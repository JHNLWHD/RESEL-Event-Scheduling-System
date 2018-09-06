Public Class frmManageDateSettingsvb

    Dim _flag = ""
    Public _acad_obj As AcademicYearClass

    Private Sub frmManageDateSettingsvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _flag = ""
            tcAYInfo.Enabled = False
            'tcSearch.Enabled = True
            btnNew.Enabled = True
            'btnEdit.Enabled = False
            btnSave.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            _flag = "New"
            tcAYInfo.Enabled = True
            'tcSearch.Enabled = False
            btnNew.Enabled = False
            'btnEdit.Enabled = False
            btnSave.Enabled = True
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            '  dtpEnd.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _acad_obj = New AcademicYearClass
            With _acad_obj
                If RequiredField(dtpStart.Value, dtpEnd.Value) = True Then
                    If _flag = "New" Then
                        .Date_settings_start = dtpStart.Value.ToString("MM")
                        .Date_settings_end = dtpEnd.Value.ToString("MM")

                        If .Date_settings_start > .Date_settings_end Then
                            If .isDateSettingsExist(dtpStart.Value.ToString("MM"), dtpEnd.Value.ToString("MM"), "New") Then
                                MessageBox.Show("Date Settings already exist.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            Else
                                If .hasActiveDateSettings = True Then
                                    .Date_settings_start = dtpStart.Value.ToString("MM")
                                    .Date_settings_end = dtpEnd.Value.ToString("MM")
                                    .Status = "Inactive"
                                    If .AddDateSettings = True Then
                                        MessageBox.Show("New Date Settings has been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        _flag = ""
                                        tcAYInfo.Enabled = False
                                        'tcSearch.Enabled = True
                                        btnNew.Enabled = True
                                        'btnEdit.Enabled = False
                                        btnSave.Enabled = False
                                        btnShowRecords.Enabled = True
                                        btnCancel.Enabled = True
                                        Exit Sub
                                    Else

                                        MessageBox.Show("New Date Settings has not been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If
                                Else
                                    Dim ans As MsgBoxResult
                                    ans = MsgBox("There is none date settings that is active." + vbCrLf + "Do you want this date_settings set to active?", MsgBoxStyle.YesNo, "Date Settings")
                                    If ans = MsgBoxResult.Yes Then
                                        .Date_settings_start = dtpStart.Value.ToString("MM")
                                        .Date_settings_end = dtpEnd.Value.ToString("MM")
                                        .Status = "Active"
                                        If .AddDateSettings = True Then
                                            MessageBox.Show("New Date Settings has been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            _flag = ""
                                            tcAYInfo.Enabled = False
                                            'tcSearch.Enabled = True
                                            btnNew.Enabled = True
                                            'btnEdit.Enabled = False
                                            btnSave.Enabled = False
                                            btnShowRecords.Enabled = True
                                            btnCancel.Enabled = True
                                            Exit Sub
                                        Else
                                            MessageBox.Show("New Date Settings has not been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    Else
                                        .Date_settings_start = dtpStart.Value.ToString("MM")
                                        .Date_settings_end = dtpEnd.Value.ToString("MM")
                                        .Status = "Inactive"
                                        If .AddDateSettings = True Then
                                            MessageBox.Show("New Date Settings has been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            _flag = ""
                                            tcAYInfo.Enabled = False
                                            ' tcSearch.Enabled = True
                                            btnNew.Enabled = True
                                            ' btnEdit.Enabled = False
                                            btnSave.Enabled = False
                                            btnShowRecords.Enabled = True
                                            btnCancel.Enabled = True
                                            Exit Sub
                                        Else
                                            MessageBox.Show("New Date Settings has not been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If


                        ElseIf .Date_settings_start = 1 And .Date_settings_end <> 1 Then
                            If .isDateSettingsExist(dtpStart.Value.ToString("MM"), dtpEnd.Value.ToString("MM"), "New") Then
                                MessageBox.Show("Date Settings already exist.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                Exit Sub
                            Else
                                If .hasActiveDateSettings = True Then
                                    .Date_settings_start = dtpStart.Value.ToString("MM")
                                    .Date_settings_end = dtpEnd.Value.ToString("MM")
                                    .Status = "Inactive"
                                    If .AddDateSettings = True Then
                                        MessageBox.Show("New Date Settings has been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        _flag = ""
                                        tcAYInfo.Enabled = False
                                        'tcSearch.Enabled = True
                                        btnNew.Enabled = True
                                        'btnEdit.Enabled = False
                                        btnSave.Enabled = False
                                        btnShowRecords.Enabled = True
                                        btnCancel.Enabled = True
                                        Exit Sub
                                    Else

                                        MessageBox.Show("New Date Settings has not been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                        Exit Sub
                                    End If
                                Else
                                    Dim ans As MsgBoxResult
                                    ans = MsgBox("There is none date settings that is active." + vbCrLf + "Do you want this date_settings set to active?", MsgBoxStyle.YesNo, "Date Settings")
                                    If ans = MsgBoxResult.Yes Then
                                        .Date_settings_start = dtpStart.Value.ToString("MM")
                                        .Date_settings_end = dtpEnd.Value.ToString("MM")
                                        .Status = "Active"
                                        If .AddDateSettings = True Then
                                            MessageBox.Show("New Date Settings has been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            _flag = ""
                                            tcAYInfo.Enabled = False
                                            'tcSearch.Enabled = True
                                            btnNew.Enabled = True
                                            'btnEdit.Enabled = False
                                            btnSave.Enabled = False
                                            btnShowRecords.Enabled = True
                                            btnCancel.Enabled = True
                                            Exit Sub
                                        Else
                                            MessageBox.Show("New Date Settings has not been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    Else
                                        .Date_settings_start = dtpStart.Value.ToString("MM")
                                        .Date_settings_end = dtpEnd.Value.ToString("MM")
                                        .Status = "Inactive"
                                        If .AddDateSettings = True Then
                                            MessageBox.Show("New Date Settings has been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            _flag = ""
                                            tcAYInfo.Enabled = False
                                            ' tcSearch.Enabled = True
                                            btnNew.Enabled = True
                                            ' btnEdit.Enabled = False
                                            btnSave.Enabled = False
                                            btnShowRecords.Enabled = True
                                            btnCancel.Enabled = True
                                            Exit Sub
                                        Else
                                            MessageBox.Show("New Date Settings has not been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                            Exit Sub
                                        End If
                                    End If
                                End If
                            End If
                        Else

                            MessageBox.Show("Start month should be greater than end.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        End If
                    ElseIf _flag = "Edit" Then
                        'Todo edit but remove
                        Exit Sub
                    Else
                        Exit Sub
                    End If
                Else

                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmAcademicDate.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Dispose()
            Close()
        Catch ex As Exception

        End Try
    End Sub
End Class