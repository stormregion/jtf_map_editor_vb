Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace NControls
	Public Class NFloatUpDown
		Inherits Control

		Private NumericBox As TextBox

		Private DraggerButton As Control

		Private DraggerCursor As Cursor

		Private propMinimum As Double

		Private propMaximum As Double

		Private propIncrement As Double

		Private propValue As Double

		Private propLeftMargin As Integer

		Private propUnValidatedColor As Color

		Private DropButtonLightBorderBrush As SolidBrush

		Private DropButtonDarkBorderBrush As SolidBrush

		Private DropButtonBackgroundBrush As SolidBrush

		Private DropButtonTextBrush As SolidBrush

		Private IsButtonPressed As Boolean

		Private IsMovedWhileButtonPressed As Boolean

		Private DragFromY As Integer

		Private StartPoint As Point

		Public Property UnValidatedColor() As Color
			Get
				Return Me.propUnValidatedColor
			End Get
			Set(value As Color)
				Me.propUnValidatedColor = value
			End Set
		End Property

		Public Property SelectionLength() As Integer
			Get
				Return Me.NumericBox.SelectionLength
			End Get
			Set(value As Integer)
				Me.NumericBox.SelectionLength = value
			End Set
		End Property

		Public Property BorderStyle() As BorderStyle
			Get
				Return Me.NumericBox.BorderStyle
			End Get
			Set(value As BorderStyle)
				Me.NumericBox.BorderStyle = value
			End Set
		End Property

		Public Property LeftMargin() As Integer
			Get
				Return Me.propLeftMargin
			End Get
			Set(value As Integer)
				Me.propLeftMargin = value
				Dim location As Point = New Point(value, 1)
				Me.NumericBox.Location = location
				Dim size As Size = New Size(MyBase.Width - Me.DraggerButton.Width - Me.propLeftMargin, MyBase.Height - 1)
				Me.NumericBox.Size = size
				Me.NumericBox.Invalidate()
			End Set
		End Property

		Public Property Value() As Double
			Get
				Return Me.propValue
			End Get
			Set(value As Double)
				If value < Me.Minimum Then
					value = Me.Minimum
				End If
				If value > Me.Maximum Then
					value = Me.Maximum
				End If
				Me.propValue = value
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>, CType((AddressOf <Module>.??_C@_02NJPGOMH@?$CFf?$AA@), __Pointer(Of SByte)), value)
				Try
					Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
					Dim value2 As __Pointer(Of SByte)
					If num <> 0UI Then
						value2 = num
					Else
						value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Me.NumericBox.Text = New String(CType(value2, __Pointer(Of SByte)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Me.NumericBox.Invalidate()
			End Set
		End Property

		Public Property Increment() As Double
			Get
				Return Me.propIncrement
			End Get
			Set(value As Double)
				Me.propIncrement = value
			End Set
		End Property

		Public Property Maximum() As Double
			Get
				Return Me.propMaximum
			End Get
			Set(value As Double)
				Me.propMaximum = value
				If Me.Value > value Then
					Me.Value = value
				End If
			End Set
		End Property

		Public Property Minimum() As Double
			Get
				Return Me.propMinimum
			End Get
			Set(value As Double)
				Me.propMinimum = value
				If Me.Value < value Then
					Me.Value = value
				End If
			End Set
		End Property

		Public Sub New()
			MyBase.Height = 16
			Me.propLeftMargin = 0
			Dim color As Color = Color.FromKnownColor(KnownColor.ControlLightLight)
			Me.DropButtonLightBorderBrush = New SolidBrush(color)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.ControlDark)
			Me.DropButtonDarkBorderBrush = New SolidBrush(color2)
			Dim color3 As Color = Color.FromKnownColor(KnownColor.Control)
			Me.DropButtonBackgroundBrush = New SolidBrush(color3)
			Dim color4 As Color = Color.FromKnownColor(KnownColor.ControlText)
			Me.DropButtonTextBrush = New SolidBrush(color4)
			Me.DraggerButton = New Control()
			Dim backColor As Color = Color.FromKnownColor(KnownColor.Window)
			Me.DraggerButton.BackColor = backColor
			Me.DraggerButton.Dock = DockStyle.Right
			Dim size As Size = New Size(16, 16)
			Me.DraggerButton.Size = size
			AddHandler Me.DraggerButton.MouseDown, AddressOf Me.DraggerButton_MouseDown
			AddHandler Me.DraggerButton.MouseUp, AddressOf Me.DraggerButton_MouseUp
			AddHandler Me.DraggerButton.MouseMove, AddressOf Me.DraggerButton_MouseMove
			AddHandler Me.DraggerButton.Paint, AddressOf Me.DraggerButton_Paint
			Me.NumericBox = New TextBox()
			Dim location As Point = New Point(Me.propLeftMargin, 1)
			Me.NumericBox.Location = location
			Dim size2 As Size = New Size(MyBase.Width - Me.DraggerButton.Width - Me.propLeftMargin, MyBase.Height - 1)
			Me.NumericBox.Size = size2
			AddHandler Me.NumericBox.KeyDown, AddressOf Me.NumericBox_KeyDown
			AddHandler Me.NumericBox.MouseDown, AddressOf Me.NumericBox_MouseDown
			AddHandler Me.NumericBox.Validated, AddressOf Me.NumericBox_Validated
			AddHandler Me.NumericBox.TextChanged, AddressOf Me.NumericBox_TextChanged
			MyBase.Controls.Add(Me.DraggerButton)
			MyBase.Controls.Add(Me.NumericBox)
			Me.Minimum = -1.7976931348623157E+308
			Me.Maximum = 1.7976931348623157E+308
			Me.Increment = 0.0
			Me.Value = 0.0
			Dim foreColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.NumericBox.ForeColor = foreColor
			Dim unValidatedColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.UnValidatedColor = unValidatedColor
			Me.IsButtonPressed = False
		End Sub

		Protected Overrides Sub OnGotFocus(e As EventArgs)
			Me.NumericBox.Focus()
		End Sub

		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			If Me.NumericBox IsNot Nothing Then
				Dim size As Size = New Size(MyBase.Width - Me.DraggerButton.Width - Me.propLeftMargin, MyBase.Height - 1)
				Me.NumericBox.Size = size
				Me.NumericBox.Invalidate()
			End If
		End Sub

		Public Sub RaiseValidate()
			Me.NumericBox_Validated(Me.NumericBox, Nothing)
		End Sub

		Private Sub DraggerButton_MouseDown(sender As Object, e As MouseEventArgs)
			Dim arg_06_0 As Cursor = Me.Cursor
			Me.DragFromY = Cursor.Position.Y
			Dim arg_20_0 As Cursor = Me.Cursor
			Dim position As Point = Cursor.Position
			Me.StartPoint = position
			Dim arg_34_0 As Cursor = Me.Cursor
			Cursor.Current = Cursors.SizeNS
			If Not Me.NumericBox.Focused Then
				Me.NumericBox.Focus()
			End If
			Me.IsButtonPressed = True
			Me.IsMovedWhileButtonPressed = False
			Me.DraggerButton.Invalidate()
			Me.OnMouseDown(e)
		End Sub

		Private Sub DraggerButton_MouseUp(sender As Object, e As MouseEventArgs)
			If Not Me.IsMovedWhileButtonPressed Then
				If e.Y <= 8 Then
					Me.Value += Me.Increment
				Else
					Me.Value -= Me.Increment
				End If
			End If
			Me.IsButtonPressed = False
			Me.DraggerButton.Invalidate()
			Dim arg_5F_0 As Integer = Screen.AllScreens(0).Bounds.Top
			Dim arg_66_0 As Cursor = Me.Cursor
			Cursor.Position = Me.StartPoint
			Me.NumericBox_Validated(Me.NumericBox, Nothing)
		End Sub

		Private Sub DraggerButton_MouseMove(sender As Object, e As MouseEventArgs)
			If Me.IsButtonPressed Then
				Dim arg_11_0 As Cursor = Me.Cursor
				Dim position As Point = Cursor.Position
				Me.Value -= CDec((position.Y - Me.DragFromY)) * Me.Increment
				Me.Value = CDec((<Module>.fround(CSng((Me.Value * 100000.0))) * 1E-05F))
				Dim arg_66_0 As Cursor = Me.Cursor
				Dim position2 As Point = Cursor.Position
				Dim flag As Boolean = False
				Dim num As Integer = Screen.AllScreens(0).Bounds.Right - 3
				If position2.X > num Then
					position2.X = Screen.AllScreens(0).Bounds.Left + 4
					flag = True
				Else
					Dim num2 As Integer = Screen.AllScreens(0).Bounds.Left + 3
					If position2.X < num2 Then
						position2.X = Screen.AllScreens(0).Bounds.Right - 4
						flag = True
					End If
				End If
				Dim num3 As Integer = Screen.AllScreens(0).Bounds.Bottom - 3
				If position2.Y > num3 Then
					position2.Y = Screen.AllScreens(0).Bounds.Top + 4
				Else
					Dim num4 As Integer = Screen.AllScreens(0).Bounds.Top + 3
					If position2.Y < num4 Then
						position2.Y = Screen.AllScreens(0).Bounds.Bottom - 4
					Else If Not flag Then
						GoTo IL_18D
					End If
				End If
				Dim arg_185_0 As Cursor = Me.Cursor
				Cursor.Position = position2
				IL_18D:
				Dim arg_193_0 As Cursor = Me.Cursor
				Me.DragFromY = Cursor.Position.Y
				Me.IsMovedWhileButtonPressed = True
			End If
		End Sub

		Private Sub DraggerButton_Paint(sender As Object, e As PaintEventArgs)
			Dim brush As SolidBrush
			Dim brush2 As SolidBrush
			If Me.IsButtonPressed Then
				brush = Me.DropButtonLightBorderBrush
				brush2 = Me.DropButtonDarkBorderBrush
			Else
				brush = Me.DropButtonDarkBorderBrush
				brush2 = Me.DropButtonLightBorderBrush
			End If
			e.Graphics.FillRectangle(Me.DropButtonBackgroundBrush, 0F, 0F, 16F, 16F)
			e.Graphics.FillRectangle(brush2, 0F, 0F, 15F, 1F)
			e.Graphics.FillRectangle(brush2, 0F, 0F, 1F, 15F)
			e.Graphics.FillRectangle(brush, 1F, 15F, 14F, 1F)
			e.Graphics.FillRectangle(brush, 15F, 0F, 1F, 15F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 8F, 4F, 1F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 7F, 5F, 3F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 6F, 6F, 5F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 6F, 9F, 5F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 7F, 10F, 3F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 8F, 11F, 1F, 1F)
		End Sub

		Private Sub NumericBox_KeyDown(__unnamed000 As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.Up Then
				Me.Value += Me.Increment
				e.Handled = True
			Else If e.KeyCode = Keys.Down Then
				Me.Value -= Me.Increment
				e.Handled = True
			Else If e.KeyCode = Keys.[Return] Then
				Me.NumericBox_Validated(Nothing, e)
			End If
			Me.OnKeyDown(e)
		End Sub

		Private Sub NumericBox_MouseDown(__unnamed000 As Object, e As MouseEventArgs)
			Me.OnMouseDown(e)
		End Sub

		Private Sub NumericBox_Validated(__unnamed000 As Object, e As EventArgs)
			Me.UpdateValueFromText()
			Dim foreColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.NumericBox.ForeColor = foreColor
			Me.OnValidated(e)
		End Sub

		Private Sub NumericBox_TextChanged(__unnamed000 As Object, e As EventArgs)
			Dim unValidatedColor As Color = Me.UnValidatedColor
			Me.NumericBox.ForeColor = unValidatedColor
			Me.OnTextChanged(e)
		End Sub

		Private Sub UpdateValueFromText()
			__Dereference(<Module>._errno()) = 0
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.NumericBox.Text)
			Dim value As Double
			Try
				Dim num As UInteger = CUInt((__Dereference(ptr)))
				value = <Module>.strtod(If((num = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num), Nothing)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			If __Dereference(<Module>._errno()) = 34 Then
				Dim value2 As Double = Me.Value
				Me.NumericBox.Text = value2.ToString()
				Me.NumericBox.Invalidate()
			Else
				Me.Value = value
			End If
		End Sub
	End Class
End Namespace
