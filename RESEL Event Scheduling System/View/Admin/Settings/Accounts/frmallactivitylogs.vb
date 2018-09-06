Public Class frmallactivitylogs

    Public _accnt_obj As AccountClass

    Private Sub lnklblRefresh_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub frmallactivitylogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _accnt_obj = New AccountClass
            With _accnt_obj
                .LoadAllActLogs(dgvAL)
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

    End Sub
End Class