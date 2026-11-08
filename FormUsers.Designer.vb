<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsers
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        txtUsername = New TextBox()
        txtPassword = New TextBox()
        btnAdd = New Button()
        btnEdit = New Button()
        btnToggleBlock = New Button()
        btnClear = New Button()
        Label1 = New Label()
        Label2 = New Label()
        lblStatus = New Label()
        GroupBox1 = New GroupBox()
        cmbRole = New ComboBox()
        Label3 = New Label()
        dgUsers = New DataGridView()
        GroupBox1.SuspendLayout()
        CType(dgUsers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Georgia", 11F)
        txtUsername.Location = New Point(167, 57)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(365, 24)
        txtUsername.TabIndex = 0
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Georgia", 11F)
        txtPassword.Location = New Point(167, 118)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(365, 24)
        txtPassword.TabIndex = 1
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Green
        btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(0))
        btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(0))
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(800, 63)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(169, 35)
        btnAdd.TabIndex = 2
        btnAdd.Text = "Ajouter🎁"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.FromArgb(CByte(21), CByte(91), CByte(165))
        btnEdit.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(0))
        btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(0))
        btnEdit.FlatStyle = FlatStyle.Flat
        btnEdit.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnEdit.ForeColor = Color.White
        btnEdit.Location = New Point(800, 163)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(169, 35)
        btnEdit.TabIndex = 3
        btnEdit.Text = "Modifier✏"
        btnEdit.UseVisualStyleBackColor = False
        ' 
        ' btnToggleBlock
        ' 
        btnToggleBlock.BackColor = Color.Crimson
        btnToggleBlock.FlatAppearance.MouseDownBackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(0))
        btnToggleBlock.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(0))
        btnToggleBlock.FlatStyle = FlatStyle.Flat
        btnToggleBlock.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnToggleBlock.ForeColor = Color.White
        btnToggleBlock.Location = New Point(800, 271)
        btnToggleBlock.Name = "btnToggleBlock"
        btnToggleBlock.Size = New Size(169, 35)
        btnToggleBlock.TabIndex = 4
        btnToggleBlock.Text = "Bloquer/Debloquer🔏"
        btnToggleBlock.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(26), CByte(59), CByte(85))
        btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(0))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(480, 243)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(90, 28)
        btnClear.TabIndex = 5
        btnClear.Text = "Nettoyer"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label1.Location = New Point(34, 120)
        Label1.Name = "Label1"
        Label1.Size = New Size(102, 20)
        Label1.TabIndex = 6
        Label1.Text = "Mot de Passe"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label2.Location = New Point(34, 55)
        Label2.Name = "Label2"
        Label2.Size = New Size(121, 20)
        Label2.TabIndex = 7
        Label2.Text = "Nom Utilisateur"
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblStatus.ForeColor = SystemColors.Highlight
        lblStatus.Location = New Point(135, 338)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(21, 20)
        lblStatus.TabIndex = 8
        lblStatus.Text = "..."
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.FromArgb(CByte(143), CByte(188), CByte(202))
        GroupBox1.Controls.Add(cmbRole)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(txtUsername)
        GroupBox1.Controls.Add(txtPassword)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(btnClear)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        GroupBox1.Location = New Point(135, 57)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(576, 278)
        GroupBox1.TabIndex = 9
        GroupBox1.TabStop = False
        GroupBox1.Text = "Formulaire Utilisateur"
        ' 
        ' cmbRole
        ' 
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRole.Font = New Font("Segoe UI", 11F)
        cmbRole.FormattingEnabled = True
        cmbRole.Items.AddRange(New Object() {"Administrateur", "Responsable de filière"})
        cmbRole.Location = New Point(167, 182)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(365, 28)
        cmbRole.TabIndex = 9
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        Label3.Location = New Point(36, 187)
        Label3.Name = "Label3"
        Label3.Size = New Size(40, 20)
        Label3.TabIndex = 8
        Label3.Text = "Role"
        ' 
        ' dgUsers
        ' 
        dgUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgUsers.BackgroundColor = Color.WhiteSmoke
        dgUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Control
        DataGridViewCellStyle1.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        dgUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = SystemColors.Window
        DataGridViewCellStyle2.Font = New Font("Segoe UI", 10F)
        DataGridViewCellStyle2.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.False
        dgUsers.DefaultCellStyle = DataGridViewCellStyle2
        dgUsers.Dock = DockStyle.Bottom
        dgUsers.Location = New Point(0, 384)
        dgUsers.Name = "dgUsers"
        dgUsers.Size = New Size(1159, 264)
        dgUsers.TabIndex = 10
        ' 
        ' FormUsers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(148), CByte(172), CByte(181))
        ClientSize = New Size(1159, 648)
        Controls.Add(dgUsers)
        Controls.Add(GroupBox1)
        Controls.Add(lblStatus)
        Controls.Add(btnToggleBlock)
        Controls.Add(btnEdit)
        Controls.Add(btnAdd)
        Name = "FormUsers"
        Text = "FormUsers"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(dgUsers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnToggleBlock As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgUsers As DataGridView
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents Label3 As Label
End Class
