Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace Script_ActionListTree_Node
	Public Class ActionListTreeControl_Node_TextElement
		Inherits Component

		Private mText As String

		Private mType As Integer

		Private Area As Rectangle

		Private mParamIndex As Integer

		Public ReadOnly Property Fixed() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return(If((Me.Type = 3), 1, 0)) <> 0
			End Get
		End Property

		Public ReadOnly Property Parameter() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return(If((Me.Type = 1), 1, 0)) <> 0
			End Get
		End Property

		Public ReadOnly Property Type() As Integer
			Get
				Return Me.mType
			End Get
		End Property

		Public Property Text() As String
			Get
				Return Me.mText
			End Get
			Set(value As String)
				Me.mText = value
			End Set
		End Property

		Public ReadOnly Property ParameterIndex() As Integer
			Get
				Return Me.mParamIndex
			End Get
		End Property

		Public Sub New(text As String, type As Integer, paramindex As Integer)
			Me.mText = text
			Me.mType = type
			Me.mParamIndex = paramindex
		End Sub

		Public Function GetArea() As __Pointer(Of Rectangle)
			Return Me.Area
		End Function

		Public Sub SetArea(area As __Pointer(Of Rectangle))
			Me.Area = __Dereference(area)
		End Sub
	End Class
End Namespace
