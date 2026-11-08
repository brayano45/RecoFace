<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLogin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        LabelError = New Label()
        PictureBox1 = New PictureBox()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        Label2 = New Label()
        Label3 = New Label()
        btnLogin = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' LabelError
        ' 
        LabelError.AutoSize = True
        LabelError.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LabelError.ForeColor = Color.Red
        LabelError.Location = New Point(781, 234)
        LabelError.Name = "LabelError"
        LabelError.Size = New Size(0, 19)
        LabelError.TabIndex = 6
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Left
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.previous
        PictureBox1.Location = New Point(3, 605)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(52, 41)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Segoe UI", 13F)
        txtUsername.Location = New Point(10, 47)
        txtUsername.Margin = New Padding(3, 2, 3, 2)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(277, 31)
        txtUsername.TabIndex = 1
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Segoe UI", 13F)
        txtPassword.Location = New Point(7, 46)
        txtPassword.Margin = New Padding(3, 2, 3, 2)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(273, 31)
        txtPassword.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        Label2.Location = New Point(3, 7)
        Label2.Name = "Label2"
        Label2.Size = New Size(128, 31)
        Label2.TabIndex = 3
        Label2.Text = "Identifiant"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        Label3.Location = New Point(0, 9)
        Label3.Name = "Label3"
        Label3.Size = New Size(155, 31)
        Label3.TabIndex = 4
        Label3.Text = "Mot de passe"
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.DodgerBlue
        btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(0))
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 17F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(971, 567)
        btnLogin.Margin = New Padding(3, 2, 3, 2)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(173, 50)
        btnLogin.TabIndex = 5
        btnLogin.Text = "Se connecter"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(txtUsername)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(12, 106)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(300, 91)
        Panel1.TabIndex = 8
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(txtPassword)
        Panel2.Location = New Point(862, 106)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(288, 91)
        Panel2.TabIndex = 9
        ' 
        ' FormLogin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Snow
        BackgroundImage = My.Resources.Resources.etu1
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1159, 648)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(PictureBox1)
        Controls.Add(LabelError)
        Controls.Add(btnLogin)
        DoubleBuffered = True
        Margin = New Padding(3, 2, 3, 2)
        MaximumSize = New Size(1175, 687)
        Name = "FormLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ETUGEST"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents LabelError As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel

End Class