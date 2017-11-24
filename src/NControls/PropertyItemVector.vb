Imports <CppImplementationDetails>
Imports NWorkshop
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyItemVector
		Inherits PropertyItemString

		Protected ColorButton As NImageButton

		Protected Sub ColorButton_Click(sender As Object, e As EventArgs)
			Dim colorPickerDialog As ColorPickerDialog = New ColorPickerDialog()
			Dim location As Point = Me.ColorButton.Location
			colorPickerDialog.Location = location
			Dim var As __Pointer(Of Void) = Me.Var
			colorPickerDialog.SetRGBA(__Dereference(CType(var, __Pointer(Of Single))), __Dereference(CType((CType(var, __Pointer(Of Byte)) + 4), __Pointer(Of Single))), __Dereference(CType((CType(var, __Pointer(Of Byte)) + 8), __Pointer(Of Single))), __Dereference(CType((CType(var, __Pointer(Of Byte)) + 12), __Pointer(Of Single))))
			If colorPickerDialog.ShowDialog() = DialogResult.OK Then
				var = Me.Var
				Dim arg_51_0 As ColorPickerDialog = colorPickerDialog
				Dim expr_47 As __Pointer(Of Void) = var
				arg_51_0.GetRGBA(expr_47, CType(expr_47, __Pointer(Of Byte)) + 4, CType(var, __Pointer(Of Byte)) + 8, CType(var, __Pointer(Of Byte)) + 12)
				Me.ComponentChanged()
				Me.Host.RegenerateSubtree(Me.Index)
				Me.Host.InvalidateViewControl()
			End If
		End Sub

		Protected Overrides Function GetValue() As String
			Select Case __Dereference(CType(Me.Type, __Pointer(Of Integer)))
				Case 16, 17
					Dim var As __Pointer(Of Void) = Me.Var
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>, CType((AddressOf <Module>.??_C@_08EJKDHBBI@?$CI?$CFf?$DL?5?$CFf?$CJ?$AA@), __Pointer(Of SByte)), CDec((__Dereference(CType(var, __Pointer(Of Single))))), CDec((__Dereference(CType((CType(var, __Pointer(Of Byte)) + 4), __Pointer(Of Single))))))
					Dim result As String
					Try
						Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
						result = New String(CType((If((num = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num)), __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
					Return result
				Case 19, 20
					Dim var2 As __Pointer(Of Void) = Me.Var
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>2, CType((AddressOf <Module>.??_C@_0N@FKJLJAOI@?$CI?$CFf?$DL?5?$CFf?$DL?5?$CFf?$CJ?$AA@), __Pointer(Of SByte)), CDec((__Dereference(CType(var2, __Pointer(Of Single))))), CDec((__Dereference(CType((CType(var2, __Pointer(Of Byte)) + 4), __Pointer(Of Single))))), CDec((__Dereference(CType((CType(var2, __Pointer(Of Byte)) + 8), __Pointer(Of Single))))))
					Dim result2 As String
					Try
						Dim num2 As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
						result2 = New String(CType((If((num2 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num2)), __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
					End If
					Return result2
				Case 22
					Dim var3 As __Pointer(Of Void) = Me.Var
					Dim gBaseString<char>3 As GBaseString<char>
					Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>3, CType((AddressOf <Module>.??_C@_0BB@OHPMMBPN@?$CI?$CFf?$DL?5?$CFf?$DL?5?$CFf?$DL?5?$CFf?$CJ?$AA@), __Pointer(Of SByte)), CDec((__Dereference(CType(var3, __Pointer(Of Single))))), CDec((__Dereference(CType((CType(var3, __Pointer(Of Byte)) + 4), __Pointer(Of Single))))), CDec((__Dereference(CType((CType(var3, __Pointer(Of Byte)) + 8), __Pointer(Of Single))))), CDec((__Dereference(CType((CType(var3, __Pointer(Of Byte)) + 12), __Pointer(Of Single))))))
					Dim result3 As String
					Try
						Dim num3 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
						result3 = New String(CType((If((num3 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num3)), __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>3 IsNot Nothing Then
						<Module>.free(gBaseString<char>3)
					End If
					Return result3
			End Select
			<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 981, CType((AddressOf <Module>.??_C@_0CI@BCHGCKCL@NControls?3?3PropertyItemVector?3?3G@), __Pointer(Of SByte)))
			<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BI@GEHCFIMB@Unsupported?5vector?5type?$AA@), __Pointer(Of SByte)))
			Return Nothing
		End Function

		Protected Overrides Sub SetValue(value As String)
			Dim gBaseString<char> As GBaseString<char>
			<Module>.GBaseString<char>.{ctor}(gBaseString<char>, value)
			Dim gTokenizer As GTokenizer
			Try
				Dim ptr As __Pointer(Of SByte)
				If gBaseString<char> IsNot Nothing Then
					ptr = gBaseString<char>
				Else
					ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				<Module>.GTokenizer.{ctor}(gTokenizer, ptr, value.Length)
				Try
					<Module>.GTokenizer.ReadToken(gTokenizer)
					If gTokenizer = 24 Then
						GoTo IL_75
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GTokenizer.{dtor}), CType((AddressOf gTokenizer), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GTokenizer.{dtor}(gTokenizer)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
				GoTo IL_3E6
			End If
			GoTo IL_3E6
			IL_75:
			Try
				Try
					Dim num As Integer = __Dereference(CType(Me.Type, __Pointer(Of Integer)))
					Dim num2 As Integer
					If num <> 16 AndAlso num <> 17 Then
						If num <> 19 AndAlso num <> 20 Then
							If num = 22 Then
								num2 = 4
								GoTo IL_BF
							End If
							<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 1002, CType((AddressOf <Module>.??_C@_0CI@ODFKDJFG@NControls?3?3PropertyItemVector?3?3S@), __Pointer(Of SByte)))
							<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BI@GEHCFIMB@Unsupported?5vector?5type?$AA@), __Pointer(Of SByte)))
						End If
						num2 = 3
					Else
						num2 = 2
					End If
					IL_BF:
					Dim num3 As Integer = 0
					If 0 >= num2 Then
						GoTo IL_200
					End If
					While True
						If num3 <> 0 Then
							<Module>.GTokenizer.ReadToken(gTokenizer)
							If gTokenizer <> 3 Then
								Exit While
							End If
						End If
						<Module>.GTokenizer.ReadToken(gTokenizer)
						If gTokenizer = 18 Then
							<Module>.GTokenizer.ReadToken(gTokenizer)
							If gTokenizer = 15 Then
								Dim $ArrayType$$$BY03M As $ArrayType$$$BY03M
								__Dereference((num3 * 4 + $ArrayType$$$BY03M)) = CSng((-CSng((__Dereference((gTokenizer + 16))))))
							Else
								If gTokenizer <> 16 Then
									GoTo Block_36
								End If
								Dim $ArrayType$$$BY03M As $ArrayType$$$BY03M
								__Dereference((num3 * 4 + $ArrayType$$$BY03M)) = CSng((-CSng((__Dereference((gTokenizer + 24))))))
							End If
						Else If gTokenizer = 15 Then
							Dim $ArrayType$$$BY03M As $ArrayType$$$BY03M
							__Dereference((num3 * 4 + $ArrayType$$$BY03M)) = CSng((__Dereference((gTokenizer + 16))))
						Else
							If gTokenizer <> 16 Then
								GoTo Block_38
							End If
							Dim $ArrayType$$$BY03M As $ArrayType$$$BY03M
							__Dereference((num3 * 4 + $ArrayType$$$BY03M)) = CSng((__Dereference((gTokenizer + 24))))
						End If
						num3 += 1
						If num3 >= num2 Then
							GoTo Block_39
						End If
					End While
					GoTo IL_17A
					Block_36:
					GoTo IL_1A6
					Block_38:
					GoTo IL_1D3
					Block_39:
					GoTo IL_200
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GTokenizer.{dtor}), CType((AddressOf gTokenizer), __Pointer(Of Void)))
					Throw
				End Try
				IL_17A:
				<Module>.GTokenizer.{dtor}(gTokenizer)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
				GoTo IL_3E6
			End If
			GoTo IL_3E6
			IL_1A6:
			Try
				<Module>.GTokenizer.{dtor}(gTokenizer)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
				GoTo IL_3E6
			End If
			GoTo IL_3E6
			IL_1D3:
			Try
				<Module>.GTokenizer.{dtor}(gTokenizer)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
				GoTo IL_3E6
			End If
			GoTo IL_3E6
			IL_200:
			Try
				Try
					<Module>.GTokenizer.ReadToken(gTokenizer)
					If gTokenizer = 25 Then
						GoTo IL_24D
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GTokenizer.{dtor}), CType((AddressOf gTokenizer), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GTokenizer.{dtor}(gTokenizer)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
				GoTo IL_3E6
			End If
			GoTo IL_3E6
			IL_24D:
			Try
				Try
					<Module>.GTokenizer.ReadToken(gTokenizer)
					If gTokenizer Is Nothing Then
						GoTo IL_298
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GTokenizer.{dtor}), CType((AddressOf gTokenizer), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GTokenizer.{dtor}(gTokenizer)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
				GoTo IL_3E6
			End If
			GoTo IL_3E6
			IL_298:
			Try
				Try
					Select Case __Dereference(CType(Me.Type, __Pointer(Of Integer)))
						Case 16, 17
							Dim $ArrayType$$$BY03M As $ArrayType$$$BY03M
							Dim gVector As GVector2 = $ArrayType$$$BY03M
							__Dereference((gVector + 4)) = __Dereference(($ArrayType$$$BY03M + 4))
							cpblk(Me.Var, gVector, 8)
						Case 18
							GoTo IL_3A7
						Case 19, 20
							Dim $ArrayType$$$BY03M As $ArrayType$$$BY03M
							Dim gVector2 As GVector3 = $ArrayType$$$BY03M
							__Dereference((gVector2 + 4)) = __Dereference(($ArrayType$$$BY03M + 4))
							__Dereference((gVector2 + 8)) = __Dereference(($ArrayType$$$BY03M + 8))
							cpblk(Me.Var, gVector2, 12)
						Case 21
							GoTo IL_3A7
						Case 22
							Dim $ArrayType$$$BY03M As $ArrayType$$$BY03M
							Dim gColor As GColor = $ArrayType$$$BY03M
							__Dereference((gColor + 4)) = __Dereference(($ArrayType$$$BY03M + 4))
							__Dereference((gColor + 8)) = __Dereference(($ArrayType$$$BY03M + 8))
							__Dereference((gColor + 12)) = __Dereference(($ArrayType$$$BY03M + 12))
							cpblk(Me.Var, gColor, 16)
						Case Else
							GoTo IL_3A7
					End Select
					Me.Host.RegenerateSubtree(Me.Index)
					Me.Host.RaiseItemChanged()
					Me.Host.InvalidateViewControl()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GTokenizer.{dtor}), CType((AddressOf gTokenizer), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GTokenizer.{dtor}(gTokenizer)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
				GoTo IL_3E6
			End If
			GoTo IL_3E6
			IL_3A7:
			Try
				Try
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 1058, CType((AddressOf <Module>.??_C@_0CI@ODFKDJFG@NControls?3?3PropertyItemVector?3?3S@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BI@GEHCFIMB@Unsupported?5vector?5type?$AA@), __Pointer(Of SByte)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GTokenizer.{dtor}), CType((AddressOf gTokenizer), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			IL_3E6:
			Try
				Try
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GTokenizer.{dtor}), CType((AddressOf gTokenizer), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
		End Sub

		Protected Sub ComponentChanged()
			Me.EditControl.Text = Me.GetValue()
			If Me.IsDefault() Then
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Bold)
			Else
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Regular)
			End If
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Sub Refresh()
			Me.EditControl.Text = Me.GetValue()
			If Me.IsDefault() Then
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Bold)
			Else
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Regular)
			End If
			Me.Host.RegenerateSubtree(Me.Index)
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Function CanBeExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return True
		End Function

		Public Overrides Function ShouldBeExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return False
		End Function

		Public Overrides Function Expand() As ArrayList
			Dim arrayList As ArrayList = New ArrayList()
			Dim default_value As Single = 0.33F
			Dim min_value As Single = -3.40282347E+38F
			Dim max_value As Single = 3.40282347E+38F
			Dim step_value As Single = 0.5F
			Dim default_value2 As Single = 0F
			Dim min_value2 As Single = 0F
			Dim max_value2 As Single = 1F
			Dim step_value2 As Single = 0.025F
			Select Case __Dereference(CType(Me.Type, __Pointer(Of Integer)))
				Case 16, 17
					arrayList.Add(PropertyItem.MakeProperty("X", Nothing, AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, Me.Var, default_value, min_value, max_value, step_value))
					arrayList.Add(PropertyItem.MakeProperty("Z", Nothing, AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, CType((CType(Me.Var, __Pointer(Of Byte)) + 4), __Pointer(Of Void)), default_value, min_value, max_value, step_value))
				Case 19, 20
					arrayList.Add(PropertyItem.MakeProperty("X", Nothing, AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, Me.Var, default_value, min_value, max_value, step_value))
					arrayList.Add(PropertyItem.MakeProperty("Y", Nothing, AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, CType((CType(Me.Var, __Pointer(Of Byte)) + 4), __Pointer(Of Void)), default_value, min_value, max_value, step_value))
					arrayList.Add(PropertyItem.MakeProperty("Z", Nothing, AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, CType((CType(Me.Var, __Pointer(Of Byte)) + 8), __Pointer(Of Void)), default_value, min_value, max_value, step_value))
				Case 22
					arrayList.Add(PropertyItem.MakeProperty("Red", CType((AddressOf <Module>.??_C@_0O@NNKGIGDI@Red?5Component?$AA@), __Pointer(Of SByte)), AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, Me.Var, default_value2, min_value2, max_value2, step_value2))
					arrayList.Add(PropertyItem.MakeProperty("Green", CType((AddressOf <Module>.??_C@_0BA@LJNHNHAN@Green?5Component?$AA@), __Pointer(Of SByte)), AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, CType((CType(Me.Var, __Pointer(Of Byte)) + 4), __Pointer(Of Void)), default_value2, min_value2, max_value2, step_value2))
					arrayList.Add(PropertyItem.MakeProperty("Blue", CType((AddressOf <Module>.??_C@_0P@PGFMMNHF@Blue?5Component?$AA@), __Pointer(Of SByte)), AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, CType((CType(Me.Var, __Pointer(Of Byte)) + 8), __Pointer(Of Void)), default_value2, min_value2, max_value2, step_value2))
					arrayList.Add(PropertyItem.MakeProperty("Alpha", CType((AddressOf <Module>.??_C@_0BA@JEPOJENN@Alpha?5Component?$AA@), __Pointer(Of SByte)), AddressOf <Module>.?A0x25985e21.PropertyItem_Class_float, CType((CType(Me.Var, __Pointer(Of Byte)) + 12), __Pointer(Of Void)), default_value2, min_value2, max_value2, step_value2))
			End Select
			Dim enumerator As IEnumerator = arrayList.GetEnumerator()
			If enumerator.MoveNext() Then
				Do
					AddHandler(TryCast(enumerator.Current, PropertyItem)).ItemChanged, AddressOf Me.ComponentChanged
				Loop While enumerator.MoveNext()
			End If
			Return arrayList
		End Function

		Public Overrides Sub UpdateControl(bounds As Rectangle)
			If Me.ColorButton IsNot Nothing Then
				Dim sz As Size = New Size(17, 16)
				Dim size As Size = bounds.Size
				Dim location As Point = bounds.Location + size - sz
				Me.ColorButton.Location = location
			Else If __Dereference(CType(Me.Type, __Pointer(Of Integer))) = 22 Then
				Me.ColorButton = New NImageButton()
				Dim sz2 As Size = New Size(17, 16)
				Dim size2 As Size = bounds.Size
				Dim location2 As Point = bounds.Location + size2 - sz2
				Me.ColorButton.Location = location2
				Dim size3 As Size = New Size(16, 16)
				Me.ColorButton.Size = size3
				Me.ColorButton.TabIndex = 1
				Me.ColorButton.Image = ImageServer.GetImageServer("Images").GetImage("ColorPicker")
				Me.Host.Controls.Add(Me.ColorButton)
				AddHandler Me.ColorButton.Click, AddressOf Me.ColorButton_Click
			End If
			MyBase.UpdateControl(bounds)
		End Sub

		Public Overrides Sub DestroyControl()
			If Me.ColorButton IsNot Nothing Then
				RemoveHandler Me.ColorButton.Click, AddressOf Me.ColorButton_Click
				Me.Host.Controls.Remove(Me.ColorButton)
				Me.ColorButton = Nothing
			End If
			MyBase.DestroyControl()
		End Sub

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
