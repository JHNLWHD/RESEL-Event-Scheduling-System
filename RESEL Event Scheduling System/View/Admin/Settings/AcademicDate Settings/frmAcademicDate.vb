Public Class frmAcademicDate

    Public _acad_year_obj As AcademicYearClass
    Dim _year As String = "0987654321- "

    Private Sub frmAcademicDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _acad_year_obj = New AcademicYearClass
            cboSort.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cboSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSort.SelectedIndexChanged
        Try
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                If cboSort.SelectedIndex = 0 Then
                    If txtSearch.Text.Length >= 2 Then
                        txtSearch_TextChanged(sender, e)
                    Else
                        _acad_year_obj.LoadAYDateSettingsRecords(dgvAY, "All", 0)
                    End If
                    .AYDateSettingsRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYDateSettingsRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYDateSettingsRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                ElseIf cboSort.SelectedIndex = 1 Then
                    If txtSearch.Text.Length >= 2 Then
                        txtSearch_TextChanged(sender, e)
                    Else
                        _acad_year_obj.LoadAYDateSettingsRecords(dgvAY, "Active", 0)
                    End If

                    .AYDateSettingsRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYDateSettingsRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYDateSettingsRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                ElseIf cboSort.SelectedIndex = 2 Then
                    If txtSearch.Text.Length >= 2 Then
                        txtSearch_TextChanged(sender, e)
                    Else
                        _acad_year_obj.LoadAYDateSettingsRecords(dgvAY, "Inactive", 0)
                    End If

                    .AYDateSettingsRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYDateSettingsRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYDateSettingsRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                Else
                    Exit Sub
                End If
            End With

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvAY_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAY.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvAY.Rows(e.RowIndex).Selected = True
                dgvAY.CurrentCell = dgvAY.Rows(e.RowIndex).Cells(e.ColumnIndex)
                If dgvAY.SelectedRows.Count = 1 Then

                    If dgvAY.SelectedRows(0).Cells(3).Value.ToString = "Inactive" Then
                        cmOpen.Show(dgvAY, e.Location)
                        cmOpen.Show(Cursor.Position)
                    Else
                        dgvAY.ClearSelection()
                        Exit Sub
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub dgvAY_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvAY.RowPrePaint
        Try
            If dgvAY.Rows(e.RowIndex).Cells(3).Value.ToString = "Active" Then
                dgvAY.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.ForestGreen
                dgvAY.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
            Else
                dgvAY.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            _acad_year_obj = New AcademicYearClass
            Dim ans As MsgBoxResult

            ans = MessageBox.Show("This date setttings will take effect on the next calendar year.", "Activate Calendar Date", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If ans = MsgBoxResult.Yes Then
                With _acad_year_obj
                    .Status = "Inactive"
                    If .CloseAYDate = True Then
                        .Status = "Active"
                        .Iddate_settings = dgvAY.SelectedRows(0).Cells(0).Value.ToString
                        .Date_settings_start_word = dgvAY.SelectedRows(0).Cells(1).Value.ToString
                        .Date_settings_end_word = dgvAY.SelectedRows(0).Cells(2).Value.ToString
                        If .ActivateAYDate = True Then
                            MessageBox.Show("This date setttings is activated.", "Activate Calendar Date", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cboSort_SelectedIndexChanged(sender, e)
                        Else
                            MessageBox.Show("This date setttings failed to activate.", "Activate Calendar Date", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                End With
            Else
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                If txtSearch.Text = vbNullString Then
                    cboSort_SelectedIndexChanged(sender, e)
                ElseIf txtSearch.Text.Length >= 2 Then
                    Dim arrMonth As String() = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"}
                    Dim result As String() = Array.FindAll(arrMonth, Function(s) s.StartsWith(txtSearch.Text, True, Globalization.CultureInfo.InvariantCulture))
                    Dim x As Integer = Array.FindIndex(arrMonth, Function(s) s.Contains(txtSearch.Text))
                    Dim intMon As Integer = Array.IndexOf(arrMonth, result.ToString) + 1
                    'MsgBox(x + 1)
                    .SearchAYDateSettingsRecords(dgvAY, cboSort.Text, 0, x + 1)

                    .AYDateSettingsRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYDateSettingsRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYDateSettingsRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblRefresh.LinkClicked
        Try
            txtSearch.Clear()
            cboSort_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub lnklblPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
        Try
            Dim dt As New DataTable
            Dim rpt As New rptAcademicDate
            Dim frm As New reports

            With dt
                .Columns.Add("date_settings_start")
                .Columns.Add("date_settings_end")
                .Columns.Add("status")
            End With


            For i As Integer = 0 To dgvAY.RowCount - 1
                dt.Rows.Add(dgvAY.Rows(i).Cells(1).Value.ToString,
                            dgvAY.Rows(i).Cells(2).Value.ToString,
                            dgvAY.Rows(i).Cells(3).Value.ToString)
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