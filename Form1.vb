Imports System.Environment
Imports System.IO
Imports System.Net
Imports Newtonsoft.Json.Linq

Public Class Form1

    Public ReadOnly DefaultDirectory As String = $"{GetFolderPath(SpecialFolder.ApplicationData)}\.noble"
    Public ReadOnly CurrentDirectory As String = Application.StartupPath
    Public ReadOnly CurrentPath As String = Application.ExecutablePath()

    Public ReadOnly LauncherVertion As String = "v0.1.0"

    Dim web As WebClient = New WebClient

    Private args As String()
    Private arg_string As String = " "

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        args = Environment.GetCommandLineArgs()
        For Each arg In args
            arg_string &= $"{arg} "
        Next
        If Not IO.Directory.Exists(DefaultDirectory) Then
            IO.Directory.CreateDirectory(DefaultDirectory)
        End If
        'MsgBox($"DefaultDirectory is {DefaultDirectory}, CurrentDirectory is {CurrentDirectory}")
        If CurrentDirectory = DefaultDirectory Then
            Dim LauncherDefaultPath As String = $"{DefaultDirectory}\NobleLauncher.exe"
            'If Not File.Exists(LauncherDefaultPath) Then
            IO.File.Copy(CurrentPath, LauncherDefaultPath, True)
            'End If
            Process.Start(LauncherDefaultPath)
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

#Region "-silentstart"
            If args.Contains("-silentstart") Then
                Me.Hide()
            End If
#End Region
            Dim dependencies_individials As JObject = dependencies("individials")
            For Each i In dependencies_dependencies
                Dim currentfile = hash_file(IO.File.ReadAllBytes(i("name")))
                If currentfile IsNot i("md5") Then
                    web.DownloadFile(i("url").ToString, i("name"))
                End If
            Next

        End If


        'Dim t As JObject = New JObject
        't.Add("test", "success")
        'MsgBox(t.ToString)
    End Sub
End Class
