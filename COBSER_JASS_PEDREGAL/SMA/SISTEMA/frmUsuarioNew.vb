Imports ACCESO
Imports LOGICA
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmUsuarioNew
    Dim idJas As String
    Dim vf As New clsValidateForm
    Dim flagDNI As Boolean = False


    Private Sub frmUsuarioNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        clsJunta.LoadCombo(cmbJunta)
        'idJas = frmUsuarios.tvJuntas.SelectedNode.Tag
        'idJas = idJas.Substring(2)
        clsUsuario.LoadComboTipoPersona(cmbTipo)
        clsUsuario.LoadComboSexo(cmbSexo)
        vf.removeForms()
        vf.addTextbox(txtDNI, "numeric", True)
        vf.addTextbox(txtRUC, "numeric", True)
        vf.addTextbox(txtNombre, "string", False)
        vf.addCombobox(cmbJunta, "string", False)
        vf.addCombobox(cmbSexo, "string", True)
        vf.addCombobox(cmbTipo, "string", False)
        vf.addTextbox(txtApellidoP, "string", True)
        vf.addTextbox(txtApellidoM, "string", True)

        If (frmPrincipal.userSystem.idInterfaz = 4) Then
            cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
            cmbJunta.Enabled = False
        End If
        idJas = cmbJunta.SelectedValue
        clsValidateForm.LimpiarControles(Me.GroupPanel1)
        cmbJunta.SelectedValue = idJas
        cmbTipo.SelectedIndex = 0
        cmbSexo.SelectedIndex = 0
        LabelX4.Visible = False
        txtRUC.Visible = False

    End Sub
    Sub ChangeValidate()
        Select Case cmbTipo.SelectedValue
            Case 1
                vf.item(1).allowblank = False 'dni obligatorio
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
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim flagHomonimo As Boolean = False
        Dim flagSave As Boolean = True
        Dim msgHomonimo As DialogResult
        'Dim utmp1 As New clsUsuario
        Dim m As MsgBoxResult
        ChangeValidate()
        'If (vf.startValidation) Then
        Dim flagDNI As Boolean = False
        Dim flagRUC As Boolean = False
        Dim sexo As String

        If (cmbSexo.SelectedIndex = -1) Then
            sexo = ""
        Else
            sexo = cmbSexo.SelectedValue
        End If
        idJas = cmbJunta.SelectedValue
        Dim u As New clsUsuario(idJas, cmbTipo.SelectedValue, txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtDNI.Text, txtRUC.Text, txtDomicilio.Text, txtEmail.Text, txtCelular.Text, cmbSexo.SelectedValue, ACCESO.Conexion.getDateServer)

        If (u.dni <> "") Then
            flagDNI = clsUsuario.ExisteDNI(txtDNI.Text, cmbJunta.SelectedValue)
            If flagDNI Then
                'utmp = clsUsuario.LoadUsuarioByDNI(u.dni)
            End If
        End If
        If (u.ruc <> "") Then
            flagRUC = clsUsuario.ExisteRUC(txtRUC.Text, cmbJunta.SelectedValue)
            If flagRUC Then
                'utmp = clsUsuario.LoadUsuarioByRUC(u.ruc)
            End If
        End If
        If (Not flagDNI) Then
            If (Not flagRUC) Then
                If (clsUsuario.isHomonimo(cmbJunta.SelectedValue, txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text)) Then
                    flagHomonimo = True
                End If
                If (flagHomonimo) Then
                    msgHomonimo = MessageBox.Show("Ya existe un usuario registrado con los mismos nombres y apellidos." & vbCrLf & "Desea continuar y grabarlo como homonimo?", "SIRIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (msgHomonimo = Windows.Forms.DialogResult.No) Then
                        flagSave = False
                    End If
                End If
                'If (flagSave) Then
                'Dim dtfecha As DateTime = DateTime.Now

                u.Insert()
                m = MessageBox.Show("Informacion registrada satisfactroriamente." & vbCrLf & "Desea continuar?", "SISCOB", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                frmUsuarios.gridUsuarios.DataSource = frmUsuarios.Filtrar()
                clsValidateForm.LimpiarControles(Me.GroupPanel1)
                vf.resetForm()
                If (frmPrincipal.userSystem.idInterfaz = 3) Then
                    cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                    cmbJunta.Enabled = False
                End If
                If (m = Windows.Forms.DialogResult.No) Then
                    Me.Close()
                End If
                'End If
            Else
                'If utmp.estado = "0" Then

                m = MessageBox.Show("Se ha encontrado un registro que coincide con el número de RUC y se encuentra eliminado. Desea remplazar los datos del registro?", "SIGMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If m = MsgBoxResult.Yes Then

                    'u.id = utmp.id
                    'u.idJas = utmp.idJas
                    u.estado = "1"
                    u.Update()
                    m = MessageBox.Show("Informacion registrada satisfactroriamente." & vbCrLf & "Desea continuar?", "SIRIG", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    frmUsuarios.gridUsuarios.DataSource = frmUsuarios.Filtrar()
                    clsValidateForm.LimpiarControles(Me.GroupPanel1)
                    vf.resetForm()
                    If (frmPrincipal.userSystem.idInterfaz = 3) Then
                        cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                        cmbJunta.Enabled = False
                    End If
                    If (m = Windows.Forms.DialogResult.No) Then
                        Me.Close()
                    End If
                End If

                MsgBox("RUC ingresado ya se encuentra registrado. No se puede insertar un RUC duplicado", MsgBoxStyle.Exclamation)
                'End If

            End If
        Else
            'If utmp.estado = "0" Then
            'm = MessageBox.Show("Se ha encontrado un registro que coincide con el número de DNI y se encuentra eliminado. Desea remplazar los datos del registro?", "SIGMA", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            'If m = MsgBoxResult.Yes Then
            'u.id = utmp.id
            'u.idJas = utmp.idJas
            'u.estado = "1"
            'u.Update()

            m = MessageBox.Show("Informacion registrada satisfactroriamente." & vbCrLf & "Desea continuar?", "COBSER", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            frmUsuarios.gridUsuarios.DataSource = frmUsuarios.Filtrar()
            clsValidateForm.LimpiarControles(Me.GroupPanel1)
            vf.resetForm()
            If (frmPrincipal.userSystem.idInterfaz = 3) Then
                cmbJunta.SelectedValue = frmPrincipal.userSystem.idJunta
                cmbJunta.Enabled = False
            End If
            If (m = Windows.Forms.DialogResult.No) Then
                Me.Close()
            End If
            'End If
            'Else
            MsgBox("DNI ingresado ya se encuentra registrado. No se puede insertar un DNI duplicado", MsgBoxStyle.Exclamation)
        End If


        'End If


    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        Try
            Select cmbTipo.SelectedIndex
                Case 0
                    LabelX4.Visible = False
                    txtRUC.Visible = False

                    LabelX5.Visible = True
                    LabelX6.Visible = True
                    LabelX8.Visible = True
                    txtDNI.Visible = True
                    txtApellidoP.Visible = True
                    txtApellidoM.Visible = True

                Case 1
                    'txtRepresentante.Visible = True
                    'lblRepresentante.Visible = True
                    LabelX4.Visible = True
                    txtRUC.Visible = True
                    LabelX5.Visible = False
                    LabelX6.Visible = False
                    LabelX8.Visible = False
                    txtDNI.Visible = False
                    txtApellidoP.Visible = False
                    txtApellidoM.Visible = False
                    
                Case 2
                    LabelX4.Visible = True
                    txtRUC.Visible = True
                    LabelX5.Visible = False
                    LabelX6.Visible = False
                    LabelX8.Visible = False
                    txtDNI.Visible = False
                    txtApellidoP.Visible = False
                    txtApellidoM.Visible = False

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbSexo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSexo.SelectedIndexChanged

    End Sub

    Private Sub txtDNI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDNI.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtNombre.Focus()
        End If
    End Sub

    Private Sub txtDNI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDNI.TextChanged

    End Sub

    Private Sub txtNombre_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtApellidoP.Focus()
        End If
    End Sub

    Private Sub txtNombre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged

    End Sub

    Private Sub txtApellidoP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidoP.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtApellidoM.Focus()
        End If
    End Sub

    Private Sub txtApellidoP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellidoP.TextChanged
        
    End Sub

    Private Sub txtApellidoM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellidoM.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtDomicilio.Focus()
        End If
    End Sub

    Private Sub txtApellidoM_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtApellidoM.TextChanged

    End Sub

    Private Sub txtDomicilio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDomicilio.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtCelular.Focus()
        End If
    End Sub

    Private Sub txtDomicilio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDomicilio.TextChanged

    End Sub

    Private Sub txtCelular_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCelular.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            txtCelular.Focus()
        End If
    End Sub

    Private Sub txtCelular_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCelular.TextChanged

    End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            btnSave.Focus()

        End If
    End Sub

    Private Sub txtEmail_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEmail.TextChanged

    End Sub
End Class