Imports System.Data.OleDb
Imports SOMS.Models

Namespace ViewModels

    Public Class loginPageViewModel
        Public Model As New User
        'UC012
        Function getUserByDetailFromModel(username As String, password As String) As String
            'Flag for always failed login until right credentials
            Dim returnUserLoginStatus As String = "Failed"
            Dim dr As OleDbDataReader
            Dim sql As String = "SELECT * from [User] WHERE Username = ? AND Password = ?"
            Dim con As New OleDbConnection(Database.dbProvider)

            con.Open()
            'Parameterized Query
            Dim com As New OleDbCommand(sql, con)
            com.Parameters.AddWithValue("@username", username)
            com.Parameters.AddWithValue("@password", password)
            'Execute Read Query
            dr = com.ExecuteReader()
            While dr.Read
                MessageBox.Show("Login Successfully!")
                'UserId login saved
                Database.userId = dr(0).ToString()

                Model.Id = dr(0).ToString()
                Model.Username = dr(1).ToString()
                Model.Password = dr(2).ToString()
                Model.Status = dr(3).ToString()
                returnUserLoginStatus = Model.Status
            End While
            'Return Flag Value
            con.Close()
            Return returnUserLoginStatus
        End Function
    End Class

End Namespace
