<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtFname = New System.Windows.Forms.TextBox()
        Me.txtLname = New System.Windows.Forms.TextBox()
        Me.txtContactnum = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.enter = New System.Windows.Forms.Button()
        Me.back = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtFname
        '
        Me.txtFname.Location = New System.Drawing.Point(165, 70)
        Me.txtFname.Name = "txtFname"
        Me.txtFname.Size = New System.Drawing.Size(165, 20)
        Me.txtFname.TabIndex = 0
        '
        'txtLname
        '
        Me.txtLname.Location = New System.Drawing.Point(165, 117)
        Me.txtLname.Name = "txtLname"
        Me.txtLname.Size = New System.Drawing.Size(165, 20)
        Me.txtLname.TabIndex = 1
        '
        'txtContactnum
        '
        Me.txtContactnum.Location = New System.Drawing.Point(165, 161)
        Me.txtContactnum.Name = "txtContactnum"
        Me.txtContactnum.Size = New System.Drawing.Size(165, 20)
        Me.txtContactnum.TabIndex = 2
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(165, 213)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(165, 20)
        Me.txtEmail.TabIndex = 3
        '
        'enter
        '
        Me.enter.Location = New System.Drawing.Point(165, 258)
        Me.enter.Name = "enter"
        Me.enter.Size = New System.Drawing.Size(75, 23)
        Me.enter.TabIndex = 4
        Me.enter.Text = "Enter"
        Me.enter.UseVisualStyleBackColor = True
        '
        'back
        '
        Me.back.Location = New System.Drawing.Point(165, 297)
        Me.back.Name = "back"
        Me.back.Size = New System.Drawing.Size(75, 23)
        Me.back.TabIndex = 5
        Me.back.Text = "Back"
        Me.back.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Tailor.My.Resources.Resources._3
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.back)
        Me.Controls.Add(Me.enter)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.txtContactnum)
        Me.Controls.Add(Me.txtLname)
        Me.Controls.Add(Me.txtFname)
        Me.Name = "Form3"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFname As TextBox
    Friend WithEvents txtLname As TextBox
    Friend WithEvents txtContactnum As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents enter As Button
    Friend WithEvents back As Button
End Class
