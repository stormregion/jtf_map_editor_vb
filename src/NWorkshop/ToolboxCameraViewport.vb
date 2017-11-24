Imports NControls
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxCameraViewport
		Inherits Form

		Protected ToolWindows As ArrayList

		Protected CamViewPortExist As __Pointer(Of Boolean)

		Protected IRenderTargetIdx As Integer

		Protected IRenderTarget As __Pointer(Of GIRenderTarget)

		Protected IViewport As __Pointer(Of GIViewport)

		Protected CameraPosition As __Pointer(Of GPoint3)

		Protected CameraDirection As Single

		Protected CameraElevation As Single

		Protected CameraFOV As Single

		Protected CameraRoll As Single

		Protected ValidCamera As Boolean

		Protected NeedToRender As Boolean

		Protected FormCaption As __Pointer(Of GBaseString<char>)

		Protected PrevWidth As Integer

		Protected PrevHeight As Integer

		Private panCameraViewport As NSolidPanel

		Private components As Container

		Public Sub New(toolwindows As ArrayList, camviewportexist As __Pointer(Of Boolean))
			Dim ptr As __Pointer(Of GPoint3) = <Module>.new(12UI)
			Dim cameraPosition As __Pointer(Of GPoint3)
			Try
				If ptr IsNot Nothing Then
					__Dereference(CType((ptr + 8 / __SizeOf(GPoint3)), __Pointer(Of Single))) = 0F
					__Dereference(CType((ptr + 4 / __SizeOf(GPoint3)), __Pointer(Of Single))) = 0F
					__Dereference(CType(ptr, __Pointer(Of Single))) = 0F
					cameraPosition = ptr
				Else
					cameraPosition = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.CameraPosition = cameraPosition
			Me.CameraDirection = 0F
			Me.CameraElevation = 0F
			Me.CameraFOV = 0F
			Me.CameraRoll = 0F
			Me.ValidCamera = False
			Me.NeedToRender = True
			Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.new(8UI)
			Dim formCaption As __Pointer(Of GBaseString<char>)
			Try
				If ptr2 IsNot Nothing Then
					__Dereference(CType(ptr2, __Pointer(Of Integer))) = 0
					__Dereference(CType((ptr2 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0
					formCaption = ptr2
				Else
					formCaption = 0
				End If
			Catch 
				<Module>.delete(CType(ptr2, __Pointer(Of Void)))
				Throw
			End Try
			Me.FormCaption = formCaption
			Me.PrevWidth = 0
			Me.PrevHeight = 0
			Me.ToolWindows = toolwindows
			Me.CamViewPortExist = camviewportexist
			Me.InitializeComponent()
			Dim nSolidPanel As NSolidPanel = New NSolidPanel()
			Me.panCameraViewport = nSolidPanel
			nSolidPanel.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.panCameraViewport.Location = location
			Me.panCameraViewport.Name = "panCameraViewport"
			Dim size As Size = New Size(400, 300)
			Me.panCameraViewport.Size = size
			Me.panCameraViewport.TabIndex = 0
			AddHandler Me.panCameraViewport.SizeChanged, AddressOf Me.panCameraViewport_SizeChanged
			AddHandler Me.panCameraViewport.Paint, AddressOf Me.panCameraViewport_Paint
			MyBase.Controls.Add(Me.panCameraViewport)
			Me.IRenderTargetIdx = -1
			Me.IRenderTarget = Nothing
			Me.IViewport = Nothing
			Dim size2 As Size = New Size(593, 335)
			Me.panCameraViewport.Size = size2
			Dim clientSize As Size = New Size(593, 335)
			MyBase.ClientSize = clientSize
			Dim location2 As Point = New Point(677, 607)
			MyBase.Location = location2
		End Sub

		Public Sub Destroy()
			Me.Dispose(True)
		End Sub

		Public Sub Paint()
			Me.panCameraViewport_Paint(Nothing, Nothing)
		End Sub

		Public Function GetFocus() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return MyBase.ContainsFocus
		End Function

		Public Sub SetCamera(pos As __Pointer(Of GPoint3), dir As Single, elev As Single, fov As Single, roll As Single, <MarshalAs(UnmanagedType.U1)> ForceRefresh As Boolean)
			Me.ValidCamera = True
			Dim cameraPosition As __Pointer(Of GPoint3) = Me.CameraPosition
			Dim ptr As __Pointer(Of GPoint3) = cameraPosition
			Dim num As Integer
			If __Dereference(pos) = __Dereference(ptr) AndAlso __Dereference((pos + 4)) = __Dereference((ptr + 4)) AndAlso __Dereference((pos + 8)) = __Dereference((ptr + 8)) Then
				num = 1
			Else
				num = 0
			End If
			If CByte(num) <> 0 AndAlso dir = Me.CameraDirection AndAlso elev = Me.CameraElevation AndAlso fov = Me.CameraFOV AndAlso roll = Me.CameraRoll Then
				Me.NeedToRender = False
			Else
				Me.NeedToRender = True
				cpblk(cameraPosition, pos, 12)
				Me.CameraDirection = dir
				Me.CameraElevation = elev
				Me.CameraFOV = fov
				Me.CameraRoll = roll
			End If
			If ForceRefresh Then
				Me.NeedToRender = True
			End If
		End Sub

		Public Sub SetCaption(caption As __Pointer(Of GBaseString<char>))
			<Module>.GBaseString<char>.=(Me.FormCaption, caption)
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			Me.Deinitialize()
			If disposing Then
				Dim container As Container = Me.components
				If container IsNot Nothing Then
					container.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Protected Sub Deinitialize()
			Dim camViewPortExist As __Pointer(Of Boolean) = Me.CamViewPortExist
			If camViewPortExist IsNot Nothing Then
				__Dereference(camViewPortExist) = False
			End If
			Dim toolWindows As ArrayList = Me.ToolWindows
			If toolWindows IsNot Nothing Then
				toolWindows.Remove(Me)
			End If
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, Me.IRenderTargetIdx, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 104)))
			Me.IRenderTargetIdx = -1
			Me.IRenderTarget = Nothing
			Me.IViewport = Nothing
		End Sub

		Private Sub InitializeComponent()
			Dim resourceManager As ResourceManager = New ResourceManager(GetType(ToolboxCameraViewport))
			MyBase.SuspendLayout()
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(400, 300)
			MyBase.ClientSize = clientSize
			MyBase.Icon = CType(resourceManager.GetObject("$this.Icon"), Icon)
			Dim location As Point = New Point(870, 642)
			MyBase.Location = location
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "ToolboxCameraViewport"
			MyBase.StartPosition = FormStartPosition.Manual
			Me.Text = "CameraPreview"
			MyBase.TopMost = True
			AddHandler MyBase.Resize, AddressOf Me.ToolboxCameraViewport_Resize
			AddHandler MyBase.SizeChanged, AddressOf Me.ToolboxCameraViewport_SizeChanged
			AddHandler MyBase.Load, AddressOf Me.ToolboxCameraViewport_Load
			AddHandler MyBase.Closed, AddressOf Me.ToolboxCameraViewport_Closed
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub OnIdle(sender As Object, e As EventArgs)
			If MyBase.ContainsFocus Then
				Me.panCameraViewport.Invalidate(False)
			End If
		End Sub

		Private Sub ToolboxCameraViewport_Closed(sender As Object, e As EventArgs)
		End Sub

		Private Sub ToolboxCameraViewport_Load(sender As Object, e As EventArgs)
			Dim ptr As __Pointer(Of HWND__) = CType(Me.panCameraViewport.Handle.ToPointer(), __Pointer(Of HWND__))
			Dim num As Integer = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,HWND__*,System.Int32), <Module>.IEngine, ptr, 4, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 100)))
			Me.IRenderTargetIdx = num
			Dim num2 As Integer = calli(GIRenderTarget* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), <Module>.IEngine, num, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 96)))
			Me.IRenderTarget = num2
			Me.IViewport = calli(GIViewport* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32), num2, 0, __Dereference((__Dereference(num2) + 32)))
			AddHandler Application.Idle, AddressOf Me.OnIdle
		End Sub

		Private Sub panCameraViewport_Paint(sender As Object, e As PaintEventArgs)
			If Me.IRenderTarget IsNot Nothing Then
				Dim iViewport As __Pointer(Of GIViewport) = Me.IViewport
				If iViewport IsNot Nothing AndAlso Me.ValidCamera AndAlso Me.NeedToRender Then
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single,System.Single), iViewport, Me.CameraPosition, Me.CameraDirection, Me.CameraElevation, Me.CameraRoll, __Dereference((__Dereference(CType(iViewport, __Pointer(Of Integer))) + 12)))
					Dim iViewport2 As __Pointer(Of GIViewport) = Me.IViewport
					Dim num As Single
					Dim num2 As Single
					Dim num3 As Single
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), iViewport2, num, num2, num3, __Dereference((__Dereference(CType(iViewport2, __Pointer(Of Integer))) + 44)))
					Dim iViewport3 As __Pointer(Of GIViewport) = Me.IViewport
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single), iViewport3, Me.CameraFOV, num2, num3, __Dereference((__Dereference(CType(iViewport3, __Pointer(Of Integer))) + 40)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int64), <Module>.Scene, 0L, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 32)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, 0, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 304)))
					Dim iRenderTarget As __Pointer(Of GIRenderTarget) = Me.IRenderTarget
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GIScene*,System.UInt32 modopt(System.Runtime.CompilerServices.IsLong)), iRenderTarget, <Module>.Scene, 8256, __Dereference((__Dereference(CType(iRenderTarget, __Pointer(Of Integer))) + 36)))
					calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.Scene, 1, __Dereference((__Dereference(CType(<Module>.Scene, __Pointer(Of Integer))) + 304)))
					Dim gBaseString<char> As GBaseString<char>
					<Module>.GBaseString<char>.{ctor}(gBaseString<char>, 20F.ToString())
					Try
						Dim gBaseString<char>2 As GBaseString<char>
						<Module>.GBaseString<char>.{ctor}(gBaseString<char>2, 1.76666665F.ToString())
						Try
							Dim gBaseString<char>3 As GBaseString<char>
							Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.+(AddressOf gBaseString<char>3, CType((AddressOf <Module>.??_C@_0BA@HNGHCCF@CameraPreview?5?$FL?$AA@), __Pointer(Of SByte)), Me.FormCaption)
							Try
								Dim gBaseString<char>4 As GBaseString<char>
								Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(ptr, AddressOf gBaseString<char>4, CType((AddressOf <Module>.??_C@_0N@DMCNAIPA@?$FN?5?5aspect?5?3?5?$AA@), __Pointer(Of SByte)))
								Try
									Dim gBaseString<char>5 As GBaseString<char>
									Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(ptr2, AddressOf gBaseString<char>5, gBaseString<char>2)
									Try
										Dim gBaseString<char>6 As GBaseString<char>
										Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(ptr3, AddressOf gBaseString<char>6, CType((AddressOf <Module>.??_C@_0P@IEAIKAGH@?5?5ServerFPS?5?3?5?$AA@), __Pointer(Of SByte)))
										Try
											Dim gBaseString<char>7 As GBaseString<char>
											Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.+(ptr4, AddressOf gBaseString<char>7, gBaseString<char>)
											Try
												Dim num4 As UInteger = CUInt((__Dereference(CType(ptr5, __Pointer(Of Integer)))))
												Dim value As __Pointer(Of SByte)
												If num4 <> 0UI Then
													value = num4
												Else
													value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
												End If
												Me.Text = New String(CType(value, __Pointer(Of SByte)))
											Catch 
												<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>7), __Pointer(Of Void)))
												Throw
											End Try
											If gBaseString<char>7 IsNot Nothing Then
												<Module>.free(gBaseString<char>7)
												gBaseString<char>7 = 0
											End If
										Catch 
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
											Throw
										End Try
										If gBaseString<char>6 IsNot Nothing Then
											<Module>.free(gBaseString<char>6)
											gBaseString<char>6 = 0
										End If
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>5 IsNot Nothing Then
										<Module>.free(gBaseString<char>5)
										gBaseString<char>5 = 0
									End If
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
									Throw
								End Try
								If gBaseString<char>4 IsNot Nothing Then
									<Module>.free(gBaseString<char>4)
									gBaseString<char>4 = 0
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>3 IsNot Nothing Then
								<Module>.free(gBaseString<char>3)
								gBaseString<char>3 = 0
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
				End If
			End If
		End Sub

		Private Sub panCameraViewport_SizeChanged(sender As Object, e As EventArgs)
			If Me.IRenderTarget IsNot Nothing Then
				Me.NeedToRender = True
				Dim clientSize As Size = Me.panCameraViewport.ClientSize
				Dim clientSize2 As Size = Me.panCameraViewport.ClientSize
				Dim num As Integer = __Dereference(CType(Me.IRenderTarget, __Pointer(Of Integer))) + 12
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32), Me.IRenderTarget, clientSize2.Width, clientSize.Height, __Dereference(num))
				If Me.panCameraViewport.ClientSize.Width <> 0 AndAlso Me.panCameraViewport.ClientSize.Height <> 0 Then
					MyBase.Invalidate()
				End If
			End If
		End Sub

		Private Sub ToolboxCameraViewport_Resize(sender As Object, e As EventArgs)
		End Sub

		Private Sub ToolboxCameraViewport_SizeChanged(sender As Object, e As EventArgs)
			Dim num As Integer = MyBase.ClientSize.Height
			Dim num2 As Integer = MyBase.ClientSize.Width
			If MyBase.ClientSize.Height <> Me.PrevHeight Then
				num2 = CInt((CDec((CSng(MyBase.ClientSize.Height) * 1.76666665F))))
			Else If MyBase.ClientSize.Width <> Me.PrevWidth Then
				num = CInt((CDec((CSng(MyBase.ClientSize.Width) * 0.5660377F))))
			End If
			If num2 <> 0 AndAlso num <> 0 Then
				Dim size As Size = New Size(num2, num)
				Me.panCameraViewport.Size = size
				Dim clientSize As Size = New Size(num2, num)
				MyBase.ClientSize = clientSize
			End If
			Me.PrevHeight = num
			Me.PrevWidth = num2
		End Sub
	End Class
End Namespace
