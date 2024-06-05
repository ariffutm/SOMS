Imports SOMS.Models
Imports SOMS.ViewModels
Imports System.Collections.ObjectModel
Imports System.Data.OleDb

Public Class salesPageViewModel
    'Instance Attributes
    Private Shared _instance As itemPageViewModel
    'Order Attributes
    Public Property salesList As New ObservableCollection(Of Sales)

    Dim con As New OleDbConnection(Database.dbProvider)
    Dim data As OleDbDataReader
    ''Singleton - To pass data between form 
    Public Shared Function GetInstance() As itemPageViewModel
        If _instance Is Nothing Then
            _instance = New itemPageViewModel()
        End If
        Return _instance
    End Function

    'UC013 Read
    ''All 
    Public Sub getAllSalesFromModel()
        salesList.Clear()
        Dim sql As String = "Select * From [Sales]"
        Dim com As New OleDbCommand(sql, con)
        con.Open()
        'Exceute reader, then load into table
        data = com.ExecuteReader()
        While data.Read()
            Dim Model As New Sales With {
             .Id = data("Id"),
             .orderId = data("orderId"),
             .orderItemId = data("orderItemId"),
             .dateIssued = data("dateIssued"),
             .Amount = data("Amount")
            }
            salesList.Add(Model)
        End While
        con.Close()
    End Sub
    ''By date 
    Public Sub getSalesByDateFromModel()
        salesList.Clear()
        Dim sql As String = "Select * From [Sales]"
        Dim com As New OleDbCommand(sql, con)
        con.Open()
        'Exceute reader, then load into table
        data = com.ExecuteReader()
        While data.Read()
            Dim Model As New Sales With {
              .Id = data("Id"),
             .orderId = data("orderId"),
             .orderItemId = data("orderItemId"),
             .dateIssued = data("dateIssued"),
             .Amount = data("Amount")
            }
            salesList.Add(Model)
        End While
        con.Close()
    End Sub
    ''Between Date
    Public Sub getSalesBetweenDateFromModel()
        salesList.Clear()
        Dim sql As String = "Select * From [Sales]"
        Dim com As New OleDbCommand(sql, con)
        con.Open()
        'Exceute reader, then load into table
        data = com.ExecuteReader()
        While data.Read()
            Dim Model As New Sales With {
              .Id = data("Id"),
             .orderId = data("orderId"),
             .orderItemId = data("orderItemId"),
             .dateIssued = data("dateIssued"),
             .Amount = data("Amount")
            }
            salesList.Add(Model)
        End While
        con.Close()
    End Sub

End Class
