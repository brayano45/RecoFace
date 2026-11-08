<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStudents
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
        Dim DataGridViewCellStyle5 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As DataGridViewCellStyle = New DataGridViewCellStyle()
        dgStudents = New DataGridView()
        GroupBox1 = New GroupBox()
        btnClear = New Button()
        txtClasse = New ComboBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        txtNom = New TextBox()
        txtPrenom = New TextBox()
        txtMatricule = New TextBox()
        btnAdd = New Button()
        btnDelete = New Button()
        btnUpdate = New Button()
        txtSearch = New TextBox()
        CType(dgStudents, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgStudents
        ' 
        dgStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgStudents.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgStudents.BackgroundColor = Color.WhiteSmoke
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = SystemColors.Control
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        dgStudents.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        dgStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dgStudents.DefaultCellStyle = DataGridViewCellStyle6
        dgStudents.Dock = DockStyle.Bottom
        dgStudents.Location = New Point(0, 303)
        dgStudents.Margin = New Padding(3, 2, 3, 2)
        dgStudents.Name = "dgStudents"
        dgStudents.RowHeadersWidth = 51
        dgStudents.Size = New Size(1159, 345)
        dgStudents.TabIndex = 0
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.FromArgb(CByte(143), CByte(188), CByte(202))
        GroupBox1.Controls.Add(btnClear)
        GroupBox1.Controls.Add(txtClasse)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(txtNom)
        GroupBox1.Controls.Add(txtPrenom)
        GroupBox1.Controls.Add(txtMatricule)
        GroupBox1.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(48, 21)
        GroupBox1.Margin = New Padding(3, 2, 3, 2)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 2, 3, 2)
        GroupBox1.Size = New Size(483, 262)
        GroupBox1.TabIndex = 1
        GroupBox1.TabStop = False
        GroupBox1.Text = "Informations Etudiants"
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(26), CByte(59), CByte(85))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold Or FontStyle.Italic)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(339, 227)
        btnClear.Margin = New Padding(3, 2, 3, 2)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(141, 31)
        btnClear.TabIndex = 7
        btnClear.Text = "Vider les champs"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' txtClasse
        ' 
        txtClasse.DropDownStyle = ComboBoxStyle.DropDownList
        txtClasse.Font = New Font("Georgia", 12.0F)
        txtClasse.FormattingEnabled = True
        txtClasse.Items.AddRange(New Object() {"GL2A", "GL2B", "GL2C", "GL2D"})
        txtClasse.Location = New Point(105, 171)
        txtClasse.Name = "txtClasse"
        txtClasse.Size = New Size(350, 26)
        txtClasse.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label4.Location = New Point(23, 173)
        Label4.Name = "Label4"
        Label4.Size = New Size(52, 20)
        Label4.TabIndex = 7
        Label4.Text = "Classe"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label3.Location = New Point(23, 131)
        Label3.Name = "Label3"
        Label3.Size = New Size(64, 20)
        Label3.TabIndex = 6
        Label3.Text = "Prenom"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label2.Location = New Point(23, 89)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 20)
        Label2.TabIndex = 5
        Label2.Text = "Nom"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(23, 46)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 20)
        Label1.TabIndex = 4
        Label1.Text = "Matricule"
        ' 
        ' txtNom
        ' 
        txtNom.Font = New Font("Georgia", 12.0F)
        txtNom.Location = New Point(105, 83)
        txtNom.Margin = New Padding(3, 2, 3, 2)
        txtNom.Name = "txtNom"
        txtNom.Size = New Size(350, 26)
        txtNom.TabIndex = 3
        ' 
        ' txtPrenom
        ' 
        txtPrenom.Font = New Font("Georgia", 12.0F)
        txtPrenom.Location = New Point(105, 126)
        txtPrenom.Margin = New Padding(3, 2, 3, 2)
        txtPrenom.Name = "txtPrenom"
        txtPrenom.Size = New Size(350, 26)
        txtPrenom.TabIndex = 1
        ' 
        ' txtMatricule
        ' 
        txtMatricule.Font = New Font("Georgia", 12.0F)
        txtMatricule.Location = New Point(105, 41)
        txtMatricule.Margin = New Padding(3, 2, 3, 2)
        txtMatricule.Name = "txtMatricule"
        txtMatricule.Size = New Size(350, 26)
        txtMatricule.TabIndex = 0
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.Green
        btnAdd.FlatStyle = FlatStyle.Flat
        btnAdd.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        btnAdd.ForeColor = Color.White
        btnAdd.Location = New Point(636, 94)
        btnAdd.Margin = New Padding(3, 2, 3, 2)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(108, 35)
        btnAdd.TabIndex = 2
        btnAdd.Text = "Ajouter🎁"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Crimson
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold Or FontStyle.Italic)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(636, 231)
        btnDelete.Margin = New Padding(3, 2, 3, 2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(108, 35)
        btnDelete.TabIndex = 3
        btnDelete.Text = "Supprimer🗑"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnUpdate
        ' 
        btnUpdate.BackColor = Color.FromArgb(CByte(21), CByte(91), CByte(165))
        btnUpdate.FlatStyle = FlatStyle.Flat
        btnUpdate.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold Or FontStyle.Italic)
        btnUpdate.ForeColor = Color.White
        btnUpdate.Location = New Point(636, 165)
        btnUpdate.Margin = New Padding(3, 2, 3, 2)
        btnUpdate.Name = "btnUpdate"
        btnUpdate.Size = New Size(108, 35)
        btnUpdate.TabIndex = 4
        btnUpdate.Text = "Modifier✏"
        btnUpdate.UseVisualStyleBackColor = False
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 10.2F, FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(636, 23)
        txtSearch.Margin = New Padding(3, 2, 3, 2)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(243, 26)
        txtSearch.TabIndex = 5
        txtSearch.Text = "rechercher......"
        ' 
        ' FormStudents
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        AutoSize = True
        BackColor = Color.FromArgb(CByte(148), CByte(172), CByte(181))
        ClientSize = New Size(1159, 648)
        Controls.Add(txtSearch)
        Controls.Add(btnUpdate)
        Controls.Add(btnDelete)
        Controls.Add(btnAdd)
        Controls.Add(GroupBox1)
        Controls.Add(dgStudents)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FormStudents"
        Text = "FormStudents"
        CType(dgStudents, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgStudents As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtNom As TextBox
    Friend WithEvents txtPrenom As TextBox
    Friend WithEvents txtMatricule As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents btnClear As Button
    Friend WithEvents txtClasse As ComboBox
End Class
