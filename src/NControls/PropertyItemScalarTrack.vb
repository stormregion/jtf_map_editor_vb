Imports NWorkshop
Imports System

Namespace NControls
	Public Class PropertyItemScalarTrack
		Inherits PropertyItemFloat

		Protected CurveEditor As NCurveEditor

		Protected Overrides Function GetValue() As Double
			Dim num As Single = __Dereference((__Dereference((__Dereference(CType(Me.Var, __Pointer(Of Integer))) + 12)) + 4))
			Return CDec(num)
		End Function

		Protected Overrides Sub SetValue(value As Double)
		End Sub

		Public Sub New()
			Try
				Me.LowerBound = 1.17549435E-38F
				Me.UpperBound = 3.40282347E+38F
				Me.StepValue = 0.5F
				Me.DefaultValue = 0F
			Catch 
				MyBase.{dtor}()
				Throw
			End Try
		End Sub

		Public Function GetTrackEditor() As NCurveEditor
			Dim nCurveEditor As NCurveEditor = New NCurveEditor(__Dereference(CType(Me.Var, __Pointer(Of Integer))))
			Me.CurveEditor = nCurveEditor
			Return nCurveEditor
		End Function

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
