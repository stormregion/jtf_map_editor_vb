Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class ToolboxContainer
		Inherits UserControl
		Implements IRearrangeableControl

		Public Delegate Sub OpenStateToggleHandler()

		Private panel1 As Panel

		Private btnClose As Button

		Private lblCaption As Label

		Private imageListCloseButton As ImageList

		Private components As IContainer

		Private ContainerOpen As Boolean

		Private AutosizeP As Boolean

		Private MinHeightP As Integer

		Private MinWidth As Integer

		Private Toolbox As UserControl

		Private RearrangeHandler As ToolRearranged

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

		Public Custom Event OpenStateToggledEvent As ToolboxContainer.OpenStateToggleHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			AddHandler
				Me.OpenStateToggledEvent = [Delegate].Combine(Me.OpenStateToggledEvent, value)
			End AddHandler
			<MethodImpl(MethodImplOptions.Synchronized)>
			RemoveHandler
				Me.OpenStateToggledEvent = [Delegate].Remove(Me.OpenStateToggledEvent, value)
			End RemoveHandler
		End Event

		Public Property Open() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return Me.ContainerOpen
			End Get
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				If value <> Me.ContainerOpen Then
					Me.ContainerOpen = value
					If value Then
						Me.btnClose.ImageIndex = 0
						Dim size As Size = Me.Toolbox.Size
						Dim size2 As Size = New Size(MyBase.Size.Width, size.Height + 16)
						MyBase.Size = size2
					Else
						Me.btnClose.ImageIndex = 1
						Dim size3 As Size = New Size(MyBase.Size.Width, 16)
						MyBase.Size = size3
					End If
				End If
			End Set
		End Property

		Public ReadOnly Property MinHeight() As Integer
			Get
				If Not Me.AutosizeP Then
					Return MyBase.Height
				End If
				If Me.ContainerOpen Then
					Return Me.MinHeightP
				End If
				Return 16
			End Get
		End Property

		Public Property Autosize() As Boolean
			<MarshalAs(UnmanagedType.U1)>
			Get
				Return Me.AutosizeP
			End Get
			<MarshalAs(UnmanagedType.U1)>
			Set(value As Boolean)
				Me.AutosizeP = value
			End Set
		End Property

		Public Sub New()
			Me.OpenStateToggledEvent = Nothing
			Me.Rearranged = Nothing
			Me.MinHeightP = 16
			Me.AutosizeP = False
			Me.RearrangeHandler = Nothing
			Me.InitializeComponent()
			Me.ContainerOpen = True
		End Sub

		Protected Overrides Sub Dispose(<MarshalAs(UnmanagedType.U1)> disposing As Boolean)
			If disposing Then
				Dim container As IContainer = Me.components
				If container IsNot Nothing Then
					container.Dispose()
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		Private Sub InitializeComponent()
			Me.components = New Container()
			Dim resourceManager As ResourceManager = New ResourceManager(GetType(ToolboxContainer))
			Me.panel1 = New Panel()
			Me.lblCaption = New Label()
			Me.btnClose = New Button()
			Me.imageListCloseButton = New ImageList(Me.components)
			Me.panel1.SuspendLayout()
			MyBase.SuspendLayout()
			Dim activeCaption As Color = SystemColors.ActiveCaption
			Me.panel1.BackColor = activeCaption
			Me.panel1.Controls.Add(Me.lblCaption)
			Me.panel1.Controls.Add(Me.btnClose)
			Me.panel1.Dock = DockStyle.Top
			Dim location As Point = New Point(0, 0)
			Me.panel1.Location = location
			Me.panel1.Name = "panel1"
			Dim size As Size = New Size(256, 16)
			Me.panel1.Size = size
			Me.panel1.TabIndex = 0
			Me.lblCaption.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.lblCaption.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			Dim activeCaptionText As Color = SystemColors.ActiveCaptionText
			Me.lblCaption.ForeColor = activeCaptionText
			Dim location2 As Point = New Point(1, 1)
			Me.lblCaption.Location = location2
			Me.lblCaption.Name = "lblCaption"
			Dim size2 As Size = New Size(238, 15)
			Me.lblCaption.Size = size2
			Me.lblCaption.TabIndex = 1
			Me.lblCaption.Text = "This is the caption text"
			AddHandler Me.lblCaption.DoubleClick, AddressOf Me.lblCaption_DoubleClick
			Me.btnClose.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Dim control As Color = SystemColors.Control
			Me.btnClose.BackColor = control
			Me.btnClose.FlatStyle = FlatStyle.Flat
			Me.btnClose.ImageIndex = 0
			Me.btnClose.ImageList = Me.imageListCloseButton
			Dim location3 As Point = New Point(240, 0)
			Me.btnClose.Location = location3
			Me.btnClose.Name = "btnClose"
			Dim size3 As Size = New Size(16, 16)
			Me.btnClose.Size = size3
			Me.btnClose.TabIndex = 0
			AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
			Me.imageListCloseButton.ColorDepth = ColorDepth.Depth24Bit
			Dim imageSize As Size = New Size(16, 16)
			Me.imageListCloseButton.ImageSize = imageSize
			Me.imageListCloseButton.ImageStream = CType(resourceManager.GetObject("imageListCloseButton.ImageStream"), ImageListStreamer)
			Dim magenta As Color = Color.Magenta
			Me.imageListCloseButton.TransparentColor = magenta
			Dim control2 As Color = SystemColors.Control
			Me.BackColor = control2
			MyBase.Controls.Add(Me.panel1)
			MyBase.Name = "ToolboxContainer"
			Dim size4 As Size = New Size(256, 16)
			MyBase.Size = size4
			Me.panel1.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Public Sub AddToolbox(toolbox As UserControl)
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			Me.Toolbox = toolbox
			Dim containerOpen As Boolean = Me.ContainerOpen
			Me.ContainerOpen = True
			MyBase.SuspendLayout()
			Dim size As Size = Me.Toolbox.Size
			Dim size2 As Size = New Size(Me.Toolbox.Size.Width, size.Height + 16)
			MyBase.Size = size2
			Dim location As Point = New Point(0, 16)
			Me.Toolbox.Location = location
			Me.lblCaption.Text = Me.Toolbox.Text
			Me.Toolbox.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			MyBase.Controls.Add(toolbox)
			Me.Dock = DockStyle.Top
			MyBase.ResumeLayout(False)
			Me.MinHeightP = Me.Toolbox.Height + 16
			Me.MinWidth = Me.Toolbox.Width
			Dim rearrangeableControl As IRearrangeableControl = Nothing
			Try
				rearrangeableControl = (TryCast(Me.Toolbox, IRearrangeableControl))
				GoTo IL_132
			End Try
			Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
			endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
			IL_132:
			If rearrangeableControl IsNot Nothing Then
				Dim toolRearranged As ToolRearranged = AddressOf Me.ChildToolRearranged
				Me.RearrangeHandler = toolRearranged
				AddHandler rearrangeableControl.Rearranged, toolRearranged
			End If
			If Not containerOpen Then
				Me.Open = False
			End If
		End Sub

		Public Sub RemoveToolbox()
			Dim num As Integer = CInt(__StackAlloc(Byte, <Module>.__CxxQueryExceptionSize()))
			If Me.Toolbox IsNot Nothing Then
				Dim size As Size = New Size(Me.MinWidth, Me.MinHeightP - 16)
				Me.Toolbox.Size = size
				MyBase.Controls.Remove(Me.Toolbox)
				Dim rearrangeableControl As IRearrangeableControl = Nothing
				Try
					rearrangeableControl = (TryCast(Me.Toolbox, IRearrangeableControl))
					GoTo IL_A2
				End Try
				Dim exceptionCode As UInteger = CUInt(Marshal.GetExceptionCode())
				endfilter(<Module>.__CxxExceptionFilter(Marshal.GetExceptionPointers(), Nothing, 0, Nothing))
				IL_A2:
				If rearrangeableControl IsNot Nothing Then
					Dim rearrangeHandler As ToolRearranged = Me.RearrangeHandler
					If rearrangeHandler IsNot Nothing Then
						RemoveHandler rearrangeableControl.Rearranged, rearrangeHandler
					End If
				End If
			End If
			Me.Toolbox = Nothing
			Me.RearrangeHandler = Nothing
		End Sub

		Public Sub Inflate(extraheight As Integer)
			Dim toolbox As UserControl = Me.Toolbox
			If toolbox IsNot Nothing Then
				Dim size As Size = New Size(toolbox.Size.Width, Me.MinHeightP + extraheight - 16)
				Me.Toolbox.Size = size
				Dim size2 As Size = Me.Toolbox.Size
				Dim size3 As Size = New Size(Me.Toolbox.Size.Width, size2.Height + 16)
				MyBase.Size = size3
			End If
		End Sub

		Private Sub btnClose_Click(sender As Object, e As EventArgs)
			Dim open As Byte = If((Not Me.Open), 1, 0)
			Me.Open = (open <> 0)
			Me.raise_OpenStateToggledEvent()
		End Sub

		Private Sub lblCaption_DoubleClick(sender As Object, e As EventArgs)
			Dim open As Byte = If((Not Me.Open), 1, 0)
			Me.Open = (open <> 0)
			Me.raise_OpenStateToggledEvent()
		End Sub

		Private Sub ChildToolRearranged(sender As Object, newsize As Integer)
			If Me.ContainerOpen Then
				MyBase.SuspendLayout()
				Dim size As Size = Me.Toolbox.Size
				Dim num As Integer = newsize + 16
				Dim size2 As Size = New Size(size.Width, num)
				MyBase.Size = size2
				Dim location As Point = New Point(0, 16)
				Me.Toolbox.Location = location
				MyBase.ResumeLayout(False)
				Me.MinHeightP = num
				Me.MinWidth = Me.Toolbox.Width
				Me.raise_OpenStateToggledEvent()
			End If
		End Sub

		Protected Sub raise_OpenStateToggledEvent()
			Dim openStateToggledEvent As ToolboxContainer.OpenStateToggleHandler = Me.OpenStateToggledEvent
			If openStateToggledEvent IsNot Nothing Then
				openStateToggledEvent()
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
