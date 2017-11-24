Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace NControls
	Public Class NImageButton
		Inherits Control

		Protected propImage As Image

		Protected IsButtonPressed As Boolean

		Public WriteOnly Property Image() As Image
			Set(value As Image)
				Me.propImage = value
			End Set
		End Property

		Public Sub New()
			AddHandler MyBase.Paint, AddressOf Me.OnPaint
			AddHandler MyBase.MouseDown, AddressOf Me.OnMouseDown
			AddHandler MyBase.MouseUp, AddressOf Me.OnMouseUp
		End Sub

		Protected Overridable Sub OnMouseDown(sender As Object, e As MouseEventArgs)
			Me.IsButtonPressed = True
			MyBase.Invalidate()
		End Sub

		Protected Overridable Sub OnMouseUp(sender As Object, e As MouseEventArgs)
			Me.IsButtonPressed = False
			MyBase.Invalidate()
		End Sub

		Protected Overridable Sub OnPaint(Sender As Object, e As PaintEventArgs)
			Dim brush As SolidBrush
			Dim brush2 As SolidBrush
			If Me.IsButtonPressed Then
				brush = New SolidBrush(Color.FromKnownColor(KnownColor.ControlLightLight))
				brush2 = New SolidBrush(Color.FromKnownColor(KnownColor.ControlDark))
			Else
				brush = New SolidBrush(Color.FromKnownColor(KnownColor.ControlDark))
				brush2 = New SolidBrush(Color.FromKnownColor(KnownColor.ControlLightLight))
			End If
			Dim color As Color = Color.FromKnownColor(KnownColor.Control)
			e.Graphics.FillRectangle(New SolidBrush(color), 0F, 0F, 16F, 16F)
			e.Graphics.FillRectangle(brush2, 0F, 0F, 15F, 1F)
			e.Graphics.FillRectangle(brush2, 0F, 0F, 1F, 15F)
			e.Graphics.FillRectangle(brush, 1F, 15F, 14F, 1F)
			e.Graphics.FillRectangle(brush, 15F, 0F, 1F, 15F)
			Dim image As Image = Me.propImage
			If image IsNot Nothing Then
				e.Graphics.DrawImage(image, 2F, 2F, 12F, 12F)
			End If
		End Sub
	End Class
End Namespace
