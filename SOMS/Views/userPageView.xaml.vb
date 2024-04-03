Imports System.Collections.ObjectModel
Imports SOMS.Models
Imports SOMS.ViewModels

Partial Public Class userPageView
    Public Property userList = New ObservableCollection(Of User)

    Public Sub New()
        InitializeComponent()

        userList = seeAllUserList()
        Me.DataContext = Me
    End Sub

    Private Function seeAllUserList() As ObservableCollection(Of User)
        Dim getUserList = New userPageViewModel

        userList = getUserList.getAllUserListFromModel
        Return userList
    End Function
End Class
