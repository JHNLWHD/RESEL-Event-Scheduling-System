Imports MySql.Data.MySqlClient
Public Class frmHome

    Public _acad_year_obj As AcademicYearClass
    Public _account_obj As AccountClass
    Public _event_obj As EventClass
    Dim _flag As String = ""
    Dim str As String = ""


    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'CODE HERE
            If Connect() = True Then
                tmrDateTime.Start()
                tmrEvents.Start()

                lblConn.Text = "Connection Status: Connected"
            Else
                lblConn.Text = "Connection Status: Disconnected"
            End If
        Catch ex As Exception
            lblConn.Text = "Connection Status: Disconnected"
        End Try
    End Sub

    Private Sub tmrDateTime_Tick(sender As Object, e As EventArgs) Handles tmrDateTime.Tick
        Try
            lblDate.Text = getDate()
            lblTime.Text = getTime()
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                .getActiveAY()
                lblAY.Text = .Academic_year
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmHome_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If _flag = "CLICK" Then
                Dispose()
            Else
                _account_obj = New AccountClass
                With _account_obj
                    .Idaccount = frmLogIn._user_id
                    .Account_isLogin = "FALSE"
                    Dim ans As MsgBoxResult

                    ans = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If ans = MsgBoxResult.Yes Then
                        str = "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                                                                & "VALUES('" & MySqlHelper.EscapeString("You have logged out.") & "'," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have logged out.") & "',CURRENT_TIMESTAMP," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"

                        If .UpdateAccountFlag(str) = True Then
                            _flag = ""
                            ' Close()
                            frmLogIn.Show()
                            frmLogIn.txtUsername.Clear()
                            frmLogIn.txtPassword.Clear()
                            frmLogIn.txtUsername.Focus()
                        Else
                            MessageBox.Show("Failed to log-out", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Else
                        e.Cancel = True
                    End If
                End With
            End If

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub ManageAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageAccountsToolStripMenuItem.Click
        Try
            frmManageAccounts.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ManageCollegeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageCollegeToolStripMenuItem.Click
        Try
            frmManageCollege.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub DepartmentsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DepartmentsToolStripMenuItem.Click
        Try
            frmManageUnits.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub SchoolYearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SchoolYearToolStripMenuItem.Click
        Try
            frmManageAcademicYear.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ManageVenueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageVenueToolStripMenuItem.Click
        Try
            frmManageVenue.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub EventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EventsToolStripMenuItem.Click
        Try
            'frmManageEvents.ShowDialog()
            frmEventScheduling.ShowDialog()
        Catch ex As Exception
            ' MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ManageHolidaysToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageHolidaysToolStripMenuItem.Click
        Try
            frmManageHoliday.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ManagePartnerAgencyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManagePartnerAgencyToolStripMenuItem.Click
        Try
            frmManagePartnerAgency.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BackUpDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackUpDatabaseToolStripMenuItem.Click
        Try
            Dim file As String
            sfd.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*"
            sfd.FileName = "Database Backup " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".sql"
            If sfd.ShowDialog = DialogResult.OK Then
                file = sfd.FileName
                databaseBackup(file)
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub RestoreDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestoreDatabaseToolStripMenuItem.Click
        Try
            Dim file As String
            ofd.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*"
            If ofd.ShowDialog = DialogResult.OK Then
                file = ofd.FileName
                databaseRestore(file)
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        Try
            _account_obj = New AccountClass
            With _account_obj
                .Idaccount = frmLogIn._user_id
                .Account_isLogin = "FALSE"
                Dim ans As MsgBoxResult

                ans = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If ans = MsgBoxResult.Yes Then
                    str = "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                                                                & "VALUES('" & MySqlHelper.EscapeString("You have logged out.") & "'," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have logged out.") & "',CURRENT_TIMESTAMP," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"

                    If .UpdateAccountFlag(str) = True Then
                        _flag = "CLICK"
                        Close()
                        frmLogIn.Show()
                        frmLogIn.txtUsername.Clear()
                        frmLogIn.txtPassword.Clear()
                        frmLogIn.txtUsername.Focus()
                    Else
                        _flag = ""
                        MessageBox.Show("Failed to log-out", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    _flag = ""
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            _flag = ""
            Exit Sub
        End Try
    End Sub

    Public Sub tmrEvents_Tick(sender As Object, e As EventArgs) Handles tmrEvents.Tick
        Try
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()

            With _event_obj
                .LoadListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, dgvEvents)
                .LoadEventsByType(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev, "PENDING")
                .LoadEventsByType(_acad_year_obj.Idacademic_year, dgvOverdue, frmLogIn._user_type, frmLogIn._user_unit_abbrev, "OVERDUE")
                .LoadEventsByType(_acad_year_obj.Idacademic_year, dgvToday, frmLogIn._user_type, frmLogIn._user_unit_abbrev, "ON-GOING")
            End With
            tmrEvents.Interval = 50000
            '  tmrEvents.Stop()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ListOfEventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ListOfEventsToolStripMenuItem.Click
        Try
            ListofEvents.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ArchiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchiveToolStripMenuItem.Click
        Try
            frmArchive.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub dgvPending_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPending.CellDoubleClick
    '    Try
    '        _event_obj = New EventClass
    '        With _event_obj
    '            .LoadEventsDetails(frmViewdetails.dgvSchedule, dgvPending.SelectedRows(0).Cells(0).Value.ToString)
    '            frmViewdetails.lblActCode.Text = .Event_code
    '            frmViewdetails.lblEventName.Text = .Event_name
    '            frmViewdetails.lblGoal.Text = .Event_goal
    '            frmViewdetails.lblType.Text = .Event_type
    '            frmViewdetails.lblNo.Text = .Event_number_of_participants
    '            frmViewdetails.lblType.Text = .Event_type
    '            frmViewdetails.lblUnit.Text = .Event_unit
    '            frmViewdetails.ShowDialog()
    '        End With

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub dgvOverdue_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOverdue.CellDoubleClick
    '    Try
    '        _event_obj = New EventClass
    '        With _event_obj
    '            .LoadEventsDetails(frmViewdetails.dgvSchedule, dgvPending.SelectedRows(0).Cells(0).Value.ToString)
    '            frmViewdetails.lblActCode.Text = .Event_code
    '            frmViewdetails.lblEventName.Text = .Event_name
    '            frmViewdetails.lblGoal.Text = .Event_goal
    '            frmViewdetails.lblType.Text = .Event_type
    '            frmViewdetails.lblNo.Text = .Event_number_of_participants
    '            frmViewdetails.lblType.Text = .Event_type
    '            frmViewdetails.lblUnit.Text = .Event_unit
    '            frmViewdetails.ShowDialog()
    '        End With

    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub dgvToday_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvToday.CellDoubleClick
    '    Try
    '        _event_obj = New EventClass
    '        With _event_obj
    '            .LoadEventsDetails(frmViewdetails.dgvSchedule, dgvPending.SelectedRows(0).Cells(0).Value.ToString)
    '            frmViewdetails.lblActCode.Text = .Event_code
    '            frmViewdetails.lblEventName.Text = .Event_name
    '            frmViewdetails.lblGoal.Text = .Event_goal
    '            frmViewdetails.lblType.Text = .Event_type
    '            frmViewdetails.lblNo.Text = .Event_number_of_participants
    '            frmViewdetails.lblType.Text = .Event_type
    '            frmViewdetails.lblUnit.Text = .Event_unit
    '            frmViewdetails.ShowDialog()
    '        End With

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub ActivityLogsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivityLogsToolStripMenuItem.Click
        Try
            frmActivityLogs.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EventsReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EventsReportsToolStripMenuItem.Click
        Try
            frmEventReportRecords.Show()
        Catch ex As Exception
            'MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub DateSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DateSettingsToolStripMenuItem.Click
        Try
            frmManageDateSettingsvb.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AccountSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountSettingsToolStripMenuItem.Click
        Try
            frmaccountsettings.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ActivityLogs2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActivityLogs2ToolStripMenuItem.Click
        Try
            frmallactivitylogs.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub PendingToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Try
    '        frmPendEve.ShowDialog()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub OverdueToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Try
    '        frmOverdue.ShowDialog()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub OnGoingToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Try
    '        frmTodayEve.ShowDialog()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub AllToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Try
    '        ListofEvents.ShowDialog()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub ViewEventTrackingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewEventTrackingToolStripMenuItem.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadEventsDetails(frmEventTrack.dgvSchedule, dgvEvents.SelectedRows(0).Cells(0).Value.ToString)
                frmEventTrack.lblActCode.Text = .Event_code
                frmEventTrack.lblEventName.Text = .Event_name
                frmEventTrack.lblGoal.Text = .Event_goal
                frmEventTrack.lblType.Text = .Event_type
                frmEventTrack.lblNo.Text = .Event_number_of_participants
                frmEventTrack.lblType.Text = .Event_type
                frmEventTrack.lblUnit.Text = .Event_unit
                frmEventTrack.lblPriority.Text = .Event_priority
                .LoadEventsTrack(frmEventTrack.dgvTrack, .Ideveent)
                frmEventTrack.ShowDialog()
            End With

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvEvents_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEvents.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                If e.RowIndex >= 0 Then
                    dgvEvents.Rows(e.RowIndex).Selected = True
                    dgvEvents.CurrentCell = dgvEvents.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If dgvEvents.SelectedRows.Count = 1 Then
                        If dgvEvents.SelectedRows(0).Cells(6).Value.ToString = "Completed" Then
                            cmManage.Items.Remove(EditEventDetaisToolStripMenuItem)
                            cmManage.Items.Remove(RescheduleThisEventToolStripMenuItem)
                            cmManage.Show(dgvEvents, e.Location)
                            cmManage.Show(Cursor.Position)
                        ElseIf dgvEvents.SelectedRows(0).Cells(6).Value.ToString = "On-going" Then
                            cmManage.Items.Remove(RescheduleThisEventToolStripMenuItem)
                            cmManage.Items.Insert(0, EditEventDetaisToolStripMenuItem)
                            cmManage.Show(dgvEvents, e.Location)
                            cmManage.Show(Cursor.Position)
                        ElseIf dgvEvents.SelectedRows(0).Cells(6).Value.ToString = "Overdue" Or dgvEvents.SelectedRows(0).Cells(6).Value.ToString = "Pending" Then
                            cmManage.Items.Insert(0, EditEventDetaisToolStripMenuItem)
                            cmManage.Items.Insert(1, RescheduleThisEventToolStripMenuItem)
                            cmManage.Show(dgvEvents, e.Location)
                            cmManage.Show(Cursor.Position)
                        Else
                            cmManage.Items.Insert(0, EditEventDetaisToolStripMenuItem)
                            cmManage.Items.Insert(1, RescheduleThisEventToolStripMenuItem)
                            cmManage.Show(dgvEvents, e.Location)
                            cmManage.Show(Cursor.Position)
                        End If
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            frmEventScheduling.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvEvents_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvEvents.RowPrePaint
        Try
            With dgvEvents.Rows(e.RowIndex).Cells(6)
                If .Value.ToString = "Pending" Then
                    .Style.ForeColor = Color.Yellow
                    .Style.Font = New Font("Segoe UI", 11.25, FontStyle.Bold)

                ElseIf .Value.ToString = "Overdue" Then
                    .Style.ForeColor = Color.Red
                    .Style.Font = New Font("Segoe UI", 11.25, FontStyle.Bold)

                ElseIf .Value.ToString = "On-going" Then
                    .Style.ForeColor = Color.SeaGreen
                    .Style.Font = New Font("Segoe UI", 11.25, FontStyle.Bold)


                ElseIf .Value.ToString = "Incoming" Then
                    .Style.ForeColor = Color.Purple
                    .Style.Font = New Font("Segoe UI", 11.25, FontStyle.Bold)

                ElseIf .Value.ToString = "Completed" Then
                    .Style.ForeColor = Color.SkyBlue
                    .Style.Font = New Font("Segoe UI", 11.25, FontStyle.Bold)

                End If
            End With

        Catch ex As Exception

        End Try
    End Sub

    'Private Sub CompletedToolStripMenuItem_Click(sender As Object, e As EventArgs)
    '    Try
    '        frmCompletedEvents.ShowDialog()
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()

            With _event_obj
                If txtSearch.Text.Length >= 2 Then
                    .SearchListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, dgvEvents, txtSearch.Text)
                ElseIf txtSearch.Text = vbNullString Then
                    .LoadListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, dgvEvents)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ViewMoreDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewMoreDetailsToolStripMenuItem.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadEventsDetails(frmViewdetails.dgvSchedule, dgvEvents.SelectedRows(0).Cells(0).Value.ToString)
                frmViewdetails.lblActCode.Text = .Event_code
                frmViewdetails.lblEventName.Text = .Event_name
                frmViewdetails.lblGoal.Text = .Event_goal
                frmViewdetails.lblType.Text = .Event_type
                frmViewdetails.lblNo.Text = .Event_number_of_participants
                frmViewdetails.lblType.Text = .Event_type
                frmViewdetails.lblUnit.Text = .Event_unit
                frmViewdetails.lblPriority.Text = .Event_priority
                frmViewdetails.ShowDialog()
            End With

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvPending_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPending.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                If e.RowIndex >= 0 Then
                    dgvPending.Rows(e.RowIndex).Selected = True
                    dgvPending.CurrentCell = dgvPending.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If dgvPending.SelectedRows.Count = 1 Then
                        cmManage.Show(dgvPending, e.Location)
                        cmManage.Show(Cursor.Position)
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub dgvOverdue_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvOverdue.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                If e.RowIndex >= 0 Then
                    dgvOverdue.Rows(e.RowIndex).Selected = True
                    dgvOverdue.CurrentCell = dgvOverdue.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If dgvOverdue.SelectedRows.Count = 1 Then
                        cmManage.Show(dgvOverdue, e.Location)
                        cmManage.Show(Cursor.Position)
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub EditEventDetaisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditEventDetaisToolStripMenuItem.Click
        Try
            _acad_year_obj = New AcademicYearClass
            _event_obj = New EventClass
            With _event_obj
                .LoadEventsDetailsToEdit(frmViewdetails.dgvSchedule, dgvEvents.SelectedRows(0).Cells(0).Value.ToString)
                frmEditDetails.txtCode.Text = .Event_code
                frmEditDetails.txtTitleOfActivity.Text = .Event_name
                frmEditDetails.txtGoal.Text = .Event_goal
                frmEditDetails.txtType.Text = .Event_type
                frmEditDetails.txtNumberOfParticipants.Text = .Event_number_of_participants
                frmEditDetails.txtStatus.Text = .Event_status
                frmEditDetails.txtBudget.Text = .Event_budget
                If .Event_priority = "Priority" Then
                    frmEditDetails.chkPriority.Checked = True
                Else
                    frmEditDetails.chkPriority.Checked = False
                End If
                frmEditDetails.idC = .Ideveent
                frmEditDetails.ShowDialog()
            End With
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RescheduleThisEventToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RescheduleThisEventToolStripMenuItem.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                If dgvEvents.SelectedRows(0).Cells(6).Value.ToString = "Completed" Then
                    MessageBox.Show("Event is already completed and can't be rescheduled.")
                    Exit Sub
                Else
                    .LoadEventsDetailsToResched(frmEventReschedulingvb.dgvSchedule, dgvEvents.SelectedRows(0).Cells(0).Value.ToString)
                    frmEventReschedulingvb.idEve = .Ideveent
                    frmEventReschedulingvb.lblActCode.Text = .Event_code
                    frmEventReschedulingvb.lblEventName.Text = .Event_name
                    frmEventReschedulingvb.lblGoal.Text = .Event_goal
                    frmEventReschedulingvb.lblType.Text = .Event_type
                    frmEventReschedulingvb.lblNo.Text = .Event_number_of_participants
                    frmEventReschedulingvb.lblType.Text = .Event_type
                    frmEventReschedulingvb.lblUnit.Text = .Event_unit
                    frmEventReschedulingvb._prio = .Event_priority
                    frmEventReschedulingvb.lblStatus.Text = .Event_priority
                    frmEventReschedulingvb.status = .Event_status
                    frmEventReschedulingvb.ShowDialog()
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Try
            EditEventDetaisToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        Try
            RescheduleThisEventToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Try
            ViewEventTrackingToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        Try
            ViewMoreDetailsToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem11.Click
        Try
            EditEventDetaisToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        Try
            RescheduleThisEventToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        Try
            ViewEventTrackingToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        Try
            ViewMoreDetailsToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        Try
            ViewEventTrackingToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        Try
            ViewMoreDetailsToolStripMenuItem_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvToday_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvToday.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                If e.RowIndex >= 0 Then
                    dgvToday.Rows(e.RowIndex).Selected = True
                    dgvToday.CurrentCell = dgvToday.Rows(e.RowIndex).Cells(e.ColumnIndex)

                    If dgvOverdue.SelectedRows.Count = 1 Then
                        cmToday.Show(dgvToday, e.Location)
                        cmToday.Show(Cursor.Position)
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub MissionToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MissionToolStripMenuItem1.Click
        Try

            MessageBox.Show("RESEL Event Scheduling System was developed by AL-JHOENIL D. WAHID for OJT project.", "About System", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class
