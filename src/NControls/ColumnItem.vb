Imports System

Namespace NControls
	Public Class ColumnItem
		Public Name As String

		Public MinWidth As Single

		Public Sub New(name As String, minwidth As Integer)
			Me.Name = String.Copy(name)
			Me.MinWidth = CSng(minwidth)
		End Sub
	End Class
End Namespace
