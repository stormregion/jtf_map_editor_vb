Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Windows.Forms

Namespace NControls
	Public Class DropList
		Inherits Control

		Public Delegate Sub __Delegate_ChooseItem( As Integer)

		Public Delegate Sub __Delegate_MouseDownOccured()

		Public NormalItemBackgroundBrush As Brush

		Public NormalItemTextBrush As Brush

		Public DropButtonLightBorderBrush As Brush

		Public DropButtonDarkBorderBrush As Brush

		Public DropButtonBackgroundBrush As Brush

		Public DropButtonTextBrush As Brush

		Public ListFont As Font

		Public ItemsListBox As DropListPopup

		Public Items As ArrayList

		Public SelectedIndex As Integer

		Public Custom Event MouseDownOccured As DropList.__Delegate_MouseDownOccured
			AddHandler
				Me.MouseDownOccured = [Delegate].Combine(Me.MouseDownOccured, value)
			End AddHandler
			RemoveHandler
				Me.MouseDownOccured = [Delegate].Remove(Me.MouseDownOccured, value)
			End RemoveHandler
		End Event

		Public Custom Event ChooseItem As DropList.__Delegate_ChooseItem
			AddHandler
				Me.ChooseItem = [Delegate].Combine(Me.ChooseItem, value)
			End AddHandler
			RemoveHandler
				Me.ChooseItem = [Delegate].Remove(Me.ChooseItem, value)
			End RemoveHandler
		End Event

		Public Sub New()
			Me.ChooseItem = Nothing
			Me.MouseDownOccured = Nothing
			Dim color As Color = Color.FromKnownColor(KnownColor.Window)
			Me.NormalItemBackgroundBrush = New SolidBrush(color)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.NormalItemTextBrush = New SolidBrush(color2)
			Dim color3 As Color = Color.FromKnownColor(KnownColor.ControlLightLight)
			Me.DropButtonLightBorderBrush = New SolidBrush(color3)
			Dim color4 As Color = Color.FromKnownColor(KnownColor.ControlDark)
			Me.DropButtonDarkBorderBrush = New SolidBrush(color4)
			Dim color5 As Color = Color.FromKnownColor(KnownColor.Control)
			Me.DropButtonBackgroundBrush = New SolidBrush(color5)
			Dim color6 As Color = Color.FromKnownColor(KnownColor.ControlText)
			Me.DropButtonTextBrush = New SolidBrush(color6)
			Me.ListFont = Me.Font
			Me.Items = New ArrayList()
			Me.SelectedIndex = -1
		End Sub

		Public Sub SetSelection(sel As Integer)
			Me.SelectedIndex = sel
			MyBase.Invalidate()
			Me.UnDrop()
			Me.raise_ChooseItem(Me.SelectedIndex)
		End Sub

		Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
			Dim clipRectangle As Rectangle = e.ClipRectangle
			e.Graphics.FillRectangle(Me.NormalItemBackgroundBrush, clipRectangle)
		End Sub

		Protected Overrides Sub OnPaint(e As PaintEventArgs)
			If Me.SelectedIndex >= 0 Then
				Dim point As PointF = New PointF(0F, 1F)
				e.Graphics.DrawString(Me.Items(Me.SelectedIndex).ToString(), Me.Font, Me.NormalItemTextBrush, point)
			End If
			Dim num As Single = CSng((MyBase.Width - 16))
			Dim x As Single = num + 1F
			e.Graphics.FillRectangle(Me.DropButtonBackgroundBrush, x, 1F, 14F, CSng(MyBase.Height) - 2F)
			e.Graphics.FillRectangle(Me.DropButtonLightBorderBrush, num, 0F, 15F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonLightBorderBrush, num, 0F, 1F, CSng(MyBase.Height))
			e.Graphics.FillRectangle(Me.DropButtonDarkBorderBrush, x, CSng(MyBase.Height) - 1F, 14F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonDarkBorderBrush, num + 16F - 1F, 0F, 1F, CSng(MyBase.Height))
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, num + 5F, 6F, 7F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, num + 6F, 7F, 5F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, num + 7F, 8F, 3F, 1F)
			e.Graphics.FillRectangle(Me.DropButtonTextBrush, num + 8F, 9F, 1F, 1F)
		End Sub

		Protected Overrides Sub OnClick(e As EventArgs)
			If Me.ItemsListBox Is Nothing Then
				Me.Drop()
			Else
				Me.UnDrop()
			End If
		End Sub

		Protected Overrides Sub OnGotFocus(e As EventArgs)
			Me.Drop()
		End Sub

		Protected Sub ItemsListBox_ChooseItem(index As Integer)
			If index >= 0 Then
				Me.SelectedIndex = index
				MyBase.Invalidate()
			End If
			Me.UnDrop()
			Me.raise_ChooseItem(Me.SelectedIndex)
		End Sub

		Protected Sub Drop()
			If Me.ItemsListBox Is Nothing Then
				Me.ItemsListBox = New DropListPopup()
				Dim size As Size = New Size(MyBase.Size.Width, 300)
				Me.ItemsListBox.Size = size
				Me.ItemsListBox.Font = Me.ListFont
				Dim items As ArrayList = Me.Items
				If items IsNot Nothing Then
					Dim num As Integer = 0
					If 0 < items.Count Then
						Do
							Me.ItemsListBox.Items.Add(Me.Items(num))
							num += 1
						Loop While num < Me.Items.Count
					End If
				End If
				Dim selectedIndex As Integer = Me.SelectedIndex
				If selectedIndex >= 0 Then
					Me.ItemsListBox.SelectedIndex = selectedIndex
				End If
				Dim size2 As Size = MyBase.Size
				Dim num2 As Integer = Me.ItemsListBox.Items.Count + 1
				Dim size3 As Size = New Size(size2.Width, Me.ItemsListBox.ItemHeight * num2)
				Me.ItemsListBox.Size = size3
				Dim p As Point = New Point(-1, MyBase.Size.Height)
				Dim location As Point = MyBase.PointToScreen(p)
				Me.ItemsListBox.Location = location
				Dim arg_14C_0 As Integer = <Module>.GetSystemMetrics(1)
				Dim location2 As Point = Me.ItemsListBox.Location
				If arg_14C_0 < Me.ItemsListBox.Size.Height + location2.Y Then
					Dim p2 As Point = New Point(-1, -(Me.ItemsListBox.Items.Count * Me.ItemsListBox.ItemHeight))
					Dim location3 As Point = MyBase.PointToScreen(p2)
					Me.ItemsListBox.Location = location3
				End If
				Me.ItemsListBox.Parent = MyBase.Parent
				AddHandler Me.ItemsListBox.ChooseItem, AddressOf Me.ItemsListBox_ChooseItem
				Me.ItemsListBox.CreateControl()
				<Module>.SetCapture(CType(Me.ItemsListBox.Handle.ToPointer(), __Pointer(Of HWND__)))
			End If
		End Sub

		Protected Sub UnDrop()
			Dim itemsListBox As DropListPopup = Me.ItemsListBox
			If itemsListBox IsNot Nothing Then
				itemsListBox.Dispose()
				Me.ItemsListBox = Nothing
			End If
		End Sub

		Protected Sub raise_ChooseItem(i1 As Integer)
			Dim chooseItem As DropList.__Delegate_ChooseItem = Me.ChooseItem
			If chooseItem IsNot Nothing Then
				chooseItem(i1)
			End If
		End Sub

		Protected Sub raise_MouseDownOccured()
			Dim mouseDownOccured As DropList.__Delegate_MouseDownOccured = Me.MouseDownOccured
			If mouseDownOccured IsNot Nothing Then
				mouseDownOccured()
			End If
		End Sub
	End Class
End Namespace
