Imports WatsonWebsocket

Namespace WebSocket
    Module Index
        Public WithEvents server_ As WatsonWsServer
        Public WithEvents client_ As WatsonWsClient
        Sub StartServer()
            server_ = New WatsonWsServer("127.0.0.1", 26100)
            server_.Start()
        End Sub
        Sub StopServer()
            server_.Stop()
        End Sub
        Sub ConnectClient(uriString As String)
            client_ = New WatsonWsClient(New Uri(uriString))
            client_.Start()
        End Sub
        Sub DisconnectClient()
            client_.Stop()
        End Sub

#Region "Client Handlers"
        Private Sub client_ServerConnected(sender As Object, e As EventArgs) Handles client_.ServerConnected
            WebSocket.Client.ServerConnected()
        End Sub

        Private Sub client_MessageReceived(sender As Object, e As MessageReceivedEventArgs) Handles client_.MessageReceived
            WebSocket.Client.MessageReceived(e)
        End Sub

        Private Sub client_ServerDisconnected(sender As Object, e As EventArgs) Handles client_.ServerDisconnected
            WebSocket.Client.ServerDisconnected()
        End Sub

#End Region

#Region "Server Handlers"
        Private Sub server_ClientConnected(sender As Object, e As ClientConnectedEventArgs) Handles server_.ClientConnected
            WebSocket.Server.ClientConnected(e)
        End Sub

        Private Sub server_ClientDisconnected(sender As Object, e As ClientDisconnectedEventArgs) Handles server_.ClientDisconnected
            WebSocket.Server.ClientDisconnected(e)
        End Sub

        Private Sub server_MessageReceived(sender As Object, e As MessageReceivedEventArgs) Handles server_.MessageReceived
            WebSocket.Server.MessageReceived(e)
        End Sub

        Private Sub server_ServerStopped(sender As Object, e As EventArgs) Handles server_.ServerStopped

        End Sub
#End Region

    End Module
End Namespace

