Public Class TransparentListBox
    Inherits System.Windows.Forms.ListBox

    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer _
  Or ControlStyles.UserPaint _
  Or ControlStyles.AllPaintingInWmPaint _
  Or ControlStyles.SupportsTransparentBackColor, _
  False)
        'MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        'MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        'MyBase.SetStyle(ControlStyles.UserPaint, True)
        'MyBase.SetStyle(ControlStyles.ResizeRedraw, True)
        'MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        MyBase.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
    End Sub
End Class

Public Class MyListBox
    Inherits System.Windows.Forms.ListBox
    Private BGImage As Image
    Public Overrides Property BackgroundImage() As Image
        Get
            Return BGImage
        End Get
        Set(ByVal Value As Image)
            BGImage = Value
        End Set
    End Property
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.DrawImage(BGImage, New PointF(0, 0))
    End Sub

    Protected Overrides Sub RefreshItem(ByVal index As Integer)

    End Sub

    Protected Overrides Sub SetItemsCore(ByVal items As System.Collections.IList)

    End Sub
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ArtWorkMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ArtWorkMenuArtShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.ArtWorkMenuLyric = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicListMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MusicMenuListReset = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicMenuListDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MusicMenuListUp = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicMenuListDown = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicMenuListRandom = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MusicMenuLoopPlay = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.MusicMenuCreatePlayListCreate = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicMenuCreatePlayListOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.MusicMenuOpenDir = New System.Windows.Forms.ToolStripMenuItem()
        Me.AToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MusicPathList = New System.Windows.Forms.ListBox()
        Me.MediaPositionTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MediaPositionBar = New System.Windows.Forms.HScrollBar()
        Me.SongChengeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.VolumePanel = New System.Windows.Forms.Panel()
        Me.VolumeLabel = New System.Windows.Forms.Label()
        Me.VolumeBar = New System.Windows.Forms.TrackBar()
        Me.MusicPathListSub = New System.Windows.Forms.ListBox()
        Me.MusicListSub = New System.Windows.Forms.ListBox()
        Me.TimeLabel = New System.Windows.Forms.Label()
        Me.MusicPathList2 = New System.Windows.Forms.ListBox()
        Me.LoopStateLabel = New System.Windows.Forms.Label()
        Me.MusicDownBT = New System.Windows.Forms.Button()
        Me.MusicUpBT = New System.Windows.Forms.Button()
        Me.ArtWork = New System.Windows.Forms.PictureBox()
        Me.NextMusicBT = New System.Windows.Forms.PictureBox()
        Me.BackMusicBT = New System.Windows.Forms.PictureBox()
        Me.MediaVolumeBT = New System.Windows.Forms.PictureBox()
        Me.MediaStopBT = New System.Windows.Forms.PictureBox()
        Me.MediaPlayBT = New System.Windows.Forms.PictureBox()
        Me.SearchMusic = New System.Windows.Forms.Timer(Me.components)
        Me.LyricBox = New ZBobb.AlphaBlendTextBox()
        Me.MusicList = New System.Windows.Forms.ListBox()
        Me.MainMenuFileBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuCreatePlaylist = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuOpenPlaylist = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.MainMenuExitBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuToolBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuSettingsBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MainMenuSkinBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuSkinNormal = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuSkinDark = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuSkinWaterBlue = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuHelpBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuCheckUpdateBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenuVersionBT = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MainMenuBugCheck = New System.Windows.Forms.ToolStripMenuItem()
        Me.AToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.CToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MemBox = New System.Windows.Forms.ToolStripTextBox()
        Me.MemTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BackupTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MainPlayer = New AxWMPLib.AxWindowsMediaPlayer()
        Me.ArtWorkMenu.SuspendLayout()
        Me.MusicListMenu.SuspendLayout()
        Me.VolumePanel.SuspendLayout()
        CType(Me.VolumeBar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArtWork, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NextMusicBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BackMusicBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MediaVolumeBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MediaStopBT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MediaPlayBT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu.SuspendLayout()
        CType(Me.MainPlayer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ArtWorkMenu
        '
        Me.ArtWorkMenu.BackColor = System.Drawing.SystemColors.Control
        Me.ArtWorkMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArtWorkMenuArtShow, Me.ArtWorkMenuLyric})
        Me.ArtWorkMenu.Name = "ArtWorkMenu"
        Me.ArtWorkMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.ArtWorkMenu.ShowCheckMargin = True
        Me.ArtWorkMenu.ShowImageMargin = False
        Me.ArtWorkMenu.Size = New System.Drawing.Size(178, 48)
        '
        'ArtWorkMenuArtShow
        '
        Me.ArtWorkMenuArtShow.Name = "ArtWorkMenuArtShow"
        Me.ArtWorkMenuArtShow.Size = New System.Drawing.Size(177, 22)
        Me.ArtWorkMenuArtShow.Text = "アートワークを表示する"
        '
        'ArtWorkMenuLyric
        '
        Me.ArtWorkMenuLyric.Name = "ArtWorkMenuLyric"
        Me.ArtWorkMenuLyric.Size = New System.Drawing.Size(177, 22)
        Me.ArtWorkMenuLyric.Text = "歌詞を表示する"
        '
        'MusicListMenu
        '
        Me.MusicListMenu.BackColor = System.Drawing.SystemColors.Control
        Me.MusicListMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MusicMenuListReset, Me.MusicMenuListDelete, Me.ToolStripSeparator1, Me.MusicMenuListUp, Me.MusicMenuListDown, Me.MusicMenuListRandom, Me.ToolStripSeparator2, Me.MusicMenuLoopPlay, Me.ToolStripSeparator5, Me.MusicMenuCreatePlayListCreate, Me.MusicMenuCreatePlayListOpen, Me.ToolStripSeparator6, Me.MusicMenuOpenDir, Me.AToolStripMenuItem1, Me.BToolStripMenuItem1, Me.AddToolStripMenuItem, Me.NowToolStripMenuItem})
        Me.MusicListMenu.Name = "MusicListMenu"
        Me.MusicListMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MusicListMenu.Size = New System.Drawing.Size(208, 314)
        '
        'MusicMenuListReset
        '
        Me.MusicMenuListReset.Name = "MusicMenuListReset"
        Me.MusicMenuListReset.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuListReset.Text = "リストをリセット"
        '
        'MusicMenuListDelete
        '
        Me.MusicMenuListDelete.Name = "MusicMenuListDelete"
        Me.MusicMenuListDelete.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuListDelete.Text = "選択項目を削除"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(204, 6)
        '
        'MusicMenuListUp
        '
        Me.MusicMenuListUp.Name = "MusicMenuListUp"
        Me.MusicMenuListUp.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuListUp.Text = "上へ移動"
        '
        'MusicMenuListDown
        '
        Me.MusicMenuListDown.Name = "MusicMenuListDown"
        Me.MusicMenuListDown.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuListDown.Text = "下へ移動"
        '
        'MusicMenuListRandom
        '
        Me.MusicMenuListRandom.Name = "MusicMenuListRandom"
        Me.MusicMenuListRandom.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuListRandom.Text = "リストをランダムセット"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(204, 6)
        '
        'MusicMenuLoopPlay
        '
        Me.MusicMenuLoopPlay.Name = "MusicMenuLoopPlay"
        Me.MusicMenuLoopPlay.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuLoopPlay.Text = "連続再生"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(204, 6)
        '
        'MusicMenuCreatePlayListCreate
        '
        Me.MusicMenuCreatePlayListCreate.Name = "MusicMenuCreatePlayListCreate"
        Me.MusicMenuCreatePlayListCreate.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuCreatePlayListCreate.Text = "プレイリストの作成"
        '
        'MusicMenuCreatePlayListOpen
        '
        Me.MusicMenuCreatePlayListOpen.Name = "MusicMenuCreatePlayListOpen"
        Me.MusicMenuCreatePlayListOpen.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuCreatePlayListOpen.Text = "プレイリストを開く"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(204, 6)
        '
        'MusicMenuOpenDir
        '
        Me.MusicMenuOpenDir.Name = "MusicMenuOpenDir"
        Me.MusicMenuOpenDir.Size = New System.Drawing.Size(207, 22)
        Me.MusicMenuOpenDir.Text = "選択中の音楽フォルダを開く"
        '
        'AToolStripMenuItem1
        '
        Me.AToolStripMenuItem1.Name = "AToolStripMenuItem1"
        Me.AToolStripMenuItem1.Size = New System.Drawing.Size(207, 22)
        Me.AToolStripMenuItem1.Text = "Old"
        Me.AToolStripMenuItem1.Visible = False
        '
        'BToolStripMenuItem1
        '
        Me.BToolStripMenuItem1.Name = "BToolStripMenuItem1"
        Me.BToolStripMenuItem1.Size = New System.Drawing.Size(207, 22)
        Me.BToolStripMenuItem1.Text = "New"
        Me.BToolStripMenuItem1.Visible = False
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        Me.AddToolStripMenuItem.Visible = False
        '
        'NowToolStripMenuItem
        '
        Me.NowToolStripMenuItem.Name = "NowToolStripMenuItem"
        Me.NowToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.NowToolStripMenuItem.Text = "now"
        '
        'MusicPathList
        '
        Me.MusicPathList.FormattingEnabled = True
        Me.MusicPathList.ItemHeight = 12
        Me.MusicPathList.Location = New System.Drawing.Point(126, 32)
        Me.MusicPathList.Name = "MusicPathList"
        Me.MusicPathList.Size = New System.Drawing.Size(205, 100)
        Me.MusicPathList.TabIndex = 19
        Me.MusicPathList.Visible = False
        '
        'MediaPositionTimer
        '
        Me.MediaPositionTimer.Interval = 1000
        '
        'MediaPositionBar
        '
        Me.MediaPositionBar.Location = New System.Drawing.Point(12, 279)
        Me.MediaPositionBar.Name = "MediaPositionBar"
        Me.MediaPositionBar.Size = New System.Drawing.Size(499, 22)
        Me.MediaPositionBar.TabIndex = 26
        '
        'SongChengeTimer
        '
        Me.SongChengeTimer.Interval = 1000
        '
        'VolumePanel
        '
        Me.VolumePanel.BackColor = System.Drawing.SystemColors.Control
        Me.VolumePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.VolumePanel.Controls.Add(Me.VolumeLabel)
        Me.VolumePanel.Controls.Add(Me.VolumeBar)
        Me.VolumePanel.Location = New System.Drawing.Point(385, 192)
        Me.VolumePanel.Name = "VolumePanel"
        Me.VolumePanel.Size = New System.Drawing.Size(86, 156)
        Me.VolumePanel.TabIndex = 34
        Me.VolumePanel.Visible = False
        '
        'VolumeLabel
        '
        Me.VolumeLabel.AutoSize = True
        Me.VolumeLabel.ForeColor = System.Drawing.SystemColors.Info
        Me.VolumeLabel.Location = New System.Drawing.Point(55, 72)
        Me.VolumeLabel.Name = "VolumeLabel"
        Me.VolumeLabel.Size = New System.Drawing.Size(23, 12)
        Me.VolumeLabel.TabIndex = 1
        Me.VolumeLabel.Text = "100"
        '
        'VolumeBar
        '
        Me.VolumeBar.Location = New System.Drawing.Point(4, 2)
        Me.VolumeBar.Maximum = 100
        Me.VolumeBar.Name = "VolumeBar"
        Me.VolumeBar.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.VolumeBar.Size = New System.Drawing.Size(45, 150)
        Me.VolumeBar.TabIndex = 0
        Me.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.VolumeBar.Value = 100
        '
        'MusicPathListSub
        '
        Me.MusicPathListSub.FormattingEnabled = True
        Me.MusicPathListSub.ItemHeight = 12
        Me.MusicPathListSub.Location = New System.Drawing.Point(12, 172)
        Me.MusicPathListSub.Name = "MusicPathListSub"
        Me.MusicPathListSub.Size = New System.Drawing.Size(125, 100)
        Me.MusicPathListSub.TabIndex = 35
        Me.MusicPathListSub.Visible = False
        '
        'MusicListSub
        '
        Me.MusicListSub.FormattingEnabled = True
        Me.MusicListSub.ItemHeight = 12
        Me.MusicListSub.Location = New System.Drawing.Point(199, 232)
        Me.MusicListSub.Name = "MusicListSub"
        Me.MusicListSub.Size = New System.Drawing.Size(117, 40)
        Me.MusicListSub.TabIndex = 36
        Me.MusicListSub.Visible = False
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TimeLabel.Location = New System.Drawing.Point(157, 330)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(91, 12)
        Me.TimeLabel.TabIndex = 37
        Me.TimeLabel.Text = "00:00:00/00:00:00"
        '
        'MusicPathList2
        '
        Me.MusicPathList2.FormattingEnabled = True
        Me.MusicPathList2.ItemHeight = 12
        Me.MusicPathList2.Location = New System.Drawing.Point(126, 138)
        Me.MusicPathList2.Name = "MusicPathList2"
        Me.MusicPathList2.Size = New System.Drawing.Size(205, 88)
        Me.MusicPathList2.TabIndex = 38
        Me.MusicPathList2.Visible = False
        '
        'LoopStateLabel
        '
        Me.LoopStateLabel.AutoSize = True
        Me.LoopStateLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LoopStateLabel.Location = New System.Drawing.Point(254, 330)
        Me.LoopStateLabel.Name = "LoopStateLabel"
        Me.LoopStateLabel.Size = New System.Drawing.Size(62, 12)
        Me.LoopStateLabel.TabIndex = 40
        Me.LoopStateLabel.Text = "{LoopState}"
        '
        'MusicDownBT
        '
        Me.MusicDownBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.down
        Me.MusicDownBT.Location = New System.Drawing.Point(480, 61)
        Me.MusicDownBT.Name = "MusicDownBT"
        Me.MusicDownBT.Size = New System.Drawing.Size(31, 23)
        Me.MusicDownBT.TabIndex = 42
        Me.MusicDownBT.UseVisualStyleBackColor = True
        '
        'MusicUpBT
        '
        Me.MusicUpBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.up
        Me.MusicUpBT.Location = New System.Drawing.Point(480, 32)
        Me.MusicUpBT.Name = "MusicUpBT"
        Me.MusicUpBT.Size = New System.Drawing.Size(31, 23)
        Me.MusicUpBT.TabIndex = 41
        Me.MusicUpBT.UseVisualStyleBackColor = True
        '
        'ArtWork
        '
        Me.ArtWork.ContextMenuStrip = Me.ArtWorkMenu
        Me.ArtWork.Location = New System.Drawing.Point(12, 32)
        Me.ArtWork.Name = "ArtWork"
        Me.ArtWork.Size = New System.Drawing.Size(108, 72)
        Me.ArtWork.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ArtWork.TabIndex = 32
        Me.ArtWork.TabStop = False
        '
        'NextMusicBT
        '
        Me.NextMusicBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.ForwardHover
        Me.NextMusicBT.Location = New System.Drawing.Point(126, 323)
        Me.NextMusicBT.Name = "NextMusicBT"
        Me.NextMusicBT.Size = New System.Drawing.Size(25, 25)
        Me.NextMusicBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.NextMusicBT.TabIndex = 31
        Me.NextMusicBT.TabStop = False
        '
        'BackMusicBT
        '
        Me.BackMusicBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.BackHover
        Me.BackMusicBT.Location = New System.Drawing.Point(95, 323)
        Me.BackMusicBT.Name = "BackMusicBT"
        Me.BackMusicBT.Size = New System.Drawing.Size(25, 25)
        Me.BackMusicBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BackMusicBT.TabIndex = 30
        Me.BackMusicBT.TabStop = False
        '
        'MediaVolumeBT
        '
        Me.MediaVolumeBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.VolumeHover
        Me.MediaVolumeBT.Location = New System.Drawing.Point(477, 314)
        Me.MediaVolumeBT.Name = "MediaVolumeBT"
        Me.MediaVolumeBT.Size = New System.Drawing.Size(34, 34)
        Me.MediaVolumeBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MediaVolumeBT.TabIndex = 29
        Me.MediaVolumeBT.TabStop = False
        '
        'MediaStopBT
        '
        Me.MediaStopBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.StopHover
        Me.MediaStopBT.Location = New System.Drawing.Point(54, 323)
        Me.MediaStopBT.Name = "MediaStopBT"
        Me.MediaStopBT.Size = New System.Drawing.Size(25, 25)
        Me.MediaStopBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MediaStopBT.TabIndex = 28
        Me.MediaStopBT.TabStop = False
        '
        'MediaPlayBT
        '
        Me.MediaPlayBT.Image = Global.KMMediaPlayer_Fix.My.Resources.Resources.PlayHover
        Me.MediaPlayBT.Location = New System.Drawing.Point(12, 312)
        Me.MediaPlayBT.Name = "MediaPlayBT"
        Me.MediaPlayBT.Size = New System.Drawing.Size(36, 36)
        Me.MediaPlayBT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MediaPlayBT.TabIndex = 27
        Me.MediaPlayBT.TabStop = False
        '
        'SearchMusic
        '
        Me.SearchMusic.Interval = 1000
        '
        'LyricBox
        '
        Me.LyricBox.BackAlpha = 10
        Me.LyricBox.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LyricBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LyricBox.ContextMenuStrip = Me.ArtWorkMenu
        Me.LyricBox.Cursor = System.Windows.Forms.Cursors.Default
        Me.LyricBox.ForeColor = System.Drawing.Color.Snow
        Me.LyricBox.Location = New System.Drawing.Point(12, 110)
        Me.LyricBox.Multiline = True
        Me.LyricBox.Name = "LyricBox"
        Me.LyricBox.ReadOnly = True
        Me.LyricBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.LyricBox.Size = New System.Drawing.Size(108, 121)
        Me.LyricBox.TabIndex = 43
        '
        'MusicList
        '
        Me.MusicList.AllowDrop = True
        Me.MusicList.BackColor = System.Drawing.SystemColors.Control
        Me.MusicList.ContextMenuStrip = Me.MusicListMenu
        Me.MusicList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MusicList.FormattingEnabled = True
        Me.MusicList.HorizontalScrollbar = True
        Me.MusicList.ItemHeight = 12
        Me.MusicList.Location = New System.Drawing.Point(337, 32)
        Me.MusicList.Name = "MusicList"
        Me.MusicList.Size = New System.Drawing.Size(137, 244)
        Me.MusicList.TabIndex = 17
        '
        'MainMenuFileBT
        '
        Me.MainMenuFileBT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainMenuCreatePlaylist, Me.MainMenuOpenPlaylist, Me.ToolStripSeparator7, Me.MainMenuExitBT})
        Me.MainMenuFileBT.Name = "MainMenuFileBT"
        Me.MainMenuFileBT.Size = New System.Drawing.Size(67, 20)
        Me.MainMenuFileBT.Text = "ファイル(&F)"
        '
        'MainMenuCreatePlaylist
        '
        Me.MainMenuCreatePlaylist.Name = "MainMenuCreatePlaylist"
        Me.MainMenuCreatePlaylist.Size = New System.Drawing.Size(160, 22)
        Me.MainMenuCreatePlaylist.Text = "プレイリストの作成"
        '
        'MainMenuOpenPlaylist
        '
        Me.MainMenuOpenPlaylist.Name = "MainMenuOpenPlaylist"
        Me.MainMenuOpenPlaylist.Size = New System.Drawing.Size(160, 22)
        Me.MainMenuOpenPlaylist.Text = "プレイリストを開く"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(157, 6)
        '
        'MainMenuExitBT
        '
        Me.MainMenuExitBT.BackColor = System.Drawing.SystemColors.Control
        Me.MainMenuExitBT.Name = "MainMenuExitBT"
        Me.MainMenuExitBT.Size = New System.Drawing.Size(160, 22)
        Me.MainMenuExitBT.Text = "閉じる(&X)"
        '
        'MainMenuToolBT
        '
        Me.MainMenuToolBT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainMenuSettingsBT, Me.ToolStripSeparator3, Me.MainMenuSkinBT})
        Me.MainMenuToolBT.Name = "MainMenuToolBT"
        Me.MainMenuToolBT.Size = New System.Drawing.Size(60, 20)
        Me.MainMenuToolBT.Text = "ツール(&T)"
        '
        'MainMenuSettingsBT
        '
        Me.MainMenuSettingsBT.Name = "MainMenuSettingsBT"
        Me.MainMenuSettingsBT.Size = New System.Drawing.Size(112, 22)
        Me.MainMenuSettingsBT.Text = "設定(&S)"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(109, 6)
        Me.ToolStripSeparator3.Visible = False
        '
        'MainMenuSkinBT
        '
        Me.MainMenuSkinBT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainMenuSkinNormal, Me.MainMenuSkinDark, Me.MainMenuSkinWaterBlue})
        Me.MainMenuSkinBT.Enabled = False
        Me.MainMenuSkinBT.Name = "MainMenuSkinBT"
        Me.MainMenuSkinBT.Size = New System.Drawing.Size(112, 22)
        Me.MainMenuSkinBT.Text = "スキン"
        Me.MainMenuSkinBT.Visible = False
        '
        'MainMenuSkinNormal
        '
        Me.MainMenuSkinNormal.Name = "MainMenuSkinNormal"
        Me.MainMenuSkinNormal.Size = New System.Drawing.Size(100, 22)
        Me.MainMenuSkinNormal.Text = "通常"
        '
        'MainMenuSkinDark
        '
        Me.MainMenuSkinDark.Name = "MainMenuSkinDark"
        Me.MainMenuSkinDark.Size = New System.Drawing.Size(100, 22)
        Me.MainMenuSkinDark.Text = "ダーク"
        '
        'MainMenuSkinWaterBlue
        '
        Me.MainMenuSkinWaterBlue.Name = "MainMenuSkinWaterBlue"
        Me.MainMenuSkinWaterBlue.Size = New System.Drawing.Size(100, 22)
        Me.MainMenuSkinWaterBlue.Text = "水色"
        '
        'MainMenuHelpBT
        '
        Me.MainMenuHelpBT.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainMenuCheckUpdateBT, Me.MainMenuVersionBT, Me.ToolStripSeparator4, Me.MainMenuBugCheck})
        Me.MainMenuHelpBT.Name = "MainMenuHelpBT"
        Me.MainMenuHelpBT.Size = New System.Drawing.Size(65, 20)
        Me.MainMenuHelpBT.Text = "ヘルプ(&H)"
        '
        'MainMenuCheckUpdateBT
        '
        Me.MainMenuCheckUpdateBT.Name = "MainMenuCheckUpdateBT"
        Me.MainMenuCheckUpdateBT.Size = New System.Drawing.Size(159, 22)
        Me.MainMenuCheckUpdateBT.Text = "アップデートの確認"
        '
        'MainMenuVersionBT
        '
        Me.MainMenuVersionBT.Name = "MainMenuVersionBT"
        Me.MainMenuVersionBT.Size = New System.Drawing.Size(159, 22)
        Me.MainMenuVersionBT.Text = "バージョン情報(&A)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(156, 6)
        '
        'MainMenuBugCheck
        '
        Me.MainMenuBugCheck.Name = "MainMenuBugCheck"
        Me.MainMenuBugCheck.Size = New System.Drawing.Size(159, 22)
        Me.MainMenuBugCheck.Text = "不具合報告"
        '
        'AToolStripMenuItem
        '
        Me.AToolStripMenuItem.Name = "AToolStripMenuItem"
        Me.AToolStripMenuItem.Size = New System.Drawing.Size(25, 23)
        Me.AToolStripMenuItem.Text = "a"
        Me.AToolStripMenuItem.Visible = False
        '
        'BToolStripMenuItem
        '
        Me.BToolStripMenuItem.Name = "BToolStripMenuItem"
        Me.BToolStripMenuItem.Size = New System.Drawing.Size(26, 23)
        Me.BToolStripMenuItem.Text = "b"
        Me.BToolStripMenuItem.Visible = False
        '
        'MainMenu
        '
        Me.MainMenu.BackColor = System.Drawing.SystemColors.Control
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainMenuFileBT, Me.MainMenuToolBT, Me.MainMenuHelpBT, Me.AToolStripMenuItem, Me.BToolStripMenuItem, Me.CToolStripMenuItem, Me.DToolStripMenuItem, Me.EToolStripMenuItem, Me.MemBox})
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MainMenu.Size = New System.Drawing.Size(523, 24)
        Me.MainMenu.TabIndex = 33
        Me.MainMenu.Text = "MenuStrip2"
        '
        'CToolStripMenuItem
        '
        Me.CToolStripMenuItem.Name = "CToolStripMenuItem"
        Me.CToolStripMenuItem.Size = New System.Drawing.Size(25, 23)
        Me.CToolStripMenuItem.Text = "c"
        Me.CToolStripMenuItem.Visible = False
        '
        'DToolStripMenuItem
        '
        Me.DToolStripMenuItem.Name = "DToolStripMenuItem"
        Me.DToolStripMenuItem.Size = New System.Drawing.Size(26, 23)
        Me.DToolStripMenuItem.Text = "d"
        Me.DToolStripMenuItem.Visible = False
        '
        'EToolStripMenuItem
        '
        Me.EToolStripMenuItem.Name = "EToolStripMenuItem"
        Me.EToolStripMenuItem.Size = New System.Drawing.Size(25, 23)
        Me.EToolStripMenuItem.Text = "e"
        Me.EToolStripMenuItem.Visible = False
        '
        'MemBox
        '
        Me.MemBox.Name = "MemBox"
        Me.MemBox.Size = New System.Drawing.Size(100, 23)
        Me.MemBox.Visible = False
        '
        'MemTimer
        '
        '
        'BackupTimer
        '
        Me.BackupTimer.Interval = 60000
        '
        'MainPlayer
        '
        Me.MainPlayer.Enabled = True
        Me.MainPlayer.Location = New System.Drawing.Point(12, 32)
        Me.MainPlayer.Name = "MainPlayer"
        Me.MainPlayer.OcxState = CType(resources.GetObject("MainPlayer.OcxState"), System.Windows.Forms.AxHost.State)
        Me.MainPlayer.Size = New System.Drawing.Size(319, 244)
        Me.MainPlayer.TabIndex = 0
        Me.MainPlayer.Visible = False
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(523, 360)
        Me.Controls.Add(Me.MusicPathList2)
        Me.Controls.Add(Me.LyricBox)
        Me.Controls.Add(Me.VolumePanel)
        Me.Controls.Add(Me.MusicDownBT)
        Me.Controls.Add(Me.MusicPathListSub)
        Me.Controls.Add(Me.LoopStateLabel)
        Me.Controls.Add(Me.MusicUpBT)
        Me.Controls.Add(Me.MusicListSub)
        Me.Controls.Add(Me.MusicPathList)
        Me.Controls.Add(Me.ArtWork)
        Me.Controls.Add(Me.TimeLabel)
        Me.Controls.Add(Me.MediaPositionBar)
        Me.Controls.Add(Me.MainPlayer)
        Me.Controls.Add(Me.NextMusicBT)
        Me.Controls.Add(Me.BackMusicBT)
        Me.Controls.Add(Me.MainMenu)
        Me.Controls.Add(Me.MediaStopBT)
        Me.Controls.Add(Me.MusicList)
        Me.Controls.Add(Me.MediaVolumeBT)
        Me.Controls.Add(Me.MediaPlayBT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ArtWorkMenu.ResumeLayout(False)
        Me.MusicListMenu.ResumeLayout(False)
        Me.VolumePanel.ResumeLayout(False)
        Me.VolumePanel.PerformLayout()
        CType(Me.VolumeBar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArtWork, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NextMusicBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BackMusicBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MediaVolumeBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MediaStopBT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MediaPlayBT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu.ResumeLayout(False)
        Me.MainMenu.PerformLayout()
        CType(Me.MainPlayer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MainPlayer As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents MusicPathList As System.Windows.Forms.ListBox
    Friend WithEvents MediaPositionTimer As System.Windows.Forms.Timer
    Friend WithEvents MediaPositionBar As System.Windows.Forms.HScrollBar
    Friend WithEvents SongChengeTimer As System.Windows.Forms.Timer
    Friend WithEvents MediaPlayBT As System.Windows.Forms.PictureBox
    Friend WithEvents MediaStopBT As System.Windows.Forms.PictureBox
    Friend WithEvents MediaVolumeBT As System.Windows.Forms.PictureBox
    Friend WithEvents BackMusicBT As System.Windows.Forms.PictureBox
    Friend WithEvents NextMusicBT As System.Windows.Forms.PictureBox
    Friend WithEvents ArtWork As System.Windows.Forms.PictureBox
    Friend WithEvents MusicListMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MusicMenuListReset As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MusicMenuListUp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MusicMenuListDown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VolumePanel As System.Windows.Forms.Panel
    Friend WithEvents VolumeLabel As System.Windows.Forms.Label
    Friend WithEvents VolumeBar As System.Windows.Forms.TrackBar
    Friend WithEvents MusicPathListSub As System.Windows.Forms.ListBox
    Friend WithEvents MusicListSub As System.Windows.Forms.ListBox
    Friend WithEvents MusicMenuListRandom As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MusicMenuListDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MusicMenuLoopPlay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimeLabel As System.Windows.Forms.Label
    Friend WithEvents MusicPathList2 As System.Windows.Forms.ListBox
    Friend WithEvents ArtWorkMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ArtWorkMenuArtShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoopStateLabel As System.Windows.Forms.Label
    Friend WithEvents MusicUpBT As System.Windows.Forms.Button
    Friend WithEvents MusicDownBT As System.Windows.Forms.Button
    Friend WithEvents SearchMusic As System.Windows.Forms.Timer

    Public WithEvents MusicList As System.Windows.Forms.ListBox

    Friend WithEvents MusicMenuCreatePlayListCreate As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MusicMenuCreatePlayListOpen As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MusicMenuOpenDir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LyricBox As ZBobb.AlphaBlendTextBox
    Friend WithEvents ArtWorkMenuLyric As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuFileBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuCreatePlaylist As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuOpenPlaylist As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MainMenuExitBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuToolBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuSettingsBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MainMenuSkinBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuSkinNormal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuSkinDark As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuSkinWaterBlue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuHelpBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuCheckUpdateBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenuVersionBT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MainMenuBugCheck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MainMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents MemBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents MemTimer As System.Windows.Forms.Timer
    Friend WithEvents BackupTimer As System.Windows.Forms.Timer
    Friend WithEvents DToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
