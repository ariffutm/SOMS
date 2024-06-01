Imports SOMS.ViewModels
Public Class loginPageView
    Private Sub LoginButton_Click(sender As Object, e As RoutedEventArgs)
        Dim viewModel = New loginPageViewModel
        Dim returnloginStatus As String

        returnloginStatus = viewModel.getUserByDetailFromModel(textBoxEmail.Text, passwordBox1.Password)

        If returnloginStatus = "admin" Then
            Dim dashboardAdmin As MainWindow = New MainWindow
            Me.Close()
            dashboardAdmin.Show()
        ElseIf returnloginStatus = "user" Then
            Dim dashboardUser As MainWindow = New MainWindow()
            Me.Close()
            dashboardUser.Show()
        Else returnloginStatus = "Failed"
            errormessage.Text = "Failed login"
        End If
    End Sub
End Class
