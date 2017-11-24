Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxWeather
		Inherits UserControl

		Public Delegate Sub __Delegate_ValueChanged( As __Pointer(Of GWWeather))

		Private components As Container

		Private cpickerAmbient As ColorPicker

		Private cpickerSunColor As ColorPicker

		Private cpickerFogColor As ColorPicker

		Private sliderSunDir As SliderPanel

		Private sliderSunElev As SliderPanel

		Private sliderFogStart As SliderPanel

		Private sliderFogEnd As SliderPanel

		Private sliderFogStartVal As SliderPanel

		Private sliderFogEndVal As SliderPanel

		Private sliderFogSkyBox As SliderPanel

		Private sliderDetectionMod As SliderPanel

		Private sliderWindDir As SliderPanel

		Private sliderWindSpeed As SliderPanel

		Private sliderWindRandom As SliderPanel

		Private sliderRain As SliderPanel

		Private sliderThunder As SliderPanel

		Private sliderSnow As SliderPanel

		Private sliderClouds As SliderPanel

		Private sliderSandstorm As SliderPanel

		Private sliderSandstormSize As SliderPanel

		Private Tools As Toolbar

		Private listWeather As ListView

		Private SkyboxBtn As Button

		Private EnvBtn As Button

		Private CloudBtn As Button

		Private ResetCloudBtn As Button

		Private ResetEnvBtn As Button

		Private ResetSkyBtn As Button

		Private Weathers As ColumnHeader

		Protected World As __Pointer(Of GEditorWorld)

		Protected ListRefreshing As Boolean

		Public Custom Event ValueChanged As ToolboxWeather.__Delegate_ValueChanged
			AddHandler
				Me.ValueChanged = [Delegate].Combine(Me.ValueChanged, value)
			End AddHandler
			RemoveHandler
				Me.ValueChanged = [Delegate].Remove(Me.ValueChanged, value)
			End RemoveHandler
		End Event

		Public Sub New()
			Me.ValueChanged = Nothing
			Me.World = Nothing
			Me.ListRefreshing = False
			Me.InitializeComponent()
			Me.cpickerAmbient = New ColorPicker()
			Dim location As Point = New Point(10, 124)
			Me.cpickerAmbient.Location = location
			Me.cpickerAmbient.Name = "cpickerAmbient"
			Me.cpickerAmbient.TabIndex = 0
			Me.cpickerAmbient.Font = Me.Font
			Me.cpickerAmbient.Text = "Ambient"
			AddHandler Me.cpickerAmbient.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.cpickerAmbient)
			Me.cpickerSunColor = New ColorPicker()
			Dim location2 As Point = New Point(10, 260)
			Me.cpickerSunColor.Location = location2
			Me.cpickerSunColor.Name = "cpickerSunColor"
			Me.cpickerSunColor.TabIndex = 0
			Me.cpickerSunColor.Font = Me.Font
			Me.cpickerSunColor.Text = "Sunlight"
			AddHandler Me.cpickerSunColor.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.cpickerSunColor)
			Me.sliderSunDir = New SliderPanel(0, 360, 15)
			Dim location3 As Point = New Point(10, 386)
			Me.sliderSunDir.Location = location3
			Me.sliderSunDir.Name = "sliderSunDir"
			Me.sliderSunDir.TabIndex = 0
			Me.sliderSunDir.Font = Me.Font
			Me.sliderSunDir.Text = "Dir"
			AddHandler Me.sliderSunDir.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderSunDir)
			Me.sliderSunElev = New SliderPanel(0, 90, 5)
			Dim location4 As Point = New Point(10, 414)
			Me.sliderSunElev.Location = location4
			Me.sliderSunElev.Name = "sliderSunElev"
			Me.sliderSunElev.TabIndex = 0
			Me.sliderSunElev.Font = Me.Font
			Me.sliderSunElev.Text = "Elev"
			AddHandler Me.sliderSunElev.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderSunElev)
			Me.cpickerFogColor = New ColorPicker()
			Dim location5 As Point = New Point(10, 452)
			Me.cpickerFogColor.Location = location5
			Me.cpickerFogColor.Name = "cpickerFogColor"
			Me.cpickerFogColor.TabIndex = 0
			Me.cpickerFogColor.Font = Me.Font
			Me.cpickerFogColor.Text = "Fog"
			AddHandler Me.cpickerFogColor.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.cpickerFogColor)
			Me.sliderFogStart = New SliderPanel(0, 1000, 10)
			Dim location6 As Point = New Point(10, 578)
			Me.sliderFogStart.Location = location6
			Me.sliderFogStart.Name = "sliderFogStart"
			Me.sliderFogStart.TabIndex = 0
			Me.sliderFogStart.Font = Me.Font
			Me.sliderFogStart.Text = "Start"
			AddHandler Me.sliderFogStart.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderFogStart)
			Me.sliderFogEnd = New SliderPanel(0, 1000, 10)
			Dim location7 As Point = New Point(10, 606)
			Me.sliderFogEnd.Location = location7
			Me.sliderFogEnd.Name = "sliderFogEnd"
			Me.sliderFogEnd.TabIndex = 0
			Me.sliderFogEnd.Font = Me.Font
			Me.sliderFogEnd.Text = "End"
			AddHandler Me.sliderFogEnd.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderFogEnd)
			Me.sliderFogStartVal = New SliderPanel(0, 100, 10)
			Dim location8 As Point = New Point(10, 634)
			Me.sliderFogStartVal.Location = location8
			Me.sliderFogStartVal.Name = "sliderFogStartVal"
			Me.sliderFogStartVal.TabIndex = 0
			Me.sliderFogStartVal.Font = Me.Font
			Me.sliderFogStartVal.Text = "StartVal"
			AddHandler Me.sliderFogStartVal.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderFogStartVal)
			Me.sliderFogEndVal = New SliderPanel(0, 100, 10)
			Dim location9 As Point = New Point(10, 662)
			Me.sliderFogEndVal.Location = location9
			Me.sliderFogEndVal.Name = "sliderFogEndVal"
			Me.sliderFogEndVal.TabIndex = 0
			Me.sliderFogEndVal.Font = Me.Font
			Me.sliderFogEndVal.Text = "EndVal"
			AddHandler Me.sliderFogEndVal.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderFogEndVal)
			Me.sliderFogSkyBox = New SliderPanel(0, 100, 10)
			Dim location10 As Point = New Point(10, 690)
			Me.sliderFogSkyBox.Location = location10
			Me.sliderFogSkyBox.Name = "sliderFogSkyBox"
			Me.sliderFogSkyBox.TabIndex = 0
			Me.sliderFogSkyBox.Font = Me.Font
			Me.sliderFogSkyBox.Text = "SkyBox"
			AddHandler Me.sliderFogSkyBox.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderFogSkyBox)
			Me.sliderDetectionMod = New SliderPanel(1, 100, 5)
			Dim location11 As Point = New Point(10, 734)
			Me.sliderDetectionMod.Location = location11
			Me.sliderDetectionMod.Name = "sliderDetectionMod"
			Me.sliderDetectionMod.TabIndex = 0
			Me.sliderDetectionMod.Font = Me.Font
			Me.sliderDetectionMod.Text = "DetectMod"
			AddHandler Me.sliderDetectionMod.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderDetectionMod)
			Me.sliderWindDir = New SliderPanel(0, 360, 15)
			Dim location12 As Point = New Point(10, 762)
			Me.sliderWindDir.Location = location12
			Me.sliderWindDir.Name = "sliderWindDir"
			Me.sliderWindDir.TabIndex = 0
			Me.sliderWindDir.Font = Me.Font
			Me.sliderWindDir.Text = "Wind Dir"
			AddHandler Me.sliderWindDir.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderWindDir)
			Me.sliderWindSpeed = New SliderPanel(0, 60, 5)
			Dim location13 As Point = New Point(10, 790)
			Me.sliderWindSpeed.Location = location13
			Me.sliderWindSpeed.Name = "sliderWindSpeed"
			Me.sliderWindSpeed.TabIndex = 0
			Me.sliderWindSpeed.Font = Me.Font
			Me.sliderWindSpeed.Text = "Wind Speed"
			AddHandler Me.sliderWindSpeed.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderWindSpeed)
			Me.sliderWindRandom = New SliderPanel(0, 100, 5)
			Dim location14 As Point = New Point(10, 818)
			Me.sliderWindRandom.Location = location14
			Me.sliderWindRandom.Name = "sliderWindRandom"
			Me.sliderWindRandom.TabIndex = 0
			Me.sliderWindRandom.Font = Me.Font
			Me.sliderWindRandom.Text = "Wind Random"
			AddHandler Me.sliderWindRandom.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderWindRandom)
			Me.sliderRain = New SliderPanel(0, 400, 20)
			Dim location15 As Point = New Point(10, 854)
			Me.sliderRain.Location = location15
			Me.sliderRain.Name = "sliderRain"
			Me.sliderRain.TabIndex = 0
			Me.sliderRain.Font = Me.Font
			Me.sliderRain.Text = "Rain"
			AddHandler Me.sliderRain.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderRain)
			Me.sliderThunder = New SliderPanel(0, 400, 20)
			Dim location16 As Point = New Point(10, 882)
			Me.sliderThunder.Location = location16
			Me.sliderThunder.Name = "sliderThunder"
			Me.sliderThunder.TabIndex = 0
			Me.sliderThunder.Font = Me.Font
			Me.sliderThunder.Text = "Thunder"
			AddHandler Me.sliderThunder.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderThunder)
			Me.sliderSnow = New SliderPanel(0, 1200, 20)
			Dim location17 As Point = New Point(10, 910)
			Me.sliderSnow.Location = location17
			Me.sliderSnow.Name = "sliderSnow"
			Me.sliderSnow.TabIndex = 0
			Me.sliderSnow.Font = Me.Font
			Me.sliderSnow.Text = "Snow"
			AddHandler Me.sliderSnow.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderSnow)
			Me.sliderClouds = New SliderPanel(0, 400, 20)
			Dim location18 As Point = New Point(10, 938)
			Me.sliderClouds.Location = location18
			Me.sliderClouds.Name = "sliderClouds"
			Me.sliderClouds.TabIndex = 0
			Me.sliderClouds.Font = Me.Font
			Me.sliderClouds.Text = "Clouds"
			AddHandler Me.sliderClouds.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderClouds)
			Me.sliderSandstorm = New SliderPanel(0, 100, 5)
			Dim location19 As Point = New Point(10, 966)
			Me.sliderSandstorm.Location = location19
			Me.sliderSandstorm.Name = "sliderSandstorm"
			Me.sliderSandstorm.TabIndex = 0
			Me.sliderSandstorm.Font = Me.Font
			Me.sliderSandstorm.Text = "Sandstorm"
			AddHandler Me.sliderSandstorm.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderSandstorm)
			Me.sliderSandstormSize = New SliderPanel(0, 20, 1)
			Dim location20 As Point = New Point(10, 994)
			Me.sliderSandstormSize.Location = location20
			Me.sliderSandstormSize.Name = "sliderSandstormSize"
			Me.sliderSandstormSize.TabIndex = 0
			Me.sliderSandstormSize.Font = Me.Font
			Me.sliderSandstormSize.Text = "Sandstorm Size"
			AddHandler Me.sliderSandstormSize.ValueChanged, AddressOf Me.OnValueChanged
			MyBase.Controls.Add(Me.sliderSandstormSize)
			Dim location21 As Point = New Point(Me.SkyboxBtn.Location.X, 1030)
			Me.SkyboxBtn.Location = location21
			Dim location22 As Point = New Point(Me.ResetSkyBtn.Location.X, 1030)
			Me.ResetSkyBtn.Location = location22
			Dim location23 As Point = New Point(Me.EnvBtn.Location.X, 1054)
			Me.EnvBtn.Location = location23
			Dim location24 As Point = New Point(Me.ResetEnvBtn.Location.X, 1054)
			Me.ResetEnvBtn.Location = location24
			Dim location25 As Point = New Point(Me.CloudBtn.Location.X, 1078)
			Me.CloudBtn.Location = location25
			Dim location26 As Point = New Point(Me.ResetCloudBtn.Location.X, 1078)
			Me.ResetCloudBtn.Location = location26
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0ToolboxWeather@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Me.Tools = toolbar
			toolbar.Dock = DockStyle.Top
			AddHandler Me.Tools.ButtonClick, AddressOf Me.tools_ButtonClick
			Dim size As Size = MyBase.Size
			Dim size2 As Size = New Size(MyBase.Size.Width, size.Height)
			Me.Tools.Size = size2
			MyBase.Controls.Add(Me.Tools)
			Dim size3 As Size = New Size(MyBase.Size.Width, 1106)
			MyBase.Size = size3
		End Sub

		Public Sub Refresh(world As __Pointer(Of GEditorWorld))
			Me.World = world
			Me.RefreshList()
			Me.RefreshGUI()
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
			Me.listWeather = New ListView()
			Me.Weathers = New ColumnHeader()
			Me.SkyboxBtn = New Button()
			Me.EnvBtn = New Button()
			Me.CloudBtn = New Button()
			Me.ResetCloudBtn = New Button()
			Me.ResetEnvBtn = New Button()
			Me.ResetSkyBtn = New Button()
			MyBase.SuspendLayout()
			Dim values As ColumnHeader() = New ColumnHeader() { Me.Weathers }
			Me.listWeather.Columns.AddRange(values)
			Me.listWeather.FullRowSelect = True
			Me.listWeather.GridLines = True
			Me.listWeather.HeaderStyle = ColumnHeaderStyle.None
			Me.listWeather.HideSelection = False
			Me.listWeather.LabelEdit = True
			Me.listWeather.LabelWrap = False
			Dim location As Point = New Point(0, 32)
			Me.listWeather.Location = location
			Me.listWeather.MultiSelect = False
			Me.listWeather.Name = "listWeather"
			Dim size As Size = New Size(256, 88)
			Me.listWeather.Size = size
			Me.listWeather.Sorting = SortOrder.Ascending
			Me.listWeather.TabIndex = 18
			Me.listWeather.View = View.Details
			AddHandler Me.listWeather.AfterLabelEdit, AddressOf Me.listWeather_AfterLabelEdit
			AddHandler Me.listWeather.SelectedIndexChanged, AddressOf Me.listWeather_SelectedIndexChanged
			Me.Weathers.Width = 234
			Dim location2 As Point = New Point(8, 128)
			Me.SkyboxBtn.Location = location2
			Me.SkyboxBtn.Name = "SkyboxBtn"
			Dim size2 As Size = New Size(120, 23)
			Me.SkyboxBtn.Size = size2
			Me.SkyboxBtn.TabIndex = 19
			Me.SkyboxBtn.Text = "Load skybox"
			AddHandler Me.SkyboxBtn.Click, AddressOf Me.SkyboxBtn_Click
			Dim location3 As Point = New Point(8, 152)
			Me.EnvBtn.Location = location3
			Me.EnvBtn.Name = "EnvBtn"
			Dim size3 As Size = New Size(120, 23)
			Me.EnvBtn.Size = size3
			Me.EnvBtn.TabIndex = 20
			Me.EnvBtn.Text = "Load environment"
			AddHandler Me.EnvBtn.Click, AddressOf Me.EnvBtn_Click
			Me.EnvBtn.Enabled = False
			Dim location4 As Point = New Point(8, 176)
			Me.CloudBtn.Location = location4
			Me.CloudBtn.Name = "CloudBtn"
			Dim size4 As Size = New Size(120, 23)
			Me.CloudBtn.Size = size4
			Me.CloudBtn.TabIndex = 21
			Me.CloudBtn.Text = "Load cloud"
			AddHandler Me.CloudBtn.Click, AddressOf Me.CloudBtn_Click
			Dim location5 As Point = New Point(128, 176)
			Me.ResetCloudBtn.Location = location5
			Me.ResetCloudBtn.Name = "ResetCloudBtn"
			Dim size5 As Size = New Size(120, 23)
			Me.ResetCloudBtn.Size = size5
			Me.ResetCloudBtn.TabIndex = 24
			Me.ResetCloudBtn.Text = "Reset cloud"
			AddHandler Me.ResetCloudBtn.Click, AddressOf Me.ResetCloudBtn_Click
			Dim location6 As Point = New Point(128, 152)
			Me.ResetEnvBtn.Location = location6
			Me.ResetEnvBtn.Name = "ResetEnvBtn"
			Dim size6 As Size = New Size(120, 23)
			Me.ResetEnvBtn.Size = size6
			Me.ResetEnvBtn.TabIndex = 23
			Me.ResetEnvBtn.Text = "Reset environment"
			AddHandler Me.ResetEnvBtn.Click, AddressOf Me.ResetEnvBtn_Click
			Me.ResetEnvBtn.Enabled = False
			Dim location7 As Point = New Point(128, 128)
			Me.ResetSkyBtn.Location = location7
			Me.ResetSkyBtn.Name = "ResetSkyBtn"
			Dim size7 As Size = New Size(120, 23)
			Me.ResetSkyBtn.Size = size7
			Me.ResetSkyBtn.TabIndex = 22
			Me.ResetSkyBtn.Text = "Reset skybox"
			AddHandler Me.ResetSkyBtn.Click, AddressOf Me.ResetSkyBtn_Click
			MyBase.Controls.Add(Me.ResetCloudBtn)
			MyBase.Controls.Add(Me.ResetEnvBtn)
			MyBase.Controls.Add(Me.ResetSkyBtn)
			MyBase.Controls.Add(Me.CloudBtn)
			MyBase.Controls.Add(Me.EnvBtn)
			MyBase.Controls.Add(Me.SkyboxBtn)
			MyBase.Controls.Add(Me.listWeather)
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			MyBase.Name = "ToolboxWeather"
			Dim size8 As Size = New Size(256, 460)
			MyBase.Size = size8
			MyBase.ResumeLayout(False)
		End Sub

		Protected Sub RefreshList()
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Me.listWeather.BeginUpdate()
			Me.listWeather.Items.Clear()
			Dim num2 As Integer = -1
			While True
				Dim ptr As __Pointer(Of GHeap<GWWeather>) = Me.World + 3436 / __SizeOf(GEditorWorld)
				Dim num3 As Integer = num2 + 1
				Dim num4 As Integer = __Dereference((ptr + 4))
				If num3 >= num4 Then
					Exit While
				End If
				Dim num5 As Integer = num3 * 124 + __Dereference(ptr)
				While __Dereference(num5) <> 2147483647
					num3 += 1
					num5 += 124
					If num3 >= num4 Then
						GoTo IL_D5
					End If
				End While
				num2 = num3
				If num3 < 0 Then
					Exit While
				End If
				Dim listViewItem As ListViewItem = New ListViewItem()
				Dim num6 As UInteger = CUInt((__Dereference((num3 * 124 + __Dereference(CType((Me.World + 3436 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))) + 12))))
				Dim value As __Pointer(Of SByte)
				If num6 <> 0UI Then
					value = num6
				Else
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				listViewItem.Text = New String(CType(value, __Pointer(Of SByte)))
				listViewItem.Tag = num3
				Me.listWeather.Items.Add(listViewItem)
			End While
			IL_D5:
			Dim num7 As Integer = __Dereference(CType((Me.World + 3456 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
			Try
				For i As Integer = 0 To Me.listWeather.Items.Count - 1
					Dim tag As Object = Me.listWeather.Items(i).Tag
					Dim ptr2 As __Pointer(Of Integer)
					If TypeOf tag Is Integer Then
						ptr2 = CInt(tag)
					Else
						ptr2 = 0
					End If
					If num7 = __Dereference(ptr2) Then
						Me.listWeather.Items(i).Selected = True
					End If
				Next
				GoTo IL_19B
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_19B:
			Me.listWeather.EndUpdate()
			Dim clientSize As Size = Me.listWeather.ClientSize
			Me.listWeather.Columns(0).Width = clientSize.Width
		End Sub

		Protected Sub RefreshGUI()
			Dim ptr As __Pointer(Of GWWeather) = <Module>.GEditorWorld.GetWeather(Me.World, -1)
			Me.cpickerAmbient.Hue = __Dereference((ptr + 16))
			Me.cpickerAmbient.Sat = __Dereference((ptr + 20))
			Me.cpickerAmbient.Val = __Dereference((ptr + 24))
			Me.cpickerSunColor.Hue = __Dereference((ptr + 28))
			Me.cpickerSunColor.Sat = __Dereference((ptr + 32))
			Me.cpickerSunColor.Val = __Dereference((ptr + 36))
			Me.sliderSunDir.Value = __Dereference((ptr + 40))
			Me.sliderSunElev.Value = __Dereference((ptr + 44))
			Me.cpickerFogColor.Hue = __Dereference((ptr + 48))
			Me.cpickerFogColor.Sat = __Dereference((ptr + 52))
			Me.cpickerFogColor.Val = __Dereference((ptr + 56))
			Me.sliderFogStart.Value = __Dereference((ptr + 60))
			Me.sliderFogEnd.Value = __Dereference((ptr + 64))
			Me.sliderFogStartVal.Value = __Dereference((ptr + 68))
			Me.sliderFogEndVal.Value = __Dereference((ptr + 72))
			Me.sliderFogSkyBox.Value = __Dereference((ptr + 76))
			Me.sliderWindDir.Value = __Dereference((ptr + 80))
			Me.sliderWindSpeed.Value = __Dereference((ptr + 84))
			Me.sliderWindRandom.Value = __Dereference((ptr + 88))
			Me.sliderRain.Value = __Dereference((ptr + 92))
			Me.sliderThunder.Value = __Dereference((ptr + 96))
			Me.sliderSnow.Value = __Dereference((ptr + 100))
			Me.sliderClouds.Value = __Dereference((ptr + 104))
			Me.sliderSandstorm.Value = __Dereference((ptr + 108))
			Me.sliderSandstormSize.Value = __Dereference((ptr + 112))
			Me.sliderDetectionMod.Value = __Dereference((ptr + 116))
		End Sub

		Protected Sub OnValueChanged()
			Dim gWWeather As GWWeather
			<Module>.GAWeather.{ctor}(gWWeather)
			Try
				gWWeather = <Module>.??_7GWWeather@@6B@
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
				Throw
			End Try
			Try
				Dim colorPicker As ColorPicker = Me.cpickerAmbient
				__Dereference((gWWeather + 16)) = colorPicker.Hue
				__Dereference((gWWeather + 20)) = colorPicker.Sat
				__Dereference((gWWeather + 24)) = colorPicker.Val
				Dim colorPicker2 As ColorPicker = Me.cpickerSunColor
				__Dereference((gWWeather + 28)) = colorPicker2.Hue
				__Dereference((gWWeather + 32)) = colorPicker2.Sat
				__Dereference((gWWeather + 36)) = colorPicker2.Val
				__Dereference((gWWeather + 40)) = Me.sliderSunDir.Value
				__Dereference((gWWeather + 44)) = Me.sliderSunElev.Value
				Dim colorPicker3 As ColorPicker = Me.cpickerFogColor
				__Dereference((gWWeather + 48)) = colorPicker3.Hue
				__Dereference((gWWeather + 52)) = colorPicker3.Sat
				__Dereference((gWWeather + 56)) = colorPicker3.Val
				__Dereference((gWWeather + 60)) = Me.sliderFogStart.Value
				__Dereference((gWWeather + 64)) = Me.sliderFogEnd.Value
				__Dereference((gWWeather + 68)) = Me.sliderFogStartVal.Value
				__Dereference((gWWeather + 72)) = Me.sliderFogEndVal.Value
				__Dereference((gWWeather + 76)) = Me.sliderFogSkyBox.Value
				__Dereference((gWWeather + 80)) = Me.sliderWindDir.Value
				__Dereference((gWWeather + 84)) = Me.sliderWindSpeed.Value
				__Dereference((gWWeather + 88)) = Me.sliderWindRandom.Value
				__Dereference((gWWeather + 92)) = Me.sliderRain.Value
				__Dereference((gWWeather + 96)) = Me.sliderThunder.Value
				__Dereference((gWWeather + 100)) = Me.sliderSnow.Value
				__Dereference((gWWeather + 104)) = Me.sliderClouds.Value
				__Dereference((gWWeather + 108)) = Me.sliderSandstorm.Value
				__Dereference((gWWeather + 112)) = Me.sliderSandstormSize.Value
				__Dereference((gWWeather + 116)) = Me.sliderDetectionMod.Value
				Me.raise_ValueChanged(gWWeather)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GWWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
				Throw
			End Try
			If __Dereference((gWWeather + 8)) <> 0 Then
				<Module>.free(__Dereference((gWWeather + 8)))
			End If
		End Sub

		Protected Sub tools_ButtonClick(idx As Integer, group As Integer)
			Select Case idx
				Case 1
					Me.btnNew_Click()
				Case 2
					Me.btnCopy_Click()
				Case 3
					Me.btnDelete_Click()
				Case 4
					Me.btnReset_Click()
			End Select
		End Sub

		Protected Sub btnNew_Click()
			If Me.World IsNot Nothing Then
				Dim gWWeather As GWWeather
				<Module>.GAWeather.{ctor}(gWWeather)
				Try
					gWWeather = <Module>.??_7GWWeather@@6B@
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				Try
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
					Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world, AddressOf gBaseString<char>3, 5, ptr2, -1, ptr)
					Try
						Dim num As Integer = __Dereference(CType((ptr3 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer)))
						If num <> 0 Then
							__Dereference((gWWeather + 12)) = num
							__Dereference((gWWeather + 8)) = <Module>.realloc(__Dereference((gWWeather + 8)), CUInt((__Dereference((gWWeather + 12)) + 1)))
							cpblk(__Dereference((gWWeather + 8)), __Dereference(CType(ptr3, __Pointer(Of Integer))), __Dereference((gWWeather + 12)) + 1)
						Else
							__Dereference((gWWeather + 12)) = 0
							If __Dereference((gWWeather + 8)) <> 0 Then
								<Module>.free(__Dereference((gWWeather + 8)))
								__Dereference((gWWeather + 8)) = 0
							End If
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>3 IsNot Nothing Then
						<Module>.free(gBaseString<char>3)
					End If
					<Module>.GWorld.SetNextWeather(Me.World, <Module>.GEditorWorld.AddWeather(Me.World, gWWeather), 0F)
					Me.Refresh(Me.World)
					If Me.listWeather.SelectedItems.Count > 0 Then
						Me.listWeather.SelectedItems(0).BeginEdit()
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GWWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				If __Dereference((gWWeather + 8)) <> 0 Then
					<Module>.free(__Dereference((gWWeather + 8)))
				End If
			End If
		End Sub

		Protected Sub btnCopy_Click()
			If Me.World IsNot Nothing AndAlso Me.listWeather.SelectedIndices.Count > 0 Then
				Dim ptr As __Pointer(Of GWWeather) = <Module>.GEditorWorld.GetWeather(Me.World, -1)
				Dim gWWeather As GWWeather
				<Module>.GAWeather.{ctor}(gWWeather, ptr)
				Try
					gWWeather = <Module>.??_7GWWeather@@6B@
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				Try
					Dim gWWeather2 As GWWeather
					<Module>.GAWeather.{ctor}(gWWeather2, gWWeather)
					Try
						gWWeather2 = <Module>.??_7GWWeather@@6B@
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWeather.{dtor}), CType((AddressOf gWWeather2), __Pointer(Of Void)))
						Throw
					End Try
					Try
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
						Dim gBaseString<char>2 As GBaseString<char>
						Dim world As __Pointer(Of GEditorWorld)
						Try
							If __Dereference((gWWeather2 + 12)) <> 0 Then
								__Dereference((gBaseString<char>2 + 4)) = __Dereference((gWWeather2 + 12))
								gBaseString<char>2 = <Module>.malloc(CUInt((__Dereference((gWWeather2 + 12)) + 1)))
								cpblk(gBaseString<char>2, __Dereference((gWWeather2 + 8)), __Dereference((gBaseString<char>2 + 4)) + 1)
							Else
								__Dereference((gBaseString<char>2 + 4)) = 0
								gBaseString<char>2 = 0
							End If
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
						Dim src As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world, AddressOf gBaseString<char>3, 5, CType((AddressOf gBaseString<char>2), __Pointer(Of GBaseString<char>)), -1, ptr2)
						Try
							<Module>.GBaseString<char>.=(gWWeather2 + 8, src)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>3 IsNot Nothing Then
							<Module>.free(gBaseString<char>3)
						End If
						<Module>.GWorld.SetNextWeather(Me.World, <Module>.GEditorWorld.AddWeather(Me.World, gWWeather2), 0F)
						Me.Refresh(Me.World)
						If Me.listWeather.SelectedItems.Count > 0 Then
							Me.listWeather.SelectedItems(0).BeginEdit()
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GWWeather.{dtor}), CType((AddressOf gWWeather2), __Pointer(Of Void)))
						Throw
					End Try
					If __Dereference((gWWeather2 + 8)) <> 0 Then
						<Module>.free(__Dereference((gWWeather2 + 8)))
						__Dereference((gWWeather2 + 8)) = 0
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GWWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				If __Dereference((gWWeather + 8)) <> 0 Then
					<Module>.free(__Dereference((gWWeather + 8)))
				End If
			End If
		End Sub

		Protected Sub btnDelete_Click()
			If Me.World IsNot Nothing AndAlso Me.listWeather.SelectedIndices.Count > 0 Then
				Dim world As __Pointer(Of GEditorWorld) = Me.World
				Dim num As Integer = __Dereference(CType((world + 3456 / __SizeOf(GEditorWorld)), __Pointer(Of Integer)))
				If <Module>.GEditorWorld.RemoveWeather(world, num) IsNot Nothing Then
					world = Me.World
					Dim expr_3C As __Pointer(Of GEditorWorld) = world
					<Module>.GWorld.SetNextWeather(expr_3C, <Module>.GHeap<GWWeather>.GetNext(expr_3C + 3436 / __SizeOf(GEditorWorld), -1), 0F)
				End If
				Me.Refresh(Me.World)
			End If
		End Sub

		Protected Sub btnReset_Click()
			If Me.World IsNot Nothing Then
				Dim gWWeather As GWWeather
				<Module>.GAWeather.{ctor}(gWWeather)
				Try
					gWWeather = <Module>.??_7GWWeather@@6B@
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				Try
					Me.raise_ValueChanged(gWWeather)
					Me.RefreshGUI()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GWWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				If __Dereference((gWWeather + 8)) <> 0 Then
					<Module>.free(__Dereference((gWWeather + 8)))
				End If
			End If
		End Sub

		Protected Sub listWeather_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			If Me.World IsNot Nothing AndAlso Me.listWeather.SelectedIndices.Count > 0 Then
				Try
					Dim tag As Object = Me.listWeather.SelectedItems(0).Tag
					Dim ptr As __Pointer(Of Integer)
					If TypeOf tag Is Integer Then
						ptr = CInt(tag)
					Else
						ptr = 0
					End If
					<Module>.GWorld.SetNextWeather(Me.World, __Dereference(ptr), 0F)
					Me.RefreshGUI()
					Return
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End If
		End Sub

		Private Sub listWeather_AfterLabelEdit(sender As Object, e As LabelEditEventArgs)
			If e.Label IsNot Nothing Then
				Dim ptr As __Pointer(Of GWWeather) = <Module>.GEditorWorld.GetWeather(Me.World, -1)
				Dim gWWeather As GWWeather
				<Module>.GAWeather.{ctor}(gWWeather, ptr)
				Try
					gWWeather = <Module>.??_7GWWeather@@6B@
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				Try
					If e.Label.Length > 0 Then
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
						Dim ptr3 As __Pointer(Of GBaseString<char>)
						Dim world As __Pointer(Of GEditorWorld)
						Try
							Dim gBaseString<char>2 As GBaseString<char>
							ptr3 = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, e.Label)
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
						Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.?GetNextValidScriptEntityID@GWorld@@$$FQAE?AV?$GBaseString@D@@W4GScriptEntityType@@V2@H1@Z(world, AddressOf gBaseString<char>3, 5, ptr3, -2, ptr2)
						Try
							<Module>.GEditorWorld.RenameWeather(Me.World, ptr4, -1)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>3 IsNot Nothing Then
							<Module>.free(gBaseString<char>3)
						End If
						e.CancelEdit = True
						Me.RefreshList()
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GWWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				If __Dereference((gWWeather + 8)) <> 0 Then
					<Module>.free(__Dereference((gWWeather + 8)))
				End If
			End If
		End Sub

		Private Sub SkyboxBtn_Click(sender As Object, e As EventArgs)
			Dim newAssetPicker As NewAssetPicker = New NewAssetPicker(NewAssetPicker.ObjectType.SkyBoxLoader, 0)
			newAssetPicker.Reset()
			If newAssetPicker.ShowDialog() = DialogResult.OK Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, newAssetPicker.NewName)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					<Module>.GWorld.SetSkyBox(Me.World, ptr2)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Dim gBaseString<char>2 As GBaseString<char>
				Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, newAssetPicker.NewName)
				Try
					Dim num2 As UInteger = CUInt((__Dereference(ptr3)))
					Dim ptr4 As __Pointer(Of SByte)
					If num2 <> 0UI Then
						ptr4 = num2
					Else
						ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					<Module>.GWorld.SetEnvironmentMap(Me.World, ptr4)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
				End If
			End If
		End Sub

		Private Sub EnvBtn_Click(sender As Object, e As EventArgs)
		End Sub

		Private Sub CloudBtn_Click(sender As Object, e As EventArgs)
			Dim newAssetPicker As NewAssetPicker = New NewAssetPicker(NewAssetPicker.ObjectType.CloudLoader, 0)
			newAssetPicker.Reset()
			If newAssetPicker.ShowDialog() = DialogResult.OK Then
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, newAssetPicker.NewName)
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					<Module>.GWorld.SetCloud(Me.World, ptr2)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
			End If
		End Sub

		Private Sub ResetSkyBtn_Click(sender As Object, e As EventArgs)
			<Module>.GWorld.SetSkyBox(Me.World, Nothing)
			<Module>.GWorld.SetEnvironmentMap(Me.World, Nothing)
		End Sub

		Private Sub ResetEnvBtn_Click(sender As Object, e As EventArgs)
		End Sub

		Private Sub ResetCloudBtn_Click(sender As Object, e As EventArgs)
			<Module>.GWorld.SetCloud(Me.World, Nothing)
		End Sub

		Protected Sub raise_ValueChanged(i1 As __Pointer(Of GWWeather))
			Dim valueChanged As ToolboxWeather.__Delegate_ValueChanged = Me.ValueChanged
			If valueChanged IsNot Nothing Then
				valueChanged(i1)
			End If
		End Sub
	End Class
End Namespace
