Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NDebuggerLog
		Inherits UserControl

		Private LogList As ListBox

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
			Me.LogList = New ListBox()
			MyBase.SuspendLayout()
			Me.LogList.Dock = DockStyle.Fill
			Me.LogList.HorizontalScrollbar = True
			Dim location As Point = New Point(0, 0)
			Me.LogList.Location = location
			Me.LogList.Name = "LogList"
			Dim size As Size = New Size(256, 303)
			Me.LogList.Size = size
			Me.LogList.TabIndex = 0
			MyBase.Controls.Add(Me.LogList)
			MyBase.Name = "NDebuggerLog"
			Dim size2 As Size = New Size(256, 304)
			MyBase.Size = size2
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub Reset()
			Me.LogList.Items.Clear()
		End Sub

		Public Sub AddEcho(row As String)
			Me.LogList.Items.Add(row)
			Me.LogList.SelectedIndex = Me.LogList.Items.Count - 1
		End Sub
	End Class
End Namespace
