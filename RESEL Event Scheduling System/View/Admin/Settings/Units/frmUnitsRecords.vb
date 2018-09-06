Public Class frmUnitsRecords

    Public _account_obj As AccountClass

    Private Sub frmUnitsRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _account_obj = New AccountClass
            With _account_obj
                '  .LoadUnitRecords(dgvAccounts, "Active")
                cboSort.SelectedIndex = 0
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cboSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSort.SelectedIndexChanged
        Try
            _account_obj = New AccountClass
            With _account_obj
                If cboSort.SelectedIndex = 0 Then
                    .LoadUnitRecords(dgvUnits, "Active")

                    .UnitRecordCount("Active")
                    lblActiveUnit.Text = .Unit_count

                    .UnitRecordCount("Inactive")
                    lblInactiveUnit.Text = .Unit_count

                    .UnitRecordCount("Active,Inactive")
                    lblTotalUnit.Text = .Unit_count

                ElseIf cboSort.SelectedIndex = 1 Then
                    .LoadUnitRecords(dgvUnits, "Inactive")

                    .UnitRecordCount("Active")
                    lblActiveUnit.Text = .Unit_count

                    .UnitRecordCount("Inactive")
                    lblInactiveUnit.Text = .Unit_count

                    .UnitRecordCount("Active,Inactive")
                    lblTotalUnit.Text = .Unit_count

                ElseIf cboSort.SelectedIndex = 2 Then
                    .LoadUnitRecords(dgvUnits, "Active,Inactive")

                    .UnitRecordCount("Active")
                    lblActiveUnit.Text = .Unit_count

                    .UnitRecordCount("Inactive")
                    lblInactiveUnit.Text = .Unit_count

                    .UnitRecordCount("Active,Inactive")
                    lblTotalUnit.Text = .Unit_count

                End If
            End With

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _account_obj = New AccountClass
            With _account_obj
                If cboSort.SelectedIndex = 0 Then
                    .UnitRecordCount("Active")
                    lblActiveUnit.Text = .Unit_count

                    .UnitRecordCount("Inactive")
                    lblInactiveUnit.Text = .Unit_count

                    .UnitRecordCount("Active,Inactive")
                    lblTotalUnit.Text = .Unit_count
                    If txtSearch.Text.Length >= 2 Then

                        .SearchUnitRecords(dgvUnits, txtSearch.Text, 0, "Active")
                    ElseIf txtSearch.Text = vbNullString Then
                        .LoadUnitRecords(dgvUnits, "Active")
                    End If
                ElseIf cboSort.SelectedIndex = 1 Then
                    .UnitRecordCount("Active")
                    lblActiveUnit.Text = .Unit_count

                    .UnitRecordCount("Inactive")
                    lblInactiveUnit.Text = .Unit_count

                    .UnitRecordCount("Active,Inactive")
                    lblTotalUnit.Text = .Unit_count
                    If txtSearch.Text.Length >= 2 Then
                        .SearchUnitRecords(dgvUnits, txtSearch.Text, 0, "Inactive")
                    ElseIf txtSearch.Text = vbNullString Then
                        .LoadUnitRecords(dgvUnits, "Inactive")
                    End If
                ElseIf cboSort.SelectedIndex = 2 Then
                    .UnitRecordCount("Active")
                    lblActiveUnit.Text = .Unit_count

                    .UnitRecordCount("Inactive")
                    lblInactiveUnit.Text = .Unit_count

                    .UnitRecordCount("Active,Inactive")
                    lblTotalUnit.Text = .Unit_count
                    If txtSearch.Text.Length >= 2 Then
                        .SearchUnitRecords(dgvUnits, txtSearch.Text, 0, "Active,Inactive")
                    ElseIf txtSearch.Text = vbNullString Then
                        .LoadUnitRecords(dgvUnits, "Active,Inactive")
                    End If
                End If

            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmUnitsRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateToolStripMenuItem.Click
        Try
            _account_obj = New AccountClass
            With _account_obj
                .Idunit = dgvUnits.SelectedRows(0).Cells(0).Value.ToString
                .Unit_name = dgvUnits.SelectedRows(0).Cells(1).Value.ToString
                If .ActivateUnit = True Then
                    MessageBox.Show("Unit has been activated", "Activate Unit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If cboSort.SelectedIndex = 0 Then
                        .LoadUnitRecords(dgvUnits, "Active")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 1 Then
                        .LoadUnitRecords(dgvUnits, "Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 2 Then
                        .LoadUnitRecords(dgvUnits, "Active,Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    End If
                    Exit Sub
                Else
                    MessageBox.Show("Unit has not been activated", "Activate Unit", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If cboSort.SelectedIndex = 0 Then
                        .LoadUnitRecords(dgvUnits, "Active")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 1 Then
                        .LoadUnitRecords(dgvUnits, "Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 2 Then
                        .LoadUnitRecords(dgvUnits, "Active,Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    End If
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            'activate

            _account_obj = New AccountClass
            With _account_obj
                Dim ans As MsgBoxResult
                ans = MessageBox.Show("Are you sure you want to remove this unit?" + vbCrLf + "This will result to deactivating the unit also.", "Remove Unit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If ans = MsgBoxResult.Yes Then
                    .Idunit = dgvUnits.SelectedRows(0).Cells(0).Value.ToString
                    .Unit_name = dgvUnits.SelectedRows(0).Cells(1).Value.ToString
                    .Unit_remove_status = "TRUE"
                    If .RemoveUnit = True Then
                        MessageBox.Show("Unit has been removed", "Remove Unit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If cboSort.SelectedIndex = 0 Then
                            .LoadUnitRecords(dgvUnits, "Active")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        ElseIf cboSort.SelectedIndex = 1 Then
                            .LoadUnitRecords(dgvUnits, "Inactive")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        ElseIf cboSort.SelectedIndex = 2 Then
                            .LoadUnitRecords(dgvUnits, "Active,Inactive")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        End If
                        Exit Sub
                    Else
                        MessageBox.Show("Unit has not been removed", "Removed Unit", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        If cboSort.SelectedIndex = 0 Then
                            .LoadUnitRecords(dgvUnits, "Active")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        ElseIf cboSort.SelectedIndex = 1 Then
                            .LoadUnitRecords(dgvUnits, "Inactive")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        ElseIf cboSort.SelectedIndex = 2 Then
                            .LoadUnitRecords(dgvUnits, "Active,Inactive")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        End If
                        Exit Sub
                    End If
                Else
                    If cboSort.SelectedIndex = 0 Then
                        .LoadUnitRecords(dgvUnits, "Active")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 1 Then
                        .LoadUnitRecords(dgvUnits, "Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 2 Then
                        .LoadUnitRecords(dgvUnits, "Active,Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    End If
                    Exit Sub
                End If

            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub DeactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeactivateToolStripMenuItem.Click
        Try
            _account_obj = New AccountClass
            With _account_obj
                .Idunit = dgvUnits.SelectedRows(0).Cells(0).Value.ToString
                .Unit_name = dgvUnits.SelectedRows(0).Cells(1).Value.ToString
                Dim ans As MsgBoxResult

                ans = MessageBox.Show("This will result to deactivating the accounts under this unit." + vbCrLf + "Are you sure you want to deactivate this unit?", "Deactivate Unit", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If ans = MsgBoxResult.Yes Then
                    If .DeactivateUnit = True Then
                        MessageBox.Show("Unit has been deactivated", "Deactivate Unit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If cboSort.SelectedIndex = 0 Then
                            .LoadUnitRecords(dgvUnits, "Active")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        ElseIf cboSort.SelectedIndex = 1 Then
                            .LoadUnitRecords(dgvUnits, "Inactive")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        ElseIf cboSort.SelectedIndex = 2 Then
                            .LoadUnitRecords(dgvUnits, "Active,Inactive")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        End If
                        Exit Sub
                    Else
                        MessageBox.Show("Unit has not been deactivated", "Dectivate Unit", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        If cboSort.SelectedIndex = 0 Then
                            .LoadUnitRecords(dgvUnits, "Active")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        ElseIf cboSort.SelectedIndex = 1 Then
                            .LoadUnitRecords(dgvUnits, "Inactive")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        ElseIf cboSort.SelectedIndex = 2 Then
                            .LoadUnitRecords(dgvUnits, "Active,Inactive")

                            .UnitRecordCount("Active")
                            lblActiveUnit.Text = .Unit_count

                            .UnitRecordCount("Inactive")
                            lblInactiveUnit.Text = .Unit_count

                            .UnitRecordCount("Active,Inactive")
                            lblTotalUnit.Text = .Unit_count

                        End If
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

    Private Sub RemoveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem1.Click
        Try
            'deactivate
            _account_obj = New AccountClass
            With _account_obj
                .Idunit = dgvUnits.SelectedRows(0).Cells(0).Value.ToString
                .Unit_name = dgvUnits.SelectedRows(0).Cells(1).Value.ToString
                .Unit_remove_status = "TRUE"
                'Dim ans As MsgBoxResult
                'If ans = MsgBoxResult.Yes Then
                .Idunit = dgvUnits.SelectedRows(0).Cells(0).Value.ToString
                .Unit_name = dgvUnits.SelectedRows(0).Cells(1).Value.ToString
                .Unit_remove_status = "TRUE"
                If .RemoveUnit = True Then
                    MessageBox.Show("Unit has been removed", "Remove Unit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If cboSort.SelectedIndex = 0 Then
                        .LoadUnitRecords(dgvUnits, "Active")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 1 Then
                        .LoadUnitRecords(dgvUnits, "Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 2 Then
                        .LoadUnitRecords(dgvUnits, "Active,Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    End If
                    Exit Sub
                Else
                    MessageBox.Show("Unit has not been removed", "Removed Unit", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If cboSort.SelectedIndex = 0 Then
                        .LoadUnitRecords(dgvUnits, "Active")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 1 Then
                        .LoadUnitRecords(dgvUnits, "Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    ElseIf cboSort.SelectedIndex = 2 Then
                        .LoadUnitRecords(dgvUnits, "Active,Inactive")

                        .UnitRecordCount("Active")
                        lblActiveUnit.Text = .Unit_count

                        .UnitRecordCount("Inactive")
                        lblInactiveUnit.Text = .Unit_count

                        .UnitRecordCount("Active,Inactive")
                        lblTotalUnit.Text = .Unit_count

                    End If
                    Exit Sub
                End If
                ' Else
                'If cboSort.SelectedIndex = 0 Then
                '        .LoadUnitRecords(dgvAccounts, "Active")

                '        .UnitRecordCount("Active")
                '        lblActiveUnit.Text = .Unit_count

                '        .UnitRecordCount("Inactive")
                '        lblInactiveUnit.Text = .Unit_count

                '        .UnitRecordCount("Active,Inactive")
                '        lblTotalUnit.Text = .Unit_count

                '    ElseIf cboSort.SelectedIndex = 1 Then
                '        .LoadUnitRecords(dgvAccounts, "Inactive")

                '        .UnitRecordCount("Active")
                '        lblActiveUnit.Text = .Unit_count

                '        .UnitRecordCount("Inactive")
                '        lblInactiveUnit.Text = .Unit_count

                '        .UnitRecordCount("Active,Inactive")
                '        lblTotalUnit.Text = .Unit_count

                '    ElseIf cboSort.SelectedIndex = 2 Then
                '        .LoadUnitRecords(dgvAccounts, "Active,Inactive")

                '        .UnitRecordCount("Active")
                '        lblActiveUnit.Text = .Unit_count

                '        .UnitRecordCount("Inactive")
                '        lblInactiveUnit.Text = .Unit_count

                '        .UnitRecordCount("Active,Inactive")
                '        lblTotalUnit.Text = .Unit_count

                ' End If
                Exit Sub
                '  End If
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub dgvUnits_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvUnits.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvUnits.Rows(e.RowIndex).Selected = True
                dgvUnits.CurrentCell = dgvUnits.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvUnits.SelectedRows.Count = 1 Then

                    If dgvUnits.SelectedRows(0).Cells(4).Value.ToString = "Active" Then
                        cmDeact.Show(dgvUnits, e.Location)
                        cmDeact.Show(Cursor.Position)
                    ElseIf dgvUnits.SelectedRows(0).Cells(4).Value.ToString = "Inactive" Then
                        cmAct.Show(dgvUnits, e.Location)
                        cmAct.Show(Cursor.Position)
                    Else
                        Exit Sub
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblRefresh.LinkClicked
        Try
            txtSearch.Clear()
            cboSort_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnklblPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
        Try
            Dim dt As New DataTable
            Dim rpt As New rptUnits
            Dim frm As New reports

            With dt
                .Columns.Add("unit_name")
                .Columns.Add("unit_abbrev")
                .Columns.Add("unit_reg_date")
                .Columns.Add("unit_status")
            End With

            For i As Integer = 0 To dgvUnits.RowCount - 1
                dt.Rows.Add(dgvUnits.Rows(i).Cells(1).Value.ToString,
                            dgvUnits.Rows(i).Cells(2).Value.ToString,
                            dgvUnits.Rows(i).Cells(3).Value.ToString,
                            dgvUnits.Rows(i).Cells(4).Value.ToString)
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