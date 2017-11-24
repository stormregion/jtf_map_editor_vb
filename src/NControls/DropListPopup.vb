Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace NControls
	Public Class DropListPopup
		Inherits ListBox

		Public Delegate Sub __Delegate_ChooseItem( As Integer)

		Public Custom Event ChooseItem As DropListPopup.__Delegate_ChooseItem
			AddHandler
				Me.ChooseItem = [Delegate].Combine(Me.ChooseItem, value)
			End AddHandler
			RemoveHandler
				Me.ChooseItem = [Delegate].Remove(Me.ChooseItem, value)
			End RemoveHandler
		End Event

		Protected Overrides ReadOnly Property CreateParams() As CreateParams
			Get
				Dim createParams As CreateParams = MyBase.CreateParams
				createParams.Style = -1868562432
				createParams.ExStyle = 0
				Return createParams
			End Get
		End Property

		Public Sub New()
			Me.ChooseItem = Nothing
			Me.DrawMode = DrawMode.OwnerDrawFixed
			Me.ItemHeight += 2
		End Sub

		Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
			Me.raise_ChooseItem(Me.SelectedIndex)
		End Sub

		Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
			If e.X >= 0 Then
				Dim size As Size = MyBase.Size
				If e.X < size.Width AndAlso e.Y >= 0 Then
					Dim size2 As Size = MyBase.Size
					If e.Y < size2.Height Then
						Return
					End If
				End If
			End If
			Me.raise_ChooseItem(-1)
		End Sub

		Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.raise_ChooseItem(Me.SelectedIndex)
			Else If e.KeyCode = Keys.Escape Then
				Me.raise_ChooseItem(-1)
			Else
				MyBase.OnKeyDown(e)
			End If
		End Sub

		Protected Sub raise_ChooseItem(i1 As Integer)
			Dim chooseItem As DropListPopup.__Delegate_ChooseItem = Me.ChooseItem
			If chooseItem IsNot Nothing Then
				chooseItem(i1)
			End If
		End Sub
	End Class
End Namespace
