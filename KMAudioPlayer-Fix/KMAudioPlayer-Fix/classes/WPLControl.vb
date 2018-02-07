Imports System.Xml

Public Class WPLControl
    Public Function WPLCreate(ByVal savepath As String, ByVal mediapath As ArrayList) As Integer
        Dim xDocument As XmlDocument = New XmlDocument
        Dim xDeclaration As XmlProcessingInstruction = xDocument.CreateProcessingInstruction("wpl", "version=""1.0""")
        Dim xRoot As XmlElement = xDocument.CreateElement("smil")

        Dim xmeta As XmlElement

        'Head
        Dim header As XmlElement = xDocument.CreateElement("head")

        xmeta = xDocument.CreateElement("meta")
        xmeta.SetAttribute("name", "Generator")
        xmeta.SetAttribute("content", "KMAudioPlayer")
        header.AppendChild(xmeta)

        xmeta = xDocument.CreateElement("meta")
        xmeta.SetAttribute("name", "ItemCount")
        xmeta.SetAttribute("content", mediapath.Count)
        header.AppendChild(xmeta)

        'Body
        Dim bodier As XmlElement = xDocument.CreateElement("body")
        Dim seqer As XmlElement = xDocument.CreateElement("seq")
        Dim xmedia As XmlElement

        For i = 0 To mediapath.Count - 1
            xmedia = xDocument.CreateElement("media")
            xmedia.SetAttribute("src", mediapath(i))
            seqer.AppendChild(xmedia)
        Next

        'seqの追加
        bodier.AppendChild(seqer)

        'ヘッダーとボディーの追加
        xRoot.AppendChild(header)
        xRoot.AppendChild(bodier)

        '宣言の追加
        xDocument.AppendChild(xDeclaration)
        'smilの追加
        xDocument.AppendChild(xRoot)

        xDocument.Save(savepath)

        xDeclaration = Nothing
        xRoot = Nothing
        xDocument = Nothing

        Return 0
    End Function

    Public Function WPLLoad(ByVal wplpath As String, ByRef returnmedia As ArrayList) As Integer
        Dim xDocument As XmlDocument = New XmlDocument
        Dim xRoot As XmlElement
        Dim xDataList As XmlNodeList
        Dim xMediaList As XmlNodeList

        Dim media As New ArrayList

        Try
            xDocument.Load(wplpath)

            xRoot = xDocument.DocumentElement

            xDataList = xRoot.GetElementsByTagName("body")
            For Each xElement As XmlElement In xDataList
                xMediaList = xElement.GetElementsByTagName("media")
                For Each xMedia As XmlElement In xMediaList
                    media.Add(xMedia.SelectSingleNode("@src").Value)
                Next xMedia
            Next xElement
            returnmedia = media

            Return 0
        Catch SIFNFE As System.IO.FileNotFoundException
            Return 2
        Catch ex As Exception
            Return 1
        End Try
    End Function
End Class
