Imports System
Imports System.Runtime.InteropServices

Namespace NControls
	Public Class PropertyItemBoolean
		Inherits PropertyItemEnum

		Protected Overrides Sub GetItems()
			Me.dropList.Items.Add("True")
			Me.dropList.Items.Add("False")
			Dim selectedIndex As Integer = If((__Dereference(CType(Me.Var, __Pointer(Of Byte))) <> 0), 0, 1)
			Me.dropList.SelectedIndex = selectedIndex
		End Sub

		Protected Overrides Sub SelectItem(index As Integer)
			If(TryCast(Me.dropList.Items(index), String)).CompareTo("True") = 0 Then
				Dim var As __Pointer(Of Void) = Me.Var
				If __Dereference(CType(var, __Pointer(Of Byte))) <> 1 Then
					__Dereference(CType(var, __Pointer(Of Byte))) = 1
					Me.Host.RaiseItemChanged()
					Me.Host.InvalidateViewControl()
				End If
			Else
				Dim var As __Pointer(Of Void) = Me.Var
				If __Dereference(CType(var, __Pointer(Of Byte))) <> 0 Then
					__Dereference(CType(var, __Pointer(Of Byte))) = 0
					Me.Host.RaiseItemChanged()
					Me.Host.InvalidateViewControl()
				End If
			End If
		End Sub

		Public Overrides Sub Refresh()
			Dim num As Integer = 0
			If 0 < Me.dropList.Items.Count Then
				Do
					Dim text As String = TryCast(Me.dropList.Items(num), String)
					If text.CompareTo("True") = 0 AndAlso __Dereference(CType(Me.Var, __Pointer(Of Byte))) <> 0 Then
						GoTo IL_74
					End If
					If text.CompareTo("False") = 0 AndAlso __Dereference(CType(Me.Var, __Pointer(Of Byte))) = 0 Then
						GoTo IL_82
					End If
					num += 1
				Loop While num < Me.dropList.Items.Count
				GoTo IL_8E
				IL_74:
				Me.dropList.SetSelection(num)
				GoTo IL_8E
				IL_82:
				Me.dropList.SetSelection(num)
			End If
			IL_8E:
			Me.Host.RaiseItemChanged()
		End Sub

		Public Overrides Function IsDefault() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim b As Byte = If((Me.[Default] <> 0UI), 1, 0)
			Return __Dereference(CType(Me.Var, __Pointer(Of Byte))) = b
		End Function

		Public Overrides Sub SetDefault()
			Dim flag As Boolean = Me.[Default] <> 0UI
			Dim num As Integer = 0
			If 0 < Me.dropList.Items.Count Then
				Do
					Dim text As String = TryCast(Me.dropList.Items(num), String)
					If text.CompareTo("True") = 0 AndAlso flag Then
						GoTo IL_73
					End If
					If text.CompareTo("False") = 0 AndAlso Not flag Then
						GoTo IL_81
					End If
					num += 1
				Loop While num < Me.dropList.Items.Count
				Return
				IL_73:
				Me.dropList.SetSelection(num)
				Return
				IL_81:
				Me.dropList.SetSelection(num)
			End If
		End Sub

		Public Overrides Function HasDefaultOption() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return True
		End Function

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
