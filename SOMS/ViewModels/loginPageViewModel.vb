Imports System.Data
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports SOMS.Models

Namespace ViewModels

    Public Class loginPageViewModel
        Public Model As User
        Public database As New Database

        Function getUserByDetailFromModel(username As String, password As String) As String
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

                'Model.Id = sdr.GetString(0).ToString()
                'Model.Name = sdr.GetString(1).ToString()
                'Model.Code = sdr.GetString(2).ToString()
                'Model.Type = sdr.GetString(3).ToString()
                returnUserLoginStatus = "admin"
            Else
                MessageBox.Show("Invalid username or password!")
                returnUserLoginStatus = "Failed"
            End If
            connection.Close()
            Return returnUserLoginStatus
        End Function
    End Class

End Namespace
