Public Class frmHolidayRecords

    Public _holiday_obj As EventClass

    Private Sub frmHolidayRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _holiday_obj = New EventClass
            With _holiday_obj
                cboSort.SelectedIndex = 0
                cboFilter.SelectedIndex = 0
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSort.SelectedIndexChanged
        Try
            _holiday_obj = New EventClass
            With _holiday_obj
                If cboSort.SelectedIndex = 0 Then
                    If cboFilter.SelectedIndex = 0 Then
                        .LoadHolidayRecords(dgvHoliday, "ALL", 0, "ALL")
                    ElseIf cboFilter.SelectedIndex = 1 Then
                        .LoadHolidayRecords(dgvHoliday, "ALL", 0, "Active")
                    ElseIf cboFilter.SelectedIndex = 2 Then
                        .LoadHolidayRecords(dgvHoliday, "ALL", 0, "Inactive")
                    End If
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count

                ElseIf cboSort.SelectedIndex = 1 Then
                    If cboFilter.SelectedIndex = 0 Then
                        .LoadHolidayRecords(dgvHoliday, "INTERNATIONAL", 0, "ALL")
                    ElseIf cboFilter.SelectedIndex = 1 Then
                        .LoadHolidayRecords(dgvHoliday, "INTERNATIONAL", 0, "Active")
                    ElseIf cboFilter.SelectedIndex = 2 Then
                        .LoadHolidayRecords(dgvHoliday, "INTERNATIONAL", 0, "Inactive")
                    End If

                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count

                ElseIf cboSort.SelectedIndex = 2 Then
                    If cboFilter.SelectedIndex = 0 Then
                        .LoadHolidayRecords(dgvHoliday, "NATIONAL", 0, "ALL")
                    ElseIf cboFilter.SelectedIndex = 1 Then
                        .LoadHolidayRecords(dgvHoliday, "NATIONAL", 0, "Active")
                    ElseIf cboFilter.SelectedIndex = 2 Then
                        .LoadHolidayRecords(dgvHoliday, "NATIONAL", 0, "Inactive")
                    End If

                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count


                ElseIf cboSort.SelectedIndex = 3 Then
                    If cboFilter.SelectedIndex = 0 Then
                        .LoadHolidayRecords(dgvHoliday, "REGIONAL", 0, "ALL")
                    ElseIf cboFilter.SelectedIndex = 1 Then
                        .LoadHolidayRecords(dgvHoliday, "REGIONAL", 0, "Active")
                    ElseIf cboFilter.SelectedIndex = 2 Then
                        .LoadHolidayRecords(dgvHoliday, "REGIONAL", 0, "Inactive")
                    End If

                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count

                ElseIf cboSort.SelectedIndex = 4 Then
                    If cboFilter.SelectedIndex = 0 Then
                        .LoadHolidayRecords(dgvHoliday, "LOCAL", 0, "ALL")
                    ElseIf cboFilter.SelectedIndex = 1 Then
                        .LoadHolidayRecords(dgvHoliday, "LOCAL", 0, "Active")
                    ElseIf cboFilter.SelectedIndex = 2 Then
                        .LoadHolidayRecords(dgvHoliday, "LOCAL", 0, "Inactive")
                    End If
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _holiday_obj = New EventClass
            With _holiday_obj
                If cboSort.SelectedIndex = 0 Then
                    If txtSearch.Text.Length >= 2 Then
                        If cboFilter.SelectedIndex = 0 Then
                            .SearchHolidayRecords(dgvHoliday, "ALL", 0, txtSearch.Text, "ALL")
                        ElseIf cboFilter.SelectedIndex = 1 Then
                            .SearchHolidayRecords(dgvHoliday, "ALL", 0, txtSearch.Text, "Active")
                        ElseIf cboFilter.SelectedIndex = 2 Then
                            .SearchHolidayRecords(dgvHoliday, "ALL", 0, txtSearch.Text, "Inactive")
                        End If
                    ElseIf txtSearch.Text = vbNullString Then
                        cboSort_SelectedIndexChanged(sender, e)
                    End If
                ElseIf cboSort.SelectedIndex = 1 Then
                    If txtSearch.Text.Length >= 2 Then
                        If cboFilter.SelectedIndex = 0 Then
                            .SearchHolidayRecords(dgvHoliday, "INTERNATIONAL", 0, txtSearch.Text, "ALL")
                        ElseIf cboFilter.SelectedIndex = 1 Then
                            .SearchHolidayRecords(dgvHoliday, "INTERNATIONAL", 0, txtSearch.Text, "Active")
                        ElseIf cboFilter.SelectedIndex = 2 Then
                            .SearchHolidayRecords(dgvHoliday, "INTERNATIONAL", 0, txtSearch.Text, "Inactive")
                        End If
                    ElseIf txtSearch.Text = vbNullString Then
                        cboSort_SelectedIndexChanged(sender, e)
                    End If
                ElseIf cboSort.SelectedIndex = 2 Then
                    If txtSearch.Text.Length >= 2 Then
                        If cboFilter.SelectedIndex = 0 Then
                            .SearchHolidayRecords(dgvHoliday, "NATIONAL", 0, txtSearch.Text, "ALL")
                        ElseIf cboFilter.SelectedIndex = 1 Then
                            .SearchHolidayRecords(dgvHoliday, "NATIONAL", 0, txtSearch.Text, "Active")
                        ElseIf cboFilter.SelectedIndex = 2 Then
                            .SearchHolidayRecords(dgvHoliday, "NATIONAL", 0, txtSearch.Text, "Inactive")
                        End If
                    ElseIf txtSearch.Text = vbNullString Then
                        cboSort_SelectedIndexChanged(sender, e)
                    End If
                ElseIf cboSort.SelectedIndex = 3 Then
                    If txtSearch.Text.Length >= 2 Then
                        If cboFilter.SelectedIndex = 0 Then
                            .SearchHolidayRecords(dgvHoliday, "REGIONAL", 0, txtSearch.Text, "ALL")
                        ElseIf cboFilter.SelectedIndex = 1 Then
                            .SearchHolidayRecords(dgvHoliday, "REGIONAL", 0, txtSearch.Text, "Active")
                        ElseIf cboFilter.SelectedIndex = 2 Then
                            .SearchHolidayRecords(dgvHoliday, "REGIONAL", 0, txtSearch.Text, "Inactive")
                        End If
                    ElseIf txtSearch.Text = vbNullString Then
                        cboSort_SelectedIndexChanged(sender, e)
                    End If
                ElseIf cboSort.SelectedIndex = 4 Then
                    If txtSearch.Text.Length >= 2 Then
                        If cboFilter.SelectedIndex = 0 Then
                            .SearchHolidayRecords(dgvHoliday, "LOCAL", 0, txtSearch.Text, "ALL")
                        ElseIf cboFilter.SelectedIndex = 1 Then
                            .SearchHolidayRecords(dgvHoliday, "LOCAL", 0, txtSearch.Text, "Active")
                        ElseIf cboFilter.SelectedIndex = 2 Then
                            .SearchHolidayRecords(dgvHoliday, "LOCAL", 0, txtSearch.Text, "Inactive")
                        End If
                    ElseIf txtSearch.Text = vbNullString Then
                        cboSort_SelectedIndexChanged(sender, e)
                    End If
                End If
                .HolidayRecordCount("INTERNATIONAL")
                lblInternational.Text = .Holiday_count

                .HolidayRecordCount("NATIONAL")
                lblNational.Text = .Holiday_count

                .HolidayRecordCount("REGIONAL", "LOCAL")
                lblRegLoc.Text = .Holiday_count
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAY_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvHoliday.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvHoliday.Rows(e.RowIndex).Selected = True
                dgvHoliday.CurrentCell = dgvHoliday.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvHoliday.SelectedRows.Count = 1 Then
                    If dgvHoliday.SelectedRows(0).Cells(4).Value.ToString = "Active" Then
                        cmDeact.Show(dgvHoliday, e.Location)
                        cmDeact.Show(Cursor.Position)
                    ElseIf dgvHoliday.SelectedRows(0).Cells(4).Value.ToString = "Inactive" Then
                        cmAct.Show(dgvHoliday, e.Location)
                        cmAct.Show(Cursor.Position)
                    Else
                        Exit Sub
                    End If

                Else
                    Exit Sub
                End If
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem1.Click
        Try
            'act
            _holiday_obj = New EventClass
            With _holiday_obj
                Dim ans As MsgBoxResult
                ans = MessageBox.Show("Are you sure you want to remove this holiday?" + vbCrLf + "This will result to deactivating the holiday also.", "Remove Unit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ans = MsgBoxResult.Yes Then
                    .Idholiday = dgvHoliday.SelectedRows(0).Cells(0).Value.ToString
                    .Holiday_remove_status = "TRUE"
                    If .RemoveHoliday = True Then
                        MessageBox.Show("Holiday has been removed", "Remove Holiday", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        .HolidayRecordCount("INTERNATIONAL")
                        lblInternational.Text = .Holiday_count

                        .HolidayRecordCount("NATIONAL")
                        lblNational.Text = .Holiday_count

                        .HolidayRecordCount("REGIONAL", "LOCAL")
                        lblRegLoc.Text = .Holiday_count
                        Exit Sub
                    Else
                        MessageBox.Show("Holiday has not been removed", "Removed Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .HolidayRecordCount("INTERNATIONAL")
                        lblInternational.Text = .Holiday_count

                        .HolidayRecordCount("NATIONAL")
                        lblNational.Text = .Holiday_count

                        .HolidayRecordCount("REGIONAL", "LOCAL")
                        lblRegLoc.Text = .Holiday_count
                        Exit Sub
                    End If
                Else
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count
                    Exit Sub
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            _holiday_obj = New EventClass
            With _holiday_obj
                .Idholiday = dgvHoliday.SelectedRows(0).Cells(0).Value.ToString
                If .ActivateHoliday = True Then
                    MessageBox.Show("Holiday has been activated", "Activate Holiday", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count
                    Exit Sub
                Else
                    MessageBox.Show("Holiday has not been activated", "Activate Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count
                    Exit Sub
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            'deact
            _holiday_obj = New EventClass
            With _holiday_obj
                .Idholiday = dgvHoliday.SelectedRows(0).Cells(0).Value.ToString
                .Holiday_remove_status = "TRUE"
                If .RemoveHoliday = True Then
                    MessageBox.Show("Holiday has been removed", "Remove Holiday", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count
                    Exit Sub
                Else
                    MessageBox.Show("Holiday has not been removed", "Removed Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count
                    Exit Sub
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeactivateToolStripMenuItem.Click
        Try
            _holiday_obj = New EventClass
            With _holiday_obj
                .Idholiday = dgvHoliday.SelectedRows(0).Cells(0).Value.ToString
                If .DeactivateHoliday = True Then
                    MessageBox.Show("Holiday has been deactivated", "Deactivate Holiday", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count
                    Exit Sub
                Else
                    MessageBox.Show("Holiday has not been deactivated", "Deactivate Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .HolidayRecordCount("INTERNATIONAL")
                    lblInternational.Text = .Holiday_count

                    .HolidayRecordCount("NATIONAL")
                    lblNational.Text = .Holiday_count

                    .HolidayRecordCount("REGIONAL", "LOCAL")
                    lblRegLoc.Text = .Holiday_count
                    Exit Sub
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblRefresh.LinkClicked
        Try
            cboSort_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnklblPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Try
            'code here for print crystal report
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmHolidayRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub cboFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFilter.SelectedIndexChanged
        Try
            cboSort_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnklblPrint_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
        Try
            'code here for print crystal
            Dim dt As New DataTable
            Dim rpt As New listHolidays
            Dim frm As New reports

            With dt.Columns
                .Add("holiday_name")
                .Add("holiday_type")
                .Add("holiday_date")
                .Add("holiday_status")
            End With

            For i As Integer = 0 To dgvHoliday.Rows.Count - 1
                'get from datagridview
                dt.Rows.Add(dgvHoliday.Rows(i).Cells(1).Value.ToString,
                            dgvHoliday.Rows(i).Cells(2).Value.ToString,
                            dgvHoliday.Rows(i).Cells(3).Value.ToString,
                            dgvHoliday.Rows(i).Cells(4).Value.ToString)
            Next

            rpt.SetDataSource(dt)
            rpt.SetParameterValue("acad_year", frmHome.lblAY.Text)

            With frm
                .CrystalReportViewer1.ReportSource = rpt
                .CrystalReportViewer1.Refresh()
                .ShowDialog()
            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class