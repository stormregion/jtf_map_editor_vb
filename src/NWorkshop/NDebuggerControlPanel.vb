Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NDebuggerControlPanel
		Inherits UserControl

		Private components As Container

		Public Sub New()
			Me.InitializeComponent()
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
			Dim clientSize As Size = New Size(248, 270)
			MyBase.ClientSize = clientSize
			MyBase.Name = "DebuggerControlPanel"
			Me.Text = "DebuggerControlPanel"
		End Sub
	End Class
End Namespace
