Imports System

Namespace NControls
	Public Class PropertyItemWString
		Inherits PropertyItemString

		Protected Overrides Function GetValue() As String
			Dim num As UInteger = CUInt((__Dereference(CType(Me.Var, __Pointer(Of Integer)))))
			Return New String(CType((If((num = 0UI), <Module>.?EmptyString@?$GBaseString@_W@@1PB_WB, num)), __Pointer(Of Char)))
		End Function

		Protected Overrides Sub SetValue(value As String)
			Dim gBaseString<wchar_t> As GBaseString<wchar_t>
			Dim ptr As __Pointer(Of GBaseString<wchar_t>) = <Module>.GBaseString<wchar_t>.{ctor}(gBaseString<wchar_t>, value)
			Dim flag As Boolean
			Try
				flag = ((If((<Module>.GBaseString<wchar_t>.Compare(Me.Var, ptr, False) <> 0), 1, 0)) <> 0)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<wchar_t>.{dtor}), CType((AddressOf gBaseString<wchar_t>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<wchar_t> IsNot Nothing Then
				<Module>.free(gBaseString<wchar_t>)
			End If
			If flag Then
				<Module>.GBaseString<wchar_t>.=(Me.Var, value)
				Me.Host.RaiseItemChanged()
			End If
		End Sub

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
