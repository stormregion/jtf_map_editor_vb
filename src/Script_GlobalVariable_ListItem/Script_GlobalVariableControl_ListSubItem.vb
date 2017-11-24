Imports System
Imports System.ComponentModel

Namespace Script_GlobalVariable_ListItem
	Public Class Script_GlobalVariableControl_ListSubItem
		Inherits Component

		Private mText As String

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
		End Sub
	End Class
End Namespace
