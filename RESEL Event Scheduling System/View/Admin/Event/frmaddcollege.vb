Public Class frmaddcollege
    Public _college_obj As CollegeClass

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            _college_obj = New CollegeClass
            If RequiredField(txtCollegeA.Text, txtCollegeF.Text) = True Then
                With _college_obj
                    .College_name = txtCollegeF.Text
                    .College_abbrev = txtCollegeA.Text
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
                    If .AddCollege() = True Then
                        MessageBox.Show("New College has been saved.", "Register New College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dispose()
                        Close()
                        LoadCollegeToCbo(frmManageEvents.cboCollege)
                    Else
                        MessageBox.Show("Error.", "Register New College", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                End With
            Else
                MessageBox.Show("All fields required.", "Register New College", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            txtCollegeA.Clear()
            txtCollegeF.Clear()
            Dispose()
            Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmaddcollege_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class