Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NewAssetPicker
		Inherits Form

		Public Enum ObjectType
			CloudLoader = 8
			EnvMapLoader = 7
			SkyBoxLoader = 6
			OptionsEditor = 5
			MissionVariablesEditor = 4
			GameVariablesEditor = 3
			EffectEditor = 2
			UnitEditor = 1
			MissingAsset = 0
		End Enum

		Private AcceptBtn As Button

		Private CancelBtn As Button

		Private components As Container

		Private control As FilePickerControl

		Private propNewFile As String

		Public ReadOnly Property NewName() As String
			Get
				Return Me.propNewFile
			End Get
		End Property

		Public Sub New(objecttype As NewAssetPicker.ObjectType, filetype As Integer)
			Me.InitializeComponent()
			Me.AcceptBtn.Enabled = False
			Dim filePickerControl As FilePickerControl = New FilePickerControl()
			Me.control = filePickerControl
			filePickerControl.ViewMode = FilePickerControl.Mode.Composite
			Select Case objecttype
				Case NewAssetPicker.ObjectType.MissingAsset
					Select Case filetype
						Case 0
							Dim extensions As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BICDMHKB@wav?$AA@), __Pointer(Of SByte))) }
							Me.Text = "Select new sound"
							Me.control.Root = "sounds"
							Me.control.ThumbRoot = "Sounds"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Sound
							Me.control.Extensions = extensions
						Case 1
							Dim extensions2 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BFLBBCNI@mat?$AA@), __Pointer(Of SByte))) }
							Me.Text = "Select new decal"
							Me.control.Root = "decals"
							Me.control.ThumbRoot = "Decals"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Material
							Me.control.Extensions = extensions2
						Case 2
							Dim extensions3 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03MBBDFFBP@4dp?$AA@), __Pointer(Of SByte))), New String(CType((AddressOf <Module>.??_C@_02CCENMFAC@4d?$AA@), __Pointer(Of SByte))) }
							Me.Text = "Select new object"
							Me.control.Root = "objects"
							Me.control.ThumbRoot = "Objects"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Model
							Me.control.Extensions = extensions3
						Case 3
							Dim extensions4 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BFLBBCNI@mat?$AA@), __Pointer(Of SByte))) }
							Me.Text = "Select new road"
							Me.control.Root = "roads"
							Me.control.ThumbRoot = "Roads"
							Me.control.ViewMode = FilePickerControl.Mode.Composite
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Tile
							Me.control.Extensions = extensions4
						Case 4
							Dim extensions5 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BFLBBCNI@mat?$AA@), __Pointer(Of SByte))) }
							Me.Text = "Select new tile"
							Me.control.Root = "tiles"
							Me.control.ThumbRoot = "Tiles"
							Me.control.ViewMode = FilePickerControl.Mode.Composite
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Tile
							Me.control.Extensions = extensions5
						Case 5
							Dim extensions6 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_04NPEDKLDA@unit?$AA@), __Pointer(Of SByte))) }
							Me.Text = "Select new unit"
							Me.control.Root = "units"
							Me.control.ThumbRoot = "Units"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Unit
							Me.control.Extensions = extensions6
						Case 6
							Dim extensions7 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_04NPEDKLDA@unit?$AA@), __Pointer(Of SByte))) }
							Me.Text = "Select new building"
							Me.control.Root = "buildings"
							Me.control.ThumbRoot = "Buildings"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Unit
							Me.control.Extensions = extensions7
						Case 7
							Dim extensions8 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_02KLACGCIB@fx?$AA@), __Pointer(Of SByte))) }
							Me.Text = "Select new effect"
							Me.control.Root = "effects"
							Me.control.ThumbRoot = "Effects"
							Me.control.ViewMode = FilePickerControl.Mode.Composite
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Effect
							Me.control.Extensions = extensions8
					End Select
				Case NewAssetPicker.ObjectType.UnitEditor
					Select Case filetype
						Case 27
							Dim extensions9 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03MBBDFFBP@4dp?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Models"
							Me.control.Root = "units_data"
							Me.control.ThumbRoot = "units"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Model
							Me.control.Extensions = extensions9
						Case 28
							Dim extensions10 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_02KLACGCIB@fx?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Effects"
							Me.control.Root = "effects"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Effect
							Me.control.Extensions = extensions10
						Case 29
							Dim extensions11 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03LJIJAGL@tga?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Textures"
							Me.control.Root = "units_data"
							Me.control.ThumbRoot = "units"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Material
							Me.control.Extensions = extensions11
						Case 30
							Dim extensions12 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_04NPEDKLDA@unit?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Units"
							Me.control.Root = "units"
							Me.control.ThumbRoot = "units"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Unit
							Me.control.FilterNonEditableUnits = False
							Me.control.Extensions = extensions12
						Case 31
							Dim extensions13 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BICDMHKB@wav?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Sound"
							Me.control.Root = "sounds"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Sound
							Me.control.Extensions = extensions13
						Case 33
							Dim extensions14 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BFLBBCNI@mat?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Materials"
							Me.control.Root = "units_data"
							Me.control.ThumbRoot = "units"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Material
							Me.control.Extensions = extensions14
					End Select
				Case NewAssetPicker.ObjectType.EffectEditor
					Select Case filetype
						Case 27
							Dim extensions15 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03MBBDFFBP@4dp?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Models"
							Me.control.Root = "effects_data"
							Me.control.ThumbRoot = "effects"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Model
							Me.control.Extensions = extensions15
						Case 29
							Dim extensions16 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03LJIJAGL@tga?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Textures"
							Me.control.Root = "effects_data"
							Me.control.ThumbRoot = "effects"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Material
							Me.control.Extensions = extensions16
						Case 31
							Dim extensions17 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BICDMHKB@wav?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Sound"
							Me.control.Root = "sounds"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Sound
							Me.control.Extensions = extensions17
						Case 33
							Dim extensions18 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BFLBBCNI@mat?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Materials"
							Me.control.Root = "decals"
							Me.control.ThumbRoot = "effects"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Material
							Me.control.Extensions = extensions18
						Case 34
							Dim extensions19 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_08PKKGOGAD@particle?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Particles"
							Me.control.Root = "effects_data"
							Me.control.ThumbRoot = "effects"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Material
							Me.control.Extensions = extensions19
					End Select
				Case NewAssetPicker.ObjectType.GameVariablesEditor
					If filetype <> 30 Then
						If filetype = 36 Then
							Dim extensions20 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03HBNNNHNM@map?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Maps"
							Me.control.Root = "maps"
							Me.control.ThumbRoot = "map"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Map
							Me.control.Extensions = extensions20
						End If
					Else
						Dim extensions21 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_04NPEDKLDA@unit?$AA@), __Pointer(Of SByte))) }
						Me.control.Text = "Units"
						Me.control.Root = "units"
						Me.control.ThumbRoot = "units"
						Me.control.ThumbMode = ThumbnailServer.ThumbType.Unit
						Me.control.FilterNonEditableUnits = False
						Me.control.Extensions = extensions21
					End If
				Case NewAssetPicker.ObjectType.MissionVariablesEditor
					Select Case filetype
						Case 28
							Dim extensions22 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_02KLACGCIB@fx?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Effects"
							Me.control.Root = "effects"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Effect
							Me.control.Extensions = extensions22
						Case 30
							Dim extensions23 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_04NPEDKLDA@unit?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Units"
							Me.control.Root = "units"
							Me.control.ThumbRoot = "units"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Unit
							Me.control.FilterNonEditableUnits = False
							Me.control.Extensions = extensions23
						Case 31
							Dim extensions24 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BICDMHKB@wav?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Music"
							Me.control.Root = "music"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Sound
							Me.control.Extensions = extensions24
						Case 32
							Dim extensions25 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03BICDMHKB@wav?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Speech"
							Me.control.Root = "sounds/dialog"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Sound
							Me.control.Extensions = extensions25
						Case 35
							Dim extensions26 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03KCBANMCB@loc?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Locales"
							Me.control.Root = "locales"
							Me.control.ThumbRoot = "locales"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Locale
							Me.control.Extensions = extensions26
						Case 36
							Dim extensions27 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03HBNNNHNM@map?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Maps"
							Me.control.Root = "maps"
							Me.control.ThumbRoot = "map"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Map
							Me.control.Extensions = extensions27
						Case 37
							Dim extensions28 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03LJIJAGL@tga?$AA@), __Pointer(Of SByte))) }
							Me.control.Text = "Backgrounds"
							Me.control.Root = "menu/backgrounds"
							Me.control.ThumbRoot = "backgrounds"
							Me.control.ThumbMode = ThumbnailServer.ThumbType.Material
							Me.control.Extensions = extensions28
					End Select
				Case NewAssetPicker.ObjectType.SkyBoxLoader
					Dim extensions29 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03LJIJAGL@tga?$AA@), __Pointer(Of SByte))) }
					Me.Text = "Select new skybox texture"
					Me.control.Root = "skybox"
					Me.control.ThumbRoot = "skybox"
					Me.control.ThumbMode = ThumbnailServer.ThumbType.Box
					Me.control.Extensions = extensions29
				Case NewAssetPicker.ObjectType.EnvMapLoader
					Dim extensions30 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03LJIJAGL@tga?$AA@), __Pointer(Of SByte))) }
					Me.Text = "Select new environment map texture"
					Me.control.Root = "envmap"
					Me.control.ThumbRoot = "envmap"
					Me.control.ThumbMode = ThumbnailServer.ThumbType.Box
					Me.control.Extensions = extensions30
				Case NewAssetPicker.ObjectType.CloudLoader
					Dim extensions31 As String() = New String() { New String(CType((AddressOf <Module>.??_C@_03LJIJAGL@tga?$AA@), __Pointer(Of SByte))) }
					Me.Text = "Select new cloud texture"
					Me.control.Root = "clouds"
					Me.control.ThumbRoot = "clouds"
					Me.control.ThumbMode = ThumbnailServer.ThumbType.Cloud
					Me.control.Extensions = extensions31
			End Select
			Me.control.ViewMode = FilePickerControl.Mode.Treeview
			AddHandler Me.control.SingleClickSelection, AddressOf Me.FileSelectedSingle
			AddHandler Me.control.DoubleClickSelection, AddressOf Me.FileSelectedDouble
			MyBase.Controls.Add(Me.control)
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing AndAlso Me.components IsNot Nothing Then
				Me.control.Dispose()
				Me.components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
			Me.AcceptBtn = New Button()
			Me.CancelBtn = New Button()
			MyBase.SuspendLayout()
			Me.AcceptBtn.DialogResult = DialogResult.OK
			Me.AcceptBtn.FlatStyle = FlatStyle.System
			Dim location As Point = New Point(8, 336)
			Me.AcceptBtn.Location = location
			Me.AcceptBtn.Name = "AcceptBtn"
			Dim size As Size = New Size(104, 23)
			Me.AcceptBtn.Size = size
			Me.AcceptBtn.TabIndex = 0
			Me.AcceptBtn.Text = "Select"
			Me.CancelBtn.DialogResult = DialogResult.Cancel
			Me.CancelBtn.FlatStyle = FlatStyle.System
			Dim location2 As Point = New Point(144, 336)
			Me.CancelBtn.Location = location2
			Me.CancelBtn.Name = "CancelBtn"
			Dim size2 As Size = New Size(104, 23)
			Me.CancelBtn.Size = size2
			Me.CancelBtn.TabIndex = 1
			Me.CancelBtn.Text = "Cancel"
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(256, 368)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.CancelBtn)
			MyBase.Controls.Add(Me.AcceptBtn)
			MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "NewAssetPicker"
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Select new "
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub FileSelectedSingle(FileName As String)
			Me.propNewFile = Me.control.Root + "/" + FileName
			Me.AcceptBtn.Enabled = True
		End Sub

		Private Sub FileSelectedDouble(FileName As String)
			Me.propNewFile = Me.control.Root + "/" + FileName
			MyBase.DialogResult = DialogResult.OK
			MyBase.Close()
		End Sub

		Public Sub Reset()
			Me.propNewFile = ""
			Me.AcceptBtn.Enabled = False
		End Sub
	End Class
End Namespace
