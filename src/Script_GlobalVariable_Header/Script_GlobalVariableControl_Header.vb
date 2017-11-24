Imports System
Imports System.ComponentModel

Namespace Script_GlobalVariable_Header
	Public Class Script_GlobalVariableControl_Header
		Inherits Component

		Private mText As String

		Private mWidth As Integer

		Public Property Width() As Integer
			Get
				Return Me.mWidth
			End Get
			Set(value As Integer)
				Me.mWidth = value
				If value < 1 Then
					Me.mWidth = 1
				End If
			End Set
		End Property

		Public Property Text() As String
			Get
				Return Me.mText
			End Get
			Set(value As String)
				Me.mText = value
			End Set
		End Property

		Public Sub New()
			Me.mText = ""
			Me.mWidth = 50
		End Sub
	End Class
End Namespace
