Imports NControls
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxPlayer
		Inherits UserControl

		Public Delegate Sub __Delegate_PlayerChanged( As Integer)

		Public Delegate Sub __Delegate_EditPlayerProperties( As Integer)

		Private PlayersGrid As GridControl

		Private components As Container

		Public Custom Event EditPlayerProperties As ToolboxPlayer.__Delegate_EditPlayerProperties
			AddHandler
				Me.EditPlayerProperties = [Delegate].Combine(Me.EditPlayerProperties, value)
			End AddHandler
			RemoveHandler
				Me.EditPlayerProperties = [Delegate].Remove(Me.EditPlayerProperties, value)
			End RemoveHandler
		End Event

		Public Custom Event PlayerChanged As ToolboxPlayer.__Delegate_PlayerChanged
			AddHandler
				Me.PlayerChanged = [Delegate].Combine(Me.PlayerChanged, value)
			End AddHandler
			RemoveHandler
				Me.PlayerChanged = [Delegate].Remove(Me.PlayerChanged, value)
			End RemoveHandler
		End Event

		Public Sub New()
			Me.PlayerChanged = Nothing
			Me.EditPlayerProperties = Nothing
			Me.InitializeComponent()
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

		Private Sub InitializeComponent()
			MyBase.Name = "ToolboxPlayer"
			Dim size As Size = New Size(200, 236)
			MyBase.Size = size
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub InitPlayersGrid(world As __Pointer(Of GWorld))
			Dim arrayList As ArrayList = New ArrayList()
			arrayList.Add(New ColumnItem(New String(CType((AddressOf <Module>.??_C@_02JINPPBEP@No?$AA@), __Pointer(Of SByte))), 15))
			arrayList.Add(New ColumnItem(New String(CType((AddressOf <Module>.??_C@_07CEAHOFOL@Faction?$AA@), __Pointer(Of SByte))), 50))
			arrayList.Add(New ColumnItem(New String(CType((AddressOf <Module>.??_C@_07DFGIDBBA@Control?$AA@), __Pointer(Of SByte))), 50))
			arrayList.Add(New ColumnItem(New String(CType((AddressOf <Module>.??_C@_04GBPANCCF@Team?$AA@), __Pointer(Of SByte))), 20))
			arrayList.Add(New ColumnItem(New String(CType((AddressOf <Module>.??_C@_05PDOBBJNA@Color?$AA@), __Pointer(Of SByte))), 20))
			If Me.PlayersGrid Is Nothing Then
				Dim gridControl As GridControl = New GridControl(200, 236, arrayList, 0)
				Me.PlayersGrid = gridControl
				gridControl.Dock = DockStyle.Fill
				Me.PlayersGrid.SelectedIndex = 0
				AddHandler Me.PlayersGrid.ChooseItem, AddressOf Me.PlayersGridChooseItem
				AddHandler Me.PlayersGrid.DoubleClickItem, AddressOf Me.PlayersGridDoubleClickItem
				MyBase.Controls.Add(Me.PlayersGrid)
			End If
			Me.InitItems(world)
		End Sub

		Public Sub RemovePlayersGrid()
			MyBase.Controls.Remove(Me.PlayersGrid)
		End Sub

		Public Sub InitItems(world As __Pointer(Of GWorld))
			Dim value As String = Nothing
			If Me.PlayersGrid.Items.Count > 0 Then
				Me.PlayersGrid.Items.Clear()
			End If
			Dim num As Integer = 0
			Do
				Dim ptr As __Pointer(Of GPlayer) = <Module>.GWorld.GetPlayer(world, num)
				Dim arrayList As ArrayList = New ArrayList()
				arrayList.Add(String.Format("{0}", num + 1))
				Select Case __Dereference(CType((ptr + 4 / __SizeOf(GPlayer)), __Pointer(Of Integer)))
					Case 0
						value = New String(CType((AddressOf <Module>.??_C@_05IHOOPELI@Iraqi?$AA@), __Pointer(Of SByte)))
					Case 1
						value = New String(CType((AddressOf <Module>.??_C@_03OHIEPGFF@JTF?$AA@), __Pointer(Of SByte)))
					Case 2
						value = New String(CType((AddressOf <Module>.??_C@_07NDGKDAPO@Bosnian?$AA@), __Pointer(Of SByte)))
					Case 3
						value = New String(CType((AddressOf <Module>.??_C@_08NKKMBANE@Somalian?$AA@), __Pointer(Of SByte)))
					Case 4
						value = New String(CType((AddressOf <Module>.??_C@_09LDEFILLJ@Colombian?$AA@), __Pointer(Of SByte)))
					Case 5
						value = New String(CType((AddressOf <Module>.??_C@_06DJKJCBIE@Afghan?$AA@), __Pointer(Of SByte)))
				End Select
				arrayList.Add(value)
				Select Case __Dereference(CType((ptr + 8 / __SizeOf(GPlayer)), __Pointer(Of Integer)))
					Case 0
						value = New String(CType((AddressOf <Module>.??_C@_05OHCDHBAC@Human?$AA@), __Pointer(Of SByte)))
					Case 1
						value = New String(CType((AddressOf <Module>.??_C@_08JABLAMKL@Computer?$AA@), __Pointer(Of SByte)))
					Case 2
						value = New String(CType((AddressOf <Module>.??_C@_07GJJCKENN@Neutral?$AA@), __Pointer(Of SByte)))
					Case 3
						value = New String(CType((AddressOf <Module>.??_C@_09BIDEJFLN@Rescuable?$AA@), __Pointer(Of SByte)))
					Case 4
						value = New String(CType((AddressOf <Module>.??_C@_03KNAPCKEA@Spy?$AA@), __Pointer(Of SByte)))
					Case 5
						value = New String(CType((AddressOf <Module>.??_C@_05JDMJBIOG@Civil?$AA@), __Pointer(Of SByte)))
				End Select
				arrayList.Add(value)
				arrayList.Add(String.Format("{0}", __Dereference(CType((ptr + 16 / __SizeOf(GPlayer)), __Pointer(Of Integer)))))
				arrayList.Add(String.Format("{0}", __Dereference(CType(ptr, __Pointer(Of Integer)))))
				Me.PlayersGrid.Items.Add(arrayList)
				num += 1
			Loop While num < 12
			Me.PlayersGrid.UpdateViewHeight()
		End Sub

		Private Sub PlayersGridChooseItem(index As Integer)
			Me.raise_PlayerChanged(index)
		End Sub

		Private Sub PlayersGridDoubleClickItem(index As Integer)
			Me.raise_EditPlayerProperties(index)
		End Sub

		Protected Sub raise_PlayerChanged(i1 As Integer)
			Dim playerChanged As ToolboxPlayer.__Delegate_PlayerChanged = Me.PlayerChanged
			If playerChanged IsNot Nothing Then
				playerChanged(i1)
			End If
		End Sub

		Protected Sub raise_EditPlayerProperties(i1 As Integer)
			Dim editPlayerProperties As ToolboxPlayer.__Delegate_EditPlayerProperties = Me.EditPlayerProperties
			If editPlayerProperties IsNot Nothing Then
				editPlayerProperties(i1)
			End If
		End Sub
	End Class
End Namespace
