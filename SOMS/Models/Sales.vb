Namespace Models
    Public Class Sales

        Private _id As String
        Private _orderId As String
        Private _total As String
        Private _dateIssued As String

        Public Property ID As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property OrderID As String
            Get
                Return _orderId
            End Get
            Set(ByVal value As String)
                _orderId = value
            End Set
        End Property

        Public Property Total As String
            Get
                Return _total
            End Get
            Set(ByVal value As String)
                _total = value
            End Set
        End Property

        Public Property OnDate As String
            Get
                Return _dateIssued
            End Get
            Set(ByVal value As String)
                _dateIssued = value
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