Imports Newtonsoft.Json.Linq

Namespace WebSocket.Server
    Module Action_START_REQUEST
        Sub START_REQUEST(json As JObject)
            Try
                Form1.WindowState = FormWindowState.Normal
                Form1.GhostTheme1.Visible = True
                Form1.ShowInTaskbar = True
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End Sub

    End Module
End Namespace
