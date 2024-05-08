Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Data.OleDb
Imports SOMS.Models

Namespace ViewModels
    Public Class userPageViewModel
        Dim con As New OleDbConnection(Database.dbProvider)
        Dim data As OleDbDataReader

        Public Property userList As New ObservableCollection(Of User)

        'UC013 Read
        Public Sub getAllUserListFromModel()
            Dim sql As String = "Select * From [User]"
            Dim com As New OleDbCommand(sql, con)

            con.Open()
            'Exceute reader, then load into table
            data = com.ExecuteReader()
            While data.Read()
                Dim userModel As New User With {
                  .Id = data.GetValue("Id").ToString,
                  .Username = data.GetValue("Username").ToString,
                  .Password = data.GetValue("Password").ToString,
                  .Status = data.GetValue("Status").ToString
                }
                userList.Add(userModel)
            End While
            con.Close()
        End Sub

        'UC013 Add
        Public Sub addUserToModel(Username As String, Password As String, Status As String)
            Dim sql As String = "INSERT INTO [User] (Username, [Password], Status) VALUES (?,?,?)"
            Dim com = New OleDbCommand(sql, con)

            con.Open()
            If String.IsNullOrWhiteSpace(Username) Or String.IsNullOrWhiteSpace(Password) Or String.IsNullOrEmpty(Status) Then
                MessageBox.Show("Please fill out all text boxes.")
            Else
                com.Parameters.AddWithValue("@username", Username)
                com.Parameters.AddWithValue("@password", Password)
                com.Parameters.AddWithValue("@status", Status)
                com.ExecuteNonQuery()
                MessageBox.Show("New user added to the Database")
            End If
            con.Close()
        End Sub

        'UC013 Delete
        Public Sub deleteUserFromModel(deleteUser As User)
            Select Case MsgBox("Delete this user with the ID: " + deleteUser.Id, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    Dim sql As String = "DELETE FROM [User] WHERE Id = ?"
                    Dim com = New OleDbCommand(sql, con)
                    'Open Connection
                    con.Open()
                    com.Parameters.AddWithValue("@Id", deleteUser.Id)
                    com.ExecuteNonQuery()
                    MessageBox.Show("User successfully deleted from the Database")
                    con.Close()
            End Select
        End Sub

        'UC013 Update
        Public Sub updateUserFromModel(deleteUser As User)
            Dim sql As String = "UPDATE [User] SET Username=?, [Password]=? WHERE Id=?"
            Dim com = New OleDbCommand(sql, con)

            'con.Open()
            'If String.IsNullOrWhiteSpace(Username) Or String.IsNullOrWhiteSpace(Password) Or String.IsNullOrEmpty(Status) Then
            '    MessageBox.Show("Please fill out all text boxes.")
            'Else
            '    com.Parameters.AddWithValue("@username", Username)
            '    com.Parameters.AddWithValue("@password", Password)
            '    com.Parameters.AddWithValue("@status", Status)
            '    com.ExecuteNonQuery()
            '    MessageBox.Show("New user added to the Database")
            'End If
            'con.Close()
            'Select Case MsgBox("Update this user with the ID: " + deleteUser.Id, MsgBoxStyle.YesNo)
            '    Case MsgBoxResult.Yes
            '        Dim sql As String = "DELETE FROM [User] WHERE Id = ?"
            '        Dim com = New OleDbCommand(sql, con)
            '        'Open Connection
            '        con.Open()
            '        com.Parameters.AddWithValue("@Id", deleteUser.Id)
            '        com.ExecuteNonQuery()
            '        MessageBox.Show("User successfully deleted from the Database")
            '        con.Close()
            'End Select
        End Sub

    End Class

End Namespace
