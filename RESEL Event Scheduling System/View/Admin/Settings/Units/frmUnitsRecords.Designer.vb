<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUnitsRecords
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lnklblRefresh = New System.Windows.Forms.LinkLabel()
        Me.lnklblPrint = New System.Windows.Forms.LinkLabel()
        Me.dgvUnits = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit_abbrev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reg_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSort = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblInactiveUnit = New System.Windows.Forms.Label()
        Me.lblActiveUnit = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTotalUnit = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.cmAct = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ActivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmDeact = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeactivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.cmAct.SuspendLayout()
        Me.cmDeact.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Crimson
        Me.Panel9.Location = New System.Drawing.Point(-30, 561)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1242, 68)
        Me.Panel9.TabIndex = 20
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.lnklblRefresh)
        Me.Panel2.Controls.Add(Me.lnklblPrint)
        Me.Panel2.Controls.Add(Me.dgvUnits)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cboSort)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Location = New System.Drawing.Point(13, 76)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(920, 475)
        Me.Panel2.TabIndex = 18
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label16)
        Me.Panel6.Location = New System.Drawing.Point(25, 410)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(877, 57)
        Me.Panel6.TabIndex = 61
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(59, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(640, 23)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Note: Right-Click to Activate/Deactivate or Remove Unit"
        '
        'lnklblRefresh
        '
        Me.lnklblRefresh.AutoSize = True
        Me.lnklblRefresh.BackColor = System.Drawing.Color.Transparent
        Me.lnklblRefresh.Font = New System.Drawing.Font("Segoe MDL2 Assets", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnklblRefresh.LinkColor = System.Drawing.Color.Transparent
        Me.lnklblRefresh.Location = New System.Drawing.Point(803, 53)
        Me.lnklblRefresh.Name = "lnklblRefresh"
        Me.lnklblRefresh.Size = New System.Drawing.Size(35, 19)
        Me.lnklblRefresh.TabIndex = 12
        Me.lnklblRefresh.TabStop = True
        Me.lnklblRefresh.Text = " "
        Me.lnklblRefresh.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'lnklblPrint
        '
        Me.lnklblPrint.AutoSize = True
        Me.lnklblPrint.BackColor = System.Drawing.Color.Transparent
        Me.lnklblPrint.Font = New System.Drawing.Font("Segoe MDL2 Assets", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnklblPrint.LinkColor = System.Drawing.Color.Transparent
        Me.lnklblPrint.Location = New System.Drawing.Point(851, 53)
        Me.lnklblPrint.Name = "lnklblPrint"
        Me.lnklblPrint.Size = New System.Drawing.Size(29, 19)
        Me.lnklblPrint.TabIndex = 11
        Me.lnklblPrint.TabStop = True
        Me.lnklblPrint.Text = ""
        Me.lnklblPrint.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'dgvUnits
        '
        Me.dgvUnits.AllowUserToAddRows = False
        Me.dgvUnits.AllowUserToDeleteRows = False
        Me.dgvUnits.AllowUserToResizeColumns = False
        Me.dgvUnits.AllowUserToResizeRows = False
        Me.dgvUnits.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUnits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUnits.ColumnHeadersHeight = 31
        Me.dgvUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvUnits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me._Name, Me.Unit_abbrev, Me.Reg_date, Me.Status})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvUnits.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvUnits.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvUnits.Location = New System.Drawing.Point(25, 107)
        Me.dgvUnits.MultiSelect = False
        Me.dgvUnits.Name = "dgvUnits"
        Me.dgvUnits.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUnits.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUnits.RowHeadersVisible = False
        Me.dgvUnits.RowHeadersWidth = 50
        Me.dgvUnits.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUnits.Size = New System.Drawing.Size(877, 297)
        Me.dgvUnits.TabIndex = 3
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        '_Name
        '
        Me._Name.HeaderText = "Complete Unit Name"
        Me._Name.Name = "_Name"
        Me._Name.ReadOnly = True
        Me._Name.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me._Name.Width = 350
        '
        'Unit_abbrev
        '
        Me.Unit_abbrev.HeaderText = "Unit Abbreviation"
        Me.Unit_abbrev.Name = "Unit_abbrev"
        Me.Unit_abbrev.ReadOnly = True
        Me.Unit_abbrev.Width = 210
        '
        'Reg_date
        '
        Me.Reg_date.HeaderText = "Registration Date"
        Me.Reg_date.Name = "Reg_date"
        Me.Reg_date.ReadOnly = True
        Me.Reg_date.Width = 180
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 130
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(505, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 25)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Sort by"
        '
        'cboSort
        '
        Me.cboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSort.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSort.FormattingEnabled = True
        Me.cboSort.Items.AddRange(New Object() {"ACTIVE", "INACTIVE", "ALL"})
        Me.cboSort.Location = New System.Drawing.Point(585, 47)
        Me.cboSort.Name = "cboSort"
        Me.cboSort.Size = New System.Drawing.Size(114, 29)
        Me.cboSort.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(33, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(108, 46)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(382, 29)
        Me.txtSearch.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(33, 375)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(216, 63)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Total no. of Inactive Accounts"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Crimson
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Location = New System.Drawing.Point(-30, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1242, 71)
        Me.Panel1.TabIndex = 19
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(30, 16)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(1182, 39)
        Me.TextBox3.TabIndex = 0
        Me.TextBox3.Text = "UNITS RECORDS"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lblInactiveUnit)
        Me.Panel3.Controls.Add(Me.lblActiveUnit)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.lblTotalUnit)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button4)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.ComboBox2)
        Me.Panel3.Location = New System.Drawing.Point(943, 76)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(229, 475)
        Me.Panel3.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 380)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 63)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Total no. of Inactive Units"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInactiveUnit
        '
        Me.lblInactiveUnit.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInactiveUnit.ForeColor = System.Drawing.Color.White
        Me.lblInactiveUnit.Location = New System.Drawing.Point(6, 320)
        Me.lblInactiveUnit.Name = "lblInactiveUnit"
        Me.lblInactiveUnit.Size = New System.Drawing.Size(216, 59)
        Me.lblInactiveUnit.TabIndex = 16
        Me.lblInactiveUnit.Text = "100"
        Me.lblInactiveUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblActiveUnit
        '
        Me.lblActiveUnit.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActiveUnit.ForeColor = System.Drawing.Color.White
        Me.lblActiveUnit.Location = New System.Drawing.Point(3, 152)
        Me.lblActiveUnit.Name = "lblActiveUnit"
        Me.lblActiveUnit.Size = New System.Drawing.Size(216, 66)
        Me.lblActiveUnit.TabIndex = 14
        Me.lblActiveUnit.Text = "100"
        Me.lblActiveUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(216, 63)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Total no. of Active Units"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotalUnit
        '
        Me.lblTotalUnit.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalUnit.ForeColor = System.Drawing.Color.White
        Me.lblTotalUnit.Location = New System.Drawing.Point(3, 23)
        Me.lblTotalUnit.Name = "lblTotalUnit"
        Me.lblTotalUnit.Size = New System.Drawing.Size(216, 59)
        Me.lblTotalUnit.TabIndex = 12
        Me.lblTotalUnit.Text = "100"
        Me.lblTotalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(33, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(167, 30)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Total no. of Units"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(732, 418)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(98, 36)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "?"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(628, 418)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(98, 36)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Edit"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(684, 36)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 20)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Sort by"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(746, 38)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(84, 21)
        Me.ComboBox2.TabIndex = 7
        '
        'cmAct
        '
        Me.cmAct.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivateToolStripMenuItem, Me.RemoveToolStripMenuItem})
        Me.cmAct.Name = "cmAct"
        Me.cmAct.Size = New System.Drawing.Size(118, 48)
        '
        'ActivateToolStripMenuItem
        '
        Me.ActivateToolStripMenuItem.Name = "ActivateToolStripMenuItem"
        Me.ActivateToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.ActivateToolStripMenuItem.Text = "Activate"
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'cmDeact
        '
        Me.cmDeact.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeactivateToolStripMenuItem, Me.RemoveToolStripMenuItem1})
        Me.cmDeact.Name = "cmDeact"
        Me.cmDeact.Size = New System.Drawing.Size(130, 48)
        '
        'DeactivateToolStripMenuItem
        '
        Me.DeactivateToolStripMenuItem.Name = "DeactivateToolStripMenuItem"
        Me.DeactivateToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DeactivateToolStripMenuItem.Text = "Deactivate"
        '
        'RemoveToolStripMenuItem1
        '
        Me.RemoveToolStripMenuItem1.Name = "RemoveToolStripMenuItem1"
        Me.RemoveToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.RemoveToolStripMenuItem1.Text = "Remove"
        '
        'frmUnitsRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 629)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmUnitsRecords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.dgvUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.cmAct.ResumeLayout(False)
        Me.cmDeact.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents dgvUnits As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents _Name As DataGridViewTextBoxColumn
    Friend WithEvents Unit_abbrev As DataGridViewTextBoxColumn
    Friend WithEvents Reg_date As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Label3 As Label
    Friend WithEvents cboSort As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents lblInactiveUnit As Label
    Friend WithEvents lblActiveUnit As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTotalUnit As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents cmAct As ContextMenuStrip
    Friend WithEvents ActivateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmDeact As ContextMenuStrip
    Friend WithEvents DeactivateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents lnklblPrint As LinkLabel
    Friend WithEvents lnklblRefresh As LinkLabel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label16 As Label
End Class
