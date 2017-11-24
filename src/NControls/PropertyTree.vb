Imports GRTTI
Imports NWorkshop
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyTree
		Inherits BaseScrollableControl

		Public Delegate Sub __Delegate_ItemChanged()

		Public Delegate Sub __Delegate_SelectedIndexChanged()

		Private PropTreeDescription As Label

		Private PropTreeHeader As HeaderControl

		Private PropTreeCore As PropertyTreeCore

		Private PropTreeCorner As Control

		Public Custom Event SelectedIndexChanged As PropertyTree.__Delegate_SelectedIndexChanged
			AddHandler
				Me.SelectedIndexChanged = [Delegate].Combine(Me.SelectedIndexChanged, value)
			End AddHandler
			RemoveHandler
				Me.SelectedIndexChanged = [Delegate].Remove(Me.SelectedIndexChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event ItemChanged As PropertyTree.__Delegate_ItemChanged
			AddHandler
				Me.ItemChanged = [Delegate].Combine(Me.ItemChanged, value)
			End AddHandler
			RemoveHandler
				Me.ItemChanged = [Delegate].Remove(Me.ItemChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event TrackSelected As PropertyTreeCore.TrackSelectedHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.TrackSelected = [Delegate].Combine(Me.TrackSelected, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.TrackSelected = [Delegate].Remove(Me.TrackSelected, value)
			End RemoveHandler
		End Event

		Public ReadOnly Property OwnControls() As Control.ControlCollection
			Get
				Return MyBase.Controls
			End Get
		End Property

		Public ReadOnly Property Controls() As Control.ControlCollection
			Get
				Return Me.PropTreeCore.Controls
			End Get
		End Property

		Public ReadOnly Property ColumnDatas() As ArrayList
			Get
				Return Me.PropTreeCore.ColumnDatas
			End Get
		End Property

		Public Sub New(descriptionlines As Integer, objecttype As NewAssetPicker.ObjectType, clipboard As __Pointer(Of NPropertyClipboard))
			Me.ItemChanged = Nothing
			Me.SelectedIndexChanged = Nothing
			Me.TrackSelected = Nothing
			Dim backColor As Color = Color.FromKnownColor(KnownColor.Window)
			Me.BackColor = backColor
			Me.PropTreeDescription = New Label()
			Dim backColor2 As Color = Color.FromKnownColor(KnownColor.Control)
			Me.PropTreeDescription.BackColor = backColor2
			Dim foreColor As Color = Color.FromKnownColor(KnownColor.ControlText)
			Me.PropTreeDescription.ForeColor = foreColor
			Me.PropTreeDescription.BorderStyle = BorderStyle.Fixed3D
			Me.PropTreeDescription.Width = MyBase.Width
			Me.PropTreeDescription.Height = (Me.Font.Height + 2) * descriptionlines
			Me.PropTreeDescription.Dock = DockStyle.Bottom
			Me.PropTreeCore = New PropertyTreeCore(MyBase.Width, MyBase.Height, MyBase.Height, 2, Me.PropTreeDescription, objecttype, clipboard)
			Dim location As Point = New Point(0, 20)
			Me.PropTreeCore.Location = location
			Dim arrayList As ArrayList = New ArrayList()
			arrayList.Add(New ColumnItem(New String(CType((AddressOf <Module>.??_C@_07CKMABNOK@Setting?$AA@), __Pointer(Of SByte))), 90))
			arrayList.Add(New ColumnItem(New String(CType((AddressOf <Module>.??_C@_05LPIJGKJ@Value?$AA@), __Pointer(Of SByte))), 70))
			Dim enumerator As IEnumerator = arrayList.GetEnumerator()
			Dim proportion As Single = 1F / CSng(arrayList.Count)
			If enumerator.MoveNext() Then
				Do
					Dim columnItem As ColumnItem = TryCast(enumerator.Current, ColumnItem)
					Dim columnData As ColumnData = New ColumnData(columnItem.Name, CInt((CDec(columnItem.MinWidth))))
					columnData.Proportion = proportion
					Me.ColumnDatas.Add(columnData)
				Loop While enumerator.MoveNext()
			End If
			Me.PropTreeHeader = New HeaderControl(Me.PropTreeCore)
			Me.PropTreeHeader.Width = Me.PropTreeCore.GetViewControlWidth()
			Me.PropTreeHeader.Height = 20
			Me.PropTreeCorner = New Control()
			Dim location2 As Point = New Point(Me.PropTreeHeader.Width, 0)
			Me.PropTreeCorner.Location = location2
			Me.PropTreeCorner.Width = MyBase.Width - Me.PropTreeHeader.Width
			Me.PropTreeCorner.Height = 20
			Dim backColor3 As Color = Color.FromKnownColor(KnownColor.Control)
			Me.PropTreeCorner.BackColor = backColor3
			Dim num As Integer = MyBase.Height - Me.PropTreeHeader.Height
			Me.PropTreeCore.Height = num - Me.PropTreeDescription.Height
			Me.PropTreeHeader.RecalcColumnDatas()
			Me.PropTreeHeader.Refresh()
			Me.PropTreeCore.Refresh()
			Me.OwnControls.Add(Me.PropTreeHeader)
			Me.OwnControls.Add(Me.PropTreeCorner)
			Me.OwnControls.Add(Me.PropTreeCore)
			Me.OwnControls.Add(Me.PropTreeDescription)
			AddHandler Me.PropTreeCore.ItemChanged, AddressOf Me.PropTreeCore_ItemChanged
			AddHandler Me.PropTreeCore.SelectedIndexChanged, AddressOf Me.PropTreeCore_SelectedIndexChanged
			AddHandler Me.PropTreeCore.TrackSelected, AddressOf Me.PropTreeCore_TrackSelected
		End Sub

		Public Sub SetVariable(type As __Pointer(Of GClass), var As __Pointer(Of Void), measures As __Pointer(Of GMeasures))
			Me.PropTreeCore.SetVariable(type, var, measures)
			Me.PropTreeCore.SelectedIndex = 0
			Me.PropTreeCore.EnsureSelectedVisible()
			Me.PropTreeCore.Refresh()
		End Sub

		Public Sub SetVariableNoReset(type As __Pointer(Of GClass), var As __Pointer(Of Void), measures As __Pointer(Of GMeasures))
			Me.PropTreeCore.SetVariable(type, var, measures, False)
			Dim propTreeCore As PropertyTreeCore = Me.PropTreeCore
			If propTreeCore.SelectedIndex >= Me.PropTreeCore.Items.Count Then
				propTreeCore.SelectedIndex = 0
			End If
			Me.PropTreeCore.EnsureSelectedVisible()
			Me.PropTreeCore.Refresh()
		End Sub

		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			MyBase.OnSizeChanged(e)
			If Me.PropTreeCore IsNot Nothing Then
				Me.PropTreeCore.Width = MyBase.Width
				Dim num As Integer = MyBase.Height - Me.PropTreeHeader.Height
				Me.PropTreeCore.Height = num - Me.PropTreeDescription.Height
				Me.PropTreeHeader.Width = Me.PropTreeCore.GetViewControlWidth()
				Me.PropTreeHeader.RecalcColumnDatas()
				Me.PropTreeCorner.Width = MyBase.Width - Me.PropTreeHeader.Width
				Me.PropTreeCorner.Height = 20
				Dim location As Point = New Point(Me.PropTreeHeader.Width, 0)
				Me.PropTreeCorner.Location = location
				Me.PropTreeDescription.Width = MyBase.Width
				Me.PropTreeHeader.Refresh()
				Me.PropTreeCore.Refresh()
			End If
		End Sub

		Protected Overrides Sub OnGotFocus(e As EventArgs)
			Me.PropTreeCore.Focus()
		End Sub

		Private Sub PropTreeCore_ItemChanged()
			Me.raise_ItemChanged()
		End Sub

		Private Sub PropTreeCore_SelectedIndexChanged()
			Me.raise_SelectedIndexChanged()
		End Sub

		Private Sub PropTreeCore_TrackSelected(curveeditor As NCurveEditor)
			Me.raise_TrackSelected(curveeditor)
		End Sub

		Protected Sub raise_ItemChanged()
			Dim itemChanged As PropertyTree.__Delegate_ItemChanged = Me.ItemChanged
			If itemChanged IsNot Nothing Then
				itemChanged()
			End If
		End Sub

		Protected Sub raise_SelectedIndexChanged()
			Dim selectedIndexChanged As PropertyTree.__Delegate_SelectedIndexChanged = Me.SelectedIndexChanged
			If selectedIndexChanged IsNot Nothing Then
				selectedIndexChanged()
			End If
		End Sub

		Protected Sub raise_TrackSelected(i1 As NCurveEditor)
			Dim trackSelected As PropertyTreeCore.TrackSelectedHandler = Me.TrackSelected
			If trackSelected IsNot Nothing Then
				trackSelected(i1)
			End If
		End Sub
	End Class
End Namespace
