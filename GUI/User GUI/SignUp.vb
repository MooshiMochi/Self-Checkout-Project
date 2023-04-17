
Imports System.Text.RegularExpressions
Imports System.Net
Imports System.Web.Script.Serialization

Public Class SignUp

    Dim previousPage As Form = Nothing
    Dim data As New Dictionary(Of String, Object)


    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim email As String = txtEmail.Text
        Dim password As String = txtPassword.Text
        Dim confirmPassword As String = txtPasswordConfirm.Text

        data("email") = email
        data("password") = password
        data("passwordConfirm") = confirmPassword

        If Not Regex.IsMatch(email, "^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$") Then
            MessageBox.Show("The email you entered is not valid." & vbNewLine & "Please enter a valid email address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return

        ElseIf password = confirmPassword And password <> "" And confirmPassword <> "" Then
            ' Check if an account with that username exists
            Dim request As HttpWebRequest = WebRequest.Create(Constants.BASE_API_URL & "/api/users?email=" & email)
            Dim requestProxy As New Request()
            requestProxy.MakeRequest(request, "GET", "application/json", Nothing, AddressOf CheckEmailAvailableCallback)

        Else
            MessageBox.Show("Password does not match")
        End If

    End Sub

    Private Function CheckEmailAvailableCallback(response As String)

        Dim jss As New JavaScriptSerializer()
        Dim responseDict As Dictionary(Of String, Object) = jss.Deserialize(Of Dictionary(Of String, Object))(response)

        If responseDict("status") = "success" And responseDict("exists") = False Then
            Dim nextPage As New PersonalDetails(Me, Me.data)
            Me.Hide()
            nextPage.Show()

        Else
            MessageBox.Show("The email you entered is already in use!")
        End If
        Return Nothing
    End Function

    Private Sub TxtUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEmail.KeyPress, txtPassword.KeyPress, txtPasswordConfirm.KeyPress
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
End Class