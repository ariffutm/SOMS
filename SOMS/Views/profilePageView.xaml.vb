Imports SOMS.ViewModels

Public Class profilePageView
    'UC011
    Private Sub SendProfileUpdated_Click(sender As Object, e As RoutedEventArgs)
        Dim viewModel = New ProfilePageViewModel
        viewModel.UpdateUserByIDIntoModel(usernameBox.Text, currentPasswordBox.Text, newPasswordBox.Text)
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As RoutedEventArgs)
        Me.Close()
    End Sub
End Class
