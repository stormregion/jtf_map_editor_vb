Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace NWorkshop
	Public Class NDebuggerUnits
		Inherits UserControl

		Private MainFilter As ListBox

		Private SecondaryFilter As ListBox

		Private UnitList As ListView

		Private UnitID As ColumnHeader

		Private UnitType As ColumnHeader

		Private components As Container

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
			Me.MainFilter = New ListBox()
			Me.SecondaryFilter = New ListBox()
			Me.UnitList = New ListView()
			Me.UnitID = New ColumnHeader()
			Me.UnitType = New ColumnHeader()
			MyBase.SuspendLayout()
			Dim items As Object() = New Object() { "Infantry", "Vehicle", "Building", "Other" }
			Me.MainFilter.Items.AddRange(items)
			Dim location As Point = New Point(8, 272)
			Me.MainFilter.Location = location
			Me.MainFilter.Name = "MainFilter"
			Dim size As Size = New Size(120, 69)
			Me.MainFilter.Size = size
			Me.MainFilter.TabIndex = 1
			Dim items2 As Object() = New Object() { "Anarchist", "Team1", "Team2", "Team3", "Team4" }
			Me.SecondaryFilter.Items.AddRange(items2)
			Dim location2 As Point = New Point(128, 272)
			Me.SecondaryFilter.Location = location2
			Me.SecondaryFilter.Name = "SecondaryFilter"
			Dim size2 As Size = New Size(112, 69)
			Me.SecondaryFilter.Size = size2
			Me.SecondaryFilter.TabIndex = 2
			Dim values As ColumnHeader() = New ColumnHeader() { Me.UnitID, Me.UnitType }
			Me.UnitList.Columns.AddRange(values)
			Me.UnitList.GridLines = True
			Dim location3 As Point = New Point(8, 8)
			Me.UnitList.Location = location3
			Me.UnitList.Name = "UnitList"
			Dim size3 As Size = New Size(232, 256)
			Me.UnitList.Size = size3
			Me.UnitList.TabIndex = 3
			Me.UnitList.View = View.Details
			Me.UnitID.Text = "Unit ID"
			Me.UnitID.Width = 168
			Me.UnitType.Text = "Type"
			MyBase.Controls.Add(Me.UnitList)
			MyBase.Controls.Add(Me.SecondaryFilter)
			MyBase.Controls.Add(Me.MainFilter)
			MyBase.Name = "NDebuggerUnits"
			Dim size4 As Size = New Size(248, 344)
			MyBase.Size = size4
			MyBase.ResumeLayout(False)
		End Sub
	End Class
End Namespace
