Public Class profilePageView
    Private Sub SendProfileUpdated_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As RoutedEventArgs)
        Dim Dashboard = New MainWindow()
        Me.Close()
        Dashboard.Show()
    End Sub
End Class
