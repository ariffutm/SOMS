Imports SOMS.ViewModels

Public Class MainWindow
    Private Sub userPage_Click(sender As Object, e As RoutedEventArgs) Handles userPage.Click
        Dim userPage As userPageView = New userPageView()
        userPage.Show()
    End Sub

    Private Sub profilePage_Click(sender As Object, e As RoutedEventArgs) Handles profilePage.Click
        Dim profilePage As profilePageView = New profilePageView()
        profilePage.Show()
    End Sub

    Private Sub orderPage_Click(sender As Object, e As RoutedEventArgs) Handles orderPage.Click
        Dim orderSubsystemPage As orderSubsystemPageView = New orderSubsystemPageView()
        orderSubsystemPage.Show()
    End Sub

    Private Sub salesPage_Click(sender As Object, e As RoutedEventArgs) Handles salesPage.Click
        Dim salesPage As salesPageView = New salesPageView()
        salesPage.Show()
    End Sub
End Class
