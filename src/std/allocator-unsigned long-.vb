Imports Microsoft.VisualC
Imports System
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Namespace std
	<DebugInfoInPDB(), MiscellaneousBits(64), NativeCppClass()>
	<StructLayout(LayoutKind.Sequential, Size = 1)>
	Friend Structure allocator<unsigned long>
		<DebugInfoInPDB(), MiscellaneousBits(65), CLSCompliant(False), NativeCppClass()>
		<StructLayout(LayoutKind.Sequential, Size = 1)>
		Public Structure rebind<unsigned long>
		End Structure

		<DebugInfoInPDB(), MiscellaneousBits(65), CLSCompliant(False), NativeCppClass()>
		<StructLayout(LayoutKind.Sequential, Size = 1)>
		Public Structure rebind<std::_Tree_nod<std::_Tset_traits<unsigned long,std::less<unsigned long>,std::allocator<unsigned long>,0> >::_Node>
		End Structure

		<DebugInfoInPDB(), MiscellaneousBits(65), CLSCompliant(False), NativeCppClass()>
		<StructLayout(LayoutKind.Sequential, Size = 1)>
		Public Structure rebind<std::_Tree_nod<std::_Tset_traits<unsigned long,std::less<unsigned long>,std::allocator<unsigned long>,0> >::_Node *>
		End Structure

		<DebugInfoInPDB(), MiscellaneousBits(65), CLSCompliant(False), NativeCppClass()>
		<StructLayout(LayoutKind.Sequential, Size = 1)>
		Public Structure rebind<char>
		End Structure

		Public Shared Sub <MarshalCopy>(ptr As __Pointer(Of allocator<unsigned long>), ptr2 As __Pointer(Of allocator<unsigned long>))
		End Sub
	End Structure
End Namespace
