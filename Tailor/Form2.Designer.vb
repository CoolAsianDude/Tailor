<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.btnSubtract = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.back1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cusnum = New System.Windows.Forms.Label()
        Me.date1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSubtract
        '
        Me.btnSubtract.Location = New System.Drawing.Point(148, 336)
        Me.btnSubtract.Name = "btnSubtract"
        Me.btnSubtract.Size = New System.Drawing.Size(111, 39)
        Me.btnSubtract.TabIndex = 0
        Me.btnSubtract.Text = "Check Out"
        Me.btnSubtract.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 117)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(378, 179)
        Me.DataGridView1.TabIndex = 1
        '
        'back1
        '
        Me.back1.Location = New System.Drawing.Point(148, 381)
        Me.back1.Name = "back1"
        Me.back1.Size = New System.Drawing.Size(111, 39)
        Me.back1.TabIndex = 2
        Me.back1.Text = "Back"
        Me.back1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 323)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CustomerID:"
        '
        'cusnum
        '
        Me.cusnum.AutoSize = True
        Me.cusnum.Location = New System.Drawing.Point(12, 349)
        Me.cusnum.Name = "cusnum"
        Me.cusnum.Size = New System.Drawing.Size(13, 13)
        Me.cusnum.TabIndex = 4
        Me.cusnum.Text = "0"
        Me.cusnum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'date1
        '
        Me.date1.Location = New System.Drawing.Point(15, 400)
        Me.date1.Name = "date1"
        Me.date1.Size = New System.Drawing.Size(100, 20)
        Me.date1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 381)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Order Date:"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Tailor.My.Resources.Resources._2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.date1)
        Me.Controls.Add(Me.cusnum)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.back1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSubtract)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSubtract As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents back1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cusnum As Label
    Friend WithEvents date1 As TextBox
    Friend WithEvents Label2 As Label
End Class
