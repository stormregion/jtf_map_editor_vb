Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxBuildingProperties
		Inherits UserControl

		Public Delegate Sub __Delegate_PropertiesChanged( As __Pointer(Of GUnitStats))

		Private label2 As Label

		Private textBoxScriptID As TextBox

		Private label13 As Label

		Private checkBoxUnloadAtCriticalDamage As CheckBox

		Private label1 As Label

		Private label3 As Label

		Private textBoxHPConcrete As TextBox

		Private textBoxHP As TextBox

		Private Stats As __Pointer(Of GUnitStats)

		Private World As __Pointer(Of GWorld)

		Private components As Container

		Public Custom Event PropertiesChanged As ToolboxBuildingProperties.__Delegate_PropertiesChanged
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
			Me.textBoxScriptID.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxScriptID.Enabled = False
			Me.checkBoxUnloadAtCriticalDamage.Enabled = False
			Me.textBoxHP.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxHP.Enabled = False
			Me.textBoxHPConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Me.textBoxHPConcrete.Enabled = False
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
			Me.textBoxScriptID = New TextBox()
			Me.label2 = New Label()
			Me.label13 = New Label()
			Me.checkBoxUnloadAtCriticalDamage = New CheckBox()
			Me.label1 = New Label()
			Me.textBoxHPConcrete = New TextBox()
			Me.label3 = New Label()
			Me.textBoxHP = New TextBox()
			MyBase.SuspendLayout()
			Dim location As Point = New Point(56, 8)
			Me.textBoxScriptID.Location = location
			Me.textBoxScriptID.Name = "textBoxScriptID"
			Dim size As Size = New Size(200, 20)
			Me.textBoxScriptID.Size = size
			Me.textBoxScriptID.TabIndex = 1
			Me.textBoxScriptID.Text = "ScriptID"
			AddHandler Me.textBoxScriptID.KeyDown, AddressOf Me.textBoxScriptID_KeyDown
			AddHandler Me.textBoxScriptID.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location2 As Point = New Point(0, 8)
			Me.label2.Location = location2
			Me.label2.Name = "label2"
			Dim size2 As Size = New Size(48, 24)
			Me.label2.Size = size2
			Me.label2.TabIndex = 3
			Me.label2.Text = "ScriptID:"
			Me.label2.TextAlign = ContentAlignment.MiddleRight
			Dim location3 As Point = New Point(104, 32)
			Me.label13.Location = location3
			Me.label13.Name = "label13"
			Dim size3 As Size = New Size(136, 24)
			Me.label13.Size = size3
			Me.label13.TabIndex = 19
			Me.label13.Text = "Unload at critical damage"
			Me.label13.TextAlign = ContentAlignment.MiddleLeft
			Dim location4 As Point = New Point(240, 32)
			Me.checkBoxUnloadAtCriticalDamage.Location = location4
			Me.checkBoxUnloadAtCriticalDamage.Name = "checkBoxUnloadAtCriticalDamage"
			Dim size4 As Size = New Size(16, 24)
			Me.checkBoxUnloadAtCriticalDamage.Size = size4
			Me.checkBoxUnloadAtCriticalDamage.TabIndex = 18
			Me.checkBoxUnloadAtCriticalDamage.Text = "checkBox1"
			Me.checkBoxUnloadAtCriticalDamage.ThreeState = True
			AddHandler Me.checkBoxUnloadAtCriticalDamage.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			Dim location5 As Point = New Point(56, 32)
			Me.label1.Location = location5
			Me.label1.Name = "label1"
			Dim size5 As Size = New Size(24, 24)
			Me.label1.Size = size5
			Me.label1.TabIndex = 24
			Me.label1.Text = "%"
			Me.label1.TextAlign = ContentAlignment.MiddleLeft
			Me.textBoxHPConcrete.Enabled = False
			Dim location6 As Point = New Point(80, 32)
			Me.textBoxHPConcrete.Location = location6
			Me.textBoxHPConcrete.Name = "textBoxHPConcrete"
			Dim size6 As Size = New Size(24, 20)
			Me.textBoxHPConcrete.Size = size6
			Me.textBoxHPConcrete.TabIndex = 23
			Me.textBoxHPConcrete.Text = "HP"
			Dim location7 As Point = New Point(8, 32)
			Me.label3.Location = location7
			Me.label3.Name = "label3"
			Dim size7 As Size = New Size(24, 24)
			Me.label3.Size = size7
			Me.label3.TabIndex = 22
			Me.label3.Text = "HP"
			Me.label3.TextAlign = ContentAlignment.MiddleLeft
			Dim location8 As Point = New Point(32, 32)
			Me.textBoxHP.Location = location8
			Me.textBoxHP.Name = "textBoxHP"
			Dim size8 As Size = New Size(24, 20)
			Me.textBoxHP.Size = size8
			Me.textBoxHP.TabIndex = 21
			Me.textBoxHP.Text = "HP"
			AddHandler Me.textBoxHP.Validated, AddressOf Me.ToolboxUnitProperties_Validated
			MyBase.Controls.Add(Me.label1)
			MyBase.Controls.Add(Me.textBoxHPConcrete)
			MyBase.Controls.Add(Me.label3)
			MyBase.Controls.Add(Me.textBoxHP)
			MyBase.Controls.Add(Me.label13)
			MyBase.Controls.Add(Me.checkBoxUnloadAtCriticalDamage)
			MyBase.Controls.Add(Me.label2)
			MyBase.Controls.Add(Me.textBoxScriptID)
			MyBase.Name = "ToolboxBuildingProperties"
			Dim size9 As Size = New Size(264, 64)
			MyBase.Size = size9
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub Refresh(world As __Pointer(Of GEditorWorld))
			<Module>.GEditorWorld.GetSelectedWUnitStats(world, Me.Stats)
			If(If((<Module>.GBaseString<char>.Compare(Me.Stats + 4 / __SizeOf(GUnitStats), CType((AddressOf <Module>.??_C@_02PGHGPEOM@?91?$AA@), __Pointer(Of SByte)), False) = 0), 1, 0)) <> 0 Then
				Me.textBoxScriptID.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxScriptID.Enabled = False
			Else If(If((<Module>.GBaseString<char>.Compare(Me.Stats + 4 / __SizeOf(GUnitStats), CType((AddressOf <Module>.??_C@_02NNFLKHCP@?92?$AA@), __Pointer(Of SByte)), False) = 0), 1, 0)) <> 0 Then
				Me.textBoxScriptID.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxScriptID.Enabled = True
			Else
				Dim num As UInteger = CUInt((__Dereference(CType((Me.Stats + 4 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))))
				Dim value As __Pointer(Of SByte)
				If num <> 0UI Then
					value = num
				Else
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				Me.textBoxScriptID.Text = New String(CType(value, __Pointer(Of SByte)))
				Me.textBoxScriptID.Enabled = True
			End If
			Dim num2 As Integer = __Dereference(CType((Me.Stats + 72 / __SizeOf(GUnitStats)), __Pointer(Of Integer)))
			If num2 = -1 Then
				Me.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Indeterminate
				Me.checkBoxUnloadAtCriticalDamage.Enabled = False
			Else If num2 = -2 Then
				Me.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Indeterminate
				Me.checkBoxUnloadAtCriticalDamage.Enabled = True
			Else
				If num2 <> 0 Then
					Me.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Checked
				Else
					Me.checkBoxUnloadAtCriticalDamage.CheckState = CheckState.Unchecked
				End If
				Me.checkBoxUnloadAtCriticalDamage.Enabled = True
			End If
			Dim ptr As __Pointer(Of GUnitStats) = Me.Stats + 20 / __SizeOf(GUnitStats)
			Dim num3 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
			If num3 = -1 Then
				Me.textBoxHP.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxHP.Enabled = False
			Else If num3 = -2 Then
				Me.textBoxHP.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
				Me.textBoxHP.Enabled = True
			Else
				Dim num4 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
				Me.textBoxHP.Text = num4.ToString()
				Me.textBoxHP.Enabled = True
			End If
			Dim ptr2 As __Pointer(Of GUnitStats) = Me.Stats + 24 / __SizeOf(GUnitStats)
			Dim num5 As Integer = __Dereference(CType(ptr2, __Pointer(Of Integer)))
			If num5 = -1 Then
				Me.textBoxHPConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Else If num5 = -2 Then
				Me.textBoxHPConcrete.Text = New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte)))
			Else
				Dim num6 As Integer = __Dereference(CType(ptr2, __Pointer(Of Integer)))
				Me.textBoxHPConcrete.Text = num6.ToString()
			End If
		End Sub

		Public Sub UpdateStats()
			Dim gBaseString<char> As GBaseString<char> = 0
			__Dereference((gBaseString<char> + 4)) = 0
			Try
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
					gBaseString<char>2 = 0
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
					gBaseString<char>3 = 0
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
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
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

		Protected Sub raise_PropertiesChanged(i1 As __Pointer(Of GUnitStats))
			Dim propertiesChanged As ToolboxBuildingProperties.__Delegate_PropertiesChanged = Me.PropertiesChanged
			If propertiesChanged IsNot Nothing Then
				propertiesChanged(i1)
			End If
		End Sub
	End Class
End Namespace
