Imports System.Collections.ObjectModel
Imports SOMS.Models

Namespace ViewModels
    Public Class userPageViewModel
        Function getAllUserListFromModel() As ObservableCollection(Of User)
            Dim userList = New ObservableCollection(Of User) From {
                New User() With {
                .Id = "1",
                .Name = "admin",
                .Code = "admin",
                .Type = "admin"
                },
                        New User() With {
                .Id = "2",
                .Name = "user",
                .Code = "user",
                .Type = "user"
                 }
            }
            Return userList
        End Function
    End Class
End Namespace
