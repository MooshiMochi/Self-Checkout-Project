Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Web.Script.Serialization


Public Class PersonalDetails


    Dim previousPage As Form = Nothing
    Dim data As Dictionary(Of String, Object) = Nothing

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim email As String = data("email")
        Dim password As String = data("password")
        Dim confirmPassword As String = data("passwordConfirm")
        Dim name As String = txtName.Text
        Dim surname As String = txtSurname.Text
        Dim DoB As Date = DoBTimePicker.Value

        If Not Regex.IsMatch(email, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$") Then
            MessageBox.Show("The email you entered is not valid." & vbNewLine & "Please enter a valid email address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        ElseIf password = confirmPassword And password <> "" And confirmPassword <> "" Then

            Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/register")

            Dim data As String = "{""email"":""" & email & """,""password"":""" & password & """,""firstName"":""" & name & """,""lastName"":""" & surname & """,""DoB"":""" & DoB & """}"

            Dim requestProxy As New Request()
            requestProxy.MakeRequest(request, "POST", "application/json", data, AddressOf SignUpCallback)

        Else
            MessageBox.Show("Password does not match")
        End If

    End Sub

    Private Function CodeScannedCallback()
        Me.Close()
        Dim loginForm As New Login(New Main())
        loginForm.Show()
        Return Nothing
    End Function

    Private Function MakeAuthenticatorRequest(username As String)

        Dim params As String = "?username=" & username

        Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/get_authenticator_secret" & params)

        Dim requestProxy As New Request()
        requestProxy.MakeRequest(request, "GET", "application/json", Nothing, AddressOf MakeAuthenticatorCallback)
        Return Nothing
    End Function


    Private Function MakeAuthenticatorCallback(response As String)

        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") = False Then
            MessageBox.Show(responseObj("message"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim ViewBox As New ViewPictureBox(responseObj("qr_code"), AddressOf CodeScannedCallback)
            ViewBox.Show()
        End If

        Return Nothing

    End Function


    Private Function SignUpCallback(response As String)

        Dim jss As New JavaScriptSerializer()
        Dim responseDict As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(response)

        If responseDict("status") = "success" Then

            MessageBox.Show("Please scan the following QR code with your authenticator app!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            MakeAuthenticatorRequest(data("email"))

        Else
            MessageBox.Show("The email you entered is already in use!")
        End If
        Return Nothing
    End Function

    Private Sub TxtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtName.KeyPress, txtSurname.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnSignUp.PerformClick()
        End If
    End Sub

    Public Sub New(previousPage As Form, data As Dictionary(Of String, Object))
        InitializeComponent()
        Me.previousPage = previousPage
        Me.data = data
        previousPage.Hide()
    End Sub

    Private Sub BTNBack_Click(sender As Object, e As EventArgs) Handles BTNBack.Click
        Hide()
        previousPage.Show()
    End Sub

End Class