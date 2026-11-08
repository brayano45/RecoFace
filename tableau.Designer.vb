<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tableau
    Inherits System.Windows.Forms.UserControl

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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()

        ' Conteneurs principaux
        Me.PanelContent = New System.Windows.Forms.Panel()
        Me.PanelFooter = New System.Windows.Forms.Panel()
        Me.LabelCopyright = New System.Windows.Forms.Label()

        ' Éléments du Dashboard
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ChartCamembert = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.ChartCourbe = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Voir = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dfdate = New System.Windows.Forms.DateTimePicker()
        Me.dbdate = New System.Windows.Forms.DateTimePicker()
        Me.LabelTitreStats = New System.Windows.Forms.Label()

        ' Initialisation
        Me.PanelContent.SuspendLayout()
        Me.PanelFooter.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.ChartCamembert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.ChartCourbe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()

        '
        ' PanelContent (Le bloc qui contient tes graphiques)
        '
        Me.PanelContent.Anchor = System.Windows.Forms.AnchorStyles.None ' Astuce : pas de Dock, on va le centrer par code
        Me.PanelContent.BackColor = System.Drawing.Color.Transparent
        Me.PanelContent.Controls.Add(Me.Panel7)
        Me.PanelContent.Controls.Add(Me.Panel6)
        Me.PanelContent.Controls.Add(Me.Panel5)
        Me.PanelContent.Controls.Add(Me.Panel4)
        Me.PanelContent.Controls.Add(Me.Panel3)
        Me.PanelContent.Controls.Add(Me.Panel2)
        Me.PanelContent.Controls.Add(Me.Panel1)
        Me.PanelContent.Location = New System.Drawing.Point(20, 20) ' Position temporaire
        Me.PanelContent.Name = "PanelContent"
        Me.PanelContent.Size = New System.Drawing.Size(1130, 600) ' Taille fixe optimisée
        Me.PanelContent.TabIndex = 0

        '
        ' PanelFooter (Le pied de page VISIBLE)
        '
        Me.PanelFooter.BackColor = System.Drawing.Color.Teal
        Me.PanelFooter.Controls.Add(Me.LabelCopyright)
        Me.PanelFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelFooter.Location = New System.Drawing.Point(0, 648)
        Me.PanelFooter.Name = "PanelFooter"
        Me.PanelFooter.Size = New System.Drawing.Size(1181, 40)
        Me.PanelFooter.TabIndex = 1

        '
        ' LabelCopyright
        '
        Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelCopyright.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.LabelCopyright.ForeColor = System.Drawing.Color.White ' BLANC
        Me.LabelCopyright.Location = New System.Drawing.Point(0, 0)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(1181, 40)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "ETUGEST © 2025 - Tous droits réservés"
        Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        ' --- REPRISE DU CONTENU (INCHANGÉ MAIS DANS PANELCONTENT) ---

        ' Panel1
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(350, 150)
        Me.Panel1.TabIndex = 0

        ' Label4
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label4.ForeColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(20, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Inscrits actuellement"

        ' Label3
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.Label3.Location = New System.Drawing.Point(15, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 65)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "0"

        ' Label2
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
        Me.Label2.Location = New System.Drawing.Point(15, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "TOTAL ÉTUDIANTS"

        ' Panel2
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(390, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(350, 150)
        Me.Panel2.TabIndex = 1

        ' Label9
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.ForeColor = System.Drawing.Color.Gray
        Me.Label9.Location = New System.Drawing.Point(20, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Aujourd'hui"

        ' Label7
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113)
        Me.Label7.Location = New System.Drawing.Point(15, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 65)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "0"

        ' Label5
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
        Me.Label5.Location = New System.Drawing.Point(15, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 21)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "PRÉSENTS"

        ' Panel3
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(780, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(350, 150)
        Me.Panel3.TabIndex = 2

        ' Label10
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label10.ForeColor = System.Drawing.Color.Gray
        Me.Label10.Location = New System.Drawing.Point(20, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Aujourd'hui"

        ' Label8
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(64, 64, 64)
        Me.Label8.Location = New System.Drawing.Point(15, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 21)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "ABSENTS"

        ' Label6
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60)
        Me.Label6.Location = New System.Drawing.Point(15, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 65)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "0"

        ' Panel4 (Camembert)
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.ChartCamembert)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Location = New System.Drawing.Point(0, 170)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(350, 250)
        Me.Panel4.TabIndex = 3

        ' Label13
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.ForeColor = System.Drawing.Color.DimGray
        Me.Label13.Location = New System.Drawing.Point(15, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(141, 21)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Taux de Présence"

        ' ChartCamembert
        ChartArea1.Name = "ChartArea1"
        Me.ChartCamembert.ChartAreas.Add(ChartArea1)
        Me.ChartCamembert.Dock = System.Windows.Forms.DockStyle.Bottom
        Legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom
        Legend1.Name = "Legend1"
        Me.ChartCamembert.Legends.Add(Legend1)
        Me.ChartCamembert.Location = New System.Drawing.Point(0, 40)
        Me.ChartCamembert.Name = "ChartCamembert"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.ChartCamembert.Series.Add(Series1)
        Me.ChartCamembert.Size = New System.Drawing.Size(350, 210)
        Me.ChartCamembert.TabIndex = 3
        Me.ChartCamembert.Text = "Chart1"

        ' Panel5 (Conteneur Courbe)
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.Label14)
        Me.Panel5.Location = New System.Drawing.Point(390, 170)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(740, 250)
        Me.Panel5.TabIndex = 4

        ' Label14
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.Color.DimGray
        Me.Label14.Location = New System.Drawing.Point(15, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(154, 21)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Évolution Semaine"

        ' Panel6 (Le Graphique Courbe lui-même)
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.ChartCourbe)
        Me.Panel6.Location = New System.Drawing.Point(400, 210)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(720, 200)
        Me.Panel6.TabIndex = 5

        ' ChartCourbe
        ChartArea2.AxisX.LineColor = System.Drawing.Color.LightGray
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea2.AxisY.LineColor = System.Drawing.Color.LightGray
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea2.BackColor = System.Drawing.Color.White
        ChartArea2.Name = "ChartArea1"
        Me.ChartCourbe.ChartAreas.Add(ChartArea2)
        Me.ChartCourbe.Dock = System.Windows.Forms.DockStyle.Fill
        Legend2.Enabled = False
        Legend2.Name = "Legend1"
        Me.ChartCourbe.Legends.Add(Legend2)
        Me.ChartCourbe.Location = New System.Drawing.Point(0, 0)
        Me.ChartCourbe.Name = "ChartCourbe"
        Me.ChartCourbe.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel
        Series2.BorderWidth = 3
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series2.Color = System.Drawing.Color.FromArgb(100, 52, 152, 219)
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.ChartCourbe.Series.Add(Series2)
        Me.ChartCourbe.Size = New System.Drawing.Size(720, 200)
        Me.ChartCourbe.TabIndex = 0

        ' Panel7 (Barre de recherche)
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.Voir)
        Me.Panel7.Controls.Add(Me.Label17)
        Me.Panel7.Controls.Add(Me.Label16)
        Me.Panel7.Controls.Add(Me.dfdate)
        Me.Panel7.Controls.Add(Me.dbdate)
        Me.Panel7.Controls.Add(Me.LabelTitreStats)
        Me.Panel7.Location = New System.Drawing.Point(0, 440)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1130, 80)
        Me.Panel7.TabIndex = 6

        ' Voir
        Me.Voir.BackColor = System.Drawing.Color.FromArgb(52, 152, 219)
        Me.Voir.FlatAppearance.BorderSize = 0
        Me.Voir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Voir.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Voir.ForeColor = System.Drawing.Color.White
        Me.Voir.Location = New System.Drawing.Point(850, 25)
        Me.Voir.Name = "Voir"
        Me.Voir.Size = New System.Drawing.Size(150, 35)
        Me.Voir.TabIndex = 4
        Me.Voir.Text = "Appliquer Filtre"
        Me.Voir.UseVisualStyleBackColor = False

        ' Label17
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(520, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(36, 25)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Au"

        ' Label16
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(220, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 25)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Du"

        ' dfdate
        Me.dfdate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dfdate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dfdate.Location = New System.Drawing.Point(560, 27)
        Me.dfdate.Name = "dfdate"
        Me.dfdate.Size = New System.Drawing.Size(200, 25)
        Me.dfdate.TabIndex = 1

        ' dbdate
        Me.dbdate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dbdate.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dbdate.Location = New System.Drawing.Point(260, 27)
        Me.dbdate.Name = "dbdate"
        Me.dbdate.Size = New System.Drawing.Size(200, 25)
        Me.dbdate.TabIndex = 0

        ' LabelTitreStats
        Me.LabelTitreStats.AutoSize = True
        Me.LabelTitreStats.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelTitreStats.ForeColor = System.Drawing.Color.DimGray
        Me.LabelTitreStats.Location = New System.Drawing.Point(15, 27)
        Me.LabelTitreStats.Name = "LabelTitreStats"
        Me.LabelTitreStats.Size = New System.Drawing.Size(141, 21)
        Me.LabelTitreStats.TabIndex = 5
        Me.LabelTitreStats.Text = "Filtre par Période"

        ' tableau
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(240, 244, 248)
        Me.Controls.Add(Me.PanelContent)
        Me.Controls.Add(Me.PanelFooter)
        Me.Name = "tableau"
        Me.Size = New System.Drawing.Size(1181, 688)

        Me.PanelContent.ResumeLayout(False)
        Me.PanelContent.PerformLayout()
        Me.PanelFooter.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.ChartCamembert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        CType(Me.ChartCourbe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContent As System.Windows.Forms.Panel
    Friend WithEvents PanelFooter As System.Windows.Forms.Panel
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dfdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dbdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Voir As System.Windows.Forms.Button
    Friend WithEvents ChartCamembert As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ChartCourbe As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents LabelTitreStats As System.Windows.Forms.Label

End Class