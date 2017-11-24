Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class ColorPicker
		Inherits Control

		Private Enum DragType
			DRAG_SATVAL = 2
			DRAG_HUE = 1
			DRAG_NONE = 0
		End Enum

		Private Enum DisplayMode
			DISPLAY_TRACKBARS = 1
			DISPLAY_GRAPHS = 0
		End Enum

		Public Delegate Sub __Delegate_ValueChanged()

		Public BackgroundBrush As Brush

		Public MarkerBrush As Brush

		Private components As Container

		Private panColor As Panel

		Private lblHue As Label

		Private tbHue As TextBox

		Private lblSat As Label

		Private tbSat As TextBox

		Private lblVal As Label

		Private tbVal As TextBox

		Private lblText As Label

		Private panHue As Panel

		Private panSat As Panel

		Private panVal As Panel

		Private panHueColor As NSolidPanel

		Private panSatColor As NSolidPanel

		Private panValColor As NSolidPanel

		Private trkHue As TrackBar

		Private trkSat As TrackBar

		Private trkVal As TrackBar

		Private ModeSelector As Toolbar

		Private ColorPickerBitmap As Bitmap

		Private TrackbarBitmap As Bitmap

		Private propHue As Integer

		Private propSat As Integer

		Private propVal As Integer

		Private DragType As ColorPicker.DragType

		Private DisplayMode As ColorPicker.DisplayMode

		Public Custom Event ValueChanged As ColorPicker.__Delegate_ValueChanged
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
				Dim label As Label = Me.lblText
				If label IsNot Nothing Then
					label.Text = value
				End If
			End Set
		End Property

		Public Property Val() As Integer
			Get
				Return Me.propVal
			End Get
			Set(value As Integer)
				Me.propVal = value
				Dim num As Integer = value
				Me.tbVal.Text = num.ToString()
				Me.trkVal.Value = value
				Me.ColorPickerBitmap = Nothing
				Me.UpdatePanelColor()
				MyBase.Invalidate()
			End Set
		End Property

		Public Property Sat() As Integer
			Get
				Return Me.propSat
			End Get
			Set(value As Integer)
				Me.propSat = value
				Dim num As Integer = value
				Me.tbSat.Text = num.ToString()
				Me.trkSat.Value = value
				Me.ColorPickerBitmap = Nothing
				Me.UpdatePanelColor()
				MyBase.Invalidate()
			End Set
		End Property

		Public Property Hue() As Integer
			Get
				Return Me.propHue
			End Get
			Set(value As Integer)
				Me.propHue = value
				Dim num As Integer = value
				Me.tbHue.Text = num.ToString()
				Me.trkHue.Value = value
				Me.ColorPickerBitmap = Nothing
				Me.UpdatePanelColor()
				MyBase.Invalidate()
			End Set
		End Property

		Public Sub New()
			Me.ValueChanged = Nothing
			Me.propHue = 0
			Me.propSat = 100
			Me.propVal = 100
			Me.DragType = ColorPicker.DragType.DRAG_NONE
			Me.InitializeComponent()
			Me.InitializeComponent2()
			Dim color As Color = Color.FromKnownColor(KnownColor.Control)
			Me.BackgroundBrush = New SolidBrush(color)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.Black)
			Me.MarkerBrush = New SolidBrush(color2)
			Me.TrackbarBitmap = New Bitmap(142, 15)
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
			Dim size As Size = New Size(256, 120)
			MyBase.Size = size
			Me.Text = "ColorPicker"
		End Sub

		Private Sub InitializeComponent2()
			Me.lblText = New Label()
			Dim location As Point = New Point(0, 0)
			Me.lblText.Location = location
			Me.lblText.Name = "lblText"
			Dim size As Size = New Size(80, 15)
			Me.lblText.Size = size
			Me.lblText.TabIndex = 0
			Me.lblText.Font = Me.Font
			Me.lblText.Text = Me.Text
			Me.lblText.TextAlign = ContentAlignment.TopCenter
			MyBase.Controls.Add(Me.lblText)
			Me.panColor = New Panel()
			Dim location2 As Point = New Point(0, 15)
			Me.panColor.Location = location2
			Dim size2 As Size = New Size(80, 21)
			Me.panColor.Size = size2
			Me.panColor.BorderStyle = BorderStyle.Fixed3D
			MyBase.Controls.Add(Me.panColor)
			Me.UpdatePanelColor()
			Me.lblHue = New Label()
			Dim location3 As Point = New Point(0, 43)
			Me.lblHue.Location = location3
			Me.lblHue.Name = "lblHue"
			Dim size3 As Size = New Size(48, 21)
			Me.lblHue.Size = size3
			Me.lblHue.TabIndex = 0
			Me.lblHue.Font = Me.Font
			Me.lblHue.Text = "Hue"
			Me.lblHue.TextAlign = ContentAlignment.MiddleRight
			MyBase.Controls.Add(Me.lblHue)
			Me.tbHue = New TextBox()
			Dim location4 As Point = New Point(48, 43)
			Me.tbHue.Location = location4
			Me.tbHue.Name = "tbHue"
			Dim size4 As Size = New Size(32, 21)
			Me.tbHue.Size = size4
			Me.tbHue.TabIndex = 1
			Dim hue As Integer = Me.Hue
			Me.tbHue.Text = hue.ToString()
			AddHandler Me.tbHue.Validated, AddressOf Me.tbHue_Validated
			MyBase.Controls.Add(Me.tbHue)
			Me.lblSat = New Label()
			Dim location5 As Point = New Point(0, 71)
			Me.lblSat.Location = location5
			Me.lblSat.Name = "lblSat"
			Dim size5 As Size = New Size(48, 21)
			Me.lblSat.Size = size5
			Me.lblSat.TabIndex = 2
			Me.lblSat.Font = Me.Font
			Me.lblSat.Text = "Sat"
			Me.lblSat.TextAlign = ContentAlignment.MiddleRight
			MyBase.Controls.Add(Me.lblSat)
			Me.tbSat = New TextBox()
			Dim location6 As Point = New Point(48, 71)
			Me.tbSat.Location = location6
			Me.tbSat.Name = "tbSat"
			Dim size6 As Size = New Size(32, 21)
			Me.tbSat.Size = size6
			Me.tbSat.TabIndex = 3
			Dim sat As Integer = Me.Sat
			Me.tbSat.Text = sat.ToString()
			AddHandler Me.tbSat.Validated, AddressOf Me.tbSat_Validated
			MyBase.Controls.Add(Me.tbSat)
			Me.lblVal = New Label()
			Dim location7 As Point = New Point(0, 99)
			Me.lblVal.Location = location7
			Me.lblVal.Name = "lblVal"
			Dim size7 As Size = New Size(48, 21)
			Me.lblVal.Size = size7
			Me.lblVal.TabIndex = 4
			Me.lblVal.Font = Me.Font
			Me.lblVal.Text = "Val"
			Me.lblVal.TextAlign = ContentAlignment.MiddleRight
			MyBase.Controls.Add(Me.lblVal)
			Me.tbVal = New TextBox()
			Dim location8 As Point = New Point(48, 99)
			Me.tbVal.Location = location8
			Me.tbVal.Name = "tbVal"
			Dim size8 As Size = New Size(32, 21)
			Me.tbVal.Size = size8
			Me.tbVal.TabIndex = 5
			Dim val As Integer = Me.Val
			Me.tbVal.Text = val.ToString()
			AddHandler Me.tbVal.Validated, AddressOf Me.tbVal_Validated
			MyBase.Controls.Add(Me.tbVal)
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?A0x2cec50cb.?items@?1??InitializeComponent2@ColorPicker@NControls@@A$AAMXXZ@4PAUGToolbarItem@3@A), __Pointer(Of GToolbarItem)), 16)
			Me.ModeSelector = toolbar
			toolbar.Dock = DockStyle.None
			AddHandler Me.ModeSelector.ButtonClick, AddressOf Me.tb_ModeSelector_Pushed
			Dim size9 As Size = New Size(22, 20)
			Me.ModeSelector.Size = size9
			Dim location9 As Point = New Point(MyBase.Size.Width - 36, 0)
			Me.ModeSelector.Location = location9
			MyBase.Controls.Add(Me.ModeSelector)
			Me.panHue = New Panel()
			Dim location10 As Point = New Point(80, 36)
			Me.panHue.Location = location10
			Dim size10 As Size = New Size(168, 28)
			Me.panHue.Size = size10
			Me.panHue.TabIndex = 0
			Me.panSat = New Panel()
			Dim location11 As Point = New Point(80, 64)
			Me.panSat.Location = location11
			Dim size11 As Size = New Size(168, 28)
			Me.panSat.Size = size11
			Me.panSat.TabIndex = 0
			Me.panVal = New Panel()
			Dim location12 As Point = New Point(80, 92)
			Me.panVal.Location = location12
			Dim size12 As Size = New Size(168, 28)
			Me.panVal.Size = size12
			Me.panVal.TabIndex = 0
			Me.panHueColor = New NSolidPanel()
			Dim location13 As Point = New Point(13, 1)
			Me.panHueColor.Location = location13
			Dim size13 As Size = New Size(142, 5)
			Me.panHueColor.Size = size13
			Me.panHueColor.TabIndex = 0
			AddHandler Me.panHueColor.Paint, AddressOf Me.trkHue_Paint
			Me.panSatColor = New NSolidPanel()
			Dim location14 As Point = New Point(13, 1)
			Me.panSatColor.Location = location14
			Dim size14 As Size = New Size(142, 5)
			Me.panSatColor.Size = size14
			Me.panSatColor.TabIndex = 0
			AddHandler Me.panSatColor.Paint, AddressOf Me.trkSat_Paint
			Me.panValColor = New NSolidPanel()
			Dim location15 As Point = New Point(13, 1)
			Me.panValColor.Location = location15
			Dim size15 As Size = New Size(142, 5)
			Me.panValColor.Size = size15
			Me.panValColor.TabIndex = 0
			AddHandler Me.panValColor.Paint, AddressOf Me.trkVal_Paint
			Me.trkHue = New TrackBar()
			Dim location16 As Point = New Point(0, -3)
			Me.trkHue.Location = location16
			Me.trkHue.Maximum = 359
			Me.trkHue.Minimum = 0
			Me.trkHue.Name = "trkHue"
			Dim size16 As Size = New Size(168, 45)
			Me.trkHue.Size = size16
			Me.trkHue.TabIndex = 6
			Me.trkHue.TickStyle = TickStyle.TopLeft
			Me.trkHue.TickFrequency = 360
			Me.trkHue.Value = Me.Hue
			AddHandler Me.trkHue.Scroll, AddressOf Me.trkHue_Scroll
			Me.trkSat = New TrackBar()
			Dim location17 As Point = New Point(0, -3)
			Me.trkSat.Location = location17
			Me.trkSat.Maximum = 100
			Me.trkSat.Minimum = 0
			Me.trkSat.Name = "trkHue"
			Dim size17 As Size = New Size(168, 45)
			Me.trkSat.Size = size17
			Me.trkSat.TabIndex = 6
			Me.trkSat.TickStyle = TickStyle.TopLeft
			Me.trkSat.TickFrequency = 100
			Me.trkSat.Value = Me.Sat
			AddHandler Me.trkSat.Scroll, AddressOf Me.trkSat_Scroll
			Me.trkVal = New TrackBar()
			Dim location18 As Point = New Point(0, -3)
			Me.trkVal.Location = location18
			Me.trkVal.Maximum = 100
			Me.trkVal.Minimum = 0
			Me.trkVal.Name = "trkHue"
			Dim size18 As Size = New Size(168, 45)
			Me.trkVal.Size = size18
			Me.trkVal.TabIndex = 6
			Me.trkVal.TickStyle = TickStyle.TopLeft
			Me.trkVal.TickFrequency = 100
			Me.trkVal.Value = Me.Val
			AddHandler Me.trkVal.Scroll, AddressOf Me.trkVal_Scroll
			Me.panHue.Controls.Add(Me.panHueColor)
			Me.panSat.Controls.Add(Me.panSatColor)
			Me.panVal.Controls.Add(Me.panValColor)
			Me.panHue.Controls.Add(Me.trkHue)
			Me.panSat.Controls.Add(Me.trkSat)
			Me.panVal.Controls.Add(Me.trkVal)
			MyBase.Controls.Add(Me.panHue)
			MyBase.Controls.Add(Me.panSat)
			MyBase.Controls.Add(Me.panVal)
		End Sub

		Private Function CalculateColorPickerBitmap(hue As Single) As Bitmap
			Dim bitmap As Bitmap = New Bitmap(120, 120)
			Dim color As Color = Color.FromKnownColor(KnownColor.Control)
			Dim num As Single = hue * -0.0174532924F
			Dim num2 As Double = CDec(num)
			Dim num3 As Single = CSng(Math.Cos(num2))
			Dim gLine As GLine = CSng(Math.Sin(num2))
			Dim num4 As Double = CDec((num + 2.09439516F))
			Dim num5 As Single = CSng(Math.Cos(num4))
			Dim num6 As Single = num5
			Dim num7 As Single = CSng(Math.Sin(num4))
			Dim gLine2 As GLine = num7
			Dim num8 As Double = CDec((num - 2.09439516F))
			Dim num9 As Single = CSng(Math.Cos(num8))
			Dim gLine3 As GLine = CSng(Math.Sin(num8))
			Dim num10 As Integer = 0
			Do
				Dim num11 As Single = CSng((num10 - 60))
				Dim num12 As Single = num11 + 0.5F
				Dim num13 As Integer = -60
				Do
					Dim num14 As Single = num12
					Dim num15 As Single = CSng(num13)
					Dim num16 As Single = num15 + 0.5F
					Dim num17 As Single = num16
					Dim expr_AC As Single = num17
					Dim arg_B2_0 As Single = expr_AC * expr_AC
					Dim expr_B0 As Single = num14
					Dim num18 As Single = arg_B2_0 + expr_B0 * expr_B0
					If num18 > 3685.353F Then
						bitmap.SetPixel(num13 + 60, num10, color)
					Else If num18 < 2236.61768F Then
						Dim num19 As Integer = 0
						Dim num20 As Integer = 0
						Dim num21 As Single = num15 + 0.125F
						Dim num22 As Single = num15 + 0.375F
						Dim num23 As Single = num15 + 0.625F
						Dim num24 As Single = num15 + 0.875F
						Do
							Dim gPoint As GPoint2 = num21
							Dim num25 As Single = (CSng(num20) + 0.5F) * 0.25F + num11
							__Dereference((gPoint + 4)) = num25
							If __Dereference((gPoint + 4)) * num3 + gPoint * gLine - 22.5F < 0F AndAlso gPoint * gLine2 + __Dereference((gPoint + 4)) * num6 - 22.5F < 0F AndAlso gPoint * gLine3 + __Dereference((gPoint + 4)) * num9 - 22.5F < 0F Then
								num19 += 1
							End If
							gPoint = num22
							__Dereference((gPoint + 4)) = num25
							If __Dereference((gPoint + 4)) * num3 + gPoint * gLine - 22.5F < 0F AndAlso gPoint * gLine2 + __Dereference((gPoint + 4)) * num6 - 22.5F < 0F AndAlso gPoint * gLine3 + __Dereference((gPoint + 4)) * num9 - 22.5F < 0F Then
								num19 += 1
							End If
							gPoint = num23
							__Dereference((gPoint + 4)) = num25
							If __Dereference((gPoint + 4)) * num3 + gPoint * gLine - 22.5F < 0F AndAlso gPoint * gLine2 + __Dereference((gPoint + 4)) * num6 - 22.5F < 0F AndAlso gPoint * gLine3 + __Dereference((gPoint + 4)) * num9 - 22.5F < 0F Then
								num19 += 1
							End If
							gPoint = num24
							__Dereference((gPoint + 4)) = num25
							If __Dereference((gPoint + 4)) * num3 + gPoint * gLine - 22.5F < 0F AndAlso gPoint * gLine2 + __Dereference((gPoint + 4)) * num6 - 22.5F < 0F AndAlso gPoint * gLine3 + __Dereference((gPoint + 4)) * num9 - 22.5F < 0F Then
								num19 += 1
							End If
							num20 += 1
						Loop While num20 < 4
						If num19 <> 0 Then
							Dim gPoint2 As GPoint2 = num16
							__Dereference((gPoint2 + 4)) = num12
							Dim num26 As Single = num5
							Dim num27 As Single = num7
							Dim num28 As Single = (num27 * gPoint2 + num26 * __Dereference((gPoint2 + 4)) + 45F) * 0.0148148146F
							Dim num29 As Single
							If num28 <= 0F Then
								num29 = 0F
								GoTo IL_32A
							End If
							num29 = num28
							If num28 < 1F Then
								GoTo IL_32A
							End If
							Dim num30 As Single = 1F
							IL_337:
							Dim num31 As Double = CDec((num + 3.66519165F))
							Dim num32 As Single = CSng(Math.Cos(num31))
							Dim num33 As Single = CSng(Math.Sin(num31))
							Dim num34 As Single = num33 * gPoint2 + num32 * __Dereference((gPoint2 + 4))
							If num30 <= 0.001F Then
								GoTo IL_3A2
							End If
							num34 = num34 / num30 * 0.0222222228F / CSng(Math.Sqrt(3.0)) + 0.5F
							If num34 <= 0F Then
								GoTo IL_3A2
							End If
							Dim num35 As Single = num34
							If num34 < 1F Then
								GoTo IL_3B4
							End If
							Dim num36 As Single = 1F
							IL_3C1:
							Dim gColor As GColor
							__Dereference((gColor + 8)) = 0F
							__Dereference((gColor + 4)) = 0F
							gColor = 0F
							__Dereference((gColor + 12)) = 1F
							<Module>.GColor.FromHSV(gColor, CInt((CDec(hue))), CInt((CDec((num36 * 100F)))), CInt((CDec((num30 * 100F)))))
							If num19 = 16 Then
								Dim color2 As Color = Color.FromArgb(255, CInt((gColor * 255F)), CInt((CDec((__Dereference((gColor + 4)) * 255F)))), CInt((CDec((__Dereference((gColor + 8)) * 255F)))))
								bitmap.SetPixel(num13 + 60, num10, color2)
								GoTo IL_8D1
							End If
							Dim num37 As Single = CSng(num19) * 0.0625F
							Dim num38 As Single = 1F - num37
							Dim color3 As Color = Color.FromArgb(255, CInt((CSng(color.R) * num38 + num37 * gColor * 255F)), CInt((CDec((CSng(color.G) * num38 + num37 * __Dereference((gColor + 4)) * 255F)))), CInt((CDec((CSng(color.B) * num38 + num37 * __Dereference((gColor + 8)) * 255F)))))
							bitmap.SetPixel(num13 + 60, num10, color3)
							GoTo IL_8D1
							IL_3B4:
							num36 = num35
							GoTo IL_3C1
							IL_3A2:
							num35 = 0F
							GoTo IL_3B4
							IL_32A:
							num30 = num29
							GoTo IL_337
						End If
						bitmap.SetPixel(num13 + 60, num10, color)
					Else
						Dim num39 As Integer = 0
						Dim num40 As Integer = 0
						Dim num21 As Single = num15 + 0.125F
						Dim num22 As Single = num15 + 0.375F
						Dim num23 As Single = num15 + 0.625F
						Dim num24 As Single = num15 + 0.875F
						Do
							Dim num41 As Single = (CSng(num40) + 0.5F) * 0.25F + num11
							Dim num42 As Single = num41
							Dim num43 As Single = num21
							Dim expr_534 As Single = num43
							Dim arg_53A_0 As Single = expr_534 * expr_534
							Dim expr_538 As Single = num42
							Dim num44 As Single = arg_53A_0 + expr_538 * expr_538
							If num44 < 3600F AndAlso num44 > 2304F Then
								num39 += 1
							End If
							num42 = num41
							num43 = num22
							Dim expr_55A As Single = num43
							Dim arg_560_0 As Single = expr_55A * expr_55A
							Dim expr_55E As Single = num42
							num44 = arg_560_0 + expr_55E * expr_55E
							If num44 < 3600F AndAlso num44 > 2304F Then
								num39 += 1
							End If
							num42 = num41
							num43 = num23
							Dim expr_580 As Single = num43
							Dim arg_586_0 As Single = expr_580 * expr_580
							Dim expr_584 As Single = num42
							num44 = arg_586_0 + expr_584 * expr_584
							If num44 < 3600F AndAlso num44 > 2304F Then
								num39 += 1
							End If
							num42 = num41
							num43 = num24
							Dim expr_5A6 As Single = num43
							Dim arg_5AC_0 As Single = expr_5A6 * expr_5A6
							Dim expr_5AA As Single = num42
							num44 = arg_5AC_0 + expr_5AA * expr_5AA
							If num44 < 3600F AndAlso num44 > 2304F Then
								num39 += 1
							End If
							num40 += 1
						Loop While num40 < 4
						If num39 <> 0 Then
							Dim num45 As Single = CSng((Math.Atan2(CDec((num10 - 60)) + 0.5, CDec(num13) + 0.5) * 57.295780181884766 + 90.0))
							If num45 < 0F Then
								num45 += 360F
							End If
							Dim gColor2 As GColor
							__Dereference((gColor2 + 8)) = 0F
							__Dereference((gColor2 + 4)) = 0F
							gColor2 = 0F
							__Dereference((gColor2 + 12)) = 1F
							<Module>.GColor.FromHSV(gColor2, CInt((CDec(num45))), 100, 100)
							Dim num46 As Single = num16
							Dim num47 As Single = num12
							Dim expr_660 As Single = num47
							Dim arg_666_0 As Double = CDec((expr_660 * expr_660))
							Dim expr_664 As Single = num46
							Dim num48 As Single = CSng(Math.Sqrt(arg_666_0 + CDec((expr_664 * expr_664))))
							Dim num49 As Single = 1F / num48
							num46 *= num49
							num47 *= num49
							If num48 > 58F Then
								Dim num50 As Single = num48 - 58F
								num46 = num46 * num50 * 0.5F
								num47 = num47 * num50 * 0.5F
							Else If num48 < 50F Then
								Dim num51 As Single = num48 - 50F
								num46 = num46 * num51 * 0.5F
								num47 = num47 * num51 * 0.5F
							Else
								num46 = 0F
								num47 = 0F
							End If
							Dim gVector As GVector3 = num46
							__Dereference((gVector + 4)) = num47
							__Dereference((gVector + 8)) = 1F
							<Module>.GVector3.Normalize(gVector)
							Dim gVector2 As GVector3 = -0.707106769F
							__Dereference((gVector2 + 4)) = -0.707106769F
							__Dereference((gVector2 + 8)) = 1F
							<Module>.GVector3.Normalize(gVector2)
							Dim num52 As Single = __Dereference((gVector2 + 8)) * __Dereference((gVector + 8))
							Dim num53 As Single = gVector2 * gVector
							Dim num54 As Single = __Dereference((gVector2 + 4)) * __Dereference((gVector + 4))
							Dim num55 As Single = 1F - num52 + num54 + num53 + num52
							Dim num56 As Single = num54 + num53 + num52
							Dim num57 As Single
							If num56 > 0F Then
								num57 = num56
							Else
								num57 = 0F
							End If
							Dim num58 As Single = num57
							Dim num59 As UInteger = 16UI
							Dim num60 As Single = 1F
							While True
								If(num59 And 1UI) <> 0UI Then
									num60 *= num58
								End If
								num59 >>= 1
								If num59 = 0UI Then
									Exit While
								End If
								Dim expr_7B4 As Single = num58
								num58 = expr_7B4 * expr_7B4
							End While
							Dim num61 As Single = num60 * 2F
							gColor2 = gColor2 * num55 + num61
							__Dereference((gColor2 + 4)) = __Dereference((gColor2 + 4)) * num55 + num61
							__Dereference((gColor2 + 8)) = __Dereference((gColor2 + 8)) * num55 + num61
							<Module>.GColor.Saturate(gColor2)
							If num39 = 16 Then
								Dim color4 As Color = Color.FromArgb(255, CInt((gColor2 * 255F)), CInt((CDec((__Dereference((gColor2 + 4)) * 255F)))), CInt((CDec((__Dereference((gColor2 + 8)) * 255F)))))
								bitmap.SetPixel(num13 + 60, num10, color4)
							Else
								Dim num62 As Single = CSng(num39) * 0.0625F
								Dim num63 As Single = 1F - num62
								Dim color5 As Color = Color.FromArgb(255, CInt((CSng(color.R) * num63 + num62 * gColor2 * 255F)), CInt((CDec((CSng(color.G) * num63 + num62 * __Dereference((gColor2 + 4)) * 255F)))), CInt((CDec((CSng(color.B) * num63 + num62 * __Dereference((gColor2 + 8)) * 255F)))))
								bitmap.SetPixel(num13 + 60, num10, color5)
							End If
						Else
							bitmap.SetPixel(num13 + 60, num10, color)
						End If
					End If
					IL_8D1:
					num13 += 1
				Loop While num13 + 60 < 120
				num10 += 1
			Loop While num10 < 120
			Return bitmap
		End Function

		Private Sub UpdateHue(e As MouseEventArgs)
			Dim num As Single = CSng((e.X - 160)) + 0.5F
			Dim num2 As Single = CSng((e.Y - 60)) + 0.5F
			Dim num3 As Single = CSng(Math.Atan2(CDec(num2), CDec(num)))
			Dim num4 As Single = <Module>.fround(num3 * 57.29578F) + 90
			If num4 < 0F Then
				num4 += 360F
			End If
			Me.Hue = CInt((CDec(num4)))
			Me.raise_ValueChanged()
		End Sub

		Private Sub UpdateSatVal(e As MouseEventArgs)
			Dim num As Single = CSng((e.X - 160)) + 0.5F
			Dim num2 As Single = CSng((e.Y - 60)) + 0.5F
			Dim num3 As Single = CSng((-CSng(Me.Hue))) * 0.0174532924F
			Dim num4 As Single = num3 + 2.09439516F
			Dim num5 As Single = CSng(Math.Cos(CDec(num4)))
			Dim num6 As Single = CSng(Math.Sin(CDec(num4)))
			Dim num7 As Single = (num6 * num + num5 * num2 + 45F) * 0.0148148146F
			Dim num8 As Single
			Dim num9 As Single
			If num7 > 0F Then
				num8 = num7
				If num7 >= 1F Then
					num9 = 1F
					GoTo IL_98
				End If
			Else
				num8 = 0F
			End If
			num9 = num8
			IL_98:
			Dim num10 As Single = num3 + 3.66519165F
			Dim num11 As Single = CSng(Math.Cos(CDec(num10)))
			Dim num12 As Single = CSng(Math.Sin(CDec(num10)))
			Dim num13 As Single = num12 * num + num11 * num2
			Dim num14 As Single
			Dim num15 As Single
			If num9 > 0.001F Then
				num13 = num13 / num9 * 0.0222222228F / CSng(Math.Sqrt(3.0)) + 0.5F
				If num13 > 0F Then
					num14 = num13
					If num13 < 1F Then
						GoTo IL_10A
					End If
					num15 = 1F
					GoTo IL_115
				End If
			End If
			num14 = 0F
			IL_10A:
			num15 = num14
			IL_115:
			Me.Sat = CInt((CDec((num15 * 100F))))
			Me.Val = CInt((CDec((num9 * 100F))))
			Me.raise_ValueChanged()
		End Sub

		Private Sub UpdatePanelColor()
			Dim gColor As GColor
			__Dereference((gColor + 8)) = 0F
			__Dereference((gColor + 4)) = 0F
			gColor = 0F
			__Dereference((gColor + 12)) = 1F
			<Module>.GColor.FromHSV(gColor, Me.Hue, Me.Sat, Me.Val)
			Dim backColor As Color = Color.FromArgb(CInt((gColor * 255F)), CInt((CDec((__Dereference((gColor + 4)) * 255F)))), CInt((CDec((__Dereference((gColor + 8)) * 255F)))))
			Me.panColor.BackColor = backColor
			If Me.DisplayMode = ColorPicker.DisplayMode.DISPLAY_TRACKBARS Then
				Me.UpdateTrackbarColors()
			End If
		End Sub

		Private Sub UpdateTrackbarColors()
			Dim gColor As GColor
			__Dereference((gColor + 8)) = 0F
			__Dereference((gColor + 4)) = 0F
			gColor = 0F
			__Dereference((gColor + 12)) = 1F
			Dim num As Integer = 0
			Do
				Dim num2 As Single = CSng(num)
				<Module>.GColor.FromHSV(gColor, CInt((CDec((num2 * 2.53521132F)))), Me.Sat, Me.Val)
				Dim num3 As Integer = 0
				Dim blue As Integer = CInt((CDec((__Dereference((gColor + 8)) * 255F))))
				Dim green As Integer = CInt((CDec((__Dereference((gColor + 4)) * 255F))))
				Dim red As Integer = CInt((gColor * 255F))
				Do
					Dim color As Color = Color.FromArgb(red, green, blue)
					Me.TrackbarBitmap.SetPixel(num, num3, color)
					num3 += 1
				Loop While num3 < 5
				Dim num4 As Integer = CInt((CDec((num2 * 0.704225361F))))
				<Module>.GColor.FromHSV(gColor, Me.Hue, num4, Me.Val)
				Dim num5 As Integer = 5
				Dim blue2 As Integer = CInt((CDec((__Dereference((gColor + 8)) * 255F))))
				Dim green2 As Integer = CInt((CDec((__Dereference((gColor + 4)) * 255F))))
				Dim red2 As Integer = CInt((gColor * 255F))
				Do
					Dim color2 As Color = Color.FromArgb(red2, green2, blue2)
					Me.TrackbarBitmap.SetPixel(num, num5, color2)
					num5 += 1
				Loop While num5 < 10
				<Module>.GColor.FromHSV(gColor, Me.Hue, Me.Sat, num4)
				Dim num6 As Integer = 10
				Dim blue3 As Integer = CInt((CDec((__Dereference((gColor + 8)) * 255F))))
				Dim green3 As Integer = CInt((CDec((__Dereference((gColor + 4)) * 255F))))
				Dim red3 As Integer = CInt((gColor * 255F))
				Do
					Dim color3 As Color = Color.FromArgb(red3, green3, blue3)
					Me.TrackbarBitmap.SetPixel(num, num6, color3)
					num6 += 1
				Loop While num6 < 15
				num += 1
			Loop While num < 142
			Me.panHueColor.Invalidate()
			Me.panSatColor.Invalidate()
			Me.panValColor.Invalidate()
		End Sub

		Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
			Dim displayMode As ColorPicker.DisplayMode = Me.DisplayMode
			If displayMode <> ColorPicker.DisplayMode.DISPLAY_GRAPHS Then
				If displayMode = ColorPicker.DisplayMode.DISPLAY_TRACKBARS Then
					Me.panHue.Show()
					Me.panSat.Show()
					Me.panVal.Show()
					Dim size As Size = MyBase.Size
					Dim size2 As Size = MyBase.Size
					e.Graphics.FillRectangle(Me.BackgroundBrush, 0, 0, size2.Width, size.Height)
				End If
			Else
				Me.panHue.Hide()
				Me.panSat.Hide()
				Me.panVal.Hide()
				Dim size3 As Size = MyBase.Size
				e.Graphics.FillRectangle(Me.BackgroundBrush, 0, 0, 100, size3.Height)
				Dim size4 As Size = MyBase.Size
				Dim size5 As Size = MyBase.Size
				e.Graphics.FillRectangle(Me.BackgroundBrush, size5.Width - 36, 0, 36, size4.Height)
			End If
		End Sub

		Protected Overrides Sub OnPaint(e As PaintEventArgs)
			If Me.DisplayMode = ColorPicker.DisplayMode.DISPLAY_GRAPHS Then
				If Me.ColorPickerBitmap Is Nothing Then
					Me.ColorPickerBitmap = Me.CalculateColorPickerBitmap(CSng(Me.Hue))
				End If
				e.Graphics.DrawImage(Me.ColorPickerBitmap, 100, 0, Me.ColorPickerBitmap.Width, Me.ColorPickerBitmap.Height)
				Dim num As Single = CSng(Me.Hue) * 0.0174532924F
				Dim num2 As Single = CSng(Math.Sin(CDec(num))) * 54F + 159.5F
				Dim num3 As Single = 59.5F - CSng(Math.Cos(CDec(num))) * 54F
				e.Graphics.FillEllipse(Me.MarkerBrush, num2 - 4F, num3 - 4F, 8F, 8F)
				num = 2.09439516F - num
				Dim num4 As Single = CSng((CDec(Me.Val) * 0.01 * 67.5 - 45.0))
				Dim num5 As Single = CSng(Math.Sqrt(3.0))
				Dim num6 As Single = CSng(((CDec(Me.Sat) * 0.01 - 0.5) * (CDec(Me.Val) * 0.01) * CDec((num5 * 45F))))
				Dim num7 As Single = CSng(Math.Cos(CDec(num)))
				Dim num8 As Single = num7
				Dim num9 As Single = CSng(Math.Sin(CDec(num)))
				Dim num10 As Single = num9 * num4 + num8 * num6 + 159.5F
				Dim num11 As Single = num9
				Dim num12 As Single = 59.5F - num11 * num6 + num7 * num4
				e.Graphics.FillEllipse(Me.MarkerBrush, num10 - 4F, num12 - 4F, 8F, 8F)
			End If
		End Sub

		Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
			If(e.Button And MouseButtons.Left) <> MouseButtons.None AndAlso Me.DisplayMode = ColorPicker.DisplayMode.DISPLAY_GRAPHS Then
				Dim num As Single = CSng((e.X - 160)) + 0.5F
				Dim num2 As Single = CSng((e.Y - 60)) + 0.5F
				Dim expr_42 As Single = num2
				Dim arg_47_0 As Double = CDec((expr_42 * expr_42))
				Dim expr_45 As Single = num
				Dim num3 As Single = CSng(Math.Sqrt(arg_47_0 + CDec((expr_45 * expr_45))))
				If num3 <= 60F AndAlso num3 >= 48F Then
					Me.DragType = ColorPicker.DragType.DRAG_HUE
					Me.UpdateHue(e)
				Else
					Dim num4 As Single = CSng((-CSng(Me.Hue))) * 0.0174532924F
					Dim num5 As Single = CSng(Math.Cos(CDec(num4)))
					Dim gLine As GLine = CSng(Math.Sin(CDec(num4)))
					Dim num6 As Single = num4 + 2.09439516F
					Dim num7 As Single = CSng(Math.Cos(CDec(num6)))
					Dim gLine2 As GLine = CSng(Math.Sin(CDec(num6)))
					Dim num8 As Single = num4 - 2.09439516F
					Dim num9 As Single = CSng(Math.Cos(CDec(num8)))
					Dim gLine3 As GLine = CSng(Math.Sin(CDec(num8)))
					If gLine * num + num5 * num2 - 22.5F < 0F AndAlso gLine2 * num + num7 * num2 - 22.5F < 0F AndAlso gLine3 * num + num9 * num2 - 22.5F < 0F Then
						Me.DragType = ColorPicker.DragType.DRAG_SATVAL
						Me.UpdateSatVal(e)
					End If
				End If
			End If
		End Sub

		Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
			Dim dragType As ColorPicker.DragType = Me.DragType
			If dragType = ColorPicker.DragType.DRAG_HUE Then
				Me.UpdateHue(e)
			Else If dragType = ColorPicker.DragType.DRAG_SATVAL Then
				Me.UpdateSatVal(e)
			End If
		End Sub

		Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
			Me.DragType = ColorPicker.DragType.DRAG_NONE
		End Sub

		Private Sub tbHue_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = 0
			Try
				num2 = Integer.Parse(Me.tbHue.Text)
				GoTo IL_6E
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_6E:
			If num2 > 360 Then
				num2 = 360
			Else If num2 < 0 Then
				num2 = 0
			End If
			If Me.Hue <> num2 Then
				Me.Hue = num2
			End If
			Me.raise_ValueChanged()
		End Sub

		Private Sub tbSat_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = 0
			Try
				num2 = Integer.Parse(Me.tbSat.Text)
				GoTo IL_6E
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_6E:
			If num2 > 100 Then
				num2 = 100
			Else If num2 < 0 Then
				num2 = 0
			End If
			If Me.Sat <> num2 Then
				Me.Sat = num2
			End If
			Me.raise_ValueChanged()
		End Sub

		Private Sub tbVal_Validated(sender As Object, e As EventArgs)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim num2 As Integer = 0
			Try
				num2 = Integer.Parse(Me.tbVal.Text)
				GoTo IL_6E
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_6E:
			If num2 > 100 Then
				num2 = 100
			Else If num2 < 0 Then
				num2 = 0
			End If
			If Me.Val <> num2 Then
				Me.Val = num2
			End If
			Me.raise_ValueChanged()
		End Sub

		Private Sub tb_ModeSelector_Pushed(idx As Integer, radio_group As Integer)
			If Me.DisplayMode = ColorPicker.DisplayMode.DISPLAY_GRAPHS Then
				Me.DisplayMode = ColorPicker.DisplayMode.DISPLAY_TRACKBARS
				Me.UpdateTrackbarColors()
			Else
				Me.DisplayMode = ColorPicker.DisplayMode.DISPLAY_GRAPHS
			End If
			MyBase.Invalidate()
		End Sub

		Private Sub trkHue_Scroll(sender As Object, e As EventArgs)
			Me.Hue = Me.trkHue.Value
			Me.raise_ValueChanged()
		End Sub

		Private Sub trkSat_Scroll(sender As Object, e As EventArgs)
			Me.Sat = Me.trkSat.Value
			Me.raise_ValueChanged()
		End Sub

		Private Sub trkVal_Scroll(sender As Object, e As EventArgs)
			Me.Val = Me.trkVal.Value
			Me.raise_ValueChanged()
		End Sub

		Private Sub trkHue_Paint(sender As Object, e As PaintEventArgs)
			Dim srcRect As Rectangle = New Rectangle(0, 0, 142, 5)
			e.Graphics.DrawImage(Me.TrackbarBitmap, 0, 0, srcRect, GraphicsUnit.Pixel)
		End Sub

		Private Sub trkSat_Paint(sender As Object, e As PaintEventArgs)
			Dim srcRect As Rectangle = New Rectangle(0, 5, 142, 10)
			e.Graphics.DrawImage(Me.TrackbarBitmap, 0, 0, srcRect, GraphicsUnit.Pixel)
		End Sub

		Private Sub trkVal_Paint(sender As Object, e As PaintEventArgs)
			Dim srcRect As Rectangle = New Rectangle(0, 10, 142, 15)
			e.Graphics.DrawImage(Me.TrackbarBitmap, 0, 0, srcRect, GraphicsUnit.Pixel)
		End Sub

		Protected Sub raise_ValueChanged()
			Dim valueChanged As ColorPicker.__Delegate_ValueChanged = Me.ValueChanged
			If valueChanged IsNot Nothing Then
				valueChanged()
			End If
		End Sub
	End Class
End Namespace
