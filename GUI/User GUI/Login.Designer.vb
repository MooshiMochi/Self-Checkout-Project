<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblCustomerLogin = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblErrUsername = New System.Windows.Forms.Label()
        Me.lblErrPassword = New System.Windows.Forms.Label()
        Me.lblForgotPass = New System.Windows.Forms.Label()
        Me.BTNBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblCustomerLogin
        '
        Me.lblCustomerLogin.AutoSize = True
        Me.lblCustomerLogin.Font = New System.Drawing.Font("Lucida Sans", 36.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCustomerLogin.Location = New System.Drawing.Point(347, 43)
        Me.lblCustomerLogin.Name = "lblCustomerLogin"
        Me.lblCustomerLogin.Size = New System.Drawing.Size(779, 109)
        Me.lblCustomerLogin.TabIndex = 4
        Me.lblCustomerLogin.Text = "Customer Login"
        '
        'btnLogin
        '
        Me.btnLogin.AutoSize = True
        Me.btnLogin.BackColor = System.Drawing.Color.Transparent
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnLogin.FlatAppearance.BorderSize = 10
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Lucida Sans", 16.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnLogin.Location = New System.Drawing.Point(547, 607)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(328, 113)
        Me.btnLogin.TabIndex = 9
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'txtUsername
        '
        Me.txtUsername.Font = New System.Drawing.Font("Lucida Sans", 12.0!)
        Me.txtUsername.Location = New System.Drawing.Point(455, 232)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(523, 45)
        Me.txtUsername.TabIndex = 10
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(455, 433)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(523, 45)
        Me.txtPassword.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(448, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 37)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Username"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Sans", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(448, 393)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 37)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Password"
        '
        'lblErrUsername
        '
        Me.lblErrUsername.AutoSize = True
        Me.lblErrUsername.Font = New System.Drawing.Font("Lucida Sans", 10.125!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrUsername.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblErrUsername.Location = New System.Drawing.Point(585, 293)
        Me.lblErrUsername.Name = "lblErrUsername"
        Me.lblErrUsername.Size = New System.Drawing.Size(226, 32)
        Me.lblErrUsername.TabIndex = 15
        Me.lblErrUsername.Text = "⚠️ Invalid Email"
        Me.lblErrUsername.Visible = False
        '
        'lblErrPassword
        '
        Me.lblErrPassword.AutoSize = True
        Me.lblErrPassword.Font = New System.Drawing.Font("Lucida Sans", 10.125!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrPassword.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblErrPassword.Location = New System.Drawing.Point(391, 492)
        Me.lblErrPassword.Name = "lblErrPassword"
        Me.lblErrPassword.Size = New System.Drawing.Size(639, 32)
        Me.lblErrPassword.TabIndex = 16
        Me.lblErrPassword.Text = "⚠️ Password must be at least 6 characters long"
        Me.lblErrPassword.Visible = False
        '
        'lblForgotPass
        '
        Me.lblForgotPass.AutoSize = True
        Me.lblForgotPass.Font = New System.Drawing.Font("Lucida Sans", 10.125!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForgotPass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblForgotPass.Location = New System.Drawing.Point(585, 750)
        Me.lblForgotPass.Name = "lblForgotPass"
        Me.lblForgotPass.Size = New System.Drawing.Size(244, 32)
        Me.lblForgotPass.TabIndex = 17
        Me.lblForgotPass.Text = "Forgot Password?"
        '
        'BTNBack
        '
        Me.BTNBack.AutoSize = True
        Me.BTNBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BTNBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.BTNBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BTNBack.FlatAppearance.BorderSize = 10
        Me.BTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNBack.Font = New System.Drawing.Font("Lucida Sans", 12.0!)
        Me.BTNBack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BTNBack.Location = New System.Drawing.Point(1199, 12)
        Me.BTNBack.Name = "BTNBack"
        Me.BTNBack.Size = New System.Drawing.Size(187, 67)
        Me.BTNBack.TabIndex = 18
        Me.BTNBack.Text = "< Back"
        Me.BTNBack.UseVisualStyleBackColor = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1398, 815)
        Me.Controls.Add(Me.BTNBack)
        Me.Controls.Add(Me.lblForgotPass)
        Me.Controls.Add(Me.lblErrPassword)
        Me.Controls.Add(Me.lblErrUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.lblCustomerLogin)
        Me.Name = "Login"
        Me.Text = "Login"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblCustomerLogin As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblErrUsername As Label
    Friend WithEvents lblErrPassword As Label
    Friend WithEvents lblForgotPass As Label
    Friend WithEvents BTNBack As Button
End Class
