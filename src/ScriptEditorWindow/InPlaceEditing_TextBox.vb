Imports System
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace ScriptEditorWindow
	Public Class InPlaceEditing_TextBox
		Inherits TextBox

		Public Custom Event EditingCancel As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.EditingCancel = [Delegate].Combine(Me.EditingCancel, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.EditingCancel = [Delegate].Remove(Me.EditingCancel, value)
			End RemoveHandler
		End Event

		Public Custom Event EditingReady As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.EditingReady = [Delegate].Combine(Me.EditingReady, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.EditingReady = [Delegate].Remove(Me.EditingReady, value)
			End RemoveHandler
		End Event

		Public Overrides ReadOnly Property CreateParams() As CreateParams
			Get
				Dim createParams As CreateParams = MyBase.CreateParams
				createParams.Style = -1870659584
				createParams.ExStyle = 0
				Return createParams
			End Get
		End Property

		Public Sub New()
			Me.EditingReady = Nothing
			Me.EditingCancel = Nothing
			Me.Multiline = False
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
						Return
					End If
				End If
			End If
			Me.raise_EditingCancel(Me, New EventArgs())
		End Sub

		Public Overrides Sub OnKeyDown(e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.raise_EditingReady(Me, New EventArgs())
			Else If e.KeyCode = Keys.Escape Then
				Me.raise_EditingCancel(Me, New EventArgs())
			Else
				MyBase.OnKeyDown(e)
			End If
		End Sub

		Protected Sub raise_EditingReady(i1 As Object, i2 As EventArgs)
			Dim editingReady As EventHandler = Me.EditingReady
			If editingReady IsNot Nothing Then
				editingReady(i1, i2)
			End If
		End Sub

		Protected Sub raise_EditingCancel(i1 As Object, i2 As EventArgs)
			Dim editingCancel As EventHandler = Me.EditingCancel
			If editingCancel IsNot Nothing Then
				editingCancel(i1, i2)
			End If
		End Sub

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
