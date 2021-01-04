

Imports Newtonsoft.Json.Linq
Imports WatsonWebsocket

Namespace WebSocket.Server
    Module ClientConnectedExecuter

        Sub ClientConnected(e As ClientConnectedEventArgs)
            Dim resp As New JObject
            resp.Add("ver", Form1.LauncherVersion)
            resp.Add("action", "CLIENT_CHECK")
            server_.SendAsync(e.IpPort, resp.ToString)
        End Sub
    End Module
End Namespace


