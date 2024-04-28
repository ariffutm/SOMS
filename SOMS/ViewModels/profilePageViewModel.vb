Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports SOMS.Models

Public Class ProfilePageViewModel
    Public Model As New User

    Function UpdateUserByIDIntoModel(Username As String, currentPass As String, newPass As String) As Boolean
        ''Dim sql As String = "UPDATE [User] SET Username = @name, Password = @pass WHERE [userId] = @id"
        Dim data As OleDbDataReader
        Dim con As New OleDbConnection(Database.dbProvider)

        con.Open()
        Dim sql As String = "SELECT * from [User] WHERE Id = @id"
        Dim com As New OleDbCommand(sql, con)
        com.Parameters.AddWithValue("@id", "1")

        'Exceute reader, then load into table for update validation
        data = com.ExecuteReader()
        ''Dim dt As New DataTable()
        ''dt.Load(data)
        'MessageBox.Show(dt.Rows(1)(1))

        con.Close()
        ''Check the text box filled, old password requirement.
        'If String.IsNullOrWhiteSpace(Username) AndAlso String.IsNullOrWhiteSpace(newPass) Then
        '    MessageBox.Show("Please fill out all text boxes.")
        '    Return False
        'ElseIf currentPass IsNot dt.Rows(1)(3) Then
        '    MessageBox.Show("Wrong current password.")
        '    Return False
        'ElseIf newPass Is dt.Rows(1)(3) Then
        '    MessageBox.Show("Please change to a different password than the current one.")
        '    Return False
        'Else
        '    sql = "SELECT * from [User] WHERE userId = @id"

        'End If
        Return False
    End Function

End Class
