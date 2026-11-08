<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGeneratePDF
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
        Label1 = New Label()
        dtStart = New DateTimePicker()
        btnGenererPDF = New Button()
        dtEnd = New DateTimePicker()
        Label2 = New Label()
        Label3 = New Label()
        cmbClasse = New ComboBox()
        Label4 = New Label()
        btnBrowsePDF = New Button()
        txtSavePath = New TextBox()
        Label12 = New Label()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Georgia", 18F, FontStyle.Bold Or FontStyle.Underline, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(177, 70)
        Label1.Name = "Label1"
        Label1.Size = New Size(806, 29)
        Label1.TabIndex = 0
        Label1.Text = "GENERATION DU RAPPORT JOURNALIER-HEBDOMADAIRE..."
        Label1.TextAlign = ContentAlignment.TopCenter
        ' 
        ' dtStart
        ' 
        dtStart.Font = New Font("Segoe UI", 14F)
        dtStart.Location = New Point(117, 234)
        dtStart.Margin = New Padding(3, 2, 3, 2)
        dtStart.Name = "dtStart"
        dtStart.Size = New Size(328, 32)
        dtStart.TabIndex = 2
        ' 
        ' btnGenererPDF
        ' 
        btnGenererPDF.BackColor = Color.Green
        btnGenererPDF.FlatStyle = FlatStyle.Flat
        btnGenererPDF.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnGenererPDF.ForeColor = Color.White
        btnGenererPDF.Location = New Point(510, 376)
        btnGenererPDF.Margin = New Padding(3, 2, 3, 2)
        btnGenererPDF.Name = "btnGenererPDF"
        btnGenererPDF.Size = New Size(157, 41)
        btnGenererPDF.TabIndex = 3
        btnGenererPDF.Text = "EXPORTER 📤"
        btnGenererPDF.UseVisualStyleBackColor = False
        ' 
        ' dtEnd
        ' 
        dtEnd.Font = New Font("Segoe UI", 14F)
        dtEnd.Location = New Point(494, 234)
        dtEnd.Margin = New Padding(3, 2, 3, 2)
        dtEnd.Name = "dtEnd"
        dtEnd.Size = New Size(328, 32)
        dtEnd.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label2.Location = New Point(111, 207)
        Label2.Name = "Label2"
        Label2.Size = New Size(40, 25)
        Label2.TabIndex = 6
        Label2.Text = "DU"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label3.Location = New Point(489, 207)
        Label3.Name = "Label3"
        Label3.Size = New Size(39, 25)
        Label3.TabIndex = 7
        Label3.Text = "AU"
        ' 
        ' cmbClasse
        ' 
        cmbClasse.DropDownStyle = ComboBoxStyle.DropDownList
        cmbClasse.Font = New Font("Segoe UI", 14F)
        cmbClasse.FormattingEnabled = True
        cmbClasse.Location = New Point(874, 233)
        cmbClasse.Name = "cmbClasse"
        cmbClasse.Size = New Size(239, 33)
        cmbClasse.TabIndex = 8
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        Label4.Location = New Point(868, 205)
        Label4.Name = "Label4"
        Label4.Size = New Size(79, 25)
        Label4.TabIndex = 9
        Label4.Text = "CLASSE"
        ' 
        ' btnBrowsePDF
        ' 
        btnBrowsePDF.BackColor = Color.FromArgb(CByte(27), CByte(159), CByte(202))
        btnBrowsePDF.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnBrowsePDF.ForeColor = Color.White
        btnBrowsePDF.Location = New Point(700, 587)
        btnBrowsePDF.Margin = New Padding(3, 2, 3, 2)
        btnBrowsePDF.Name = "btnBrowsePDF"
        btnBrowsePDF.Size = New Size(122, 36)
        btnBrowsePDF.TabIndex = 24
        btnBrowsePDF.Text = "Parcourir....."
        btnBrowsePDF.UseVisualStyleBackColor = False
        ' 
        ' txtSavePath
        ' 
        txtSavePath.Location = New Point(350, 534)
        txtSavePath.Margin = New Padding(3, 2, 3, 2)
        txtSavePath.Name = "txtSavePath"
        txtSavePath.Size = New Size(472, 23)
        txtSavePath.TabIndex = 23
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Georgia", 11F, FontStyle.Bold)
        Label12.Location = New Point(117, 537)
        Label12.Name = "Label12"
        Label12.Size = New Size(225, 18)
        Label12.TabIndex = 22
        Label12.Text = "Dossier de stockage du PDF :"
        ' 
        ' FormGeneratePDF
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(148), CByte(172), CByte(181))
        ClientSize = New Size(1159, 648)
        Controls.Add(btnBrowsePDF)
        Controls.Add(txtSavePath)
        Controls.Add(Label12)
        Controls.Add(Label4)
        Controls.Add(cmbClasse)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(dtEnd)
        Controls.Add(btnGenererPDF)
        Controls.Add(dtStart)
        Controls.Add(Label1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FormGeneratePDF"
        Text = "FormGeneratePDF"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dtStart As DateTimePicker
    Friend WithEvents btnGenererPDF As Button
    Friend WithEvents dtEnd As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbClasse As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnBrowsePDF As Button
    Friend WithEvents txtSavePath As TextBox
    Friend WithEvents Label12 As Label
End Class