<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCameraEnroll
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        PictureBoxCamera = New PictureBox()
        btnStop = New Button()
        btnCapture = New Button()
        btnClear = New Button()
        lblCount = New Label()
        FlowPanelThumbs = New FlowLayoutPanel()
        txtMatricule = New TextBox()
        Matricule = New Label()
        btnStart = New Button()
        btnSaveSet = New Button()
        numTarget = New NumericUpDown()
        lblStatus = New Label()
        Label1 = New Label()
        grpList = New GroupBox()
        btnDeleteEnroll = New Button()
        txtSearchEnroll = New TextBox()
        Label2 = New Label()
        dgEnrolled = New DataGridView()
        CType(PictureBoxCamera, ComponentModel.ISupportInitialize).BeginInit()
        CType(numTarget, ComponentModel.ISupportInitialize).BeginInit()
        grpList.SuspendLayout()
        CType(dgEnrolled, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBoxCamera
        ' 
        PictureBoxCamera.BackColor = Color.WhiteSmoke
        PictureBoxCamera.BorderStyle = BorderStyle.Fixed3D
        PictureBoxCamera.Location = New Point(12, 40)
        PictureBoxCamera.Margin = New Padding(3, 2, 3, 2)
        PictureBoxCamera.Name = "PictureBoxCamera"
        PictureBoxCamera.Size = New Size(480, 360)
        PictureBoxCamera.SizeMode = PictureBoxSizeMode.Zoom
        PictureBoxCamera.TabIndex = 0
        PictureBoxCamera.TabStop = False
        ' 
        ' btnStop
        ' 
        btnStop.BackColor = Color.Crimson
        btnStop.Enabled = False
        btnStop.FlatStyle = FlatStyle.Flat
        btnStop.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnStop.ForeColor = Color.White
        btnStop.Location = New Point(130, 415)
        btnStop.Margin = New Padding(3, 2, 3, 2)
        btnStop.Name = "btnStop"
        btnStop.Size = New Size(100, 35)
        btnStop.TabIndex = 1
        btnStop.Text = "Arrêter⏹"
        btnStop.UseVisualStyleBackColor = False
        ' 
        ' btnCapture
        ' 
        btnCapture.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btnCapture.Enabled = False
        btnCapture.FlatStyle = FlatStyle.Flat
        btnCapture.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnCapture.ForeColor = Color.White
        btnCapture.Location = New Point(245, 415)
        btnCapture.Margin = New Padding(3, 2, 3, 2)
        btnCapture.Name = "btnCapture"
        btnCapture.Size = New Size(100, 35)
        btnCapture.TabIndex = 2
        btnCapture.Text = "Capturer✔"
        btnCapture.UseVisualStyleBackColor = False
        ' 
        ' btnClear
        ' 
        btnClear.BackColor = Color.FromArgb(CByte(26), CByte(59), CByte(85))
        btnClear.FlatStyle = FlatStyle.Flat
        btnClear.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnClear.ForeColor = Color.White
        btnClear.Location = New Point(360, 415)
        btnClear.Margin = New Padding(3, 2, 3, 2)
        btnClear.Name = "btnClear"
        btnClear.Size = New Size(100, 35)
        btnClear.TabIndex = 3
        btnClear.Text = "Vider💱"
        btnClear.UseVisualStyleBackColor = False
        ' 
        ' lblCount
        ' 
        lblCount.AutoSize = True
        lblCount.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        lblCount.ForeColor = Color.Green
        lblCount.Location = New Point(12, 9)
        lblCount.Name = "lblCount"
        lblCount.Size = New Size(63, 25)
        lblCount.TabIndex = 4
        lblCount.Text = "0 / 20"
        ' 
        ' FlowPanelThumbs
        ' 
        FlowPanelThumbs.AutoScroll = True
        FlowPanelThumbs.BackColor = Color.White
        FlowPanelThumbs.BorderStyle = BorderStyle.FixedSingle
        FlowPanelThumbs.Location = New Point(12, 465)
        FlowPanelThumbs.Margin = New Padding(3, 2, 3, 2)
        FlowPanelThumbs.Name = "FlowPanelThumbs"
        FlowPanelThumbs.Size = New Size(480, 110)
        FlowPanelThumbs.TabIndex = 5
        ' 
        ' txtMatricule
        ' 
        txtMatricule.Font = New Font("Segoe UI", 12.0F)
        txtMatricule.Location = New Point(515, 65)
        txtMatricule.Margin = New Padding(3, 2, 3, 2)
        txtMatricule.Name = "txtMatricule"
        txtMatricule.ReadOnly = True
        txtMatricule.Size = New Size(219, 29)
        txtMatricule.TabIndex = 6
        ' 
        ' Matricule
        ' 
        Matricule.AutoSize = True
        Matricule.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Matricule.Location = New Point(515, 40)
        Matricule.Name = "Matricule"
        Matricule.Size = New Size(159, 19)
        Matricule.TabIndex = 7
        Matricule.Text = "Matricule sélectionné :"
        ' 
        ' btnStart
        ' 
        btnStart.BackColor = Color.Green
        btnStart.FlatStyle = FlatStyle.Flat
        btnStart.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        btnStart.ForeColor = Color.White
        btnStart.Location = New Point(15, 415)
        btnStart.Margin = New Padding(3, 2, 3, 2)
        btnStart.Name = "btnStart"
        btnStart.Size = New Size(100, 35)
        btnStart.TabIndex = 8
        btnStart.Text = "Caméra📸"
        btnStart.UseVisualStyleBackColor = False
        ' 
        ' btnSaveSet
        ' 
        btnSaveSet.BackColor = Color.DodgerBlue
        btnSaveSet.FlatStyle = FlatStyle.Flat
        btnSaveSet.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        btnSaveSet.ForeColor = Color.White
        btnSaveSet.Location = New Point(515, 161)
        btnSaveSet.Margin = New Padding(3, 2, 3, 2)
        btnSaveSet.Name = "btnSaveSet"
        btnSaveSet.Size = New Size(219, 45)
        btnSaveSet.TabIndex = 9
        btnSaveSet.Text = "💾 SAUVEGARDER"
        btnSaveSet.UseVisualStyleBackColor = False
        ' 
        ' numTarget
        ' 
        numTarget.Font = New Font("Segoe UI", 12.0F)
        numTarget.Location = New Point(515, 120)
        numTarget.Margin = New Padding(3, 2, 3, 2)
        numTarget.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        numTarget.Name = "numTarget"
        numTarget.Size = New Size(80, 29)
        numTarget.TabIndex = 10
        numTarget.Value = New Decimal(New Integer() {20, 0, 0, 0})
        ' 
        ' lblStatus
        ' 
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold Or FontStyle.Italic)
        lblStatus.ForeColor = Color.Blue
        lblStatus.Location = New Point(12, 580)
        lblStatus.Name = "lblStatus"
        lblStatus.Size = New Size(40, 21)
        lblStatus.TabIndex = 11
        lblStatus.Text = "Prêt"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        Label1.Location = New Point(515, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(105, 19)
        Label1.TabIndex = 12
        Label1.Text = "Photos cibles :"
        ' 
        ' grpList
        ' 
        grpList.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        grpList.Controls.Add(btnDeleteEnroll)
        grpList.Controls.Add(txtSearchEnroll)
        grpList.Controls.Add(Label2)
        grpList.Controls.Add(dgEnrolled)
        grpList.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold)
        grpList.Location = New Point(755, 12)
        grpList.Name = "grpList"
        grpList.Size = New Size(392, 624)
        grpList.TabIndex = 13
        grpList.TabStop = False
        grpList.Text = "Liste des Étudiants"
        ' 
        ' btnDeleteEnroll
        ' 
        btnDeleteEnroll.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        btnDeleteEnroll.BackColor = Color.Crimson
        btnDeleteEnroll.FlatStyle = FlatStyle.Flat
        btnDeleteEnroll.ForeColor = Color.White
        btnDeleteEnroll.Location = New Point(6, 570)
        btnDeleteEnroll.Name = "btnDeleteEnroll"
        btnDeleteEnroll.Size = New Size(380, 40)
        btnDeleteEnroll.TabIndex = 2
        btnDeleteEnroll.Text = "🗑 SUPPRIMER L'ENRÔLEMENT"
        btnDeleteEnroll.UseVisualStyleBackColor = False
        ' 
        ' txtSearchEnroll
        ' 
        txtSearchEnroll.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearchEnroll.Location = New Point(90, 25)
        txtSearchEnroll.Name = "txtSearchEnroll"
        txtSearchEnroll.Size = New Size(296, 25)
        txtSearchEnroll.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(6, 28)
        Label2.Name = "Label2"
        Label2.Size = New Size(77, 19)
        Label2.TabIndex = 3
        Label2.Text = "Chercher :"
        ' 
        ' dgEnrolled
        ' 
        dgEnrolled.AllowUserToAddRows = False
        dgEnrolled.AllowUserToDeleteRows = False
        dgEnrolled.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgEnrolled.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgEnrolled.BackgroundColor = Color.White
        dgEnrolled.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgEnrolled.Location = New Point(6, 60)
        dgEnrolled.Name = "dgEnrolled"
        dgEnrolled.ReadOnly = True
        dgEnrolled.RowHeadersVisible = False
        dgEnrolled.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgEnrolled.Size = New Size(380, 500)
        dgEnrolled.TabIndex = 0
        ' 
        ' FormCameraEnroll
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(148), CByte(172), CByte(181))
        ClientSize = New Size(1159, 648)
        Controls.Add(grpList)
        Controls.Add(Label1)
        Controls.Add(lblStatus)
        Controls.Add(numTarget)
        Controls.Add(btnSaveSet)
        Controls.Add(btnStart)
        Controls.Add(Matricule)
        Controls.Add(txtMatricule)
        Controls.Add(FlowPanelThumbs)
        Controls.Add(lblCount)
        Controls.Add(btnClear)
        Controls.Add(btnCapture)
        Controls.Add(btnStop)
        Controls.Add(PictureBoxCamera)
        Margin = New Padding(3, 2, 3, 2)
        Name = "FormCameraEnroll"
        Text = "Enrôlement Étudiant"
        CType(PictureBoxCamera, ComponentModel.ISupportInitialize).EndInit()
        CType(numTarget, ComponentModel.ISupportInitialize).EndInit()
        grpList.ResumeLayout(False)
        grpList.PerformLayout()
        CType(dgEnrolled, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBoxCamera As PictureBox
    Friend WithEvents btnStop As Button
    Friend WithEvents btnCapture As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents lblCount As Label
    Friend WithEvents FlowPanelThumbs As FlowLayoutPanel
    Friend WithEvents txtMatricule As TextBox
    Friend WithEvents Matricule As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents btnSaveSet As Button
    Friend WithEvents numTarget As NumericUpDown
    Friend WithEvents lblStatus As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents grpList As GroupBox
    Friend WithEvents dgEnrolled As DataGridView
    Friend WithEvents txtSearchEnroll As TextBox
    Friend WithEvents btnDeleteEnroll As Button
    Friend WithEvents Label2 As Label
End Class