Imports MySql.Data.MySqlClient
Public Class frmEventReschedulingvb
    Public Shared _event_Stat As Integer = 0
    Public Shared _prio_Stat As Integer = 0
    Public Shared _prio As String = ""
    Public Shared index As Integer = 0
    Public Shared idEve As Integer = 0
    Public Shared status As String = ""
    Public _acad_year_obj As AcademicYearClass
    Public _event_obj As EventClass
    Public _college_obj As CollegeClass
    Public _venue As VenueClass
    Public _acc As AccountClass
    Dim str As String = ""
    Private _ds As New DataSet
    Private _ds1 As New DataSet
    Private _ds2 As New DataSet

    Private Sub dgvSchedule_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSchedule.CellContentClick
        Try
            If e.ColumnIndex = 7 Then
                If dgvSchedule.SelectedRows(0).Cells(6).Value.ToString <> "Completed" Then
                    index = e.RowIndex
                    frmSetSchedule._id = dgvSchedule.SelectedRows(0).Cells(0).Value.ToString
                    frmSetSchedule.ShowDialog()

                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Dispose()
            Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmEventReschedulingvb_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Try
            Dim pend As Integer = 0
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()
            _event_obj = New EventClass
            With _event_obj
                .Academic_year_idacademic_year = _acad_year_obj.Idacademic_year
                .Event_code = lblActCode.Text
                .Ideveent = idEve
                .Event_status = status
                _prio = _prio
                If _prio = "Priority" Then
                    For Each row As DataGridViewRow In dgvSchedule.Rows
                        If .isScheduleConflictResched(row.Cells(3).Value.ToString(), row.Cells(4).Value.ToString, row.Cells(5).Value.ToString, row.Cells(2).Value.ToString, .Academic_year_idacademic_year, "", "TRUE", idEve) = True Then
                            pend = 1
                            'MsgBox("ss1")
                        ElseIf .isScheduleConflictResched(row.Cells(3).Value.ToString(), row.Cells(4).Value.ToString, row.Cells(5).Value.ToString, row.Cells(2).Value.ToString, .Academic_year_idacademic_year, "", "FALSE", idEve) = True Then
                            'update the other event to pending
                            'get all event id then update

                            'MsgBox("ss2")
                        Else
                            MsgBox("ss3")

                            If row.Cells(8).Value > 0 Then

                                str += "DELETE FROM event_has_schedule WHERE event_idevent = '" & idEve & "' AND schedule_idschedule = '" & row.Cells(0).Value.ToString & "';"
                                str += "DELETE FROM venue_has_schedule WHERE event_idevent = '" & idEve & "' AND venue_idvenue = '" & row.Cells(1).Value.ToString & "';"

                                str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                                & "VALUES('" & MySqlHelper.EscapeString(row.Cells(3).Value.ToString()) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"

                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                            & "VALUES('" & row.Cells(1).Value.ToString & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule),'" & MySqlHelper.EscapeString("Incoming") & "');"
                            End If


                        End If
                    Next
                Else

                    For Each row As DataGridViewRow In dgvSchedule.Rows

                        If .isScheduleConflictResched(row.Cells(3).Value.ToString(), row.Cells(4).Value.ToString, row.Cells(5).Value.ToString, row.Cells(2).Value.ToString, .Academic_year_idacademic_year, "", "TRUE", idEve) = True Then
                            ' MsgBox("ss1")
                        ElseIf .isScheduleConflictResched(row.Cells(3).Value.ToString(), row.Cells(4).Value.ToString, row.Cells(5).Value.ToString, row.Cells(2).Value.ToString, .Academic_year_idacademic_year, "", "FALSE", idEve) = True Then
                            'MsgBox("ss2")
                            pend = 1
                        Else
                            MsgBox("ss3")

                            If row.Cells(8).Value > 0 Then
                                str += "DELETE FROM event_has_schedule WHERE event_idevent = '" & idEve & "' AND schedule_idschedule = '" & row.Cells(0).Value.ToString & "';"
                                str += "DELETE FROM venue_has_schedule WHERE event_idevent = '" & idEve & "' AND venue_idvenue = '" & row.Cells(1).Value.ToString & "';"

                                str += "INSERT INTO schedule(schedule_date,schedule_start_time,schedule_end_time,schedule_remove_status,academic_year_idacademic_year) " _
                                                & "VALUES('" & MySqlHelper.EscapeString(row.Cells(3).Value.ToString()) & "',TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(4).Value.ToString) & "','%h:%i %p'))," _
                                                & "TIME(STR_TO_DATE('" & MySqlHelper.EscapeString(row.Cells(5).Value.ToString) & "','%h:%i %p')),'" & MySqlHelper.EscapeString("FALSE") & "','" & MySqlHelper.EscapeString(.Academic_year_idacademic_year) & "');"

                                str += "INSERT INTO venue_has_schedule(venue_idvenue,schedule_idschedule,venue_has_schedule_reg_date) " _
                                        & "VALUES('" & row.Cells(1).Value.ToString & "',(SELECT MAX(idschedule) FROM schedule),CURRENT_DATE);"
                                str += "INSERT INTO event_has_schedule(event_idevent,schedule_idschedule,event_has_schedule_status) VALUES((SELECT idevent FROM event WHERE event_code = '" & MySqlHelper.EscapeString(.Event_code) & "'),(SELECT MAX(idschedule) FROM schedule),'" & MySqlHelper.EscapeString("Incoming") & "');"
                                'run query check here

                            End If




                        End If
                    Next
                End If

                If pend = 1 Then
                    .Event_code = lblActCode.Text

                    _acad_year_obj.getActiveAY()

                    .Event_priority = _prio
                    .Ideveent = idEve
                    .Account_idaccount = frmLogIn._user_id

                    .Event_status = "Pending"
                    .Event_unit = frmHome.lblUnit.Text
                    If .UpdateEventStatus(str) = True Then
                        MsgBox("Event has been rescheduled")

                        Try
                            _acad_year_obj.getActiveAY()

                            With _event_obj
                                .LoadListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, ListofEvents.dgvEvents)
                                .LoadListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, frmHome.dgvEvents)
                            End With
                        Catch ex As Exception

                        End Try
                        Dispose()
                        Close()

                    Else
                        MsgBox("Event has not been rescheduled")
                    End If
                Else

                    _acad_year_obj.getActiveAY()
                    .Academic_year_idacademic_year = _acad_year_obj.Idacademic_year
                    .Event_priority = _prio

                    .Event_remove_status = "FALSE"
                    .Event_is_cancel = "FALSE"
                    .Event_remarks = ""
                    .Account_idaccount = frmLogIn._user_id
                    .Event_status = "Incoming"
                    .Event_unit = frmHome.lblUnit.Text
                    If .UpdateEventStatus(str) = True Then
                        MsgBox("Event has been rescheduled")
                        Dim _determinant As Integer = 0
                        For Each row As DataGridViewRow In dgvSchedule.Rows
                            .CheckConflictToOtherEvent(row.Cells(8).Value.ToString, idEve)
                            If .Ctr = 1 Then
                                LoadAllIDEventsToCheckConflict(.Idevent_clone)
                                For Each row2 As DataRow In _ds.Tables(0).Rows
                                    .Idschedule = row2("idschedule")
                                    'checkconflict
                                    'select * from event_has_schedule where idsc = ' and ideve != '
                                    '
                                    LoadAllIDEventsToCheckConflictSchedule(.Idschedule, .Idevent_clone)
                                    For Each row3 As DataRow In _ds1.Tables(0).Rows
                                        _determinant = 1
                                    Next

                                Next
                                'here yung update
                                .Event_status = "Approved"
                                .Ideveent = .Idevent_clone
                                .Event_name = .Event_name
                                .UpdateEventStatResched()
                            End If

                        Next
                        Try
                            _acad_year_obj.getActiveAY()

                            With _event_obj
                                .LoadListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, ListofEvents.dgvEvents)
                                .LoadListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, frmHome.dgvEvents)
                            End With
                        Catch ex As Exception

                        End Try
                        Dispose()
                        Close()

                    Else
                        MsgBox("Event has not been rescheduled")
                    End If
                End If


                ' End If


            End With
        Catch ex As Exception
            'MsgBox(ex.Message + "jhbjb")
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Function checkDGVConflict(str As String) As Boolean
        Dim bool As Boolean = False
        Try
            '  MsgBox(str)
            For Each row As DataGridViewRow In dgvSchedule.Rows
                If row.Cells(3).Value = str _
                    And Convert.ToDateTime(row.Cells(4).Value).ToString("HH:mm") < Convert.ToDateTime(frmSetSchedule.dtpEndTime.Text).ToString("HH:mm") _
                    And Convert.ToDateTime(row.Cells(5).Value).ToString("HH:mm") > Convert.ToDateTime(frmSetSchedule.dtpStartTime.Text).ToString("HH:mm") Then
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

    Private Sub LoadAllIDEventsToCheckConflict(index As Integer)
        Try
            ConnectToServer()
            _ds.Clear()

            Dim da As New MySqlDataAdapter
            Dim sql As String = "SELECT * FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.idevent = '" & index & "';"
            da = New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(_ds)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub LoadAllIDEventsToCheckConflictSchedule(index As Integer, index2 As Integer)
        Try
            ConnectToServer()
            _ds1.Clear()

            Dim da As New MySqlDataAdapter
            Dim sql As String = "SELECT * FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event_has_schedule.schedule_idschedule = '" & index & "' AND event.idevent != '" & index2 & "';"
            da = New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(_ds1)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
End Class