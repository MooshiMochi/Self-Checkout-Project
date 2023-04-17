<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PersonalDetails
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
        Me.BTNBack = New System.Windows.Forms.Button()
        Me.lblDoB = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnSignUp = New System.Windows.Forms.Button()
        Me.lblCustomerLogin = New System.Windows.Forms.Label()
        Me.DoBTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'BTNBack
        '
        Me.BTNBack.AutoSize = True
        Me.BTNBack.BackColor = System.Drawing.Color.Transparent
        Me.BTNBack.Cursor = System.Windows.Forms.Cursors.Default
        Me.BTNBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BTNBack.FlatAppearance.BorderSize = 10
        Me.BTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNBack.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BTNBack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BTNBack.Location = New System.Drawing.Point(594, 11)
        Me.BTNBack.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNBack.Name = "BTNBack"
        Me.BTNBack.Size = New System.Drawing.Size(94, 48)
        Me.BTNBack.TabIndex = 35
        Me.BTNBack.Text = "< Back"
        Me.BTNBack.UseVisualStyleBackColor = False
        '
        'lblDoB
        '
        Me.lblDoB.AutoSize = True
        Me.lblDoB.Font = New System.Drawing.Font("Lucida Sans", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDoB.Location = New System.Drawing.Point(300, 277)
        Me.lblDoB.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDoB.Name = "lblDoB"
        Me.lblDoB.Size = New System.Drawing.Size(113, 18)
        Me.lblDoB.TabIndex = 34
        Me.lblDoB.Text = "Date of birth"
        '
        'lblSurname
        '
        Me.lblSurname.AutoSize = True
        Me.lblSurname.Font = New System.Drawing.Font("Lucida Sans", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSurname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblSurname.Location = New System.Drawing.Point(311, 202)
        Me.lblSurname.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(80, 18)
        Me.lblSurname.TabIndex = 32
        Me.lblSurname.Text = "Surname"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Lucida Sans", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblName.Location = New System.Drawing.Point(327, 114)
        Me.lblName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(54, 18)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = "Name"
        '
        'txtSurname
        '
        Me.txtSurname.Font = New System.Drawing.Font("Lucida Sans", 12.0!)
        Me.txtSurname.Location = New System.Drawing.Point(196, 222)
        Me.txtSurname.Margin = New System.Windows.Forms.Padding(2)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(312, 26)
        Me.txtSurname.TabIndex = 30
        Me.txtSurname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(196, 134)
        Me.txtName.Margin = New System.Windows.Forms.Padding(2)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(312, 26)
        Me.txtName.TabIndex = 29
        Me.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSignUp
        '
        Me.btnSignUp.AutoSize = True
        Me.btnSignUp.BackColor = System.Drawing.Color.Transparent
        Me.btnSignUp.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSignUp.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSignUp.FlatAppearance.BorderSize = 10
        Me.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSignUp.Font = New System.Drawing.Font("Lucida Sans", 16.125!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignUp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnSignUp.Location = New System.Drawing.Point(251, 356)
        Me.btnSignUp.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSignUp.Name = "btnSignUp"
        Me.btnSignUp.Size = New System.Drawing.Size(215, 55)
        Me.btnSignUp.TabIndex = 28
        Me.btnSignUp.Text = "Create Account"
        Me.btnSignUp.UseVisualStyleBackColor = False
        '
        'lblCustomerLogin
        '
        Me.lblCustomerLogin.AutoSize = True
        Me.lblCustomerLogin.Font = New System.Drawing.Font("Lucida Sans", 36.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomerLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCustomerLogin.Location = New System.Drawing.Point(155, 36)
        Me.lblCustomerLogin.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCustomerLogin.Name = "lblCustomerLogin"
        Me.lblCustomerLogin.Size = New System.Drawing.Size(381, 55)
        Me.lblCustomerLogin.TabIndex = 27
        Me.lblCustomerLogin.Text = "Create Account"
        '
        'DoBTimePicker
        '
        Me.DoBTimePicker.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DoBTimePicker.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DoBTimePicker.Location = New System.Drawing.Point(197, 298)
        Me.DoBTimePicker.Name = "DoBTimePicker"
        Me.DoBTimePicker.Size = New System.Drawing.Size(312, 20)
        Me.DoBTimePicker.TabIndex = 36
        '
        'PersonalDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(699, 442)
        Me.Controls.Add(Me.DoBTimePicker)
        Me.Controls.Add(Me.BTNBack)
        Me.Controls.Add(Me.lblDoB)
        Me.Controls.Add(Me.lblSurname)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.btnSignUp)
        Me.Controls.Add(Me.lblCustomerLogin)
        Me.Name = "PersonalDetails"
        Me.Text = "PersonalDetails"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BTNBack As Button
    Friend WithEvents lblDoB As Label
    Friend WithEvents lblSurname As Label
    Friend WithEvents lblName As Label
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents btnSignUp As Button
    Friend WithEvents lblCustomerLogin As Label
    Friend WithEvents DoBTimePicker As DateTimePicker
End Class
