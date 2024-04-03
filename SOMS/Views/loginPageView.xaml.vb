Imports System.Runtime.CompilerServices
Imports SOMS.ViewModels

Public Class loginPageView
    Private Sub LoginButton_Click(sender As Object, e As RoutedEventArgs)
        Dim login = New loginPageViewModel
        Dim loginStatus As String

        loginStatus = login.getUserByDetailFromModel(textBoxEmail.Text, passwordBox1.Password)
        If loginStatus = "Admin" Then
            Dim dashboardAdmin As MainWindow = New MainWindow()
            Me.Close()
            dashboardAdmin.Show()
        ElseIf loginStatus = "User" Then
            Dim dashboardUser As MainWindow = New MainWindow()
            Me.Close()
            dashboardUser.Show()
        Else loginStatus = "Failed"
            errormessage.Text = "Failed login"
        End If
    End Sub

End Class
