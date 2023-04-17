Imports System.IO

Public Class ViewPictureBox

    Dim OkCallback As Action = Nothing

    Public Sub New(ByVal base64String As String, callback As Action)

        InitializeComponent()

        OkCallback = callback

        Dim pictureBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(pictureBytes)
        pbDefault.Image = Image.FromStream(ms)

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        If OkCallback <> Nothing Then
            OkCallback()
        End If
        Close()
    End Sub

End Class