<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAudit
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
        dgAudits = New DataGridView()
        txtSearch = New TextBox()
        CType(dgAudits, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' dgAudits
        ' 
        dgAudits.AllowUserToDeleteRows = False
        dgAudits.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        dgAudits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgAudits.BackgroundColor = Color.WhiteSmoke
        dgAudits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgAudits.Location = New Point(0, 212)
        dgAudits.Name = "dgAudits"
        dgAudits.ReadOnly = True
        dgAudits.Size = New Size(1158, 433)
        dgAudits.TabIndex = 0
        ' 
        ' txtSearch
        ' 
        txtSearch.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        txtSearch.Location = New Point(320, 97)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(313, 29)
        txtSearch.TabIndex = 1
        txtSearch.Text = "Rechercher........"
        ' 
        ' FormAudit
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(148), CByte(172), CByte(181))
        ClientSize = New Size(1159, 648)
        Controls.Add(txtSearch)
        Controls.Add(dgAudits)
        Name = "FormAudit"
        Text = "FormAudit"
        CType(dgAudits, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgAudits As DataGridView
    Friend WithEvents txtSearch As TextBox
End Class
