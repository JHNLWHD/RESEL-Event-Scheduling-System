Imports MySql.Data.MySqlClient
Public Class frmLogIn

    Public _account_obj As AccountClass
    Public _acad_obj As AcademicYearClass
    Public Shared _user_id As Integer = 0
    Public Shared _user_name As String = ""
    Public Shared _user_unit_name As String = ""
    Public Shared _user_unit_abbrev As String = ""
    Public Shared _user_type As String = ""
    Dim str As String = ""

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Try
            _account_obj = New AccountClass
            _acad_obj = New AcademicYearClass

            With _account_obj
                If RequiredField(txtUsername.Text, txtPassword.Text) = True Then
                    If .isExist(txtUsername.Text) = True Then
                        If .isRemove(txtUsername.Text) = False Then
                            If .isActive(txtUsername.Text, txtPassword.Text) = True Then
                                If .isMatched(txtUsername.Text, txtPassword.Text) = True Then
                                    If .isLogin(txtUsername.Text, txtPassword.Text) = False Then
                                        If .isAdmin(txtUsername.Text, txtPassword.Text) = True Then
ACTIVE:
                                            If _acad_obj.hasActiveDateSettings = True Then
                                                If _acad_obj.hasExist = True Then
                                                    If _acad_obj.hasActive = True Then
                                                        _acad_obj.getActiveAY()
                                                        If Convert.ToDateTime(getDate()).ToString("yyyy") >= _acad_obj.Academic_year_start And Convert.ToDateTime(getDate()).ToString("yyyy") <= _acad_obj.Academic_year_end Then
                                                            .getAccountDetails(txtUsername.Text, txtPassword.Text)
                                                            _user_id = .Idaccount
                                                            _user_name = String.Format("{0} {1}", .Account_fn, .Account_ln)
                                                            _user_unit_name = .Account_unit_name
                                                            _user_unit_abbrev = .Account_unit_abbrev
                                                            _user_type = .Account_type

                                                            .Idaccount = _user_id
                                                            .Account_isLogin = "TRUE"
                                                            str = "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                                                                & "VALUES('" & MySqlHelper.EscapeString("You have logged in.") & "'," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have logged in.") & "',CURRENT_TIMESTAMP," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"

                                                            If .UpdateAccountFlag(str) = True Then
                                                                frmHome.Show()
                                                                frmHome.lblName.Text = _user_name
                                                                frmHome.lblUnit.Text = _user_unit_abbrev
                                                                ' frmHome.ReportsToolStripMenuItem2.Visible = False
                                                                Hide()
                                                            Else
                                                                MessageBox.Show("Failed to login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                                Exit Sub
                                                            End If

                                                        ElseIf Convert.ToDateTime(getDate()).ToString("yyyy") > _acad_obj.Academic_year_end Then
                                                            Dim ans As MsgBoxResult
                                                            ans = MessageBox.Show("Backing up of database is required.", "Database Backup", MessageBoxButtons.OK, MessageBoxIcon.Question)
                                                            If ans = MsgBoxResult.Ok Then
                                                                Dim file As String
                                                                sfd.Filter = "SQL Dump File (*.sql)|*.sql|All files (*.*)|*.*"
                                                                sfd.FileName = "Database Backup " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".sql"
                                                                If sfd.ShowDialog = DialogResult.OK Then
                                                                    file = sfd.FileName
                                                                    databaseBackup(file)
                                                                End If
                                                            Else
                                                                Application.Exit()
                                                            End If
                                                            'need to backup database
                                                            'else exit system
                                                        ElseIf Convert.ToDateTime(getDate()).ToString("yyyy") < _acad_obj.Academic_year_start Then
                                                            MessageBox.Show("Your time is not sync. Please conatact your admin to check the system time." + vbCrLf + "The system will exit now. You're current work will not be saved.", "Deactivate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                            Exit Sub
                                                        End If

                                                    Else
                                                        'show form of acad to set active
                                                        '   MessageBox.Show("Academic Year Records is currently empty." + vbCrLf + "You will be redirect to a new form to set the new active academic year.", "Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                        frmAYActivate.ShowDialog()
                                                        GoTo ACTIVE
                                                    End If
                                                Else
                                                    'show form of acad year
                                                    MessageBox.Show("Academic Year Records is currently empty." + vbCrLf + "You will be redirect to a new form to set the new active academic year.", "Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                    frmAddAcademicYear.ShowDialog()
                                                    GoTo ACTIVE
                                                End If
                                            Else
                                                MessageBox.Show("Academic Date Settings Records is currently empty." + vbCrLf + "You will be redirect to a new form to set the new active academic year.", "Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                frmSetDateSetttings.ShowDialog()
                                                GoTo ACTIVE
                                            End If

                                        Else
                                            If _acad_obj.hasExist = True Then
                                                If _acad_obj.hasActive = True Then
                                                    _acad_obj.getActiveAY()
                                                    If Convert.ToDateTime(getDate()).ToString("yyyy") >= _acad_obj.Academic_year_start And Convert.ToDateTime(getDate()).ToString("yyyy") <= _acad_obj.Academic_year_end Then
                                                        .getAccountDetails(txtUsername.Text, txtPassword.Text)
                                                        _user_id = .Idaccount
                                                        _user_name = String.Format("{0} {1}", .Account_fn, .Account_ln)
                                                        _user_unit_name = .Account_unit_name
                                                        _user_unit_abbrev = .Account_unit_abbrev
                                                        _user_type = .Account_type

                                                        .Idaccount = _user_id
                                                        .Account_isLogin = "TRUE"
                                                        str = "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                                                                & "VALUES('" & MySqlHelper.EscapeString("You have logged in.") & "'," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have logged in.") & "',CURRENT_TIMESTAMP," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"

                                                        If .UpdateAccountFlag(str) = True Then
                                                            frmHome.Show()
                                                            frmHome.lblName.Text = _user_name
                                                            frmHome.lblUnit.Text = _user_unit_abbrev
                                                            frmHome.ToolStripMenuItem3.Visible = False
                                                            '  frmHome.ReportsToolStripMenuItem2.Visible = False
                                                            frmHome.ActivityLogs2ToolStripMenuItem.Visible = False
                                                            Hide()
                                                        Else
                                                            MessageBox.Show("Failed to login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                                            Exit Sub
                                                        End If

                                                    ElseIf Convert.ToDateTime(getDate()).ToString("yyyy") > _acad_obj.Academic_year_end Then
                                                        'need to backup database
                                                        'else exit system
                                                        'user
                                                        MessageBox.Show("Backing up of database. Please conatact your admin to backup the database." + vbCrLf + "The system will exit now. You're current work will not be saved.", "Deactivate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                        Exit Sub
                                                    ElseIf Convert.ToDateTime(getDate()).ToString("yyyy") < _acad_obj.Academic_year_start Then
                                                        MessageBox.Show("Your time is not sync. Please conatact your admin to check the system time." + vbCrLf + "The system will exit now. You're current work will not be saved.", "Deactivate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                        Exit Sub
                                                    End If

                                                Else
                                                    MessageBox.Show("Please contact your admin to activate an academic year.")
                                                    Exit Sub
                                                End If
                                            Else
                                                MessageBox.Show("Please contact your admin to add an activated academic year.")
                                                Exit Sub
                                            End If


                                        End If
                                    Else
                                        MessageBox.Show("This account is currently login in another device.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        Exit Sub
                                    End If

                                Else
                                    MessageBox.Show("Account details doesn't match.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit Sub
                                End If
                            Else
                                MessageBox.Show("This account has been deactivated.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("This account has been removed.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("This account doesn't exist.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("All fields are required.", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtUsername.Focus()
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            ' MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Private Sub frmLogIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtUsername.Focus()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmLogIn_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Try
            frmConnectionSettings.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub
End Class