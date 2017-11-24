Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class SliderPanel
		Inherits Control

		Public Delegate Sub __Delegate_ValueChanged()

		Private components As Container

		Private lblValue As Label

		Private tbValue As TextBox

		Private trkValue As TrackBar

		Private SliderPanelBitmap As Bitmap

		Private propValue As Integer

		Private MinimumValue As Integer

		Private MaximumValue As Integer

		Public Custom Event ValueChanged As SliderPanel.__Delegate_ValueChanged
			AddHandler
				Me.ValueChanged = [Delegate].Combine(Me.ValueChanged, value)
			End AddHandler
			RemoveHandler
				Me.ValueChanged = [Delegate].Remove(Me.ValueChanged, value)
			End RemoveHandler
		End Event

		Public Overrides WriteOnly Property Text() As String
			Set(value As String)
				MyBase.Text = value
				Dim label As Label = Me.lblValue
				If label IsNot Nothing Then
					label.Text = value
				End If
			End Set
		End Property

		Public Property Value() As Integer
			Get
				Return Me.propValue
			End Get
			Set(value As Integer)
				Me.propValue = value
				Dim num As Integer = value
				Me.tbValue.Text = num.ToString()
				Me.trkValue.Value = value
			End Set
		End Property

		Public Sub New(min_value As Integer, max_value As Integer, tick_frequency As Integer)
			Me.ValueChanged = Nothing
			Dim num As Integer = If((0 > min_value), 0, min_value)
			Dim num2 As Integer
			If num < max_value Then
				num2 = num
			Else
				num2 = max_value
			End If
			Me.propValue = num2
			Me.MinimumValue = min_value
			Me.MaximumValue = max_value
			Me.InitializeComponent()
			Me.lblValue = New Label()
			Dim location As Point = New Point(0, 1)
			Me.lblValue.Location = location
			Me.lblValue.Name = "lblValue"
			Dim size As Size = New Size(48, 21)
			Me.lblValue.Size = size
			Me.lblValue.TabIndex = 0
			Me.lblValue.Text = "Value"
			Me.lblValue.TextAlign = ContentAlignment.MiddleRight
			MyBase.Controls.Add(Me.lblValue)
			Me.tbValue = New TextBox()
			Dim location2 As Point = New Point(48, 1)
			Me.tbValue.Location = location2
			Me.tbValue.Name = "tbValue"
			Dim size2 As Size = New Size(32, 21)
			Me.tbValue.Size = size2
			Me.tbValue.TabIndex = 3
			Me.tbValue.Text = "0"
			AddHandler Me.tbValue.Validated, AddressOf Me.tbValue_Validated
			MyBase.Controls.Add(Me.tbValue)
			Dim trackBar As TrackBar = New TrackBar()
			Me.trkValue = trackBar
			trackBar.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim location3 As Point = New Point(80, 0)
			Me.trkValue.Location = location3
			Me.trkValue.Maximum = Me.MaximumValue
			Me.trkValue.Minimum = Me.MinimumValue
			Me.trkValue.Name = "trkValue"
			Dim size3 As Size = New Size(168, 45)
			Me.trkValue.Size = size3
			Me.trkValue.TabIndex = 2
			Me.trkValue.TickFrequency = tick_frequency
			Me.trkValue.Value = Me.propValue
			AddHandler Me.trkValue.Scroll, AddressOf Me.trkValue_Scroll
			MyBase.Controls.Add(Me.trkValue)
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
			Me.components = New Container()
			Dim size As Size = New Size(256, 28)
			MyBase.Size = size
			Me.Text = "SliderPanel"
		End Sub

		Private Sub tbValue_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = 0
			Try
				num2 = Integer.Parse(Me.tbValue.Text)
				GoTo IL_72
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_72:
			Dim maximumValue As Integer = Me.MaximumValue
			If num2 > maximumValue Then
				num2 = maximumValue
			Else
				Dim minimumValue As Integer = Me.MinimumValue
				If num2 < minimumValue Then
					num2 = minimumValue
				End If
			End If
			Me.propValue = num2
			Dim num3 As Integer = num2
			Me.tbValue.Text = num3.ToString()
			Me.trkValue.Value = Me.propValue
			Me.raise_ValueChanged()
		End Sub

		Private Sub trkValue_Scroll(sender As Object, e As EventArgs)
			Dim value As Integer = Me.trkValue.Value
			Me.propValue = value
			Dim num As Integer = value
			Me.tbValue.Text = num.ToString()
			Me.raise_ValueChanged()
		End Sub

		Protected Sub raise_ValueChanged()
			Dim valueChanged As SliderPanel.__Delegate_ValueChanged = Me.ValueChanged
			If valueChanged IsNot Nothing Then
				valueChanged()
			End If
		End Sub
	End Class
End Namespace
