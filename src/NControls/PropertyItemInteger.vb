Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyItemInteger
		Inherits PropertyItem

		Protected EditControl As NNumericUpDown

		Protected LowerBound As Long

		Protected UpperBound As Long

		Protected StepValue As Long

		Protected DefaultValue As Long

		Protected Sub EditControl_Enter(sender As Object, e As EventArgs)
		End Sub

		Protected Sub EditControl_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.Host.Focus()
				Me.Host.InvalidateViewControl()
				e.Handled = True
			Else If e.KeyCode = Keys.Escape Then
				Me.EditControl.Value = Me.GetValue()
				Me.Host.Focus()
				Me.Host.InvalidateViewControl()
				e.Handled = True
			End If
		End Sub

		Protected Sub EditControl_ValueChanged(sender As Object, e As EventArgs)
		End Sub

		Protected Sub EditControl_Validated(sender As Object, e As EventArgs)
			Me.SetValue(Me.EditControl.Value)
			If Me.IsDefault() Then
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Regular)
			Else
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Bold)
			End If
		End Sub

		Protected Sub EditControl_MouseDown(sender As Object, e As MouseEventArgs)
			Dim location As Point = Me.EditControl.Location
			Dim host As PropertyTreeCore = Me.Host
			host.SelectedIndex = CInt((CDec((CSng(location.Y) / host.ItemHeight))))
			Me.Host.EnsureSelectedVisible()
		End Sub

		Protected Overridable Function GetValue() As Long
			Select Case __Dereference(CType(Me.Type, __Pointer(Of Integer)))
				Case 2
					Return CLng((__Dereference(CType(Me.Var, __Pointer(Of SByte)))))
				Case 3
					Return CLng((CULng((__Dereference(CType(Me.Var, __Pointer(Of Byte)))))))
				Case 4
					Return CLng((__Dereference(CType(Me.Var, __Pointer(Of Short)))))
				Case 5
					Return CLng((CULng((__Dereference(CType(Me.Var, __Pointer(Of UShort)))))))
				Case 6
					Return CLng((__Dereference(CType(Me.Var, __Pointer(Of Integer)))))
				Case 7
					Return CLng((CULng((__Dereference(CType(Me.Var, __Pointer(Of Integer)))))))
				Case Else
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 593, CType((AddressOf <Module>.??_C@_0CJ@GECMPENI@NControls?3?3PropertyItemInteger?3?3@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BJ@CIEPDBBG@Unsupported?5integer?5type?$AA@), __Pointer(Of SByte)))
					Return 0L
			End Select
		End Function

		Protected Overridable Sub SetValue(ival As Long)
			Select Case __Dereference(CType(Me.Type, __Pointer(Of Integer)))
				Case 2
					Dim var As __Pointer(Of Void) = Me.Var
					If CLng((__Dereference(CType(var, __Pointer(Of SByte))))) = ival Then
						Return
					End If
					__Dereference(CType(var, __Pointer(Of Byte))) = CByte((CInt(ival)))
				Case 3
					Dim var As __Pointer(Of Void) = Me.Var
					If CULng((__Dereference(CType(var, __Pointer(Of Byte))))) = CULng(ival) Then
						Return
					End If
					__Dereference(CType(var, __Pointer(Of Byte))) = CByte((CInt(ival)))
				Case 4
					Dim var As __Pointer(Of Void) = Me.Var
					If CLng((__Dereference(CType(var, __Pointer(Of Short))))) = ival Then
						Return
					End If
					__Dereference(CType(var, __Pointer(Of Short))) = CShort((CInt(ival)))
				Case 5
					Dim var As __Pointer(Of Void) = Me.Var
					If CULng((__Dereference(CType(var, __Pointer(Of UShort))))) = CULng(ival) Then
						Return
					End If
					__Dereference(CType(var, __Pointer(Of Short))) = CShort((CInt(ival)))
				Case 6
					Dim var As __Pointer(Of Void) = Me.Var
					If CLng((__Dereference(CType(var, __Pointer(Of Integer))))) = ival Then
						Return
					End If
					__Dereference(CType(var, __Pointer(Of Integer))) = CInt(ival)
				Case 7
					Dim var As __Pointer(Of Void) = Me.Var
					If CULng((__Dereference(CType(var, __Pointer(Of Integer))))) = CULng(ival) Then
						Return
					End If
					__Dereference(CType(var, __Pointer(Of Integer))) = CInt(ival)
				Case Else
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 685, CType((AddressOf <Module>.??_C@_0CJ@JFAAOHKF@NControls?3?3PropertyItemInteger?3?3@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BJ@CIEPDBBG@Unsupported?5integer?5type?$AA@), __Pointer(Of SByte)))
					Return
			End Select
			Me.Host.RaiseItemChanged()
		End Sub

		Protected Function StringToInt64(value As String, ival As __Pointer(Of Long)) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim num As Long = 1L
			Dim gBaseString<char> As GBaseString<char>
			<Module>.GBaseString<char>.{ctor}(gBaseString<char>, value)
			Try
				If __Dereference((gBaseString<char> + 4)) <> 0 Then
					While 0 < __Dereference((gBaseString<char> + 4))
						If __Dereference(gBaseString<char>) = 32 Then
							If 1 >= __Dereference((gBaseString<char> + 4)) Then
								<Module>.free(gBaseString<char>)
								gBaseString<char> = 0
								__Dereference((gBaseString<char> + 4)) = 0
								GoTo IL_199
							End If
							Dim num2 As Integer = __Dereference((gBaseString<char> + 4)) - 1
							Dim ptr As __Pointer(Of SByte) = <Module>.malloc(CUInt((num2 + 1)))
							cpblk(ptr, gBaseString<char> + 1, num2)
							__Dereference(CType((ptr + num2 / __SizeOf(SByte)), __Pointer(Of Byte))) = 0
							<Module>.free(gBaseString<char>)
							gBaseString<char> = ptr
							__Dereference((gBaseString<char> + 4)) = num2
							If num2 = 0 Then
								GoTo IL_199
							End If
						Else
							IL_A5:
							If __Dereference((gBaseString<char> + 4)) <> 0 Then
								While -1 >= -(__Dereference((gBaseString<char> + 4)))
									If __Dereference((gBaseString<char> + __Dereference((gBaseString<char> + 4)) - 1)) = 32 Then
										<Module>.GBaseString<char>.Crop(gBaseString<char>, 0, __Dereference((gBaseString<char> + 4)) - 1)
										If __Dereference((gBaseString<char> + 4)) = 0 Then
											GoTo IL_199
										End If
									Else
										IL_103:
										If __Dereference((gBaseString<char> + 4)) = 0 Then
											GoTo IL_199
										End If
										If 0 >= __Dereference((gBaseString<char> + 4)) Then
											<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
											<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), 0)
											GoTo IL_199
										End If
										If __Dereference(gBaseString<char>) <> 45 Then
											GoTo IL_199
										End If
										num = -1L
										If 1 < __Dereference((gBaseString<char> + 4)) Then
											Dim num3 As Integer = __Dereference((gBaseString<char> + 4)) - 1
											Dim ptr2 As __Pointer(Of SByte) = <Module>.malloc(CUInt((num3 + 1)))
											cpblk(ptr2, gBaseString<char> + 1, num3)
											__Dereference(CType((ptr2 + num3 / __SizeOf(SByte)), __Pointer(Of Byte))) = 0
											<Module>.free(gBaseString<char>)
											gBaseString<char> = ptr2
											__Dereference((gBaseString<char> + 4)) = num3
											GoTo IL_199
										End If
										<Module>.free(gBaseString<char>)
										gBaseString<char> = 0
										__Dereference((gBaseString<char> + 4)) = 0
										GoTo IL_199
									End If
								End While
								<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
								<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), -1)
								GoTo IL_103
							End If
							GoTo IL_199
						End If
					End While
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), 0)
					GoTo IL_A5
				End If
				IL_199:
				__Dereference(ival) = 0L
				Dim num4 As Integer = 0
				If 0 >= __Dereference((gBaseString<char> + 4)) Then
					GoTo IL_32B
				End If
				While True
					Dim ptr3 As __Pointer(Of SByte)
					If num4 >= 0 Then
						If num4 >= __Dereference((gBaseString<char> + 4)) Then
							Exit While
						End If
						ptr3 = gBaseString<char> + num4
					Else
						If num4 < -(__Dereference((gBaseString<char> + 4))) Then
							Exit While
						End If
						ptr3 = __Dereference((gBaseString<char> + 4)) + gBaseString<char> + num4
					End If
					If __Dereference(ptr3) < 48 Then
						GoTo Block_22
					End If
					Dim ptr4 As __Pointer(Of SByte)
					If num4 >= 0 Then
						If num4 >= __Dereference((gBaseString<char> + 4)) Then
							GoTo IL_2BD
						End If
						ptr4 = gBaseString<char> + num4
					Else
						If num4 < -(__Dereference((gBaseString<char> + 4))) Then
							GoTo IL_2BD
						End If
						ptr4 = __Dereference((gBaseString<char> + 4)) + gBaseString<char> + num4
					End If
					If __Dereference(ptr4) > 57 Then
						GoTo Block_26
					End If
					Dim ptr5 As __Pointer(Of SByte)
					If num4 >= 0 Then
						If num4 >= __Dereference((gBaseString<char> + 4)) Then
							GoTo IL_29E
						End If
						ptr5 = gBaseString<char> + num4
					Else
						If num4 < -(__Dereference((gBaseString<char> + 4))) Then
							GoTo IL_29E
						End If
						ptr5 = __Dereference((gBaseString<char> + 4)) + gBaseString<char> + num4
					End If
					__Dereference(ival) = CLng((__Dereference(ptr5) - 48)) + __Dereference(ival) * 10L
					Dim num5 As Long = __Dereference(ival) * num
					If num5 > Me.UpperBound Then
						GoTo Block_30
					End If
					If num5 < Me.LowerBound Then
						GoTo Block_31
					End If
					num4 += 1
					If num4 >= __Dereference((gBaseString<char> + 4)) Then
						GoTo Block_32
					End If
				End While
				GoTo IL_2FB
				Block_22:
				Block_26:
				GoTo IL_2EC
				Block_30:
				Block_31:
				Block_32:
				GoTo IL_32B
				IL_29E:
				<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
				<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), num4)
				IL_2BD:
				<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
				<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), num4)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			IL_2EC:
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Return False
			IL_2FB:
			Try
				<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
				Dim num4 As Integer
				<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), num4)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			IL_32B:
			Try
				__Dereference(ival) *= num
				Dim upperBound As Long = Me.UpperBound
				If __Dereference(ival) > upperBound Then
					__Dereference(ival) = upperBound
				End If
				Dim lowerBound As Long = Me.LowerBound
				If __Dereference(ival) < lowerBound Then
					__Dereference(ival) = lowerBound
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Return True
		End Function

		Public Overrides Sub Refresh()
			Me.EditControl.Value = Me.GetValue()
			Me.EditControl.RaiseValidate()
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Sub UpdateControl(bounds As Rectangle)
			bounds.X += 1
			bounds.Y += 1
			bounds.Width -= 2
			bounds.Height -= 1
			If Me.EditControl IsNot Nothing Then
				Dim location As Point = bounds.Location
				Me.EditControl.Location = location
				Dim size As Size = bounds.Size
				Me.EditControl.Size = size
			Else
				Dim nNumericUpDown As NNumericUpDown = New NNumericUpDown()
				Me.EditControl = nNumericUpDown
				nNumericUpDown.BorderStyle = BorderStyle.None
				Dim location2 As Point = bounds.Location
				Me.EditControl.Location = location2
				Dim size2 As Size = bounds.Size
				Me.EditControl.Size = size2
				Me.EditControl.TabIndex = 1
				Me.EditControl.Value = Me.GetValue()
				Me.EditControl.LeftMargin = 1
				Me.EditControl.Minimum = Me.LowerBound
				Me.EditControl.Maximum = Me.UpperBound
				Me.EditControl.Increment = Me.StepValue
				Dim unValidatedColor As Color = Color.FromKnownColor(KnownColor.Red)
				Me.EditControl.UnValidatedColor = unValidatedColor
				If Me.IsDefault() Then
					Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Regular)
				Else
					Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Bold)
				End If
				Me.Host.Controls.Add(Me.EditControl)
				AddHandler Me.EditControl.Enter, AddressOf Me.EditControl_Enter
				AddHandler Me.EditControl.KeyDown, AddressOf Me.EditControl_KeyDown
				AddHandler Me.EditControl.Validated, AddressOf Me.EditControl_Validated
				AddHandler Me.EditControl.MouseDown, AddressOf Me.EditControl_MouseDown
			End If
		End Sub

		Public Overrides Sub DestroyControl()
			If Me.EditControl IsNot Nothing Then
				RemoveHandler Me.EditControl.Enter, AddressOf Me.EditControl_Enter
				RemoveHandler Me.EditControl.KeyDown, AddressOf Me.EditControl_KeyDown
				RemoveHandler Me.EditControl.Validated, AddressOf Me.EditControl_Validated
				RemoveHandler Me.EditControl.MouseDown, AddressOf Me.EditControl_MouseDown
				Me.Host.Controls.Remove(Me.EditControl)
				Me.EditControl = Nothing
			End If
		End Sub

		Public Overrides Function OnEnterPressed() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim editControl As NNumericUpDown = Me.EditControl
			If editControl IsNot Nothing Then
				editControl.Focus()
				Me.EditControl.SelectionLength = 0
			End If
			Me.Host.InvalidateViewControl()
			Return True
		End Function

		Public Sub New(default_value As Long, lower_bound As Long, upper_bound As Long, step_value As Long)
			Try
				Me.LowerBound = lower_bound
				Me.UpperBound = upper_bound
				Me.StepValue = step_value
				Me.DefaultValue = default_value
			Catch 
				MyBase.{dtor}()
				Throw
			End Try
		End Sub

		Public Overrides Function IsDefault() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Select Case __Dereference(CType(Me.Type, __Pointer(Of Integer)))
				Case 2
					Return(If((__Dereference(CType(Me.Var, __Pointer(Of SByte))) = CSByte(Me.[Default])), 1, 0)) <> 0
				Case 3
					Return(If((__Dereference(CType(Me.Var, __Pointer(Of Byte))) = CByte(Me.[Default])), 1, 0)) <> 0
				Case 4
					Return(If((__Dereference(CType(Me.Var, __Pointer(Of Short))) = CShort(Me.[Default])), 1, 0)) <> 0
				Case 5
					Return(If((__Dereference(CType(Me.Var, __Pointer(Of UShort))) = CUShort(Me.[Default])), 1, 0)) <> 0
				Case 6
					Return(If((__Dereference(CType(Me.Var, __Pointer(Of Integer))) = CInt(Me.[Default])), 1, 0)) <> 0
				Case 7
					Return(If((__Dereference(CType(Me.Var, __Pointer(Of Integer))) = CInt(Me.[Default])), 1, 0)) <> 0
				Case Else
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 711, CType((AddressOf <Module>.??_C@_0CK@PECOOCJM@NControls?3?3PropertyItemInteger?3?3@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BJ@CIEPDBBG@Unsupported?5integer?5type?$AA@), __Pointer(Of SByte)))
					Return False
			End Select
		End Function

		Public Overrides Sub SetDefault()
			Me.EditControl.Value = CLng(Me.[Default])
			Me.EditControl.RaiseValidate()
		End Sub

		Public Overrides Function HasDefaultOption() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return True
		End Function

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
