Imports NWorkshop
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace NControls
	Public Class NFilePickerTextBox
		Inherits Control

		Private FileTextBox As TextBox

		Private DraggerButton As Control

		Private DraggerCursor As Cursor

		Private propLeftMargin As Integer

		Private ObjType As NewAssetPicker.ObjectType

		Private FileType As Integer

		Private propUnValidatedColor As Color

		Private DropButtonLightBorderBrush As SolidBrush

		Private DropButtonDarkBorderBrush As SolidBrush

		Private DropButtonBackgroundBrush As SolidBrush

		Private DropButtonTextBrush As SolidBrush

		Public Property UnValidatedColor() As Color
			Get
				Return Me.propUnValidatedColor
			End Get
			Set(value As Color)
				Me.propUnValidatedColor = value
			End Set
		End Property

		Public Property BorderStyle() As BorderStyle
			Get
				Return Me.FileTextBox.BorderStyle
			End Get
			Set(value As BorderStyle)
				Me.FileTextBox.BorderStyle = value
			End Set
		End Property

		Public Property SelectionLength() As Integer
			Get
				Return Me.FileTextBox.SelectionLength
			End Get
			Set(value As Integer)
				Me.FileTextBox.SelectionLength = value
			End Set
		End Property

		Public Overrides Property Text() As String
			Get
				Return Me.FileTextBox.Text
			End Get
			Set(value As String)
				Me.FileTextBox.Text = value
			End Set
		End Property

		Public Property LeftMargin() As Integer
			Get
				Return Me.propLeftMargin
			End Get
			Set(value As Integer)
				Me.propLeftMargin = value
				Dim location As Point = New Point(value, 1)
				Me.FileTextBox.Location = location
				Dim size As Size = New Size(MyBase.Width - Me.DraggerButton.Width - Me.propLeftMargin, MyBase.Height - 1)
				Me.FileTextBox.Size = size
				Me.FileTextBox.Invalidate()
			End Set
		End Property

		Public Sub New(objecttype As NewAssetPicker.ObjectType, filetype As Integer)
			Me.ObjType = objecttype
			Me.FileType = filetype
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
			Dim control As Control = New Control()
			Me.DraggerButton = control
			control.Dock = DockStyle.Right
			Dim size As Size = New Size(16, 16)
			Me.DraggerButton.Size = size
			AddHandler Me.DraggerButton.MouseDown, AddressOf Me.DraggerButton_MouseDown
			AddHandler Me.DraggerButton.Click, AddressOf Me.DraggerButton_Click
			AddHandler Me.DraggerButton.Paint, AddressOf Me.DraggerButton_Paint
			Me.FileTextBox = New TextBox()
			Dim location As Point = New Point(Me.propLeftMargin, 1)
			Me.FileTextBox.Location = location
			Dim size2 As Size = New Size(MyBase.Width - Me.DraggerButton.Width - Me.propLeftMargin, MyBase.Height - 1)
			Me.FileTextBox.Size = size2
			AddHandler Me.FileTextBox.KeyDown, AddressOf Me.FileTextBox_KeyDown
			AddHandler Me.FileTextBox.MouseDown, AddressOf Me.FileTextBox_MouseDown
			AddHandler Me.FileTextBox.Validated, AddressOf Me.FileTextBox_Validated
			AddHandler Me.FileTextBox.TextChanged, AddressOf Me.FileTextBox_TextChanged
			MyBase.Controls.Add(Me.DraggerButton)
			MyBase.Controls.Add(Me.FileTextBox)
			Dim foreColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.FileTextBox.ForeColor = foreColor
			Dim unValidatedColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.UnValidatedColor = unValidatedColor
		End Sub

		Protected Overrides Sub OnGotFocus(e As EventArgs)
			Me.FileTextBox.Focus()
		End Sub

		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			If Me.FileTextBox IsNot Nothing Then
				Dim size As Size = New Size(MyBase.Width - Me.DraggerButton.Width - Me.propLeftMargin, MyBase.Height - 1)
				Me.FileTextBox.Size = size
				Me.FileTextBox.Invalidate()
			End If
		End Sub

		Public Sub RaiseValidate()
			Me.FileTextBox_Validated(Me.FileTextBox, Nothing)
		End Sub

		Private Sub DraggerButton_MouseDown(sender As Object, e As MouseEventArgs)
			Me.OnMouseDown(e)
		End Sub

		Private Sub DraggerButton_Click(sender As Object, e As EventArgs)
			MyBase.Focus()
			Me.SelectionLength = 0
			Dim newAssetPicker As NewAssetPicker = New NewAssetPicker(Me.ObjType, Me.FileType)
			newAssetPicker.StartPosition = FormStartPosition.CenterScreen
			If newAssetPicker.ShowDialog() = DialogResult.OK Then
				Me.FileTextBox.Text = newAssetPicker.NewName
				Me.FileTextBox_Validated(Me.FileTextBox, e)
			End If
			newAssetPicker.Dispose()
			Me.OnClick(e)
		End Sub

		Private Sub DraggerButton_Paint(sender As Object, e As PaintEventArgs)
			e.Graphics.FillRectangle(Me.DropButtonBackgroundBrush, 0F, 0F, 16F, 16F)
			e.Graphics.FillRectangle(Me.DropButtonLightBorderBrush, 0F, 0F, 15F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonLightBorderBrush, 0F, 0F, 1F, 15F)
			e.Graphics.FillRectangle(Me.DropButtonDarkBorderBrush, 1F, 15F, 14F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonDarkBorderBrush, 15F, 0F, 1F, 15F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 6F, 6F, 1F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 8F, 6F, 1F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 10F, 6F, 1F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 6F, 9F, 5F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 7F, 10F, 3F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, 8F, 11F, 1F, 1F)
		End Sub

		Private Sub FileTextBox_KeyDown(__unnamed000 As Object, e As KeyEventArgs)
			Me.OnKeyDown(e)
		End Sub

		Private Sub FileTextBox_MouseDown(__unnamed000 As Object, e As MouseEventArgs)
			If Not Me.FileTextBox.Focused Then
				Me.FileTextBox.Focus()
			End If
			Me.OnMouseDown(e)
		End Sub

		Private Sub FileTextBox_Validated(__unnamed000 As Object, e As EventArgs)
			Dim foreColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.FileTextBox.ForeColor = foreColor
			Me.OnValidated(e)
		End Sub

		Private Sub FileTextBox_TextChanged(__unnamed000 As Object, e As EventArgs)
			Dim unValidatedColor As Color = Me.UnValidatedColor
			Me.FileTextBox.ForeColor = unValidatedColor
			Me.OnTextChanged(e)
		End Sub
	End Class
End Namespace
