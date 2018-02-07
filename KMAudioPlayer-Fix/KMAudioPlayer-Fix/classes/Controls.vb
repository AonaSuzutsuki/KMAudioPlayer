Public Class Controls

    Public Function GetString(ByVal Matches As String, ByVal GetStrNum As Integer)
        Dim MainStringData As New System.Text.RegularExpressions.Regex("{(.*?)_(.*?)}", _
            System.Text.RegularExpressions.RegexOptions.IgnoreCase Or _
            System.Text.RegularExpressions.RegexOptions.Singleline)

        Dim StringData As System.Text.RegularExpressions.MatchCollection = _
            MainStringData.Matches("{" & Matches & "}")

        For Each resultString As System.Text.RegularExpressions.Match In StringData
            Return resultString.Groups(GetStrNum).Value
        Next

        Return "NULL"
    End Function

    Public Function GetStringFix(ByVal Matches As String, ByVal GetStrNum As Integer)
        Dim MainStringData As New System.Text.RegularExpressions.Regex("{(.*?)""crlf""(.*?)}", _
            System.Text.RegularExpressions.RegexOptions.IgnoreCase Or _
            System.Text.RegularExpressions.RegexOptions.Singleline)

        Dim StringData As System.Text.RegularExpressions.MatchCollection = _
            MainStringData.Matches("{" & Matches & "}")

        For Each resultString As System.Text.RegularExpressions.Match In StringData
            Return resultString.Groups(GetStrNum).Value
        Next

        Return "NULL"
    End Function
End Class
