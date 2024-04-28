Imports System.Runtime.CompilerServices
Imports SOMS.ViewModels

Public Class loginPageView
    Private Sub LoginButton_Click(sender As Object, e As RoutedEventArgs)
        Dim viewModel = New loginPageViewModel
        Dim loginStatus As String

        loginStatus = viewModel.getUserByDetailFromModel(textBoxEmail.Text, passwordBox1.Password)

        If loginStatus = "admin" Then
            Dim dashboardAdmin As MainWindow = New MainWindow()
            Me.Close()
            dashboardAdmin.Show()
        ElseIf loginStatus = "user" Then
            Dim dashboardUser As MainWindow = New MainWindow()
            Me.Close()
            dashboardUser.Show()
        Else loginStatus = "Failed"
            errormessage.Text = "Failed login"
        End If
    End Sub

End Class
