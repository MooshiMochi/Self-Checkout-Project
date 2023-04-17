<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewPictureBox
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
        Me.pbDefault = New System.Windows.Forms.PictureBox()
        Me.BtnOK = New System.Windows.Forms.Button()
        CType(Me.pbDefault, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbDefault
        '
        Me.pbDefault.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.pbDefault.Location = New System.Drawing.Point(49, 17)
        Me.pbDefault.Margin = New System.Windows.Forms.Padding(2)
        Me.pbDefault.Name = "pbDefault"
        Me.pbDefault.Size = New System.Drawing.Size(385, 266)
        Me.pbDefault.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbDefault.TabIndex = 0
        Me.pbDefault.TabStop = False
        '
        'BtnOK
        '
        Me.BtnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.BtnOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnOK.FlatAppearance.BorderSize = 8
        Me.BtnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOK.Font = New System.Drawing.Font("Lucida Sans", 7.875!)
        Me.BtnOK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.BtnOK.Location = New System.Drawing.Point(196, 300)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(2)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(75, 37)
        Me.BtnOK.TabIndex = 7
        Me.BtnOK.Text = "Ok"
        Me.BtnOK.UseVisualStyleBackColor = False
        '
        'ViewPictureBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(116, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(484, 359)
        Me.Controls.Add(Me.BtnOK)
        Me.Controls.Add(Me.pbDefault)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "ViewPictureBox"
        Me.Text = "Picture"
        CType(Me.pbDefault, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbDefault As PictureBox
    Friend WithEvents BtnOK As Button
End Class
