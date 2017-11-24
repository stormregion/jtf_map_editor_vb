Imports <CppImplementationDetails>
Imports NControls
Imports ScriptEditorWindow
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	<UnsafeValueType()>
	Public Class NMainForm
		Inherits Form

		Public Shared MainWorkshopForm As NMainForm = Nothing

		Private ScriptEditorFormInstance As ScriptEditorForm

		Private menuFile As MenuItem

		Private menuFileExit As MenuItem

		Private sbMain As StatusBar

		Private panMainViewport As AllKeyHandlingSolidPanel

		Private menuFileNew As MenuItem

		Private menuFileOpen As MenuItem

		Private menuFileSave As MenuItem

		Private menuFileSaveAs As MenuItem

		Private menuFileSeparator1 As MenuItem

		Private menuFileSeparator2 As MenuItem

		Private menuFileOpenRecent As MenuItem

		Private menuEdit As MenuItem

		Private menuEditUndo As MenuItem

		Private menuEditRedo As MenuItem

		Private menuEditSeparator1 As MenuItem

		Private menuEditCut As MenuItem

		Private menuEditCopy As MenuItem

		Private menuEditPaste As MenuItem

		Private menuEditDelete As MenuItem

		Private menuEditSeparator2 As MenuItem

		Private menuEditSelectAll As MenuItem

		Private menuEditSelectNone As MenuItem

		Private menuView As MenuItem

		Private menuSound As MenuItem

		Private menuSoundDisable As MenuItem

		Private menuSoundStereo As MenuItem

		Private menuSoundQuad As MenuItem

		Private menuSoundSurround As MenuItem

		Private menuSoundReverseStereo As MenuItem

		Private menuTools As MenuItem

		Private menuToolsOptions As MenuItem

		Private menuToolsSeparator1 As MenuItem

		Private menuToolsScriptEditor As MenuItem

		Private menuViewSidebar As MenuItem

		Private menuViewSidebarLeft As MenuItem

		Private menuViewSidebarRight As MenuItem

		Private menuViewStatusBar As MenuItem

		Private menuViewToolbar As MenuItem

		Private menuViewSidebarOff As MenuItem

		Private splitMain As Splitter

		Private menuMode As MenuItem

		Private menuModeVertex As MenuItem

		Private menuModeRoad As MenuItem

		Private menuModeDecal As MenuItem

		Private menuItem5 As MenuItem

		Private menuModeLake As MenuItem

		Private menuModeRiver As MenuItem

		Private menuModeCameraCurve As MenuItem

		Private menuItem8 As MenuItem

		Private menuModeDoodad As MenuItem

		Private menuModeWire As MenuItem

		Private menuModeUnit As MenuItem

		Private menuModeAmbient As MenuItem

		Private menuModeEffect As MenuItem

		Private menuMain As MainMenu

		Private menuModePaint As MenuItem

		Private MainViewPopupMenu As ContextMenu

		Private menuEditControlPaste As MenuItem

		Private menuItem3 As MenuItem

		Private menuModePaths As MenuItem

		Private menuModeLocations As MenuItem

		Private menuModeUnitGroup As MenuItem

		Private menuModeBuilding As MenuItem

		Private menuModeSectors As MenuItem

		Private menuFileImportCam As MenuItem

		Private menuFileExport As MenuItem

		Private menuItem1 As MenuItem

		Private menuFileRemoveImportCam As MenuItem

		Private menuToolsMissionVariables As MenuItem

		Private components As IContainer

		Private tbMain As Toolbar

		Private tbDebug As Toolbar

		Private panSideBar As NControls.ScrollableControl

		Private IRenderTarget As __Pointer(Of GIRenderTarget)

		Private IViewport As __Pointer(Of GIViewport)

		Private KeyTimes As $ArrayType$$$BY0BAA@_J

		Private LastUpdate As Long

		Private LastCamViewPortUpdate As Long

		Private DragMode As Integer

		Private KeyDragMode As Integer

		Private DragStarted As Boolean

		Private DragPreventMenu As Boolean

		Private DragMX As Integer

		Private DragMY As Integer

		Private DragLastX As Integer

		Private DragLastY As Integer

		Private DragX As Single

		Private DragY As Single

		Private DragZ As Single

		Private DragTX As Single

		Private DragTZ As Single

		Private DragTarget As Integer

		Private ND As __Pointer(Of GNativeData)

		Private World As __Pointer(Of GEditorWorld)

		Private Clipboard As __Pointer(Of GWorldClipboard)

		Private EntityClipboard As __Pointer(Of GEntityClipboard)

		Private EffectEditorClipboard As __Pointer(Of NPropertyClipboard)

		Private UnitEditorClipboard As __Pointer(Of NPropertyClipboard)

		Private GameDebugMode As Boolean

		Private GameDebugWithShotsMode As Boolean

		Private GameDebugBackupWorld As __Pointer(Of GEditorWorld)

		Private GameDebugBackupScene As __Pointer(Of GIScene)

		Private GameDebugWorld As __Pointer(Of GWorld)

		Private EditorMode As Integer

		Private DebugMode As Integer

		Private propBrushType As Integer

		Private propPaintType As Integer

		Private VertexFalloffType As Integer

		Private SelectionFalloffType As Integer

		Private SelectionAdditiveMode As Boolean

		Private SelectionActive As Boolean

		Private SelectionPossible As Boolean

		Private EntityType As Integer

		Private EntityOperation As $ArrayType$$$BY0BE@W4GEntityOperation@@

		Private EntityAlignRotate As $ArrayType$$$BY0BE@_N

		Private EntityAlignMove As $ArrayType$$$BY0BE@_N

		Private EntityLockSelection As $ArrayType$$$BY0BE@_N

		Private EntityLockHeights As $ArrayType$$$BY0BE@_N

		Private EntityRandomAngle As $ArrayType$$$BY0BE@_N

		Private EntityName As $ArrayType$$$BY0BE@PAV?$GBaseString@D@@

		Private PreCreatedEntity As Integer

		Private UpDownBrushDiam As Single

		Private UpDownBrushDiam2 As Single

		Private UpDownBrushPressure As Single

		Private HeightSetValue As Single

		Private HeightSetBrushDiam As Single

		Private HeightSetBrushDiam2 As Single

		Private HeightSetBrushPressure As Single

		Private SmoothBrushDiam As Single

		Private SmoothBrushDiam2 As Single

		Private SmoothBrushPressure As Single

		Private PaintBrushDiam As Single

		Private PaintBrushPressure As Single

		Private SelectionDiam As Single

		Private SelectionDiam2 As Single

		Private SelectionPressure As Single

		Private ForestStrokeSize As Single

		Private ForestStrokePressure As Single

		Private Terraformer As __Pointer(Of GTerraformer)

		Private MapFileName As __Pointer(Of GBaseString<char>)

		Private ExportMapFileName As __Pointer(Of GBaseString<char>)

		Private ImportCamFileName As __Pointer(Of GBaseString<char>)

		Private ToolWindows As ArrayList

		Private TileParcelX As Integer

		Private TileParcelZ As Integer

		Private TileDataValid As Boolean

		Private VertexTools As ToolboxVertex

		Private VertexToolContainer As ToolboxContainer

		Private ObjectFilePicker As FilePickerControl

		Private ObjectTools As ToolboxEntities

		Private ObjectFileContainer As ToolboxContainer

		Private ObjectToolContainer As ToolboxContainer

		Private RoadFilePicker As FilePickerControl

		Private RoadTools As ToolboxEntities

		Private RoadFileContainer As ToolboxContainer

		Private RoadToolContainer As ToolboxContainer

		Private NavPointTools As ToolboxEntities

		Private NavPointToolContainer As ToolboxContainer

		Private DecalFilePicker As FilePickerControl

		Private DecalTools As ToolboxEntities

		Private DecalFileContainer As ToolboxContainer

		Private DecalToolContainer As ToolboxContainer

		Private LakeFilePicker As FilePickerControl

		Private LakeTools As ToolboxEntities

		Private LakeToolContainer As ToolboxContainer

		Private LakeFileContainer As ToolboxContainer

		Private RiverFilePicker As FilePickerControl

		Private RiverTools As ToolboxEntities

		Private RiverToolContainer As ToolboxContainer

		Private RiverFileContainer As ToolboxContainer

		Private CameraCurveTools As ToolboxEntities

		Private CameraCurveToolContainer As ToolboxContainer

		Private CameraCurvePropsContainer As ToolboxContainer

		Private CameraCurveProps As ToolboxScriptEntities

		Private BuildingFilePicker As FilePickerControl

		Private BuildingTools As ToolboxEntities

		Private BuildingPropertiesTools As ToolboxBuildingProperties

		Private BuildingFileContainer As ToolboxContainer

		Private BuildingToolContainer As ToolboxContainer

		Private BuildingPropertiesContainer As ToolboxContainer

		Private UnitFilePicker As FilePickerControl

		Private UnitTools As ToolboxEntities

		Private PlayerTools As ToolboxPlayer

		Private UnitPropertiesTools As ToolboxUnitProperties

		Private UnitFileContainer As ToolboxContainer

		Private UnitToolContainer As ToolboxContainer

		Private PlayerContainer As ToolboxContainer

		Private UnitPropertiesContainer As ToolboxContainer

		Private SoundFilePicker As FilePickerControl

		Private SoundTools As ToolboxEntities

		Private SoundFileContainer As ToolboxContainer

		Private SoundToolContainer As ToolboxContainer

		Private EffectFilePicker As FilePickerControl

		Private EffectTools As ToolboxEntities

		Private EffectFileContainer As ToolboxContainer

		Private EffectToolContainer As ToolboxContainer

		Private LocaleFilePicker As FilePickerControl

		Private TerrainFilePicker As ToolboxTerrain

		Private TerrainTools As ToolboxTerrainTools

		Private TerrainFileContainer As ToolboxContainer

		Private TerrainToolContainer As ToolboxContainer

		Private SectorTools As ToolboxSectors

		Private SectorToolContainer As ToolboxContainer

		Private CurrentScriptEnittyToolbar As ToolboxScriptEntities

		Private PathTools As ToolboxEntities

		Private PathProps As ToolboxScriptEntities

		Private PathToolContainer As ToolboxContainer

		Private PathPropsContainer As ToolboxContainer

		Private LocationTools As ToolboxEntities

		Private LocationProps As ToolboxScriptEntities

		Private LocationToolContainer As ToolboxContainer

		Private LocationPropsContainer As ToolboxContainer

		Private UnitGroupTools As ToolboxEntities

		Private UnitGroupProps As ToolboxScriptEntities

		Private UnitGroupToolContainer As ToolboxContainer

		Private UnitGroupPropsContainer As ToolboxContainer

		Private ObjectiveTools As ToolboxEntities

		Private ObjectiveProps As ToolboxScriptEntities

		Private ObjectiveToolContainer As ToolboxContainer

		Private ObjectivePropsContainer As ToolboxContainer

		Private WeatherTools As ToolboxWeather

		Private WeatherToolContainer As ToolboxContainer

		Private OptionsTools As ToolboxOptions

		Private OptionToolContainer As ToolboxContainer

		Private MinimapPanel As Minimap

		Private VertexMinimap As ToolboxContainer

		Private ObjectsMinimap As ToolboxContainer

		Private RoadsMinimap As ToolboxContainer

		Private NavPointsMinimap As ToolboxContainer

		Private DecalsMinimap As ToolboxContainer

		Private LakeMinimap As ToolboxContainer

		Private RiverMinimap As ToolboxContainer

		Private CameraCurveMinimap As ToolboxContainer

		Private UnitMinimap As ToolboxContainer

		Private SoundMinimap As ToolboxContainer

		Private EffectMinimap As ToolboxContainer

		Private TerrainMinimap As ToolboxContainer

		Private PathMinimap As ToolboxContainer

		Private LocationMinimap As ToolboxContainer

		Private UnitGroupMinimap As ToolboxContainer

		Private BuildingMinimap As ToolboxContainer

		Private LoggerContainer As ToolboxContainer

		Private LoggerTool As NDebuggerLog

		Private DUnitsContainer As ToolboxContainer

		Private DUnitsTool As NDebuggerUnits

		Private DUnitGroupsContainer As ToolboxContainer

		Private DUnitGroupsTool As NDebuggerUnitGroups

		Private DTriggersContainer As ToolboxContainer

		Private DTriggersTool As NDebuggerTriggers

		Private DGVarsContainer As ToolboxContainer

		Private DGVarsTool As NDebuggerGVars

		Private DControlPanel As NDebuggerControlPanel

		Private LogControlPanel As ToolboxContainer

		Private UnitsControlPanel As ToolboxContainer

		Private UnitGroupsControlPanel As ToolboxContainer

		Private TriggersControlPanel As ToolboxContainer

		Private CurrentControlPanel As ToolboxContainer

		Private ScrollbarOn As Boolean

		Private Rearranging As Boolean

		Private OldHeight As Integer

		Private LayoutChanged As Boolean

		Private VariableSizeToolChanged As Boolean

		Private OpenFileName As String

		Private TemporaryModeChange As Boolean

		Private LastPasteOptions As UInteger

		Private BrushNeedsUpdate As Boolean

		Private BrushX As Single

		Private BrushZ As Single

		Private MinimapViewportNeedsUpdate As Boolean

		Private MinimapUnitsNeedUpdate As Boolean

		Private CurrentEntityToolbar As ToolboxEntities

		Private CurrentMinimap As ToolboxContainer

		Private LastCameraType As Integer

		Private LastCamera As __Pointer(Of GCamera)

		Private SectorSelectionNeedsUpdate As Boolean

		Private BrushCursor As __Pointer(Of GHandle<11>)

		Private ParcelSelection As __Pointer(Of GHandle<11>)

		Private PhysicsModels As __Pointer(Of GArray<GIModel *>)

		Private MouseTargetX As Single

		Private MouseTargetY As Single

		Private MouseTargetZ As Single

		Private SelectedMapNote As Integer

		Private MapNoteX As Integer

		Private MapNoteY As Integer

		Private GroupListRefreshNeeded As Boolean

		Private LastClickTime As Long

		Private LastClickTimeRightButton As Long

		Private LastClickUnit As Integer

		Private TurnUnitIdx As Integer

		Private CommandMode As Integer

		Private AcceptedCommand As Integer

		Private LastEditorMode As Integer

		Private CurrentOrder As __Pointer(Of GOrder)

		Private AvailableCommands As $ArrayType$$$BY0DA@_N

		Private DebugMapTempFOV As Single

		Private DebugMapTempNearPlane As Single

		Private DebugMapTempFarPlane As Single

		Private DebugMapTemp_RefractBufferWidth As Integer

		Private DebugMapTemp_RefractBufferHeight As Integer

		Private DebugMapTemp_ReflectBufferWidth As Integer

		Private DebugMapTemp_ReflectBufferHeight As Integer

		Private DebugMapTemp_DistanceBufferWidth As Integer

		Private DebugMapTemp_DistanceBufferHeight As Integer

		Private DebugMapTemp_ShadowBufferSize As Integer

		Private DebugMapTemp_SoundDevice As Integer

		Private WindowClosing As Boolean

		Public ProgressDialog As ThumbProgress

		Private WriteOnly Property PaintType() As Integer
			Set(value As Integer)
				Me.propPaintType = value
				Me.TerrainTools.PaintType = value
				If Me.propPaintType <> 14 Then
					Me.TileDataValid = False
					Me.TerrainFilePicker.UpdateLayerUsage(0)
				End If
			End Set
		End Property

		Private WriteOnly Property BrushType() As Integer
			Set(value As Integer)
				Me.propBrushType = value
				Me.VertexTools.BrushType = value
				Me.VertexTools.SelectionType = value
				Me.VertexTools.FalloffType = Me.VertexFalloffType
				Me.VertexTools.AdditiveMode = (__Dereference(CType((Me.Terraformer + 8 / __SizeOf(GTerraformer)), __Pointer(Of Byte))) <> 0)
				Me.VertexTools.LockObjectHeights = (__Dereference(CType((Me.Terraformer + 9 / __SizeOf(GTerraformer)), __Pointer(Of Byte))) <> 0)
			End Set
		End Property

		Private Property BrushColor() As __Pointer(Of GColor)
			Get
				Return CType((Me.Terraformer + 16 / __SizeOf(GTerraformer)), __Pointer(Of GColor))
			End Get
			Set(value As __Pointer(Of GColor))
				cpblk(Me.Terraformer + 16 / __SizeOf(GTerraformer), value, 16)
			End Set
		End Property

		Private Property BrushPressure() As __Pointer(Of Single)
			Get
				Dim editorMode As Integer = Me.EditorMode
				If editorMode = 1 Then
					Dim num As Integer = Me.propBrushType
					If num = 24 Then
						Return Me.SelectionPressure
					End If
					If num < 20 Then
						Select Case num
							Case 2, 3
								Return Me.UpDownBrushPressure
							Case 4, 5, 6
								Return Me.HeightSetBrushPressure
							Case 7, 8
								Return Me.SmoothBrushPressure
						End Select
					End If
				Else If editorMode = 2 Then
					Select Case Me.propPaintType
						Case 9, 10, 11, 15, 16
							Return Me.PaintBrushPressure
					End Select
				End If
				Return 0
			End Get
			Set(value As __Pointer(Of Single))
				Dim brushPressure As __Pointer(Of Single) = Me.BrushPressure
				Dim num As Single = value
				If brushPressure IsNot Nothing Then
					If num < 5F Then
						num = 5F
					Else If num > 100F Then
						num = 100F
					End If
					__Dereference(brushPressure) = num
				End If
			End Set
		End Property

		Private Property BrushSize2() As __Pointer(Of Single)
			Get
				If Me.EditorMode = 1 Then
					Dim num As Integer = Me.propBrushType
					If num = 24 AndAlso Me.SelectionFalloffType = 101 Then
						Return Me.SelectionDiam2
					End If
					If num < 20 AndAlso Me.VertexFalloffType = 101 Then
						Select Case num
							Case 2, 3
								Return Me.UpDownBrushDiam2
							Case 4, 5, 6
								Return Me.HeightSetBrushDiam2
							Case 7, 8
								Return Me.SmoothBrushDiam2
						End Select
					End If
				End If
				Return 0
			End Get
			Set(value As __Pointer(Of Single))
				Dim brushSize As __Pointer(Of Single) = Me.BrushSize2
				Dim num As Single = value
				If brushSize IsNot Nothing Then
					If num < 0F Then
						num = 0F
					Else If num > 100F Then
						num = 100F
					End If
					__Dereference(brushSize) = num
				End If
			End Set
		End Property

		Private Property BrushSize() As __Pointer(Of Single)
			Get
				Dim editorMode As Integer = Me.EditorMode
				If editorMode = 1 Then
					Dim num As Integer = Me.propBrushType
					If num = 24 Then
						Return Me.SelectionDiam
					End If
					If num < 20 Then
						Select Case num
							Case 2, 3
								Return Me.UpDownBrushDiam
							Case 4, 5, 6
								Return Me.HeightSetBrushDiam
							Case 7, 8
								Return Me.SmoothBrushDiam
						End Select
					End If
				Else If editorMode = 2 Then
					Select Case Me.propPaintType
						Case 9, 10, 11, 15, 16
							Return Me.PaintBrushDiam
					End Select
				End If
				Return 0
			End Get
			Set(value As __Pointer(Of Single))
				Dim brushSize As __Pointer(Of Single) = Me.BrushSize
				Dim num As Single = value
				If brushSize IsNot Nothing Then
					If num < 0.5F Then
						num = 0.5F
					Else If num > 30F Then
						num = 30F
					End If
					__Dereference(brushSize) = <Module>.fround(num * 50F) * 0.02F
				End If
			End Set
		End Property

		Private Property BrushHeight() As __Pointer(Of Single)
			Get
				If Me.EditorMode = 1 Then
					Dim num As Integer = Me.propBrushType
					If num < 20 AndAlso num - 4 <= 2 Then
						Return Me.HeightSetValue
					End If
				End If
				Return 0
			End Get
			Set(value As __Pointer(Of Single))
				Dim brushHeight As __Pointer(Of Single) = Me.BrushHeight
				Dim num As Single = value
				If brushHeight IsNot Nothing Then
					If num < -30F Then
						num = -30F
					Else If num > 50F Then
						num = 50F
					End If
					__Dereference(brushHeight) = num
				End If
			End Set
		End Property

		Public Sub New()
			Me.Rearranging = True
			Me.LayoutChanged = True
			Me.VariableSizeToolChanged = False
			Me.WindowClosing = False
			Me.InitializeComponent()
			Dim allKeyHandlingSolidPanel As AllKeyHandlingSolidPanel = New AllKeyHandlingSolidPanel()
			Me.panMainViewport = allKeyHandlingSolidPanel
			allKeyHandlingSolidPanel.BorderStyle = BorderStyle.Fixed3D
			Me.panMainViewport.Dock = DockStyle.Fill
			Dim location As Point = New Point(3, 0)
			Me.panMainViewport.Location = location
			Me.panMainViewport.Name = "panMainViewport"
			Dim size As Size = New Size(789, 551)
			Me.panMainViewport.Size = size
			Me.panMainViewport.TabIndex = 4
			Me.panMainViewport.TabStop = True
			AddHandler Me.panMainViewport.SizeChanged, AddressOf Me.panMainViewport_SizeChanged
			AddHandler Me.panMainViewport.MouseUp, AddressOf Me.panMainViewport_MouseUp
			AddHandler Me.panMainViewport.Paint, AddressOf Me.panMainViewport_Paint
			AddHandler Me.panMainViewport.MouseMove, AddressOf Me.panMainViewport_MouseMove
			AddHandler Me.panMainViewport.MouseDown, AddressOf Me.panMainViewport_MouseDown
			AddHandler Me.panMainViewport.DoubleClick, AddressOf Me.panMainViewport_DoubleClick
			MyBase.Controls.Add(Me.panMainViewport)
			Me.InitializeVariables()
			Dim scrollableControl As NControls.ScrollableControl = New NControls.ScrollableControl(256, 551, 551, 2)
			Me.panSideBar = scrollableControl
			scrollableControl.HideScrollBar()
			Me.panSideBar.Dock = DockStyle.Left
			Dim location2 As Point = New Point(0, 0)
			Me.panSideBar.Location = location2
			Me.panSideBar.Name = "panSideBar"
			Me.panSideBar.TabIndex = 2
			AddHandler Me.panSideBar.Resize, AddressOf Me.panSideBar_Resize
			MyBase.Controls.Remove(Me.sbMain)
			MyBase.Controls.Add(Me.panSideBar)
			MyBase.Controls.Add(Me.sbMain)
			Me.tbMain = New Toolbar(CType((AddressOf <Module>.?items@?1???0NMainForm@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Dim size2 As Size = New Size(300, 300)
			Me.tbMain.Size = size2
			Me.tbMain.Dock = DockStyle.Top
			AddHandler Me.tbMain.ButtonClick, AddressOf Me.tbMain_ButtonClick
			MyBase.Controls.Add(Me.tbMain)
			Me.tbDebug = New Toolbar(CType((AddressOf <Module>.?debugitems@?1???0NMainForm@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Dim size3 As Size = New Size(300, 300)
			Me.tbDebug.Size = size3
			Me.tbDebug.Dock = DockStyle.Top
			AddHandler Me.tbDebug.ButtonClick, AddressOf Me.tbDebug_ButtonClick
			Dim ptr As __Pointer(Of GHandle<11>) = <Module>.new(4UI)
			Dim brushCursor As __Pointer(Of GHandle<11>)
			Try
				If ptr IsNot Nothing Then
					__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
					brushCursor = ptr
				Else
					brushCursor = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.BrushCursor = brushCursor
			Dim ptr2 As __Pointer(Of GHandle<11>) = <Module>.new(4UI)
			Dim parcelSelection As __Pointer(Of GHandle<11>)
			Try
				If ptr2 IsNot Nothing Then
					__Dereference(CType(ptr2, __Pointer(Of Integer))) = 0
					parcelSelection = ptr2
				Else
					parcelSelection = 0
				End If
			Catch 
				<Module>.delete(CType(ptr2, __Pointer(Of Void)))
				Throw
			End Try
			Me.ParcelSelection = parcelSelection
			Me.ScriptEditorFormInstance = Nothing
		End Sub

		Public Sub ShellOpenFile(filename As String)
			Me.OpenFileName = filename
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
			Dim resourceManager As ResourceManager = New ResourceManager(GetType(NMainForm))
			Me.menuMain = New MainMenu()
			Me.menuFile = New MenuItem()
			Me.menuFileNew = New MenuItem()
			Me.menuFileOpen = New MenuItem()
			Me.menuFileOpenRecent = New MenuItem()
			Me.menuFileSeparator1 = New MenuItem()
			Me.menuFileSave = New MenuItem()
			Me.menuFileSaveAs = New MenuItem()
			Me.menuItem1 = New MenuItem()
			Me.menuFileExport = New MenuItem()
			Me.menuFileImportCam = New MenuItem()
			Me.menuFileRemoveImportCam = New MenuItem()
			Me.menuFileSeparator2 = New MenuItem()
			Me.menuFileExit = New MenuItem()
			Me.menuEdit = New MenuItem()
			Me.menuEditUndo = New MenuItem()
			Me.menuEditRedo = New MenuItem()
			Me.menuEditSeparator1 = New MenuItem()
			Me.menuEditCut = New MenuItem()
			Me.menuEditCopy = New MenuItem()
			Me.menuEditPaste = New MenuItem()
			Me.menuEditControlPaste = New MenuItem()
			Me.menuEditDelete = New MenuItem()
			Me.menuEditSeparator2 = New MenuItem()
			Me.menuEditSelectAll = New MenuItem()
			Me.menuEditSelectNone = New MenuItem()
			Me.menuView = New MenuItem()
			Me.menuViewToolbar = New MenuItem()
			Me.menuViewSidebar = New MenuItem()
			Me.menuViewSidebarLeft = New MenuItem()
			Me.menuViewSidebarRight = New MenuItem()
			Me.menuViewSidebarOff = New MenuItem()
			Me.menuViewStatusBar = New MenuItem()
			Me.menuSound = New MenuItem()
			Me.menuSoundDisable = New MenuItem()
			Me.menuSoundStereo = New MenuItem()
			Me.menuSoundQuad = New MenuItem()
			Me.menuSoundSurround = New MenuItem()
			Me.menuSoundReverseStereo = New MenuItem()
			Me.menuMode = New MenuItem()
			Me.menuModeVertex = New MenuItem()
			Me.menuModePaint = New MenuItem()
			Me.menuModeRoad = New MenuItem()
			Me.menuModeDecal = New MenuItem()
			Me.menuModeSectors = New MenuItem()
			Me.menuItem5 = New MenuItem()
			Me.menuModeLake = New MenuItem()
			Me.menuModeRiver = New MenuItem()
			Me.menuItem8 = New MenuItem()
			Me.menuModeDoodad = New MenuItem()
			Me.menuModeWire = New MenuItem()
			Me.menuModeBuilding = New MenuItem()
			Me.menuModeUnit = New MenuItem()
			Me.menuModeAmbient = New MenuItem()
			Me.menuModeEffect = New MenuItem()
			Me.menuItem3 = New MenuItem()
			Me.menuModeCameraCurve = New MenuItem()
			Me.menuModePaths = New MenuItem()
			Me.menuModeLocations = New MenuItem()
			Me.menuModeUnitGroup = New MenuItem()
			Me.menuTools = New MenuItem()
			Me.menuToolsScriptEditor = New MenuItem()
			Me.menuToolsSeparator1 = New MenuItem()
			Me.menuToolsOptions = New MenuItem()
			Me.sbMain = New StatusBar()
			Me.splitMain = New Splitter()
			Me.MainViewPopupMenu = New ContextMenu()
			Me.menuToolsMissionVariables = New MenuItem()
			MyBase.SuspendLayout()
			Dim items As MenuItem() = New MenuItem() { Me.menuFile, Me.menuEdit, Me.menuView, Me.menuMode, Me.menuTools, Me.menuSound }
			Me.menuMain.MenuItems.AddRange(items)
			Me.menuFile.Index = 0
			Dim items2 As MenuItem() = New MenuItem() { Me.menuFileNew, Me.menuFileOpen, Me.menuFileOpenRecent, Me.menuFileSeparator1, Me.menuFileSave, Me.menuFileSaveAs, Me.menuItem1, Me.menuFileExport, Me.menuFileImportCam, Me.menuFileRemoveImportCam, Me.menuFileSeparator2, Me.menuFileExit }
			Me.menuFile.MenuItems.AddRange(items2)
			Me.menuFile.Text = "&File"
			Me.menuFileNew.Index = 0
			Me.menuFileNew.Shortcut = Shortcut.CtrlN
			Me.menuFileNew.Text = "&New..."
			AddHandler Me.menuFileNew.Click, AddressOf Me.menuFileNew_Click
			Me.menuFileOpen.Index = 1
			Me.menuFileOpen.Shortcut = Shortcut.CtrlO
			Me.menuFileOpen.Text = "&Open..."
			AddHandler Me.menuFileOpen.Click, AddressOf Me.menuFileOpen_Click
			Me.menuFileOpenRecent.Index = 2
			Me.menuFileOpenRecent.Text = "Open &Recent..."
			AddHandler Me.menuFileOpenRecent.Click, AddressOf Me.menuFileOpenRecent_Click
			Me.menuFileSeparator1.Index = 3
			Me.menuFileSeparator1.Text = "-"
			Me.menuFileSave.Index = 4
			Me.menuFileSave.Shortcut = Shortcut.CtrlS
			Me.menuFileSave.Text = "&Save"
			AddHandler Me.menuFileSave.Click, AddressOf Me.menuFileSave_Click
			Me.menuFileSaveAs.Index = 5
			Me.menuFileSaveAs.Text = "S&ave As..."
			AddHandler Me.menuFileSaveAs.Click, AddressOf Me.menuFileSaveAs_Click
			Me.menuItem1.Index = 6
			Me.menuItem1.Text = "-"
			Me.menuFileExport.Index = 7
			Me.menuFileExport.Text = "&Export map..."
			AddHandler Me.menuFileExport.Click, AddressOf Me.menuFileExport_Click
			Me.menuFileImportCam.Index = 8
			Me.menuFileImportCam.Text = "&Import camera..."
			AddHandler Me.menuFileImportCam.Click, AddressOf Me.menuFileImportCam_Click
			Me.menuFileRemoveImportCam.Index = 9
			Me.menuFileRemoveImportCam.Text = "&Remove ImportCamera"
			AddHandler Me.menuFileRemoveImportCam.Click, AddressOf Me.menuFileRemoveImportCam_Click
			Me.menuFileSeparator2.Index = 10
			Me.menuFileSeparator2.Text = "-"
			Me.menuFileExit.Index = 11
			Me.menuFileExit.Shortcut = Shortcut.AltF4
			Me.menuFileExit.Text = "E&xit"
			AddHandler Me.menuFileExit.Click, AddressOf Me.menuFileExit_Click
			Me.menuEdit.Index = 1
			Dim items3 As MenuItem() = New MenuItem() { Me.menuEditUndo, Me.menuEditRedo, Me.menuEditSeparator1, Me.menuEditCut, Me.menuEditCopy, Me.menuEditPaste, Me.menuEditControlPaste, Me.menuEditDelete, Me.menuEditSeparator2, Me.menuEditSelectAll, Me.menuEditSelectNone }
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
			Me.menuEditSeparator1.Index = 2
			Me.menuEditSeparator1.Text = "-"
			Me.menuEditCut.Index = 3
			Me.menuEditCut.Shortcut = Shortcut.CtrlX
			Me.menuEditCut.Text = "Cu&t"
			AddHandler Me.menuEditCut.Click, AddressOf Me.menuEditCut_Click
			Me.menuEditCopy.Index = 4
			Me.menuEditCopy.Shortcut = Shortcut.CtrlC
			Me.menuEditCopy.Text = "&Copy"
			AddHandler Me.menuEditCopy.Click, AddressOf Me.menuEditCopy_Click
			Me.menuEditPaste.Index = 5
			Me.menuEditPaste.Shortcut = Shortcut.CtrlV
			Me.menuEditPaste.Text = "&Paste"
			AddHandler Me.menuEditPaste.Click, AddressOf Me.menuEditPaste_Click
			Me.menuEditControlPaste.Index = 6
			Me.menuEditControlPaste.Shortcut = Shortcut.CtrlShiftV
			Me.menuEditControlPaste.Text = "Paste &Special"
			AddHandler Me.menuEditControlPaste.Click, AddressOf Me.menuEditControlPaste_Click
			Me.menuEditDelete.Index = 7
			Me.menuEditDelete.Shortcut = Shortcut.CtrlDel
			Me.menuEditDelete.Text = "&Delete"
			AddHandler Me.menuEditDelete.Click, AddressOf Me.menuEditDelete_Click
			Me.menuEditSeparator2.Index = 8
			Me.menuEditSeparator2.Text = "-"
			Me.menuEditSelectAll.Index = 9
			Me.menuEditSelectAll.Shortcut = Shortcut.CtrlA
			Me.menuEditSelectAll.Text = "Select &All"
			AddHandler Me.menuEditSelectAll.Click, AddressOf Me.menuEditSelectAll_Click
			Me.menuEditSelectNone.Index = 10
			Me.menuEditSelectNone.Shortcut = Shortcut.CtrlShiftA
			Me.menuEditSelectNone.Text = "Select None"
			AddHandler Me.menuEditSelectNone.Click, AddressOf Me.menuEditSelectNone_Click
			Me.menuView.Index = 2
			Dim items4 As MenuItem() = New MenuItem() { Me.menuViewToolbar, Me.menuViewSidebar, Me.menuViewStatusBar }
			Me.menuView.MenuItems.AddRange(items4)
			Me.menuView.Text = "&View"
			Me.menuViewToolbar.Checked = True
			Me.menuViewToolbar.Index = 0
			Me.menuViewToolbar.Text = "&Toolbar"
			AddHandler Me.menuViewToolbar.Click, AddressOf Me.menuViewToolbar_Click
			Me.menuViewSidebar.Index = 1
			Dim items5 As MenuItem() = New MenuItem() { Me.menuViewSidebarLeft, Me.menuViewSidebarRight, Me.menuViewSidebarOff }
			Me.menuViewSidebar.MenuItems.AddRange(items5)
			Me.menuViewSidebar.Text = "&Sidebar"
			Me.menuViewSidebarLeft.Checked = True
			Me.menuViewSidebarLeft.Index = 0
			Me.menuViewSidebarLeft.Text = "Left"
			AddHandler Me.menuViewSidebarLeft.Click, AddressOf Me.menuViewSidebarLeft_Click
			Me.menuViewSidebarRight.Index = 1
			Me.menuViewSidebarRight.Text = "Right"
			AddHandler Me.menuViewSidebarRight.Click, AddressOf Me.menuViewSidebarRight_Click
			Me.menuViewSidebarOff.Index = 2
			Me.menuViewSidebarOff.Text = "Off"
			AddHandler Me.menuViewSidebarOff.Click, AddressOf Me.menuViewSidebarOff_Click
			Me.menuViewStatusBar.Checked = True
			Me.menuViewStatusBar.Index = 2
			Me.menuViewStatusBar.Text = "St&atus Bar"
			AddHandler Me.menuViewStatusBar.Click, AddressOf Me.menuViewStatusBar_Click
			Me.menuSound.Index = 5
			Dim items6 As MenuItem() = New MenuItem() { Me.menuSoundDisable, Me.menuSoundStereo, Me.menuSoundQuad, Me.menuSoundSurround, Me.menuSoundReverseStereo }
			Me.menuSound.MenuItems.AddRange(items6)
			Me.menuSound.Text = "&Sound"
			Me.menuSoundDisable.Checked = False
			Me.menuSoundDisable.Index = 0
			Me.menuSoundDisable.Text = "&Disable"
			AddHandler Me.menuSoundDisable.Click, AddressOf Me.menuSoundDisable_Click
			Me.menuSoundStereo.Checked = True
			Me.menuSoundStereo.Index = 1
			Me.menuSoundStereo.Text = "2.0 &Stereo"
			AddHandler Me.menuSoundStereo.Click, AddressOf Me.menuSoundStereo_Click
			Me.menuSoundQuad.Checked = False
			Me.menuSoundQuad.Index = 2
			Me.menuSoundQuad.Text = "4.0 &Quadro"
			AddHandler Me.menuSoundQuad.Click, AddressOf Me.menuSoundQuad_Click
			Me.menuSoundSurround.Checked = False
			Me.menuSoundSurround.Index = 3
			Me.menuSoundSurround.Text = "5.1 S&urround"
			AddHandler Me.menuSoundSurround.Click, AddressOf Me.menuSoundSurround_Click
			Me.menuSoundReverseStereo.Checked = False
			Me.menuSoundReverseStereo.Index = 4
			Me.menuSoundReverseStereo.Text = "&Reverse Stereo"
			AddHandler Me.menuSoundReverseStereo.Click, AddressOf Me.menuSoundReverseStereo_Click
			Me.menuMode.Index = 3
			Dim items7 As MenuItem() = New MenuItem() { Me.menuModeVertex, Me.menuModePaint, Me.menuModeRoad, Me.menuModeDecal, Me.menuModeSectors, Me.menuItem5, Me.menuModeLake, Me.menuModeRiver, Me.menuItem8, Me.menuModeDoodad, Me.menuModeWire, Me.menuModeBuilding, Me.menuModeUnit, Me.menuModeAmbient, Me.menuModeEffect, Me.menuItem3, Me.menuModeCameraCurve, Me.menuModePaths, Me.menuModeLocations, Me.menuModeUnitGroup }
			Me.menuMode.MenuItems.AddRange(items7)
			Me.menuMode.Text = "&Mode"
			Me.menuModeVertex.Index = 0
			Me.menuModeVertex.Text = "Vertex"
			AddHandler Me.menuModeVertex.Click, AddressOf Me.menuModeVertex_Click
			Me.menuModePaint.Index = 1
			Me.menuModePaint.Text = "Paint"
			AddHandler Me.menuModePaint.Click, AddressOf Me.menuModePaint_Click
			Me.menuModeRoad.Index = 2
			Me.menuModeRoad.Text = "Road"
			AddHandler Me.menuModeRoad.Click, AddressOf Me.menuModeRoad_Click
			Me.menuModeDecal.Index = 3
			Me.menuModeDecal.Text = "Decal"
			AddHandler Me.menuModeDecal.Click, AddressOf Me.menuModeDecal_Click
			Me.menuModeSectors.Index = 4
			Me.menuModeSectors.Text = "Sector"
			AddHandler Me.menuModeSectors.Click, AddressOf Me.menuModeSectors_Click
			Me.menuItem5.Index = 5
			Me.menuItem5.Text = "-"
			Me.menuModeLake.Index = 6
			Me.menuModeLake.Text = "Lake"
			AddHandler Me.menuModeLake.Click, AddressOf Me.menuModeLake_Click
			Me.menuModeRiver.Index = 7
			Me.menuModeRiver.Text = "River"
			AddHandler Me.menuModeRiver.Click, AddressOf Me.menuModeRiver_Click
			Me.menuItem8.Index = 8
			Me.menuItem8.Text = "-"
			Me.menuModeDoodad.Index = 9
			Me.menuModeDoodad.Text = "Doodad"
			AddHandler Me.menuModeDoodad.Click, AddressOf Me.menuModeDoodad_Click
			Me.menuModeWire.Index = 10
			Me.menuModeWire.Text = "Wire"
			AddHandler Me.menuModeWire.Click, AddressOf Me.menuModeWire_Click
			Me.menuModeBuilding.Index = 11
			Me.menuModeBuilding.Text = "Building"
			AddHandler Me.menuModeBuilding.Click, AddressOf Me.menuModeBuilding_Click
			Me.menuModeUnit.Index = 12
			Me.menuModeUnit.Text = "Unit"
			AddHandler Me.menuModeUnit.Click, AddressOf Me.menuModeUnit_Click
			Me.menuModeAmbient.Index = 13
			Me.menuModeAmbient.Text = "Ambient"
			AddHandler Me.menuModeAmbient.Click, AddressOf Me.menuModeAmbient_Click
			Me.menuModeEffect.Index = 14
			Me.menuModeEffect.Text = "Effect"
			AddHandler Me.menuModeEffect.Click, AddressOf Me.menuModeEffect_Click
			Me.menuItem3.Index = 15
			Me.menuItem3.Text = "-"
			Me.menuModeCameraCurve.Index = 16
			Me.menuModeCameraCurve.Text = "CameraCurve"
			AddHandler Me.menuModeCameraCurve.Click, AddressOf Me.menuModeCameraCurve_Click
			Me.menuModePaths.Index = 17
			Me.menuModePaths.Text = "Path"
			AddHandler Me.menuModePaths.Click, AddressOf Me.menuModePaths_Click
			Me.menuModeLocations.Index = 18
			Me.menuModeLocations.Text = "Location"
			AddHandler Me.menuModeLocations.Click, AddressOf Me.menuModeLocations_Click
			Me.menuModeUnitGroup.Index = 19
			Me.menuModeUnitGroup.Text = "Unit AI group"
			AddHandler Me.menuModeUnitGroup.Click, AddressOf Me.menuModeUnitGroup_Click
			Me.menuTools.Index = 4
			Dim items8 As MenuItem() = New MenuItem() { Me.menuToolsScriptEditor, Me.menuToolsMissionVariables, Me.menuToolsSeparator1, Me.menuToolsOptions }
			Me.menuTools.MenuItems.AddRange(items8)
			Me.menuTools.Text = "&Tools"
			Me.menuToolsScriptEditor.Index = 0
			Me.menuToolsScriptEditor.Text = "&Script Editor..."
			AddHandler Me.menuToolsScriptEditor.Click, AddressOf Me.menuToolsScriptEditor_Click
			Me.menuToolsMissionVariables.Index = 1
			Me.menuToolsMissionVariables.Text = "&Mission Variables..."
			AddHandler Me.menuToolsMissionVariables.Click, AddressOf Me.menuToolsMissionVariables_Click
			Me.menuToolsSeparator1.Index = 2
			Me.menuToolsSeparator1.Text = "-"
			Me.menuToolsOptions.Index = 3
			Me.menuToolsOptions.Text = "&Options..."
			Dim location As Point = New Point(0, 551)
			Me.sbMain.Location = location
			Me.sbMain.Name = "sbMain"
			Dim size As Size = New Size(792, 22)
			Me.sbMain.Size = size
			Me.sbMain.TabIndex = 0
			Me.sbMain.Text = "sbMain"
			Dim location2 As Point = New Point(0, 0)
			Me.splitMain.Location = location2
			Me.splitMain.MinExtra = 512
			Me.splitMain.MinSize = 256
			Me.splitMain.Name = "splitMain"
			Dim size2 As Size = New Size(3, 551)
			Me.splitMain.Size = size2
			Me.splitMain.TabIndex = 3
			Me.splitMain.TabStop = False
			AddHandler Me.MainViewPopupMenu.Popup, AddressOf Me.MainViewPopupMenu_Popup
			Dim autoScaleBaseSize As Size = New Size(5, 14)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(792, 573)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.splitMain)
			MyBase.Controls.Add(Me.sbMain)
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			MyBase.Icon = CType(resourceManager.GetObject("$this.Icon"), Icon)
			MyBase.Menu = Me.menuMain
			Dim minimumSize As Size = New Size(800, 600)
			Me.MinimumSize = minimumSize
			MyBase.Name = "NMainForm"
			Me.Text = "Workshop" & ChrW(8482)
			MyBase.WindowState = FormWindowState.Maximized
			AddHandler MyBase.Closing, AddressOf Me.NMainForm_Closing
			AddHandler MyBase.Load, AddressOf Me.NMainForm_Load
			AddHandler MyBase.Closed, AddressOf Me.NMainForm_Closed
			AddHandler MyBase.Activated, AddressOf Me.NMainForm_Activated
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub InitializeVariables()
			Me.IViewport = Nothing
			initblk(Me.KeyTimes, 0, 2048)
			Me.LastUpdate = 0L
			Me.LastCamViewPortUpdate = 0L
			Me.DragMode = 0
			Me.DragStarted = False
			Me.DragPreventMenu = False
			Me.SelectionPossible = False
			Dim ptr As __Pointer(Of GNativeData) = <Module>.new(36UI)
			Dim nD As __Pointer(Of GNativeData)
			Try
				If ptr IsNot Nothing Then
					__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr + 4 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr + 8 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr + 12 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
					Dim ptr2 As __Pointer(Of Void) = CType((ptr + 16 / __SizeOf(GNativeData)), __Pointer(Of Void))
					__Dereference(CType(ptr2, __Pointer(Of Integer))) = 0
					__Dereference(CType((CType(ptr2, __Pointer(Of Byte)) + 4), __Pointer(Of Integer))) = 0
					__Dereference(CType((CType(ptr2, __Pointer(Of Byte)) + 8), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr + 28 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr + 32 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
					nD = ptr
				Else
					nD = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.ND = nD
			Me.World = Nothing
			Me.Clipboard = Nothing
			Dim ptr3 As __Pointer(Of GEntityClipboard) = <Module>.new(300UI)
			Dim entityClipboard As __Pointer(Of GEntityClipboard)
			Try
				If ptr3 IsNot Nothing Then
					entityClipboard = <Module>.GEntityClipboard.{ctor}(ptr3)
				Else
					entityClipboard = 0
				End If
			Catch 
				<Module>.delete(CType(ptr3, __Pointer(Of Void)))
				Throw
			End Try
			Me.EntityClipboard = entityClipboard
			Dim ptr4 As __Pointer(Of NPropertyClipboard) = <Module>.new(8UI)
			Dim effectEditorClipboard As __Pointer(Of NPropertyClipboard)
			Try
				If ptr4 IsNot Nothing Then
					__Dereference(CType((ptr4 + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))) = 0
					effectEditorClipboard = ptr4
				Else
					effectEditorClipboard = 0
				End If
			Catch 
				<Module>.delete(CType(ptr4, __Pointer(Of Void)))
				Throw
			End Try
			Me.EffectEditorClipboard = effectEditorClipboard
			Dim ptr5 As __Pointer(Of NPropertyClipboard) = <Module>.new(8UI)
			Dim unitEditorClipboard As __Pointer(Of NPropertyClipboard)
			Try
				If ptr5 IsNot Nothing Then
					__Dereference(CType((ptr5 + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))) = 0
					unitEditorClipboard = ptr5
				Else
					unitEditorClipboard = 0
				End If
			Catch 
				<Module>.delete(CType(ptr5, __Pointer(Of Void)))
				Throw
			End Try
			Me.UnitEditorClipboard = unitEditorClipboard
			Me.GameDebugMode = False
			Me.GameDebugWithShotsMode = False
			Me.GameDebugBackupWorld = Nothing
			Me.GameDebugBackupScene = Nothing
			Me.CurrentOrder = Nothing
			Me.EditorMode = 0
			Me.DebugMode = 500
			Me.propBrushType = 2
			Me.propPaintType = 9
			Dim ptr6 As __Pointer(Of GTerraformer) = <Module>.new(76UI)
			Dim ptr7 As __Pointer(Of GTerraformer)
			Try
				If ptr6 IsNot Nothing Then
					ptr7 = <Module>.GTerraformer.{ctor}(ptr6)
				Else
					ptr7 = 0
				End If
			Catch 
				<Module>.delete(CType(ptr6, __Pointer(Of Void)))
				Throw
			End Try
			Me.Terraformer = ptr7
			Me.VertexFalloffType = 100
			__Dereference((ptr7 + 8)) = 1
			__Dereference(CType((Me.Terraformer + 9 / __SizeOf(GTerraformer)), __Pointer(Of Byte))) = 0
			Dim gColor As GColor = 0F
			__Dereference((gColor + 4)) = 0F
			__Dereference((gColor + 8)) = 0F
			__Dereference((gColor + 12)) = 0F
			cpblk(Me.Terraformer + 16 / __SizeOf(GTerraformer), gColor, 16)
			Me.SelectionFalloffType = 100
			Me.SelectionAdditiveMode = True
			Me.SelectionActive = False
			Me.UpDownBrushDiam = 1.5F
			Me.UpDownBrushPressure = 20F
			Me.HeightSetValue = 0F
			Me.HeightSetBrushDiam = 2F
			Me.HeightSetBrushPressure = 20F
			Me.SmoothBrushDiam = 1F
			Me.SmoothBrushPressure = 10F
			Me.PaintBrushDiam = 1.5F
			Me.PaintBrushPressure = 25F
			__Dereference(CType((Me.Terraformer + 12 / __SizeOf(GTerraformer)), __Pointer(Of Integer))) = 0
			Me.SelectionDiam = 1.5F
			Me.SelectionPressure = 20F
			Me.UpDownBrushDiam2 = 75F
			Me.HeightSetBrushDiam2 = 75F
			Me.SmoothBrushDiam2 = 75F
			Me.SelectionDiam2 = 75F
			Me.ForestStrokeSize = 1.5F
			Me.ForestStrokePressure = 25F
			Me.EntityType = 0
			Dim ptr8 As __Pointer(Of $ArrayType$$$BY0BE@_N) = Me.EntityAlignMove
			Dim ptr9 As __Pointer(Of $ArrayType$$$BY0BE@PAV?$GBaseString@D@@) = Me.EntityName
			Dim num As Integer = Me.EntityOperation - Me.EntityName
			Dim num2 As Integer = Me.EntityAlignRotate - Me.EntityAlignMove
			Dim num3 As Integer = Me.EntityLockSelection - Me.EntityAlignMove
			Dim num4 As Integer = Me.EntityLockHeights - Me.EntityAlignMove
			Dim num5 As Integer = Me.EntityRandomAngle - Me.EntityAlignMove
			Dim num6 As UInteger = 20UI
			Do
				__Dereference((num + ptr9)) = 1
				Dim ptr10 As __Pointer(Of GBaseString<char>) = <Module>.new(8UI)
				Dim ptr11 As __Pointer(Of GBaseString<char>)
				Try
					If ptr10 IsNot Nothing Then
						__Dereference(CType(ptr10, __Pointer(Of Integer))) = 0
						__Dereference(CType((ptr10 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0
						ptr11 = ptr10
					Else
						ptr11 = 0
					End If
				Catch 
					<Module>.delete(CType(ptr10, __Pointer(Of Void)))
					Throw
				End Try
				__Dereference(ptr9) = ptr11
				__Dereference((ptr8 + num2)) = 0
				__Dereference(ptr8) = 0
				__Dereference((ptr8 + num3)) = 0
				__Dereference((ptr8 + num4)) = 0
				__Dereference((ptr8 + num5)) = 0
				ptr9 += 4
				ptr8 += 1
				num6 -= 1UI
			Loop While num6 > 0UI
			Me.PreCreatedEntity = -1
			Dim ptr12 As __Pointer(Of GBaseString<char>) = <Module>.new(8UI)
			Dim mapFileName As __Pointer(Of GBaseString<char>)
			Try
				If ptr12 IsNot Nothing Then
					__Dereference(CType(ptr12, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr12 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0
					mapFileName = ptr12
				Else
					mapFileName = 0
				End If
			Catch 
				<Module>.delete(CType(ptr12, __Pointer(Of Void)))
				Throw
			End Try
			Me.MapFileName = mapFileName
			Dim ptr13 As __Pointer(Of GBaseString<char>) = <Module>.new(8UI)
			Dim exportMapFileName As __Pointer(Of GBaseString<char>)
			Try
				If ptr13 IsNot Nothing Then
					__Dereference(CType(ptr13, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr13 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0
					exportMapFileName = ptr13
				Else
					exportMapFileName = 0
				End If
			Catch 
				<Module>.delete(CType(ptr13, __Pointer(Of Void)))
				Throw
			End Try
			Me.ExportMapFileName = exportMapFileName
			Dim ptr14 As __Pointer(Of GBaseString<char>) = <Module>.new(8UI)
			Dim importCamFileName As __Pointer(Of GBaseString<char>)
			Try
				If ptr14 IsNot Nothing Then
					__Dereference(CType(ptr14, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr14 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0
					importCamFileName = ptr14
				Else
					importCamFileName = 0
				End If
			Catch 
				<Module>.delete(CType(ptr14, __Pointer(Of Void)))
				Throw
			End Try
			Me.ImportCamFileName = importCamFileName
			Me.ToolWindows = New ArrayList()
			Me.ScrollbarOn = False
			Me.OldHeight = 0
			Me.OpenFileName = ""
			Me.TemporaryModeChange = False
			Me.CurrentEntityToolbar = Nothing
			Me.CurrentMinimap = Nothing
			Me.BrushNeedsUpdate = False
			Me.MinimapViewportNeedsUpdate = False
			Me.MinimapUnitsNeedUpdate = False
			Me.LastCameraType = 0
			Dim lastCamera As __Pointer(Of GCamera) = <Module>.new(20UI)
			Me.LastCamera = lastCamera
			Me.SectorSelectionNeedsUpdate = False
			Me.LastPasteOptions = 8191UI
			Dim ptr15 As __Pointer(Of GArray<GIModel *>) = <Module>.new(12UI)
			Dim physicsModels As __Pointer(Of GArray<GIModel *>)
			Try
				If ptr15 IsNot Nothing Then
					__Dereference(CType(ptr15, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr15 + 4 / __SizeOf(GArray<GIModel *>)), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr15 + 8 / __SizeOf(GArray<GIModel *>)), __Pointer(Of Integer))) = 0
					physicsModels = ptr15
				Else
					physicsModels = 0
				End If
			Catch 
				<Module>.delete(CType(ptr15, __Pointer(Of Void)))
				Throw
			End Try
			Me.PhysicsModels = physicsModels
			Me.KeyDragMode = 0
		End Sub

		Private Function SaveDocumentIfChanged() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world Is Nothing OrElse <Module>.GEditorWorld.IsChanged(world) Is Nothing Then
				Return True
			End If
			Dim dialogResult As DialogResult = MessageBox.Show("The map has been modified since the last save." & vbLf & "Do you want to save?", "Save Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation)
			If dialogResult = DialogResult.No Then
				Return True
			End If
			If dialogResult = DialogResult.Yes Then
				Me.menuFileSave_Click(Nothing, Nothing)
				If <Module>.GEditorWorld.IsChanged(Me.World) Is Nothing Then
					Return True
				End If
			End If
			Return False
		End Function

		Private Sub DiscardDocument()
			Me.EndDebugMap()
			Me.SetEditorMode(0)
			Me.EnableMenuAndToolbarItems(False)
			Me.SelectionActive = False
			Dim scriptEditorFormInstance As ScriptEditorForm = Me.ScriptEditorFormInstance
			If scriptEditorFormInstance IsNot Nothing Then
				scriptEditorFormInstance.Close()
				__Dereference(CType((Me.World + 5080 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = 0
				Me.ScriptEditorFormInstance = Nothing
			End If
			If <Module>.Scene IsNot Nothing Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(Me.BrushCursor), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 260)))
				__Dereference(CType(Me.BrushCursor, __Pointer(Of Integer))) = 0
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(Me.ParcelSelection), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 260)))
				__Dereference(CType(Me.ParcelSelection, __Pointer(Of Integer))) = 0
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 260)))
				__Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 260)))
				__Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
			End If
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				Dim ptr As __Pointer(Of GEditorWorld) = world
				Dim arg_114_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr, 1, __Dereference((__Dereference(CType(ptr, __Pointer(Of Integer))))))
				Me.World = Nothing
			End If
		End Sub

		Private Sub NewDocument(width As Integer, height As Integer)
			Me.DiscardDocument()
			Me.CameraCurveProps.InitCameraCurveProps()
			Dim ptr As __Pointer(Of GEditorWorld) = <Module>.new(5192UI)
			Dim ptr2 As __Pointer(Of GEditorWorld)
			Try
				If ptr IsNot Nothing Then
					Dim nD As __Pointer(Of GNativeData) = Me.ND
					ptr2 = <Module>.GEditorWorld.{ctor}(ptr, __Dereference(CType((nD + 4 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), __Dereference(CType(nD, __Pointer(Of GHandle<19>))), __Dereference(CType(nD, __Pointer(Of GHandle<19>))))
				Else
					ptr2 = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			<Module>.GWorld.New(ptr2, width, height, CType((AddressOf <Module>.??_C@_0M@PDMEOFLC@000?5default?$AA@), __Pointer(Of SByte)))
			<Module>.GEditorWorld.Initialize(ptr2)
			<Module>.GWorld.SetCameraFarClip(ptr2, 600F)
			Me.World = ptr2
			<Module>.SafeWorld = ptr2
			<Module>.GEditorWorld.SelectNone(Me.World)
			Me.InitUI()
			Dim mapFileName As __Pointer(Of GBaseString<char>) = Me.MapFileName
			Dim num As UInteger = CUInt((__Dereference(mapFileName)))
			If num <> 0UI Then
				<Module>.free(num)
				__Dereference(mapFileName) = 0
			End If
			__Dereference((mapFileName + 4)) = 0
			Me.EnableMenuAndToolbarItems(True)
			Me.InitMinimap()
			Me.InitScriptTools()
			Me.SetEditorMode(1)
		End Sub

		Private Sub OpenDocument(filepathname As String)
			Me.DiscardDocument()
			Me.CameraCurveProps.InitCameraCurveProps()
			Dim gBaseString<char> As GBaseString<char>
			Dim src As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, filepathname)
			Try
				<Module>.GBaseString<char>.=(Me.MapFileName, src)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Dim num As UInteger = CUInt((__Dereference(CType(Me.MapFileName, __Pointer(Of Integer)))))
			Dim ptr As __Pointer(Of SByte)
			If num <> 0UI Then
				ptr = num
			Else
				ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
			End If
			Dim ptr2 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenRead(<Module>.FS, ptr, Nothing)
			Dim mapFileName As __Pointer(Of GBaseString<char>) = Me.MapFileName
			Dim num2 As Integer = __Dereference((mapFileName + 4))
			Dim gBaseString<char>2 As GBaseString<char>
			If num2 <> 0 Then
				__Dereference((gBaseString<char>2 + 4)) = num2
				gBaseString<char>2 = <Module>.malloc(CUInt((__Dereference((gBaseString<char>2 + 4)) + 1)))
				cpblk(gBaseString<char>2, __Dereference(mapFileName), __Dereference((gBaseString<char>2 + 4)) + 1)
			Else
				__Dereference((gBaseString<char>2 + 4)) = 0
				gBaseString<char>2 = 0
			End If
			Try
				Dim num3 As UInteger = CUInt((__Dereference(<Module>.GBaseString<char>.SetExtension(gBaseString<char>2, CType((AddressOf <Module>.??_C@_03LDJCPKFL@ma2?$AA@), __Pointer(Of SByte))))))
				Dim ptr3 As __Pointer(Of SByte)
				If num3 <> 0UI Then
					ptr3 = num3
				Else
					ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				Dim ptr4 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenRead(<Module>.FS, ptr3, Nothing)
				If ptr2 Is Nothing Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1021, CType((AddressOf <Module>.??_C@_0CD@EHEEFEHN@NWorkshop?3?3NMainForm?3?3OpenDocume@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), __Pointer(Of SByte)), __Dereference(Me.MapFileName))
				End If
				Dim ptr5 As __Pointer(Of GEditorWorld) = <Module>.new(5192UI)
				Dim ptr6 As __Pointer(Of GEditorWorld)
				Try
					If ptr5 IsNot Nothing Then
						Dim nD As __Pointer(Of GNativeData) = Me.ND
						ptr6 = <Module>.GEditorWorld.{ctor}(ptr5, __Dereference(CType((nD + 4 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), __Dereference(CType(nD, __Pointer(Of GHandle<19>))), __Dereference(CType(nD, __Pointer(Of GHandle<19>))))
					Else
						ptr6 = 0
					End If
				Catch 
					<Module>.delete(CType(ptr5, __Pointer(Of Void)))
					Throw
				End Try
				Dim gAWorld As GAWorld
				<Module>.GAWorld.{ctor}(gAWorld)
				Try
					<Module>.GAWorld.Load(gAWorld, ptr4)
					If <Module>.?Load@GWorld@@$$FQAE_NPAVGStream@@PAVGAWorld@@_NP6AXABUGLoadingInfo@@PAX@ZP6AXXZP6AHW4AssetType@@PBDAAV?$GBaseString@D@@2@Z4@Z(ptr6, ptr2, AddressOf gAWorld, True, <Module>.__unep@?OnLoadNotifier@NWorkshop@@$$FYAXABUGLoadingInfo@@PAX@Z, <Module>.__unep@?OnLoadRefresh@NWorkshop@@$$FYAXXZ, <Module>.__unep@?MissingAssetHandler@NWorkshop@@$$FYAHW4AssetType@@PBDAAV?$GBaseString@D@@_N@Z, Nothing) IsNot Nothing Then
						<Module>.GEditorWorld.Initialize(ptr6)
						<Module>.GEditorWorld.ReplaceDoodadsToBuildings(ptr6)
						<Module>.GWorld.SetCameraFarClip(ptr6, 600F)
						Me.World = ptr6
						<Module>.SafeWorld = ptr6
						<Module>.GEditorWorld.SelectNone(Me.World)
						Me.InitUI()
						Me.EnableMenuAndToolbarItems(True)
						Me.InitMinimap()
						Me.InitScriptTools()
						Me.SetEditorMode(1)
					Else
						Dim mapFileName2 As __Pointer(Of GBaseString<char>) = Me.MapFileName
						Dim num4 As UInteger = CUInt((__Dereference(mapFileName2)))
						If num4 <> 0UI Then
							<Module>.free(num4)
							__Dereference(mapFileName2) = 0
						End If
						__Dereference((mapFileName2 + 4)) = 0
						If ptr6 IsNot Nothing Then
							Dim arg_1F8_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, __Dereference((__Dereference(ptr6))))
						End If
					End If
					Dim arg_203_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, __Dereference((__Dereference(CType(ptr2, __Pointer(Of Integer))))))
					If ptr4 IsNot Nothing Then
						Dim arg_213_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, __Dereference((__Dereference(CType(ptr4, __Pointer(Of Integer))))))
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWorld.{dtor}), CType((AddressOf gAWorld), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GAWorld.{dtor}(gAWorld)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>2 IsNot Nothing Then
				<Module>.free(gBaseString<char>2)
			End If
		End Sub

		Private Sub SaveDocument()
			If Me.World IsNot Nothing Then
				Dim mapFileName As __Pointer(Of GBaseString<char>) = Me.MapFileName
				If(If((__Dereference(CType((mapFileName + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0), 1, 0)) = 0 Then
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.Dirname(mapFileName, AddressOf gBaseString<char>)
					Dim gBaseString<char>2 As GBaseString<char>
					Try
						<Module>.GBaseString<char>.+(ptr, AddressOf gBaseString<char>2, CType((AddressOf <Module>.??_C@_09IECNAGPM@?1$$temp$$?$AA@), __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
						End If
						Dim gBaseString<char>3 As GBaseString<char>
						Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.Dirname(Me.MapFileName, AddressOf gBaseString<char>3)
						Dim gBaseString<char>4 As GBaseString<char>
						Try
							<Module>.GBaseString<char>.+(ptr2, AddressOf gBaseString<char>4, CType((AddressOf <Module>.??_C@_0L@DABFHKNE@?1$$temp2$$?$AA@), __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
							Throw
						End Try
						Try
							If gBaseString<char>3 IsNot Nothing Then
								<Module>.free(gBaseString<char>3)
							End If
							Dim mapFileName2 As __Pointer(Of GBaseString<char>) = Me.MapFileName
							Dim num As Integer = __Dereference((mapFileName2 + 4))
							Dim gBaseString<char>5 As GBaseString<char>
							If num <> 0 Then
								__Dereference((gBaseString<char>5 + 4)) = num
								Dim num2 As UInteger = CUInt((__Dereference((gBaseString<char>5 + 4)) + 1))
								gBaseString<char>5 = <Module>.malloc(num2)
								cpblk(gBaseString<char>5, __Dereference(mapFileName2), num2)
							Else
								__Dereference((gBaseString<char>5 + 4)) = 0
								gBaseString<char>5 = 0
							End If
							Try
								<Module>.GBaseString<char>.SetExtension(gBaseString<char>5, CType((AddressOf <Module>.??_C@_03LDJCPKFL@ma2?$AA@), __Pointer(Of SByte)))
								Dim ptr3 As __Pointer(Of SByte)
								If gBaseString<char>2 IsNot Nothing Then
									ptr3 = gBaseString<char>2
								Else
									ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								Dim ptr4 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenWrite(<Module>.FS, ptr3, Nothing)
								Dim ptr5 As __Pointer(Of SByte)
								If gBaseString<char>4 IsNot Nothing Then
									ptr5 = gBaseString<char>4
								Else
									ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								Dim ptr6 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenWrite(<Module>.FS, ptr5, Nothing)
								If ptr4 Is Nothing Then
									<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1066, CType((AddressOf <Module>.??_C@_0CD@DBLALDPC@NWorkshop?3?3NMainForm?3?3SaveDocume@), __Pointer(Of SByte)))
									Dim num3 As UInteger = CUInt((__Dereference(CType(Me.MapFileName, __Pointer(Of Integer)))))
									Dim ptr7 As __Pointer(Of SByte)
									If num3 <> 0UI Then
										ptr7 = num3
									Else
										ptr7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), __Pointer(Of SByte)), ptr7)
								End If
								If <Module>.GEditorWorld.Save(Me.World, ptr4, ptr6) IsNot Nothing Then
									<Module>.GEditorWorld.MarkSaved(Me.World)
									Dim arg_18B_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, __Dereference((__Dereference(CType(ptr4, __Pointer(Of Integer))))))
									If ptr6 IsNot Nothing Then
										Dim arg_199_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, __Dereference((__Dereference(CType(ptr6, __Pointer(Of Integer))))))
									End If
									Dim num4 As UInteger = CUInt((__Dereference(CType(Me.MapFileName, __Pointer(Of Integer)))))
									<Module>.unlink(If((num4 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num4))
									<Module>.unlink(If((gBaseString<char>5 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>5))
									Dim num5 As UInteger = CUInt((__Dereference(CType(Me.MapFileName, __Pointer(Of Integer)))))
									Dim ptr8 As __Pointer(Of SByte)
									If num5 <> 0UI Then
										ptr8 = num5
									Else
										ptr8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									<Module>.rename(If((gBaseString<char>2 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>2), ptr8)
									Dim ptr9 As __Pointer(Of SByte)
									If gBaseString<char>5 IsNot Nothing Then
										ptr9 = gBaseString<char>5
									Else
										ptr9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									<Module>.rename(If((gBaseString<char>4 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>4), ptr9)
								Else
									Dim arg_22C_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, __Dereference((__Dereference(CType(ptr4, __Pointer(Of Integer))))))
									If ptr6 IsNot Nothing Then
										Dim arg_23A_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, __Dereference((__Dereference(CType(ptr6, __Pointer(Of Integer))))))
									End If
									<Module>.unlink(If((gBaseString<char>2 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>2))
									<Module>.unlink(If((gBaseString<char>4 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>4))
								End If
								Me.RefreshMenuAndToolbarItems()
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>5 IsNot Nothing Then
								<Module>.free(gBaseString<char>5)
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>4 IsNot Nothing Then
							<Module>.free(gBaseString<char>4)
							gBaseString<char>4 = 0
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
					End If
				End If
			End If
		End Sub

		Private Sub ExportMap()
			If Me.World IsNot Nothing Then
				Dim exportMapFileName As __Pointer(Of GBaseString<char>) = Me.ExportMapFileName
				If(If((__Dereference(CType((exportMapFileName + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0), 1, 0)) = 0 Then
					Dim ptr As __Pointer(Of GStream) = <Module>.GFileSystem.OpenWrite(<Module>.FS, <Module>.GBaseString<char>..PBD(exportMapFileName), Nothing)
					If ptr Is Nothing Then
						<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1098, CType((AddressOf <Module>.??_C@_0CA@EEBAHGLL@NWorkshop?3?3NMainForm?3?3ExportMap?$AA@), __Pointer(Of SByte)))
						<Module>.GLogger.Warning(CType((AddressOf <Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), __Pointer(Of SByte)), <Module>.GBaseString<char>..PBD(Me.ExportMapFileName))
					Else
						Dim gBaseString<char> As GBaseString<char>
						<Module>.GBaseString<char>.Basename(Me.ExportMapFileName, AddressOf gBaseString<char>)
						Try
							Dim gBaseString<char>2 As GBaseString<char>
							<Module>.GBaseString<char>.Copy(gBaseString<char>, AddressOf gBaseString<char>2, 0, <Module>.GBaseString<char>.GetFirstCharIndex(gBaseString<char>, 46))
							Try
								Dim gBaseString<char>3 As GBaseString<char>
								<Module>.GBaseString<char>.+(gBaseString<char>2, AddressOf gBaseString<char>3, CType((AddressOf <Module>.??_C@_0N@KFJPEGJO@_terrain?44dp?$AA@), __Pointer(Of SByte)))
								Try
									Dim gBaseString<char>4 As GBaseString<char>
									Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.Dirname(Me.ExportMapFileName, AddressOf gBaseString<char>4)
									Dim gBaseString<char>6 As GBaseString<char>
									Try
										Dim gBaseString<char>5 As GBaseString<char>
										Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(ptr2, AddressOf gBaseString<char>5, CType((AddressOf <Module>.??_C@_01KMDKNFGN@?1?$AA@), __Pointer(Of SByte)))
										Try
											<Module>.GBaseString<char>.+(ptr3, AddressOf gBaseString<char>6, gBaseString<char>3)
										Catch 
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
											Throw
										End Try
										Try
											<Module>.GBaseString<char>.{dtor}(gBaseString<char>5)
										Catch 
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
											Throw
										End Try
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
										Throw
									End Try
									Try
										<Module>.GBaseString<char>.{dtor}(gBaseString<char>4)
										Dim ptr4 As __Pointer(Of G4DPModel) = <Module>.new(56UI)
										Dim ptr5 As __Pointer(Of G4DPModel)
										Try
											If ptr4 IsNot Nothing Then
												ptr5 = <Module>.G4DPModel.{ctor}(ptr4)
											Else
												ptr5 = 0
											End If
										Catch 
											<Module>.delete(CType(ptr4, __Pointer(Of Void)))
											Throw
										End Try
										__Dereference(ptr5) = 1
										Dim num As Integer = <Module>.GArray<G4DPNode>.Add(ptr5 + 32)
										Dim num2 As Integer = __Dereference(CType((Me.World + 2548 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
										Dim num3 As Integer = num * 128
										Dim arg_16A_0 As __Pointer(Of Integer) = num3 + __Dereference((ptr5 + 32)) + 100
										Dim expr_15F As Integer = num2
										__Dereference(arg_16A_0) = calli(G4DPMesh* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_15F, __Dereference((__Dereference(expr_15F) + 52)))
										<Module>.GBaseString<char>.=(num3 + __Dereference((ptr5 + 32)), CType((AddressOf <Module>.??_C@_07GICFIHGN@Terrain?$AA@), __Pointer(Of SByte)))
										<Module>.GBaseString<char>.=(__Dereference((ptr5 + 32)) + num3 + 8, CType((AddressOf <Module>.??_C@_07GICFIHGN@Terrain?$AA@), __Pointer(Of SByte)))
										__Dereference((<Module>.GArray<G4DPNode>.[](ptr5 + 32, num) + 16)) = -1
										__Dereference((<Module>.GArray<G4DPNode>.[](ptr5 + 32, num) + 20)) = -1
										Dim ptr6 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenWrite(<Module>.FS, <Module>.GBaseString<char>..PBD(gBaseString<char>6), Nothing)
										<Module>.GRTTI.SaveVariablesAsText(ptr6, AddressOf <Module>.GRTT_4dpModel.Class_G4DPModel, ptr5, <Module>.Measures)
										If ptr6 IsNot Nothing Then
											Dim arg_1ED_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, __Dereference((__Dereference(CType(ptr6, __Pointer(Of Integer))))))
										End If
										Dim ptr7 As __Pointer(Of G4DPModelList) = <Module>.new(12UI)
										Dim ptr8 As __Pointer(Of G4DPModelList)
										Try
											If ptr7 IsNot Nothing Then
												ptr8 = <Module>.G4DPModelList.{ctor}(ptr7)
											Else
												ptr8 = 0
											End If
										Catch 
											<Module>.delete(CType(ptr7, __Pointer(Of Void)))
											Throw
										End Try
										Dim num4 As Integer = <Module>.GArray<G4DPModelInfo>.Add(ptr8)
										<Module>.GBaseString<char>.=(<Module>.GArray<G4DPModelInfo>.[](ptr8, num4), gBaseString<char>3)
										<Module>.GBaseString<char>.=(<Module>.GArray<G4DPModelInfo>.[](ptr8, num4) + 8, CType((AddressOf <Module>.??_C@_07GICFIHGN@Terrain?$AA@), __Pointer(Of SByte)))
										cpblk(<Module>.GArray<G4DPModelInfo>.[](ptr8, num4) + 16, <Module>.RHandToLHandMatrix, 48)
										Dim ptr9 As __Pointer(Of GEditorWorld) = Me.World + 3196 / __SizeOf(GEditorWorld)
										Dim num5 As Integer = <Module>.GHeap<GWCameraCurve>.GetNext(ptr9, -1)
										If num5 >= 0 Then
											Do
												Dim num6 As Integer = num5 * 104
												If __Dereference((num6 + __Dereference(CType(ptr9, __Pointer(Of Integer))) + 4 + 32)) = 0 Then
													Dim src As __Pointer(Of GWCameraCurve) = num6 + __Dereference(CType(ptr9, __Pointer(Of Integer))) + 4
													Dim gBaseString<char>7 As GBaseString<char>
													<Module>.GBaseString<char>.{ctor}(gBaseString<char>7, src)
													Try
														Dim gPoint As GPoint3
														__Dereference((gPoint + 8)) = 0F
														__Dereference((gPoint + 4)) = 0F
														gPoint = 0F
														Dim gPoint2 As GPoint3
														__Dereference((gPoint2 + 8)) = 0F
														__Dereference((gPoint2 + 4)) = 0F
														gPoint2 = 0F
														Dim num7 As Single = <Module>.GWorld.GetCameraCurveDuration(Me.World, num5)
														If num7 <> 0F Then
															GoTo IL_306
														End If
													Catch 
														<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>7), __Pointer(Of Void)))
														Throw
													End Try
													<Module>.GBaseString<char>.{dtor}(gBaseString<char>7)
													GoTo IL_6C3
													IL_306:
													Try
														Dim num8 As Integer = 0
														ptr9 = Me.World + 3196 / __SizeOf(GEditorWorld)
														Dim ptr10 As __Pointer(Of GWCameraCurve) = num6 + __Dereference(CType(ptr9, __Pointer(Of Integer))) + 4
														Dim num9 As Integer = __Dereference((ptr10 + 48))
														If 0 < num9 Then
															Do
																Dim num10 As Integer = __Dereference(CType(ptr9, __Pointer(Of Integer)))
																Dim ptr11 As __Pointer(Of GWCameraCurve) = num6 + num10 + 4
																Dim num11 As Integer = __Dereference((num8 * 4 + __Dereference((ptr11 + 44))))
																Dim src2 As __Pointer(Of GWCameraCurve) = num10 + num11 * 104 + 4
																Dim gBaseString<char>8 As GBaseString<char>
																<Module>.GBaseString<char>.{ctor}(gBaseString<char>8, src2)
																Try
																	Dim gBaseString<char>9 As GBaseString<char>
																	Dim ptr12 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(gBaseString<char>7, AddressOf gBaseString<char>9, CType((AddressOf <Module>.??_C@_01IDAFKMJL@_?$AA@), __Pointer(Of SByte)))
																	Dim gBaseString<char>10 As GBaseString<char>
																	Try
																		<Module>.GBaseString<char>.+(ptr12, AddressOf gBaseString<char>10, gBaseString<char>8)
																	Catch 
																		<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>9), __Pointer(Of Void)))
																		Throw
																	End Try
																	Try
																		If gBaseString<char>9 IsNot Nothing Then
																			<Module>.free(gBaseString<char>9)
																			gBaseString<char>9 = 0
																		End If
																		Dim gBaseString<char>11 As GBaseString<char>
																		Dim ptr13 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(gBaseString<char>2, AddressOf gBaseString<char>11, gBaseString<char>10)
																		Dim gBaseString<char>12 As GBaseString<char>
																		Try
																			<Module>.GBaseString<char>.+(ptr13, AddressOf gBaseString<char>12, CType((AddressOf <Module>.??_C@_07PAGPJACA@?44dpcam?$AA@), __Pointer(Of SByte)))
																		Catch 
																			<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>11), __Pointer(Of Void)))
																			Throw
																		End Try
																		Try
																			If gBaseString<char>11 IsNot Nothing Then
																				<Module>.free(gBaseString<char>11)
																				gBaseString<char>11 = 0
																			End If
																			Dim gBaseString<char>13 As GBaseString<char>
																			Dim ptr14 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.Dirname(Me.ExportMapFileName, AddressOf gBaseString<char>13)
																			Dim gBaseString<char>15 As GBaseString<char>
																			Try
																				Dim gBaseString<char>14 As GBaseString<char>
																				Dim ptr15 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(ptr14, AddressOf gBaseString<char>14, CType((AddressOf <Module>.??_C@_01KMDKNFGN@?1?$AA@), __Pointer(Of SByte)))
																				Try
																					<Module>.GBaseString<char>.+(ptr15, AddressOf gBaseString<char>15, gBaseString<char>12)
																				Catch 
																					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>14), __Pointer(Of Void)))
																					Throw
																				End Try
																				Try
																					If gBaseString<char>14 IsNot Nothing Then
																						<Module>.free(gBaseString<char>14)
																						gBaseString<char>14 = 0
																					End If
																				Catch 
																					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>15), __Pointer(Of Void)))
																					Throw
																				End Try
																			Catch 
																				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>13), __Pointer(Of Void)))
																				Throw
																			End Try
																			Try
																				If gBaseString<char>13 IsNot Nothing Then
																					<Module>.free(gBaseString<char>13)
																					gBaseString<char>13 = 0
																				End If
																				Dim ptr16 As __Pointer(Of G4DPCameraCurve) = <Module>.new(32UI)
																				Dim ptr17 As __Pointer(Of G4DPCameraCurve)
																				Try
																					If ptr16 IsNot Nothing Then
																						ptr17 = <Module>.G4DPCameraCurve.{ctor}(ptr16)
																					Else
																						ptr17 = 0
																					End If
																				Catch 
																					<Module>.delete(CType(ptr16, __Pointer(Of Void)))
																					Throw
																				End Try
																				Dim num7 As Single
																				__Dereference((ptr17 + 8)) = num7
																				<Module>.GBaseString<char>.=(ptr17, gBaseString<char>10)
																				__Dereference((ptr17 + 12)) = 1.76666665F
																				__Dereference((ptr17 + 16)) = 20F
																				Dim num12 As Single = 0F
																				If 0F <= num7 Then
																					Dim num13 As Single = 1F / num7
																					Do
																						Dim gPoint As GPoint3
																						Dim gPoint2 As GPoint3
																						Dim num14 As Single
																						Dim num15 As Single
																						Dim num16 As Single
																						Dim num17 As Single
																						<Module>.GWorld.GetCameraAllParams(Me.World, num5, num11, True, num12 * num13, gPoint, gPoint2, num14, num15, num16, num17)
																						gPoint *= 1.5F
																						__Dereference((gPoint + 4)) = __Dereference((gPoint + 4)) * 1.5F
																						__Dereference((gPoint + 8)) = __Dereference((gPoint + 8)) * -1.5F
																						gPoint2 *= 1.5F
																						__Dereference((gPoint2 + 4)) = __Dereference((gPoint2 + 4)) * 1.5F
																						__Dereference((gPoint2 + 8)) = __Dereference((gPoint2 + 8)) * -1.5F
																						Dim num18 As Integer = <Module>.GArray<G4DPCameraKey>.Add(ptr17 + 20) * 36
																						__Dereference((__Dereference((ptr17 + 20)) + num18)) = num12
																						cpblk(num18 + __Dereference((ptr17 + 20)) + 4, gPoint, 12)
																						cpblk(num18 + __Dereference((ptr17 + 20)) + 16, gPoint2, 12)
																						__Dereference((num18 + __Dereference((ptr17 + 20)) + 28)) = num16
																						__Dereference((num18 + __Dereference((ptr17 + 20)) + 32)) = num17
																						num12 += 0.05F
																					Loop While num12 <= num7
																				End If
																				Dim ptr18 As __Pointer(Of SByte)
																				If gBaseString<char>15 IsNot Nothing Then
																					ptr18 = gBaseString<char>15
																				Else
																					ptr18 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
																				End If
																				Dim ptr19 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenWrite(<Module>.FS, ptr18, Nothing)
																				<Module>.GRTTI.SaveVariablesAsText(ptr19, AddressOf <Module>.GRTT_4dpModel.Class_G4DPCameraCurve, ptr17, <Module>.Measures)
																				If ptr19 IsNot Nothing Then
																					Dim arg_5EA_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr19, 1, __Dereference((__Dereference(CType(ptr19, __Pointer(Of Integer))))))
																				End If
																				<Module>.G4DPCameraCurve.{dtor}(ptr17)
																				<Module>.delete(ptr17)
																				num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8)
																				Dim num19 As Integer = num4 * 64
																				<Module>.GBaseString<char>.=(__Dereference(ptr8) + num19, gBaseString<char>12)
																				<Module>.GBaseString<char>.=(num19 + __Dereference(ptr8) + 8, CType((AddressOf <Module>.??_C@_06JCBBMBIP@Camera?$AA@), __Pointer(Of SByte)))
																			Catch 
																				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>15), __Pointer(Of Void)))
																				Throw
																			End Try
																			<Module>.GBaseString<char>.{dtor}(gBaseString<char>15)
																		Catch 
																			<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>12), __Pointer(Of Void)))
																			Throw
																		End Try
																		<Module>.GBaseString<char>.{dtor}(gBaseString<char>12)
																	Catch 
																		<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>10), __Pointer(Of Void)))
																		Throw
																	End Try
																	<Module>.GBaseString<char>.{dtor}(gBaseString<char>10)
																Catch 
																	<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>8), __Pointer(Of Void)))
																	Throw
																End Try
																<Module>.GBaseString<char>.{dtor}(gBaseString<char>8)
																num8 += 1
																ptr9 = Me.World + 3196 / __SizeOf(GEditorWorld)
																ptr10 = num6 + __Dereference(CType(ptr9, __Pointer(Of Integer))) + 4
																num9 = __Dereference((ptr10 + 48))
															Loop While num8 < num9
														End If
													Catch 
														<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>7), __Pointer(Of Void)))
														Throw
													End Try
													<Module>.GBaseString<char>.{dtor}(gBaseString<char>7)
												End If
												IL_6C3:
												ptr9 = Me.World + 3196 / __SizeOf(GEditorWorld)
												num5 = <Module>.GHeap<GWCameraCurve>.GetNext(ptr9, num5)
											Loop While num5 >= 0
										End If
										Dim ptr20 As __Pointer(Of GEditorWorld) = Me.World + 2928 / __SizeOf(GEditorWorld)
										Dim num20 As Integer = <Module>.GHeapDRB<GUnit *>.GetNext(ptr20, -1)
										If num20 >= 0 Then
											While True
												Dim expr_712 As Integer = __Dereference((__Dereference((num20 * 8 + __Dereference(CType(ptr20, __Pointer(Of Integer))) + 4)) + 8))
												Dim num21 As Integer
												If calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_712, __Dereference((__Dereference(expr_712) + 44))) Then
													num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8)
													num21 = num4 * 64
													<Module>.GBaseString<char>.=(num21 + __Dereference(ptr8) + 8, CType((AddressOf <Module>.??_C@_0N@MGNDAPHK@UnitBuilding?$AA@), __Pointer(Of SByte)))
													GoTo IL_785
												End If
												Dim expr_757 As Integer = __Dereference((__Dereference((num20 * 8 + __Dereference(CType((Me.World + 2928 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 4)) + 8))
												If calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_757, __Dereference((__Dereference(expr_757) + 36))) Then
													num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8)
													num21 = num4 * 64
													<Module>.GBaseString<char>.=(num21 + __Dereference(ptr8) + 8, CType((AddressOf <Module>.??_C@_0M@OIHLOAJC@UnitVehicle?$AA@), __Pointer(Of SByte)))
													GoTo IL_785
												End If
												IL_857:
												ptr20 = Me.World + 2928 / __SizeOf(GEditorWorld)
												num20 = <Module>.GHeapDRB<GUnit *>.GetNext(ptr20, num20)
												If num20 < 0 Then
													Exit While
												End If
												Continue While
												IL_785:
												Dim ptr21 As __Pointer(Of __Pointer(Of GUnit)) = num20 * 8 + __Dereference(CType((Me.World + 2928 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 4
												<Module>.GBaseString<char>.=(__Dereference(ptr8) + num21, __Dereference((__Dereference(ptr21) + 8)) + 12)
												ptr20 = Me.World + 2928 / __SizeOf(GEditorWorld)
												Dim ptr22 As __Pointer(Of __Pointer(Of GUnit)) = num20 * 8 + __Dereference(CType(ptr20, __Pointer(Of Integer))) + 4
												Dim gPoint3 As GPoint3
												cpblk(gPoint3, __Dereference(ptr22) + 528, 12)
												Dim gVector As GVector3
												__Dereference((gVector + 8)) = -(__Dereference((gPoint3 + 8)))
												Dim num22 As Single = gPoint3 * 1.5F
												Dim num23 As Single = __Dereference((gPoint3 + 4)) * 1.5F
												Dim num24 As Single = __Dereference((gVector + 8)) * 1.5F
												Dim gVector2 As GVector3 = num22
												__Dereference((gVector2 + 4)) = num23
												__Dereference((gVector2 + 8)) = num24
												Dim ptr23 As __Pointer(Of __Pointer(Of GUnit)) = num20 * 8 + __Dereference(CType(ptr20, __Pointer(Of Integer))) + 4
												Dim gMatrix As GMatrix3
												Dim gMatrix2 As GMatrix3
												Dim gMatrix3 As GMatrix3
												<Module>.GMatrix3.*(<Module>.Matrix3RotationY(AddressOf gMatrix, -(__Dereference((__Dereference(ptr23) + 564)))), AddressOf gMatrix2, <Module>.Matrix3Translation(AddressOf gMatrix3, gVector2))
												cpblk(num21 + __Dereference(ptr8) + 16, gMatrix2, 48)
												GoTo IL_857
											End While
										End If
										Dim num25 As Integer = <Module>.GHeap<GWDoodad>.GetNext(Me.World + 2864 / __SizeOf(GEditorWorld), -1)
										If num25 >= 0 Then
											Do
												num4 = <Module>.GArray<G4DPModelInfo>.Add(ptr8)
												Dim ptr24 As __Pointer(Of GWDoodad) = num25 * 208 + __Dereference(CType((Me.World + 2864 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 4
												Dim num26 As Integer = num4 * 64
												<Module>.GBaseString<char>.=(__Dereference(ptr8) + num26, ptr24 + 8)
												<Module>.GBaseString<char>.=(num26 + __Dereference(ptr8) + 8, CType((AddressOf <Module>.??_C@_06MMNHEDBI@Doodad?$AA@), __Pointer(Of SByte)))
												Dim world As __Pointer(Of GEditorWorld) = Me.World
												Dim num27 As Single = __Dereference((<Module>.GHeap<GWDoodad>.[](world + 2864 / __SizeOf(GEditorWorld), num25) + 20))
												Dim num28 As Single = __Dereference((<Module>.GHeap<GWDoodad>.[](world + 2864 / __SizeOf(GEditorWorld), num25) + 28))
												Dim num29 As Single = __Dereference((<Module>.GHeap<GWDoodad>.[](world + 2864 / __SizeOf(GEditorWorld), num25) + 24))
												Dim num30 As Single = <Module>.GWorld.GetHeight(world, num27, num29) + num28
												Dim gVector3 As GVector3 = num27
												__Dereference((gVector3 + 4)) = num30
												__Dereference((gVector3 + 8)) = -num29
												Dim gTransformation As GTransformation
												<Module>.GTransformation.{ctor}(gTransformation)
												Dim gVector4 As GVector3
												Dim ptr25 As __Pointer(Of GVector3) = <Module>.GVector3.*(gVector3, AddressOf gVector4, 1.5F)
												cpblk(gTransformation, ptr25, 12)
												Dim ptr26 As __Pointer(Of GEditorWorld) = Me.World + 2864 / __SizeOf(GEditorWorld)
												<Module>.GTransformation.SetRotationTiltXZ(gTransformation, -(__Dereference((<Module>.GHeap<GWDoodad>.[](ptr26, num25) + 32))), __Dereference((<Module>.GHeap<GWDoodad>.[](ptr26, num25) + 36)), -(__Dereference((<Module>.GHeap<GWDoodad>.[](ptr26, num25) + 40))))
												Dim arg_9AC_0 As Integer = __Dereference(ptr8) + num26
												Dim gMatrix4 As GMatrix3
												Dim ptr27 As __Pointer(Of GMatrix3) = <Module>.GTransformation.GetMatrix(gTransformation, AddressOf gMatrix4)
												cpblk(arg_9AC_0 + 16, ptr27, 48)
												num25 = <Module>.GHeap<GWDoodad>.GetNext(Me.World + 2864 / __SizeOf(GEditorWorld), num25)
											Loop While num25 >= 0
										End If
										<Module>.GRTTI.SaveVariablesAsText(ptr, AddressOf <Module>.GRTT_4dpModel.Class_G4DPModelList, ptr8, <Module>.Measures)
										If ptr8 IsNot Nothing Then
											<Module>.G4DPModelList.__delDtor(ptr8, 1UI)
										End If
										Dim arg_9F7_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr, 1, __Dereference((__Dereference(CType(ptr, __Pointer(Of Integer))))))
										Me.RefreshMenuAndToolbarItems()
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
										Throw
									End Try
									<Module>.GBaseString<char>.{dtor}(gBaseString<char>6)
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
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GBaseString<char>.{dtor}(gBaseString<char>)
					End If
				End If
			End If
		End Sub

		Private Sub ImportCamera()
			If Me.World IsNot Nothing Then
				Dim num As UInteger = CUInt((__Dereference(CType(Me.ImportCamFileName, __Pointer(Of Integer)))))
				Dim ptr As __Pointer(Of SByte)
				If num <> 0UI Then
					ptr = num
				Else
					ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				Dim ptr2 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenRead(<Module>.FS, ptr, Nothing)
				If ptr2 Is Nothing Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1255, CType((AddressOf <Module>.??_C@_0CD@EMPMDFDB@NWorkshop?3?3NMainForm?3?3ImportCame@), __Pointer(Of SByte)))
					Dim num2 As UInteger = CUInt((__Dereference(CType(Me.ImportCamFileName, __Pointer(Of Integer)))))
					Dim ptr3 As __Pointer(Of SByte)
					If num2 <> 0UI Then
						ptr3 = num2
					Else
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					<Module>.GLogger.Warning(CType((AddressOf <Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), __Pointer(Of SByte)), ptr3)
				Else
					Dim num3 As UInteger = CUInt((__Dereference(CType((Me.World + 3216 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))))
					If num3 <> 0UI Then
						Dim ptr4 As __Pointer(Of G4DPCameraCurve) = num3
						<Module>.G4DPCameraCurve.{dtor}(ptr4)
						<Module>.delete(CType(ptr4, __Pointer(Of Void)))
						__Dereference(CType((Me.World + 3216 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = 0
					End If
					Dim ptr5 As __Pointer(Of G4DPCameraCurve) = <Module>.new(32UI)
					Dim ptr6 As __Pointer(Of G4DPCameraCurve)
					Try
						If ptr5 IsNot Nothing Then
							ptr6 = <Module>.G4DPCameraCurve.{ctor}(ptr5)
						Else
							ptr6 = 0
						End If
					Catch 
						<Module>.delete(CType(ptr5, __Pointer(Of Void)))
						Throw
					End Try
					__Dereference(CType((Me.World + 3216 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = ptr6
					Dim gMeasures As GMeasures
					<Module>.GRTTI.LoadVariablesAsText(ptr2, AddressOf <Module>.GRTT_4dpModel.Class_G4DPCameraCurve, __Dereference(CType((Me.World + 3216 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))), <Module>.GMeasures.{ctor}(gMeasures, 1F, 1F))
					__Dereference(CType((Me.World + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) = 1
					Me.CameraCurveProps.RefreshCameraCurveIndex()
					Dim arg_11F_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, __Dereference((__Dereference(CType(ptr2, __Pointer(Of Integer))))))
				End If
			End If
		End Sub

		Private Sub RemoveImportCamera()
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				Dim num As UInteger = CUInt((__Dereference(CType((world + 3216 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))))
				If num <> 0UI Then
					Dim ptr As __Pointer(Of G4DPCameraCurve) = num
					<Module>.G4DPCameraCurve.{dtor}(ptr)
					<Module>.delete(CType(ptr, __Pointer(Of Void)))
					__Dereference(CType((Me.World + 3216 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = 0
				End If
				__Dereference(CType((Me.World + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) = 0
				Me.CameraCurveProps.RefreshCameraCurveIndex()
			End If
		End Sub

		Private Sub LoadScripts()
			Dim nFileDialog As NFileDialog = New NFileDialog(Nothing, True)
			nFileDialog.AvailableModes = 2
			nFileDialog.SelectedMode = 2
			nFileDialog.DefaultExtension = "scr"
			Dim gBaseString<char>3 As GBaseString<char>
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
				Dim gBaseString<char>2 As GBaseString<char>
				Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, nFileDialog.FilePath)
				Dim ptr6 As __Pointer(Of GStream)
				Try
					Dim num2 As UInteger = CUInt((__Dereference(<Module>.GBaseString<char>.SetExtension(ptr4, CType((AddressOf <Module>.??_C@_03PFCKMFAK@sce?$AA@), __Pointer(Of SByte))))))
					Dim ptr5 As __Pointer(Of SByte)
					If num2 <> 0UI Then
						ptr5 = num2
					Else
						ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					ptr6 = <Module>.GFileSystem.OpenRead(<Module>.FS, ptr5, Nothing)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
					gBaseString<char>2 = 0
				End If
				If ptr3 Is Nothing Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1293, CType((AddressOf <Module>.??_C@_0CC@OLBJKMDA@NWorkshop?3?3NMainForm?3?3LoadScript@), __Pointer(Of SByte)))
					Dim ptr7 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, nFileDialog.FilePath)
					Try
						<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), __Pointer(Of SByte)), __Dereference(ptr7))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
						Throw
					End Try
				End If
				Try
					<Module>.?LoadScriptEntities@GEditorWorld@@$$FQAE_NPAVGStream@@0P6AHW4AssetType@@PBDAAV?$GBaseString@D@@_N@Z@Z(Me.World, ptr3, ptr6, <Module>.__unep@?MissingAssetHandler@NWorkshop@@$$FYAHW4AssetType@@PBDAAV?$GBaseString@D@@_N@Z)
					Me.RefreshMenuAndToolbarItems()
					Dim arg_147_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, __Dereference((__Dereference(CType(ptr3, __Pointer(Of Integer))))))
					If ptr6 IsNot Nothing Then
						Dim arg_157_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, __Dereference((__Dereference(CType(ptr6, __Pointer(Of Integer))))))
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
			End If
			Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
				Throw
			End Try
		End Sub

		Private Sub SaveScripts()
			Dim nFileDialog As NFileDialog = New NFileDialog(Nothing, True)
			nFileDialog.AvailableModes = 4
			nFileDialog.SelectedMode = 4
			nFileDialog.DefaultExtension = "scr"
			Dim gBaseString<char>4 As GBaseString<char>
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
				Dim gBaseString<char>2 As GBaseString<char>
				Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, nFileDialog.FilePath)
				Dim ptr6 As __Pointer(Of GStream)
				Try
					Dim num2 As UInteger = CUInt((__Dereference(<Module>.GBaseString<char>.SetExtension(ptr4, CType((AddressOf <Module>.??_C@_03PFCKMFAK@sce?$AA@), __Pointer(Of SByte))))))
					Dim ptr5 As __Pointer(Of SByte)
					If num2 <> 0UI Then
						ptr5 = num2
					Else
						ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					ptr6 = <Module>.GFileSystem.OpenWrite(<Module>.FS, ptr5, Nothing)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
					gBaseString<char>2 = 0
				End If
				Dim gBaseString<char>3 As GBaseString<char>
				If ptr3 Is Nothing Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1315, CType((AddressOf <Module>.??_C@_0CC@BFOKHLGJ@NWorkshop?3?3NMainForm?3?3SaveScript@), __Pointer(Of SByte)))
					Dim ptr7 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, nFileDialog.FilePath)
					Try
						<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BC@OMEJDKEE@Couldn?8t?5write?5?$CFs?$AA@), __Pointer(Of SByte)), __Dereference(ptr7))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
						Throw
					End Try
				End If
				Dim ptr8 As __Pointer(Of GBaseString<char>)
				Try
					If ptr6 IsNot Nothing Then
						GoTo IL_188
					End If
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1317, CType((AddressOf <Module>.??_C@_0CC@BFOKHLGJ@NWorkshop?3?3NMainForm?3?3SaveScript@), __Pointer(Of SByte)))
					ptr8 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>4, nFileDialog.FilePath)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
				Try
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BC@OMEJDKEE@Couldn?8t?5write?5?$CFs?$AA@), __Pointer(Of SByte)), __Dereference(<Module>.GBaseString<char>.SetExtension(ptr8, CType((AddressOf <Module>.??_C@_03PFCKMFAK@sce?$AA@), __Pointer(Of SByte)))))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
					Throw
				End Try
				IL_188:
				Try
					<Module>.GEditorWorld.SaveScriptEntities(Me.World, ptr3, ptr6)
					Dim arg_1A1_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr3, 1, __Dereference((__Dereference(CType(ptr3, __Pointer(Of Integer))))))
					Dim arg_1AC_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, __Dereference((__Dereference(CType(ptr6, __Pointer(Of Integer))))))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
					Throw
				End Try
			End If
			Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
				Throw
			End Try
		End Sub

		Private Sub UpdateKey(time As Long, keycode As Integer)
			If Me.KeyDragMode = 0 Then
				Dim num As Long = __Dereference((keycode * 8 + Me.KeyTimes))
				Dim num2 As Long = time - num
				Dim lastUpdate As Long = Me.LastUpdate
				Dim num3 As Long
				If lastUpdate > num Then
					num3 = lastUpdate - num
				Else
					num3 = 0L
				End If
				Dim gameDebugWorld As __Pointer(Of GWorld) = Me.GameDebugWorld
				Dim ptr As __Pointer(Of GWorld)
				If gameDebugWorld IsNot Nothing Then
					ptr = gameDebugWorld
				Else
					ptr = CType(Me.World, __Pointer(Of GWorld))
				End If
				Select Case keycode
					Case 33
						<Module>.GWorld.CameraZoom(ptr, CSng((CDec((num2 - num3)) * 2E-05)))
					Case 34
						<Module>.GWorld.CameraRotate(ptr, CSng((CDec((num2 - num3)) * 1E-06)), 0F)
					Case 35
						<Module>.GWorld.CameraRotate(ptr, 0F, CSng((CDec((num2 - num3)) * 1E-06)))
					Case 36
						<Module>.GWorld.CameraRotate(ptr, 0F, CSng((CDec((num3 - num2)) * 1E-06)))
					Case 37
						<Module>.GWorld.CameraMove(ptr, 0F, CSng((CDec((num3 - num2)) * 2E-05)))
					Case 38
						<Module>.GWorld.CameraMove(ptr, CSng((CDec((num2 - num3)) * 2E-05)), 0F)
					Case 39
						<Module>.GWorld.CameraMove(ptr, 0F, CSng((CDec((num2 - num3)) * 2E-05)))
					Case 40
						<Module>.GWorld.CameraMove(ptr, CSng((CDec((num3 - num2)) * 2E-05)), 0F)
					Case 45
						<Module>.GWorld.CameraZoom(ptr, CSng((CDec((num3 - num2)) * 2E-05)))
					Case 46
						<Module>.GWorld.CameraRotate(ptr, CSng((CDec((num3 - num2)) * 1E-06)), 0F)
				End Select
				Me.MinimapViewportNeedsUpdate = True
			End If
		End Sub

		Private Sub SetEditorMode(mode As Integer)
			If Me.EditorMode <> mode Then
				MyBase.SuspendLayout()
				Dim flag As Boolean = False
				Select Case Me.EditorMode
					Case 1
						Me.CancelDepressedDrag(True)
						Me.panSideBar.Controls.Remove(Me.VertexToolContainer)
						Me.panSideBar.Controls.Remove(Me.VertexMinimap)
						If Me.World IsNot Nothing Then
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(Me.BrushCursor), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 264)))
						End If
					Case 2
						Me.panSideBar.Controls.Remove(Me.TerrainToolContainer)
						Me.panSideBar.Controls.Remove(Me.TerrainFileContainer)
						Me.panSideBar.Controls.Remove(Me.TerrainMinimap)
						Dim world As __Pointer(Of GEditorWorld) = Me.World
						If world IsNot Nothing Then
							<Module>.GEditorWorld.ShowInvertedSelection(world, False)
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(Me.BrushCursor), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 264)))
						End If
					Case 3
						Me.panSideBar.Controls.Remove(Me.RoadFileContainer)
						Me.panSideBar.Controls.Remove(Me.RoadToolContainer)
						Me.panSideBar.Controls.Remove(Me.RoadsMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 4
						Me.panSideBar.Controls.Remove(Me.DecalFileContainer)
						Me.panSideBar.Controls.Remove(Me.DecalToolContainer)
						Me.panSideBar.Controls.Remove(Me.DecalsMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 5
						Me.panSideBar.Controls.Remove(Me.LakeToolContainer)
						Me.panSideBar.Controls.Remove(Me.LakeFileContainer)
						Me.panSideBar.Controls.Remove(Me.LakeMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 6
						Me.panSideBar.Controls.Remove(Me.RiverToolContainer)
						Me.panSideBar.Controls.Remove(Me.RiverFileContainer)
						Me.panSideBar.Controls.Remove(Me.RiverMinimap)
						Me.CurrentEntityToolbar = Nothing
						Me.CurrentScriptEnittyToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 7
						Me.panSideBar.Controls.Remove(Me.ObjectFileContainer)
						Me.panSideBar.Controls.Remove(Me.ObjectToolContainer)
						Me.panSideBar.Controls.Remove(Me.ObjectsMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 8
						Me.CurrentEntityToolbar = Nothing
						Dim world2 As __Pointer(Of GEditorWorld) = Me.World
						If world2 IsNot Nothing Then
							Dim num As Integer = <Module>.GHeap<GWWirePoint>.GetNext(world2 + 3112 / __SizeOf(GEditorWorld), -1)
							If num >= 0 Then
								Do
									<Module>.GWorld.UpdateWirePoint(Me.World, num, False)
									num = <Module>.GHeap<GWWirePoint>.GetNext(Me.World + 3112 / __SizeOf(GEditorWorld), num)
								Loop While num >= 0
							End If
						End If
					Case 9
						Me.panSideBar.Controls.Remove(Me.BuildingPropertiesContainer)
						Me.panSideBar.Controls.Remove(Me.BuildingFileContainer)
						Me.panSideBar.Controls.Remove(Me.BuildingToolContainer)
						Me.panSideBar.Controls.Remove(Me.BuildingMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 10
						Me.panSideBar.Controls.Remove(Me.UnitFileContainer)
						Me.panSideBar.Controls.Remove(Me.UnitPropertiesContainer)
						Me.panSideBar.Controls.Remove(Me.PlayerContainer)
						Me.panSideBar.Controls.Remove(Me.UnitToolContainer)
						Me.panSideBar.Controls.Remove(Me.UnitMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 11
						Me.panSideBar.Controls.Remove(Me.SoundFileContainer)
						Me.panSideBar.Controls.Remove(Me.SoundToolContainer)
						Me.panSideBar.Controls.Remove(Me.SoundMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 12
						Me.panSideBar.Controls.Remove(Me.EffectFileContainer)
						Me.panSideBar.Controls.Remove(Me.EffectToolContainer)
						Me.panSideBar.Controls.Remove(Me.EffectMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 13
						Me.panSideBar.Controls.Remove(Me.WeatherToolContainer)
					Case 14
						Me.panSideBar.Controls.Remove(Me.OptionToolContainer)
					Case 15
						Me.panSideBar.Controls.Remove(Me.SectorToolContainer)
						If Me.World IsNot Nothing Then
							Me.InitMinimap()
							<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(Me.World, Me.LastCameraType)
							<Module>.GWorld.SetCamera(Me.World, Me.LastCamera)
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(Me.ParcelSelection), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 264)))
						End If
						Me.CurrentScriptEnittyToolbar = Nothing
					Case 16
						Dim world3 As __Pointer(Of GEditorWorld) = Me.World
						If world3 IsNot Nothing AndAlso <Module>.GEditorWorld.GetCameraCurveAlwaysDraw(world3) Is Nothing Then
							Me.CameraCurveProps.RemoveCameraViewPort()
						End If
						Me.panSideBar.Controls.Remove(Me.CameraCurveToolContainer)
						Me.panSideBar.Controls.Remove(Me.CameraCurveMinimap)
						Me.panSideBar.Controls.Remove(Me.CameraCurvePropsContainer)
						Me.CurrentEntityToolbar = Nothing
						Me.CurrentScriptEnittyToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 17
						Me.panSideBar.Controls.Remove(Me.PathToolContainer)
						Me.panSideBar.Controls.Remove(Me.PathPropsContainer)
						Me.panSideBar.Controls.Remove(Me.PathMinimap)
						Me.CurrentEntityToolbar = Nothing
						Me.CurrentScriptEnittyToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 18
						Me.panSideBar.Controls.Remove(Me.LocationToolContainer)
						Me.panSideBar.Controls.Remove(Me.LocationPropsContainer)
						Me.panSideBar.Controls.Remove(Me.LocationMinimap)
						Me.CurrentEntityToolbar = Nothing
						Me.CurrentScriptEnittyToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 19
						Me.panSideBar.Controls.Remove(Me.UnitGroupPropsContainer)
						Me.panSideBar.Controls.Remove(Me.UnitGroupMinimap)
						Me.CurrentEntityToolbar = Nothing
						Me.CurrentScriptEnittyToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
							<Module>.GEditorWorld.ShowAIGroups(Me.World)
						End If
					Case 20
						Me.panSideBar.Controls.Remove(Me.ObjectiveToolContainer)
						Me.panSideBar.Controls.Remove(Me.ObjectivePropsContainer)
						Me.CurrentScriptEnittyToolbar = Nothing
					Case 21
						Me.panSideBar.Controls.Remove(Me.NavPointToolContainer)
						Me.panSideBar.Controls.Remove(Me.NavPointsMinimap)
						Me.CurrentEntityToolbar = Nothing
						If Me.World IsNot Nothing Then
							Me.LeaveEntityMode()
						End If
					Case 22
						MyBase.Controls.Remove(Me.tbDebug)
						MyBase.Controls.Add(Me.tbMain)
						flag = True
				End Select
				Me.EditorMode = mode
				Me.CurrentMinimap = Nothing
				Dim checked As Byte = If((mode = 1), 1, 0)
				Me.menuModeVertex.Checked = (checked <> 0)
				Dim checked2 As Byte = If((Me.EditorMode = 2), 1, 0)
				Me.menuModePaint.Checked = (checked2 <> 0)
				Dim checked3 As Byte = If((Me.EditorMode = 3), 1, 0)
				Me.menuModeRoad.Checked = (checked3 <> 0)
				Dim checked4 As Byte = If((Me.EditorMode = 4), 1, 0)
				Me.menuModeDecal.Checked = (checked4 <> 0)
				Dim checked5 As Byte = If((Me.EditorMode = 5), 1, 0)
				Me.menuModeLake.Checked = (checked5 <> 0)
				Dim checked6 As Byte = If((Me.EditorMode = 6), 1, 0)
				Me.menuModeRiver.Checked = (checked6 <> 0)
				Dim checked7 As Byte = If((Me.EditorMode = 16), 1, 0)
				Me.menuModeCameraCurve.Checked = (checked7 <> 0)
				Dim checked8 As Byte = If((Me.EditorMode = 7), 1, 0)
				Me.menuModeDoodad.Checked = (checked8 <> 0)
				Dim checked9 As Byte = If((Me.EditorMode = 8), 1, 0)
				Me.menuModeWire.Checked = (checked9 <> 0)
				Dim checked10 As Byte = If((Me.EditorMode = 9), 1, 0)
				Me.menuModeBuilding.Checked = (checked10 <> 0)
				Dim checked11 As Byte = If((Me.EditorMode = 10), 1, 0)
				Me.menuModeUnit.Checked = (checked11 <> 0)
				Dim checked12 As Byte = If((Me.EditorMode = 11), 1, 0)
				Me.menuModeAmbient.Checked = (checked12 <> 0)
				Dim checked13 As Byte = If((Me.EditorMode = 12), 1, 0)
				Me.menuModeEffect.Checked = (checked13 <> 0)
				Dim checked14 As Byte = If((Me.EditorMode = 15), 1, 0)
				Me.menuModeSectors.Checked = (checked14 <> 0)
				Dim checked15 As Byte = If((Me.EditorMode = 17), 1, 0)
				Me.menuModePaths.Checked = (checked15 <> 0)
				Dim checked16 As Byte = If((Me.EditorMode = 18), 1, 0)
				Me.menuModeLocations.Checked = (checked16 <> 0)
				Dim checked17 As Byte = If((Me.EditorMode = 19), 1, 0)
				Me.menuModeUnitGroup.Checked = (checked17 <> 0)
				Me.tbMain.SetItemPushed(Me.EditorMode, True)
				Dim world4 As __Pointer(Of GEditorWorld) = Me.World
				If world4 Is Nothing AndAlso Me.GameDebugWorld Is Nothing Then
					MyBase.ResumeLayout(False)
				Else
					If world4 IsNot Nothing Then
						<Module>.?SetEditorMode@GEditorWorld@@$$FQAEXW4GEditorMode@@@Z(world4, Me.EditorMode)
					End If
					Select Case Me.EditorMode
						Case 1
							Me.VertexTools.SelectionType = __Dereference(CType(Me.Terraformer, __Pointer(Of Integer)))
							Me.VertexMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.VertexMinimap)
							Me.panSideBar.Controls.Add(Me.VertexToolContainer)
							Me.CurrentMinimap = Me.VertexMinimap
						Case 2
							Me.TerrainFilePicker.World = Me.World
							Me.TerrainMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.TerrainMinimap)
							Me.panSideBar.Controls.Add(Me.TerrainFileContainer)
							Me.panSideBar.Controls.Add(Me.TerrainToolContainer)
							Me.CurrentMinimap = Me.TerrainMinimap
							Me.TerrainFilePicker.UpdateLayerList(-1, 0)
							<Module>.GEditorWorld.ShowInvertedSelection(Me.World, True)
						Case 3
							Me.RoadsMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.RoadsMinimap)
							Me.panSideBar.Controls.Add(Me.RoadFileContainer)
							Me.panSideBar.Controls.Add(Me.RoadToolContainer)
							Me.CurrentMinimap = Me.RoadsMinimap
							Me.CurrentEntityToolbar = Me.RoadTools
							Me.EntityType = 9
						Case 4
							Me.DecalsMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.DecalsMinimap)
							Me.panSideBar.Controls.Add(Me.DecalFileContainer)
							Me.panSideBar.Controls.Add(Me.DecalToolContainer)
							Me.CurrentMinimap = Me.DecalsMinimap
							Me.CurrentEntityToolbar = Me.DecalTools
							Me.EntityType = 7
						Case 5
							Me.LakeMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.LakeMinimap)
							Me.panSideBar.Controls.Add(Me.LakeFileContainer)
							Me.panSideBar.Controls.Add(Me.LakeToolContainer)
							Me.CurrentMinimap = Me.LakeMinimap
							Me.CurrentEntityToolbar = Me.LakeTools
							Me.EntityType = 6
							<Module>.GEditorWorld.UpdateWaters(Me.World)
							If <Module>.GWorld.GetBlockMapMode(Me.World) IsNot Nothing Then
								<Module>.GWorld.UpdateWaterMap(Me.World)
							End If
						Case 6
							Me.RiverMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.RiverMinimap)
							Me.panSideBar.Controls.Add(Me.RiverFileContainer)
							Me.panSideBar.Controls.Add(Me.RiverToolContainer)
							Me.CurrentMinimap = Me.RiverMinimap
							Me.CurrentEntityToolbar = Me.RiverTools
							Me.EntityType = 11
							<Module>.GEditorWorld.UpdateWaters(Me.World)
							If <Module>.GWorld.GetBlockMapMode(Me.World) IsNot Nothing Then
								<Module>.GWorld.UpdateWaterMap(Me.World)
							End If
						Case 7
							Me.ObjectsMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.ObjectsMinimap)
							Me.panSideBar.Controls.Add(Me.ObjectFileContainer)
							Me.panSideBar.Controls.Add(Me.ObjectToolContainer)
							Me.CurrentMinimap = Me.ObjectsMinimap
							Me.CurrentEntityToolbar = Me.ObjectTools
							Me.EntityType = 1
						Case 8
							Dim num2 As Integer = <Module>.GHeap<GWWirePoint>.GetNext(Me.World + 3112 / __SizeOf(GEditorWorld), -1)
							If num2 >= 0 Then
								Do
									<Module>.GWorld.UpdateWirePoint(Me.World, num2, True)
									num2 = <Module>.GHeap<GWWirePoint>.GetNext(Me.World + 3112 / __SizeOf(GEditorWorld), num2)
								Loop While num2 >= 0
							End If
						Case 9
							Me.BuildingMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.BuildingMinimap)
							Me.panSideBar.Controls.Add(Me.BuildingFileContainer)
							Me.panSideBar.Controls.Add(Me.BuildingPropertiesContainer)
							Me.panSideBar.Controls.Add(Me.BuildingToolContainer)
							Me.CurrentMinimap = Me.BuildingMinimap
							Me.CurrentEntityToolbar = Me.BuildingTools
							Me.EntityType = 2
						Case 10
							Me.UnitMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.UnitMinimap)
							Me.panSideBar.Controls.Add(Me.UnitFileContainer)
							Me.panSideBar.Controls.Add(Me.UnitPropertiesContainer)
							Me.panSideBar.Controls.Add(Me.PlayerContainer)
							Me.panSideBar.Controls.Add(Me.UnitToolContainer)
							Me.CurrentMinimap = Me.UnitMinimap
							Me.CurrentEntityToolbar = Me.UnitTools
							Me.EntityType = 3
						Case 11
							Me.SoundMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.SoundMinimap)
							Me.panSideBar.Controls.Add(Me.SoundFileContainer)
							Me.panSideBar.Controls.Add(Me.SoundToolContainer)
							Me.CurrentMinimap = Me.SoundMinimap
							Me.CurrentEntityToolbar = Me.SoundTools
							Me.EntityType = 5
						Case 12
							Me.EffectMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.EffectMinimap)
							Me.panSideBar.Controls.Add(Me.EffectFileContainer)
							Me.panSideBar.Controls.Add(Me.EffectToolContainer)
							Me.CurrentMinimap = Me.EffectMinimap
							Me.CurrentEntityToolbar = Me.EffectTools
							Me.EntityType = 8
						Case 13
							Me.WeatherTools.Refresh(Me.World)
							Me.panSideBar.Controls.Add(Me.WeatherToolContainer)
						Case 14
							Me.OptionsTools.Refresh()
							Me.OptionsTools.RefreshResourceTree()
							Me.panSideBar.Controls.Add(Me.OptionToolContainer)
						Case 15
							Me.panSideBar.Controls.Add(Me.SectorToolContainer)
							If Not flag Then
								Me.LastCameraType = <Module>.?GetCameraType@GWorld@@$$FQBE?AW4GCameraType@@XZ(Me.World)
								<Module>.GWorld.GetCamera(Me.World, Me.LastCamera)
							End If
							<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(Me.World, 1)
							Me.SectorSelectionNeedsUpdate = True
							Me.SectorTools.World = Me.World
							Me.CurrentScriptEnittyToolbar = Me.SectorTools.ScriptEntityTool
						Case 16
							Me.CameraCurveMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.CameraCurveMinimap)
							Me.panSideBar.Controls.Add(Me.CameraCurvePropsContainer)
							Me.panSideBar.Controls.Add(Me.CameraCurveToolContainer)
							Me.CurrentMinimap = Me.CameraCurveMinimap
							Me.CurrentEntityToolbar = Me.CameraCurveTools
							Me.EntityType = 13
							Me.CameraCurveProps.World = Me.World
							Me.CurrentScriptEnittyToolbar = Me.CameraCurveProps
						Case 17
							Me.PathMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.PathMinimap)
							Me.panSideBar.Controls.Add(Me.PathPropsContainer)
							Me.panSideBar.Controls.Add(Me.PathToolContainer)
							Me.CurrentMinimap = Me.PathMinimap
							Me.CurrentEntityToolbar = Me.PathTools
							Me.EntityType = 15
							Me.PathProps.World = Me.World
							Me.CurrentScriptEnittyToolbar = Me.PathProps
						Case 18
							Me.LocationMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.LocationMinimap)
							Me.panSideBar.Controls.Add(Me.LocationPropsContainer)
							Me.panSideBar.Controls.Add(Me.LocationToolContainer)
							Me.CurrentMinimap = Me.LocationMinimap
							Me.CurrentEntityToolbar = Me.LocationTools
							Me.EntityType = 17
							Me.LocationProps.World = Me.World
							Me.CurrentScriptEnittyToolbar = Me.LocationProps
						Case 19
							Me.UnitGroupMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.UnitGroupMinimap)
							Me.panSideBar.Controls.Add(Me.UnitGroupPropsContainer)
							Me.CurrentMinimap = Me.UnitGroupMinimap
							Me.UnitGroupProps.World = Me.World
							Me.CurrentScriptEnittyToolbar = Me.UnitGroupProps
							Me.EntityType = 4
						Case 20
							Me.panSideBar.Controls.Add(Me.ObjectivePropsContainer)
							Me.panSideBar.Controls.Add(Me.ObjectiveToolContainer)
							Me.EntityType = 0
							Me.ObjectiveProps.World = Me.World
							Me.CurrentScriptEnittyToolbar = Me.ObjectiveProps
						Case 21
							Me.NavPointsMinimap.AddToolbox(Me.MinimapPanel)
							Me.panSideBar.Controls.Add(Me.NavPointsMinimap)
							Me.panSideBar.Controls.Add(Me.NavPointToolContainer)
							Me.CurrentMinimap = Me.NavPointsMinimap
							Me.CurrentEntityToolbar = Me.NavPointTools
							Me.EntityType = 19
						Case 22
							MyBase.Controls.Remove(Me.tbMain)
							MyBase.Controls.Add(Me.tbDebug)
					End Select
					Me.SetViewType()
					Me.LayoutChanged = True
					Me.TileDataValid = False
					Dim num3 As Integer = __Dereference((Me.EntityType * 4 + Me.EntityOperation))
					If num3 = 2 OrElse num3 = 4 Then
						Me.ResetToolbars()
					End If
					Me.RefreshMenuAndToolbarItems()
					Me.RefreshMinimap()
					Me.MinimapViewportNeedsUpdate = True
					MyBase.ResumeLayout(False)
				End If
			End If
		End Sub

		Private Sub SetDebugMode(mode As Integer)
			Select Case Me.DebugMode
				Case 500
					Me.panSideBar.Controls.Remove(Me.LoggerContainer)
					Me.panSideBar.Controls.Remove(Me.LogControlPanel)
				Case 501
					Me.panSideBar.Controls.Remove(Me.DUnitsContainer)
					Me.panSideBar.Controls.Remove(Me.UnitsControlPanel)
				Case 502
					Me.panSideBar.Controls.Remove(Me.DUnitGroupsContainer)
					Me.panSideBar.Controls.Remove(Me.UnitGroupsControlPanel)
				Case 503
					Me.panSideBar.Controls.Remove(Me.DTriggersContainer)
					Me.panSideBar.Controls.Remove(Me.DGVarsContainer)
					Me.panSideBar.Controls.Remove(Me.TriggersControlPanel)
			End Select
			Me.CurrentControlPanel = Nothing
			Me.DebugMode = mode
			Me.tbDebug.SetItemPushed(mode, True)
			Select Case mode
				Case 500
					Me.LogControlPanel.AddToolbox(Me.DControlPanel)
					Me.panSideBar.Controls.Add(Me.LogControlPanel)
					Me.panSideBar.Controls.Add(Me.LoggerContainer)
					Me.CurrentControlPanel = Me.LogControlPanel
				Case 501
					Me.UnitsControlPanel.AddToolbox(Me.DControlPanel)
					Me.panSideBar.Controls.Add(Me.UnitsControlPanel)
					Me.panSideBar.Controls.Add(Me.DUnitsContainer)
					Me.CurrentControlPanel = Me.UnitsControlPanel
				Case 502
					Me.UnitGroupsControlPanel.AddToolbox(Me.DControlPanel)
					Me.panSideBar.Controls.Add(Me.UnitGroupsControlPanel)
					Me.panSideBar.Controls.Add(Me.DUnitGroupsContainer)
					Me.CurrentControlPanel = Me.UnitGroupsControlPanel
				Case 503
					Me.TriggersControlPanel.AddToolbox(Me.DControlPanel)
					Me.panSideBar.Controls.Add(Me.TriggersControlPanel)
					Me.panSideBar.Controls.Add(Me.DGVarsContainer)
					Me.panSideBar.Controls.Add(Me.DTriggersContainer)
					Me.CurrentControlPanel = Me.TriggersControlPanel
			End Select
		End Sub

		Private Sub StartPaste()
			If Me.DragMode = 0 Then
				Dim entityType As Integer = Me.EntityType
				If entityType <> 0 Then
					If <Module>.?StartEntityPaste@GEditorWorld@@$$FQAE_NW4GEntityType@@AAUGEntityClipboard@@_N@Z(Me.World, entityType, Me.EntityClipboard, __Dereference((Me.EntityAlignMove + entityType)) <> 0) IsNot Nothing Then
						Me.DragMode = 3
						Dim ptr As __Pointer(Of $ArrayType$$$BY0BE@W4GEntityOperation@@) = Me.EntityType * 4 + Me.EntityOperation
						Dim num As Integer = __Dereference(ptr)
						If num = 2 OrElse num = 4 Then
							__Dereference(ptr) = 1
						End If
					End If
				Else If Me.EditorMode = 1 Then
					Dim mousePosition As Point = Control.MousePosition
					Dim mousePosition2 As Point = Control.MousePosition
					Dim num2 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
					Dim gRay As GRay
					Dim num3 As Single
					Dim num4 As Single
					Dim num5 As Single
					<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, mousePosition2.X, mousePosition.Y, __Dereference(num2)), num3, num4, num5)
					<Module>.GEditorWorld.StartPaste(Me.World, Me.Clipboard, <Module>.fround(num3), <Module>.fround(num5), 8191)
					Me.DragMode = 4
				End If
			End If
		End Sub

		Private Sub StartEntityPreCreate()
			Me.CancelDepressedDrag(True)
			Me.ResetToolbarsToPlace()
			If Me.DragMode = 0 Then
				Dim entityType As Integer = Me.EntityType
				Dim num As UInteger = CUInt((__Dereference((__Dereference((entityType * 4 + Me.EntityName))))))
				Dim ptr As __Pointer(Of SByte)
				If num <> 0UI Then
					ptr = num
				Else
					ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				If <Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(Me.World, entityType, ptr, __Dereference((Me.EntityAlignMove + entityType)) <> 0, __Dereference((Me.EntityRandomAngle + entityType)) <> 0) IsNot Nothing Then
					__Dereference((Me.EntityType * 4 + Me.EntityOperation)) = 2
					Me.DragMode = 1
				End If
			End If
		End Sub

		Private Sub StartEntityPreCreateNode()
			Me.CancelDepressedDrag(True)
			If Me.DragMode = 0 Then
				Select Case Me.EntityType
					Case 9
						Me.RoadTools.ResetToPlaceNode()
						Dim entityType As Integer = Me.EntityType
						Dim num As UInteger = CUInt((__Dereference((__Dereference((entityType * 4 + Me.EntityName))))))
						Dim ptr As __Pointer(Of SByte)
						If num <> 0UI Then
							ptr = num
						Else
							ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						If <Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(Me.World, 10, ptr, __Dereference((Me.EntityAlignMove + entityType)) <> 0, __Dereference((Me.EntityRandomAngle + entityType)) <> 0) IsNot Nothing Then
							Me.DragMode = 2
						End If
					Case 11
						Me.RiverTools.ResetToPlaceNode()
						Dim entityType2 As Integer = Me.EntityType
						Dim num2 As UInteger = CUInt((__Dereference((__Dereference((entityType2 * 4 + Me.EntityName))))))
						Dim ptr2 As __Pointer(Of SByte)
						If num2 <> 0UI Then
							ptr2 = num2
						Else
							ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						If <Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(Me.World, 12, ptr2, __Dereference((Me.EntityAlignMove + entityType2)) <> 0, __Dereference((Me.EntityRandomAngle + entityType2)) <> 0) IsNot Nothing Then
							Me.DragMode = 2
						End If
					Case 13
						Me.CameraCurveTools.ResetToPlaceNode()
						Dim entityType3 As Integer = Me.EntityType
						Dim num3 As UInteger = CUInt((__Dereference((__Dereference((entityType3 * 4 + Me.EntityName))))))
						Dim ptr3 As __Pointer(Of SByte)
						If num3 <> 0UI Then
							ptr3 = num3
						Else
							ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						If <Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(Me.World, 14, ptr3, __Dereference((Me.EntityAlignMove + entityType3)) <> 0, __Dereference((Me.EntityRandomAngle + entityType3)) <> 0) IsNot Nothing Then
							Me.DragMode = 2
						End If
					Case 15
						Me.PathTools.ResetToPlaceNode()
						Dim entityType4 As Integer = Me.EntityType
						Dim num4 As UInteger = CUInt((__Dereference((__Dereference((entityType4 * 4 + Me.EntityName))))))
						Dim ptr4 As __Pointer(Of SByte)
						If num4 <> 0UI Then
							ptr4 = num4
						Else
							ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						If <Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(Me.World, 16, ptr4, __Dereference((Me.EntityAlignMove + entityType4)) <> 0, __Dereference((Me.EntityRandomAngle + entityType4)) <> 0) IsNot Nothing Then
							Me.DragMode = 2
						End If
					Case 17
						Me.LocationTools.ResetToPlaceNode()
						Dim entityType5 As Integer = Me.EntityType
						Dim num5 As UInteger = CUInt((__Dereference((__Dereference((entityType5 * 4 + Me.EntityName))))))
						Dim ptr5 As __Pointer(Of SByte)
						If num5 <> 0UI Then
							ptr5 = num5
						Else
							ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						If <Module>.?StartEntityPlace@GEditorWorld@@$$FQAE_NW4GEntityType@@PBD_N2@Z(Me.World, 18, ptr5, __Dereference((Me.EntityAlignMove + entityType5)) <> 0, __Dereference((Me.EntityRandomAngle + entityType5)) <> 0) IsNot Nothing Then
							Me.DragMode = 2
						End If
				End Select
			End If
		End Sub

		Private Sub LeaveEntityMode()
			Me.CancelDepressedDrag(True)
			Me.EntityType = 0
		End Sub

		Private Sub SetViewType()
			Dim num As Integer = 0
			If(__Dereference((<Module>.Options + 68)) And 1) <> 0 Then
				num = 34
			End If
			If(__Dereference((<Module>.Options + 68)) And 2) <> 0 Then
				num = num Or 1
			End If
			If __Dereference((<Module>.Options + 72)) = 1 Then
				num = num Or 8
			Else If __Dereference((<Module>.Options + 72)) = 2 Then
				num = num Or 4
			End If
			If __Dereference((<Module>.Options + 78)) <> 0 Then
				num = num Or 128
			End If
			Dim editorMode As Integer = Me.EditorMode
			If editorMode = 2 Then
				Dim num2 As Integer = Me.propPaintType
				If num2 = 13 OrElse num2 = 14 Then
					num = num Or 32
				End If
			End If
			If editorMode = 15 Then
				num = num Or 32
			End If
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				<Module>.GWorld.SetTerrainViewType(world, num)
			End If
		End Sub

		Private Sub InitUI()
			If <Module>.Scene IsNot Nothing Then
				Dim gHandle<11> As GHandle<11>
				Dim num As Integer = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, gHandle<11>, 0, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 256)))
				cpblk(Me.BrushCursor, num, 4)
				Dim gHandle<11>2 As GHandle<11>
				Dim num2 As Integer = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, gHandle<11>2, 0, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 256)))
				cpblk(Me.ParcelSelection, num2, 4)
			End If
			Me.toolboxOptions_OptionsChanged()
			Dim editorMode As Integer = Me.EditorMode
			Me.EditorMode = 1
			Me.VertexTools.SelectionType = 0
			Me.VertexTools.SetBrushSize1(Me.BrushSize)
			Me.VertexTools.SetBrushSize2(0)
			Me.VertexTools.SetBrushPressure(Me.BrushPressure)
			Me.VertexTools.AdditiveMode = (__Dereference(CType((Me.Terraformer + 8 / __SizeOf(GTerraformer)), __Pointer(Of Byte))) <> 0)
			Me.VertexTools.LockObjectHeights = (__Dereference(CType((Me.Terraformer + 9 / __SizeOf(GTerraformer)), __Pointer(Of Byte))) <> 0)
			Me.EditorMode = 2
			Me.TerrainTools.SetBrushSize1(Me.BrushSize)
			Me.TerrainTools.SetBrushSize2(0)
			Me.TerrainTools.SetBrushPressure(Me.BrushPressure)
			Me.EditorMode = editorMode
			Me.VertexTools.BrushType = Me.propBrushType
			Me.VertexTools.FalloffType = Me.VertexFalloffType
			Me.TerrainTools.PaintType = Me.propPaintType
			Me.VertexTools.InvertEnable = False
			Me.TerrainTools.FillEnable = False
			Me.PlayerTools.InitPlayersGrid(CType(Me.World, __Pointer(Of GWorld)))
			<Module>.GEditorWorld.ClearParcelSelection(Me.World)
		End Sub

		Private Sub UpdateBrushSliders()
			Dim editorMode As Integer = Me.EditorMode
			If editorMode = 1 Then
				Me.VertexTools.SetBrushSize1(Me.BrushSize)
				Me.VertexTools.SetBrushSize2(Me.BrushSize2)
				Me.VertexTools.SetBrushPressure(Me.BrushPressure)
				Me.VertexTools.SetBrushHeight(Me.BrushHeight)
			Else If editorMode = 2 Then
				Me.TerrainTools.SetBrushSize1(Me.BrushSize)
				Me.TerrainTools.SetBrushSize2(Me.BrushSize2)
				Me.TerrainTools.SetBrushPressure(Me.BrushPressure)
			End If
		End Sub

		Private Sub SetAffectedLayer(value As Integer)
			__Dereference(CType((Me.Terraformer + 12 / __SizeOf(GTerraformer)), __Pointer(Of Integer))) = value
		End Sub

		Private Sub ResetToolbars()
			Dim currentEntityToolbar As ToolboxEntities = Me.CurrentEntityToolbar
			If currentEntityToolbar IsNot Nothing Then
				currentEntityToolbar.ResetToMove()
			End If
		End Sub

		Private Sub ResetToolbarsToPlace()
			Dim currentEntityToolbar As ToolboxEntities = Me.CurrentEntityToolbar
			If currentEntityToolbar IsNot Nothing Then
				currentEntityToolbar.ResetToPlace()
			End If
		End Sub

		Private Sub CompleteDepressedDrag(m_x As Integer, m_y As Integer)
			Dim dragMode As Integer = Me.DragMode
			If dragMode <> 0 AndAlso dragMode < 6 Then
				Select Case dragMode
					Case 1, 2
						Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
						Dim gRay As GRay
						If <Module>.GEditorWorld.CompleteEntityPlace(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56)))) >= 0 Then
							Dim entityType As Integer = Me.EntityType
							Dim ptr As __Pointer(Of $ArrayType$$$BY0BE@W4GEntityOperation@@) = entityType * 4 + Me.EntityOperation
							If __Dereference(ptr) = 2 AndAlso (entityType = 9 OrElse entityType = 11 OrElse entityType = 13 OrElse entityType = 15 OrElse entityType = 17) Then
								__Dereference(ptr) = 4
							End If
						End If
					Case 3
						<Module>.GEditorWorld.CompleteEntityPaste(Me.World)
					Case 4
						<Module>.GEditorWorld.CompletePaste(Me.World, Me.Clipboard)
						Me.propBrushType = 0
						Me.VertexTools.EmulatePush(0)
						Me.VertexTools.EmulateUp(0)
					Case 5
						<Module>.GEditorWorld.AddPolySelectPoint(Me.World)
						Return
				End Select
				Me.DragMode = 0
				Me.RefreshMenuAndToolbarItems()
				If Me.EntityType = 3 Then
					Me.MinimapUnitsNeedUpdate = True
				Else
					Me.RefreshMinimap()
				End If
			End If
		End Sub

		Private Function CancelDepressedDrag(<MarshalAs(UnmanagedType.U1)> reset As Boolean) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim dragMode As Integer = Me.DragMode
			If dragMode <> 0 AndAlso dragMode < 6 Then
				Select Case dragMode
					Case 1, 2
						<Module>.GEditorWorld.CancelEntityPlace(Me.World)
						If reset Then
							__Dereference((Me.EntityType * 4 + Me.EntityOperation)) = 1
							Me.ResetToolbars()
						End If
						Me.DragMode = 0
						Me.RefreshMenuAndToolbarItems()
						Return True
					Case 3
						<Module>.GEditorWorld.CancelEntityPaste(Me.World)
						Me.DragMode = 0
						Me.RefreshMenuAndToolbarItems()
						Return True
					Case 4
						<Module>.GEditorWorld.CancelPaste(Me.World, Me.Clipboard)
						Me.propBrushType = 0
						Me.DragMode = 0
						Return True
					Case 5
						<Module>.GEditorWorld.FinishTerraforming(Me.World)
						Me.SelectionActive = True
						Me.VertexTools.InvertEnable = True
						Me.TerrainTools.FillEnable = True
						Me.DragMode = 0
						Return True
				End Select
			End If
			Me.RefreshMenuAndToolbarItems()
			Return False
		End Function

		Private Sub CompletePressedDrag(m_x As Integer, m_y As Integer)
			Dim dragMode As Integer = Me.DragMode
			If dragMode <> 0 AndAlso dragMode >= 6 Then
				Dim num As Single
				Dim num3 As Single
				If Me.GameDebugWorld IsNot Nothing Then
					Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
					Dim gRay As GRay
					Dim num2 As Single
					<Module>.GWorld.GetTarget(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))), num, num2, num3)
				Else
					Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
					Dim num2 As Single
					Dim gRay2 As GRay
					<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay2, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))), num, num2, num3)
				End If
				Select Case Me.DragMode
					Case 7
						<Module>.GEditorWorld.FinishTerraforming(Me.World)
						Dim num4 As Integer = __Dereference(CType(Me.Terraformer, __Pointer(Of Integer)))
						If num4 = 14 Then
							Me.TileDataValid = False
							Me.UpdateLayerUsage(CInt((CDec(num))), CInt((CDec(num3))))
						Else If num4 >= 20 Then
							Me.SelectionActive = True
							Me.VertexTools.InvertEnable = True
							Me.TerrainTools.FillEnable = True
						End If
					Case 9
						Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
						Dim gRay3 As GRay
						<Module>.GEditorWorld.CompleteEntityMove(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay3, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
						Dim scriptEditorFormInstance As ScriptEditorForm = Me.ScriptEditorFormInstance
						If scriptEditorFormInstance IsNot Nothing Then
							scriptEditorFormInstance.EditorsChanged()
						End If
					Case 10
						<Module>.GEditorWorld.CompleteEntityLift(Me.World)
					Case 11
						If Me.EntityType <> 7 Then
							<Module>.GEditorWorld.CompleteEntityRotate(Me.World)
						End If
					Case 12
						<Module>.GEditorWorld.CompleteEntityPointRotate(Me.World)
					Case 13
						<Module>.GEditorWorld.CompleteEntityTilt(Me.World)
					Case 14, 15
						<Module>.GWorld.ClearBoxSelection(Me.World)
						Dim num5 As Integer = If((Me.DragMode = 15), 5, 16)
						Dim num6 As Integer = __Dereference(CType(Me.World, __Pointer(Of Integer))) + 20
						Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
						Dim gPyramid As GPyramid
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GPyramid modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32), Me.World, Me.EntityType, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), iViewport, gPyramid, Me.DragMX, Me.DragMY, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 60))), num5, __Dereference(num6))
						Dim currentScriptEnittyToolbar As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
						If currentScriptEnittyToolbar IsNot Nothing Then
							currentScriptEnittyToolbar.UpdateHilighting()
						End If
					Case 16
						<Module>.GEditorWorld.CompleteEntityScale(Me.World)
					Case 17
						Select Case Me.EntityType
							Case 9
								Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
								Dim gRay4 As GRay
								<Module>.GEditorWorld.CompleteEntityPlaceRoadNode(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay4, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
							Case 11
								Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
								Dim gRay5 As GRay
								<Module>.GEditorWorld.CompleteEntityPlaceRiverNode(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay5, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
							Case 13
								Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
								Dim gRay6 As GRay
								<Module>.GEditorWorld.CompleteEntityPlaceCameraCurveNode(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay6, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
							Case 15
								Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
								Dim gRay7 As GRay
								<Module>.GEditorWorld.CompleteEntityPlacePathNode(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay7, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
							Case 17
								Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
								Dim gRay8 As GRay
								<Module>.GEditorWorld.CompleteEntityPlaceLocationVertex(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay8, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
						End Select
					Case 18, 19, 20, 21, 27, 28
						<Module>.ShowCursor(1)
					Case 24
						Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
						Dim gRay9 As GRay
						Dim num7 As Integer = <Module>.GWorld.GetTargetWirePoint(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay9, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
						Dim world As __Pointer(Of GEditorWorld) = Me.World
						Dim num8 As Integer = __Dereference(CType((world + 3104 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
						If num8 >= 0 AndAlso num7 >= 0 AndAlso num7 <> num8 Then
							<Module>.GWorld.CreateWire(world, num8, num7, 0.35F, 0.025F)
							<Module>.GWorld.SelectWirePoint(Me.World, num7, 48)
						End If
					Case 25
						Me.SectorSelectionNeedsUpdate = True
				End Select
				Dim dragMode2 As Integer = Me.DragMode
				If dragMode2 <> 19 AndAlso dragMode2 <> 18 AndAlso Me.EntityType <> 3 Then
					Me.RefreshMinimap()
				End If
				dragMode = Me.DragMode
				If dragMode <> 19 AndAlso dragMode <> 18 AndAlso Me.EntityType = 3 Then
					Me.MinimapUnitsNeedUpdate = True
				End If
				Me.panMainViewport.Capture = False
				Me.DragMode = 0
				Me.RefreshMenuAndToolbarItems()
			End If
		End Sub

		Private Sub RefreshTerraformer()
			If Me.BrushHeight IsNot Nothing Then
				Dim brushHeight As __Pointer(Of Single) = Me.BrushHeight
				__Dereference(CType((Me.Terraformer + 48 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = __Dereference(brushHeight)
			End If
			If Me.BrushPressure IsNot Nothing Then
				Dim brushPressure As __Pointer(Of Single) = Me.BrushPressure
				__Dereference(CType((Me.Terraformer + 44 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = __Dereference(brushPressure)
			End If
			If Me.BrushSize IsNot Nothing Then
				Dim brushSize As __Pointer(Of Single) = Me.BrushSize
				__Dereference(CType((Me.Terraformer + 32 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = __Dereference(brushSize)
			End If
			If Me.BrushSize2 IsNot Nothing Then
				Dim brushSize2 As __Pointer(Of Single) = Me.BrushSize2
				__Dereference(CType((Me.Terraformer + 40 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = __Dereference(brushSize2)
			End If
			Dim terraformer As __Pointer(Of GTerraformer) = Me.Terraformer
			__Dereference(CType((terraformer + 36 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = __Dereference(CType((terraformer + 40 / __SizeOf(GTerraformer)), __Pointer(Of Single))) * __Dereference(CType((terraformer + 32 / __SizeOf(GTerraformer)), __Pointer(Of Single))) * 0.01F
			Dim editorMode As Integer = Me.EditorMode
			If editorMode <> 1 Then
				If editorMode = 2 Then
					__Dereference(CType(Me.Terraformer, __Pointer(Of Integer))) = Me.propPaintType
				End If
			Else
				__Dereference(CType(Me.Terraformer, __Pointer(Of Integer))) = Me.propBrushType
			End If
			Dim terraformer2 As __Pointer(Of GTerraformer) = Me.Terraformer
			If __Dereference(CType(terraformer2, __Pointer(Of Integer))) < 20 Then
				__Dereference(CType((terraformer2 + 4 / __SizeOf(GTerraformer)), __Pointer(Of Integer))) = Me.VertexFalloffType
			Else
				__Dereference(CType((terraformer2 + 4 / __SizeOf(GTerraformer)), __Pointer(Of Integer))) = Me.SelectionFalloffType
			End If
		End Sub

		Private Sub ResetTerrainTool()
			Dim num As Integer = Me.propPaintType
			If num = 15 OrElse num = 16 OrElse num = 17 Then
				Me.TerrainTools.EmulatePush(0)
				Me.TerrainTools.EmulateUp(0)
			End If
		End Sub

		Private Sub EnableMenuAndToolbarItems(<MarshalAs(UnmanagedType.U1)> enable As Boolean)
			Me.menuFileSave.Enabled = enable
			Me.menuFileSaveAs.Enabled = enable
			Me.menuEdit.Enabled = enable
			Me.menuToolsScriptEditor.Enabled = enable
			Me.tbMain.SetItemEnable(202, enable)
			Me.tbMain.SetItemEnable(203, enable)
			Me.tbMain.SetItemEnable(204, enable)
			Me.tbMain.SetItemEnable(205, enable)
			Me.tbMain.SetItemEnable(206, enable)
			Me.tbMain.SetItemEnable(207, enable)
			Me.tbMain.SetItemEnable(208, enable)
			Me.tbMain.SetItemEnable(209, enable)
			Me.tbMain.SetItemEnable(210, enable)
			Me.tbMain.SetItemEnable(211, enable)
			Me.menuModeVertex.Enabled = enable
			Me.menuModePaint.Enabled = enable
			Me.menuModeRoad.Enabled = enable
			Me.menuModeDecal.Enabled = enable
			Me.menuModeLake.Enabled = enable
			Me.menuModeRiver.Enabled = enable
			Me.menuModeCameraCurve.Enabled = enable
			Me.menuModeDoodad.Enabled = enable
			Me.menuModeWire.Enabled = enable
			Me.menuModeBuilding.Enabled = enable
			Me.menuModeUnit.Enabled = enable
			Me.menuModeAmbient.Enabled = enable
			Me.menuModeEffect.Enabled = enable
			Me.menuModePaths.Enabled = enable
			Me.menuModeLocations.Enabled = enable
			Me.menuModeUnitGroup.Enabled = enable
			Me.menuModeSectors.Enabled = enable
			Me.tbMain.SetGroupEnable(1, enable)
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub RefreshMenuAndToolbarItems()
			Dim enabled As Byte = If((Me.EditorMode <> 22), 1, 0)
			Me.menuToolsScriptEditor.Enabled = (enabled <> 0)
			If Me.World IsNot Nothing Then
				Dim gBaseString<char> As GBaseString<char> = 0
				__Dereference((gBaseString<char> + 4)) = 0
				Try
					Dim mapFileName As __Pointer(Of GBaseString<char>) = Me.MapFileName
					If(If((__Dereference(CType((mapFileName + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0), 1, 0)) <> 0 Then
						<Module>.GBaseString<char>.=(gBaseString<char>, CType((AddressOf <Module>.??_C@_08OBKBFOJH@Untitled?$AA@), __Pointer(Of SByte)))
					Else
						<Module>.GBaseString<char>.=(gBaseString<char>, mapFileName)
					End If
					Dim world As __Pointer(Of GEditorWorld) = Me.World
					Dim num As Integer = __Dereference(CType((world + 2544 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
					Dim num2 As Integer = __Dereference(CType((world + 2540 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
					Dim num3 As Integer = __Dereference(CType((world + 2544 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
					Dim num4 As Integer = __Dereference(CType((world + 2540 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>2, CType((AddressOf <Module>.??_C@_0BC@PHOIDCLM@?5?$FL?5?$CFdx?$CFd?0?5?$CFdx?$CFd?5?$FN?$AA@), __Pointer(Of SByte)), CInt((CDec((CSng(num4) * __Dereference((<Module>.Measures + 4)))))), CInt((CDec((CSng(num3) * __Dereference((<Module>.Measures + 4)))))), CInt((CDec((CSng((num2 - 32)) * __Dereference((<Module>.Measures + 4)))))), CInt((CDec((CSng((num - 32)) * __Dereference((<Module>.Measures + 4)))))))
					Try
						Dim num5 As Integer = __Dereference(CType((ptr + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer)))
						If num5 <> 0 Then
							gBaseString<char> = <Module>.realloc(gBaseString<char>, CUInt((__Dereference((gBaseString<char> + 4)) + num5 + 1)))
							cpblk(__Dereference((gBaseString<char> + 4)) + gBaseString<char>, __Dereference(CType(ptr, __Pointer(Of Integer))), __Dereference(CType((ptr + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) + 1)
							__Dereference((gBaseString<char> + 4)) = __Dereference(CType((ptr + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) + __Dereference((gBaseString<char> + 4))
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
					End If
					If <Module>.GEditorWorld.IsChanged(Me.World) IsNot Nothing Then
						<Module>.GBaseString<char>.+=(gBaseString<char>, CType((AddressOf <Module>.??_C@_02FHJIKMCF@?5?$CK?$AA@), __Pointer(Of SByte)))
					End If
					Dim ptr2 As __Pointer(Of SByte) = CType((AddressOf <Module>.??_C@_0N@EPOCAHEK@?5?9?5Workshop?$JJ?$AA@), __Pointer(Of SByte))
					Dim b As SByte
					Do
						b = __Dereference(CType(ptr2, __Pointer(Of SByte)))
						ptr2 += 1 / __SizeOf(SByte)
					Loop While b <> 0
					Dim num6 As Integer = ptr2 - <Module>.??_C@_0N@EPOCAHEK@?5?9?5Workshop?$JJ?$AA@ / __SizeOf(SByte) - 1 / __SizeOf(SByte)
					If num6 <> 0 Then
						Dim num7 As UInteger = CUInt((num6 + __Dereference((gBaseString<char> + 4))))
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num7 + 1UI)
						cpblk(__Dereference((gBaseString<char> + 4)) + gBaseString<char>, <Module>.??_C@_0N@EPOCAHEK@?5?9?5Workshop?$JJ?$AA@, num6 + 1)
						__Dereference((gBaseString<char> + 4)) = CInt(num7)
					End If
					Dim value As __Pointer(Of SByte)
					If gBaseString<char> IsNot Nothing Then
						value = gBaseString<char>
					Else
						value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					If Me.Text <> New String(CType(value, __Pointer(Of SByte))) Then
						Dim value2 As __Pointer(Of SByte)
						If gBaseString<char> IsNot Nothing Then
							value2 = gBaseString<char>
						Else
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.Text = New String(CType(value2, __Pointer(Of SByte)))
					End If
					Dim entityType As Integer
					Dim num8 As Integer
					If Me.EditorMode <> 1 OrElse <Module>.GEditorWorld.SelectionExists(Me.World) Is Nothing Then
						entityType = Me.EntityType
						If entityType <> 0 Then
							world = Me.World
							If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, entityType, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) AndAlso Me.EditorMode <> 19 Then
								GoTo IL_226
							End If
						End If
						num8 = 0
						GoTo IL_22E
					End If
					IL_226:
					num8 = 1
					IL_22E:
					Dim flag As Boolean = CByte(num8) <> 0
					Me.menuEditCopy.Enabled = flag
					Me.tbMain.SetItemEnable(204, flag)
					entityType = Me.EntityType
					Dim num9 As Integer
					If entityType <> 0 Then
						world = Me.World
						If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, entityType, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) AndAlso Me.EditorMode <> 19 Then
							num9 = 1
							GoTo IL_284
						End If
					End If
					num9 = 0
					IL_284:
					Dim flag2 As Boolean = CByte(num9) <> 0
					Me.menuEditCut.Enabled = flag2
					Me.tbMain.SetItemEnable(203, flag2)
					Dim editorMode As Integer = Me.EditorMode
					Dim num10 As Integer
					If editorMode <> 1 OrElse Me.Clipboard Is Nothing Then
						entityType = Me.EntityType
						If entityType = 0 OrElse <Module>.?HasEntity@GEntityClipboard@@$$FQAE_NW4GEntityType@@@Z(Me.EntityClipboard, entityType) Is Nothing OrElse editorMode = 19 Then
							num10 = 0
							GoTo IL_2E3
						End If
					End If
					num10 = 1
					IL_2E3:
					Dim flag3 As Boolean = CByte(num10) <> 0
					Me.menuEditPaste.Enabled = flag3
					Dim enabled2 As Byte
					If Me.EditorMode = 1 AndAlso Me.Clipboard IsNot Nothing Then
						enabled2 = 1
					Else
						enabled2 = 0
					End If
					Me.menuEditControlPaste.Enabled = (enabled2 <> 0)
					Me.tbMain.SetItemEnable(205, flag3)
					entityType = Me.EntityType
					If entityType <> 0 Then
						world = Me.World
						If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, entityType, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) AndAlso Me.EditorMode <> 19 Then
							GoTo IL_370
						End If
					End If
					Dim num11 As Integer
					If Me.EditorMode <> 8 OrElse __Dereference(CType((Me.World + 3104 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) < 0 Then
						num11 = 0
						GoTo IL_378
					End If
					IL_370:
					num11 = 1
					IL_378:
					Dim flag4 As Boolean = CByte(num11) <> 0
					Me.menuEditDelete.Enabled = flag4
					Me.tbMain.SetItemEnable(206, flag4)
					Dim flag5 As Boolean = <Module>.GEditorWorld.IsUndoAvail(Me.World) IsNot Nothing
					Me.menuEditUndo.Enabled = flag5
					Me.tbMain.SetItemEnable(207, flag5)
					Dim flag6 As Boolean = <Module>.GEditorWorld.IsRedoAvail(Me.World) IsNot Nothing
					Me.menuEditRedo.Enabled = flag6
					Me.tbMain.SetItemEnable(208, flag6)
					Me.VertexTools.InvertEnable = (<Module>.GEditorWorld.SelectionExists(Me.World) IsNot Nothing)
					Me.TerrainTools.FillEnable = (<Module>.GEditorWorld.SelectionExists(Me.World) IsNot Nothing)
					Dim currentScriptEnittyToolbar As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
					If currentScriptEnittyToolbar IsNot Nothing Then
						currentScriptEnittyToolbar.RefreshEntityList()
					End If
					Dim scriptEditorFormInstance As ScriptEditorForm = Me.ScriptEditorFormInstance
					If scriptEditorFormInstance IsNot Nothing Then
						scriptEditorFormInstance.EditorsChanged()
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			End If
		End Sub

		Private Sub RegisterScriptRefreshCallback()
			__Dereference(CType((Me.World + 5080 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = <Module>.__unep@?ScriptEditorNotifier@NWorkshop@@$$FYAXXZ
		End Sub

		Private Sub VisualizeBrush(x As Single, z As Single)
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(Me.BrushCursor), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 264)))
			Dim brushPressure As __Pointer(Of Single) = Me.BrushPressure
			Dim color As Color = Color.FromArgb(4259648)
			If brushPressure IsNot Nothing Then
				If __Dereference(brushPressure) < 75F Then
					If __Dereference(brushPressure) < 50F Then
						If __Dereference(brushPressure) < 25F Then
							color = Color.FromArgb(40, CInt((CDec((__Dereference(brushPressure) * 0.04F * 215F + 40F)))), 255)
						Else
							color = Color.FromArgb(40, 255, CInt((CDec(((1F - (__Dereference(brushPressure) - 25F) * 0.04F) * 215F + 40F)))))
						End If
					Else
						color = Color.FromArgb(CInt((CDec(((__Dereference(brushPressure) - 50F) * 0.04F * 215F + 40F)))), 255, 40)
					End If
				Else
					color = Color.FromArgb(255, CInt((CDec(((1F - (__Dereference(brushPressure) - 75F) * 0.04F) * 215F + 40F)))), 40)
				End If
			End If
			Dim brushSize As __Pointer(Of Single) = Me.BrushSize
			If brushSize IsNot Nothing Then
				Dim gPoint As GPoint2 = x
				__Dereference((gPoint + 4)) = z
				Dim num As Integer = __Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 296
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint2,System.Single,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.BrushCursor), gPoint, __Dereference(brushSize), color.ToArgb(), __Dereference(num))
			End If
			Dim brushSize2 As __Pointer(Of Single) = Me.BrushSize2
			If brushSize2 IsNot Nothing Then
				Dim gPoint2 As GPoint2 = x
				__Dereference((gPoint2 + 4)) = z
				Dim num2 As Integer = __Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 296
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint2,System.Single,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.BrushCursor), gPoint2, __Dereference(brushSize) * __Dereference(brushSize2) * 0.01F, color.ToArgb(), __Dereference(num2))
			End If
			Dim brushHeight As __Pointer(Of Single) = Me.BrushHeight
			If brushHeight IsNot Nothing Then
				Dim num3 As Single = __Dereference(brushHeight)
				Dim gPoint3 As GPoint3 = x
				__Dereference((gPoint3 + 4)) = num3
				__Dereference((gPoint3 + 8)) = z
				Dim num4 As Single = <Module>.GWorld.GetHeight(Me.World, x, z)
				Dim gPoint4 As GPoint3 = x
				__Dereference((gPoint4 + 4)) = num4
				__Dereference((gPoint4 + 8)) = z
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.BrushCursor), gPoint4, gPoint3, 4259648, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 284)))
				Dim num5 As Single = __Dereference(brushHeight)
				Dim gPoint5 As GPoint3 = x
				__Dereference((gPoint5 + 4)) = num5
				__Dereference((gPoint5 + 8)) = z
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.BrushCursor), gPoint5, 16777024, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 276)))
				Dim num6 As Single = <Module>.GWorld.GetHeight(Me.World, x, z)
				Dim gPoint6 As GPoint3 = x
				__Dereference((gPoint6 + 4)) = num6
				__Dereference((gPoint6 + 8)) = z
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.BrushCursor), gPoint6, 16777024, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 276)))
			End If
		End Sub

		Private Sub RearrangeToolbars()
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = Me.panSideBar.Height
			If num2 <> 0 Then
				Dim num3 As Integer = 0
				Me.Rearranging = True
				For i As Integer = 0 To Me.panSideBar.Controls.Count - 1
					Try
						Dim toolboxContainer As ToolboxContainer = TryCast(Me.panSideBar.Controls(i), ToolboxContainer)
						If toolboxContainer IsNot Nothing Then
							If toolboxContainer.Autosize AndAlso toolboxContainer.Open Then
								num3 += 1
							End If
							num2 -= toolboxContainer.MinHeight
						End If
						GoTo IL_CD
					End Try
					Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
					IL_CD:
				Next
				Dim num4 As Integer = 0
				If num3 > 0 Then
					num4 = num2 / num3
				End If
				Me.panSideBar.SuspendLayout()
				Dim systemMetrics As Integer = <Module>.GetSystemMetrics(2)
				If num2 < 0 Then
					Me.panSideBar.ViewHeight = Me.panSideBar.Height - num2
				Else
					Me.panSideBar.ViewHeight = Me.panSideBar.Height
				End If
				If num2 < 0 Then
					If Not Me.ScrollbarOn Then
						Me.ScrollbarOn = True
						Me.splitMain.MinSize = systemMetrics + 256
						Dim size As Size = Me.panSideBar.Size
						Dim size2 As Size = New Size(Me.panSideBar.Size.Width + systemMetrics, size.Height)
						Me.panSideBar.Size = size2
						Me.panSideBar.ShowScrollBar()
					End If
				Else If Me.ScrollbarOn Then
					Me.ScrollbarOn = False
					Me.splitMain.MinSize = 256
					Dim size3 As Size = Me.panSideBar.Size
					Dim size4 As Size = New Size(Me.panSideBar.Size.Width - systemMetrics, size3.Height)
					Me.panSideBar.Size = size4
					Me.panSideBar.HideScrollBar()
				End If
				If num4 < 0 Then
					num4 = 0
				End If
				For j As Integer = 0 To Me.panSideBar.Controls.Count - 1
					Try
						Dim toolboxContainer2 As ToolboxContainer = TryCast(Me.panSideBar.Controls(j), ToolboxContainer)
						If toolboxContainer2 IsNot Nothing AndAlso toolboxContainer2.Autosize AndAlso toolboxContainer2.Open Then
							toolboxContainer2.Inflate(num4)
						End If
						GoTo IL_2AC
					End Try
					Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
					IL_2AC:
				Next
				Me.panSideBar.ResumeLayout()
				Me.Rearranging = False
				Me.OldHeight = Me.panSideBar.Height
				Dim width As Integer
				If Me.ScrollbarOn Then
					width = Me.panSideBar.Size.Width - systemMetrics
				Else
					width = Me.panSideBar.Size.Width
				End If
				Dim editorMode As Integer = Me.EditorMode
				If editorMode = 2 Then
					Dim size5 As Size = New Size(width, Me.TerrainTools.Size.Height)
					Me.TerrainTools.Size = size5
				Else If editorMode = 1 Then
					Dim size6 As Size = New Size(width, Me.VertexTools.Size.Height)
					Me.VertexTools.Size = size6
				End If
			End If
		End Sub

		Private Sub UpdateLayerUsage(x As Integer, z As Integer)
			Dim num As Integer = x / 16
			Dim num2 As Integer = z / 16
			If Not Me.TileDataValid OrElse num <> Me.TileParcelX OrElse num2 <> Me.TileParcelZ Then
				Me.TileParcelX = num
				Me.TileParcelZ = num2
				Me.TileDataValid = True
				Me.TerrainFilePicker.UpdateLayerUsage(<Module>.GEditorWorld.GetLayerUsageFlags(Me.World, num, num2))
			End If
		End Sub

		Private Sub RefreshMinimapCameraGizmo()
			Dim currentMinimap As ToolboxContainer = Me.CurrentMinimap
			If currentMinimap IsNot Nothing AndAlso currentMinimap.Open Then
				Dim array As PointF() = New PointF(199) {}
				Dim num As Single = CSng(Me.panMainViewport.Size.Width) * 0.02F
				Dim num2 As Single = CSng(Me.panMainViewport.Size.Height) * 0.02F
				Dim num3 As Integer = 0
				Do
					Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
					Dim num4 As Single = CSng(num3)
					Dim num5 As Single = num4 * num2
					Dim gRay As GRay
					Dim x As Single
					Dim num6 As Single
					Dim y As Single
					<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay, 0, CInt((CDec(num5))), __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))), x, num6, y)
					array(num3).X = x
					array(num3).Y = y
					Dim size As Size = Me.panMainViewport.Size
					Dim num7 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
					Dim num8 As Single = num4 * num
					Dim gRay2 As GRay
					<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay2, CInt((CDec(num8))), size.Height, __Dereference(num7)), x, num6, y)
					Dim num9 As Integer = num3 + 100 - 50
					array(num9).X = x
					array(num9).Y = y
					Dim size2 As Size = Me.panMainViewport.Size
					Dim size3 As Size = Me.panMainViewport.Size
					Dim num10 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
					Dim gRay3 As GRay
					<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay3, size3.Width, CInt((CDec((CSng(size2.Height) - num5)))), __Dereference(num10)), x, num6, y)
					array(num3 + 100).X = x
					array(num3 + 100).Y = y
					Dim size4 As Size = Me.panMainViewport.Size
					Dim num11 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
					Dim gRay4 As GRay
					<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay4, CInt((CDec((CSng(size4.Width) - num8)))), 0, __Dereference(num11)), x, num6, y)
					Dim num12 As Integer = num3 + 100 + 50
					array(num12).X = x
					array(num12).Y = y
					num3 += 1
				Loop While num3 < 50
				Me.MinimapPanel.RefreshViewport(array)
				Me.MinimapPanel.DrawMap()
			End If
		End Sub

		Private Sub RefreshMinimap()
			Dim currentMinimap As ToolboxContainer = Me.CurrentMinimap
			If currentMinimap IsNot Nothing AndAlso currentMinimap.Open Then
				Me.MinimapPanel.RefreshMap(False)
				Me.RefreshMinimapCameraGizmo()
			End If
		End Sub

		Private Sub InitMinimap()
			Me.MinimapPanel.World = Me.World
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			Me.MinimapPanel.SetScene(<Module>.Scene, __Dereference(CType((world + 2540 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))), __Dereference(CType((world + 2544 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))))
			Me.MinimapNeedsRefresh()
		End Sub

		Private Sub InitScriptTools()
			Me.SectorTools.World = Me.World
			Me.CameraCurveProps.World = Me.World
			Me.PathProps.World = Me.World
			Me.LocationProps.World = Me.World
			Me.UnitGroupProps.World = Me.World
		End Sub

		Private Sub RefreshUnitsOnMinimap()
			Me.MinimapPanel.RefreshUnits()
			Me.RefreshMinimapCameraGizmo()
		End Sub

		Private Sub RefreshSectorSelection()
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(Me.ParcelSelection), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 264)))
			Dim num As Integer
			Dim num2 As Integer
			Dim num3 As Integer
			Dim num4 As Integer
			If <Module>.GEditorWorld.GetParcelSelection(Me.World, num, num2, num3, num4) IsNot Nothing Then
				Dim num5 As Integer = num
				If num < num3 Then
					Do
						If num5 Mod 2 <> 0 Then
							Dim num6 As Single = CSng((num5 + 1))
							Dim gPoint As GPoint3 = num6
							__Dereference((gPoint + 4)) = 58F
							Dim num7 As Single = CSng(num2)
							__Dereference((gPoint + 8)) = num7
							Dim num8 As Single = CSng(num5)
							Dim gPoint2 As GPoint3 = num8
							__Dereference((gPoint2 + 4)) = 58F
							__Dereference((gPoint2 + 8)) = num7
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.ParcelSelection), gPoint2, gPoint, 4210943, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 284)))
							Dim gPoint3 As GPoint3 = num6
							__Dereference((gPoint3 + 4)) = 58F
							Dim num9 As Single = CSng(num4)
							__Dereference((gPoint3 + 8)) = num9
							Dim gPoint4 As GPoint3 = num8
							__Dereference((gPoint4 + 4)) = 58F
							__Dereference((gPoint4 + 8)) = num9
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.ParcelSelection), gPoint4, gPoint3, 4210943, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 284)))
						End If
						num5 += 1
					Loop While num5 < num3
				End If
				Dim num10 As Integer = num2
				If num2 < num4 Then
					Do
						If num10 Mod 2 <> 0 Then
							Dim num11 As Single = CSng(num)
							Dim gPoint5 As GPoint3 = num11
							__Dereference((gPoint5 + 4)) = 58F
							Dim num12 As Single = CSng((num10 + 1))
							__Dereference((gPoint5 + 8)) = num12
							Dim gPoint6 As GPoint3 = num11
							__Dereference((gPoint6 + 4)) = 58F
							Dim num13 As Single = CSng(num10)
							__Dereference((gPoint6 + 8)) = num13
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.ParcelSelection), gPoint6, gPoint5, 4210943, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 284)))
							Dim num14 As Single = CSng(num3)
							Dim gPoint7 As GPoint3 = num14
							__Dereference((gPoint7 + 4)) = 58F
							__Dereference((gPoint7 + 8)) = num12
							Dim gPoint8 As GPoint3 = num14
							__Dereference((gPoint8 + 4)) = 58F
							__Dereference((gPoint8 + 8)) = num13
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.Scene, __Dereference(Me.ParcelSelection), gPoint8, gPoint7, 4210943, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 284)))
						End If
						num10 += 1
					Loop While num10 < num4
				End If
			End If
		End Sub

		Private Sub RunMap()
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			If Me.World IsNot Nothing Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, <Module>.GFileSystem.GetHomePath(<Module>.FS))
				Dim gBaseString<char>2 As GBaseString<char>
				Try
					<Module>.GBaseString<char>.+(ptr, AddressOf gBaseString<char>2, CType((AddressOf <Module>.??_C@_0BA@FGELNJIA@$$TestRun$$?4map?$AA@), __Pointer(Of SByte)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				Dim gBaseString<char>4 As GBaseString<char>
				Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
					Dim gBaseString<char>3 As GBaseString<char>
					Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, <Module>.GFileSystem.GetHomePath(<Module>.FS))
					Try
						<Module>.GBaseString<char>.+(ptr2, AddressOf gBaseString<char>4, CType((AddressOf <Module>.??_C@_0BA@JEAEPEAH@$$TestRun$$?4ma2?$AA@), __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
						Throw
					End Try
					Try
						If gBaseString<char>3 IsNot Nothing Then
							<Module>.free(gBaseString<char>3)
							gBaseString<char>3 = 0
						End If
						Dim fileInfo As FileInfo = New FileInfo(Application.ExecutablePath)
						Dim ptr3 As __Pointer(Of SByte)
						If gBaseString<char>2 IsNot Nothing Then
							ptr3 = gBaseString<char>2
						Else
							ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Dim ptr4 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenWrite(<Module>.FS, ptr3, Nothing)
						Dim ptr5 As __Pointer(Of SByte)
						If gBaseString<char>4 IsNot Nothing Then
							ptr5 = gBaseString<char>4
						Else
							ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Dim ptr6 As __Pointer(Of GStream) = <Module>.GFileSystem.OpenWrite(<Module>.FS, ptr5, Nothing)
						If ptr4 Is Nothing Then
							<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1980, CType((AddressOf <Module>.??_C@_0BN@CIJBGNFH@NWorkshop?3?3NMainForm?3?3RunMap?$AA@), __Pointer(Of SByte)))
							Dim ptr7 As __Pointer(Of SByte)
							If gBaseString<char>2 IsNot Nothing Then
								ptr7 = gBaseString<char>2
							Else
								ptr7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), __Pointer(Of SByte)), __Dereference(CType(ptr7, __Pointer(Of SByte))))
						End If
						If ptr6 Is Nothing Then
							<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 1983, CType((AddressOf <Module>.??_C@_0BN@CIJBGNFH@NWorkshop?3?3NMainForm?3?3RunMap?$AA@), __Pointer(Of SByte)))
							Dim ptr8 As __Pointer(Of SByte)
							If gBaseString<char>4 IsNot Nothing Then
								ptr8 = gBaseString<char>4
							Else
								ptr8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BB@MAHHKGJO@Couldn?8t?5open?5?$CFs?$AA@), __Pointer(Of SByte)), __Dereference(CType(ptr8, __Pointer(Of SByte))))
						End If
						If <Module>.GEditorWorld.Save(Me.World, ptr4, ptr6) Is Nothing Then
							GoTo IL_2D8
						End If
						Dim arg_172_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, __Dereference((__Dereference(CType(ptr4, __Pointer(Of Integer))))))
						Dim arg_17D_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, __Dereference((__Dereference(CType(ptr6, __Pointer(Of Integer))))))
						Dim process As Process = New Process()
						Dim fileName As String = fileInfo.Directory.FullName + "/jtf.exe"
						process.StartInfo.FileName = fileName
						process.StartInfo.CreateNoWindow = False
						Dim value As __Pointer(Of SByte)
						If gBaseString<char>2 IsNot Nothing Then
							value = gBaseString<char>2
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						process.StartInfo.Arguments = "-map """ + New String(CType(value, __Pointer(Of SByte))) + New String(CType((AddressOf <Module>.??_C@_01BJJEKLCA@?$CC?$AA@), __Pointer(Of SByte)))
						Try
							process.Start()
							GoTo IL_285
						End Try
						Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
						endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
						IL_285:
						process.WaitForExit()
						GoTo IL_30F
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>4 IsNot Nothing Then
						<Module>.free(gBaseString<char>4)
						gBaseString<char>4 = 0
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
					Return
				End If
				Return
				IL_2D8:
				Try
					Try
						Dim ptr4 As __Pointer(Of GStream)
						Dim arg_2E3_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, __Dereference((__Dereference(CType(ptr4, __Pointer(Of Integer))))))
						Dim ptr6 As __Pointer(Of GStream)
						Dim arg_2EE_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr6, 1, __Dereference((__Dereference(CType(ptr6, __Pointer(Of Integer))))))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
						Throw
					End Try
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				IL_30F:
				Try
					Try
						Dim ptr9 As __Pointer(Of SByte)
						If gBaseString<char>2 IsNot Nothing Then
							ptr9 = gBaseString<char>2
						Else
							ptr9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						<Module>.GFileSystem.Remove(<Module>.FS, ptr9)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>4 IsNot Nothing Then
						<Module>.free(gBaseString<char>4)
						gBaseString<char>4 = 0
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
				End If
			End If
		End Sub

		Private Sub UpdateCameraCurvePreview(elapsed As Long, <MarshalAs(UnmanagedType.U1)> force_refresh As Boolean)
			Dim cameraCurveProps As ToolboxScriptEntities = Me.CameraCurveProps
			Dim num As Single = cameraCurveProps.GetCameraCurvePos()
			Dim cameraCurveDuration As Single = cameraCurveProps.GetCameraCurveDuration()
			Dim gBaseString<char> As GBaseString<char> = 0
			__Dereference((gBaseString<char> + 4)) = 0
			Try
				Dim cameraStatus As Integer = Me.CameraCurveProps.GetCameraStatus()
				If cameraStatus <> 1 Then
					If cameraStatus <> 2 Then
						If cameraStatus <> 3 Then
							<Module>.GBaseString<char>.=(gBaseString<char>, CType((AddressOf <Module>.??_C@_05PDJBBECF@pause?$AA@), __Pointer(Of SByte)))
						Else
							num = CSng(elapsed) * 3E-06F + num
							<Module>.GBaseString<char>.=(gBaseString<char>, CType((AddressOf <Module>.??_C@_02MBHFIONK@3x?$AA@), __Pointer(Of SByte)))
						End If
					Else
						num -= CSng(elapsed) * 3E-06F
						<Module>.GBaseString<char>.=(gBaseString<char>, CType((AddressOf <Module>.??_C@_03ENCIPPDH@?93x?$AA@), __Pointer(Of SByte)))
					End If
				Else
					num = CSng(elapsed) * 1E-06F + num
					<Module>.GBaseString<char>.=(gBaseString<char>, CType((AddressOf <Module>.??_C@_02MCPBFKLE@1x?$AA@), __Pointer(Of SByte)))
				End If
				If Me.CameraCurveProps.GetCameraCurveLoop() Then
					If num > cameraCurveDuration Then
						num = 0F
					Else If num < 0F Then
						num = cameraCurveDuration
					End If
				Else
					If num > cameraCurveDuration Then
						num = cameraCurveDuration
					End If
					If num < 0F Then
						num = 0F
					End If
				End If
				Me.CameraCurveProps.SetCameraCurvePos(num)
				Me.CameraCurveProps.RefreshCameraCurvePos()
				If Me.CameraCurveProps.RefreshCameraViewport(gBaseString<char>, cameraStatus, force_refresh) Then
					MyBase.Focus()
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
		End Sub

		Private Sub DebugMap()
			If Me.World IsNot Nothing Then
				Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
				Dim debugMapTempFOV As Single
				Dim debugMapTempNearPlane As Single
				Dim debugMapTempFarPlane As Single
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), iViewport, debugMapTempFOV, debugMapTempNearPlane, debugMapTempFarPlane, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 44)))
				Me.DebugMapTempFOV = debugMapTempFOV
				Me.DebugMapTempNearPlane = debugMapTempNearPlane
				Me.DebugMapTempFarPlane = debugMapTempFarPlane
				Me.LastCameraType = <Module>.?GetCameraType@GWorld@@$$FQBE?AW4GCameraType@@XZ(Me.World)
				<Module>.GWorld.GetCamera(Me.World, Me.LastCamera)
				Dim world As __Pointer(Of GEditorWorld) = Me.World
				Dim num As Integer = __Dereference(CType((world + 3228 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
				Dim num2 As Integer = __Dereference(CType((world + 3232 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
				Dim gStreamBuffer As GStreamBuffer
				<Module>.GStreamBuffer.{ctor}(gStreamBuffer)
				Try
					Dim gStreamBuffer2 As GStreamBuffer
					<Module>.GStreamBuffer.{ctor}(gStreamBuffer2)
					Try
						Dim world2 As __Pointer(Of GEditorWorld) = Me.World
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world2, 3, 0, __Dereference((__Dereference(CType(world2, __Pointer(Of Integer))) + 12)))
						Dim world3 As __Pointer(Of GEditorWorld) = Me.World
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world3, 2, 0, __Dereference((__Dereference(CType(world3, __Pointer(Of Integer))) + 12)))
						<Module>.GEditorWorld.Refresh(Me.World, 0L, Me.IViewport)
						<Module>.GEditorWorld.ResetForDebug(Me.World, Me.IViewport)
						If <Module>.GEditorWorld.Save(Me.World, CType((AddressOf gStreamBuffer), __Pointer(Of GStream)), CType((AddressOf gStreamBuffer2), __Pointer(Of GStream))) IsNot Nothing Then
							GoTo IL_129
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GStreamBuffer.{dtor}), CType((AddressOf gStreamBuffer2), __Pointer(Of Void)))
						Throw
					End Try
					<Module>.GStreamBuffer.{dtor}(gStreamBuffer2)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GStreamBuffer.{dtor}), CType((AddressOf gStreamBuffer), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GStreamBuffer.{dtor}(gStreamBuffer)
				Return
				IL_129:
				Try
					Dim gStreamBuffer2 As GStreamBuffer
					Try
						Me.GameDebugMode = True
						Me.GameDebugBackupWorld = Me.World
						Me.World = Nothing
						<Module>.World = Nothing
						Me.GameDebugBackupScene = <Module>.Scene
						<Module>.Scene = Nothing
						initblk(Me.AvailableCommands, 0, 48)
						Dim ptr As __Pointer(Of GWorld) = <Module>.new(4200UI)
						Dim gameDebugWorld As __Pointer(Of GWorld)
						Try
							If ptr IsNot Nothing Then
								Dim nD As __Pointer(Of GNativeData) = Me.ND
								gameDebugWorld = <Module>.GWorld.{ctor}(ptr, __Dereference(CType((nD + 4 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), __Dereference(CType(nD, __Pointer(Of GHandle<19>))), __Dereference(CType(nD, __Pointer(Of GHandle<19>))), True)
							Else
								gameDebugWorld = 0
							End If
						Catch 
							<Module>.delete(CType(ptr, __Pointer(Of Void)))
							Throw
						End Try
						Me.GameDebugWorld = gameDebugWorld
						Dim gAWorld As GAWorld
						<Module>.GAWorld.{ctor}(gAWorld)
						Try
							<Module>.GAWorld.Load(gAWorld, CType((AddressOf gStreamBuffer2), __Pointer(Of GStream)))
							<Module>.GStream.Reset(gStreamBuffer)
							If <Module>.?Load@GWorld@@$$FQAE_NPAVGStream@@PAVGAWorld@@_NP6AXABUGLoadingInfo@@PAX@ZP6AXXZP6AHW4AssetType@@PBDAAV?$GBaseString@D@@2@Z4@Z(Me.GameDebugWorld, CType((AddressOf gStreamBuffer), __Pointer(Of GStream)), AddressOf gAWorld, True, 0, 0, 0, Nothing) Is Nothing Then
								<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0P@KKPHAALN@?4?2MainForm?4cpp?$AA@), __Pointer(Of SByte)), 2081, CType((AddressOf <Module>.??_C@_0BP@KBDKBGLO@NWorkshop?3?3NMainForm?3?3DebugMap?$AA@), __Pointer(Of SByte)))
								<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0P@BIPNFHPK@Can?8t?5load?5map?$AA@), __Pointer(Of SByte)))
							End If
							<Module>.GWorld.Initialize(Me.GameDebugWorld)
							Dim gGameLogicSettings As GGameLogicSettings = 0
							Dim ptr2 As __Pointer(Of GGameLogic) = <Module>.new(75952UI)
							Dim ptr3 As __Pointer(Of GGameLogic)
							Try
								If ptr2 IsNot Nothing Then
									Dim nD2 As __Pointer(Of GNativeData) = Me.ND
									ptr3 = <Module>.GGameLogic.{ctor}(ptr2, __Dereference(CType((nD2 + 4 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), __Dereference(CType((nD2 + 8 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), __Dereference(CType((nD2 + 12 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), gGameLogicSettings, Nothing)
								Else
									ptr3 = 0
								End If
							Catch 
								<Module>.delete(CType(ptr2, __Pointer(Of Void)))
								Throw
							End Try
							<Module>.GameLogic = ptr3
							<Module>.GGameLogic.SetEchoCallback(ptr3, <Module>.__unep@?EchoLogHandler@NWorkshop@@$$FYAXV?$GBaseString@D@@@Z)
							Dim ptr4 As __Pointer(Of GOrder) = <Module>.new(120UI)
							Dim currentOrder As __Pointer(Of GOrder)
							Try
								If ptr4 IsNot Nothing Then
									currentOrder = <Module>.GOrder.{ctor}(ptr4)
								Else
									currentOrder = 0
								End If
							Catch 
								<Module>.delete(CType(ptr4, __Pointer(Of Void)))
								Throw
							End Try
							Me.CurrentOrder = currentOrder
							Me.LastEditorMode = Me.EditorMode
							Me.SetEditorMode(22)
							Me.CurrentControlPanel = Nothing
							Me.SetDebugMode(Me.DebugMode)
							Me.LoggerTool.Reset()
							Me.LastCamViewPortUpdate = <Module>.GTimer.GetTimeH(<Module>.Timer)
							Me.LastUpdate = Me.LastCamViewPortUpdate
							<Module>.GWorld.AlwaysDrawPaths(Me.GameDebugWorld, True)
							<Module>.GWorld.AlwaysDrawLocations(Me.GameDebugWorld, True)
							Me.tbDebug.SetItemPushed(214, True)
							Me.DTriggersTool.Init(__Dereference(CType((<Module>.GameLogic + 2932 / __SizeOf(GGameLogic)), __Pointer(Of Integer))))
							Me.DGVarsTool.Init(__Dereference(CType((<Module>.GameLogic + 2932 / __SizeOf(GGameLogic)), __Pointer(Of Integer))))
							__Dereference(CType((Me.GameDebugWorld + 3228 / __SizeOf(GWorld)), __Pointer(Of Integer))) = num
							__Dereference(CType((Me.GameDebugWorld + 3232 / __SizeOf(GWorld)), __Pointer(Of Integer))) = num2
							__Dereference(CType((Me.GameDebugWorld + 3236 / __SizeOf(GWorld)), __Pointer(Of Byte))) = (If(Me.CameraCurveProps.GetCameraCurveMakeShots(), 1, 0))
							__Dereference(CType((Me.GameDebugWorld + 3220 / __SizeOf(GWorld)), __Pointer(Of Byte))) = __Dereference(CType((Me.GameDebugBackupWorld + 3220 / __SizeOf(GEditorWorld)), __Pointer(Of Byte)))
							__Dereference(CType((Me.GameDebugWorld + 3216 / __SizeOf(GWorld)), __Pointer(Of Integer))) = __Dereference(CType((Me.GameDebugBackupWorld + 3216 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
							__Dereference(CType((Me.GameDebugWorld + 3224 / __SizeOf(GWorld)), __Pointer(Of Single))) = __Dereference(CType((Me.GameDebugBackupWorld + 3224 / __SizeOf(GEditorWorld)), __Pointer(Of Single)))
							If Me.CameraCurveProps.GetCameraCurveDebugShow() Then
								If num <> -1 OrElse __Dereference(CType((Me.GameDebugWorld + 3220 / __SizeOf(GWorld)), __Pointer(Of Byte))) <> 0 Then
									If Me.CameraCurveProps.GetCameraCurveMakeShots() Then
										Dim gBaseString<char> As GBaseString<char>
										<Module>.GBaseString<char>.{ctor}(gBaseString<char>, <Module>.GFileSystem.GetHomePath(<Module>.FS))
										Try
											Dim gBaseString<char>2 As GBaseString<char>
											Dim src As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(gBaseString<char>, AddressOf gBaseString<char>2, CType((AddressOf <Module>.??_C@_0N@FEIMNKOL@?1CameraShots?$AA@), __Pointer(Of SByte)))
											Try
												<Module>.GBaseString<char>.=(Me.GameDebugWorld + 3240 / __SizeOf(GWorld), src)
											Catch 
												<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
												Throw
											End Try
											If gBaseString<char>2 IsNot Nothing Then
												<Module>.free(gBaseString<char>2)
											End If
											Dim num3 As UInteger = CUInt((__Dereference(CType((Me.GameDebugWorld + 3240 / __SizeOf(GWorld)), __Pointer(Of Integer)))))
											Dim ptr5 As __Pointer(Of SByte)
											If num3 <> 0UI Then
												ptr5 = num3
											Else
												ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
											End If
											<Module>.GFileSystem.CreatePath(<Module>.FS, ptr5)
											Me.GameDebugWithShotsMode = True
											Dim gameDebugWorld2 As __Pointer(Of GWorld) = Me.GameDebugWorld
											Me.CameraCurveProps.GetResolution(gameDebugWorld2 + 3248 / __SizeOf(GWorld), gameDebugWorld2 + 3252 / __SizeOf(GWorld))
											Me.DebugMapTemp_RefractBufferWidth = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 1, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20)))
											Me.DebugMapTemp_RefractBufferHeight = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 2, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20)))
											Me.DebugMapTemp_ReflectBufferWidth = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 3, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20)))
											Me.DebugMapTemp_ReflectBufferHeight = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 4, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20)))
											Me.DebugMapTemp_DistanceBufferWidth = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 5, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20)))
											Me.DebugMapTemp_DistanceBufferHeight = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 6, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20)))
											Me.DebugMapTemp_ShadowBufferSize = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 8, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20)))
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 1, __Dereference(CType((Me.GameDebugWorld + 3248 / __SizeOf(GWorld)), __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 2, __Dereference(CType((Me.GameDebugWorld + 3252 / __SizeOf(GWorld)), __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 3, __Dereference(CType((Me.GameDebugWorld + 3248 / __SizeOf(GWorld)), __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 4, __Dereference(CType((Me.GameDebugWorld + 3252 / __SizeOf(GWorld)), __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 5, __Dereference(CType((Me.GameDebugWorld + 3248 / __SizeOf(GWorld)), __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 6, __Dereference(CType((Me.GameDebugWorld + 3252 / __SizeOf(GWorld)), __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
											calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 8, 2048, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
										Catch 
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
											Throw
										End Try
										If gBaseString<char> IsNot Nothing Then
											<Module>.free(gBaseString<char>)
										End If
									End If
									<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(Me.GameDebugWorld, 2)
									Dim expr_670 As __Pointer(Of GISoundSys) = <Module>.ISoundSys
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_670, __Dereference((__Dereference(CType(expr_670, __Pointer(Of Integer))) + 144)))
								End If
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWorld.{dtor}), CType((AddressOf gAWorld), __Pointer(Of Void)))
							Throw
						End Try
						<Module>.GAWorld.{dtor}(gAWorld)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GStreamBuffer.{dtor}), CType((AddressOf gStreamBuffer2), __Pointer(Of Void)))
						Throw
					End Try
					<Module>.GStreamBuffer.{dtor}(gStreamBuffer2)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GStreamBuffer.{dtor}), CType((AddressOf gStreamBuffer), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GStreamBuffer.{dtor}(gStreamBuffer)
			End If
		End Sub

		Private Sub EndDebugMap()
			If Me.GameDebugMode Then
				Me.panSideBar.Controls.Remove(Me.LoggerContainer)
				Me.panSideBar.Controls.Remove(Me.DUnitsContainer)
				Me.panSideBar.Controls.Remove(Me.DUnitGroupsContainer)
				Me.panSideBar.Controls.Remove(Me.DTriggersContainer)
				Me.panSideBar.Controls.Remove(Me.DGVarsContainer)
				Dim currentControlPanel As ToolboxContainer = Me.CurrentControlPanel
				If currentControlPanel IsNot Nothing Then
					Me.panSideBar.Controls.Remove(currentControlPanel)
				End If
				Me.CurrentControlPanel = Nothing
				Dim currentOrder As __Pointer(Of GOrder) = Me.CurrentOrder
				If currentOrder IsNot Nothing Then
					Dim ptr As __Pointer(Of GOrder) = currentOrder
					<Module>.GOrder.{dtor}(ptr)
					<Module>.delete(CType(ptr, __Pointer(Of Void)))
					Me.CurrentOrder = Nothing
				End If
				If <Module>.GameLogic IsNot Nothing Then
					Dim arg_D9_0 As __Pointer(Of Void) = CType(<Module>.GameLogic, __Pointer(Of Void))
					<Module>.GGameLogic.{dtor}(<Module>.GameLogic)
					<Module>.delete(arg_D9_0)
					<Module>.GameLogic = Nothing
				End If
				Dim gameDebugWorld As __Pointer(Of GWorld) = Me.GameDebugWorld
				If gameDebugWorld IsNot Nothing Then
					Dim ptr2 As __Pointer(Of GWorld) = gameDebugWorld
					Dim arg_FA_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, __Dereference((__Dereference(CType(ptr2, __Pointer(Of Integer))))))
					Me.GameDebugWorld = Nothing
				End If
				Dim gameDebugBackupWorld As __Pointer(Of GEditorWorld) = Me.GameDebugBackupWorld
				Me.World = gameDebugBackupWorld
				<Module>.World = CType(gameDebugBackupWorld, __Pointer(Of GWorld))
				<Module>.Scene = Me.GameDebugBackupScene
				If Me.GameDebugWithShotsMode Then
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 1, Me.DebugMapTemp_RefractBufferWidth, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 2, Me.DebugMapTemp_RefractBufferHeight, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 3, Me.DebugMapTemp_ReflectBufferWidth, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 4, Me.DebugMapTemp_ReflectBufferHeight, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 5, Me.DebugMapTemp_DistanceBufferWidth, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 6, Me.DebugMapTemp_DistanceBufferHeight, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 8, Me.DebugMapTemp_ShadowBufferSize, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
					Dim expr_1EE As __Pointer(Of GISoundSys) = <Module>.ISoundSys
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_1EE, __Dereference((__Dereference(CType(expr_1EE, __Pointer(Of Integer))) + 148)))
				End If
				Me.GameDebugMode = False
				Me.GameDebugWithShotsMode = False
				Me.SetEditorMode(Me.LastEditorMode)
				<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(Me.World, Me.LastCameraType)
				<Module>.GWorld.SetCamera(Me.World, Me.LastCamera)
				Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single), iViewport, Me.DebugMapTempFOV, Me.DebugMapTempNearPlane, Me.DebugMapTempFarPlane, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 40)))
			End If
		End Sub

		Private Sub UpdateCameraDebugText()
			If Not calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 3, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 32))) Then
				Dim gameDebugWorld As __Pointer(Of GWorld) = Me.GameDebugWorld
				Dim gCamera As GCamera
				If gameDebugWorld IsNot Nothing Then
					<Module>.GWorld.GetCamera(gameDebugWorld, gCamera)
				Else
					<Module>.GWorld.GetCamera(Me.World, gCamera)
				End If
				Dim num As Single = __Dereference((gCamera + 8)) * 0.159154937F
				Dim num2 As Single = CSng((CDec(num) Mod 1.0))
				If num2 < 0F Then
					num2 += 1F
				End If
				Dim num3 As Integer = ((4 - __Dereference((<Module>.MissionVariables + 4))) * 2 + <Module>.fround(num2 * 8F)) Mod 8
				Dim $ArrayType$$$BY08PBD As $ArrayType$$$BY08PBD = <Module>.??_C@_05FPOHJMOI@North?$AA@
				__Dereference(($ArrayType$$$BY08PBD + 4)) = <Module>.??_C@_09DEECMKJ@NorthEast?$AA@
				__Dereference(($ArrayType$$$BY08PBD + 8)) = <Module>.??_C@_04DHLACFEG@East?$AA@
				__Dereference(($ArrayType$$$BY08PBD + 12)) = <Module>.??_C@_09NLNBCPOI@SouthEast?$AA@
				__Dereference(($ArrayType$$$BY08PBD + 16)) = <Module>.??_C@_05HNHILFBE@South?$AA@
				__Dereference(($ArrayType$$$BY08PBD + 20)) = <Module>.??_C@_09EOJDHMFN@SouthWest?$AA@
				__Dereference(($ArrayType$$$BY08PBD + 24)) = <Module>.??_C@_04KCPCHGPD@West?$AA@
				__Dereference(($ArrayType$$$BY08PBD + 28)) = <Module>.??_C@_09JGAGHPBM@NorthWest?$AA@
				__Dereference(($ArrayType$$$BY08PBD + 32)) = <Module>.??_C@_05FPOHJMOI@North?$AA@
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>, CType((AddressOf <Module>.??_C@_0EF@KDOIMJMO@X?3?5?$CFf?0?5Z?3?5?$CFf?0?5Y?3?5?$CFf?0?5Camera?3?5?$FLDi@), __Pointer(Of SByte)), CDec(Me.MouseTargetX), CDec(Me.MouseTargetZ), CDec(Me.MouseTargetY), CDec((num2 * 360F)), __Dereference((num3 * 4 + $ArrayType$$$BY08PBD)), CDec((__Dereference((gCamera + 12)) * 57.29578F)), CDec((__Dereference((<Module>.Measures + 4)) * __Dereference((gCamera + 16)))))
				Try
					Dim num4 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
					Dim ptr2 As __Pointer(Of SByte)
					If num4 <> 0UI Then
						ptr2 = num4
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim nD As __Pointer(Of GNativeData) = Me.ND
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>,GHandle<12>,System.Int32,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.ILayout, __Dereference(CType((nD + 24 / __SizeOf(GNativeData)), __Pointer(Of GHandle<19>))), __Dereference(CType((nD + 4 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), 0, ptr2, __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))) + 84)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			End If
		End Sub

		Private Sub RefreshDebug()
			Dim num As Long = <Module>.GTimer.GetTimeH(<Module>.Timer)
			If Me.LastUpdate = 0L Then
				Me.LastUpdate = num
			End If
			Dim num2 As Integer = 0
			Do
				If __Dereference((num2 * 8 + Me.KeyTimes)) <> 0L Then
					Me.UpdateKey(num, num2)
				End If
				num2 += 1
			Loop While num2 < 256
			Dim num3 As Long = num - Me.LastUpdate
			Me.LastUpdate = num
			If Me.GameDebugMode AndAlso Me.GameDebugWithShotsMode Then
				num3 = 50000L
			End If
			<Module>.GGameLogic.Refresh(<Module>.GameLogic, num3, Me.IViewport)
			Me.UpdateCameraDebugText()
			If Not Me.GameDebugWithShotsMode Then
				Dim gameDebugWorld As __Pointer(Of GWorld) = Me.GameDebugWorld
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GIViewport*), gameDebugWorld, Me.IViewport, __Dereference((__Dereference(CType(gameDebugWorld, __Pointer(Of Integer))) + 36)))
				Dim gameDebugWorld2 As __Pointer(Of GWorld) = Me.GameDebugWorld
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), gameDebugWorld2, 0, __Dereference((__Dereference(CType(gameDebugWorld2, __Pointer(Of Integer))) + 40)))
			End If
			Dim gGamePanelStatus As GGamePanelStatus
			<Module>.GGamePanelStatus.{ctor}(gGamePanelStatus)
			Try
				Dim gModOptions As GModOptions = 0
				__Dereference((gModOptions + 4)) = 0
				__Dereference((gModOptions + 8)) = 0
				Try
					Dim gMissionStatus As GMissionStatus = 0
					__Dereference((gMissionStatus + 4)) = 0
					__Dereference((gMissionStatus + 8)) = 0
					Try
						__Dereference((gMissionStatus + 12)) = 0
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<GMissionObjectiveInfo>.{dtor}), CType((AddressOf gMissionStatus), __Pointer(Of Void)))
						Throw
					End Try
					Try
						Dim num4 As Integer
						<Module>.GGameLogic.GetGamePanelStatus(<Module>.GameLogic, gGamePanelStatus, Me.CurrentOrder, gModOptions, gMissionStatus, num4)
						Dim num5 As Integer = 0
						Do
							Dim b As Byte = If((__Dereference((num5 + gGamePanelStatus)) <> 0), 1, 0)
							__Dereference((Me.AvailableCommands + num5)) = b
							num5 += 1
						Loop While num5 < 48
						If __Dereference((gGamePanelStatus + 228)) = 1 Then
							If Me.CommandMode <> 20 AndAlso Me.AcceptedCommand <> 20 Then
								<Module>.GWorld.ShowUnitRange(Me.GameDebugWorld, __Dereference((gGamePanelStatus + 232)), 5, 0F)
							Else
								<Module>.GWorld.ShowUnitRange(Me.GameDebugWorld, __Dereference((gGamePanelStatus + 232)), 2, 0F)
							End If
						Else
							<Module>.GWorld.ShowUnitRange(Me.GameDebugWorld, -1, 15, 0F)
						End If
						If Me.DebugMode = 503 Then
							Me.DTriggersTool.Refresh(__Dereference(CType((<Module>.GameLogic + 2932 / __SizeOf(GGameLogic)), __Pointer(Of Integer))))
							Me.DGVarsTool.Refresh(__Dereference(CType((<Module>.GameLogic + 2932 / __SizeOf(GGameLogic)), __Pointer(Of Integer))))
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GMissionStatus.{dtor}), CType((AddressOf gMissionStatus), __Pointer(Of Void)))
						Throw
					End Try
					Dim num6 As Integer = 0
					If 0 < __Dereference((gMissionStatus + 4)) Then
						Dim num7 As Integer = 0
						Do
							<Module>.GMissionObjectiveInfo.__delDtor(num7 + gMissionStatus, 0UI)
							num6 += 1
							num7 += 24
						Loop While num6 < __Dereference((gMissionStatus + 4))
					End If
					If gMissionStatus IsNot Nothing Then
						<Module>.free(gMissionStatus)
						gMissionStatus = 0
					End If
					__Dereference((gMissionStatus + 4)) = 0
					__Dereference((gMissionStatus + 8)) = 0
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GModOptions.{dtor}), CType((AddressOf gModOptions), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GArray<GBaseString<char> >.{dtor}(gModOptions)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GGamePanelStatus.{dtor}), CType((AddressOf gGamePanelStatus), __Pointer(Of Void)))
				Throw
			End Try
			<Module>.GGamePanelStatus.{dtor}(gGamePanelStatus)
		End Sub

		Private Sub SetPlaySpeed(play_speed As Integer)
			<Module>.GGameLogic.SetPlaySpeed(<Module>.GameLogic, play_speed, True)
		End Sub

		Private Sub HandleDebugKeys(code As Keys)
			Select Case code
				Case Keys.Pause
					If <Module>.GGameLogic.GetPlaySpeed(<Module>.GameLogic) Is Nothing Then
						<Module>.GGameLogic.RefreshMicroFrame(<Module>.GameLogic)
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), <Module>.Scene, 25000L, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 32)))
						Return
					End If
					Me.SetPlaySpeed(0)
					Return
				Case Keys.Escape
					Me.EndDebugMap()
					Return
				Case Keys.Space
					Dim num As Integer = If((<Module>.GGameLogic.GetPlaySpeed(<Module>.GameLogic) = 0), 1, 0)
					<Module>.GGameLogic.SetPlaySpeed(<Module>.GameLogic, num, True)
					Return
				Case Keys.A
					Me.StartDebugCommand(7)
					Return
				Case Keys.B
					Me.StartDebugCommand(2)
					Return
				Case Keys.D
					If __Dereference((Me.AvailableCommands + 6)) <> 0 Then
						Dim b As Byte
						If __Dereference((Me.KeyTimes + 128)) <> 0L Then
							b = 1
						Else
							b = 0
						End If
						<Module>.?QUnitCommand@GGameLogic@@$$FQAEXW4GTargetTask@@_N@Z(<Module>.GameLogic, 24, b <> 0)
						Return
					End If
					Return
				Case Keys.M
					Me.StartDebugCommand(1)
					Return
				Case Keys.P
					If __Dereference((Me.AvailableCommands + 4)) <> 0 Then
						Dim b2 As Byte
						If __Dereference((Me.KeyTimes + 128)) <> 0L Then
							b2 = 1
						Else
							b2 = 0
						End If
						<Module>.?QUnitCommand@GGameLogic@@$$FQAEXW4GTargetTask@@_N@Z(<Module>.GameLogic, 23, b2 <> 0)
						Return
					End If
					Return
				Case Keys.S
					If __Dereference((Me.AvailableCommands + 3)) <> 0 Then
						Dim b3 As Byte
						If __Dereference((Me.KeyTimes + 128)) <> 0L Then
							b3 = 1
						Else
							b3 = 0
						End If
						<Module>.?QUnitCommand@GGameLogic@@$$FQAEXW4GTargetTask@@_N@Z(<Module>.GameLogic, 4, b3 <> 0)
						Return
					End If
					Return
				Case Keys.U
					If __Dereference((Me.AvailableCommands + 5)) <> 0 Then
						Dim b4 As Byte
						If __Dereference((Me.KeyTimes + 128)) <> 0L Then
							b4 = 1
						Else
							b4 = 0
						End If
						<Module>.?QUnitCommand@GGameLogic@@$$FQAEXW4GTargetTask@@_N@Z(<Module>.GameLogic, 22, b4 <> 0)
						Return
					End If
					Return
				Case Keys.F1
					If __Dereference((Me.KeyTimes + 128)) <> 0L Then
						<Module>.GWorld.CameraInitialize(Me.GameDebugWorld)
					Else
						Dim gameDebugWorld As __Pointer(Of GWorld) = Me.GameDebugWorld
						Dim b5 As Byte = If((__Dereference(CType((gameDebugWorld + 136 / __SizeOf(GWorld)), __Pointer(Of Byte))) = 0), 1, 0)
						<Module>.GWorld.LimitGameCamera(gameDebugWorld, b5 <> 0)
					End If
					Me.MinimapViewportNeedsUpdate = True
					Return
				Case Keys.F7
					If __Dereference((Me.KeyTimes + 136)) <> 0L Then
						Dim b6 As Byte = If((<Module>.GWorld.GetBlockMapMode(Me.GameDebugWorld) = 0), 1, 0)
						<Module>.GWorld.SetBlockMapMode(Me.GameDebugWorld, b6 <> 0)
						Return
					End If
					Dim b7 As Byte = If((calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(CType((<Module>.GameLogic + 2440 / __SizeOf(GGameLogic)), __Pointer(Of GHandle<11>))), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 272))) = 0), 1, 0)
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, __Dereference(CType((<Module>.GameLogic + 2440 / __SizeOf(GGameLogic)), __Pointer(Of GHandle<11>))), b7, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 268)))
					Return
			End Select
			If code - Keys.D1 <= 8 Then
				If __Dereference((Me.KeyTimes + 128)) <> 0L Then
					Select Case code
						Case Keys.D1
							<Module>.?QUnitCommandWithUnitState@GGameLogic@@$$FQAEXW4GTargetTask@@H_N@Z(<Module>.GameLogic, 32, 0, False)
						Case Keys.D2
							<Module>.?QUnitCommandWithUnitState@GGameLogic@@$$FQAEXW4GTargetTask@@H_N@Z(<Module>.GameLogic, 32, 2, False)
						Case Keys.D4
							<Module>.GGameLogic.QSetFormation(<Module>.GameLogic, 2)
						Case Keys.D5
							<Module>.GGameLogic.QSetFormation(<Module>.GameLogic, 1)
						Case Keys.D6
							<Module>.GGameLogic.QSetFormation(<Module>.GameLogic, 0)
					End Select
				Else If __Dereference((Me.KeyTimes + 136)) <> 0L Then
					<Module>.GWorld.CreateUnitGroup(Me.GameDebugWorld, code - Keys.D0)
				Else
					<Module>.GWorld.SelectUnitGroup(Me.GameDebugWorld, code - Keys.D0)
				End If
			End If
		End Sub

		Private Sub DebugMouseDown(sender As Object, e As MouseEventArgs)
			Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
			Dim gRay As GRay
			Dim dragX As Single
			Dim num2 As Single
			Dim dragZ As Single
			<Module>.GWorld.GetTarget(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, e.X, e.Y, __Dereference(num)), dragX, num2, dragZ)
			If e.Button = MouseButtons.Left Then
				If Me.DragMode = 31 Then
					Dim commandMode As Integer = Me.CommandMode
					If commandMode = 20 Then
						Me.CancelDebugCommand()
					Else
						If commandMode <> 1 AndAlso commandMode <> 2 Then
							Me.ExecuteDebugCommand(e.X, e.Y, CInt((__Dereference((Me.KeyTimes + 136)))), commandMode)
							Me.CommandMode = 0
							Me.DragMode = 0
							Return
						End If
						Me.DragX = dragX
						Me.DragZ = dragZ
						Me.DragY = num2 + 0.1F
						Me.DragMode = 33
						Return
					End If
				Else
					If Me.LastClickTime <> 0L AndAlso Math.Abs(Me.DragMX - e.X) <= 4 AndAlso Math.Abs(Me.DragMY - e.Y) <= 4 AndAlso <Module>.GTimer.GetTimeH(<Module>.Timer) - Me.LastClickTime <= 200000L Then
						Dim num3 As Integer
						If __Dereference((Me.KeyTimes + 128)) <> 0L Then
							num3 = 5
						Else
							num3 = 16
						End If
						Dim num4 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 60
						Dim gPyramid As GPyramid
						<Module>.GWorld.SelectUnitByType(Me.GameDebugWorld, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), Me.IViewport, gPyramid, 0, 0, MyBase.Width, MyBase.Height, __Dereference(num4)), Me.LastClickUnit, num3)
						Me.LastClickTime = 0L
						Me.LastClickTimeRightButton = 0L
						Return
					End If
					If __Dereference((Me.KeyTimes + 136)) <> 0L Then
						Dim num5 As Long = __Dereference((Me.KeyTimes + 128))
						Dim num6 As Integer
						If num5 <> 0L Then
							num6 = 5
						Else
							num6 = 16
						End If
						Dim num7 As Integer
						If num5 <> 0L Then
							num7 = 5
						Else
							num7 = 16
						End If
						Dim num8 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim num9 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 60
						Dim gPyramid2 As GPyramid
						Dim gRay2 As GRay
						<Module>.GWorld.SelectUnitByType(Me.GameDebugWorld, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), Me.IViewport, gPyramid2, 0, 0, MyBase.Width, MyBase.Height, __Dereference(num9)), <Module>.GWorld.SelectUnit(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay2, e.X, e.Y, __Dereference(num8)), num7), num6)
						Me.LastClickTime = 0L
						Me.LastClickTimeRightButton = 0L
						Return
					End If
					If Me.DragMode = 19 Then
						Me.DragMX = e.X
						Me.DragMY = e.Y
						Me.DragMode = 18
						Me.DragStarted = False
						Return
					End If
				End If
				Me.DragMX = e.X
				Me.DragMY = e.Y
				Me.DragMode = 30
				Me.DragStarted = False
				Me.LastClickTime = <Module>.GTimer.GetTimeH(<Module>.Timer)
				Me.LastClickUnit = -1
			Else If e.Button = MouseButtons.Right Then
				<Module>.GWorld.ClearBoxSelection(Me.GameDebugWorld)
				Dim flag As Boolean = (If((<Module>.GWorld.CountSelectedUnits(Me.GameDebugWorld) <> 0), 1, 0)) <> 0
				Dim dragMode As Integer = Me.DragMode
				If dragMode = 31 Then
					Me.CancelDebugCommand()
				Else If dragMode = 30 Then
					<Module>.GWorld.SelectUnit(Me.GameDebugWorld, 1)
					Me.DragMX = e.X
					Me.DragMY = e.Y
					Me.DragMode = 18
				Else If flag Then
					Dim num10 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
					Dim gRay3 As GRay
					Dim num11 As Integer = <Module>.GWorld.GetTargetUnit(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay3, e.X, e.Y, __Dereference(num10)))
					Dim num12 As Integer = <Module>.GGameLogic.GetUnitAlignment(<Module>.GameLogic, num11)
					If num11 >= 0 AndAlso num12 = -1 Then
						Dim control As Integer = CInt((__Dereference((Me.KeyTimes + 136))))
						If Me.LastClickTimeRightButton <> 0L AndAlso Math.Abs(Me.DragMX - e.X) <= 4 AndAlso Math.Abs(Me.DragMY - e.Y) <= 4 AndAlso <Module>.GTimer.GetTimeH(<Module>.Timer) - Me.LastClickTimeRightButton <= 200000L Then
							control = 1
							Me.LastClickTime = 0L
							Me.LastClickTimeRightButton = 0L
						Else
							Me.LastClickTimeRightButton = <Module>.GTimer.GetTimeH(<Module>.Timer)
							Me.DragMX = e.X
							Me.DragMY = e.Y
						End If
						Me.CommandMode = 0
						Me.ExecuteDebugCommand(e.X, e.Y, control, 0)
					Else
						Me.DragX = dragX
						Me.DragY = num2
						Me.DragZ = dragZ
						If num12 = 1 AndAlso num11 >= 0 AndAlso (__Dereference((__Dereference((num11 * 8 + __Dereference(CType((Me.GameDebugWorld + 2928 / __SizeOf(GWorld)), __Pointer(Of Integer))) + 4)) + 844)) And 1) <> 0 Then
							Me.DragMode = 32
							Me.TurnUnitIdx = num11
						Else
							Me.DragMode = 33
						End If
						Me.DragY = num2 + 0.1F
						Me.CommandMode = 0
					End If
				Else If dragMode <> 18 Then
					Me.DragMX = e.X
					Me.DragMY = e.Y
					Me.DragMode = 19
					Me.CommandMode = 0
					<Module>.ShowCursor(0)
				End If
			Else If e.Button = MouseButtons.Middle Then
				Me.CompletePressedDrag(e.X, e.Y)
				Me.CancelDepressedDrag(True)
				Me.DragMX = e.X
				Me.DragMY = e.Y
				Me.DragMode = 18
				Me.panMainViewport.Capture = True
				<Module>.ShowCursor(0)
			End If
		End Sub

		Private Sub DebugMouseUp(sender As Object, e As MouseEventArgs)
			Dim dragMode As Integer = Me.DragMode
			If dragMode = 33 OrElse dragMode = 32 Then
				Dim control As Integer = CInt((__Dereference((Me.KeyTimes + 136))))
				If Me.LastClickTimeRightButton <> 0L AndAlso Math.Abs(Me.DragMX - e.X) <= 4 AndAlso Math.Abs(Me.DragMY - e.Y) <= 4 AndAlso <Module>.GTimer.GetTimeH(<Module>.Timer) - Me.LastClickTimeRightButton <= 200000L Then
					control = 1
					Me.LastClickTime = 0L
					Me.LastClickTimeRightButton = 0L
				Else
					Me.LastClickTimeRightButton = <Module>.GTimer.GetTimeH(<Module>.Timer)
					Me.DragMX = e.X
					Me.DragMY = e.Y
				End If
				Me.ExecuteDebugCommand(e.X, e.Y, control, Me.CommandMode)
				Me.DragMode = 0
				Me.CommandMode = 0
			End If
			If Me.DragMode = 30 Then
				<Module>.GWorld.ClearBoxSelection(Me.GameDebugWorld)
				If Me.DragStarted Then
					Me.LastClickTime = 0L
					Me.LastClickTimeRightButton = 0L
					Dim num As Integer
					If __Dereference((Me.KeyTimes + 128)) <> 0L Then
						num = 5
					Else
						num = 16
					End If
					Dim num2 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 60
					Dim gPyramid As GPyramid
					<Module>.GWorld.SelectUnit(Me.GameDebugWorld, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), Me.IViewport, gPyramid, Me.DragMX, Me.DragMY, e.X, e.Y, __Dereference(num2)), num)
				Else
					Dim num3 As Integer
					If __Dereference((Me.KeyTimes + 128)) <> 0L Then
						num3 = 17
					Else
						num3 = 16
					End If
					Dim num4 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
					Dim gRay As GRay
					Me.LastClickUnit = <Module>.GWorld.SelectUnit(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, e.X, e.Y, __Dereference(num4)), num3)
				End If
			End If
			Me.CompletePressedDrag(e.X, e.Y)
		End Sub

		Private Sub DebugMouseMove(sender As Object, e As MouseEventArgs)
			Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
			Dim gRay As GRay
			Dim x As Single
			Dim num2 As Single
			Dim z As Single
			<Module>.GWorld.GetTarget(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, e.X, e.Y, __Dereference(num)), x, num2, z)
			Dim dragMode As Integer = Me.DragMode
			If dragMode <> 18 Then
				If dragMode <> 19 Then
					If dragMode <> 30 Then
						Me.MouseUpdateDefault(e.X, e.Y, x, z)
					Else
						Dim num3 As Integer
						If Not Me.DragStarted AndAlso Math.Abs(Me.DragMX - e.X) <= 4 AndAlso Math.Abs(Me.DragMY - e.Y) <= 4 Then
							num3 = 0
						Else
							num3 = 1
						End If
						Dim b As Byte = CByte(num3)
						Me.DragStarted = (b <> 0)
						If b <> 0 Then
							<Module>.GWorld.SetBoxSelection(Me.GameDebugWorld, Me.DragMX, Me.DragMY, e.X, e.Y)
							Dim num4 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 60
							Dim gPyramid As GPyramid
							<Module>.GWorld.SelectUnit(Me.GameDebugWorld, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), Me.IViewport, gPyramid, Me.DragMX, Me.DragMY, e.X, e.Y, __Dereference(num4)), 33)
						Else
							Me.MouseUpdateDefault(e.X, e.Y, x, z)
						End If
					End If
				Else If(Me.DragStarted OrElse Math.Abs(e.X - Me.DragMX) >= 2 OrElse Math.Abs(e.Y - Me.DragMY) >= 2) AndAlso (e.X <> Me.DragMX OrElse e.Y <> Me.DragMY) Then
					Me.DragStarted = True
					<Module>.GWorld.CameraMove(Me.GameDebugWorld, CSng((CDec((Me.DragMY - e.Y)) * 0.02)), CSng((CDec((e.X - Me.DragMX)) * 0.02)))
					Dim p As Point = New Point(Me.DragMX, Me.DragMY)
					p = Me.panMainViewport.PointToScreen(p)
					<Module>.SetCursorPos(p.X, p.Y)
				End If
			Else If e.X <> Me.DragMX OrElse e.Y <> Me.DragMY Then
				<Module>.GWorld.CameraRotate(Me.GameDebugWorld, CSng((CDec((e.X - Me.DragMX)) * 0.002)), CSng((CDec((e.Y - Me.DragMY)) * 0.002)))
				Dim p2 As Point = New Point(Me.DragMX, Me.DragMY)
				p2 = Me.panMainViewport.PointToScreen(p2)
				<Module>.SetCursorPos(p2.X, p2.Y)
			End If
		End Sub

		Private Sub MouseUpdateDefault(m_x As Integer, m_y As Integer, x As Single, z As Single)
			Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
			Dim gRay As GRay
			Dim num As Integer = <Module>.GWorld.GetTargetUnit(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
			If Me.panMainViewport.Focused Then
				<Module>.GWorld.SelectUnit(Me.GameDebugWorld, num, 33)
				If num < 0 Then
					Dim gPoint As GPoint2 = x
					__Dereference((gPoint + 4)) = z
					Dim gCircle As GCircle
					<Module>.GGameLogic.IntersectionWithStaticObjects(<Module>.GCircle.{ctor}(gCircle, gPoint, 0.25F), 67US)
				End If
			Else
				<Module>.GWorld.SelectUnit(Me.GameDebugWorld, 1)
				<Module>.SetCursor(Nothing)
			End If
		End Sub

		Private Sub StartDebugCommand(command As Integer)
			Me.StartDebugCommand(command, True)
		End Sub

		Private Sub StartDebugCommand(command As Integer, <MarshalAs(UnmanagedType.U1)> cancellast As Boolean)
			If __Dereference((Me.AvailableCommands + command)) <> 0 Then
				If cancellast Then
					Me.CancelDebugCommand()
				End If
				Me.DragMode = 31
				Me.CommandMode = command
			End If
		End Sub

		Private Sub CancelDebugCommand()
			Me.CommandMode = 0
			Me.DragMode = 0
			Me.panMainViewport.Capture = False
		End Sub

		Private Sub ExecuteDebugCommand(m_x As Integer, m_y As Integer, control As Integer, command As Integer)
			Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
			Dim gRay As GRay
			Dim num As Integer = <Module>.GWorld.GetTargetUnit(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))))
			Dim dragMode As Integer = Me.DragMode
			If((dragMode <> 33 AndAlso dragMode <> 32) OrElse (m_x = Me.DragMX AndAlso m_y = Me.DragMY)) AndAlso num > -1 Then
				Dim commandMode As Integer = Me.CommandMode
				If commandMode <> 1 Then
					If commandMode <> 7 Then
						Dim b As Byte
						If __Dereference((Me.KeyTimes + 128)) <> 0L Then
							b = 1
						Else
							b = 0
						End If
						<Module>.?QUnitCommandWithUnit@GGameLogic@@$$FQAEXW4GTargetTask@@H_N@Z(<Module>.GameLogic, 1, num, b <> 0)
					Else
						Dim b2 As Byte
						If __Dereference((Me.KeyTimes + 128)) <> 0L Then
							b2 = 1
						Else
							b2 = 0
						End If
						<Module>.?QUnitCommandWithUnitAndGunnertype@GGameLogic@@$$FQAEXW4GTargetTask@@HW4GGunnerType@@_N@Z(<Module>.GameLogic, 5, num, 0, b2 <> 0)
					End If
				Else
					Dim b3 As Byte
					If __Dereference((Me.KeyTimes + 128)) <> 0L Then
						b3 = 1
					Else
						b3 = 0
					End If
					<Module>.?QUnitCommandWithUnit@GGameLogic@@$$FQAEXW4GTargetTask@@H_N@Z(<Module>.GameLogic, 2, num, b3 <> 0)
				End If
			Else
				iViewport = Me.IViewport
				Dim gRay2 As GRay
				Dim num2 As Single
				Dim num3 As Single
				Dim num4 As Single
				<Module>.GWorld.GetTarget(Me.GameDebugWorld, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay2, m_x, m_y, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))), num2, num3, num4)
				If <Module>.GWorld.IsParcelPlayable(Me.GameDebugWorld, num2, num4) IsNot Nothing Then
					Dim commandMode2 As Integer = Me.CommandMode
					If commandMode2 <> 1 Then
						If commandMode2 <> 2 Then
							If commandMode2 <> 7 Then
								If Me.DragMode = 32 Then
									Dim b4 As Byte
									If __Dereference((Me.KeyTimes + 128)) <> 0L Then
										b4 = 1
									Else
										b4 = 0
									End If
									Dim num5 As Integer = __Dereference((Me.TurnUnitIdx * 8 + __Dereference(CType((Me.GameDebugWorld + 2928 / __SizeOf(GWorld)), __Pointer(Of Integer))) + 4))
									Dim num6 As Single = num2 - __Dereference((num5 + 528))
									Dim num7 As Single = num4 - __Dereference((num5 + 536))
									Dim num8 As Single = CSng(Math.Atan2(CDec(num6), CDec(num7)))
									<Module>.?QUnitCommandWithDir@GGameLogic@@$$FQAEXW4GTargetTask@@M_N@Z(<Module>.GameLogic, 2, num8, b4 <> 0)
								Else
									Dim num9 As Single = num2 - Me.DragX
									Dim num10 As Single = num9
									If CDec((CSng(Math.Abs(CDec(num10))))) < 0.05 Then
										Dim num11 As Single = num4 - Me.DragZ
										If CDec((CSng(Math.Abs(CDec(num11))))) < 0.05 Then
											Dim b5 As Byte
											If __Dereference((Me.KeyTimes + 128)) <> 0L Then
												b5 = 1
											Else
												b5 = 0
											End If
											<Module>.?QUnitCommandWithPoint@GGameLogic@@$$FQAEXW4GTargetTask@@MM_N@Z(<Module>.GameLogic, 2, num2, num4, b5 <> 0)
											Return
										End If
									End If
									Dim b6 As Byte
									If __Dereference((Me.KeyTimes + 128)) <> 0L Then
										b6 = 1
									Else
										b6 = 0
									End If
									Dim num12 As Single = num9
									Dim num13 As Single = num4 - Me.DragZ
									Dim num14 As Single = CSng(Math.Atan2(CDec(num12), CDec(num13)))
									<Module>.?QUnitCommandWithPointAndDir@GGameLogic@@$$FQAEXW4GTargetTask@@MMM_N@Z(<Module>.GameLogic, 2, Me.DragX, Me.DragZ, num14, b6 <> 0)
								End If
							Else
								Dim b7 As Byte
								If __Dereference((Me.KeyTimes + 128)) <> 0L Then
									b7 = 1
								Else
									b7 = 0
								End If
								<Module>.?QUnitCommandWithPoint@GGameLogic@@$$FQAEXW4GTargetTask@@MM_N@Z(<Module>.GameLogic, 7, num2, num4, b7 <> 0)
							End If
						Else
							Dim num9 As Single = num2 - Me.DragX
							Dim num15 As Single = num9
							If CDec((CSng(Math.Abs(CDec(num15))))) < 0.05 Then
								Dim num16 As Single = num4 - Me.DragZ
								If CDec((CSng(Math.Abs(CDec(num16))))) < 0.05 Then
									Dim b8 As Byte
									If __Dereference((Me.KeyTimes + 128)) <> 0L Then
										b8 = 1
									Else
										b8 = 0
									End If
									<Module>.GGameLogic.QMoveBackwardToPoint(<Module>.GameLogic, num2, num4, b8 <> 0)
									Return
								End If
							End If
							Dim b9 As Byte
							If __Dereference((Me.KeyTimes + 128)) <> 0L Then
								b9 = 1
							Else
								b9 = 0
							End If
							Dim num17 As Single = num9
							Dim num18 As Single = num4 - Me.DragZ
							Dim num19 As Single = CSng(Math.Atan2(CDec(num17), CDec(num18)))
							<Module>.GGameLogic.QMoveBackwardToPointWithDir(<Module>.GameLogic, Me.DragX, Me.DragZ, num19, b9 <> 0)
						End If
					Else
						Dim num9 As Single = num2 - Me.DragX
						Dim num20 As Single = num9
						If CDec((CSng(Math.Abs(CDec(num20))))) < 0.05 Then
							Dim num21 As Single = num4 - Me.DragZ
							If CDec((CSng(Math.Abs(CDec(num21))))) < 0.05 Then
								Dim b10 As Byte
								If __Dereference((Me.KeyTimes + 128)) <> 0L Then
									b10 = 1
								Else
									b10 = 0
								End If
								<Module>.?QUnitCommandWithPoint@GGameLogic@@$$FQAEXW4GTargetTask@@MM_N@Z(<Module>.GameLogic, 2, num2, num4, b10 <> 0)
								Return
							End If
						End If
						Dim b11 As Byte
						If __Dereference((Me.KeyTimes + 128)) <> 0L Then
							b11 = 1
						Else
							b11 = 0
						End If
						Dim num22 As Single = num9
						Dim num23 As Single = num4 - Me.DragZ
						Dim num24 As Single = CSng(Math.Atan2(CDec(num22), CDec(num23)))
						<Module>.?QUnitCommandWithPointAndDir@GGameLogic@@$$FQAEXW4GTargetTask@@MMM_N@Z(<Module>.GameLogic, 2, Me.DragX, Me.DragZ, num24, b11 <> 0)
					End If
				End If
			End If
		End Sub

		Private Sub menuFileNew_Click(sender As Object, e As EventArgs)
			If Me.SaveDocumentIfChanged() Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 8, True)
				nFileDialog.AvailableModes = 11
				nFileDialog.SelectedMode = 1
				nFileDialog.DefaultExtension = "map"
				If nFileDialog.ShowDialog() = DialogResult.OK Then
					If nFileDialog.SelectedMode = 1 Then
						Me.NewDocument(nFileDialog.NewWidht, nFileDialog.NewHeight)
					Else
						Me.OpenDocument(nFileDialog.FilePath)
						nFileDialog.UpdateRecentFiles()
						<Module>.SaveOptions()
					End If
				End If
			End If
		End Sub

		Private Sub menuFileOpen_Click(sender As Object, e As EventArgs)
			If Me.SaveDocumentIfChanged() Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 8, True)
				nFileDialog.AvailableModes = 11
				nFileDialog.SelectedMode = 2
				nFileDialog.DefaultExtension = "map"
				If nFileDialog.ShowDialog() = DialogResult.OK Then
					If nFileDialog.SelectedMode = 1 Then
						Me.NewDocument(nFileDialog.NewWidht, nFileDialog.NewHeight)
					Else
						Me.OpenDocument(nFileDialog.FilePath)
						nFileDialog.UpdateRecentFiles()
						<Module>.SaveOptions()
					End If
				End If
			End If
		End Sub

		Private Sub menuFileOpenRecent_Click(sender As Object, e As EventArgs)
			If Me.SaveDocumentIfChanged() Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 8, True)
				nFileDialog.AvailableModes = 11
				nFileDialog.SelectedMode = 8
				nFileDialog.DefaultExtension = "map"
				If nFileDialog.ShowDialog() = DialogResult.OK Then
					If nFileDialog.SelectedMode = 1 Then
						Me.NewDocument(nFileDialog.NewWidht, nFileDialog.NewHeight)
					Else
						Me.OpenDocument(nFileDialog.FilePath)
						nFileDialog.UpdateRecentFiles()
						<Module>.SaveOptions()
					End If
				End If
			End If
		End Sub

		Private Sub menuFileSave_Click(sender As Object, e As EventArgs)
			If Me.World IsNot Nothing Then
				If(If((__Dereference(CType((Me.MapFileName + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0), 1, 0)) <> 0 Then
					Me.menuFileSaveAs_Click(sender, e)
				Else
					Me.SaveDocument()
				End If
			End If
		End Sub

		Private Sub menuFileSaveAs_Click(sender As Object, e As EventArgs)
			If Me.World IsNot Nothing Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 8, True)
				nFileDialog.AvailableModes = 4
				nFileDialog.SelectedMode = 4
				nFileDialog.DefaultExtension = "map"
				If nFileDialog.ShowDialog() = DialogResult.OK Then
					<Module>.GBaseString<char>.=(Me.MapFileName, nFileDialog.FilePath)
					Me.SaveDocument()
					nFileDialog.UpdateRecentFiles()
					<Module>.SaveOptions()
				End If
			End If
		End Sub

		Private Sub menuFileExport_Click(sender As Object, e As EventArgs)
			If Me.World IsNot Nothing Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 20, True)
				nFileDialog.AvailableModes = 4
				nFileDialog.SelectedMode = 4
				nFileDialog.DefaultExtension = "xsimap"
				If nFileDialog.ShowDialog() = DialogResult.OK Then
					<Module>.GBaseString<char>.=(Me.ExportMapFileName, nFileDialog.FilePath)
					Me.ExportMap()
					nFileDialog.UpdateRecentFiles()
					<Module>.SaveOptions()
				End If
			End If
		End Sub

		Private Sub menuFileImportCam_Click(sender As Object, e As EventArgs)
			If Me.World IsNot Nothing Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 32, True)
				nFileDialog.AvailableModes = 2
				nFileDialog.SelectedMode = 2
				nFileDialog.DefaultExtension = "4dpcam"
				If nFileDialog.ShowDialog() = DialogResult.OK Then
					<Module>.GBaseString<char>.=(Me.ImportCamFileName, nFileDialog.FilePath)
					Me.ImportCamera()
					nFileDialog.UpdateRecentFiles()
					<Module>.SaveOptions()
				End If
			End If
		End Sub

		Private Sub menuFileRemoveImportCam_Click(sender As Object, e As EventArgs)
			Me.RemoveImportCamera()
		End Sub

		Private Sub menuFileExit_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub tbMain_ButtonClick(idx As Integer, radio_group As Integer)
			Me.TemporaryModeChange = False
			If radio_group = 1 Then
				Me.SetEditorMode(idx)
			Else If idx = 200 Then
				Me.menuFileNew_Click(Nothing, Nothing)
			Else If idx = 201 Then
				Me.menuFileOpen_Click(Nothing, Nothing)
			Else If idx = 202 Then
				Me.menuFileSave_Click(Nothing, Nothing)
			Else If idx = 207 Then
				Me.menuEditUndo_Click(Nothing, Nothing)
			Else If idx = 208 Then
				Me.menuEditRedo_Click(Nothing, Nothing)
			Else If idx = 203 Then
				Me.menuEditCut_Click(Nothing, Nothing)
			Else If idx = 204 Then
				Me.menuEditCopy_Click(Nothing, Nothing)
			Else If idx = 205 Then
				Me.menuEditPaste_Click(Nothing, Nothing)
			Else If idx = 206 Then
				Me.menuEditDelete_Click(Nothing, Nothing)
			Else If idx = 209 Then
				Me.menuToolsScriptEditor_Click(Nothing, Nothing)
			Else If idx = 210 Then
				Me.RunMap()
			Else If idx = 211 Then
				Me.DebugMap()
			End If
		End Sub

		Private Sub tbDebug_ButtonClick(idx As Integer, radio_group As Integer)
			Me.tbDebug.SetItemPushed(213, False)
			Me.tbDebug.SetItemPushed(214, False)
			Me.tbDebug.SetItemPushed(216, False)
			Me.tbDebug.SetItemPushed(217, False)
			If radio_group = 3 Then
				Me.SetDebugMode(idx)
			Else
				Select Case idx
					Case 212
						Me.EndDebugMap()
					Case 213
						Me.SetPlaySpeed(0)
						Me.tbDebug.SetItemPushed(213, True)
					Case 214
						Me.SetPlaySpeed(1)
						Me.tbDebug.SetItemPushed(214, True)
					Case 215
						If <Module>.GGameLogic.GetPlaySpeed(<Module>.GameLogic) Is Nothing Then
							<Module>.GGameLogic.RefreshMicroFrame(<Module>.GameLogic)
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), <Module>.Scene, 25000L, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 32)))
						Else
							Me.SetPlaySpeed(0)
						End If
						Me.tbDebug.SetItemPushed(213, True)
					Case 216
						Me.SetPlaySpeed(2)
						Me.tbDebug.SetItemPushed(216, True)
					Case 217
						Me.SetPlaySpeed(4)
						Me.tbDebug.SetItemPushed(217, True)
				End Select
			End If
		End Sub

		Private Sub OnIdle(sender As Object, e As EventArgs)
			If Me.LayoutChanged Then
				Me.RearrangeToolbars()
				Me.LayoutChanged = False
				MyBase.PerformLayout(Me.panSideBar, New String(CType((AddressOf <Module>.??_C@_06OJKCFPBI@Bounds?$AA@), __Pointer(Of SByte))))
				If Me.CurrentMinimap IsNot Nothing Then
					Me.RefreshMinimap()
				End If
			End If
			If MyBase.ContainsFocus Then
				Me.panMainViewport.Invalidate(False)
			End If
			Dim num As Long = <Module>.GTimer.GetTimeH(<Module>.Timer)
			If Me.LastCamViewPortUpdate = 0L Then
				Me.LastCamViewPortUpdate = num
			End If
			Dim elapsed As Long = num - Me.LastCamViewPortUpdate
			Me.LastCamViewPortUpdate = num
			Dim force_refresh As Byte = If((Me.EditorMode <> 16), 1, 0)
			Me.UpdateCameraCurvePreview(elapsed, force_refresh <> 0)
		End Sub

		Private Sub NMainForm_Load(sender As Object, e As EventArgs)
			<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), __Pointer(Of SByte)), 2173, CType((AddressOf <Module>.??_C@_0CF@NJHDLMN@NWorkshop?3?3NMainForm?3?3NMainForm_@), __Pointer(Of SByte)))
			<Module>.GLogger.Log(0, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.EnableMenuAndToolbarItems(False)
			<Module>.LoadOptions()
			If __Dereference((<Module>.Options + 4)) = 1 Then
				MyBase.SuspendLayout()
				Me.panSideBar.Dock = DockStyle.Right
				Me.splitMain.Dock = DockStyle.Right
				MyBase.ResumeLayout()
				Me.menuViewSidebarLeft.Checked = False
				Me.menuViewSidebarRight.Checked = True
				Me.menuViewSidebarOff.Checked = False
			Else If __Dereference((<Module>.Options + 4)) = 2 Then
				MyBase.SuspendLayout()
				Me.panSideBar.Visible = False
				Me.splitMain.Visible = False
				MyBase.ResumeLayout()
				Me.menuViewSidebarLeft.Checked = False
				Me.menuViewSidebarRight.Checked = False
				Me.menuViewSidebarOff.Checked = True
			End If
			If <Module>.Options Is Nothing Then
				Me.menuViewToolbar.Checked = False
				Me.tbMain.Visible = False
			End If
			If __Dereference((<Module>.Options + 1)) = 0 Then
				Me.menuViewStatusBar.Checked = False
				Me.sbMain.Visible = False
			End If
			Dim gEngineInitParams As GEngineInitParams
			<Module>.GEngineInitParams.{ctor}(gEngineInitParams)
			Dim gMeasures As GMeasures
			<Module>.GMeasures.{ctor}(gMeasures, <Module>.Measures, 1F)
			gEngineInitParams = Me.panMainViewport.Handle.ToPointer()
			__Dereference((gEngineInitParams + 4)) = __Dereference((<Module>.Options + 84))
			__Dereference((gEngineInitParams + 12)) = gMeasures
			<Module>.EngineInitialize(gEngineInitParams)
			Dim num As Integer = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 96)))
			Me.IRenderTarget = num
			Dim gHandle<19> As GHandle<19>
			num = calli(GHandle<19>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>*), num, gHandle<19>, __Dereference((__Dereference(num) + 16)))
			cpblk(Me.ND, num, 4)
			Dim iRenderTarget As __Pointer(Of GIRenderTarget) = Me.IRenderTarget
			Me.IViewport = calli(GIViewport* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), iRenderTarget, 0, __Dereference((__Dereference(CType(iRenderTarget, __Pointer(Of Integer))) + 32)))
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 34, 1, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 17, 1, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 10, 1, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			Dim num2 As Integer = __Dereference(CType(<Module>.IEngine, __Pointer(Of Integer)))
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 0, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, __Dereference((num2 + 32))), __Dereference((num2 + 16)))
			Dim gHandle<12> As GHandle<12>
			num2 = calli(GHandle<12>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>*,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, gHandle<12>, <Module>.??_C@_0BN@LLMEMFNI@menu?1fonts?1sans_serif_14?4gui?$AA@, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 128)))
			cpblk(Me.ND + 4 / __SizeOf(GNativeData), num2, 4)
			Dim gHandle<12>2 As GHandle<12>
			num2 = calli(GHandle<12>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>*,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, gHandle<12>2, <Module>.??_C@_0CA@EFIECEJB@menu?1fonts?1medium_shadow?4ttfont?$AA@, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 128)))
			cpblk(Me.ND + 8 / __SizeOf(GNativeData), num2, 4)
			Dim gHandle<12>3 As GHandle<12>
			num2 = calli(GHandle<12>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>*,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, gHandle<12>3, <Module>.??_C@_0BP@MPLAGJCI@menu?1fonts?1large_shadow?4ttfont?$AA@, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 128)))
			cpblk(Me.ND + 12 / __SizeOf(GNativeData), num2, 4)
			Dim gRect As GRect = 8
			__Dereference((gRect + 4)) = 8
			__Dereference((gRect + 8)) = 0
			__Dereference((gRect + 12)) = 0
			Dim gHandle<19>2 As GHandle<19>
			Dim num3 As Integer = calli(GHandle<19>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>*,System.Int32,GHandle<19>,GRect,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.ILayout, gHandle<19>2, 3, __Dereference(CType(Me.ND, __Pointer(Of GHandle<19>))), gRect, 5, __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))))))
			cpblk(Me.ND + 16 / __SizeOf(GNativeData), num3, 4)
			Dim gRect2 As GRect = 8
			__Dereference((gRect2 + 4)) = 26
			__Dereference((gRect2 + 8)) = 0
			__Dereference((gRect2 + 12)) = 0
			Dim gHandle<19>3 As GHandle<19>
			Dim num4 As Integer = calli(GHandle<19>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>*,System.Int32,GHandle<19>,GRect,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.ILayout, gHandle<19>3, 3, __Dereference(CType(Me.ND, __Pointer(Of GHandle<19>))), gRect2, 5, __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))))))
			cpblk(Me.ND + 20 / __SizeOf(GNativeData), num4, 4)
			Dim gRect3 As GRect = 8
			__Dereference((gRect3 + 4)) = 44
			__Dereference((gRect3 + 8)) = 0
			__Dereference((gRect3 + 12)) = 0
			Dim gHandle<19>4 As GHandle<19>
			Dim num5 As Integer = calli(GHandle<19>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>*,System.Int32,GHandle<19>,GRect,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), <Module>.ILayout, gHandle<19>4, 3, __Dereference(CType(Me.ND, __Pointer(Of GHandle<19>))), gRect3, 5, __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))))))
			cpblk(Me.ND + 24 / __SizeOf(GNativeData), num5, 4)
			Dim ptr As __Pointer(Of GUnitRegistry) = <Module>.new(60UI)
			Dim unitRegistry As __Pointer(Of GUnitRegistry)
			Try
				If ptr IsNot Nothing Then
					unitRegistry = <Module>.GUnitRegistry.{ctor}(ptr)
				Else
					unitRegistry = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			<Module>.UnitRegistry = unitRegistry
			AddHandler Application.Idle, AddressOf Me.OnIdle
			AddHandler Me.panMainViewport.MouseWheel, AddressOf Me.panMainViewport_MouseWheel
			AddHandler Me.panMainViewport.KeyDown, AddressOf Me.panMainViewport_KeyDown
			AddHandler Me.panMainViewport.KeyUp, AddressOf Me.panMainViewport_KeyUp
			Dim toolboxVertex As ToolboxVertex = New ToolboxVertex()
			Me.VertexTools = toolboxVertex
			toolboxVertex.Text = "Vertex"
			AddHandler Me.VertexTools.BrushTypeChanged, AddressOf Me.toolboxVertex_BrushTypeChanged
			AddHandler Me.VertexTools.BrushParametersChanged, AddressOf Me.toolboxVertex_BrushParametersChanged
			AddHandler Me.VertexTools.BrushFalloffTypeChanged, AddressOf Me.BrushFalloffTypeChanged
			AddHandler Me.VertexTools.VertexFlagChanged, AddressOf Me.BrushFlagChanged
			AddHandler Me.VertexTools.SelectionTypeChanged, AddressOf Me.SelectionTypeChanged
			AddHandler Me.VertexTools.InvertSelection, AddressOf Me.InvertSelection
			Dim extensions As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03MBBDFFBP@4dp?$AA@), __Pointer(Of SByte))), New String(CType((AddressOf <Module>.??_C@_02CCENMFAC@4d?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl As FilePickerControl = New FilePickerControl()
			Me.ObjectFilePicker = filePickerControl
			filePickerControl.Text = "Objects"
			Me.ObjectFilePicker.Root = "Objects"
			Me.ObjectFilePicker.ThumbRoot = "Objects"
			Me.ObjectFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.ObjectFilePicker.ThumbMode = ThumbnailServer.ThumbType.Model
			Me.ObjectFilePicker.Extensions = extensions
			AddHandler Me.ObjectFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			Me.ObjectTools = New ToolboxEntities(<Module>.NWorkshop.ObjectTools)
			AddHandler Me.ObjectTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.ObjectTools.FlagChanged, AddressOf Me.EntityFlagChanged
			Me.ObjectTools.Text = "Object manipulators"
			Dim extensions2 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BFLBBCNI@mat?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl2 As FilePickerControl = New FilePickerControl()
			Me.RoadFilePicker = filePickerControl2
			filePickerControl2.Text = "Roads"
			Me.RoadFilePicker.Root = "Roads"
			Me.RoadFilePicker.ThumbRoot = "Roads"
			Me.RoadFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.RoadFilePicker.ThumbMode = ThumbnailServer.ThumbType.Tile
			Me.RoadFilePicker.Extensions = extensions2
			AddHandler Me.RoadFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			Me.RoadTools = New ToolboxEntities(<Module>.NWorkshop.RoadTools)
			AddHandler Me.RoadTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.RoadTools.FlagChanged, AddressOf Me.EntityFlagChanged
			AddHandler Me.RoadTools.DecalAction, AddressOf Me.EntityDecalAction
			Me.RoadTools.Text = "Road manipulators"
			Me.NavPointTools = New ToolboxEntities(<Module>.NWorkshop.NavPointTools)
			AddHandler Me.NavPointTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.NavPointTools.FlagChanged, AddressOf Me.EntityFlagChanged
			Me.NavPointTools.Text = "Navigation point manipulators"
			Dim extensions3 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BFLBBCNI@mat?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl3 As FilePickerControl = New FilePickerControl()
			Me.DecalFilePicker = filePickerControl3
			filePickerControl3.Text = "Decals"
			Me.DecalFilePicker.Root = "Decals"
			Me.DecalFilePicker.ThumbRoot = "Decals"
			Me.DecalFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.DecalFilePicker.ThumbMode = ThumbnailServer.ThumbType.Material
			Me.DecalFilePicker.Extensions = extensions3
			AddHandler Me.DecalFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			Me.DecalTools = New ToolboxEntities(<Module>.NWorkshop.DecalTools)
			AddHandler Me.DecalTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.DecalTools.FlagChanged, AddressOf Me.EntityFlagChanged
			AddHandler Me.DecalTools.DecalAction, AddressOf Me.EntityDecalAction
			Me.DecalTools.Text = "Decal manipulators"
			Dim extensions4 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_05NGCECGPF@fluid?$AA@), __Pointer(Of SByte))), New String(CType((AddressOf <Module>.??_C@_03KJMBPJEB@fog?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl4 As FilePickerControl = New FilePickerControl()
			Me.LakeFilePicker = filePickerControl4
			filePickerControl4.Text = "Fluids"
			Me.LakeFilePicker.Root = "Water"
			Me.LakeFilePicker.ThumbRoot = "Water"
			Me.LakeFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.LakeFilePicker.ThumbMode = ThumbnailServer.ThumbType.Fluid
			Me.LakeFilePicker.Extensions = extensions4
			AddHandler Me.LakeFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			Me.LakeTools = New ToolboxEntities(<Module>.NWorkshop.LakeTools)
			AddHandler Me.LakeTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.LakeTools.FlagChanged, AddressOf Me.EntityFlagChanged
			Me.LakeTools.Text = "Lake manipulators"
			Dim extensions5 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_05NGCECGPF@fluid?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl5 As FilePickerControl = New FilePickerControl()
			Me.RiverFilePicker = filePickerControl5
			filePickerControl5.Text = "Fluids"
			Me.RiverFilePicker.Root = "Water"
			Me.RiverFilePicker.ThumbRoot = "Water"
			Me.RiverFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.RiverFilePicker.ThumbMode = ThumbnailServer.ThumbType.Fluid
			Me.RiverFilePicker.Extensions = extensions5
			AddHandler Me.RiverFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			Me.RiverTools = New ToolboxEntities(<Module>.NWorkshop.RiverTools)
			AddHandler Me.RiverTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.RiverTools.FlagChanged, AddressOf Me.EntityFlagChanged
			Me.RiverTools.Text = "River manipulators"
			Me.CameraCurveTools = New ToolboxEntities(<Module>.NWorkshop.CameraCurveTools)
			AddHandler Me.CameraCurveTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.CameraCurveTools.FlagChanged, AddressOf Me.EntityFlagChanged
			AddHandler Me.CameraCurveTools.Action, AddressOf Me.EntityAction
			Me.CameraCurveTools.Text = "CameraCurve manipulators"
			Dim toolboxScriptEntities As ToolboxScriptEntities = New ToolboxScriptEntities(2)
			Me.CameraCurveProps = toolboxScriptEntities
			toolboxScriptEntities.Text = "CameraCurve properties"
			Me.PathTools = New ToolboxEntities(<Module>.NWorkshop.PathTools)
			AddHandler Me.PathTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.PathTools.FlagChanged, AddressOf Me.EntityFlagChanged
			AddHandler Me.PathTools.Action, AddressOf Me.EntityAction
			Me.PathTools.Text = "Path manipulators"
			Dim toolboxScriptEntities2 As ToolboxScriptEntities = New ToolboxScriptEntities(0)
			Me.PathProps = toolboxScriptEntities2
			toolboxScriptEntities2.Text = "Path properties"
			Me.LocationTools = New ToolboxEntities(<Module>.NWorkshop.LocationTools)
			AddHandler Me.LocationTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.LocationTools.FlagChanged, AddressOf Me.EntityFlagChanged
			AddHandler Me.LocationTools.Action, AddressOf Me.EntityAction
			Me.LocationTools.Text = "Location manipulators"
			toolboxScriptEntities2 = New ToolboxScriptEntities(1)
			Me.LocationProps = toolboxScriptEntities2
			toolboxScriptEntities2.Text = "Location properties"
			toolboxScriptEntities2 = New ToolboxScriptEntities(3)
			Me.UnitGroupProps = toolboxScriptEntities2
			toolboxScriptEntities2.Text = "Unit AI group properties"
			Me.ObjectiveTools = New ToolboxEntities(<Module>.NWorkshop.ObjectiveTools)
			AddHandler Me.ObjectiveTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.ObjectiveTools.FlagChanged, AddressOf Me.EntityFlagChanged
			AddHandler Me.ObjectiveTools.Action, AddressOf Me.EntityAction
			Me.ObjectiveTools.Text = "Objective manipulators"
			toolboxScriptEntities2 = New ToolboxScriptEntities(6)
			Me.ObjectiveProps = toolboxScriptEntities2
			toolboxScriptEntities2.Text = "Objective properties"
			Dim extensions6 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_04NPEDKLDA@unit?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl6 As FilePickerControl = New FilePickerControl()
			Me.BuildingFilePicker = filePickerControl6
			filePickerControl6.Text = "Buildings"
			Me.BuildingFilePicker.Root = "Buildings"
			Me.BuildingFilePicker.ThumbRoot = "Buildings"
			Me.BuildingFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.BuildingFilePicker.ThumbMode = ThumbnailServer.ThumbType.Unit
			Me.BuildingFilePicker.Extensions = extensions6
			AddHandler Me.BuildingFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			AddHandler Me.BuildingFilePicker.ContextPopup, AddressOf Me.BuildingFilePicker_ContextPopup
			Me.BuildingTools = New ToolboxEntities(<Module>.NWorkshop.BuildingTools)
			AddHandler Me.BuildingTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.BuildingTools.FlagChanged, AddressOf Me.EntityFlagChanged
			Me.BuildingTools.Text = "Building manipulators"
			Dim toolboxBuildingProperties As ToolboxBuildingProperties = New ToolboxBuildingProperties()
			Me.BuildingPropertiesTools = toolboxBuildingProperties
			toolboxBuildingProperties.Text = "Building properties"
			AddHandler Me.BuildingPropertiesTools.PropertiesChanged, AddressOf Me.toolboxUnitProperties_PropertiesChanged
			Dim extensions7 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_04NPEDKLDA@unit?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl7 As FilePickerControl = New FilePickerControl()
			Me.UnitFilePicker = filePickerControl7
			filePickerControl7.Text = "Units"
			Me.UnitFilePicker.Root = "Units"
			Me.UnitFilePicker.ThumbRoot = "Units"
			Me.UnitFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.UnitFilePicker.ThumbMode = ThumbnailServer.ThumbType.Unit
			Me.UnitFilePicker.Extensions = extensions7
			AddHandler Me.UnitFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			AddHandler Me.UnitFilePicker.ContextPopup, AddressOf Me.UnitFilePicker_ContextPopup
			Me.UnitTools = New ToolboxEntities(<Module>.NWorkshop.UnitTools)
			AddHandler Me.UnitTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.UnitTools.FlagChanged, AddressOf Me.EntityFlagChanged
			Me.UnitTools.Text = "Unit manipulators"
			Dim toolboxPlayer As ToolboxPlayer = New ToolboxPlayer()
			Me.PlayerTools = toolboxPlayer
			toolboxPlayer.Text = "Player selection"
			AddHandler Me.PlayerTools.PlayerChanged, AddressOf Me.toolboxPlayer_PlayerChanged
			AddHandler Me.PlayerTools.EditPlayerProperties, AddressOf Me.toolboxPlayer_EditPlayerProperties
			Dim toolboxUnitProperties As ToolboxUnitProperties = New ToolboxUnitProperties()
			Me.UnitPropertiesTools = toolboxUnitProperties
			toolboxUnitProperties.Text = "Unit properties"
			AddHandler Me.UnitPropertiesTools.PropertiesChanged, AddressOf Me.toolboxUnitProperties_PropertiesChanged
			Dim extensions8 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BICDMHKB@wav?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl8 As FilePickerControl = New FilePickerControl()
			Me.SoundFilePicker = filePickerControl8
			filePickerControl8.Text = "Sounds"
			Me.SoundFilePicker.Root = "Sounds"
			Me.SoundFilePicker.ThumbRoot = "Sounds"
			Me.SoundFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.SoundFilePicker.ThumbMode = ThumbnailServer.ThumbType.Sound
			Me.SoundFilePicker.Extensions = extensions8
			AddHandler Me.SoundFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			Me.SoundTools = New ToolboxEntities(<Module>.NWorkshop.SoundTools)
			AddHandler Me.SoundTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.SoundTools.FlagChanged, AddressOf Me.EntityFlagChanged
			Me.SoundTools.Text = "Sound manipulators"
			Dim extensions9 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_02KLACGCIB@fx?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl9 As FilePickerControl = New FilePickerControl()
			Me.EffectFilePicker = filePickerControl9
			filePickerControl9.Text = "Effects"
			Me.EffectFilePicker.Root = "Effects"
			Me.EffectFilePicker.ThumbRoot = "Effects"
			Me.EffectFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.EffectFilePicker.ThumbMode = ThumbnailServer.ThumbType.Effect
			Me.EffectFilePicker.Extensions = extensions9
			AddHandler Me.EffectFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			Me.EffectTools = New ToolboxEntities(<Module>.NWorkshop.EffectTools)
			AddHandler Me.EffectTools.ModeChanged, AddressOf Me.EntityModeChanged
			AddHandler Me.EffectTools.FlagChanged, AddressOf Me.EntityFlagChanged
			Me.EffectTools.Text = "Effect manipulators"
			Dim extensions10 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03KCBANMCB@loc?$AA@), __Pointer(Of SByte))) }
			Dim filePickerControl10 As FilePickerControl = New FilePickerControl()
			Me.LocaleFilePicker = filePickerControl10
			filePickerControl10.Text = "Locals"
			Me.LocaleFilePicker.Root = "Locals"
			Me.LocaleFilePicker.ThumbRoot = "Locals"
			Me.LocaleFilePicker.ViewMode = FilePickerControl.Mode.Treeview
			Me.LocaleFilePicker.ThumbMode = ThumbnailServer.ThumbType.Locale
			Me.LocaleFilePicker.Extensions = extensions10
			AddHandler Me.LocaleFilePicker.SingleClickSelection, AddressOf Me.FileSelectedSingle
			Dim toolboxTerrain As ToolboxTerrain = New ToolboxTerrain()
			Me.TerrainFilePicker = toolboxTerrain
			toolboxTerrain.Text = "Terrain layers"
			AddHandler Me.TerrainFilePicker.LayerSelected, AddressOf Me.SetAffectedLayer
			AddHandler Me.TerrainFilePicker.ResetToPaint, AddressOf Me.ResetTerrainTool
			AddHandler Me.TerrainFilePicker.GUINeedRefreshEvent, AddressOf Me.RefreshMenuAndToolbarItems
			Dim toolboxTerrainTools As ToolboxTerrainTools = New ToolboxTerrainTools()
			Me.TerrainTools = toolboxTerrainTools
			toolboxTerrainTools.Text = "Terrain layer manipulators"
			AddHandler Me.TerrainTools.PaintTypeChanged, AddressOf Me.toolboxPainter_BrushTypeChanged
			AddHandler Me.TerrainTools.BrushParametersChanged, AddressOf Me.toolboxPainter_BrushParametersChanged
			AddHandler Me.TerrainTools.FillSelection, AddressOf Me.FillSelection
			AddHandler Me.TerrainTools.BrushColorChanged, AddressOf Me.toolboxPainter_BrushColorChanged
			Dim toolboxSectors As ToolboxSectors = New ToolboxSectors()
			Me.SectorTools = toolboxSectors
			toolboxSectors.Text = "Sector manipulators"
			AddHandler Me.SectorTools.Action, AddressOf Me.toolboxSectors_OperationActivated
			Dim toolboxWeather As ToolboxWeather = New ToolboxWeather()
			Me.WeatherTools = toolboxWeather
			toolboxWeather.Text = "Weather"
			AddHandler Me.WeatherTools.ValueChanged, AddressOf Me.toolboxWeather_ValueChanged
			Dim toolboxOptions As ToolboxOptions = New ToolboxOptions()
			Me.OptionsTools = toolboxOptions
			toolboxOptions.Text = "Options"
			AddHandler Me.OptionsTools.OptionsChanged, AddressOf Me.toolboxOptions_OptionsChanged
			Dim nDebuggerLog As NDebuggerLog = New NDebuggerLog()
			Me.LoggerTool = nDebuggerLog
			nDebuggerLog.Text = "Log"
			Dim nDebuggerUnits As NDebuggerUnits = New NDebuggerUnits()
			Me.DUnitsTool = nDebuggerUnits
			nDebuggerUnits.Text = "Unit debugger"
			Dim nDebuggerUnitGroups As NDebuggerUnitGroups = New NDebuggerUnitGroups()
			Me.DUnitGroupsTool = nDebuggerUnitGroups
			nDebuggerUnitGroups.Text = "AI goup debugger"
			Dim nDebuggerTriggers As NDebuggerTriggers = New NDebuggerTriggers()
			Me.DTriggersTool = nDebuggerTriggers
			nDebuggerTriggers.Text = "Trigger debugger"
			Dim nDebuggerGVars As NDebuggerGVars = New NDebuggerGVars()
			Me.DGVarsTool = nDebuggerGVars
			nDebuggerGVars.Text = "Global variables"
			Dim nDebuggerControlPanel As NDebuggerControlPanel = New NDebuggerControlPanel()
			Me.DControlPanel = nDebuggerControlPanel
			nDebuggerControlPanel.Text = "Game panel"
			Dim toolboxContainer As ToolboxContainer = New ToolboxContainer()
			Me.VertexToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.VertexTools)
			AddHandler Me.VertexToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.ObjectFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.ObjectFilePicker)
			Me.ObjectFileContainer.Autosize = True
			AddHandler Me.ObjectFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.ObjectToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.ObjectTools)
			AddHandler Me.ObjectToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.RoadFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.RoadFilePicker)
			Me.RoadFileContainer.Autosize = True
			AddHandler Me.RoadFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.RoadToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.RoadTools)
			AddHandler Me.RoadToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.NavPointToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.NavPointTools)
			AddHandler Me.NavPointToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.DecalFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.DecalFilePicker)
			Me.DecalFileContainer.Autosize = True
			AddHandler Me.DecalFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.DecalToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.DecalTools)
			AddHandler Me.DecalToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.LakeFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.LakeFilePicker)
			Me.LakeFileContainer.Autosize = True
			AddHandler Me.LakeFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.LakeToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.LakeTools)
			AddHandler Me.LakeToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.RiverFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.RiverFilePicker)
			Me.RiverFileContainer.Autosize = True
			AddHandler Me.RiverFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.RiverToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.RiverTools)
			AddHandler Me.RiverToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.CameraCurveToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.CameraCurveTools)
			AddHandler Me.CameraCurveToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.CameraCurvePropsContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.CameraCurveProps)
			AddHandler Me.CameraCurvePropsContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.PathToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.PathTools)
			AddHandler Me.PathToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.PathPropsContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.PathProps)
			AddHandler Me.PathPropsContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.LocationToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.LocationTools)
			AddHandler Me.LocationToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.LocationPropsContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.LocationProps)
			AddHandler Me.LocationPropsContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.UnitGroupPropsContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.UnitGroupProps)
			AddHandler Me.UnitGroupPropsContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.ObjectiveToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.ObjectiveTools)
			AddHandler Me.ObjectiveToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.ObjectivePropsContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.ObjectiveProps)
			AddHandler Me.ObjectivePropsContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.BuildingFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.BuildingFilePicker)
			Me.BuildingFileContainer.Autosize = True
			AddHandler Me.BuildingFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.BuildingToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.BuildingTools)
			AddHandler Me.BuildingToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.BuildingPropertiesContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.BuildingPropertiesTools)
			Me.BuildingPropertiesContainer.Open = False
			AddHandler Me.BuildingPropertiesContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.UnitFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.UnitFilePicker)
			Me.UnitFileContainer.Autosize = True
			AddHandler Me.UnitFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.UnitToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.UnitTools)
			AddHandler Me.UnitToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.PlayerContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.PlayerTools)
			Me.PlayerContainer.Open = False
			AddHandler Me.PlayerContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.UnitPropertiesContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.UnitPropertiesTools)
			Me.UnitPropertiesContainer.Open = False
			AddHandler Me.UnitPropertiesContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.SoundFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.SoundFilePicker)
			Me.SoundFileContainer.Autosize = True
			AddHandler Me.SoundFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.SoundToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.SoundTools)
			AddHandler Me.SoundToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.EffectFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.EffectFilePicker)
			Me.EffectFileContainer.Autosize = True
			AddHandler Me.EffectFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.EffectToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.EffectTools)
			AddHandler Me.EffectToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.TerrainFileContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.TerrainFilePicker)
			Me.TerrainFileContainer.Autosize = True
			AddHandler Me.TerrainFileContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.TerrainToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.TerrainTools)
			AddHandler Me.TerrainToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.SectorToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.SectorTools)
			AddHandler Me.SectorToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.WeatherToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.WeatherTools)
			AddHandler Me.WeatherToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.OptionToolContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.OptionsTools)
			AddHandler Me.OptionToolContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.LoggerContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.LoggerTool)
			AddHandler Me.LoggerContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.DUnitsContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.DUnitsTool)
			AddHandler Me.DUnitsContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.DUnitGroupsContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.DUnitGroupsTool)
			AddHandler Me.DUnitGroupsContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.DTriggersContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.DTriggersTool)
			AddHandler Me.DTriggersContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer = New ToolboxContainer()
			Me.DGVarsContainer = toolboxContainer
			toolboxContainer.AddToolbox(Me.DGVarsTool)
			AddHandler Me.DGVarsContainer.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			Me.LogControlPanel = New ToolboxContainer()
			AddHandler Me.LogControlPanel.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			Me.UnitsControlPanel = New ToolboxContainer()
			AddHandler Me.UnitsControlPanel.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			Me.UnitGroupsControlPanel = New ToolboxContainer()
			AddHandler Me.UnitGroupsControlPanel.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			Me.TriggersControlPanel = New ToolboxContainer()
			AddHandler Me.TriggersControlPanel.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			Dim minimap As Minimap = New Minimap()
			Me.MinimapPanel = minimap
			minimap.Text = "Minimap"
			AddHandler Me.MinimapPanel.MapNeedsRefresh, AddressOf Me.MinimapNeedsRefresh
			AddHandler Me.MinimapPanel.CameraMove, AddressOf Me.MinimapMovesCamera
			AddHandler Me.MinimapPanel.CameraRotate, AddressOf Me.MinimapRotatesCamera
			Me.VertexMinimap = New ToolboxContainer()
			AddHandler Me.VertexMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			Dim toolboxContainer2 As ToolboxContainer = New ToolboxContainer()
			Me.ObjectsMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.ObjectsMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.RoadsMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.RoadsMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.NavPointsMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.NavPointsMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.DecalsMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.DecalsMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.LakeMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.LakeMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.RiverMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.RiverMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.CameraCurveMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.CameraCurveMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.PathMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.PathMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.LocationMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.LocationMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.UnitGroupMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.UnitGroupMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.BuildingMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.BuildingMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.UnitMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.UnitMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.SoundMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.SoundMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.EffectMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.EffectMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			toolboxContainer2 = New ToolboxContainer()
			Me.TerrainMinimap = toolboxContainer2
			toolboxContainer2.Open = False
			AddHandler Me.TerrainMinimap.OpenStateToggledEvent, AddressOf Me.panSideBarToolStateToggled
			If Me.OpenFileName.Length > 0 Then
				Me.OpenDocument(Me.OpenFileName)
			Else If __Dereference((<Module>.Options + 12)) <> 0 Then
				Me.menuFileOpenRecent_Click(sender, e)
			Else
				Me.menuFileOpen_Click(sender, e)
			End If
		End Sub

		Private Sub NMainForm_Activated(sender As Object, e As EventArgs)
			If <Module>.IEngine IsNot Nothing Then
				Dim expr_0C As __Pointer(Of GIEngine) = <Module>.IEngine
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_0C, __Dereference((__Dereference(CType(expr_0C, __Pointer(Of Integer))) + 244)))
			End If
		End Sub

		Private Sub FileSelectedSingle(FileName As String)
			<Module>.GBaseString<char>.=(__Dereference((Me.EntityType * 4 + Me.EntityName)), FileName)
			Me.StartEntityPreCreate()
		End Sub

		Private Sub EntityModeChanged(mode As Integer)
			Me.CancelDepressedDrag(False)
			If mode = 256 Then
				<Module>.GEditorWorld.ResetSelectedObjectHeights(Me.World)
				Me.CurrentEntityToolbar.EmulatePushByID(1)
				Me.CurrentEntityToolbar.EmulateUpByID(1)
			Else
				__Dereference((Me.EntityType * 4 + Me.EntityOperation)) = mode
				If mode = 2 Then
					Dim entityType As Integer = Me.EntityType
					Select Case entityType
						Case 13
							Dim gBaseString<char> As GBaseString<char>
							Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr2 As __Pointer(Of GBaseString<char>)
							Dim world As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>2 As GBaseString<char>
								ptr2 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
								Try
									world = Me.World
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>3 As GBaseString<char>
							Dim src As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world, AddressOf gBaseString<char>3, 2, ptr2, -1, ptr)
							Try
								<Module>.GBaseString<char>.=(__Dereference((Me.EntityType * 4 + Me.EntityName)), src)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>3 IsNot Nothing Then
								<Module>.free(gBaseString<char>3)
							End If
						Case 15
							Dim gBaseString<char>4 As GBaseString<char>
							Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>4, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr4 As __Pointer(Of GBaseString<char>)
							Dim world2 As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>5 As GBaseString<char>
								ptr4 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>5, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
								Try
									world2 = Me.World
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>6 As GBaseString<char>
							Dim src2 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world2, AddressOf gBaseString<char>6, 0, ptr4, -1, ptr3)
							Try
								<Module>.GBaseString<char>.=(__Dereference((Me.EntityType * 4 + Me.EntityName)), src2)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>6 IsNot Nothing Then
								<Module>.free(gBaseString<char>6)
							End If
						Case 17
							Dim gBaseString<char>7 As GBaseString<char>
							Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>7, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
							Dim ptr6 As __Pointer(Of GBaseString<char>)
							Dim world3 As __Pointer(Of GEditorWorld)
							Try
								Dim gBaseString<char>8 As GBaseString<char>
								ptr6 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>8, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
								Try
									world3 = Me.World
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>8), __Pointer(Of Void)))
									Throw
								End Try
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>7), __Pointer(Of Void)))
								Throw
							End Try
							Dim gBaseString<char>9 As GBaseString<char>
							Dim src3 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world3, AddressOf gBaseString<char>9, 1, ptr6, -1, ptr5)
							Try
								<Module>.GBaseString<char>.=(__Dereference((Me.EntityType * 4 + Me.EntityName)), src3)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>9), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>9 IsNot Nothing Then
								<Module>.free(gBaseString<char>9)
							End If
						Case 19
							<Module>.GBaseString<char>.=(__Dereference((entityType * 4 + Me.EntityName)), CType((AddressOf <Module>.??_C@_08MDCLHJPM@Navpoint?$AA@), __Pointer(Of SByte)))
					End Select
				Else If mode = 4 Then
					Me.StartEntityPreCreateNode()
					GoTo IL_285
				End If
				If __Dereference((__Dereference((Me.EntityType * 4 + Me.EntityName)) + 4)) > 0 AndAlso mode = 2 Then
					Me.StartEntityPreCreate()
				End If
				IL_285:
				Dim currentScriptEnittyToolbar As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
				If currentScriptEnittyToolbar IsNot Nothing Then
					currentScriptEnittyToolbar.RefreshEntityList()
				End If
			End If
		End Sub

		Private Sub EntityDecalAction(operation As Integer)
			<Module>.?TransformSelectedDecals@GEditorWorld@@$$FQAEXW4GDecalOp@@@Z(Me.World, operation)
			Me.RefreshMenuAndToolbarItems()
			Me.RefreshMinimap()
		End Sub

		Private Sub EntityAction(operation As Integer)
			Select Case operation
				Case 400
					If MessageBox.Show("Are you sure you want to clear the script entities from the map?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
						Dim scriptEditorFormInstance As ScriptEditorForm = Me.ScriptEditorFormInstance
						If scriptEditorFormInstance IsNot Nothing Then
							scriptEditorFormInstance.Close()
						End If
						__Dereference(CType((Me.World + 5080 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = 0
						<Module>.GEditorWorld.ClearScriptEntities(Me.World, True)
						Me.RefreshMenuAndToolbarItems()
					End If
				Case 401
					Me.SaveScripts()
				Case 402
					If MessageBox.Show("Are you sure you want to replace the script entities on the map?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
						Dim scriptEditorFormInstance2 As ScriptEditorForm = Me.ScriptEditorFormInstance
						If scriptEditorFormInstance2 IsNot Nothing Then
							scriptEditorFormInstance2.Close()
						End If
						__Dereference(CType((Me.World + 5080 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = 0
						Me.LoadScripts()
					End If
				Case 403
					<Module>.GEditorWorld.CreateObjective(Me.World)
					Me.RefreshMenuAndToolbarItems()
				Case 404
					<Module>.GEditorWorld.DeleteObjective(Me.World, Me.CurrentScriptEnittyToolbar.SelectedEntityIndex)
					Me.RefreshMenuAndToolbarItems()
			End Select
		End Sub

		Private Sub EntityFlagChanged(flag As FlagType, <MarshalAs(UnmanagedType.U1)> value As Boolean)
			Select Case flag
				Case FlagType.SNAP_ANGLE
					__Dereference((Me.EntityAlignRotate + Me.EntityType)) = (If(value, 1, 0))
				Case FlagType.SNAP_TO_GRID
					__Dereference((Me.EntityAlignMove + Me.EntityType)) = (If(value, 1, 0))
				Case FlagType.RANDOM_ORIENTATION
					__Dereference((Me.EntityRandomAngle + Me.EntityType)) = (If(value, 1, 0))
				Case FlagType.LOCK_SELECTION
					__Dereference((Me.EntityLockSelection + Me.EntityType)) = (If(value, 1, 0))
					If Not value Then
						Dim world As __Pointer(Of GEditorWorld) = Me.World
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world, Me.EntityType, 0, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 12)))
					End If
				Case FlagType.LOCK_HEIGHTS
					__Dereference((Me.EntityLockHeights + Me.EntityType)) = (If(value, 1, 0))
			End Select
		End Sub

		Private Sub toolboxUnitProperties_PropertiesChanged(stats As __Pointer(Of GUnitStats))
			<Module>.GEditorWorld.StartWUnitPropertiesChange(Me.World)
			<Module>.GEditorWorld.SetSelectedWUnitStats(Me.World, stats)
			Dim num As Integer = -1
			While True
				Dim ptr As __Pointer(Of GEditorWorld) = Me.World + 2884 / __SizeOf(GEditorWorld)
				Dim ptr2 As __Pointer(Of GHeap<GWUnit>) = ptr
				Dim num2 As Integer = num + 1
				Dim num3 As Integer = __Dereference((ptr2 + 4))
				If num2 >= num3 Then
					Exit While
				End If
				Dim num4 As Integer = num2 * 124 + __Dereference(ptr2)
				While __Dereference(num4) <> 2147483647
					num2 += 1
					num4 += 124
					If num2 >= num3 Then
						GoTo IL_76
					End If
				End While
				num = num2
				If num2 < 0 Then
					Exit While
				End If
				Dim expr_6A As Integer = __Dereference(CType(ptr, __Pointer(Of Integer))) + num2 * 124 + 4
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_6A, __Dereference((__Dereference(expr_6A) + 8)))
			End While
			IL_76:
			Me.MinimapUnitsNeedUpdate = True
			<Module>.GEditorWorld.CompleteWUnitPropertiesChange(Me.World)
		End Sub

		Private Sub toolboxPlayer_PlayerChanged(player As Integer)
			<Module>.GEditorWorld.SetActualPlayer(Me.World, player)
		End Sub

		Private Sub toolboxPlayer_EditPlayerProperties(player_idx As Integer)
			Dim playerForm As PlayerForm = New PlayerForm()
			playerForm.StartPosition = FormStartPosition.CenterScreen
			Dim num As Integer = player_idx * 160
			playerForm.comboBoxColor.SelectedIndex = __Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 284 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
			playerForm.SetTeam(__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 300 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))))
			playerForm.SetRace(__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 288 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))))
			playerForm.SetControl(__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 292 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))))
			playerForm.SetTargetElector(__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 304 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))))
			playerForm.Money = __Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 352 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
			If playerForm.ShowDialog() = DialogResult.OK Then
				__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 284 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = playerForm.comboBoxColor.SelectedIndex
				__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 300 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = playerForm.GetTeam()
				__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 288 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = playerForm.GetRace()
				__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 292 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = playerForm.GetControl()
				__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 304 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = playerForm.GetTargetElector()
				Dim money As Integer = playerForm.Money
				__Dereference(CType((num / __SizeOf(GEditorWorld) + Me.World + 352 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = money
				Me.PlayerTools.InitItems(CType(Me.World, __Pointer(Of GWorld)))
			End If
		End Sub

		Private Sub toolboxVertex_BrushTypeChanged(e As Integer)
			Me.TemporaryModeChange = False
			Me.BrushType = e
			Me.SetViewType()
			Dim size As Size = Me.panMainViewport.Size
			Dim size2 As Size = Me.panMainViewport.Size
			Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
			Dim gRay As GRay
			Dim x As Single
			Dim num2 As Single
			Dim z As Single
			<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, size2.Width / 2, size.Height / 2, __Dereference(num)), x, num2, z)
			Me.VisualizeBrush(x, z)
			Me.UpdateBrushSliders()
		End Sub

		Private Sub BrushFalloffTypeChanged(newtype As Integer)
			If Me.EditorMode = 1 Then
				If Me.propBrushType < 20 Then
					Me.VertexFalloffType = newtype
				Else
					Me.SelectionFalloffType = newtype
				End If
			End If
			Dim size As Size = Me.panMainViewport.Size
			Dim size2 As Size = Me.panMainViewport.Size
			Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
			Dim gRay As GRay
			Dim x As Single
			Dim num2 As Single
			Dim z As Single
			<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, size2.Width / 2, size.Height / 2, __Dereference(num)), x, num2, z)
			Me.VisualizeBrush(x, z)
			Me.UpdateBrushSliders()
		End Sub

		Private Sub BrushFlagChanged(flag As Integer, <MarshalAs(UnmanagedType.U1)> value As Boolean)
			If flag <> 200 Then
				If flag = 201 Then
					__Dereference(CType((Me.Terraformer + 9 / __SizeOf(GTerraformer)), __Pointer(Of Byte))) = (If(value, 1, 0))
				End If
			Else If Me.EditorMode = 1 Then
				If Me.propBrushType < 20 Then
					__Dereference(CType((Me.Terraformer + 8 / __SizeOf(GTerraformer)), __Pointer(Of Byte))) = (If(value, 1, 0))
				Else
					Me.SelectionAdditiveMode = value
				End If
			End If
		End Sub

		Private Sub toolboxVertex_BrushParametersChanged(size1 As Single, size2 As Single, pressure As Single, height As Single)
			Me.BrushSize = size1
			Me.BrushSize2 = size2
			Me.BrushPressure = pressure
			Me.BrushHeight = height
			Dim size3 As Size = Me.panMainViewport.Size
			Dim size4 As Size = Me.panMainViewport.Size
			Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
			Dim gRay As GRay
			Dim x As Single
			Dim num2 As Single
			Dim z As Single
			<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, size4.Width / 2, size3.Height / 2, __Dereference(num)), x, num2, z)
			Me.VisualizeBrush(x, z)
			Me.UpdateBrushSliders()
		End Sub

		Private Sub toolboxPainter_BrushTypeChanged(e As Integer)
			Me.TemporaryModeChange = False
			Me.PaintType = e
			Me.SetViewType()
			Me.UpdateBrushSliders()
		End Sub

		Private Sub toolboxPainter_BrushParametersChanged(size1 As Single, size2 As Single, pressure As Single, height As Single)
			Me.BrushSize = size1
			Me.BrushSize2 = size2
			Me.BrushPressure = pressure
			Dim size3 As Size = Me.panMainViewport.Size
			Dim size4 As Size = Me.panMainViewport.Size
			Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
			Dim gRay As GRay
			Dim x As Single
			Dim num2 As Single
			Dim z As Single
			<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, size4.Width / 2, size3.Height / 2, __Dereference(num)), x, num2, z)
			Me.VisualizeBrush(x, z)
			Me.UpdateBrushSliders()
		End Sub

		Private Sub toolboxPainter_BrushColorChanged(newcolor As UInteger)
			Dim gColor As GColor = (newcolor >> 16 And 255) * 0.003921569F
			__Dereference((gColor + 4)) = (newcolor >> 8 And 255) * 0.003921569F
			__Dereference((gColor + 8)) = (newcolor And 255) * 0.003921569F
			__Dereference((gColor + 12)) = (newcolor >> 24) * 0.003921569F
			cpblk(Me.Terraformer + 16 / __SizeOf(GTerraformer), gColor, 16)
		End Sub

		Private Sub SelectionTypeChanged(newtype As Integer)
			Me.propBrushType = newtype
			Me.VertexTools.ResetToNone()
			Me.VertexTools.FalloffType = Me.SelectionFalloffType
			Me.VertexTools.AdditiveMode = Me.SelectionAdditiveMode
			Me.SetViewType()
			Dim size As Size = Me.panMainViewport.Size
			Dim size2 As Size = Me.panMainViewport.Size
			Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
			Dim gRay As GRay
			Dim x As Single
			Dim num2 As Single
			Dim z As Single
			<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, size2.Width / 2, size.Height / 2, __Dereference(num)), x, num2, z)
			Me.VisualizeBrush(x, z)
			Me.UpdateBrushSliders()
		End Sub

		Private Sub InvertSelection()
			<Module>.GEditorWorld.InvertSelection(Me.World)
			Me.RefreshMenuAndToolbarItems()
			Me.RefreshMinimap()
		End Sub

		Private Sub FillSelection(filltype As Integer)
			Me.RefreshTerraformer()
			__Dereference(CType(Me.Terraformer, __Pointer(Of Integer))) = filltype
			<Module>.GEditorWorld.StartTerraforming(Me.World, Me.Terraformer)
			Me.RefreshMenuAndToolbarItems()
			Me.RefreshMinimap()
		End Sub

		Private Sub toolboxSectors_OperationActivated(op As Integer, info As String)
			Select Case op
				Case 0
					<Module>.GEditorWorld.AddSelectedParcels(Me.World)
				Case 1
					<Module>.GEditorWorld.RemoveSelectedParcels(Me.World)
				Case 2
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, info)
					Try
						Dim num As UInteger = CUInt((__Dereference(ptr)))
						Dim ptr2 As __Pointer(Of SByte)
						If num <> 0UI Then
							ptr2 = num
						Else
							ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						<Module>.GWorld.SetSketchTexture(Me.World, ptr2)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
				Case 3
					<Module>.GWorld.ShiftSketch(Me.World, 0, -1)
				Case 4
					<Module>.GWorld.ShiftSketch(Me.World, 0, 1)
				Case 5
					<Module>.GWorld.ShiftSketch(Me.World, 1, 0)
				Case 6
					<Module>.GWorld.ShiftSketch(Me.World, -1, 0)
				Case 7
					<Module>.GWorld.ShiftSketch(Me.World, 0, -16)
				Case 8
					<Module>.GWorld.ShiftSketch(Me.World, 0, 16)
				Case 9
					<Module>.GWorld.ShiftSketch(Me.World, 16, 0)
				Case 10
					<Module>.GWorld.ShiftSketch(Me.World, -16, 0)
			End Select
			Me.RefreshSectorSelection()
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub toolboxOptions_OptionsChanged()
			Me.SetViewType()
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing AndAlso <Module>.GWorld.GetBlockMapMode(world) <> __Dereference((<Module>.Options + 76)) Then
				<Module>.GWorld.SetBlockMapMode(Me.World, __Dereference((<Module>.Options + 76)) <> 0)
				Me.RefreshMinimap()
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 17, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 77)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 17, __Dereference((<Module>.Options + 77)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 28, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 79)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 28, __Dereference((<Module>.Options + 79)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 11, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 80)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 11, __Dereference((<Module>.Options + 80)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 12, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 81)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 12, __Dereference((<Module>.Options + 81)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 13, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 88)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 13, __Dereference((<Module>.Options + 88)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 14, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 92)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 14, __Dereference((<Module>.Options + 92)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 30, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 112)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 30, __Dereference((<Module>.Options + 112)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) AndAlso __Dereference((<Module>.Options + 93)) = 0 Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 0, 0, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If Not calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) AndAlso __Dereference((<Module>.Options + 93)) <> 0 Then
				Dim num As Integer = __Dereference(CType(<Module>.IEngine, __Pointer(Of Integer)))
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 0, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, __Dereference((num + 32))), __Dereference((num + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 21, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 94)) Then
				Dim num2 As Integer = __Dereference(CType(<Module>.IEngine, __Pointer(Of Integer)))
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 21, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 2, __Dereference((num2 + 32))) * __Dereference((<Module>.Options + 94)), __Dereference((num2 + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 22, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 96)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 22, __Dereference((<Module>.Options + 96)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 27, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 108)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 27, __Dereference((<Module>.Options + 108)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 29, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 109)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 29, __Dereference((<Module>.Options + 109)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 18, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 100)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 18, __Dereference((<Module>.Options + 100)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 23, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 104)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 23, __Dereference((<Module>.Options + 104)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 33, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) <> __Dereference((<Module>.Options + 116)) Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 33, __Dereference((<Module>.Options + 116)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
			End If
			Dim num3 As Integer = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 96)))
			Dim flag As Boolean
			Dim num4 As Integer
			Dim num5 As Integer
			Dim num6 As Integer
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Boolean* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), num3, flag, num4, num5, num6, __Dereference((__Dereference(num3))))
			If num6 <> __Dereference((<Module>.Options + 84)) Then
				Dim num7 As Integer = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 0, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 96)))
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), num7, 0, 0, __Dereference((<Module>.Options + 84)), __Dereference((__Dereference(num7) + 4)))
			End If
			<Module>.SaveOptions()
		End Sub

		Private Sub toolboxWeather_ValueChanged(weather As __Pointer(Of GWWeather))
			<Module>.GEditorWorld.SetWeather(Me.World, -1, weather)
		End Sub

		Private Sub panMainViewport_SizeChanged(sender As Object, e As EventArgs)
			<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CD@BGDBOEOH@c?3?2jtfcode?2src?2workshop?2MainForm@), __Pointer(Of SByte)), 3225, CType((AddressOf <Module>.??_C@_0DC@IFGJDFHM@NWorkshop?3?3NMainForm?3?3panMainVie@), __Pointer(Of SByte)))
			<Module>.GLogger.Log(0, CType((AddressOf <Module>.??_C@_0BL@LAMDIDIP@Resize?5viewport?5to?5?$CFd?5x?5?$CFd?$AA@), __Pointer(Of SByte)), Me.panMainViewport.Width, Me.panMainViewport.Height)
			If <Module>.IEngine IsNot Nothing Then
				Dim num As Integer = __Dereference(CType(Me.IRenderTarget, __Pointer(Of Integer))) + 12
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), Me.IRenderTarget, Me.panMainViewport.Width, Me.panMainViewport.Height, __Dereference(num))
			End If
		End Sub

		Private Sub NMainForm_Closing(sender As Object, e As CancelEventArgs)
			If Me.GameDebugWorld IsNot Nothing Then
				Me.EndDebugMap()
				e.Cancel = True
			Else
				If Me.ToolWindows.Count > 0 Then
					Do
						Dim form As Form = TryCast(Me.ToolWindows(0), Form)
						form.Activate()
						form.Close()
						If Me.ToolWindows.Contains(form) Then
							GoTo IL_61
						End If
					Loop While Me.ToolWindows.Count > 0
					GoTo IL_68
					IL_61:
					e.Cancel = True
				End If
				IL_68:
				If Not Me.SaveDocumentIfChanged() Then
					e.Cancel = True
				End If
			End If
		End Sub

		Private Sub NMainForm_Closed(sender As Object, e As EventArgs)
			Me.WindowClosing = True
			Me.DiscardDocument()
			Dim brushCursor As __Pointer(Of GHandle<11>) = Me.BrushCursor
			If brushCursor IsNot Nothing Then
				<Module>.delete(CType(brushCursor, __Pointer(Of Void)))
				Me.BrushCursor = Nothing
			End If
			Dim parcelSelection As __Pointer(Of GHandle<11>) = Me.ParcelSelection
			If parcelSelection IsNot Nothing Then
				<Module>.delete(CType(parcelSelection, __Pointer(Of Void)))
				Me.ParcelSelection = Nothing
			End If
			<Module>.delete(CType(Me.LastCamera, __Pointer(Of Void)))
			If Me.ToolWindows.Count > 0 Then
				Do
					Dim form As Form = TryCast(Me.ToolWindows(0), Form)
					form.Close()
					Me.ToolWindows.Remove(form)
				Loop While Me.ToolWindows.Count > 0
			End If
			Me.CameraCurveProps.RemoveCameraViewPort()
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>), <Module>.ILayout, __Dereference(CType((Me.ND + 16 / __SizeOf(GNativeData)), __Pointer(Of GHandle<19>))), __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))) + 4)))
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>), <Module>.ILayout, __Dereference(CType((Me.ND + 20 / __SizeOf(GNativeData)), __Pointer(Of GHandle<19>))), __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))) + 4)))
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>), <Module>.ILayout, __Dereference(CType((Me.ND + 24 / __SizeOf(GNativeData)), __Pointer(Of GHandle<19>))), __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))) + 4)))
			__Dereference(CType((Me.ND + 16 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
			__Dereference(CType((Me.ND + 20 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
			__Dereference(CType((Me.ND + 24 / __SizeOf(GNativeData)), __Pointer(Of Integer))) = 0
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>), <Module>.IEngine, __Dereference(CType((Me.ND + 4 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 144)))
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>), <Module>.IEngine, __Dereference(CType((Me.ND + 8 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 144)))
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<12>), <Module>.IEngine, __Dereference(CType((Me.ND + 12 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 144)))
			Dim objectFilePicker As FilePickerControl = Me.ObjectFilePicker
			If objectFilePicker IsNot Nothing Then
				objectFilePicker.Dispose()
			End If
			Dim roadFilePicker As FilePickerControl = Me.RoadFilePicker
			If roadFilePicker IsNot Nothing Then
				roadFilePicker.Dispose()
			End If
			Dim decalFilePicker As FilePickerControl = Me.DecalFilePicker
			If decalFilePicker IsNot Nothing Then
				decalFilePicker.Dispose()
			End If
			Dim unitFilePicker As FilePickerControl = Me.UnitFilePicker
			If unitFilePicker IsNot Nothing Then
				unitFilePicker.Dispose()
			End If
			Dim terrainTools As ToolboxTerrainTools = Me.TerrainTools
			If terrainTools IsNot Nothing Then
				terrainTools.Dispose()
			End If
			Dim riverFilePicker As FilePickerControl = Me.RiverFilePicker
			If riverFilePicker IsNot Nothing Then
				riverFilePicker.Dispose()
			End If
			Dim lakeFilePicker As FilePickerControl = Me.LakeFilePicker
			If lakeFilePicker IsNot Nothing Then
				lakeFilePicker.Dispose()
			End If
			Dim buildingFilePicker As FilePickerControl = Me.BuildingFilePicker
			If buildingFilePicker IsNot Nothing Then
				buildingFilePicker.Dispose()
			End If
			Dim soundFilePicker As FilePickerControl = Me.SoundFilePicker
			If soundFilePicker IsNot Nothing Then
				soundFilePicker.Dispose()
			End If
			Dim effectFilePicker As FilePickerControl = Me.EffectFilePicker
			If effectFilePicker IsNot Nothing Then
				effectFilePicker.Dispose()
			End If
			Dim localeFilePicker As FilePickerControl = Me.LocaleFilePicker
			If localeFilePicker IsNot Nothing Then
				localeFilePicker.Dispose()
			End If
			Dim unitEditorClipboard As __Pointer(Of NPropertyClipboard) = Me.UnitEditorClipboard
			If unitEditorClipboard IsNot Nothing Then
				Dim num As UInteger = CUInt((__Dereference(CType((unitEditorClipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer)))))
				If num <> 0UI Then
					Dim ptr As __Pointer(Of GStream) = num
					Dim arg_283_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr, 1, __Dereference((__Dereference(CType(ptr, __Pointer(Of Integer))))))
					__Dereference(CType((Me.UnitEditorClipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))) = 0
				End If
			End If
			Dim effectEditorClipboard As __Pointer(Of NPropertyClipboard) = Me.EffectEditorClipboard
			If effectEditorClipboard IsNot Nothing Then
				Dim num2 As UInteger = CUInt((__Dereference(CType((effectEditorClipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer)))))
				If num2 <> 0UI Then
					Dim ptr2 As __Pointer(Of GStream) = num2
					Dim arg_2B5_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr2, 1, __Dereference((__Dereference(CType(ptr2, __Pointer(Of Integer))))))
					__Dereference(CType((Me.EffectEditorClipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))) = 0
				End If
			End If
			Dim unitEditorClipboard2 As __Pointer(Of NPropertyClipboard) = Me.UnitEditorClipboard
			If unitEditorClipboard2 IsNot Nothing Then
				<Module>.delete(CType(unitEditorClipboard2, __Pointer(Of Void)))
				Me.UnitEditorClipboard = Nothing
			End If
			Dim effectEditorClipboard2 As __Pointer(Of NPropertyClipboard) = Me.EffectEditorClipboard
			If effectEditorClipboard2 IsNot Nothing Then
				<Module>.delete(CType(effectEditorClipboard2, __Pointer(Of Void)))
				Me.EffectEditorClipboard = Nothing
			End If
			Dim num3 As Integer = 0
			If 0 < __Dereference(CType((Me.PhysicsModels + 4 / __SizeOf(GArray<GIModel *>)), __Pointer(Of Integer))) Then
				Do
					Dim num4 As Integer = num3 * 4
					Dim num5 As Integer = num4 + __Dereference(CType(Me.PhysicsModels, __Pointer(Of Integer)))
					If __Dereference(num5) <> 0 Then
						Dim expr_31B As Integer = __Dereference(num5)
						Dim expr_325 As Integer = expr_31B + __Dereference((__Dereference((expr_31B + 4)) + 4)) + 4
						Dim arg_32F_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_325, __Dereference((__Dereference(expr_325) + 4)))
						__Dereference((__Dereference(CType(Me.PhysicsModels, __Pointer(Of Integer))) + num4)) = 0
					End If
					num3 += 1
				Loop While num3 < __Dereference(CType((Me.PhysicsModels + 4 / __SizeOf(GArray<GIModel *>)), __Pointer(Of Integer)))
			End If
			Dim physicsModels As __Pointer(Of GArray<GIModel *>) = Me.PhysicsModels
			If physicsModels IsNot Nothing Then
				Dim ptr3 As __Pointer(Of GArray<GIModel *>) = physicsModels
				Dim arg_371_0 As __Pointer(Of Integer) = __Dereference(CType((ptr3 + 4 / __SizeOf(GArray<GIModel *>)), __Pointer(Of Integer)))
				Dim num6 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
				If num6 <> 0UI Then
					<Module>.free(num6)
					__Dereference(CType(ptr3, __Pointer(Of Integer))) = 0
				End If
				__Dereference(arg_371_0) = 0
				__Dereference(CType((ptr3 + 8 / __SizeOf(GArray<GIModel *>)), __Pointer(Of Integer))) = 0
				<Module>.delete(CType(ptr3, __Pointer(Of Void)))
				Me.PhysicsModels = Nothing
			End If
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				Dim ptr4 As __Pointer(Of GEditorWorld) = world
				Dim arg_39A_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr4, 1, __Dereference((__Dereference(CType(ptr4, __Pointer(Of Integer))))))
				Me.World = Nothing
			End If
			If <Module>.UnitRegistry IsNot Nothing Then
				Dim arg_3B8_0 As __Pointer(Of Void) = CType(<Module>.UnitRegistry, __Pointer(Of Void))
				<Module>.GUnitRegistry.{dtor}(<Module>.UnitRegistry)
				<Module>.delete(arg_3B8_0)
				<Module>.UnitRegistry = Nothing
			End If
			<Module>.EngineShutdown()
		End Sub

		Private Sub panMainViewport_Paint(sender As Object, e As PaintEventArgs)
			If <Module>.GLogger.ActiveDialogExists() Is Nothing AndAlso Not Me.WindowClosing Then
				If <Module>.ISoundSys IsNot Nothing Then
					Dim expr_21 As __Pointer(Of GISoundSys) = <Module>.ISoundSys
					Dim arg_29_0 As Object = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_21, __Dereference((__Dereference(CType(expr_21, __Pointer(Of Integer))))))
				End If
				If Me.World IsNot Nothing Then
					Dim num As Long = <Module>.GTimer.GetTimeH(<Module>.Timer)
					If Me.LastUpdate = 0L Then
						Me.LastUpdate = num
					End If
					Dim num2 As Integer = 0
					Do
						If __Dereference((num2 * 8 + Me.KeyTimes)) <> 0L Then
							Me.UpdateKey(num, num2)
						End If
						num2 += 1
					Loop While num2 < 256
					Dim num3 As Long = num - Me.LastUpdate
					Me.LastUpdate = num
					If Me.BrushNeedsUpdate Then
						Me.VisualizeBrush(Me.BrushX, Me.BrushZ)
						Me.BrushNeedsUpdate = False
					End If
					<Module>.GWorld.UpdateCamera(Me.World, Me.IViewport)
					<Module>.GEditorWorld.Refresh(Me.World, num3, Me.IViewport)
					<Module>.GEditorWorld.RefreshTopology(Me.World)
					<Module>.GWorld.UpdateWaterDeferred(Me.World)
					<Module>.GWorld.UpdateBlockMap(Me.World)
					<Module>.GWorld.UpdateVectorBlock(Me.World)
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), <Module>.Scene, num3, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 32)))
					If Me.MinimapUnitsNeedUpdate Then
						Me.RefreshUnitsOnMinimap()
						Me.MinimapUnitsNeedUpdate = False
					End If
					If Me.MinimapViewportNeedsUpdate OrElse <Module>.GWorld.IsCameraMoving(Me.World) IsNot Nothing Then
						Me.RefreshMinimapCameraGizmo()
						Me.MinimapViewportNeedsUpdate = False
					End If
					If Me.SectorSelectionNeedsUpdate Then
						Me.RefreshSectorSelection()
						Me.SectorSelectionNeedsUpdate = False
					End If
					Dim b As Byte = If((__Dereference((<Module>.Options + 68)) = 3), 1, 0)
					Dim world As __Pointer(Of GEditorWorld) = Me.World
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), world, b, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 40)))
					Me.UpdateCameraDebugText()
				End If
				If Me.GameDebugWorld IsNot Nothing Then
					Me.RefreshDebug()
				End If
				If <Module>.IEngine IsNot Nothing Then
					Dim ptr As __Pointer(Of GIScene)
					If Me.World Is Nothing AndAlso Me.GameDebugWorld Is Nothing Then
						ptr = Nothing
					Else
						ptr = <Module>.Scene
					End If
					Dim iRenderTarget As __Pointer(Of GIRenderTarget) = Me.IRenderTarget
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GIScene*,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iRenderTarget, ptr, 4194304, __Dereference((__Dereference(CType(iRenderTarget, __Pointer(Of Integer))) + 36)))
					If Not calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 3, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 32))) AndAlso (If((__Dereference(CType(Me.ND, __Pointer(Of Integer))) <> 0), 1, 0)) <> 0 Then
						Dim gBaseString<char> As GBaseString<char>
						Dim num4 As Integer = calli(GBaseString<char>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GBaseString<char>*), <Module>.IEngine, gBaseString<char>, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 4)))
						Try
							Dim num5 As UInteger = CUInt((__Dereference(num4)))
							Dim ptr2 As __Pointer(Of SByte)
							If num5 <> 0UI Then
								ptr2 = num5
							Else
								ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							Dim nD As __Pointer(Of GNativeData) = Me.ND
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>,GHandle<12>,System.Int32,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.ILayout, __Dereference(CType((nD + 16 / __SizeOf(GNativeData)), __Pointer(Of GHandle<19>))), __Dereference(CType((nD + 4 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), 0, ptr2, __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))) + 84)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
						End If
						If <Module>.ISoundSys IsNot Nothing Then
							Dim gBaseString<char>2 As GBaseString<char>
							Dim num6 As Integer = calli(GBaseString<char>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GBaseString<char>*), <Module>.ISoundSys, gBaseString<char>2, __Dereference((__Dereference(CType(<Module>.ISoundSys, __Pointer(Of Integer))) + 60)))
							Try
								Dim num7 As UInteger = CUInt((__Dereference(num6)))
								Dim ptr3 As __Pointer(Of SByte)
								If num7 <> 0UI Then
									ptr3 = num7
								Else
									ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								Dim nD2 As __Pointer(Of GNativeData) = Me.ND
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<19>,GHandle<12>,System.Int32,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.ILayout, __Dereference(CType((nD2 + 20 / __SizeOf(GNativeData)), __Pointer(Of GHandle<19>))), __Dereference(CType((nD2 + 4 / __SizeOf(GNativeData)), __Pointer(Of GHandle<12>))), 0, ptr3, __Dereference((__Dereference(CType(<Module>.ILayout, __Pointer(Of Integer))) + 84)))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>2 IsNot Nothing Then
								<Module>.free(gBaseString<char>2)
							End If
						End If
					End If
				End If
			End If
		End Sub

		Private Sub panMainViewport_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode >= Keys.None OrElse e.KeyCode < CType(256, Keys) Then
				If __Dereference((e.KeyCode * Keys.Back + Me.KeyTimes)) = 0L Then
					__Dereference((e.KeyCode * Keys.Back + Me.KeyTimes)) = <Module>.GTimer.GetTimeH(<Module>.Timer)
				End If
				e.Handled = True
				If Me.GameDebugMode Then
					Me.HandleDebugKeys(e.KeyCode)
				Else
					If e.KeyCode >= Keys.D1 AndAlso e.KeyCode <= Keys.D9 Then
						Select Case Me.EditorMode
							Case 1
								Me.VertexTools.EmulatePush(e.KeyCode - Keys.D1)
							Case 2
								Me.TerrainTools.EmulatePush(e.KeyCode - Keys.D1)
							Case 3, 4, 5, 6, 7, 9, 10, 11, 12, 16
								If Me.CurrentEntityToolbar IsNot Nothing Then
									If e.KeyCode = Keys.D1 Then
										Me.CurrentEntityToolbar.PrevGroup()
									Else If e.KeyCode = Keys.D2 Then
										Me.CurrentEntityToolbar.PrevTool()
									Else If e.KeyCode = Keys.D3 Then
										Me.CurrentEntityToolbar.NextTool()
									Else If e.KeyCode = Keys.D4 Then
										Me.CurrentEntityToolbar.NextGroup()
									Else If e.KeyCode = Keys.D5 Then
										Me.CurrentEntityToolbar.NextTool()
										Me.CurrentEntityToolbar.PrevTool()
										Me.CurrentEntityToolbar.EmulatePush(-1)
									End If
								End If
						End Select
					End If
					Dim ptr As __Pointer(Of $ArrayType$$$BY0BAA@_J) = Me.KeyTimes + 128
					If __Dereference(ptr) <> 0L AndAlso Me.EntityType <> 0 AndAlso Me.World IsNot Nothing AndAlso (e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down) Then
						Dim world As __Pointer(Of GEditorWorld) = Me.World
						If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, Me.EntityType, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) Then
							Dim num As Single = 0F
							Dim num2 As Single = 0F
							Select Case e.KeyCode
								Case Keys.Left
									num = -0.1F
								Case Keys.Up
									num2 = 0.1F
								Case Keys.Right
									num = 0.1F
								Case Keys.Down
									num2 = -0.1F
							End Select
							Select Case __Dereference((Me.EntityType * 4 + Me.EntityOperation))
								Case 1
									If Me.KeyDragMode <> 9 Then
										Dim arg_39A_0 As Cursor = Me.panMainViewport.Cursor
										Dim position As Point = Cursor.Position
										Dim arg_3AD_0 As Cursor = Me.panMainViewport.Cursor
										Me.CompleteDepressedDrag(Cursor.Position.X, position.Y)
										Dim arg_3D4_0 As Cursor = Me.panMainViewport.Cursor
										Dim position2 As Point = Cursor.Position
										Dim arg_3E7_0 As Cursor = Me.panMainViewport.Cursor
										Me.CompletePressedDrag(Cursor.Position.X, position2.Y)
										Dim entityType As Integer = Me.EntityType
										If <Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@_N@Z(Me.World, entityType, __Dereference((Me.EntityAlignMove + entityType)) <> 0) IsNot Nothing Then
											Me.KeyDragMode = 9
										End If
									End If
									<Module>.GEditorWorld.FollowEntityMove(Me.World, num, num2)
								Case 8
									If Me.KeyDragMode <> 10 Then
										Dim arg_457_0 As Cursor = Me.panMainViewport.Cursor
										Dim position3 As Point = Cursor.Position
										Dim arg_46A_0 As Cursor = Me.panMainViewport.Cursor
										Me.CompleteDepressedDrag(Cursor.Position.X, position3.Y)
										Dim arg_491_0 As Cursor = Me.panMainViewport.Cursor
										Dim position4 As Point = Cursor.Position
										Dim arg_4A4_0 As Cursor = Me.panMainViewport.Cursor
										Me.CompletePressedDrag(Cursor.Position.X, position4.Y)
										If <Module>.?StartEntityLift@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(Me.World, Me.EntityType, 0) IsNot Nothing Then
											Me.KeyDragMode = 10
											Me.DragY = 0F
										End If
									End If
									Dim num3 As Single = CSng((CDec(Me.DragY) - CDec(num2) * 50.0))
									Me.DragY = num3
									<Module>.GEditorWorld.FollowEntityLift(Me.World, CInt((CDec(num3))))
								Case 16
									If Me.KeyDragMode <> 11 Then
										Dim arg_532_0 As Cursor = Me.panMainViewport.Cursor
										Dim position5 As Point = Cursor.Position
										Dim arg_545_0 As Cursor = Me.panMainViewport.Cursor
										Me.CompleteDepressedDrag(Cursor.Position.X, position5.Y)
										Dim arg_56C_0 As Cursor = Me.panMainViewport.Cursor
										Dim position6 As Point = Cursor.Position
										Dim arg_57F_0 As Cursor = Me.panMainViewport.Cursor
										Me.CompletePressedDrag(Cursor.Position.X, position6.Y)
										Dim entityType2 As Integer = Me.EntityType
										If <Module>.?StartEntityRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@H_N@Z(Me.World, entityType2, 0, __Dereference((Me.EntityAlignRotate + entityType2)) <> 0) IsNot Nothing Then
											Me.KeyDragMode = 11
											Me.DragY = 0F
										End If
									End If
									Dim num4 As Single = CSng((CDec(Me.DragY) + CDec((num2 * 3.14159274F)) * 15.625))
									Me.DragY = num4
									<Module>.GEditorWorld.FollowEntityRotate(Me.World, CInt((CDec(num4))))
								Case 64
									If Me.KeyDragMode <> 13 Then
										Dim arg_621_0 As Cursor = Me.panMainViewport.Cursor
										Dim position7 As Point = Cursor.Position
										Dim arg_634_0 As Cursor = Me.panMainViewport.Cursor
										Me.CompleteDepressedDrag(Cursor.Position.X, position7.Y)
										Dim arg_65B_0 As Cursor = Me.panMainViewport.Cursor
										Dim position8 As Point = Cursor.Position
										Dim arg_66E_0 As Cursor = Me.panMainViewport.Cursor
										Me.CompletePressedDrag(Cursor.Position.X, position8.Y)
										If <Module>.?StartEntityTilt@GEditorWorld@@$$FQAE_NW4GEntityType@@MM@Z(Me.World, Me.EntityType, 0F, 0F) IsNot Nothing Then
											Me.KeyDragMode = 13
											Me.DragX = 0F
											Me.DragY = 0F
										End If
									End If
									Dim num5 As Single = CSng((CDec(Me.DragX) + CDec(num) * 0.2))
									Me.DragX = num5
									Dim num6 As Single = CSng((CDec(Me.DragY) + CDec(num2) * 0.2))
									Me.DragY = num6
									<Module>.GEditorWorld.FollowEntityTilt(Me.World, num5, num6)
							End Select
						End If
					End If
					Select Case e.KeyCode
						Case Keys.ShiftKey
							Dim editorMode As Integer = Me.EditorMode
							If editorMode = 2 Then
								If Me.propPaintType = 9 Then
									Me.PaintType = 10
									Me.TemporaryModeChange = True
								End If
								If Me.propPaintType = 15 Then
									Me.PaintType = 16
									Me.TemporaryModeChange = True
								End If
							Else If editorMode = 1 Then
								Dim num7 As Integer = Me.propBrushType
								If num7 < 20 AndAlso num7 = 2 Then
									Me.BrushType = 3
									Me.TemporaryModeChange = True
								End If
							End If
						Case Keys.ControlKey
							If Me.EditorMode = 2 AndAlso Me.propPaintType = 9 Then
								Me.PaintType = 11
								Me.TemporaryModeChange = True
							End If
						Case Keys.Space
							Select Case Me.EditorMode
								Case 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 16, 17, 18, 21
									Dim currentEntityToolbar As ToolboxEntities = Me.CurrentEntityToolbar
									If currentEntityToolbar IsNot Nothing Then
										currentEntityToolbar.EmulatePushByID(303)
									End If
							End Select
						Case Keys.A
							Dim num8 As Integer = If((__Dereference((<Module>.Options + 81)) = 0), 1, 0)
							__Dereference((<Module>.Options + 81)) = CByte(num8)
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.B
							Dim num9 As Integer = If((__Dereference((<Module>.Options + 76)) = 0), 1, 0)
							__Dereference((<Module>.Options + 76)) = CByte(num9)
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.C
							Dim num10 As Integer = If((__Dereference((<Module>.Options + 92)) = 0), 1, 0)
							__Dereference((<Module>.Options + 92)) = CByte(num10)
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.E
							Dim num11 As Integer = If((__Dereference((<Module>.Options + 93)) = 0), 1, 0)
							__Dereference((<Module>.Options + 93)) = CByte(num11)
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.I
							Dim num12 As Integer = If((__Dereference((<Module>.Options + 79)) = 0), 1, 0)
							__Dereference((<Module>.Options + 79)) = CByte(num12)
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.L
							Dim num13 As Integer = If((__Dereference((<Module>.Options + 77)) = 0), 1, 0)
							__Dereference((<Module>.Options + 77)) = CByte(num13)
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.O
							Dim num14 As Integer = If((__Dereference((<Module>.Options + 78)) = 0), 1, 0)
							__Dereference((<Module>.Options + 78)) = CByte(num14)
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.P
							Dim num15 As Integer = If((calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 24, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) = 0), 1, 0)
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 24, num15, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
						Case Keys.Q
							__Dereference((<Module>.Options + 72)) = (If((__Dereference((<Module>.Options + 72)) = 2), 0, 2))
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.S
							__Dereference((<Module>.Options + 72)) = (If((__Dereference((<Module>.Options + 72)) = 1), 2, 1))
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.T
							Dim num16 As Integer = If((__Dereference((<Module>.Options + 80)) = 0), 1, 0)
							__Dereference((<Module>.Options + 80)) = CByte(num16)
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.U
							Dim num17 As Integer = __Dereference((<Module>.Options + 112))
							If num17 <> 0 Then
								If num17 <> 1 Then
									__Dereference((<Module>.Options + 112)) = (If((num17 <> 2), 0, 3))
								Else
									__Dereference((<Module>.Options + 112)) = 2
								End If
							Else
								__Dereference((<Module>.Options + 112)) = 1
							End If
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.W
							__Dereference((<Module>.Options + 68)) = (If((__Dereference((<Module>.Options + 68)) = 3), 2, 3))
							Me.toolboxOptions_OptionsChanged()
							If Me.EditorMode = 14 Then
								Me.OptionsTools.Refresh()
							End If
						Case Keys.Multiply
							If __Dereference(ptr) <> 0L Then
								If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 26, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) < 16 Then
									Dim num18 As Integer = __Dereference(CType(<Module>.IEngine, __Pointer(Of Integer)))
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 26, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 26, __Dereference((num18 + 20))) + 1, __Dereference((num18 + 16)))
								End If
							Else If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 25, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) < 16 Then
								Dim num19 As Integer = __Dereference(CType(<Module>.IEngine, __Pointer(Of Integer)))
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 25, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 25, __Dereference((num19 + 20))) + 1, __Dereference((num19 + 16)))
							End If
						Case Keys.Divide
							If __Dereference(ptr) <> 0L Then
								If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 26, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) > 0 Then
									Dim num20 As Integer = __Dereference(CType(<Module>.IEngine, __Pointer(Of Integer)))
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 26, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 26, __Dereference((num20 + 20))) - 1, __Dereference((num20 + 16)))
								End If
							Else If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 25, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) > 0 Then
								Dim num21 As Integer = __Dereference(CType(<Module>.IEngine, __Pointer(Of Integer)))
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 25, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 25, __Dereference((num21 + 20))) - 1, __Dereference((num21 + 16)))
							End If
						Case Keys.F1
							Dim world2 As __Pointer(Of GEditorWorld) = Me.World
							If world2 IsNot Nothing Then
								If __Dereference(ptr) <> 0L Then
									<Module>.GWorld.CameraInitialize(world2)
								Else
									Dim b As Byte = If((__Dereference(CType((world2 + 136 / __SizeOf(GEditorWorld)), __Pointer(Of Byte))) = 0), 1, 0)
									<Module>.GWorld.LimitGameCamera(world2, b <> 0)
								End If
								Me.MinimapViewportNeedsUpdate = True
							End If
						Case Keys.F2
							Dim num22 As Integer = If((calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 15, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) = 0), 1, 0)
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 15, num22, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
						Case Keys.F3
							If __Dereference((Me.KeyTimes + 136)) <> 0L Then
								Dim num23 As Integer = If((calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 19, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) = 0), 1, 0)
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 19, num23, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
							Else If __Dereference(ptr) <> 0L Then
								Dim num24 As Integer = If((calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, 9, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 20))) = 0), 1, 0)
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.IEngine, 9, num24, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 16)))
							End If
						Case Keys.F5
							If __Dereference((Me.KeyTimes + 136)) <> 0L Then
								Me.RunMap()
							Else
								Me.DebugMap()
							End If
						Case Keys.F7
							Me.menuToolsScriptEditor_Click(Nothing, Nothing)
						Case Keys.F8
							If(If((__Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of Integer))) <> 0), 1, 0)) = 0 Then
								Dim gHandle<11> As GHandle<11>
								Dim num25 As Integer = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, gHandle<11>, 1, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 256)))
								cpblk(Me.ND + 32 / __SizeOf(GNativeData), num25, 4)
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, __Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), 0, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 268)))
							End If
							If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 272))) Then
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 264)))
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, __Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), 1, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 268)))
								Dim num26 As Integer = <Module>.GHeapDRB<GUnit *>.GetNext(Me.World + 2928 / __SizeOf(GEditorWorld), -1)
								If num26 >= 0 Then
									While True
										Dim ptr2 As __Pointer(Of GUnit) = __Dereference((num26 * 8 + __Dereference(CType((Me.World + 2928 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 4))
										Dim expr_B19 As Integer = __Dereference(CType((ptr2 + 8 / __SizeOf(GUnit)), __Pointer(Of Integer)))
										If calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_B19, __Dereference((__Dereference(expr_B19) + 32))) Then
											GoTo IL_B37
										End If
										Dim expr_B2A As Integer = __Dereference(CType((ptr2 + 8 / __SizeOf(GUnit)), __Pointer(Of Integer)))
										If calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_B2A, __Dereference((__Dereference(expr_B2A) + 36))) Then
											GoTo IL_B37
										End If
										IL_B95:
										num26 = <Module>.GHeapDRB<GUnit *>.GetNext(Me.World + 2928 / __SizeOf(GEditorWorld), num26)
										If num26 < 0 Then
											Exit While
										End If
										Continue While
										IL_B37:
										Dim num27 As Single = __Dereference(CType((ptr2 + 528 / __SizeOf(GUnit)), __Pointer(Of Single)))
										Dim num28 As Single = __Dereference(CType((ptr2 + 528 / __SizeOf(GUnit) + 8 / __SizeOf(GUnit)), __Pointer(Of Single)))
										Dim gPoint As GPoint2 = num27
										__Dereference((gPoint + 4)) = num28
										calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint2,System.Single,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong),System.Single), <Module>.Scene, __Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), gPoint, __Dereference(CType((ptr2 + 124 / __SizeOf(GUnit)), __Pointer(Of Single))) * 0.5F, 16777215, 0F, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 288)))
										GoTo IL_B95
									End While
								End If
							Else
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, __Dereference(CType((Me.ND + 32 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), 0, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 268)))
							End If
						Case Keys.F9
							If(If((__Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of Integer))) <> 0), 1, 0)) = 0 Then
								Dim gHandle<11>2 As GHandle<11>
								Dim num29 As Integer = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, gHandle<11>2, 1, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 256)))
								cpblk(Me.ND + 28 / __SizeOf(GNativeData), num29, 4)
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, __Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), 0, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 268)))
							End If
							If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 272))) Then
								Dim ptr3 As __Pointer(Of GPUnit) = <Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, CType((AddressOf <Module>.??_C@_0CB@NBPLGCPO@units?1JTF?5?9?5Infantry?1Ranger?4unit@), __Pointer(Of SByte)), False, True)
								If ptr3 IsNot Nothing Then
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), <Module>.Scene, __Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 264)))
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, __Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), 1, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 268)))
									Dim gGraph As GGraph
									<Module>.GGraph.{ctor}(gGraph, __Dereference(CType((ptr3 + 92 / __SizeOf(GPUnit)), __Pointer(Of Single))) * 0.5F, <Module>.GPUnit.GetMovementMaskWithoutEdge(ptr3), __Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))))
									<Module>.GGraph.{dtor}(gGraph)
								End If
							Else
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, __Dereference(CType((Me.ND + 28 / __SizeOf(GNativeData)), __Pointer(Of GHandle<11>))), 0, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 268)))
							End If
					End Select
				End If
			End If
		End Sub

		Private Sub panMainViewport_KeyUp(sender As Object, e As KeyEventArgs)
			If e.KeyCode >= Keys.None OrElse e.KeyCode < CType(256, Keys) Then
				If __Dereference((e.KeyCode * Keys.Back + Me.KeyTimes)) <> 0L Then
					If Me.World IsNot Nothing Then
						Me.UpdateKey(<Module>.GTimer.GetTimeH(<Module>.Timer), CInt(e.KeyCode))
					End If
					__Dereference((e.KeyCode * Keys.Back + Me.KeyTimes)) = 0L
				End If
				If e.KeyCode >= Keys.D1 AndAlso e.KeyCode <= Keys.D9 Then
					Select Case Me.EditorMode
						Case 1
							Me.VertexTools.EmulateUp(e.KeyCode - Keys.D1)
						Case 2
							Me.TerrainTools.EmulateUp(e.KeyCode - Keys.D1)
						Case 3, 4, 5, 6, 7, 9, 10, 11, 12, 16
							If Me.CurrentEntityToolbar IsNot Nothing AndAlso e.KeyCode = Keys.D5 Then
								Me.CurrentEntityToolbar.EmulateUp(-1)
							End If
					End Select
				End If
				If Me.KeyDragMode <> 0 AndAlso (e.KeyCode = Keys.Left OrElse e.KeyCode = Keys.Right OrElse e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.ShiftKey) Then
					Select Case Me.KeyDragMode
						Case 9
							<Module>.GEditorWorld.CompleteEntityMove(Me.World)
							Dim scriptEditorFormInstance As ScriptEditorForm = Me.ScriptEditorFormInstance
							If scriptEditorFormInstance IsNot Nothing Then
								scriptEditorFormInstance.EditorsChanged()
							End If
						Case 10
							<Module>.GEditorWorld.CompleteEntityLift(Me.World)
						Case 11
							<Module>.GEditorWorld.CompleteEntityRotate(Me.World)
						Case 13
							<Module>.GEditorWorld.CompleteEntityTilt(Me.World)
					End Select
					If Me.EntityType = 3 Then
						Me.MinimapUnitsNeedUpdate = True
					End If
					Me.KeyDragMode = 0
					Me.RefreshMenuAndToolbarItems()
				End If
				Dim keyCode As Keys = e.KeyCode
				If keyCode <> Keys.ShiftKey Then
					If keyCode <> Keys.ControlKey Then
						If keyCode = Keys.Space Then
							Select Case Me.EditorMode
								Case 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 16, 17, 18, 21
									Dim currentEntityToolbar As ToolboxEntities = Me.CurrentEntityToolbar
									If currentEntityToolbar IsNot Nothing Then
										currentEntityToolbar.EmulateUpByID(303)
									End If
							End Select
						End If
					Else If Me.EditorMode = 2 AndAlso Me.propPaintType = 11 Then
						Me.PaintType = 9
						Me.TemporaryModeChange = False
					End If
				Else
					Dim editorMode As Integer = Me.EditorMode
					If editorMode = 2 AndAlso Me.TemporaryModeChange Then
						If Me.propPaintType = 10 Then
							Me.PaintType = 9
							Me.TemporaryModeChange = False
						End If
						If Me.propPaintType = 16 Then
							Me.PaintType = 15
							Me.TemporaryModeChange = False
						End If
					Else If editorMode = 1 AndAlso Me.TemporaryModeChange AndAlso Me.propBrushType = 3 Then
						Me.BrushType = 2
						Me.TemporaryModeChange = False
					End If
				End If
			End If
		End Sub

		Private Sub panMainViewport_Click(sender As Object, e As EventArgs)
			Dim editorMode As Integer = Me.EditorMode
			If editorMode = 10 Then
				Me.UnitPropertiesTools.Refresh(Me.World)
			Else If editorMode = 9 Then
				Me.BuildingPropertiesTools.Refresh(Me.World)
			End If
		End Sub

		Private Sub panMainViewport_MouseDown(sender As Object, e As MouseEventArgs)
			If Me.GameDebugMode Then
				Me.DebugMouseDown(sender, e)
			Else If Me.World IsNot Nothing Then
				If e.Button = MouseButtons.Left Then
					Me.CompleteDepressedDrag(e.X, e.Y)
					Me.CompletePressedDrag(e.X, e.Y)
					Dim num As Single
					Dim heightSetValue As Single
					Dim num2 As Single
					If Me.EditorMode = 15 Then
						<Module>.GWorld.GetPointInTopMode(Me.World, Me.IViewport, CSng(e.X), CSng(e.Y), num, heightSetValue, num2)
					Else
						Dim num3 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim gRay As GRay
						<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, e.X, e.Y, __Dereference(num3)), num, heightSetValue, num2)
					End If
					If Me.EntityType <> 0 Then
						Dim num4 As Integer = __Dereference(CType(Me.World, __Pointer(Of Integer))) + 8
						Dim num5 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim gRay2 As GRay
						Dim num6 As Integer = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GRay modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), Me.World, Me.EntityType, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay2, e.X, e.Y, __Dereference(num5)), 0, __Dereference(num4))
						Me.DragX = num
						Me.DragZ = num2
						Me.DragMX = e.X
						Me.DragMY = e.Y
						Dim entityType As Integer = Me.EntityType
						Dim ptr As __Pointer(Of $ArrayType$$$BY0BE@W4GEntityOperation@@) = entityType * 4 + Me.EntityOperation
						Dim num7 As Integer = __Dereference(ptr)
						If num7 <> 2 AndAlso num7 <> 4 AndAlso __Dereference((Me.KeyTimes + 128)) <> 0L Then
							If num6 >= 0 Then
								Dim world As __Pointer(Of GEditorWorld) = Me.World
								calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world, entityType, num6, 17, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 16)))
								Dim currentScriptEnittyToolbar As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
								If currentScriptEnittyToolbar IsNot Nothing Then
									currentScriptEnittyToolbar.UpdateHilighting()
								End If
							Else
								Me.DragMode = 15
							End If
						Else
							Select Case __Dereference(ptr)
								Case 1
									If num6 < 0 AndAlso __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
										Me.DragMode = 14
									Else
										If __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
											Dim world2 As __Pointer(Of GEditorWorld) = Me.World
											If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world2, entityType, num6, __Dereference((__Dereference(CType(world2, __Pointer(Of Integer))) + 28))) Then
												Dim world3 As __Pointer(Of GEditorWorld) = Me.World
												calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world3, Me.EntityType, num6, 16, __Dereference((__Dereference(CType(world3, __Pointer(Of Integer))) + 16)))
											End If
										End If
										If __Dereference((Me.KeyTimes + 136)) <> 0L Then
											Select Case <Module>.?GetEntityAlternativeOp@GEditorWorld@@$$FQAEHW4GEntityType@@@Z(Me.World, Me.EntityType)
												Case 8
													If <Module>.?StartEntityLift@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(Me.World, Me.EntityType, e.Y) IsNot Nothing Then
														Me.DragMode = 10
														GoTo IL_C39
													End If
													GoTo IL_C39
												Case 16
													entityType = Me.EntityType
													If entityType = 7 OrElse <Module>.?StartEntityRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@H_N@Z(Me.World, Me.EntityType, e.Y, __Dereference((Me.EntityAlignRotate + entityType)) <> 0) IsNot Nothing Then
														Me.DragMode = 11
														GoTo IL_C39
													End If
													GoTo IL_C39
												Case 32
													entityType = Me.EntityType
													If <Module>.?StartEntityPointRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@MMH_N1@Z(Me.World, Me.EntityType, num, num2, e.Y, __Dereference((Me.EntityAlignRotate + entityType)) <> 0, __Dereference((Me.EntityLockHeights + entityType)) <> 0) IsNot Nothing Then
														Me.DragMode = 12
														GoTo IL_C39
													End If
													GoTo IL_C39
												Case 128
													If <Module>.?StartEntityScale@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(Me.World, Me.EntityType, e.Y) IsNot Nothing Then
														Me.DragMode = 16
														GoTo IL_C39
													End If
													GoTo IL_C39
											End Select
											Dim num8 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
											entityType = Me.EntityType
											Dim gRay3 As GRay
											If <Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(Me.World, entityType, num, num2, __Dereference((Me.EntityAlignMove + entityType)) <> 0, __Dereference((Me.EntityLockHeights + entityType)) <> 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay3, e.X, e.Y, __Dereference(num8))) IsNot Nothing Then
												Me.DragMode = 9
											End If
										Else
											Dim num9 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
											entityType = Me.EntityType
											Dim gRay4 As GRay
											If <Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(Me.World, entityType, num, num2, __Dereference((Me.EntityAlignMove + entityType)) <> 0, __Dereference((Me.EntityLockHeights + entityType)) <> 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay4, e.X, e.Y, __Dereference(num9))) IsNot Nothing Then
												Me.DragMode = 9
											End If
										End If
									End If
								Case 2, 4
									If(num6 >= 0 AndAlso (entityType = 9 OrElse entityType = 10 OrElse entityType = 12 OrElse entityType = 14 OrElse entityType = 15 OrElse entityType = 16 OrElse entityType = 17 OrElse entityType = 18)) OrElse entityType = 11 OrElse entityType = 13 Then
										Me.DragMode = 17
									End If
								Case 8
									If num6 < 0 AndAlso __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
										Me.DragMode = 14
									Else
										If __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
											Dim world4 As __Pointer(Of GEditorWorld) = Me.World
											If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world4, entityType, num6, __Dereference((__Dereference(CType(world4, __Pointer(Of Integer))) + 28))) Then
												Dim world5 As __Pointer(Of GEditorWorld) = Me.World
												calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world5, Me.EntityType, num6, 16, __Dereference((__Dereference(CType(world5, __Pointer(Of Integer))) + 16)))
											End If
										End If
										If <Module>.?StartEntityLift@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(Me.World, Me.EntityType, e.Y) IsNot Nothing Then
											Me.DragMode = 10
										End If
									End If
								Case 16
									If num6 < 0 AndAlso __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
										Me.DragMode = 14
									Else
										If __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
											Dim world6 As __Pointer(Of GEditorWorld) = Me.World
											If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world6, entityType, num6, __Dereference((__Dereference(CType(world6, __Pointer(Of Integer))) + 28))) Then
												Dim world7 As __Pointer(Of GEditorWorld) = Me.World
												calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world7, Me.EntityType, num6, 16, __Dereference((__Dereference(CType(world7, __Pointer(Of Integer))) + 16)))
											End If
										End If
										If __Dereference((Me.KeyTimes + 136)) <> 0L Then
											Dim num10 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
											entityType = Me.EntityType
											Dim gRay5 As GRay
											If <Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(Me.World, entityType, num, num2, __Dereference((Me.EntityAlignMove + entityType)) <> 0, __Dereference((Me.EntityLockHeights + entityType)) <> 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay5, e.X, e.Y, __Dereference(num10))) IsNot Nothing Then
												Me.DragMode = 9
											End If
										Else If <Module>.?StartEntityRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@H_N@Z(Me.World, Me.EntityType, e.Y, __Dereference((Me.EntityAlignRotate + Me.EntityType)) <> 0) IsNot Nothing Then
											Me.DragMode = 11
										End If
									End If
								Case 32
									If num6 < 0 AndAlso __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
										Me.DragMode = 14
									Else
										If __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
											Dim world8 As __Pointer(Of GEditorWorld) = Me.World
											If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world8, entityType, num6, __Dereference((__Dereference(CType(world8, __Pointer(Of Integer))) + 28))) Then
												Dim world9 As __Pointer(Of GEditorWorld) = Me.World
												calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world9, Me.EntityType, num6, 16, __Dereference((__Dereference(CType(world9, __Pointer(Of Integer))) + 16)))
											End If
										End If
										If __Dereference((Me.KeyTimes + 136)) <> 0L Then
											Dim num11 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
											entityType = Me.EntityType
											Dim gRay6 As GRay
											If <Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(Me.World, entityType, num, num2, __Dereference((Me.EntityAlignMove + entityType)) <> 0, __Dereference((Me.EntityLockHeights + entityType)) <> 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay6, e.X, e.Y, __Dereference(num11))) IsNot Nothing Then
												Me.DragMode = 9
											End If
										Else
											entityType = Me.EntityType
											If <Module>.?StartEntityPointRotate@GEditorWorld@@$$FQAE_NW4GEntityType@@MMH_N1@Z(Me.World, Me.EntityType, num, num2, e.Y, __Dereference((Me.EntityAlignRotate + entityType)) <> 0, __Dereference((Me.EntityLockHeights + entityType)) <> 0) IsNot Nothing Then
												Me.DragMode = 12
											End If
										End If
									End If
								Case 64
									If num6 < 0 AndAlso __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
										Me.DragMode = 14
									Else
										If __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
											Dim world10 As __Pointer(Of GEditorWorld) = Me.World
											If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world10, entityType, num6, __Dereference((__Dereference(CType(world10, __Pointer(Of Integer))) + 28))) Then
												Dim world11 As __Pointer(Of GEditorWorld) = Me.World
												calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world11, Me.EntityType, num6, 16, __Dereference((__Dereference(CType(world11, __Pointer(Of Integer))) + 16)))
											End If
										End If
										If <Module>.?StartEntityTilt@GEditorWorld@@$$FQAE_NW4GEntityType@@MM@Z(Me.World, Me.EntityType, num, num2) IsNot Nothing Then
											Me.DragMode = 13
										End If
									End If
								Case 128
									If num6 < 0 AndAlso __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
										Me.DragMode = 14
									Else
										If __Dereference((Me.EntityLockSelection + entityType)) = 0 Then
											Dim world12 As __Pointer(Of GEditorWorld) = Me.World
											If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world12, entityType, num6, __Dereference((__Dereference(CType(world12, __Pointer(Of Integer))) + 28))) Then
												Dim world13 As __Pointer(Of GEditorWorld) = Me.World
												calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world13, Me.EntityType, num6, 16, __Dereference((__Dereference(CType(world13, __Pointer(Of Integer))) + 16)))
											End If
										End If
										If __Dereference((Me.KeyTimes + 136)) <> 0L Then
											Dim num12 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
											entityType = Me.EntityType
											Dim gRay7 As GRay
											If <Module>.?StartEntityMove@GEditorWorld@@$$FQAE_NW4GEntityType@@MM_N1ABUGRay@@@Z(Me.World, entityType, num, num2, __Dereference((Me.EntityAlignMove + entityType)) <> 0, __Dereference((Me.EntityLockHeights + entityType)) <> 0, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay7, e.X, e.Y, __Dereference(num12))) IsNot Nothing Then
												Me.DragMode = 9
											End If
										Else If <Module>.?StartEntityScale@GEditorWorld@@$$FQAE_NW4GEntityType@@H@Z(Me.World, Me.EntityType, e.Y) IsNot Nothing Then
											Me.DragMode = 16
										End If
									End If
							End Select
						End If
						IL_C39:
						Dim editorMode As Integer = Me.EditorMode
						If editorMode = 10 Then
							Me.UnitPropertiesTools.Refresh(Me.World)
						Else If editorMode = 9 Then
							Me.BuildingPropertiesTools.Refresh(Me.World)
						End If
					End If
					If Me.EditorMode = 1 AndAlso num >= 0F Then
						Dim ptr2 As __Pointer(Of $ArrayType$$$BY0BAA@_J) = Me.KeyTimes + 136
						Dim num13 As Long = __Dereference(ptr2)
						If num13 <> 0L Then
							Dim num14 As Integer = Me.propBrushType
							If num14 <> 21 AndAlso num14 <> 22 AndAlso num14 <> 23 Then
								Me.HeightSetValue = heightSetValue
								Me.UpdateBrushSliders()
								GoTo IL_EE8
							End If
						End If
						Dim num15 As Integer = Me.propBrushType
						If num15 >= 20 AndAlso Me.DragMode <> 5 Then
							Me.DragMode = 7
							If Me.SelectionActive AndAlso __Dereference((Me.KeyTimes + 128)) = 0L AndAlso num13 = 0L AndAlso num15 <> 24 Then
								If <Module>.GEditorWorld.IsSelection(Me.World, num, num2) IsNot Nothing Then
									Me.RefreshTerraformer()
									__Dereference(CType(Me.Terraformer, __Pointer(Of Integer))) = 20
									<Module>.GEditorWorld.StartTerraforming(Me.World, Me.Terraformer, e.X, e.Y, False, False)
									Me.DragX = num
									Me.DragZ = num2
								Else
									<Module>.GEditorWorld.SelectNone(Me.World)
									Me.SelectionActive = False
									Me.VertexTools.InvertEnable = False
									Me.TerrainTools.FillEnable = False
									Me.DragMode = 0
									Me.SelectionPossible = True
									Me.DragX = num
									Me.DragZ = num2
									Me.RefreshMenuAndToolbarItems()
									Me.RefreshMinimap()
								End If
							Else If num15 = 24 Then
								Me.RefreshTerraformer()
								If __Dereference((Me.KeyTimes + 128)) <> 0L Then
									__Dereference(CType((Me.Terraformer + 44 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = -Me.SelectionPressure
								Else
									__Dereference(CType((Me.Terraformer + 44 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = Me.SelectionPressure
								End If
								<Module>.GEditorWorld.StartTerraforming(Me.World, Me.Terraformer, e.X, e.Y, False, False)
							Else
								Me.RefreshTerraformer()
								If __Dereference(ptr2) <> 0L AndAlso Me.SelectionActive Then
									__Dereference(CType((Me.Terraformer + 44 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = -1F
								Else
									__Dereference(CType((Me.Terraformer + 44 / __SizeOf(GTerraformer)), __Pointer(Of Single))) = 1F
								End If
								<Module>.GEditorWorld.StartTerraforming(Me.World, Me.Terraformer, e.X, e.Y, False, False)
								Me.DragX = num
								Me.DragZ = num2
								If Me.propBrushType = 23 Then
									Me.DragMode = 5
								End If
							End If
						Else If Me.DragMode <> 5 Then
							Me.RefreshTerraformer()
							Me.DragMode = 7
							<Module>.GEditorWorld.StartTerraforming(Me.World, Me.Terraformer, e.X, e.Y, False, False)
						End If
					End If
					IL_EE8:
					If Me.EditorMode = 2 AndAlso num >= 0F Then
						Me.RefreshTerraformer()
						If Me.propPaintType = 15 AndAlso __Dereference((Me.KeyTimes + 136)) <> 0L Then
							Dim gColor As GColor
							<Module>.GColor.{ctor}(gColor, <Module>.GEditorWorld.GetVertexColor(Me.World, num, num2))
							cpblk(Me.Terraformer + 16 / __SizeOf(GTerraformer), gColor, 16)
							Me.TerrainTools.SetColor(<Module>.GColor..K(Me.Terraformer + 16 / __SizeOf(GTerraformer)))
						Else If <Module>.GEditorWorld.StartTerraforming(Me.World, Me.Terraformer, e.X, e.Y, False, False) IsNot Nothing Then
							Me.DragMode = 7
						End If
					End If
					If Me.EditorMode = 15 Then
						<Module>.GEditorWorld.ClearParcelSelection(Me.World)
						If <Module>.GEditorWorld.IsParcelSelectionValid(Me.World) Is Nothing Then
							Me.DragMode = 25
							Me.DragX = num
							Me.DragZ = num2
						Else
							Me.DragMode = 0
						End If
						Me.SectorSelectionNeedsUpdate = True
					End If
					If Me.EditorMode = 8 AndAlso num >= 0F Then
						Dim num16 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim gRay8 As GRay
						Dim num17 As Integer = <Module>.GWorld.GetTargetWirePoint(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay8, e.X, e.Y, __Dereference(num16)))
						If num17 >= 0 Then
							<Module>.GWorld.SelectWirePoint(Me.World, num17, 48)
							<Module>.GWorld.UpdateWirePoint(Me.World, num17, True)
							Me.DragMode = 24
							Me.DragX = num
							Me.DragZ = num2
						End If
					End If
					Dim dragMode As Integer = Me.DragMode
					If dragMode <> 0 AndAlso dragMode >= 6 Then
						Me.panMainViewport.Capture = True
					End If
				Else If e.Button = MouseButtons.Right Then
					Me.DragPreventMenu = Me.CancelDepressedDrag(True)
					Me.CompletePressedDrag(e.X, e.Y)
					If Me.EntityType <> 0 Then
						Dim num18 As Integer = __Dereference(CType(Me.World, __Pointer(Of Integer))) + 8
						Dim num19 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim gRay9 As GRay
						Dim num20 As Integer = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GRay modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), Me.World, Me.EntityType, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay9, e.X, e.Y, __Dereference(num19)), 0, __Dereference(num18))
						If num20 >= 0 Then
							Dim world14 As __Pointer(Of GEditorWorld) = Me.World
							If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world14, Me.EntityType, num20, __Dereference((__Dereference(CType(world14, __Pointer(Of Integer))) + 28))) Then
								Dim entityType2 As Integer = Me.EntityType
								If __Dereference((Me.EntityLockSelection + entityType2)) = 0 Then
									Dim world15 As __Pointer(Of GEditorWorld) = Me.World
									calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), world15, entityType2, num20, 16, __Dereference((__Dereference(CType(world15, __Pointer(Of Integer))) + 16)))
									Dim currentScriptEnittyToolbar2 As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
									If currentScriptEnittyToolbar2 IsNot Nothing Then
										currentScriptEnittyToolbar2.UpdateHilighting()
									End If
								End If
							End If
						End If
					End If
					Me.DragMX = e.X
					Me.DragMY = e.Y
					Dim editorMode2 As Integer = Me.EditorMode
					If editorMode2 = 1 Then
						Dim num21 As Integer = Me.propBrushType
						If num21 < 20 OrElse num21 = 24 Then
							GoTo IL_11A5
						End If
					End If
					If editorMode2 <> 2 Then
						GoTo IL_11CE
					End If
					IL_11A5:
					If __Dereference((Me.KeyTimes + 128)) <> 0L AndAlso Me.BrushSize IsNot Nothing Then
						Me.DragMode = 20
						GoTo IL_129B
					End If
					IL_11CE:
					If editorMode2 = 1 Then
						Dim num22 As Integer = Me.propBrushType
						If num22 < 20 OrElse num22 = 24 Then
							GoTo IL_11EC
						End If
					End If
					If editorMode2 <> 2 Then
						GoTo IL_1215
					End If
					IL_11EC:
					If __Dereference((Me.KeyTimes + 136)) <> 0L AndAlso Me.BrushSize IsNot Nothing Then
						Me.DragMode = 21
						GoTo IL_129B
					End If
					IL_1215:
					If editorMode2 = 11 Then
						Dim world16 As __Pointer(Of GEditorWorld) = Me.World
						If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world16, 5, __Dereference((__Dereference(CType(world16, __Pointer(Of Integer))) + 32))) AndAlso __Dereference((Me.KeyTimes + 128)) <> 0L Then
							Me.DragMode = 28
							GoTo IL_129B
						End If
					End If
					If Me.EditorMode = 11 Then
						Dim world17 As __Pointer(Of GEditorWorld) = Me.World
						If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world17, 5, __Dereference((__Dereference(CType(world17, __Pointer(Of Integer))) + 32))) AndAlso __Dereference((Me.KeyTimes + 136)) <> 0L Then
							Me.DragMode = 27
							GoTo IL_129B
						End If
					End If
					Me.DragMode = 19
					IL_129B:
					Me.DragStarted = False
					Me.panMainViewport.Capture = True
					<Module>.ShowCursor(0)
				Else If e.Button = MouseButtons.Middle Then
					Me.CompletePressedDrag(e.X, e.Y)
					Me.CancelDepressedDrag(True)
					Me.DragMX = e.X
					Me.DragMY = e.Y
					Me.DragMode = 18
					Me.panMainViewport.Capture = True
					<Module>.ShowCursor(0)
				End If
			End If
		End Sub

		Private Sub panMainViewport_MouseUp(sender As Object, e As MouseEventArgs)
			Me.SelectionPossible = False
			If Me.GameDebugMode Then
				Me.DebugMouseUp(sender, e)
			Else If e.Button = MouseButtons.Left Then
				Me.CompletePressedDrag(e.X, e.Y)
				Dim entityType As Integer = Me.EntityType
				If entityType <> 0 AndAlso __Dereference((entityType * 4 + Me.EntityOperation)) = 2 Then
					Me.StartEntityPreCreate()
				Else If(entityType = 9 OrElse entityType = 11 OrElse entityType = 13 OrElse entityType = 15 OrElse entityType = 17) AndAlso __Dereference((entityType * 4 + Me.EntityOperation)) = 4 Then
					Me.StartEntityPreCreateNode()
				End If
				Dim editorMode As Integer = Me.EditorMode
				If editorMode = 10 Then
					Me.UnitPropertiesTools.Refresh(Me.World)
				Else If editorMode = 9 Then
					Me.BuildingPropertiesTools.Refresh(Me.World)
				End If
			Else If e.Button = MouseButtons.Right Then
				If(Me.DragMode <> 0 AndAlso Me.DragStarted) OrElse Me.DragPreventMenu Then
					Me.CompletePressedDrag(e.X, e.Y)
					Me.DragPreventMenu = False
				Else
					Me.CompletePressedDrag(e.X, e.Y)
					Me.MapNoteX = e.X
					Me.MapNoteY = e.Y
					Dim pos As Point = New Point(e.X, e.Y)
					Me.MainViewPopupMenu.Show(Me.panMainViewport, pos)
				End If
			Else If e.Button = MouseButtons.Middle Then
				Me.CompletePressedDrag(e.X, e.Y)
			End If
		End Sub

		Private Sub panMainViewport_MouseMove(sender As Object, e As MouseEventArgs)
			If Form.ActiveForm Is Me Then
				Me.panMainViewport.Focus()
				If Me.GameDebugMode Then
					Me.DebugMouseMove(sender, e)
				Else If Me.World IsNot Nothing Then
					Dim num As Single
					Dim mouseTargetY As Single
					Dim num2 As Single
					If Me.EditorMode = 15 Then
						<Module>.GWorld.GetPointInTopMode(Me.World, Me.IViewport, CSng(e.X), CSng(e.Y), num, mouseTargetY, num2)
					Else If Me.DragMode = 4 Then
						Dim num3 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim gRay As GRay
						<Module>.GEditorWorld.GetPasteTarget(Me.World, Me.Clipboard, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, e.X, e.Y, __Dereference(num3)), num, mouseTargetY, num2)
					Else
						Dim num4 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim gRay2 As GRay
						<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay2, e.X, e.Y, __Dereference(num4)), num, mouseTargetY, num2)
					End If
					Me.MouseTargetX = num
					Me.MouseTargetY = mouseTargetY
					Me.MouseTargetZ = num2
					If Me.SelectionPossible AndAlso (e.X <> Me.DragMX OrElse e.Y <> Me.DragMY) Then
						Me.DragMode = 7
						Me.RefreshTerraformer()
						<Module>.GEditorWorld.StartTerraforming(Me.World, Me.Terraformer)
						Me.SelectionActive = True
						Me.SelectionPossible = False
					End If
					Select Case Me.DragMode
						Case 1, 2
							Dim num5 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
							Dim gRay3 As GRay
							<Module>.GEditorWorld.FollowEntityPlace(Me.World, num, num2, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay3, e.X, e.Y, __Dereference(num5)))
							GoTo IL_B14
						Case 3
							<Module>.GEditorWorld.FollowEntityPaste(Me.World, num, num2)
							GoTo IL_B14
						Case 4
							If num >= 0F Then
								<Module>.GEditorWorld.DragPaste(Me.World, Me.Clipboard, <Module>.fround(num), <Module>.fround(num2))
								GoTo IL_B14
							End If
							GoTo IL_B14
						Case 5, 7
							<Module>.GEditorWorld.Terraform(Me.World, e.X, e.Y, False, False)
							GoTo IL_B14
						Case 9
							Dim num6 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
							Dim gRay4 As GRay
							<Module>.GEditorWorld.FollowEntityMove(Me.World, num, num2, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay4, e.X, e.Y, __Dereference(num6)))
							GoTo IL_B14
						Case 10
							<Module>.GEditorWorld.FollowEntityLift(Me.World, e.Y)
							GoTo IL_B14
						Case 11
							If Me.EntityType <> 7 Then
								<Module>.GEditorWorld.FollowEntityRotate(Me.World, e.Y)
								GoTo IL_B14
							End If
							If e.Y - Me.DragMY > 20 Then
								<Module>.?TransformSelectedDecals@GEditorWorld@@$$FQAEXW4GDecalOp@@@Z(Me.World, 403)
								Me.DragMY = e.Y
								GoTo IL_B14
							End If
							If Me.DragMY - e.Y > 20 Then
								<Module>.?TransformSelectedDecals@GEditorWorld@@$$FQAEXW4GDecalOp@@@Z(Me.World, 402)
								Me.DragMY = e.Y
								GoTo IL_B14
							End If
							GoTo IL_B14
						Case 12
							<Module>.GEditorWorld.FollowEntityPointRotate(Me.World, e.Y)
							GoTo IL_B14
						Case 13
							<Module>.GEditorWorld.FollowEntityTilt(Me.World, num, num2)
							GoTo IL_B14
						Case 14, 15
							<Module>.GWorld.SetBoxSelection(Me.World, Me.DragMX, Me.DragMY, e.X, e.Y)
							Dim num7 As Integer = __Dereference(CType(Me.World, __Pointer(Of Integer))) + 20
							Dim num8 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 60
							Dim gPyramid As GPyramid
							calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GPyramid modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32), Me.World, Me.EntityType, calli(GPyramid* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPyramid*,System.Int32,System.Int32,System.Int32,System.Int32), Me.IViewport, gPyramid, Me.DragMX, Me.DragMY, e.X, e.Y, __Dereference(num8)), 33, __Dereference(num7))
							Dim currentScriptEnittyToolbar As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
							If currentScriptEnittyToolbar IsNot Nothing Then
								currentScriptEnittyToolbar.UpdateHilighting()
								GoTo IL_B14
							End If
							GoTo IL_B14
						Case 16
							<Module>.GEditorWorld.FollowEntityScale(Me.World, e.Y)
							GoTo IL_B14
						Case 17
							Dim num9 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
							Dim gRay5 As GRay
							<Module>.GEditorWorld.FollowEntityPostPlace(Me.World, num, num2, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay5, e.X, e.Y, __Dereference(num9)))
							GoTo IL_B14
						Case 18
							If e.X <> Me.DragMX OrElse e.Y <> Me.DragMY Then
								<Module>.GWorld.CameraRotate(Me.World, CSng((CDec((e.X - Me.DragMX)) * 0.002)), CSng((CDec((e.Y - Me.DragMY)) * 0.002)))
								Dim dragMX As tagPOINT = Me.DragMX
								__Dereference((dragMX + 4)) = Me.DragMY
								<Module>.ClientToScreen(CType(Me.panMainViewport.Handle.ToPointer(), __Pointer(Of HWND__)), AddressOf dragMX)
								<Module>.SetCursorPos(dragMX, __Dereference((dragMX + 4)))
								Me.MinimapViewportNeedsUpdate = True
								GoTo IL_B14
							End If
							GoTo IL_B14
						Case 19
							If(Me.DragStarted OrElse Math.Abs(e.X - Me.DragMX) >= 2 OrElse Math.Abs(e.Y - Me.DragMY) >= 2) AndAlso (e.X <> Me.DragMX OrElse e.Y <> Me.DragMY) Then
								Me.DragStarted = True
								<Module>.GWorld.CameraMove(Me.World, CSng((CDec((Me.DragMY - e.Y)) * 0.02)), CSng((CDec((e.X - Me.DragMX)) * 0.02)))
								Dim dragMX2 As tagPOINT = Me.DragMX
								__Dereference((dragMX2 + 4)) = Me.DragMY
								<Module>.ClientToScreen(CType(Me.panMainViewport.Handle.ToPointer(), __Pointer(Of HWND__)), AddressOf dragMX2)
								<Module>.SetCursorPos(dragMX2, __Dereference((dragMX2 + 4)))
								Me.MinimapViewportNeedsUpdate = True
								GoTo IL_B14
							End If
							GoTo IL_B14
						Case 20
							If(Me.DragStarted OrElse Math.Abs(e.X - Me.DragMX) >= 2 OrElse Math.Abs(e.Y - Me.DragMY) >= 2) AndAlso (e.X <> Me.DragMX OrElse e.Y <> Me.DragMY) Then
								Me.DragStarted = True
								Dim brushSize As __Pointer(Of Single) = Me.BrushSize
								Dim num10 As Single = CSng((CDec((e.X - Me.DragMX)) * 0.02 + CDec((__Dereference(brushSize)))))
								Me.BrushSize = num10
								If Me.EditorMode = 1 Then
									Dim num11 As Integer = Me.propBrushType
									If(num11 < 20 AndAlso Me.VertexFalloffType = 101) OrElse (num11 = 24 AndAlso Me.SelectionFalloffType = 101) Then
										Dim brushSize2 As __Pointer(Of Single) = Me.BrushSize2
										Dim num12 As Single = CSng((CDec((Me.DragMY - e.Y)) * 0.1 + CDec((__Dereference(brushSize2)))))
										Me.BrushSize2 = num12
									End If
								End If
								Me.UpdateBrushSliders()
								Dim dragMX3 As tagPOINT = Me.DragMX
								__Dereference((dragMX3 + 4)) = Me.DragMY
								<Module>.ClientToScreen(CType(Me.panMainViewport.Handle.ToPointer(), __Pointer(Of HWND__)), AddressOf dragMX3)
								<Module>.SetCursorPos(dragMX3, __Dereference((dragMX3 + 4)))
								GoTo IL_B14
							End If
							GoTo IL_B14
						Case 21
							If(Me.DragStarted OrElse Math.Abs(e.X - Me.DragMX) >= 2 OrElse Math.Abs(e.Y - Me.DragMY) >= 2) AndAlso (e.X <> Me.DragMX OrElse e.Y <> Me.DragMY) Then
								Me.DragStarted = True
								Dim brushPressure As __Pointer(Of Single) = Me.BrushPressure
								Dim num13 As Single = CSng((CDec((e.X - Me.DragMX)) * 0.2 + CDec((__Dereference(brushPressure)))))
								Me.BrushPressure = num13
								If Me.EditorMode = 1 Then
									Dim num14 As Integer = Me.propBrushType
									If num14 = 6 OrElse num14 = 5 OrElse num14 = 4 Then
										Dim brushHeight As __Pointer(Of Single) = Me.BrushHeight
										Dim num15 As Single = CSng((CDec((Me.DragMY - e.Y)) * 0.1 + CDec((__Dereference(brushHeight)))))
										Me.BrushHeight = num15
									End If
								End If
								Me.UpdateBrushSliders()
								Dim dragMX4 As tagPOINT = Me.DragMX
								__Dereference((dragMX4 + 4)) = Me.DragMY
								<Module>.ClientToScreen(CType(Me.panMainViewport.Handle.ToPointer(), __Pointer(Of HWND__)), AddressOf dragMX4)
								<Module>.SetCursorPos(dragMX4, __Dereference((dragMX4 + 4)))
								GoTo IL_B14
							End If
							GoTo IL_B14
						Case 22, 23
							Dim num16 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
							Dim gRay6 As GRay
							<Module>.GWorld.SelectWirePoint(Me.World, <Module>.GWorld.GetTargetWirePoint(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay6, e.X, e.Y, __Dereference(num16))), 33)
							GoTo IL_B14
						Case 24
							GoTo IL_B14
						Case 25
							<Module>.GEditorWorld.SetParcelSelection(Me.World, Me.DragX, Me.DragZ, num, num2)
							Me.SectorSelectionNeedsUpdate = True
							GoTo IL_B14
						Case 27
							If(Me.DragStarted OrElse Math.Abs(e.X - Me.DragMX) >= 2 OrElse Math.Abs(e.Y - Me.DragMY) >= 2) AndAlso (e.X <> Me.DragMX OrElse e.Y <> Me.DragMY) Then
								Me.DragStarted = True
								If Me.EditorMode = 11 Then
									Dim world As __Pointer(Of GEditorWorld) = Me.World
									If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, 5, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) Then
										<Module>.GEditorWorld.ChangeSelectedAmbientMinRange(Me.World, CSng((CDec((e.X - Me.DragMX)) * 0.1)))
									End If
								End If
								Dim dragMX5 As tagPOINT = Me.DragMX
								__Dereference((dragMX5 + 4)) = Me.DragMY
								<Module>.ClientToScreen(CType(Me.panMainViewport.Handle.ToPointer(), __Pointer(Of HWND__)), AddressOf dragMX5)
								<Module>.SetCursorPos(dragMX5, __Dereference((dragMX5 + 4)))
								GoTo IL_B14
							End If
							GoTo IL_B14
						Case 28
							If(Me.DragStarted OrElse Math.Abs(e.X - Me.DragMX) >= 2 OrElse Math.Abs(e.Y - Me.DragMY) >= 2) AndAlso (e.X <> Me.DragMX OrElse e.Y <> Me.DragMY) Then
								Me.DragStarted = True
								If Me.EditorMode = 11 Then
									Dim world2 As __Pointer(Of GEditorWorld) = Me.World
									If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world2, 5, __Dereference((__Dereference(CType(world2, __Pointer(Of Integer))) + 32))) Then
										<Module>.GEditorWorld.ChangeSelectedAmbientMaxRange(Me.World, CSng((CDec((e.X - Me.DragMX)) * 0.1)))
									End If
								End If
								Dim dragMX6 As tagPOINT = Me.DragMX
								__Dereference((dragMX6 + 4)) = Me.DragMY
								<Module>.ClientToScreen(CType(Me.panMainViewport.Handle.ToPointer(), __Pointer(Of HWND__)), AddressOf dragMX6)
								<Module>.SetCursorPos(dragMX6, __Dereference((dragMX6 + 4)))
								GoTo IL_B14
							End If
							GoTo IL_B14
					End Select
					If Me.EditorMode = 8 Then
						Dim num17 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim gRay7 As GRay
						<Module>.GWorld.SelectWirePoint(Me.World, <Module>.GWorld.GetTargetWirePoint(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay7, e.X, e.Y, __Dereference(num17))), 33)
					Else If Me.EntityType <> 0 Then
						Dim num18 As Integer = __Dereference(CType(Me.World, __Pointer(Of Integer))) + 24
						Dim num19 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
						Dim gRay8 As GRay
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,GRay modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Int32), Me.World, Me.EntityType, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay8, e.X, e.Y, __Dereference(num19)), 33, __Dereference(num18))
						Dim currentScriptEnittyToolbar2 As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
						If currentScriptEnittyToolbar2 IsNot Nothing Then
							currentScriptEnittyToolbar2.UpdateHilighting()
						End If
					End If
					IL_B14:
					Dim editorMode As Integer = Me.EditorMode
					If editorMode = 1 OrElse editorMode = 2 Then
						Me.BrushNeedsUpdate = True
						Me.BrushX = num
						Me.BrushZ = num2
						If Me.propPaintType = 14 Then
							Dim num20 As Single
							If num >= 0F Then
								num20 = num * 0.0625F
							Else
								num20 = -1F
							End If
							Dim num21 As Integer = CInt((CDec(num20)))
							Dim num22 As Single
							If num2 >= 0F Then
								num22 = num2 * 0.0625F
							Else
								num22 = -1F
							End If
							Dim num23 As Integer = CInt((CDec(num22)))
							If Not Me.TileDataValid OrElse num21 <> Me.TileParcelX OrElse num23 <> Me.TileParcelZ Then
								Me.TileParcelX = num21
								Me.TileParcelZ = num23
								Me.TileDataValid = True
								Me.TerrainFilePicker.UpdateLayerUsage(<Module>.GEditorWorld.GetLayerUsageFlags(Me.World, num21, num23))
							End If
						End If
					End If
				End If
			End If
		End Sub

		Private Sub panMainViewport_MouseWheel(sender As Object, e As MouseEventArgs)
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing OrElse Me.GameDebugWorld IsNot Nothing Then
				Dim editorMode As Integer = Me.EditorMode
				If editorMode = 2 AndAlso __Dereference((Me.KeyTimes + 128)) <> 0L Then
					If e.Delta > 0 Then
						Dim ptr As __Pointer(Of GTerraformer) = Me.Terraformer + 12 / __SizeOf(GTerraformer)
						Dim num As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
						If num < 19 Then
							__Dereference(CType(ptr, __Pointer(Of Integer))) = num + 1
						End If
					End If
					If e.Delta < 0 Then
						Dim ptr2 As __Pointer(Of GTerraformer) = Me.Terraformer + 12 / __SizeOf(GTerraformer)
						Dim num2 As Integer = __Dereference(CType(ptr2, __Pointer(Of Integer)))
						If num2 > 0 Then
							__Dereference(CType(ptr2, __Pointer(Of Integer))) = num2 - 1
						End If
					End If
					Me.TerrainFilePicker.SelectLayer(__Dereference(CType((Me.Terraformer + 12 / __SizeOf(GTerraformer)), __Pointer(Of Integer))))
				Else If editorMode = 11 AndAlso calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, 5, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) AndAlso __Dereference((Me.KeyTimes + 128)) <> 0L Then
					<Module>.GEditorWorld.ChangeSelectedAmbientVolume(Me.World, CSng(e.Delta) * 0.0003F)
				Else If Me.GameDebugMode Then
					<Module>.GWorld.CameraZoom(Me.GameDebugWorld, CSng(e.Delta) * 0.008333334F * -2F)
				Else
					<Module>.GWorld.CameraZoom(Me.World, CSng(e.Delta) * 0.008333334F * -2F)
					Me.MinimapViewportNeedsUpdate = True
				End If
			End If
		End Sub

		Private Sub menuEditUndo_Click(sender As Object, e As EventArgs)
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				If Me.EditorMode <> 15 Then
					Me.LastCameraType = <Module>.?GetCameraType@GWorld@@$$FQBE?AW4GCameraType@@XZ(world)
					<Module>.GWorld.GetCamera(Me.World, Me.LastCamera)
				End If
				<Module>.GEditorWorld.Undo(Me.World)
				If Me.EditorMode <> 15 Then
					<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(Me.World, Me.LastCameraType)
					<Module>.GWorld.SetCamera(Me.World, Me.LastCamera)
					Me.InitMinimap()
				End If
				If Me.EditorMode = 2 Then
					Me.TerrainFilePicker.UpdateLayerList(-1, 0)
				End If
				Dim editorMode As Integer = Me.EditorMode
				If editorMode = 10 Then
					Me.UnitPropertiesTools.Refresh(Me.World)
				Else If editorMode = 9 Then
					Me.BuildingPropertiesTools.Refresh(Me.World)
				End If
				Me.RefreshMenuAndToolbarItems()
				Me.RefreshMinimap()
			End If
		End Sub

		Private Sub menuEditRedo_Click(sender As Object, e As EventArgs)
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				If Me.EditorMode <> 15 Then
					Me.LastCameraType = <Module>.?GetCameraType@GWorld@@$$FQBE?AW4GCameraType@@XZ(world)
					<Module>.GWorld.GetCamera(Me.World, Me.LastCamera)
				End If
				<Module>.GEditorWorld.Redo(Me.World)
				If Me.EditorMode <> 15 Then
					<Module>.?SetCameraType@GWorld@@$$FQAEXW4GCameraType@@@Z(Me.World, Me.LastCameraType)
					<Module>.GWorld.SetCamera(Me.World, Me.LastCamera)
					Me.InitMinimap()
				End If
				If Me.EditorMode = 2 Then
					Me.TerrainFilePicker.UpdateLayerList(-1, 0)
				End If
				Dim editorMode As Integer = Me.EditorMode
				If editorMode = 10 Then
					Me.UnitPropertiesTools.Refresh(Me.World)
				Else If editorMode = 9 Then
					Me.BuildingPropertiesTools.Refresh(Me.World)
				End If
				Me.RefreshMenuAndToolbarItems()
				Me.RefreshMinimap()
			End If
		End Sub

		Private Sub menuEditCut_Click(sender As Object, e As EventArgs)
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				Dim entityType As Integer = Me.EntityType
				If entityType <> 0 Then
					<Module>.?CutSelectedEntities@GEditorWorld@@$$FQAEXW4GEntityType@@AAUGEntityClipboard@@@Z(world, entityType, Me.EntityClipboard)
				End If
				Me.RefreshMenuAndToolbarItems()
			End If
		End Sub

		Private Sub menuEditCopy_Click(sender As Object, e As EventArgs)
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				If Me.EditorMode = 1 Then
					Dim clipboard As __Pointer(Of GWorldClipboard) = Me.Clipboard
					If clipboard IsNot Nothing Then
						Dim ptr As __Pointer(Of GWorldClipboard) = clipboard
						<Module>.GWorldClipboard.{dtor}(ptr)
						<Module>.delete(CType(ptr, __Pointer(Of Void)))
						Me.Clipboard = Nothing
					End If
					Me.Clipboard = <Module>.GEditorWorld.Copy(Me.World)
				Else
					Dim entityType As Integer = Me.EntityType
					If entityType <> 0 Then
						<Module>.?CopySelectedEntities@GEditorWorld@@$$FQAEXW4GEntityType@@AAUGEntityClipboard@@@Z(world, entityType, Me.EntityClipboard)
					End If
				End If
				Me.RefreshMenuAndToolbarItems()
			End If
		End Sub

		Private Sub menuEditPaste_Click(sender As Object, e As EventArgs)
			If Me.World IsNot Nothing Then
				Me.StartPaste()
				Me.RefreshMenuAndToolbarItems()
			End If
		End Sub

		Private Sub menuEditDelete_Click(sender As Object, e As EventArgs)
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				Select Case Me.EditorMode
					Case 3, 4, 5, 6, 7, 9, 10, 11, 12, 16, 17, 18, 21
						<Module>.?RemoveSelectedEntities@GEditorWorld@@$$FQAEXW4GEntityType@@@Z(world, Me.EntityType)
						Dim currentEntityToolbar As ToolboxEntities = Me.CurrentEntityToolbar
						If currentEntityToolbar IsNot Nothing AndAlso __Dereference((Me.EntityLockSelection + Me.EntityType)) <> 0 Then
							currentEntityToolbar.EmulatePushByID(303)
							Me.CurrentEntityToolbar.EmulateUpByID(303)
						End If
					Case 8
						Dim num As Integer = __Dereference(CType((world + 3104 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
						If num >= 0 Then
							<Module>.GWorld.RemoveWirePointConnections(world, num)
						End If
				End Select
				Me.RefreshMenuAndToolbarItems()
			End If
		End Sub

		Private Sub panMainViewport_DoubleClick(sender As Object, e As EventArgs)
			If Not Me.GameDebugMode Then
				Dim world As __Pointer(Of GEditorWorld) = Me.World
				If world IsNot Nothing Then
					Select Case Me.EntityType
						Case 13, 14
							<Module>.GEditorWorld.SelectAllCorrespondingCameraCurveNodes(world)
						Case 15, 16
							<Module>.GEditorWorld.SelectAllCorrespondingPathNodes(world)
						Case 17, 18
							<Module>.GEditorWorld.SelectAllCorrespondingLocationVertices(world)
					End Select
				End If
			End If
		End Sub

		Private Sub menuEditSelectAll_Click(sender As Object, e As EventArgs)
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				Dim entityType As Integer = Me.EntityType
				If entityType <> 0 Then
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world, entityType, 16, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 12)))
					Dim currentScriptEnittyToolbar As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
					If currentScriptEnittyToolbar IsNot Nothing Then
						currentScriptEnittyToolbar.UpdateHilighting()
					End If
					Dim editorMode As Integer = Me.EditorMode
					If editorMode = 10 Then
						Me.UnitPropertiesTools.Refresh(Me.World)
					Else If editorMode = 9 Then
						Me.BuildingPropertiesTools.Refresh(Me.World)
					End If
				Else
					Dim editorMode As Integer = Me.EditorMode
					If editorMode = 1 OrElse editorMode = 2 Then
						<Module>.GEditorWorld.SelectAll(world)
					End If
				End If
				Me.RefreshMenuAndToolbarItems()
			End If
		End Sub

		Private Sub menuEditSelectNone_Click(sender As Object, e As EventArgs)
			Dim world As __Pointer(Of GEditorWorld) = Me.World
			If world IsNot Nothing Then
				Dim entityType As Integer = Me.EntityType
				If entityType <> 0 Then
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), world, entityType, 0, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 12)))
					Dim currentEntityToolbar As ToolboxEntities = Me.CurrentEntityToolbar
					If currentEntityToolbar IsNot Nothing AndAlso __Dereference((Me.EntityLockSelection + Me.EntityType)) <> 0 Then
						currentEntityToolbar.EmulatePushByID(303)
						Me.CurrentEntityToolbar.EmulateUpByID(303)
					End If
					Dim currentScriptEnittyToolbar As ToolboxScriptEntities = Me.CurrentScriptEnittyToolbar
					If currentScriptEnittyToolbar IsNot Nothing Then
						currentScriptEnittyToolbar.UpdateHilighting()
					End If
				Else
					Dim editorMode As Integer = Me.EditorMode
					If editorMode = 1 OrElse editorMode = 2 Then
						<Module>.GEditorWorld.SelectNone(world)
						Me.SelectionActive = False
					End If
				End If
				Me.RefreshMenuAndToolbarItems()
			End If
		End Sub

		Private Sub menuModeVertex_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(1)
		End Sub

		Private Sub menuModePaint_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(2)
		End Sub

		Private Sub menuModeRoad_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(3)
		End Sub

		Private Sub menuModeDecal_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(4)
		End Sub

		Private Sub menuModeLake_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(5)
		End Sub

		Private Sub menuModeRiver_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(6)
		End Sub

		Private Sub menuModeCameraCurve_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(16)
		End Sub

		Private Sub menuModePaths_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(17)
		End Sub

		Private Sub menuModeLocations_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(18)
		End Sub

		Private Sub menuModeUnitGroup_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(19)
		End Sub

		Private Sub menuModeDoodad_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(7)
		End Sub

		Private Sub menuModeWire_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(8)
		End Sub

		Private Sub menuModeBuilding_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(9)
		End Sub

		Private Sub menuModeUnit_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(10)
		End Sub

		Private Sub menuModeAmbient_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(11)
		End Sub

		Private Sub menuModeEffect_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(12)
		End Sub

		Private Sub menuModeSectors_Click(sender As Object, e As EventArgs)
			Me.SetEditorMode(15)
		End Sub

		Private Sub menuViewSidebarLeft_Click(sender As Object, e As EventArgs)
			MyBase.SuspendLayout()
			Me.panSideBar.Dock = DockStyle.Left
			Me.splitMain.Dock = DockStyle.Left
			Me.panSideBar.Visible = True
			Me.splitMain.Visible = True
			MyBase.ResumeLayout()
			Me.menuViewSidebarLeft.Checked = True
			Me.menuViewSidebarRight.Checked = False
			Me.menuViewSidebarOff.Checked = False
			__Dereference((<Module>.Options + 4)) = 0
			<Module>.SaveOptions()
		End Sub

		Private Sub menuViewSidebarRight_Click(sender As Object, e As EventArgs)
			MyBase.SuspendLayout()
			Me.panSideBar.Dock = DockStyle.Right
			Me.splitMain.Dock = DockStyle.Right
			Me.panSideBar.Visible = True
			Me.splitMain.Visible = True
			MyBase.ResumeLayout()
			Me.menuViewSidebarLeft.Checked = False
			Me.menuViewSidebarRight.Checked = True
			Me.menuViewSidebarOff.Checked = False
			__Dereference((<Module>.Options + 4)) = 1
			<Module>.SaveOptions()
		End Sub

		Private Sub menuViewSidebarOff_Click(sender As Object, e As EventArgs)
			MyBase.SuspendLayout()
			Me.panSideBar.Visible = False
			Me.splitMain.Visible = False
			MyBase.ResumeLayout()
			Me.menuViewSidebarLeft.Checked = False
			Me.menuViewSidebarRight.Checked = False
			Me.menuViewSidebarOff.Checked = True
			__Dereference((<Module>.Options + 4)) = 2
			<Module>.SaveOptions()
		End Sub

		Private Sub menuViewToolbar_Click(sender As Object, e As EventArgs)
			Dim checked As Byte = If((Not Me.menuViewToolbar.Checked), 1, 0)
			Me.menuViewToolbar.Checked = (checked <> 0)
			Me.tbMain.Visible = Me.menuViewToolbar.Checked
			<Module>.Options = Me.menuViewToolbar.Checked
			<Module>.SaveOptions()
		End Sub

		Private Sub menuViewStatusBar_Click(sender As Object, e As EventArgs)
			Dim checked As Byte = If((Not Me.menuViewStatusBar.Checked), 1, 0)
			Me.menuViewStatusBar.Checked = (checked <> 0)
			Me.sbMain.Visible = Me.menuViewStatusBar.Checked
			__Dereference((<Module>.Options + 1)) = (If(Me.menuViewStatusBar.Checked, 1, 0))
			<Module>.SaveOptions()
		End Sub

		Private Sub menuSoundDisable_Click(sender As Object, e As EventArgs)
			Me.menuSoundDisable.Checked = True
			Me.menuSoundStereo.Checked = False
			Me.menuSoundQuad.Checked = False
			Me.menuSoundSurround.Checked = False
			If <Module>.ISoundSys IsNot Nothing Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.ISoundSys, 3, 2, __Dereference((__Dereference(CType(<Module>.ISoundSys, __Pointer(Of Integer))) + 28)))
			End If
		End Sub

		Private Sub menuSoundStereo_Click(sender As Object, e As EventArgs)
			Me.menuSoundDisable.Checked = False
			Me.menuSoundStereo.Checked = True
			Me.menuSoundQuad.Checked = False
			Me.menuSoundSurround.Checked = False
			If <Module>.ISoundSys IsNot Nothing Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.ISoundSys, 0, 2, __Dereference((__Dereference(CType(<Module>.ISoundSys, __Pointer(Of Integer))) + 28)))
			End If
		End Sub

		Private Sub menuSoundQuad_Click(sender As Object, e As EventArgs)
			Me.menuSoundDisable.Checked = False
			Me.menuSoundStereo.Checked = False
			Me.menuSoundQuad.Checked = True
			Me.menuSoundSurround.Checked = False
			If <Module>.ISoundSys IsNot Nothing Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.ISoundSys, 0, 3, __Dereference((__Dereference(CType(<Module>.ISoundSys, __Pointer(Of Integer))) + 28)))
			End If
		End Sub

		Private Sub menuSoundSurround_Click(sender As Object, e As EventArgs)
			Me.menuSoundDisable.Checked = False
			Me.menuSoundStereo.Checked = False
			Me.menuSoundQuad.Checked = False
			Me.menuSoundSurround.Checked = True
			If <Module>.ISoundSys IsNot Nothing Then
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), <Module>.ISoundSys, 0, 5, __Dereference((__Dereference(CType(<Module>.ISoundSys, __Pointer(Of Integer))) + 28)))
			End If
		End Sub

		Private Sub menuSoundReverseStereo_Click(sender As Object, e As EventArgs)
			Dim checked As Byte = If((Not Me.menuSoundReverseStereo.Checked), 1, 0)
			Me.menuSoundReverseStereo.Checked = (checked <> 0)
			If <Module>.ISoundSys IsNot Nothing Then
				Dim expr_27 As __Pointer(Of GISoundSys) = <Module>.ISoundSys
				Dim num As Integer = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_27, __Dereference((__Dereference(CType(expr_27, __Pointer(Of Integer))) + 12))) And -33
				Dim num2 As Integer = If(Me.menuSoundReverseStereo.Checked, 32, 0)
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.ISoundSys, num2 Or num, __Dereference((__Dereference(CType(<Module>.ISoundSys, __Pointer(Of Integer))) + 16)))
			End If
		End Sub

		Private Sub menuToolsUnitEditor_Click(sender As Object, e As EventArgs)
			Dim nUnitEditor As NUnitEditor = New NUnitEditor(Me.ToolWindows, String.Empty, Me.UnitEditorClipboard)
			AddHandler nUnitEditor.PUnitChanged, AddressOf Me.UnitEditor_PUnitChanged
			nUnitEditor.Show()
			<Module>.SaveOptions()
		End Sub

		Private Sub UnitEditor_PUnitChanged(punit_filename As __Pointer(Of SByte))
			If Me.World IsNot Nothing Then
				Dim num As Integer = -1
				While True
					Dim world As __Pointer(Of GEditorWorld) = Me.World
					Dim ptr As __Pointer(Of GHeap<GWUnit>) = world + 2884 / __SizeOf(GEditorWorld)
					Dim num2 As Integer = num + 1
					Dim num3 As Integer = __Dereference((ptr + 4))
					If num2 >= num3 Then
						Exit While
					End If
					Dim num4 As Integer = num2 * 124 + __Dereference(ptr)
					While __Dereference(num4) <> 2147483647
						num2 += 1
						num4 += 124
						If num2 >= num3 Then
							GoTo IL_7E
						End If
					End While
					num = num2
					If num2 < 0 Then
						Exit While
					End If
					Dim expr_65 As __Pointer(Of GEditorWorld) = world
					<Module>.GWorld.RemoveUnit(expr_65, __Dereference((__Dereference(CType((expr_65 + 2884 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + num2 * 124 + 108)))
				End While
				IL_7E:
				Dim num5 As Integer = -1
				While True
					Dim world As __Pointer(Of GEditorWorld) = Me.World
					Dim ptr2 As __Pointer(Of GHeap<GWUnit>) = world + 2884 / __SizeOf(GEditorWorld)
					Dim num6 As Integer = num5 + 1
					Dim num7 As Integer = __Dereference((ptr2 + 4))
					If num6 >= num7 Then
						Exit While
					End If
					Dim num8 As Integer = num6 * 124 + __Dereference(ptr2)
					While __Dereference(num8) <> 2147483647
						num6 += 1
						num8 += 124
						If num6 >= num7 Then
							GoTo IL_12A
						End If
					End While
					num5 = num6
					If num6 < 0 Then
						Exit While
					End If
					Dim num9 As Integer = __Dereference(CType((world + 2884 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + num6 * 124 + 108
					Dim num10 As Integer = __Dereference(num9)
					Dim num11 As Integer
					If num10 >= 0 AndAlso num10 < __Dereference(CType((world + 2928 / __SizeOf(GEditorWorld) + 4 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) AndAlso __Dereference((num10 * 8 + __Dereference(CType((world + 2928 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))))) = 2147483647 Then
						num11 = 1
					Else
						num11 = 0
					End If
					If CByte(num11) = 0 Then
						__Dereference(num9) = -1
					End If
				End While
				IL_12A:
				Dim num12 As Integer = -1
				While True
					Dim world As __Pointer(Of GEditorWorld) = Me.World
					Dim ptr3 As __Pointer(Of GHeap<GWUnit>) = world + 2884 / __SizeOf(GEditorWorld)
					Dim num13 As Integer = num12 + 1
					Dim num14 As Integer = __Dereference((ptr3 + 4))
					If num13 >= num14 Then
						Exit While
					End If
					Dim num15 As Integer = num13 * 124 + __Dereference(ptr3)
					While __Dereference(num15) <> 2147483647
						num13 += 1
						num15 += 124
						If num13 >= num14 Then
							GoTo IL_1EA
						End If
					End While
					num12 = num13
					If num13 < 0 Then
						Exit While
					End If
					Dim num16 As Integer = __Dereference(CType((world + 2884 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + num13 * 124
					Dim num17 As Integer = __Dereference((num16 + 108))
					Dim num18 As Integer
					If num17 >= 0 AndAlso num17 < __Dereference(CType((world + 2928 / __SizeOf(GEditorWorld) + 4 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) AndAlso __Dereference((num17 * 8 + __Dereference(CType((world + 2928 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))))) = 2147483647 Then
						num18 = 1
					Else
						num18 = 0
					End If
					If CByte(num18) = 0 Then
						Dim num19 As Integer = num16 + 4
						Dim ptr4 As __Pointer(Of GWUnit) = num19
						__Dereference((num19 + 104)) = <Module>.GWorld.CreateUnit(world, ptr4)
					End If
				End While
				IL_1EA:
				Dim num20 As Integer = -1
				While True
					Dim ptr5 As __Pointer(Of GEditorWorld) = Me.World + 2884 / __SizeOf(GEditorWorld)
					Dim ptr6 As __Pointer(Of GHeap<GWUnit>) = ptr5
					Dim num21 As Integer = num20 + 1
					Dim num22 As Integer = __Dereference((ptr6 + 4))
					If num21 >= num22 Then
						Exit While
					End If
					Dim num23 As Integer = num21 * 124 + __Dereference(ptr6)
					While __Dereference(num23) <> 2147483647
						num21 += 1
						num23 += 124
						If num21 >= num22 Then
							Return
						End If
					End While
					num20 = num21
					If num21 < 0 Then
						Exit While
					End If
					Dim expr_247 As Integer = __Dereference(CType(ptr5, __Pointer(Of Integer))) + num21 * 124 + 4
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_247, __Dereference((__Dereference(expr_247) + 8)))
					Me.panMainViewport.Invalidate()
				End While
			End If
		End Sub

		Private Sub menuToolsEffectEditor_Click(sender As Object, e As EventArgs)
			Dim nEffectEditor As NEffectEditor = New NEffectEditor(Me.ToolWindows, "", Me.EffectEditorClipboard)
			Me.ToolWindows.Add(nEffectEditor)
			nEffectEditor.Show()
			<Module>.SaveOptions()
		End Sub

		Private Sub menuToolsScriptEditor_Click(sender As Object, e As EventArgs)
			Dim scriptEditorFormInstance As ScriptEditorForm = Me.ScriptEditorFormInstance
			If scriptEditorFormInstance IsNot Nothing Then
				scriptEditorFormInstance.Focus()
				Me.RegisterScriptRefreshCallback()
			Else If Me.World IsNot Nothing Then
				Me.ScriptEditorFormInstance = New ScriptEditorForm()
				AddHandler Me.ScriptEditorFormInstance.Closed, AddressOf Me.ScriptEditorForm_Closed
				Me.ScriptEditorFormInstance.Show()
				Me.RegisterScriptRefreshCallback()
				<Module>.SaveOptions()
			End If
		End Sub

		Private Sub ScriptEditorForm_Closed(sender As Object, e As EventArgs)
			Me.ScriptEditorFormInstance = Nothing
			__Dereference(CType((Me.World + 5080 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) = 0
		End Sub

		Private Sub EffectEditor_PEffectChanged(peffect_filename As __Pointer(Of SByte))
			If Me.World IsNot Nothing Then
				Dim num As Integer = -1
				While True
					Dim ptr As __Pointer(Of GEditorWorld) = Me.World + 3084 / __SizeOf(GEditorWorld)
					Dim ptr2 As __Pointer(Of GHeap<GWEffect>) = ptr
					Dim num2 As Integer = num + 1
					Dim num3 As Integer = __Dereference((ptr2 + 4))
					If num2 >= num3 Then
						Exit While
					End If
					Dim num4 As Integer = num2 * 60 + __Dereference(ptr2)
					While __Dereference(num4) <> 2147483647
						num2 += 1
						num4 += 60
						If num2 >= num3 Then
							Return
						End If
					End While
					num = num2
					If num2 < 0 Then
						Exit While
					End If
					Dim num5 As Integer = num2 * 60
					If(If((<Module>.GBaseString<char>.Compare(__Dereference(CType(ptr, __Pointer(Of Integer))) + num5 + 4 + 8, peffect_filename, False) = 0), 1, 0)) <> 0 Then
						Dim expr_91 As Integer = __Dereference((num5 + __Dereference(CType((Me.World + 3084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 52))
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_91, __Dereference((__Dereference(expr_91) + 4)))
						Dim expr_AE As Integer = __Dereference((num5 + __Dereference(CType((Me.World + 3084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 52))
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_AE, __Dereference((__Dereference(expr_AE))))
						Dim num6 As Integer = __Dereference((num5 + __Dereference(CType((Me.World + 3084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 52))
						If num6 <> 0 Then
							Dim expr_D1 As Integer = num6
							Dim expr_DB As Integer = expr_D1 + __Dereference((__Dereference((expr_D1 + 4)) + 4)) + 4
							Dim arg_E5_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_DB, __Dereference((__Dereference(expr_DB) + 4)))
							__Dereference((num5 + __Dereference(CType((Me.World + 3084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 52)) = 0
						End If
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>), <Module>.IEngine, __Dereference((num5 + __Dereference(CType((Me.World + 3084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 48)), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 216)))
						Dim ptr3 As __Pointer(Of GAEntity) = num5 + __Dereference(CType((Me.World + 3084 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 4
						calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), ptr3, num2, __Dereference((__Dereference(ptr3) + 4)))
						__Dereference((ptr3 + 4)) = 1
						Me.panMainViewport.Invalidate()
					End If
				End While
			End If
		End Sub

		Private Sub menuToolsGameVariables_Click(sender As Object, e As EventArgs)
			New NGameVariablesEditor(Me.ToolWindows).Show()
			<Module>.SaveOptions()
		End Sub

		Private Sub menuToolsMissionVariables_Click(sender As Object, e As EventArgs)
			New NMissionVariablesEditor(Me.ToolWindows, Me.World).Show()
			<Module>.SaveOptions()
		End Sub

		Private Sub panSideBar_Resize(sender As Object, e As EventArgs)
			Dim size As Size = Me.panSideBar.Size
			Me.panSideBar.ViewWidth = size.Width
			If Not Me.Rearranging Then
				Dim size2 As Size = Me.panSideBar.Size
				If Me.OldHeight <> size2.Height Then
					Dim size3 As Size = Me.panSideBar.Size
					Me.panSideBar.ViewHeight = size3.Height
					Me.LayoutChanged = True
				End If
			End If
		End Sub

		Private Sub panSideBarToolStateToggled()
			Me.LayoutChanged = True
		End Sub

		Private Sub MainViewPopupMenu_Popup(sender As Object, e As EventArgs)
			Me.MainViewPopupMenu.MenuItems.Clear()
			Me.MainViewPopupMenu.MergeMenu(Me.menuEdit)
			Dim item As MenuItem = New MenuItem("-")
			Me.MainViewPopupMenu.MenuItems.Add(item)
			Me.SelectedMapNote = <Module>.GEditorWorld.GetMapNoteAt(Me.World, Me.MapNoteX, Me.MapNoteY)
			Dim menuItem As MenuItem = New MenuItem("Create map note")
			Dim enabled As Byte = If((Me.SelectedMapNote = -1), 1, 0)
			menuItem.Enabled = (enabled <> 0)
			AddHandler menuItem.Click, AddressOf Me.menuItemCreateNote_Clicked
			Me.MainViewPopupMenu.MenuItems.Add(menuItem)
			Dim menuItem2 As MenuItem = New MenuItem("Edit map note")
			Dim enabled2 As Byte = If((Me.SelectedMapNote > -1), 1, 0)
			menuItem2.Enabled = (enabled2 <> 0)
			AddHandler menuItem2.Click, AddressOf Me.menuItemEditNote_Clicked
			Me.MainViewPopupMenu.MenuItems.Add(menuItem2)
			Dim menuItem3 As MenuItem = New MenuItem("Remove map note")
			Dim enabled3 As Byte = If((Me.SelectedMapNote > -1), 1, 0)
			menuItem3.Enabled = (enabled3 <> 0)
			AddHandler menuItem3.Click, AddressOf Me.menuItemRemoveNote_Clicked
			Me.MainViewPopupMenu.MenuItems.Add(menuItem3)
			Dim editorMode As Integer = Me.EditorMode
			If editorMode = 10 OrElse editorMode = 9 Then
				Dim world As __Pointer(Of GEditorWorld) = Me.World
				If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, Me.EntityType, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) > 0 Then
					Dim item2 As MenuItem = New MenuItem("-")
					Dim menuItem4 As MenuItem = New MenuItem("Unload All")
					AddHandler menuItem4.Click, AddressOf Me.menuItemUnloadAll_Clicked
					Me.MainViewPopupMenu.MenuItems.Add(item2)
					Me.MainViewPopupMenu.MenuItems.Add(menuItem4)
				End If
			End If
			If Me.EditorMode = 19 Then
				Dim item3 As MenuItem = New MenuItem("-")
				Me.MainViewPopupMenu.MenuItems.Add(item3)
				Dim world As __Pointer(Of GEditorWorld) = Me.World
				If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, Me.EntityType, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) > 0 Then
					Dim menuItem5 As MenuItem = New MenuItem("Add to new group")
					AddHandler menuItem5.Click, AddressOf Me.menuItemNewGroup_Clicked
					Me.MainViewPopupMenu.MenuItems.Add(menuItem5)
					Dim menuItem6 As MenuItem = New MenuItem("Add to selected group")
					AddHandler menuItem6.Click, AddressOf Me.menuItemAddtoGroup_Clicked
					Dim enabled4 As Byte = If((Me.CurrentScriptEnittyToolbar.SelectedEntityIndex >= 0), 1, 0)
					menuItem6.Enabled = (enabled4 <> 0)
					Me.MainViewPopupMenu.MenuItems.Add(menuItem6)
					Dim menuItem7 As MenuItem = New MenuItem("Remove from group")
					AddHandler menuItem7.Click, AddressOf Me.menuItemRemovefromGroup_Clicked
					Dim enabled5 As Byte = If((<Module>.GEditorWorld.GetSelectedAIGroup(Me.World) >= -1), 1, 0)
					menuItem7.Enabled = (enabled5 <> 0)
					Me.MainViewPopupMenu.MenuItems.Add(menuItem7)
				End If
				Dim menuItem8 As MenuItem = New MenuItem("Create empty group")
				AddHandler menuItem8.Click, AddressOf Me.menuItemNewEmptyGroup_Clicked
				Me.MainViewPopupMenu.MenuItems.Add(menuItem8)
			End If
			If Me.EditorMode = 15 AndAlso <Module>.GEditorWorld.IsParcelSelectionValid(Me.World) IsNot Nothing Then
				Dim item4 As MenuItem = New MenuItem("-")
				Me.MainViewPopupMenu.MenuItems.Add(item4)
				Dim menuItem9 As MenuItem = New MenuItem("Create sector")
				AddHandler menuItem9.Click, AddressOf Me.menuItemNewSector_Clicked
				Me.MainViewPopupMenu.MenuItems.Add(menuItem9)
				Dim menuItem10 As MenuItem = New MenuItem("Add to selected sector")
				AddHandler menuItem10.Click, AddressOf Me.menuItemAddtoSector_Clicked
				Dim enabled6 As Byte = If((Me.CurrentScriptEnittyToolbar.SelectedEntityIndex >= 0), 1, 0)
				menuItem10.Enabled = (enabled6 <> 0)
				Me.MainViewPopupMenu.MenuItems.Add(menuItem10)
				Dim menuItem11 As MenuItem = New MenuItem("Clear parcels")
				AddHandler menuItem11.Click, AddressOf Me.menuItemRemovefromSector_Clicked
				Dim enabled7 As Byte = If((<Module>.GEditorWorld.GetSelectedSector(Me.World) >= -1), 1, 0)
				menuItem11.Enabled = (enabled7 <> 0)
				Me.MainViewPopupMenu.MenuItems.Add(menuItem11)
			End If
			If Me.EditorMode = 17 Then
				Dim world As __Pointer(Of GEditorWorld) = Me.World
				If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), world, Me.EntityType, __Dereference((__Dereference(CType(world, __Pointer(Of Integer))) + 32))) = 1 Then
					Dim item5 As MenuItem = New MenuItem("-")
					Dim menuItem12 As MenuItem = New MenuItem("Waiting node")
					AddHandler menuItem12.Click, AddressOf Me.menuItemPathnodeWait_Clicked
					menuItem12.Checked = (<Module>.GEditorWorld.GetSelectedPathNodeWait(Me.World) IsNot Nothing)
					Me.MainViewPopupMenu.MenuItems.Add(item5)
					Me.MainViewPopupMenu.MenuItems.Add(menuItem12)
				End If
			End If
			If Me.EditorMode = 6 AndAlso <Module>.GEditorWorld.CountSelectedRivers(Me.World) = 1 Then
				Dim item6 As MenuItem = New MenuItem("-")
				Dim menuItem13 As MenuItem = New MenuItem("Waterfall")
				AddHandler menuItem13.Click, AddressOf Me.menuItemWaterfall_Clicked
				menuItem13.Checked = (<Module>.GEditorWorld.GetSelectedWaterFall(Me.World) IsNot Nothing)
				Me.MainViewPopupMenu.MenuItems.Add(item6)
				Me.MainViewPopupMenu.MenuItems.Add(menuItem13)
			End If
		End Sub

		Private Sub UnitFilePicker_ContextPopup(punit_filename As String)
		End Sub

		Private Sub BuildingFilePicker_ContextPopup(punit_filename As String)
		End Sub

		Private Sub menuItemUnloadAll_Clicked(sender As Object, e As EventArgs)
			Dim editorMode As Integer = Me.EditorMode
			If editorMode = 10 OrElse editorMode = 19 OrElse editorMode = 9 Then
				<Module>.GEditorWorld.UnloadAllStoredUnits(Me.World)
				Dim scriptEditorFormInstance As ScriptEditorForm = Me.ScriptEditorFormInstance
				If scriptEditorFormInstance IsNot Nothing Then
					scriptEditorFormInstance.EditorsChanged()
				End If
			End If
		End Sub

		Private Sub menuItemNewGroup_Clicked(sender As Object, e As EventArgs)
			<Module>.GEditorWorld.AddSelectedUnitsToGroup(Me.World, -1)
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub menuItemNewEmptyGroup_Clicked(sender As Object, e As EventArgs)
			<Module>.GEditorWorld.CreateEmptyGroup(Me.World)
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub menuItemAddtoGroup_Clicked(sender As Object, e As EventArgs)
			<Module>.GEditorWorld.AddSelectedUnitsToGroup(Me.World, Me.CurrentScriptEnittyToolbar.SelectedEntityIndex)
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub menuItemRemovefromGroup_Clicked(sender As Object, e As EventArgs)
			<Module>.GEditorWorld.RemoveSelectedUnitsFromGroup(Me.World)
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub menuItemNewSector_Clicked(sender As Object, e As EventArgs)
			<Module>.GEditorWorld.AddSelectedParcelsToSector(Me.World, -1)
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub menuItemAddtoSector_Clicked(sender As Object, e As EventArgs)
			<Module>.GEditorWorld.AddSelectedParcelsToSector(Me.World, Me.CurrentScriptEnittyToolbar.SelectedEntityIndex)
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub menuItemRemovefromSector_Clicked(sender As Object, e As EventArgs)
			<Module>.GEditorWorld.RemoveSelectedParcelsFromSector(Me.World)
			Me.RefreshMenuAndToolbarItems()
		End Sub

		Private Sub menuItemCreateNote_Clicked(sender As Object, e As EventArgs)
			Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
			Dim gRay As GRay
			Dim num As Single
			Dim num2 As Single
			Dim num3 As Single
			<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), iViewport, gRay, Me.MapNoteX, Me.MapNoteY, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 56))), num, num2, num3)
			Dim gPoint As GPoint3 = num
			__Dereference((gPoint + 4)) = num2
			__Dereference((gPoint + 8)) = num3
			Me.SelectedMapNote = <Module>.GEditorWorld.CreateMapNote(Me.World, gPoint)
			Dim textInputBox As TextInputBox = New TextInputBox()
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetMapNoteText(Me.World, AddressOf gBaseString<char>, Me.SelectedMapNote)
			Try
				Dim num4 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
				Dim value As __Pointer(Of SByte)
				If num4 <> 0UI Then
					value = num4
				Else
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				textInputBox.EditText = New String(CType(value, __Pointer(Of SByte)))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Dim p As Point = New Point(Me.MapNoteX, Me.MapNoteY)
			Dim location As Point = Me.panMainViewport.PointToScreen(p)
			textInputBox.Location = location
			If textInputBox.ShowDialog() = DialogResult.OK Then
				Dim gBaseString<char>2 As GBaseString<char>
				Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, textInputBox.EditText)
				Dim world As __Pointer(Of GEditorWorld)
				Dim selectedMapNote As Integer
				Try
					world = Me.World
					selectedMapNote = Me.SelectedMapNote
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				<Module>.GEditorWorld.SetMapNote(world, selectedMapNote, ptr2)
			Else
				<Module>.GEditorWorld.RemoveMapNote(Me.World, Me.SelectedMapNote)
			End If
		End Sub

		Private Sub menuItemEditNote_Clicked(sender As Object, e As EventArgs)
			If Me.SelectedMapNote >= 0 Then
				Dim textInputBox As TextInputBox = New TextInputBox()
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetMapNoteText(Me.World, AddressOf gBaseString<char>, Me.SelectedMapNote)
				Try
					Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
					Dim value As __Pointer(Of SByte)
					If num <> 0UI Then
						value = num
					Else
						value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					textInputBox.EditText = New String(CType(value, __Pointer(Of SByte)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Dim p As Point = New Point(Me.MapNoteX, Me.MapNoteY)
				Dim location As Point = Me.panMainViewport.PointToScreen(p)
				textInputBox.Location = location
				If textInputBox.ShowDialog() = DialogResult.OK Then
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, textInputBox.EditText)
					Dim world As __Pointer(Of GEditorWorld)
					Dim selectedMapNote As Integer
					Try
						world = Me.World
						selectedMapNote = Me.SelectedMapNote
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					<Module>.GEditorWorld.SetMapNote(world, selectedMapNote, ptr2)
				End If
			End If
		End Sub

		Private Sub menuItemRemoveNote_Clicked(sender As Object, e As EventArgs)
			Dim selectedMapNote As Integer = Me.SelectedMapNote
			If selectedMapNote >= 0 Then
				<Module>.GEditorWorld.RemoveMapNote(Me.World, selectedMapNote)
			End If
		End Sub

		Private Sub menuItemEditUnit_Clicked(sender As Object, e As EventArgs)
			Dim editorMode As Integer = Me.EditorMode
			If editorMode = 10 Then
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GEditorWorld.GetSelectedPUnit(Me.World, AddressOf gBaseString<char>)
				Try
					Dim ptr As __Pointer(Of SByte)
					If gBaseString<char> IsNot Nothing Then
						ptr = gBaseString<char>
					Else
						ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GFileSystem.GetFileFullPath(<Module>.FS, AddressOf gBaseString<char>2, ptr)
					Dim nUnitEditor As NUnitEditor
					Try
						Dim num As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
						Dim value As __Pointer(Of SByte)
						If num <> 0UI Then
							value = num
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						nUnitEditor = New NUnitEditor(Me.ToolWindows, New String(CType(value, __Pointer(Of SByte))), Me.UnitEditorClipboard)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
						gBaseString<char>2 = 0
					End If
					AddHandler nUnitEditor.PUnitChanged, AddressOf Me.UnitEditor_PUnitChanged
					nUnitEditor.Show()
					<Module>.SaveOptions()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			Else If editorMode = 9 Then
				Dim gBaseString<char>3 As GBaseString<char>
				<Module>.GEditorWorld.GetSelectedPUnit(Me.World, AddressOf gBaseString<char>3)
				Try
					Dim ptr3 As __Pointer(Of SByte)
					If gBaseString<char>3 IsNot Nothing Then
						ptr3 = gBaseString<char>3
					Else
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gBaseString<char>4 As GBaseString<char>
					Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GFileSystem.GetFileFullPath(<Module>.FS, AddressOf gBaseString<char>4, ptr3)
					Dim nUnitEditor2 As NUnitEditor
					Try
						Dim num2 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
						Dim value2 As __Pointer(Of SByte)
						If num2 <> 0UI Then
							value2 = num2
						Else
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						nUnitEditor2 = New NUnitEditor(Me.ToolWindows, New String(CType(value2, __Pointer(Of SByte))), Me.UnitEditorClipboard)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>4 IsNot Nothing Then
						<Module>.free(gBaseString<char>4)
						gBaseString<char>4 = 0
					End If
					AddHandler nUnitEditor2.PUnitChanged, AddressOf Me.UnitEditor_PUnitChanged
					nUnitEditor2.Show()
					<Module>.SaveOptions()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>3 IsNot Nothing Then
					<Module>.free(gBaseString<char>3)
				End If
			End If
		End Sub

		Private Sub menuItemFPEditUnit_Clicked(sender As Object, e As EventArgs)
			Dim editorMode As Integer = Me.EditorMode
			If editorMode = 10 Then
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>, "units/" + Me.UnitFilePicker.File)
				Try
					Dim ptr As __Pointer(Of SByte)
					If gBaseString<char> IsNot Nothing Then
						ptr = gBaseString<char>
					Else
						ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GFileSystem.GetFileFullPath(<Module>.FS, AddressOf gBaseString<char>2, ptr)
					Dim nUnitEditor As NUnitEditor
					Try
						Dim num As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
						Dim value As __Pointer(Of SByte)
						If num <> 0UI Then
							value = num
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						nUnitEditor = New NUnitEditor(Me.ToolWindows, New String(CType(value, __Pointer(Of SByte))), Me.UnitEditorClipboard)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
						gBaseString<char>2 = 0
					End If
					AddHandler nUnitEditor.PUnitChanged, AddressOf Me.UnitEditor_PUnitChanged
					nUnitEditor.Show()
					<Module>.SaveOptions()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			Else If editorMode = 9 Then
				Dim gBaseString<char>3 As GBaseString<char>
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>3, "buildings/" + Me.BuildingFilePicker.File)
				Try
					Dim ptr3 As __Pointer(Of SByte)
					If gBaseString<char>3 IsNot Nothing Then
						ptr3 = gBaseString<char>3
					Else
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gBaseString<char>4 As GBaseString<char>
					Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GFileSystem.GetFileFullPath(<Module>.FS, AddressOf gBaseString<char>4, ptr3)
					Dim nUnitEditor2 As NUnitEditor
					Try
						Dim num2 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
						Dim value2 As __Pointer(Of SByte)
						If num2 <> 0UI Then
							value2 = num2
						Else
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						nUnitEditor2 = New NUnitEditor(Me.ToolWindows, New String(CType(value2, __Pointer(Of SByte))), Me.UnitEditorClipboard)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>4 IsNot Nothing Then
						<Module>.free(gBaseString<char>4)
						gBaseString<char>4 = 0
					End If
					AddHandler nUnitEditor2.PUnitChanged, AddressOf Me.UnitEditor_PUnitChanged
					nUnitEditor2.Show()
					<Module>.SaveOptions()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>3 IsNot Nothing Then
					<Module>.free(gBaseString<char>3)
				End If
			End If
		End Sub

		Private Sub menuItemEditEffect_Clicked(sender As Object, e As EventArgs)
			If Me.EditorMode = 12 Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetSelectedPEffect(Me.World, AddressOf gBaseString<char>)
				Dim peffect_name As String
				Try
					Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
					peffect_name = New String(CType((If((num = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num)), __Pointer(Of SByte)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
					gBaseString<char> = 0
				End If
				Dim nEffectEditor As NEffectEditor = New NEffectEditor(Me.ToolWindows, peffect_name, Me.EffectEditorClipboard)
				AddHandler nEffectEditor.PEffectChanged, AddressOf Me.EffectEditor_PEffectChanged
				nEffectEditor.Show()
				<Module>.SaveOptions()
			End If
		End Sub

		Private Sub menuItemPathnodeWait_Clicked(sender As Object, e As EventArgs)
			If Me.EditorMode = 17 Then
				Dim b As Byte = If((<Module>.GEditorWorld.GetSelectedPathNodeWait(Me.World) = 0), 1, 0)
				<Module>.GEditorWorld.SetSelectedPathNodeWait(Me.World, b <> 0)
			End If
		End Sub

		Private Sub menuItemWaterfall_Clicked(sender As Object, e As EventArgs)
			If Me.EditorMode = 6 Then
				Dim b As Byte = If((<Module>.GEditorWorld.GetSelectedWaterFall(Me.World) = 0), 1, 0)
				<Module>.GEditorWorld.SetSelectedWaterFall(Me.World, b <> 0)
			End If
		End Sub

		Private Sub MinimapNeedsRefresh()
			Me.MinimapPanel.RefreshMap(True)
			Me.MinimapPanel.RefreshUnits()
			Me.RefreshMinimapCameraGizmo()
			Me.MinimapPanel.DrawMap()
		End Sub

		Private Sub MinimapMovesCamera(dx As Single, dz As Single)
			Dim gCamera As GCamera
			<Module>.GWorld.GetCamera(Me.World, gCamera)
			<Module>.GWorld.CameraSetPosition(Me.World, gCamera + dx, __Dereference((gCamera + 4)) - dz)
			Me.MinimapViewportNeedsUpdate = True
		End Sub

		Private Sub MinimapRotatesCamera(alpha As Single)
			<Module>.GWorld.CameraRotate(Me.World, alpha, 0F)
			Me.MinimapViewportNeedsUpdate = True
		End Sub

		Private Sub menuEditControlPaste_Click(sender As Object, e As EventArgs)
			Dim pasteOptions As PasteOptions = New PasteOptions()
			pasteOptions.PasteOptionFlags = Me.LastPasteOptions
			If pasteOptions.ShowDialog() = DialogResult.OK Then
				Me.LastPasteOptions = pasteOptions.PasteOptionFlags
				Dim mousePosition As Point = Control.MousePosition
				Dim mousePosition2 As Point = Control.MousePosition
				Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
				Dim gRay As GRay
				Dim num2 As Single
				Dim num3 As Single
				Dim num4 As Single
				<Module>.GWorld.GetTarget(Me.World, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, mousePosition2.X, mousePosition.Y, __Dereference(num)), num2, num3, num4)
				<Module>.GEditorWorld.StartPaste(Me.World, Me.Clipboard, CInt((CDec(num2))), CInt((CDec(num4))), pasteOptions.PasteOptionFlags)
				Me.DragMode = 4
			End If
			__Dereference((Me.KeyTimes + 128)) = 0L
			__Dereference((Me.KeyTimes + 136)) = 0L
			__Dereference((Me.KeyTimes + 688)) = 0L
		End Sub

		Public Sub RefreshScriptEditorForm()
			Me.ScriptEditorFormInstance.EditorsChanged()
		End Sub

		Private Sub menuHelpContents_Click(sender As Object, e As EventArgs)
			Help.ShowHelp(Me, "Workshop.chm", HelpNavigator.TableOfContents)
		End Sub

		Private Sub menuHelpIndex_Click(sender As Object, e As EventArgs)
			Help.ShowHelp(Me, "Workshop.chm", HelpNavigator.Index)
		End Sub

		Private Sub menuHelpAbout_Click(sender As Object, e As EventArgs)
		End Sub

		Public Sub LogDebugMessage(message As __Pointer(Of GBaseString<char>))
			Try
				Dim num As UInteger = CUInt((__Dereference(CType(message, __Pointer(Of Integer)))))
				Dim value As __Pointer(Of SByte)
				If num <> 0UI Then
					value = num
				Else
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				Me.LoggerTool.AddEcho(New String(CType(value, __Pointer(Of SByte))))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType(message, __Pointer(Of Void)))
				Throw
			End Try
			Dim num2 As UInteger = CUInt((__Dereference(CType(message, __Pointer(Of Integer)))))
			If num2 <> 0UI Then
				<Module>.free(num2)
				__Dereference(CType(message, __Pointer(Of Integer))) = 0
			End If
		End Sub
	End Class
End Namespace
