Imports System.Collections.ObjectModel
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
        Public Sub getOrderListFromModel()
            Dim sql As String = "Select * From [Order]"
            Dim com As New OleDbCommand(sql, con)
            con.Open()
            'Exceute reader, then load into table
            data = com.ExecuteReader()
            While data.Read()
                Dim orderModel As New Order With {
                  .Customer = data.GetValue("buyerName").ToString,
                  .Phone = data.GetValue("buyerPhone").ToString,
                  .Email = data.GetValue("Email").ToString,
                  .Address = data.GetValue("Address").ToString,
                  .Method = data.GetValue("Payment").ToString,
                  .Id = data.GetValue("Id").ToString,
                  .Courier = data.GetValue("courierNumber").ToString,
                  .Status = data.GetValue("Status").ToString,
                  .IssuedOn = data.GetValue("dateIssued").ToString
                }
                orderList.Add(orderModel)
            End While
            con.Close()
        End Sub
        Private Sub getOrderItemListByOrderIdFromModel(OrderId As String)
            Dim sql As String = "Select * From [OrderItems] WHERE orderId = ?"
            Dim com As New OleDbCommand(sql, con)
            com.Parameters.AddWithValue("@orderId", OrderId)
            con.Open()
            'Exceute reader, then load into table
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

        'UC003 Add
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
            Try
                con.Open()
                'If String.IsNullOrWhiteSpace(Username) Or String.IsNullOrWhiteSpace(Password) Or String.IsNullOrEmpty(Status) Then
                '    MessageBox.Show("Please fill out all text boxes.")
                'Else
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
                'End If
                con.Close()
                addNewOrderItemIntoModel(Id, orderItem, itemPrice, itemQuantity)
            Catch
                MessageBox.Show("Same Reference ID Exists. Please correct it back")
            Finally
                MessageBox.Show("New order item added to Order ID: " + Id)
            End Try
            getOrderItemListByOrderIdFromModel(Id)
        End Sub
        Private Sub addNewOrderItemIntoModel(orderId As String, orderItem As Item, Price As String, Quantity As String)
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
        End Sub

        'UC005.2 Delete
        Public Sub deleteUserFromModel(deleteUser As User)
            Select Case MsgBox("Delete this user with the ID: " + deleteUser.Id, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    Dim sql As String = "DELETE FROM [User] WHERE Id = ?"
                    Dim com = New OleDbCommand(sql, con)
                    'Open Connection
                    con.Open()
                    com.Parameters.AddWithValue("@Id", deleteUser.Id)
                    com.ExecuteNonQuery()
                    MessageBox.Show("User successfully deleted from the Database")
                    con.Close()
            End Select
        End Sub

        'UC005.3 Update
        Public Function updateUserToModel(Id As String, Username As String, Password As String, Status As String) As Boolean
            Dim sql As String = "UPDATE [User] SET Username=?, [Password]=?, Status=? WHERE Id=?"
            Dim com = New OleDbCommand(sql, con)
            con.Open()
            If String.IsNullOrEmpty(Id) Then
                MessageBox.Show("Please click the select button below to choose the user for the update.")
            ElseIf String.IsNullOrWhiteSpace(Username) Or String.IsNullOrWhiteSpace(Password) Or String.IsNullOrEmpty(Status) Then
                MessageBox.Show("Please fill out all text boxes.")
            Else
                com.Parameters.AddWithValue("@username", Username)
                com.Parameters.AddWithValue("@password", Password)
                com.Parameters.AddWithValue("@status", Status)
                com.Parameters.AddWithValue("@id", Id)
                com.ExecuteNonQuery()
                MessageBox.Show("Update sucessfully.")
                con.Close()
                Return True
            End If
            con.Close()
            Return False
        End Function


        'Testing input
        Private Sub Testing(input As String)
            MessageBox.Show(input)
        End Sub
    End Class

End Namespace
