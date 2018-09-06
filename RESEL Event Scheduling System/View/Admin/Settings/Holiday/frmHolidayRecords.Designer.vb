<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHolidayRecords
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmAct = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cboFilter = New System.Windows.Forms.ComboBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lnklblPrint = New System.Windows.Forms.LinkLabel()
        Me.lnklblRefresh = New System.Windows.Forms.LinkLabel()
        Me.dgvHoliday = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me._Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HolidayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HolidayDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSort = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblRegLoc = New System.Windows.Forms.Label()
        Me.lblNational = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.lblInternational = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.cmDeact = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeactivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmAct.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.dgvHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.cmDeact.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.OpenToolStripMenuItem.Text = "Activate"
        '
        'cmAct
        '
        Me.cmAct.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem1, Me.OpenToolStripMenuItem})
        Me.cmAct.Name = "cmOpen"
        Me.cmAct.Size = New System.Drawing.Size(118, 48)
        '
        'RemoveToolStripMenuItem1
        '
        Me.RemoveToolStripMenuItem1.Name = "RemoveToolStripMenuItem1"
        Me.RemoveToolStripMenuItem1.Size = New System.Drawing.Size(117, 22)
        Me.RemoveToolStripMenuItem1.Text = "Remove"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(43, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 25)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(118, 58)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(320, 29)
        Me.txtSearch.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.cboFilter)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.lnklblPrint)
        Me.Panel2.Controls.Add(Me.lnklblRefresh)
        Me.Panel2.Controls.Add(Me.dgvHoliday)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.cboSort)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Location = New System.Drawing.Point(11, 76)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(920, 475)
        Me.Panel2.TabIndex = 18
        '
        'cboFilter
        '
        Me.cboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFilter.FormattingEnabled = True
        Me.cboFilter.Items.AddRange(New Object() {"ALL", "ACTIVE", "INACTIVE"})
        Me.cboFilter.Location = New System.Drawing.Point(681, 58)
        Me.cboFilter.Name = "cboFilter"
        Me.cboFilter.Size = New System.Drawing.Size(129, 29)
        Me.cboFilter.TabIndex = 63
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label16)
        Me.Panel6.Location = New System.Drawing.Point(50, 413)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(831, 57)
        Me.Panel6.TabIndex = 62
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(36, 17)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(640, 23)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Note: Right-Click to Activate/Deactivate or Remove a Holiday"
        '
        'lnklblPrint
        '
        Me.lnklblPrint.AutoSize = True
        Me.lnklblPrint.BackColor = System.Drawing.Color.Transparent
        Me.lnklblPrint.Font = New System.Drawing.Font("Segoe MDL2 Assets", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnklblPrint.LinkColor = System.Drawing.Color.Transparent
        Me.lnklblPrint.Location = New System.Drawing.Point(848, 64)
        Me.lnklblPrint.Name = "lnklblPrint"
        Me.lnklblPrint.Size = New System.Drawing.Size(29, 19)
        Me.lnklblPrint.TabIndex = 11
        Me.lnklblPrint.TabStop = True
        Me.lnklblPrint.Text = ""
        Me.lnklblPrint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lnklblPrint.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'lnklblRefresh
        '
        Me.lnklblRefresh.AutoSize = True
        Me.lnklblRefresh.BackColor = System.Drawing.Color.Transparent
        Me.lnklblRefresh.Font = New System.Drawing.Font("Segoe MDL2 Assets", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnklblRefresh.LinkColor = System.Drawing.Color.Transparent
        Me.lnklblRefresh.Location = New System.Drawing.Point(813, 64)
        Me.lnklblRefresh.Name = "lnklblRefresh"
        Me.lnklblRefresh.Size = New System.Drawing.Size(29, 19)
        Me.lnklblRefresh.TabIndex = 9
        Me.lnklblRefresh.TabStop = True
        Me.lnklblRefresh.Text = ""
        Me.lnklblRefresh.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'dgvHoliday
        '
        Me.dgvHoliday.AllowUserToAddRows = False
        Me.dgvHoliday.AllowUserToDeleteRows = False
        Me.dgvHoliday.AllowUserToResizeColumns = False
        Me.dgvHoliday.AllowUserToResizeRows = False
        Me.dgvHoliday.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHoliday.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvHoliday.ColumnHeadersHeight = 31
        Me.dgvHoliday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvHoliday.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me._Name, Me.HolidayType, Me.HolidayDate, Me.Status})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvHoliday.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvHoliday.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvHoliday.Location = New System.Drawing.Point(48, 110)
        Me.dgvHoliday.MultiSelect = False
        Me.dgvHoliday.Name = "dgvHoliday"
        Me.dgvHoliday.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvHoliday.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvHoliday.RowHeadersVisible = False
        Me.dgvHoliday.RowHeadersWidth = 50
        Me.dgvHoliday.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvHoliday.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvHoliday.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHoliday.Size = New System.Drawing.Size(831, 299)
        Me.dgvHoliday.TabIndex = 3
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
        Me._Name.HeaderText = "Holiday Name"
        Me._Name.Name = "_Name"
        Me._Name.ReadOnly = True
        Me._Name.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me._Name.Width = 450
        '
        'HolidayType
        '
        Me.HolidayType.HeaderText = "Holiday Type"
        Me.HolidayType.Name = "HolidayType"
        Me.HolidayType.ReadOnly = True
        Me.HolidayType.Width = 130
        '
        'HolidayDate
        '
        Me.HolidayDate.HeaderText = "Date"
        Me.HolidayDate.Name = "HolidayDate"
        Me.HolidayDate.ReadOnly = True
        Me.HolidayDate.Width = 150
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(469, 58)
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
        Me.cboSort.Items.AddRange(New Object() {"ALL", "INTERNATIONAL", "NATIONAL", "REGIONAL", "LOCAL"})
        Me.cboSort.Location = New System.Drawing.Point(549, 58)
        Me.cboSort.Name = "cboSort"
        Me.cboSort.Size = New System.Drawing.Size(129, 29)
        Me.cboSort.TabIndex = 7
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.lblRegLoc)
        Me.Panel3.Controls.Add(Me.lblNational)
        Me.Panel3.Controls.Add(Me.lbl)
        Me.Panel3.Controls.Add(Me.lblInternational)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Button3)
        Me.Panel3.Controls.Add(Me.Button4)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.ComboBox2)
        Me.Panel3.Location = New System.Drawing.Point(940, 76)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(229, 475)
        Me.Panel3.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(9, 373)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(216, 96)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Total no. of Active Regional/Local Holiday"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRegLoc
        '
        Me.lblRegLoc.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegLoc.ForeColor = System.Drawing.Color.White
        Me.lblRegLoc.Location = New System.Drawing.Point(6, 317)
        Me.lblRegLoc.Name = "lblRegLoc"
        Me.lblRegLoc.Size = New System.Drawing.Size(216, 59)
        Me.lblRegLoc.TabIndex = 16
        Me.lblRegLoc.Text = "100"
        Me.lblRegLoc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNational
        '
        Me.lblNational.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNational.ForeColor = System.Drawing.Color.White
        Me.lblNational.Location = New System.Drawing.Point(3, 156)
        Me.lblNational.Name = "lblNational"
        Me.lblNational.Size = New System.Drawing.Size(216, 66)
        Me.lblNational.TabIndex = 14
        Me.lblNational.Text = "100"
        Me.lblNational.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl
        '
        Me.lbl.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.White
        Me.lbl.Location = New System.Drawing.Point(3, 233)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(216, 63)
        Me.lbl.TabIndex = 13
        Me.lbl.Text = "Total no. of Active National Holiday"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblInternational
        '
        Me.lblInternational.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInternational.ForeColor = System.Drawing.Color.White
        Me.lblInternational.Location = New System.Drawing.Point(3, 4)
        Me.lblInternational.Name = "lblInternational"
        Me.lblInternational.Size = New System.Drawing.Size(216, 59)
        Me.lblInternational.TabIndex = 12
        Me.lblInternational.Text = "100"
        Me.lblInternational.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 15.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(-1, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(230, 83)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Total no. of Active International Holiday"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(684, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Sort by"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(746, 38)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(84, 21)
        Me.ComboBox2.TabIndex = 7
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(60, 16)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(1182, 39)
        Me.TextBox3.TabIndex = 0
        Me.TextBox3.Text = "HOLIDAY RECORDS"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Crimson
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Location = New System.Drawing.Point(-61, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1242, 71)
        Me.Panel1.TabIndex = 20
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Crimson
        Me.Panel9.Location = New System.Drawing.Point(-61, 561)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1242, 68)
        Me.Panel9.TabIndex = 21
        '
        'cmDeact
        '
        Me.cmDeact.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RemoveToolStripMenuItem, Me.DeactivateToolStripMenuItem})
        Me.cmDeact.Name = "cmDeact"
        Me.cmDeact.Size = New System.Drawing.Size(130, 48)
        '
        'RemoveToolStripMenuItem
        '
        Me.RemoveToolStripMenuItem.Name = "RemoveToolStripMenuItem"
        Me.RemoveToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.RemoveToolStripMenuItem.Text = "Remove"
        '
        'DeactivateToolStripMenuItem
        '
        Me.DeactivateToolStripMenuItem.Name = "DeactivateToolStripMenuItem"
        Me.DeactivateToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.DeactivateToolStripMenuItem.Text = "Deactivate"
        '
        'frmHolidayRecords
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1182, 629)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel9)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmHolidayRecords"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.cmAct.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.dgvHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.cmDeact.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmAct As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lnklblRefresh As LinkLabel
    Friend WithEvents dgvHoliday As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents cboSort As ComboBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents lblRegLoc As Label
    Friend WithEvents lblNational As Label
    Friend WithEvents lbl As Label
    Friend WithEvents lblInternational As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents cmDeact As ContextMenuStrip
    Friend WithEvents RemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeactivateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lnklblPrint As LinkLabel
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents _Name As DataGridViewTextBoxColumn
    Friend WithEvents HolidayType As DataGridViewTextBoxColumn
    Friend WithEvents HolidayDate As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents cboFilter As ComboBox
End Class
