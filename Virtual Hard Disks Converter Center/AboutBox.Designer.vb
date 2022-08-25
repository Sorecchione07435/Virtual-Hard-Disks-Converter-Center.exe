<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblProductName = New System.Windows.Forms.Label()
        Me.LblVersion = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LblCompany = New System.Windows.Forms.Label()
        Me.LblCopyright = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(62, 63)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'LblProductName
        '
        Me.LblProductName.Location = New System.Drawing.Point(81, 13)
        Me.LblProductName.Name = "LblProductName"
        Me.LblProductName.Size = New System.Drawing.Size(192, 23)
        Me.LblProductName.TabIndex = 1
        Me.LblProductName.Text = "{0}"
        Me.LblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblVersion
        '
        Me.LblVersion.Location = New System.Drawing.Point(81, 36)
        Me.LblVersion.Name = "LblVersion"
        Me.LblVersion.Size = New System.Drawing.Size(192, 23)
        Me.LblVersion.TabIndex = 2
        Me.LblVersion.Text = "Ver. {0}"
        Me.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(252, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LblCompany
        '
        Me.LblCompany.Location = New System.Drawing.Point(81, 70)
        Me.LblCompany.Name = "LblCompany"
        Me.LblCompany.Size = New System.Drawing.Size(192, 23)
        Me.LblCompany.TabIndex = 4
        Me.LblCompany.Text = "{0}"
        Me.LblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCopyright
        '
        Me.LblCopyright.Location = New System.Drawing.Point(81, 93)
        Me.LblCopyright.Name = "LblCopyright"
        Me.LblCopyright.Size = New System.Drawing.Size(192, 23)
        Me.LblCopyright.TabIndex = 5
        Me.LblCopyright.Text = "{0}"
        Me.LblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AboutBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(339, 156)
        Me.Controls.Add(Me.LblCopyright)
        Me.Controls.Add(Me.LblCompany)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LblVersion)
        Me.Controls.Add(Me.LblProductName)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Informazioni su VHD Converter Center"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LblProductName As Label
    Friend WithEvents LblVersion As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents LblCompany As Label
    Friend WithEvents LblCopyright As Label
End Class
