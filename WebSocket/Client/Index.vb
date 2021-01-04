Imports Newtonsoft.Json.Linq

Namespace WebSocket.Client
    Module Index
        Function CheckIfStarted() As Boolean
            Return testSelectedPort("127.0.0.1", 26100)
        End Function

        Function RequestClientToStart() As Boolean
            If CheckIfStarted() Then
                Try
                    ConnectClient("ws://127.0.0.1:26100")
                    Dim request As New JObject From {
                        {"ver", Form1.LauncherVersion},
                        {"action", "START_REQUEST"}
                    }

                    client_.SendAsync(request.ToString)
                Catch ex As Exception
                    Return False
                End Try
                Return True
            Else
                Return False
            End If
        End Function
    End Module
End Namespace

