Imports Script_ActionListTree_Node
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Timers
Imports System.Windows.Forms

Namespace Script_ActionListTree
	Public Class Script_ActionListTreeControl
		Inherits UserControl

		Public Enum eEditingType
			EDITING_MAX = 2
			EDITING_ListSelection = 1
			EDITING_Number = 0
		End Enum

		Private mRootNode As ActionListTreeControl_Node

		Private mFirstDisplayNode As ActionListTreeControl_Node

		Private mSelectedNode As ActionListTreeControl_Node

		Private mSelectedNode_End As ActionListTreeControl_Node

		Private mMouseTargetNode As ActionListTreeControl_Node

		Private mMouseTargetTextElement As ActionListTreeControl_Node_TextElement

		Private mRowHeight As Integer

		Private mDepthTab As Integer

		Private mFrameSize As Integer

		Private mSpaceWidth As Integer

		Private mMaxRows As Integer

		Private mSelectedRow As Integer

		Private mSelectedBeginExtended As Integer

		Private mSelectedEndExtended As Integer

		Private MouseLeftHeld As Boolean

		Private ScrollTimer As System.Timers.Timer

		Private mEditingType As Script_ActionListTreeControl.eEditingType

		Private mEditedText As String

		Private mEditingStringList As String()

		Private mEditingList_X As Integer

		Private mEditingList_Y As Integer

		Private mEditingList_Y_Up As Integer

		Private mEditingList_Width As Integer

		Private mEditingList_MaxDisplayed As Integer

		Private mEditingList_FirstDisplayed As Integer

		Private mEditingList_Selected As Integer

		Private components As Container

		Public Custom Event ListSelectingFinished As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.ListSelectingFinished = [Delegate].Combine(Me.ListSelectingFinished, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.ListSelectingFinished = [Delegate].Remove(Me.ListSelectingFinished, value)
			End RemoveHandler
		End Event

		Public Custom Event TextEditingFinished As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.TextEditingFinished = [Delegate].Combine(Me.TextEditingFinished, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.TextEditingFinished = [Delegate].Remove(Me.TextEditingFinished, value)
			End RemoveHandler
		End Event

		Public Custom Event TextEditingRequest As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.TextEditingRequest = [Delegate].Combine(Me.TextEditingRequest, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.TextEditingRequest = [Delegate].Remove(Me.TextEditingRequest, value)
			End RemoveHandler
		End Event

		Public Custom Event MouseTargetOnDrop As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.MouseTargetOnDrop = [Delegate].Combine(Me.MouseTargetOnDrop, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.MouseTargetOnDrop = [Delegate].Remove(Me.MouseTargetOnDrop, value)
			End RemoveHandler
		End Event

		Public Custom Event MouseTargetDoubleClicked As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.MouseTargetDoubleClicked = [Delegate].Combine(Me.MouseTargetDoubleClicked, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.MouseTargetDoubleClicked = [Delegate].Remove(Me.MouseTargetDoubleClicked, value)
			End RemoveHandler
		End Event

		Public Custom Event MouseTargetChanged As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.MouseTargetChanged = [Delegate].Combine(Me.MouseTargetChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.MouseTargetChanged = [Delegate].Remove(Me.MouseTargetChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event ExpandChanged As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.ExpandChanged = [Delegate].Combine(Me.ExpandChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.ExpandChanged = [Delegate].Remove(Me.ExpandChanged, value)
			End RemoveHandler
		End Event

		Public Custom Event SelectionChanged As EventHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.SelectionChanged = [Delegate].Combine(Me.SelectionChanged, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.SelectionChanged = [Delegate].Remove(Me.SelectionChanged, value)
			End RemoveHandler
		End Event

		Public ReadOnly Property ListSelection_Selected() As Integer
			Get
				Return Me.mEditingList_Selected
			End Get
		End Property

		Public ReadOnly Property EditedText() As String
			Get
				Return Me.mEditedText
			End Get
		End Property

		Public ReadOnly Property EditingType() As Script_ActionListTreeControl.eEditingType
			Get
				Return Me.mEditingType
			End Get
		End Property

		Public ReadOnly Property Editing() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return(If((Me.mEditingType <> Script_ActionListTreeControl.eEditingType.EDITING_MAX), 1, 0)) <> 0
			End Get
		End Property

		Public ReadOnly Property MouseTargetTextElement() As ActionListTreeControl_Node_TextElement
			Get
				Return Me.mMouseTargetTextElement
			End Get
		End Property

		Public ReadOnly Property MouseTargetNode() As ActionListTreeControl_Node
			Get
				Return Me.mMouseTargetNode
			End Get
		End Property

		Public ReadOnly Property SelectedNode_End() As ActionListTreeControl_Node
			Get
				Return Me.mSelectedNode_End
			End Get
		End Property

		Public ReadOnly Property SelectedNode() As ActionListTreeControl_Node
			Get
				Return Me.mSelectedNode
			End Get
		End Property

		Public ReadOnly Property RootNode() As ActionListTreeControl_Node
			Get
				Return Me.mRootNode
			End Get
		End Property

		Public Sub New()
			Me.SelectionChanged = Nothing
			Me.ExpandChanged = Nothing
			Me.MouseTargetChanged = Nothing
			Me.MouseTargetDoubleClicked = Nothing
			Me.MouseTargetOnDrop = Nothing
			Me.TextEditingRequest = Nothing
			Me.TextEditingFinished = Nothing
			Me.ListSelectingFinished = Nothing
			Me.InitializeComponent()
			Dim actionListTreeControl_Node As ActionListTreeControl_Node = New ActionListTreeControl_Node("<*ROOT*>", False)
			Me.mRootNode = actionListTreeControl_Node
			actionListTreeControl_Node.Expand()
			Dim actionListTreeControl_Node2 As ActionListTreeControl_Node = Me.mRootNode
			Me.mFirstDisplayNode = actionListTreeControl_Node2
			Me.mSelectedNode = actionListTreeControl_Node2
			Me.mSelectedNode_End = actionListTreeControl_Node2
			Me.mFrameSize = 2
			Me.mSpaceWidth = 3
			Me.mRowHeight = 16
			Me.mDepthTab = 16
			Me.mMaxRows = 0
			Me.mSelectedRow = 0
			Me.mMouseTargetNode = Nothing
			Me.mMouseTargetTextElement = Nothing
			Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
			Me.MouseLeftHeld = False
			Me.ScrollTimer = Nothing
			Me.AllowDrop = True
			MyBase.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer, True)
			MyBase.UpdateStyles()
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
			Me.AllowDrop = True
			Dim window As Color = SystemColors.Window
			Me.BackColor = window
			MyBase.Name = "Script_ActionListTreeControl"
			Dim size As Size = New Size(228, 176)
			MyBase.Size = size
			AddHandler MyBase.SizeChanged, AddressOf Me.Script_ActionListTreeControl_Update
			AddHandler MyBase.Enter, AddressOf Me.Script_ActionListTreeControl_Update
			AddHandler MyBase.MouseUp, AddressOf Me.Script_ActionListTreeControl_MouseUp
			AddHandler MyBase.Paint, AddressOf Me.Script_ActionListTreeControl_Paint
			AddHandler MyBase.DragDrop, AddressOf Me.Script_ActionListTreeControl_DragDrop
			AddHandler MyBase.KeyDown, AddressOf Me.Script_ActionListTreeControl_KeyDown
			AddHandler MyBase.Leave, AddressOf Me.Script_ActionListTreeControl_Update
			AddHandler MyBase.DragOver, AddressOf Me.Script_ActionListTreeControl_DragOver
			AddHandler MyBase.MouseMove, AddressOf Me.Script_ActionListTreeControl_MouseMove
			AddHandler MyBase.MouseWheel, AddressOf Me.Script_ActionListTreeControl_MouseWheel
			AddHandler MyBase.MouseDown, AddressOf Me.Script_ActionListTreeControl_MouseDown
		End Sub

		Public Sub StartTextEditing(s As String)
			Me.mEditedText = s
			Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_Number
			MyBase.Capture = True
			MyBase.Invalidate()
		End Sub

		Public Sub StartListSelecting(stringlist As String())
			Me.mEditingStringList = stringlist
			Me.mEditingList_MaxDisplayed = 10
			Me.mEditingList_FirstDisplayed = 0
			Me.mEditingList_Selected = 0
			Me.mEditingList_Width = 0
			Me.mEditedText = stringlist(0)
			Dim num As Integer = stringlist.Length
			If num < 10 Then
				Me.mEditingList_MaxDisplayed = num
			End If
			Me.mEditingList_X = Me.mMouseTargetTextElement.GetArea().X
			Me.mEditingList_Y_Up = Me.mMouseTargetTextElement.GetArea().Y
			Me.mEditingList_Y = Me.mMouseTargetTextElement.GetArea().Bottom
			Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection
			MyBase.Capture = True
			MyBase.Invalidate()
		End Sub

		Public Sub StopListSelecting()
			Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
			Me.mEditingStringList = Nothing
			MyBase.Capture = False
			MyBase.Invalidate()
		End Sub

		Public Sub Dirty(<MarshalAs(UnmanagedType.U1)> reset As Boolean)
			MyBase.Invalidate()
			If MyBase.Capture Then
				MyBase.Capture = False
			End If
			Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
			If reset Then
				Dim treeNext As ActionListTreeControl_Node = Me.GetTreeNext(Me.mRootNode)
				Me.mSelectedNode = treeNext
				Me.mSelectedNode_End = treeNext
				Me.mFirstDisplayNode = treeNext
				Me.mMouseTargetNode = Nothing
				Me.mMouseTargetTextElement = Nothing
				Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
				Me.raise_SelectionChanged(Me, New EventArgs())
				Me.raise_MouseTargetChanged(Me, New EventArgs())
			End If
		End Sub

		Public Function GetTreePrev(node As ActionListTreeControl_Node) As ActionListTreeControl_Node
			If node Is Nothing Then
				Return Nothing
			End If
			If node.Prev IsNot Nothing Then
				If node.Prev.Expanded AndAlso node.Prev.GetNumberOfNodes() <> 0 Then
					node = node.Prev
					If node.Expanded Then
						While node.GetNumberOfNodes() <> 0
							Dim expr_43 As ActionListTreeControl_Node = node
							node = expr_43.GetNode(expr_43.GetNumberOfNodes() - 1)
							If Not node.Expanded Then
								Exit While
							End If
						End While
					End If
					If node.GetNumberOfHeaderNodes() <> 0 Then
						Dim expr_63 As ActionListTreeControl_Node = node
						Return expr_63.GetHeaderNode(expr_63.GetNumberOfHeaderNodes() - 1)
					End If
					Return node
				Else
					If node.Prev.GetNumberOfHeaderNodes() <> 0 Then
						Return node.Prev.GetHeaderNode(node.Prev.GetNumberOfHeaderNodes() - 1)
					End If
					Return node.Prev
				End If
			Else
				If Not node.HeaderNode AndAlso node.Parent.GetNumberOfHeaderNodes() <> 0 Then
					Return node.Parent.GetHeaderNode(node.Parent.GetNumberOfHeaderNodes() - 1)
				End If
				If node.Parent IsNot Nothing AndAlso node.Parent IsNot Me.mRootNode Then
					Return node.Parent
				End If
				Return Nothing
			End If
		End Function

		Public Function GetTreeNext(node As ActionListTreeControl_Node, steps As Integer) As ActionListTreeControl_Node
			If node Is Me.mRootNode Then
				node = Me.GetTreeNext(node)
			End If
			If node IsNot Nothing Then
				While steps <> 0
					node = Me.GetTreeNext(node)
					steps -= 1
					If node Is Nothing Then
						Exit While
					End If
				End While
			End If
			Return node
		End Function

		Public Function GetTreeNext(node As ActionListTreeControl_Node) As ActionListTreeControl_Node
			If node Is Nothing Then
				Return Nothing
			End If
			Dim flag As Boolean = True
			While True
				If flag Then
					If node.GetNumberOfHeaderNodes() <> 0 Then
						Exit While
					End If
					If node.Expanded AndAlso node.GetNumberOfNodes() <> 0 Then
						GoTo IL_68
					End If
				End If
				If node.[Next] IsNot Nothing Then
					GoTo IL_70
				End If
				If node.Parent Is Nothing Then
					GoTo IL_84
				End If
				If node.HeaderNode AndAlso node.Parent.Expanded AndAlso node.Parent.GetNumberOfNodes() <> 0 Then
					GoTo IL_77
				End If
				flag = False
				node = node.Parent
			End While
			Return node.GetHeaderNode(0)
			IL_68:
			Return node.GetNode(0)
			IL_70:
			Return node.[Next]
			IL_77:
			Return node.Parent.GetNode(0)
			IL_84:
			Return Nothing
		End Function

		Public Function GetTreeNext_OpenNoHeader(node As ActionListTreeControl_Node) As ActionListTreeControl_Node
			If node IsNot Nothing AndAlso Not node.HeaderNode Then
				Dim flag As Boolean = True
				While Not flag OrElse node.GetNumberOfNodes() = 0
					If node.[Next] IsNot Nothing Then
						Return node.[Next]
					End If
					If node.Parent Is Nothing Then
						Return Nothing
					End If
					flag = False
					node = node.Parent
				End While
				Return node.GetNode(0)
			End If
			Return Nothing
		End Function

		Public Sub GetSelectionInfos(firstdisplayed As __Pointer(Of Integer), selrow As __Pointer(Of Integer))
			Dim treeNext As ActionListTreeControl_Node = Me.GetTreeNext(Me.mRootNode)
			__Dereference(firstdisplayed) = 0
			__Dereference(selrow) = 0
			If treeNext IsNot Nothing Then
				While treeNext IsNot Me.mSelectedNode
					If treeNext Is Me.mFirstDisplayNode Then
						__Dereference(firstdisplayed) = __Dereference(selrow)
					End If
					__Dereference(selrow) += 1
					treeNext = Me.GetTreeNext(treeNext)
					If treeNext Is Nothing Then
						Exit While
					End If
				End While
			End If
			If treeNext Is Me.mFirstDisplayNode Then
				__Dereference(firstdisplayed) = __Dereference(selrow)
			End If
		End Sub

		Public Sub SetSelectionInfos(firstdisplayed As Integer, selrow As Integer)
			Dim actionListTreeControl_Node As ActionListTreeControl_Node = Me.GetTreeNext(Me.mRootNode)
			If firstdisplayed > selrow Then
				firstdisplayed = selrow
			End If
			Dim num As Integer = Me.mMaxRows
			If num + firstdisplayed < selrow Then
				firstdisplayed = selrow - num + 1
			End If
			Me.mFirstDisplayNode = Me.mRootNode
			Dim num2 As Integer = 0
			If 0 < selrow Then
				While actionListTreeControl_Node IsNot Nothing
					If num2 = firstdisplayed Then
						Me.mFirstDisplayNode = actionListTreeControl_Node
					End If
					Dim treeNext As ActionListTreeControl_Node = Me.GetTreeNext(actionListTreeControl_Node)
					If treeNext Is Nothing Then
						Exit While
					End If
					actionListTreeControl_Node = treeNext
					num2 += 1
					If num2 >= selrow Then
						Exit While
					End If
				End While
			End If
			If num2 = firstdisplayed Then
				Me.mFirstDisplayNode = actionListTreeControl_Node
			End If
			Me.mSelectedNode = actionListTreeControl_Node
			Me.mSelectedNode_End = actionListTreeControl_Node
			Me.mSelectedBeginExtended = actionListTreeControl_Node.ActionIndex
			Me.mSelectedEndExtended = actionListTreeControl_Node.ActionIndex
			Me.mSelectedRow = num2 - firstdisplayed
			Me.mMouseTargetNode = Nothing
			Me.mMouseTargetTextElement = Nothing
			Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
			If MyBase.Capture Then
				MyBase.Capture = False
			End If
			Me.raise_SelectionChanged(Me, New EventArgs())
			Me.raise_MouseTargetChanged(Me, New EventArgs())
			MyBase.Invalidate()
		End Sub

		Public Sub SetSelectionExtendedInfos(selbeginext As Integer, selendext As Integer)
			Me.mSelectedBeginExtended = selbeginext
			Me.mSelectedEndExtended = selendext
			MyBase.Invalidate()
		End Sub

		Protected Overrides Function IsInputKey(key As Keys) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			Return key >= Keys.Left AndAlso key <= Keys.Down
		End Function

		Private Sub Script_ActionListTreeControl_Paint(sender As Object, e As PaintEventArgs)
			Dim graphics As Graphics = e.Graphics
			Dim clientRectangle As Rectangle = MyBase.ClientRectangle
			Dim num As Integer = -Me.mFrameSize
			Dim expr_1C As Integer = num
			clientRectangle.Inflate(expr_1C, expr_1C)
			Dim num2 As Integer = clientRectangle.Width
			clientRectangle.Width = num2 - 1
			num2 = clientRectangle.Height
			clientRectangle.Height = num2 - 1
			Dim font As Font = New Font("Arial", 8F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim font2 As Font = New Font("Arial", 8F, FontStyle.Underline, GraphicsUnit.Point, 0)
			Dim controlDark As Pen = SystemPens.ControlDark
			Dim controlDarkDark As Pen = SystemPens.ControlDarkDark
			Dim controlLight As Pen = SystemPens.ControlLight
			Dim controlLightLight As Pen = SystemPens.ControlLightLight
			Dim controlLight2 As Pen = SystemPens.ControlLight
			Dim pen As Pen = New Pen(Color.FromKnownColor(KnownColor.LightGreen))
			Dim controlDark2 As Pen = SystemPens.ControlDark
			Dim brush As Brush
			Dim brush2 As Brush
			If Me.Focused Then
				brush = SystemBrushes.Highlight
				New SolidBrush(Color.FromKnownColor(KnownColor.MediumBlue))
				Dim arg_CB_0 As Brush = SystemBrushes.HighlightText
				If Me.mMouseTargetNode Is Me.mSelectedNode Then
					brush2 = New SolidBrush(Color.FromKnownColor(KnownColor.DarkGray))
				Else
					brush2 = New SolidBrush(Color.FromKnownColor(KnownColor.LightGray))
				End If
			Else
				brush = New SolidBrush(Color.FromKnownColor(KnownColor.Gray))
				New SolidBrush(Color.FromKnownColor(KnownColor.LightGray))
				Dim arg_11A_0 As Brush = SystemBrushes.ControlText
				brush2 = New SolidBrush(Color.FromKnownColor(KnownColor.Blue))
			End If
			Dim brush3 As Brush = New SolidBrush(Color.FromKnownColor(KnownColor.Green))
			Dim brush4 As Brush = New SolidBrush(Color.FromKnownColor(KnownColor.LightGreen))
			Dim controlText As Brush = SystemBrushes.ControlText
			Dim highlightText As Brush = SystemBrushes.HighlightText
			Dim array As Brush() = New Brush(9) {}
			array(0) = SystemBrushes.ControlText
			Dim color As Color = Color.FromKnownColor(KnownColor.Blue)
			array(2) = New SolidBrush(color)
			Dim color2 As Color = Color.FromKnownColor(KnownColor.OrangeRed)
			array(1) = New SolidBrush(color2)
			Dim color3 As Color = Color.FromKnownColor(KnownColor.DarkGray)
			array(3) = New SolidBrush(color3)
			Dim color4 As Color = Color.FromKnownColor(KnownColor.Red)
			array(4) = New SolidBrush(color4)
			array(5) = SystemBrushes.HighlightText
			Dim color5 As Color = Color.FromKnownColor(KnownColor.LightBlue)
			array(7) = New SolidBrush(color5)
			Dim color6 As Color = Color.FromKnownColor(KnownColor.Yellow)
			array(6) = New SolidBrush(color6)
			Dim color7 As Color = Color.FromKnownColor(KnownColor.Gray)
			array(8) = New SolidBrush(color7)
			Dim color8 As Color = Color.FromKnownColor(KnownColor.Red)
			array(9) = New SolidBrush(color8)
			Dim num3 As Integer = clientRectangle.Left + 14
			Dim num4 As Integer = clientRectangle.Top
			Dim i As Integer = (Me.mRowHeight - font.Height) / 2 + num4
			Dim actionListTreeControl_Node As ActionListTreeControl_Node = Me.mFirstDisplayNode
			Dim actionListTreeControl_Node2 As ActionListTreeControl_Node = actionListTreeControl_Node
			If actionListTreeControl_Node2 IsNot Nothing Then
				While actionListTreeControl_Node2.Parent IsNot Nothing
					actionListTreeControl_Node2 = actionListTreeControl_Node2.Parent
					num3 = Me.mDepthTab + num3
					If actionListTreeControl_Node2 Is Nothing Then
						Exit While
					End If
				End While
			End If
			actionListTreeControl_Node2 = actionListTreeControl_Node
			If actionListTreeControl_Node2 IsNot Nothing Then
				While i < clientRectangle.Bottom
					Dim actionListTreeControl_Node3 As ActionListTreeControl_Node = Me.mSelectedNode
					Dim actionListTreeControl_Node4 As ActionListTreeControl_Node = Me.mSelectedNode_End
					Dim flag As Boolean
					Dim num5 As Integer
					If actionListTreeControl_Node3 Is actionListTreeControl_Node4 Then
						flag = ((If((actionListTreeControl_Node3 Is actionListTreeControl_Node2), 1, 0)) <> 0)
					Else
						If actionListTreeControl_Node3.ActionIndex <= actionListTreeControl_Node2.ActionIndex AndAlso actionListTreeControl_Node2.ActionIndex <= actionListTreeControl_Node4.ActionIndex Then
							num5 = 1
						Else
							num5 = 0
						End If
						flag = (CByte(num5) <> 0)
						If actionListTreeControl_Node4.ActionIndex <= actionListTreeControl_Node2.ActionIndex AndAlso actionListTreeControl_Node2.ActionIndex <= actionListTreeControl_Node3.ActionIndex Then
							num5 = 1
						Else
							num5 = 0
						End If
						flag = (((If(flag, 1, 0)) Or CByte(num5)) <> 0)
					End If
					If Me.mSelectedBeginExtended <= actionListTreeControl_Node2.ActionIndex AndAlso actionListTreeControl_Node2.ActionIndex <= Me.mSelectedEndExtended Then
						num5 = 1
					Else
						num5 = 0
					End If
					Dim flag2 As Boolean = CByte(num5) <> 0
					If actionListTreeControl_Node2 IsNot Me.mRootNode Then
						Dim num6 As Integer = Me.mDepthTab
						num5 = num3 - num6 - 4
						Dim num9 As Integer
						If Not actionListTreeControl_Node2.HeaderNode Then
							If actionListTreeControl_Node2.GetNumberOfNodes() <> 0 Then
								num6 = Me.mRowHeight
								Dim num7 As Integer = Me.mDepthTab
								graphics.DrawRectangle(controlDark2, num7 / 4 + num5, num6 / 4 + num4, num7 / 2, num6 / 2)
								Dim num8 As Integer = num4 + Me.mRowHeight / 2
								num7 = Me.mDepthTab
								graphics.DrawLine(controlDark2, num5 + num7 / 4 + 2, num8, num5 + num7 * 3 / 4 - 2, num8)
								If Not actionListTreeControl_Node2.Expanded Then
									num6 = Me.mRowHeight
									num8 = num5 + Me.mDepthTab / 2
									graphics.DrawLine(controlDark2, num8, num4 + num6 / 4 + 2, num8, num4 + num6 * 3 / 4 - 2)
								End If
								num8 = num5 + Me.mDepthTab / 2
								graphics.DrawLine(controlLight2, num8, num4, num8, Me.mRowHeight / 4 + num4)
								num8 = num4 + Me.mRowHeight / 2
								num7 = Me.mDepthTab
								graphics.DrawLine(controlLight2, num7 * 3 / 4 + num5, num8, num7 + num5, num8)
								If actionListTreeControl_Node2.[Next] IsNot Nothing Then
									num7 = Me.mRowHeight
									num8 = num5 + Me.mDepthTab / 2
									graphics.DrawLine(controlLight2, num8, num7 * 3 / 4 + num4, num8, num7 + num4)
								End If
							Else If actionListTreeControl_Node2.[Next] IsNot Nothing Then
								Dim num8 As Integer = num5 + Me.mDepthTab / 2
								graphics.DrawLine(controlLight2, num8, num4, num8, Me.mRowHeight + num4)
								num8 = num4 + Me.mRowHeight / 2
								Dim num7 As Integer = Me.mDepthTab
								graphics.DrawLine(controlLight2, num7 / 2 + num5, num8, num7 + num5, num8)
							Else
								Dim num8 As Integer = num5 + Me.mDepthTab / 2
								graphics.DrawLine(controlLight2, num8, num4, num8, Me.mRowHeight / 2 + num4)
								num8 = num4 + Me.mRowHeight / 2
								Dim num7 As Integer = Me.mDepthTab
								graphics.DrawLine(controlLight2, num7 / 2 + num5, num8, num7 + num5, num8)
							End If
						Else
							If actionListTreeControl_Node2.[Next] IsNot Nothing Then
								Dim num8 As Integer = num5 + num6 * 3 / 2
								graphics.DrawLine(pen, num8, num4, num8, Me.mRowHeight + num4)
								num8 = num4 + Me.mRowHeight / 2
								Dim num7 As Integer = Me.mDepthTab
								graphics.DrawLine(pen, num7 * 3 / 2 + num5, num8, num7 * 2 + num5, num8)
							Else
								Dim num8 As Integer = num5 + num6 * 3 / 2
								graphics.DrawLine(pen, num8, num4, num8, Me.mRowHeight / 2 + num4)
								num8 = num4 + Me.mRowHeight / 2
								Dim num7 As Integer = Me.mDepthTab
								graphics.DrawLine(pen, num7 * 3 / 2 + num5, num8, num7 * 2 + num5, num8)
							End If
							If actionListTreeControl_Node2.Parent.Expanded AndAlso actionListTreeControl_Node2.Parent.GetNumberOfNodes() <> 0 Then
								num9 = num5 + Me.mDepthTab / 2
								graphics.DrawLine(controlLight2, num9, num4, num9, Me.mRowHeight + num4)
							End If
						End If
						Dim parent As ActionListTreeControl_Node = actionListTreeControl_Node2.Parent
						Dim num10 As Integer = Me.mDepthTab
						num5 -= num10
						If parent IsNot Me.mRootNode Then
							Do
								If parent.[Next] IsNot Nothing Then
									num9 = num5 + num10 / 2
									graphics.DrawLine(controlLight2, num9, num4, num9, Me.mRowHeight + num4)
								End If
								parent = parent.Parent
								num10 = Me.mDepthTab
								num5 -= num10
							Loop While parent IsNot Me.mRootNode
						End If
						num9 = (If((Not actionListTreeControl_Node2.HeaderNode), 0, Me.mDepthTab)) + num3
						If actionListTreeControl_Node2.GetNumberOfTextElements() <> 0 Then
							Dim num11 As Integer
							If flag AndAlso Not Me.Editing Then
								graphics.FillRectangle(brush, num9 - 2, num4, clientRectangle.Width + clientRectangle.Left + (2 - num9), Me.mRowHeight)
								num11 = 5
							Else
								num11 = 0
							End If
							If flag2 AndAlso Not Me.Editing Then
								graphics.FillRectangle(brush, Me.mDepthTab + num5 - 10, num4, 7, Me.mRowHeight)
							End If
							Dim num12 As Integer = 0
							If 0 < actionListTreeControl_Node2.GetNumberOfTextElements() Then
								Do
									Dim textElement As ActionListTreeControl_Node_TextElement = actionListTreeControl_Node2.GetTextElement(num12)
									Dim sizeF As SizeF = graphics.MeasureString(textElement.Text, font, 0, Nothing)
									Dim size As Size = New Size(CInt((CDec(sizeF.Width))) + 4, CInt((CDec(sizeF.Height))) + 4)
									Dim location As Point = New Point(num9 - 2, i - 2)
									Dim rectangle As Rectangle = New Rectangle(location, size)
									textElement.SetArea(rectangle)
									If Me.mMouseTargetTextElement Is textElement Then
										If Me.Editing Then
											sizeF = graphics.MeasureString(Me.mEditedText, font, 0, Nothing)
											Dim size2 As Size = New Size(CInt((CDec(sizeF.Width))) + 4, CInt((CDec(sizeF.Height))) + 4)
											Dim location2 As Point = New Point(num9 - 2, i - 2)
											Dim rect As Rectangle = New Rectangle(location2, size2)
											textElement.SetArea(rect)
											graphics.DrawRectangle(controlDark2, rect)
											Dim p As Point = New Point(num9, i)
											Dim point As PointF = p
											graphics.DrawString(Me.mEditedText, font, array(textElement.Type + num11), point)
										Else
											graphics.FillRectangle(brush2, __Dereference(textElement.GetArea()))
											Dim p2 As Point = New Point(num9, i)
											Dim point2 As PointF = p2
											graphics.DrawString(textElement.Text, font2, array(textElement.Type + num11), point2)
										End If
									Else
										Dim p3 As Point = New Point(num9, i)
										Dim point3 As PointF = p3
										graphics.DrawString(textElement.Text, font, array(textElement.Type + num11), point3)
									End If
									num9 = CInt((CDec(sizeF.Width))) + Me.mSpaceWidth + num9
									num12 += 1
								Loop While num12 < actionListTreeControl_Node2.GetNumberOfTextElements()
							End If
						Else If actionListTreeControl_Node2.HeaderNode Then
							If flag Then
								num10 = Me.mDepthTab
								graphics.FillRectangle(brush2, num3 + num10 - 2, num4, clientRectangle.Width + clientRectangle.Left + (2 - num10 - num3), Me.mRowHeight)
								Dim p4 As Point = New Point(Me.mDepthTab + num3, i)
								Dim point4 As PointF = p4
								graphics.DrawString(actionListTreeControl_Node2.Text, font, brush4, point4)
							Else
								Dim p5 As Point = New Point(Me.mDepthTab + num3, i)
								Dim point5 As PointF = p5
								graphics.DrawString(actionListTreeControl_Node2.Text, font, brush3, point5)
							End If
						Else If flag Then
							graphics.FillRectangle(brush, num3 - 2, num4, clientRectangle.Width + clientRectangle.Left + (2 - num3), Me.mRowHeight)
							Dim p6 As Point = New Point(num3, i)
							Dim point6 As PointF = p6
							graphics.DrawString(actionListTreeControl_Node2.Text, font, highlightText, point6)
						Else
							Dim p7 As Point = New Point(num3, i)
							Dim point7 As PointF = p7
							graphics.DrawString(actionListTreeControl_Node2.Text, font, controlText, point7)
						End If
						Dim num13 As Integer = Me.mRowHeight
						i = num13 + i
						num4 = num13 + num4
					End If
					Dim flag3 As Boolean = True
					While True
						If flag3 Then
							If actionListTreeControl_Node2.GetNumberOfHeaderNodes() <> 0 Then
								GoTo IL_A3D
							End If
							If actionListTreeControl_Node2.Expanded AndAlso actionListTreeControl_Node2.GetNumberOfNodes() <> 0 Then
								GoTo IL_A52
							End If
						End If
						If actionListTreeControl_Node2.[Next] IsNot Nothing Then
							GoTo IL_A67
						End If
						If actionListTreeControl_Node2.Parent Is Nothing Then
							GoTo IL_A7F
						End If
						flag3 = False
						If actionListTreeControl_Node2.HeaderNode AndAlso actionListTreeControl_Node2.Parent.Expanded AndAlso actionListTreeControl_Node2.Parent.GetNumberOfNodes() <> 0 Then
							GoTo IL_A70
						End If
						actionListTreeControl_Node2 = actionListTreeControl_Node2.Parent
						num3 -= Me.mDepthTab
					End While
					IL_A81:
					If actionListTreeControl_Node2 Is Nothing Then
						Exit While
					End If
					Continue While
					IL_A3D:
					actionListTreeControl_Node2 = actionListTreeControl_Node2.GetHeaderNode(0)
					num3 = Me.mDepthTab + num3
					GoTo IL_A81
					IL_A52:
					actionListTreeControl_Node2 = actionListTreeControl_Node2.GetNode(0)
					num3 = Me.mDepthTab + num3
					GoTo IL_A81
					IL_A67:
					actionListTreeControl_Node2 = actionListTreeControl_Node2.[Next]
					GoTo IL_A81
					IL_A70:
					actionListTreeControl_Node2 = actionListTreeControl_Node2.Parent.GetNode(0)
					GoTo IL_A81
					IL_A7F:
					actionListTreeControl_Node2 = Nothing
					GoTo IL_A81
				End While
			End If
			Dim num14 As Integer = Me.mFrameSize
			Dim expr_A93 As Integer = num14
			clientRectangle.Inflate(expr_A93, expr_A93)
			graphics.DrawLine(controlDark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Right, clientRectangle.Top)
			graphics.DrawLine(controlDarkDark, clientRectangle.Left, clientRectangle.Top + 1, clientRectangle.Right - 1, clientRectangle.Top + 1)
			graphics.DrawLine(controlDark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Left, clientRectangle.Bottom)
			graphics.DrawLine(controlDarkDark, clientRectangle.Left + 1, clientRectangle.Top, clientRectangle.Left + 1, clientRectangle.Bottom - 1)
			graphics.DrawLine(controlLightLight, clientRectangle.Left + 1, clientRectangle.Bottom, clientRectangle.Right - 1, clientRectangle.Bottom)
			graphics.DrawLine(controlLight, clientRectangle.Left + 2, clientRectangle.Bottom - 1, clientRectangle.Right - 1, clientRectangle.Bottom - 1)
			graphics.DrawLine(controlLightLight, clientRectangle.Right, clientRectangle.Top + 1, clientRectangle.Right, clientRectangle.Bottom)
			graphics.DrawLine(controlLight, clientRectangle.Right - 1, clientRectangle.Top + 2, clientRectangle.Right - 1, clientRectangle.Bottom)
			If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection Then
				Dim num15 As Integer
				If Me.mEditingList_Width = 0 Then
					num15 = 0
					If 0 < Me.mEditingStringList.Length Then
						Do
							Dim num16 As Integer = CInt((CDec(graphics.MeasureString(Me.mEditingStringList(num15), font, 0, Nothing).Width)))
							If num16 > Me.mEditingList_Width Then
								Me.mEditingList_Width = num16
							End If
							num15 += 1
						Loop While num15 < Me.mEditingStringList.Length
					End If
					Me.mEditingList_Width += 6
					If Me.mFrameSize * 2 + Me.mEditingList_X + Me.mEditingList_Width >= clientRectangle.Width Then
						Me.mEditingList_X = clientRectangle.Width - (Me.mFrameSize << 1) - Me.mEditingList_Width
					End If
					If Me.mEditingList_X < 0 Then
						Me.mEditingList_X = 0
					End If
					num15 = Me.mEditingList_MaxDisplayed * Me.mRowHeight
					num14 = Me.mFrameSize
					If num14 * 2 + Me.mEditingList_Y + num15 >= clientRectangle.Height Then
						Me.mEditingList_Y = Me.mEditingList_Y_Up - (num14 << 1) - num15
					End If
					If Me.mEditingList_Y < 0 Then
						Me.mEditingList_Y = 0
					End If
				End If
				clientRectangle.X = clientRectangle.X + Me.mEditingList_X + Me.mFrameSize
				clientRectangle.Y = clientRectangle.Y + Me.mEditingList_Y + Me.mFrameSize
				clientRectangle.Width = Me.mEditingList_Width
				clientRectangle.Height = Me.mEditingList_MaxDisplayed * Me.mRowHeight
				graphics.FillRectangle(SystemBrushes.ControlLight, clientRectangle)
				num15 = clientRectangle.Y
				Dim num17 As Integer = 0
				If 0 < Me.mEditingList_MaxDisplayed Then
					Do
						Dim num18 As Integer = num17 + Me.mEditingList_FirstDisplayed
						If num18 >= Me.mEditingStringList.Length Then
							Exit Do
						End If
						Dim num19 As Integer = num18
						Dim brush5 As Brush
						If num19 = Me.mEditingList_Selected Then
							graphics.FillRectangle(brush, clientRectangle.X, num15, clientRectangle.Width, Me.mRowHeight)
							brush5 = highlightText
						Else
							brush5 = controlText
						End If
						Dim p8 As Point = New Point(clientRectangle.X + 2, (Me.mRowHeight - font.Height) / 2 + num15)
						Dim point8 As PointF = p8
						graphics.DrawString(Me.mEditingStringList(num19), font, brush5, point8)
						num17 += 1
						num15 = Me.mRowHeight + num15
					Loop While num17 < Me.mEditingList_MaxDisplayed
				End If
				num14 = Me.mFrameSize
				Dim expr_E24 As Integer = num14
				clientRectangle.Inflate(expr_E24, expr_E24)
				graphics.DrawLine(controlDark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Right, clientRectangle.Top)
				graphics.DrawLine(controlDarkDark, clientRectangle.Left, clientRectangle.Top + 1, clientRectangle.Right - 1, clientRectangle.Top + 1)
				graphics.DrawLine(controlDark, clientRectangle.Left, clientRectangle.Top, clientRectangle.Left, clientRectangle.Bottom)
				graphics.DrawLine(controlDarkDark, clientRectangle.Left + 1, clientRectangle.Top, clientRectangle.Left + 1, clientRectangle.Bottom - 1)
				graphics.DrawLine(controlLightLight, clientRectangle.Left + 1, clientRectangle.Bottom, clientRectangle.Right - 1, clientRectangle.Bottom)
				graphics.DrawLine(controlLight, clientRectangle.Left + 2, clientRectangle.Bottom - 1, clientRectangle.Right - 1, clientRectangle.Bottom - 1)
				graphics.DrawLine(controlLightLight, clientRectangle.Right, clientRectangle.Top + 1, clientRectangle.Right, clientRectangle.Bottom)
				graphics.DrawLine(controlLight, clientRectangle.Right - 1, clientRectangle.Top + 2, clientRectangle.Right - 1, clientRectangle.Bottom)
			End If
		End Sub

		Private Sub Script_ActionListTreeControl_KeyDown(sender As Object, e As KeyEventArgs)
			Dim c As Char = vbNullChar
			Select Case e.KeyCode
				Case Keys.Back
					If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_Number Then
						Dim text As String = Me.mEditedText.Substring(0, Me.mEditedText.Length - 1)
						Me.mEditedText = text
						If text.Length = 0 OrElse Me.mEditedText.CompareTo("-") = 0 Then
							Me.mEditedText = "0"
						End If
						MyBase.Invalidate()
					End If
				Case Keys.[Return]
					If Me.Editing Then
						Dim eEditingType As Script_ActionListTreeControl.eEditingType = Me.mEditingType
						If eEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection Then
							MyBase.Capture = False
							Me.raise_ListSelectingFinished(Me, New EventArgs())
							Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
							MyBase.Invalidate()
						Else If eEditingType = Script_ActionListTreeControl.eEditingType.EDITING_Number Then
							MyBase.Capture = False
							Me.raise_TextEditingFinished(Me, New EventArgs())
							Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
							MyBase.Invalidate()
						End If
					Else
						Dim actionListTreeControl_Node As ActionListTreeControl_Node = Me.mSelectedNode
						If actionListTreeControl_Node IsNot Nothing AndAlso actionListTreeControl_Node.GetNumberOfNodes() <> 0 Then
							Me.mSelectedNode.ToggleExpand()
							MyBase.Invalidate()
						End If
					End If
					e.Handled = True
				Case Keys.Escape
					If Me.Editing Then
						Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
						MyBase.Capture = False
						e.Handled = True
						MyBase.Invalidate()
					End If
				Case Keys.Up
					If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection Then
						Dim num As Integer = Me.mEditingList_Selected
						If num > 0 Then
							Dim num2 As Integer = num - 1
							Me.mEditingList_Selected = num2
							If Me.mEditingList_FirstDisplayed > num2 Then
								Me.mEditingList_FirstDisplayed = num2
							End If
							Me.mEditedText = Me.mEditingStringList(num2)
							MyBase.Invalidate()
						End If
						e.Handled = True
					Else If Not Me.Editing Then
						Dim treePrev As ActionListTreeControl_Node = Me.GetTreePrev(Me.mSelectedNode)
						If treePrev IsNot Nothing Then
							If Me.mFirstDisplayNode Is Me.mSelectedNode Then
								Me.mFirstDisplayNode = treePrev
							Else
								Me.mSelectedRow -= 1
							End If
							Me.mSelectedNode = treePrev
							Me.mSelectedNode_End = treePrev
							Me.mSelectedBeginExtended = treePrev.ActionIndex
							Me.mSelectedEndExtended = treePrev.ActionIndex
							Me.raise_SelectionChanged(Me, New EventArgs())
							MyBase.Invalidate()
						End If
						e.Handled = True
					End If
				Case Keys.Down
					If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection Then
						Dim array As String() = Me.mEditingStringList
						Dim num3 As Integer = Me.mEditingList_Selected + 1
						If num3 < array.Length Then
							Me.mEditingList_Selected = num3
							Dim num4 As Integer = Me.mEditingList_MaxDisplayed
							If Me.mEditingList_FirstDisplayed + num4 <= num3 Then
								Me.mEditingList_FirstDisplayed = num3 - num4 + 1
							End If
							Me.mEditedText = array(num3)
							MyBase.Invalidate()
						End If
						e.Handled = True
					Else If Not Me.Editing Then
						Dim treeNext As ActionListTreeControl_Node = Me.GetTreeNext(Me.mSelectedNode)
						If treeNext IsNot Nothing Then
							Me.mSelectedNode = treeNext
							Me.mSelectedNode_End = treeNext
							Me.mSelectedBeginExtended = treeNext.ActionIndex
							Me.mSelectedEndExtended = treeNext.ActionIndex
							Dim num5 As Integer = Me.mSelectedRow + 1
							If num5 = Me.mMaxRows Then
								Me.mFirstDisplayNode = Me.GetTreeNext(Me.mFirstDisplayNode)
							Else
								Me.mSelectedRow = num5
							End If
							Me.raise_SelectionChanged(Me, New EventArgs())
							MyBase.Invalidate()
						End If
						e.Handled = True
					End If
				Case Keys.D0
					c = "0"c
				Case Keys.D1
					c = "1"c
				Case Keys.D2
					c = "2"c
				Case Keys.D3
					c = "3"c
				Case Keys.D4
					c = "4"c
				Case Keys.D5
					c = "5"c
				Case Keys.D6
					c = "6"c
				Case Keys.D7
					c = "7"c
				Case Keys.D8
					c = "8"c
				Case Keys.D9
					c = "9"c
				Case Keys.NumPad0
					c = "0"c
				Case Keys.NumPad1
					c = "1"c
				Case Keys.NumPad2
					c = "2"c
				Case Keys.NumPad3
					c = "3"c
				Case Keys.NumPad4
					c = "4"c
				Case Keys.NumPad5
					c = "5"c
				Case Keys.NumPad6
					c = "6"c
				Case Keys.NumPad7
					c = "7"c
				Case Keys.NumPad8
					c = "8"c
				Case Keys.NumPad9
					c = "9"c
				Case Keys.OemMinus
					If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_Number Then
						If Me.mEditedText(0) = "-"c Then
							Me.mEditedText = Me.mEditedText.Substring(1, Me.mEditedText.Length - 1)
						Else
							Me.mEditedText = "-" + Me.mEditedText
						End If
						MyBase.Invalidate()
					End If
			End Select
			If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_Number AndAlso c <> vbNullChar Then
				e.Handled = True
				If Me.mEditedText.Length < 8 Then
					If String.Compare(Me.mEditedText, "0", False) = 0 Then
						Me.mEditedText = String.Empty
					End If
					Me.mEditedText += String.Format("{0}", c)
					MyBase.Invalidate()
				End If
			End If
		End Sub

		Private Sub Script_ActionListTreeControl_Update(sender As Object, e As EventArgs)
			Me.mMaxRows = (MyBase.ClientRectangle.Height - (Me.mFrameSize << 1)) / Me.mRowHeight
			MyBase.Invalidate()
		End Sub

		Private Sub Script_ActionListTreeControl_MouseDown(sender As Object, e As MouseEventArgs)
			If e.Button = MouseButtons.Left Then
				If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection Then
					Dim clientRectangle As Rectangle = MyBase.ClientRectangle
					clientRectangle.X = clientRectangle.X + Me.mFrameSize + Me.mEditingList_X
					clientRectangle.Y = clientRectangle.Y + Me.mEditingList_Y + Me.mFrameSize
					clientRectangle.Width = Me.mEditingList_Width
					clientRectangle.Height = Me.mRowHeight * Me.mEditingList_MaxDisplayed
					Dim x As Integer = e.X
					Dim y As Integer = e.Y
					If clientRectangle.Contains(x, y) Then
						Me.mEditingList_Selected = (y - clientRectangle.Y) / Me.mRowHeight + Me.mEditingList_FirstDisplayed
						Me.raise_ListSelectingFinished(Me, New EventArgs())
						If MyBase.Capture Then
							MyBase.Capture = False
						End If
						Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_MAX
						MyBase.Invalidate()
					End If
				Else If Not Me.Editing AndAlso Me.mSelectedNode IsNot Nothing Then
					Dim clientRectangle2 As Rectangle = MyBase.ClientRectangle
					Dim num As Integer = -Me.mFrameSize
					Dim expr_113 As Integer = num
					clientRectangle2.Inflate(expr_113, expr_113)
					Dim x2 As Integer = e.X
					Dim y2 As Integer = e.Y
					If clientRectangle2.Contains(x2, y2) Then
						Dim num2 As Integer = (y2 - clientRectangle2.Y) / Me.mRowHeight
						Dim treeNext As ActionListTreeControl_Node = Me.GetTreeNext(Me.mFirstDisplayNode, num2)
						If treeNext IsNot Nothing Then
							Dim num3 As Integer
							If Me.mSelectedNode Is treeNext AndAlso Me.mSelectedNode_End Is treeNext Then
								num3 = 1
							Else
								num3 = 0
							End If
							Dim flag As Boolean = CByte(num3) <> 0
							Me.mSelectedNode = treeNext
							Me.mSelectedNode_End = treeNext
							Me.MouseLeftHeld = True
							Dim num4 As Integer = Me.mMaxRows
							If num2 = num4 Then
								Me.mSelectedRow = num4 - 1
								Me.mFirstDisplayNode = Me.GetTreeNext(Me.mFirstDisplayNode)
							Else
								Me.mSelectedRow = num2
							End If
							If e.Clicks = 2 AndAlso Me.mMouseTargetTextElement Is Nothing Then
								Me.mSelectedNode.ToggleExpand()
								Me.raise_ExpandChanged(Me, New EventArgs())
							End If
							If Not flag Then
								Me.mSelectedBeginExtended = treeNext.ActionIndex
								Me.mSelectedEndExtended = treeNext.ActionIndex
								Me.raise_SelectionChanged(Me, New EventArgs())
							End If
							If e.Clicks = 2 AndAlso Me.mMouseTargetTextElement IsNot Nothing Then
								Me.raise_TextEditingRequest(Me, New EventArgs())
							End If
							Me.ScrollTimer = New System.Timers.Timer()
							AddHandler Me.ScrollTimer.Elapsed, AddressOf Me.Script_ActionListTreeControl_OnTimed
							Me.ScrollTimer.AutoReset = False
							Me.ScrollTimer.Interval = 100.0
							Me.ScrollTimer.Enabled = True
							MyBase.Invalidate()
						End If
					End If
				End If
			End If
		End Sub

		Private Sub Script_ActionListTreeControl_MouseMove(sender As Object, e As MouseEventArgs)
			Me.UpdateMouseTarget(e.X, e.Y)
			If Me.MouseLeftHeld Then
				Dim clientRectangle As Rectangle = MyBase.ClientRectangle
				Dim num As Integer = -Me.mFrameSize
				Dim expr_32 As Integer = num
				clientRectangle.Inflate(expr_32, expr_32)
				Dim x As Integer = e.X
				Dim y As Integer = e.Y
				If clientRectangle.Contains(x, y) Then
					Dim num2 As Integer = (y - clientRectangle.Y) / Me.mRowHeight
					Dim treeNext As ActionListTreeControl_Node = Me.GetTreeNext(Me.mFirstDisplayNode, num2)
					If treeNext IsNot Nothing Then
						Dim flag As Boolean = (If((Me.mSelectedNode Is treeNext), 1, 0)) <> 0
						Me.mSelectedNode = treeNext
						Dim num3 As Integer = Me.mMaxRows
						If num2 = num3 Then
							Me.mSelectedRow = num3 - 1
							Me.mFirstDisplayNode = Me.GetTreeNext(Me.mFirstDisplayNode)
						Else
							Me.mSelectedRow = num2
						End If
						If Not flag Then
							Me.mSelectedBeginExtended = treeNext.ActionIndex
							Me.mSelectedEndExtended = treeNext.ActionIndex
							Me.raise_SelectionChanged(Me, New EventArgs())
						End If
						MyBase.Invalidate()
					End If
				End If
			Else If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection Then
				Dim clientRectangle2 As Rectangle = MyBase.ClientRectangle
				clientRectangle2.X = clientRectangle2.X + Me.mEditingList_X + Me.mFrameSize
				clientRectangle2.Y = clientRectangle2.Y + Me.mEditingList_Y + Me.mFrameSize
				clientRectangle2.Width = Me.mEditingList_Width
				clientRectangle2.Height = Me.mEditingList_MaxDisplayed * Me.mRowHeight
				Dim x2 As Integer = e.X
				Dim y2 As Integer = e.Y
				If clientRectangle2.Contains(x2, y2) Then
					Dim num4 As Integer = Me.mEditingList_FirstDisplayed + (y2 - clientRectangle2.Y) / Me.mRowHeight
					Me.mEditingList_Selected = num4
					Me.mEditedText = Me.mEditingStringList(num4)
					MyBase.Invalidate()
				End If
			End If
		End Sub

		Private Sub Script_ActionListTreeControl_MouseUp(sender As Object, e As MouseEventArgs)
			If e.Button = MouseButtons.Left AndAlso Me.MouseLeftHeld Then
				Me.MouseLeftHeld = False
				Me.ScrollTimer.[Stop]()
				Me.ScrollTimer = Nothing
				MyBase.Invalidate()
			End If
		End Sub

		Private Sub Script_ActionListTreeControl_MouseWheel(sender As Object, e As MouseEventArgs)
			If Me.mSelectedNode IsNot Nothing AndAlso Not Me.MouseLeftHeld Then
				Dim num As Integer = e.Delta * SystemInformation.MouseWheelScrollLines / 120
				If num <> 0 Then
					If Me.mEditingType = Script_ActionListTreeControl.eEditingType.EDITING_ListSelection Then
						If num > 0 Then
							Dim num2 As Integer = Me.mEditingList_Selected
							If num > num2 Then
								Me.mEditingList_Selected = 0
							Else
								Me.mEditingList_Selected = num2 - num
							End If
							Dim num3 As Integer = Me.mEditingList_Selected
							If Me.mEditingList_FirstDisplayed > num3 Then
								Me.mEditingList_FirstDisplayed = num3
							End If
						Else
							Dim num4 As Integer = Me.mEditingStringList.Length - 1
							Me.mEditingList_Selected = num4
							Dim num5 As Integer = Me.mEditingList_MaxDisplayed
							If Me.mEditingList_FirstDisplayed + num5 <= num4 Then
								Me.mEditingList_FirstDisplayed = num4 - num5 + 1
							End If
						End If
						Me.mEditedText = Me.mEditingStringList(Me.mEditingList_Selected)
						MyBase.Invalidate()
					Else If Not Me.Editing Then
						If num > 0 Then
							Dim actionListTreeControl_Node As ActionListTreeControl_Node = Me.mSelectedNode
							Dim num6 As Integer = Me.mSelectedRow
							Dim actionListTreeControl_Node2 As ActionListTreeControl_Node = Me.mFirstDisplayNode
							Do
								num -= 1
								Dim treePrev As ActionListTreeControl_Node = Me.GetTreePrev(actionListTreeControl_Node)
								If treePrev Is Nothing OrElse treePrev Is Me.mRootNode Then
									Exit Do
								End If
								If actionListTreeControl_Node2 Is actionListTreeControl_Node Then
									actionListTreeControl_Node2 = treePrev
								Else
									num6 -= 1
								End If
								actionListTreeControl_Node = treePrev
							Loop While num <> 0
							If actionListTreeControl_Node IsNot Me.mSelectedNode Then
								Me.mFirstDisplayNode = actionListTreeControl_Node2
								Me.mSelectedRow = num6
								Me.mSelectedNode = actionListTreeControl_Node
								Me.mSelectedNode_End = actionListTreeControl_Node
								Me.mSelectedBeginExtended = actionListTreeControl_Node.ActionIndex
								Me.mSelectedEndExtended = actionListTreeControl_Node.ActionIndex
								Me.raise_SelectionChanged(Me, New EventArgs())
								MyBase.Invalidate()
							End If
						Else
							num = -num
							Dim actionListTreeControl_Node3 As ActionListTreeControl_Node = Me.mSelectedNode
							Dim num7 As Integer = Me.mSelectedRow
							Dim treeNext As ActionListTreeControl_Node = Me.mFirstDisplayNode
							If num <> 0 Then
								Dim num8 As Integer = num7 + 1
								Do
									num -= 1
									Dim treeNext2 As ActionListTreeControl_Node = Me.GetTreeNext(actionListTreeControl_Node3)
									If treeNext2 Is Nothing Then
										Exit Do
									End If
									If num8 = Me.mMaxRows Then
										treeNext = Me.GetTreeNext(treeNext)
									Else
										num7 += 1
										num8 += 1
									End If
									actionListTreeControl_Node3 = treeNext2
								Loop While num <> 0
							End If
							If actionListTreeControl_Node3 IsNot Me.mSelectedNode Then
								Me.mFirstDisplayNode = treeNext
								Me.mSelectedRow = num7
								Me.mSelectedNode = actionListTreeControl_Node3
								Me.mSelectedNode_End = actionListTreeControl_Node3
								Me.mSelectedBeginExtended = actionListTreeControl_Node3.ActionIndex
								Me.mSelectedEndExtended = actionListTreeControl_Node3.ActionIndex
								Me.raise_SelectionChanged(Me, New EventArgs())
								MyBase.Invalidate()
							End If
						End If
					End If
				End If
			End If
		End Sub

		Private Sub Script_ActionListTreeControl_DragOver(sender As Object, e As DragEventArgs)
			Dim p As Point = New Point(e.X, e.Y)
			Dim point As Point = MyBase.PointToClient(p)
			Me.UpdateMouseTarget(point.X, point.Y)
		End Sub

		Private Sub Script_ActionListTreeControl_DragDrop(sender As Object, e As DragEventArgs)
			If Me.mMouseTargetNode IsNot Nothing AndAlso Me.mMouseTargetTextElement IsNot Nothing Then
				Me.raise_MouseTargetOnDrop(Me, New EventArgs())
			End If
		End Sub

		Private Sub Script_ActionListTreeControl_OnTimed(sender As Object, e As ElapsedEventArgs)
			If Me.MouseLeftHeld Then
				Dim mousePosition As Point = Control.MousePosition
				Dim point As Point = MyBase.PointToClient(mousePosition)
				If point.Y < 0 Then
					Dim treePrev As ActionListTreeControl_Node = Me.GetTreePrev(Me.mSelectedNode)
					If treePrev IsNot Nothing Then
						If Me.mFirstDisplayNode Is Me.mSelectedNode Then
							Me.mFirstDisplayNode = treePrev
						Else
							Me.mSelectedRow -= 1
						End If
						Me.mSelectedNode = treePrev
						Me.raise_SelectionChanged(Me, New EventArgs())
						MyBase.Invalidate()
					End If
				Else
					Dim clientRectangle As Rectangle = MyBase.ClientRectangle
					If point.Y >= clientRectangle.Height Then
						Dim treeNext As ActionListTreeControl_Node = Me.GetTreeNext(Me.mSelectedNode)
						If treeNext IsNot Nothing Then
							Me.mSelectedNode = treeNext
							Dim num As Integer = Me.mSelectedRow + 1
							If num = Me.mMaxRows Then
								Me.mFirstDisplayNode = Me.GetTreeNext(Me.mFirstDisplayNode)
							Else
								Me.mSelectedRow = num
							End If
							Me.raise_SelectionChanged(Me, New EventArgs())
							MyBase.Invalidate()
						End If
					End If
				End If
				Me.ScrollTimer.Start()
			End If
		End Sub

		Private Sub UpdateMouseTarget(x As Integer, y As Integer)
			If Me.mSelectedNode IsNot Nothing AndAlso Not Me.Editing Then
				Dim clientRectangle As Rectangle = MyBase.ClientRectangle
				Dim num As Integer = -Me.mFrameSize
				Dim expr_2B As Integer = num
				clientRectangle.Inflate(expr_2B, expr_2B)
				If clientRectangle.Contains(x, y) Then
					Dim steps As Integer = (y - clientRectangle.Y) / Me.mRowHeight
					Dim actionListTreeControl_Node As ActionListTreeControl_Node = Me.GetTreeNext(Me.mFirstDisplayNode, steps)
					If actionListTreeControl_Node Is Nothing Then
						If Me.mMouseTargetNode IsNot Nothing Then
							Me.mMouseTargetNode = Nothing
							Me.mMouseTargetTextElement = Nothing
							Me.raise_MouseTargetChanged(Me, New EventArgs())
						End If
					Else
						Dim actionListTreeControl_Node_TextElement As ActionListTreeControl_Node_TextElement = Nothing
						Dim num2 As Integer = 0
						If 0 < actionListTreeControl_Node.GetNumberOfTextElements() Then
							Dim textElement As ActionListTreeControl_Node_TextElement
							Do
								textElement = actionListTreeControl_Node.GetTextElement(num2)
								If textElement.Type = 1 AndAlso textElement.GetArea().Contains(x, y) Then
									GoTo IL_C9
								End If
								num2 += 1
							Loop While num2 < actionListTreeControl_Node.GetNumberOfTextElements()
							GoTo IL_CB
							IL_C9:
							actionListTreeControl_Node_TextElement = textElement
						End If
						IL_CB:
						If actionListTreeControl_Node_TextElement Is Nothing Then
							actionListTreeControl_Node = Nothing
						End If
						If Me.mMouseTargetNode IsNot actionListTreeControl_Node OrElse Me.mMouseTargetTextElement IsNot actionListTreeControl_Node_TextElement Then
							Me.mMouseTargetNode = actionListTreeControl_Node
							Me.mMouseTargetTextElement = actionListTreeControl_Node_TextElement
							Me.raise_MouseTargetChanged(Me, New EventArgs())
							MyBase.Invalidate()
						End If
					End If
				End If
			End If
		End Sub

		Protected Sub raise_SelectionChanged(i1 As Object, i2 As EventArgs)
			Dim selectionChanged As EventHandler = Me.SelectionChanged
			If selectionChanged IsNot Nothing Then
				selectionChanged(i1, i2)
			End If
		End Sub

		Protected Sub raise_ExpandChanged(i1 As Object, i2 As EventArgs)
			Dim expandChanged As EventHandler = Me.ExpandChanged
			If expandChanged IsNot Nothing Then
				expandChanged(i1, i2)
			End If
		End Sub

		Protected Sub raise_MouseTargetChanged(i1 As Object, i2 As EventArgs)
			Dim mouseTargetChanged As EventHandler = Me.MouseTargetChanged
			If mouseTargetChanged IsNot Nothing Then
				mouseTargetChanged(i1, i2)
			End If
		End Sub

		Protected Sub raise_MouseTargetDoubleClicked(i1 As Object, i2 As EventArgs)
			Dim mouseTargetDoubleClicked As EventHandler = Me.MouseTargetDoubleClicked
			If mouseTargetDoubleClicked IsNot Nothing Then
				mouseTargetDoubleClicked(i1, i2)
			End If
		End Sub

		Protected Sub raise_MouseTargetOnDrop(i1 As Object, i2 As EventArgs)
			Dim mouseTargetOnDrop As EventHandler = Me.MouseTargetOnDrop
			If mouseTargetOnDrop IsNot Nothing Then
				mouseTargetOnDrop(i1, i2)
			End If
		End Sub

		Protected Sub raise_TextEditingRequest(i1 As Object, i2 As EventArgs)
			Dim textEditingRequest As EventHandler = Me.TextEditingRequest
			If textEditingRequest IsNot Nothing Then
				textEditingRequest(i1, i2)
			End If
		End Sub

		Protected Sub raise_TextEditingFinished(i1 As Object, i2 As EventArgs)
			Dim textEditingFinished As EventHandler = Me.TextEditingFinished
			If textEditingFinished IsNot Nothing Then
				textEditingFinished(i1, i2)
			End If
		End Sub

		Protected Sub raise_ListSelectingFinished(i1 As Object, i2 As EventArgs)
			Dim listSelectingFinished As EventHandler = Me.ListSelectingFinished
			If listSelectingFinished IsNot Nothing Then
				listSelectingFinished(i1, i2)
			End If
		End Sub
	End Class
End Namespace
