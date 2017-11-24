Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class ColorPickerDialog
		Inherits Form

		Private OKBtn As Button

		Private CancelBtn As Button

		Private ColorPicker As ColorPicker

		Private AlfaSlider As SliderPanel

		Private components As Container

		Public Sub New()
			Me.InitializeComponent()
			Me.ColorPicker = New ColorPicker()
			Dim location As Point = New Point(10, 10)
			Me.ColorPicker.Location = location
			MyBase.Controls.Add(Me.ColorPicker)
			Dim sliderPanel As SliderPanel = New SliderPanel(0, 255, 15)
			Me.AlfaSlider = sliderPanel
			sliderPanel.Text = "Alfa"
			Dim sz As Size = New Size(0, Me.ColorPicker.Height + 6)
			Dim location2 As Point = Me.ColorPicker.Location + sz
			Me.AlfaSlider.Location = location2
			MyBase.Controls.Add(Me.AlfaSlider)
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
			Me.OKBtn = New Button()
			Me.CancelBtn = New Button()
			MyBase.SuspendLayout()
			Me.OKBtn.DialogResult = DialogResult.OK
			Dim location As Point = New Point(8, 176)
			Me.OKBtn.Location = location
			Me.OKBtn.Name = "OKBtn"
			Dim size As Size = New Size(120, 23)
			Me.OKBtn.Size = size
			Me.OKBtn.TabIndex = 0
			Me.OKBtn.Text = "Accept"
			Me.CancelBtn.DialogResult = DialogResult.Cancel
			Dim location2 As Point = New Point(136, 176)
			Me.CancelBtn.Location = location2
			Me.CancelBtn.Name = "CancelBtn"
			Dim size2 As Size = New Size(120, 23)
			Me.CancelBtn.Size = size2
			Me.CancelBtn.TabIndex = 1
			Me.CancelBtn.Text = "Cancel"
			MyBase.AcceptButton = Me.OKBtn
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			MyBase.CancelButton = Me.CancelBtn
			Dim clientSize As Size = New Size(264, 210)
			MyBase.ClientSize = clientSize
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.CancelBtn)
			MyBase.Controls.Add(Me.OKBtn)
			MyBase.Name = "ColorPickerDialog"
			MyBase.SizeGripStyle = SizeGripStyle.Hide
			Me.Text = "Calibrate color"
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub SetRGBA(r As Single, g As Single, b As Single, a As Single)
			Dim gColor As GColor = r
			__Dereference((gColor + 4)) = g
			__Dereference((gColor + 8)) = b
			__Dereference((gColor + 12)) = a
			<Module>.GColor.Saturate(gColor)
			Dim hue As Integer
			Dim sat As Integer
			Dim val As Integer
			<Module>.GColor.ToHSV(gColor, hue, sat, val)
			Me.ColorPicker.Hue = hue
			Me.ColorPicker.Sat = sat
			Me.ColorPicker.Val = val
			Me.AlfaSlider.Value = <Module>.ffloor(a * 255F)
		End Sub

		Public Sub GetRGBA(r As __Pointer(Of Single), g As __Pointer(Of Single), b As __Pointer(Of Single), a As __Pointer(Of Single))
			Dim gColor As GColor
			__Dereference((gColor + 8)) = 0F
			__Dereference((gColor + 4)) = 0F
			gColor = 0F
			__Dereference((gColor + 12)) = 1F
			Dim colorPicker As ColorPicker = Me.ColorPicker
			<Module>.GColor.FromHSV(gColor, colorPicker.Hue, colorPicker.Sat, colorPicker.Val)
			__Dereference(r) = gColor
			__Dereference(g) = __Dereference((gColor + 4))
			__Dereference(b) = __Dereference((gColor + 8))
			__Dereference(a) = CSng(Me.AlfaSlider.Value) * 0.003921569F
		End Sub
	End Class
End Namespace
