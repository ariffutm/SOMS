Namespace Models
    Public Class Item

        Private _id As String
        Private _name As String
        Private _price As String
        Private _description As String
        Private _stock As String


        Public Property ID As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(ByVal value As String)
                _name = value
            End Set
        End Property

        Public Property Price As String
            Get
                Return _price
            End Get
            Set(ByVal value As String)
                _price = value
            End Set
        End Property

        Public Property Description As String
            Get
                Return _description
            End Get
            Set(ByVal value As String)
                _description = value
            End Set
        End Property

        Public Property Stock As String
            Get
                Return _stock
            End Get
            Set(ByVal value As String)
                _stock = value
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