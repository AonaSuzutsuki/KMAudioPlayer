Imports System.Net.Sockets
Imports System.Net
Imports System.Threading
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports WMPLib
Imports System.Runtime.InteropServices


Public Class MainForm

    Dim mcClass As New Controls
    Dim iniclass As New INI
    Public AutoInt As Integer

    Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        iniclass.WriteInt("Main", "Volume", MainPlayer.settings.volume, My.Application.Info.DirectoryPath & "\settings.ini")
        iniclass.WriteInt("Main", "X", Me.Location.X, My.Application.Info.DirectoryPath & "\settings.ini")
        iniclass.WriteInt("Main", "Y", Me.Location.Y, My.Application.Info.DirectoryPath & "\settings.ini")
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim BackupNum As Integer = iniclass.GetInt("Main", "Backup", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        If (BackupNum = 1) Then
            Try
                If Not (System.IO.Directory.Exists("temp")) Then
                    System.IO.Directory.CreateDirectory("temp")
                End If
                If (MusicPathList.Items.Count > 0) Then
                    Dim wplclass As New WPLControl
                    Dim media As New ArrayList
                    For i = 0 To MusicPathList.Items.Count - 1
                        media.Add(MusicPathList.Items.Item(i))
                    Next
                    wplclass.WPLCreate(My.Application.Info.DirectoryPath & "\temp\backup", media)

                    'Dim List As String
                    'Dim title As String = "  <title>" & "KMAudioPlayer" & "</title>"

                    'Dim musicliststr As String
                    'For i = 0 To MusicPathList.Items.Count - 1
                    '    musicliststr += "   <media src=""" & MusicPathList.Items.Item(i) & """/>" & vbCrLf
                    'Next

                    'Dim WriteStr As String = "<?wpl version=""1.0""?>" & vbCrLf & _
                    '    "<smil>" & vbCrLf & _
                    '    " <head>" & vbCrLf & _
                    '    "  <meta name=""Generator"" content=""Microsoft Windows Media Player -- KMAudioPlayer""/>" & vbCrLf & _
                    '    "  <meta name=""ItemCount"" content=""1""/>" & vbCrLf & _
                    '    title & vbCrLf & _
                    '    " </head>" & vbCrLf & _
                    '    " <body>" & vbCrLf & _
                    '    "  <seq>" & vbCrLf & _
                    '    musicliststr & _
                    '    "  </seq>" & vbCrLf & _
                    '    " </body>" & vbCrLf & _
                    '    "</smil>"

                    'Using sw As New System.IO.StreamWriter(My.Application.Info.DirectoryPath & "\temp\backup", False, System.Text.Encoding.UTF8)
                    '    sw.Write(WriteStr)
                    'End Using

                    If Not (MainPlayer.URL = Nothing) Then
                        iniclass.WriteInt("Backup", "ActiveMusic", MusicPathList.SelectedItem, My.Application.Info.DirectoryPath & "\temp\backup.ini")
                        If (playstate = 0) Then
                            iniclass.WriteInt("Backup", "StateTime", 0, My.Application.Info.DirectoryPath & "\temp\backup.ini")
                        Else
                            iniclass.WriteInt("Backup", "StateTime", MainPlayer.Ctlcontrols.currentPosition, My.Application.Info.DirectoryPath & "\temp\backup.ini")
                        End If
                        iniclass.WriteInt("Backup", "AllTime", MainPlayer.currentMedia.duration, My.Application.Info.DirectoryPath & "\temp\backup.ini")
                    End If
                End If
            Catch
                Application.Exit()
            End Try
        End If
    End Sub

    Private Sub BackupTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupTimer.Tick
        Dim AutoBackupNum As Integer = iniclass.GetInt("Main", "AutoBackup", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        If (AutoBackupNum = 1) Then
            Try
                If Not (System.IO.Directory.Exists("temp")) Then
                    System.IO.Directory.CreateDirectory("temp")
                End If

                If (MusicPathList.Items.Count > 0) Then
                    Dim wplclass As New WPLControl
                    Dim media As New ArrayList
                    For i = 0 To MusicPathList.Items.Count - 1
                        media.Add(MusicPathList.Items.Item(i))
                    Next
                    wplclass.WPLCreate(My.Application.Info.DirectoryPath & "\temp\backup", media)

                    If Not (MainPlayer.URL = Nothing) Then
                        iniclass.WriteInt("Backup", "ActiveMusic", MusicPathList.SelectedItem, My.Application.Info.DirectoryPath & "\temp\backup.ini")
                        If (playstate = 0) Then
                            iniclass.WriteInt("Backup", "StateTime", 0, My.Application.Info.DirectoryPath & "\temp\backup.ini")
                        Else
                            iniclass.WriteInt("Backup", "StateTime", MainPlayer.Ctlcontrols.currentPosition, My.Application.Info.DirectoryPath & "\temp\backup.ini")
                        End If
                        iniclass.WriteInt("Backup", "AllTime", MainPlayer.currentMedia.duration, My.Application.Info.DirectoryPath & "\temp\backup.ini")
                    End If
                End If
            Catch
                BackupTimer.Stop()
            End Try
        End If
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.Title
        Me.SetStyle(ControlStyles.SupportsTransparentBackColor, True)

        Dim cmds As String() = System.Environment.GetCommandLineArgs()
        If (cmds.Length > 1) Then
            Dim i As Integer
            For i = 1 To cmds.Length - 1
                If (cmds(i).IndexOf(".kmplist") > -1) Then
                    OpenPlaylistLoad(cmds(i))
                ElseIf (cmds(i).IndexOf(".wpl") > -1) Then
                    OpenWPLLoad(cmds(i))
                Else
                    MusicPathList.Items.Add(cmds(i))
                    MusicPathList2.Items.Add(cmds(i))
                    Dim FileName As String = IO.Path.GetFileNameWithoutExtension(cmds(i))
                    MusicList.Items.Add(FileName)
                End If
            Next i
            MediaPlayBT.Enabled = True
        End If

        Directory.SetCurrentDirectory(My.Application.Info.DirectoryPath)

        If (Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName).Length > 1) Then

        End If

        Dim AddMusic As Integer = iniclass.GetInt("Main", "AddMusic", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        If (AddMusic = 1) Then

        End If

        Dim UpdateNum As Integer = iniclass.GetInt("Main", "AutoUpdate", 1, My.Application.Info.DirectoryPath & "\settings.ini")
        If (UpdateNum = 1) Then
            CheckStart()
        End If

        Dim locationx As Integer = iniclass.GetInt("Main", "X", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        Dim locationy As Integer = iniclass.GetInt("Main", "Y", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        Me.Location = New Point(locationx, locationy)

        MainPlayer.settings.autoStart = False
        MediaPositionBar.Enabled = False

        VolumeBar.Value = MainPlayer.settings.volume
        VolumeLabel.Text = MainPlayer.settings.volume
        VolumePanel.Parent = Me
        VolumePanel.BackColor = Color.Transparent

        'アートワーク
        artshownum = iniclass.GetInt("Main", "ShowArtWork", 1, My.Application.Info.DirectoryPath & "\settings.ini")
        If (artshownum = 1) Then
            ArtWork.Visible = True
            ArtWorkMenuArtShow.Checked = True
            'ArtWork.BackColor = Color.Black
        Else
            ArtWork.Visible = True
            ArtWorkMenuArtShow.Checked = False
            'ArtWork.BackColor = Me.BackColor
        End If
        ArtWork.Size = New Size(319, 243)
        ArtWork.Image = My.Resources.artwork
        ArtWork.AllowDrop = True

        'Lyric
        lyricshownum = iniclass.GetInt("Main", "ShowLyric", 1, My.Application.Info.DirectoryPath & "\settings.ini")
        If (lyricshownum = 1) Then
            'LyricBox.Visible = True
            ArtWorkMenuLyric.Checked = True
            'ArtWork.BackColor = Color.Black
        Else
            'LyricBox.Visible = False
            ArtWorkMenuLyric.Checked = False
            'ArtWork.BackColor = Me.BackColor
        End If
        LyricBox.Visible = False
        LyricBox.Parent = Me.ArtWork
        LyricBox.BackAlpha = 30
        LyricBox.Location = New Size(0, 0)
        LyricBox.Size = New Size(319, 243)


        'ループ
        LoopPlay = iniclass.GetInt("Main", "LoopPlay", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        If (LoopPlay = 1) Then
            MusicMenuLoopPlay.Checked = True
            LoopStateLabel.Text = "連続再生ON"
        Else
            MusicMenuLoopPlay.Checked = False
            LoopStateLabel.Text = "連続再生OFF"
        End If

        'Skin
        Dim customcolor As String
        customcolor = iniclass.GetStr("Main", "CustomSkin", "", My.Application.Info.DirectoryPath & "\settings.ini")
        If (customcolor = "") Then

        Else
            Dim settingsclass As New Settings
            Try
                settingsclass.getObject(My.Application.Info.DirectoryPath & "\Skins\" & customcolor)
            Catch

            End Try
        End If

        Dim vol As Integer = iniclass.GetInt("Main", "Volume", 100, My.Application.Info.DirectoryPath & "\settings.ini")
        MainPlayer.settings.volume = vol
        VolumeBar.Value = vol
        VolumeLabel.Text = vol

        Dim BackupNum As Integer = iniclass.GetInt("Main", "Backup", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        Dim AutoBackupNum As Integer = iniclass.GetInt("Main", "AutoBackup", 0, My.Application.Info.DirectoryPath & "\settings.ini")
        Dim BackupInterval As Integer = iniclass.GetInt("Main", "BackupInterval", 60000, My.Application.Info.DirectoryPath & "\settings.ini")
        If (BackupNum = 1) Then
            If (System.IO.File.Exists(My.Application.Info.DirectoryPath & "\temp\backup")) Then
                Try
                    OpenTempList(My.Application.Info.DirectoryPath & "\temp")
                Catch
                    MusicPathList.Items.Clear()
                    MusicPathList2.Items.Clear()
                    MusicList.Items.Clear()
                    MainPlayer.Ctlcontrols.currentPosition = 0
                    MainPlayer.URL = ""
                    MediaPositionBar.Maximum = 0
                    MediaPositionBar.Value = 0
                    MediaPositionBar.Enabled = False

                    Dim second As Integer = 0
                    Dim second2 As Integer = 0
                    Dim ts As TimeSpan = New TimeSpan(0, 0, second)
                    Dim ts2 As TimeSpan = New TimeSpan(0, 0, second2)
                    TimeLabel.Text = ts.ToString & "/" & ts2.ToString
                End Try
            End If
        End If
        If (MusicPathList.Items.Count < 1) Then
            MediaPlayBT.Enabled = False
        End If
        If (AutoBackupNum = 1) Then
            BackupTimer.Interval = BackupInterval
            BackupTimer.Start()
        Else
            BackupTimer.Interval = BackupInterval
            BackupTimer.Stop()
        End If

        Dim visiblity As String = iniclass.GetStr("Admins", "Visivility", "false", My.Application.Info.DirectoryPath & "\settings.ini")
        If (visiblity = "true") Then
            CToolStripMenuItem.Visible = True
            DToolStripMenuItem.Visible = True
            MemBox.Visible = True
            EToolStripMenuItem.Visible = True
            MemTimer.Start()
            AToolStripMenuItem1.Visible = True
            BToolStripMenuItem1.Visible = True
            AddToolStripMenuItem.Visible = True
        End If
    End Sub

    Private Sub OpenTempList(ByVal MainFileName As String)
        OpenWPLLoad(MainFileName & "\backup")

        Dim activemusic As String
        Dim statetime As Double
        Dim alltime As Double
        activemusic = iniclass.GetStr("Backup", "ActiveMusic", "", MainFileName & "\backup.ini")
        statetime = iniclass.GetStr("Backup", "StateTime", 0, MainFileName & "\backup.ini")
        alltime = iniclass.GetStr("Backup", "AllTime", 0, MainFileName & "\backup.ini")
        MusicPathList.SelectedItem = activemusic
        MusicList.SelectedItem = System.IO.Path.GetFileNameWithoutExtension(activemusic)

        MainPlayer.URL = activemusic
        MainPlayer.Ctlcontrols.currentPosition = statetime
        If Not (alltime = Nothing) Then
            MediaPositionBar.Maximum = CInt(alltime)
            MediaPositionBar.Value = CInt(statetime)
            MediaPositionBar.Enabled = True

            Dim second As Integer = CInt(statetime)
            Dim second2 As Integer = CInt(alltime)
            Dim ts As TimeSpan = New TimeSpan(0, 0, second)
            Dim ts2 As TimeSpan = New TimeSpan(0, 0, second2)
            TimeLabel.Text = ts.ToString & "/" & ts2.ToString
        End If

        System.IO.Directory.Delete(MainFileName, True)
    End Sub

    Private Sub OpenPlaylistLoad(ByVal MainFileName As String)
        Dim contclass As New Controls

        MusicPathList.Items.Clear()
        MusicPathList2.Items.Clear()
        MusicList.Items.Clear()
        Using sr As New System.IO.StreamReader(MainFileName, System.Text.Encoding.UTF8)
            Dim alertnum As Integer = 0
            While sr.Peek() > -1
                Dim filename As String
                filename = sr.ReadLine()
                If (contclass.GetStringFix(filename, 2) = "NULL") Then
                    Dim result As DialogResult

                    If (alertnum = 0) Then
                        result = MessageBox.Show("古いプレイリストの可能性があります。" & vbCrLf & _
                                                                     "追加しますか？" & vbCrLf & _
                                                                     "※_が含まれる楽曲は正常に追加できません。" & vbCrLf & _
                                                                     "※この問題は次のプレイリスト作成にて修復されます。", _
                                             "確認", _
                                             MessageBoxButtons.YesNo, _
                                             MessageBoxIcon.Exclamation)
                    End If

                    If (result = DialogResult.Yes Or alertnum = 1) Then
                        MusicPathList.Items.Add(contclass.GetString(filename, 1))
                        MusicPathList2.Items.Add(contclass.GetString(filename, 1))
                        MusicList.Items.Add(contclass.GetString(filename, 2))
                        alertnum = 1
                    ElseIf (result = DialogResult.No Or alertnum = 2) Then
                        alertnum = 2
                    End If
                Else
                    MusicPathList.Items.Add(contclass.GetStringFix(filename, 1))
                    MusicPathList2.Items.Add(contclass.GetStringFix(filename, 1))
                    MusicList.Items.Add(contclass.GetStringFix(filename, 2))
                End If
            End While
        End Using
        MediaPlayBT.Enabled = True
    End Sub

    Private Sub OpenWPLLoad(ByVal MainFileName As String)
        'Using sr As New System.IO.StreamReader(MainFileName, System.Text.Encoding.UTF8)
        '    While sr.Peek > -1
        '        returnstr = StringSearchMethod("<media src=""(.*?)""/>", sr.ReadLine, "1")
        '        If Not (returnstr = vbNullString) Then
        '            'returnstr = returnstr.Replace("..\..\..\..\", "C:\")
        '            System.Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(MainFileName)
        '            returnstr = System.IO.Path.GetFullPath(returnstr)
        '            MusicPathList.Items.Add(returnstr)
        '            MusicPathList2.Items.Add(returnstr)
        '            MusicList.Items.Add(IO.Path.GetFileNameWithoutExtension(returnstr))
        '        End If
        '    End While
        'End Using
        Dim wplclass As New WPLControl
        Dim media As ArrayList
        Dim returnstr As String
        Dim returnint As Integer = wplclass.WPLLoad(MainFileName, media)
        If (returnint = 0) Then
            For i = 0 To media.Count - 1
                System.Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(MainFileName)
                returnstr = System.IO.Path.GetFullPath(media.Item(i))
                MusicPathList.Items.Add(returnstr)
                MusicPathList2.Items.Add(returnstr)
                MusicList.Items.Add(IO.Path.GetFileNameWithoutExtension(returnstr))
            Next
        End If

        System.Environment.CurrentDirectory = My.Application.Info.DirectoryPath
        MediaPlayBT.Enabled = True
    End Sub

    Private Sub MainForm_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        'MusicUpBT.Location = New Size(Me.Size.Width - 59, MusicUpBT.Location.Y)
        'MusicDownBT.Location = New Size(Me.Size.Width - 59, MusicDownBT.Location.Y)
        'MediaPositionBar.Size = New Size(Me.Size.Width - 40, MediaPositionBar.Size.Height)
        'MediaVolumeBT.Location = New Size(Me.Size.Width - 62, MediaVolumeBT.Location.Y)
    End Sub


    '起動アップデートチェック
    Dim t As New System.Threading.Thread( _
            New System.Threading.ThreadStart( _
            AddressOf UpdateCheckback))

    Private Sub CheckStart()
        Try
            t.IsBackground = True
            t.Start()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub UpdateCheckback()
        UpdateCheckNoAlert()
        t.Abort()
    End Sub

    Private Sub UpdateCheckNoAlert()
        Dim version As String
        Try
            Using wc As New System.Net.WebClient()
                wc.DownloadFile("http://kimamaningen.futene.net/HTML/Downloads/TGSUpdate/KMAudioPlayer/version.txt", "version.txt")
            End Using
        Catch ex As Exception

        End Try

        Try
            Using sr As New System.IO.StreamReader("version.txt")
                version = sr.ReadToEnd()
            End Using
            If (My.Application.Info.Version.ToString = version) Then
                Me.Invoke(New MethodInvoker(Sub()
                                                AutoInt = 0
                                            End Sub))
                System.IO.File.Delete("version.txt")
            Else
                MsgBox("アップデートがあります。", vbInformation, "お知らせ")
                Me.Invoke(New MethodInvoker(Sub()
                                                AutoInt = 1
                                            End Sub))
                System.IO.File.Delete("version.txt")
            End If
        Catch

        End Try
    End Sub


    'Picグラデーション
    Private Function PicBoxBack()
        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(ArtWork.Width, ArtWork.Height)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        '縦に白から黒へのグラデーションのブラシを作成
        'g.VisibleClipBoundsは表示クリッピング領域に外接する四角形
        Dim gb As New LinearGradientBrush( _
            g.VisibleClipBounds, _
            Color.Gray, _
            Color.Black, _
            LinearGradientMode.Vertical)

        '四角を描く
        g.FillRectangle(gb, g.VisibleClipBounds)

        'リソースを解放する
        gb.Dispose()
        g.Dispose()

        'PictureBox1に表示する
        Return canvas
    End Function


    'メインメニュー
    Private Sub MainMenuCreatePlaylist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuCreatePlaylist.Click
        CreatePlaylist()
    End Sub

    Private Sub MainMenuOpenPlaylist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuOpenPlaylist.Click
        OpenPlaylist()
    End Sub

    Private Sub MainMenuExitBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuExitBT.Click
        Close()
    End Sub

    Private Sub MainMenuSettingsBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuSettingsBT.Click
        Dim settingsview As New Settings
        settingsview.ShowDialog()
        settingsview.Dispose()
    End Sub

    Private Sub MainMenuCheckUpdateBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuCheckUpdateBT.Click
        Updater.Show()
    End Sub

    Private Sub MainMenuVersionBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuVersionBT.Click
        Dim verclass As New VerInfo
        verclass.ShowDialog()
        verclass.Dispose()
    End Sub



    'Unused Method
    Private Sub MainMenuSkinNormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuSkinNormal.Click
        skinChange(1)
    End Sub

    Private Sub MainMenuSkinDark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuSkinDark.Click
        skinChange(2)
    End Sub

    Private Sub MainMenuSkinWaterBlue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuSkinWaterBlue.Click
        skinChange(3)
    End Sub



    Private Sub MainMenuBugCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainMenuBugCheck.Click
        Dim result As DialogResult = MessageBox.Show("既定のブラウザで開きます。よろしいですか？", _
                                             "不具合報告", _
                                             MessageBoxButtons.OKCancel, _
                                             MessageBoxIcon.Exclamation)

        '何が選択されたか調べる 
        If (result = DialogResult.OK) Then
            System.Diagnostics.Process.Start("https://twitter.com/kiri_wiz")
        ElseIf (result = DialogResult.Cancel) Then

        End If
    End Sub

    'スキンチェンジ
    Dim colornum As Integer
    Public Sub skinChange(ByVal skinnum As Integer)

        Me.BackgroundImage = Nothing
        SkinTransparent()

        If (skinnum = 1) Then
            'ノーマル
            Me.BackColor = Color.FromKnownColor(KnownColor.Control)
            MusicList.BackColor = Color.FromKnownColor(KnownColor.Control)
            'VolumePanel.BackColor = Color.FromKnownColor(KnownColor.Control)
            VolumeBar.BackColor = Color.FromKnownColor(KnownColor.Control)
            ArtWorkMenu.BackColor = Color.FromKnownColor(KnownColor.Control)
            MusicListMenu.BackColor = Color.FromKnownColor(KnownColor.Control)
            MusicList.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            TimeLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            LoopStateLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText)

            If (artshownum = 1) Then
                ArtWork.BackColor = Color.Black
                If (playstate = 1) Then
                    If (System.IO.File.Exists(getArtWork())) Then
                        ArtWork.ImageLocation = getArtWork()
                    Else
                        ArtWork.BackColor = Color.Black
                    End If
                End If
            Else
                ArtWork.BackColor = Me.BackColor
            End If
            colornum = 1

            'iniclass.WriteInt("Main", "Skin", colornum, My.Application.Info.DirectoryPath & "\settings.ini")

            '黒
        ElseIf (skinnum = 2) Then
            Me.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
            MusicList.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
            'VolumePanel.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
            VolumeBar.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
            ArtWorkMenu.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
            MusicListMenu.BackColor = Color.FromKnownColor(KnownColor.ControlDarkDark)
            MusicList.ForeColor = Color.FromKnownColor(KnownColor.Control)
            TimeLabel.ForeColor = Color.FromKnownColor(KnownColor.Control)
            LoopStateLabel.ForeColor = Color.FromKnownColor(KnownColor.Control)

            If (artshownum = 1) Then
                ArtWork.BackColor = Color.Black
                If (playstate = 1) Then
                    If (System.IO.File.Exists(getArtWork())) Then
                        ArtWork.ImageLocation = getArtWork()
                    Else
                        ArtWork.BackColor = Color.Black
                    End If
                End If
            Else
                ArtWork.BackColor = Me.BackColor
            End If

            colornum = 2

            'iniclass.WriteInt("Main", "Skin", colornum, My.Application.Info.DirectoryPath & "\settings.ini")

            '水色
        ElseIf (skinnum = 3) Then
            'Me.BackColor = Color.FromKnownColor(KnownColor.LightSteelBlue)
            Me.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)
            MusicList.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)
            'VolumePanel.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)
            VolumeBar.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)
            ArtWorkMenu.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)
            MusicListMenu.BackColor = Color.FromKnownColor(KnownColor.ActiveCaption)
            MusicList.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            TimeLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText)
            LoopStateLabel.ForeColor = Color.FromKnownColor(KnownColor.ControlText)

            If (artshownum = 1) Then
                ArtWork.BackColor = Color.Black
                If (playstate = 1) Then
                    If (System.IO.File.Exists(getArtWork())) Then
                        ArtWork.ImageLocation = getArtWork()
                    Else
                        ArtWork.BackColor = Color.Black
                    End If
                End If
            Else
                ArtWork.BackColor = Me.BackColor
            End If

            colornum = 3

            'iniclass.WriteInt("Main", "Skin", colornum, My.Application.Info.DirectoryPath & "\settings.ini")
        End If
        'iniclass.WriteInt("Main", "CustomSkin", "", My.Application.Info.DirectoryPath & "\settings.ini")
    End Sub

    '透過
    Public Sub SkinTransparent()
        'Dim canvas As New Bitmap(Me.BackgroundImage.Width, Me.BackgroundImage.Height)

        MainMenu.BackColor = Color.Transparent
        'MusicList.BackColor = Color.FromArgb(128, Me.BackColor)
        TimeLabel.BackColor = Color.Transparent
        LoopStateLabel.BackColor = Color.Transparent
        MediaPlayBT.BackColor = Color.Transparent
        MediaStopBT.BackColor = Color.Transparent
        BackMusicBT.BackColor = Color.Transparent
        NextMusicBT.BackColor = Color.Transparent
        MediaVolumeBT.BackColor = Color.Transparent
    End Sub



    Dim i2 As Integer
    Private Sub MusicList_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MusicList.DragDrop
        Dim dropbeforeitem As Integer = MusicList.SelectedIndex
        Try
            Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

            'ListBoxに追加
            MusicPathListSub.Items.Clear()
            MusicPathListSub.Items.AddRange(files)
            MusicPathList2.Items.AddRange(files)

            Dim i As Integer = 0
            Dim i2 As Integer

            If (MusicPathList.Items.Count > 0) Then
                For num = 1 To files.Length
                    Dim file As String = files(num - 1)
                    Dim Index As Integer
                    Index = MusicPathList.FindStringExact(file)
                    If Index = ListBox.NoMatches Then
                        MusicPathList.Items.Add(file)
                        Dim FileName As String = IO.Path.GetFileNameWithoutExtension(file)
                        MusicList.Items.Add(FileName)
                    End If
                Next
                'While i < MusicPathList2.Items.Count
                '    Dim Index As Integer
                '    Index = MusicPathList.FindStringExact(MusicPathList2.Items.Item(i))

                '    If Index = ListBox.NoMatches Then
                '        MusicPathList.Items.AddRange(MusicPathListSub.Items)
                '        For i2 = 0 To MusicPathListSub.Items.Count
                '            Dim FileName As String = IO.Path.GetFileNameWithoutExtension(MusicPathListSub.Items.Item(i2))
                '            MusicList.Items.Add(FileName)
                '        Next
                '    End If
                '    i += 1
                'End While

                'i = 0
            Else
                MusicList.Items.Clear()
                MusicPathList.Items.Clear()

                For num = 1 To files.Length
                    Dim file As String = files(num - 1)
                    Dim Index As Integer
                    Index = MusicPathList.FindStringExact(file)
                    If Index = ListBox.NoMatches Then
                        MusicPathList.Items.Add(file)
                        Dim FileName As String = IO.Path.GetFileNameWithoutExtension(file)
                        MusicList.Items.Add(FileName)
                    End If
                Next
                'While i < MusicPathList2.Items.Count
                '    Dim Index As Integer
                '    Index = MusicPathList.FindStringExact(MusicPathList2.Items.Item(i))
                '    Dim FileName As String = IO.Path.GetFileNameWithoutExtension(MusicPathList2.Items.Item(i))

                '    If Index = ListBox.NoMatches Then
                '        MusicPathList.Items.Add(MusicPathList2.Items.Item(i))
                '        MusicList.Items.Add(FileName)
                '    End If
                '    i += 1
                'End While

                'i = 0
            End If

            'While i < MusicPathList2.Items.Count
            '    i += 1
            '    i2 = i - 1
            '    Dim FileName As String = IO.Path.GetFileNameWithoutExtension(MusicPathList2.Items.Item(i2))

            '    Dim Index As Integer
            '    Index = MusicList.FindStringExact(FileName)

            '    If Index = ListBox.NoMatches Then
            '        MusicList.Items.Add(FileName)
            '    End If
            'End While
        Catch ex As Exception

        End Try

        If Not (MusicPathList.Items.Count < 1) Then
            MediaPlayBT.Enabled = True
        End If

        MusicPathListSub.Items.Clear()
        MusicList.SelectedIndex = dropbeforeitem
        MusicPathList.SelectedIndex = MusicList.SelectedIndex
    End Sub

    Private Sub MusicList_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MusicList.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'FileDropならDrop可 
            e.Effect = DragDropEffects.Copy
        Else
            'Drop不可 
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub ArtWork_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ArtWork.DragDrop
        Dim dropbeforeitem As Integer = MusicList.SelectedIndex
        Try
            Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

            'ListBoxに追加
            MusicPathListSub.Items.Clear()
            MusicPathListSub.Items.AddRange(files)
            MusicPathList2.Items.AddRange(files)

            Dim i As Integer = 0
            Dim i2 As Integer

            If (MusicPathList.Items.Count > 0) Then
                While i < MusicPathList2.Items.Count
                    Dim Index As Integer
                    Index = MusicPathList.FindString(MusicPathList2.Items.Item(i))

                    If Index = ListBox.NoMatches Then
                        MusicPathList.Items.AddRange(MusicPathListSub.Items)
                        For i2 = 0 To MusicPathListSub.Items.Count
                            Dim FileName As String = IO.Path.GetFileNameWithoutExtension(MusicPathListSub.Items.Item(i2))
                            MusicList.Items.Add(FileName)
                        Next
                    End If
                    i += 1
                End While

                i = 0
            Else
                MusicList.Items.Clear()
                MusicPathList.Items.Clear()

                While i < MusicPathList2.Items.Count
                    Dim Index As Integer
                    Index = MusicPathList.FindString(MusicPathList2.Items.Item(i))
                    Dim FileName As String = IO.Path.GetFileNameWithoutExtension(MusicPathList2.Items.Item(i))

                    If Index = ListBox.NoMatches Then
                        MusicPathList.Items.Add(MusicPathList2.Items.Item(i))
                        MusicList.Items.Add(FileName)
                    End If
                    i += 1
                End While

                i = 0
            End If
        Catch ex As Exception

        End Try

        If Not (MusicPathList.Items.Count < 1) Then
            MediaPlayBT.Enabled = True
        End If

        MusicPathListSub.Items.Clear()
        MusicList.SelectedIndex = dropbeforeitem
        MusicPathList.SelectedIndex = MusicList.SelectedIndex

        'Dim dropbeforeitem As Integer = MusicList.SelectedIndex
        'Try
        '    Dim files() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        '    'ListBoxに追加
        '    'MusicPathList.Items.Clear()
        '    MusicPathList2.Items.AddRange(files)

        '    Dim i As Integer = 0
        '    MusicList.Items.Clear()
        '    MusicPathList.Items.Clear()

        '    While i < MusicPathList2.Items.Count
        '        Dim Index As Integer
        '        Index = MusicPathList.FindString(MusicPathList2.Items.Item(i))
        '        Dim FileName As String = IO.Path.GetFileNameWithoutExtension(MusicPathList2.Items.Item(i))

        '        If Index = ListBox.NoMatches Then
        '            MusicPathList.Items.Add(MusicPathList2.Items.Item(i))
        '            MusicList.Items.Add(FileName)
        '        End If
        '        i += 1
        '    End While

        '    i = 0

        'Catch ex As Exception

        'End Try

        'If Not (MusicPathList.Items.Count < 1) Then
        '    MediaPlayBT.Enabled = True
        'End If

        'MusicList.SelectedIndex = dropbeforeitem
        'MusicPathList.SelectedIndex = MusicList.SelectedIndex
    End Sub

    Private Sub ArtWork_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ArtWork.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'FileDropならDrop可 
            e.Effect = DragDropEffects.Copy
        Else
            'Drop不可 
            e.Effect = DragDropEffects.None
        End If
    End Sub


    'Private Sub MusicList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MusicList.MouseDown
    '    DoDragDrop(MusicList.SelectedItem, DragDropEffects.Move)
    'End Sub

    'Private Sub MusicList_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles MusicList.DragOver
    '    e.Effect = e.AllowedEffect
    'End Sub

    Private Sub MusicList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MusicList.DoubleClick
        MusicPathList.SelectedIndex = MusicList.SelectedIndex

        Try
            MainPlayer.URL = MusicPathList.SelectedItem.ToString
            MainPlayer.Ctlcontrols.currentPosition = 0
            MainPlayer.Ctlcontrols.play()
            playstate = 1
            MediaPositionBar.Enabled = True
            MediaPlayBT.Image = My.Resources.PauseHover

            If (System.IO.File.Exists(getArtWork())) Then
                ArtWork.ImageLocation = getArtWork()
            Else
                ArtWork.Image = Nothing
            End If
        Catch exNullRef As System.NullReferenceException
            'MessageBox.Show("不明なエラー", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("不明なエラー", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




    'ミュージックリストメニュー
    Private Sub MusicListMenu_Opened(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicListMenu.Opened
        If (MusicList.SelectedIndex = 0) Then
            MusicMenuListUp.Enabled = False
            MusicMenuListDown.Enabled = True
        ElseIf (MusicList.SelectedIndex = MusicList.Items.Count - 1) Then
            MusicMenuListUp.Enabled = True
            MusicMenuListDown.Enabled = False

        ElseIf Not (MusicList.SelectedIndex >= 0) Then
            MusicMenuListUp.Enabled = False
            MusicMenuListDown.Enabled = False
        Else
            MusicMenuListUp.Enabled = True
            MusicMenuListDown.Enabled = True
        End If

        If (MusicList.Items.Count = 0) Then
            MusicMenuListUp.Enabled = False
            MusicMenuListDown.Enabled = False
            MusicMenuListRandom.Enabled = False
        Else
            MusicMenuListRandom.Enabled = True
        End If

        If (MusicList.SelectedIndex < 0) Then
            MusicMenuListDelete.Enabled = False
            MusicMenuOpenDir.Enabled = False
        Else
            MusicMenuListDelete.Enabled = True
            MusicMenuOpenDir.Enabled = True
        End If
    End Sub

    Private Sub MusicMenuListReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuListReset.Click
        MusicList.Items.Clear()
        MusicPathList.Items.Clear()
        MusicPathList2.Items.Clear()
        MediaPositionBar.Enabled = False

        MainPlayer.URL = ""
        MainPlayer.Ctlcontrols.stop()
        MediaPlayBT.Image = My.Resources.PlayHover
        ArtWork.Image = My.Resources.artwork
    End Sub

    Private Sub MusicMenuListUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuListUp.Click
        MusicChange("up")
    End Sub

    Private Sub MusicMenuListDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuListDown.Click
        MusicChange("down")
    End Sub

    Private Sub MusicMenuLoopPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuLoopPlay.Click
        If (LoopPlay = 0) Then
            LoopPlay = 1
            MusicMenuLoopPlay.Checked = True
            LoopStateLabel.Text = "連続再生ON"
        Else
            LoopPlay = 0
            MusicMenuLoopPlay.Checked = False
            LoopStateLabel.Text = "連続再生OFF"
        End If
        iniclass.WriteInt("Main", "LoopPlay", LoopPlay, My.Application.Info.DirectoryPath & "\settings.ini")
    End Sub

    Private Sub MusicChange(ByVal num As String)
        Try
            If (num = "up") Then
                Dim item As String = MusicList.SelectedItem
                Dim itemup As String = MusicList.Items(MusicList.SelectedIndex - 1)

                Dim selectmusicpath As String = MusicPathList.SelectedItem

                MusicPathList.SelectedIndex = MusicList.SelectedIndex

                Dim pathitem As String = MusicPathList.SelectedItem
                Dim pathitemup As String = MusicPathList.Items(MusicPathList.SelectedIndex - 1)

                MusicList.Items.Item(MusicList.SelectedIndex - 1) = item
                MusicList.Items.Item(MusicList.SelectedIndex) = itemup
                MusicPathList.Items.Item(MusicList.SelectedIndex - 1) = pathitem
                MusicPathList.Items.Item(MusicList.SelectedIndex) = pathitemup

                MusicList.SelectedIndex = MusicList.SelectedIndex - 1
                MusicPathList.SelectedItem = selectmusicpath

                'Dim item As String = MusicList.SelectedItem
                'Dim itemup As String = MusicList.Items(MusicList.SelectedIndex - 1)

                'MusicPathList.SelectedIndex = MusicList.SelectedIndex

                'Dim pathitem As String = MusicPathList.SelectedItem
                'Dim pathitemup As String = MusicPathList.Items(MusicPathList.SelectedIndex - 1)

                'MusicList.Items.Item(MusicList.SelectedIndex - 1) = item
                'MusicList.Items.Item(MusicList.SelectedIndex) = itemup
                'MusicPathList.Items.Item(MusicPathList.SelectedIndex - 1) = pathitem
                'MusicPathList.Items.Item(MusicPathList.SelectedIndex) = pathitemup

                'MusicList.SelectedIndex = MusicList.SelectedIndex - 1
                'MusicPathList.SelectedIndex = MusicList.SelectedIndex
            ElseIf (num = "down") Then
                Dim item As String = MusicList.SelectedItem
                Dim itemdown As String = MusicList.Items(MusicList.SelectedIndex + 1)

                Dim selectmusicpath As String = MusicPathList.SelectedItem

                MusicPathList.SelectedIndex = MusicList.SelectedIndex

                Dim pathitem As String = MusicPathList.SelectedItem
                Dim pathitemdown As String = MusicPathList.Items(MusicPathList.SelectedIndex + 1)

                MusicList.Items.Item(MusicList.SelectedIndex + 1) = item
                MusicList.Items.Item(MusicList.SelectedIndex) = itemdown
                MusicPathList.Items.Item(MusicPathList.SelectedIndex + 1) = pathitem
                MusicPathList.Items.Item(MusicPathList.SelectedIndex) = pathitemdown

                MusicList.SelectedIndex = MusicList.SelectedIndex + 1
                MusicPathList.SelectedItem = selectmusicpath

                'Dim item As String = MusicList.SelectedItem
                'Dim itemdown As String = MusicList.Items(MusicList.SelectedIndex + 1)

                'MusicPathList.SelectedIndex = MusicList.SelectedIndex

                'Dim pathitem As String = MusicPathList.SelectedItem
                'Dim pathitemdown As String = MusicPathList.Items(MusicPathList.SelectedIndex + 1)

                'MusicList.Items.Item(MusicList.SelectedIndex + 1) = item
                'MusicList.Items.Item(MusicList.SelectedIndex) = itemdown
                'MusicPathList.Items.Item(MusicPathList.SelectedIndex + 1) = pathitem
                'MusicPathList.Items.Item(MusicPathList.SelectedIndex) = pathitemdown

                'MusicList.SelectedIndex = MusicList.SelectedIndex + 1
                'MusicPathList.SelectedIndex = MusicList.SelectedIndex
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MusicUpBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicUpBT.Click
        MusicChange("up")
    End Sub

    Private Sub MusicDownBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicDownBT.Click
        MusicChange("down")
    End Sub

    Dim selecteditem As String = "0"
    Dim selecteditempath As String = "0"
    Private Sub MusicMenuListRandom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuListRandom.Click
        Try

            Dim myRandom As New Random
            Dim i As Integer = MusicList.Items.Count
            Dim selectitem As String
            Dim selectitempath As String

            Dim rnum As Integer = myRandom.Next(i)

            MusicListSub.Items.Clear()
            MusicPathListSub.Items.Clear()
            MusicListSub.Items.AddRange(MusicList.Items)
            MusicPathListSub.Items.AddRange(MusicPathList.Items)

            MusicList.Items.Clear()
            MusicPathList.Items.Clear()

            selecteditem = "0"
            selecteditempath = "0"

            selectitem = MusicListSub.Items.Item(rnum).ToString()
            selectitempath = MusicPathListSub.Items.Item(rnum).ToString()

            Do
                rnum = myRandom.Next(i)

                If (MusicPathList.Items.Count = MusicPathListSub.Items.Count) Then
                    Exit Do
                Else
                    Dim Index As Integer
                    Index = MusicPathList.FindStringExact(selectitempath)

                    If Not (Index = ListBox.NoMatches) Then
                        selectitem = MusicListSub.Items.Item(rnum).ToString()
                        selectitempath = MusicPathListSub.Items.Item(rnum).ToString()
                        Continue Do
                    End If
                End If

                selecteditem = selecteditem & selectitem
                selecteditempath = selecteditempath & selectitempath

                MusicList.Items.Add(selectitem)
                MusicPathList.Items.Add(selectitempath)
            Loop

            MusicListSub.Items.Clear()
            MusicPathListSub.Items.Clear()

            'Dim myRandom As New Random
            'Dim i As Integer = MusicList.Items.Count
            'Dim selectitem As String
            'Dim selectitempath As String

            'Dim rnum As Integer = myRandom.Next(i)

            'MusicListSub.Items.Clear()
            'MusicPathListSub.Items.Clear()
            'MusicListSub.Items.AddRange(MusicList.Items)
            'MusicPathListSub.Items.AddRange(MusicPathList.Items)

            'MusicList.Items.Clear()
            'MusicPathList.Items.Clear()

            'selecteditem = "0"
            'selecteditempath = "0"

            'selectitem = MusicListSub.Items.Item(rnum).ToString()
            'selectitempath = MusicPathListSub.Items.Item(rnum).ToString()

            'Do
            '    rnum = myRandom.Next(i)

            '    If (MusicPathList.Items.Count = MusicPathListSub.Items.Count) Then
            '        Exit Do
            '    Else
            '        Dim Index As Integer
            '        Index = MusicList.FindStringExact(selectitem)

            '        If Not (Index = ListBox.NoMatches) Then
            '            selectitem = MusicListSub.Items.Item(rnum).ToString()
            '            selectitempath = MusicPathListSub.Items.Item(rnum).ToString()
            '            Continue Do
            '        End If
            '    End If

            '    selecteditem = selecteditem & selectitem
            '    selecteditempath = selecteditempath & selectitempath

            '    MusicList.Items.Add(selectitem)
            '    MusicPathList.Items.Add(selectitempath)
            'Loop
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MusicMenuListDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuListDelete.Click
        Try
            Dim delselectnum As Integer = MusicList.SelectedIndex
            MusicPathList.SelectedIndex = delselectnum

            Dim Index As Integer = 0

            For Index = 1 To MusicPathList2.Items.Count
                MusicPathList2.Items.Remove(MusicPathList.SelectedItem)
            Next

            MusicList.Items.RemoveAt(delselectnum)
            MusicPathList.Items.RemoveAt(delselectnum)

            MusicList.SelectedIndex = delselectnum
            MusicPathList.SelectedIndex = delselectnum
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MusicMenuCreatePlayListCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuCreatePlayListCreate.Click
        CreatePlaylist()
    End Sub

    Private Sub MusicMenuCreatePlayListOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuCreatePlayListOpen.Click
        OpenPlaylist()
    End Sub

    Private Sub MusicMenuOpenDir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicMenuOpenDir.Click
        Try
            System.Diagnostics.Process.Start("EXPLORER.EXE", "/select," & MusicPathList.Items.Item(MusicList.SelectedIndex))
        Catch ex As Exception
            MessageBox.Show("不明なエラー", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function StringSearchMethod(ByVal txt As String, _
                                       ByVal mototxt As String, _
                                       ByVal int As Integer)
        Dim SearchMethodData As New System.Text.RegularExpressions.Regex(txt, _
            System.Text.RegularExpressions.RegexOptions.IgnoreCase Or _
            System.Text.RegularExpressions.RegexOptions.Singleline)

        Dim SearchMethodData2 As System.Text.RegularExpressions.MatchCollection = _
            SearchMethodData.Matches(mototxt)

        For Each SearchMethod As System.Text.RegularExpressions.Match In SearchMethodData2
            Return SearchMethod.Groups(int).Value
        Next
    End Function

    Private Sub MusicList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MusicList.KeyDown
        If (e.KeyCode = Keys.Delete) Then
            Try
                Dim delselectnum As Integer = MusicList.SelectedIndex
                MusicPathList.SelectedIndex = delselectnum

                Dim Index As Integer = 0

                For Index = 1 To MusicPathList2.Items.Count
                    MusicPathList2.Items.Remove(MusicPathList.SelectedItem)
                Next

                MusicList.Items.RemoveAt(delselectnum)
                MusicPathList.Items.RemoveAt(delselectnum)

                MusicList.SelectedIndex = delselectnum
                MusicPathList.SelectedIndex = delselectnum
            Catch ex As Exception

            End Try
        End If
    End Sub



    'Playlist
    Private Sub CreatePlaylist()
        Dim stParentName As String = iniclass.GetStr("Main", "SavePath", System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), My.Application.Info.DirectoryPath & "\settings.ini")

        Dim sfd As New SaveFileDialog()

        sfd.FileName = ""
        sfd.InitialDirectory = stParentName
        sfd.Filter = _
         "プレイリストファイル(*.kmplist)|*.kmplist|Windows Play List(*.wpl)|*.wpl"
        sfd.FilterIndex = 2
        sfd.Title = "保存先のファイルを選択してください"
        sfd.RestoreDirectory = True
        sfd.OverwritePrompt = True
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then
            iniclass.WriteStr("Main", "SavePath", System.IO.Path.GetDirectoryName(sfd.FileName), My.Application.Info.DirectoryPath & "\settings.ini")
            If (System.IO.Path.GetExtension(sfd.FileName) = ".kmplist") Then
                Using sw As New System.IO.StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                    For i = 0 To MusicPathList.Items.Count - 1
                        sw.Write(MusicPathList.Items.Item(i) & """crlf""" & MusicList.Items.Item(i) & vbCrLf)
                    Next
                End Using
            ElseIf (System.IO.Path.GetExtension(sfd.FileName) = ".wpl") Then
                'Dim title As String = "  <title>" & "KMAudioPlayer" & "</title>"

                'Dim musicliststr As String
                'For i = 0 To MusicPathList.Items.Count - 1
                '    musicliststr += "   <media src=""" & MusicPathList.Items.Item(i) & """/>" & vbCrLf
                'Next

                'Dim WriteStr As String = "<?wpl version=""1.0""?>" & vbCrLf & _
                '    "<smil>" & vbCrLf & _
                '    " <head>" & vbCrLf & _
                '    "  <meta name=""Generator"" content=""Microsoft Windows Media Player -- KMAudioPlayer""/>" & vbCrLf & _
                '    "  <meta name=""ItemCount"" content=""1""/>" & vbCrLf & _
                '    title & vbCrLf & _
                '    " </head>" & vbCrLf & _
                '    " <body>" & vbCrLf & _
                '    "  <seq>" & vbCrLf & _
                '    musicliststr & _
                '    "  </seq>" & vbCrLf & _
                '    " </body>" & vbCrLf & _
                '    "</smil>"

                'Using sw As New System.IO.StreamWriter(sfd.FileName, False, System.Text.Encoding.UTF8)
                '    sw.Write(WriteStr)
                'End Using
                Dim wplclass As New WPLControl
                Dim media As New ArrayList
                For i = 0 To MusicPathList.Items.Count - 1
                    media.Add(MusicPathList.Items.Item(i))
                Next
                wplclass.WPLCreate(sfd.FileName, media)
            End If
        End If
    End Sub

    Private Sub OpenPlaylist()
        Dim contclass As New Controls

        Dim stParentName As String = iniclass.GetStr("Main", "SavePath", System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), My.Application.Info.DirectoryPath & "\settings.ini")
        Dim ofd As New OpenFileDialog()

        ofd.FileName = ""
        ofd.InitialDirectory = stParentName
        ofd.Filter = _
            "プレイリストファイル(*.kmplist)|*.kmplist|Windows Play List(*.wpl)|*.wpl"
        ofd.FilterIndex = 2
        ofd.Title = "開くファイルを選択してください"
        ofd.RestoreDirectory = True
        ofd.CheckFileExists = True
        ofd.CheckPathExists = True

        If ofd.ShowDialog() = DialogResult.OK Then
            iniclass.WriteStr("Main", "SavePath", System.IO.Path.GetDirectoryName(ofd.FileName), My.Application.Info.DirectoryPath & "\settings.ini")
            MusicPathList.Items.Clear()
            MusicPathList2.Items.Clear()
            MusicList.Items.Clear()
            If (System.IO.Path.GetExtension(ofd.FileName) = ".kmplist") Then
                Using sr As New System.IO.StreamReader(ofd.FileName, System.Text.Encoding.UTF8)
                    Dim alertnum As Integer = 0
                    While sr.Peek() > -1
                        Dim filename As String
                        filename = sr.ReadLine()
                        If (contclass.GetStringFix(filename, 2) = "NULL") Then
                            Dim result As DialogResult

                            If (alertnum = 0) Then
                                result = MessageBox.Show("古いプレイリストの可能性があります。" & vbCrLf & _
                                                                             "追加しますか？" & vbCrLf & _
                                                                             "※_が含まれる楽曲は正常に追加できません。" & vbCrLf & _
                                                                             "※この問題は次のプレイリスト作成にて修復されます。", _
                                                     "確認", _
                                                     MessageBoxButtons.YesNo, _
                                                     MessageBoxIcon.Exclamation)
                            End If

                            If (result = DialogResult.Yes Or alertnum = 1) Then
                                MusicPathList.Items.Add(contclass.GetString(filename, 1))
                                MusicPathList2.Items.Add(contclass.GetString(filename, 1))
                                MusicList.Items.Add(contclass.GetString(filename, 2))
                                alertnum = 1
                            ElseIf (result = DialogResult.No Or alertnum = 2) Then
                                alertnum = 2
                            End If
                        Else
                            MusicPathList.Items.Add(contclass.GetStringFix(filename, 1))
                            MusicPathList2.Items.Add(contclass.GetStringFix(filename, 1))
                            MusicList.Items.Add(contclass.GetStringFix(filename, 2))
                        End If
                    End While
                End Using
                MediaPlayBT.Enabled = True
            ElseIf (System.IO.Path.GetExtension(ofd.FileName) = ".wpl") Then
                Dim returnstr As String
                'Using sr As New System.IO.StreamReader(ofd.FileName, System.Text.Encoding.UTF8)
                '    While sr.Peek > -1
                '        returnstr = StringSearchMethod("<media src=""(.*?)""/>", sr.ReadLine, "1")
                '        If Not (returnstr = vbNullString) Then
                '            'returnstr = returnstr.Replace("..\..\..\..\", "C:\")
                '            System.Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(ofd.FileName)
                '            returnstr = System.IO.Path.GetFullPath(returnstr)
                '            MusicPathList.Items.Add(returnstr)
                '            MusicPathList2.Items.Add(returnstr)
                '            MusicList.Items.Add(IO.Path.GetFileNameWithoutExtension(returnstr))
                '        End If
                '    End While
                'End Using
                Dim wplclass As New WPLControl
                Dim media As ArrayList
                Dim returnint As Integer = wplclass.WPLLoad(ofd.FileName, media)
                If (returnint = 0) Then
                    For i = 0 To media.Count - 1
                        System.Environment.CurrentDirectory = System.IO.Path.GetDirectoryName(ofd.FileName)
                        returnstr = System.IO.Path.GetFullPath(media.Item(i))
                        MusicPathList.Items.Add(returnstr)
                        MusicPathList2.Items.Add(returnstr)
                        MusicList.Items.Add(IO.Path.GetFileNameWithoutExtension(returnstr))
                    Next
                End If

                System.Environment.CurrentDirectory = My.Application.Info.DirectoryPath
                MediaPlayBT.Enabled = True
            End If
        End If
    End Sub

    Private Function getWMPDir() As String
        Dim stringValue As String

        Using regkey As Microsoft.Win32.RegistryKey = _
    Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Keyboard\Native Media Players\WMP", False)
            'キーが存在しないときは null が返される
            If regkey Is Nothing Then
                Return "C:\Program Files\Windows Media Player\wmplayer.exe"
            End If

            stringValue = DirectCast(regkey.GetValue("ExePath"), String)

            '閉じる
        End Using
        Return stringValue
    End Function

    'アートワークメニュー
    Dim artshownum As Integer
    Dim lyricshownum As Integer
    Private Sub ArtWorkMenuArtShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArtWorkMenuArtShow.Click
        If (ArtWorkMenuArtShow.Checked) Then
            artshownum = 0
            ArtWorkMenuArtShow.Checked = False
            ArtWork.Image = My.Resources.artwork
            'ArtWork.BackColor = Me.BackColor
        Else
            artshownum = 1
            ArtWorkMenuArtShow.Checked = True
            'ArtWork.BackColor = Color.Black
            If (playstate = 1) Then
                If (System.IO.File.Exists(getArtWork())) Then
                    ArtWork.ImageLocation = getArtWork()
                Else
                    ArtWork.Image = My.Resources.artwork
                End If
            End If
        End If
        iniclass.WriteInt("Main", "ShowArtWork", artshownum, My.Application.Info.DirectoryPath & "\settings.ini")
    End Sub

    Private Sub ArtWorkMenuLyric_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ArtWorkMenuLyric.Click
        If (ArtWorkMenuLyric.Checked) Then
            lyricshownum = 0
            ArtWorkMenuLyric.Checked = False
            LyricBox.Visible = False
        Else
            lyricshownum = 1
            ArtWorkMenuLyric.Checked = True
            If (playstate = 1) Then
                If (getLyric() = vbNullString) Then
                    LyricBox.Visible = False
                Else
                    LyricBox.Visible = True
                End If
            End If
        End If
        iniclass.WriteInt("Main", "ShowLyric", lyricshownum, My.Application.Info.DirectoryPath & "\settings.ini")
    End Sub


    Dim playstate As Integer = 0
    Private Sub MediaPlayBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaPlayBT.Click
        Try
            If (MusicPathList.Items.Count > 0) Then
                If (playstate = 0) Then
                    '再生されていないとき

                    If (MusicPathList.SelectedItem = vbNullString) Then
                        MusicPathList.SelectedIndex = 0
                        MusicList.SelectedIndex = 0
                    End If

                    MainPlayer.URL = MusicPathList.SelectedItem.ToString
                    MainPlayer.Ctlcontrols.play()
                    MediaPlayBT.Image = My.Resources.PauseHover
                    playstate = 1

                    MediaPositionBar.Enabled = True

                    'If (MusicPathList.Items.Count < 2) Then
                    '    BackMusicBT.Enabled = False
                    '    NextMusicBT.Enabled = False
                    'Else
                    '    BackMusicBT.Enabled = True
                    '    NextMusicBT.Enabled = True
                    'End If

                    If (MusicPathList.SelectedItem.ToString.IndexOf(".mp4") >= 0 Or _
                        MusicPathList.SelectedItem.ToString.IndexOf(".avi") >= 0 Or _
                        MusicPathList.SelectedItem.ToString.IndexOf(".wmv") >= 0 _
                        ) Then
                        MainPlayer.Visible = False
                    Else
                        MainPlayer.Visible = False
                    End If
                ElseIf (playstate = 1) Then
                    '再生されていれば一時停止
                    MainPlayer.Ctlcontrols.pause()
                    MediaPlayBT.Image = My.Resources.PlayHover
                    playstate = 2
                Else
                    '一時停止中なら再生
                    MainPlayer.Ctlcontrols.play()
                    MediaPlayBT.Image = My.Resources.PauseHover
                    playstate = 1

                    If (System.IO.File.Exists(getArtWork())) Then
                        ArtWork.ImageLocation = getArtWork()
                    Else
                        ArtWork.BackColor = Color.Black
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MediaStopBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaStopBT.Click
        Try
            MainPlayer.Ctlcontrols.stop()
            MediaPositionBar.Value = 0
            MediaPlayBT.Image = My.Resources.PlayHover
            ArtWork.Image = My.Resources.artwork
            playstate = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackMusicBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackMusicBT.Click
        Try
            MusicPathList.SelectedIndex -= 1
            MusicList.SelectedIndex = MusicPathList.SelectedIndex
            MainPlayer.Ctlcontrols.stop()
            MainPlayer.URL = MusicPathList.SelectedItem.ToString
            MainPlayer.Ctlcontrols.play()
            MediaPlayBT.Image = My.Resources.PauseHover
            playstate = 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NextMusicBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NextMusicBT.Click
        Try
            MusicPathList.SelectedIndex += 1
            MusicList.SelectedIndex = MusicPathList.SelectedIndex
            MainPlayer.Ctlcontrols.stop()
            MainPlayer.URL = MusicPathList.SelectedItem.ToString
            MainPlayer.Ctlcontrols.play()
            MediaPlayBT.Image = My.Resources.PauseHover
            playstate = 1
        Catch ex As Exception

        End Try
    End Sub



    Private Function getArtWork()
        Dim hDirInfo As System.IO.DirectoryInfo = System.IO.Directory.GetParent(MusicPathList.SelectedItem)

        Return hDirInfo.FullName & "\Folder.jpg"
    End Function

    Private Function getLyric()

        Dim lyric As String = MainPlayer.currentMedia.getItemInfo("WM/Lyrics")

        Return lyric
    End Function

    Dim readint As Integer = 0
    Dim LoopPlay As Integer = 0
    Private Sub MainPlayer_PlayStateChange(ByVal sender As Object, ByVal e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles MainPlayer.PlayStateChange
        Dim stateint As Integer = e.newState
        If (stateint = 1) Then
            MediaPositionTimer.Stop()
            ArtWork.Image = My.Resources.artwork
            LyricBox.Visible = False
        ElseIf (stateint = 2) Then

        ElseIf (stateint = 3) Then
            MediaPositionTimer.Start()
            MediaPositionBar.Maximum = MainPlayer.currentMedia.duration + 8

            If (artshownum = 1) Then
                If (System.IO.File.Exists(getArtWork())) Then
                    ArtWork.ImageLocation = getArtWork()
                Else
                    ArtWork.Image = My.Resources.artwork
                End If
            Else
                ArtWork.Image = My.Resources.artwork
            End If

            LyricBox.Text = getLyric()
            If (lyricshownum = 1) Then
                If (getLyric() = vbNullString) Then
                    LyricBox.Visible = False
                Else
                    LyricBox.Visible = True
                End If
            Else
                LyricBox.Visible = False
            End If

            Dim second2 As Double = MainPlayer.currentMedia.duration
            Dim ts2 As TimeSpan = New TimeSpan(0, 0, second2)
            TimeLabel.Text = "00:00:00/" & ts2.ToString
        ElseIf (stateint = 8) Then
            SongChengeTimer.Start()
        ElseIf (stateint = 9) Then
            '準備
            'Try
            '    If Not (System.IO.File.Exists(MusicPathList.SelectedItem)) Then
            '        MusicPathList.SelectedIndex += 1
            '        MusicList.SelectedIndex += 1

            '        MainPlayer.URL = MusicPathList.SelectedItem.ToString
            '        MainPlayer.Ctlcontrols.play()
            '        playstate = 1

            '        If (artshownum = 1) Then
            '            If (System.IO.File.Exists(getArtWork())) Then
            '                ArtWork.ImageLocation = getArtWork()
            '            Else
            '                ArtWork.Image = My.Resources.artwork
            '            End If
            '        Else
            '            ArtWork.Image = My.Resources.artwork
            '        End If
            '    End If
            'Catch ex As Exception
            '    MainPlayer.Ctlcontrols.stop()
            '    MediaPositionBar.Value = 0
            '    MediaPlayBT.Image = My.Resources.PlayHover
            '    ArtWork.Image = Nothing
            '    playstate = 0
            'End Try
        End If
    End Sub

    Private Sub MediaPositionTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaPositionTimer.Tick
        Try
            MediaPositionBar.Value = MainPlayer.Ctlcontrols.currentPosition

            Dim second As Integer = MainPlayer.Ctlcontrols.currentPosition
            Dim second2 As Integer = MainPlayer.currentMedia.duration
            Dim ts As TimeSpan = New TimeSpan(0, 0, second)
            Dim ts2 As TimeSpan = New TimeSpan(0, 0, second2)
            TimeLabel.Text = ts.ToString & "/" & ts2.ToString
        Catch ex As Exception

        End Try
        'Label2.Text = MediaPositionBar.Value

    End Sub

    Private Sub MediaPositionBar_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles MediaPositionBar.Scroll
        Try
            MainPlayer.Ctlcontrols.currentPosition = MediaPositionBar.Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SongChengeTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SongChengeTimer.Tick
        MediaPositionTimer.Stop()

        Try
            MusicPathList.SelectedIndex = MusicPathList.SelectedIndex + 1
            MusicList.SelectedIndex = MusicPathList.SelectedIndex

            MainPlayer.URL = MusicPathList.SelectedItem.ToString
            MainPlayer.Ctlcontrols.play()
            MediaPositionBar.Value = 0
            playstate = 1

            If (System.IO.File.Exists(getArtWork())) Then
                ArtWork.ImageLocation = getArtWork()
            Else
                ArtWork.Image = Nothing
            End If
        Catch SAOOE As System.ArgumentOutOfRangeException
            If (LoopPlay = 0) Then
                MediaPlayBT.Image = My.Resources.PlayHover
                MediaPositionBar.Value = 0
                playstate = 0
            Else
                MusicPathList.SelectedIndex = 0
                MusicList.SelectedIndex = MusicPathList.SelectedIndex

                MainPlayer.URL = MusicPathList.SelectedItem.ToString
                MainPlayer.Ctlcontrols.play()
                playstate = 1

                If (System.IO.File.Exists(getArtWork())) Then
                    ArtWork.ImageLocation = getArtWork()
                Else
                    ArtWork.Image = Nothing
                End If
            End If
        End Try

        SongChengeTimer.Stop()
    End Sub




    'ボリューム
    Private Sub TrackBar1_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VolumeBar.Scroll
        MainPlayer.settings.volume = VolumeBar.Value
        VolumeLabel.Text = VolumeBar.Value
    End Sub

    Private Sub MediaVolumeBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MediaVolumeBT.Click
        If (VolumePanel.Visible = False) Then
            VolumePanel.Visible = True
        Else
            VolumePanel.Visible = False
        End If
    End Sub


    'Mouse Scroll
    Private Sub VolumePanel_VisibleChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VolumePanel.VisibleChanged
        If (VolumePanel.Visible = True) Then
            VolumeBar.Value = MainPlayer.settings.volume
        End If
    End Sub

    Private Sub MusicList_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MusicList.MouseEnter
        MusicList.Focus()
    End Sub

    Private Sub VolumePanel_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VolumePanel.MouseEnter
        VolumeBar.Focus()
    End Sub

    Private Sub MusicList_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MusicList.MouseLeave
        ActiveControl = Nothing
    End Sub

    Private Sub VolumePanel_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles VolumePanel.MouseLeave
        ActiveControl = Nothing
    End Sub

    Private Sub VolumeBar_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles VolumeBar.MouseEnter, VolumeLabel.MouseEnter
        VolumeBar.Focus()
    End Sub


    Private Sub AToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AToolStripMenuItem.Click
        '関連付ける拡張子
        Dim extension As String = ".mp3"
        '実行するコマンドライン
        Dim commandline As String = """" + Application.ExecutablePath + """ %1"
        'ファイルタイプ名
        Dim fileType As String = Application.ProductName
        '説明（「ファイルの種類」として表示される）
        '（必要なし）
        Dim description As String = "MyApplication File"
        '動詞
        Dim verb As String = "open"
        '動詞の説明（エクスプローラのコンテキストメニューに表示される）
        '（必要なし）
        Dim verb_description As String = "MyApplicationで開く(&O)"
        'アイコンのパスとインデックス
        Dim iconPath As String = Application.ExecutablePath
        Dim iconIndex As Integer = 0

        'ファイルタイプを登録
        Dim regkey As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(extension)
        regkey.SetValue("", fileType)
        regkey.Close()

        'ファイルタイプとその説明を登録
        Dim shellkey As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(fileType)
        shellkey.SetValue("", description)

        '動詞とその説明を登録
        shellkey = shellkey.CreateSubKey("shell\" + verb)
        shellkey.SetValue("", verb_description)

        'コマンドラインを登録
        shellkey = shellkey.CreateSubKey("command")
        shellkey.SetValue("", commandline)
        shellkey.Close()

        'アイコンの登録
        Dim iconkey As Microsoft.Win32.RegistryKey = _
            Microsoft.Win32.Registry.ClassesRoot.CreateSubKey( _
                fileType + "\DefaultIcon")
        iconkey.SetValue("", iconPath + "," + iconIndex.ToString())
        iconkey.Close()
    End Sub

    Private Sub BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BToolStripMenuItem.Click
        '拡張子
        Dim extension As String = ".mp3"
        'ファイルタイプ名
        Dim fileType As String = Application.ProductName

        'レジストリキーを削除
        Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(extension)
        'Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree(fileType)
    End Sub

    Private Sub CToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CToolStripMenuItem.Click
        ArtWork.Image.Dispose()
        ArtWork.Image = My.Resources.artwork

        System.GC.Collect()
    End Sub

    Private Sub MemTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MemTimer.Tick
        Dim memnum As Double
        Dim vmemnum As Double
        memnum = My.Application.Info.WorkingSet / 1024 / 1024
        MemBox.Text = memnum
    End Sub

    Private Sub DToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DToolStripMenuItem.Click
        MemoryRelease.Release()
    End Sub

    Private Sub EToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EToolStripMenuItem.Click
        Release2()
    End Sub

    Private Sub AToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AToolStripMenuItem1.Click
        Dim stw As Stopwatch = New Stopwatch()
        stw.Start()

        Dim List As String
        Dim title As String = "  <title>" & "KMAudioPlayer" & "</title>"

        Dim musicliststr As String
        For i = 0 To MusicPathList.Items.Count - 1
            musicliststr += "   <media src=""" & MusicPathList.Items.Item(i) & """/>" & vbCrLf
        Next

        Dim WriteStr As String = "<?wpl version=""1.0""?>" & vbCrLf & _
            "<smil>" & vbCrLf & _
            " <head>" & vbCrLf & _
            "  <meta name=""Generator"" content=""Microsoft Windows Media Player -- KMAudioPlayer""/>" & vbCrLf & _
            "  <meta name=""ItemCount"" content=""1""/>" & vbCrLf & _
            title & vbCrLf & _
            " </head>" & vbCrLf & _
            " <body>" & vbCrLf & _
            "  <seq>" & vbCrLf & _
            musicliststr & _
            "  </seq>" & vbCrLf & _
            " </body>" & vbCrLf & _
            "</smil>"

        Using sw As New System.IO.StreamWriter("C:\backup.txt", False, System.Text.Encoding.UTF8)
            sw.Write(WriteStr)
        End Using

        stw.Stop()
        Dim elapsedTime As Long = stw.ElapsedMilliseconds
        MessageBox.Show("完了" & vbCrLf & "経過時間:" & elapsedTime / 1000 & "秒")

        System.IO.File.Delete("C:\backup.txt")
    End Sub

    Private Sub BToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BToolStripMenuItem1.Click
        Dim stw As Stopwatch = New Stopwatch()
        stw.Start()

        If (MusicPathList.Items.Count > 0) Then
            Dim wplclass As New WPLControl
            Dim media As New ArrayList
            For i = 0 To MusicPathList.Items.Count - 1
                media.Add(MusicPathList.Items.Item(i))
            Next
            wplclass.WPLCreate("C:\backup.txt", media)
        End If

        stw.Stop()
        Dim elapsedTime As Long = stw.ElapsedMilliseconds
        MessageBox.Show("完了" & vbCrLf & "経過時間:" & elapsedTime / 1000 & "秒")

        System.IO.File.Delete("C:\backup.txt")
    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        MusicPathList.Items.Clear()
        MusicList.Items.Clear()
        For i = 0 To 10000
            MusicPathList.Items.Add("C:\backup\backup\backup\backup.txt" & i)
            MusicList.Items.Add(i)
        Next
    End Sub

    Private Sub NowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NowToolStripMenuItem.Click
        MessageBox.Show(MainPlayer.Ctlcontrols.currentItem.sourceURL)
    End Sub
End Class
