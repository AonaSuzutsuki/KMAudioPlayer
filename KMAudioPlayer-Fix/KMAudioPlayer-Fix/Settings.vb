Public Class Settings

    Dim iniclass As New INI

    Private Sub Settings_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        memrefreshback.Abort()
        iniclass.Dispose()
    End Sub

    Private Sub Settings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim upcheck As Integer = iniclass.GetInt("Main", "AutoUpdate", 1, My.Application.Info.DirectoryPath & "\settings.ini")
        If (upcheck = 1) Then
            AutoCheckBox.Checked = True
        Else
            AutoCheckBox.Checked = False
        End If

        'BetaMode()

        Dim backupcheckInt As Integer = iniclass.GetInt("Main", "Backup", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        If (backupcheckInt = 1) Then
            BackupCheck.Checked = True
        Else
            BackupCheck.Checked = False
        End If

        Dim autobackupcheckInt As Integer = iniclass.GetInt("Main", "AutoBackup", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        If (autobackupcheckInt = 1) Then
            AutoBackupCheck.Checked = True
        Else
            AutoBackupCheck.Checked = False
        End If

        Dim backupInterval As Integer = iniclass.GetInt("Main", "BackupInterval", 60000, My.Application.Info.DirectoryPath & "\settings.ini")
        If (backupInterval = vbNull) Then
            BackupIntervalBox.Text = 60
        Else
            BackupIntervalBox.Text = backupInterval / 1000
        End If

        CustomSkinList.Items.Add("なし")

        Try
            Dim subFolders As String()
            subFolders = System.IO.Directory.GetDirectories(My.Application.Info.DirectoryPath & "\Skins", "*", System.IO.SearchOption.AllDirectories)
            CustomSkinList.Items.AddRange(subFolders)

            Dim FolderName As String
            Dim RenameFolder As String
            For SkinNum = 1 To CustomSkinList.Items.Count
                'CustomSkinList.Items.Item(SkinNum) += "\"
                FolderName = CustomSkinList.Items.Item(SkinNum)
                RenameFolder = System.IO.Path.GetFileName(FolderName)
                CustomSkinList.Items.Item(SkinNum) = RenameFolder
            Next

            'SettingTabMain.TabPages.Remove(CustomSkinTab)
        Catch
        End Try

        Dim customskin As String = iniclass.GetStr("Main", "CustomSkin", "なし", My.Application.Info.DirectoryPath & "\settings.ini")
        CustomSkinList.SelectedItem = customskin

        SettingTabMain.TabPages.RemoveAt(2)

        'Try
        '    memrefreshback.Start()
        'Catch ex As Exception
        '    memrefreshback.Abort()
        'End Try
    End Sub

    Private Sub BetaMode()
        AutoCheckBox.Enabled = False
        AutoCheckBox.Checked = False
    End Sub

    Private Sub BackupIntervalBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles BackupIntervalBox.KeyPress
        If (e.KeyChar < "0"c OrElse "9"c < e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub BackupHelpBT_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles BackupHelpBT.LinkClicked
        MessageBox.Show("アプリケーション終了時に再生状態やリストをバックアップし、次回起動時に復元します。", "バックアップ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub AutoBackupHelp_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles AutoBackupHelp.LinkClicked
        MessageBox.Show("定期的にバックアップを作成します。これにより予期せぬ終了にもある程度対応できます。", "バックアップ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
    End Sub

    Private Sub SaveBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveBT.Click
        If (AutoCheckBox.Checked) Then
            iniclass.WriteInt("Main", "AutoUpdate", 1, My.Application.Info.DirectoryPath & "\settings.ini")
        Else
            iniclass.WriteInt("Main", "AutoUpdate", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        End If

        If (BackupCheck.Checked) Then
            iniclass.WriteInt("Main", "Backup", 1, My.Application.Info.DirectoryPath & "\settings.ini")
        Else
            iniclass.WriteInt("Main", "Backup", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        End If

        'AutoBackup
        If (AutoBackupCheck.Checked) Then
            If (BackupIntervalBox.Text = vbNullString) Then
                MessageBox.Show("間隔値を空にすることはできません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                If (CInt(BackupIntervalBox.Text) >= 10) Then
                    Dim interval As Integer = CInt(BackupIntervalBox.Text) * 1000
                    iniclass.WriteInt("Main", "BackupInterval", interval, My.Application.Info.DirectoryPath & "\settings.ini")
                    MainForm.BackupTimer.Interval = interval
                Else
                    Dim alert As DialogResult = MessageBox.Show("値を小さくしすぎるとHDDアクセスが増加します。よろしいですか？", "お知らせ", _
                                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If (alert = DialogResult.Yes) Then
                        Dim interval As Integer = CInt(BackupIntervalBox.Text) * 1000
                        iniclass.WriteInt("Main", "BackupInterval", interval, My.Application.Info.DirectoryPath & "\settings.ini")
                        MainForm.BackupTimer.Interval = interval
                    End If
                End If
            End If
            iniclass.WriteInt("Main", "AutoBackup", 1, My.Application.Info.DirectoryPath & "\settings.ini")
            MainForm.BackupTimer.Stop()
            MainForm.BackupTimer.Start()
        Else
            iniclass.WriteInt("Main", "AutoBackup", 0, My.Application.Info.DirectoryPath & "\settings.ini")
            MainForm.BackupTimer.Stop()
        End If

        'SkinChanger
        If Not (CustomSkinList.SelectedIndex < 0) Then
            If (CustomSkinList.SelectedItem = "なし") Then
                MainForm.skinChange(1)
                iniclass.WriteStr("Main", "CustomSkin", CustomSkinList.SelectedItem, My.Application.Info.DirectoryPath & "\settings.ini")
            Else
                'If (IsAdministrator() = True) Then
                Try
                    getObject(My.Application.Info.DirectoryPath & "\Skins\" & CustomSkinList.SelectedItem.ToString)
                Catch
                    MessageBox.Show("不明なエラー", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                iniclass.WriteStr("Main", "CustomSkin", CustomSkinList.SelectedItem, My.Application.Info.DirectoryPath & "\settings.ini")
                'Else
                'MessageBox.Show("スキンの変更をする場合、管理者権限で実行してください。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            End If
        End If

        Close()
    End Sub

    'Public Sub setSkin(ByVal filepath As String)
    '    Dim MainBack As String = iniclass.GetStr("Images", "MainBack", Nothing, filepath & "\info.ini")
    '    MainForm.BackgroundImage = System.Drawing.Bitmap.FromFile(filepath & "\" & MainBack)
    'End Sub

    Public Sub setObject(ByVal filepath As String)
        '保存するクラス(SampleClass)のインスタンスを作成
        Dim obj As New DataClass
        obj.FontColor = "0, 0, 0, 0"

        'XmlSerializerオブジェクトを作成
        'オブジェクトの型を指定する
        Dim serializer As New System.Xml.Serialization.XmlSerializer( _
            GetType(DataClass))
        '書き込むファイルを開く
        Dim fs As New System.IO.FileStream(filepath, System.IO.FileMode.Create)
        'シリアル化し、XMLファイルに保存する
        serializer.Serialize(fs, obj)
        'ファイルを閉じる
        fs.Close()
    End Sub

    Public Sub getObject(ByVal filepath As String)
        '保存元のファイル名
        Dim fileName As String = filepath & "\object.config"

        'XmlSerializerオブジェクトを作成
        Dim serializer As _
            New System.Xml.Serialization.XmlSerializer(GetType(DataClass))
        '読み込むファイルを開く
        Dim fs As New System.IO.FileStream( _
            fileName, System.IO.FileMode.Open)
        'XMLファイルから読み込み、逆シリアル化する
        Dim obj As DataClass = CType(serializer.Deserialize(fs), DataClass)
        'ファイルを閉じる
        fs.Close()

        If (obj.Identification > 0) Then
            MainForm.skinChange(obj.Identification)
        Else

            Dim colors As New Drawing.ColorConverter
            MainForm.MusicList.BackColor = colors.ConvertFromString(obj.MusiListBackColor)
            MainForm.MusicListMenu.BackColor = colors.ConvertFromString(obj.MusiListBackColor)
            MainForm.ArtWorkMenu.BackColor = colors.ConvertFromString(obj.MusiListBackColor)
            MainForm.MainMenu.BackColor = colors.ConvertFromString(obj.MusiListBackColor)
            MainForm.VolumeBar.BackColor = colors.ConvertFromString(obj.VolumeBarColor)

            MainForm.TimeLabel.ForeColor = colors.ConvertFromString(obj.FontColor)
            MainForm.LoopStateLabel.ForeColor = colors.ConvertFromString(obj.FontColor)
            MainForm.MusicList.ForeColor = colors.ConvertFromString(obj.FontColor)
            MainForm.VolumeLabel.ForeColor = colors.ConvertFromString(obj.FontColor)

            MainForm.BackgroundImage = System.Drawing.Bitmap.FromFile(filepath & "\" & obj.MainBackImg)

            MainForm.SkinTransparent()
        End If
    End Sub

    Public Shared Function IsAdministrator() As Boolean
        '現在のユーザーを表すWindowsIdentityオブジェクトを取得する
        Dim wi As System.Security.Principal.WindowsIdentity = _
            System.Security.Principal.WindowsIdentity.GetCurrent()
        'WindowsPrincipalオブジェクトを作成する
        Dim wp As New System.Security.Principal.WindowsPrincipal(wi)
        'Administratorsグループに属しているか調べる
        Return wp.IsInRole( _
            System.Security.Principal.WindowsBuiltInRole.Administrator)
    End Function


    Private Sub CancelBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelBT.Click
        Close()
    End Sub



    Private Sub UrselfMemFreeBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UrselfMemFreeBT.Click
        System.GC.Collect()
    End Sub

    Dim memrefreshback As New System.Threading.Thread( _
            New System.Threading.ThreadStart( _
            AddressOf MemRefresh))
    Private Sub MemRefresh()
        Dim memnum As Double
        Do
            memnum = My.Application.Info.WorkingSet / 1024 / 1024
            Me.Invoke(New MethodInvoker(Sub()
                                            MemLabel.Text = memnum & "MB"
                                        End Sub))
            System.Threading.Thread.Sleep(1000)
        Loop
    End Sub
End Class

Public Class DataClass
    Public Identification As Integer
    Public MainBackImg As String
    Public MusiListBackColor As String
    Public VolumeBarColor As String
    Public FontColor As String
End Class