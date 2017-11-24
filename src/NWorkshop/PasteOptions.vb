Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class PasteOptions
		Inherits Form

		Private TerrainGroup As GroupBox

		Private WaterGroup As GroupBox

		Private ObjectGroup As GroupBox

		Private StructGroup As GroupBox

		Private MiscGroup As GroupBox

		Private HeightCheck As CheckBox

		Private LayersCheck As CheckBox

		Private ColorCheck As CheckBox

		Private LakeCheck As CheckBox

		Private RiverCheck As CheckBox

		Private RoadCheck As CheckBox

		Private BuildCheck As CheckBox

		Private WireCheck As CheckBox

		Private ObjectCheck As CheckBox

		Private DecalCheck As CheckBox

		Private UnitCheck As CheckBox

		Private SoundCheck As CheckBox

		Private EffectCheck As CheckBox

		Private OKBtn As Button

		Private NOBtn As Button

		Private components As Container

		Private propPasteOptionFlags As UInteger

		Private Lock As Boolean

		Public Property PasteOptionFlags() As UInteger
			Get
				Return Me.propPasteOptionFlags
			End Get
			Set(value As UInteger)
				Me.propPasteOptionFlags = value
				Me.Lock = True
				Me.HeightCheck.Checked = ((value And 1) <> 0)
				Dim checked As Byte = CByte((Me.propPasteOptionFlags >> 1 And 1UI))
				Me.LayersCheck.Checked = (checked <> 0)
				Dim checked2 As Byte = CByte((Me.propPasteOptionFlags >> 2 And 1UI))
				Me.ColorCheck.Checked = (checked2 <> 0)
				Dim checked3 As Byte = CByte((Me.propPasteOptionFlags >> 3 And 1UI))
				Me.DecalCheck.Checked = (checked3 <> 0)
				Dim checked4 As Byte = CByte((Me.propPasteOptionFlags >> 4 And 1UI))
				Me.LakeCheck.Checked = (checked4 <> 0)
				Dim checked5 As Byte = CByte((Me.propPasteOptionFlags >> 5 And 1UI))
				Me.RiverCheck.Checked = (checked5 <> 0)
				Dim checked6 As Byte = CByte((Me.propPasteOptionFlags >> 6 And 1UI))
				Me.RoadCheck.Checked = (checked6 <> 0)
				Dim checked7 As Byte = CByte((Me.propPasteOptionFlags >> 7 And 1UI))
				Me.BuildCheck.Checked = (checked7 <> 0)
				Dim checked8 As Byte = CByte((Me.propPasteOptionFlags >> 8 And 1UI))
				Me.WireCheck.Checked = (checked8 <> 0)
				Dim checked9 As Byte = CByte((Me.propPasteOptionFlags >> 9 And 1UI))
				Me.ObjectCheck.Checked = (checked9 <> 0)
				Dim checked10 As Byte = CByte((Me.propPasteOptionFlags >> 10 And 1UI))
				Me.UnitCheck.Checked = (checked10 <> 0)
				Dim checked11 As Byte = CByte((Me.propPasteOptionFlags >> 11 And 1UI))
				Me.SoundCheck.Checked = (checked11 <> 0)
				Dim checked12 As Byte = CByte((Me.propPasteOptionFlags >> 12 And 1UI))
				Me.EffectCheck.Checked = (checked12 <> 0)
				Dim checked13 As Byte = CByte((Me.propPasteOptionFlags >> 12 And 1UI))
				Me.EffectCheck.Checked = (checked13 <> 0)
				Me.Lock = False
			End Set
		End Property

		Public Sub New()
			Me.InitializeComponent()
			Me.Lock = False
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
			Me.TerrainGroup = New GroupBox()
			Me.DecalCheck = New CheckBox()
			Me.ColorCheck = New CheckBox()
			Me.LayersCheck = New CheckBox()
			Me.HeightCheck = New CheckBox()
			Me.WaterGroup = New GroupBox()
			Me.RiverCheck = New CheckBox()
			Me.LakeCheck = New CheckBox()
			Me.ObjectGroup = New GroupBox()
			Me.UnitCheck = New CheckBox()
			Me.ObjectCheck = New CheckBox()
			Me.StructGroup = New GroupBox()
			Me.WireCheck = New CheckBox()
			Me.BuildCheck = New CheckBox()
			Me.RoadCheck = New CheckBox()
			Me.MiscGroup = New GroupBox()
			Me.EffectCheck = New CheckBox()
			Me.SoundCheck = New CheckBox()
			Me.OKBtn = New Button()
			Me.NOBtn = New Button()
			Me.TerrainGroup.SuspendLayout()
			Me.WaterGroup.SuspendLayout()
			Me.ObjectGroup.SuspendLayout()
			Me.StructGroup.SuspendLayout()
			Me.MiscGroup.SuspendLayout()
			MyBase.SuspendLayout()
			Me.TerrainGroup.Controls.Add(Me.DecalCheck)
			Me.TerrainGroup.Controls.Add(Me.ColorCheck)
			Me.TerrainGroup.Controls.Add(Me.LayersCheck)
			Me.TerrainGroup.Controls.Add(Me.HeightCheck)
			Me.TerrainGroup.FlatStyle = FlatStyle.System
			Dim location As Point = New Point(8, 8)
			Me.TerrainGroup.Location = location
			Me.TerrainGroup.Name = "TerrainGroup"
			Dim size As Size = New Size(112, 120)
			Me.TerrainGroup.Size = size
			Me.TerrainGroup.TabIndex = 0
			Me.TerrainGroup.TabStop = False
			Me.TerrainGroup.Text = "Terrain"
			Me.DecalCheck.FlatStyle = FlatStyle.System
			Dim location2 As Point = New Point(8, 88)
			Me.DecalCheck.Location = location2
			Me.DecalCheck.Name = "DecalCheck"
			Dim size2 As Size = New Size(96, 24)
			Me.DecalCheck.Size = size2
			Me.DecalCheck.TabIndex = 3
			Me.DecalCheck.Text = "Decals"
			AddHandler Me.DecalCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.ColorCheck.FlatStyle = FlatStyle.System
			Dim location3 As Point = New Point(8, 64)
			Me.ColorCheck.Location = location3
			Me.ColorCheck.Name = "ColorCheck"
			Dim size3 As Size = New Size(96, 24)
			Me.ColorCheck.Size = size3
			Me.ColorCheck.TabIndex = 2
			Me.ColorCheck.Text = "Vertex color"
			AddHandler Me.ColorCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.LayersCheck.FlatStyle = FlatStyle.System
			Dim location4 As Point = New Point(8, 40)
			Me.LayersCheck.Location = location4
			Me.LayersCheck.Name = "LayersCheck"
			Dim size4 As Size = New Size(96, 24)
			Me.LayersCheck.Size = size4
			Me.LayersCheck.TabIndex = 1
			Me.LayersCheck.Text = "Terrain layers"
			AddHandler Me.LayersCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.HeightCheck.FlatStyle = FlatStyle.System
			Dim location5 As Point = New Point(8, 16)
			Me.HeightCheck.Location = location5
			Me.HeightCheck.Name = "HeightCheck"
			Dim size5 As Size = New Size(96, 24)
			Me.HeightCheck.Size = size5
			Me.HeightCheck.TabIndex = 0
			Me.HeightCheck.Text = "Height map"
			AddHandler Me.HeightCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.WaterGroup.Controls.Add(Me.RiverCheck)
			Me.WaterGroup.Controls.Add(Me.LakeCheck)
			Me.WaterGroup.FlatStyle = FlatStyle.System
			Dim location6 As Point = New Point(8, 128)
			Me.WaterGroup.Location = location6
			Me.WaterGroup.Name = "WaterGroup"
			Dim size6 As Size = New Size(112, 72)
			Me.WaterGroup.Size = size6
			Me.WaterGroup.TabIndex = 1
			Me.WaterGroup.TabStop = False
			Me.WaterGroup.Text = "Water"
			Me.RiverCheck.FlatStyle = FlatStyle.System
			Dim location7 As Point = New Point(8, 40)
			Me.RiverCheck.Location = location7
			Me.RiverCheck.Name = "RiverCheck"
			Dim size7 As Size = New Size(96, 24)
			Me.RiverCheck.Size = size7
			Me.RiverCheck.TabIndex = 1
			Me.RiverCheck.Text = "Rivers"
			AddHandler Me.RiverCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.LakeCheck.FlatStyle = FlatStyle.System
			Dim location8 As Point = New Point(8, 16)
			Me.LakeCheck.Location = location8
			Me.LakeCheck.Name = "LakeCheck"
			Dim size8 As Size = New Size(96, 24)
			Me.LakeCheck.Size = size8
			Me.LakeCheck.TabIndex = 0
			Me.LakeCheck.Text = "Lakes"
			AddHandler Me.LakeCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.ObjectGroup.Controls.Add(Me.UnitCheck)
			Me.ObjectGroup.Controls.Add(Me.ObjectCheck)
			Me.ObjectGroup.FlatStyle = FlatStyle.System
			Dim location9 As Point = New Point(8, 296)
			Me.ObjectGroup.Location = location9
			Me.ObjectGroup.Name = "ObjectGroup"
			Dim size9 As Size = New Size(112, 72)
			Me.ObjectGroup.Size = size9
			Me.ObjectGroup.TabIndex = 2
			Me.ObjectGroup.TabStop = False
			Me.ObjectGroup.Text = "Objects"
			Me.UnitCheck.FlatStyle = FlatStyle.System
			Dim location10 As Point = New Point(8, 40)
			Me.UnitCheck.Location = location10
			Me.UnitCheck.Name = "UnitCheck"
			Dim size10 As Size = New Size(96, 24)
			Me.UnitCheck.Size = size10
			Me.UnitCheck.TabIndex = 1
			Me.UnitCheck.Text = "Units"
			AddHandler Me.UnitCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.ObjectCheck.FlatStyle = FlatStyle.System
			Dim location11 As Point = New Point(8, 16)
			Me.ObjectCheck.Location = location11
			Me.ObjectCheck.Name = "ObjectCheck"
			Dim size11 As Size = New Size(96, 24)
			Me.ObjectCheck.Size = size11
			Me.ObjectCheck.TabIndex = 0
			Me.ObjectCheck.Text = "Objects"
			AddHandler Me.ObjectCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.StructGroup.Controls.Add(Me.WireCheck)
			Me.StructGroup.Controls.Add(Me.BuildCheck)
			Me.StructGroup.Controls.Add(Me.RoadCheck)
			Me.StructGroup.FlatStyle = FlatStyle.System
			Dim location12 As Point = New Point(8, 200)
			Me.StructGroup.Location = location12
			Me.StructGroup.Name = "StructGroup"
			Dim size12 As Size = New Size(112, 96)
			Me.StructGroup.Size = size12
			Me.StructGroup.TabIndex = 3
			Me.StructGroup.TabStop = False
			Me.StructGroup.Text = "Structures"
			Me.WireCheck.FlatStyle = FlatStyle.System
			Dim location13 As Point = New Point(8, 64)
			Me.WireCheck.Location = location13
			Me.WireCheck.Name = "WireCheck"
			Dim size13 As Size = New Size(96, 24)
			Me.WireCheck.Size = size13
			Me.WireCheck.TabIndex = 2
			Me.WireCheck.Text = "Wires"
			AddHandler Me.WireCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.BuildCheck.FlatStyle = FlatStyle.System
			Dim location14 As Point = New Point(8, 40)
			Me.BuildCheck.Location = location14
			Me.BuildCheck.Name = "BuildCheck"
			Dim size14 As Size = New Size(96, 24)
			Me.BuildCheck.Size = size14
			Me.BuildCheck.TabIndex = 1
			Me.BuildCheck.Text = "Buildings"
			AddHandler Me.BuildCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.RoadCheck.FlatStyle = FlatStyle.System
			Dim location15 As Point = New Point(8, 16)
			Me.RoadCheck.Location = location15
			Me.RoadCheck.Name = "RoadCheck"
			Dim size15 As Size = New Size(96, 24)
			Me.RoadCheck.Size = size15
			Me.RoadCheck.TabIndex = 0
			Me.RoadCheck.Text = "Roads"
			AddHandler Me.RoadCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.MiscGroup.Controls.Add(Me.EffectCheck)
			Me.MiscGroup.Controls.Add(Me.SoundCheck)
			Me.MiscGroup.FlatStyle = FlatStyle.System
			Dim location16 As Point = New Point(8, 368)
			Me.MiscGroup.Location = location16
			Me.MiscGroup.Name = "MiscGroup"
			Dim size16 As Size = New Size(112, 72)
			Me.MiscGroup.Size = size16
			Me.MiscGroup.TabIndex = 4
			Me.MiscGroup.TabStop = False
			Me.MiscGroup.Text = "Miscellaneous"
			Me.EffectCheck.FlatStyle = FlatStyle.System
			Dim location17 As Point = New Point(8, 40)
			Me.EffectCheck.Location = location17
			Me.EffectCheck.Name = "EffectCheck"
			Dim size17 As Size = New Size(96, 24)
			Me.EffectCheck.Size = size17
			Me.EffectCheck.TabIndex = 1
			Me.EffectCheck.Text = "Effects"
			AddHandler Me.EffectCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.SoundCheck.FlatStyle = FlatStyle.System
			Dim location18 As Point = New Point(8, 16)
			Me.SoundCheck.Location = location18
			Me.SoundCheck.Name = "SoundCheck"
			Dim size18 As Size = New Size(96, 24)
			Me.SoundCheck.Size = size18
			Me.SoundCheck.TabIndex = 0
			Me.SoundCheck.Text = "Sounds"
			AddHandler Me.SoundCheck.CheckedChanged, AddressOf Me.OptionChange
			Me.OKBtn.DialogResult = DialogResult.OK
			Me.OKBtn.FlatStyle = FlatStyle.System
			Dim location19 As Point = New Point(8, 448)
			Me.OKBtn.Location = location19
			Me.OKBtn.Name = "OKBtn"
			Dim size19 As Size = New Size(56, 23)
			Me.OKBtn.Size = size19
			Me.OKBtn.TabIndex = 5
			Me.OKBtn.Text = "GO!"
			Me.NOBtn.DialogResult = DialogResult.Cancel
			Me.NOBtn.FlatStyle = FlatStyle.System
			Dim location20 As Point = New Point(64, 448)
			Me.NOBtn.Location = location20
			Me.NOBtn.Name = "NOBtn"
			Dim size20 As Size = New Size(56, 23)
			Me.NOBtn.Size = size20
			Me.NOBtn.TabIndex = 6
			Me.NOBtn.Text = "NO!"
			MyBase.AcceptButton = Me.OKBtn
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			MyBase.CancelButton = Me.NOBtn
			Dim clientSize As Size = New Size(128, 474)
			MyBase.ClientSize = clientSize
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.NOBtn)
			MyBase.Controls.Add(Me.OKBtn)
			MyBase.Controls.Add(Me.MiscGroup)
			MyBase.Controls.Add(Me.StructGroup)
			MyBase.Controls.Add(Me.ObjectGroup)
			MyBase.Controls.Add(Me.WaterGroup)
			MyBase.Controls.Add(Me.TerrainGroup)
			MyBase.Name = "PasteOptions"
			MyBase.SizeGripStyle = SizeGripStyle.Hide
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "Paste Special"
			Me.TerrainGroup.ResumeLayout(False)
			Me.WaterGroup.ResumeLayout(False)
			Me.ObjectGroup.ResumeLayout(False)
			Me.StructGroup.ResumeLayout(False)
			Me.MiscGroup.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub OptionChange(sender As Object, e As EventArgs)
			If Not Me.Lock Then
				Me.propPasteOptionFlags = 0UI
				If Me.HeightCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 1UI
				End If
				If Me.LayersCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 2UI
				End If
				If Me.ColorCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 4UI
				End If
				If Me.DecalCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 8UI
				End If
				If Me.LakeCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 16UI
				End If
				If Me.RiverCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 32UI
				End If
				If Me.RoadCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 64UI
				End If
				If Me.BuildCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 128UI
				End If
				If Me.WireCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 256UI
				End If
				If Me.ObjectCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 512UI
				End If
				If Me.UnitCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 1024UI
				End If
				If Me.SoundCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 2048UI
				End If
				If Me.EffectCheck.Checked Then
					Me.propPasteOptionFlags = Me.propPasteOptionFlags Or 4096UI
				End If
			End If
		End Sub
	End Class
End Namespace
