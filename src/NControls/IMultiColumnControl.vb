Imports System
Imports System.Collections

Namespace NControls
	Public Interface IMultiColumnControl
		ReadOnly Property ColumnDatas() As ArrayList

		Sub ColumnsResized()
	End Interface
End Namespace
