Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class Minimap
		Inherits UserControl

		Private Structure UnitPoint
			Public position As PointF

			Public color As Color
		End Structure

		Public Delegate Sub MapNeedsRefreshHandler()

		Public Delegate Sub MoveCameraHandler(dx As Single, dz As Single)

		Public Delegate Sub RotateCameraHandler(alpha As Single)

		Private MapPanel As NSolidPanel

		Private components As Container

		Private MapScene As __Pointer(Of GIScene)

		Private propWorld As __Pointer(Of GEditorWorld)

		Private LevelWidth As Single

		Private LevelHeight As Single

		Private Margin As Single

		Private Camera As Point

		Private DragPoint As Point

		Private Origo As Point

		Private Map As Image

		Private Backbuffer As Bitmap

		Private TopLeft As PointF

		Private TopRight As PointF

		Private BottomLeft As PointF

		Private BottomRight As PointF

		Private UsefulSize As SizeF

		Private LeftVPs As PointF()

		Private TopVPs As PointF()

		Private RightVPs As PointF()

		Private BottomVPs As PointF()

		Private Units As Minimap.UnitPoint()

		Private ConfigTools As Toolbar

		Private AutoRefresh As Boolean

		Private CameraDrag As Boolean

		Private CameraActive As Boolean

		Private CamRotateActive As Boolean

		Public Custom Event CameraRotate As Minimap.RotateCameraHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.CameraRotate = [Delegate].Combine(Me.CameraRotate, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.CameraRotate = [Delegate].Remove(Me.CameraRotate, value)
			End RemoveHandler
		End Event

		Public Custom Event CameraMove As Minimap.MoveCameraHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.CameraMove = [Delegate].Combine(Me.CameraMove, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.CameraMove = [Delegate].Remove(Me.CameraMove, value)
			End RemoveHandler
		End Event

		Public Custom Event MapNeedsRefresh As Minimap.MapNeedsRefreshHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.MapNeedsRefresh = [Delegate].Combine(Me.MapNeedsRefresh, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.MapNeedsRefresh = [Delegate].Remove(Me.MapNeedsRefresh, value)
			End RemoveHandler
		End Event

		Public WriteOnly Property World() As __Pointer(Of GEditorWorld)
			Set(value As __Pointer(Of GEditorWorld))
				Me.propWorld = value
			End Set
		End Property

		Public Sub New()
			Me.MapNeedsRefresh = Nothing
			Me.CameraMove = Nothing
			Me.CameraRotate = Nothing
			Me.MapScene = Nothing
			Me.LeftVPs = New PointF(-1) {}
			Me.TopVPs = New PointF(-1) {}
			Me.RightVPs = New PointF(-1) {}
			Me.BottomVPs = New PointF(-1) {}
			Me.Units = New Minimap.UnitPoint(-1) {}
			Me.InitializeComponent()
			Dim nSolidPanel As NSolidPanel = New NSolidPanel()
			Me.MapPanel = nSolidPanel
			nSolidPanel.Anchor = AnchorStyles.Top
			Dim location As Point = New Point(0, 0)
			Me.MapPanel.Location = location
			Me.MapPanel.Name = "MapPanel"
			Dim size As Size = New Size(256, 256)
			Me.MapPanel.Size = size
			Me.MapPanel.TabIndex = 0
			AddHandler Me.MapPanel.MouseUp, AddressOf Me.MapPanel_MouseUp
			AddHandler Me.MapPanel.Paint, AddressOf Me.MapPanel_Paint
			AddHandler Me.MapPanel.MouseMove, AddressOf Me.MapPanel_MouseMove
			AddHandler Me.MapPanel.MouseDown, AddressOf Me.MapPanel_MouseDown
			MyBase.Controls.Add(Me.MapPanel)
			Dim size2 As Size = Me.MapPanel.Size
			Me.Backbuffer = New Bitmap(Me.MapPanel.Size.Width, size2.Height, PixelFormat.Format24bppRgb)
			Dim size3 As Size = Me.MapPanel.Size
			Me.Map = New Bitmap(Me.MapPanel.Size.Width, size3.Height, PixelFormat.Format24bppRgb)
			Dim toolbar As Toolbar = New Toolbar(CType((AddressOf <Module>.?items@?1???0Minimap@NWorkshop@@Q$AAM@XZ@4PAUGToolbarItem@NControls@@A), __Pointer(Of GToolbarItem)), 24)
			Me.ConfigTools = toolbar
			toolbar.Dock = DockStyle.Bottom
			AddHandler Me.ConfigTools.ButtonClick, AddressOf Me.ConfigTools_ButtonClick
			Dim size4 As Size = New Size(MyBase.Size.Width, 32)
			Me.ConfigTools.Size = size4
			MyBase.Controls.Add(Me.ConfigTools)
			Me.AutoRefresh = False
			Me.ConfigTools.SetGroupEnable(1, True)
			Me.CameraDrag = False
			Me.CameraActive = False
			Me.CamRotateActive = False
			Me.propWorld = Nothing
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
			MyBase.SuspendLayout()
			Dim control As Color = SystemColors.Control
			Me.BackColor = control
			MyBase.Name = "Minimap"
			Dim size As Size = New Size(256, 288)
			MyBase.Size = size
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub InternalMapRefresh()
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim gWWeather As GWWeather
			If Me.MapScene IsNot Nothing AndAlso MyBase.Size.Height > 0 AndAlso MyBase.Size.Width > 0 Then
				Dim graphics As Graphics = Graphics.FromImage(Me.Map)
				<Module>.GAWeather.{ctor}(gWWeather)
				Try
					gWWeather = <Module>.??_7GWWeather@@6B@
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GAWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				Try
					Dim num2 As Integer = -1
					While True
						Dim ptr As __Pointer(Of GWorld) = <Module>.World + 3436 / __SizeOf(GWorld)
						Dim ptr2 As __Pointer(Of GHeap<GWWeather>) = ptr
						Dim num3 As Integer = num2 + 1
						Dim num4 As Integer = __Dereference((ptr2 + 4))
						If num3 >= num4 Then
							Exit While
						End If
						Dim num5 As Integer = num3 * 124 + __Dereference(ptr2)
						While __Dereference(num5) <> 2147483647
							num3 += 1
							num5 += 124
							If num3 >= num4 Then
								GoTo IL_F8
							End If
						End While
						num2 = num3
						If num3 < 0 Then
							Exit While
						End If
						Dim num6 As Integer = num3 * 124
						If <Module>.GBaseString<char>.Compare(__Dereference(CType(ptr, __Pointer(Of Integer))) + num6 + 4 + 8, CType((AddressOf <Module>.??_C@_07MGKHBAOD@minimap?$AA@), __Pointer(Of SByte)), True) Is Nothing Then
							<Module>.GAWeather.=(gWWeather, num6 + __Dereference(CType((<Module>.World + 3436 / __SizeOf(GWorld)), __Pointer(Of Integer))) + 4)
						End If
					End While
					IL_F8:
					Dim gColor As GColor
					__Dereference((gColor + 8)) = 0F
					__Dereference((gColor + 4)) = 0F
					gColor = 0F
					__Dereference((gColor + 12)) = 1F
					<Module>.GColor.FromHSV(gColor, __Dereference((gWWeather + 16)), __Dereference((gWWeather + 20)), __Dereference((gWWeather + 24)))
					Dim mapScene As __Pointer(Of GIScene) = Me.MapScene
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), mapScene, gColor, __Dereference((__Dereference(CType(mapScene, __Pointer(Of Integer))) + 68)))
					<Module>.GColor.FromHSV(gColor, __Dereference((gWWeather + 28)), __Dereference((gWWeather + 32)), __Dereference((gWWeather + 36)))
					Dim mapScene2 As __Pointer(Of GIScene) = Me.MapScene
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single), mapScene2, gColor, CSng((__Dereference((gWWeather + 40)))) * 0.0174532924F, CSng((__Dereference((gWWeather + 44)))) * -0.0174532924F, __Dereference((__Dereference(CType(mapScene2, __Pointer(Of Integer))) + 72)))
					Dim mapScene3 As __Pointer(Of GIScene) = Me.MapScene
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), mapScene3, 0F, 0F, 0F, 1000F, 1000F, 0F, 1F, 1F, __Dereference((__Dereference(CType(mapScene3, __Pointer(Of Integer))) + 76)))
					Dim mapScene4 As __Pointer(Of GIScene) = Me.MapScene
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single), mapScene4, 0F, 0F, 0F, 0F, 0F, __Dereference((__Dereference(CType(mapScene4, __Pointer(Of Integer))) + 92)))
					Dim num7 As Integer = __Dereference(CType(Me.MapScene, __Pointer(Of Integer))) + 16
					Dim ptr3 As __Pointer(Of GImage) = calli(GImage* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,System.Single,System.Single,System.Single), Me.MapScene, CInt((CDec(Me.UsefulSize.Width))), CInt((CDec(Me.UsefulSize.Height))), 1F, 600F, 60F, __Dereference(num7))
					<Module>.GWorld.UpdateWeather(<Module>.World)
					Dim bitmap As Bitmap = Nothing
					Try
						Dim hbitmap As IntPtr = New IntPtr(<Module>.GImage.CreateHBitmap(ptr3))
						bitmap = Image.FromHbitmap(hbitmap)
						GoTo IL_2D5
					End Try
					Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
					endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
					IL_2D5:
					Dim color As Color = Color.FromArgb(0, 0, 64)
					graphics.Clear(color)
					graphics.DrawImage(bitmap, Me.Origo)
					Dim color2 As Color = Color.FromArgb(255, 24, 24)
					graphics.DrawRectangle(New Pen(color2, 1F), Me.Origo.X, Me.Origo.Y, CInt((CDec(Me.UsefulSize.Width))) - 1, CInt((CDec(Me.UsefulSize.Height))) - 1)
					If ptr3 IsNot Nothing Then
						<Module>.GImage.{dtor}(ptr3)
						<Module>.delete(CType(ptr3, __Pointer(Of Void)))
					End If
					bitmap.Dispose()
					graphics.Dispose()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GWWeather.{dtor}), CType((AddressOf gWWeather), __Pointer(Of Void)))
					Throw
				End Try
				If __Dereference((gWWeather + 8)) <> 0 Then
					<Module>.free(__Dereference((gWWeather + 8)))
				End If
			End If
			Return
			<Module>.GWWeather.{dtor}(gWWeather)
		End Sub

		Public Sub SetScene(scene As __Pointer(Of GIScene), levelwidth As Integer, levelhight As Integer)
			Dim num As Single = CSng(levelwidth)
			Me.LevelWidth = num
			Dim num2 As Single = CSng(levelhight)
			Me.LevelHeight = num2
			Me.MapScene = scene
			Dim num3 As Single
			If num > num2 Then
				num3 = CSng(Me.MapPanel.Size.Width) / Me.LevelWidth
			Else
				num3 = CSng(Me.MapPanel.Size.Height) / Me.LevelHeight
			End If
			Me.Origo.X = CInt((CDec(((CSng(Me.MapPanel.Size.Width) - Me.LevelWidth * num3) * 0.5F))))
			Me.UsefulSize.Width = Me.LevelWidth * num3
			Me.Origo.Y = CInt((CDec(((CSng(Me.MapPanel.Size.Height) - Me.LevelHeight * num3) * 0.5F))))
			Me.UsefulSize.Height = Me.LevelHeight * num3
			Me.Margin = num3 * 16F
		End Sub

		Public Sub RefreshViewport(vps As PointF())
			Dim num As Single = Me.UsefulSize.Width / Me.LevelWidth
			Dim num2 As Single = Me.UsefulSize.Height / Me.LevelHeight
			Dim pointF As PointF = Nothing
			Dim pointF2 As PointF = Nothing
			Dim pointF3 As PointF = Nothing
			Dim pointF4 As PointF = Nothing
			Dim num3 As Integer = 1
			Dim num4 As Integer = 1
			Dim num5 As Integer = 1
			Dim num6 As Integer = 1
			Dim num7 As Integer = 100
			Do
				If vps(num7 - 100).X >= 0F Then
					num3 += 1
				End If
				If vps(num7 - 50).X >= 0F Then
					num4 += 1
				End If
				If vps(num7).X >= 0F Then
					num5 += 1
				End If
				If vps(num7 + 50).X >= 0F Then
					num6 += 1
				End If
				num7 += 1
			Loop While num7 - 100 < 50
			Me.LeftVPs = New PointF(num3 - 1) {}
			Me.TopVPs = New PointF(num4 - 1) {}
			Me.RightVPs = New PointF(num5 - 1) {}
			Me.BottomVPs = New PointF(num6 - 1) {}
			Dim num8 As Integer = 0
			Dim num9 As Integer = 0
			Dim num10 As Integer = 0
			Dim num11 As Integer = 0
			Dim num12 As Integer = 100
			Do
				If vps(num12 - 100).X >= 0F Then
					Dim num13 As Single = vps(num12 - 100).X * num
					Me.LeftVPs(num8).X = CSng(Me.Origo.X) + num13
					Dim num14 As Single = CSng((Me.MapPanel.Size.Height - Me.Origo.Y))
					Me.LeftVPs(num8).Y = num14 - vps(num12 - 100).Y * num2
					num8 += 1
				End If
				If vps(num12 - 50).X >= 0F Then
					Dim num15 As Single = vps(num12 - 50).X * num
					Me.TopVPs(num9).X = CSng(Me.Origo.X) + num15
					Dim num16 As Single = CSng((Me.MapPanel.Size.Height - Me.Origo.Y))
					Me.TopVPs(num9).Y = num16 - vps(num12 - 50).Y * num2
					num9 += 1
				End If
				If vps(num12).X >= 0F Then
					Dim num17 As Single = vps(num12).X * num
					Me.RightVPs(num10).X = CSng(Me.Origo.X) + num17
					Dim num18 As Single = CSng((Me.MapPanel.Size.Height - Me.Origo.Y))
					Me.RightVPs(num10).Y = num18 - vps(num12).Y * num2
					num10 += 1
				End If
				If vps(num12 + 50).X >= 0F Then
					Dim num19 As Single = vps(num12 + 50).X * num
					Me.BottomVPs(num11).X = CSng(Me.Origo.X) + num19
					Dim num20 As Single = CSng((Me.MapPanel.Size.Height - Me.Origo.Y))
					Me.BottomVPs(num11).Y = num20 - vps(num12 + 50).Y * num2
					num11 += 1
				End If
				num12 += 1
			Loop While num12 - 100 < 50
			If Me.LeftVPs.Length > 1 Then
				If vps(50).X > 0F Then
					Me.LeftVPs(num3 - 1) = Me.TopVPs(0)
				Else
					Dim leftVPs As PointF() = Me.LeftVPs
					leftVPs(num3 - 1) = leftVPs(num3 - 2)
				End If
			End If
			If Me.TopVPs.Length > 1 Then
				If vps(100).X > 0F Then
					Me.TopVPs(num4 - 1) = Me.RightVPs(0)
				Else
					Dim topVPs As PointF() = Me.TopVPs
					topVPs(num4 - 1) = topVPs(num4 - 2)
				End If
			End If
			If Me.RightVPs.Length > 1 Then
				If vps(150).X > 0F Then
					Me.RightVPs(num5 - 1) = Me.BottomVPs(0)
				Else
					Dim rightVPs As PointF() = Me.RightVPs
					rightVPs(num5 - 1) = rightVPs(num5 - 2)
				End If
			End If
			If Me.BottomVPs.Length > 1 Then
				If vps(0).X > 0F Then
					Me.BottomVPs(num6 - 1) = Me.LeftVPs(0)
				Else
					Dim bottomVPs As PointF() = Me.BottomVPs
					bottomVPs(num6 - 1) = bottomVPs(num6 - 2)
				End If
			End If
			pointF = Me.LeftVPs(num3 - 1)
			pointF2 = Me.TopVPs(num4 - 1)
			pointF4 = Me.RightVPs(num5 - 1)
			pointF3 = Me.BottomVPs(num6 - 1)
			Dim num21 As Single = pointF4.X + pointF3.X
			Dim num22 As Single = pointF2.X + num21
			Me.Camera.X = CInt((CDec(((pointF.X + num22) * 0.25F))))
			Dim num23 As Single = pointF4.Y + pointF3.Y
			Dim num24 As Single = pointF2.Y + num23
			Me.Camera.Y = CInt((CDec(((pointF.Y + num24) * 0.25F))))
			Dim graphics As Graphics = Graphics.FromImage(Me.Backbuffer)
			Dim map As Image = Me.Map
			If map IsNot Nothing Then
				graphics.DrawImage(map, 0, 0)
			End If
			graphics.SmoothingMode = SmoothingMode.AntiAlias
			Dim num25 As Integer = 0
			If 0 < Me.Units.Length Then
				Do
					Dim num26 As Integer = CInt((CDec(Me.Units(num25).position.X)))
					Dim num27 As Integer = CInt((CDec(Me.Units(num25).position.Y)))
					If num26 >= 0 AndAlso num26 + 1 < Me.Backbuffer.Width AndAlso num27 >= 0 AndAlso num27 + 1 < Me.Backbuffer.Height Then
						Me.Backbuffer.SetPixel(num26, num27, Me.Units(num25).color)
						Me.Backbuffer.SetPixel(num26 + 1, num27, Me.Units(num25).color)
						Me.Backbuffer.SetPixel(num26, num27 + 1, Me.Units(num25).color)
						Me.Backbuffer.SetPixel(num26 + 1, num27 + 1, Me.Units(num25).color)
					End If
					num25 += 1
				Loop While num25 < Me.Units.Length
			End If
			If Me.LeftVPs.Length > 1 Then
				Dim color As Color = Color.FromArgb(24, 255, 24)
				graphics.DrawLines(New Pen(color, 1F), Me.LeftVPs)
			End If
			If Me.TopVPs.Length > 1 Then
				Dim color2 As Color = Color.FromArgb(24, 255, 24)
				graphics.DrawLines(New Pen(color2, 1F), Me.TopVPs)
			End If
			If Me.RightVPs.Length > 1 Then
				Dim color3 As Color = Color.FromArgb(24, 255, 24)
				graphics.DrawLines(New Pen(color3, 1F), Me.RightVPs)
			End If
			If Me.BottomVPs.Length > 1 Then
				Dim color4 As Color = Color.FromArgb(24, 255, 24)
				graphics.DrawLines(New Pen(color4, 1F), Me.BottomVPs)
			End If
			graphics.Dispose()
		End Sub

		Public Sub RefreshMap(<MarshalAs(UnmanagedType.U1)> force As Boolean)
			If Me.AutoRefresh OrElse force Then
				Me.InternalMapRefresh()
			End If
		End Sub

		Public Sub RefreshUnits()
			If Me.propWorld IsNot Nothing Then
				Dim num As Integer = 0
				Dim num2 As Single = Me.UsefulSize.Width / Me.LevelWidth
				Dim num3 As Single = Me.UsefulSize.Height / Me.LevelHeight
				Dim num4 As Integer = -1
				While True
					Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld + 2928 / __SizeOf(GEditorWorld)
					Dim ptr2 As __Pointer(Of GHeapDRB<GUnit *>) = ptr
					Dim num5 As Integer = num4 + 1
					Dim num6 As Integer = __Dereference((ptr2 + 4))
					If num5 >= num6 Then
						Exit While
					End If
					Dim num7 As Integer = num5 * 8 + __Dereference(ptr2)
					While __Dereference(num7) <> 2147483647
						num5 += 1
						num7 += 8
						If num5 >= num6 Then
							GoTo IL_B8
						End If
					End While
					num4 = num5
					If num5 < 0 Then
						Exit While
					End If
					Dim ptr3 As __Pointer(Of GUnit) = __Dereference((num5 * 8 + __Dereference(CType(ptr, __Pointer(Of Integer))) + 4))
					If __Dereference(CType((ptr3 + 940 / __SizeOf(GUnit)), __Pointer(Of Byte))) = 0 Then
						Dim expr_A3 As Integer = __Dereference(CType((ptr3 + 8 / __SizeOf(GUnit)), __Pointer(Of Integer)))
						If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_A3, __Dereference((__Dereference(expr_A3) + 44))) Then
							num += 1
						End If
					End If
				End While
				IL_B8:
				Me.Units = New Minimap.UnitPoint(num - 1) {}
				Dim num8 As Integer = 0
				Dim num9 As Integer = -1
				While True
					Dim ptr As __Pointer(Of GEditorWorld) = Me.propWorld + 2928 / __SizeOf(GEditorWorld)
					Dim ptr4 As __Pointer(Of GHeapDRB<GUnit *>) = ptr
					Dim num10 As Integer = num9 + 1
					Dim num11 As Integer = __Dereference((ptr4 + 4))
					If num10 >= num11 Then
						Exit While
					End If
					Dim num12 As Integer = num10 * 8 + __Dereference(ptr4)
					While __Dereference(num12) <> 2147483647
						num10 += 1
						num12 += 8
						If num10 >= num11 Then
							Return
						End If
					End While
					num9 = num10
					If num10 < 0 Then
						Exit While
					End If
					Dim ptr5 As __Pointer(Of GUnit) = __Dereference((num10 * 8 + __Dereference(CType(ptr, __Pointer(Of Integer))) + 4))
					If __Dereference(CType((ptr5 + 940 / __SizeOf(GUnit)), __Pointer(Of Byte))) = 0 Then
						Dim expr_13A As Integer = __Dereference(CType((ptr5 + 8 / __SizeOf(GUnit)), __Pointer(Of Integer)))
						If Not calli(System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride) modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_13A, __Dereference((__Dereference(expr_13A) + 44))) Then
							Me.Units(num8).position.X = CSng(Me.Origo.X) + __Dereference(CType((ptr5 + 528 / __SizeOf(GUnit)), __Pointer(Of Single))) * num2
							Dim size As Size = Me.MapPanel.Size
							Me.Units(num8).position.Y = CSng((size.Height - Me.Origo.Y)) - __Dereference(CType((ptr5 + 536 / __SizeOf(GUnit)), __Pointer(Of Single))) * num3
							Dim color As Color = Color.FromArgb(__Dereference(CType((__Dereference(CType((ptr5 + 832 / __SizeOf(GUnit)), __Pointer(Of Integer))) * 160 / __SizeOf(GEditorWorld) + Me.propWorld + 284 / __SizeOf(GEditorWorld)), __Pointer(Of Integer))))
							Me.Units(num8).color = color
							num8 += 1
						End If
					End If
				End While
			End If
		End Sub

		Public Sub DrawMap()
			Me.MapPanel.Invalidate()
		End Sub

		Private Sub MapPanel_Paint(sender As Object, e As PaintEventArgs)
			Dim backbuffer As Bitmap = Me.Backbuffer
			If backbuffer IsNot Nothing Then
				e.Graphics.DrawImage(backbuffer, 0, 0)
			End If
		End Sub

		Private Sub MapPanel_MouseDown(sender As Object, e As MouseEventArgs)
			If e.Button <> MouseButtons.Left AndAlso e.Button <> MouseButtons.Right Then
				If e.Button = MouseButtons.Middle AndAlso Not Me.CameraActive Then
					Me.CamRotateActive = True
					Me.DragPoint.X = e.X
				End If
			Else
				Me.DragPoint.X = e.X
				Me.DragPoint.Y = e.Y
				Me.CameraActive = True
				If e.Button = MouseButtons.Left Then
					Dim num As Single = CSng((e.X - Me.Camera.X))
					Dim num2 As Single = CSng((e.Y - Me.Camera.Y))
					Dim num3 As Single = Me.LevelHeight * num2
					Dim num4 As Single = Me.LevelWidth * num
					Me.raise_CameraMove(num4 / Me.UsefulSize.Width, num3 / Me.UsefulSize.Height)
				End If
			End If
		End Sub

		Private Sub MapPanel_MouseMove(sender As Object, e As MouseEventArgs)
			If Me.CameraActive Then
				Me.CameraDrag = True
				Dim num As Single = CSng((e.X - Me.DragPoint.X))
				Dim num2 As Single = CSng((e.Y - Me.DragPoint.Y))
				Dim num3 As Single = Me.LevelHeight * num2
				Dim num4 As Single = Me.LevelWidth * num
				Me.raise_CameraMove(num4 / Me.UsefulSize.Width, num3 / Me.UsefulSize.Height)
				Me.DragPoint.X = e.X
				Me.DragPoint.Y = e.Y
			Else If Me.CamRotateActive Then
				Me.raise_CameraRotate(CSng((e.X - Me.DragPoint.X)) * 0.02F)
				Me.DragPoint.X = e.X
			End If
		End Sub

		Private Sub ConfigTools_ButtonClick(idx As Integer, radio_group As Integer)
			If radio_group = 1 Then
				Me.raise_MapNeedsRefresh()
			Else If radio_group = 2 Then
				Dim b As Byte = If((Not Me.AutoRefresh), 1, 0)
				Me.AutoRefresh = (b <> 0)
				Me.ConfigTools.SetItemPushed(idx, b <> 0)
				Dim enable As Byte = If((Not Me.AutoRefresh), 1, 0)
				Me.ConfigTools.SetGroupEnable(1, enable <> 0)
			End If
		End Sub

		Private Sub MapPanel_MouseUp(sender As Object, e As MouseEventArgs)
			If(e.Button = MouseButtons.Left OrElse e.Button = MouseButtons.Right) AndAlso Me.CameraActive Then
				If Not Me.CameraDrag Then
					Dim num As Single = CSng((e.X - Me.Camera.X))
					Dim num2 As Single = CSng((e.Y - Me.Camera.Y))
					Dim num3 As Single = Me.LevelHeight * num2
					Dim num4 As Single = Me.LevelWidth * num
					Me.raise_CameraMove(num4 / Me.UsefulSize.Width, num3 / Me.UsefulSize.Height)
				End If
				Me.CameraActive = False
				Me.CameraDrag = False
			Else If e.Button = MouseButtons.Middle Then
				Me.CamRotateActive = False
			End If
		End Sub

		Protected Sub raise_MapNeedsRefresh()
			Dim mapNeedsRefresh As Minimap.MapNeedsRefreshHandler = Me.MapNeedsRefresh
			If mapNeedsRefresh IsNot Nothing Then
				mapNeedsRefresh()
			End If
		End Sub

		Protected Sub raise_CameraMove(i1 As Single, i2 As Single)
			Dim cameraMove As Minimap.MoveCameraHandler = Me.CameraMove
			If cameraMove IsNot Nothing Then
				cameraMove(i1, i2)
			End If
		End Sub

		Protected Sub raise_CameraRotate(i1 As Single)
			Dim cameraRotate As Minimap.RotateCameraHandler = Me.CameraRotate
			If cameraRotate IsNot Nothing Then
				cameraRotate(i1)
			End If
		End Sub
	End Class
End Namespace
