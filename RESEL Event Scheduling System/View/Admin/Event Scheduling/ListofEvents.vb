Public Class ListofEvents
    Public _acad_year_obj As AcademicYearClass
    Public _acc As AccountClass
    Public _event_obj As EventClass
    Public _college_obj As CollegeClass
    Public Shared idE As Integer = 0

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

    Private Sub ListofEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()

            With _event_obj
                .LoadListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, dgvEvents)
            End With
        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgvPending_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvEvents.CellMouseUp
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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            'code here for print crystal
            Dim dt As New DataTable
            Dim rpt As New listOfEventsrpt
            Dim frm As New reports

            With dt.Columns
                .Add("event_name")
                .Add("event_number_of_participants")
                .Add("event_type")
                .Add("event_status")
                '.Add(columname)
                'records in report

            End With


            For i As Integer = 0 To dgvEvents.Rows.Count - 1
                'get from datagridview
                dt.Rows.Add(dgvEvents.Rows(i).Cells(3).Value.ToString,
                            dgvEvents.Rows(i).Cells(5).Value.ToString,
                            dgvEvents.Rows(i).Cells(4).Value.ToString,
                            dgvEvents.Rows(i).Cells(6).Value.ToString)
            Next



            rpt.SetDataSource(dt)

            With frm
                .CrystalReportViewer1.ReportSource = rpt
                .CrystalReportViewer1.Refresh()
                .ShowDialog()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                ''  MsgBox()
                If .Event_priority = "Priority" Then
                    frmEditDetails.chkPriority.Checked = True
                Else
                    frmEditDetails.chkPriority.Checked = False
                End If
                frmEditDetails.idC = .Ideveent
                frmEditDetails.ShowDialog()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RescheduleThisEventToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles RescheduleThisEventToolStripMenuItem.Click
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

    Private Sub ViewEventTrackingToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ViewEventTrackingToolStripMenuItem.Click
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
                .LoadEventsTrack(frmEventTrack.dgvTrack, .Ideveent)
                frmEventTrack.ShowDialog()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ViewMoreDetailsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ViewMoreDetailsToolStripMenuItem.Click
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
                frmViewdetails.ShowDialog()
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class