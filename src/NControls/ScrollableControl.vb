Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NControls
	Public Class ScrollableControl
		Inherits BaseScrollableControl

		Protected ViewControl As DoubleBuffControl

		Protected Scrollbar As VScrollBar

		Private propScrollbarMode As Integer

		Private propViewWidth As Integer

		Private propViewHeight As Integer

		Private propStartY As Integer

		Private propSmallChangeFactor As Integer

		Private StartX As Integer

		Private Suspended As Boolean

		Private HiddenScrollbar As Boolean

		Private components As Container

		Private MyControlAddedHandler As ControlEventHandler

		Private MyControlRemovedHandler As ControlEventHandler

		Public ReadOnly Property OwnControls() As Control.ControlCollection
			Get
				Return MyBase.Controls
			End Get
		End Property

		Public ReadOnly Property Controls() As Control.ControlCollection
			Get
				Return Me.ViewControl.Controls
			End Get
		End Property

		Public Property SmallChangeFactor() As Integer
			Get
				Return Me.propSmallChangeFactor
			End Get
			Set(value As Integer)
				Me.propSmallChangeFactor = value
				If Me.OwnControls.Contains(Me.Scrollbar) Then
					Me.Scrollbar.SmallChange = Me.Scrollbar.LargeChange / Me.propSmallChangeFactor
				End If
			End Set
		End Property

		Public Property StartY() As Integer
			Get
				Return Me.propStartY
			End Get
			Set(value As Integer)
				If value > Me.propViewHeight - MyBase.Height Then
					value = Me.propViewHeight - MyBase.Height
				End If
				If value < 0 Then
					value = 0
				End If
				Dim num As Integer = Me.propStartY
				Me.propStartY = value
				Dim location As Point = New Point(Me.StartX, -value)
				Me.ViewControl.Location = location
				Dim num2 As Integer = Me.propStartY
				Dim num3 As Integer = num2 - num
				If num3 > 0 Then
					Dim rc As Rectangle = New Rectangle(Me.StartX, MyBase.Height + num, Me.propViewWidth, num3)
					Me.ViewControl.Invalidate(rc)
				Else
					Dim rc2 As Rectangle = New Rectangle(Me.StartX, num2, Me.propViewWidth, num3)
					Me.ViewControl.Invalidate(rc2)
				End If
				Dim scrollbar As VScrollBar = Me.Scrollbar
				If scrollbar IsNot Nothing Then
					scrollbar.Value = Me.propStartY
				End If
				Me.ViewControl.Refresh()
			End Set
		End Property

		Public Property ViewHeight() As Integer
			Get
				Return Me.propViewWidth
			End Get
			Set(value As Integer)
				If value > 0 Then
					Me.propViewHeight = value
					If Me.Scrollbar IsNot Nothing Then
						Me.CalcScrollParams()
						Me.Scrollbar.Invalidate()
					End If
					Me.ViewControl.Height = Me.propViewHeight
					If MyBase.Height + Me.propStartY > Me.propViewHeight Then
						Dim num As Integer = Me.propViewHeight - MyBase.Height
						If num < 0 Then
							num = 0
						End If
						Me.StartY = num
					End If
					Dim location As Point = New Point(Me.StartX, -Me.propStartY)
					Me.ViewControl.Location = location
					Me.ViewControl.Refresh()
				End If
			End Set
		End Property

		Public Property ViewWidth() As Integer
			Get
				Return Me.propViewWidth
			End Get
			Set(value As Integer)
				Me.propViewWidth = value
				Me.ViewControl.Width = value
			End Set
		End Property

		Public Property ScrollbarMode() As Integer
			Get
				Return Me.propScrollbarMode
			End Get
			Set(value As Integer)
				Me.propScrollbarMode = value
				Me.propStartY = 0
				If value <> 0 Then
					If Not Me.OwnControls.Contains(Me.Scrollbar) Then
						Me.Scrollbar = New VScrollBar()
						AddHandler Me.Scrollbar.Scroll, AddressOf Me.ScrollbarScroll
						Me.CalcScrollParams()
						If Me.ScrollbarMode = 2 Then
							Me.Scrollbar.Dock = DockStyle.Right
							Me.StartX = 0
						Else
							Me.Scrollbar.Dock = DockStyle.Left
							Me.StartX = Me.Scrollbar.Width
						End If
						RemoveHandler MyBase.ControlAdded, Me.MyControlAddedHandler
						Me.OwnControls.Add(Me.Scrollbar)
						AddHandler MyBase.ControlAdded, Me.MyControlAddedHandler
						Me.propViewWidth = MyBase.Width - Me.Scrollbar.Width
					Else If Me.ScrollbarMode = 2 Then
						Me.Scrollbar.Dock = DockStyle.Right
						Me.StartX = 0
					Else
						Me.Scrollbar.Dock = DockStyle.Left
						Me.StartX = Me.Scrollbar.Width
					End If
				Else
					If Me.OwnControls.Contains(Me.Scrollbar) Then
						RemoveHandler MyBase.ControlRemoved, Me.MyControlRemovedHandler
						Me.OwnControls.Remove(Me.Scrollbar)
						AddHandler MyBase.ControlRemoved, Me.MyControlRemovedHandler
						Me.Scrollbar.Dispose()
						Me.StartX = 0
					End If
					Me.propViewWidth = MyBase.Width
				End If
				Dim location As Point = New Point(Me.StartX, -Me.propStartY)
				Me.ViewControl.Location = location
				Me.ViewControl.Width = Me.propViewWidth
			End Set
		End Property

		Public Sub New(width As Integer, height As Integer, viewheight As Integer, scrollbarmode As Integer)
			Me.InitializeComponent()
			MyBase.Width = width
			MyBase.Height = height
			Me.propViewHeight = viewheight
			Me.propScrollbarMode = scrollbarmode
			Me.Suspended = False
			Me.HiddenScrollbar = False
			Me.propStartY = 0
			Me.StartX = 0
			Me.propSmallChangeFactor = 8
			If Me.ScrollbarMode <> 0 Then
				Me.Scrollbar = New VScrollBar()
				AddHandler Me.Scrollbar.Scroll, AddressOf Me.ScrollbarScroll
				Me.CalcScrollParams()
				If Me.ScrollbarMode = 2 Then
					Me.Scrollbar.Dock = DockStyle.Right
				Else
					Me.Scrollbar.Dock = DockStyle.Left
					Me.StartX = Me.Scrollbar.Width
				End If
				Me.OwnControls.Add(Me.Scrollbar)
				Me.propViewWidth = MyBase.Width - Me.Scrollbar.Width
			Else
				Me.propViewWidth = MyBase.Width
			End If
			Dim doubleBuffControl As DoubleBuffControl = New DoubleBuffControl(Me, New String(CType((AddressOf <Module>.??_C@_00CNPNBAHC@?$AA@), __Pointer(Of SByte))), Me.StartX, Me.propStartY, Me.propViewWidth, Me.propViewHeight)
			Me.ViewControl = doubleBuffControl
			Me.OwnControls.Add(doubleBuffControl)
			Dim controlEventHandler As ControlEventHandler = AddressOf Me.myControlAdded
			Me.MyControlAddedHandler = controlEventHandler
			AddHandler MyBase.ControlAdded, controlEventHandler
			Dim controlEventHandler2 As ControlEventHandler = AddressOf Me.myControlRemoved
			Me.MyControlRemovedHandler = controlEventHandler2
			AddHandler MyBase.ControlRemoved, controlEventHandler2
			AddHandler Me.ViewControl.MouseDown, AddressOf Me.ViewControlMouseDown
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

		Protected Overrides Sub OnSizeChanged(e As EventArgs)
			MyBase.OnSizeChanged(e)
			If Me.ViewControl IsNot Nothing Then
				If Me.ScrollbarMode <> 0 AndAlso Not Me.HiddenScrollbar Then
					Me.ViewWidth = MyBase.Width - Me.Scrollbar.Width
				Else
					Me.ViewWidth = MyBase.Width
				End If
				If Me.ScrollbarMode <> 0 AndAlso Not Me.HiddenScrollbar Then
					Me.CalcScrollParams()
					Me.Scrollbar.Refresh()
				End If
				If MyBase.Height > Me.propViewHeight - Me.propStartY Then
					Me.StartY = Me.propViewHeight - MyBase.Height
				End If
				Me.ViewControl.Refresh()
			End If
		End Sub

		Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
			If Not Me.IsFocusedScrollableChild(Me) Then
				Dim scrollbar As VScrollBar = Me.Scrollbar
				If scrollbar IsNot Nothing Then
					Dim num As Integer = e.Delta / 120 * scrollbar.SmallChange
					Dim num2 As Integer = Me.Scrollbar.Value - num
					If num2 < 0 Then
						num2 = 0
					Else If num2 > Me.Scrollbar.Maximum Then
						num2 = Me.Scrollbar.Maximum
					End If
					Me.StartY = num2
				End If
			End If
		End Sub

		Private Sub InitializeComponent()
			Me.components = New Container()
		End Sub

		Private Sub myControlAdded(__unnamed000 As Object, e As ControlEventArgs)
			Me.ViewControl.Controls.Add(e.Control)
		End Sub

		Private Sub myControlRemoved(__unnamed000 As Object, e As ControlEventArgs)
			Me.ViewControl.Controls.Remove(e.Control)
		End Sub

		Private Sub ViewControlMouseDown(__unnamed000 As Object, e As MouseEventArgs)
			MyBase.Focus()
		End Sub

		Private Sub ScrollbarScroll(__unnamed000 As Object, e As ScrollEventArgs)
			Me.StartY = e.NewValue
		End Sub

		Private Sub CalcScrollParams()
			If MyBase.Height > 0 Then
				Dim num As Integer = Me.propViewHeight
				If num - MyBase.Height > 0 Then
					Me.Scrollbar.Maximum = num
					Me.Scrollbar.LargeChange = MyBase.Height
					Me.Scrollbar.SmallChange = Me.Scrollbar.LargeChange / Me.propSmallChangeFactor
					Me.Scrollbar.Enabled = True
				Else
					Me.Scrollbar.Maximum = 0
					Me.Scrollbar.LargeChange = MyBase.Height
					Me.Scrollbar.SmallChange = MyBase.Height
					Me.Scrollbar.Enabled = False
				End If
			End If
		End Sub

		Private Function IsFocusedScrollableChild(rootcontrol As Control) As<MarshalAs(UnmanagedType.U1)>
		Boolean
			If rootcontrol.Controls.Count > 0 Then
				Dim enumerator As IEnumerator = rootcontrol.Controls.GetEnumerator()
				If enumerator.MoveNext() Then
					Do
						If enumerator.Current.[GetType]().BaseType.Equals(Type.[GetType]("NControls.BaseScrollableControl")) Then
							If(TryCast(enumerator.Current, BaseScrollableControl)).ContainsFocus Then
								Return True
							End If
						Else If Me.IsFocusedScrollableChild(TryCast(enumerator.Current, Control)) Then
							Return True
						End If
					Loop While enumerator.MoveNext()
					Return False
				End If
			End If
			Return False
		End Function

		Public Sub SuspendLayout()
			Me.Suspended = True
			Dim viewControl As DoubleBuffControl = Me.ViewControl
			If viewControl IsNot Nothing Then
				viewControl.SuspendLayout()
			End If
			Dim scrollbar As VScrollBar = Me.Scrollbar
			If scrollbar IsNot Nothing Then
				scrollbar.SuspendLayout()
			End If
			MyBase.SuspendLayout()
		End Sub

		Public Sub ResumeLayout()
			Me.Suspended = False
			Dim viewControl As DoubleBuffControl = Me.ViewControl
			If viewControl IsNot Nothing Then
				viewControl.ResumeLayout()
			End If
			Dim scrollbar As VScrollBar = Me.Scrollbar
			If scrollbar IsNot Nothing Then
				scrollbar.ResumeLayout()
			End If
			MyBase.ResumeLayout()
		End Sub

		Public Sub HideScrollBar()
			Dim scrollbar As VScrollBar = Me.Scrollbar
			If scrollbar IsNot Nothing AndAlso Me.OwnControls.Contains(scrollbar) Then
				Me.HiddenScrollbar = True
				RemoveHandler MyBase.ControlRemoved, Me.MyControlRemovedHandler
				Me.OwnControls.Remove(Me.Scrollbar)
				AddHandler MyBase.ControlRemoved, Me.MyControlRemovedHandler
				Dim width As Integer = MyBase.Width
				Me.propViewWidth = width
				Me.ViewControl.Width = width
			End If
		End Sub

		Public Sub ShowScrollBar()
			Dim scrollbar As VScrollBar = Me.Scrollbar
			If scrollbar IsNot Nothing AndAlso Not Me.OwnControls.Contains(scrollbar) Then
				Me.HiddenScrollbar = False
				RemoveHandler MyBase.ControlAdded, Me.MyControlAddedHandler
				Me.OwnControls.Add(Me.Scrollbar)
				AddHandler MyBase.ControlAdded, Me.MyControlAddedHandler
				Dim width As Integer = MyBase.Width - Me.Scrollbar.Width
				Me.propViewWidth = width
				Me.ViewControl.Width = width
			End If
		End Sub
	End Class
End Namespace
