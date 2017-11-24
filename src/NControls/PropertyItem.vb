Imports GRTTI
Imports System
Imports System.Collections
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyItem
		Public Delegate Sub ListOpHandler(arrayidx As Integer)

		Public Delegate Sub CopyPasteHandler(item As PropertyItem)

		Public Delegate Sub __Delegate_ItemChanged()

		Protected Name As String

		Protected Type As __Pointer(Of GClass)

		Protected Var As __Pointer(Of Void)

		Protected ParentType As __Pointer(Of GClass)

		Protected ParentVar As __Pointer(Of Void)

		Protected Description As String

		Protected [Default] As UInteger

		Protected Minimum As UInteger

		Protected Maximum As UInteger

		Protected [Step] As UInteger

		Protected MeasureString As String

		Protected DefaultMenu As ContextMenu

		Protected EditMenu As ContextMenu

		Public Index As Integer

		Public ArrayIndex As Integer

		Public IndentDepth As Integer

		Public Host As PropertyTreeCore

		Public Expanded As Boolean

		Public Custom Event ItemChanged As PropertyItem.__Delegate_ItemChanged
			AddHandler
				Me.ItemChanged = [Delegate].Combine(Me.ItemChanged, value)
			End AddHandler
			RemoveHandler
				Me.ItemChanged = [Delegate].Remove(Me.ItemChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event Paste As PropertyItem.CopyPasteHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Paste = [Delegate].Combine(Me.Paste, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Paste = [Delegate].Remove(Me.Paste, value)
			End RemoveHandler
		End Event

		Public Custom Event Copy As PropertyItem.CopyPasteHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Copy = [Delegate].Combine(Me.Copy, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Copy = [Delegate].Remove(Me.Copy, value)
			End RemoveHandler
		End Event

		Public Custom Event MoveDown As PropertyItem.ListOpHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.MoveDown = [Delegate].Combine(Me.MoveDown, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.MoveDown = [Delegate].Remove(Me.MoveDown, value)
			End RemoveHandler
		End Event

		Public Custom Event MoveUp As PropertyItem.ListOpHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.MoveUp = [Delegate].Combine(Me.MoveUp, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.MoveUp = [Delegate].Remove(Me.MoveUp, value)
			End RemoveHandler
		End Event

		Public Custom Event Insert As PropertyItem.ListOpHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Insert = [Delegate].Combine(Me.Insert, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Insert = [Delegate].Remove(Me.Insert, value)
			End RemoveHandler
		End Event

		Public Custom Event Remove As PropertyItem.ListOpHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Remove = [Delegate].Combine(Me.Remove, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Remove = [Delegate].Remove(Me.Remove, value)
			End RemoveHandler
		End Event

		Public Sub New()
			Me.ItemChanged = Nothing
			Me.Remove = Nothing
			Me.Insert = Nothing
			Me.MoveUp = Nothing
			Me.MoveDown = Nothing
			Me.Copy = Nothing
			Me.Paste = Nothing
			Me.DefaultMenu = New ContextMenu()
			Dim menuItem As MenuItem = New MenuItem("Reset to default")
			AddHandler menuItem.Click, AddressOf Me.OnDefault
			Me.DefaultMenu.MenuItems.Add(menuItem)
			If Me.HasDefaultOption() Then
				menuItem.Enabled = True
			Else
				menuItem.Enabled = False
			End If
			Me.EditMenu = New ContextMenu()
			Dim menuItem2 As MenuItem = New MenuItem("Copy")
			AddHandler menuItem2.Click, AddressOf Me.OnCopy
			Me.EditMenu.MenuItems.Add(menuItem2)
			Dim menuItem3 As MenuItem = New MenuItem("Paste")
			AddHandler menuItem3.Click, AddressOf Me.OnPaste
			Me.EditMenu.MenuItems.Add(menuItem3)
		End Sub

		Public Function IdentifyType() As Integer
			Return __Dereference(CType(Me.Type, __Pointer(Of Integer)))
		End Function

		Public Sub SaveToBuffer(st As __Pointer(Of GStream))
			<Module>.GRTTI.SaveVariablesAsText(st, Me.Type, Me.Var, <Module>.Measures)
		End Sub

		Public Sub LoadFromBuffer(st As __Pointer(Of GStream))
			<Module>.GRTTI.LoadVariablesAsText(st, Me.Type, Me.Var, <Module>.Measures)
		End Sub

		Public Overridable Sub Refresh()
		End Sub

		Public Overridable Sub UpdateControl(bounds As Rectangle)
		End Sub

		Public Overridable Sub DestroyControl()
		End Sub

		Public Overridable Function OnEnterPressed() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return False
		End Function

		Public Overridable Function CanBeExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return False
		End Function

		Public Overridable Function ShouldBeExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return Me.CanBeExpanded()
		End Function

		Public Function IsExpanded() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return Me.Expanded
		End Function

		Public Overridable Function Expand() As ArrayList
			Return Nothing
		End Function

		Protected Overrides Sub Finalize()
			Me.DestroyControl()
		End Sub

		Public Overridable Function GetName() As String
			Return Me.Name
		End Function

		Public Overridable Function GetNameWithMeasure() As String
			Return Me.GetName() + " " + Me.MeasureString
		End Function

		Public Overridable Function GetDescription() As String
			Return Me.Description
		End Function

		Public Overridable Function IsDefault() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return False
		End Function

		Public Overridable Function HasDefaultOption() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return False
		End Function

		Public Function GetContextMenu() As Menu
			Return Me.DefaultMenu
		End Function

		Public Function GetEditContextMenu() As Menu
			Return Me.EditMenu
		End Function

		Public Sub OnDefault(sender As Object, e As EventArgs)
			Me.SetDefault()
		End Sub

		Public Sub OnCopy(sender As Object, e As EventArgs)
			Dim copy As PropertyItem.CopyPasteHandler = Me.Copy
			If copy IsNot Nothing Then
				copy(Me)
			End If
		End Sub

		Public Sub OnPaste(sender As Object, e As EventArgs)
			Dim paste As PropertyItem.CopyPasteHandler = Me.Paste
			If paste IsNot Nothing Then
				paste(Me)
			End If
		End Sub

		Public Sub InjectMenu(menuitem As MenuItem)
			Me.DefaultMenu.MenuItems.Add(menuitem)
		End Sub

		Public Overridable Sub SetDefault()
		End Sub

		Public Sub OnInsert(sender As Object, e As EventArgs)
			Dim insert As PropertyItem.ListOpHandler = Me.Insert
			If insert IsNot Nothing Then
				insert(Me.ArrayIndex)
			End If
		End Sub

		Public Sub OnRemove(sender As Object, e As EventArgs)
			Dim remove As PropertyItem.ListOpHandler = Me.Remove
			If remove IsNot Nothing Then
				remove(Me.ArrayIndex)
			End If
		End Sub

		Public Sub OnMoveUp(sender As Object, e As EventArgs)
			Dim moveUp As PropertyItem.ListOpHandler = Me.MoveUp
			If moveUp IsNot Nothing Then
				moveUp(Me.ArrayIndex)
			End If
		End Sub

		Public Sub OnMoveDown(sender As Object, e As EventArgs)
			Dim moveDown As PropertyItem.ListOpHandler = Me.MoveDown
			If moveDown IsNot Nothing Then
				moveDown(Me.ArrayIndex)
			End If
		End Sub

		Public Shared Function MakeProperty(name As String, description As __Pointer(Of SByte), type As __Pointer(Of GClass), var As __Pointer(Of Void), default_value As UInteger, min_value As UInteger, max_value As UInteger, step_value As UInteger) As PropertyItem
			Dim propertyItem As PropertyItem
			Select Case __Dereference(CType(type, __Pointer(Of Integer)))
				Case 1
					propertyItem = New PropertyItemBoolean()
				Case 2
					propertyItem = New PropertyItemInteger(CLng(default_value), CLng(min_value), CLng(max_value), CLng(step_value))
				Case 3
					propertyItem = New PropertyItemInteger(CLng(default_value), CLng(min_value), CLng(max_value), CLng(step_value))
				Case 4
					propertyItem = New PropertyItemInteger(CLng(default_value), CLng(min_value), CLng(max_value), CLng(step_value))
				Case 5
					propertyItem = New PropertyItemInteger(CLng(default_value), CLng(min_value), CLng(max_value), CLng(step_value))
				Case 6
					propertyItem = New PropertyItemInteger(default_value, min_value, max_value, step_value)
				Case 7
					propertyItem = New PropertyItemInteger(CLng(default_value), CLng(min_value), CLng(max_value), CLng(step_value))
				Case 8
					propertyItem = New PropertyItemFloat(default_value, min_value, max_value, step_value)
				Case 9
					propertyItem = New PropertyItemFloat(default_value, min_value, max_value, step_value)
					propertyItem.MeasureString = "<m>"
				Case 10
					propertyItem = New PropertyItemFloat(default_value, min_value, max_value, step_value)
					propertyItem.MeasureString = "<cm>"
				Case 11
					propertyItem = New PropertyItemFloat(default_value, min_value, max_value, step_value)
					propertyItem.MeasureString = "<s>"
				Case 12
					propertyItem = New PropertyItemFloat(default_value, min_value, max_value, step_value)
					propertyItem.MeasureString = "<km/h>"
				Case 13
					propertyItem = New PropertyItemFloat(default_value, min_value, max_value, step_value)
					propertyItem.MeasureString = "<deg>"
				Case 14
					propertyItem = New PropertyItemFloat(default_value, min_value, max_value, step_value)
					propertyItem.MeasureString = "<deg/s>"
				Case 15
					propertyItem = New PropertyItemFloat(default_value, min_value, max_value, step_value)
				Case 16, 17, 19, 20, 22
					propertyItem = New PropertyItemVector()
				Case 18, 21, 23, 24
					GoTo IL_3EC
				Case 25
					propertyItem = New PropertyItemString()
				Case 26
					propertyItem = New PropertyItemWString()
				Case 27
					propertyItem = New PropertyItemFileName(27)
				Case 28
					propertyItem = New PropertyItemFileName(28)
				Case 29
					propertyItem = New PropertyItemFileName(29)
				Case 30
					propertyItem = New PropertyItemFileName(30)
				Case 31
					propertyItem = New PropertyItemFileName(31)
				Case 32
					propertyItem = New PropertyItemFileName(32)
				Case 33
					propertyItem = New PropertyItemFileName(33)
				Case 34
					propertyItem = New PropertyItemFileName(34)
				Case 35
					propertyItem = New PropertyItemFileName(35)
				Case 36
					propertyItem = New PropertyItemFileName(36)
				Case 37
					propertyItem = New PropertyItemFileName(37)
				Case 38
					propertyItem = New PropertyItemStruct()
				Case 39
					propertyItem = New PropertyItemEnum()
				Case 40
					Dim num As Integer = __Dereference(CType((type + 52 / __SizeOf(GClass)), __Pointer(Of Integer)))
					If __Dereference(num) <> 38 Then
						<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 133, CType((AddressOf <Module>.??_C@_0CG@JPCBOHFL@NControls?3?3PropertyItem?3?3MakePro@), __Pointer(Of SByte)))
						<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0DE@GGGDDGPM@Pointer?5is?5only?5supported?5with?5s@), __Pointer(Of SByte)))
					End If
					Dim ptr As __Pointer(Of SByte) = <Module>.??_C@_0O@DPNPBEBH@GPCurveScalar?$AA@
					Dim num2 As Integer = __Dereference((num + 4))
					Dim b As SByte = __Dereference(num2)
					Dim b2 As SByte = 71
					If b >= 71 Then
						While b <= b2
							If b = 0 Then
								propertyItem = New PropertyItemScalarTrack()
								GoTo IL_396
							End If
							num2 += 1
							ptr += 1
							b = __Dereference(num2)
							b2 = __Dereference(ptr)
							If b < b2 Then
								Exit While
							End If
						End While
					End If
					propertyItem = New PropertyItemPointerTo()
				Case 41
					propertyItem = New PropertyItemArray()
				Case 42
					propertyItem = New PropertyItemDArray()
				Case Else
					GoTo IL_3EC
			End Select
			IL_396:
			propertyItem.Name = name
			propertyItem.Description = New String(CType(description, __Pointer(Of SByte)))
			propertyItem.Type = type
			propertyItem.Var = var
			propertyItem.[Default] = default_value
			propertyItem.Minimum = min_value
			propertyItem.Maximum = max_value
			propertyItem.[Step] = step_value
			If propertyItem.MeasureString Is Nothing Then
				propertyItem.MeasureString = ""
			End If
			Return propertyItem
			IL_3EC:
			<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CB@CCMFIMID@?4?2controls?2PropertyTreeItems?4cpp@), __Pointer(Of SByte)), 141, CType((AddressOf <Module>.??_C@_0CG@JPCBOHFL@NControls?3?3PropertyItem?3?3MakePro@), __Pointer(Of SByte)))
			<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BB@FMKGMNNA@Unsupported?5type?$AA@), __Pointer(Of SByte)))
			Return Nothing
		End Function

		Protected Sub raise_ItemChanged()
			Dim itemChanged As PropertyItem.__Delegate_ItemChanged = Me.ItemChanged
			If itemChanged IsNot Nothing Then
				itemChanged()
			End If
		End Sub

		Protected Sub raise_Remove(i1 As Integer)
			Dim remove As PropertyItem.ListOpHandler = Me.Remove
			If remove IsNot Nothing Then
				remove(i1)
			End If
		End Sub

		Protected Sub raise_Insert(i1 As Integer)
			Dim insert As PropertyItem.ListOpHandler = Me.Insert
			If insert IsNot Nothing Then
				insert(i1)
			End If
		End Sub

		Protected Sub raise_MoveUp(i1 As Integer)
			Dim moveUp As PropertyItem.ListOpHandler = Me.MoveUp
			If moveUp IsNot Nothing Then
				moveUp(i1)
			End If
		End Sub

		Protected Sub raise_MoveDown(i1 As Integer)
			Dim moveDown As PropertyItem.ListOpHandler = Me.MoveDown
			If moveDown IsNot Nothing Then
				moveDown(i1)
			End If
		End Sub

		Protected Sub raise_Copy(i1 As PropertyItem)
			Dim copy As PropertyItem.CopyPasteHandler = Me.Copy
			If copy IsNot Nothing Then
				copy(i1)
			End If
		End Sub

		Protected Sub raise_Paste(i1 As PropertyItem)
			Dim paste As PropertyItem.CopyPasteHandler = Me.Paste
			If paste IsNot Nothing Then
				paste(i1)
			End If
		End Sub

		Public Sub {dtor}()
			GC.SuppressFinalize(Me)
			Me.Finalize()
		End Sub
	End Class
End Namespace
