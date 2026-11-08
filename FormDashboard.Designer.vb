<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDashboard
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
        components = New ComponentModel.Container()
        Panel1 = New Panel()
        btnSchedule = New Button()
        btnLogs = New Button()
        Label2 = New Label()
        btnUsers = New Button()
        btnTrain = New Button()
        btnSettings = New Button()
        btnPDF = New Button()
        btnPresences = New Button()
        btnEnroll = New Button()
        btnStudents = New Button()
        btnDashboard = New Button()
        lblAdminName = New Label()
        PictureBox1 = New PictureBox()
        btnLogout = New Button()
        Panel2 = New Panel()
        lblModelStatus = New Label()
        lblStat = New Label()
        PanelMain = New Panel()
        monPanel = New Panel()
        TimerCheckPeriods = New Timer(components)
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        PanelMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(26), CByte(59), CByte(85))
        Panel1.Controls.Add(btnSchedule)
        Panel1.Controls.Add(btnLogs)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(btnUsers)
        Panel1.Controls.Add(btnTrain)
        Panel1.Controls.Add(btnSettings)
        Panel1.Controls.Add(btnPDF)
        Panel1.Controls.Add(btnPresences)
        Panel1.Controls.Add(btnEnroll)
        Panel1.Controls.Add(btnStudents)
        Panel1.Controls.Add(btnDashboard)
        Panel1.Controls.Add(lblAdminName)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(202, 749)
        Panel1.TabIndex = 0
        ' 
        ' btnSchedule
        ' 
        btnSchedule.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnSchedule.FlatAppearance.MouseDownBackColor = Color.Black
        btnSchedule.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnSchedule.FlatStyle = FlatStyle.Flat
        btnSchedule.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnSchedule.ForeColor = Color.Black
        btnSchedule.Location = New Point(24, 326)
        btnSchedule.Margin = New Padding(3, 2, 3, 2)
        btnSchedule.Name = "btnSchedule"
        btnSchedule.Size = New Size(155, 39)
        btnSchedule.TabIndex = 12
        btnSchedule.Text = "Planning📅"
        btnSchedule.UseVisualStyleBackColor = False
        ' 
        ' btnLogs
        ' 
        btnLogs.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnLogs.FlatAppearance.MouseDownBackColor = Color.Black
        btnLogs.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnLogs.FlatStyle = FlatStyle.Flat
        btnLogs.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnLogs.ForeColor = Color.Black
        btnLogs.Location = New Point(24, 622)
        btnLogs.Margin = New Padding(3, 2, 3, 2)
        btnLogs.Name = "btnLogs"
        btnLogs.Size = New Size(155, 37)
        btnLogs.TabIndex = 11
        btnLogs.Text = "Historique🎈"
        btnLogs.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BorderStyle = BorderStyle.Fixed3D
        Label2.Font = New Font("Georgia", 25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.Aqua
        Label2.Location = New Point(5, 8)
        Label2.Name = "Label2"
        Label2.Size = New Size(192, 41)
        Label2.TabIndex = 10
        Label2.Text = "ETUGEST"
        ' 
        ' btnUsers
        ' 
        btnUsers.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnUsers.FlatAppearance.MouseDownBackColor = Color.Black
        btnUsers.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnUsers.FlatStyle = FlatStyle.Flat
        btnUsers.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnUsers.ForeColor = Color.Black
        btnUsers.Location = New Point(24, 564)
        btnUsers.Margin = New Padding(3, 2, 3, 2)
        btnUsers.Name = "btnUsers"
        btnUsers.Size = New Size(155, 39)
        btnUsers.TabIndex = 9
        btnUsers.Text = "Utilisateurs👤"
        btnUsers.UseVisualStyleBackColor = False
        ' 
        ' btnTrain
        ' 
        btnTrain.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnTrain.FlatAppearance.MouseDownBackColor = Color.Black
        btnTrain.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnTrain.FlatStyle = FlatStyle.Flat
        btnTrain.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnTrain.ForeColor = Color.Black
        btnTrain.Location = New Point(24, 504)
        btnTrain.Margin = New Padding(3, 2, 3, 2)
        btnTrain.Name = "btnTrain"
        btnTrain.Size = New Size(155, 39)
        btnTrain.TabIndex = 8
        btnTrain.Text = "Entrainer👁"
        btnTrain.UseVisualStyleBackColor = False
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnSettings.FlatAppearance.MouseDownBackColor = Color.Black
        btnSettings.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnSettings.FlatStyle = FlatStyle.Flat
        btnSettings.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnSettings.ForeColor = Color.Black
        btnSettings.Location = New Point(24, 688)
        btnSettings.Margin = New Padding(3, 2, 3, 2)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(155, 39)
        btnSettings.TabIndex = 2
        btnSettings.Text = "Paramètres⚙"
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnPDF
        ' 
        btnPDF.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnPDF.FlatAppearance.MouseDownBackColor = Color.Black
        btnPDF.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnPDF.FlatStyle = FlatStyle.Flat
        btnPDF.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnPDF.ForeColor = Color.Black
        btnPDF.Location = New Point(24, 445)
        btnPDF.Margin = New Padding(3, 2, 3, 2)
        btnPDF.Name = "btnPDF"
        btnPDF.Size = New Size(155, 36)
        btnPDF.TabIndex = 6
        btnPDF.Text = "Générer PDF📑"
        btnPDF.UseVisualStyleBackColor = False
        ' 
        ' btnPresences
        ' 
        btnPresences.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnPresences.FlatAppearance.MouseDownBackColor = Color.Black
        btnPresences.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnPresences.FlatStyle = FlatStyle.Flat
        btnPresences.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnPresences.ForeColor = Color.Black
        btnPresences.Location = New Point(24, 384)
        btnPresences.Margin = New Padding(3, 2, 3, 2)
        btnPresences.Name = "btnPresences"
        btnPresences.Size = New Size(155, 39)
        btnPresences.TabIndex = 5
        btnPresences.Text = "Présences📰"
        btnPresences.UseVisualStyleBackColor = False
        ' 
        ' btnEnroll
        ' 
        btnEnroll.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnEnroll.FlatAppearance.MouseDownBackColor = Color.Black
        btnEnroll.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnEnroll.FlatStyle = FlatStyle.Flat
        btnEnroll.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnEnroll.ForeColor = Color.Black
        btnEnroll.Location = New Point(24, 271)
        btnEnroll.Margin = New Padding(3, 2, 3, 2)
        btnEnroll.Name = "btnEnroll"
        btnEnroll.Size = New Size(155, 39)
        btnEnroll.TabIndex = 3
        btnEnroll.Text = "Enrolement📷"
        btnEnroll.UseVisualStyleBackColor = False
        ' 
        ' btnStudents
        ' 
        btnStudents.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnStudents.FlatAppearance.MouseDownBackColor = Color.Black
        btnStudents.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnStudents.FlatStyle = FlatStyle.Flat
        btnStudents.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnStudents.ForeColor = Color.Black
        btnStudents.Location = New Point(24, 212)
        btnStudents.Margin = New Padding(3, 2, 3, 2)
        btnStudents.Name = "btnStudents"
        btnStudents.Size = New Size(155, 39)
        btnStudents.TabIndex = 2
        btnStudents.Text = "Etudiants👨‍👩‍👧‍👦"
        btnStudents.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnDashboard.FlatAppearance.MouseDownBackColor = Color.Black
        btnDashboard.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnDashboard.ForeColor = Color.Black
        btnDashboard.Location = New Point(24, 153)
        btnDashboard.Margin = New Padding(3, 2, 3, 2)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Size = New Size(155, 39)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Dashboard📊"
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' lblAdminName
        ' 
        lblAdminName.AutoSize = True
        lblAdminName.Font = New Font("Georgia", 13F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAdminName.ForeColor = Color.White
        lblAdminName.Location = New Point(54, 112)
        lblAdminName.Name = "lblAdminName"
        lblAdminName.Size = New Size(70, 21)
        lblAdminName.TabIndex = 1
        lblAdminName.Text = "Label1"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.user
        PictureBox1.Location = New Point(71, 62)
        PictureBox1.Margin = New Padding(3, 2, 3, 2)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(50, 45)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(CByte(190), CByte(230), CByte(253))
        btnLogout.FlatAppearance.MouseDownBackColor = Color.Black
        btnLogout.FlatAppearance.MouseOverBackColor = Color.Aqua
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnLogout.ForeColor = Color.Crimson
        btnLogout.Location = New Point(1016, 13)
        btnLogout.Margin = New Padding(3, 2, 3, 2)
        btnLogout.Name = "btnLogout"
        btnLogout.Size = New Size(155, 39)
        btnLogout.TabIndex = 7
        btnLogout.Text = "Deconnexion📛"
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(26), CByte(59), CByte(85))
        Panel2.Controls.Add(btnLogout)
        Panel2.Controls.Add(lblModelStatus)
        Panel2.Controls.Add(lblStat)
        Panel2.Dock = DockStyle.Top
        Panel2.Location = New Point(202, 0)
        Panel2.Margin = New Padding(3, 2, 3, 2)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1183, 63)
        Panel2.TabIndex = 1
        ' 
        ' lblModelStatus
        ' 
        lblModelStatus.AutoSize = True
        lblModelStatus.Font = New Font("Segoe UI", 11F)
        lblModelStatus.ForeColor = Color.Black
        lblModelStatus.Location = New Point(658, 20)
        lblModelStatus.Name = "lblModelStatus"
        lblModelStatus.Size = New Size(53, 20)
        lblModelStatus.TabIndex = 0
        lblModelStatus.Text = "Label2"
        ' 
        ' lblStat
        ' 
        lblStat.AutoSize = True
        lblStat.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblStat.ForeColor = Color.White
        lblStat.Location = New Point(113, 20)
        lblStat.Name = "lblStat"
        lblStat.Size = New Size(156, 25)
        lblStat.TabIndex = 0
        lblStat.Text = "Tableau de bord"
        ' 
        ' PanelMain
        ' 
        PanelMain.BackColor = Color.FromArgb(CByte(242), CByte(242), CByte(242))
        PanelMain.Controls.Add(monPanel)
        PanelMain.Dock = DockStyle.Fill
        PanelMain.ForeColor = SystemColors.ButtonShadow
        PanelMain.Location = New Point(202, 63)
        PanelMain.Margin = New Padding(3, 2, 3, 2)
        PanelMain.Name = "PanelMain"
        PanelMain.Size = New Size(1183, 686)
        PanelMain.TabIndex = 2
        ' 
        ' monPanel
        ' 
        monPanel.BackColor = Color.White
        monPanel.Dock = DockStyle.Fill
        monPanel.ForeColor = Color.Black
        monPanel.Location = New Point(0, 0)
        monPanel.Name = "monPanel"
        monPanel.Size = New Size(1183, 686)
        monPanel.TabIndex = 1
        ' 
        ' TimerCheckPeriods
        ' 
        ' 
        ' FormDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1385, 749)
        Controls.Add(PanelMain)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Margin = New Padding(3, 2, 3, 2)
        MaximumSize = New Size(1401, 788)
        Name = "FormDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ETUGEST"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        PanelMain.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnPDF As Button
    Friend WithEvents btnPresences As Button
    Friend WithEvents btnEnroll As Button
    Friend WithEvents btnStudents As Button
    Friend WithEvents btnDashboard As Button
    Friend WithEvents lblAdminName As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblStat As Label
    Friend WithEvents PanelMain As Panel
    Friend WithEvents btnTrain As Button
    Friend WithEvents lblModelStatus As Label
    Friend WithEvents TimerCheckPeriods As Timer
    Friend WithEvents monPanel As Panel
    Friend WithEvents btnUsers As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnLogs As Button
    Friend WithEvents btnSchedule As Button
End Class