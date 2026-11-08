<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCameraRecognition
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

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        pictureBoxCamera = New PictureBox()
        grpCamera = New GroupBox()
        panelCameraControls = New Panel()
        btnReloadModel = New Button()
        btnScan = New Button()
        btnStop = New Button()
        btnStart = New Button()
        grpResult = New GroupBox()
        lblConfidence = New Label()
        lblPeriod = New Label()
        pictureBoxFaceThumb = New PictureBox()
        lblMatricule = New Label()
        lblStudent = New Label()
        lblStatus = New Label()
        grpActions = New GroupBox()
        GroupBox1 = New GroupBox()
        statusStrip = New StatusStrip()
        CType(pictureBoxCamera, ComponentModel.ISupportInitialize).BeginInit()
        grpCamera.SuspendLayout()
        panelCameraControls.SuspendLayout()
        grpResult.SuspendLayout()
        CType(pictureBoxFaceThumb, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pictureBoxCamera
        ' 
        pictureBoxCamera.BorderStyle = BorderStyle.FixedSingle
        pictureBoxCamera.Dock = DockStyle.Fill
        pictureBoxCamera.Location = New Point(3, 25)
        pictureBoxCamera.Name = "pictureBoxCamera"
        pictureBoxCamera.Size = New Size(593, 428)
        pictureBoxCamera.SizeMode = PictureBoxSizeMode.Zoom
        pictureBoxCamera.TabIndex = 0
        pictureBoxCamera.TabStop = False
        ' 
        ' grpCamera
        ' 
        grpCamera.BackColor = Color.WhiteSmoke
        grpCamera.Controls.Add(panelCameraControls)
        grpCamera.Controls.Add(pictureBoxCamera)
        grpCamera.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpCamera.Location = New Point(12, 12)
        grpCamera.Name = "grpCamera"
        grpCamera.Size = New Size(599, 456)
        grpCamera.TabIndex = 1
        grpCamera.TabStop = False
        grpCamera.Text = "CAMERA"
        ' 
        ' panelCameraControls
        ' 
        panelCameraControls.Controls.Add(btnReloadModel)
        panelCameraControls.Controls.Add(btnScan)
        panelCameraControls.Controls.Add(btnStop)
        panelCameraControls.Controls.Add(btnStart)
        panelCameraControls.Dock = DockStyle.Bottom
        panelCameraControls.Location = New Point(3, 373)
        panelCameraControls.Name = "panelCameraControls"
        panelCameraControls.Size = New Size(593, 80)
        panelCameraControls.TabIndex = 2
        ' 
        ' btnReloadModel
        ' 
        btnReloadModel.BackColor = Color.Purple
        btnReloadModel.Enabled = False
        btnReloadModel.FlatStyle = FlatStyle.Flat
        btnReloadModel.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnReloadModel.ForeColor = Color.White
        btnReloadModel.Location = New Point(462, 26)
        btnReloadModel.Name = "btnReloadModel"
        btnReloadModel.Size = New Size(120, 29)
        btnReloadModel.TabIndex = 3
        btnReloadModel.Text = "Actualiser"
        btnReloadModel.UseVisualStyleBackColor = False
        ' 
        ' btnScan
        ' 
        btnScan.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnScan.Enabled = False
        btnScan.FlatStyle = FlatStyle.Flat
        btnScan.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnScan.ForeColor = Color.White
        btnScan.Location = New Point(303, 26)
        btnScan.Name = "btnScan"
        btnScan.Size = New Size(120, 29)
        btnScan.TabIndex = 2
        btnScan.Text = "[Scanner]"
        btnScan.UseVisualStyleBackColor = False
        ' 
        ' btnStop
        ' 
        btnStop.BackColor = Color.Crimson
        btnStop.Enabled = False
        btnStop.FlatStyle = FlatStyle.Flat
        btnStop.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnStop.ForeColor = Color.White
        btnStop.Location = New Point(157, 26)
        btnStop.Name = "btnStop"
        btnStop.Size = New Size(100, 29)
        btnStop.TabIndex = 1
        btnStop.Text = "Arreter" & ChrW(55357) & ChrW(57317)
        btnStop.UseVisualStyleBackColor = False
        ' 
        ' btnStart
        ' 
        btnStart.BackColor = Color.Green
        btnStart.FlatStyle = FlatStyle.Flat
        btnStart.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        btnStart.ForeColor = Color.White
        btnStart.Location = New Point(13, 26)
        btnStart.Name = "btnStart"
        btnStart.Size = New Size(105, 29)
        btnStart.TabIndex = 0
        btnStart.Text = "Demarer⏰"
        btnStart.UseVisualStyleBackColor = False
        ' 
        ' grpResult
        ' 
        grpResult.BackColor = Color.Snow
        grpResult.Controls.Add(lblConfidence)
        grpResult.Controls.Add(lblPeriod)
        grpResult.Controls.Add(pictureBoxFaceThumb)
        grpResult.Controls.Add(lblMatricule)
        grpResult.Controls.Add(lblStudent)
        grpResult.Controls.Add(lblStatus)
        grpResult.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpResult.Location = New Point(629, 12)
        grpResult.Name = "grpResult"
        grpResult.Size = New Size(530, 200)
        grpResult.TabIndex = 2
        grpResult.TabStop = False
        grpResult.Text = "RESULTAT"
        ' 
        ' lblConfidence
        ' 
        lblConfidence.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblConfidence.ForeColor = Color.Indigo
        lblConfidence.Location = New Point(13, 157)
        lblConfidence.Name = "lblConfidence"
        lblConfidence.Size = New Size(285, 24)
        lblConfidence.TabIndex = 7
        lblConfidence.Text = "Confiance : "
        ' 
        ' lblPeriod
        ' 
        lblPeriod.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblPeriod.ForeColor = Color.Indigo
        lblPeriod.Location = New Point(14, 128)
        lblPeriod.Name = "lblPeriod"
        lblPeriod.Size = New Size(285, 24)
        lblPeriod.TabIndex = 6
        lblPeriod.Text = "Periode : "
        ' 
        ' pictureBoxFaceThumb
        ' 
        pictureBoxFaceThumb.Location = New Point(407, 71)
        pictureBoxFaceThumb.Name = "pictureBoxFaceThumb"
        pictureBoxFaceThumb.Size = New Size(120, 105)
        pictureBoxFaceThumb.SizeMode = PictureBoxSizeMode.Zoom
        pictureBoxFaceThumb.TabIndex = 5
        pictureBoxFaceThumb.TabStop = False
        ' 
        ' lblMatricule
        ' 
        lblMatricule.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMatricule.ForeColor = Color.Indigo
        lblMatricule.Location = New Point(13, 96)
        lblMatricule.Name = "lblMatricule"
        lblMatricule.Size = New Size(285, 24)
        lblMatricule.TabIndex = 2
        lblMatricule.Text = "Matricule : "
        ' 
        ' lblStudent
        ' 
        lblStudent.Font = New Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStudent.ForeColor = Color.Indigo
        lblStudent.Location = New Point(13, 64)
        lblStudent.Name = "lblStudent"
        lblStudent.Size = New Size(285, 24)
        lblStudent.TabIndex = 1
        lblStudent.Text = "Etudiant : "
        ' 
        ' lblStatus
        ' 
        lblStatus.Font = New Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblStatus.ForeColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        lblStatus.Location = New Point(14, 35)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(516, 24)
        lblStatus.TabIndex = 0
        lblStatus.Text = "Statut : ........."
        ' 
        ' grpActions
        ' 
        grpActions.BackColor = Color.WhiteSmoke
        grpActions.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        grpActions.Location = New Point(629, 220)
        grpActions.Name = "grpActions"
        grpActions.Size = New Size(331, 160)
        grpActions.TabIndex = 3
        grpActions.TabStop = False
        grpActions.Text = "ACTIONS"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.WhiteSmoke
        GroupBox1.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        GroupBox1.Location = New Point(629, 409)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(331, 160)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        GroupBox1.Text = "ACTIONS"
        ' 
        ' statusStrip
        ' 
        statusStrip.ImageScalingSize = New Size(20, 20)
        statusStrip.Location = New Point(0, 626)
        statusStrip.Name = "statusStrip"
        statusStrip.Size = New Size(1159, 22)
        statusStrip.TabIndex = 5
        statusStrip.Text = "StatusStrip"
        ' 
        ' FormCameraRecognition
        ' 
        AutoScaleDimensions = New SizeF(8F, 19F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(148), CByte(172), CByte(181))
        ClientSize = New Size(1159, 648)
        Controls.Add(statusStrip)
        Controls.Add(GroupBox1)
        Controls.Add(grpActions)
        Controls.Add(grpResult)
        Controls.Add(grpCamera)
        Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "FormCameraRecognition"
        StartPosition = FormStartPosition.CenterScreen
        Text = "ETUGEST"
        CType(pictureBoxCamera, ComponentModel.ISupportInitialize).EndInit()
        grpCamera.ResumeLayout(False)
        panelCameraControls.ResumeLayout(False)
        grpResult.ResumeLayout(False)
        CType(pictureBoxFaceThumb, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents pictureBoxCamera As PictureBox
    Friend WithEvents grpCamera As GroupBox
    Friend WithEvents panelCameraControls As Panel
    Friend WithEvents btnStop As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents btnScan As Button
    Friend WithEvents btnReloadModel As Button
    Friend WithEvents grpResult As GroupBox
    Friend WithEvents lblStudent As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblMatricule As Label
    Friend WithEvents pictureBoxFaceThumb As PictureBox
    Friend WithEvents grpActions As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents statusStrip As StatusStrip
    Friend WithEvents lblConfidence As Label
    Friend WithEvents lblPeriod As Label
End Class