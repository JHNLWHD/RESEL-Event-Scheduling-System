Imports MySql.Data.MySqlClient
Public Class frmManageEvents

    Public _flag As String = ""
    Public _acad_year_obj As AcademicYearClass
    Public _event_obj As EventClass
    Public _college_obj As CollegeClass
    Public _venue As VenueClass
    Dim _prio As String = ""
    Public str As String = ""
    Public strpa As String = ""
    Public strStartTime As String = ""
    Public strEndTime As String = ""
    Public _event_Stat As Integer = 0
    Public _prio_Stat As Integer = 0
    'IF 0 then APPROVED ELSE PENDING
    Public ch1 As New DataGridViewCheckBoxCell()
    Dim myList As New List(Of String)()
    Dim keyNum As String = "0987654321"
    Public Shared idC As Integer = 0


    Private Sub frmManageEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            tcActivityInfo.Enabled = False
            tcActivitySchedule.Enabled = False
            'tcSearch.Enabled = True
            btnNew.Enabled = True
            btnSave.Enabled = False
            'btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                .getActiveAY()
                dtpDate.MinDate = Convert.ToDateTime(.Academic_year_start)
                dtpDate.MaxDate = Convert.ToDateTime(.Academic_year_end)
            End With
        Catch ex As Exception

            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim pend As Integer = 0
            _acad_year_obj = New AcademicYearClass
            _event_obj = New EventClass
            With _event_obj
                If _flag = "New" Then
                    If RequiredField(txtCode.Text, txtTitleOfActivity.Text, txtBudget.Text, txtGoal.Text, cboType.Text, txtNumberOfParticipants.Text) = True Then
                        .Event_code = txtCode.Text
                        .Event_name = txtTitleOfActivity.Text
                        .Event_budget = txtBudget.Text
                        .Event_goal = txtGoal.Text
                        For Each row As DataGridViewRow In dgvPA.Rows
                            If row.Cells(0).Value.ToString = True Then
                                myList.Add(row.Cells(2).Value.ToString)
                            Else
                                myList.Remove(row.Cells(2).Value.ToString)
                            End If
                        Next
                        Dim myArray As String() = myList.ToArray()
                        For Each value As String In myArray
                            .Event_partner_agency = String.Join(",", value)
                        Next
                        '.Event_partner_agency = txtPartnerAgency.Text
                        .Event_number_of_participants = Decimal.Parse(txtNumberOfParticipants.Text)
                        _acad_year_obj.getActiveAY()
                        .Academic_year_idacademic_year = _acad_year_obj.Idacademic_year
                        .Event_priority = _prio
                        .Event_type = cboType.Text
                        .Event_remove_status = "FALSE"
                        .Event_is_cancel = "FALSE"
                        .Event_remarks = ""
                        .Account_idaccount = frmLogIn._user_id
                        If _prio = "TRUE" Then
                            For Each row As DataGridViewRow In dgvSchedule.Rows
                                If .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, cboVenue.Text, .Academic_year_idacademic_year, "", "TRUE") = True Then

                                    'Dim ans1 As MsgBoxResult
                                    'ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    'If ans1 = MsgBoxResult.Yes Then
                                    ' dgvSchedule.Rows.Add(.Idschedule, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Pending")
                                    str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                        & "VALUES('" & row.Cells(1).Value.ToString & "','" & MySqlHelper.EscapeString(.Idschedule) & "',CURRENT_DATE);"
                                        str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),'" & MySqlHelper.EscapeString(.Idschedule) & "');"
                                        pend = 1
                                    '_prio_Stat = 1
                                    'update the other event to pending
                                    'get all event id then update
                                    'Else
                                    '    '  Exit Sub
                                    'End If

                                ElseIf .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    If ans1 = MsgBoxResult.Yes Then
                                        'dgvSchedule.Rows.Add(.Idschedule, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Approved")
                                        '_prio_Stat = 1
                                        str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                       & "VALUES('" & row.Cells(1).Value.ToString & "','" & MySqlHelper.EscapeString(.Idschedule) & "',CURRENT_DATE);"
                                        str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),'" & MySqlHelper.EscapeString(.Idschedule) & "');"
                                        'update the other event to pending
                                        'get all event id then update
                                        pend = 1
                                    Else
                                        ' Exit Sub

                                    End If
                                Else
                                    'If checkDGVConflict() = True Then
                                    '    Dim ans2 As MsgBoxResult
                                    '    ans2 = MsgBox("The schedule Is conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    '    If ans2 = MsgBoxResult.Yes Then
                                    '        'dgvSchedule.Rows.Add(0, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Pending")
                                    '        str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                    '                & "VALUES('" & MySqlHelper.EscapeString(row.Cells(3).Value.ToString) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                    '                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                                    '        str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                    '              & "VALUES('" & MySqlHelper.EscapeString(.Idvenue) & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                    '        str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule));"
                                    '        pend = 1
                                    '    Else
                                    '        'Exit Sub
                                    '    End If
                                    'Else
                                    'dgvSchedule.Rows.Add(0, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Approved")
                                    '_event_Stat = 1
                                    str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                                & "VALUES('" & MySqlHelper.EscapeString(row.Cells(3).Value.ToString) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                                    str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                            & "VALUES('" & row.Cells(1).Value.ToString & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                    str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule));"
                                    ' End If
                                End If
                            Next
                        ElseIf _prio = "FALSE" Then

                            For Each row As DataGridViewRow In dgvSchedule.Rows
                                If .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, cboVenue.Text, .Academic_year_idacademic_year, "", "TRUE") = True Then

                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    If ans1 = MsgBoxResult.Yes Then
                                        'dgvSchedule.Rows.Add(.Idschedule, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Approved")
                                        '_prio_Stat = 1
                                        str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                       & "VALUES('" & row.Cells(1).Value.ToString & "','" & MySqlHelper.EscapeString(.Idschedule) & "',CURRENT_DATE);"
                                        str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),'" & MySqlHelper.EscapeString(.Idschedule) & "');"
                                        'update the other event to pending
                                        'get all event id then update
                                    Else
                                        'Exit Sub
                                    End If

                                ElseIf .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    If ans1 = MsgBoxResult.Yes Then
                                        ' dgvSchedule.Rows.Add(.Idschedule, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Pending")
                                        str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                       & "VALUES('" & row.Cells(1).Value.ToString & "','" & MySqlHelper.EscapeString(.Idschedule) & "',CURRENT_DATE);"
                                        str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),'" & MySqlHelper.EscapeString(.Idschedule) & "');"
                                        pend = 1
                                    Else
                                        'Exit Sub
                                    End If
                                Else
                                    'If checkDGVConflict() = True Then
                                    '    Dim ans2 As MsgBoxResult
                                    '    ans2 = MsgBox("The schedule Is conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    '    If ans2 = MsgBoxResult.Yes Then
                                    '        'dgvSchedule.Rows.Add(0, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Pending")
                                    '        str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                    '                & "VALUES('" & MySqlHelper.EscapeString(row.Cells(3).Value.ToString) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                    '                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                                    '        str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                    '              & "VALUES('" & MySqlHelper.EscapeString(.Idvenue) & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                    '        str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule));"
                                    '        pend = 1
                                    '    Else
                                    '        'Exit Sub
                                    '    End If
                                    'Else
                                    'dgvSchedule.Rows.Add(0, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Approved")
                                    '_event_Stat = 1
                                    str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                                & "VALUES('" & MySqlHelper.EscapeString(row.Cells(3).Value.ToString) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                                    str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                            & "VALUES('" & row.Cells(1).Value.ToString & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                    str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule));"
                                    ' End If
                                End If
                            Next
                        Else
                            For Each row As DataGridViewRow In dgvSchedule.Rows
                                'If checkDGVConflict() = True Then
                                '    Dim ans2 As MsgBoxResult
                                '    ans2 = MsgBox("The schedule Is conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                '    If ans2 = MsgBoxResult.Yes Then
                                '        'dgvSchedule.Rows.Add(0, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Pending")
                                '        str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                '                & "VALUES('" & MySqlHelper.EscapeString(row.Cells(3).Value.ToString) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                '                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                                '        str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                '              & "VALUES('" & MySqlHelper.EscapeString(.Idvenue) & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                '        str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule));"
                                '        pend = 1
                                '    Else
                                '        'Exit Sub
                                '    End If
                                'Else
                                'dgvSchedule.Rows.Add(0, IDVenue, cboVenue.Text, cboStartTime.Text, cboEndTime.Text, "Approved")
                                '_event_Stat = 1
                                str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                            & "VALUES('" & MySqlHelper.EscapeString(row.Cells(3).Value.ToString) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                            & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                        & "VALUES('" & row.Cells(1).Value.ToString & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule));"
                                ' End If
                            Next
                        End If
                        For Each row As DataGridViewRow In dgvDept.Rows
                            If row.Cells(0).Value.ToString = True Then
                                str += "INSERT INTO department_has_event(department_iddepartment,event_idevent,department_has_event_reg_date) VALUES('" & row.Cells(1).Value.ToString & "'," _
                                & "(SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),CURRENT_DATE);"
                            Else
                                ' Exit Sub
                            End If
                        Next
                        ' If pend = 1 Then
                        .Event_status = txtStatus.Text
                            .Event_unit = frmHome.lblUnit.Text
                            If .AddEvent(str) = True Then
                                MsgBox("New Event has been saved")
                                txtBudget.Clear()
                                txtCode.Clear()
                                txtGoal.Clear()
                                txtNumberOfParticipants.Clear()
                                txtStatus.Clear()
                                txtTitleOfActivity.Clear()
                                cboCollege.SelectedIndex = -1
                                cboEndTime.SelectedIndex = -1
                                cboStartTime.SelectedIndex = -1
                                dgvDept.Rows.Clear()
                                dgvPA.Rows.Clear()
                                tcActivityInfo.Enabled = False
                                tcActivitySchedule.Enabled = False
                                'tcSearch.Enabled = True
                                btnNew.Enabled = True
                                btnSave.Enabled = False
                                'btnEdit.Enabled = False
                                btnShowRecords.Enabled = True
                                btnCancel.Enabled = True
                                _acad_year_obj = New AcademicYearClass
                                With _acad_year_obj
                                    .getActiveAY()
                                    dtpDate.MinDate = Convert.ToDateTime(.Academic_year_start)
                                    dtpDate.MaxDate = Convert.ToDateTime(.Academic_year_end)
                                End With
                            Else
                                MsgBox("New Event has not been saved")
                            End If

                            ' End If
                        Else
                        MessageBox.Show("All fields required")
                    End If
                ElseIf _flag.Equals("Edit") Then
                        MsgBox(1)
                    Else
                        MsgBox(2)
                    ' Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

  

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmShowRecords.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            _acad_year_obj = New AcademicYearClass
            If _flag = "New" Then
                txtBudget.Clear()
                txtCode.Clear()
                txtGoal.Clear()
                txtNumberOfParticipants.Clear()
                txtStatus.Clear()
                txtTitleOfActivity.Clear()
                cboCollege.SelectedIndex = -1
                cboEndTime.SelectedIndex = -1
                cboStartTime.SelectedIndex = -1
                dgvDept.Rows.Clear()
                dgvPA.Rows.Clear()
                tcActivityInfo.Enabled = False
                tcActivitySchedule.Enabled = False
                'tcSearch.Enabled = True
                btnNew.Enabled = True
                btnSave.Enabled = False
                'btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                _acad_year_obj = New AcademicYearClass
                With _acad_year_obj
                    .getActiveAY()
                    dtpDate.MinDate = Convert.ToDateTime(.Academic_year_start)
                    dtpDate.MaxDate = Convert.ToDateTime(.Academic_year_end)
                End With
            Else
                Dispose()
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            _acad_year_obj = New AcademicYearClass
            _event_obj = New EventClass
            With _acad_year_obj
                .getActiveAY()
                '   txtCode.Text = String.Format("{0}-{1}-{2}-{3}", "R", Year(.Academic_year_start), Year(.Academic_year_end), generateRandom())
                LoadTimeToCbo(cboStartTime)
                LoadTimeToCbo(cboEndTime)
                LoadVenueToCbo(cboVenue)
                _event_obj.LoadPartnerAgencyCheck(dgvPA, 0)
                dtpDate.MinDate = Convert.ToDateTime(.Academic_year_start)
                dtpDate.MaxDate = Convert.ToDateTime(.Academic_year_end)
                '  _event_obj.LoadHoliday()
                tcActivityInfo.Enabled = True
                tcActivitySchedule.Enabled = True
                '  tcSearch.Enabled = False
                btnNew.Enabled = False
                btnSave.Enabled = True
                'btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                LoadCollegeToCbo(cboCollege)
                _flag = "New"
                txtStatus.Text = "Approved"
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub chkPriority_CheckedChanged(sender As Object, e As EventArgs) Handles chkPriority.CheckedChanged
        If chkPriority.Checked = True Then
            _prio = "TRUE"
        Else
            _prio = "FALSE"
        End If
    End Sub

    Private Sub cboCollege_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCollege.SelectedIndexChanged
        Try
            _college_obj = New CollegeClass
            With _college_obj
                .getIDCollege(cboCollege.Text)
                idC = .Idcollege
                .LoadDeptByCollegeEvents(dgvDept, .Idcollege)
                LinkLabel3.Enabled = True
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Try
            'here detect holidays.
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _venue = New VenueClass
            Dim dtp As Date = New Date(1754, dtpDate.Value.Month, dtpDate.Value.Day)
            _event_obj.LoadHoliday(dtp.ToString("yyyy-MM-dd"))

            With _event_obj

                Dim x As Date = New Date(dtpDate.Value.Year, _event_obj.Holiday_date.Month, _event_obj.Holiday_date.Day)
                Dim y As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, dtpDate.Value.Day)
                _acad_year_obj.getActiveAY()
                .Academic_year_idacademic_year = _acad_year_obj.Idacademic_year
                If _event_Stat = 1 Then
                    txtStatus.Text = "APPROVED"
                Else
                    txtStatus.Text = "PENDING"
                End If
                If cboStartTime.Text <> Nothing And cboEndTime.Text <> Nothing And cboVenue.Text <> Nothing Then
                    If Convert.ToDateTime(cboStartTime.Text) > Convert.ToDateTime(cboEndTime.Text) Then
                        MsgBox("Start time must be less than End time.")
                        Exit Sub
                    ElseIf Convert.ToDateTime(cboStartTime.Text) = Convert.ToDateTime(cboEndTime.Text) Then
                        MsgBox("Start time cannot be equal to End time.")
                        Exit Sub
                    Else
                        If y = x Then
                            Dim ans As MsgBoxResult
                            ans = MessageBox.Show("This date Is a holiday." + vbCrLf + "Are you sure you want to schedule this event?", "Holiday", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If ans = MsgBoxResult.Yes Then

                                If .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, cboVenue.Text, .Academic_year_idacademic_year, "", "TRUE") = True Then
                                    If _prio = "TRUE" Then
                                        Dim ans1 As MsgBoxResult
                                        ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans1 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Pending")
                                            _prio_Stat = 1
                                            'update the other event to pending
                                            'get all event id then update
                                        Else
                                            Exit Sub
                                        End If
                                    ElseIf _prio = "FALSE" Then
                                        Dim ans1 As MsgBoxResult
                                        ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans1 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Approved")
                                            _prio_Stat = 1
                                            'update the other event to pending
                                            'get all event id then update
                                        Else
                                            Exit Sub
                                        End If
                                    End If


                                ElseIf .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                    If _prio = "TRUE" Then
                                        Dim ans1 As MsgBoxResult
                                        ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans1 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Approved")
                                            _prio_Stat = 1
                                            'update the other event to pending
                                            'get all event id then update
                                        Else
                                            Exit Sub
                                        End If
                                    ElseIf _prio = "FALSE" Then
                                        Dim ans1 As MsgBoxResult
                                        ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans1 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Pending")
                                        Else
                                            Exit Sub
                                        End If
                                    End If

                                Else
                                    If checkDGVConflict() = True Then
                                        Dim ans2 As MsgBoxResult
                                        ans2 = MsgBox("The schedule Is conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans2 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Pending")
                                        Else
                                            Exit Sub
                                        End If
                                    Else
                                        dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Approved")
                                        _event_Stat = 1
                                        If _event_Stat = 1 Then
                                            txtStatus.Text = "APPROVED"
                                        Else
                                            txtStatus.Text = "PENDING"
                                        End If
                                    End If

                                End If


                            Else
                                'do nothing
                                Exit Sub
                            End If
                        Else
                            If .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, cboVenue.Text, .Academic_year_idacademic_year, "", "TRUE") = True Then
                                If _prio = "TRUE" Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    If ans1 = MsgBoxResult.Yes Then
                                        dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Pending")
                                        _prio_Stat = 1
                                        'update the other event to pending
                                        'get all event id then update
                                    Else
                                        Exit Sub
                                    End If
                                ElseIf _prio = "FALSE" Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    If ans1 = MsgBoxResult.Yes Then
                                        dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Approved")
                                        _prio_Stat = 1
                                        'update the other event to pending
                                        'get all event id then update
                                    Else
                                        Exit Sub
                                    End If
                                End If


                            ElseIf .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                If _prio = "TRUE" Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    If ans1 = MsgBoxResult.Yes Then
                                        dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Approved")
                                        _prio_Stat = 1
                                        'update the other event to pending
                                        'get all event id then update
                                    Else
                                        Exit Sub
                                    End If
                                ElseIf _prio = "FALSE" Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule Is conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    If ans1 = MsgBoxResult.Yes Then
                                        dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Pending")
                                    Else
                                        Exit Sub
                                    End If
                                End If

                            Else
                                If checkDGVConflict() = True Then
                                    Dim ans2 As MsgBoxResult
                                    ans2 = MsgBox("The schedule Is conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                    If ans2 = MsgBoxResult.Yes Then
                                        dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Pending")
                                    Else
                                        Exit Sub
                                    End If
                                Else
                                    dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), cboStartTime.Text, cboEndTime.Text, "Approved")
                                    _event_Stat = 1
                                    If _event_Stat = 1 Then
                                        txtStatus.Text = "APPROVED"
                                    Else
                                        txtStatus.Text = "PENDING"
                                    End If
                                End If

                            End If
                        End If

                    End If

                Else
                    MessageBox.Show("All fields required")
                    Exit Sub
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub dgvSchedule_RowPrePaint(sender As Object, e As DataGridViewRowPrePaintEventArgs) Handles dgvSchedule.RowPrePaint
        Try
            If dgvSchedule.Rows(e.RowIndex).Cells(5).Value.ToString = "Pending" Then
                dgvSchedule.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Purple
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvSchedule_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvSchedule.RowsAdded
        Try
            If dgvSchedule.Rows(e.RowIndex).Cells(5).Value.ToString = "Pending" Then
                dgvSchedule.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.Purple
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function checkDGVConflict() As Boolean
        Dim bool As Boolean = False
        Try
            For Each row As DataGridViewRow In dgvSchedule.Rows
                If row.Cells(3).Value = dtpDate.Value.ToString("yyyy-MM-dd") _
                    And Convert.ToDateTime(row.Cells(4).Value).ToString("HH:mm") < Convert.ToDateTime(cboEndTime.Text).ToString("HH:mm") _
                    And Convert.ToDateTime(row.Cells(5).Value).ToString("HH:mm") > Convert.ToDateTime(cboStartTime.Text).ToString("HH:mm") Then
                    bool = True
                    Exit For
                Else
                    bool = False
                End If
            Next
        Catch ex As Exception
            Return False
        End Try
        Return bool
    End Function

    Private Sub dgvDept_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDept.CellContentClick
        Try

            ch1 = DirectCast(dgvDept.Rows(dgvDept.CurrentRow.Index).Cells(0), DataGridViewCheckBoxCell)

            If ch1.Value Is Nothing Then
                ch1.Value = False
            End If
            Select Case ch1.Value.ToString()
                Case "True"
                    ch1.Value = False
                    myList.Add(dgvPA.Rows(dgvPA.CurrentRow.Index).Cells(2).Value.ToString)
                    Exit Select
                Case "False"
                    ch1.Value = True
                    Exit Select
            End Select



        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvPA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPA.CellContentClick
        Try
            ch1 = DirectCast(dgvPA.Rows(dgvPA.CurrentRow.Index).Cells(0), DataGridViewCheckBoxCell)

            If ch1.Value Is Nothing Then
                ch1.Value = False
            End If
            Select Case ch1.Value.ToString()
                Case "True"
                    ch1.Value = False
                    myList.Add(dgvPA.SelectedRows(0).Cells(2).Value.ToString)
                    Exit Select
                Case "False"
                    ch1.Value = True
                    myList.Remove(dgvPA.SelectedRows(0).Cells(2).Value.ToString)
                    Exit Select
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub cboVenue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboVenue.SelectedIndexChanged

    End Sub

    Private Sub txtNumberOfParticipants_TextChanged(sender As Object, e As EventArgs) Handles txtNumberOfParticipants.TextChanged
        keyAllow(keyNum, txtNumberOfParticipants)
    End Sub

    Private Sub txtBudget_TextChanged(sender As Object, e As EventArgs) Handles txtBudget.TextChanged
        keyAllow(keyNum, txtBudget)
    End Sub

    Private Sub frmManageEvents_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            _acad_year_obj = New AcademicYearClass
            If _flag = "New" Then
                Dispose()
            Else
                Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            frmpartneragencies.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            frmaddcollege.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Try
            frmadddept.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Try
            frmsavevenue.ShowDialog()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvSchedule_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvSchedule.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvDept.Rows(e.RowIndex).Selected = True
                dgvDept.CurrentCell = dgvDept.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvDept.SelectedRows.Count = 1 Then

                    ''  If dgvAY.SelectedRows(0).Cells(2).Value.ToString = "CLOSE" Then
                    ContextMenuStrip1.Show(dgvDept, e.Location)
                    ContextMenuStrip1.Show(Cursor.Position)
                    'Else
                    'Exit Sub
                    'End If

                End If
            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            dgvDept.Rows.Remove(dgvDept.SelectedRows(0))
        Catch ex As Exception

        End Try
    End Sub
End Class