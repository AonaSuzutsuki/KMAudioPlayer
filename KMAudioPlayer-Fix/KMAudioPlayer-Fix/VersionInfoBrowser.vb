Imports System.Runtime.InteropServices

Public Class VersionInfoBrowser

    <DllImport("KERNEL32.DLL")> _
    Public Shared Function WritePrivateProfileString( _
ByVal lpAppName As String, _
ByVal lpKeyName As String, _
ByVal lpString As String, _
ByVal lpFileName As String) As Integer
    End Function

    <DllImport("KERNEL32.DLL", CharSet:=CharSet.Auto)> _
    Public Shared Function GetPrivateProfileInt( _
ByVal lpAppName As String, _
ByVal lpKeyName As String, ByVal nDefault As Integer, _
ByVal lpFileName As String) As Integer
    End Function

    Public url As String

    Private Sub VersionInfoBrowser_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Select Case Me.WindowState
            Case FormWindowState.Normal
                VersionInfoBrowser.WritePrivateProfileString("Size", "Width", Me.Width, My.Application.Info.DirectoryPath & "\Browser.ini")
                VersionInfoBrowser.WritePrivateProfileString("Size", "Height", Me.Height, My.Application.Info.DirectoryPath & "\Browser.ini")
            Case FormWindowState.Minimized

            Case FormWindowState.Maximized

        End Select
    End Sub

    Private Sub VersionInfoBrowser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (System.IO.File.Exists("./Browser.ini")) Then
            Dim iniWidth As Integer
            Dim iniHeight As Integer
            iniWidth = VersionInfoBrowser.GetPrivateProfileInt("Size", "Width", 0, My.Application.Info.DirectoryPath & "\Browser.ini")
            iniHeight = VersionInfoBrowser.GetPrivateProfileInt("Size", "Height", 0, My.Application.Info.DirectoryPath & "\Browser.ini")
            Me.Size = New Size(iniWidth, iniHeight)
            Dim ScreenWidth As Integer
            Dim ScreenHeight As Integer
            ScreenWidth = SystemInformation.WorkingArea.Width
            ScreenHeight = SystemInformation.WorkingArea.Height
            Me.Location = New Point((ScreenWidth - Me.Width) / 2, _
           (ScreenHeight - Me.Height) / 2)
        End If

        StatusLabel.Text = ""
        MainBrowser.Navigate(url)
        StatusLabel.Text = "読み込み中"

        BrowserBackBT.Enabled = False
        BrowserForwardBT.Enabled = False
    End Sub

    Private Sub CloseMenuBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseMenuBT.Click
        Close()
    End Sub


    Private Sub MainBrowser_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles MainBrowser.DocumentCompleted
        Me.Text = MainBrowser.DocumentTitle.ToString
        BrowserURLBox.Text = MainBrowser.Url.ToString
        StatusLabel.Text = ""

        If (MainBrowser.CanGoBack) Then
            BrowserBackBT.Enabled = True
        Else
            BrowserBackBT.Enabled = False
        End If

        If (MainBrowser.CanGoForward) Then
            BrowserForwardBT.Enabled = True
        Else
            BrowserForwardBT.Enabled = False
        End If

    End Sub

    Private Sub MainBrowser_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MainBrowser.NewWindow
        Dim NewURL As String = CType(sender, WebBrowser).StatusText
        MainBrowser.Navigate(NewURL)
        e.Cancel = True
    End Sub

    Private Sub BrowserBackBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowserBackBT.Click
        MainBrowser.GoBack()
    End Sub

    Private Sub BrowserForwardBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowserForwardBT.Click
        MainBrowser.GoForward()
    End Sub

    Private Sub BrowserURLBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BrowserURLBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            MainBrowser.Navigate(BrowserURLBox.Text)
        End If
    End Sub
End Class