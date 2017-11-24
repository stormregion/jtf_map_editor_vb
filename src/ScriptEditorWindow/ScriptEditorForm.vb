Imports <CppImplementationDetails>
Imports NWorkshop
Imports Script_ActionListTree
Imports Script_ActionListTree_Node
Imports Script_GlobalVariable
Imports Script_GlobalVariable_Header
Imports Script_GlobalVariable_ListItem
Imports ScriptEditor
Imports ScriptVariablePropertiesWindow
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace ScriptEditorWindow
	Public Class ScriptEditorForm
		Inherits Form

		Private Enum eDragType
			DRAG_MAX = 4
			DRAG_Trigger = 3
			DRAG_Entity = 2
			DRAG_LocalVariable = 1
			DRAG_GlobalVariable = 0
		End Enum

		Private ScriptIndex As Integer

		Private Editor As __Pointer(Of cEditor)

		Private ClipboardStream As __Pointer(Of GStreamBuffer)

		Private DragType As ScriptEditorForm.eDragType

		Private DragIndex As Integer

		Private ListSelection_ValueType As Integer

		Private ScriptEntities_List As Integer()

		Private SelectedTriggerIndex As Integer

		Private menuItem1 As MenuItem

		Private GlobalVariable_Create As MenuItem

		Private GlobalVariable_Delete As MenuItem

		Private GlobalVariables_ContextMenu As ContextMenu

		Private Triggers_ContextMenu As ContextMenu

		Private Trigger_Create As MenuItem

		Private Trigger_Delete As MenuItem

		Private Script_New As MenuItem

		Private Script_Save As MenuItem

		Private Script_SaveAs As MenuItem

		Private Script_Close As MenuItem

		Private menuItem3 As MenuItem

		Private GlobalVariableControl As Script_GlobalVariableControl

		Private TriggerVariableControl As Script_GlobalVariableControl

		Private GlobalTriggerControl As Script_GlobalVariableControl

		Private ScriptEntitiesControl As Script_GlobalVariableControl

		Private ScriptEntitiesFilterBox As ListBox

		Private TV_Name As Script_GlobalVariableControl_Header

		Private TV_Type As Script_GlobalVariableControl_Header

		Private TV_Value As Script_GlobalVariableControl_Header

		Private GLV_Name As Script_GlobalVariableControl_Header

		Private GLV_Type As Script_GlobalVariableControl_Header

		Private GLV_Value As Script_GlobalVariableControl_Header

		Private GLV_Used As Script_GlobalVariableControl_Header

		Private GT_Name As Script_GlobalVariableControl_Header

		Private GT_Event As Script_GlobalVariableControl_Header

		Private SEN_Name As Script_GlobalVariableControl_Header

		Private SEN_Type As Script_GlobalVariableControl_Header

		Private SEN_Value As Script_GlobalVariableControl_Header

		Private SEN_Used As Script_GlobalVariableControl_Header

		Private TriggerActionListLabel As Label

		Private GlobalVariablesLabel As Label

		Private ScriptEntitiesFilterLabel As Label

		Private ScriptEntitiesLabel As Label

		Private TriggerVariablesLabel As Label

		Private TriggerGroup As GroupBox

		Private GlobalGroupBox As GroupBox

		Private GT_Active As Script_GlobalVariableControl_Header

		Private TV_Used As Script_GlobalVariableControl_Header

		Private MainMenu As MainMenu

		Private ActionType_Label As Label

		Private ConditionType_Label As Label

		Private AddActionButton As Button

		Private DeleteActionButton As Button

		Private AddConditionButton As Button

		Private DeleteConditionButton As Button

		Private DeleteActionBlockButton As Button

		Private DeleteConditionBlockButton As Button

		Private StatusLine As TextBox

		Private ActionListTreeControl As Script_ActionListTreeControl

		Private NegateConditionButton As Button

		Private TriggerVariables_ContextMenu As ContextMenu

		Private TriggerVariable_Create As MenuItem

		Private TriggerVariable_Delete As MenuItem

		Private ActionTypeBox As ListBox

		Private ConditionTypeBox As ListBox

		Private DeleteActionPartButton As Button

		Private menuItem2 As MenuItem

		Private MainMenu_Scripts As MenuItem

		Private Edit_Undo As MenuItem

		Private Edit_Redo As MenuItem

		Private menuItem5 As MenuItem

		Private Edit_Copy As MenuItem

		Private Edit_Cut As MenuItem

		Private Edit_Paste As MenuItem

		Private Edit_Clear As MenuItem

		Private menuItem6 As MenuItem

		Private Script_Import As MenuItem

		Private Script_Export As MenuItem

		Private Script_Delete As MenuItem

		Private InsertSingleOrConditionButton As Button

		Private Trigger_Copy As MenuItem

		Private ActionList_ContextMenu As ContextMenu

		Private Actions_Insert As MenuItem

		Private Actions_Delete As MenuItem

		Private menuItem7 As MenuItem

		Private TriggerVariable_MoveUp As MenuItem

		Private TriggerVariable_MoveDown As MenuItem

		Private TriggerVariable_FixOrder As MenuItem

		Private menuItem7a As MenuItem

		Private GlobalVariable_MoveUp As MenuItem

		Private GlobalVariable_MoveDown As MenuItem

		Private GlobalVariable_FixOrder As MenuItem

		Private menuItem8 As MenuItem

		Private Edit_Refresh As MenuItem

		Private Trigger_Create_Empty As MenuItem

		Private menuItem9 As MenuItem

		Private Trigger_FixOrder As MenuItem

		Private Trigger_MoveUp As MenuItem

		Private Trigger_MoveDown As MenuItem

		Private ScriptEntities_ShowStoredUnits As CheckBox

		Private components As Container

		Public Sub New()
			Me.InitializeComponent()
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
			Me.MainMenu = New MainMenu()
			Me.menuItem1 = New MenuItem()
			Me.Script_New = New MenuItem()
			Me.Script_Save = New MenuItem()
			Me.Script_Delete = New MenuItem()
			Me.menuItem3 = New MenuItem()
			Me.Script_Import = New MenuItem()
			Me.Script_Export = New MenuItem()
			Me.menuItem6 = New MenuItem()
			Me.Script_Close = New MenuItem()
			Me.menuItem2 = New MenuItem()
			Me.Edit_Undo = New MenuItem()
			Me.Edit_Redo = New MenuItem()
			Me.menuItem5 = New MenuItem()
			Me.Edit_Cut = New MenuItem()
			Me.Edit_Copy = New MenuItem()
			Me.Edit_Paste = New MenuItem()
			Me.Edit_Clear = New MenuItem()
			Me.menuItem8 = New MenuItem()
			Me.Edit_Refresh = New MenuItem()
			Me.MainMenu_Scripts = New MenuItem()
			Me.Script_SaveAs = New MenuItem()
			Me.GlobalGroupBox = New GroupBox()
			Me.GlobalTriggerControl = New Script_GlobalVariableControl()
			Me.GT_Name = New Script_GlobalVariableControl_Header()
			Me.GT_Event = New Script_GlobalVariableControl_Header()
			Me.GT_Active = New Script_GlobalVariableControl_Header()
			Me.Triggers_ContextMenu = New ContextMenu()
			Me.Trigger_Create = New MenuItem()
			Me.Trigger_Create_Empty = New MenuItem()
			Me.Trigger_Copy = New MenuItem()
			Me.Trigger_Delete = New MenuItem()
			Me.menuItem9 = New MenuItem()
			Me.Trigger_MoveUp = New MenuItem()
			Me.Trigger_MoveDown = New MenuItem()
			Me.Trigger_FixOrder = New MenuItem()
			Me.GlobalVariablesLabel = New Label()
			Me.GlobalVariableControl = New Script_GlobalVariableControl()
			Me.GLV_Name = New Script_GlobalVariableControl_Header()
			Me.GLV_Type = New Script_GlobalVariableControl_Header()
			Me.GLV_Value = New Script_GlobalVariableControl_Header()
			Me.GLV_Used = New Script_GlobalVariableControl_Header()
			Me.GlobalVariables_ContextMenu = New ContextMenu()
			Me.GlobalVariable_Create = New MenuItem()
			Me.GlobalVariable_Delete = New MenuItem()
			Me.ScriptEntitiesLabel = New Label()
			Me.ScriptEntitiesControl = New Script_GlobalVariableControl()
			Me.SEN_Name = New Script_GlobalVariableControl_Header()
			Me.SEN_Type = New Script_GlobalVariableControl_Header()
			Me.SEN_Value = New Script_GlobalVariableControl_Header()
			Me.SEN_Used = New Script_GlobalVariableControl_Header()
			Me.ScriptEntitiesFilterLabel = New Label()
			Me.ScriptEntitiesFilterBox = New ListBox()
			Me.TriggerGroup = New GroupBox()
			Me.InsertSingleOrConditionButton = New Button()
			Me.DeleteActionPartButton = New Button()
			Me.ConditionTypeBox = New ListBox()
			Me.ActionTypeBox = New ListBox()
			Me.NegateConditionButton = New Button()
			Me.DeleteConditionBlockButton = New Button()
			Me.DeleteActionBlockButton = New Button()
			Me.DeleteConditionButton = New Button()
			Me.AddConditionButton = New Button()
			Me.DeleteActionButton = New Button()
			Me.AddActionButton = New Button()
			Me.ConditionType_Label = New Label()
			Me.ActionType_Label = New Label()
			Me.ActionListTreeControl = New Script_ActionListTreeControl()
			Me.ActionList_ContextMenu = New ContextMenu()
			Me.Actions_Insert = New MenuItem()
			Me.Actions_Delete = New MenuItem()
			Me.TriggerActionListLabel = New Label()
			Me.TriggerVariablesLabel = New Label()
			Me.TriggerVariableControl = New Script_GlobalVariableControl()
			Me.TV_Name = New Script_GlobalVariableControl_Header()
			Me.TV_Type = New Script_GlobalVariableControl_Header()
			Me.TV_Value = New Script_GlobalVariableControl_Header()
			Me.TV_Used = New Script_GlobalVariableControl_Header()
			Me.TriggerVariables_ContextMenu = New ContextMenu()
			Me.TriggerVariable_Create = New MenuItem()
			Me.TriggerVariable_Delete = New MenuItem()
			Me.menuItem7 = New MenuItem()
			Me.TriggerVariable_MoveUp = New MenuItem()
			Me.TriggerVariable_MoveDown = New MenuItem()
			Me.TriggerVariable_FixOrder = New MenuItem()
			Me.menuItem7a = New MenuItem()
			Me.GlobalVariable_MoveUp = New MenuItem()
			Me.GlobalVariable_MoveDown = New MenuItem()
			Me.GlobalVariable_FixOrder = New MenuItem()
			Me.StatusLine = New TextBox()
			Me.ScriptEntities_ShowStoredUnits = New CheckBox()
			Me.GlobalGroupBox.SuspendLayout()
			Me.TriggerGroup.SuspendLayout()
			MyBase.SuspendLayout()
			Dim items As MenuItem() = New MenuItem() { Me.menuItem1, Me.menuItem2, Me.MainMenu_Scripts }
			Me.MainMenu.MenuItems.AddRange(items)
			Me.menuItem1.Index = 0
			Dim items2 As MenuItem() = New MenuItem() { Me.Script_New, Me.Script_Save, Me.Script_Delete, Me.menuItem3, Me.Script_Import, Me.Script_Export, Me.menuItem6, Me.Script_Close }
			Me.menuItem1.MenuItems.AddRange(items2)
			Me.menuItem1.Text = "File"
			Me.Script_New.Index = 0
			Me.Script_New.Shortcut = Shortcut.CtrlN
			Me.Script_New.Text = "New"
			AddHandler Me.Script_New.Click, AddressOf Me.Script_New_Click
			Me.Script_Save.Index = 1
			Me.Script_Save.Shortcut = Shortcut.CtrlS
			Me.Script_Save.Text = "Save"
			AddHandler Me.Script_Save.Click, AddressOf Me.Script_Save_Click
			Me.Script_Delete.Index = 2
			Me.Script_Delete.Shortcut = Shortcut.CtrlDel
			Me.Script_Delete.Text = "Delete"
			AddHandler Me.Script_Delete.Click, AddressOf Me.Script_Delete_Click
			Me.menuItem3.Index = 3
			Me.menuItem3.Text = "-"
			Me.Script_Import.Index = 4
			Me.Script_Import.Text = "Import..."
			AddHandler Me.Script_Import.Click, AddressOf Me.Script_Import_Click
			Me.Script_Export.Index = 5
			Me.Script_Export.Text = "Export..."
			AddHandler Me.Script_Export.Click, AddressOf Me.Script_Export_Click
			Me.menuItem6.Index = 6
			Me.menuItem6.Text = "-"
			Me.Script_Close.Index = 7
			Me.Script_Close.Text = "Close"
			AddHandler Me.Script_Close.Click, AddressOf Me.Script_Close_Click
			Me.menuItem2.Index = 1
			Dim items3 As MenuItem() = New MenuItem() { Me.Edit_Undo, Me.Edit_Redo, Me.menuItem5, Me.Edit_Cut, Me.Edit_Copy, Me.Edit_Paste, Me.Edit_Clear, Me.menuItem8, Me.Edit_Refresh }
			Me.menuItem2.MenuItems.AddRange(items3)
			Me.menuItem2.Text = "Edit"
			Me.Edit_Undo.Enabled = False
			Me.Edit_Undo.Index = 0
			Me.Edit_Undo.Shortcut = Shortcut.CtrlZ
			Me.Edit_Undo.Text = "Undo"
			AddHandler Me.Edit_Undo.Click, AddressOf Me.Edit_Undo_Click
			Me.Edit_Redo.Enabled = False
			Me.Edit_Redo.Index = 1
			Me.Edit_Redo.Shortcut = Shortcut.CtrlY
			Me.Edit_Redo.Text = "Redo"
			AddHandler Me.Edit_Redo.Click, AddressOf Me.Edit_Redo_Click
			Me.menuItem5.Index = 2
			Me.menuItem5.Text = "-"
			Me.Edit_Cut.Index = 3
			Me.Edit_Cut.Shortcut = Shortcut.CtrlX
			Me.Edit_Cut.Text = "Cut"
			AddHandler Me.Edit_Cut.Click, AddressOf Me.Edit_Cut_Click
			Me.Edit_Copy.Index = 4
			Me.Edit_Copy.Shortcut = Shortcut.CtrlC
			Me.Edit_Copy.Text = "Copy"
			AddHandler Me.Edit_Copy.Click, AddressOf Me.Edit_Copy_Click
			Me.Edit_Paste.Index = 5
			Me.Edit_Paste.Shortcut = Shortcut.CtrlV
			Me.Edit_Paste.Text = "Paste"
			AddHandler Me.Edit_Paste.Click, AddressOf Me.Edit_Paste_Click
			Me.Edit_Clear.Index = 6
			Me.Edit_Clear.Text = "Clear"
			AddHandler Me.Edit_Clear.Click, AddressOf Me.Edit_Clear_Click
			Me.menuItem8.Index = 7
			Me.menuItem8.Text = "-"
			Me.Edit_Refresh.Index = 8
			Me.Edit_Refresh.Shortcut = Shortcut.CtrlR
			Me.Edit_Refresh.Text = "Refresh"
			AddHandler Me.Edit_Refresh.Click, AddressOf Me.Edit_Refresh_Click
			Me.MainMenu_Scripts.Index = 2
			Me.MainMenu_Scripts.Text = "Scripts"
			Me.Script_SaveAs.Index = -1
			Me.Script_SaveAs.Text = ""
			Me.GlobalGroupBox.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left)
			Me.GlobalGroupBox.Controls.Add(Me.GlobalTriggerControl)
			Dim location As Point = New Point(8, 8)
			Me.GlobalGroupBox.Location = location
			Me.GlobalGroupBox.Name = "GlobalGroupBox"
			Dim size As Size = New Size(296, 712)
			Me.GlobalGroupBox.Size = size
			Me.GlobalGroupBox.TabIndex = 6
			Me.GlobalGroupBox.TabStop = False
			Me.GlobalGroupBox.Text = "Triggers"
			Me.GlobalTriggerControl.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left)
			Dim window As Color = SystemColors.Window
			Me.GlobalTriggerControl.BackColor = window
			Dim columnHeaders As Script_GlobalVariableControl_Header() = New Script_GlobalVariableControl_Header() { Me.GT_Name, Me.GT_Event, Me.GT_Active }
			Me.GlobalTriggerControl.ColumnHeaders = columnHeaders
			Me.GlobalTriggerControl.ContextMenu = Me.Triggers_ContextMenu
			Me.GlobalTriggerControl.DrawGrid = True
			Me.GlobalTriggerControl.HeaderHeight = 18
			Me.GlobalTriggerControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
			Dim location2 As Point = New Point(8, 16)
			Me.GlobalTriggerControl.Location = location2
			Me.GlobalTriggerControl.Name = "GlobalTriggerControl"
			Me.GlobalTriggerControl.RealSelectedIndex = -1
			Me.GlobalTriggerControl.RowHeight = 14
			Me.GlobalTriggerControl.SelectedIndex = -1
			Dim size2 As Size = New Size(280, 686)
			Me.GlobalTriggerControl.Size = size2
			Me.GlobalTriggerControl.TabIndex = 6
			AddHandler Me.GlobalTriggerControl.DragStarted, AddressOf Me.GlobalTriggerControl_DragStarted
			AddHandler Me.GlobalTriggerControl.SortModeChanged, AddressOf Me.GlobalTriggerControl_SortModeChanged
			AddHandler Me.GlobalTriggerControl.ItemClicked, AddressOf Me.GlobalTriggerControl_ItemClicked
			AddHandler Me.GlobalTriggerControl.ItemDoubleClicked, AddressOf Me.GlobalTriggerControl_ItemDoubleClicked
			AddHandler Me.GlobalTriggerControl.SelectedIndexChanged, AddressOf Me.GlobalTriggerControl_SelectedIndexChanged
			Me.GT_Name.Text = "Name"
			Me.GT_Name.Width = 150
			Me.GT_Event.Text = "Event"
			Me.GT_Event.Width = 78
			Me.GT_Active.Text = "Act."
			Me.GT_Active.Width = 30
			Dim items4 As MenuItem() = New MenuItem() { Me.Trigger_Create, Me.Trigger_Create_Empty, Me.Trigger_Copy, Me.Trigger_Delete, Me.menuItem9, Me.Trigger_MoveUp, Me.Trigger_MoveDown, Me.Trigger_FixOrder }
			Me.Triggers_ContextMenu.MenuItems.AddRange(items4)
			Me.Trigger_Create.Index = 0
			Me.Trigger_Create.Shortcut = Shortcut.Ins
			Me.Trigger_Create.Text = "Create trigger"
			AddHandler Me.Trigger_Create.Click, AddressOf Me.Trigger_Create_Click
			Me.Trigger_Create_Empty.Index = 1
			Me.Trigger_Create_Empty.Text = "Create empty trigger"
			AddHandler Me.Trigger_Create_Empty.Click, AddressOf Me.Trigger_Create_Empty_Click
			Me.Trigger_Copy.Index = 2
			Me.Trigger_Copy.Shortcut = Shortcut.CtrlIns
			Me.Trigger_Copy.Text = "Copy trigger"
			AddHandler Me.Trigger_Copy.Click, AddressOf Me.Trigger_Copy_Click
			Me.Trigger_Delete.Index = 3
			Me.Trigger_Delete.Shortcut = Shortcut.Del
			Me.Trigger_Delete.Text = "Delete trigger"
			AddHandler Me.Trigger_Delete.Click, AddressOf Me.Trigger_Delete_Click
			Me.menuItem9.Index = 4
			Me.menuItem9.Text = "-"
			Me.Trigger_MoveUp.Index = 5
			Me.Trigger_MoveUp.Text = "Move Up"
			Me.Trigger_MoveUp.Shortcut = Shortcut.AltUpArrow
			AddHandler Me.Trigger_MoveUp.Click, AddressOf Me.Trigger_MoveUp_Click
			Me.Trigger_MoveDown.Index = 6
			Me.Trigger_MoveDown.Text = "Move Down"
			Me.Trigger_MoveDown.Shortcut = Shortcut.AltDownArrow
			AddHandler Me.Trigger_MoveDown.Click, AddressOf Me.Trigger_MoveDown_Click
			Me.Trigger_FixOrder.Index = 7
			Me.Trigger_FixOrder.Text = "Fix order"
			AddHandler Me.Trigger_FixOrder.Click, AddressOf Me.Trigger_FixOrder_Click
			Me.ScriptEntitiesFilterLabel.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left)
			Dim location3 As Point = New Point(8, 456)
			Me.ScriptEntitiesFilterLabel.Location = location3
			Me.ScriptEntitiesFilterLabel.Name = "ScriptEntitiesFilterLabel"
			Dim size3 As Size = New Size(80, 16)
			Me.ScriptEntitiesFilterLabel.Size = size3
			Me.ScriptEntitiesFilterLabel.TabIndex = 1
			Me.ScriptEntitiesFilterLabel.Text = "Filter"
			Me.ScriptEntitiesFilterBox.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left)
			Dim window2 As Color = SystemColors.Window
			Me.ScriptEntitiesFilterBox.BackColor = window2
			Dim location4 As Point = New Point(8, 472)
			Me.ScriptEntitiesFilterBox.Location = location4
			Me.ScriptEntitiesFilterBox.Name = "ScriptEntitiesFilterBox"
			Me.ScriptEntitiesFilterBox.ItemHeight = 14
			Me.ScriptEntitiesFilterBox.SelectedIndex = -1
			Dim size4 As Size = New Size(128, 214)
			Me.ScriptEntitiesFilterBox.Size = size4
			Me.ScriptEntitiesFilterBox.TabIndex = 15
			Me.ScriptEntitiesFilterBox.SelectionMode = SelectionMode.MultiExtended
			AddHandler Me.ScriptEntitiesFilterBox.SelectedIndexChanged, AddressOf Me.ScriptEntitiesFilterBox_SelectedIndexChanged
			Me.ScriptEntitiesLabel.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left)
			Dim location5 As Point = New Point(144, 456)
			Me.ScriptEntitiesLabel.Location = location5
			Me.ScriptEntitiesLabel.Name = "ScriptEntitiesLabel"
			Dim size5 As Size = New Size(104, 16)
			Me.ScriptEntitiesLabel.Size = size5
			Me.ScriptEntitiesLabel.TabIndex = 1
			Me.ScriptEntitiesLabel.Text = "Entities"
			Me.ScriptEntitiesControl.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim window3 As Color = SystemColors.Window
			Me.ScriptEntitiesControl.BackColor = window3
			Dim columnHeaders2 As Script_GlobalVariableControl_Header() = New Script_GlobalVariableControl_Header() { Me.SEN_Name, Me.SEN_Type, Me.SEN_Value, Me.SEN_Used }
			Me.ScriptEntitiesControl.ColumnHeaders = columnHeaders2
			Me.ScriptEntitiesControl.DrawGrid = True
			Me.ScriptEntitiesControl.HeaderHeight = 18
			Me.ScriptEntitiesControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
			Dim location6 As Point = New Point(144, 472)
			Me.ScriptEntitiesControl.Location = location6
			Me.ScriptEntitiesControl.Name = "ScriptEntitiesControl"
			Me.ScriptEntitiesControl.RealSelectedIndex = -1
			Me.ScriptEntitiesControl.RowHeight = 14
			Me.ScriptEntitiesControl.SelectedIndex = -1
			Dim size6 As Size = New Size(272, 230)
			Me.ScriptEntitiesControl.Size = size6
			Me.ScriptEntitiesControl.TabIndex = 15
			AddHandler Me.ScriptEntitiesControl.DragStarted, AddressOf Me.ScriptEntitiesControl_DragStarted
			Me.ScriptEntities_ShowStoredUnits.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left)
			Dim location7 As Point = New Point(8, 690)
			Me.ScriptEntities_ShowStoredUnits.Location = location7
			Me.ScriptEntities_ShowStoredUnits.Name = "ScriptEntities_ShowStoredUnits"
			Dim size7 As Size = New Size(128, 16)
			Me.ScriptEntities_ShowStoredUnits.Size = size7
			Me.ScriptEntities_ShowStoredUnits.TabIndex = 20
			Me.ScriptEntities_ShowStoredUnits.Text = "Stored units"
			Me.ScriptEntities_ShowStoredUnits.Checked = True
			AddHandler Me.ScriptEntities_ShowStoredUnits.CheckedChanged, AddressOf Me.ScriptEntities_ShowStoredUnits_CheckedChanged
			Me.SEN_Name.Text = "Name"
			Me.SEN_Name.Width = 160
			Me.SEN_Type.Text = "Type"
			Me.SEN_Type.Width = 32
			Me.SEN_Value.Text = "Value"
			Me.SEN_Value.Width = 38
			Me.SEN_Used.Text = "Used"
			Me.SEN_Used.Width = 42
			Me.GlobalVariablesLabel.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location8 As Point = New Point(428, 456)
			Me.GlobalVariablesLabel.Location = location8
			Me.GlobalVariablesLabel.Name = "GlobalVariablesLabel"
			Dim size8 As Size = New Size(104, 16)
			Me.GlobalVariablesLabel.Size = size8
			Me.GlobalVariablesLabel.TabIndex = 1
			Me.GlobalVariablesLabel.Text = "Global Variables"
			Me.GlobalVariableControl.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim window4 As Color = SystemColors.Window
			Me.GlobalVariableControl.BackColor = window4
			Dim columnHeaders3 As Script_GlobalVariableControl_Header() = New Script_GlobalVariableControl_Header() { Me.GLV_Name, Me.GLV_Type, Me.GLV_Value, Me.GLV_Used }
			Me.GlobalVariableControl.ColumnHeaders = columnHeaders3
			Me.GlobalVariableControl.ContextMenu = Me.GlobalVariables_ContextMenu
			Me.GlobalVariableControl.DrawGrid = True
			Me.GlobalVariableControl.HeaderHeight = 18
			Me.GlobalVariableControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
			Dim location9 As Point = New Point(428, 472)
			Me.GlobalVariableControl.Location = location9
			Me.GlobalVariableControl.Name = "GlobalVariableControl"
			Me.GlobalVariableControl.RealSelectedIndex = -1
			Me.GlobalVariableControl.RowHeight = 14
			Me.GlobalVariableControl.SelectedIndex = -1
			Dim size9 As Size = New Size(380, 106)
			Me.GlobalVariableControl.Size = size9
			Me.GlobalVariableControl.TabIndex = 5
			AddHandler Me.GlobalVariableControl.DragStarted, AddressOf Me.GlobalVariableControl_DragStarted
			AddHandler Me.GlobalVariableControl.ItemDoubleClicked, AddressOf Me.GlobalVariableControl_ItemDoubleClicked
			AddHandler Me.GlobalVariableControl.SelectedIndexChanged, AddressOf Me.GlobalVariableControl_SelectedIndexChanged
			Me.GLV_Name.Text = "Name"
			Me.GLV_Name.Width = 268
			Me.GLV_Type.Text = "Type"
			Me.GLV_Type.Width = 32
			Me.GLV_Value.Text = "Value"
			Me.GLV_Value.Width = 38
			Me.GLV_Used.Text = "Used"
			Me.GLV_Used.Width = 42
			Dim items5 As MenuItem() = New MenuItem() { Me.GlobalVariable_Create, Me.GlobalVariable_Delete, Me.menuItem7a, Me.GlobalVariable_MoveUp, Me.GlobalVariable_MoveDown, Me.GlobalVariable_FixOrder }
			Me.GlobalVariables_ContextMenu.MenuItems.AddRange(items5)
			Me.GlobalVariable_Create.Index = 0
			Me.GlobalVariable_Create.Shortcut = Shortcut.Ins
			Me.GlobalVariable_Create.Text = "Create variable"
			AddHandler Me.GlobalVariable_Create.Click, AddressOf Me.GlobalVariable_Create_Click
			Me.GlobalVariable_Delete.Index = 1
			Me.GlobalVariable_Delete.Shortcut = Shortcut.Del
			Me.GlobalVariable_Delete.Text = "Delete variable"
			AddHandler Me.GlobalVariable_Delete.Click, AddressOf Me.GlobalVariable_Delete_Click
			Me.menuItem7a.Index = 2
			Me.menuItem7a.Text = "-"
			Me.GlobalVariable_MoveUp.Enabled = False
			Me.GlobalVariable_MoveUp.Index = 3
			Me.GlobalVariable_MoveUp.Text = "Move Up"
			AddHandler Me.GlobalVariable_MoveUp.Click, AddressOf Me.GlobalVariable_MoveUp_Click
			Me.GlobalVariable_MoveDown.Enabled = False
			Me.GlobalVariable_MoveDown.Index = 4
			Me.GlobalVariable_MoveDown.Text = "Move Down"
			AddHandler Me.GlobalVariable_MoveDown.Click, AddressOf Me.GlobalVariable_MoveDown_Click
			Me.GlobalVariable_FixOrder.Index = 5
			Me.GlobalVariable_FixOrder.Text = "Fix order"
			AddHandler Me.GlobalVariable_FixOrder.Click, AddressOf Me.GlobalVariable_FixOrder_Click
			Me.TriggerGroup.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.TriggerGroup.Controls.Add(Me.InsertSingleOrConditionButton)
			Me.TriggerGroup.Controls.Add(Me.DeleteActionPartButton)
			Me.TriggerGroup.Controls.Add(Me.ConditionTypeBox)
			Me.TriggerGroup.Controls.Add(Me.ActionTypeBox)
			Me.TriggerGroup.Controls.Add(Me.NegateConditionButton)
			Me.TriggerGroup.Controls.Add(Me.DeleteConditionBlockButton)
			Me.TriggerGroup.Controls.Add(Me.DeleteActionBlockButton)
			Me.TriggerGroup.Controls.Add(Me.DeleteConditionButton)
			Me.TriggerGroup.Controls.Add(Me.AddConditionButton)
			Me.TriggerGroup.Controls.Add(Me.DeleteActionButton)
			Me.TriggerGroup.Controls.Add(Me.AddActionButton)
			Me.TriggerGroup.Controls.Add(Me.ConditionType_Label)
			Me.TriggerGroup.Controls.Add(Me.ActionType_Label)
			Me.TriggerGroup.Controls.Add(Me.ActionListTreeControl)
			Me.TriggerGroup.Controls.Add(Me.TriggerActionListLabel)
			Me.TriggerGroup.Controls.Add(Me.TriggerVariablesLabel)
			Me.TriggerGroup.Controls.Add(Me.TriggerVariableControl)
			Me.TriggerGroup.Controls.Add(Me.GlobalVariablesLabel)
			Me.TriggerGroup.Controls.Add(Me.GlobalVariableControl)
			Me.TriggerGroup.Controls.Add(Me.ScriptEntitiesLabel)
			Me.TriggerGroup.Controls.Add(Me.ScriptEntitiesControl)
			Me.TriggerGroup.Controls.Add(Me.ScriptEntities_ShowStoredUnits)
			Me.TriggerGroup.Controls.Add(Me.ScriptEntitiesFilterLabel)
			Me.TriggerGroup.Controls.Add(Me.ScriptEntitiesFilterBox)
			Dim location10 As Point = New Point(312, 8)
			Me.TriggerGroup.Location = location10
			Me.TriggerGroup.Name = "TriggerGroup"
			Dim size10 As Size = New Size(816, 712)
			Me.TriggerGroup.Size = size10
			Me.TriggerGroup.TabIndex = 7
			Me.TriggerGroup.TabStop = False
			Me.TriggerGroup.Text = "Trigger"
			Me.InsertSingleOrConditionButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location11 As Point = New Point(600, 416)
			Me.InsertSingleOrConditionButton.Location = location11
			Me.InsertSingleOrConditionButton.Name = "InsertSingleOrConditionButton"
			Dim size11 As Size = New Size(96, 23)
			Me.InsertSingleOrConditionButton.Size = size11
			Me.InsertSingleOrConditionButton.TabIndex = 31
			Me.InsertSingleOrConditionButton.Text = "InsertSingleOr"
			AddHandler Me.InsertSingleOrConditionButton.Click, AddressOf Me.InsertSingleOrConditionButton_Click
			Me.DeleteActionPartButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location12 As Point = New Point(496, 416)
			Me.DeleteActionPartButton.Location = location12
			Me.DeleteActionPartButton.Name = "DeleteActionPartButton"
			Dim size12 As Size = New Size(96, 23)
			Me.DeleteActionPartButton.Size = size12
			Me.DeleteActionPartButton.TabIndex = 30
			Me.DeleteActionPartButton.Text = "DeleteAPart"
			AddHandler Me.DeleteActionPartButton.Click, AddressOf Me.DeleteActionPartButton_Click
			Me.ConditionTypeBox.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location13 As Point = New Point(496, 32)
			Me.ConditionTypeBox.Location = location13
			Me.ConditionTypeBox.Name = "ConditionTypeBox"
			Dim size13 As Size = New Size(312, 352)
			Me.ConditionTypeBox.Size = size13
			Me.ConditionTypeBox.TabIndex = 29
			Me.ActionTypeBox.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location14 As Point = New Point(496, 32)
			Me.ActionTypeBox.Location = location14
			Me.ActionTypeBox.Name = "ActionTypeBox"
			Dim size14 As Size = New Size(312, 352)
			Me.ActionTypeBox.Size = size14
			Me.ActionTypeBox.TabIndex = 28
			Me.NegateConditionButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location15 As Point = New Point(496, 416)
			Me.NegateConditionButton.Location = location15
			Me.NegateConditionButton.Name = "NegateConditionButton"
			Dim size15 As Size = New Size(96, 23)
			Me.NegateConditionButton.Size = size15
			Me.NegateConditionButton.TabIndex = 20
			Me.NegateConditionButton.Text = "NegateCond."
			AddHandler Me.NegateConditionButton.Click, AddressOf Me.NegateConditionButton_Click
			Me.DeleteConditionBlockButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location16 As Point = New Point(704, 384)
			Me.DeleteConditionBlockButton.Location = location16
			Me.DeleteConditionBlockButton.Name = "DeleteConditionBlockButton"
			Dim size16 As Size = New Size(96, 23)
			Me.DeleteConditionBlockButton.Size = size16
			Me.DeleteConditionBlockButton.TabIndex = 19
			Me.DeleteConditionBlockButton.Text = "DeleteCBlock"
			AddHandler Me.DeleteConditionBlockButton.Click, AddressOf Me.DeleteConditionBlockButton_Click
			Me.DeleteActionBlockButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location17 As Point = New Point(704, 384)
			Me.DeleteActionBlockButton.Location = location17
			Me.DeleteActionBlockButton.Name = "DeleteActionBlockButton"
			Dim size17 As Size = New Size(96, 23)
			Me.DeleteActionBlockButton.Size = size17
			Me.DeleteActionBlockButton.TabIndex = 18
			Me.DeleteActionBlockButton.Text = "DeleteABlock"
			AddHandler Me.DeleteActionBlockButton.Click, AddressOf Me.DeletActionBlockButton_Click
			Me.DeleteConditionButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location18 As Point = New Point(600, 384)
			Me.DeleteConditionButton.Location = location18
			Me.DeleteConditionButton.Name = "DeleteConditionButton"
			Dim size18 As Size = New Size(96, 23)
			Me.DeleteConditionButton.Size = size18
			Me.DeleteConditionButton.TabIndex = 17
			Me.DeleteConditionButton.Text = "DeleteCondition"
			AddHandler Me.DeleteConditionButton.Click, AddressOf Me.DeleteConditionButton_Click
			Me.AddConditionButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location19 As Point = New Point(496, 384)
			Me.AddConditionButton.Location = location19
			Me.AddConditionButton.Name = "AddConditionButton"
			Dim size19 As Size = New Size(96, 23)
			Me.AddConditionButton.Size = size19
			Me.AddConditionButton.TabIndex = 16
			Me.AddConditionButton.Text = "AddCondition"
			AddHandler Me.AddConditionButton.Click, AddressOf Me.AddConditionButton_Click
			Me.DeleteActionButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location20 As Point = New Point(600, 384)
			Me.DeleteActionButton.Location = location20
			Me.DeleteActionButton.Name = "DeleteActionButton"
			Dim size20 As Size = New Size(96, 23)
			Me.DeleteActionButton.Size = size20
			Me.DeleteActionButton.TabIndex = 15
			Me.DeleteActionButton.Text = "DeleteAction"
			AddHandler Me.DeleteActionButton.Click, AddressOf Me.DeleteActionButton_Click
			Me.AddActionButton.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location21 As Point = New Point(496, 384)
			Me.AddActionButton.Location = location21
			Me.AddActionButton.Name = "AddActionButton"
			Dim size21 As Size = New Size(96, 23)
			Me.AddActionButton.Size = size21
			Me.AddActionButton.TabIndex = 14
			Me.AddActionButton.Text = "AddAction"
			AddHandler Me.AddActionButton.Click, AddressOf Me.AddActionButton_Click
			Me.ConditionType_Label.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Dim location22 As Point = New Point(496, 16)
			Me.ConditionType_Label.Location = location22
			Me.ConditionType_Label.Name = "ConditionType_Label"
			Dim size22 As Size = New Size(100, 16)
			Me.ConditionType_Label.Size = size22
			Me.ConditionType_Label.TabIndex = 13
			Me.ConditionType_Label.Text = "ConditionType"
			Me.ActionType_Label.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Dim location23 As Point = New Point(496, 16)
			Me.ActionType_Label.Location = location23
			Me.ActionType_Label.Name = "ActionType_Label"
			Dim size23 As Size = New Size(100, 16)
			Me.ActionType_Label.Size = size23
			Me.ActionType_Label.TabIndex = 11
			Me.ActionType_Label.Text = "ActionType"
			Me.ActionListTreeControl.AllowDrop = True
			Me.ActionListTreeControl.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim window5 As Color = SystemColors.Window
			Me.ActionListTreeControl.BackColor = window5
			Me.ActionListTreeControl.ContextMenu = Me.ActionList_ContextMenu
			Dim location24 As Point = New Point(8, 32)
			Me.ActionListTreeControl.Location = location24
			Me.ActionListTreeControl.Name = "ActionListTreeControl"
			Dim size24 As Size = New Size(480, 412)
			Me.ActionListTreeControl.Size = size24
			Me.ActionListTreeControl.TabIndex = 9
			AddHandler Me.ActionListTreeControl.ListSelectingFinished, AddressOf Me.ActionListTreeControl_ListSelectingFinished
			AddHandler Me.ActionListTreeControl.MouseTargetOnDrop, AddressOf Me.ActionListTreeControl_MouseTargetOnDrop
			AddHandler Me.ActionListTreeControl.TextEditingRequest, AddressOf Me.ActionListTreeControl_TextEditingRequest
			AddHandler Me.ActionListTreeControl.TextEditingFinished, AddressOf Me.ActionListTreeControl_TextEditingFinished
			AddHandler Me.ActionListTreeControl.ExpandChanged, AddressOf Me.ActionListTreeControl_ExpandChanged
			AddHandler Me.ActionListTreeControl.MouseTargetChanged, AddressOf Me.ActionListTreeControl_MouseTargetChanged
			AddHandler Me.ActionListTreeControl.MouseTargetDoubleClicked, AddressOf Me.ActionListTreeControl_MouseTargetDoubleClicked
			AddHandler Me.ActionListTreeControl.DragEnter, AddressOf Me.ActionListTreeControl_DragEnter
			AddHandler Me.ActionListTreeControl.SelectionChanged, AddressOf Me.ActionListTreeControl_SelectionChanged
			Dim items6 As MenuItem() = New MenuItem() { Me.Actions_Insert, Me.Actions_Delete }
			Me.ActionList_ContextMenu.MenuItems.AddRange(items6)
			Me.Actions_Insert.Index = 0
			Me.Actions_Insert.Shortcut = Shortcut.Ins
			Me.Actions_Insert.Text = "Insert"
			AddHandler Me.Actions_Insert.Click, AddressOf Me.Actions_Insert_Click
			Me.Actions_Delete.Index = 1
			Me.Actions_Delete.Shortcut = Shortcut.Del
			Me.Actions_Delete.Text = "Delete"
			AddHandler Me.Actions_Delete.Click, AddressOf Me.Actions_Delete_Click
			Dim location25 As Point = New Point(8, 16)
			Me.TriggerActionListLabel.Location = location25
			Me.TriggerActionListLabel.Name = "TriggerActionListLabel"
			Dim size25 As Size = New Size(100, 16)
			Me.TriggerActionListLabel.Size = size25
			Me.TriggerActionListLabel.TabIndex = 2
			Me.TriggerActionListLabel.Text = "ActionList"
			Me.TriggerVariablesLabel.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location26 As Point = New Point(428, 587)
			Me.TriggerVariablesLabel.Location = location26
			Me.TriggerVariablesLabel.Name = "TriggerVariablesLabel"
			Dim size26 As Size = New Size(100, 16)
			Me.TriggerVariablesLabel.Size = size26
			Me.TriggerVariablesLabel.TabIndex = 0
			Me.TriggerVariablesLabel.Text = "Trigger Variables"
			Me.TriggerVariableControl.AllowDrop = True
			Me.TriggerVariableControl.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim window6 As Color = SystemColors.Window
			Me.TriggerVariableControl.BackColor = window6
			Dim columnHeaders4 As Script_GlobalVariableControl_Header() = New Script_GlobalVariableControl_Header() { Me.TV_Name, Me.TV_Type, Me.TV_Value, Me.TV_Used }
			Me.TriggerVariableControl.ColumnHeaders = columnHeaders4
			Me.TriggerVariableControl.ContextMenu = Me.TriggerVariables_ContextMenu
			Me.TriggerVariableControl.DrawGrid = True
			Me.TriggerVariableControl.HeaderHeight = 18
			Me.TriggerVariableControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
			Dim location27 As Point = New Point(428, 604)
			Me.TriggerVariableControl.Location = location27
			Me.TriggerVariableControl.Name = "TriggerVariableControl"
			Me.TriggerVariableControl.RealSelectedIndex = -1
			Me.TriggerVariableControl.RowHeight = 14
			Me.TriggerVariableControl.SelectedIndex = -1
			Dim size27 As Size = New Size(380, 99)
			Me.TriggerVariableControl.Size = size27
			Me.TriggerVariableControl.TabIndex = 6
			AddHandler Me.TriggerVariableControl.DragStarted, AddressOf Me.TriggerVariableControl_DragStarted
			AddHandler Me.TriggerVariableControl.SortModeChanged, AddressOf Me.TriggerVariableControl_SortModeChanged
			AddHandler Me.TriggerVariableControl.ItemDoubleClicked, AddressOf Me.TriggerVariableControl_ItemDoubleClicked
			AddHandler Me.TriggerVariableControl.SelectedIndexChanged, AddressOf Me.TriggerVariableControl_SelectedIndexChanged
			Me.TV_Name.Text = "Name"
			Me.TV_Name.Width = 268
			Me.TV_Type.Text = "Type"
			Me.TV_Type.Width = 32
			Me.TV_Value.Text = "Value"
			Me.TV_Value.Width = 38
			Me.TV_Used.Text = "Used"
			Me.TV_Used.Width = 42
			Dim items7 As MenuItem() = New MenuItem() { Me.TriggerVariable_Create, Me.TriggerVariable_Delete, Me.menuItem7, Me.TriggerVariable_MoveUp, Me.TriggerVariable_MoveDown, Me.TriggerVariable_FixOrder }
			Me.TriggerVariables_ContextMenu.MenuItems.AddRange(items7)
			Me.TriggerVariable_Create.Index = 0
			Me.TriggerVariable_Create.Shortcut = Shortcut.Ins
			Me.TriggerVariable_Create.Text = "Create variable"
			AddHandler Me.TriggerVariable_Create.Click, AddressOf Me.TriggerVariable_Create_Click
			Me.TriggerVariable_Delete.Index = 1
			Me.TriggerVariable_Delete.Shortcut = Shortcut.Del
			Me.TriggerVariable_Delete.Text = "Delete variable"
			AddHandler Me.TriggerVariable_Delete.Click, AddressOf Me.TriggerVariable_Delete_Click
			Me.menuItem7.Index = 2
			Me.menuItem7.Text = "-"
			Me.TriggerVariable_MoveUp.Enabled = False
			Me.TriggerVariable_MoveUp.Index = 3
			Me.TriggerVariable_MoveUp.Text = "Move Up"
			AddHandler Me.TriggerVariable_MoveUp.Click, AddressOf Me.TriggerVariable_MoveUp_Click
			Me.TriggerVariable_MoveDown.Enabled = False
			Me.TriggerVariable_MoveDown.Index = 4
			Me.TriggerVariable_MoveDown.Text = "Move Down"
			AddHandler Me.TriggerVariable_MoveDown.Click, AddressOf Me.TriggerVariable_MoveDown_Click
			Me.TriggerVariable_FixOrder.Index = 5
			Me.TriggerVariable_FixOrder.Text = "Fix order"
			AddHandler Me.TriggerVariable_FixOrder.Click, AddressOf Me.TriggerVariable_FixOrder_Click
			Me.StatusLine.AcceptsReturn = True
			Me.StatusLine.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim location28 As Point = New Point(8, 726)
			Me.StatusLine.Location = location28
			Me.StatusLine.Multiline = True
			Me.StatusLine.Name = "StatusLine"
			Me.StatusLine.[ReadOnly] = True
			Dim size28 As Size = New Size(1120, 38)
			Me.StatusLine.Size = size28
			Me.StatusLine.TabIndex = 8
			Me.StatusLine.TabStop = False
			Me.StatusLine.Text = ""
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(1144, 773)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.StatusLine)
			MyBase.Controls.Add(Me.TriggerGroup)
			MyBase.Controls.Add(Me.GlobalGroupBox)
			MyBase.Menu = Me.MainMenu
			MyBase.Name = "ScriptEditorForm"
			Me.RightToLeft = RightToLeft.No
			Me.Text = "Script editor"
			AddHandler MyBase.Load, AddressOf Me.ScriptEditorForm_Load
			AddHandler MyBase.Deactivate, AddressOf Me.ScriptEditorForm_Deactivate
			Me.GlobalGroupBox.ResumeLayout(False)
			Me.TriggerGroup.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub ScriptEditorForm_Load(sender As Object, e As EventArgs)
			Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
			Me.SelectedTriggerIndex = -1
			Dim ptr As __Pointer(Of UInteger) = CType((AddressOf <Module>.ScriptEditor.ValueTypeList_Filter), __Pointer(Of UInteger))
			If <Module>.ScriptEditor.ValueTypeList_Filter <> 32 Then
				Do
					ptr += 4 / __SizeOf(UInteger)
				Loop While __Dereference(CType(ptr, __Pointer(Of Integer))) <> 32
			End If
			Dim num As Integer = ptr - <Module>.ScriptEditor.ValueTypeList_Filter / __SizeOf(UInteger) >> 2
			If __Dereference(CType(ptr, __Pointer(Of Integer))) <> 41 Then
				Do
					ptr += 4 / __SizeOf(UInteger)
				Loop While __Dereference(CType(ptr, __Pointer(Of Integer))) <> 41
			End If
			Dim num2 As Integer = ptr - <Module>.ScriptEditor.ValueTypeList_Filter / __SizeOf(UInteger) >> 2
			Dim ptr2 As __Pointer(Of $ArrayType$$$BY0CJ@H) = AddressOf <Module>.ScriptEditor.EntityTypeIndices
			Do
				__Dereference(CType(ptr2, __Pointer(Of Integer))) = -1
				ptr2 += 4 / __SizeOf($ArrayType$$$BY0CJ@H)
			Loop While ptr2 < <Module>.ScriptEditor.EntityTypeIndices + 164
			Dim array As Object() = New Object(num2 - 1) {}
			Dim ptr3 As __Pointer(Of UInteger) = CType((AddressOf <Module>.ScriptEditor.ValueTypeList_Filter), __Pointer(Of UInteger))
			Dim num3 As Integer = 0
			If 0 < num Then
				Do
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetValueTypeAsString(AddressOf gBaseString<char>, __Dereference(CType(ptr3, __Pointer(Of Integer))))
					Try
						Dim num4 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
						Dim value As __Pointer(Of SByte)
						If num4 <> 0UI Then
							value = num4
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						array(num3) = New String(CType(value, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
						gBaseString<char> = 0
					End If
					__Dereference((__Dereference(CType(ptr3, __Pointer(Of Integer))) * 4 + <Module>.ScriptEditor.EntityTypeIndices)) = num3
					num3 += 1
					ptr3 += 4 / __SizeOf(UInteger)
				Loop While num3 < num
			End If
			Dim num5 As Integer = num
			If num < num2 Then
				Do
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetExtraFilterAsString(AddressOf gBaseString<char>2, __Dereference(CType(ptr3, __Pointer(Of Integer))))
					Try
						Dim num6 As UInteger = CUInt((__Dereference(CType(ptr5, __Pointer(Of Integer)))))
						Dim value2 As __Pointer(Of SByte)
						If num6 <> 0UI Then
							value2 = num6
						Else
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						array(num5) = New String(CType(value2, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
						gBaseString<char>2 = 0
					End If
					__Dereference((__Dereference(CType(ptr3, __Pointer(Of Integer))) * 4 + <Module>.ScriptEditor.EntityTypeIndices)) = num5
					num5 += 1
					ptr3 += 4 / __SizeOf(UInteger)
				Loop While num5 < num2
			End If
			Me.ScriptEntitiesFilterBox.Items.Clear()
			Me.ScriptEntitiesFilterBox.Items.AddRange(array)
			Dim num7 As Integer = 0
			If 0 < num2 Then
				Do
					Me.ScriptEntitiesFilterBox.SetSelected(num7, True)
					num7 += 1
				Loop While num7 < num2
			End If
			Dim ptr6 As __Pointer(Of Integer) = CType((AddressOf <Module>.ScriptEditor.ActionTypeList), __Pointer(Of Integer))
			If <Module>.ScriptEditor.ActionTypeList <> 168 Then
				Do
					ptr6 += 4 / __SizeOf(Integer)
				Loop While __Dereference(CType(ptr6, __Pointer(Of Integer))) <> 168
			End If
			Dim num8 As Integer = ptr6 - <Module>.ScriptEditor.ActionTypeList / __SizeOf(Integer) >> 2
			Dim array2 As Object() = New Object(num8 - 1) {}
			Dim ptr7 As __Pointer(Of Integer) = CType((AddressOf <Module>.ScriptEditor.ActionTypeList), __Pointer(Of Integer))
			Dim num9 As Integer = 0
			If 0 < num8 Then
				Do
					Dim gBaseString<char>3 As GBaseString<char>
					Dim ptr8 As __Pointer(Of GBaseString<char>) = <Module>.?GetActionTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eAction_Type@Script@@@Z(AddressOf gBaseString<char>3, __Dereference(CType(ptr7, __Pointer(Of Integer))))
					Try
						Dim num10 As UInteger = CUInt((__Dereference(CType(ptr8, __Pointer(Of Integer)))))
						Dim value3 As __Pointer(Of SByte)
						If num10 <> 0UI Then
							value3 = num10
						Else
							value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						array2(num9) = New String(CType(value3, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>3 IsNot Nothing Then
						<Module>.free(gBaseString<char>3)
						gBaseString<char>3 = 0
					End If
					num9 += 1
					ptr7 += 4 / __SizeOf(Integer)
				Loop While num9 < num8
			End If
			Me.ActionTypeBox.Items.Clear()
			Me.ActionTypeBox.Items.AddRange(array2)
			Me.ActionTypeBox.SelectedIndex = 0
			Dim ptr9 As __Pointer(Of Integer) = CType((AddressOf <Module>.ScriptEditor.ConditionTypeList), __Pointer(Of Integer))
			If <Module>.ScriptEditor.ConditionTypeList <> 26 Then
				Do
					ptr9 += 4 / __SizeOf(Integer)
				Loop While __Dereference(CType(ptr9, __Pointer(Of Integer))) <> 26
			End If
			Dim num11 As Integer = ptr9 - <Module>.ScriptEditor.ConditionTypeList / __SizeOf(Integer) >> 2
			Dim array3 As Object() = New Object(num11 - 1) {}
			Dim ptr10 As __Pointer(Of Integer) = CType((AddressOf <Module>.ScriptEditor.ConditionTypeList), __Pointer(Of Integer))
			Dim num12 As Integer = 0
			If 0 < num11 Then
				Do
					Dim gBaseString<char>4 As GBaseString<char>
					Dim ptr11 As __Pointer(Of GBaseString<char>) = <Module>.?GetConditionTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eCondition_Type@Script@@_N@Z(AddressOf gBaseString<char>4, __Dereference(CType(ptr10, __Pointer(Of Integer))), 0)
					Try
						Dim num13 As UInteger = CUInt((__Dereference(CType(ptr11, __Pointer(Of Integer)))))
						Dim value4 As __Pointer(Of SByte)
						If num13 <> 0UI Then
							value4 = num13
						Else
							value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						array3(num12) = New String(CType(value4, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>4 IsNot Nothing Then
						<Module>.free(gBaseString<char>4)
						gBaseString<char>4 = 0
					End If
					num12 += 1
					ptr10 += 4 / __SizeOf(Integer)
				Loop While num12 < num11
			End If
			Me.ConditionTypeBox.Items.Clear()
			Me.ConditionTypeBox.Items.AddRange(array3)
			Me.ConditionTypeBox.SelectedIndex = 0
			Dim ptr12 As __Pointer(Of GStreamBuffer) = <Module>.new(36UI)
			Dim clipboardStream As __Pointer(Of GStreamBuffer)
			Try
				If ptr12 IsNot Nothing Then
					clipboardStream = <Module>.GStreamBuffer.{ctor}(ptr12)
				Else
					clipboardStream = 0
				End If
			Catch 
				<Module>.delete(CType(ptr12, __Pointer(Of Void)))
				Throw
			End Try
			Me.ClipboardStream = clipboardStream
			Me.ScriptIndex = -1
			Me.RefreshScriptList()
			Me.ChangeScript(0)
			Me.Edit_Copy.Enabled = True
			Me.Edit_Cut.Enabled = True
			Me.Edit_Paste.Enabled = False
			Me.Edit_Clear.Enabled = True
		End Sub

		Private Sub RefreshScriptList()
			Me.MainMenu_Scripts.MenuItems.Clear()
			Dim num As Integer = __Dereference(CType((<Module>.SafeWorld + 4084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
			Dim array As MenuItem() = New MenuItem(num - 1) {}
			Dim num2 As Integer = 0
			If 0 < num Then
				Do
					array(num2) = New MenuItem()
					array(num2).Index = num2
					Dim num3 As Integer = num2 + 1
					array(num2).Text = String.Format(New String(CType((AddressOf <Module>.??_C@_0M@MABEAKPP@?$HL0?$HN?4?5script?$AA@), __Pointer(Of SByte))), num3)
					AddHandler array(num2).Click, AddressOf Me.MainMenu_Scripts_Click
					If num2 < 10 Then
						array(num2).Shortcut = num2 + Shortcut.Ctrl1
					Else If num2 = 10 Then
						array(10).Shortcut = Shortcut.Ctrl0
					End If
					num2 = num3
				Loop While num2 < __Dereference(CType((<Module>.SafeWorld + 4084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
			End If
			Me.MainMenu_Scripts.MenuItems.AddRange(array)
		End Sub

		Private Sub ChangeScript(index As Integer)
			Dim scriptIndex As Integer = Me.ScriptIndex
			If index <> scriptIndex Then
				If scriptIndex <> -1 Then
					Me.MainMenu_Scripts.MenuItems(scriptIndex).Checked = False
					Me.SaveScript()
				End If
				Me.ScriptIndex = index
				Me.Editor = Me.GetEditor(index)
				Me.MainMenu_Scripts.MenuItems(Me.ScriptIndex).Checked = True
				Me.RefreshAll()
			End If
		End Sub

		Private Sub SaveScript()
			<Module>.ScriptEditor.cManager.SaveEditor(<Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld), Me.ScriptIndex)
		End Sub

		Private Function FilterEntity(value As __Pointer(Of sValue), scriptID As __Pointer(Of GBaseString<char>)) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim num As Integer = __Dereference(value)
			Dim index As Integer
			If num = 3 Then
				Dim ptr As __Pointer(Of GWUnit) = <Module>.GWorld.FindWUnitByScriptID(<Module>.SafeWorld, scriptID)
				If ptr Is Nothing Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0BO@JEMOOMIB@?4?2script?2ScriptEditorForm?4cpp?$AA@), __Pointer(Of SByte)), 300, CType((AddressOf <Module>.??_C@_0DD@LOOMFEIB@ScriptEditorWindow?3?3ScriptEditor@), __Pointer(Of SByte)))
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>, CType((AddressOf <Module>.??_C@_0CD@OMJMMENC@Unit?5?$CFs?5not?5removed?5from?5scripte@), __Pointer(Of SByte)), __Dereference(scriptID))
					Try
						Dim num2 As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
						<Module>.GLogger.Warning(If((num2 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num2))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
					Return True
				End If
				Dim checked As Boolean = Me.ScriptEntities_ShowStoredUnits.Checked
				If __Dereference(CType((ptr + 72 / __SizeOf(GWUnit)), __Pointer(Of Byte))) <> 0 AndAlso Not checked Then
					Return True
				End If
				Dim num3 As Integer = __Dereference(CType((ptr + 36 / __SizeOf(GWUnit)), __Pointer(Of Integer)))
				If num3 >= 0 Then
					index = __Dereference((__Dereference(CType((<Module>.SafeWorld + num3 * 160 / __SizeOf(GEditorWorld) + 300 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) * 4 + (<Module>.ScriptEditor.EntityTypeIndices + 144)))
				Else
					index = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 144))
				End If
				If Not Me.ScriptEntitiesFilterBox.GetSelected(index) Then
					Return True
				End If
				If <Module>.GWUnit.IsBuilding(ptr) IsNot Nothing Then
					index = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 136))
				Else If <Module>.GWUnit.IsVehicle(ptr) IsNot Nothing Then
					index = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 132))
				Else If <Module>.GWUnit.IsInfantry(ptr) IsNot Nothing Then
					index = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 128))
				Else
					index = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 140))
				End If
			Else
				index = __Dereference((num * 4 + <Module>.ScriptEditor.EntityTypeIndices))
			End If
			Return Not Me.ScriptEntitiesFilterBox.GetSelected(index)
		End Function

		Private Sub RefreshAll()
			Me.RefreshScriptEntities()
			Me.RefreshGlobalVariables()
			Me.RefreshTriggers()
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			If __Dereference(CType((editor + 32 / __SizeOf(cEditor)), __Pointer(Of Integer))) <> 0 Then
				Me.RefreshTriggerData(__Dereference((Me.GlobalTriggerControl.SelectedIndex * 4 + __Dereference(CType((editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer))))), 0)
			End If
			Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
			Me.Edit_Undo.Enabled = (CByte(num) <> 0)
			Dim editor2 As __Pointer(Of cEditor) = Me.Editor
			Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
			Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
		End Sub

		Private Sub RefreshScriptEntities()
			If Me.Editor IsNot Nothing Then
				Dim index As Integer = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 128))
				Me.ScriptEntities_ShowStoredUnits.Enabled = Me.ScriptEntitiesFilterBox.GetSelected(index)
				Dim index2 As Integer = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 132))
				Dim enabled As Byte
				If Not Me.ScriptEntities_ShowStoredUnits.Enabled AndAlso Not Me.ScriptEntitiesFilterBox.GetSelected(index2) Then
					enabled = 0
				Else
					enabled = 1
				End If
				Me.ScriptEntities_ShowStoredUnits.Enabled = (enabled <> 0)
				Dim index3 As Integer = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 136))
				Dim enabled2 As Byte
				If Not Me.ScriptEntities_ShowStoredUnits.Enabled AndAlso Not Me.ScriptEntitiesFilterBox.GetSelected(index3) Then
					enabled2 = 0
				Else
					enabled2 = 1
				End If
				Me.ScriptEntities_ShowStoredUnits.Enabled = (enabled2 <> 0)
				Dim num As Integer = 0
				Dim num2 As Integer = 0
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num3 As Integer = __Dereference((editor + 48))
				If 0 < num3 Then
					Do
						Dim editor2 As __Pointer(Of cEditor) = Me.Editor
						Dim ptr As __Pointer(Of cVariable) = __Dereference((num2 * 4 + __Dereference((editor2 + 44))))
						Dim value As __Pointer(Of sValue) = ptr + 16
						If Not Me.FilterEntity(value, <Module>.ScriptEditor.cVariable.GetName(ptr)) Then
							num += 1
						End If
						num2 += 1
						editor = Me.Editor
						num3 = __Dereference((editor + 48))
					Loop While num2 < num3
				End If
				Me.ScriptEntities_List = New Integer(num - 1) {}
				If num = 0 Then
					Me.ScriptEntitiesControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
				Else
					Dim array As Script_GlobalVariableControl_ListItem() = New Script_GlobalVariableControl_ListItem(num - 1) {}
					Dim num4 As Integer = 0
					Dim num5 As Integer = 0
					Dim num6 As Integer = __Dereference(CType((Me.Editor + 48 / __SizeOf(cEditor)), __Pointer(Of Integer)))
					If 0 < num6 Then
						Do
							Dim editor3 As __Pointer(Of cEditor) = Me.Editor
							Dim ptr2 As __Pointer(Of cVariable) = __Dereference((num5 * 4 + __Dereference((editor3 + 44))))
							Dim value2 As __Pointer(Of sValue) = ptr2 + 16
							If Not Me.FilterEntity(value2, <Module>.ScriptEditor.cVariable.GetName(ptr2)) Then
								Dim array2 As Script_GlobalVariableControl_ListSubItem() = New Script_GlobalVariableControl_ListSubItem(3) {}
								array2(0) = New Script_GlobalVariableControl_ListSubItem()
								Dim num7 As UInteger = CUInt((__Dereference(<Module>.ScriptEditor.cVariable.GetName(ptr2))))
								Dim value3 As __Pointer(Of SByte)
								If num7 <> 0UI Then
									value3 = num7
								Else
									value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								array2(0).Text = New String(CType(value3, __Pointer(Of SByte)))
								array2(1) = New Script_GlobalVariableControl_ListSubItem()
								Dim gBaseString<char> As GBaseString<char>
								Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(AddressOf gBaseString<char>, __Dereference((ptr2 + 16)), 0)
								Try
									Dim num8 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
									Dim value4 As __Pointer(Of SByte)
									If num8 <> 0UI Then
										value4 = num8
									Else
										value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									array2(1).Text = New String(CType(value4, __Pointer(Of SByte)))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
									Throw
								End Try
								If gBaseString<char> IsNot Nothing Then
									<Module>.free(gBaseString<char>)
									gBaseString<char> = 0
								End If
								array2(2) = New Script_GlobalVariableControl_ListSubItem()
								Dim gBaseString<char>2 As GBaseString<char>
								Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.sValue.GetAsString(ptr2 + 16, AddressOf gBaseString<char>2, Me.Editor)
								Try
									Dim num9 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
									Dim value5 As __Pointer(Of SByte)
									If num9 <> 0UI Then
										value5 = num9
									Else
										value5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									array2(2).Text = New String(CType(value5, __Pointer(Of SByte)))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
									Throw
								End Try
								If gBaseString<char>2 IsNot Nothing Then
									<Module>.free(gBaseString<char>2)
									gBaseString<char>2 = 0
								End If
								array2(3) = New Script_GlobalVariableControl_ListSubItem()
								Dim num10 As Integer = __Dereference((ptr2 + 32))
								Dim text As String
								If num10 > 0 Then
									Dim num11 As Integer = num10
									text = String.Format(New String(CType((AddressOf <Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@), __Pointer(Of SByte))), num11)
								Else
									text = New String(CType((AddressOf <Module>.??_C@_02KAJCLHKP@no?$AA@), __Pointer(Of SByte)))
								End If
								array2(3).Text = text
								Me.ScriptEntities_List(num4) = num5
								array(num4) = New Script_GlobalVariableControl_ListItem()
								Dim arg_2E8_0 As Script_GlobalVariableControl_ListItem = array(num4)
								num4 += 1
								arg_2E8_0.SubItems = array2
							End If
							num5 += 1
						Loop While num5 < __Dereference(CType((Me.Editor + 48 / __SizeOf(cEditor)), __Pointer(Of Integer)))
					End If
					Me.ScriptEntitiesControl.Items = array
				End If
			End If
		End Sub

		Private Sub RefreshGlobalVariables()
			Me.GlobalVariable_Create.Enabled = True
			Dim num As Integer = __Dereference(CType((Me.Editor + 16 / __SizeOf(cEditor)), __Pointer(Of Integer)))
			Me.GlobalVariable_Create.Enabled = True
			If num = 0 Then
				Me.GlobalVariableControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
				Me.GlobalVariable_Delete.Enabled = False
				Me.GlobalVariable_FixOrder.Enabled = False
				Me.GlobalVariable_MoveDown.Enabled = False
				Me.GlobalVariable_MoveUp.Enabled = False
			Else
				Dim array As Script_GlobalVariableControl_ListItem() = New Script_GlobalVariableControl_ListItem(num - 1) {}
				Dim num2 As Integer = 0
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num3 As Integer = __Dereference(CType((editor + 16 / __SizeOf(cEditor)), __Pointer(Of Integer)))
				If 0 < num3 Then
					Do
						Dim ptr As __Pointer(Of cEditor) = editor
						Dim ptr2 As __Pointer(Of cVariable) = __Dereference((num2 * 4 + __Dereference((ptr + 12))))
						Dim array2 As Script_GlobalVariableControl_ListSubItem() = New Script_GlobalVariableControl_ListSubItem(3) {}
						array2(0) = New Script_GlobalVariableControl_ListSubItem()
						Dim num4 As UInteger = CUInt((__Dereference(<Module>.ScriptEditor.cVariable.GetName(ptr2))))
						Dim value As __Pointer(Of SByte)
						If num4 <> 0UI Then
							value = num4
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						array2(0).Text = New String(CType(value, __Pointer(Of SByte)))
						array2(1) = New Script_GlobalVariableControl_ListSubItem()
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(AddressOf gBaseString<char>, __Dereference((ptr2 + 16)), 0)
						Try
							Dim num5 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
							Dim value2 As __Pointer(Of SByte)
							If num5 <> 0UI Then
								value2 = num5
							Else
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							array2(1).Text = New String(CType(value2, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
						array2(2) = New Script_GlobalVariableControl_ListSubItem()
						Dim gBaseString<char>2 As GBaseString<char>
						Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.sValue.GetAsString(ptr2 + 16, AddressOf gBaseString<char>2, Me.Editor)
						Try
							Dim num6 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
							Dim value3 As __Pointer(Of SByte)
							If num6 <> 0UI Then
								value3 = num6
							Else
								value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							array2(2).Text = New String(CType(value3, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
							gBaseString<char>2 = 0
						End If
						array2(3) = New Script_GlobalVariableControl_ListSubItem()
						Dim num7 As Integer = __Dereference((ptr2 + 32))
						Dim text As String
						If num7 > 0 Then
							Dim num8 As Integer = num7
							text = String.Format(New String(CType((AddressOf <Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@), __Pointer(Of SByte))), num8)
						Else
							text = New String(CType((AddressOf <Module>.??_C@_02KAJCLHKP@no?$AA@), __Pointer(Of SByte)))
						End If
						array2(3).Text = text
						array(num2) = New Script_GlobalVariableControl_ListItem()
						Dim arg_1EE_0 As Script_GlobalVariableControl_ListItem = array(num2)
						num2 += 1
						arg_1EE_0.SubItems = array2
						editor = Me.Editor
					Loop While num2 < __Dereference(CType((editor + 16 / __SizeOf(cEditor)), __Pointer(Of Integer)))
				End If
				Me.GlobalVariableControl.Items = array
				Me.GlobalVariable_Delete.Enabled = True
				Dim globalVariableControl As Script_GlobalVariableControl = Me.GlobalVariableControl
				If globalVariableControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((globalVariableControl.SelectedIndex + 1 < __Dereference(CType((Me.Editor + 16 / __SizeOf(cEditor)), __Pointer(Of Integer)))), 1, 0)
					Me.GlobalVariable_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.GlobalVariableControl.SelectedIndex > 0), 1, 0)
					Me.GlobalVariable_MoveUp.Enabled = (enabled2 <> 0)
					Me.GlobalVariable_FixOrder.Enabled = False
				Else
					Me.GlobalVariable_MoveDown.Enabled = False
					Me.GlobalVariable_MoveUp.Enabled = False
					Me.GlobalVariable_FixOrder.Enabled = True
				End If
			End If
		End Sub

		Private Sub RefreshTriggers()
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			If __Dereference(CType((editor + 32 / __SizeOf(cEditor)), __Pointer(Of Integer))) = 0 Then
				Me.GlobalTriggerControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
				Me.RefreshTriggerData(Nothing, 0)
				Me.Trigger_MoveDown.Enabled = False
				Me.Trigger_MoveUp.Enabled = False
				Me.Trigger_FixOrder.Enabled = False
				Me.Trigger_Delete.Enabled = False
			Else
				Dim array As Script_GlobalVariableControl_ListItem() = New Script_GlobalVariableControl_ListItem(__Dereference(CType((editor + 32 / __SizeOf(cEditor)), __Pointer(Of Integer))) - 1) {}
				Dim num As Integer = 0
				Dim num2 As Integer = __Dereference(CType((editor + 32 / __SizeOf(cEditor)), __Pointer(Of Integer)))
				If 0 < num2 Then
					Do
						Dim ptr As __Pointer(Of cEditor) = editor
						Dim ptr2 As __Pointer(Of cTrigger) = __Dereference((num * 4 + __Dereference((ptr + 28))))
						Dim array2 As Script_GlobalVariableControl_ListSubItem() = New Script_GlobalVariableControl_ListSubItem(2) {}
						array2(0) = New Script_GlobalVariableControl_ListSubItem()
						Dim num3 As UInteger = CUInt((__Dereference((ptr2 + 8))))
						Dim value As __Pointer(Of SByte)
						If num3 <> 0UI Then
							value = num3
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						array2(0).Text = New String(CType(value, __Pointer(Of SByte)))
						array2(1) = New Script_GlobalVariableControl_ListSubItem()
						Dim num4 As Integer = __Dereference((ptr2 + 16))
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.?GetEventTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eEvent_Type@Script@@@Z(AddressOf gBaseString<char>, num4)
						Try
							Dim num5 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
							Dim value2 As __Pointer(Of SByte)
							If num5 <> 0UI Then
								value2 = num5
							Else
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							array2(1).Text = New String(CType(value2, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
						array2(2) = New Script_GlobalVariableControl_ListSubItem()
						Dim text As String
						If __Dereference((ptr2 + 48)) <> 0 Then
							text = "yes"
						Else
							text = New String(CType((AddressOf <Module>.??_C@_02KAJCLHKP@no?$AA@), __Pointer(Of SByte)))
						End If
						array2(2).Text = text
						array(num) = New Script_GlobalVariableControl_ListItem()
						array(num).SubItems = array2
						num += 1
						editor = Me.Editor
					Loop While num < __Dereference(CType((editor + 32 / __SizeOf(cEditor)), __Pointer(Of Integer)))
				End If
				Me.GlobalTriggerControl.Items = array
				If Me.GlobalTriggerControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((Me.SelectedTriggerIndex + 1 < __Dereference(CType((Me.Editor + 32 / __SizeOf(cEditor)), __Pointer(Of Integer)))), 1, 0)
					Me.Trigger_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.SelectedTriggerIndex > 0), 1, 0)
					Me.Trigger_MoveUp.Enabled = (enabled2 <> 0)
					Me.Trigger_FixOrder.Enabled = False
				Else
					Me.Trigger_MoveDown.Enabled = False
					Me.Trigger_MoveUp.Enabled = False
					Me.Trigger_FixOrder.Enabled = True
				End If
				Me.Trigger_Delete.Enabled = True
			End If
		End Sub

		Private Sub RefreshTriggerData(trigger As __Pointer(Of cTrigger), treeselchange As Integer)
			If trigger Is Nothing Then
				Me.ActionListTreeControl.RootNode.Clear()
				Me.ActionListTreeControl.Enabled = False
				Me.ActionListTreeControl.Dirty(True)
				Me.ActionType_Label.Hide()
				Me.AddActionButton.Hide()
				Me.DeleteActionButton.Hide()
				Me.DeleteActionBlockButton.Hide()
				Me.DeleteActionPartButton.Hide()
				Me.ConditionType_Label.Hide()
				Me.AddConditionButton.Hide()
				Me.DeleteConditionButton.Hide()
				Me.DeleteConditionBlockButton.Hide()
				Me.ActionTypeBox.Hide()
				Me.ConditionTypeBox.Hide()
				Me.NegateConditionButton.Hide()
				Me.InsertSingleOrConditionButton.Hide()
				Me.Actions_Insert.Enabled = False
				Me.Actions_Delete.Enabled = False
				Me.AddActionButton.Enabled = False
				Me.DeleteActionButton.Enabled = False
				Me.DeleteActionBlockButton.Enabled = False
				Me.DeleteActionPartButton.Enabled = False
				Me.AddConditionButton.Enabled = False
				Me.DeleteConditionButton.Enabled = False
				Me.DeleteConditionBlockButton.Enabled = False
				Me.ActionTypeBox.Enabled = False
				Me.ConditionTypeBox.Enabled = False
				Me.NegateConditionButton.Enabled = False
				Me.InsertSingleOrConditionButton.Enabled = False
				Me.TriggerVariableControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
				Me.TriggerVariableControl.Enabled = False
				Me.RefreshTriggerVariables(Nothing)
			Else
				Me.TriggerVariableControl.Enabled = True
				Me.RefreshTriggerVariables(trigger)
				Me.ActionListTreeControl.Enabled = True
				Dim firstdisplayed As Integer
				Dim num As Integer
				Me.ActionListTreeControl.GetSelectionInfos(firstdisplayed, num)
				If treeselchange < 0 Then
					treeselchange = -treeselchange
					If treeselchange < num Then
						num -= treeselchange
					Else
						num = 0
					End If
				Else
					num = treeselchange + num
				End If
				Me.ActionListTreeControl.RootNode.Clear()
				Me.Actions_Insert.Enabled = True
				If __Dereference(CType((trigger + 40 / __SizeOf(cTrigger)), __Pointer(Of Integer))) <> 0 Then
					Me.Actions_Delete.Enabled = True
					Dim array As ActionListTreeControl_Node() = New ActionListTreeControl_Node(__Dereference(CType((trigger + 40 / __SizeOf(cTrigger)), __Pointer(Of Integer))) - 1) {}
					array(0) = Nothing
					Dim num2 As Integer = 0
					Dim num3 As Integer = __Dereference(CType((trigger + 40 / __SizeOf(cTrigger)), __Pointer(Of Integer)))
					If 0 < num3 Then
						Dim ptr As __Pointer(Of cTrigger) = trigger + 36 / __SizeOf(cTrigger)
						Do
							Dim ptr2 As __Pointer(Of cAction) = __Dereference((num2 * 4 + __Dereference(CType(ptr, __Pointer(Of Integer)))))
							If __Dereference((ptr2 + 436)) = 0 AndAlso array(0) IsNot Nothing Then
								Me.ActionListTreeControl.RootNode.AddNode(array(0))
							End If
							Dim gBaseString<char> As GBaseString<char>
							Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.cAction.GetAsFormattedString(ptr2, AddressOf gBaseString<char>)
							Try
								Dim num4 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
								Dim value As __Pointer(Of SByte)
								If num4 <> 0UI Then
									value = num4
								Else
									value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								Dim num5 As Integer = __Dereference((ptr2 + 436))
								array(num5) = New ActionListTreeControl_Node(New String(CType(value, __Pointer(Of SByte))), True)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char> IsNot Nothing Then
								<Module>.free(gBaseString<char>)
								gBaseString<char> = 0
							End If
							Dim num6 As Integer = __Dereference((ptr2 + 436))
							array(num6).ActionIndex = num2
							If __Dereference((ptr2 + 436)) <> 0 Then
								Dim num7 As Integer = __Dereference((ptr2 + 436))
								Dim num8 As Integer = num7
								Dim num9 As Integer = num7
								array(num9 - 1).AddNode(array(num8))
							End If
							Select Case __Dereference((ptr2 + 4))
								Case 1, 2, 3, 5, 8, 11
									If __Dereference((ptr2 + 460)) <> 0 Then
										Dim num10 As Integer = __Dereference((ptr2 + 436))
										array(num10).Expand()
									End If
									Dim num11 As Integer = __Dereference((ptr2 + 436))
									array(num11 + 1) = Nothing
							End Select
							Dim num12 As Integer = __Dereference((ptr2 + 4))
							If num12 > 0 AndAlso (num12 <= 2 OrElse num12 = 11) Then
								Dim num13 As Integer = 0
								Dim num14 As Integer = __Dereference((ptr2 + 12))
								If 0 < num14 Then
									Dim ptr4 As __Pointer(Of cAction) = ptr2 + 8
									Do
										Dim gBaseString<char>2 As GBaseString<char>
										Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.cCondition.GetAsFormattedString(__Dereference((num13 * 4 + __Dereference(ptr4))), AddressOf gBaseString<char>2)
										Dim actionListTreeControl_Node As ActionListTreeControl_Node
										Try
											Dim num15 As UInteger = CUInt((__Dereference(CType(ptr5, __Pointer(Of Integer)))))
											actionListTreeControl_Node = New ActionListTreeControl_Node(New String(CType((If((num15 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num15)), __Pointer(Of SByte))), True)
										Catch 
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
											Throw
										End Try
										If gBaseString<char>2 IsNot Nothing Then
											<Module>.free(gBaseString<char>2)
											gBaseString<char>2 = 0
										End If
										actionListTreeControl_Node.ActionIndex = num2
										actionListTreeControl_Node.ConditionIndex = num13
										array(__Dereference((ptr2 + 436))).AddHeaderNode(actionListTreeControl_Node)
										num13 += 1
									Loop While num13 < __Dereference((ptr2 + 12))
								End If
								Dim actionListTreeControl_Node2 As ActionListTreeControl_Node = New ActionListTreeControl_Node("r:End ConditionList", True)
								actionListTreeControl_Node2.ActionIndex = num2
								actionListTreeControl_Node2.ConditionIndex = __Dereference((ptr2 + 12))
								array(__Dereference((ptr2 + 436))).AddHeaderNode(actionListTreeControl_Node2)
							End If
							num2 += 1
						Loop While num2 < __Dereference(CType((trigger + 40 / __SizeOf(cTrigger)), __Pointer(Of Integer)))
					End If
					If array(0) IsNot Nothing Then
						Me.ActionListTreeControl.RootNode.AddNode(array(0))
					End If
				Else
					Me.Actions_Delete.Enabled = False
				End If
				Dim actionListTreeControl_Node3 As ActionListTreeControl_Node = New ActionListTreeControl_Node(New String(CType((AddressOf <Module>.??_C@_05MFELCDH@r?3End?$AA@), __Pointer(Of SByte))), True)
				actionListTreeControl_Node3.ActionIndex = __Dereference(CType((trigger + 40 / __SizeOf(cTrigger)), __Pointer(Of Integer)))
				Me.ActionListTreeControl.RootNode.AddNode(actionListTreeControl_Node3)
				Me.ActionListTreeControl.Dirty(False)
				Me.ActionListTreeControl.SetSelectionInfos(firstdisplayed, num)
			End If
		End Sub

		Private Sub RefreshTriggerVariables(trigger As __Pointer(Of cTrigger))
			If trigger IsNot Nothing AndAlso __Dereference(CType((trigger + 28 / __SizeOf(cTrigger)), __Pointer(Of Integer))) <> 0 Then
				Me.TriggerVariable_Delete.Enabled = True
				Dim num As Integer = __Dereference(CType((trigger + 28 / __SizeOf(cTrigger)), __Pointer(Of Integer)))
				Dim array As Script_GlobalVariableControl_ListItem() = New Script_GlobalVariableControl_ListItem(num - 1) {}
				Dim num2 As Integer = 0
				Dim num3 As Integer = num
				If 0 < num3 Then
					Dim ptr As __Pointer(Of cTrigger) = trigger + 24 / __SizeOf(cTrigger)
					Do
						Dim ptr2 As __Pointer(Of cVariable) = __Dereference((num2 * 4 + __Dereference(CType(ptr, __Pointer(Of Integer)))))
						Dim array2 As Script_GlobalVariableControl_ListSubItem() = New Script_GlobalVariableControl_ListSubItem(3) {}
						array2(0) = New Script_GlobalVariableControl_ListSubItem()
						Dim num4 As UInteger = CUInt((__Dereference(<Module>.ScriptEditor.cVariable.GetName(ptr2))))
						Dim value As __Pointer(Of SByte)
						If num4 <> 0UI Then
							value = num4
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						array2(0).Text = New String(CType(value, __Pointer(Of SByte)))
						array2(1) = New Script_GlobalVariableControl_ListSubItem()
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(AddressOf gBaseString<char>, __Dereference((ptr2 + 16)), 0)
						Try
							Dim num5 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
							Dim value2 As __Pointer(Of SByte)
							If num5 <> 0UI Then
								value2 = num5
							Else
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							array2(1).Text = New String(CType(value2, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
						array2(2) = New Script_GlobalVariableControl_ListSubItem()
						Dim gBaseString<char>2 As GBaseString<char>
						Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.sValue.GetAsString(ptr2 + 16, AddressOf gBaseString<char>2, Me.Editor)
						Try
							Dim num6 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
							Dim value3 As __Pointer(Of SByte)
							If num6 <> 0UI Then
								value3 = num6
							Else
								value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							array2(2).Text = New String(CType(value3, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
							gBaseString<char>2 = 0
						End If
						array2(3) = New Script_GlobalVariableControl_ListSubItem()
						Dim num7 As Integer = __Dereference((ptr2 + 32))
						Dim text As String
						If num7 > 0 Then
							Dim num8 As Integer = num7
							text = String.Format(New String(CType((AddressOf <Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@), __Pointer(Of SByte))), num8)
						Else
							text = New String(CType((AddressOf <Module>.??_C@_02KAJCLHKP@no?$AA@), __Pointer(Of SByte)))
						End If
						array2(3).Text = text
						array(num2) = New Script_GlobalVariableControl_ListItem()
						array(num2).SubItems = array2
						num2 += 1
					Loop While num2 < __Dereference(CType((trigger + 28 / __SizeOf(cTrigger)), __Pointer(Of Integer)))
				End If
				Me.TriggerVariableControl.Items = array
				Dim triggerVariableControl As Script_GlobalVariableControl = Me.TriggerVariableControl
				If triggerVariableControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((triggerVariableControl.SelectedIndex + 1 < __Dereference(CType((trigger + 28 / __SizeOf(cTrigger)), __Pointer(Of Integer)))), 1, 0)
					Me.TriggerVariable_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.TriggerVariableControl.SelectedIndex > 0), 1, 0)
					Me.TriggerVariable_MoveUp.Enabled = (enabled2 <> 0)
					Me.TriggerVariable_FixOrder.Enabled = False
				Else
					Me.TriggerVariable_MoveDown.Enabled = False
					Me.TriggerVariable_MoveUp.Enabled = False
					Me.TriggerVariable_FixOrder.Enabled = True
				End If
			Else
				Me.TriggerVariableControl.Items = New Script_GlobalVariableControl_ListItem(-1) {}
				Me.TriggerVariable_Delete.Enabled = False
				Me.TriggerVariable_FixOrder.Enabled = False
				Me.TriggerVariable_MoveDown.Enabled = False
				Me.TriggerVariable_MoveUp.Enabled = False
			End If
		End Sub

		Private Sub Trigger_Create_Click(sender As Object, e As EventArgs)
			<Module>.ScriptEditor.cEditor.CreateTrigger(Me.Editor, 0)
			Me.RefreshTriggers()
			Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
			Me.Edit_Undo.Enabled = (CByte(num) <> 0)
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
			Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
		End Sub

		Private Sub Trigger_Create_Empty_Click(sender As Object, e As EventArgs)
			<Module>.ScriptEditor.cEditor.CreateTrigger(Me.Editor, 1)
			Me.RefreshTriggers()
			Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
			Me.Edit_Undo.Enabled = (CByte(num) <> 0)
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
			Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
		End Sub

		Private Sub Trigger_Copy_Click(sender As Object, e As EventArgs)
			Dim selectedIndex As Integer = Me.GlobalTriggerControl.SelectedIndex
			If selectedIndex <> -1 Then
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((selectedIndex * 4 + __Dereference(CType((editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				If <Module>.ScriptEditor.cEditor.CreateTrigger(editor, ptr) IsNot Nothing Then
					Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num) <> 0)
					Dim editor2 As __Pointer(Of cEditor) = Me.Editor
					Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
					Me.RefreshAll()
				End If
			End If
		End Sub

		Private Sub Trigger_Delete_Click(sender As Object, e As EventArgs)
			Dim selectedIndex As Integer = Me.GlobalTriggerControl.SelectedIndex
			If selectedIndex <> -1 Then
				<Module>.ScriptEditor.cEditor.DeleteTrigger(Me.Editor, selectedIndex, False)
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
				Me.RefreshAll()
			End If
		End Sub

		Private Sub ScriptEditorForm_Deactivate(sender As Object, e As EventArgs)
			Me.SaveScript()
		End Sub

		Private Sub MainMenu_Scripts_Click(sender As Object, e As EventArgs)
			Me.ChangeScript(sender.Index)
		End Sub

		Private Sub Script_New_Click(sender As Object, e As EventArgs)
			Me.SaveScript()
			Dim index As Integer
			Dim ptr As __Pointer(Of cEditor) = <Module>.ScriptEditor.cManager.CreateEditor(<Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld), index)
			Me.Editor = ptr
			If ptr IsNot Nothing Then
				Me.RefreshScriptList()
				Me.ChangeScript(index)
				Me.RefreshAll()
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
			End If
		End Sub

		Private Sub Script_Save_Click(sender As Object, e As EventArgs)
			Me.SaveScript()
		End Sub

		Private Sub Script_Delete_Click(sender As Object, e As EventArgs)
			If __Dereference(CType((<Module>.SafeWorld + 4084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) >= 2 Then
				Dim scriptIndex As Integer = Me.ScriptIndex
				Dim num As Integer = scriptIndex
				<Module>.ScriptEditor.cManager.DeleteEditor(<Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld), scriptIndex)
				Me.ScriptIndex = -1
				If num >= __Dereference(CType((<Module>.SafeWorld + 4084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) Then
					num -= 1
				End If
				Me.RefreshScriptList()
				Me.ChangeScript(num)
			End If
		End Sub

		Private Sub Script_Import_Click(sender As Object, e As EventArgs)
			Dim nFileDialog As NFileDialog = New NFileDialog(Nothing, True)
			nFileDialog.DefaultExtension = "hbs"
			nFileDialog.AvailableModes = 2
			nFileDialog.SelectedMode = 2
			If nFileDialog.ShowDialog() = DialogResult.OK Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, nFileDialog.FilePath)
				Dim ptr3 As __Pointer(Of GStream)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					ptr3 = <Module>.GFileSystem.OpenRead(<Module>.FS, ptr2, Nothing)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
					gBaseString<char> = 0
				End If
				If ptr3 IsNot Nothing Then
					Dim index As Integer
					Dim flag As Boolean = <Module>.ScriptEditor.cManager.ImportEditor(<Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld), index, ptr3) IsNot Nothing
					Dim arg_A3_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, __Dereference((__Dereference(CType(ptr3, __Pointer(Of Integer))))))
					If flag Then
						Me.RefreshScriptList()
						Me.ChangeScript(index)
						Me.RefreshAll()
						Dim num2 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
						Me.Edit_Undo.Enabled = (CByte(num2) <> 0)
						Dim editor As __Pointer(Of cEditor) = Me.Editor
						Dim num3 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
						Me.Edit_Redo.Enabled = (CByte(num3) <> 0)
					End If
				End If
			End If
		End Sub

		Private Sub Script_Export_Click(sender As Object, e As EventArgs)
			Dim nFileDialog As NFileDialog = New NFileDialog(Nothing, True)
			nFileDialog.DefaultExtension = "hbs"
			nFileDialog.AvailableModes = 4
			nFileDialog.SelectedMode = 4
			If nFileDialog.ShowDialog() = DialogResult.OK Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, nFileDialog.FilePath)
				Dim ptr3 As __Pointer(Of GStream)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					ptr3 = <Module>.GFileSystem.OpenWrite(<Module>.FS, ptr2, Nothing)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
					gBaseString<char> = 0
				End If
				If ptr3 IsNot Nothing Then
					<Module>.ScriptEditor.cEditor.Store(Me.Editor, ptr3)
					Dim arg_92_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, __Dereference((__Dereference(CType(ptr3, __Pointer(Of Integer))))))
				End If
			End If
		End Sub

		Private Sub Edit_Copy_Click(sender As Object, e As EventArgs)
			If Me.GlobalTriggerControl.SelectedIndex <> -1 Then
				Dim arg_20_0 As Integer = Me.SelectedTriggerIndex
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((arg_20_0 * 4 + __Dereference((editor + 28))))
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim selectedNode As ActionListTreeControl_Node = actionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing Then
					Dim selectedNode_End As ActionListTreeControl_Node = actionListTreeControl.SelectedNode_End
					If selectedNode_End IsNot Nothing Then
						Dim actionIndex As Integer
						Dim actionIndex2 As Integer
						If selectedNode.ActionIndex <= selectedNode_End.ActionIndex Then
							actionIndex = selectedNode.ActionIndex
							actionIndex2 = selectedNode_End.ActionIndex
						Else
							actionIndex2 = selectedNode.ActionIndex
							actionIndex = selectedNode_End.ActionIndex
						End If
						Dim ptr2 As __Pointer(Of GStreamBuffer) = <Module>.new(36UI)
						Dim ptr3 As __Pointer(Of GStreamBuffer)
						Try
							If ptr2 IsNot Nothing Then
								ptr3 = <Module>.GStreamBuffer.{ctor}(ptr2)
							Else
								ptr3 = 0
							End If
						Catch 
							<Module>.delete(CType(ptr2, __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GStreamBuffer.Clear(ptr3)
						If <Module>.ScriptEditor.cTrigger.CopyActions(ptr, actionIndex, actionIndex2, ptr3) IsNot Nothing Then
							Dim clipboardStream As __Pointer(Of GStreamBuffer) = Me.ClipboardStream
							If clipboardStream IsNot Nothing Then
								Dim arg_CA_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), clipboardStream, 1, __Dereference((__Dereference(CType(clipboardStream, __Pointer(Of Integer))))))
							End If
							Me.ClipboardStream = ptr3
							Me.Edit_Paste.Enabled = True
						End If
					End If
				End If
			End If
		End Sub

		Private Sub Edit_Cut_Click(sender As Object, e As EventArgs)
			If Me.GlobalTriggerControl.SelectedIndex <> -1 Then
				Dim arg_20_0 As Integer = Me.SelectedTriggerIndex
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((arg_20_0 * 4 + __Dereference((editor + 28))))
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim selectedNode As ActionListTreeControl_Node = actionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing Then
					Dim selectedNode_End As ActionListTreeControl_Node = actionListTreeControl.SelectedNode_End
					If selectedNode_End IsNot Nothing Then
						Dim actionIndex As Integer
						Dim actionIndex2 As Integer
						If selectedNode.ActionIndex <= selectedNode_End.ActionIndex Then
							actionIndex = selectedNode.ActionIndex
							actionIndex2 = selectedNode_End.ActionIndex
						Else
							actionIndex2 = selectedNode.ActionIndex
							actionIndex = selectedNode_End.ActionIndex
						End If
						Dim ptr2 As __Pointer(Of GStreamBuffer) = <Module>.new(36UI)
						Dim ptr3 As __Pointer(Of GStreamBuffer)
						Try
							If ptr2 IsNot Nothing Then
								ptr3 = <Module>.GStreamBuffer.{ctor}(ptr2)
							Else
								ptr3 = 0
							End If
						Catch 
							<Module>.delete(CType(ptr2, __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GStreamBuffer.Clear(ptr3)
						If <Module>.ScriptEditor.cTrigger.CopyActions(ptr, actionIndex, actionIndex2, ptr3) IsNot Nothing AndAlso <Module>.ScriptEditor.cTrigger.DeleteActionRange(ptr, actionIndex, actionIndex2) IsNot Nothing Then
							Dim clipboardStream As __Pointer(Of GStreamBuffer) = Me.ClipboardStream
							If clipboardStream IsNot Nothing Then
								Dim arg_D7_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), clipboardStream, 1, __Dereference((__Dereference(CType(clipboardStream, __Pointer(Of Integer))))))
							End If
							Me.ClipboardStream = ptr3
							Me.Edit_Paste.Enabled = True
							Me.RefreshTriggerData(ptr, 0)
						End If
					End If
				End If
			End If
		End Sub

		Private Sub Edit_Paste_Click(sender As Object, e As EventArgs)
			If Me.GlobalTriggerControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim selectedNode As ActionListTreeControl_Node = actionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing Then
					Dim selectedNode_End As ActionListTreeControl_Node = actionListTreeControl.SelectedNode_End
					If selectedNode_End IsNot Nothing Then
						Dim actionIndex As Integer
						Dim actionIndex2 As Integer
						If selectedNode Is selectedNode_End Then
							actionIndex = selectedNode.ActionIndex
							actionIndex2 = selectedNode_End.ActionIndex
						Else If selectedNode.ActionIndex <= selectedNode_End.ActionIndex Then
							actionIndex = selectedNode.ActionIndex
							actionIndex2 = selectedNode_End.ActionIndex
						Else
							actionIndex2 = selectedNode.ActionIndex
							actionIndex = selectedNode_End.ActionIndex
						End If
						Dim b As Byte = If((selectedNode Is selectedNode_End), 1, 0)
						If <Module>.ScriptEditor.cTrigger.PasteActions(ptr, actionIndex, actionIndex2, b <> 0, CType(Me.ClipboardStream, __Pointer(Of GStream))) IsNot Nothing Then
							Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
							Me.Edit_Undo.Enabled = (CByte(num) <> 0)
							Dim editor As __Pointer(Of cEditor) = Me.Editor
							Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
							Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
							Me.RefreshGlobalVariables()
							Me.RefreshTriggerData(ptr, 0)
						End If
					End If
				End If
			End If
		End Sub

		Private Sub Edit_Clear_Click(sender As Object, e As EventArgs)
			If Me.GlobalTriggerControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim selectedNode As ActionListTreeControl_Node = actionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing Then
					Dim selectedNode_End As ActionListTreeControl_Node = actionListTreeControl.SelectedNode_End
					If selectedNode_End IsNot Nothing Then
						Dim actionIndex As Integer
						Dim actionIndex2 As Integer
						If selectedNode.ActionIndex <= selectedNode_End.ActionIndex Then
							actionIndex = selectedNode.ActionIndex
							actionIndex2 = selectedNode_End.ActionIndex
						Else
							actionIndex2 = selectedNode.ActionIndex
							actionIndex = selectedNode_End.ActionIndex
						End If
						<Module>.ScriptEditor.cTrigger.DeleteActionRange(ptr, actionIndex, actionIndex2)
					End If
				End If
			End If
		End Sub

		Private Sub Edit_Refresh_Click(sender As Object, e As EventArgs)
			Me.RefreshAll()
		End Sub

		Private Sub GlobalVariableControl_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim globalVariableControl As Script_GlobalVariableControl = Me.GlobalVariableControl
			If globalVariableControl.SelectedIndex <> -1 Then
				If globalVariableControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((globalVariableControl.SelectedIndex + 1 < __Dereference(CType((Me.Editor + 16 / __SizeOf(cEditor)), __Pointer(Of Integer)))), 1, 0)
					Me.GlobalVariable_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.GlobalVariableControl.SelectedIndex > 0), 1, 0)
					Me.GlobalVariable_MoveUp.Enabled = (enabled2 <> 0)
					Me.GlobalVariable_FixOrder.Enabled = False
				Else
					Me.GlobalVariable_MoveDown.Enabled = False
					Me.GlobalVariable_MoveUp.Enabled = False
					Me.GlobalVariable_FixOrder.Enabled = True
				End If
			End If
		End Sub

		Private Sub GlobalVariableControl_ItemDoubleClicked(sender As Object, e As EventArgs)
			Dim clickedIndex As Integer = Me.GlobalVariableControl.ClickedIndex
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			Dim ptr As __Pointer(Of cVariable) = __Dereference((clickedIndex * 4 + __Dereference((editor + 12))))
			Dim scriptVariablePropertiesForm As ScriptVariablePropertiesForm = New ScriptVariablePropertiesForm()
			Dim location As Point = MyBase.Location
			scriptVariablePropertiesForm.Location.X = (location.X - scriptVariablePropertiesForm.Width) / 2
			Dim location2 As Point = MyBase.Location
			scriptVariablePropertiesForm.Location.Y = (location2.Y - scriptVariablePropertiesForm.Height) / 2
			scriptVariablePropertiesForm.SetFrom(Me.Editor, Nothing, ptr)
			If scriptVariablePropertiesForm.ShowDialog() = DialogResult.OK Then
				Dim num As Integer = <Module>.ScriptEditor.cEditor.BeginUndoBlock(Me.Editor)
				Dim variable_Type As Integer = scriptVariablePropertiesForm.Variable_Type
				If variable_Type <> 2 AndAlso __Dereference((ptr + 40)) <> 0 Then
					<Module>.?ChangeVariableAutoChangeMode@cEditor@ScriptEditor@@$$FQAE_NHW4eAutoChange_Mode@cVariable@Script@@HH@Z(Me.Editor, clickedIndex, 0, 0, 0)
				End If
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>, scriptVariablePropertiesForm.Variable_Name)
				Try
					<Module>.ScriptEditor.cEditor.RenameVariable(Me.Editor, clickedIndex, gBaseString<char>)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				<Module>.?ChangeVariableType@cEditor@ScriptEditor@@$$FQAE_NHW4eValue_Type@Script@@@Z(Me.Editor, clickedIndex, variable_Type)
				<Module>.ScriptEditor.cEditor.ChangeVariableValue(Me.Editor, clickedIndex, scriptVariablePropertiesForm.Variable_Value)
				If variable_Type = 2 Then
					<Module>.?ChangeVariableAutoChangeMode@cEditor@ScriptEditor@@$$FQAE_NHW4eAutoChange_Mode@cVariable@Script@@HH@Z(Me.Editor, clickedIndex, scriptVariablePropertiesForm.Variable_AutoChangeMode, scriptVariablePropertiesForm.Variable_AutoChange_Value, scriptVariablePropertiesForm.Variable_AutoChange_Period)
				End If
				<Module>.ScriptEditor.cEditor.EndUndoBlock(Me.Editor, num)
				Me.RefreshAll()
			End If
		End Sub

		Private Sub GlobalVariable_Create_Click(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of cVariable) = <Module>.ScriptEditor.cEditor.CreateVariable(Me.Editor)
			__Dereference(CType((ptr + 16 / __SizeOf(cVariable)), __Pointer(Of Integer))) = 2
			__Dereference(CType((ptr + 20 / __SizeOf(cVariable)), __Pointer(Of Integer))) = 0
			Me.RefreshGlobalVariables()
			Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
			Me.Edit_Undo.Enabled = (CByte(num) <> 0)
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
			Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
		End Sub

		Private Sub GlobalVariable_Delete_Click(sender As Object, e As EventArgs)
			Dim selectedIndex As Integer = Me.GlobalVariableControl.SelectedIndex
			If selectedIndex <> -1 Then
				<Module>.ScriptEditor.cEditor.DeleteVariable(Me.Editor, selectedIndex, False)
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
				Me.RefreshAll()
			End If
		End Sub

		Private Sub GlobalVariableControl_DragStarted(sender As Object, e As EventArgs)
			Me.DragType = ScriptEditorForm.eDragType.DRAG_GlobalVariable
			Dim globalVariableControl As Script_GlobalVariableControl = Me.GlobalVariableControl
			If globalVariableControl.SelectedIndex <> -1 Then
				Dim selectedIndex As Integer = globalVariableControl.SelectedIndex
				Me.DragIndex = selectedIndex
				globalVariableControl.DoDragDrop(selectedIndex, DragDropEffects.Link)
			End If
		End Sub

		Private Sub GlobalVariableControl_SortModeChanged(sender As Object, e As EventArgs)
			Dim globalVariableControl As Script_GlobalVariableControl = Me.GlobalVariableControl
			If globalVariableControl.SelectedIndex <> -1 Then
				Dim num As Integer = __Dereference(CType((Me.Editor + 16 / __SizeOf(cEditor)), __Pointer(Of Integer)))
				If num = 0 Then
					Me.GlobalVariable_MoveDown.Enabled = False
					Me.GlobalVariable_MoveUp.Enabled = False
					Me.GlobalVariable_FixOrder.Enabled = False
				Else If globalVariableControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((globalVariableControl.SelectedIndex + 1 < num), 1, 0)
					Me.GlobalVariable_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.GlobalVariableControl.SelectedIndex > 0), 1, 0)
					Me.GlobalVariable_MoveUp.Enabled = (enabled2 <> 0)
					Me.GlobalVariable_FixOrder.Enabled = False
				Else
					Me.GlobalVariable_MoveDown.Enabled = False
					Me.GlobalVariable_MoveUp.Enabled = False
					Me.GlobalVariable_FixOrder.Enabled = True
				End If
			End If
		End Sub

		Private Sub GlobalVariable_FixOrder_Click(sender As Object, e As EventArgs)
			Dim globalVariableControl As Script_GlobalVariableControl = Me.GlobalVariableControl
			If globalVariableControl.SelectedIndex <> -1 AndAlso Not globalVariableControl.IsInOriginalOrder() Then
				Dim num As UInteger = CUInt(globalVariableControl.SortIndices.Length)
				Dim ptr As __Pointer(Of Integer) = <Module>.new[](If((num > 1073741823UI), 4294967295UI, (num << 2)))
				Dim num2 As Integer = 0
				globalVariableControl = Me.GlobalVariableControl
				If 0 < globalVariableControl.SortIndices.Length Then
					Do
						num2(ptr) = globalVariableControl.SortIndices(num2)
						num2 += 1
						globalVariableControl = Me.GlobalVariableControl
					Loop While num2 < globalVariableControl.SortIndices.Length
				End If
				Dim flag As Boolean = <Module>.ScriptEditor.cEditor.FixVariableOrder(Me.Editor, CType(ptr, __Pointer(Of Integer)), Me.GlobalVariableControl.SortIndices.Length) IsNot Nothing
				<Module>.delete[](CType(ptr, __Pointer(Of Void)))
				If flag Then
					Dim num3 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num3) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num4 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num4) <> 0)
					Me.RefreshGlobalVariables()
					Me.GlobalVariableControl.ForceUnsorted()
				End If
			End If
		End Sub

		Private Sub GlobalVariable_MoveUp_Click(sender As Object, e As EventArgs)
			Dim globalVariableControl As Script_GlobalVariableControl = Me.GlobalVariableControl
			If globalVariableControl.SelectedIndex <> -1 AndAlso globalVariableControl.IsInOriginalOrder() AndAlso <Module>.ScriptEditor.cEditor.MoveVariableUp(Me.Editor, globalVariableControl.SelectedIndex) IsNot Nothing Then
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
				Me.RefreshGlobalVariables()
				globalVariableControl = Me.GlobalVariableControl
				globalVariableControl.SelectedIndex -= 1
			End If
		End Sub

		Private Sub GlobalVariable_MoveDown_Click(sender As Object, e As EventArgs)
			Dim globalVariableControl As Script_GlobalVariableControl = Me.GlobalVariableControl
			If globalVariableControl.SelectedIndex <> -1 AndAlso globalVariableControl.IsInOriginalOrder() AndAlso <Module>.ScriptEditor.cEditor.MoveVariableDown(Me.Editor, globalVariableControl.SelectedIndex) IsNot Nothing Then
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
				Me.RefreshGlobalVariables()
				globalVariableControl = Me.GlobalVariableControl
				globalVariableControl.SelectedIndex += 1
			End If
		End Sub

		Private Sub ScriptEntitiesFilterBox_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.RefreshScriptEntities()
		End Sub

		Private Sub ScriptEntitiesControl_DragStarted(sender As Object, e As EventArgs)
			Me.DragType = ScriptEditorForm.eDragType.DRAG_Entity
			Dim scriptEntitiesControl As Script_GlobalVariableControl = Me.ScriptEntitiesControl
			If scriptEntitiesControl.SelectedIndex <> -1 Then
				Dim num As Integer = Me.ScriptEntities_List(scriptEntitiesControl.SelectedIndex)
				Me.DragIndex = num
				scriptEntitiesControl.DoDragDrop(num, DragDropEffects.Link)
			End If
		End Sub

		Private Sub ScriptEntities_ShowStoredUnits_CheckedChanged(sender As Object, e As EventArgs)
			Dim num As Integer = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 136))
			If num < 0 Then
				num = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 132))
				If num < 0 Then
					num = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 128))
					If num < 0 Then
						num = __Dereference((<Module>.ScriptEditor.EntityTypeIndices + 140))
					End If
				End If
			End If
			If Me.ScriptEntitiesFilterBox.GetSelected(num) Then
				Me.RefreshScriptEntities()
			End If
		End Sub

		Private Sub GlobalTriggerControl_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			Dim selectedIndex As Integer = globalTriggerControl.SelectedIndex
			Me.SelectedTriggerIndex = selectedIndex
			If selectedIndex = -1 Then
				Me.RefreshTriggerData(Nothing, 0)
				Me.Trigger_MoveDown.Enabled = False
				Me.Trigger_MoveUp.Enabled = False
				Me.Trigger_FixOrder.Enabled = False
			Else
				If globalTriggerControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((selectedIndex + 1 < __Dereference(CType((Me.Editor + 32 / __SizeOf(cEditor)), __Pointer(Of Integer)))), 1, 0)
					Me.Trigger_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.SelectedTriggerIndex > 0), 1, 0)
					Me.Trigger_MoveUp.Enabled = (enabled2 <> 0)
					Me.Trigger_FixOrder.Enabled = False
				Else
					Me.Trigger_MoveDown.Enabled = False
					Me.Trigger_MoveUp.Enabled = False
					Me.Trigger_FixOrder.Enabled = True
				End If
				Me.RefreshTriggerData(__Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer))))), 0)
			End If
		End Sub

		Private Sub GlobalTriggerControl_ItemClicked(sender As Object, e As EventArgs)
		End Sub

		Private Sub GlobalTriggerControl_ItemDoubleClicked(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			Dim clickedColumnIndex As Integer = globalTriggerControl.ClickedColumnIndex
			If clickedColumnIndex <> 0 Then
				If clickedColumnIndex <> 1 Then
					If clickedColumnIndex = 2 Then
						Dim clickedIndex As Integer = globalTriggerControl.ClickedIndex
						Dim editor As __Pointer(Of cEditor) = Me.Editor
						Dim ptr As __Pointer(Of cTrigger) = __Dereference((clickedIndex * 4 + __Dereference(CType((editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
						Dim b As Byte = If((__Dereference((ptr + 48)) = 0), 1, 0)
						<Module>.ScriptEditor.cEditor.SetTriggerActiveState(editor, ptr, b <> 0)
						If clickedIndex = Me.SelectedTriggerIndex Then
							Me.RefreshTriggerData(ptr, 0)
						End If
						Dim text As String
						If __Dereference((ptr + 48)) <> 0 Then
							text = "yes"
						Else
							text = "no"
						End If
						Me.GlobalTriggerControl.Items(clickedIndex).SubItems(2).Text = text
						Me.GlobalTriggerControl.Invalidate()
						Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
						Me.Edit_Undo.Enabled = (CByte(num) <> 0)
						Dim editor2 As __Pointer(Of cEditor) = Me.Editor
						Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
						Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
					End If
				Else
					Dim arg_108_0 As Integer = globalTriggerControl.ClickedIndex
					Dim editor3 As __Pointer(Of cEditor) = Me.Editor
					Dim ptr2 As __Pointer(Of cTrigger) = __Dereference((arg_108_0 * 4 + __Dereference((editor3 + 28))))
					Dim ptr3 As __Pointer(Of Integer) = CType((AddressOf <Module>.ScriptEditor.EventTypeList), __Pointer(Of Integer))
					If <Module>.ScriptEditor.EventTypeList <> 11 Then
						Do
							ptr3 += 4 / __SizeOf(Integer)
						Loop While __Dereference(CType(ptr3, __Pointer(Of Integer))) <> 11
					End If
					Dim num3 As Integer = ptr3 - <Module>.ScriptEditor.EventTypeList / __SizeOf(Integer) >> 2
					Dim array As Object() = New Object(num3 - 1) {}
					Dim selectedIndex As Integer = 0
					Dim num4 As Integer = 0
					If 0 < num3 Then
						Dim ptr4 As __Pointer(Of cTrigger) = ptr2 + 16
						Do
							Dim gBaseString<char> As GBaseString<char>
							Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.?GetEventTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eEvent_Type@Script@@@Z(AddressOf gBaseString<char>, __Dereference((num4 * 4 + <Module>.ScriptEditor.EventTypeList)))
							Try
								Dim num5 As UInteger = CUInt((__Dereference(CType(ptr5, __Pointer(Of Integer)))))
								Dim value As __Pointer(Of SByte)
								If num5 <> 0UI Then
									value = num5
								Else
									value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								array(num4) = New String(CType(value, __Pointer(Of SByte)))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char> IsNot Nothing Then
								<Module>.free(gBaseString<char>)
								gBaseString<char> = 0
							End If
							If __Dereference((num4 * 4 + <Module>.ScriptEditor.EventTypeList)) = __Dereference(ptr4) Then
								selectedIndex = num4
							End If
							num4 += 1
						Loop While num4 < num3
					End If
					Dim inPlaceEditing_ListBox As InPlaceEditing_ListBox = New InPlaceEditing_ListBox()
					inPlaceEditing_ListBox.Items.Clear()
					inPlaceEditing_ListBox.Items.AddRange(array)
					Dim rectangle As Rectangle = Nothing
					Me.GlobalTriggerControl.GetClickedRect(rectangle)
					inPlaceEditing_ListBox.SelectedIndex = selectedIndex
					Dim p As Point = New Point(rectangle.X, rectangle.Y + rectangle.Height)
					Dim location As Point = Me.GlobalTriggerControl.PointToScreen(p)
					inPlaceEditing_ListBox.Location = location
					Dim width As Integer
					If rectangle.Width > 80 Then
						width = rectangle.Width
					Else
						width = 80
					End If
					Dim num6 As Integer = inPlaceEditing_ListBox.Items.Count + 1
					Dim size As Size = New Size(width, inPlaceEditing_ListBox.ItemHeight * num6)
					inPlaceEditing_ListBox.Size = size
					AddHandler inPlaceEditing_ListBox.SelectionReady, AddressOf Me.TriggerEventBox_InPlace_SelectionReady
					AddHandler inPlaceEditing_ListBox.SelectionCancel, AddressOf Me.TriggerEventBox_InPlace_SelectionCancel
					inPlaceEditing_ListBox.Parent = Me
					inPlaceEditing_ListBox.CreateControl()
					<Module>.SetCapture(CType(inPlaceEditing_ListBox.Handle.ToPointer(), __Pointer(Of HWND__)))
				End If
			Else
				Dim arg_2F3_0 As Integer = __Dereference((globalTriggerControl.ClickedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim inPlaceEditing_TextBox As InPlaceEditing_TextBox = New InPlaceEditing_TextBox()
				Dim rectangle2 As Rectangle = Nothing
				Me.GlobalTriggerControl.GetClickedRect(rectangle2)
				Dim num7 As UInteger = CUInt((__Dereference((arg_2F3_0 + 8))))
				Dim value2 As __Pointer(Of SByte)
				If num7 <> 0UI Then
					value2 = num7
				Else
					value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				inPlaceEditing_TextBox.Text = New String(CType(value2, __Pointer(Of SByte)))
				Dim p2 As Point = New Point(rectangle2.X, rectangle2.Y)
				Dim location2 As Point = Me.GlobalTriggerControl.PointToScreen(p2)
				inPlaceEditing_TextBox.Location = location2
				Dim width2 As Integer
				If rectangle2.Width > 120 Then
					width2 = rectangle2.Width
				Else
					width2 = 120
				End If
				Dim size2 As Size = New Size(width2, rectangle2.Height)
				inPlaceEditing_TextBox.Size = size2
				AddHandler inPlaceEditing_TextBox.EditingReady, AddressOf Me.TriggerNameBox_InPlace_EditingReady
				AddHandler inPlaceEditing_TextBox.EditingCancel, AddressOf Me.TriggerNameBox_InPlace_EditingCancel
				inPlaceEditing_TextBox.Parent = Me
				inPlaceEditing_TextBox.CreateControl()
				<Module>.SetCapture(CType(inPlaceEditing_TextBox.Handle.ToPointer(), __Pointer(Of HWND__)))
			End If
		End Sub

		Private Sub GlobalTriggerControl_DragStarted(sender As Object, e As EventArgs)
			Me.DragType = ScriptEditorForm.eDragType.DRAG_Trigger
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			Dim selectedIndex As Integer = globalTriggerControl.SelectedIndex
			Me.DragIndex = selectedIndex
			globalTriggerControl.DoDragDrop(selectedIndex, DragDropEffects.Link)
		End Sub

		Private Sub GlobalTriggerControl_SortModeChanged(sender As Object, e As EventArgs)
			Dim num As Integer = __Dereference(CType((Me.Editor + 32 / __SizeOf(cEditor)), __Pointer(Of Integer)))
			If num = 0 Then
				Me.Trigger_MoveDown.Enabled = False
				Me.Trigger_MoveUp.Enabled = False
				Me.Trigger_FixOrder.Enabled = False
			Else
				Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
				If globalTriggerControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((globalTriggerControl.SelectedIndex + 1 < num), 1, 0)
					Me.Trigger_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.GlobalTriggerControl.SelectedIndex > 0), 1, 0)
					Me.Trigger_MoveUp.Enabled = (enabled2 <> 0)
					Me.Trigger_FixOrder.Enabled = False
				Else
					Me.Trigger_MoveDown.Enabled = False
					Me.Trigger_MoveUp.Enabled = False
					Me.Trigger_FixOrder.Enabled = True
				End If
			End If
		End Sub

		Private Sub Trigger_FixOrder_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If Not globalTriggerControl.IsInOriginalOrder() Then
				Dim num As UInteger = CUInt(globalTriggerControl.SortIndices.Length)
				Dim ptr As __Pointer(Of Integer) = <Module>.new[](If((num > 1073741823UI), 4294967295UI, (num << 2)))
				Dim num2 As Integer = 0
				globalTriggerControl = Me.GlobalTriggerControl
				If 0 < globalTriggerControl.SortIndices.Length Then
					Do
						num2(ptr) = globalTriggerControl.SortIndices(num2)
						num2 += 1
						globalTriggerControl = Me.GlobalTriggerControl
					Loop While num2 < globalTriggerControl.SortIndices.Length
				End If
				Dim flag As Boolean = <Module>.ScriptEditor.cEditor.FixTriggerOrder(Me.Editor, CType(ptr, __Pointer(Of Integer)), Me.GlobalTriggerControl.SortIndices.Length) IsNot Nothing
				<Module>.delete[](CType(ptr, __Pointer(Of Void)))
				If flag Then
					Dim num3 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num3) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num4 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num4) <> 0)
					Me.RefreshTriggers()
					Me.GlobalTriggerControl.ForceUnsorted()
				End If
			End If
		End Sub

		Private Sub Trigger_MoveUp_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.IsInOriginalOrder() AndAlso <Module>.ScriptEditor.cEditor.MoveTriggerUp(Me.Editor, globalTriggerControl.SelectedIndex) IsNot Nothing Then
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
				Me.RefreshTriggers()
				globalTriggerControl = Me.GlobalTriggerControl
				globalTriggerControl.SelectedIndex -= 1
			End If
		End Sub

		Private Sub Trigger_MoveDown_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.IsInOriginalOrder() AndAlso <Module>.ScriptEditor.cEditor.MoveTriggerDown(Me.Editor, globalTriggerControl.SelectedIndex) IsNot Nothing Then
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
				Me.RefreshTriggers()
				globalTriggerControl = Me.GlobalTriggerControl
				globalTriggerControl.SelectedIndex += 1
			End If
		End Sub

		Private Sub ActionListTreeControl_SelectionChanged(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim selectedNode As ActionListTreeControl_Node = actionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing Then
					Dim selectedNode_End As ActionListTreeControl_Node = actionListTreeControl.SelectedNode_End
					If selectedNode_End IsNot Nothing Then
						Dim actionIndex As Integer
						Dim actionIndex2 As Integer
						If selectedNode.ActionIndex <= selectedNode_End.ActionIndex Then
							actionIndex = selectedNode.ActionIndex
							actionIndex2 = selectedNode_End.ActionIndex
						Else
							actionIndex2 = selectedNode.ActionIndex
							actionIndex = selectedNode_End.ActionIndex
						End If
						<Module>.ScriptEditor.cTrigger.CalculateSelection(ptr, actionIndex, actionIndex2)
						Me.ActionListTreeControl.SetSelectionExtendedInfos(actionIndex, actionIndex2)
						If selectedNode Is selectedNode_End AndAlso selectedNode.HeaderNode Then
							Me.ActionType_Label.Hide()
							Me.ActionTypeBox.Hide()
							Me.AddActionButton.Hide()
							Me.DeleteActionButton.Hide()
							Me.DeleteActionBlockButton.Hide()
							Me.DeleteActionPartButton.Hide()
							Me.ActionTypeBox.Enabled = False
							Me.AddActionButton.Enabled = False
							Me.DeleteActionButton.Enabled = False
							Me.DeleteActionBlockButton.Enabled = False
							Me.DeleteActionPartButton.Enabled = False
							Me.ConditionTypeBox.Enabled = True
							Me.AddConditionButton.Enabled = True
							Dim ptr2 As __Pointer(Of cAction) = __Dereference((selectedNode.ActionIndex * 4 + __Dereference((ptr + 36))))
							Dim conditionIndex As Integer = selectedNode.ConditionIndex
							If selectedNode.ConditionIndex < __Dereference((ptr2 + 12)) Then
								Me.DeleteConditionButton.Enabled = True
								Me.InsertSingleOrConditionButton.Enabled = True
								Dim num As Integer = __Dereference((__Dereference((conditionIndex * 4 + __Dereference((ptr2 + 8)))) + 4))
								If num >= 0 AndAlso num <= 4 Then
									Me.NegateConditionButton.Enabled = False
								Else
									Me.NegateConditionButton.Enabled = True
								End If
								If num >= 2 AndAlso num <= 4 Then
									Me.DeleteConditionBlockButton.Enabled = True
								Else
									Me.DeleteConditionBlockButton.Enabled = False
								End If
							Else
								Me.DeleteConditionButton.Enabled = False
								Me.DeleteConditionBlockButton.Enabled = False
								Me.NegateConditionButton.Enabled = False
								Me.InsertSingleOrConditionButton.Enabled = False
							End If
							Me.ConditionType_Label.Show()
							Me.ConditionTypeBox.Show()
							Me.AddConditionButton.Show()
							Me.DeleteConditionButton.Show()
							Me.DeleteConditionBlockButton.Show()
							Me.NegateConditionButton.Show()
							Me.InsertSingleOrConditionButton.Show()
						Else
							Me.ConditionType_Label.Hide()
							Me.ConditionTypeBox.Hide()
							Me.AddConditionButton.Hide()
							Me.DeleteConditionButton.Hide()
							Me.DeleteConditionBlockButton.Hide()
							Me.NegateConditionButton.Hide()
							Me.InsertSingleOrConditionButton.Hide()
							Me.ConditionTypeBox.Enabled = False
							Me.AddConditionButton.Enabled = False
							Me.DeleteConditionButton.Enabled = False
							Me.DeleteConditionBlockButton.Enabled = False
							Me.NegateConditionButton.Enabled = False
							Me.InsertSingleOrConditionButton.Enabled = False
							If selectedNode IsNot selectedNode_End Then
								Me.ActionTypeBox.Enabled = False
								Me.AddActionButton.Enabled = False
								Me.DeleteActionButton.Enabled = True
								Me.DeleteActionBlockButton.Enabled = False
								Me.DeleteActionPartButton.Enabled = False
							Else
								Me.ActionTypeBox.Enabled = True
								Me.AddActionButton.Enabled = True
								Dim num2 As Integer
								If selectedNode.ActionIndex < __Dereference((ptr + 40)) Then
									num2 = __Dereference((__Dereference((selectedNode.ActionIndex * 4 + __Dereference((ptr + 36)))) + 4))
									Me.DeleteActionButton.Enabled = True
								Else
									num2 = 168
									Me.DeleteActionButton.Enabled = False
								End If
								Select Case num2
									Case 1, 2, 3, 4, 5, 7, 8, 10, 11, 12
										Me.DeleteActionBlockButton.Enabled = True
										GoTo IL_3E2
								End Select
								Me.DeleteActionBlockButton.Enabled = False
								IL_3E2:
								If num2 >= 2 AndAlso num2 <= 3 Then
									Me.DeleteActionPartButton.Enabled = True
								Else
									Me.DeleteActionPartButton.Enabled = False
								End If
							End If
							Me.ActionType_Label.Show()
							Me.ActionTypeBox.Show()
							Me.AddActionButton.Show()
							Me.DeleteActionButton.Show()
							Me.DeleteActionBlockButton.Show()
							Me.DeleteActionPartButton.Show()
						End If
					End If
				End If
			End If
		End Sub

		Private Sub ActionListTreeControl_ExpandChanged(sender As Object, e As EventArgs)
			Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
			If selectedNode IsNot Nothing Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.GlobalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim actionIndex As Integer = selectedNode.ActionIndex
				If actionIndex < __Dereference((ptr + 40)) Then
					Dim ptr2 As __Pointer(Of cAction) = __Dereference((actionIndex * 4 + __Dereference((ptr + 36))))
					Dim num As Integer = If((__Dereference((ptr2 + 460)) = 0), 1, 0)
					__Dereference((ptr2 + 460)) = CByte(num)
				End If
			End If
		End Sub

		Private Sub ActionListTreeControl_MouseTargetChanged(sender As Object, e As EventArgs)
			Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
			Dim mouseTargetNode As ActionListTreeControl_Node = actionListTreeControl.MouseTargetNode
			If mouseTargetNode Is Nothing Then
				Me.StatusLine.Text = String.Empty
			Else
				Dim mouseTargetTextElement As ActionListTreeControl_Node_TextElement = actionListTreeControl.MouseTargetTextElement
				Dim arg_46_0 As Integer = Me.GlobalTriggerControl.SelectedIndex
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((arg_46_0 * 4 + __Dereference((editor + 28))))
				Dim actionIndex As Integer = mouseTargetNode.ActionIndex
				Dim num As Integer = __Dereference((ptr + 40))
				If actionIndex < num Then
					Dim ptr2 As __Pointer(Of cAction) = __Dereference((actionIndex * 4 + __Dereference((ptr + 36))))
					If mouseTargetNode.HeaderNode Then
						Dim conditionIndex As Integer = mouseTargetNode.ConditionIndex
						Dim num2 As Integer = __Dereference((ptr2 + 12))
						If conditionIndex < num2 Then
							Dim ptr3 As __Pointer(Of cCondition) = __Dereference((conditionIndex * 4 + __Dereference((ptr2 + 8))))
							Dim array As String() = New String(3) {}
							Dim num3 As Integer = __Dereference((ptr3 + 4))
							Dim gBaseString<char> As GBaseString<char>
							Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.?GetConditionTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eCondition_Type@Script@@_N@Z(AddressOf gBaseString<char>, num3, 0)
							Try
								Dim num4 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
								Dim value As __Pointer(Of SByte)
								If num4 <> 0UI Then
									value = num4
								Else
									value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								array(0) = New String(CType(value, __Pointer(Of SByte)))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char> IsNot Nothing Then
								<Module>.free(gBaseString<char>)
							End If
							Dim gBaseString<char>2 As GBaseString<char>
							Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.cCondition.GetAsString(ptr3, AddressOf gBaseString<char>2)
							Try
								Dim num5 As UInteger = CUInt((__Dereference(CType(ptr5, __Pointer(Of Integer)))))
								Dim value2 As __Pointer(Of SByte)
								If num5 <> 0UI Then
									value2 = num5
								Else
									value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								array(1) = New String(CType(value2, __Pointer(Of SByte)))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>2 IsNot Nothing Then
								<Module>.free(gBaseString<char>2)
							End If
							Dim ptr6 As __Pointer(Of sParameter) = ptr3 + mouseTargetTextElement.ParameterIndex * 52 + 12
							If __Dereference(ptr6) = 0 AndAlso __Dereference((ptr6 + 28)) <> 0 Then
								Dim array2 As String() = New String(3) {}
								array2(0) = mouseTargetTextElement.Text
								Dim text As String
								If __Dereference((ptr6 + 28)) = 2 Then
									text = "global"
								Else
									text = New String(CType((AddressOf <Module>.??_C@_05IDKHKMLA@local?$AA@), __Pointer(Of SByte)))
								End If
								array2(1) = text
								Dim gBaseString<char>3 As GBaseString<char>
								Dim ptr7 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetValueTypeAsString(AddressOf gBaseString<char>3, __Dereference((ptr6 + 32)))
								Try
									array2(2) = New String(<Module>.GBaseString<char>..PBD(ptr7))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
									Throw
								End Try
								If gBaseString<char>3 IsNot Nothing Then
									<Module>.free(gBaseString<char>3)
								End If
								array2(3) = New String(<Module>.GBaseString<char>..PBD(ptr6 + 44))
								array(2) = String.Format("{0} was a {1} variable of type {2} with name {3}", array2)
							Else
								array(2) = mouseTargetTextElement.Text
							End If
							Dim cParameterInfoArray As cParameterInfoArray = 0
							__Dereference((cParameterInfoArray + 4)) = 0
							__Dereference((cParameterInfoArray + 8)) = 0
							Try
								Dim flag As Boolean
								If <Module>.ScriptEditor.cCondition.GetParameterBaseType(ptr3, mouseTargetTextElement.ParameterIndex, cParameterInfoArray, flag) IsNot Nothing Then
									array(3) = "Not implemented"
								Else
									array(3) = "No info!"
								End If
								Me.StatusLine.Lines = array
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						End If
					Else
						Dim array3 As String() = New String(3) {}
						Dim num6 As Integer = __Dereference((ptr2 + 4))
						Dim gBaseString<char>4 As GBaseString<char>
						Dim ptr8 As __Pointer(Of GBaseString<char>) = <Module>.?GetActionTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eAction_Type@Script@@@Z(AddressOf gBaseString<char>4, num6)
						Try
							Dim num7 As UInteger = CUInt((__Dereference(CType(ptr8, __Pointer(Of Integer)))))
							Dim value3 As __Pointer(Of SByte)
							If num7 <> 0UI Then
								value3 = num7
							Else
								value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							array3(0) = New String(CType(value3, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>4 IsNot Nothing Then
							<Module>.free(gBaseString<char>4)
						End If
						Dim gBaseString<char>5 As GBaseString<char>
						Dim ptr9 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.cAction.GetAsString(ptr2, AddressOf gBaseString<char>5)
						Try
							Dim num8 As UInteger = CUInt((__Dereference(CType(ptr9, __Pointer(Of Integer)))))
							Dim value4 As __Pointer(Of SByte)
							If num8 <> 0UI Then
								value4 = num8
							Else
								value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							array3(1) = New String(CType(value4, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>5 IsNot Nothing Then
							<Module>.free(gBaseString<char>5)
						End If
						Dim ptr10 As __Pointer(Of sParameter) = ptr2 + mouseTargetTextElement.ParameterIndex * 52 + 20
						If __Dereference(ptr10) = 0 AndAlso __Dereference((ptr10 + 28)) <> 0 Then
							Dim array4 As String() = New String(3) {}
							array4(0) = mouseTargetTextElement.Text
							Dim text2 As String
							If __Dereference((ptr10 + 28)) = 2 Then
								text2 = "global"
							Else
								text2 = New String(CType((AddressOf <Module>.??_C@_05IDKHKMLA@local?$AA@), __Pointer(Of SByte)))
							End If
							array4(1) = text2
							Dim gBaseString<char>6 As GBaseString<char>
							Dim ptr11 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetValueTypeAsString(AddressOf gBaseString<char>6, __Dereference((ptr10 + 32)))
							Try
								array4(2) = New String(<Module>.GBaseString<char>..PBD(ptr11))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GBaseString<char>.{dtor}(gBaseString<char>6)
							array4(3) = New String(<Module>.GBaseString<char>..PBD(ptr10 + 44))
							array3(2) = String.Format("{0} was a {1} variable of type {2} with name {3}", array4)
						Else
							array3(2) = mouseTargetTextElement.Text
						End If
						Dim cParameterInfoArray2 As cParameterInfoArray = 0
						__Dereference((cParameterInfoArray2 + 4)) = 0
						__Dereference((cParameterInfoArray2 + 8)) = 0
						Try
							Dim flag2 As Boolean
							If <Module>.ScriptEditor.cAction.GetParameterBaseType(ptr2, mouseTargetTextElement.ParameterIndex, cParameterInfoArray2, flag2) IsNot Nothing Then
								array3(3) = "Not implemented"
							Else
								array3(3) = "No info!"
							End If
							Me.StatusLine.Lines = array3
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
					End If
				End If
			End If
		End Sub

		Private Sub ActionListTreeControl_MouseTargetDoubleClicked(sender As Object, e As EventArgs)
		End Sub

		Private Sub ActionListTreeControl_MouseTargetOnDrop(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim mouseTargetNode As ActionListTreeControl_Node = actionListTreeControl.MouseTargetNode
				Dim mouseTargetTextElement As ActionListTreeControl_Node_TextElement = actionListTreeControl.MouseTargetTextElement
				Dim arg_43_0 As Integer = globalTriggerControl.SelectedIndex
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim ptr As __Pointer(Of cEditor) = editor
				Dim ptr2 As __Pointer(Of cTrigger) = __Dereference((arg_43_0 * 4 + __Dereference((ptr + 28))))
				Dim actionIndex As Integer = mouseTargetNode.ActionIndex
				Dim num As Integer = __Dereference((ptr2 + 40))
				If actionIndex < num Then
					Dim parameterIndex As Integer = mouseTargetTextElement.ParameterIndex
					Dim ptr4 As __Pointer(Of cVariable)
					Dim num2 As Integer
					Dim num3 As Integer
					Select Case Me.DragType
						Case ScriptEditorForm.eDragType.DRAG_GlobalVariable
							Dim arg_9A_0 As Integer = Me.DragIndex
							Dim ptr3 As __Pointer(Of cEditor) = editor
							ptr4 = __Dereference((arg_9A_0 * 4 + __Dereference((ptr3 + 12))))
							num2 = 2
							num3 = 4
						Case ScriptEditorForm.eDragType.DRAG_LocalVariable
							ptr4 = __Dereference((Me.DragIndex * 4 + __Dereference((ptr2 + 24))))
							num2 = 3
							num3 = 5
							If(If((__Dereference(CType((ptr4 + 12 / __SizeOf(cVariable)), __Pointer(Of Integer))) = 2), 1, 0)) <> 0 Then
								Dim num4 As Integer = 0
								If 0 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) Then
									Do
										If __Dereference((<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4) + 4)) = 5 OrElse __Dereference((<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4) + 4)) = 8 Then
											Dim arg_12C_0 As Integer = __Dereference((<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4) + 440))
											Dim num5 As Integer = __Dereference(CType(ptr4, __Pointer(Of Integer)))
											If arg_12C_0 = num5 Then
												Exit Do
											End If
										End If
										num4 += 1
									Loop While num4 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2)
								End If
								If num4 = <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) OrElse actionIndex <= num4 Then
									Return
								End If
								Dim num6 As Integer = If((<Module>.?GetType@cAction@ScriptEditor@@$$FQBE?AW4eAction_Type@Script@@XZ(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4)) = 5), 7, 10)
								Dim num7 As Integer = <Module>.ScriptEditor.cAction.GetDepth(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4))
								If num4 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) Then
									While <Module>.?GetType@cAction@ScriptEditor@@$$FQBE?AW4eAction_Type@Script@@XZ(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4)) <> num6 OrElse <Module>.ScriptEditor.cAction.GetDepth(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num4)) <> num7
										num4 += 1
										If num4 >= <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) Then
											Exit While
										End If
									End While
								End If
								If num4 = <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) OrElse actionIndex >= num4 Then
									Return
								End If
							Else If <Module>.ScriptEditor.cVariable.IsAuto(ptr4) IsNot Nothing Then
								Dim num8 As Integer = 0
								If 0 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) Then
									Do
										If __Dereference((<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num8) + 4)) = 39 Then
											Dim num9 As Integer = __Dereference(CType(ptr4, __Pointer(Of Integer)))
											If <Module>.ScriptEditor.cAction.GetAutoVariableIndex(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num8)) = num9 Then
												Exit Do
											End If
										End If
										num8 += 1
									Loop While num8 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2)
								End If
								If num8 = <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) OrElse actionIndex <= num8 Then
									Return
								End If
								Dim num10 As Integer = <Module>.ScriptEditor.cAction.GetDepth(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num8))
								If num8 < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) Then
									While <Module>.ScriptEditor.cAction.GetDepth(<Module>.ScriptEditor.cTrigger.GetAction(ptr2, num8)) >= num10
										num8 += 1
										If num8 >= <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr2) Then
											Exit While
										End If
									End While
								End If
								If actionIndex >= num8 Then
									Return
								End If
							End If
						Case ScriptEditorForm.eDragType.DRAG_Entity
							Dim arg_BA_0 As Integer = Me.DragIndex
							Dim ptr5 As __Pointer(Of cEditor) = editor
							ptr4 = __Dereference((arg_BA_0 * 4 + __Dereference((ptr5 + 44))))
							num2 = 6
							num3 = 7
						Case ScriptEditorForm.eDragType.DRAG_Trigger
							If mouseTargetNode.HeaderNode Then
								Dim conditionIndex As Integer = mouseTargetNode.ConditionIndex
								Dim num11 As Integer = __Dereference((<Module>.ScriptEditor.cEditor.GetTrigger(editor, Me.DragIndex) + 4))
								If <Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(editor, ptr2, actionIndex, conditionIndex, parameterIndex, 10, num11) Is Nothing Then
									Return
								End If
							Else
								Dim num12 As Integer = __Dereference((<Module>.ScriptEditor.cEditor.GetTrigger(editor, Me.DragIndex) + 4))
								If <Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(editor, ptr2, actionIndex, parameterIndex, 10, num12) Is Nothing Then
									Return
								End If
							End If
							Me.RefreshTriggerData(ptr2, 0)
							Me.RefreshGlobalVariables()
							Me.Edit_Undo.Enabled = (<Module>.ScriptEditor.cEditor.HasUndo(Me.Editor) IsNot Nothing)
							Me.Edit_Redo.Enabled = (<Module>.ScriptEditor.cEditor.HasRedo(Me.Editor) IsNot Nothing)
							Return
						Case Else
							Return
					End Select
					If mouseTargetNode.HeaderNode Then
						Dim conditionIndex2 As Integer = mouseTargetNode.ConditionIndex
						Dim gArray<int> As GArray<int>
						<Module>.GArray<int>.{ctor}(gArray<int>)
						Try
							If <Module>.ScriptEditor.cEditor.GetConditionParameterChangePossibilities(Me.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, ptr4, gArray<int>) IsNot Nothing Then
								GoTo IL_2A9
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GArray<int>.{dtor}(gArray<int>)
						Return
						IL_2A9:
						Try
							If __Dereference((gArray<int> + 4)) <> 0 Then
								GoTo IL_2CF
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GArray<int>.{dtor}(gArray<int>)
						Return
						IL_2CF:
						Try
							If __Dereference((gArray<int> + 4)) <> 1 Then
								GoTo IL_372
							End If
							Dim num13 As Integer = __Dereference(<Module>.GArray<int>.[](gArray<int>, 0))
							If num13 <> -1 Then
								GoTo IL_329
							End If
							If <Module>.?ChangeConditionParameterVariable@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eParameter_Type@Script@@H@Z(Me.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, num2, <Module>.ScriptEditor.cVariable.GetVariableIndex(ptr4)) IsNot Nothing Then
								GoTo IL_366
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GArray<int>.{dtor}(gArray<int>)
						Return
						IL_329:
						Try
							Dim num13 As Integer
							If <Module>.?ChangeConditionParameterMember@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eParameter_Type@Script@@HH@Z(Me.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, num3, <Module>.ScriptEditor.cVariable.GetVariableIndex(ptr4), num13) IsNot Nothing Then
								GoTo IL_366
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GArray<int>.{dtor}(gArray<int>)
						Return
						IL_366:
						<Module>.GArray<int>.{dtor}(gArray<int>)
						GoTo IL_524
						IL_372:
						Try
							Dim array As String() = New String(__Dereference((gArray<int> + 4)) - 1) {}
							Dim num14 As Integer = __Dereference(<Module>.ScriptEditor.cVariable.GetValue(ptr4))
							Dim num15 As Integer = 0
							If 0 < __Dereference((gArray<int> + 4)) Then
								Do
									array(num15) = New String(<Module>.GBaseString<char>..PBD(<Module>.ScriptEditor.cVariable.GetName(ptr4)))
									Dim num16 As Integer = __Dereference(<Module>.GArray<int>.[](gArray<int>, num15))
									If num16 <> -1 Then
										Dim ptr6 As __Pointer(Of sMemberInfo) = <Module>.?GetMember@ScriptEditor@@$$FYAABUsMemberInfo@1@W4eValue_Type@Script@@H@Z(num14, num16)
										array(num15) = array(num15) + New String(CType((AddressOf <Module>.??_C@_01LFCBOECM@?4?$AA@), __Pointer(Of SByte))) + New String(__Dereference(ptr6))
									End If
									num15 += 1
								Loop While num15 < __Dereference((gArray<int> + 4))
							End If
							Me.ActionListTreeControl.StartListSelecting(array)
							Me.ActionListTreeControl.Focus()
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GArray<int>.{dtor}(gArray<int>)
						Return
					End If
					Dim gArray<int>2 As GArray<int>
					<Module>.GArray<int>.{ctor}(gArray<int>2)
					Try
						If <Module>.ScriptEditor.cEditor.GetActionParameterChangePossibilities(Me.Editor, ptr2, actionIndex, parameterIndex, ptr4, gArray<int>2) IsNot Nothing Then
							GoTo IL_464
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
						Throw
					End Try
					<Module>.GArray<int>.{dtor}(gArray<int>2)
					Return
					IL_464:
					Try
						If __Dereference((gArray<int>2 + 4)) <> 0 Then
							GoTo IL_48A
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
						Throw
					End Try
					<Module>.GArray<int>.{dtor}(gArray<int>2)
					Return
					IL_48A:
					Try
						If __Dereference((gArray<int>2 + 4)) <> 1 Then
							GoTo IL_55B
						End If
						Dim num17 As Integer = __Dereference(<Module>.GArray<int>.[](gArray<int>2, 0))
						If num17 <> -1 Then
							GoTo IL_4E2
						End If
						If <Module>.?ChangeActionParameterVariable@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eParameter_Type@Script@@H@Z(Me.Editor, ptr2, actionIndex, parameterIndex, num2, <Module>.ScriptEditor.cVariable.GetVariableIndex(ptr4)) IsNot Nothing Then
							GoTo IL_51D
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
						Throw
					End Try
					<Module>.GArray<int>.{dtor}(gArray<int>2)
					Return
					IL_4E2:
					Try
						Dim num17 As Integer
						If <Module>.?ChangeActionParameterMember@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eParameter_Type@Script@@HH@Z(Me.Editor, ptr2, actionIndex, parameterIndex, num3, <Module>.ScriptEditor.cVariable.GetVariableIndex(ptr4), num17) IsNot Nothing Then
							GoTo IL_51D
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
						Throw
					End Try
					<Module>.GArray<int>.{dtor}(gArray<int>2)
					Return
					IL_51D:
					<Module>.GArray<int>.{dtor}(gArray<int>2)
					GoTo IL_524
					IL_55B:
					Try
						Dim array2 As String() = New String(__Dereference((gArray<int>2 + 4)) - 1) {}
						Dim num18 As Integer = __Dereference(<Module>.ScriptEditor.cVariable.GetValue(ptr4))
						Dim num19 As Integer = 0
						If 0 < __Dereference((gArray<int>2 + 4)) Then
							Do
								array2(num19) = New String(<Module>.GBaseString<char>..PBD(<Module>.ScriptEditor.cVariable.GetName(ptr4)))
								Dim num20 As Integer = __Dereference(<Module>.GArray<int>.[](gArray<int>2, num19))
								If num20 <> -1 Then
									Dim ptr7 As __Pointer(Of sMemberInfo) = <Module>.?GetMember@ScriptEditor@@$$FYAABUsMemberInfo@1@W4eValue_Type@Script@@H@Z(num18, num20)
									array2(num19) = array2(num19) + New String(CType((AddressOf <Module>.??_C@_01LFCBOECM@?4?$AA@), __Pointer(Of SByte))) + New String(__Dereference(ptr7))
								End If
								num19 += 1
							Loop While num19 < __Dereference((gArray<int>2 + 4))
						End If
						Me.ActionListTreeControl.StartListSelecting(array2)
						Me.ActionListTreeControl.Focus()
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
						Throw
					End Try
					<Module>.GArray<int>.{dtor}(gArray<int>2)
					Return
					IL_524:
					Me.Edit_Undo.Enabled = (<Module>.ScriptEditor.cEditor.HasUndo(Me.Editor) IsNot Nothing)
					Me.Edit_Redo.Enabled = (<Module>.ScriptEditor.cEditor.HasRedo(Me.Editor) IsNot Nothing)
					Me.RefreshAll()
				End If
			End If
		End Sub

		Private Sub ActionListTreeControl_DragEnter(sender As Object, e As DragEventArgs)
			e.Effect = DragDropEffects.Link
		End Sub

		Private Sub ActionListTreeControl_TextEditingRequest(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim mouseTargetNode As ActionListTreeControl_Node = actionListTreeControl.MouseTargetNode
				Dim mouseTargetTextElement As ActionListTreeControl_Node_TextElement = actionListTreeControl.MouseTargetTextElement
				Dim selectedIndex As Integer = globalTriggerControl.SelectedIndex
				Dim ptr As __Pointer(Of cTrigger) = <Module>.ScriptEditor.cEditor.GetTrigger(Me.Editor, selectedIndex)
				Dim actionIndex As Integer = mouseTargetNode.ActionIndex
				If actionIndex < <Module>.ScriptEditor.cTrigger.GetNumberOfActions(ptr) Then
					Dim ptr2 As __Pointer(Of cAction) = <Module>.ScriptEditor.cTrigger.GetAction(ptr, actionIndex)
					Dim parameterIndex As Integer = mouseTargetTextElement.ParameterIndex
					Dim s As String = "0"
					If Not mouseTargetNode.HeaderNode Then
						Dim cParameterInfoArray As cParameterInfoArray
						<Module>.ScriptEditor.cParameterInfoArray.{ctor}(cParameterInfoArray)
						Try
							Dim flag As Boolean
							If <Module>.ScriptEditor.cAction.GetParameterBaseType(ptr2, parameterIndex, cParameterInfoArray, flag) IsNot Nothing Then
								GoTo IL_F4A
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_F4A:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 2) Is Nothing Then
								GoTo IL_FDE
							End If
							Dim ptr3 As __Pointer(Of sParameter) = <Module>.ScriptEditor.cAction.GetParameter(ptr2, parameterIndex)
							If __Dereference(ptr3) = 1 Then
								If __Dereference((ptr3 + 4)) = 2 Then
									Dim gBaseString<char> As GBaseString<char>
									Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.sValue.GetAsEditingString(ptr3 + 4, AddressOf gBaseString<char>)
									Try
										s = New String(<Module>.GBaseString<char>..PBD(ptr4))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>)
								End If
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						GoTo IL_FCC
						IL_FDE:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 9) Is Nothing Then
								GoTo IL_106F
							End If
							Dim array As String() = New String(11) {}
							Dim num As Integer = 0
							Do
								array(num) = String.Format(New String(CType((AddressOf <Module>.??_C@_0M@OAEPIHCK@Player?5?$CD?$HL0?$HN?$AA@), __Pointer(Of SByte))), num + 1)
								num += 1
							Loop While num < 12
							Me.ActionListTreeControl.StartListSelecting(array)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 9
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_106F:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 21) Is Nothing Then
								GoTo IL_111A
							End If
							Dim array2 As String() = New String(3) {}
							Dim num2 As Integer = 0
							Do
								Dim gBaseString<char>2 As GBaseString<char>
								Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetUnitCategoryString(AddressOf gBaseString<char>2, num2)
								Try
									array2(num2) = New String(<Module>.GBaseString<char>..PBD(ptr5))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>2)
								num2 += 1
							Loop While num2 < 4
							Me.ActionListTreeControl.StartListSelecting(array2)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 21
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_111A:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 22) Is Nothing Then
								GoTo IL_11C5
							End If
							Dim array3 As String() = New String(3) {}
							Dim num3 As Integer = 0
							Do
								Dim gBaseString<char>3 As GBaseString<char>
								Dim ptr6 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetSupportTypeString(AddressOf gBaseString<char>3, num3)
								Try
									array3(num3) = New String(<Module>.GBaseString<char>..PBD(ptr6))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>3)
								num3 += 1
							Loop While num3 < 4
							Me.ActionListTreeControl.StartListSelecting(array3)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 22
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_11C5:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 1) Is Nothing Then
								GoTo IL_127E
							End If
							Dim array4 As String() = New String(1) {}
							Dim num4 As Integer = 0
							Do
								Dim sValue As sValue
								Dim gBaseString<char>4 As GBaseString<char>
								Dim ptr7 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.sValue.GetAsString(<Module>.??0sValue@ScriptEditor@@$$FQAE@W4eValue_Type@Script@@H@Z(sValue, 1, num4), AddressOf gBaseString<char>4, Me.Editor)
								Try
									array4(num4) = New String(<Module>.GBaseString<char>..PBD(ptr7))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>4)
								num4 += 1
							Loop While num4 < 2
							Me.ActionListTreeControl.StartListSelecting(array4)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 1
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_127E:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 13) Is Nothing Then
								GoTo IL_1389
							End If
							Dim num5 As Integer = 0
							Dim ptr8 As __Pointer(Of GEditorWorld) = <Module>.SafeWorld + 3436 / __SizeOf(GEditorWorld)
							Dim num6 As Integer = <Module>.GHeap<GWWeather>.GetNext(ptr8, -1)
							If num6 >= 0 Then
								Do
									num5 += 1
									num6 = <Module>.GHeap<GWWeather>.GetNext(ptr8, num6)
								Loop While num6 >= 0
								If num5 <> 0 Then
									GoTo IL_12EC
								End If
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_12EC:
						Try
							Dim num5 As Integer
							Dim array5 As String() = New String(num5 - 1) {}
							Dim num7 As Integer = 0
							Dim ptr8 As __Pointer(Of GEditorWorld)
							Dim num8 As Integer = <Module>.GHeap<GWWeather>.GetNext(ptr8, -1)
							If num8 >= 0 Then
								Do
									array5(num7) = New String(<Module>.GBaseString<char>..PBD(<Module>.GHeap<GWWeather>.[](ptr8, num8) + 8))
									num7 += 1
									ptr8 = <Module>.SafeWorld + 3436 / __SizeOf(GEditorWorld)
									num8 = <Module>.GHeap<GWWeather>.GetNext(ptr8, num8)
								Loop While num8 >= 0
							End If
							Me.ActionListTreeControl.StartListSelecting(array5)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 13
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1389:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 5) Is Nothing Then
								GoTo IL_14A3
							End If
							Dim newAssetPicker As NewAssetPicker = New NewAssetPicker(NewAssetPicker.ObjectType.UnitEditor, 30)
							newAssetPicker.Reset()
							If newAssetPicker.ShowDialog() = DialogResult.OK Then
								GoTo IL_13D9
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_13D9:
						Try
							Dim newAssetPicker As NewAssetPicker
							Dim gBaseString<char>5 As GBaseString<char>
							<Module>.GBaseString<char>.{ctor}(gBaseString<char>5, newAssetPicker.NewName)
							Dim num9 As Integer
							Try
								num9 = <Module>.ScriptEditor.cManager.RegisterUnitType(<Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld), gBaseString<char>5)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GBaseString<char>.{dtor}(gBaseString<char>5)
							If num9 <> -1 Then
								GoTo IL_1443
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1443:
						Try
							Dim num9 As Integer
							If <Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(Me.Editor, ptr, actionIndex, parameterIndex, 5, num9) IsNot Nothing Then
								GoTo IL_147A
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_147A:
						Try
							Me.RefreshTriggerData(ptr, 0)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_14A3:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 14) Is Nothing Then
								GoTo IL_15BF
							End If
							Dim newAssetPicker2 As NewAssetPicker = New NewAssetPicker(NewAssetPicker.ObjectType.UnitEditor, 28)
							newAssetPicker2.Reset()
							If newAssetPicker2.ShowDialog() = DialogResult.OK Then
								GoTo IL_14F4
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_14F4:
						Try
							Dim newAssetPicker2 As NewAssetPicker
							Dim gBaseString<char>6 As GBaseString<char>
							<Module>.GBaseString<char>.{ctor}(gBaseString<char>6, newAssetPicker2.NewName)
							Dim num10 As Integer
							Try
								num10 = <Module>.ScriptEditor.cManager.RegisterEffectName(<Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld), gBaseString<char>6)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GBaseString<char>.{dtor}(gBaseString<char>6)
							If num10 <> -1 Then
								GoTo IL_155E
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_155E:
						Try
							Dim num10 As Integer
							If <Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(Me.Editor, ptr, actionIndex, parameterIndex, 14, num10) IsNot Nothing Then
								GoTo IL_1596
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1596:
						Try
							Me.RefreshTriggerData(ptr, 0)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_15BF:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 10) Is Nothing Then
								GoTo IL_1674
							End If
							Dim editor As __Pointer(Of cEditor) = Me.Editor
							Dim array6 As String() = New String(<Module>.ScriptEditor.cEditor.GetNumberOfTriggers(editor) - 1) {}
							Dim num11 As Integer = 0
							If 0 < <Module>.ScriptEditor.cEditor.GetNumberOfTriggers(editor) Then
								Do
									array6(num11) = New String(<Module>.GBaseString<char>..PBD(<Module>.ScriptEditor.cTrigger.GetName(<Module>.ScriptEditor.cEditor.GetTrigger(Me.Editor, num11))))
									num11 += 1
								Loop While num11 < <Module>.ScriptEditor.cEditor.GetNumberOfTriggers(Me.Editor)
							End If
							Me.ActionListTreeControl.StartListSelecting(array6)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 10
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1674:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 17) Is Nothing Then
								GoTo IL_172D
							End If
							Dim num12 As Integer = <Module>.ScriptEditor.GetAIGroup_Behaviour_MAX()
							Dim array7 As String() = New String(num12 - 1) {}
							Dim num13 As Integer = 0
							If 0 < num12 Then
								Do
									Dim gBaseString<char>7 As GBaseString<char>
									Dim ptr9 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetAIGroup_BehaviourAsString(AddressOf gBaseString<char>7, num13)
									Try
										array7(num13) = New String(<Module>.GBaseString<char>..PBD(ptr9))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>7), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>7)
									num13 += 1
								Loop While num13 < num12
							End If
							Me.ActionListTreeControl.StartListSelecting(array7)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 17
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_172D:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 18) Is Nothing Then
								GoTo IL_17E6
							End If
							Dim num14 As Integer = <Module>.ScriptEditor.GetAIGroup_Bravery_MAX()
							Dim array8 As String() = New String(num14 - 1) {}
							Dim num15 As Integer = 0
							If 0 < num14 Then
								Do
									Dim gBaseString<char>8 As GBaseString<char>
									Dim ptr10 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetAIGroup_BraveryAsString(AddressOf gBaseString<char>8, num15)
									Try
										array8(num15) = New String(<Module>.GBaseString<char>..PBD(ptr10))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>8), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>8)
									num15 += 1
								Loop While num15 < num14
							End If
							Me.ActionListTreeControl.StartListSelecting(array8)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 18
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_17E6:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 19) Is Nothing Then
								GoTo IL_189F
							End If
							Dim num16 As Integer = <Module>.ScriptEditor.GetAIGroup_Helps_MAX()
							Dim array9 As String() = New String(num16 - 1) {}
							Dim num17 As Integer = 0
							If 0 < num16 Then
								Do
									Dim gBaseString<char>9 As GBaseString<char>
									Dim ptr11 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetAIGroup_HelpsAsString(AddressOf gBaseString<char>9, num17)
									Try
										array9(num17) = New String(<Module>.GBaseString<char>..PBD(ptr11))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>9), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>9)
									num17 += 1
								Loop While num17 < num16
							End If
							Me.ActionListTreeControl.StartListSelecting(array9)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 19
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_189F:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 20) Is Nothing Then
								GoTo IL_1958
							End If
							Dim num18 As Integer = <Module>.ScriptEditor.GetUnit_Behaviour_MAX()
							Dim array10 As String() = New String(num18 - 1) {}
							Dim num19 As Integer = 0
							If 0 < num18 Then
								Do
									Dim gBaseString<char>10 As GBaseString<char>
									Dim ptr12 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetUnit_BehaviourAsString(AddressOf gBaseString<char>10, num19)
									Try
										array10(num19) = New String(<Module>.GBaseString<char>..PBD(ptr12))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>10), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>10)
									num19 += 1
								Loop While num19 < num18
							End If
							Me.ActionListTreeControl.StartListSelecting(array10)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 20
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1958:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 24) Is Nothing Then
								GoTo IL_1A03
							End If
							Dim array11 As String() = New String(2) {}
							Dim num20 As Integer = 0
							Do
								Dim gBaseString<char>11 As GBaseString<char>
								Dim ptr13 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetDisplayTypeString(AddressOf gBaseString<char>11, num20)
								Try
									array11(num20) = New String(<Module>.GBaseString<char>..PBD(ptr13))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>11), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>11)
								num20 += 1
							Loop While num20 < 3
							Me.ActionListTreeControl.StartListSelecting(array11)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 24
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1A03:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 25) Is Nothing Then
								GoTo IL_1AB0
							End If
							Dim array12 As String() = New String(10) {}
							Dim num21 As Integer = 0
							Do
								Dim gBaseString<char>12 As GBaseString<char>
								Dim ptr14 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetReinforcementString(AddressOf gBaseString<char>12, num21)
								Try
									array12(num21) = New String(<Module>.GBaseString<char>..PBD(ptr14))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>12), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>12)
								num21 += 1
							Loop While num21 < 11
							Me.ActionListTreeControl.StartListSelecting(array12)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 25
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1AB0:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 27) Is Nothing Then
								GoTo IL_1B5B
							End If
							Dim array13 As String() = New String(2) {}
							Dim num22 As Integer = 0
							Do
								Dim gBaseString<char>13 As GBaseString<char>
								Dim ptr15 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetMusicString(AddressOf gBaseString<char>13, num22)
								Try
									array13(num22) = New String(<Module>.GBaseString<char>..PBD(ptr15))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>13), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>13)
								num22 += 1
							Loop While num22 < 3
							Me.ActionListTreeControl.StartListSelecting(array13)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 27
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1B5B:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 28) Is Nothing Then
								GoTo IL_1C08
							End If
							Dim array14 As String() = New String(9) {}
							Dim num23 As Integer = 0
							Do
								Dim gBaseString<char>14 As GBaseString<char>
								Dim ptr16 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetGunnerString(AddressOf gBaseString<char>14, num23)
								Try
									array14(num23) = New String(<Module>.GBaseString<char>..PBD(ptr16))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>14), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>14)
								num23 += 1
							Loop While num23 < 10
							Me.ActionListTreeControl.StartListSelecting(array14)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 28
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1C08:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 29) Is Nothing Then
								GoTo IL_1CB3
							End If
							Dim array15 As String() = New String(2) {}
							Dim num24 As Integer = 0
							Do
								Dim gBaseString<char>15 As GBaseString<char>
								Dim ptr17 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetFormationString(AddressOf gBaseString<char>15, num24)
								Try
									array15(num24) = New String(<Module>.GBaseString<char>..PBD(ptr17))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>15), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>15)
								num24 += 1
							Loop While num24 < 3
							Me.ActionListTreeControl.StartListSelecting(array15)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 29
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1CB3:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray, 1, 30) Is Nothing Then
								GoTo IL_1D5D
							End If
							Dim array16 As String() = New String(58) {}
							Dim num25 As Integer = 0
							Do
								Dim gBaseString<char>16 As GBaseString<char>
								Dim ptr18 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetSpeechString(AddressOf gBaseString<char>16, num25)
								Try
									array16(num25) = New String(<Module>.GBaseString<char>..PBD(ptr18))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>16), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>16)
								num25 += 1
							Loop While num25 < 59
							Me.ActionListTreeControl.StartListSelecting(array16)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 30
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
						IL_1D5D:
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray)
						Return
					End If
					Dim conditionIndex As Integer = mouseTargetNode.ConditionIndex
					If conditionIndex < <Module>.ScriptEditor.cAction.GetNumberOfConditions(ptr2) Then
						Dim ptr19 As __Pointer(Of cCondition) = <Module>.ScriptEditor.cAction.GetCondition(ptr2, conditionIndex)
						Dim cParameterInfoArray2 As cParameterInfoArray
						<Module>.ScriptEditor.cParameterInfoArray.{ctor}(cParameterInfoArray2)
						Try
							Dim flag2 As Boolean
							If <Module>.ScriptEditor.cCondition.GetParameterBaseType(ptr19, parameterIndex, cParameterInfoArray2, flag2) IsNot Nothing Then
								GoTo IL_E9
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_E9:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 2) Is Nothing Then
								GoTo IL_174
							End If
							Dim ptr20 As __Pointer(Of sParameter) = <Module>.ScriptEditor.cCondition.GetParameter(ptr19, parameterIndex)
							If __Dereference(ptr20) = 1 Then
								If __Dereference((ptr20 + 4)) = 2 Then
									Dim gBaseString<char>17 As GBaseString<char>
									Dim ptr21 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.sValue.GetAsEditingString(ptr20 + 4, AddressOf gBaseString<char>17)
									Try
										s = New String(<Module>.GBaseString<char>..PBD(ptr21))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>17), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>17)
								End If
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						GoTo IL_FCC
						IL_174:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 5) Is Nothing Then
								GoTo IL_290
							End If
							Dim newAssetPicker3 As NewAssetPicker = New NewAssetPicker(NewAssetPicker.ObjectType.UnitEditor, 30)
							newAssetPicker3.Reset()
							If newAssetPicker3.ShowDialog() = DialogResult.OK Then
								GoTo IL_1C4
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_1C4:
						Try
							Dim newAssetPicker3 As NewAssetPicker
							Dim gBaseString<char>18 As GBaseString<char>
							<Module>.GBaseString<char>.{ctor}(gBaseString<char>18, newAssetPicker3.NewName)
							Dim num26 As Integer
							Try
								num26 = <Module>.ScriptEditor.cManager.RegisterUnitType(<Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld), gBaseString<char>18)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>18), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GBaseString<char>.{dtor}(gBaseString<char>18)
							If num26 <> -1 Then
								GoTo IL_22E
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_22E:
						Try
							Dim num26 As Integer
							If <Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(Me.Editor, ptr, actionIndex, conditionIndex, parameterIndex, 5, num26) IsNot Nothing Then
								GoTo IL_267
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_267:
						Try
							Me.RefreshTriggerData(ptr, 0)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_290:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 14) Is Nothing Then
								GoTo IL_3AE
							End If
							Dim newAssetPicker4 As NewAssetPicker = New NewAssetPicker(NewAssetPicker.ObjectType.UnitEditor, 28)
							newAssetPicker4.Reset()
							If newAssetPicker4.ShowDialog() = DialogResult.OK Then
								GoTo IL_2E1
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_2E1:
						Try
							Dim newAssetPicker4 As NewAssetPicker
							Dim gBaseString<char>19 As GBaseString<char>
							<Module>.GBaseString<char>.{ctor}(gBaseString<char>19, newAssetPicker4.NewName)
							Dim num27 As Integer
							Try
								num27 = <Module>.ScriptEditor.cManager.RegisterEffectName(<Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld), gBaseString<char>19)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>19), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GBaseString<char>.{dtor}(gBaseString<char>19)
							If num27 <> -1 Then
								GoTo IL_34B
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_34B:
						Try
							Dim num27 As Integer
							If <Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(Me.Editor, ptr, actionIndex, conditionIndex, parameterIndex, 14, num27) IsNot Nothing Then
								GoTo IL_385
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_385:
						Try
							Me.RefreshTriggerData(ptr, 0)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_3AE:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 9) Is Nothing Then
								GoTo IL_43F
							End If
							Dim array17 As String() = New String(11) {}
							Dim num28 As Integer = 0
							Do
								array17(num28) = String.Format(New String(CType((AddressOf <Module>.??_C@_0M@OAEPIHCK@Player?5?$CD?$HL0?$HN?$AA@), __Pointer(Of SByte))), num28 + 1)
								num28 += 1
							Loop While num28 < 12
							Me.ActionListTreeControl.StartListSelecting(array17)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 9
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_43F:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 21) Is Nothing Then
								GoTo IL_4EE
							End If
							Dim array18 As String() = New String(3) {}
							Dim num29 As Integer = 0
							Do
								Dim gBaseString<char>20 As GBaseString<char>
								Dim ptr22 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetUnitCategoryString(AddressOf gBaseString<char>20, num29)
								Try
									array18(num29) = New String(<Module>.GBaseString<char>..PBD(ptr22))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>20), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>20)
								num29 += 1
							Loop While num29 < 4
							Me.ActionListTreeControl.StartListSelecting(array18)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 21
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_4EE:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 22) Is Nothing Then
								GoTo IL_599
							End If
							Dim array19 As String() = New String(3) {}
							Dim num30 As Integer = 0
							Do
								Dim gBaseString<char>21 As GBaseString<char>
								Dim ptr23 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetSupportTypeString(AddressOf gBaseString<char>21, num30)
								Try
									array19(num30) = New String(<Module>.GBaseString<char>..PBD(ptr23))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>21), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>21)
								num30 += 1
							Loop While num30 < 4
							Me.ActionListTreeControl.StartListSelecting(array19)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 22
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_599:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 1) Is Nothing Then
								GoTo IL_652
							End If
							Dim array20 As String() = New String(1) {}
							Dim num31 As Integer = 0
							Do
								Dim sValue2 As sValue
								Dim gBaseString<char>22 As GBaseString<char>
								Dim ptr24 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.sValue.GetAsString(<Module>.??0sValue@ScriptEditor@@$$FQAE@W4eValue_Type@Script@@H@Z(sValue2, 1, num31), AddressOf gBaseString<char>22, Me.Editor)
								Try
									array20(num31) = New String(<Module>.GBaseString<char>..PBD(ptr24))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>22), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>22)
								num31 += 1
							Loop While num31 < 2
							Me.ActionListTreeControl.StartListSelecting(array20)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 1
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_652:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 13) Is Nothing Then
								GoTo IL_75D
							End If
							Dim num32 As Integer = 0
							Dim ptr25 As __Pointer(Of GEditorWorld) = <Module>.SafeWorld + 3436 / __SizeOf(GEditorWorld)
							Dim num33 As Integer = <Module>.GHeap<GWWeather>.GetNext(ptr25, -1)
							If num33 >= 0 Then
								Do
									num32 += 1
									num33 = <Module>.GHeap<GWWeather>.GetNext(ptr25, num33)
								Loop While num33 >= 0
								If num32 <> 0 Then
									GoTo IL_6C0
								End If
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_6C0:
						Try
							Dim num32 As Integer
							Dim array21 As String() = New String(num32 - 1) {}
							Dim num34 As Integer = 0
							Dim ptr25 As __Pointer(Of GEditorWorld)
							Dim num35 As Integer = <Module>.GHeap<GWWeather>.GetNext(ptr25, -1)
							If num35 >= 0 Then
								Do
									array21(num34) = New String(<Module>.GBaseString<char>..PBD(<Module>.GHeap<GWWeather>.[](ptr25, num35) + 8))
									num34 += 1
									ptr25 = <Module>.SafeWorld + 3436 / __SizeOf(GEditorWorld)
									num35 = <Module>.GHeap<GWWeather>.GetNext(ptr25, num35)
								Loop While num35 >= 0
							End If
							Me.ActionListTreeControl.StartListSelecting(array21)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 13
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_75D:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 10) Is Nothing Then
								GoTo IL_812
							End If
							Dim editor2 As __Pointer(Of cEditor) = Me.Editor
							Dim array22 As String() = New String(<Module>.ScriptEditor.cEditor.GetNumberOfTriggers(editor2) - 1) {}
							Dim num36 As Integer = 0
							If 0 < <Module>.ScriptEditor.cEditor.GetNumberOfTriggers(editor2) Then
								Do
									array22(num36) = New String(<Module>.GBaseString<char>..PBD(<Module>.ScriptEditor.cTrigger.GetName(<Module>.ScriptEditor.cEditor.GetTrigger(Me.Editor, num36))))
									num36 += 1
								Loop While num36 < <Module>.ScriptEditor.cEditor.GetNumberOfTriggers(Me.Editor)
							End If
							Me.ActionListTreeControl.StartListSelecting(array22)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 10
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_812:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 17) Is Nothing Then
								GoTo IL_8CB
							End If
							Dim num37 As Integer = <Module>.ScriptEditor.GetAIGroup_Behaviour_MAX()
							Dim array23 As String() = New String(num37 - 1) {}
							Dim num38 As Integer = 0
							If 0 < num37 Then
								Do
									Dim gBaseString<char>23 As GBaseString<char>
									Dim ptr26 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetAIGroup_BehaviourAsString(AddressOf gBaseString<char>23, num38)
									Try
										array23(num38) = New String(<Module>.GBaseString<char>..PBD(ptr26))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>23), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>23)
									num38 += 1
								Loop While num38 < num37
							End If
							Me.ActionListTreeControl.StartListSelecting(array23)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 17
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_8CB:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 18) Is Nothing Then
								GoTo IL_984
							End If
							Dim num39 As Integer = <Module>.ScriptEditor.GetAIGroup_Bravery_MAX()
							Dim array24 As String() = New String(num39 - 1) {}
							Dim num40 As Integer = 0
							If 0 < num39 Then
								Do
									Dim gBaseString<char>24 As GBaseString<char>
									Dim ptr27 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetAIGroup_BraveryAsString(AddressOf gBaseString<char>24, num40)
									Try
										array24(num40) = New String(<Module>.GBaseString<char>..PBD(ptr27))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>24), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>24)
									num40 += 1
								Loop While num40 < num39
							End If
							Me.ActionListTreeControl.StartListSelecting(array24)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 18
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_984:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 19) Is Nothing Then
								GoTo IL_A3D
							End If
							Dim num41 As Integer = <Module>.ScriptEditor.GetAIGroup_Helps_MAX()
							Dim array25 As String() = New String(num41 - 1) {}
							Dim num42 As Integer = 0
							If 0 < num41 Then
								Do
									Dim gBaseString<char>25 As GBaseString<char>
									Dim ptr28 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetAIGroup_HelpsAsString(AddressOf gBaseString<char>25, num42)
									Try
										array25(num42) = New String(<Module>.GBaseString<char>..PBD(ptr28))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>25), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>25)
									num42 += 1
								Loop While num42 < num41
							End If
							Me.ActionListTreeControl.StartListSelecting(array25)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 19
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_A3D:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 20) Is Nothing Then
								GoTo IL_AF6
							End If
							Dim num43 As Integer = <Module>.ScriptEditor.GetUnit_Behaviour_MAX()
							Dim array26 As String() = New String(num43 - 1) {}
							Dim num44 As Integer = 0
							If 0 < num43 Then
								Do
									Dim gBaseString<char>26 As GBaseString<char>
									Dim ptr29 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetUnit_BehaviourAsString(AddressOf gBaseString<char>26, num44)
									Try
										array26(num44) = New String(<Module>.GBaseString<char>..PBD(ptr29))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>26), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>26)
									num44 += 1
								Loop While num44 < num43
							End If
							Me.ActionListTreeControl.StartListSelecting(array26)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 20
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_AF6:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 24) Is Nothing Then
								GoTo IL_BA1
							End If
							Dim array27 As String() = New String(2) {}
							Dim num45 As Integer = 0
							Do
								Dim gBaseString<char>27 As GBaseString<char>
								Dim ptr30 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetDisplayTypeString(AddressOf gBaseString<char>27, num45)
								Try
									array27(num45) = New String(<Module>.GBaseString<char>..PBD(ptr30))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>27), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>27)
								num45 += 1
							Loop While num45 < 3
							Me.ActionListTreeControl.StartListSelecting(array27)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 24
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_BA1:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 25) Is Nothing Then
								GoTo IL_C4E
							End If
							Dim array28 As String() = New String(10) {}
							Dim num46 As Integer = 0
							Do
								Dim gBaseString<char>28 As GBaseString<char>
								Dim ptr31 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetReinforcementString(AddressOf gBaseString<char>28, num46)
								Try
									array28(num46) = New String(<Module>.GBaseString<char>..PBD(ptr31))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>28), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>28)
								num46 += 1
							Loop While num46 < 11
							Me.ActionListTreeControl.StartListSelecting(array28)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 25
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_C4E:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 27) Is Nothing Then
								GoTo IL_CF9
							End If
							Dim array29 As String() = New String(2) {}
							Dim num47 As Integer = 0
							Do
								Dim gBaseString<char>29 As GBaseString<char>
								Dim ptr32 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetMusicString(AddressOf gBaseString<char>29, num47)
								Try
									array29(num47) = New String(<Module>.GBaseString<char>..PBD(ptr32))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>29), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>29)
								num47 += 1
							Loop While num47 < 3
							Me.ActionListTreeControl.StartListSelecting(array29)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 27
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_CF9:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 28) Is Nothing Then
								GoTo IL_DA6
							End If
							Dim array30 As String() = New String(9) {}
							Dim num48 As Integer = 0
							Do
								Dim gBaseString<char>30 As GBaseString<char>
								Dim ptr33 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetGunnerString(AddressOf gBaseString<char>30, num48)
								Try
									array30(num48) = New String(<Module>.GBaseString<char>..PBD(ptr33))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>30), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>30)
								num48 += 1
							Loop While num48 < 10
							Me.ActionListTreeControl.StartListSelecting(array30)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 28
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_DA6:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 29) Is Nothing Then
								GoTo IL_E51
							End If
							Dim array31 As String() = New String(2) {}
							Dim num49 As Integer = 0
							Do
								Dim gBaseString<char>31 As GBaseString<char>
								Dim ptr34 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetFormationString(AddressOf gBaseString<char>31, num49)
								Try
									array31(num49) = New String(<Module>.GBaseString<char>..PBD(ptr34))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>31), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>31)
								num49 += 1
							Loop While num49 < 3
							Me.ActionListTreeControl.StartListSelecting(array31)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 29
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_E51:
						Try
							If <Module>.?IsCompatible@cParameterInfoArray@ScriptEditor@@$$FQBE_NW4eParameter_Type@Script@@W4eValue_Type@4@@Z(cParameterInfoArray2, 1, 30) Is Nothing Then
								GoTo IL_EFE
							End If
							Dim array32 As String() = New String(58) {}
							Dim num50 As Integer = 0
							Do
								Dim gBaseString<char>32 As GBaseString<char>
								Dim ptr35 As __Pointer(Of GBaseString<char>) = <Module>.Script.GetSpeechString(AddressOf gBaseString<char>32, num50)
								Try
									array32(num50) = New String(<Module>.GBaseString<char>..PBD(ptr35))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>32), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>32)
								num50 += 1
							Loop While num50 < 59
							Me.ActionListTreeControl.StartListSelecting(array32)
							Me.ActionListTreeControl.Focus()
							Me.DragType = ScriptEditorForm.eDragType.DRAG_MAX
							Me.ListSelection_ValueType = 30
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf ScriptEditor.cParameterInfoArray.{dtor}), CType((AddressOf cParameterInfoArray2), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
						IL_EFE:
						<Module>.ScriptEditor.cParameterInfoArray.{dtor}(cParameterInfoArray2)
						Return
					End If
					Return
					IL_FCC:
					Me.ActionListTreeControl.StartTextEditing(s)
				End If
			End If
		End Sub

		Private Sub ActionListTreeControl_TextEditingFinished(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim mouseTargetNode As ActionListTreeControl_Node = actionListTreeControl.MouseTargetNode
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim actionIndex As Integer = mouseTargetNode.ActionIndex
				If actionIndex < __Dereference((ptr + 40)) Then
					Dim parameterIndex As Integer = actionListTreeControl.MouseTargetTextElement.ParameterIndex
					Dim editedText As String = actionListTreeControl.EditedText
					Dim num As Integer = 0
					Dim num2 As Integer = 1
					Dim num3 As Integer = 0
					If editedText(0) = "-"c Then
						num2 = -1
						num3 = 1
					End If
					If num3 < editedText.Length Then
						While editedText(num3) >= "0"c AndAlso editedText(num3) <= "9"c
							num = num * 10 + CInt(editedText(num3)) - 48
							num3 += 1
							If num3 >= editedText.Length Then
								Exit While
							End If
						End While
					End If
					num = num2 * num
					If mouseTargetNode.HeaderNode Then
						Dim conditionIndex As Integer = mouseTargetNode.ConditionIndex
						If <Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(Me.Editor, ptr, actionIndex, conditionIndex, parameterIndex, 2, num) Is Nothing Then
							Return
						End If
					Else If <Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(Me.Editor, ptr, actionIndex, parameterIndex, 2, num) Is Nothing Then
						Return
					End If
					Dim num4 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num4) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num5 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num5) <> 0)
					Me.RefreshTriggerData(ptr, 0)
				End If
			End If
		End Sub

		Private Sub ActionListTreeControl_ListSelectingFinished(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim mouseTargetNode As ActionListTreeControl_Node = actionListTreeControl.MouseTargetNode
				Dim mouseTargetTextElement As ActionListTreeControl_Node_TextElement = actionListTreeControl.MouseTargetTextElement
				Dim arg_43_0 As Integer = globalTriggerControl.SelectedIndex
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim ptr As __Pointer(Of cEditor) = editor
				Dim ptr2 As __Pointer(Of cTrigger) = __Dereference((arg_43_0 * 4 + __Dereference((ptr + 28))))
				Dim actionIndex As Integer = mouseTargetNode.ActionIndex
				Dim num As Integer = __Dereference((ptr2 + 40))
				If actionIndex < num Then
					Dim parameterIndex As Integer = mouseTargetTextElement.ParameterIndex
					Dim dragType As ScriptEditorForm.eDragType = Me.DragType
					If dragType = ScriptEditorForm.eDragType.DRAG_MAX Then
						Dim num2 As Integer = actionListTreeControl.ListSelection_Selected
						Dim gBaseString<char> As GBaseString<char>
						<Module>.GBaseString<char>.{ctor}(gBaseString<char>, actionListTreeControl.EditedText)
						Try
							Me.ActionListTreeControl.StopListSelecting()
							Dim listSelection_ValueType As Integer = Me.ListSelection_ValueType
							If listSelection_ValueType <> 10 Then
								If listSelection_ValueType <> 13 Then
									If listSelection_ValueType = 19 Then
										num2 = 1 << num2
									End If
								Else
									num2 = -1
									Dim ptr3 As __Pointer(Of GEditorWorld) = <Module>.SafeWorld + 3436 / __SizeOf(GEditorWorld)
									Dim num3 As Integer = <Module>.GHeap<GWWeather>.GetNext(ptr3, -1)
									If num3 >= 0 Then
										While (If((<Module>.GBaseString<char>.Compare(__Dereference(CType(ptr3, __Pointer(Of Integer))) + num3 * 124 + 4 + 8, gBaseString<char>, False) = 0), 1, 0)) = 0
											ptr3 = <Module>.SafeWorld + 3436 / __SizeOf(GEditorWorld)
											num3 = <Module>.GHeap<GWWeather>.GetNext(ptr3, num3)
											If num3 < 0 Then
												GoTo IL_13A
											End If
										End While
										num2 = num3
									End If
								End If
							Else
								Dim editor2 As __Pointer(Of cEditor) = Me.Editor
								num2 = __Dereference((__Dereference((num2 * 4 + __Dereference((editor2 + 28)))) + 4))
							End If
							IL_13A:
							If Not mouseTargetNode.HeaderNode Then
								GoTo IL_18F
							End If
							Dim conditionIndex As Integer = mouseTargetNode.ConditionIndex
							If <Module>.?ChangeConditionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eValue_Type@Script@@H@Z(Me.Editor, ptr2, actionIndex, conditionIndex, parameterIndex, Me.ListSelection_ValueType, num2) IsNot Nothing Then
								GoTo IL_1CF
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							Return
						End If
						Return
						IL_18F:
						Try
							If <Module>.?ChangeActionParameterValue@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eValue_Type@Script@@H@Z(Me.Editor, ptr2, actionIndex, parameterIndex, Me.ListSelection_ValueType, num2) IsNot Nothing Then
								GoTo IL_1CF
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							Return
						End If
						Return
						IL_1CF:
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
						End If
					Else
						Dim eDragType As ScriptEditorForm.eDragType = dragType
						Dim ptr5 As __Pointer(Of cVariable)
						Dim num4 As Integer
						Dim num5 As Integer
						If eDragType <> ScriptEditorForm.eDragType.DRAG_GlobalVariable Then
							If eDragType <> ScriptEditorForm.eDragType.DRAG_LocalVariable Then
								If eDragType <> ScriptEditorForm.eDragType.DRAG_Entity Then
									Return
								End If
								Dim arg_208_0 As Integer = Me.DragIndex
								Dim ptr4 As __Pointer(Of cEditor) = editor
								ptr5 = __Dereference((arg_208_0 * 4 + __Dereference((ptr4 + 44))))
								num4 = 6
								num5 = 7
							Else
								ptr5 = __Dereference((Me.DragIndex * 4 + __Dereference((ptr2 + 24))))
								num4 = 3
								num5 = 5
							End If
						Else
							Dim arg_23D_0 As Integer = Me.DragIndex
							Dim ptr6 As __Pointer(Of cEditor) = editor
							ptr5 = __Dereference((arg_23D_0 * 4 + __Dereference((ptr6 + 12))))
							num4 = 2
							num5 = 4
						End If
						If mouseTargetNode.HeaderNode Then
							Dim conditionIndex2 As Integer = mouseTargetNode.ConditionIndex
							Dim listSelection_Selected As Integer = actionListTreeControl.ListSelection_Selected
							actionListTreeControl.StopListSelecting()
							Dim gArray<int> As GArray<int> = 0
							__Dereference((gArray<int> + 4)) = 0
							__Dereference((gArray<int> + 8)) = 0
							Try
								If <Module>.ScriptEditor.cEditor.GetConditionParameterChangePossibilities(Me.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, ptr5, gArray<int>) IsNot Nothing Then
									GoTo IL_2B6
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GArray<int>.{dtor}(gArray<int>)
							Return
							IL_2B6:
							Try
								If listSelection_Selected < __Dereference((gArray<int> + 4)) Then
									GoTo IL_2DE
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GArray<int>.{dtor}(gArray<int>)
							Return
							IL_2DE:
							Try
								Dim num6 As Integer = listSelection_Selected * 4 + gArray<int>
								If __Dereference(num6) <> -1 Then
									GoTo IL_32A
								End If
								Dim num7 As Integer = __Dereference(CType(ptr5, __Pointer(Of Integer)))
								If <Module>.?ChangeConditionParameterVariable@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eParameter_Type@Script@@H@Z(Me.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, num4, num7) IsNot Nothing Then
									GoTo IL_36B
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GArray<int>.{dtor}(gArray<int>)
							Return
							IL_32A:
							Try
								Dim num6 As Integer
								Dim ptr7 As __Pointer(Of Integer) = num6
								Dim num8 As Integer = __Dereference(CType(ptr5, __Pointer(Of Integer)))
								If <Module>.?ChangeConditionParameterMember@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHHW4eParameter_Type@Script@@HH@Z(Me.Editor, ptr2, actionIndex, conditionIndex2, parameterIndex, num5, num8, __Dereference(ptr7)) IsNot Nothing Then
									GoTo IL_36B
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GArray<int>.{dtor}(gArray<int>)
							Return
							IL_36B:
							<Module>.GArray<int>.{dtor}(gArray<int>)
						Else
							Dim listSelection_Selected2 As Integer = actionListTreeControl.ListSelection_Selected
							actionListTreeControl.StopListSelecting()
							Dim gArray<int>2 As GArray<int> = 0
							__Dereference((gArray<int>2 + 4)) = 0
							__Dereference((gArray<int>2 + 8)) = 0
							Try
								If <Module>.ScriptEditor.cEditor.GetActionParameterChangePossibilities(Me.Editor, ptr2, actionIndex, parameterIndex, ptr5, gArray<int>2) IsNot Nothing Then
									GoTo IL_3C9
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GArray<int>.{dtor}(gArray<int>2)
							Return
							IL_3C9:
							Try
								If listSelection_Selected2 < __Dereference((gArray<int>2 + 4)) Then
									GoTo IL_3F1
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GArray<int>.{dtor}(gArray<int>2)
							Return
							IL_3F1:
							Try
								Dim num9 As Integer = listSelection_Selected2 * 4 + gArray<int>2
								If __Dereference(num9) <> -1 Then
									GoTo IL_43B
								End If
								Dim num10 As Integer = __Dereference(CType(ptr5, __Pointer(Of Integer)))
								If <Module>.?ChangeActionParameterVariable@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eParameter_Type@Script@@H@Z(Me.Editor, ptr2, actionIndex, parameterIndex, num4, num10) IsNot Nothing Then
									GoTo IL_477
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GArray<int>.{dtor}(gArray<int>2)
							Return
							IL_43B:
							Try
								Dim num9 As Integer
								Dim ptr8 As __Pointer(Of Integer) = num9
								Dim num11 As Integer = __Dereference(CType(ptr5, __Pointer(Of Integer)))
								If <Module>.?ChangeActionParameterMember@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HHW4eParameter_Type@Script@@HH@Z(Me.Editor, ptr2, actionIndex, parameterIndex, num5, num11, __Dereference(ptr8)) IsNot Nothing Then
									GoTo IL_477
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>2), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GArray<int>.{dtor}(gArray<int>2)
							Return
							IL_477:
							<Module>.GArray<int>.{dtor}(gArray<int>2)
						End If
					End If
					Me.Edit_Undo.Enabled = (<Module>.ScriptEditor.cEditor.HasUndo(Me.Editor) IsNot Nothing)
					Me.Edit_Redo.Enabled = (<Module>.ScriptEditor.cEditor.HasRedo(Me.Editor) IsNot Nothing)
					Me.RefreshAll()
				End If
			End If
		End Sub

		Private Sub Actions_Insert_Click(sender As Object, e As EventArgs)
			If Me.AddActionButton.Enabled OrElse Me.AddConditionButton.Enabled Then
				Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
				If globalTriggerControl.SelectedIndex <> -1 Then
					Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
					Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
					If selectedNode IsNot Nothing AndAlso selectedNode.HeaderNode Then
						Dim num As Integer = __Dereference((Me.ConditionTypeBox.SelectedIndex * 4 + <Module>.ScriptEditor.ConditionTypeList))
						Dim actionIndex As Integer = selectedNode.ActionIndex
						If actionIndex >= __Dereference((ptr + 40)) Then
							Return
						End If
						Dim arg_A0_0 As __Pointer(Of cAction) = __Dereference((actionIndex * 4 + __Dereference((ptr + 36))))
						Dim conditionIndex As Integer = selectedNode.ConditionIndex
						If <Module>.?CreateCondition@cAction@ScriptEditor@@$$FQAEPAVcCondition@2@W4eCondition_Type@Script@@H@Z(arg_A0_0, num, conditionIndex) Is Nothing Then
							Return
						End If
					Else
						Dim num2 As Integer = __Dereference((Me.ActionTypeBox.SelectedIndex * 4 + <Module>.ScriptEditor.ActionTypeList))
						If num2 = 108 Then
							Return
						End If
						Dim num3 As Integer
						If selectedNode IsNot Nothing Then
							num3 = selectedNode.ActionIndex
						Else
							num3 = 0
						End If
						If <Module>.?CreateAction@cTrigger@ScriptEditor@@$$FQAEPAVcAction@2@W4eAction_Type@Script@@H@Z(ptr, num2, num3) Is Nothing Then
							Return
						End If
					End If
					Dim num4 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num4) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num5 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num5) <> 0)
					Me.RefreshTriggerData(ptr, 1)
				End If
			End If
		End Sub

		Private Sub Actions_Delete_Click(sender As Object, e As EventArgs)
			If Me.DeleteActionButton.Enabled OrElse Me.DeleteConditionButton.Enabled Then
				Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
				If globalTriggerControl.SelectedIndex <> -1 Then
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
					Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
					Dim selectedNode As ActionListTreeControl_Node = actionListTreeControl.SelectedNode
					Dim selectedNode_End As ActionListTreeControl_Node = actionListTreeControl.SelectedNode_End
					If selectedNode IsNot Nothing Then
						If selectedNode Is selectedNode_End Then
							If selectedNode.HeaderNode Then
								Dim actionIndex As Integer = selectedNode.ActionIndex
								Dim conditionIndex As Integer = selectedNode.ConditionIndex
								If <Module>.ScriptEditor.cEditor.DeleteCondition(editor, ptr, actionIndex, conditionIndex) Is Nothing Then
									Return
								End If
							Else If <Module>.ScriptEditor.cTrigger.DeleteAction(ptr, selectedNode.ActionIndex, False) Is Nothing Then
								Return
							End If
						Else
							Dim actionIndex2 As Integer
							Dim actionIndex3 As Integer
							If selectedNode.ActionIndex <= selectedNode_End.ActionIndex Then
								actionIndex2 = selectedNode.ActionIndex
								actionIndex3 = selectedNode_End.ActionIndex
							Else
								actionIndex3 = selectedNode.ActionIndex
								actionIndex2 = selectedNode_End.ActionIndex
							End If
							If <Module>.ScriptEditor.cTrigger.DeleteActionRange(ptr, actionIndex2, actionIndex3) Is Nothing Then
								Return
							End If
						End If
						Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
						Me.Edit_Undo.Enabled = (CByte(num) <> 0)
						Dim editor2 As __Pointer(Of cEditor) = Me.Editor
						Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
						Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
						Me.RefreshTriggerData(ptr, 0)
					End If
				End If
			End If
		End Sub

		Private Sub AddActionButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
				If selectedNode Is Nothing OrElse Not selectedNode.HeaderNode Then
					Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
					Dim num As Integer = __Dereference((Me.ActionTypeBox.SelectedIndex * 4 + <Module>.ScriptEditor.ActionTypeList))
					If num <> 108 Then
						Dim num2 As Integer
						If selectedNode IsNot Nothing Then
							num2 = selectedNode.ActionIndex
						Else
							num2 = 0
						End If
						If <Module>.?CreateAction@cTrigger@ScriptEditor@@$$FQAEPAVcAction@2@W4eAction_Type@Script@@H@Z(ptr, num, num2) IsNot Nothing Then
							Dim num3 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
							Me.Edit_Undo.Enabled = (CByte(num3) <> 0)
							Dim editor As __Pointer(Of cEditor) = Me.Editor
							Dim num4 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
							Me.Edit_Redo.Enabled = (CByte(num4) <> 0)
							Me.RefreshAll()
							Me.RefreshTriggerData(ptr, 1)
						End If
					End If
				End If
			End If
		End Sub

		Private Sub DeleteActionButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim actionListTreeControl As Script_ActionListTreeControl = Me.ActionListTreeControl
				Dim selectedNode As ActionListTreeControl_Node = actionListTreeControl.SelectedNode
				Dim selectedNode_End As ActionListTreeControl_Node = actionListTreeControl.SelectedNode_End
				If selectedNode IsNot Nothing Then
					If selectedNode Is selectedNode_End Then
						If selectedNode.HeaderNode OrElse <Module>.ScriptEditor.cTrigger.DeleteAction(ptr, selectedNode.ActionIndex, False) Is Nothing Then
							Return
						End If
					Else
						Dim actionIndex As Integer
						Dim actionIndex2 As Integer
						If selectedNode.ActionIndex <= selectedNode_End.ActionIndex Then
							actionIndex = selectedNode.ActionIndex
							actionIndex2 = selectedNode_End.ActionIndex
						Else
							actionIndex2 = selectedNode.ActionIndex
							actionIndex = selectedNode_End.ActionIndex
						End If
						If <Module>.ScriptEditor.cTrigger.DeleteActionRange(ptr, actionIndex, actionIndex2) Is Nothing Then
							Return
						End If
					End If
					Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
					Me.RefreshAll()
				End If
			End If
		End Sub

		Private Sub DeletActionBlockButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing AndAlso Not selectedNode.HeaderNode AndAlso <Module>.ScriptEditor.cTrigger.DeleteActionBlock(ptr, selectedNode.ActionIndex) IsNot Nothing Then
					Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
					Me.RefreshAll()
				End If
			End If
		End Sub

		Private Sub DeleteActionPartButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing AndAlso Not selectedNode.HeaderNode AndAlso <Module>.ScriptEditor.cTrigger.DeleteActionPart(ptr, selectedNode.ActionIndex) IsNot Nothing Then
					Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
					Me.RefreshAll()
				End If
			End If
		End Sub

		Private Sub AddConditionButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing AndAlso selectedNode.HeaderNode Then
					Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
					Dim num As Integer = __Dereference((Me.ConditionTypeBox.SelectedIndex * 4 + <Module>.ScriptEditor.ConditionTypeList))
					If num <> 24 Then
						Dim actionIndex As Integer = selectedNode.ActionIndex
						If actionIndex < __Dereference((ptr + 40)) Then
							Dim arg_8C_0 As __Pointer(Of cAction) = __Dereference((actionIndex * 4 + __Dereference((ptr + 36))))
							Dim conditionIndex As Integer = selectedNode.ConditionIndex
							If <Module>.?CreateCondition@cAction@ScriptEditor@@$$FQAEPAVcCondition@2@W4eCondition_Type@Script@@H@Z(arg_8C_0, num, conditionIndex) IsNot Nothing Then
								Dim num2 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
								Me.Edit_Undo.Enabled = (CByte(num2) <> 0)
								Dim editor As __Pointer(Of cEditor) = Me.Editor
								Dim num3 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
								Me.Edit_Redo.Enabled = (CByte(num3) <> 0)
								Me.RefreshTriggerData(ptr, 1)
							End If
						End If
					End If
				End If
			End If
		End Sub

		Private Sub DeleteConditionButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing AndAlso selectedNode.HeaderNode Then
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
					Dim actionIndex As Integer = selectedNode.ActionIndex
					Dim conditionIndex As Integer = selectedNode.ConditionIndex
					If <Module>.ScriptEditor.cEditor.DeleteCondition(editor, ptr, actionIndex, conditionIndex) IsNot Nothing Then
						Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
						Me.Edit_Undo.Enabled = (CByte(num) <> 0)
						Dim editor2 As __Pointer(Of cEditor) = Me.Editor
						Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
						Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
						Me.RefreshAll()
					End If
				End If
			End If
		End Sub

		Private Sub DeleteConditionBlockButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing AndAlso selectedNode.HeaderNode Then
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
					Dim actionIndex As Integer = selectedNode.ActionIndex
					Dim conditionIndex As Integer = selectedNode.ConditionIndex
					If <Module>.ScriptEditor.cEditor.DeleteConditionBlock(editor, ptr, actionIndex, conditionIndex) IsNot Nothing Then
						Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
						Me.Edit_Undo.Enabled = (CByte(num) <> 0)
						Dim editor2 As __Pointer(Of cEditor) = Me.Editor
						Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
						Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
						Me.RefreshAll()
					End If
				End If
			End If
		End Sub

		Private Sub NegateConditionButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing AndAlso selectedNode.HeaderNode Then
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
					Dim actionIndex As Integer = selectedNode.ActionIndex
					Dim conditionIndex As Integer = selectedNode.ConditionIndex
					If <Module>.ScriptEditor.cEditor.NegateCondition(editor, ptr, actionIndex, conditionIndex) IsNot Nothing Then
						Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
						Me.Edit_Undo.Enabled = (CByte(num) <> 0)
						Dim editor2 As __Pointer(Of cEditor) = Me.Editor
						Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
						Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
						Me.RefreshTriggerData(ptr, 0)
					End If
				End If
			End If
		End Sub

		Private Sub InsertSingleOrConditionButton_Click(sender As Object, e As EventArgs)
			Dim globalTriggerControl As Script_GlobalVariableControl = Me.GlobalTriggerControl
			If globalTriggerControl.SelectedIndex <> -1 Then
				Dim selectedNode As ActionListTreeControl_Node = Me.ActionListTreeControl.SelectedNode
				If selectedNode IsNot Nothing AndAlso selectedNode.HeaderNode Then
					Dim ptr As __Pointer(Of cTrigger) = __Dereference((globalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
					Dim conditionIndex As Integer = selectedNode.ConditionIndex
					If <Module>.ScriptEditor.cAction.InsertSingleOrCondition(__Dereference((selectedNode.ActionIndex * 4 + __Dereference((ptr + 36)))), conditionIndex) IsNot Nothing Then
						Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
						Me.Edit_Undo.Enabled = (CByte(num) <> 0)
						Dim editor As __Pointer(Of cEditor) = Me.Editor
						Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
						Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
						Me.RefreshTriggerData(ptr, 0)
					End If
				End If
			End If
		End Sub

		Private Sub TriggerVariableControl_DragStarted(sender As Object, e As EventArgs)
			Me.DragType = ScriptEditorForm.eDragType.DRAG_LocalVariable
			Dim triggerVariableControl As Script_GlobalVariableControl = Me.TriggerVariableControl
			Dim selectedIndex As Integer = triggerVariableControl.SelectedIndex
			Me.DragIndex = selectedIndex
			triggerVariableControl.DoDragDrop(selectedIndex, DragDropEffects.Link)
		End Sub

		Private Sub TriggerVariableControl_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim triggerVariableControl As Script_GlobalVariableControl = Me.TriggerVariableControl
			If triggerVariableControl.SelectedIndex <> -1 Then
				If triggerVariableControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((triggerVariableControl.SelectedIndex + 1 < __Dereference((__Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer))))) + 28))), 1, 0)
					Me.TriggerVariable_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.TriggerVariableControl.SelectedIndex > 0), 1, 0)
					Me.TriggerVariable_MoveUp.Enabled = (enabled2 <> 0)
					Me.TriggerVariable_FixOrder.Enabled = False
				Else
					Me.TriggerVariable_MoveDown.Enabled = False
					Me.TriggerVariable_MoveUp.Enabled = False
					Me.TriggerVariable_FixOrder.Enabled = True
				End If
			End If
		End Sub

		Private Sub TriggerVariableControl_ItemDoubleClicked(sender As Object, e As EventArgs)
			Dim arg_0F_0 As Integer = Me.SelectedTriggerIndex
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			Dim ptr As __Pointer(Of cTrigger) = __Dereference((arg_0F_0 * 4 + __Dereference((editor + 28))))
			Dim clickedIndex As Integer = Me.TriggerVariableControl.ClickedIndex
			Dim ptr2 As __Pointer(Of cVariable) = __Dereference((clickedIndex * 4 + __Dereference((ptr + 24))))
			Dim scriptVariablePropertiesForm As ScriptVariablePropertiesForm = New ScriptVariablePropertiesForm()
			Dim location As Point = MyBase.Location
			scriptVariablePropertiesForm.Location.X = (location.X - scriptVariablePropertiesForm.Width) / 2
			Dim location2 As Point = MyBase.Location
			scriptVariablePropertiesForm.Location.Y = (location2.Y - scriptVariablePropertiesForm.Height) / 2
			scriptVariablePropertiesForm.SetFrom(Me.Editor, ptr, ptr2)
			If scriptVariablePropertiesForm.ShowDialog() = DialogResult.OK Then
				Dim num As Integer = <Module>.ScriptEditor.cEditor.BeginUndoBlock(Me.Editor)
				Dim variable_Type As Integer = scriptVariablePropertiesForm.Variable_Type
				If variable_Type <> 2 AndAlso __Dereference((ptr2 + 40)) <> 0 Then
					<Module>.?ChangeTriggerVariableAutoChangeMode@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HW4eAutoChange_Mode@cVariable@Script@@HH@Z(Me.Editor, ptr, clickedIndex, 0, 0, 0)
				End If
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>, scriptVariablePropertiesForm.Variable_Name)
				Try
					<Module>.ScriptEditor.cEditor.RenameTriggerVariable(Me.Editor, ptr, clickedIndex, gBaseString<char>)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				If <Module>.ScriptEditor.cVariable.IsConstant(ptr2) Is Nothing Then
					<Module>.?ChangeTriggerVariableType@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HW4eValue_Type@Script@@@Z(Me.Editor, ptr, clickedIndex, variable_Type)
					<Module>.ScriptEditor.cEditor.ChangeTriggerVariableValue(Me.Editor, ptr, clickedIndex, scriptVariablePropertiesForm.Variable_Value)
				End If
				If variable_Type = 2 Then
					<Module>.?ChangeTriggerVariableAutoChangeMode@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@HW4eAutoChange_Mode@cVariable@Script@@HH@Z(Me.Editor, ptr, clickedIndex, scriptVariablePropertiesForm.Variable_AutoChangeMode, scriptVariablePropertiesForm.Variable_AutoChange_Value, scriptVariablePropertiesForm.Variable_AutoChange_Period)
				End If
				<Module>.ScriptEditor.cEditor.EndUndoBlock(Me.Editor, num)
				Me.RefreshAll()
			End If
		End Sub

		Private Sub TriggerVariable_Create_Click(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
			Dim ptr2 As __Pointer(Of cVariable) = <Module>.ScriptEditor.cTrigger.CreateVariable(ptr)
			__Dereference(CType((ptr2 + 16 / __SizeOf(cVariable)), __Pointer(Of Integer))) = 2
			__Dereference(CType((ptr2 + 20 / __SizeOf(cVariable)), __Pointer(Of Integer))) = 0
			Me.RefreshTriggerVariables(ptr)
			Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
			Me.Edit_Undo.Enabled = (CByte(num) <> 0)
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
			Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
		End Sub

		Private Sub TriggerVariable_Delete_Click(sender As Object, e As EventArgs)
			Dim selectedIndex As Integer = Me.TriggerVariableControl.SelectedIndex
			If selectedIndex <> -1 Then
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				If <Module>.ScriptEditor.cEditor.DeleteTriggerVariable(editor, ptr, selectedIndex) IsNot Nothing Then
					Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num) <> 0)
					Dim editor2 As __Pointer(Of cEditor) = Me.Editor
					Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
					Me.RefreshAll()
				End If
			End If
		End Sub

		Private Sub TriggerVariableControl_SortModeChanged(sender As Object, e As EventArgs)
			Dim triggerVariableControl As Script_GlobalVariableControl = Me.TriggerVariableControl
			If triggerVariableControl.SelectedIndex <> -1 Then
				Dim num As Integer = __Dereference((__Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer))))) + 28))
				If num = 0 Then
					Me.TriggerVariable_MoveDown.Enabled = False
					Me.TriggerVariable_MoveUp.Enabled = False
					Me.TriggerVariable_FixOrder.Enabled = False
				Else If triggerVariableControl.IsInOriginalOrder() Then
					Dim enabled As Byte = If((triggerVariableControl.SelectedIndex + 1 < num), 1, 0)
					Me.TriggerVariable_MoveDown.Enabled = (enabled <> 0)
					Dim enabled2 As Byte = If((Me.TriggerVariableControl.SelectedIndex > 0), 1, 0)
					Me.TriggerVariable_MoveUp.Enabled = (enabled2 <> 0)
					Me.TriggerVariable_FixOrder.Enabled = False
				Else
					Me.TriggerVariable_MoveDown.Enabled = False
					Me.TriggerVariable_MoveUp.Enabled = False
					Me.TriggerVariable_FixOrder.Enabled = True
				End If
			End If
		End Sub

		Private Sub TriggerVariable_FixOrder_Click(sender As Object, e As EventArgs)
			Dim triggerVariableControl As Script_GlobalVariableControl = Me.TriggerVariableControl
			If triggerVariableControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				If Not triggerVariableControl.IsInOriginalOrder() Then
					Dim num As UInteger = CUInt(triggerVariableControl.SortIndices.Length)
					Dim ptr2 As __Pointer(Of Integer) = <Module>.new[](If((num > 1073741823UI), 4294967295UI, (num << 2)))
					Dim num2 As Integer = 0
					triggerVariableControl = Me.TriggerVariableControl
					If 0 < triggerVariableControl.SortIndices.Length Then
						Do
							num2(ptr2) = triggerVariableControl.SortIndices(num2)
							num2 += 1
							triggerVariableControl = Me.TriggerVariableControl
						Loop While num2 < triggerVariableControl.SortIndices.Length
					End If
					Dim flag As Boolean = <Module>.ScriptEditor.cTrigger.FixVariableOrder(ptr, CType(ptr2, __Pointer(Of Integer)), Me.TriggerVariableControl.SortIndices.Length) IsNot Nothing
					<Module>.delete[](CType(ptr2, __Pointer(Of Void)))
					If flag Then
						Dim num3 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
						Me.Edit_Undo.Enabled = (CByte(num3) <> 0)
						Dim editor As __Pointer(Of cEditor) = Me.Editor
						Dim num4 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
						Me.Edit_Redo.Enabled = (CByte(num4) <> 0)
						Me.RefreshTriggerVariables(ptr)
						Me.TriggerVariableControl.ForceUnsorted()
					End If
				End If
			End If
		End Sub

		Private Sub TriggerVariable_MoveUp_Click(sender As Object, e As EventArgs)
			Dim triggerVariableControl As Script_GlobalVariableControl = Me.TriggerVariableControl
			If triggerVariableControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				If triggerVariableControl.IsInOriginalOrder() AndAlso <Module>.ScriptEditor.cTrigger.MoveVariableUp(ptr, triggerVariableControl.SelectedIndex) IsNot Nothing Then
					Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
					Me.RefreshTriggerVariables(ptr)
					triggerVariableControl = Me.TriggerVariableControl
					triggerVariableControl.SelectedIndex -= 1
				End If
			End If
		End Sub

		Private Sub TriggerVariable_MoveDown_Click(sender As Object, e As EventArgs)
			Dim triggerVariableControl As Script_GlobalVariableControl = Me.TriggerVariableControl
			If triggerVariableControl.SelectedIndex <> -1 Then
				Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.SelectedTriggerIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
				If triggerVariableControl.IsInOriginalOrder() AndAlso <Module>.ScriptEditor.cTrigger.MoveVariableDown(ptr, triggerVariableControl.SelectedIndex) IsNot Nothing Then
					Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
					Me.Edit_Undo.Enabled = (CByte(num) <> 0)
					Dim editor As __Pointer(Of cEditor) = Me.Editor
					Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
					Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
					Me.RefreshTriggerVariables(ptr)
					triggerVariableControl = Me.TriggerVariableControl
					triggerVariableControl.SelectedIndex += 1
				End If
			End If
		End Sub

		Private Sub Script_Close_Click(sender As Object, e As EventArgs)
			Me.SaveScript()
			MyBase.Close()
		End Sub

		Private Sub TriggerEventBox_InPlace_SelectionCancel(sender As Object, e As EventArgs)
			sender.Dispose()
			Me.GlobalTriggerControl.Focus()
		End Sub

		Private Sub TriggerEventBox_InPlace_SelectionReady(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of cTrigger) = __Dereference((Me.GlobalTriggerControl.SelectedIndex * 4 + __Dereference(CType((Me.Editor + 28 / __SizeOf(cEditor)), __Pointer(Of Integer)))))
			Dim num As Integer = __Dereference((sender.SelectedIndex * 4 + <Module>.ScriptEditor.EventTypeList))
			If <Module>.?SetTriggerEventType@cEditor@ScriptEditor@@$$FQAE_NAAVcTrigger@2@W4eEvent_Type@Script@@@Z(Me.Editor, ptr, num) IsNot Nothing Then
				Dim num2 As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num2) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num3 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num3) <> 0)
				Me.RefreshTriggers()
				Me.RefreshTriggerData(ptr, 0)
				sender.Dispose()
				Me.GlobalTriggerControl.Focus()
			End If
		End Sub

		Private Sub TriggerNameBox_InPlace_EditingCancel(sender As Object, e As EventArgs)
			sender.Dispose()
			Me.GlobalTriggerControl.Focus()
		End Sub

		Private Sub TriggerNameBox_InPlace_EditingReady(sender As Object, e As EventArgs)
			Dim arg_14_0 As Integer = Me.GlobalTriggerControl.SelectedIndex
			Dim editor As __Pointer(Of cEditor) = Me.Editor
			Dim ptr As __Pointer(Of cTrigger) = __Dereference((arg_14_0 * 4 + __Dereference((editor + 28))))
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, sender.Text)
			Dim flag As Boolean
			Try
				flag = ((If((<Module>.GBaseString<char>.Compare(ptr + 8, ptr2, False) <> 0), 1, 0)) <> 0)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			If flag Then
				Dim gBaseString<char>2 As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>2, sender.Text)
				Dim flag2 As Boolean
				Try
					flag2 = ((If((<Module>.ScriptEditor.cEditor.RenameTrigger(Me.Editor, ptr, gBaseString<char>2) = 0), 1, 0)) <> 0)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
				End If
				If flag2 Then
					Return
				End If
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor2 As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor2 + 68)) < __Dereference((editor2 + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
				Me.RefreshTriggers()
				Me.RefreshTriggerData(ptr, 0)
			End If
			sender.Dispose()
			Me.GlobalTriggerControl.Focus()
		End Sub

		Private Sub Edit_Undo_Click(sender As Object, e As EventArgs)
			If <Module>.ScriptEditor.cEditor.Undo(Me.Editor) IsNot Nothing Then
				Me.RefreshAll()
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
			End If
		End Sub

		Private Sub Edit_Redo_Click(sender As Object, e As EventArgs)
			If <Module>.ScriptEditor.cEditor.Redo(Me.Editor) IsNot Nothing Then
				Me.RefreshAll()
				Dim num As Integer = If((__Dereference(CType((Me.Editor + 68 / __SizeOf(cEditor)), __Pointer(Of Integer))) > 0), 1, 0)
				Me.Edit_Undo.Enabled = (CByte(num) <> 0)
				Dim editor As __Pointer(Of cEditor) = Me.Editor
				Dim num2 As Integer = If((__Dereference((editor + 68)) < __Dereference((editor + 60))), 1, 0)
				Me.Edit_Redo.Enabled = (CByte(num2) <> 0)
			End If
		End Sub

		Private Function GetEditor(index As Integer) As __Pointer(Of cEditor)
			Dim scriptIndex As Integer = Me.ScriptIndex
			Dim ptr As __Pointer(Of cManager) = <Module>.SafeWorld + 5128 / __SizeOf(GEditorWorld)
			Dim result As __Pointer(Of cEditor)
			If scriptIndex >= __Dereference((__Dereference(ptr) + 4)) Then
				result = Nothing
			Else If __Dereference((__Dereference((ptr + 12)) + scriptIndex * 4)) = 0 AndAlso <Module>.ScriptEditor.cManager.LoadEditor(ptr, scriptIndex) Is Nothing Then
				result = Nothing
			Else
				result = __Dereference((__Dereference((ptr + 12)) + scriptIndex * 4))
			End If
			Return result
		End Function

		Public Sub EditorsChanged()
			Me.RefreshAll()
		End Sub
	End Class
End Namespace
