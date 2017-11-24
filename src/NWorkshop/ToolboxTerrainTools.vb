Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxTerrainTools
		Inherits UserControl
		Implements IRearrangeableControl

		Public Delegate Sub FillSelectionHandler(filltype As Integer)

		Public Delegate Sub ColorChangedHandler(newcolor As UInteger)

		Public Delegate Sub __Delegate_PaintTypeChanged( As Integer)

		Private components As IContainer

		Private BrushToolbox As BrushTools

		Private PaintTypeP As Integer

		Private tbPaint As Toolbar

		Private ColorTool As ColorPicker

		Private ExtraCPHeight As Integer

		Public Custom Event PaintTypeChanged As ToolboxTerrainTools.__Delegate_PaintTypeChanged
			AddHandler
				Me.PaintTypeChanged = [Delegate].Combine(Me.PaintTypeChanged, value)
			End AddHandler
			RemoveHandler
				Me.PaintTypeChanged = [Delegate].Remove(Me.PaintTypeChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event BrushColorChanged As ToolboxTerrainTools.ColorChangedHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.BrushColorChanged = [Delegate].Combine(Me.BrushColorChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.BrushColorChanged = [Delegate].Remove(Me.BrushColorChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event FillSelection As ToolboxTerrainTools.FillSelectionHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.FillSelection = [Delegate].Combine(Me.FillSelection, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.FillSelection = [Delegate].Remove(Me.FillSelection, value)
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

		Public WriteOnly Property FillEnable() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				Me.tbPaint.SetGroupEnable(2, value)
			End Set
		End Property

		Public Property PaintType() As Integer
			Get
				Return Me.PaintTypeP
			End Get
			Set(value As Integer)
				Me.PaintTypeP = value
				Me.tbPaint.SetItemPushed(value, True)
			End Set
		End Property

		Public Sub New()
			Me.Rearranged = Nothing
			Me.PaintTypeChanged = Nothing
			Me.BrushParametersChanged = Nothing
			Me.FillSelection = Nothing
			Me.BrushColorChanged = Nothing
			Me.InitializeComponent()
			Me.ColorTool = New ColorPicker()
			AddHandler Me.ColorTool.ValueChanged, AddressOf Me.ColorChanged
			MyBase.Controls.Add(Me.ColorTool)
			Me.BrushToolbox = New BrushTools(False)
			AddHandler Me.BrushToolbox.BrushParametersChanged, AddressOf Me.InternalBrushParamChanged
			AddHandler Me.BrushToolbox.Rearranged, AddressOf Me.SlidersRearranged
			Dim location As Point = New Point(0, 36)
			Me.BrushToolbox.Location = location
			Me.BrushToolbox.Anchor = (AnchorStyles.Top Or AnchorStyles.Left)
			MyBase.Controls.Add(Me.BrushToolbox)
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0ToolboxTerrainTools@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Me.tbPaint = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.tbPaint.ButtonClick, AddressOf Me.tbPaint_ButtonClick
			AddHandler Me.tbPaint.Rearranged, AddressOf Me.ToolbarRearranged
			Dim size As Size = MyBase.Size
			Dim size2 As Size = New Size(MyBase.Size.Width, size.Height)
			Me.tbPaint.Size = size2
			MyBase.Controls.Add(Me.tbPaint)
			Dim location2 As Point = Me.BrushToolbox.Location
			Dim location3 As Point = New Point(10, Me.BrushToolbox.Height + location2.Y)
			Me.ColorTool.Location = location3
			Me.ColorTool.Text = "Brush color"
			Me.ExtraCPHeight = 0
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
			MyBase.Name = "ToolboxTerrainTools"
			Dim size As Size = New Size(256, 192)
			MyBase.Size = size
			AddHandler MyBase.Resize, AddressOf Me.ToolboxTerrainTools_Resize
		End Sub

		Public Sub ResetToNone()
			Me.tbPaint.SetGroupPushed(1, False)
			Me.BrushToolbox.SetBrushSize1(0)
		End Sub

		Public Sub EmulatePush(ordinal As Integer)
			Me.tbPaint.EmulatePush(ordinal)
		End Sub

		Public Sub EmulateUp(ordinal As Integer)
			Me.tbPaint.EmulateUp(ordinal)
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

		Public Sub SetColor(color As UInteger)
			Dim gColor As GColor = (color >> 16 And 255) * 0.003921569F
			__Dereference((gColor + 4)) = (color >> 8 And 255) * 0.003921569F
			__Dereference((gColor + 8)) = (color And 255) * 0.003921569F
			__Dereference((gColor + 12)) = (color >> 24) * 0.003921569F
			Dim hue As Integer
			Dim sat As Integer
			Dim val As Integer
			<Module>.GColor.ToHSV(gColor, hue, sat, val)
			Me.ColorTool.Hue = hue
			Me.ColorTool.Sat = sat
			Me.ColorTool.Val = val
		End Sub

		Private Sub ToolbarRearranged(sender As Object, newheight As Integer)
			Dim size As Size = MyBase.Size
			Dim size2 As Size = Me.BrushToolbox.Size
			If newheight <> size.Height - size2.Height Then
				Dim location As Point = New Point(0, newheight + 8)
				Me.BrushToolbox.Location = location
				Dim location2 As Point = Me.BrushToolbox.Location
				Dim location3 As Point = New Point(10, Me.BrushToolbox.Height + location2.Y)
				Me.ColorTool.Location = location3
				Dim size3 As Size = Me.BrushToolbox.Size
				Dim size4 As Size = New Size(MyBase.Size.Width, size3.Height + Me.ExtraCPHeight + newheight)
				MyBase.Size = size4
				Me.raise_Rearranged(sender, MyBase.Size.Height)
			End If
		End Sub

		Private Sub SlidersRearranged(sender As Object, newheight As Integer)
			Dim size As Size = MyBase.Size
			Dim size2 As Size = Me.tbPaint.Size
			If newheight <> size.Height - size2.Height Then
				Dim location As Point = Me.BrushToolbox.Location
				Dim location2 As Point = New Point(10, Me.BrushToolbox.Height + location.Y)
				Me.ColorTool.Location = location2
				Dim size3 As Size = Me.tbPaint.Size
				Dim size4 As Size = New Size(MyBase.Size.Width, size3.Height + Me.ExtraCPHeight + newheight)
				MyBase.Size = size4
				Me.raise_Rearranged(sender, MyBase.Size.Height)
			End If
		End Sub

		Private Sub tbPaint_ButtonClick(idx As Integer, radio_group As Integer)
			If radio_group = 1 Then
				If idx = 15 AndAlso 15 <> Me.PaintType Then
					Me.ExtraCPHeight = 140
					Dim size As Size = MyBase.Size
					Dim size2 As Size = New Size(MyBase.Size.Width, size.Height + Me.ExtraCPHeight)
					MyBase.Size = size2
					Me.raise_Rearranged(Me, MyBase.Size.Height)
					Me.ColorChanged()
				Else If Me.PaintType = 15 AndAlso idx <> Me.PaintType Then
					Me.ExtraCPHeight = 0
					Dim size3 As Size = MyBase.Size
					Dim size4 As Size = New Size(MyBase.Size.Width, size3.Height + Me.ExtraCPHeight)
					MyBase.Size = size4
					Me.raise_Rearranged(Me, MyBase.Size.Height)
				End If
				Me.PaintType = idx
				Me.raise_PaintTypeChanged(Me.PaintType)
			Else If radio_group = 2 Then
				Me.raise_FillSelection(idx)
			End If
		End Sub

		Private Sub InternalBrushParamChanged(size1 As Single, size2 As Single, pressure As Single, height As Single)
			Me.raise_BrushParametersChanged(size1, size2, pressure, height)
		End Sub

		Private Sub ToolboxTerrainTools_Resize(sender As Object, e As EventArgs)
			Dim size As Size = Me.BrushToolbox.Size
			Dim size2 As Size = New Size(MyBase.Size.Width, size.Height)
			Me.BrushToolbox.Size = size2
		End Sub

		Private Sub ColorChanged()
			Dim gColor As GColor
			__Dereference((gColor + 8)) = 0F
			__Dereference((gColor + 4)) = 0F
			gColor = 0F
			__Dereference((gColor + 12)) = 1F
			Dim colorTool As ColorPicker = Me.ColorTool
			<Module>.GColor.FromHSV(gColor, colorTool.Hue, colorTool.Sat, colorTool.Val)
			Me.raise_BrushColorChanged(<Module>.GColor..K(gColor))
		End Sub

		Protected Sub raise_Rearranged(i1 As Object, i2 As Integer)
			Dim rearranged As ToolRearranged = Me.Rearranged
			If rearranged IsNot Nothing Then
				rearranged(i1, i2)
			End If
		End Sub

		Protected Sub raise_PaintTypeChanged(i1 As Integer)
			Dim paintTypeChanged As ToolboxTerrainTools.__Delegate_PaintTypeChanged = Me.PaintTypeChanged
			If paintTypeChanged IsNot Nothing Then
				paintTypeChanged(i1)
			End If
		End Sub

		Protected Sub raise_BrushParametersChanged(i1 As Single, i2 As Single, i3 As Single, i4 As Single)
			Dim brushParametersChanged As BrushTools.BrushParametersChangeHandler = Me.BrushParametersChanged
			If brushParametersChanged IsNot Nothing Then
				brushParametersChanged(i1, i2, i3, i4)
			End If
		End Sub

		Protected Sub raise_FillSelection(i1 As Integer)
			Dim fillSelection As ToolboxTerrainTools.FillSelectionHandler = Me.FillSelection
			If fillSelection IsNot Nothing Then
				fillSelection(i1)
			End If
		End Sub

		Protected Sub raise_BrushColorChanged(i1 As UInteger)
			Dim brushColorChanged As ToolboxTerrainTools.ColorChangedHandler = Me.BrushColorChanged
			If brushColorChanged IsNot Nothing Then
				brushColorChanged(i1)
			End If
		End Sub
	End Class
End Namespace
