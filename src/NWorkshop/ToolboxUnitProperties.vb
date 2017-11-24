Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxUnitProperties
		Inherits UserControl

		Public Delegate Sub __Delegate_PropertiesChanged( As __Pointer(Of GUnitStats))

		Private groupBox1 As GroupBox

		Private textBoxHP As TextBox

		Private label5 As Label

		Private textBoxAmmo As TextBox

		Private textBoxCargo As TextBox

		Private label6 As Label

		Private label7 As Label

		Private label8 As Label

		Private comboBoxBehaviour As ComboBox

		Private label1 As Label

		Private label2 As Label

		Private comboBoxPlayer As ComboBox

		Private textBoxScriptID As TextBox

		Private comboBoxLevel As ComboBox

		Private label4 As Label

		Private comboBoxOwnedGear As ComboBox

		Private label3 As Label

		Private textBoxHPConcrete As TextBox

		Private textBoxAmmoConcrete As TextBox

		Private textBoxCargoConcrete As TextBox

		Private label12 As Label

		Private label10 As Label

		Private label11 As Label

		Private groupBoxUnitState As GroupBox

		Private radioButton1 As RadioButton

		Private radioButton4 As RadioButton

		Private radioButton5 As RadioButton

		Private radioButton6 As RadioButton

		Private radioButton2 As RadioButton

		Private radioButton3 As RadioButton

		Private radioButton7 As RadioButton

		Private checkBoxRelax As CheckBox

		Private label9 As Label

		Private radioButton8 As RadioButton

		Private label13 As Label

		Private checkBoxUnloadAtCriticalDamage As CheckBox

		Private Stats As __Pointer(Of GUnitStats)

		Private World As __Pointer(Of GWorld)

		Private components As Container

		Public Custom Event PropertiesChanged As ToolboxUnitProperties.__Delegate_PropertiesChanged
			AddHandler
				Me.PropertiesChanged = [Delegate].Combine(Me.PropertiesChanged, value)
			End AddHandler
			RemoveHandler
				Me.PropertiesChanged = [Delegate].Remove(Me.PropertiesChanged, value)
			End RemoveHandler
		End Event

		Public Sub New()
			Me.PropertiesChanged = Nothing
			Dim ptr As __Pointer(Of GUnitStats) = <Module>.new(96UI)
			Dim stats As __Pointer(Of GUnitStats)
			Try
				If ptr IsNot Nothing Then
					Dim ptr2 As __Pointer(Of GBaseString<char>) = ptr + 4 / __SizeOf(GUnitStats)
					__Dereference(ptr2) = 0
					__Dereference((ptr2 + 4)) = 0
					Try
						Dim ptr3 As __Pointer(Of GBaseString<char>) = ptr + 12 / __SizeOf(GUnitStats)
						__Dereference(ptr3) = 0
						__Dereference((ptr3 + 4)) = 0
						Try
							Dim ptr4 As __Pointer(Of GBaseString<char>) = ptr + 88 / __SizeOf(GUnitStats)
							__Dereference(ptr4) = 0
							__Dereference((ptr4 + 4)) = 0
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((ptr + 12 / __SizeOf(GUnitStats)), __Pointer(Of Void)))
							Throw
						End Try
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((ptr + 4 / __SizeOf(GUnitStats)), __Pointer(Of Void)))
						Throw
					End Try
					stats = ptr
				Else
					stats = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.Stats = stats
			Me.InitializeComponent()
			Dim num As Integer = 0
			Do
				Dim num2 As Integer = num + 1
				Dim num3 As Integer = num2
				Me.comboBoxPlayer.Items.Add("Player " + num3.ToString())
				num = num2
			Loop While num < 12
			Me.comboBoxBehaviour.Items.Add("Free move")
			Me.comboBoxBehaviour.Items.Add("Hold move")
			Me.comboBoxBehaviour.Items.Add("Guardian")
			Me.comboBoxBehaviour.Items.Add("Partisan")
			Me.comboBoxBehaviour.Items.Add("Fanatic")
			Dim num4 As Integer = 0
			Do
				Dim num5 As Integer = num4 + 1
				Dim num6 As Integer = num5
				Me.comboBoxLevel.Items.Add("Level " + num6.ToString())
				num4 = num5
			Loop While num4 < 5
			Dim num7 As Integer = 0
			Do
				Dim num8 As Integer = num7 + 1
				Dim num9 As Integer = num8
				Me.comboBoxLevel.Items.Add("Hero Level " + num9.ToString())
				num7 = num8
			Loop While num7 < 10
			Me.comboBoxPlayer.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.comboBoxPlayer.Enabled = False
			Me.comboBoxLevel.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.comboBoxLevel.Enabled = False
			Me.textBoxScriptID.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxScriptID.Enabled = False
			Me.comboBoxBehaviour.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.comboBoxBehaviour.Enabled = False
			Me.checkBoxRelax.Enabled = False
			Me.checkBoxUnloadAtCriticalDamage.Enabled = False
			Me.textBoxHP.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxHP.Enabled = False
			Me.textBoxHPConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxHPConcrete.Enabled = False
			Me.textBoxAmmo.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxAmmo.Enabled = False
			Me.textBoxAmmoConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxAmmoConcrete.Enabled = False
			Me.textBoxCargo.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxCargo.Enabled = False
			Me.textBoxCargoConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxCargoConcrete.Enabled = False
			Me.comboBoxOwnedGear.Items.Add("No gear")
			Dim num10 As Integer = 0
			If 0 < __Dereference(CType((<Module>.UnitRegistry + 4 / __SizeOf(GUnitRegistry)), __Pointer(Of Integer))) Then
				Do
					Dim num11 As Integer = num10 * 4
					Dim expr_330 As Integer = __Dereference((num11 + __Dereference(CType(<Module>.UnitRegistry, __Pointer(Of Integer)))))
					If calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_330, __Dereference((__Dereference(expr_330) + 48))) Then
						Dim ptr5 As __Pointer(Of GPEquipmentUnit) = <Module>.__RTDynamicCast(__Dereference((num11 + __Dereference(CType(<Module>.UnitRegistry, __Pointer(Of Integer))))), 0, CType((AddressOf <Module>.??_R0?AVGPUnit@@@8), __Pointer(Of Void)), CType((AddressOf <Module>.??_R0?AVGPEquipmentUnit@@@8), __Pointer(Of Void)), 0)
						If <Module>.GPEquipmentUnit.IsPassive(ptr5) Is Nothing Then
							Dim num12 As UInteger = CUInt((__Dereference(CType((ptr5 + 380 / __SizeOf(GPEquipmentUnit)), __Pointer(Of Integer)))))
							Dim value As __Pointer(Of SByte)
							If num12 <> 0UI Then
								value = num12
							Else
								value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							Me.comboBoxOwnedGear.Items.Add(New String(CType(value, __Pointer(Of SByte))))
						End If
					End If
					num10 += 1
				Loop While num10 < __Dereference(CType((<Module>.UnitRegistry + 4 / __SizeOf(GUnitRegistry)), __Pointer(Of Integer)))
			End If
			Me.comboBoxOwnedGear.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.comboBoxOwnedGear.Enabled = False
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
			Me.comboBoxPlayer = New ComboBox()
			Me.textBoxScriptID = New TextBox()
			Me.label1 = New Label()
			Me.label2 = New Label()
			Me.comboBoxLevel = New ComboBox()
			Me.label4 = New Label()
			Me.groupBox1 = New GroupBox()
			Me.label11 = New Label()
			Me.label10 = New Label()
			Me.label12 = New Label()
			Me.textBoxCargoConcrete = New TextBox()
			Me.textBoxAmmoConcrete = New TextBox()
			Me.textBoxHPConcrete = New TextBox()
			Me.label7 = New Label()
			Me.label6 = New Label()
			Me.textBoxCargo = New TextBox()
			Me.textBoxAmmo = New TextBox()
			Me.label5 = New Label()
			Me.textBoxHP = New TextBox()
			Me.label8 = New Label()
			Me.comboBoxBehaviour = New ComboBox()
			Me.comboBoxOwnedGear = New ComboBox()
			Me.label3 = New Label()
			Me.groupBoxUnitState = New GroupBox()
			Me.radioButton1 = New RadioButton()
			Me.radioButton2 = New RadioButton()
			Me.radioButton3 = New RadioButton()
			Me.radioButton4 = New RadioButton()
			Me.radioButton5 = New RadioButton()
			Me.radioButton6 = New RadioButton()
			Me.radioButton7 = New RadioButton()
			Me.radioButton8 = New RadioButton()
			Me.checkBoxRelax = New CheckBox()
			Me.label9 = New Label()
			Me.label13 = New Label()
			Me.checkBoxUnloadAtCriticalDamage = New CheckBox()
			Me.groupBox1.SuspendLayout()
			Me.groupBoxUnitState.SuspendLayout()
			MyBase.SuspendLayout()
			Me.comboBoxPlayer.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location As Point = New Point(80, 8)
			Me.comboBoxPlayer.Location = location
			Me.comboBoxPlayer.Name = "comboBoxPlayer"
			Dim size As Size = New Size(176, 21)
			Me.comboBoxPlayer.Size = size
			Me.comboBoxPlayer.MaxDropDownItems = 20
			Me.comboBoxPlayer.TabIndex = 0
			AddHandler Me.comboBoxPlayer.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location2 As Point = New Point(80, 56)
			Me.textBoxScriptID.Location = location2
			Me.textBoxScriptID.Name = "textBoxScriptID"
			Dim size2 As Size = New Size(176, 20)
			Me.textBoxScriptID.Size = size2
			Me.textBoxScriptID.TabIndex = 1
			Me.textBoxScriptID.Text = "ScriptID"
			AddHandler Me.textBoxScriptID.KeyDown, AddressOf Me.textBoxScriptID_KeyDown
			AddHandler Me.textBoxScriptID.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location3 As Point = New Point(32, 8)
			Me.label1.Location = location3
			Me.label1.Name = "label1"
			Dim size3 As Size = New Size(48, 24)
			Me.label1.Size = size3
			Me.label1.TabIndex = 2
			Me.label1.Text = "Owner:"
			Me.label1.TextAlign = ContentAlignment.MiddleRight
			Dim location4 As Point = New Point(32, 56)
			Me.label2.Location = location4
			Me.label2.Name = "label2"
			Dim size4 As Size = New Size(48, 24)
			Me.label2.Size = size4
			Me.label2.TabIndex = 3
			Me.label2.Text = "ScriptID:"
			Me.label2.TextAlign = ContentAlignment.MiddleRight
			Me.comboBoxLevel.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location5 As Point = New Point(80, 32)
			Me.comboBoxLevel.Location = location5
			Me.comboBoxLevel.Name = "comboBoxLevel"
			Dim size5 As Size = New Size(176, 21)
			Me.comboBoxLevel.Size = size5
			Me.comboBoxLevel.MaxDropDownItems = 20
			Me.comboBoxLevel.TabIndex = 6
			AddHandler Me.comboBoxLevel.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location6 As Point = New Point(32, 32)
			Me.label4.Location = location6
			Me.label4.Name = "label4"
			Dim size6 As Size = New Size(48, 24)
			Me.label4.Size = size6
			Me.label4.TabIndex = 7
			Me.label4.Text = "Level:"
			Me.label4.TextAlign = ContentAlignment.MiddleRight
			Me.groupBox1.Controls.Add(Me.label11)
			Me.groupBox1.Controls.Add(Me.label10)
			Me.groupBox1.Controls.Add(Me.label12)
			Me.groupBox1.Controls.Add(Me.textBoxCargoConcrete)
			Me.groupBox1.Controls.Add(Me.textBoxAmmoConcrete)
			Me.groupBox1.Controls.Add(Me.textBoxHPConcrete)
			Me.groupBox1.Controls.Add(Me.label7)
			Me.groupBox1.Controls.Add(Me.label6)
			Me.groupBox1.Controls.Add(Me.textBoxCargo)
			Me.groupBox1.Controls.Add(Me.textBoxAmmo)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.textBoxHP)
			Me.groupBox1.FlatStyle = FlatStyle.System
			Dim location7 As Point = New Point(80, 192)
			Me.groupBox1.Location = location7
			Me.groupBox1.Name = "groupBox1"
			Dim size7 As Size = New Size(176, 96)
			Me.groupBox1.Size = size7
			Me.groupBox1.TabIndex = 9
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Stats"
			Dim location8 As Point = New Point(96, 64)
			Me.label11.Location = location8
			Me.label11.Name = "label11"
			Dim size8 As Size = New Size(16, 24)
			Me.label11.Size = size8
			Me.label11.TabIndex = 22
			Me.label11.Text = "%"
			Me.label11.TextAlign = ContentAlignment.MiddleLeft
			Dim location9 As Point = New Point(96, 40)
			Me.label10.Location = location9
			Me.label10.Name = "label10"
			Dim size9 As Size = New Size(16, 24)
			Me.label10.Size = size9
			Me.label10.TabIndex = 21
			Me.label10.Text = "%"
			Me.label10.TextAlign = ContentAlignment.MiddleLeft
			AddHandler Me.label10.Click, AddressOf Me.label10_Click
			Dim location10 As Point = New Point(96, 16)
			Me.label12.Location = location10
			Me.label12.Name = "label12"
			Dim size10 As Size = New Size(16, 24)
			Me.label12.Size = size10
			Me.label12.TabIndex = 20
			Me.label12.Text = "%"
			Me.label12.TextAlign = ContentAlignment.MiddleLeft
			Me.textBoxCargoConcrete.Enabled = False
			Dim location11 As Point = New Point(120, 64)
			Me.textBoxCargoConcrete.Location = location11
			Me.textBoxCargoConcrete.Name = "textBoxCargoConcrete"
			Dim size11 As Size = New Size(32, 20)
			Me.textBoxCargoConcrete.Size = size11
			Me.textBoxCargoConcrete.TabIndex = 19
			Me.textBoxCargoConcrete.Text = "Cargo"
			Me.textBoxAmmoConcrete.Enabled = False
			Dim location12 As Point = New Point(120, 40)
			Me.textBoxAmmoConcrete.Location = location12
			Me.textBoxAmmoConcrete.Name = "textBoxAmmoConcrete"
			Dim size12 As Size = New Size(32, 20)
			Me.textBoxAmmoConcrete.Size = size12
			Me.textBoxAmmoConcrete.TabIndex = 18
			Me.textBoxAmmoConcrete.Text = "Ammo"
			Me.textBoxHPConcrete.Enabled = False
			Dim location13 As Point = New Point(120, 16)
			Me.textBoxHPConcrete.Location = location13
			Me.textBoxHPConcrete.Name = "textBoxHPConcrete"
			Dim size13 As Size = New Size(32, 20)
			Me.textBoxHPConcrete.Size = size13
			Me.textBoxHPConcrete.TabIndex = 17
			Me.textBoxHPConcrete.Text = "HP"
			Dim location14 As Point = New Point(8, 64)
			Me.label7.Location = location14
			Me.label7.Name = "label7"
			Dim size14 As Size = New Size(48, 24)
			Me.label7.Size = size14
			Me.label7.TabIndex = 16
			Me.label7.Text = "Cargo"
			Me.label7.TextAlign = ContentAlignment.MiddleLeft
			Dim location15 As Point = New Point(8, 40)
			Me.label6.Location = location15
			Me.label6.Name = "label6"
			Dim size15 As Size = New Size(56, 24)
			Me.label6.Size = size15
			Me.label6.TabIndex = 15
			Me.label6.Text = "Ammo"
			Me.label6.TextAlign = ContentAlignment.MiddleLeft
			Dim location16 As Point = New Point(64, 64)
			Me.textBoxCargo.Location = location16
			Me.textBoxCargo.Name = "textBoxCargo"
			Dim size16 As Size = New Size(32, 20)
			Me.textBoxCargo.Size = size16
			Me.textBoxCargo.TabIndex = 13
			Me.textBoxCargo.Text = "Cargo"
			AddHandler Me.textBoxCargo.KeyDown, AddressOf Me.textBoxCargo_KeyDown
			AddHandler Me.textBoxCargo.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location17 As Point = New Point(64, 40)
			Me.textBoxAmmo.Location = location17
			Me.textBoxAmmo.Name = "textBoxAmmo"
			Dim size17 As Size = New Size(32, 20)
			Me.textBoxAmmo.Size = size17
			Me.textBoxAmmo.TabIndex = 12
			Me.textBoxAmmo.Text = "Ammo"
			AddHandler Me.textBoxAmmo.KeyDown, AddressOf Me.textBoxAmmo_KeyDown
			AddHandler Me.textBoxAmmo.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location18 As Point = New Point(8, 16)
			Me.label5.Location = location18
			Me.label5.Name = "label5"
			Dim size18 As Size = New Size(40, 24)
			Me.label5.Size = size18
			Me.label5.TabIndex = 11
			Me.label5.Text = "HP"
			Me.label5.TextAlign = ContentAlignment.MiddleLeft
			Dim location19 As Point = New Point(64, 16)
			Me.textBoxHP.Location = location19
			Me.textBoxHP.Name = "textBoxHP"
			Dim size19 As Size = New Size(32, 20)
			Me.textBoxHP.Size = size19
			Me.textBoxHP.TabIndex = 10
			Me.textBoxHP.Text = "HP"
			AddHandler Me.textBoxHP.KeyDown, AddressOf Me.textBoxHP_KeyDown
			AddHandler Me.textBoxHP.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location20 As Point = New Point(16, 80)
			Me.label8.Location = location20
			Me.label8.Name = "label8"
			Dim size20 As Size = New Size(64, 24)
			Me.label8.Size = size20
			Me.label8.TabIndex = 11
			Me.label8.Text = "Behaviour:"
			Me.label8.TextAlign = ContentAlignment.MiddleRight
			Me.comboBoxBehaviour.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location21 As Point = New Point(80, 80)
			Me.comboBoxBehaviour.Location = location21
			Me.comboBoxBehaviour.Name = "comboBoxBehaviour"
			Dim size21 As Size = New Size(176, 21)
			Me.comboBoxBehaviour.Size = size21
			Me.comboBoxBehaviour.TabIndex = 10
			AddHandler Me.comboBoxBehaviour.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Me.comboBoxOwnedGear.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location22 As Point = New Point(80, 296)
			Me.comboBoxOwnedGear.Location = location22
			Me.comboBoxOwnedGear.Name = "comboBoxOwnedGear"
			Dim size22 As Size = New Size(176, 21)
			Me.comboBoxOwnedGear.Size = size22
			Me.comboBoxOwnedGear.MaxDropDownItems = 20
			Me.comboBoxOwnedGear.TabIndex = 0
			AddHandler Me.comboBoxOwnedGear.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location23 As Point = New Point(8, 296)
			Me.label3.Location = location23
			Me.label3.Name = "label3"
			Dim size23 As Size = New Size(72, 24)
			Me.label3.Size = size23
			Me.label3.TabIndex = 14
			Me.label3.Text = "Equipment:"
			Me.label3.TextAlign = ContentAlignment.MiddleRight
			Me.groupBoxUnitState.Controls.Add(Me.radioButton1)
			Me.groupBoxUnitState.Controls.Add(Me.radioButton2)
			Me.groupBoxUnitState.Controls.Add(Me.radioButton3)
			Me.groupBoxUnitState.Controls.Add(Me.radioButton4)
			Me.groupBoxUnitState.Controls.Add(Me.radioButton5)
			Me.groupBoxUnitState.Controls.Add(Me.radioButton6)
			Me.groupBoxUnitState.Controls.Add(Me.radioButton7)
			Me.groupBoxUnitState.Controls.Add(Me.radioButton8)
			Dim location24 As Point = New Point(80, 104)
			Me.groupBoxUnitState.Location = location24
			Me.groupBoxUnitState.Name = "groupBoxUnitState"
			Dim size24 As Size = New Size(176, 88)
			Me.groupBoxUnitState.Size = size24
			Me.groupBoxUnitState.TabIndex = 15
			Me.groupBoxUnitState.TabStop = False
			Me.groupBoxUnitState.Text = "Unit state"
			AddHandler Me.groupBoxUnitState.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location25 As Point = New Point(16, 16)
			Me.radioButton1.Location = location25
			Me.radioButton1.Name = "radioButton1"
			Dim size25 As Size = New Size(64, 16)
			Me.radioButton1.Size = size25
			Me.radioButton1.TabIndex = 0
			Me.radioButton1.Text = "Normal"
			Dim location26 As Point = New Point(16, 32)
			Me.radioButton2.Location = location26
			Me.radioButton2.Name = "radioButton2"
			Dim size26 As Size = New Size(64, 16)
			Me.radioButton2.Size = size26
			Me.radioButton2.TabIndex = 8
			Me.radioButton2.Text = "Knee"
			Dim location27 As Point = New Point(16, 48)
			Me.radioButton3.Location = location27
			Me.radioButton3.Name = "radioButton3"
			Dim size27 As Size = New Size(64, 16)
			Me.radioButton3.Size = size27
			Me.radioButton3.TabIndex = 10
			Me.radioButton3.Text = "Lay"
			Dim location28 As Point = New Point(16, 64)
			Me.radioButton4.Location = location28
			Me.radioButton4.Name = "radioButton4"
			Dim size28 As Size = New Size(72, 16)
			Me.radioButton4.Size = size28
			Me.radioButton4.TabIndex = 1
			Me.radioButton4.Text = "Walk"
			Dim location29 As Point = New Point(88, 16)
			Me.radioButton5.Location = location29
			Me.radioButton5.Name = "radioButton5"
			Dim size29 As Size = New Size(82, 16)
			Me.radioButton5.Size = size29
			Me.radioButton5.TabIndex = 2
			Me.radioButton5.Text = "Vehicle"
			Dim location30 As Point = New Point(88, 32)
			Me.radioButton6.Location = location30
			Me.radioButton6.Name = "radioButton6"
			Dim size30 As Size = New Size(82, 16)
			Me.radioButton6.Size = size30
			Me.radioButton6.TabIndex = 6
			Me.radioButton6.Text = "Fireposition"
			Dim location31 As Point = New Point(88, 48)
			Me.radioButton7.Location = location31
			Me.radioButton7.Name = "radioButton7"
			Dim size31 As Size = New Size(64, 16)
			Me.radioButton7.Size = size31
			Me.radioButton7.TabIndex = 11
			Me.radioButton7.Text = "Dug in"
			Dim location32 As Point = New Point(88, 64)
			Me.radioButton8.Location = location32
			Me.radioButton8.Name = "radioButton8"
			Dim size32 As Size = New Size(64, 16)
			Me.radioButton8.Size = size32
			Me.radioButton8.TabIndex = 12
			Me.radioButton8.Text = "Supply"
			Dim location33 As Point = New Point(240, 320)
			Me.checkBoxRelax.Location = location33
			Me.checkBoxRelax.Name = "checkBoxRelax"
			Dim size33 As Size = New Size(16, 24)
			Me.checkBoxRelax.Size = size33
			Me.checkBoxRelax.TabIndex = 16
			Me.checkBoxRelax.ThreeState = True
			AddHandler Me.checkBoxRelax.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location34 As Point = New Point(200, 320)
			Me.label9.Location = location34
			Me.label9.Name = "label9"
			Dim size34 As Size = New Size(40, 24)
			Me.label9.Size = size34
			Me.label9.TabIndex = 17
			Me.label9.Text = "Relax"
			Me.label9.TextAlign = ContentAlignment.MiddleLeft
			Dim location35 As Point = New Point(24, 320)
			Me.label13.Location = location35
			Me.label13.Name = "label13"
			Dim size35 As Size = New Size(136, 24)
			Me.label13.Size = size35
			Me.label13.TabIndex = 19
			Me.label13.Text = "Unload at critical damage"
			Me.label13.TextAlign = ContentAlignment.MiddleLeft
			Dim location36 As Point = New Point(160, 320)
			Me.checkBoxUnloadAtCriticalDamage.Location = location36
			Me.checkBoxUnloadAtCriticalDamage.Name = "checkBoxUnloadAtCriticalDamage"
			Dim size36 As Size = New Size(16, 24)
			Me.checkBoxUnloadAtCriticalDamage.Size = size36
			Me.checkBoxUnloadAtCriticalDamage.TabIndex = 18
			Me.checkBoxUnloadAtCriticalDamage.ThreeState = True
			AddHandler Me.checkBoxUnloadAtCriticalDamage.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			MyBase.Controls.Add(Me.label13)
			MyBase.Controls.Add(Me.checkBoxUnloadAtCriticalDamage)
			MyBase.Controls.Add(Me.label9)
			MyBase.Controls.Add(Me.checkBoxRelax)
			MyBase.Controls.Add(Me.groupBoxUnitState)
			MyBase.Controls.Add(Me.label3)
			MyBase.Controls.Add(Me.label8)
			MyBase.Controls.Add(Me.comboBoxBehaviour)
			MyBase.Controls.Add(Me.groupBox1)
			MyBase.Controls.Add(Me.label4)
			MyBase.Controls.Add(Me.comboBoxLevel)
			MyBase.Controls.Add(Me.label2)
			MyBase.Controls.Add(Me.label1)
			MyBase.Controls.Add(Me.textBoxScriptID)
			MyBase.Controls.Add(Me.comboBoxPlayer)
			MyBase.Controls.Add(Me.comboBoxOwnedGear)
			MyBase.Name = "ToolboxUnitProperties"
			Dim size37 As Size = New Size(264, 352)
			MyBase.Size = size37
			Me.groupBox1.ResumeLayout(False)
			Me.groupBoxUnitState.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub Refresh(world As __Pointer(Of GEditorWorld))
			<Module>.GEditorWorld.GetSelectedWUnitStats(world, Me.Stats)
			Dim num As Integer = __Dereference(CType(Me.Stats, __Pointer(Of Integer)))
			If num = -1 Then
				Me.comboBoxPlayer.SelectedIndex = -1
				Me.comboBoxPlayer.Enabled = False
			Else If num = -2 Then
				Me.comboBoxPlayer.SelectedIndex = -1
				Me.comboBoxPlayer.Enabled = True
			Else
				Me.comboBoxPlayer.SelectedIndex = num
				Me.comboBoxPlayer.Enabled = True
			End If
			Dim num2 As Integer = __Dereference(CType((Me.Stats + 44 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
			If num2 = -1 Then
				Me.comboBoxLevel.SelectedIndex = -1
				Me.comboBoxLevel.Enabled = False
			Else If num2 = -2 Then
				Me.comboBoxLevel.SelectedIndex = -1
				Me.comboBoxLevel.Enabled = True
			Else
				Me.comboBoxLevel.SelectedIndex = num2
				Me.comboBoxLevel.Enabled = True
			End If
			If(If((<Module>.GBaseString<char>.Compare(Me.Stats + 4 / __SizeOf(GUnitStats), CType((AddressOf <Module>.??_C@_02PGHGPEOM@?91?$AA@), __Pointer(Of SByte)), False) = 0), 1, 0)) <> 0 Then
				Me.textBoxScriptID.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxScriptID.Enabled = False
			Else If(If((<Module>.GBaseString<char>.Compare(Me.Stats + 4 / __SizeOf(GUnitStats), CType((AddressOf <Module>.??_C@_02NNFLKHCP@?92?$AA@), __Pointer(Of SByte)), False) = 0), 1, 0)) <> 0 Then
				Me.textBoxScriptID.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxScriptID.Enabled = True
			Else
				Dim num3 As UInteger = CUInt((__Dereference(CType((Me.Stats + 4 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))))
				Dim value As __Pointer(Of SByte)
				If num3 <> 0UI Then
					value = num3
				Else
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				Me.textBoxScriptID.Text = New String(CType(value, __Pointer(Of SByte)))
				Me.textBoxScriptID.Enabled = True
			End If
			Dim num4 As Integer = __Dereference(CType((Me.Stats + 48 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
			If num4 = -1 Then
				Me.comboBoxBehaviour.SelectedIndex = -1
				Me.comboBoxBehaviour.Enabled = False
			Else If num4 = -2 Then
				Me.comboBoxBehaviour.SelectedIndex = -1
				Me.comboBoxBehaviour.Enabled = True
			Else
				Me.comboBoxBehaviour.SelectedIndex = num4
				Me.comboBoxBehaviour.Enabled = True
			End If
			Dim num5 As Integer = __Dereference(CType((Me.Stats + 52 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
			If num5 = -1 Then
				Me.UpdateUnitStateGroupBox()
				Me.groupBoxUnitState.Enabled = False
			Else If num5 = -2 Then
				Me.UpdateUnitStateGroupBox()
				Me.groupBoxUnitState.Enabled = True
			Else
				Me.UpdateUnitStateGroupBox()
				Me.groupBoxUnitState.Enabled = True
			End If
			Dim num6 As Integer = __Dereference(CType((Me.Stats + 68 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
			If num6 = -1 Then
				Me.checkBoxRelax.CheckState = CheckState.Indeterminate
				Me.checkBoxRelax.Enabled = False
			Else If num6 = -2 Then
				Me.checkBoxRelax.CheckState = CheckState.Indeterminate
				Me.checkBoxRelax.Enabled = True
			Else
				If num6 <> 0 Then
					Me.checkBoxRelax.CheckState = CheckState.Checked
				Else
					Me.checkBoxRelax.CheckState = CheckState.Unchecked
				End If
				Me.checkBoxRelax.Enabled = True
			End If
			Dim num7 As Integer = __Dereference(CType((Me.Stats + 72 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
			If num7 = -1 Then
				Me.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Indeterminate
				Me.checkBoxUnloadAtCriticalDamage.Enabled = False
			Else If num7 = -2 Then
				Me.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Indeterminate
				Me.checkBoxUnloadAtCriticalDamage.Enabled = True
			Else
				If num7 <> 0 Then
					Me.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Checked
				Else
					Me.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Unchecked
				End If
				Me.checkBoxUnloadAtCriticalDamage.Enabled = True
			End If
			Dim ptr As __Pointer(Of GUnitStats) = Me.Stats + 20 / __SizeOf(GUnitStats)
			Dim num8 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
			If num8 = -1 Then
				Me.textBoxHP.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxHP.Enabled = False
			Else If num8 = -2 Then
				Me.textBoxHP.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxHP.Enabled = True
			Else
				Dim num9 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
				Me.textBoxHP.Text = num9.ToString()
				Me.textBoxHP.Enabled = True
			End If
			Dim ptr2 As __Pointer(Of GUnitStats) = Me.Stats + 24 / __SizeOf(GUnitStats)
			Dim num10 As Integer = __Dereference(CType(ptr2, __Pointer(Of Integer)))
			If num10 = -1 Then
				Me.textBoxHPConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Else If num10 = -2 Then
				Me.textBoxHPConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Else
				Dim num11 As Integer = __Dereference(CType(ptr2, __Pointer(Of Integer)))
				Me.textBoxHPConcrete.Text = num11.ToString()
			End If
			Dim ptr3 As __Pointer(Of GUnitStats) = Me.Stats + 28 / __SizeOf(GUnitStats)
			Dim num12 As Integer = __Dereference(CType(ptr3, __Pointer(Of Integer)))
			If num12 = -1 Then
				Me.textBoxAmmo.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxAmmo.Enabled = False
			Else If num12 = -2 Then
				Me.textBoxAmmo.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxAmmo.Enabled = True
			Else
				Dim num13 As Integer = __Dereference(CType(ptr3, __Pointer(Of Integer)))
				Me.textBoxAmmo.Text = num13.ToString()
				Me.textBoxAmmo.Enabled = True
			End If
			Dim stats As __Pointer(Of GUnitStats) = Me.Stats
			If __Dereference(CType((stats + 32 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = -1 Then
				Me.textBoxAmmoConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Else If __Dereference(CType((stats + 24 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = -2 Then
				Me.textBoxAmmoConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Else
				Dim num14 As Integer = __Dereference(CType((stats + 32 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
				Me.textBoxAmmoConcrete.Text = num14.ToString()
			End If
			Dim ptr4 As __Pointer(Of GUnitStats) = Me.Stats + 36 / __SizeOf(GUnitStats)
			Dim num15 As Integer = __Dereference(CType(ptr4, __Pointer(Of Integer)))
			If num15 = -1 Then
				Me.textBoxCargo.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxCargo.Enabled = False
			Else If num15 = -2 Then
				Me.textBoxCargo.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxCargo.Enabled = True
			Else
				Dim num16 As Integer = __Dereference(CType(ptr4, __Pointer(Of Integer)))
				Me.textBoxCargo.Text = num16.ToString()
				Me.textBoxCargo.Enabled = True
			End If
			Dim ptr5 As __Pointer(Of GUnitStats) = Me.Stats + 40 / __SizeOf(GUnitStats)
			Dim num17 As Integer = __Dereference(CType(ptr5, __Pointer(Of Integer)))
			If num17 = -1 Then
				Me.textBoxCargoConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Else If num17 = -2 Then
				Me.textBoxCargoConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Else
				Dim num18 As Integer = __Dereference(CType(ptr5, __Pointer(Of Integer)))
				Me.textBoxCargoConcrete.Text = num18.ToString()
			End If
			Dim stats2 As __Pointer(Of GUnitStats) = Me.Stats
			Dim num19 As Integer = __Dereference(CType((stats2 + 84 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
			If num19 = -1 Then
				Me.comboBoxOwnedGear.SelectedIndex = -1
				Me.comboBoxOwnedGear.Enabled = False
			Else If num19 = -2 Then
				Me.comboBoxOwnedGear.SelectedIndex = -1
				Me.comboBoxOwnedGear.Enabled = True
			Else
				If(If((__Dereference(CType((stats2 + 92 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = 0), 1, 0)) <> 0 Then
					Me.comboBoxOwnedGear.SelectedIndex = 0
				Else
					Dim num20 As UInteger = CUInt((__Dereference(CType((stats2 + 88 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))))
					Dim value2 As __Pointer(Of SByte)
					If num20 <> 0UI Then
						value2 = num20
					Else
						value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Me.comboBoxOwnedGear.Text = New String(CType(value2, __Pointer(Of SByte)))
				End If
				Me.comboBoxOwnedGear.Enabled = True
			End If
		End Sub

		Public Sub UpdateStats()
			Dim gBaseString<char> As GBaseString<char> = 0
			__Dereference((gBaseString<char> + 4)) = 0
			Try
				__Dereference(CType(Me.Stats, __Pointer(Of Integer))) = Me.comboBoxPlayer.SelectedIndex
				__Dereference(CType((Me.Stats + 44 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = Me.comboBoxLevel.SelectedIndex
				Dim gBaseString<char>2 As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, Me.textBoxScriptID.Text)
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
				End If
				If(If((__Dereference((gBaseString<char> + 4)) = 0), 1, 0)) <> 0 Then
					<Module>.GBaseString<char>.=(Me.Stats + 4 / __SizeOf(GUnitStats), CType((AddressOf <Module>.??_C@_02PGHGPEOM@?91?$AA@), __Pointer(Of SByte)))
				Else
					Dim ptr2 As __Pointer(Of GBaseString<char>) = Me.Stats + 4 / __SizeOf(GUnitStats)
					If __Dereference((gBaseString<char> + 4)) <> 0 Then
						__Dereference((ptr2 + 4)) = __Dereference((gBaseString<char> + 4))
						Dim ptr3 As __Pointer(Of Void) = <Module>.realloc(__Dereference(ptr2), CUInt((__Dereference((gBaseString<char> + 4)) + 1)))
						__Dereference(ptr2) = ptr3
						cpblk(ptr3, gBaseString<char>, __Dereference((ptr2 + 4)) + 1)
					Else
						__Dereference((ptr2 + 4)) = 0
						Dim num3 As Integer = __Dereference(ptr2)
						If num3 <> 0 Then
							<Module>.free(num3)
							__Dereference(ptr2) = 0
						End If
					End If
				End If
				__Dereference(CType((Me.Stats + 48 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = Me.comboBoxBehaviour.SelectedIndex
				__Dereference(CType((Me.Stats + 52 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = Me.GetUnitState()
				__Dereference(CType((Me.Stats + 68 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = (If(Me.checkBoxRelax.Checked, 1, 0))
				__Dereference(CType((Me.Stats + 72 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = (If(Me.checkBoxUnloadAtCriticalDamage.Checked, 1, 0))
				Dim gBaseString<char>3 As GBaseString<char>
				Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, Me.textBoxHP.Text)
				Try
					Dim num4 As Integer = __Dereference((ptr4 + 4))
					If num4 <> 0 Then
						__Dereference((gBaseString<char> + 4)) = num4
						Dim num5 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num5)
						cpblk(gBaseString<char>, __Dereference(ptr4), num5)
					Else
						__Dereference((gBaseString<char> + 4)) = 0
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>3 IsNot Nothing Then
					<Module>.free(gBaseString<char>3)
				End If
				If(If((__Dereference((gBaseString<char> + 4)) = 0), 1, 0)) <> 0 Then
					__Dereference(CType((Me.Stats + 20 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = -1
				Else
					Dim ptr5 As __Pointer(Of SByte)
					If gBaseString<char> IsNot Nothing Then
						ptr5 = gBaseString<char>
					Else
						ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					__Dereference(CType((Me.Stats + 20 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = <Module>.atoi(ptr5)
				End If
				Dim gBaseString<char>4 As GBaseString<char>
				Dim ptr6 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>4, Me.textBoxAmmo.Text)
				Try
					Dim num6 As Integer = __Dereference((ptr6 + 4))
					If num6 <> 0 Then
						__Dereference((gBaseString<char> + 4)) = num6
						Dim num7 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num7)
						cpblk(gBaseString<char>, __Dereference(ptr6), num7)
					Else
						__Dereference((gBaseString<char> + 4)) = 0
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>4 IsNot Nothing Then
					<Module>.free(gBaseString<char>4)
				End If
				If(If((__Dereference((gBaseString<char> + 4)) = 0), 1, 0)) <> 0 Then
					__Dereference(CType((Me.Stats + 28 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = -1
				Else
					Dim ptr7 As __Pointer(Of SByte)
					If gBaseString<char> IsNot Nothing Then
						ptr7 = gBaseString<char>
					Else
						ptr7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					__Dereference(CType((Me.Stats + 28 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = <Module>.atoi(ptr7)
				End If
				Dim gBaseString<char>5 As GBaseString<char>
				Dim ptr8 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>5, Me.textBoxCargo.Text)
				Try
					Dim num8 As Integer = __Dereference((ptr8 + 4))
					If num8 <> 0 Then
						__Dereference((gBaseString<char> + 4)) = num8
						Dim num9 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num9)
						cpblk(gBaseString<char>, __Dereference(ptr8), num9)
					Else
						__Dereference((gBaseString<char> + 4)) = 0
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>5 IsNot Nothing Then
					<Module>.free(gBaseString<char>5)
				End If
				If(If((__Dereference((gBaseString<char> + 4)) = 0), 1, 0)) <> 0 Then
					__Dereference(CType((Me.Stats + 36 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = -1
				Else
					Dim ptr9 As __Pointer(Of SByte)
					If gBaseString<char> IsNot Nothing Then
						ptr9 = gBaseString<char>
					Else
						ptr9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					__Dereference(CType((Me.Stats + 36 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = <Module>.atoi(ptr9)
				End If
				Dim gBaseString<char>6 As GBaseString<char>
				Dim ptr10 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>6, Me.comboBoxOwnedGear.Text)
				Try
					Dim num10 As Integer = __Dereference((ptr10 + 4))
					If num10 <> 0 Then
						__Dereference((gBaseString<char> + 4)) = num10
						Dim num11 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
						gBaseString<char> = <Module>.realloc(gBaseString<char>, num11)
						cpblk(gBaseString<char>, __Dereference(ptr10), num11)
					Else
						__Dereference((gBaseString<char> + 4)) = 0
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>6 IsNot Nothing Then
					<Module>.free(gBaseString<char>6)
				End If
				If Me.comboBoxOwnedGear.SelectedIndex = 0 Then
					__Dereference(CType((Me.Stats + 84 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = 0
					Dim ptr11 As __Pointer(Of GBaseString<char>) = Me.Stats + 88 / __SizeOf(GUnitStats)
					Dim num12 As UInteger = CUInt((__Dereference(ptr11)))
					If num12 <> 0UI Then
						<Module>.free(num12)
						__Dereference(ptr11) = 0
					End If
					__Dereference((ptr11 + 4)) = 0
				Else If(If((__Dereference((gBaseString<char> + 4)) = 0), 1, 0)) <> 0 Then
					__Dereference(CType((Me.Stats + 84 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = -1
				Else
					__Dereference(CType((Me.Stats + 84 / __SizeOf(GUnitStats)), __Pointer(Of Integer))) = 1
					<Module>.GBaseString<char>.=(Me.Stats + 88 / __SizeOf(GUnitStats), gBaseString<char>)
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
		End Sub

		Public Function GetUnitState() As Integer
			Dim enumerator As IEnumerator = Me.groupBoxUnitState.Controls.GetEnumerator()
			Dim num As Integer = 0
			If enumerator.MoveNext() Then
				While Not(TryCast(enumerator.Current, RadioButton)).Checked
					num += 1
					If Not enumerator.MoveNext() Then
						Return -1
					End If
				End While
				Return num
			End If
			Return -1
		End Function

		Public Sub UpdateUnitStateGroupBox()
			Dim enumerator As IEnumerator = Me.groupBoxUnitState.Controls.GetEnumerator()
			Dim num As Integer = 0
			If enumerator.MoveNext() Then
				Do
					If __Dereference(CType((num / __SizeOf(GUnitStats) + Me.Stats + 56 / __SizeOf(GUnitStats)), __Pointer(Of Byte))) <> 0 Then
						(TryCast(enumerator.Current, RadioButton)).Enabled = True
					Else
						(TryCast(enumerator.Current, RadioButton)).Enabled = False
					End If
					num += 1
				Loop While enumerator.MoveNext()
			End If
			Dim num2 As Integer = __Dereference(CType((Me.Stats + 52 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
			If num2 = -1 Then
				If enumerator.MoveNext() Then
					Do
						(TryCast(enumerator.Current, RadioButton)).Checked = False
					Loop While enumerator.MoveNext()
				End If
			Else If num2 >= 0 Then
				num2 = __Dereference(CType((Me.Stats + 52 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
				If num2 < Me.groupBoxUnitState.Controls.Count Then
					(TryCast(Me.groupBoxUnitState.Controls(num2), RadioButton)).Checked = True
				End If
			End If
		End Sub

		Private Sub ToolboxUnitProperties_Validated(sender As Object, e As EventArgs)
			Me.UpdateStats()
			Me.raise_PropertiesChanged(Me.Stats)
		End Sub

		Private Sub textBoxHP_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.ToolboxUnitProperties_Validated(Me, Nothing)
			End If
		End Sub

		Private Sub textBoxAmmo_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.ToolboxUnitProperties_Validated(Me, Nothing)
			End If
		End Sub

		Private Sub textBoxCargo_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.ToolboxUnitProperties_Validated(Me, Nothing)
			End If
		End Sub

		Private Sub textBoxScriptID_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.ToolboxUnitProperties_Validated(Me, Nothing)
			End If
		End Sub

		Private Sub textBoxGroupID_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.ToolboxUnitProperties_Validated(Me, Nothing)
			End If
		End Sub

		Private Sub label10_Click(sender As Object, e As EventArgs)
		End Sub

		Protected Sub raise_PropertiesChanged(i1 As __Pointer(Of GUnitStats))
			Dim propertiesChanged As ToolboxUnitProperties.__Delegate_PropertiesChanged = Me.PropertiesChanged
			If propertiesChanged IsNot Nothing Then
				propertiesChanged(i1)
			End If
		End Sub
	End Class
End Namespace
