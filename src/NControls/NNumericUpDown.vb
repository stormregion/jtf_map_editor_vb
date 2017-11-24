Imports System
Imports System.Drawing
Imports System.Timers
Imports System.Windows.Forms

Namespace NControls
	Public Class NNumericUpDown
		Inherits Control

		Private NumericBox As TextBox

		Private DraggerButton As Control

		Private DraggerCursor As Cursor

		Private propMinimum As Long

		Private propMaximum As Long

		Private propIncrement As Long

		Private propValue As Long

		Private propLeftMargin As Integer

		Private propUnValidatedColor As Color

		Private DropButtonLightBorderBrush As SolidBrush

		Private DropButtonDarkBorderBrush As SolidBrush

		Private DropButtonBackgroundBrush As SolidBrush

		Private DropButtonTextBrush As SolidBrush

		Private ValueChangeTimer As System.Timers.Timer

		Private IsButtonUpPressed As Boolean

		Private IsButtonDownPressed As Boolean

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

		Public Overrides ReadOnly Property Text() As String
			Get
				Return Me.NumericBox.Text
			End Get
		End Property

		Public Property Value() As Long
			Get
				Return Me.propValue
			End Get
			Set(value As Long)
				If value < Me.Minimum Then
					value = Me.Minimum
				End If
				If value > Me.Maximum Then
					value = Me.Maximum
				End If
				Me.propValue = value
				Dim num As Long = value
				Me.NumericBox.Text = num.ToString()
				Me.NumericBox.Invalidate()
			End Set
		End Property

		Public Property Increment() As Long
			Get
				Return Me.propIncrement
			End Get
			Set(value As Long)
				Me.propIncrement = value
			End Set
		End Property

		Public Property Maximum() As Long
			Get
				Return Me.propMaximum
			End Get
			Set(value As Long)
				Me.propMaximum = value
				If Me.Value > value Then
					Me.Value = value
				End If
			End Set
		End Property

		Public Property Minimum() As Long
			Get
				Return Me.propMinimum
			End Get
			Set(value As Long)
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
			Dim foreColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.NumericBox.ForeColor = foreColor
			MyBase.Controls.Add(Me.DraggerButton)
			MyBase.Controls.Add(Me.NumericBox)
			Me.Minimum = -9223372036854775808L
			Me.Maximum = 9223372036854775807L
			Me.Increment = 0L
			Me.Value = 0L
			Dim foreColor2 As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.NumericBox.ForeColor = foreColor2
			Dim unValidatedColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.UnValidatedColor = unValidatedColor
			Me.ValueChangeTimer = New System.Timers.Timer()
			Me.IsButtonUpPressed = False
			Me.IsButtonDownPressed = False
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
			If Not Me.NumericBox.Focused Then
				Me.NumericBox.Focus()
			End If
			If e.Y <= 8 Then
				Me.IsButtonUpPressed = True
			Else
				Me.IsButtonDownPressed = True
			End If
			Me.DraggerButton.Invalidate()
			Me.NumericBox_Validated(Me.NumericBox, Nothing)
			Me.OnMouseDown(e)
		End Sub

		Private Sub TimedDecrease(source As Object, __unnamed001 As ElapsedEventArgs)
			Me.ValueChangeTimer.Interval = Me.ValueChangeTimer.Interval * 0.8
			Me.Value -= Me.Increment
		End Sub

		Private Sub TimedIncrease(source As Object, __unnamed001 As ElapsedEventArgs)
			Me.ValueChangeTimer.Interval = Me.ValueChangeTimer.Interval * 0.8
			Me.Value += Me.Increment
		End Sub

		Private Sub DraggerButton_MouseUp(sender As Object, e As MouseEventArgs)
			If e.Y <= 8 Then
				Me.Value += Me.Increment
				Me.IsButtonUpPressed = False
			Else
				Me.Value -= Me.Increment
				Me.IsButtonDownPressed = False
			End If
			Me.NumericBox_Validated(Me.NumericBox, Nothing)
			Me.DraggerButton.Invalidate()
		End Sub

		Private Sub DraggerButton_MouseMove(sender As Object, e As MouseEventArgs)
		End Sub

		Private Sub DraggerButton_Paint(sender As Object, e As PaintEventArgs)
			Dim dropButtonLightBorderBrush As SolidBrush
			Dim brush As SolidBrush
			Dim dropButtonDarkBorderBrush As SolidBrush
			Dim brush2 As SolidBrush
			If Me.IsButtonDownPressed Then
				dropButtonLightBorderBrush = Me.DropButtonLightBorderBrush
				brush = dropButtonLightBorderBrush
				dropButtonDarkBorderBrush = Me.DropButtonDarkBorderBrush
				brush2 = dropButtonDarkBorderBrush
			Else
				dropButtonDarkBorderBrush = Me.DropButtonDarkBorderBrush
				brush = dropButtonDarkBorderBrush
				dropButtonLightBorderBrush = Me.DropButtonLightBorderBrush
				brush2 = dropButtonLightBorderBrush
			End If
			Dim brush3 As SolidBrush
			Dim brush4 As SolidBrush
			If Me.IsButtonUpPressed Then
				brush3 = dropButtonLightBorderBrush
				brush4 = dropButtonDarkBorderBrush
			Else
				brush3 = dropButtonDarkBorderBrush
				brush4 = dropButtonLightBorderBrush
			End If
			e.Graphics.FillRectangle(Me.DropButtonBackgroundBrush, 0F, 0F, 16F, 16F)
			e.Graphics.FillRectangle(brush4, 0F, 0F, 15F, 1F)
			e.Graphics.FillRectangle(brush4, 0F, 0F, 1F, 8F)
			e.Graphics.FillRectangle(brush3, 1F, 7F, 14F, 1F)
			e.Graphics.FillRectangle(brush3, 15F, 0F, 1F, 8F)
			e.Graphics.FillRectangle(brush2, 0F, 8F, 15F, 1F)
			e.Graphics.FillRectangle(brush2, 0F, 8F, 1F, 8F)
			e.Graphics.FillRectangle(brush, 1F, 15F, 14F, 1F)
			e.Graphics.FillRectangle(brush, 15F, 8F, 1F, 8F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 8F, 3F, 1F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 7F, 4F, 3F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 7F, 11F, 3F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 8F, 12F, 1F, 1F)
		End Sub

		Private Sub NumericBox_KeyDown(__unnamed000 As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.Up Then
				Me.Value += Me.Increment
				e.Handled = True
			Else If e.KeyCode = Keys.Down Then
				Me.Value -= Me.Increment
				e.Handled = True
			Else If e.KeyCode = Keys.[Return] Then
				Me.UpdateValueFromText()
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
			Dim value As Long
			Try
				Dim num As UInteger = CUInt((__Dereference(ptr)))
				value = <Module>._strtoi64(If((num = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num), Nothing, 10)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			If __Dereference(<Module>._errno()) = 34 Then
				Dim value2 As Long = Me.Value
				Me.NumericBox.Text = value2.ToString()
				Me.NumericBox.Invalidate()
			Else
				Me.Value = value
			End If
		End Sub
	End Class
End Namespace
