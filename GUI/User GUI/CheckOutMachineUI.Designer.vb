<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CheckOutMachineUI
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
        Me.BtnBack = New System.Windows.Forms.Button()
        Me.BtnScan = New System.Windows.Forms.Button()
        Me.pbCaptureImage = New System.Windows.Forms.PictureBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        CType(Me.pbCaptureImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnBack
        '
        Me.BtnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnBack.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnBack.FlatAppearance.BorderSize = 8
        Me.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBack.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnBack.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnBack.Location = New System.Drawing.Point(497, 913)
        Me.BtnBack.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnBack.Name = "BtnBack"
        Me.BtnBack.Size = New System.Drawing.Size(216, 88)
        Me.BtnBack.TabIndex = 11
        Me.BtnBack.Text = "< Back"
        Me.BtnBack.UseVisualStyleBackColor = False
        '
        'BtnScan
        '
        Me.BtnScan.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnScan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnScan.FlatAppearance.BorderSize = 8
        Me.BtnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnScan.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnScan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnScan.Location = New System.Drawing.Point(888, 913)
        Me.BtnScan.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnScan.Name = "BtnScan"
        Me.BtnScan.Size = New System.Drawing.Size(216, 88)
        Me.BtnScan.TabIndex = 10
        Me.BtnScan.Text = "Scan"
        Me.BtnScan.UseVisualStyleBackColor = False
        '
        'pbCaptureImage
        '
        Me.pbCaptureImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pbCaptureImage.Location = New System.Drawing.Point(348, 42)
        Me.pbCaptureImage.Margin = New System.Windows.Forms.Padding(4)
        Me.pbCaptureImage.Name = "pbCaptureImage"
        Me.pbCaptureImage.Size = New System.Drawing.Size(898, 748)
        Me.pbCaptureImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbCaptureImage.TabIndex = 9
        Me.pbCaptureImage.TabStop = False
        '
        'lblDesc
        '
        Me.lblDesc.AutoSize = True
        Me.lblDesc.Font = New System.Drawing.Font("Lucida Sans", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblDesc.Location = New System.Drawing.Point(300, 826)
        Me.lblDesc.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(991, 37)
        Me.lblDesc.TabIndex = 22
        Me.lblDesc.Text = "Please present the QR code to the camera and press 'Scan'!"
        '
        'CheckOutMachineUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1564, 1044)
        Me.Controls.Add(Me.lblDesc)
        Me.Controls.Add(Me.BtnBack)
        Me.Controls.Add(Me.BtnScan)
        Me.Controls.Add(Me.pbCaptureImage)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "CheckOutMachineUI"
        Me.Text = "CheckoutMachineUI"
        CType(Me.pbCaptureImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnBack As Button
    Friend WithEvents BtnScan As Button
    Friend WithEvents pbCaptureImage As PictureBox
    Friend WithEvents lblDesc As Label
End Class
