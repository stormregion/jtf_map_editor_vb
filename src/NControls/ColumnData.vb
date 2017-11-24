Imports System

Namespace NControls
	Friend Class ColumnData
		Inherits ColumnItem

		Public StartX As Single

		Public Width As Single

		Public Proportion As Single

		Public Sub New(name As String, minwidth As Integer)
			MyBase.New(name, minwidth)
		End Sub
	End Class
End Namespace
