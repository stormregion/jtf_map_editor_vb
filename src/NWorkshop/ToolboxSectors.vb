Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxSectors
		Inherits UserControl

		Public Delegate Sub SectorActionHandler(op As Integer, info As String)

		Private components As Container

		Private SketchPanel As Panel

		Private BtnDownPlus As Button

		Private BtnRightPlus As Button

		Private BtnLeftPlus As Button

		Private BtnUpPlus As Button

		Private BtnDown As Button

		Private BtnUp As Button

		Private BtnRight As Button

		Private BtnLeft As Button

		Private SketchBtn As Button

		Private SectorTools As Toolbar

		Private LoadSketchDialog As NFileDialog

		Private SectorList As ToolboxScriptEntities

		Public Custom Event Action As ToolboxSectors.SectorActionHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Action = [Delegate].Combine(Me.Action, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Action = [Delegate].Remove(Me.Action, value)
			End RemoveHandler
		End Event

		Public ReadOnly Property ScriptEntityTool() As ToolboxScriptEntities
			Get
				Return Me.SectorList
			End Get
		End Property

		Public WriteOnly Property World() As __Pointer(Of GEditorWorld)
			Set(value As __Pointer(Of GEditorWorld))
				Me.SectorList.World = value
			End Set
		End Property

		Public Sub New()
			Me.Action = Nothing
			Me.InitializeComponent()
			Me.SectorList = New ToolboxScriptEntities(4)
			Dim location As Point = New Point(0, 32)
			Me.SectorList.Location = location
			MyBase.Controls.Add(Me.SectorList)
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0ToolboxSectors@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Me.SectorTools = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.SectorTools.ButtonClick, AddressOf Me.SectorTools_ButtonClick
			Dim size As Size = New Size(MyBase.Size.Width, 32)
			Me.SectorTools.Size = size
			MyBase.Controls.Add(Me.SectorTools)
			Dim nFileDialog As NFileDialog = New NFileDialog(Nothing, True)
			Me.LoadSketchDialog = nFileDialog
			nFileDialog.AvailableModes = 2
			Me.LoadSketchDialog.DefaultExtension = "tga"
			Me.LoadSketchDialog.SelectedMode = 2
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing Then
				Dim container As Container = Me.components
				If container IsNot Nothing Then
					container.Dispose()
					MyBase.Dispose(disposing)
				End If
			End If
		End Sub

		Private Sub InitializeComponent()
			Dim resourceManager As ResourceManager = New ResourceManager(GetType(ToolboxSectors))
			Me.SketchPanel = New Panel()
			Me.BtnDownPlus = New Button()
			Me.BtnRightPlus = New Button()
			Me.BtnLeftPlus = New Button()
			Me.BtnUpPlus = New Button()
			Me.BtnDown = New Button()
			Me.BtnUp = New Button()
			Me.BtnRight = New Button()
			Me.BtnLeft = New Button()
			Me.SketchBtn = New Button()
			Me.SketchPanel.SuspendLayout()
			MyBase.SuspendLayout()
			Me.SketchPanel.Controls.Add(Me.BtnDownPlus)
			Me.SketchPanel.Controls.Add(Me.BtnRightPlus)
			Me.SketchPanel.Controls.Add(Me.BtnLeftPlus)
			Me.SketchPanel.Controls.Add(Me.BtnUpPlus)
			Me.SketchPanel.Controls.Add(Me.BtnDown)
			Me.SketchPanel.Controls.Add(Me.BtnUp)
			Me.SketchPanel.Controls.Add(Me.BtnRight)
			Me.SketchPanel.Controls.Add(Me.BtnLeft)
			Me.SketchPanel.Controls.Add(Me.SketchBtn)
			Me.SketchPanel.Dock = DockStyle.Bottom
			Dim location As Point = New Point(0, 360)
			Me.SketchPanel.Location = location
			Me.SketchPanel.Name = "SketchPanel"
			Dim size As Size = New Size(256, 120)
			Me.SketchPanel.Size = size
			Me.SketchPanel.TabIndex = 9
			Me.BtnDownPlus.Image = CType(resourceManager.GetObject("BtnDownPlus.Image"), Image)
			Dim location2 As Point = New Point(24, 96)
			Me.BtnDownPlus.Location = location2
			Me.BtnDownPlus.Name = "BtnDownPlus"
			Dim size2 As Size = New Size(128, 24)
			Me.BtnDownPlus.Size = size2
			Me.BtnDownPlus.TabIndex = 17
			AddHandler Me.BtnDownPlus.Click, AddressOf Me.BtnDownPlus_Click
			Me.BtnRightPlus.Image = CType(resourceManager.GetObject("BtnRightPlus.Image"), Image)
			Dim location3 As Point = New Point(152, 0)
			Me.BtnRightPlus.Location = location3
			Me.BtnRightPlus.Name = "BtnRightPlus"
			Dim size3 As Size = New Size(24, 120)
			Me.BtnRightPlus.Size = size3
			Me.BtnRightPlus.TabIndex = 16
			AddHandler Me.BtnRightPlus.Click, AddressOf Me.BtnRightPlus_Click
			Me.BtnLeftPlus.Image = CType(resourceManager.GetObject("BtnLeftPlus.Image"), Image)
			Dim location4 As Point = New Point(0, 0)
			Me.BtnLeftPlus.Location = location4
			Me.BtnLeftPlus.Name = "BtnLeftPlus"
			Dim size4 As Size = New Size(24, 120)
			Me.BtnLeftPlus.Size = size4
			Me.BtnLeftPlus.TabIndex = 15
			AddHandler Me.BtnLeftPlus.Click, AddressOf Me.BtnLeftPlus_Click
			Me.BtnUpPlus.Image = CType(resourceManager.GetObject("BtnUpPlus.Image"), Image)
			Dim location5 As Point = New Point(24, 0)
			Me.BtnUpPlus.Location = location5
			Me.BtnUpPlus.Name = "BtnUpPlus"
			Dim size5 As Size = New Size(128, 24)
			Me.BtnUpPlus.Size = size5
			Me.BtnUpPlus.TabIndex = 14
			AddHandler Me.BtnUpPlus.Click, AddressOf Me.BtnUpPlus_Click
			Me.BtnDown.Image = CType(resourceManager.GetObject("BtnDown.Image"), Image)
			Dim location6 As Point = New Point(48, 72)
			Me.BtnDown.Location = location6
			Me.BtnDown.Name = "BtnDown"
			Dim size6 As Size = New Size(80, 24)
			Me.BtnDown.Size = size6
			Me.BtnDown.TabIndex = 13
			AddHandler Me.BtnDown.Click, AddressOf Me.BtnDown_Click
			Me.BtnUp.Image = CType(resourceManager.GetObject("BtnUp.Image"), Image)
			Dim location7 As Point = New Point(48, 24)
			Me.BtnUp.Location = location7
			Me.BtnUp.Name = "BtnUp"
			Dim size7 As Size = New Size(80, 24)
			Me.BtnUp.Size = size7
			Me.BtnUp.TabIndex = 12
			AddHandler Me.BtnUp.Click, AddressOf Me.BtnUp_Click
			Me.BtnRight.Image = CType(resourceManager.GetObject("BtnRight.Image"), Image)
			Dim location8 As Point = New Point(128, 24)
			Me.BtnRight.Location = location8
			Me.BtnRight.Name = "BtnRight"
			Dim size8 As Size = New Size(24, 72)
			Me.BtnRight.Size = size8
			Me.BtnRight.TabIndex = 11
			AddHandler Me.BtnRight.Click, AddressOf Me.BtnRight_Click
			Me.BtnLeft.Image = CType(resourceManager.GetObject("BtnLeft.Image"), Image)
			Dim location9 As Point = New Point(24, 24)
			Me.BtnLeft.Location = location9
			Me.BtnLeft.Name = "BtnLeft"
			Dim size9 As Size = New Size(24, 72)
			Me.BtnLeft.Size = size9
			Me.BtnLeft.TabIndex = 10
			AddHandler Me.BtnLeft.Click, AddressOf Me.BtnLeft_Click
			Dim location10 As Point = New Point(48, 48)
			Me.SketchBtn.Location = location10
			Me.SketchBtn.Name = "SketchBtn"
			Dim size10 As Size = New Size(80, 23)
			Me.SketchBtn.Size = size10
			Me.SketchBtn.TabIndex = 9
			Me.SketchBtn.Text = "Load sketch"
			AddHandler Me.SketchBtn.Click, AddressOf Me.SketchBtn_Click
			MyBase.Controls.Add(Me.SketchPanel)
			MyBase.Name = "ToolboxSectors"
			Dim size11 As Size = New Size(256, 480)
			MyBase.Size = size11
			Me.SketchPanel.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub SectorTools_ButtonClick(idx As Integer, radio_group As Integer)
			If radio_group = 1 Then
				Me.raise_Action(idx, Nothing)
			End If
		End Sub

		Private Sub SketchBtn_Click(sender As Object, e As EventArgs)
			If Me.LoadSketchDialog.ShowDialog() = DialogResult.OK Then
				Me.raise_Action(2, Me.LoadSketchDialog.FileName)
			End If
		End Sub

		Private Sub BtnUp_Click(sender As Object, e As EventArgs)
			Me.raise_Action(3, Nothing)
		End Sub

		Private Sub BtnDown_Click(sender As Object, e As EventArgs)
			Me.raise_Action(4, Nothing)
		End Sub

		Private Sub BtnRight_Click(sender As Object, e As EventArgs)
			Me.raise_Action(6, Nothing)
		End Sub

		Private Sub BtnLeft_Click(sender As Object, e As EventArgs)
			Me.raise_Action(5, Nothing)
		End Sub

		Private Sub BtnRightPlus_Click(sender As Object, e As EventArgs)
			Me.raise_Action(10, Nothing)
		End Sub

		Private Sub BtnUpPlus_Click(sender As Object, e As EventArgs)
			Me.raise_Action(7, Nothing)
		End Sub

		Private Sub BtnLeftPlus_Click(sender As Object, e As EventArgs)
			Me.raise_Action(9, Nothing)
		End Sub

		Private Sub BtnDownPlus_Click(sender As Object, e As EventArgs)
			Me.raise_Action(8, Nothing)
		End Sub

		Protected Sub raise_Action(i1 As Integer, i2 As String)
			Dim action As ToolboxSectors.SectorActionHandler = Me.Action
			If action IsNot Nothing Then
				action(i1, i2)
			End If
		End Sub
	End Class
End Namespace
