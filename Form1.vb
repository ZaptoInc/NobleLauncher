Imports System.Environment
Imports System.IO
Imports System.IO.Compression
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
            Dim si As New ProcessStartInfo
            si.FileName = LauncherDefaultPath
            si.Arguments = arg_string
            si.WorkingDirectory = DefaultDirectory
            Process.Start(si)
            End
        Else
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
                End If
            End If

        End If

    End Sub

    Function CheckAndCorrectConfig(cfg As ConfigObject) As Boolean

    End Function

    Private Sub Install_DownloadButton_Click(sender As Object, e As EventArgs) Handles Install_DownloadButton.Click

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
                Else
                    Directory.Delete(d, True)
                End If
            Next
        End If
    End Sub

    Sub DownloadMod(Optional currentver As Integer = 0, Optional reinstall As Boolean = False)
        If CheckIfDownloadIsRequired(currentver, reinstall) Then
            Dim modfolder As String = $"{FileDirectory}\noble"
            If Not Directory.Exists(modfolder) Then
                Directory.CreateDirectory(modfolder)
            End If
            Dim modfolder_csgo = $"{modfolder}\csgo"
            If ModInfo Is Nothing Then
                ModInfo = JsonConvert.DeserializeObject(Of ModObject)(web.DownloadString("https://raw.githubusercontent.com/ZaptoInc/NobleLauncher/main/files/mod.json"))
            End If
            If Not IO.Directory.Exists($"{FileDirectory}/cache") Then
                IO.Directory.CreateDirectory($"{FileDirectory}/cache")
            End If
            Dim latest = ModInfo.vers(ModInfo.latestverid)
            CleanGameInstall(modfolder_csgo)
            For Each f In latest.files
                Select Case f.type
                    Case Mod_Ver_File_TypeEnum.Folder
                        Directory.CreateDirectory($"{modfolder}{f.dir}")
                    Case Mod_Ver_File_TypeEnum.File
                        web.DownloadFile(f.url, $"{modfolder}{f.dir}\{f.name}")
                    Case Mod_Ver_File_TypeEnum.Zip
                        Dim guid_ As String = Guid.NewGuid.ToString.ToString
                        Dim cachefile As String = $"{FileDirectory}/cache/{guid_}.cache"
                        web.DownloadFile(f.url, cachefile)
                        ZipFile.ExtractToDirectory(cachefile, $"{modfolder}{f.dir}")
                        File.Delete(cachefile)
                End Select
            Next

        End If
    End Sub
End Class
