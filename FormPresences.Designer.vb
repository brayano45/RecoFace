<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPresences
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
        Dim DataGridViewCellStyle7 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As DataGridViewCellStyle = New DataGridViewCellStyle()
        txtSearchStudent = New TextBox()
        btnSearch = New Button()
        dtStart = New DateTimePicker()
        dtEnd = New DateTimePicker()
        Label1 = New Label()
        Label2 = New Label()
        btnFilter = New Button()
        dgPresences = New DataGridView()
        btnSave = New Button()
        btnDelete = New Button()
        btnClear = New Button()
        txtJustification = New TextBox()
        Label3 = New Label()
        lblSelectedStudent = New Label()
        dtDate = New DateTimePicker()
        chkP1 = New CheckBox()
        chkP2 = New CheckBox()
        chkP3 = New CheckBox()
        chkP4 = New CheckBox()
        Label4 = New Label()
        txtFiltreClasse = New ComboBox()
        CType(dgPresences, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtSearchStudent
        ' 
        txtSearchStudent.Location = New Point(816, 32)
        txtSearchStudent.Margin = New Padding(3, 2, 3, 2)
        txtSearchStudent.Name = "txtSearchStudent"
        txtSearchStudent.Size = New Size(188, 23)
        txtSearchStudent.TabIndex = 0
        ' 
        ' btnSearch
        ' 
        btnSearch.BackColor = Color.FromArgb(CByte(27), CByte(159), CByte(202))
        btnSearch.FlatStyle = FlatStyle.Flat
        btnSearch.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        btnSearch.ForeColor = Color.White
        btnSearch.Location = New Point(1007, 27)
        btnSearch.Margin = New Padding(3, 2, 3, 2)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(100, 35)
        btnSearch.TabIndex = 1
        btnSearch.Text = "Rechercher"
        btnSearch.UseVisualStyleBackColor = False
        ' 
        ' dtStart
        ' 
        dtStart.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        dtStart.Location = New Point(19, 79)
        dtStart.Margin = New Padding(3, 2, 3, 2)
        dtStart.Name = "dtStart"
        dtStart.Size = New Size(219, 23)
        dtStart.TabIndex = 2
        ' 
        ' dtEnd
        ' 
        dtEnd.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        dtEnd.Location = New Point(19, 139)
        dtEnd.Margin = New Padding(3, 2, 3, 2)
        dtEnd.Name = "dtEnd"
        dtEnd.Size = New Size(219, 23)
        dtEnd.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(15, 58)
        Label1.Name = "Label1"
        Label1.Size = New Size(53, 19)
        Label1.TabIndex = 4
        Label1.Text = "DEBUT"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(14, 119)
        Label2.Name = "Label2"
        Label2.Size = New Size(31, 19)
        Label2.TabIndex = 5
        Label2.Text = "FIN"
        ' 
        ' btnFilter
        ' 
        btnFilter.BackColor = Color.FromArgb(CByte(27), CByte(159), CByte(202))
        btnFilter.FlatStyle = FlatStyle.Flat
        btnFilter.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        btnFilter.ForeColor = Color.White
        btnFilter.Location = New Point(270, 134)
        btnFilter.Margin = New Padding(3, 2, 3, 2)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(97, 35)
        btnFilter.TabIndex = 6
        btnFilter.Text = "Filtrer"
        btnFilter.UseVisualStyleBackColor = False
        ' 
        ' dgPresences
        ' 
        dgPresences.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgPresences.BackgroundColor = Color.WhiteSmoke
        DataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = SystemColors.Control
        DataGridViewCellStyle5.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = DataGridViewTriState.True
        dgPresences.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        dgPresences.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = SystemColors.Window
        DataGridViewCellStyle6.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle6.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = DataGridViewTriState.False
        dgPresences.DefaultCellStyle = DataGridViewCellStyle6
        dgPresences.Dock = DockStyle.Bottom
        dgPresences.Location = New Point(0, 315)
        dgPresences.Margin = New Padding(3, 2, 3, 2)
        dgPresences.Name = "dgPresences"
        DataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = SystemColors.Control
        DataGridViewCellStyle7.Font = New Font("Segoe UI", 10.0F)
        DataGridViewCellStyle7.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = DataGridViewTriState.True
        dgPresences.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        dgPresences.RowHeadersWidth = 51
        DataGridViewCellStyle8.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        dgPresences.RowsDefaultCellStyle = DataGridViewCellStyle8
        dgPresences.Size = New Size(1159, 333)
        dgPresences.TabIndex = 7
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.Green
        btnSave.FlatStyle = FlatStyle.Flat
        btnSave.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        btnSave.ForeColor = Color.White
        btnSave.Location = New Point(1007, 129)
        btnSave.Margin = New Padding(3, 2, 3, 2)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(140, 35)
        btnSave.TabIndex = 14
        btnSave.Text = "Enregistrer✅"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnDelete
        ' 
        btnDelete.BackColor = Color.Crimson
        btnDelete.FlatStyle = FlatStyle.Flat
        btnDelete.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        btnDelete.ForeColor = Color.White
        btnDelete.Location = New Point(1007, 192)
        btnDelete.Margin = New Padding(3, 2, 3, 2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(140, 35)
        btnDelete.TabIndex = 15
        btnDelete.Text = "Supprimer🗑"
        btnDelete.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(26), CByte(59), CByte(85))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(1007, 253)
        btnClear.Margin = New Padding(3, 2, 3, 2)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(140, 35)
        btnClear.TabIndex = 16
        btnClear.Text = "Nettoyer"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' txtJustification
        ' 
        txtJustification.Font = New Font("Segoe UI", 11.0F)
        txtJustification.ForeColor = Color.Purple
        txtJustification.Location = New Point(626, 163)
        txtJustification.Name = "txtJustification"
        txtJustification.Size = New Size(220, 27)
        txtJustification.TabIndex = 17
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label3.ForeColor = Color.Purple
        Label3.Location = New Point(626, 142)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 20)
        Label3.TabIndex = 18
        Label3.Text = "Justification"
        ' 
        ' lblSelectedStudent
        ' 
        lblSelectedStudent.AutoSize = True
        lblSelectedStudent.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblSelectedStudent.ForeColor = Color.Purple
        lblSelectedStudent.Location = New Point(460, 287)
        lblSelectedStudent.Name = "lblSelectedStudent"
        lblSelectedStudent.Size = New Size(42, 21)
        lblSelectedStudent.TabIndex = 8
        lblSelectedStudent.Text = "........"
        ' 
        ' dtDate
        ' 
        dtDate.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        dtDate.Location = New Point(510, 79)
        dtDate.Margin = New Padding(3, 2, 3, 2)
        dtDate.Name = "dtDate"
        dtDate.Size = New Size(219, 25)
        dtDate.TabIndex = 9
        ' 
        ' chkP1
        ' 
        chkP1.AutoSize = True
        chkP1.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        chkP1.Location = New Point(510, 116)
        chkP1.Margin = New Padding(3, 2, 3, 2)
        chkP1.Name = "chkP1"
        chkP1.Size = New Size(93, 23)
        chkP1.TabIndex = 10
        chkP1.Text = "Periode 1"
        chkP1.UseVisualStyleBackColor = True
        ' 
        ' chkP2
        ' 
        chkP2.AutoSize = True
        chkP2.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        chkP2.Location = New Point(510, 156)
        chkP2.Margin = New Padding(3, 2, 3, 2)
        chkP2.Name = "chkP2"
        chkP2.Size = New Size(93, 23)
        chkP2.TabIndex = 11
        chkP2.Text = "Periode 2"
        chkP2.UseVisualStyleBackColor = True
        ' 
        ' chkP3
        ' 
        chkP3.AutoSize = True
        chkP3.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        chkP3.Location = New Point(510, 193)
        chkP3.Margin = New Padding(3, 2, 3, 2)
        chkP3.Name = "chkP3"
        chkP3.Size = New Size(93, 23)
        chkP3.TabIndex = 12
        chkP3.Text = "Periode 3"
        chkP3.UseVisualStyleBackColor = True
        ' 
        ' chkP4
        ' 
        chkP4.AutoSize = True
        chkP4.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        chkP4.Location = New Point(510, 228)
        chkP4.Margin = New Padding(3, 2, 3, 2)
        chkP4.Name = "chkP4"
        chkP4.Size = New Size(93, 23)
        chkP4.TabIndex = 13
        chkP4.Text = "Periode 4"
        chkP4.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(266, 58)
        Label4.Name = "Label4"
        Label4.Size = New Size(58, 19)
        Label4.TabIndex = 22
        Label4.Text = "CLASSE"
        ' 
        ' txtFiltreClasse
        ' 
        txtFiltreClasse.DropDownStyle = ComboBoxStyle.DropDownList
        txtFiltreClasse.Font = New Font("Georgia", 9F, FontStyle.Bold)
        txtFiltreClasse.FormattingEnabled = True
        txtFiltreClasse.Location = New Point(270, 79)
        txtFiltreClasse.Name = "txtFiltreClasse"
        txtFiltreClasse.Size = New Size(161, 23)
        txtFiltreClasse.TabIndex = 21
        ' 
        ' FormPresences
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(148), CByte(172), CByte(181))
        ClientSize = New Size(1159, 648)
        Controls.Add(Label4)
        Controls.Add(txtFiltreClasse)
        Controls.Add(Label3)
        Controls.Add(txtJustification)
        Controls.Add(btnClear)
        Controls.Add(btnDelete)
        Controls.Add(btnSave)
        Controls.Add(chkP4)
        Controls.Add(chkP3)
        Controls.Add(chkP2)
        Controls.Add(chkP1)
        Controls.Add(dtDate)
        Controls.Add(lblSelectedStudent)
        Controls.Add(dgPresences)
        Controls.Add(btnFilter)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(dtEnd)
        Controls.Add(dtStart)
        Controls.Add(btnSearch)
        Controls.Add(txtSearchStudent)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FormPresences"
        Text = "Gestion des Présences"
        CType(dgPresences, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtSearchStudent As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents dtStart As DateTimePicker
    Friend WithEvents dtEnd As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnFilter As Button
    Friend WithEvents dgPresences As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents txtJustification As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSelectedStudent As Label
    Friend WithEvents dtDate As DateTimePicker
    Friend WithEvents chkP1 As CheckBox
    Friend WithEvents chkP2 As CheckBox
    Friend WithEvents chkP3 As CheckBox
    Friend WithEvents chkP4 As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtFiltreClasse As ComboBox
End Class