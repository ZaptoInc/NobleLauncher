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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IO.Directory.Exists(DefaultDirectory) Then
            IO.Directory.CreateDirectory(DefaultDirectory)
        End If
        'MsgBox($"DefaultDirectory is {DefaultDirectory}, CurrentDirectory is {CurrentDirectory}")
        If Not CurrentDirectory = DefaultDirectory Then
            Dim LauncherDefaultPath As String = $"{DefaultDirectory}\NobleLauncher.exe"
            If Not File.Exists(LauncherDefaultPath) Then
                IO.File.Copy(CurrentPath, LauncherDefaultPath)
            End If
            Process.Start(LauncherDefaultPath)
            End
        Else
            If Not File.Exists($"{DefaultDirectory}\Newtonsoft.Json.dll") Then
                web.DownloadFile("https://cdn.discordapp.com/attachments/714829721078202429/795253986151104522/Newtonsoft.Json.dll", $"{DefaultDirectory}\Newtonsoft.Json.dll")
            End If
        End If


        'Dim t As JObject = New JObject
        't.Add("test", "success")
        'MsgBox(t.ToString)
    End Sub
End Class
