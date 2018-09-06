Public Class frmVenueRecords

    Public _venue_obj As VenueClass

    Private Sub frmVenueRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _venue_obj = New VenueClass
            With _venue_obj
                .LoadVenueRecords(dgvVenue, 0)
                .VenueRecordCount()
                lblTotalVenue.Text = .Venue_count
                'load statistics
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            'here
            _venue_obj = New VenueClass
            With _venue_obj
                If txtSearch.Text.Length >= 2 Then
                    .SearchVenueRecords(dgvVenue, txtSearch.Text, 0)
                ElseIf txtSearch.Text.Length = vbNullString Then
                    .LoadVenueRecords(dgvVenue, 0)
                End If
                .VenueRecordCount()
                lblTotalVenue.Text = .Venue_count
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmVenueRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            _venue_obj = New VenueClass
            With _venue_obj
                .Idvenue = dgvVenue.SelectedRows(0).Cells(0).Value.ToString
                .Venue_name = dgvVenue.SelectedRows(0).Cells(1).Value.ToString
                .Venue_remove_status = "TRUE"
                If .RemoveVenue = True Then
                    MessageBox.Show("Venue has been removed.", "Remove Venue", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmVenueRecords_Load(sender, e)
                    Exit Sub
                Else
                    MessageBox.Show("Venue has not been removed.", "Remove Venue", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    frmVenueRecords_Load(sender, e)
                    Exit Sub
                End If
            End With

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvVenue_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvVenue.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvVenue.Rows(e.RowIndex).Selected = True
                dgvVenue.CurrentCell = dgvVenue.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvVenue.SelectedRows.Count = 1 Then
                    cmRemove.Show(dgvVenue, e.Location)
                    cmRemove.Show(Cursor.Position)
                Else
                    Exit Sub
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub lnklblPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
        Try
            Dim dt As New DataTable
            Dim rpt As New venue
            Dim frm As New reports

            With dt
                .Columns.Add("venue_name")
                .Columns.Add("venue_abbrev")
            End With

            For i As Integer = 0 To dgvVenue.RowCount - 1
                dt.Rows.Add(dgvVenue.Rows(i).Cells(1).Value.ToString,
                            dgvVenue.Rows(i).Cells(2).Value.ToString)
            Next



            rpt.SetDataSource(dt)
            rpt.SetParameterValue("acad_year", frmHome.lblAY.Text)

            With frm
                .CrystalReportViewer1.ReportSource = rpt
                .CrystalReportViewer1.Refresh()
                .ShowDialog()
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblRefresh.LinkClicked
        Try
            txtSearch.Clear()
            frmVenueRecords_Load(sender, e)
        Catch ex As Exception

        End Try
    End Sub
End Class