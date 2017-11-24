Imports System
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace ScriptEditorWindow
	Public Class InPlaceEditing_ListBox
		Inherits ListBox

		Public Custom Event SelectionCancel As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.SelectionCancel = [Delegate].Combine(Me.SelectionCancel, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.SelectionCancel = [Delegate].Remove(Me.SelectionCancel, value)
			End RemoveHandler
		End Event

		Public Custom Event SelectionReady As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.SelectionReady = [Delegate].Combine(Me.SelectionReady, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.SelectionReady = [Delegate].Remove(Me.SelectionReady, value)
			End RemoveHandler
		End Event

		Public Overrides ReadOnly Property CreateParams() As CreateParams
			Get
				Dim createParams As CreateParams = MyBase.CreateParams
				createParams.Style = -1868562432
				createParams.ExStyle = 0
				Return createParams
			End Get
		End Property

		Public Sub New()
			Me.SelectionReady = Nothing
			Me.SelectionCancel = Nothing
		End Sub

		Protected Overrides Sub Finalize()
			MyBase.Finalize()
		End Sub

		Public Overrides Sub OnMouseDown(e As MouseEventArgs)
			If e.X >= 0 Then
				Dim size As Size = MyBase.Size
				If e.X < size.Width AndAlso e.Y >= 0 Then
					Dim size2 As Size = MyBase.Size
					If e.Y < size2.Height Then
						Me.raise_SelectionReady(Me, New EventArgs())
						Return
					End If
				End If
			End If
			Me.raise_SelectionCancel(Me, New EventArgs())
		End Sub

		Public Overrides Sub OnKeyDown(e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.raise_SelectionReady(Me, New EventArgs())
			Else If e.KeyCode = Keys.Escape Then
				Me.raise_SelectionCancel(Me, New EventArgs())
			Else
				MyBase.OnKeyDown(e)
			End If
		End Sub

		Protected Sub raise_SelectionReady(i1 As Object, i2 As EventArgs)
			Dim selectionReady As EventHandler = Me.SelectionReady
			If selectionReady IsNot Nothing Then
				selectionReady(i1, i2)
			End If
		End Sub

		Protected Sub raise_SelectionCancel(i1 As Object, i2 As EventArgs)
			Dim selectionCancel As EventHandler = Me.SelectionCancel
			If selectionCancel IsNot Nothing Then
				selectionCancel(i1, i2)
			End If
		End Sub

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
