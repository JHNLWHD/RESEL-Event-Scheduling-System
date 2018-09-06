Public Class frmArchive

    Public _event_obj As EventClass
    Public _acad_obj As AcademicYearClass

    Private Sub frmArchive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LoadArchiveAYToCbo(cboAY, frmHome.lblAY.Text, getActiveAYStart)
            cboAY.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboAY_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAY.SelectedIndexChanged
        Try
            _event_obj = New EventClass
            With _event_obj
                .LoadListOfEventsArchive(cboAY.Text, frmLogIn._user_type, frmLogIn._user_unit_abbrev, dgvEvents)
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class