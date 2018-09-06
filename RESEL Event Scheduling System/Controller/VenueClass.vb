Imports MySql.Data.MySqlClient
Public Class VenueClass

    Private _idvenue As Integer = 0
    Private _venue_name As String = ""
    Private _venue_abbev As String = ""
    Private _venue_reg_date As Date
    Private _venue_count As Integer = 0
    Private _venue_remove_status As String = ""

    Public Property Idvenue As Integer
        Get
            Return _idvenue
        End Get
        Set(value As Integer)
            _idvenue = value
        End Set
    End Property

    Public Property Venue_name As String
        Get
            Return _venue_name
        End Get
        Set(value As String)
            _venue_name = value
        End Set
    End Property

    Public Property Venue_abbev As String
        Get
            Return _venue_abbev
        End Get
        Set(value As String)
            _venue_abbev = value
        End Set
    End Property

    Public Property Venue_reg_date As Date
        Get
            Return _venue_reg_date
        End Get
        Set(value As Date)
            _venue_reg_date = value
        End Set
    End Property

    Public Property Venue_remove_status As String
        Get
            Return _venue_remove_status
        End Get
        Set(value As String)
            _venue_remove_status = value
        End Set
    End Property

    Public Property Venue_count As Integer
        Get
            Return _venue_count
        End Get
        Set(value As Integer)
            _venue_count = value
        End Set
    End Property

    Public Function AddVenue() As Boolean
        Try
            'VALIDATE IF EXISTING
            Dim sql As String = "INSERT INTO venue(venue_name,venue_abbrev,venue_reg_date,venue_remove_status) VALUES(@0,@1,CURRENT_DATE,'" & MySqlHelper.EscapeString("FALSE") & "');"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have saved new venue: " + Venue_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have saved new venue: " + Venue_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Venue_name, Venue_abbev)
        Catch ex As Exception
            Rollback()
            Return False
            'MsgBox(ex.Message)
        Finally
            Commit()
        End Try
        Return True
    End Function



    Public Function isVenueFExist(str As String, trigger As String, Optional ByVal idVen As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idvenue FROM venue WHERE venue_name = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idvenue FROM venue WHERE venue_name = '" & MySqlHelper.EscapeString(str) & "' AND idvenue != '" & MySqlHelper.EscapeString(idVen) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim obj As Object = ds.Tables(0).Rows(0)("idvenue")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function isVenueAExist(str As String, trigger As String, Optional ByVal idVen As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idvenue FROM venue WHERE venue_abbrev = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idvenue FROM venue WHERE venue_abbrev = '" & MySqlHelper.EscapeString(str) & "' AND idvenue != '" & MySqlHelper.EscapeString(idVen) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim obj As Object = ds.Tables(0).Rows(0)("idvenue")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function getIDVenue(str As String) As Integer
        Dim ds As New DataSet
        Dim obj As Integer = 0
        Try
            Dim sql As String = ""
            sql = "SELECT idvenue FROM venue WHERE venue_name = '" & MySqlHelper.EscapeString(str) & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            obj = ds.Tables(0).Rows(0)("idvenue")
        Catch ex As Exception
            Return 0
            Exit Function
        End Try
        Return obj
    End Function

    Public Function UpdateVenue() As Boolean
        Try
            Dim sql As String = ""
            sql = "UPDATE venue Set venue_name =@0,venue_abbrev=@1 WHERE idvenue=@2;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have updated a venue to: " + Venue_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have updated a venue to: " + Venue_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Venue_name, Venue_abbev, Idvenue)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function


    Public Function RemoveVenue() As Boolean
        Try
            Dim sql As String = "UPDATE venue SET venue_remove_status=@0 WHERE idvenue=@1;"
            sql += "INSERT INTO activity_logs(activity_logs_myact_name,activity_logs_act_name,activity_logs_date,account_idaccount) " _
                & "VALUES('" & MySqlHelper.EscapeString("You have removed a venue: " + Venue_name) & "'," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_name + " have removed a venue: " + Venue_name) & "',CURRENT_TIMESTAMP," _
                & "'" & MySqlHelper.EscapeString(frmLogIn._user_id) & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Venue_remove_status, Idvenue)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Sub LoadVenueRecords(dgv As DataGridView, limit As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            If limit = 0 Then
                sql = "SELECT * FROM venue WHERE venue_reg_date <= CURRENT_DATE And " _
                        & "venue_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' ORDER BY idvenue DESC;"
            Else
                sql = "SELECT * FROM venue WHERE venue_reg_date <= CURRENT_DATE AND " _
                        & "venue_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' ORDER BY idvenue DESC LIMIT 5;"
            End If

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idvenue"), MySqlDR("venue_name"), MySqlDR("venue_abbrev"))
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchVenueRecords(dgv As DataGridView, str As String, limit As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            If limit = 0 Then
                sql = "SELECT * FROM venue WHERE (venue_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND venue_reg_date <= CURRENT_DATE AND " _
                        & "venue_remove_status LIKE '%" & MySqlHelper.EscapeString("FALSE") & "%') OR (venue_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND venue_reg_date <= CURRENT_DATE AND " _
                        & "venue_remove_status LIKE '%" & MySqlHelper.EscapeString("FALSE") & "%') ORDER BY idvenue DESC;"
            Else
                sql = "SELECT * FROM venue WHERE (venue_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND venue_reg_date <= CURRENT_DATE AND " _
                        & "venue_remove_status LIKE '%" & MySqlHelper.EscapeString("FALSE") & "%') OR (venue_abbrev LIKE '%" & MySqlHelper.EscapeString(str) & "%' AND venue_reg_date <= CURRENT_DATE AND " _
                        & "venue_remove_status LIKE '%" & MySqlHelper.EscapeString("FALSE") & "%') ORDER BY idvenue DESC LIMIT 5;"
            End If

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idvenue"), MySqlDR("venue_name"), MySqlDR("venue_abbrev"))
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadVenueToEdit(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM venue WHERE venue_reg_date <= CURRENT_DATE AND venue_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "AND idvenue = " & MySqlHelper.EscapeString(index) & ";"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idvenue = MySqlDR("idvenue")
                Venue_name = MySqlDR("venue_name")
                Venue_abbev = MySqlDR("venue_abbrev")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub VenueRecordCount()
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT count(*) FROM venue WHERE venue_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"



            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Venue_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

End Class
