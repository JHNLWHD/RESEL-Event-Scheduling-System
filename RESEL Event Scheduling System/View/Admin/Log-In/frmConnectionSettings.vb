Public Class frmConnectionSettings
    Private str0 As String = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ._"
    Private NumOnly As String = "1234567890"
    Private NumWithDot As String = "1234567890."

    Public Sub AllowedOnly(s As String, tb As TextBox)
        Try
            Dim theText As String = tb.Text
            Dim Letter As String
            Dim SelectionIndex As Integer = tb.SelectionStart
            Dim Change As Integer
            For x As Integer = 0 To tb.Text.Length - 1
                Letter = tb.Text.Substring(x, 1)
                If s.Contains(Letter) = False Then
                    theText = theText.Replace(Letter, String.Empty)
                    Change = 1
                End If
            Next
            tb.Text = theText
            tb.Select(SelectionIndex - Change, 0)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtServer_TextChanged(sender As Object, e As EventArgs) Handles txtServer.TextChanged
        AllowedOnly(str0, txtServer)
    End Sub
    Private Sub txtPort_TextChanged(sender As Object, e As EventArgs) Handles txtPort.TextChanged
        AllowedOnly(NumOnly, txtPort)
    End Sub
    Private Sub txtDatabaseName_TextChanged(sender As Object, e As EventArgs) Handles txtDatabase.TextChanged
        AllowedOnly(str0, txtDatabase)
    End Sub
    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged
        AllowedOnly(str0, txtUser)
    End Sub
    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        AllowedOnly(str0, txtPassword)
    End Sub
    Private Sub btnTestConnection_Click(sender As Object, e As EventArgs) Handles btnTestConnection.Click
        Try
            Dim TestStr As String = "server=" & txtServer.Text & ";port=" & txtPort.Text _
                                             & ";database=" & txtDatabase.Text & ";user=" & txtUser.Text _
                                             & ";password=" & txtPassword.Text
            If TestConnection(TestStr) = True Then
                If MessageBox.Show("You have successfully established a connection. Do you want save the changes?", "Connection Succeeded",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    My.Settings.Server = txtServer.Text
                    My.Settings.Port = txtPort.Text
                    My.Settings.Database = txtDatabase.Text
                    My.Settings.User = txtUser.Text
                    My.Settings.Password = txtPassword.Text
                    My.Settings.Save()
                    Close()
                End If
            Else
                MsgBox("Unable to connect to specified server. Please review connection fields.", "Connection Failed", MessageBoxIcon.Error)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class