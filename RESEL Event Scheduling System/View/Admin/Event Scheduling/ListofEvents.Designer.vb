<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ListofEvents
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.dgvEvents = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EventCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EventName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EventType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NumberParticipants = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EventStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.lnklblRefresh = New System.Windows.Forms.LinkLabel()
        Me.cmManage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditEventDetaisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RescheduleThisEventToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewEventTrackingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMoreDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvEvents, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.cmManage.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Crimson
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1091, 66)
        Me.Panel1.TabIndex = 47
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(-3, 12)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(1078, 39)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.Text = "LIST OF EVENTS"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvEvents
        '
        Me.dgvEvents.AllowUserToAddRows = False
        Me.dgvEvents.AllowUserToResizeColumns = False
        Me.dgvEvents.AllowUserToResizeRows = False
        Me.dgvEvents.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEvents.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEvents.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEvents.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Unit, Me.EventCode, Me.EventName, Me.EventType, Me.NumberParticipants, Me.EventStatus})
        Me.dgvEvents.Location = New System.Drawing.Point(37, 81)
        Me.dgvEvents.MultiSelect = False
        Me.dgvEvents.Name = "dgvEvents"
        Me.dgvEvents.ReadOnly = True
        Me.dgvEvents.RowHeadersVisible = False
        Me.dgvEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEvents.Size = New System.Drawing.Size(975, 259)
        Me.dgvEvents.TabIndex = 48
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ID.Visible = False
        '
        'Unit
        '
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EventCode
        '
        Me.EventCode.HeaderText = "Event Code"
        Me.EventCode.Name = "EventCode"
        Me.EventCode.ReadOnly = True
        Me.EventCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EventName
        '
        Me.EventName.HeaderText = "Event Name"
        Me.EventName.Name = "EventName"
        Me.EventName.ReadOnly = True
        Me.EventName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EventName.Width = 300
        '
        'EventType
        '
        Me.EventType.HeaderText = "Event Type"
        Me.EventType.Name = "EventType"
        Me.EventType.ReadOnly = True
        Me.EventType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EventType.Width = 120
        '
        'NumberParticipants
        '
        Me.NumberParticipants.HeaderText = "No. of Participants"
        Me.NumberParticipants.Name = "NumberParticipants"
        Me.NumberParticipants.ReadOnly = True
        Me.NumberParticipants.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.NumberParticipants.Width = 200
        '
        'EventStatus
        '
        Me.EventStatus.HeaderText = "Event Status"
        Me.EventStatus.Name = "EventStatus"
        Me.EventStatus.ReadOnly = True
        Me.EventStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.EventStatus.Width = 150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(50, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 25)
        Me.Label2.TabIndex = 50
        Me.Label2.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(125, 34)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(382, 29)
        Me.txtSearch.TabIndex = 49
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.lnklblRefresh)
        Me.Panel2.Controls.Add(Me.txtSearch)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.dgvEvents)
        Me.Panel2.Location = New System.Drawing.Point(12, 89)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1054, 543)
        Me.Panel2.TabIndex = 51
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Panel10)
        Me.Panel6.Controls.Add(Me.Panel11)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.Label13)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Controls.Add(Me.Label10)
        Me.Panel6.Location = New System.Drawing.Point(37, 389)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(975, 93)
        Me.Panel6.TabIndex = 57
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Purple
        Me.Panel10.Location = New System.Drawing.Point(682, 41)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(83, 18)
        Me.Panel10.TabIndex = 21
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel11.Location = New System.Drawing.Point(498, 43)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(83, 18)
        Me.Panel11.TabIndex = 20
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(619, 42)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 17)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "Incoming"
        '
        'Label15
        '
        Me.Label15.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(426, 43)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 17)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Completed"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.ForestGreen
        Me.Panel9.Location = New System.Drawing.Point(859, 41)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(68, 18)
        Me.Panel9.TabIndex = 17
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Red
        Me.Panel8.Location = New System.Drawing.Point(311, 43)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(82, 18)
        Me.Panel8.TabIndex = 16
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Yellow
        Me.Panel7.Location = New System.Drawing.Point(136, 42)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(82, 18)
        Me.Panel7.TabIndex = 15
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(796, 41)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 17)
        Me.Label13.TabIndex = 14
        Me.Label13.Text = "On Going"
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(254, 43)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 17)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Overdue"
        '
        'Label11
        '
        Me.Label11.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Light", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(83, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(52, 17)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Pending"
        '
        'Label10
        '
        Me.Label10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 17)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Legend"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe MDL2 Assets", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Location = New System.Drawing.Point(934, 39)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(39, 21)
        Me.LinkLabel1.TabIndex = 56
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = " "
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'lnklblRefresh
        '
        Me.lnklblRefresh.AutoSize = True
        Me.lnklblRefresh.Font = New System.Drawing.Font("Segoe MDL2 Assets", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnklblRefresh.LinkColor = System.Drawing.Color.Transparent
        Me.lnklblRefresh.Location = New System.Drawing.Point(893, 41)
        Me.lnklblRefresh.Name = "lnklblRefresh"
        Me.lnklblRefresh.Size = New System.Drawing.Size(35, 19)
        Me.lnklblRefresh.TabIndex = 51
        Me.lnklblRefresh.TabStop = True
        Me.lnklblRefresh.Text = " "
        Me.lnklblRefresh.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'cmManage
        '
        Me.cmManage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditEventDetaisToolStripMenuItem, Me.RescheduleThisEventToolStripMenuItem, Me.ViewEventTrackingToolStripMenuItem, Me.ViewMoreDetailsToolStripMenuItem})
        Me.cmManage.Name = "cmManage"
        Me.cmManage.Size = New System.Drawing.Size(189, 92)
        '
        'EditEventDetaisToolStripMenuItem
        '
        Me.EditEventDetaisToolStripMenuItem.Name = "EditEventDetaisToolStripMenuItem"
        Me.EditEventDetaisToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.EditEventDetaisToolStripMenuItem.Text = "Edit Event Details"
        '
        'RescheduleThisEventToolStripMenuItem
        '
        Me.RescheduleThisEventToolStripMenuItem.Name = "RescheduleThisEventToolStripMenuItem"
        Me.RescheduleThisEventToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.RescheduleThisEventToolStripMenuItem.Text = "Reschedule this Event"
        '
        'ViewEventTrackingToolStripMenuItem
        '
        Me.ViewEventTrackingToolStripMenuItem.Name = "ViewEventTrackingToolStripMenuItem"
        Me.ViewEventTrackingToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ViewEventTrackingToolStripMenuItem.Text = "View Event Tracking"
        '
        'ViewMoreDetailsToolStripMenuItem
        '
        Me.ViewMoreDetailsToolStripMenuItem.Name = "ViewMoreDetailsToolStripMenuItem"
        Me.ViewMoreDetailsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.ViewMoreDetailsToolStripMenuItem.Text = "View More Details"
        '
        'ListofEvents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 644)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "ListofEvents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvEvents, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.cmManage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents dgvEvents As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lnklblRefresh As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Unit As DataGridViewTextBoxColumn
    Friend WithEvents EventCode As DataGridViewTextBoxColumn
    Friend WithEvents EventName As DataGridViewTextBoxColumn
    Friend WithEvents EventType As DataGridViewTextBoxColumn
    Friend WithEvents NumberParticipants As DataGridViewTextBoxColumn
    Friend WithEvents EventStatus As DataGridViewTextBoxColumn
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents cmManage As ContextMenuStrip
    Friend WithEvents EditEventDetaisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RescheduleThisEventToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewEventTrackingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewMoreDetailsToolStripMenuItem As ToolStripMenuItem
End Class
