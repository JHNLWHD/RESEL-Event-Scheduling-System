Public Class frmActivityLogs

    Public _accnt_obj As AccountClass

    Private Sub frmActivityLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _accnt_obj = New AccountClass
            With _accnt_obj
                .LoadActLogs(dgvAL, frmLogIn._user_id)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblRefresh.LinkClicked

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class