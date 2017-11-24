Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxVertex
		Inherits UserControl
		Implements IRearrangeableControl

		Public Delegate Sub BrushTypeChangeHandler(newtype As Integer)

		Public Delegate Sub VertexFlagChangeHandler(flag As Integer, <MarshalAs(UnmanagedType.U1)> value As Boolean)

		Public Delegate Sub SelectionTypeChangedHandler(newtype As Integer)

		Public Delegate Sub InvertSelectionHandler()

		Public Delegate Sub __Delegate_BrushTypeChanged( As Integer)

		Private components As IContainer

		Private BrushToolbox As BrushTools

		Private propBrushType As Integer

		Private propFalloffType As Integer

		Private tbBrush As Toolbar

		Private propSelectionType As Integer

		Private Additive As Boolean

		Private LockHeight As Boolean

		Public Custom Event BrushTypeChanged As ToolboxVertex.__Delegate_BrushTypeChanged
			AddHandler
				Me.BrushTypeChanged = [Delegate].Combine(Me.BrushTypeChanged, value)
			End AddHandler
			RemoveHandler
				Me.BrushTypeChanged = [Delegate].Remove(Me.BrushTypeChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event InvertSelection As ToolboxVertex.InvertSelectionHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.InvertSelection = [Delegate].Combine(Me.InvertSelection, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.InvertSelection = [Delegate].Remove(Me.InvertSelection, value)
			End RemoveHandler
		End Event

		Public Custom Event SelectionTypeChanged As ToolboxVertex.SelectionTypeChangedHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.SelectionTypeChanged = [Delegate].Combine(Me.SelectionTypeChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.SelectionTypeChanged = [Delegate].Remove(Me.SelectionTypeChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event VertexFlagChanged As ToolboxVertex.VertexFlagChangeHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.VertexFlagChanged = [Delegate].Combine(Me.VertexFlagChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.VertexFlagChanged = [Delegate].Remove(Me.VertexFlagChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event BrushFalloffTypeChanged As ToolboxVertex.BrushTypeChangeHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.BrushFalloffTypeChanged = [Delegate].Combine(Me.BrushFalloffTypeChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.BrushFalloffTypeChanged = [Delegate].Remove(Me.BrushFalloffTypeChanged, value)
			End RemoveHandler
		End Event

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

		Public Custom Event BrushParametersChanged As BrushTools.BrushParametersChangeHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.BrushParametersChanged = [Delegate].Combine(Me.BrushParametersChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.BrushParametersChanged = [Delegate].Remove(Me.BrushParametersChanged, value)
			End RemoveHandler
		End Event

		Public WriteOnly Property InvertEnable() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				Me.tbBrush.SetItemEnable(25, value)
			End Set
		End Property

		Public Property SelectionType() As Integer
			Get
				Return Me.propSelectionType
			End Get
			Set(value As Integer)
				Me.propSelectionType = value
				If value < 20 Then
					Me.tbBrush.SetGroupPushed(4, False)
				Else
					Me.tbBrush.SetItemPushed(value, True)
					Me.tbBrush.SetGroupPushed(1, False)
				End If
			End Set
		End Property

		Public Property LockObjectHeights() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return Me.LockHeight
			End Get
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				Me.LockHeight = value
				If Me.propSelectionType < 20 Then
					Me.tbBrush.SetItemPushed(201, value)
				End If
			End Set
		End Property

		Public Property AdditiveMode() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return Me.Additive
			End Get
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				Me.Additive = value
				Dim num As Integer = Me.propBrushType
				If(num <> 7 AndAlso num <> 1 AndAlso Me.propSelectionType < 20) OrElse Me.propSelectionType = 24 Then
					Me.tbBrush.SetItemPushed(200, value)
				End If
			End Set
		End Property

		Public Property FalloffType() As Integer
			Get
				Return Me.propFalloffType
			End Get
			Set(value As Integer)
				Me.propFalloffType = value
				If(Me.propBrushType <> 1 AndAlso Me.propSelectionType < 20) OrElse Me.propSelectionType = 24 Then
					Me.tbBrush.SetItemPushed(value, True)
				End If
			End Set
		End Property

		Public Property BrushType() As Integer
			Get
				Return Me.propBrushType
			End Get
			Set(value As Integer)
				Me.propBrushType = value
				Me.tbBrush.SetItemPushed(value, True)
			End Set
		End Property

		Public Sub New()
			Me.BrushTypeChanged = Nothing
			Me.BrushParametersChanged = Nothing
			Me.Rearranged = Nothing
			Me.BrushFalloffTypeChanged = Nothing
			Me.VertexFlagChanged = Nothing
			Me.SelectionTypeChanged = Nothing
			Me.InvertSelection = Nothing
			Me.InitializeComponent()
			Me.BrushToolbox = New BrushTools(True)
			AddHandler Me.BrushToolbox.BrushParametersChanged, AddressOf Me.InternalBrushParamChanged
			AddHandler Me.BrushToolbox.Rearranged, AddressOf Me.SlidersRearranged
			Dim location As Point = New Point(0, 36)
			Me.BrushToolbox.Location = location
			Me.BrushToolbox.Anchor = (AnchorStyles.Top Or AnchorStyles.Left)
			MyBase.Controls.Add(Me.BrushToolbox)
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0ToolboxVertex@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Me.tbBrush = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.tbBrush.ButtonClick, AddressOf Me.tbBrush_ButtonClick
			AddHandler Me.tbBrush.Rearranged, AddressOf Me.ToolbarRearranged
			Dim size As Size = MyBase.Size
			Dim size2 As Size = New Size(MyBase.Size.Width, size.Height)
			Me.tbBrush.Size = size2
			MyBase.Controls.Add(Me.tbBrush)
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing Then
				Dim container As IContainer = Me.components
				If container IsNot Nothing Then
					container.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			MyBase.Name = "ToolboxVertex"
			Dim size As Size = New Size(256, 256)
			MyBase.Size = size
			AddHandler MyBase.Resize, AddressOf Me.ToolboxVertex_Resize
		End Sub

		Public Sub ResetToNone()
			Me.tbBrush.SetGroupPushed(1, False)
			Me.BrushToolbox.SetBrushSize1(0)
		End Sub

		Public Sub SetBrushSize1(ByRef val As Single)
			Me.BrushToolbox.SetBrushSize1(val)
		End Sub

		Public Sub SetBrushSize2(ByRef val As Single)
			Me.BrushToolbox.SetBrushSize2(val)
		End Sub

		Public Sub SetBrushPressure(ByRef val As Single)
			Me.BrushToolbox.SetBrushPressure(val)
		End Sub

		Public Sub SetBrushHeight(ByRef val As Single)
			Me.BrushToolbox.SetBrushHeight(val)
		End Sub

		Public Sub EmulatePush(ordinal As Integer)
			Me.tbBrush.EmulatePush(ordinal)
		End Sub

		Public Sub EmulateUp(ordinal As Integer)
			Me.tbBrush.EmulateUp(ordinal)
		End Sub

		Private Sub ToolbarRearranged(sender As Object, newheight As Integer)
			Dim size As Size = MyBase.Size
			Dim size2 As Size = Me.BrushToolbox.Size
			If newheight <> size.Height - size2.Height Then
				Dim location As Point = New Point(0, newheight + 8)
				Me.BrushToolbox.Location = location
				Dim size3 As Size = Me.BrushToolbox.Size
				Dim size4 As Size = New Size(MyBase.Size.Width, size3.Height + newheight)
				MyBase.Size = size4
				Me.raise_Rearranged(sender, MyBase.Size.Height)
			End If
		End Sub

		Private Sub SlidersRearranged(sender As Object, newheight As Integer)
			Dim size As Size = MyBase.Size
			Dim size2 As Size = Me.tbBrush.Size
			If newheight <> size.Height - size2.Height Then
				Dim size3 As Size = Me.tbBrush.Size
				Dim size4 As Size = New Size(MyBase.Size.Width, size3.Height + newheight)
				MyBase.Size = size4
				Me.raise_Rearranged(sender, MyBase.Size.Height)
			End If
		End Sub

		Private Sub tbBrush_ButtonClick(idx As Integer, radio_group As Integer)
			If radio_group = 1 Then
				Me.BrushType = idx
				Me.raise_BrushTypeChanged(Me.BrushType)
				If idx <> 7 Then
					If idx <> 1 Then
						Me.tbBrush.SetGroupEnable(2, True)
						Me.tbBrush.SetItemPushed(Me.propFalloffType, True)
						Me.tbBrush.SetItemEnable(200, True)
						Me.tbBrush.SetItemPushed(200, Me.Additive)
						Me.raise_VertexFlagChanged(200, Me.Additive)
						GoTo IL_DB
					End If
					Me.tbBrush.SetGroupPushed(2, False)
					Me.tbBrush.SetGroupEnable(2, False)
				Else
					Me.tbBrush.SetGroupEnable(2, True)
					Me.tbBrush.SetItemPushed(Me.propFalloffType, True)
				End If
				Me.tbBrush.SetItemPushed(200, False)
				Me.tbBrush.SetItemEnable(200, False)
				IL_DB:
				Me.tbBrush.SetItemEnable(201, True)
				Me.tbBrush.SetItemPushed(201, Me.LockHeight)
				Me.raise_VertexFlagChanged(201, Me.LockHeight)
			Else If radio_group = 2 Then
				Me.tbBrush.SetItemPushed(idx, True)
				Me.raise_BrushFalloffTypeChanged(idx)
			Else If radio_group = 3 Then
				Dim toolbar As Toolbar = Me.tbBrush
				Dim flag As Boolean = (If((Not toolbar.GetItemPushed(idx)), 1, 0)) <> 0
				toolbar.SetItemPushed(idx, flag)
				Dim additive As Integer
				If flag AndAlso idx = 200 Then
					additive = 1
				Else
					additive = 0
				End If
				Me.Additive = (additive <> 0)
				Dim lockHeight As Integer
				If flag AndAlso idx = 201 Then
					lockHeight = 1
				Else
					lockHeight = 0
				End If
				Me.LockHeight = (lockHeight <> 0)
				Me.raise_VertexFlagChanged(idx, flag)
			Else If radio_group = 4 Then
				Me.tbBrush.SetItemPushed(idx, True)
				If idx = 24 Then
					Me.tbBrush.SetGroupEnable(2, True)
					Me.tbBrush.SetItemPushed(Me.propFalloffType, True)
					Me.tbBrush.SetItemEnable(200, True)
					Me.tbBrush.SetItemPushed(200, Me.Additive)
					Me.raise_VertexFlagChanged(200, Me.Additive)
				Else
					Me.tbBrush.SetGroupPushed(2, False)
					Me.tbBrush.SetGroupEnable(2, False)
					Me.tbBrush.SetItemPushed(200, False)
					Me.tbBrush.SetItemEnable(200, False)
				End If
				Me.tbBrush.SetItemPushed(201, False)
				Me.tbBrush.SetItemEnable(201, False)
				Me.propSelectionType = idx
				Me.raise_SelectionTypeChanged(idx)
			Else If radio_group = 5 Then
				Me.raise_InvertSelection()
			End If
		End Sub

		Private Sub InternalBrushParamChanged(size1 As Single, size2 As Single, pressure As Single, height As Single)
			Me.raise_BrushParametersChanged(size1, size2, pressure, height)
		End Sub

		Private Sub InternalBrushFalloffTypeChanged(newtype As Integer)
			Me.raise_BrushFalloffTypeChanged(newtype)
		End Sub

		Private Sub ToolboxVertex_Resize(sender As Object, e As EventArgs)
			Dim size As Size = Me.BrushToolbox.Size
			Dim size2 As Size = New Size(MyBase.Size.Width, size.Height)
			Me.BrushToolbox.Size = size2
		End Sub

		Protected Sub raise_BrushTypeChanged(i1 As Integer)
			Dim brushTypeChanged As ToolboxVertex.__Delegate_BrushTypeChanged = Me.BrushTypeChanged
			If brushTypeChanged IsNot Nothing Then
				brushTypeChanged(i1)
			End If
		End Sub

		Protected Sub raise_BrushParametersChanged(i1 As Single, i2 As Single, i3 As Single, i4 As Single)
			Dim brushParametersChanged As BrushTools.BrushParametersChangeHandler = Me.BrushParametersChanged
			If brushParametersChanged IsNot Nothing Then
				brushParametersChanged(i1, i2, i3, i4)
			End If
		End Sub

		Protected Sub raise_Rearranged(i1 As Object, i2 As Integer)
			Dim rearranged As ToolRearranged = Me.Rearranged
			If rearranged IsNot Nothing Then
				rearranged(i1, i2)
			End If
		End Sub

		Protected Sub raise_BrushFalloffTypeChanged(i1 As Integer)
			Dim brushFalloffTypeChanged As ToolboxVertex.BrushTypeChangeHandler = Me.BrushFalloffTypeChanged
			If brushFalloffTypeChanged IsNot Nothing Then
				brushFalloffTypeChanged(i1)
			End If
		End Sub

		Protected Sub raise_VertexFlagChanged(i1 As Integer, <MarshalAs(UnmanagedType.U1)> i2 As Boolean)
			Dim vertexFlagChanged As ToolboxVertex.VertexFlagChangeHandler = Me.VertexFlagChanged
			If vertexFlagChanged IsNot Nothing Then
				vertexFlagChanged(i1, i2)
			End If
		End Sub

		Protected Sub raise_SelectionTypeChanged(i1 As Integer)
			Dim selectionTypeChanged As ToolboxVertex.SelectionTypeChangedHandler = Me.SelectionTypeChanged
			If selectionTypeChanged IsNot Nothing Then
				selectionTypeChanged(i1)
			End If
		End Sub

		Protected Sub raise_InvertSelection()
			Dim invertSelection As ToolboxVertex.InvertSelectionHandler = Me.InvertSelection
			If invertSelection IsNot Nothing Then
				invertSelection()
			End If
		End Sub
	End Class
End Namespace
