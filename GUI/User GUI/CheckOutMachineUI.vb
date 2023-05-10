Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.Net
Imports System.Web.Script.Serialization

Public Class CheckOutMachineUI


    Dim CAMARA As VideoCaptureDevice
    ReadOnly productAgeRequirement As Integer = 18

    Dim customer_id As Integer = Nothing

    Public Sub New(productRequiredAge As Integer)
        InitializeComponent()
        Me.productAgeRequirement = productRequiredAge
    End Sub

    Private Sub ScanFace_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        Try
            CAMARA.Stop()
        Catch ex As Exception
            Me.Dispose()
        End Try
    End Sub

    Private Sub ScanFace_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height += 60

        Dim CAMARAS As New VideoCaptureDeviceForm()
        If CAMARAS.ShowDialog() = DialogResult.OK Then
            CAMARA = CAMARAS.VideoDevice
            AddHandler CAMARA.NewFrame, New NewFrameEventHandler(AddressOf CAPTURAR)
            CAMARA.Start()
        Else
            Me.Close()
        End If

    End Sub

    Private Sub CAPTURAR(sender As Object, eventArgs As NewFrameEventArgs)
        Dim BMP As Bitmap = DirectCast(eventArgs.Frame.Clone(), Bitmap)
        pbCaptureImage.Image = DirectCast(eventArgs.Frame.Clone(), Bitmap)

    End Sub

    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles BtnScan.Click
        CAMARA.Stop()

        Dim image As Bitmap = pbCaptureImage.Image
        Dim imageBytes As Byte() = Constants.ImageToByte(image)
        Dim imageString As String = Convert.ToBase64String(imageBytes)
        Dim requestProxy As New Request()
        Dim request As HttpWebRequest = Nothing
        Dim data As String
        If customer_id = Nothing Then

            request = WebRequest.Create(Constants.BASE_API_URL & "/read_qr")
            data = "{""b64_qr_code"":""" & imageString & """}"
            requestProxy.MakeRequest(request, "POST", "application/json", data, AddressOf QRCodeCallback)
        Else

            request = WebRequest.Create(Constants.BASE_API_URL & "/check_age?customer_id=" & customer_id)
            data = "{""b64_cam_img"":""" & imageString & """}"
            requestProxy.MakeRequest(request, "POST", "application/json", data, AddressOf CheckAgeCallback)
        End If

        CAMARA.Start()

    End Sub

    Private Function QRCodeCallback(ByVal response As String)
        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") Then
            ' if the "customer_id" key is not present, alert the user that they need to scan the QR code first

            If responseObj.ContainsKey("customer_id") Then
                customer_id = CInt(responseObj("customer_id"))
                lblDesc.Text = "Please face the camera and press 'Scan' to scan your face!"

                Dim location As Point = lblDesc.Location
                location.X += 15
                lblDesc.Location = location

                MessageBox.Show("Customer ID: " & customer_id & vbNewLine & "Please scan your face now!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please scan the QR code first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Please scan the QR code first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return Nothing
    End Function

    Private Function CheckAgeCallback(ByVal response As String)
        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") Then
            If responseObj("age") IsNot Nothing Then
                If CInt(responseObj("age")) >= productAgeRequirement Then
                    MessageBox.Show("You are old enough.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
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

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        Me.Close()
    End Sub
End Class