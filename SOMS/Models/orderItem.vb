Namespace Models
    Public Class orderItem

        Private _id As String
        Private _orderId As String
        Private _itemId As String
        Private _itemName As String
        Private _quantity As String
        Private _price As String
        Private _total As String

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

        Public Property ItemID As String
            Get
                Return _itemId
            End Get
            Set(ByVal value As String)
                _itemId = value
            End Set
        End Property

        Public Property ItemName As String
            Get
                Return _itemName
            End Get
            Set(ByVal value As String)
                _itemName = value
            End Set
        End Property

        Public Property Quantity As String
            Get
                Return _quantity
            End Get
            Set(ByVal value As String)
                _quantity = value
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

        Public Property Total As String
            Get
                Return _total
            End Get
            Set(ByVal value As String)
                _total = value
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