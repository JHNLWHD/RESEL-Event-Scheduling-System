Public Class frmOverdue

    Public _acad_year_obj As AcademicYearClass
    Public _account_obj As AccountClass
    Public _event_obj As EventClass

    Private Sub frmOverdue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()
            With _event_obj
                .LoadEventsType(_acad_year_obj.Idacademic_year, dgvOverdue, frmLogIn._user_type, frmLogIn._user_unit_abbrev, "OVERDUE")
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        Try
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()
            With _event_obj
                If txtCode.Text.Length >= 2 Then
                    .SearchEvents(dgvOverdue, _acad_year_obj.Idacademic_year, "PENDING", txtCode.Text)
                ElseIf txtCode.Text = vbNullString Then
                    .LoadEventsType(_acad_year_obj.Idacademic_year, dgvOverdue, frmLogIn._user_type, frmLogIn._user_unit_abbrev, "PENDING")
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RescheduleThisEventToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RescheduleThisEventToolStripMenuItem.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                If dgvOverdue.SelectedRows(0).Cells(6).Value.ToString = "Completed" Then
                    MessageBox.Show("Event is already completed and can't be rescheduled.")
                    Exit Sub
                Else
                    .LoadEventsDetailsToResched(frmEventReschedulingvb.dgvSchedule, dgvOverdue.SelectedRows(0).Cells(0).Value.ToString)
                    frmEventReschedulingvb.idEve = .Ideveent
                    frmEventReschedulingvb.lblActCode.Text = .Event_code
                    frmEventReschedulingvb.lblEventName.Text = .Event_name
                    frmEventReschedulingvb.lblGoal.Text = .Event_goal
                    frmEventReschedulingvb.lblType.Text = .Event_type
                    frmEventReschedulingvb.lblNo.Text = .Event_number_of_participants
                    frmEventReschedulingvb.lblType.Text = .Event_type
                    frmEventReschedulingvb.lblUnit.Text = .Event_unit
                    frmEventReschedulingvb._prio = .Event_priority

                    frmEventReschedulingvb.ShowDialog()
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ViewEventTrackingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewEventTrackingToolStripMenuItem.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadEventsDetails(frmEventTrack.dgvSchedule, dgvOverdue.SelectedRows(0).Cells(0).Value.ToString)
                frmEventTrack.lblActCode.Text = .Event_code
                frmEventTrack.lblEventName.Text = .Event_name
                frmEventTrack.lblGoal.Text = .Event_goal
                frmEventTrack.lblType.Text = .Event_type
                frmEventTrack.lblNo.Text = .Event_number_of_participants
                frmEventTrack.lblType.Text = .Event_type
                frmEventTrack.lblUnit.Text = .Event_unit
                .LoadEventsTrack(dgvOverdue, .Ideveent)
                frmEventTrack.ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ViewMoreDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewMoreDetailsToolStripMenuItem.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadEventsDetails(frmViewdetails.dgvSchedule, dgvOverdue.SelectedRows(0).Cells(0).Value.ToString)
                frmViewdetails.lblActCode.Text = .Event_code
                frmViewdetails.lblEventName.Text = .Event_name
                frmViewdetails.lblGoal.Text = .Event_goal
                frmViewdetails.lblType.Text = .Event_type
                frmViewdetails.lblNo.Text = .Event_number_of_participants
                frmViewdetails.lblType.Text = .Event_type
                frmViewdetails.lblUnit.Text = .Event_unit
                frmViewdetails.ShowDialog()
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditEventDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditEventDetailsToolStripMenuItem.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvOverdue_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvOverdue.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvOverdue.Rows(e.RowIndex).Selected = True
                dgvOverdue.CurrentCell = dgvOverdue.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvOverdue.SelectedRows.Count = 1 Then
                    cmManage.Show(dgvOverdue, e.Location)
                    cmManage.Show(Cursor.Position)
                End If
            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub
End Class