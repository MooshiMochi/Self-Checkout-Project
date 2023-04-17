<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
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
        Me.pbQR = New System.Windows.Forms.PictureBox()
        Me.pbID = New System.Windows.Forms.PictureBox()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.BtnLogOut = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblPersonalDetails = New System.Windows.Forms.Label()
        Me.GroupPersonalDetailsBG = New System.Windows.Forms.PictureBox()
        Me.GroupPersonalDetails = New System.Windows.Forms.PictureBox()
        Me.selectPictureDialog = New System.Windows.Forms.OpenFileDialog()
        Me.lblSelectedFile = New System.Windows.Forms.Label()
        Me.lblPDName = New System.Windows.Forms.Label()
        Me.lblPDDoB = New System.Windows.Forms.Label()
        Me.lblCustomerID = New System.Windows.Forms.Label()
        Me.BtnSetupAuthenticator = New System.Windows.Forms.Button()
        Me.BTNBack = New System.Windows.Forms.Button()
        CType(Me.pbQR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupPersonalDetailsBG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupPersonalDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbQR
        '
        Me.pbQR.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pbQR.Location = New System.Drawing.Point(497, 232)
        Me.pbQR.Margin = New System.Windows.Forms.Padding(2)
        Me.pbQR.Name = "pbQR"
        Me.pbQR.Size = New System.Drawing.Size(166, 173)
        Me.pbQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbQR.TabIndex = 0
        Me.pbQR.TabStop = False
        '
        'pbID
        '
        Me.pbID.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pbID.Location = New System.Drawing.Point(29, 232)
        Me.pbID.Margin = New System.Windows.Forms.Padding(2)
        Me.pbID.Name = "pbID"
        Me.pbID.Size = New System.Drawing.Size(166, 173)
        Me.pbID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbID.TabIndex = 1
        Me.pbID.TabStop = False
        Me.pbID.WaitOnLoad = True
        '
        'BtnUpload
        '
        Me.BtnUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnUpload.FlatAppearance.BorderSize = 8
        Me.BtnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpload.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnUpload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnUpload.Location = New System.Drawing.Point(228, 332)
        Me.BtnUpload.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(120, 38)
        Me.BtnUpload.TabIndex = 5
        Me.BtnUpload.Text = "Upload"
        Me.BtnUpload.UseVisualStyleBackColor = False
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnSelect.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnSelect.FlatAppearance.BorderSize = 8
        Me.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelect.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnSelect.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnSelect.Location = New System.Drawing.Point(228, 263)
        Me.BtnSelect.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(120, 38)
        Me.BtnSelect.TabIndex = 6
        Me.BtnSelect.Text = "Select an Image"
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'BtnLogOut
        '
        Me.BtnLogOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnLogOut.FlatAppearance.BorderSize = 8
        Me.BtnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogOut.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnLogOut.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnLogOut.Location = New System.Drawing.Point(497, 92)
        Me.BtnLogOut.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnLogOut.Name = "BtnLogOut"
        Me.BtnLogOut.Size = New System.Drawing.Size(166, 40)
        Me.BtnLogOut.TabIndex = 7
        Me.BtnLogOut.Text = "Log Out"
        Me.BtnLogOut.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans", 7.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Gold
        Me.Label1.Location = New System.Drawing.Point(26, 435)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(658, 14)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "If your personal details or home address are not filled then it is likely that yo" &
    "ur ID is not suppoted or the picture is blurry."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Lucida Sans", 7.875!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gold
        Me.Label2.Location = New System.Drawing.Point(220, 448)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(247, 14)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Please re-upload a clearer picture of your ID."
        '
        'lblPersonalDetails
        '
        Me.lblPersonalDetails.AutoSize = True
        Me.lblPersonalDetails.Font = New System.Drawing.Font("Lucida Sans", 13.875!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonalDetails.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblPersonalDetails.Location = New System.Drawing.Point(20, 13)
        Me.lblPersonalDetails.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPersonalDetails.Name = "lblPersonalDetails"
        Me.lblPersonalDetails.Size = New System.Drawing.Size(160, 22)
        Me.lblPersonalDetails.TabIndex = 10
        Me.lblPersonalDetails.Text = "Personal Details"
        '
        'GroupPersonalDetailsBG
        '
        Me.GroupPersonalDetailsBG.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.GroupPersonalDetailsBG.Location = New System.Drawing.Point(24, 41)
        Me.GroupPersonalDetailsBG.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupPersonalDetailsBG.Name = "GroupPersonalDetailsBG"
        Me.GroupPersonalDetailsBG.Size = New System.Drawing.Size(324, 146)
        Me.GroupPersonalDetailsBG.TabIndex = 13
        Me.GroupPersonalDetailsBG.TabStop = False
        '
        'GroupPersonalDetails
        '
        Me.GroupPersonalDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.GroupPersonalDetails.Location = New System.Drawing.Point(29, 46)
        Me.GroupPersonalDetails.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupPersonalDetails.Name = "GroupPersonalDetails"
        Me.GroupPersonalDetails.Size = New System.Drawing.Size(314, 135)
        Me.GroupPersonalDetails.TabIndex = 14
        Me.GroupPersonalDetails.TabStop = False
        '
        'selectPictureDialog
        '
        Me.selectPictureDialog.FileName = "unknown"
        Me.selectPictureDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png"
        Me.selectPictureDialog.Title = "Select Picture"
        '
        'lblSelectedFile
        '
        Me.lblSelectedFile.AutoSize = True
        Me.lblSelectedFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblSelectedFile.Location = New System.Drawing.Point(230, 302)
        Me.lblSelectedFile.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblSelectedFile.Name = "lblSelectedFile"
        Me.lblSelectedFile.Size = New System.Drawing.Size(55, 13)
        Me.lblSelectedFile.TabIndex = 16
        Me.lblSelectedFile.Text = "Selected: "
        Me.lblSelectedFile.Visible = False
        '
        'lblPDName
        '
        Me.lblPDName.AutoSize = True
        Me.lblPDName.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.lblPDName.Font = New System.Drawing.Font("Lucida Sans", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPDName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.lblPDName.Location = New System.Drawing.Point(35, 71)
        Me.lblPDName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPDName.Name = "lblPDName"
        Me.lblPDName.Size = New System.Drawing.Size(51, 16)
        Me.lblPDName.TabIndex = 17
        Me.lblPDName.Text = "Name:"
        '
        'lblPDDoB
        '
        Me.lblPDDoB.AutoSize = True
        Me.lblPDDoB.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.lblPDDoB.Font = New System.Drawing.Font("Lucida Sans", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPDDoB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.lblPDDoB.Location = New System.Drawing.Point(35, 103)
        Me.lblPDDoB.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblPDDoB.Name = "lblPDDoB"
        Me.lblPDDoB.Size = New System.Drawing.Size(106, 16)
        Me.lblPDDoB.TabIndex = 18
        Me.lblPDDoB.Text = "Date of Birth:"
        '
        'lblCustomerID
        '
        Me.lblCustomerID.AutoSize = True
        Me.lblCustomerID.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.lblCustomerID.Font = New System.Drawing.Font("Lucida Sans", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCustomerID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.lblCustomerID.Location = New System.Drawing.Point(35, 136)
        Me.lblCustomerID.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(102, 16)
        Me.lblCustomerID.TabIndex = 19
        Me.lblCustomerID.Text = "Customer ID:"
        '
        'BtnSetupAuthenticator
        '
        Me.BtnSetupAuthenticator.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnSetupAuthenticator.FlatAppearance.BorderSize = 8
        Me.BtnSetupAuthenticator.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSetupAuthenticator.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnSetupAuthenticator.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnSetupAuthenticator.Location = New System.Drawing.Point(497, 136)
        Me.BtnSetupAuthenticator.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnSetupAuthenticator.Name = "BtnSetupAuthenticator"
        Me.BtnSetupAuthenticator.Size = New System.Drawing.Size(166, 40)
        Me.BtnSetupAuthenticator.TabIndex = 24
        Me.BtnSetupAuthenticator.Text = "Setup Authenticator"
        Me.BtnSetupAuthenticator.UseVisualStyleBackColor = False
        '
        'BTNBack
        '
        Me.BTNBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BTNBack.FlatAppearance.BorderSize = 8
        Me.BTNBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNBack.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BTNBack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BTNBack.Location = New System.Drawing.Point(497, 48)
        Me.BTNBack.Margin = New System.Windows.Forms.Padding(2)
        Me.BTNBack.Name = "BTNBack"
        Me.BTNBack.Size = New System.Drawing.Size(166, 40)
        Me.BTNBack.TabIndex = 26
        Me.BTNBack.Text = "< Back"
        Me.BTNBack.UseVisualStyleBackColor = False
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(742, 487)
        Me.Controls.Add(Me.BTNBack)
        Me.Controls.Add(Me.BtnSetupAuthenticator)
        Me.Controls.Add(Me.lblCustomerID)
        Me.Controls.Add(Me.lblPDDoB)
        Me.Controls.Add(Me.lblPDName)
        Me.Controls.Add(Me.lblSelectedFile)
        Me.Controls.Add(Me.GroupPersonalDetails)
        Me.Controls.Add(Me.GroupPersonalDetailsBG)
        Me.Controls.Add(Me.lblPersonalDetails)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnLogOut)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.BtnUpload)
        Me.Controls.Add(Me.pbID)
        Me.Controls.Add(Me.pbQR)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Home"
        Me.Text = "Home"
        CType(Me.pbQR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupPersonalDetailsBG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupPersonalDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbQR As PictureBox
    Friend WithEvents pbID As PictureBox
    Friend WithEvents BtnUpload As Button
    Friend WithEvents BtnSelect As Button
    Friend WithEvents BtnLogOut As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPersonalDetails As Label
    Friend WithEvents GroupPersonalDetailsBG As PictureBox
    Friend WithEvents GroupPersonalDetails As PictureBox
    Friend WithEvents selectPictureDialog As OpenFileDialog
    Friend WithEvents lblSelectedFile As Label
    Friend WithEvents lblPDName As Label
    Friend WithEvents lblPDDoB As Label
    Friend WithEvents lblCustomerID As Label
    Friend WithEvents BtnSetupAuthenticator As Button
    Friend WithEvents BTNBack As Button
End Class
