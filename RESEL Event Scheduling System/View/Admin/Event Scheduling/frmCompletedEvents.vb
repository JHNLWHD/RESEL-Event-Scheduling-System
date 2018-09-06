Public Class frmCompletedEvents

    Public _acad_year_obj As AcademicYearClass
    Public _account_obj As AccountClass
    Public _event_obj As EventClass

    Private Sub frmCompletedEvents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _event_obj = New EventClass
            _acad_year_obj = New AcademicYearClass
            _acad_year_obj.getActiveAY()
            With _event_obj
                .LoadEventsType(_acad_year_obj.Idacademic_year, dgvPending, frmLogIn._user_type, frmLogIn._user_unit_abbrev, "COMPLETED")
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class