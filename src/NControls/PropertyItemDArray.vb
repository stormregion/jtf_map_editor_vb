Imports GRTTI
Imports System
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyItemDArray
		Inherits PropertyItemInteger

		Protected Overrides Function GetValue() As Long
			Return CLng((__Dereference(CType((CType(Me.Var, __Pointer(Of Byte)) + 4), __Pointer(Of Integer)))))
		End Function

		Protected Overrides Sub SetValue(ival As Long)
			Dim var As __Pointer(Of GArrayHeader) = CType(Me.Var, __Pointer(Of GArrayHeader))
			Dim num As Integer = __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer)))
			Dim num2 As Long = CLng(num)
			If num2 <> ival Then
				If num2 < ival Then
					If CLng((__Dereference(CType((var + 8 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))))) < ival Then
						Dim ptr As __Pointer(Of Void) = <Module>.realloc(__Dereference(CType(var, __Pointer(Of Integer))), CUInt((CInt((CLng((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))))) * ival)))))
						__Dereference(CType(var, __Pointer(Of Integer))) = ptr
						Dim num3 As Integer = __Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))
						Dim num4 As Integer = __Dereference(CType((var + 8 / __SizeOf(GArrayHeader)), __Pointer(Of Integer)))
						initblk(num3 * num4 + CType(ptr, __Pointer(Of Byte)), 0, CInt(((ival - CLng(num4)) * CLng(num3))))
						__Dereference(CType((var + 8 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) = CInt(ival)
					End If
					__Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) = CInt(ival)
				Else If num2 > ival Then
					If __Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 40)) <> 0 Then
						Dim num5 As Integer = num
						If CLng(num5) < ival Then
							Do
								Dim type As __Pointer(Of GClass) = Me.Type
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), __Dereference(CType((type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))) * num5 + __Dereference(CType(var, __Pointer(Of Integer))), __Dereference((__Dereference(CType((type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 40)))
								num5 += 1
							Loop While CLng(num5) < ival
						End If
					End If
					Dim num6 As Long = CLng((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
					initblk(CInt((num6 * ival)) + __Dereference(CType(var, __Pointer(Of Integer))), 0, CInt(((CLng((__Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))))) - ival) * num6)))
					__Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) = CInt(ival)
				End If
				Me.Host.RegenerateSubtree(Me.Index)
				Me.Host.RaiseItemChanged()
				Me.Host.InvalidateViewControl()
			End If
		End Sub

		Public Sub New()
			Try
				Me.LowerBound = 0L
				Me.UpperBound = 255L
				Me.StepValue = 1L
				Me.DefaultValue = 0L
			Catch 
				MyBase.{dtor}()
				Throw
			End Try
		End Sub

		Public Overrides Sub Refresh()
			Me.EditControl.Value = CLng((__Dereference(CType((CType(Me.Var, __Pointer(Of Byte)) + 4), __Pointer(Of Integer)))))
			Me.EditControl.RaiseValidate()
			Me.Host.RegenerateSubtree(Me.Index)
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Function IsDefault() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return False
		End Function

		Public Overrides Function CanBeExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return __Dereference(CType((CType(Me.Var, __Pointer(Of Byte)) + 4), __Pointer(Of Integer))) <> 0
		End Function

		Public Overrides Function Expand() As ArrayList
			Dim arrayList As ArrayList = New ArrayList()
			Dim var As __Pointer(Of GArrayHeader) = CType(Me.Var, __Pointer(Of GArrayHeader))
			Dim default_value As Single = 0F
			Dim min_value As Single = -3.40282347E+38F
			Dim max_value As Single = 3.40282347E+38F
			Dim step_value As Single = 0.5F
			Dim num As Integer = 0
			Dim num2 As Integer = __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer)))
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
							arrayList.Add(PropertyItem.MakeProperty(New String(CType(value, __Pointer(Of SByte))), Nothing, __Dereference(CType((type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))), __Dereference(CType((type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))) * num + __Dereference(CType(var, __Pointer(Of Integer))), default_value, min_value, max_value, step_value))
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
							arrayList.Add(PropertyItem.MakeProperty(New String(CType(value2, __Pointer(Of SByte))), Nothing, __Dereference(CType((type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))), __Dereference(CType((type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))) * num + __Dereference(CType(var, __Pointer(Of Integer))), default_value, min_value, max_value, step_value))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
							gBaseString<char>2 = 0
						End If
					End If
					Dim propertyItem As PropertyItem = TryCast(arrayList(num), PropertyItem)
					Dim menuItem As MenuItem = New MenuItem("Insert")
					AddHandler menuItem.Click, AddressOf propertyItem.OnInsert
					propertyItem.InjectMenu(menuItem)
					Dim menuItem2 As MenuItem = New MenuItem("Move Up")
					AddHandler menuItem2.Click, AddressOf propertyItem.OnMoveUp
					propertyItem.InjectMenu(menuItem2)
					Dim menuItem3 As MenuItem = New MenuItem("Move Down")
					AddHandler menuItem3.Click, AddressOf propertyItem.OnMoveDown
					propertyItem.InjectMenu(menuItem3)
					Dim menuItem4 As MenuItem = New MenuItem("Remove")
					AddHandler menuItem4.Click, AddressOf propertyItem.OnRemove
					propertyItem.InjectMenu(menuItem4)
					propertyItem.ArrayIndex = num
					AddHandler propertyItem.Insert, AddressOf Me.InsertItem
					AddHandler propertyItem.Remove, AddressOf Me.RemoveItem
					AddHandler propertyItem.MoveUp, AddressOf Me.MoveItemUp
					AddHandler propertyItem.MoveDown, AddressOf Me.MoveItemDown
					num += 1
					num2 = __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer)))
				Loop While num < num2
			End If
			Return arrayList
		End Function

		Public Overrides Function GetName() As String
			Return Me.Name + "[]"
		End Function

		Public Sub InsertItem(itemidx As Integer)
			Dim var As __Pointer(Of GArrayHeader) = CType(Me.Var, __Pointer(Of GArrayHeader))
			Dim num As Integer = __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer)))
			If itemidx < num AndAlso itemidx >= 0 Then
				Dim num2 As Integer = num + 1
				If __Dereference(CType((var + 8 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) < num2 Then
					Dim expr_29 As __Pointer(Of GArrayHeader) = var
					__Dereference(CType(expr_29, __Pointer(Of Integer))) = <Module>.realloc(__Dereference(CType(expr_29, __Pointer(Of Integer))), CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))) * num2)))
					__Dereference(CType((var + 8 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) = num2
				End If
				Dim num3 As UInteger = CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
				Dim num4 As Integer = __Dereference(CType(var, __Pointer(Of Integer)))
				<Module>.memmove((itemidx + 1) * CInt(num3) + num4, num3 * CUInt(itemidx) + CUInt(num4), CUInt(((__Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) - itemidx) * CInt(num3))))
				Dim num5 As UInteger = CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
				initblk(num5 * CUInt(itemidx) + CUInt((__Dereference(CType(var, __Pointer(Of Integer))))), 0, num5)
				__Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) = num2
				Me.EditControl.Value += 1L
				Me.EditControl.RaiseValidate()
				Me.Host.RegenerateSubtree(Me.Index)
				Me.Host.RaiseItemChanged()
				Me.Host.InvalidateViewControl()
			End If
		End Sub

		Public Sub RemoveItem(itemidx As Integer)
			Dim var As __Pointer(Of GArrayHeader) = CType(Me.Var, __Pointer(Of GArrayHeader))
			If itemidx < __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) AndAlso itemidx >= 0 Then
				Dim type As __Pointer(Of GClass) = Me.Type
				Dim num As UInteger = CUInt((__Dereference((__Dereference(CType((type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 40))))
				If num <> 0UI Then
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), __Dereference(CType((type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))) * itemidx + __Dereference(CType(var, __Pointer(Of Integer))), num)
				End If
				Dim num2 As Integer = __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer)))
				If itemidx <> num2 - 1 Then
					Dim num3 As Integer = __Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))
					Dim num4 As Integer = __Dereference(CType(var, __Pointer(Of Integer)))
					<Module>.memmove(num3 * itemidx + num4, (itemidx + 1) * num3 + num4, CUInt(((num2 - itemidx - 1) * num3)))
				End If
				Dim num5 As Integer = __Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))
				initblk((__Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) - 1) * num5 + __Dereference(CType(var, __Pointer(Of Integer))), 0, num5)
				__Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) = __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) + -1
				Me.EditControl.Value -= 1L
				Me.EditControl.RaiseValidate()
				Me.Host.RegenerateSubtree(Me.Index)
				Me.Host.RaiseItemChanged()
				Me.Host.InvalidateViewControl()
			End If
		End Sub

		Public Sub MoveItemUp(itemidx As Integer)
			Dim var As __Pointer(Of GArrayHeader) = CType(Me.Var, __Pointer(Of GArrayHeader))
			If itemidx < __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) AndAlso itemidx > 0 Then
				Dim ptr As __Pointer(Of Byte) = <Module>.new[](CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))))))
				Dim num As UInteger = CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
				cpblk(ptr, num * CUInt(itemidx) + CUInt((__Dereference(CType(var, __Pointer(Of Integer))))), num)
				Dim num2 As UInteger = CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
				Dim num3 As Integer = __Dereference(CType(var, __Pointer(Of Integer)))
				cpblk(num2 * CUInt(itemidx) + CUInt(num3), (itemidx - 1) * CInt(num2) + num3, num2)
				Dim num4 As UInteger = CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
				cpblk((itemidx - 1) * CInt(num4) + __Dereference(CType(var, __Pointer(Of Integer))), ptr, num4)
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Me.Host.RegenerateSubtree(Me.Index)
				Me.Host.RaiseItemChanged()
				Me.Host.InvalidateViewControl()
			End If
		End Sub

		Public Sub MoveItemDown(itemidx As Integer)
			Dim var As __Pointer(Of GArrayHeader) = CType(Me.Var, __Pointer(Of GArrayHeader))
			If itemidx < __Dereference(CType((var + 4 / __SizeOf(GArrayHeader)), __Pointer(Of Integer))) - 1 AndAlso itemidx >= 0 Then
				Dim ptr As __Pointer(Of Byte) = <Module>.new[](CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))))))
				Dim num As UInteger = CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
				cpblk(ptr, num * CUInt(itemidx) + CUInt((__Dereference(CType(var, __Pointer(Of Integer))))), num)
				Dim num2 As UInteger = CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
				Dim num3 As Integer = __Dereference(CType(var, __Pointer(Of Integer)))
				cpblk(num2 * CUInt(itemidx) + CUInt(num3), (itemidx + 1) * CInt(num2) + num3, num2)
				Dim num4 As UInteger = CUInt((__Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer)))))
				cpblk((itemidx + 1) * CInt(num4) + __Dereference(CType(var, __Pointer(Of Integer))), ptr, num4)
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Me.Host.RegenerateSubtree(Me.Index)
				Me.Host.RaiseItemChanged()
				Me.Host.InvalidateViewControl()
			End If
		End Sub

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
