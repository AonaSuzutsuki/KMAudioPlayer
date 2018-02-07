<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Updater
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
        Me.CheckBT = New System.Windows.Forms.Button()
        Me.UpdateBT = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'CheckBT
        '
        Me.CheckBT.Location = New System.Drawing.Point(31, 13)
        Me.CheckBT.Name = "CheckBT"
        Me.CheckBT.Size = New System.Drawing.Size(75, 23)
        Me.CheckBT.TabIndex = 0
        Me.CheckBT.Text = "確認"
        Me.CheckBT.UseVisualStyleBackColor = True
        '
        'UpdateBT
        '
        Me.UpdateBT.Location = New System.Drawing.Point(113, 13)
        Me.UpdateBT.Name = "UpdateBT"
        Me.UpdateBT.Size = New System.Drawing.Size(75, 23)
        Me.UpdateBT.TabIndex = 1
        Me.UpdateBT.Text = "アップデート"
        Me.UpdateBT.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        '
        'Updater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(219, 61)
        Me.Controls.Add(Me.UpdateBT)
        Me.Controls.Add(Me.CheckBT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Updater"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "アップデーター"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CheckBT As System.Windows.Forms.Button
    Friend WithEvents UpdateBT As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
