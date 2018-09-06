Imports MySql.Data.MySqlClient
Public Class AccountClass

    Private _idaccount As Integer = 0
    Private _account_fn As String = ""
    Private _account_ln As String = ""
    Private _account_username As String = ""
    Private _account_password As String = ""
    Private _account_status As String = ""
    Private _account_type As String = ""
    Private _account_reg_date As Date
    Private _account_position As String = ""
    Private _account_unit_name As String = ""
    Private _account_unit_abbrev As String = ""
    Private _account_remove_status As String = ""
    Private _account_isActive As String = ""
    Private _account_isLogin As String = ""
    Private _account_count As Integer = 0
    Private _account_name As String = ""

    Private _idactivity_logs As Integer = 0
    Private _activity_logs_act_name As String = ""
    Private _activity_logs_date As Date


    Private _idunit As Integer = 0
    Private _unit_name As String = ""
    Private _unit_abbrev As String = ""
    Private _unit_reg_date As Date
    Private _unit_status As String = ""
    Private _unit_remove_status As String = ""
    Private _unit_count As Integer = 0


    Public Property Idaccount As Integer
        Get
            Return _idaccount
        End Get
        Set(value As Integer)
            _idaccount = value
        End Set
    End Property

    Public Property Account_fn As String
        Get
            Return _account_fn
        End Get
        Set(value As String)
            _account_fn = value
        End Set
    End Property

    Public Property Account_ln As String
        Get
            Return _account_ln
        End Get
        Set(value As String)
            _account_ln = value
        End Set
    End Property

    Public Property Account_username As String
        Get
            Return _account_username
        End Get
        Set(value As String)
            _account_username = value
        End Set
    End Property

    Public Property Account_password As String
        Get
            Return _account_password
        End Get
        Set(value As String)
            _account_password = value
        End Set
    End Property

    Public Property Account_status As String
        Get
            Return _account_status
        End Get
        Set(value As String)
            _account_status = value
        End Set
    End Property

    Public Property Account_type As String
        Get
            Return _account_type
        End Get
        Set(value As String)
            _account_type = value
        End Set
    End Property

    Public Property Account_reg_date As Date
        Get
            Return _account_reg_date
        End Get
        Set(value As Date)
            _account_reg_date = value
        End Set
    End Property

    Public Property Account_position As String
        Get
            Return _account_position
        End Get
        Set(value As String)
            _account_position = value
        End Set
    End Property

    Public Property Account_unit_name As String
        Get
            Return _account_unit_name
        End Get
        Set(value As String)
            _account_unit_name = value
        End Set
    End Property

    Public Property Account_unit_abbrev As String
        Get
            Return _account_unit_abbrev
        End Get
        Set(value As String)
            _account_unit_abbrev = value
        End Set
    End Property

    Public Property Idunit As Integer
        Get
            Return _idunit
        End Get
        Set(value As Integer)
            _idunit = value
        End Set
    End Property

    Public Property Unit_name As String
        Get
            Return _unit_name
        End Get
        Set(value As String)
            _unit_name = value
        End Set
    End Property

    Public Property Unit_abbrev As String
        Get
            Return _unit_abbrev
        End Get
        Set(value As String)
            _unit_abbrev = value
        End Set
    End Property

    Public Property Unit_reg_date As Date
        Get
            Return _unit_reg_date
        End Get
        Set(value As Date)
            _unit_reg_date = value
        End Set
    End Property

    Public Property Unit_status As String
        Get
            Return _unit_status
        End Get
        Set(value As String)
            _unit_status = value
        End Set
    End Property

    Public Property Account_remove_status As String
        Get
            Return _account_remove_status
        End Get
        Set(value As String)
            _account_remove_status = value
        End Set
    End Property

    Public Property Account_isActive As String
        Get
            Return _account_isActive
        End Get
        Set(value As String)
            _account_isActive = value
        End Set
    End Property

    Public Property Account_isLogin As String
        Get
            Return _account_isLogin
        End Get
        Set(value As String)
            _account_isLogin = value
        End Set
    End Property

    Public Property Unit_remove_status As String
        Get
            Return _unit_remove_status
        End Get
        Set(value As String)
            _unit_remove_status = value
        End Set
    End Property

    Public Property Account_count As Integer
        Get
            Return _account_count
        End Get
        Set(value As Integer)
            _account_count = value
        End Set
    End Property

    Public Property Unit_count As Integer
        Get
            Return _unit_count
        End Get
        Set(value As Integer)
            _unit_count = value
        End Set
    End Property

    Public Property Account_name As String
        Get
            Return _account_name
        End Get
        Set(value As String)
            _account_name = value
        End Set
    End Property

    Public Property Idactivity_logs As Integer
        Get
            Return _idactivity_logs
        End Get
        Set(value As Integer)
            _idactivity_logs = value
        End Set
    End Property

    Public Property Activity_logs_act_name As String
        Get
            Return _activity_logs_act_name
        End Get
        Set(value As String)
            _activity_logs_act_name = value
        End Set
    End Property

    Public Property Activity_logs_date As Date
        Get
            Return _activity_logs_date
        End Get
        Set(value As Date)
            _activity_logs_date = value
        End Set
    End Property

    Public Function AddUnit() As Boolean
        Try
            Dim sql As String = "INSERT INTO unit(unit_name, unit_abbrev, unit_reg_date, unit_status,unit_remove_status) VALUES(@0,@1,CURRENT_DATE," _
                               & "'" & MySqlHelper.EscapeString("Active") & "','" & MySqlHelper.EscapeString("FALSE") & "');"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have saved new unit: " + Unit_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have saved new unit: " + Unit_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Unit_name, Unit_abbrev)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateUnit() As Boolean
        Try
            Dim sql As String = "UPDATE unit SET unit_name=@0, unit_abbrev=@1 WHERE idunit=@2;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have updated an unit to: " + Unit_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have updated an unit to: " + Unit_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Unit_name, Unit_abbrev, Idunit)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function AddAccount() As Boolean
        Try
            Dim sql As String = "INSERT INTO account(account_fn,account_ln,account_username,account_password,account_status,account_type," _
                            & "account_reg_date,account_position,account_unit_name,account_unit_abbrev,account_hasAdmin,account_remove_status) " _
                            & "VALUES(@0,@1,@2,@3,@4,@5," _
                            & "CURRENT_DATE,@6,@7,@8,'" & MySqlHelper.EscapeString(" ") & "','" & MySqlHelper.EscapeString("FALSE") & "');"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have save new account: " + String.Format("{0} {1}", Account_fn, Account_ln)) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have save new account: " + String.Format("{0} {1}", Account_fn, Account_ln)) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            'ACTIVITY LOGS
            ConnectToServer()
            ServerExecuteSQL(sql, Account_fn, Account_ln, Account_username, Account_password, Account_status, Account_type, Account_position,
                             Account_unit_name, Account_unit_abbrev)
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateAccount(str As String, str2 As String) As Boolean
        Try
            Dim sql As String = "UPDATE account SET account_fn=@0,account_ln=@1,account_username=@2,account_password=@3,account_type=@4," _
                            & "account_position=@5,unit_idunit = (SELECT idunit FROM unit WHERE unit_name = '" & MySqlHelper.EscapeString(str) & "' AND unit_abbrev = '" & MySqlHelper.EscapeString(str2) & "' LIMIT 1) WHERE idaccount = @6;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have updated an account to: " + String.Format("{0} {1}", Account_fn, Account_ln)) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " updated an account to: " + String.Format("{0} {1}", Account_fn, Account_ln)) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Account_fn, Account_ln, Account_username, Account_password, Account_type, Account_position,
                             Account_unit_name, Idaccount)
        Catch ex As Exception
            '  MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateAccountFlag(str As String) As Boolean
        Try
            Dim sql As String = "UPDATE account SET account_isLogin=@0 WHERE idaccount = @1;"
            sql += str
            'NO ACTIVITY LOGS
            ConnectToServer()
            ServerExecuteSQL(sql, Account_isLogin, Idaccount)
        Catch ex As Exception
            '  MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateAccountSettings() As Boolean
        Try
            Dim sql As String = "UPDATE account SET account_username=@0,account_password=@1 WHERE idaccount = @2;"
            'NO ACTIVITY LOGS
            ConnectToServer()
            ServerExecuteSQL(sql, Account_username, Account_password, Idaccount)
        Catch ex As Exception
            '  MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function AddAccountDynamic(str As String, str2 As String) As Boolean
        Try
            Dim sql As String = "INSERT INTO account(account_fn,account_ln,account_username,account_password,account_status,account_type," _
                            & "account_reg_date,account_position,unit_idunit,account_remove_status,account_isActive,account_isLogin) " _
                            & "VALUES(@0,@1,@2,@3,@4,@5," _
                            & "CURRENT_DATE,@6,(SELECT idunit FROM unit WHERE unit_name = '" & MySqlHelper.EscapeString(str) & "' AND unit_abbrev = '" & MySqlHelper.EscapeString(str2) & "' LIMIT 1)," _
                            & "'" & MySqlHelper.EscapeString("FALSE") & "',@7,@8);"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have save new account: " + String.Format("{0} {1}", Account_fn, Account_ln)) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have save new account: " + String.Format("{0} {1}", Account_fn, Account_ln)) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Account_fn, Account_ln, Account_username, Account_password, Account_status, Account_type, Account_position,
                             Account_isActive, Account_isLogin)
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Sub LoadAccountRecords(dgv As DataGridView, str As String)
        Try
            ConnectToServer()
            Dim sql As String = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit=unit.idunit WHERE MATCH(account.account_status) AGAINST('" & MySqlHelper.EscapeString(str) & "') " _
                                & "AND account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idaccount"), String.Format("{0} {1}", MySqlDR("account_fn"), MySqlDR("account_ln")), MySqlDR("unit_abbrev"),
                     MySqlDR("account_position"), MySqlDR("account_username"), MySqlDR("account_type"), MySqlDR("account_status"))
            End While

            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            '    MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchAccountRecords(dgv As DataGridView, filter As String, str As String, limit As Integer, trigger As String)
        Try
            ConnectToServer()
            Dim sql As String = ""

            If filter = "ALL" Then

                If limit = 0 Then
                    sql = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit=unit.idunit WHERE (CONCAT(account.account_fn,' ',account.account_ln) LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND account.account_reg_date <= CURRENT_DATE" _
                   & " AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') " _
                   & "OR (CONCAT(account.account_ln,',',account.account_fn) LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') " _
                   & "OR (account.account_username LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') " _
                   & "ORDER BY account.idaccount DESC;"
                Else
                    sql = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit=unit.idunit WHERE (CONCAT(account.account_fn,' ',account.account_ln) LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND account.account_reg_date <= CURRENT_DATE" _
                   & " AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') " _
                   & "OR (CONCAT(account.account_ln,',',account.account_fn) LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') " _
                   & "OR (account.account_username LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') " _
                   & "ORDER BY account.idaccount DESC LIMIT 5;"
                End If

            ElseIf filter = "ACTIVE" Then

                If limit = 0 Then
                    sql = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit=unit.idunit WHERE (CONCAT(account.account_fn,' ',account.account_ln) LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND account.account_reg_date <= CURRENT_DATE" _
                   & " AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Active") & "') " _
                   & "OR (CONCAT(account.account_ln,',',account.account_fn) LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Active") & "') " _
                   & "OR (account.account_username LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Active") & "') " _
                   & "ORDER BY account.idaccount DESC;"
                Else
                    sql = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit=unit.idunit WHERE (CONCAT(account.account_fn,' ',account.account_ln) LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND account.account_reg_date <= CURRENT_DATE" _
                   & " AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Active") & "') " _
                   & "OR (CONCAT(account.account_ln,',',account.account_fn) LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Active") & "') " _
                   & "OR (account.account_username LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Active") & "') " _
                   & "ORDER BY account.idaccount DESC LIMIT 5;"
                End If

            ElseIf filter = "INACTIVE" Then

                If limit = 0 Then
                    sql = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit=unit.idunit WHERE (CONCAT(account.account_fn,' ',account.account_ln) LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND account.account_reg_date <= CURRENT_DATE" _
                   & " AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Active") & "') " _
                   & "OR (CONCAT(account.account_ln,',',account.account_fn) LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Inactive") & "') " _
                   & "OR (account.account_username LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Inactive") & "') " _
                   & "ORDER BY account.idaccount DESC;"
                Else
                    sql = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit=unit.idunit WHERE (CONCAT(account.account_fn,' ',account.account_ln) LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND account.account_reg_date <= CURRENT_DATE" _
                   & " AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Active") & "') " _
                   & "OR (CONCAT(account.account_ln,',',account.account_fn) LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Inactive") & "') " _
                   & "OR (account.account_username LIKE '%" & MySqlHelper.EscapeString(str) & "%' " _
                   & "AND account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND account.account_status = '" & MySqlHelper.EscapeString("Inactive") & "') " _
                   & "ORDER BY account.idaccount DESC LIMIT 5;"
                End If

            End If

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                If trigger = "Edit" Then
                    dgv.Rows.Add(MySqlDR("idaccount"), String.Format("{0} {1}", MySqlDR("account_fn"), MySqlDR("account_ln")))
                ElseIf trigger = "Load" Then
                    dgv.Rows.Add(MySqlDR("idaccount"), String.Format("{0} {1}", MySqlDR("account_fn"), MySqlDR("account_ln")), MySqlDR("unit_abbrev"),
                             MySqlDR("account_position"), MySqlDR("account_username"), MySqlDR("account_type"), MySqlDR("account_status"))
                End If
            End While

            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadAccountToEdit(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit=unit.idunit WHERE account.account_reg_date <= CURRENT_DATE AND account.account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & " AND account.idaccount = " & MySqlHelper.EscapeString(index) & " ORDER BY account.idaccount DESC LIMIT 1;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idaccount = MySqlDR("idaccount")
                Account_fn = MySqlDR("account_fn")
                Account_ln = MySqlDR("account_ln")
                Account_username = MySqlDR("account_username")
                Account_password = MySqlDR("account_password")
                Account_position = MySqlDR("account_position")
                Account_unit_abbrev = MySqlDR("unit_abbrev")
                Account_type = MySqlDR("account_type")
                Account_status = MySqlDR("account_status")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadUnitRecordsToSched(dgv As DataGridView)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM unit WHERE unit_status = '" & MySqlHelper.EscapeString("Active") & "' AND unit_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(0, MySqlDR("idunit"), MySqlDR("unit_abbrev"))
            End While

            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadUnitRecords(dgv As DataGridView, str As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM unit WHERE MATCH(unit_status) AGAINST('" & MySqlHelper.EscapeString(str) & "') " _
                 & "AND unit_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idunit"), MySqlDR("unit_name"), MySqlDR("unit_abbrev"), Convert.ToDateTime(MySqlDR("unit_reg_date")).ToString("MM-dd-yyyy"), MySqlDR("unit_status"))
            End While

            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Function getUnit(str As String) As Object
        Dim ds As New DataSet
        Dim oj As Object
        Try
            Dim sql As String = "SELECT idunit,unit_name FROM unit WHERE unit_abbrev = '" & MySqlHelper.EscapeString(str) & "' ORDER BY idunit DESC LIMIT 1;"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            oj = ds.Tables(0).Rows(0)("unit_name")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
        Return oj
    End Function

    Public Sub SearchUnitRecords(dgv As DataGridView, str As String, limit As Integer, filter As String)
        Try
            ConnectToServer()
            Dim sql As String = ""

            If limit = 0 Then
                If filter = "ACTIVE,INACTIVE" Then
                    sql = "SELECT * FROM unit WHERE (unit_name LIKE '%" & MySqlHelper.EscapeString(str) & "%') OR (unit_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%');"
                Else
                    sql = "SELECT * FROM unit WHERE (unit_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND unit_status = '" & MySqlHelper.EscapeString(filter) & "') OR (unit_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND unit_status = '" & MySqlHelper.EscapeString(filter) & "');"
                End If

            Else
                If filter = "ACTIVE,INACTIVE" Then
                    sql = "SELECT * FROM unit WHERE (unit_name LIKE '%" & MySqlHelper.EscapeString(str) & "%') OR (unit_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%') LIMIT 5;"
                Else
                    sql = "SELECT * FROM unit WHERE (unit_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND unit_status = '" & MySqlHelper.EscapeString(filter) & "') OR (unit_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND unit_status = '" & MySqlHelper.EscapeString(filter) & "') LIMIT 5;"
                End If

            End If

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idunit"), MySqlDR("unit_name"), MySqlDR("unit_abbrev"), Convert.ToDateTime(MySqlDR("unit_reg_date")).ToString("MM-dd-yyyy"), MySqlDR("unit_status"))
            End While

            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            '   MsgBox(ex.Message)
        End Try
    End Sub

    Public Function hasAdminThanOne() As Boolean
        Dim ds As New DataSet
        Dim ctr As Integer = 0
        Dim bool As Boolean = False
        Try
            Dim sql As String = "SELECT idaccount FROM account WHERE account_type = '" & MySqlHelper.EscapeString("Admin") & "' AND account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            'check if it exist then go to catch if none
            While MySqlDR.Read
                Idaccount = MySqlDR("idaccount")
                ctr += 1
            End While
            If ctr > 1 And ctr <> 0 Then
                bool = True
            ElseIf ctr = 1 Or ctr = 0 Then
                bool = False
            End If
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
        End Try
        Return bool
    End Function

    Public Function hasAdmin() As Boolean
        Dim ds As New DataSet
        Dim ctr As Integer = 0
        Dim bool As Boolean = False
        Try
            Dim sql As String = "SELECT idaccount FROM account WHERE account_type = '" & MySqlHelper.EscapeString("Admin") & "' AND account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            'check if it exist then go to catch if none
            While MySqlDR.Read
                Idaccount = MySqlDR("idaccount")
                ctr += 1
            End While
            If ctr > 1 And ctr <> 0 Then
                bool = False
            ElseIf ctr = 0 Then
                bool = False
            ElseIf ctr = 1 Or ctr = 0 Then
                bool = True
            End If
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
        End Try
        Return bool
    End Function

    Public Function hasAdminUpdate(index As Integer) As Boolean
        Dim ds As New DataSet
        Dim ctr As Integer = 0
        Dim bool As Boolean = False
        Try
            Dim sql As String = "SELECT idaccount FROM account WHERE account_type = '" & MySqlHelper.EscapeString("Admin") & "' AND account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND idaccount != '" & MySqlHelper.EscapeString(index) & "';"
            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            'check if it exist then go to catch if none
            While MySqlDR.Read
                Idaccount = MySqlDR("idaccount")
                ctr += 1
            End While
            If ctr > 1 And ctr <> 0 Then
                bool = False
            ElseIf ctr = 0 Then
                bool = False
            ElseIf ctr = 1 Or ctr = 0 Then
                bool = True
            End If
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
        End Try
        Return bool
    End Function

    Public Function RemoveAccount() As Boolean
        Try
            Dim sql As String = "UPDATE account SET account_status = '" & MySqlHelper.EscapeString("INACTIVE") & "',account_remove_status=@0 WHERE idaccount=@1;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have remove an account : " + Account_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " remove an account :" + Account_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Account_remove_status, Idaccount)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function DeactivateAccount() As Boolean
        Try
            Dim sql As String = "UPDATE account SET account_status = '" & MySqlHelper.EscapeString("Inactive") & "' WHERE idaccount=@0;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have deactivated an account : " + Account_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " deactivated an account :" + Account_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Idaccount)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function ActivateAccount() As Boolean
        Try
            Dim sql As String = "UPDATE account SET account_status = '" & MySqlHelper.EscapeString("Active") & "' WHERE idaccount=@0;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have activated an account : " + Account_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " activated an account :" + Account_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Idaccount)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function isUnitFExist(str As String, trigger As String, Optional ByVal idUnit As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idunit FROM unit WHERE unit_name = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idunit FROM unit WHERE unit_name = '" & MySqlHelper.EscapeString(str) & "' AND idunit != '" & MySqlHelper.EscapeString(idUnit) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(Sql, getServerConnection)
            da.Fill(ds, Sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idunit")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
            Exit Function
        End Try

        Return True
    End Function

    Public Function isUnitAExist(str As String, trigger As String, Optional ByVal idUnit As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idunit FROM unit WHERE unit_abbrev = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idunit FROM unit WHERE unit_abbrev = '" & MySqlHelper.EscapeString(str) & "' AND idunit != '" & MySqlHelper.EscapeString(idUnit) & "';"
            End If
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idunit")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
            Exit Function
        End Try

        Return True
    End Function
    Public Sub LoadUnitToEdit(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM unit WHERE unit_reg_date <= CURRENT_DATE AND unit_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "'" _
                        & " AND idunit = " & MySqlHelper.EscapeString(index) & " ORDER BY idunit DESC LIMIT 1;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idunit = MySqlDR("idunit")
                Unit_name = MySqlDR("unit_name")
                Unit_abbrev = MySqlDR("unit_abbrev")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub AccountRecordCount(str As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            If str = "Active" Or str = "Inactive" Then
                sql = "SELECT count(*) FROM account WHERE account_status = '" & MySqlHelper.EscapeString(str) & "' " _
                & "AND account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            Else
                sql = "SELECT count(*) FROM account WHERE account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Account_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UnitRecordCount(str As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            If str = "Active" Or str = "Inactive" Then
                sql = "SELECT count(*) FROM unit WHERE unit_status = '" & MySqlHelper.EscapeString(str) & "' " _
                & "AND unit_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            Else
                sql = "SELECT count(*) FROM unit WHERE unit_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Unit_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function RemoveUnit() As Boolean
        Try
            Dim sql As String = "UPDATE unit SET unit_status = '" & MySqlHelper.EscapeString("Inactive") & "',unit_remove_status=@0 WHERE idunit=@1;"
            sql += "UPDATE account SET account_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' WHERE unit_idunit=@2;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have removed an unit : " + Unit_name + "and also deactivated and removed all accounts under this unit") & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " removed an unit :" + Unit_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Unit_remove_status, Idunit, Idunit)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function DeactivateUnit() As Boolean
        Try
            Dim sql As String = "UPDATE unit SET unit_status = '" & MySqlHelper.EscapeString("Inactive") & "' WHERE idunit=@0;"
            sql += "UPDATE account SET account_status = '" & MySqlHelper.EscapeString("Inactive") & "' WHERE unit_idunit=@1;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have deactivated an unit : " + Unit_name + "and also deactivated all accounts under this unit") & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " deactivated an unit :" + Unit_name + "and also deactivated all accounts under this unit") & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Idunit, Idunit)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function ActivateUnit() As Boolean
        Try
            Dim sql As String = "UPDATE unit SET unit_status = '" & MySqlHelper.EscapeString("Active") & "' WHERE idunit=@0;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have activated an unit : " + Unit_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " activated an unit :" + Unit_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Idunit)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function isExist(strUsername As String) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = "SELECT idaccount FROM account WHERE account_username = '" & MySqlHelper.EscapeString(strUsername) & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to ctch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idaccount")
        Catch ex As Exception
            'MsgBox(ex.Message)
            Return False
        End Try
        Return True
    End Function

    Public Function isRemove(strUsername As String) As Boolean
        Dim ds As New DataSet
        Dim bool As Boolean = False
        Try
            Dim sql As String = "SELECT account_remove_status FROM account WHERE account_username = '" & MySqlHelper.EscapeString(strUsername) & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim oj As Object = ds.Tables(0).Rows(0)("account_remove_status")
            If oj = "TRUE" Then
                bool = True
            Else
                bool = False
            End If
        Catch ex As Exception
            bool = False
            Return bool
        End Try
        Return bool
    End Function

    Public Function isActive(strUsername As String, strpassword As String) As Boolean
        Dim ds As New DataSet
        Dim bool As Boolean = False
        Try
            Dim sql As String = "SELECT account_status FROM account WHERE account_username = '" & MySqlHelper.EscapeString(strUsername) & "' AND account_password = '" & MySqlHelper.EscapeString(strpassword) & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim oj As Object = ds.Tables(0).Rows(0)("account_status")
            If oj = "Active" Then
                bool = True
            Else
                bool = False
            End If
        Catch ex As Exception
            bool = False
            Return bool
        End Try
        Return bool
    End Function

    Public Function isAdmin(strUsername As String, strPassword As String) As Boolean
        Dim ds As New DataSet
        Dim bool As Boolean = False
        Try
            Dim sql As String = "SELECT account_type FROM account WHERE account_username = '" & MySqlHelper.EscapeString(strUsername) & "' AND account_password = '" & MySqlHelper.EscapeString(strPassword) & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim oj As Object = ds.Tables(0).Rows(0)("account_type")
            If oj = "Admin" Then
                bool = True
            Else
                bool = False
            End If
        Catch ex As Exception
            bool = False
            Return bool
        End Try
        Return bool
    End Function

    Public Function isMatched(strUsername As String, strPassword As String) As Boolean
        Dim ds As New DataSet
        Dim bool As Boolean = False
        Try
            Dim sql As String = "SELECT idaccount FROM account WHERE account_username = '" & MySqlHelper.EscapeString(strUsername) & "' AND BINARY account_password = '" & MySqlHelper.EscapeString(strPassword) & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim oj As Object = ds.Tables(0).Rows(0)("idaccount")
            If oj <> 0 Then
                bool = True
            Else
                bool = False
            End If
        Catch ex As Exception
            bool = False
            Return bool
        End Try
        Return bool
    End Function

    Public Function isLogin(strUsername As String, strPassword As String) As Boolean
        Dim ds As New DataSet
        Dim bool As Boolean = False
        Try
            Dim sql As String = "SELECT account_isLogin FROM account WHERE account_username = '" & MySqlHelper.EscapeString(strUsername) & "' AND account_password = '" & MySqlHelper.EscapeString(strPassword) & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim oj As Object = ds.Tables(0).Rows(0)("account_isLogin")
            If oj = "TRUE" Then
                bool = True
            Else
                bool = False
            End If
        Catch ex As Exception
            bool = False
            Return bool
        End Try
        Return bool
    End Function

    Public Sub getAccountDetails(strUsername As String, strPassword As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM account INNER JOIN unit ON account.unit_idunit = unit.idunit WHERE account.account_username = '" & MySqlHelper.EscapeString(strUsername) & "' AND account.account_password = '" & MySqlHelper.EscapeString(strPassword) & "';"


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idaccount = MySqlDR("idaccount")
                Account_fn = MySqlDR("account_fn")
                Account_ln = MySqlDR("account_ln")
                Account_unit_name = MySqlDR("unit_name")
                Account_unit_abbrev = MySqlDR("unit_abbrev")
                Account_type = MySqlDR("account_type")
                Account_username = MySqlDR("account_username")
                Account_password = MySqlDR("account_password")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub getAccountDetailsSettings(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM account WHERE idaccount = '" & frmLogIn._user_id & "';"


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idaccount = MySqlDR("idaccount")
                Account_fn = MySqlDR("account_fn")
                Account_ln = MySqlDR("account_ln")
                '  Account_unit_name = MySqlDR("account_unit_name")
                '  Account_unit_abbrev = MySqlDR("account_unit_abbrev")
                Account_type = MySqlDR("account_type")
                Account_username = MySqlDR("account_username")
                Account_password = MySqlDR("account_password")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadActLogs(dgv As DataGridView, Index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM activity_logs WHERE account_idaccount = '" & MySqlHelper.EscapeString(Index) & "' AND activity_logs_date <= CURRENT_TIMESTAMP ORDER BY activity_logs_date DESC;"
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idactivity_logs"), MySqlDR("activity_logs_date"), MySqlDR("activity_logs_act_name"))
            End While


            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadAllActLogs(dgv As DataGridView)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM activity_logs WHERE activity_logs_date <= CURRENT_TIMESTAMP ORDER BY activity_logs_date DESC;"
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idactivity_logs"), MySqlDR("activity_logs_date"), MySqlDR("activity_logs_act_name"))
            End While


            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchActLogs(dgv As DataGridView, Index As Integer, str As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM activity_logs WHERE account_idaccount = '" & MySqlHelper.EscapeString(Index) & "' AND activity_logs_date <= CURRENT_TIMESTAMP ORDER BY activity_logs_date DESC;"
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idactivity_logs"), MySqlDR("activity_logs_date"), MySqlDR("activity_logs_act_name"))
            End While


            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub
End Class
