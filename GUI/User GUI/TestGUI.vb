Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Public Class TestGUI
    Dim TestNum As Integer = 0
    Dim verified As Integer = -1
    Dim LastClickedTestButton As Button = Nothing
    Dim customerID As Integer = Nothing
    Private Sub BtnTest_Click(sender As Object, e As EventArgs) Handles BtnTest1.Click, BtnTest2.Click
        ' if the BtnTest1 is clicked, set TestNum to 1
        ' if the BtnTest2 is clicked, set TestNum to 2

        Dim sender_string As String = sender.ToString()
        TestNum = CInt(sender_string.Substring(sender_string.Length - 1)) - 1

        LastClickedTestButton = sender

        Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/load_test_data?test_num=" & TestNum & "&verified=" & verified)  ' 18+ data --> Adult
        Dim requestProxy As New Request()
        requestProxy.MakeRequest(request, "GET", "application/json", Nothing, AddressOf GetImageCallback)
    End Sub

    Private Function GetImageCallback(ByVal response As String)
        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") Then
            Dim qr_image_string As String = responseObj("qr_picture")
            Dim id_image_string As String = responseObj("id_picture")
            Dim cam_image_string As String = responseObj("cam_picture")

            If qr_image_string IsNot Nothing Then
                Dim pictureBytes As Byte() = Convert.FromBase64String(qr_image_string)
                Dim pictureStream As New MemoryStream(pictureBytes)

                pbDisplayQR.Image = Image.FromStream(pictureStream)
                pbDisplayQR.Update()
            End If

            If id_image_string IsNot Nothing Then
                Dim pictureBytes As Byte() = Convert.FromBase64String(id_image_string)
                Dim pictureStream As New MemoryStream(pictureBytes)

                pbDisplayID.Image = Image.FromStream(pictureStream)
                pbDisplayID.Update()
            End If

            If cam_image_string IsNot Nothing Then
                Dim pictureBytes As Byte() = Convert.FromBase64String(cam_image_string)
                Dim pictureStream As New MemoryStream(pictureBytes)

                pbDisplayCam.Image = Image.FromStream(pictureStream)
                pbDisplayCam.Update()
            End If
        Else
            ' in reality this will never fail as the API only returns a 200 status response.
            MessageBox.Show(responseObj("message"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return Nothing

    End Function

    Private Sub btnTestStart_Click(sender As Object, e As EventArgs) Handles btnTestStart.Click

        If txtAgeReq.Text = "" Then
            txtAgeReq.Text = "18"
        End If

        ' check if any of the picture boxes don't have an image. If they don't alert the user that they need to laod the test data first
        If pbDisplayQR.Image Is Nothing Or pbDisplayID.Image Is Nothing Or pbDisplayCam.Image Is Nothing Then
            MessageBox.Show("Please load the test data first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' convert the images to base64 strings
        Dim qr_image_string As String = Convert.ToBase64String(Constants.ImageToByte(pbDisplayQR.Image))
        Dim cam_image_string As String = Convert.ToBase64String(Constants.ImageToByte(pbDisplayCam.Image))

        Dim readQRRequest As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/read_qr")

        Dim requestProxy As New Request()

        ' these are the params that need to be added:
        ' b64_cam_img
        ' b64_qr_code
        Dim checkAgeData As String = "{""b64_cam_img"":""" & cam_image_string & """}"
        Dim readQRData As String = "{""b64_qr_code"":""" & qr_image_string & """}"

        requestProxy.MakeRequest(readQRRequest, "POST", "application/json", readQRData, AddressOf ReadQRCallback)
        If customerID <> Nothing Then
            Dim checkAgeRequest As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/check_age?customer_id=" & customerID)
            requestProxy.MakeRequest(checkAgeRequest, "POST", "application/json", checkAgeData, AddressOf CheckAgeCallback)
        End If
    End Sub


    Private Function ReadQRCallback(ByVal response As String)
        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") Then
            If responseObj.ContainsKey("customer_id") Then
                customerID = CInt(responseObj("customer_id"))
            End If
        Else
            ' in reality this will never fail as the API only returns a 200 status response.
            MessageBox.Show(responseObj("message"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return Nothing
    End Function


    ' a callback function that will take 1 parameter (the response from the API) as string
    ' it will deserealize the string into a dict object with the jss serealizer
    ' then it will check if the success key is true. If it isn't, alert the user that there was an error in the API.
    ' if it is True, check that the age key is not null. If it is, alert the user that the age could not be determined.
    ' if the age key is not null, check that the age is >= the age required. If it is, alert the user that they are old enough.
    ' if the age is not >= the age required, alert the user that they are not old enough.

    Private Function CheckAgeCallback(ByVal response As String)
        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") Then
            If responseObj("age") IsNot Nothing Then
                If CInt(responseObj("age")) >= CInt(txtAgeReq.Text) Then
                    MessageBox.Show("You are old enough.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("You are not old enough.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Could not determine age.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            ' in reality this will never fail as the API only returns a 200 status response.
            MessageBox.Show(responseObj("message"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        Return Nothing
    End Function

    Private Sub txtAgeReq_TextChanged(sender As Object, e As EventArgs) Handles txtAgeReq.TextChanged
        If txtAgeReq.Text <> "" Then
            ' check if any of the characters in the textbox are not numbers. If they are, remove them.
            For Each c As Char In txtAgeReq.Text
                If Not Char.IsNumber(c) Then
                    txtAgeReq.Text = txtAgeReq.Text.Replace(c, "")
                End If
            Next
        End If
    End Sub

    Private Sub CheckoutMachineGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Width += 90
        Me.Height += 20
    End Sub

    Private Sub BTNVerifyAcc_Click(sender As Object, e As EventArgs) Handles BTNVerifyAcc.Click
        verified = 1
        LastClickedTestButton?.PerformClick()
    End Sub

    Private Sub BTNUnverifyAcc_Click(sender As Object, e As EventArgs) Handles BTNUnverifyAcc.Click
        verified = 0
        LastClickedTestButton?.PerformClick()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        verified = -1
        TestNum = 0
        pbDisplayQR.Image = Nothing
        pbDisplayCam.Image = Nothing
        pbDisplayID.Image = Nothing
        txtAgeReq.Text = "18"
        LastClickedTestButton = Nothing
        customerID = Nothing
    End Sub

    Private Sub pbDisplayX_Click(sender As Object, e As EventArgs) Handles pbDisplayQR.Click, pbDisplayCam.Click, pbDisplayID.Click
        If sender.Image IsNot Nothing Then
            Dim ms As New MemoryStream()
            sender.Image.Save(ms, sender.Image.RawFormat)
            Dim b64Image As String = Convert.ToBase64String(ms.ToArray())

            Dim ViewBox As New ViewPictureBox(b64Image, Nothing)
            ViewBox.Show()
        End If
    End Sub

    Private Sub BtnTestCheckoutUI_Click(sender As Object, e As EventArgs) Handles BtnTestCheckoutUI.Click
        If txtAgeReq.Text = "" Then
            txtAgeReq.Text = "18"
        End If
        Dim checkoutUI As New CheckOutMachineUI(CInt(txtAgeReq.Text))
        checkoutUI.Show()

    End Sub
End Class