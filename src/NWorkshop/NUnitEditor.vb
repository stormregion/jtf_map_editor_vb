Imports NControls
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NUnitEditor
		Inherits Form

		Public Delegate Sub __Delegate_PUnitChanged( As __Pointer(Of SByte))

		Protected PUnitContainer As __Pointer(Of GPUnitContainer)

		Protected ToolWindows As ArrayList

		Protected ToolWindowIdx As Integer

		Protected FileDialog As NFileDialog

		Protected FileName As String

		Protected Modified As Boolean

		Private menuUnitEditor As MainMenu

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

		Private menuItem1 As MenuItem

		Private menuItem2 As MenuItem

		Private panel1 As Panel

		Private components As IContainer

		Private tbMain As Toolbar

		Private UnitPropTree As PropertyTree

		Private UndoArray As __Pointer(Of GArray<GStreamBuffer>)

		Private UndoIndex As Integer

		Private SavedIndex As Integer

		Private PUnitNameToLoad As String

		Public Custom Event PUnitChanged As NUnitEditor.__Delegate_PUnitChanged
			AddHandler
				Me.PUnitChanged = [Delegate].Combine(Me.PUnitChanged, value)
			End AddHandler
			RemoveHandler
				Me.PUnitChanged = [Delegate].Remove(Me.PUnitChanged, value)
			End RemoveHandler
		End Event

		Public Sub New(toolwindows As ArrayList, punit_name As String, clipboard As __Pointer(Of NPropertyClipboard))
			Me.PUnitChanged = Nothing
			Me.InitializeComponent()
			If punit_name IsNot Nothing AndAlso punit_name.Length > 0 Then
				Me.PUnitNameToLoad = punit_name
			Else
				Me.PUnitNameToLoad = Nothing
			End If
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?4???0NUnitEditor@NWorkshop@@Q$AAM@P$AAVArrayList@Collections@System@@P$AAVString@5@PAUNPropertyClipboard@NControls@@@Z@4PAUGToolbarItem@8@A), __Pointer(Of GToolbarItem)), 24)
			Me.tbMain = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.tbMain.ButtonClick, AddressOf Me.tbUnitEditor_ButtonClick
			MyBase.Controls.Add(Me.tbMain)
			Dim propertyTree As PropertyTree = New PropertyTree(2, NewAssetPicker.ObjectType.UnitEditor, clipboard)
			Me.UnitPropTree = propertyTree
			Me.panel1.Controls.Add(propertyTree)
			Me.UnitPropTree.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.UnitPropTree.Location = location
			Me.UnitPropTree.Name = "UnitPropTree"
			Dim size As Size = New Size(250, 435)
			Me.UnitPropTree.Size = size
			Me.UnitPropTree.TabIndex = 0
			Me.UnitPropTree.Text = "UnitPropTree"
			AddHandler Me.UnitPropTree.ItemChanged, AddressOf Me.UnitPropTree_ItemChanged
			Me.ToolWindows = toolwindows
			toolwindows.Add(Me)
			Dim ptr As __Pointer(Of GPUnitContainer) = <Module>.new(12UI)
			Dim ptr2 As __Pointer(Of GPUnitContainer)
			Try
				If ptr IsNot Nothing Then
					__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr + 4 / __SizeOf(GPUnitContainer)), __Pointer(Of Integer))) = 0
					Try
						__Dereference(CType((ptr + 8 / __SizeOf(GPUnitContainer)), __Pointer(Of Integer))) = 0
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType(ptr, __Pointer(Of Void)))
						Throw
					End Try
					ptr2 = ptr
				Else
					ptr2 = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.PUnitContainer = ptr2
			__Dereference((ptr2 + 8)) = 0
			Me.FileName = ""
			Me.Modified = False
			Me.UpdateWindowText()
			Me.tbMain.SetItemEnable(203, False)
			Me.tbMain.SetItemEnable(204, False)
			Me.tbMain.SetItemEnable(205, False)
			Me.tbMain.SetItemEnable(206, False)
			Me.tbMain.SetItemEnable(207, False)
			Me.tbMain.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = False
			Me.menuEditRedo.Enabled = False
			Dim ptr3 As __Pointer(Of GArray<GStreamBuffer>) = <Module>.new(12UI)
			Dim undoArray As __Pointer(Of GArray<GStreamBuffer>)
			Try
				If ptr3 IsNot Nothing Then
					__Dereference(CType(ptr3, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr3 + 4 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr3 + 8 / __SizeOf(GArray<GStreamBuffer>)), __Pointer(Of Integer))) = 0
					undoArray = ptr3
				Else
					undoArray = 0
				End If
			Catch 
				<Module>.delete(CType(ptr3, __Pointer(Of Void)))
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
			Me.menuUnitEditor = New MainMenu()
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
			Me.menuItem1 = New MenuItem()
			Me.menuItem2 = New MenuItem()
			MyBase.SuspendLayout()
			Me.panel1.BorderStyle = BorderStyle.Fixed3D
			Me.panel1.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.panel1.Location = location
			Me.panel1.Name = "panel1"
			Dim size As Size = New Size(408, 721)
			Me.panel1.Size = size
			Me.panel1.TabIndex = 0
			Dim items As MenuItem() = New MenuItem() { Me.menuFile, Me.menuEdit, Me.menuItem1 }
			Me.menuUnitEditor.MenuItems.AddRange(items)
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
			Dim clientSize As Size = New Size(408, 721)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.panel1)
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			MyBase.Menu = Me.menuUnitEditor
			MyBase.Name = "NUnitEditor"
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Unit Editor"
			AddHandler MyBase.Closing, AddressOf Me.UnitEditor_Closing
			AddHandler MyBase.Load, AddressOf Me.UnitEditor_Load
			AddHandler MyBase.Closed, AddressOf Me.UnitEditor_Closed
			MyBase.ResumeLayout(False)
		End Sub

		Private Function SaveDocumentIfChanged() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			If Not Me.Modified Then
				Return True
			End If
			Dim dialogResult As DialogResult = MessageBox.Show("The unit has been modified since the last save." & vbLf & "Do you want to save?", "Save Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
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
			Dim num As UInteger = CUInt((__Dereference(CType((Me.PUnitContainer + 8 / __SizeOf(GPUnitContainer)), __Pointer(Of Integer)))))
			If num <> 0UI Then
				Dim expr_0E As UInteger = num
				Dim expr_18 As UInteger = expr_0E + CUInt((__Dereference((__Dereference((expr_0E + 4UI)) + 4)))) + 4UI
				Dim arg_22_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_18, __Dereference((__Dereference(expr_18) + 4)))
				__Dereference(CType((Me.PUnitContainer + 8 / __SizeOf(GPUnitContainer)), __Pointer(Of Integer))) = 0
			End If
		End Sub

		Private Sub NewDocument(filename As String)
			Me.DiscardDocument()
			If filename.Length > 0 Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, filename)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					<Module>.GUnitRegistry.LoadUnitFile(If((num = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num), Me.PUnitContainer)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
					gBaseString<char> = 0
				End If
				Dim gBaseString<char>2 As GBaseString<char>
				Dim src As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, filename)
				Try
					<Module>.GBaseString<char>.=(Me.PUnitContainer, src)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
					gBaseString<char>2 = 0
				End If
			Else
				__Dereference(CType((Me.PUnitContainer + 8 / __SizeOf(GPUnitContainer)), __Pointer(Of Integer))) = 0
			End If
			Me.UnitPropTree.SetVariable(AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
			Me.UnitPropTree.Focus()
			<Module>.GArray<GStreamBuffer>.Clear(Me.UndoArray, 0)
			Dim num2 As Integer = <Module>.GArray<GStreamBuffer>.Add(Me.UndoArray)
			Me.UndoIndex = num2
			<Module>.GRTTI.SaveVariablesAsText(num2 * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
			Me.SavedIndex = Me.UndoIndex
			Me.FileName = String.Empty
			Me.Modified = False
			Me.UpdateWindowText()
			Me.tbMain.SetItemEnable(207, False)
			Me.tbMain.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = False
			Me.menuEditRedo.Enabled = False
		End Sub

		Private Sub OpenDocument(filepathname As String)
			Me.DiscardDocument()
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, filepathname)
			Try
				Dim num As UInteger = CUInt((__Dereference(ptr)))
				<Module>.GUnitRegistry.LoadUnitFile(If((num = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num), Me.PUnitContainer)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Me.UnitPropTree.SetVariable(AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
			Me.UnitPropTree.Focus()
			<Module>.GArray<GStreamBuffer>.Clear(Me.UndoArray, 0)
			Dim num2 As Integer = <Module>.GArray<GStreamBuffer>.Add(Me.UndoArray)
			Me.UndoIndex = num2
			<Module>.GRTTI.SaveVariablesAsText(num2 * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
			Me.SavedIndex = Me.UndoIndex
			Me.FileName = filepathname
			Me.Modified = False
			Me.UpdateWindowText()
			Me.tbMain.SetItemEnable(207, False)
			Me.tbMain.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = False
			Me.menuEditRedo.Enabled = False
		End Sub

		Private Sub SaveDocument()
			Dim gBaseString<char> As GBaseString<char>
			<Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.FileName)
			Try
				If <Module>.GUnitRegistry.SaveUnitFile(If((gBaseString<char> Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>), Me.PUnitContainer) IsNot Nothing Then
					Me.SavedIndex = Me.UndoIndex
					Me.Modified = False
					Me.UpdateWindowText()
					<Module>.GUnitRegistry.ReloadPUnits(<Module>.UnitRegistry)
					Dim ptr As __Pointer(Of SByte)
					If gBaseString<char> IsNot Nothing Then
						ptr = gBaseString<char>
					Else
						ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gPath As GPath
					<Module>.GPath.{ctor}(gPath, ptr)
					Try
						Dim num As Integer = 0
						If 0 < __Dereference((gPath + 16)) Then
							While <Module>.GBaseString<char>.Compare(num * 8 + __Dereference((gPath + 12)), CType((AddressOf <Module>.??_C@_05CCBEFJDC@units?$AA@), __Pointer(Of SByte)), False) IsNot Nothing
								num += 1
								If num >= __Dereference((gPath + 16)) Then
									Exit While
								End If
							End While
						End If
						Dim ptr2 As __Pointer(Of SByte) = CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte))
						Dim b As SByte
						Do
							b = __Dereference(CType(ptr2, __Pointer(Of SByte)))
							ptr2 += 1 / __SizeOf(SByte)
						Loop While b <> 0
						__Dereference((gBaseString<char> + 4)) = ptr2 - <Module>.??_C@_00CNPNBAHC@?$AA@ / __SizeOf(SByte) - 1 / __SizeOf(SByte)
						Dim num2 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num2)
						cpblk(gBaseString<char>, <Module>.??_C@_00CNPNBAHC@?$AA@, num2)
						If num < __Dereference((gPath + 16)) - 1 Then
							Do
								Dim gBaseString<char>2 As GBaseString<char>
								Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(num * 8 + __Dereference((gPath + 12)), AddressOf gBaseString<char>2, CType((AddressOf <Module>.??_C@_01KMDKNFGN@?1?$AA@), __Pointer(Of SByte)))
								Try
									Dim num3 As Integer = __Dereference(CType((ptr3 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer)))
									If num3 <> 0 Then
										gBaseString<char> = <Module>.realloc(gBaseString<char>, CUInt((__Dereference((gBaseString<char> + 4)) + num3 + 1)))
										cpblk(__Dereference((gBaseString<char> + 4)) + gBaseString<char>, __Dereference(CType(ptr3, __Pointer(Of Integer))), __Dereference(CType((ptr3 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) + 1)
										__Dereference((gBaseString<char> + 4)) = __Dereference(CType((ptr3 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) + __Dereference((gBaseString<char> + 4))
									End If
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
									Throw
								End Try
								If gBaseString<char>2 IsNot Nothing Then
									<Module>.free(gBaseString<char>2)
									gBaseString<char>2 = 0
								End If
								num += 1
							Loop While num < __Dereference((gPath + 16)) - 1
						End If
						Dim ptr4 As __Pointer(Of GBaseString<char>) = __Dereference((gPath + 16)) * 8 + __Dereference((gPath + 12)) - 8
						Dim num4 As Integer = __Dereference((ptr4 + 4))
						If num4 <> 0 Then
							gBaseString<char> = <Module>.realloc(gBaseString<char>, CUInt((__Dereference((gBaseString<char> + 4)) + num4 + 1)))
							cpblk(__Dereference((gBaseString<char> + 4)) + gBaseString<char>, __Dereference(ptr4), __Dereference((ptr4 + 4)) + 1)
							__Dereference((gBaseString<char> + 4)) = __Dereference((ptr4 + 4)) + __Dereference((gBaseString<char> + 4))
						End If
						Dim i As __Pointer(Of SByte)
						If gBaseString<char> IsNot Nothing Then
							i = gBaseString<char>
						Else
							i = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.raise_PUnitChanged(i)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
						Throw
					End Try
					Try
						<Module>.GArray<GBaseString<char> >.{dtor}(gPath + 12)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
						Throw
					End Try
					If gPath IsNot Nothing Then
						<Module>.free(gPath)
					End If
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
		End Sub

		Private Sub UnitPropTree_ItemChanged()
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
			<Module>.GRTTI.SaveVariablesAsText(num3 * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
			If Me.UndoIndex <= Me.SavedIndex Then
				Me.SavedIndex = 0
			End If
			Me.Modified = True
			Me.tbMain.SetItemEnable(207, True)
			Me.tbMain.SetItemEnable(208, False)
			Me.menuEditUndo.Enabled = True
			Me.menuEditRedo.Enabled = False
			Me.UpdateWindowText()
		End Sub

		Private Sub UnitEditor_Load(sender As Object, e As EventArgs)
			Dim pUnitNameToLoad As String = Me.PUnitNameToLoad
			If pUnitNameToLoad IsNot Nothing Then
				Me.OpenDocument(pUnitNameToLoad)
			Else
				Me.menuFileNew_Click(sender, e)
			End If
		End Sub

		Private Sub UnitEditor_Closing(sender As Object, e As CancelEventArgs)
			If Not Me.SaveDocumentIfChanged() Then
				e.Cancel = True
			End If
		End Sub

		Private Sub UnitEditor_Closed(sender As Object, e As EventArgs)
			Dim toolWindows As ArrayList = Me.ToolWindows
			If toolWindows IsNot Nothing Then
				toolWindows.Remove(Me)
			End If
			Dim num As UInteger = CUInt((__Dereference(CType((Me.PUnitContainer + 8 / __SizeOf(GPUnitContainer)), __Pointer(Of Integer)))))
			If num <> 0UI Then
				Dim expr_1F As UInteger = num
				Dim expr_29 As UInteger = expr_1F + CUInt((__Dereference((__Dereference((expr_1F + 4UI)) + 4)))) + 4UI
				Dim arg_33_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_29, __Dereference((__Dereference(expr_29) + 4)))
				__Dereference(CType((Me.PUnitContainer + 8 / __SizeOf(GPUnitContainer)), __Pointer(Of Integer))) = 0
			End If
			Dim undoArray As __Pointer(Of GArray<GStreamBuffer>) = Me.UndoArray
			If undoArray IsNot Nothing Then
				Dim ptr As __Pointer(Of GArray<GStreamBuffer>) = undoArray
				<Module>.GArray<GStreamBuffer>.{dtor}(ptr)
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Me.UndoArray = Nothing
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
			Me.Text = str2 + str + " - Unit Editor"
		End Sub

		Private Sub menuFileNew_Click(sender As Object, e As EventArgs)
			Me.tbMain.Focus()
			If Me.SaveDocumentIfChanged() Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 56, True)
				Me.FileDialog = nFileDialog
				nFileDialog.SetTypeToUnitEditor()
				Me.FileDialog.DefaultExtension = "unit"
				Me.FileDialog.AvailableModes = 11
				Me.FileDialog.SelectedMode = 1
				Me.FileDialog.FileName = ""
				If Me.FileDialog.ShowDialog() = DialogResult.OK Then
					Dim fileDialog As NFileDialog = Me.FileDialog
					If fileDialog.SelectedMode = 1 Then
						Me.NewDocument(fileDialog.NewUnitFileName)
					Else
						Me.OpenDocument(fileDialog.FilePath)
						Me.FileDialog.UpdateRecentFiles()
						<Module>.SaveOptions()
					End If
				End If
			End If
		End Sub

		Private Sub menuFileOpen_Click(sender As Object, e As EventArgs)
			Me.tbMain.Focus()
			If Me.SaveDocumentIfChanged() Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 56, True)
				Me.FileDialog = nFileDialog
				nFileDialog.SetTypeToUnitEditor()
				Me.FileDialog.DefaultExtension = "unit"
				Me.FileDialog.AvailableModes = 11
				Me.FileDialog.SelectedMode = 2
				Me.FileDialog.FileName = ""
				If Me.FileDialog.ShowDialog() = DialogResult.OK Then
					Dim fileDialog As NFileDialog = Me.FileDialog
					If fileDialog.SelectedMode = 1 Then
						Me.NewDocument(fileDialog.NewUnitFileName)
					Else
						Me.OpenDocument(fileDialog.FilePath)
						Me.FileDialog.UpdateRecentFiles()
						<Module>.SaveOptions()
					End If
				End If
			End If
		End Sub

		Private Sub menuFileOpenRecent_Click(sender As Object, e As EventArgs)
			Me.tbMain.Focus()
			If Me.SaveDocumentIfChanged() Then
				Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 56, True)
				Me.FileDialog = nFileDialog
				nFileDialog.SetTypeToUnitEditor()
				Me.FileDialog.DefaultExtension = "unit"
				Me.FileDialog.AvailableModes = 11
				Me.FileDialog.SelectedMode = 8
				Me.FileDialog.FileName = ""
				If Me.FileDialog.ShowDialog() = DialogResult.OK Then
					Dim fileDialog As NFileDialog = Me.FileDialog
					If fileDialog.SelectedMode = 1 Then
						Me.NewDocument(fileDialog.NewUnitFileName)
					Else
						Me.OpenDocument(fileDialog.FilePath)
						Me.FileDialog.UpdateRecentFiles()
						<Module>.SaveOptions()
					End If
				End If
			End If
		End Sub

		Private Sub menuFileSave_Click(sender As Object, e As EventArgs)
			Me.tbMain.Focus()
			Me.UnitPropTree.Focus()
			If Me.FileName.Length = 0 Then
				Me.menuFileSaveAs_Click(sender, e)
			Else
				Me.SaveDocument()
			End If
		End Sub

		Private Sub menuFileSaveAs_Click(sender As Object, e As EventArgs)
			Me.tbMain.Focus()
			Me.UnitPropTree.Focus()
			Dim nFileDialog As NFileDialog = New NFileDialog(<Module>.Options + 56, True)
			Me.FileDialog = nFileDialog
			nFileDialog.DefaultExtension = "unit"
			Me.FileDialog.AvailableModes = 12
			Me.FileDialog.SelectedMode = 4
			If Me.FileDialog.ShowDialog() = DialogResult.OK Then
				Me.FileName = Me.FileDialog.FilePath
				Me.SaveDocument()
				Me.FileDialog.UpdateRecentFiles()
				<Module>.SaveOptions()
			End If
		End Sub

		Private Sub menuFileClose_Click(sender As Object, e As EventArgs)
			MyBase.Close()
		End Sub

		Private Sub tbUnitEditor_ButtonClick(idx As Integer, radio_group As Integer)
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

		Private Sub menuEditUndo_Click(sender As Object, e As EventArgs)
			Dim undoIndex As Integer = Me.UndoIndex
			If undoIndex > 0 Then
				Dim num As Integer = undoIndex - 1
				Me.UndoIndex = num
				<Module>.GStream.Reset(num * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))))
				<Module>.GRTTI.LoadVariablesAsText(Me.UndoIndex * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
				Me.UnitPropTree.SetVariable(AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
				If Me.UndoIndex = Me.SavedIndex Then
					Me.Modified = False
					Me.UpdateWindowText()
				Else
					Me.Modified = True
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
				<Module>.GRTTI.LoadVariablesAsText(Me.UndoIndex * 36 + __Dereference(CType(Me.UndoArray, __Pointer(Of Integer))), AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
				Me.UnitPropTree.SetVariable(AddressOf <Module>.GRTT_Unit.Class_GPUnitContainer, CType(Me.PUnitContainer, __Pointer(Of Void)), <Module>.Measures)
				If Me.UndoIndex = Me.SavedIndex Then
					Me.Modified = False
					Me.UpdateWindowText()
				Else
					Me.Modified = True
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
			Dim pUnitChanged As NUnitEditor.__Delegate_PUnitChanged = Me.PUnitChanged
			If pUnitChanged IsNot Nothing Then
				pUnitChanged(i1)
			End If
		End Sub
	End Class
End Namespace
