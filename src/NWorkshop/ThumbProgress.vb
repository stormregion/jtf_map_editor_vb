Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ThumbProgress
		Inherits Form

		Private TheProgressBar As ProgressBar

		Private components As Container

		Private Prompt As String

		Public Sub New(<MarshalAs(UnmanagedType.U1)> loading As Boolean)
			Me.InitializeComponent()
			If loading Then
				Me.Text = "Loading map"
			End If
		End Sub

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
			Me.TheProgressBar = New ProgressBar()
			MyBase.SuspendLayout()
			Dim location As Point = New Point(8, 64)
			Me.TheProgressBar.Location = location
			Me.TheProgressBar.Name = "TheProgressBar"
			Dim size As Size = New Size(424, 23)
			Me.TheProgressBar.Size = size
			Me.TheProgressBar.[Step] = 1
			Me.TheProgressBar.TabIndex = 0
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			MyBase.CausesValidation = False
			Dim clientSize As Size = New Size(442, 100)
			MyBase.ClientSize = clientSize
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.TheProgressBar)
			MyBase.FormBorderStyle = FormBorderStyle.FixedSingle
			MyBase.Name = "ThumbProgress"
			MyBase.ShowInTaskbar = False
			MyBase.SizeGripStyle = SizeGripStyle.Hide
			MyBase.StartPosition = FormStartPosition.CenterScreen
			Me.Text = "Generating thumbnails"
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub PaintInfoPanel()
			Dim font As Font = New Font(New String(CType((AddressOf <Module>.??_C@_0BF@LKOMBMBF@Microsoft?5Sans?5Serif?$AA@), __Pointer(Of SByte))), 8.25F)
			Dim graphics As Graphics = MyBase.CreateGraphics()
			Dim color As Color = Color.FromKnownColor(KnownColor.Control)
			graphics.Clear(color)
			Dim black As Color = Color.Black
			graphics.DrawString("Processing:", font, New SolidBrush(black), 0F, 0F)
			Dim black2 As Color = Color.Black
			graphics.DrawString(Me.Prompt, font, New SolidBrush(black2), 20F, 20F)
			graphics.Dispose()
		End Sub

		Public Sub StartThumbnailGeneration(count As Integer)
			Me.TheProgressBar.Minimum = 0
			Me.TheProgressBar.Maximum = count
			Me.TheProgressBar.Value = 0
		End Sub

		Public Sub [Next](current As Integer, prompt As String)
			Me.TheProgressBar.Value = current
			Me.Prompt = prompt
			Me.PaintInfoPanel()
		End Sub

		Public Sub [Next](prompt As String)
			Dim value As Integer = Me.TheProgressBar.Value
			Me.TheProgressBar.Value = value + 1
			Dim value2 As Integer = Me.TheProgressBar.Value
			Me.TheProgressBar.Value = value2 - 1
			Me.Prompt = prompt
			Me.PaintInfoPanel()
		End Sub

		Public Sub Finished()
			Dim value As Integer = Me.TheProgressBar.Value
			Me.TheProgressBar.Value = value + 1
			If Me.TheProgressBar.Value = Me.TheProgressBar.Maximum Then
				MyBase.Hide()
			End If
		End Sub
	End Class
End Namespace
