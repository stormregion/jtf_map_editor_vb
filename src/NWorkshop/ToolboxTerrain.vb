Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxTerrain
		Inherits UserControl
		Implements IRearrangeableControl

		Public Delegate Sub LayerSet(layerindx As Integer)

		Public Delegate Sub ResumePaint()

		Public Delegate Sub GUINeedRefreshHandler()

		Private TypeImageList As ImageList

		Private LayerList As ListView

		Private DummyColumn As ColumnHeader

		Private SelectionTT As ToolTip

		Private ToolPanel As Panel

		Private DownBtn As Button

		Private UpBtn As Button

		Private DeleteBtn As Button

		Private ReplaceBtn As Button

		Private AddBtn As Button

		Private LayerPopupMenu As ContextMenu

		Private menuItem6 As MenuItem

		Private menuitemNormal As MenuItem

		Private menuitemBlocker As MenuItem

		Private menuitemGrass As MenuItem

		Private menuitemFord As MenuItem

		Private menuitemWalker As MenuItem

		Private menuitemInvisible As MenuItem

		Private menuitemDustFree As MenuItem

		Private components As IContainer

		Private TerrainPicker As FilePickerControl

		Private WorldP As __Pointer(Of GEditorWorld)

		Private SelectedTile As String

		Private CurrentForceCount As Integer

		Private PopupLayerIndx As Integer

		Public Custom Event GUINeedRefreshEvent As ToolboxTerrain.GUINeedRefreshHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.GUINeedRefreshEvent = [Delegate].Combine(Me.GUINeedRefreshEvent, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.GUINeedRefreshEvent = [Delegate].Remove(Me.GUINeedRefreshEvent, value)
			End RemoveHandler
		End Event

		Public Overrides Custom Event Rearranged As ToolRearranged
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Rearranged = [Delegate].Combine(Me.Rearranged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Rearranged = [Delegate].Remove(Me.Rearranged, value)
			End RemoveHandler
		End Event

		Public Custom Event ResetToPaint As ToolboxTerrain.ResumePaint
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.ResetToPaint = [Delegate].Combine(Me.ResetToPaint, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.ResetToPaint = [Delegate].Remove(Me.ResetToPaint, value)
			End RemoveHandler
		End Event

		Public Custom Event LayerSelected As ToolboxTerrain.LayerSet
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.LayerSelected = [Delegate].Combine(Me.LayerSelected, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.LayerSelected = [Delegate].Remove(Me.LayerSelected, value)
			End RemoveHandler
		End Event

		Public WriteOnly Property World() As __Pointer(Of GEditorWorld)
			Set(value As __Pointer(Of GEditorWorld))
				Me.WorldP = value
			End Set
		End Property

		Public Sub New()
			Me.LayerSelected = Nothing
			Me.ResetToPaint = Nothing
			Me.Rearranged = Nothing
			Me.GUINeedRefreshEvent = Nothing
			Me.PopupLayerIndx = -1
			Me.InitializeComponent()
			Me.TerrainPicker = New FilePickerControl()
			Dim extensions As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BFLBBCNI@mat?$AA@), __Pointer(Of SByte))) }
			Me.TerrainPicker.Text = "Tiles"
			Me.TerrainPicker.Root = "Tiles"
			Me.TerrainPicker.ThumbRoot = "Tiles"
			Me.TerrainPicker.Extensions = extensions
			Me.TerrainPicker.ViewMode = FilePickerControl.Mode.Composite
			Me.TerrainPicker.ThumbMode = ThumbnailServer.ThumbType.Tile
			Dim location As Point = New Point(0, 40)
			Me.TerrainPicker.Location = location
			Me.TerrainPicker.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			AddHandler Me.TerrainPicker.DoubleClickSelection, AddressOf Me.TileDoubleClicked
			AddHandler Me.TerrainPicker.SingleClickSelection, AddressOf Me.TileSingleClicked
			MyBase.SuspendLayout()
			Me.ToolPanel.Controls.Add(Me.TerrainPicker)
			MyBase.ResumeLayout()
			Me.LoadInit()
			Me.SelectedTile = ""
			Me.CurrentForceCount = 0
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing AndAlso Me.components IsNot Nothing Then
				Dim terrainPicker As FilePickerControl = Me.TerrainPicker
				If terrainPicker IsNot Nothing Then
					terrainPicker.Dispose()
				End If
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
			Dim container As Container = New Container()
			Me.components = container
			Me.TypeImageList = New ImageList(container)
			Me.LayerList = New ListView()
			Me.DummyColumn = New ColumnHeader()
			Me.ToolPanel = New Panel()
			Me.DownBtn = New Button()
			Me.UpBtn = New Button()
			Me.DeleteBtn = New Button()
			Me.ReplaceBtn = New Button()
			Me.AddBtn = New Button()
			Me.LayerPopupMenu = New ContextMenu()
			Me.menuitemNormal = New MenuItem()
			Me.menuitemBlocker = New MenuItem()
			Me.menuitemGrass = New MenuItem()
			Me.menuitemDustFree = New MenuItem()
			Me.menuitemFord = New MenuItem()
			Me.menuitemWalker = New MenuItem()
			Me.menuItem6 = New MenuItem()
			Me.menuitemInvisible = New MenuItem()
			Me.ToolPanel.SuspendLayout()
			MyBase.SuspendLayout()
			Me.TypeImageList.ColorDepth = ColorDepth.Depth24Bit
			Dim imageSize As Size = New Size(16, 16)
			Me.TypeImageList.ImageSize = imageSize
			Dim magenta As Color = Color.Magenta
			Me.TypeImageList.TransparentColor = magenta
			Me.LayerList.Alignment = ListViewAlignment.Left
			Me.LayerList.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim values As ColumnHeader() = New ColumnHeader() { Me.DummyColumn }
			Me.LayerList.Columns.AddRange(values)
			Me.LayerList.FullRowSelect = True
			Me.LayerList.GridLines = True
			Me.LayerList.HeaderStyle = ColumnHeaderStyle.None
			Me.LayerList.HideSelection = False
			Me.LayerList.LabelWrap = False
			Dim location As Point = New Point(0, 8)
			Me.LayerList.Location = location
			Me.LayerList.MultiSelect = False
			Me.LayerList.Name = "LayerList"
			Me.LayerList.Scrollable = False
			Dim size As Size = New Size(256, 24)
			Me.LayerList.Size = size
			Me.LayerList.SmallImageList = Me.TypeImageList
			Me.LayerList.TabIndex = 0
			Me.LayerList.View = View.Details
			AddHandler Me.LayerList.Click, AddressOf Me.LayerList_Click
			AddHandler Me.LayerList.SizeChanged, AddressOf Me.LayerList_SizeChanged
			AddHandler Me.LayerList.MouseUp, AddressOf Me.LayerList_MouseUp
			AddHandler Me.LayerList.SelectedIndexChanged, AddressOf Me.LayerList_SelectedIndexChanged
			Me.DummyColumn.Width = 251
			Me.ToolPanel.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.ToolPanel.Controls.Add(Me.DownBtn)
			Me.ToolPanel.Controls.Add(Me.UpBtn)
			Me.ToolPanel.Controls.Add(Me.DeleteBtn)
			Me.ToolPanel.Controls.Add(Me.ReplaceBtn)
			Me.ToolPanel.Controls.Add(Me.AddBtn)
			Dim location2 As Point = New Point(0, 32)
			Me.ToolPanel.Location = location2
			Me.ToolPanel.Name = "ToolPanel"
			Dim size2 As Size = New Size(256, 384)
			Me.ToolPanel.Size = size2
			Me.ToolPanel.TabIndex = 6
			Dim location3 As Point = New Point(224, 8)
			Me.DownBtn.Location = location3
			Me.DownBtn.Name = "DownBtn"
			Dim size3 As Size = New Size(24, 23)
			Me.DownBtn.Size = size3
			Me.DownBtn.TabIndex = 10
			Me.DownBtn.Text = "D"
			AddHandler Me.DownBtn.Click, AddressOf Me.DownBtn_Click
			Dim location4 As Point = New Point(200, 8)
			Me.UpBtn.Location = location4
			Me.UpBtn.Name = "UpBtn"
			Dim size4 As Size = New Size(24, 23)
			Me.UpBtn.Size = size4
			Me.UpBtn.TabIndex = 9
			Me.UpBtn.Text = "U"
			AddHandler Me.UpBtn.Click, AddressOf Me.UpBtn_Click
			Dim location5 As Point = New Point(120, 8)
			Me.DeleteBtn.Location = location5
			Me.DeleteBtn.Name = "DeleteBtn"
			Dim size5 As Size = New Size(56, 23)
			Me.DeleteBtn.Size = size5
			Me.DeleteBtn.TabIndex = 8
			Me.DeleteBtn.Text = "Delete"
			AddHandler Me.DeleteBtn.Click, AddressOf Me.DeleteBtn_Click
			Dim location6 As Point = New Point(64, 8)
			Me.ReplaceBtn.Location = location6
			Me.ReplaceBtn.Name = "ReplaceBtn"
			Dim size6 As Size = New Size(56, 23)
			Me.ReplaceBtn.Size = size6
			Me.ReplaceBtn.TabIndex = 7
			Me.ReplaceBtn.Text = "Replace"
			AddHandler Me.ReplaceBtn.Click, AddressOf Me.ReplaceBtn_Click
			Dim location7 As Point = New Point(8, 8)
			Me.AddBtn.Location = location7
			Me.AddBtn.Name = "AddBtn"
			Dim size7 As Size = New Size(56, 23)
			Me.AddBtn.Size = size7
			Me.AddBtn.TabIndex = 6
			Me.AddBtn.Text = "Add"
			AddHandler Me.AddBtn.Click, AddressOf Me.AddBtn_Click
			Dim items As MenuItem() = New MenuItem() { Me.menuitemNormal, Me.menuitemBlocker, Me.menuitemGrass, Me.menuitemDustFree, Me.menuitemFord, Me.menuitemWalker, Me.menuItem6, Me.menuitemInvisible }
			Me.LayerPopupMenu.MenuItems.AddRange(items)
			AddHandler Me.LayerPopupMenu.Popup, AddressOf Me.ContextMenuPopu
			Me.menuitemNormal.Index = 0
			Me.menuitemNormal.RadioCheck = True
			Me.menuitemNormal.Text = "Normal"
			AddHandler Me.menuitemNormal.Click, AddressOf Me.menuitemNormal_Click
			Me.menuitemBlocker.Index = 1
			Me.menuitemBlocker.RadioCheck = True
			Me.menuitemBlocker.Text = "Blocker"
			AddHandler Me.menuitemBlocker.Click, AddressOf Me.menuitemBlocker_Click
			Me.menuitemGrass.Index = 2
			Me.menuitemGrass.RadioCheck = True
			Me.menuitemGrass.Text = "Grass"
			AddHandler Me.menuitemGrass.Click, AddressOf Me.menuitemGrass_Click
			Me.menuitemDustFree.Index = 3
			Me.menuitemDustFree.RadioCheck = True
			Me.menuitemDustFree.Text = "Dust-free"
			AddHandler Me.menuitemDustFree.Click, AddressOf Me.menuitemDustFree_Click
			Me.menuitemFord.Index = 4
			Me.menuitemFord.RadioCheck = True
			Me.menuitemFord.Text = "Ford"
			AddHandler Me.menuitemFord.Click, AddressOf Me.menuitemFord_Click
			Me.menuitemWalker.Index = 5
			Me.menuitemWalker.RadioCheck = True
			Me.menuitemWalker.Text = "Only walker"
			AddHandler Me.menuitemWalker.Click, AddressOf Me.menuitemWalker_Click
			Me.menuItem6.Index = 6
			Me.menuItem6.Text = "-"
			Me.menuitemInvisible.Index = 7
			Me.menuitemInvisible.Text = "Invisible"
			AddHandler Me.menuitemInvisible.Click, AddressOf Me.menuitemInvisible_Click
			MyBase.Controls.Add(Me.ToolPanel)
			MyBase.Controls.Add(Me.LayerList)
			MyBase.Name = "ToolboxTerrain"
			Dim size8 As Size = New Size(256, 416)
			MyBase.Size = size8
			AddHandler MyBase.Resize, AddressOf Me.ToolboxTerrain_Resize
			Me.ToolPanel.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub UpdateButtons()
			Dim selectedLayer As Integer = Me.GetSelectedLayer()
			If selectedLayer <> 0 AndAlso selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) - 1 Then
				Me.UpBtn.Enabled = True
			Else
				Me.UpBtn.Enabled = False
			End If
			If selectedLayer > 1 AndAlso selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) Then
				Me.DownBtn.Enabled = True
			Else
				Me.DownBtn.Enabled = False
			End If
			If selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) AndAlso <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) >= 2 Then
				Me.DeleteBtn.Enabled = True
			Else
				Me.DeleteBtn.Enabled = False
			End If
			If selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) AndAlso Me.SelectedTile.Length <> 0 Then
				Me.ReplaceBtn.Enabled = True
			Else
				Me.ReplaceBtn.Enabled = False
			End If
			If <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) < 20 AndAlso Me.SelectedTile.Length <> 0 Then
				Me.AddBtn.Enabled = True
			Else
				Me.AddBtn.Enabled = False
			End If
		End Sub

		Private Function GetLayerStyle(indx As Integer) As Integer
			Dim num As Integer = 0
			Dim checked As Byte = If(((<Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, indx) And 31) = 0), 1, 0)
			Me.menuitemNormal.Checked = (checked <> 0)
			If Me.menuitemNormal.Checked Then
				num = 1
			End If
			Me.menuitemBlocker.Checked = ((<Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, indx) And 1) <> 0)
			If Me.menuitemBlocker.Checked Then
				num = 2
			End If
			Dim checked2 As Byte = <Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, indx) >> 2 And 1
			Me.menuitemFord.Checked = (checked2 <> 0)
			If Me.menuitemFord.Checked Then
				num = 3
			End If
			Dim checked3 As Byte = <Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, indx) >> 1 And 1
			Me.menuitemGrass.Checked = (checked3 <> 0)
			If Me.menuitemGrass.Checked Then
				num = 4
			End If
			Dim checked4 As Byte = <Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, indx) >> 4 And 1
			Me.menuitemWalker.Checked = (checked4 <> 0)
			If Me.menuitemWalker.Checked Then
				num = 5
			End If
			Dim checked5 As Byte = <Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, indx) >> 3 And 1
			Me.menuitemDustFree.Checked = (checked5 <> 0)
			If Me.menuitemDustFree.Checked Then
				num = 6
			End If
			Dim checked6 As Byte = <Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, indx) >> 7 And 1
			Me.menuitemInvisible.Checked = (checked6 <> 0)
			If Me.menuitemInvisible.Checked Then
				num += 6
			End If
			Return num
		End Function

		Private Sub SetLayerStyle(indx As Integer)
			Dim layerStyle As Integer = Me.GetLayerStyle(indx)
			Me.LayerList.Items(Me.PopupLayerIndx).ImageIndex = layerStyle
			Me.LayerList.Items(Me.PopupLayerIndx).StateImageIndex = layerStyle
		End Sub

		Public Sub LoadInit()
			Dim imageServer As ImageServer = ImageServer.GetImageServer("Images")
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0L@DBPODKKK@LayerEmpty?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0M@PFFBNMCL@LayerNormal?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0N@LHBDMIPF@LayerBlocker?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_09BNICPIFC@LayerFord?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0L@IJIDFFAH@LayerGrass?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0M@BEOOIFHK@LayerWalker?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0O@JGFPCMMM@LayerDustFree?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0P@NIMJGNGI@LayerNormalInv?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0BA@OJKCICPJ@LayerBlockerInv?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0N@GNNLFMJH@LayerFordInv?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0O@GLACECGK@LayerGrassInv?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0P@IFBAGBAO@LayerWalkerInv?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Me.TypeImageList.Images.Add(imageServer.GetImage(New String(CType((AddressOf <Module>.??_C@_0BB@IHGAGHJE@LayerDustFreeInv?$AA@), __Pointer(Of SByte))), KnownColor.Window))
			Dim toolTip As ToolTip = New ToolTip()
			Me.SelectionTT = toolTip
			toolTip.AutoPopDelay = 0
			Me.SelectionTT.InitialDelay = 0
			Me.SelectionTT.ReshowDelay = 0
			Me.SelectionTT.SetToolTip(Me.AddBtn, "")
			Me.SelectionTT.SetToolTip(Me.ReplaceBtn, "")
			Me.SelectionTT.ShowAlways = True
		End Sub

		Public Sub UpdateLayerList(selection As Integer, forcecount As Integer)
			Dim text As String = ""
			If selection < 0 AndAlso Me.LayerList.SelectedItems.Count > 0 Then
				text = Me.LayerList.SelectedItems(0).Text
			End If
			Me.LayerList.Items.Clear()
			Dim num As Integer = <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP)
			Dim num2 As Integer = 1
			Me.LayerList.SuspendLayout()
			Dim num3 As Integer = 19
			Do
				If num3 < num Then
					Dim listViewItem As ListViewItem = New ListViewItem()
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GEditorWorld.GetTileLayerName(Me.WorldP, AddressOf gBaseString<char>, num3)
					Try
						Dim num4 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
						Dim value As __Pointer(Of SByte)
						If num4 <> 0UI Then
							value = num4
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						listViewItem.Text = New String(CType(value, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
						gBaseString<char> = 0
					End If
					Dim layerStyle As Integer = Me.GetLayerStyle(num3)
					listViewItem.ImageIndex = layerStyle
					listViewItem.StateImageIndex = layerStyle
					If selection < 0 AndAlso text.Length > 0 AndAlso String.Compare(listViewItem.Text, text) = 0 Then
						listViewItem.Selected = True
					End If
					Me.LayerList.Items.Add(listViewItem)
				Else If num2 > 0 Then
					Dim listViewItem2 As ListViewItem = New ListViewItem()
					listViewItem2.Text = "New Layer"
					listViewItem2.ImageIndex = 0
					listViewItem2.StateImageIndex = 0
					Me.LayerList.Items.Add(listViewItem2)
					num2 -= 1
				End If
				num3 -= 1
			Loop While num3 > -1
			If selection >= 0 Then
				Me.SelectLayer(selection)
			End If
			If Me.LayerList.SelectedItems.Count < 1 Then
				Me.SelectLayer(-1)
			End If
			Me.UpdateButtons()
			Me.LayerList.ResumeLayout()
			Me.Rearrange()
			Me.raise_LayerSelected(Me.GetSelectedLayer())
		End Sub

		Public Function GetSelectedLayer() As Integer
			If Me.LayerList.SelectedIndices.Count > 0 Then
				Dim num As Integer = -1 - Me.LayerList.SelectedIndices(0)
				Return Me.LayerList.Items.Count + num
			End If
			Return 20
		End Function

		Public Sub SelectLayer(layer As Integer)
			If layer < 0 Then
				Me.LayerList.Items(Me.LayerList.Items.Count - 1).Selected = True
			Else If layer > Me.LayerList.Items.Count - 1 Then
				Me.LayerList.Items(0).Selected = True
			Else
				Me.LayerList.Items(Me.LayerList.Items.Count - layer - 1).Selected = True
			End If
		End Sub

		Public Sub UpdateLayerUsage(flags As UInteger)
			Dim num As Integer = <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP)
			Me.LayerList.BeginUpdate()
			Dim num2 As Integer = Me.LayerList.Items.Count - 1
			If num2 >= 0 Then
				Dim num3 As Integer = -1 - num2
				Do
					If num2 < num Then
						If(1 << num2 And flags) IsNot Nothing Then
							Dim font As Font = Me.LayerList.Items(Me.LayerList.Items.Count + num3).Font
							Me.LayerList.Items(Me.LayerList.Items.Count + num3).Font = New Font(font, FontStyle.Bold)
						Else
							Dim font2 As Font = Me.LayerList.Items(Me.LayerList.Items.Count + num3).Font
							Me.LayerList.Items(Me.LayerList.Items.Count + num3).Font = New Font(font2, FontStyle.Regular)
						End If
					End If
					num2 -= 1
					num3 += 1
				Loop While num2 >= 0
			End If
			Me.LayerList.EndUpdate()
		End Sub

		Public Sub Rearrange()
			MyBase.SuspendLayout()
			Dim itemRect As Rectangle = Me.LayerList.GetItemRect(0)
			Dim num As Integer = Me.LayerList.Items.Count - 1
			Dim num2 As Integer = itemRect.Height * num
			Dim size As Size = MyBase.Size
			Dim num3 As Integer = num2 + 416
			Dim size2 As Size = New Size(size.Width, num3)
			MyBase.Size = size2
			Dim location As Point = New Point(0, num2 + 40)
			Me.ToolPanel.Location = location
			Dim size3 As Size = New Size(MyBase.Size.Width, 400)
			Me.ToolPanel.Size = size3
			Dim pt As Point = New Point(MyBase.Size.Width, num2 + 24)
			Dim size4 As Size = New Size(pt)
			Me.LayerList.Size = size4
			MyBase.ResumeLayout()
			Me.raise_Rearranged(Me, num3)
		End Sub

		Public Sub [Resume]()
			Me.raise_LayerSelected(Me.GetSelectedLayer())
		End Sub

		Private Sub LayerList_SizeChanged(sender As Object, e As EventArgs)
			Dim displayRectangle As Rectangle = Me.LayerList.DisplayRectangle
			Me.LayerList.Columns(0).Width = displayRectangle.Width
		End Sub

		Private Sub TileDoubleClicked(TileName As String)
			Me.SelectedTile = TileName
			Me.UpdateButtons()
			Me.SelectionTT.SetToolTip(Me.AddBtn, "Add " + TileName)
			Me.SelectionTT.SetToolTip(Me.ReplaceBtn, "Replace with " + TileName)
			If Me.GetSelectedLayer() < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) Then
				Me.ReplaceBtn_Click(Me, New EventArgs())
			Else
				Me.AddBtn_Click(Me, New EventArgs())
			End If
		End Sub

		Private Sub TileSingleClicked(TileName As String)
			Me.SelectedTile = TileName
			Me.UpdateButtons()
			Me.SelectionTT.SetToolTip(Me.AddBtn, "Add " + TileName)
			Me.SelectionTT.SetToolTip(Me.ReplaceBtn, "Replace with " + TileName)
		End Sub

		Private Sub AddBtn_Click(sender As Object, e As EventArgs)
			If <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) < 20 Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.SelectedTile)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Me.UpdateLayerList(<Module>.GEditorWorld.AddTileLayer(Me.WorldP, ptr2, 0), Me.CurrentForceCount)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Me.raise_GUINeedRefreshEvent()
			End If
		End Sub

		Private Sub ReplaceBtn_Click(sender As Object, e As EventArgs)
			Dim selectedLayer As Integer = Me.GetSelectedLayer()
			If Me.SelectedTile.Length > 0 AndAlso selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.SelectedTile)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					<Module>.GEditorWorld.SetTileLayer(Me.WorldP, selectedLayer, ptr2)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Me.UpdateLayerList(selectedLayer, Me.CurrentForceCount)
				Me.raise_GUINeedRefreshEvent()
			End If
		End Sub

		Private Sub DeleteBtn_Click(sender As Object, e As EventArgs)
			Dim selectedLayer As Integer = Me.GetSelectedLayer()
			If selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) AndAlso (selectedLayer <> 0 OrElse MessageBox.Show("Deleting the bottom layer removes the painting of the next layer!" & vbLf & vbLf & "Are you sure you want to delete the bottom layer?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.Yes) Then
				<Module>.GEditorWorld.RemoveTileLayer(Me.WorldP, selectedLayer)
				Me.UpdateLayerList(-1, Me.CurrentForceCount)
				Me.raise_GUINeedRefreshEvent()
			End If
		End Sub

		Private Sub UpBtn_Click(sender As Object, e As EventArgs)
			Dim selectedLayer As Integer = Me.GetSelectedLayer()
			If selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) - 1 Then
				Me.UpdateLayerList(<Module>.GEditorWorld.MoveTileLayer(Me.WorldP, selectedLayer, 1), Me.CurrentForceCount)
				Me.raise_GUINeedRefreshEvent()
			End If
		End Sub

		Private Sub DownBtn_Click(sender As Object, e As EventArgs)
			Dim selectedLayer As Integer = Me.GetSelectedLayer()
			If selectedLayer < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) AndAlso selectedLayer > 0 Then
				Me.UpdateLayerList(<Module>.GEditorWorld.MoveTileLayer(Me.WorldP, selectedLayer, -1), Me.CurrentForceCount)
				Me.raise_GUINeedRefreshEvent()
			End If
		End Sub

		Private Sub LayerList_SelectedIndexChanged(sender As Object, e As EventArgs)
			Me.UpdateButtons()
			Me.raise_LayerSelected(Me.GetSelectedLayer())
		End Sub

		Private Sub LayerList_MouseUp(sender As Object, e As MouseEventArgs)
			If e.Button = MouseButtons.Right Then
				Dim itemAt As ListViewItem = Me.LayerList.GetItemAt(e.X, e.Y)
				If itemAt IsNot Nothing Then
					Me.PopupLayerIndx = itemAt.Index
					Dim pos As Point = New Point(e.X, e.Y)
					Me.LayerPopupMenu.Show(Me.LayerList, pos)
				Else
					Me.PopupLayerIndx = -1
				End If
			End If
		End Sub

		Private Sub ContextMenuPopu(sender As Object, e As EventArgs)
			Dim num As Integer = Me.LayerList.Items.Count - Me.PopupLayerIndx - 1
			If num < <Module>.GEditorWorld.GetNumOfTileLayers(Me.WorldP) AndAlso num <> 0 Then
				Dim num2 As Integer = 0
				If 0 < Me.LayerPopupMenu.MenuItems.Count Then
					Do
						Me.LayerPopupMenu.MenuItems(num2).Enabled = True
						num2 += 1
					Loop While num2 < Me.LayerPopupMenu.MenuItems.Count
				End If
				Me.SetLayerStyle(num)
			Else
				Dim num3 As Integer = 0
				If 0 < Me.LayerPopupMenu.MenuItems.Count Then
					Do
						Me.LayerPopupMenu.MenuItems(num3).Checked = False
						Me.LayerPopupMenu.MenuItems(num3).Enabled = False
						num3 += 1
					Loop While num3 < Me.LayerPopupMenu.MenuItems.Count
				End If
			End If
		End Sub

		Private Sub menuitemNormal_Click(sender As Object, e As EventArgs)
			Dim num As Integer = Me.LayerList.Items.Count - Me.PopupLayerIndx - 1
			If Me.menuitemInvisible.Checked Then
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 128)
			Else
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 0)
			End If
			Me.SetLayerStyle(num)
			Me.raise_GUINeedRefreshEvent()
		End Sub

		Private Sub menuitemBlocker_Click(sender As Object, e As EventArgs)
			Dim num As Integer = Me.LayerList.Items.Count - Me.PopupLayerIndx - 1
			If Me.menuitemInvisible.Checked Then
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 129)
			Else
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 1)
			End If
			Me.SetLayerStyle(num)
			Me.raise_GUINeedRefreshEvent()
		End Sub

		Private Sub menuitemGrass_Click(sender As Object, e As EventArgs)
			Dim num As Integer = Me.LayerList.Items.Count - Me.PopupLayerIndx - 1
			If Me.menuitemInvisible.Checked Then
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 130)
			Else
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 2)
			End If
			Me.SetLayerStyle(num)
			Me.raise_GUINeedRefreshEvent()
		End Sub

		Private Sub menuitemDustFree_Click(sender As Object, e As EventArgs)
			Dim num As Integer = Me.LayerList.Items.Count - Me.PopupLayerIndx - 1
			If Me.menuitemInvisible.Checked Then
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 136)
			Else
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 8)
			End If
			Me.SetLayerStyle(num)
			Me.raise_GUINeedRefreshEvent()
		End Sub

		Private Sub menuitemFord_Click(sender As Object, e As EventArgs)
			Dim num As Integer = Me.LayerList.Items.Count - Me.PopupLayerIndx - 1
			If Me.menuitemInvisible.Checked Then
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 132)
			Else
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 4)
			End If
			Me.SetLayerStyle(num)
			Me.raise_GUINeedRefreshEvent()
		End Sub

		Private Sub menuitemWalker_Click(sender As Object, e As EventArgs)
			Dim num As Integer = Me.LayerList.Items.Count - Me.PopupLayerIndx - 1
			If Me.menuitemInvisible.Checked Then
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 144)
			Else
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, 16)
			End If
			Me.SetLayerStyle(num)
			Me.raise_GUINeedRefreshEvent()
		End Sub

		Private Sub menuitemInvisible_Click(sender As Object, e As EventArgs)
			Dim num As Integer = Me.LayerList.Items.Count - Me.PopupLayerIndx - 1
			If Me.menuitemInvisible.Checked Then
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, <Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, num) And -129)
			Else
				<Module>.GEditorWorld.SetTileLayerFlags(Me.WorldP, num, <Module>.GEditorWorld.GetTileLayerFlags(Me.WorldP, num) Or 128)
			End If
			Me.SetLayerStyle(num)
			Me.raise_GUINeedRefreshEvent()
		End Sub

		Private Sub ToolboxTerrain_Resize(sender As Object, e As EventArgs)
		End Sub

		Private Sub LayerList_Click(sender As Object, e As EventArgs)
			Me.raise_ResetToPaint()
		End Sub

		Protected Sub raise_LayerSelected(i1 As Integer)
			Dim layerSelected As ToolboxTerrain.LayerSet = Me.LayerSelected
			If layerSelected IsNot Nothing Then
				layerSelected(i1)
			End If
		End Sub

		Protected Sub raise_ResetToPaint()
			Dim resetToPaint As ToolboxTerrain.ResumePaint = Me.ResetToPaint
			If resetToPaint IsNot Nothing Then
				resetToPaint()
			End If
		End Sub

		Protected Sub raise_Rearranged(i1 As Object, i2 As Integer)
			Dim rearranged As ToolRearranged = Me.Rearranged
			If rearranged IsNot Nothing Then
				rearranged(i1, i2)
			End If
		End Sub

		Protected Sub raise_GUINeedRefreshEvent()
			Dim gUINeedRefreshEvent As ToolboxTerrain.GUINeedRefreshHandler = Me.GUINeedRefreshEvent
			If gUINeedRefreshEvent IsNot Nothing Then
				gUINeedRefreshEvent()
			End If
		End Sub
	End Class
End Namespace
