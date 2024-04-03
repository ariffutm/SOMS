Imports System.Data
Imports System.Text.RegularExpressions
Imports SOMS.Models

Namespace ViewModels

    Public Class loginPageViewModel

        Function getUserByDetailFromModel(username As String, password As String) As String
            If username = "admin" And password = "admin" Then
                Return "Admin"
            ElseIf username = "user" And password = "user" Then
                Return "User"
            Else
                Return "Failed"
            End If
        End Function
    End Class

End Namespace
