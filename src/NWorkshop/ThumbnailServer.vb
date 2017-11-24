Imports System
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices

Namespace NWorkshop
	Public Class ThumbnailServer
		Implements IDisposable

		Public Enum ThumbType
			Fluid = 7
			Tile = 5
			Locale = 9
			Effect = 4
			Sound = 3
			Model = 0
			Cloud = 8
			Map = 10
			Box = 6
			Unit = 2
			Material = 1
		End Enum

		Private CamRotation As __Pointer(Of GMatrix3)

		Private CamPos As __Pointer(Of GPoint3)

		Private IScene As __Pointer(Of GIScene)

		Private mode As ThumbnailServer.ThumbType

		Private ProgressDialog As ThumbProgress

		Private disposed As Boolean

		Private forceupdate As Boolean

		Private Sub InitCam(model As __Pointer(Of GIModel))
			Dim gBox As GBox
			<Module>.GBox.{ctor}(gBox)
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GBox* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), model, gBox, __Dereference((__Dereference(CType(model, __Pointer(Of Integer))) + 356)))
			Dim num As Single = CSng(Math.Abs(gBox))
			Dim num2 As Single = CSng(Math.Abs(CDec((__Dereference((gBox + 4))))))
			Dim num3 As Single
			If num < num2 Then
				num3 = num2
			Else
				num3 = num
			End If
			num2 = CSng(Math.Abs(CDec((__Dereference((gBox + 12))))))
			Dim num4 As Single
			If num3 < num2 Then
				num4 = num2
			Else
				num4 = num3
			End If
			num2 = CSng(Math.Abs(CDec((__Dereference((gBox + 20))))))
			Dim num5 As Single
			If num4 < num2 Then
				num5 = num2
			Else
				num5 = num4
			End If
			num2 = CSng(Math.Abs(CDec((__Dereference((gBox + 8))))))
			Dim num6 As Single
			If num5 < num2 Then
				num6 = num2
			Else
				num6 = num5
			End If
			num2 = CSng(Math.Abs(CDec((__Dereference((gBox + 16))))))
			Dim num7 As Single
			If num6 < num2 Then
				num7 = num2
			Else
				num7 = num6
			End If
			Dim num8 As Single = num7 * 2.13546252F
			Dim ptr As __Pointer(Of GPoint3) = <Module>.new(12UI)
			Dim ptr2 As __Pointer(Of GPoint3)
			Try
				If ptr IsNot Nothing Then
					__Dereference(CType(ptr, __Pointer(Of Single))) = 0F
					__Dereference(CType((ptr + 4 / __SizeOf(GPoint3)), __Pointer(Of Single))) = 0F
					__Dereference(CType((ptr + 8 / __SizeOf(GPoint3)), __Pointer(Of Single))) = num8
					ptr2 = ptr
				Else
					ptr2 = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.CamPos = ptr2
			<Module>.GPoint3.*=(ptr2, Me.CamRotation)
			Dim num9 As Single = (__Dereference((gBox + 8)) + __Dereference((gBox + 12))) * 0.5F
			Dim camPos As __Pointer(Of GPoint3) = Me.CamPos
			Dim expr_119 As __Pointer(Of GPoint3) = camPos
			__Dereference(expr_119) = __Dereference(expr_119)
			__Dereference((camPos + 4)) = __Dereference((camPos + 4)) + num9
			__Dereference((camPos + 8)) = __Dereference((camPos + 8))
			Dim gPoint As GPoint3 = 0F
			__Dereference((gPoint + 4)) = 0F
			__Dereference((gPoint + 8)) = num8 * 0.1F
			calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), model, gPoint, __Dereference((__Dereference(CType(model, __Pointer(Of Integer))) + 24)))
		End Sub

		Public Overrides Sub Dispose()
			Me.Dispose(True)
			GC.SuppressFinalize(Me)
		End Sub

		Private Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If Not Me.disposed Then
				Dim camPos As __Pointer(Of GPoint3) = Me.CamPos
				If camPos IsNot Nothing Then
					<Module>.delete(CType(camPos, __Pointer(Of Void)))
					Me.CamPos = Nothing
				End If
				Dim camRotation As __Pointer(Of GMatrix3) = Me.CamRotation
				If camRotation IsNot Nothing Then
					<Module>.delete(CType(camRotation, __Pointer(Of Void)))
					Me.CamRotation = Nothing
				End If
				Dim iScene As __Pointer(Of GIScene) = Me.IScene
				If iScene IsNot Nothing Then
					Dim expr_41 As __Pointer(Of GIScene) = iScene
					Dim expr_4B As __Pointer(Of GIScene) = expr_41 + __Dereference((__Dereference(CType((expr_41 + 4 / __SizeOf(GIScene)), __Pointer(Of Integer))) + 4)) / __SizeOf(GIScene) + 4 / __SizeOf(GIScene)
					Dim arg_55_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_4B, __Dereference((__Dereference(CType(expr_4B, __Pointer(Of Integer))) + 4)))
					Me.IScene = Nothing
				End If
			End If
			Me.disposed = True
		End Sub

		Public Sub New(thumbmode As ThumbnailServer.ThumbType)
			Me.forceupdate = False
			Me.disposed = False
			Me.mode = thumbmode
			Me.IScene = Nothing
			Me.CamRotation = Nothing
			Me.CamPos = Nothing
			Me.ProgressDialog = New ThumbProgress()
			Dim thumbType As ThumbnailServer.ThumbType = Me.mode
			If thumbType = ThumbnailServer.ThumbType.Model OrElse thumbType = ThumbnailServer.ThumbType.Unit Then
				Dim num As Integer = calli(GIScene* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride)), <Module>.IEngine, 0, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 12)))
				Me.IScene = num
				Dim gColor As GColor = 0.3F
				__Dereference((gColor + 4)) = 0.3F
				__Dereference((gColor + 8)) = 0.4F
				__Dereference((gColor + 12)) = 1F
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced)), num, gColor, __Dereference((__Dereference(num) + 68)))
				Dim gVector As GVector3 = -1F
				__Dereference((gVector + 4)) = -1F
				__Dereference((gVector + 8)) = 0F
				Dim gColor2 As GColor = 0.8F
				__Dereference((gColor2 + 4)) = 0.8F
				__Dereference((gColor2 + 8)) = 0.9F
				__Dereference((gColor2 + 12)) = 1F
				Dim iScene As __Pointer(Of GIScene) = Me.IScene
				Dim arg_FD_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,GColor,GVector3), iScene, gColor2, gVector, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 52)))
				iScene = Me.IScene
				calli(System.Void modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single,System.Single), iScene, 0.5F, 0.5F, 0.5F, 0F, 0F, 0F, 1F, 1F, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 76)))
				Dim ptr As __Pointer(Of GMatrix3) = <Module>.new(48UI)
				Dim ptr2 As __Pointer(Of GMatrix3)
				Try
					If ptr IsNot Nothing Then
						ptr2 = <Module>.GMatrix3.{ctor}(ptr)
					Else
						ptr2 = 0
					End If
				Catch 
					<Module>.delete(CType(ptr, __Pointer(Of Void)))
					Throw
				End Try
				Me.CamRotation = ptr2
				Dim gMatrix As GMatrix3
				Dim ptr3 As __Pointer(Of GMatrix3) = <Module>.Matrix3RotationX(AddressOf gMatrix, 3.53429174F)
				cpblk(ptr2, ptr3, 48)
				Dim gMatrix2 As GMatrix3
				<Module>.GMatrix3.*=(ptr2, <Module>.Matrix3RotationY(AddressOf gMatrix2, -0.7853982F))
			End If
		End Sub

		Public Function GetThumbnail(root As String, fullfilename As String, hash As String, <MarshalAs(UnmanagedType.U1)> forceupdate As Boolean) As Image
			Dim result As Image = Nothing
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, "Thumbs" + "/" + root + hash + ".tga")
			Dim gBaseString<char>2 As GBaseString<char>
			Try
				Dim num As UInteger = CUInt((__Dereference(ptr)))
				Dim ptr2 As __Pointer(Of SByte)
				If num <> 0UI Then
					ptr2 = num
				Else
					ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				<Module>.GFileSystem.MakeFullHomePath(<Module>.FS, AddressOf gBaseString<char>2, ptr2)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			Dim gBaseString<char>3 As GBaseString<char>
			Dim ptr5 As __Pointer(Of GImage)
			Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Dim directory As DirectoryInfo = New FileInfo(New String(CType((If((gBaseString<char>2 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>2)), __Pointer(Of SByte)))).Directory
				<Module>.GBaseString<char>.{ctor}(gBaseString<char>3, fullfilename)
				Try
					Dim value As __Pointer(Of SByte)
					If gBaseString<char>3 IsNot Nothing Then
						value = gBaseString<char>3
					Else
						value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Me.ProgressDialog.[Next](New String(CType(value, __Pointer(Of SByte))))
					If Me.mode = ThumbnailServer.ThumbType.Tile Then
						Dim gBaseString<char>4 As GBaseString<char>
						Dim src As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>4, fullfilename + "_1.mat")
						Try
							<Module>.GBaseString<char>.=(gBaseString<char>3, src)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>4 IsNot Nothing Then
							<Module>.free(gBaseString<char>4)
						End If
					End If
					If Not directory.Exists Then
						directory.Create()
					End If
					Dim ptr3 As __Pointer(Of SByte)
					If gBaseString<char>3 IsNot Nothing Then
						ptr3 = gBaseString<char>3
					Else
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gFileAttributes As GFileAttributes
					<Module>.GFileSystem.CheckFile(<Module>.FS, ptr3, gFileAttributes)
					Dim ptr4 As __Pointer(Of SByte)
					If gBaseString<char>2 IsNot Nothing Then
						ptr4 = gBaseString<char>2
					Else
						ptr4 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gFileAttributes2 As GFileAttributes
					Dim num3 As Integer
					If <Module>.GFileSystem.CheckFile(<Module>.FS, ptr4, gFileAttributes2) IsNot Nothing Then
						Dim num2 As Integer
						If gFileAttributes Is Nothing AndAlso gFileAttributes2 Is Nothing AndAlso __Dereference((gFileAttributes + 8)) < __Dereference((gFileAttributes2 + 8)) + 20000000L AndAlso __Dereference((gFileAttributes + 8)) > __Dereference((gFileAttributes2 + 8)) - 20000000L Then
							num2 = 0
						Else
							num2 = 1
						End If
						If CByte(num2) = 0 Then
							num3 = 0
							GoTo IL_190
						End If
					End If
					num3 = 1
					IL_190:
					Dim num4 As Integer
					If CByte(num3) = 0 AndAlso Not forceupdate Then
						num4 = 0
					Else
						num4 = 1
					End If
					Dim flag As Boolean = CByte(num4) <> 0
					ptr5 = Nothing
					If Not flag Then
						GoTo IL_3FA
					End If
					Me.ProgressDialog.Show()
					Dim value2 As __Pointer(Of SByte)
					If gBaseString<char>3 IsNot Nothing Then
						value2 = gBaseString<char>3
					Else
						value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Me.ProgressDialog.[Next](New String(CType(value2, __Pointer(Of SByte))))
					Select Case Me.mode
						Case ThumbnailServer.ThumbType.Model, ThumbnailServer.ThumbType.Unit
							Dim ptr6 As __Pointer(Of SByte)
							If gBaseString<char>3 IsNot Nothing Then
								ptr6 = gBaseString<char>3
							Else
								ptr6 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							Dim iScene As __Pointer(Of GIScene) = Me.IScene
							Dim ptr7 As __Pointer(Of GIModel) = calli(GIModel* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*,System.Single,System.Byte modopt(System.Runtime.CompilerServices.CompilerMarshalOverride),System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), iScene, ptr6, __Dereference((<Module>.Measures + 8)), 1, 0, __Dereference((__Dereference(CType(iScene, __Pointer(Of Integer))) + 132)))
							If ptr7 IsNot Nothing Then
								GoTo IL_2A5
							End If
							Me.ProgressDialog.Finished()
						Case ThumbnailServer.ThumbType.Material
							GoTo IL_31F
						Case ThumbnailServer.ThumbType.Sound
							GoTo IL_3B0
						Case ThumbnailServer.ThumbType.Effect
							GoTo IL_3B0
						Case ThumbnailServer.ThumbType.Tile
							GoTo IL_31F
						Case Else
							GoTo IL_3B0
					End Select
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>3 IsNot Nothing Then
					<Module>.free(gBaseString<char>3)
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>2 IsNot Nothing Then
				<Module>.free(gBaseString<char>2)
			End If
			Return result
			IL_2A5:
			Try
				Try
					Dim ptr7 As __Pointer(Of GIModel)
					Me.InitCam(ptr7)
					Dim iScene2 As __Pointer(Of GIScene) = Me.IScene
					ptr5 = calli(GImage* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.Int32,System.Int32,GPoint3 modopt(System.Runtime.CompilerServices.IsConst)* modopt(System.Runtime.CompilerServices.IsImplicitlyDereferenced),System.Single,System.Single,System.Single,System.Single,System.Single), iScene2, 64, 64, Me.CamPos, -0.7853982F, 0.3926991F, 0.7853982F, 1F, 1000F, __Dereference((__Dereference(CType(iScene2, __Pointer(Of Integer))) + 24)))
					Dim expr_2E8 As __Pointer(Of GIModel) = ptr7
					Dim expr_2F2 As __Pointer(Of GIModel) = expr_2E8 + __Dereference((__Dereference(CType((expr_2E8 + 4 / __SizeOf(GIModel)), __Pointer(Of Integer))) + 4)) / __SizeOf(GIModel) + 4 / __SizeOf(GIModel)
					Dim arg_2FC_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_2F2, __Dereference((__Dereference(CType(expr_2F2, __Pointer(Of Integer))) + 4)))
					GoTo IL_36D
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			IL_31F:
			Try
				Try
					Dim ptr8 As __Pointer(Of SByte)
					If gBaseString<char>3 IsNot Nothing Then
						ptr8 = gBaseString<char>3
					Else
						ptr8 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					ptr5 = calli(GImage* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.SByte modopt(System.Runtime.CompilerServices.IsSignUnspecifiedByte) modopt(System.Runtime.CompilerServices.IsConst)*), <Module>.IEngine, ptr8, __Dereference((__Dereference(CType(<Module>.IEngine, __Pointer(Of Integer))) + 196)))
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			IL_36D:
			Try
				Try
					If ptr5 IsNot Nothing Then
						Dim ptr9 As __Pointer(Of SByte)
						If gBaseString<char>2 IsNot Nothing Then
							ptr9 = gBaseString<char>2
						Else
							ptr9 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						<Module>.GImage.SaveTGA(ptr5, ptr9, Nothing)
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			IL_3B0:
			Try
				Try
					Dim ptr10 As __Pointer(Of SByte)
					If gBaseString<char>2 IsNot Nothing Then
						ptr10 = gBaseString<char>2
					Else
						ptr10 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gFileAttributes As GFileAttributes
					<Module>.GFileSystem.SetFileTime(<Module>.FS, ptr10, __Dereference((gFileAttributes + 8)))
					GoTo IL_46F
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			IL_3FA:
			Try
				Try
					Dim ptr11 As __Pointer(Of GImage) = <Module>.new(36UI)
					Dim ptr12 As __Pointer(Of GImage)
					Try
						If ptr11 IsNot Nothing Then
							ptr12 = <Module>.GImage.{ctor}(ptr11)
						Else
							ptr12 = 0
						End If
					Catch 
						<Module>.delete(CType(ptr11, __Pointer(Of Void)))
						Throw
					End Try
					ptr5 = ptr12
					Dim ptr13 As __Pointer(Of SByte)
					If gBaseString<char>2 IsNot Nothing Then
						ptr13 = gBaseString<char>2
					Else
						ptr13 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					If <Module>.GImage.LoadTGA(ptr12, ptr13, Nothing) Is Nothing Then
						If ptr12 Is Nothing Then
							GoTo IL_4AB
						End If
						<Module>.GImage.{dtor}(ptr12)
						<Module>.delete(ptr12)
						GoTo IL_4AB
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			IL_46F:
			Try
				Try
					If ptr5 IsNot Nothing Then
						Dim hbitmap As IntPtr = New IntPtr(<Module>.GImage.CreateHBitmap(ptr5))
						result = Image.FromHbitmap(hbitmap)
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			IL_4AB:
			Try
				Try
					Me.ProgressDialog.Finished()
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>3 IsNot Nothing Then
					<Module>.free(gBaseString<char>3)
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>2 IsNot Nothing Then
				<Module>.free(gBaseString<char>2)
			End If
			Return result
		End Function

		Public Sub StartThumbnailGeneration(count As Integer)
			Me.ProgressDialog.StartThumbnailGeneration(count)
		End Sub

		Public Sub FinishThumbnailGeneration()
			Me.ProgressDialog.Hide()
		End Sub
	End Class
End Namespace
