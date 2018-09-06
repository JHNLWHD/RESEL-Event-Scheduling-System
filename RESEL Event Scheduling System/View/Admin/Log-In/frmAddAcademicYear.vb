Public Class frmAddAcademicYear
    Public _account_obj As AccountClass
    Public _acad_obj As AcademicYearClass

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _acad_obj = New AcademicYearClass
            If RequiredField(dtpStart.Value.ToShortDateString, dtpEnd.Value.ToShortDateString) = True Then
                With _acad_obj
                    If dtpStart.Value <= dtpEnd.Value Then
                        If .isAYExist(dtpStart.Value.ToString("yyyy"), dtpEnd.Value.ToString("yyyy"), "New") = True Then
                            MsgBox("Academic Year already exist.")
                            Exit Sub
                        Else
                            If .isAYConflict(dtpStart.Value.ToString("yyyy"), dtpEnd.Value.ToString("yyyy"), "New") = True Then
                                MessageBox.Show("Academic Year is conflict with " + .Academic_year, "Register New Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            Else
                                'MsgBox(2)

                                .Academic_year_start = dtpStart.Value.Year
                                .Academic_year_end = dtpEnd.Value.Year
                                MsgBox(.Academic_year_start)
                                .Academic_year_status = "Active"
                                .Academic_year_remove_status = "FALSE"
                                .Academic_year = String.Format("{0} - {1}", dtpStart.Value.Year, dtpEnd.Value.Year)
                                If .AddAYNoActLogs = True Then
                                    MessageBox.Show("New Academic Year has been saved and activated.", "Register New Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Close()
                                    'SYNC ALL USER WHEN AY IS CHANGED
                                    'getActiveAY()
                                Else
                                    MessageBox.Show("Error.", "Register New Academic Year", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                    Exit Sub
                                End If
                            End If
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
        Catch ex As Exception
            MsgBox(ex.Message)
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmAddAcademicYear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Dim _date As Date = New Date(Date.Parse(getDate).Year, Date.Parse(getDate).Month, Date.Parse(getDate).Day)
            'dtpStart.MinDate = _date
            _acad_obj = New AcademicYearClass
            dtpEnd.Value = dtpStart.Value.AddYears(1)
            With _acad_obj
                .getActiveAY()
                ' dtpStart.MinDate = .Academic_year_start
            End With

        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmAddAcademicYear_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
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

        End Try
    End Sub
End Class