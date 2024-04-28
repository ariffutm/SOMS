Imports System.Data
Imports System.Text.RegularExpressions
Imports SOMS.Models

Namespace ViewModels

    Public Class loginPageViewModel

        Function getUserByDetailFromModel(username As String, password As String) As String
<<<<<<< Updated upstream
            If username = "admin" And password = "admin" Then
                Return "Admin"
            ElseIf username = "user" And password = "user" Then
                Return "User"
=======
            Dim sdr As OleDbDataReader
            Dim SQL As String = "SELECT * from [User] WHERE Username = '" & username & "' AND Password = '" & password & "' "
            Dim returnUserLoginStatus As String
            Dim connection As New OleDbConnection(database.dbProvider)

            Dim oleCommand = New OleDbCommand(SQL, connection)
            connection.Open()
            sdr = oleCommand.ExecuteReader

            If (sdr.Read() = True) Then
                MessageBox.Show("Login Successfully!")
                'MessageBox.Show(sdr.GetString(0))

                Model.Id = sdr.GetString(0).ToString()
                Model.Name = sdr.GetString(1).ToString()
                Model.Code = sdr.GetString(2).ToString()
                Model.Type = sdr.GetString(3).ToString()
                returnUserLoginStatus = sdr.GetString(3).ToString()
>>>>>>> Stashed changes
            Else
                Return "Failed"
            End If
        End Function
    End Class

End Namespace
