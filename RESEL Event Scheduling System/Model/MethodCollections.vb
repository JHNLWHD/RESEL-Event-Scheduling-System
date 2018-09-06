Imports System.Text
Imports MySql.Data.MySqlClient
Module MethodCollections

    Public Sub CheckforDoubleDot(tb As TextBox)
        Try
            Dim cntr As Integer = 0
            Dim theText As String = tb.Text
            Dim Letter As String
            Dim SelectionIndex As Integer = tb.SelectionStart
            Dim Change As Integer
            For x As Integer = 0 To tb.Text.Length - 1
                Letter = tb.Text.Substring(x, 1)
                If Letter = "." Then
                    cntr = cntr + 1
                End If

                If cntr > 1 Then
                    theText = ChangeSecondDot(tb.Text, x)
                    Change = 1
                End If
            Next
            tb.Text = theText
            tb.Select(SelectionIndex - Change, 0)
            If tb.Text.Length = 1 Then
                If cntr = 1 Then
                    tb.Text = "0."
                    tb.Select(2, 0)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function ChangeSecondDot(s As String, id As Integer) As String
        Dim sb As New StringBuilder(s)
        sb(id) = ""
        Return sb.ToString()
    End Function
    Public Sub NumberFormat(Text As TextBox)
        Try
            If Len(Text.Text) > 0 Then
                If Text.Text.Substring(0, 1) = "," Then
                    Text.Text = Text.Text.Remove(0, 1)
                    Exit Sub
                End If
                Text.Text = FormatNumber(CDbl(Text.Text), 0)
                Dim x As Integer = Text.SelectionStart.ToString
                If x = 0 Then
                    Text.SelectionStart = Len(Text.Text)
                    Text.SelectionLength = 0
                Else
                    Text.SelectionStart = x
                    Text.SelectionLength = 0
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Function getDate() As String

        Dim _date As String
        Try
            ConnectToServer()
            Dim cmd As New MySqlCommand()
            Dim sql As String = "select date_format(current_date(),'%M %d, %Y')"
            cmd = New MySqlCommand(sql, getServerConnection())
            _date = cmd.ExecuteScalar

        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try

        Return _date

    End Function

    Public Function getYear() As String

        Dim _date As String
        Try
            ConnectToServer()
            Dim cmd As New MySqlCommand
            Dim sql As String = "select date_format(current_date(),'%Y')"
            cmd = New MySqlCommand(sql, getServerConnection())
            _date = cmd.ExecuteScalar
        Catch ex As Exception
            Return Nothing
        End Try

        Return _date

    End Function

    Public Function getTime() As String

        Dim _date As String
        Try
            ConnectToServer()
            Dim cmd As New MySqlCommand
            Dim sql As String = "select date_format(current_time(),'%r')"
            cmd = New MySqlCommand(sql, getServerConnection())
            _date = cmd.ExecuteScalar
        Catch ex As Exception
            Return Nothing
        End Try

        Return _date

    End Function

    Public Sub keyAllow(str1 As String, txt As TextBox)
        Dim text As String = txt.Text
        Dim key As String
        Dim selectionIndex As Integer = txt.SelectionStart
        Dim change As Integer
        Dim selectionLength As Integer
        selectionLength = txt.SelectionLength

        For x As Integer = 0 To txt.TextLength - 1
            key = txt.Text.Substring(x, 1)
            If str1.Contains(key) = False Then
                text = text.Replace(key, String.Empty)
                change = 1
            End If

        Next
        txt.Text = text
        txt.SelectionStart = selectionIndex
        txt.SelectionLength = selectionIndex
    End Sub


    Public Sub ClearAll(root As Control)

        For Each ctrl As Control In root.Controls
            If TypeOf ctrl Is TabControl Then
                CType(ctrl, TextBox).Text = ""
            End If
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = ""
            End If
            If TypeOf ctrl Is ComboBox Then
                CType(ctrl, ComboBox).SelectedIndex = -1
            End If
        Next ctrl

    End Sub



    Public Function RequiredField(ParamArray obj() As Object) As Boolean
        Try
            Dim i As Integer
            For i = 0 To obj.Length - 1
                If String.IsNullOrWhiteSpace(obj(i)) = True Then
                    Return False
                End If
            Next
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function getActiveAY() As Object
        Dim ds As New DataSet
        Dim oj As Object
        Try
            Dim sql As String = "SELECT academic_year FROM academic_year WHERE academic_year_status = '" & MySqlHelper.EscapeString("ACTIVE") & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            oj = ds.Tables(0).Rows(0)("academic_year")
        Catch ex As Exception
            '        CloseSQLConnection()
            ' MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
        Return oj
    End Function


    Public Sub LoadAYToCbo(cbo As ComboBox)
        Try
            ConnectToServer()
            Dim sql As String = ""
            Dim x As Integer = 1
            sql = "SELECT * FROM unit WHERE unit_reg_date <= CURRENT_DATE AND unit_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "'" _
                        & " AND unit_status = '" & MySqlHelper.EscapeString("ACTIVE") & "' ORDER BY idunit ASC;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            cbo.Items.Clear()
            cbo.Items.Add("RESEL")
            While MySqlDR.Read
                Dim name As String = MySqlDR("unit_abbrev")
                cbo.Items.Insert(x, name)
                x += 1
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadArchiveAYToCbo(cbo As ComboBox, ay As String, ays As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM academic_year WHERE academic_year != '" & ay & "' AND academic_year_start < '" & ays & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            cbo.Items.Clear()
            While MySqlDR.Read
                Dim name As String = MySqlDR("academic_year")
                cbo.Items.Add(name)
            End While

            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadVenueToCbo(cbo As ComboBox)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM venue WHERE venue_reg_date <= CURRENT_DATE And " _
                        & "venue_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' ORDER BY idvenue DESC;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            cbo.Items.Clear()

            While MySqlDR.Read
                Dim name As String = MySqlDR("venue_name")
                cbo.Items.Add(name)
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadCollegeToCbo(cbo As ComboBox)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "SELECT * FROM college WHERE college_reg_date <= CURRENT_DATE AND college_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' ORDER BY idcollege DESC;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            cbo.Items.Clear()

            While MySqlDR.Read
                Dim name As String = MySqlDR("college_name")
                cbo.Items.Add(name)
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadTimeToCbo(cbo As ComboBox)
        Try
            Dim StartTime As Date = Date.ParseExact("00:00", "HH:mm", Nothing)
            ' Set the end time (23:55 means 11:55 PM)
            Dim EndTime As Date = Date.ParseExact("23:55", "HH:mm", Nothing)
            ' y = 0
            Dim _interval As New TimeSpan(0, 5, 0)

            cbo.Items.Clear()

            While StartTime <= EndTime
                cbo.Items.Add(StartTime.ToShortTimeString)
                StartTime = StartTime.Add(_interval)
            End While

        Catch ex As Exception

        End Try
    End Sub

    Public Function generateRandom() As String
        Dim str As String = ""
        Try
            Dim rdm As New Random()
            Dim chr As Char() = ("QWERTYUIOPLKJHGFDSAZXCVBNM").ToCharArray
            For i As Integer = 0 To 7
                str += chr(rdm.Next(0, chr.Length))
            Next
        Catch ex As Exception

        End Try

        Return str
    End Function

    Public Function generateUsername() As String
        Dim str As String = ""
        Try
            Dim rdm As New Random()
            Dim chr As Char() = ("QWERTYUIOPLKJHGFDSAZXCVBNM").ToCharArray
            For i As Integer = 0 To 4
                str += chr(rdm.Next(0, chr.Length))
            Next
        Catch ex As Exception

        End Try

        Return str
    End Function

    Public Function generatePassword() As String
        Dim str As String = ""
        Try
            Dim rdm As New Random()
            Dim chr As Char() = ("1234567890").ToCharArray
            For i As Integer = 0 To 5
                str += chr(rdm.Next(0, chr.Length))
            Next
        Catch ex As Exception

        End Try

        Return str
    End Function

    Public Function getActiveAYStart() As Object
        Dim ds As New DataSet
        Dim oj As Object
        Try
            Dim sql As String = "SELECT * FROM academic_year WHERE academic_year_status = '" & MySqlHelper.EscapeString("ACTIVE") & "';"
            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            oj = ds.Tables(0).Rows(0)("academic_year_start")
        Catch ex As Exception
            'CloseSQLConnection()
            ' MsgBox(ex.Message)
            Return Nothing
            Exit Function
        End Try
        Return oj
    End Function
End Module
