Imports NControls
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NMissionVariablesEditor
		Inherits Form

		Protected ToolWindows As ArrayList

		Protected ToolWindowIdx As Integer

		Protected FileDialog As NFileDialog

		Protected FileName As String

		Protected Modified As Boolean

		Private propWorld As __Pointer(Of GEditorWorld)

		Private menuMissionVariablesEditor As MainMenu

		Private menuFile As MenuItem

		Private menuFileClose As MenuItem

		Private panel1 As Panel

		Private components As Container

		Private tbMain As Toolbar

		Private MissionVarsPropTree As PropertyTree

		Public Sub New(toolwindows As ArrayList, world As __Pointer(Of GEditorWorld))
			Me.propWorld = world
			Me.InitializeComponent()
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0NMissionVariablesEditor@NWorkshop@@Q$AAM@P$AAVArrayList@Collections@System@@PAVGEditorWorld@@@Z@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Me.tbMain = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.tbMain.ButtonClick, AddressOf Me.tbMissionVariablesEditor_ButtonClick
			MyBase.Controls.Add(Me.tbMain)
			Dim propertyTree As PropertyTree = New PropertyTree(2, NewAssetPicker.ObjectType.MissionVariablesEditor, Nothing)
			Me.MissionVarsPropTree = propertyTree
			Me.panel1.Controls.Add(propertyTree)
			Me.MissionVarsPropTree.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.MissionVarsPropTree.Location = location
			Me.MissionVarsPropTree.Name = "MissionVarsPropTree"
			Dim size As Size = New Size(250, 435)
			Me.MissionVarsPropTree.Size = size
			Me.MissionVarsPropTree.TabIndex = 0
			Me.MissionVarsPropTree.Text = "MissionVarsPropTree"
			AddHandler Me.MissionVarsPropTree.ItemChanged, AddressOf Me.MissionVarsPropTree_ItemChanged
			Me.ToolWindows = toolwindows
			toolwindows.Add(Me)
			Me.tbMain.SetItemEnable(202, False)
			Me.tbMain.SetItemEnable(203, False)
			Me.tbMain.SetItemEnable(204, False)
			Me.tbMain.SetItemEnable(205, False)
			Me.tbMain.SetItemEnable(206, False)
			Me.Modified = False
			Me.UpdateWindowText()
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
			Me.menuMissionVariablesEditor = New MainMenu()
			Me.menuFile = New MenuItem()
			Me.menuFileClose = New MenuItem()
			Me.panel1 = New Panel()
			MyBase.SuspendLayout()
			Dim items As MenuItem() = New MenuItem() { Me.menuFile }
			Me.menuMissionVariablesEditor.MenuItems.AddRange(items)
			Me.menuFile.Index = 0
			Dim items2 As MenuItem() = New MenuItem() { Me.menuFileClose }
			Me.menuFile.MenuItems.AddRange(items2)
			Me.menuFile.Text = "&File"
			Me.menuFileClose.Index = 0
			Me.menuFileClose.Text = "&Close"
			AddHandler Me.menuFileClose.Click, AddressOf Me.menuFileClose_Click
			Me.panel1.BorderStyle = BorderStyle.Fixed3D
			Me.panel1.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.panel1.Location = location
			Me.panel1.Name = "panel1"
			Dim size As Size = New Size(408, 457)
			Me.panel1.Size = size
			Me.panel1.TabIndex = 0
			Dim autoScaleBaseSize As Size = New Size(5, 14)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(408, 457)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.panel1)
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			MyBase.Menu = Me.menuMissionVariablesEditor
			MyBase.Name = "NMissionVariablesEditor"
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Mission Variables"
			AddHandler MyBase.Load, AddressOf Me.NMissionVariablesEditor_Load
			AddHandler MyBase.Closed, AddressOf Me.NMissionVariablesEditor_Closed
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub tbMissionVariablesEditor_ButtonClick(idx As Integer, radio_group As Integer)
		End Sub

		Private Sub MissionVarsPropTree_ItemChanged()
			Me.Modified = True
			Me.UpdateWindowText()
		End Sub

		Private Sub UpdateWindowText()
			Dim str As String
			If Me.Modified Then
				str = " *"
			Else
				str = ""
			End If
			Me.Text = "Mission Variables" + str
		End Sub

		Private Sub NMissionVariablesEditor_Load(sender As Object, e As EventArgs)
			Me.MissionVarsPropTree.SetVariable(AddressOf <Module>.GRTT_MissionVariables.Class_GMissionVariables, CType((AddressOf <Module>.MissionVariables), __Pointer(Of Void)), <Module>.Measures)
			Me.MissionVarsPropTree.Focus()
			Me.Modified = False
			Me.UpdateWindowText()
		End Sub

		Private Sub NMissionVariablesEditor_Closed(sender As Object, e As EventArgs)
			If Me.Modified Then
				<Module>.GWorld.LoadMissionLocales()
			End If
			Dim toolWindows As ArrayList = Me.ToolWindows
			If toolWindows IsNot Nothing Then
				toolWindows.Remove(Me)
			End If
		End Sub

		Private Sub menuFileClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub
	End Class
End Namespace
