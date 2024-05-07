Imports System.Collections.ObjectModel
Imports SOMS.Models
Imports SOMS.ViewModels

Partial Public Class userPageView

    Public Sub New()
        InitializeComponent()

        Me.DataContext = seeAllUserList()
    End Sub

    'UC013 Add
    Private Sub ButtonAdd_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAdd.Click
        Dim viewModel = New userPageViewModel

        viewModel.addUserToModel(TextBoxUsername.Text, TextBoxPassword.Text, TextBoxStatus.Text)
        Me.DataContext = seeAllUserList()
    End Sub

    'UC013 Read
    Private Function seeAllUserList() As userPageViewModel
        Dim viewModel = New userPageViewModel
        viewModel.getAllUserListFromModel()
        Return viewModel
    End Function
End Class
