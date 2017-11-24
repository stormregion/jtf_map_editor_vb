Imports Script_GlobalVariable_Header
Imports Script_GlobalVariable_ListItem
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace Script_GlobalVariable
	Public Class Script_GlobalVariableControl
		Inherits UserControl

		Public Enum eSortMode
			SORT_Descending = 2
			SORT_Ascending = 1
			SORT_Unsorted = 0
		End Enum

		Private Enum eMode
			MODE_ColumnResize = 1
			MODE_Normal = 0
		End Enum

		Private mMode As Script_GlobalVariableControl.eMode

		Private mHeaderHeight As Integer

		Private mRowHeight As Integer

		Private mDrawGrid As Boolean

		Private mColumnHeaders As Script_GlobalVariableControl_Header()

		Private mItems As Script_GlobalVariableControl_ListItem()

		Private mSortMode As Script_GlobalVariableControl.eSortMode

		Private mSortColumn As Integer

		Private mSortIndices As Integer()

		Private mFirstDisplayed As Integer

		Private mSelectedIndex As Integer

		Private mMaxRows As Integer

		Private mClickedIndex As Integer

		Private mClickedColumnIndex As Integer

		Private mColumnToResize As Integer

		Private mColumnResizeMouseX As Integer

		Private mFrameSize As Integer

		Private Pen_Dark As Pen

		Private Pen_DarkDark As Pen

		Private Pen_Light As Pen

		Private Pen_LightLight As Pen

		Private Font As Font

		Private Brush_Selection As Brush

		Private Brush_Selection_Focus As Brush

		Private Brush_Header As Brush

		Private Brush_Header_Focus As Brush

		Private Brush_Header_Text As Brush

		Private Brush_Header_Text_Focus As Brush

		Private Brush_Text As Brush

		Private Brush_Text_Focus As Brush

		Private Brush_Text_Highlight As Brush

		Private Brush_Text_Highlight_Focus As Brush

		Private VertScrollBar As VScrollBar

		Private components As Container

		Public Custom Event SortModeChanged As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.SortModeChanged = [Delegate].Combine(Me.SortModeChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.SortModeChanged = [Delegate].Remove(Me.SortModeChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event ItemDoubleClicked As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.ItemDoubleClicked = [Delegate].Combine(Me.ItemDoubleClicked, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.ItemDoubleClicked = [Delegate].Remove(Me.ItemDoubleClicked, value)
			End RemoveHandler
		End Event

		Public Custom Event ItemClicked As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.ItemClicked = [Delegate].Combine(Me.ItemClicked, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.ItemClicked = [Delegate].Remove(Me.ItemClicked, value)
			End RemoveHandler
		End Event

		Public Custom Event DragStarted As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.DragStarted = [Delegate].Combine(Me.DragStarted, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.DragStarted = [Delegate].Remove(Me.DragStarted, value)
			End RemoveHandler
		End Event

		Public Custom Event SelectedIndexChanged As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.SelectedIndexChanged = [Delegate].Combine(Me.SelectedIndexChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.SelectedIndexChanged = [Delegate].Remove(Me.SelectedIndexChanged, value)
			End RemoveHandler
		End Event

		Public ReadOnly Property ClickedColumnIndex() As Integer
			Get
				Return Me.mClickedColumnIndex
			End Get
		End Property

		Public ReadOnly Property ClickedIndex() As Integer
			Get
				Return Me.mClickedIndex
			End Get
		End Property

		Public Property SelectedIndex() As Integer
			Get
				Dim num As Integer = Me.mSelectedIndex
				If num = -1 Then
					Return -1
				End If
				Return Me.mSortIndices(num)
			End Get
			Set(value As Integer)
				Dim num As Integer = 0
				Dim array As Integer() = Me.mSortIndices
				Dim num2 As Integer = array.Length
				If 0 < num2 Then
					While array(num) <> value
						num += 1
						If num >= Me.mSortIndices.Length Then
							Exit While
						End If
					End While
				End If
				If num = num2 Then
					num = 0
				End If
				Dim num3 As Integer = Me.mItems.Length
				If num3 = 0 Then
					num = -1
				Else If num < 0 Then
					num = 0
				Else If num >= num3 Then
					num = num3 - 1
				End If
				If Me.mFirstDisplayed > num Then
					If num <> -1 AndAlso Me.mMaxRows < num2 Then
						Me.mFirstDisplayed = num
					Else
						Me.mFirstDisplayed = 0
					End If
				End If
				Dim num4 As Integer = Me.mMaxRows
				If Me.mFirstDisplayed + num4 <= num Then
					Me.mFirstDisplayed = num - num4 + 1
				End If
				If Me.mSelectedIndex <> num Then
					Me.mSelectedIndex = num
					Me.UpdateScrollbar()
					MyBase.Invalidate()
					Me.raise_SelectedIndexChanged(Me, New EventArgs())
				End If
			End Set
		End Property

		Public Property RealSelectedIndex() As Integer
			Get
				Return Me.mSelectedIndex
			End Get
			Set(value As Integer)
				Dim num As Integer = Me.mItems.Length
				If num = 0 Then
					value = -1
				Else If value < 0 Then
					value = 0
				Else If value >= num Then
					value = num - 1
				End If
				If Me.mFirstDisplayed > value Then
					If value <> -1 AndAlso Me.mMaxRows < Me.mSortIndices.Length Then
						Me.mFirstDisplayed = value
					Else
						Me.mFirstDisplayed = 0
					End If
				End If
				Dim num2 As Integer = Me.mMaxRows
				If Me.mFirstDisplayed + num2 <= value Then
					Me.mFirstDisplayed = value - num2 + 1
				End If
				If Me.mSelectedIndex <> value Then
					Me.mSelectedIndex = value
					MyBase.Invalidate()
					Me.UpdateScrollbar()
					Me.raise_SelectedIndexChanged(Me, New EventArgs())
				End If
			End Set
		End Property

		Public Property DrawGrid() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return Me.mDrawGrid
			End Get
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				Me.mDrawGrid = value
				MyBase.Invalidate()
			End Set
		End Property

		Public Property HeaderHeight() As Integer
			Get
				Return Me.mHeaderHeight
			End Get
			Set(value As Integer)
				Me.mHeaderHeight = value
				If value < 10 Then
					Me.mHeaderHeight = 10
				End If
				MyBase.Invalidate()
			End Set
		End Property

		Public Property RowHeight() As Integer
			Get
				Return Me.mRowHeight
			End Get
			Set(value As Integer)
				Me.mRowHeight = value
				If value < 10 Then
					Me.mRowHeight = 10
				End If
				MyBase.Invalidate()
			End Set
		End Property

		Public ReadOnly Property SortIndices() As Integer()
			Get
				Return Me.mSortIndices
			End Get
		End Property

		Public Property Items() As Script_GlobalVariableControl_ListItem()
			Get
				Return Me.mItems
			End Get
			Set(value As Script_GlobalVariableControl_ListItem())
				Dim selectedIndex As Integer = Me.SelectedIndex
				Me.mItems = value
				Me.mSortIndices = New Integer(value.Length - 1) {}
				Me.Sort(False)
				Dim num As Integer = Me.RealSelectedIndex
				Dim num2 As Integer = Me.mItems.Length
				If num2 = 0 Then
					num = -1
				Else If num >= num2 Then
					num = num2 - 1
				Else If num = -1 Then
					num = 0
				End If
				If selectedIndex <> -1 Then
					Dim num3 As Integer = 0
					Dim array As Integer() = Me.mSortIndices
					Dim num4 As Integer = array.Length
					If 0 < num4 Then
						While array(num3) <> selectedIndex
							num3 += 1
							If num3 >= Me.mSortIndices.Length Then
								Exit While
							End If
						End While
					End If
					If num3 <> num4 Then
						num = num3
					End If
				End If
				Dim num5 As Integer
				If Me.mSelectedIndex = num AndAlso (num = -1 OrElse Me.mSortIndices(num) = selectedIndex) Then
					num5 = 0
				Else
					num5 = 1
				End If
				Dim flag As Boolean = CByte(num5) <> 0
				Me.mSelectedIndex = num
				If Me.mFirstDisplayed > num Then
					If num <> -1 AndAlso Me.mMaxRows < Me.mSortIndices.Length Then
						Me.mFirstDisplayed = num
					Else
						Me.mFirstDisplayed = 0
					End If
				End If
				MyBase.Invalidate()
				Me.UpdateScrollbar()
				If flag Then
					Me.raise_SelectedIndexChanged(Me, New EventArgs())
				End If
			End Set
		End Property

		Public Property ColumnHeaders() As Script_GlobalVariableControl_Header()
			Get
				Return Me.mColumnHeaders
			End Get
			Set(value As Script_GlobalVariableControl_Header())
				Me.mColumnHeaders = value
				MyBase.Invalidate()
			End Set
		End Property

		Public Sub New()
			Me.SelectedIndexChanged = Nothing
			Me.DragStarted = Nothing
			Me.ItemClicked = Nothing
			Me.ItemDoubleClicked = Nothing
			Me.SortModeChanged = Nothing
			Me.InitializeComponent()
			Me.mColumnHeaders = New Script_GlobalVariableControl_Header(-1) {}
			Me.mItems = New Script_GlobalVariableControl_ListItem(-1) {}
			Me.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Unsorted
			Me.mSortColumn = 0
			Me.mSortIndices = New Integer(-1) {}
			Me.mHeaderHeight = 18
			Me.mRowHeight = 14
			Me.mFirstDisplayed = 0
			Me.mSelectedIndex = -1
			Me.mDrawGrid = False
			Me.mFrameSize = 2
			Me.mMaxRows = 0
			Me.mMode = Script_GlobalVariableControl.eMode.MODE_Normal
			MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
			MyBase.UpdateStyles()
			Me.Pen_Dark = SystemPens.ControlDark
			Me.Pen_DarkDark = SystemPens.ControlDarkDark
			Me.Pen_Light = SystemPens.ControlLight
			Me.Pen_LightLight = SystemPens.ControlLightLight
			Dim color As Color = Color.FromKnownColor(KnownColor.LightGray)
			Me.Brush_Header = New SolidBrush(color)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.MediumBlue)
			Me.Brush_Header_Focus = New SolidBrush(color2)
			Dim color3 As Color = Color.FromKnownColor(KnownColor.ControlText)
			Me.Brush_Header_Text = New SolidBrush(color3)
			Dim color4 As Color = Color.FromKnownColor(KnownColor.HighlightText)
			Me.Brush_Header_Text_Focus = New SolidBrush(color4)
			Dim color5 As Color = Color.FromKnownColor(KnownColor.DarkGray)
			Me.Brush_Selection = New SolidBrush(color5)
			Me.Brush_Selection_Focus = SystemBrushes.Highlight
			Dim color6 As Color = Color.FromKnownColor(KnownColor.ControlText)
			Me.Brush_Text = New SolidBrush(color6)
			Dim color7 As Color = Color.FromKnownColor(KnownColor.ControlText)
			Me.Brush_Text_Focus = New SolidBrush(color7)
			Dim color8 As Color = Color.FromKnownColor(KnownColor.HighlightText)
			Me.Brush_Text_Highlight = New SolidBrush(color8)
			Dim color9 As Color = Color.FromKnownColor(KnownColor.HighlightText)
			Me.Brush_Text_Highlight_Focus = New SolidBrush(color9)
			Me.Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0)
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
			Me.VertScrollBar = New VScrollBar()
			MyBase.SuspendLayout()
			Me.VertScrollBar.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right)
			Dim location As Point = New Point(212, 0)
			Me.VertScrollBar.Location = location
			Me.VertScrollBar.Name = "VertScrollBar"
			Dim size As Size = New Size(16, 176)
			Me.VertScrollBar.Size = size
			Me.VertScrollBar.TabIndex = 0
			AddHandler Me.VertScrollBar.ValueChanged, AddressOf Me.VertScrollBar_ValueChanged
			AddHandler Me.VertScrollBar.Scroll, AddressOf Me.VertScrollBar_Scroll
			Dim window As Color = SystemColors.Window
			Me.BackColor = window
			MyBase.Controls.Add(Me.VertScrollBar)
			MyBase.Name = "Script_GlobalVariableControl"
			Dim size2 As Size = New Size(228, 176)
			MyBase.Size = size2
			AddHandler MyBase.SizeChanged, AddressOf Me.Script_GlobalVariableControl_Update
			AddHandler MyBase.Enter, AddressOf Me.Script_GlobalVariableControl_Update
			AddHandler MyBase.MouseUp, AddressOf Me.Script_GlobalVariableControl_MouseUp
			AddHandler MyBase.Paint, AddressOf Me.Script_GlobalVariableControl_Paint
			AddHandler MyBase.KeyDown, AddressOf Me.Script_GlobalVariableControl_KeyDown
			AddHandler MyBase.Leave, AddressOf Me.Script_GlobalVariableControl_Update
			AddHandler MyBase.MouseMove, AddressOf Me.Script_GlobalVariableControl_MouseMove
			AddHandler MyBase.MouseWheel, AddressOf Me.Script_GlobalVariableControl_MouseWheel
			AddHandler MyBase.MouseDown, AddressOf Me.Script_GlobalVariableControl_MouseDown
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub GetClickedRect(rect As __Pointer(Of Rectangle))
			rect.Y = (Me.mClickedIndex - Me.mFirstDisplayed) * Me.mRowHeight + Me.mHeaderHeight + Me.mFrameSize
			rect.Height = Me.mRowHeight
			rect.X = Me.mFrameSize
			Dim num As Integer = 0
			If 0 < Me.mClickedColumnIndex Then
				Do
					rect.X = Me.mColumnHeaders(num).Width + rect.X
					num += 1
				Loop While num < Me.mClickedColumnIndex
			End If
			rect.Width = Me.mColumnHeaders(Me.mClickedColumnIndex).Width
		End Sub

		Public Function IsInOriginalOrder() As<MarshalAs(UnmanagedType.U1)>
		Boolean
			If Me.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Unsorted Then
				Return True
			End If
			Dim num As Integer = 0
			Dim array As Integer() = Me.mSortIndices
			Dim num2 As Integer = array.Length
			If 0 < num2 Then
				While array(num) = num
					num += 1
					If num >= num2 Then
						Return True
					End If
				End While
				Return False
			End If
			Return True
		End Function

		Public Sub ForceUnsorted()
			Me.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Unsorted
			Me.Sort(True)
		End Sub

		Protected Overrides Function IsInputKey(key As Keys) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return key >= Keys.Left AndAlso key <= Keys.Down
		End Function

		Private Sub Script_GlobalVariableControl_Paint(sender As Object, e As PaintEventArgs)
			Dim graphics As Graphics = e.Graphics
			Dim clientRectangle As Rectangle = MyBase.ClientRectangle
			clientRectangle.Width -= Me.VertScrollBar.Width
			clientRectangle.X += Me.mFrameSize
			clientRectangle.Y += Me.mFrameSize
			clientRectangle.Width -= Me.mFrameSize << 1
			clientRectangle.Height -= Me.mFrameSize << 1
			Dim width As Integer = clientRectangle.Width
			clientRectangle.Width = width - 1
			Dim height As Integer = clientRectangle.Height
			clientRectangle.Height = height - 1
			Dim brush As Brush
			Dim brush2 As Brush
			Dim brush3 As Brush
			Dim brush4 As Brush
			Dim brush5 As Brush
			If Me.Focused Then
				brush = Me.Brush_Selection_Focus
				brush2 = Me.Brush_Header_Focus
				brush3 = Me.Brush_Header_Text_Focus
				brush4 = Me.Brush_Text_Focus
				brush5 = Me.Brush_Text_Highlight_Focus
			Else
				brush = Me.Brush_Selection
				brush2 = Me.Brush_Header
				brush3 = Me.Brush_Header_Text
				brush4 = Me.Brush_Text
				brush5 = Me.Brush_Text_Highlight
			End If
			If Me.Items.Length <> 0 Then
				Dim num As Integer = (Me.RealSelectedIndex - Me.mFirstDisplayed) * Me.mRowHeight
				Dim num2 As Integer = clientRectangle.Top + Me.mHeaderHeight + num
				If num2 < clientRectangle.Bottom Then
					graphics.FillRectangle(brush, clientRectangle.Left, num2, clientRectangle.Width, Me.mRowHeight)
				End If
			End If
			graphics.FillRectangle(brush2, clientRectangle.Left, clientRectangle.Top, clientRectangle.Width, Me.mHeaderHeight)
			Dim num3 As Integer = clientRectangle.Left
			Dim top As Integer = clientRectangle.Top
			Dim num4 As Integer = Me.mHeaderHeight + top - 1
			Dim format As StringFormat = New StringFormat()
			Dim num5 As Integer = 0
			If 0 < Me.mColumnHeaders.Length Then
				Do
					If num3 < clientRectangle.Right Then
						Dim array As Script_GlobalVariableControl_Header() = Me.mColumnHeaders
						Dim num6 As Integer
						If num5 + 1 = array.Length Then
							num6 = clientRectangle.Right - num3
						Else
							num6 = array(num5).Width
						End If
						Dim num7 As Integer = num3 + num6 - 1
						graphics.DrawLine(Me.Pen_LightLight, num3, top, num7, top)
						graphics.DrawLine(Me.Pen_LightLight, num3, top, num3, num4)
						graphics.DrawLine(Me.Pen_Dark, num3 + 1, num4, num7, num4)
						graphics.DrawLine(Me.Pen_Dark, num7, top + 1, num7, num4)
						If Me.mColumnHeaders(num5).Text IsNot Nothing Then
							Dim layoutRectangle As RectangleF = New RectangleF(CSng((num3 + 2)), CSng(((Me.mHeaderHeight - Me.Font.Height) / 2 + top)), CSng((num6 - 4)), CSng(Me.Font.Height))
							graphics.DrawString(Me.mColumnHeaders(num5).Text, Me.Font, brush3, layoutRectangle, format)
						End If
						Dim eSortMode As Script_GlobalVariableControl.eSortMode = Me.mSortMode
						If eSortMode <> Script_GlobalVariableControl.eSortMode.SORT_Unsorted AndAlso Me.mSortColumn = num5 Then
							Dim y As Integer
							If eSortMode = Script_GlobalVariableControl.eSortMode.SORT_Ascending Then
								y = num4 - 5
							Else
								y = top + 5
							End If
							Dim x As Integer = (num7 * 2 - 14) / 2
							Dim y2 As Integer = (num4 + top) / 2
							graphics.DrawLine(Me.Pen_LightLight, num7 - 10, y2, x, y)
							graphics.DrawLine(Me.Pen_LightLight, num7 - 4, y2, x, y)
						End If
						num3 = num7 + 1
					End If
					num5 += 1
				Loop While num5 < Me.mColumnHeaders.Length
			End If
			num4 += 1
			If Me.mDrawGrid Then
				Dim num8 As Integer = clientRectangle.Left
				Dim num9 As Integer = 0
				If 1 < Me.mColumnHeaders.Length Then
					Do
						If num8 < clientRectangle.Right Then
							num8 = Me.mColumnHeaders(num9).Width + num8
							graphics.DrawLine(Me.Pen_Light, num8, num4, num8, clientRectangle.Bottom)
						End If
						num9 += 1
					Loop While num9 + 1 < Me.mColumnHeaders.Length
				End If
				Dim num10 As Integer = (clientRectangle.Height - Me.mHeaderHeight) / Me.mRowHeight
				Dim num11 As Integer = clientRectangle.Top + Me.mHeaderHeight
				If 0 < num10 Then
					Dim num12 As UInteger = CUInt(num10)
					Do
						num11 = Me.RowHeight + num11
						graphics.DrawLine(Me.Pen_Light, clientRectangle.Left, num11, clientRectangle.Right, num11)
						num12 -= 1UI
					Loop While num12 > 0UI
				End If
			End If
			If Me.Items.Length <> 0 Then
				Dim num13 As Integer = Me.mFirstDisplayed
				Dim i As Integer = clientRectangle.Top + Me.mHeaderHeight
				If num13 < Me.Items.Length Then
					While i < clientRectangle.Bottom
						Dim script_GlobalVariableControl_ListItem As Script_GlobalVariableControl_ListItem = Me.mItems(Me.mSortIndices(num13))
						Dim num14 As Integer = clientRectangle.Left
						Dim j As Integer = 0
						If 0 < Me.mColumnHeaders.Length Then
							While j < script_GlobalVariableControl_ListItem.SubItems.Length
								If script_GlobalVariableControl_ListItem.SubItems(j).Text IsNot Nothing AndAlso num14 < clientRectangle.Right Then
									Dim array2 As Script_GlobalVariableControl_Header() = Me.mColumnHeaders
									Dim num15 As Integer
									If j + 1 = array2.Length Then
										num15 = clientRectangle.Right - num14
									Else
										num15 = array2(j).Width
									End If
									Dim brush6 As Brush
									If num13 = Me.RealSelectedIndex Then
										brush6 = brush5
									Else
										brush6 = brush4
									End If
									Dim layoutRectangle2 As RectangleF = New RectangleF(CSng((num14 + 2)), CSng(((Me.mRowHeight - Me.Font.Height) / 2 + i)), CSng((num15 - 4)), CSng(Me.Font.Height))
									graphics.DrawString(script_GlobalVariableControl_ListItem.SubItems(j).Text, Me.Font, brush6, layoutRectangle2, format)
								End If
								Dim array3 As Script_GlobalVariableControl_Header() = Me.mColumnHeaders
								Dim arg_534_0 As Script_GlobalVariableControl_Header = array3(j)
								j += 1
								num14 = arg_534_0.Width + num14
								If j >= array3.Length Then
									Exit While
								End If
							End While
						End If
						i = Me.mRowHeight + i
						num13 += 1
						If num13 >= Me.Items.Length Then
							Exit While
						End If
					End While
				End If
			End If
			clientRectangle.X -= Me.mFrameSize
			clientRectangle.Y -= Me.mFrameSize
			clientRectangle.Width = Me.mFrameSize * 2 + clientRectangle.Width
			clientRectangle.Height = Me.mFrameSize * 2 + clientRectangle.Height
			graphics.DrawLine(Me.Pen_Dark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Right, clientRectangle.Top)
			graphics.DrawLine(Me.Pen_DarkDark, clientRectangle.Left, clientRectangle.Top + 1, clientRectangle.Right - 1, clientRectangle.Top + 1)
			graphics.DrawLine(Me.Pen_Dark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Left, clientRectangle.Bottom)
			graphics.DrawLine(Me.Pen_DarkDark, clientRectangle.Left + 1, clientRectangle.Top, clientRectangle.Left + 1, clientRectangle.Bottom - 1)
			graphics.DrawLine(Me.Pen_LightLight, clientRectangle.Left + 1, clientRectangle.Bottom, clientRectangle.Right - 1, clientRectangle.Bottom)
			graphics.DrawLine(Me.Pen_Light, clientRectangle.Left + 2, clientRectangle.Bottom - 1, clientRectangle.Right - 1, clientRectangle.Bottom - 1)
			graphics.DrawLine(Me.Pen_LightLight, clientRectangle.Right, clientRectangle.Top + 1, clientRectangle.Right, clientRectangle.Bottom)
			graphics.DrawLine(Me.Pen_Light, clientRectangle.Right - 1, clientRectangle.Top + 2, clientRectangle.Right - 1, clientRectangle.Bottom)
		End Sub

		Private Sub Script_GlobalVariableControl_KeyDown(sender As Object, e As KeyEventArgs)
			If Me.RealSelectedIndex <> -1 Then
				Select Case e.KeyCode
					Case Keys.Prior
						If Me.RealSelectedIndex > 0 Then
							Dim num As Integer = Me.mMaxRows
							If Me.RealSelectedIndex >= num Then
								Dim num2 As Integer = Me.mSelectedIndex - num
								If Me.mFirstDisplayed > num2 Then
									Me.mFirstDisplayed = num2
								End If
								Me.RealSelectedIndex = num2
							Else
								Me.mFirstDisplayed = 0
								Me.RealSelectedIndex = 0
							End If
						End If
						e.Handled = True
					Case Keys.[Next]
						If Me.RealSelectedIndex + 1 < Me.Items.Length Then
							Dim num3 As Integer = Me.mMaxRows
							Dim num4 As Integer
							If num3 + Me.RealSelectedIndex + 1 < Me.Items.Length Then
								num4 = Me.RealSelectedIndex + num3
							Else
								num4 = Me.Items.Length - 1
							End If
							If num4 - Me.mFirstDisplayed >= num3 Then
								Me.mFirstDisplayed = num4 - num3 + 1
							End If
							Me.RealSelectedIndex = num4
						End If
						e.Handled = True
					Case Keys.[End]
						If Me.RealSelectedIndex + 1 < Me.Items.Length Then
							Dim num5 As Integer = Me.Items.Length - 1
							Dim num6 As Integer = Me.mMaxRows
							If num5 - Me.mFirstDisplayed >= num6 Then
								Me.mFirstDisplayed = num5 - num6 + 1
							End If
							Me.RealSelectedIndex = num5
						End If
						e.Handled = True
					Case Keys.Home
						If Me.RealSelectedIndex > 0 Then
							Me.mFirstDisplayed = 0
							Me.RealSelectedIndex = 0
						End If
						e.Handled = True
					Case Keys.Up
						If Me.RealSelectedIndex > 0 Then
							Dim num7 As Integer = Me.mSelectedIndex - 1
							If Me.mFirstDisplayed > num7 Then
								Me.mFirstDisplayed = num7
							End If
							Me.RealSelectedIndex = num7
						End If
						e.Handled = True
					Case Keys.Down
						If Me.RealSelectedIndex + 1 < Me.Items.Length Then
							Dim num8 As Integer = Me.mSelectedIndex + 1
							Dim num9 As Integer = Me.mFirstDisplayed
							If num8 - num9 = Me.mMaxRows Then
								Me.mFirstDisplayed = num9 + 1
							End If
							Me.RealSelectedIndex = num8
						End If
						e.Handled = True
				End Select
			End If
		End Sub

		Private Sub Script_GlobalVariableControl_Update(sender As Object, e As EventArgs)
			If MyBase.ClientRectangle.Height > Me.mFrameSize * 2 + Me.mHeaderHeight Then
				Dim num As Integer = (MyBase.ClientRectangle.Height - (Me.mFrameSize << 1) - Me.mHeaderHeight) / Me.mRowHeight
				Me.mMaxRows = num
				Dim realSelectedIndex As Integer = Me.RealSelectedIndex
				If realSelectedIndex <> -1 Then
					Dim num2 As Integer = Me.mItems.Length
					If num >= num2 Then
						Me.mFirstDisplayed = 0
					Else
						Dim num3 As Integer = num + Me.mFirstDisplayed
						If num3 <= realSelectedIndex Then
							Me.mFirstDisplayed = realSelectedIndex - num + 1
						Else If num3 > num2 Then
							Me.mFirstDisplayed = num2 - num
						End If
					End If
				End If
				Dim num4 As Integer = 0
				Dim num5 As Integer = 0
				Dim array As Script_GlobalVariableControl_Header() = Me.mColumnHeaders
				If 0 < array.Length Then
					Dim num6 As Integer = Me.mColumnHeaders.Length
					Do
						num4 = array(num5).Width + num4
						num5 += 1
					Loop While num5 < num6
				End If
				num4 = MyBase.ClientRectangle.Width - num4 - Me.VertScrollBar.Width
				If num4 <> 0 Then
					Dim script_GlobalVariableControl_Header As Script_GlobalVariableControl_Header = Me.mColumnHeaders(0)
					num4 = script_GlobalVariableControl_Header.Width + num4
					If num4 < 40 Then
						num4 = 40
					End If
					script_GlobalVariableControl_Header.Width = num4
				End If
			Else
				Me.mMaxRows = 0
				Me.mFirstDisplayed = 0
			End If
			Me.UpdateScrollbar()
			MyBase.Invalidate()
		End Sub

		Private Sub Script_GlobalVariableControl_MouseDown(sender As Object, e As MouseEventArgs)
			If Me.mColumnHeaders.Length <> 0 AndAlso e.Button = MouseButtons.Left Then
				Dim clientRectangle As Rectangle = MyBase.ClientRectangle
				clientRectangle.Width -= Me.VertScrollBar.Width
				clientRectangle.X += Me.mFrameSize
				clientRectangle.Y += Me.mFrameSize
				clientRectangle.Width -= Me.mFrameSize << 1
				clientRectangle.Height -= Me.mFrameSize << 1
				Dim num As Integer = e.X
				Dim y As Integer = e.Y
				If clientRectangle.Contains(num, y) Then
					num -= Me.mFrameSize
					Dim num2 As Integer = 0
					Dim array As Script_GlobalVariableControl_Header() = Me.mColumnHeaders
					Dim num3 As Integer = array.Length
					If 0 < num3 Then
						Do
							Dim script_GlobalVariableControl_Header As Script_GlobalVariableControl_Header = array(num2)
							If num < script_GlobalVariableControl_Header.Width Then
								Exit Do
							End If
							Dim script_GlobalVariableControl_Header2 As Script_GlobalVariableControl_Header = script_GlobalVariableControl_Header
							num2 += 1
							num -= script_GlobalVariableControl_Header2.Width
						Loop While num2 < Me.mColumnHeaders.Length
					End If
					If num2 = num3 Then
						num2 = num3 - 1
						num = 5
					End If
					If(num2 <> 0 AndAlso num <= 4) OrElse (num2 + 1 < num3 AndAlso num + 4 >= array(num2).Width) Then
						Me.mMode = Script_GlobalVariableControl.eMode.MODE_ColumnResize
						If num <= 4 Then
							Me.mColumnToResize = num2 - 1
						Else
							Me.mColumnToResize = num2
						End If
						Me.mColumnResizeMouseX = e.X
						MyBase.Capture = True
						Me.Cursor = Cursors.SizeWE
						MyBase.Invalidate()
					Else If y < clientRectangle.Y + Me.mHeaderHeight Then
						If Me.mItems.Length <> 0 Then
							If num2 = Me.mSortColumn Then
								Dim eSortMode As Script_GlobalVariableControl.eSortMode = Me.mSortMode
								If eSortMode <> Script_GlobalVariableControl.eSortMode.SORT_Unsorted Then
									If eSortMode <> Script_GlobalVariableControl.eSortMode.SORT_Ascending Then
										If eSortMode = Script_GlobalVariableControl.eSortMode.SORT_Descending Then
											Me.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Unsorted
										End If
									Else
										Me.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Descending
									End If
								Else
									Me.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Ascending
								End If
							Else
								Me.mSortMode = Script_GlobalVariableControl.eSortMode.SORT_Ascending
								Me.mSortColumn = num2
							End If
							Me.Sort(True)
							MyBase.Invalidate()
						End If
					Else
						Dim num4 As Integer = (y - clientRectangle.Y - Me.mHeaderHeight) / Me.mRowHeight + Me.mFirstDisplayed
						If num4 < Me.mItems.Length Then
							Me.mClickedColumnIndex = num2
							Me.mClickedIndex = num4
							Me.raise_ItemClicked(Me, New EventArgs())
							If e.Clicks = 2 Then
								Me.raise_ItemDoubleClicked(Me, New EventArgs())
							End If
							Dim num5 As Integer = Me.mFirstDisplayed
							If num4 - num5 = Me.mMaxRows Then
								Me.mFirstDisplayed = num5 + 1
							End If
							Me.RealSelectedIndex = num4
							If e.Clicks = 1 Then
								Me.raise_DragStarted(Me, New EventArgs())
							End If
						End If
					End If
				End If
			End If
		End Sub

		Private Sub Script_GlobalVariableControl_MouseMove(sender As Object, e As MouseEventArgs)
			Dim array As Script_GlobalVariableControl_Header() = Me.mColumnHeaders
			If array.Length <> 0 Then
				Dim eMode As Script_GlobalVariableControl.eMode = Me.mMode
				If eMode <> Script_GlobalVariableControl.eMode.MODE_Normal Then
					If eMode = Script_GlobalVariableControl.eMode.MODE_ColumnResize Then
						Dim num As Integer = array(Me.mColumnToResize).Width - Me.mColumnResizeMouseX
						Dim num2 As Integer = e.X + num
						If num2 < 5 Then
							num2 = 5
						Else
							Dim num3 As Integer = 0
							Dim num4 As Integer = 0
							If 0 < Me.mColumnToResize Then
								array = Me.mColumnHeaders
								Dim num5 As Integer = Me.mColumnToResize
								Do
									num3 = array(num4).Width + num3
									num4 += 1
								Loop While num4 < num5
							End If
							Dim num6 As Integer = MyBase.ClientRectangle.Width - (Me.mFrameSize << 1) - Me.VertScrollBar.Width
							If num3 + num2 > num6 Then
								num2 = num6 - num3
							End If
						End If
						Dim num7 As Integer = Me.mColumnToResize
						array = Me.mColumnHeaders
						Me.mColumnResizeMouseX = num2 - array(num7).Width + Me.mColumnResizeMouseX
						array(num7).Width = num2
						MyBase.Invalidate()
					End If
				Else
					Dim clientRectangle As Rectangle = MyBase.ClientRectangle
					clientRectangle.Width -= Me.VertScrollBar.Width
					clientRectangle.X += Me.mFrameSize
					clientRectangle.Y += Me.mFrameSize
					clientRectangle.Width -= Me.mFrameSize << 1
					clientRectangle.Height -= Me.mFrameSize << 1
					Dim num8 As Integer = e.X
					Dim y As Integer = e.Y
					If clientRectangle.Contains(num8, y) Then
						num8 -= Me.mFrameSize
						Dim num9 As Integer = 0
						array = Me.mColumnHeaders
						Dim num10 As Integer = array.Length
						If 0 < num10 Then
							Do
								Dim script_GlobalVariableControl_Header As Script_GlobalVariableControl_Header = array(num9)
								If num8 < script_GlobalVariableControl_Header.Width Then
									Exit Do
								End If
								Dim script_GlobalVariableControl_Header2 As Script_GlobalVariableControl_Header = script_GlobalVariableControl_Header
								num9 += 1
								num8 -= script_GlobalVariableControl_Header2.Width
							Loop While num9 < Me.mColumnHeaders.Length
						End If
						If num9 = num10 Then
							num9 = num10 - 1
							num8 = 5
						End If
						If(num9 <> 0 AndAlso num8 <= 4) OrElse (num9 + 1 < num10 AndAlso num8 + 4 >= array(num9).Width) Then
							Me.Cursor = Cursors.SizeWE
							Return
						End If
					End If
					Me.Cursor = Cursors.[Default]
				End If
			End If
		End Sub

		Private Sub Script_GlobalVariableControl_MouseUp(sender As Object, e As MouseEventArgs)
			If Me.mMode = Script_GlobalVariableControl.eMode.MODE_ColumnResize AndAlso e.Button = MouseButtons.Left Then
				Me.mMode = Script_GlobalVariableControl.eMode.MODE_Normal
				MyBase.Capture = False
				Me.Cursor = Cursors.[Default]
				MyBase.Invalidate()
			End If
		End Sub

		Private Sub Script_GlobalVariableControl_MouseWheel(sender As Object, e As MouseEventArgs)
			Dim num As Integer = e.Delta * SystemInformation.MouseWheelScrollLines / 120
			If num <> 0 Then
				If num > 0 Then
					If Me.RealSelectedIndex > 0 Then
						If Me.RealSelectedIndex >= num Then
							Dim num2 As Integer = Me.mSelectedIndex - num
							If Me.mFirstDisplayed > num2 Then
								Me.mFirstDisplayed = num2
							End If
							Me.RealSelectedIndex = num2
						Else
							Me.mFirstDisplayed = 0
							Me.RealSelectedIndex = 0
						End If
					End If
				Else
					num = -num
					If Me.RealSelectedIndex + 1 < Me.Items.Length Then
						Dim num3 As Integer
						If num + Me.RealSelectedIndex + 1 < Me.Items.Length Then
							num3 = Me.RealSelectedIndex + num
						Else
							num3 = Me.Items.Length - 1
						End If
						Dim num4 As Integer = Me.mMaxRows
						If num3 - Me.mFirstDisplayed >= num4 Then
							Me.mFirstDisplayed = num3 - num4 + 1
						End If
						Me.RealSelectedIndex = num3
					End If
				End If
			End If
		End Sub

		Private Sub VertScrollBar_Scroll(sender As Object, e As ScrollEventArgs)
			Dim value As Integer = Me.VertScrollBar.Value
			If value <> Me.mFirstDisplayed Then
				Me.mFirstDisplayed = value
				If Me.RealSelectedIndex <> -1 Then
					Dim realSelectedIndex As Integer = Me.RealSelectedIndex
					If realSelectedIndex < value Then
						Me.RealSelectedIndex = value
					Else
						Dim num As Integer = Me.mMaxRows
						If realSelectedIndex >= num + value Then
							Me.RealSelectedIndex = value + num - 1
						End If
					End If
				End If
				MyBase.Invalidate()
			End If
		End Sub

		Private Sub VertScrollBar_ValueChanged(sender As Object, e As EventArgs)
			Dim value As Integer = Me.VertScrollBar.Value
			If value <> Me.mFirstDisplayed Then
				Me.mFirstDisplayed = value
				If Me.RealSelectedIndex <> -1 Then
					Dim realSelectedIndex As Integer = Me.RealSelectedIndex
					If realSelectedIndex < value Then
						Me.RealSelectedIndex = value
					Else
						Dim num As Integer = Me.mMaxRows
						If realSelectedIndex >= num + value Then
							Me.RealSelectedIndex = value + num - 1
						End If
					End If
				End If
				MyBase.Invalidate()
			End If
		End Sub

		Private Sub Sort(<MarshalAs(UnmanagedType.U1)> [event] As Boolean)
			Dim num As Integer = 0
			If 0 < Me.mItems.Length Then
				Do
					Dim arg_16_0 As Integer() = Me.mSortIndices
					Dim expr_15 As Integer = num
					arg_16_0(expr_15) = expr_15
					num += 1
				Loop While num < Me.mItems.Length
			End If
			Dim eSortMode As Script_GlobalVariableControl.eSortMode = Me.mSortMode
			If eSortMode <> Script_GlobalVariableControl.eSortMode.SORT_Ascending Then
				If eSortMode = Script_GlobalVariableControl.eSortMode.SORT_Descending Then
					Dim num2 As Integer = 1
					If 1 < Me.mItems.Length Then
						Do
							Dim num3 As Integer = 0
							If 0 < num2 Then
								Do
									Dim array As Integer() = Me.mSortIndices
									Dim array2 As Script_GlobalVariableControl_ListItem() = Me.mItems
									Dim script_GlobalVariableControl_ListItem As Script_GlobalVariableControl_ListItem = array2(array(num2))
									Dim script_GlobalVariableControl_ListItem2 As Script_GlobalVariableControl_ListItem = array2(array(num3))
									Dim num4 As Integer = Me.mSortColumn
									If(script_GlobalVariableControl_ListItem.SubItems.Length > num4 OrElse script_GlobalVariableControl_ListItem2.SubItems.Length > num4) AndAlso script_GlobalVariableControl_ListItem.SubItems.Length > num4 Then
										If script_GlobalVariableControl_ListItem2.SubItems.Length > num4 Then
											Dim arg_D8_0 As String = script_GlobalVariableControl_ListItem.SubItems(num4).Text
											Dim text As String = script_GlobalVariableControl_ListItem2.SubItems(num4).Text
											If String.Compare(arg_D8_0, text) <= 0 Then
												GoTo IL_102
											End If
										End If
										array = Me.mSortIndices
										Dim num5 As Integer = array(num2)
										array(num2) = array(num3)
										Me.mSortIndices(num3) = num5
									End If
									IL_102:
									num3 += 1
								Loop While num3 < num2
							End If
							num2 += 1
						Loop While num2 < Me.mItems.Length
					End If
				End If
			Else
				Dim num6 As Integer = 1
				If 1 < Me.mItems.Length Then
					Do
						Dim num7 As Integer = 0
						If 0 < num6 Then
							Do
								Dim array3 As Integer() = Me.mSortIndices
								Dim array4 As Script_GlobalVariableControl_ListItem() = Me.mItems
								Dim script_GlobalVariableControl_ListItem3 As Script_GlobalVariableControl_ListItem = array4(array3(num6))
								Dim script_GlobalVariableControl_ListItem4 As Script_GlobalVariableControl_ListItem = array4(array3(num7))
								Dim num8 As Integer = Me.mSortColumn
								If(script_GlobalVariableControl_ListItem3.SubItems.Length > num8 OrElse script_GlobalVariableControl_ListItem4.SubItems.Length > num8) AndAlso script_GlobalVariableControl_ListItem3.SubItems.Length > num8 Then
									If script_GlobalVariableControl_ListItem4.SubItems.Length > num8 Then
										Dim arg_1B2_0 As String = script_GlobalVariableControl_ListItem3.SubItems(num8).Text
										Dim text2 As String = script_GlobalVariableControl_ListItem4.SubItems(num8).Text
										If String.Compare(arg_1B2_0, text2) >= 0 Then
											GoTo IL_1D8
										End If
									End If
									array3 = Me.mSortIndices
									Dim num9 As Integer = array3(num6)
									array3(num6) = array3(num7)
									Me.mSortIndices(num7) = num9
								End If
								IL_1D8:
								num7 += 1
							Loop While num7 < num6
						End If
						num6 += 1
					Loop While num6 < Me.mItems.Length
				End If
			End If
			If [event] Then
				Me.UpdateScrollbar()
				Me.raise_SelectedIndexChanged(Me, New EventArgs())
				Me.raise_SortModeChanged(Me, New EventArgs())
			End If
		End Sub

		Private Sub UpdateScrollbar()
			Me.VertScrollBar.Minimum = 0
			Dim num As Integer = Me.mMaxRows
			If num <> 0 AndAlso num < Me.mItems.Length Then
				Me.VertScrollBar.LargeChange = num - 1
				Me.VertScrollBar.Maximum = Me.mItems.Length - 2
				Me.VertScrollBar.Value = Me.mFirstDisplayed
			Else
				Me.VertScrollBar.Maximum = 0
				Me.VertScrollBar.Value = 0
			End If
		End Sub

		Protected Sub raise_SelectedIndexChanged(i1 As Object, i2 As EventArgs)
			Dim selectedIndexChanged As EventHandler = Me.SelectedIndexChanged
			If selectedIndexChanged IsNot Nothing Then
				selectedIndexChanged(i1, i2)
			End If
		End Sub

		Protected Sub raise_DragStarted(i1 As Object, i2 As EventArgs)
			Dim dragStarted As EventHandler = Me.DragStarted
			If dragStarted IsNot Nothing Then
				dragStarted(i1, i2)
			End If
		End Sub

		Protected Sub raise_ItemClicked(i1 As Object, i2 As EventArgs)
			Dim itemClicked As EventHandler = Me.ItemClicked
			If itemClicked IsNot Nothing Then
				itemClicked(i1, i2)
			End If
		End Sub

		Protected Sub raise_ItemDoubleClicked(i1 As Object, i2 As EventArgs)
			Dim itemDoubleClicked As EventHandler = Me.ItemDoubleClicked
			If itemDoubleClicked IsNot Nothing Then
				itemDoubleClicked(i1, i2)
			End If
		End Sub

		Protected Sub raise_SortModeChanged(i1 As Object, i2 As EventArgs)
			Dim sortModeChanged As EventHandler = Me.SortModeChanged
			If sortModeChanged IsNot Nothing Then
				sortModeChanged(i1, i2)
			End If
		End Sub
	End Class
End Namespace
