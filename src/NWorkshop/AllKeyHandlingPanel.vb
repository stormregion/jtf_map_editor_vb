Imports System
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Friend Class AllKeyHandlingPanel
		Inherits Panel

		Protected Overrides Function IsInputKey(keyData As Keys) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return True
		End Function
	End Class
End Namespace
