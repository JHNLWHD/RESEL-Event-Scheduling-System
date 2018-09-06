Imports MySql.Data.MySqlClient

Public Class EventClass
    Inherits CollegeClass

    Private _academic_year_idacademic_year As Integer = 0
    Public ch1 As New DataGridViewCheckBoxCell()
    Private _ideveent As Integer = 0
    Private _event_code As String = ""
    Private _event_name As String = ""
    Private _event_type As String = ""
    Private _event_number_of_participants As Integer = 0
    Private _event_acad_year As String = ""
    Private _event_priority As String = ""
    Private _event_remove_status As String = ""
    Private _event_is_cancel As String = ""
    Private _event_budget As Decimal = 0.00
    Private _event_partner_agency As String = ""
    Private _event_status As String = ""
    Private _event_remarks As String = ""
    Private _event_goal As String = ""
    Private _event_unit As String = ""
    Private _ctr As Integer = 0
    Private _idevent_clone As Integer = 0

    Private _account_idaccount As Integer = 0

    Private _idschedule As Integer = 0
    Private _schedule_date As Date
    Private _schedule_date_min As Date
    Private _schedule_date_norm As Date
    Private _schedule_start_time As TimeSpan
    Private _schedule_end_time As TimeSpan
    Private _schedule_remove_status As String = ""
    Private _schedule_acad_year As String = ""

    Private _idevent_has_schedule As Integer = 0
    Private _event_idevent As Integer = 0
    Private _schedule_idschedule As Integer = 0


    Private _idholiday As Integer = 0
    Private _holiday_name As String = ""
    Private _holiday_type As String = ""
    Private _holiday_date As Date
    Private _holiday_status As String = ""
    Private _holiday_reg_date As Date
    Private _holiday_remove_status As String = ""
    Private _holiday_count As Integer = 0

    Private _idpartner_agency As Integer = 0
    Private _partner_agency_name As String = ""
    Private _partner_agency_abbrev As String = ""
    Private _partner_agency_remove_status As String = ""
    Private _partner_agency_reg_date As Date
    Private _partner_agency_count As Integer = 0

    Private _unit_id_unit As Integer = 0
    Private _ds As New DataSet
    Private _ds1 As New DataSet

    Public Property Ideveent As Integer
        Get
            Return _ideveent
        End Get
        Set(value As Integer)
            _ideveent = value
        End Set
    End Property

    Public Property Event_code As String
        Get
            Return _event_code
        End Get
        Set(value As String)
            _event_code = value
        End Set
    End Property

    Public Property Event_name As String
        Get
            Return _event_name
        End Get
        Set(value As String)
            _event_name = value
        End Set
    End Property

    Public Property Event_type As String
        Get
            Return _event_type
        End Get
        Set(value As String)
            _event_type = value
        End Set
    End Property

    Public Property Event_number_of_participants As Integer
        Get
            Return _event_number_of_participants
        End Get
        Set(value As Integer)
            _event_number_of_participants = value
        End Set
    End Property

    Public Property Event_acad_year As String
        Get
            Return _event_acad_year
        End Get
        Set(value As String)
            _event_acad_year = value
        End Set
    End Property

    Public Property Event_priority As String
        Get
            Return _event_priority
        End Get
        Set(value As String)
            _event_priority = value
        End Set
    End Property

    Public Property Event_remove_status As String
        Get
            Return _event_remove_status
        End Get
        Set(value As String)
            _event_remove_status = value
        End Set
    End Property

    Public Property Event_is_cancel As String
        Get
            Return _event_is_cancel
        End Get
        Set(value As String)
            _event_is_cancel = value
        End Set
    End Property

    Public Property Event_budget As Decimal
        Get
            Return _event_budget
        End Get
        Set(value As Decimal)
            _event_budget = value
        End Set
    End Property

    Public Property Event_partner_agency As String
        Get
            Return _event_partner_agency
        End Get
        Set(value As String)
            _event_partner_agency = value
        End Set
    End Property

    Public Property Account_idaccount As Integer
        Get
            Return _account_idaccount
        End Get
        Set(value As Integer)
            _account_idaccount = value
        End Set
    End Property

    Public Property Idholiday As Integer
        Get
            Return _idholiday
        End Get
        Set(value As Integer)
            _idholiday = value
        End Set
    End Property

    Public Property Holiday_name As String
        Get
            Return _holiday_name
        End Get
        Set(value As String)
            _holiday_name = value
        End Set
    End Property

    Public Property Holiday_type As String
        Get
            Return _holiday_type
        End Get
        Set(value As String)
            _holiday_type = value
        End Set
    End Property

    Public Property Holiday_date As Date
        Get
            Return _holiday_date
        End Get
        Set(value As Date)
            _holiday_date = value
        End Set
    End Property

    Public Property Holiday_status As String
        Get
            Return _holiday_status
        End Get
        Set(value As String)
            _holiday_status = value
        End Set
    End Property

    Public Property Holiday_reg_date As Date
        Get
            Return _holiday_reg_date
        End Get
        Set(value As Date)
            _holiday_reg_date = value
        End Set
    End Property

    Public Property Event_status As String
        Get
            Return _event_status
        End Get
        Set(value As String)
            _event_status = value
        End Set
    End Property

    Public Property Event_remarks As String
        Get
            Return _event_remarks
        End Get
        Set(value As String)
            _event_remarks = value
        End Set
    End Property

    Public Property Event_goal As String
        Get
            Return _event_goal
        End Get
        Set(value As String)
            _event_goal = value
        End Set
    End Property

    Public Property Idschedule As Integer
        Get
            Return _idschedule
        End Get
        Set(value As Integer)
            _idschedule = value
        End Set
    End Property

    Public Property Schedule_date As Date
        Get
            Return _schedule_date
        End Get
        Set(value As Date)
            _schedule_date = value
        End Set
    End Property

    Public Property Schedule_start_time As TimeSpan
        Get
            Return _schedule_start_time
        End Get
        Set(value As TimeSpan)
            _schedule_start_time = value
        End Set
    End Property

    Public Property Schedule_end_time As TimeSpan
        Get
            Return _schedule_end_time
        End Get
        Set(value As TimeSpan)
            _schedule_end_time = value
        End Set
    End Property

    Public Property Schedule_remove_status As String
        Get
            Return _schedule_remove_status
        End Get
        Set(value As String)
            _schedule_remove_status = value
        End Set
    End Property

    Public Property Schedule_acad_year As String
        Get
            Return _schedule_acad_year
        End Get
        Set(value As String)
            _schedule_acad_year = value
        End Set
    End Property

    Public Property Idevent_has_schedule As Integer
        Get
            Return _idevent_has_schedule
        End Get
        Set(value As Integer)
            _idevent_has_schedule = value
        End Set
    End Property

    Public Property Event_idevent As Integer
        Get
            Return _event_idevent
        End Get
        Set(value As Integer)
            _event_idevent = value
        End Set
    End Property

    Public Property Schedule_idschedule As Integer
        Get
            Return _schedule_idschedule
        End Get
        Set(value As Integer)
            _schedule_idschedule = value
        End Set
    End Property

    Public Property Holiday_remove_status As String
        Get
            Return _holiday_remove_status
        End Get
        Set(value As String)
            _holiday_remove_status = value
        End Set
    End Property

    Public Property Holiday_count As Integer
        Get
            Return _holiday_count
        End Get
        Set(value As Integer)
            _holiday_count = value
        End Set
    End Property

    Public Property Idpartner_agency As Integer
        Get
            Return _idpartner_agency
        End Get
        Set(value As Integer)
            _idpartner_agency = value
        End Set
    End Property

    Public Property Partner_agency_name As String
        Get
            Return _partner_agency_name
        End Get
        Set(value As String)
            _partner_agency_name = value
        End Set
    End Property

    Public Property Partner_agency_remove_status As String
        Get
            Return _partner_agency_remove_status
        End Get
        Set(value As String)
            _partner_agency_remove_status = value
        End Set
    End Property

    Public Property Partner_agency_reg_date As Date
        Get
            Return _partner_agency_reg_date
        End Get
        Set(value As Date)
            _partner_agency_reg_date = value
        End Set
    End Property

    Public Property Partner_agency_count As Integer
        Get
            Return _partner_agency_count
        End Get
        Set(value As Integer)
            _partner_agency_count = value
        End Set
    End Property

    Public Property Academic_year_idacademic_year As Integer
        Get
            Return _academic_year_idacademic_year
        End Get
        Set(value As Integer)
            _academic_year_idacademic_year = value
        End Set
    End Property

    Public Property Event_unit As String
        Get
            Return _event_unit
        End Get
        Set(value As String)
            _event_unit = value
        End Set
    End Property

    Public Property Schedule_date_min As Date
        Get
            Return _schedule_date_min
        End Get
        Set(value As Date)
            _schedule_date_min = value
        End Set
    End Property

    Public Property Partner_agency_abbrev As String
        Get
            Return _partner_agency_abbrev
        End Get
        Set(value As String)
            _partner_agency_abbrev = value
        End Set
    End Property

    Public Property Unit_id_unit As Integer
        Get
            Return _unit_id_unit
        End Get
        Set(value As Integer)
            _unit_id_unit = value
        End Set
    End Property

    Public Property Schedule_date_norm As Date
        Get
            Return _schedule_date_norm
        End Get
        Set(value As Date)
            _schedule_date_norm = value
        End Set
    End Property

    Public Property Ctr As Integer
        Get
            Return _ctr
        End Get
        Set(value As Integer)
            _ctr = value
        End Set
    End Property

    Public Property Idevent_clone As Integer
        Get
            Return _idevent_clone
        End Get
        Set(value As Integer)
            _idevent_clone = value
        End Set
    End Property

    Sub New()
        Try
            ConnectToServer()
            Dim sql As String = ""

            Dim _acad As New AcademicYearClass
            _acad.getActiveAY()
            LoadAllIDEventsTimeTravel(_acad.Idacademic_year)

            For Each row As DataRow In _ds.Tables(0).Rows
                Ideveent = row("idevent")
                Event_name = row("event_name")
                Event_status = row("event_status")
                LoadAllDateTimeTravel(Ideveent)

                For Each row2 As DataRow In _ds1.Tables(0).Rows

                    Schedule_date_min = Convert.ToDateTime(row2("min(schedule.schedule_date)")).ToString("yyyy-MM-dd")
                    Schedule_date = Convert.ToDateTime(row2("max(schedule.schedule_date)")).ToString("yyyy-MM-dd")
                    Idevent_has_schedule = row2("idevent_has_schedule")


                    If Event_status = "Incoming" And Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") = Schedule_date_min Then
                        'update to on-going

                        Ideveent = row("idevent")
                        Event_name = row("event_name")
                        Event_status = "On-going"

                        UpdateEventStat()
                    ElseIf Event_status = "Approved" And Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") = Schedule_date Then


                        Ideveent = row("idevent")
                        Event_name = row("event_name")
                        Event_status = "On-going"

                        UpdateEventStat()

                    ElseIf Event_status = "Incoming" And (Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") >= Schedule_date_min And Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") <= Schedule_date) Then

                        Ideveent = row("idevent")
                        Event_name = row("event_name")
                        Event_status = "On-going"

                        UpdateEventStat()


                    ElseIf Event_status = "Incoming" And Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") > Schedule_date Then
                        'UPDATE TO COMPLETED
                        Ideveent = row("idevent")
                        Event_name = row("event_name")
                        Event_status = "Completed"

                        UpdateEventStat()

                    ElseIf Event_status = "On-going" And Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") > Schedule_date Then
                        'UPDATE TO COMPLETED
                        Ideveent = row("idevent")
                        Event_name = row("event_name")
                        Event_status = "Completed"

                        UpdateEventStat()

                    ElseIf Event_status = "Pending" And Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") > Schedule_date Then
                        'UPDATE TO OVERDUE`

                        Ideveent = row("idevent")
                        Event_name = row("event_name")
                        Event_status = "Overdue"

                        UpdateEventStat()

                    ElseIf Event_status = "Overdue" And Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") <= Schedule_date Then
                        'UPDATE TO OVERDUE
                        Ideveent = row("idevent")
                        Event_name = row("event_name")
                        Event_status = "Pending"

                        UpdateEventStat()

                    ElseIf Event_status = "Completed" And Convert.ToDateTime(getDate).ToString("yyyy-MM-dd") < Schedule_date_min Then
                        'UPDATE TO 
                        Ideveent = row("idevent")
                        Event_name = row("event_name")
                        Event_status = "Incoming"

                        UpdateEventStat()

                    Else
                        ' MsgBox(1)
                        Exit For
                    End If
                Next


            Next
            'MySqlDR.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Function AddEvent(str As String) As Boolean
        Try
            Dim sql As String = ""
            'load code
            sql = "INSERT INTO event(event_code,event_name,event_type,event_number_of_participants,account_idaccount,event_priority,event_remove_status," _
                & "event_is_cancel,event_budget,academic_year_idacademic_year,event_unit,event_status,event_remarks,event_reg_date,event_goal) VALUES(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,CURRENT_DATE,@13);"
            sql += "INSERT INTO event_history(event_history_name,event_history_reg_date,event_idevent) VALUES('" & Event_name + " is " + Event_status & "' ,CURRENT_DATE,(SELECT MAX(idevent) from event));"

            sql += str
            ConnectToServer()
            ServerExecuteSQL(sql, Event_code, Event_name, Event_type, Event_number_of_participants, Account_idaccount, Event_priority, Event_remove_status,
                             Event_is_cancel, Event_budget, Academic_year_idacademic_year, Event_unit, Event_status, Event_remarks, Event_goal)

        Catch ex As Exception
            'MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function


    Public Function UpdateEvent(str As String) As Boolean
        Try
            Dim sql As String = ""
            'load code
            sql = "DELETE FROM event_has_partner_agency WHERE event_idevent=@0;"
            sql += "DELETE FROM department_has_event WHERE event_idevent=@1;"
            sql += "DELETE FROM event_has_unit WHERE event_idevent=@2;"
            sql += "UPDATE event SET event_name=@3,event_type=@4,event_number_of_participants=@5,event_priority=@6," _
                & "event_budget=@7,event_goal=@8 WHERE idevent=@9;"

            sql += str
            ConnectToServer()
            ServerExecuteSQL(sql, Ideveent, Ideveent, Ideveent, Event_name, Event_type, Event_number_of_participants, Event_priority, Event_budget, Event_goal, Ideveent)
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function


    Public Function AddHoliday() As Boolean
        Try
            Dim sql As String = ""
            sql = "INSERT INTO holiday(holiday_name,holiday_type,holiday_date,holiday_status,holiday_reg_date,holiday_remove_status) VALUES(@0,@1,@2,@3,CURRENT_DATE,'" & MySqlHelper.EscapeString("FALSE") & "');"
            ConnectToServer()
            ServerExecuteSQL(sql, Holiday_name, Holiday_type, Holiday_date, Holiday_status)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateEventStat() As Boolean
        Try
            Dim sql As String = ""
            sql = "UPDATE event SET event_status =@0 WHERE idevent=@1;"
            sql += "UPDATE event_has_schedule SET event_has_schedule_status=@2 WHERE idevent_has_schedule=@3;"
            sql += "INSERT INTO event_history(event_history_name,event_history_reg_date,event_idevent) VALUES('" & Event_name + " is " + Event_status & "' ,CURRENT_DATE,@2);"


            ConnectToServer()
            ServerExecuteSQL(sql, Event_status, Ideveent, Ideveent, Event_status, Idevent_has_schedule)
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateEventStatResched() As Boolean
        Try
            Dim sql As String = ""
            sql = "UPDATE event SET event_status =@0 WHERE idevent=@1;"
            sql += "UPDATE event_has_schedule SET event_has_schedule_status=@2 WHERE event_idevent=@3;"
            sql += "INSERT INTO event_history(event_history_name,event_history_reg_date,event_idevent) VALUES('" & Event_name + " is " + Event_status & "' ,CURRENT_DATE,@2);"


            ConnectToServer()
            ServerExecuteSQL(sql, Event_status, Ideveent, Ideveent, Event_status, Ideveent)
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdateEventStatus(str As String) As Boolean
        Try
            Dim sql As String = ""
            sql = "UPDATE event SET event_status =@0 WHERE idevent=@1;"
            sql += "INSERT INTO event_history(event_history_name,event_history_reg_date,event_idevent) VALUES('" & Event_name + " is " + Event_status & "' ,CURRENT_DATE,@2);"
            sql += str

            ConnectToServer()
            ServerExecuteSQL(sql, Event_status, Ideveent, Ideveent)
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function
    Public Function UpdateHoliday() As Boolean
        Try
            Dim sql As String = ""
            sql = "UPDATE holiday Set holiday_name=@0,holiday_type=@1,holiday_date=@2 WHERE idholiday=@3;"
            ConnectToServer()
            ServerExecuteSQL(sql, Holiday_name, Holiday_type, Holiday_date, Idholiday)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function


    Public Sub LoadHolidayRecords(dgv As DataGridView, filter As String, limit As Integer, Optional ByVal status As String = "")
        Try

            Dim sql As String = ""

            If filter = "ALL" Then
                If status = "ALL" Then
                    If limit = 0 Then
                        sql = "Select * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "ORDER BY idholiday DESC;"
                    Else
                        sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "ORDER BY idholiday DESC LIMIT 5;"
                    End If
                Else
                    If limit = 0 Then
                        sql = "Select * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_status = '" & MySqlHelper.EscapeString(status) & "' ORDER BY idholiday DESC;"
                    Else
                        sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_status = '" & MySqlHelper.EscapeString(status) & "' ORDER BY idholiday DESC LIMIT 5;"
                    End If
                End If
            Else
                If status = "ALL" Then
                    If limit = 0 Then
                        sql = "Select * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_type = '" & MySqlHelper.EscapeString(filter) & "' ORDER BY idholiday DESC;"
                    Else
                        sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_type = '" & MySqlHelper.EscapeString(filter) & "' ORDER BY idholiday DESC LIMIT 5;"
                    End If
                Else
                    If limit = 0 Then
                        sql = "Select * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_type = '" & MySqlHelper.EscapeString(filter) & "' AND holiday_status = '" & MySqlHelper.EscapeString(status) & "' ORDER BY idholiday DESC;"
                    Else
                        sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_type = '" & MySqlHelper.EscapeString(filter) & "' AND holiday_status = '" & MySqlHelper.EscapeString(status) & "' ORDER BY idholiday DESC LIMIT 5;"
                    End If
                End If
            End If

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idholiday"), MySqlDR("holiday_name"), MySqlDR("holiday_type"), Convert.ToDateTime(MySqlDR("holiday_date")).ToString("MM-dd"), MySqlDR("holiday_status"))
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchHolidayRecords(dgv As DataGridView, filter As String, limit As Integer, str As String, status As String)
        Try

            Dim sql As String = ""

            If filter = "ALL" Then
                If status = "ALL" Then
                    If limit = 0 Then
                        sql = "Select * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idholiday DESC;"
                    Else
                        sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idholiday DESC LIMIT 5;"
                    End If
                Else
                    If limit = 0 Then
                        sql = "Select * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_status = '" & MySqlHelper.EscapeString(status) & "' AND holiday_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idholiday DESC;"
                    Else
                        sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_status = '" & MySqlHelper.EscapeString(status) & "' AND holiday_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idholiday DESC LIMIT 5;"
                    End If
                End If
            Else
                If status = "ALL" Then
                    If limit = 0 Then
                        sql = "Select * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_type = '" & MySqlHelper.EscapeString(filter) & "' AND holiday_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idholiday DESC;"
                    Else
                        sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_type = '" & MySqlHelper.EscapeString(filter) & "' AND holiday_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idholiday DESC LIMIT 5;"
                    End If
                Else
                    If limit = 0 Then
                        sql = "Select * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_type = '" & MySqlHelper.EscapeString(filter) & "' AND holiday_status = '" & MySqlHelper.EscapeString(status) & "' " _
                            & "AND holiday_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idholiday DESC;"
                    Else
                        sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE And holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                            & "AND holiday_type = '" & MySqlHelper.EscapeString(filter) & "' AND holiday_status = '" & MySqlHelper.EscapeString(status) & "' " _
                            & "AND holiday_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idholiday DESC LIMIT 5;"
                    End If
                End If
            End If

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idholiday"), MySqlDR("holiday_name"), MySqlDR("holiday_type"), Convert.ToDateTime(MySqlDR("holiday_date")).ToString("MM-dd"), MySqlDR("holiday_status"))
            End While
            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadHolidayToEdit(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE And holiday_status = '" & MySqlHelper.EscapeString("Active") & "' " _
                        & " AND idholiday = " & MySqlHelper.EscapeString(index) & " ORDER BY idholiday DESC LIMIT 1;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idholiday = MySqlDR("idholiday")
                Holiday_name = MySqlDR("holiday_name")
                Holiday_type = MySqlDR("holiday_type")
                Holiday_status = MySqlDR("holiday_status")
                Holiday_date = MySqlDR("holiday_date")

            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadHoliday(_date As String)
        Try

            Dim sql As String = ""

            sql = "SELECT * FROM holiday WHERE holiday_reg_date <= CURRENT_DATE AND holiday_status = '" & MySqlHelper.EscapeString("Active") & "' AND holiday_date = '" & MySqlHelper.EscapeString(_date) & "';"


            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader


            While MySqlDR.Read
                Holiday_date = MySqlDR("holiday_date")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub

    Public Function isScheduleConflict(dtpDate As String, timeStart As String, timeEnd As String, strVenue As String, acad_year As String, trigger As String, bool As String) As Boolean
        Dim ds As New DataSet
        Try
            ds.Clear()

            If bool = "TRUE" Then
                bool = "Priority"
            Else
                bool = "Non-Priority"
            End If

            Dim sql As String = ""
            sql = "SELECT *,idevent,event_name,idschedule,event_priority,idvenue FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent " _
                & "INNER JOIN schedule ON event_has_schedule.schedule_idschedule = schedule.idschedule " _
                & "INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue " _
                & "WHERE venue_has_schedule.venue_idvenue = (SELECT idvenue FROM venue WHERE venue_name = '" & MySqlHelper.EscapeString(strVenue) & "' LIMIT 1) " _
                & "AND venue_has_schedule.schedule_idschedule = (SELECT idschedule FROM schedule WHERE schedule.schedule_date = '" & MySqlHelper.EscapeString(dtpDate) & "' " _
                & "AND (schedule.schedule_start_time < TIME_FORMAT(str_to_date('" & MySqlHelper.EscapeString(timeEnd) & "','%h:%i %p'),'%T') " _
                & "AND schedule.schedule_end_time > TIME_FORMAT(str_to_date('" & MySqlHelper.EscapeString(timeStart) & "','%h:%i %p'),'%T')) " _
                & "AND schedule.academic_year_idacademic_year = '" & MySqlHelper.EscapeString(acad_year) & "' LIMIT 1) AND event.event_priority = '" & MySqlHelper.EscapeString(bool) & "' LIMIT 1;"



            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            'MsgBox("1")
            Dim oj As Object = ds.Tables(0).Rows(0)("idevent")
            Event_name = ds.Tables(0).Rows(0)("event_name")
            Idschedule = ds.Tables(0).Rows(0)("idschedule")
            Event_priority = ds.Tables(0).Rows(0)("event_priority")
            Idvenue = ds.Tables(0).Rows(0)("idvenue")
            'MsgBox("2")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
            Exit Function
        End Try

        Return True
    End Function

    Public Function isScheduleConflictResched(dtpDate As String, timeStart As String, timeEnd As String, strVenue As String, acad_year As Integer, trigger As String, bool As String, idEvent As Integer) As Boolean
        Dim ds As New DataSet
        Try
            If bool = "TRUE" Then
                bool = "Priority"
            Else
                bool = "Non-Priority"
            End If

            Dim sql As String = ""

            sql = "SELECT *,idevent,event_name,idschedule,event_priority,idvenue FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent " _
                & "INNER JOIN schedule ON event_has_schedule.schedule_idschedule = schedule.idschedule " _
                & "INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue " _
                & "WHERE venue_has_schedule.venue_idvenue = (SELECT idvenue FROM venue WHERE venue_name = '" & MySqlHelper.EscapeString(strVenue) & "' LIMIT 1) " _
                & "AND venue_has_schedule.schedule_idschedule = (SELECT idschedule FROM schedule WHERE schedule.schedule_date = '" & MySqlHelper.EscapeString(dtpDate) & "' " _
                & "AND (schedule.schedule_start_time < TIME_FORMAT(str_to_date('" & MySqlHelper.EscapeString(timeEnd) & "','%h:%i %p'),'%T') " _
                & "AND schedule.schedule_end_time > TIME_FORMAT(str_to_date('" & MySqlHelper.EscapeString(timeStart) & "','%h:%i %p'),'%T')) " _
                & "AND schedule.academic_year_idacademic_year = '" & MySqlHelper.EscapeString(acad_year) & "' LIMIT 1) AND event.event_priority = '" & MySqlHelper.EscapeString(bool) & "' AND event.idevent != '" & idEvent & "' LIMIT 1;"

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            'check if it exist then go to catch if none
            Dim oj As Object = ds.Tables(0).Rows(0)("idevent")
            Event_name = ds.Tables(0).Rows(0)("event_name")
            Idschedule = ds.Tables(0).Rows(0)("idschedule")
            Event_priority = ds.Tables(0).Rows(0)("event_priority")
            Idvenue = ds.Tables(0).Rows(0)("idvenue")
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Return False
            Exit Function
        End Try

        Return True
    End Function

    Public Function RemoveHoliday() As Boolean
        Try
            Dim sql As String = "UPDATE holiday SET holiday_status = '" & MySqlHelper.EscapeString("Inactive") & "',holiday_remove_status=@0 WHERE idholiday=@1;"
            ConnectToServer()
            ServerExecuteSQL(sql, Holiday_remove_status, Idholiday)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function DeactivateHoliday() As Boolean
        Try
            Dim sql As String = "UPDATE holiday SET holiday_status = '" & MySqlHelper.EscapeString("Inactive") & "' WHERE idholiday=@0;"
            ConnectToServer()
            ServerExecuteSQL(sql, Idholiday)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function ActivateHoliday() As Boolean
        Try
            Dim sql As String = "UPDATE holiday SET holiday_status = '" & MySqlHelper.EscapeString("Active") & "' WHERE idholiday=@0;"
            ConnectToServer()
            ServerExecuteSQL(sql, Idholiday)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Sub HolidayRecordCount(str As String, Optional ByVal str1 As String = "")
        Try
            ConnectToServer()
            Dim sql As String = ""
            If str = "INTERNATIONAL" Then
                sql = "SELECT count(*) FROM holiday WHERE holiday_type = '" & MySqlHelper.EscapeString(str) & "' " _
                     & "AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            ElseIf str = "NATIONAL" Then
                sql = "SELECT count(*) FROM holiday WHERE holiday_type = '" & MySqlHelper.EscapeString(str) & "' " _
                     & "AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            Else
                sql = "SELECT count(*) FROM holiday WHERE (holiday_type = '" & MySqlHelper.EscapeString(str) & "' " _
                     & "OR holiday_type = '" & MySqlHelper.EscapeString(str1) & "') AND holiday_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Holiday_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function AddPartnerAgency() As Boolean
        Try
            Dim sql As String = ""
            sql = "INSERT INTO partner_agency(partner_agency_name,partner_agency_remove_status,partner_agency_reg_date,partner_agency_abbrev) VALUES(@0,@1,CURRENT_DATE,@2);"
            ConnectToServer()
            ServerExecuteSQL(sql, Partner_agency_name, Partner_agency_remove_status, Partner_agency_abbrev)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function UpdatePartnerAgency() As Boolean
        Try
            Dim sql As String = ""
            sql = "UPDATE partner_agency SET partner_agency_name=@0,partner_agency_abbrev=@1 WHERE idpartner_agency=@2;"
            ConnectToServer()
            ServerExecuteSQL(sql, Partner_agency_name, Partner_agency_abbrev, Idpartner_agency)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Function RemovePartnerAgency() As Boolean
        Try
            Dim sql As String = "UPDATE partner_agency SET partner_agency_remove_status =@0 WHERE idpartner_agency=@1;"
            ConnectToServer()
            ServerExecuteSQL(sql, Partner_agency_remove_status, Idpartner_agency)
        Catch ex As Exception
            Rollback()
            Return False
        Finally
            Commit()
        End Try
        Return True
    End Function

    Public Sub LoadPartnerAgencyToEdit(index As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT * FROM partner_agency WHERE partner_agency_reg_date <= CURRENT_DATE" _
                        & " AND idpartner_agency = " & MySqlHelper.EscapeString(index) & " ORDER BY idpartner_agency DESC LIMIT 1;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Idpartner_agency = MySqlDR("idpartner_agency")
                Partner_agency_name = MySqlDR("partner_agency_name")
                Partner_agency_abbrev = MySqlDR("partner_agency_abbrev")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchPartnerAgencyRecords(dgv As DataGridView, limit As Integer, str As String)
        Try

            Dim sql As String = ""


            If limit = 0 Then
                sql = "SELECT * FROM partner_agency WHERE partner_agency_reg_date <= CURRENT_DATE AND partner_agency_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "AND partner_agency_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idpartner_agency DESC;"
            Else
                sql = "SELECT * FROM partner_agency WHERE partner_agency_reg_date <= CURRENT_DATE AND partner_agency_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "AND partner_agency_name LIKE '%" & MySqlHelper.EscapeString(str) & "%' ORDER BY idpartner_agency DESC LIMIT 5;"
            End If

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idpartner_agency"), MySqlDR("partner_agency_name"), MySqlDR("partner_agency_remove_status"), Convert.ToDateTime(MySqlDR("partner_agency_reg_date")).ToString("MM-dd-yyyy"))
            End While

            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadPartnerAgencyRecords(dgv As DataGridView, limit As Integer)
        Try

            Dim sql As String = ""

            If limit = 0 Then
                sql = "SELECT * FROM partner_agency WHERE partner_agency_reg_date <= CURRENT_DATE AND partner_agency_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "ORDER BY idpartner_agency DESC;"
            Else
                sql = "SELECT * FROM partner_agency WHERE partner_agency_reg_date <= CURRENT_DATE AND partner_agency_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "ORDER BY idpartner_agency DESC LIMIT 5;"
            End If

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idpartner_agency"), MySqlDR("partner_agency_name"), MySqlDR("partner_agency_remove_status"), Convert.ToDateTime(MySqlDR("partner_agency_reg_date")).ToString("MM-dd-yyyy"))
            End While

            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub LoadPartnerAgencyCheck(dgv As DataGridView, limit As Integer)
        Try

            Dim sql As String = ""

            If limit = 0 Then
                sql = "SELECT * FROM partner_agency WHERE partner_agency_reg_date <= CURRENT_DATE AND partner_agency_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "ORDER BY idpartner_agency DESC;"
            Else
                sql = "SELECT * FROM partner_agency WHERE partner_agency_reg_date <= CURRENT_DATE AND partner_agency_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "' " _
                        & "ORDER BY idpartner_agency DESC LIMIT 5;"
            End If

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(0, MySqlDR("idpartner_agency"), MySqlDR("partner_agency_name"))
            End While

            dgv.ClearSelection()

            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub PartnerAgencyRecordCount()
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT count(*) FROM partner_agency WHERE partner_agency_remove_status = '" & MySqlHelper.EscapeString("FALSE") & "';"



            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

            While MySqlDR.Read
                Partner_agency_count = MySqlDR("count(*)")
            End While

            MySqlDR.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadListOfEventsReports(str As String, dgv As DataGridView, fromDate As String, toDate As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            If str = "ADMIN" Then
                sql = "select * from event inner join event_has_schedule on event.idevent = event_has_schedule.event_idevent inner join schedule " _
                       & "on event_has_schedule.schedule_idschedule = schedule.idschedule where schedule.schedule_date >= '" & MySqlHelper.EscapeString(fromDate) & "' " _
                       & "and schedule.schedule_date <= '" & MySqlHelper.EscapeString(toDate) & "' group by idevent;"
            Else
                sql = "select * from event inner join event_has_schedule on event.idevent = event_has_schedule.event_idevent inner join schedule " _
                       & "on event_has_schedule.schedule_idschedule = schedule.idschedule where schedule.schedule_date >= '" & MySqlHelper.EscapeString(fromDate) & "' " _
                       & "and schedule.schedule_date <= '" & MySqlHelper.EscapeString(toDate) & "' geoup by idevent;"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_code"), MySqlDR("event_name"), MySqlDR("event_type"), MySqlDR("event_number_of_participants"), MySqlDR("event_status"))

            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub LoadListOfEvents(index As Integer, str As String, unit As String, dgv As DataGridView)
        Try
            ConnectToServer()
            Dim sql As String = ""
            If str = "ADMIN" Then
                sql = "SELECT * FROM event WHERE academic_year_idacademic_year = '" & MySqlHelper.EscapeString(index) & "';"
            Else
                sql = "SELECT * FROM event WHERE academic_year_idacademic_year = '" & MySqlHelper.EscapeString(index) & "' AND event_unit = '" & MySqlHelper.EscapeString(unit) & "';"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_code"), MySqlDR("event_name"), MySqlDR("event_type"), MySqlDR("event_number_of_participants"), MySqlDR("event_status"))

            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadListOfEventsArchive(index As String, str As String, unit As String, dgv As DataGridView)
        Try
            ConnectToServer()
            Dim sql As String = ""
            If str = "ADMIN" Then
                sql = "SELECT * FROM event WHERE academic_year = '" & MySqlHelper.EscapeString(index) & "';"
            Else
                sql = "SELECT * FROM event WHERE academic_year = '" & MySqlHelper.EscapeString(index) & "' AND event_unit = '" & MySqlHelper.EscapeString(unit) & "';"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_code"), MySqlDR("event_name"), MySqlDR("event_type"), MySqlDR("event_number_of_participants"), MySqlDR("event_status"))

            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchListOfEvents(index As Integer, str As String, unit As String, dgv As DataGridView, search As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            If str = "ADMIN" Then
                sql = "SELECT * FROM event WHERE academic_year_idacademic_year = '" & MySqlHelper.EscapeString(index) & "' AND event_name LIKE '%" & MySqlHelper.EscapeString(search) & "%';"
            Else
                sql = "SELECT * FROM event WHERE academic_year_idacademic_year = '" & MySqlHelper.EscapeString(index) & "' AND event_unit = '" & MySqlHelper.EscapeString(unit) & "' AND event_name LIKE '%" & MySqlHelper.EscapeString(search) & "%';"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_code"), MySqlDR("event_name"), MySqlDR("event_type"), MySqlDR("event_number_of_participants"), MySqlDR("event_status"))

            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadEventsByType(index As Integer, dgv As DataGridView, str As String, unit As String, type As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            If str = "ADMIN" Then
                sql = "SELECT * FROM event WHERE academic_year_idacademic_year = '" & MySqlHelper.EscapeString(index) & "' AND event_status = '" & MySqlHelper.EscapeString(type) & "';"
            Else
                sql = "SELECT * FROM event WHERE academic_year_idacademic_year = '" & MySqlHelper.EscapeString(index) & "' AND event_unit = '" & MySqlHelper.EscapeString(unit) & "' AND event_status = '" & MySqlHelper.EscapeString(type) & "';"
            End If


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_code"), MySqlDR("event_name"), MySqlDR("event_type"), MySqlDR("event_number_of_participants"), MySqlDR("event_status"))

            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadIDEvents(str As String)
        Try
            ConnectToServer()
            _ds.Clear()
            Dim da As New MySqlDataAdapter
            Dim sql As String = "select idevent from event where event_status = '" & MySqlHelper.EscapeString(str) & "';"
            da = New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(_ds)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub LoadAllIDEvents()
        Try
            ConnectToServer()
            _ds.Clear()
            '  sql = "SELECT *,max(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.idevent = '" & MySqlHelper.EscapeString(Ideveent) & "' AND event.academic_year_idacademic_year = '" & _acad.Idacademic_year & "';"
            Dim da As New MySqlDataAdapter
            Dim sql As String = "select idevent from event;"
            da = New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(_ds)
        Catch ex As Exception
            ' MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub LoadAllIDEventsTimeTravel(index As Integer)
        Try
            ConnectToServer()
            _ds.Clear()

            Dim da As New MySqlDataAdapter
            Dim sql As String = "SELECT * FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.academic_year_idacademic_year = '" & index & "';"
            da = New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(_ds)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub LoadAllDateTimeTravel(index As Integer)
        Try
            ConnectToServer()
            _ds1.Clear()

            Dim da As New MySqlDataAdapter
            Dim sql As String = "SELECT *,max(schedule.schedule_date),min(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.idevent = '" & index & "';"
            da = New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(_ds1)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Public Sub LoadEventsType(index As Integer, dgv As DataGridView, str As String, unit As String, type As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            LoadIDEvents(type)
            dgv.Rows.Clear()

            For Each row As DataRow In _ds.Tables(0).Rows
                Ideveent = row("idevent")

                If str = "ADMIN" Then
                    sql = "SELECT *,event.idevent,event.event_unit,event.event_name,min(schedule.schedule_date),max(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule " _
                        & "ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                        & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.academic_year_idacademic_year = " _
                        & "'" & MySqlHelper.EscapeString(index) & "' AND event.event_status = '" & MySqlHelper.EscapeString(type) & "' AND event.idevent = '" & MySqlHelper.EscapeString(Ideveent) & "';"
                Else
                    sql = "SELECT *,event.idevent,event.event_unit,event.event_name,min(schedule.schedule_date),max(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule " _
                        & "ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                        & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.academic_year_idacademic_year = " _
                        & "'" & MySqlHelper.EscapeString(index) & "' AND event.event_status = '" & MySqlHelper.EscapeString(type) & "' AND event.idevent = '" & MySqlHelper.EscapeString(Ideveent) & "' AND event.event_unit = '" & MySqlHelper.EscapeString(unit) & "';"
                End If

                Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
                Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

                While MySqlDR.Read
                    dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_name"), MySqlDR("venue_name"), Convert.ToDateTime(MySqlDR("min(schedule.schedule_date)")).ToString("MM-dd-yyyy"), Convert.ToDateTime(MySqlDR("max(schedule.schedule_date)")).ToString("MM-dd-yyyy"))

                End While
                dgv.ClearSelection()
                MySqlDR.Close()
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchEvents(dgv As DataGridView, index As Integer, type As String, search As String)
        Try
            ConnectToServer()
            Dim sql As String = ""

            sql = "SELECT *,event.idevent,event.event_unit,event.event_name,min(schedule.schedule_date),max(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule " _
                        & "ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                        & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.academic_year_idacademic_year = " _
                        & "'" & MySqlHelper.EscapeString(index) & "' AND event.event_status = '" & MySqlHelper.EscapeString(type) & "' AND event.event_name LIKE '%" & MySqlHelper.EscapeString(search) & "%';"


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_name"), MySqlDR("venue_name"), Convert.ToDateTime(MySqlDR("min(schedule.schedule_date)")).ToString("MM-dd-yyyy"), Convert.ToDateTime(MySqlDR("max(schedule.schedule_date)")).ToString("MM-dd-yyyy"))

            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadEventsTypeShowRecords(index As Integer, dgv As DataGridView, str As String, unit As String, type As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            LoadIDEvents(type)
            dgv.Rows.Clear()

            For Each row As DataRow In _ds.Tables(0).Rows
                Ideveent = row("idevent")

                If str = "ADMIN" Then
                    sql = "SELECT *,event.idevent,event.event_unit,event.event_name,min(schedule.schedule_date),max(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule " _
                        & "ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                        & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.academic_year_idacademic_year = " _
                        & "'" & MySqlHelper.EscapeString(index) & "' AND event.event_status = '" & MySqlHelper.EscapeString(type) & "' AND event.idevent = '" & MySqlHelper.EscapeString(Ideveent) & "';"
                Else
                    sql = "SELECT *,event.idevent,event.event_unit,event.event_name,min(schedule.schedule_date),max(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule " _
                        & "ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                        & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.academic_year_idacademic_year = " _
                        & "'" & MySqlHelper.EscapeString(index) & "' AND event.event_status = '" & MySqlHelper.EscapeString(type) & "' AND event.idevent = '" & MySqlHelper.EscapeString(Ideveent) & "' AND event.event_unit = '" & MySqlHelper.EscapeString(unit) & "';"
                End If

                Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
                Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

                While MySqlDR.Read
                    dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_name"), MySqlDR("venue_name"), Convert.ToDateTime(MySqlDR("min(schedule.schedule_date)")).ToString("MM-dd-yyyy"), Convert.ToDateTime(MySqlDR("max(schedule.schedule_date)")).ToString("MM-dd-yyyy"), MySqlDR("event_status"))

                End While
                dgv.ClearSelection()
                MySqlDR.Close()
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadAllEvents(index As Integer, dgv As DataGridView, str As String, unit As String)
        Try
            ConnectToServer()
            Dim sql As String = ""
            LoadAllIDEvents()
            dgv.Rows.Clear()

            For Each row As DataRow In _ds.Tables(0).Rows
                Ideveent = row("idevent")

                If str = "ADMIN" Then
                    sql = "SELECT *,event.idevent,event.event_unit,event.event_name,min(schedule.schedule_date),max(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule " _
                        & "ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                        & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.academic_year_idacademic_year = " _
                        & "'" & MySqlHelper.EscapeString(index) & "' AND event.idevent = '" & MySqlHelper.EscapeString(Ideveent) & "';"
                Else
                    sql = "SELECT *,event.idevent,event.event_unit,event.event_name,min(schedule.schedule_date),max(schedule.schedule_date) FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent INNER JOIN schedule " _
                        & "ON event_has_schedule.schedule_idschedule = schedule.idschedule INNER JOIN venue_has_schedule ON schedule.idschedule = venue_has_schedule.schedule_idschedule " _
                        & "INNER JOIN venue ON venue_has_schedule.venue_idvenue = venue.idvenue WHERE event.academic_year_idacademic_year = " _
                        & "'" & MySqlHelper.EscapeString(index) & "' AND event.idevent = '" & MySqlHelper.EscapeString(Ideveent) & "';"
                End If

                Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
                Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader

                While MySqlDR.Read
                    dgv.Rows.Add(MySqlDR("idevent"), MySqlDR("event_unit"), MySqlDR("event_name"), MySqlDR("venue_name"), Convert.ToDateTime(MySqlDR("min(schedule.schedule_date)")).ToString("MM-dd-yyyy"), Convert.ToDateTime(MySqlDR("max(schedule.schedule_date)")).ToString("MM-dd-yyyy"), MySqlDR("event_status"))

                End While
                dgv.ClearSelection()
                MySqlDR.Close()
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadEventsDetails(dgv As DataGridView, id As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "select *,TIME_FORMAT(schedule.schedule_start_time,'%h:%i %p'),TIME_FORMAT(schedule.schedule_end_time,'%h:%i %p') from event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent inner join schedule on event_has_schedule.schedule_idschedule = schedule.idschedule inner join venue_has_schedule on schedule.idschedule = venue_has_schedule.schedule_idschedule inner join venue on venue_has_schedule.venue_idvenue = venue.idvenue where idevent = '" & MySqlHelper.EscapeString(id) & "';"


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                Ideveent = MySqlDR("idevent")
                Event_code = MySqlDR("event_code")
                Event_name = MySqlDR("event_name")
                Event_goal = MySqlDR("event_goal")
                Event_type = MySqlDR("event_type")
                Event_number_of_participants = MySqlDR("event_number_of_participants")
                Event_unit = MySqlDR("event_unit")
                Event_priority = MySqlDR("event_priority")
                dgv.Rows.Add(MySqlDR("venue_name"), Convert.ToDateTime(MySqlDR("schedule_date")).ToString("MMMM dd, yyyy"), MySqlDR("TIME_FORMAT(schedule.schedule_start_time,'%h:%i %p')"), MySqlDR("TIME_FORMAT(schedule.schedule_end_time,'%h:%i %p')"))
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub LoadEventsDetailsToResched(dgv As DataGridView, id As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "select *,TIME_FORMAT(schedule.schedule_start_time,'%h:%i %p'),TIME_FORMAT(schedule.schedule_end_time,'%h:%i %p') from event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent inner join schedule on event_has_schedule.schedule_idschedule = schedule.idschedule inner join venue_has_schedule on schedule.idschedule = venue_has_schedule.schedule_idschedule inner join venue on venue_has_schedule.venue_idvenue = venue.idvenue where idevent = '" & MySqlHelper.EscapeString(id) & "';"


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                Ideveent = MySqlDR("idevent")
                Event_code = MySqlDR("event_code")
                Event_name = MySqlDR("event_name")
                Event_goal = MySqlDR("event_goal")
                Event_type = MySqlDR("event_type")
                Event_number_of_participants = MySqlDR("event_number_of_participants")
                Event_unit = MySqlDR("event_unit")
                Event_priority = MySqlDR("event_priority")
                Event_status = MySqlDR("event_status")
                dgv.Rows.Add(MySqlDR("idschedule"), MySqlDR("idvenue"), MySqlDR("venue_name"), Convert.ToDateTime(MySqlDR("schedule_date")).ToString("yyyy-MM-dd"), MySqlDR("TIME_FORMAT(schedule.schedule_start_time,'%h:%i %p')"), MySqlDR("TIME_FORMAT(schedule.schedule_end_time,'%h:%i %p')"), MySqlDR("event_has_schedule_status"), "", 0)
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadEventsDetailsToEdit(dgv As DataGridView, id As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "select * from event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent inner join schedule on event_has_schedule.schedule_idschedule = schedule.idschedule inner join venue_has_schedule on schedule.idschedule = venue_has_schedule.schedule_idschedule inner join venue on venue_has_schedule.venue_idvenue = venue.idvenue where idevent = '" & MySqlHelper.EscapeString(id) & "';"


            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                Ideveent = MySqlDR("idevent")
                Event_code = MySqlDR("event_code")
                Event_name = MySqlDR("event_name")
                Event_goal = MySqlDR("event_goal")
                Event_type = MySqlDR("event_type")
                Event_number_of_participants = MySqlDR("event_number_of_participants")
                Event_status = MySqlDR("event_status")
                Event_priority = MySqlDR("event_priority")
                Event_budget = MySqlDR("event_budget")
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadEventsTrack(dgv As DataGridView, id As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "select * from event_history where event_idevent = '" & MySqlHelper.EscapeString(id) & "' ORDER BY idevent_history DESC;"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            dgv.Rows.Clear()

            While MySqlDR.Read
                dgv.Rows.Add(MySqlDR("event_history_name"))
            End While
            dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try
    End Sub


    Public Sub LoadEventCollegeEdit(id As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "select * from department inner join department_has_event on department.iddepartment = department_has_event.department_iddepartment where event_idevent = '" & MySqlHelper.EscapeString(id) & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            'dgv.Rows.Clear()

            While MySqlDR.Read
                Idcollege = MySqlDR("college_idcollege")
                Iddepartment = MySqlDR("department_iddepartment")
                For Each row As DataGridViewRow In frmEditDetails.dgvCollege.Rows
                    If Idcollege = row.Cells(1).Value.ToString Then
                        row.Cells(0).Value = True
                    End If
                Next

                For Each row As DataGridViewRow In frmEditDetails.dgvDept.Rows
                    If Iddepartment = row.Cells(1).Value.ToString Then
                        row.Cells(0).Value = True
                    End If
                Next
            End While
            'dgv.ClearSelection()
            '  MySqlDR1.Close()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox("sdad" + ex.Message)
        End Try
    End Sub
    Public Sub LoadEventPA(id As Integer, dgv As DataGridView)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "select * from event_has_partner_agency where event_idevent = '" & MySqlHelper.EscapeString(id) & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            ' dgv.Rows.Clear()

            While MySqlDR.Read
                Idpartner_agency = MySqlDR("partner_agency_idpartner_agency")
                For Each row As DataGridViewRow In dgv.Rows
                    If Idpartner_agency = row.Cells(1).Value.ToString Then
                        row.Cells(0).Value = True
                    End If
                Next

            End While
            'dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub LoadEventUnit(id As Integer)
        Try
            ConnectToServer()
            Dim sql As String = ""
            sql = "select * from event_has_unit where event_idevent = '" & MySqlHelper.EscapeString(id) & "';"

            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader
            ' dgv.Rows.Clear()

            While MySqlDR.Read
                Unit_id_unit = MySqlDR("unit_idunit")
                For Each row As DataGridViewRow In frmEditDetails.dgvUnit.Rows
                    If Unit_id_unit = row.Cells(1).Value Then
                        row.Cells(0).Value = True
                        ' Exit For
                    End If
                Next

            End While
            'dgv.ClearSelection()
            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function isPartnerAgencyFExist(str As String, trigger As String, Optional ByVal idP As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idpartner_agency FROM partner_agency WHERE partner_agency_name = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idpartner_agency FROM partner_agency WHERE partner_agency_name = '" & MySqlHelper.EscapeString(str) & "' AND idpartner_agency != '" & MySqlHelper.EscapeString(idP) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim obj As Object = ds.Tables(0).Rows(0)("idpartner_agency")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Public Function isPartnerAgencyAExist(str As String, trigger As String, Optional ByVal idP As Integer = 0) As Boolean
        Dim ds As New DataSet
        Try
            Dim sql As String = ""
            If trigger = "New" Then
                sql = "SELECT idpartner_agency FROM partner_agency WHERE partner_agency_abbrev = '" & MySqlHelper.EscapeString(str) & "';"
            ElseIf trigger = "Edit" Then
                sql = "SELECT idpartner_agency FROM partner_agency WHERE partner_agency_abbrev = '" & MySqlHelper.EscapeString(str) & "' AND idpartner_agency != '" & MySqlHelper.EscapeString(idP) & "';"
            End If

            ConnectToServer()
            Dim da As New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(ds, sql)
            Dim obj As Object = ds.Tables(0).Rows(0)("idpartner_agency")
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function


    Public Sub CheckConflictToOtherEvent(idSchedule As Integer, idEvent As Integer)
        Try

            Dim sql As String = ""


            sql = "SELECT * FROM event INNER JOIN event_has_schedule ON event.idevent = event_has_schedule.event_idevent " _
               & "INNER JOIN schedule ON event_has_schedule.schedule_idschedule = schedule.idschedule " _
               & "WHERE schedule.idschedule = '" & idSchedule & "' AND event.idevent != '" & idEvent & "';"

            ConnectToServer()
            Dim MySqlCmd As MySqlCommand = New MySqlCommand(sql, getServerConnection)
            Dim MySqlDR As MySqlDataReader = MySqlCmd.ExecuteReader


            While MySqlDR.Read
                Ctr += 1
                Idevent_clone = MySqlDR("idevent")
                Event_name = MySqlDR("event_name")
            End While



            MySqlDR.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
