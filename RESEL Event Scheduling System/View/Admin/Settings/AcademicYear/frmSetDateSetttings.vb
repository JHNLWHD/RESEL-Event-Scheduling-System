Public Class frmSetDateSetttings

    Public _acad_obj As AcademicYearClass
    Dim _flag = ""

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        _acad_obj = New AcademicYearClass
        With _acad_obj
            If RequiredField(dtpStart.Value, dtpEnd.Value) = True Then
                .Date_settings_start = Convert.ToDateTime(dtpStart.Value).ToString("MM")
                .Date_settings_end = Convert.ToDateTime(dtpEnd.Value).ToString("MM")
                If .Date_settings_start > .Date_settings_end Then
                        If .isDateSettingsExist(dtpStart.Value.ToString("MM"), dtpEnd.Value.ToString("MM"), "New") Then
                            MessageBox.Show("Date Settings already exist.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Exit Sub
                        Else
                            .Date_settings_start = dtpStart.Value.ToString("MM")
                            .Date_settings_end = dtpEnd.Value.ToString("MM")
                            .Status = "Active"
                        If .AddDateSettings = True Then
                            MessageBox.Show("New Date Settings has been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            _flag = ""
                            Dispose()
                            Close()
                            Exit Sub
                        ElseIf .AddDateSettingsNOACTLOGS = True Then
                            MessageBox.Show("New Date Settings has been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            _flag = ""
                            Dispose()
                            Close()
                            Exit Sub
                        Else
                            MessageBox.Show("New Date Settings has not been saved.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If


                    End If


                    Else
                        MessageBox.Show("Start month should be greater than end.", "New Date Settings", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If


                Else
                MessageBox.Show("All fileds required")
                Exit Sub
            End If
        End With
    End Sub

    Private Sub frmSetDateSetttings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception

        End Try
    End Sub

End Class