Imports GRTTI
Imports System
Imports System.Collections
Imports System.Runtime.InteropServices

Namespace NControls
	Public Class PropertyItemPointerTo
		Inherits PropertyItemEnum

		Protected Overrides Sub GetItems()
			Me.dropList.Items.Add("Disabled")
			Dim num As UInteger = CUInt((__Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 16))))
			If num <> 0UI Then
				Dim num2 As Integer = 0
				If __Dereference(num) <> 0 Then
					Dim num3 As Integer = CInt(num)
					Do
						Me.dropList.Items.Add(New String(__Dereference((__Dereference(num3) + 4))))
						num2 += 1
						num3 = num2 * 4 + __Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 16))
					Loop While __Dereference(num3) <> 0
				End If
			Else
				Me.dropList.Items.Add("Enabled")
			End If
			Dim var As __Pointer(Of Void) = Me.Var
			If __Dereference(CType(var, __Pointer(Of Integer))) <> 0 Then
				Dim num4 As Integer = __Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer)))
				If __Dereference((num4 + 16)) <> 0 Then
					Dim ptr As __Pointer(Of SByte) = calli(System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), __Dereference(CType(var, __Pointer(Of Integer))), __Dereference((num4 + 20)))
					If <Module>.strncmp(ptr, CType((AddressOf <Module>.??_C@_07DIBCDNGL@struct?5?$AA@), __Pointer(Of SByte)), 7UI) Is Nothing Then
						ptr += 7 / __SizeOf(SByte)
					Else
						If <Module>.strncmp(ptr, CType((AddressOf <Module>.??_C@_06LJBABKPM@class?5?$AA@), __Pointer(Of SByte)), 6UI) IsNot Nothing Then
							<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 1777, CType((AddressOf <Module>.??_C@_0CL@LBKEDLGC@NControls?3?3PropertyItemPointerTo@), __Pointer(Of SByte)))
							<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0CJ@CFPHDAMK@The?5type?5?8?$CFs?8?5is?5not?5a?5struct?5or@), __Pointer(Of SByte)), ptr)
							GoTo IL_1B1
						End If
						ptr += 6 / __SizeOf(SByte)
					End If
					Dim num5 As Integer = 0
					num = CUInt((__Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 16))))
					If __Dereference(num) <> 0 Then
						Dim b As SByte = __Dereference(CType(ptr, __Pointer(Of SByte)))
						Dim num6 As Integer = CInt(num)
						Do
							Dim ptr2 As __Pointer(Of SByte) = ptr
							Dim num7 As Integer = __Dereference((__Dereference(num6) + 4))
							Dim b2 As SByte = __Dereference(num7)
							Dim b3 As SByte = b
							If b2 >= b3 Then
								Dim ptr3 As __Pointer(Of SByte) = num7 - ptr
								While b2 <= b3
									If b2 = 0 Then
										GoTo IL_14E
									End If
									ptr2 += 1 / __SizeOf(SByte)
									b2 = __Dereference(CType((ptr3 + ptr2 / __SizeOf(SByte)), __Pointer(Of SByte)))
									b3 = __Dereference(CType(ptr2, __Pointer(Of SByte)))
									If b2 < b3 Then
										Exit While
									End If
								End While
							End If
							num5 += 1
							num6 = num5 * 4 + CInt(num)
						Loop While __Dereference(num6) <> 0
					End If
					IL_14E:
					If __Dereference((num5 * 4 + CInt(num))) = 0 Then
						<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 1785, CType((AddressOf <Module>.??_C@_0CL@LBKEDLGC@NControls?3?3PropertyItemPointerTo@), __Pointer(Of SByte)))
						<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0CK@DEIACGDP@The?5type?5?8?$CFs?8?5is?5not?5a?5descenden@), __Pointer(Of SByte)), ptr, __Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 4)))
					End If
					Me.dropList.SelectedIndex = num5 + 1
					Return
				End If
				IL_1B1:
				Me.dropList.SelectedIndex = 1
			Else
				Me.dropList.SelectedIndex = 0
			End If
		End Sub

		Protected Overrides Sub SelectItem(index As Integer)
			Dim var As __Pointer(Of Void) = Me.Var
			Dim ptr As __Pointer(Of __Pointer(Of Void)) = var
			If index = 0 Then
				Dim num As UInteger = CUInt((__Dereference(ptr)))
				If num = 0UI Then
					Return
				End If
				Dim num2 As UInteger = CUInt((__Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 32))))
				If num2 <> 0UI Then
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), num, num2)
				Else
					<Module>.free(num)
				End If
				__Dereference(ptr) = 0
			Else
				Dim type As __Pointer(Of GClass) = Me.Type
				Dim num3 As Integer = __Dereference(CType((type + 52 / __SizeOf(GClass)), __Pointer(Of Integer)))
				If __Dereference((num3 + 16)) <> 0 Then
					Dim ptr2 As __Pointer(Of GStreamBuffer) = Nothing
					If __Dereference(ptr) <> 0 Then
						Dim ptr3 As __Pointer(Of SByte) = calli(System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), __Dereference(CType(var, __Pointer(Of Integer))), __Dereference((num3 + 20)))
						If <Module>.strncmp(ptr3, CType((AddressOf <Module>.??_C@_07DIBCDNGL@struct?5?$AA@), __Pointer(Of SByte)), 7UI) Is Nothing Then
							ptr3 += 7 / __SizeOf(SByte)
						Else
							If <Module>.strncmp(ptr3, CType((AddressOf <Module>.??_C@_06LJBABKPM@class?5?$AA@), __Pointer(Of SByte)), 6UI) IsNot Nothing Then
								<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 1834, CType((AddressOf <Module>.??_C@_0CN@BMAEKPLO@NControls?3?3PropertyItemPointerTo@), __Pointer(Of SByte)))
								<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0CJ@CFPHDAMK@The?5type?5?8?$CFs?8?5is?5not?5a?5struct?5or@), __Pointer(Of SByte)), ptr3)
								GoTo IL_1E5
							End If
							ptr3 += 6 / __SizeOf(SByte)
						End If
						Dim num4 As Integer = 0
						Dim num5 As UInteger = CUInt((__Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 16))))
						If __Dereference(num5) <> 0 Then
							Dim b As SByte = __Dereference(CType(ptr3, __Pointer(Of SByte)))
							Dim num6 As Integer = CInt(num5)
							Do
								Dim ptr4 As __Pointer(Of SByte) = ptr3
								Dim num7 As Integer = __Dereference((__Dereference(num6) + 4))
								Dim b2 As SByte = __Dereference(num7)
								Dim b3 As SByte = b
								If b2 >= b3 Then
									Dim ptr5 As __Pointer(Of SByte) = num7 - ptr3
									While b2 <= b3
										If b2 = 0 Then
											GoTo IL_114
										End If
										ptr4 += 1 / __SizeOf(SByte)
										b2 = __Dereference(CType((ptr5 + ptr4 / __SizeOf(SByte)), __Pointer(Of SByte)))
										b3 = __Dereference(CType(ptr4, __Pointer(Of SByte)))
										If b2 < b3 Then
											Exit While
										End If
									End While
								End If
								num4 += 1
								num6 = num4 * 4 + CInt(num5)
							Loop While __Dereference(num6) <> 0
						End If
						IL_114:
						If __Dereference((num4 * 4 + CInt(num5))) = 0 Then
							<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 1842, CType((AddressOf <Module>.??_C@_0CN@BMAEKPLO@NControls?3?3PropertyItemPointerTo@), __Pointer(Of SByte)))
							<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0CK@DEIACGDP@The?5type?5?8?$CFs?8?5is?5not?5a?5descenden@), __Pointer(Of SByte)), ptr3, __Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 4)))
						End If
						If num4 <> index - 1 Then
							Dim ptr6 As __Pointer(Of GStreamBuffer) = <Module>.new(36UI)
							Dim ptr7 As __Pointer(Of GStreamBuffer)
							Try
								If ptr6 IsNot Nothing Then
									ptr7 = <Module>.GStreamBuffer.{ctor}(ptr6)
								Else
									ptr7 = 0
								End If
							Catch 
								<Module>.delete(CType(ptr6, __Pointer(Of Void)))
								Throw
							End Try
							ptr2 = ptr7
							<Module>.GRTTI.SaveVariablesAsText(ptr7, __Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))), __Dereference(ptr), Me.Host.Measures)
							Dim num8 As UInteger = CUInt((__Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 32))))
							If num8 <> 0UI Then
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), __Dereference(ptr), num8)
							Else
								<Module>.free(__Dereference(ptr))
							End If
							__Dereference(ptr) = 0
							GoTo IL_1EC
						End If
						IL_1E5:
						If __Dereference(ptr) <> 0 Then
							Return
						End If
					End If
					IL_1EC:
					Dim num9 As Integer = __Dereference((index * 4 + __Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 16)) - 4))
					Dim num10 As UInteger = CUInt((__Dereference((num9 + 28))))
					If num10 <> 0UI Then
						__Dereference(ptr) = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvCdecl)(), num10)
					Else
						Dim ptr8 As __Pointer(Of Void) = <Module>.malloc(CUInt((__Dereference((num9 + 48)))))
						__Dereference(ptr) = ptr8
						initblk(ptr8, 0, __Dereference((__Dereference((index * 4 + __Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 16)) - 4)) + 48)))
					End If
					If ptr2 IsNot Nothing Then
						<Module>.GStream.Reset(ptr2)
						<Module>.GRTTI.LoadVariablesAsText(CType(ptr2, __Pointer(Of GStream)), __Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))), __Dereference(ptr), Me.Host.Measures)
						Dim arg_27A_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, __Dereference((__Dereference(CType(ptr2, __Pointer(Of Integer))))))
					End If
				Else
					If __Dereference(ptr) <> 0 Then
						Return
					End If
					Dim num11 As UInteger = CUInt((__Dereference((num3 + 28))))
					If num11 <> 0UI Then
						__Dereference(ptr) = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvCdecl)(), num11)
					Else
						Dim ptr9 As __Pointer(Of Void) = <Module>.malloc(CUInt((__Dereference(CType((type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))))))
						__Dereference(ptr) = ptr9
						initblk(ptr9, 0, __Dereference(CType((Me.Type + 48 / __SizeOf(GClass)), __Pointer(Of Integer))))
					End If
				End If
			End If
			Me.Host.RegenerateSubtree(Me.Index)
			Me.Host.RaiseItemChanged()
			Me.Host.InvalidateViewControl()
		End Sub

		Public Overrides Sub Refresh()
			Dim ptr As __Pointer(Of Void) = __Dereference(CType(Me.Var, __Pointer(Of Integer)))
			If ptr IsNot Nothing Then
				Dim num As Integer = __Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer)))
				If __Dereference((num + 16)) <> 0 Then
					Dim ptr2 As __Pointer(Of SByte) = calli(System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.CallConvCdecl)(System.Void*), ptr, __Dereference((num + 20)))
					If <Module>.strncmp(ptr2, CType((AddressOf <Module>.??_C@_07DIBCDNGL@struct?5?$AA@), __Pointer(Of SByte)), 7UI) Is Nothing Then
						ptr2 += 7 / __SizeOf(SByte)
					Else
						If <Module>.strncmp(ptr2, CType((AddressOf <Module>.??_C@_06LJBABKPM@class?5?$AA@), __Pointer(Of SByte)), 6UI) IsNot Nothing Then
							<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 1727, CType((AddressOf <Module>.??_C@_0CK@EHBDGIII@NControls?3?3PropertyItemPointerTo@), __Pointer(Of SByte)))
							<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0CJ@CFPHDAMK@The?5type?5?8?$CFs?8?5is?5not?5a?5struct?5or@), __Pointer(Of SByte)), ptr2)
							GoTo IL_12A
						End If
						ptr2 += 6 / __SizeOf(SByte)
					End If
					Dim num2 As Integer = 0
					Dim num3 As UInteger = CUInt((__Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 16))))
					If __Dereference(num3) <> 0 Then
						Dim b As SByte = __Dereference(CType(ptr2, __Pointer(Of SByte)))
						Dim num4 As Integer = CInt(num3)
						Do
							Dim ptr3 As __Pointer(Of SByte) = ptr2
							Dim num5 As Integer = __Dereference((__Dereference(num4) + 4))
							Dim b2 As SByte = __Dereference(num5)
							Dim b3 As SByte = b
							If b2 >= b3 Then
								Dim ptr4 As __Pointer(Of SByte) = num5 - ptr2
								While b2 <= b3
									If b2 = 0 Then
										GoTo IL_C6
									End If
									ptr3 += 1 / __SizeOf(SByte)
									b2 = __Dereference(CType((ptr4 + ptr3 / __SizeOf(SByte)), __Pointer(Of SByte)))
									b3 = __Dereference(CType(ptr3, __Pointer(Of SByte)))
									If b2 < b3 Then
										Exit While
									End If
								End While
							End If
							num2 += 1
							num4 = num2 * 4 + CInt(num3)
						Loop While __Dereference(num4) <> 0
					End If
					IL_C6:
					If __Dereference((num2 * 4 + CInt(num3))) = 0 Then
						<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 1735, CType((AddressOf <Module>.??_C@_0CK@EHBDGIII@NControls?3?3PropertyItemPointerTo@), __Pointer(Of SByte)))
						<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0CK@DEIACGDP@The?5type?5?8?$CFs?8?5is?5not?5a?5descenden@), __Pointer(Of SByte)), ptr2, __Dereference((__Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer))) + 4)))
					End If
					Me.dropList.SelectedIndex = num2 + 1
					GoTo IL_144
				End If
				IL_12A:
				Me.dropList.SelectedIndex = 1
			Else
				Me.dropList.SelectedIndex = 0
			End If
			IL_144:
			Me.Host.RegenerateSubtree(Me.Index)
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Function CanBeExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return(If((__Dereference(CType(Me.Var, __Pointer(Of Integer))) <> 0), 1, 0)) <> 0
		End Function

		Public Overrides Function Expand() As ArrayList
			Dim arrayList As ArrayList = New ArrayList()
			Dim ptr As __Pointer(Of Void) = __Dereference(CType(Me.Var, __Pointer(Of Integer)))
			Dim num As Integer = __Dereference(CType((Me.Type + 52 / __SizeOf(GClass)), __Pointer(Of Integer)))
			Dim num2 As UInteger = CUInt((__Dereference((num + 16))))
			Dim ptr2 As __Pointer(Of GMember) = __Dereference(((If((num2 = 0UI), num, (__Dereference((Me.dropList.SelectedIndex * 4 + CInt(num2) - 4))))) + 8))
			Dim num3 As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
			If num3 <> 0UI Then
				Do
					arrayList.Add(PropertyItem.MakeProperty(New String(num3), __Dereference(CType((ptr2 + 12 / __SizeOf(GMember)), __Pointer(Of Integer))), __Dereference(CType((ptr2 + 4 / __SizeOf(GMember)), __Pointer(Of Integer))), CType((__Dereference(CType((ptr2 + 8 / __SizeOf(GMember)), __Pointer(Of Integer))) + CType(ptr, __Pointer(Of Byte))), __Pointer(Of Void)), __Dereference(CType((ptr2 + 16 / __SizeOf(GMember)), __Pointer(Of Integer))), __Dereference(CType((ptr2 + 20 / __SizeOf(GMember)), __Pointer(Of Integer))), __Dereference(CType((ptr2 + 24 / __SizeOf(GMember)), __Pointer(Of Integer))), __Dereference(CType((ptr2 + 28 / __SizeOf(GMember)), __Pointer(Of Integer)))))
					ptr2 += 32 / __SizeOf(GMember)
					num3 = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
				Loop While num3 <> 0UI
			End If
			Return arrayList
		End Function

		Public Overrides Sub SetDefault()
			Me.dropList.SetSelection(0)
		End Sub

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
