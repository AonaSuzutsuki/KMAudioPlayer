<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VerInfo
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
        Me.OKBT = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RevolHP = New System.Windows.Forms.LinkLabel()
        Me.AyaHP = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NameLabel = New System.Windows.Forms.LinkLabel()
        Me.VersionLabel = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.KyoroziHP = New System.Windows.Forms.LinkLabel()
        Me.NekoUmiHP = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'OKBT
        '
        Me.OKBT.BackColor = System.Drawing.SystemColors.Control
        Me.OKBT.Location = New System.Drawing.Point(323, 260)
        Me.OKBT.Name = "OKBT"
        Me.OKBT.Size = New System.Drawing.Size(96, 33)
        Me.OKBT.TabIndex = 0
        Me.OKBT.Text = "OK"
        Me.OKBT.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.NekoUmiHP)
        Me.Panel1.Controls.Add(Me.KyoroziHP)
        Me.Panel1.Controls.Add(Me.RevolHP)
        Me.Panel1.Controls.Add(Me.AyaHP)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.NameLabel)
        Me.Panel1.Controls.Add(Me.VersionLabel)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 140)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(305, 153)
        Me.Panel1.TabIndex = 1
        '
        'RevolHP
        '
        Me.RevolHP.AutoSize = True
        Me.RevolHP.Location = New System.Drawing.Point(76, 75)
        Me.RevolHP.Name = "RevolHP"
        Me.RevolHP.Size = New System.Drawing.Size(34, 12)
        Me.RevolHP.TabIndex = 16
        Me.RevolHP.TabStop = True
        Me.RevolHP.Text = "Revol"
        '
        'AyaHP
        '
        Me.AyaHP.AutoSize = True
        Me.AyaHP.Location = New System.Drawing.Point(76, 59)
        Me.AyaHP.Name = "AyaHP"
        Me.AyaHP.Size = New System.Drawing.Size(46, 12)
        Me.AyaHP.TabIndex = 15
        Me.AyaHP.TabStop = True
        Me.AyaHP.Text = "?!?!?Aya"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "協力者:"
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Location = New System.Drawing.Point(76, 15)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(40, 12)
        Me.NameLabel.TabIndex = 4
        Me.NameLabel.TabStop = True
        Me.NameLabel.Text = "{Name}"
        '
        'VersionLabel
        '
        Me.VersionLabel.AutoSize = True
        Me.VersionLabel.Location = New System.Drawing.Point(76, 37)
        Me.VersionLabel.Name = "VersionLabel"
        Me.VersionLabel.Size = New System.Drawing.Size(50, 12)
        Me.VersionLabel.TabIndex = 3
        Me.VersionLabel.Text = "{Version}"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "バージョン: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "作者: "
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("MS UI Gothic", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.Control
        Me.TitleLabel.Location = New System.Drawing.Point(26, 24)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(96, 35)
        Me.TitleLabel.TabIndex = 2
        Me.TitleLabel.Text = "{Title}"
        '
        'KyoroziHP
        '
        Me.KyoroziHP.AutoSize = True
        Me.KyoroziHP.Location = New System.Drawing.Point(76, 91)
        Me.KyoroziHP.Name = "KyoroziHP"
        Me.KyoroziHP.Size = New System.Drawing.Size(141, 12)
        Me.KyoroziHP.TabIndex = 17
        Me.KyoroziHP.TabStop = True
        Me.KyoroziHP.Text = "釣り天国ジュニア＆キョロジイ"
        '
        'NekoUmiHP
        '
        Me.NekoUmiHP.AutoSize = True
        Me.NekoUmiHP.Location = New System.Drawing.Point(76, 123)
        Me.NekoUmiHP.Name = "NekoUmiHP"
        Me.NekoUmiHP.Size = New System.Drawing.Size(29, 12)
        Me.NekoUmiHP.TabIndex = 19
        Me.NekoUmiHP.TabStop = True
        Me.NekoUmiHP.Text = "猫海"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(76, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 12)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "ぴちゅーん"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(128, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "様"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(116, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 12)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "様"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(223, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(17, 12)
        Me.Label7.TabIndex = 23
        Me.Label7.Text = "様"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(134, 107)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 24
        Me.Label8.Text = "様"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(111, 123)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(17, 12)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "様"
        '
        'VerInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(431, 305)
        Me.ControlBox = False
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.OKBT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "VerInfo"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VerInfo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OKBT As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents NameLabel As System.Windows.Forms.LinkLabel
    Friend WithEvents VersionLabel As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents RevolHP As System.Windows.Forms.LinkLabel
    Friend WithEvents AyaHP As System.Windows.Forms.LinkLabel
    Friend WithEvents NekoUmiHP As System.Windows.Forms.LinkLabel
    Friend WithEvents KyoroziHP As System.Windows.Forms.LinkLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
