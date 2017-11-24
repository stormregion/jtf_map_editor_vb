Imports Microsoft.DirectX
Imports Microsoft.DirectX.Direct3D
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NDirect3D
		Private D3DDevice As Device

		Private PresentParams As PresentParameters()

		Private VBuffer As VertexBuffer

		Private LineVertices As CustomVertex.TransformedColored()

		Private RectangleVertices As CustomVertex.TransformedColored()

		Private FilledRectangleVertices As CustomVertex.TransformedColored()

		Private D3DFont As Microsoft.DirectX.Direct3D.Font

		Private SysFont As System.Drawing.Font

		Private StartVertexIndex As Integer

		Private EndVertexIndex As Integer

		Private LastOperation As Integer

		Private Sub DeviceResetEvent(sender As Object, e As EventArgs)
			Dim d3DFont As Microsoft.DirectX.Direct3D.Font = Me.D3DFont
			If d3DFont IsNot Nothing Then
				d3DFont.OnResetDevice()
			End If
			Dim valueType As ValueType = Nothing
			Me.VBuffer = New VertexBuffer(valueType.[GetType](), 4096, Me.D3DDevice, Usage.Dynamic, VertexFormats.Diffuse Or VertexFormats.Transformed, Pool.[Default])
			Me.LineVertices = New CustomVertex.TransformedColored(1) {}
			Me.RectangleVertices = New CustomVertex.TransformedColored(7) {}
			Me.FilledRectangleVertices = New CustomVertex.TransformedColored(5) {}
			Me.D3DDevice.VertexFormat = (VertexFormats.Diffuse Or VertexFormats.Transformed)
			Me.D3DDevice.SetStreamSource(0, Me.VBuffer, 0)
			Me.EndVertexIndex = 0
			Me.StartVertexIndex = 0
			Me.LastOperation = 0
		End Sub

		Private Sub DeviceResizeEvent(sender As Object, e As CancelEventArgs)
			e.Cancel = True
		End Sub

		Public Sub New(control As Control)
			Me.PresentParams = New PresentParameters(0) {}
			Me.PresentParams(0) = New PresentParameters()
			Me.PresentParams(0).Windowed = True
			Me.PresentParams(0).SwapEffect = SwapEffect.Discard
			Me.D3DDevice = New Device(0, DeviceType.Hardware, control, CreateFlags.SoftwareVertexProcessing, Me.PresentParams)
			AddHandler Me.D3DDevice.DeviceReset, AddressOf Me.DeviceResetEvent
			AddHandler Me.D3DDevice.DeviceResizing, AddressOf Me.DeviceResizeEvent
			Dim font As System.Drawing.Font = New System.Drawing.Font("Arial", 8F)
			Me.SysFont = font
			Me.D3DFont = New Microsoft.DirectX.Direct3D.Font(Me.D3DDevice, font)
			Me.D3DDevice.Reset(Me.PresentParams)
		End Sub

		Public Sub DisposeD3DX()
			Dim d3DFont As Microsoft.DirectX.Direct3D.Font = Me.D3DFont
			If d3DFont IsNot Nothing Then
				d3DFont.Dispose()
			End If
		End Sub

		Public Sub Clear(color As Color)
			Me.D3DDevice.Clear(ClearFlags.Target, color, 1F, 0)
		End Sub

		Public Sub Clear()
			Dim blue As Color = Color.Blue
			Me.D3DDevice.Clear(ClearFlags.Target, blue, 1F, 0)
		End Sub

		Public Sub Present()
			Me.D3DDevice.Present()
		End Sub

		Public Sub BeginScene()
			Me.D3DDevice.BeginScene()
			Me.D3DDevice.SetStreamSource(0, Me.VBuffer, 0)
		End Sub

		Public Sub EndScene()
			Me.Flush(False)
			Me.D3DDevice.EndScene()
		End Sub

		Public Sub Reset()
			Me.D3DDevice.Reset(Me.PresentParams)
		End Sub

		Public Sub Resize(width As Integer, height As Integer)
			Me.PresentParams(0).BackBufferWidth = width
			Me.PresentParams(0).BackBufferHeight = height
			Me.D3DDevice.Reset(Me.PresentParams)
		End Sub

		Public Sub Flush(<MarshalAs(UnmanagedType.U1)> restart As Boolean)
			If Me.StartVertexIndex < Me.EndVertexIndex Then
				Me.D3DDevice.VertexFormat = (VertexFormats.Diffuse Or VertexFormats.Transformed)
				Dim lastOperation As Integer = Me.LastOperation
				If lastOperation <> 1 Then
					If lastOperation = 2 Then
						Dim startVertexIndex As Integer = Me.StartVertexIndex
						Me.D3DDevice.DrawPrimitives(PrimitiveType.TriangleList, startVertexIndex, (Me.EndVertexIndex - startVertexIndex) / 3)
					End If
				Else
					Dim startVertexIndex2 As Integer = Me.StartVertexIndex
					Me.D3DDevice.DrawPrimitives(PrimitiveType.LineList, startVertexIndex2, Me.EndVertexIndex - startVertexIndex2 >> 1)
				End If
			End If
			Me.LastOperation = 0
			If restart Then
				Me.EndVertexIndex = 0
				Me.StartVertexIndex = 0
			Else
				Me.StartVertexIndex = Me.EndVertexIndex
			End If
		End Sub

		Public Sub DrawLine(color As Integer, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
			Dim lastOperation As Integer = Me.LastOperation
			If 1 <> lastOperation AndAlso 0 <> lastOperation Then
				Me.Flush(False)
			End If
			Dim endVertexIndex As Integer = Me.EndVertexIndex
			Dim arg_13F_0 As GraphicsStream
			If 4096 >= endVertexIndex + 2 Then
				Dim num As UInteger = CUInt(__SizeOf(CustomVertex.TransformedColored))
				arg_13F_0 = Me.VBuffer.Lock(CInt((num * CUInt(endVertexIndex))), CInt((CInt(num) << 1)), LockFlags.NoOverwrite)
			Else
				Me.Flush(True)
				Dim num As UInteger = CUInt(__SizeOf(CustomVertex.TransformedColored))
				arg_13F_0 = Me.VBuffer.Lock(Me.EndVertexIndex * CInt(num), CInt((CInt(num) << 1)), LockFlags.Discard)
			End If
			Me.LineVertices(1).Z = 0F
			Me.LineVertices(0).Z = 0F
			Me.LineVertices(1).Rhw = 1F
			Me.LineVertices(0).Rhw = 1F
			Me.LineVertices(1).Color = color
			Me.LineVertices(0).Color = color
			Me.LineVertices(0).X = CSng(x1)
			Me.LineVertices(0).Y = CSng(y1)
			Me.LineVertices(1).X = CSng(x2)
			Me.LineVertices(1).Y = CSng(y2)
			arg_13F_0.Write(Me.LineVertices)
			Me.VBuffer.Unlock()
			Me.EndVertexIndex += 2
			Me.LastOperation = 1
		End Sub

		Public Sub DrawLine(color As Color, x1 As Integer, y1 As Integer, x2 As Integer, y2 As Integer)
			Me.DrawLine(color.ToArgb(), x1, y1, x2, y2)
		End Sub

		Public Sub FillRectangle(color As Color, rect As RectangleF)
			Me.FillRectangle(color, rect.X, rect.Y, rect.Width, rect.Height)
		End Sub

		Public Sub FillRectangle(color As Color, rect As Rectangle)
			Me.FillRectangle(color, CSng(rect.X), CSng(rect.Y), CSng(rect.Width), CSng(rect.Height))
		End Sub

		Public Sub FillRectangle(color As Color, x As Integer, y As Integer, width As Integer, height As Integer)
			Me.FillRectangle(color, CSng(x), CSng(y), CSng(width), CSng(height))
		End Sub

		Public Sub FillRectangle(color As Color, x As Single, y As Single, width As Single, height As Single)
			Dim lastOperation As Integer = Me.LastOperation
			If 2 <> lastOperation AndAlso 0 <> lastOperation Then
				Me.Flush(False)
			End If
			Dim endVertexIndex As Integer = Me.EndVertexIndex
			Dim arg_324_0 As GraphicsStream
			If 4096 >= endVertexIndex + 6 Then
				Dim num As UInteger = CUInt(__SizeOf(CustomVertex.TransformedColored))
				arg_324_0 = Me.VBuffer.Lock(CInt((num * CUInt(endVertexIndex))), CInt((num * 6UI)), LockFlags.NoOverwrite)
			Else
				Me.Flush(True)
				Dim num As UInteger = CUInt(__SizeOf(CustomVertex.TransformedColored))
				arg_324_0 = Me.VBuffer.Lock(Me.EndVertexIndex * CInt(num), CInt((num * 6UI)), LockFlags.Discard)
			End If
			Me.FilledRectangleVertices(5).Z = 0F
			Me.FilledRectangleVertices(4).Z = 0F
			Me.FilledRectangleVertices(3).Z = 0F
			Me.FilledRectangleVertices(2).Z = 0F
			Me.FilledRectangleVertices(1).Z = 0F
			Me.FilledRectangleVertices(0).Z = 0F
			Me.FilledRectangleVertices(5).Rhw = 1F
			Me.FilledRectangleVertices(4).Rhw = 1F
			Me.FilledRectangleVertices(3).Rhw = 1F
			Me.FilledRectangleVertices(2).Rhw = 1F
			Me.FilledRectangleVertices(1).Rhw = 1F
			Me.FilledRectangleVertices(0).Rhw = 1F
			Me.FilledRectangleVertices(5).Color = color.ToArgb()
			Dim filledRectangleVertices As CustomVertex.TransformedColored() = Me.FilledRectangleVertices
			filledRectangleVertices(4).Color = filledRectangleVertices(5).Color
			Dim filledRectangleVertices2 As CustomVertex.TransformedColored() = Me.FilledRectangleVertices
			filledRectangleVertices2(3).Color = filledRectangleVertices2(4).Color
			Dim filledRectangleVertices3 As CustomVertex.TransformedColored() = Me.FilledRectangleVertices
			filledRectangleVertices3(2).Color = filledRectangleVertices3(3).Color
			Dim filledRectangleVertices4 As CustomVertex.TransformedColored() = Me.FilledRectangleVertices
			filledRectangleVertices4(1).Color = filledRectangleVertices4(2).Color
			Dim filledRectangleVertices5 As CustomVertex.TransformedColored() = Me.FilledRectangleVertices
			filledRectangleVertices5(0).Color = filledRectangleVertices5(1).Color
			Dim x2 As Single = x + width
			Me.FilledRectangleVertices(0).X = x2
			Me.FilledRectangleVertices(0).Y = y
			Me.FilledRectangleVertices(1).X = x2
			Dim y2 As Single = y + height
			Me.FilledRectangleVertices(1).Y = y2
			Me.FilledRectangleVertices(2).X = x
			Me.FilledRectangleVertices(2).Y = y
			Me.FilledRectangleVertices(3).X = x2
			Me.FilledRectangleVertices(3).Y = y2
			Me.FilledRectangleVertices(4).X = x
			Me.FilledRectangleVertices(4).Y = y2
			Me.FilledRectangleVertices(5).X = x
			Me.FilledRectangleVertices(5).Y = y
			arg_324_0.Write(Me.FilledRectangleVertices)
			Me.VBuffer.Unlock()
			Me.EndVertexIndex += 6
			Me.LastOperation = 2
		End Sub

		Public Sub DrawRectangle(color As Color, rect As RectangleF)
			Me.DrawRectangle(color, rect.X, rect.Y, rect.Width, rect.Height)
		End Sub

		Public Sub DrawRectangle(color As Color, rect As Rectangle)
			Me.DrawRectangle(color, CSng(rect.X), CSng(rect.Y), CSng(rect.Width), CSng(rect.Height))
		End Sub

		Public Sub DrawRectangle(color As Color, x As Integer, y As Integer, width As Integer, height As Integer)
			Me.DrawRectangle(color, CSng(x), CSng(y), CSng(width), CSng(height))
		End Sub

		Public Sub DrawRectangle(color As Color, x As Single, y As Single, width As Single, height As Single)
			Dim lastOperation As Integer = Me.LastOperation
			If 1 <> lastOperation AndAlso 0 <> lastOperation Then
				Me.Flush(False)
			End If
			Dim endVertexIndex As Integer = Me.EndVertexIndex
			Dim arg_408_0 As GraphicsStream
			If 4096 >= endVertexIndex + 8 Then
				Dim num As UInteger = CUInt(__SizeOf(CustomVertex.TransformedColored))
				arg_408_0 = Me.VBuffer.Lock(CInt((num * CUInt(endVertexIndex))), CInt((CInt(num) << 3)), LockFlags.NoOverwrite)
			Else
				Me.Flush(True)
				Dim num As UInteger = CUInt(__SizeOf(CustomVertex.TransformedColored))
				arg_408_0 = Me.VBuffer.Lock(Me.EndVertexIndex * CInt(num), CInt((CInt(num) << 3)), LockFlags.Discard)
			End If
			Me.RectangleVertices(7).Z = 0F
			Me.RectangleVertices(6).Z = 0F
			Me.RectangleVertices(5).Z = 0F
			Me.RectangleVertices(4).Z = 0F
			Me.RectangleVertices(3).Z = 0F
			Me.RectangleVertices(2).Z = 0F
			Me.RectangleVertices(1).Z = 0F
			Me.RectangleVertices(0).Z = 0F
			Me.RectangleVertices(7).Rhw = 1F
			Me.RectangleVertices(6).Rhw = 1F
			Me.RectangleVertices(5).Rhw = 1F
			Me.RectangleVertices(4).Rhw = 1F
			Me.RectangleVertices(3).Rhw = 1F
			Me.RectangleVertices(2).Rhw = 1F
			Me.RectangleVertices(1).Rhw = 1F
			Me.RectangleVertices(0).Rhw = 1F
			Me.RectangleVertices(7).Color = color.ToArgb()
			Dim rectangleVertices As CustomVertex.TransformedColored() = Me.RectangleVertices
			rectangleVertices(6).Color = rectangleVertices(7).Color
			Dim rectangleVertices2 As CustomVertex.TransformedColored() = Me.RectangleVertices
			rectangleVertices2(5).Color = rectangleVertices2(6).Color
			Dim rectangleVertices3 As CustomVertex.TransformedColored() = Me.RectangleVertices
			rectangleVertices3(4).Color = rectangleVertices3(5).Color
			Dim rectangleVertices4 As CustomVertex.TransformedColored() = Me.RectangleVertices
			rectangleVertices4(3).Color = rectangleVertices4(4).Color
			Dim rectangleVertices5 As CustomVertex.TransformedColored() = Me.RectangleVertices
			rectangleVertices5(2).Color = rectangleVertices5(3).Color
			Dim rectangleVertices6 As CustomVertex.TransformedColored() = Me.RectangleVertices
			rectangleVertices6(1).Color = rectangleVertices6(2).Color
			Dim rectangleVertices7 As CustomVertex.TransformedColored() = Me.RectangleVertices
			rectangleVertices7(0).Color = rectangleVertices7(1).Color
			Me.RectangleVertices(0).X = x
			Me.RectangleVertices(0).Y = y
			Dim x2 As Single = x + width
			Me.RectangleVertices(1).X = x2
			Me.RectangleVertices(1).Y = y
			Me.RectangleVertices(2).X = x2
			Me.RectangleVertices(2).Y = y
			Me.RectangleVertices(3).X = x2
			Dim y2 As Single = y + height
			Me.RectangleVertices(3).Y = y2
			Me.RectangleVertices(4).X = x2
			Me.RectangleVertices(4).Y = y2
			Me.RectangleVertices(5).X = x
			Me.RectangleVertices(5).Y = y2
			Me.RectangleVertices(6).X = x
			Me.RectangleVertices(6).Y = y2
			Me.RectangleVertices(7).X = x
			Me.RectangleVertices(7).Y = y
			arg_408_0.Write(Me.RectangleVertices)
			Me.VBuffer.Unlock()
			Me.EndVertexIndex += 8
			Me.LastOperation = 1
		End Sub

		Public Sub TextOutA([string] As String, x As Integer, y As Integer, color As Color)
			Me.D3DFont.DrawText(Nothing, [string], x, y, color)
		End Sub
	End Class
End Namespace
