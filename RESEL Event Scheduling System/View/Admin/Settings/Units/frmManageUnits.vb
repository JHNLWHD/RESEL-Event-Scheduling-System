Public Class frmManageUnits

    Public _account_obj As AccountClass
    Dim _flag As String = ""
    Dim _UAbbrev As String = ""
    Dim _UName As String = ""
    Public Shared _idUnit As Integer
    Dim _unitAllow As String = "QWERTYUIOPLKJHGFDSAZXCVBNM .qwertyuioplkjhgfdsazcvbnm,-"

    Private Sub frmManageUnits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _account_obj = New AccountClass
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcUnitInfo.Enabled = False
            txtUnitF.Clear()
            txtUnitA.Clear()
            dgvList.Rows.Clear()
            dgvList.ClearSelection()
            btnNew.Focus()


            With _account_obj
                .LoadUnitRecords(dgvList, "ACTIVE")
                .Unit_name = "RESEARCH,EXTENSION SERVICES AND EXTERNAL LINKAGES"
                .Unit_abbrev = "RESEL"
                If .isUnitFExist(.Unit_name, "New") = True Then

                    If .isUnitAExist(.Unit_abbrev, "New") = True Then
                        'MessageBox.Show("Unit information already exist")
                        Exit Sub
                    End If
                    'MessageBox.Show("Unit name already exist")
                    Exit Sub
                End If
                If .isUnitAExist(.Unit_abbrev, "New") = True Then
                    'MessageBox.Show("Unit abbreviation already exist")
                    Exit Sub
                End If
                If .AddUnit() = True Then
                    With _account_obj
                        .LoadUnitRecords(dgvList, "ACTIVE")
                    End With
                    Exit Sub
                Else
                    MessageBox.Show("Error.", "Register New Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            _flag = "New"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcUnitInfo.Enabled = True
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _account_obj = New AccountClass
            If RequiredField(txtUnitF.Text, txtUnitA.Text) = True Then
                With _account_obj
                    If _flag = "New" Then
                        .Unit_name = txtUnitF.Text
                        .Unit_abbrev = txtUnitA.Text
                        If .isUnitFExist(.Unit_name, "New") = True Then

                            If .isUnitAExist(.Unit_abbrev, "New") = True Then
                                MessageBox.Show("Unit information already exist")
                                Exit Sub
                            End If
                            MessageBox.Show("Unit name already exist")
                            Exit Sub
                        End If
                        If .isUnitAExist(.Unit_abbrev, "New") = True Then
                            MessageBox.Show("Unit abbreviation already exist")
                            Exit Sub
                        End If
                        'If txtUnitA.Text = "RESEL" And txtUnitF.Text = "RESEARCH,EXTENSION SERVICES AND EXTERNAL LINKAGES" Then
                        '    MessageBox.Show("This unit already exist")
                        '    Exit Sub
                        'End If
                        If .AddUnit() = True Then
                            MessageBox.Show("New Unit has been saved.", "Register New Unit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            btnNew.Enabled = True
                            btnSave.Enabled = False
                            btnEdit.Enabled = False
                            btnShowRecords.Enabled = True
                            btnCancel.Enabled = True
                            tcUnitInfo.Enabled = False
                            txtUnitF.Clear()
                            txtUnitA.Clear()
                            dgvList.Rows.Clear()
                            dgvList.ClearSelection()
                            btnNew.Focus()

                            With _account_obj
                                .LoadUnitRecords(dgvList, "ACTIVE")
                            End With
                            Exit Sub
                        Else
                            MessageBox.Show("Error.", "Register New Unit", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                    ElseIf _flag = "Edit" Then
                        .Idunit = _idUnit
                        .Unit_name = txtUnitF.Text
                        .Unit_abbrev = txtUnitA.Text


                        '1== true 0==false

                        If String.Compare(txtUnitF.Text, _UName, False) = 0 And String.Compare(txtUnitA.Text, _UAbbrev, False) = 0 Then
                            MessageBox.Show("Inputted values are just the same.")
                            Exit Sub
                        Else

                            If .isUnitFExist(.Unit_name, "New", .Idunit) = True Then

                                If .isUnitAExist(.Unit_abbrev, "New", .Idunit) = True Then
                                    MessageBox.Show("Unit information already exist")
                                    Exit Sub
                                End If
                                MessageBox.Show("Unit name already exist")
                                Exit Sub
                            End If
                            If .isUnitAExist(.Unit_abbrev, "New", .Idunit) = True Then
                                MessageBox.Show("Unit abbreviation already exist")
                                Exit Sub
                            End If

                            If .UpdateUnit = True Then
                                MessageBox.Show("Unit has been updated.", "Update Unit", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                btnNew.Enabled = True
                                btnSave.Enabled = False
                                btnEdit.Enabled = False
                                btnShowRecords.Enabled = True
                                btnCancel.Enabled = True
                                tcUnitInfo.Enabled = False
                                txtUnitF.Clear()
                                txtUnitA.Clear()
                                dgvList.Rows.Clear()
                                dgvList.ClearSelection()
                                btnNew.Focus()

                                With _account_obj
                                    .LoadUnitRecords(dgvList, "ACTIVE")
                                End With
                                Exit Sub
                            Else
                                MessageBox.Show("Unit has not been updated.", "Update Unit", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If




                        End If

                    Else
                            Exit Sub
                    End If

                End With
            Else
                MessageBox.Show("All fields are required", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            _flag = "Edit"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcUnitInfo.Enabled = True
            txtUnitF.Enabled = True
            txtUnitA.Enabled = True
            dgvList.ClearSelection()
            tcSearch.Enabled = False
            txtUnitF.Focus()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmUnitsRecords.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If _flag = "New" Then
                Try
                    _account_obj = New AccountClass
                    btnNew.Enabled = True
                    btnSave.Enabled = False
                    btnEdit.Enabled = False
                    btnShowRecords.Enabled = True
                    btnCancel.Enabled = True
                    tcUnitInfo.Enabled = False
                    txtUnitF.Clear()
                    txtUnitA.Clear()
                    dgvList.Rows.Clear()
                    dgvList.ClearSelection()
                    btnNew.Focus()

                    With _account_obj
                        .LoadUnitRecords(dgvList, "ACTIVE")
                    End With
                Catch ex As Exception

                End Try
            ElseIf _flag = "Edit" Then
                Try
                    _account_obj = New AccountClass
                    btnNew.Enabled = True
                    btnSave.Enabled = False
                    btnEdit.Enabled = False
                    btnShowRecords.Enabled = True
                    btnCancel.Enabled = True
                    tcUnitInfo.Enabled = False
                    txtUnitF.Clear()
                    txtUnitA.Clear()
                    dgvList.Rows.Clear()
                    dgvList.ClearSelection()
                    btnNew.Focus()

                    With _account_obj
                        .LoadUnitRecords(dgvList, "ACTIVE")
                    End With
                Catch ex As Exception

                End Try
            ElseIf _flag = "" Then
                Dispose()
                Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        Try
            _account_obj = New AccountClass
            With _account_obj
                .LoadUnitToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                _idUnit = .Idunit
                txtUnitF.Text = .Unit_name
                txtUnitA.Text = .Unit_abbrev
                _UAbbrev = .Unit_abbrev
                _UName = .Unit_name
            End With
            _flag = "Edit"
            btnNew.Enabled = False
            btnSave.Enabled = True
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcUnitInfo.Enabled = True
            txtUnitA.Enabled = True
            txtUnitF.Enabled = True
            dgvList.ClearSelection()
            tcSearch.Enabled = False
            txtUnitF.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            _account_obj = New AccountClass
            With _account_obj
                .LoadUnitToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                _idUnit = .Idunit
                txtUnitF.Text = .Unit_name
                txtUnitA.Text = .Unit_abbrev
                _UAbbrev = .Unit_abbrev
                _UName = .Unit_name
                btnNew.Enabled = False
                btnSave.Enabled = False
                btnEdit.Enabled = True
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcUnitInfo.Enabled = False
                dgvList.ClearSelection()
            End With
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub frmManageUnits_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Dispose()
        Catch ex As Exception
            MessageBox.Show("Connection Error." + vbCrLf + "Please check your connection settings", "Connection Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtUnitF_TextChanged(sender As Object, e As EventArgs) Handles txtUnitF.TextChanged
        Try
            keyAllow(_unitAllow, txtUnitF)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtUnitA_TextChanged(sender As Object, e As EventArgs) Handles txtUnitA.TextChanged
        Try
            keyAllow(_unitAllow, txtUnitA)
        Catch ex As Exception

        End Try
    End Sub
End Class