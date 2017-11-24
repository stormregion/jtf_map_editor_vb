Imports GRTTI
Imports System
Imports System.Collections
Imports System.Runtime.InteropServices

Namespace NControls
	Public Class PropertyItemArray
		Inherits PropertyItem

		Public Overrides Sub Refresh()
			Me.Host.RegenerateSubtree(Me.Index)
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Function CanBeExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return __Dereference(CType((Me.Type + 44 / __SizeOf(GClass)), __Pointer(Of Integer))) <> 0
		End Function

		Public Overrides Function Expand() As ArrayList
			Dim arrayList As ArrayList = New ArrayList()
			Dim default_value As Single = 0F
			Dim min_value As Single = -3.40282347E+38F
			Dim max_value As Single = 3.40282347E+38F
			Dim step_value As Single = 0.5F
			Dim num As Integer = 0
			Dim num2 As Integer = __Dereference(CType((Me.Type + 44 / __SizeOf(GClass)), __Pointer(Of Integer)))
			If 0 < num2 Then
				Do
					If num2 > 10 Then
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>, CType((AddressOf <Module>.??_C@_04OGKJMPGK@?$CF02d?$AA@), __Pointer(Of SByte)), num)
						Try
							Dim num3 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
							Dim value As __Pointer(Of SByte)
							If num3 <> 0UI Then
								value = num3
							Else
								value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							Dim type As __Pointer(Of GClass) = Me.Type
							arrayList.Add(PropertyItem.MakeProperty(New String(CType(value, __Pointer(Of SByte))), Nothing, __Dereference(CType((type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))), CType((__Dereference(CType((type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))) * num + CType(Me.Var, __Pointer(Of Byte))), __Pointer(Of Void)), default_value, min_value, max_value, step_value))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
					Else
						Dim gBaseString<char>2 As GBaseString<char>
						Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>2, CType((AddressOf <Module>.??_C@_02DPKJAMEF@?$CFd?$AA@), __Pointer(Of SByte)), num)
						Try
							Dim num4 As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
							Dim value2 As __Pointer(Of SByte)
							If num4 <> 0UI Then
								value2 = num4
							Else
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							Dim type As __Pointer(Of GClass) = Me.Type
							arrayList.Add(PropertyItem.MakeProperty(New String(CType(value2, __Pointer(Of SByte))), Nothing, __Dereference(CType((type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))), CType((__Dereference(CType((type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))) * num + CType(Me.Var, __Pointer(Of Byte))), __Pointer(Of Void)), default_value, min_value, max_value, step_value))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
							gBaseString<char>2 = 0
						End If
					End If
					num += 1
					num2 = __Dereference(CType((Me.Type + 44 / __SizeOf(GClass)), __Pointer(Of Integer)))
				Loop While num < num2
			End If
			Return arrayList
		End Function

		Public Overrides Function GetName() As String
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>, CType((AddressOf <Module>.??_C@_04KBDJOJNB@?$FL?$CFd?$FN?$AA@), __Pointer(Of SByte)), __Dereference(CType((Me.Type + 44 / __SizeOf(GClass)), __Pointer(Of Integer))))
			Dim result As String
			Try
				Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
				Dim value As __Pointer(Of SByte)
				If num <> 0UI Then
					value = num
				Else
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				result = Me.Name + New String(CType(value, __Pointer(Of SByte)))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Return result
		End Function

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
