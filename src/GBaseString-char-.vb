Imports Microsoft.VisualC
Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
<DebugInfoInPDB(), MiscellaneousBits(64), NativeCppClass()>
<StructLayout(LayoutKind.Sequential, Size = 8)>
Friend Structure GBaseString<char>
	Public Shared Sub <MarshalCopy>(ptr As __Pointer(Of GBaseString<char>), ptr2 As __Pointer(Of GBaseString<char>))
		Dim num As Integer = __Dereference(CType((ptr2 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer)))
		If num <> 0 Then
			__Dereference(CType((ptr + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = num
			Dim ptr3 As __Pointer(Of Void) = <Module>.malloc(CUInt((num + 1)))
			__Dereference(CType(ptr, __Pointer(Of Integer))) = ptr3
			cpblk(ptr3, __Dereference(CType(ptr2, __Pointer(Of Integer))), __Dereference(CType((ptr + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) + 1)
		Else
			__Dereference(CType((ptr + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0
			__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
		End If
	End Sub

	Public Shared Sub <MarshalDestroy>(ptr As __Pointer(Of GBaseString<char>))
		Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
		If num <> 0UI Then
			<Module>.free(num)
			__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
		End If
	End Sub
End Structure
