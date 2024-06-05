﻿Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Data.OleDb
Imports System.Diagnostics.Metrics
Imports System.Net
Imports SOMS.Models

Namespace ViewModels
    Public Class orderPageViewModel
        Private Shared _instance As orderPageViewModel

        Dim con As New OleDbConnection(Database.dbProvider)
        Dim data As OleDbDataReader
        'OrderPageView
        Public Property orderItemList As New ObservableCollection(Of orderItem)
        Public Property orderModel As New Order
        Public Property orderItemModel As New orderItem

        'OrderListView
        Public Property orderList As New ObservableCollection(Of Order)

        'Singleton - To pass data between form 
        Public Shared Function GetInstance() As orderPageViewModel
            If _instance Is Nothing Then
                _instance = New orderPageViewModel()
            End If
            Return _instance
        End Function

        'UC005.1 Read
        ''Select order list
        Public Sub getOrderListFromModel()
            orderList.Clear()
            Dim sql As String = "Select * From [Order]"
            Dim com As New OleDbCommand(sql, con)
            con.Open()
            'Exceute reader, then load into table
            data = com.ExecuteReader()
            While data.Read()
                Dim orderModel As New Order With {
                  .Customer = data.GetValue("Customer").ToString,
                  .Phone = data.GetValue("Phone").ToString,
                  .Email = data.GetValue("Email").ToString,
                  .Address = data.GetValue("Address").ToString,
                  .Method = data.GetValue("Payment").ToString,
                  .Id = data.GetValue("Id").ToString,
                  .Courier = data.GetValue("courierRef").ToString,
                  .Status = data.GetValue("Status").ToString,
                  .IssuedOn = FormatDateTime(data.GetValue("dateIssued"), DateFormat.ShortDate)
                }
                orderList.Add(orderModel)
            End While
            con.Close()
        End Sub
        ''Select Order by ID
        Public Sub getOrderByIdFromModel(Id As String)
            Dim sql As String = "Select * From [Order] WHERE Id = ?"
            Dim com As New OleDbCommand(sql, con)
            com.Parameters.AddWithValue("@Id", Id)
            con.Open()
            'Exceute reader, then load into Model
            data = com.ExecuteReader()
            data.Read()

            Dim orderModel As New Order With {
              .Customer = data.GetValue("Customer").ToString,
              .Phone = data.GetValue("Phone").ToString,
              .Email = data.GetValue("Email").ToString,
              .Address = data.GetValue("Address").ToString,
              .Method = data.GetValue("Payment").ToString,
              .Id = data.GetValue("Id").ToString,
              .Courier = data.GetValue("courierRef").ToString,
              .Status = data.GetValue("Status").ToString,
              .IssuedOn = FormatDateTime(data.GetValue("dateIssued"), DateFormat.ShortDate)
              }
            con.Close()
        End Sub
        ''Select Order's order items By Order ID
        Public Sub getOrderItemListByOrderIdFromModel(OrderId As String)
            orderItemList.Clear()
            Dim sql As String = "Select * From [OrderItems] WHERE orderId = ?"
            Dim com As New OleDbCommand(sql, con)
            com.Parameters.AddWithValue("@orderId", OrderId)
            con.Open()
            'Exceute reader, then load into Model
            data = com.ExecuteReader()
            While data.Read()
                Dim orderItemModel As New orderItem With {
                  .ID = data.GetValue("Id").ToString,
                  .OrderID = data.GetValue("orderId").ToString,
                  .ItemID = data.GetValue("itemId").ToString,
                  .ItemName = data.GetValue("itemName").ToString,
                  .Quantity = data.GetValue("Quantity").ToString,
                  .Price = data.GetValue("Price").ToString,
                  .Total = data.GetValue("Total").ToString
                }
                orderItemList.Add(orderItemModel)
            End While
            con.Close()
        End Sub
        ''Select order items By Order ID and Item ID
        Public Sub getOrderItemByOrderIdAndItemIdFromModel(OrderId As String, itemId As String)
            Dim sql As String = "Select * From [OrderItems] WHERE orderId = ? AND itemId = ?"
            Dim com As New OleDbCommand(sql, con)
            com.Parameters.AddWithValue("@orderId", OrderId)
            com.Parameters.AddWithValue("@itemId", itemId)
            con.Open()
            'Exceute reader, then load into Model
            data = com.ExecuteReader()
            data.Read()
            orderItemModel.ID = data.GetValue("Id").ToString
            orderItemModel.OrderID = data.GetValue("orderId").ToString
            orderItemModel.ItemID = data.GetValue("itemId").ToString
            orderItemModel.ItemName = data.GetValue("itemName").ToString
            orderItemModel.Quantity = data.GetValue("Quantity").ToString
            orderItemModel.Price = data.GetValue("Price").ToString
            orderItemModel.Total = data.GetValue("Total").ToString
            con.Close()
        End Sub

        'UC003 Add Order
        Public Sub addNewOrderIntoModel(Cust As String, Phone As String, Email As String,
                                        Address As String, Payment As String, Id As String,
                                        Courier As String, Status As String, dateIssue As String,
                                        orderItem As Item, itemPrice As String, itemQuantity As String)
            'Add New Order into Order Table
            Dim sql As String = "INSERT INTO [Order] (Customer, Phone, Email, 
                                                      Address, Payment, Id,
                                                      courierRef, Status, dateIssued) VALUES 
                                                      (?,?,?,
                                                       ?,?,?,
                                                       ?,?,?)"
            Dim com = New OleDbCommand(sql, con)
            If CheckExistOrderInDatabase(Id) = True Then
                'Add only new order item
                addNewOrderItemIntoOrder(Id, orderItem, itemPrice, itemQuantity)
                'Add new sales
                ''Get orderItem 
                getOrderItemByOrderIdAndItemIdFromModel(Id, orderItem.ID)
                AddSalesIntoDatabase(Id, dateIssue, orderItemModel)
            Else
                'Add new order
                con.Open()
                com.Parameters.AddWithValue("@cust", Cust)
                com.Parameters.AddWithValue("@phone", Phone)
                com.Parameters.AddWithValue("@email", Email)
                com.Parameters.AddWithValue("@address", Address)
                com.Parameters.AddWithValue("@payment", Payment)
                com.Parameters.AddWithValue("@id", Id)
                com.Parameters.AddWithValue("@courier", Courier)
                com.Parameters.AddWithValue("@status", Status)
                com.Parameters.AddWithValue("@date", dateIssue)
                com.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("Added New Order with ID: " + Id)
                'Add new order item
                addNewOrderItemIntoOrder(Id, orderItem, itemPrice, itemQuantity)
                'Add new sales
                ''Get orderItem 
                getOrderItemByOrderIdAndItemIdFromModel(Id, orderItem.ID)
                AddSalesIntoDatabase(Id, dateIssue, orderItemModel)
            End If
            'Refresh order's Order Item List
            getOrderItemListByOrderIdFromModel(Id)
        End Sub
        '''Add order's order item
        Private Sub addNewOrderItemIntoOrder(orderId As String, orderItem As Item, Price As String, Quantity As String)
            Try
                'Add New OrderItem into OrderItem Table
                Dim sql As String = "INSERT INTO [OrderItems] (orderId, itemId, itemName, Quantity, Price) VALUES 
                                                              (?,?,?,?,?)"
                Dim com = New OleDbCommand(sql, con)
                con.Open()
                com.Parameters.AddWithValue("@orderId", orderId)
                com.Parameters.AddWithValue("@itemId", orderItem.ID)
                com.Parameters.AddWithValue("@itemName", orderItem.Name)
                com.Parameters.AddWithValue("@quantity", Quantity)
                com.Parameters.AddWithValue("@price", Price)
                com.ExecuteNonQuery()
                con.Close()
                MessageBox.Show("New order item added to Order ID: " + orderId)
            Catch
                MessageBox.Show("Issue in adding a new order item into the order.")
            End Try
        End Sub

        'UC005.2 Delete
        ''Delete Order Item
        Public Sub deleteOrderItemFromModel(deleteOrderItem As orderItem)
            Select Case MsgBox("Remove this item with the name: " + deleteOrderItem.ItemName, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    Dim sql As String = "DELETE FROM [OrderItems] WHERE Id = ?"
                    Dim com = New OleDbCommand(sql, con)
                    'Open Connection
                    con.Open()
                    com.Parameters.AddWithValue("@Id", deleteOrderItem.ID)
                    com.ExecuteNonQuery()
                    MessageBox.Show("Item successfully removed from the order.")
                    con.Close()
            End Select
            getOrderItemListByOrderIdFromModel(deleteOrderItem.OrderID)
        End Sub
        ''Delete Order
        Public Sub deleteOrderFromModel(deleteOrder As Order)
            Select Case MsgBox("Remove this order with the ID: " + deleteOrder.Id, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    con.Open()
                    Try
                        Dim sql As String = "DELETE FROM [Order] WHERE Id = ?"
                        Dim com = New OleDbCommand(sql, con)
                        com.Parameters.AddWithValue("@Id", deleteOrder.Id)
                        com.ExecuteNonQuery()
                        MessageBox.Show("Order successfully removed from database.")
                    Catch
                        MessageBox.Show("The order has order items listed. Please remove it first.")
                    End Try
                    con.Close()
            End Select
        End Sub

        'UC005.3 Update
        Public Sub updateOrderByIDIntoModel(Cust As String, Phone As String, Email As String,
                                            Address As String, Payment As String, newId As String,
                                            Courier As String, Status As String, dateIssue As String,
                                            oldId As String)
            Select Case MsgBox("Update this order with ID: " + oldId, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    Dim sql As String = "UPDATE [Order] SET Id=?, Customer=?, Phone=?, Email=?, Address=?,
                                                    Payment=?, courierRef=?, Status=?, dateIssued=? 
                                                    WHERE Id=?;"
                    Dim com = New OleDbCommand(sql, con)
                    con.Open()
                    com.Parameters.AddWithValue("@newId", newId)
                    com.Parameters.AddWithValue("@cust", Cust)
                    com.Parameters.AddWithValue("@phone", Phone)
                    com.Parameters.AddWithValue("@email", Email)
                    com.Parameters.AddWithValue("@address", Address)
                    com.Parameters.AddWithValue("@payment", Payment)
                    com.Parameters.AddWithValue("@courier", Courier)
                    com.Parameters.AddWithValue("@status", Status)
                    com.Parameters.AddWithValue("@date", dateIssue)
                    com.Parameters.AddWithValue("@oldId", oldId)
                    com.ExecuteNonQuery()
                    MessageBox.Show("Order Details successfully updated.")
                    con.Close()
            End Select

        End Sub

        'Sub-Function
        Public Function CheckExistOrderInDatabase(Id As String) As Boolean
            Dim Status As New Boolean
            Dim sql As String = "Select * From [Order] WHERE Id = ?"
            Dim com As New OleDbCommand(sql, con)
            com.Parameters.AddWithValue("@Id", Id)
            con.Open()
            'Exceute reader, then load into Model
            data = com.ExecuteReader()
            If data.HasRows Then
                Status = True
            Else
                Status = False
            End If
            con.Close()
            Return Status
        End Function
        ''Sales
        '''Add new sales
        Private Sub AddSalesIntoDatabase(orderId As String, _date As String, orderItem As orderItem)
            Dim sql As String = "INSERT INTO [Sales] (orderId, orderItemId, itemName, dateIssued, Amount) VALUES 
                                                      (?,?,?,?,?)"
            Dim com = New OleDbCommand(sql, con)
            con.Open()
            com.Parameters.AddWithValue("@orderId", orderId)
            com.Parameters.AddWithValue("@orderItemId", orderItem.ID)
            com.Parameters.AddWithValue("@itemName", orderItem.ItemName)
            com.Parameters.AddWithValue("@dateIssued", _date)
            com.Parameters.AddWithValue("@amount", orderItem.Total)
            com.ExecuteNonQuery()
            con.Close()
        End Sub
        ''Testing input
        Private Sub Testing(input As String)
            MessageBox.Show(input)
        End Sub
    End Class

End Namespace
