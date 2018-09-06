Public Class frmManageAcademicYear

    Public _acad_year_obj As AcademicYearClass
    Dim _num As String = "0987654321"
    Dim _year As String = "0987654321 -"
    Dim _flag As String = ""
    Public Shared idAY As Integer = 0

    Private Sub frmManageAcademicYear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Controls orientation
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcAYInfo.Enabled = False
            tcSearch.Enabled = True
            dtpStart.ResetText()
            dtpEnd.ResetText()
            btnNew.Focus()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
Here:
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                If .hasActiveDateSettings = True Then
                    _flag = "New"
                    btnNew.Enabled = False
                    btnSave.Enabled = True
                    tcAYInfo.Enabled = True
                    tcSearch.Enabled = False
                    dtpEnd.Enabled = False
                    txtSearch.Clear()
                    dgvList.Rows.Clear()
                    '.getActiveAY()
                    'dtpStart.MinDate = Date.Parse(.Academic_year_start)
                Else
                    MessageBox.Show("There is none active date settings." + vbCrLf + "Date Settings form will be loaded.", "Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    frmSetDateSetttings.ShowDialog()
                    GoTo Here
                End If
            End With

            'txtFrom.Enabled = True

        Catch ex As Exception
            'MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _acad_year_obj = New AcademicYearClass
            If _flag.Equals("New") = True Then
                If RequiredField(dtpStart.Value.ToShortDateString, dtpEnd.Value.ToShortDateString) = True Then
                    With _acad_year_obj
                        If dtpStart.Value.Year < dtpEnd.Value.Year Then
                            If .isAYExist(dtpStart.Value.ToString("yyyy"), dtpEnd.Value.ToString("yyyy"), "New") = True Then
                                MsgBox("Calendar Year already exist.")
                                Exit Sub
                            Else
                                'If .isAYConflict(dtpStart.Value.ToString("yyyy"), dtpEnd.Value.ToString("yyyy"), "New") = True Then
                                '    MessageBox.Show("Academic Year is conflict with " + .Academic_year, "Register New Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                '    Exit Sub
                                'Else
                                If .hasActive = True Then
                                    .Academic_year_start = dtpStart.Value.Year
                                    .Academic_year_end = dtpEnd.Value.Year
                                    .Academic_year_status = "Inactive"
                                    .Academic_year_remove_status = "FALSE"
                                    .Academic_year = String.Format("{0} - {1}", dtpStart.Value.Year, dtpEnd.Value.Year)
                                    If .AddAY = True Then
                                        MessageBox.Show("New Calendar Year has been saved.", "Register New Calendar Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        btnNew.Enabled = True
                                        btnSave.Enabled = False
                                        btnEdit.Enabled = False
                                        btnShowRecords.Enabled = True
                                        btnCancel.Enabled = True
                                        tcAYInfo.Enabled = False
                                        tcSearch.Enabled = True
                                        dtpStart.ResetText()
                                        dtpEnd.ResetText()
                                        btnNew.Focus()
                                        dtpEnd.Enabled = False
                                        txtSearch.Clear()
                                        dgvList.Rows.Clear()
                                        _flag = ""
                                        Exit Sub
                                    Else
                                        MessageBox.Show("Error.", "Register New Calendar Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                        Exit Sub
                                    End If
                                Else

                                    Try
                                        Dim ans As MsgBoxResult
                                        ans = MsgBox("There is none calendar year that is active." + vbCrLf + "Do you want this calendar year set to active?", MsgBoxStyle.YesNo, "Calendar Year")
                                        If ans = MsgBoxResult.Yes Then
                                            .Academic_year_start = dtpStart.Value.Year
                                            .Academic_year_end = dtpEnd.Value.Year
                                            .Academic_year_status = "Active"
                                            .Academic_year_remove_status = "FALSE"
                                            .Academic_year = String.Format("{0} - {1}", dtpStart.Value.Year, dtpEnd.Value.Year)
                                            If .AddAY = True Then

                                                MessageBox.Show("New Calendar Year has been saved.", "Register New Calendar Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                btnNew.Enabled = True
                                                btnSave.Enabled = False
                                                btnEdit.Enabled = False
                                                btnShowRecords.Enabled = True
                                                btnCancel.Enabled = True
                                                tcAYInfo.Enabled = False
                                                tcSearch.Enabled = True
                                                dtpStart.ResetText()
                                                dtpEnd.ResetText()
                                                btnNew.Focus()
                                                dtpEnd.Enabled = False
                                                _flag = ""
                                                txtSearch.Clear()
                                                dgvList.Rows.Clear()
                                                'SYNC ALL USER WHEN AY IS CHANGED
                                                'getActiveAY()
                                                Exit Sub
                                            Else
                                                MessageBox.Show("Error.", "Register New Calendar Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                                Exit Sub
                                            End If
                                        Else
                                            .Academic_year_start = dtpStart.Value.Year
                                            .Academic_year_end = dtpEnd.Value.Year
                                            .Academic_year_status = "Inactive"
                                            .Academic_year_remove_status = "FALSE"
                                            .Academic_year = String.Format("{0} - {1}", dtpStart.Value.Year, dtpEnd.Value.Year)
                                            If .AddAY = True Then
                                                MessageBox.Show("New Calendar Year has been saved.", "Register New Calendar Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                btnNew.Enabled = True
                                                btnSave.Enabled = False
                                                btnEdit.Enabled = False
                                                btnShowRecords.Enabled = True
                                                btnCancel.Enabled = True
                                                tcAYInfo.Enabled = False
                                                tcSearch.Enabled = True
                                                dtpStart.ResetText()
                                                dtpEnd.ResetText()
                                                btnNew.Focus()
                                                dtpEnd.Enabled = False
                                                txtSearch.Clear()
                                                dgvList.Rows.Clear()
                                                _flag = ""
                                                Exit Sub
                                            Else
                                                MessageBox.Show("Error.", "Register New Calendar Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                                Exit Sub
                                            End If
                                        End If
                                    Catch ex As Exception
                                        Exit Sub
                                    End Try

                                End If

                                ' End If
                            End If


                        Else
                            MsgBox("Dates are invalid")
                            Exit Sub
                        End If

                    End With
                    Exit Sub
                Else
                    MessageBox.Show("All fields are required", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            ElseIf _flag.Equals("Edit") = True Then
                If RequiredField(dtpStart.Value.ToShortDateString, dtpEnd.Value.ToShortDateString) = True Then
                    With _acad_year_obj
                        .Idacademic_year = idAY
                        .Academic_year_start = dtpStart.Value.Year
                        .Academic_year_end = dtpEnd.Value.Year
                        .Academic_year_status = "Inactive"
                        .Academic_year_remove_status = "FALSE"
                        .Academic_year = String.Format("{0} - {1}", dtpStart.Value.Year, dtpEnd.Value.Year)
                        If dtpStart.Value <= dtpEnd.Value Then
                            If .isAYExist(dtpStart.Value.ToString("yyyy"), dtpEnd.Value.ToString("yyyy"), "Edit", .Idacademic_year) = True Then
                                MsgBox("Calendar Year already exist.")
                                Exit Sub
                            Else
                                'If .isAYConflict(dtpStart.Value.ToString("yyyy"), dtpEnd.Value.ToString("yyyy"), "Edit", .Idacademic_year) = True Then
                                '    MessageBox.Show("Academic Year is conflict with " + .Academic_year, "Update Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                '    Exit Sub
                                'Else

                                If .UpdateAY = True Then
                                    MessageBox.Show("Calendar Year has been updated.", "Update Calendar Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    btnNew.Enabled = True
                                    btnSave.Enabled = False
                                    btnEdit.Enabled = False
                                    btnShowRecords.Enabled = True
                                    btnCancel.Enabled = True
                                    tcAYInfo.Enabled = False
                                    tcSearch.Enabled = True
                                    dtpStart.ResetText()
                                    dtpEnd.ResetText()
                                    btnNew.Focus()
                                    dtpEnd.Enabled = False
                                    _flag = ""
                                    txtSearch.Clear()
                                    dgvList.Rows.Clear()
                                    Exit Sub
                                Else
                                    MessageBox.Show("Error.", "Update Calendar Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                                'End If
                            End If
                        Else
                            MsgBox("Dates are invalid")
                            Exit Sub
                        End If

                    End With
                    Exit Sub
                Else
                    MessageBox.Show("All fields are required", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

            Else
                Exit Sub
            End If


        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            _flag = "Edit"
            btnEdit.Enabled = False
            btnNew.Enabled = False
            btnSave.Enabled = True
            'txtFrom.Enabled = True
            'txtTo.Enabled = False
            tcAYInfo.Enabled = True
            tcSearch.Enabled = False
            dtpEnd.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            keyAllow(_year, txtSearch)
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                If txtSearch.Text.Length >= 2 Then
                    .SearchAYRecords(dgvList, "All", txtSearch.Text, 1, "Edit")
                ElseIf txtSearch.Text = vbNullString Then
                    txtSearch.Clear()
                    dgvList.Rows.Clear()
                    dgvList.ClearSelection()
                Else

                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        Try
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                .LoadAYToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                idAY = .Idacademic_year
                dtpStart.Value = Date.ParseExact(.Academic_year_start.ToString, "yyyy", Globalization.CultureInfo.InvariantCulture)
                dtpEnd.Value = Date.ParseExact(.Academic_year_end.ToString, "yyyy", Globalization.CultureInfo.InvariantCulture)
                'txtFrom.Text = .Academic_year_start
                'txtTo.Text = .Academic_year_end
            End With
            _flag = "Edit"
            btnEdit.Enabled = False
            btnNew.Enabled = False
            btnSave.Enabled = True
            tcAYInfo.Enabled = True
            'txtTo.Enabled = False
            tcSearch.Enabled = False
            dtpEnd.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If _flag = "" Then
                Close()
                dtpStart.ResetText()
                dtpEnd.ResetText()
                txtSearch.Clear()
                dgvList.Rows.Clear()
                dgvList.ClearSelection()
                Exit Sub
            ElseIf _flag = "New" Then
                btnNew.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcAYInfo.Enabled = False
                tcSearch.Enabled = True
                dtpStart.ResetText()
                dtpEnd.ResetText()
                btnNew.Focus()
                Exit Sub
            ElseIf _flag = "Edit" Then
                btnNew.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcAYInfo.Enabled = False
                tcSearch.Enabled = True
                dtpStart.ResetText()
                dtpEnd.ResetText()
                btnNew.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmAYRecords.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            _acad_year_obj = New AcademicYearClass
            With _acad_year_obj
                .LoadAYToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                idAY = .Idacademic_year
                dtpStart.Value = Date.ParseExact(.Academic_year_start.ToString, "yyyy", Globalization.CultureInfo.InvariantCulture)
                dtpEnd.Value = Date.ParseExact(.Academic_year_end.ToString, "yyyy", Globalization.CultureInfo.InvariantCulture)
            End With
            btnEdit.Enabled = True
            btnNew.Enabled = False
            btnSave.Enabled = False
            tcAYInfo.Enabled = False
            tcSearch.Enabled = True
            dtpEnd.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmManageAcademicYear_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub dtpStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpStart.ValueChanged
        Try
            dtpEnd.Value = dtpStart.Value.AddYears(1)
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class