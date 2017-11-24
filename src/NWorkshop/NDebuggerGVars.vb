Imports Script
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NDebuggerGVars
		Inherits UserControl

		Private components As Container

		Private GVarList As ListView

		Private GVarName As ColumnHeader

		Private GVarType As ColumnHeader

		Private GVarValue As ColumnHeader

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
			Me.GVarList = New ListView()
			Me.GVarName = New ColumnHeader()
			Me.GVarType = New ColumnHeader()
			Me.GVarValue = New ColumnHeader()
			MyBase.SuspendLayout()
			Me.GVarList.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim values As ColumnHeader() = New ColumnHeader() { Me.GVarName, Me.GVarType, Me.GVarValue }
			Me.GVarList.Columns.AddRange(values)
			Me.GVarList.GridLines = True
			Dim location As Point = New Point(8, 8)
			Me.GVarList.Location = location
			Me.GVarList.Name = "GVarList"
			Dim size As Size = New Size(232, 312)
			Me.GVarList.Size = size
			Me.GVarList.TabIndex = 0
			Me.GVarList.View = View.Details
			AddHandler Me.GVarList.Resize, AddressOf Me.GVarList_Resize
			Me.GVarName.Text = "Name"
			Me.GVarName.Width = 125
			Me.GVarType.Text = "Type"
			Me.GVarType.Width = 49
			Me.GVarValue.Text = "Value"
			Me.GVarValue.Width = 54
			MyBase.Controls.Add(Me.GVarList)
			MyBase.Name = "NDebuggerGVars"
			Dim size2 As Size = New Size(248, 328)
			MyBase.Size = size2
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub Init(script As __Pointer(Of cScript))
			Dim gArray<Script::cVariable *> As GArray<Script::cVariable *>
			<Module>.GArray<Script::cVariable *>.{ctor}(gArray<Script::cVariable *>, script + 8 / __SizeOf(cScript))
			Try
				Me.GVarList.Items.Clear()
				Dim num As Integer = 0
				If 0 < __Dereference((gArray<Script::cVariable *> + 4)) Then
					Do
						Dim ptr As __Pointer(Of cVariable) = __Dereference((num * 4 + gArray<Script::cVariable *>))
						Dim num2 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
						Dim listViewItem As ListViewItem = New ListViewItem(New String(CType((If((num2 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num2)), __Pointer(Of SByte))))
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(AddressOf gBaseString<char>, __Dereference(CType((ptr + 12 / __SizeOf(cVariable)), __Pointer(Of Integer))), 0)
						Try
							Dim num3 As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
							Dim value As __Pointer(Of SByte)
							If num3 <> 0UI Then
								value = num3
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
						Dim gBaseString<char>2 As GBaseString<char>
						Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.Script.sValue.GetAsString(ptr + 12 / __SizeOf(cVariable), AddressOf gBaseString<char>2)
						Try
							Dim num4 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
							Dim value2 As __Pointer(Of SByte)
							If num4 <> 0UI Then
								value2 = num4
							Else
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							listViewItem.SubItems.Add(New String(CType(value2, __Pointer(Of SByte))))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
							gBaseString<char>2 = 0
						End If
						Me.GVarList.Items.Add(listViewItem)
						num += 1
					Loop While num < __Dereference((gArray<Script::cVariable *> + 4))
				End If
				Me.GVarList_Resize(Nothing, Nothing)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<Script::cVariable *>.{dtor}), CType((AddressOf gArray<Script::cVariable *>), __Pointer(Of Void)))
				Throw
			End Try
			If gArray<Script::cVariable *> IsNot Nothing Then
				<Module>.free(gArray<Script::cVariable *>)
			End If
		End Sub

		Public Sub Refresh(script As __Pointer(Of cScript))
			Dim gArray<Script::cVariable *> As GArray<Script::cVariable *>
			<Module>.GArray<Script::cVariable *>.{ctor}(gArray<Script::cVariable *>, script + 8 / __SizeOf(cScript))
			Try
				Dim num As Integer = 0
				If 0 < __Dereference((gArray<Script::cVariable *> + 4)) Then
					Do
						Dim ptr As __Pointer(Of cVariable) = __Dereference((num * 4 + gArray<Script::cVariable *>))
						Dim listViewItem As ListViewItem = Me.GVarList.Items(num)
						Dim num2 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
						Dim value As __Pointer(Of SByte)
						If num2 <> 0UI Then
							value = num2
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						listViewItem.Text = New String(CType(value, __Pointer(Of SByte)))
						Dim ptr2 As __Pointer(Of cVariable) = ptr + 12 / __SizeOf(cVariable)
						Dim gBaseString<char> As GBaseString<char>
						Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.?GetValueTypeAsShortString@ScriptEditor@@$$FYA?AV?$GBaseString@D@@W4eValue_Type@Script@@_N@Z(AddressOf gBaseString<char>, __Dereference(CType(ptr2, __Pointer(Of Integer))), 0)
						Try
							Dim num3 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
							Dim value2 As __Pointer(Of SByte)
							If num3 <> 0UI Then
								value2 = num3
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
						Dim gBaseString<char>2 As GBaseString<char>
						Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.Script.sValue.GetAsString(ptr2, AddressOf gBaseString<char>2)
						Try
							Dim num4 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
							Dim value3 As __Pointer(Of SByte)
							If num4 <> 0UI Then
								value3 = num4
							Else
								value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							listViewItem.SubItems(2).Text = New String(CType(value3, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
							gBaseString<char>2 = 0
						End If
						num += 1
					Loop While num < __Dereference((gArray<Script::cVariable *> + 4))
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GArray<Script::cVariable *>.{dtor}), CType((AddressOf gArray<Script::cVariable *>), __Pointer(Of Void)))
				Throw
			End Try
			If gArray<Script::cVariable *> IsNot Nothing Then
				<Module>.free(gArray<Script::cVariable *>)
			End If
		End Sub

		Private Sub GVarList_Resize(sender As Object, e As EventArgs)
			Dim num As Integer = Me.GVarList.ClientSize.Width - Me.GVarType.Width
			Me.GVarName.Width = num - Me.GVarValue.Width
		End Sub
	End Class
End Namespace
