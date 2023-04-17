
Public Class Main


    Dim APIStatus As Boolean = True
    Dim toggled As Boolean = False
    Dim CheckoutGUI As New TestGUI()
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        APIStatus = New Request().CheckAPIStatus()
        If APIStatus = False Then
            labelAPIOffline.Show()
        End If

        If toggled = False Then

            CheckoutGUI.Show()
            toggled = True
        End If
    End Sub

    Private Sub Main_Unload(sender As Object, e As EventArgs) Handles MyBase.Closed
        CheckoutGUI.Close()
    End Sub

    Private Sub lblForgotPass_Click(sender As Object, e As EventArgs) Handles lblForgotPass.Click

        If Not CheckAPIStatus() Then
            Return
        End If

        Me.Hide()

        Dim forgotPassForm As New ForgotPassword(Me)
        forgotPassForm.Show()

    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click

        If Not CheckAPIStatus() Then
            Return
        End If

        Me.Hide()

        Dim loginForm As New Login(Me)
        loginForm.Show()

    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click

        If Not CheckAPIStatus() Then
            Return
        End If

        Me.Hide()

        Dim signUpForm As New SignUp(Me)
        signUpForm.Show()
    End Sub

    Private Function CheckAPIStatus() As Boolean
        If APIStatus = False Then
            MessageBox.Show("The API is not running. Please try again later.")
            Return False
        End If
        Return True
    End Function

End Class
