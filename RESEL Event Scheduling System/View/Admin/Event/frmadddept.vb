Public Class frmadddept

    Public _dept_obj As CollegeClass

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            _dept_obj = New CollegeClass
            With _dept_obj
                If RequiredField(txtDeptF.Text, txtDeptA.Text) = True Then

                    .Idcollege = frmManageEvents.idC
                    .College_name = frmManageEvents.cboCollege.Text
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
                        Dispose()
                        Close()
                        .LoadDeptByCollegeEvents(frmManageEvents.dgvDept, .Idcollege)
                    Else
                        MessageBox.Show("New department has not been saved.", "Register New Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MsgBox("All fields are required.")
                    Exit Sub
                End If
                    End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dispose()
            Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmadddept_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class