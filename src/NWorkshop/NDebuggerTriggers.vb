Imports Script
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NDebuggerTriggers
		Inherits UserControl

		Private components As Container

		Private TriggerList As ListView

		Private TriggerName As ColumnHeader

		Private Active As ColumnHeader

		Private [Event] As ColumnHeader

		Public Sub New()
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
			Me.TriggerList = New ListView()
			Me.TriggerName = New ColumnHeader()
			Me.[Event] = New ColumnHeader()
			Me.Active = New ColumnHeader()
			MyBase.SuspendLayout()
			Me.TriggerList.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim values As ColumnHeader() = New ColumnHeader() { Me.TriggerName, Me.[Event], Me.Active }
			Me.TriggerList.Columns.AddRange(values)
			Me.TriggerList.GridLines = True
			Dim location As Point = New Point(8, 8)
			Me.TriggerList.Location = location
			Me.TriggerList.Name = "TriggerList"
			Dim size As Size = New Size(232, 312)
			Me.TriggerList.Size = size
			Me.TriggerList.TabIndex = 0
			Me.TriggerList.View = View.Details
			AddHandler Me.TriggerList.Resize, AddressOf Me.TriggerList_Resize
			Me.TriggerName.Text = "Name"
			Me.TriggerName.Width = 116
			Me.[Event].Text = "Event"
			Me.[Event].Width = 69
			Me.Active.Text = "Active"
			Me.Active.Width = 43
			MyBase.Controls.Add(Me.TriggerList)
			MyBase.Name = "NDebuggerTriggers"
			Dim size2 As Size = New Size(248, 328)
			MyBase.Size = size2
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub Init(script As __Pointer(Of cScript))
			Dim gArray<Script::cTrigger *> As GArray<Script::cTrigger *>
			<Module>.GArray<Script::cTrigger *>.{ctor}(gArray<Script::cTrigger *>, script + 32 / __SizeOf(cScript))
			Try
				Me.TriggerList.Items.Clear()
				Dim num As Integer = 0
				If 0 < __Dereference((gArray<Script::cTrigger *> + 4)) Then
					Do
						Dim ptr As __Pointer(Of cTrigger) = __Dereference((num * 4 + gArray<Script::cTrigger *>))
						Dim num2 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
						Dim listViewItem As ListViewItem = New ListViewItem(New String(CType((If((num2 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num2)), __Pointer(Of SByte))))
						Dim num3 As Integer = __Dereference(CType((ptr + 8 / __SizeOf(cTrigger)), __Pointer(Of Integer)))
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.?GetEventTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eEvent_Type@Script@@@Z(AddressOf gBaseString<char>, num3)
						Try
							Dim num4 As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
							Dim value As __Pointer(Of SByte)
							If num4 <> 0UI Then
								value = num4
							Else
								value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							listViewItem.SubItems.Add(New String(CType(value, __Pointer(Of SByte))))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
						Dim b As Byte = __Dereference(CType((ptr + 28 / __SizeOf(cTrigger)), __Pointer(Of Byte)))
						Dim text As String
						If b <> 0 Then
							text = "yes"
						Else
							text = New String(CType((AddressOf <Module>.??_C@_02KAJCLHKP@no?$AA@), __Pointer(Of SByte)))
						End If
						listViewItem.SubItems.Add(text)
						Me.TriggerList.Items.Add(listViewItem)
						num += 1
					Loop While num < __Dereference((gArray<Script::cTrigger *> + 4))
				End If
				Me.TriggerList_Resize(Nothing, Nothing)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<Script::cTrigger *>.{dtor}), CType((AddressOf gArray<Script::cTrigger *>), __Pointer(Of Void)))
				Throw
			End Try
			If gArray<Script::cTrigger *> IsNot Nothing Then
				<Module>.free(gArray<Script::cTrigger *>)
			End If
		End Sub

		Public Sub Refresh(script As __Pointer(Of cScript))
			Dim gArray<Script::cTrigger *> As GArray<Script::cTrigger *>
			<Module>.GArray<Script::cTrigger *>.{ctor}(gArray<Script::cTrigger *>, script + 32 / __SizeOf(cScript))
			Try
				Dim num As Integer = 0
				If 0 < __Dereference((gArray<Script::cTrigger *> + 4)) Then
					Do
						Dim ptr As __Pointer(Of cTrigger) = __Dereference((num * 4 + gArray<Script::cTrigger *>))
						Dim listViewItem As ListViewItem = Me.TriggerList.Items(num)
						Dim num2 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
						Dim value As __Pointer(Of SByte)
						If num2 <> 0UI Then
							value = num2
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						listViewItem.Text = New String(CType(value, __Pointer(Of SByte)))
						Dim num3 As Integer = __Dereference(CType((ptr + 8 / __SizeOf(cTrigger)), __Pointer(Of Integer)))
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.?GetEventTypeAsString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eEvent_Type@Script@@@Z(AddressOf gBaseString<char>, num3)
						Try
							Dim num4 As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
							Dim value2 As __Pointer(Of SByte)
							If num4 <> 0UI Then
								value2 = num4
							Else
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							listViewItem.SubItems(1).Text = New String(CType(value2, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
							gBaseString<char> = 0
						End If
						Dim b As Byte = __Dereference(CType((ptr + 28 / __SizeOf(cTrigger)), __Pointer(Of Byte)))
						Dim text As String
						If b <> 0 Then
							text = "yes"
						Else
							text = New String(CType((AddressOf <Module>.??_C@_02KAJCLHKP@no?$AA@), __Pointer(Of SByte)))
						End If
						listViewItem.SubItems(2).Text = text
						num += 1
					Loop While num < __Dereference((gArray<Script::cTrigger *> + 4))
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<Script::cTrigger *>.{dtor}), CType((AddressOf gArray<Script::cTrigger *>), __Pointer(Of Void)))
				Throw
			End Try
			If gArray<Script::cTrigger *> IsNot Nothing Then
				<Module>.free(gArray<Script::cTrigger *>)
			End If
		End Sub

		Private Sub TriggerList_Resize(sender As Object, e As EventArgs)
			Dim num As Integer = Me.TriggerList.ClientSize.Width - Me.Active.Width
			Me.TriggerName.Width = num - Me.[Event].Width
		End Sub
	End Class
End Namespace
