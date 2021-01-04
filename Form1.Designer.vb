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
        Me.MainControl = New NobleLauncher.GhostTabControlLagFree()
        Me.InstallPage = New System.Windows.Forms.TabPage()
        Me.Install_Autoupdate_CheckBox = New System.Windows.Forms.CheckBox()
        Me.Install_DownloadButton = New NobleLauncher.GhostButton()
        Me.DownloadPage = New System.Windows.Forms.TabPage()
        Me.Download_Logs = New System.Windows.Forms.ListBox()
        Me.Download_Progressbar = New System.Windows.Forms.ProgressBar()
        Me.Download_PlayButton = New NobleLauncher.GhostButton()
        Me.PlayPage = New System.Windows.Forms.TabPage()
        Me.GhostTheme1.SuspendLayout()
        Me.MainControl.SuspendLayout()
        Me.InstallPage.SuspendLayout()
        Me.DownloadPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'GhostTheme1
        '
        Me.GhostTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.GhostTheme1.Colors = New NobleLauncher.Bloom(-1) {}
        Me.GhostTheme1.Controls.Add(Me.GhostControlBox1)
        Me.GhostTheme1.Controls.Add(Me.MainControl)
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
        'MainControl
        '
        Me.MainControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MainControl.Controls.Add(Me.InstallPage)
        Me.MainControl.Controls.Add(Me.DownloadPage)
        Me.MainControl.Controls.Add(Me.PlayPage)
        Me.MainControl.Location = New System.Drawing.Point(12, 31)
        Me.MainControl.Name = "MainControl"
        Me.MainControl.SelectedIndex = 0
        Me.MainControl.Size = New System.Drawing.Size(822, 496)
        Me.MainControl.TabIndex = 0
        '
        'InstallPage
        '
        Me.InstallPage.BackColor = System.Drawing.Color.Transparent
        Me.InstallPage.Controls.Add(Me.Install_Autoupdate_CheckBox)
        Me.InstallPage.Controls.Add(Me.Install_DownloadButton)
        Me.InstallPage.Location = New System.Drawing.Point(4, 25)
        Me.InstallPage.Name = "InstallPage"
        Me.InstallPage.Padding = New System.Windows.Forms.Padding(3)
        Me.InstallPage.Size = New System.Drawing.Size(814, 467)
        Me.InstallPage.TabIndex = 0
        Me.InstallPage.Text = "Install"
        '
        'Install_Autoupdate_CheckBox
        '
        Me.Install_Autoupdate_CheckBox.AutoSize = True
        Me.Install_Autoupdate_CheckBox.Checked = True
        Me.Install_Autoupdate_CheckBox.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Install_Autoupdate_CheckBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Install_Autoupdate_CheckBox.Location = New System.Drawing.Point(325, 367)
        Me.Install_Autoupdate_CheckBox.Name = "Install_Autoupdate_CheckBox"
        Me.Install_Autoupdate_CheckBox.Size = New System.Drawing.Size(165, 17)
        Me.Install_Autoupdate_CheckBox.TabIndex = 1
        Me.Install_Autoupdate_CheckBox.Text = "Enable mod auto update"
        Me.Install_Autoupdate_CheckBox.UseVisualStyleBackColor = True
        '
        'Install_DownloadButton
        '
        Me.Install_DownloadButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.DownloadPage.Controls.Add(Me.Download_Logs)
        Me.DownloadPage.Controls.Add(Me.Download_Progressbar)
        Me.DownloadPage.Controls.Add(Me.Download_PlayButton)
        Me.DownloadPage.Location = New System.Drawing.Point(4, 25)
        Me.DownloadPage.Name = "DownloadPage"
        Me.DownloadPage.Padding = New System.Windows.Forms.Padding(3)
        Me.DownloadPage.Size = New System.Drawing.Size(814, 467)
        Me.DownloadPage.TabIndex = 1
        Me.DownloadPage.Text = "Download"
        '
        'Download_Logs
        '
        Me.Download_Logs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Download_Logs.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.Download_Logs.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Download_Logs.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Download_Logs.FormattingEnabled = True
        Me.Download_Logs.Location = New System.Drawing.Point(6, 6)
        Me.Download_Logs.Name = "Download_Logs"
        Me.Download_Logs.Size = New System.Drawing.Size(802, 364)
        Me.Download_Logs.TabIndex = 5
        '
        'Download_Progressbar
        '
        Me.Download_Progressbar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Download_Progressbar.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Download_Progressbar.Location = New System.Drawing.Point(6, 378)
        Me.Download_Progressbar.Name = "Download_Progressbar"
        Me.Download_Progressbar.Size = New System.Drawing.Size(802, 23)
        Me.Download_Progressbar.TabIndex = 4
        '
        'Download_PlayButton
        '
        Me.Download_PlayButton.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Download_PlayButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Download_PlayButton.Color = System.Drawing.Color.Empty
        Me.Download_PlayButton.Colors = New NobleLauncher.Bloom(-1) {}
        Me.Download_PlayButton.Customization = ""
        Me.Download_PlayButton.Enabled = False
        Me.Download_PlayButton.EnableGlass = True
        Me.Download_PlayButton.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Download_PlayButton.Image = Nothing
        Me.Download_PlayButton.Location = New System.Drawing.Point(323, 407)
        Me.Download_PlayButton.Name = "Download_PlayButton"
        Me.Download_PlayButton.NoRounding = False
        Me.Download_PlayButton.Size = New System.Drawing.Size(168, 54)
        Me.Download_PlayButton.TabIndex = 1
        Me.Download_PlayButton.Text = "Play"
        Me.Download_PlayButton.Transparent = True
        '
        'PlayPage
        '
        Me.PlayPage.BackColor = System.Drawing.Color.Transparent
        Me.PlayPage.Location = New System.Drawing.Point(4, 25)
        Me.PlayPage.Name = "PlayPage"
        Me.PlayPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PlayPage.Size = New System.Drawing.Size(814, 467)
        Me.PlayPage.TabIndex = 3
        Me.PlayPage.Text = "Play"
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
        Me.MainControl.ResumeLayout(False)
        Me.InstallPage.ResumeLayout(False)
        Me.InstallPage.PerformLayout()
        Me.DownloadPage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GhostTheme1 As GhostTheme
    Friend WithEvents MainControl As GhostTabControlLagFree
    Friend WithEvents InstallPage As TabPage
    Friend WithEvents DownloadPage As TabPage
    Friend WithEvents GhostControlBox1 As GhostControlBox
    Friend WithEvents Install_DownloadButton As GhostButton
    Friend WithEvents PlayPage As TabPage
    Friend WithEvents Download_PlayButton As GhostButton
    Friend WithEvents Download_Progressbar As ProgressBar
    Friend WithEvents Download_Logs As ListBox
    Friend WithEvents Install_Autoupdate_CheckBox As CheckBox
End Class
