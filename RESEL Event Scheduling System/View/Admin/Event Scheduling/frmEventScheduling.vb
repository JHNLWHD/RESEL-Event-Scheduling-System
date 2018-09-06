Imports MySql.Data.MySqlClient
Imports System.Globalization
Public Class frmEventScheduling

    Public _flag As String = ""
    Public _acad_year_obj As AcademicYearClass
    Public _event_obj As EventClass
    Public _college_obj As New CollegeClass
    Public _venue As VenueClass
    Public _acc As AccountClass
    Dim _prio As String = "Non-Priority"
    Public str As String = ""
    Public strpa As String = ""
    Public strStartTime As String = ""
    Public strEndTime As String = ""
    Public _event_Stat As Integer = 0
    Public _prio_Stat As Integer = 0
    'IF 0 then APPROVED ELSE PENDING
    Dim myList As New List(Of String)()
    Dim keyNum As String = "0987654321"
    Public Shared idC As Integer = 0
    Private _dsEvent As New DataSet

    Private Sub frmEventScheduling_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _acad_year_obj = New AcademicYearClass
            _event_obj = New EventClass
            _college_obj = New CollegeClass
            _acc = New AccountClass
            With _acad_year_obj
                .getActiveAY()
                dtpDate.MinDate = New Date(Convert.ToDateTime(getDate()).ToString("yyyy"), Convert.ToDateTime(getDate()).ToString("MM"), Convert.ToDateTime(getDate()).ToString("dd"))
                dtpDate2.MinDate = New Date(Convert.ToDateTime(getDate()).ToString("yyyy"), Convert.ToDateTime(getDate()).ToString("MM"), Convert.ToDateTime(getDate()).ToString("dd"))
                If .Date_settings_end = 1 Or .Date_settings_end = 3 Or .Date_settings_end = 5 Or .Date_settings_end = 7 Or .Date_settings_end = 8 Or .Date_settings_end = 10 Or .Date_settings_end = 12 Then
                    dtpDate.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 31)
                    dtpDate2.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 31)
                ElseIf .Date_settings_end = 4 Or .Date_settings_end = 6 Or .Date_settings_end = 9 Or .Date_settings_end = 11 Then
                    dtpDate.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 30)
                    dtpDate2.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 30)
                ElseIf .Academic_year_end Mod 4 = 0 Then
                    dtpDate.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 29)
                    dtpDate2.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 29)
                ElseIf .Academic_year_end Mod 4 <> 0 Then
                    dtpDate.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 28)
                    dtpDate2.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 28)
                End If
                LoadVenueToCbo(cboVenue)
                _college_obj.LoadCollegeToSched(dgvCollege)
                _event_obj.LoadPartnerAgencyCheck(dgvPA, 0)
                _acc.LoadUnitRecordsToSched(dgvUnit)
                txtCode.Text = String.Format("{0}-{1}-{2}-{3}", "R", .Academic_year_start, .Academic_year_end, generateRandom())
                txtStatus.Text = "Incoming"
                If chkPriority.Checked = True Then
                    _prio = "Priority"
                Else
                    _prio = "Non-Priority"
                End If
            End With
        Catch ex As Exception

            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvPA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPA.CellContentClick
        Try
            If e.ColumnIndex = 0 Then
                If dgvPA.SelectedRows(0).Cells(0).Value = False Then
                    dgvPA.SelectedRows(0).Cells(0).Value = True
                Else
                    dgvPA.SelectedRows(0).Cells(0).Value = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub dgvCollege_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCollege.CellContentClick
        Try
            If e.ColumnIndex = 0 Then

                dgvDept.Rows.Clear()
                If dgvCollege.SelectedRows(0).Cells(0).Value = False Then
                    dgvCollege.SelectedRows(0).Cells(0).Value = True
                Else
                    dgvCollege.SelectedRows(0).Cells(0).Value = False
                End If
                For Each row As DataGridViewRow In dgvCollege.Rows
                    If row.Cells(0).Value = True Then
                        _college_obj.LoadDeptByCollegeEvents(dgvDept, row.Cells(1).Value)
                    End If
                Next
            End If
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub chkPriority_CheckedChanged(sender As Object, e As EventArgs) Handles chkPriority.CheckedChanged
        Try
            If chkPriority.Checked = True Then
                _prio = "Priority"
            Else
                _prio = "Non-Priority"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        Try
            'here detect holidays.
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _venue = New VenueClass
            Dim dtp As Date = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
            _event_obj.LoadHoliday(dtp.ToString("yyyy-MM-dd"))
            ' MsgBox(_event_obj.Holiday_date)
            With _event_obj
                _acad_year_obj.getActiveAY()
                .Academic_year_idacademic_year = _acad_year_obj.Idacademic_year
                If _event_Stat = 1 Then
                    txtStatus.Text = "Incoming"
                Else
                    txtStatus.Text = "Pending"
                End If
                If dtpStartTime.Value.ToString("hh:mm tt") <> Nothing And dtpEndTime.Value.ToString("hh:mm tt") <> Nothing And cboVenue.Text <> Nothing Then
                    If Convert.ToDateTime(dtpStartTime.Value).ToString("HH:mm") > Convert.ToDateTime(dtpEndTime.Value).ToString("HH:mm") Then
                        MsgBox("Start time must be less than End time.")
                        Exit Sub
                    ElseIf Convert.ToDateTime(dtpStartTime.Value).ToString("HH:mm") = Convert.ToDateTime(dtpEndTime.Value).ToString("HH:mm") Then
                        MsgBox("Start time cannot be equal to End time.")
                        Exit Sub


                    Else
                        If chkNormal.Checked = True Then
                            Dim startDate As Date = dtpDate.Value
                            Dim endDate As Date = dtpDate2.Value
                            If startDate <> endDate Then
                                If dtpDate.Value > dtpDate2.Value Then
                                    MsgBox("Start date cannot be greater than End date.")
                                    Exit Sub
                                Else
                                    While startDate.ToString("yyyy-MM-dd") <= endDate.ToString("yyyy-MM-dd")
                                        ''MsgBox(startDate)
                                        'MsgBox(startDate.ToString("yyyy-MM-dd"))
                                        If .Holiday_date.ToString("yyyy-MM-dd") = startDate.ToString("yyyy-MM-dd") Then
                                            Dim ans As MsgBoxResult
                                            ans = MessageBox.Show("This date is in a holiday." + vbCrLf + "Are you sure you want to schedule this event?", "Holiday", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                            If ans = MsgBoxResult.Yes Then

                                                If .isScheduleConflict(startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "TRUE") = True Then
                                                    If _prio = "Priority" Then
                                                        Dim ans1 As MsgBoxResult
                                                        ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                        If ans1 = MsgBoxResult.Yes Then
                                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")

                                                            _prio_Stat = 1

                                                            startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                            'MsgBox(startDate)
                                                            'update the other event to pending
                                                            'get all event id then update
                                                        Else
                                                            startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                            'MsgBox(startDate)
                                                        End If
                                                    ElseIf _prio = "Non-Priority" Then
                                                        Dim ans1 As MsgBoxResult
                                                        ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                        If ans1 = MsgBoxResult.Yes Then
                                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                            _prio_Stat = 1
                                                            startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                            'MsgBox(startDate)
                                                            'update the other event to pending
                                                            'get all event id then update
                                                        Else
                                                            startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                            'MsgBox(startDate)
                                                        End If
                                                    End If


                                                ElseIf .isScheduleConflict(startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                                    If _prio = "Priority" Then
                                                        dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                        _event_Stat = 1
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                        If _event_Stat = 1 Then
                                                            txtStatus.Text = "Incoming"
                                                        Else
                                                            txtStatus.Text = "Pending"
                                                        End If
                                                        'Dim ans1 As MsgBoxResult
                                                        'ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                        'If ans1 = MsgBoxResult.Yes Then
                                                        '    dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                        '    _prio_Stat = 1
                                                        '    startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        '    'MsgBox(startDate)
                                                        '    'update the other event to pending
                                                        '    'get all event id then update
                                                        'Else
                                                        '    startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        '    'MsgBox(startDate)
                                                        'End If
                                                    ElseIf _prio = "Non-Priority" Then
                                                        Dim ans1 As MsgBoxResult
                                                        ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                        If ans1 = MsgBoxResult.Yes Then
                                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                                            startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                            'MsgBox(startDate)
                                                        Else
                                                            startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                            'MsgBox(startDate)
                                                        End If
                                                    End If

                                                Else
                                                    If checkDGVConflict(startDate.ToString("yyyy-MM-dd")) = True Then
                                                        Dim ans2 As MsgBoxResult
                                                        ans2 = MsgBox("The schedule is in conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                        If ans2 = MsgBoxResult.Yes Then
                                                            dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                                            startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                            'MsgBox(startDate)
                                                        Else
                                                            startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                            'MsgBox(startDate)
                                                        End If
                                                    Else
                                                        dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                        _event_Stat = 1
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                        If _event_Stat = 1 Then
                                                            txtStatus.Text = "Incoming"
                                                        Else
                                                            txtStatus.Text = "Pending"
                                                        End If
                                                    End If

                                                End If


                                            Else
                                                'do nothing
                                                startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                'MsgBox(startDate)
                                            End If
                                        Else
                                            If .isScheduleConflict(startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "TRUE") = True Then
                                                If _prio = "Priority" Then
                                                    Dim ans1 As MsgBoxResult
                                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                    If ans1 = MsgBoxResult.Yes Then
                                                        dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                                        _prio_Stat = 1
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                        'update the other event to pending
                                                        'get all event id then update
                                                    Else
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                    End If
                                                ElseIf _prio = "Non-Priority" Then
                                                    Dim ans1 As MsgBoxResult
                                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                    If ans1 = MsgBoxResult.Yes Then
                                                        dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                        _prio_Stat = 1
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                        'update the other event to pending
                                                        'get all event id then update
                                                    Else
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                    End If
                                                End If


                                            ElseIf .isScheduleConflict(startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                                If _prio = "Priority" Then
                                                    dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                    _event_Stat = 1
                                                    startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                    'MsgBox(startDate)

                                                    If _event_Stat = 1 Then
                                                        txtStatus.Text = "Incoming"
                                                    Else
                                                        txtStatus.Text = "Pending"
                                                    End If
                                                    'Dim ans1 As MsgBoxResult
                                                    'ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                    'If ans1 = MsgBoxResult.Yes Then
                                                    '    dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                    '    _prio_Stat = 1
                                                    '    startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                    '    'MsgBox(startDate)
                                                    '    'update the other event to pending
                                                    '    'get all event id then update
                                                    'Else
                                                    '    Exit Sub
                                                    'End If
                                                ElseIf _prio = "Non-Priority" Then
                                                    Dim ans1 As MsgBoxResult
                                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                    If ans1 = MsgBoxResult.Yes Then
                                                        dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                    Else
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                    End If
                                                End If

                                            Else
                                                If checkDGVConflict(startDate.ToString("yyyy-MM-dd")) = True Then
                                                    Dim ans2 As MsgBoxResult
                                                    ans2 = MsgBox("The schedule is in conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                                    If ans2 = MsgBoxResult.Yes Then
                                                        dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                    Else
                                                        startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                        'MsgBox(startDate)
                                                    End If
                                                Else
                                                    dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                    _event_Stat = 1
                                                    startDate = startDate.AddDays(1).ToString("yyyy-MM-dd")
                                                    'MsgBox(startDate)

                                                    If _event_Stat = 1 Then
                                                        txtStatus.Text = "Incoming"
                                                    Else
                                                        txtStatus.Text = "Pending"
                                                    End If
                                                End If

                                            End If
                                        End If
                                        'startDate.AddDays(1).ToString("yyyy-MM-dd")
                                        'MsgBox(startDate)
                                    End While
                                End If

                            Else
                                GoTo abnormal
                            End If

                        Else
abnormal:
                            'MsgBox(.Holiday_date)
                            If .Holiday_date.ToString("yyyy-MM-dd") = dtp.ToString("yyyy-MM-dd") Then
                                Dim ans As MsgBoxResult
                                ans = MessageBox.Show("This date is in a holiday." + vbCrLf + "Are you sure you want to schedule this event?", "Holiday", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                If ans = MsgBoxResult.Yes Then

                                    If .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "TRUE") = True Then
                                        If _prio = "Priority" Then
                                            Dim ans1 As MsgBoxResult
                                            ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                            If ans1 = MsgBoxResult.Yes Then
                                                dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                                _prio_Stat = 1
                                                'update the other event to pending
                                                'get all event id then update
                                            Else
                                                Exit Sub
                                            End If
                                        ElseIf _prio = "Non-Priority" Then
                                            Dim ans1 As MsgBoxResult
                                            ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                            If ans1 = MsgBoxResult.Yes Then
                                                dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                                _prio_Stat = 1
                                                'update the other event to pending
                                                'get all event id then update
                                            Else
                                                Exit Sub
                                            End If
                                        End If


                                    ElseIf .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                        If _prio = "Priority" Then
                                            dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                            _event_Stat = 1
                                            If _event_Stat = 1 Then
                                                txtStatus.Text = "Incoming"
                                            Else
                                                txtStatus.Text = "Pending"
                                            End If
                                            'Dim ans1 As MsgBoxResult
                                            'ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                            'If ans1 = MsgBoxResult.Yes Then
                                            '    dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                            '    _prio_Stat = 1
                                            '    'update the other event to pending
                                            '    'get all event id then update
                                            'Else
                                            '    Exit Sub
                                            'End If
                                        ElseIf _prio = "Non-Priority" Then
                                            Dim ans1 As MsgBoxResult
                                            ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                            If ans1 = MsgBoxResult.Yes Then
                                                dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                            Else
                                                Exit Sub
                                            End If
                                        End If

                                    Else
                                        If checkDGVConflict(dtpDate.Value.ToString("yyyy-MM-dd")) = True Then
                                            Dim ans2 As MsgBoxResult
                                            ans2 = MsgBox("The schedule is in conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                            If ans2 = MsgBoxResult.Yes Then
                                                dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                            Else
                                                Exit Sub
                                            End If
                                        Else
                                            dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                            _event_Stat = 1
                                            If _event_Stat = 1 Then
                                                txtStatus.Text = "Incoming"
                                            Else
                                                txtStatus.Text = "Pending"
                                            End If
                                        End If

                                    End If


                                Else
                                    'do nothing
                                    Exit Sub
                                End If
                            Else
                                If .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "TRUE") = True Then
                                    If _prio = "Priority" Then
                                        Dim ans1 As MsgBoxResult
                                        ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans1 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                            _prio_Stat = 1
                                            'update the other event to pending
                                            'get all event id then update
                                        Else
                                            Exit Sub
                                        End If

                                    ElseIf _prio = "Non-Priority" Then
                                        Dim ans1 As MsgBoxResult
                                        ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans1 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                            _prio_Stat = 1
                                            'update the other event to pending
                                            'get all event id then update
                                        Else
                                            Exit Sub
                                        End If
                                    End If


                                ElseIf .isScheduleConflict(dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                    If _prio = "Priority" Then
                                        dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                        _event_Stat = 1
                                        If _event_Stat = 1 Then
                                            txtStatus.Text = "Incoming"
                                        Else
                                            txtStatus.Text = "Pending"
                                        End If
                                        'Dim ans1 As MsgBoxResult
                                        'ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        'If ans1 = MsgBoxResult.Yes Then
                                        '    dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                        '    _prio_Stat = 1
                                        '    'update the other event to pending
                                        '    'get all event id then update
                                        'Else
                                        '    Exit Sub
                                        'End If
                                    ElseIf _prio = "Non-Priority" Then
                                        Dim ans1 As MsgBoxResult
                                        ans1 = MsgBox("The schedule is in conflict with " + .Event_name + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans1 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(.Idschedule, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                        Else
                                            Exit Sub
                                        End If
                                    End If

                                Else
                                    If checkDGVConflict(dtpDate.Value.ToString("yyyy-MM-dd")) = True Then
                                        Dim ans2 As MsgBoxResult
                                        ans2 = MsgBox("The schedule is in conflict with some events." + vbCrLf + "Are you sure you want to schedule this event?", MsgBoxStyle.YesNo, "Manage Event")
                                        If ans2 = MsgBoxResult.Yes Then
                                            dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                        Else
                                            Exit Sub
                                        End If
                                    Else
                                        dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Approved")
                                        _event_Stat = 1
                                        If _event_Stat = 1 Then
                                            txtStatus.Text = "Incoming"
                                        Else
                                            txtStatus.Text = "Pending"
                                        End If
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
            ' MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub chkNormal_CheckedChanged(sender As Object, e As EventArgs) Handles chkNormal.CheckedChanged
        Try
            If chkNormal.Checked = True Then
                dtpDate2.Enabled = True
            Else
                dtpDate2.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function checkDGVConflict(str As String) As Boolean
        Dim bool As Boolean = False
        Try
            '  MsgBox(str)
            For Each row As DataGridViewRow In dgvSchedule.Rows
                If row.Cells(3).Value = str _
                    And Convert.ToDateTime(row.Cells(4).Value).ToString("HH:mm") < Convert.ToDateTime(dtpEndTime.Value).ToString("HH:mm") _
                    And Convert.ToDateTime(row.Cells(5).Value).ToString("HH:mm") > Convert.ToDateTime(dtpStartTime.Value).ToString("HH:mm") Then
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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim pend As Integer = 0
            Dim sched_check, dept_unit_check, pa_check As Integer
            sched_check = 0
            dept_unit_check = 0
            pa_check = 0
            _acad_year_obj = New AcademicYearClass
            _event_obj = New EventClass
            With _event_obj
                '  If _flag = "New" Then
                If RequiredField(txtCode.Text, txtTitleOfActivity.Text, txtBudget.Text, txtGoal.Text, txtType.Text, txtNumberOfParticipants.Text) = True Then
                    .Academic_year_idacademic_year = _acad_year_obj.Idacademic_year
                    .Event_code = txtCode.Text
                    If _prio = "Priority" Then
                        For Each row As DataGridViewRow In dgvSchedule.Rows

                            Dim _date As DateTime = DateTime.ParseExact(row.Cells(3).Value.ToString, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                            Dim date_str As String = _date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)


                            If .isScheduleConflict(date_str, row.Cells(4).Value.ToString, row.Cells(5).Value.ToString, row.Cells(2).Value.ToString, .Academic_year_idacademic_year.ToString, "", "TRUE") = True Then
                                For Each rowP As DataRow In _dsEvent.Tables(0).Rows
                                    .Ideveent = rowP("idevent")
                                    str += "UPDATE event SET event_status = '" & MySqlHelper.EscapeString("Pending") & "' WHERE idevent = '" & .Ideveent & "';"
                                Next
                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                        & "VALUES('" & row.Cells(1).Value.ToString & "','" & MySqlHelper.EscapeString(.Idschedule) & "',CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),'" & MySqlHelper.EscapeString(.Idschedule) & "','" & MySqlHelper.EscapeString(.Event_status) & "');"
                                pend = 1
                                sched_check = 1
                            ElseIf .isScheduleConflict(date_str, row.Cells(4).Value.ToString, row.Cells(5).Value.ToString, row.Cells(2).Value.ToString, .Academic_year_idacademic_year.ToString, "", "FALSE") = True Then
                                For Each rowP As DataRow In _dsEvent.Tables(0).Rows
                                    .Ideveent = rowP("idevent")
                                    str += "UPDATE event SET event_status = '" & MySqlHelper.EscapeString("Pending") & "' WHERE idevent = '" & .Ideveent & "';"
                                Next
                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                       & "VALUES('" & row.Cells(1).Value.ToString & "','" & MySqlHelper.EscapeString(.Idschedule) & "',CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),'" & MySqlHelper.EscapeString(.Idschedule) & "','" & MySqlHelper.EscapeString(.Event_status) & "');"
                                'update the other event to pending
                                'get all event id then update
                                sched_check = 1
                            Else

                                str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                                & "VALUES('" & MySqlHelper.EscapeString(date_str) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                        & "VALUES('" & row.Cells(1).Value.ToString & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule),'" & MySqlHelper.EscapeString(.Event_status) & "');"
                                sched_check = 1
                            End If
                        Next
                    ElseIf _prio = "Non-Priority" Then

                        For Each row As DataGridViewRow In dgvSchedule.Rows

                            Dim _date As DateTime = DateTime.ParseExact(row.Cells(3).Value.ToString, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                            Dim date_str As String = _date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)

                            If .isScheduleConflict(date_str, row.Cells(4).Value.ToString, row.Cells(5).Value.ToString, row.Cells(2).Value.ToString, .Academic_year_idacademic_year, "", "TRUE") = True Then

                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                       & "VALUES('" & row.Cells(1).Value.ToString & "','" & MySqlHelper.EscapeString(.Idschedule) & "',CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),'" & MySqlHelper.EscapeString(.Idschedule) & "','" & MySqlHelper.EscapeString(.Event_status) & "');"
                                'update the other event to pending
                                'get all event id then update
                                sched_check = 1
                            ElseIf .isScheduleConflict(date_str, row.Cells(4).Value.ToString, row.Cells(5).Value.ToString, row.Cells(2).Value.ToString, .Academic_year_idacademic_year, "", "FALSE") = True Then
                                For Each rowP As DataRow In _dsEvent.Tables(0).Rows
                                    .Ideveent = rowP("idevent")
                                    str += "UPDATE event SET event_status = '" & MySqlHelper.EscapeString("Pending") & "' WHERE idevent = '" & .Ideveent & "';"
                                Next
                                ' dgvSchedule.Rows.Add(.Idschedule, IDVenue, cboVenue.Text, dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Pending")
                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                       & "VALUES('" & row.Cells(1).Value.ToString & "','" & MySqlHelper.EscapeString(.Idschedule) & "',CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),'" & MySqlHelper.EscapeString(.Idschedule) & "','" & MySqlHelper.EscapeString(.Event_status) & "');"
                                pend = 1
                                sched_check = 1
                            Else

                                str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                                & "VALUES('" & MySqlHelper.EscapeString(date_str) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                            & "VALUES('" & row.Cells(1).Value.ToString & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule),'" & MySqlHelper.EscapeString(.Event_status) & "');"
                                sched_check = 1
                            End If
                        Next
                    Else
                        For Each row As DataGridViewRow In dgvSchedule.Rows

                            Dim _date As DateTime = DateTime.ParseExact(row.Cells(3).Value.ToString, "yyyy-MM-dd", CultureInfo.InvariantCulture)
                            Dim date_str As String = _date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)

                            str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                            & "VALUES('" & MySqlHelper.EscapeString(date_str) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                            & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"
                            str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                        & "VALUES('" & row.Cells(1).Value.ToString & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                            str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule),'" & MySqlHelper.EscapeString(.Event_status) & "');"
                            sched_check = 1
                        Next
                    End If
                    For Each row As DataGridViewRow In dgvDept.Rows
                        If row.Cells(0).Value.ToString = True Then
                            str += "INSERT INTO department_has_event(department_iddepartment,event_idevent,department_has_event_reg_date) VALUES('" & row.Cells(1).Value.ToString & "'," _
                            & "(SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),CURRENT_DATE);"
                            dept_unit_check = 1
                        Else
                            ' Exit Sub
                        End If
                    Next

                    For Each row As DataGridViewRow In dgvPA.Rows
                        If row.Cells(0).Value.ToString = True Then
                            str += "INSERT INTO event_has_partner_agency(event_idevent,partner_agency_idpartner_agency) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "')," _
                            & "'" & row.Cells(1).Value.ToString & "');"
                            pa_check = 1
                        Else
                            ' Exit Sub
                        End If
                    Next

                    For Each row As DataGridViewRow In dgvUnit.Rows
                        If row.Cells(0).Value.ToString = True Then
                            str += "INSERT INTO event_has_unit(event_idevent,unit_idunit) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "')," _
                            & "'" & row.Cells(1).Value.ToString & "');"
                            dept_unit_check = 1
                        Else
                            ' Exit Sub
                        End If
                    Next
                    If sched_check = 1 And dept_unit_check = 1 Then
                        If pend = 1 Then
                            .Event_code = txtCode.Text
                            .Event_name = txtTitleOfActivity.Text
                            .Event_budget = txtBudget.Text
                            .Event_goal = txtGoal.Text
                            .Event_number_of_participants = Decimal.Parse(txtNumberOfParticipants.Text)
                            _acad_year_obj.getActiveAY()

                            .Event_priority = _prio
                            .Event_type = txtType.Text
                            .Event_remove_status = "FALSE"
                            .Event_is_cancel = "FALSE"
                            .Event_remarks = ""
                            .Account_idaccount = frmLogIn._user_id
                            .Event_status = "Pending"
                            .Event_unit = frmHome.lblUnit.Text
                            If .AddEvent(str) = True Then
                                MsgBox("New Event has been saved")
                                Dispose()
                                Close()
                                frmHome.tmrEvents_Tick(sender, e)
                            Else
                                MsgBox("New Event has not been saved")
                            End If
                        Else
                            .Event_code = txtCode.Text
                            .Event_name = txtTitleOfActivity.Text
                            .Event_budget = txtBudget.Text
                            .Event_goal = txtGoal.Text
                            .Event_number_of_participants = Decimal.Parse(txtNumberOfParticipants.Text)
                            _acad_year_obj.getActiveAY()
                            .Academic_year_idacademic_year = _acad_year_obj.Idacademic_year
                            .Event_priority = _prio
                            .Event_type = txtType.Text
                            .Event_remove_status = "FALSE"
                            .Event_is_cancel = "FALSE"
                            .Event_remarks = ""
                            .Account_idaccount = frmLogIn._user_id
                            .Event_status = "Incoming"
                            .Event_unit = frmHome.lblUnit.Text
                            If .AddEvent(str) = True Then
                                MsgBox("New Event has been saved")
                                Dispose()
                                Close()
                                frmHome.tmrEvents_Tick(sender, e)
                            Else
                                MsgBox("New Event has not been saved")
                            End If
                        End If
                    Else
                        GoTo AFR
                    End If



AFR:
                Else
                    MessageBox.Show("All fields required")
                End If

            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvSchedule_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvSchedule.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvSchedule.Rows(e.RowIndex).Selected = True
                dgvSchedule.CurrentCell = dgvSchedule.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvSchedule.SelectedRows.Count = 1 Then

                    cmRemove.Show(dgvSchedule, e.Location)
                    cmRemove.Show(Cursor.Position)

                End If
            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub RemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RemoveToolStripMenuItem.Click
        Try
            dgvSchedule.Rows.Remove(dgvSchedule.SelectedRows(0))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmEventScheduling_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dispose()
            Close()
            frmHome.tmrEvents_Tick(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvDept_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDept.CellContentClick
        Try
            If e.ColumnIndex = 0 Then

                If dgvDept.SelectedRows(0).Cells(0).Value = False Then
                    dgvDept.SelectedRows(0).Cells(0).Value = True
                Else
                    dgvDept.SelectedRows(0).Cells(0).Value = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvUnit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUnit.CellContentClick
        Try
            If e.ColumnIndex = 0 Then

                If dgvUnit.SelectedRows(0).Cells(0).Value = False Then
                    dgvUnit.SelectedRows(0).Cells(0).Value = True
                Else
                    dgvUnit.SelectedRows(0).Cells(0).Value = False
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtBudget_TextChanged(sender As Object, e As EventArgs) Handles txtBudget.TextChanged
        keyAllow("0987654321,", txtBudget)
        CheckforDoubleDot(txtBudget)
        NumberFormat(txtBudget)
    End Sub

    Private Sub txtNumberOfParticipants_TextChanged(sender As Object, e As EventArgs) Handles txtNumberOfParticipants.TextChanged
        keyAllow("0987654321,", txtNumberOfParticipants)
        CheckforDoubleDot(txtNumberOfParticipants)
        NumberFormat(txtNumberOfParticipants)
    End Sub
End Class