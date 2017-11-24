Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class GridControlCore
		Inherits ScrollableControl
		Implements IMultiColumnControl

		Public Delegate Sub __Delegate_ChooseItem( As Integer)

		Public Delegate Sub __Delegate_DoubleClickItem( As Integer)

		Private propItems As ArrayList

		Private propColumnDatas As ArrayList

		Private propSelectedIndex As Integer

		Private CellHeight As Single

		Public NormalItemBackgroundBrush As Brush

		Public SelectedItemBackgroundBrush As Brush

		Public NormalItemTextBrush As Brush

		Public SelectedItemTextBrush As Brush

		Public Custom Event DoubleClickItem As GridControlCore.__Delegate_DoubleClickItem
			AddHandler
				Me.DoubleClickItem = [Delegate].Combine(Me.DoubleClickItem, value)
			End AddHandler
			RemoveHandler
				Me.DoubleClickItem = [Delegate].Remove(Me.DoubleClickItem, value)
			End RemoveHandler
		End Event

		Public Custom Event ChooseItem As GridControlCore.__Delegate_ChooseItem
			AddHandler
				Me.ChooseItem = [Delegate].Combine(Me.ChooseItem, value)
			End AddHandler
			RemoveHandler
				Me.ChooseItem = [Delegate].Remove(Me.ChooseItem, value)
			End RemoveHandler
		End Event

		Public Property SelectedIndex() As Integer
			Get
				Return Me.propSelectedIndex
			End Get
			Set(value As Integer)
				Me.propSelectedIndex = value
			End Set
		End Property

		Public Overrides ReadOnly Property ColumnDatas() As ArrayList
			Get
				Return Me.propColumnDatas
			End Get
		End Property

		Public ReadOnly Property Items() As ArrayList
			Get
				Return Me.propItems
			End Get
		End Property

		Public Sub New(width As Integer, height As Integer, viewheight As Integer, scrollbarmode As Integer)
			MyBase.New(width, height, viewheight, scrollbarmode)
			Me.ChooseItem = Nothing
			Me.DoubleClickItem = Nothing
			Me.propItems = New ArrayList()
			Me.propColumnDatas = New ArrayList()
			Dim color As Color = Color.FromKnownColor(KnownColor.Window)
			Me.NormalItemBackgroundBrush = New SolidBrush(color)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.NormalItemTextBrush = New SolidBrush(color2)
			Dim color3 As Color = Color.FromKnownColor(KnownColor.ActiveCaption)
			Me.SelectedItemBackgroundBrush = New SolidBrush(color3)
			Dim color4 As Color = Color.FromKnownColor(KnownColor.ActiveCaptionText)
			Me.SelectedItemTextBrush = New SolidBrush(color4)
			AddHandler Me.ViewControl.Paint, AddressOf Me.ViewControlPaint
			AddHandler Me.ViewControl.MouseDown, AddressOf Me.ViewControlMouseDown
			AddHandler Me.ViewControl.DoubleClick, AddressOf Me.ViewControlDoubleClick
			Me.CellHeight = CSng((CDec(Me.Font.Height) + 5.0))
			Dim backColor As Color = Color.FromKnownColor(KnownColor.Window)
			Me.BackColor = backColor
		End Sub

		Private Sub ViewControlPaint(sender As Object, e As PaintEventArgs)
			Dim num As Integer = CInt((CDec((CSng(MyBase.StartY) / Me.CellHeight))))
			Dim num2 As Integer = CInt((CDec((CSng(MyBase.Height) / Me.CellHeight + 2F))))
			If num2 + num > Me.propItems.Count - 1 Then
				num2 = Me.propItems.Count - num
			End If
			Dim enumerator As IEnumerator = Me.propItems.GetRange(num, num2).GetEnumerator()
			Dim num3 As Integer = CInt((CDec((Me.CellHeight * CSng(num)))))
			If enumerator.MoveNext() Then
				Do
					If enumerator.Current.[GetType]().Equals(Type.[GetType]("System.Collections.ArrayList")) Then
						Dim enumerator2 As IEnumerator = (TryCast(enumerator.Current, ArrayList)).GetEnumerator()
						Dim enumerator3 As IEnumerator = Me.ColumnDatas.GetEnumerator()
						Dim num4 As Single = 0F
						If enumerator2.MoveNext() Then
							While enumerator3.MoveNext()
								Dim width As Single = (TryCast(enumerator3.Current, ColumnData)).Width
								Dim num5 As Single
								Dim brush As Brush
								If num <> Me.SelectedIndex Then
									num5 = CSng(num3)
									e.Graphics.FillRectangle(Me.NormalItemBackgroundBrush, num4, num5, width, Me.CellHeight)
									brush = Me.NormalItemTextBrush
								Else
									num5 = CSng(num3)
									e.Graphics.FillRectangle(Me.SelectedItemBackgroundBrush, num4, num5, width, Me.CellHeight)
									brush = Me.SelectedItemTextBrush
								End If
								e.Graphics.DrawString(enumerator2.Current.ToString(), Me.Font, brush, num4, num5 + 2F)
								num4 = width + num4
								If Not enumerator2.MoveNext() Then
									Exit While
								End If
							End While
						End If
					Else
						Dim brush As Brush
						If num <> Me.SelectedIndex Then
							brush = Me.NormalItemTextBrush
						Else
							e.Graphics.FillRectangle(Me.SelectedItemBackgroundBrush, 0F, CSng(num3), CSng(MyBase.Width), Me.CellHeight)
							brush = Me.SelectedItemTextBrush
						End If
						e.Graphics.DrawString(enumerator.Current.ToString(), Me.Font, brush, 0F, CSng(num3) + 1F)
					End If
					num3 = CInt((CDec((Me.CellHeight + CSng(num3)))))
					num += 1
				Loop While enumerator.MoveNext()
			End If
		End Sub

		Private Sub ViewControlMouseDown(sender As Object, e As MouseEventArgs)
			Me.SelectedIndex = CInt((CDec((CSng((e.Y - 1)) / Me.CellHeight))))
			Me.EnsureSelectedVisible()
			Me.raise_ChooseItem(Me.SelectedIndex)
		End Sub

		Private Sub ViewControlDoubleClick(sender As Object, e As EventArgs)
			Me.raise_DoubleClickItem(Me.SelectedIndex)
		End Sub

		Protected Overrides Function IsInputKey(keyData As Keys) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return True
		End Function

		Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
			If e.KeyCode = Keys.Up Then
				If Me.SelectedIndex > 0 Then
					Me.SelectedIndex -= 1
					Me.EnsureSelectedVisible()
				End If
				e.Handled = True
			End If
			If e.KeyCode = Keys.Down Then
				If Me.SelectedIndex < Me.Items.Count - 1 Then
					Me.SelectedIndex += 1
					Me.EnsureSelectedVisible()
				End If
				e.Handled = True
			End If
			If e.KeyCode = Keys.Home Then
				Me.SelectedIndex = 0
				Me.EnsureSelectedVisible()
				e.Handled = True
			End If
			If e.KeyCode = Keys.[End] Then
				If Me.Items.Count > 0 Then
					Me.SelectedIndex = Me.Items.Count - 1
					Me.EnsureSelectedVisible()
				End If
				e.Handled = True
			End If
			If e.KeyCode = Keys.Prior Then
				Dim num As Single = CSng(Me.SelectedIndex)
				Dim num2 As Integer = CInt((CDec((num - CSng(MyBase.Height) / Me.CellHeight + 1F))))
				If num2 >= 0 Then
					Me.SelectedIndex = num2
				Else
					Me.SelectedIndex = 0
				End If
				Me.EnsureSelectedVisible()
				e.Handled = True
			End If
			If e.KeyCode = Keys.[Next] Then
				Dim num3 As Integer = CInt((CDec((CSng(MyBase.Height) / Me.CellHeight + CSng(Me.SelectedIndex) - 1F))))
				If num3 < Me.Items.Count Then
					Me.SelectedIndex = num3
				Else
					Me.SelectedIndex = Me.Items.Count - 1
				End If
				Me.EnsureSelectedVisible()
				e.Handled = True
			End If
			MyBase.OnKeyDown(e)
			Me.raise_ChooseItem(Me.SelectedIndex)
		End Sub

		Public Function GetViewControlWidth() As Integer
			Return Me.ViewControl.Width
		End Function

		Public Sub UpdateViewHeight()
			MyBase.ViewHeight = CInt((CDec((CSng(Me.propItems.Count) * Me.CellHeight))))
		End Sub

		Public Sub EnsureSelectedVisible()
			If CSng(Me.SelectedIndex) * Me.CellHeight < CSng(MyBase.StartY) Then
				MyBase.StartY = CInt((CDec((CSng(Me.SelectedIndex) * Me.CellHeight))))
			Else
				Dim num As Single = CSng(Me.SelectedIndex) * Me.CellHeight - CSng(MyBase.StartY)
				If num > CSng(MyBase.Height) - Me.CellHeight Then
					Dim num2 As Single = CSng(Me.SelectedIndex) * Me.CellHeight
					MyBase.StartY = CInt((CDec((num2 - CSng(MyBase.Height) + Me.CellHeight))))
				End If
			End If
			Me.ViewControl.Refresh()
		End Sub

		Public Overrides Sub ColumnsResized()
			Me.ViewControl.Refresh()
		End Sub

		Protected Sub raise_ChooseItem(i1 As Integer)
			Dim chooseItem As GridControlCore.__Delegate_ChooseItem = Me.ChooseItem
			If chooseItem IsNot Nothing Then
				chooseItem(i1)
			End If
		End Sub

		Protected Sub raise_DoubleClickItem(i1 As Integer)
			Dim doubleClickItem As GridControlCore.__Delegate_DoubleClickItem = Me.DoubleClickItem
			If doubleClickItem IsNot Nothing Then
				doubleClickItem(i1)
			End If
		End Sub
	End Class
End Namespace
