Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module CommonModule

    Function MathMap(ByVal value As Decimal, ByVal fromSource As Decimal, ByVal toSource As Decimal, ByVal fromTarget As Decimal, ByVal toTarget As Decimal) As Decimal
        Dim result As Decimal = (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget
        Return result
    End Function

    Function hash_file(file As Byte()) As String
        Dim hash = MD5.Create().ComputeHash(file)
        Return ByteArrayToString(hash)
    End Function


    Public Function ByteArrayToString(ByVal arrInput() As Byte) As String
        Dim i As Integer
        Dim sOutput As New StringBuilder(arrInput.Length)
        For i = 0 To arrInput.Length - 1
            sOutput.Append(arrInput(i).ToString("x2"))
        Next
        Return sOutput.ToString()
    End Function

    Public Function StringToByteArray(s As String) As Byte()
        ' remove any spaces from, e.g. "A0 20 34 34"
        s = s.Replace(" "c, "")
        ' make sure we have an even number of digits
        If (s.Length And 1) = 1 Then
            Throw New FormatException("Odd string length when even string length is required.")
        End If

        ' calculate the length of the byte array and dim an array to that
        Dim nBytes = s.Length \ 2
        Dim a(nBytes - 1) As Byte

        ' pick out every two bytes and convert them from hex representation
        For i = 0 To nBytes - 1
            a(i) = Convert.ToByte(s.Substring(i * 2, 2), 16)
        Next

        Return a

    End Function

    Public Function testSelectedPort(ip As String, port As Integer) As Boolean
        ' Function to open a socket to the specified port to see if it is listening

        ' Connect to socket
        Dim testSocket As New System.Net.Sockets.TcpClient()

        Try
            testSocket.Connect(ip, port)
            ' The socket is accepting connections
            testSocket.Close()
            Return True

        Catch ex As Exception
            ' The port is not accepting connections
            Return False
        End Try

        Return False
    End Function
    Function TimeStamp() As Long
        Return CLng(DateTime.UtcNow.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)
    End Function
    Function TimeStamp(date_ As Date) As Long
        Return CLng(date_.Subtract(New DateTime(1970, 1, 1)).TotalMilliseconds)
    End Function


    Public Function CreateSymLink(where As String, fromWhere As String, Optional isDirectory As Boolean = False) As Boolean
        Dim flag As Boolean = Directory.Exists(where) AndAlso Not File.GetAttributes(where).ToString().Contains("ReparsePoint")
        If flag Then
            Directory.Delete(where)
        Else
            Dim flag2 As Boolean = File.Exists(where)
            If flag2 Then
                File.Delete(where)
            End If
        End If
        Return Win32.CreateSymbolicLink(where, fromWhere, If(isDirectory, Win32.SymLinkFlag.Directory, Win32.SymLinkFlag.File))
    End Function
End Module
