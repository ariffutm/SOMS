Imports System.Collections.ObjectModel
Imports SOMS.Models

Namespace ViewModels
    Public Class userPageViewModel
        Function getAllUserListFromModel() As ObservableCollection(Of User)
            Dim userList = New ObservableCollection(Of User) From {
                New User() With {
                .Id = "Directory1",
                .Name = "Directory1",
                .Code = "Info1",
                .Type = "Directory1"
                },
                        New User() With {
                .Id = "Directory2",
                .Name = "Directory2",
                .Code = "Info2",
                .Type = "Directory2"
                 },
                        New User() With {
                .Id = "Directory2",
                .Name = "Info3",
                .Code = "Info3",
                .Type = "Info3"
                 }
            }
            Return userList
        End Function
    End Class
End Namespace
