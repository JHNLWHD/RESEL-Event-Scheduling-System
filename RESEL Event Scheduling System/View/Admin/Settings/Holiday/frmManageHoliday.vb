Public Class frmManageHoliday

    Public _holiday_obj As EventClass
    Dim _flag As String = ""
    Public Shared idHol As Integer = 0
    Dim _Holiday_status As String = ""
    Dim _holidayAllow As String = "QWERTYUIOPLKJHGFDSAZXCVBNMqwertyuioplkjhgfdsazxcvbnm -'"

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            _flag = "New"
            dtpDate.Value = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcSearch.Enabled = False
            tcHolidayInfo.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmManageHoliday_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtpDate.Value = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcSearch.Enabled = True
            tcHolidayInfo.Enabled = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        _holiday_obj = New EventClass
        With _holiday_obj
            If _flag.Equals("New") Then
                If RequiredField(txtHolidayName.Text, dtpDate.Text, cboHolidayType.Text) = True Then
                    .Holiday_name = txtHolidayName.Text
                    .Holiday_type = cboHolidayType.Text
                    .Holiday_date = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
                    .Holiday_status = "ACTIVE"
                    If .AddHoliday = True Then
                        MessageBox.Show("New Holiday has been saved.", "Register New Holiday", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtpDate.Value = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
                        btnNew.Enabled = True
                        btnSave.Enabled = False
                        btnEdit.Enabled = False
                        btnShowRecords.Enabled = True
                        btnCancel.Enabled = True
                        tcSearch.Enabled = True
                        tcHolidayInfo.Enabled = False
                        _flag = ""
                        txtHolidayName.Clear()
                        cboHolidayType.SelectedIndex = -1
                        txtSearch.Clear()
                        dgvList.Rows.Clear()
                        dgvList.ClearSelection()
                        Exit Sub
                    Else
                        MessageBox.Show("New Holiday has not been saved.", "Register New Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("All are required fields", "Register New Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            ElseIf _flag.Equals("Edit") Then
                If RequiredField(txtHolidayName.Text, dtpDate.Text, cboHolidayType.Text) = True Then
                    .Idholiday = idHol
                    .Holiday_name = txtHolidayName.Text
                    .Holiday_type = cboHolidayType.Text
                    .Holiday_date = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
                    .Holiday_status = _Holiday_status
                    If .UpdateHoliday = True Then
                        MessageBox.Show("Holiday has been updated.", "Update Holiday", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dtpDate.Value = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
                        btnNew.Enabled = True
                        btnSave.Enabled = False
                        btnEdit.Enabled = False
                        btnShowRecords.Enabled = True
                        btnCancel.Enabled = True
                        tcSearch.Enabled = True
                        tcHolidayInfo.Enabled = False
                        _flag = ""
                        txtHolidayName.Clear()
                        cboHolidayType.SelectedIndex = -1
                        txtSearch.Clear()
                        dgvList.Rows.Clear()
                        dgvList.ClearSelection()
                        Exit Sub
                    Else
                        MessageBox.Show("Holiday has not been updated.", "Update Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("All are required fields", "Register New Holiday", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Else
                Exit Sub
            End If


        End With
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            _flag = "Edit"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcSearch.Enabled = False
            tcHolidayInfo.Enabled = True
            dtpDate.Value = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmHolidayRecords.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If _flag = "New" Then
                dtpDate.Value = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
                btnNew.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcSearch.Enabled = True
                tcHolidayInfo.Enabled = False
                txtSearch.Clear()
                txtHolidayName.Clear()
                cboHolidayType.SelectedIndex = 0
                dgvList.Rows.Clear()
                dgvList.ClearSelection()
            ElseIf _flag = "Edit" Then
                dtpDate.Value = New Date(1756, dtpDate.Value.Month, dtpDate.Value.Day)
                btnNew.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcSearch.Enabled = True
                tcHolidayInfo.Enabled = False
                txtSearch.Clear()
                txtHolidayName.Clear()
                cboHolidayType.SelectedIndex = 0
                dgvList.Rows.Clear()
                dgvList.ClearSelection()
            ElseIf _flag = "" Then
                Dispose()
                Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _holiday_obj = New EventClass
            With _holiday_obj
                If txtSearch.Text.Length >= 2 Then
                    .SearchHolidayRecords(dgvList, "ALL", 0, txtSearch.Text, "ALL")
                ElseIf txtSearch.Text = vbNullString Then
                    dgvList.Rows.Clear()
                    dgvList.ClearSelection()
                End If

            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            _holiday_obj = New EventClass
            With _holiday_obj
                .LoadHolidayToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                idHol = dgvList.SelectedRows(0).Cells(0).Value.ToString
                txtHolidayName.Text = .Holiday_name
                cboHolidayType.SelectedIndex = cboHolidayType.FindString(.Holiday_type)
                dtpDate.Value = New Date(1756, .Holiday_date.Month, .Holiday_date.Day)
                _Holiday_status = .Holiday_status
            End With
            btnEdit.Enabled = True
            btnNew.Enabled = False
            btnSave.Enabled = False
            tcHolidayInfo.Enabled = False
            tcSearch.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        Try
            _holiday_obj = New EventClass
            With _holiday_obj
                .LoadHolidayToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                idHol = dgvList.SelectedRows(0).Cells(0).Value.ToString
                txtHolidayName.Text = .Holiday_name
                cboHolidayType.SelectedIndex = cboHolidayType.FindString(.Holiday_type)
                dtpDate.Value = New Date(1756, .Holiday_date.Month, .Holiday_date.Day)
                _Holiday_status = .Holiday_status
            End With
            _flag = "Edit"
            btnEdit.Enabled = False
            btnNew.Enabled = False
            btnSave.Enabled = True
            tcHolidayInfo.Enabled = True
            tcSearch.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHolidayName_TextChanged(sender As Object, e As EventArgs) Handles txtHolidayName.TextChanged
        Try
            keyAllow(_holidayAllow, txtHolidayName)
        Catch ex As Exception

        End Try
    End Sub
End Class