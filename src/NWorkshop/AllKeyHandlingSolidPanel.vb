Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Friend Class AllKeyHandlingSolidPanel
		Inherits Panel

		Public Sub New()
			MyBase.SetStyle(ControlStyles.Opaque, True)
		End Sub

		Protected Overrides Function IsInputKey(keyData As Keys) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return True
		End Function
	End Class
End Namespace
