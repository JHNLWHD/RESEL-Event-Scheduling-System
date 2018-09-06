Imports MySql.Data.MySqlClient
Public Class AcademicYearClass

    Private _idacademic_year As Integer = 0
    Private _academic_year_start As Integer = 0
    Private _academic_year_end As Integer = 0
    Private _academic_year As String = ""
    Private _academic_year_status As String = ""
    Private _academic_year_remove_status As String = ""
    Private _acad_count As Integer = 0
    Private _iddate_settings As Integer = 0
    Private _date_settings_start As Integer = 1
    Private _date_settings_end As Integer = 1
    Private _status As String = ""
    Private _date_settings_start_word As String = ""
    Private _date_settings_end_word As String = ""

    Public Property Idacademic_year As Integer
        Get
            Return _idacademic_year
        End Get
        Set(value As Integer)
            _idacademic_year = value
        End Set
    End Property



    Public Property Academic_year_status As String
        Get
            Return _academic_year_status
        End Get
        Set(value As String)
            _academic_year_status = value
        End Set
    End Property

    Public Property Academic_year As String
        Get
            Return _academic_year
        End Get
        Set(value As String)
            _academic_year = value
        End Set
    End Property

    Public Property Academic_year_remove_status As String
        Get
            Return _academic_year_remove_status
        End Get
        Set(value As String)
            _academic_year_remove_status = value
        End Set
    End Property

    Public Property Academic_year_start As Integer
        Get
            Return _academic_year_start
        End Get
        Set(value As Integer)
            _academic_year_start = value
        End Set
    End Property

    Public Property Academic_year_end As Integer
        Get
            Return _academic_year_end
        End Get
        Set(value As Integer)
            _academic_year_end = value
        End Set
    End Property

    Public Property Acad_count As Integer
        Get
            Return _acad_count
        End Get
        Set(value As Integer)
            _acad_count = value
        End Set
    End Property

    Public Property Iddate_settings As Integer
        Get
            Return _iddate_settings
        End Get
        Set(value As Integer)
            _iddate_settings = value
        End Set
    End Property

    Public Property Date_settings_start As Integer
        Get
            Return _date_settings_start
        End Get
        Set(value As Integer)
            _date_settings_start = value
        End Set
    End Property

    Public Property Date_settings_end As Integer
        Get
            Return _date_settings_end
        End Get
        Set(value As Integer)
            _date_settings_end = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    Public Property Date_settings_start_word As String
        Get
            Return _date_settings_start_word
        End Get
        Set(value As String)
            _date_settings_start_word = value
        End Set
    End Property

    Public Property Date_settings_end_word As String
        Get
            Return _date_settings_end_word
        End Get
        Set(value As String)
            _date_settings_end_word = value
        End Set
    End Property

    Sub New()
        Try
            Dim acc As AccountClass = New AccountClass
            Dim str As String = ""

            ConnectToServer()
            getActiveAY()
            If hasExist() = True Then
                If Convert.ToDateTime(getDate()).ToString("yyyy") >= Academic_year_start And Convert.ToDateTime(getDate()).ToString("yyyy") <= Academic_year_end Then
                    'no change
                ElseIf Convert.ToDateTime(getDate()).ToString("yyyy") > Academic_year_end Then
                    If CloseAY() = True Then
                        MessageBox.Show("Your academic year is already deactivated." + vbCrLf + "The system will exit now. You're current work will not be saved.", "Deactivate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        acc.Idaccount = frmLogIn._user_id
                        acc.Account_isLogin = "FALSE"
                        str = "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                                                                & "VALUES('" & MySqlHelper.EscapeString("You have logged out.") & "'," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + "have logged out.") & "',CURRENT_TIMESTAMP," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
                        acc.UpdateAccountFlag(str)
                        Application.Exit()
                    Else
                        MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                ElseIf Convert.ToDateTime(getDate()).ToString("yyyy") < Academic_year_start Then
                    MessageBox.Show("Your time is not sync. Please contact your admin to check the system time." + vbCrLf + "The system will exit now. You're current work will not be saved.", "Deactivate Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    acc.Idaccount = frmLogIn._user_id
                    acc.Account_isLogin = "FALSE"
                    str = "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                                                                & "VALUES('" & MySqlHelper.EscapeString("You have logged out.") & "'," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + "have logged out.") & "',CURRENT_TIMESTAMP," _
                                                                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
                    acc.UpdateAccountFlag(str)
                    Application.Exit()
                End If
            Else

            End If


        Catch ex As Exception
            'MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Function AddAY() As Boolean
        Try
            'Validate first if AY is existing
            'Validate if it is Currently Active
            Dim sql As String = "INSERT INTO academic_year(academic_year_start,academic_year_end,academic_year,academic_year_status,academic_year_remove_status,academic_year_reg_date,date_settings_iddate_settings) VALUES(@0,@1,@2,@3,@4,CURRENT_DATE,(SELECT iddate_settings FROM date_settings WHERE status = '" & MySqlHelper.EscapeString("Active") & "' LIMIT 1));"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have saved new academic year: " + Academic_year) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have saved new academic year: " + Academic_year) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Academic_year_start, Academic_year_end, Academic_year, Academic_year_status, Academic_year_remove_status)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function AddDateSettings() As Boolean
        Try
            'Validate first if AY is existing
            'Validate if it is Currently Active
            Dim sql As String = "INSERT INTO date_settings(date_settings_start,date_settings_end,status) VALUES(@0,@1,@2);"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount)" _
                & " VALUES('" & MySqlHelper.EscapeString("You have saved new date settings: " + Date_settings_start_word + "-" + Date_settings_end_word) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have saved new date settings: " + Date_settings_start_word + "-" + Date_settings_end_word) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Date_settings_start, Date_settings_end, Status)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function
    Public Function AddDateSettingsNOACTLOGS() As Boolean
        Try
            'Validate first if AY is existing
            'Validate if it is Currently Active
            Dim sql As String = "INSERT INTO date_settings(date_settings_start,date_settings_end,status) VALUES(@0,@1,@2);"

            ConnectToServer()
            ServerExecuteSQL(sql, Date_settings_start, Date_settings_end, Status)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function
    Public Function AddAYNoActLogs() As Boolean
        Try
            'Validate first if AY is existing
            'Validate if it is Currently Active
            Dim sql As String = "INSERT INTO academic_year(academic_year_start,academic_year_end,academic_year,academic_year_status,academic_year_remove_status,academic_year_reg_date,date_settings_iddate_settings) VALUES(@0,@1,@2,@3,@4,CURRENT_DATE,(SELECT iddate_settings FROM date_settings WHERE status = '" & MySqlHelper.EscapeString("Active") & "' LIMIT 1));"
            ConnectToServer()
            ServerExecuteSQL(sql, Academic_year_start, Academic_year_end, Academic_year, Academic_year_status, Academic_year_remove_status)
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateAY() As Boolean
        Try
            'Validate first if AY is existing
            'Validate if it is Currently Active
            Dim sql As String = "UPDATE academic_year SET academic_year_start=@0,academic_year_end=@1,academic_year=@2 WHERE idacademic_year=@3;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have updated an academic year to: " + Academic_year) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have updated an academic year to: " + Academic_year) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Academic_year_start, Academic_year_end, Academic_year, Idacademic_year)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function RemoveAY() As Boolean
        Try
            'Validate if it is Currently Active
            'If true then don't proceed
            Dim sql As String = "UPDATE academic_year SET academic_year_remove_status=@0 WHERE idacademic_year=@1;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have removed an academic year: " + Academic_year) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have removed an academic year: " + Academic_year) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Academic_year_remove_status, Idacademic_year)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function ActivateAY() As Boolean
        Try
            'set all to close before activating or vice-versa
            Dim sql As String = "UPDATE academic_year SET academic_year_status=@0 WHERE idacademic_year=@1;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have activated an academic year: " + Academic_year) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have activated an academic year: " + Academic_year) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Academic_year_status, Idacademic_year)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function CloseAY() As Boolean
        Try
            'set all to close before activating or vice-versa
            Dim sql As String = "UPDATE academic_year SET academic_year_status='Inactive';"
            'NO ACTIVITY LOGS
            ConnectToServer()
            ServerExecuteSQL(sql)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function isAYExist(strFrom As String, strTo As String, trigger As String, Optional ByVal idAcad As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idacademic_year FROM academic_year WHERE academic_year = '" & String.Format("{0} - {1}", MySqlHelper.EscapeString(strFrom), MySqlHelper.EscapeString(strTo)) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idacademic_year FROM academic_year WHERE academic_year = '" & String.Format("{0} - {1}", MySqlHelper.EscapeString(strFrom), MySqlHelper.EscapeString(strTo)) & "' " _
                   & "AND idacademic_year != '" & MySqlHelper.EscapeString(idAcad) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idacademic_year")
        Catch ex As Exception
            '  MsgBox(ex.Message)
            Return False
            Exit Function
        End Try

        Return True
    End Function

    Public Function isDateSettingsExist(strFrom As String, strTo As String, trigger As String, Optional ByVal idAcad As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT iddate_settings FROM date_settings WHERE date_settings_start = '" & MySqlHelper.EscapeString(strFrom) & "' AND date_settings_end = '" & MySqlHelper.EscapeString(strTo) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT iddate_settings FROM date_settings WHERE date_settings_start = '" & MySqlHelper.EscapeString(strFrom) & "' AND date_settings_end = '" & MySqlHelper.EscapeString(strTo) & "' AND iddate_settings != '" & MySqlHelper.EscapeString(idAcad) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("iddate_settings")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
            Exit Function
        End Try

        Return True
    End Function

    Public Function isAYConflict(dtpFrom As String, dtpTo As String, trigger As String, Optional ByVal idAcad As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then

                sql = "SELECT * FROM academic_year WHERE academic_year_start <= '" & MySqlHelper.EscapeString(dtpTo) & "' AND " _
              & "academic_year_end >= '" & MySqlHelper.EscapeString(dtpFrom) & "';"

            ElseIf trigger = "Edit" Then

                sql = "SELECT * FROM academic_year WHERE academic_year_start <= '" & MySqlHelper.EscapeString(dtpTo) & "' AND " _
              & "academic_year_end >= '" & MySqlHelper.EscapeString(dtpFrom) & "' AND idacademic_year != '" & MySqlHelper.EscapeString(idAcad) & "';"

            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idacademic_year")
            Academic_year = ds.Tables(0).Rows(0)("academic_year")
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return False
            Exit Function
        End Try

        Return True
    End Function

    Public Function isActive(str As String) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = "SELECT idacademic_year FROM academic_year WHERE academic_year_status = '" & MySqlHelper.EscapeString("ACTIVE") & "' AND academic_year = '" & MySqlHelper.EscapeString(str) & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idacademic_year")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function hasActive() As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = "SELECT idacademic_year FROM academic_year WHERE academic_year_status = '" & MySqlHelper.EscapeString("Active") & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idacademic_year")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function hasActiveDateSettings() As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = "SELECT iddate_settings FROM date_settings WHERE status = '" & MySqlHelper.EscapeString("Active") & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("iddate_settings")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function hasExist() As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = "SELECT idacademic_year FROM academic_year;"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idacademic_year")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Sub LoadAYRecords(dgv As DataGridView, filter As String, limit As Integer)
        Try

            Dim sql As String = ""

            If filter = "ALL" Then
                If limit = 0 Then
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year_reg_date <= CURRENT_DATE AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "ORDER BY idacademic_year DESC;"
                Else
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year_reg_date <= CURRENT_DATE AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "ORDER BY idacademic_year DESC LIMIT 5;"
                End If
            Else
                If limit = 0 Then
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year_status = '" & MySqlHelper.EscapeString(filter) & "' AND academic_year_reg_date <= CURRENT_DATE AND " _
                        & "academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' ORDER BY idacademic_year DESC;"
                Else
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year_status = '" & MySqlHelper.EscapeString(filter) & "' AND academic_year_reg_date <= CURRENT_DATE AND " _
                        & "academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' ORDER BY idacademic_year DESC LIMIT 5;"
                End If
            End If

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idacademic_year"), MySqlDR("academic_year"), Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MySqlDR("date_settings_start")), Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MySqlDR("date_settings_end")), MySqlDR("academic_year_status"))
            End While
            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchAYRecords(dgv As DataGridView, filter As String, str As String, limit As Integer, trigger As String)
        Try

            Dim sql As String = ""

            If filter = "All" Then

                If limit = 0 Then
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE (academic_year LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND academic_year_reg_date <= CURRENT_DATE" _
                   & " AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') ORDER BY idacademic_year DESC;"
                Else
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE (academic_year LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND academic_year_reg_date <= CURRENT_DATE" _
                   & " AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') ORDER BY idacademic_year DESC LIMIT 5;"
                End If

            ElseIf filter = "Active" Then

                If limit = 0 Then
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND academic_year_reg_date <= CURRENT_DATE" _
                    & " AND academic_year_status = '" & MySqlHelper.EscapeString("Active") & "' AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                    & "ORDER BY idacademic_year DESC;"
                Else
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year Like '%" & MySqlHelper.EscapeString(str) & "%' AND academic_year_reg_date <= CURRENT_DATE" _
                    & " AND academic_year_status = '" & MySqlHelper.EscapeString("Active") & "' AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                    & " ORDER BY idacademic_year DESC LIMIT 5;"
                End If

            ElseIf filter = "Inactive" Then

                If limit = 0 Then
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year Like '%" & MySqlHelper.EscapeString(str) & "%' AND academic_year_reg_date <= CURRENT_DATE" _
                    & " AND academic_year_status = '" & MySqlHelper.EscapeString("Inactive") & "' AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                    & "ORDER BY idacademic_year DESC;"
                Else
                    sql = "SELECT * FROM academic_year INNER JOIN date_settings on academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year Like '%" & MySqlHelper.EscapeString(str) & "%' AND academic_year_reg_date <= CURRENT_DATE" _
                    & " AND academic_year_status = '" & MySqlHelper.EscapeString("Inactive") & "' AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                    & "ORDER BY idacademic_year DESC LIMIT 5;"
                End If

            End If
            dgv.Rows.Clear()
            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection())
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader()

            While MySqlDR.Read
                If trigger = "Edit" Then
                    dgv.Rows.Add(MySqlDR("idacademic_year"), MySqlDR("academic_year"))
                ElseIf trigger = "Load" Then
                    dgv.Rows.Add(MySqlDR("idacademic_year"), MySqlDR("academic_year"), Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MySqlDR("date_settings_start")), Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MySqlDR("date_settings_end")), MySqlDR("academic_year_status"))
                End If
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadAYToEdit(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM academic_year WHERE academic_year_reg_date <= CURRENT_DATE AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & " AND idacademic_year = " & MySqlHelper.EscapeString(index) & " ORDER BY idacademic_year DESC LIMIT 1;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idacademic_year = MySqlDR("idacademic_year")
                Academic_year_start = MySqlDR("academic_year_start")
                Academic_year_end = MySqlDR("academic_year_end")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub getActiveAY()
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM academic_year INNER JOIN date_settings ON academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year.academic_year_status = '" & MySqlHelper.EscapeString("Active") & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idacademic_year = MySqlDR("idacademic_year")
                Academic_year = MySqlDR("academic_year")
                Academic_year_start = MySqlDR("academic_year_start")
                Academic_year_end = MySqlDR("academic_year_end")
                Date_settings_start = MySqlDR("date_settings_start")
                Date_settings_end = MySqlDR("date_settings_end")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ActiveAYRecord(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM academic_year INNER JOIN date_settings ON academic_year.date_settings_iddate_settings = date_settings.iddate_settings WHERE academic_year_status = '" & MySqlHelper.EscapeString("Active") & "' " _
                & "AND idacademic_year = '" & MySqlHelper.EscapeString(index) & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Academic_year = MySqlDR("academic_year")
                Academic_year_start = MySqlDR("academic_year_start")
                Academic_year_end = MySqlDR("academic_year_end")
                Date_settings_start = MySqlDR("date_settings_start")
                Date_settings_end = MySqlDR("date_settings_end")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub AYRecordCount(str As String)
        Try
            ConnectToServer()
            Acad_count = 0
            Dim sql As String = ""
            If str = "Active" Or str = "Inactive" Then
                sql = "SELECT count(*) FROM academic_year WHERE academic_year_status = '" & MySqlHelper.EscapeString(str) & "' " _
                & "AND academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            Else
                sql = "SELECT count(*) FROM academic_year WHERE academic_year_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Acad_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadAYDateSettingsRecords(dgv As DataGridView, filter As String, limit As Integer)
        Try

            Dim sql As String = ""

            If filter = "All" Then
                If limit = 0 Then
                    sql = "SELECT * FROM date_settings ORDER BY iddate_settings DESC;"
                Else
                    sql = "SELECT * FROM date_settings ORDER BY iddate_settings DESC LIMIT 5;"
                End If
            Else
                If limit = 0 Then
                    sql = "SELECT * FROM date_settings WHERE status = '" & MySqlHelper.EscapeString(filter) & "' ORDER BY iddate_settings DESC;"
                Else
                    sql = "SELECT * FROM date_settings WHERE status = '" & MySqlHelper.EscapeString(filter) & "' ORDER BY iddate_settings DESC LIMIT 5;"
                End If
            End If

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("iddate_settings"), Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MySqlDR("date_settings_start")), Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MySqlDR("date_settings_end")), MySqlDR("status"))
            End While
            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchAYDateSettingsRecords(dgv As DataGridView, filter As String, limit As Integer, txt As String)
        Try

            Dim sql As String = ""

            If filter = "All" Then
                If limit = 0 Then
                    sql = "SELECT * FROM date_settings WHERE date_settings_start LIKE '%" & MySqlHelper.EscapeString(txt) & "%'  OR date_settings_end LIKE '%" & MySqlHelper.EscapeString(txt) & "%' ORDER BY iddate_settings DESC;"
                Else
                    sql = "SELECT * FROM date_settings WHERE date_settings_start LIKE '%" & MySqlHelper.EscapeString(txt) & "%' OR date_settings_end LIKE '%" & MySqlHelper.EscapeString(txt) & "%' ORDER BY iddate_settings DESC LIMIT 5;"
                End If
            Else
                If limit = 0 Then
                    sql = "SELECT * FROM date_settings WHERE status = '" & MySqlHelper.EscapeString(filter) & "' AND (date_settings_start LIKE '%" & MySqlHelper.EscapeString(txt) & "%' OR date_settings_end LIKE '%" & MySqlHelper.EscapeString(txt) & "%') ORDER BY iddate_settings DESC;"
                Else
                    sql = "SELECT * FROM date_settings WHERE status = '" & MySqlHelper.EscapeString(filter) & "' AND (date_settings_start LIKE '%" & MySqlHelper.EscapeString(txt) & "%' OR date_settings_end LIKE '%" & MySqlHelper.EscapeString(txt) & "%') ORDER BY iddate_settings DESC LIMIT 5;"
                End If
            End If

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("iddate_settings"), Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MySqlDR("date_settings_start")), Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(MySqlDR("date_settings_end")), MySqlDR("status"))
            End While
            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub AYDateSettingsRecordCount(str As String)
        Try
            ConnectToServer()
            Acad_count = 0
            Dim sql As String = ""
            If str = "Active" Or str = "Inactive" Then
                sql = "SELECT count(*) FROM date_settings WHERE status = '" & MySqlHelper.EscapeString(str) & "' ORDER BY iddate_settings DESC;"
            Else
                sql = "SELECT count(*) FROM date_settings ORDER BY iddate_settings DESC;"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Acad_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Public Function ActivateAYDate() As Boolean
        Try
            'set all to close before activating or vice-versa
            Dim sql As String = "UPDATE date_settings SET status=@0 WHERE iddate_settings=@1;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have activated an academic date settings: " + String.Format("{0}-{1}", Date_settings_start_word, Date_settings_end_word)) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have activated an academic date settings: " + String.Format("{0}-{1}", Date_settings_start_word, Date_settings_end_word)) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Status, Iddate_settings)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function CloseAYDate() As Boolean
        Try
            'set all to close before activating or vice-versa
            Dim sql As String = "UPDATE date_settings SET status=@0;"
            'NO ACTIVITY LOGS
            ConnectToServer()
            ServerExecuteSQL(sql, Status)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function
End Class
