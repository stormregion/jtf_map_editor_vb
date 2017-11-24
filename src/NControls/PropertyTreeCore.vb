Imports GRTTI
Imports NWorkshop
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Timers
Imports System.Windows.Forms

Namespace NControls
	Public Class PropertyTreeCore
		Inherits ScrollableControl
		Implements IMultiColumnControl

		Public Delegate Sub TrackSelectedHandler(curveeditor As NCurveEditor)

		Public Delegate Sub __Delegate_ItemChanged()

		Public Delegate Sub __Delegate_SelectedIndexChanged()

		Public ItemHeight As Single

		Public Measures As __Pointer(Of GMeasures)

		Public ObjType As NewAssetPicker.ObjectType

		Private propItems As ArrayList

		Private propColumnDatas As ArrayList

		Private propSelectedIndex As Integer

		Private DescLabel As Label

		Private NormalItemBackgroundBrush As Brush

		Private NormalItemTextBrush As Brush

		Private SelectedItemBackgroundBrush As Brush

		Private SelectedItemTextBrush As Brush

		Private FocusSelectedItemBackgroundBrush As Brush

		Private FocusSelectedItemTextBrush As Brush

		Private ItemBorderPen As Pen

		Private ExpandedLinePen As Pen

		Private IndentWidth As Integer

		Private LastSelectedIndex As Integer

		Private IsDblClickEnabled As Boolean

		Private ForbidDblClickTimer As System.Timers.Timer

		Private LocalMenu As ContextMenu

		Private Clipboard As __Pointer(Of NPropertyClipboard)

		Private ItemCopyHandler As PropertyItem.CopyPasteHandler

		Private ItemPasteHandler As PropertyItem.CopyPasteHandler

		Private components As Container

		Public Custom Event SelectedIndexChanged As PropertyTreeCore.__Delegate_SelectedIndexChanged
			AddHandler
				Me.SelectedIndexChanged = [Delegate].Combine(Me.SelectedIndexChanged, value)
			End AddHandler
			RemoveHandler
				Me.SelectedIndexChanged = [Delegate].Remove(Me.SelectedIndexChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event ItemChanged As PropertyTreeCore.__Delegate_ItemChanged
			AddHandler
				Me.ItemChanged = [Delegate].Combine(Me.ItemChanged, value)
			End AddHandler
			RemoveHandler
				Me.ItemChanged = [Delegate].Remove(Me.ItemChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event TrackSelected As PropertyTreeCore.TrackSelectedHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.TrackSelected = [Delegate].Combine(Me.TrackSelected, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.TrackSelected = [Delegate].Remove(Me.TrackSelected, value)
			End RemoveHandler
		End Event

		Public Property SelectedIndex() As Integer
			Get
				Return Me.propSelectedIndex
			End Get
			Set(value As Integer)
				Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
				Me.propSelectedIndex = value
				Me.raise_SelectedIndexChanged()
				Dim propertyItemScalarTrack As PropertyItemScalarTrack = Nothing
				Try
					propertyItemScalarTrack = (TryCast(Me.Items(Me.SelectedIndex), PropertyItemScalarTrack))
					GoTo IL_7A
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
				IL_7A:
				If propertyItemScalarTrack IsNot Nothing Then
					Me.raise_TrackSelected(propertyItemScalarTrack.GetTrackEditor())
				Else
					Me.raise_TrackSelected(Nothing)
				End If
			End Set
		End Property

		Public Overrides ReadOnly Property ColumnDatas() As ArrayList
			Get
				Return Me.propColumnDatas
			End Get
		End Property

		Public ReadOnly Property Items() As ArrayList
			Get
				Return Me.propItems
			End Get
		End Property

		Public Sub New(width As Integer, height As Integer, viewheight As Integer, scrollbarmode As Integer, desclabel As Label, objecttype As NewAssetPicker.ObjectType, clipboard As __Pointer(Of NPropertyClipboard))
			MyBase.New(width, height, viewheight, scrollbarmode)
			Me.ItemChanged = Nothing
			Me.SelectedIndexChanged = Nothing
			Me.TrackSelected = Nothing
			Me.DescLabel = desclabel
			Me.ObjType = objecttype
			Me.InitializeComponent()
			Me.propItems = New ArrayList()
			Me.propColumnDatas = New ArrayList()
			Me.ItemHeight = CSng((Me.Font.Height + 3))
			Me.IndentWidth = 13
			Me.LastSelectedIndex = -1
			Dim color As Color = Color.FromKnownColor(KnownColor.Window)
			Me.NormalItemBackgroundBrush = New SolidBrush(color)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.WindowText)
			Me.NormalItemTextBrush = New SolidBrush(color2)
			Dim color3 As Color = Color.FromKnownColor(KnownColor.Control)
			Me.SelectedItemBackgroundBrush = New SolidBrush(color3)
			Dim color4 As Color = Color.FromKnownColor(KnownColor.ControlText)
			Me.SelectedItemTextBrush = New SolidBrush(color4)
			Dim color5 As Color = Color.FromKnownColor(KnownColor.Highlight)
			Me.FocusSelectedItemBackgroundBrush = New SolidBrush(color5)
			Dim color6 As Color = Color.FromKnownColor(KnownColor.HighlightText)
			Me.FocusSelectedItemTextBrush = New SolidBrush(color6)
			Dim color7 As Color = Color.FromKnownColor(KnownColor.Control)
			Me.ItemBorderPen = New Pen(color7)
			Dim pen As Pen = New Pen(Color.FromKnownColor(KnownColor.ControlText))
			Me.ExpandedLinePen = pen
			pen.DashStyle = DashStyle.Dot
			AddHandler Me.ViewControl.Paint, AddressOf Me.ViewControlPaint
			AddHandler Me.ViewControl.MouseDown, AddressOf Me.ViewControlMouseDown
			AddHandler Me.ViewControl.MouseUp, AddressOf Me.ViewControlMouseUp
			AddHandler Me.ViewControl.DoubleClick, AddressOf Me.ViewControlDoubleClick
			Me.IsDblClickEnabled = True
			Me.ForbidDblClickTimer = New System.Timers.Timer()
			AddHandler Me.ForbidDblClickTimer.Elapsed, AddressOf Me.EnableDblClick
			Me.ForbidDblClickTimer.Interval = 500.0
			Me.ForbidDblClickTimer.Enabled = False
			Me.LocalMenu = New ContextMenu()
			Me.Clipboard = clipboard
			Me.ItemCopyHandler = AddressOf Me.OnItemCopy
			Me.ItemPasteHandler = AddressOf Me.OnItemPaste
		End Sub

		Public Sub AddSubitems(subitems As ArrayList, indent_depth As Integer, insert_at As __Pointer(Of Integer))
			Me.AddSubitems(subitems, indent_depth, insert_at, Nothing)
		End Sub

		Public Sub AddSubitems(subitems As ArrayList, indent_depth As Integer, insert_at As __Pointer(Of Integer), expansions As ArrayList)
			Dim num As Integer = 0
			If 0 < subitems.Count Then
				Do
					Dim propertyItem As PropertyItem = TryCast(subitems(num), PropertyItem)
					propertyItem.IndentDepth = indent_depth
					propertyItem.Index = __Dereference(insert_at)
					propertyItem.Host = Me
					Me.Items.Insert(__Dereference(insert_at), propertyItem)
					propertyItem.UpdateControl(New Rectangle() With { .X = CInt((CDec(((TryCast(Me.ColumnDatas(1), ColumnData)).StartX + 2F)))), .Y = CInt((CDec((CSng(propertyItem.Index) * Me.ItemHeight)))), .Width = CInt((CDec(((TryCast(Me.ColumnDatas(1), ColumnData)).Width - 1F)))), .Height = CInt((CDec(Me.ItemHeight))) })
					__Dereference(insert_at) += 1
					Dim flag As Boolean = True
					If expansions IsNot Nothing Then
						Dim num2 As Integer = 0
						If 0 < expansions.Count Then
							Dim itemStatus As ItemStatus
							Do
								itemStatus = (TryCast(expansions(num2), ItemStatus))
								If String.Compare(itemStatus.Name, propertyItem.GetName()) = 0 AndAlso itemStatus.Type = propertyItem.IdentifyType() Then
									GoTo IL_117
								End If
								num2 += 1
							Loop While num2 < expansions.Count
							GoTo IL_11F
							IL_117:
							flag = itemStatus.Expanded
						End If
					End If
					IL_11F:
					If propertyItem.ShouldBeExpanded() AndAlso flag Then
						Me.AddSubitems(propertyItem.Expand(), indent_depth + 1, insert_at, expansions)
						propertyItem.Expanded = True
					Else
						propertyItem.Expanded = False
					End If
					num += 1
				Loop While num < subitems.Count
			End If
		End Sub

		Public Sub UpdateSubitems(start_idx As Integer)
			Dim num As Integer = start_idx
			If start_idx < Me.Items.Count Then
				Do
					Dim propertyItem As PropertyItem = TryCast(Me.Items(num), PropertyItem)
					propertyItem.Index = num
					propertyItem.UpdateControl(New Rectangle() With { .X = CInt((CDec(((TryCast(Me.ColumnDatas(1), ColumnData)).StartX + 2F)))), .Y = CInt((CDec((CSng(propertyItem.Index) * Me.ItemHeight)))), .Width = CInt((CDec(((TryCast(Me.ColumnDatas(1), ColumnData)).Width - 1F)))), .Height = CInt((CDec(Me.ItemHeight))) })
					num += 1
				Loop While num < Me.Items.Count
			End If
		End Sub

		Public Sub SetVariable(type As __Pointer(Of GClass), var As __Pointer(Of Void), measures As __Pointer(Of GMeasures))
			Me.SetVariable(type, var, measures, True)
		End Sub

		Public Sub SetVariable(type As __Pointer(Of GClass), var As __Pointer(Of Void), measures As __Pointer(Of GMeasures), <MarshalAs(UnmanagedType.U1)> reset As Boolean)
			Dim ptr As __Pointer(Of GMeasures) = <Module>.new(52UI)
			Dim measures2 As __Pointer(Of GMeasures)
			If ptr IsNot Nothing Then
				cpblk(ptr, measures, 52)
				measures2 = ptr
			Else
				measures2 = Nothing
			End If
			Me.Measures = measures2
			MyBase.SuspendLayout()
			Dim arrayList As ArrayList = Nothing
			If Me.Items.Count <> 0 Then
				Do
					Dim propertyItem As PropertyItem = TryCast(Me.Items(Me.Items.Count - 1), PropertyItem)
					If Not reset AndAlso propertyItem.CanBeExpanded() Then
						Dim itemStatus As ItemStatus = New ItemStatus()
						itemStatus.Name = propertyItem.GetName()
						itemStatus.Type = propertyItem.IdentifyType()
						itemStatus.Expanded = propertyItem.Expanded
						If arrayList Is Nothing Then
							arrayList = New ArrayList()
						End If
						arrayList.Add(itemStatus)
					End If
					propertyItem.DestroyControl()
					Me.Items.RemoveAt(Me.Items.Count - 1)
				Loop While Me.Items.Count <> 0
			End If
			If type IsNot Nothing AndAlso var IsNot Nothing Then
				Dim propertyItem2 As PropertyItem = PropertyItem.MakeProperty(Nothing, Nothing, type, var, 0, 0, 0, 0)
				If Not propertyItem2.CanBeExpanded() Then
					<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0BM@KKOJMHJP@?4?2controls?2PropertyTree?4cpp?$AA@), __Pointer(Of SByte)), 111, CType((AddressOf <Module>.??_C@_0CJ@KLAPHJA@NControls?3?3PropertyTreeCore?3?3Set@), __Pointer(Of SByte)))
					<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0CF@JFNPDDOC@The?5passed?5type?5should?5be?5expand@), __Pointer(Of SByte)))
				End If
				Dim num As Integer = 0
				Me.AddSubitems(propertyItem2.Expand(), 0, num, arrayList)
			End If
			MyBase.ResumeLayout()
			Me.UpdateViewHeight()
		End Sub

		Public Sub RegenerateSubtree(index As Integer)
			MyBase.SuspendLayout()
			Dim propertyItem As PropertyItem = TryCast(Me.Items(index), PropertyItem)
			If propertyItem.Expanded Then
				Dim num As Integer = index + 1
				If num < Me.Items.Count Then
					Do
						Dim propertyItem2 As PropertyItem = TryCast(Me.Items(index + 1), PropertyItem)
						If propertyItem2.IndentDepth <= propertyItem.IndentDepth Then
							Exit Do
						End If
						propertyItem2.DestroyControl()
						Me.Items.RemoveAt(index + 1)
					Loop While num < Me.Items.Count
				End If
			End If
			If propertyItem.CanBeExpanded() AndAlso (propertyItem.Expanded OrElse propertyItem.ShouldBeExpanded()) Then
				Dim num2 As Integer = index + 1
				Me.AddSubitems(propertyItem.Expand(), propertyItem.IndentDepth + 1, num2)
				propertyItem.Expanded = True
			Else
				propertyItem.Expanded = False
			End If
			Me.UpdateSubitems(index + 1)
			MyBase.ResumeLayout()
			Me.UpdateViewHeight()
		End Sub

		Public Sub InvalidateViewControl()
			Me.ViewControl.Invalidate()
		End Sub

		Public Sub RaiseItemChanged()
			Me.raise_ItemChanged()
		End Sub

		Public Function GetViewControlWidth() As Integer
			Return Me.ViewControl.Width
		End Function

		Public Overrides Sub ColumnsResized()
			Me.ViewControl.Refresh()
			Me.UpdateSubitems(0)
		End Sub

		Public Sub EnsureSelectedVisible()
			If CSng(Me.SelectedIndex) * Me.ItemHeight < CSng(MyBase.StartY) Then
				MyBase.StartY = CInt((CDec((CSng(Me.SelectedIndex) * Me.ItemHeight))))
			Else
				Dim num As Single = CSng(Me.SelectedIndex) * Me.ItemHeight - CSng(MyBase.StartY)
				If num > CSng(MyBase.Height) - Me.ItemHeight Then
					Dim num2 As Single = CSng(Me.SelectedIndex) * Me.ItemHeight
					MyBase.StartY = CInt((CDec((num2 - CSng(MyBase.Height) + Me.ItemHeight))))
				End If
			End If
			Me.ViewControl.Invalidate()
			If Me.DescLabel IsNot Nothing AndAlso Me.Items.Count <> 0 Then
				Dim propertyItem As PropertyItem = TryCast(Me.Items(Me.SelectedIndex), PropertyItem)
				Me.DescLabel.Text = propertyItem.GetDescription()
			End If
		End Sub

		Public Sub UpdateViewHeight()
			MyBase.ViewHeight = CInt((CDec((CSng(Me.propItems.Count) * Me.ItemHeight + 1F))))
		End Sub

		Public Overrides Sub Refresh()
			If Me.Items IsNot Nothing Then
				Me.UpdateSubitems(0)
			End If
			Me.ViewControl.Refresh()
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

		Protected Overrides Function IsInputKey(keyData As Keys) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return True
		End Function

		Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
			If e.KeyCode = Keys.Up Then
				If Me.SelectedIndex > 0 Then
					Me.SelectedIndex -= 1
					Me.EnsureSelectedVisible()
				End If
				e.Handled = True
			Else If e.KeyCode = Keys.Down Then
				If Me.SelectedIndex < Me.Items.Count - 1 Then
					Me.SelectedIndex += 1
					Me.EnsureSelectedVisible()
				End If
				e.Handled = True
			Else If e.KeyCode = Keys.Home Then
				Me.SelectedIndex = 0
				Me.EnsureSelectedVisible()
				e.Handled = True
			Else If e.KeyCode = Keys.[End] Then
				If Me.Items.Count > 0 Then
					Me.SelectedIndex = Me.Items.Count - 1
					Me.EnsureSelectedVisible()
				End If
				e.Handled = True
			Else If e.KeyCode = Keys.Prior Then
				Dim num As Single = CSng(Me.SelectedIndex)
				Dim num2 As Integer = CInt((CDec((num - CSng(MyBase.Height) / Me.ItemHeight + 1F))))
				If num2 >= 0 Then
					Me.SelectedIndex = num2
				Else
					Me.SelectedIndex = 0
				End If
				Me.EnsureSelectedVisible()
				e.Handled = True
			Else If e.KeyCode = Keys.[Next] Then
				Dim num3 As Integer = CInt((CDec((CSng(MyBase.Height) / Me.ItemHeight + CSng(Me.SelectedIndex) - 1F))))
				If num3 < Me.Items.Count Then
					Me.SelectedIndex = num3
				Else
					Me.SelectedIndex = Me.Items.Count - 1
				End If
				Me.EnsureSelectedVisible()
				e.Handled = True
			Else If e.KeyCode = Keys.[Return] Then
				e.Handled = True
				If Me.SelectedIndex >= 0 AndAlso Not(TryCast(Me.Items(Me.SelectedIndex), PropertyItem)).OnEnterPressed() Then
					Me.ViewControlDoubleClick(Me, Nothing)
				End If
			Else If e.KeyCode = Keys.Space Then
				e.Handled = True
				Me.ViewControlDoubleClick(Me, Nothing)
			End If
			MyBase.OnKeyDown(e)
		End Sub

		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			MyBase.OnSizeChanged(e)
		End Sub

		Protected Overrides Sub OnGotFocus(e As EventArgs)
			Me.ViewControl.Invalidate()
		End Sub

		Protected Sub OnItemCopy(item As PropertyItem)
			Dim num As UInteger = CUInt((__Dereference(CType((Me.Clipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer)))))
			If num <> 0UI Then
				Dim ptr As __Pointer(Of GStream) = num
				Dim arg_19_0 As Object = calli(System.Void* modopt(System.Runtime.CompilerServices.CallConvThiscall)(System.IntPtr,System.UInt32), ptr, 1, __Dereference((__Dereference(CType(ptr, __Pointer(Of Integer))))))
				__Dereference(CType((Me.Clipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))) = 0
			End If
			__Dereference(CType(Me.Clipboard, __Pointer(Of Integer))) = item.IdentifyType()
			Dim ptr2 As __Pointer(Of GStreamBuffer) = <Module>.new(36UI)
			Dim ptr3 As __Pointer(Of GStreamBuffer)
			Try
				If ptr2 IsNot Nothing Then
					ptr3 = <Module>.GStreamBuffer.{ctor}(ptr2)
				Else
					ptr3 = 0
				End If
			Catch 
				<Module>.delete(CType(ptr2, __Pointer(Of Void)))
				Throw
			End Try
			__Dereference(CType((Me.Clipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))) = ptr3
			item.SaveToBuffer(__Dereference(CType((Me.Clipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))))
		End Sub

		Protected Sub OnItemPaste(item As PropertyItem)
			item.LoadFromBuffer(__Dereference(CType((Me.Clipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))))
			item.Refresh()
		End Sub

		Private Sub InitializeComponent()
			Me.Font = New Font("Tahoma", 8.25F)
		End Sub

		Private Sub ViewControlPaint(sender As Object, e As PaintEventArgs)
			Dim num As Integer = 0
			If 0 < Me.Items.Count Then
				Do
					Dim clip As Rectangle = Nothing
					clip.X = 0
					clip.Y = 0
					clip.Width = Me.ViewControl.Width
					clip.Height = Me.ViewControl.Height
					e.Graphics.SetClip(clip)
					Dim propertyItem As PropertyItem = TryCast(Me.Items(num), PropertyItem)
					propertyItem.Index = num
					Dim rect As Rectangle = Nothing
					Dim rect2 As Rectangle = Nothing
					rect.X = CInt((CDec((TryCast(Me.ColumnDatas(0), ColumnData)).StartX)))
					rect.Y = CInt((CDec((CSng(propertyItem.Index) * Me.ItemHeight))))
					rect.Width = CInt((CDec((TryCast(Me.ColumnDatas(0), ColumnData)).Width)))
					rect.Height = CInt((CDec(Me.ItemHeight)))
					clip.X = rect.X
					clip.Y = rect.Y
					clip.Width = rect.Width - 2
					clip.Height = rect.Height
					rect2.X = CInt((CDec((TryCast(Me.ColumnDatas(1), ColumnData)).StartX)))
					rect2.Y = rect.Y
					rect2.Width = CInt((CDec((TryCast(Me.ColumnDatas(1), ColumnData)).Width)))
					rect2.Height = rect.Height
					Dim brush As Brush
					Dim brush2 As Brush
					If propertyItem.Index = Me.SelectedIndex Then
						If Me.Focused Then
							brush = Me.FocusSelectedItemBackgroundBrush
							brush2 = Me.FocusSelectedItemTextBrush
						Else
							brush = Me.SelectedItemBackgroundBrush
							brush2 = Me.SelectedItemTextBrush
						End If
					Else
						brush = Me.NormalItemBackgroundBrush
						brush2 = Me.NormalItemTextBrush
					End If
					e.Graphics.FillRectangle(brush, rect)
					e.Graphics.DrawRectangle(Me.ItemBorderPen, rect)
					e.Graphics.DrawRectangle(Me.ItemBorderPen, rect2)
					e.Graphics.SetClip(clip)
					rect.X = propertyItem.IndentDepth * Me.IndentWidth + rect.X + 3
					If propertyItem.Expanded Then
						Dim rect3 As Rectangle = Nothing
						rect3.X = rect.X
						rect3.Y = CInt((CDec((CSng(rect.Y) + Me.ItemHeight * 0.5F - 4F))))
						rect3.Width = 9
						rect3.Height = 9
						e.Graphics.FillRectangle(brush2, rect3)
						rect3.X += 1
						rect3.Y += 1
						rect3.Width = 7
						rect3.Height = 7
						e.Graphics.FillRectangle(brush, rect3)
						rect3.X += 1
						rect3.Y += 3
						rect3.Width = 5
						rect3.Height = 1
						e.Graphics.FillRectangle(brush2, rect3)
						Dim point As PointF = New PointF(CSng((rect.X + 10)), CSng((rect.Y + 2)))
						e.Graphics.DrawString(propertyItem.GetName(), Me.Font, brush2, point)
					Else If propertyItem.CanBeExpanded() Then
						Dim rect4 As Rectangle = Nothing
						rect4.X = rect.X
						rect4.Y = CInt((CDec((CSng(rect.Y) + Me.ItemHeight * 0.5F - 4F))))
						rect4.Width = 9
						rect4.Height = 9
						e.Graphics.FillRectangle(brush2, rect4)
						rect4.X += 1
						rect4.Y += 1
						rect4.Width = 7
						rect4.Height = 7
						e.Graphics.FillRectangle(brush, rect4)
						rect4.X += 1
						rect4.Y += 3
						rect4.Width = 5
						rect4.Height = 1
						e.Graphics.FillRectangle(brush2, rect4)
						rect4.X += 2
						rect4.Y -= 2
						rect4.Width = 1
						rect4.Height = 5
						e.Graphics.FillRectangle(brush2, rect4)
						Dim point2 As PointF = New PointF(CSng((rect.X + 10)), CSng((rect.Y + 2)))
						e.Graphics.DrawString(propertyItem.GetNameWithMeasure(), Me.Font, brush2, point2)
					Else
						Dim point3 As PointF = New PointF(CSng((rect.X + 10)), CSng((rect.Y + 2)))
						e.Graphics.DrawString(propertyItem.GetNameWithMeasure(), Me.Font, brush2, point3)
					End If
					num += 1
				Loop While num < Me.Items.Count
			End If
		End Sub

		Private Sub ViewControlMouseDown(sender As Object, e As MouseEventArgs)
			Me.SelectedIndex = CInt((CDec((CSng((e.Y - 1)) / Me.ItemHeight))))
			Me.EnsureSelectedVisible()
			Dim num As Integer = (TryCast(Me.Items(Me.SelectedIndex), PropertyItem)).IndentDepth * Me.IndentWidth + 2
			If e.X >= num AndAlso e.X < num + 10 Then
				Me.ExpandItem(Me.SelectedIndex)
				Me.IsDblClickEnabled = False
				Me.ForbidDblClickTimer.Enabled = True
			End If
		End Sub

		Private Sub ViewControlMouseUp(sender As Object, e As MouseEventArgs)
			If e.Button = MouseButtons.Right Then
				Me.SelectedIndex = CInt((CDec((CSng((e.Y - 1)) / Me.ItemHeight))))
				Me.EnsureSelectedVisible()
				Dim propertyItem As PropertyItem = TryCast(Me.Items(Me.SelectedIndex), PropertyItem)
				Dim num As Single = CSng(e.X)
				If num < (TryCast(Me.ColumnDatas(0), ColumnData)).Width Then
					Me.LocalMenu.MenuItems.Clear()
					If propertyItem.GetContextMenu() IsNot Nothing Then
						Me.LocalMenu.MergeMenu(propertyItem.GetContextMenu())
					End If
					If propertyItem.GetEditContextMenu() IsNot Nothing AndAlso Me.Clipboard IsNot Nothing Then
						Me.LocalMenu.MenuItems.Add("-")
						Me.LocalMenu.MergeMenu(propertyItem.GetEditContextMenu())
						Dim clipboard As __Pointer(Of NPropertyClipboard) = Me.Clipboard
						Dim enabled As Byte
						If __Dereference(CType((clipboard + 4 / __SizeOf(NPropertyClipboard)), __Pointer(Of Integer))) <> 0 AndAlso __Dereference(CType(clipboard, __Pointer(Of Integer))) = propertyItem.IdentifyType() Then
							enabled = 1
						Else
							enabled = 0
						End If
						Me.LocalMenu.MenuItems(Me.LocalMenu.MenuItems.Count - 1).Enabled = (enabled <> 0)
						AddHandler propertyItem.Copy, Me.ItemCopyHandler
						AddHandler propertyItem.Paste, Me.ItemPasteHandler
					End If
					Dim location As Point = Me.ViewControl.Location
					Dim location2 As Point = Me.ViewControl.Location
					Dim pos As Point = New Point(e.X + location2.X, e.Y + location.Y)
					Me.LocalMenu.Show(Me, pos)
				End If
			End If
		End Sub

		Private Sub EnableDblClick(source As Object, __unnamed001 As ElapsedEventArgs)
			Me.IsDblClickEnabled = True
			Me.ForbidDblClickTimer.Enabled = False
		End Sub

		Private Sub ViewControlDoubleClick(sender As Object, e As EventArgs)
			If Me.IsDblClickEnabled AndAlso Me.SelectedIndex >= 0 Then
				Me.ExpandItem(Me.SelectedIndex)
			End If
		End Sub

		Private Sub ExpandItem(index As Integer)
			Dim propertyItem As PropertyItem = TryCast(Me.Items(index), PropertyItem)
			If propertyItem.Expanded Then
				MyBase.SuspendLayout()
				Dim num As Integer = index + 1
				If num < Me.Items.Count Then
					Do
						Dim propertyItem2 As PropertyItem = TryCast(Me.Items(index + 1), PropertyItem)
						If propertyItem2.IndentDepth <= propertyItem.IndentDepth Then
							Exit Do
						End If
						propertyItem2.DestroyControl()
						Me.Items.RemoveAt(index + 1)
					Loop While num < Me.Items.Count
				End If
				Me.UpdateSubitems(index + 1)
				MyBase.ResumeLayout()
				propertyItem.Expanded = False
				Me.UpdateViewHeight()
			Else If propertyItem.CanBeExpanded() Then
				MyBase.SuspendLayout()
				Dim num2 As Integer = index + 1
				Dim num3 As Integer = num2
				Me.AddSubitems(propertyItem.Expand(), propertyItem.IndentDepth + 1, num3)
				Me.UpdateSubitems(num2)
				MyBase.ResumeLayout()
				propertyItem.Expanded = True
				Me.UpdateViewHeight()
			End If
		End Sub

		Protected Sub raise_ItemChanged()
			Dim itemChanged As PropertyTreeCore.__Delegate_ItemChanged = Me.ItemChanged
			If itemChanged IsNot Nothing Then
				itemChanged()
			End If
		End Sub

		Protected Sub raise_SelectedIndexChanged()
			Dim selectedIndexChanged As PropertyTreeCore.__Delegate_SelectedIndexChanged = Me.SelectedIndexChanged
			If selectedIndexChanged IsNot Nothing Then
				selectedIndexChanged()
			End If
		End Sub

		Protected Sub raise_TrackSelected(i1 As NCurveEditor)
			Dim trackSelected As PropertyTreeCore.TrackSelectedHandler = Me.TrackSelected
			If trackSelected IsNot Nothing Then
				trackSelected(i1)
			End If
		End Sub
	End Class
End Namespace
