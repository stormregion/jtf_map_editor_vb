Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxOptions
		Inherits UserControl

		Public Delegate Sub __Delegate_OptionsChanged()

		Private components As Container

		Private btnCleanup As Button

		Private treeResources As TreeView

		Private OptionsPropertyTree As PropertyTree

		Public Custom Event OptionsChanged As ToolboxOptions.__Delegate_OptionsChanged
			AddHandler
				Me.OptionsChanged = [Delegate].Combine(Me.OptionsChanged, value)
			End AddHandler
			RemoveHandler
				Me.OptionsChanged = [Delegate].Remove(Me.OptionsChanged, value)
			End RemoveHandler
		End Event

		Public Sub New()
			Me.OptionsChanged = Nothing
			Me.InitializeComponent()
			Dim propertyTree As PropertyTree = New PropertyTree(0, NewAssetPicker.ObjectType.OptionsEditor, Nothing)
			Me.OptionsPropertyTree = propertyTree
			propertyTree.Dock = DockStyle.Top
			Dim location As Point = New Point(0, 0)
			Me.OptionsPropertyTree.Location = location
			Me.OptionsPropertyTree.Name = "OptionsPropertyTree"
			Dim size As Size = New Size(200, 300)
			Me.OptionsPropertyTree.Size = size
			Me.OptionsPropertyTree.TabIndex = 0
			Me.OptionsPropertyTree.Text = "OptionsPropertyTree"
			AddHandler Me.OptionsPropertyTree.ItemChanged, AddressOf Me.OptionsPropertyTree_ItemChanged
			MyBase.Controls.Add(Me.OptionsPropertyTree)
		End Sub

		Public Overrides Sub Refresh()
			Dim gMeasures As GMeasures
			Me.OptionsPropertyTree.SetVariable(Nothing, Nothing, <Module>.GMeasures.{ctor}(gMeasures, 1F, 1F))
			Dim gMeasures2 As GMeasures
			Me.OptionsPropertyTree.SetVariable(AddressOf <Module>.GRTT_WorkshopOptions.Class_GViewOptions, <Module>.Options + 68, <Module>.GMeasures.{ctor}(gMeasures2, 1F, 1F))
		End Sub

		Private Sub AddNodes(parent As TreeNodeCollection, rstat As __Pointer(Of GResourceStat))
			Dim num As Integer = 0
			Dim num2 As Integer = __Dereference(CType((rstat + 16 / __SizeOf(GResourceStat)), __Pointer(Of Integer)))
			If 0 < num2 Then
				Dim num3 As Integer = 0
				Do
					Dim num4 As Integer = num3 + __Dereference(CType((rstat + 12 / __SizeOf(GResourceStat)), __Pointer(Of Integer)))
					Dim ptr As __Pointer(Of GResourceStat) = num4
					Dim num5 As UInteger = CUInt((__Dereference(num4)))
					Dim ptr2 As __Pointer(Of SByte)
					If num5 <> 0UI Then
						ptr2 = num5
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>, CType((AddressOf <Module>.??_C@_0O@EGKHGIFB@?$CFs?5?$CI?$CF1?42f?5MB?$CJ?$AA@), __Pointer(Of SByte)), ptr2, __Dereference((ptr + 8)) * 9.5367431640625E-07)
					Dim index As Integer
					Try
						Dim num6 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
						Dim value As __Pointer(Of SByte)
						If num6 <> 0UI Then
							value = num6
						Else
							value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						index = parent.Add(New TreeNode(New String(CType(value, __Pointer(Of SByte)))))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
						gBaseString<char> = 0
					End If
					Dim rstat2 As __Pointer(Of GResourceStat) = __Dereference(CType((rstat + 12 / __SizeOf(GResourceStat)), __Pointer(Of Integer))) + num3
					Me.AddNodes(parent(index).Nodes, rstat2)
					num += 1
					num3 += 24
				Loop While num < __Dereference(CType((rstat + 16 / __SizeOf(GResourceStat)), __Pointer(Of Integer)))
			End If
		End Sub

		Public Sub RefreshResourceTree()
			Me.treeResources.BeginUpdate()
			Me.treeResources.Nodes.Clear()
			Dim expr_20 As __Pointer(Of GIEngine) = <Module>.IEngine
			Dim ptr As __Pointer(Of GResourceStat) = calli(GResourceStat* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_20, __Dereference((__Dereference(CType(expr_20, __Pointer(Of Integer))) + 92)))
			Dim num As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
			Dim ptr2 As __Pointer(Of SByte)
			If num <> 0UI Then
				ptr2 = num
			Else
				ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
			End If
			Dim gBaseString<char> As GBaseString<char>
			Dim ptr3 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>, CType((AddressOf <Module>.??_C@_0O@EGKHGIFB@?$CFs?5?$CI?$CF1?42f?5MB?$CJ?$AA@), __Pointer(Of SByte)), ptr2, __Dereference(CType((ptr + 8 / __SizeOf(GResourceStat)), __Pointer(Of Integer))) * 9.5367431640625E-07)
			Dim index As Integer
			Try
				Dim num2 As UInteger = CUInt((__Dereference(CType(ptr3, __Pointer(Of Integer)))))
				Dim value As __Pointer(Of SByte)
				If num2 <> 0UI Then
					value = num2
				Else
					value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				index = Me.treeResources.Nodes.Add(New TreeNode(New String(CType(value, __Pointer(Of SByte)))))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
			Me.AddNodes(Me.treeResources.Nodes(index).Nodes, ptr)
			Dim pThis As __Pointer(Of GResourceStat) = ptr
			Try
				<Module>.GArray<GResourceStat>.{dtor}(ptr + 12 / __SizeOf(GResourceStat))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType(pThis, __Pointer(Of Void)))
				Throw
			End Try
			Dim num3 As UInteger = CUInt((__Dereference(CType(ptr, __Pointer(Of Integer)))))
			If num3 <> 0UI Then
				<Module>.free(num3)
				__Dereference(CType(ptr, __Pointer(Of Integer))) = 0
			End If
			<Module>.delete(CType(ptr, __Pointer(Of Void)))
			Dim expr_109 As __Pointer(Of GIEngine) = <Module>.IEngine
			Dim ptr4 As __Pointer(Of GResourceStat) = calli(GResourceStat* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_109, __Dereference((__Dereference(CType(expr_109, __Pointer(Of Integer))) + 200)))
			Dim num4 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
			Dim ptr5 As __Pointer(Of SByte)
			If num4 <> 0UI Then
				ptr5 = num4
			Else
				ptr5 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
			End If
			Dim gBaseString<char>2 As GBaseString<char>
			Dim ptr6 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>2, CType((AddressOf <Module>.??_C@_0O@EGKHGIFB@?$CFs?5?$CI?$CF1?42f?5MB?$CJ?$AA@), __Pointer(Of SByte)), ptr5, __Dereference(CType((ptr4 + 8 / __SizeOf(GResourceStat)), __Pointer(Of Integer))) * 9.5367431640625E-07)
			Dim index2 As Integer
			Try
				Dim num5 As UInteger = CUInt((__Dereference(CType(ptr6, __Pointer(Of Integer)))))
				Dim value2 As __Pointer(Of SByte)
				If num5 <> 0UI Then
					value2 = num5
				Else
					value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
				End If
				index2 = Me.treeResources.Nodes.Add(New TreeNode(New String(CType(value2, __Pointer(Of SByte)))))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char>2 IsNot Nothing Then
				<Module>.free(gBaseString<char>2)
			End If
			Me.AddNodes(Me.treeResources.Nodes(index2).Nodes, ptr4)
			Dim pThis2 As __Pointer(Of GResourceStat) = ptr4
			Try
				<Module>.GArray<GResourceStat>.{dtor}(ptr4 + 12 / __SizeOf(GResourceStat))
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType(pThis2, __Pointer(Of Void)))
				Throw
			End Try
			Dim num6 As UInteger = CUInt((__Dereference(CType(ptr4, __Pointer(Of Integer)))))
			If num6 <> 0UI Then
				<Module>.free(num6)
				__Dereference(CType(ptr4, __Pointer(Of Integer))) = 0
			End If
			<Module>.delete(CType(ptr4, __Pointer(Of Void)))
			Me.treeResources.EndUpdate()
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
			Me.btnCleanup = New Button()
			Me.treeResources = New TreeView()
			MyBase.SuspendLayout()
			Me.btnCleanup.Dock = DockStyle.Top
			Dim location As Point = New Point(0, 0)
			Me.btnCleanup.Location = location
			Me.btnCleanup.Name = "btnCleanup"
			Dim size As Size = New Size(300, 24)
			Me.btnCleanup.Size = size
			Me.btnCleanup.TabIndex = 1
			Me.btnCleanup.Text = "Dispose unused resources"
			AddHandler Me.btnCleanup.Click, AddressOf Me.btnCleanup_Click
			Me.treeResources.Dock = DockStyle.Fill
			Me.treeResources.ImageIndex = -1
			Dim location2 As Point = New Point(0, 0)
			Me.treeResources.Location = location2
			Me.treeResources.Name = "treeResources"
			Me.treeResources.SelectedImageIndex = -1
			Dim size2 As Size = New Size(300, 600)
			Me.treeResources.Size = size2
			Me.treeResources.TabIndex = 0
			MyBase.Controls.Add(Me.treeResources)
			MyBase.Controls.Add(Me.btnCleanup)
			MyBase.Name = "ToolboxOptions"
			Dim size3 As Size = New Size(300, 600)
			MyBase.Size = size3
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub OptionsPropertyTree_ItemChanged()
			Me.raise_OptionsChanged()
		End Sub

		Private Sub btnCleanup_Click(sender As Object, e As EventArgs)
			<Module>.GUnitRegistry.UnloadUnusedUnitResources(<Module>.UnitRegistry)
			Dim expr_0F As __Pointer(Of GIEngine) = <Module>.IEngine
			Dim arg_1A_0 As Object = calli(System.Int32 modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr), expr_0F, __Dereference((__Dereference(CType(expr_0F, __Pointer(Of Integer))) + 72)))
			Me.RefreshResourceTree()
		End Sub

		Protected Sub raise_OptionsChanged()
			Dim optionsChanged As ToolboxOptions.__Delegate_OptionsChanged = Me.OptionsChanged
			If optionsChanged IsNot Nothing Then
				optionsChanged()
			End If
		End Sub
	End Class
End Namespace
