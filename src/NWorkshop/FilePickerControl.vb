Imports <CppImplementationDetails>
Imports NControls
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class FilePickerControl
		Inherits UserControl

		Public Delegate Sub FilePickedHandler(FileName As String)

		Public Delegate Sub ContextMenuPopupHandler(FileName As String)

		Public Enum Mode
			Composite = 2
			Treeview = 1
			Thumbnail = 0
		End Enum

		Public Enum ItemType
			Fileitem = 2
			Updiritem = 1
			Diritem = 0
		End Enum

		Private MainPanel As Panel

		Private Thumbnails As ImageList

		Private TreeViewIcons As ImageList

		Private CmpSplitter As Splitter

		Private menuItemRefreshTN As MenuItem

		Private ThumbContextMenu As ContextMenu

		Private TreeContextMenu As ContextMenu

		Private components As IContainer

		Private LastCompositeHeight As Integer

		Private ThumbList As ListView

		Private DirectoryTree As TreeView

		Private FPTools As Toolbar

		Private RootP As String

		Private Current As String

		Private ThumbRootVal As String

		Private ThumbRootP As String

		Private FileP As String

		Private ExtensionsP As String()

		Private ModeP As FilePickerControl.Mode

		Private ThumbTypeP As ThumbnailServer.ThumbType

		Private ThumbnailIndices As Hashtable

		Private ThumbsSrvr As ThumbnailServer

		Private ThumbnailTooltip As ToolTip

		Private IconsSrvr As ImageServer

		Private initialized As Boolean

		Private LastTTIndx As Integer

		Private RestrictMouseEvents As Boolean

		Private FilterNonEditableUnitsP As Boolean

		Private Shared MViewer As Process = Nothing

		Public Custom Event ContextPopup As FilePickerControl.ContextMenuPopupHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.ContextPopup = [Delegate].Combine(Me.ContextPopup, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.ContextPopup = [Delegate].Remove(Me.ContextPopup, value)
			End RemoveHandler
		End Event

		Public Custom Event DoubleClickSelection As FilePickerControl.FilePickedHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.DoubleClickSelection = [Delegate].Combine(Me.DoubleClickSelection, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.DoubleClickSelection = [Delegate].Remove(Me.DoubleClickSelection, value)
			End RemoveHandler
		End Event

		Public Custom Event SingleClickSelection As FilePickerControl.FilePickedHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.SingleClickSelection = [Delegate].Combine(Me.SingleClickSelection, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.SingleClickSelection = [Delegate].Remove(Me.SingleClickSelection, value)
			End RemoveHandler
		End Event

		Public WriteOnly Property FilterNonEditableUnits() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				Me.FilterNonEditableUnitsP = value
			End Set
		End Property

		Public WriteOnly Property AddittionalContextMenu() As Menu
			Set(value As Menu)
				Me.ThumbContextMenu.MenuItems.Clear()
				Me.ThumbContextMenu.MenuItems.Add(Me.menuItemRefreshTN)
				Me.TreeContextMenu.MenuItems.Clear()
				If value IsNot Nothing Then
					Me.ThumbContextMenu.MenuItems.Add("-")
					Me.ThumbContextMenu.MergeMenu(value)
					Me.TreeContextMenu.MenuItems.Add("-")
					Me.TreeContextMenu.MergeMenu(value)
				End If
			End Set
		End Property

		Public Property ThumbMode() As ThumbnailServer.ThumbType
			Get
				Return Me.ThumbTypeP
			End Get
			Set(value As ThumbnailServer.ThumbType)
				Me.ThumbTypeP = value
			End Set
		End Property

		Public Property ViewMode() As FilePickerControl.Mode
			Get
				Return Me.ModeP
			End Get
			Set(value As FilePickerControl.Mode)
				Me.ModeP = value
				If Me.initialized Then
					Me.CommonInitLogics()
				End If
			End Set
		End Property

		Public Property Extensions() As String()
			Get
				Return Me.ExtensionsP
			End Get
			Set(value As String())
				Me.ExtensionsP = value
			End Set
		End Property

		Public ReadOnly Property File() As String
			Get
				Return Me.FileP
			End Get
		End Property

		Public Property ThumbRoot() As String
			Get
				Return Me.ThumbRootVal
			End Get
			Set(value As String)
				Me.ThumbRootVal = value
				Me.ThumbRootP = value
				If value.Length > 0 Then
					Me.ThumbRootP += "/"
				End If
			End Set
		End Property

		Public Property Root() As String
			Get
				Return Me.RootP
			End Get
			Set(value As String)
				Me.RootP = value
			End Set
		End Property

		Public Sub New()
			Me.SingleClickSelection = Nothing
			Me.DoubleClickSelection = Nothing
			Me.ContextPopup = Nothing
			Me.RootP = ""
			Me.Current = ""
			Me.FileP = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.ExtensionsP = Nothing
			Me.ModeP = FilePickerControl.Mode.Thumbnail
			Me.ThumbnailIndices = New Hashtable()
			Me.InitializeComponent()
			Me.initialized = False
			Me.ThumbsSrvr = Nothing
			Me.ThumbTypeP = ThumbnailServer.ThumbType.Model
			Me.IconsSrvr = ImageServer.GetImageServer("Images")
			Me.LastTTIndx = -1
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0FilePickerControl@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Me.FPTools = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.FPTools.ButtonClick, AddressOf Me.FPTools_ButtonClick
			Dim size As Size = New Size(MyBase.Size.Width, 32)
			Me.FPTools.Size = size
			MyBase.Controls.Add(Me.FPTools)
			Me.LastCompositeHeight = Me.MainPanel.Size.Height / 2 - 4
			Me.RestrictMouseEvents = False
			Me.FilterNonEditableUnitsP = True
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing Then
				Dim thumbsSrvr As ThumbnailServer = Me.ThumbsSrvr
				If thumbsSrvr IsNot Nothing Then
					thumbsSrvr.Dispose()
				End If
				Dim container As IContainer = Me.components
				If container IsNot Nothing Then
					container.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
			Me.components = New Container()
			Me.MainPanel = New Panel()
			Me.Thumbnails = New ImageList(Me.components)
			Me.TreeViewIcons = New ImageList(Me.components)
			Me.ThumbContextMenu = New ContextMenu()
			Me.menuItemRefreshTN = New MenuItem()
			Me.TreeContextMenu = New ContextMenu()
			MyBase.SuspendLayout()
			Me.MainPanel.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim location As Point = New Point(0, 32)
			Me.MainPanel.Location = location
			Me.MainPanel.Name = "MainPanel"
			Dim size As Size = New Size(256, 288)
			Me.MainPanel.Size = size
			Me.MainPanel.TabIndex = 3
			Me.Thumbnails.ColorDepth = ColorDepth.Depth32Bit
			Dim imageSize As Size = New Size(64, 64)
			Me.Thumbnails.ImageSize = imageSize
			Dim magenta As Color = Color.Magenta
			Me.Thumbnails.TransparentColor = magenta
			Me.TreeViewIcons.ColorDepth = ColorDepth.Depth24Bit
			Dim imageSize2 As Size = New Size(16, 16)
			Me.TreeViewIcons.ImageSize = imageSize2
			Dim magenta2 As Color = Color.Magenta
			Me.TreeViewIcons.TransparentColor = magenta2
			Dim items As MenuItem() = New MenuItem() { Me.menuItemRefreshTN }
			Me.ThumbContextMenu.MenuItems.AddRange(items)
			AddHandler Me.ThumbContextMenu.Popup, AddressOf Me.ContextMenu_Popup
			Me.menuItemRefreshTN.Index = 0
			Me.menuItemRefreshTN.Text = "Refresh thumbnail"
			AddHandler Me.menuItemRefreshTN.Click, AddressOf Me.menuItemRefreshTN_Click
			AddHandler Me.TreeContextMenu.Popup, AddressOf Me.ContextMenu_Popup
			MyBase.Controls.Add(Me.MainPanel)
			MyBase.Name = "FilePickerControl"
			Dim size2 As Size = New Size(256, 320)
			MyBase.Size = size2
			AddHandler MyBase.Load, AddressOf Me.OnLoad
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub InitTreeView()
			Dim treeView As TreeView = New TreeView()
			Me.DirectoryTree = treeView
			treeView.BorderStyle = BorderStyle.Fixed3D
			Me.DirectoryTree.PathSeparator = "/"
			Me.DirectoryTree.ShowLines = False
			Me.DirectoryTree.ShowPlusMinus = False
			Me.DirectoryTree.ShowRootLines = False
			Me.DirectoryTree.ImageList = Me.TreeViewIcons
			Dim image As Image = Me.IconsSrvr.GetImage("Folder_16", KnownColor.Window)
			If image IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image)
			End If
			Dim image2 As Image = Me.IconsSrvr.GetImage("Folder_Up_16", KnownColor.Window)
			If image2 IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image2)
			End If
			Dim image3 As Image = Me.IconsSrvr.GetImage("Object_16", KnownColor.Window)
			If image3 IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image3)
			End If
			Dim image4 As Image = Me.IconsSrvr.GetImage("Effect_16", KnownColor.Window)
			If image4 IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image4)
			End If
			Dim image5 As Image = Me.IconsSrvr.GetImage("Material_16", KnownColor.Window)
			If image5 IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image5)
			End If
			Dim image6 As Image = Me.IconsSrvr.GetImage("Sound_16", KnownColor.Window)
			If image6 IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image6)
			End If
			Dim image7 As Image = Me.IconsSrvr.GetImage("Unit_16", KnownColor.Window)
			If image7 IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image7)
			End If
			Dim image8 As Image = Me.IconsSrvr.GetImage("Water_16", KnownColor.Window)
			If image8 IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image8)
			End If
			Dim image9 As Image = Me.IconsSrvr.GetImage("Map_16", KnownColor.Window)
			If image9 IsNot Nothing Then
				Me.TreeViewIcons.Images.Add(image9)
			End If
			Me.DirectoryTree.HideSelection = False
			AddHandler Me.DirectoryTree.DoubleClick, AddressOf Me.TreeItem_DblClick
			AddHandler Me.DirectoryTree.MouseDown, AddressOf Me.TreeItem_SingleClick
			AddHandler Me.DirectoryTree.MouseUp, AddressOf Me.TreeviewMouseUp
			AddHandler Me.DirectoryTree.BeforeSelect, AddressOf Me.TreeItemSelection
			Me.DirectoryTree.TabIndex = 5
			Me.DirectoryTree.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.DirectoryTree.Name = "TreeBrowser"
		End Sub

		Private Sub InitThumbView()
			Dim listView As ListView = New ListView()
			Me.ThumbList = listView
			listView.BorderStyle = BorderStyle.Fixed3D
			Me.ThumbList.View = View.LargeIcon
			Me.ThumbList.Font = New Font("Arial", 0.1F, GraphicsUnit.Pixel)
			Me.ThumbList.LargeImageList = Me.Thumbnails
			Dim image As Image = Me.IconsSrvr.GetImage("Folder_64", KnownColor.Window)
			If image IsNot Nothing Then
				Me.Thumbnails.Images.Add(image)
			End If
			Dim image2 As Image = Me.IconsSrvr.GetImage("Folder_Up_64", KnownColor.Window)
			If image2 IsNot Nothing Then
				Me.Thumbnails.Images.Add(image2)
			End If
			Dim image3 As Image = Me.IconsSrvr.GetImage("Unknown_64", KnownColor.Window)
			If image3 IsNot Nothing Then
				Me.Thumbnails.Images.Add(image3)
			End If
			Dim image4 As Image = Me.IconsSrvr.GetImage("Effect_64", KnownColor.Window)
			If image4 IsNot Nothing Then
				Me.Thumbnails.Images.Add(image4)
			End If
			Dim image5 As Image = Me.IconsSrvr.GetImage("Sound_64", KnownColor.Window)
			If image5 IsNot Nothing Then
				Me.Thumbnails.Images.Add(image5)
			End If
			Dim image6 As Image = Me.IconsSrvr.GetImage("Water_64", KnownColor.Window)
			If image6 IsNot Nothing Then
				Me.Thumbnails.Images.Add(image6)
			End If
			Dim image7 As Image = Me.IconsSrvr.GetImage("Map_64", KnownColor.Window)
			If image7 IsNot Nothing Then
				Me.Thumbnails.Images.Add(image7)
			End If
			Me.ThumbList.HideSelection = False
			Me.ThumbList.LabelWrap = False
			AddHandler Me.ThumbList.DoubleClick, AddressOf Me.ListItem_DblClick
			AddHandler Me.ThumbList.Click, AddressOf Me.ListItem_SingleClick
			AddHandler Me.ThumbList.MouseUp, AddressOf Me.ThumbviewMouseUp
			AddHandler Me.ThumbList.MouseDown, AddressOf Me.ThumbviewMouseDown
			Dim toolTip As ToolTip = New ToolTip()
			Me.ThumbnailTooltip = toolTip
			toolTip.AutoPopDelay = 0
			Me.ThumbnailTooltip.InitialDelay = 0
			Me.ThumbnailTooltip.ReshowDelay = 0
			Me.ThumbnailTooltip.SetToolTip(Me.ThumbList, "")
			Me.ThumbnailTooltip.ShowAlways = True
			AddHandler Me.ThumbList.MouseMove, AddressOf Me.MouseMove
			AddHandler Me.ThumbList.MouseWheel, AddressOf Me.MouseMove
			Me.ThumbList.TabIndex = 6
			Me.ThumbList.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.ThumbList.Name = "ThumbView"
		End Sub

		Private Sub CommonInitLogics()
			If Me.ModeP <> FilePickerControl.Mode.Treeview Then
				Dim thumbTypeP As ThumbnailServer.ThumbType = Me.ThumbTypeP
				If thumbTypeP <> ThumbnailServer.ThumbType.Effect AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Sound AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Box AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Fluid AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Cloud Then
					Me.FPTools.SetItemEnable(5, True)
					GoTo IL_4B
				End If
			End If
			Me.FPTools.SetItemEnable(5, False)
			IL_4B:
			MyBase.SuspendLayout()
			Me.MainPanel.Controls.Clear()
			Dim modeP As FilePickerControl.Mode = Me.ModeP
			If modeP <> FilePickerControl.Mode.Thumbnail Then
				If modeP <> FilePickerControl.Mode.Treeview Then
					If modeP = FilePickerControl.Mode.Composite Then
						Me.FPTools.SetItemEnable(1, False)
						Me.FPTools.SetItemPushed(4, True)
						Dim size As Size = New Size(Me.MainPanel.Size.Width, Me.LastCompositeHeight)
						Me.DirectoryTree.Size = size
						Me.MainPanel.Controls.Add(Me.ThumbList)
						Me.MainPanel.Controls.Add(Me.CmpSplitter)
						Me.MainPanel.Controls.Add(Me.DirectoryTree)
						Me.DirectoryTree.Dock = DockStyle.Top
						Me.CmpSplitter.Dock = DockStyle.Top
						Me.ThumbList.Dock = DockStyle.Fill
						Me.DirectoryTree.Nodes.Clear()
					End If
				Else
					Me.FPTools.SetItemEnable(1, False)
					Me.FPTools.SetItemPushed(3, True)
					Dim location As Point = New Point(0, 0)
					Me.DirectoryTree.Location = location
					Dim size2 As Size = Me.MainPanel.Size
					Me.DirectoryTree.Size = size2
					Me.MainPanel.Controls.Add(Me.DirectoryTree)
					Me.DirectoryTree.Dock = DockStyle.Fill
					Me.DirectoryTree.Nodes.Clear()
				End If
			Else
				Me.FPTools.SetItemEnable(1, True)
				Me.FPTools.SetItemPushed(2, True)
				Dim location2 As Point = New Point(0, 0)
				Me.ThumbList.Location = location2
				Dim size3 As Size = Me.MainPanel.Size
				Me.ThumbList.Size = size3
				Me.MainPanel.Controls.Add(Me.ThumbList)
				Me.ThumbList.Dock = DockStyle.Fill
			End If
			Me.initialized = True
			Me.FillData()
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub FillData()
			Dim modeP As FilePickerControl.Mode = Me.ModeP
			If modeP <> FilePickerControl.Mode.Thumbnail Then
				If modeP <> FilePickerControl.Mode.Treeview Then
					If modeP = FilePickerControl.Mode.Composite Then
						Me.FillTreeWData()
						Me.FillListWData()
					End If
				Else
					Me.FillTreeWData()
				End If
			Else
				Me.FillListWData()
			End If
		End Sub

		Private Sub FillListWData()
			Dim gBaseString<char> As GBaseString<char> = 0
			__Dereference((gBaseString<char> + 4)) = 0
			Try
				If Me.Current.Length > 0 Then
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, Me.Root + "/" + Me.Current + "/*")
					Try
						Dim num As Integer = __Dereference((ptr + 4))
						If num <> 0 Then
							__Dereference((gBaseString<char> + 4)) = num
							Dim num2 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
							gBaseString<char> = <Module>.realloc(Nothing, num2)
							cpblk(gBaseString<char>, __Dereference(ptr), num2)
						Else
							__Dereference((gBaseString<char> + 4)) = 0
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
						gBaseString<char>2 = 0
					End If
				Else
					Dim gBaseString<char>3 As GBaseString<char>
					Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, Me.Root + "/*")
					Try
						Dim num3 As Integer = __Dereference((ptr2 + 4))
						If num3 <> 0 Then
							__Dereference((gBaseString<char> + 4)) = num3
							Dim num4 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
							gBaseString<char> = <Module>.realloc(Nothing, num4)
							cpblk(gBaseString<char>, __Dereference(ptr2), num4)
						Else
							__Dereference((gBaseString<char> + 4)) = 0
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
				Dim gFoundFiles As GFoundFiles = 0
				__Dereference((gFoundFiles + 4)) = 0
				__Dereference((gFoundFiles + 8)) = 0
				Try
					Dim ptr3 As __Pointer(Of SByte)
					If gBaseString<char> IsNot Nothing Then
						ptr3 = gBaseString<char>
					Else
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					<Module>.GFileSystem.FindFiles(<Module>.FS, ptr3, gFoundFiles)
					Dim _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z As method = <Module>.__unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z
					If 0 < __Dereference((gFoundFiles + 4)) Then
						<Module>.qsort(gFoundFiles, CUInt((__Dereference((gFoundFiles + 4)))), 32UI, _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z)
					End If
					Me.ThumbList.Items.Clear()
					Me.ThumbsSrvr.StartThumbnailGeneration(Me.CountRelevantFiles(AddressOf gFoundFiles))
					Dim num5 As Integer = 0
					If 0 < __Dereference((gFoundFiles + 4)) Then
						Dim num6 As Integer = 0
						Do
							Dim num7 As UInteger = CUInt((__Dereference((num6 + gFoundFiles + 24))))
							Dim text As String = New String(CType((If((num7 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num7)), __Pointer(Of SByte)))
							Dim ptr4 As __Pointer(Of GFoundFile) = num6 + gFoundFiles
							If 0 >= __Dereference((ptr4 + 24 + 4)) Then
								GoTo IL_33C
							End If
							If __Dereference((__Dereference((ptr4 + 24)))) <> 46 OrElse (Me.Current.Length > 0 AndAlso String.Compare(text, "..", True) = 0) Then
								Dim listViewItem As ListViewItem = Nothing
								If __Dereference((num6 + gFoundFiles)) <> 0 Then
									If Me.ModeP <> FilePickerControl.Mode.Composite Then
										listViewItem = New ListViewItem("")
										listViewItem.SubItems.Add(text)
										If String.Compare(text, "..", True) <> 0 Then
											listViewItem.Tag = FilePickerControl.ItemType.Diritem
											listViewItem.ImageIndex = Me.GetThumbnailIndex(listViewItem)
										Else
											listViewItem.Tag = FilePickerControl.ItemType.Updiritem
											listViewItem.ImageIndex = 1
										End If
									End If
								Else
									Dim text2 As String = ""
									Dim extension As String = text2
									Dim text3 As String = text2
									Me.SplitFileName(text, text3, extension)
									If Me.IsFileRelevant(extension) AndAlso Me.IsFileRelevantByName(text3) AndAlso Me.IsFileRelevantByPath(Me.Current + "/", text, True) Then
										listViewItem = New ListViewItem("")
										Dim thumbTypeP As ThumbnailServer.ThumbType = Me.ThumbTypeP
										If thumbTypeP <> ThumbnailServer.ThumbType.Tile AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Box Then
											listViewItem.SubItems.Add(text)
										Else
											listViewItem.SubItems.Add(Me.GetNameBase(text3))
										End If
										listViewItem.Tag = FilePickerControl.ItemType.Fileitem
										listViewItem.ImageIndex = Me.GetThumbnailIndex(listViewItem)
									End If
								End If
								If listViewItem IsNot Nothing Then
									Me.ThumbList.Items.Add(listViewItem)
								End If
							End If
							num5 += 1
							num6 += 32
						Loop While num5 < __Dereference((gFoundFiles + 4))
						GoTo IL_35B
						IL_33C:
						<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
						<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), 0)
					End If
					IL_35B:
					Me.ThumbsSrvr.FinishThumbnailGeneration()
					MyBase.Focus()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GFoundFiles.{dtor}), CType((AddressOf gFoundFiles), __Pointer(Of Void)))
					Throw
				End Try
				Dim num8 As Integer = 0
				If 0 < __Dereference((gFoundFiles + 4)) Then
					Dim num9 As Integer = 0
					Do
						<Module>.GFoundFile.__delDtor(num9 + gFoundFiles, 0UI)
						num8 += 1
						num9 += 32
					Loop While num8 < __Dereference((gFoundFiles + 4))
				End If
				If gFoundFiles IsNot Nothing Then
					<Module>.free(gFoundFiles)
					gFoundFiles = 0
				End If
				__Dereference((gFoundFiles + 4)) = 0
				__Dereference((gFoundFiles + 8)) = 0
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
		End Sub

		Private Sub FillTreeWData()
			Dim array As String() = Me.SplitPath(Me.Current)
			Dim text As String = Me.Root + "/"
			Dim nodes As TreeNodeCollection = Me.DirectoryTree.Nodes
			Dim treeNode As TreeNode = Nothing
			Dim treeNode2 As TreeNode = Nothing
			Dim gFoundFiles As GFoundFiles = 0
			__Dereference((gFoundFiles + 4)) = 0
			__Dereference((gFoundFiles + 8)) = 0
			Try
				Dim num As Integer = 0
				Dim gBaseString<char> As GBaseString<char>
				If 0 < array.Length + 1 Then
					Do
						If treeNode IsNot Nothing Then
							treeNode2 = treeNode
						End If
						If nodes.Count = 0 Then
							<Module>.GBaseString<char>.{ctor}(gBaseString<char>, text + "*")
							Try
								Dim ptr As __Pointer(Of SByte)
								If gBaseString<char> IsNot Nothing Then
									ptr = gBaseString<char>
								Else
									ptr = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								<Module>.GFileSystem.FindFiles(<Module>.FS, ptr, gFoundFiles)
								Dim _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z As method = <Module>.__unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z
								If 0 < __Dereference((gFoundFiles + 4)) Then
									<Module>.qsort(gFoundFiles, CUInt((__Dereference((gFoundFiles + 4)))), 32UI, _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z)
								End If
								nodes.Clear()
								Dim num2 As Integer = 0
								If 0 < __Dereference((gFoundFiles + 4)) Then
									Dim num3 As Integer = 0
									While True
										Dim num4 As UInteger = CUInt((__Dereference((num3 + gFoundFiles + 24))))
										Dim text2 As String = New String(CType((If((num4 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num4)), __Pointer(Of SByte)))
										Dim num5 As Integer = gFoundFiles + num3
										Dim ptr2 As __Pointer(Of GFoundFile) = num5
										If 0 >= __Dereference((ptr2 + 24 + 4)) Then
											Exit While
										End If
										If __Dereference((__Dereference((ptr2 + 24)))) <> 46 Then
											Dim treeNode3 As TreeNode = Nothing
											If __Dereference(num5) <> 0 Then
												treeNode3 = New TreeNode(text2)
												treeNode3.Tag = FilePickerControl.ItemType.Diritem
												If num < array.Length Then
													If String.Compare(treeNode3.Text, array(num), True) <> 0 Then
														Me.CollapseTreeItem(treeNode3)
													Else
														treeNode = treeNode3
													End If
												End If
											Else If Me.ModeP <> FilePickerControl.Mode.Composite Then
												Dim text3 As String = ""
												Dim extension As String = text3
												Dim text4 As String = text3
												Me.SplitFileName(text2, text4, extension)
												If Me.IsFileRelevant(extension) AndAlso Me.IsFileRelevantByName(text4) AndAlso Me.IsFileRelevantByPath(text, text2, False) Then
													Dim thumbTypeP As ThumbnailServer.ThumbType = Me.ThumbTypeP
													If thumbTypeP <> ThumbnailServer.ThumbType.Tile AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Box Then
														treeNode3 = New TreeNode(text2)
													Else
														treeNode3 = New TreeNode(Me.GetNameBase(text4))
													End If
													treeNode3.Tag = FilePickerControl.ItemType.Fileitem
													Select Case Me.ThumbTypeP
														Case ThumbnailServer.ThumbType.Material, ThumbnailServer.ThumbType.Tile
															treeNode3.ImageIndex = 4
															treeNode3.SelectedImageIndex = 4
														Case ThumbnailServer.ThumbType.Unit
															treeNode3.ImageIndex = 6
															treeNode3.SelectedImageIndex = 6
														Case ThumbnailServer.ThumbType.Sound
															treeNode3.ImageIndex = 5
															treeNode3.SelectedImageIndex = 5
														Case ThumbnailServer.ThumbType.Effect
															treeNode3.ImageIndex = 3
															treeNode3.SelectedImageIndex = 3
														Case ThumbnailServer.ThumbType.Box, ThumbnailServer.ThumbType.Fluid, ThumbnailServer.ThumbType.Cloud
															treeNode3.ImageIndex = 7
															treeNode3.SelectedImageIndex = 7
														Case ThumbnailServer.ThumbType.Locale, ThumbnailServer.ThumbType.Map
															treeNode3.ImageIndex = 8
															treeNode3.SelectedImageIndex = 8
														Case Else
															treeNode3.ImageIndex = 2
															treeNode3.SelectedImageIndex = 2
													End Select
												End If
											End If
											If treeNode3 IsNot Nothing Then
												nodes.Add(treeNode3)
											End If
										End If
										num2 += 1
										num3 += 32
										If num2 >= __Dereference((gFoundFiles + 4)) Then
											GoTo Block_38
										End If
									End While
									GoTo IL_383
									Block_38:
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char> IsNot Nothing Then
								<Module>.free(gBaseString<char>)
								gBaseString<char> = 0
							End If
						Else
							Dim num6 As Integer = 0
							If 0 < nodes.Count Then
								Do
									Dim treeNode4 As TreeNode = nodes(num6)
									Dim tag As Object = treeNode4.Tag
									If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) <> FilePickerControl.ItemType.Fileitem AndAlso num < array.Length Then
										If String.Compare(treeNode4.Text, array(num), True) <> 0 Then
											Me.CollapseTreeItem(treeNode4)
										Else
											treeNode = treeNode4
										End If
									End If
									num6 += 1
								Loop While num6 < nodes.Count
							End If
						End If
						If treeNode IsNot Nothing Then
							nodes = treeNode.Nodes
						End If
						If num < array.Length Then
							text = text + array(num) + "/"
						End If
						If treeNode2 IsNot Nothing Then
							Me.ExpandTreeItem(treeNode2)
						End If
						num += 1
					Loop While num < array.Length + 1
					GoTo IL_3B3
					IL_383:
					Try
						<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
						<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), 0)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
				End If
				IL_3B3:
				Try
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GFoundFiles.{dtor}), CType((AddressOf gFoundFiles), __Pointer(Of Void)))
				Throw
			End Try
			Dim num7 As Integer = 0
			If 0 < __Dereference((gFoundFiles + 4)) Then
				Dim num8 As Integer = 0
				Do
					<Module>.GFoundFile.__delDtor(num8 + gFoundFiles, 0UI)
					num7 += 1
					num8 += 32
				Loop While num7 < __Dereference((gFoundFiles + 4))
			End If
			If gFoundFiles IsNot Nothing Then
				<Module>.free(gFoundFiles)
			End If
		End Sub

		Private Sub ExpandTreeItem(item As TreeNode)
			If item IsNot Nothing Then
				Dim tag As Object = item.Tag
				If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) <> FilePickerControl.ItemType.Fileitem Then
					item.Expand()
					item.ImageIndex = 1
					item.SelectedImageIndex = 1
				End If
			End If
		End Sub

		Private Sub CollapseTreeItem(item As TreeNode)
			If item IsNot Nothing Then
				Dim tag As Object = item.Tag
				If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) <> FilePickerControl.ItemType.Fileitem Then
					item.Collapse()
					item.ImageIndex = 0
					item.SelectedImageIndex = 0
					Dim num As Integer = 0
					If 0 < item.Nodes.Count Then
						Do
							Me.CollapseTreeItem(item.Nodes(num))
							num += 1
						Loop While num < item.Nodes.Count
					End If
				End If
			End If
		End Sub

		Private Sub UpDir()
			Dim separator As Char() = "/".ToCharArray()
			Dim array As String() = Me.Current.Split(separator)
			If array.Length > 1 Then
				Me.Current = array(0)
				Dim num As Integer = 1
				If 1 < array.Length - 1 Then
					Do
						Me.Current = Me.Current + "/" + array(num)
						num += 1
					Loop While num < array.Length - 1
				End If
			Else
				Me.Current = ""
			End If
		End Sub

		Private Sub ForceUpdateThumbnails()
			Dim text As String = Nothing
			Me.ThumbsSrvr.StartThumbnailGeneration(Me.ThumbList.Items.Count)
			Dim num As Integer = 0
			If 0 < Me.ThumbList.Items.Count Then
				Do
					Dim num2 As Integer
					Me.Thumbnails.Images(Me.ThumbList.Items(num).ImageIndex) = Me.GetThumbnailImage(Me.ThumbList.Items(num), text, num2, True)
					num += 1
				Loop While num < Me.ThumbList.Items.Count
			End If
			Me.ThumbsSrvr.FinishThumbnailGeneration()
			MyBase.Focus()
		End Sub

		Private Function GetNameBase(fullname As String) As String
			Dim num As Integer = 0
			Dim num2 As Integer = fullname.Length - 1
			If num2 >= 0 Then
				Do
					num += 1
					If fullname(num2) = "_"c Then
						Exit Do
					End If
					num2 -= 1
				Loop While num2 >= 0
			End If
			Return fullname.Remove(fullname.Length - num, num)
		End Function

		Private Sub SplitFileName(filename As String, name As __Pointer(Of String), extension As __Pointer(Of String))
			Dim separator As Char() = ".".ToCharArray()
			Dim array As String() = filename.Split(separator)
			Dim num As Integer = array.Length
			If num > 1 Then
				__Dereference(extension) = array(num - 1)
			Else
				__Dereference(extension) = ""
			End If
			If array.Length > 0 Then
				__Dereference(name) = array(0)
			End If
			Dim num2 As Integer = 1
			If 1 < array.Length - 1 Then
				Do
					__Dereference(name) = __Dereference(name) + "." + array(num2)
					num2 += 1
				Loop While num2 < array.Length - 1
			End If
		End Sub

		Private Function IsFileRelevant(extension As String) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim extensionsP As String() = Me.ExtensionsP
			If extensionsP Is Nothing Then
				Return True
			End If
			Dim num As Integer = 0
			If 0 < extensionsP.Length Then
				While String.Compare(extensionsP(num), extension, True) <> 0
					num += 1
					extensionsP = Me.ExtensionsP
					If num >= extensionsP.Length Then
						Return False
					End If
				End While
				Return True
			End If
			Return False
		End Function

		Private Function IsFileRelevantByName(name As String) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim thumbTypeP As ThumbnailServer.ThumbType = Me.ThumbTypeP
			If thumbTypeP = ThumbnailServer.ThumbType.Box Then
				Return(If((String.Compare(name.Substring(name.Length - 4, 4), "_top") = 0), 1, 0)) <> 0
			End If
			Return thumbTypeP <> ThumbnailServer.ThumbType.Tile OrElse (If((String.Compare(name.Substring(name.Length - 2, 2), "_1") = 0), 1, 0)) <> 0
		End Function

		Private Function IsFileRelevantByPath(parentpath As String, filename As String, <MarshalAs(UnmanagedType.U1)> rootneeded As Boolean) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			If Me.ThumbTypeP = ThumbnailServer.ThumbType.Unit AndAlso Me.FilterNonEditableUnitsP Then
				Dim text As String
				If parentpath.Length > 1 Then
					text = parentpath + filename
				Else
					text = filename
				End If
				If rootneeded Then
					text = Me.Root + "/" + text
				End If
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, text)
				Dim result As Boolean
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim expr_69 As __Pointer(Of GPUnit) = <Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, ptr2, False, True)
					result = (calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_69, __Dereference((__Dereference(expr_69) + 92))) <> 0)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Return result
			End If
			Return True
		End Function

		Private Function CountRelevantFiles(foundfiles As __Pointer(Of GFoundFiles)) As Integer
			Dim num As Integer = 0
			Dim gBaseString<char> As GBaseString<char> = 0
			__Dereference((gBaseString<char> + 4)) = 0
			Try
				Dim num2 As Integer = 0
				Dim num3 As Integer = __Dereference(CType((foundfiles + 4 / __SizeOf(GFoundFiles)), __Pointer(Of Integer)))
				If 0 < num3 Then
					Dim num4 As Integer = 0
					Do
						Dim num5 As UInteger = CUInt((__Dereference((num4 + __Dereference(CType(foundfiles, __Pointer(Of Integer))) + 24))))
						Dim value As __Pointer(Of SByte)
						If num5 <> 0UI Then
							value = num5
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						<Module>.GBaseString<char>.=(gBaseString<char>, New String(CType(value, __Pointer(Of SByte))))
						Dim ptr As __Pointer(Of GFoundFile) = num4 + __Dereference(CType(foundfiles, __Pointer(Of Integer)))
						If 0 >= __Dereference((ptr + 24 + 4)) Then
							GoTo IL_13A
						End If
						If(__Dereference((__Dereference((ptr + 24)))) <> 46 OrElse (Me.Current.Length > 0 AndAlso String.Compare(New String(CType((If((gBaseString<char> Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>)), __Pointer(Of SByte))), "..", True) = 0)) AndAlso __Dereference((num4 + __Dereference(CType(foundfiles, __Pointer(Of Integer))))) = 0 Then
							Dim text As String = ""
							Dim extension As String = text
							Dim name As String = text
							Dim value2 As __Pointer(Of SByte)
							If gBaseString<char> IsNot Nothing Then
								value2 = gBaseString<char>
							Else
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							Me.SplitFileName(New String(CType(value2, __Pointer(Of SByte))), name, extension)
							If Me.IsFileRelevant(extension) AndAlso Me.IsFileRelevantByName(name) Then
								Dim value3 As __Pointer(Of SByte)
								If gBaseString<char> IsNot Nothing Then
									value3 = gBaseString<char>
								Else
									value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								If Me.IsFileRelevantByPath(Me.Current + "/", New String(CType(value3, __Pointer(Of SByte))), True) Then
									num += 1
								End If
							End If
						End If
						num2 += 1
						num4 += 32
						num3 = __Dereference(CType((foundfiles + 4 / __SizeOf(GFoundFiles)), __Pointer(Of Integer)))
					Loop While num2 < num3
					GoTo IL_169
					IL_13A:
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), 0)
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			IL_169:
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Return num
		End Function

		Private Function GetThumbnailIndex(lvi As ListViewItem) As Integer
			Dim key As String = Nothing
			Dim num As Integer
			Dim thumbnailImage As Image = Me.GetThumbnailImage(lvi, key, num, False)
			If thumbnailImage IsNot Nothing Then
				Me.Thumbnails.Images.Add(thumbnailImage)
				Dim num2 As Integer = Me.Thumbnails.Images.Count - 1
				Me.ThumbnailIndices(key) = num2
				Return num2
			End If
			If num > -1 Then
				Return num
			End If
			Return 2
		End Function

		Private Function GetThumbnailImage(lvi As ListViewItem, hashcode As __Pointer(Of String), hashindex As __Pointer(Of Integer), <MarshalAs(UnmanagedType.U1)> forceupdate As Boolean) As Image
			__Dereference(hashindex) = -1
			Dim text As String
			If Me.Current.Length > 0 Then
				text = Me.Current + "/" + lvi.SubItems(1).Text
			Else
				text = String.Concat(lvi.SubItems(1).Text)
			End If
			text = Me.Root + "/" + text
			If Me.ThumbTypeP = ThumbnailServer.ThumbType.Unit Then
				Dim tag As Object = lvi.Tag
				If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) = FilePickerControl.ItemType.Fileitem Then
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, text)
					Try
						Dim num As UInteger = CUInt((__Dereference(ptr)))
						Dim ptr2 As __Pointer(Of SByte)
						If num <> 0UI Then
							ptr2 = num
						Else
							ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Dim num2 As UInteger = CUInt((__Dereference((<Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, ptr2, False, True) + 12))))
						text = New String(CType((If((num2 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num2)), __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
						gBaseString<char> = 0
					End If
				End If
			End If
			text = text.ToLower()
			Dim gMD5Wrapper As GMD5Wrapper
			<Module>.md5_init(CType((AddressOf gMD5Wrapper), __Pointer(Of md5_state_s)))
			Dim gBaseString<char>2 As GBaseString<char>
			Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, text)
			Try
				Dim num3 As UInteger = CUInt((__Dereference(ptr3)))
				Dim ptr4 As __Pointer(Of SByte)
				If num3 <> 0UI Then
					ptr4 = num3
				Else
					ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				Dim length As Integer = text.Length
				<Module>.md5_append(CType((AddressOf gMD5Wrapper), __Pointer(Of md5_state_s)), CType(ptr4, __Pointer(Of Byte)), length)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>2 IsNot Nothing Then
				<Module>.free(gBaseString<char>2)
			End If
			Dim $ArrayType$$$BY0CB@D As $ArrayType$$$BY0CB@D
			<Module>.GMD5Wrapper.Finish(gMD5Wrapper, $ArrayType$$$BY0CB@D)
			Dim text2 As String = New String(CType((AddressOf $ArrayType$$$BY0CB@D), __Pointer(Of SByte)))
			__Dereference(hashcode) = text2
			Dim obj As Object = Nothing
			If Not forceupdate Then
				obj = Me.ThumbnailIndices(text2)
			End If
			If obj IsNot Nothing Then
				Dim ptr5 As __Pointer(Of Integer)
				If TypeOf obj Is Integer Then
					ptr5 = CInt(obj)
				Else
					ptr5 = 0
				End If
				__Dereference(hashindex) = __Dereference(ptr5)
				Return Nothing
			End If
			Dim tag2 As Object = lvi.Tag
			If __Dereference((If((Not(TypeOf tag2 Is FilePickerControl.ItemType)), 0, CType(tag2, FilePickerControl.ItemType)))) <> FilePickerControl.ItemType.Diritem Then
				Dim thumbTypeP As ThumbnailServer.ThumbType = Me.ThumbTypeP
				If thumbTypeP <> ThumbnailServer.ThumbType.Sound AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Effect AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Box AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Fluid AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Cloud AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Locale AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Map Then
					Return Me.ThumbsSrvr.GetThumbnail(Me.ThumbRootP, text, __Dereference(hashcode), forceupdate)
				End If
			End If
			Dim tag3 As Object = lvi.Tag
			Dim image As Image
			If __Dereference((If((Not(TypeOf tag3 Is FilePickerControl.ItemType)), 0, CType(tag3, FilePickerControl.ItemType)))) = FilePickerControl.ItemType.Diritem Then
				image = Me.Thumbnails.Images(0)
			Else
				Dim thumbTypeP As ThumbnailServer.ThumbType = Me.ThumbTypeP
				If thumbTypeP = ThumbnailServer.ThumbType.Effect Then
					image = Me.Thumbnails.Images(3)
				Else If thumbTypeP = ThumbnailServer.ThumbType.Box Then
					image = Me.Thumbnails.Images(3)
				Else If thumbTypeP = ThumbnailServer.ThumbType.Fluid Then
					image = Me.Thumbnails.Images(5)
				Else If thumbTypeP = ThumbnailServer.ThumbType.Cloud Then
					image = Me.Thumbnails.Images(5)
				Else If thumbTypeP = ThumbnailServer.ThumbType.Locale Then
					image = Me.Thumbnails.Images(6)
				Else If thumbTypeP = ThumbnailServer.ThumbType.Map Then
					image = Me.Thumbnails.Images(6)
				Else
					image = Me.Thumbnails.Images(2)
				End If
			End If
			If image Is Nothing Then
				Return Nothing
			End If
			Dim image2 As Image = image.Clone()
			Dim graphics As Graphics = Graphics.FromImage(image2)
			Dim rectangleF As RectangleF = New RectangleF(0F, 20F, 64F, 27F)
			Dim darkBlue As Color = Color.DarkBlue
			Dim brush As SolidBrush = New SolidBrush(Color.FromArgb(128, darkBlue))
			graphics.FillRectangle(brush, rectangleF)
			Dim font As Font = New Font(New Font(New String(CType((AddressOf <Module>.??_C@_05MPFIAJAP@Arial?$AA@), __Pointer(Of SByte))), 8F), FontStyle.Bold)
			Dim brush2 As SolidBrush = New SolidBrush(Color.White)
			graphics.DrawString(lvi.SubItems(1).Text, font, brush2, rectangleF)
			Return image2
		End Function

		Private Function GetHotThumb(x As Integer, y As Integer) As Integer
			Dim num As Integer = Me.ThumbList.Items.Count - 1
			If num > -1 Then
				Do
					Dim itemRect As Rectangle = Me.ThumbList.GetItemRect(num)
					Dim pt As Point = New Point(x, y)
					If itemRect.Contains(pt) Then
						Return num
					End If
					num -= 1
				Loop While num > -1
				Return -1
			End If
			Return -1
		End Function

		Private Function SplitPath(fullpath As String) As String()
			Dim separator As Char() = "/".ToCharArray()
			Return fullpath.Split(separator)
		End Function

		Private Function CutToSize(name As String) As String
			Dim text As String = name
			If name.Length > 8 Then
				text = name.Substring(0, 7)
				text += New String(CType((AddressOf <Module>.??_C@_03KHICJKCI@?4?4?4?$AA@), __Pointer(Of SByte)))
			End If
			Return text
		End Function

		Private Function GetFullThumbViewPath(lvi As ListViewItem) As String
			Dim text As String
			If Me.Current.Length > 0 Then
				text = Me.Current + "/" + lvi.SubItems(1).Text
			Else
				text = String.Concat(lvi.SubItems(1).Text)
			End If
			text = Me.Root + "/" + text
			If Me.ThumbTypeP = ThumbnailServer.ThumbType.Unit Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, text)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim num2 As UInteger = CUInt((__Dereference((<Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, ptr2, False, True) + 12))))
					text = New String(CType((If((num2 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num2)), __Pointer(Of SByte)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
					gBaseString<char> = 0
				End If
			End If
			text = text.ToLower()
			Dim gBaseString<char>2 As GBaseString<char>
			Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, text)
			Dim gBaseString<char>3 As GBaseString<char>
			Try
				Dim num3 As UInteger = CUInt((__Dereference(ptr3)))
				Dim ptr4 As __Pointer(Of SByte)
				If num3 <> 0UI Then
					ptr4 = num3
				Else
					ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				<Module>.GFileSystem.GetFileFullPath(<Module>.FS, AddressOf gBaseString<char>3, ptr4)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			Dim result As String
			Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
				End If
				If(If((gBaseString<char>3 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>3)) Is Nothing Then
					GoTo IL_160
				End If
				result = New String(CType((If((gBaseString<char>3 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>3)), __Pointer(Of SByte)))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>3 IsNot Nothing Then
				<Module>.free(gBaseString<char>3)
			End If
			Return result
			IL_160:
			Dim result2 As String
			Try
				result2 = Nothing
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>3 IsNot Nothing Then
				<Module>.free(gBaseString<char>3)
			End If
			Return result2
		End Function

		Private Function GetFullTreeViewPath(tn As TreeNode) As String
			Dim text As String = tn.FullPath
			text = Me.Root + "/" + text
			If Me.ThumbTypeP = ThumbnailServer.ThumbType.Unit Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, text)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim num2 As UInteger = CUInt((__Dereference((<Module>.GUnitRegistry.GetPUnit(<Module>.UnitRegistry, ptr2, False, True) + 12))))
					text = New String(CType((If((num2 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num2)), __Pointer(Of SByte)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
					gBaseString<char> = 0
				End If
			End If
			text = text.ToLower()
			Dim gBaseString<char>2 As GBaseString<char>
			Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, text)
			Dim gBaseString<char>3 As GBaseString<char>
			Try
				Dim num3 As UInteger = CUInt((__Dereference(ptr3)))
				Dim ptr4 As __Pointer(Of SByte)
				If num3 <> 0UI Then
					ptr4 = num3
				Else
					ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				<Module>.GFileSystem.GetFileFullPath(<Module>.FS, AddressOf gBaseString<char>3, ptr4)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			Dim result As String
			Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
				End If
				If(If((gBaseString<char>3 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>3)) Is Nothing Then
					GoTo IL_11E
				End If
				result = New String(CType((If((gBaseString<char>3 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>3)), __Pointer(Of SByte)))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>3 IsNot Nothing Then
				<Module>.free(gBaseString<char>3)
			End If
			Return result
			IL_11E:
			Dim result2 As String
			Try
				result2 = Nothing
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>3 IsNot Nothing Then
				<Module>.free(gBaseString<char>3)
			End If
			Return result2
		End Function

		Private Sub ViewModel(path As String)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim fileInfo As FileInfo = New FileInfo(Application.ExecutablePath)
			Dim fileName As String = fileInfo.Directory.FullName + "/modelviewer.exe"
			Dim exceptionCode As UInteger
			If FilePickerControl.MViewer Is Nothing OrElse FilePickerControl.MViewer.HasExited Then
				FilePickerControl.MViewer = New Process()
				FilePickerControl.MViewer.StartInfo.FileName = fileName
				FilePickerControl.MViewer.StartInfo.CreateNoWindow = False
				FilePickerControl.MViewer.StartInfo.Arguments = """" + path + New String(CType((AddressOf <Module>.??_C@_01BJJEKLCA@?$CC?$AA@), __Pointer(Of SByte)))
				Try
					FilePickerControl.MViewer.Start()
					Return
				End Try
				exceptionCode = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End If
			Try
				Dim streamWriter As StreamWriter = New StreamWriter(fileInfo.Directory.FullName + "/$$MVInfo$$.mvi")
				streamWriter.WriteLine(path)
				streamWriter.Close()
				<Module>.PostMessageA(CType(FilePickerControl.MViewer.MainWindowHandle.ToPointer(), __Pointer(Of HWND__)), 1025UI, 0UI, 0)
				<Module>.SetForegroundWindow(CType(FilePickerControl.MViewer.MainWindowHandle.ToPointer(), __Pointer(Of HWND__)))
				GoTo IL_116
			End Try
			exceptionCode = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_116:
		End Sub

		Private Sub OnLoad(sender As Object, e As EventArgs)
			If Not Me.initialized Then
				Me.ThumbsSrvr = New ThumbnailServer(Me.ThumbTypeP)
				Me.CmpSplitter = New Splitter()
			End If
			Me.CmpSplitter.MinExtra = 76
			Me.CmpSplitter.MinSize = 76
			Me.InitThumbView()
			Me.InitTreeView()
			Me.CommonInitLogics()
		End Sub

		Private Sub FPTools_ButtonClick(idx As Integer, radio_group As Integer)
			Select Case idx
				Case 1
					Me.UpDir()
					Me.FillData()
				Case 2
					Dim modeP As FilePickerControl.Mode = Me.ModeP
					If modeP <> FilePickerControl.Mode.Thumbnail Then
						If modeP = FilePickerControl.Mode.Composite Then
							Me.LastCompositeHeight = Me.DirectoryTree.Size.Height
						End If
						Me.ModeP = FilePickerControl.Mode.Thumbnail
						Me.CommonInitLogics()
					End If
				Case 3
					Dim modeP2 As FilePickerControl.Mode = Me.ModeP
					If modeP2 <> FilePickerControl.Mode.Treeview Then
						If modeP2 = FilePickerControl.Mode.Composite Then
							Me.LastCompositeHeight = Me.DirectoryTree.Size.Height
						End If
						Me.ModeP = FilePickerControl.Mode.Treeview
						Me.CommonInitLogics()
					End If
				Case 4
					If Me.ModeP <> FilePickerControl.Mode.Composite Then
						Me.ModeP = FilePickerControl.Mode.Composite
						Me.CommonInitLogics()
					End If
				Case 5
					Me.ForceUpdateThumbnails()
			End Select
		End Sub

		Private Sub TreeViewButton_Click(sender As Object, e As EventArgs)
			Me.ModeP = FilePickerControl.Mode.Treeview
			Me.CommonInitLogics()
		End Sub

		Private Sub ThumbsButton_Click(sender As Object, e As EventArgs)
			Me.ModeP = FilePickerControl.Mode.Thumbnail
			Me.CommonInitLogics()
		End Sub

		Private Sub ListItem_DblClick(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			If Not Me.RestrictMouseEvents Then
				Try
					If Me.ThumbList.SelectedItems.Count > 0 Then
						Dim listViewItem As ListViewItem = Me.ThumbList.SelectedItems(0)
						Dim tag As Object = listViewItem.Tag
						If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) = FilePickerControl.ItemType.Updiritem Then
							Me.UpDir()
						Else
							Dim tag2 As Object = listViewItem.Tag
							If __Dereference((If((Not(TypeOf tag2 Is FilePickerControl.ItemType)), 0, CType(tag2, FilePickerControl.ItemType)))) <> FilePickerControl.ItemType.Diritem Then
								If Me.Current.Length > 0 Then
									Me.FileP = Me.Current + "/" + listViewItem.SubItems(1).Text
								Else
									Me.FileP = listViewItem.SubItems(1).Text
								End If
								Me.raise_DoubleClickSelection(Me.FileP)
								Return
							End If
							If Me.Current.Length > 0 Then
								Me.Current = Me.Current + "/" + listViewItem.SubItems(1).Text
							Else
								Me.Current = listViewItem.SubItems(1).Text
							End If
						End If
						Me.FillData()
					End If
					Return
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End If
		End Sub

		Private Sub ThumbviewMouseDown(sender As Object, e As MouseEventArgs)
			If e.Button = MouseButtons.Right Then
				Me.RestrictMouseEvents = True
			End If
		End Sub

		Private Sub ListItem_SingleClick(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Try
				If Me.ThumbList.SelectedItems.Count > 0 Then
					Dim listViewItem As ListViewItem = Me.ThumbList.SelectedItems(0)
					Dim tag As Object = listViewItem.Tag
					If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) = FilePickerControl.ItemType.Fileitem Then
						If Me.Current.Length > 0 Then
							Me.FileP = Me.Current + "/" + listViewItem.SubItems(1).Text
						Else
							Me.FileP = listViewItem.SubItems(1).Text
						End If
						If Not Me.RestrictMouseEvents Then
							Me.raise_SingleClickSelection(Me.FileP)
						End If
					End If
				End If
				Return
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
		End Sub

		Private Sub TreeItem_DblClick(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			If Not Me.RestrictMouseEvents Then
				Try
					If Me.DirectoryTree.SelectedNode IsNot Nothing Then
						Dim tag As Object = Me.DirectoryTree.SelectedNode.Tag
						If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) = FilePickerControl.ItemType.Fileitem Then
							Dim fullPath As String = Me.DirectoryTree.SelectedNode.FullPath
							Me.FileP = fullPath
							Me.raise_DoubleClickSelection(fullPath)
						Else If Me.DirectoryTree.SelectedNode.IsExpanded Then
							Me.DirectoryTree.SelectedNode.Collapse()
						Else
							Me.DirectoryTree.SelectedNode.Expand()
						End If
					End If
					Return
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End If
		End Sub

		Private Sub TreeItem_SingleClick(sender As Object, e As MouseEventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			If e.Button <> MouseButtons.Left Then
				Me.RestrictMouseEvents = True
			End If
			Try
				Dim nodeAt As TreeNode = Me.DirectoryTree.GetNodeAt(e.X, e.Y)
				Me.DirectoryTree.SelectedNode = nodeAt
				If nodeAt IsNot Nothing Then
					Dim tag As Object = nodeAt.Tag
					If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) <> FilePickerControl.ItemType.Fileitem Then
						If Not Me.RestrictMouseEvents Then
							Me.Current = nodeAt.FullPath
							If nodeAt.ImageIndex = 1 Then
								Me.CollapseTreeItem(nodeAt)
								Me.UpDir()
								If Me.ModeP = FilePickerControl.Mode.Composite Then
									Me.FillListWData()
								End If
							Else
								Me.FillData()
							End If
						End If
					Else
						If nodeAt.Parent IsNot Nothing Then
							Me.Current = nodeAt.Parent.FullPath
						Else
							Me.Current = ""
						End If
						Dim fullPath As String = nodeAt.FullPath
						Me.FileP = fullPath
						If Not Me.RestrictMouseEvents Then
							Me.raise_SingleClickSelection(fullPath)
						End If
					End If
				End If
				Return
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
		End Sub

		Private Sub TreeItemSelection(sender As Object, e As TreeViewCancelEventArgs)
			If e.Action <> TreeViewAction.Unknown Then
				e.Cancel = True
			End If
		End Sub

		Private Sub UpButton_Click(sender As Object, e As EventArgs)
			Me.UpDir()
			Me.FillData()
		End Sub

		Private Sub MouseMove(sender As Object, e As MouseEventArgs)
			Dim modeP As FilePickerControl.Mode = Me.ModeP
			If modeP = FilePickerControl.Mode.Thumbnail OrElse modeP = FilePickerControl.Mode.Composite Then
				Dim hotThumb As Integer = Me.GetHotThumb(e.X, e.Y)
				If Me.LastTTIndx <> hotThumb Then
					If hotThumb > -1 Then
						Dim listViewItem As ListViewItem = Me.ThumbList.Items(hotThumb)
						Me.ThumbnailTooltip.Active = True
						Me.ThumbnailTooltip.SetToolTip(Me.ThumbList, listViewItem.SubItems(1).Text)
					Else
						Me.ThumbnailTooltip.Active = False
					End If
					Me.LastTTIndx = hotThumb
				End If
			End If
		End Sub

		Private Sub CompositeButton_Click(sender As Object, e As EventArgs)
			Me.ModeP = FilePickerControl.Mode.Composite
			Me.CommonInitLogics()
		End Sub

		Private Sub TreeviewMouseUp(sender As Object, e As MouseEventArgs)
			Dim selectedNode As TreeNode = Me.DirectoryTree.SelectedNode
			If e.Button = MouseButtons.Right AndAlso selectedNode IsNot Nothing Then
				Dim tag As Object = selectedNode.Tag
				If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) = FilePickerControl.ItemType.Fileitem Then
					Me.RestrictMouseEvents = True
					Dim pos As Point = New Point(e.X, e.Y)
					Me.TreeContextMenu.Show(Me.DirectoryTree, pos)
				End If
			End If
			Me.RestrictMouseEvents = False
		End Sub

		Private Sub ThumbviewMouseUp(sender As Object, e As MouseEventArgs)
			If e.Button = MouseButtons.Right AndAlso Me.ThumbList.SelectedItems.Count > 0 Then
				Dim tag As Object = Me.ThumbList.SelectedItems(0).Tag
				If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) = FilePickerControl.ItemType.Fileitem Then
					Me.RestrictMouseEvents = True
					Dim pos As Point = New Point(e.X, e.Y)
					Me.ThumbContextMenu.Show(Me.ThumbList, pos)
				End If
			End If
			Me.RestrictMouseEvents = False
		End Sub

		Private Sub menuItemRefreshTN_Click(sender As Object, e As EventArgs)
			Dim text As String = Nothing
			If Me.ThumbList.SelectedItems.Count > 0 Then
				Dim listViewItem As ListViewItem = Me.ThumbList.SelectedItems(0)
				Me.ThumbsSrvr.StartThumbnailGeneration(1)
				Dim num As Integer
				Me.Thumbnails.Images(listViewItem.ImageIndex) = Me.GetThumbnailImage(listViewItem, text, num, True)
				Me.ThumbsSrvr.FinishThumbnailGeneration()
				MyBase.Focus()
			End If
		End Sub

		Private Sub ContextMenu_Popup(sender As Object, e As EventArgs)
			Me.raise_ContextPopup(Me.FileP)
			If Me.ModeP = FilePickerControl.Mode.Treeview Then
				Me.menuItemRefreshTN.Enabled = False
			Else If Me.ThumbList.SelectedItems.Count > 0 Then
				Dim listViewItem As ListViewItem = Me.ThumbList.SelectedItems(0)
				Dim thumbTypeP As ThumbnailServer.ThumbType = Me.ThumbTypeP
				Dim enabled As Byte
				If thumbTypeP <> ThumbnailServer.ThumbType.Sound AndAlso thumbTypeP <> ThumbnailServer.ThumbType.Effect Then
					Dim tag As Object = listViewItem.Tag
					If __Dereference((If((Not(TypeOf tag Is FilePickerControl.ItemType)), 0, CType(tag, FilePickerControl.ItemType)))) = FilePickerControl.ItemType.Fileitem AndAlso Me.GetFullThumbViewPath(listViewItem) IsNot Nothing Then
						enabled = 1
						GoTo IL_89
					End If
				End If
				enabled = 0
				IL_89:
				Me.menuItemRefreshTN.Enabled = (enabled <> 0)
			Else
				Me.menuItemRefreshTN.Enabled = False
			End If
		End Sub

		Private Sub menuItemViewModel_Click(sender As Object, e As EventArgs)
			If Me.ThumbList.SelectedItems.Count > 0 Then
				Dim lvi As ListViewItem = Me.ThumbList.SelectedItems(0)
				Me.ViewModel(Me.GetFullThumbViewPath(lvi))
			End If
		End Sub

		Private Sub menuItemTVViewModel_Click(sender As Object, e As EventArgs)
			Dim selectedNode As TreeNode = Me.DirectoryTree.SelectedNode
			If selectedNode IsNot Nothing Then
				Me.ViewModel(Me.GetFullTreeViewPath(selectedNode))
			End If
		End Sub

		Protected Sub raise_SingleClickSelection(i1 As String)
			Dim singleClickSelection As FilePickerControl.FilePickedHandler = Me.SingleClickSelection
			If singleClickSelection IsNot Nothing Then
				singleClickSelection(i1)
			End If
		End Sub

		Protected Sub raise_DoubleClickSelection(i1 As String)
			Dim doubleClickSelection As FilePickerControl.FilePickedHandler = Me.DoubleClickSelection
			If doubleClickSelection IsNot Nothing Then
				doubleClickSelection(i1)
			End If
		End Sub

		Protected Sub raise_ContextPopup(i1 As String)
			Dim contextPopup As FilePickerControl.ContextMenuPopupHandler = Me.ContextPopup
			If contextPopup IsNot Nothing Then
				contextPopup(i1)
			End If
		End Sub
	End Class
End Namespace
