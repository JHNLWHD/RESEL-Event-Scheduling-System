Public Class frmManageVenue

    Public _venue_obj As VenueClass
    Dim _flag As String = ""
    Public Shared idVen As Integer = 0
    Dim _VenueF As String = ""
    Dim _VenueA As String = ""
    Dim _venueAllow As String = "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm1234567809)( ."
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            _flag = "New"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcVenueInfo.Enabled = True
            tcSearch.Enabled = False
            dgvList.Rows.Clear()
            dgvList.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmManageVenue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcVenueInfo.Enabled = False
            tcSearch.Enabled = True
            dgvList.Rows.Clear()
            dgvList.ClearSelection()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _venue_obj = New VenueClass
            With _venue_obj
                If RequiredField(txtVenueA.Text, txtVenueF.Text) = True Then
                    If _flag = "New" Then
                        If .isVenueFExist(txtVenueF.Text, "New") = True Then

                            If .isVenueAExist(txtVenueA.Text, "New") = True Then
                                MessageBox.Show("This venue information already exist.", "New Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                            MessageBox.Show("This venue full name already exist.", "New Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                            btnNew.Enabled = True
                            btnSave.Enabled = False
                            btnEdit.Enabled = False
                            btnShowRecords.Enabled = True
                            btnCancel.Enabled = True
                            tcVenueInfo.Enabled = False
                            tcSearch.Enabled = True
                            txtVenueF.Clear()
                            txtVenueA.Clear()
                            txtSearch.Clear()
                            dgvList.Rows.Clear()
                            dgvList.ClearSelection()
                            _flag = ""
                            Exit Sub
                        Else
                            MessageBox.Show("New venue has not been saved.", "New Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    ElseIf _flag = "Edit" Then
                        'check if duplicate
                        .Idvenue = idVen
                        .Venue_name = txtVenueF.Text
                        .Venue_abbev = txtVenueA.Text


                        If String.Compare(txtVenueF.Text, _VenueF, True) = 0 And String.Compare(txtVenueA.Text, _VenueA, True) = 0 Then
                            MessageBox.Show("Inputted values are just the same.")
                            Exit Sub
                        Else
                            If .isVenueFExist(txtVenueF.Text, "Edit", .Idvenue) = True Then
                                If .isVenueAExist(txtVenueA.Text, "Edit", .Idvenue) = True Then
                                    MessageBox.Show("This venue information already exist.", "Update Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                                MessageBox.Show("This venue full name already exist.", "New Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                            If .isVenueAExist(txtVenueA.Text, "Edit", .Idvenue) = True Then
                                MessageBox.Show("This venue abbreviation already exist.", "Update Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            If .UpdateVenue = True Then
                                MessageBox.Show("Venue information has been updated", "Update Venue", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                btnNew.Enabled = True
                                btnSave.Enabled = False
                                btnEdit.Enabled = False
                                btnShowRecords.Enabled = True
                                btnCancel.Enabled = True
                                tcSearch.Enabled = True
                                tcVenueInfo.Enabled = False
                                txtVenueF.Clear()
                                txtVenueA.Clear()
                                txtSearch.Clear()
                                dgvList.Rows.Clear()
                                dgvList.ClearSelection()
                                _flag = ""
                                Exit Sub
                            Else
                                MessageBox.Show("Venue information has not been updated", "Update Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If


                        End If
                    Else
                        Exit Sub
                    End If



                    Else
                    MessageBox.Show("All are required fields", "Update Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmVenueRecords.ShowDialog()
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
                    tcVenueInfo.Enabled = False
                    tcSearch.Enabled = True
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
                    tcVenueInfo.Enabled = False
                    tcSearch.Enabled = True
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

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            _venue_obj = New VenueClass
            With _venue_obj
                .LoadVenueToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                idVen = dgvList.SelectedRows(0).Cells(0).Value.ToString
                .Venue_name = .Venue_name
                .Venue_abbev = .Venue_abbev
                txtVenueF.Text = .Venue_name
                txtVenueA.Text = .Venue_abbev
                _VenueA = .Venue_name
                _VenueF = .Venue_abbev
            End With
            btnEdit.Enabled = True
            btnNew.Enabled = False
            btnSave.Enabled = False
            tcVenueInfo.Enabled = False
            tcSearch.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        Try
            _venue_obj = New VenueClass
            With _venue_obj
                .LoadVenueToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                idVen = dgvList.SelectedRows(0).Cells(0).Value.ToString
                .Venue_name = dgvList.SelectedRows(0).Cells(1).Value.ToString
                .Venue_abbev = dgvList.SelectedRows(0).Cells(2).Value.ToString
                txtVenueF.Text = .Venue_name
                txtVenueA.Text = .Venue_abbev
                _VenueA = txtVenueA.Text
                _VenueF = txtVenueF.Text
            End With
            _flag = "Edit"
            btnEdit.Enabled = False
            btnNew.Enabled = False
            btnSave.Enabled = True
            tcSearch.Enabled = False
            tcVenueInfo.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _venue_obj = New VenueClass
            With _venue_obj
                .SearchVenueRecords(dgvList, txtSearch.Text, 0)
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
            tcVenueInfo.Enabled = True
            tcSearch.Enabled = False

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmManageVenue_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtVenueF_TextChanged(sender As Object, e As EventArgs) Handles txtVenueF.TextChanged
        Try
            keyAllow(_venueAllow, txtVenueF)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtVenueA_TextChanged(sender As Object, e As EventArgs) Handles txtVenueA.TextChanged
        Try
            keyAllow(_venueAllow, txtVenueA)
        Catch ex As Exception

        End Try
    End Sub
End Class