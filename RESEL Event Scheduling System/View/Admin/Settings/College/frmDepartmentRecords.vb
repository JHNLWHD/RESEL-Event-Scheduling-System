Public Class frmDepartmentRecords

    Public _dept_obj As CollegeClass


    Private Sub frmDepartmentRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _dept_obj = New CollegeClass
            With _dept_obj
                .LoadDepartment(dgvDept)
                .DeptRecordCount()
                lblDeptTotal.Text = .Dept_count
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _dept_obj = New CollegeClass
            With _dept_obj
                If txtSearch.Text.Length >= 2 Then
                    .SearchDepartment(dgvDept, txtSearch.Text)
                ElseIf txtSearch.Text = vbNullString Then
                    .LoadDepartment(dgvDept)
                End If

            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmDepartmentRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            _dept_obj = New CollegeClass
            With _dept_obj
                .LoadCollege(0, dgvDept.SelectedRows(0).Cells(4).Value.ToString)
                .College_name = .College_name
                .Iddepartment = dgvDept.SelectedRows(0).Cells(0).Value.ToString
                .Department_name = dgvDept.SelectedRows(0).Cells(1).Value.ToString
                .Department_remove_status = "TRUE"
                If .RemoveDepartmentRecord = True Then
                    MessageBox.Show("Department has been removed.", "Remove Department", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    .LoadDepartment(dgvDept)
                    .DeptRecordCount()
                    lblDeptTotal.Text = .Dept_count
                    Exit Sub
                Else
                    MessageBox.Show("Department has not been removed.", "Remove Department", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .LoadDepartment(dgvDept)
                    .DeptRecordCount()
                    lblDeptTotal.Text = .Dept_count
                    Exit Sub
                End If
            End With
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
            _dept_obj = New CollegeClass
            With _dept_obj
                .LoadDepartment(dgvDept)
                .DeptRecordCount()
                lblDeptTotal.Text = .Dept_count
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvCollege_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDept.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try

                If e.RowIndex >= 0 Then
                    dgvDept.Rows(e.RowIndex).Selected = True
                    dgvDept.CurrentCell = dgvDept.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If dgvDept.SelectedRows.Count = 1 Then

                        cmManage.Show(dgvDept, e.Location)
                        cmManage.Show(Cursor.Position)
                    End If



                End If
            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub lnklblPrint_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
        Try
            Dim dt As New DataTable
            Dim rpt As New deprtmntrpt
            Dim frm As New reports

            With dt
                .Columns.Add("department_name")
                .Columns.Add("department_abbrev")
                .Columns.Add("department_reg_date")
            End With

            For i As Integer = 0 To dgvDept.RowCount - 1
                dt.Rows.Add(dgvDept.Rows(i).Cells(1).Value.ToString,
                            dgvDept.Rows(i).Cells(2).Value.ToString,
                            dgvDept.Rows(i).Cells(3).Value.ToString)
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