Imports System
Imports System.Runtime.InteropServices

Namespace NWorkshop
	Friend Delegate Sub ToolboxFlagHandler(flag As FlagType, <MarshalAs(UnmanagedType.U1)> value As Boolean)
End Namespace
