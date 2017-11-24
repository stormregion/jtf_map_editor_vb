Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NCopyKeyDialog
		Inherits Form

		Private Yes As Button

		Private No As Button

		Private Cancel As Button

		Private TextLabel As Label

		Private components As Container

		Public Sub New(yestext As String, notext As String)
			Me.InitializeComponent()
			Me.Yes.Text = yestext
			Me.No.Text = notext
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
			Me.Yes = New Button()
			Me.No = New Button()
			Me.Cancel = New Button()
			Me.TextLabel = New Label()
			MyBase.SuspendLayout()
			Dim location As Point = New Point(8, 48)
			Me.Yes.Location = location
			Me.Yes.Name = "Yes"
			Dim size As Size = New Size(216, 24)
			Me.Yes.Size = size
			Me.Yes.TabIndex = 0
			Me.Yes.Text = "Copy loop start value to this key"
			AddHandler Me.Yes.Click, AddressOf Me.Yes_Click
			Dim location2 As Point = New Point(240, 48)
			Me.No.Location = location2
			Me.No.Name = "No"
			Dim size2 As Size = New Size(216, 24)
			Me.No.Size = size2
			Me.No.TabIndex = 1
			Me.No.Text = "Copy value of this key to loop start"
			AddHandler Me.No.Click, AddressOf Me.No_Click
			Dim location3 As Point = New Point(192, 88)
			Me.Cancel.Location = location3
			Me.Cancel.Name = "Cancel"
			Dim size3 As Size = New Size(80, 24)
			Me.Cancel.Size = size3
			Me.Cancel.TabIndex = 2
			Me.Cancel.Text = "&Cancel"
			AddHandler Me.Cancel.Click, AddressOf Me.Cancel_Click
			Dim location4 As Point = New Point(24, 16)
			Me.TextLabel.Location = location4
			Me.TextLabel.Name = "TextLabel"
			Dim size4 As Size = New Size(416, 16)
			Me.TextLabel.Size = size4
			Me.TextLabel.TabIndex = 3
			Me.TextLabel.Text = "The key value of loop start and loop end must be equal!"
			Me.TextLabel.TextAlign = ContentAlignment.MiddleCenter
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(464, 125)
			MyBase.ClientSize = clientSize
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.TextLabel)
			MyBase.Controls.Add(Me.Cancel)
			MyBase.Controls.Add(Me.No)
			MyBase.Controls.Add(Me.Yes)
			MyBase.FormBorderStyle = FormBorderStyle.FixedSingle
			MyBase.Name = "NCopyKeyDialog"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = FormStartPosition.CenterScreen
			Me.Text = "Key value mismatch"
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub Yes_Click(sender As Object, e As EventArgs)
			MyBase.DialogResult = DialogResult.Yes
			MyBase.Close()
		End Sub

		Private Sub No_Click(sender As Object, e As EventArgs)
			MyBase.DialogResult = DialogResult.No
			MyBase.Close()
		End Sub

		Private Sub Cancel_Click(sender As Object, e As EventArgs)
			MyBase.DialogResult = DialogResult.Cancel
			MyBase.Close()
		End Sub
	End Class
End Namespace
