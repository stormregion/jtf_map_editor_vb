Imports ScriptEditor
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Globalization
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace ScriptVariablePropertiesWindow
	Public Class ScriptVariablePropertiesForm
		Inherits Form

		Private VarProp_AutoChangePeriod As TextBox

		Private VarProp_AutoChangeModeLabel As Label

		Private VarProp_AutoChangeMode As ComboBox

		Private Variable_Name_Label As Label

		Private VarProp_Name As TextBox

		Private VarProp_Type_Label As Label

		Private VarProp_Type As ComboBox

		Private VarProp_Value_Label As Label

		Private VarProp_Value As TextBox

		Private VarProp_OK_Button As Button

		Private VarProp_Cancel_Button As Button

		Private VarProp_AutoChangeValue_Label As Label

		Private VarProp_AutoChangeValue As TextBox

		Private VarProp_AutoChangePeriod_Label As Label

		Private components As Container

		Private Var_Used As Integer

		Private Editor As __Pointer(Of cEditor)

		Private Trigger As __Pointer(Of cTrigger)

		Public ReadOnly Property Variable_AutoChange_Value() As Integer
			Get
				Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
				Try
					Return(CType(Me.VarProp_AutoChangeValue.Text, IConvertible)).ToInt32(New NumberFormatInfo())
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End Get
		End Property

		Public ReadOnly Property Variable_AutoChange_Period() As Integer
			Get
				Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
				Try
					Return(CType(Me.VarProp_AutoChangePeriod.Text, IConvertible)).ToInt32(New NumberFormatInfo())
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End Get
		End Property

		Public ReadOnly Property Variable_AutoChangeMode() As Integer
			Get
				Return Me.VarProp_AutoChangeMode.SelectedIndex
			End Get
		End Property

		Public ReadOnly Property Variable_Value() As Integer
			Get
				Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
				Try
					Return(CType(Me.VarProp_Value.Text, IConvertible)).ToInt32(New NumberFormatInfo())
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End Get
		End Property

		Public ReadOnly Property Variable_Type() As Integer
			Get
				Return __Dereference((Me.VarProp_Type.SelectedIndex * 4 + <Module>.ScriptEditor.ValueTypeList))
			End Get
		End Property

		Public ReadOnly Property Variable_Name() As String
			Get
				Return Me.VarProp_Name.Text
			End Get
		End Property

		Public Sub New()
			Me.InitializeComponent()
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
			Me.VarProp_AutoChangeValue_Label = New Label()
			Me.VarProp_AutoChangeValue = New TextBox()
			Me.VarProp_AutoChangePeriod_Label = New Label()
			Me.VarProp_AutoChangePeriod = New TextBox()
			Me.VarProp_AutoChangeModeLabel = New Label()
			Me.VarProp_AutoChangeMode = New ComboBox()
			Me.Variable_Name_Label = New Label()
			Me.VarProp_Name = New TextBox()
			Me.VarProp_Type_Label = New Label()
			Me.VarProp_Type = New ComboBox()
			Me.VarProp_Value_Label = New Label()
			Me.VarProp_Value = New TextBox()
			Me.VarProp_OK_Button = New Button()
			Me.VarProp_Cancel_Button = New Button()
			MyBase.SuspendLayout()
			Dim location As Point = New Point(8, 168)
			Me.VarProp_AutoChangeValue_Label.Location = location
			Me.VarProp_AutoChangeValue_Label.Name = "VarProp_AutoChangeValue_Label"
			Dim size As Size = New Size(80, 16)
			Me.VarProp_AutoChangeValue_Label.Size = size
			Me.VarProp_AutoChangeValue_Label.TabIndex = 26
			Me.VarProp_AutoChangeValue_Label.Text = "Change value"
			Dim location2 As Point = New Point(104, 168)
			Me.VarProp_AutoChangeValue.Location = location2
			Me.VarProp_AutoChangeValue.Name = "VarProp_AutoChangeValue"
			Dim size2 As Size = New Size(184, 20)
			Me.VarProp_AutoChangeValue.Size = size2
			Me.VarProp_AutoChangeValue.TabIndex = 25
			Me.VarProp_AutoChangeValue.Text = ""
			Dim location3 As Point = New Point(8, 136)
			Me.VarProp_AutoChangePeriod_Label.Location = location3
			Me.VarProp_AutoChangePeriod_Label.Name = "VarProp_AutoChangePeriod_Label"
			Dim size3 As Size = New Size(80, 16)
			Me.VarProp_AutoChangePeriod_Label.Size = size3
			Me.VarProp_AutoChangePeriod_Label.TabIndex = 24
			Me.VarProp_AutoChangePeriod_Label.Text = "Change period"
			Dim location4 As Point = New Point(104, 136)
			Me.VarProp_AutoChangePeriod.Location = location4
			Me.VarProp_AutoChangePeriod.Name = "VarProp_AutoChangePeriod"
			Dim size4 As Size = New Size(184, 20)
			Me.VarProp_AutoChangePeriod.Size = size4
			Me.VarProp_AutoChangePeriod.TabIndex = 23
			Me.VarProp_AutoChangePeriod.Text = ""
			Dim location5 As Point = New Point(8, 104)
			Me.VarProp_AutoChangeModeLabel.Location = location5
			Me.VarProp_AutoChangeModeLabel.Name = "VarProp_AutoChangeModeLabel"
			Dim size5 As Size = New Size(96, 16)
			Me.VarProp_AutoChangeModeLabel.Size = size5
			Me.VarProp_AutoChangeModeLabel.TabIndex = 22
			Me.VarProp_AutoChangeModeLabel.Text = "AutoChangeMode"
			Me.VarProp_AutoChangeMode.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location6 As Point = New Point(104, 104)
			Me.VarProp_AutoChangeMode.Location = location6
			Me.VarProp_AutoChangeMode.Name = "VarProp_AutoChangeMode"
			Dim size6 As Size = New Size(184, 21)
			Me.VarProp_AutoChangeMode.Size = size6
			Me.VarProp_AutoChangeMode.TabIndex = 21
			AddHandler Me.VarProp_AutoChangeMode.SelectedIndexChanged, AddressOf Me.VarProp_AutoChangeMode_SelectedIndexChanged
			Dim location7 As Point = New Point(8, 8)
			Me.Variable_Name_Label.Location = location7
			Me.Variable_Name_Label.Name = "Variable_Name_Label"
			Dim size7 As Size = New Size(40, 16)
			Me.Variable_Name_Label.Size = size7
			Me.Variable_Name_Label.TabIndex = 15
			Me.Variable_Name_Label.Text = "Name"
			Dim location8 As Point = New Point(56, 8)
			Me.VarProp_Name.Location = location8
			Me.VarProp_Name.Name = "VarProp_Name"
			Dim size8 As Size = New Size(184, 20)
			Me.VarProp_Name.Size = size8
			Me.VarProp_Name.TabIndex = 17
			Me.VarProp_Name.Text = ""
			Dim location9 As Point = New Point(8, 40)
			Me.VarProp_Type_Label.Location = location9
			Me.VarProp_Type_Label.Name = "VarProp_Type_Label"
			Dim size9 As Size = New Size(40, 16)
			Me.VarProp_Type_Label.Size = size9
			Me.VarProp_Type_Label.TabIndex = 16
			Me.VarProp_Type_Label.Text = "Type"
			Me.VarProp_Type.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location10 As Point = New Point(56, 40)
			Me.VarProp_Type.Location = location10
			Me.VarProp_Type.Name = "VarProp_Type"
			Dim size10 As Size = New Size(184, 21)
			Me.VarProp_Type.Size = size10
			Me.VarProp_Type.TabIndex = 19
			AddHandler Me.VarProp_Type.SelectedIndexChanged, AddressOf Me.VarProp_Type_SelectedIndexChanged
			Dim location11 As Point = New Point(8, 72)
			Me.VarProp_Value_Label.Location = location11
			Me.VarProp_Value_Label.Name = "VarProp_Value_Label"
			Dim size11 As Size = New Size(40, 16)
			Me.VarProp_Value_Label.Size = size11
			Me.VarProp_Value_Label.TabIndex = 18
			Me.VarProp_Value_Label.Text = "Value"
			Dim location12 As Point = New Point(56, 72)
			Me.VarProp_Value.Location = location12
			Me.VarProp_Value.Name = "VarProp_Value"
			Dim size12 As Size = New Size(184, 20)
			Me.VarProp_Value.Size = size12
			Me.VarProp_Value.TabIndex = 20
			Me.VarProp_Value.Text = ""
			Dim location13 As Point = New Point(120, 208)
			Me.VarProp_OK_Button.Location = location13
			Me.VarProp_OK_Button.Name = "VarProp_OK_Button"
			Dim size13 As Size = New Size(80, 23)
			Me.VarProp_OK_Button.Size = size13
			Me.VarProp_OK_Button.TabIndex = 27
			Me.VarProp_OK_Button.Text = "OK"
			AddHandler Me.VarProp_OK_Button.Click, AddressOf Me.VarProp_OK_Button_Click
			Me.VarProp_Cancel_Button.DialogResult = DialogResult.Cancel
			Dim location14 As Point = New Point(208, 208)
			Me.VarProp_Cancel_Button.Location = location14
			Me.VarProp_Cancel_Button.Name = "VarProp_Cancel_Button"
			Dim size14 As Size = New Size(80, 23)
			Me.VarProp_Cancel_Button.Size = size14
			Me.VarProp_Cancel_Button.TabIndex = 28
			Me.VarProp_Cancel_Button.Text = "Cancel"
			MyBase.AcceptButton = Me.VarProp_OK_Button
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			MyBase.CancelButton = Me.VarProp_Cancel_Button
			Dim clientSize As Size = New Size(296, 245)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.VarProp_Cancel_Button)
			MyBase.Controls.Add(Me.VarProp_OK_Button)
			MyBase.Controls.Add(Me.VarProp_AutoChangeValue_Label)
			MyBase.Controls.Add(Me.VarProp_AutoChangeValue)
			MyBase.Controls.Add(Me.VarProp_AutoChangePeriod)
			MyBase.Controls.Add(Me.VarProp_Name)
			MyBase.Controls.Add(Me.VarProp_Value)
			MyBase.Controls.Add(Me.VarProp_AutoChangePeriod_Label)
			MyBase.Controls.Add(Me.VarProp_AutoChangeModeLabel)
			MyBase.Controls.Add(Me.VarProp_AutoChangeMode)
			MyBase.Controls.Add(Me.Variable_Name_Label)
			MyBase.Controls.Add(Me.VarProp_Type_Label)
			MyBase.Controls.Add(Me.VarProp_Type)
			MyBase.Controls.Add(Me.VarProp_Value_Label)
			MyBase.MaximizeBox = False
			Dim maximumSize As Size = New Size(304, 272)
			Me.MaximumSize = maximumSize
			Dim minimumSize As Size = New Size(304, 272)
			Me.MinimumSize = minimumSize
			MyBase.Name = "ScriptVariablePropertiesForm"
			MyBase.SizeGripStyle = SizeGripStyle.Hide
			Me.Text = "Variable Properties"
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub SetFrom(editor As __Pointer(Of cEditor), trigger As __Pointer(Of cTrigger), variable As __Pointer(Of cVariable))
			Me.Editor = editor
			Me.Trigger = trigger
			Dim ptr As __Pointer(Of Integer) = CType((AddressOf <Module>.ScriptEditor.ValueTypeList), __Pointer(Of Integer))
			If <Module>.ScriptEditor.ValueTypeList <> 31 Then
				Do
					ptr += 4 / __SizeOf(Integer)
				Loop While __Dereference(CType(ptr, __Pointer(Of Integer))) <> 31
			End If
			Dim num As Integer = ptr - <Module>.ScriptEditor.ValueTypeList / __SizeOf(Integer) >> 2
			Dim array As Object() = New Object(num - 1) {}
			Dim ptr2 As __Pointer(Of Integer) = CType((AddressOf <Module>.ScriptEditor.ValueTypeList), __Pointer(Of Integer))
			Dim num2 As Integer = 0
			If 0 < num Then
				Do
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.GetValueTypeAsString(AddressOf gBaseString<char>, __Dereference(CType(ptr2, __Pointer(Of Integer))))
					Try
						Dim num3 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
						Dim value As __Pointer(Of SByte)
						If num3 <> 0UI Then
							value = num3
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						array(num2) = New String(CType(value, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
						gBaseString<char> = 0
					End If
					num2 += 1
					ptr2 += 4 / __SizeOf(Integer)
				Loop While num2 < num
			End If
			Me.VarProp_Type.Items.Clear()
			Me.VarProp_Type.Items.AddRange(array)
			Dim array2 As Object() = New Object(2) {}
			Dim num4 As Integer = 0
			Do
				Dim gBaseString<char>2 As GBaseString<char>
				Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.?GetAutoChangeModeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eAutoChange_Mode@cVariable@Script@@@Z(AddressOf gBaseString<char>2, num4)
				Try
					Dim num5 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
					Dim value2 As __Pointer(Of SByte)
					If num5 <> 0UI Then
						value2 = num5
					Else
						value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					array2(num4) = New String(CType(value2, __Pointer(Of SByte)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>2 IsNot Nothing Then
					<Module>.free(gBaseString<char>2)
					gBaseString<char>2 = 0
				End If
				num4 += 1
			Loop While num4 < 3
			Me.VarProp_AutoChangeMode.Items.Clear()
			Me.VarProp_AutoChangeMode.Items.AddRange(array2)
			Dim flag As Boolean = <Module>.ScriptEditor.cVariable.IsConstant(variable) IsNot Nothing
			Dim ptr5 As __Pointer(Of Integer) = CType((AddressOf <Module>.ScriptEditor.ValueTypeList), __Pointer(Of Integer))
			If <Module>.ScriptEditor.ValueTypeList <> 31 Then
				Dim num6 As Integer = __Dereference((variable + 16))
				Dim num7 As Integer = <Module>.ScriptEditor.ValueTypeList
				While num7 <> num6
					ptr5 += 4 / __SizeOf(Integer)
					num7 = __Dereference(CType(ptr5, __Pointer(Of Integer)))
					If num7 = 31 Then
						Exit While
					End If
				End While
			End If
			Dim var_Used As Integer = __Dereference((variable + 32))
			Me.Var_Used = var_Used
			Dim num8 As UInteger = CUInt((__Dereference(<Module>.ScriptEditor.cVariable.GetName(variable))))
			Dim value3 As __Pointer(Of SByte)
			If num8 <> 0UI Then
				value3 = num8
			Else
				value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
			End If
			Me.VarProp_Name.Text = New String(CType(value3, __Pointer(Of SByte)))
			If flag Then
				Me.VarProp_Type.Enabled = False
				Me.VarProp_Type.SelectedIndex = -1
				Me.VarProp_Value.Enabled = False
				Me.VarProp_Value.Text = "0"
			Else
				Dim enabled As Byte
				If __Dereference((variable + 32)) = 0 AndAlso __Dereference((variable + 40)) = 0 Then
					enabled = 1
				Else
					enabled = 0
				End If
				Me.VarProp_Type.Enabled = (enabled <> 0)
				Me.VarProp_Type.SelectedIndex = ptr5 - <Module>.ScriptEditor.ValueTypeList / __SizeOf(Integer) >> 2
				Dim ptr6 As __Pointer(Of cVariable) = variable + 16
				If __Dereference(ptr6) - 1 <= 1 Then
					Me.VarProp_Value.Enabled = True
					Dim gBaseString<char>3 As GBaseString<char>
					Dim ptr7 As __Pointer(Of GBaseString<char>) = <Module>.ScriptEditor.sValue.GetAsEditingString(ptr6, AddressOf gBaseString<char>3)
					Try
						Dim num9 As UInteger = CUInt((__Dereference(CType(ptr7, __Pointer(Of Integer)))))
						Dim value4 As __Pointer(Of SByte)
						If num9 <> 0UI Then
							value4 = num9
						Else
							value4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.VarProp_Value.Text = New String(CType(value4, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>3 IsNot Nothing Then
						<Module>.free(gBaseString<char>3)
						gBaseString<char>3 = 0
					End If
				Else
					Me.VarProp_Value.Enabled = False
					Me.VarProp_Value.Text = "0"
				End If
				If __Dereference(ptr6) = 2 Then
					Me.VarProp_AutoChangeMode.Enabled = True
					Me.VarProp_AutoChangeMode.SelectedIndex = __Dereference((variable + 40))
					If __Dereference((variable + 40)) = 0 Then
						Me.VarProp_AutoChangePeriod.Enabled = False
						Me.VarProp_AutoChangePeriod.Text = String.Empty
						Me.VarProp_AutoChangeValue.Enabled = False
						Me.VarProp_AutoChangeValue.Text = String.Empty
						Return
					End If
					Me.VarProp_AutoChangePeriod.Enabled = True
					Dim num10 As Integer = __Dereference((variable + 48))
					Me.VarProp_AutoChangePeriod.Text = String.Format(New String(CType((AddressOf <Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@), __Pointer(Of SByte))), num10)
					Me.VarProp_AutoChangeValue.Enabled = True
					Dim num11 As Integer = __Dereference((variable + 44))
					Me.VarProp_AutoChangeValue.Text = String.Format(New String(CType((AddressOf <Module>.??_C@_03NMHPOFFF@?$HL0?$HN?$AA@), __Pointer(Of SByte))), num11)
					Return
				End If
			End If
			Me.VarProp_AutoChangeMode.Enabled = False
			Me.VarProp_AutoChangeMode.SelectedIndex = 0
			Me.VarProp_AutoChangePeriod.Enabled = False
			Me.VarProp_AutoChangePeriod.Text = String.Empty
			Me.VarProp_AutoChangeValue.Enabled = False
			Me.VarProp_AutoChangeValue.Text = String.Empty
		End Sub

		Private Sub VarProp_OK_Button_Click(sender As Object, e As EventArgs)
			MyBase.DialogResult = DialogResult.OK
			MyBase.Close()
		End Sub

		Private Sub VarProp_Type_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim num As Integer = __Dereference((Me.VarProp_Type.SelectedIndex * 4 + <Module>.ScriptEditor.ValueTypeList))
			If num > 0 AndAlso num <= 2 Then
				Me.VarProp_Value.Enabled = True
			Else
				Me.VarProp_Value.Enabled = False
			End If
			If num = 2 Then
				Me.VarProp_AutoChangeMode.Enabled = True
				If Me.VarProp_AutoChangeMode.SelectedIndex = 0 Then
					Me.VarProp_AutoChangePeriod.Enabled = False
					Me.VarProp_AutoChangeValue.Enabled = False
				Else
					Me.VarProp_AutoChangePeriod.Enabled = True
					Me.VarProp_AutoChangeValue.Enabled = True
				End If
			Else
				Me.VarProp_AutoChangeMode.Enabled = False
				Me.VarProp_AutoChangePeriod.Enabled = False
				Me.VarProp_AutoChangeValue.Enabled = False
			End If
		End Sub

		Private Sub VarProp_AutoChangeMode_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Me.VarProp_AutoChangeMode.SelectedIndex = 0 Then
				Dim enabled As Byte = If((Me.Var_Used = 0), 1, 0)
				Me.VarProp_Type.Enabled = (enabled <> 0)
				Me.VarProp_AutoChangePeriod.Enabled = False
				Me.VarProp_AutoChangeValue.Enabled = False
			Else
				Me.VarProp_Type.Enabled = False
				Me.VarProp_AutoChangePeriod.Enabled = True
				Me.VarProp_AutoChangeValue.Enabled = True
			End If
		End Sub
	End Class
End Namespace
