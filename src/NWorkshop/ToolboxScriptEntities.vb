Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxScriptEntities
		Inherits UserControl

		Private EntityList As ListView

		Private Dummy As ColumnHeader

		Private EntityName As ColumnHeader

		Private EntityColor As ColumnHeader

		Private ColorChooser As ContextMenu

		Private Red As MenuItem

		Private Yellow As MenuItem

		Private Green As MenuItem

		Private Cyan As MenuItem

		Private Blue As MenuItem

		Private Magenta As MenuItem

		Private ShowCheck As CheckBox

		Private UnitGroupBox As GroupBox

		Private BehaviorLbl As Label

		Private BehaviorList As ListBox

		Private BraveryLbl As Label

		Private BraveryList As ListBox

		Private HelpCountLbl As Label

		Private MaxHelpNumeric As NumericUpDown

		Private FallbackList As ListBox

		Private FallbackLbl As Label

		Private HelpTypeList As ListBox

		Private HelpTypeLbl As Label

		Private ObjectivePanel As Panel

		Private ObjectiveGroup As GroupBox

		Private TargetList As ListBox

		Private AddBtn As Button

		Private ObjPathsLbl As Label

		Private ObjLocLblb As Label

		Private ObjPathList As ListBox

		Private ObjLocList As ListBox

		Private DescriptionLbl As Label

		Private TargetLbl As Label

		Private DescriptionEdit As TextBox

		Private RemoveBtn As Button

		Private RewardNumeric As NumericUpDown

		Private RewardLbl As Label

		Private CurveGroupBox As GroupBox

		Private TimeCurveButton As Button

		Private FOVCurveButton As Button

		Private RollCurveButton As Button

		Private CamBeginButton As Button

		Private CamPauseButton As Button

		Private CamPlayButton As Button

		Private CamRewindButton As Button

		Private CamForwardButton As Button

		Private label1 As Label

		Private label2 As Label

		Private CurveDuration As TextBox

		Private CurveLoop As CheckBox

		Private CurvePositionTrack As TrackBar

		Private CurveActPos As TextBox

		Private EyeCurveSelect As ComboBox

		Private TargetCurveSelect As ComboBox

		Private label3 As Label

		Private label5 As Label

		Private label6 As Label

		Private CurveActPercent As TextBox

		Private label7 As Label

		Private label4 As Label

		Private TargetUsed As CheckBox

		Private ShowViewport As CheckBox

		Private label8 As Label

		Private CurveDebugStart As TextBox

		Private label9 As Label

		Private CurveDebugShow As CheckBox

		Private CurveMakeShots As CheckBox

		Private ResolutionList As ComboBox

		Private AddTargetCurve As Button

		Private RemoveTargetCurve As Button

		Private LinkedTarget As Label

		Private HelpRangeLbl As Label

		Private HelpRangeEdit As TextBox

		Private RangeLbl As Label

		Private RangeEdit As TextBox

		Private VehiclesCheck As CheckBox

		Private BuildingsCheck As CheckBox

		Private components As Container

		Private propWorld As __Pointer(Of GEditorWorld)

		Private SCEType As Integer

		Private SelectedItem As Integer

		Private SelectedWorldIndex As Integer

		Private EditLabel As Boolean

		Private EditedLabel As String

		Private Locations As Integer()

		Private Paths As Integer()

		Private Targets As Integer()

		Private CameraEyeCurveSelectedIdx As Integer

		Private CameraTargetCurveSelectedIdx As Integer

		Private CameraEyeCurveIndex As Integer

		Private CameraTargetCurveIndex As Integer

		Private CameraStatus As Integer

		Private CameraPlayPosition As Single

		Private CamViewport As ToolboxCameraViewport

		Private ToolWindows As ArrayList

		Private CameraViewPortExist As __Pointer(Of Boolean)

		Private PropsRefreshing As Boolean

		Public ForceRefresh As Boolean

		Public ReadOnly Property SelectedEntityIndex() As Integer
			Get
				Return Me.SelectedWorldIndex
			End Get
		End Property

		Public WriteOnly Property World() As __Pointer(Of GEditorWorld)
			Set(value As __Pointer(Of GEditorWorld))
				Me.propWorld = value
				If value IsNot Nothing Then
					Me.ShowCheck_CheckedChanged(Nothing, Nothing)
				End If
			End Set
		End Property

		Public Sub New(type As Integer)
			Me.InitializeComponent()
			Me.ToolWindows = New ArrayList()
			Dim ptr As __Pointer(Of Boolean) = <Module>.new(1UI)
			Dim cameraViewPortExist As __Pointer(Of Boolean)
			If ptr IsNot Nothing Then
				__Dereference(ptr) = False
				cameraViewPortExist = ptr
			Else
				cameraViewPortExist = Nothing
			End If
			Me.CameraViewPortExist = cameraViewPortExist
			Me.InitCameraCurveProps()
			Me.SelectedItem = -1
			Me.SelectedWorldIndex = -1
			Me.SCEType = type
			Me.EditLabel = False
			Me.PropsRefreshing = False
			Me.propWorld = Nothing
			If type = 0 Then
				Me.EntityList.Columns.Add("Looped", 50, HorizontalAlignment.Center)
			Else If type = 2 Then
				Me.EntityList.Columns.Add("Eye", 50, HorizontalAlignment.Center)
			Else If type = 4 Then
				Me.EntityList.Columns.Add("Active", 60, HorizontalAlignment.Center)
				Me.EntityList.Columns.Add("AISleep", 60, HorizontalAlignment.Center)
			Else If type = 1 Then
				Me.EntityList.Columns.Add("Effect range", 60, HorizontalAlignment.Center)
				Me.EntityList.Columns.Add("Event source", 60, HorizontalAlignment.Center)
			Else If type = 6 Then
				Me.EntityList.Columns.Remove(Me.EntityColor)
				Me.EntityList.Columns.Add("Inititial state", 60, HorizontalAlignment.Center)
				Me.EntityList.Columns.Add("Type", 60, HorizontalAlignment.Center)
			Else If type = 3 Then
				Me.EntityList.Columns.Add("Type", 60, HorizontalAlignment.Center)
				GoTo IL_2A1
			End If
			MyBase.Controls.Remove(Me.UnitGroupBox)
			MyBase.Controls.Remove(Me.BehaviorLbl)
			MyBase.Controls.Remove(Me.BehaviorList)
			MyBase.Controls.Remove(Me.RangeLbl)
			MyBase.Controls.Remove(Me.RangeEdit)
			MyBase.Controls.Remove(Me.BraveryLbl)
			MyBase.Controls.Remove(Me.BraveryList)
			MyBase.Controls.Remove(Me.HelpTypeLbl)
			MyBase.Controls.Remove(Me.HelpTypeList)
			MyBase.Controls.Remove(Me.FallbackLbl)
			MyBase.Controls.Remove(Me.FallbackList)
			MyBase.Controls.Remove(Me.HelpCountLbl)
			MyBase.Controls.Remove(Me.MaxHelpNumeric)
			Dim size As Size = MyBase.Size
			Dim size2 As Size = New Size(MyBase.Size.Width, size.Height - Me.UnitGroupBox.Height)
			MyBase.Size = size2
			If type = 6 Then
				Dim location As Point = Me.ObjectivePanel.Location
				Dim location2 As Point = Me.ObjectivePanel.Location
				Dim num As Integer = -8 - Me.UnitGroupBox.Height
				Dim location3 As Point = New Point(location2.X, location.Y + num)
				Me.ObjectivePanel.Location = location3
				GoTo IL_342
			End If
			IL_2A1:
			MyBase.Controls.Remove(Me.ObjectivePanel)
			Dim size3 As Size = MyBase.Size
			Dim size4 As Size = New Size(MyBase.Size.Width, size3.Height - Me.ObjectivePanel.Height)
			MyBase.Size = size4
			If type = 2 Then
				Dim location4 As Point = Me.CurveGroupBox.Location
				Dim location5 As Point = Me.CurveGroupBox.Location
				Dim num2 As Integer = -8 - Me.UnitGroupBox.Height - Me.ObjectivePanel.Height
				Dim location6 As Point = New Point(location5.X, location4.Y + num2)
				Me.CurveGroupBox.Location = location6
				Dim items As Object() = New Object() { "848x480 (1x)", "1024x580", "1280x725", "1600x906", "1696x960 (2x)", "2048x1160", "2544x1440 (3x)", "3392x1920 (4x)" }
				Me.ResolutionList.Items.AddRange(items)
				GoTo IL_443
			End If
			IL_342:
			MyBase.Controls.Remove(Me.CurveGroupBox)
			Dim size5 As Size = MyBase.Size
			Dim size6 As Size = New Size(MyBase.Size.Width, size5.Height - Me.CurveGroupBox.Height)
			MyBase.Size = size6
			IL_443:
			AddHandler Application.Idle, AddressOf Me.OnIdle
		End Sub

		Private Sub OnIdle(sender As Object, e As EventArgs)
			Me.ShowViewport.Checked = __Dereference(Me.CameraViewPortExist)
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
			Me.EntityList = New ListView()
			Me.Dummy = New ColumnHeader()
			Me.EntityName = New ColumnHeader()
			Me.EntityColor = New ColumnHeader()
			Me.ColorChooser = New ContextMenu()
			Me.Red = New MenuItem()
			Me.Yellow = New MenuItem()
			Me.Green = New MenuItem()
			Me.Cyan = New MenuItem()
			Me.Blue = New MenuItem()
			Me.Magenta = New MenuItem()
			Me.ShowCheck = New CheckBox()
			Me.UnitGroupBox = New GroupBox()
			Me.VehiclesCheck = New CheckBox()
			Me.RangeLbl = New Label()
			Me.RangeEdit = New TextBox()
			Me.MaxHelpNumeric = New NumericUpDown()
			Me.HelpCountLbl = New Label()
			Me.FallbackList = New ListBox()
			Me.FallbackLbl = New Label()
			Me.HelpTypeList = New ListBox()
			Me.HelpTypeLbl = New Label()
			Me.BraveryList = New ListBox()
			Me.BraveryLbl = New Label()
			Me.HelpRangeLbl = New Label()
			Me.HelpRangeEdit = New TextBox()
			Me.BehaviorLbl = New Label()
			Me.BehaviorList = New ListBox()
			Me.ObjectivePanel = New Panel()
			Me.ObjectiveGroup = New GroupBox()
			Me.RewardLbl = New Label()
			Me.RewardNumeric = New NumericUpDown()
			Me.TargetLbl = New Label()
			Me.RemoveBtn = New Button()
			Me.TargetList = New ListBox()
			Me.AddBtn = New Button()
			Me.ObjPathsLbl = New Label()
			Me.ObjLocLblb = New Label()
			Me.ObjPathList = New ListBox()
			Me.ObjLocList = New ListBox()
			Me.DescriptionLbl = New Label()
			Me.DescriptionEdit = New TextBox()
			Me.CurveGroupBox = New GroupBox()
			Me.LinkedTarget = New Label()
			Me.RemoveTargetCurve = New Button()
			Me.AddTargetCurve = New Button()
			Me.ResolutionList = New ComboBox()
			Me.CurveMakeShots = New CheckBox()
			Me.CurveDebugShow = New CheckBox()
			Me.label8 = New Label()
			Me.CurveDebugStart = New TextBox()
			Me.label9 = New Label()
			Me.ShowViewport = New CheckBox()
			Me.TargetUsed = New CheckBox()
			Me.label7 = New Label()
			Me.CurveActPercent = New TextBox()
			Me.label6 = New Label()
			Me.label5 = New Label()
			Me.label4 = New Label()
			Me.label3 = New Label()
			Me.TargetCurveSelect = New ComboBox()
			Me.EyeCurveSelect = New ComboBox()
			Me.CurveActPos = New TextBox()
			Me.CurvePositionTrack = New TrackBar()
			Me.CurveLoop = New CheckBox()
			Me.label2 = New Label()
			Me.CamForwardButton = New Button()
			Me.CamRewindButton = New Button()
			Me.CamPlayButton = New Button()
			Me.CamPauseButton = New Button()
			Me.CamBeginButton = New Button()
			Me.RollCurveButton = New Button()
			Me.FOVCurveButton = New Button()
			Me.TimeCurveButton = New Button()
			Me.CurveDuration = New TextBox()
			Me.label1 = New Label()
			Me.BuildingsCheck = New CheckBox()
			Me.UnitGroupBox.SuspendLayout()
			(CType(Me.MaxHelpNumeric, ISupportInitialize)).BeginInit()
			Me.ObjectivePanel.SuspendLayout()
			Me.ObjectiveGroup.SuspendLayout()
			(CType(Me.RewardNumeric, ISupportInitialize)).BeginInit()
			Me.CurveGroupBox.SuspendLayout()
			(CType(Me.CurvePositionTrack, ISupportInitialize)).BeginInit()
			MyBase.SuspendLayout()
			Dim values As ColumnHeader() = New ColumnHeader() { Me.Dummy, Me.EntityName, Me.EntityColor }
			Me.EntityList.Columns.AddRange(values)
			Me.EntityList.FullRowSelect = True
			Me.EntityList.GridLines = True
			Me.EntityList.HeaderStyle = ColumnHeaderStyle.None
			Me.EntityList.HideSelection = False
			Me.EntityList.LabelEdit = True
			Dim location As Point = New Point(8, 8)
			Me.EntityList.Location = location
			Me.EntityList.MultiSelect = False
			Me.EntityList.Name = "EntityList"
			Dim size As Size = New Size(240, 288)
			Me.EntityList.Size = size
			Me.EntityList.Sorting = SortOrder.Ascending
			Me.EntityList.TabIndex = 0
			Me.EntityList.View = View.Details
			AddHandler Me.EntityList.MouseUp, AddressOf Me.EntityList_MouseUp
			AddHandler Me.EntityList.AfterLabelEdit, AddressOf Me.EntityList_AfterLabelEdit
			AddHandler Me.EntityList.SelectedIndexChanged, AddressOf Me.EntityList_SelectedIndexChanged
			Me.Dummy.Text = "Dummy"
			Me.Dummy.Width = 0
			Me.EntityName.Text = "NameHeader"
			Me.EntityName.Width = 216
			Me.EntityColor.Text = "ColorHeader"
			Me.EntityColor.Width = 20
			Dim items As MenuItem() = New MenuItem() { Me.Red, Me.Yellow, Me.Green, Me.Cyan, Me.Blue, Me.Magenta }
			Me.ColorChooser.MenuItems.AddRange(items)
			Me.Red.Index = 0
			Me.Red.OwnerDraw = True
			Me.Red.Text = ""
			AddHandler Me.Red.DrawItem, AddressOf Me.DrawColorSelector
			AddHandler Me.Red.Click, AddressOf Me.ColorSelected
			AddHandler Me.Red.MeasureItem, AddressOf Me.MeasureColorSelector
			Me.Yellow.Index = 1
			Me.Yellow.OwnerDraw = True
			Me.Yellow.Text = ""
			AddHandler Me.Yellow.DrawItem, AddressOf Me.DrawColorSelector
			AddHandler Me.Yellow.Click, AddressOf Me.ColorSelected
			AddHandler Me.Yellow.MeasureItem, AddressOf Me.MeasureColorSelector
			Me.Green.Index = 2
			Me.Green.OwnerDraw = True
			Me.Green.Text = ""
			AddHandler Me.Green.DrawItem, AddressOf Me.DrawColorSelector
			AddHandler Me.Green.Click, AddressOf Me.ColorSelected
			AddHandler Me.Green.MeasureItem, AddressOf Me.MeasureColorSelector
			Me.Cyan.Index = 3
			Me.Cyan.OwnerDraw = True
			Me.Cyan.Text = ""
			AddHandler Me.Cyan.DrawItem, AddressOf Me.DrawColorSelector
			AddHandler Me.Cyan.Click, AddressOf Me.ColorSelected
			AddHandler Me.Cyan.MeasureItem, AddressOf Me.MeasureColorSelector
			Me.Blue.Index = 4
			Me.Blue.OwnerDraw = True
			Me.Blue.Text = ""
			AddHandler Me.Blue.DrawItem, AddressOf Me.DrawColorSelector
			AddHandler Me.Blue.Click, AddressOf Me.ColorSelected
			AddHandler Me.Blue.MeasureItem, AddressOf Me.MeasureColorSelector
			Me.Magenta.Index = 5
			Me.Magenta.OwnerDraw = True
			Me.Magenta.Text = ""
			AddHandler Me.Magenta.DrawItem, AddressOf Me.DrawColorSelector
			AddHandler Me.Magenta.Click, AddressOf Me.ColorSelected
			AddHandler Me.Magenta.MeasureItem, AddressOf Me.MeasureColorSelector
			Dim location2 As Point = New Point(8, 304)
			Me.ShowCheck.Location = location2
			Me.ShowCheck.Name = "ShowCheck"
			Dim size2 As Size = New Size(104, 16)
			Me.ShowCheck.Size = size2
			Me.ShowCheck.TabIndex = 1
			Me.ShowCheck.Text = "Show Always"
			AddHandler Me.ShowCheck.CheckedChanged, AddressOf Me.ShowCheck_CheckedChanged
			Me.UnitGroupBox.Controls.Add(Me.BuildingsCheck)
			Me.UnitGroupBox.Controls.Add(Me.VehiclesCheck)
			Me.UnitGroupBox.Controls.Add(Me.RangeLbl)
			Me.UnitGroupBox.Controls.Add(Me.RangeEdit)
			Me.UnitGroupBox.Controls.Add(Me.MaxHelpNumeric)
			Me.UnitGroupBox.Controls.Add(Me.HelpCountLbl)
			Me.UnitGroupBox.Controls.Add(Me.FallbackList)
			Me.UnitGroupBox.Controls.Add(Me.FallbackLbl)
			Me.UnitGroupBox.Controls.Add(Me.HelpTypeList)
			Me.UnitGroupBox.Controls.Add(Me.HelpTypeLbl)
			Me.UnitGroupBox.Controls.Add(Me.BraveryList)
			Me.UnitGroupBox.Controls.Add(Me.BraveryLbl)
			Me.UnitGroupBox.Controls.Add(Me.HelpRangeLbl)
			Me.UnitGroupBox.Controls.Add(Me.HelpRangeEdit)
			Me.UnitGroupBox.Controls.Add(Me.BehaviorLbl)
			Me.UnitGroupBox.Controls.Add(Me.BehaviorList)
			Dim location3 As Point = New Point(8, 328)
			Me.UnitGroupBox.Location = location3
			Me.UnitGroupBox.Name = "UnitGroupBox"
			Dim size3 As Size = New Size(240, 368)
			Me.UnitGroupBox.Size = size3
			Me.UnitGroupBox.TabIndex = 4
			Me.UnitGroupBox.TabStop = False
			Me.UnitGroupBox.Text = "Unit group props"
			Dim location4 As Point = New Point(8, 312)
			Me.VehiclesCheck.Location = location4
			Me.VehiclesCheck.Name = "VehiclesCheck"
			Dim size4 As Size = New Size(224, 24)
			Me.VehiclesCheck.Size = size4
			Me.VehiclesCheck.TabIndex = 19
			Me.VehiclesCheck.Text = "Advanced vehicle usage"
			AddHandler Me.VehiclesCheck.CheckedChanged, AddressOf Me.VehiclesCheck_CheckedChanged
			Dim location5 As Point = New Point(128, 200)
			Me.RangeLbl.Location = location5
			Me.RangeLbl.Name = "RangeLbl"
			Me.RangeLbl.TabIndex = 18
			Me.RangeLbl.Text = "Group range"
			Dim location6 As Point = New Point(128, 224)
			Me.RangeEdit.Location = location6
			Me.RangeEdit.Name = "RangeEdit"
			Me.RangeEdit.TabIndex = 17
			Me.RangeEdit.Text = ""
			AddHandler Me.RangeEdit.Validated, AddressOf Me.RangeEdit_Validated
			AddHandler Me.RangeEdit.TextChanged, AddressOf Me.RangeEdit_TextChanged
			Dim location7 As Point = New Point(8, 280)
			Me.MaxHelpNumeric.Location = location7
			Dim maximum As Decimal = New Decimal(New Integer() { 10, 0, 0, 0 })
			Me.MaxHelpNumeric.Maximum = maximum
			Me.MaxHelpNumeric.Name = "MaxHelpNumeric"
			Dim size5 As Size = New Size(104, 20)
			Me.MaxHelpNumeric.Size = size5
			Me.MaxHelpNumeric.TabIndex = 16
			AddHandler Me.MaxHelpNumeric.ValueChanged, AddressOf Me.MaxHelpNumeric_ValueChanged
			Dim location8 As Point = New Point(8, 256)
			Me.HelpCountLbl.Location = location8
			Me.HelpCountLbl.Name = "HelpCountLbl"
			Me.HelpCountLbl.TabIndex = 15
			Me.HelpCountLbl.Text = "Max. help count"
			Dim location9 As Point = New Point(128, 136)
			Me.FallbackList.Location = location9
			Me.FallbackList.Name = "FallbackList"
			Dim size6 As Size = New Size(104, 56)
			Me.FallbackList.Size = size6
			Me.FallbackList.TabIndex = 13
			AddHandler Me.FallbackList.SelectedIndexChanged, AddressOf Me.FallbackList_SelectedIndexChanged
			Dim location10 As Point = New Point(128, 112)
			Me.FallbackLbl.Location = location10
			Me.FallbackLbl.Name = "FallbackLbl"
			Dim size7 As Size = New Size(96, 23)
			Me.FallbackLbl.Size = size7
			Me.FallbackLbl.TabIndex = 12
			Me.FallbackLbl.Text = "Fallback location"
			Dim items2 As Object() = New Object() { "Freelance", "Support", "Artillery", "Light backup", "Heavy backup", "Air support", "Recon" }
			Me.HelpTypeList.Items.AddRange(items2)
			Dim location11 As Point = New Point(8, 152)
			Me.HelpTypeList.Location = location11
			Me.HelpTypeList.Name = "HelpTypeList"
			Me.HelpTypeList.SelectionMode = SelectionMode.MultiSimple
			Dim size8 As Size = New Size(104, 95)
			Me.HelpTypeList.Size = size8
			Me.HelpTypeList.TabIndex = 11
			AddHandler Me.HelpTypeList.SelectedIndexChanged, AddressOf Me.HelpTypeList_SelectedIndexChanged
			Dim location12 As Point = New Point(8, 128)
			Me.HelpTypeLbl.Location = location12
			Me.HelpTypeLbl.Name = "HelpTypeLbl"
			Dim size9 As Size = New Size(88, 23)
			Me.HelpTypeLbl.Size = size9
			Me.HelpTypeLbl.TabIndex = 10
			Me.HelpTypeLbl.Text = "AvailableHelp"
			Dim items3 As Object() = New Object() { "Coward", "Normal", "Brave", "Fanatic" }
			Me.BraveryList.Items.AddRange(items3)
			Dim location13 As Point = New Point(128, 48)
			Me.BraveryList.Location = location13
			Me.BraveryList.Name = "BraveryList"
			Dim size10 As Size = New Size(104, 56)
			Me.BraveryList.Size = size10
			Me.BraveryList.TabIndex = 9
			AddHandler Me.BraveryList.SelectedIndexChanged, AddressOf Me.BraveryList_SelectedIndexChanged
			Dim location14 As Point = New Point(128, 24)
			Me.BraveryLbl.Location = location14
			Me.BraveryLbl.Name = "BraveryLbl"
			Dim size11 As Size = New Size(88, 23)
			Me.BraveryLbl.Size = size11
			Me.BraveryLbl.TabIndex = 8
			Me.BraveryLbl.Text = "Bravery"
			Dim location15 As Point = New Point(128, 256)
			Me.HelpRangeLbl.Location = location15
			Me.HelpRangeLbl.Name = "HelpRangeLbl"
			Me.HelpRangeLbl.TabIndex = 7
			Me.HelpRangeLbl.Text = "Group help range"
			Dim location16 As Point = New Point(128, 280)
			Me.HelpRangeEdit.Location = location16
			Me.HelpRangeEdit.Name = "HelpRangeEdit"
			Me.HelpRangeEdit.TabIndex = 6
			Me.HelpRangeEdit.Text = ""
			AddHandler Me.HelpRangeEdit.Validated, AddressOf Me.HelpRangeEdit_Validated
			AddHandler Me.HelpRangeEdit.TextChanged, AddressOf Me.HelpRangeEdit_TextChanged
			Dim location17 As Point = New Point(8, 24)
			Me.BehaviorLbl.Location = location17
			Me.BehaviorLbl.Name = "BehaviorLbl"
			Me.BehaviorLbl.TabIndex = 5
			Me.BehaviorLbl.Text = "Group behavior"
			Dim items4 As Object() = New Object() { "Defend", "Scout", "Freelance", "Support", "Dumb" }
			Me.BehaviorList.Items.AddRange(items4)
			Dim location18 As Point = New Point(8, 48)
			Me.BehaviorList.Location = location18
			Me.BehaviorList.Name = "BehaviorList"
			Dim size12 As Size = New Size(104, 69)
			Me.BehaviorList.Size = size12
			Me.BehaviorList.TabIndex = 4
			AddHandler Me.BehaviorList.SelectedIndexChanged, AddressOf Me.BehaviorList_SelectedIndexChanged
			Me.ObjectivePanel.Controls.Add(Me.ObjectiveGroup)
			Dim location19 As Point = New Point(8, 712)
			Me.ObjectivePanel.Location = location19
			Me.ObjectivePanel.Name = "ObjectivePanel"
			Dim size13 As Size = New Size(240, 400)
			Me.ObjectivePanel.Size = size13
			Me.ObjectivePanel.TabIndex = 5
			Me.ObjectiveGroup.Controls.Add(Me.RewardLbl)
			Me.ObjectiveGroup.Controls.Add(Me.RewardNumeric)
			Me.ObjectiveGroup.Controls.Add(Me.TargetLbl)
			Me.ObjectiveGroup.Controls.Add(Me.RemoveBtn)
			Me.ObjectiveGroup.Controls.Add(Me.TargetList)
			Me.ObjectiveGroup.Controls.Add(Me.AddBtn)
			Me.ObjectiveGroup.Controls.Add(Me.ObjPathsLbl)
			Me.ObjectiveGroup.Controls.Add(Me.ObjLocLblb)
			Me.ObjectiveGroup.Controls.Add(Me.ObjPathList)
			Me.ObjectiveGroup.Controls.Add(Me.ObjLocList)
			Me.ObjectiveGroup.Controls.Add(Me.DescriptionLbl)
			Me.ObjectiveGroup.Controls.Add(Me.DescriptionEdit)
			Dim location20 As Point = New Point(0, 0)
			Me.ObjectiveGroup.Location = location20
			Me.ObjectiveGroup.Name = "ObjectiveGroup"
			Dim size14 As Size = New Size(240, 400)
			Me.ObjectiveGroup.Size = size14
			Me.ObjectiveGroup.TabIndex = 6
			Me.ObjectiveGroup.TabStop = False
			Me.ObjectiveGroup.Text = "Objective props"
			Dim location21 As Point = New Point(8, 120)
			Me.RewardLbl.Location = location21
			Me.RewardLbl.Name = "RewardLbl"
			Dim size15 As Size = New Size(48, 23)
			Me.RewardLbl.Size = size15
			Me.RewardLbl.TabIndex = 11
			Me.RewardLbl.Text = "Reward:"
			Dim increment As Decimal = New Decimal(New Integer() { 100, 0, 0, 0 })
			Me.RewardNumeric.Increment = increment
			Dim location22 As Point = New Point(56, 120)
			Me.RewardNumeric.Location = location22
			Dim maximum2 As Decimal = New Decimal(New Integer() { 10000000, 0, 0, 0 })
			Me.RewardNumeric.Maximum = maximum2
			Me.RewardNumeric.Name = "RewardNumeric"
			Dim size16 As Size = New Size(176, 20)
			Me.RewardNumeric.Size = size16
			Me.RewardNumeric.TabIndex = 10
			AddHandler Me.RewardNumeric.ValueChanged, AddressOf Me.RewardNumeric_ValueChanged
			Dim location23 As Point = New Point(8, 304)
			Me.TargetLbl.Location = location23
			Me.TargetLbl.Name = "TargetLbl"
			Me.TargetLbl.TabIndex = 9
			Me.TargetLbl.Text = "Targets"
			Dim location24 As Point = New Point(8, 272)
			Me.RemoveBtn.Location = location24
			Me.RemoveBtn.Name = "RemoveBtn"
			Dim size17 As Size = New Size(224, 23)
			Me.RemoveBtn.Size = size17
			Me.RemoveBtn.TabIndex = 8
			Me.RemoveBtn.Text = "Remove"
			AddHandler Me.RemoveBtn.Click, AddressOf Me.RemoveBtn_Click
			Dim location25 As Point = New Point(8, 328)
			Me.TargetList.Location = location25
			Me.TargetList.Name = "TargetList"
			Dim size18 As Size = New Size(224, 56)
			Me.TargetList.Size = size18
			Me.TargetList.TabIndex = 7
			Dim location26 As Point = New Point(8, 248)
			Me.AddBtn.Location = location26
			Me.AddBtn.Name = "AddBtn"
			Dim size19 As Size = New Size(224, 23)
			Me.AddBtn.Size = size19
			Me.AddBtn.TabIndex = 6
			Me.AddBtn.Text = "Add"
			AddHandler Me.AddBtn.Click, AddressOf Me.AddBtn_Click
			Dim location27 As Point = New Point(128, 152)
			Me.ObjPathsLbl.Location = location27
			Me.ObjPathsLbl.Name = "ObjPathsLbl"
			Me.ObjPathsLbl.TabIndex = 5
			Me.ObjPathsLbl.Text = "Paths"
			Dim location28 As Point = New Point(8, 152)
			Me.ObjLocLblb.Location = location28
			Me.ObjLocLblb.Name = "ObjLocLblb"
			Me.ObjLocLblb.TabIndex = 4
			Me.ObjLocLblb.Text = "Locations"
			Dim location29 As Point = New Point(128, 176)
			Me.ObjPathList.Location = location29
			Me.ObjPathList.Name = "ObjPathList"
			Dim size20 As Size = New Size(104, 69)
			Me.ObjPathList.Size = size20
			Me.ObjPathList.TabIndex = 3
			AddHandler Me.ObjPathList.SelectedIndexChanged, AddressOf Me.ObjPathList_SelectedIndexChanged
			Dim location30 As Point = New Point(8, 176)
			Me.ObjLocList.Location = location30
			Me.ObjLocList.Name = "ObjLocList"
			Dim size21 As Size = New Size(104, 69)
			Me.ObjLocList.Size = size21
			Me.ObjLocList.TabIndex = 2
			AddHandler Me.ObjLocList.SelectedIndexChanged, AddressOf Me.ObjLocList_SelectedIndexChanged
			Dim location31 As Point = New Point(8, 24)
			Me.DescriptionLbl.Location = location31
			Me.DescriptionLbl.Name = "DescriptionLbl"
			Me.DescriptionLbl.TabIndex = 1
			Me.DescriptionLbl.Text = "Description"
			Dim location32 As Point = New Point(8, 48)
			Me.DescriptionEdit.Location = location32
			Me.DescriptionEdit.Multiline = True
			Me.DescriptionEdit.Name = "DescriptionEdit"
			Dim size22 As Size = New Size(224, 64)
			Me.DescriptionEdit.Size = size22
			Me.DescriptionEdit.TabIndex = 0
			Me.DescriptionEdit.Text = ""
			AddHandler Me.DescriptionEdit.Validated, AddressOf Me.DescriptionEdit_Validated
			AddHandler Me.DescriptionEdit.TextChanged, AddressOf Me.DescriptionEdit_TextChanged
			Me.CurveGroupBox.Controls.Add(Me.LinkedTarget)
			Me.CurveGroupBox.Controls.Add(Me.RemoveTargetCurve)
			Me.CurveGroupBox.Controls.Add(Me.AddTargetCurve)
			Me.CurveGroupBox.Controls.Add(Me.ResolutionList)
			Me.CurveGroupBox.Controls.Add(Me.CurveMakeShots)
			Me.CurveGroupBox.Controls.Add(Me.CurveDebugShow)
			Me.CurveGroupBox.Controls.Add(Me.label8)
			Me.CurveGroupBox.Controls.Add(Me.CurveDebugStart)
			Me.CurveGroupBox.Controls.Add(Me.label9)
			Me.CurveGroupBox.Controls.Add(Me.ShowViewport)
			Me.CurveGroupBox.Controls.Add(Me.TargetUsed)
			Me.CurveGroupBox.Controls.Add(Me.label7)
			Me.CurveGroupBox.Controls.Add(Me.CurveActPercent)
			Me.CurveGroupBox.Controls.Add(Me.label6)
			Me.CurveGroupBox.Controls.Add(Me.label5)
			Me.CurveGroupBox.Controls.Add(Me.label4)
			Me.CurveGroupBox.Controls.Add(Me.label3)
			Me.CurveGroupBox.Controls.Add(Me.TargetCurveSelect)
			Me.CurveGroupBox.Controls.Add(Me.EyeCurveSelect)
			Me.CurveGroupBox.Controls.Add(Me.CurveActPos)
			Me.CurveGroupBox.Controls.Add(Me.CurvePositionTrack)
			Me.CurveGroupBox.Controls.Add(Me.CurveLoop)
			Me.CurveGroupBox.Controls.Add(Me.label2)
			Me.CurveGroupBox.Controls.Add(Me.CamForwardButton)
			Me.CurveGroupBox.Controls.Add(Me.CamRewindButton)
			Me.CurveGroupBox.Controls.Add(Me.CamPlayButton)
			Me.CurveGroupBox.Controls.Add(Me.CamPauseButton)
			Me.CurveGroupBox.Controls.Add(Me.CamBeginButton)
			Me.CurveGroupBox.Controls.Add(Me.RollCurveButton)
			Me.CurveGroupBox.Controls.Add(Me.FOVCurveButton)
			Me.CurveGroupBox.Controls.Add(Me.TimeCurveButton)
			Me.CurveGroupBox.Controls.Add(Me.CurveDuration)
			Me.CurveGroupBox.Controls.Add(Me.label1)
			Dim location33 As Point = New Point(8, 1128)
			Me.CurveGroupBox.Location = location33
			Me.CurveGroupBox.Name = "CurveGroupBox"
			Dim size23 As Size = New Size(240, 320)
			Me.CurveGroupBox.Size = size23
			Me.CurveGroupBox.TabIndex = 17
			Me.CurveGroupBox.TabStop = False
			Me.CurveGroupBox.Text = "Curve group props"
			Dim location34 As Point = New Point(21, 68)
			Me.LinkedTarget.Location = location34
			Me.LinkedTarget.Name = "LinkedTarget"
			Dim size24 As Size = New Size(40, 16)
			Me.LinkedTarget.Size = size24
			Me.LinkedTarget.TabIndex = 45
			Me.LinkedTarget.Text = "Linked"
			Me.LinkedTarget.Visible = False
			Dim location35 As Point = New Point(136, 64)
			Me.RemoveTargetCurve.Location = location35
			Me.RemoveTargetCurve.Name = "RemoveTargetCurve"
			Dim size25 As Size = New Size(88, 23)
			Me.RemoveTargetCurve.Size = size25
			Me.RemoveTargetCurve.TabIndex = 44
			Me.RemoveTargetCurve.Text = "RemoveTarget"
			AddHandler Me.RemoveTargetCurve.Click, AddressOf Me.RemoveTargetCurve_Click
			Dim location36 As Point = New Point(64, 64)
			Me.AddTargetCurve.Location = location36
			Me.AddTargetCurve.Name = "AddTargetCurve"
			Dim size26 As Size = New Size(72, 23)
			Me.AddTargetCurve.Size = size26
			Me.AddTargetCurve.TabIndex = 43
			Me.AddTargetCurve.Text = "AddTarget"
			AddHandler Me.AddTargetCurve.Click, AddressOf Me.AddTargetCurve_Click
			Me.ResolutionList.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location37 As Point = New Point(96, 280)
			Me.ResolutionList.Location = location37
			Me.ResolutionList.Name = "ResolutionList"
			Dim size27 As Size = New Size(121, 21)
			Me.ResolutionList.Size = size27
			Me.ResolutionList.TabIndex = 42
			Dim location38 As Point = New Point(145, 248)
			Me.CurveMakeShots.Location = location38
			Me.CurveMakeShots.Name = "CurveMakeShots"
			Dim size28 As Size = New Size(88, 24)
			Me.CurveMakeShots.Size = size28
			Me.CurveMakeShots.TabIndex = 41
			Me.CurveMakeShots.Text = "MakeShots"
			Dim location39 As Point = New Point(145, 232)
			Me.CurveDebugShow.Location = location39
			Me.CurveDebugShow.Name = "CurveDebugShow"
			Dim size29 As Size = New Size(88, 24)
			Me.CurveDebugShow.Size = size29
			Me.CurveDebugShow.TabIndex = 40
			Me.CurveDebugShow.Text = "DebugShow"
			Dim location40 As Point = New Point(116, 250)
			Me.label8.Location = location40
			Me.label8.Name = "label8"
			Dim size30 As Size = New Size(28, 16)
			Me.label8.Size = size30
			Me.label8.TabIndex = 39
			Me.label8.Text = "sec"
			Dim location41 As Point = New Point(69, 248)
			Me.CurveDebugStart.Location = location41
			Me.CurveDebugStart.Name = "CurveDebugStart"
			Dim size31 As Size = New Size(47, 20)
			Me.CurveDebugStart.Size = size31
			Me.CurveDebugStart.TabIndex = 38
			Me.CurveDebugStart.Text = ""
			AddHandler Me.CurveDebugStart.Validated, AddressOf Me.CurveDebugStart_Validated
			AddHandler Me.CurveDebugStart.TextChanged, AddressOf Me.CurveDebugStart_TextChanged
			Dim location42 As Point = New Point(7, 250)
			Me.label9.Location = location42
			Me.label9.Name = "label9"
			Dim size32 As Size = New Size(72, 16)
			Me.label9.Size = size32
			Me.label9.TabIndex = 37
			Me.label9.Text = "DebugStart:"
			Dim location43 As Point = New Point(180, 176)
			Me.ShowViewport.Location = location43
			Me.ShowViewport.Name = "ShowViewport"
			Dim size33 As Size = New Size(56, 24)
			Me.ShowViewport.Size = size33
			Me.ShowViewport.TabIndex = 36
			Me.ShowViewport.Text = "show"
			AddHandler Me.ShowViewport.CheckedChanged, AddressOf Me.ShowViewport_CheckedChanged
			Dim location44 As Point = New Point(46, 39)
			Me.TargetUsed.Location = location44
			Me.TargetUsed.Name = "TargetUsed"
			Dim size34 As Size = New Size(16, 24)
			Me.TargetUsed.Size = size34
			Me.TargetUsed.TabIndex = 35
			Me.TargetUsed.Text = "loop"
			AddHandler Me.TargetUsed.CheckedChanged, AddressOf Me.TargetUsed_CheckedChanged
			Dim location45 As Point = New Point(162, 154)
			Me.label7.Location = location45
			Me.label7.Name = "label7"
			Dim size35 As Size = New Size(16, 16)
			Me.label7.Size = size35
			Me.label7.TabIndex = 34
			Me.label7.Text = "%"
			Me.CurveActPercent.Cursor = Cursors.[Default]
			Me.CurveActPercent.Enabled = False
			Dim location46 As Point = New Point(128, 152)
			Me.CurveActPercent.Location = location46
			Me.CurveActPercent.Name = "CurveActPercent"
			Me.CurveActPercent.[ReadOnly] = True
			Dim size36 As Size = New Size(34, 20)
			Me.CurveActPercent.Size = size36
			Me.CurveActPercent.TabIndex = 33
			Me.CurveActPercent.Text = ""
			Dim location47 As Point = New Point(104, 154)
			Me.label6.Location = location47
			Me.label6.Name = "label6"
			Dim size37 As Size = New Size(28, 16)
			Me.label6.Size = size37
			Me.label6.TabIndex = 32
			Me.label6.Text = "sec"
			Dim location48 As Point = New Point(8, 154)
			Me.label5.Location = location48
			Me.label5.Name = "label5"
			Dim size38 As Size = New Size(48, 16)
			Me.label5.Size = size38
			Me.label5.TabIndex = 31
			Me.label5.Text = "Position:"
			Dim location49 As Point = New Point(6, 43)
			Me.label4.Location = location49
			Me.label4.Name = "label4"
			Dim size39 As Size = New Size(48, 16)
			Me.label4.Size = size39
			Me.label4.TabIndex = 30
			Me.label4.Text = "Target:"
			Dim location50 As Point = New Point(32, 19)
			Me.label3.Location = location50
			Me.label3.Name = "label3"
			Dim size40 As Size = New Size(32, 16)
			Me.label3.Size = size40
			Me.label3.TabIndex = 29
			Me.label3.Text = "Eye:"
			Me.TargetCurveSelect.AllowDrop = True
			Me.TargetCurveSelect.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location51 As Point = New Point(64, 40)
			Me.TargetCurveSelect.Location = location51
			Me.TargetCurveSelect.MaxDropDownItems = 16
			Me.TargetCurveSelect.Name = "TargetCurveSelect"
			Dim size41 As Size = New Size(160, 21)
			Me.TargetCurveSelect.Size = size41
			Me.TargetCurveSelect.TabIndex = 28
			AddHandler Me.TargetCurveSelect.SelectedIndexChanged, AddressOf Me.TargetCurveSelect_SelectedIndexChanged
			Me.EyeCurveSelect.AllowDrop = True
			Me.EyeCurveSelect.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location52 As Point = New Point(64, 16)
			Me.EyeCurveSelect.Location = location52
			Me.EyeCurveSelect.MaxDropDownItems = 16
			Me.EyeCurveSelect.Name = "EyeCurveSelect"
			Dim size42 As Size = New Size(160, 21)
			Me.EyeCurveSelect.Size = size42
			Me.EyeCurveSelect.TabIndex = 27
			AddHandler Me.EyeCurveSelect.SelectedIndexChanged, AddressOf Me.EyeCurveSelect_SelectedIndexChanged
			Me.CurveActPos.Cursor = Cursors.[Default]
			Me.CurveActPos.Enabled = False
			Dim location53 As Point = New Point(56, 152)
			Me.CurveActPos.Location = location53
			Me.CurveActPos.Name = "CurveActPos"
			Me.CurveActPos.[ReadOnly] = True
			Dim size43 As Size = New Size(48, 20)
			Me.CurveActPos.Size = size43
			Me.CurveActPos.TabIndex = 26
			Me.CurveActPos.Text = ""
			Me.CurvePositionTrack.LargeChange = 100
			Dim location54 As Point = New Point(8, 208)
			Me.CurvePositionTrack.Location = location54
			Me.CurvePositionTrack.Maximum = 10000
			Me.CurvePositionTrack.Name = "CurvePositionTrack"
			Dim size44 As Size = New Size(224, 45)
			Me.CurvePositionTrack.Size = size44
			Me.CurvePositionTrack.TabIndex = 25
			Me.CurvePositionTrack.TickStyle = TickStyle.None
			AddHandler Me.CurvePositionTrack.Scroll, AddressOf Me.CurvePositionTrack_Scroll
			Me.CurveLoop.Checked = True
			Me.CurveLoop.CheckState = CheckState.Checked
			Dim location55 As Point = New Point(180, 152)
			Me.CurveLoop.Location = location55
			Me.CurveLoop.Name = "CurveLoop"
			Dim size45 As Size = New Size(48, 24)
			Me.CurveLoop.Size = size45
			Me.CurveLoop.TabIndex = 24
			Me.CurveLoop.Text = "loop"
			Dim location56 As Point = New Point(104, 130)
			Me.label2.Location = location56
			Me.label2.Name = "label2"
			Dim size46 As Size = New Size(28, 16)
			Me.label2.Size = size46
			Me.label2.TabIndex = 23
			Me.label2.Text = "sec"
			Dim location57 As Point = New Point(136, 176)
			Me.CamForwardButton.Location = location57
			Me.CamForwardButton.Name = "CamForwardButton"
			Dim size47 As Size = New Size(32, 23)
			Me.CamForwardButton.Size = size47
			Me.CamForwardButton.TabIndex = 22
			Me.CamForwardButton.Text = ">>"
			AddHandler Me.CamForwardButton.Click, AddressOf Me.CamForwardButton_Click
			Dim location58 As Point = New Point(40, 176)
			Me.CamRewindButton.Location = location58
			Me.CamRewindButton.Name = "CamRewindButton"
			Dim size48 As Size = New Size(32, 23)
			Me.CamRewindButton.Size = size48
			Me.CamRewindButton.TabIndex = 21
			Me.CamRewindButton.Text = "<<"
			AddHandler Me.CamRewindButton.Click, AddressOf Me.CamRewindButton_Click
			Dim location59 As Point = New Point(104, 176)
			Me.CamPlayButton.Location = location59
			Me.CamPlayButton.Name = "CamPlayButton"
			Dim size49 As Size = New Size(32, 23)
			Me.CamPlayButton.Size = size49
			Me.CamPlayButton.TabIndex = 20
			Me.CamPlayButton.Text = ">"
			AddHandler Me.CamPlayButton.Click, AddressOf Me.CamPlayButton_Click
			Dim location60 As Point = New Point(72, 176)
			Me.CamPauseButton.Location = location60
			Me.CamPauseButton.Name = "CamPauseButton"
			Dim size50 As Size = New Size(32, 23)
			Me.CamPauseButton.Size = size50
			Me.CamPauseButton.TabIndex = 19
			Me.CamPauseButton.Text = "| |"
			AddHandler Me.CamPauseButton.Click, AddressOf Me.CamPauseButton_Click
			Dim location61 As Point = New Point(8, 176)
			Me.CamBeginButton.Location = location61
			Me.CamBeginButton.Name = "CamBeginButton"
			Dim size51 As Size = New Size(32, 23)
			Me.CamBeginButton.Size = size51
			Me.CamBeginButton.TabIndex = 18
			Me.CamBeginButton.Text = "|<<"
			AddHandler Me.CamBeginButton.Click, AddressOf Me.CamBeginButton_Click
			Dim location62 As Point = New Point(152, 96)
			Me.RollCurveButton.Location = location62
			Me.RollCurveButton.Name = "RollCurveButton"
			Dim size52 As Size = New Size(72, 23)
			Me.RollCurveButton.Size = size52
			Me.RollCurveButton.TabIndex = 14
			Me.RollCurveButton.Text = "Roll"
			AddHandler Me.RollCurveButton.Click, AddressOf Me.RollCurveButton_Click
			Dim location63 As Point = New Point(80, 96)
			Me.FOVCurveButton.Location = location63
			Me.FOVCurveButton.Name = "FOVCurveButton"
			Dim size53 As Size = New Size(72, 23)
			Me.FOVCurveButton.Size = size53
			Me.FOVCurveButton.TabIndex = 13
			Me.FOVCurveButton.Text = "FOV"
			AddHandler Me.FOVCurveButton.Click, AddressOf Me.FOVCurveButton_Click
			Dim location64 As Point = New Point(8, 96)
			Me.TimeCurveButton.Location = location64
			Me.TimeCurveButton.Name = "TimeCurveButton"
			Dim size54 As Size = New Size(72, 23)
			Me.TimeCurveButton.Size = size54
			Me.TimeCurveButton.TabIndex = 12
			Me.TimeCurveButton.Text = "Time%"
			AddHandler Me.TimeCurveButton.Click, AddressOf Me.TimeCurveButton_Click
			Dim location65 As Point = New Point(57, 128)
			Me.CurveDuration.Location = location65
			Me.CurveDuration.Name = "CurveDuration"
			Dim size55 As Size = New Size(47, 20)
			Me.CurveDuration.Size = size55
			Me.CurveDuration.TabIndex = 17
			Me.CurveDuration.Text = ""
			AddHandler Me.CurveDuration.Validated, AddressOf Me.CurveDuration_Validated
			AddHandler Me.CurveDuration.TextChanged, AddressOf Me.CurveDuration_TextChanged
			Dim location66 As Point = New Point(8, 130)
			Me.label1.Location = location66
			Me.label1.Name = "label1"
			Dim size56 As Size = New Size(56, 16)
			Me.label1.Size = size56
			Me.label1.TabIndex = 12
			Me.label1.Text = "Duration:"
			Dim location67 As Point = New Point(8, 336)
			Me.BuildingsCheck.Location = location67
			Me.BuildingsCheck.Name = "BuildingsCheck"
			Dim size57 As Size = New Size(224, 24)
			Me.BuildingsCheck.Size = size57
			Me.BuildingsCheck.TabIndex = 20
			Me.BuildingsCheck.Text = "Advanced building usage"
			AddHandler Me.BuildingsCheck.CheckedChanged, AddressOf Me.BuildingsCheck_CheckedChanged
			MyBase.Controls.Add(Me.ObjectivePanel)
			MyBase.Controls.Add(Me.UnitGroupBox)
			MyBase.Controls.Add(Me.ShowCheck)
			MyBase.Controls.Add(Me.EntityList)
			MyBase.Controls.Add(Me.CurveGroupBox)
			MyBase.Name = "ToolboxScriptEntities"
			Dim size58 As Size = New Size(256, 1456)
			MyBase.Size = size58
			AddHandler MyBase.Paint, AddressOf Me.ToolboxScriptEntities_Paint
			Me.UnitGroupBox.ResumeLayout(False)
			(CType(Me.MaxHelpNumeric, ISupportInitialize)).EndInit()
			Me.ObjectivePanel.ResumeLayout(False)
			Me.ObjectiveGroup.ResumeLayout(False)
			(CType(Me.RewardNumeric, ISupportInitialize)).EndInit()
			Me.CurveGroupBox.ResumeLayout(False)
			(CType(Me.CurvePositionTrack, ISupportInitialize)).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub SelectItem(lvi As ListViewItem)
			Dim backColor As Color = Color.FromKnownColor(KnownColor.Highlight)
			lvi.SubItems(1).BackColor = backColor
			Dim foreColor As Color = Color.FromKnownColor(KnownColor.HighlightText)
			lvi.SubItems(1).ForeColor = foreColor
			If Me.SCEType = 0 Then
				Dim backColor2 As Color = Color.FromKnownColor(KnownColor.Highlight)
				lvi.SubItems(3).BackColor = backColor2
				Dim foreColor2 As Color = Color.FromKnownColor(KnownColor.HighlightText)
				lvi.SubItems(3).ForeColor = foreColor2
			End If
		End Sub

		Private Sub DeselectItem(lvi As ListViewItem)
			Dim backColor As Color = Color.FromKnownColor(KnownColor.Window)
			lvi.SubItems(1).BackColor = backColor
			Dim foreColor As Color = Color.FromKnownColor(KnownColor.WindowText)
			lvi.SubItems(1).ForeColor = foreColor
			If Me.SCEType = 0 Then
				Dim backColor2 As Color = Color.FromKnownColor(KnownColor.Window)
				lvi.SubItems(3).BackColor = backColor2
				Dim foreColor2 As Color = Color.FromKnownColor(KnownColor.WindowText)
				lvi.SubItems(3).ForeColor = foreColor2
			End If
		End Sub

		Private Sub RefreshScriptEntityProps(idx As Integer)
			If Me.propWorld IsNot Nothing Then
				Dim sCEType As Integer = Me.SCEType
				If sCEType = 3 OrElse sCEType = 6 Then
					If sCEType = 3 Then
						If idx < 0 Then
							Me.PropsRefreshing = True
							Me.BehaviorList.SelectedIndex = -1
							Me.BraveryList.SelectedIndex = -1
							Me.FallbackList.SelectedIndex = -1
							Dim num As Integer = 0
							If 0 < Me.HelpTypeList.Items.Count Then
								Do
									Me.HelpTypeList.SetSelected(num, False)
									num += 1
								Loop While num < Me.HelpTypeList.Items.Count
							End If
							Me.RangeEdit.Text = ""
							Me.HelpRangeEdit.Text = ""
							Me.MaxHelpNumeric.Text = ""
							Me.VehiclesCheck.Checked = False
							Me.BuildingsCheck.Checked = False
							Me.PropsRefreshing = False
							Me.BehaviorList.Enabled = False
							Me.BraveryList.Enabled = False
							Me.FallbackList.Enabled = False
							Me.HelpTypeList.Enabled = False
							Me.MaxHelpNumeric.Enabled = False
							Me.RangeEdit.Enabled = False
							Me.HelpRangeEdit.Enabled = False
							Me.VehiclesCheck.Enabled = False
							Me.BuildingsCheck.Enabled = False
						Else
							Me.BehaviorList.Enabled = True
							Me.BraveryList.Enabled = True
							Me.FallbackList.Enabled = True
							Me.HelpTypeList.Enabled = True
							Me.MaxHelpNumeric.Enabled = True
							Me.RangeEdit.Enabled = True
							Me.HelpRangeEdit.Enabled = True
							Me.VehiclesCheck.Enabled = True
							Me.BuildingsCheck.Enabled = True
							Dim selectedIndex As GAIGroupProps
							<Module>.GEditorWorld.GetAIGroupProps(Me.propWorld, AddressOf selectedIndex, idx)
							Me.PropsRefreshing = True
							Me.BehaviorList.SelectedIndex = selectedIndex
							Me.BraveryList.SelectedIndex = __Dereference((selectedIndex + 16))
							Me.HelpTypeList.SetSelected(0, CByte((__Dereference((selectedIndex + 12)) And 1)) <> 0)
							Dim value As Byte = CByte((CUInt((__Dereference((selectedIndex + 12)))) >> 1 And 1UI))
							Me.HelpTypeList.SetSelected(1, value <> 0)
							Dim value2 As Byte = CByte((CUInt((__Dereference((selectedIndex + 12)))) >> 2 And 1UI))
							Me.HelpTypeList.SetSelected(2, value2 <> 0)
							Dim value3 As Byte = CByte((CUInt((__Dereference((selectedIndex + 12)))) >> 3 And 1UI))
							Me.HelpTypeList.SetSelected(3, value3 <> 0)
							Dim value4 As Byte = CByte((CUInt((__Dereference((selectedIndex + 12)))) >> 4 And 1UI))
							Me.HelpTypeList.SetSelected(4, value4 <> 0)
							Dim value5 As Byte = CByte((CUInt((__Dereference((selectedIndex + 12)))) >> 5 And 1UI))
							Me.HelpTypeList.SetSelected(5, value5 <> 0)
							Dim value6 As Byte = CByte((CUInt((__Dereference((selectedIndex + 12)))) >> 6 And 1UI))
							Me.HelpTypeList.SetSelected(6, value6 <> 0)
							If __Dereference((selectedIndex + 24)) = -1 Then
								Me.FallbackList.SelectedIndex = 0
							Else If __Dereference((selectedIndex + 24)) = -2 Then
								Me.FallbackList.SelectedIndex = 1
							Else
								Dim num2 As Integer = 0
								If 0 < Me.Locations.Length Then
									Do
										If Me.Locations(num2) = __Dereference((selectedIndex + 24)) Then
											Me.FallbackList.SelectedIndex = num2 + 2
										End If
										num2 += 1
									Loop While num2 < Me.Locations.Length
								End If
							End If
							Dim num3 As Single = __Dereference((selectedIndex + 4)) / <Module>.Measures
							Me.RangeEdit.Text = num3.ToString()
							Dim num4 As Single = __Dereference((selectedIndex + 8)) / <Module>.Measures
							Me.HelpRangeEdit.Text = num4.ToString()
							Dim value7 As Decimal = New Decimal(__Dereference((selectedIndex + 20)))
							Me.MaxHelpNumeric.Value = value7
							Me.VehiclesCheck.Checked = (__Dereference((selectedIndex + 28)) <> 0)
							Me.BuildingsCheck.Checked = (__Dereference((selectedIndex + 29)) <> 0)
							Me.PropsRefreshing = False
						End If
					Else If sCEType = 6 Then
						If idx < 0 Then
							Me.PropsRefreshing = True
							Me.ObjLocList.SelectedIndex = -1
							Me.ObjPathList.SelectedIndex = -1
							Me.TargetList.SelectedIndex = -1
							Me.DescriptionEdit.Text = ""
							Dim value8 As Decimal = New Decimal(0)
							Me.RewardNumeric.Value = value8
							Me.PropsRefreshing = False
							Me.ObjLocList.Enabled = False
							Me.ObjPathList.Enabled = False
							Me.TargetList.Enabled = False
							Me.DescriptionEdit.Enabled = False
							Me.RewardNumeric.Enabled = False
						Else
							Me.ObjLocList.Enabled = True
							Me.ObjPathList.Enabled = True
							Me.TargetList.Enabled = True
							Me.DescriptionEdit.Enabled = True
							Me.RewardNumeric.Enabled = True
							Me.PropsRefreshing = True
							Dim gBaseString<char> As GBaseString<char>
							Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetObjectiveDescription(Me.propWorld, AddressOf gBaseString<char>, idx)
							Try
								Dim num5 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
								Dim value9 As __Pointer(Of SByte)
								If num5 <> 0UI Then
									value9 = num5
								Else
									value9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								Me.DescriptionEdit.Text = New String(CType(value9, __Pointer(Of SByte)))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char> IsNot Nothing Then
								<Module>.free(gBaseString<char>)
							End If
							Dim value10 As Decimal = New Decimal(<Module>.GEditorWorld.GetObjectiveReward(Me.propWorld, idx))
							Me.RewardNumeric.Value = value10
							Me.TargetList.Items.Clear()
							Dim num6 As Integer = idx * 68
							Dim num7 As Integer = __Dereference((num6 + __Dereference(CType((Me.propWorld + 3416 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 4 + 40))
							Me.Targets = New Integer(num7 - 1) {}
							Dim num8 As Integer = 0
							Dim gBaseString<char>2 As GBaseString<char> = 0
							__Dereference((gBaseString<char>2 + 4)) = 0
							Try
								Dim gBaseString<char>3 As GBaseString<char> = 0
								__Dereference((gBaseString<char>3 + 4)) = 0
								Try
									Dim num9 As Integer = -1
									While True
										Dim ptr2 As __Pointer(Of GWObjective) = num6 + __Dereference(CType((Me.propWorld + 3416 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 4
										Dim num10 As Integer = num9 + 1
										Dim num11 As Integer = num9 * 8 + 8
										If num10 >= __Dereference((ptr2 + 40)) Then
											Exit While
										End If
										num9 = num10
										If num10 < 0 Then
											Exit While
										End If
										<Module>.GBaseString<char>.Format(gBaseString<char>2, CType((AddressOf <Module>.??_C@_0O@PNCAEKFM@Target?5?$CFd?5?3?3?5?$AA@), __Pointer(Of SByte)), num10)
										Dim ptr3 As __Pointer(Of GEditorWorld) = Me.propWorld
										Dim num12 As Integer = num6 + __Dereference(CType((ptr3 + 3416 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 4
										Dim ptr4 As __Pointer(Of GWObjective) = num12
										If __Dereference((num11 + __Dereference((ptr4 + 36)) + 4)) = 0 Then
											Dim ptr5 As __Pointer(Of GAObjectiveTarget) = __Dereference((num12 + 36)) + num11
											If <Module>.GHeap<GWLocation>.Present(ptr3 + 3352 / __SizeOf(GEditorWorld), __Dereference(ptr5)) IsNot Nothing Then
												Dim num13 As Integer = __Dereference((__Dereference((num12 + 36)) + num11))
												<Module>.GBaseString<char>.=(gBaseString<char>3, __Dereference(CType((ptr3 + 3352 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + num13 * 76 + 4)
											Else
												<Module>.GBaseString<char>.=(gBaseString<char>3, CType((AddressOf <Module>.??_C@_0BB@JAFGFJIC@Invalid?5location?$AA@), __Pointer(Of SByte)))
											End If
										Else
											Dim ptr6 As __Pointer(Of GAObjectiveTarget) = __Dereference((num12 + 36)) + num11
											If <Module>.GHeap<GWPath>.Present(ptr3 + 3312 / __SizeOf(GEditorWorld), __Dereference(ptr6)) IsNot Nothing Then
												Dim ptr7 As __Pointer(Of GAObjectiveTarget) = __Dereference((num12 + 36)) + num11
												<Module>.GBaseString<char>.=(gBaseString<char>3, <Module>.GHeap<GWPath>.[](ptr3 + 3312 / __SizeOf(GEditorWorld), __Dereference(ptr7)))
											Else
												<Module>.GBaseString<char>.=(gBaseString<char>3, CType((AddressOf <Module>.??_C@_0N@KKHAJPLM@Invalid?5path?$AA@), __Pointer(Of SByte)))
											End If
										End If
										Dim gBaseString<char>4 As GBaseString<char>
										Dim ptr8 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(gBaseString<char>2, AddressOf gBaseString<char>4, gBaseString<char>3)
										Try
											Me.TargetList.Items.Add(New String(<Module>.GBaseString<char>..PBD(ptr8)))
										Catch 
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
											Throw
										End Try
										<Module>.GBaseString<char>.{dtor}(gBaseString<char>4)
										Me.Targets(num8) = num10
										num8 += 1
									End While
									Me.PropsRefreshing = False
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
									Throw
								End Try
								<Module>.GBaseString<char>.{dtor}(gBaseString<char>3)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GBaseString<char>.{dtor}(gBaseString<char>2)
						End If
					End If
				End If
			End If
		End Sub

		Public Sub RefreshEntityList()
			Me.EntityList.Items.Clear()
			If Me.propWorld IsNot Nothing Then
				Dim gBaseString<char> As GBaseString<char> = 0
				__Dereference((gBaseString<char> + 4)) = 0
				Try
					Dim color As Color = Nothing
					Me.EntityList.BeginUpdate()
					Dim num17 As Integer
					Select Case Me.SCEType
						Case 0
							Dim num As Integer = <Module>.GHeap<GWPath>.GetNext(Me.propWorld + 3312 / __SizeOf(GEditorWorld), -1)
							If num >= 0 Then
								Do
									Dim gBaseString<char>2 As GBaseString<char>
									Dim src As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetPathName(Me.propWorld, AddressOf gBaseString<char>2, num)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>2 IsNot Nothing Then
										<Module>.free(gBaseString<char>2)
										gBaseString<char>2 = 0
									End If
									color = Color.FromArgb(<Module>.GEditorWorld.GetPathColor(Me.propWorld, num))
									color = Color.FromArgb(255, color)
									Dim listViewItem As ListViewItem = New ListViewItem()
									listViewItem.UseItemStyleForSubItems = False
									Dim value As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value = gBaseString<char>
									Else
										value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem.Text = New String(CType(value, __Pointer(Of SByte)))
									listViewItem.Tag = num
									If gBaseString<char> IsNot Nothing Then
										value = gBaseString<char>
									Else
										value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem.SubItems.Add(New String(CType(value, __Pointer(Of SByte))))
									Dim arg_161_0 As ListViewItem.ListViewSubItemCollection = listViewItem.SubItems
									Dim arg_161_1 As String = ""
									Dim expr_14C As Color = color
									arg_161_0.Add(arg_161_1, expr_14C, expr_14C, New Font(New String(CType((AddressOf <Module>.??_C@_05MPFIAJAP@Arial?$AA@), __Pointer(Of SByte))), 1F))
									Dim num2 As Integer = <Module>.GEditorWorld.GetPathLooping(Me.propWorld, num)
									If num2 <> 0 Then
										If num2 <> 1 Then
											If num2 = 2 Then
												listViewItem.SubItems.Add("Return")
											End If
										Else
											listViewItem.SubItems.Add("Loop")
										End If
									Else
										listViewItem.SubItems.Add("Single")
									End If
									If num = Me.SelectedWorldIndex Then
										Me.SelectItem(listViewItem)
									End If
									Me.EntityList.Items.Add(listViewItem)
									num = <Module>.GHeap<GWPath>.GetNext(Me.propWorld + 3312 / __SizeOf(GEditorWorld), num)
								Loop While num >= 0
							End If
						Case 1
							Dim num3 As Integer = <Module>.GHeap<GWLocation>.GetNext(Me.propWorld + 3352 / __SizeOf(GEditorWorld), -1)
							If num3 >= 0 Then
								While True
									Dim gBaseString<char>3 As GBaseString<char>
									Dim src2 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetLocationName(Me.propWorld, AddressOf gBaseString<char>3, num3)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src2)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>3 IsNot Nothing Then
										<Module>.free(gBaseString<char>3)
										gBaseString<char>3 = 0
									End If
									color = Color.FromArgb(<Module>.GEditorWorld.GetLocationColor(Me.propWorld, num3))
									color = Color.FromArgb(255, color)
									Dim listViewItem2 As ListViewItem = New ListViewItem()
									listViewItem2.UseItemStyleForSubItems = False
									Dim value2 As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value2 = gBaseString<char>
									Else
										value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem2.Text = New String(CType(value2, __Pointer(Of SByte)))
									listViewItem2.Tag = num3
									If gBaseString<char> IsNot Nothing Then
										value2 = gBaseString<char>
									Else
										value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem2.SubItems.Add(New String(CType(value2, __Pointer(Of SByte))))
									Dim arg_6B1_0 As ListViewItem.ListViewSubItemCollection = listViewItem2.SubItems
									Dim arg_6B1_1 As String = ""
									Dim expr_69C As Color = color
									arg_6B1_0.Add(arg_6B1_1, expr_69C, expr_69C, New Font(New String(CType((AddressOf <Module>.??_C@_05MPFIAJAP@Arial?$AA@), __Pointer(Of SByte))), 1F))
									Select Case <Module>.GEditorWorld.GetLocationEffectRange(Me.propWorld, num3)
										Case 1
											listViewItem2.SubItems.Add("Ground")
										Case 2
											listViewItem2.SubItems.Add("Air")
										Case 3
											listViewItem2.SubItems.Add("Full")
										Case 4
											listViewItem2.SubItems.Add("Civil meeting area")
										Case 5, 6, 7
											GoTo IL_750
										Case 8
											listViewItem2.SubItems.Add("Patrol waiting area")
										Case Else
											GoTo IL_750
									End Select
									IL_761:
									If <Module>.GEditorWorld.IsLocationEventSource(Me.propWorld, num3) IsNot Nothing Then
										listViewItem2.SubItems.Add("Active")
									Else
										listViewItem2.SubItems.Add("Passive")
									End If
									If num3 = Me.SelectedWorldIndex Then
										Me.SelectItem(listViewItem2)
									End If
									Me.EntityList.Items.Add(listViewItem2)
									num3 = <Module>.GHeap<GWLocation>.GetNext(Me.propWorld + 3352 / __SizeOf(GEditorWorld), num3)
									If num3 < 0 Then
										Exit While
									End If
									Continue While
									IL_750:
									listViewItem2.SubItems.Add("Invalid")
									GoTo IL_761
								End While
							End If
						Case 2
							Dim num2 As Integer = <Module>.GHeap<GWCameraCurve>.GetNext(Me.propWorld + 3196 / __SizeOf(GEditorWorld), -1)
							If num2 >= 0 Then
								Do
									Dim gBaseString<char>4 As GBaseString<char>
									Dim src3 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetCameraCurveName(Me.propWorld, AddressOf gBaseString<char>4, num2)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src3)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>4 IsNot Nothing Then
										<Module>.free(gBaseString<char>4)
										gBaseString<char>4 = 0
									End If
									color = Color.FromArgb(<Module>.GEditorWorld.GetCameraCurveColor(Me.propWorld, num2))
									color = Color.FromArgb(255, color)
									Dim listViewItem3 As ListViewItem = New ListViewItem()
									listViewItem3.UseItemStyleForSubItems = False
									Dim value3 As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value3 = gBaseString<char>
									Else
										value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem3.Text = New String(CType(value3, __Pointer(Of SByte)))
									listViewItem3.Tag = num2
									If gBaseString<char> IsNot Nothing Then
										value3 = gBaseString<char>
									Else
										value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem3.SubItems.Add(New String(CType(value3, __Pointer(Of SByte))))
									Dim arg_2F9_0 As ListViewItem.ListViewSubItemCollection = listViewItem3.SubItems
									Dim arg_2F9_1 As String = ""
									Dim expr_2E4 As Color = color
									arg_2F9_0.Add(arg_2F9_1, expr_2E4, expr_2E4, New Font(New String(CType((AddressOf <Module>.??_C@_05MPFIAJAP@Arial?$AA@), __Pointer(Of SByte))), 1F))
									Dim num4 As Integer = <Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(Me.propWorld, num2)
									If num4 <> 0 Then
										If num4 = 1 Then
											listViewItem3.SubItems.Add("Target")
										End If
									Else
										listViewItem3.SubItems.Add("Eye")
									End If
									If num2 = Me.SelectedWorldIndex Then
										Me.SelectItem(listViewItem3)
									End If
									Me.EntityList.Items.Add(listViewItem3)
									num2 = <Module>.GHeap<GWCameraCurve>.GetNext(Me.propWorld + 3196 / __SizeOf(GEditorWorld), num2)
								Loop While num2 >= 0
							End If
							Me.CameraEyeCurveSelectedIdx = Me.EyeCurveSelect.SelectedIndex
							Me.CameraTargetCurveSelectedIdx = Me.TargetCurveSelect.SelectedIndex
							Me.EyeCurveSelect.Items.Clear()
							Me.TargetCurveSelect.Items.Clear()
							Dim num5 As Integer = <Module>.GHeap<GWCameraCurve>.GetNext(Me.propWorld + 3196 / __SizeOf(GEditorWorld), -1)
							If num5 >= 0 Then
								Do
									If <Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(Me.propWorld, num5) Is Nothing Then
										Dim gBaseString<char>5 As GBaseString<char>
										Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetCameraCurveName(Me.propWorld, AddressOf gBaseString<char>5, num5)
										Try
											Dim num6 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
											Dim value4 As __Pointer(Of SByte)
											If num6 <> 0UI Then
												value4 = num6
											Else
												value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
											End If
											Me.EyeCurveSelect.Items.Add(New String(CType(value4, __Pointer(Of SByte))))
										Catch 
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
											Throw
										End Try
										If gBaseString<char>5 IsNot Nothing Then
											<Module>.free(gBaseString<char>5)
											gBaseString<char>5 = 0
										End If
									Else If <Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(Me.propWorld, num5) = 1 Then
										Dim gBaseString<char>6 As GBaseString<char>
										Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetCameraCurveName(Me.propWorld, AddressOf gBaseString<char>6, num5)
										Try
											Dim num6 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
											Dim value4 As __Pointer(Of SByte)
											If num6 <> 0UI Then
												value4 = num6
											Else
												value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
											End If
											Me.TargetCurveSelect.Items.Add(New String(CType(value4, __Pointer(Of SByte))))
										Catch 
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
											Throw
										End Try
										If gBaseString<char>6 IsNot Nothing Then
											<Module>.free(gBaseString<char>6)
											gBaseString<char>6 = 0
										End If
									End If
									num5 = <Module>.GHeap<GWCameraCurve>.GetNext(Me.propWorld + 3196 / __SizeOf(GEditorWorld), num5)
								Loop While num5 >= 0
							End If
							If Me.EyeCurveSelect.Items.Count <> 0 Then
								Dim num7 As Integer = Me.CameraEyeCurveSelectedIdx
								If num7 < Me.EyeCurveSelect.Items.Count Then
									Me.EyeCurveSelect.SelectedIndex = num7
								Else
									Me.EyeCurveSelect.SelectedIndex = Me.EyeCurveSelect.Items.Count - 1
								End If
							End If
							If Me.TargetCurveSelect.Items.Count <> 0 Then
								Dim num7 As Integer = Me.CameraTargetCurveSelectedIdx
								If num7 < Me.TargetCurveSelect.Items.Count Then
									Me.TargetCurveSelect.SelectedIndex = num7
								Else
									Me.TargetCurveSelect.SelectedIndex = Me.TargetCurveSelect.Items.Count - 1
								End If
							End If
							Me.CameraEyeCurveSelectedIdx = Me.EyeCurveSelect.SelectedIndex
							Me.CameraTargetCurveSelectedIdx = Me.TargetCurveSelect.SelectedIndex
							Me.RefreshCameraCurveIndex()
						Case 3
							Dim num8 As Integer = <Module>.GHeap<GWAIGroup>.GetNext(Me.propWorld + 3392 / __SizeOf(GEditorWorld), -1)
							If num8 >= 0 Then
								Do
									Dim gBaseString<char>7 As GBaseString<char>
									Dim src4 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetAIGroupName(Me.propWorld, AddressOf gBaseString<char>7, num8)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src4)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>7), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>7 IsNot Nothing Then
										<Module>.free(gBaseString<char>7)
										gBaseString<char>7 = 0
									End If
									color = Color.FromArgb(<Module>.GEditorWorld.GetAIGroupColor(Me.propWorld, num8))
									color = Color.FromArgb(255, color)
									Dim listViewItem4 As ListViewItem = New ListViewItem()
									listViewItem4.UseItemStyleForSubItems = False
									Dim value5 As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value5 = gBaseString<char>
									Else
										value5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem4.Text = New String(CType(value5, __Pointer(Of SByte)))
									listViewItem4.Tag = num8
									If gBaseString<char> IsNot Nothing Then
										value5 = gBaseString<char>
									Else
										value5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem4.SubItems.Add(New String(CType(value5, __Pointer(Of SByte))))
									Dim arg_8D6_0 As ListViewItem.ListViewSubItemCollection = listViewItem4.SubItems
									Dim arg_8D6_1 As String = ""
									Dim expr_8C1 As Color = color
									arg_8D6_0.Add(arg_8D6_1, expr_8C1, expr_8C1, New Font(New String(CType((AddressOf <Module>.??_C@_05MPFIAJAP@Arial?$AA@), __Pointer(Of SByte))), 1F))
									If __Dereference((num8 * 392 + __Dereference(CType((Me.propWorld + 3392 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 8 + 55)) <> 0 Then
										listViewItem4.SubItems.Add("Empty")
									Else
										listViewItem4.SubItems.Add("Normal")
									End If
									If num8 = Me.SelectedWorldIndex Then
										Me.SelectItem(listViewItem4)
									End If
									Me.EntityList.Items.Add(listViewItem4)
									num8 = <Module>.GHeap<GWAIGroup>.GetNext(Me.propWorld + 3392 / __SizeOf(GEditorWorld), num8)
								Loop While num8 >= 0
							End If
							Me.FallbackList.Items.Clear()
							Me.FallbackList.Items.Add("None")
							Me.FallbackList.Items.Add("Merge group")
							Dim ptr2 As __Pointer(Of GEditorWorld) = Me.propWorld
							Dim num9 As Integer = __Dereference(CType((ptr2 + 3368 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
							Me.Locations = New Integer(num9 - 1) {}
							num9 = 0
							Dim num10 As Integer = <Module>.GHeap<GWLocation>.GetNext(ptr2 + 3352 / __SizeOf(GEditorWorld), -1)
							If num10 >= 0 Then
								Do
									Dim gBaseString<char>8 As GBaseString<char>
									Dim src5 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetLocationName(Me.propWorld, AddressOf gBaseString<char>8, num10)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src5)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>8), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>8 IsNot Nothing Then
										<Module>.free(gBaseString<char>8)
										gBaseString<char>8 = 0
									End If
									Dim value6 As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value6 = gBaseString<char>
									Else
										value6 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									Me.FallbackList.Items.Add(New String(CType(value6, __Pointer(Of SByte))))
									Me.Locations(num9) = num10
									num9 += 1
									num10 = <Module>.GHeap<GWLocation>.GetNext(Me.propWorld + 3352 / __SizeOf(GEditorWorld), num10)
								Loop While num10 >= 0
							End If
						Case 4
							Dim num11 As Integer = <Module>.GHeap<GSector>.GetNext(Me.propWorld + 2712 / __SizeOf(GEditorWorld), -1)
							If num11 >= 0 Then
								Do
									Dim gBaseString<char>9 As GBaseString<char>
									Dim src6 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetSectorName(Me.propWorld, AddressOf gBaseString<char>9, num11)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src6)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>9), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>9 IsNot Nothing Then
										<Module>.free(gBaseString<char>9)
										gBaseString<char>9 = 0
									End If
									color = Color.FromArgb(<Module>.GEditorWorld.GetSectorColor(Me.propWorld, num11))
									color = Color.FromArgb(255, color)
									Dim listViewItem5 As ListViewItem = New ListViewItem()
									listViewItem5.UseItemStyleForSubItems = False
									Dim value7 As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value7 = gBaseString<char>
									Else
										value7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem5.Text = New String(CType(value7, __Pointer(Of SByte)))
									listViewItem5.Tag = num11
									If gBaseString<char> IsNot Nothing Then
										value7 = gBaseString<char>
									Else
										value7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem5.SubItems.Add(New String(CType(value7, __Pointer(Of SByte))))
									Dim arg_B6F_0 As ListViewItem.ListViewSubItemCollection = listViewItem5.SubItems
									Dim arg_B6F_1 As String = ""
									Dim expr_B5A As Color = color
									arg_B6F_0.Add(arg_B6F_1, expr_B5A, expr_B5A, New Font(New String(CType((AddressOf <Module>.??_C@_05MPFIAJAP@Arial?$AA@), __Pointer(Of SByte))), 1F))
									If <Module>.GWorld.IsSectorInactive(Me.propWorld, num11) IsNot Nothing Then
										listViewItem5.SubItems.Add("Inactive")
									Else
										listViewItem5.SubItems.Add("Active")
									End If
									If <Module>.GWorld.IsSectorAISleep(Me.propWorld, num11) IsNot Nothing Then
										listViewItem5.SubItems.Add("AI sleep")
									Else
										listViewItem5.SubItems.Add("AI active")
									End If
									If num11 = Me.SelectedWorldIndex Then
										Me.SelectItem(listViewItem5)
									End If
									Me.EntityList.Items.Add(listViewItem5)
									num11 = <Module>.GHeap<GSector>.GetNext(Me.propWorld + 2712 / __SizeOf(GEditorWorld), num11)
								Loop While num11 >= 0
							End If
						Case 6
							Dim num12 As Integer = <Module>.GHeap<GWObjective>.GetNext(Me.propWorld + 3416 / __SizeOf(GEditorWorld), -1)
							If num12 >= 0 Then
								Do
									Dim gBaseString<char>10 As GBaseString<char>
									Dim src7 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetObjectiveName(Me.propWorld, AddressOf gBaseString<char>10, num12)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src7)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>10), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>10 IsNot Nothing Then
										<Module>.free(gBaseString<char>10)
										gBaseString<char>10 = 0
									End If
									Dim listViewItem6 As ListViewItem = New ListViewItem()
									listViewItem6.UseItemStyleForSubItems = False
									Dim value8 As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value8 = gBaseString<char>
									Else
										value8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem6.Text = New String(CType(value8, __Pointer(Of SByte)))
									listViewItem6.Tag = num12
									If gBaseString<char> IsNot Nothing Then
										value8 = gBaseString<char>
									Else
										value8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									listViewItem6.SubItems.Add(New String(CType(value8, __Pointer(Of SByte))))
									Dim num13 As Integer = <Module>.GEditorWorld.GetObjectiveType(Me.propWorld, num12)
									If num13 <> 0 Then
										If num13 <> 1 Then
											If num13 = 2 Then
												listViewItem6.SubItems.Add("Condition")
											End If
										Else
											listViewItem6.SubItems.Add("Optional")
										End If
									Else
										listViewItem6.SubItems.Add("Primary")
									End If
									If <Module>.GEditorWorld.IsObjectiveActive(Me.propWorld, num12) IsNot Nothing Then
										listViewItem6.SubItems.Add("Active")
									Else
										listViewItem6.SubItems.Add("Inactive")
									End If
									If num12 = Me.SelectedWorldIndex Then
										Me.SelectItem(listViewItem6)
									End If
									Me.EntityList.Items.Add(listViewItem6)
									num12 = <Module>.GHeap<GWObjective>.GetNext(Me.propWorld + 3416 / __SizeOf(GEditorWorld), num12)
								Loop While num12 >= 0
							End If
							Me.ObjLocList.Items.Clear()
							Dim ptr3 As __Pointer(Of GEditorWorld) = Me.propWorld
							Dim num14 As Integer = __Dereference(CType((ptr3 + 3368 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
							Me.Locations = New Integer(num14 - 1) {}
							num14 = 0
							Dim num15 As Integer = <Module>.GHeap<GWLocation>.GetNext(ptr3 + 3352 / __SizeOf(GEditorWorld), -1)
							If num15 >= 0 Then
								Do
									Dim gBaseString<char>11 As GBaseString<char>
									Dim src8 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetLocationName(Me.propWorld, AddressOf gBaseString<char>11, num15)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src8)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>11), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>11 IsNot Nothing Then
										<Module>.free(gBaseString<char>11)
										gBaseString<char>11 = 0
									End If
									Dim value9 As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value9 = gBaseString<char>
									Else
										value9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									Me.ObjLocList.Items.Add(New String(CType(value9, __Pointer(Of SByte))))
									Me.Locations(num14) = num15
									num14 += 1
									num15 = <Module>.GHeap<GWLocation>.GetNext(Me.propWorld + 3352 / __SizeOf(GEditorWorld), num15)
								Loop While num15 >= 0
							End If
							Me.ObjPathList.Items.Clear()
							Dim ptr4 As __Pointer(Of GEditorWorld) = Me.propWorld
							Dim num16 As Integer = __Dereference(CType((ptr4 + 3328 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
							Me.Paths = New Integer(num16 - 1) {}
							num16 = 0
							num17 = <Module>.GHeap<GWPath>.GetNext(ptr4 + 3312 / __SizeOf(GEditorWorld), -1)
							If num17 >= 0 Then
								Do
									Dim gBaseString<char>12 As GBaseString<char>
									Dim src9 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetPathName(Me.propWorld, AddressOf gBaseString<char>12, num17)
									Try
										<Module>.GBaseString<char>.=(gBaseString<char>, src9)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>12), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>12 IsNot Nothing Then
										<Module>.free(gBaseString<char>12)
										gBaseString<char>12 = 0
									End If
									Dim value10 As __Pointer(Of SByte)
									If gBaseString<char> IsNot Nothing Then
										value10 = gBaseString<char>
									Else
										value10 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									Me.ObjPathList.Items.Add(New String(CType(value10, __Pointer(Of SByte))))
									Me.Paths(num16) = num17
									num16 += 1
									num17 = <Module>.GHeap<GWPath>.GetNext(Me.propWorld + 3312 / __SizeOf(GEditorWorld), num17)
								Loop While num17 >= 0
							End If
					End Select
					Me.EntityList.EndUpdate()
					Dim num18 As Integer = 0
					num17 = 2
					If 2 < Me.EntityList.Columns.Count Then
						Do
							num18 = Me.EntityList.Columns(num17).Width + num18
							num17 += 1
						Loop While num17 < Me.EntityList.Columns.Count
					End If
					Dim clientSize As Size = Me.EntityList.ClientSize
					Me.EntityList.Columns(1).Width = clientSize.Width - num18
					num18 = 0
					If 0 >= Me.EntityList.Items.Count Then
						GoTo IL_1088
					End If
					Do
						Dim tag As Object = Me.EntityList.Items(num18).Tag
						If __Dereference((If((Not(TypeOf tag Is Integer)), 0, CInt(tag)))) = Me.SelectedWorldIndex Then
							GoTo IL_1055
						End If
						num18 += 1
					Loop While num18 < Me.EntityList.Items.Count
					GoTo IL_1088
					IL_1055:
					Me.SelectedItem = num18
					Me.RefreshScriptEntityProps(Me.SelectedWorldIndex)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
					Return
				End If
				Return
				IL_1088:
				Try
					Me.SelectedItem = -1
					Me.SelectedWorldIndex = -1
					Me.RefreshScriptEntityProps(-1)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			End If
		End Sub

		Public Sub UpdateHilighting()
			If Me.propWorld IsNot Nothing AndAlso Me.SCEType = 3 Then
				Dim gArray<int> As GArray<int> = 0
				__Dereference((gArray<int> + 4)) = 0
				__Dereference((gArray<int> + 8)) = 0
				Try
					<Module>.GEditorWorld.CountAIGroupSelections(Me.propWorld, gArray<int>)
					Dim num As Integer = 0
					Dim num2 As Integer = -1
					Dim num3 As Integer = 0
					If 0 < Me.EntityList.Items.Count Then
						Do
							If num3 <> Me.SelectedItem Then
								Dim tag As Object = Me.EntityList.Items(num3).Tag
								If __Dereference((__Dereference((If((Not(TypeOf tag Is Integer)), 0, CInt(tag)))) * 4 + gArray<int>)) > 0 Then
									Dim backColor As Color = Color.FromKnownColor(KnownColor.ControlLightLight)
									Me.EntityList.Items(num3).SubItems(1).BackColor = backColor
									num += 1
									Dim tag2 As Object = Me.EntityList.Items(num3).Tag
									num2 = __Dereference((If((Not(TypeOf tag2 Is Integer)), 0, CInt(tag2))))
								Else
									Dim backColor2 As Color = Color.FromKnownColor(KnownColor.Window)
									Me.EntityList.Items(num3).SubItems(1).BackColor = backColor2
								End If
							End If
							num3 += 1
						Loop While num3 < Me.EntityList.Items.Count
						If num <> 0 Then
							If num <> 1 Then
								Me.RefreshScriptEntityProps(-1)
								GoTo IL_1E9
							End If
							Me.RefreshScriptEntityProps(num2)
							If num2 = Me.SelectedWorldIndex Then
								GoTo IL_1E9
							End If
							Me.BehaviorList.Enabled = False
							Me.BraveryList.Enabled = False
							Me.FallbackList.Enabled = False
							Me.HelpTypeList.Enabled = False
							Me.MaxHelpNumeric.Enabled = False
							Me.RangeEdit.Enabled = False
							Me.HelpRangeEdit.Enabled = False
							Me.VehiclesCheck.Enabled = False
							Me.BuildingsCheck.Enabled = False
							GoTo IL_1E9
						End If
					End If
					Me.RefreshScriptEntityProps(Me.SelectedWorldIndex)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<int>.{dtor}), CType((AddressOf gArray<int>), __Pointer(Of Void)))
					Throw
				End Try
				IL_1E9:
				If gArray<int> IsNot Nothing Then
					<Module>.free(gArray<int>)
				End If
			End If
		End Sub

		Public Sub SetEntityName(idx As Integer, newname As String)
			If Me.propWorld IsNot Nothing Then
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>, newname)
				Try
					Select Case Me.SCEType
						Case 0
							Dim gBaseString<char>2 As GBaseString<char>
							Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr2 As __Pointer(Of GBaseString<char>)
							Dim ptr3 As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>3 As GBaseString<char>
								ptr2 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, gBaseString<char>)
								Try
									ptr3 = Me.propWorld
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>4 As GBaseString<char>
							Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr3, AddressOf gBaseString<char>4, 0, ptr2, idx, ptr)
							Try
								Dim num As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
								Dim ptr5 As __Pointer(Of SByte)
								If num <> 0UI Then
									ptr5 = num
								Else
									ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								<Module>.GEditorWorld.SetPathName(Me.propWorld, idx, ptr5)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>4 IsNot Nothing Then
								<Module>.free(gBaseString<char>4)
							End If
						Case 1
							Dim gBaseString<char>5 As GBaseString<char>
							Dim ptr6 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>5, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr7 As __Pointer(Of GBaseString<char>)
							Dim ptr8 As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>6 As GBaseString<char>
								ptr7 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>6, gBaseString<char>)
								Try
									ptr8 = Me.propWorld
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>7 As GBaseString<char>
							Dim ptr9 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr8, AddressOf gBaseString<char>7, 1, ptr7, idx, ptr6)
							Try
								<Module>.GEditorWorld.SetLocationName(Me.propWorld, idx, <Module>.GBaseString<char>..PBD(ptr9))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>7), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>7 IsNot Nothing Then
								<Module>.free(gBaseString<char>7)
							End If
						Case 2
							Dim gBaseString<char>8 As GBaseString<char>
							Dim ptr10 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>8, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr11 As __Pointer(Of GBaseString<char>)
							Dim ptr12 As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>9 As GBaseString<char>
								ptr11 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>9, gBaseString<char>)
								Try
									ptr12 = Me.propWorld
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>9), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>8), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>10 As GBaseString<char>
							Dim ptr13 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr12, AddressOf gBaseString<char>10, 2, ptr11, idx, ptr10)
							Try
								<Module>.GEditorWorld.SetCameraCurveName(Me.propWorld, idx, <Module>.GBaseString<char>..PBD(ptr13))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>10), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>10 IsNot Nothing Then
								<Module>.free(gBaseString<char>10)
							End If
						Case 3
							Dim gBaseString<char>11 As GBaseString<char>
							Dim ptr14 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>11, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr15 As __Pointer(Of GBaseString<char>)
							Dim ptr16 As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>12 As GBaseString<char>
								ptr15 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>12, gBaseString<char>)
								Try
									ptr16 = Me.propWorld
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>12), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>11), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>13 As GBaseString<char>
							Dim ptr17 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr16, AddressOf gBaseString<char>13, 3, ptr15, idx, ptr14)
							Dim ptr18 As __Pointer(Of GEditorWorld)
							Try
								ptr18 = Me.propWorld
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>13), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GEditorWorld.SetAIGroupName(ptr18, idx, CType(ptr17, __Pointer(Of GBaseString<char>)))
						Case 4
							Dim gBaseString<char>14 As GBaseString<char>
							Dim ptr19 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>14, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr20 As __Pointer(Of GBaseString<char>)
							Dim ptr21 As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>15 As GBaseString<char>
								ptr20 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>15, gBaseString<char>)
								Try
									ptr21 = Me.propWorld
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>15), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>14), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>16 As GBaseString<char>
							Dim ptr22 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr21, AddressOf gBaseString<char>16, 4, ptr20, idx, ptr19)
							Dim ptr23 As __Pointer(Of GEditorWorld)
							Try
								ptr23 = Me.propWorld
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>16), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GEditorWorld.SetSectorName(ptr23, idx, CType(ptr22, __Pointer(Of GBaseString<char>)))
						Case 6
							Dim gBaseString<char>17 As GBaseString<char>
							Dim ptr24 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>17, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr25 As __Pointer(Of GBaseString<char>)
							Dim ptr26 As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>18 As GBaseString<char>
								ptr25 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>18, gBaseString<char>)
								Try
									ptr26 = Me.propWorld
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>18), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>17), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>19 As GBaseString<char>
							Dim ptr27 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(ptr26, AddressOf gBaseString<char>19, 6, ptr25, idx, ptr24)
							Dim ptr28 As __Pointer(Of GEditorWorld)
							Try
								ptr28 = Me.propWorld
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>19), __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GEditorWorld.SetObjectiveName(ptr28, idx, CType(ptr27, __Pointer(Of GBaseString<char>)))
					End Select
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			End If
		End Sub

		Public Sub RefreshCameraCurveIndex()
			If Me.propWorld IsNot Nothing Then
				Me.CameraEyeCurveIndex = -1
				Me.CameraTargetCurveIndex = -1
				Dim num As Integer = -1
				While True
					Dim ptr As __Pointer(Of GHeap<GWCameraCurve>) = Me.propWorld + 3196 / __SizeOf(GEditorWorld)
					Dim num2 As Integer = num + 1
					Dim num3 As Integer = __Dereference((ptr + 4))
					If num2 >= num3 Then
						Exit While
					End If
					Dim num4 As Integer = num2 * 104 + __Dereference(ptr)
					While __Dereference(num4) <> 2147483647
						num2 += 1
						num4 += 104
						If num2 >= num3 Then
							GoTo IL_1C5
						End If
					End While
					num = num2
					If num2 < 0 Then
						Exit While
					End If
					If Me.EyeCurveSelect.SelectedIndex >= 0 Then
						Dim gBaseString<char> As GBaseString<char>
						<Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.EyeCurveSelect.Items(Me.EyeCurveSelect.SelectedIndex).ToString())
						Try
							Dim gBaseString<char>2 As GBaseString<char>
							Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetCameraCurveName(Me.propWorld, AddressOf gBaseString<char>2, num2)
							Dim flag As Boolean
							Try
								flag = ((If((<Module>.GBaseString<char>.Compare(ptr2, gBaseString<char>, False) = 0), 1, 0)) <> 0)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>2 IsNot Nothing Then
								<Module>.free(gBaseString<char>2)
								gBaseString<char>2 = 0
							End If
							If flag Then
								Me.CameraEyeCurveIndex = num2
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
					End If
					If Me.TargetCurveSelect.SelectedIndex >= 0 Then
						Dim gBaseString<char>3 As GBaseString<char>
						<Module>.GBaseString<char>.{ctor}(gBaseString<char>3, Me.TargetCurveSelect.Items(Me.TargetCurveSelect.SelectedIndex).ToString())
						Try
							Dim gBaseString<char>4 As GBaseString<char>
							Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetCameraCurveName(Me.propWorld, AddressOf gBaseString<char>4, num2)
							Dim flag2 As Boolean
							Try
								flag2 = ((If((<Module>.GBaseString<char>.Compare(ptr3, gBaseString<char>3, False) = 0), 1, 0)) <> 0)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>4 IsNot Nothing Then
								<Module>.free(gBaseString<char>4)
								gBaseString<char>4 = 0
							End If
							If flag2 Then
								Me.CameraTargetCurveIndex = num2
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>3 IsNot Nothing Then
							<Module>.free(gBaseString<char>3)
							gBaseString<char>3 = 0
						End If
					End If
				End While
				IL_1C5:
				__Dereference(CType((Me.propWorld + 3228 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = Me.CameraEyeCurveIndex
				Dim num5 As Integer
				If Me.TargetUsed.Checked Then
					num5 = Me.CameraTargetCurveIndex
				Else
					num5 = -1
				End If
				__Dereference(CType((Me.propWorld + 3232 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = num5
				Me.LinkedTarget.Visible = (<Module>.GEditorWorld.IsCameraCurveTargetLinked(Me.propWorld, Me.CameraEyeCurveIndex, Me.CameraTargetCurveIndex) IsNot Nothing)
				Dim cameraEyeCurveIndex As Integer = Me.CameraEyeCurveIndex
				If cameraEyeCurveIndex >= 0 OrElse __Dereference(CType((Me.propWorld + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) <> 0 Then
					Dim num6 As Single = <Module>.GWorld.GetCameraCurveDuration(Me.propWorld, cameraEyeCurveIndex)
					Me.CurveDuration.Text = num6.ToString()
					Dim num7 As Single = <Module>.GWorld.GetCameraCurveDebugStart(Me.propWorld, Me.CameraEyeCurveIndex)
					Me.CurveDebugStart.Text = num7.ToString()
				End If
				If __Dereference(CType((Me.propWorld + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) <> 0 Then
					Me.AddTargetCurve.Enabled = False
					Me.RemoveTargetCurve.Enabled = False
					Me.EyeCurveSelect.Enabled = False
					Me.TargetCurveSelect.Enabled = False
					Me.LinkedTarget.Visible = False
					Me.TimeCurveButton.Enabled = False
					Me.FOVCurveButton.Enabled = False
					Me.RollCurveButton.Enabled = False
					Me.CurveDuration.Enabled = False
					Me.CurveDebugStart.Enabled = True
					Me.CamBeginButton.Enabled = True
					Me.CamRewindButton.Enabled = True
					Me.CamPauseButton.Enabled = True
					Me.CamPlayButton.Enabled = True
					Me.CamForwardButton.Enabled = True
					Me.CurvePositionTrack.Enabled = True
				Else If Me.CameraEyeCurveIndex <> -1 AndAlso Me.CameraTargetCurveIndex <> -1 Then
					Me.EyeCurveSelect.Enabled = True
					Me.TargetCurveSelect.Enabled = True
					Me.AddTargetCurve.Enabled = True
					Me.RemoveTargetCurve.Enabled = True
					Me.TimeCurveButton.Enabled = True
					Me.FOVCurveButton.Enabled = True
					Me.RollCurveButton.Enabled = True
					Me.CamBeginButton.Enabled = True
					Me.CamRewindButton.Enabled = True
					Me.CamPauseButton.Enabled = True
					Me.CamPlayButton.Enabled = True
					Me.CamForwardButton.Enabled = True
					Me.CurvePositionTrack.Enabled = True
					Me.CurveDuration.Enabled = True
					Me.CurveDebugStart.Enabled = True
				Else
					Me.EyeCurveSelect.Enabled = True
					Me.TargetCurveSelect.Enabled = True
					Me.LinkedTarget.Visible = False
					Me.AddTargetCurve.Enabled = False
					Me.RemoveTargetCurve.Enabled = False
					If Me.CameraEyeCurveIndex = -1 Then
						Me.TimeCurveButton.Enabled = False
						Me.FOVCurveButton.Enabled = False
						Me.RollCurveButton.Enabled = False
						Me.CurveDuration.Enabled = False
						Me.CurveDebugStart.Enabled = False
						Me.CamBeginButton.Enabled = False
						Me.CamRewindButton.Enabled = False
						Me.CamPauseButton.Enabled = False
						Me.CamPlayButton.Enabled = False
						Me.CamForwardButton.Enabled = False
						Me.CurvePositionTrack.Enabled = False
					Else
						Me.TimeCurveButton.Enabled = True
						Me.FOVCurveButton.Enabled = True
						Me.RollCurveButton.Enabled = True
						Me.CurveDuration.Enabled = True
						Me.CurveDebugStart.Enabled = True
						Dim enabled As Byte = If((Not Me.TargetUsed.Checked), 1, 0)
						Me.CamBeginButton.Enabled = (enabled <> 0)
						Dim enabled2 As Byte = If((Not Me.TargetUsed.Checked), 1, 0)
						Me.CamRewindButton.Enabled = (enabled2 <> 0)
						Dim enabled3 As Byte = If((Not Me.TargetUsed.Checked), 1, 0)
						Me.CamPauseButton.Enabled = (enabled3 <> 0)
						Dim enabled4 As Byte = If((Not Me.TargetUsed.Checked), 1, 0)
						Me.CamPlayButton.Enabled = (enabled4 <> 0)
						Dim enabled5 As Byte = If((Not Me.TargetUsed.Checked), 1, 0)
						Me.CamForwardButton.Enabled = (enabled5 <> 0)
						Dim enabled6 As Byte = If((Not Me.TargetUsed.Checked), 1, 0)
						Me.CurvePositionTrack.Enabled = (enabled6 <> 0)
					End If
				End If
			End If
		End Sub

		Public Sub InitCameraCurveProps()
			Me.ForceRefresh = False
			Me.RemoveCameraViewPort()
			Me.CameraEyeCurveSelectedIdx = -1
			Me.CameraTargetCurveSelectedIdx = -1
			Me.CameraEyeCurveIndex = -1
			Me.CameraTargetCurveIndex = -1
			Me.CameraStatus = 0
			Me.CameraPlayPosition = 0F
			Me.CamViewport = Nothing
			Me.CurveMakeShots.Checked = False
			Me.CurveDebugShow.Checked = False
			Me.CurveDebugStart.Text = New String(CType((AddressOf <Module>.??_C@_01GBGANLPD@0?$AA@), __Pointer(Of SByte)))
			Me.ShowViewport.Checked = False
			Me.CurveLoop.Checked = True
			Me.TargetUsed.Checked = False
		End Sub

		Public Sub RefreshCameraCurvePos()
			Dim cameraCurvePosPercent As Single = Me.GetCameraCurvePosPercent()
			Me.CurvePositionTrack.Value = CInt((CDec((CSng(Me.CurvePositionTrack.Maximum) * cameraCurvePosPercent))))
			Dim cameraPlayPosition As Single = Me.CameraPlayPosition
			Me.CurveActPos.Text = cameraPlayPosition.ToString()
			Dim num As Single = cameraCurvePosPercent * 100F
			Me.CurveActPercent.Text = num.ToString()
		End Sub

		Public Function RefreshCameraViewport(caption As __Pointer(Of GBaseString<char>), camstat As Integer, <MarshalAs(UnmanagedType.U1)> forcerefresh As Boolean) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr Is Nothing Then
				Return False
			End If
			If __Dereference(CType((ptr + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) = 0 AndAlso (Me.CameraEyeCurveIndex = -1 OrElse (Me.TargetUsed.Checked AndAlso Me.CameraTargetCurveIndex = -1)) Then
				Return False
			End If
			Me.ForceRefresh = forcerefresh
			Dim gPoint As GPoint3
			__Dereference((gPoint + 8)) = 0F
			__Dereference((gPoint + 4)) = 0F
			gPoint = 0F
			Dim gPoint2 As GPoint3
			__Dereference((gPoint2 + 8)) = 0F
			__Dereference((gPoint2 + 4)) = 0F
			gPoint2 = 0F
			Dim dir As Single
			Dim elev As Single
			Dim fov As Single
			Dim roll As Single
			<Module>.GWorld.GetCameraAllParams(Me.propWorld, Me.CameraEyeCurveIndex, Me.CameraTargetCurveIndex, Me.TargetUsed.Checked, Me.GetCameraCurvePosPercent(), gPoint, gPoint2, dir, elev, fov, roll)
			<Module>.GEditorWorld.SetCameraCurveDebugPosition(Me.propWorld, gPoint, gPoint2)
			Dim camViewport As ToolboxCameraViewport = Me.CamViewport
			If camViewport IsNot Nothing Then
				camViewport.SetCamera(gPoint, dir, elev, fov, roll, Me.ForceRefresh)
				Me.CamViewport.SetCaption(caption)
				Me.CamViewport.Paint()
				Return Me.CamViewport.GetFocus()
			End If
			Return False
		End Function

		Public Function GetCameraCurvePos() As Single
			Return Me.CameraPlayPosition
		End Function

		Public Sub SetCameraCurvePos(time As Single)
			Me.CameraPlayPosition = time
		End Sub

		Public Function GetCameraStatus() As Integer
			Return Me.CameraStatus
		End Function

		Public Function GetCameraCurveDuration() As Single
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing Then
				Dim cameraEyeCurveIndex As Integer = Me.CameraEyeCurveIndex
				If cameraEyeCurveIndex >= 0 OrElse __Dereference(CType((ptr + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) <> 0 Then
					Return <Module>.GWorld.GetCameraCurveDuration(ptr, cameraEyeCurveIndex)
				End If
			End If
			Return 0F
		End Function

		Public Function GetCameraCurveDebugStart() As Single
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing Then
				Dim cameraEyeCurveIndex As Integer = Me.CameraEyeCurveIndex
				If cameraEyeCurveIndex >= 0 OrElse __Dereference(CType((ptr + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) <> 0 Then
					Return <Module>.GWorld.GetCameraCurveDebugStart(ptr, cameraEyeCurveIndex)
				End If
			End If
			Return 0F
		End Function

		Public Function GetCameraCurvePosPercent() As Single
			Dim cameraCurveDuration As Single = Me.GetCameraCurveDuration()
			Dim result As Single
			If cameraCurveDuration > 0F Then
				result = Me.CameraPlayPosition / cameraCurveDuration
			Else
				result = 0F
			End If
			Return result
		End Function

		Public Sub SetCameraCurvePosPercent(percent As Single)
			Dim cameraCurveDuration As Single = Me.GetCameraCurveDuration()
			Dim num As Single
			If percent >= 1F Then
				num = 1F
			Else
				Dim num2 As Single
				If percent <= 0F Then
					num2 = 0F
				Else
					num2 = percent
				End If
				num = num2
			End If
			Dim cameraCurvePos As Single
			If cameraCurveDuration > 0F Then
				cameraCurvePos = num * cameraCurveDuration
			Else
				cameraCurvePos = 0F
			End If
			Me.SetCameraCurvePos(cameraCurvePos)
		End Sub

		Public Function GetCameraCurveLoop() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return Me.CurveLoop.Checked
		End Function

		Public Function GetCameraCurveDebugShow() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return Me.CurveDebugShow.Checked
		End Function

		Public Function GetCameraCurveMakeShots() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return Me.CurveMakeShots.Checked
		End Function

		Public Sub GetResolution(resx As __Pointer(Of Integer), resy As __Pointer(Of Integer))
			Select Case Me.ResolutionList.SelectedIndex
				Case 0
					__Dereference(resx) = 848
					__Dereference(resy) = 480
				Case 1
					__Dereference(resx) = 1024
					__Dereference(resy) = 580
				Case 2
					__Dereference(resx) = 1280
					__Dereference(resy) = 725
				Case 3
					__Dereference(resx) = 1600
					__Dereference(resy) = 906
				Case 4
					__Dereference(resx) = 1696
					__Dereference(resy) = 960
				Case 5
					__Dereference(resx) = 2048
					__Dereference(resy) = 1160
				Case 6
					__Dereference(resx) = 2544
					__Dereference(resy) = 1440
				Case 7
					__Dereference(resx) = 3392
					__Dereference(resy) = 1920
				Case Else
					__Dereference(resx) = 848
					__Dereference(resy) = 480
			End Select
		End Sub

		Public Sub CreateCameraViewPort()
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr Is Nothing OrElse __Dereference(CType((ptr + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) <> 0 OrElse (Me.CameraEyeCurveIndex <> -1 AndAlso (Not Me.TargetUsed.Checked OrElse Me.CameraTargetCurveIndex <> -1)) Then
				Dim cameraViewPortExist As __Pointer(Of Boolean) = Me.CameraViewPortExist
				If Not(__Dereference(cameraViewPortExist)) Then
					__Dereference(cameraViewPortExist) = True
					Dim toolboxCameraViewport As ToolboxCameraViewport = New ToolboxCameraViewport(Me.ToolWindows, Me.CameraViewPortExist)
					Me.CamViewport = toolboxCameraViewport
					Me.ToolWindows.Add(toolboxCameraViewport)
					Me.CamViewport.Show()
				End If
			End If
		End Sub

		Public Sub RemoveCameraViewPort()
			If __Dereference(Me.CameraViewPortExist) Then
				Me.ToolWindows.Remove(Me.CamViewport)
				Me.CamViewport.Destroy()
			End If
		End Sub

		Private Sub EntityList_AfterLabelEdit(sender As Object, e As LabelEditEventArgs)
			Me.EditLabel = False
			If e.Label IsNot Nothing Then
				Me.SetEntityName(Me.SelectedWorldIndex, e.Label)
			End If
			Me.EntityList.Items(Me.SelectedItem).Selected = False
			Me.RefreshEntityList()
		End Sub

		Private Sub EntityList_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Me.EntityList.SelectedIndices.Count > 0 Then
				If Me.SelectedItem >= 0 Then
					Dim selectedItem As Integer = Me.SelectedItem
					If selectedItem <> Me.EntityList.SelectedIndices(0) Then
						Me.DeselectItem(Me.EntityList.Items(selectedItem))
					End If
				End If
				If Me.SelectedItem = Me.EntityList.SelectedIndices(0) Then
					Me.EditLabel = True
				End If
				Dim num As Integer = Me.EntityList.SelectedIndices(0)
				Me.SelectedItem = num
				Dim tag As Object = Me.EntityList.Items(num).Tag
				Dim ptr As __Pointer(Of Integer)
				If TypeOf tag Is Integer Then
					ptr = CInt(tag)
				Else
					ptr = 0
				End If
				Me.SelectedWorldIndex = __Dereference(ptr)
				Me.EntityList.Items(Me.SelectedItem).Selected = False
				Me.SelectItem(Me.EntityList.Items(Me.SelectedItem))
				<Module>.GEditorWorld.SelectAIGroup(Me.propWorld, Me.SelectedWorldIndex)
			Else
				Dim selectedItem As Integer = Me.SelectedItem
				If selectedItem >= 0 Then
					Me.DeselectItem(Me.EntityList.Items(selectedItem))
				End If
			End If
			Me.RefreshScriptEntityProps(Me.SelectedWorldIndex)
		End Sub

		Private Sub EntityList_MouseUp(sender As Object, e As MouseEventArgs)
			If Me.SelectedItem >= 0 AndAlso Me.EditLabel AndAlso e.Button = MouseButtons.Left Then
				Dim num As Integer = Me.EntityList.Items(Me.SelectedItem).Bounds.Left
				Dim num2 As Integer = 0
				Dim num3 As Integer = 1
				If 1 < Me.EntityList.Columns.Count Then
					Do
						num = Me.EntityList.Columns(num3).Width + num
						If num > e.X Then
							GoTo IL_9F
						End If
						num3 += 1
					Loop While num3 < Me.EntityList.Columns.Count
					GoTo IL_A2
					IL_9F:
					num2 = num3
				End If
				IL_A2:
				Select Case num2
					Case 1
						Me.EntityList.Items(Me.SelectedItem).Text = Me.EntityList.Items(Me.SelectedItem).SubItems(1).Text
						Me.EntityList.Items(Me.SelectedItem).SubItems(1).Text = ""
						Me.EntityList.Items(Me.SelectedItem).Selected = True
						Me.EntityList.Items(Me.SelectedItem).BeginEdit()
					Case 2
						If Me.SCEType = 6 Then
							<Module>.GEditorWorld.SetObjectiveType(Me.propWorld, Me.SelectedWorldIndex, (<Module>.GEditorWorld.GetObjectiveType(Me.propWorld, Me.SelectedWorldIndex) + 1) Mod 3)
							Me.RefreshEntityList()
							Me.EditLabel = False
						Else
							Dim pos As Point = New Point(e.X, e.Y)
							Me.ColorChooser.Show(Me.EntityList, pos)
							Me.EditLabel = False
						End If
					Case 3
						Dim sCEType As Integer = Me.SCEType
						If sCEType = 0 Then
							<Module>.GEditorWorld.SetPathLooping(Me.propWorld, Me.SelectedWorldIndex, (<Module>.GEditorWorld.GetPathLooping(Me.propWorld, Me.SelectedWorldIndex) + 1) Mod 3)
							Me.RefreshEntityList()
							Me.EditLabel = False
						Else If sCEType = 2 Then
							If <Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(Me.propWorld, Me.SelectedWorldIndex) Is Nothing Then
								<Module>.?SetCameraCurveType@GEditorWorld@@$$FQAEXHW4GCameraCurveType@@@Z(Me.propWorld, Me.SelectedWorldIndex, 1)
							Else If <Module>.?GetCameraCurveType@GEditorWorld@@$$FQAE?AW4GCameraCurveType@@H@Z(Me.propWorld, Me.SelectedWorldIndex) = 1 Then
								<Module>.?SetCameraCurveType@GEditorWorld@@$$FQAEXHW4GCameraCurveType@@@Z(Me.propWorld, Me.SelectedWorldIndex, 0)
							End If
							Me.RefreshEntityList()
							Me.EditLabel = False
						Else If sCEType = 4 Then
							<Module>.GWorld.SetSectorActive(Me.propWorld, Me.SelectedWorldIndex, <Module>.GWorld.IsSectorInactive(Me.propWorld, Me.SelectedWorldIndex) IsNot Nothing)
							Me.RefreshEntityList()
							Me.EditLabel = False
						Else If sCEType = 1 Then
							Dim b As Byte = <Module>.GEditorWorld.GetLocationEffectRange(Me.propWorld, Me.SelectedWorldIndex) + 1
							If b > 4 Then
								b = 1
							End If
							<Module>.GEditorWorld.SetLocationEffectRange(Me.propWorld, Me.SelectedWorldIndex, b)
							Me.RefreshEntityList()
							Me.EditLabel = False
						Else If sCEType = 6 Then
							Dim b2 As Byte = If((<Module>.GEditorWorld.IsObjectiveActive(Me.propWorld, Me.SelectedWorldIndex) = 0), 1, 0)
							<Module>.GEditorWorld.SetObjectiveActive(Me.propWorld, Me.SelectedWorldIndex, b2 <> 0)
							Me.EditLabel = False
							Me.RefreshEntityList()
						Else If sCEType = 3 Then
							Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
							Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld + 3392 / __SizeOf(GEditorWorld)
							If <Module>.GHeap<GWAIGroup>.Present(ptr, selectedWorldIndex) IsNot Nothing Then
								Dim num4 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer))) + selectedWorldIndex * 392 + 63
								Dim num5 As Integer = If((__Dereference(num4) = 0), 1, 0)
								__Dereference(num4) = CByte(num5)
								<Module>.GEditorWorld.PurgeAIGroup(Me.propWorld, Me.SelectedWorldIndex, Nothing)
								Me.RefreshEntityList()
								Me.EditLabel = False
							End If
						End If
					Case 4
						Dim sCEType2 As Integer = Me.SCEType
						If sCEType2 = 4 Then
							Dim b3 As Byte = If((<Module>.GWorld.IsSectorAISleep(Me.propWorld, Me.SelectedWorldIndex) = 0), 1, 0)
							<Module>.GWorld.SetSectorAISleep(Me.propWorld, Me.SelectedWorldIndex, b3 <> 0)
							Me.RefreshEntityList()
							Me.EditLabel = False
						Else If sCEType2 = 1 Then
							Dim b4 As Byte = If((<Module>.GEditorWorld.IsLocationEventSource(Me.propWorld, Me.SelectedWorldIndex) = 0), 1, 0)
							<Module>.GEditorWorld.SetLocationEventSource(Me.propWorld, Me.SelectedWorldIndex, b4 <> 0)
							Me.RefreshEntityList()
							Me.EditLabel = False
						End If
				End Select
			End If
		End Sub

		Private Sub DrawColorSelector(sender As Object, e As DrawItemEventArgs)
			If sender Is Me.Red Then
				Dim bounds As Rectangle = e.Bounds
				Dim color As Color = Color.FromArgb(-57312)
				e.Graphics.FillRectangle(New SolidBrush(color), bounds)
			Else If sender Is Me.Yellow Then
				Dim bounds2 As Rectangle = e.Bounds
				Dim color2 As Color = Color.FromArgb(-224)
				e.Graphics.FillRectangle(New SolidBrush(color2), bounds2)
			Else If sender Is Me.Green Then
				Dim bounds3 As Rectangle = e.Bounds
				Dim color3 As Color = Color.FromArgb(-14614752)
				e.Graphics.FillRectangle(New SolidBrush(color3), bounds3)
			Else If sender Is Me.Cyan Then
				Dim bounds4 As Rectangle = e.Bounds
				Dim color4 As Color = Color.FromArgb(-14614529)
				e.Graphics.FillRectangle(New SolidBrush(color4), bounds4)
			Else If sender Is Me.Blue Then
				Dim bounds5 As Rectangle = e.Bounds
				Dim color5 As Color = Color.FromArgb(-14671617)
				e.Graphics.FillRectangle(New SolidBrush(color5), bounds5)
			Else If sender Is Me.Magenta Then
				Dim bounds6 As Rectangle = e.Bounds
				Dim color6 As Color = Color.FromArgb(-57089)
				e.Graphics.FillRectangle(New SolidBrush(color6), bounds6)
			End If
			If(e.State And DrawItemState.Selected) <> DrawItemState.None Then
				Dim bounds7 As Rectangle = e.Bounds
				Dim color7 As Color = Color.FromKnownColor(KnownColor.Highlight)
				e.Graphics.DrawRectangle(New Pen(color7, 2F), bounds7)
			Else
				Dim bounds8 As Rectangle = e.Bounds
				Dim color8 As Color = Color.FromKnownColor(KnownColor.Window)
				e.Graphics.DrawRectangle(New Pen(color8, 2F), bounds8)
			End If
		End Sub

		Private Sub MeasureColorSelector(sender As Object, e As MeasureItemEventArgs)
			e.ItemWidth = Me.EntityColor.Width - 12
			e.ItemHeight = Me.EntityList.Items(Me.SelectedItem).Bounds.Height + 2
		End Sub

		Private Sub ColorSelected(sender As Object, e As EventArgs)
			Dim num As UInteger = 0UI
			If sender Is Me.Red Then
				num = 16719904UI
			Else If sender Is Me.Yellow Then
				num = 16776992UI
			Else If sender Is Me.Green Then
				num = 2162464UI
			Else If sender Is Me.Cyan Then
				num = 2162687UI
			Else If sender Is Me.Blue Then
				num = 2105599UI
			Else If sender Is Me.Magenta Then
				num = 16720127UI
			End If
			Select Case Me.SCEType
				Case 0
					<Module>.GEditorWorld.SetPathColor(Me.propWorld, Me.SelectedWorldIndex, num)
				Case 1
					<Module>.GEditorWorld.SetLocationColor(Me.propWorld, Me.SelectedWorldIndex, CInt(num))
				Case 2
					<Module>.GEditorWorld.SetCameraCurveColor(Me.propWorld, Me.SelectedWorldIndex, num)
				Case 3
					<Module>.GEditorWorld.SetAIGroupColor(Me.propWorld, Me.SelectedWorldIndex, num)
				Case 4
					<Module>.GEditorWorld.SetSectorColor(Me.propWorld, Me.SelectedWorldIndex, num)
			End Select
			Me.RefreshEntityList()
		End Sub

		Private Sub ShowCheck_CheckedChanged(sender As Object, e As EventArgs)
			Select Case Me.SCEType
				Case 0
					<Module>.GWorld.AlwaysDrawPaths(Me.propWorld, Me.ShowCheck.Checked)
				Case 1
					<Module>.GWorld.AlwaysDrawLocations(Me.propWorld, Me.ShowCheck.Checked)
				Case 2
					<Module>.GEditorWorld.AlwaysDrawCameraCurves(Me.propWorld, Me.ShowCheck.Checked)
				Case 3
					<Module>.GEditorWorld.AlwaysDrawAIGroups(Me.propWorld, Me.ShowCheck.Checked)
				Case 4
					<Module>.GEditorWorld.AlwaysDrawSectors(Me.propWorld, Me.ShowCheck.Checked)
			End Select
		End Sub

		Private Sub RangeEdit_TextChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing AndAlso Me.RangeEdit.Text.Length > 0 Then
				Me.RangeEdit_Validated(Nothing, Nothing)
			End If
		End Sub

		Private Sub BehaviorList_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing Then
				Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
				If ptr IsNot Nothing Then
					Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
					If selectedWorldIndex >= 0 Then
						Dim selectedIndex As GAIGroupProps
						<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf selectedIndex, selectedWorldIndex)
						selectedIndex = Me.BehaviorList.SelectedIndex
						<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, selectedIndex)
					End If
				End If
			End If
		End Sub

		Private Sub BraveryList_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing Then
				Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
				If ptr IsNot Nothing Then
					Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
					If selectedWorldIndex >= 0 Then
						Dim gAIGroupProps As GAIGroupProps
						<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf gAIGroupProps, selectedWorldIndex)
						__Dereference((gAIGroupProps + 16)) = Me.BraveryList.SelectedIndex
						<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, gAIGroupProps)
					End If
				End If
			End If
		End Sub

		Private Sub HelpTypeList_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing Then
				Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
				If ptr IsNot Nothing Then
					Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
					If selectedWorldIndex >= 0 Then
						Dim gAIGroupProps As GAIGroupProps
						<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf gAIGroupProps, selectedWorldIndex)
						__Dereference((gAIGroupProps + 12)) = 0
						If Me.HelpTypeList.GetSelected(0) Then
							__Dereference((gAIGroupProps + 12)) = (__Dereference((gAIGroupProps + 12)) Or 1)
						End If
						If Me.HelpTypeList.GetSelected(1) Then
							__Dereference((gAIGroupProps + 12)) = (__Dereference((gAIGroupProps + 12)) Or 2)
						End If
						If Me.HelpTypeList.GetSelected(2) Then
							__Dereference((gAIGroupProps + 12)) = (__Dereference((gAIGroupProps + 12)) Or 4)
						End If
						If Me.HelpTypeList.GetSelected(3) Then
							__Dereference((gAIGroupProps + 12)) = (__Dereference((gAIGroupProps + 12)) Or 8)
						End If
						If Me.HelpTypeList.GetSelected(4) Then
							__Dereference((gAIGroupProps + 12)) = (__Dereference((gAIGroupProps + 12)) Or 16)
						End If
						If Me.HelpTypeList.GetSelected(5) Then
							__Dereference((gAIGroupProps + 12)) = (__Dereference((gAIGroupProps + 12)) Or 32)
						End If
						If Me.HelpTypeList.GetSelected(6) Then
							__Dereference((gAIGroupProps + 12)) = (__Dereference((gAIGroupProps + 12)) Or 64)
						End If
						<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, gAIGroupProps)
					End If
				End If
			End If
		End Sub

		Private Sub FallbackList_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing Then
				Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
				If ptr IsNot Nothing Then
					Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
					If selectedWorldIndex >= 0 Then
						Dim gAIGroupProps As GAIGroupProps
						<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf gAIGroupProps, selectedWorldIndex)
						If Me.FallbackList.SelectedIndex = 0 Then
							__Dereference((gAIGroupProps + 24)) = -1
						Else If Me.FallbackList.SelectedIndex = 1 Then
							__Dereference((gAIGroupProps + 24)) = -2
						Else
							__Dereference((gAIGroupProps + 24)) = Me.Locations(Me.FallbackList.SelectedIndex - 2)
						End If
						<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, gAIGroupProps)
					End If
				End If
			End If
		End Sub

		Private Sub RangeEdit_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing Then
				Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
				If selectedWorldIndex >= 0 Then
					Dim gAIGroupProps As GAIGroupProps
					<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf gAIGroupProps, selectedWorldIndex)
					Dim num2 As Single = 0F
					Try
						num2 = CSng((Double.Parse(Me.RangeEdit.Text) * <Module>.Measures))
						GoTo IL_BD
					End Try
					Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
					IL_BD:
					__Dereference((gAIGroupProps + 4)) = num2
					<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, gAIGroupProps)
				End If
			End If
		End Sub

		Private Sub MaxHelpNumeric_ValueChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing Then
				Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
				If ptr IsNot Nothing Then
					Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
					If selectedWorldIndex >= 0 Then
						Dim gAIGroupProps As GAIGroupProps
						<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf gAIGroupProps, selectedWorldIndex)
						Dim value As Decimal = Me.MaxHelpNumeric.Value
						__Dereference((gAIGroupProps + 20)) = Decimal.ToInt32(value)
						<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, gAIGroupProps)
					End If
				End If
			End If
		End Sub

		Private Sub DescriptionEdit_Validated(sender As Object, e As EventArgs)
			If Me.propWorld IsNot Nothing AndAlso Me.SelectedWorldIndex >= 0 Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.DescriptionEdit.Text)
				Dim ptr2 As __Pointer(Of GEditorWorld)
				Dim selectedWorldIndex As Integer
				Try
					ptr2 = Me.propWorld
					selectedWorldIndex = Me.SelectedWorldIndex
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GEditorWorld.SetObjectiveDescription(ptr2, selectedWorldIndex, ptr)
			End If
		End Sub

		Private Sub DescriptionEdit_TextChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing Then
				Me.DescriptionEdit_Validated(Nothing, Nothing)
			End If
		End Sub

		Private Sub ObjLocList_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Me.ObjLocList.SelectedIndex >= 0 Then
				Me.ObjPathList.SelectedIndex = -1
			End If
		End Sub

		Private Sub ObjPathList_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Me.ObjPathList.SelectedIndex >= 0 Then
				Me.ObjLocList.SelectedIndex = -1
			End If
		End Sub

		Private Sub AddBtn_Click(sender As Object, e As EventArgs)
			If Me.propWorld IsNot Nothing AndAlso Me.SelectedWorldIndex >= 0 Then
				Dim gObjectiveTarget As GObjectiveTarget
				If Me.ObjLocList.SelectedIndex >= 0 Then
					__Dereference((gObjectiveTarget + 4)) = 0
					gObjectiveTarget = Me.Locations(Me.ObjLocList.SelectedIndex)
				Else
					If Me.ObjPathList.SelectedIndex < 0 Then
						Return
					End If
					__Dereference((gObjectiveTarget + 4)) = 1
					gObjectiveTarget = Me.Paths(Me.ObjPathList.SelectedIndex)
				End If
				<Module>.GEditorWorld.AddTargetToObjective(Me.propWorld, Me.SelectedWorldIndex, gObjectiveTarget)
				Me.RefreshEntityList()
			End If
		End Sub

		Private Sub RemoveBtn_Click(sender As Object, e As EventArgs)
			If Me.propWorld IsNot Nothing AndAlso Me.SelectedWorldIndex >= 0 AndAlso Me.TargetList.SelectedIndex >= 0 Then
				<Module>.GEditorWorld.RemoveTargetFromObjective(Me.propWorld, Me.SelectedWorldIndex, Me.Targets(Me.TargetList.SelectedIndex))
				Me.RefreshEntityList()
			End If
		End Sub

		Private Sub RewardNumeric_ValueChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing AndAlso Me.propWorld IsNot Nothing AndAlso Me.SelectedWorldIndex >= 0 Then
				Dim value As Decimal = Me.RewardNumeric.Value
				<Module>.GEditorWorld.SetObjectiveReward(Me.propWorld, Me.SelectedWorldIndex, Decimal.ToInt32(value))
			End If
		End Sub

		Private Sub TimeCurveButton_Click(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing AndAlso Me.CameraEyeCurveIndex >= 0 AndAlso __Dereference(CType((ptr + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) = 0 Then
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>, CType((AddressOf <Module>.??_C@_0M@ONDGBKLB@Time?$CF?5Curve?$AA@), __Pointer(Of SByte)))
				Try
					New ToolboxCurveEditor(0, Me.CameraEyeCurveIndex, Me.propWorld, AddressOf gBaseString<char>, 0F, 1F).ShowDialog()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			End If
		End Sub

		Private Sub FOVCurveButton_Click(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing AndAlso Me.CameraEyeCurveIndex >= 0 AndAlso __Dereference(CType((ptr + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) = 0 Then
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>, CType((AddressOf <Module>.??_C@_09ODDABLAP@FOV?5Curve?$AA@), __Pointer(Of SByte)))
				Try
					New ToolboxCurveEditor(1, Me.CameraEyeCurveIndex, Me.propWorld, AddressOf gBaseString<char>, 0F, 180F).ShowDialog()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			End If
		End Sub

		Private Sub RollCurveButton_Click(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing AndAlso Me.CameraEyeCurveIndex >= 0 AndAlso __Dereference(CType((ptr + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) = 0 Then
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>, CType((AddressOf <Module>.??_C@_0L@FHNGHPLJ@Roll?5Curve?$AA@), __Pointer(Of SByte)))
				Try
					New ToolboxCurveEditor(2, Me.CameraEyeCurveIndex, Me.propWorld, AddressOf gBaseString<char>, -180F, 180F).ShowDialog()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			End If
		End Sub

		Private Sub CamBeginButton_Click(sender As Object, e As EventArgs)
			Me.CameraStatus = 0
			Me.CameraPlayPosition = 0F
		End Sub

		Private Sub CamRewindButton_Click(sender As Object, e As EventArgs)
			Me.CameraStatus = 2
		End Sub

		Private Sub CamPauseButton_Click(sender As Object, e As EventArgs)
			Me.CameraStatus = 0
		End Sub

		Private Sub CamPlayButton_Click(sender As Object, e As EventArgs)
			Me.CameraStatus = 1
		End Sub

		Private Sub CamForwardButton_Click(sender As Object, e As EventArgs)
			Me.CameraStatus = 3
		End Sub

		Private Sub EyeCurveSelect_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Me.propWorld IsNot Nothing AndAlso Me.CameraEyeCurveSelectedIdx <> Me.EyeCurveSelect.SelectedIndex Then
				Me.CameraEyeCurveSelectedIdx = Me.EyeCurveSelect.SelectedIndex
				Me.RefreshCameraCurveIndex()
				Me.CameraStatus = 0
				Me.CameraPlayPosition = 0F
			End If
		End Sub

		Private Sub TargetCurveSelect_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Me.propWorld IsNot Nothing AndAlso Me.CameraTargetCurveSelectedIdx <> Me.TargetCurveSelect.SelectedIndex Then
				Me.CameraTargetCurveSelectedIdx = Me.TargetCurveSelect.SelectedIndex
				Me.RefreshCameraCurveIndex()
			End If
		End Sub

		Private Sub CurveDuration_TextChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing AndAlso Me.CurveDuration.Text.Length > 0 Then
				Me.CurveDuration_Validated(Nothing, Nothing)
			End If
		End Sub

		Private Sub CurveDuration_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			If Me.propWorld IsNot Nothing AndAlso Me.CameraEyeCurveIndex >= 0 Then
				Dim num2 As Single = 0F
				Try
					num2 = CSng(Double.Parse(Me.CurveDuration.Text))
					GoTo IL_A8
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
				IL_A8:
				<Module>.GWorld.SetCameraCurveDuration(Me.propWorld, Me.CameraEyeCurveIndex, num2)
			End If
		End Sub

		Private Sub CurveDebugStart_TextChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing AndAlso Me.CurveDebugStart.Text.Length > 0 Then
				Me.CurveDebugStart_Validated(Nothing, Nothing)
			End If
		End Sub

		Private Sub CurveDebugStart_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			If Me.propWorld IsNot Nothing AndAlso Me.CameraEyeCurveIndex >= 0 Then
				Dim num2 As Single = 0F
				Try
					num2 = CSng(Double.Parse(Me.CurveDebugStart.Text))
					GoTo IL_A8
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
				IL_A8:
				<Module>.GWorld.SetCameraCurveDebugStart(Me.propWorld, Me.CameraEyeCurveIndex, num2)
			End If
		End Sub

		Private Sub CurvePositionTrack_Scroll(sender As Object, e As EventArgs)
			Me.CameraStatus = 0
			Dim num As Single = CSng(Me.CurvePositionTrack.Value)
			Me.SetCameraCurvePosPercent(num / CSng(Me.CurvePositionTrack.Maximum))
		End Sub

		Private Sub TargetUsed_CheckedChanged(sender As Object, e As EventArgs)
			Me.RefreshCameraCurveIndex()
		End Sub

		Private Sub ShowViewport_CheckedChanged(sender As Object, e As EventArgs)
			If Me.ShowViewport.Checked Then
				Me.CreateCameraViewPort()
			Else
				Me.RemoveCameraViewPort()
			End If
		End Sub

		Private Sub ToolboxScriptEntities_Paint(sender As Object, e As PaintEventArgs)
		End Sub

		Private Sub AddTargetCurve_Click(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing Then
				Dim cameraEyeCurveIndex As Integer = Me.CameraEyeCurveIndex
				If cameraEyeCurveIndex >= 0 Then
					Dim cameraTargetCurveIndex As Integer = Me.CameraTargetCurveIndex
					If cameraTargetCurveIndex >= 0 Then
						<Module>.GEditorWorld.AddToCameraCurveTargetList(ptr, cameraEyeCurveIndex, cameraTargetCurveIndex)
						Me.LinkedTarget.Visible = True
					End If
				End If
			End If
		End Sub

		Private Sub RemoveTargetCurve_Click(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing Then
				Dim cameraEyeCurveIndex As Integer = Me.CameraEyeCurveIndex
				If cameraEyeCurveIndex >= 0 Then
					Dim cameraTargetCurveIndex As Integer = Me.CameraTargetCurveIndex
					If cameraTargetCurveIndex >= 0 Then
						<Module>.GEditorWorld.RemoveFromCameraCurveTargetList(ptr, cameraEyeCurveIndex, cameraTargetCurveIndex)
						Me.LinkedTarget.Visible = False
					End If
				End If
			End If
		End Sub

		Private Sub HelpRangeEdit_TextChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing AndAlso Me.HelpRangeEdit.Text.Length > 0 Then
				Me.HelpRangeEdit_Validated(Nothing, Nothing)
			End If
		End Sub

		Private Sub HelpRangeEdit_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
			If ptr IsNot Nothing Then
				Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
				If selectedWorldIndex >= 0 Then
					Dim gAIGroupProps As GAIGroupProps
					<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf gAIGroupProps, selectedWorldIndex)
					Dim num2 As Single = 0F
					Try
						num2 = CSng((Double.Parse(Me.HelpRangeEdit.Text) * <Module>.Measures))
						GoTo IL_BD
					End Try
					Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
					IL_BD:
					__Dereference((gAIGroupProps + 8)) = num2
					<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, gAIGroupProps)
				End If
			End If
		End Sub

		Private Sub VehiclesCheck_CheckedChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing Then
				Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
				If ptr IsNot Nothing Then
					Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
					If selectedWorldIndex >= 0 Then
						Dim gAIGroupProps As GAIGroupProps
						<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf gAIGroupProps, selectedWorldIndex)
						__Dereference((gAIGroupProps + 28)) = (If(Me.VehiclesCheck.Checked, 1, 0))
						<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, gAIGroupProps)
					End If
				End If
			End If
		End Sub

		Private Sub BuildingsCheck_CheckedChanged(sender As Object, e As EventArgs)
			If Not Me.PropsRefreshing Then
				Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld
				If ptr IsNot Nothing Then
					Dim selectedWorldIndex As Integer = Me.SelectedWorldIndex
					If selectedWorldIndex >= 0 Then
						Dim gAIGroupProps As GAIGroupProps
						<Module>.GEditorWorld.GetAIGroupProps(ptr, AddressOf gAIGroupProps, selectedWorldIndex)
						__Dereference((gAIGroupProps + 29)) = (If(Me.BuildingsCheck.Checked, 1, 0))
						<Module>.GEditorWorld.SetAIGroupProps(Me.propWorld, Me.SelectedWorldIndex, gAIGroupProps)
					End If
				End If
			End If
		End Sub
	End Class
End Namespace
