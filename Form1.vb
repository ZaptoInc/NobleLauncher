Imports System.Environment
Imports System.IO
Imports System.IO.Compression
Imports System.Media
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    Public ReadOnly DefaultDirectory As String = $"{GetFolderPath(SpecialFolder.ApplicationData)}\.noble"
    Public FileDirectory As String = DefaultDirectory
    Public ReadOnly CurrentDirectory As String = Application.StartupPath
    Public ReadOnly CurrentPath As String = Application.ExecutablePath()
    Public ReadOnly ConfigPath As String = $"{DefaultDirectory}\LauncherConfig.json"

    Public ReadOnly LauncherVersion As String = "v0.1.0"

    Dim web As WebClient = New WebClient

    Private args As String()
    Private arg_string As String = " "

    Public Config As ConfigObject = New ConfigObject

    Public ModInfo As ModObject = Nothing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        args = Environment.GetCommandLineArgs()
        For Each arg In args
            arg_string &= $"{arg} "
        Next
        If Not IO.Directory.Exists(DefaultDirectory) Then
            IO.Directory.CreateDirectory(DefaultDirectory)
        End If
        If Not CurrentDirectory = DefaultDirectory Then
            Dim LauncherDefaultPath As String = $"{DefaultDirectory}\NobleLauncher.exe"
            Try
                IO.File.Copy(CurrentPath, LauncherDefaultPath, True)
            Catch ex As Exception

            End Try


            Process.Start(New ProcessStartInfo With {
                .FileName = LauncherDefaultPath, .Arguments = arg_string, .WorkingDirectory = DefaultDirectory
            })
            End
        Else
#Region "-createsymlink"
            If args.Contains("-createsymlink") Then
                If Win32.IsAdministrator Then
                    Dim initaldirectory As String = "C:\Program Files (x86)\Steam\steamapps\common\Counter-Strike Global Offensive"
                    If Not Directory.Exists(initaldirectory) Then
                        initaldirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                    End If
                    Dim dialog As New OpenFileDialog With {.Filter = "csgo.exe|csgo.exe", .InitialDirectory = initaldirectory, .Multiselect = False}
                    Dim csgoDirectory = Nothing
                    If dialog.ShowDialog = DialogResult.OK Then
                        csgoDirectory = dialog.FileName.Replace("\csgo.exe", "")
                    Else
                        MsgBox("Sorry, you closed me and i don't know where csgo is located, i can't do anything", MsgBoxStyle.OkOnly, "Ho Ho...")
                        End
                    End If

                    Dim baseDirectory As String = $"{FileDirectory}\noble"
                    CreateSymLink(baseDirectory + "/csgo/maps/workshop", csgoDirectory + "/csgo/maps/workshop", True)
                    CreateSymLink(baseDirectory + "/csgo/panorama/fonts", csgoDirectory + "/csgo/panorama/fonts", True)
                    Dim flag4 As Boolean = Directory.Exists(baseDirectory + "/csgo/maps/workshop") AndAlso Not File.GetAttributes(baseDirectory + "/csgo/maps/workshop").ToString().Contains("ReparsePoint")
                    If flag4 Then
                        Directory.Delete(baseDirectory + "/csgo/maps/workshop")
                        File.Create(baseDirectory + "/csgo/maps/workshop")
                    Else
                        Dim flag5 As Boolean = Not Directory.Exists(baseDirectory + "/csgo/maps/workshop") AndAlso Not File.Exists(baseDirectory + "/csgo/maps/workshop")
                        If flag5 Then
                            File.Create(baseDirectory + "/csgo/maps/workshop")
                        End If
                    End If
                    Dim flag6 As Boolean = Directory.Exists(baseDirectory + "/csgo/panorama/fonts") AndAlso Not File.GetAttributes(baseDirectory + "/csgo/panorama/fonts").ToString().Contains("ReparsePoint")
                    If flag6 Then
                        Directory.Delete(baseDirectory + "/csgo/panorama/fonts")
                        File.Create(baseDirectory + "/csgo/panorama/fonts")
                    Else
                        Dim flag7 As Boolean = Not Directory.Exists(baseDirectory + "/csgo/panorama/fonts") AndAlso Not File.Exists(baseDirectory + "/csgo/panorama/fonts")
                        If flag7 Then
                            File.Create(baseDirectory + "/csgo/panorama/fonts")
                        End If
                    End If
                Else
                    If MsgBox("Sorry, i am Not launched With administrator permission, would you Like To Try again?", MsgBoxStyle.YesNo, "Admin permission") = MsgBoxResult.Yes Then
                        Dim pr = Process.Start(New ProcessStartInfo With {.FileName = CurrentPath, .Arguments = arg_string, .Verb = "runas"})
                        End
                    Else
                        End
                    End If
                End If
            End If
#End Region
            Try
                If Not File.Exists($"{DefaultDirectory}\Newtonsoft.Json.dll") Then
                    web.DownloadFile("https://cdn.discordapp.com/attachments/714829721078202429/795253986151104522/Newtonsoft.Json.dll", $"{DefaultDirectory}\Newtonsoft.Json.dll")
                Else
                    If Not hash_file(IO.File.ReadAllBytes($"{DefaultDirectory}\Newtonsoft.Json.dll")) = "6815034209687816d8cf401877ec8133" Then
                        web.DownloadFile("https://cdn.discordapp.com/attachments/714829721078202429/795253986151104522/Newtonsoft.Json.dll", $"{DefaultDirectory}\Newtonsoft.Json.dll")
                    End If
                End If
            Catch ex As Exception
                MsgBox("Could not download or verify dependency 'Newtonsoft.Json.dll'", MsgBoxStyle.Critical + MsgBoxStyle.YesNoCancel)
            End Try
            Dim dependencies As JObject = JObject.Parse(web.DownloadString("https://raw.githubusercontent.com/ZaptoInc/NobleLauncher/main/files/dependencies.json"))
            Dim dependencies_dependencies As JArray = dependencies("dependencies")
#Region "arg -generatemd5values"
            If args.Contains("-generatemd5values") Then
                Dim result As String = ""
                For Each i In dependencies_dependencies
                    result &= $"{i("name")} {hash_file(IO.File.ReadAllBytes(i("name")))}{vbCrLf}"
                Next
                IO.File.WriteAllText("md5values.txt", result)
                End
            End If
#End Region
            For Each i In dependencies_dependencies
                Dim currentfile = hash_file(IO.File.ReadAllBytes(i("name")))
                If Not currentfile = i("md5").ToString Then
                    web.DownloadFile(i("url").ToString, i("name"))
                End If
            Next
            Dim silentstart As Boolean = False

            If WebSocket.Client.RequestClientToStart() Then
                End
            End If

            WebSocket.StartServer()

            If IO.Directory.Exists($"{FileDirectory}/cache") Then
                IO.Directory.Delete($"{FileDirectory}/cache", True)
            End If
            IO.Directory.CreateDirectory($"{FileDirectory}/cache")

#Region "arg -silentstart"
            If args.Contains("-silentstart") Then
                silentstart = True
            End If
            If silentstart Then
                Dim thr As New Threading.Thread(Sub(x)
                                                    Threading.Thread.Sleep(100)
                                                    Me.WindowState = FormWindowState.Minimized
                                                    GhostTheme1.Visible = False
                                                    Me.ShowInTaskbar = False
                                                End Sub)
                thr.Start()
            End If
#End Region
            If File.Exists(ConfigPath) Then
                Config = JsonConvert.DeserializeObject(Of ConfigObject)(IO.File.ReadAllText(ConfigPath))
            End If
            If Config.mod_ver > 0 Then
                If CheckIfDownloadIsRequired(Config.mod_ver) Then
                    If Config.auto_update_game Then
                        DownloadMod(Config.mod_ver)
                    Else
                        Dim thr As New Threading.Thread(Sub(x)
                                                            Threading.Thread.Sleep(100)
                                                            Dim mb_result = MsgBox("A new version of NOBLE Strike is available, would you like to download it?")
                                                            If mb_result = MsgBoxResult.Yes Then
                                                                DownloadMod(Config.mod_ver)
                                                            End If
                                                        End Sub)
                        thr.Start()

                    End If
                Else
                    MainControl.SelectedTab = PlayPage
                End If
            End If

        End If

    End Sub

    Function CheckAndCorrectConfig(cfg As ConfigObject) As Boolean

    End Function

    Private Sub Install_DownloadButton_Click(sender As Object, e As EventArgs) Handles Install_DownloadButton.Click
        DownloadMod(Config.mod_ver)
    End Sub

    Function CheckIfDownloadIsRequired(Optional currentver As Integer = 0, Optional reinstall As Boolean = False) As Boolean
        If ModInfo Is Nothing Then
            ModInfo = JsonConvert.DeserializeObject(Of ModObject)(web.DownloadString("https://raw.githubusercontent.com/ZaptoInc/NobleLauncher/main/files/mod.json"))
        End If
        If reinstall = True Then
            Return True
        Else
            If currentver > 0 Then
                If ModInfo.latestverid > currentver Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return True
            End If
        End If
    End Function

    Sub CleanGameInstall(path As String)
        If Directory.Exists(path) Then
            For Each f In Directory.GetFiles(path)
                File.Delete(f)
            Next
            For Each d In Directory.GetDirectories(path)
                If d.EndsWith("replays") Then
                ElseIf d.EndsWith("maps") Then
                ElseIf d.EndsWith("cfg") Then
                ElseIf d.EndsWith("panorama") Then
                Else
                    Directory.Delete(d, True)
                End If
            Next
        End If
    End Sub
    Dim downloadlogs As String = ""
    Sub DownloadMod(Optional currentver As Integer = 0, Optional reinstall As Boolean = False)
        MainControl.SelectedTab = DownloadPage
        Download_Logs.Items.Clear()
        downloadlogs = ""
        If CheckIfDownloadIsRequired(currentver, reinstall) Then
            Dim modfolder As String = $"{FileDirectory}\noble"
            If Not Directory.Exists(modfolder) Then
                Directory.CreateDirectory(modfolder)
            End If
            Dim modfolder_csgo = $"{modfolder}\csgo"
            If ModInfo Is Nothing Then
                ModInfo = JsonConvert.DeserializeObject(Of ModObject)(web.DownloadString("https://raw.githubusercontent.com/ZaptoInc/NobleLauncher/main/files/mod.json"))
                Application.DoEvents()
            End If
            If Not IO.Directory.Exists($"{FileDirectory}/cache") Then
                IO.Directory.CreateDirectory($"{FileDirectory}/cache")
            End If
            Dim latest = ModInfo.vers(ModInfo.latestverid)
            CleanGameInstall(modfolder_csgo)
            Download_Progressbar.Maximum = latest.files.Count
            Dim failedfiles As Boolean = False
            For Each f In latest.files
                Application.DoEvents()

                Select Case f.type
                    Case Mod_Ver_File_TypeEnum.Folder
                        Try
                            AddDownloadLog($"Creating directory {modfolder}{f.dir}")
                            Application.DoEvents()
                            Directory.CreateDirectory($"{modfolder}{f.dir}")
                        Catch ex As Exception
                            AddDownloadLog($"/!\ERROR/!\ Failed to creating directory {modfolder}{f.dir}: {ex.ToString}")
                            failedfiles = True
                            Application.DoEvents()
                        End Try
                    Case Mod_Ver_File_TypeEnum.File
                        Try
                            AddDownloadLog($"Downloading file {f.dir}{f.name}")

                            Application.DoEvents()
                            web.DownloadFile(f.url, $"{modfolder}{f.dir}\{f.name}")
                            AddDownloadLog($"Downloaded file {f.dir}{f.name}")
                            Application.DoEvents()
                        Catch ex As Exception
                            AddDownloadLog($"/!\ERROR/!\ Failed to download file {f.name}: {ex.ToString}")
                            failedfiles = True
                            Application.DoEvents()
                        End Try
                    Case Mod_Ver_File_TypeEnum.Zip
                        Try
                            Dim guid_ As String = Guid.NewGuid.ToString.ToString
                            Dim cachefile As String = $"{FileDirectory}/cache/{guid_}.cache"
                            AddDownloadLog($"Downloading Zip {f.name}")
                            Application.DoEvents()
                            web.DownloadFile(f.url, cachefile)
                            AddDownloadLog($"Downloaded Zip {f.name}")
                            Application.DoEvents()
                            AddDownloadLog($"UnZipping {f.name}")
                            Application.DoEvents()
                            Using archive As ZipArchive = ZipFile.OpenRead(cachefile)
                                For Each entry As ZipArchiveEntry In archive.Entries
                                    Try
                                        Dim entryFullname = Path.Combine($"{modfolder}{f.dir}", entry.FullName)
                                        Dim entryPath = Path.GetDirectoryName(entryFullname)
                                        If (Not (Directory.Exists(entryPath))) Then
                                            Directory.CreateDirectory(entryPath)
                                        End If

                                        Dim entryFn = Path.GetFileName(entryFullname)
                                        If (Not String.IsNullOrEmpty(entryFn)) Then
                                            entry.ExtractToFile(entryFullname, True)
                                        End If
                                        AddDownloadLog($"Extracted {entry.FullName} from {f.name}")
                                        Application.DoEvents()
                                    Catch ex As Exception
                                        AddDownloadLog($"/!\ERROR/!\ Failed to extract {entry.FullName} from {f.name}: {ex.ToString}")
                                        failedfiles = True
                                        Application.DoEvents()
                                    End Try
                                Next
                            End Using
                            AddDownloadLog($"UnZipped {f.name}")
                            Application.DoEvents()
                            File.Delete(cachefile)
                        Catch ex As Exception
                            AddDownloadLog($"/!\ERROR/!\ Failed to download or unZip {f.name}: {ex.ToString}")
                            failedfiles = True
                            Application.DoEvents()
                        End Try
                End Select
                Download_Logs.SelectedIndex = Download_Logs.Items.Count - 1
                Download_Logs.SelectedIndex = -1
                Download_Progressbar.Value += 1
            Next
            Config.mod_ver = ModInfo.latestverid
            IO.File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(Config))
            If failedfiles Then
                If Not Directory.Exists($"{DefaultDirectory}\logs") Then
                    Directory.CreateDirectory($"{DefaultDirectory}\logs")
                End If
                Dim logfilepath = $"{DefaultDirectory}\logs\downloadlog_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.log"
                IO.File.WriteAllText(logfilepath, downloadlogs)
                If MsgBox("There was at least one error while downloading the game, whould you like to see the log file? (this can be useful if you need support)", MsgBoxStyle.YesNo, "Error occurred") = MsgBoxResult.Yes Then
                    Process.Start("explorer.exe", $"/select,""{logfilepath}""")
                End If
            End If

            Dim baseDirectory As String = $"{FileDirectory}\noble"
            Dim flag3 As Boolean = Not Win32.IsAdministrator() AndAlso (File.Exists(baseDirectory + "/csgo/maps") OrElse File.Exists(baseDirectory + "/csgo/maps/workshop") OrElse (Not File.Exists(baseDirectory + "/csgo/maps/workshop") AndAlso Not Directory.Exists(baseDirectory + "/csgo/maps/workshop")) OrElse (Directory.Exists(baseDirectory + "/csgo/maps/workshop") AndAlso Not File.GetAttributes(baseDirectory + "/csgo/maps/workshop").ToString().Contains("ReparsePoint")) OrElse File.Exists(baseDirectory + "/csgo/panorama/fonts") OrElse (Not File.Exists(baseDirectory + "/csgo/panorama/fonts") AndAlso Not Directory.Exists(baseDirectory + "/csgo/panorama/fonts")) OrElse (Directory.Exists(baseDirectory + "/csgo/panorama/fonts") AndAlso Not File.GetAttributes(baseDirectory + "/csgo/panorama/fonts").ToString().Contains("ReparsePoint")))
            If flag3 Then
                SystemSounds.Exclamation.Play()
                Dim allowlink As MsgBoxResult = MsgBox("Sir, permission to make the link between CS:GO and Noble Strike for the workshop and panorama folders? That way they don't make you lag and don't have to redownload em?", MessageBoxButtons.YesNo, "Admin permission")
                If allowlink = MsgBoxResult.Yes Then
                    Dim pr = Process.Start(New ProcessStartInfo With {.FileName = CurrentPath, .Arguments = "-createsymlink", .Verb = "runas"})
                    pr.WaitForExit()
                End If
            End If
        End If
    End Sub
    Sub AddDownloadLog(log As String)
        downloadlogs &= vbCrLf & "[" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & "]" & log
        Download_Logs.Items.Add(log)
    End Sub

    Private Sub Download_PlayButton_Click(sender As Object, e As EventArgs) Handles Download_PlayButton.Click
        MainControl.SelectedTab = PlayPage
    End Sub

    Private Sub Install_Autoupdate_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Install_Autoupdate_CheckBox.CheckedChanged
        If Install_Autoupdate_CheckBox.Checked = True Then
            Install_Autoupdate_CheckBox.CheckState = CheckState.Indeterminate
        End If
        Config.auto_update_game = Install_Autoupdate_CheckBox.Checked
        IO.File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(Config))
    End Sub
End Class
