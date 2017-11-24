Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxEntities
		Inherits UserControl
		Implements IRearrangeableControl

		Private components As Container

		Private Toolbar As Toolbar

		Public Overrides Custom Event Rearranged As ToolRearranged
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Rearranged = [Delegate].Combine(Me.Rearranged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Rearranged = [Delegate].Remove(Me.Rearranged, value)
			End RemoveHandler
		End Event

		Public Custom Event Action As ToolboxActionHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Action = [Delegate].Combine(Me.Action, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Action = [Delegate].Remove(Me.Action, value)
			End RemoveHandler
		End Event

		Public Custom Event DecalAction As ToolboxActionHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.DecalAction = [Delegate].Combine(Me.DecalAction, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.DecalAction = [Delegate].Remove(Me.DecalAction, value)
			End RemoveHandler
		End Event

		Public Custom Event FlagChanged As ToolboxFlagHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.FlagChanged = [Delegate].Combine(Me.FlagChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.FlagChanged = [Delegate].Remove(Me.FlagChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event ModeChanged As ToolboxModeHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.ModeChanged = [Delegate].Combine(Me.ModeChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.ModeChanged = [Delegate].Remove(Me.ModeChanged, value)
			End RemoveHandler
		End Event

		Public Sub New(items As __Pointer(Of GToolbarItem))
			Me.ModeChanged = Nothing
			Me.FlagChanged = Nothing
			Me.DecalAction = Nothing
			Me.Action = Nothing
			Me.Rearranged = Nothing
			Me.InitializeComponent()
			Me.Toolbar = New Toolbar(items, 24)
			AddHandler Me.Toolbar.ButtonClick, AddressOf Me.tbEntity_ButtonClick
			AddHandler Me.Toolbar.Rearranged, AddressOf Me.ChildRearranged
			Me.ResetToMove()
			MyBase.Controls.Add(Me.Toolbar)
			Dim size As Size = MyBase.Size
			Dim size2 As Size = New Size(MyBase.Size.Width, size.Height)
			Me.Toolbar.Size = size2
			Me.Toolbar.Dock = DockStyle.Top
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing Then
				Dim container As Container = Me.components
				If container IsNot Nothing Then
					container.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
			MyBase.Name = "ToolboxEntities"
			Dim size As Size = New Size(256, 80)
			MyBase.Size = size
		End Sub

		Public Sub EmulatePush(ordinal As Integer)
			Me.Toolbar.EmulatePush(ordinal)
		End Sub

		Public Sub EmulateUp(ordinal As Integer)
			Me.Toolbar.EmulateUp(ordinal)
		End Sub

		Public Sub EmulatePushByID(indx As Integer)
			Me.Toolbar.EmulatePushByID(indx)
		End Sub

		Public Sub EmulateUpByID(indx As Integer)
			Me.Toolbar.EmulateUpByID(indx)
		End Sub

		Public Sub NextTool()
			If Me.Toolbar.NextTool() = 1 Then
				Me.Toolbar.EmulatePush(-1)
				Me.Toolbar.EmulateUp(-1)
			End If
		End Sub

		Public Sub PrevTool()
			If Me.Toolbar.PrevTool() = 1 Then
				Me.Toolbar.EmulatePush(-1)
				Me.Toolbar.EmulateUp(-1)
			End If
		End Sub

		Public Sub NextGroup()
			Me.Toolbar.NextGroup()
		End Sub

		Public Sub PrevGroup()
			Me.Toolbar.PrevGroup()
		End Sub

		Public Sub ResetToMove()
			Me.Toolbar.SetItemPushed(1, True)
			Me.Toolbar.SetSelectedItem(1)
		End Sub

		Public Sub ResetToPlace()
			Me.Toolbar.SetItemPushed(2, True)
			Me.Toolbar.SetItemPushed(303, False)
			Me.Toolbar.SetSelectedItem(2)
			Me.raise_FlagChanged(FlagType.LOCK_SELECTION, False)
		End Sub

		Public Sub ResetToPlaceNode()
			Me.Toolbar.SetItemPushed(4, True)
			Me.Toolbar.SetItemPushed(303, False)
			Me.Toolbar.SetSelectedItem(4)
			Me.raise_FlagChanged(FlagType.LOCK_SELECTION, False)
		End Sub

		Private Sub ChildRearranged(sender As Object, newheight As Integer)
			If newheight <> MyBase.Size.Height Then
				Dim size As Size = New Size(MyBase.Size.Width, newheight)
				MyBase.Size = size
				Me.raise_Rearranged(sender, MyBase.Size.Height)
			End If
		End Sub

		Private Sub tbEntity_ButtonClick(idx As Integer, radio_group As Integer)
			If radio_group = 1 Then
				If idx = 2 Then
					Me.Toolbar.SetItemPushed(303, False)
					Me.raise_FlagChanged(FlagType.LOCK_SELECTION, False)
				End If
				Me.Toolbar.SetItemPushed(idx, True)
				Me.raise_ModeChanged(idx)
			Else If radio_group = 2 Then
				Me.raise_DecalAction(idx)
			Else If radio_group = 3 Then
				Me.raise_Action(idx)
			Else
				Dim toolbar As Toolbar = Me.Toolbar
				Dim flag As Boolean = (If((Not toolbar.GetItemPushed(idx)), 1, 0)) <> 0
				toolbar.SetItemPushed(idx, flag)
				Me.raise_FlagChanged(CType(idx, FlagType), flag)
			End If
		End Sub

		Protected Sub raise_ModeChanged(i1 As Integer)
			Dim modeChanged As ToolboxModeHandler = Me.ModeChanged
			If modeChanged IsNot Nothing Then
				modeChanged(i1)
			End If
		End Sub

		Protected Sub raise_FlagChanged(i1 As FlagType, <MarshalAs(UnmanagedType.U1)> i2 As Boolean)
			Dim flagChanged As ToolboxFlagHandler = Me.FlagChanged
			If flagChanged IsNot Nothing Then
				flagChanged(i1, i2)
			End If
		End Sub

		Protected Sub raise_DecalAction(i1 As Integer)
			Dim decalAction As ToolboxActionHandler = Me.DecalAction
			If decalAction IsNot Nothing Then
				decalAction(i1)
			End If
		End Sub

		Protected Sub raise_Action(i1 As Integer)
			Dim action As ToolboxActionHandler = Me.Action
			If action IsNot Nothing Then
				action(i1)
			End If
		End Sub

		Protected Sub raise_Rearranged(i1 As Object, i2 As Integer)
			Dim rearranged As ToolRearranged = Me.Rearranged
			If rearranged IsNot Nothing Then
				rearranged(i1, i2)
			End If
		End Sub
	End Class
End Namespace
