Imports System.Collections.ObjectModel
Imports SOMS.Models

Namespace ViewModels
    Public Class userPageViewModel
        Function getAllUserListFromModel() As ObservableCollection(Of User)
            Dim userList = New ObservableCollection(Of User) From {
                New User() With {
                .userId = "1",
                .Username = "admin",
                .Password = "admin",
                .Status = "admin"
                },
                        New User() With {
                .userId = "2",
                .Username = "user",
                .Password = "user",
                .Status = "user"
                 }
            }
            Return userList
        End Function
    End Class
End Namespace
