'Author : Al-Jhoenil D. Wahid
'Created Date : 1/11/2017
Imports MySql.Data.MySqlClient
Module ConnectionAdapter

    Private Connection As New MySqlConnection
    Private Transaction As MySqlTransaction
    Private ConnectionString As String = "server=" & My.Settings.Server & ";user id=" & My.Settings.User & ";persistsecurityinfo=True;database=" & My.Settings.Database & ";Password=" & My.Settings.Password & ";"

    Public Function TestConnection(str As String) As Boolean
        Try
            If Connection.State = ConnectionState.Open Then
                CloseSQLConnection()
            End If
            Connection.ConnectionString = str
            Connection.Open()
            Transaction = Connection.BeginTransaction
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Connect() As Boolean
        Dim bool As Boolean = False
        Try
            If ConnectToServer() = True Then
                bool = True
                frmHome.lblConn.Text = "Connection Status: Connected"
                ' Return bool
            Else
                bool = False
                frmHome.lblConn.Text = "Connection Status: Disconnected"
                ' Return bool
            End If
        Catch ex As Exception
            Return False
        End Try
        Return bool
    End Function

    Public Function ConnectToServer() As Boolean
        Try
            If Connection.State = ConnectionState.Open Then
                CloseSQLConnection()
            End If
            Connection.ConnectionString = ConnectionString
            Connection.Open()
            Transaction = Connection.BeginTransaction
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Create Update Delete Queries Execution
    Public Sub ServerExecuteSQL(sql As String, ParamArray obj() As Object)
        Dim cmd As New MySqlCommand(sql, Connection, Transaction)
        Dim i As Integer
        For i = 0 To obj.Length - 1
            cmd.Parameters.AddWithValue("@" & i, obj(i))
        Next
        cmd.ExecuteNonQuery()
        cmd.Dispose()
    End Sub

    Public Sub Commit()
        Transaction.Commit()
        Transaction = Connection.BeginTransaction
    End Sub

    Public Sub Rollback()
        Transaction.Rollback()
        Transaction = Connection.BeginTransaction
    End Sub

    Public Sub CloseSQLConnection()
        Connection.Close()
    End Sub

    Public Function getServerConnection() As MySqlConnection
        Return Connection
    End Function

    Public Function getConnectionString() As String
        Return ConnectionString
    End Function
    Public Sub databaseBackup(str As String)
        Try
            ConnectionString += "charset=utf8;convertzerodatetime=true;"
            ConnectToServer()
            Dim cmd As MySqlCommand = New MySqlCommand
            Dim backup As MySqlBackup = New MySqlBackup(cmd)
            backup.ExportToFile(str)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub databaseRestore(str As String)
        Try
            ConnectionString += "charset=utf8;convertzerodatetime=true;"
            ConnectToServer()
            Dim cmd As MySqlCommand = New MySqlCommand
            Dim backup As MySqlBackup = New MySqlBackup(cmd)
            backup.ImportFromFile(str)
        Catch ex As Exception

        End Try
    End Sub

End Module