Imports System.ComponentModel
Imports System.Data.OleDb

Namespace Models

    Public Class User

        Private Id As String
        Private name As String
        Private pass As String
        Private role As String


        Public Property userId As String
            Get
                Return Id
            End Get
            Set(ByVal value As String)
                Id = value
            End Set
        End Property

        Public Property Username As String
            Get
                Return name
            End Get
            Set(ByVal value As String)
                name = value
            End Set
        End Property

        Public Property Password As String
            Get
                Return pass
            End Get
            Set(ByVal value As String)
                pass = value
            End Set
        End Property

        Public Property Status As String
            Get
                Return role
            End Get
            Set(ByVal value As String)
                role = value
            End Set
        End Property


    End Class

End Namespace