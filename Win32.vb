Imports System
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Friend Module Win32
	Friend Enum SymLinkFlag
		File
		Directory
	End Enum

	Public Const SW_SHOWMAXIMIZED As Integer = 3

	'Public Declare Function CreateSymbolicLink Lib "kernel32.dll" (lpSymlinkFileName As String, lpTargetFileName As String, dwFlags As Win32.SymLinkFlag) As <MarshalAs(UnmanagedType.I1)>
	'Boolean

	<DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
	Public Function CreateSymbolicLink(ByVal lpSymlinkFileName As String, ByVal lpTargetFileName As String, ByVal dwFlags As Win32.SymLinkFlag) As Boolean
	End Function

	Public Declare Function ShowWindow Lib "user32.dll" (hWnd As IntPtr, nCmdShow As Integer) As Boolean

	Public Function IsAdministrator() As Boolean
		Dim current As WindowsIdentity = WindowsIdentity.GetCurrent()
		Dim windowsPrincipal As WindowsPrincipal = New WindowsPrincipal(current)
		Return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator)
	End Function
End Module