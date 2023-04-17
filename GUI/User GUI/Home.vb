Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Public Class Home
    Private ReadOnly Username As String
    Private ReadOnly CustomerID As String

    Dim previousPage As Form = Nothing

    Dim selectedPicture As String
    Dim selectedPictureExt As String
    Dim SelectedPictureName As String

    Public Sub New(username As String, customerID As String, previousPage As Form)
        InitializeComponent()
        Me.Username = username
        Me.CustomerID = customerID
        Me.previousPage = previousPage
        previousPage.Hide()
    End Sub

    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/load?username=" & Me.Username)
        Dim requestProxy As New Request()
        requestProxy.MakeRequest(request, "GET", "application/json", Nothing, AddressOf LoadCallback)

        request = WebRequest.Create(Constants.BASE_API_URL & "/make_qr?data=" & Me.CustomerID)
        requestProxy.MakeRequest(request, "GET", "application/json", Nothing, AddressOf CustomerQRCallback)

    End Sub

    Private Sub LoadCallback(ByVal response As String)

        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") = True Then
            Dim documentPicture As String = responseObj("document")

            If documentPicture IsNot Nothing Then
                LoadImage(pbID, documentPicture)
            End If

            Dim firstName As String = responseObj("firstName")
            Dim lastName As String = responseObj("lastName")
            Dim DoB As String = responseObj("DoB")
            Dim verified As Boolean = responseObj("verified")

            lblPDName.Text = "Name: " & firstName & " " & lastName
            lblPDDoB.Text = "Date of Birth: " & DoB
            If verified Then
                lblPDDoB.Text += " (Verified)"
            Else
                lblPDDoB.Text += " (Not Verified)"
            End If
            lblCustomerID.Text = "Customer ID: " & CustomerID

        End If
    End Sub

    Private Sub CustomerQRCallback(response As String)
        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") = True Then
            Dim documentPicture As String = responseObj("qr_code")
            LoadImage(pbQR, documentPicture)
        End If
    End Sub

    Private Sub LoadImage(ByRef pb As PictureBox, ByVal b64Image As String)

        Dim documentPictureBytes As Byte() = Convert.FromBase64String(b64Image)

        ' convert the byte array to a memory stream
        Dim documentPictureStream As New MemoryStream(documentPictureBytes)

        ' set the picture box image to the memory stream
        pb.Image = Image.FromStream(documentPictureStream)
        pb.Update()
    End Sub


    Private Sub BtnLogOut_Click(sender As Object, e As EventArgs) Handles BtnLogOut.Click
        Dim mainForm As New Main()
        mainForm.Show()
        Me.Close()

    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        ' Select the local picture fileDim openFileDialog As New OpenFileDialog()
        If selectPictureDialog.ShowDialog() = DialogResult.OK Then
            selectedPicture = selectPictureDialog.FileName
            ' get the extension of the file
            selectedPictureExt = Path.GetExtension(selectedPicture)

            Dim parts As String() = selectedPicture.Split("\")
            SelectedPictureName = parts(parts.Length - 1)

            lblSelectedFile.Text = "Selected: " & SelectedPictureName
            lblSelectedFile.Visible = True
        End If
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        If selectedPicture Is Nothing Then
            MessageBox.Show("Please select a picture first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Upload the picture to the server

        Dim pictureBytes As Byte() = File.ReadAllBytes(selectedPicture)
        Dim pictureBase64 As String = Convert.ToBase64String(pictureBytes)

        Dim data As String = "{""picture"":""" & pictureBase64 & """,""extension"":""" & selectedPictureExt & """,""filename"":""" & SelectedPictureName & """,""username"":""" & Username & """}"

        Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/upload")

        Dim requestProxy As New Request()
        requestProxy.MakeRequest(request, "POST", "application/json", data, AddressOf UploadImageCallback)


    End Sub

    Private Function UploadImageCallback(ByVal response As String) As Dictionary(Of String, String)
        ' Handle the response from the server
        Dim jss As New JavaScriptSerializer()
        Console.WriteLine("Received response: " & response)
        Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(response)

        If dict("status") = "success" Then
            MessageBox.Show("Image uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Image upload failed!" & vbNewLine & vbNewLine & dict("message"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' call the load function to refresh the picture
        Home_Load(Nothing, Nothing)

        Return dict

    End Function

    Private Sub BtnSetupAuthenticator_Click(sender As Object, e As EventArgs) Handles BtnSetupAuthenticator.Click

        Dim params As String = "?username=" & Me.Username

        Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/get_authenticator_secret" & params)

        Dim requestProxy As New Request()
        requestProxy.MakeRequest(request, "GET", "application/json", Nothing, AddressOf AuthenticatorCallback)

    End Sub

    Private Function AuthenticatorCallback(response As String)

        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") = False Then
            MessageBox.Show(responseObj("message"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim ViewBox As New ViewPictureBox(responseObj("qr_code"), Nothing)
            ViewBox.Show()
        End If

        Return Nothing

    End Function

    Private Sub PbQR_Click(sender As Object, e As EventArgs) Handles pbQR.Click
        ' convert the pbQR image to a base64 string
        If pbQR.Image IsNot Nothing Then
            Dim ms As New MemoryStream()
            pbQR.Image.Save(ms, pbQR.Image.RawFormat)
            Dim b64Image As String = Convert.ToBase64String(ms.ToArray())

            Dim ViewBox As New ViewPictureBox(b64Image, Nothing)
            ViewBox.Show()
        End If

    End Sub


    Private Sub pbID_Click(sender As Object, e As EventArgs) Handles pbID.Click
        If pbID.Image IsNot Nothing Then
            Dim ms As New MemoryStream()
            pbID.Image.Save(ms, pbID.Image.RawFormat)
            Dim b64Image As String = Convert.ToBase64String(ms.ToArray())

            Dim ViewBox As New ViewPictureBox(b64Image, Nothing)
            ViewBox.Show()
        End If
    End Sub


    Private Sub BTNBack_Click(sender As Object, e As EventArgs) Handles BTNBack.Click
        Hide()
        previousPage.Show()
    End Sub


End Class