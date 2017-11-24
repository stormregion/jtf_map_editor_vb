Imports GRTTI
Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyItemEnum
		Inherits PropertyItem

		Protected dropList As DropList

		Protected Sub dropList_Enter(sender As Object, e As EventArgs)
		End Sub

		Protected Sub dropList_ChooseItem(index As Integer)
			If index >= 0 Then
				Me.SelectItem(index)
			End If
			If Me.IsDefault() Then
				Me.dropList.Font = New Font(Me.dropList.Font, FontStyle.Regular)
			Else
				Me.dropList.Font = New Font(Me.dropList.Font, FontStyle.Bold)
			End If
			Me.Host.Focus()
			Me.Host.InvalidateViewControl()
		End Sub

		Protected Sub dropList_MouseDown(__unnamed000 As Object, e As MouseEventArgs)
			Dim location As Point = Me.dropList.Location
			Dim host As PropertyTreeCore = Me.Host
			host.SelectedIndex = CInt((CDec((CSng(location.Y) / host.ItemHeight))))
			Me.Host.EnsureSelectedVisible()
			Me.Host.InvalidateViewControl()
		End Sub

		Protected Overridable Sub GetItems()
			Dim num As Integer = 0
			Dim num2 As Integer = __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer)))
			If __Dereference(num2) <> 0 Then
				Dim num3 As Integer = 0
				Do
					Me.dropList.Items.Add(New String(__Dereference((num3 + num2 + 4))))
					If __Dereference((num3 + __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer))) + 8)) = __Dereference(CType(Me.Var, __Pointer(Of Integer))) Then
						Me.dropList.SelectedIndex = num
					End If
					num += 1
					num3 = num * 12
					num2 = __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer)))
				Loop While __Dereference((num2 + num3)) <> 0
			End If
		End Sub

		Protected Overridable Sub SelectItem(index As Integer)
			Dim text As String = TryCast(Me.dropList.Items(index), String)
			Dim num As Integer = 0
			Dim num2 As Integer = __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer)))
			If __Dereference(num2) <> 0 Then
				Dim num3 As Integer = 0
				Do
					If text.CompareTo(New String(__Dereference((num3 + num2 + 4)))) = 0 Then
						Dim var As __Pointer(Of Void) = Me.Var
						Dim num4 As Integer = __Dereference((num3 + __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer))) + 8))
						If __Dereference(CType(var, __Pointer(Of Integer))) <> num4 Then
							__Dereference(CType(var, __Pointer(Of Integer))) = num4
							Me.Host.RaiseItemChanged()
							Me.Host.InvalidateViewControl()
						End If
					End If
					num += 1
					num3 = num * 12
					num2 = __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer)))
				Loop While __Dereference((num2 + num3)) <> 0
			End If
		End Sub

		Public Overrides Sub Refresh()
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer)))
			If __Dereference(num3) <> 0 Then
				Dim num4 As Integer = num3
				Dim num5 As Integer = __Dereference(CType(Me.Var, __Pointer(Of Integer)))
				While num5 <> __Dereference((num4 + 8))
					num2 += 1
					num4 = num3 + num2 * 12
					If __Dereference(num4) = 0 Then
						GoTo IL_3B
					End If
				End While
				num = num2
			End If
			IL_3B:
			Dim num6 As Integer = 0
			If 0 < Me.dropList.Items.Count Then
				Dim num7 As Integer = num * 12
				While (TryCast(Me.dropList.Items(num6), String)).CompareTo(New String(__Dereference((num7 + __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer))) + 4)))) <> 0
					num6 += 1
					If num6 >= Me.dropList.Items.Count Then
						GoTo IL_AE
					End If
				End While
				Me.dropList.SetSelection(num6)
			End If
			IL_AE:
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Function IsDefault() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return __Dereference(CType(Me.Var, __Pointer(Of Integer))) = CInt(Me.[Default])
		End Function

		Public Overrides Sub SetDefault()
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			Dim num3 As Integer = __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer)))
			If __Dereference(num3) <> 0 Then
				Dim num4 As Integer = num3
				Dim [default] As UInteger = Me.[Default]
				While [default] <> __Dereference((num4 + 8))
					num2 += 1
					num4 = num3 + num2 * 12
					If __Dereference(num4) = 0 Then
						GoTo IL_3A
					End If
				End While
				num = num2
			End If
			IL_3A:
			Dim num5 As Integer = 0
			If 0 < Me.dropList.Items.Count Then
				Dim num6 As Integer = num * 12
				While (TryCast(Me.dropList.Items(num5), String)).CompareTo(New String(__Dereference((num6 + __Dereference(CType((Me.Type + 24 / __SizeOf(GClass)), __Pointer(Of Integer))) + 4)))) <> 0
					num5 += 1
					If num5 >= Me.dropList.Items.Count Then
						Return
					End If
				End While
				Me.dropList.SetSelection(num5)
			End If
		End Sub

		Public Overrides Function HasDefaultOption() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return True
		End Function

		Public Overrides Sub UpdateControl(bounds As Rectangle)
			bounds.X -= 1
			bounds.Y += 1
			bounds.Height -= 1
			If Me.dropList IsNot Nothing Then
				Dim location As Point = bounds.Location
				Me.dropList.Location = location
				Dim size As Size = bounds.Size
				Me.dropList.Size = size
			Else
				Me.dropList = New DropList()
				Dim location2 As Point = bounds.Location
				Me.dropList.Location = location2
				Dim size2 As Size = bounds.Size
				Me.dropList.Size = size2
				Me.dropList.TabIndex = 1
				Me.GetItems()
				If Me.IsDefault() Then
					Me.dropList.Font = New Font(Me.dropList.Font, FontStyle.Regular)
				Else
					Me.dropList.Font = New Font(Me.dropList.Font, FontStyle.Bold)
				End If
				Me.Host.Controls.Add(Me.dropList)
				AddHandler Me.dropList.Enter, AddressOf Me.dropList_Enter
				AddHandler Me.dropList.ChooseItem, AddressOf Me.dropList_ChooseItem
				AddHandler Me.dropList.MouseDown, AddressOf Me.dropList_MouseDown
			End If
		End Sub

		Public Overrides Sub DestroyControl()
			If Me.dropList IsNot Nothing Then
				RemoveHandler Me.dropList.Enter, AddressOf Me.dropList_Enter
				RemoveHandler Me.dropList.ChooseItem, AddressOf Me.dropList_ChooseItem
				RemoveHandler Me.dropList.MouseDown, AddressOf Me.dropList_MouseDown
				Me.Host.Controls.Remove(Me.dropList)
				Me.dropList = Nothing
			End If
		End Sub

		Public Overrides Function OnEnterPressed() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim dropList As DropList = Me.dropList
			If dropList IsNot Nothing Then
				dropList.Focus()
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
