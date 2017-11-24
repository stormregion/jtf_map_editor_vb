Imports NControls
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NGameVariablesEditor
		Inherits Form

		Public Delegate Sub __Delegate_PUnitChanged( As __Pointer(Of SByte))

		Protected ToolWindows As ArrayList

		Protected ToolWindowIdx As Integer

		Protected FileDialog As NFileDialog

		Protected FileName As String

		Protected Modified As Boolean

		Private menuGameVariablesEditor As MainMenu

		Private menuFile As MenuItem

		Private menuFileSave As MenuItem

		Private menuFileClose As MenuItem

		Private menuFileSeparator2 As MenuItem

		Private menuEdit As MenuItem

		Private menuEditUndo As MenuItem

		Private menuEditRedo As MenuItem

		Private menuItem1 As MenuItem

		Private menuItem2 As MenuItem

		Private panel1 As Panel

		Private components As IContainer

		Private tbMain As Toolbar

		Private GameVarsPropTree As PropertyTree

		Private UndoArray As __Pointer(Of GArray<GStreamBuffer>)

		Private UndoIndex As Integer

		Private SavedIndex As Integer

		Public Custom Event PUnitChanged As NGameVariablesEditor.__Delegate_PUnitChanged
			AddHandler
				Me.PUnitChanged = [Delegate].Combine(Me.PUnitChanged, value)
			End AddHandler
			RemoveHandler
				Me.PUnitChanged = [Delegate].Remove(Me.PUnitChanged, value)
			End RemoveHandler
		End Event

		Public Sub New(toolwindows As ArrayList)
			Me.PUnitChanged = Nothing
			Me.InitializeComponent()
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0NGameVariablesEditor@NWorkshop@@Q$AAM@P$AAVArrayList@Collections@System@@@Z@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Me.tbMain = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.tbMain.ButtonClick, AddressOf Me.tbGameVariablesEditor_ButtonClick
			MyBase.Controls.Add(Me.tbMain)
			Dim propertyTree As PropertyTree = New PropertyTree(2, NewAssetPicker.ObjectType.GameVariablesEditor, Nothing)
			Me.GameVarsPropTree = propertyTree
			Me.panel1.Controls.Add(propertyTree)
			Me.GameVarsPropTree.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.GameVarsPropTree.Location = location
			Me.GameVarsPropTree.Name = "GameVarsPropTree"
			Dim size As Size = New Size(250, 435)
			Me.GameVarsPropTree.Size = size
			Me.GameVarsPropTree.TabIndex = 0
			Me.GameVarsPropTree.Text = "GameVarsPropTree"
			AddHandler Me.GameVarsPropTree.ItemChanged, AddressOf Me.GameVarsPropTree_ItemChanged
			Me.ToolWindows = toolwindows
			toolwindows.Add(Me)
			Me.Modified = False
			Me.UpdateWindowText()
			Me.tbMain.SetItemEnable(202, False)
			Me.tbMain.SetItemEnable(203, False)
			Me.tbMain.SetItemEnable(204, False)
			Me.tbMain.SetItemEnable(205, False)
			Me.tbMain.SetItemEnable(206, False)
			Me.tbMain.SetItemEnable(207, False)
			Me.tbMain.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = False
			Me.menuEditRedo.Enabled = False
			Me.menuFileSave.Enabled = False
			Dim ptr As __Pointer(Of GArray<GStreamBuffer>) = <Module>.new(12UI)
			Dim undoArray As __Pointer(Of GArray<GStreamBuffer>)
			Try
				If ptr IsNot Nothing Then
					__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr + 8 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) = 0
					undoArray = ptr
				Else
					undoArray = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.UndoArray = undoArray
			Me.UndoIndex = 0
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
			Me.panel1 = New Panel()
			Me.menuGameVariablesEditor = New MainMenu()
			Me.menuFile = New MenuItem()
			Me.menuFileSave = New MenuItem()
			Me.menuFileSeparator2 = New MenuItem()
			Me.menuFileClose = New MenuItem()
			Me.menuEdit = New MenuItem()
			Me.menuEditUndo = New MenuItem()
			Me.menuEditRedo = New MenuItem()
			Me.menuItem1 = New MenuItem()
			Me.menuItem2 = New MenuItem()
			MyBase.SuspendLayout()
			Me.panel1.BorderStyle = BorderStyle.Fixed3D
			Me.panel1.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.panel1.Location = location
			Me.panel1.Name = "panel1"
			Dim size As Size = New Size(408, 457)
			Me.panel1.Size = size
			Me.panel1.TabIndex = 0
			Dim items As MenuItem() = New MenuItem() { Me.menuFile, Me.menuEdit, Me.menuItem1 }
			Me.menuGameVariablesEditor.MenuItems.AddRange(items)
			Me.menuFile.Index = 0
			Dim items2 As MenuItem() = New MenuItem() { Me.menuFileSave, Me.menuFileSeparator2, Me.menuFileClose }
			Me.menuFile.MenuItems.AddRange(items2)
			Me.menuFile.Text = "&File"
			Me.menuFileSave.Index = 0
			Me.menuFileSave.Shortcut = Shortcut.CtrlS
			Me.menuFileSave.Text = "&Save"
			AddHandler Me.menuFileSave.Click, AddressOf Me.menuFileSave_Click
			Me.menuFileSeparator2.Index = 1
			Me.menuFileSeparator2.Text = "-"
			Me.menuFileClose.Index = 2
			Me.menuFileClose.Shortcut = Shortcut.AltF4
			Me.menuFileClose.Text = "&Close"
			AddHandler Me.menuFileClose.Click, AddressOf Me.menuFileClose_Click
			Me.menuEdit.Index = 1
			Dim items3 As MenuItem() = New MenuItem() { Me.menuEditUndo, Me.menuEditRedo }
			Me.menuEdit.MenuItems.AddRange(items3)
			Me.menuEdit.Text = "&Edit"
			Me.menuEditUndo.Index = 0
			Me.menuEditUndo.Shortcut = Shortcut.CtrlZ
			Me.menuEditUndo.Text = "&Undo"
			AddHandler Me.menuEditUndo.Click, AddressOf Me.menuEditUndo_Click
			Me.menuEditRedo.Index = 1
			Me.menuEditRedo.Shortcut = Shortcut.CtrlR
			Me.menuEditRedo.Text = "&Redo"
			AddHandler Me.menuEditRedo.Click, AddressOf Me.menuEditRedo_Click
			Me.menuItem1.Index = 2
			Dim items4 As MenuItem() = New MenuItem() { Me.menuItem2 }
			Me.menuItem1.MenuItems.AddRange(items4)
			Me.menuItem1.Text = "&Help"
			Me.menuItem2.Enabled = False
			Me.menuItem2.Index = 0
			Me.menuItem2.Text = "RTFS ;)"
			Dim autoScaleBaseSize As Size = New Size(5, 14)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(408, 457)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.panel1)
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			MyBase.Menu = Me.menuGameVariablesEditor
			MyBase.Name = "NGameVariablesEditor"
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Game Variables"
			AddHandler MyBase.Closing, AddressOf Me.GameVariablesEditor_Closing
			AddHandler MyBase.Load, AddressOf Me.NGameVariablesEditor_Load
			AddHandler MyBase.Closed, AddressOf Me.GameVariablesEditor_Closed
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub NGameVariablesEditor_Load(sender As Object, e As EventArgs)
			Me.GameVarsPropTree.SetVariable(AddressOf <Module>.GRTT_GameVariables.Class_GGameVariables, CType((AddressOf <Module>.GameVariables), __Pointer(Of Void)), <Module>.Measures)
			Me.GameVarsPropTree.Focus()
			<Module>.GArray<GStreamBuffer>.Clear(Me.UndoArray, 0)
			Dim num As Integer = <Module>.GArray<GStreamBuffer>.Add(Me.UndoArray)
			Me.UndoIndex = num
			<Module>.GRTTI.SaveVariablesAsText(num * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_GameVariables.Class_GGameVariables, CType((AddressOf <Module>.GameVariables), __Pointer(Of Void)), <Module>.Measures)
			Me.SavedIndex = Me.UndoIndex
			Me.Modified = False
			Me.UpdateWindowText()
			Me.tbMain.SetItemEnable(207, False)
			Me.tbMain.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = False
			Me.menuEditRedo.Enabled = False
		End Sub

		Private Sub GameVarsPropTree_ItemChanged()
			If Me.UndoIndex + 1 < __Dereference(CType((Me.UndoArray + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) Then
				Do
					Dim expr_19 As __Pointer(Of GArray<GStreamBuffer>) = Me.UndoArray
					<Module>.GArray<GStreamBuffer>.Remove(expr_19, __Dereference(CType((expr_19 + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) - 1)
				Loop While Me.UndoIndex + 1 < __Dereference(CType((Me.UndoArray + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer)))
			End If
			Dim undoArray As __Pointer(Of GArray<GStreamBuffer>) = Me.UndoArray
			If __Dereference(CType((undoArray + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) >= 32 Then
				Dim ptr As __Pointer(Of GArray<GStreamBuffer>) = undoArray
				If 0 >= __Dereference((ptr + 4)) Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DB@DFIJMDNC@c?3?2jtfcode?2src?2core?2include?2?4?4?1t@), __Pointer(Of SByte)), 116, CType((AddressOf <Module>.??_C@_0CE@LPFCBJKE@GArray?$DMclass?5GStreamBuffer?$DO?3?3Rem@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BN@PNEPLEML@invalid?5index?5?$CI?$CFd?$CJ?5Size?5?$DN?5?$CFd?$AA@), __Pointer(Of SByte)), 0, __Dereference((ptr + 4)))
				End If
				Dim num As Integer = __Dereference(ptr)
				Dim arg_7F_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), num, 0, __Dereference((__Dereference(num))))
				__Dereference((ptr + 4)) = __Dereference((ptr + 4)) + -1
				Dim num2 As Integer = __Dereference((ptr + 4))
				If num2 <> 0 Then
					num = __Dereference(ptr)
					Dim expr_96 As Integer = num
					<Module>.memmove(expr_96, expr_96 + 36, CUInt((num2 * 36)))
				End If
				initblk(__Dereference((ptr + 4)) * 36 + __Dereference(ptr), 0, 36)
			End If
			Dim num3 As Integer = <Module>.GArray<GStreamBuffer>.Add(Me.UndoArray)
			Me.UndoIndex = num3
			<Module>.GRTTI.SaveVariablesAsText(num3 * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_GameVariables.Class_GGameVariables, CType((AddressOf <Module>.GameVariables), __Pointer(Of Void)), <Module>.Measures)
			If Me.UndoIndex <= Me.SavedIndex Then
				Me.SavedIndex = 0
			End If
			Me.Modified = True
			Me.tbMain.SetItemEnable(202, True)
			Me.tbMain.SetItemEnable(207, True)
			Me.tbMain.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = True
			Me.menuEditRedo.Enabled = False
			Me.menuFileSave.Enabled = True
			Me.UpdateWindowText()
		End Sub

		Private Function SaveIfModified(sender As Object, e As EventArgs) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			If Not Me.Modified Then
				Return True
			End If
			Dim dialogResult As DialogResult = MessageBox.Show("Game variables have been modified since the last save." & vbLf & "Do you want to save?", "Save Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
			If dialogResult = DialogResult.No Then
				Return True
			End If
			If dialogResult = DialogResult.Yes Then
				Me.menuFileSave_Click(sender, e)
				If Not Me.Modified Then
					Return True
				End If
			End If
			Return False
		End Function

		Private Sub GameVariablesEditor_Closing(sender As Object, e As CancelEventArgs)
			If Not Me.SaveIfModified(sender, e) Then
				e.Cancel = True
			End If
		End Sub

		Private Sub GameVariablesEditor_Closed(sender As Object, e As EventArgs)
			Dim toolWindows As ArrayList = Me.ToolWindows
			If toolWindows IsNot Nothing Then
				toolWindows.Remove(Me)
			End If
		End Sub

		Private Sub UpdateWindowText()
			Dim str As String
			If Me.Modified Then
				str = " *"
			Else
				str = ""
			End If
			Me.Text = "Game Variables" + str
		End Sub

		Private Sub menuFileSave_Click(sender As Object, e As EventArgs)
			Me.tbMain.Focus()
			Me.GameVarsPropTree.Focus()
			If <Module>.GGameVariables.SaveGameVariables(<Module>.GameVariables) IsNot Nothing Then
				Me.SavedIndex = Me.UndoIndex
				Me.Modified = False
				Me.tbMain.SetItemEnable(202, False)
				Me.menuFileSave.Enabled = False
				Me.UpdateWindowText()
			End If
		End Sub

		Private Sub menuFileClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub tbGameVariablesEditor_ButtonClick(idx As Integer, radio_group As Integer)
			If idx = 202 Then
				Me.menuFileSave_Click(Nothing, Nothing)
			Else If idx = 207 Then
				Me.menuEditUndo_Click(Nothing, Nothing)
			Else If idx = 208 Then
				Me.menuEditRedo_Click(Nothing, Nothing)
			End If
		End Sub

		Private Sub menuEditUndo_Click(sender As Object, e As EventArgs)
			Dim undoIndex As Integer = Me.UndoIndex
			If undoIndex > 0 Then
				Dim num As Integer = undoIndex - 1
				Me.UndoIndex = num
				<Module>.GStream.Reset(num * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))))
				<Module>.GRTTI.LoadVariablesAsText(Me.UndoIndex * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_GameVariables.Class_GGameVariables, CType((AddressOf <Module>.GameVariables), __Pointer(Of Void)), <Module>.Measures)
				Me.GameVarsPropTree.SetVariable(AddressOf <Module>.GRTT_GameVariables.Class_GGameVariables, CType((AddressOf <Module>.GameVariables), __Pointer(Of Void)), <Module>.Measures)
				If Me.UndoIndex = Me.SavedIndex Then
					Me.Modified = False
					Me.UpdateWindowText()
					Me.tbMain.SetItemEnable(202, False)
					Me.menuFileSave.Enabled = False
				Else
					Me.Modified = True
					Me.tbMain.SetItemEnable(202, True)
					Me.menuFileSave.Enabled = True
				End If
				Me.UpdateWindowText()
				Me.menuEditRedo.Enabled = True
				Me.tbMain.SetItemEnable(208, True)
				If Me.UndoIndex = 0 Then
					Me.tbMain.SetItemEnable(207, False)
					Me.menuEditUndo.Enabled = False
				End If
			End If
		End Sub

		Private Sub menuEditRedo_Click(sender As Object, e As EventArgs)
			Dim undoArray As __Pointer(Of GArray<GStreamBuffer>) = Me.UndoArray
			Dim undoIndex As Integer = Me.UndoIndex
			If undoIndex < __Dereference(CType((undoArray + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) - 1 Then
				Dim num As Integer = undoIndex + 1
				Me.UndoIndex = num
				<Module>.GStream.Reset(num * 36 + __Dereference(CType(undoArray, __Pointer(Of Integer))))
				<Module>.GRTTI.LoadVariablesAsText(Me.UndoIndex * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_GameVariables.Class_GGameVariables, CType((AddressOf <Module>.GameVariables), __Pointer(Of Void)), <Module>.Measures)
				Me.GameVarsPropTree.SetVariable(AddressOf <Module>.GRTT_GameVariables.Class_GGameVariables, CType((AddressOf <Module>.GameVariables), __Pointer(Of Void)), <Module>.Measures)
				If Me.UndoIndex = Me.SavedIndex Then
					Me.Modified = False
					Me.UpdateWindowText()
					Me.tbMain.SetItemEnable(202, False)
					Me.menuFileSave.Enabled = False
				Else
					Me.Modified = True
					Me.tbMain.SetItemEnable(202, True)
					Me.menuFileSave.Enabled = True
				End If
				Me.UpdateWindowText()
				Me.menuEditUndo.Enabled = True
				Me.tbMain.SetItemEnable(207, True)
				If Me.UndoIndex = __Dereference(CType((Me.UndoArray + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) - 1 Then
					Me.tbMain.SetItemEnable(208, False)
					Me.menuEditRedo.Enabled = False
				End If
			End If
		End Sub

		Protected Sub raise_PUnitChanged(i1 As __Pointer(Of SByte))
			Dim pUnitChanged As NGameVariablesEditor.__Delegate_PUnitChanged = Me.PUnitChanged
			If pUnitChanged IsNot Nothing Then
				pUnitChanged(i1)
			End If
		End Sub
	End Class
End Namespace
