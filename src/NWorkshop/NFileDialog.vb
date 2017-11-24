Imports NControls
Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Resources
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NFileDialog
		Inherits Form

		Private UnitFilePickerTextBox As NFilePickerTextBox

		Private panTab As Panel

		Private panPreview As Panel

		Private btnCancel As Button

		Private btnOK As Button

		Private labRecentPreview As Label

		Private panRecentPreViewport As Panel

		Private labRecentPreviewUnderConstruction As Label

		Private tabMode As TabControl

		Private tabNew As TabPage

		Private tabRecent As TabPage

		Private panRecent As Panel

		Private radRecentThumbnails As RadioButton

		Private radRecentDetails As RadioButton

		Private labRecentLocation As Label

		Private btnRecentLocationRoot As Button

		Private btnRecentLocationUp As Button

		Private cmbRecentLocation As ComboBox

		Private listRecent As ListView

		Private labRecentFileType As Label

		Private labRecentFileName As Label

		Private cmbRecentFileName As ComboBox

		Private cmbRecentFileType As ComboBox

		Private splitPreview As Splitter

		Private colOpenFileName As ColumnHeader

		Private colOpenFileSize As ColumnHeader

		Private colOpenFileDate As ColumnHeader

		Private imgFileTypeLargeIcons As ImageList

		Private imgFileTypeSmallIcons As ImageList

		Private tabBrowse As TabPage

		Private panBrowse As Panel

		Private radBrowseThumbnails As RadioButton

		Private radBrowseDetails As RadioButton

		Private listBrowse As ListView

		Private labBrowseLocation As Label

		Private labBrowseFileType As Label

		Private labBrowseFileName As Label

		Private cmbBrowseFileName As ComboBox

		Private cmbBrowseFileType As ComboBox

		Private btnBrowseLocationRoot As Button

		Private btnBrowseLocationUp As Button

		Private cmbBrowseLocation As ComboBox

		Private colRecentFileName As ColumnHeader

		Private SizeGroup As GroupBox

		Private trkWidth As TrackBar

		Private tbSize As TextBox

		Private chkSquare As CheckBox

		Private trkHeight As TrackBar

		Private tbInnerSize As TextBox

		Private InheritGroup As GroupBox

		Private label1 As Label

		Private components As IContainer

		Private propAvailableModes As Integer

		Private propSelectedMode As Integer

		Private FullBrowse As Boolean

		Private propLocation As __Pointer(Of GPath)

		Private propCurrentLocation As __Pointer(Of GPath)

		Private propFileName As String

		Private propDefaultExtension As String

		Private FileType As Integer

		Private RecentFiles As __Pointer(Of GArray<GBaseString<char> >)

		Private IconSrvr As ImageServer

		Private SquareMap As Boolean

		Private MapWidth As Integer

		Private MapHeight As Integer

		Private ShellMenuPos As Point

		Private IsUnitEditorType As Boolean

		Public ReadOnly Property NewUnitFileName() As String
			Get
				Return Me.UnitFilePickerTextBox.Text
			End Get
		End Property

		Public ReadOnly Property NewHeight() As Integer
			Get
				Return Me.MapHeight
			End Get
		End Property

		Public ReadOnly Property NewWidht() As Integer
			Get
				Return Me.MapWidth
			End Get
		End Property

		Public Property DefaultExtension() As String
			Get
				Return Me.propDefaultExtension
			End Get
			Set(value As String)
				Me.propDefaultExtension = value
				If value.Length > 0 Then
					Me.cmbBrowseFileType.Text = "*." + value
				Else
					Me.cmbBrowseFileType.Text = "*.*"
				End If
			End Set
		End Property

		Public Property FilePath() As String
			Get
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.FileName)
				Dim result As String
				Try
					Dim num As UInteger = CUInt((__Dereference(ptr)))
					Dim ptr2 As __Pointer(Of SByte)
					If num <> 0UI Then
						ptr2 = num
					Else
						ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gPath As GPath
					Dim ptr3 As __Pointer(Of GPath) = <Module>.GPath.{ctor}(gPath, ptr2)
					Try
						Dim gPath2 As GPath
						Dim ptr4 As __Pointer(Of GPath) = <Module>.GPath.{ctor}(gPath2, Me.Location)
						Try
							Dim gPath3 As GPath
							Dim ptr5 As __Pointer(Of GPath) = <Module>.GPath.+(ptr4, AddressOf gPath3, ptr3)
							Try
								Dim gBaseString<char>2 As GBaseString<char>
								<Module>.GPath..?AV?$GBaseString@D@@(ptr5, CType((AddressOf gBaseString<char>2), __Pointer(Of GBaseString<char>)))
								Try
									Dim gBaseString<char>3 As GBaseString<char>
									If __Dereference((gBaseString<char>2 + 4)) <> 0 Then
										__Dereference((gBaseString<char>3 + 4)) = __Dereference((gBaseString<char>2 + 4))
										Dim num2 As UInteger = CUInt((__Dereference((gBaseString<char>2 + 4)) + 1))
										gBaseString<char>3 = <Module>.malloc(num2)
										cpblk(gBaseString<char>3, gBaseString<char>2, num2)
									Else
										__Dereference((gBaseString<char>3 + 4)) = 0
										gBaseString<char>3 = 0
									End If
									Try
										result = New String(CType((If((gBaseString<char>3 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>3)), __Pointer(Of SByte)))
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>3 IsNot Nothing Then
										<Module>.free(gBaseString<char>3)
									End If
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
									Throw
								End Try
								If gBaseString<char>2 IsNot Nothing Then
									<Module>.free(gBaseString<char>2)
									gBaseString<char>2 = 0
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath3), __Pointer(Of Void)))
								Throw
							End Try
							Try
								<Module>.GArray<GBaseString<char> >.{dtor}(gPath3 + 12)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath3), __Pointer(Of Void)))
								Throw
							End Try
							If gPath3 IsNot Nothing Then
								<Module>.free(gPath3)
								gPath3 = 0
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath2), __Pointer(Of Void)))
							Throw
						End Try
						Try
							<Module>.GArray<GBaseString<char> >.{dtor}(gPath2 + 12)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath2), __Pointer(Of Void)))
							Throw
						End Try
						If gPath2 IsNot Nothing Then
							<Module>.free(gPath2)
							gPath2 = 0
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
						Throw
					End Try
					Try
						<Module>.GArray<GBaseString<char> >.{dtor}(gPath + 12)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
						Throw
					End Try
					If gPath IsNot Nothing Then
						<Module>.free(gPath)
						gPath = 0
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Return result
			End Get
			Set(value As String)
				Dim gBaseString<char> As GBaseString<char>
				Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, value)
				Dim gPath As GPath
				Try
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.Dirname(ptr, AddressOf gBaseString<char>2)
					Try
						Dim num As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
						Dim ptr3 As __Pointer(Of SByte)
						If num <> 0UI Then
							ptr3 = num
						Else
							ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						<Module>.GPath.{ctor}(gPath, ptr3)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
							gBaseString<char>2 = 0
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
						Throw
					End Try
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
					Me.Location = AddressOf gPath
					Dim gBaseString<char>3 As GBaseString<char>
					Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, value)
					Try
						Dim gBaseString<char>4 As GBaseString<char>
						Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.Basename(ptr4, AddressOf gBaseString<char>4)
						Try
							Dim num2 As UInteger = CUInt((__Dereference(CType(ptr5, __Pointer(Of Integer)))))
							Dim value2 As __Pointer(Of SByte)
							If num2 <> 0UI Then
								value2 = num2
							Else
								value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							Me.FileName = New String(CType(value2, __Pointer(Of SByte)))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>4 IsNot Nothing Then
							<Module>.free(gBaseString<char>4)
							gBaseString<char>4 = 0
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>3 IsNot Nothing Then
						<Module>.free(gBaseString<char>3)
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
					Throw
				End Try
				Try
					<Module>.GArray<GBaseString<char> >.{dtor}(gPath + 12)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
					Throw
				End Try
				If gPath IsNot Nothing Then
					<Module>.free(gPath)
				End If
			End Set
		End Property

		Public Property FileName() As String
			Get
				Return Me.propFileName
			End Get
			Set(value As String)
				Me.propFileName = value
				Me.cmbBrowseFileName.Text = value
			End Set
		End Property

		Private Property CurrentLocation() As __Pointer(Of GPath)
			Get
				Return Me.propCurrentLocation
			End Get
			Set(value As __Pointer(Of GPath))
				<Module>.GPath.=(Me.propCurrentLocation, value)
				<Module>.GPath.Collapse(Me.propCurrentLocation)
				Dim gBaseString<char> As GBaseString<char>
				<Module>.GPath..?AV?$GBaseString@D@@(Me.propCurrentLocation, CType((AddressOf gBaseString<char>), __Pointer(Of GBaseString<char>)))
				Try
					Dim gBaseString<char>2 As GBaseString<char>
					If __Dereference((gBaseString<char> + 4)) <> 0 Then
						__Dereference((gBaseString<char>2 + 4)) = __Dereference((gBaseString<char> + 4))
						Dim num As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
						gBaseString<char>2 = <Module>.malloc(num)
						cpblk(gBaseString<char>2, gBaseString<char>, num)
					Else
						__Dereference((gBaseString<char>2 + 4)) = 0
						gBaseString<char>2 = 0
					End If
					Try
						Dim value2 As __Pointer(Of SByte)
						If gBaseString<char>2 IsNot Nothing Then
							value2 = gBaseString<char>2
						Else
							value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.cmbBrowseLocation.Text = New String(CType(value2, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char> IsNot Nothing Then
					<Module>.free(gBaseString<char>)
				End If
				Dim gBaseString<char>3 As GBaseString<char>
				<Module>.GPath..?AV?$GBaseString@D@@(Me.propCurrentLocation, CType((AddressOf gBaseString<char>3), __Pointer(Of GBaseString<char>)))
				Try
					Dim gBaseString<char>4 As GBaseString<char>
					If __Dereference((gBaseString<char>3 + 4)) <> 0 Then
						__Dereference((gBaseString<char>4 + 4)) = __Dereference((gBaseString<char>3 + 4))
						Dim num2 As UInteger = CUInt((__Dereference((gBaseString<char>3 + 4)) + 1))
						gBaseString<char>4 = <Module>.malloc(num2)
						cpblk(gBaseString<char>4, gBaseString<char>3, num2)
					Else
						__Dereference((gBaseString<char>4 + 4)) = 0
						gBaseString<char>4 = 0
					End If
					Try
						Dim value3 As __Pointer(Of SByte)
						If gBaseString<char>4 IsNot Nothing Then
							value3 = gBaseString<char>4
						Else
							value3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Me.cmbRecentLocation.Text = New String(CType(value3, __Pointer(Of SByte)))
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>4 IsNot Nothing Then
						<Module>.free(gBaseString<char>4)
					End If
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>3 IsNot Nothing Then
					<Module>.free(gBaseString<char>3)
				End If
			End Set
		End Property

		Private Property Location() As __Pointer(Of GPath)
			Get
				Return Me.propLocation
			End Get
			Set(value As __Pointer(Of GPath))
				<Module>.GPath.=(Me.propLocation, value)
				<Module>.GPath.Collapse(Me.propLocation)
				Me.CurrentLocation = value
			End Set
		End Property

		Public Property SelectedMode() As Integer
			Get
				Return Me.propSelectedMode
			End Get
			Set(value As Integer)
				If(Me.propAvailableModes And value) <> 0 Then
					Me.propSelectedMode = value
					Select Case value
						Case 1
							Me.tabMode.SelectedTab = Me.tabNew
						Case 2, 4
							Me.tabMode.SelectedTab = Me.tabBrowse
						Case 8
							Me.tabMode.SelectedTab = Me.tabRecent
					End Select
				End If
			End Set
		End Property

		Public Property AvailableModes() As Integer
			Get
				Return Me.propAvailableModes
			End Get
			Set(value As Integer)
				Me.propAvailableModes = 0
				Me.propSelectedMode = 0
				Me.tabMode.SuspendLayout()
				Me.tabMode.Controls.Clear()
				If(value And 4) <> 0 Then
					Me.propAvailableModes = Me.propAvailableModes Or 4
					Me.tabMode.Controls.Add(Me.tabBrowse)
					Me.tabBrowse.Text = "Save"
				Else
					If(value And 1) <> 0 Then
						Me.propAvailableModes = Me.propAvailableModes Or 1
						If Me.IsUnitEditorType Then
							Me.SizeGroup.Hide()
							Dim nFilePickerTextBox As NFilePickerTextBox = New NFilePickerTextBox(NewAssetPicker.ObjectType.UnitEditor, 30)
							Me.UnitFilePickerTextBox = nFilePickerTextBox
							nFilePickerTextBox.BorderStyle = BorderStyle.None
							Dim location As Point = New Point(110, 16)
							Me.UnitFilePickerTextBox.Location = location
							Dim size As Size = New Size(290, 20)
							Me.UnitFilePickerTextBox.Size = size
							Me.InheritGroup.Controls.Add(Me.UnitFilePickerTextBox)
							Me.tabNew.Controls.Add(Me.InheritGroup)
						End If
						Me.tabMode.Controls.Add(Me.tabNew)
					End If
					If(value And 2) <> 0 Then
						Me.propAvailableModes = Me.propAvailableModes Or 2
						Me.tabMode.Controls.Add(Me.tabBrowse)
						Me.tabBrowse.Text = "Open"
						If(value And 8) <> 0 Then
							Me.propAvailableModes = Me.propAvailableModes Or 8
							Me.tabMode.Controls.Add(Me.tabRecent)
						End If
					End If
				End If
				Me.tabMode.ResumeLayout()
			End Set
		End Property

		Public Sub New(recentfiles As __Pointer(Of GArray<GBaseString<char> >), <MarshalAs(UnmanagedType.U1)> full_browse As Boolean)
			Me.InitializeComponent()
			Dim imageServer As ImageServer = ImageServer.GetImageServer("Images")
			Me.IconSrvr = imageServer
			Dim image As Image = imageServer.GetImage("Map_16", KnownColor.Window)
			If image IsNot Nothing Then
				Me.imgFileTypeSmallIcons.Images.Add(image)
			End If
			Dim image2 As Image = Me.IconSrvr.GetImage("Folder_Up_16", KnownColor.Window)
			If image2 IsNot Nothing Then
				Me.imgFileTypeSmallIcons.Images.Add(image2)
			End If
			Dim image3 As Image = Me.IconSrvr.GetImage("Folder_16", KnownColor.Window)
			If image3 IsNot Nothing Then
				Me.imgFileTypeSmallIcons.Images.Add(image3)
			End If
			Dim image4 As Image = Me.IconSrvr.GetImage("Map_32", KnownColor.Window)
			If image4 IsNot Nothing Then
				Me.imgFileTypeLargeIcons.Images.Add(image4)
			End If
			Dim image5 As Image = Me.IconSrvr.GetImage("Folder_Up_64", KnownColor.Window)
			If image5 IsNot Nothing Then
				Me.imgFileTypeLargeIcons.Images.Add(image5)
			End If
			Dim image6 As Image = Me.IconSrvr.GetImage("Folder_64", KnownColor.Window)
			If image6 IsNot Nothing Then
				Me.imgFileTypeLargeIcons.Images.Add(image6)
			End If
			Me.propAvailableModes = 11
			Me.propSelectedMode = 1
			Dim ptr As __Pointer(Of GPath) = <Module>.new(24UI)
			Dim ptr2 As __Pointer(Of GPath)
			Try
				If ptr IsNot Nothing Then
					ptr2 = <Module>.GPath.{ctor}(ptr)
				Else
					ptr2 = 0
				End If
			Catch 
				<Module>.delete(CType(ptr, __Pointer(Of Void)))
				Throw
			End Try
			Me.propLocation = ptr2
			Dim ptr3 As __Pointer(Of GPath) = <Module>.new(24UI)
			Dim ptr4 As __Pointer(Of GPath)
			Try
				If ptr3 IsNot Nothing Then
					ptr4 = <Module>.GPath.{ctor}(ptr3)
				Else
					ptr4 = 0
				End If
			Catch 
				<Module>.delete(CType(ptr3, __Pointer(Of Void)))
				Throw
			End Try
			Me.propCurrentLocation = ptr4
			Me.RecentFiles = recentfiles
			Me.FullBrowse = full_browse
			Me.labBrowseFileName.Enabled = full_browse
			Me.cmbBrowseFileName.Enabled = Me.FullBrowse
			Dim gPath As GPath
			<Module>.GPath.{ctor}(gPath)
			Try
				Dim recentFiles As __Pointer(Of GArray<GBaseString<char> >) = Me.RecentFiles
				If recentFiles IsNot Nothing AndAlso __Dereference(CType((recentFiles + 4 / __SizeOf(GArray<GBaseString<char> >)), __Pointer(Of Integer))) <> 0 Then
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.Dirname(__Dereference(CType(recentFiles, __Pointer(Of Integer))), AddressOf gBaseString<char>)
					Try
						Dim num As UInteger = CUInt((__Dereference(CType(ptr5, __Pointer(Of Integer)))))
						Dim ptr6 As __Pointer(Of SByte)
						If num <> 0UI Then
							ptr6 = num
						Else
							ptr6 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						<Module>.GPath.=(gPath, ptr6)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
				Else If Me.FullBrowse Then
					<Module>.GPath.=(gPath, <Module>.GFileSystem.GetHomePath(<Module>.FS))
				End If
				Me.Location = AddressOf gPath
				Me.propFileName = ""
				Me.propDefaultExtension = ""
				Me.FileType = 0
				Me.Update_listBrowse()
				Me.SquareMap = True
				Me.trkHeight.Maximum = 60
				Me.trkHeight.Minimum = 6
				Me.trkWidth.Maximum = 60
				Me.trkWidth.Minimum = 6
				Me.MapWidth = 240
				Me.MapHeight = 240
				Me.tbSize.Text = (CSng((CSng(Me.MapWidth) * __Dereference((<Module>.Measures + 4))))).ToString() + "x" + (CSng((__Dereference((<Module>.Measures + 4)) * 240F))).ToString()
				Me.tbInnerSize.Text = (CSng((CSng((Me.MapWidth - 32)) * __Dereference((<Module>.Measures + 4))))).ToString() + "x" + (CSng((CSng((Me.MapHeight - 32)) * __Dereference((<Module>.Measures + 4))))).ToString()
				Me.IsUnitEditorType = False
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
				Throw
			End Try
			Try
				<Module>.GArray<GBaseString<char> >.{dtor}(gPath + 12)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
				Throw
			End Try
			If gPath IsNot Nothing Then
				<Module>.free(gPath)
			End If
		End Sub

		Public Sub UpdateRecentFiles()
			Dim gBaseString<char> As GBaseString<char>
			<Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.FilePath)
			Try
				Dim num As Integer = 0
				Dim recentFiles As __Pointer(Of GArray<GBaseString<char> >) = Me.RecentFiles
				Dim ptr As __Pointer(Of GArray<GBaseString<char> >) = recentFiles
				Dim num2 As Integer = __Dereference((ptr + 4))
				If 0 < num2 Then
					Do
						Dim ptr2 As __Pointer(Of GArray<GBaseString<char> >) = recentFiles
						If(If((<Module>.GBaseString<char>.Compare(num * 8 + __Dereference(ptr2), gBaseString<char>, False) = 0), 1, 0)) <> 0 Then
							GoTo IL_5A
						End If
						num += 1
						recentFiles = Me.RecentFiles
						ptr = recentFiles
						num2 = __Dereference((ptr + 4))
					Loop While num < num2
					GoTo IL_66
					IL_5A:
					<Module>.GArray<GBaseString<char> >.Remove(Me.RecentFiles, num)
				End If
				IL_66:
				Dim recentFiles2 As __Pointer(Of GArray<GBaseString<char> >) = Me.RecentFiles
				If __Dereference(CType((recentFiles2 + 4 / __SizeOf(GArray<GBaseString<char> >)), __Pointer(Of Integer))) > 20 Then
					Dim num3 As Integer = __Dereference(CType((recentFiles2 + 4 / __SizeOf(GArray<GBaseString<char> >)), __Pointer(Of Integer)))
					<Module>.GArray<GBaseString<char> >.Remove(recentFiles2, num3 - 1)
				End If
				Dim arg_9A_0 As __Pointer(Of GBaseString<char>) = <Module>.GArray<GBaseString<char> >.Insert(Me.RecentFiles, 0)
				Dim recentFiles3 As __Pointer(Of GArray<GBaseString<char> >) = Me.RecentFiles
				Dim ptr3 As __Pointer(Of GBaseString<char>) = arg_9A_0 * 8 + __Dereference(recentFiles3)
				If __Dereference((gBaseString<char> + 4)) <> 0 Then
					__Dereference((ptr3 + 4)) = __Dereference((gBaseString<char> + 4))
					Dim ptr4 As __Pointer(Of Void) = <Module>.realloc(__Dereference(ptr3), CUInt((__Dereference((gBaseString<char> + 4)) + 1)))
					__Dereference(ptr3) = ptr4
					cpblk(ptr4, gBaseString<char>, __Dereference((ptr3 + 4)) + 1)
				Else
					__Dereference((ptr3 + 4)) = 0
					Dim num4 As Integer = __Dereference(ptr3)
					If num4 <> 0 Then
						<Module>.free(num4)
						__Dereference(ptr3) = 0
					End If
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
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
			Dim resourceManager As ResourceManager = New ResourceManager(GetType(NFileDialog))
			Me.panTab = New Panel()
			Me.tabMode = New TabControl()
			Me.tabNew = New TabPage()
			Me.InheritGroup = New GroupBox()
			Me.SizeGroup = New GroupBox()
			Me.tbInnerSize = New TextBox()
			Me.chkSquare = New CheckBox()
			Me.tbSize = New TextBox()
			Me.trkHeight = New TrackBar()
			Me.trkWidth = New TrackBar()
			Me.tabBrowse = New TabPage()
			Me.panBrowse = New Panel()
			Me.radBrowseThumbnails = New RadioButton()
			Me.radBrowseDetails = New RadioButton()
			Me.listBrowse = New ListView()
			Me.colOpenFileName = New ColumnHeader()
			Me.colOpenFileSize = New ColumnHeader()
			Me.colOpenFileDate = New ColumnHeader()
			Me.imgFileTypeLargeIcons = New ImageList(Me.components)
			Me.imgFileTypeSmallIcons = New ImageList(Me.components)
			Me.labBrowseLocation = New Label()
			Me.labBrowseFileType = New Label()
			Me.labBrowseFileName = New Label()
			Me.cmbBrowseFileName = New ComboBox()
			Me.cmbBrowseFileType = New ComboBox()
			Me.btnBrowseLocationRoot = New Button()
			Me.btnBrowseLocationUp = New Button()
			Me.cmbBrowseLocation = New ComboBox()
			Me.tabRecent = New TabPage()
			Me.panRecent = New Panel()
			Me.radRecentThumbnails = New RadioButton()
			Me.radRecentDetails = New RadioButton()
			Me.labRecentLocation = New Label()
			Me.btnRecentLocationRoot = New Button()
			Me.btnRecentLocationUp = New Button()
			Me.cmbRecentLocation = New ComboBox()
			Me.listRecent = New ListView()
			Me.colRecentFileName = New ColumnHeader()
			Me.labRecentFileType = New Label()
			Me.labRecentFileName = New Label()
			Me.cmbRecentFileName = New ComboBox()
			Me.cmbRecentFileType = New ComboBox()
			Me.panPreview = New Panel()
			Me.panRecentPreViewport = New Panel()
			Me.labRecentPreviewUnderConstruction = New Label()
			Me.labRecentPreview = New Label()
			Me.btnCancel = New Button()
			Me.btnOK = New Button()
			Me.splitPreview = New Splitter()
			Me.label1 = New Label()
			Me.panTab.SuspendLayout()
			Me.tabMode.SuspendLayout()
			Me.tabNew.SuspendLayout()
			Me.InheritGroup.SuspendLayout()
			Me.SizeGroup.SuspendLayout()
			(CType(Me.trkHeight, ISupportInitialize)).BeginInit()
			(CType(Me.trkWidth, ISupportInitialize)).BeginInit()
			Me.tabBrowse.SuspendLayout()
			Me.panBrowse.SuspendLayout()
			Me.tabRecent.SuspendLayout()
			Me.panRecent.SuspendLayout()
			Me.panPreview.SuspendLayout()
			Me.panRecentPreViewport.SuspendLayout()
			MyBase.SuspendLayout()
			Me.panTab.Controls.Add(Me.tabMode)
			Me.panTab.Dock = DockStyle.Fill
			Dim location As Point = New Point(0, 0)
			Me.panTab.Location = location
			Me.panTab.Name = "panTab"
			Dim size As Size = New Size(429, 413)
			Me.panTab.Size = size
			Me.panTab.TabIndex = 3
			Me.tabMode.Alignment = TabAlignment.Bottom
			Me.tabMode.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.tabMode.Controls.Add(Me.tabNew)
			Me.tabMode.Controls.Add(Me.tabBrowse)
			Me.tabMode.Controls.Add(Me.tabRecent)
			Dim location2 As Point = New Point(0, 0)
			Me.tabMode.Location = location2
			Me.tabMode.Name = "tabMode"
			Dim padding As Point = New Point(16, 5)
			Me.tabMode.Padding = padding
			Me.tabMode.SelectedIndex = 0
			Dim size2 As Size = New Size(429, 392)
			Me.tabMode.Size = size2
			Me.tabMode.TabIndex = 1
			AddHandler Me.tabMode.SelectedIndexChanged, AddressOf Me.tabMode_SelectedIndexChanged
			Me.tabNew.Controls.Add(Me.SizeGroup)
			Dim location3 As Point = New Point(4, 4)
			Me.tabNew.Location = location3
			Me.tabNew.Name = "tabNew"
			Dim size3 As Size = New Size(421, 366)
			Me.tabNew.Size = size3
			Me.tabNew.TabIndex = 0
			Me.tabNew.Text = "New"
			Me.InheritGroup.Controls.Add(Me.label1)
			Dim location4 As Point = New Point(8, 8)
			Me.InheritGroup.Location = location4
			Me.InheritGroup.Name = "InheritGroup"
			Dim size4 As Size = New Size(408, 44)
			Me.InheritGroup.Size = size4
			Me.InheritGroup.TabIndex = 1
			Me.InheritGroup.TabStop = False
			Me.InheritGroup.Text = "Inheritance "
			Me.SizeGroup.Controls.Add(Me.tbInnerSize)
			Me.SizeGroup.Controls.Add(Me.chkSquare)
			Me.SizeGroup.Controls.Add(Me.tbSize)
			Me.SizeGroup.Controls.Add(Me.trkHeight)
			Me.SizeGroup.Controls.Add(Me.trkWidth)
			Me.SizeGroup.FlatStyle = FlatStyle.System
			Dim location5 As Point = New Point(8, 12)
			Me.SizeGroup.Location = location5
			Me.SizeGroup.Name = "SizeGroup"
			Dim size5 As Size = New Size(408, 104)
			Me.SizeGroup.Size = size5
			Me.SizeGroup.TabIndex = 0
			Me.SizeGroup.TabStop = False
			Me.SizeGroup.Text = "Map size"
			Dim location6 As Point = New Point(256, 76)
			Me.tbInnerSize.Location = location6
			Me.tbInnerSize.Name = "tbInnerSize"
			Me.tbInnerSize.[ReadOnly] = True
			Dim size6 As Size = New Size(144, 21)
			Me.tbInnerSize.Size = size6
			Me.tbInnerSize.TabIndex = 4
			Me.tbInnerSize.Text = ""
			Me.chkSquare.Checked = True
			Me.chkSquare.CheckState = CheckState.Checked
			Me.chkSquare.FlatStyle = FlatStyle.System
			Dim location7 As Point = New Point(256, 20)
			Me.chkSquare.Location = location7
			Me.chkSquare.Name = "chkSquare"
			Me.chkSquare.RightToLeft = RightToLeft.No
			Dim size7 As Size = New Size(144, 24)
			Me.chkSquare.Size = size7
			Me.chkSquare.TabIndex = 3
			Me.chkSquare.Text = "Square map"
			AddHandler Me.chkSquare.CheckedChanged, AddressOf Me.chkSquare_CheckedChanged
			Dim location8 As Point = New Point(256, 48)
			Me.tbSize.Location = location8
			Me.tbSize.Name = "tbSize"
			Me.tbSize.[ReadOnly] = True
			Dim size8 As Size = New Size(144, 21)
			Me.tbSize.Size = size8
			Me.tbSize.TabIndex = 2
			Me.tbSize.Text = ""
			Dim location9 As Point = New Point(4, 52)
			Me.trkHeight.Location = location9
			Me.trkHeight.Maximum = 60
			Me.trkHeight.Minimum = 15
			Me.trkHeight.Name = "trkHeight"
			Dim size9 As Size = New Size(248, 34)
			Me.trkHeight.Size = size9
			Me.trkHeight.TabIndex = 1
			Me.trkHeight.Value = 15
			AddHandler Me.trkHeight.Scroll, AddressOf Me.trkHeight_Scroll
			Dim location10 As Point = New Point(4, 20)
			Me.trkWidth.Location = location10
			Me.trkWidth.Maximum = 60
			Me.trkWidth.Minimum = 15
			Me.trkWidth.Name = "trkWidth"
			Dim size10 As Size = New Size(248, 34)
			Me.trkWidth.Size = size10
			Me.trkWidth.TabIndex = 0
			Me.trkWidth.TickStyle = TickStyle.TopLeft
			Me.trkWidth.Value = 15
			AddHandler Me.trkWidth.Scroll, AddressOf Me.trkWidth_Scroll
			Me.tabBrowse.Controls.Add(Me.panBrowse)
			Dim location11 As Point = New Point(4, 4)
			Me.tabBrowse.Location = location11
			Me.tabBrowse.Name = "tabBrowse"
			Dim size11 As Size = New Size(421, 366)
			Me.tabBrowse.Size = size11
			Me.tabBrowse.TabIndex = 1
			Me.tabBrowse.Text = "Open"
			Me.tabBrowse.Visible = False
			Me.panBrowse.Controls.Add(Me.radBrowseThumbnails)
			Me.panBrowse.Controls.Add(Me.radBrowseDetails)
			Me.panBrowse.Controls.Add(Me.listBrowse)
			Me.panBrowse.Controls.Add(Me.labBrowseLocation)
			Me.panBrowse.Controls.Add(Me.labBrowseFileType)
			Me.panBrowse.Controls.Add(Me.labBrowseFileName)
			Me.panBrowse.Controls.Add(Me.cmbBrowseFileName)
			Me.panBrowse.Controls.Add(Me.cmbBrowseFileType)
			Me.panBrowse.Controls.Add(Me.btnBrowseLocationRoot)
			Me.panBrowse.Controls.Add(Me.btnBrowseLocationUp)
			Me.panBrowse.Controls.Add(Me.cmbBrowseLocation)
			Me.panBrowse.Dock = DockStyle.Fill
			Dim location12 As Point = New Point(0, 0)
			Me.panBrowse.Location = location12
			Me.panBrowse.Name = "panBrowse"
			Dim size12 As Size = New Size(421, 366)
			Me.panBrowse.Size = size12
			Me.panBrowse.TabIndex = 4
			Me.radBrowseThumbnails.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Me.radBrowseThumbnails.Appearance = Appearance.Button
			Me.radBrowseThumbnails.FlatStyle = FlatStyle.System
			Dim location13 As Point = New Point(396, 4)
			Me.radBrowseThumbnails.Location = location13
			Me.radBrowseThumbnails.Name = "radBrowseThumbnails"
			Dim size13 As Size = New Size(24, 21)
			Me.radBrowseThumbnails.Size = size13
			Me.radBrowseThumbnails.TabIndex = 12
			Me.radBrowseThumbnails.Text = "T"
			AddHandler Me.radBrowseThumbnails.CheckedChanged, AddressOf Me.radBrowseThumbnails_CheckedChanged
			Me.radBrowseDetails.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Me.radBrowseDetails.Appearance = Appearance.Button
			Me.radBrowseDetails.Checked = True
			Me.radBrowseDetails.FlatStyle = FlatStyle.System
			Dim location14 As Point = New Point(368, 4)
			Me.radBrowseDetails.Location = location14
			Me.radBrowseDetails.Name = "radBrowseDetails"
			Dim size14 As Size = New Size(24, 21)
			Me.radBrowseDetails.Size = size14
			Me.radBrowseDetails.TabIndex = 11
			Me.radBrowseDetails.TabStop = True
			Me.radBrowseDetails.Text = "D"
			AddHandler Me.radBrowseDetails.CheckedChanged, AddressOf Me.radBrowseDetails_CheckedChanged
			Me.listBrowse.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim values As ColumnHeader() = New ColumnHeader() { Me.colOpenFileName, Me.colOpenFileSize, Me.colOpenFileDate }
			Me.listBrowse.Columns.AddRange(values)
			Me.listBrowse.FullRowSelect = True
			Me.listBrowse.HideSelection = False
			Me.listBrowse.LargeImageList = Me.imgFileTypeLargeIcons
			Dim location15 As Point = New Point(4, 28)
			Me.listBrowse.Location = location15
			Me.listBrowse.MultiSelect = False
			Me.listBrowse.Name = "listBrowse"
			Dim size15 As Size = New Size(416, 283)
			Me.listBrowse.Size = size15
			Me.listBrowse.SmallImageList = Me.imgFileTypeSmallIcons
			Me.listBrowse.TabIndex = 10
			Me.listBrowse.View = View.Details
			AddHandler Me.listBrowse.Resize, AddressOf Me.listBrowse_Resize
			AddHandler Me.listBrowse.ItemActivate, AddressOf Me.listBrowse_ItemActivate
			AddHandler Me.listBrowse.MouseUp, AddressOf Me.listBrowse_MouseUp
			AddHandler Me.listBrowse.SelectedIndexChanged, AddressOf Me.listBrowse_SelectedIndexChanged
			Me.colOpenFileName.Text = "Name"
			Me.colOpenFileName.Width = 218
			Me.colOpenFileSize.Text = "Size"
			Me.colOpenFileSize.TextAlign = HorizontalAlignment.Right
			Me.colOpenFileSize.Width = 77
			Me.colOpenFileDate.Text = "Date"
			Me.colOpenFileDate.Width = 120
			Me.imgFileTypeLargeIcons.ColorDepth = ColorDepth.Depth24Bit
			Dim imageSize As Size = New Size(32, 32)
			Me.imgFileTypeLargeIcons.ImageSize = imageSize
			Dim magenta As Color = Color.Magenta
			Me.imgFileTypeLargeIcons.TransparentColor = magenta
			Me.imgFileTypeSmallIcons.ColorDepth = ColorDepth.Depth24Bit
			Dim imageSize2 As Size = New Size(16, 16)
			Me.imgFileTypeSmallIcons.ImageSize = imageSize2
			Dim magenta2 As Color = Color.Magenta
			Me.imgFileTypeSmallIcons.TransparentColor = magenta2
			Me.labBrowseLocation.Enabled = False
			Dim location16 As Point = New Point(21, 7)
			Me.labBrowseLocation.Location = location16
			Me.labBrowseLocation.Name = "labBrowseLocation"
			Dim size16 As Size = New Size(50, 16)
			Me.labBrowseLocation.Size = size16
			Me.labBrowseLocation.TabIndex = 9
			Me.labBrowseLocation.Text = "Location:"
			Me.labBrowseFileType.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left)
			Me.labBrowseFileType.Enabled = False
			Dim location17 As Point = New Point(21, 341)
			Me.labBrowseFileType.Location = location17
			Me.labBrowseFileType.Name = "labBrowseFileType"
			Dim size17 As Size = New Size(50, 16)
			Me.labBrowseFileType.Size = size17
			Me.labBrowseFileType.TabIndex = 8
			Me.labBrowseFileType.Text = "FileType:"
			Me.labBrowseFileName.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left)
			Me.labBrowseFileName.Enabled = False
			Dim location18 As Point = New Point(18, 317)
			Me.labBrowseFileName.Location = location18
			Me.labBrowseFileName.Name = "labBrowseFileName"
			Dim size18 As Size = New Size(54, 16)
			Me.labBrowseFileName.Size = size18
			Me.labBrowseFileName.TabIndex = 7
			Me.labBrowseFileName.Text = "FileName:"
			Me.cmbBrowseFileName.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.cmbBrowseFileName.DropDownWidth = 320
			Me.cmbBrowseFileName.Enabled = False
			Me.cmbBrowseFileName.ItemHeight = 13
			Dim location19 As Point = New Point(72, 314)
			Me.cmbBrowseFileName.Location = location19
			Me.cmbBrowseFileName.Name = "cmbBrowseFileName"
			Dim size19 As Size = New Size(348, 21)
			Me.cmbBrowseFileName.Size = size19
			Me.cmbBrowseFileName.TabIndex = 6
			AddHandler Me.cmbBrowseFileName.KeyPress, AddressOf Me.cmbBrowseFileName_KeyPress
			AddHandler Me.cmbBrowseFileName.TextChanged, AddressOf Me.cmbBrowseFileName_TextChanged
			Me.cmbBrowseFileType.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.cmbBrowseFileType.DropDownWidth = 320
			Me.cmbBrowseFileType.Enabled = False
			Me.cmbBrowseFileType.ItemHeight = 13
			Dim location20 As Point = New Point(72, 338)
			Me.cmbBrowseFileType.Location = location20
			Me.cmbBrowseFileType.Name = "cmbBrowseFileType"
			Dim size20 As Size = New Size(348, 21)
			Me.cmbBrowseFileType.Size = size20
			Me.cmbBrowseFileType.TabIndex = 5
			Me.cmbBrowseFileType.Text = "All Files (*.*)"
			Me.btnBrowseLocationRoot.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Me.btnBrowseLocationRoot.FlatStyle = FlatStyle.System
			Dim location21 As Point = New Point(336, 4)
			Me.btnBrowseLocationRoot.Location = location21
			Me.btnBrowseLocationRoot.Name = "btnBrowseLocationRoot"
			Dim size21 As Size = New Size(24, 21)
			Me.btnBrowseLocationRoot.Size = size21
			Me.btnBrowseLocationRoot.TabIndex = 3
			Me.btnBrowseLocationRoot.Text = "/"
			AddHandler Me.btnBrowseLocationRoot.Click, AddressOf Me.btnBrowseLocationRoot_Click
			Me.btnBrowseLocationUp.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Me.btnBrowseLocationUp.FlatStyle = FlatStyle.System
			Dim location22 As Point = New Point(308, 4)
			Me.btnBrowseLocationUp.Location = location22
			Me.btnBrowseLocationUp.Name = "btnBrowseLocationUp"
			Dim size22 As Size = New Size(24, 21)
			Me.btnBrowseLocationUp.Size = size22
			Me.btnBrowseLocationUp.TabIndex = 2
			Me.btnBrowseLocationUp.Text = "^"
			AddHandler Me.btnBrowseLocationUp.Click, AddressOf Me.btnBrowseLocationUp_Click
			Me.cmbBrowseLocation.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.cmbBrowseLocation.DropDownWidth = 272
			Me.cmbBrowseLocation.Enabled = False
			Me.cmbBrowseLocation.ItemHeight = 13
			Dim location23 As Point = New Point(72, 4)
			Me.cmbBrowseLocation.Location = location23
			Me.cmbBrowseLocation.Name = "cmbBrowseLocation"
			Dim size23 As Size = New Size(232, 21)
			Me.cmbBrowseLocation.Size = size23
			Me.cmbBrowseLocation.TabIndex = 1
			Me.tabRecent.Controls.Add(Me.panRecent)
			Dim location24 As Point = New Point(4, 4)
			Me.tabRecent.Location = location24
			Me.tabRecent.Name = "tabRecent"
			Dim size24 As Size = New Size(421, 366)
			Me.tabRecent.Size = size24
			Me.tabRecent.TabIndex = 2
			Me.tabRecent.Text = "Recent"
			Me.tabRecent.Visible = False
			Me.panRecent.Controls.Add(Me.radRecentThumbnails)
			Me.panRecent.Controls.Add(Me.radRecentDetails)
			Me.panRecent.Controls.Add(Me.labRecentLocation)
			Me.panRecent.Controls.Add(Me.btnRecentLocationRoot)
			Me.panRecent.Controls.Add(Me.btnRecentLocationUp)
			Me.panRecent.Controls.Add(Me.cmbRecentLocation)
			Me.panRecent.Controls.Add(Me.listRecent)
			Me.panRecent.Controls.Add(Me.labRecentFileType)
			Me.panRecent.Controls.Add(Me.labRecentFileName)
			Me.panRecent.Controls.Add(Me.cmbRecentFileName)
			Me.panRecent.Controls.Add(Me.cmbRecentFileType)
			Me.panRecent.Dock = DockStyle.Fill
			Dim location25 As Point = New Point(0, 0)
			Me.panRecent.Location = location25
			Me.panRecent.Name = "panRecent"
			Dim size25 As Size = New Size(421, 366)
			Me.panRecent.Size = size25
			Me.panRecent.TabIndex = 5
			Me.radRecentThumbnails.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Me.radRecentThumbnails.Appearance = Appearance.Button
			Me.radRecentThumbnails.FlatStyle = FlatStyle.System
			Dim location26 As Point = New Point(396, 4)
			Me.radRecentThumbnails.Location = location26
			Me.radRecentThumbnails.Name = "radRecentThumbnails"
			Dim size26 As Size = New Size(24, 21)
			Me.radRecentThumbnails.Size = size26
			Me.radRecentThumbnails.TabIndex = 18
			Me.radRecentThumbnails.Text = "T"
			AddHandler Me.radRecentThumbnails.CheckedChanged, AddressOf Me.radRecentThumbnails_CheckedChanged
			Me.radRecentDetails.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Me.radRecentDetails.Appearance = Appearance.Button
			Me.radRecentDetails.Checked = True
			Me.radRecentDetails.FlatStyle = FlatStyle.System
			Dim location27 As Point = New Point(368, 4)
			Me.radRecentDetails.Location = location27
			Me.radRecentDetails.Name = "radRecentDetails"
			Dim size27 As Size = New Size(24, 21)
			Me.radRecentDetails.Size = size27
			Me.radRecentDetails.TabIndex = 17
			Me.radRecentDetails.TabStop = True
			Me.radRecentDetails.Text = "D"
			AddHandler Me.radRecentDetails.CheckedChanged, AddressOf Me.radRecentDetails_CheckedChanged
			Me.labRecentLocation.Enabled = False
			Dim location28 As Point = New Point(21, 7)
			Me.labRecentLocation.Location = location28
			Me.labRecentLocation.Name = "labRecentLocation"
			Dim size28 As Size = New Size(50, 16)
			Me.labRecentLocation.Size = size28
			Me.labRecentLocation.TabIndex = 16
			Me.labRecentLocation.Text = "Location:"
			Me.btnRecentLocationRoot.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Me.btnRecentLocationRoot.Enabled = False
			Me.btnRecentLocationRoot.FlatStyle = FlatStyle.System
			Dim location29 As Point = New Point(336, 4)
			Me.btnRecentLocationRoot.Location = location29
			Me.btnRecentLocationRoot.Name = "btnRecentLocationRoot"
			Dim size29 As Size = New Size(24, 21)
			Me.btnRecentLocationRoot.Size = size29
			Me.btnRecentLocationRoot.TabIndex = 15
			Me.btnRecentLocationRoot.Text = "/"
			Me.btnRecentLocationUp.Anchor = (AnchorStyles.Top Or AnchorStyles.Right)
			Me.btnRecentLocationUp.Enabled = False
			Me.btnRecentLocationUp.FlatStyle = FlatStyle.System
			Dim location30 As Point = New Point(308, 4)
			Me.btnRecentLocationUp.Location = location30
			Me.btnRecentLocationUp.Name = "btnRecentLocationUp"
			Dim size30 As Size = New Size(24, 21)
			Me.btnRecentLocationUp.Size = size30
			Me.btnRecentLocationUp.TabIndex = 14
			Me.btnRecentLocationUp.Text = "^"
			Me.cmbRecentLocation.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.cmbRecentLocation.DropDownWidth = 272
			Me.cmbRecentLocation.Enabled = False
			Me.cmbRecentLocation.ItemHeight = 13
			Dim location31 As Point = New Point(72, 4)
			Me.cmbRecentLocation.Location = location31
			Me.cmbRecentLocation.Name = "cmbRecentLocation"
			Dim size31 As Size = New Size(232, 21)
			Me.cmbRecentLocation.Size = size31
			Me.cmbRecentLocation.TabIndex = 13
			Me.listRecent.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Dim values2 As ColumnHeader() = New ColumnHeader() { Me.colRecentFileName }
			Me.listRecent.Columns.AddRange(values2)
			Me.listRecent.FullRowSelect = True
			Me.listRecent.HideSelection = False
			Me.listRecent.LargeImageList = Me.imgFileTypeLargeIcons
			Dim location32 As Point = New Point(4, 28)
			Me.listRecent.Location = location32
			Me.listRecent.MultiSelect = False
			Me.listRecent.Name = "listRecent"
			Dim size32 As Size = New Size(416, 283)
			Me.listRecent.Size = size32
			Me.listRecent.SmallImageList = Me.imgFileTypeSmallIcons
			Me.listRecent.TabIndex = 10
			Me.listRecent.View = View.Details
			AddHandler Me.listRecent.ItemActivate, AddressOf Me.listRecent_ItemActivate
			AddHandler Me.listRecent.SelectedIndexChanged, AddressOf Me.listRecent_SelectedIndexChanged
			Me.colRecentFileName.Text = "Name"
			Me.colRecentFileName.Width = 410
			Me.labRecentFileType.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left)
			Me.labRecentFileType.Enabled = False
			Dim location33 As Point = New Point(21, 341)
			Me.labRecentFileType.Location = location33
			Me.labRecentFileType.Name = "labRecentFileType"
			Dim size33 As Size = New Size(50, 16)
			Me.labRecentFileType.Size = size33
			Me.labRecentFileType.TabIndex = 8
			Me.labRecentFileType.Text = "FileType:"
			Me.labRecentFileName.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left)
			Me.labRecentFileName.Enabled = False
			Dim location34 As Point = New Point(18, 317)
			Me.labRecentFileName.Location = location34
			Me.labRecentFileName.Name = "labRecentFileName"
			Dim size34 As Size = New Size(54, 16)
			Me.labRecentFileName.Size = size34
			Me.labRecentFileName.TabIndex = 7
			Me.labRecentFileName.Text = "FileName:"
			Me.cmbRecentFileName.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.cmbRecentFileName.DropDownWidth = 320
			Me.cmbRecentFileName.Enabled = False
			Me.cmbRecentFileName.ItemHeight = 13
			Dim location35 As Point = New Point(72, 314)
			Me.cmbRecentFileName.Location = location35
			Me.cmbRecentFileName.Name = "cmbRecentFileName"
			Dim size35 As Size = New Size(348, 21)
			Me.cmbRecentFileName.Size = size35
			Me.cmbRecentFileName.TabIndex = 6
			AddHandler Me.cmbRecentFileName.TextChanged, AddressOf Me.cmbRecentFileName_TextChanged
			Me.cmbRecentFileType.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.cmbRecentFileType.DropDownWidth = 320
			Me.cmbRecentFileType.Enabled = False
			Me.cmbRecentFileType.ItemHeight = 13
			Dim location36 As Point = New Point(72, 338)
			Me.cmbRecentFileType.Location = location36
			Me.cmbRecentFileType.Name = "cmbRecentFileType"
			Dim size36 As Size = New Size(348, 21)
			Me.cmbRecentFileType.Size = size36
			Me.cmbRecentFileType.TabIndex = 5
			Me.cmbRecentFileType.Text = "All Files (*.*)"
			Me.panPreview.Controls.Add(Me.panRecentPreViewport)
			Me.panPreview.Controls.Add(Me.labRecentPreview)
			Me.panPreview.Controls.Add(Me.btnCancel)
			Me.panPreview.Controls.Add(Me.btnOK)
			Me.panPreview.Dock = DockStyle.Right
			Dim location37 As Point = New Point(432, 0)
			Me.panPreview.Location = location37
			Me.panPreview.Name = "panPreview"
			Dim size37 As Size = New Size(200, 413)
			Me.panPreview.Size = size37
			Me.panPreview.TabIndex = 4
			Me.panRecentPreViewport.Anchor = (AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.panRecentPreViewport.BorderStyle = BorderStyle.Fixed3D
			Me.panRecentPreViewport.Controls.Add(Me.labRecentPreviewUnderConstruction)
			Dim location38 As Point = New Point(0, 32)
			Me.panRecentPreViewport.Location = location38
			Me.panRecentPreViewport.Name = "panRecentPreViewport"
			Dim size38 As Size = New Size(196, 340)
			Me.panRecentPreViewport.Size = size38
			Me.panRecentPreViewport.TabIndex = 12
			Me.labRecentPreviewUnderConstruction.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
			Me.labRecentPreviewUnderConstruction.Enabled = False
			Dim location39 As Point = New Point(8, 8)
			Me.labRecentPreviewUnderConstruction.Location = location39
			Me.labRecentPreviewUnderConstruction.Name = "labRecentPreviewUnderConstruction"
			Dim size39 As Size = New Size(179, 16)
			Me.labRecentPreviewUnderConstruction.Size = size39
			Me.labRecentPreviewUnderConstruction.TabIndex = 0
			Me.labRecentPreviewUnderConstruction.Text = "Under Construction!"
			Me.labRecentPreviewUnderConstruction.TextAlign = ContentAlignment.TopCenter
			Me.labRecentPreview.Enabled = False
			Dim location40 As Point = New Point(8, 12)
			Me.labRecentPreview.Location = location40
			Me.labRecentPreview.Name = "labRecentPreview"
			Dim size40 As Size = New Size(50, 17)
			Me.labRecentPreview.Size = size40
			Me.labRecentPreview.TabIndex = 11
			Me.labRecentPreview.Text = "Preview:"
			Me.btnCancel.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Me.btnCancel.DialogResult = DialogResult.Cancel
			Me.btnCancel.FlatStyle = FlatStyle.System
			Dim location41 As Point = New Point(104, 381)
			Me.btnCancel.Location = location41
			Me.btnCancel.Name = "btnCancel"
			Dim size41 As Size = New Size(80, 24)
			Me.btnCancel.Size = size41
			Me.btnCancel.TabIndex = 4
			Me.btnCancel.Text = "Cancel"
			Me.btnOK.Anchor = (AnchorStyles.Bottom Or AnchorStyles.Right)
			Me.btnOK.FlatStyle = FlatStyle.System
			Dim location42 As Point = New Point(20, 381)
			Me.btnOK.Location = location42
			Me.btnOK.Name = "btnOK"
			Dim size42 As Size = New Size(80, 24)
			Me.btnOK.Size = size42
			Me.btnOK.TabIndex = 3
			Me.btnOK.Text = "Create"
			AddHandler Me.btnOK.Click, AddressOf Me.btnOK_Click
			Me.splitPreview.Dock = DockStyle.Right
			Dim location43 As Point = New Point(429, 0)
			Me.splitPreview.Location = location43
			Me.splitPreview.MinExtra = 400
			Me.splitPreview.MinSize = 200
			Me.splitPreview.Name = "splitPreview"
			Dim size43 As Size = New Size(3, 413)
			Me.splitPreview.Size = size43
			Me.splitPreview.TabIndex = 5
			Me.splitPreview.TabStop = False
			Dim location44 As Point = New Point(8, 17)
			Me.label1.Location = location44
			Me.label1.Name = "label1"
			Dim size44 As Size = New Size(96, 15)
			Me.label1.Size = size44
			Me.label1.TabIndex = 0
			Me.label1.Text = "Inherit unit from:"
			MyBase.AcceptButton = Me.btnOK
			MyBase.AutoScale = False
			Dim autoScaleBaseSize As Size = New Size(5, 14)
			Me.AutoScaleBaseSize = autoScaleBaseSize
			MyBase.CancelButton = Me.btnCancel
			Dim clientSize As Size = New Size(632, 413)
			MyBase.ClientSize = clientSize
			MyBase.Controls.Add(Me.panTab)
			MyBase.Controls.Add(Me.splitPreview)
			MyBase.Controls.Add(Me.panPreview)
			Me.Font = New Font("Tahoma", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
			MyBase.Icon = CType(resourceManager.GetObject("$this.Icon"), Icon)
			MyBase.MaximizeBox = False
			MyBase.MinimizeBox = False
			Dim minimumSize As Size = New Size(640, 440)
			Me.MinimumSize = minimumSize
			MyBase.Name = "NFileDialog"
			MyBase.ShowInTaskbar = False
			MyBase.StartPosition = FormStartPosition.CenterParent
			Me.Text = "New"
			AddHandler MyBase.Activated, AddressOf Me.NFileDialog_Activated
			Me.panTab.ResumeLayout(False)
			Me.tabMode.ResumeLayout(False)
			Me.tabNew.ResumeLayout(False)
			Me.InheritGroup.ResumeLayout(False)
			Me.SizeGroup.ResumeLayout(False)
			(CType(Me.trkHeight, ISupportInitialize)).EndInit()
			(CType(Me.trkWidth, ISupportInitialize)).EndInit()
			Me.tabBrowse.ResumeLayout(False)
			Me.panBrowse.ResumeLayout(False)
			Me.tabRecent.ResumeLayout(False)
			Me.panRecent.ResumeLayout(False)
			Me.panPreview.ResumeLayout(False)
			Me.panRecentPreViewport.ResumeLayout(False)
			MyBase.ResumeLayout(False)
		End Sub

		Private Sub HandleShellMenu()
			Dim gBaseString<char> As GBaseString<char> = 0
			__Dereference((gBaseString<char> + 4)) = 0
			Try
				If Me.listBrowse.SelectedItems.Count > 0 Then
					Dim gBaseString<char>2 As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>2, Me.listBrowse.SelectedItems(0).Text)
					Try
						Dim num As Integer = __Dereference((ptr + 4))
						If num <> 0 Then
							__Dereference((gBaseString<char> + 4)) = num
							Dim num2 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
							gBaseString<char> = <Module>.realloc(Nothing, num2)
							cpblk(gBaseString<char>, __Dereference(ptr), num2)
						Else
							__Dereference((gBaseString<char> + 4)) = 0
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>2 IsNot Nothing Then
						<Module>.free(gBaseString<char>2)
						gBaseString<char>2 = 0
					End If
				End If
				Dim point As Point = Me.listBrowse.PointToScreen(Me.ShellMenuPos)
				Dim handle As IntPtr = Me.Handle
				Dim gBaseString<char>3 As GBaseString<char>
				Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GPath.GetShellCompatiblePathString(Me.propCurrentLocation, AddressOf gBaseString<char>3)
				Try
					Dim num3 As UInteger = CUInt((__Dereference(CType(ptr2, __Pointer(Of Integer)))))
					Dim ptr3 As __Pointer(Of SByte)
					If num3 <> 0UI Then
						ptr3 = num3
					Else
						ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					<Module>.SHMLoadShellMenu(If((gBaseString<char> Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>), ptr3, CType(handle.ToPointer(), __Pointer(Of HWND__)), point.X, point.Y)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
					Throw
				End Try
				If gBaseString<char>3 IsNot Nothing Then
					<Module>.free(gBaseString<char>3)
				End If
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
				Throw
			End Try
			If gBaseString<char> IsNot Nothing Then
				<Module>.free(gBaseString<char>)
			End If
		End Sub

		Public Sub SetTypeToUnitEditor()
			Me.IsUnitEditorType = True
		End Sub

		Private Sub listBrowse_Resize(sender As Object, e As EventArgs)
			Dim arg_5B_0 As ColumnHeader = Me.listBrowse.Columns(0)
			Dim columnHeader As ColumnHeader = Me.listBrowse.Columns(1)
			Dim columnHeader2 As ColumnHeader = Me.listBrowse.Columns(2)
			Dim clientRectangle As Rectangle = Me.listBrowse.ClientRectangle
			Dim num As Integer = -3 - columnHeader.Width - columnHeader2.Width
			arg_5B_0.Width = clientRectangle.Width + num
			Me.listBrowse.PerformLayout()
		End Sub

		Private Sub Update_listBrowse()
			Dim num As UInteger = 0UI
			Me.listBrowse.SuspendLayout()
			Me.listBrowse.Items.Clear()
			Dim gPath As GPath
			<Module>.GPath.{ctor}(gPath, Me.CurrentLocation)
			Try
				If(If((<Module>.GBaseString<char>.Compare(gPath, CType((AddressOf <Module>.??_C@_03MKLNKIKF@?1?10?$AA@), __Pointer(Of SByte)), False) <> 0), 1, 0)) <> 0 Then
					Dim gFoundFiles As GFoundFiles = 0
					__Dereference((gFoundFiles + 4)) = 0
					__Dereference((gFoundFiles + 8)) = 0
					Try
						If Not Me.FullBrowse Then
							__Dereference((gPath + 8)) = 0
						End If
						Dim gPath2 As GPath
						Dim ptr As __Pointer(Of GPath) = <Module>.GPath.{ctor}(gPath2, CType((AddressOf <Module>.??_C@_01NBENCBCI@?$CK?$AA@), __Pointer(Of SByte)))
						Try
							Dim gPath3 As GPath
							Dim ptr2 As __Pointer(Of GPath) = <Module>.GPath.+(gPath, AddressOf gPath3, ptr)
							Try
								Dim gBaseString<char> As GBaseString<char>
								<Module>.GPath..?AV?$GBaseString@D@@(ptr2, CType((AddressOf gBaseString<char>), __Pointer(Of GBaseString<char>)))
								Try
									Dim gBaseString<char>2 As GBaseString<char>
									If __Dereference((gBaseString<char> + 4)) <> 0 Then
										__Dereference((gBaseString<char>2 + 4)) = __Dereference((gBaseString<char> + 4))
										Dim num2 As UInteger = CUInt((__Dereference((gBaseString<char> + 4)) + 1))
										gBaseString<char>2 = <Module>.malloc(num2)
										cpblk(gBaseString<char>2, gBaseString<char>, num2)
									Else
										__Dereference((gBaseString<char>2 + 4)) = 0
										gBaseString<char>2 = 0
									End If
									Try
										Dim ptr3 As __Pointer(Of SByte)
										If gBaseString<char>2 IsNot Nothing Then
											ptr3 = gBaseString<char>2
										Else
											ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
										End If
										<Module>.GFileSystem.FindFiles(<Module>.FS, ptr3, gFoundFiles)
									Catch 
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
										Throw
									End Try
									If gBaseString<char>2 IsNot Nothing Then
										<Module>.free(gBaseString<char>2)
									End If
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
									Throw
								End Try
								If gBaseString<char> IsNot Nothing Then
									<Module>.free(gBaseString<char>)
									gBaseString<char> = 0
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath3), __Pointer(Of Void)))
								Throw
							End Try
							Try
								<Module>.GArray<GBaseString<char> >.{dtor}(gPath3 + 12)
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath3), __Pointer(Of Void)))
								Throw
							End Try
							If gPath3 IsNot Nothing Then
								<Module>.free(gPath3)
								gPath3 = 0
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath2), __Pointer(Of Void)))
							Throw
						End Try
						Try
							<Module>.GArray<GBaseString<char> >.{dtor}(gPath2 + 12)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath2), __Pointer(Of Void)))
							Throw
						End Try
						If gPath2 IsNot Nothing Then
							<Module>.free(gPath2)
						End If
						If Me.propDefaultExtension.Length > 0 Then
							Dim num3 As Integer = 0
							If 0 < __Dereference((gFoundFiles + 4)) Then
								Dim num4 As Integer = 0
								While True
									If __Dereference((num4 + gFoundFiles)) <> 0 Then
										GoTo IL_25C
									End If
									Dim gBaseString<char>3 As GBaseString<char>
									Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, Me.propDefaultExtension)
									Dim gBaseString<char>4 As GBaseString<char>
									Try
										num = num Or 1UI
										Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.GetExtension(num4 + gFoundFiles + 24, AddressOf gBaseString<char>4)
										Try
											num = num Or 2UI
											Dim num5 As UInteger = CUInt((__Dereference(ptr4)))
											Dim ptr6 As __Pointer(Of SByte)
											If num5 <> 0UI Then
												ptr6 = num5
											Else
												ptr6 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
											End If
											Dim num6 As UInteger = CUInt((__Dereference(CType(ptr5, __Pointer(Of Integer)))))
											If <Module>.stricmp(If((num6 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num6), ptr6) IsNot Nothing Then
												Dim num7 As Integer = 1
												GoTo IL_294
											End If
										Catch 
											If(num And 2UI) <> 0UI Then
												num = num And 4294967293UI
												<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
											End If
											Throw
										End Try
									Catch 
										If(num And 1UI) <> 0UI Then
											num = num And 4294967294UI
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
										End If
										Throw
									End Try
									GoTo IL_25C
									IL_294:
									Dim flag As Boolean
									Try
										Try
											Dim num7 As Integer
											flag = (CByte(num7) <> 0)
										Catch 
											If(num And 2UI) <> 0UI Then
												num = num And 4294967293UI
												<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
											End If
											Throw
										End Try
										If(num And 2UI) <> 0UI Then
											num = num And 4294967293UI
											If gBaseString<char>4 IsNot Nothing Then
												<Module>.free(gBaseString<char>4)
												gBaseString<char>4 = 0
											End If
										End If
									Catch 
										If(num And 1UI) <> 0UI Then
											num = num And 4294967294UI
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
										End If
										Throw
									End Try
									If(num And 1UI) <> 0UI Then
										num = num And 4294967294UI
										If gBaseString<char>3 IsNot Nothing Then
											<Module>.free(gBaseString<char>3)
											gBaseString<char>3 = 0
										End If
									End If
									If flag Then
										<Module>.GArray<GFoundFile>.Remove(gFoundFiles, num3)
									Else
										num3 += 1
										num4 += 32
									End If
									If num3 >= __Dereference((gFoundFiles + 4)) Then
										Exit While
									End If
									Continue While
									IL_25C:
									Try
										Try
											Dim num7 As Integer = 0
										Catch 
											If(num And 2UI) <> 0UI Then
												num = num And 4294967293UI
												<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
											End If
											Throw
										End Try
									Catch 
										If(num And 1UI) <> 0UI Then
											num = num And 4294967294UI
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
										End If
										Throw
									End Try
									GoTo IL_294
								End While
							End If
						End If
						Dim _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z As method = <Module>.__unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z
						If 0 < __Dereference((gFoundFiles + 4)) Then
							<Module>.qsort(gFoundFiles, CUInt((__Dereference((gFoundFiles + 4)))), 32UI, _unep@?Compare@GFoundFiles@@$$FKAHPBX0@Z)
						End If
						If __Dereference(CType((Me.CurrentLocation + 16 / __SizeOf(GPath)), __Pointer(Of Integer))) <> 0 OrElse Me.FullBrowse Then
							Dim listViewItem As ListViewItem
							If __Dereference(CType((Me.CurrentLocation + 16 / __SizeOf(GPath)), __Pointer(Of Integer))) <> 0 Then
								listViewItem = New ListViewItem("..")
							Else
								listViewItem = New ListViewItem("//0/")
							End If
							listViewItem.SubItems.Add("<DIR>  ")
							listViewItem.ImageIndex = 1
							listViewItem.SubItems.Add("")
							Me.listBrowse.Items.Add(listViewItem)
						End If
						Dim num8 As Integer = 0
						If 0 < __Dereference((gFoundFiles + 4)) Then
							Dim num9 As Integer = 0
							Do
								Dim ptr7 As __Pointer(Of GBaseString<char>) = gFoundFiles + num9 + 24
								Dim num10 As Integer = 0
								If 0 < __Dereference((ptr7 + 4)) Then
									Do
										Dim num11 As Integer = num10 + __Dereference(ptr7)
										If __Dereference(num11) = 92 Then
											__Dereference(num11) = 47
										End If
										num10 += 1
									Loop While num10 < __Dereference((ptr7 + 4))
								End If
								Dim num12 As Integer = gFoundFiles + num9
								Dim ptr8 As __Pointer(Of GFoundFile) = num12
								If 0 >= __Dereference((ptr8 + 24 + 4)) Then
									GoTo IL_533
								End If
								If __Dereference((__Dereference((ptr8 + 24)))) <> 46 Then
									Dim num13 As UInteger = CUInt((__Dereference((num12 + 24))))
									Dim listViewItem2 As ListViewItem = New ListViewItem(New String(CType((If((num13 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num13)), __Pointer(Of SByte))))
									num12 = gFoundFiles + num9
									If __Dereference(num12) <> 0 Then
										listViewItem2.SubItems.Add("<DIR>  ")
										Dim ptr9 As __Pointer(Of GFoundFile) = num9 + gFoundFiles
										If 0 >= __Dereference((ptr9 + 24 + 4)) Then
											GoTo IL_514
										End If
										Dim imageIndex As Integer = If((__Dereference((__Dereference((ptr9 + 24)))) = 46), 1, 2)
										listViewItem2.ImageIndex = imageIndex
									Else
										Dim num14 As Long = __Dereference((num12 + 16))
										listViewItem2.SubItems.Add(num14.ToString())
										listViewItem2.ImageIndex = 0
									End If
									Dim dateTime As DateTime = DateTime.FromFileTime(__Dereference((gFoundFiles + num9 + 8)))
									listViewItem2.SubItems.Add(dateTime.ToString())
									Me.listBrowse.Items.Add(listViewItem2)
								End If
								num8 += 1
								num9 += 32
							Loop While num8 < __Dereference((gFoundFiles + 4))
							GoTo IL_552
							IL_514:
							<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
							<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), 0)
							IL_533:
							<Module>.GLogger.MarkLine(CType((AddressOf <Module>.??_C@_0DG@BGPGHONL@c?3?2jtfcode?2src?2core?2dstruct?2?4?4?1t@), __Pointer(Of SByte)), 315, CType((AddressOf <Module>.??_C@_0BP@DABAEMKJ@GBaseString?$DMchar?$DO?3?3operator?5?$FL?$FN?$AA@), __Pointer(Of SByte)))
							<Module>.GLogger.Panic(CType((AddressOf <Module>.??_C@_0BD@BJBMHDG@invalid?5index?5?$CI?$CFd?$CJ?$AA@), __Pointer(Of SByte)), 0)
						End If
						IL_552:
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GFoundFiles.{dtor}), CType((AddressOf gFoundFiles), __Pointer(Of Void)))
						Throw
					End Try
					Dim num15 As Integer = 0
					If 0 < __Dereference((gFoundFiles + 4)) Then
						Dim num16 As Integer = 0
						Do
							<Module>.GFoundFile.__delDtor(num16 + gFoundFiles, 0UI)
							num15 += 1
							num16 += 32
						Loop While num15 < __Dereference((gFoundFiles + 4))
					End If
					If gFoundFiles IsNot Nothing Then
						<Module>.free(gFoundFiles)
					End If
				Else
					Dim b As SByte = 65
					Do
						Dim gBaseString<char>5 As GBaseString<char>
						Dim ptr10 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>5, CType((AddressOf <Module>.??_C@_04CGJNICGF@?$CFc?3?2?$AA@), __Pointer(Of SByte)), b)
						Dim driveTypeA As UInteger
						Try
							Dim num17 As UInteger = CUInt((__Dereference(CType(ptr10, __Pointer(Of Integer)))))
							driveTypeA = <Module>.GetDriveTypeA(If((num17 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num17))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>5 IsNot Nothing Then
							<Module>.free(gBaseString<char>5)
							gBaseString<char>5 = 0
						End If
						If driveTypeA > 1UI Then
							Dim gBaseString<char>6 As GBaseString<char>
							Dim ptr11 As __Pointer(Of GBaseString<char>) = <Module>.Format(AddressOf gBaseString<char>6, CType((AddressOf <Module>.??_C@_04CGJNICGF@?$CFc?3?2?$AA@), __Pointer(Of SByte)), b)
							Dim listViewItem3 As ListViewItem
							Try
								Dim num18 As UInteger = CUInt((__Dereference(CType(ptr11, __Pointer(Of Integer)))))
								listViewItem3 = New ListViewItem(New String(CType((If((num18 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num18)), __Pointer(Of SByte))))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>6 IsNot Nothing Then
								<Module>.free(gBaseString<char>6)
								gBaseString<char>6 = 0
							End If
							Select Case driveTypeA
								Case 2UI
									listViewItem3.SubItems.Add("<Removable>")
								Case 3UI
									listViewItem3.SubItems.Add("<Fixed>")
								Case 4UI
									listViewItem3.SubItems.Add("<Remote>")
								Case 5UI
									listViewItem3.SubItems.Add("<CD-ROM>")
								Case 6UI
									listViewItem3.SubItems.Add("<Ramdisk>")
								Case Else
									listViewItem3.SubItems.Add("<Unknown>")
							End Select
							listViewItem3.ImageIndex = 2
							listViewItem3.SubItems.Add("")
							Me.listBrowse.Items.Add(listViewItem3)
						End If
						b += 1
					Loop While b <= 90
				End If
				Me.listBrowse.ResumeLayout()
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
				Throw
			End Try
			Try
				<Module>.GArray<GBaseString<char> >.{dtor}(gPath + 12)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
				Throw
			End Try
			If gPath IsNot Nothing Then
				<Module>.free(gPath)
			End If
		End Sub

		Private Sub listBrowse_Activated(sender As Object, e As EventArgs)
		End Sub

		Private Sub listRecent_Activated(sender As Object, e As EventArgs)
			Me.listRecent.SuspendLayout()
			Me.listRecent.Items.Clear()
			Dim num As Integer = 0
			Dim recentFiles As __Pointer(Of GArray<GBaseString<char> >) = Me.RecentFiles
			If 0 < __Dereference(CType((recentFiles + 4 / __SizeOf(GArray<GBaseString<char> >)), __Pointer(Of Integer))) Then
				Do
					Dim num2 As UInteger = CUInt((__Dereference((num * 8 + __Dereference(CType(recentFiles, __Pointer(Of Integer)))))))
					Dim listViewItem As ListViewItem = New ListViewItem(New String(CType((If((num2 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num2)), __Pointer(Of SByte))))
					listViewItem.Tag = num
					listViewItem.ImageIndex = 0
					Me.listRecent.Items.Add(listViewItem)
					num += 1
					recentFiles = Me.RecentFiles
				Loop While num < __Dereference(CType((recentFiles + 4 / __SizeOf(GArray<GBaseString<char> >)), __Pointer(Of Integer)))
			End If
			If Me.listRecent.Items.Count <> 0 Then
				Me.listRecent.Items(0).Selected = True
			End If
			Me.listRecent.ResumeLayout()
		End Sub

		Private Sub NFileDialog_Activated(sender As Object, e As EventArgs)
			Dim num As Integer = Me.propSelectedMode
			If num = 1 Then
				Me.Text = "New"
				Me.btnOK.Text = "Create"
				Me.btnOK.Enabled = True
			Else If num = 2 Then
				Me.Text = "Open"
				Me.btnOK.Text = "Open"
				Me.cmbBrowseFileName.Text = ""
				Me.cmbBrowseFileName_TextChanged(sender, e)
				Me.Update_listBrowse()
			Else If num = 4 Then
				Me.Text = "Save As"
				Me.btnOK.Text = "Save"
				Me.cmbBrowseFileName.Text = ""
				Me.cmbBrowseFileName_TextChanged(sender, e)
				Me.Update_listBrowse()
			Else If num = 8 Then
				Me.Text = "Open Recent"
				Me.btnOK.Text = "Open"
				Me.cmbRecentLocation.Text = ""
				Me.cmbRecentFileName.Text = ""
				Me.cmbRecentFileName_TextChanged(sender, e)
				Me.listRecent_Activated(sender, e)
			End If
		End Sub

		Private Sub tabMode_SelectedIndexChanged(sender As Object, e As EventArgs)
			If Me.tabMode.SelectedTab Is Me.tabNew Then
				Me.propSelectedMode = (Me.propAvailableModes And 1)
			Else If Me.tabMode.SelectedTab Is Me.tabBrowse Then
				Me.propSelectedMode = (Me.propAvailableModes And 2)
			Else If Me.tabMode.SelectedTab Is Me.tabRecent Then
				Me.propSelectedMode = (Me.propAvailableModes And 8)
			End If
			Me.NFileDialog_Activated(sender, e)
		End Sub

		Private Sub btnBrowseLocationRoot_Click(sender As Object, e As EventArgs)
			Dim gPath As GPath
			<Module>.GPath.{ctor}(gPath, Me.CurrentLocation)
			Try
				__Dereference((gPath + 8)) = 1
				<Module>.GArray<GBaseString<char> >.Clear(gPath + 12, 0)
				Me.CurrentLocation = AddressOf gPath
				Me.cmbBrowseFileName.Text = ""
				Me.btnOK.Enabled = False
				Me.Update_listBrowse()
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
				Throw
			End Try
			Try
				<Module>.GArray<GBaseString<char> >.{dtor}(gPath + 12)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
				Throw
			End Try
			If gPath IsNot Nothing Then
				<Module>.free(gPath)
			End If
		End Sub

		Private Sub btnBrowseLocationUp_Click(sender As Object, e As EventArgs)
			Dim gPath As GPath
			<Module>.GPath.{ctor}(gPath, Me.CurrentLocation)
			Try
				If __Dereference((gPath + 16)) <> 0 Then
					Dim gPath2 As GPath
					Dim ptr As __Pointer(Of GPath) = <Module>.GPath.{ctor}(gPath2, CType((AddressOf <Module>.??_C@_02DJGKEECL@?4?4?$AA@), __Pointer(Of SByte)))
					Try
						<Module>.GPath.+=(gPath, ptr)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath2), __Pointer(Of Void)))
						Throw
					End Try
					Try
						<Module>.GArray<GBaseString<char> >.{dtor}(gPath2 + 12)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath2), __Pointer(Of Void)))
						Throw
					End Try
					If gPath2 IsNot Nothing Then
						<Module>.free(gPath2)
					End If
				Else If Me.FullBrowse Then
					Dim gPath3 As GPath
					Dim ptr2 As __Pointer(Of GPath) = <Module>.GPath.{ctor}(gPath3, CType((AddressOf <Module>.??_C@_04LEGKNCKC@?1?10?1?$AA@), __Pointer(Of SByte)))
					Try
						<Module>.GPath.+=(gPath, ptr2)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath3), __Pointer(Of Void)))
						Throw
					End Try
					Try
						<Module>.GArray<GBaseString<char> >.{dtor}(gPath3 + 12)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath3), __Pointer(Of Void)))
						Throw
					End Try
					If gPath3 IsNot Nothing Then
						<Module>.free(gPath3)
					End If
				End If
				Me.CurrentLocation = AddressOf gPath
				Me.cmbBrowseFileName.Text = ""
				Me.btnOK.Enabled = False
				Me.Update_listBrowse()
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
				Throw
			End Try
			Try
				<Module>.GArray<GBaseString<char> >.{dtor}(gPath + 12)
			Catch 
				<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
				Throw
			End Try
			If gPath IsNot Nothing Then
				<Module>.free(gPath)
			End If
		End Sub

		Private Sub listBrowse_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim selectedItems As ListView.SelectedListViewItemCollection = Me.listBrowse.SelectedItems
			If selectedItems.Count = 1 Then
				Me.cmbBrowseFileName.Text = selectedItems(0).Text
			End If
		End Sub

		Private Sub listRecent_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim num As UInteger = 0UI
			Dim selectedItems As ListView.SelectedListViewItemCollection = Me.listRecent.SelectedItems
			If selectedItems.Count = 1 Then
				Dim text As String = selectedItems(0).Text
				Dim num2 As Integer = text.LastIndexOf("\"c)
				Dim num3 As Integer = text.LastIndexOf("/"c)
				Dim num4 As Integer
				If num3 > num2 Then
					num4 = num3
				Else
					num4 = num2
				End If
				Dim ptr As __Pointer(Of GPath) = <Module>.new(24UI)
				Dim gBaseString<char> As GBaseString<char>
				Dim currentLocation As __Pointer(Of GPath)
				Try
					If ptr IsNot Nothing Then
						Dim ptr2 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, text.Substring(0, num4 + 1))
						Try
							num = 1UI
							Dim num5 As UInteger = CUInt((__Dereference(ptr2)))
							Dim ptr3 As __Pointer(Of SByte)
							If num5 <> 0UI Then
								ptr3 = num5
							Else
								ptr3 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
							End If
							currentLocation = <Module>.GPath.{ctor}(ptr, ptr3)
							GoTo IL_AB
						Catch 
							If(num And 1UI) <> 0UI Then
								num = num And 4294967294UI
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
							End If
							Throw
						End Try
					End If
					currentLocation = 0
					IL_AB:
				Catch 
					<Module>.delete(CType(ptr, __Pointer(Of Void)))
					Throw
				End Try
				Try
					Me.CurrentLocation = currentLocation
				Catch 
					If(num And 1UI) <> 0UI Then
						num = num And 4294967294UI
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
					End If
					Throw
				End Try
				If(num And 1UI) <> 0UI Then
					num = num And 4294967294UI
					If gBaseString<char> IsNot Nothing Then
						<Module>.free(gBaseString<char>)
					End If
				End If
				Me.cmbRecentFileName.Text = text.Substring(num4 + 1)
			Else
				Me.cmbRecentLocation.Text = ""
				Me.cmbRecentFileName.Text = ""
			End If
		End Sub

		Private Sub btnOK_Click(sender As Object, e As EventArgs)
			Dim num As UInteger = 0UI
			Dim num2 As Integer = Me.propSelectedMode
			If num2 = 1 Then
				MyBase.DialogResult = DialogResult.OK
				MyBase.Close()
			Else If num2 <> 2 AndAlso num2 <> 4 Then
				If num2 = 8 Then
					Dim gBaseString<char> As GBaseString<char>
					Dim ptr As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>, Me.cmbRecentFileName.Text)
					Dim gPath2 As GPath
					Try
						Dim num3 As UInteger = CUInt((__Dereference(ptr)))
						Dim ptr2 As __Pointer(Of SByte)
						If num3 <> 0UI Then
							ptr2 = num3
						Else
							ptr2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
						End If
						Dim gPath As GPath
						Dim ptr3 As __Pointer(Of GPath) = <Module>.GPath.{ctor}(gPath, ptr2)
						Try
							<Module>.GPath.+(Me.CurrentLocation, AddressOf gPath2, ptr3)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath), __Pointer(Of Void)))
							Throw
						End Try
						Try
							<Module>.GPath.{dtor}(gPath)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath2), __Pointer(Of Void)))
							Throw
						End Try
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>), __Pointer(Of Void)))
						Throw
					End Try
					Try
						If gBaseString<char> IsNot Nothing Then
							<Module>.free(gBaseString<char>)
						End If
						<Module>.GPath.MakeFull(gPath2)
						Dim gBaseString<char>2 As GBaseString<char>
						<Module>.GPath..?AV?$GBaseString@D@@(gPath2, CType((AddressOf gBaseString<char>2), __Pointer(Of GBaseString<char>)))
						Dim num5 As UInteger
						Try
							Dim gBaseString<char>3 As GBaseString<char>
							Dim ptr4 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>3, gBaseString<char>2)
							Try
								Dim num4 As UInteger = CUInt((__Dereference(ptr4)))
								num5 = <Module>.GetFileAttributesA(If((num4 = 0UI), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, num4))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>3), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>3 IsNot Nothing Then
								<Module>.free(gBaseString<char>3)
								gBaseString<char>3 = 0
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>2), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>2 IsNot Nothing Then
							<Module>.free(gBaseString<char>2)
						End If
						If(If((<Module>.GBaseString<char>.Compare(gPath2, CType((AddressOf <Module>.??_C@_03MKLNKIKF@?1?10?$AA@), __Pointer(Of SByte)), False) = 0), 1, 0)) <> 0 Then
							num5 = 16UI
						Else If num5 = 4294967295UI Then
							Dim gBaseString<char>4 As GBaseString<char>
							<Module>.GPath..?AV?$GBaseString@D@@(gPath2, CType((AddressOf gBaseString<char>4), __Pointer(Of GBaseString<char>)))
							Dim text As String
							Try
								Dim gBaseString<char>5 As GBaseString<char>
								Dim ptr5 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>5, gBaseString<char>4)
								Try
									Dim num6 As UInteger = CUInt((__Dereference(ptr5)))
									Dim value As __Pointer(Of SByte)
									If num6 <> 0UI Then
										value = num6
									Else
										value = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
									End If
									text = String.Format("'{0}'" & vbLf & "File not found.", New String(CType(value, __Pointer(Of SByte))))
								Catch 
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>5), __Pointer(Of Void)))
									Throw
								End Try
								If gBaseString<char>5 IsNot Nothing Then
									<Module>.free(gBaseString<char>5)
									gBaseString<char>5 = 0
								End If
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>4), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>4 IsNot Nothing Then
								<Module>.free(gBaseString<char>4)
								gBaseString<char>4 = 0
							End If
							MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
							GoTo IL_22B
						End If
						If(num5 And 16UI) = 0UI Then
							Me.Location = Me.CurrentLocation
							Me.propFileName = Me.cmbRecentFileName.Text
							MyBase.DialogResult = DialogResult.OK
							MyBase.Close()
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath2), __Pointer(Of Void)))
						Throw
					End Try
					IL_22B:
					<Module>.GPath.{dtor}(gPath2)
				End If
			Else
				Dim gBaseString<char>6 As GBaseString<char>
				Dim ptr6 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>6, Me.cmbBrowseFileName.Text)
				Dim gPath4 As GPath
				Try
					Dim num7 As UInteger = CUInt((__Dereference(ptr6)))
					Dim ptr7 As __Pointer(Of SByte)
					If num7 <> 0UI Then
						ptr7 = num7
					Else
						ptr7 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
					End If
					Dim gPath3 As GPath
					Dim ptr8 As __Pointer(Of GPath) = <Module>.GPath.{ctor}(gPath3, ptr7)
					Try
						<Module>.GPath.+(Me.CurrentLocation, AddressOf gPath4, ptr8)
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath3), __Pointer(Of Void)))
						Throw
					End Try
					Try
						Try
							<Module>.GArray<GBaseString<char> >.{dtor}(gPath3 + 12)
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath3), __Pointer(Of Void)))
							Throw
						End Try
						If gPath3 IsNot Nothing Then
							<Module>.free(gPath3)
							gPath3 = 0
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath4), __Pointer(Of Void)))
						Throw
					End Try
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>6), __Pointer(Of Void)))
					Throw
				End Try
				Try
					If gBaseString<char>6 IsNot Nothing Then
						<Module>.free(gBaseString<char>6)
					End If
					<Module>.GPath.MakeFull(gPath4)
					Dim gBaseString<char>7 As GBaseString<char>
					<Module>.GPath..?AV?$GBaseString@D@@(gPath4, CType((AddressOf gBaseString<char>7), __Pointer(Of GBaseString<char>)))
					Dim num9 As UInteger
					Try
						Dim gBaseString<char>8 As GBaseString<char>
						If __Dereference((gBaseString<char>7 + 4)) <> 0 Then
							__Dereference((gBaseString<char>8 + 4)) = __Dereference((gBaseString<char>7 + 4))
							Dim num8 As UInteger = CUInt((__Dereference((gBaseString<char>7 + 4)) + 1))
							gBaseString<char>8 = <Module>.malloc(num8)
							cpblk(gBaseString<char>8, gBaseString<char>7, num8)
						Else
							__Dereference((gBaseString<char>8 + 4)) = 0
							gBaseString<char>8 = 0
						End If
						Try
							num9 = <Module>.GetFileAttributesA(If((gBaseString<char>8 Is Nothing), <Module>.?EmptyString@?$GBaseString@D@@1PBDB, gBaseString<char>8))
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>8), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>8 IsNot Nothing Then
							<Module>.free(gBaseString<char>8)
						End If
					Catch 
						<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>7), __Pointer(Of Void)))
						Throw
					End Try
					If gBaseString<char>7 IsNot Nothing Then
						<Module>.free(gBaseString<char>7)
					End If
					If(If((<Module>.GBaseString<char>.Compare(gPath4, CType((AddressOf <Module>.??_C@_03MKLNKIKF@?1?10?$AA@), __Pointer(Of SByte)), False) = 0), 1, 0)) <> 0 Then
						num9 = 16UI
					Else If num9 = 4294967295UI Then
						If Me.propSelectedMode <> 2 AndAlso <Module>.GetLastError() = 2 Then
							Me.Location = Me.CurrentLocation
							Me.propFileName = Me.cmbBrowseFileName.Text
							Dim gBaseString<char>9 As GBaseString<char>
							Dim gBaseString<char>10 As GBaseString<char>
							Dim num10 As Integer
							If Me.propDefaultExtension.Length > 0 Then
								Dim ptr9 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.{ctor}(gBaseString<char>9, Me.propFileName)
								Try
									num = 1UI
									Dim ptr10 As __Pointer(Of GBaseString<char>) = <Module>.GBaseString<char>.GetExtension(ptr9, AddressOf gBaseString<char>10)
									Try
										num = 3UI
										If(If((__Dereference(CType((ptr10 + 4 / __SizeOf(GBaseString<char>)), __Pointer(Of Integer))) = 0), 1, 0)) <> 0 Then
											If Me.propFileName(Me.propFileName.Length - 1) <> "."c Then
												num10 = 1
												GoTo IL_4A5
											End If
										End If
									Catch 
										If(num And 2UI) <> 0UI Then
											num = num And 4294967293UI
											<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>10), __Pointer(Of Void)))
										End If
										Throw
									End Try
								Catch 
									If(num And 1UI) <> 0UI Then
										num = num And 4294967294UI
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>9), __Pointer(Of Void)))
									End If
									Throw
								End Try
							End If
							Try
								Try
									num10 = 0
								Catch 
									If(num And 2UI) <> 0UI Then
										num = num And 4294967293UI
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>10), __Pointer(Of Void)))
									End If
									Throw
								End Try
							Catch 
								If(num And 1UI) <> 0UI Then
									num = num And 4294967294UI
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>9), __Pointer(Of Void)))
								End If
								Throw
							End Try
							IL_4A5:
							Dim flag As Boolean
							Try
								Try
									flag = (CByte(num10) <> 0)
								Catch 
									If(num And 2UI) <> 0UI Then
										num = num And 4294967293UI
										<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>10), __Pointer(Of Void)))
									End If
									Throw
								End Try
								If(num And 2UI) <> 0UI Then
									num = num And 4294967293UI
									If gBaseString<char>10 IsNot Nothing Then
										<Module>.free(gBaseString<char>10)
										gBaseString<char>10 = 0
									End If
								End If
							Catch 
								If(num And 1UI) <> 0UI Then
									num = num And 4294967294UI
									<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>9), __Pointer(Of Void)))
								End If
								Throw
							End Try
							If(num And 1UI) <> 0UI Then
								num = num And 4294967294UI
								If gBaseString<char>9 IsNot Nothing Then
									<Module>.free(gBaseString<char>9)
								End If
							End If
							If flag Then
								Me.propFileName = Me.propFileName + "." + Me.propDefaultExtension
							End If
							MyBase.DialogResult = DialogResult.OK
							MyBase.Close()
							GoTo IL_653
						End If
						Dim gBaseString<char>11 As GBaseString<char>
						<Module>.GPath..?AV?$GBaseString@D@@(gPath4, CType((AddressOf gBaseString<char>11), __Pointer(Of GBaseString<char>)))
						Dim text2 As String
						Try
							Dim gBaseString<char>12 As GBaseString<char>
							If __Dereference((gBaseString<char>11 + 4)) <> 0 Then
								__Dereference((gBaseString<char>12 + 4)) = __Dereference((gBaseString<char>11 + 4))
								Dim num11 As UInteger = CUInt((__Dereference((gBaseString<char>11 + 4)) + 1))
								gBaseString<char>12 = <Module>.malloc(num11)
								cpblk(gBaseString<char>12, gBaseString<char>11, num11)
							Else
								__Dereference((gBaseString<char>12 + 4)) = 0
								gBaseString<char>12 = 0
							End If
							Try
								Dim value2 As __Pointer(Of SByte)
								If gBaseString<char>12 IsNot Nothing Then
									value2 = gBaseString<char>12
								Else
									value2 = <Module>.?EmptyString@?$GBaseString@D@@1PBDB
								End If
								text2 = String.Format("'{0}'" & vbLf & "File not found.", New String(CType(value2, __Pointer(Of SByte))))
							Catch 
								<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>12), __Pointer(Of Void)))
								Throw
							End Try
							If gBaseString<char>12 IsNot Nothing Then
								<Module>.free(gBaseString<char>12)
							End If
						Catch 
							<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gBaseString<char>11), __Pointer(Of Void)))
							Throw
						End Try
						If gBaseString<char>11 IsNot Nothing Then
							<Module>.free(gBaseString<char>11)
							gBaseString<char>11 = 0
						End If
						MessageBox.Show(text2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
						GoTo IL_653
					End If
					If(num9 And 16UI) <> 0UI Then
						Me.CurrentLocation = AddressOf gPath4
						Me.cmbBrowseFileName.Text = ""
						Me.Update_listBrowse()
					Else
						Me.Location = Me.CurrentLocation
						Me.propFileName = Me.cmbBrowseFileName.Text
						MyBase.DialogResult = DialogResult.OK
						MyBase.Close()
					End If
					IL_653:
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GPath.{dtor}), CType((AddressOf gPath4), __Pointer(Of Void)))
					Throw
				End Try
				Try
					<Module>.GArray<GBaseString<char> >.{dtor}(gPath4 + 12)
				Catch 
					<Module>.___CxxCallUnwindDtor(ldftn(AddressOf GBaseString<char>.{dtor}), CType((AddressOf gPath4), __Pointer(Of Void)))
					Throw
				End Try
				If gPath4 IsNot Nothing Then
					<Module>.free(gPath4)
				End If
			End If
		End Sub

		Private Sub listBrowse_ItemActivate(sender As Object, e As EventArgs)
			Me.listBrowse_SelectedIndexChanged(sender, e)
			Me.btnOK_Click(sender, e)
		End Sub

		Private Sub listRecent_ItemActivate(sender As Object, e As EventArgs)
			Me.listRecent_SelectedIndexChanged(sender, e)
			Me.btnOK_Click(sender, e)
		End Sub

		Private Sub radBrowseDetails_CheckedChanged(sender As Object, e As EventArgs)
			Me.listBrowse.View = View.Details
			Me.listBrowse.PerformLayout()
			Dim num As Integer = Me.propSelectedMode
			If num = 2 OrElse num = 4 Then
				Me.radRecentDetails.Checked = True
				Me.radRecentThumbnails.Checked = False
				Me.listRecent.View = View.Details
				Me.listRecent.PerformLayout()
			End If
		End Sub

		Private Sub radBrowseThumbnails_CheckedChanged(sender As Object, e As EventArgs)
			Me.listBrowse.View = View.LargeIcon
			Me.listBrowse.PerformLayout()
			Dim num As Integer = Me.propSelectedMode
			If num = 2 OrElse num = 4 Then
				Me.radRecentDetails.Checked = False
				Me.radRecentThumbnails.Checked = True
				Me.listRecent.View = View.LargeIcon
				Me.listRecent.PerformLayout()
			End If
		End Sub

		Private Sub cmbBrowseFileName_TextChanged(sender As Object, e As EventArgs)
			Dim enabled As Byte = If((Me.cmbBrowseFileName.Text.Length > 0), 1, 0)
			Me.btnOK.Enabled = (enabled <> 0)
		End Sub

		Private Sub cmbBrowseFileName_KeyPress(sender As Object, e As KeyPressEventArgs)
			Me.listBrowse.SelectedItems.Clear()
		End Sub

		Private Sub cmbRecentFileName_TextChanged(sender As Object, e As EventArgs)
			Dim enabled As Byte = If((Me.cmbRecentFileName.Text.Length > 0), 1, 0)
			Me.btnOK.Enabled = (enabled <> 0)
		End Sub

		Private Sub radRecentDetails_CheckedChanged(sender As Object, e As EventArgs)
			Me.listRecent.View = View.Details
			Me.listRecent.PerformLayout()
			If Me.propSelectedMode = 8 Then
				Me.radBrowseDetails.Checked = True
				Me.radBrowseThumbnails.Checked = False
				Me.listBrowse.View = View.Details
				Me.listBrowse.PerformLayout()
			End If
		End Sub

		Private Sub radRecentThumbnails_CheckedChanged(sender As Object, e As EventArgs)
			Me.listRecent.View = View.LargeIcon
			Me.listRecent.PerformLayout()
			If Me.propSelectedMode = 8 Then
				Me.radBrowseDetails.Checked = False
				Me.radBrowseThumbnails.Checked = True
				Me.listBrowse.View = View.LargeIcon
				Me.listBrowse.PerformLayout()
			End If
		End Sub

		Private Sub trkWidth_Scroll(sender As Object, e As EventArgs)
			Dim num As Integer = Me.trkWidth.Value * 16
			Me.MapWidth = num
			If Me.SquareMap Then
				Me.MapHeight = num
				Me.trkHeight.Value = Me.trkWidth.Value
			End If
			Me.tbSize.Text = (CSng((CSng(Me.MapWidth) * __Dereference((<Module>.Measures + 4))))).ToString() + "x" + (CSng((CSng(Me.MapHeight) * __Dereference((<Module>.Measures + 4))))).ToString()
			Me.tbInnerSize.Text = (CSng((CSng((Me.MapWidth - 32)) * __Dereference((<Module>.Measures + 4))))).ToString() + "x" + (CSng((CSng((Me.MapHeight - 32)) * __Dereference((<Module>.Measures + 4))))).ToString()
		End Sub

		Private Sub trkHeight_Scroll(sender As Object, e As EventArgs)
			Dim num As Integer = Me.trkHeight.Value * 16
			Me.MapHeight = num
			If Me.SquareMap Then
				Me.MapWidth = num
				Me.trkWidth.Value = Me.trkHeight.Value
			End If
			Me.tbSize.Text = (CSng((CSng(Me.MapWidth) * __Dereference((<Module>.Measures + 4))))).ToString() + "x" + (CSng((CSng(Me.MapHeight) * __Dereference((<Module>.Measures + 4))))).ToString()
			Me.tbInnerSize.Text = (CSng((CSng((Me.MapWidth - 32)) * __Dereference((<Module>.Measures + 4))))).ToString() + "x" + (CSng((CSng((Me.MapHeight - 32)) * __Dereference((<Module>.Measures + 4))))).ToString()
		End Sub

		Private Sub chkSquare_CheckedChanged(sender As Object, e As EventArgs)
			Dim b As Byte = If((Not Me.SquareMap), 1, 0)
			Me.SquareMap = (b <> 0)
			If b <> 0 Then
				Me.MapHeight = Me.MapWidth
				Me.trkHeight.Value = Me.trkWidth.Value
			End If
			Me.tbSize.Text = (CSng((CSng(Me.MapWidth) * __Dereference((<Module>.Measures + 4))))).ToString() + "x" + (CSng((CSng(Me.MapHeight) * __Dereference((<Module>.Measures + 4))))).ToString()
			Me.tbInnerSize.Text = (CSng((CSng((Me.MapWidth - 32)) * __Dereference((<Module>.Measures + 4))))).ToString() + "x" + (CSng((CSng((Me.MapHeight - 32)) * __Dereference((<Module>.Measures + 4))))).ToString()
		End Sub

		Private Sub listBrowse_MouseUp(sender As Object, e As MouseEventArgs)
			If e.Button = MouseButtons.Right Then
				Me.ShellMenuPos.X = e.X
				Me.ShellMenuPos.Y = e.Y
				Me.HandleShellMenu()
			End If
		End Sub
	End Class
End Namespace
