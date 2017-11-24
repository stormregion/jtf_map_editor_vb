Imports Microsoft.VisualC
Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace std
	<DebugInfoInPDB(), MiscellaneousBits(64), NativeCppClass()>
	<StructLayout(LayoutKind.Sequential, Size = 1)>
	Friend Structure allocator<char>
		<DebugInfoInPDB(), MiscellaneousBits(65), CLSCompliant(False), NativeCppClass()>
		<StructLayout(LayoutKind.Sequential, Size = 1)>
		Public Structure rebind<char>
		End Structure

		Public Shared Sub <MarshalCopy>(ptr As __Pointer(Of allocator<char>), ptr2 As __Pointer(Of allocator<char>))
			<Module>.std.allocator<char>.{ctor}(ptr, ptr2)
		End Sub
	End Structure
End Namespace
