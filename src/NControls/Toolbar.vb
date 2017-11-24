Imports NWorkshop
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class Toolbar
		Inherits Control
		Implements IRearrangeableControl

		Private Class ToolbarItemProp
			Public itemImage As Image

			Public itemDisabledImage As Image

			Public itemBounds As Rectangle

			Public Pushed As Boolean

			Public Enabled As Boolean
		End Class

		Public Delegate Sub __Delegate_ButtonClick( As Integer,  As Integer)

		Private Items As __Pointer(Of GToolbarItem)

		Private ItemProps As Toolbar.ToolbarItemProp()

		Private NumItems As Integer

		Private IconSize As Integer

		Private LineHeight As Integer

		Private ActiveItem As Integer

		Private ActivePressed As Boolean

		Private SelectedItem As Integer

		Public ControlLight As Brush

		Public ControlDark As Brush

		Public NormalBackgroundBrush As Brush

		Public PushedBackgroundBrush As Brush

		Public SelectionBrush As Brush

		Public Tooltip As ToolTip

		Private components As Container

		Public Custom Event ButtonClick As Toolbar.__Delegate_ButtonClick
			AddHandler
				Me.ButtonClick = [Delegate].Combine(Me.ButtonClick, value)
			End AddHandler
			RemoveHandler
				Me.ButtonClick = [Delegate].Remove(Me.ButtonClick, value)
			End RemoveHandler
		End Event

		Public Overrides Custom Event Rearranged As ToolRearranged
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.Rearranged = [Delegate].Combine(Me.Rearranged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.Rearranged = [Delegate].Remove(Me.Rearranged, value)
			End RemoveHandler
		End Event

		Public Sub New(items As __Pointer(Of GToolbarItem), icon_size As Integer)
			Me.ButtonClick = Nothing
			Me.Rearranged = Nothing
			Me.NumItems = 0
			Me.ActiveItem = -2
			Me.SelectedItem = -1
			Me.ActivePressed = False
			MyBase.SetStyle(ControlStyles.Selectable, False)
			Me.InitializeComponent()
			Me.Items = items
			Me.IconSize = icon_size
			Me.NumItems = 0
			If __Dereference(CType(items, __Pointer(Of Integer))) <> -3 Then
				Do
					Me.NumItems += 1
				Loop While __Dereference(CType((Me.NumItems * 16 / __SizeOf(GToolbarItem) + Me.Items), __Pointer(Of Integer))) <> -3
			End If
			Me.ItemProps = New Toolbar.ToolbarItemProp(Me.NumItems - 1) {}
			Dim imageServer As ImageServer = ImageServer.GetImageServer("Images")
			Dim num As Integer = 0
			If 0 < Me.NumItems Then
				Dim num2 As Integer = 0
				Do
					Me.ItemProps(num) = New Toolbar.ToolbarItemProp()
					Dim ptr As __Pointer(Of GToolbarItem) = num2 / __SizeOf(GToolbarItem) + Me.Items
					Dim num3 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
					If num3 <> -1 AndAlso num3 <> -2 Then
						Me.ItemProps(num).itemImage = imageServer.GetImage(New String(__Dereference(CType((ptr + 8 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))))
						Me.ItemProps(num).itemDisabledImage = imageServer.GetImage(New String(__Dereference(CType((num2 / __SizeOf(GToolbarItem) + Me.Items + 8 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))) + "-disabled")
						Dim toolbarItemProp As Toolbar.ToolbarItemProp = Me.ItemProps(num)
						If toolbarItemProp.itemImage Is Nothing OrElse toolbarItemProp.itemDisabledImage Is Nothing Then
							GoTo IL_170
						End If
					End If
					Me.ItemProps(num).Enabled = True
					Me.ItemProps(num).Pushed = False
					num += 1
					num2 += 16
				Loop While num < Me.NumItems
				GoTo IL_199
				IL_170:
				<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0CL@OAFELHOF@c?3?2jtfcode?2src?2workshop?2controls@), __Pointer(Of SByte)), 98, CType((AddressOf <Module>.??_C@_0BM@GKMMDKEB@NControls?3?3Toolbar?3?3Toolbar?$AA@), __Pointer(Of SByte)))
				<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BF@GFLGEJNH@Icon?5?8?$CFs?8?5is?5missing?$AA@), __Pointer(Of SByte)), __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + Me.Items + 8 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))))
			End If
			IL_199:
			Me.LineHeight = Me.IconSize + 6
			Dim color As Color = Color.FromKnownColor(KnownColor.Control)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.ControlLightLight)
			Me.ControlLight = New SolidBrush(color2)
			Dim color3 As Color = Color.FromKnownColor(KnownColor.ControlDark)
			Me.ControlDark = New SolidBrush(color3)
			Dim color4 As Color = Color.FromArgb(CInt((CDec((CSng(color.R) * 0.8333333F)))), CInt((CDec((CSng(color.G) * 0.8333333F)))), CInt((CDec((CSng(color.B) * 0.8333333F)))))
			Dim num4 As Integer = CInt((CDec((CSng(color.B) * 1.2F))))
			Dim blue As Integer
			If num4 < 255 Then
				blue = num4
			Else
				blue = 255
			End If
			Dim num5 As Integer = CInt((CDec((CSng(color.G) * 1.2F))))
			Dim green As Integer
			If num5 < 255 Then
				green = num5
			Else
				green = 255
			End If
			Dim num6 As Integer = CInt((CDec((CSng(color.R) * 1.2F))))
			Dim color5 As Color = Color.FromArgb(If((num6 >= 255), 255, num6), green, blue)
			Dim point As Point = New Point(0, Me.LineHeight)
			Dim point2 As Point = New Point(0, 0)
			Me.NormalBackgroundBrush = New LinearGradientBrush(point2, point, color5, color4)
			Dim num7 As Integer = CInt((CDec((CSng(color.B) * 1.2F))))
			Dim blue2 As Integer
			If num7 < 255 Then
				blue2 = num7
			Else
				blue2 = 255
			End If
			Dim num8 As Integer = CInt((CDec((CSng(color.G) * 1.2F))))
			Dim green2 As Integer
			If num8 < 255 Then
				green2 = num8
			Else
				green2 = 255
			End If
			Dim num9 As Integer = CInt((CDec((CSng(color.R) * 1.2F))))
			Dim color6 As Color = Color.FromArgb(If((num9 >= 255), 255, num9), green2, blue2)
			Dim color7 As Color = Color.FromArgb(CInt((CDec((CSng(color.R) * 0.8333333F)))), CInt((CDec((CSng(color.G) * 0.8333333F)))), CInt((CDec((CSng(color.B) * 0.8333333F)))))
			Dim point3 As Point = New Point(0, Me.LineHeight)
			Dim point4 As Point = New Point(0, 0)
			Me.PushedBackgroundBrush = New LinearGradientBrush(point4, point3, color7, color6)
			Dim color8 As Color = Color.FromKnownColor(KnownColor.Highlight)
			Me.SelectionBrush = New SolidBrush(color8)
			Dim toolTip As ToolTip = New ToolTip()
			Me.Tooltip = toolTip
			toolTip.SetToolTip(Me, " ")
			Me.RearrangeToolbar()
		End Sub

		Public Sub RearrangeToolbar()
			If Me.NumItems <> 0 AndAlso MyBase.Size.Width <> 0 Then
				Dim num As Integer = 0
				Dim num2 As Integer = 0
				Dim num3 As Integer = 0
				Dim numItems As Integer = Me.NumItems
				If 0 < numItems Then
					While True
						Dim num4 As Integer = 0
						Dim num5 As Integer = 0
						Dim num6 As Integer = 0
						Dim num7 As Integer = 0
						Dim num8 As Integer = num3
						If num3 >= numItems Then
							GoTo IL_11E
						End If
						Dim num11 As Integer
						Do
							Dim num9 As Integer = 0
							Dim num10 As Integer = 0
							num11 = num8
							Dim num12 As Integer = numItems
							If num8 < num12 Then
								Dim ptr As __Pointer(Of GToolbarItem) = num8 * 16 / __SizeOf(GToolbarItem) + Me.Items
								Do
									Dim num13 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
									If num13 = -1 Then
										Exit Do
									End If
									If num13 = -2 Then
										num10 += 1
									Else
										num9 = Me.IconSize + num9 + 6
									End If
									num11 += 1
									ptr += 16 / __SizeOf(GToolbarItem)
								Loop While num11 < num12
							End If
							Dim size As Size = MyBase.Size
							Dim num14 As Integer = num4 + (num9 + num6)
							If num14 > size.Width Then
								Exit Do
							End If
							num4 = num14
							num5 = num10 + num5
							num7 = num11
							num6 = 0
							numItems = Me.NumItems
							Dim num15 As Integer = numItems
							If num11 < num15 Then
								Dim ptr2 As __Pointer(Of GToolbarItem) = num11 * 16 / __SizeOf(GToolbarItem) + Me.Items
								While __Dereference(CType(ptr2, __Pointer(Of Integer))) = -1
									num6 += 6
									num11 += 1
									ptr2 += 16 / __SizeOf(GToolbarItem)
									If num11 >= num15 Then
										Exit While
									End If
								End While
							End If
							num8 = num11
						Loop While num11 < numItems
						If num8 = num3 Then
							GoTo IL_11E
						End If
						Dim num16 As Integer = MyBase.Size.Width - num4
						Dim num17 As Integer
						If num5 > 1 Then
							num17 = num5
						Else
							num17 = 1
						End If
						Dim num18 As Integer = num16 / num17
						Dim num19 As Integer
						If num5 > 1 Then
							num19 = num5
						Else
							num19 = 1
						End If
						Dim num20 As Integer = num16 Mod num19
						Dim num21 As Integer = num3
						If num3 < num7 Then
							Dim num22 As Integer = num3 * 16
							Do
								Dim num23 As Integer = __Dereference(CType((Me.Items + num22 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))
								Dim num24 As Integer
								If num23 = -1 Then
									num24 = 6
								Else If num23 = -2 Then
									num24 = num18
									If num20 <> 0 Then
										num24 = num18 + 1
										num20 -= 1
									End If
								Else
									num24 = Me.IconSize + 6
								End If
								Me.ItemProps(num21).itemBounds.X = num2
								Me.ItemProps(num21).itemBounds.Y = Me.LineHeight * num
								Me.ItemProps(num21).itemBounds.Width = num24
								Me.ItemProps(num21).itemBounds.Height = Me.LineHeight
								num2 = num24 + num2
								num21 += 1
								num22 += 16
							Loop While num21 < num7
						End If
						If num21 < num8 Then
							Do
								Me.ItemProps(num21).itemBounds.X = num2
								Me.ItemProps(num21).itemBounds.Y = Me.LineHeight * num
								Me.ItemProps(num21).itemBounds.Width = 0
								Me.ItemProps(num21).itemBounds.Height = Me.LineHeight
								num21 += 1
							Loop While num21 < num8
						End If
						num += 1
						num2 = 0
						num3 = num21
						IL_390:
						numItems = Me.NumItems
						If num21 >= numItems Then
							Exit While
						End If
						Continue While
						IL_11E:
						num21 = num3
						If num3 < Me.NumItems Then
							Dim num25 As Integer = num3 * 16
							Do
								Dim num26 As Integer = __Dereference(CType((Me.Items + num25 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))
								If num26 = -1 Then
									Exit Do
								End If
								If num26 <> -2 Then
									Dim num27 As Integer = Me.IconSize + 6
									Dim size2 As Size = MyBase.Size
									If num2 + num27 > size2.Width Then
										Exit Do
									End If
									Me.ItemProps(num21).itemBounds.X = num2
									Me.ItemProps(num21).itemBounds.Y = Me.LineHeight * num
									Me.ItemProps(num21).itemBounds.Width = num27
									Me.ItemProps(num21).itemBounds.Height = Me.LineHeight
									num2 += num27
								End If
								num21 += 1
								num25 += 16
							Loop While num21 < Me.NumItems
						End If
						Dim numItems2 As Integer = Me.NumItems
						If num21 < numItems2 Then
							Dim ptr3 As __Pointer(Of GToolbarItem) = num21 * 16 / __SizeOf(GToolbarItem) + Me.Items
							While __Dereference(CType(ptr3, __Pointer(Of Integer))) = -1
								num21 += 1
								ptr3 += 16 / __SizeOf(GToolbarItem)
								If num21 >= numItems2 Then
									Exit While
								End If
							End While
						End If
						num += 1
						num2 = 0
						num3 = num21
						GoTo IL_390
					End While
				End If
				num -= 1
				Dim size3 As Size = MyBase.Size
				Dim num28 As Integer = num + 1
				If size3.Height <> Me.LineHeight * num28 Then
					Dim size4 As Size = New Size(MyBase.Size.Width, Me.LineHeight * num28)
					MyBase.Size = size4
				End If
				MyBase.Invalidate()
			End If
		End Sub

		Public Sub SetItemEnable(idx As Integer, <MarshalAs(UnmanagedType.U1)> enable As Boolean)
			Dim num As Integer = 0
			If 0 < Me.NumItems Then
				Dim num2 As Integer = 0
				Do
					If __Dereference(CType((Me.Items + num2 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))) = idx Then
						Dim toolbarItemProp As Toolbar.ToolbarItemProp = Me.ItemProps(num)
						If toolbarItemProp.Enabled <> enable Then
							toolbarItemProp.Enabled = enable
							If Not enable Then
								Me.ItemProps(num).Pushed = False
							End If
							Me.InvalidateItem(num)
						End If
					End If
					num += 1
					num2 += 16
				Loop While num < Me.NumItems
			End If
		End Sub

		Public Sub SetGroupEnable(idx As Integer, <MarshalAs(UnmanagedType.U1)> enable As Boolean)
			Dim num As Integer = 0
			If 0 < Me.NumItems Then
				Dim num2 As Integer = 0
				Do
					If __Dereference(CType((num2 / __SizeOf(GToolbarItem) + Me.Items + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))) = idx Then
						Dim toolbarItemProp As Toolbar.ToolbarItemProp = Me.ItemProps(num)
						If toolbarItemProp.Enabled <> enable Then
							toolbarItemProp.Enabled = enable
							If Not enable Then
								Me.ItemProps(num).Pushed = False
							End If
							Me.InvalidateItem(num)
						End If
					End If
					num += 1
					num2 += 16
				Loop While num < Me.NumItems
			End If
		End Sub

		Public Sub SetGroupPushed(idx As Integer, <MarshalAs(UnmanagedType.U1)> pushed As Boolean)
			Dim num As Integer = 0
			If 0 < Me.NumItems Then
				Dim num2 As Integer = 0
				Do
					If __Dereference(CType((num2 / __SizeOf(GToolbarItem) + Me.Items + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))) = idx Then
						Dim toolbarItemProp As Toolbar.ToolbarItemProp = Me.ItemProps(num)
						If toolbarItemProp.Pushed <> pushed Then
							If toolbarItemProp.Enabled AndAlso pushed Then
								toolbarItemProp.Pushed = True
							Else
								toolbarItemProp.Pushed = False
							End If
							Me.InvalidateItem(num)
						End If
					End If
					num += 1
					num2 += 16
				Loop While num < Me.NumItems
			End If
		End Sub

		Public Sub SetItemPushed(idx As Integer, <MarshalAs(UnmanagedType.U1)> pushed As Boolean)
			Dim num As Integer = 0
			Dim num2 As Integer = 0
			If 0 < Me.NumItems Then
				Dim num3 As Integer = 0
				Do
					Dim ptr As __Pointer(Of GToolbarItem) = num3 / __SizeOf(GToolbarItem) + Me.Items
					If __Dereference(CType(ptr, __Pointer(Of Integer))) = idx Then
						num = __Dereference(CType((ptr + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))
						Dim toolbarItemProp As Toolbar.ToolbarItemProp = Me.ItemProps(num2)
						If toolbarItemProp.Pushed <> pushed Then
							toolbarItemProp.Pushed = pushed
							Me.InvalidateItem(num2)
						End If
					End If
					num2 += 1
					num3 += 16
				Loop While num2 < Me.NumItems
				If num <> 0 Then
					Dim num4 As Integer = 0
					If 0 < Me.NumItems Then
						Dim num5 As Integer = 0
						Do
							Dim ptr2 As __Pointer(Of GToolbarItem) = num5 / __SizeOf(GToolbarItem) + Me.Items
							If __Dereference(CType((ptr2 + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))) = num AndAlso __Dereference(CType(ptr2, __Pointer(Of Integer))) <> idx Then
								Dim toolbarItemProp2 As Toolbar.ToolbarItemProp = Me.ItemProps(num4)
								If toolbarItemProp2.Pushed Then
									toolbarItemProp2.Pushed = False
									Me.InvalidateItem(num4)
								End If
							End If
							num4 += 1
							num5 += 16
						Loop While num4 < Me.NumItems
					End If
				End If
			End If
		End Sub

		Public Function GetItemPushed(idx As Integer) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Dim num As Integer = 0
			Dim numItems As Integer = Me.NumItems
			If 0 < numItems Then
				Dim ptr As __Pointer(Of GToolbarItem) = Me.Items
				While __Dereference(CType(ptr, __Pointer(Of Integer))) <> idx
					num += 1
					ptr += 16 / __SizeOf(GToolbarItem)
					If num >= numItems Then
						Return False
					End If
				End While
				Return Me.ItemProps(num).Pushed
			End If
			Return False
		End Function

		Public Sub EmulatePushByID(indx As Integer)
			Dim num As Integer = -1
			Dim num2 As Integer = 0
			Dim numItems As Integer = Me.NumItems
			If 0 < numItems Then
				Dim items As __Pointer(Of GToolbarItem) = Me.Items
				Dim numItems2 As Integer = Me.NumItems
				Do
					If __Dereference(CType((num2 * 16 / __SizeOf(GToolbarItem) + items), __Pointer(Of Integer))) = indx Then
						num = num2
						num2 = numItems
					End If
					num2 += 1
				Loop While num2 < numItems2
				If num >= 0 AndAlso Me.ItemProps(num).Enabled Then
					Dim activeItem As Integer = Me.ActiveItem
					If activeItem <> num Then
						Me.InvalidateItem(activeItem)
						Me.ActiveItem = num
						Me.InvalidateItem(num)
					End If
					Me.ActivePressed = True
					Me.InvalidateItem(Me.ActiveItem)
				End If
			End If
		End Sub

		Public Sub EmulateUpByID(indx As Integer)
			Dim num As Integer = -1
			Dim num2 As Integer = 0
			Dim numItems As Integer = Me.NumItems
			If 0 < numItems Then
				Dim items As __Pointer(Of GToolbarItem) = Me.Items
				Dim numItems2 As Integer = Me.NumItems
				Do
					If __Dereference(CType((num2 * 16 / __SizeOf(GToolbarItem) + items), __Pointer(Of Integer))) = indx Then
						num = num2
						num2 = numItems
					End If
					num2 += 1
				Loop While num2 < numItems2
			End If
			Dim activeItem As Integer = Me.ActiveItem
			If num = activeItem AndAlso activeItem >= 0 AndAlso Me.ItemProps(num).Enabled Then
				Dim ptr As __Pointer(Of GToolbarItem) = activeItem * 16 / __SizeOf(GToolbarItem) + Me.Items
				Me.raise_ButtonClick(__Dereference(CType(ptr, __Pointer(Of Integer))), __Dereference(CType((ptr + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))))
				Me.ActivePressed = False
				Me.InvalidateItem(Me.ActiveItem)
				Me.ActiveItem = -1
			End If
		End Sub

		Public Sub EmulatePush(ordinal As Integer)
			Dim num As Integer = -1
			Dim num2 As Integer = -1
			If ordinal < 0 Then
				If Me.ActiveItem < 0 Then
					Return
				End If
			Else
				Dim num3 As Integer = 0
				If -1 < ordinal Then
					Dim ptr As __Pointer(Of GToolbarItem) = Me.Items
					Do
						Dim num4 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
						If num4 <> -1 AndAlso num4 <> -2 Then
							num2 = num3
							num += 1
						End If
						num3 += 1
						ptr += 16 / __SizeOf(GToolbarItem)
					Loop While num < ordinal
				End If
				Dim numItems As Integer = Me.NumItems
				If ordinal >= numItems OrElse num2 < 0 OrElse num2 >= numItems OrElse Not Me.ItemProps(num2).Enabled Then
					Return
				End If
				Dim activeItem As Integer = Me.ActiveItem
				If activeItem <> num2 Then
					Me.InvalidateItem(activeItem)
					Me.ActiveItem = num2
					Me.InvalidateItem(num2)
				End If
			End If
			Me.ActivePressed = True
			Me.InvalidateItem(Me.ActiveItem)
		End Sub

		Public Sub EmulateUp(ordinal As Integer)
			Dim num As Integer = -1
			Dim num2 As Integer = -1
			If ordinal < 0 Then
				num2 = Me.ActiveItem
			Else
				Dim num3 As Integer = 0
				If -1 < ordinal Then
					Dim ptr As __Pointer(Of GToolbarItem) = Me.Items
					Do
						Dim num4 As Integer = __Dereference(CType(ptr, __Pointer(Of Integer)))
						If num4 <> -1 AndAlso num4 <> -2 Then
							num2 = num3
							num += 1
						End If
						num3 += 1
						ptr += 16 / __SizeOf(GToolbarItem)
					Loop While num < ordinal
				End If
			End If
			Dim activeItem As Integer = Me.ActiveItem
			If num2 = activeItem AndAlso activeItem >= 0 AndAlso Me.ItemProps(num2).Enabled Then
				Dim ptr2 As __Pointer(Of GToolbarItem) = activeItem * 16 / __SizeOf(GToolbarItem) + Me.Items
				Me.raise_ButtonClick(__Dereference(CType(ptr2, __Pointer(Of Integer))), __Dereference(CType((ptr2 + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))))
				Me.ActivePressed = False
				Me.InvalidateItem(Me.ActiveItem)
				Me.SelectedItem = Me.ActiveItem
				Me.ActiveItem = -1
			End If
		End Sub

		Public Function NextTool() As Integer
			Dim num As Integer = Me.SelectedItem + 1
			Dim num2 As Integer = 0
			Dim numItems As Integer = Me.NumItems
			If 0 < numItems Then
				Dim items As __Pointer(Of GToolbarItem) = Me.Items
				Do
					If num >= numItems Then
						num = 0
					End If
					If __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + items), __Pointer(Of Integer))) >= 0 Then
						GoTo IL_42
					End If
					num += 1
					num2 += 1
				Loop While num2 < Me.NumItems
				Return -1
				IL_42:
				Dim activeItem As Integer = Me.ActiveItem
				If activeItem <> num AndAlso num >= 0 Then
					Me.InvalidateItem(activeItem)
					Me.ActiveItem = num
					Me.InvalidateItem(num)
				End If
				Me.SelectedItem = num
				Return __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + Me.Items + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))
			End If
			Return -1
		End Function

		Public Function PrevTool() As Integer
			Dim num As Integer = Me.SelectedItem - 1
			Dim num2 As Integer = 0
			Dim numItems As Integer = Me.NumItems
			If 0 < numItems Then
				Dim items As __Pointer(Of GToolbarItem) = Me.Items
				Do
					If num < 0 Then
						num = numItems - 1
					End If
					If __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + items), __Pointer(Of Integer))) >= 0 Then
						GoTo IL_44
					End If
					num -= 1
					num2 += 1
				Loop While num2 < Me.NumItems
				Return -1
				IL_44:
				Dim activeItem As Integer = Me.ActiveItem
				If activeItem <> num AndAlso num >= 0 Then
					Me.InvalidateItem(activeItem)
					Me.ActiveItem = num
					Me.InvalidateItem(num)
				End If
				Me.SelectedItem = num
				Return __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + Me.Items + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))
			End If
			Return -1
		End Function

		Public Function NextGroup() As Integer
			Dim num As Integer = Me.SelectedItem + 1
			Dim flag As Boolean = False
			Dim num2 As Integer = 0
			Dim numItems As Integer = Me.NumItems
			If 0 < numItems Then
				Dim items As __Pointer(Of GToolbarItem) = Me.Items
				Do
					If num >= numItems Then
						num = 0
						flag = True
					End If
					Dim num3 As Integer = __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + items), __Pointer(Of Integer)))
					If num3 >= 0 AndAlso flag Then
						GoTo IL_5A
					End If
					If num3 < 0 Then
						flag = True
					End If
					num += 1
					num2 += 1
				Loop While num2 < Me.NumItems
				Return -1
				IL_5A:
				Dim activeItem As Integer = Me.ActiveItem
				If activeItem <> num AndAlso num >= 0 Then
					Me.InvalidateItem(activeItem)
					Me.ActiveItem = num
					Me.InvalidateItem(num)
				End If
				Me.SelectedItem = num
				Return __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + Me.Items + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))
			End If
			Return -1
		End Function

		Public Function PrevGroup() As Integer
			Dim num As Integer = Me.SelectedItem - 1
			Dim flag As Boolean = False
			Dim num2 As Integer = 0
			Dim num3 As Integer = Me.NumItems - 1
			If 0 < num3 Then
				Dim items As __Pointer(Of GToolbarItem) = Me.Items
				Do
					If num < 0 Then
						num = num3
						flag = True
					End If
					Dim num4 As Integer = __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + items), __Pointer(Of Integer)))
					If num4 >= 0 AndAlso flag Then
						GoTo IL_5E
					End If
					If num4 < 0 Then
						flag = True
					End If
					num -= 1
					num2 += 1
				Loop While num2 < Me.NumItems - 1
				Return -1
				IL_5E:
				Dim activeItem As Integer = Me.ActiveItem
				If activeItem <> num AndAlso num >= 0 Then
					Me.InvalidateItem(activeItem)
					Me.ActiveItem = num
					Me.InvalidateItem(num)
				End If
				Me.SelectedItem = num
				Return __Dereference(CType((num * 16 / __SizeOf(GToolbarItem) + Me.Items + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))
			End If
			Return -1
		End Function

		Public Sub SetSelectedItem(idx As Integer)
			Dim num As Integer = 0
			If 0 < Me.NumItems Then
				Dim ptr As __Pointer(Of GToolbarItem) = Me.Items
				Do
					If __Dereference(CType(ptr, __Pointer(Of Integer))) = idx Then
						Me.SelectedItem = num
					End If
					num += 1
					ptr += 16 / __SizeOf(GToolbarItem)
				Loop While num < Me.NumItems
			End If
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
			Me.Font = New Font("Tahoma", 8.25F)
			Dim size As Size = New Size(300, 300)
			MyBase.Size = size
		End Sub

		Protected Overrides Sub OnPaint(e As PaintEventArgs)
			If Me.NumItems <> 0 Then
				Dim size As Size = MyBase.Size
				Dim size2 As Size = MyBase.Size
				e.Graphics.FillRectangle(Me.NormalBackgroundBrush, 0, 0, size2.Width, size.Height)
				Dim num As Integer = 0
				If 0 < Me.NumItems Then
					Dim num2 As Integer = 0
					Do
						Dim itemProps As Toolbar.ToolbarItemProp() = Me.ItemProps
						Dim itemBounds As Rectangle = itemProps(num).itemBounds
						Dim num3 As Integer = __Dereference(CType((Me.Items + num2 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))
						If num3 = -1 Then
							If itemBounds.Width <> 0 Then
								e.Graphics.FillRectangle(Me.ControlDark, itemBounds.X + 2, itemBounds.Y + 2, 1, Me.IconSize + 2)
								e.Graphics.FillRectangle(Me.ControlLight, itemBounds.X + 3, itemBounds.Y + 2, 1, Me.IconSize + 2)
							End If
						Else If num3 <> -2 Then
							If(num = Me.ActiveItem AndAlso Me.ActivePressed) OrElse itemProps(num).Pushed Then
								e.Graphics.FillRectangle(Me.PushedBackgroundBrush, itemBounds.X + 1, itemBounds.Y + 1, itemBounds.Width - 2, itemBounds.Height - 2)
							End If
							If num = Me.ActiveItem Then
								e.Graphics.FillRectangle(Me.SelectionBrush, itemBounds.X + 1, itemBounds.Y + 1, itemBounds.Width - 2, 1)
								e.Graphics.FillRectangle(Me.SelectionBrush, itemBounds.X + 1, itemBounds.Y + 1, 1, itemBounds.Height - 2)
								Dim num4 As Integer = itemBounds.Y - 2
								e.Graphics.FillRectangle(Me.SelectionBrush, itemBounds.X + 1, itemBounds.Height + num4, itemBounds.Width - 2, 1)
								Dim num5 As Integer = itemBounds.X - 2
								e.Graphics.FillRectangle(Me.SelectionBrush, itemBounds.Width + num5, itemBounds.Y + 1, 1, itemBounds.Height - 2)
							End If
							If Not Me.ItemProps(num).Enabled Then
								Dim iconSize As Integer = Me.IconSize
								Dim arg_248_0 As Graphics = e.Graphics
								Dim arg_248_1 As Image = Me.ItemProps(num).itemDisabledImage
								Dim arg_248_2 As Integer = itemBounds.X + 3
								Dim arg_248_3 As Integer = itemBounds.Y + 3
								Dim expr_247 As Integer = iconSize
								arg_248_0.DrawImage(arg_248_1, arg_248_2, arg_248_3, expr_247, expr_247)
							Else If num = Me.ActiveItem AndAlso Me.ActivePressed Then
								Dim iconSize2 As Integer = Me.IconSize
								Dim arg_293_0 As Graphics = e.Graphics
								Dim arg_293_1 As Image = Me.ItemProps(num).itemImage
								Dim arg_293_2 As Integer = itemBounds.X + 4
								Dim arg_293_3 As Integer = itemBounds.Y + 4
								Dim expr_292 As Integer = iconSize2
								arg_293_0.DrawImage(arg_293_1, arg_293_2, arg_293_3, expr_292, expr_292)
							Else
								Dim iconSize3 As Integer = Me.IconSize
								Dim arg_2CA_0 As Graphics = e.Graphics
								Dim arg_2CA_1 As Image = Me.ItemProps(num).itemImage
								Dim arg_2CA_2 As Integer = itemBounds.X + 3
								Dim arg_2CA_3 As Integer = itemBounds.Y + 3
								Dim expr_2C9 As Integer = iconSize3
								arg_2CA_0.DrawImage(arg_2CA_1, arg_2CA_2, arg_2CA_3, expr_2C9, expr_2C9)
							End If
						End If
						num += 1
						num2 += 16
					Loop While num < Me.NumItems
				End If
			End If
		End Sub

		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			Me.RearrangeToolbar()
			Me.raise_Rearranged(Me, MyBase.Height)
		End Sub

		Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
			Dim num As Integer = -1
			Dim num2 As Integer = 0
			If 0 < Me.NumItems Then
				Dim num3 As Integer = 0
				Do
					If __Dereference(CType((Me.Items + num3 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))) <> -1 Then
						Dim itemProps As Toolbar.ToolbarItemProp() = Me.ItemProps
						If itemProps(num2).Enabled Then
							Dim itemBounds As Rectangle = itemProps(num2).itemBounds
							If e.X >= itemBounds.Left AndAlso e.X < itemBounds.Right AndAlso e.Y >= itemBounds.Top AndAlso e.Y < itemBounds.Bottom Then
								GoTo IL_91
							End If
						End If
					End If
					num2 += 1
					num3 += 16
				Loop While num2 < Me.NumItems
				GoTo IL_93
				IL_91:
				num = num2
			End If
			IL_93:
			Dim activeItem As Integer = Me.ActiveItem
			If activeItem <> num Then
				Me.InvalidateItem(activeItem)
				Me.ActiveItem = num
				Me.InvalidateItem(num)
				Dim tooltip As ToolTip = Me.Tooltip
				If tooltip IsNot Nothing Then
					If Me.ActiveItem >= 0 Then
						Me.Tooltip.SetToolTip(Me, New String(__Dereference(CType((num2 * 16 / __SizeOf(GToolbarItem) + Me.Items + 4 / __SizeOf(GToolbarItem)), __Pointer(Of Integer)))))
					Else
						tooltip.SetToolTip(Me, "")
					End If
				End If
			End If
		End Sub

		Protected Overrides Sub OnMouseLeave(e As EventArgs)
			Dim activeItem As Integer = Me.ActiveItem
			If activeItem >= 0 Then
				Me.InvalidateItem(activeItem)
				Me.ActiveItem = -1
			End If
			Me.Tooltip.SetToolTip(Me, "")
			Me.ActivePressed = False
		End Sub

		Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
			Me.ActivePressed = True
			Me.InvalidateItem(Me.ActiveItem)
		End Sub

		Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
			If Me.ActivePressed Then
				Dim activeItem As Integer = Me.ActiveItem
				If activeItem >= 0 Then
					Dim ptr As __Pointer(Of GToolbarItem) = activeItem * 16 / __SizeOf(GToolbarItem) + Me.Items
					Me.raise_ButtonClick(__Dereference(CType(ptr, __Pointer(Of Integer))), __Dereference(CType((ptr + 12 / __SizeOf(GToolbarItem)), __Pointer(Of Integer))))
				End If
			End If
			Dim activeItem2 As Integer = Me.ActiveItem
			Me.SelectedItem = activeItem2
			Me.ActivePressed = False
			Me.InvalidateItem(activeItem2)
		End Sub

		Private Sub InvalidateItem(idx As Integer)
			If idx >= 0 AndAlso idx < Me.NumItems Then
				MyBase.Invalidate(Me.ItemProps(idx).itemBounds)
			End If
		End Sub

		Protected Sub raise_ButtonClick(i1 As Integer, i2 As Integer)
			Dim buttonClick As Toolbar.__Delegate_ButtonClick = Me.ButtonClick
			If buttonClick IsNot Nothing Then
				buttonClick(i1, i2)
			End If
		End Sub

		Protected Sub raise_Rearranged(i1 As Object, i2 As Integer)
			Dim rearranged As ToolRearranged = Me.Rearranged
			If rearranged IsNot Nothing Then
				rearranged(i1, i2)
			End If
		End Sub
	End Class
End Namespace
