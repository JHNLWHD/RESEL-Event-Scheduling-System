Public Class frmManagePartnerAgency

    Public _partner_agency_obj As EventClass
    Dim _flag As String = ""
    Public Shared _idPA As Integer = 0
    Dim _PA, _PF As String
    Private Sub frmManagePartnerAgency_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            btnNew.Enabled = True
            btnSave.Enabled = False
            btnEdit.Enabled = False
            btnShowRecords.Enabled = True
            btnCancel.Enabled = True
            tcPAInfo.Enabled = False
            txtName.Clear()
            dgvList.Rows.Clear()
            dgvList.ClearSelection()
            btnNew.Focus()
            txtAbbrev.Clear()
        Catch ex As Exception

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
            tcPAInfo.Enabled = True
            tcSearch.Enabled = False
            txtName.Clear()
            dgvList.Rows.Clear()
            dgvList.ClearSelection()
            txtName.Focus()
            txtAbbrev.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            _partner_agency_obj = New EventClass
            With _partner_agency_obj
                If RequiredField(txtName.Text) = True Then
                    .Partner_agency_name = txtName.Text
                    .Partner_agency_abbrev = txtAbbrev.Text
                    .Partner_agency_remove_status = "FALSE"
                    If _flag = "New" Then
                        If .isPartnerAgencyFExist(txtName.Text, "New") = True Then

                            If .isPartnerAgencyAExist(txtAbbrev.Text, "New") = True Then
                                MessageBox.Show("This partner agency information already exist.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                            MessageBox.Show("This partner agency full name already exist.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                        If .isPartnerAgencyAExist(txtAbbrev.Text, "New") = True Then
                            MessageBox.Show("This partner agency abbreviation already exist.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If

                        If .AddPartnerAgency = True Then
                            MessageBox.Show("Partner Agency has been saved.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            btnNew.Enabled = True
                            btnSave.Enabled = False
                            btnEdit.Enabled = False
                            btnShowRecords.Enabled = True
                            btnCancel.Enabled = True
                            tcPAInfo.Enabled = False
                            txtName.Clear()
                            dgvList.Rows.Clear()
                            dgvList.ClearSelection()
                            txtAbbrev.Clear()
                            btnNew.Focus()
                            _flag = ""
                            Exit Sub
                        Else
                            MessageBox.Show("Partner Agency has not been saved.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    ElseIf _flag = "Edit" Then
                        .Idpartner_agency = _idPA
                        .Partner_agency_name = txtName.Text
                        .Partner_agency_abbrev = txtAbbrev.Text
                        If String.Compare(txtName.Text, _PF, True) = 0 And String.Compare(txtAbbrev.Text, _PA, True) = 0 Then
                            MessageBox.Show("Inputted values are just the same.")
                            Exit Sub
                        Else

                            If .isPartnerAgencyFExist(txtName.Text, "Edit", .Idpartner_agency) = True Then

                                If .isPartnerAgencyAExist(txtAbbrev.Text, "Edit", .Idpartner_agency) = True Then
                                    MessageBox.Show("This partner agency information already exist.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End If
                                MessageBox.Show("This partner agency full name already exist.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                            If .isPartnerAgencyAExist(txtAbbrev.Text, "Edit", .Idpartner_agency) = True Then
                                MessageBox.Show("This partner agency abbreviation already exist.", "New Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If

                            If .UpdatePartnerAgency = True Then
                                MessageBox.Show("Partner Agency has been updated.", "Update Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                btnNew.Enabled = True
                                btnSave.Enabled = False
                                btnEdit.Enabled = False
                                btnShowRecords.Enabled = True
                                btnCancel.Enabled = True
                                tcPAInfo.Enabled = False
                                txtName.Clear()
                                dgvList.Rows.Clear()
                                dgvList.ClearSelection()
                                btnNew.Focus()
                                txtAbbrev.Clear()
                                _flag = ""
                                Exit Sub
                            Else
                                MessageBox.Show("Partner Agency has not been updated.", "Update Partner Agency", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Sub
                            End If
                        End If
                    Else
                        Exit Sub
                    End If

                Else
                    MessageBox.Show("All fields required", "Field requirement", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception

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
            tcPAInfo.Enabled = True
            tcSearch.Enabled = False
            txtName.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnShowRecords_Click(sender As Object, e As EventArgs) Handles btnShowRecords.Click
        Try
            frmPartnerAgencyRecords.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If _flag = "New" Then
                _flag = ""
                btnNew.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcPAInfo.Enabled = False
                txtName.Clear()
                txtSearch.Clear()
                tcSearch.Enabled = True
                dgvList.Rows.Clear()
                dgvList.ClearSelection()
                btnNew.Focus()
                txtAbbrev.Clear()
            ElseIf _flag = "Edit" Then
                _flag = ""
                btnNew.Enabled = True
                btnSave.Enabled = False
                btnEdit.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
                tcPAInfo.Enabled = False
                txtName.Clear()
                txtSearch.Clear()
                tcSearch.Enabled = True
                dgvList.Rows.Clear()
                dgvList.ClearSelection()
                btnNew.Focus()
                txtAbbrev.Clear()
            Else
                Dispose()
                Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        Try
            _partner_agency_obj = New EventClass
            With _partner_agency_obj
                _flag = "Edit"
                .LoadPartnerAgencyToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                .Idpartner_agency = dgvList.SelectedRows(0).Cells(0).Value.ToString
                _idPA = .Idpartner_agency
                .Partner_agency_name = .Partner_agency_name
                txtName.Text = .Partner_agency_name
                txtAbbrev.Text = .Partner_agency_abbrev
                _PF = .Partner_agency_name
                _PA = .Partner_agency_abbrev
                tcPAInfo.Enabled = True
                tcSearch.Enabled = False
                btnNew.Enabled = False
                btnEdit.Enabled = False
                btnSave.Enabled = True
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvList_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellClick
        Try
            _partner_agency_obj = New EventClass
            With _partner_agency_obj
                .LoadPartnerAgencyToEdit(dgvList.SelectedRows(0).Cells(0).Value.ToString)
                .Idpartner_agency = dgvList.SelectedRows(0).Cells(0).Value.ToString
                _idPA = .Idpartner_agency
                .Partner_agency_name = .Partner_agency_name
                txtName.Text = .Partner_agency_name
                txtAbbrev.Text = .Partner_agency_abbrev
                _PF = .Partner_agency_name
                _PA = .Partner_agency_abbrev
                tcPAInfo.Enabled = False
                tcSearch.Enabled = True
                btnNew.Enabled = False
                btnEdit.Enabled = True
                btnSave.Enabled = False
                btnShowRecords.Enabled = True
                btnCancel.Enabled = True
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            _partner_agency_obj = New EventClass
            With _partner_agency_obj
                If txtSearch.Text.Length >= 2 Then
                    .SearchPartnerAgencyRecords(dgvList, 1, txtSearch.Text)
                ElseIf txtSearch.Text = vbNullString Then
                    dgvList.Rows.Clear()
                    dgvList.ClearSelection()
                Else
                    Exit Sub
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

    End Sub

    Private Sub txtAbbrev_TextChanged(sender As Object, e As EventArgs) Handles txtAbbrev.TextChanged

    End Sub
End Class