Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class PlayerForm
		Inherits Form

		Public comboBoxColor As ComboBox

		Private radioButtonControl0 As RadioButton

		Private radioButtonControl1 As RadioButton

		Private radioButtonControl2 As RadioButton

		Private radioButtonControl3 As RadioButton

		Private groupBoxResources As GroupBox

		Private labelMoney As Label

		Private numericMoney As NumericUpDown

		Private radioButton1 As RadioButton

		Private radioButton2 As RadioButton

		Private radioButton3 As RadioButton

		Private radioButton4 As RadioButton

		Private radioButton5 As RadioButton

		Private groupBoxTargetElector As GroupBox

		Private radioButton6 As RadioButton

		Private radioButtonControl5 As RadioButton

		Private radioButtonControl4 As RadioButton

		Private groupBoxColor As GroupBox

		Private groupBoxTeam As GroupBox

		Private groupBoxControl As GroupBox

		Private groupBoxRace As GroupBox

		Private radioButtonTeam1 As RadioButton

		Private radioButtonTeam2 As RadioButton

		Private radioButtonTeam3 As RadioButton

		Private radioButtonTeam4 As RadioButton

		Private radioButtonTeam0 As RadioButton

		Private radioButtonRace0 As RadioButton

		Private radioButtonRace1 As RadioButton

		Private radioButtonRace2 As RadioButton

		Private radioButtonRace3 As RadioButton

		Private radioButtonRace4 As RadioButton

		Private radioButtonRace5 As RadioButton

		Private buttonOK As Button

		Private buttonCancel As Button

		Private components As Container

		Public Property Money() As Integer
			Get
				Return Decimal.ToInt32(Me.numericMoney.Value)
			End Get
			Set(value As Integer)
				Dim value2 As Decimal = New Decimal(value)
				Me.numericMoney.Value = value2
			End Set
		End Property

		Public Sub New()
			Me.InitializeComponent()
			Dim items As Object() = New Object() { "Red", "Orange", "Yellow", "Green", "Cyan", "Blue", "Purple", "Pink", "Black", "Grey", "White", "Brown" }
			Me.comboBoxColor.Items.AddRange(items)
			MyBase.AcceptButton = Me.buttonOK
			MyBase.CancelButton = Me.buttonCancel
		End Sub

		Public Function GetTeam() As Integer
			Dim enumerator As IEnumerator = Me.groupBoxTeam.Controls.GetEnumerator()
			Dim num As Integer = 0
			If enumerator.MoveNext() Then
				While Not(TryCast(enumerator.Current, RadioButton)).Checked
					num += 1
					If Not enumerator.MoveNext() Then
						Return 0
					End If
				End While
				Return num
			End If
			Return 0
		End Function

		Public Function GetRace() As Integer
			Dim enumerator As IEnumerator = Me.groupBoxRace.Controls.GetEnumerator()
			Dim num As Integer = 0
			If enumerator.MoveNext() Then
				While Not(TryCast(enumerator.Current, RadioButton)).Checked
					num += 1
					If Not enumerator.MoveNext() Then
						Return 0
					End If
				End While
				Return num
			End If
			Return 0
		End Function

		Public Function GetControl() As Integer
			Dim enumerator As IEnumerator = Me.groupBoxControl.Controls.GetEnumerator()
			Dim num As Integer = 0
			If enumerator.MoveNext() Then
				While Not(TryCast(enumerator.Current, RadioButton)).Checked
					num += 1
					If Not enumerator.MoveNext() Then
						Return 0
					End If
				End While
				Return num
			End If
			Return 0
		End Function

		Public Function GetTargetElector() As Integer
			Dim enumerator As IEnumerator = Me.groupBoxTargetElector.Controls.GetEnumerator()
			Dim num As Integer = 0
			If enumerator.MoveNext() Then
				While Not(TryCast(enumerator.Current, RadioButton)).Checked
					num += 1
					If Not enumerator.MoveNext() Then
						Return 0
					End If
				End While
				Return num
			End If
			Return 0
		End Function

		Public Sub SetTeam(idx As Integer)
			If idx >= 0 AndAlso idx < Me.groupBoxTeam.Controls.Count Then
				(TryCast(Me.groupBoxTeam.Controls(idx), RadioButton)).Checked = True
			End If
		End Sub

		Public Sub SetRace(idx As Integer)
			If idx >= 0 AndAlso idx < Me.groupBoxRace.Controls.Count Then
				(TryCast(Me.groupBoxRace.Controls(idx), RadioButton)).Checked = True
			End If
		End Sub

		Public Sub SetControl(idx As Integer)
			If idx >= 0 AndAlso idx < Me.groupBoxControl.Controls.Count Then
				(TryCast(Me.groupBoxControl.Controls(idx), RadioButton)).Checked = True
			End If
		End Sub

		Public Sub SetTargetElector(idx As Integer)
			If idx >= 0 AndAlso idx < Me.groupBoxTargetElector.Controls.Count Then
				(TryCast(Me.groupBoxTargetElector.Controls(idx), RadioButton)).Checked = True
			End If
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
			Me.groupBoxColor = New GroupBox()
			Me.comboBoxColor = New ComboBox()
			Me.groupBoxTeam = New GroupBox()
			Me.radioButtonTeam0 = New RadioButton()
			Me.radioButtonTeam1 = New RadioButton()
			Me.radioButtonTeam2 = New RadioButton()
			Me.radioButtonTeam3 = New RadioButton()
			Me.radioButtonTeam4 = New RadioButton()
			Me.groupBoxRace = New GroupBox()
			Me.radioButtonRace0 = New RadioButton()
			Me.radioButtonRace1 = New RadioButton()
			Me.radioButtonRace2 = New RadioButton()
			Me.radioButtonRace3 = New RadioButton()
			Me.radioButtonRace4 = New RadioButton()
			Me.radioButtonRace5 = New RadioButton()
			Me.buttonOK = New Button()
			Me.buttonCancel = New Button()
			Me.groupBoxControl = New GroupBox()
			Me.radioButtonControl0 = New RadioButton()
			Me.radioButtonControl1 = New RadioButton()
			Me.radioButtonControl2 = New RadioButton()
			Me.radioButtonControl3 = New RadioButton()
			Me.radioButtonControl4 = New RadioButton()
			Me.radioButtonControl5 = New RadioButton()
			Me.groupBoxResources = New GroupBox()
			Me.numericMoney = New NumericUpDown()
			Me.labelMoney = New Label()
			Me.groupBoxTargetElector = New GroupBox()
			Me.radioButton1 = New RadioButton()
			Me.radioButton2 = New RadioButton()
			Me.radioButton3 = New RadioButton()
			Me.radioButton4 = New RadioButton()
			Me.radioButton5 = New RadioButton()
			Me.radioButton6 = New RadioButton()
			Me.groupBoxColor.SuspendLayout()
			Me.groupBoxTeam.SuspendLayout()
			Me.groupBoxRace.SuspendLayout()
			Me.groupBoxControl.SuspendLayout()
			Me.groupBoxResources.SuspendLayout()
			(CType(Me.numericMoney, ISupportInitialize)).BeginInit()
			Me.groupBoxTargetElector.SuspendLayout()
			MyBase.SuspendLayout()
			Me.groupBoxColor.Controls.Add(Me.comboBoxColor)
			Me.groupBoxColor.FlatStyle = FlatStyle.System
			Dim location As Point = New Point(8, 8)
			Me.groupBoxColor.Location = location
			Me.groupBoxColor.Name = "groupBoxColor"
			Dim size As Size = New Size(128, 48)
			Me.groupBoxColor.Size = size
			Me.groupBoxColor.TabIndex = 0
			Me.groupBoxColor.TabStop = False
			Me.groupBoxColor.Text = "Color"
			Me.comboBoxColor.DropDownStyle = ComboBoxStyle.DropDownList
			Dim location2 As Point = New Point(8, 16)
			Me.comboBoxColor.Location = location2
			Me.comboBoxColor.Name = "comboBoxColor"
			Dim size2 As Size = New Size(112, 21)
			Me.comboBoxColor.Size = size2
			Me.comboBoxColor.TabIndex = 0
			Me.groupBoxTeam.Controls.Add(Me.radioButtonTeam0)
			Me.groupBoxTeam.Controls.Add(Me.radioButtonTeam1)
			Me.groupBoxTeam.Controls.Add(Me.radioButtonTeam2)
			Me.groupBoxTeam.Controls.Add(Me.radioButtonTeam3)
			Me.groupBoxTeam.Controls.Add(Me.radioButtonTeam4)
			Me.groupBoxTeam.FlatStyle = FlatStyle.System
			Dim location3 As Point = New Point(144, 136)
			Me.groupBoxTeam.Location = location3
			Me.groupBoxTeam.Name = "groupBoxTeam"
			Dim size3 As Size = New Size(128, 104)
			Me.groupBoxTeam.Size = size3
			Me.groupBoxTeam.TabIndex = 1
			Me.groupBoxTeam.TabStop = False
			Me.groupBoxTeam.Text = "Team"
			Me.radioButtonTeam0.FlatStyle = FlatStyle.System
			Dim location4 As Point = New Point(8, 16)
			Me.radioButtonTeam0.Location = location4
			Me.radioButtonTeam0.Name = "radioButtonTeam0"
			Dim size4 As Size = New Size(104, 16)
			Me.radioButtonTeam0.Size = size4
			Me.radioButtonTeam0.TabIndex = 5
			Me.radioButtonTeam0.Text = "Anarchist"
			Me.radioButtonTeam1.FlatStyle = FlatStyle.System
			Dim location5 As Point = New Point(8, 32)
			Me.radioButtonTeam1.Location = location5
			Me.radioButtonTeam1.Name = "radioButtonTeam1"
			Dim size5 As Size = New Size(104, 16)
			Me.radioButtonTeam1.Size = size5
			Me.radioButtonTeam1.TabIndex = 0
			Me.radioButtonTeam1.Text = "Team 1"
			Me.radioButtonTeam2.FlatStyle = FlatStyle.System
			Dim location6 As Point = New Point(8, 48)
			Me.radioButtonTeam2.Location = location6
			Me.radioButtonTeam2.Name = "radioButtonTeam2"
			Dim size6 As Size = New Size(104, 16)
			Me.radioButtonTeam2.Size = size6
			Me.radioButtonTeam2.TabIndex = 1
			Me.radioButtonTeam2.Text = "Team 2"
			Me.radioButtonTeam3.FlatStyle = FlatStyle.System
			Dim location7 As Point = New Point(8, 64)
			Me.radioButtonTeam3.Location = location7
			Me.radioButtonTeam3.Name = "radioButtonTeam3"
			Dim size7 As Size = New Size(104, 16)
			Me.radioButtonTeam3.Size = size7
			Me.radioButtonTeam3.TabIndex = 2
			Me.radioButtonTeam3.Text = "Team 3"
			Me.radioButtonTeam4.FlatStyle = FlatStyle.System
			Dim location8 As Point = New Point(8, 80)
			Me.radioButtonTeam4.Location = location8
			Me.radioButtonTeam4.Name = "radioButtonTeam4"
			Dim size8 As Size = New Size(104, 16)
			Me.radioButtonTeam4.Size = size8
			Me.radioButtonTeam4.TabIndex = 3
			Me.radioButtonTeam4.Text = "Team 4"
			Me.groupBoxRace.Controls.Add(Me.radioButtonRace0)
			Me.groupBoxRace.Controls.Add(Me.radioButtonRace1)
			Me.groupBoxRace.Controls.Add(Me.radioButtonRace2)
			Me.groupBoxRace.Controls.Add(Me.radioButtonRace3)
			Me.groupBoxRace.Controls.Add(Me.radioButtonRace4)
			Me.groupBoxRace.Controls.Add(Me.radioButtonRace5)
			Me.groupBoxRace.FlatStyle = FlatStyle.System
			Dim location9 As Point = New Point(144, 8)
			Me.groupBoxRace.Location = location9
			Me.groupBoxRace.Name = "groupBoxRace"
			Dim size9 As Size = New Size(128, 120)
			Me.groupBoxRace.Size = size9
			Me.groupBoxRace.TabIndex = 2
			Me.groupBoxRace.TabStop = False
			Me.groupBoxRace.Text = "Faction"
			Me.radioButtonRace0.FlatStyle = FlatStyle.System
			Dim location10 As Point = New Point(8, 16)
			Me.radioButtonRace0.Location = location10
			Me.radioButtonRace0.Name = "radioButtonRace0"
			Dim size10 As Size = New Size(88, 16)
			Me.radioButtonRace0.Size = size10
			Me.radioButtonRace0.TabIndex = 0
			Me.radioButtonRace0.Text = "Iraqi"
			Me.radioButtonRace1.FlatStyle = FlatStyle.System
			Dim location11 As Point = New Point(8, 32)
			Me.radioButtonRace1.Location = location11
			Me.radioButtonRace1.Name = "radioButtonRace1"
			Dim size11 As Size = New Size(88, 16)
			Me.radioButtonRace1.Size = size11
			Me.radioButtonRace1.TabIndex = 1
			Me.radioButtonRace1.Text = "JTF"
			Me.radioButtonRace2.FlatStyle = FlatStyle.System
			Dim location12 As Point = New Point(8, 48)
			Me.radioButtonRace2.Location = location12
			Me.radioButtonRace2.Name = "radioButtonRace2"
			Dim size12 As Size = New Size(88, 16)
			Me.radioButtonRace2.Size = size12
			Me.radioButtonRace2.TabIndex = 2
			Me.radioButtonRace2.Text = "Bosnian"
			Me.radioButtonRace3.FlatStyle = FlatStyle.System
			Dim location13 As Point = New Point(8, 64)
			Me.radioButtonRace3.Location = location13
			Me.radioButtonRace3.Name = "radioButtonRace3"
			Dim size13 As Size = New Size(88, 16)
			Me.radioButtonRace3.Size = size13
			Me.radioButtonRace3.TabIndex = 3
			Me.radioButtonRace3.Text = "Somalian"
			Me.radioButtonRace4.FlatStyle = FlatStyle.System
			Dim location14 As Point = New Point(8, 80)
			Me.radioButtonRace4.Location = location14
			Me.radioButtonRace4.Name = "radioButtonRace4"
			Dim size14 As Size = New Size(88, 16)
			Me.radioButtonRace4.Size = size14
			Me.radioButtonRace4.TabIndex = 4
			Me.radioButtonRace4.Text = "Colombian"
			Me.radioButtonRace5.FlatStyle = FlatStyle.System
			Dim location15 As Point = New Point(8, 96)
			Me.radioButtonRace5.Location = location15
			Me.radioButtonRace5.Name = "radioButtonRace5"
			Dim size15 As Size = New Size(88, 16)
			Me.radioButtonRace5.Size = size15
			Me.radioButtonRace5.TabIndex = 5
			Me.radioButtonRace5.Text = "Afghan"
			Me.buttonOK.FlatStyle = FlatStyle.System
			Dim location16 As Point = New Point(280, 216)
			Me.buttonOK.Location = location16
			Me.buttonOK.Name = "buttonOK"
			Dim size16 As Size = New Size(72, 24)
			Me.buttonOK.Size = size16
			Me.buttonOK.TabIndex = 3
			Me.buttonOK.Text = "OK"
			AddHandler Me.buttonOK.Click, AddressOf Me.buttonOK_Click
			Me.buttonCancel.FlatStyle = FlatStyle.System
			Dim location17 As Point = New Point(360, 216)
			Me.buttonCancel.Location = location17
			Me.buttonCancel.Name = "buttonCancel"
			Dim size17 As Size = New Size(64, 24)
			Me.buttonCancel.Size = size17
			Me.buttonCancel.TabIndex = 4
			Me.buttonCancel.Text = "Cancel"
			AddHandler Me.buttonCancel.Click, AddressOf Me.buttonCancel_Click
			Me.groupBoxControl.Controls.Add(Me.radioButtonControl0)
			Me.groupBoxControl.Controls.Add(Me.radioButtonControl1)
			Me.groupBoxControl.Controls.Add(Me.radioButtonControl2)
			Me.groupBoxControl.Controls.Add(Me.radioButtonControl3)
			Me.groupBoxControl.Controls.Add(Me.radioButtonControl4)
			Me.groupBoxControl.Controls.Add(Me.radioButtonControl5)
			Me.groupBoxControl.FlatStyle = FlatStyle.System
			Dim location18 As Point = New Point(8, 64)
			Me.groupBoxControl.Location = location18
			Me.groupBoxControl.Name = "groupBoxControl"
			Dim size18 As Size = New Size(128, 128)
			Me.groupBoxControl.Size = size18
			Me.groupBoxControl.TabIndex = 5
			Me.groupBoxControl.TabStop = False
			Me.groupBoxControl.Text = "Control"
			Me.radioButtonControl0.FlatStyle = FlatStyle.System
			Dim location19 As Point = New Point(8, 24)
			Me.radioButtonControl0.Location = location19
			Me.radioButtonControl0.Name = "radioButtonControl0"
			Dim size19 As Size = New Size(104, 16)
			Me.radioButtonControl0.Size = size19
			Me.radioButtonControl0.TabIndex = 0
			Me.radioButtonControl0.Text = "Human"
			Me.radioButtonControl1.FlatStyle = FlatStyle.System
			Dim location20 As Point = New Point(8, 40)
			Me.radioButtonControl1.Location = location20
			Me.radioButtonControl1.Name = "radioButtonControl1"
			Dim size20 As Size = New Size(104, 16)
			Me.radioButtonControl1.Size = size20
			Me.radioButtonControl1.TabIndex = 1
			Me.radioButtonControl1.Text = "Computer"
			Me.radioButtonControl2.FlatStyle = FlatStyle.System
			Dim location21 As Point = New Point(8, 56)
			Me.radioButtonControl2.Location = location21
			Me.radioButtonControl2.Name = "radioButtonControl2"
			Dim size21 As Size = New Size(104, 16)
			Me.radioButtonControl2.Size = size21
			Me.radioButtonControl2.TabIndex = 2
			Me.radioButtonControl2.Text = "Neutral"
			Me.radioButtonControl3.FlatStyle = FlatStyle.System
			Dim location22 As Point = New Point(8, 72)
			Me.radioButtonControl3.Location = location22
			Me.radioButtonControl3.Name = "radioButtonControl3"
			Dim size22 As Size = New Size(104, 16)
			Me.radioButtonControl3.Size = size22
			Me.radioButtonControl3.TabIndex = 3
			Me.radioButtonControl3.Text = "Rescuable"
			Me.radioButtonControl4.FlatStyle = FlatStyle.System
			Dim location23 As Point = New Point(8, 88)
			Me.radioButtonControl4.Location = location23
			Me.radioButtonControl4.Name = "radioButtonControl4"
			Dim size23 As Size = New Size(104, 16)
			Me.radioButtonControl4.Size = size23
			Me.radioButtonControl4.TabIndex = 4
			Me.radioButtonControl4.Text = "Spy"
			Me.radioButtonControl5.FlatStyle = FlatStyle.System
			Dim location24 As Point = New Point(8, 104)
			Me.radioButtonControl5.Location = location24
			Me.radioButtonControl5.Name = "radioButtonControl5"
			Dim size24 As Size = New Size(104, 16)
			Me.radioButtonControl5.Size = size24
			Me.radioButtonControl5.TabIndex = 5
			Me.radioButtonControl5.Text = "Civil"
			Me.groupBoxResources.Controls.Add(Me.numericMoney)
			Me.groupBoxResources.Controls.Add(Me.labelMoney)
			Dim location25 As Point = New Point(280, 136)
			Me.groupBoxResources.Location = location25
			Me.groupBoxResources.Name = "groupBoxResources"
			Dim size25 As Size = New Size(144, 64)
			Me.groupBoxResources.Size = size25
			Me.groupBoxResources.TabIndex = 6
			Me.groupBoxResources.TabStop = False
			Me.groupBoxResources.Text = "Resources"
			Dim increment As Decimal = New Decimal(New Integer() { 10, 0, 0, 0 })
			Me.numericMoney.Increment = increment
			Dim location26 As Point = New Point(8, 32)
			Me.numericMoney.Location = location26
			Dim maximum As Decimal = New Decimal(New Integer() { 1000000, 0, 0, 0 })
			Me.numericMoney.Maximum = maximum
			Me.numericMoney.Name = "numericMoney"
			Dim size26 As Size = New Size(112, 20)
			Me.numericMoney.Size = size26
			Me.numericMoney.TabIndex = 2
			Dim location27 As Point = New Point(8, 16)
			Me.labelMoney.Location = location27
			Me.labelMoney.Name = "labelMoney"
			Dim size27 As Size = New Size(56, 23)
			Me.labelMoney.Size = size27
			Me.labelMoney.TabIndex = 1
			Me.labelMoney.Text = "Money"
			Me.groupBoxTargetElector.Controls.Add(Me.radioButton1)
			Me.groupBoxTargetElector.Controls.Add(Me.radioButton2)
			Me.groupBoxTargetElector.Controls.Add(Me.radioButton3)
			Me.groupBoxTargetElector.Controls.Add(Me.radioButton4)
			Me.groupBoxTargetElector.Controls.Add(Me.radioButton5)
			Me.groupBoxTargetElector.Controls.Add(Me.radioButton6)
			Me.groupBoxTargetElector.FlatStyle = FlatStyle.System
			Dim location28 As Point = New Point(280, 8)
			Me.groupBoxTargetElector.Location = location28
			Me.groupBoxTargetElector.Name = "groupBoxTargetElector"
			Dim size28 As Size = New Size(144, 120)
			Me.groupBoxTargetElector.Size = size28
			Me.groupBoxTargetElector.TabIndex = 6
			Me.groupBoxTargetElector.TabStop = False
			Me.groupBoxTargetElector.Text = "Target-elector"
			Me.radioButton1.Enabled = False
			Me.radioButton1.FlatStyle = FlatStyle.System
			Dim location29 As Point = New Point(8, 16)
			Me.radioButton1.Location = location29
			Me.radioButton1.Name = "radioButton1"
			Dim size29 As Size = New Size(120, 16)
			Me.radioButton1.Size = size29
			Me.radioButton1.TabIndex = 0
			Me.radioButton1.Text = "Nearest"
			AddHandler Me.radioButton1.CheckedChanged, AddressOf Me.radioButton1_CheckedChanged
			Me.radioButton2.FlatStyle = FlatStyle.System
			Dim location30 As Point = New Point(8, 32)
			Me.radioButton2.Location = location30
			Me.radioButton2.Name = "radioButton2"
			Dim size30 As Size = New Size(120, 16)
			Me.radioButton2.Size = size30
			Me.radioButton2.TabIndex = 1
			Me.radioButton2.Text = "Best type"
			Me.radioButton3.FlatStyle = FlatStyle.System
			Dim location31 As Point = New Point(8, 48)
			Me.radioButton3.Location = location31
			Me.radioButton3.Name = "radioButton3"
			Dim size31 As Size = New Size(128, 16)
			Me.radioButton3.Size = size31
			Me.radioButton3.TabIndex = 2
			Me.radioButton3.Text = "Best damage/danger"
			Me.radioButton4.Enabled = False
			Me.radioButton4.FlatStyle = FlatStyle.System
			Dim location32 As Point = New Point(8, 64)
			Me.radioButton4.Location = location32
			Me.radioButton4.Name = "radioButton4"
			Dim size32 As Size = New Size(120, 16)
			Me.radioButton4.Size = size32
			Me.radioButton4.TabIndex = 3
			Me.radioButton4.Text = "Fastest kill"
			Me.radioButton5.Enabled = False
			Me.radioButton5.FlatStyle = FlatStyle.System
			Dim location33 As Point = New Point(8, 80)
			Me.radioButton5.Location = location33
			Me.radioButton5.Name = "radioButton5"
			Dim size33 As Size = New Size(120, 16)
			Me.radioButton5.Size = size33
			Me.radioButton5.TabIndex = 4
			Me.radioButton5.Text = "Fastest kill/danger"
			Me.radioButton6.FlatStyle = FlatStyle.System
			Dim location34 As Point = New Point(8, 96)
			Me.radioButton6.Location = location34
			Me.radioButton6.Name = "radioButton6"
			Dim size34 As Size = New Size(120, 16)
			Me.radioButton6.Size = size34
			Me.radioButton6.TabIndex = 5
			Me.radioButton6.Text = "Fastest kill/reward"
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(432, 245)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.groupBoxResources)
			MyBase.Controls.Add(Me.groupBoxControl)
			MyBase.Controls.Add(Me.buttonCancel)
			MyBase.Controls.Add(Me.buttonOK)
			MyBase.Controls.Add(Me.groupBoxRace)
			MyBase.Controls.Add(Me.groupBoxTeam)
			MyBase.Controls.Add(Me.groupBoxColor)
			MyBase.Controls.Add(Me.groupBoxTargetElector)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "PlayerForm"
			MyBase.SizeGripStyle = SizeGripStyle.Hide
			Me.Text = "Player properties"
			Me.groupBoxColor.ResumeLayout(False)
			Me.groupBoxTeam.ResumeLayout(False)
			Me.groupBoxRace.ResumeLayout(False)
			Me.groupBoxControl.ResumeLayout(False)
			Me.groupBoxResources.ResumeLayout(False)
			(CType(Me.numericMoney, ISupportInitialize)).EndInit()
			Me.groupBoxTargetElector.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub buttonOK_Click(sender As Object, e As EventArgs)
			MyBase.DialogResult = DialogResult.OK
		End Sub

		Private Sub buttonCancel_Click(sender As Object, e As EventArgs)
			MyBase.DialogResult = DialogResult.Cancel
		End Sub

		Private Sub radioButton1_CheckedChanged(sender As Object, e As EventArgs)
		End Sub
	End Class
End Namespace
