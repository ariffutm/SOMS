Imports SOMS.ViewModels

Public Class profilePageView
    'UC011
    Private Sub SendProfileUpdated_Click(sender As Object, e As RoutedEventArgs)
        Dim viewModel = New ProfilePageViewModel
        Dim sendUpdateProfileStatus As Boolean

        sendUpdateProfileStatus = viewModel.UpdateUserByIDIntoModel(usernameBox.Text, currentPasswordBox.Password, newPasswordBox.Password)
    End Sub

    Private Sub cancelButton_Click(sender As Object, e As RoutedEventArgs)
        Dim Dashboard = New MainWindow()
        Me.Close()
        Dashboard.Show()
    End Sub
End Class
