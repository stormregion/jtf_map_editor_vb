Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Friend Class ShellMessageFilter
		Implements IMessageFilter

		Public Overrides Function PreFilterMessage(ByRef m As Message) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim gBaseString<char> As GBaseString<char> = 0
			__Dereference((gBaseString<char> + 4)) = 0
			Try
				<Module>.GBaseString<char>.Format(gBaseString<char>, CType((AddressOf <Module>.??_C@_0P@DFNMEEBH@Outer?5HWND?3?5?$CFd?$AA@), __Pointer(Of SByte)), m.HWnd.ToInt32())
				<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), __Pointer(Of SByte)), 5971, CType((AddressOf <Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@), __Pointer(Of SByte)))
				Dim ptr As __Pointer(Of SByte)
				If gBaseString<char> IsNot Nothing Then
					ptr = gBaseString<char>
				Else
					ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				<Module>.GLogger.Log(1, ptr)
				If m.Msg = 288 Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), __Pointer(Of SByte)), 5974, CType((AddressOf <Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@), __Pointer(Of SByte)))
					<Module>.GLogger.Log(1, CType((AddressOf <Module>.??_C@_0P@LIJAPFGP@Outer?5Menuchar?$AA@), __Pointer(Of SByte)))
				End If
				If m.Msg = 279 Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), __Pointer(Of SByte)), 5977, CType((AddressOf <Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@), __Pointer(Of SByte)))
					<Module>.GLogger.Log(1, CType((AddressOf <Module>.??_C@_0BG@NLDNIMEG@Outer?5Init?5menu?5popup?$AA@), __Pointer(Of SByte)))
				End If
				If m.Msg = 43 Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), __Pointer(Of SByte)), 5980, CType((AddressOf <Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@), __Pointer(Of SByte)))
					<Module>.GLogger.Log(1, CType((AddressOf <Module>.??_C@_0P@ICCANDCE@Outer?5DrawItem?$AA@), __Pointer(Of SByte)))
				End If
				If m.Msg = 44 Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), __Pointer(Of SByte)), 5983, CType((AddressOf <Module>.??_C@_0DA@KDHFAGLM@NWorkshop?3?3ShellMessageFilter?3?3P@), __Pointer(Of SByte)))
					<Module>.GLogger.Log(1, CType((AddressOf <Module>.??_C@_0O@ONOCNMLD@Outer?5Measure?$AA@), __Pointer(Of SByte)))
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Return False
		End Function
	End Class
End Namespace
