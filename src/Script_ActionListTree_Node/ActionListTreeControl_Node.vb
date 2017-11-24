Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Runtime.InteropServices

Namespace Script_ActionListTree_Node
	Public Class ActionListTreeControl_Node
		Inherits Component

		Private mParent As ActionListTreeControl_Node

		Private mPrev As ActionListTreeControl_Node

		Private mNext As ActionListTreeControl_Node

		Private mText As String

		Private TextElements As ArrayList

		Private HeaderNodes As ArrayList

		Private Nodes As ArrayList

		Private mExpanded As Boolean

		Private mHeaderNode As Boolean

		Private mActionIndex As Integer

		Private mConditionIndex As Integer

		Public ReadOnly Property [Next]() As ActionListTreeControl_Node
			Get
				Return Me.mNext
			End Get
		End Property

		Public ReadOnly Property Prev() As ActionListTreeControl_Node
			Get
				Return Me.mPrev
			End Get
		End Property

		Public ReadOnly Property Parent() As ActionListTreeControl_Node
			Get
				Return Me.mParent
			End Get
		End Property

		Public Property ConditionIndex() As Integer
			Get
				Return Me.mConditionIndex
			End Get
			Set(value As Integer)
				Me.mConditionIndex = value
			End Set
		End Property

		Public Property ActionIndex() As Integer
			Get
				Return Me.mActionIndex
			End Get
			Set(value As Integer)
				Me.mActionIndex = value
			End Set
		End Property

		Public ReadOnly Property Empty() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Dim num As Integer
				If Me.GetNumberOfHeaderNodes() = 0 AndAlso Me.GetNumberOfNodes() = 0 Then
					num = 1
				Else
					num = 0
				End If
				Return CByte(num) <> 0
			End Get
		End Property

		Public ReadOnly Property HeaderNode() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return Me.mHeaderNode
			End Get
		End Property

		Public ReadOnly Property Expanded() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return Me.mExpanded
			End Get
		End Property

		Public ReadOnly Property Text() As String
			Get
				Return Me.mText
			End Get
		End Property

		Public Sub New(text As String, <MarshalAs(UnmanagedType.U1)> formattedtext As Boolean)
			Me.mText = text
			Me.mParent = Nothing
			Me.mPrev = Nothing
			Me.mNext = Nothing
			Me.TextElements = New ArrayList()
			Me.HeaderNodes = New ArrayList()
			Me.Nodes = New ArrayList()
			Me.mExpanded = False
			Me.mHeaderNode = False
			Me.mActionIndex = 0
			Me.mConditionIndex = 0
			If formattedtext Then
				Me.ParseFormattedText()
			End If
		End Sub

		Public Function GetNumberOfTextElements() As Integer
			Return Me.TextElements.Count
		End Function

		Public Function GetTextElement(idx As Integer) As ActionListTreeControl_Node_TextElement
			Return Me.TextElements(idx)
		End Function

		Public Function AddHeaderNode(headernode As ActionListTreeControl_Node) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			If Me.HeaderNode Then
				Return False
			End If
			If Not headernode.Empty Then
				Return False
			End If
			If Me.HeaderNodes.Count <> 0 Then
				Me.GetHeaderNode(Me.HeaderNodes.Count - 1).mNext = headernode
				headernode.mPrev = Me.GetHeaderNode(Me.HeaderNodes.Count - 1)
			End If
			Me.HeaderNodes.Add(headernode)
			headernode.mParent = Me
			headernode.mHeaderNode = True
			Return True
		End Function

		Public Function GetNumberOfHeaderNodes() As Integer
			Return Me.HeaderNodes.Count
		End Function

		Public Function GetHeaderNode(idx As Integer) As ActionListTreeControl_Node
			Return Me.HeaderNodes(idx)
		End Function

		Public Function AddNode(node As ActionListTreeControl_Node) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			If Me.HeaderNode Then
				Return False
			End If
			If Me.Nodes.Count <> 0 Then
				Me.GetNode(Me.Nodes.Count - 1).mNext = node
				node.mPrev = Me.GetNode(Me.Nodes.Count - 1)
			End If
			Me.Nodes.Add(node)
			node.mParent = Me
			node.mHeaderNode = False
			Return True
		End Function

		Public Function GetNumberOfNodes() As Integer
			Return Me.Nodes.Count
		End Function

		Public Function GetNode(idx As Integer) As ActionListTreeControl_Node
			Return Me.Nodes(idx)
		End Function

		Public Sub Clear()
			Me.HeaderNodes = New ArrayList()
			Me.Nodes = New ArrayList()
		End Sub

		Public Sub Expand()
			Me.mExpanded = True
		End Sub

		Public Sub Close()
			Me.mExpanded = False
		End Sub

		Public Sub ToggleExpand()
			Dim num As Integer = If((Not Me.mExpanded), 1, 0)
			Me.mExpanded = (num <> 0)
		End Sub

		Protected Sub ParseFormattedText()
			Dim num As Integer = 0
			If 0 < Me.Text.Length Then
				While True
					Dim num2 As Integer
					Select Case Me.Text(num)
						Case "0"c
							num2 = 5
							GoTo IL_14E
						Case "f"c
							num2 = 3
							GoTo IL_14E
						Case "i"c
							num2 = 4
							GoTo IL_14E
						Case "n"c
							num2 = 0
							GoTo IL_14E
						Case "p"c
							num2 = 1
							GoTo IL_14E
						Case "r"c
							num2 = 2
							GoTo IL_14E
					End Select
					IL_2A5:
					num += 1
					If num >= Me.Text.Length Then
						Exit While
					End If
					Continue While
					IL_14E:
					num += 1
					If num = Me.Text.Length OrElse Me.Text(num) <> ":"c Then
						Exit While
					End If
					num += 1
					If num = Me.Text.Length Then
						Exit While
					End If
					Dim num3 As Integer = 0
					If num2 = 1 Then
						If Me.Text(num) < "0"c OrElse "9"c < Me.Text(num) Then
							Exit While
						End If
						If num < Me.Text.Length Then
							While "0"c <= Me.Text(num) AndAlso Me.Text(num) <= "9"c
								num3 = num3 * 10 + CInt(Me.Text(num)) - 48
								num += 1
								If num >= Me.Text.Length Then
									Exit While
								End If
							End While
						End If
						If num = Me.Text.Length OrElse Me.Text(num) <> ":"c Then
							Exit While
						End If
						num += 1
						If num = Me.Text.Length Then
							Exit While
						End If
					End If
					Dim num4 As Integer = num
					If num >= Me.Text.Length Then
						Exit While
					End If
					While Me.Text(num) <> ","c
						num += 1
						If num >= Me.Text.Length Then
							Exit While
						End If
					End While
					If num = num4 Then
						Exit While
					End If
					If num2 <> 5 Then
						Dim value As ActionListTreeControl_Node_TextElement = New ActionListTreeControl_Node_TextElement(Me.Text.Substring(num4, num - num4), num2, num3)
						Me.TextElements.Add(value)
						GoTo IL_2A5
					End If
					GoTo IL_2A5
				End While
			End If
		End Sub
	End Class
End Namespace
