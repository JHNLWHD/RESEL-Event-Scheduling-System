Imports MySql.Data.MySqlClient

Public Class CollegeClass
    Inherits VenueClass

    Private _idcollege As Integer = 0
    Private _college_name As String = ""
    Private _college_abbrev As String = ""
    Private _college_reg_date As Date
    Private _college_remove_status As String = ""
    Private _college_count As Integer = 0

    Private _iddepartment As Integer = 0
    Private _department_name As String = ""
    Private _department_abbrev As String = ""
    Private _department_reg_date As Date
    Private _department_remove_status As String = ""
    Private _dept_count As Integer = 0

    Public Property Idcollege As Integer
        Get
            Return _idcollege
        End Get
        Set(value As Integer)
            _idcollege = value
        End Set
    End Property

    Public Property College_name As String
        Get
            Return _college_name
        End Get
        Set(value As String)
            _college_name = value
        End Set
    End Property

    Public Property College_abbrev As String
        Get
            Return _college_abbrev
        End Get
        Set(value As String)
            _college_abbrev = value
        End Set
    End Property

    Public Property College_reg_date As Date
        Get
            Return _college_reg_date
        End Get
        Set(value As Date)
            _college_reg_date = value
        End Set
    End Property

    Public Property College_remove_status As String
        Get
            Return _college_remove_status
        End Get
        Set(value As String)
            _college_remove_status = value
        End Set
    End Property

    Public Property Iddepartment As Integer
        Get
            Return _iddepartment
        End Get
        Set(value As Integer)
            _iddepartment = value
        End Set
    End Property

    Public Property Department_name As String
        Get
            Return _department_name
        End Get
        Set(value As String)
            _department_name = value
        End Set
    End Property

    Public Property Department_abbrev As String
        Get
            Return _department_abbrev
        End Get
        Set(value As String)
            _department_abbrev = value
        End Set
    End Property

    Public Property Department_reg_date As Date
        Get
            Return _department_reg_date
        End Get
        Set(value As Date)
            _department_reg_date = value
        End Set
    End Property

    Public Property Department_remove_status As String
        Get
            Return _department_remove_status
        End Get
        Set(value As String)
            _department_remove_status = value
        End Set
    End Property

    Public Property College_count As Integer
        Get
            Return _college_count
        End Get
        Set(value As Integer)
            _college_count = value
        End Set
    End Property

    Public Property Dept_count As Integer
        Get
            Return _dept_count
        End Get
        Set(value As Integer)
            _dept_count = value
        End Set
    End Property

    Public Function AddCollege() As Boolean
        Try
            Dim sql As String = "INSERT INTO college(college_name,college_abbrev,college_reg_date,college_remove_status) VALUES(@0,@1,CURRENT_DATE,'" & MySqlHelper.EscapeString("FALSE") & "');"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have saved new college: " + College_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have saved new college: " + College_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, College_name, College_abbrev)
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function AddDepartment() As Boolean
        Try
            Dim sql As String = "INSERT INTO department(department_name,department_abbrev,department_reg_date,department_remove_status,college_idcollege) VALUES(@0,@1,CURRENT_DATE,'" & MySqlHelper.EscapeString("FALSE") & "',@2);"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have saved new department: " + Department_name + " to college: " + College_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have saved new department: " + Department_name + " to college: " + College_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Department_name, Department_abbrev, Idcollege)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function


    Public Function UpdateCollege() As Boolean
        Try
            'Check if duplicate
            Dim sql As String = "UPDATE college SET college_name=@0,college_abbrev=@1 WHERE idcollege =@2;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have updated a college to: " + College_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have updated a college to: " + College_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, College_name, College_abbrev, Idcollege)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateDepartment() As Boolean
        Try
            'Check if duplicate
            Dim sql As String = "UPDATE department SET department_name=@0,department_abbrev=@1 WHERE iddepartment=@2;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have updated a department to: " + Department_name + " by college: " + College_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have updpated a department to: " + Department_name + " to college: " + College_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Department_name, Department_abbrev, Iddepartment)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function RemoveCollege() As Boolean
        Try
            'Check if duplicate
            Dim sql As String = "UPDATE college SET college_remove_status=@0 WHERE idcollege =@1;"
            sql += "UPDATE department SET department_remove_status=@2 WHERE college_idcollege =@3;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have removed a college: " + College_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have removed a college: " + College_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, College_remove_status, Idcollege, Department_remove_status, Idcollege)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    'Public Function RemoveDepartment() As Boolean
    '    Try
    '        'Check if duplicate         
    '        Dim sql As String = "UPDATE department SET department_remove_status=@0 WHERE college_idcollege =@1;"
    '        sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
    '            & "VALUES('" & MySqlHelper.EscapeString("YOU HAVE REMOVED A DEPARTMENT: " + Department_name + " BY COLLEGE " + College_name) & "'," _
    '            & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " HAVE REMOVED A DEPARTMENT: " + Department_name + " BY COLLEGE " + College_name) & "',CURRENT_TIMESTAMP," _
    '            & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
    '        ConnectToServer()
    '        ServerExecuteSQL(sql, Department_remove_status, Idcollege)
    '    Catch ex As Exception
    '        Rollback()
    '        Return False
    '    Finally
    '        Commit()
    '    End Try
    '    Return True
    'End Function

    Public Function RemoveDepartmentRecord() As Boolean
        Try
            'Check if duplicate
            Dim sql As String = "UPDATE department SET department_remove_status=@0 WHERE iddepartment =@1;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have removed a department : " + Department_name + " by college: " + College_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have updpated a department : " + Department_name + " to college: " + College_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Department_remove_status, Iddepartment)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function


    Public Function isCollegeFExist(str As String, trigger As String, Optional ByVal idCollege As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idcollege FROM college WHERE college_name = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idcollege FROM college WHERE college_name = '" & MySqlHelper.EscapeString(str) & "' AND idcollege != '" & MySqlHelper.EscapeString(idCollege) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim obj As Object = ds.Tables(0).Rows(0)("idcollege")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


    Public Function isCollegeAExist(str As String, trigger As String, Optional ByVal idCollege As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idcollege FROM college WHERE college_abbrev = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idcollege FROM college WHERE college_abbrev = '" & MySqlHelper.EscapeString(str) & "' AND idcollege != '" & MySqlHelper.EscapeString(idCollege) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim obj As Object = ds.Tables(0).Rows(0)("idcollege")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function isDeptFExist(str As String, trigger As String, Optional ByVal idDept As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT iddepartment FROM department WHERE department_name = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT iddepartment FROM department WHERE department_name = '" & MySqlHelper.EscapeString(str) & "' AND iddepartment != '" & MySqlHelper.EscapeString(idDept) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim obj As Object = ds.Tables(0).Rows(0)("iddepartment")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


    Public Function isDeptAExist(str As String, trigger As String, Optional ByVal idDept As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT iddepartment FROM department WHERE department_abbrev = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT iddepartment FROM department WHERE department_abbrev = '" & MySqlHelper.EscapeString(str) & "' AND iddepartment != '" & MySqlHelper.EscapeString(idDept) & "';"
            End If
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim obj As Object = ds.Tables(0).Rows(0)("iddepartment")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Sub SearchCollegeRecords(dgv As DataGridView, str As String, limit As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            If limit = 0 Then
                sql = "SELECT * FROM college WHERE (college_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND college_reg_date <= CURRENT_DATE AND " _
                        & "college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') OR (college_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND college_reg_date <= CURRENT_DATE AND " _
                        & "college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') ORDER BY idcollege DESC;"
            Else
                sql = "SELECT * FROM college WHERE (college_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND college_reg_date <= CURRENT_DATE AND " _
                        & "college_remove_status LIKE '%" & MySqlHelper.EscapeString("FALSE") & "%') OR (college_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND college_reg_date <= CURRENT_DATE AND " _
                        & "college_remove_status LIKE '%" & MySqlHelper.EscapeString("FALSE") & "%') ORDER BY idcollege DESC LIMIT 5;"
            End If

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idcollege"), MySqlDR("college_name"), MySqlDR("college_abbrev"), Convert.ToDateTime(MySqlDR("college_reg_date")).ToString("MM-dd-yyyy"))
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadCollegeRecords(dgv As DataGridView, limit As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            If limit = 0 Then
                sql = "SELECT * FROM college WHERE college_reg_date <= CURRENT_DATE AND college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' ORDER BY idcollege DESC;"
            Else
                sql = "SELECT * FROM college WHERE college_reg_date <= CURRENT_DATE AND college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' ORDER BY idcollege DESC LIMIT 5;"
            End If

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idcollege"), MySqlDR("college_name"), MySqlDR("college_abbrev"), Convert.ToDateTime(MySqlDR("college_reg_date")).ToString("MM-dd-yyyy"))
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadCollege(limit As Integer, index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            If limit = 0 Then
                sql = "SELECT * FROM college WHERE college_reg_date <= CURRENT_DATE AND college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND idcollege = '" & MySqlHelper.EscapeString(index) & "' ORDER BY idcollege DESC LIMIT 1;"
            Else
                sql = "SELECT * FROM college WHERE college_reg_date <= CURRENT_DATE AND college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' AND idcollege = '" & MySqlHelper.EscapeString(index) & "' ORDER BY idcollege DESC LIMIT 5;"
            End If

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader


            While MySqlDR.Read
                College_name = MySqlDR("college_name")
                College_abbrev = MySqlDR("college_abbrev")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadCollegeToEdit(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM college WHERE college_reg_date <= CURRENT_DATE AND college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & " AND idcollege = " & MySqlHelper.EscapeString(index) & " ORDER BY idcollege DESC LIMIT 1;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idcollege = MySqlDR("idcollege")
                College_name = MySqlDR("college_name")
                College_abbrev = MySqlDR("college_abbrev")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadDeptByCollege(dgv As DataGridView, index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM department WHERE department_reg_date <= CURRENT_DATE AND department_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & " AND college_idcollege = " & MySqlHelper.EscapeString(index) & " ORDER BY iddepartment DESC;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read

                dgv.Rows.Add(MySqlDR("iddepartment"), MySqlDR("department_name"), MySqlDR("department_abbrev"))
            End While
            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadDeptByCollegeEvents(dgv As DataGridView, index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM department WHERE department_reg_date <= CURRENT_DATE AND department_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & " AND college_idcollege = " & MySqlHelper.EscapeString(index) & " ORDER BY iddepartment DESC;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            'dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(0, MySqlDR("iddepartment"), MySqlDR("department_name"), MySqlDR("college_idcollege"))
            End While

            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadDeptByCollegeEventsEdit(dgv As DataGridView, index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM department WHERE department_reg_date <= CURRENT_DATE AND department_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & " AND college_idcollege = " & MySqlHelper.EscapeString(index) & " ORDER BY iddepartment DESC;"

            Dim MySqlCmd2 As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR2 As MySqlDataReader = MySqlCmd2.ExecuteReader

            'dgv.Rows.Clear()

            While MySqlDR2.Read
                dgv.Rows.Add(0, MySqlDR2("iddepartment"), MySqlDR2("department_name"), MySqlDR2("college_idcollege"))
            End While

            dgv.ClearSelection()

            MySqlDR2.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub LoadCollegeToSched(dgv As DataGridView)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM college WHERE college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(0, MySqlDR("idcollege"), MySqlDR("college_abbrev"))
            End While
            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadDepartment(dgv As DataGridView)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM department WHERE department_reg_date <= CURRENT_DATE AND department_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "'" _
                        & " ORDER BY iddepartment DESC;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("iddepartment"), MySqlDR("department_name"), MySqlDR("department_abbrev"), Convert.ToDateTime(MySqlDR("department_reg_date")).ToString("MM-dd-yyyy"), MySqlDR("college_idcollege"))
            End While

            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            '    MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchDepartment(dgv As DataGridView, str As String)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM department WHERE (department_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND department_reg_date <= CURRENT_DATE AND department_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "')" _
                        & " OR (department_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND department_reg_date <= CURRENT_DATE AND department_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "') ORDER BY iddepartment DESC;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("iddepartment"), MySqlDR("department_name"), MySqlDR("department_abbrev"), Convert.ToDateTime(MySqlDR("department_reg_date")).ToString("MM-dd-yyyy"), MySqlDR("college_idcollege"))
            End While

            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub getIDCollege(str As String)
        Try
            Dim sql As String = ""
            sql = "SELECT * FROM college WHERE college_abbrev = '" & MySqlHelper.EscapeString(str) & "' LIMIT 1;"
            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idcollege = MySqlDR("idcollege")
            End While

            MySqlDR.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub CollegeRecordCount()
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT count(*) FROM college WHERE college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                College_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DeptRecordCount()
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT count(*) FROM department WHERE department_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Dept_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
End Class
