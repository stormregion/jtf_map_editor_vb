Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms

Namespace NControls
	Public Class GridControl
		Inherits BaseScrollableControl

		Public Delegate Sub __Delegate_ChooseItem( As Integer)

		Public Delegate Sub __Delegate_DoubleClickItem( As Integer)

		Private GridHeader As HeaderControl

		Private GridCore As GridControlCore

		Private MyControlAddedHandler As ControlEventHandler

		Public Custom Event DoubleClickItem As GridControl.__Delegate_DoubleClickItem
			AddHandler
				Me.DoubleClickItem = [Delegate].Combine(Me.DoubleClickItem, value)
			End AddHandler
			RemoveHandler
				Me.DoubleClickItem = [Delegate].Remove(Me.DoubleClickItem, value)
			End RemoveHandler
		End Event

		Public Custom Event ChooseItem As GridControl.__Delegate_ChooseItem
			AddHandler
				Me.ChooseItem = [Delegate].Combine(Me.ChooseItem, value)
			End AddHandler
			RemoveHandler
				Me.ChooseItem = [Delegate].Remove(Me.ChooseItem, value)
			End RemoveHandler
		End Event

		Public ReadOnly Property OwnControls() As Control.ControlCollection
			Get
				Return MyBase.Controls
			End Get
		End Property

		Public ReadOnly Property Controls() As Control.ControlCollection
			Get
				Return Me.GridCore.Controls
			End Get
		End Property

		Public ReadOnly Property ColumnDatas() As ArrayList
			Get
				Return Me.GridCore.ColumnDatas
			End Get
		End Property

		Public Property SelectedIndex() As Integer
			Get
				Return Me.GridCore.SelectedIndex
			End Get
			Set(value As Integer)
				Me.GridCore.SelectedIndex = value
			End Set
		End Property

		Public ReadOnly Property Items() As ArrayList
			Get
				Return Me.GridCore.Items
			End Get
		End Property

		Public Sub New(width As Integer, height As Integer, column_items As ArrayList, scrollbarmode As Integer)
			Me.ChooseItem = Nothing
			Me.DoubleClickItem = Nothing
			MyBase.Width = width
			MyBase.Height = height
			Dim num As Integer = height - 20
			Dim expr_2C As Integer = num
			Me.GridCore = New GridControlCore(width, expr_2C, expr_2C, scrollbarmode)
			Dim location As Point = New Point(0, 20)
			Me.GridCore.Location = location
			Dim enumerator As IEnumerator = column_items.GetEnumerator()
			Dim proportion As Single = 1F / CSng(column_items.Count)
			If enumerator.MoveNext() Then
				Do
					Dim columnItem As ColumnItem = TryCast(enumerator.Current, ColumnItem)
					Dim columnData As ColumnData = New ColumnData(columnItem.Name, CInt((CDec(columnItem.MinWidth))))
					columnData.Proportion = proportion
					Me.ColumnDatas.Add(columnData)
				Loop While enumerator.MoveNext()
			End If
			Me.GridHeader = New HeaderControl(Me.GridCore)
			Me.GridHeader.Width = Me.GridCore.GetViewControlWidth()
			Me.GridHeader.Height = 20
			Me.GridHeader.RecalcColumnDatas()
			Me.OwnControls.Add(Me.GridHeader)
			Me.OwnControls.Add(Me.GridCore)
			AddHandler Me.GridCore.ChooseItem, AddressOf Me.GridCoreChooseItem
			AddHandler Me.GridCore.DoubleClickItem, AddressOf Me.GridCoreDoubleClickItem
		End Sub

		Public Sub GridCoreChooseItem(index As Integer)
			Me.raise_ChooseItem(index)
		End Sub

		Public Sub GridCoreDoubleClickItem(index As Integer)
			Me.raise_DoubleClickItem(index)
		End Sub

		Public Sub UpdateViewHeight()
			Me.GridCore.UpdateViewHeight()
		End Sub

		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			MyBase.OnSizeChanged(e)
			If Me.GridCore IsNot Nothing Then
				Me.GridCore.Width = MyBase.Width
				Me.GridCore.Height = MyBase.Height - 20
				Me.GridHeader.Width = Me.GridCore.GetViewControlWidth()
				Me.GridHeader.RecalcColumnDatas()
				Me.GridHeader.Refresh()
			End If
		End Sub

		Protected Sub raise_ChooseItem(i1 As Integer)
			Dim chooseItem As GridControl.__Delegate_ChooseItem = Me.ChooseItem
			If chooseItem IsNot Nothing Then
				chooseItem(i1)
			End If
		End Sub

		Protected Sub raise_DoubleClickItem(i1 As Integer)
			Dim doubleClickItem As GridControl.__Delegate_DoubleClickItem = Me.DoubleClickItem
			If doubleClickItem IsNot Nothing Then
				doubleClickItem(i1)
			End If
		End Sub
	End Class
End Namespace
