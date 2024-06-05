Imports System.Collections.ObjectModel

Namespace Models
    Public Class Item

        Private _id As String
        Private _name As String
        Private _price As String
        Private _description As String
        Private _stock As String
        'Sub-Attributes
        Public orderItemList As New ObservableCollection(Of orderItem)
        Private _balance As String


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

        Public Property Balance As String
            Get
                Return _balance
            End Get
            Set(ByVal value As String)
                _balance = value
            End Set
        End Property


        'Sub-Function
        Public Sub calculateBalance()
            Dim sum As New Integer
            'Calculation Processs
            For Each data As orderItem In orderItemList
                sum += Integer.Parse(data.Quantity)
            Next
            Dim remainStock As Int32 = Int32.Parse(Stock) - sum
            'Pass value.ToString to Atttribute
            Balance = remainStock.ToString
        End Sub
    End Class

End Namespace