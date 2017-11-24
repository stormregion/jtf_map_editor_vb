Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.Reflection
Imports System.Resources
Imports System.Runtime.InteropServices

Namespace NWorkshop
	Public Class ImageServer
		Private ResourceMan As ResourceManager

		Private Reservoir As Hashtable

		Private BkReservoir As Hashtable

		Private Shared Server As ImageServer = Nothing

		Private Sub New(resourcepath As String)
			Me.ResourceMan = New ResourceManager(resourcepath, Assembly.GetExecutingAssembly())
			Me.Reservoir = New Hashtable()
			Me.BkReservoir = New Hashtable()
		End Sub

		Public Shared Function GetImageServer(resourcepath As String) As ImageServer
			If ImageServer.Server Is Nothing Then
				ImageServer.Server = New ImageServer(resourcepath)
			End If
			Return ImageServer.Server
		End Function

		Public Function GetImage(ID As String) As Image
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim image As Image = Nothing
			If Me.ResourceMan IsNot Nothing Then
				Try
					image = (TryCast(Me.Reservoir(ID), Image))
					If image Is Nothing Then
						image = (TryCast(Me.ResourceMan.GetObject(ID, CultureInfo.InvariantCulture), Image))
						If image IsNot Nothing Then
							Me.Reservoir.Add(ID, image)
						End If
					End If
					Return image
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End If
			Return image
		End Function

		Public Function GetImage(ID As String, Background As KnownColor) As Image
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Dim image As Image = Nothing
			Dim key As String = ID + Background
			If Me.ResourceMan IsNot Nothing Then
				Try
					image = (TryCast(Me.BkReservoir(key), Image))
					If image Is Nothing Then
						Dim image2 As Image = Me.GetImage(ID)
						If image2 IsNot Nothing Then
							image = New Bitmap(image2.Width, image2.Height, PixelFormat.Format32bppArgb)
							Dim graphics As Graphics = Graphics.FromImage(image)
							Dim color As Color = Color.FromKnownColor(Background)
							graphics.Clear(color)
							Dim rect As Rectangle = New Rectangle(0, 0, image2.Width, image2.Height)
							graphics.DrawImage(image2, rect)
							Me.BkReservoir.Add(key, image)
						End If
					End If
					Return image
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			End If
			Return image
		End Function
	End Class
End Namespace
