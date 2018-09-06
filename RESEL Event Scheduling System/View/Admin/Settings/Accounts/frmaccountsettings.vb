Public Class frmaccountsettings

    Public _acc As AccountClass
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            pnlstart.Visible = False
            pnlchange.Visible = True
            txtU.Text = txtUser.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtPass.UseSystemPasswordChar = False
        Else
            txtPass.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            pnlchange.Visible = False
            pnlstart.Visible = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            _acc = New AccountClass
            With _acc
                If lblPM.Visible = True Then
                    .Idaccount = frmLogIn._user_id
                    .Account_username = txtU.Text
                    .Account_password = txtP.Text
                    If .UpdateAccountSettings = True Then
                        MsgBox("Settings changed")
                        Dispose()
                        Close()
                    Else
                        MsgBox("Settings not changed")
                    End If
                Else
                    MsgBox("Password does not match.")
                End If

            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmaccountsettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _acc = New AccountClass
            With _acc
                pnlstart.Visible = True
                pnlchange.Visible = False
                .getAccountDetailsSettings(frmLogIn._user_id)
                txtUser.Enabled = False
                txtPass.Enabled = False
                txtUser.Text = .Account_username
                txtPass.Text = .Account_password

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRP_TextChanged(sender As Object, e As EventArgs) Handles txtRP.TextChanged
        Try
            If txtRP.Text.Length >= 5 Then
                If txtP.Text = txtRP.Text Then
                    lblPM.Visible = True
                Else
                    lblPM.Visible = False
                End If
            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtP_TextChanged(sender As Object, e As EventArgs) Handles txtP.TextChanged
        Try
            If txtP.Text.Length >= 5 Then
                If txtP.Text = txtRP.Text Then
                    lblPM.Visible = True
                Else
                    lblPM.Visible = False
                End If
            Else

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtP_LostFocus(sender As Object, e As EventArgs) Handles txtP.LostFocus
        Try
            If txtP.Text.Length < 5 Then
                lblPass.Visible = True
                lblPM.Visible = False
            Else
                lblPass.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtRP_LostFocus(sender As Object, e As EventArgs) Handles txtRP.LostFocus
        Try
            If txtRP.Text.Length < 5 Then
                lblPass2.Visible = True
                lblPM.Visible = False
            Else
                lblPass2.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmaccountsettings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub
End Class