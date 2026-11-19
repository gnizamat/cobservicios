Public Class frmInicio
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub
    'Inicio de formulario
    Private Sub frmInicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim c As New ACCESO.Conexion
        Dim ttt As New ToolTip
        'Dim source As String = "1234"

        ttt.SetToolTip(btnAceptar, "Aceptar")
        ttt.SetToolTip(btnConnect, "Parametros de Conexión")
        frmSplash.Show()
        Me.Visible = False
        'abriendo conexion
        If (c.Connect()) Then
            Dim dt = c.Query("select idGrupo,vNombre from sysGrupo where idPGrupo=" & c.idGrupo & " and cEstado=1")
            c.Close()
            If (String.Compare(c.msgError, "") = 0) Then
                If dt.Rows.Count > 0 Then
                    cmbGrupo.DataSource = dt
                    cmbGrupo.ValueMember = dt.Columns(0).ToString()
                    cmbGrupo.DisplayMember = dt.Columns(1).ToString()
                    cmbGrupo.Text = ""
                Else
                    Me.btnAceptar.Enabled = False
                End If
            Else
                Me.Show()
                MsgBox(c.msgError, MsgBoxStyle.Critical)
            End If
        Else
            Me.Show()
            MsgBox(c.msgError, MsgBoxStyle.Critical)
        End If
        Me.PictureBox1.Controls.Add(lblGroup)
        Me.PictureBox1.Controls.Add(lblSplahText)

        Me.PictureBox1.Controls.Add(lblUser)
        Me.PictureBox1.Controls.Add(lblPass)
        'Me.PictureBox1.Controls.Add(pbImage)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim usuario As New ACCESO.User(cmbGrupo.SelectedValue, txtUsuario.Text, txtPassword.Text)
        Dim c As New ACCESO.Conexion
        Dim g As ACCESO.Grupo
        c.LoadConnection()
        If (usuario.Validar()) Then
            g = ACCESO.Grupo.load(usuario.idGrupo)
            'guardo los datos del usuario
            frmPrincipal.userSystem.usuario = usuario.usuario
            frmPrincipal.userSystem.password = usuario.password
            frmPrincipal.userSystem.idGrupo = usuario.idGrupo
            frmPrincipal.userSystem.idInterfaz = c.idGrupo
            frmPrincipal.userSystem.idRegion = g.idRegion
            frmPrincipal.userSystem.idDistritoRiego = g.idDistritoRiego
            frmPrincipal.userSystem.idJunta = g.idJunta
            frmPrincipal.userSystem.idComision = g.idComision
            'llamo al formulario principal
            frmPrincipal.Show()
            Me.Close()
        Else
            MsgBox("Usuario o contraseña incorrecta", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        frmConexion.ShowDialog()
    End Sub
    Private Sub txtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsuario.KeyPress
        Dim a As Char = e.KeyChar
        'MsgBox(a)
        If (a <> Convert.ToChar(Keys.Back)) Then
            If (Not Char.IsLetterOrDigit(a)) Then
                If (a <> "_" And a <> "-") Then
                    e.KeyChar = Nothing
                End If
            End If
        End If
    End Sub


   End Class

