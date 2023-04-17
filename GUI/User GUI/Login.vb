Imports System.Net
Imports System.Web.Script.Serialization

Public Class Login

    Dim previousPage As Form = Nothing

    Dim username As String
    Dim password As String

    Private Sub TxtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged
        If txtUsername.Text = "" Then
            lblErrUsername.Show()
        Else
            lblErrUsername.Hide()
        End If
    End Sub

    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text = "" Then
            lblErrPassword.Show()
        Else
            lblErrPassword.Hide()
        End If
    End Sub



    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        username = txtUsername.Text.ToLower()
        password = txtPassword.Text.ToLower()

        If username = "" Or password = "" Then
            lblErrUsername.Show()
            lblErrPassword.Show()
            Return
        End If

        Dim RequestProxy As New Request()
        Dim data As String = "{""username"":""" & username & """,""password"":""" & password & """}"
        Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/login")
        RequestProxy.MakeRequest(request, "POST", "application/json", data, AddressOf LoginRequestCallback)

    End Sub

    Private Sub LblForgotPass_Click(sender As Object, e As EventArgs) Handles lblForgotPass.Click
        Me.Hide()
        Dim forgotPasswordForm As New ForgotPassword(Me)
        forgotPasswordForm.Show()
    End Sub

    Private Function LoginRequestCallback(ByVal response As String) As Dictionary(Of String, String)
        ' parse the response string to a dict
        Dim jss As New JavaScriptSerializer()
        Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(response)

        If dict.Item("success") = True Then
            Me.Hide()
            Dim home As New Home(username, dict("customerID"), Me)
            home.Show()
        Else
            MsgBox("Login unsuccessful")
        End If
        Return dict
    End Function


    Private Sub TxtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsername.KeyPress, txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnLogin.PerformClick()
        End If
    End Sub

    Public Sub New(previousPage As Form)
        InitializeComponent()
        Me.previousPage = previousPage
        previousPage.Hide()
    End Sub

    Private Sub BTNBack_Click(sender As Object, e As EventArgs) Handles BTNBack.Click
        Hide()
        previousPage.Show()
    End Sub


End Class