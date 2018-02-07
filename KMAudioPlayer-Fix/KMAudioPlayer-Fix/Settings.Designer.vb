<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.SettingTabMain = New System.Windows.Forms.TabControl()
        Me.GeneralTab = New System.Windows.Forms.TabPage()
        Me.AutoBackupHelp = New System.Windows.Forms.LinkLabel()
        Me.AutoBackupCheck = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BackupIntervalBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BackupHelpBT = New System.Windows.Forms.LinkLabel()
        Me.BackupCheck = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.AutoCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CustomSkinTab = New System.Windows.Forms.TabPage()
        Me.CustomSkinList = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TestTab = New System.Windows.Forms.TabPage()
        Me.MemLabel = New System.Windows.Forms.Label()
        Me.UrselfMemFreeBT = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SaveBT = New System.Windows.Forms.Button()
        Me.CancelBT = New System.Windows.Forms.Button()
        Me.SettingTabMain.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.CustomSkinTab.SuspendLayout()
        Me.TestTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'SettingTabMain
        '
        Me.SettingTabMain.Controls.Add(Me.GeneralTab)
        Me.SettingTabMain.Controls.Add(Me.CustomSkinTab)
        Me.SettingTabMain.Controls.Add(Me.TestTab)
        Me.SettingTabMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.SettingTabMain.Location = New System.Drawing.Point(0, 0)
        Me.SettingTabMain.Name = "SettingTabMain"
        Me.SettingTabMain.SelectedIndex = 0
        Me.SettingTabMain.Size = New System.Drawing.Size(284, 253)
        Me.SettingTabMain.TabIndex = 0
        '
        'GeneralTab
        '
        Me.GeneralTab.Controls.Add(Me.AutoBackupHelp)
        Me.GeneralTab.Controls.Add(Me.AutoBackupCheck)
        Me.GeneralTab.Controls.Add(Me.Label6)
        Me.GeneralTab.Controls.Add(Me.BackupIntervalBox)
        Me.GeneralTab.Controls.Add(Me.Label5)
        Me.GeneralTab.Controls.Add(Me.BackupHelpBT)
        Me.GeneralTab.Controls.Add(Me.BackupCheck)
        Me.GeneralTab.Controls.Add(Me.Label4)
        Me.GeneralTab.Controls.Add(Me.AutoCheckBox)
        Me.GeneralTab.Controls.Add(Me.Label1)
        Me.GeneralTab.Location = New System.Drawing.Point(4, 22)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTab.Size = New System.Drawing.Size(276, 227)
        Me.GeneralTab.TabIndex = 0
        Me.GeneralTab.Text = "全般"
        Me.GeneralTab.UseVisualStyleBackColor = True
        '
        'AutoBackupHelp
        '
        Me.AutoBackupHelp.AutoSize = True
        Me.AutoBackupHelp.Location = New System.Drawing.Point(200, 101)
        Me.AutoBackupHelp.Name = "AutoBackupHelp"
        Me.AutoBackupHelp.Size = New System.Drawing.Size(17, 12)
        Me.AutoBackupHelp.TabIndex = 9
        Me.AutoBackupHelp.TabStop = True
        Me.AutoBackupHelp.Text = "？"
        '
        'AutoBackupCheck
        '
        Me.AutoBackupCheck.AutoSize = True
        Me.AutoBackupCheck.Location = New System.Drawing.Point(23, 100)
        Me.AutoBackupCheck.Name = "AutoBackupCheck"
        Me.AutoBackupCheck.Size = New System.Drawing.Size(171, 16)
        Me.AutoBackupCheck.TabIndex = 8
        Me.AutoBackupCheck.Text = "定期的にバックアップを作成する"
        Me.AutoBackupCheck.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(146, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "秒"
        '
        'BackupIntervalBox
        '
        Me.BackupIntervalBox.Location = New System.Drawing.Point(40, 134)
        Me.BackupIntervalBox.Name = "BackupIntervalBox"
        Me.BackupIntervalBox.Size = New System.Drawing.Size(100, 19)
        Me.BackupIntervalBox.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 119)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 12)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "バックアップ間隔"
        '
        'BackupHelpBT
        '
        Me.BackupHelpBT.AutoSize = True
        Me.BackupHelpBT.Location = New System.Drawing.Point(200, 78)
        Me.BackupHelpBT.Name = "BackupHelpBT"
        Me.BackupHelpBT.Size = New System.Drawing.Size(17, 12)
        Me.BackupHelpBT.TabIndex = 4
        Me.BackupHelpBT.TabStop = True
        Me.BackupHelpBT.Text = "？"
        '
        'BackupCheck
        '
        Me.BackupCheck.AutoSize = True
        Me.BackupCheck.Location = New System.Drawing.Point(23, 77)
        Me.BackupCheck.Name = "BackupCheck"
        Me.BackupCheck.Size = New System.Drawing.Size(171, 16)
        Me.BackupCheck.TabIndex = 3
        Me.BackupCheck.Text = "終了時にリストをバックアップする"
        Me.BackupCheck.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 12)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "バックアップ"
        '
        'AutoCheckBox
        '
        Me.AutoCheckBox.AutoSize = True
        Me.AutoCheckBox.Location = New System.Drawing.Point(23, 28)
        Me.AutoCheckBox.Name = "AutoCheckBox"
        Me.AutoCheckBox.Size = New System.Drawing.Size(119, 16)
        Me.AutoCheckBox.TabIndex = 1
        Me.AutoCheckBox.Text = "起動時にチェックする"
        Me.AutoCheckBox.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "アップデート"
        '
        'CustomSkinTab
        '
        Me.CustomSkinTab.Controls.Add(Me.CustomSkinList)
        Me.CustomSkinTab.Controls.Add(Me.Label2)
        Me.CustomSkinTab.Location = New System.Drawing.Point(4, 22)
        Me.CustomSkinTab.Name = "CustomSkinTab"
        Me.CustomSkinTab.Padding = New System.Windows.Forms.Padding(3)
        Me.CustomSkinTab.Size = New System.Drawing.Size(276, 227)
        Me.CustomSkinTab.TabIndex = 1
        Me.CustomSkinTab.Text = "スキン"
        Me.CustomSkinTab.UseVisualStyleBackColor = True
        '
        'CustomSkinList
        '
        Me.CustomSkinList.FormattingEnabled = True
        Me.CustomSkinList.ItemHeight = 12
        Me.CustomSkinList.Location = New System.Drawing.Point(32, 22)
        Me.CustomSkinList.Name = "CustomSkinList"
        Me.CustomSkinList.Size = New System.Drawing.Size(236, 196)
        Me.CustomSkinList.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "カスタムスキン"
        '
        'TestTab
        '
        Me.TestTab.Controls.Add(Me.MemLabel)
        Me.TestTab.Controls.Add(Me.UrselfMemFreeBT)
        Me.TestTab.Controls.Add(Me.Label3)
        Me.TestTab.Location = New System.Drawing.Point(4, 22)
        Me.TestTab.Name = "TestTab"
        Me.TestTab.Padding = New System.Windows.Forms.Padding(3)
        Me.TestTab.Size = New System.Drawing.Size(276, 227)
        Me.TestTab.TabIndex = 2
        Me.TestTab.Text = "テスト"
        Me.TestTab.UseVisualStyleBackColor = True
        '
        'MemLabel
        '
        Me.MemLabel.AutoSize = True
        Me.MemLabel.Location = New System.Drawing.Point(122, 33)
        Me.MemLabel.Name = "MemLabel"
        Me.MemLabel.Size = New System.Drawing.Size(26, 12)
        Me.MemLabel.TabIndex = 2
        Me.MemLabel.Text = "0KB"
        '
        'UrselfMemFreeBT
        '
        Me.UrselfMemFreeBT.Location = New System.Drawing.Point(26, 28)
        Me.UrselfMemFreeBT.Name = "UrselfMemFreeBT"
        Me.UrselfMemFreeBT.Size = New System.Drawing.Size(90, 23)
        Me.UrselfMemFreeBT.TabIndex = 1
        Me.UrselfMemFreeBT.Text = "実行する"
        Me.UrselfMemFreeBT.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "手動メモリ解放"
        '
        'SaveBT
        '
        Me.SaveBT.Location = New System.Drawing.Point(114, 259)
        Me.SaveBT.Name = "SaveBT"
        Me.SaveBT.Size = New System.Drawing.Size(75, 23)
        Me.SaveBT.TabIndex = 1
        Me.SaveBT.Text = "保存"
        Me.SaveBT.UseVisualStyleBackColor = True
        '
        'CancelBT
        '
        Me.CancelBT.Location = New System.Drawing.Point(197, 259)
        Me.CancelBT.Name = "CancelBT"
        Me.CancelBT.Size = New System.Drawing.Size(75, 23)
        Me.CancelBT.TabIndex = 2
        Me.CancelBT.Text = "キャンセル"
        Me.CancelBT.UseVisualStyleBackColor = True
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 294)
        Me.Controls.Add(Me.CancelBT)
        Me.Controls.Add(Me.SaveBT)
        Me.Controls.Add(Me.SettingTabMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Settings"
        Me.Text = "設定"
        Me.SettingTabMain.ResumeLayout(False)
        Me.GeneralTab.ResumeLayout(False)
        Me.GeneralTab.PerformLayout()
        Me.CustomSkinTab.ResumeLayout(False)
        Me.CustomSkinTab.PerformLayout()
        Me.TestTab.ResumeLayout(False)
        Me.TestTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SettingTabMain As System.Windows.Forms.TabControl
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents AutoCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SaveBT As System.Windows.Forms.Button
    Friend WithEvents CancelBT As System.Windows.Forms.Button
    Friend WithEvents CustomSkinTab As System.Windows.Forms.TabPage
    Friend WithEvents CustomSkinList As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TestTab As System.Windows.Forms.TabPage
    Friend WithEvents UrselfMemFreeBT As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents MemLabel As System.Windows.Forms.Label
    Friend WithEvents BackupHelpBT As System.Windows.Forms.LinkLabel
    Friend WithEvents BackupCheck As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BackupIntervalBox As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents AutoBackupHelp As System.Windows.Forms.LinkLabel
    Friend WithEvents AutoBackupCheck As System.Windows.Forms.CheckBox
End Class
