Namespace Models

    Public Class Order

        Private orderId As String
        Private dateIssued As String
        Private buyerPhone As String
        Private Payment As String
        Private courierNumber As String
        Private _status As String
        Private buyerName As String
        Private _email As String
        Private _address As String

        Public Property Id As String
            Get
                Return orderId
            End Get
            Set(ByVal value As String)
                orderId = value
            End Set
        End Property

        Public Property IssuedOn As String
            Get
                Return dateIssued
            End Get
            Set(ByVal value As String)
                dateIssued = value
            End Set
        End Property

        Public Property Phone As String
            Get
                Return buyerPhone
            End Get
            Set(ByVal value As String)
                buyerPhone = value
            End Set
        End Property

        Public Property Method As String
            Get
                Return Payment
            End Get
            Set(ByVal value As String)
                Payment = value
            End Set
        End Property

        Public Property Courier As String
            Get
                Return courierNumber
            End Get
            Set(ByVal value As String)
                courierNumber = value
            End Set
        End Property

        Public Property Status As String
            Get
                Return _status
            End Get
            Set(ByVal value As String)
                _status = value
            End Set
        End Property

        Public Property Customer As String
            Get
                Return buyerName
            End Get
            Set(ByVal value As String)
                buyerName = value
            End Set
        End Property

        Public Property Email As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                _email = value
            End Set
        End Property

        Public Property Address As String
            Get
                Return _address
            End Get
            Set(ByVal value As String)
                _address = value
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