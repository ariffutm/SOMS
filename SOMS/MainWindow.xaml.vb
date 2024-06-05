Imports SOMS.ViewModels

Public Class MainWindow
    Private Sub UserPage_Click(sender As Object, e As RoutedEventArgs)
        Dim userPage As userPageView = New userPageView()
        userPage.Show()
    End Sub

    Private Sub ProfilePage_Click(sender As Object, e As RoutedEventArgs)
        Dim profilePage As profilePageView = New profilePageView()
        profilePage.Show()
    End Sub

    Private Sub orderSubsystemPage_Click(sender As Object, e As RoutedEventArgs)
        Dim orderSubsystemPage As orderSubsystemPageView = New orderSubsystemPageView()
        orderSubsystemPage.Show()
    End Sub

    Private Sub SalesPage_Click(sender As Object, e As RoutedEventArgs) Handles SalesPage.Click
        Dim salesPage As salesPageView = New salesPageView()
        salesPage.Show()
    End Sub
End Class
