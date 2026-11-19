Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Data.OleDb

'Imports ACCESO
Imports LOGICA



Public Class frmUsuariosUpd
    
    Dim id As String
    Dim idjunta As String
    Dim idJas As String
    Dim idusuario As Integer
    'Dim u As New LOGICA.clsUsuario


    'Dim u As New clsUsuario
    Dim vf As New clsValidateForm
    Dim dni_ini As String
    Dim ruc_ini As String
    Sub FormClear()
        txtNombre.ResetText()
        txtApellidoM.ResetText()
        txtApellidoP.ResetText()
        txtDNI.ResetText()
        txtRUC.ResetText()
        txtEmail.ResetText()
        txtCelular.ResetText()
        txtDomicilio.ResetText()
        'cmbSexo.ResetText()
        'cmbTipo.ResetText()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Select Case cmbTipo.SelectedValue
            Case 1
                'vf.item(1).allowblank = False 'dni obligatorio ---- SE DESACTIVO CAMBO SOLO PARA REGISTRAR FALLECIDOS
                vf.item(2).allowblank = True 'ruc no es obligatorio
                vf.item(5).allowblank = False 'sexo obligatorio
                vf.item(7).allowblank = False 'apellido paterno obligatorio
                vf.item(8).allowblank = False 'apellido materno obligatorio
            Case 2
                vf.item(1).allowblank = True 'dni no  obligatorio
                vf.item(2).allowblank = False 'ruc obligatorio
                vf.item(5).allowblank = True 'sexo no obligatorio
                vf.item(7).allowblank = True 'apellido paterno no es obligatorio
                vf.item(8).allowblank = True 'apellido materno no es obligatorio
            Case 3
                vf.item(1).allowblank = True 'dni no  obligatorio
                vf.item(2).allowblank = True 'ruc no es obligatorio
                vf.item(5).allowblank = True 'sexo no obligatorio
                vf.item(7).allowblank = True 'apellido paterno no es obligatorio
                vf.item(8).allowblank = True 'apellido materno no es obligatorio
        End Select
        If (vf.startValidation) Then
            Dim flagDNI As Boolean = False
            Dim flagRUC As Boolean = False
            'If (txtDNI.Text <> dni_ini) Then
            '    If (txtDNI.Text <> "") Then
            '        flagDNI = clsUsuario.ExisteDNI(txtDNI.Text, cmbJunta.SelectedValue)
            '    End If
            'End If
            If (txtRUC.Text <> ruc_ini) Then
                If (txtRUC.Text <> "") Then
                    flagRUC = clsUsuario.ExisteRUC(txtRUC.Text, cmbJunta.SelectedValue)
                End If
            End If

            If (Not flagDNI) Then
                If (Not flagRUC) Then
                    Dim u As New clsUsuario(idJas, cmbTipo.SelectedValue, txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtDNI.Text, txtRUC.Text, txtDomicilio.Text, txtEmail.Text, txtCelular.Text, cmbSexo.SelectedValue, ACCESO.Conexion.getDateServer)
                    u.id = idusuario

                    u.Update()
                    frmUsuarios.gridUsuarios.DataSource = frmUsuarios.Filtrar()
                    vf.resetForm()
                    MsgBox("Información actualizada satisfactoriamente", MsgBoxStyle.Information)
                    Me.Close()

                Else
                    MsgBox("RUC ingresado ya se encuentra registrado. No se puede insertar un DNI duplicado", MsgBoxStyle.Exclamation)
                End If
            Else
                MsgBox("DNI ingresado ya se encuentra registrado. No se puede insertar un DNI duplicado", MsgBoxStyle.Exclamation)
            End If

        Else
            MsgBox("Información invalida o incompleta", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub frmUsuariosUpd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vf.removeForms()
        vf.addTextbox(txtDNI, "numeric", True)
        vf.addTextbox(txtRUC, "numeric", True)
        vf.addTextbox(txtNombre, "string", False)
        vf.addCombobox(cmbJunta, "string", False)
        vf.addCombobox(cmbSexo, "string", True)
        vf.addCombobox(cmbTipo, "string", False)
        vf.addTextbox(txtApellidoP, "string", True)
        vf.addTextbox(txtApellidoM, "string", True)
        vf.item(1).minLength = 8
        vf.item(1).maxLength = 8
        vf.item(2).minLength = 11
        vf.item(2).maxLength = 11
        vf.resetForm()

        clsUsuario.LoadComboSexo(cmbSexo)
        clsJunta.LoadCombo(cmbJunta)
        clsUsuario.LoadComboTipoPersona(cmbTipo)
        cmbJunta.Enabled = False

        'With frmUsuarios.gridUsuarios
        '    idJas = .Item(0, .CurrentRow.Index).Value
        '    'idjunta = .Item(1, .CurrentRow.Index).Value
        '    'u = clsUsuario.LoadUsuario(id, idjunta)
        'End With
        'clsEntidad.LoadCombo(cmbEntidad, " where cEstado=1")

        'clsTipoCuentas.LoadCombo(cmbTipoCta)
        'cmbTipoTran.SelectedIndex = 0
        idJas = frmUsuarios.gridUsuarios.Item(0, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        idusuario = frmUsuarios.gridUsuarios.Item(1, frmUsuarios.gridUsuarios.CurrentRow.Index).Value

        cmbTipo.SelectedValue = frmUsuarios.gridUsuarios.Item(10, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        cmbSexo.SelectedValue = frmUsuarios.gridUsuarios.Item(13, frmUsuarios.gridUsuarios.CurrentRow.Index).Value

        txtDNI.Text = frmUsuarios.gridUsuarios.Item(5, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtRUC.Text = frmUsuarios.gridUsuarios.Item(6, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtNombre.Text = frmUsuarios.gridUsuarios.Item(2, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtApellidoP.Text = frmUsuarios.gridUsuarios.Item(3, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtApellidoM.Text = frmUsuarios.gridUsuarios.Item(4, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtDomicilio.Text = frmUsuarios.gridUsuarios.Item(7, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtCelular.Text = frmUsuarios.gridUsuarios.Item(9, frmUsuarios.gridUsuarios.CurrentRow.Index).Value
        txtEmail.Text = frmUsuarios.gridUsuarios.Item(8, frmUsuarios.gridUsuarios.CurrentRow.Index).Value

        'txtCCI.Text = frmTransacciones.dgTransferencias.Item(5, frmTransacciones.dgTransferencias.CurrentRow.Index).Value
        'cmbTipoTran.Text = frmTransacciones.dgTransferencias.Item(9, frmTransacciones.dgTransferencias.CurrentRow.Index).Value
        'txtDescripcion.Text = frmTransacciones.dgTransferencias.Item(7, frmTransacciones.dgTransferencias.CurrentRow.Index).Value
        'txtMonto.Text = frmTransacciones.dgTransferencias.Item(8, frmTransacciones.dgTransferencias.CurrentRow.Index).Value

        'clsUsuario.LoadComboSexo(cmbSexo)
        'clsJunta.LoadCombo(cmbJunta)
        'clsUsuario.LoadComboTipoPersona(cmbTipo)
        'With frmUsuarios.gridUsuarios
        '    id = .Item(0, .CurrentRow.Index).Value
        '    idJas = .Item(1, .CurrentRow.Index).Value
        '    u = clsUsuario.LoadUsuario(id, idjunta)
        'End With
        'cmbJunta.SelectedValue = u.idJas
        'cmbSexo.SelectedValue = u.sexo
        'cmbTipo.SelectedValue = u.idTipoPersona
        'txtNombre.Text = u.nombre
        'txtApellidoP.Text = u.apePaterno
        'txtApellidoM.Text = u.apeMaterno
        'txtCelular.Text = u.celular
        'txtRUC.Text = u.ruc
        'ruc_ini = u.ruc
        'txtDNI.Text = u.dni
        'dni_ini = u.dni
        'txtEmail.Text = u.email
        'txtDomicilio.Text = u.direccion
        'cmbJunta.Enabled = False
        ''agregamos conyuge

    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged

    End Sub
End Class