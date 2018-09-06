Public Class frmsavevenue

    Public _venue_obj As VenueClass

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            _venue_obj = New VenueClass
            With _venue_obj
                If RequiredField(txtVenueA.Text, txtVenueF.Text) = True Then

                    If .isVenueFExist(txtVenueF.Text, "New") = True Then

                        If .isVenueAExist(txtVenueA.Text, "New") = True Then
                            MessageBox.Show("This venue information already exist.", "New Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                        Exit Sub
                    End If
                    If .isVenueAExist(txtVenueA.Text, "New") = True Then
                        MessageBox.Show("This venue abbreviation already exist.", "New Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                    .Venue_name = txtVenueF.Text
                    .Venue_abbev = txtVenueA.Text
                    If .AddVenue = True Then
                        MessageBox.Show("New venue has been saved.", "New Venue", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dispose()
                        Close()
                        LoadVenueToCbo(frmManageEvents.cboVenue)
                        Exit Sub
                    Else
                        MessageBox.Show("New venue has not been saved.", "New Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("All are required fields", "Update Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dispose()
            Close()
        Catch ex As Exception

        End Try
    End Sub
End Class