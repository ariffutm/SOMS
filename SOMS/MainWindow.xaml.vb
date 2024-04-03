Imports SOMS.ViewModels

Public Class MainWindow
    Private Sub UserPage_Click(sender As Object, e As RoutedEventArgs)
        Dim userPage As userPageView = New userPageView()
        Me.Close()
        userPage.Show()
    End Sub

    Private Sub ProfilePage_Click(sender As Object, e As RoutedEventArgs)
        Dim profilePage As profilePageView = New profilePageView()
        Me.Close()
        profilePage.Show()
    End Sub
End Class
