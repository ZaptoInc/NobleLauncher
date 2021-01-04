<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.GhostTheme1 = New NobleLauncher.GhostTheme()
        Me.GhostControlBox1 = New NobleLauncher.GhostControlBox()
        Me.GhostTabControlLagFree1 = New NobleLauncher.GhostTabControlLagFree()
        Me.InstallPage = New System.Windows.Forms.TabPage()
        Me.Install_DownloadButton = New NobleLauncher.GhostButton()
        Me.DownloadPage = New System.Windows.Forms.TabPage()
        Me.GhostTheme1.SuspendLayout()
        Me.GhostTabControlLagFree1.SuspendLayout()
        Me.InstallPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'GhostTheme1
        '
        Me.GhostTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.GhostTheme1.Colors = New NobleLauncher.Bloom(-1) {}
        Me.GhostTheme1.Controls.Add(Me.GhostControlBox1)
        Me.GhostTheme1.Controls.Add(Me.GhostTabControlLagFree1)
        Me.GhostTheme1.Customization = ""
        Me.GhostTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GhostTheme1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GhostTheme1.Image = Nothing
        Me.GhostTheme1.Location = New System.Drawing.Point(0, 0)
        Me.GhostTheme1.Movable = True
        Me.GhostTheme1.Name = "GhostTheme1"
        Me.GhostTheme1.NoRounding = False
        Me.GhostTheme1.ShowIcon = False
        Me.GhostTheme1.Sizable = True
        Me.GhostTheme1.Size = New System.Drawing.Size(846, 539)
        Me.GhostTheme1.SmartBounds = True
        Me.GhostTheme1.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.GhostTheme1.TabIndex = 0
        Me.GhostTheme1.Text = "Noble Strike Launcher"
        Me.GhostTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.Transparent = False
        '
        'GhostControlBox1
        '
        Me.GhostControlBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GhostControlBox1.Customization = "QEBA/wAAAP9aWlr/"
        Me.GhostControlBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.GhostControlBox1.Image = Nothing
        Me.GhostControlBox1.Location = New System.Drawing.Point(772, 3)
        Me.GhostControlBox1.Name = "GhostControlBox1"
        Me.GhostControlBox1.NoRounding = False
        Me.GhostControlBox1.Size = New System.Drawing.Size(71, 19)
        Me.GhostControlBox1.TabIndex = 1
        Me.GhostControlBox1.Text = "GhostControlBox1"
        Me.GhostControlBox1.Transparent = False
        '
        'GhostTabControlLagFree1
        '
        Me.GhostTabControlLagFree1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GhostTabControlLagFree1.Controls.Add(Me.InstallPage)
        Me.GhostTabControlLagFree1.Controls.Add(Me.DownloadPage)
        Me.GhostTabControlLagFree1.Location = New System.Drawing.Point(12, 31)
        Me.GhostTabControlLagFree1.Name = "GhostTabControlLagFree1"
        Me.GhostTabControlLagFree1.SelectedIndex = 0
        Me.GhostTabControlLagFree1.Size = New System.Drawing.Size(822, 496)
        Me.GhostTabControlLagFree1.TabIndex = 0
        '
        'InstallPage
        '
        Me.InstallPage.BackColor = System.Drawing.Color.Transparent
        Me.InstallPage.Controls.Add(Me.Install_DownloadButton)
        Me.InstallPage.Location = New System.Drawing.Point(4, 25)
        Me.InstallPage.Name = "InstallPage"
        Me.InstallPage.Padding = New System.Windows.Forms.Padding(3)
        Me.InstallPage.Size = New System.Drawing.Size(814, 467)
        Me.InstallPage.TabIndex = 0
        Me.InstallPage.Text = "Install"
        '
        'Install_DownloadButton
        '
        Me.Install_DownloadButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Install_DownloadButton.Color = System.Drawing.Color.Empty
        Me.Install_DownloadButton.Colors = New NobleLauncher.Bloom(-1) {}
        Me.Install_DownloadButton.Customization = ""
        Me.Install_DownloadButton.EnableGlass = True
        Me.Install_DownloadButton.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Install_DownloadButton.Image = Nothing
        Me.Install_DownloadButton.Location = New System.Drawing.Point(323, 407)
        Me.Install_DownloadButton.Name = "Install_DownloadButton"
        Me.Install_DownloadButton.NoRounding = False
        Me.Install_DownloadButton.Size = New System.Drawing.Size(168, 54)
        Me.Install_DownloadButton.TabIndex = 0
        Me.Install_DownloadButton.Text = "Download"
        Me.Install_DownloadButton.Transparent = True
        '
        'DownloadPage
        '
        Me.DownloadPage.BackColor = System.Drawing.Color.Transparent
        Me.DownloadPage.Location = New System.Drawing.Point(4, 25)
        Me.DownloadPage.Name = "DownloadPage"
        Me.DownloadPage.Padding = New System.Windows.Forms.Padding(3)
        Me.DownloadPage.Size = New System.Drawing.Size(814, 467)
        Me.DownloadPage.TabIndex = 1
        Me.DownloadPage.Text = "Download"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.ClientSize = New System.Drawing.Size(846, 539)
        Me.Controls.Add(Me.GhostTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Noble Strike Launcher"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.GhostTheme1.ResumeLayout(False)
        Me.GhostTabControlLagFree1.ResumeLayout(False)
        Me.InstallPage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GhostTheme1 As GhostTheme
    Friend WithEvents GhostTabControlLagFree1 As GhostTabControlLagFree
    Friend WithEvents InstallPage As TabPage
    Friend WithEvents DownloadPage As TabPage
    Friend WithEvents GhostControlBox1 As GhostControlBox
    Friend WithEvents Install_DownloadButton As GhostButton
End Class
