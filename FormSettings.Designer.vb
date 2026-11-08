<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSettings
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
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        GroupBox3 = New GroupBox()
        nudMinSize = New NumericUpDown()
        lblMinFaceSize = New Label()
        GroupBox2 = New GroupBox()
        btnBrowseModel = New Button()
        txtModelPath = New TextBox()
        btnBrowseTraining = New Button()
        txtTrainingPath = New TextBox()
        Label3 = New Label()
        lblTrainingPath = New Label()
        GroupBox1 = New GroupBox()
        nudImagesPerStudent = New NumericUpDown()
        lblImagesPer = New Label()
        nudThreshold = New NumericUpDown()
        lblThreshold = New Label()
        TabPage2 = New TabPage()
        GroupBox4 = New GroupBox()
        lblDBStatus = New Label()
        btnTestConnection = New Button()
        txtDBPass = New TextBox()
        txtDBUser = New TextBox()
        txtDBName = New TextBox()
        txtHost = New TextBox()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        TabPage3 = New TabPage()
        GroupBox5 = New GroupBox()
        btnSaveTimes = New Button()
        dtpP4End = New DateTimePicker()
        dtpP4Start = New DateTimePicker()
        Label11 = New Label()
        dtpP3End = New DateTimePicker()
        dtpP3Start = New DateTimePicker()
        Label10 = New Label()
        dtpP2End = New DateTimePicker()
        dtpP2Start = New DateTimePicker()
        Label5 = New Label()
        dtpP1End = New DateTimePicker()
        Label4 = New Label()
        Label2 = New Label()
        dtpP1Start = New DateTimePicker()
        Label1 = New Label()
        btnSave = New Button()
        Panel1 = New Panel()
        chkLogs = New CheckBox()
        chkDarkMode = New CheckBox()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        GroupBox3.SuspendLayout()
        CType(nudMinSize, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        GroupBox1.SuspendLayout()
        CType(nudImagesPerStudent, ComponentModel.ISupportInitialize).BeginInit()
        CType(nudThreshold, ComponentModel.ISupportInitialize).BeginInit()
        TabPage2.SuspendLayout()
        GroupBox4.SuspendLayout()
        TabPage3.SuspendLayout()
        GroupBox5.SuspendLayout()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Font = New Font("Georgia", 13.0F, FontStyle.Bold)
        TabControl1.Location = New Point(0, 0)
        TabControl1.Margin = New Padding(3, 2, 3, 2)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1159, 648)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.Lavender
        TabPage1.Controls.Add(GroupBox3)
        TabPage1.Controls.Add(GroupBox2)
        TabPage1.Controls.Add(GroupBox1)
        TabPage1.Location = New Point(4, 29)
        TabPage1.Margin = New Padding(3, 2, 3, 2)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3, 2, 3, 2)
        TabPage1.Size = New Size(1151, 615)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Reconnaissance Faciale"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.BackColor = Color.Snow
        GroupBox3.Controls.Add(nudMinSize)
        GroupBox3.Controls.Add(lblMinFaceSize)
        GroupBox3.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        GroupBox3.Location = New Point(3, 188)
        GroupBox3.Margin = New Padding(3, 2, 3, 2)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Padding = New Padding(3, 2, 3, 2)
        GroupBox3.Size = New Size(1145, 162)
        GroupBox3.TabIndex = 5
        GroupBox3.TabStop = False
        GroupBox3.Text = "DETECTION FACE"
        ' 
        ' nudMinSize
        ' 
        nudMinSize.Font = New Font("Segoe UI", 12.0F)
        nudMinSize.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        nudMinSize.Location = New Point(279, 63)
        nudMinSize.Margin = New Padding(3, 2, 3, 2)
        nudMinSize.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
        nudMinSize.Name = "nudMinSize"
        nudMinSize.Size = New Size(189, 29)
        nudMinSize.TabIndex = 4
        ' 
        ' lblMinFaceSize
        ' 
        lblMinFaceSize.AutoSize = True
        lblMinFaceSize.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblMinFaceSize.Location = New Point(8, 65)
        lblMinFaceSize.Name = "lblMinFaceSize"
        lblMinFaceSize.Size = New Size(224, 21)
        lblMinFaceSize.TabIndex = 8
        lblMinFaceSize.Text = "Taille minimale visage (px) :"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.BackColor = Color.WhiteSmoke
        GroupBox2.Controls.Add(btnBrowseModel)
        GroupBox2.Controls.Add(txtModelPath)
        GroupBox2.Controls.Add(btnBrowseTraining)
        GroupBox2.Controls.Add(txtTrainingPath)
        GroupBox2.Controls.Add(Label3)
        GroupBox2.Controls.Add(lblTrainingPath)
        GroupBox2.Dock = DockStyle.Bottom
        GroupBox2.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        GroupBox2.Location = New Point(3, 441)
        GroupBox2.Margin = New Padding(3, 2, 3, 2)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Padding = New Padding(3, 2, 3, 2)
        GroupBox2.Size = New Size(1145, 172)
        GroupBox2.TabIndex = 4
        GroupBox2.TabStop = False
        GroupBox2.Text = "CHEMINS"
        ' 
        ' btnBrowseModel
        ' 
        btnBrowseModel.BackColor = Color.Green
        btnBrowseModel.FlatStyle = FlatStyle.Flat
        btnBrowseModel.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnBrowseModel.ForeColor = Color.White
        btnBrowseModel.Location = New Point(770, 112)
        btnBrowseModel.Margin = New Padding(3, 2, 3, 2)
        btnBrowseModel.Name = "btnBrowseModel"
        btnBrowseModel.Size = New Size(113, 25)
        btnBrowseModel.TabIndex = 7
        btnBrowseModel.Text = "Changer"
        btnBrowseModel.UseVisualStyleBackColor = False
        ' 
        ' txtModelPath
        ' 
        txtModelPath.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        txtModelPath.Location = New Point(660, 70)
        txtModelPath.Margin = New Padding(3, 2, 3, 2)
        txtModelPath.Name = "txtModelPath"
        txtModelPath.ReadOnly = True
        txtModelPath.Size = New Size(223, 29)
        txtModelPath.TabIndex = 6
        ' 
        ' btnBrowseTraining
        ' 
        btnBrowseTraining.BackColor = Color.Green
        btnBrowseTraining.FlatStyle = FlatStyle.Flat
        btnBrowseTraining.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        btnBrowseTraining.ForeColor = Color.White
        btnBrowseTraining.Location = New Point(141, 112)
        btnBrowseTraining.Margin = New Padding(3, 2, 3, 2)
        btnBrowseTraining.Name = "btnBrowseTraining"
        btnBrowseTraining.Size = New Size(113, 25)
        btnBrowseTraining.TabIndex = 5
        btnBrowseTraining.Text = "Changer"
        btnBrowseTraining.UseVisualStyleBackColor = False
        ' 
        ' txtTrainingPath
        ' 
        txtTrainingPath.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        txtTrainingPath.Location = New Point(30, 70)
        txtTrainingPath.Margin = New Padding(3, 2, 3, 2)
        txtTrainingPath.Name = "txtTrainingPath"
        txtTrainingPath.ReadOnly = True
        txtTrainingPath.Size = New Size(224, 29)
        txtTrainingPath.TabIndex = 4
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        Label3.Location = New Point(635, 40)
        Label3.Name = "Label3"
        Label3.Size = New Size(143, 21)
        Label3.TabIndex = 2
        Label3.Text = "Dossier du Model"
        ' 
        ' lblTrainingPath
        ' 
        lblTrainingPath.AutoSize = True
        lblTrainingPath.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblTrainingPath.Location = New Point(5, 40)
        lblTrainingPath.Name = "lblTrainingPath"
        lblTrainingPath.Size = New Size(148, 21)
        lblTrainingPath.TabIndex = 0
        lblTrainingPath.Text = "Dossier d'Images :"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.WhiteSmoke
        GroupBox1.Controls.Add(nudImagesPerStudent)
        GroupBox1.Controls.Add(lblImagesPer)
        GroupBox1.Controls.Add(nudThreshold)
        GroupBox1.Controls.Add(lblThreshold)
        GroupBox1.Dock = DockStyle.Top
        GroupBox1.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        GroupBox1.Location = New Point(3, 2)
        GroupBox1.Margin = New Padding(3, 2, 3, 2)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 2, 3, 2)
        GroupBox1.Size = New Size(1145, 154)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "MODELE"
        ' 
        ' nudImagesPerStudent
        ' 
        nudImagesPerStudent.Font = New Font("Segoe UI", 12.0F)
        nudImagesPerStudent.Location = New Point(369, 93)
        nudImagesPerStudent.Margin = New Padding(3, 2, 3, 2)
        nudImagesPerStudent.Maximum = New Decimal(New Integer() {80, 0, 0, 0})
        nudImagesPerStudent.Name = "nudImagesPerStudent"
        nudImagesPerStudent.Size = New Size(245, 29)
        nudImagesPerStudent.TabIndex = 3
        ' 
        ' lblImagesPer
        ' 
        lblImagesPer.AutoSize = True
        lblImagesPer.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblImagesPer.Location = New Point(365, 55)
        lblImagesPer.Name = "lblImagesPer"
        lblImagesPer.Size = New Size(245, 21)
        lblImagesPer.TabIndex = 2
        lblImagesPer.Text = "Nombre d’images par étudiant"
        ' 
        ' nudThreshold
        ' 
        nudThreshold.Font = New Font("Segoe UI", 12.0F)
        nudThreshold.Location = New Point(8, 93)
        nudThreshold.Margin = New Padding(3, 2, 3, 2)
        nudThreshold.Maximum = New Decimal(New Integer() {80, 0, 0, 0})
        nudThreshold.Name = "nudThreshold"
        nudThreshold.Size = New Size(268, 29)
        nudThreshold.TabIndex = 1
        ' 
        ' lblThreshold
        ' 
        lblThreshold.AutoSize = True
        lblThreshold.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        lblThreshold.Location = New Point(5, 55)
        lblThreshold.Name = "lblThreshold"
        lblThreshold.Size = New Size(271, 21)
        lblThreshold.TabIndex = 0
        lblThreshold.Text = "Distance de reconnaissance (0–80)"
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(GroupBox4)
        TabPage2.Location = New Point(4, 29)
        TabPage2.Margin = New Padding(3, 2, 3, 2)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3, 2, 3, 2)
        TabPage2.Size = New Size(1151, 615)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Configuration BD"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(lblDBStatus)
        GroupBox4.Controls.Add(btnTestConnection)
        GroupBox4.Controls.Add(txtDBPass)
        GroupBox4.Controls.Add(txtDBUser)
        GroupBox4.Controls.Add(txtDBName)
        GroupBox4.Controls.Add(txtHost)
        GroupBox4.Controls.Add(Label9)
        GroupBox4.Controls.Add(Label8)
        GroupBox4.Controls.Add(Label7)
        GroupBox4.Controls.Add(Label6)
        GroupBox4.Dock = DockStyle.Fill
        GroupBox4.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox4.Location = New Point(3, 2)
        GroupBox4.Margin = New Padding(3, 2, 3, 2)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Padding = New Padding(3, 2, 3, 2)
        GroupBox4.Size = New Size(1145, 611)
        GroupBox4.TabIndex = 0
        GroupBox4.TabStop = False
        GroupBox4.Text = "Paramètres de connexion"
        ' 
        ' lblDBStatus
        ' 
        lblDBStatus.AutoSize = True
        lblDBStatus.Location = New Point(5, 351)
        lblDBStatus.Name = "lblDBStatus"
        lblDBStatus.Size = New Size(65, 20)
        lblDBStatus.TabIndex = 9
        lblDBStatus.Text = "Status : "
        ' 
        ' btnTestConnection
        ' 
        btnTestConnection.Location = New Point(330, 294)
        btnTestConnection.Margin = New Padding(3, 2, 3, 2)
        btnTestConnection.Name = "btnTestConnection"
        btnTestConnection.Size = New Size(185, 31)
        btnTestConnection.TabIndex = 8
        btnTestConnection.Text = "Tester la connexion"
        btnTestConnection.UseVisualStyleBackColor = True
        ' 
        ' txtDBPass
        ' 
        txtDBPass.Location = New Point(223, 210)
        txtDBPass.Margin = New Padding(3, 2, 3, 2)
        txtDBPass.Name = "txtDBPass"
        txtDBPass.Size = New Size(292, 27)
        txtDBPass.TabIndex = 7
        ' 
        ' txtDBUser
        ' 
        txtDBUser.Location = New Point(223, 151)
        txtDBUser.Margin = New Padding(3, 2, 3, 2)
        txtDBUser.Name = "txtDBUser"
        txtDBUser.Size = New Size(292, 27)
        txtDBUser.TabIndex = 6
        ' 
        ' txtDBName
        ' 
        txtDBName.Location = New Point(223, 93)
        txtDBName.Margin = New Padding(3, 2, 3, 2)
        txtDBName.Name = "txtDBName"
        txtDBName.Size = New Size(292, 27)
        txtDBName.TabIndex = 5
        ' 
        ' txtHost
        ' 
        txtHost.Location = New Point(223, 43)
        txtHost.Margin = New Padding(3, 2, 3, 2)
        txtHost.Name = "txtHost"
        txtHost.Size = New Size(292, 27)
        txtHost.TabIndex = 4
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(5, 216)
        Label9.Name = "Label9"
        Label9.Size = New Size(110, 20)
        Label9.TabIndex = 3
        Label9.Text = "Mot de passe :"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(5, 156)
        Label8.Name = "Label8"
        Label8.Size = New Size(156, 20)
        Label8.TabIndex = 2
        Label8.Text = "Nom de l'utilisateur :"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(5, 98)
        Label7.Name = "Label7"
        Label7.Size = New Size(203, 20)
        Label7.TabIndex = 1
        Label7.Text = "Nom de la Base de donnée :"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(5, 45)
        Label6.Name = "Label6"
        Label6.Size = New Size(123, 20)
        Label6.TabIndex = 0
        Label6.Text = "Nom du serveur"
        ' 
        ' TabPage3
        ' 
        TabPage3.BackColor = Color.Lavender
        TabPage3.Controls.Add(GroupBox5)
        TabPage3.Controls.Add(btnSave)
        TabPage3.Controls.Add(Panel1)
        TabPage3.Location = New Point(4, 29)
        TabPage3.Margin = New Padding(3, 2, 3, 2)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3, 2, 3, 2)
        TabPage3.Size = New Size(1151, 615)
        TabPage3.TabIndex = 2
        TabPage3.Text = "Application"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(btnSaveTimes)
        GroupBox5.Controls.Add(dtpP4End)
        GroupBox5.Controls.Add(dtpP4Start)
        GroupBox5.Controls.Add(Label11)
        GroupBox5.Controls.Add(dtpP3End)
        GroupBox5.Controls.Add(dtpP3Start)
        GroupBox5.Controls.Add(Label10)
        GroupBox5.Controls.Add(dtpP2End)
        GroupBox5.Controls.Add(dtpP2Start)
        GroupBox5.Controls.Add(Label5)
        GroupBox5.Controls.Add(dtpP1End)
        GroupBox5.Controls.Add(Label4)
        GroupBox5.Controls.Add(Label2)
        GroupBox5.Controls.Add(dtpP1Start)
        GroupBox5.Controls.Add(Label1)
        GroupBox5.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        GroupBox5.Location = New Point(0, 32)
        GroupBox5.Margin = New Padding(3, 2, 3, 2)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Padding = New Padding(3, 2, 3, 2)
        GroupBox5.Size = New Size(642, 294)
        GroupBox5.TabIndex = 20
        GroupBox5.TabStop = False
        GroupBox5.Text = "Plages horaires"
        ' 
        ' btnSaveTimes
        ' 
        btnSaveTimes.Location = New Point(528, 251)
        btnSaveTimes.Name = "btnSaveTimes"
        btnSaveTimes.Size = New Size(95, 30)
        btnSaveTimes.TabIndex = 21
        btnSaveTimes.Text = "Enregistrer"
        btnSaveTimes.UseVisualStyleBackColor = True
        ' 
        ' dtpP4End
        ' 
        dtpP4End.Format = DateTimePickerFormat.Time
        dtpP4End.Location = New Point(375, 202)
        dtpP4End.Margin = New Padding(3, 2, 3, 2)
        dtpP4End.Name = "dtpP4End"
        dtpP4End.ShowUpDown = True
        dtpP4End.Size = New Size(219, 25)
        dtpP4End.TabIndex = 27
        ' 
        ' dtpP4Start
        ' 
        dtpP4Start.Format = DateTimePickerFormat.Time
        dtpP4Start.Location = New Point(121, 202)
        dtpP4Start.Margin = New Padding(3, 2, 3, 2)
        dtpP4Start.Name = "dtpP4Start"
        dtpP4Start.ShowUpDown = True
        dtpP4Start.Size = New Size(219, 25)
        dtpP4Start.TabIndex = 26
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.Location = New Point(30, 208)
        Label11.Name = "Label11"
        Label11.Size = New Size(66, 15)
        Label11.TabIndex = 25
        Label11.Text = "Periode 4 :"
        ' 
        ' dtpP3End
        ' 
        dtpP3End.Format = DateTimePickerFormat.Time
        dtpP3End.Location = New Point(375, 151)
        dtpP3End.Margin = New Padding(3, 2, 3, 2)
        dtpP3End.Name = "dtpP3End"
        dtpP3End.ShowUpDown = True
        dtpP3End.Size = New Size(219, 25)
        dtpP3End.TabIndex = 24
        ' 
        ' dtpP3Start
        ' 
        dtpP3Start.Format = DateTimePickerFormat.Time
        dtpP3Start.Location = New Point(121, 151)
        dtpP3Start.Margin = New Padding(3, 2, 3, 2)
        dtpP3Start.Name = "dtpP3Start"
        dtpP3Start.ShowUpDown = True
        dtpP3Start.Size = New Size(219, 25)
        dtpP3Start.TabIndex = 23
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label10.Location = New Point(30, 156)
        Label10.Name = "Label10"
        Label10.Size = New Size(66, 15)
        Label10.TabIndex = 22
        Label10.Text = "Periode 3 :"
        ' 
        ' dtpP2End
        ' 
        dtpP2End.Format = DateTimePickerFormat.Time
        dtpP2End.Location = New Point(375, 98)
        dtpP2End.Margin = New Padding(3, 2, 3, 2)
        dtpP2End.Name = "dtpP2End"
        dtpP2End.ShowUpDown = True
        dtpP2End.Size = New Size(219, 25)
        dtpP2End.TabIndex = 21
        ' 
        ' dtpP2Start
        ' 
        dtpP2Start.Format = DateTimePickerFormat.Time
        dtpP2Start.Location = New Point(121, 98)
        dtpP2Start.Margin = New Padding(3, 2, 3, 2)
        dtpP2Start.Name = "dtpP2Start"
        dtpP2Start.ShowUpDown = True
        dtpP2Start.Size = New Size(219, 25)
        dtpP2Start.TabIndex = 20
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(30, 104)
        Label5.Name = "Label5"
        Label5.Size = New Size(66, 15)
        Label5.TabIndex = 19
        Label5.Text = "Periode 2 :"
        ' 
        ' dtpP1End
        ' 
        dtpP1End.Format = DateTimePickerFormat.Time
        dtpP1End.Location = New Point(375, 44)
        dtpP1End.Margin = New Padding(3, 2, 3, 2)
        dtpP1End.Name = "dtpP1End"
        dtpP1End.ShowUpDown = True
        dtpP1End.Size = New Size(219, 25)
        dtpP1End.TabIndex = 18
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label4.Location = New Point(438, 22)
        Label4.Name = "Label4"
        Label4.Size = New Size(23, 15)
        Label4.TabIndex = 17
        Label4.Text = "Fin"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Label2.Location = New Point(179, 22)
        Label2.Name = "Label2"
        Label2.Size = New Size(42, 15)
        Label2.TabIndex = 16
        Label2.Text = "Debut"
        ' 
        ' dtpP1Start
        ' 
        dtpP1Start.Format = DateTimePickerFormat.Time
        dtpP1Start.Location = New Point(121, 44)
        dtpP1Start.Margin = New Padding(3, 2, 3, 2)
        dtpP1Start.Name = "dtpP1Start"
        dtpP1Start.ShowUpDown = True
        dtpP1Start.Size = New Size(219, 25)
        dtpP1Start.TabIndex = 15
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(30, 50)
        Label1.Name = "Label1"
        Label1.Size = New Size(66, 15)
        Label1.TabIndex = 14
        Label1.Text = "Periode 1 :"
        ' 
        ' btnSave
        ' 
        btnSave.Location = New Point(487, 358)
        btnSave.Margin = New Padding(3, 2, 3, 2)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(155, 38)
        btnSave.TabIndex = 18
        btnSave.Text = "Sauvegarder"
        btnSave.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(chkLogs)
        Panel1.Controls.Add(chkDarkMode)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(3, 2)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1145, 31)
        Panel1.TabIndex = 17
        ' 
        ' chkLogs
        ' 
        chkLogs.AutoSize = True
        chkLogs.Location = New Point(354, 7)
        chkLogs.Margin = New Padding(3, 2, 3, 2)
        chkLogs.Name = "chkLogs"
        chkLogs.Size = New Size(92, 25)
        chkLogs.TabIndex = 20
        chkLogs.Text = "Erreur"
        chkLogs.UseVisualStyleBackColor = True
        ' 
        ' chkDarkMode
        ' 
        chkDarkMode.AutoSize = True
        chkDarkMode.Location = New Point(482, 7)
        chkDarkMode.Margin = New Padding(3, 2, 3, 2)
        chkDarkMode.Name = "chkDarkMode"
        chkDarkMode.Size = New Size(157, 25)
        chkDarkMode.TabIndex = 19
        chkDarkMode.Text = "Mode Sombre"
        chkDarkMode.UseVisualStyleBackColor = True
        ' 
        ' FormSettings
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1159, 648)
        Controls.Add(TabControl1)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FormSettings"
        Text = "FormSettings"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        CType(nudMinSize, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(nudImagesPerStudent, ComponentModel.ISupportInitialize).EndInit()
        CType(nudThreshold, ComponentModel.ISupportInitialize).EndInit()
        TabPage2.ResumeLayout(False)
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        TabPage3.ResumeLayout(False)
        GroupBox5.ResumeLayout(False)
        GroupBox5.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents nudThreshold As NumericUpDown
    Friend WithEvents lblThreshold As Label
    Friend WithEvents lblImagesPer As Label
    Friend WithEvents nudImagesPerStudent As NumericUpDown
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtTrainingPath As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTrainingPath As Label
    Friend WithEvents btnBrowseModel As Button
    Friend WithEvents txtModelPath As TextBox
    Friend WithEvents btnBrowseTraining As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lblMinFaceSize As Label
    Friend WithEvents nudMinSize As NumericUpDown
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDBStatus As Label
    Friend WithEvents btnTestConnection As Button
    Friend WithEvents txtDBPass As TextBox
    Friend WithEvents txtDBUser As TextBox
    Friend WithEvents txtDBName As TextBox
    Friend WithEvents txtHost As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents chkLogs As CheckBox
    Friend WithEvents chkDarkMode As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents dtpP4End As DateTimePicker
    Friend WithEvents dtpP4Start As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents dtpP3End As DateTimePicker
    Friend WithEvents dtpP3Start As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents dtpP2End As DateTimePicker
    Friend WithEvents dtpP2Start As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpP1End As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpP1Start As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSaveTimes As Button
End Class
