Imports System.Collections.ObjectModel
Imports System.Data
Imports System.Data.OleDb
Imports SOMS.Models

Namespace ViewModels
    Public Class orderPageViewModel
        'Private Shared _instance As orderPageViewModel

        Dim con As New OleDbConnection(Database.dbProvider)
        Dim data As OleDbDataReader
        'OrderPageView
        Public Property orderItemList As New ObservableCollection(Of orderItem)
        Public Property orderModel As New Order
        Public Property orderItemModel As New orderItem

        'OrderListView
        Public Property orderList As New ObservableCollection(Of Order)

        ''Singleton - To pass data between form 
        'Public Shared Function GetInstance() As orderPageViewModel
        '    If _instance Is Nothing Then
        '        _instance = New orderPageViewModel()
        '    End If
        '    Return _instance
        'End Function

        'UC005.1 Read
        ''''Select order list
        Public Sub getOrderListFromModel()
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
        ''''Select Order by ID
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
            Testing(orderModel.Id)
        End Sub
        '''''Select Order's order items By Order ID
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
            'Try
            If CheckExistOrderInDatabase(Id) = True Then
                addNewOrderItemIntoOrder(Id, orderItem, itemPrice, itemQuantity)
            Else
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
                addNewOrderItemIntoOrder(Id, orderItem, itemPrice, itemQuantity)
                MessageBox.Show("Added New Order with ID: " + Id)
            End If
            'Catch
            '    MessageBox.Show("Maybe the same reference ID exists. Please click the 'Search Order' button to select an existing order.")
            'Finally

            'End Try
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

        ''Sub-Function
        Public Function CheckExistOrderInDatabase(Id As String) As Boolean
            Testing("CheckExistOrderInDatabase")
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
        'Testing input
        Private Sub Testing(input As String)
            MessageBox.Show(input)
        End Sub
    End Class

End Namespace
