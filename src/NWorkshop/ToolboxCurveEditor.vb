Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxCurveEditor
		Inherits Form

		Private curveeditor As NCurveEditor

		Private propWorld As __Pointer(Of GEditorWorld)

		Private FormCaption As __Pointer(Of GBaseString<char>)

		Private MinValue As Single

		Private MaxValue As Single

		Private CurveType As Integer

		Private CurveIndex As Integer

		Private components As Container

		Public Sub New(curvetype As Integer, curveindex As Integer, world As __Pointer(Of GEditorWorld), caption As __Pointer(Of GBaseString<char>), minvalue As Single, maxvalue As Single)
			Me.propWorld = world
			Me.CurveType = curvetype
			Me.CurveIndex = curveindex
			Me.FormCaption = caption
			Me.MinValue = minvalue
			Me.MaxValue = maxvalue
			Me.InitializeComponent()
			Me.CreateCurveEditor()
			Dim num As UInteger = CUInt((__Dereference(CType(Me.FormCaption, __Pointer(Of Integer)))))
			Dim value As __Pointer(Of SByte)
			If num <> 0UI Then
				value = num
			Else
				value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
			End If
			Me.Text = New String(CType(value, __Pointer(Of SByte)))
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing Then
				Dim container As Container = Me.components
				If container IsNot Nothing Then
					container.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub CreateCurveEditor()
			Dim gKeyLimit As GKeyLimit = 1F
			__Dereference((gKeyLimit + 4)) = Me.MinValue
			__Dereference((gKeyLimit + 8)) = Me.MaxValue
			Dim curveType As Integer = Me.CurveType
			If curveType <> 0 Then
				If curveType <> 1 Then
					If curveType = 2 Then
						Me.curveeditor = New NCurveEditor(<Module>.GEditorWorld.GetCameraCurveRollCurve(Me.propWorld, Me.CurveIndex), gKeyLimit)
					End If
				Else
					Me.curveeditor = New NCurveEditor(<Module>.GEditorWorld.GetCameraCurveFOVCurve(Me.propWorld, Me.CurveIndex), gKeyLimit)
				End If
			Else
				Me.curveeditor = New NCurveEditor(<Module>.GEditorWorld.GetCameraCurveTimeCurve(Me.propWorld, Me.CurveIndex), gKeyLimit)
			End If
			MyBase.SuspendLayout()
			MyBase.Controls.Add(Me.curveeditor)
			MyBase.ResumeLayout(False)
			Me.curveeditor.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
		End Sub

		Private Sub InitializeComponent()
			Dim autoScaleBaseSize As Size = New Size(5, 13)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			Dim clientSize As Size = New Size(650, 500)
			MyBase.ClientSize = clientSize
			MyBase.Name = "ToolboxCurveEditor"
		End Sub
	End Class
End Namespace
