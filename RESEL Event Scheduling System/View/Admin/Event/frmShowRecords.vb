Public Class frmShowRecords

    Public _event_obj As EventClass
    Public _acad_year_obj As AcademicYearClass

    Public Sub frmShowRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cboSort.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboSort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSort.SelectedIndexChanged
        Try
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()
            With _event_obj
                If cboSort.SelectedIndex = 0 Then
                    .LoadAllEvents(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev)
                ElseIf cboSort.SelectedIndex = 1 Then
                    .LoadEventsTypeShowRecords(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev, cboSort.Text)
                ElseIf cboSort.SelectedIndex = 2 Then
                    .LoadEventsTypeShowRecords(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev, cboSort.Text)
                ElseIf cboSort.SelectedIndex = 3 Then
                    .LoadEventsTypeShowRecords(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev, cboSort.Text)
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPending_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvPending.CellMouseUp
        If e.Button = MouseButtons.Right Then
            Try
                dgvPending.Rows(e.RowIndex).Selected = True
                dgvPending.CurrentCell = dgvPending.Rows(e.RowIndex).Cells(e.ColumnIndex)

                If dgvPending.SelectedRows.Count = 1 Then

                    If dgvPending.SelectedRows(0).Cells(6).Value.ToString <> "COMPLETED" And frmLogIn._user_type = "ADMIN" Then
                        cmAdmin.Show(dgvPending, e.Location)
                        cmAdmin.Show(Cursor.Position)

                    ElseIf dgvPending.SelectedRows(0).Cells(6).Value.ToString = "COMPLETED" And frmLogIn._user_type = "ADMIN" Then
                        cmManage.Show(dgvPending, e.Location)
                        cmManage.Show(Cursor.Position)

                    ElseIf dgvPending.SelectedRows(0).Cells(6).Value.ToString = "COMPLETED" And frmLogIn._user_type = "USER" Then
                        cmManage.Show(dgvPending, e.Location)
                        cmManage.Show(Cursor.Position)

                    ElseIf dgvPending.SelectedRows(0).Cells(6).Value.ToString <> "COMPLETED" And frmLogIn._user_type = "USER" Then
                        cmUser.Show(dgvPending, e.Location)
                        cmUser.Show(Cursor.Position)
                    End If

                End If
            Catch ex As Exception
                MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub ViewMoreDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewMoreDetailsToolStripMenuItem.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadEventsDetails(frmViewdetails.dgvSchedule, dgvPending.SelectedRows(0).Cells(0).Value.ToString)
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

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadEventsDetails(frmViewdetails.dgvSchedule, dgvPending.SelectedRows(0).Cells(0).Value.ToString)
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

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadEventsDetails(frmViewdetails.dgvSchedule, dgvPending.SelectedRows(0).Cells(0).Value.ToString)
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

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Try
            _event_obj = New EventClass

            'frmediteventvb.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            'frmediteventvb.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()
            With _event_obj
                If cboSort.SelectedIndex = 0 Then
                    .LoadAllEvents(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev)
                ElseIf cboSort.SelectedIndex = 1 Then
                    If txtSearch.Text.Length >= 2 Then
                        .SearchEvents(dgvPending, _acad_year_obj.Idacademic_year, cboSort.Text, txtSearch.Text)
                    Else
                        .LoadEventsTypeShowRecords(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev, cboSort.Text)
                    End If

                ElseIf cboSort.SelectedIndex = 2 Then
                    If txtSearch.Text.Length >= 2 Then
                        .SearchEvents(dgvPending, _acad_year_obj.Idacademic_year, cboSort.Text, txtSearch.Text)
                    Else
                        .LoadEventsTypeShowRecords(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev, cboSort.Text)
                    End If

                ElseIf cboSort.SelectedIndex = 3 Then
                    If txtSearch.Text.Length >= 2 Then
                        .SearchEvents(dgvPending, _acad_year_obj.Idacademic_year, cboSort.Text, txtSearch.Text)
                    Else
                        .LoadEventsTypeShowRecords(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev, cboSort.Text)
                    End If

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CancelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CancelToolStripMenuItem.Click
        Try
            _event_obj = New EventClass
            With _event_obj
                .Ideveent = dgvPending.SelectedRows(0).Cells(0).Value.ToString
                .Event_status = "CANCELLED"
                If .UpdateEventStat() = True Then
                    MsgBox("Event has been cancelled")
                Else
                    MsgBox("Event has not been cancelled")
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class