Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NCurveEditor
		Inherits UserControl

		Public Delegate Sub CurveChangedHandler()

		Private Type As Integer

		Private LinearScalarPrototype As __Pointer(Of GPCurveLinearScalar)

		Private LinearScalarEditor As __Pointer(Of GCurveLinearScalarEditor)

		Private LinearColorPrototype As __Pointer(Of GPCurveLinearColor)

		Private LinearColorEditor As __Pointer(Of GCurveLinearColorEditor)

		Private BezierScalarPrototype As __Pointer(Of GPCurveBezierScalar)

		Private BezierScalarEditor As __Pointer(Of GCurveBezierScalarEditor)

		Private ColorPanelToEditPanel As Integer

		Private HighlightNodeIndex As Integer

		Private CursorHidden As Boolean

		Private DragMode As Integer

		Private BaseMousePoint As Point

		Private PrevMousePoint As Point

		Private IViewport As RectangleF

		Private EnvelopRectangle As Rectangle

		Private EnvelopRectangleF As RectangleF

		Private SelectionRectangle As Rectangle

		Private X0 As Integer

		Private X1 As Integer

		Private X5 As Integer

		Private X10 As Integer

		Private Y0 As Integer

		Private Y1 As Integer

		Private YM1 As Integer

		Private Y5 As Integer

		Private YM5 As Integer

		Private Y10 As Integer

		Private YM10 As Integer

		Private Nodes As __Pointer(Of GArray<GKeyNode>)

		Private ContextMenuPosition As Point

		Private ContextMenuBlock As Boolean

		Private ContextMenuNodeIndex As Integer

		Private DisposeLinearScalarPrototype As Boolean

		Private DisposeLinearColorPrototype As Boolean

		Private DisposeBezierScalarPrototype As Boolean

		Private KeyMoveMode As Integer

		Private InvalidColorPanel As Boolean

		Private ColorPicker As ColorPicker

		Private TimeUpDown As NFloatUpDown

		Private ValueUpDown As NFloatUpDown

		Private EditPanelD3D As NDirect3D

		Private ColorPanelD3D As NDirect3D

		Private mainMenu1 As MainMenu

		Private menuItem4 As MenuItem

		Private menuItem7 As MenuItem

		Private [Exit] As MenuItem

		Private File As MenuItem

		Private [New] As MenuItem

		Private Open As MenuItem

		Private Save As MenuItem

		Private SaveAs As MenuItem

		Private Edit As MenuItem

		Private Undo As MenuItem

		Private [Select] As MenuItem

		Private All As MenuItem

		Private None As MenuItem

		Private Invert As MenuItem

		Private EditPanelContextMenu As ContextMenu

		Private AddKey As MenuItem

		Private RemoveKey As MenuItem

		Private ClearLoopStart As MenuItem

		Private ClearLoopEnd As MenuItem

		Private SetAsLoopStart As MenuItem

		Private SetAsLoopEnd As MenuItem

		Private PeekColor As MenuItem

		Private TimePanel As Panel

		Private ValuePanel As Panel

		Private Redo As MenuItem

		Private EditPanel As NSolidPanel

		Private StatusBar As StatusBar

		Private ColorPanel As NSolidPanel

		Private ParameterPanel As Panel

		Private TypeSelect As ComboBox

		Private components As Container

		Public Custom Event NotifyUndoStep As NCurveEditor.CurveChangedHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.NotifyUndoStep = [Delegate].Combine(Me.NotifyUndoStep, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.NotifyUndoStep = [Delegate].Remove(Me.NotifyUndoStep, value)
			End RemoveHandler
		End Event

		Public Sub New(prototype As __Pointer(Of GPCurveBezierScalar), keylimit As __Pointer(Of GKeyLimit))
			Me.Type = 2
			Me.HighlightNodeIndex = -1
			Me.DragMode = 0
			Me.NotifyUndoStep = Nothing
			Me.InitializeComponent()
			Me.InitializeComponent2(Nothing, Nothing, prototype, keylimit)
		End Sub

		Public Sub New(prototype As __Pointer(Of GPCurveBezierScalar))
			Me.Type = 2
			Me.HighlightNodeIndex = -1
			Me.DragMode = 0
			Me.NotifyUndoStep = Nothing
			Me.InitializeComponent()
			Me.InitializeComponent2(Nothing, Nothing, prototype, Nothing)
		End Sub

		Public Sub New(prototype As __Pointer(Of GPCurveLinearColor))
			Me.Type = 1
			Me.HighlightNodeIndex = -1
			Me.DragMode = 0
			Me.NotifyUndoStep = Nothing
			Me.InitializeComponent()
			Me.InitializeComponent2(Nothing, prototype, Nothing, Nothing)
		End Sub

		Public Sub New(prototype As __Pointer(Of GPCurveLinearScalar), keylimit As __Pointer(Of GKeyLimit))
			Me.Type = 0
			Me.HighlightNodeIndex = -1
			Me.DragMode = 0
			Me.NotifyUndoStep = Nothing
			Me.InitializeComponent()
			Me.InitializeComponent2(prototype, Nothing, Nothing, keylimit)
		End Sub

		Public Sub New(prototype As __Pointer(Of GPCurveLinearScalar))
			Me.Type = 0
			Me.HighlightNodeIndex = -1
			Me.DragMode = 0
			Me.NotifyUndoStep = Nothing
			Me.InitializeComponent()
			Me.InitializeComponent2(prototype, Nothing, Nothing, Nothing)
		End Sub

		Public Sub New()
			Me.Type = 0
			Me.HighlightNodeIndex = -1
			Me.DragMode = 0
			Me.NotifyUndoStep = Nothing
			Me.InitializeComponent()
			Me.InitializeComponent2(Nothing, Nothing, Nothing, Nothing)
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing Then
				Dim container As Container = Me.components
				If container IsNot Nothing Then
					container.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
			Dim nodes As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
			If nodes IsNot Nothing Then
				Dim ptr As __Pointer(Of GArray<GKeyNode>) = nodes
				Dim arg_42_0 As __Pointer(Of Integer) = __Dereference(CType((ptr + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer)))
				Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
				If num <> 0UI Then
					<Module>.free(num)
					__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
				End If
				__Dereference(arg_42_0) = 0
				__Dereference(CType((ptr + 8 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer))) = 0
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
			End If
			Dim linearScalarEditor As __Pointer(Of GCurveLinearScalarEditor) = Me.LinearScalarEditor
			If linearScalarEditor IsNot Nothing Then
				Dim ptr2 As __Pointer(Of GCurveLinearScalarEditor) = linearScalarEditor
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.{dtor}(ptr2)
				<Module>.delete(CType(ptr2, __Pointer(Of Void)))
			End If
			If Me.DisposeLinearScalarPrototype Then
				Dim linearScalarPrototype As __Pointer(Of GPCurveLinearScalar) = Me.LinearScalarPrototype
				If linearScalarPrototype IsNot Nothing Then
					Dim ptr3 As __Pointer(Of GPCurveLinearScalar) = linearScalarPrototype
					Dim arg_90_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, __Dereference((__Dereference(CType(ptr3, __Pointer(Of Integer))))))
				End If
			End If
			If Me.DisposeLinearColorPrototype Then
				Dim linearColorPrototype As __Pointer(Of GPCurveLinearColor) = Me.LinearColorPrototype
				If linearColorPrototype IsNot Nothing Then
					Dim ptr4 As __Pointer(Of GPCurveLinearColor) = linearColorPrototype
					Dim arg_B2_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, __Dereference((__Dereference(CType(ptr4, __Pointer(Of Integer))))))
				End If
			End If
			If Me.DisposeBezierScalarPrototype Then
				Dim bezierScalarPrototype As __Pointer(Of GPCurveBezierScalar) = Me.BezierScalarPrototype
				If bezierScalarPrototype IsNot Nothing Then
					Dim ptr5 As __Pointer(Of GPCurveBezierScalar) = bezierScalarPrototype
					Dim arg_D1_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr5, 1, __Dereference((__Dereference(CType(ptr5, __Pointer(Of Integer))))))
				End If
			End If
		End Sub

		Private Sub InitializeComponent()
			Me.EditPanelContextMenu = New ContextMenu()
			Me.AddKey = New MenuItem()
			Me.RemoveKey = New MenuItem()
			Me.SetAsLoopStart = New MenuItem()
			Me.SetAsLoopEnd = New MenuItem()
			Me.ClearLoopStart = New MenuItem()
			Me.ClearLoopEnd = New MenuItem()
			Me.PeekColor = New MenuItem()
			Me.StatusBar = New StatusBar()
			Me.ParameterPanel = New Panel()
			Me.ValuePanel = New Panel()
			Me.TimePanel = New Panel()
			Me.TypeSelect = New ComboBox()
			Me.mainMenu1 = New MainMenu()
			Me.File = New MenuItem()
			Me.New = New MenuItem()
			Me.Open = New MenuItem()
			Me.menuItem4 = New MenuItem()
			Me.Save = New MenuItem()
			Me.SaveAs = New MenuItem()
			Me.menuItem7 = New MenuItem()
			Me.[Exit] = New MenuItem()
			Me.Edit = New MenuItem()
			Me.Undo = New MenuItem()
			Me.Redo = New MenuItem()
			Me.[Select] = New MenuItem()
			Me.All = New MenuItem()
			Me.None = New MenuItem()
			Me.Invert = New MenuItem()
			Me.ParameterPanel.SuspendLayout()
			MyBase.SuspendLayout()
			Dim items As MenuItem() = New MenuItem() { Me.AddKey, Me.RemoveKey, Me.SetAsLoopStart, Me.SetAsLoopEnd, Me.ClearLoopStart, Me.ClearLoopEnd, Me.PeekColor }
			Me.EditPanelContextMenu.MenuItems.AddRange(items)
			AddHandler Me.EditPanelContextMenu.Popup, AddressOf Me.EditPanelContextMenu_Popup
			Me.AddKey.Index = 0
			Me.AddKey.Text = "Add key"
			AddHandler Me.AddKey.Click, AddressOf Me.AddKey_Click
			Me.RemoveKey.Index = 1
			Me.RemoveKey.Text = "Remove key"
			AddHandler Me.RemoveKey.Click, AddressOf Me.RemoveKey_Click
			Me.SetAsLoopStart.Index = 2
			Me.SetAsLoopStart.Text = "Set as loop start"
			AddHandler Me.SetAsLoopStart.Click, AddressOf Me.SetAsLoopStart_Click
			Me.SetAsLoopEnd.Index = 3
			Me.SetAsLoopEnd.Text = "Set as loop end"
			AddHandler Me.SetAsLoopEnd.Click, AddressOf Me.SetAsLoopEnd_Click
			Me.ClearLoopStart.Checked = True
			Me.ClearLoopStart.Index = 4
			Me.ClearLoopStart.Text = "Clear loop start"
			AddHandler Me.ClearLoopStart.Click, AddressOf Me.ClearLoopStart_Click
			Me.ClearLoopEnd.Checked = True
			Me.ClearLoopEnd.Index = 5
			Me.ClearLoopEnd.Text = "Clear loop end"
			AddHandler Me.ClearLoopEnd.Click, AddressOf Me.ClearLoopEnd_Click
			Me.PeekColor.Index = 6
			Me.PeekColor.Text = "Peek color"
			AddHandler Me.PeekColor.Click, AddressOf Me.PeekColor_Click
			Dim location As Point = New Point(0, 457)
			Me.StatusBar.Location = location
			Me.StatusBar.Name = "StatusBar"
			Dim size As Size = New Size(632, 24)
			Me.StatusBar.Size = size
			Me.StatusBar.TabIndex = 1
			Me.ParameterPanel.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left)
			Me.ParameterPanel.Controls.Add(Me.ValuePanel)
			Me.ParameterPanel.Controls.Add(Me.TimePanel)
			Me.ParameterPanel.Controls.Add(Me.TypeSelect)
			Dim location2 As Point = New Point(8, 8)
			Me.ParameterPanel.Location = location2
			Me.ParameterPanel.Name = "ParameterPanel"
			Dim size2 As Size = New Size(256, 448)
			Me.ParameterPanel.Size = size2
			Me.ParameterPanel.TabIndex = 3
			Dim window As Color = SystemColors.Window
			Me.ValuePanel.BackColor = window
			Me.ValuePanel.BorderStyle = BorderStyle.Fixed3D
			Dim location3 As Point = New Point(128, 0)
			Me.ValuePanel.Location = location3
			Me.ValuePanel.Name = "ValuePanel"
			Dim size3 As Size = New Size(128, 24)
			Me.ValuePanel.Size = size3
			Me.ValuePanel.TabIndex = 2
			Dim window2 As Color = SystemColors.Window
			Me.TimePanel.BackColor = window2
			Me.TimePanel.BorderStyle = BorderStyle.Fixed3D
			Dim location4 As Point = New Point(0, 0)
			Me.TimePanel.Location = location4
			Me.TimePanel.Name = "TimePanel"
			Dim size4 As Size = New Size(128, 24)
			Me.TimePanel.Size = size4
			Me.TimePanel.TabIndex = 1
			Me.TypeSelect.DropDownStyle = ComboBoxStyle.DropDownList
			Me.TypeSelect.Enabled = False
			Me.TypeSelect.ImeMode = ImeMode.NoControl
			Dim items2 As Object() = New Object() { "Linear Scalar", "Linear Color", "Bezier Scalar" }
			Me.TypeSelect.Items.AddRange(items2)
			Dim location5 As Point = New Point(8, 400)
			Me.TypeSelect.Location = location5
			Me.TypeSelect.Name = "TypeSelect"
			Dim size5 As Size = New Size(96, 21)
			Me.TypeSelect.Size = size5
			Me.TypeSelect.TabIndex = 0
			Me.TypeSelect.Visible = False
			AddHandler Me.TypeSelect.SelectedIndexChanged, AddressOf Me.TypeSelect_SelectedIndexChanged
			Dim items3 As MenuItem() = New MenuItem() { Me.File, Me.Edit, Me.[Select] }
			Me.mainMenu1.MenuItems.AddRange(items3)
			Me.File.Index = 0
			Dim items4 As MenuItem() = New MenuItem() { Me.New, Me.Open, Me.menuItem4, Me.Save, Me.SaveAs, Me.menuItem7, Me.[Exit] }
			Me.File.MenuItems.AddRange(items4)
			Me.File.Text = "&File"
			Me.New.Index = 0
			Me.New.Shortcut = Shortcut.CtrlN
			Me.New.Text = "&New"
			Me.Open.Index = 1
			Me.Open.Shortcut = Shortcut.CtrlO
			Me.Open.Text = "&Open..."
			Me.menuItem4.Index = 2
			Me.menuItem4.Text = "-"
			Me.Save.Index = 3
			Me.Save.Shortcut = Shortcut.CtrlS
			Me.Save.Text = "&Save"
			Me.SaveAs.Index = 4
			Me.SaveAs.Text = "Save &As..."
			Me.menuItem7.Index = 5
			Me.menuItem7.Text = "-"
			Me.[Exit].Index = 6
			Me.[Exit].Shortcut = Shortcut.AltF4
			Me.[Exit].Text = "E&xit"
			AddHandler Me.[Exit].Click, AddressOf Me.Exit_Click
			Me.Edit.Index = 1
			Dim items5 As MenuItem() = New MenuItem() { Me.Undo, Me.Redo }
			Me.Edit.MenuItems.AddRange(items5)
			Me.Edit.Text = "&Edit"
			Me.Undo.Index = 0
			Me.Undo.Shortcut = Shortcut.CtrlZ
			Me.Undo.Text = "&Undo"
			AddHandler Me.Undo.Click, AddressOf Me.Undo_Click
			Me.Redo.Index = 1
			Me.Redo.Shortcut = Shortcut.CtrlY
			Me.Redo.Text = "&Redo"
			AddHandler Me.Redo.Click, AddressOf Me.Redo_Click
			Me.[Select].Index = 2
			Dim items6 As MenuItem() = New MenuItem() { Me.All, Me.None, Me.Invert }
			Me.[Select].MenuItems.AddRange(items6)
			Me.[Select].Text = "&Select"
			Me.All.Index = 0
			Me.All.Shortcut = Shortcut.CtrlA
			Me.All.Text = "&All"
			AddHandler Me.All.Click, AddressOf Me.All_Click
			Me.None.Index = 1
			Me.None.Shortcut = Shortcut.CtrlShiftA
			Me.None.Text = "&None"
			AddHandler Me.None.Click, AddressOf Me.None_Click
			Me.Invert.Index = 2
			Me.Invert.Shortcut = Shortcut.CtrlI
			Me.Invert.Text = "&Invert"
			Dim clientSize As Size = New Size(632, 481)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.StatusBar)
			MyBase.Controls.Add(Me.ParameterPanel)
			MyBase.Name = "NCurveEditor"
			Me.Text = "CurveEditor"
			AddHandler MyBase.SizeChanged, AddressOf Me.NCurveEditor_SizeChanged
			AddHandler MyBase.MouseWheel, AddressOf Me.NCurveEditor_MouseWheel
			Me.ParameterPanel.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub DisposeD3DX()
			Dim colorPanelD3D As NDirect3D = Me.ColorPanelD3D
			If colorPanelD3D IsNot Nothing Then
				colorPanelD3D.DisposeD3DX()
			End If
			Dim editPanelD3D As NDirect3D = Me.EditPanelD3D
			If editPanelD3D IsNot Nothing Then
				editPanelD3D.DisposeD3DX()
			End If
		End Sub

		Public Sub Update()
			Me.RefreshComponent()
		End Sub

		Private Sub InitializeComponent2(linear_scalar_prototype As __Pointer(Of GPCurveLinearScalar), linear_color_prototype As __Pointer(Of GPCurveLinearColor), bezier_scalar_prototype As __Pointer(Of GPCurveBezierScalar), keylimit As __Pointer(Of GKeyLimit))
			Me.EditPanel = New NSolidPanel()
			Me.ColorPanel = New NSolidPanel()
			Me.EditPanel.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim window As Color = SystemColors.Window
			Me.EditPanel.BackColor = window
			Me.EditPanel.BorderStyle = BorderStyle.Fixed3D
			Me.EditPanel.ContextMenu = Me.EditPanelContextMenu
			Dim location As Point = New Point(272, 8)
			Me.EditPanel.Location = location
			Me.EditPanel.Name = "EditPanel"
			Dim size As Size = New Size(352, 408)
			Me.EditPanel.Size = size
			Me.EditPanel.TabIndex = 0
			AddHandler Me.EditPanel.Resize, AddressOf Me.EditPanel_Resize
			AddHandler Me.EditPanel.MouseUp, AddressOf Me.EditPanel_MouseUp
			AddHandler Me.EditPanel.Paint, AddressOf Me.EditPanel_Paint
			AddHandler Me.EditPanel.KeyDown, AddressOf Me.EditPanel_KeyDown
			AddHandler Me.EditPanel.MouseMove, AddressOf Me.EditPanel_MouseMove
			AddHandler Me.EditPanel.MouseLeave, AddressOf Me.EditPanel_MouseLeave
			AddHandler Me.EditPanel.MouseDown, AddressOf Me.EditPanel_MouseDown
			Me.ColorPanel.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim window2 As Color = SystemColors.Window
			Me.ColorPanel.BackColor = window2
			Me.ColorPanel.BorderStyle = BorderStyle.Fixed3D
			Dim location2 As Point = New Point(272, 424)
			Me.ColorPanel.Location = location2
			Me.ColorPanel.Name = "ColorPanel"
			Dim size2 As Size = New Size(352, 32)
			Me.ColorPanel.Size = size2
			Me.ColorPanel.TabIndex = 2
			AddHandler Me.ColorPanel.Resize, AddressOf Me.ColorPanel_Resize
			AddHandler Me.ColorPanel.Paint, AddressOf Me.ColorPanel_Paint
			AddHandler Me.ColorPanel.MouseMove, AddressOf Me.ColorPanel_MouseMove
			AddHandler Me.ColorPanel.MouseDown, AddressOf Me.ColorPanel_MouseDown
			MyBase.Controls.Add(Me.EditPanel)
			MyBase.Controls.Add(Me.ColorPanel)
			AddHandler Application.Idle, AddressOf Me.NCurveEditor_Idle
			Dim clientSize As Size = Me.TimePanel.ClientSize
			Me.TimePanel.Height = Me.TimePanel.Height + (16 - clientSize.Height)
			Me.TimeUpDown = New NFloatUpDown()
			Dim location3 As Point = New Point(0, 0)
			Me.TimeUpDown.Location = location3
			Dim size3 As Size = New Size(Me.TimePanel.ClientSize.Width, 16)
			Me.TimeUpDown.Size = size3
			Me.TimeUpDown.BorderStyle = BorderStyle.None
			Me.TimeUpDown.Increment = 0.10000000149011612
			Me.TimeUpDown.Minimum = 0.0
			If keylimit IsNot Nothing Then
				Me.TimeUpDown.Maximum = CDec((__Dereference(CType(keylimit, __Pointer(Of Single)))))
			Else
				Me.TimeUpDown.Maximum = 3.4028234663852886E+38
			End If
			AddHandler Me.TimeUpDown.Validated, AddressOf Me.TimeUpDown_Validated
			Me.TimePanel.Controls.Add(Me.TimeUpDown)
			Me.TimePanel.Enabled = False
			Dim clientSize2 As Size = Me.ValuePanel.ClientSize
			Me.ValuePanel.Height = Me.ValuePanel.Height + (16 - clientSize2.Height)
			Me.ValueUpDown = New NFloatUpDown()
			Dim location4 As Point = New Point(0, 0)
			Me.ValueUpDown.Location = location4
			Dim size4 As Size = New Size(Me.ValuePanel.ClientSize.Width, 16)
			Me.ValueUpDown.Size = size4
			Me.ValueUpDown.BorderStyle = BorderStyle.None
			Me.ValueUpDown.Increment = 0.10000000149011612
			If keylimit IsNot Nothing Then
				Me.ValueUpDown.Minimum = CDec((__Dereference(CType((keylimit + 4 / __SizeOf(GKeyLimit)), __Pointer(Of Single)))))
				Me.ValueUpDown.Maximum = CDec((__Dereference(CType((keylimit + 8 / __SizeOf(GKeyLimit)), __Pointer(Of Single)))))
			Else If linear_color_prototype IsNot Nothing Then
				Me.ValueUpDown.Minimum = 0.0
				Me.ValueUpDown.Maximum = 1.0
			Else
				Me.ValueUpDown.Minimum = -3.4028234663852886E+38
				Me.ValueUpDown.Maximum = 3.4028234663852886E+38
			End If
			AddHandler Me.ValueUpDown.Validated, AddressOf Me.ValueUpDown_Validated
			Me.ValuePanel.Controls.Add(Me.ValueUpDown)
			Me.ValuePanel.Enabled = False
			Me.ColorPicker = New ColorPicker()
			Dim location5 As Point = New Point(0, 32)
			Me.ColorPicker.Location = location5
			Me.ColorPicker.Name = "ColorPicker"
			Me.ColorPicker.TabIndex = 0
			Me.ColorPicker.Font = Me.Font
			Me.ColorPicker.Text = ""
			AddHandler Me.ColorPicker.ValueChanged, AddressOf Me.ColorPicker_ValueChanged
			Me.ParameterPanel.Controls.Add(Me.ColorPicker)
			Me.EditPanelD3D = New NDirect3D(Me.EditPanel)
			Me.ColorPanelD3D = New NDirect3D(Me.ColorPanel)
			If linear_scalar_prototype IsNot Nothing Then
				Me.LinearScalarPrototype = linear_scalar_prototype
			Else
				Dim ptr As __Pointer(Of GPCurveLinearScalar) = <Module>.new(24UI)
				Dim linearScalarPrototype As __Pointer(Of GPCurveLinearScalar)
				Try
					If ptr IsNot Nothing Then
						linearScalarPrototype = <Module>.GPCurveLinearScalar.{ctor}(ptr)
					Else
						linearScalarPrototype = 0
					End If
				Catch 
					<Module>.delete(CType(ptr, __Pointer(Of Void)))
					Throw
				End Try
				Me.LinearScalarPrototype = linearScalarPrototype
				Me.DisposeLinearScalarPrototype = True
			End If
			If keylimit IsNot Nothing Then
				Dim ptr2 As __Pointer(Of GCurveLinearScalarEditor) = <Module>.new(140UI)
				Dim linearScalarEditor As __Pointer(Of GCurveLinearScalarEditor)
				Try
					If ptr2 IsNot Nothing Then
						linearScalarEditor = <Module>.GCurveLinearScalarEditor.{ctor}(ptr2, Me.LinearScalarPrototype, keylimit)
					Else
						linearScalarEditor = 0
					End If
				Catch 
					<Module>.delete(CType(ptr2, __Pointer(Of Void)))
					Throw
				End Try
				Me.LinearScalarEditor = linearScalarEditor
			Else
				Dim ptr3 As __Pointer(Of GCurveLinearScalarEditor) = <Module>.new(140UI)
				Dim linearScalarEditor2 As __Pointer(Of GCurveLinearScalarEditor)
				Try
					If ptr3 IsNot Nothing Then
						linearScalarEditor2 = <Module>.GCurveLinearScalarEditor.{ctor}(ptr3, Me.LinearScalarPrototype)
					Else
						linearScalarEditor2 = 0
					End If
				Catch 
					<Module>.delete(CType(ptr3, __Pointer(Of Void)))
					Throw
				End Try
				Me.LinearScalarEditor = linearScalarEditor2
			End If
			If linear_color_prototype IsNot Nothing Then
				Me.LinearColorPrototype = linear_color_prototype
			Else
				Dim ptr4 As __Pointer(Of GPCurveLinearColor) = <Module>.new(24UI)
				Dim linearColorPrototype As __Pointer(Of GPCurveLinearColor)
				Try
					If ptr4 IsNot Nothing Then
						linearColorPrototype = <Module>.GPCurveLinearColor.{ctor}(ptr4)
					Else
						linearColorPrototype = 0
					End If
				Catch 
					<Module>.delete(CType(ptr4, __Pointer(Of Void)))
					Throw
				End Try
				Me.LinearColorPrototype = linearColorPrototype
				Me.DisposeLinearColorPrototype = True
			End If
			Dim ptr5 As __Pointer(Of GCurveLinearColorEditor) = <Module>.new(164UI)
			Dim linearColorEditor As __Pointer(Of GCurveLinearColorEditor)
			Try
				If ptr5 IsNot Nothing Then
					Dim linearColorPrototype2 As __Pointer(Of GPCurveLinearColor) = Me.LinearColorPrototype
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.{ctor}(ptr5, linearColorPrototype2)
					Try
						__Dereference(CType(ptr5, __Pointer(Of Integer))) = <Module>.??_7GCurveLinearColorEditor@@6B@
						__Dereference(CType((ptr5 + 144 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Single))) = 3.40282347E+38F
						__Dereference(CType((ptr5 + 152 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Single))) = 1F
						__Dereference(CType((ptr5 + 148 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Single))) = 0F
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.{dtor}), CType(ptr5, __Pointer(Of Void)))
						Throw
					End Try
					linearColorEditor = ptr5
				Else
					linearColorEditor = 0
				End If
			Catch 
				<Module>.delete(CType(ptr5, __Pointer(Of Void)))
				Throw
			End Try
			Me.LinearColorEditor = linearColorEditor
			If bezier_scalar_prototype IsNot Nothing Then
				Me.BezierScalarPrototype = bezier_scalar_prototype
			Else
				Dim ptr6 As __Pointer(Of GPCurveBezierScalar) = <Module>.new(36UI)
				Dim bezierScalarPrototype As __Pointer(Of GPCurveBezierScalar)
				Try
					If ptr6 IsNot Nothing Then
						bezierScalarPrototype = <Module>.GPCurveBezierScalar.{ctor}(ptr6)
					Else
						bezierScalarPrototype = 0
					End If
				Catch 
					<Module>.delete(CType(ptr6, __Pointer(Of Void)))
					Throw
				End Try
				Me.BezierScalarPrototype = bezierScalarPrototype
				Me.DisposeBezierScalarPrototype = True
			End If
			If keylimit IsNot Nothing Then
				Dim ptr7 As __Pointer(Of GCurveBezierScalarEditor) = <Module>.new(140UI)
				Dim bezierScalarEditor As __Pointer(Of GCurveBezierScalarEditor)
				Try
					If ptr7 IsNot Nothing Then
						Dim bezierScalarPrototype2 As __Pointer(Of GPCurveBezierScalar) = Me.BezierScalarPrototype
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.{ctor}(ptr7, bezierScalarPrototype2)
						Try
							__Dereference(CType(ptr7, __Pointer(Of Integer))) = <Module>.??_7?$GCurveScalarEditor@VGCurveBezierScalar@@VGPCurveBezierScalar@@VGPCurveScalarKey@@@@6B@
							cpblk(ptr7 + 120 / __SizeOf(GCurveBezierScalarEditor), keylimit, 12)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.{dtor}), CType(ptr7, __Pointer(Of Void)))
							Throw
						End Try
						Try
							__Dereference(CType(ptr7, __Pointer(Of Integer))) = <Module>.??_7GCurveBezierScalarEditor@@6B@
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GCurveScalarEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.{dtor}), CType(ptr7, __Pointer(Of Void)))
							Throw
						End Try
						bezierScalarEditor = ptr7
					Else
						bezierScalarEditor = 0
					End If
				Catch 
					<Module>.delete(CType(ptr7, __Pointer(Of Void)))
					Throw
				End Try
				Me.BezierScalarEditor = bezierScalarEditor
			Else
				Dim ptr8 As __Pointer(Of GCurveBezierScalarEditor) = <Module>.new(140UI)
				Dim bezierScalarEditor2 As __Pointer(Of GCurveBezierScalarEditor)
				Try
					If ptr8 IsNot Nothing Then
						bezierScalarEditor2 = <Module>.GCurveBezierScalarEditor.{ctor}(ptr8, Me.BezierScalarPrototype)
					Else
						bezierScalarEditor2 = 0
					End If
				Catch 
					<Module>.delete(CType(ptr8, __Pointer(Of Void)))
					Throw
				End Try
				Me.BezierScalarEditor = bezierScalarEditor2
			End If
			Dim ptr9 As __Pointer(Of GArray<GKeyNode>) = <Module>.new(12UI)
			Dim nodes As __Pointer(Of GArray<GKeyNode>)
			Try
				If ptr9 IsNot Nothing Then
					__Dereference(CType(ptr9, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr9 + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr9 + 8 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer))) = 0
					nodes = ptr9
				Else
					nodes = 0
				End If
			Catch 
				<Module>.delete(CType(ptr9, __Pointer(Of Void)))
				Throw
			End Try
			Me.Nodes = nodes
			Me.GetDesignerComponentParameters()
			Me.TypeSelect.SelectedIndex = Me.Type
			Me.CenterViewport()
			Me.RefreshComponent()
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						__Dereference(CType((Me.BezierScalarEditor + 136 / __SizeOf(GCurveBezierScalarEditor)), __Pointer(Of Byte))) = 0
					End If
				Else
					__Dereference(CType((Me.LinearColorEditor + 160 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Byte))) = 0
				End If
			Else
				__Dereference(CType((Me.LinearScalarEditor + 136 / __SizeOf(GCurveLinearScalarEditor)), __Pointer(Of Byte))) = 0
			End If
		End Sub

		Private Sub InvalidatePanels()
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type <> 2 Then
						Return
					End If
				Else
					Me.InvalidColorPanel = True
				End If
			End If
			Me.EditPanel.Invalidate()
		End Sub

		Private Sub ShowCursor()
			If Me.CursorHidden Then
				Cursor.Show()
				Me.CursorHidden = False
			End If
		End Sub

		Private Sub HideCursor()
			If Not Me.CursorHidden Then
				Cursor.Hide()
				Me.CursorHidden = True
			End If
		End Sub

		Private Function GetSelectedIndices() As __Pointer(Of GArray<int>)
			Dim type As Integer = Me.Type
			If type = 0 Then
				Return Me.LinearScalarEditor + 84 / __SizeOf(GCurveLinearScalarEditor)
			End If
			If type = 1 Then
				Return Me.LinearColorEditor + 108 / __SizeOf(GCurveLinearColorEditor)
			End If
			If type <> 2 Then
				Return Me.LinearScalarEditor + 84 / __SizeOf(GCurveLinearScalarEditor)
			End If
			Return Me.BezierScalarEditor + 84 / __SizeOf(GCurveBezierScalarEditor)
		End Function

		Private Function GetNumberOfSelectedIndices() As Integer
			Dim type As Integer = Me.Type
			If type = 0 Then
				Return __Dereference(CType((Me.LinearScalarEditor + 88 / __SizeOf(GCurveLinearScalarEditor)), __Pointer(Of Integer)))
			End If
			If type = 1 Then
				Return __Dereference(CType((Me.LinearColorEditor + 112 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Integer)))
			End If
			If type <> 2 Then
				Return 0
			End If
			Return __Dereference(CType((Me.BezierScalarEditor + 88 / __SizeOf(GCurveBezierScalarEditor)), __Pointer(Of Integer)))
		End Function

		Private Function GetNumberOfKeys() As Integer
			Dim type As Integer = Me.Type
			If type = 0 Then
				Return __Dereference((__Dereference(CType((Me.LinearScalarEditor + 20 / __SizeOf(GCurveLinearScalarEditor)), __Pointer(Of Integer))) + 16))
			End If
			If type = 1 Then
				Return __Dereference((__Dereference(CType((Me.LinearColorEditor + 32 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Integer))) + 16))
			End If
			If type <> 2 Then
				Return 0
			End If
			Return __Dereference((__Dereference(CType((Me.BezierScalarEditor + 20 / __SizeOf(GCurveBezierScalarEditor)), __Pointer(Of Integer))) + 16))
		End Function

		Private Function GetHorizontalKeyValue(index As Integer) As Single
			If index >= Me.GetNumberOfKeys() Then
				index = 0
			End If
			Dim type As Integer = Me.Type
			If type = 0 Then
				Return __Dereference((index * 8 + __Dereference((__Dereference(CType((Me.LinearScalarEditor + 20 / __SizeOf(GCurveLinearScalarEditor)), __Pointer(Of Integer))) + 12))))
			End If
			If type = 1 Then
				Return __Dereference((index * 20 + __Dereference((__Dereference(CType((Me.LinearColorEditor + 32 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Integer))) + 12))))
			End If
			If type <> 2 Then
				Return 0F
			End If
			Return __Dereference((index * 8 + __Dereference((__Dereference(CType((Me.BezierScalarEditor + 20 / __SizeOf(GCurveBezierScalarEditor)), __Pointer(Of Integer))) + 12))))
		End Function

		Private Function GetVerticalKeyValue(index As Integer) As Single
			If index >= Me.GetNumberOfKeys() Then
				index = 0
			End If
			Dim type As Integer = Me.Type
			If type = 0 Then
				Return __Dereference((index * 8 + __Dereference((__Dereference(CType((Me.LinearScalarEditor + 20 / __SizeOf(GCurveLinearScalarEditor)), __Pointer(Of Integer))) + 12)) + 4))
			End If
			If type = 1 Then
				Return __Dereference((index * 20 + __Dereference((__Dereference(CType((Me.LinearColorEditor + 32 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Integer))) + 12)) + 16))
			End If
			If type <> 2 Then
				Return 0F
			End If
			Return __Dereference((index * 8 + __Dereference((__Dereference(CType((Me.BezierScalarEditor + 20 / __SizeOf(GCurveBezierScalarEditor)), __Pointer(Of Integer))) + 12)) + 4))
		End Function

		Private Sub ClearSelection()
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						Dim bezierScalarEditor As __Pointer(Of GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>) = Me.BezierScalarEditor
						<Module>.GArray<int>.Clear(bezierScalarEditor + 84, 0)
						__Dereference((bezierScalarEditor + 132)) = -1
					End If
				Else
					Dim linearColorEditor As __Pointer(Of GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>) = Me.LinearColorEditor
					<Module>.GArray<int>.Clear(linearColorEditor + 108, 0)
					__Dereference((linearColorEditor + 156)) = -1
				End If
			Else
				Dim linearScalarEditor As __Pointer(Of GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>) = Me.LinearScalarEditor
				<Module>.GArray<int>.Clear(linearScalarEditor + 84, 0)
				__Dereference((linearScalarEditor + 132)) = -1
			End If
		End Sub

		Private Sub AddIndexToSelection(index As Integer)
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.AddIndexToSelection(Me.BezierScalarEditor, index)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.AddIndexToSelection(Me.LinearColorEditor, index)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.AddIndexToSelection(Me.LinearScalarEditor, index)
			End If
		End Sub

		Private Sub InvertSelection(index As Integer)
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.InvertSelection(Me.BezierScalarEditor, index)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.InvertSelection(Me.LinearColorEditor, index)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.InvertSelection(Me.LinearScalarEditor, index)
			End If
		End Sub

		Private Sub SelectToIndex(index As Integer)
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SelectToIndex(Me.BezierScalarEditor, index)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.SelectToIndex(Me.LinearColorEditor, index)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SelectToIndex(Me.LinearScalarEditor, index)
			End If
		End Sub

		Private Function GetLoopStart() As Integer
			Dim type As Integer = Me.Type
			If type = 0 Then
				Return __Dereference((__Dereference(CType((Me.LinearScalarEditor + 20 / __SizeOf(GCurveLinearScalarEditor)), __Pointer(Of Integer))) + 4))
			End If
			If type = 1 Then
				Return __Dereference((__Dereference(CType((Me.LinearColorEditor + 32 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Integer))) + 4))
			End If
			If type <> 2 Then
				Return -1
			End If
			Return __Dereference((__Dereference(CType((Me.BezierScalarEditor + 20 / __SizeOf(GCurveBezierScalarEditor)), __Pointer(Of Integer))) + 4))
		End Function

		Private Function GetLoopEnd() As Integer
			Dim type As Integer = Me.Type
			If type = 0 Then
				Return __Dereference((__Dereference(CType((Me.LinearScalarEditor + 20 / __SizeOf(GCurveLinearScalarEditor)), __Pointer(Of Integer))) + 8))
			End If
			If type = 1 Then
				Return __Dereference((__Dereference(CType((Me.LinearColorEditor + 32 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Integer))) + 8))
			End If
			If type <> 2 Then
				Return -1
			End If
			Return __Dereference((__Dereference(CType((Me.BezierScalarEditor + 20 / __SizeOf(GCurveBezierScalarEditor)), __Pointer(Of Integer))) + 8))
		End Function

		Private Sub SetLoopStart(index As Integer, <MarshalAs(UnmanagedType.U1)> modifycurrent As Boolean)
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SetLoopStart(Me.BezierScalarEditor, index, modifycurrent)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.SetLoopStart(Me.LinearColorEditor, index, modifycurrent)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SetLoopStart(Me.LinearScalarEditor, index, modifycurrent)
			End If
			Me.raise_NotifyUndoStep()
		End Sub

		Private Sub SetLoopEnd(index As Integer, <MarshalAs(UnmanagedType.U1)> modifycurrent As Boolean)
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SetLoopEnd(Me.BezierScalarEditor, index, modifycurrent)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.SetLoopEnd(Me.LinearColorEditor, index, modifycurrent)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SetLoopEnd(Me.LinearScalarEditor, index, modifycurrent)
			End If
			Me.raise_NotifyUndoStep()
		End Sub

		Private Function GetMovedIndex() As Integer
			Dim type As Integer = Me.Type
			If type = 0 Then
				Return __Dereference(CType((Me.LinearScalarEditor + 68 / __SizeOf(GCurveLinearScalarEditor)), __Pointer(Of Integer)))
			End If
			If type = 1 Then
				Return __Dereference(CType((Me.LinearColorEditor + 92 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Integer)))
			End If
			If type <> 2 Then
				Return -1
			End If
			Return __Dereference(CType((Me.BezierScalarEditor + 68 / __SizeOf(GCurveBezierScalarEditor)), __Pointer(Of Integer)))
		End Function

		Private Sub BeginMove(baseindex As Integer)
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.BeginMove(Me.BezierScalarEditor, baseindex)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.BeginMove(Me.LinearColorEditor, baseindex)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.BeginMove(Me.LinearScalarEditor, baseindex)
			End If
		End Sub

		Private Sub EndMove()
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.EndMove(Me.BezierScalarEditor)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.EndMove(Me.LinearColorEditor)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.EndMove(Me.LinearScalarEditor)
			End If
			Me.raise_NotifyUndoStep()
		End Sub

		Private Sub CancelMove()
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.CancelMove(Me.BezierScalarEditor)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.CancelMove(Me.LinearColorEditor)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.CancelMove(Me.LinearScalarEditor)
			End If
		End Sub

		Private Function IsInLimits(node As __Pointer(Of GKeyNode)) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim gPCurveScalarKey As GPCurveScalarKey = 0F
			__Dereference((gPCurveScalarKey + 4)) = 0F
			Dim gPCurveColorKey As GPCurveColorKey = 0F
			__Dereference((gPCurveColorKey + 16)) = 1F
			Dim type As Integer = Me.Type
			If type = 0 Then
				Me.ConvertNodeToScalarKey(node, gPCurveScalarKey)
				Dim linearScalarEditor As __Pointer(Of GCurveScalarEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>) = Me.LinearScalarEditor
				Dim result As Byte
				If gPCurveScalarKey >= 0F AndAlso gPCurveScalarKey <= __Dereference((linearScalarEditor + 120)) AndAlso __Dereference((gPCurveScalarKey + 4)) >= __Dereference((linearScalarEditor + 124)) AndAlso __Dereference((gPCurveScalarKey + 4)) <= __Dereference((linearScalarEditor + 128)) Then
					result = 1
				Else
					result = 0
				End If
				Return result <> 0
			End If
			If type = 1 Then
				Me.ConvertNodeToColorKey(node, gPCurveColorKey)
				Dim linearColorEditor As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
				Dim result2 As Byte
				If gPCurveColorKey >= 0F AndAlso gPCurveColorKey <= __Dereference((linearColorEditor + 144)) AndAlso __Dereference((gPCurveColorKey + 16)) >= __Dereference((linearColorEditor + 148)) AndAlso __Dereference((gPCurveColorKey + 16)) <= __Dereference((linearColorEditor + 152)) Then
					result2 = 1
				Else
					result2 = 0
				End If
				Return result2 <> 0
			End If
			If type <> 2 Then
				Return False
			End If
			Me.ConvertNodeToScalarKey(node, gPCurveScalarKey)
			Return <Module>.GCurveScalarEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.IsInLimits(Me.BezierScalarEditor, gPCurveScalarKey) IsNot Nothing
		End Function

		Private Function IsMouseOverControl(c As Control) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim position As Point = Cursor.Position
			Dim point As Point = Me.EditPanel.PointToClient(position)
			Return c.Size.Width >= point.X AndAlso c.Size.Height >= point.Y AndAlso 0 <= point.X AndAlso 0 <= point.Y
		End Function

		Private Sub GetDesignerComponentParameters()
			Dim size As Size = Me.EditPanel.Size
			Dim location As Point = Me.ColorPanel.Location
			Dim location2 As Point = Me.EditPanel.Location
			Dim num As Integer = location.Y - location2.Y
			Me.ColorPanelToEditPanel = num - size.Height
		End Sub

		Private Sub GenerateNodes()
			Dim num As Integer = -2147483648
			Dim num2 As Integer = 2147483647
			Dim num3 As Integer = -2147483648
			Dim num4 As Integer = 2147483647
			Dim num5 As Single = -3.40282347E+38F
			Dim num6 As Single = 3.40282347E+38F
			Dim num7 As Single = -3.40282347E+38F
			Dim num8 As Single = 3.40282347E+38F
			Dim size As Size = Me.EditPanel.Size
			Dim num9 As Single = CSng(size.Width)
			Dim num10 As Single = num9 / Me.IViewport.Width
			Dim num11 As Single = CSng(size.Height)
			Dim num12 As Single = num11 / Me.IViewport.Height
			Dim nodes As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
			If __Dereference(CType((nodes + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer))) <> Me.GetNumberOfKeys() Then
				<Module>.GArray<GKeyNode>.Resize(nodes, Me.GetNumberOfKeys())
			End If
			Dim num13 As Integer = 0
			If 0 < Me.GetNumberOfKeys() Then
				Do
					Dim horizontalKeyValue As Single = Me.GetHorizontalKeyValue(num13)
					Dim verticalKeyValue As Single = Me.GetVerticalKeyValue(num13)
					__Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num13 * 8)) = CInt((CDec(((horizontalKeyValue - Me.IViewport.X) * num10))))
					Dim arg_105_0 As __Pointer(Of Integer) = __Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num13 * 8
					Dim num14 As Single = Me.IViewport.Height + verticalKeyValue
					Dim num15 As Integer = CInt((CDec(((num14 - Me.IViewport.Y) * num12))))
					__Dereference((arg_105_0 + 4)) = size.Height - num15
					If horizontalKeyValue > num5 Then
						num5 = horizontalKeyValue
					End If
					If verticalKeyValue > num7 Then
						num7 = verticalKeyValue
					End If
					If horizontalKeyValue < num6 Then
						num6 = horizontalKeyValue
					End If
					If verticalKeyValue < num8 Then
						num8 = verticalKeyValue
					End If
					Dim num16 As Integer = num13 * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))
					Dim num17 As Integer = __Dereference(num16)
					If num17 > num Then
						num = num17
					End If
					Dim num18 As Integer = __Dereference((num16 + 4))
					If num18 > num3 Then
						num3 = num18
					End If
					If num17 < num2 Then
						num2 = num17
					End If
					If num18 < num4 Then
						num4 = num18
					End If
					num13 += 1
				Loop While num13 < Me.GetNumberOfKeys()
			End If
			Me.EnvelopRectangleF.X = num6
			Me.EnvelopRectangleF.Y = num8
			Me.EnvelopRectangleF.Width = num5 - num6
			Me.EnvelopRectangleF.Height = num7 - num8
			Me.EnvelopRectangle.X = num2
			Me.EnvelopRectangle.Y = num4
			Me.EnvelopRectangle.Width = num - num2
			Me.EnvelopRectangle.Height = num3 - num4
			Me.X0 = CInt((CDec((-CDec((Me.IViewport.X * num10))))))
			Dim num19 As Integer = CInt((CDec(((Me.IViewport.Height - Me.IViewport.Y) * num12))))
			Me.Y0 = size.Height - num19
			Me.X1 = CInt((CDec(((1F - Me.IViewport.X) * num10))))
			Dim num20 As Single = Me.IViewport.Height + 1F
			Dim num21 As Integer = CInt((CDec(((num20 - Me.IViewport.Y) * num12))))
			Me.Y1 = size.Height - num21
			Dim num22 As Single = Me.IViewport.Height - 1F
			Dim num23 As Integer = CInt((CDec(((num22 - Me.IViewport.Y) * num12))))
			Me.YM1 = size.Height - num23
			Me.X5 = CInt((CDec(((5F - Me.IViewport.X) * num10))))
			Dim num24 As Single = Me.IViewport.Height + 5F
			Dim num25 As Integer = CInt((CDec(((num24 - Me.IViewport.Y) * num12))))
			Me.Y5 = size.Height - num25
			Dim num26 As Single = Me.IViewport.Height - 5F
			Dim num27 As Integer = CInt((CDec(((num26 - Me.IViewport.Y) * num12))))
			Me.YM5 = size.Height - num27
			Me.X10 = CInt((CDec(((10F - Me.IViewport.X) * num10))))
			Dim num28 As Single = Me.IViewport.Height + 10F
			Dim num29 As Integer = CInt((CDec(((num28 - Me.IViewport.Y) * num12))))
			Me.Y10 = size.Height - num29
			Dim num30 As Single = Me.IViewport.Height - 10F
			Dim num31 As Integer = CInt((CDec(((num30 - Me.IViewport.Y) * num12))))
			Me.YM10 = size.Height - num31
		End Sub

		Private Sub CenterViewport()
			Dim num As Single = -3.40282347E+38F
			Dim num2 As Single = 3.40282347E+38F
			Dim num3 As Single = -3.40282347E+38F
			Dim num4 As Single = 3.40282347E+38F
			Dim num5 As Integer = 0
			Dim numberOfKeys As Integer = Me.GetNumberOfKeys()
			If 0 < numberOfKeys Then
				Do
					If Me.GetHorizontalKeyValue(num5) > num Then
						num = Me.GetHorizontalKeyValue(num5)
					End If
					If Me.GetHorizontalKeyValue(num5) < num2 Then
						num2 = Me.GetHorizontalKeyValue(num5)
					End If
					If Me.GetVerticalKeyValue(num5) > num3 Then
						num3 = Me.GetVerticalKeyValue(num5)
					End If
					If Me.GetVerticalKeyValue(num5) < num4 Then
						num4 = Me.GetVerticalKeyValue(num5)
					End If
					num5 += 1
				Loop While num5 < numberOfKeys
				If 0F <= num3 Then
					GoTo IL_89
				End If
			End If
			num3 = 0F
			IL_89:
			If 0F < num4 Then
				num4 = 0F
			End If
			If 1 = Me.Type AndAlso 1F > num3 Then
				num3 = 1F
			End If
			If num = num2 Then
				Me.IViewport.X = num2 - 0.1F
				Me.IViewport.Width = 1.2F
			Else
				Dim num6 As Single = num - num2
				Me.IViewport.X = num2 - num6 * 0.1F
				Me.IViewport.Width = num6 * 1.2F
			End If
			If num3 = num4 Then
				If 0.1F > num3 AndAlso -0.1F < num3 Then
					Me.IViewport.Y = 0.11F
					Me.IViewport.Height = 0.22F
				Else If 0F < num3 Then
					Me.IViewport.Y = num3 * 1.1F
					Me.IViewport.Height = num3 * 1.2F
				Else
					Me.IViewport.Y = num3 * -0.1F
					Me.IViewport.Height = num3 * -1.2F
				End If
			Else
				Dim num7 As Single = num3 - num4
				Me.IViewport.Y = num7 * 0.1F + num3
				Me.IViewport.Height = num7 * 1.2F
			End If
		End Sub

		Private Sub RefreshUpDownControls()
			If 0 = Me.GetNumberOfSelectedIndices() Then
				Me.TimeUpDown.Value = 0.0
				Me.ValueUpDown.Value = 0.0
				Me.TimePanel.Enabled = False
				Me.ValuePanel.Enabled = False
			Else If 1 = Me.GetNumberOfSelectedIndices() Then
				Dim selectedIndices As __Pointer(Of GArray<int>) = Me.GetSelectedIndices()
				Me.TimeUpDown.Value = CDec(Me.GetHorizontalKeyValue(__Dereference((__Dereference(selectedIndices)))))
				Dim selectedIndices2 As __Pointer(Of GArray<int>) = Me.GetSelectedIndices()
				Me.ValueUpDown.Value = CDec(Me.GetVerticalKeyValue(__Dereference((__Dereference(selectedIndices2)))))
				Me.TimePanel.Enabled = True
				Me.ValuePanel.Enabled = True
			Else
				Me.TimeUpDown.Value = 0.0
				Dim num As Double = 0.0
				Dim num2 As Integer = 0
				Dim numberOfSelectedIndices As Integer = Me.GetNumberOfSelectedIndices()
				If 0 < numberOfSelectedIndices Then
					Do
						Dim selectedIndices3 As __Pointer(Of GArray<int>) = Me.GetSelectedIndices()
						num = CDec(Me.GetVerticalKeyValue(__Dereference((num2 * 4 + __Dereference(selectedIndices3))))) + num
						num2 += 1
					Loop While num2 < numberOfSelectedIndices
				End If
				Me.ValueUpDown.Value = num / CDec(Me.GetNumberOfSelectedIndices())
				Me.TimePanel.Enabled = False
				Me.ValuePanel.Enabled = True
			End If
		End Sub

		Private Sub RefreshComponent()
			Dim point As Point = Nothing
			Dim size As Size = Nothing
			Dim point2 As Point = Nothing
			Dim point3 As Point = Nothing
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type = 1 Then
					point3 = Me.ColorPanel.Location
					point2 = Me.EditPanel.Location
					size = Me.EditPanel.Size
					size.Height = point3.Y - point2.Y - Me.ColorPanelToEditPanel
					Me.EditPanel.Size = size
					Me.ColorPanel.Visible = True
					Me.ColorPicker.Visible = True
					GoTo IL_108
				End If
				If type <> 2 Then
					GoTo IL_108
				End If
			End If
			point3 = Me.ColorPanel.Location
			point2 = Me.EditPanel.Location
			size = Me.ColorPanel.Size
			Dim num As Integer = size.Height - point2.Y
			size.Height = point3.Y + num
			Me.EditPanel.Size = size
			Me.ColorPanel.Visible = False
			Me.ColorPicker.Visible = False
			IL_108:
			Me.RefreshUpDownControls()
			Me.GenerateNodes()
			Me.InvalidatePanels()
		End Sub

		Private Sub DrawMarkers(D3D As NDirect3D)
			Dim gArray<int> As GArray<int> = 0
			__Dereference((gArray<int> + 4)) = 0
			__Dereference((gArray<int> + 8)) = 0
			Try
				Dim arg_1B_0 As Size = Me.EditPanel.Size
				Dim num As Integer = 0
				Dim nodes As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
				Dim num2 As Integer = __Dereference((nodes + 4))
				If 0 < num2 Then
					Do
						If num = Me.HighlightNodeIndex Then
							Dim controlDark As Color = SystemColors.ControlDark
							Dim nodes2 As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
							Dim arg_55_0 As __Pointer(Of Integer) = __Dereference(CType(nodes2, __Pointer(Of Integer)))
							Dim num3 As Integer = num * 8
							Dim ptr As __Pointer(Of GKeyNode) = __Dereference(arg_55_0) + num3
							Dim ptr2 As __Pointer(Of GArray<GKeyNode>) = nodes2
							D3D.FillRectangle(controlDark, __Dereference((num3 + __Dereference(ptr2))) - 2, __Dereference((ptr + 4)) - 2, 5, 5)
							Dim controlDarkDark As Color = SystemColors.ControlDarkDark
							Dim nodes3 As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
							Dim ptr3 As __Pointer(Of GArray<GKeyNode>) = nodes3
							Dim ptr4 As __Pointer(Of GKeyNode) = num3 + __Dereference(ptr3)
							Dim ptr5 As __Pointer(Of GArray<GKeyNode>) = nodes3
							D3D.DrawRectangle(controlDarkDark, __Dereference((__Dereference(ptr5) + num3)) - 3, __Dereference((ptr4 + 4)) - 3, 6, 6)
						Else
							Dim selectedIndices As __Pointer(Of GArray<int>) = Me.GetSelectedIndices()
							<Module>.GArray<int>.Resize(gArray<int>, __Dereference((selectedIndices + 4)))
							Dim num4 As Integer = 0
							If 0 < __Dereference((gArray<int> + 4)) Then
								Do
									__Dereference((num4 * 4 + gArray<int>)) = __Dereference((__Dereference(selectedIndices) + num4 * 4))
									num4 += 1
								Loop While num4 < __Dereference((gArray<int> + 4))
							End If
							Dim num5 As Integer = 0
							If 0 < __Dereference((gArray<int> + 4)) Then
								Do
									If num = __Dereference((num5 * 4 + gArray<int>)) Then
										Dim activeCaption As Color = SystemColors.ActiveCaption
										Dim nodes4 As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
										Dim ptr6 As __Pointer(Of GArray<GKeyNode>) = nodes4
										Dim ptr7 As __Pointer(Of GKeyNode) = num * 8 + __Dereference(ptr6)
										Dim ptr8 As __Pointer(Of GArray<GKeyNode>) = nodes4
										D3D.FillRectangle(activeCaption, __Dereference((num * 8 + __Dereference(ptr8))) - 2, __Dereference((ptr7 + 4)) - 2, 5, 5)
									End If
									num5 += 1
								Loop While num5 < __Dereference((gArray<int> + 4))
							End If
							Dim controlDarkDark2 As Color = SystemColors.ControlDarkDark
							Dim nodes3 As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
							Dim arg_15E_0 As __Pointer(Of Integer) = __Dereference(CType(nodes3, __Pointer(Of Integer)))
							Dim num3 As Integer = num * 8
							Dim ptr9 As __Pointer(Of GKeyNode) = __Dereference(arg_15E_0) + num3
							Dim ptr10 As __Pointer(Of GArray<GKeyNode>) = nodes3
							D3D.DrawRectangle(controlDarkDark2, __Dereference((__Dereference(ptr10) + num3)) - 3, __Dereference((ptr9 + 4)) - 3, 6, 6)
						End If
						num += 1
						nodes = Me.Nodes
						num2 = __Dereference((nodes + 4))
					Loop While num < num2
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
				Throw
			End Try
			If gArray<int> IsNot Nothing Then
				<Module>.free(gArray<int>)
			End If
		End Sub

		Private Sub DrawMarkers(graphics As Graphics)
			Dim gArray<int> As GArray<int> = 0
			__Dereference((gArray<int> + 4)) = 0
			__Dereference((gArray<int> + 8)) = 0
			Try
				Dim num As Integer = 0
				Dim nodes As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
				Dim ptr As __Pointer(Of GArray<GKeyNode>) = nodes
				Dim num2 As Integer = __Dereference((ptr + 4))
				If 0 < num2 Then
					Do
						If num = Me.HighlightNodeIndex Then
							Dim ptr2 As __Pointer(Of GArray<GKeyNode>) = nodes
							Dim num3 As Integer = num * 8
							Dim ptr3 As __Pointer(Of GKeyNode) = num3 + __Dereference(ptr2)
							Dim ptr4 As __Pointer(Of GKeyNode) = __Dereference(CType(nodes, __Pointer(Of Integer))) + num3
							graphics.FillRectangle(SystemBrushes.ControlDark, __Dereference(ptr4) - 2, __Dereference((ptr3 + 4)) - 2, 5, 5)
							Dim nodes2 As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
							Dim ptr5 As __Pointer(Of GKeyNode) = __Dereference(CType(nodes2, __Pointer(Of Integer))) + num3
							Dim ptr6 As __Pointer(Of GKeyNode) = __Dereference(CType(nodes2, __Pointer(Of Integer))) + num3
							graphics.DrawRectangle(SystemPens.ControlDarkDark, __Dereference(ptr6) - 3, __Dereference((ptr5 + 4)) - 3, 6, 6)
						Else
							Dim selectedIndices As __Pointer(Of GArray<int>) = Me.GetSelectedIndices()
							<Module>.GArray<int>.Resize(gArray<int>, __Dereference((selectedIndices + 4)))
							Dim num4 As Integer = 0
							If 0 < __Dereference((gArray<int> + 4)) Then
								Do
									__Dereference((num4 * 4 + gArray<int>)) = __Dereference((num4 * 4 + __Dereference(selectedIndices)))
									num4 += 1
								Loop While num4 < __Dereference((gArray<int> + 4))
							End If
							Dim num5 As Integer = 0
							If 0 < __Dereference((gArray<int> + 4)) Then
								Do
									If num = __Dereference((num5 * 4 + gArray<int>)) Then
										nodes = Me.Nodes
										Dim ptr7 As __Pointer(Of GKeyNode) = __Dereference(CType(nodes, __Pointer(Of Integer))) + num * 8
										Dim ptr8 As __Pointer(Of GKeyNode) = __Dereference(CType(nodes, __Pointer(Of Integer))) + num * 8
										graphics.FillRectangle(SystemBrushes.ActiveCaption, __Dereference(ptr8) - 2, __Dereference((ptr7 + 4)) - 2, 5, 5)
									End If
									num5 += 1
								Loop While num5 < __Dereference((gArray<int> + 4))
							End If
							Dim nodes2 As __Pointer(Of GArray<GKeyNode>) = Me.Nodes
							Dim ptr9 As __Pointer(Of GArray<GKeyNode>) = nodes2
							Dim num3 As Integer = num * 8
							Dim ptr10 As __Pointer(Of GKeyNode) = num3 + __Dereference(ptr9)
							Dim ptr11 As __Pointer(Of GArray<GKeyNode>) = nodes2
							Dim ptr12 As __Pointer(Of GKeyNode) = num3 + __Dereference(ptr11)
							graphics.DrawRectangle(SystemPens.ControlDarkDark, __Dereference(ptr12) - 3, __Dereference((ptr10 + 4)) - 3, 6, 6)
						End If
						num += 1
						nodes = Me.Nodes
						ptr = nodes
						num2 = __Dereference((ptr + 4))
					Loop While num < num2
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
				Throw
			End Try
			If gArray<int> IsNot Nothing Then
				<Module>.free(gArray<int>)
			End If
		End Sub

		Private Sub ConvertNodeToScalarKey(node As __Pointer(Of GKeyNode), key As __Pointer(Of GPCurveScalarKey))
			Dim size As Size = Me.EditPanel.Size
			Dim num As Single = Me.IViewport.Width * CSng((__Dereference(node)))
			Dim num2 As Single = num / CSng(size.Width)
			__Dereference(key) = Me.IViewport.X + num2
			Dim num3 As Single = Me.IViewport.Height * CSng((size.Height - __Dereference((node + 4))))
			Dim num4 As Single = num3 / CSng(size.Height)
			Dim num5 As Single = Me.IViewport.Y + num4
			Dim num6 As Single = num5 - Me.IViewport.Height
			__Dereference((key + 4)) = num6
		End Sub

		Private Sub ConvertNodeToColorKey(node As __Pointer(Of GKeyNode), key As __Pointer(Of GPCurveColorKey))
			Dim gColor As GColor
			__Dereference((gColor + 8)) = 0F
			__Dereference((gColor + 4)) = 0F
			gColor = 0F
			__Dereference((gColor + 12)) = 1F
			Dim size As Size = Me.EditPanel.Size
			Dim num As Single = Me.IViewport.Width * CSng((__Dereference(node)))
			Dim num2 As Single = num / CSng(size.Width)
			__Dereference(key) = Me.IViewport.X + num2
			Dim colorPicker As ColorPicker = Me.ColorPicker
			<Module>.GColor.FromHSV(gColor, colorPicker.Hue, colorPicker.Sat, colorPicker.Val)
			Dim num3 As Single = Me.IViewport.Height * CSng((size.Height - __Dereference((node + 4))))
			Dim num4 As Single = num3 / CSng(size.Height)
			Dim num5 As Single = Me.IViewport.Y + num4
			__Dereference((gColor + 12)) = num5 - Me.IViewport.Height
			cpblk(key + 4, gColor, 16)
		End Sub

		Private Sub AddNode(node As __Pointer(Of GKeyNode))
			Dim gPCurveScalarKey As GPCurveScalarKey = 0F
			__Dereference((gPCurveScalarKey + 4)) = 0F
			Dim gPCurveColorKey As GPCurveColorKey = 0F
			__Dereference((gPCurveColorKey + 12)) = 0F
			__Dereference((gPCurveColorKey + 8)) = 0F
			__Dereference((gPCurveColorKey + 4)) = 0F
			__Dereference((gPCurveColorKey + 16)) = 1F
			If Me.IsInLimits(node) Then
				Dim type As Integer = Me.Type
				Dim num As Integer
				If type <> 0 Then
					If type <> 1 Then
						If type <> 2 Then
							Return
						End If
						Me.ConvertNodeToScalarKey(node, gPCurveScalarKey)
						num = <Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Insert(Me.BezierScalarEditor, gPCurveScalarKey)
					Else
						Me.ConvertNodeToColorKey(node, gPCurveColorKey)
						num = <Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Insert(Me.LinearColorEditor, gPCurveColorKey)
					End If
				Else
					Me.ConvertNodeToScalarKey(node, gPCurveScalarKey)
					num = <Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Insert(Me.LinearScalarEditor, gPCurveScalarKey)
				End If
				If -1 <> num Then
					Me.RefreshComponent()
					Me.raise_NotifyUndoStep()
				End If
			End If
		End Sub

		Private Sub RemoveNodes(index As Integer, <MarshalAs(UnmanagedType.U1)> removeselection As Boolean)
			Dim type As Integer = Me.Type
			Dim flag As Boolean
			If type <> 0 Then
				If type <> 1 Then
					If type <> 2 Then
						Return
					End If
					flag = (<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Remove(Me.BezierScalarEditor, index, removeselection) IsNot Nothing)
				Else
					flag = (<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Remove(Me.LinearColorEditor, index, removeselection) IsNot Nothing)
				End If
			Else
				flag = (<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Remove(Me.LinearScalarEditor, index, removeselection) IsNot Nothing)
			End If
			If flag Then
				Me.HighlightNodeIndex = -1
				Me.RefreshComponent()
				Me.raise_NotifyUndoStep()
			End If
		End Sub

		Private Sub TimeUpDown_Validated(sender As Object, e As EventArgs)
			Dim time As Single = CSng(Me.TimeUpDown.Value)
			Dim flag As Boolean = False
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						flag = (<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SetTime(Me.BezierScalarEditor, time) IsNot Nothing)
					End If
				Else
					flag = (<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.SetTime(Me.LinearColorEditor, time) IsNot Nothing)
				End If
			Else
				flag = (<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SetTime(Me.LinearScalarEditor, time) IsNot Nothing)
			End If
			Me.RefreshComponent()
			If flag Then
				Me.raise_NotifyUndoStep()
			End If
		End Sub

		Private Sub ValueUpDown_Validated(sender As Object, e As EventArgs)
			Dim num As Single = CSng(Me.ValueUpDown.Value)
			Dim flag As Boolean = False
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						flag = (<Module>.GCurveScalarEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.SetValue(Me.BezierScalarEditor, num) IsNot Nothing)
					End If
				Else
					flag = (<Module>.GCurveLinearColorEditor.SetAlpha(Me.LinearColorEditor, num) IsNot Nothing)
				End If
			Else
				flag = (<Module>.GCurveScalarEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.SetValue(Me.LinearScalarEditor, num) IsNot Nothing)
			End If
			Me.RefreshComponent()
			If flag Then
				Me.raise_NotifyUndoStep()
			End If
		End Sub

		Private Sub NCurveEditor_SizeChanged(sender As Object, e As EventArgs)
			Me.RefreshComponent()
		End Sub

		Private Sub EditPanel_KeyDown(sender As Object, e As KeyEventArgs)
			Dim point As Point = Nothing
			Select Case e.KeyCode
				Case Keys.Space, Keys.Insert
					Dim position As Point = Cursor.Position
					point = Me.EditPanel.PointToClient(position)
					Dim x As GKeyNode = point.X
					__Dereference((x + 4)) = point.Y
					If Me.IsMouseOverControl(Me.EditPanel) Then
						Me.AddNode(x)
					End If
				Case Keys.Home
					Me.CenterViewport()
					Me.RefreshComponent()
				Case Keys.Delete
					Me.RemoveNodes(Me.HighlightNodeIndex, True)
			End Select
		End Sub

		Private Sub NCurveEditor_MouseWheel(sender As Object, e As MouseEventArgs)
			Dim delta As Integer = e.Delta
			Dim flag As Boolean = False
			Dim flag2 As Boolean = False
			If(<Module>.GetKeyState(37) And 128) <> 128S AndAlso (<Module>.GetKeyState(39) And 128) <> 128S AndAlso (<Module>.GetKeyState(16) And 128) <> 128S Then
				If(<Module>.GetKeyState(38) And 128) = 128S OrElse (<Module>.GetKeyState(40) And 128) = 128S OrElse (<Module>.GetKeyState(17) And 128) = 128S Then
					flag2 = True
				Else
					flag = True
					flag2 = True
				End If
			Else
				flag = True
			End If
			Dim num As Single = CSng(Math.Pow(0.89999997615814209, CDec((CSng(delta) * 0.008333334F))))
			If flag Then
				Dim width As Single = Me.IViewport.Width
				Dim num2 As Single = width * num
				Me.IViewport.Width = num2
				Me.IViewport.X = Me.IViewport.X - (num2 - width) * 0.5F
			End If
			If flag2 Then
				Dim height As Single = Me.IViewport.Height
				Dim num3 As Single = height * num
				Me.IViewport.Height = num3
				Me.IViewport.Y = Me.IViewport.Y + (num3 - height) * 0.5F
			End If
			Me.RefreshComponent()
		End Sub

		Private Sub EditPanel_Paint(sender As Object, e As PaintEventArgs)
			Dim size As Size = Me.EditPanel.Size
			If Nothing IsNot Me.EditPanelD3D Then
				Dim control As Color = SystemColors.Control
				Me.EditPanelD3D.Clear(control)
				Me.EditPanelD3D.BeginScene()
				Dim type As Integer = Me.Type
				Dim x As Integer
				Dim x2 As Integer
				If type <> 0 Then
					If type = 1 Then
						Dim window As Color = SystemColors.Window
						Me.EditPanelD3D.FillRectangle(window, Me.EnvelopRectangle)
						If -1 <> Me.GetLoopStart() AndAlso -1 <> Me.GetLoopEnd() AndAlso Me.GetLoopStart() <= Me.GetLoopEnd() Then
							Dim lightBlue As Color = Color.LightBlue
							Dim ptr As __Pointer(Of GKeyNode) = Me.GetLoopEnd() * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))
							Dim ptr2 As __Pointer(Of GKeyNode) = Me.GetLoopStart() * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))
							Dim ptr3 As __Pointer(Of GKeyNode) = Me.GetLoopStart() * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))
							Me.EditPanelD3D.FillRectangle(lightBlue, __Dereference(ptr3), Me.EnvelopRectangle.Top, __Dereference(ptr) - __Dereference(ptr2) + 1, Me.EnvelopRectangle.Height)
						End If
						Dim controlDarkDark As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.DrawLine(controlDarkDark, 0, Me.Y0, Me.EditPanel.Width, Me.Y0)
						Dim controlDarkDark2 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.DrawLine(controlDarkDark2, 0, Me.Y1, Me.EditPanel.Width, Me.Y1)
						Dim controlDarkDark3 As Color = SystemColors.ControlDarkDark
						x = Me.X0
						Me.EditPanelD3D.DrawLine(controlDarkDark3, x, 0, x, Me.EditPanel.Height)
						Dim controlDarkDark4 As Color = SystemColors.ControlDarkDark
						x2 = Me.X1
						Me.EditPanelD3D.DrawLine(controlDarkDark4, x2, 0, x2, Me.EditPanel.Height)
						Dim controlDarkDark5 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.DrawLine(controlDarkDark5, 0, Me.EnvelopRectangle.Top, Me.EditPanel.Width, Me.EnvelopRectangle.Top)
						Dim controlDarkDark6 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.DrawLine(controlDarkDark6, 0, Me.EnvelopRectangle.Bottom, Me.EditPanel.Width, Me.EnvelopRectangle.Bottom)
						Dim controlDarkDark7 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.DrawLine(controlDarkDark7, Me.EnvelopRectangle.Left, 0, Me.EnvelopRectangle.Left, Me.EditPanel.Height)
						Dim controlDarkDark8 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.DrawLine(controlDarkDark8, Me.EnvelopRectangle.Right, 0, Me.EnvelopRectangle.Right, Me.EditPanel.Height)
						Dim controlDarkDark9 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.TextOutA("0.0", 3, Me.Y0 - 12, controlDarkDark9)
						Dim controlDarkDark10 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.TextOutA("1.0", 3, Me.Y1 - 12, controlDarkDark10)
						Dim controlDarkDark11 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.TextOutA("0.0", Me.X0 + 3, 3, controlDarkDark11)
						Dim controlDarkDark12 As Color = SystemColors.ControlDarkDark
						Me.EditPanelD3D.TextOutA("1.0", Me.X1 + 3, 3, controlDarkDark12)
						Dim controlDarkDark13 As Color = SystemColors.ControlDarkDark
						Dim bottom As Single = Me.EnvelopRectangleF.Bottom
						Me.EditPanelD3D.TextOutA(bottom.ToString(), 3, Me.EnvelopRectangle.Top - 12, controlDarkDark13)
						Dim controlDarkDark14 As Color = SystemColors.ControlDarkDark
						Dim top As Single = Me.EnvelopRectangleF.Top
						Me.EditPanelD3D.TextOutA(top.ToString(), 3, Me.EnvelopRectangle.Bottom - 12, controlDarkDark14)
						Dim controlDarkDark15 As Color = SystemColors.ControlDarkDark
						Dim left As Single = Me.EnvelopRectangleF.Left
						Me.EditPanelD3D.TextOutA(left.ToString(), Me.EnvelopRectangle.Left + 3, 3, controlDarkDark15)
						Dim controlDarkDark16 As Color = SystemColors.ControlDarkDark
						Dim right As Single = Me.EnvelopRectangleF.Right
						Me.EditPanelD3D.TextOutA(right.ToString(), Me.EnvelopRectangle.Right + 3, 3, controlDarkDark16)
						Dim num As Single = Me.IViewport.Width / CSng(size.Width)
						Dim num2 As Single = Me.IViewport.X
						<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Restart(Me.LinearColorEditor, num2)
						Dim expr_42A As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_42A, __Dereference((__Dereference(CType(expr_42A, __Pointer(Of Integer))) + 4)))
						Dim linearColorEditor As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
						Dim expr_43E As __Pointer(Of GCurveLinearColorEditor) = linearColorEditor
						Dim num3 As Single = __Dereference((calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_43E, __Dereference((__Dereference(CType(expr_43E, __Pointer(Of Integer))) + 20))) + 12))
						Dim num4 As Single = CSng(size.Height)
						Dim num5 As Single = num4 / Me.IViewport.Height
						Dim num6 As Integer = 0
						If 0 < size.Width Then
							Do
								Dim num7 As Single = num2 + num
								linearColorEditor = Me.LinearColorEditor
								Dim num8 As Single = __Dereference((calli(GColor* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, num, __Dereference((__Dereference(CType(linearColorEditor, __Pointer(Of Integer))) + 8))) + 12))
								Dim num9 As Integer = CInt((CDec(((num3 - (Me.IViewport.Y - Me.IViewport.Height)) * num5))))
								Dim y As Integer = size.Height - num9
								Dim num10 As Integer = CInt((CDec(((num8 - (Me.IViewport.Y - Me.IViewport.Height)) * num5))))
								Dim y2 As Integer = size.Height - num10
								Dim controlDarkDark17 As Color = SystemColors.ControlDarkDark
								Dim num11 As Integer = num6 + 1
								Me.EditPanelD3D.DrawLine(controlDarkDark17, num6, y, num11, y2)
								num2 = num7
								num3 = num8
								num6 = num11
							Loop While num6 < size.Width
						End If
						Me.DrawMarkers(Me.EditPanelD3D)
						GoTo IL_D6C
					End If
					If type <> 2 Then
						GoTo IL_D6C
					End If
				End If
				Dim window2 As Color = SystemColors.Window
				Me.EditPanelD3D.FillRectangle(window2, Me.EnvelopRectangle)
				If -1 <> Me.GetLoopStart() AndAlso -1 <> Me.GetLoopEnd() AndAlso Me.GetLoopStart() <= Me.GetLoopEnd() Then
					Dim lightBlue2 As Color = Color.LightBlue
					Dim ptr4 As __Pointer(Of GKeyNode) = Me.GetLoopEnd() * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))
					Dim ptr5 As __Pointer(Of GKeyNode) = Me.GetLoopStart() * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))
					Dim ptr6 As __Pointer(Of GKeyNode) = Me.GetLoopStart() * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))
					Me.EditPanelD3D.FillRectangle(lightBlue2, __Dereference(ptr6), Me.EnvelopRectangle.Top, __Dereference(ptr4) - __Dereference(ptr5) + 1, Me.EnvelopRectangle.Height)
				End If
				Dim controlDarkDark18 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark18, 0, Me.Y0, Me.EditPanel.Width, Me.Y0)
				Dim controlDarkDark19 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark19, 0, Me.Y1, Me.EditPanel.Width, Me.Y1)
				Dim controlDarkDark20 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark20, 0, Me.YM1, Me.EditPanel.Width, Me.YM1)
				Dim controlDarkDark21 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark21, 0, Me.Y5, Me.EditPanel.Width, Me.Y5)
				Dim controlDarkDark22 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark22, 0, Me.YM5, Me.EditPanel.Width, Me.YM5)
				Dim controlDarkDark23 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark23, 0, Me.Y10, Me.EditPanel.Width, Me.Y10)
				Dim controlDarkDark24 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark24, 0, Me.YM10, Me.EditPanel.Width, Me.YM10)
				Dim controlDarkDark25 As Color = SystemColors.ControlDarkDark
				x = Me.X0
				Me.EditPanelD3D.DrawLine(controlDarkDark25, x, 0, x, Me.EditPanel.Height)
				Dim controlDarkDark26 As Color = SystemColors.ControlDarkDark
				x2 = Me.X1
				Me.EditPanelD3D.DrawLine(controlDarkDark26, x2, 0, x2, Me.EditPanel.Height)
				Dim controlDarkDark27 As Color = SystemColors.ControlDarkDark
				Dim x3 As Integer = Me.X5
				Me.EditPanelD3D.DrawLine(controlDarkDark27, x3, 0, x3, Me.EditPanel.Height)
				Dim controlDarkDark28 As Color = SystemColors.ControlDarkDark
				Dim x4 As Integer = Me.X10
				Me.EditPanelD3D.DrawLine(controlDarkDark28, x4, 0, x4, Me.EditPanel.Height)
				Dim controlDarkDark29 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark29, 0, Me.EnvelopRectangle.Top, Me.EditPanel.Width, Me.EnvelopRectangle.Top)
				Dim controlDarkDark30 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark30, 0, Me.EnvelopRectangle.Bottom, Me.EditPanel.Width, Me.EnvelopRectangle.Bottom)
				Dim controlDarkDark31 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark31, Me.EnvelopRectangle.Left, 0, Me.EnvelopRectangle.Left, Me.EditPanel.Height)
				Dim controlDarkDark32 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.DrawLine(controlDarkDark32, Me.EnvelopRectangle.Right, 0, Me.EnvelopRectangle.Right, Me.EditPanel.Height)
				Dim controlDarkDark33 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("0.0", 3, Me.Y0 - 12, controlDarkDark33)
				Dim controlDarkDark34 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("1.0", 3, Me.Y1 - 12, controlDarkDark34)
				Dim controlDarkDark35 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("-1.0", 3, Me.YM1 - 12, controlDarkDark35)
				Dim controlDarkDark36 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("5.0", 3, Me.Y5 - 12, controlDarkDark36)
				Dim controlDarkDark37 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("-5.0", 3, Me.YM5 - 12, controlDarkDark37)
				Dim controlDarkDark38 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("10.0", 3, Me.Y10 - 12, controlDarkDark38)
				Dim controlDarkDark39 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("-10.0", 3, Me.YM10 - 12, controlDarkDark39)
				Dim controlDarkDark40 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("0.0", Me.X0 + 3, 3, controlDarkDark40)
				Dim controlDarkDark41 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("1.0", Me.X1 + 3, 3, controlDarkDark41)
				Dim controlDarkDark42 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("5.0", Me.X5 + 3, 3, controlDarkDark42)
				Dim controlDarkDark43 As Color = SystemColors.ControlDarkDark
				Me.EditPanelD3D.TextOutA("10.0", Me.X10 + 3, 3, controlDarkDark43)
				Dim controlDarkDark44 As Color = SystemColors.ControlDarkDark
				Dim bottom2 As Single = Me.EnvelopRectangleF.Bottom
				Me.EditPanelD3D.TextOutA(bottom2.ToString(), 3, Me.EnvelopRectangle.Top - 12, controlDarkDark44)
				Dim controlDarkDark45 As Color = SystemColors.ControlDarkDark
				Dim top2 As Single = Me.EnvelopRectangleF.Top
				Me.EditPanelD3D.TextOutA(top2.ToString(), 3, Me.EnvelopRectangle.Bottom - 12, controlDarkDark45)
				Dim controlDarkDark46 As Color = SystemColors.ControlDarkDark
				Dim left2 As Single = Me.EnvelopRectangleF.Left
				Me.EditPanelD3D.TextOutA(left2.ToString(), Me.EnvelopRectangle.Left + 3, 3, controlDarkDark46)
				Dim controlDarkDark47 As Color = SystemColors.ControlDarkDark
				Dim right2 As Single = Me.EnvelopRectangleF.Right
				Me.EditPanelD3D.TextOutA(right2.ToString(), Me.EnvelopRectangle.Right + 3, 3, controlDarkDark47)
				If 0 = Me.Type Then
					Dim num As Single = Me.IViewport.Width / CSng(size.Width)
					Dim num2 As Single = Me.IViewport.X
					<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Restart(Me.LinearScalarEditor, num2)
					Dim expr_B3B As __Pointer(Of GCurveLinearScalarEditor) = Me.LinearScalarEditor
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_B3B, __Dereference((__Dereference(CType(expr_B3B, __Pointer(Of Integer))) + 4)))
					Dim linearScalarEditor As __Pointer(Of GCurveLinearScalarEditor) = Me.LinearScalarEditor
					Dim expr_B4F As __Pointer(Of GCurveLinearScalarEditor) = linearScalarEditor
					Dim num3 As Single = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_B4F, __Dereference((__Dereference(CType(expr_B4F, __Pointer(Of Integer))) + 24)))
					Dim num12 As Single = CSng(size.Height)
					Dim num5 As Single = num12 / Me.IViewport.Height
					Dim num6 As Integer = 0
					If 0 < size.Width Then
						Do
							Dim num7 As Single = num2 + num
							linearScalarEditor = Me.LinearScalarEditor
							Dim num8 As Single = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearScalarEditor, num, __Dereference((__Dereference(CType(linearScalarEditor, __Pointer(Of Integer))) + 8)))
							Dim num13 As Integer = CInt((CDec(((num3 - (Me.IViewport.Y - Me.IViewport.Height)) * num5))))
							Dim y3 As Integer = size.Height - num13
							Dim num14 As Integer = CInt((CDec(((num8 - (Me.IViewport.Y - Me.IViewport.Height)) * num5))))
							Dim y4 As Integer = size.Height - num14
							Dim controlDarkDark48 As Color = SystemColors.ControlDarkDark
							Dim num15 As Integer = num6 + 1
							Me.EditPanelD3D.DrawLine(controlDarkDark48, num6, y3, num15, y4)
							num2 = num7
							num3 = num8
							num6 = num15
						Loop While num6 < size.Width
					End If
				Else
					Dim num As Single = Me.IViewport.Width / CSng(size.Width)
					Dim num2 As Single = Me.IViewport.X
					<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Restart(Me.BezierScalarEditor, num2)
					Dim bezierScalarEditor As __Pointer(Of GCurveBezierScalarEditor) = Me.BezierScalarEditor
					Dim expr_C6C As __Pointer(Of GCurveBezierScalarEditor) = bezierScalarEditor
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_C6C, __Dereference((__Dereference(CType(expr_C6C, __Pointer(Of Integer))) + 4)))
					bezierScalarEditor = Me.BezierScalarEditor
					Dim expr_C80 As __Pointer(Of GCurveBezierScalarEditor) = bezierScalarEditor
					Dim num3 As Single = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_C80, __Dereference((__Dereference(CType(expr_C80, __Pointer(Of Integer))) + 24)))
					Dim num16 As Single = CSng(size.Height)
					Dim num5 As Single = num16 / Me.IViewport.Height
					Dim num6 As Integer = 0
					If 0 < size.Width Then
						Do
							Dim num7 As Single = num2 + num
							bezierScalarEditor = Me.BezierScalarEditor
							Dim num8 As Single = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), bezierScalarEditor, num, __Dereference((__Dereference(CType(bezierScalarEditor, __Pointer(Of Integer))) + 8)))
							Dim num17 As Integer = CInt((CDec(((num3 - (Me.IViewport.Y - Me.IViewport.Height)) * num5))))
							Dim y5 As Integer = size.Height - num17
							Dim num18 As Integer = CInt((CDec(((num8 - (Me.IViewport.Y - Me.IViewport.Height)) * num5))))
							Dim y6 As Integer = size.Height - num18
							Dim controlDarkDark49 As Color = SystemColors.ControlDarkDark
							Dim num19 As Integer = num6 + 1
							Me.EditPanelD3D.DrawLine(controlDarkDark49, num6, y5, num19, y6)
							num2 = num7
							num3 = num8
							num6 = num19
						Loop While num6 < size.Width
					End If
				End If
				Me.DrawMarkers(Me.EditPanelD3D)
				IL_D6C:
				If 14 = Me.DragMode Then
					Dim controlDarkDark50 As Color = SystemColors.ControlDarkDark
					Me.EditPanelD3D.DrawRectangle(controlDarkDark50, Me.SelectionRectangle)
				End If
				Me.EditPanelD3D.EndScene()
				Me.EditPanelD3D.Present()
			End If
		End Sub

		Private Sub ColorPanel_Paint(sender As Object, e As PaintEventArgs)
			Dim size As Size = Me.ColorPanel.Size
			Dim colorPanelD3D As NDirect3D = Me.ColorPanelD3D
			If Nothing IsNot colorPanelD3D Then
				colorPanelD3D.BeginScene()
				If Me.Type = 1 Then
					Dim num As Single = Me.IViewport.Width / CSng(size.Width)
					Dim x As Single = Me.IViewport.X
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Restart(Me.LinearColorEditor, x)
					Dim expr_63 As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_63, __Dereference((__Dereference(CType(expr_63, __Pointer(Of Integer))) + 4)))
					Dim linearColorEditor As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
					Dim expr_75 As __Pointer(Of GCurveLinearColorEditor) = linearColorEditor
					Dim num2 As Integer = calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_75, __Dereference((__Dereference(CType(expr_75, __Pointer(Of Integer))) + 20)))
					Dim gColor As GColor
					cpblk(gColor, num2, 16)
					Dim num3 As Integer = 0
					If 0 < size.Width Then
						Do
							Me.ColorPanelD3D.DrawLine(<Module>.GColor..K(gColor), num3, 0, num3, 32)
							linearColorEditor = Me.LinearColorEditor
							Dim num4 As Integer = calli(GColor* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, num, __Dereference((__Dereference(CType(linearColorEditor, __Pointer(Of Integer))) + 8)))
							cpblk(gColor, num4, 16)
							num3 += 1
						Loop While num3 < size.Width
					End If
				End If
				Me.ColorPanelD3D.EndScene()
				Me.ColorPanelD3D.Present()
			End If
		End Sub

		Private Sub TypeSelect_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim selectedIndex As Integer = Me.TypeSelect.SelectedIndex
			If selectedIndex <> 0 Then
				If selectedIndex <> 1 Then
					If selectedIndex = 2 Then
						Me.Type = 2
					End If
				Else
					Me.Type = 1
				End If
			Else
				Me.Type = 0
			End If
			Me.RefreshComponent()
		End Sub

		Private Sub EditPanel_MouseMove(sender As Object, e As MouseEventArgs)
			If Not Me.Focused Then
				Me.EditPanel.Focus()
			End If
			Dim gPCurveScalarKey As GPCurveScalarKey = 0F
			__Dereference((gPCurveScalarKey + 4)) = 0F
			Dim gPCurveColorKey As GPCurveColorKey = 0F
			__Dereference((gPCurveColorKey + 12)) = 0F
			__Dereference((gPCurveColorKey + 8)) = 0F
			__Dereference((gPCurveColorKey + 4)) = 0F
			__Dereference((gPCurveColorKey + 16)) = 1F
			Dim p As Point = Nothing
			Dim position As Point = Nothing
			Dim x As GKeyNode = e.X
			__Dereference((x + 4)) = e.Y
			Dim size As Size = Nothing
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type = 1 Then
					Me.ConvertNodeToColorKey(x, gPCurveColorKey)
					GoTo IL_B2
				End If
				If type <> 2 Then
					GoTo IL_B2
				End If
			End If
			Me.ConvertNodeToScalarKey(x, gPCurveScalarKey)
			IL_B2:
			If MyBase.ContainsFocus Then
				Me.EditPanel.Focus()
			End If
			Select Case Me.DragMode
				Case 0
					Dim num As Integer = -1
					Dim num2 As Integer = 0
					If 0 < __Dereference(CType((Me.Nodes + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer))) Then
						Do
							Dim ptr As __Pointer(Of GKeyNode) = __Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num2 * 8
							If 4 > __Dereference(ptr) - e.X Then
								Dim ptr2 As __Pointer(Of GKeyNode) = __Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num2 * 8
								If -4 < __Dereference(ptr2) - e.X Then
									Dim ptr3 As __Pointer(Of GKeyNode) = __Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num2 * 8
									If 4 > __Dereference((ptr3 + 4)) - e.Y Then
										Dim ptr4 As __Pointer(Of GKeyNode) = __Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num2 * 8
										If -4 < __Dereference((ptr4 + 4)) - e.Y Then
											GoTo IL_1BA
										End If
									End If
								End If
							End If
							num2 += 1
						Loop While num2 < __Dereference(CType((Me.Nodes + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer)))
						GoTo IL_1BD
						IL_1BA:
						num = num2
					End If
					IL_1BD:
					If num <> Me.HighlightNodeIndex Then
						Me.HighlightNodeIndex = num
						Me.InvalidatePanels()
					End If
				Case 9
					Dim type2 As Integer = Me.Type
					If type2 <> 0 Then
						If type2 <> 1 Then
							If type2 = 2 Then
								<Module>.?Move@?$GCurveScalarEditor@VGCurveBezierScalar@@VGPCurveBezierScalar@@VGPCurveScalarKey@@@@$$FQAEXAAVGPCurveScalarKey@@W4GKeyMoveMode@@@Z(Me.BezierScalarEditor, gPCurveScalarKey, Me.KeyMoveMode)
							End If
						Else
							<Module>.?Move@GCurveLinearColorEditor@@$$FQAEXAAVGPCurveColorKey@@W4GKeyMoveMode@@@Z(Me.LinearColorEditor, gPCurveColorKey, Me.KeyMoveMode)
						End If
					Else
						<Module>.?Move@?$GCurveScalarEditor@VGCurveLinearScalar@@VGPCurveLinearScalar@@VGPCurveScalarKey@@@@$$FQAEXAAVGPCurveScalarKey@@W4GKeyMoveMode@@@Z(Me.LinearScalarEditor, gPCurveScalarKey, Me.KeyMoveMode)
					End If
					Me.HighlightNodeIndex = -1
					Me.GenerateNodes()
					Me.RefreshUpDownControls()
					position = Cursor.Position
					Dim movedIndex As Integer = Me.GetMovedIndex()
					p.X = __Dereference((movedIndex * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))))
					Dim movedIndex2 As Integer = Me.GetMovedIndex()
					p.Y = __Dereference((movedIndex2 * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + 4))
					p = Me.EditPanel.PointToScreen(p)
					If 5 < position.X - p.X OrElse -5 > position.X - p.X Then
						position.X = p.X
						Cursor.Position = position
					End If
					If 5 < position.Y - p.Y OrElse -5 > position.Y - p.Y Then
						position.Y = p.Y
						Cursor.Position = position
					End If
					Me.InvalidatePanels()
				Case 14
					If e.X < Me.BaseMousePoint.X Then
						Me.SelectionRectangle.X = e.X
						Me.SelectionRectangle.Width = Me.BaseMousePoint.X - e.X
					Else
						Me.SelectionRectangle.X = Me.BaseMousePoint.X
						Me.SelectionRectangle.Width = e.X - Me.BaseMousePoint.X
					End If
					If e.Y < Me.BaseMousePoint.Y Then
						Me.SelectionRectangle.Y = e.Y
						Me.SelectionRectangle.Height = Me.BaseMousePoint.Y - e.Y
					Else
						Me.SelectionRectangle.Y = Me.BaseMousePoint.Y
						Me.SelectionRectangle.Height = e.Y - Me.BaseMousePoint.Y
					End If
					Me.InvalidatePanels()
				Case 19
					position = Cursor.Position
					Dim num3 As Single = CSng((position.X - Me.BaseMousePoint.X))
					Dim num4 As Single = CSng((position.Y - Me.BaseMousePoint.Y))
					If num3 <> 0F OrElse num4 <> 0F Then
						Cursor.Position = Me.BaseMousePoint
					End If
					size = Me.EditPanel.Size
					num3 = Me.IViewport.Width / CSng(size.Width) * num3
					num4 = Me.IViewport.Height / CSng(size.Height) * num4
					Me.IViewport.X = Me.IViewport.X - num3
					Me.IViewport.Y = Me.IViewport.Y + num4
					Me.RefreshComponent()
			End Select
			Dim position2 As Point = Cursor.Position
			Me.PrevMousePoint = position2
			Dim type3 As Integer = Me.Type
			If type3 <> 0 Then
				If type3 <> 1 Then
					If type3 = 2 Then
						Dim bezierScalarEditor As __Pointer(Of GCurveBezierScalarEditor) = Me.BezierScalarEditor
						Dim num5 As Single = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), bezierScalarEditor, gPCurveScalarKey, __Dereference((__Dereference(CType(bezierScalarEditor, __Pointer(Of Integer))) + 16)))
						Dim num6 As Single = __Dereference((gPCurveScalarKey + 4))
						Dim num7 As Single = gPCurveScalarKey
						Me.StatusBar.Text = "Coordinates: (" + num7.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", " + num6.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + "), Value: " + num5.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte))))
					End If
				Else
					Dim linearColorEditor As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
					Dim num8 As Single = __Dereference((calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, gPCurveColorKey, __Dereference((__Dereference(CType(linearColorEditor, __Pointer(Of Integer))) + 12))) + 8))
					Dim linearColorEditor2 As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
					Dim num9 As Single = __Dereference((calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor2, gPCurveColorKey, __Dereference((__Dereference(CType(linearColorEditor2, __Pointer(Of Integer))) + 12))) + 4))
					Dim linearColorEditor3 As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
					Dim num10 As Single = __Dereference(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor3, gPCurveColorKey, __Dereference((__Dereference(CType(linearColorEditor3, __Pointer(Of Integer))) + 12))))
					Dim linearColorEditor4 As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
					Dim num11 As Single = __Dereference((calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor4, gPCurveColorKey, __Dereference((__Dereference(CType(linearColorEditor4, __Pointer(Of Integer))) + 12))) + 12))
					Dim num12 As Single = __Dereference((gPCurveColorKey + 16))
					Dim num13 As Single = gPCurveColorKey
					Me.StatusBar.Text = "Coordinates: (" + num13.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", " + num12.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + "), Alpha: " + num11.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", Red: " + num10.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", Green: " + num9.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", Blue: " + num8.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte))))
				End If
			Else
				Dim linearScalarEditor As __Pointer(Of GCurveLinearScalarEditor) = Me.LinearScalarEditor
				Dim num14 As Single = calli(System.Single modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearScalarEditor, gPCurveScalarKey, __Dereference((__Dereference(CType(linearScalarEditor, __Pointer(Of Integer))) + 16)))
				Dim num15 As Single = __Dereference((gPCurveScalarKey + 4))
				Dim num16 As Single = gPCurveScalarKey
				Me.StatusBar.Text = "Coordinates: (" + num16.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", " + num15.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + "), Value: " + num14.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte))))
			End If
		End Sub

		Private Sub ColorPanel_MouseMove(sender As Object, e As MouseEventArgs)
			Dim gPCurveScalarKey As GPCurveScalarKey = 0F
			__Dereference((gPCurveScalarKey + 4)) = 0F
			Dim x As GKeyNode = e.X
			__Dereference((x + 4)) = e.Y
			Me.ConvertNodeToScalarKey(x, gPCurveScalarKey)
			Dim linearColorEditor As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
			Dim num As Single = __Dereference((calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, gPCurveScalarKey, __Dereference((__Dereference(CType(linearColorEditor, __Pointer(Of Integer))) + 12))) + 8))
			Dim linearColorEditor2 As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
			Dim num2 As Single = __Dereference((calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor2, gPCurveScalarKey, __Dereference((__Dereference(CType(linearColorEditor2, __Pointer(Of Integer))) + 12))) + 4))
			Dim linearColorEditor3 As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
			Dim num3 As Single = __Dereference(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor3, gPCurveScalarKey, __Dereference((__Dereference(CType(linearColorEditor3, __Pointer(Of Integer))) + 12))))
			Dim num4 As Single = gPCurveScalarKey
			Me.StatusBar.Text = "Time: " + num4.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", Red: " + num3.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", Green: " + num2.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte)))) + ", Blue: " + num.ToString(New String(CType((AddressOf <Module>.??_C@_02IBAANIJI@G3?$AA@), __Pointer(Of SByte))))
		End Sub

		Private Sub ColorPicker_ValueChanged()
			Dim gColor As GColor
			__Dereference((gColor + 8)) = 0F
			__Dereference((gColor + 4)) = 0F
			gColor = 0F
			__Dereference((gColor + 12)) = 1F
			Dim colorPicker As ColorPicker = Me.ColorPicker
			<Module>.GColor.FromHSV(gColor, colorPicker.Hue, colorPicker.Sat, colorPicker.Val)
			<Module>.GCurveLinearColorEditor.SetColor(Me.LinearColorEditor, gColor)
			Me.InvalidColorPanel = True
			Me.raise_NotifyUndoStep()
		End Sub

		Private Sub EditPanel_MouseLeave(sender As Object, e As EventArgs)
			Me.HighlightNodeIndex = -1
			Me.StatusBar.Text = Nothing
		End Sub

		Private Sub EditPanel_MouseDown(sender As Object, e As MouseEventArgs)
			If MouseButtons.Left = e.Button Then
				If -1 <> Me.HighlightNodeIndex Then
					If Control.ModifierKeys = Keys.ControlKey Then
						Me.InvertSelection(Me.HighlightNodeIndex)
					Else If Control.ModifierKeys = Keys.ShiftKey Then
						Me.SelectToIndex(Me.HighlightNodeIndex)
					Else
						If(<Module>.GetKeyState(37) And 128) <> 128S AndAlso (<Module>.GetKeyState(39) And 128) <> 128S Then
							If(<Module>.GetKeyState(38) And 128) <> 128S AndAlso (<Module>.GetKeyState(40) And 128) <> 128S Then
								Me.KeyMoveMode = 0
							Else
								Me.KeyMoveMode = 1
							End If
						Else
							Me.KeyMoveMode = 2
						End If
						Dim position As Point = Cursor.Position
						Me.BaseMousePoint = position
						Me.BeginMove(Me.HighlightNodeIndex)
						Me.HideCursor()
						Me.DragMode = 9
					End If
					Me.RefreshComponent()
				Else
					Dim position2 As Point = Cursor.Position
					Me.BaseMousePoint = position2
					Dim baseMousePoint As Point = Me.EditPanel.PointToClient(Me.BaseMousePoint)
					Me.BaseMousePoint = baseMousePoint
					Me.DragMode = 14
				End If
			Else If MouseButtons.Right = e.Button Then
				Dim dragMode As Integer = Me.DragMode
				If 9 = dragMode Then
					Cursor.Position = Me.BaseMousePoint
					Me.DragMode = 0
					Me.CancelMove()
					Me.ShowCursor()
					Me.GenerateNodes()
					Me.InvalidatePanels()
					Me.ContextMenuBlock = True
				Else If 14 = dragMode Then
					Me.DragMode = 0
					Me.InvalidatePanels()
					Me.ContextMenuBlock = True
				End If
			Else If MouseButtons.Middle = e.Button Then
				Dim position3 As Point = Cursor.Position
				Me.BaseMousePoint = position3
				Me.HideCursor()
				Me.DragMode = 19
			End If
		End Sub

		Private Sub EditPanel_MouseUp(sender As Object, e As MouseEventArgs)
			If MouseButtons.Left = e.Button Then
				Dim dragMode As Integer = Me.DragMode
				If 9 = dragMode Then
					Me.DragMode = 0
					Dim point As Point = Nothing
					Dim movedIndex As Integer = Me.GetMovedIndex()
					point.X = __Dereference((movedIndex * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer)))))
					Dim movedIndex2 As Integer = Me.GetMovedIndex()
					point.Y = __Dereference((movedIndex2 * 8 + __Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + 4))
					point = Me.EditPanel.PointToScreen(point)
					Cursor.Position = point
					Me.EndMove()
					Me.ShowCursor()
				Else If 14 = dragMode Then
					If Control.ModifierKeys <> Keys.ShiftKey Then
						Me.ClearSelection()
						Dim num As Integer = 0
						If 0 < __Dereference(CType((Me.Nodes + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer))) Then
							Do
								If __Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num * 8)) > Me.SelectionRectangle.Left AndAlso __Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num * 8)) < Me.SelectionRectangle.Right AndAlso __Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num * 8 + 4)) > Me.SelectionRectangle.Top AndAlso __Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num * 8 + 4)) < Me.SelectionRectangle.Bottom Then
									Me.InvertSelection(num)
								End If
								num += 1
							Loop While num < __Dereference(CType((Me.Nodes + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer)))
						End If
					Else
						Dim num2 As Integer = 0
						If 0 < __Dereference(CType((Me.Nodes + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer))) Then
							Do
								If __Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num2 * 8)) > Me.SelectionRectangle.Left AndAlso __Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num2 * 8)) < Me.SelectionRectangle.Right AndAlso __Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num2 * 8 + 4)) > Me.SelectionRectangle.Top AndAlso __Dereference((__Dereference(CType(Me.Nodes, __Pointer(Of Integer))) + num2 * 8 + 4)) < Me.SelectionRectangle.Bottom Then
									Me.AddIndexToSelection(num2)
								End If
								num2 += 1
							Loop While num2 < __Dereference(CType((Me.Nodes + 4 / __SizeOf(GArray<GKeyNode>)), __Pointer(Of Integer)))
						End If
					End If
					Me.DragMode = 0
					Me.RefreshComponent()
				End If
			Else If MouseButtons.Middle = e.Button AndAlso 19 = Me.DragMode Then
				Cursor.Position = Me.BaseMousePoint
				Me.ShowCursor()
				Me.DragMode = 0
			End If
		End Sub

		Private Sub ColorPanel_MouseDown(sender As Object, e As MouseEventArgs)
			Dim gPCurveScalarKey As GPCurveScalarKey = 0F
			__Dereference((gPCurveScalarKey + 4)) = 0F
			Dim x As GKeyNode = e.X
			__Dereference((x + 4)) = e.Y
			Me.ConvertNodeToScalarKey(x, gPCurveScalarKey)
			Dim linearColorEditor As __Pointer(Of GCurveLinearColorEditor) = Me.LinearColorEditor
			Dim hue As Integer
			Dim sat As Integer
			Dim val As Integer
			<Module>.GColor.ToHSV(calli(GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single), linearColorEditor, gPCurveScalarKey, __Dereference((__Dereference(CType(linearColorEditor, __Pointer(Of Integer))) + 12))), hue, sat, val)
			Me.ColorPicker.Hue = hue
			Me.ColorPicker.Sat = sat
			Me.ColorPicker.Val = val
		End Sub

		Private Sub Exit_Click(sender As Object, e As EventArgs)
		End Sub

		Private Sub All_Click(sender As Object, e As EventArgs)
			Me.ClearSelection()
			Dim num As Integer = Me.GetNumberOfKeys() - 1
			If num >= 0 Then
				Do
					Me.AddIndexToSelection(num)
					num -= 1
				Loop While num >= 0
			End If
			Me.RefreshComponent()
		End Sub

		Private Sub None_Click(sender As Object, e As EventArgs)
			Me.ClearSelection()
			Me.RefreshComponent()
		End Sub

		Private Sub Undo_Click(sender As Object, e As EventArgs)
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Undo(Me.BezierScalarEditor)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Undo(Me.LinearColorEditor)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Undo(Me.LinearScalarEditor)
			End If
			Me.RefreshComponent()
		End Sub

		Private Sub Redo_Click(sender As Object, e As EventArgs)
			Dim type As Integer = Me.Type
			If type <> 0 Then
				If type <> 1 Then
					If type = 2 Then
						<Module>.GCurveEditor<GCurveBezierScalar,GPCurveBezierScalar,GPCurveScalarKey>.Redo(Me.BezierScalarEditor)
					End If
				Else
					<Module>.GCurveEditor<GCurveLinearColor,GPCurveLinearColor,GPCurveColorKey>.Redo(Me.LinearColorEditor)
				End If
			Else
				<Module>.GCurveEditor<GCurveLinearScalar,GPCurveLinearScalar,GPCurveScalarKey>.Redo(Me.LinearScalarEditor)
			End If
			Me.RefreshComponent()
		End Sub

		Private Sub EditPanelContextMenu_Popup(sender As Object, e As EventArgs)
			Dim position As Point = Cursor.Position
			Dim contextMenuPosition As Point = Me.EditPanel.PointToClient(position)
			Me.ContextMenuPosition = contextMenuPosition
			Dim x As GKeyNode = Me.ContextMenuPosition.X
			__Dereference((x + 4)) = Me.ContextMenuPosition.Y
			Me.EditPanelContextMenu.MenuItems.Clear()
			If Not Me.ContextMenuBlock Then
				Dim highlightNodeIndex As Integer = Me.HighlightNodeIndex
				Me.ContextMenuNodeIndex = highlightNodeIndex
				If -1 <> highlightNodeIndex Then
					If 1 = Me.Type Then
						Me.EditPanelContextMenu.MenuItems.Add(Me.PeekColor)
					End If
					If Me.HighlightNodeIndex <> 0 Then
						Me.EditPanelContextMenu.MenuItems.Add(Me.RemoveKey)
					End If
					If Me.GetLoopStart() = Me.HighlightNodeIndex Then
						Me.EditPanelContextMenu.MenuItems.Add(Me.ClearLoopStart)
					Else
						Me.EditPanelContextMenu.MenuItems.Add(Me.SetAsLoopStart)
					End If
					If Me.GetLoopEnd() = Me.HighlightNodeIndex Then
						Me.EditPanelContextMenu.MenuItems.Add(Me.ClearLoopEnd)
					Else
						Me.EditPanelContextMenu.MenuItems.Add(Me.SetAsLoopEnd)
					End If
				Else If Me.IsInLimits(x) Then
					Me.EditPanelContextMenu.MenuItems.Add(Me.AddKey)
				End If
			End If
			Me.ContextMenuBlock = False
		End Sub

		Private Sub AddKey_Click(sender As Object, e As EventArgs)
			Dim x As GKeyNode = Me.ContextMenuPosition.X
			__Dereference((x + 4)) = Me.ContextMenuPosition.Y
			Me.AddNode(x)
		End Sub

		Private Sub PeekColor_Click(sender As Object, e As EventArgs)
			Dim hue As Integer
			Dim sat As Integer
			Dim val As Integer
			<Module>.GColor.ToHSV(Me.ContextMenuNodeIndex * 20 + __Dereference((__Dereference(CType((Me.LinearColorEditor + 32 / __SizeOf(GCurveLinearColorEditor)), __Pointer(Of Integer))) + 12)) + 4, hue, sat, val)
			Me.ColorPicker.Hue = hue
			Me.ColorPicker.Sat = sat
			Me.ColorPicker.Val = val
		End Sub

		Private Sub RemoveKey_Click(sender As Object, e As EventArgs)
			Me.RemoveNodes(Me.ContextMenuNodeIndex, False)
		End Sub

		Private Sub SetAsLoopStart_Click(sender As Object, e As EventArgs)
			If -1 <> Me.GetLoopEnd() AndAlso Me.GetVerticalKeyValue(Me.GetLoopEnd()) <> Me.GetVerticalKeyValue(Me.ContextMenuNodeIndex) Then
				Dim dialogResult As DialogResult = New NCopyKeyDialog("Copy loop end value to this key", "Copy value of this key to loop end").ShowDialog()
				If DialogResult.Yes = dialogResult Then
					Me.SetLoopStart(Me.ContextMenuNodeIndex, True)
				Else If DialogResult.No = dialogResult Then
					Me.SetLoopStart(Me.ContextMenuNodeIndex, False)
				End If
				Me.GenerateNodes()
			Else
				Me.SetLoopStart(Me.ContextMenuNodeIndex, False)
			End If
			Me.InvalidatePanels()
		End Sub

		Private Sub SetAsLoopEnd_Click(sender As Object, e As EventArgs)
			If -1 <> Me.GetLoopStart() AndAlso Me.GetVerticalKeyValue(Me.GetLoopStart()) <> Me.GetVerticalKeyValue(Me.ContextMenuNodeIndex) Then
				Dim dialogResult As DialogResult = New NCopyKeyDialog("Copy loop start value to this key", "Copy value of this key to loop start").ShowDialog()
				If DialogResult.Yes = dialogResult Then
					Me.SetLoopEnd(Me.ContextMenuNodeIndex, True)
				Else If DialogResult.No = dialogResult Then
					Me.SetLoopEnd(Me.ContextMenuNodeIndex, False)
				End If
				Me.GenerateNodes()
			Else
				Me.SetLoopEnd(Me.ContextMenuNodeIndex, False)
			End If
			Me.InvalidatePanels()
		End Sub

		Private Sub ClearLoopStart_Click(sender As Object, e As EventArgs)
			Me.SetLoopStart(-1, False)
		End Sub

		Private Sub ClearLoopEnd_Click(sender As Object, e As EventArgs)
			Me.SetLoopEnd(-1, False)
		End Sub

		Private Sub EditPanel_Resize(sender As Object, e As EventArgs)
			Dim clientSize As Size = Me.EditPanel.ClientSize
			If Nothing IsNot Me.EditPanelD3D AndAlso 4 <= clientSize.Width AndAlso 4 <= clientSize.Height Then
				Me.EditPanelD3D.Resize(clientSize.Width, clientSize.Height)
			End If
		End Sub

		Private Sub ColorPanel_Resize(sender As Object, e As EventArgs)
			Dim clientSize As Size = Me.ColorPanel.ClientSize
			If Nothing IsNot Me.ColorPanelD3D AndAlso 4 <= clientSize.Width AndAlso 4 <= clientSize.Height Then
				Me.ColorPanelD3D.Resize(clientSize.Width, clientSize.Height)
			End If
		End Sub

		Private Sub NCurveEditor_Closed(sender As Object, e As EventArgs)
			Me.DisposeD3DX()
		End Sub

		Private Sub NCurveEditor_Idle(sender As Object, e As EventArgs)
			If 1 = Me.Type AndAlso Me.InvalidColorPanel Then
				Me.ColorPanel.Invalidate()
				Me.InvalidColorPanel = False
			End If
		End Sub

		Protected Sub raise_NotifyUndoStep()
			Dim notifyUndoStep As NCurveEditor.CurveChangedHandler = Me.NotifyUndoStep
			If notifyUndoStep IsNot Nothing Then
				notifyUndoStep()
			End If
		End Sub
	End Class
End Namespace
