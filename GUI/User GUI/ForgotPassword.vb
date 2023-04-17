Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Web.Script.Serialization

Public Class ForgotPassword

    Dim previousPage As Form = Nothing

    Dim page As Integer = 0
    Dim enteredEmail As String
    Dim codeAttemptsLeft As Integer = 3

    Private Sub SubmitEmailCheck(ByRef page As Integer)
        If txtInput.Text = "" Then
            lblErrInput.Text = "⚠️ Please enter your email address."
            lblErrInput.Show()

        Else
            If Regex.IsMatch(txtInput.Text, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$") Then
                enteredEmail = txtInput.Text
                lblErrInput.Hide()
                page = 1
                lblInstruction.Text = "We've found the email ... linked to your account"
                lblInstruction.Text += vbNewLine + "Please enter the verification code from your authenticator app"
                txtInput.Text = ""

                Dim location As Point = txtInput.Location
                location.Y += 15
                txtInput.Location = location

            End If
        End If
    End Sub

    Private Sub SubmitCodeCheck(ByRef page As Integer)
        If txtInput.Text = "" Then
            lblErrInput.Text = "⚠️ Please enter the verification code!"
            lblErrInput.Show()
            Return
        End If

        If codeAttemptsLeft <= 0 Then
            lblErrInput.Text = "⚠️ You have exceeded the maximum number of attempts."
            lblErrInput.Show()
            Return
        End If

        CheckVerificationCode(enteredEmail.ToLower(), CInt(txtInput.Text))
    End Sub

    Private Sub SubmitNewPasswordCheck()

        If txtInput.Text = "" Then
            lblErrInput.Text = "⚠️ Please enter your new password."
            lblErrInput.Show()
            Return
        ElseIf txtInput.Text.Length < 6 Then
            lblErrInput.Text = "⚠️ Password must be at least 6 characters."
            lblErrInput.Show()
            Return

        ElseIf txtPassConfirm.Text = "" Then
            lblErrInput.Text = "⚠️ Please confirm your new password."
            lblErrInput.Show()
            Return

        ElseIf txtInput.Text <> txtPassConfirm.Text Then
            lblErrInput.Text = "⚠️ Passwords do not match."
            lblErrInput.Show()
            Return

        Else
            Dim RequestProxy As New Request()

            Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/renew-pass")
            Dim data As String = "{""email"":""" & enteredEmail & """,""password"":""" & txtInput.Text & """}"

            RequestProxy.MakeRequest(request, "POST", "application/json", data, AddressOf PasswordResetRequestCallback)

        End If

    End Sub


    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If page = 0 Then
            SubmitEmailCheck(page)
        ElseIf page = 1 Then
            SubmitCodeCheck(page)
        ElseIf page = 2 Then
            SubmitNewPasswordCheck()
        End If
    End Sub

    Private Sub CheckVerificationCode(username As String, code As Integer)

        Dim parameters As String = "?username=" & username & "&code=" & code

        Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/verify-code" & parameters)
        Dim RequestProxy As New Request()

        RequestProxy.MakeRequest(request, "GET", "application/json", Nothing, AddressOf CheckVerificationCodeCallback)
    End Sub

    Private Sub CheckVerificationCodeCallback(response As String)
        Dim jss As New JavaScriptSerializer()
        Dim responseObj As Object = jss.Deserialize(Of Object)(response)

        If responseObj("success") = True And responseObj("code_valid") = True Then
            page = 2
            lblInstruction.Text = "Please enter your new password"
            lblInstruction.Text += vbNewLine + "Password must be at least 6 characters long"

            txtInput.Text = ""
            txtInput.PasswordChar = "*"

            txtPassConfirm.Text = ""
            txtPassConfirm.Show()

            lblErrPassConfirm.Hide()
            lblErrInput.Hide()

            codeAttemptsLeft = 3

            btnNext.Location = New Point(52, 340)
            lblReEnterPass.Show()
            txtPassConfirm.Show()
        Else
            codeAttemptsLeft -= 1
            lblErrInput.Text = "⚠️ Invalid code! You have " & codeAttemptsLeft & " attempts left."
            lblErrInput.Show()
        End If
    End Sub


    Private Function PasswordResetRequestCallback(response As String)

        Dim jss As New JavaScriptSerializer()
        Dim dict As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(response)

        If dict("success") Then
            MessageBox.Show("Password successfully changed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Hide()
            Dim login As New Login(Me)
            login.Show()
        Else
            MessageBox.Show("An API error occurred while trying to change your password. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End If

        Return dict("success")

    End Function

    Private Sub TxtInput_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInput.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            btnNext.PerformClick()
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

    Private Sub ThisForm_unload(sender As Object, e As EventArgs) Handles MyBase.Closed
        If Me.previousPage IsNot Nothing Then
            Me.previousPage.Close()
        End If
    End Sub

    Private Sub txtInput_TextChanged(sender As Object, e As EventArgs) Handles txtInput.TextChanged
        If page = 1 Then
            If Not Regex.IsMatch(txtInput.Text, "^[0-9]+$") Then
                txtInput.Text = Regex.Replace(txtInput.Text, "[^0-9]", "")
            End If
        End If
    End Sub
End Class