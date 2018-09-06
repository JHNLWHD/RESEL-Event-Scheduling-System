Public Class frmpartneragencies

    Public _partner_agency_obj As EventClass

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            _partner_agency_obj = New EventClass
            With _partner_agency_obj
                If RequiredField(txtName.Text) = True Then
                    .Partner_agency_name = txtName.Text
                    .Partner_agency_remove_status = "FALSE"
                    'If .isPartnerAgencyExist(txtName.Text, "New") = True Then
                    '    MessageBox.Show("Partner Agency already exist.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    Exit Sub
                    'End If

                    If .AddPartnerAgency = True Then
                        MessageBox.Show("Partner Agency has been saved.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dispose()
                        Close()
                        .LoadPartnerAgencyCheck(frmManageEvents.dgvPA, 0)
                    Else
                        MessageBox.Show("Partner Agency has not been saved.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else


                    MessageBox.Show("All fields required", "Field requirement", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub frmpartneragencies_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class