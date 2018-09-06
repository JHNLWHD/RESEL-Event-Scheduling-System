<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendEve
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
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.lnklblRefresh = New System.Windows.Forms.LinkLabel()
        Me.cmManage = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RescheduleThisEventToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewEventTrackingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewMoreDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditEventDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvPending = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.cmManage.SuspendLayout()
        CType(Me.dgvPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.txtCode.Location = New System.Drawing.Point(99, 19)
        Me.txtCode.Multiline = True
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(533, 27)
        Me.txtCode.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.DimGray
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 21)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "SEARCH "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Crimson
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1091, 66)
        Me.Panel1.TabIndex = 23
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(0, 13)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(1091, 39)
        Me.TextBox2.TabIndex = 0
        Me.TextBox2.Text = "PENDING EVENTS"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(207, 517)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 21)
        Me.Label14.TabIndex = 45
        Me.Label14.Text = "11111111"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(22, 517)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(167, 21)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Total Pending Events :"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DimGray
        Me.Panel2.Controls.Add(Me.LinkLabel2)
        Me.Panel2.Controls.Add(Me.lnklblRefresh)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.dgvPending)
        Me.Panel2.Controls.Add(Me.txtCode)
        Me.Panel2.Location = New System.Drawing.Point(12, 75)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1069, 439)
        Me.Panel2.TabIndex = 46
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.Font = New System.Drawing.Font("Segoe MDL2 Assets", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.Transparent
        Me.LinkLabel2.Location = New System.Drawing.Point(993, 27)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(29, 19)
        Me.LinkLabel2.TabIndex = 35
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = ""
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'lnklblRefresh
        '
        Me.lnklblRefresh.AutoSize = True
        Me.lnklblRefresh.Font = New System.Drawing.Font("Segoe MDL2 Assets", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnklblRefresh.LinkColor = System.Drawing.Color.Transparent
        Me.lnklblRefresh.Location = New System.Drawing.Point(947, 27)
        Me.lnklblRefresh.Name = "lnklblRefresh"
        Me.lnklblRefresh.Size = New System.Drawing.Size(29, 19)
        Me.lnklblRefresh.TabIndex = 34
        Me.lnklblRefresh.TabStop = True
        Me.lnklblRefresh.Text = ""
        Me.lnklblRefresh.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        '
        'cmManage
        '
        Me.cmManage.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RescheduleThisEventToolStripMenuItem, Me.ViewEventTrackingToolStripMenuItem, Me.ViewMoreDetailsToolStripMenuItem, Me.EditEventDetailsToolStripMenuItem})
        Me.cmManage.Name = "cmManage"
        Me.cmManage.Size = New System.Drawing.Size(189, 92)
        '
        'RescheduleThisEventToolStripMenuItem
        '
        Me.RescheduleThisEventToolStripMenuItem.Name = "RescheduleThisEventToolStripMenuItem"
        Me.RescheduleThisEventToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.RescheduleThisEventToolStripMenuItem.Text = "Reschedule this event"
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
        'EditEventDetailsToolStripMenuItem
        '
        Me.EditEventDetailsToolStripMenuItem.Name = "EditEventDetailsToolStripMenuItem"
        Me.EditEventDetailsToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.EditEventDetailsToolStripMenuItem.Text = "Edit Event Details"
        '
        'Column5
        '
        Me.Column5.HeaderText = "TO"
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 110
        '
        'Column4
        '
        Me.Column4.HeaderText = "FROM"
        Me.Column4.Name = "Column4"
        Me.Column4.Width = 110
        '
        'Column7
        '
        Me.Column7.HeaderText = "VENUE"
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 300
        '
        'Column2
        '
        Me.Column2.HeaderText = "NAME OF EVENT"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 400
        '
        'Column3
        '
        Me.Column3.HeaderText = "UNIT"
        Me.Column3.Name = "Column3"
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        Me.ID.Width = 50
        '
        'dgvPending
        '
        Me.dgvPending.AllowUserToAddRows = False
        Me.dgvPending.AllowUserToDeleteRows = False
        Me.dgvPending.AllowUserToResizeColumns = False
        Me.dgvPending.AllowUserToResizeRows = False
        Me.dgvPending.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPending.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPending.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Column3, Me.Column2, Me.Column7, Me.Column4, Me.Column5})
        Me.dgvPending.Location = New System.Drawing.Point(23, 64)
        Me.dgvPending.Name = "dgvPending"
        Me.dgvPending.RowHeadersVisible = False
        Me.dgvPending.Size = New System.Drawing.Size(1022, 336)
        Me.dgvPending.TabIndex = 32
        '
        'frmPendEve
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1093, 547)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmPendEve"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.cmManage.ResumeLayout(False)
        CType(Me.dgvPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents cmManage As ContextMenuStrip
    Friend WithEvents RescheduleThisEventToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewEventTrackingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewMoreDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditEventDetailsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents lnklblRefresh As LinkLabel
    Friend WithEvents dgvPending As DataGridView
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
End Class
