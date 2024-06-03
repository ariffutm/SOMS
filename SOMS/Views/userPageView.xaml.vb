Imports SOMS.Models
Imports SOMS.ViewModels
Partial Public Class userPageView
    Dim viewModel As New userPageViewModel

    Public Sub New()
        InitializeComponent()
        Me.DataContext = seeAllUserList()
    End Sub

    'UC013 Add
    Private Sub ButtonAdd_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAdd.Click
        viewModel.addUserToModel(TextBoxUsername.Text, TextBoxPassword.Text, TextBoxStatus.Text)
        Me.DataContext = seeAllUserList()
    End Sub

    'UC013 Read
    Private Function seeAllUserList() As userPageViewModel
        Dim viewModel As New userPageViewModel
        viewModel.getAllUserListFromModel()
        Return viewModel
    End Function

    'UC013 Delete
    Private Sub RemoveUser(sender As Object, e As RoutedEventArgs)
        Dim user As User = DataGridUser.SelectedItem
        viewModel.deleteUserFromModel(user)
        Me.DataContext = seeAllUserList()
    End Sub

    'UC013 Select userId First, then Update
    Private Sub SelectUser(sender As Object, e As RoutedEventArgs)
        Dim user As User = DataGridUser.SelectedItem
        TextBlockId.Text = user.Id
    End Sub
    Private Sub ButtonUpdate_Click(sender As Object, e As RoutedEventArgs) Handles ButtonUpdate.Click
        If viewModel.updateUserToModel(TextBlockId.Text, TextBoxUsername.Text, TextBoxPassword.Text, TextBoxStatus.Text) = True Then
            TextBlockId.Text = ""
        End If
        Me.DataContext = seeAllUserList()
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub
End Class
