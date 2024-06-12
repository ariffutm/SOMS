Imports SOMS.Models
Imports SOMS.ViewModels
Imports System.Collections.ObjectModel
Imports System.Data.OleDb

Public Class salesPageViewModel
    'Instance Attributes
    Private Shared _instance As salesPageViewModel
    'Order Attributes
    Public Property salesList As New ObservableCollection(Of Sales)
    Public Property sum As New Double

    Dim con As New OleDbConnection(Database.dbProvider)
    Dim data As OleDbDataReader
    ''Singleton - To pass data between form 
    Public Shared Function GetInstance() As salesPageViewModel
        If _instance Is Nothing Then
            _instance = New salesPageViewModel()
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
        getSalesRecord(com)
        con.Close()
        calculateSalesSum()
    End Sub
    ''By date
    '''Under
    Public Sub getSalesByUnderDateFromModel(dateTo As String)
        salesList.Clear()
        Dim sql As String = "Select * From [Sales] WHERE dateIssued <= ?"
        Dim com As New OleDbCommand(sql, con)
        con.Open()
        com.Parameters.AddWithValue("@dateIssued", dateTo)
        'Exceute reader, then load into table
        getSalesRecord(com)
        con.Close()
    End Sub
    ''' Above
    Public Sub getSalesByAboveDateFromModel(dateFrom As String)
        salesList.Clear()
        Dim sql As String = "Select * From [Sales] WHERE dateIssued >= ?"
        Dim com As New OleDbCommand(sql, con)
        con.Open()
        com.Parameters.AddWithValue("@dateIssued", dateFrom)
        'Exceute reader, then load into table
        getSalesRecord(com)
        con.Close()
        calculateSalesSum()
    End Sub
    '''Between Date
    Public Sub getSalesBetweenDateFromModel(dateFrom As String, dateTo As String)
        salesList.Clear()
        Dim sql As String = "Select * From [Sales] WHERE dateIssued BETWEEN ? AND ?"
        Dim com As New OleDbCommand(sql, con)
        con.Open()
        com.Parameters.AddWithValue("@dateIssued", dateFrom)
        com.Parameters.AddWithValue("@dateIssued", dateTo)
        'Exceute reader function, then load into table
        getSalesRecord(com)
        con.Close()
        calculateSalesSum()
    End Sub

    'Sub-function 
    ''Calculate Sum
    Public Sub calculateSalesSum()
        sum = 0
        For Each sales In salesList
            sum += Double.Parse(sales.Amount)
        Next
    End Sub
    ''Date Filter
    Public Sub filterDate(dateFrom As String, dateTo As String)
        'Under date's To textbox
        If String.IsNullOrWhiteSpace(dateFrom) AndAlso String.IsNullOrWhiteSpace(dateTo) = False Then
            Select Case MsgBox("Get a sales list until " + dateTo, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    getSalesByUnderDateFromModel(dateTo)
            End Select
            'Above date's From textbox
        ElseIf String.IsNullOrWhiteSpace(dateTo) AndAlso String.IsNullOrWhiteSpace(dateFrom) = False Then
            Select Case MsgBox("Get a sales list after " + dateFrom, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    getSalesByAboveDateFromModel(dateFrom)
            End Select
        ElseIf String.IsNullOrWhiteSpace(dateTo) = False AndAlso String.IsNullOrWhiteSpace(dateFrom) = False Then
            Select Case MsgBox("Get a sales list between " + dateFrom + " and " + dateTo, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    getSalesBetweenDateFromModel(dateFrom, dateTo)
            End Select
        Else
            getAllSalesFromModel()
        End If
    End Sub
    ''get Sales Record from Database
    Public Sub getSalesRecord(com As OleDbCommand)
        data = com.ExecuteReader()
        While data.Read()
            Dim Model As New Sales With {
              .Id = data("Id"),
             .orderId = data("orderId"),
             .orderItemId = data("orderItemId"),
             .itemName = data("itemName"),
             .Quantity = data("Quantity"),
             .dateIssued = data("dateIssued"),
             .Amount = data("Amount")
            }
            salesList.Add(Model)
        End While
    End Sub
End Class
