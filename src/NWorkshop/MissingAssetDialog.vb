Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class MissingAssetDialog
		Inherits Form

		Private IgnoreAllBtn As Button

		Private DeleteBtn As Button

		Private AbortBtn As Button

		Private ReplaceBtn As Button

		Private WarningText As Label

		Private IgnoreBtn As Button

		Private components As Container

		Private propAssetName As String

		Private propNewName As String

		Private propAllowIgnore As Boolean

		Private propType As Integer

		Private NewDialog As NewAssetPicker

		Private AssetResult As Integer

		Public Property Type() As Integer
			Get
				Return Me.propType
			End Get
			Set(value As Integer)
				Me.propType = value
			End Set
		End Property

		Public Property AllowIgnore() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return Me.propAllowIgnore
			End Get
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				Me.propAllowIgnore = value
			End Set
		End Property

		Public Property NewName() As String
			Get
				Return Me.propNewName
			End Get
			Set(value As String)
				Me.propNewName = value
			End Set
		End Property

		Public Property AssetName() As String
			Get
				Return Me.propAssetName
			End Get
			Set(value As String)
				Me.propAssetName = value
			End Set
		End Property

		Public Sub New()
			Me.propAssetName = ""
			Me.propNewName = ""
			Me.propAllowIgnore = True
			Me.AssetResult = 105
			Me.InitializeComponent()
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing Then
				Dim newDialog As NewAssetPicker = Me.NewDialog
				If newDialog IsNot Nothing Then
					newDialog.Dispose()
				End If
				Dim container As Container = Me.components
				If container IsNot Nothing Then
					container.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
			Me.WarningText = New Label()
			Me.IgnoreBtn = New Button()
			Me.IgnoreAllBtn = New Button()
			Me.DeleteBtn = New Button()
			Me.AbortBtn = New Button()
			Me.ReplaceBtn = New Button()
			MyBase.SuspendLayout()
			Dim location As Point = New Point(8, 8)
			Me.WarningText.Location = location
			Me.WarningText.Name = "WarningText"
			Dim size As Size = New Size(424, 48)
			Me.WarningText.Size = size
			Me.WarningText.TabIndex = 0
			Me.IgnoreBtn.DialogResult = DialogResult.Ignore
			Me.IgnoreBtn.FlatStyle = FlatStyle.System
			Dim location2 As Point = New Point(8, 64)
			Me.IgnoreBtn.Location = location2
			Me.IgnoreBtn.Name = "IgnoreBtn"
			Me.IgnoreBtn.TabIndex = 1
			Me.IgnoreBtn.Text = "Ignore"
			Me.IgnoreAllBtn.DialogResult = DialogResult.Yes
			Me.IgnoreAllBtn.FlatStyle = FlatStyle.System
			Dim location3 As Point = New Point(88, 64)
			Me.IgnoreAllBtn.Location = location3
			Me.IgnoreAllBtn.Name = "IgnoreAllBtn"
			Me.IgnoreAllBtn.TabIndex = 2
			Me.IgnoreAllBtn.Text = "Ignore All"
			Me.DeleteBtn.DialogResult = DialogResult.No
			Me.DeleteBtn.FlatStyle = FlatStyle.System
			Dim location4 As Point = New Point(184, 64)
			Me.DeleteBtn.Location = location4
			Me.DeleteBtn.Name = "DeleteBtn"
			Me.DeleteBtn.TabIndex = 3
			Me.DeleteBtn.Text = "Delete"
			Me.AbortBtn.DialogResult = DialogResult.Abort
			Me.AbortBtn.FlatStyle = FlatStyle.System
			Dim location5 As Point = New Point(360, 64)
			Me.AbortBtn.Location = location5
			Me.AbortBtn.Name = "AbortBtn"
			Me.AbortBtn.TabIndex = 4
			Me.AbortBtn.Text = "Abort load"
			Me.ReplaceBtn.FlatStyle = FlatStyle.System
			Dim location6 As Point = New Point(264, 64)
			Me.ReplaceBtn.Location = location6
			Me.ReplaceBtn.Name = "ReplaceBtn"
			Me.ReplaceBtn.TabIndex = 5
			Me.ReplaceBtn.Text = "Replace"
			AddHandler Me.ReplaceBtn.Click, AddressOf Me.ReplaceBtn_Click
			MyBase.AcceptButton = Me.IgnoreBtn
			MyBase.AutoScale = False
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			MyBase.CancelButton = Me.AbortBtn
			Dim clientSize As Size = New Size(440, 94)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.ReplaceBtn)
			MyBase.Controls.Add(Me.AbortBtn)
			MyBase.Controls.Add(Me.DeleteBtn)
			MyBase.Controls.Add(Me.IgnoreAllBtn)
			MyBase.Controls.Add(Me.IgnoreBtn)
			MyBase.Controls.Add(Me.WarningText)
			MyBase.FormBorderStyle = FormBorderStyle.FixedDialog
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			MyBase.Name = "MissingAssetDialog"
			MyBase.ShowInTaskbar = False
			MyBase.SizeGripStyle = SizeGripStyle.Hide
			MyBase.StartPosition = FormStartPosition.CenterParent
			AddHandler MyBase.Load, AddressOf Me.MissingAssetDialog_Load
			MyBase.ResumeLayout(False)
		End Sub

		Public Function ShowDialog(owner As IWin32Window) As Integer
			Select Case MyBase.ShowDialog(owner)
				Case DialogResult.Abort
					Return 105
				Case DialogResult.Ignore
					Return 100
				Case DialogResult.Yes
					Return 103
				Case DialogResult.No
					Return 101
			End Select
			Return Me.AssetResult
		End Function

		Private Sub MissingAssetDialog_Load(sender As Object, e As EventArgs)
			Dim text As String = ""
			Dim str As String = text
			Dim str2 As String = text
			Select Case Me.propType
				Case 0
					str = "ambient sound"
					str2 = "An ambient sound"
				Case 1
					str = "decal"
					str2 = "A decal"
				Case 2
					str = "object"
					str2 = "An object"
				Case 3
					str = "road"
					str2 = "A road texture"
				Case 4
					str = "terrain texture"
					str2 = "A terrain texture"
				Case 5
					str = "unit"
					str2 = "A unit"
				Case 6
					str = "building"
					str2 = "A building"
				Case 7
					str = "effect"
					str2 = "An effect"
			End Select
			Me.Text = "Missing " + str + "!"
			Me.WarningText.Text = str2 + " is missing" & vbLf & vbLf + Me.propAssetName
			Me.IgnoreAllBtn.Enabled = Me.propAllowIgnore
			Me.IgnoreBtn.Enabled = Me.propAllowIgnore
			Me.NewDialog = New NewAssetPicker(NewAssetPicker.ObjectType.MissingAsset, Me.propType)
		End Sub

		Private Sub ReplaceBtn_Click(sender As Object, e As EventArgs)
			Me.NewDialog.Reset()
			If Me.NewDialog.ShowDialog(Me) = DialogResult.OK Then
				Me.propNewName = Me.NewDialog.NewName
				Me.AssetResult = 102
				MyBase.Close()
			End If
		End Sub
	End Class
End Namespace
