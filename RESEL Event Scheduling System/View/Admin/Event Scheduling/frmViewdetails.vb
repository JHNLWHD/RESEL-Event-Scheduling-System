Public Class frmViewdetails

    Private Sub frmViewdetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Dispose()
            Close()
        Catch ex As Exception

        End Try
    End Sub


End Class