Public Class frmEventReportRecords

    Public _event_obj As EventClass

    Private Sub frmEventReportRecords_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadListOfEventsReports(frmLogIn._user_type, dgvEvents, dtpFrom.Value.ToString("yyyy-MM-dd"), dtpTo.Value.ToString("yyyy-MM-dd"))
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        Try

            If dtpFrom.Value > dtpTo.Value Then
                MsgBox("Start date cannot be greater than End date.")
            Else
                frmEventReportRecords_Load(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        Try
            If dtpFrom.Value > dtpTo.Value Then
                MsgBox("Start date cannot be greater than End date.")
            Else
                frmEventReportRecords_Load(sender, e)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblRefresh.LinkClicked
        Try
            frmEventReportRecords_Load(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnklblPrint_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblPrint.LinkClicked
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
            rpt.SetParameterValue("acad_year", frmHome.lblAY.Text)
            rpt.SetParameterValue("from_date", dtpFrom.Value)
            rpt.SetParameterValue("to_date", dtpTo.Value)
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
End Class