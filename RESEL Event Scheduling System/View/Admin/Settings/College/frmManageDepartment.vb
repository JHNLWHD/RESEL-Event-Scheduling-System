Public Class frmManageDepartment

    Public _dept_obj As CollegeClass
    Dim _flag As String = ""
    Public Shared idDept As Integer = 0
    Dim _deptAllow As String = "QWERTYUIOPLKJHGFDSAZXCVBNM .qwertyuioplkjhgfdsazcvbnm"
    Public Shared coll_name As String = ""
    Dim _DN As String = ""
    Dim _DA As String = ""

    Private Sub frmManageDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _dept_obj = New CollegeClass
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcDepartmentInfo.Enabled = False
            tcList.Enabled = True
            With _dept_obj
                .LoadDeptByCollege(dgvList, frmCollegeRecords.idCOLL)
                .LoadCollege(0, frmCollegeRecords.idCOLL)
                lblCollege.Text = .College_abbrev
                coll_name = .College_name
            End With

            'LOAD LABEL TO COLLEGE ABBREV
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            _flag = "New"
            _dept_obj = New CollegeClass
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcDepartmentInfo.Enabled = True
            tcList.Enabled = False
            _dept_obj.LoadDeptByCollege(dgvList, frmCollegeRecords.idCOLL)
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _dept_obj = New CollegeClass
            With _dept_obj
                If RequiredField(txtDeptF.Text, txtDeptA.Text) = True Then
                    If _flag = "New" Then
                        .Idcollege = frmCollegeRecords.idCOLL
                        .College_name = coll_name
                        .Department_name = txtDeptF.Text
                        .Department_abbrev = txtDeptA.Text
                        If .isDeptFExist(txtDeptF.Text, "New") = True Then
                            MessageBox.Show("Department name already exist.", "Register New Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            If .isDeptAExist(txtDeptA.Text, "New") = True Then
                                MessageBox.Show("Department abbreviation already exist.", "Register New Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                            Exit Sub
                        End If
                        If .isDeptAExist(txtDeptA.Text, "New") = True Then
                            MessageBox.Show("Department abbreviation already exist.", "Register New Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        If .AddDepartment() = True Then
                            MessageBox.Show("New department has been saved", "Register New Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            .LoadDeptByCollege(dgvList, frmCollegeRecords.idCOLL)
                            btnNew.Enabled = True
                            btnSave.Enabled = False
                            btnEdit.Enabled = False
                            btnShowRecords.Enabled = True
                            btnCancel.Enabled = True
                            tcDepartmentInfo.Enabled = False
                            tcList.Enabled = True

                            txtDeptA.Clear()
                            txtDeptF.Clear()

                            _flag = ""
                        Else
                            MessageBox.Show("New department has not been saved.", "Register New Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    ElseIf _flag = "Edit" Then

                        .Iddepartment = idDept
                        .Department_name = txtDeptF.Text
                        .Department_abbrev = txtDeptA.Text
                        .College_name = coll_name
                        .Idcollege = frmCollegeRecords.idCOLL

                        If String.Compare(txtDeptF.Text, _DN, True) = 0 And String.Compare(txtDeptA.Text, _DA, True) = 0 Then
                            MessageBox.Show("Your inputs are just the same.", "Update Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                            'error message should be fixed
                        Else
                            If .isDeptFExist(txtDeptF.Text, "Edit", .Iddepartment) = True Then
                                If .isDeptAExist(txtDeptA.Text, "Edit", .Iddepartment) = True Then
                                    MessageBox.Show("Department abbreviation already exist", "Update Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                                MessageBox.Show("Department name already exist", "Update Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                            If .isDeptAExist(txtDeptA.Text, "Edit", .Iddepartment) = True Then
                                MessageBox.Show("Department abbreviation already exist", "Update Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            If .UpdateDepartment = True Then
                                MessageBox.Show("Department has been updated", "Update Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                btnNew.Enabled = True
                                btnSave.Enabled = False
                                btnEdit.Enabled = False
                                btnShowRecords.Enabled = True
                                btnCancel.Enabled = True
                                tcDepartmentInfo.Enabled = False
                                tcList.Enabled = True

                                txtDeptA.Clear()
                                txtDeptF.Clear()
                                _flag = ""
                                frmManageDepartment_Load(sender, e)
                                Exit Sub
                            Else
                                MessageBox.Show("Department has not been updated", "Update Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    Else

                    End If
                Else
                    MsgBox("All fields are required.")
                    Exit Sub
                End If
            End With

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            _flag = "Edit"
            _dept_obj = New CollegeClass
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcDepartmentInfo.Enabled = True
            tcList.Enabled = False
            _dept_obj.LoadDeptByCollege(dgvList, frmCollegeRecords.idCOLL)

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmDepartmentRecords.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If _flag = "New" Then
                _dept_obj = New CollegeClass
                btnNew.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcDepartmentInfo.Enabled = False
                tcList.Enabled = True
                _dept_obj.LoadDeptByCollege(dgvList, frmCollegeRecords.idCOLL)
                txtDeptA.Clear()
                txtDeptF.Clear()
                dgvList.ClearSelection()
            ElseIf _flag = "Edit" Then
                _dept_obj = New CollegeClass
                btnNew.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcDepartmentInfo.Enabled = False
                tcList.Enabled = True
                _dept_obj.LoadDeptByCollege(dgvList, frmCollegeRecords.idCOLL)
                txtDeptA.Clear()
                txtDeptF.Clear()
                dgvList.ClearSelection()
            ElseIf _flag = "" Then
                Dispose()
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        Try
            _flag = "Edit"
            _dept_obj = New CollegeClass
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcDepartmentInfo.Enabled = True
            tcList.Enabled = False
            idDept = dgvList.SelectedRows(0).Cells(0).Value.ToString
            With _dept_obj
                .Department_name = dgvList.SelectedRows(0).Cells(1).Value.ToString
                .Department_abbrev = dgvList.SelectedRows(0).Cells(2).Value.ToString
                txtDeptF.Text = .Department_name
                txtDeptA.Text = .Department_abbrev
                _DN = .Department_name
                _DA = .Department_abbrev
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            _dept_obj = New CollegeClass
            btnNew.Enabled = False
            btnSave.Enabled = False
            btnEdit.Enabled = True
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcDepartmentInfo.Enabled = False
            tcList.Enabled = True
            idDept = dgvList.SelectedRows(0).Cells(0).Value.ToString
            With _dept_obj
                .Department_name = dgvList.SelectedRows(0).Cells(1).Value.ToString
                .Department_abbrev = dgvList.SelectedRows(0).Cells(2).Value.ToString
                txtDeptF.Text = .Department_name
                txtDeptA.Text = .Department_abbrev
                _DN = .Department_name
                _DA = .Department_abbrev
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmManageDepartment_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmManageDepartment_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            _dept_obj = New CollegeClass
            _dept_obj.LoadDeptByCollege(dgvList, frmCollegeRecords.idCOLL)
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtDeptF_TextChanged(sender As Object, e As EventArgs) Handles txtDeptF.TextChanged
        Try
            keyAllow(_deptAllow, txtDeptF)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtDeptA_TextChanged(sender As Object, e As EventArgs) Handles txtDeptA.TextChanged
        Try
            keyAllow(_deptAllow, txtDeptA)
        Catch ex As Exception

        End Try
    End Sub
End Class