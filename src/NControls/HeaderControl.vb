Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms

Namespace NControls
	Public Class HeaderControl
		Inherits DoubleBuffControl

		Private ColumnControl As IMultiColumnControl

		Private DragIndex As Integer

		Private DragFromX As Integer

		Private ColumnHeaderLightBorderBrush As Brush

		Private ColumnHeaderDarkBorderBrush As Brush

		Private ColumnHeaderMediumBorderBrush As Brush

		Private ColumnHeaderBackgroundBrush As Brush

		Private ColumnHeaderTextBrush As Brush

		Public ReadOnly Property ColumnDatas() As ArrayList
			Get
				Return Me.ColumnControl.ColumnDatas
			End Get
		End Property

		Public Sub New(multicolumncontrol As IMultiColumnControl)
			Me.DragIndex = -1
			Dim color As Color = Color.FromKnownColor(KnownColor.ControlLightLight)
			Me.ColumnHeaderLightBorderBrush = New SolidBrush(color)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.ControlDark)
			Me.ColumnHeaderMediumBorderBrush = New SolidBrush(color2)
			Dim color3 As Color = Color.FromKnownColor(KnownColor.ControlDarkDark)
			Me.ColumnHeaderDarkBorderBrush = New SolidBrush(color3)
			Dim color4 As Color = Color.FromKnownColor(KnownColor.Control)
			Me.ColumnHeaderBackgroundBrush = New SolidBrush(color4)
			Dim color5 As Color = Color.FromKnownColor(KnownColor.ControlText)
			Me.ColumnHeaderTextBrush = New SolidBrush(color5)
			Me.ColumnControl = multicolumncontrol
			AddHandler MyBase.Paint, AddressOf Me.HeaderPaint
			AddHandler MyBase.MouseDown, AddressOf Me.HeaderMouseDown
			AddHandler MyBase.MouseUp, AddressOf Me.HeaderMouseUp
			AddHandler MyBase.MouseMove, AddressOf Me.HeaderMouseMove
		End Sub

		Public Sub RecalcColumnDatas()
			Dim columnData As ColumnData = Nothing
			If Me.ColumnDatas IsNot Nothing Then
				Dim enumerator As IEnumerator = Me.ColumnDatas.GetEnumerator()
				Dim num As Single = 0F
				Dim num2 As Single = 0F
				Dim num3 As Single = CSng(MyBase.Width)
				If enumerator.MoveNext() Then
					Do
						Dim columnData2 As ColumnData = TryCast(enumerator.Current, ColumnData)
						num3 -= columnData2.MinWidth
						num2 = columnData2.Proportion + num2
					Loop While enumerator.MoveNext()
				End If
				If num3 < 0F Then
					MyBase.Width = CInt((CDec((CSng(MyBase.Width) - num3))))
					num3 = 0F
				End If
				enumerator.Reset()
				If enumerator.MoveNext() Then
					Dim num4 As Single = 1F / num2
					Do
						columnData = (TryCast(enumerator.Current, ColumnData))
						columnData.StartX = num
						Dim num5 As Single = columnData.Proportion * num4 * num3 + columnData.MinWidth
						columnData.Width = num5
						num = num5 + num
					Loop While enumerator.MoveNext()
				End If
				Dim num6 As Single = columnData.Width + columnData.StartX
				If num6 > CSng(MyBase.Width) Then
					columnData.Width = CSng(MyBase.Width) - columnData.StartX
				End If
			End If
		End Sub

		Public Function ChangeColumnStartX(column_index As Integer, dx As Integer) As Integer
			Dim enumerator As IEnumerator = Me.ColumnDatas.GetEnumerator()
			Dim num As Single = CSng(MyBase.Width)
			If enumerator.MoveNext() Then
				Do
					Dim columnData As ColumnData = TryCast(enumerator.Current, ColumnData)
					num -= columnData.MinWidth
				Loop While enumerator.MoveNext()
			End If
			If num <= 0F Then
				Return 0
			End If
			Dim columnData2 As ColumnData = TryCast(Me.ColumnDatas(column_index), ColumnData)
			Dim num2 As Single = CSng(MyBase.Width) - columnData2.StartX
			Dim num3 As Single = 0F
			Dim num4 As Single = 0F
			enumerator = Me.ColumnDatas.GetRange(column_index, Me.ColumnDatas.Count - column_index).GetEnumerator()
			If enumerator.MoveNext() Then
				Do
					Dim columnData3 As ColumnData = TryCast(enumerator.Current, ColumnData)
					num3 = columnData3.MinWidth + num3
					num4 = columnData3.Proportion + num4
				Loop While enumerator.MoveNext()
				If num4 <> 0F Then
					GoTo IL_DE
				End If
			End If
			num4 = 1F
			IL_DE:
			num2 -= num3
			Dim num5 As Single = CSng(dx)
			Dim num6 As Single = num2 - num5
			If num6 < 0F Then
				dx = CInt((CDec(num2)))
				If column_index > 0 Then
					Dim columnData4 As ColumnData = TryCast(Me.ColumnDatas(column_index - 1), ColumnData)
					Dim num7 As Single = columnData4.Width + CSng(dx)
					If num7 >= columnData4.MinWidth Then
						columnData4.Width = num7
						columnData4.Proportion = (num7 - columnData4.MinWidth) / num
					Else
						If columnData4.Width <= columnData4.MinWidth Then
							Return 0
						End If
						dx = CInt((CDec((columnData4.MinWidth - columnData4.Width))))
						Dim minWidth As Single = columnData4.MinWidth
						columnData4.Width = minWidth
						columnData4.Proportion = (minWidth - columnData4.MinWidth) / num
					End If
				End If
				Dim num8 As Single = columnData2.StartX + CSng(dx)
				enumerator = Me.ColumnDatas.GetRange(column_index, Me.ColumnDatas.Count - column_index).GetEnumerator()
				If enumerator.MoveNext() Then
					Do
						Dim columnData5 As ColumnData = TryCast(enumerator.Current, ColumnData)
						columnData5.StartX = num8
						Dim minWidth2 As Single = columnData5.MinWidth
						columnData5.Width = minWidth2
						num8 = minWidth2 + num8
					Loop While enumerator.MoveNext()
				End If
				Return dx
			End If
			num2 = num6
			If num2 > 0F Then
				If column_index > 0 Then
					Dim columnData6 As ColumnData = TryCast(Me.ColumnDatas(column_index - 1), ColumnData)
					Dim num9 As Single = columnData6.Width + num5
					If num9 >= columnData6.MinWidth Then
						columnData6.Width = num9
						columnData6.Proportion = (num9 - columnData6.MinWidth) / num
					Else
						If columnData6.Width <= columnData6.MinWidth Then
							Return 0
						End If
						num2 = num5 + num2
						dx = CInt((CDec((columnData6.MinWidth - columnData6.Width))))
						num5 = CSng(dx)
						num2 -= num5
						Dim minWidth3 As Single = columnData6.MinWidth
						columnData6.Width = minWidth3
						columnData6.Proportion = (minWidth3 - columnData6.MinWidth) / num
					End If
				End If
				Dim num10 As Single = columnData2.StartX + num5
				enumerator = Me.ColumnDatas.GetRange(column_index, Me.ColumnDatas.Count - column_index).GetEnumerator()
				If enumerator.MoveNext() Then
					Dim num11 As Single = 1F / num4
					Dim num12 As Single = 1F / num
					Do
						Dim columnData7 As ColumnData = TryCast(enumerator.Current, ColumnData)
						columnData7.StartX = num10
						Dim num13 As Single = columnData7.Proportion * num11 * num2 + columnData7.MinWidth
						columnData7.Width = num13
						columnData7.Proportion = (num13 - columnData7.MinWidth) * num12
						num10 = columnData7.Width + num10
					Loop While enumerator.MoveNext()
				End If
				Return dx
			End If
			Return 0
		End Function

		Private Sub HeaderPaint(sender As Object, e As PaintEventArgs)
			Dim enumerator As IEnumerator = Me.ColumnDatas.GetEnumerator()
			Dim num As Single = 0F
			If enumerator.MoveNext() Then
				Do
					Dim columnData As ColumnData = TryCast(enumerator.Current, ColumnData)
					Dim num2 As Single = columnData.StartX + columnData.Width - num
					Dim width As Single = num2 - 3F
					Dim x As Single = num + 1F
					e.Graphics.FillRectangle(Me.ColumnHeaderBackgroundBrush, x, 1F, width, 17F)
					Dim x2 As Single = num + 2F
					e.Graphics.DrawString(columnData.Name, Me.Font, Me.ColumnHeaderTextBrush, x2, 2F)
					e.Graphics.FillRectangle(Me.ColumnHeaderLightBorderBrush, num, 0F, num2 - 1F, 1F)
					e.Graphics.FillRectangle(Me.ColumnHeaderLightBorderBrush, num, 0F, 1F, 20F)
					e.Graphics.FillRectangle(Me.ColumnHeaderDarkBorderBrush, x, 19F, num2 - 2F, 1F)
					Dim num3 As Single = num2 + num
					e.Graphics.FillRectangle(Me.ColumnHeaderDarkBorderBrush, num3 - 1F, 0F, 1F, 20F)
					e.Graphics.FillRectangle(Me.ColumnHeaderMediumBorderBrush, x2, 18F, width, 1F)
					e.Graphics.FillRectangle(Me.ColumnHeaderMediumBorderBrush, num3 - 2F, 1F, 1F, 18F)
					num = num3
				Loop While enumerator.MoveNext()
			End If
		End Sub

		Private Sub HeaderMouseDown(sender As Object, e As MouseEventArgs)
			Dim enumerator As IEnumerator = Me.ColumnDatas.GetEnumerator()
			Me.DragIndex = -1
			Dim num As Integer = 0
			If enumerator.MoveNext() Then
				Do
					Dim num2 As Single = CSng(e.X)
					Dim num3 As Single = num2 - (TryCast(enumerator.Current, ColumnData)).StartX
					If CSng(Math.Abs(CDec(num3))) < 5F Then
						GoTo IL_55
					End If
					num += 1
				Loop While enumerator.MoveNext()
				Return
				IL_55:
				Me.DragIndex = num
				Me.DragFromX = e.X
				Cursor.Current = Cursors.SizeWE
			End If
		End Sub

		Private Sub HeaderMouseUp(sender As Object, e As MouseEventArgs)
			Me.DragIndex = -1
		End Sub

		Private Sub HeaderMouseMove(sender As Object, e As MouseEventArgs)
			If Me.DragIndex > 0 Then
				Dim dx As Integer = e.X - Me.DragFromX
				Me.DragFromX = Me.ChangeColumnStartX(Me.DragIndex, dx) + Me.DragFromX
				Me.Refresh()
				Me.ColumnControl.ColumnsResized()
			Else
				Cursor.Current = Cursors.[Default]
				Dim enumerator As IEnumerator = Me.ColumnDatas.GetEnumerator()
				enumerator.MoveNext()
				If enumerator.MoveNext() Then
					Do
						Dim num As Single = CSng(e.X)
						Dim num2 As Single = num - (TryCast(enumerator.Current, ColumnData)).StartX
						If CSng(Math.Abs(CDec(num2))) < 5F Then
							GoTo IL_9D
						End If
					Loop While enumerator.MoveNext()
					Return
					IL_9D:
					Cursor.Current = Cursors.SizeWE
				End If
			End If
		End Sub
	End Class
End Namespace
