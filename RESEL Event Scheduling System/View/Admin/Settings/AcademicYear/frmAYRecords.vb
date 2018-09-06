Public Class frmAYRecords

    Public _acad_year_obj As AcademicYearClass
    Dim _year As String = "0987654321- "

    Private Sub frmAYRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _acad_year_obj = New AcademicYearClass
            cboSort.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            ' keyAllow(_year, txtSearch)
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                If txtSearch.Text.Length >= 2 Then
                    If cboSort.SelectedIndex = 0 Then
                        .SearchAYRecords(dgvAY, "All", txtSearch.Text, 0, "Load")
                    ElseIf cboSort.SelectedIndex = 1 Then
                        .SearchAYRecords(dgvAY, "Active", txtSearch.Text, 0, "Load")
                    ElseIf cboSort.SelectedIndex = 2 Then
                        .SearchAYRecords(dgvAY, "Inactive", txtSearch.Text, 0, "Load")
                    Else
                        Exit Sub
                    End If

                ElseIf txtSearch.Text = vbNullString Then
                    If cboSort.SelectedIndex = 0 Then
                        _acad_year_obj.LoadAYRecords(dgvAY, "ALL", 0)
                    ElseIf cboSort.SelectedIndex = 1 Then
                        _acad_year_obj.LoadAYRecords(dgvAY, "Active", 0)
                    ElseIf cboSort.SelectedIndex = 2 Then
                        _acad_year_obj.LoadAYRecords(dgvAY, "Inactive", 0)
                    Else
                        Exit Sub
                    End If
                Else

                    Exit Sub
                End If
                .AYRecordCount("ALL")
                lblAYTotal.Text = .Acad_count
                .Acad_count = 0
                .AYRecordCount("Active")
                lblAYTotalActive.Text = .Acad_count
                .Acad_count = 0
                .AYRecordCount("Inactive")
                lblAYTotalClose.Text = .Acad_count
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

                    If dgvAY.SelectedRows(0).Cells(4).Value.ToString = "Inactive" Then
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

    Private Sub RemoveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem1.Click
        Try
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                If .isActive(dgvAY.SelectedRows(0).Cells(1).Value.ToString) = True Then
                    MessageBox.Show("This academic year is the current academic year. Removing this is prohibited.", "Remove Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    .AYRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                    Exit Sub
                Else
                    .Academic_year_remove_status = "TRUE"
                    .Idacademic_year = dgvAY.SelectedRows(0).Cells(0).Value.ToString
                    .Academic_year = dgvAY.SelectedRows(0).Cells(1).Value.ToString
                    If .RemoveAY() = True Then
                        MessageBox.Show("Academic Year has been removed", "Remove Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        .LoadAYRecords(dgvAY, "ALL", 0)
                        .AYRecordCount("ALL")
                        lblAYTotal.Text = .Acad_count
                        .Acad_count = 0
                        .AYRecordCount("Active")
                        lblAYTotalActive.Text = .Acad_count
                        .Acad_count = 0
                        .AYRecordCount("Inactive")
                        lblAYTotalClose.Text = .Acad_count
                    Else
                        MessageBox.Show("Academic Year has not been removed", "Remove Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .AYRecordCount("ALL")
                        lblAYTotal.Text = .Acad_count
                        .Acad_count = 0
                        .AYRecordCount("Active")
                        lblAYTotalActive.Text = .Acad_count
                        .Acad_count = 0
                        .AYRecordCount("Inactive")
                        lblAYTotalClose.Text = .Acad_count
                    End If

                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                .Idacademic_year = dgvAY.SelectedRows(0).Cells(0).Value.ToString
                .Academic_year_status = dgvAY.SelectedRows(0).Cells(2).Value.ToString
                .Academic_year = dgvAY.SelectedRows(0).Cells(1).Value.ToString
                .ActiveAYRecord(.Idacademic_year)
                If Convert.ToDateTime(getDate()).ToString("yyyy") = .Academic_year_end And Convert.ToDateTime(getDate()).ToString("MM") = .Date_settings_end Then
                    .Academic_year_status = "Inactive"
                    If .CloseAY = True Then
                        .Academic_year_status = "Active"
                        If .ActivateAY = True Then
                            MessageBox.Show("Academic Year has been activated", "Activate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            .LoadAYRecords(dgvAY, "ALL", 0)
                            .AYRecordCount("ALL")
                            lblAYTotal.Text = .Acad_count
                            .Acad_count = 0
                            .AYRecordCount("Active")
                            lblAYTotalActive.Text = .Acad_count
                            .Acad_count = 0
                            .AYRecordCount("Inactive")
                            lblAYTotalClose.Text = .Acad_count
                        Else
                            MessageBox.Show("Academic Year has not been activated", "Activate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            .AYRecordCount("ALL")
                            lblAYTotal.Text = .Acad_count
                            .Acad_count = 0
                            .AYRecordCount("Active")
                            lblAYTotalActive.Text = .Acad_count
                            .Acad_count = 0
                            .AYRecordCount("Inactive")
                            lblAYTotalClose.Text = .Acad_count
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .AYRecordCount("ALL")
                        lblAYTotal.Text = .Acad_count
                        .Acad_count = 0
                        .AYRecordCount("Active")
                        lblAYTotalActive.Text = .Acad_count
                        .Acad_count = 0
                        .AYRecordCount("Inactive")
                        lblAYTotalClose.Text = .Acad_count
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Current academic year is not end yet. Please wait for the date to come." + vbCrLf + "Cannot activate this academic year.", "Activate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvAY.ClearSelection()
                    .AYRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                    Exit Sub
                End If

            End With
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
                        _acad_year_obj.LoadAYRecords(dgvAY, "ALL", 0)
                    End If

                    .AYRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                ElseIf cboSort.SelectedIndex = 1 Then
                    If txtSearch.Text.Length >= 2 Then
                        txtSearch_TextChanged(sender, e)
                    Else
                        _acad_year_obj.LoadAYRecords(dgvAY, "Active", 0)
                    End If


                    .AYRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                ElseIf cboSort.SelectedIndex = 2 Then
                    If txtSearch.Text.Length >= 2 Then
                        txtSearch_TextChanged(sender, e)
                    Else
                        _acad_year_obj.LoadAYRecords(dgvAY, "Inactive", 0)
                    End If

                    .AYRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                Else
                    Exit Sub
                End If
            End With

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmAYRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblRefresh.LinkClicked
        Try
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                If cboSort.SelectedIndex = 0 Then
                    _acad_year_obj.LoadAYRecords(dgvAY, "ALL", 0)
                    .AYRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                ElseIf cboSort.SelectedIndex = 1 Then
                    _acad_year_obj.LoadAYRecords(dgvAY, "Active", 0)
                    .AYRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                ElseIf cboSort.SelectedIndex = 2 Then
                    _acad_year_obj.LoadAYRecords(dgvAY, "Inactive", 0)
                    .AYRecordCount("ALL")
                    lblAYTotal.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Active")
                    lblAYTotalActive.Text = .Acad_count
                    .Acad_count = 0
                    .AYRecordCount("Inactive")
                    lblAYTotalClose.Text = .Acad_count
                Else
                    Exit Sub
                End If

            End With

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub lnklblPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
        Try
            'code here for print crytsal report
            Dim dt As New DataTable
            Dim rpt As New rptAcadmicYear
            Dim frm As New reports

            With dt
                .Columns.Add("academic_year")
                .Columns.Add("date_settings_start")
                .Columns.Add("date_settings_end")
                .Columns.Add("academic_year_status")
            End With


            For i As Integer = 0 To dgvAY.RowCount - 1
                dt.Rows.Add(dgvAY.Rows(i).Cells(1).Value.ToString,
                            dgvAY.Rows(i).Cells(2).Value.ToString,
                            dgvAY.Rows(i).Cells(3).Value.ToString,
                            dgvAY.Rows(i).Cells(4).Value.ToString)
            Next



            rpt.SetDataSource(dt)
            rpt.SetParameterValue("acad_year", frmHome.lblAY.Text)

            With frm
                .CrystalReportViewer1.ReportSource = rpt
                .CrystalReportViewer1.Refresh()
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvAY_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvAY.RowPrePaint
        Try
            If dgvAY.Rows(e.RowIndex).Cells(4).Value.ToString = "Active" Then
                dgvAY.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.ForestGreen
                dgvAY.Rows(e.RowIndex).DefaultCellStyle.ForeColor = Color.White
            Else
                dgvAY.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class