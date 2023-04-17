<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TestGUI
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
        Me.BtnTest1 = New System.Windows.Forms.Button()
        Me.pbDisplayQR = New System.Windows.Forms.PictureBox()
        Me.BtnTest2 = New System.Windows.Forms.Button()
        Me.pbDisplayCam = New System.Windows.Forms.PictureBox()
        Me.lblQRCode = New System.Windows.Forms.Label()
        Me.lblCamImage = New System.Windows.Forms.Label()
        Me.pbDisplayID = New System.Windows.Forms.PictureBox()
        Me.lblDoImage = New System.Windows.Forms.Label()
        Me.btnTestStart = New System.Windows.Forms.Button()
        Me.lblAgeReq = New System.Windows.Forms.Label()
        Me.txtAgeReq = New System.Windows.Forms.TextBox()
        Me.BTNUnverifyAcc = New System.Windows.Forms.Button()
        Me.BTNVerifyAcc = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.BtnTestCheckoutUI = New System.Windows.Forms.Button()
        CType(Me.pbDisplayQR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDisplayCam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbDisplayID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnTest1
        '
        Me.BtnTest1.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnTest1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnTest1.FlatAppearance.BorderSize = 8
        Me.BtnTest1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTest1.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnTest1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnTest1.Location = New System.Drawing.Point(486, 667)
        Me.BtnTest1.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnTest1.Name = "BtnTest1"
        Me.BtnTest1.Size = New System.Drawing.Size(332, 71)
        Me.BtnTest1.TabIndex = 9
        Me.BtnTest1.Text = "Load Test Data 1"
        Me.BtnTest1.UseVisualStyleBackColor = False
        '
        'pbDisplayQR
        '
        Me.pbDisplayQR.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pbDisplayQR.Location = New System.Drawing.Point(54, 129)
        Me.pbDisplayQR.Margin = New System.Windows.Forms.Padding(4)
        Me.pbDisplayQR.Name = "pbDisplayQR"
        Me.pbDisplayQR.Size = New System.Drawing.Size(473, 417)
        Me.pbDisplayQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbDisplayQR.TabIndex = 8
        Me.pbDisplayQR.TabStop = False
        '
        'BtnTest2
        '
        Me.BtnTest2.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnTest2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnTest2.FlatAppearance.BorderSize = 8
        Me.BtnTest2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTest2.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnTest2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnTest2.Location = New System.Drawing.Point(931, 667)
        Me.BtnTest2.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnTest2.Name = "BtnTest2"
        Me.BtnTest2.Size = New System.Drawing.Size(332, 71)
        Me.BtnTest2.TabIndex = 10
        Me.BtnTest2.Text = "Load Test Data 2"
        Me.BtnTest2.UseVisualStyleBackColor = False
        '
        'pbDisplayCam
        '
        Me.pbDisplayCam.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pbDisplayCam.Location = New System.Drawing.Point(635, 129)
        Me.pbDisplayCam.Margin = New System.Windows.Forms.Padding(4)
        Me.pbDisplayCam.Name = "pbDisplayCam"
        Me.pbDisplayCam.Size = New System.Drawing.Size(473, 417)
        Me.pbDisplayCam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbDisplayCam.TabIndex = 11
        Me.pbDisplayCam.TabStop = False
        '
        'lblQRCode
        '
        Me.lblQRCode.AutoSize = True
        Me.lblQRCode.Font = New System.Drawing.Font("Lucida Bright", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblQRCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblQRCode.Location = New System.Drawing.Point(174, 58)
        Me.lblQRCode.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblQRCode.Name = "lblQRCode"
        Me.lblQRCode.Size = New System.Drawing.Size(208, 48)
        Me.lblQRCode.TabIndex = 12
        Me.lblQRCode.Text = "QR Code"
        '
        'lblCamImage
        '
        Me.lblCamImage.AutoSize = True
        Me.lblCamImage.Font = New System.Drawing.Font("Lucida Bright", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblCamImage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblCamImage.Location = New System.Drawing.Point(714, 58)
        Me.lblCamImage.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblCamImage.Name = "lblCamImage"
        Me.lblCamImage.Size = New System.Drawing.Size(326, 48)
        Me.lblCamImage.TabIndex = 13
        Me.lblCamImage.Text = "Camera Image"
        '
        'pbDisplayID
        '
        Me.pbDisplayID.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pbDisplayID.Location = New System.Drawing.Point(1194, 129)
        Me.pbDisplayID.Margin = New System.Windows.Forms.Padding(4)
        Me.pbDisplayID.Name = "pbDisplayID"
        Me.pbDisplayID.Size = New System.Drawing.Size(473, 417)
        Me.pbDisplayID.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbDisplayID.TabIndex = 14
        Me.pbDisplayID.TabStop = False
        '
        'lblDoImage
        '
        Me.lblDoImage.AutoSize = True
        Me.lblDoImage.Font = New System.Drawing.Font("Lucida Bright", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblDoImage.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDoImage.Location = New System.Drawing.Point(1243, 58)
        Me.lblDoImage.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblDoImage.Name = "lblDoImage"
        Me.lblDoImage.Size = New System.Drawing.Size(382, 48)
        Me.lblDoImage.TabIndex = 15
        Me.lblDoImage.Text = "Document Image"
        '
        'btnTestStart
        '
        Me.btnTestStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnTestStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnTestStart.FlatAppearance.BorderSize = 8
        Me.btnTestStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestStart.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.btnTestStart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.btnTestStart.Location = New System.Drawing.Point(472, 885)
        Me.btnTestStart.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTestStart.Name = "btnTestStart"
        Me.btnTestStart.Size = New System.Drawing.Size(236, 71)
        Me.btnTestStart.TabIndex = 16
        Me.btnTestStart.Text = "Begin Test"
        Me.btnTestStart.UseVisualStyleBackColor = False
        '
        'lblAgeReq
        '
        Me.lblAgeReq.AutoSize = True
        Me.lblAgeReq.Font = New System.Drawing.Font("Lucida Bright", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblAgeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblAgeReq.Location = New System.Drawing.Point(487, 582)
        Me.lblAgeReq.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblAgeReq.Name = "lblAgeReq"
        Me.lblAgeReq.Size = New System.Drawing.Size(621, 36)
        Me.lblAgeReq.TabIndex = 17
        Me.lblAgeReq.Text = "Product Minimum Age Requirement:"
        '
        'txtAgeReq
        '
        Me.txtAgeReq.Font = New System.Drawing.Font("Lucida Bright", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtAgeReq.Location = New System.Drawing.Point(1150, 582)
        Me.txtAgeReq.Name = "txtAgeReq"
        Me.txtAgeReq.Size = New System.Drawing.Size(100, 45)
        Me.txtAgeReq.TabIndex = 18
        Me.txtAgeReq.Text = "18"
        '
        'BTNUnverifyAcc
        '
        Me.BTNUnverifyAcc.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BTNUnverifyAcc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BTNUnverifyAcc.FlatAppearance.BorderSize = 8
        Me.BTNUnverifyAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNUnverifyAcc.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BTNUnverifyAcc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BTNUnverifyAcc.Location = New System.Drawing.Point(931, 771)
        Me.BTNUnverifyAcc.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNUnverifyAcc.Name = "BTNUnverifyAcc"
        Me.BTNUnverifyAcc.Size = New System.Drawing.Size(332, 71)
        Me.BTNUnverifyAcc.TabIndex = 20
        Me.BTNUnverifyAcc.Text = "Unverify Account"
        Me.BTNUnverifyAcc.UseVisualStyleBackColor = False
        '
        'BTNVerifyAcc
        '
        Me.BTNVerifyAcc.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BTNVerifyAcc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BTNVerifyAcc.FlatAppearance.BorderSize = 8
        Me.BTNVerifyAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNVerifyAcc.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BTNVerifyAcc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BTNVerifyAcc.Location = New System.Drawing.Point(486, 771)
        Me.BTNVerifyAcc.Margin = New System.Windows.Forms.Padding(4)
        Me.BTNVerifyAcc.Name = "BTNVerifyAcc"
        Me.BTNVerifyAcc.Size = New System.Drawing.Size(332, 71)
        Me.BTNVerifyAcc.TabIndex = 19
        Me.BTNVerifyAcc.Text = "Verify Account"
        Me.BTNVerifyAcc.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnClear.FlatAppearance.BorderSize = 8
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.btnClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.btnClear.Location = New System.Drawing.Point(1059, 885)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(236, 71)
        Me.btnClear.TabIndex = 21
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'BtnTestCheckoutUI
        '
        Me.BtnTestCheckoutUI.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnTestCheckoutUI.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnTestCheckoutUI.FlatAppearance.BorderSize = 8
        Me.BtnTestCheckoutUI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTestCheckoutUI.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnTestCheckoutUI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnTestCheckoutUI.Location = New System.Drawing.Point(769, 885)
        Me.BtnTestCheckoutUI.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnTestCheckoutUI.Name = "BtnTestCheckoutUI"
        Me.BtnTestCheckoutUI.Size = New System.Drawing.Size(236, 71)
        Me.BtnTestCheckoutUI.TabIndex = 22
        Me.BtnTestCheckoutUI.Text = "Test Checkout UI"
        Me.BtnTestCheckoutUI.UseVisualStyleBackColor = False
        '
        'TestGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1742, 1008)
        Me.Controls.Add(Me.BtnTestCheckoutUI)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.BTNUnverifyAcc)
        Me.Controls.Add(Me.BTNVerifyAcc)
        Me.Controls.Add(Me.txtAgeReq)
        Me.Controls.Add(Me.lblAgeReq)
        Me.Controls.Add(Me.btnTestStart)
        Me.Controls.Add(Me.lblDoImage)
        Me.Controls.Add(Me.pbDisplayID)
        Me.Controls.Add(Me.lblCamImage)
        Me.Controls.Add(Me.lblQRCode)
        Me.Controls.Add(Me.pbDisplayCam)
        Me.Controls.Add(Me.BtnTest2)
        Me.Controls.Add(Me.BtnTest1)
        Me.Controls.Add(Me.pbDisplayQR)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MinimumSize = New System.Drawing.Size(1742, 1008)
        Me.Name = "TestGUI"
        Me.Text = "TestGUI"
        CType(Me.pbDisplayQR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDisplayCam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbDisplayID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnTest1 As Button
    Friend WithEvents pbDisplayQR As PictureBox
    Friend WithEvents BtnTest2 As Button
    Friend WithEvents pbDisplayCam As PictureBox
    Friend WithEvents lblQRCode As Label
    Friend WithEvents lblCamImage As Label
    Friend WithEvents pbDisplayID As PictureBox
    Friend WithEvents lblDoImage As Label
    Friend WithEvents btnTestStart As Button
    Friend WithEvents lblAgeReq As Label
    Friend WithEvents txtAgeReq As TextBox
    Friend WithEvents BTNUnverifyAcc As Button
    Friend WithEvents BTNVerifyAcc As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents BtnTestCheckoutUI As Button
End Class
