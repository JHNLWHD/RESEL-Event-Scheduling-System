Public Class frmCollegeRecords

    Public _college_obj As CollegeClass
    Public Shared idCOLL As Integer

    Private Sub frmCollegeRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _college_obj = New CollegeClass
            With _college_obj
                .LoadCollegeRecords(dgvCollege, 0)
                .CollegeRecordCount()
                lblTotalCollege.Text = .College_count
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _college_obj = New CollegeClass
            With _college_obj
                If txtSearch.Text.Length >= 2 Then
                    .SearchCollegeRecords(dgvCollege, txtSearch.Text, 0)
                ElseIf txtSearch.Text = vbNullString Then
                    .LoadCollegeRecords(dgvCollege, 0)
                End If
                .CollegeRecordCount()
                lblTotalCollege.Text = .College_count
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvCollege_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvCollege.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvCollege.Rows(e.RowIndex).Selected = True
                dgvCollege.CurrentCell = dgvCollege.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvCollege.SelectedRows.Count = 1 Then
                    cmManage.Show(dgvCollege, e.Location)
                    cmManage.Show(Cursor.Position)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            _college_obj = New CollegeClass
            With _college_obj
                .Idcollege = dgvCollege.SelectedRows(0).Cells(0).Value.ToString
                .College_name = dgvCollege.SelectedRows(0).Cells(1).Value.ToString
                .College_remove_status = "TRUE"
                .Department_remove_status = "TRUE"
                Dim ans As MsgBoxResult
                ans = MessageBox.Show("Are you sure you want to remove this college?" + vbCrLf + "Removing this will result to removing also the departments within this college.", "Remove College", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ans = MsgBoxResult.Yes Then
                    If .RemoveCollege = True Then
                        MessageBox.Show("This college is removed along with departments within.", "Remove College", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        .CollegeRecordCount()
                        lblTotalCollege.Text = .College_count
                        Exit Sub
                    Else
                        MessageBox.Show("This college is not removed.", "Remove College", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .CollegeRecordCount()
                        lblTotalCollege.Text = .College_count
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If

            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ManageDepartmentsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageDepartmentsToolStripMenuItem.Click
        Try
            _college_obj = New CollegeClass
            With frmManageDepartment
                .lblCollege.Text = dgvCollege.SelectedRows(0).Cells(2).Value.ToString
                idCOLL = dgvCollege.SelectedRows(0).Cells(0).Value.ToString
                _college_obj.LoadDeptByCollege(frmManageDepartment.dgvList, dgvCollege.SelectedRows(0).Cells(0).Value.ToString)
                .ShowDialog()
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmCollegeRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub lnklblPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Try
            'code here for print crystal report
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblRefresh.LinkClicked
        Try

            _college_obj = New CollegeClass
            With _college_obj
                .LoadCollegeRecords(dgvCollege, 0)
                .CollegeRecordCount()
                lblTotalCollege.Text = .College_count
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub lnklblPrint_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
        Try
            Dim dt As New DataTable
            Dim rpt As New College
            Dim frm As New reports

            With dt
                .Columns.Add("college_name")
                .Columns.Add("college_abbrev")
                .Columns.Add("college_reg_date")
            End With

            For i As Integer = 0 To dgvCollege.RowCount - 1
                dt.Rows.Add(dgvCollege.Rows(i).Cells(1).Value.ToString,
                            dgvCollege.Rows(i).Cells(2).Value.ToString,
                            dgvCollege.Rows(i).Cells(3).Value.ToString)
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