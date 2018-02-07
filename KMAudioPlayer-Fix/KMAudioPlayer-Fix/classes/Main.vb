Public Class Main
    Public Shared Sub Main(ByVal CmdArgs() As String)
        Dim frm As New MainForm

        frm.MusicList.Items.AddRange(CmdArgs)
        'Dim cmd As String
        'For Each cmd In CmdArgs

        'Next

        Application.Run(frm)
    End Sub
End Class
