Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class TextInputBox
		Inherits Form

		Private OKBtn As Button

		Private CancelBtn As Button

		Private TextEdit As TextBox

		Private components As Container

		Public Property EditText() As String
			Get
				Return Me.TextEdit.Text
			End Get
			Set(value As String)
				Me.TextEdit.Text = value
			End Set
		End Property

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
			Me.OKBtn = New Button()
			Me.CancelBtn = New Button()
			Me.TextEdit = New TextBox()
			MyBase.SuspendLayout()
			Me.OKBtn.DialogResult = DialogResult.OK
			Dim location As Point = New Point(16, 48)
			Me.OKBtn.Location = location
			Me.OKBtn.Name = "OKBtn"
			Dim size As Size = New Size(120, 23)
			Me.OKBtn.Size = size
			Me.OKBtn.TabIndex = 0
			Me.OKBtn.Text = "OK"
			Me.CancelBtn.DialogResult = DialogResult.Cancel
			Dim location2 As Point = New Point(160, 48)
			Me.CancelBtn.Location = location2
			Me.CancelBtn.Name = "CancelBtn"
			Dim size2 As Size = New Size(120, 23)
			Me.CancelBtn.Size = size2
			Me.CancelBtn.TabIndex = 1
			Me.CancelBtn.Text = "Cancel"
			Dim location3 As Point = New Point(16, 16)
			Me.TextEdit.Location = location3
			Me.TextEdit.Name = "TextEdit"
			Dim size3 As Size = New Size(264, 20)
			Me.TextEdit.Size = size3
			Me.TextEdit.TabIndex = 2
			Me.TextEdit.Text = "TextBox"
			MyBase.AcceptButton = Me.OKBtn
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			MyBase.CancelButton = Me.CancelBtn
			Dim clientSize As Size = New Size(292, 82)
			MyBase.ClientSize = clientSize
			MyBase.ControlBox = False
			MyBase.Controls.Add(Me.TextEdit)
			MyBase.Controls.Add(Me.CancelBtn)
			MyBase.Controls.Add(Me.OKBtn)
			MyBase.Name = "TextInputBox"
			MyBase.SizeGripStyle = SizeGripStyle.Hide
			MyBase.StartPosition = FormStartPosition.Manual
			Me.Text = "Set text"
			MyBase.ResumeLayout(False)
		End Sub
	End Class
End Namespace
