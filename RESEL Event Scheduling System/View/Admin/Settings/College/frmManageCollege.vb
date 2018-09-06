Public Class frmManageCollege

    Public _college_obj As CollegeClass
    Dim _flag As String = ""
    Dim _CN As String = ""
    Dim _CA As String = ""
    Public Shared idC As Integer = 0
    Dim _collegeAllow As String = "QWERTYUIOPLKJHGFDSAZCVBNM -qwertyuioplkjhgfdsazcvbnm"
    Private Sub frmManageCollege_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcCollegeInfo.Enabled = False
            tcSearch.Enabled = True
            txtCollegeA.Clear()
            txtCollegeF.Clear()
            txtSearch.Clear()
            dgvList.Rows.Clear()
            dgvList.ClearSelection()
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
            tcCollegeInfo.Enabled = True
            tcSearch.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _college_obj = New CollegeClass
            If RequiredField(txtCollegeA.Text, txtCollegeF.Text) = True Then
                With _college_obj

                    If _flag = "New" Then
                        If .isCollegeFExist(txtCollegeF.Text, "New") = True Then
                            MessageBox.Show("College name already exist.", "Register New College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            If .isCollegeAExist(txtCollegeA.Text, "New") = True Then
                                MessageBox.Show("College abbreviation already exist.", "Register New College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                            Exit Sub
                        End If
                        If .isCollegeAExist(txtCollegeA.Text, "New") = True Then
                            MessageBox.Show("College abbreviation already exist.", "Register New College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                        .College_name = txtCollegeF.Text
                        .College_abbrev = txtCollegeA.Text
                        If .AddCollege() = True Then
                            MessageBox.Show("New College has been saved.", "Register New College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            btnNew.Enabled = True
                            btnSave.Enabled = False
                            btnEdit.Enabled = False
                            btnShowRecords.Enabled = True
                            btnCancel.Enabled = True
                            tcCollegeInfo.Enabled = False
                            tcSearch.Enabled = True
                            txtCollegeA.Clear()
                            txtCollegeF.Clear()
                            txtSearch.Clear()
                            dgvList.Rows.Clear()
                            dgvList.ClearSelection()
                        Else
                            MessageBox.Show("Error.", "Register New College", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    ElseIf _flag = "Edit" Then
                        .Idcollege = idC


                        If String.Compare(txtCollegeF.Text, _CN, True) = 0 And String.Compare(txtCollegeA.Text, _CA, True) = 0 Then
                            MessageBox.Show("The college you enter is just the same", "Update College", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        Else
                            If .isCollegeFExist(txtCollegeF.Text, "Edit", .Idcollege) = True Then
                                MessageBox.Show("College name already exist.", "Update College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                If .isCollegeAExist(txtCollegeA.Text, "Edit", .Idcollege) = True Then
                                    MessageBox.Show("College abbreviation already exist.", "Update College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                                Exit Sub
                            End If
                            If .isCollegeAExist(txtCollegeA.Text, "Edit", .Idcollege) = True Then
                                MessageBox.Show("College abbreviation already exist.", "Update College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            End If
                            .College_name = txtCollegeF.Text
                            .College_abbrev = txtCollegeA.Text
                            If .UpdateCollege() = True Then
                                MessageBox.Show("New College has been updated.", "Update College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                btnNew.Enabled = True
                                btnSave.Enabled = False
                                btnEdit.Enabled = False
                                btnShowRecords.Enabled = True
                                btnCancel.Enabled = True
                                tcCollegeInfo.Enabled = False
                                tcSearch.Enabled = True
                                txtCollegeA.Clear()
                                txtCollegeF.Clear()
                                txtSearch.Clear()
                                dgvList.Rows.Clear()
                                dgvList.ClearSelection()
                            Else
                                MessageBox.Show("Error.", "Update College", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Exit Sub
                            End If
                        End If
                    Else
                        Exit Sub
                    End If

                End With
            Else
                MessageBox.Show("All fields are required", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _college_obj = New CollegeClass
            With _college_obj
                .SearchCollegeRecords(dgvList, txtSearch.Text, 1)
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            _flag = "Edit"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcCollegeInfo.Enabled = True
            tcSearch.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        Try
            _college_obj = New CollegeClass
            With _college_obj
                .LoadCollegeToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                .Idcollege = dgvList.SelectedRows(0).Cells(0).Value.ToString
                .College_name = dgvList.SelectedRows(0).Cells(1).Value.ToString
                .College_abbrev = dgvList.SelectedRows(0).Cells(2).Value.ToString
                txtCollegeF.Text = .College_name
                txtCollegeA.Text = .College_abbrev
                _CN = .College_name
                _CA = .College_abbrev
                idC = .Idcollege
            End With
            _flag = "Edit"
            btnEdit.Enabled = False
            btnNew.Enabled = False
            btnSave.Enabled = True
            tcCollegeInfo.Enabled = True
            tcSearch.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            _college_obj = New CollegeClass
            With _college_obj
                .LoadCollegeToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                .Idcollege = dgvList.SelectedRows(0).Cells(0).Value.ToString
                .College_name = dgvList.SelectedRows(0).Cells(1).Value.ToString
                .College_abbrev = dgvList.SelectedRows(0).Cells(2).Value.ToString
                txtCollegeF.Text = .College_name
                txtCollegeA.Text = .College_abbrev
                _CN = .College_name
                _CA = .College_abbrev
                idC = .Idcollege
            End With
            btnEdit.Enabled = True
            btnNew.Enabled = False
            btnSave.Enabled = False
            tcCollegeInfo.Enabled = False
            tcSearch.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmCollegeRecords.ShowDialog()
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
                    tcCollegeInfo.Enabled = False
                    tcSearch.Enabled = True
                    txtCollegeA.Clear()
                    txtCollegeF.Clear()
                    txtSearch.Clear()
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
                    tcCollegeInfo.Enabled = False
                    tcSearch.Enabled = True
                    txtCollegeA.Clear()
                    txtCollegeF.Clear()
                    txtSearch.Clear()
                    dgvList.Rows.Clear()
                    dgvList.ClearSelection()
                Catch ex As Exception

                End Try
            ElseIf _flag = "" Then
                Dispose()
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmManageCollege_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtCollegeF_TextChanged(sender As Object, e As EventArgs) Handles txtCollegeF.TextChanged
        Try
            keyAllow(_collegeAllow, txtCollegeF)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCollegeA_TextChanged(sender As Object, e As EventArgs) Handles txtCollegeA.TextChanged
        Try
            keyAllow(_collegeAllow, txtCollegeA)
        Catch ex As Exception

        End Try
    End Sub
End Class