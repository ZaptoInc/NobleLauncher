Imports System.Environment
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class Form1

    Public ReadOnly DefaultDirectory As String = $"{GetFolderPath(SpecialFolder.ApplicationData)}\.noble"
    Public ReadOnly CurrentDirectory As String = Application.StartupPath
    Public ReadOnly CurrentPath As String = Application.ExecutablePath()
    Public ReadOnly ConfigPath As String = $"{DefaultDirectory}\LauncherConfig.json"

    Public ReadOnly LauncherVersion As String = "v0.1.0"

    Dim web As WebClient = New WebClient

    Private args As String()
    Private arg_string As String = " "

    Public Config As ConfigObject = New ConfigObject

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        args = Environment.GetCommandLineArgs()
        For Each arg In args
            arg_string &= $"{arg} "
        Next
        If Not IO.Directory.Exists(DefaultDirectory) Then
            IO.Directory.CreateDirectory(DefaultDirectory)
        End If
        If Not IO.Directory.Exists($"{DefaultDirectory}/cache") Then
            IO.Directory.CreateDirectory($"{DefaultDirectory}/cache")
        End If
        If CurrentDirectory = DefaultDirectory Then
            Dim LauncherDefaultPath As String = $"{DefaultDirectory}\NobleLauncher.exe"
            If Not WebSocket.Client.RequestClientToStart() Then
                Console.WriteLine("not working")
                IO.File.Copy(CurrentPath, LauncherDefaultPath, True)
                Dim si As New ProcessStartInfo
                si.FileName = LauncherDefaultPath
                si.Arguments = arg_string
                si.WorkingDirectory = DefaultDirectory
                Process.Start(si)
            Else
                Console.WriteLine("working")
            End If
            End
        Else
            If Not File.Exists($"{DefaultDirectory}\Newtonsoft.Json.dll") Then
                web.DownloadFile("https://cdn.discordapp.com/attachments/714829721078202429/795253986151104522/Newtonsoft.Json.dll", $"{DefaultDirectory}\Newtonsoft.Json.dll")
            End If
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
            Dim silentstart As Boolean = False

            If WebSocket.Client.RequestClientToStart() Then
                End
            End If

            WebSocket.StartServer()

#Region "arg -silentstart"
            If args.Contains("-silentstart") Then
                silentstart = True
            End If
            If silentstart Then
                Dim thr As New Threading.Thread(Function(x)
                                                    Threading.Thread.Sleep(100)
                                                    Me.WindowState = FormWindowState.Minimized
                                                    GhostTheme1.Visible = False
                                                    Me.ShowInTaskbar = False
                                                End Function)
                thr.Start()
            End If
#End Region
            For Each i In dependencies_dependencies
                Dim currentfile = hash_file(IO.File.ReadAllBytes(i("name")))
                If Not currentfile = i("md5").ToString Then
                    web.DownloadFile(i("url").ToString, i("name"))
                End If
            Next
            If File.Exists(ConfigPath) Then
                Config = JsonConvert.DeserializeObject(Of ConfigObject)(IO.File.ReadAllText(ConfigPath))
            End If
        End If


        'Dim t As JObject = New JObject
        't.Add("test", "success")
        'MsgBox(t.ToString)
    End Sub

    Function CheckAndCorrectConfig(cfg As ConfigObject) As Boolean

    End Function

    Private Sub Install_DownloadButton_Click(sender As Object, e As EventArgs) Handles Install_DownloadButton.Click

    End Sub

    Sub CleanGameInstall(path As String)
        If Directory.Exists(path) Then
            For Each f In Directory.GetFiles(path)
                File.Delete(f)
            Next
            For Each d In Directory.GetDirectories(path)
                If d.EndsWith("replays") Then
                ElseIf d.EndsWith("maps") Then
                Else
                    Directory.Delete(d, True)
                End If
            Next
        End If
    End Sub

    Sub DownloadMod()
        Dim modfolder As String = $"{DefaultDirectory}\noble"
        If Not Directory.Exists(modfolder) Then
            Directory.CreateDirectory(modfolder)
        End If
        Dim modfolder_csgo = $"{modfolder}\csgo"
        CleanGameInstall(modfolder_csgo)
    End Sub
End Class
