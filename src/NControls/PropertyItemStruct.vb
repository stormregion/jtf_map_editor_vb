Imports GRTTI
Imports System
Imports System.Collections
Imports System.Runtime.InteropServices

Namespace NControls
	Public Class PropertyItemStruct
		Inherits PropertyItem

		Public Overrides Sub Refresh()
			Me.Host.RegenerateSubtree(Me.Index)
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Function CanBeExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return __Dereference((__Dereference(CType((Me.Type + 8 / __SizeOf(GClass)), __Pointer(Of Integer))))) <> 0
		End Function

		Public Overrides Function Expand() As ArrayList
			Dim arrayList As ArrayList = New ArrayList()
			Dim ptr As __Pointer(Of GMember) = __Dereference(CType((Me.Type + 8 / __SizeOf(GClass)), __Pointer(Of Integer)))
			Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
			If num <> 0UI Then
				Do
					arrayList.Add(PropertyItem.MakeProperty(New String(num), __Dereference(CType((ptr + 12 / __SizeOf(GMember)), __Pointer(Of Integer))), __Dereference(CType((ptr + 4 / __SizeOf(GMember)), __Pointer(Of Integer))), CType((CType(Me.Var, __Pointer(Of Byte)) + __Dereference(CType((ptr + 8 / __SizeOf(GMember)), __Pointer(Of Integer)))), __Pointer(Of Void)), __Dereference(CType((ptr + 16 / __SizeOf(GMember)), __Pointer(Of Integer))), __Dereference(CType((ptr + 20 / __SizeOf(GMember)), __Pointer(Of Integer))), __Dereference(CType((ptr + 24 / __SizeOf(GMember)), __Pointer(Of Integer))), __Dereference(CType((ptr + 28 / __SizeOf(GMember)), __Pointer(Of Integer)))))
					ptr += 32 / __SizeOf(GMember)
					num = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
				Loop While num <> 0UI
			End If
			Return arrayList
		End Function

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
