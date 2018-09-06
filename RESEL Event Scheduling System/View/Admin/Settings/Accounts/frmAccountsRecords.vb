Public Class frmAccountsRecords
    Public _account_obj As AccountClass

    Public Sub frmAccountsRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _account_obj = New AccountClass
            cboSort.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub cboSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSort.SelectedIndexChanged
        Try
            _account_obj = New AccountClass
            With _account_obj
                If cboSort.SelectedIndex = 0 Then
                    .LoadAccountRecords(dgvAccounts, "Active")

                    .AccountRecordCount("Active")
                    lblActiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive")
                    lblInactiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive,Active")
                    lblTotalAccount.Text = .Account_count
                    .Account_count = 0
                ElseIf cboSort.SelectedIndex = 1 Then
                    .LoadAccountRecords(dgvAccounts, "Inactive")

                    .AccountRecordCount("Active")
                    lblActiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive")
                    lblInactiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive,Active")
                    lblTotalAccount.Text = .Account_count
                    .Account_count = 0
                ElseIf cboSort.SelectedIndex = 2 Then
                    .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                    .AccountRecordCount("Active")
                    lblActiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive")
                    lblInactiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive,Active")
                    lblTotalAccount.Text = .Account_count
                    .Account_count = 0
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
                    If txtSearch.Text.Length >= 2 Then
                        _account_obj.SearchAccountRecords(dgvAccounts, "Active", txtSearch.Text, 1, "Load")
                    ElseIf txtSearch.Text = vbNullString Then
                        _account_obj.LoadAccountRecords(dgvAccounts, "Active")
                    End If
                ElseIf cboSort.SelectedIndex = 1 Then
                    If txtSearch.Text.Length >= 2 Then
                        _account_obj.SearchAccountRecords(dgvAccounts, "Inactive", txtSearch.Text, 1, "Load")
                    ElseIf txtSearch.Text = vbNullString Then
                        _account_obj.LoadAccountRecords(dgvAccounts, "Inactive")
                    End If
                ElseIf cboSort.SelectedIndex = 2 Then
                    If txtSearch.Text.Length >= 2 Then
                        _account_obj.SearchAccountRecords(dgvAccounts, "ALL", txtSearch.Text, 1, "Load")
                    ElseIf txtSearch.Text = vbNullString Then
                        _account_obj.LoadAccountRecords(dgvAccounts, "Active,Inactive")
                    End If
                End If

                .AccountRecordCount("Active")
                lblActiveAccount.Text = .Account_count
                .Account_count = 0
                .AccountRecordCount("Inactive")
                lblInactiveAccount.Text = .Account_count
                .Account_count = 0
                .AccountRecordCount("Inactive,Active")
                lblTotalAccount.Text = .Account_count
                .Account_count = 0
            End With


        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub lnkRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkRefresh.LinkClicked
        Try
            _account_obj = New AccountClass
            With _account_obj
                If cboSort.SelectedIndex = 0 Then
                    .LoadAccountRecords(dgvAccounts, "Active")

                    .AccountRecordCount("Active")
                    lblActiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive")
                    lblInactiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive,Active")
                    lblTotalAccount.Text = .Account_count
                    .Account_count = 0
                ElseIf cboSort.SelectedIndex = 1 Then
                    .LoadAccountRecords(dgvAccounts, "Inactive")

                    .AccountRecordCount("Active")
                    lblActiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive")
                    lblInactiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive,Active")
                    lblTotalAccount.Text = .Account_count
                    .Account_count = 0
                ElseIf cboSort.SelectedIndex = 2 Then
                    .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                    .AccountRecordCount("Active")
                    lblActiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive")
                    lblInactiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive,Active")
                    lblTotalAccount.Text = .Account_count
                    .Account_count = 0
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvAccounts_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAccounts.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvAccounts.Rows(e.RowIndex).Selected = True
                dgvAccounts.CurrentCell = dgvAccounts.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvAccounts.SelectedRows.Count = 1 Then

                    If dgvAccounts.SelectedRows(0).Cells(6).Value.ToString = "Active" Then
                        cmDeAct.Show(dgvAccounts, e.Location)
                        cmDeAct.Show(Cursor.Position)
                    ElseIf dgvAccounts.SelectedRows(0).Cells(6).Value.ToString = "Inactive" Then
                        cmAct.Show(dgvAccounts, e.Location)
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

    Private Sub DeactivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeactivateToolStripMenuItem.Click
        Try
            'check if admin
            'if true don't proceed
            _account_obj = New AccountClass
            With _account_obj
                If .hasAdminThanOne = True Then
                    .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                    .Account_name = dgvAccounts.SelectedRows(0).Cells(1).Value.ToString
                    If .DeactivateAccount = True Then
                        MessageBox.Show("Account has been deactivated", "Deactivate Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If cboSort.SelectedIndex = 0 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Active")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        ElseIf cboSort.SelectedIndex = 1 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Inactive")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        ElseIf cboSort.SelectedIndex = 2 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        End If
                        Exit Sub
                    Else
                        MessageBox.Show("Account has not been deactivated", "Deactivate Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                        Exit Sub
                    End If
                Else
                    .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                    .Account_name = dgvAccounts.SelectedRows(0).Cells(1).Value.ToString
                    .Account_type = dgvAccounts.SelectedRows(0).Cells(5).Value.ToString
                    If .Account_type = "User" Then
                        If .DeactivateAccount = True Then
                            MessageBox.Show("Account has been deactivated", "Deactivate Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            If cboSort.SelectedIndex = 0 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Active")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            ElseIf cboSort.SelectedIndex = 1 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Inactive")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            ElseIf cboSort.SelectedIndex = 2 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            End If
                            Exit Sub
                        Else
                            MessageBox.Show("Account has not been deactivated", "Deactivate Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("There is only one admin at the moment. Deactivating is not allowed", "Deactivate Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                        Exit Sub
                    End If

                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivateToolStripMenuItem.Click
        Try
            _account_obj = New AccountClass
            With _account_obj
                .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                .Account_name = dgvAccounts.SelectedRows(0).Cells(1).Value.ToString
                If .ActivateAccount = True Then
                    MessageBox.Show("Account has been activated", "Activate Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    If cboSort.SelectedIndex = 0 Then
                        txtSearch.Clear()
                        .LoadAccountRecords(dgvAccounts, "Active")

                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                    ElseIf cboSort.SelectedIndex = 1 Then
                        txtSearch.Clear()
                        .LoadAccountRecords(dgvAccounts, "Inactive")

                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                    ElseIf cboSort.SelectedIndex = 2 Then
                        txtSearch.Clear()
                        .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                    End If
                    Exit Sub
                Else
                    MessageBox.Show("Account has not been activated", "Activate Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    .AccountRecordCount("Active")
                    lblActiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive")
                    lblInactiveAccount.Text = .Account_count
                    .Account_count = 0
                    .AccountRecordCount("Inactive,Active")
                    lblTotalAccount.Text = .Account_count
                    .Account_count = 0
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmAccountsRecords_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            _account_obj = New AccountClass
            With _account_obj
                .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                .Account_name = dgvAccounts.SelectedRows(0).Cells(1).Value.ToString
                .Account_remove_status = "TRUE"
                If dgvAccounts.SelectedRows(0).Cells(5).Value.ToString = "Admin" Then
                    If .hasAdminThanOne = True Then
                        .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                        If .RemoveAccount = True Then
                            MessageBox.Show("Account has been removed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            If cboSort.SelectedIndex = 0 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Active")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            ElseIf cboSort.SelectedIndex = 1 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Inactive")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            ElseIf cboSort.SelectedIndex = 2 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            End If
                            Exit Sub
                        Else
                            MessageBox.Show("Account has not been removed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                            Exit Sub
                        End If
                    Else

                        MessageBox.Show("There is only one admin at the moment. Removing is not allowed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                        Exit Sub


                    End If
                Else
                    .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                    If .RemoveAccount = True Then
                        MessageBox.Show("Account has been removed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If cboSort.SelectedIndex = 0 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Active")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        ElseIf cboSort.SelectedIndex = 1 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Inactive")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        ElseIf cboSort.SelectedIndex = 2 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        End If
                        Exit Sub
                    Else
                        MessageBox.Show("Account has not been removed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                        Exit Sub
                    End If
                End If


            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RemoveToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem1.Click
        Try
            _account_obj = New AccountClass
            With _account_obj
                .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                .Account_name = dgvAccounts.SelectedRows(0).Cells(1).Value.ToString
                .Account_remove_status = "TRUE"
                If dgvAccounts.SelectedRows(0).Cells(5).Value.ToString = "ADMIN" Then
                    If .hasAdminThanOne = True Then
                        .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                        If .RemoveAccount = True Then
                            MessageBox.Show("Account has been removed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            If cboSort.SelectedIndex = 0 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Active")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            ElseIf cboSort.SelectedIndex = 1 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Inactive")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            ElseIf cboSort.SelectedIndex = 2 Then
                                txtSearch.Clear()
                                .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                                .AccountRecordCount("Active")
                                lblActiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive")
                                lblInactiveAccount.Text = .Account_count
                                .Account_count = 0
                                .AccountRecordCount("Inactive,Active")
                                lblTotalAccount.Text = .Account_count
                                .Account_count = 0
                            End If
                            Exit Sub
                        Else
                            MessageBox.Show("Account has not been removed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Error)

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                            Exit Sub
                        End If
                    Else

                        MessageBox.Show("There is only one admin at the moment. Removing is not allowed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                        Exit Sub


                    End If
                Else
                    .Idaccount = dgvAccounts.SelectedRows(0).Cells(0).Value.ToString
                    If .RemoveAccount = True Then
                        MessageBox.Show("Account has been removed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        If cboSort.SelectedIndex = 0 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Active")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        ElseIf cboSort.SelectedIndex = 1 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Inactive")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        ElseIf cboSort.SelectedIndex = 2 Then
                            txtSearch.Clear()
                            .LoadAccountRecords(dgvAccounts, "Active,Inactive")

                            .AccountRecordCount("Active")
                            lblActiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive")
                            lblInactiveAccount.Text = .Account_count
                            .Account_count = 0
                            .AccountRecordCount("Inactive,Active")
                            lblTotalAccount.Text = .Account_count
                            .Account_count = 0
                        End If
                        Exit Sub
                    Else
                        MessageBox.Show("Account has not been removed", "Remove Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        .AccountRecordCount("Active")
                        lblActiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive")
                        lblInactiveAccount.Text = .Account_count
                        .Account_count = 0
                        .AccountRecordCount("Inactive,Active")
                        lblTotalAccount.Text = .Account_count
                        .Account_count = 0
                        Exit Sub
                    End If
                End If


            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub



    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            'code here for print crystal
            Dim dt As New DataTable
            Dim rpt As New listAccount
            Dim frm As New reports

            With dt.Columns
                .Add("account_fn")
                .Add("account_username")
                .Add("account_position")
                .Add("unit_idunit")
                '.Add(columname)
                'records in report

            End With

            For i As Integer = 0 To dgvAccounts.Rows.Count - 1
                'get from datagridview
                dt.Rows.Add(dgvAccounts.Rows(i).Cells(1).Value.ToString,
                            dgvAccounts.Rows(i).Cells(4).Value.ToString,
                            dgvAccounts.Rows(i).Cells(3).Value.ToString,
                            dgvAccounts.Rows(i).Cells(2).Value.ToString)
            Next



            rpt.SetDataSource(dt)
            rpt.SetParameterValue("acad_year", frmHome.lblAY.Text)

            With frm
                .CrystalReportViewer1.ReportSource = rpt
                .CrystalReportViewer1.Refresh()
                .ShowDialog()
            End With
        Catch ex As Exception
            ' MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


End Class