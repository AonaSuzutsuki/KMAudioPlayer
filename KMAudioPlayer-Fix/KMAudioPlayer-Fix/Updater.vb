Public Class Updater

    Public AutoInt As Integer

    Private Sub Updater_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AutoInt = MainForm.AutoInt
        If (AutoInt = 0) Then
            UpdateBT.Enabled = False
        Else
            UpdateBT.Enabled = True
        End If
    End Sub

    Private Sub CheckBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBT.Click
        UpdateCheck()
    End Sub

    Public Sub UpdateCheck()
        Dim version As String
        Try
            Using wc As New System.Net.WebClient()
                wc.DownloadFile("http://kimamaningen.futene.net/HTML/Downloads/TGSUpdate/KMAudioPlayer/version.txt", My.Application.Info.DirectoryPath & "\version.txt")
            End Using
        Catch ex As Exception
            MsgBox("ファイルが見つかりません。", vbCritical, "エラー")
            MsgBox("バージョン確認ができません。", vbCritical, "エラー")
        End Try

        Try
            Using sr As New System.IO.StreamReader(My.Application.Info.DirectoryPath & "\version.txt")
                version = sr.ReadToEnd()
            End Using
            If (My.Application.Info.Version.ToString = version) Then
                MsgBox("アップデートはありません。", vbInformation, "お知らせ")
                System.IO.File.Delete("version.txt")
            Else
                MsgBox("アップデートがあります。", vbInformation, "お知らせ")
                System.IO.File.Delete("version.txt")
                UpdateBT.Enabled = True
            End If
        Catch

        End Try
    End Sub

    Public Sub UpdateCheckNoAlert()
        Dim version As String
        Try
            Using wc As New System.Net.WebClient()
                wc.DownloadFile("http://kimamaningen.futene.net/HTML/Downloads/TGSUpdate/KMMediaPlayer/version.txt", "version.txt")
            End Using
        Catch ex As Exception
            
        End Try

        Try
            Using sr As New System.IO.StreamReader("version.txt")
                version = sr.ReadToEnd()
            End Using
            If (My.Application.Info.Version.ToString = version) Then
                Me.Invoke(New MethodInvoker(Sub()
                                                MainForm.AutoInt = 0
                                            End Sub))
                System.IO.File.Delete("version.txt")
            Else
                MsgBox("アップデートがあります。", vbInformation, "お知らせ")
                Me.Invoke(New MethodInvoker(Sub()
                                                MainForm.AutoInt = 1
                                            End Sub))
                System.IO.File.Delete("version.txt")
            End If
        Catch

        End Try
    End Sub

    Private Sub UpdateBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateBT.Click
        System.IO.File.Create(My.Application.Info.DirectoryPath & "\agree")
        Process.Start(My.Application.Info.DirectoryPath & "\update.exe")
        End
    End Sub
End Class