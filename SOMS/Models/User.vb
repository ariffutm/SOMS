Imports System.ComponentModel
Imports System.Data.OleDb

Namespace Models

    Public Class User

        Private userId As String
        Private Username As String
        Private Password As String
        Private Status As String


        Public Property Id As String
            Get
                Return userId
            End Get
            Set(ByVal value As String)
                userId = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return Username
            End Get
            Set(ByVal value As String)
                Username = value
            End Set
        End Property

        Public Property Code As String
            Get
                Return Password
            End Get
            Set(ByVal value As String)
                Password = value
            End Set
        End Property

        Public Property Type As String
            Get
                Return Status
            End Get
            Set(ByVal value As String)
                Status = value
            End Set
        End Property


    End Class

End Namespace