Imports System.Data
Imports System.Data.OleDb
Imports SOMS.Models
Namespace ViewModels
    Public Class ProfilePageViewModel
        Dim con As New OleDbConnection(Database.dbProvider)
        Dim data As OleDbDataReader

        Public Sub UpdateUserByIDIntoModel(Username As String, oldPass As String, newPass As String)
            Dim sql As String = "Select * From [User] Where Id = ?"
            Dim com As New OleDbCommand(sql, con)
            con.Open()
            com.Parameters.AddWithValue("@userId", Database.userId)
            'Exceute reader, then load into table for update validation
            data = com.ExecuteReader()
            Dim dt As New DataTable()
            dt.Load(data)
            'Check the text box filled, old password requirement.
            If String.IsNullOrWhiteSpace(Username) Or String.IsNullOrWhiteSpace(oldPass) Or String.IsNullOrEmpty(newPass) Then
                MessageBox.Show("Please fill out all text boxes.")
            ElseIf oldPass <> dt.Rows(0)(2).ToString Then
                MessageBox.Show("Wrong old password.")
            ElseIf newPass = dt.Rows(0)(2) Then
                MessageBox.Show("Please change to a different password than the current one.")
            Else
                sql = "UPDATE [User] Set Username = ?, [Password] = ? WHERE Id = ?"
                com = New OleDbCommand(sql, con)
                com.Parameters.AddWithValue("@username", Username)
                com.Parameters.AddWithValue("@password", newPass)
                com.Parameters.AddWithValue("@userid", Integer.Parse(Database.userId))
                com.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Update successful.")
            End If
            con.Close()
        End Sub
    End Class
End Namespace
