<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormReset
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        lblKomunikat = New Label()
        SuspendLayout()
        '
        ' lblKomunikat
        '
        lblKomunikat.AutoSize = False
        lblKomunikat.Dock = DockStyle.Fill
        lblKomunikat.Font = New Font("Consolas", 14, FontStyle.Bold)
        lblKomunikat.ForeColor = Color.Red
        lblKomunikat.BackColor = Color.Transparent
        lblKomunikat.TextAlign = ContentAlignment.MiddleCenter
        lblKomunikat.Name = "lblKomunikat"
        lblKomunikat.TabIndex = 0
        lblKomunikat.Text = "..."
        '
        ' FormReset
        '
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(420, 120)
        Controls.Add(lblKomunikat)
        Name = "FormReset"
        Text = "Reset"
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblKomunikat As Label

End Class

