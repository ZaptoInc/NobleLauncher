Imports Newtonsoft.Json.Linq
Imports WatsonWebsocket

Namespace WebSocket.Server
    Module MessageReceivedExecuter

        Sub MessageReceived(e As MessageReceivedEventArgs)
            Dim json As JObject = JObject.Parse(Text.Encoding.UTF8.GetString(e.Data))
            json.Add("ip", e.IpPort)

            Select Case json("action").ToString
                Case "START_REQUEST"
                    START_REQUEST(json)
            End Select
        End Sub
    End Module
End Namespace







