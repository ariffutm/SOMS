Namespace Models
    Public Class Sales

        Private _id As String
        Private _orderId As String
        Private _total As String
        Private _orderItemId As String
        Private _itemName As String
        Private _quantity As String
        Private _dateIssued As String

        Public Property Id As String
            Get
                Return _id
            End Get
            Set(ByVal value As String)
                _id = value
            End Set
        End Property

        Public Property orderId As String
            Get
                Return _orderId
            End Get
            Set(ByVal value As String)
                _orderId = value
            End Set
        End Property

        Public Property Amount As String
            Get
                Return _total
            End Get
            Set(ByVal value As String)
                _total = value
            End Set
        End Property

        Public Property orderItemId As String
            Get
                Return _orderItemId
            End Get
            Set(ByVal value As String)
                _orderItemId = value
            End Set
        End Property

        Public Property itemName As String
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

        Public Property dateIssued As String
            Get
                Return _dateIssued
            End Get
            Set(ByVal value As String)
                _dateIssued = value
            End Set
        End Property
    End Class

End Namespace