Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data.OleDb

Namespace Models

    Public Class User

        Private userId As String
        Private name As String
        Private pass As String
        Private role As String


        Public Property Id As String
            Get
                Return userId
            End Get
            Set(ByVal value As String)
                userId = value
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

        'Private _userList As ObservableCollection(Of User)

        'Public Property UserList As ObservableCollection(Of User)
        '    Get
        '        Return _userList
        '    End Get
        '    Set(ByVal value As ObservableCollection(Of User))
        '        _userList = value
        '    End Set
        'End Property

    End Class

End Namespace