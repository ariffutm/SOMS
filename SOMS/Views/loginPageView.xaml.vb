Imports SOMS.ViewModels
Public Class loginPageView
    'UC012
    Private Sub LoginButton_Click(sender As Object, e As RoutedEventArgs)
        Dim viewModel = New loginPageViewModel
        Dim returnloginStatus As String

        returnloginStatus = viewModel.getUserByDetailFromModel(textBoxEmail.Text, passwordBox1.Password)

        If LCase(returnloginStatus) = "admin" Then
            userTypeUIHandling(returnloginStatus)
        ElseIf Lcase(returnloginStatus) = "user" Then
            userTypeUIHandling(returnloginStatus)
        Else
            errormessage.Text = "Failed login. Please contact the administrator."
        End If
    End Sub

    'Sub-Function 
    ''Handle User Type UI Flow
    Private Sub userTypeUIHandling(userType As String)
        Dim dashboard As MainWindow = New MainWindow

        If LCase(userType) = "admin" Then
            dashboard.profilePage.Visibility = Visibility.Collapsed
            dashboard.orderPage.Visibility = Visibility.Collapsed
            dashboard.salesPage.Visibility = Visibility.Collapsed
        Else
            dashboard.userPage.Visibility = Visibility.Collapsed
        End If
        dashboard.Show()
        Me.close
    End Sub
End Class
