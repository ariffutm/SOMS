Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Data.OleDb
Imports SOMS.Models

Namespace ViewModels
    Public Class userPageViewModel
        Public Property userList As New ObservableCollection(Of User)

        'UC013 Read
        Public Sub getAllUserListFromModel()
            'Dim userList = New ObservableCollection(Of User) From {
            '    New User() With {
            '    .Id = "1",
            '    .Username = "admin",
            '    .Password = "admin",
            '    .Status = "admin"
            '    },
            '    New User() With {
            '    .Id = "2",
            '    .Username = "user",
            '    .Password = "user",
            '    .Status = "user"
            '     }
            '}
            'Return userList

            Dim data As OleDbDataReader
            Dim con As New OleDbConnection(Database.dbProvider)

            Dim sql As String = "Select * From [User]"
            Dim com As New OleDbCommand(sql, con)
            con.Open()

            'Exceute reader, then load into table
            data = com.ExecuteReader()
            While data.Read()
                Dim userModel As New User With {
                  .Id = data.GetInt32(data.GetOrdinal("Id")),
                  .Username = data.GetString(data.GetOrdinal("Username")),
                  .Password = data.GetString(data.GetOrdinal("Password")),
                  .Status = data.GetString(data.GetOrdinal("Status"))
                }
                userList.Add(userModel)
            End While
            con.Close()
        End Sub
    End Class
End Namespace
