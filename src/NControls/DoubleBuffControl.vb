Imports System
Imports System.Windows.Forms

Namespace NControls
	Public Class DoubleBuffControl
		Inherits Control

		Public Sub New(parent As Control, text As String, left As Integer, top As Integer, width As Integer, height As Integer)
			MyBase.New(parent, text, left, top, width, height)
			MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
			MyBase.UpdateStyles()
		End Sub

		Public Sub New()
			MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
			MyBase.UpdateStyles()
		End Sub
	End Class
End Namespace
