Public Class VerInfo

    Private Sub VerInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TitleLabel.Text = My.Application.Info.Title
        NameLabel.Text = "rvv[JP]"
        VersionLabel.Text = My.Application.Info.Version.ToString '+ "b3"
    End Sub

    Private Sub NameLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles NameLabel.LinkClicked
        VersionInfoBrowser.url = "http://kimamaningen.futene.net"
        VersionInfoBrowser.Show()
    End Sub


    Private Sub OKBT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKBT.Click
        Close()
    End Sub

    Private Sub AyaHP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles AyaHP.LinkClicked
        VersionInfoBrowser.url = "http://123456aya.web.fc2.com"
        VersionInfoBrowser.Show()
    End Sub

    Private Sub RevolHP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles RevolHP.LinkClicked
        VersionInfoBrowser.url = "http://www.youtube.com/user/0t0taja"
        VersionInfoBrowser.Show()
    End Sub

    Private Sub KyoroziHP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles KyoroziHP.LinkClicked
        VersionInfoBrowser.url = "http://blogs.yahoo.co.jp/diwasakikyo"
        VersionInfoBrowser.Show()
    End Sub

    Private Sub NekoUmiHP_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles NekoUmiHP.LinkClicked
        VersionInfoBrowser.url = "http://www.pixiv.net/member.php?id=4151861"
        VersionInfoBrowser.Show()
    End Sub
End Class