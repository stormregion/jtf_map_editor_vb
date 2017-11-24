Imports System
Imports System.ComponentModel

Namespace Script_GlobalVariable_ListItem
	Public Class Script_GlobalVariableControl_ListItem
		Inherits Component

		Private mSubItems As Script_GlobalVariableControl_ListSubItem()

		Public Property SubItems() As Script_GlobalVariableControl_ListSubItem()
			Get
				Return Me.mSubItems
			End Get
			Set(value As Script_GlobalVariableControl_ListSubItem())
				Me.mSubItems = value
			End Set
		End Property

		Public Sub New()
			Me.mSubItems = New Script_GlobalVariableControl_ListSubItem(-1) {}
		End Sub
	End Class
End Namespace
