Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyItemFloat
		Inherits PropertyItem

		Protected EditControl As NFloatUpDown

		Protected LowerBound As Single

		Protected UpperBound As Single

		Protected StepValue As Single

		Protected DefaultValue As Single

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

		Protected Sub EditControl_Validated(sender As Object, e As EventArgs)
			Me.SetValue(Me.EditControl.Value)
			If Me.IsDefault() Then
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Regular)
			Else
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Bold)
			End If
		End Sub

		Protected Sub EditControl_MouseDown(__unnamed000 As Object, e As MouseEventArgs)
			Dim location As Point = Me.EditControl.Location
			Dim host As PropertyTreeCore = Me.Host
			host.SelectedIndex = CInt((CDec((CSng(location.Y) / host.ItemHeight))))
			Me.Host.EnsureSelectedVisible()
		End Sub

		Protected Overridable Function GetValue() As Double
			Select Case __Dereference(CType(Me.Type, __Pointer(Of Integer)))
				Case 8
					Return CDec((__Dereference(CType(Me.Var, __Pointer(Of Single)))))
				Case 9
					Return CDec((__Dereference(CType(Me.Var, __Pointer(Of Single))) / __Dereference(CType(Me.Host.Measures, __Pointer(Of Single)))))
				Case 10
					Return CDec((__Dereference(CType(Me.Var, __Pointer(Of Single))) / __Dereference(CType((Me.Host.Measures + 8 / __SizeOf(GMeasures)), __Pointer(Of Single)))))
				Case 11
					Return CDec((__Dereference(CType(Me.Var, __Pointer(Of Single))) / __Dereference(CType((Me.Host.Measures + 16 / __SizeOf(GMeasures)), __Pointer(Of Single)))))
				Case 12
					Return CDec((__Dereference(CType(Me.Var, __Pointer(Of Single))) / __Dereference(CType((Me.Host.Measures + 24 / __SizeOf(GMeasures)), __Pointer(Of Single)))))
				Case 13
					Return CDec((__Dereference(CType(Me.Var, __Pointer(Of Single))) / __Dereference(CType((Me.Host.Measures + 32 / __SizeOf(GMeasures)), __Pointer(Of Single)))))
				Case 14
					Return CDec((__Dereference(CType(Me.Var, __Pointer(Of Single))) / __Dereference(CType((Me.Host.Measures + 40 / __SizeOf(GMeasures)), __Pointer(Of Single)))))
				Case 15
					Return __Dereference(CType(Me.Var, __Pointer(Of Double)))
				Case Else
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 874, CType((AddressOf <Module>.??_C@_0CH@HHLOLGMI@NControls?3?3PropertyItemFloat?3?3Ge@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BJ@CIEPDBBG@Unsupported?5integer?5type?$AA@), __Pointer(Of SByte)))
					Return 0.0
			End Select
		End Function

		Protected Overridable Sub SetValue(value As Double)
			Select Case __Dereference(CType(Me.Type, __Pointer(Of Integer)))
				Case 8
					__Dereference(CType(Me.Var, __Pointer(Of Single))) = CSng(value)
				Case 9
					__Dereference(CType(Me.Var, __Pointer(Of Single))) = __Dereference(CType(Me.Host.Measures, __Pointer(Of Single))) * CSng(value)
				Case 10
					__Dereference(CType(Me.Var, __Pointer(Of Single))) = __Dereference(CType((Me.Host.Measures + 8 / __SizeOf(GMeasures)), __Pointer(Of Single))) * CSng(value)
				Case 11
					__Dereference(CType(Me.Var, __Pointer(Of Single))) = __Dereference(CType((Me.Host.Measures + 16 / __SizeOf(GMeasures)), __Pointer(Of Single))) * CSng(value)
				Case 12
					__Dereference(CType(Me.Var, __Pointer(Of Single))) = __Dereference(CType((Me.Host.Measures + 24 / __SizeOf(GMeasures)), __Pointer(Of Single))) * CSng(value)
				Case 13
					__Dereference(CType(Me.Var, __Pointer(Of Single))) = __Dereference(CType((Me.Host.Measures + 32 / __SizeOf(GMeasures)), __Pointer(Of Single))) * CSng(value)
				Case 14
					__Dereference(CType(Me.Var, __Pointer(Of Single))) = __Dereference(CType((Me.Host.Measures + 40 / __SizeOf(GMeasures)), __Pointer(Of Single))) * CSng(value)
				Case 15
					__Dereference(CType(Me.Var, __Pointer(Of Single))) = CSng(value)
				Case Else
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 907, CType((AddressOf <Module>.??_C@_0CH@IGJCKFLF@NControls?3?3PropertyItemFloat?3?3Se@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BH@IHKGLKBB@Unsupported?5float?5type?$AA@), __Pointer(Of SByte)))
					Return
			End Select
			MyBase.raise_ItemChanged()
			Me.Host.RaiseItemChanged()
		End Sub

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
				Dim nFloatUpDown As NFloatUpDown = New NFloatUpDown()
				Me.EditControl = nFloatUpDown
				nFloatUpDown.BorderStyle = BorderStyle.None
				Dim location2 As Point = bounds.Location
				Me.EditControl.Location = location2
				Dim size2 As Size = bounds.Size
				Me.EditControl.Size = size2
				Me.EditControl.TabIndex = 1
				Me.EditControl.Value = Me.GetValue()
				Me.EditControl.LeftMargin = 1
				Me.EditControl.Minimum = CDec(Me.LowerBound)
				Me.EditControl.Maximum = CDec(Me.UpperBound)
				Me.EditControl.Increment = CDec(Me.StepValue)
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
			Dim editControl As NFloatUpDown = Me.EditControl
			If editControl IsNot Nothing Then
				editControl.Focus()
				Me.EditControl.SelectionLength = 0
			End If
			Me.Host.InvalidateViewControl()
			Return True
		End Function

		Public Sub New(default_value As Single, lower_bound As Single, upper_bound As Single, step_value As Single)
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
			Return False
		End Function

		Public Overrides Sub SetDefault()
			Dim [default] As Integer = CInt(Me.[Default])
			Me.EditControl.Value = CDec([default])
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
