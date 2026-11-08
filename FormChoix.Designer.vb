<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormChoix
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        btnEtudiant = New Button()
        Label2 = New Label()
        PictureBox2 = New PictureBox()
        Panel2 = New Panel()
        btnResponsable = New Button()
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        Panel3 = New Panel()
        Panel1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(btnEtudiant)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(493, 648)
        Panel1.TabIndex = 0
        ' 
        ' btnEtudiant
        ' 
        btnEtudiant.BackColor = Color.FromArgb(CByte(26), CByte(59), CByte(85))
        btnEtudiant.FlatStyle = FlatStyle.Flat
        btnEtudiant.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnEtudiant.ForeColor = Color.White
        btnEtudiant.Location = New Point(178, 525)
        btnEtudiant.Margin = New Padding(3, 2, 3, 2)
        btnEtudiant.Name = "btnEtudiant"
        btnEtudiant.Size = New Size(131, 44)
        btnEtudiant.TabIndex = 3
        btnEtudiant.Text = "Continuer"
        btnEtudiant.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.MistyRose
        Label2.Font = New Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Indigo
        Label2.Location = New Point(158, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(170, 29)
        Label2.TabIndex = 3
        Label2.Text = "ETUDIANT ?"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Snow
        PictureBox2.Image = My.Resources.Resources.Etudiant
        PictureBox2.Location = New Point(0, 0)
        PictureBox2.Margin = New Padding(3, 2, 3, 2)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(490, 454)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(btnResponsable)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Dock = DockStyle.Right
        Panel2.Location = New Point(695, 0)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(464, 648)
        Panel2.TabIndex = 1
        ' 
        ' btnResponsable
        ' 
        btnResponsable.BackColor = Color.FromArgb(CByte(26), CByte(59), CByte(85))
        btnResponsable.FlatStyle = FlatStyle.Flat
        btnResponsable.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnResponsable.ForeColor = Color.White
        btnResponsable.Location = New Point(163, 525)
        btnResponsable.Margin = New Padding(3, 2, 3, 2)
        btnResponsable.Name = "btnResponsable"
        btnResponsable.Size = New Size(131, 44)
        btnResponsable.TabIndex = 2
        btnResponsable.Text = "Continuer"
        btnResponsable.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.MistyRose
        Label1.Font = New Font("Georgia", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Indigo
        Label1.Location = New Point(114, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(237, 29)
        Label1.TabIndex = 2
        Label1.Text = "RESPO🎗ADMIN ?"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Snow
        PictureBox1.Image = My.Resources.Resources.admin__1_
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(461, 454)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = SystemColors.ActiveCaption
        Panel3.Location = New Point(488, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(206, 648)
        Panel3.TabIndex = 2
        ' 
        ' FormChoix
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Lavender
        ClientSize = New Size(1159, 648)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Margin = New Padding(3, 2, 3, 2)
        MaximumSize = New Size(1175, 687)
        Name = "FormChoix"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ETUGEST"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEtudiant As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnResponsable As Button
    Friend WithEvents Panel3 As Panel
End Class