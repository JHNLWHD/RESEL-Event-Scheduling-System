Public Class frmPartnerAgencyRecords
    Public _partner_obj As EventClass

    Private Sub frmPartnerAgencyRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _partner_obj = New EventClass
        With _partner_obj
            .LoadPartnerAgencyRecords(dgvPA, 0)
            .PartnerAgencyRecordCount()
            lblTotalPA.Text = .Partner_agency_count
        End With
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _partner_obj = New EventClass
            With _partner_obj
                If txtSearch.Text.Length >= 2 Then
                    .SearchPartnerAgencyRecords(dgvPA, 0, txtSearch.Text)
                ElseIf txtSearch.Text = vbNullString Then
                    .LoadPartnerAgencyRecords(dgvPA, 0)
                    .PartnerAgencyRecordCount()
                    lblTotalPA.Text = .Partner_agency_count
                Else
                    .PartnerAgencyRecordCount()
                    lblTotalPA.Text = .Partner_agency_count
                    Exit Sub
                End If
                .PartnerAgencyRecordCount()
                lblTotalPA.Text = .Partner_agency_count
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCollege_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPA.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvPA.Rows(e.RowIndex).Selected = True
                dgvPA.CurrentCell = dgvPA.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvPA.SelectedRows.Count = 1 Then
                    cmManage.Show(dgvPA, e.Location)
                    cmManage.Show(Cursor.Position)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            _partner_obj = New EventClass
            With _partner_obj
                .Idpartner_agency = dgvPA.SelectedRows(0).Cells(0).Value.ToString
                .Partner_agency_remove_status = "TRUE"
                If .RemovePartnerAgency = True Then
                    MessageBox.Show("Partner Agency has been removed", "Remove Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    .LoadPartnerAgencyRecords(dgvPA, 0)
                    .PartnerAgencyRecordCount()
                    lblTotalPA.Text = .Partner_agency_count
                    Exit Sub
                Else
                    MessageBox.Show("Partner Agency has not been removed", "Remove Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .LoadPartnerAgencyRecords(dgvPA, 0)
                    .PartnerAgencyRecordCount()
                    lblTotalPA.Text = .Partner_agency_count
                    Exit Sub
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmPartnerAgencyRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnklblPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
        Try
            Dim dt As New DataTable
            Dim rpt As New partnerAgency
            Dim frm As New reports

            With dt
                .Columns.Add("partner_agency_name")
                .Columns.Add("partner_agency_reg_date")
            End With

            For i As Integer = 0 To dgvPA.RowCount - 1
                dt.Rows.Add(dgvPA.Rows(i).Cells(1).Value.ToString,
                            dgvPA.Rows(i).Cells(3).Value.ToString)
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
End Class