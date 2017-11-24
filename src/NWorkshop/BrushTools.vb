Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class BrushTools
		Inherits UserControl
		Implements IRearrangeableControl

		Public Delegate Sub BrushParametersChangeHandler(size1 As Single, size2 As Single, pressure As Single, height As Single)

		Private panPressure As Panel

		Private lblPressure As Label

		Private tbPressure As TextBox

		Private trkPressure As TrackBar

		Private panSize2 As Panel

		Private lblSize2 As Label

		Private tbSize2 As TextBox

		Private trkSize2 As TrackBar

		Private panSize1 As Panel

		Private lblSize1 As Label

		Private tbSize1 As TextBox

		Private trkSize1 As TrackBar

		Private panHeight As Panel

		Private lblHeight As Label

		Private tbHeight As TextBox

		Private trkHeight As TrackBar

		Private components As Container

		Private BrushTypeTools As Toolbar

		Private propBrushSize1 As Single

		Private propBrushSize2 As Single

		Private propBrushPressure As Single

		Private propBrushHeight As Single

		Private SecondRadiusEnable As Boolean

		Private HeightEnable As Boolean

		Private DisableAll As Boolean

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

		Public Custom Event BrushParametersChanged As BrushTools.BrushParametersChangeHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.BrushParametersChanged = [Delegate].Combine(Me.BrushParametersChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.BrushParametersChanged = [Delegate].Remove(Me.BrushParametersChanged, value)
			End RemoveHandler
		End Event

		Public Sub New(<MarshalAs(UnmanagedType.U1)> secondradiusenable As Boolean)
			Me.BrushParametersChanged = Nothing
			Me.Rearranged = Nothing
			Me.InitializeComponent()
			Me.HeightEnable = False
			Me.SecondRadiusEnable = False
			Me.DisableAll = False
			Me.trkHeight.Maximum = 50
			Me.trkHeight.Minimum = -30
			Me.trkPressure.Maximum = 100
			Me.trkPressure.Minimum = 5
			Me.trkSize1.Maximum = 1500
			Me.trkSize1.Minimum = 25
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
			Me.panPressure = New Panel()
			Me.lblPressure = New Label()
			Me.tbPressure = New TextBox()
			Me.trkPressure = New TrackBar()
			Me.panSize2 = New Panel()
			Me.lblSize2 = New Label()
			Me.tbSize2 = New TextBox()
			Me.trkSize2 = New TrackBar()
			Me.panSize1 = New Panel()
			Me.lblSize1 = New Label()
			Me.tbSize1 = New TextBox()
			Me.trkSize1 = New TrackBar()
			Me.panHeight = New Panel()
			Me.lblHeight = New Label()
			Me.tbHeight = New TextBox()
			Me.trkHeight = New TrackBar()
			Me.panPressure.SuspendLayout()
			(CType(Me.trkPressure, ISupportInitialize)).BeginInit()
			Me.panSize2.SuspendLayout()
			(CType(Me.trkSize2, ISupportInitialize)).BeginInit()
			Me.panSize1.SuspendLayout()
			(CType(Me.trkSize1, ISupportInitialize)).BeginInit()
			Me.panHeight.SuspendLayout()
			(CType(Me.trkHeight, ISupportInitialize)).BeginInit()
			MyBase.SuspendLayout()
			Me.panPressure.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.panPressure.Controls.Add(Me.lblPressure)
			Me.panPressure.Controls.Add(Me.tbPressure)
			Me.panPressure.Controls.Add(Me.trkPressure)
			Dim location As Point = New Point(0, 60)
			Me.panPressure.Location = location
			Me.panPressure.Name = "panPressure"
			Dim size As Size = New Size(256, 30)
			Me.panPressure.Size = size
			Me.panPressure.TabIndex = 8
			Dim location2 As Point = New Point(0, 0)
			Me.lblPressure.Location = location2
			Me.lblPressure.Name = "lblPressure"
			Dim size2 As Size = New Size(48, 24)
			Me.lblPressure.Size = size2
			Me.lblPressure.TabIndex = 0
			Me.lblPressure.Text = "Pressure"
			Me.lblPressure.TextAlign = ContentAlignment.MiddleRight
			Dim location3 As Point = New Point(48, 0)
			Me.tbPressure.Location = location3
			Me.tbPressure.Name = "tbPressure"
			Dim size3 As Size = New Size(40, 21)
			Me.tbPressure.Size = size3
			Me.tbPressure.TabIndex = 3
			Me.tbPressure.Text = "0"
			AddHandler Me.tbPressure.Validated, AddressOf Me.tbPressure_Validated
			Me.trkPressure.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim location4 As Point = New Point(88, 0)
			Me.trkPressure.Location = location4
			Me.trkPressure.Maximum = 100
			Me.trkPressure.Minimum = 5
			Me.trkPressure.Name = "trkPressure"
			Dim size4 As Size = New Size(168, 45)
			Me.trkPressure.Size = size4
			Me.trkPressure.TabIndex = 2
			Me.trkPressure.TickFrequency = 5
			Me.trkPressure.Value = 5
			AddHandler Me.trkPressure.Scroll, AddressOf Me.trkPressure_Scroll
			Me.panSize2.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.panSize2.Controls.Add(Me.lblSize2)
			Me.panSize2.Controls.Add(Me.tbSize2)
			Me.panSize2.Controls.Add(Me.trkSize2)
			Dim location5 As Point = New Point(0, 30)
			Me.panSize2.Location = location5
			Me.panSize2.Name = "panSize2"
			Dim size5 As Size = New Size(256, 30)
			Me.panSize2.Size = size5
			Me.panSize2.TabIndex = 7
			Dim location6 As Point = New Point(0, 0)
			Me.lblSize2.Location = location6
			Me.lblSize2.Name = "lblSize2"
			Dim size6 As Size = New Size(48, 24)
			Me.lblSize2.Size = size6
			Me.lblSize2.TabIndex = 0
			Me.lblSize2.Text = "Falloff"
			Me.lblSize2.TextAlign = ContentAlignment.MiddleRight
			Dim location7 As Point = New Point(48, 0)
			Me.tbSize2.Location = location7
			Me.tbSize2.Name = "tbSize2"
			Dim size7 As Size = New Size(40, 21)
			Me.tbSize2.Size = size7
			Me.tbSize2.TabIndex = 3
			Me.tbSize2.Text = "0"
			AddHandler Me.tbSize2.Validated, AddressOf Me.tbSize2_Validated
			Me.trkSize2.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim location8 As Point = New Point(88, 0)
			Me.trkSize2.Location = location8
			Me.trkSize2.Maximum = 100
			Me.trkSize2.Name = "trkSize2"
			Dim size8 As Size = New Size(168, 45)
			Me.trkSize2.Size = size8
			Me.trkSize2.TabIndex = 2
			Me.trkSize2.TickFrequency = 5
			Me.trkSize2.Value = 25
			AddHandler Me.trkSize2.Scroll, AddressOf Me.trkSize2_Scroll
			Me.panSize1.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.panSize1.Controls.Add(Me.lblSize1)
			Me.panSize1.Controls.Add(Me.tbSize1)
			Me.panSize1.Controls.Add(Me.trkSize1)
			Dim location9 As Point = New Point(0, 0)
			Me.panSize1.Location = location9
			Me.panSize1.Name = "panSize1"
			Dim size9 As Size = New Size(256, 30)
			Me.panSize1.Size = size9
			Me.panSize1.TabIndex = 6
			Dim location10 As Point = New Point(0, 0)
			Me.lblSize1.Location = location10
			Me.lblSize1.Name = "lblSize1"
			Dim size10 As Size = New Size(48, 24)
			Me.lblSize1.Size = size10
			Me.lblSize1.TabIndex = 0
			Me.lblSize1.Text = "Radius"
			Me.lblSize1.TextAlign = ContentAlignment.MiddleRight
			Dim location11 As Point = New Point(48, 0)
			Me.tbSize1.Location = location11
			Me.tbSize1.Name = "tbSize1"
			Dim size11 As Size = New Size(40, 21)
			Me.tbSize1.Size = size11
			Me.tbSize1.TabIndex = 3
			Me.tbSize1.Text = "0"
			AddHandler Me.tbSize1.Validated, AddressOf Me.tbSize1_Validated
			Me.trkSize1.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.trkSize1.LargeChange = 25
			Dim location12 As Point = New Point(88, 0)
			Me.trkSize1.Location = location12
			Me.trkSize1.Maximum = 800
			Me.trkSize1.Minimum = 25
			Me.trkSize1.Name = "trkSize1"
			Dim size12 As Size = New Size(168, 45)
			Me.trkSize1.Size = size12
			Me.trkSize1.TabIndex = 2
			Me.trkSize1.TickFrequency = 50
			Me.trkSize1.Value = 25
			AddHandler Me.trkSize1.Scroll, AddressOf Me.trkSize1_Scroll
			Me.panHeight.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.panHeight.Controls.Add(Me.lblHeight)
			Me.panHeight.Controls.Add(Me.tbHeight)
			Me.panHeight.Controls.Add(Me.trkHeight)
			Dim location13 As Point = New Point(0, 96)
			Me.panHeight.Location = location13
			Me.panHeight.Name = "panHeight"
			Dim size13 As Size = New Size(256, 30)
			Me.panHeight.Size = size13
			Me.panHeight.TabIndex = 9
			Dim location14 As Point = New Point(0, 0)
			Me.lblHeight.Location = location14
			Me.lblHeight.Name = "lblHeight"
			Dim size14 As Size = New Size(48, 24)
			Me.lblHeight.Size = size14
			Me.lblHeight.TabIndex = 0
			Me.lblHeight.Text = "Height"
			Me.lblHeight.TextAlign = ContentAlignment.MiddleRight
			Dim location15 As Point = New Point(48, 0)
			Me.tbHeight.Location = location15
			Me.tbHeight.Name = "tbHeight"
			Dim size15 As Size = New Size(40, 21)
			Me.tbHeight.Size = size15
			Me.tbHeight.TabIndex = 3
			Me.tbHeight.Text = "0"
			AddHandler Me.tbHeight.Validated, AddressOf Me.tbHeight_Validated
			Me.trkHeight.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim location16 As Point = New Point(88, 0)
			Me.trkHeight.Location = location16
			Me.trkHeight.Maximum = 50
			Me.trkHeight.Minimum = 20
			Me.trkHeight.Name = "trkHeight"
			Dim size16 As Size = New Size(168, 45)
			Me.trkHeight.Size = size16
			Me.trkHeight.TabIndex = 2
			Me.trkHeight.TickFrequency = 5
			Me.trkHeight.Value = 20
			AddHandler Me.trkHeight.Scroll, AddressOf Me.trkHeight_Scroll
			MyBase.Controls.Add(Me.panHeight)
			MyBase.Controls.Add(Me.panPressure)
			MyBase.Controls.Add(Me.panSize2)
			MyBase.Controls.Add(Me.panSize1)
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 238)
			MyBase.Name = "BrushTools"
			Dim size17 As Size = New Size(256, 136)
			MyBase.Size = size17
			AddHandler MyBase.Resize, AddressOf Me.BrushTools_Resize
			AddHandler MyBase.Load, AddressOf Me.BrushTools_Load
			Me.panPressure.ResumeLayout(False)
			(CType(Me.trkPressure, ISupportInitialize)).EndInit()
			Me.panSize2.ResumeLayout(False)
			(CType(Me.trkSize2, ISupportInitialize)).EndInit()
			Me.panSize1.ResumeLayout(False)
			(CType(Me.trkSize1, ISupportInitialize)).EndInit()
			Me.panHeight.ResumeLayout(False)
			(CType(Me.trkHeight, ISupportInitialize)).EndInit()
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub SetBrushSize1(ByRef val As Single)
			If val Is Nothing Then
				Me.lblSize1.Enabled = False
				Me.tbSize1.Enabled = False
				Me.trkSize1.Enabled = False
				Me.DisableAll = True
			Else
				Me.lblSize1.Enabled = True
				Me.tbSize1.Enabled = True
				Me.trkSize1.Enabled = True
				Me.tbSize1.Text = val.ToString()
				Dim num As Single
				If val < 30F Then
					num = <Module>.fround(val * 50F)
				Else
					num = 1500F
				End If
				Me.trkSize1.Value = CInt((CDec(num)))
				Me.DisableAll = False
			End If
			Me.propBrushSize1 = CSng(Me.trkSize1.Value) * 0.02F
			Me.Rearrange()
		End Sub

		Public Sub SetBrushSize2(ByRef val As Single)
			If val Is Nothing Then
				Me.lblSize2.Enabled = False
				Me.tbSize2.Enabled = False
				Me.trkSize2.Enabled = False
				Me.SecondRadiusEnable = False
			Else
				Me.lblSize2.Enabled = True
				Me.tbSize2.Enabled = True
				Me.trkSize2.Enabled = True
				Me.trkSize2.Value = CInt((CDec(val)))
				Me.tbSize2.Text = (CInt(Me.trkSize2.Value)).ToString() + " %"
				Me.SecondRadiusEnable = True
			End If
			Me.propBrushSize2 = CSng(Me.trkSize2.Value)
			Me.Rearrange()
		End Sub

		Public Sub SetBrushPressure(ByRef val As Single)
			If val Is Nothing Then
				Me.lblPressure.Enabled = False
				Me.tbPressure.Enabled = False
				Me.trkPressure.Enabled = False
			Else
				Me.lblPressure.Enabled = True
				Me.tbPressure.Enabled = True
				Me.trkPressure.Enabled = True
				Me.tbPressure.Text = (CInt(<Module>.fround(val))).ToString()
				Me.trkPressure.Value = CInt((CDec(val)))
			End If
			Me.propBrushPressure = CSng(Me.trkPressure.Value)
		End Sub

		Public Sub SetBrushHeight(ByRef val As Single)
			If val Is Nothing Then
				Me.lblHeight.Enabled = False
				Me.tbHeight.Enabled = False
				Me.trkHeight.Enabled = False
				Me.HeightEnable = False
			Else
				Me.lblHeight.Enabled = True
				Me.tbHeight.Enabled = True
				Me.trkHeight.Enabled = True
				Me.tbHeight.Text = (CInt(<Module>.fround(val))).ToString()
				Me.trkHeight.Value = CInt((CDec(val)))
				Me.HeightEnable = True
			End If
			Me.propBrushHeight = CSng(Me.trkHeight.Value)
			Me.Rearrange()
		End Sub

		Public Sub trkSize1_Scroll(sender As Object, e As EventArgs)
			Dim i As Single = CSng(Me.trkSize1.Value) * 0.02F
			Me.propBrushSize1 = i
			Me.raise_BrushParametersChanged(i, Me.propBrushSize2, Me.propBrushPressure, Me.propBrushHeight)
		End Sub

		Public Sub trkSize2_Scroll(sender As Object, e As EventArgs)
			Dim i As Single = CSng(Me.trkSize2.Value)
			Me.propBrushSize2 = i
			Me.raise_BrushParametersChanged(Me.propBrushSize1, i, Me.propBrushPressure, Me.propBrushHeight)
		End Sub

		Public Sub trkPressure_Scroll(sender As Object, e As EventArgs)
			Dim i As Single = CSng(Me.trkPressure.Value)
			Me.propBrushPressure = i
			Me.raise_BrushParametersChanged(Me.propBrushSize1, Me.propBrushSize2, i, Me.propBrushHeight)
		End Sub

		Private Sub BrushTools_Load(sender As Object, e As EventArgs)
			Me.Rearrange()
		End Sub

		Private Sub Rearrange()
			If Me.DisableAll Then
				Dim size As Size = New Size(MyBase.Size.Width, 8)
				MyBase.Size = size
			Else If Me.SecondRadiusEnable Then
				Me.panSize2.Show()
				Dim location As Point = Me.panSize2.Location
				Dim location2 As Point = New Point(0, Me.panSize2.Size.Height + location.Y)
				Me.panPressure.Location = location2
				If Me.HeightEnable Then
					Me.panHeight.Show()
					Dim location3 As Point = Me.panPressure.Location
					Dim location4 As Point = New Point(0, Me.panPressure.Size.Height + location3.Y)
					Me.panHeight.Location = location4
					Dim size2 As Size = New Size(MyBase.Size.Width, 136)
					MyBase.Size = size2
				Else
					Me.panHeight.Hide()
					Dim size3 As Size = New Size(MyBase.Size.Width, 104)
					MyBase.Size = size3
				End If
			Else
				Me.panSize2.Hide()
				Dim location5 As Point = Me.panSize2.Location
				Me.panPressure.Location = location5
				If Me.HeightEnable Then
					Me.panHeight.Show()
					Dim location6 As Point = Me.panPressure.Location
					Dim location7 As Point = New Point(0, Me.panPressure.Size.Height + location6.Y)
					Me.panHeight.Location = location7
					Dim size4 As Size = New Size(MyBase.Size.Width, 106)
					MyBase.Size = size4
				Else
					Me.panHeight.Hide()
					Dim size5 As Size = New Size(MyBase.Size.Width, 74)
					MyBase.Size = size5
				End If
			End If
			Me.raise_Rearranged(Me, MyBase.Size.Height)
		End Sub

		Private Sub trkHeight_Scroll(sender As Object, e As EventArgs)
			Dim i As Single = CSng(Me.trkHeight.Value)
			Me.propBrushHeight = i
			Me.raise_BrushParametersChanged(Me.propBrushSize1, Me.propBrushSize2, Me.propBrushPressure, i)
		End Sub

		Private Sub BrushTools_Resize(sender As Object, e As EventArgs)
		End Sub

		Private Sub tbHeight_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = 0
			Try
				num2 = Integer.Parse(Me.tbHeight.Text)
				GoTo IL_71
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_71:
			If num2 > 50 Then
				num2 = 50
			Else If num2 < -30 Then
				num2 = -30
			End If
			Dim i As Single = CSng(num2)
			Me.propBrushHeight = i
			Me.raise_BrushParametersChanged(Me.propBrushSize1, Me.propBrushSize2, Me.propBrushPressure, i)
		End Sub

		Private Sub tbPressure_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = 0
			Try
				num2 = Integer.Parse(Me.tbPressure.Text)
				GoTo IL_71
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_71:
			If num2 > 100 Then
				num2 = 100
			Else If num2 < 5 Then
				num2 = 5
			End If
			Dim i As Single = CSng(num2)
			Me.propBrushPressure = i
			Me.raise_BrushParametersChanged(Me.propBrushSize1, Me.propBrushSize2, i, Me.propBrushHeight)
		End Sub

		Private Sub tbSize2_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = 0
			Try
				num2 = Integer.Parse(Me.tbSize2.Text)
				GoTo IL_71
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_71:
			If num2 > 100 Then
				num2 = 100
			Else If num2 < 0 Then
				num2 = 0
			End If
			Dim i As Single = CSng(num2)
			Me.propBrushSize2 = i
			Me.raise_BrushParametersChanged(Me.propBrushSize1, i, Me.propBrushPressure, Me.propBrushHeight)
		End Sub

		Private Sub tbSize1_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = 0
			Try
				num2 = Integer.Parse(Me.tbSize1.Text)
				GoTo IL_71
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_71:
			Dim num3 As Single = CSng(num2)
			If num3 > 30F Then
				num2 = 30
			Else If num3 < 0.5F Then
				num2 = 0
			End If
			num3 = CSng(num2)
			Me.propBrushSize1 = num3
			Me.raise_BrushParametersChanged(num3, Me.propBrushSize2, Me.propBrushPressure, Me.propBrushHeight)
		End Sub

		Protected Sub raise_BrushParametersChanged(i1 As Single, i2 As Single, i3 As Single, i4 As Single)
			Dim brushParametersChanged As BrushTools.BrushParametersChangeHandler = Me.BrushParametersChanged
			If brushParametersChanged IsNot Nothing Then
				brushParametersChanged(i1, i2, i3, i4)
			End If
		End Sub

		Protected Sub raise_Rearranged(i1 As Object, i2 As Integer)
			Dim rearranged As ToolRearranged = Me.Rearranged
			If rearranged IsNot Nothing Then
				rearranged(i1, i2)
			End If
		End Sub
	End Class
End Namespace
