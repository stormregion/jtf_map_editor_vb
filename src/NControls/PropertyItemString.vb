Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyItemString
		Inherits PropertyItem

		Protected EditControl As TextBox

		Protected Sub EditControl_Enter(sender As Object, e As EventArgs)
		End Sub

		Protected Sub EditControl_KeyDown(sender As Object, e As KeyEventArgs)
			If e.KeyCode = Keys.[Return] Then
				Me.Host.Focus()
				Me.Host.InvalidateViewControl()
				e.Handled = True
			Else If e.KeyCode = Keys.Escape Then
				Me.EditControl.Text = Me.GetValue()
				Me.EditControl.SelectionLength = 0
				Me.Host.Focus()
				Me.Host.InvalidateViewControl()
				e.Handled = True
			End If
		End Sub

		Protected Sub EditControl_Validated(sender As Object, e As EventArgs)
			Me.SetValue(Me.EditControl.Text)
			Me.EditControl.Text = Me.GetValue()
			If Me.IsDefault() Then
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Bold)
			Else
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Regular)
			End If
			Me.EditControl.SelectionLength = 0
		End Sub

		Protected Sub EditControl_MouseDown(__unnamed000 As Object, e As MouseEventArgs)
			Dim location As Point = Me.EditControl.Location
			Dim host As PropertyTreeCore = Me.Host
			host.SelectedIndex = CInt((CDec((CSng(location.Y) / host.ItemHeight))))
			Me.Host.EnsureSelectedVisible()
		End Sub

		Protected Overridable Function GetValue() As String
			Dim num As UInteger = CUInt((__Dereference(CType(Me.Var, __Pointer(Of Integer)))))
			Return New String(CType((If((num = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num)), __Pointer(Of SByte)))
		End Function

		Protected Overridable Sub SetValue(value As String)
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, value)
			Dim flag As Boolean
			Try
				flag = ((If((<Module>.GBaseString<char>.Compare(Me.Var, ptr, False) <> 0), 1, 0)) <> 0)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			If flag Then
				<Module>.GBaseString<char>.=(Me.Var, value)
				Me.Host.RaiseItemChanged()
			End If
		End Sub

		Public Overrides Sub Refresh()
			Me.EditControl.Text = Me.GetValue()
			If Me.IsDefault() Then
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Bold)
			Else
				Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Regular)
			End If
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Sub UpdateControl(bounds As Rectangle)
			bounds.X += 2
			bounds.Y += 2
			bounds.Width -= 4
			bounds.Height -= 4
			If Me.EditControl IsNot Nothing Then
				Dim location As Point = bounds.Location
				Me.EditControl.Location = location
				Dim size As Size = bounds.Size
				Me.EditControl.Size = size
			Else
				Dim textBox As TextBox = New TextBox()
				Me.EditControl = textBox
				textBox.BorderStyle = BorderStyle.None
				Dim location2 As Point = bounds.Location
				Me.EditControl.Location = location2
				Dim size2 As Size = bounds.Size
				Me.EditControl.Size = size2
				Me.EditControl.TabIndex = 1
				Me.EditControl.Text = Me.GetValue()
				Me.EditControl.SelectionLength = 0
				If Me.IsDefault() Then
					Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Bold)
				Else
					Me.EditControl.Font = New Font(Me.EditControl.Font, FontStyle.Regular)
				End If
				Me.Host.Controls.Add(Me.EditControl)
				AddHandler Me.EditControl.Enter, AddressOf Me.EditControl_Enter
				AddHandler Me.EditControl.KeyDown, AddressOf Me.EditControl_KeyDown
				AddHandler Me.EditControl.Validated, AddressOf Me.EditControl_Validated
				AddHandler Me.EditControl.MouseDown, AddressOf Me.EditControl_MouseDown
			End If
		End Sub

		Public Overrides Sub DestroyControl()
			If Me.EditControl IsNot Nothing Then
				RemoveHandler Me.EditControl.Enter, AddressOf Me.EditControl_Enter
				RemoveHandler Me.EditControl.KeyDown, AddressOf Me.EditControl_KeyDown
				RemoveHandler Me.EditControl.Validated, AddressOf Me.EditControl_Validated
				RemoveHandler Me.EditControl.MouseDown, AddressOf Me.EditControl_MouseDown
				Me.Host.Controls.Remove(Me.EditControl)
				Me.EditControl = Nothing
			End If
		End Sub

		Public Overrides Function OnEnterPressed() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim editControl As TextBox = Me.EditControl
			If editControl IsNot Nothing Then
				editControl.Focus()
				Me.EditControl.SelectionLength = 0
			End If
			Me.Host.InvalidateViewControl()
			Return True
		End Function

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
