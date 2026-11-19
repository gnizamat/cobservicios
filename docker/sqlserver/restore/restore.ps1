# Restaura DB_JASS_NVOTALLAN.BAK en el contenedor cobservicios-sqlserver-legacy.
$ErrorActionPreference = "Stop"

$Container = "cobservicios-sqlserver-legacy"
$SaPassword = "Cobser_Legacy_2022!"
$Sqlcmd = "/opt/mssql-tools18/bin/sqlcmd"
$BakPath = "/backup/DB_JASS_NVOTALLAN.BAK"
$DbName = "DB_JASS_NVOTALLAN"

function Invoke-SqlcmdInContainer {
  param([Parameter(Mandatory = $true)][string]$Query)
  docker exec $Container $Sqlcmd -S localhost -U sa -P $SaPassword -C -h -1 -W -Q $Query
}

$running = docker ps --filter "name=$Container" --format "{{.Names}}"
if (-not $running) {
  Write-Host "Contenedor no está arriba. Ejecuta: npm run db:legacy:up"
  exit 1
}

Write-Host "Esperando SQL Server..."
$ready = $false
for ($i = 0; $i -lt 40; $i++) {
  docker exec $Container $Sqlcmd -S localhost -U sa -P $SaPassword -C -Q "SELECT 1" 2>$null | Out-Null
  if ($LASTEXITCODE -eq 0) {
    $ready = $true
    break
  }
  Start-Sleep -Seconds 3
}
if (-not $ready) {
  Write-Host "SQL Server no respondió a tiempo."
  exit 1
}

Write-Host "Obteniendo FILELISTONLY..."
$csv = docker exec $Container $Sqlcmd -S localhost -U sa -P $SaPassword -C -s "," -W -h -1 -Q "SET NOCOUNT ON; RESTORE FILELISTONLY FROM DISK = N'$BakPath'" 2>&1
$lines = @($csv | Where-Object { $_ -match "," -and $_ -notmatch "Msg |rows affected" })

if ($lines.Count -lt 1) {
  Write-Host "No se pudo leer FILELISTONLY. Salida:"
  Write-Host $csv
  exit 1
}

$dataLogical = $null
$logLogical = $null
foreach ($line in $lines) {
  $parts = $line -split ","
  if ($parts.Count -lt 3) { continue }
  $logical = $parts[0].Trim()
  $type = $parts[2].Trim()
  if ($type -eq "D" -and -not $dataLogical) { $dataLogical = $logical }
  if ($type -eq "L" -and -not $logLogical) { $logLogical = $logical }
}

if (-not $dataLogical -or -not $logLogical) {
  Write-Host "No se detectaron logical names. Líneas:"
  $lines | ForEach-Object { Write-Host $_ }
  Write-Host "Usando restore.sql estático..."
  docker exec $Container $Sqlcmd -S localhost -U sa -P $SaPassword -C -i /restore/restore.sql
  exit $LASTEXITCODE
}

Write-Host "Data logical: $dataLogical | Log logical: $logLogical"

$restoreSql = @"
USE [master];
IF DB_ID(N'$DbName') IS NOT NULL
BEGIN
  ALTER DATABASE [$DbName] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
  DROP DATABASE [$DbName];
END
RESTORE DATABASE [$DbName]
FROM DISK = N'$BakPath'
WITH
  MOVE N'$dataLogical' TO N'/var/opt/mssql/data/${DbName}.mdf',
  MOVE N'$logLogical' TO N'/var/opt/mssql/data/${DbName}_log.ldf',
  REPLACE,
  STATS = 10;
"@

$tmp = Join-Path $env:TEMP "cobservicios-restore.sql"
Set-Content -Path $tmp -Value $restoreSql -Encoding ASCII
docker cp $tmp "${Container}:/tmp/restore-dynamic.sql"
docker exec $Container $Sqlcmd -S localhost -U sa -P $SaPassword -C -i /tmp/restore-dynamic.sql

if ($LASTEXITCODE -ne 0) {
  Write-Host "Restore falló. Revisa la salida anterior."
  exit $LASTEXITCODE
}

Write-Host "OK. localhost,1433 | sa / Cobser_Legacy_2022! | DB: $DbName"
