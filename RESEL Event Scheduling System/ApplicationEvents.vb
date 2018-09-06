Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.Devices

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Partial Friend Class MyApplication
        Public _account_obj As AccountClass
        Private Sub MyApplication_NetworkAvailabilityChanged(sender As Object, e As NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged
            Try
                'CODE HERE
                'If Connect() = True Then
                '    frmHome.tmrDateTime.Start()
                '    frmHome.tmrEvents.Start()
                '    frmHome.lblConn.Text = "Connection Status: Connected"
                'Else
                '    frmHome.lblConn.Text = "Connection Status: Disconnected"
                'End If
                If Computer.Network.IsAvailable = True AndAlso Computer.Network.Ping(My.Settings.Server) = True Then
                    Connect()
                    frmHome.tmrDateTime.Start()
                    frmHome.tmrEvents.Start()
                    frmHome.lblConn.Text = "Connection Status: Connected"
                Else
                    frmHome.lblConn.Text = "Connection Status: Disconnected"
                End If
            Catch ex As Exception
                frmHome.lblConn.Text = "Connection Status: Disconnected"
            End Try
        End Sub

        'Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
        '    Try
        '        _account_obj = New AccountClass
        '        With _account_obj
        '            .Idaccount = frmLogIn._user_id
        '            .Account_isLogin = "TRUE"

        '            If .UpdateAccountFlag = True Then
        '                ' frmHome.Show()
        '                frmHome.lblName.Text = frmLogIn._user_name
        '                frmHome.lblUnit.Text = frmLogIn._user_unit_abbrev
        '                'Hide()
        '            Else
        '                MessageBox.Show("Failed to login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                Exit Sub
        '            End If
        '        End With

        '    Catch ex As Exception

        '    End Try
        'End Sub





        'Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
        '    Try
        '        MsgBox("Error 404: Not Found")
        '    Catch ex As Exception
        '        MsgBox("Error 404: Not Found")
        '    End Try
        'End Sub
    End Class
End Namespace
