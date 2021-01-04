Public Class ModObject
    Public latestver As String
    Public latestverid As Integer
    Public vers As New Dictionary(Of String, Mod_VerObject)
    Public history As Dictionary(Of String, Integer)
End Class

Public Class Mod_VerObject
    Public ver As String
    Public files As New List(Of Mod_Ver_FileObject)
End Class

Public Class Mod_Ver_FileObject
    Public name As String
    Public type As Mod_Ver_File_TypeEnum
    Public dir As String
    Public url As String
End Class

Public Enum Mod_Ver_File_TypeEnum
    Folder = 0
    File = 1
    Zip = 2
End Enum
