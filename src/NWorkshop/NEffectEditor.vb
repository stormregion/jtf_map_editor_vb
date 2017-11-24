Imports <CppImplementationDetails>
Imports GRTTI
Imports NControls
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NEffectEditor
		Inherits Form

		Public Delegate Sub __Delegate_PEffectChanged( As __Pointer(Of SByte))

		Protected ToolWindows As ArrayList

		Protected ToolWindowIdx As Integer

		Protected FileDialog As NFileDialog

		Protected PEffect As __Pointer(Of GHandle<9>)

		Protected PEffectClass As __Pointer(Of GClass)

		Protected PEffectData As __Pointer(Of Void)

		Protected FileName As String

		Protected FileNameToLoad As String

		Protected Modified As Boolean

		Protected IRenderTargetIdx As Integer

		Protected IRenderTarget As __Pointer(Of GIRenderTarget)

		Protected IViewport As __Pointer(Of GIViewport)

		Protected IScene As __Pointer(Of GIScene)

		Protected Terrain As __Pointer(Of GITerrain)

		Protected Effect As __Pointer(Of GIEffect)

		Protected LastTime As Long

		Protected DragMode As Integer

		Protected DragMX As Integer

		Protected DragMY As Integer

		Protected KeyTimes As $ArrayType$$$BY0BAA@_J

		Protected LastUpdate As Long

		Protected CamLimited As Boolean

		Protected CamDirection As Single

		Protected CamElevationMin As Single

		Protected CamElevationMax As Single

		Protected CamElevation As Single

		Protected CamDistanceMin As Single

		Protected CamDistanceMax As Single

		Protected CamDistance As Single

		Protected CameraBlendDist As Single

		Protected EmitterPosition As __Pointer(Of GPoint3)

		Protected EmitterDirection As __Pointer(Of GVector3)

		Protected EmitterVelType As Integer

		Protected EmitterDirType As Integer

		Protected EmitterMovType As Integer

		Protected ShowEffectPosDir As Integer

		Protected EmitterLines As __Pointer(Of GHandle<11>)

		Private splitter1 As Splitter

		Private menuEffectEditor As MainMenu

		Private menuFile As MenuItem

		Private menuFileNew As MenuItem

		Private menuFileOpen As MenuItem

		Private menuFileSave As MenuItem

		Private menuFileSaveAs As MenuItem

		Private menuFileClose As MenuItem

		Private menuFileSeparator2 As MenuItem

		Private menuFileSeparator1 As MenuItem

		Private menuFileOpenRecent As MenuItem

		Private menuEdit As MenuItem

		Private menuEditUndo As MenuItem

		Private menuEditRedo As MenuItem

		Private panEffectViewport As NSolidPanel

		Private menuItem8 As MenuItem

		Private menuEmitter As MenuItem

		Private menuEmitterVel0 As MenuItem

		Private menuEmitterVel1 As MenuItem

		Private menuEmitterVel2 As MenuItem

		Private menuEmitterDirVerticalP As MenuItem

		Private menuEmitterDirVerticalM As MenuItem

		Private menuEmitterDirHorizontal As MenuItem

		Private menuEmitterDirRotate As MenuItem

		Private menuItem12 As MenuItem

		Private menuEmitterMovRotate As MenuItem

		Private menuEmitterMovHorizontal As MenuItem

		Private menuItem4 As MenuItem

		Private menuEmitterReset As MenuItem

		Private menuEmitterVel3 As MenuItem

		Private menuEmitterMovVerticalP As MenuItem

		Private menuEmitterMovVerticalM As MenuItem

		Private panRight As Panel

		Private menuItem3 As MenuItem

		Private menuViewDebugMode As MenuItem

		Private menuItem2 As MenuItem

		Private menuItem5 As MenuItem

		Private menuViewShowEffectPosDir As MenuItem

		Private menuItem1 As MenuItem

		Private menuWindOff As MenuItem

		Private menuWindLight As MenuItem

		Private menuWindMedium As MenuItem

		Private menuWindHeavy As MenuItem

		Private TrackPanel As Panel

		Private splitter2 As Splitter

		Private panel1 As Panel

		Private components As IContainer

		Private tbEffectEditor As Toolbar

		Private EffectPropTree As PropertyTree

		Private CurrentCurveEditor As NCurveEditor

		Private UndoArray As __Pointer(Of GArray<GStreamBuffer>)

		Private UndoIndex As Integer

		Private SavedIndex As Integer

		Public Custom Event PEffectChanged As NEffectEditor.__Delegate_PEffectChanged
			AddHandler
				Me.PEffectChanged = [Delegate].Combine(Me.PEffectChanged, value)
			End AddHandler
			RemoveHandler
				Me.PEffectChanged = [Delegate].Remove(Me.PEffectChanged, value)
			End RemoveHandler
		End Event

		Public Sub New(toolwindows As ArrayList, peffect_name As String, clipboard As __Pointer(Of NPropertyClipboard))
			Me.PEffectChanged = Nothing
			Me.InitializeComponent()
			Dim nSolidPanel As NSolidPanel = New NSolidPanel()
			Me.panEffectViewport = nSolidPanel
			nSolidPanel.BorderStyle = BorderStyle.Fixed3D
			Me.panEffectViewport.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.panEffectViewport.Location = location
			Me.panEffectViewport.Name = "panEffectViewport"
			Dim size As Size = New Size(629, 437)
			Me.panEffectViewport.Size = size
			Me.panEffectViewport.TabIndex = 2
			AddHandler Me.panEffectViewport.SizeChanged, AddressOf Me.panEffectViewport_SizeChanged
			AddHandler Me.panEffectViewport.MouseUp, AddressOf Me.panEffectViewport_MouseUp
			AddHandler Me.panEffectViewport.Paint, AddressOf Me.panEffectViewport_Paint
			AddHandler Me.panEffectViewport.MouseMove, AddressOf Me.panEffectViewport_MouseMove
			AddHandler Me.panEffectViewport.MouseDown, AddressOf Me.panEffectViewport_MouseDown
			Me.panRight.Controls.Add(Me.panEffectViewport)
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0NEffectEditor@NWorkshop@@Q$AAM@P$AAVArrayList@Collections@System@@P$AAVString@5@PAUNPropertyClipboard@NControls@@@Z@4PAUGToolbarItem@8@A), __Pointer(Of GToolbarItem)), 24)
			Me.tbEffectEditor = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.tbEffectEditor.ButtonClick, AddressOf Me.tbEffectEditor_ButtonClick
			MyBase.Controls.Add(Me.tbEffectEditor)
			Dim propertyTree As PropertyTree = New PropertyTree(1, NewAssetPicker.ObjectType.EffectEditor, clipboard)
			Me.EffectPropTree = propertyTree
			Me.panel1.Controls.Add(propertyTree)
			Me.EffectPropTree.Dock = DockStyle.Fill
			Dim location2 As Point = New Point(0, 0)
			Me.EffectPropTree.Location = location2
			Me.EffectPropTree.Name = "EffectPropTree"
			Dim size2 As Size = New Size(250, 435)
			Me.EffectPropTree.Size = size2
			Me.EffectPropTree.TabIndex = 0
			Me.EffectPropTree.Text = "EffectPropTree"
			AddHandler Me.EffectPropTree.ItemChanged, AddressOf Me.EffectPropTree_ItemChanged
			AddHandler Me.EffectPropTree.SelectedIndexChanged, AddressOf Me.EffectPropTree_SelectedIndexChanged
			AddHandler Me.EffectPropTree.TrackSelected, AddressOf Me.StartTrackEditor
			Me.ToolWindows = toolwindows
			Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 44, True)
			Me.FileDialog = nFileDialog
			nFileDialog.DefaultExtension = "fx"
			Dim ptr As __Pointer(Of GHandle<9>) = <Module>.new(4UI)
			Dim pEffect As __Pointer(Of GHandle<9>)
			Try
				If ptr IsNot Nothing Then
					__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
					pEffect = ptr
				Else
					pEffect = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.PEffect = pEffect
			Me.PEffectClass = Nothing
			Me.PEffectData = Nothing
			Me.FileName = ""
			Me.FileNameToLoad = peffect_name
			Me.Modified = False
			Me.UpdateWindowText()
			Me.tbEffectEditor.SetItemEnable(203, False)
			Me.tbEffectEditor.SetItemEnable(204, False)
			Me.tbEffectEditor.SetItemEnable(205, False)
			Me.tbEffectEditor.SetItemEnable(206, False)
			Me.tbEffectEditor.SetItemEnable(207, False)
			Me.tbEffectEditor.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = False
			Me.menuEditRedo.Enabled = False
			Me.menuFileSave.Enabled = False
			Me.IRenderTargetIdx = -1
			Me.IRenderTarget = Nothing
			Me.IViewport = Nothing
			Me.IScene = Nothing
			Me.Terrain = Nothing
			Me.Effect = Nothing
			initblk(Me.KeyTimes, 0, 2048)
			Me.LastUpdate = 0L
			Me.LastTime = 0L
			Me.DragMode = 0
			Me.DragMY = 0
			Me.DragMX = 0
			Me.CamLimited = True
			Me.CamDirection = 0F
			Me.CamElevationMin = 0.6981317F
			Me.CamElevationMax = 1.134464F
			Me.CamElevation = 0.916297853F
			Me.CamDistanceMin = <Module>.Measures * 44F
			Dim num As Single = <Module>.Measures * 80F
			Me.CamDistanceMax = num
			Dim num2 As Single = (Me.CamDistanceMin + num) * 0.5F
			Me.CamDistance = num2
			Me.CameraBlendDist = num2
			Dim ptr2 As __Pointer(Of GPoint3) = <Module>.new(12UI)
			Dim emitterPosition As __Pointer(Of GPoint3)
			Try
				If ptr2 IsNot Nothing Then
					__Dereference(CType(ptr2, __Pointer(Of Single))) = 0F
					__Dereference(CType((ptr2 + 4 / __SizeOf(GPoint3)), __Pointer(Of Single))) = 0F
					__Dereference(CType((ptr2 + 8 / __SizeOf(GPoint3)), __Pointer(Of Single))) = 0F
					emitterPosition = ptr2
				Else
					emitterPosition = 0
				End If
			Catch 
				<Module>.delete(CType(ptr2, __Pointer(Of Void)))
				Throw
			End Try
			Me.EmitterPosition = emitterPosition
			Dim ptr3 As __Pointer(Of GVector3) = <Module>.new(12UI)
			Dim emitterDirection As __Pointer(Of GVector3)
			Try
				If ptr3 IsNot Nothing Then
					__Dereference(CType(ptr3, __Pointer(Of Single))) = 0F
					__Dereference(CType((ptr3 + 4 / __SizeOf(GVector3)), __Pointer(Of Single))) = 1F
					__Dereference(CType((ptr3 + 8 / __SizeOf(GVector3)), __Pointer(Of Single))) = 0F
					emitterDirection = ptr3
				Else
					emitterDirection = 0
				End If
			Catch 
				<Module>.delete(CType(ptr3, __Pointer(Of Void)))
				Throw
			End Try
			Me.EmitterDirection = emitterDirection
			Me.EmitterVelType = 0
			Me.EmitterDirType = 0
			Me.EmitterMovType = 2
			Me.ShowEffectPosDir = 1
			Me.menuViewShowEffectPosDir.Checked = True
			Dim ptr4 As __Pointer(Of GArray<GStreamBuffer>) = <Module>.new(12UI)
			Dim undoArray As __Pointer(Of GArray<GStreamBuffer>)
			Try
				If ptr4 IsNot Nothing Then
					__Dereference(CType(ptr4, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr4 + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr4 + 8 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) = 0
					undoArray = ptr4
				Else
					undoArray = 0
				End If
			Catch 
				<Module>.delete(CType(ptr4, __Pointer(Of Void)))
				Throw
			End Try
			Me.UndoArray = undoArray
			Me.UndoIndex = 0
			Me.CurrentCurveEditor = Nothing
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

		Protected Sub RefreshEmitter(time As Long, elapsed As Long)
			Dim num As Single = CSng(Me.EmitterVelType) / <Module>.Measures
			Select Case Me.EmitterMovType
				Case 0
					Dim ptr As __Pointer(Of GPoint3) = Me.EmitterPosition + 4 / __SizeOf(GPoint3)
					__Dereference(CType(ptr, __Pointer(Of Single))) = CSng(elapsed) * 1E-06F * num + __Dereference(CType(ptr, __Pointer(Of Single)))
					Dim ptr2 As __Pointer(Of GPoint3) = Me.EmitterPosition + 4 / __SizeOf(GPoint3)
					If __Dereference(CType(ptr2, __Pointer(Of Single))) > 32F Then
						__Dereference(CType(ptr2, __Pointer(Of Single))) -= 32F
					End If
				Case 1
					__Dereference(CType((Me.EmitterPosition + 4 / __SizeOf(GPoint3)), __Pointer(Of Single))) -= CSng(elapsed) * 1E-06F * num
					Dim ptr3 As __Pointer(Of GPoint3) = Me.EmitterPosition + 4 / __SizeOf(GPoint3)
					If __Dereference(CType(ptr3, __Pointer(Of Single))) < 0F Then
						__Dereference(CType(ptr3, __Pointer(Of Single))) += 32F
					End If
				Case 2
					Dim ptr4 As __Pointer(Of GPoint3) = Me.EmitterPosition + 8 / __SizeOf(GPoint3)
					__Dereference(CType(ptr4, __Pointer(Of Single))) = CSng(elapsed) * 1E-06F * num + __Dereference(CType(ptr4, __Pointer(Of Single)))
					Dim ptr5 As __Pointer(Of GPoint3) = Me.EmitterPosition + 8 / __SizeOf(GPoint3)
					If __Dereference(CType(ptr5, __Pointer(Of Single))) > 32F Then
						__Dereference(CType(ptr5, __Pointer(Of Single))) -= 64F
					End If
				Case 3
					Dim num2 As Single = CSng(time) * 1E-06F * num * 0.09549297F
					Dim num3 As Single = CSng(Math.Sin(CDec(num2)))
					__Dereference(CType(Me.EmitterPosition, __Pointer(Of Single))) = num3 * 24F
					Dim num4 As Single = CSng(Math.Cos(CDec(num2)))
					__Dereference(CType((Me.EmitterPosition + 8 / __SizeOf(GPoint3)), __Pointer(Of Single))) = num4 * 24F
			End Select
			Select Case Me.EmitterDirType
				Case 0
					Dim gVector As GVector3 = 0F
					__Dereference((gVector + 4)) = 1F
					__Dereference((gVector + 8)) = 0F
					cpblk(Me.EmitterDirection, gVector, 12)
				Case 1
					Dim gVector2 As GVector3 = 0F
					__Dereference((gVector2 + 4)) = -1F
					__Dereference((gVector2 + 8)) = 0F
					cpblk(Me.EmitterDirection, gVector2, 12)
				Case 2
					Dim gVector3 As GVector3 = 0F
					__Dereference((gVector3 + 4)) = 0F
					__Dereference((gVector3 + 8)) = 1F
					cpblk(Me.EmitterDirection, gVector3, 12)
				Case 3
					Dim num5 As Single = CSng(time) * 1E-06F
					Dim num6 As Single = CSng(Math.Sin(CDec((num5 * 0.636619747F))))
					__Dereference(CType(Me.EmitterDirection, __Pointer(Of Single))) = num6
					Dim num7 As Single = CSng(Math.Sin(CDec((num5 * 0.6684507F))))
					__Dereference(CType((Me.EmitterDirection + 4 / __SizeOf(GVector3)), __Pointer(Of Single))) = num7
					Dim num8 As Single = CSng(Math.Sin(CDec((num5 * 0.700281739F))))
					__Dereference(CType((Me.EmitterDirection + 8 / __SizeOf(GVector3)), __Pointer(Of Single))) = num8
			End Select
			Dim emitterPosition As __Pointer(Of GPoint3) = Me.EmitterPosition
			Dim num9 As Single = __Dereference(emitterPosition) + 32F
			Dim num10 As Single = __Dereference((emitterPosition + 4))
			Dim num11 As Single = __Dereference((emitterPosition + 8)) + 32F
			Dim gPoint As GPoint3 = num9
			__Dereference((gPoint + 4)) = num10
			__Dereference((gPoint + 8)) = num11
			Dim effect As __Pointer(Of GIEffect) = Me.Effect
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), effect, gPoint, __Dereference((__Dereference(CType(effect, __Pointer(Of Integer))) + 16)))
			Dim effect2 As __Pointer(Of GIEffect) = Me.Effect
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single), effect2, Me.EmitterDirection, 0F, __Dereference((__Dereference(CType(effect2, __Pointer(Of Integer))) + 20)))
			Dim iScene As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), iScene, __Dereference(Me.EmitterLines), __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 264)))
			If Me.ShowEffectPosDir <> 0 Then
				Dim iScene2 As __Pointer(Of GIScene) = Me.IScene
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iScene2, __Dereference(Me.EmitterLines), gPoint, 16776960, __Dereference((__Dereference(CType(iScene2, __Pointer(Of Integer))) + 276)))
				Dim emitterDirection As __Pointer(Of GVector3) = Me.EmitterDirection
				Dim num12 As Single = __Dereference(emitterDirection) * 3F
				Dim num13 As Single = __Dereference((emitterDirection + 4)) * 3F
				Dim num14 As Single = __Dereference((emitterDirection + 8)) * 3F
				Dim num15 As Single = num12 + gPoint
				Dim num16 As Single = __Dereference((gPoint + 4)) + num13
				Dim num17 As Single = __Dereference((gPoint + 8)) + num14
				Dim gPoint2 As GPoint3 = num15
				__Dereference((gPoint2 + 4)) = num16
				__Dereference((gPoint2 + 8)) = num17
				iScene = Me.IScene
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>,GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong),GPoint3,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iScene, __Dereference(Me.EmitterLines), gPoint, 16776960, gPoint2, 16776960, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 280)))
			End If
		End Sub

		Private Sub InitializeComponent()
			Dim resourceManager As ResourceManager = New ResourceManager(GetType(NEffectEditor))
			Me.panel1 = New Panel()
			Me.splitter1 = New Splitter()
			Me.menuEffectEditor = New MainMenu()
			Me.menuFile = New MenuItem()
			Me.menuFileNew = New MenuItem()
			Me.menuFileOpen = New MenuItem()
			Me.menuFileOpenRecent = New MenuItem()
			Me.menuFileSeparator1 = New MenuItem()
			Me.menuFileSave = New MenuItem()
			Me.menuFileSaveAs = New MenuItem()
			Me.menuFileSeparator2 = New MenuItem()
			Me.menuFileClose = New MenuItem()
			Me.menuEdit = New MenuItem()
			Me.menuEditUndo = New MenuItem()
			Me.menuEditRedo = New MenuItem()
			Me.menuItem3 = New MenuItem()
			Me.menuViewShowEffectPosDir = New MenuItem()
			Me.menuItem5 = New MenuItem()
			Me.menuItem2 = New MenuItem()
			Me.menuViewDebugMode = New MenuItem()
			Me.menuEmitter = New MenuItem()
			Me.menuEmitterReset = New MenuItem()
			Me.menuItem4 = New MenuItem()
			Me.menuEmitterVel0 = New MenuItem()
			Me.menuEmitterVel1 = New MenuItem()
			Me.menuEmitterVel2 = New MenuItem()
			Me.menuEmitterVel3 = New MenuItem()
			Me.menuItem8 = New MenuItem()
			Me.menuEmitterMovHorizontal = New MenuItem()
			Me.menuEmitterMovVerticalP = New MenuItem()
			Me.menuEmitterMovVerticalM = New MenuItem()
			Me.menuEmitterMovRotate = New MenuItem()
			Me.menuItem12 = New MenuItem()
			Me.menuEmitterDirHorizontal = New MenuItem()
			Me.menuEmitterDirVerticalP = New MenuItem()
			Me.menuEmitterDirVerticalM = New MenuItem()
			Me.menuEmitterDirRotate = New MenuItem()
			Me.menuItem1 = New MenuItem()
			Me.menuWindOff = New MenuItem()
			Me.menuWindLight = New MenuItem()
			Me.menuWindMedium = New MenuItem()
			Me.menuWindHeavy = New MenuItem()
			Me.panRight = New Panel()
			Me.splitter2 = New Splitter()
			Me.TrackPanel = New Panel()
			Me.panRight.SuspendLayout()
			MyBase.SuspendLayout()
			Me.panel1.BorderStyle = BorderStyle.Fixed3D
			Me.panel1.Dock = DockStyle.Left
			Dim location As Point = New Point(0, 0)
			Me.panel1.Location = location
			Me.panel1.Name = "panel1"
			Dim size As Size = New Size(384, 654)
			Me.panel1.Size = size
			Me.panel1.TabIndex = 0
			Dim location2 As Point = New Point(384, 0)
			Me.splitter1.Location = location2
			Me.splitter1.Name = "splitter1"
			Dim size2 As Size = New Size(3, 654)
			Me.splitter1.Size = size2
			Me.splitter1.TabIndex = 3
			Me.splitter1.TabStop = False
			Dim items As MenuItem() = New MenuItem() { Me.menuFile, Me.menuEdit, Me.menuItem3, Me.menuEmitter, Me.menuItem1 }
			Me.menuEffectEditor.MenuItems.AddRange(items)
			Me.menuFile.Index = 0
			Dim items2 As MenuItem() = New MenuItem() { Me.menuFileNew, Me.menuFileOpen, Me.menuFileOpenRecent, Me.menuFileSeparator1, Me.menuFileSave, Me.menuFileSaveAs, Me.menuFileSeparator2, Me.menuFileClose }
			Me.menuFile.MenuItems.AddRange(items2)
			Me.menuFile.Text = "&File"
			Me.menuFileNew.Index = 0
			Me.menuFileNew.Shortcut = Shortcut.CtrlN
			Me.menuFileNew.Text = "&New"
			AddHandler Me.menuFileNew.Click, AddressOf Me.menuFileNew_Click
			Me.menuFileOpen.Index = 1
			Me.menuFileOpen.Shortcut = Shortcut.CtrlO
			Me.menuFileOpen.Text = "Open..."
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
			Me.menuFileSeparator2.Index = 6
			Me.menuFileSeparator2.Text = "-"
			Me.menuFileClose.Index = 7
			Me.menuFileClose.Shortcut = Shortcut.AltF4
			Me.menuFileClose.Text = "&Close"
			AddHandler Me.menuFileClose.Click, AddressOf Me.menuFileClose_Click
			Me.menuEdit.Index = 1
			Dim items3 As MenuItem() = New MenuItem() { Me.menuEditUndo, Me.menuEditRedo }
			Me.menuEdit.MenuItems.AddRange(items3)
			Me.menuEdit.Text = "&Edit"
			Me.menuEditUndo.Index = 0
			Me.menuEditUndo.Text = "&Undo"
			AddHandler Me.menuEditUndo.Click, AddressOf Me.menuEditUndo_Click
			Me.menuEditRedo.Index = 1
			Me.menuEditRedo.Text = "&Redo"
			AddHandler Me.menuEditRedo.Click, AddressOf Me.menuEditRedo_Click
			Me.menuItem3.Index = 2
			Dim items4 As MenuItem() = New MenuItem() { Me.menuViewShowEffectPosDir, Me.menuItem5, Me.menuItem2, Me.menuViewDebugMode }
			Me.menuItem3.MenuItems.AddRange(items4)
			Me.menuItem3.Text = "&View"
			Me.menuViewShowEffectPosDir.Index = 0
			Me.menuViewShowEffectPosDir.Text = "Show Effect Position && Direction"
			AddHandler Me.menuViewShowEffectPosDir.Click, AddressOf Me.menuViewShowEffectPosDir_Click
			Me.menuItem5.Index = 1
			Me.menuItem5.Text = "Near-Camera Fade"
			Me.menuItem2.Index = 2
			Me.menuItem2.Text = "-"
			Me.menuViewDebugMode.Index = 3
			Me.menuViewDebugMode.Text = "&DebugMode"
			AddHandler Me.menuViewDebugMode.Click, AddressOf Me.menuViewDebugMode_Click
			Me.menuEmitter.Index = 3
			Dim items5 As MenuItem() = New MenuItem() { Me.menuEmitterReset, Me.menuItem4, Me.menuEmitterVel0, Me.menuEmitterVel1, Me.menuEmitterVel2, Me.menuEmitterVel3, Me.menuItem8, Me.menuEmitterMovHorizontal, Me.menuEmitterMovVerticalP, Me.menuEmitterMovVerticalM, Me.menuEmitterMovRotate, Me.menuItem12, Me.menuEmitterDirHorizontal, Me.menuEmitterDirVerticalP, Me.menuEmitterDirVerticalM, Me.menuEmitterDirRotate }
			Me.menuEmitter.MenuItems.AddRange(items5)
			Me.menuEmitter.Text = "E&mitterTest"
			Me.menuEmitterReset.Index = 0
			Me.menuEmitterReset.Shortcut = Shortcut.CtrlR
			Me.menuEmitterReset.Text = "R&eset"
			AddHandler Me.menuEmitterReset.Click, AddressOf Me.menuEmitterReset_Click
			Me.menuItem4.Index = 1
			Me.menuItem4.Text = "-"
			Me.menuEmitterVel0.Checked = True
			Me.menuEmitterVel0.Index = 2
			Me.menuEmitterVel0.Shortcut = Shortcut.Ctrl0
			Me.menuEmitterVel0.Text = "Vel.&0"
			AddHandler Me.menuEmitterVel0.Click, AddressOf Me.menuEmitterVel0_Click
			Me.menuEmitterVel1.Index = 3
			Me.menuEmitterVel1.Shortcut = Shortcut.Ctrl1
			Me.menuEmitterVel1.Text = "Vel.&1"
			AddHandler Me.menuEmitterVel1.Click, AddressOf Me.menuEmitterVel1_Click
			Me.menuEmitterVel2.Index = 4
			Me.menuEmitterVel2.Shortcut = Shortcut.Ctrl2
			Me.menuEmitterVel2.Text = "Vel.&2"
			AddHandler Me.menuEmitterVel2.Click, AddressOf Me.menuEmitterVel2_Click
			Me.menuEmitterVel3.Index = 5
			Me.menuEmitterVel3.Shortcut = Shortcut.Ctrl3
			Me.menuEmitterVel3.Text = "Vel.3"
			AddHandler Me.menuEmitterVel3.Click, AddressOf Me.menuEmitterVel3_Click
			Me.menuItem8.Index = 6
			Me.menuItem8.Text = "-"
			Me.menuEmitterMovHorizontal.Checked = True
			Me.menuEmitterMovHorizontal.Index = 7
			Me.menuEmitterMovHorizontal.Text = "Mov.Horizontal"
			AddHandler Me.menuEmitterMovHorizontal.Click, AddressOf Me.menuEmitterMovHorizontal_Click
			Me.menuEmitterMovVerticalP.Index = 8
			Me.menuEmitterMovVerticalP.Text = "Mov.Vertical +"
			AddHandler Me.menuEmitterMovVerticalP.Click, AddressOf Me.menuEmitterMovVerticalP_Click
			Me.menuEmitterMovVerticalM.Index = 9
			Me.menuEmitterMovVerticalM.Text = "Mov.Vertical -"
			AddHandler Me.menuEmitterMovVerticalM.Click, AddressOf Me.menuEmitterMovVerticalM_Click
			Me.menuEmitterMovRotate.Index = 10
			Me.menuEmitterMovRotate.Text = "Mov.Rotate"
			AddHandler Me.menuEmitterMovRotate.Click, AddressOf Me.menuEmitterMovRotate_Click
			Me.menuItem12.Index = 11
			Me.menuItem12.Text = "-"
			Me.menuEmitterDirHorizontal.Index = 12
			Me.menuEmitterDirHorizontal.Text = "Dir.Horizontal"
			AddHandler Me.menuEmitterDirHorizontal.Click, AddressOf Me.menuEmitterDirHorizontal_Click
			Me.menuEmitterDirVerticalP.Checked = True
			Me.menuEmitterDirVerticalP.Index = 13
			Me.menuEmitterDirVerticalP.Text = "Dir.Vertical +"
			AddHandler Me.menuEmitterDirVerticalP.Click, AddressOf Me.menuEmitterDirVerticalP_Click
			Me.menuEmitterDirVerticalM.Index = 14
			Me.menuEmitterDirVerticalM.Text = "Dir.Vertical -"
			AddHandler Me.menuEmitterDirVerticalM.Click, AddressOf Me.menuEmitterDirVerticalM_Click
			Me.menuEmitterDirRotate.Index = 15
			Me.menuEmitterDirRotate.Text = "Dir.Rotate"
			AddHandler Me.menuEmitterDirRotate.Click, AddressOf Me.menuEmitterDirRotate_Click
			Me.menuItem1.Index = 4
			Dim items6 As MenuItem() = New MenuItem() { Me.menuWindOff, Me.menuWindLight, Me.menuWindMedium, Me.menuWindHeavy }
			Me.menuItem1.MenuItems.AddRange(items6)
			Me.menuItem1.Text = "&Wind"
			Me.menuWindOff.Checked = True
			Me.menuWindOff.Index = 0
			Me.menuWindOff.RadioCheck = True
			Me.menuWindOff.Text = "Off"
			AddHandler Me.menuWindOff.Click, AddressOf Me.menuWindOff_Click
			Me.menuWindLight.Index = 1
			Me.menuWindLight.RadioCheck = True
			Me.menuWindLight.Text = "Light (20 km/h)"
			AddHandler Me.menuWindLight.Click, AddressOf Me.menuWindLight_Click
			Me.menuWindMedium.Index = 2
			Me.menuWindMedium.RadioCheck = True
			Me.menuWindMedium.Text = "Medium (40 km/h)"
			AddHandler Me.menuWindMedium.Click, AddressOf Me.menuWindMedium_Click
			Me.menuWindHeavy.Index = 3
			Me.menuWindHeavy.RadioCheck = True
			Me.menuWindHeavy.Text = "Heavy (60 km/h)"
			AddHandler Me.menuWindHeavy.Click, AddressOf Me.menuWindHeavy_Click
			Me.panRight.Controls.Add(Me.splitter2)
			Me.panRight.Controls.Add(Me.TrackPanel)
			Me.panRight.Dock = DockStyle.Fill
			Dim location3 As Point = New Point(387, 0)
			Me.panRight.Location = location3
			Me.panRight.Name = "panRight"
			Dim size3 As Size = New Size(629, 654)
			Me.panRight.Size = size3
			Me.panRight.TabIndex = 4
			Me.splitter2.Dock = DockStyle.Bottom
			Dim location4 As Point = New Point(0, 437)
			Me.splitter2.Location = location4
			Me.splitter2.Name = "splitter2"
			Dim size4 As Size = New Size(629, 3)
			Me.splitter2.Size = size4
			Me.splitter2.TabIndex = 3
			Me.splitter2.TabStop = False
			Me.TrackPanel.Dock = DockStyle.Bottom
			Dim location5 As Point = New Point(0, 440)
			Me.TrackPanel.Location = location5
			Me.TrackPanel.Name = "TrackPanel"
			Dim size5 As Size = New Size(629, 214)
			Me.TrackPanel.Size = size5
			Me.TrackPanel.TabIndex = 4
			Dim autoScaleBaseSize As Size = New Size(5, 14)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(1016, 654)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.panRight)
			MyBase.Controls.Add(Me.splitter1)
			MyBase.Controls.Add(Me.panel1)
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			MyBase.Icon = CType(resourceManager.GetObject("$this.Icon"), Icon)
			MyBase.Menu = Me.menuEffectEditor
			MyBase.Name = "NEffectEditor"
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "EffectEditor"
			AddHandler MyBase.Closing, AddressOf Me.EffectEditor_Closing
			AddHandler MyBase.Load, AddressOf Me.EffectEditor_Load
			AddHandler MyBase.Closed, AddressOf Me.EffectEditor_Closed
			AddHandler MyBase.Activated, AddressOf Me.EffectEditor_Activated
			AddHandler MyBase.Deactivate, AddressOf Me.EffectEditor_Deactivate
			Me.panRight.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Private Function SaveDocumentIfChanged() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			If Not Me.Modified Then
				Return True
			End If
			Dim dialogResult As DialogResult = MessageBox.Show("The effect has been modified since the last save." & vbLf & "Do you want to save?", "Save Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
			If dialogResult = DialogResult.No Then
				Return True
			End If
			If dialogResult = DialogResult.Yes Then
				Me.menuFileSave_Click(Nothing, Nothing)
				If Not Me.Modified Then
					Return True
				End If
			End If
			Return False
		End Function

		Private Sub DiscardDocument()
			If(If((__Dereference(CType(Me.PEffect, __Pointer(Of Integer))) <> 0), 1, 0)) <> 0 Then
				Dim gMeasures As GMeasures
				Me.EffectPropTree.SetVariable(Nothing, Nothing, <Module>.GMeasures.{ctor}(gMeasures, <Module>.Measures, 1F))
				Me.PEffectClass = Nothing
				Me.PEffectData = Nothing
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>), <Module>.IEngine, __Dereference(Me.PEffect), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 216)))
			End If
		End Sub

		Private Sub NewDocument()
			Me.DiscardDocument()
			Dim gHandle<9> As GHandle<9>
			Dim num As Integer = calli(GHandle<9>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>*), <Module>.IEngine, gHandle<9>, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 220)))
			cpblk(Me.PEffect, num, 4)
			Dim pEffectClass As __Pointer(Of GClass)
			Dim pEffectData As __Pointer(Of Void)
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GRTTI.GClass** modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Void** modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), <Module>.IEngine, __Dereference(Me.PEffect), pEffectClass, pEffectData, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 236)))
			Me.PEffectClass = pEffectClass
			Me.PEffectData = pEffectData
			Dim gMeasures As GMeasures
			Me.EffectPropTree.SetVariable(Me.PEffectClass, Me.PEffectData, <Module>.GMeasures.{ctor}(gMeasures, <Module>.Measures, 1F))
			<Module>.GArray<GStreamBuffer>.Clear(Me.UndoArray, 0)
			Dim num2 As Integer = <Module>.GArray<GStreamBuffer>.Add(Me.UndoArray)
			Me.UndoIndex = num2
			Dim arg_D4_0 As Object = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GStream*), <Module>.IEngine, __Dereference(Me.PEffect), num2 * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 224)))
			Me.SavedIndex = Me.UndoIndex
			Me.FileName = ""
			Me.Modified = False
			Me.tbEffectEditor.SetItemEnable(207, False)
			Me.tbEffectEditor.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = False
			Me.menuEditRedo.Enabled = False
			Me.UpdateWindowText()
			Me.UpdateEffect(True)
		End Sub

		Private Sub OpenDocument(filepathname As __Pointer(Of SByte))
			Me.DiscardDocument()
			Dim gHandle<9> As GHandle<9>
			Dim num As Integer = calli(GHandle<9>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>*,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, gHandle<9>, filepathname, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 212)))
			Dim gHandle<9>2 As GHandle<9>
			cpblk(gHandle<9>2, num, 4)
			If(If((gHandle<9>2 <> 0), 1, 0)) <> 0 Then
				Me.FileName = New String(CType(filepathname, __Pointer(Of SByte)))
				cpblk(Me.PEffect, gHandle<9>2, 4)
				Dim pEffectClass As __Pointer(Of GClass)
				Dim pEffectData As __Pointer(Of Void)
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GRTTI.GClass** modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Void** modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), <Module>.IEngine, __Dereference(Me.PEffect), pEffectClass, pEffectData, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 236)))
				Me.PEffectClass = pEffectClass
				Me.PEffectData = pEffectData
				Dim gMeasures As GMeasures
				Me.EffectPropTree.SetVariable(Me.PEffectClass, Me.PEffectData, <Module>.GMeasures.{ctor}(gMeasures, <Module>.Measures, 1F))
				<Module>.GArray<GStreamBuffer>.Clear(Me.UndoArray, 0)
				Dim num2 As Integer = <Module>.GArray<GStreamBuffer>.Add(Me.UndoArray)
				Me.UndoIndex = num2
				Dim arg_F8_0 As Object = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GStream*), <Module>.IEngine, __Dereference(Me.PEffect), num2 * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 224)))
				Me.SavedIndex = Me.UndoIndex
				Me.Modified = False
				Me.tbEffectEditor.SetItemEnable(207, False)
				Me.tbEffectEditor.SetItemEnable(208, False)
				Me.menuEditUndo.Enabled = False
				Me.menuEditRedo.Enabled = False
				Me.UpdateWindowText()
				Me.UpdateEffect(True)
				Me.FileDialog.UpdateRecentFiles()
			Else
				Me.NewDocument()
			End If
		End Sub

		Private Sub SaveDocument()
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.FileName)
			Dim flag As Boolean
			Try
				Dim num As UInteger = CUInt((__Dereference(ptr)))
				Dim ptr2 As __Pointer(Of SByte)
				If num <> 0UI Then
					ptr2 = num
				Else
					ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				flag = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, __Dereference(Me.PEffect), ptr2, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 228)))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			If flag Then
				Me.SavedIndex = Me.UndoIndex
				Me.Modified = False
				Me.UpdateWindowText()
				Dim expr_80 As __Pointer(Of GIEngine) = <Module>.IEngine
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_80, __Dereference((__Dereference(CType(expr_80, __Pointer(Of Integer))) + 244)))
			End If
		End Sub

		Private Sub EffectEditor_Activated(sender As Object, e As EventArgs)
		End Sub

		Private Sub EffectEditor_Deactivate(sender As Object, e As EventArgs)
		End Sub

		Private Sub UpdateEffect(<MarshalAs(UnmanagedType.U1)> refresh_prototype As Boolean)
			Dim effect As __Pointer(Of GIEffect) = Me.Effect
			If effect IsNot Nothing Then
				Dim expr_0B As __Pointer(Of GIEffect) = effect
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_0B, __Dereference((__Dereference(CType(expr_0B, __Pointer(Of Integer))) + 4)))
				effect = Me.Effect
				If effect IsNot Nothing Then
					Dim expr_20 As __Pointer(Of GIEffect) = effect
					Dim expr_2A As __Pointer(Of GIEffect) = expr_20 + __Dereference((__Dereference(CType((expr_20 + 4 / __SizeOf(GIEffect)), __Pointer(Of Integer))) + 4)) / __SizeOf(GIEffect) + 4 / __SizeOf(GIEffect)
					Dim arg_34_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_2A, __Dereference((__Dereference(CType(expr_2A, __Pointer(Of Integer))) + 4)))
					Me.Effect = Nothing
				End If
			End If
			Dim pEffect As __Pointer(Of GHandle<9>) = Me.PEffect
			If pEffect IsNot Nothing AndAlso (If((__Dereference(CType(pEffect, __Pointer(Of Integer))) <> 0), 1, 0)) <> 0 Then
				If refresh_prototype Then
					Dim arg_78_0 As Object = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>), <Module>.IEngine, __Dereference(pEffect), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 240)))
				End If
				Dim emitterPosition As __Pointer(Of GPoint3) = Me.EmitterPosition
				Dim num As Single = __Dereference(emitterPosition) + 32F
				Dim num2 As Single = __Dereference((emitterPosition + 4))
				Dim num3 As Single = __Dereference((emitterPosition + 8)) + 32F
				Dim gPoint As GPoint3 = num
				__Dereference((gPoint + 4)) = num2
				__Dereference((gPoint + 8)) = num3
				Dim iScene As __Pointer(Of GIScene) = Me.IScene
				Me.Effect = calli(GIEffect* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),GVector3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single), iScene, __Dereference(Me.PEffect), gPoint, Me.EmitterDirection, 0F, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 316)))
			End If
		End Sub

		Private Sub EffectPropTree_ItemChanged()
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
			Dim arg_F4_0 As Object = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,GStream*), <Module>.IEngine, __Dereference(Me.PEffect), num3 * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 224)))
			If Me.UndoIndex <= Me.SavedIndex Then
				Me.SavedIndex = 0
			End If
			Me.Modified = True
			Me.tbEffectEditor.SetItemEnable(202, True)
			Me.tbEffectEditor.SetItemEnable(207, True)
			Me.tbEffectEditor.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = True
			Me.menuEditRedo.Enabled = False
			Me.menuFileSave.Enabled = True
			Me.UpdateWindowText()
			Me.UpdateEffect(True)
		End Sub

		Private Sub EffectPropTree_SelectedIndexChanged()
		End Sub

		Private Sub EffectEditor_Load(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of HWND__) = CType(Me.panEffectViewport.Handle.ToPointer(), __Pointer(Of HWND__))
			Dim num As Integer = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,HWND__*,System.Int32), <Module>.IEngine, ptr, 4, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 100)))
			Me.IRenderTargetIdx = num
			Dim num2 As Integer = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, num, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 96)))
			Me.IRenderTarget = num2
			Me.IViewport = calli(GIViewport* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), num2, 0, __Dereference((__Dereference(num2) + 32)))
			Dim num3 As Integer = calli(GIScene* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.IEngine, 1, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 12)))
			Me.IScene = num3
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), num3, 0.5F, 0.5F, 0.5F, 0F, 0F, 0F, 1F, 1F, __Dereference((__Dereference(num3) + 76)))
			Dim gColor As GColor = 0.6F
			__Dereference((gColor + 4)) = 0.6F
			__Dereference((gColor + 8)) = 0.6F
			__Dereference((gColor + 12)) = 1F
			Dim iScene As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), iScene, gColor, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 68)))
			Dim gColor2 As GColor = 0.5F
			__Dereference((gColor2 + 4)) = 0.5F
			__Dereference((gColor2 + 8)) = 0.5F
			__Dereference((gColor2 + 12)) = 1F
			Dim iScene2 As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene2, gColor2, 2.61799383F, -0.6632251F, __Dereference((__Dereference(CType(iScene2, __Pointer(Of Integer))) + 72)))
			Dim iScene3 As __Pointer(Of GIScene) = Me.IScene
			Dim num4 As Integer = calli(GITerrain* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Int32), iScene3, 64, 64, 1, __Dereference((__Dereference(CType(iScene3, __Pointer(Of Integer))) + 152)))
			Me.Terrain = num4
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), num4, 5, __Dereference((__Dereference(num4) + 32)))
			Dim terrain As __Pointer(Of GITerrain) = Me.Terrain
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), terrain, 0, <Module>.??_C@_0BC@NCEDNBHE@tiles?1000?5default?$AA@, __Dereference((__Dereference(CType(terrain, __Pointer(Of Integer))) + 12)))
			AddHandler Me.panEffectViewport.MouseWheel, AddressOf Me.panEffectViewport_MouseWheel
			AddHandler Me.panEffectViewport.KeyDown, AddressOf Me.panEffectViewport_KeyDown
			AddHandler Me.panEffectViewport.KeyUp, AddressOf Me.panEffectViewport_KeyUp
			Me.ShowEffectPosDir = 1
			Me.menuViewShowEffectPosDir.Checked = True
			Dim ptr2 As __Pointer(Of GHandle<11>) = <Module>.new(4UI)
			Dim emitterLines As __Pointer(Of GHandle<11>)
			Try
				If ptr2 IsNot Nothing Then
					__Dereference(CType(ptr2, __Pointer(Of Integer))) = 0
					emitterLines = ptr2
				Else
					emitterLines = 0
				End If
			Catch 
				<Module>.delete(CType(ptr2, __Pointer(Of Void)))
				Throw
			End Try
			Me.EmitterLines = emitterLines
			Dim iScene4 As __Pointer(Of GIScene) = Me.IScene
			Dim gHandle<11> As GHandle<11>
			Dim num5 As Integer = calli(GHandle<11>* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>*,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), iScene4, gHandle<11>, 0, __Dereference((__Dereference(CType(iScene4, __Pointer(Of Integer))) + 256)))
			cpblk(Me.EmitterLines, num5, 4)
			AddHandler Application.Idle, AddressOf Me.OnIdle
			If Me.FileNameToLoad.Length > 0 Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.FileNameToLoad)
				Dim gBaseString<char>2 As GBaseString<char>
				Try
					Dim num6 As UInteger = CUInt((__Dereference(ptr3)))
					Dim ptr4 As __Pointer(Of SByte)
					If num6 <> 0UI Then
						ptr4 = num6
					Else
						ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					<Module>.GFileSystem.GetFileFullPath(<Module>.FS, AddressOf gBaseString<char>2, ptr4)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
					If(If((__Dereference((gBaseString<char>2 + 4)) = 0), 1, 0)) = 0 Then
						Dim value As __Pointer(Of SByte)
						If gBaseString<char>2 IsNot Nothing Then
							value = gBaseString<char>2
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.FileDialog.FilePath = New String(CType(value, __Pointer(Of SByte)))
						Dim filepathname As __Pointer(Of SByte)
						If gBaseString<char>2 IsNot Nothing Then
							filepathname = gBaseString<char>2
						Else
							filepathname = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.OpenDocument(filepathname)
					Else
						Me.NewDocument()
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
				End If
			Else
				Me.NewDocument()
			End If
		End Sub

		Private Sub EffectEditor_Closing(sender As Object, e As CancelEventArgs)
			If Not Me.SaveDocumentIfChanged() Then
				e.Cancel = True
			End If
		End Sub

		Private Sub EffectEditor_Closed(sender As Object, e As EventArgs)
			Me.StartTrackEditor(Nothing)
			Dim iScene As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<11>), iScene, __Dereference(Me.EmitterLines), __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 260)))
			Dim emitterLines As __Pointer(Of GHandle<11>) = Me.EmitterLines
			If emitterLines IsNot Nothing Then
				<Module>.delete(CType(emitterLines, __Pointer(Of Void)))
				Me.EmitterLines = Nothing
			End If
			Dim emitterPosition As __Pointer(Of GPoint3) = Me.EmitterPosition
			If emitterPosition IsNot Nothing Then
				<Module>.delete(CType(emitterPosition, __Pointer(Of Void)))
				Me.EmitterPosition = Nothing
			End If
			Dim emitterDirection As __Pointer(Of GVector3) = Me.EmitterDirection
			If emitterDirection IsNot Nothing Then
				<Module>.delete(CType(emitterDirection, __Pointer(Of Void)))
				Me.EmitterDirection = Nothing
			End If
			Dim toolWindows As ArrayList = Me.ToolWindows
			If toolWindows IsNot Nothing Then
				toolWindows.Remove(Me)
				Me.ToolWindows = Nothing
			End If
			Dim effect As __Pointer(Of GIEffect) = Me.Effect
			If effect IsNot Nothing Then
				Dim expr_9F As __Pointer(Of GIEffect) = effect
				Dim expr_A9 As __Pointer(Of GIEffect) = expr_9F + __Dereference((__Dereference(CType((expr_9F + 4 / __SizeOf(GIEffect)), __Pointer(Of Integer))) + 4)) / __SizeOf(GIEffect) + 4 / __SizeOf(GIEffect)
				Dim arg_B3_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_A9, __Dereference((__Dereference(CType(expr_A9, __Pointer(Of Integer))) + 4)))
				Me.Effect = Nothing
			End If
			Dim expr_C1 As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_C1, __Dereference((__Dereference(CType(expr_C1, __Pointer(Of Integer))) + 156)))
			Me.Terrain = Nothing
			Dim iScene2 As __Pointer(Of GIScene) = Me.IScene
			If iScene2 IsNot Nothing Then
				Dim expr_E1 As __Pointer(Of GIScene) = iScene2
				Dim expr_EB As __Pointer(Of GIScene) = expr_E1 + __Dereference((__Dereference(CType((expr_E1 + 4 / __SizeOf(GIScene)), __Pointer(Of Integer))) + 4)) / __SizeOf(GIScene) + 4 / __SizeOf(GIScene)
				Dim arg_F5_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_EB, __Dereference((__Dereference(CType(expr_EB, __Pointer(Of Integer))) + 4)))
				Me.IScene = Nothing
			End If
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, Me.IRenderTargetIdx, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 104)))
			Me.IRenderTargetIdx = -1
			Me.IRenderTarget = Nothing
			Me.IViewport = Nothing
			If(If((__Dereference(CType(Me.PEffect, __Pointer(Of Integer))) <> 0), 1, 0)) <> 0 Then
				Dim gMeasures As GMeasures
				Me.EffectPropTree.SetVariable(Nothing, Nothing, <Module>.GMeasures.{ctor}(gMeasures, <Module>.Measures, 1F))
				Me.PEffectClass = Nothing
				Me.PEffectData = Nothing
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>), <Module>.IEngine, __Dereference(Me.PEffect), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 216)))
				__Dereference(CType(Me.PEffect, __Pointer(Of Integer))) = 0
			End If
			Dim undoArray As __Pointer(Of GArray<GStreamBuffer>) = Me.UndoArray
			If undoArray IsNot Nothing Then
				Dim ptr As __Pointer(Of GArray<GStreamBuffer>) = undoArray
				<Module>.GArray<GStreamBuffer>.{dtor}(ptr)
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Me.UndoArray = Nothing
			End If
		End Sub

		Private Sub OnIdle(sender As Object, e As EventArgs)
			If MyBase.ContainsFocus Then
				Me.panEffectViewport.Invalidate(False)
			End If
		End Sub

		Private Sub panEffectViewport_Paint(sender As Object, e As PaintEventArgs)
			If <Module>.ISoundSys IsNot Nothing Then
				Dim expr_0C As __Pointer(Of GISoundSys) = <Module>.ISoundSys
				Dim arg_14_0 As Object = calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_0C, __Dereference((__Dereference(CType(expr_0C, __Pointer(Of Integer))))))
			End If
			If Me.IRenderTarget IsNot Nothing AndAlso Me.IViewport IsNot Nothing AndAlso Me.IScene IsNot Nothing AndAlso Me.Effect IsNot Nothing Then
				If Me.LastTime = 0L Then
					Me.LastTime = <Module>.GTimer.GetTimeH(<Module>.Timer)
					Me.CameraBlendDist = Me.CamDistance
				End If
				Dim num As Long = <Module>.GTimer.GetTimeH(<Module>.Timer)
				Dim num2 As Long = num - Me.LastTime
				Me.LastTime = num
				Dim num3 As Single = CSng(Math.Exp(CDec((CSng(num2) * -5E-06F))))
				Dim num4 As Single = (Me.CameraBlendDist - Me.CamDistance) * num3 + Me.CamDistance
				Me.CameraBlendDist = num4
				Dim camDirection As Single = Me.CamDirection
				Dim num5 As Single = CSng(Math.Sin(CDec(camDirection)))
				Dim camDirection2 As Single = Me.CamDirection
				Dim num6 As Single = CSng(Math.Cos(CDec(camDirection2)))
				Dim camElevation As Single = Me.CamElevation
				Dim num7 As Single = CSng(Math.Sin(CDec(camElevation)))
				Dim camElevation2 As Single = Me.CamElevation
				Dim num8 As Single = -CSng(Math.Cos(CDec(camElevation2)))
				Dim gVector As GVector3 = num8 * num5
				__Dereference((gVector + 4)) = num7
				__Dereference((gVector + 8)) = num8 * num6
				Dim num9 As Single = num4
				Dim num10 As Single = gVector * num9
				Dim num11 As Single = num9 * num7
				Dim num12 As Single = num9 * __Dereference((gVector + 8))
				Dim num13 As Single = num10 + 32F
				Dim num14 As Single = num11
				Dim num15 As Single = num12 + 32F
				Dim gPoint As GPoint3 = num13
				__Dereference((gPoint + 4)) = num14
				__Dereference((gPoint + 8)) = num15
				Dim gVector2 As GVector3 = -(num7 * num5)
				__Dereference((gVector2 + 4)) = num8
				__Dereference((gVector2 + 8)) = -(num7 * num6)
				Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single,System.Single), iViewport, gPoint, Me.CamDirection, Me.CamElevation, 0F, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 12)))
				If <Module>.ISoundSys IsNot Nothing Then
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),GVector3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),GVector3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), <Module>.ISoundSys, gPoint, gVector, gVector2, __Dereference((__Dereference(CType(<Module>.ISoundSys, __Pointer(Of Integer))) + 4)))
				End If
				Me.RefreshEmitter(num, num2)
				Dim iScene As __Pointer(Of GIScene) = Me.IScene
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), iScene, num2, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 32)))
				Dim iRenderTarget As __Pointer(Of GIRenderTarget) = Me.IRenderTarget
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GIScene*,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iRenderTarget, Me.IScene, 8256, __Dereference((__Dereference(CType(iRenderTarget, __Pointer(Of Integer))) + 36)))
			End If
		End Sub

		Private Sub panEffectViewport_MouseDown(sender As Object, e As MouseEventArgs)
			If e.Button = MouseButtons.Left Then
				Me.CompletePressedDrag(e.X, e.Y)
				If __Dereference((Me.KeyTimes + 136)) <> 0L Then
					Me.DragMY = e.Y
					Me.DragMode = 10
					Me.panEffectViewport.Capture = True
				Else
					Dim gPoint As GPoint3
					__Dereference((gPoint + 8)) = 0F
					gPoint = 0F
					Dim gPlane As GPlane = 0F
					__Dereference((gPlane + 4)) = 1F
					__Dereference((gPlane + 8)) = 0F
					__Dereference((gPlane + 12)) = 0F
					Dim num As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
					Dim gRay As GRay
					If <Module>.GPlane.Intersect(gPlane, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, e.X, e.Y, __Dereference(num)), gPoint) IsNot Nothing Then
						__Dereference(CType(Me.EmitterPosition, __Pointer(Of Single))) = gPoint - 32F
						__Dereference(CType((Me.EmitterPosition + 8 / __SizeOf(GPoint3)), __Pointer(Of Single))) = __Dereference((gPoint + 8)) - 32F
						Me.DragMode = 9
						Me.panEffectViewport.Capture = True
					End If
				End If
			Else If e.Button = MouseButtons.Middle Then
				Me.CompletePressedDrag(e.X, e.Y)
				Me.DragMX = e.X
				Me.DragMY = e.Y
				Me.DragMode = 18
				Me.panEffectViewport.Capture = True
				<Module>.ShowCursor(0)
			End If
		End Sub

		Private Sub panEffectViewport_MouseUp(sender As Object, e As MouseEventArgs)
			Me.CompletePressedDrag(e.X, e.Y)
		End Sub

		Private Sub CompletePressedDrag(m_x As Integer, m_y As Integer)
			Dim dragMode As Integer = Me.DragMode
			If dragMode <> 0 AndAlso dragMode >= 6 Then
				If dragMode - 18 <= 1 Then
					<Module>.ShowCursor(1)
				End If
				Me.DragMode = 0
				Me.panEffectViewport.Capture = False
			End If
		End Sub

		Private Sub panEffectViewport_MouseMove(sender As Object, e As MouseEventArgs)
			If Form.ActiveForm Is Me Then
				Me.panEffectViewport.Focus()
				Dim dragMode As Integer = Me.DragMode
				If dragMode <> 9 Then
					If dragMode <> 10 Then
						If dragMode = 18 AndAlso (e.X <> Me.DragMX OrElse e.Y <> Me.DragMY) Then
							Me.CamDirection = CSng((e.X - Me.DragMX)) * 0.002F + Me.CamDirection
							Dim dragMY As Integer = Me.DragMY
							Dim num As Single = Me.CamElevation - CSng((e.Y - dragMY)) * 0.002F
							Dim camElevationMax As Single = Me.CamElevationMax
							Dim num2 As Single
							If num < camElevationMax Then
								num2 = num
							Else
								num2 = camElevationMax
							End If
							Dim camElevationMin As Single = Me.CamElevationMin
							Dim camElevation As Single
							If num2 > camElevationMin Then
								camElevation = num2
							Else
								camElevation = camElevationMin
							End If
							Me.CamElevation = camElevation
							Dim dragMX As tagPOINT = Me.DragMX
							__Dereference((dragMX + 4)) = dragMY
							<Module>.ClientToScreen(CType(Me.panEffectViewport.Handle.ToPointer(), __Pointer(Of HWND__)), AddressOf dragMX)
							<Module>.SetCursorPos(dragMX, __Dereference((dragMX + 4)))
						End If
					Else
						Dim ptr As __Pointer(Of GPoint3) = Me.EmitterPosition + 4 / __SizeOf(GPoint3)
						__Dereference(CType(ptr, __Pointer(Of Single))) = CSng((CDec((Me.DragMY - e.Y)) * 0.04 + CDec((__Dereference(CType(ptr, __Pointer(Of Single)))))))
						Me.DragMY = e.Y
					End If
				Else
					Dim gPoint As GPoint3
					__Dereference((gPoint + 8)) = 0F
					gPoint = 0F
					Dim gPlane As GPlane = 0F
					__Dereference((gPlane + 4)) = 1F
					__Dereference((gPlane + 8)) = 0F
					__Dereference((gPlane + 12)) = 0F
					Dim num3 As Integer = __Dereference(CType(Me.IViewport, __Pointer(Of Integer))) + 56
					Dim gRay As GRay
					If <Module>.GPlane.Intersect(gPlane, calli(GRay* modreq(System.Runtime.CompilerServices.IsUdtReturn) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GRay*,System.Int32,System.Int32), Me.IViewport, gRay, e.X, e.Y, __Dereference(num3)), gPoint) IsNot Nothing Then
						__Dereference(CType(Me.EmitterPosition, __Pointer(Of Single))) = gPoint - 32F
						__Dereference(CType((Me.EmitterPosition + 8 / __SizeOf(GPoint3)), __Pointer(Of Single))) = __Dereference((gPoint + 8)) - 32F
					End If
				End If
			End If
		End Sub

		Private Sub panEffectViewport_MouseWheel(sender As Object, e As MouseEventArgs)
			Dim num As Single = Me.CamDistance - CSng(e.Delta) * 0.008333334F * 2F
			Dim camDistanceMin As Single = Me.CamDistanceMin
			Dim num2 As Single
			If num > camDistanceMin Then
				num2 = num
			Else
				num2 = camDistanceMin
			End If
			Dim camDistanceMax As Single = Me.CamDistanceMax
			Dim camDistance As Single
			If num2 < camDistanceMax Then
				camDistance = num2
			Else
				camDistance = camDistanceMax
			End If
			Me.CamDistance = camDistance
		End Sub

		Private Sub panEffectViewport_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode >= Keys.None OrElse e.KeyCode < CType(256, Keys) Then
				If __Dereference((e.KeyCode * Keys.Back + Me.KeyTimes)) = 0L Then
					__Dereference((e.KeyCode * Keys.Back + Me.KeyTimes)) = <Module>.GTimer.GetTimeH(<Module>.Timer)
				End If
				e.Handled = True
				Dim keyCode As Keys = e.KeyCode
				If keyCode <> Keys.W Then
					If keyCode <> Keys.F1 Then
						If keyCode = Keys.F5 Then
							Me.UpdateEffect(e.Control)
						End If
					Else
						Dim b As Byte = If((Not Me.CamLimited), 1, 0)
						Me.CamLimited = (b <> 0)
						If b <> 0 Then
							Me.CamElevationMin = 0.6981317F
							Me.CamElevationMax = 1.134464F
							Dim camElevation As Single = Me.CamElevation
							Dim num As Single
							Dim camElevation2 As Single
							If camElevation < 1.134464F Then
								num = camElevation
								If camElevation <= 0.6981317F Then
									camElevation2 = 0.6981317F
									GoTo IL_EB
								End If
							Else
								num = 1.134464F
							End If
							camElevation2 = num
							IL_EB:
							Me.CamElevation = camElevation2
							Me.CamDistanceMin = <Module>.Measures * 44F
							Dim num2 As Single = <Module>.Measures * 80F
							Me.CamDistanceMax = num2
							Dim camDistance As Single = Me.CamDistance
							Dim camDistanceMin As Single = Me.CamDistanceMin
							Dim num3 As Single
							If camDistance > camDistanceMin Then
								num3 = camDistance
							Else
								num3 = camDistanceMin
							End If
							Dim num4 As Single = num2
							Dim camDistance2 As Single
							If num3 < num4 Then
								camDistance2 = num3
							Else
								camDistance2 = num4
							End If
							Me.CamDistance = camDistance2
						Else
							Me.CamElevationMin = -1.57079637F
							Me.CamElevationMax = 1.57079637F
							Me.CamDistanceMin = 0F
							Me.CamDistanceMax = 1000F
						End If
					End If
				Else
					Dim terrain As __Pointer(Of GITerrain) = Me.Terrain
					Dim num5 As Integer = __Dereference(CType(terrain, __Pointer(Of Integer)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), Me.Terrain, calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), terrain, __Dereference((num5 + 36))) Xor 34, __Dereference((num5 + 32)))
				End If
			End If
		End Sub

		Private Sub panEffectViewport_KeyUp(sender As Object, e As KeyEventArgs)
			If e.KeyCode >= Keys.None OrElse e.KeyCode < CType(256, Keys) Then
				If __Dereference((e.KeyCode * Keys.Back + Me.KeyTimes)) <> 0L Then
					__Dereference((e.KeyCode * Keys.Back + Me.KeyTimes)) = 0L
				End If
				e.Handled = True
			End If
		End Sub

		Private Sub UpdateWindowText()
			Dim str As String
			If Me.Modified Then
				str = " *"
			Else
				str = ""
			End If
			Dim str2 As String
			If Me.FileName.Length <> 0 Then
				str2 = Me.FileName
			Else
				str2 = "Untitled"
			End If
			Me.Text = str2 + str + " - EffectEditor"
		End Sub

		Private Sub menuFileNew_Click(sender As Object, e As EventArgs)
			If Me.SaveDocumentIfChanged() Then
				Me.NewDocument()
			End If
		End Sub

		Private Sub menuFileOpen_Click(sender As Object, e As EventArgs)
			Me.tbEffectEditor.Focus()
			If Me.SaveDocumentIfChanged() Then
				Me.FileDialog.AvailableModes = 10
				Me.FileDialog.SelectedMode = 2
				Me.FileDialog.FileName = ""
				If Me.FileDialog.ShowDialog() = DialogResult.OK Then
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.FileDialog.FilePath)
					Try
						Dim num As UInteger = CUInt((__Dereference(ptr)))
						Dim filepathname As __Pointer(Of SByte)
						If num <> 0UI Then
							filepathname = num
						Else
							filepathname = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.OpenDocument(filepathname)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
					<Module>.SaveOptions()
				End If
			End If
		End Sub

		Private Sub menuFileOpenRecent_Click(sender As Object, e As EventArgs)
			Me.tbEffectEditor.Focus()
			If Me.SaveDocumentIfChanged() Then
				Me.FileDialog.AvailableModes = 10
				Me.FileDialog.SelectedMode = 8
				Me.FileDialog.FileName = ""
				If Me.FileDialog.ShowDialog() = DialogResult.OK Then
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.FileDialog.FilePath)
					Try
						Dim num As UInteger = CUInt((__Dereference(ptr)))
						Dim filepathname As __Pointer(Of SByte)
						If num <> 0UI Then
							filepathname = num
						Else
							filepathname = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.OpenDocument(filepathname)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
					<Module>.SaveOptions()
				End If
			End If
		End Sub

		Private Sub menuFileSave_Click(sender As Object, e As EventArgs)
			Me.tbEffectEditor.Focus()
			Me.EffectPropTree.Focus()
			If(If((__Dereference(CType(Me.PEffect, __Pointer(Of Integer))) <> 0), 1, 0)) <> 0 Then
				If Me.FileName.Length = 0 Then
					Me.menuFileSaveAs_Click(sender, e)
				Else
					Me.SaveDocument()
				End If
			End If
		End Sub

		Private Sub menuFileSaveAs_Click(sender As Object, e As EventArgs)
			Me.tbEffectEditor.Focus()
			Me.EffectPropTree.Focus()
			If(If((__Dereference(CType(Me.PEffect, __Pointer(Of Integer))) <> 0), 1, 0)) <> 0 Then
				Me.FileDialog.AvailableModes = 4
				Me.FileDialog.SelectedMode = 4
				If Me.FileDialog.ShowDialog() = DialogResult.OK Then
					Dim gBaseString<char> As GBaseString<char>
					<Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.FileDialog.FilePath)
					Try
						Dim ptr As __Pointer(Of SByte)
						If gBaseString<char> IsNot Nothing Then
							ptr = gBaseString<char>
						Else
							ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						If calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GHandle<9>,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, __Dereference(Me.PEffect), ptr, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 228))) Then
							Me.SavedIndex = Me.UndoIndex
							Dim value As __Pointer(Of SByte)
							If gBaseString<char> IsNot Nothing Then
								value = gBaseString<char>
							Else
								value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							Me.FileName = New String(CType(value, __Pointer(Of SByte)))
							Me.Modified = False
							Me.UpdateWindowText()
							Me.FileDialog.UpdateRecentFiles()
							<Module>.SaveOptions()
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
				End If
			End If
		End Sub

		Private Sub menuFileClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub tbEffectEditor_ButtonClick(idx As Integer, radio_group As Integer)
			If idx = 200 Then
				Me.menuFileNew_Click(Nothing, Nothing)
			Else If idx = 201 Then
				Me.menuFileOpen_Click(Nothing, Nothing)
			Else If idx = 202 Then
				Me.menuFileSave_Click(Nothing, Nothing)
			Else If idx = 207 Then
				Me.menuEditUndo_Click(Nothing, Nothing)
			Else If idx = 208 Then
				Me.menuEditRedo_Click(Nothing, Nothing)
			End If
		End Sub

		Private Sub panEffectViewport_SizeChanged(sender As Object, e As EventArgs)
			If Me.IRenderTarget IsNot Nothing Then
				<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CH@OGONMAAB@c?3?2jtfcode?2src?2workshop?2EffectEd@), __Pointer(Of SByte)), 1345, CType((AddressOf <Module>.??_C@_0DI@LOKDIGJJ@NWorkshop?3?3NEffectEditor?3?3panEff@), __Pointer(Of SByte)))
				Dim clientSize As Size = Me.panEffectViewport.ClientSize
				<Module>.GLogger.Log(0, CType((AddressOf <Module>.??_C@_0CC@JPPJGCIM@Resize?5effect?5viewport?5to?5?$CFd?5x?5?$CF@), __Pointer(Of SByte)), Me.panEffectViewport.ClientSize.Width, clientSize.Height)
				Dim clientSize2 As Size = Me.panEffectViewport.ClientSize
				Dim clientSize3 As Size = Me.panEffectViewport.ClientSize
				Dim num As Integer = __Dereference(CType(Me.IRenderTarget, __Pointer(Of Integer))) + 12
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), Me.IRenderTarget, clientSize3.Width, clientSize2.Height, __Dereference(num))
				If Me.panEffectViewport.ClientSize.Width <> 0 AndAlso Me.panEffectViewport.ClientSize.Height <> 0 Then
					MyBase.Invalidate()
				End If
			End If
		End Sub

		Private Sub menuTrackEditor_Click(sender As Object, e As EventArgs)
		End Sub

		Private Sub menuEmitterReset_Click(sender As Object, e As EventArgs)
			Dim gPoint As GPoint3 = 0F
			__Dereference((gPoint + 4)) = 0F
			__Dereference((gPoint + 8)) = 0F
			cpblk(Me.EmitterPosition, gPoint, 12)
			Dim gVector As GVector3 = 0F
			__Dereference((gVector + 4)) = 1F
			__Dereference((gVector + 8)) = 0F
			cpblk(Me.EmitterDirection, gVector, 12)
			Me.EmitterVelType = 0
			Me.EmitterDirType = 0
			Me.EmitterMovType = 2
			Me.menuEmitterVel0.Checked = True
			Me.menuEmitterVel1.Checked = False
			Me.menuEmitterVel2.Checked = False
			Me.menuEmitterVel3.Checked = False
			Me.menuEmitterDirHorizontal.Checked = False
			Me.menuEmitterDirVerticalP.Checked = True
			Me.menuEmitterDirVerticalM.Checked = False
			Me.menuEmitterDirRotate.Checked = False
			Me.menuEmitterMovHorizontal.Checked = True
			Me.menuEmitterMovVerticalP.Checked = False
			Me.menuEmitterMovVerticalM.Checked = False
			Me.menuEmitterMovRotate.Checked = False
		End Sub

		Private Sub menuEmitterVel0_Click(sender As Object, e As EventArgs)
			Me.EmitterVelType = 0
			Me.menuEmitterVel0.Checked = True
			Me.menuEmitterVel1.Checked = False
			Me.menuEmitterVel2.Checked = False
			Me.menuEmitterVel3.Checked = False
		End Sub

		Private Sub menuEmitterVel1_Click(sender As Object, e As EventArgs)
			Me.EmitterVelType = 5
			Me.menuEmitterVel0.Checked = False
			Me.menuEmitterVel1.Checked = True
			Me.menuEmitterVel2.Checked = False
			Me.menuEmitterVel3.Checked = False
		End Sub

		Private Sub menuEmitterVel2_Click(sender As Object, e As EventArgs)
			Me.EmitterVelType = 10
			Me.menuEmitterVel0.Checked = False
			Me.menuEmitterVel1.Checked = False
			Me.menuEmitterVel2.Checked = True
			Me.menuEmitterVel3.Checked = False
		End Sub

		Private Sub menuEmitterVel3_Click(sender As Object, e As EventArgs)
			Me.EmitterVelType = 30
			Me.menuEmitterVel0.Checked = False
			Me.menuEmitterVel1.Checked = False
			Me.menuEmitterVel2.Checked = False
			Me.menuEmitterVel3.Checked = True
		End Sub

		Private Sub menuEmitterDirVerticalP_Click(sender As Object, e As EventArgs)
			Me.EmitterDirType = 0
			Me.menuEmitterDirHorizontal.Checked = False
			Me.menuEmitterDirVerticalP.Checked = True
			Me.menuEmitterDirVerticalM.Checked = False
			Me.menuEmitterDirRotate.Checked = False
		End Sub

		Private Sub menuEmitterDirVerticalM_Click(sender As Object, e As EventArgs)
			Me.EmitterDirType = 1
			Me.menuEmitterDirHorizontal.Checked = False
			Me.menuEmitterDirVerticalP.Checked = False
			Me.menuEmitterDirVerticalM.Checked = True
			Me.menuEmitterDirRotate.Checked = False
		End Sub

		Private Sub menuEmitterDirHorizontal_Click(sender As Object, e As EventArgs)
			Me.EmitterDirType = 2
			Me.menuEmitterDirHorizontal.Checked = True
			Me.menuEmitterDirVerticalP.Checked = False
			Me.menuEmitterDirVerticalM.Checked = False
			Me.menuEmitterDirRotate.Checked = False
		End Sub

		Private Sub menuEmitterDirRotate_Click(sender As Object, e As EventArgs)
			Me.EmitterDirType = 3
			Me.menuEmitterDirHorizontal.Checked = False
			Me.menuEmitterDirVerticalP.Checked = False
			Me.menuEmitterDirVerticalM.Checked = False
			Me.menuEmitterDirRotate.Checked = True
		End Sub

		Private Sub menuEmitterMovHorizontal_Click(sender As Object, e As EventArgs)
			Me.EmitterMovType = 2
			Me.menuEmitterMovHorizontal.Checked = True
			Me.menuEmitterMovVerticalP.Checked = False
			Me.menuEmitterMovVerticalM.Checked = False
			Me.menuEmitterMovRotate.Checked = False
		End Sub

		Private Sub menuEmitterMovVerticalP_Click(sender As Object, e As EventArgs)
			Me.EmitterMovType = 0
			Me.menuEmitterMovHorizontal.Checked = False
			Me.menuEmitterMovVerticalP.Checked = True
			Me.menuEmitterMovVerticalM.Checked = False
			Me.menuEmitterMovRotate.Checked = False
		End Sub

		Private Sub menuEmitterMovVerticalM_Click(sender As Object, e As EventArgs)
			Me.EmitterMovType = 1
			Me.menuEmitterMovHorizontal.Checked = False
			Me.menuEmitterMovVerticalP.Checked = False
			Me.menuEmitterMovVerticalM.Checked = True
			Me.menuEmitterMovRotate.Checked = False
		End Sub

		Private Sub menuEmitterMovRotate_Click(sender As Object, e As EventArgs)
			Me.EmitterMovType = 3
			Me.menuEmitterMovHorizontal.Checked = False
			Me.menuEmitterMovVerticalP.Checked = False
			Me.menuEmitterMovVerticalM.Checked = False
			Me.menuEmitterMovRotate.Checked = True
		End Sub

		Private Sub menuViewShowEffectPosDir_Click(sender As Object, e As EventArgs)
			Dim num As Integer = If((Me.ShowEffectPosDir = 0), 1, 0)
			Me.ShowEffectPosDir = num
			Dim checked As Byte = If((num <> 0), 1, 0)
			Me.menuViewShowEffectPosDir.Checked = (checked <> 0)
		End Sub

		Private Sub menuViewDebugMode_Click(sender As Object, e As EventArgs)
			Dim expr_06 As __Pointer(Of GIScene) = Me.IScene
			Dim num As Integer = If((calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_06, __Dereference((__Dereference(CType(expr_06, __Pointer(Of Integer))) + 332))) = 0), 1, 0)
			Dim iScene As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), iScene, num, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 336)))
			Dim checked As Byte = If((num <> 0), 1, 0)
			Me.menuViewDebugMode.Checked = (checked <> 0)
		End Sub

		Private Sub menuEditUndo_Click(sender As Object, e As EventArgs)
			Dim undoIndex As Integer = Me.UndoIndex
			If undoIndex > 0 Then
				Dim num As Integer = undoIndex - 1
				Me.UndoIndex = num
				<Module>.GStream.Reset(num * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))))
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Void*,GStream*), <Module>.IEngine, Me.PEffectData, Me.UndoIndex * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 232)))
				Dim gMeasures As GMeasures
				Me.EffectPropTree.SetVariableNoReset(Me.PEffectClass, Me.PEffectData, <Module>.GMeasures.{ctor}(gMeasures, <Module>.Measures, 1F))
				Me.UpdateEffect(True)
				If Me.UndoIndex = Me.SavedIndex Then
					Me.Modified = False
					Me.UpdateWindowText()
					Me.tbEffectEditor.SetItemEnable(202, False)
					Me.menuFileSave.Enabled = False
				Else
					Me.Modified = True
					Me.tbEffectEditor.SetItemEnable(202, True)
					Me.menuFileSave.Enabled = True
				End If
				Me.UpdateWindowText()
				Me.menuEditRedo.Enabled = True
				Me.tbEffectEditor.SetItemEnable(208, True)
				If Me.UndoIndex = 0 Then
					Me.tbEffectEditor.SetItemEnable(207, False)
					Me.menuEditUndo.Enabled = False
				End If
				Dim currentCurveEditor As NCurveEditor = Me.CurrentCurveEditor
				If currentCurveEditor IsNot Nothing Then
					currentCurveEditor.Update()
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
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Void*,GStream*), <Module>.IEngine, Me.PEffectData, Me.UndoIndex * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 232)))
				Dim gMeasures As GMeasures
				Me.EffectPropTree.SetVariableNoReset(Me.PEffectClass, Me.PEffectData, <Module>.GMeasures.{ctor}(gMeasures, <Module>.Measures, 1F))
				Me.UpdateEffect(True)
				If Me.UndoIndex = Me.SavedIndex Then
					Me.Modified = False
					Me.UpdateWindowText()
					Me.tbEffectEditor.SetItemEnable(202, False)
					Me.menuFileSave.Enabled = False
				Else
					Me.Modified = True
					Me.tbEffectEditor.SetItemEnable(202, True)
					Me.menuFileSave.Enabled = True
				End If
				Me.UpdateWindowText()
				Me.menuEditUndo.Enabled = True
				Me.tbEffectEditor.SetItemEnable(207, True)
				If Me.UndoIndex = __Dereference(CType((Me.UndoArray + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) - 1 Then
					Me.tbEffectEditor.SetItemEnable(208, False)
					Me.menuEditRedo.Enabled = False
				End If
				Dim currentCurveEditor As NCurveEditor = Me.CurrentCurveEditor
				If currentCurveEditor IsNot Nothing Then
					currentCurveEditor.Update()
				End If
			End If
		End Sub

		Private Sub StartTrackEditor(curveeditor As NCurveEditor)
			Dim currentCurveEditor As NCurveEditor = Me.CurrentCurveEditor
			If currentCurveEditor IsNot Nothing Then
				Me.TrackPanel.Controls.Remove(currentCurveEditor)
				Me.CurrentCurveEditor.DisposeD3DX()
			End If
			Me.CurrentCurveEditor = curveeditor
			If curveeditor IsNot Nothing Then
				curveeditor.Dock = DockStyle.Fill
				Me.TrackPanel.Controls.Add(Me.CurrentCurveEditor)
				AddHandler Me.CurrentCurveEditor.NotifyUndoStep, AddressOf Me.EffectPropTree_ItemChanged
			End If
		End Sub

		Private Sub menuWindOff_Click(sender As Object, e As EventArgs)
			Dim gVector As GVector2 = 1F
			__Dereference((gVector + 4)) = 0F
			Dim iScene As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector2 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene, gVector, 0F, 0.5F, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 80)))
			Me.menuWindOff.Checked = True
			Me.menuWindLight.Checked = False
			Me.menuWindMedium.Checked = False
			Me.menuWindHeavy.Checked = False
		End Sub

		Private Sub menuWindLight_Click(sender As Object, e As EventArgs)
			Dim gVector As GVector2 = 1F
			__Dereference((gVector + 4)) = 0F
			Dim iScene As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector2 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene, gVector, 20F, 0.5F, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 80)))
			Me.menuWindOff.Checked = False
			Me.menuWindLight.Checked = True
			Me.menuWindMedium.Checked = False
			Me.menuWindHeavy.Checked = False
		End Sub

		Private Sub menuWindMedium_Click(sender As Object, e As EventArgs)
			Dim gVector As GVector2 = 1F
			__Dereference((gVector + 4)) = 0F
			Dim iScene As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector2 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene, gVector, 40F, 0.5F, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 80)))
			Me.menuWindOff.Checked = False
			Me.menuWindLight.Checked = False
			Me.menuWindMedium.Checked = True
			Me.menuWindHeavy.Checked = False
		End Sub

		Private Sub menuWindHeavy_Click(sender As Object, e As EventArgs)
			Dim gVector As GVector2 = 1F
			__Dereference((gVector + 4)) = 0F
			Dim iScene As __Pointer(Of GIScene) = Me.IScene
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GVector2 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), iScene, gVector, 60F, 0.5F, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 80)))
			Me.menuWindOff.Checked = False
			Me.menuWindLight.Checked = False
			Me.menuWindMedium.Checked = False
			Me.menuWindHeavy.Checked = True
		End Sub

		Protected Sub raise_PEffectChanged(i1 As __Pointer(Of SByte))
			Dim pEffectChanged As NEffectEditor.__Delegate_PEffectChanged = Me.PEffectChanged
			If pEffectChanged IsNot Nothing Then
				pEffectChanged(i1)
			End If
		End Sub
	End Class
End Namespace
