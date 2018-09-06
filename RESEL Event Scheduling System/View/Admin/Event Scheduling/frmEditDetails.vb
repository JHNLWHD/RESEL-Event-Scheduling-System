Imports MySql.Data.MySqlClient
Public Class frmEditDetails
    Public _flag As String = ""
    Public _acad_year_obj As AcademicYearClass
    Public _event_obj As EventClass
    Public _college_obj As New CollegeClass
    Public _venue As VenueClass
    Public _acc As AccountClass
    Dim _prio As String = ""
    Public str As String = ""
    Public strpa As String = ""
    Public strStartTime As String = ""
    Public strEndTime As String = ""
    Public _event_Stat As Integer = 0
    Public _prio_Stat As Integer = 0
    'IF 0 then APPROVED ELSE PENDING
    ' Dim myList As New List(Of String)()
    Dim keyNum As String = "0987654321"
    Public Shared idC As Integer = 0
    Public strQuery As String = ""
    Private _ds As DataSet

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dispose()
            Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _event_obj = New EventClass

            _event_obj.Event_code = txtCode.Text
            Dim dept_unit_check, pa_check As Integer
            dept_unit_check = 0
            pa_check = 0
            With _event_obj
                For Each row As DataGridViewRow In dgvDept.Rows
                    If row.Cells(0).Value.ToString = True Then

                        dept_unit_check = 1
                    Else
                        ' Exit Sub
                    End If
                Next

                For Each row As DataGridViewRow In dgvPA.Rows
                    If row.Cells(0).Value.ToString = True Then

                        pa_check = 1
                    Else
                        ' Exit Sub
                    End If
                Next

                For Each row As DataGridViewRow In dgvUnit.Rows
                    If row.Cells(0).Value.ToString = True Then

                        dept_unit_check = 1
                    Else
                        ' Exit Sub
                    End If
                Next
                If pa_check = 1 And dept_unit_check = 1 Then
                    .Ideveent = idC
                    .Event_code = txtCode.Text
                    .Event_name = txtTitleOfActivity.Text
                    .Event_budget = txtBudget.Text
                    .Event_goal = txtGoal.Text
                    .Event_number_of_participants = Decimal.Parse(txtNumberOfParticipants.Text)
                    _acad_year_obj.getActiveAY()

                    .Event_priority = _prio
                    .Event_type = txtType.Text
                    .Event_remove_status = "FALSE"
                    .Event_is_cancel = "FALSE"
                    .Event_remarks = ""
                    .Account_idaccount = frmLogIn._user_id
                    .Event_status = txtStatus.Text
                    .Event_unit = frmHome.lblUnit.Text
                    If .UpdateEvent(strQuery) = True Then
                        MsgBox("This event has been updated")
                        Try
                            _event_obj = New EventClass
                            _acad_year_obj = New AcademicYearClass
                            _acad_year_obj.getActiveAY()

                            With _event_obj
                                .LoadListOfEvents(_acad_year_obj.Idacademic_year, frmLogIn._user_type, frmLogIn._user_unit_abbrev, ListofEvents.dgvEvents)
                            End With
                        Catch ex As Exception

                        End Try
                        Dispose()
                        Close()
                    Else
                        MsgBox("This event has not been updated")
                        Exit Sub
                    End If
                Else
                    MsgBox("All fields required")
                End If

            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmEditDetails_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmEditDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _acad_year_obj = New AcademicYearClass
            _event_obj = New EventClass
            '_college_obj = New CollegeClass
            _acc = New AccountClass
            'For Each row As DataGridViewRow In dgvPA.Rows
            _event_obj.LoadPartnerAgencyCheck(dgvPA, 0)
            _event_obj.LoadEventPA(idC, dgvPA)
            _event_obj.LoadCollegeToSched(dgvCollege)
            _event_obj.LoadEventCollegeEdit(idC)
            For Each row As DataGridViewRow In dgvCollege.Rows
                If row.Cells(0).Value = True Then
                    _event_obj.LoadDeptByCollegeEventsEdit(dgvDept, row.Cells(1).Value.ToString)
                End If
            Next
            _event_obj.LoadEventCollegeEdit(idC)
            _event_obj.LoadEventUnit(idC)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkPriority_CheckedChanged(sender As Object, e As EventArgs) Handles chkPriority.CheckedChanged
        Try
            If chkPriority.Checked = True Then
                _prio = "True"
            Else
                _prio = "False"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvPA_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPA.CellContentClick
        Try
            If e.ColumnIndex = 0 Then

                If dgvPA.SelectedRows(0).Cells(0).Value = False Then
                    dgvPA.SelectedRows(0).Cells(0).Value = True
                    strQuery += "INSERT INTO event_has_partner_agency(event_idevent,partner_agency_idpartner_agency) " _
                                & "VALUES('" & MySqlHelper.EscapeString(idC) & "','" & dgvPA.SelectedRows(0).Cells(1).Value & "');"
                Else
                    dgvPA.SelectedRows(0).Cells(0).Value = False
                    strQuery += "DELETE FROM event_has_partner_agency WHERE event_idevent = '" & MySqlHelper.EscapeString(idC) & "' " _
                                & "AND partner_agency_idpartner_agency = '" & dgvPA.SelectedRows(0).Cells(1).Value & "';"
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvUnit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUnit.CellContentClick
        Try
            If e.ColumnIndex = 0 Then

                If dgvUnit.SelectedRows(0).Cells(0).Value = False Then
                    dgvUnit.SelectedRows(0).Cells(0).Value = True
                    strQuery += "INSERT INTO event_has_unit(event_idevent,unit_idunit) " _
                                & "VALUES('" & MySqlHelper.EscapeString(idC) & "','" & dgvUnit.SelectedRows(0).Cells(1).Value & "');"
                Else
                    dgvUnit.SelectedRows(0).Cells(0).Value = False
                    strQuery += "DELETE FROM event_has_unit WHERE event_idevent = '" & MySqlHelper.EscapeString(idC) & "' " _
                                & "AND unit_idunit = '" & dgvUnit.SelectedRows(0).Cells(1).Value & "';"
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvCollege_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCollege.CellContentClick
        Try
            If e.ColumnIndex = 0 Then

                dgvDept.Rows.Clear()
                If dgvCollege.SelectedRows(0).Cells(0).Value = False Then
                    dgvCollege.SelectedRows(0).Cells(0).Value = True
                    'strQuery += "INSERT INTO event_has_unit(event_idevent,unit_idunit) " _
                    '           & "VALUES('" & MySqlHelper.EscapeString(idC) & "','" & dgvUnit.SelectedRows(0).Cells(1).Value & "');"
                Else
                    dgvCollege.SelectedRows(0).Cells(0).Value = False
                    'Delete all department under this college (check/uncheck)
                    Dim _idDeptCheck As Integer = 0
                    For Each rowc As DataGridViewRow In dgvCollege.Rows
                        LoadDeptID(idC, rowc.Cells(1).Value.ToString)
                        For Each row As DataRow In _ds.Tables(0).Rows
                            'get id department
                            'select departmnt_has_event for 
                            _idDeptCheck = row("iddepartment")
                            strQuery += "DELETE FROM department_has_event WHERE event_idevent = '" & MySqlHelper.EscapeString(idC) & "' " _
                                & "AND department_iddepartment = '" & _idDeptCheck & "';"
                        Next
                    Next


                End If
                For Each row As DataGridViewRow In dgvCollege.Rows
                    If row.Cells(0).Value = True Then
                        _college_obj.LoadDeptByCollegeEvents(dgvDept, row.Cells(1).Value)
                        For Each row2 As DataGridViewRow In dgvDept.Rows
                            If row2.Cells(0).Value = True Then
                                strQuery += "INSERT INTO department_has_event(event_idevent,department_iddepartment,department_has_event_reg_date) " _
                                & "VALUES('" & MySqlHelper.EscapeString(idC) & "','" & row2.Cells(1).Value.ToString & "',CURRENT_DATE);"
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvDept_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDept.CellContentClick
        Try
            Try
                If e.ColumnIndex = 0 Then

                    If dgvDept.SelectedRows(0).Cells(0).Value = False Then
                        dgvDept.SelectedRows(0).Cells(0).Value = True
                        strQuery += "INSERT INTO department_has_event(event_idevent,department_iddepartment,department_has_event_reg_date) " _
                                & "VALUES('" & MySqlHelper.EscapeString(idC) & "','" & dgvDept.SelectedRows(0).Cells(1).Value.ToString & "',CURRENT_DATE);"
                    Else
                        dgvDept.SelectedRows(0).Cells(0).Value = False
                        strQuery += "DELETE FROM department_has_event WHERE event_idevent = '" & MySqlHelper.EscapeString(idC) & "' " _
                               & "AND department_iddepartment = '" & dgvDept.SelectedRows(0).Cells(1).Value & "';"
                    End If

                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDeptID(index As Integer, index2 As Integer)
        Try
            ConnectToServer()
            _ds.Clear()

            Dim da As New MySqlDataAdapter
            Dim sql As String = ""
            sql = "SELECT * FROM event INNER JOIN department_has_event ON event.idevent = department_has_event.event_idevent " _
                    & "INNER JOIN department ON department_has_event.department_iddepartment = department.iddepartment " _
                    & "INNER JOIN college ON department.college_idcollege = college.idcollege " _
                    & "WHERE event.idevent = '" & index & "' AND college.idcollege = '" & index2 & "';"
            da = New MySqlDataAdapter(sql, getServerConnection)
            da.Fill(_ds)
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub
End Class