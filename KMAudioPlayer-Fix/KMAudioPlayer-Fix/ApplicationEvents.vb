Imports System.IO

Namespace My

    ' 次のイベントは MyApplication に対して利用できます:
    ' 
    ' Startup: アプリケーションが開始されたとき、スタートアップ フォームが作成される前に発生します。
    ' Shutdown: アプリケーション フォームがすべて閉じられた後に発生します。このイベントは、通常の終了以外の方法でアプリケーションが終了されたときには発生しません。
    ' UnhandledException: ハンドルされていない例外がアプリケーションで発生したときに発生するイベントです。
    ' StartupNextInstance: 単一インスタンス アプリケーションが起動され、それが既にアクティブであるときに発生します。 
    ' NetworkAvailabilityChanged: ネットワーク接続が接続されたとき、または切断されたときに発生します。
    Partial Friend Class MyApplication

        Dim i As Integer

        Private Sub MyApplication_Startup() Handles Me.Startup
            'Dim os As System.OperatingSystem = System.Environment.OSVersion
            'Select Case os.Platform
            '    Case System.PlatformID.Win32NT
            '        Select Case os.Version.Major
            '            Case 5
            '                Select Case os.Version.Minor
            '                    Case 1
            '                        'XP
            '                        Exit Select
            '                    Case 2
            '                        'Server 2003
            '                        Exit Select
            '                End Select
            '                Exit Select
            '            Case 6
            '                Select Case os.Version.Minor
            '                    Case 0

            '                        'Vista
            '                        If (System.Windows.Forms.VisualStyles.VisualStyleInformation.DisplayName.IndexOf("Aero") > -1) Then
            '                            If (System.Windows.Forms.VisualStyles.VisualStyleInformation.Author = "MSX") Then
            '                                KMMediaPlayer_Fix.MainForm.MainMenuSkinBT.Enabled = True
            '                            Else
            '                                KMMediaPlayer_Fix.MainForm.MainMenuSkinBT.Enabled = False
            '                            End If
            '                        Else
            '                            KMMediaPlayer_Fix.MainForm.MainMenuSkinBT.Enabled = False
            '                        End If

            '                        Exit Select
            '                    Case 1

            '                        '7
            '                        If (System.Windows.Forms.VisualStyles.VisualStyleInformation.DisplayName.IndexOf("Aero") > -1) Then
            '                            If (System.Windows.Forms.VisualStyles.VisualStyleInformation.Author = "MSX") Then
            '                                KMMediaPlayer_Fix.MainForm.MainMenuSkinBT.Enabled = True
            '                            Else
            '                                KMMediaPlayer_Fix.MainForm.MainMenuSkinBT.Enabled = False
            '                            End If
            '                        Else
            '                            KMMediaPlayer_Fix.MainForm.MainMenuSkinBT.Enabled = False
            '                        End If

            '                        Exit Select
            '                End Select
            '                Exit Select
            '        End Select
            'End Select
        End Sub

        Private Sub MyApplication_StartupNextInstance( _
                ByVal sender As Object, _
                ByVal e As Microsoft.VisualBasic.ApplicationServices. _
                StartupNextInstanceEventArgs) _
                Handles Me.StartupNextInstance
            'MsgBox("二重起動されました")

            '後で起動されたアプリケーションのコマンドライン引数を表示
            Dim index As Integer
            For Each cmd As String In e.CommandLine

                If (cmd.IndexOf(".kmplist") > -1) Then
                    OpenPlaylistLoad(cmd)
                ElseIf (cmd.IndexOf(".wpl") > -1) Then

                Else
                    Dim filename As String = System.IO.Path.GetFileNameWithoutExtension(cmd)
                    index = KMMediaPlayer_Fix.MainForm.MusicPathList.FindStringExact(cmd)

                    If (index = ListBox.NoMatches) Then
                        KMMediaPlayer_Fix.MainForm.MusicPathList.Items.Add(cmd)
                        KMMediaPlayer_Fix.MainForm.MusicPathList2.Items.Add(cmd)
                        KMMediaPlayer_Fix.MainForm.MusicList.Items.Add(filename)
                    End If
                End If

            Next

            KMMediaPlayer_Fix.MainForm.MediaPlayBT.Enabled = True


            '先に起動しているアプリケーションをアクティブにしない
            e.BringToForeground = True
        End Sub

        Private Sub OpenPlaylistLoad(ByVal MainFileName As String)
            Dim contclass As New Controls

            KMMediaPlayer_Fix.MainForm.MusicPathList.Items.Clear()
            KMMediaPlayer_Fix.MainForm.MusicPathList2.Items.Clear()
            KMMediaPlayer_Fix.MainForm.MusicList.Items.Clear()
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
                            KMMediaPlayer_Fix.MainForm.MusicPathList.Items.Add(contclass.GetString(filename, 1))
                            KMMediaPlayer_Fix.MainForm.MusicPathList2.Items.Add(contclass.GetString(filename, 1))
                            KMMediaPlayer_Fix.MainForm.MusicList.Items.Add(contclass.GetString(filename, 2))
                            alertnum = 1
                        ElseIf (result = DialogResult.No Or alertnum = 2) Then
                            alertnum = 2
                        End If
                    Else
                        KMMediaPlayer_Fix.MainForm.MusicPathList.Items.Add(contclass.GetStringFix(filename, 1))
                        KMMediaPlayer_Fix.MainForm.MusicPathList2.Items.Add(contclass.GetStringFix(filename, 1))
                        KMMediaPlayer_Fix.MainForm.MusicList.Items.Add(contclass.GetStringFix(filename, 2))
                    End If
                End While
            End Using
            KMMediaPlayer_Fix.MainForm.MediaPlayBT.Enabled = True
        End Sub
    End Class


End Namespace

