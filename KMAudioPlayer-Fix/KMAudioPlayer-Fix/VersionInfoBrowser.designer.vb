<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VersionInfoBrowser
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MainBrowser = New System.Windows.Forms.WebBrowser()
        Me.BrowserForwardBT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BrowserURLBox = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileMenuBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseMenuBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.BrowserBackBT = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainBrowser
        '
        Me.MainBrowser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainBrowser.IsWebBrowserContextMenuEnabled = False
        Me.MainBrowser.Location = New System.Drawing.Point(0, 51)
        Me.MainBrowser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.MainBrowser.Name = "MainBrowser"
        Me.MainBrowser.Size = New System.Drawing.Size(688, 340)
        Me.MainBrowser.TabIndex = 5
        '
        'BrowserForwardBT
        '
        Me.BrowserForwardBT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BrowserForwardBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.Go
        Me.BrowserForwardBT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BrowserForwardBT.Name = "BrowserForwardBT"
        Me.BrowserForwardBT.Size = New System.Drawing.Size(23, 22)
        Me.BrowserForwardBT.Text = "進む"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BrowserURLBox
        '
        Me.BrowserURLBox.Name = "BrowserURLBox"
        Me.BrowserURLBox.Size = New System.Drawing.Size(370, 25)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowserBackBT, Me.BrowserForwardBT, Me.ToolStripSeparator1, Me.BrowserURLBox, Me.ToolStripSeparator2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 26)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ToolStrip1.Size = New System.Drawing.Size(688, 25)
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(91, 18)
        Me.StatusLabel.Text = "{StatusLabel}"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenuBT})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(688, 26)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileMenuBT
        '
        Me.FileMenuBT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseMenuBT})
        Me.FileMenuBT.Name = "FileMenuBT"
        Me.FileMenuBT.Size = New System.Drawing.Size(85, 22)
        Me.FileMenuBT.Text = "ファイル(&F)"
        '
        'CloseMenuBT
        '
        Me.CloseMenuBT.Name = "CloseMenuBT"
        Me.CloseMenuBT.Size = New System.Drawing.Size(130, 22)
        Me.CloseMenuBT.Text = "閉じる(&X)"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 391)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(688, 23)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'BrowserBackBT
        '
        Me.BrowserBackBT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BrowserBackBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.Back
        Me.BrowserBackBT.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BrowserBackBT.Name = "BrowserBackBT"
        Me.BrowserBackBT.Size = New System.Drawing.Size(23, 22)
        Me.BrowserBackBT.Text = "戻る"
        '
        'VersionInfoBrowser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 414)
        Me.Controls.Add(Me.MainBrowser)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "VersionInfoBrowser"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainBrowser As System.Windows.Forms.WebBrowser
    Friend WithEvents BrowserBackBT As System.Windows.Forms.ToolStripButton
    Friend WithEvents BrowserForwardBT As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BrowserURLBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileMenuBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseMenuBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
End Class
