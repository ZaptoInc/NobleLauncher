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

#Region "Client Handlers"
        Private Sub client_ServerConnected(sender As Object, e As EventArgs) Handles client.ServerConnected
            WebSocket.Client.ServerConnected()
        End Sub

        Private Sub client_MessageReceived(sender As Object, e As MessageReceivedEventArgs) Handles client.MessageReceived
            WebSocket.Client.MessageReceived(e)
        End Sub

        Private Sub client_ServerDisconnected(sender As Object, e As EventArgs) Handles client.ServerDisconnected
            WebSocket.Client.ServerDisconnected()
        End Sub
#End Region

#Region "Server Handlers"

#End Region

    End Module
End Namespace

