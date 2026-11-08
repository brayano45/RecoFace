Imports System.Drawing
Imports System.Windows.Forms
Public NotInheritable Class ThemeManager
    Private Sub New()
    End Sub

    Public Shared ReadOnly Property DarkBackColor As Color = Color.FromArgb(34, 40, 49)
    Public Shared ReadOnly Property DarkForeColor As Color = Color.FromArgb(230, 230, 230)
    Public Shared ReadOnly Property LightBackColor As Color = SystemColors.Control
    Public Shared ReadOnly Property LightForeColor As Color = SystemColors.ControlText

    ''' <summary>
    ''' Applique le thème sur le form et tous ses contrôles enfants (récursif).
    ''' </summary>
    Public Shared Sub ApplyTheme(frm As Form, dark As Boolean)
        If frm Is Nothing Then Return

        If dark Then
            frm.BackColor = DarkBackColor
            frm.ForeColor = DarkForeColor
        Else
            frm.BackColor = LightBackColor
            frm.ForeColor = LightForeColor
        End If

        ApplyThemeToControls(frm.Controls, dark)
    End Sub

    Private Shared Sub ApplyThemeToControls(ctrls As Control.ControlCollection, dark As Boolean)
        For Each c As Control In ctrls
            Try
                If TypeOf c Is Panel OrElse TypeOf c Is GroupBox OrElse TypeOf c Is TabPage OrElse TypeOf c Is TabControl Then
                    c.BackColor = If(dark, DarkBackColor, LightBackColor)
                    c.ForeColor = If(dark, DarkForeColor, LightForeColor)
                ElseIf TypeOf c Is Button Then
                    Dim b = CType(c, Button)
                    If dark Then
                        b.BackColor = Color.FromArgb(50, 60, 72)
                        b.ForeColor = DarkForeColor
                        b.FlatStyle = FlatStyle.Flat
                    Else
                        b.BackColor = SystemColors.Control
                        b.ForeColor = LightForeColor
                        b.FlatStyle = FlatStyle.Standard
                    End If
                ElseIf TypeOf c Is Label OrElse TypeOf c Is LinkLabel OrElse TypeOf c Is CheckBox OrElse TypeOf c Is RadioButton OrElse TypeOf c Is ComboBox OrElse TypeOf c Is TextBox OrElse TypeOf c Is NumericUpDown OrElse TypeOf c Is DateTimePicker Then
                    c.BackColor = If(dark, DarkBackColor, LightBackColor)
                    c.ForeColor = If(dark, DarkForeColor, LightForeColor)
                ElseIf TypeOf c Is DataGridView Then
                    Dim dg = CType(c, DataGridView)
                    If dark Then
                        dg.BackgroundColor = DarkBackColor
                        dg.DefaultCellStyle.BackColor = Color.FromArgb(44, 50, 60)
                        dg.DefaultCellStyle.ForeColor = DarkForeColor
                        dg.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 50, 60)
                        dg.ColumnHeadersDefaultCellStyle.ForeColor = DarkForeColor
                        dg.EnableHeadersVisualStyles = False
                    Else
                        dg.BackgroundColor = LightBackColor
                        dg.DefaultCellStyle.BackColor = Color.White
                        dg.DefaultCellStyle.ForeColor = LightForeColor
                        dg.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control
                        dg.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText
                        dg.EnableHeadersVisualStyles = True
                    End If
                Else
                    ' Default fallback
                    c.BackColor = If(dark, DarkBackColor, LightBackColor)
                    c.ForeColor = If(dark, DarkForeColor, LightForeColor)
                End If
            Catch
                ' ignore non-supported properties
            End Try

            ' Recursively apply
            If c.HasChildren Then
                ApplyThemeToControls(c.Controls, dark)
            End If
        Next
    End Sub
End Class
