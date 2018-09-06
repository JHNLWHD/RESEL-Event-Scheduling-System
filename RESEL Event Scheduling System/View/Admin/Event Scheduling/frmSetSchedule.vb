Public Class frmSetSchedule
    Public _acad_year_obj As AcademicYearClass
    Public _event_obj As EventClass
    Public _college_obj As CollegeClass
    Public _venue As VenueClass
    Public _acc As AccountClass
    Public Shared _id As Integer = 0
    Private Sub frmSetSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _acad_year_obj = New AcademicYearClass
            _event_obj = New EventClass
            _college_obj = New CollegeClass
            _acc = New AccountClass
            With _acad_year_obj
                .getActiveAY()
                dtpDate.MinDate = New Date(Convert.ToDateTime(getDate()).ToString("yyyy"), Convert.ToDateTime(getDate()).ToString("MM"), Convert.ToDateTime(getDate()).ToString("dd"))
                ' dtpDate2.MinDate = New Date(.Academic_year_start, .Date_settings_start, 1)
                If .Date_settings_end = 1 Or .Date_settings_end = 3 Or .Date_settings_end = 5 Or .Date_settings_end = 7 Or .Date_settings_end = 8 Or .Date_settings_end = 10 Or .Date_settings_end = 12 Then
                    dtpDate.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 31)
                    ' dtpDate2.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 31)
                ElseIf .Date_settings_end = 4 Or .Date_settings_end = 6 Or .Date_settings_end = 9 Or .Date_settings_end = 11 Then
                    dtpDate.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 30)
                    ' dtpDate2.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 30)
                ElseIf .Academic_year_end Mod 4 = 0 Then
                    dtpDate.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 29)
                    ' dtpDate2.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 29)
                ElseIf .Academic_year_end Mod 4 <> 0 Then
                    dtpDate.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 28)
                    ' dtpDate2.MaxDate = New Date(.Academic_year_end, .Date_settings_end, 28)
                End If

                LoadVenueToCbo(cboVenue)
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
            Dim dtp As Date = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
            _event_obj.LoadHoliday(dtp.ToString("yyyy-MM-dd"))
            ' MsgBox(_event_obj.Holiday_date)
            With _event_obj
                _acad_year_obj.getActiveAY()
                .Academic_year_idacademic_year = _acad_year_obj.Idacademic_year

                If dtpStartTime.Value.ToString("hh:mm tt") <> Nothing And dtpEndTime.Value.ToString("hh:mm tt") <> Nothing And cboVenue.Text <> Nothing Then
                    If Convert.ToDateTime(dtpStartTime.Value).ToString("hh:mm tt") > Convert.ToDateTime(dtpEndTime.Value).ToString("hh:mm tt") Then
                        MsgBox("Start time must be less than End time.")
                        Exit Sub
                    ElseIf Convert.ToDateTime(dtpStartTime.Value).ToString("hh:mm tt") = Convert.ToDateTime(dtpEndTime.Value).ToString("hh:mm tt") Then
                        MsgBox("Start time cannot be equal to End time.")
                        Exit Sub


                    Else
                        If .Holiday_date.ToString("yyyy-MM-dd") = dtp.ToString("yyyy-MM-dd") Then
                            If .isScheduleConflictResched(dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "True", frmEventReschedulingvb.idEve) = True Then
                                If frmEventReschedulingvb._prio = "Priority" Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                Else
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                End If


                            ElseIf .isScheduleConflictResched(dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE", frmEventReschedulingvb.idEve) = True Then
                                If frmEventReschedulingvb._prio = "Priority" Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                Else
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                End If

                            Else
                                If frmEventReschedulingvb.checkDGVConflict(dtpDate.Value.ToString("yyyy-MM-dd")) = True Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                Else
                                    'dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("MM-dd-yyyy"), cboStartTime.Text, cboEndTime.Text, "Approved")
                                    frmEventReschedulingvb.dgvSchedule.Rows(frmEventReschedulingvb.index).SetValues(frmEventReschedulingvb.dgvSchedule.Rows(frmEventReschedulingvb.index).Cells(0).Value.ToString, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Incoming", "", 1)
                                    frmEventReschedulingvb._event_Stat = 1
                                    Dispose()
                                    Close()
                                    ' startDate = startDate.AddDays(1).ToString("MM-dd-yyyy")

                                End If
                            End If
                        Else
                            If .isScheduleConflictResched(dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "True", frmEventReschedulingvb.idEve) = True Then
                                If frmEventReschedulingvb._prio = "Priority" Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                Else
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                End If


                            ElseIf .isScheduleConflictResched(dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), cboVenue.Text, .Academic_year_idacademic_year, "", "FALSE", frmEventReschedulingvb.idEve) = True Then
                                If frmEventReschedulingvb._prio = "Priority" Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                Else
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                End If

                            Else
                                If frmEventReschedulingvb.checkDGVConflict(dtpDate.Value.ToString("yyyy-MM-dd")) = True Then
                                    Dim ans1 As MsgBoxResult
                                    ans1 = MsgBox("The schedule is in conflict with " + .Event_name, MsgBoxStyle.OkOnly, "Manage Event")

                                Else
                                    'MsgBox(123)
                                    'dgvSchedule.Rows.Add(0, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, startDate.ToString("MM-dd-yyyy"), cboStartTime.Text, cboEndTime.Text, "Approved")
                                    frmEventReschedulingvb.dgvSchedule.Rows(frmEventReschedulingvb.index).SetValues(frmEventReschedulingvb.dgvSchedule.Rows(frmEventReschedulingvb.index).Cells(0).Value.ToString, _venue.getIDVenue(cboVenue.Text), cboVenue.Text, dtpDate.Value.ToString("yyyy-MM-dd"), dtpStartTime.Value.ToString("hh:mm tt"), dtpEndTime.Value.ToString("hh:mm tt"), "Incoming", "", 1)
                                    frmEventReschedulingvb._event_Stat = 1
                                Dispose()
                                Close()
                                ' startDate = startDate.AddDays(1).ToString("MM-dd-yyyy")

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


End Class