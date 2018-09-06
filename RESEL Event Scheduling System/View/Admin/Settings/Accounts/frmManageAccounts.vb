Public Class frmManageAccounts

    Public _account_obj As AccountClass
    Dim _flag As String = ""
    Public Shared idAccnt As Integer = 0
    Dim _nameAllow As String = "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuiopasdfghjklzxcvbnm -"
    Private Sub frmManageAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Controls orientation
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcAccountInfo.Enabled = False
            tcPersonalInfo.Enabled = False
            tcSearch.Enabled = True
            chkShowPassword.Enabled = False
            dgvList.Rows.Clear()
            dgvList.ClearSelection()
            LoadAYToCbo(cboUnit)
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            _flag = "New"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcAccountInfo.Enabled = True
            tcPersonalInfo.Enabled = True
            txtUsername.Enabled = False
            txtPassword.Enabled = False
            tcSearch.Enabled = False
            cboStatus.Enabled = False
            cboStatus.SelectedIndex = 0
            LoadAYToCbo(cboUnit)
            txtUsername.Text = String.Format("{0}-{1}", "RESEL", generateUsername())
            txtPassword.Text = generatePassword()
            chkShowPassword.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _account_obj = New AccountClass
            If RequiredField(txtFn.Text, txtLn.Text, txtPassword.Text, cboStatus.Text, txtUsername.Text, cboPosition.Text,
                             cboUnit.Text, cboUserType.Text) = True Then
                If _flag = "New" Then
                    With _account_obj
                        .Account_fn = txtFn.Text
                        .Account_ln = txtLn.Text
                        .Account_position = cboPosition.Text
                        .Account_unit_abbrev = cboUnit.Text
                        .Account_unit_name = .getUnit(.Account_unit_abbrev)
#Region "Comment"
                        'If .Account_unit_abbrev = "RESEL" Then
                        '    .Account_unit_name = "RESEARCH, EXTENSION SERVICES AND EXTERNAL LINKAGES"
                        '    .Account_username = txtUsername.Text
                        '    .Account_password = txtPassword.Text
                        '    .Account_type = cboUserType.Text
                        '    .Account_status = cboStatus.Text
                        '    If .Account_type = "ADMIN" Then
                        '        If .hasAdmin = True Then
                        '            MessageBox.Show("Only one admin is allowed.", "Register New Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '            Exit Sub
                        '        Else
                        '            '
                        '            If .AddAccount = True Then
                        '                MessageBox.Show("New Account has been saved.", "Register New Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '                btnNew.Enabled = True
                        '                btnSave.Enabled = False
                        '                btnEdit.Enabled = False
                        '                btnShowRecords.Enabled = True
                        '                btnCancel.Enabled = True
                        '                tcAccountInfo.Enabled = False
                        '                tcPersonalInfo.Enabled = False
                        '                tcSearch.Enabled = True
                        '                chkShowPassword.Enabled = False
                        '                LoadAYToCbo(cboUnit)
                        '                dgvList.Rows.Clear()
                        '                dgvList.ClearSelection()
                        '                txtFn.Clear()
                        '                txtLn.Clear()
                        '                txtPassword.Clear()
                        '                txtSearch.Clear()
                        '                txtUsername.Clear()
                        '                cboPosition.SelectedIndex = -1
                        '                cboStatus.SelectedIndex = -1
                        '                cboUnit.SelectedIndex = -1
                        '                cboUserType.SelectedIndex = -1
                        '                btnNew.Focus()
                        '                _flag = ""
                        '            Else
                        '                MessageBox.Show("Error.", "Register New Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '            End If


                        '        End If
                        '    Else
                        '        If .AddAccount = True Then
                        '            MessageBox.Show("New Account has been saved.", "Register New Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '            btnNew.Enabled = True
                        '            btnSave.Enabled = False
                        '            btnEdit.Enabled = False
                        '            btnShowRecords.Enabled = True
                        '            btnCancel.Enabled = True
                        '            tcAccountInfo.Enabled = False
                        '            tcPersonalInfo.Enabled = False
                        '            tcSearch.Enabled = True
                        '            chkShowPassword.Enabled = False
                        '            LoadAYToCbo(cboUnit)
                        '            dgvList.Rows.Clear()
                        '            dgvList.ClearSelection()
                        '            txtFn.Clear()
                        '            txtLn.Clear()
                        '            txtPassword.Clear()
                        '            txtSearch.Clear()
                        '            txtUsername.Clear()
                        '            cboPosition.SelectedIndex = -1
                        '            cboStatus.SelectedIndex = -1
                        '            cboUnit.SelectedIndex = -1
                        '            cboUserType.SelectedIndex = -1
                        '            btnNew.Focus()
                        '            _flag = ""
                        '        Else
                        '            MessageBox.Show("Error.", "Register New Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '        End If


                        '    End If
                        ' Else
#End Region
                        .Account_username = txtUsername.Text
                        .Account_password = txtPassword.Text
                        .Account_type = cboUserType.Text
                        .Account_status = cboStatus.Text

                        .Account_isActive = "FALSE"
                        .Account_isLogin = "FALSE"
                        If .AddAccountDynamic(.Account_unit_name, .Account_unit_abbrev) = True Then
                            MessageBox.Show("New Account has been saved.", "Register New Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            btnNew.Enabled = True
                            btnSave.Enabled = False
                            btnEdit.Enabled = False
                            btnShowRecords.Enabled = True
                            btnCancel.Enabled = True
                            tcAccountInfo.Enabled = False
                            tcPersonalInfo.Enabled = False
                            tcSearch.Enabled = True
                            chkShowPassword.Enabled = False
                            LoadAYToCbo(cboUnit)
                            dgvList.Rows.Clear()
                            dgvList.ClearSelection()
                            txtFn.Clear()
                            txtLn.Clear()
                            txtPassword.Clear()
                            txtSearch.Clear()
                            txtUsername.Clear()
                            cboPosition.SelectedIndex = -1
                            cboStatus.SelectedIndex = -1
                            cboUnit.SelectedIndex = -1
                            cboUserType.SelectedIndex = -1
                            btnNew.Focus()
                            _flag = ""
                        Else
                            MessageBox.Show("Error.", "Register New Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        'End If

                    End With
                ElseIf _flag = "Edit" Then
                    With _account_obj
                        .Idaccount = idAccnt
                        .Account_fn = txtFn.Text
                        .Account_ln = txtLn.Text
                        .Account_position = cboPosition.Text
                        '  .Account_unit_abbrev = cboUnit.Text
#Region "Comment"
                        'If .Account_unit_abbrev = "RESEL" Then
                        '    .Account_unit_name = "RESEARCH, EXTENSION SERVICES AND EXTERNAL LINKAGES"
                        '    .Account_username = txtUsername.Text
                        '    .Account_password = txtPassword.Text
                        '    .Account_type = cboUserType.Text
                        '    .Account_status = cboStatus.Text
                        '    .Account_unit_abbrev = "RESEL"
                        '    If .Account_type = "ADMIN" Then
                        '        If .hasAdminUpdate(.Idaccount) = True Then
                        '            MessageBox.Show("Only one admin is allowed.", "Register New Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '            Exit Sub
                        '        Else
                        '            If .UpdateAccount = True Then
                        '                MessageBox.Show("Account has been updated.", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '                btnNew.Enabled = True
                        '                btnSave.Enabled = False
                        '                btnEdit.Enabled = False
                        '                btnShowRecords.Enabled = True
                        '                btnCancel.Enabled = True
                        '                tcAccountInfo.Enabled = False
                        '                tcPersonalInfo.Enabled = False
                        '                tcSearch.Enabled = True
                        '                chkShowPassword.Enabled = False
                        '                LoadAYToCbo(cboUnit)
                        '                dgvList.Rows.Clear()
                        '                dgvList.ClearSelection()
                        '                txtFn.Clear()
                        '                txtLn.Clear()
                        '                txtPassword.Clear()
                        '                txtSearch.Clear()
                        '                txtUsername.Clear()
                        '                cboPosition.SelectedIndex = -1
                        '                cboStatus.SelectedIndex = -1
                        '                cboUnit.SelectedIndex = -1
                        '                cboUserType.SelectedIndex = -1
                        '                btnNew.Focus()
                        '                _flag = ""
                        '            Else
                        '                MessageBox.Show("Error.", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '            End If
                        '        End If
                        '    Else
                        '        If .UpdateAccount = True Then
                        '            MessageBox.Show("Account has been updated.", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        '            btnNew.Enabled = True
                        '            btnSave.Enabled = False
                        '            btnEdit.Enabled = False
                        '            btnShowRecords.Enabled = True
                        '            btnCancel.Enabled = True
                        '            tcAccountInfo.Enabled = False
                        '            tcPersonalInfo.Enabled = False
                        '            tcSearch.Enabled = True
                        '            chkShowPassword.Enabled = False
                        '            LoadAYToCbo(cboUnit)
                        '            dgvList.Rows.Clear()
                        '            dgvList.ClearSelection()
                        '            txtFn.Clear()
                        '            txtLn.Clear()
                        '            txtPassword.Clear()
                        '            txtSearch.Clear()
                        '            txtUsername.Clear()
                        '            cboPosition.SelectedIndex = -1
                        '            cboStatus.SelectedIndex = -1
                        '            cboUnit.SelectedIndex = -1
                        '            cboUserType.SelectedIndex = -1
                        '            btnNew.Focus()
                        '            _flag = ""
                        '        Else
                        '            MessageBox.Show("Error.", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        '        End If
                        '    End If
                        'Else
#End Region
                        .Account_isActive = "FALSE"
                        .Account_isLogin = "FALSE"
                        .Account_username = txtUsername.Text
                            .Account_password = txtPassword.Text
                            .Account_type = cboUserType.Text
                            .Account_status = cboStatus.Text
                            .Account_unit_abbrev = cboUnit.Text
                            .Account_unit_name = .getUnit(.Account_unit_abbrev)
                        If .UpdateAccount(.Account_unit_name, .Account_unit_abbrev) = True Then
                            MessageBox.Show("Account has been updated.", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            btnNew.Enabled = True
                            btnSave.Enabled = False
                            btnEdit.Enabled = False
                            btnShowRecords.Enabled = True
                            btnCancel.Enabled = True
                            tcAccountInfo.Enabled = False
                            tcPersonalInfo.Enabled = False
                            tcSearch.Enabled = True
                            chkShowPassword.Enabled = False
                            LoadAYToCbo(cboUnit)

                            txtFn.Clear()
                            txtLn.Clear()
                            txtPassword.Clear()
                            txtSearch.Clear()
                            txtUsername.Clear()
                            cboPosition.SelectedIndex = -1
                            cboStatus.SelectedIndex = -1
                            cboUnit.SelectedIndex = -1
                            cboUserType.SelectedIndex = -1
                            btnNew.Focus()
                            _flag = ""
                            dgvList.Rows.Clear()
                            dgvList.ClearSelection()
                        Else
                            MessageBox.Show("Error.", "Update Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        'End If

                    End With
                Else
                    Exit Sub
                End If

            Else
                MessageBox.Show("All fields are required", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If _flag = "New" Then
                Try
                    btnNew.Enabled = True
                    btnSave.Enabled = False
                    btnEdit.Enabled = False
                    btnShowRecords.Enabled = True
                    btnCancel.Enabled = True
                    tcAccountInfo.Enabled = False
                    tcPersonalInfo.Enabled = False
                    tcSearch.Enabled = True
                    chkShowPassword.Enabled = False

                    LoadAYToCbo(cboUnit)
                    txtFn.Clear()
                    txtLn.Clear()
                    txtPassword.Clear()
                    txtUsername.Clear()
                    txtSearch.Clear()
                    cboPosition.SelectedIndex = -1
                    cboStatus.SelectedIndex = -1
                    cboUnit.SelectedIndex = -1
                    cboUserType.SelectedIndex = -1
                    dgvList.Rows.Clear()
                    dgvList.ClearSelection()
                Catch ex As Exception

                End Try
            ElseIf _flag = "Edit" Then
                Try
                    btnNew.Enabled = True
                    btnSave.Enabled = False
                    btnEdit.Enabled = False
                    btnShowRecords.Enabled = True
                    btnCancel.Enabled = True
                    tcAccountInfo.Enabled = False
                    tcPersonalInfo.Enabled = False
                    tcSearch.Enabled = True
                    chkShowPassword.Enabled = False

                    LoadAYToCbo(cboUnit)
                    txtFn.Clear()
                    txtLn.Clear()
                    txtPassword.Clear()
                    txtUsername.Clear()
                    txtSearch.Clear()
                    cboPosition.SelectedIndex = -1
                    cboStatus.SelectedIndex = -1
                    cboUnit.SelectedIndex = -1
                    cboUserType.SelectedIndex = -1
                    dgvList.Rows.Clear()
                    dgvList.ClearSelection()
                Catch ex As Exception

                End Try
            ElseIf _flag = "" Then
                txtFn.Clear()
                txtLn.Clear()
                txtPassword.Clear()
                txtUsername.Clear()
                txtSearch.Clear()
                cboPosition.SelectedIndex = -1
                cboStatus.SelectedIndex = -1
                cboUnit.SelectedIndex = -1
                cboUserType.SelectedIndex = -1
                Dispose()
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmAccountsRecords.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmManageAccounts_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            _flag = "Edit"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            tcAccountInfo.Enabled = True
            tcPersonalInfo.Enabled = True
            tcSearch.Enabled = False
            cboStatus.Enabled = True
            txtPassword.Enabled = True
            '  LoadAYToCbo(cboUnit)
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        Try
            _account_obj = New AccountClass
            LoadAYToCbo(cboUnit)
            With _account_obj
                .LoadAccountToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                idAccnt = dgvList.SelectedRows(0).Cells(0).Value.ToString
                txtFn.Text = .Account_fn
                txtLn.Text = .Account_ln
                txtPassword.Text = .Account_password
                txtUsername.Text = .Account_username
                cboPosition.SelectedIndex = cboPosition.FindString(.Account_position)
                cboUnit.SelectedIndex = cboUnit.FindString(.Account_unit_abbrev)
                cboUserType.SelectedIndex = cboUserType.FindString(.Account_type)
                cboStatus.SelectedIndex = cboStatus.FindString(.Account_status)
            End With
            _flag = "Edit"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            tcAccountInfo.Enabled = True
            tcPersonalInfo.Enabled = True
            tcSearch.Enabled = False
            cboStatus.Enabled = True
            txtPassword.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            _account_obj = New AccountClass
            LoadAYToCbo(cboUnit)
            With _account_obj
                .LoadAccountToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                idAccnt = dgvList.SelectedRows(0).Cells(0).Value.ToString
                txtFn.Text = .Account_fn
                txtLn.Text = .Account_ln
                txtPassword.Text = .Account_password
                txtUsername.Text = .Account_username
                cboPosition.SelectedIndex = cboPosition.FindString(.Account_position)
                cboUnit.SelectedIndex = cboUnit.FindString(.Account_unit_abbrev)
                cboUserType.SelectedIndex = cboUserType.FindString(.Account_type)
                cboStatus.SelectedIndex = cboStatus.FindString(.Account_status)
            End With
            _flag = "Edit"
            btnNew.Enabled = False
            btnSave.Enabled = False
            btnEdit.Enabled = True
            tcAccountInfo.Enabled = False
            tcPersonalInfo.Enabled = False
            tcSearch.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _account_obj = New AccountClass
            With _account_obj
                .SearchAccountRecords(dgvList, "ALL", txtSearch.Text, 1, "Edit")
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtFn_TextChanged(sender As Object, e As EventArgs) Handles txtFn.TextChanged
        Try
            keyAllow(_nameAllow, txtFn)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtLn_TextChanged(sender As Object, e As EventArgs) Handles txtLn.TextChanged
        Try
            keyAllow(_nameAllow, txtLn)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        If chkShowPassword.Checked = True Then
            txtPassword.UseSystemPasswordChar = False
        Else
            txtPassword.UseSystemPasswordChar = True
        End If
    End Sub

End Class