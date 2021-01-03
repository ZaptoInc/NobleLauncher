Imports WatsonWebsocket

Namespace WebSocket
    Module Index
        Public WithEvents server As WatsonWsServer
        Public WithEvents client As WatsonWsClient
        Sub StartServer()
            server = New WatsonWsServer("127.0.0.1", 26100)
            server.Start()
        End Sub
        Sub StopServer()
            server.Stop()
        End Sub
        Sub ConnectClient(uriString As String)
            client = New WatsonWsClient(New Uri(uriString))
            client.Start()
        End Sub
        Sub DisconnectClient()
            client.Stop()
        End Sub
    End Module
End Namespace

