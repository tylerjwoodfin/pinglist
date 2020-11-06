<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadCSV = New System.Windows.Forms.ToolStripMenuItem()
        Me.grid1 = New System.Windows.Forms.DataGridView()
        Me.ClickHereLabel = New System.Windows.Forms.Label()
        Me.Clear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Export = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewCSV = New System.Windows.Forms.ToolStripMenuItem()
        Me.About = New System.Windows.Forms.ToolStripMenuItem()
        Me.Run = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.Run})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewCSV, Me.LoadCSV, Me.Export, Me.Clear, Me.About, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'LoadCSV
        '
        Me.LoadCSV.Name = "LoadCSV"
        Me.LoadCSV.ShortcutKeyDisplayString = "Ctrl+O"
        Me.LoadCSV.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.LoadCSV.Size = New System.Drawing.Size(224, 26)
        Me.LoadCSV.Text = "Load CSV..."
        '
        'grid1
        '
        Me.grid1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid1.Location = New System.Drawing.Point(0, 30)
        Me.grid1.Name = "grid1"
        Me.grid1.RowHeadersVisible = False
        Me.grid1.RowHeadersWidth = 51
        Me.grid1.RowTemplate.Height = 24
        Me.grid1.Size = New System.Drawing.Size(800, 420)
        Me.grid1.TabIndex = 1
        Me.grid1.Visible = False
        '
        'ClickHereLabel
        '
        Me.ClickHereLabel.BackColor = System.Drawing.Color.DarkGray
        Me.ClickHereLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ClickHereLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!)
        Me.ClickHereLabel.Location = New System.Drawing.Point(0, 28)
        Me.ClickHereLabel.Margin = New System.Windows.Forms.Padding(0)
        Me.ClickHereLabel.Name = "ClickHereLabel"
        Me.ClickHereLabel.Size = New System.Drawing.Size(800, 422)
        Me.ClickHereLabel.TabIndex = 2
        Me.ClickHereLabel.Text = "Click Here or Drag a CSV"
        Me.ClickHereLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Clear
        '
        Me.Clear.Enabled = False
        Me.Clear.Name = "Clear"
        Me.Clear.Size = New System.Drawing.Size(224, 26)
        Me.Clear.Text = "Clear"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeyDisplayString = "Alt+F4"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(224, 26)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'Export
        '
        Me.Export.Enabled = False
        Me.Export.Name = "Export"
        Me.Export.Size = New System.Drawing.Size(224, 26)
        Me.Export.Text = "Export..."
        '
        'NewCSV
        '
        Me.NewCSV.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.NewCSV.Name = "NewCSV"
        Me.NewCSV.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewCSV.Size = New System.Drawing.Size(224, 26)
        Me.NewCSV.Text = "New"
        '
        'About
        '
        Me.About.Name = "About"
        Me.About.Size = New System.Drawing.Size(224, 26)
        Me.About.Text = "About"
        '
        'Run
        '
        Me.Run.AccessibleName = "Run (Ctrl + R)"
        Me.Run.AutoToolTip = True
        Me.Run.Enabled = False
        Me.Run.Image = Global.PingList.My.Resources.Resources.play1
        Me.Run.Name = "Run"
        Me.Run.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.Run.Size = New System.Drawing.Size(124, 24)
        Me.Run.Text = "Run (Ctrl+R)"
        Me.Run.ToolTipText = "Run (Ctrl+R)"
        '
        'ProgressBar
        '
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar.Location = New System.Drawing.Point(0, 427)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(800, 23)
        Me.ProgressBar.TabIndex = 3
        Me.ProgressBar.Visible = False
        '
        'Form1
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.ClickHereLabel)
        Me.Controls.Add(Me.grid1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "PingList"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadCSV As ToolStripMenuItem
    Friend WithEvents grid1 As DataGridView
    Friend WithEvents Run As ToolStripMenuItem
    Friend WithEvents ClickHereLabel As Label
    Friend WithEvents Clear As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Export As ToolStripMenuItem
    Friend WithEvents NewCSV As ToolStripMenuItem
    Friend WithEvents About As ToolStripMenuItem
    Friend WithEvents ProgressBar As ProgressBar
End Class
