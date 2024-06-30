Imports SOMS.Models
Imports System.Collections.ObjectModel
Imports System.Data.OleDb

Namespace ViewModels
    Public Class itemPageViewModel
        'Instance Attributes
        Private Shared _instance As itemPageViewModel
        'Order Attributes
        Public Property itemList As New ObservableCollection(Of Item)
        Public Property selectedItem As New Item

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
        Public Sub getAllItemListFromModel()
            itemList.Clear()
            Dim sql As String = "Select * From [Item]"
            Dim com As New OleDbCommand(sql, con)
            con.Open()
            'Exceute reader, then load into table
            data = com.ExecuteReader()
            While data.Read()
                Dim Model As New Item With {
                 .ID = data("Id"),
                 .Name = data("itemName"),
                 .Price = data("Price"),
                 .Description = data("Description"),
                 .Stock = data("Stock")
                }
                itemList.Add(Model)
            End While
            con.Close()
            For Each data As Item In itemList
                getOrderItemListFromOrderItemModel(data)
            Next
        End Sub
        ''By Item ID From Order List Table
        Public Sub getOrderItemListFromOrderItemModel(Item As Item)
            Dim sql As String = "Select * From [OrderItems] WHERE itemId = ?"
            Dim com As New OleDbCommand(sql, con)
            com.Parameters.AddWithValue("@itemId", Item.ID)
            con.Open()
            'Exceute reader, then load into table
            data = com.ExecuteReader()
            While data.Read()
                Dim Model As New orderItem With {
                   .ID = data.GetValue(0).ToString,
                  .OrderID = data.GetValue(1).ToString,
                  .ItemID = data.GetValue(2).ToString,
                  .ItemName = data.GetValue(3).ToString,
                  .Quantity = data.GetValue(4).ToString,
                  .Price = data.GetValue(5).ToString,
                  .Total = data.GetValue(6).ToString
                }
                Item.orderItemList.Add(Model)
            End While
            Item.calculateBalance()
            con.Close()
        End Sub

        'UC007 Add
        Public Sub addNewItemIntoModel(Id As String, Name As String, Price As String, Description As String, Stock As String)
            Dim sql As String = "INSERT INTO [Item] (Id, itemName, Price, Description, Stock) VALUES (?,?,?,?,?)"
            Dim com = New OleDbCommand(sql, con)
            con.Open()
            Try
                If String.IsNullOrEmpty(Id) Then
                    MessageBox.Show("Please fill in the correct ID for the item.")
                ElseIf DataValidationGood(Id, Name, Price, Description, Stock) Then
                    com.Parameters.AddWithValue("@id", Id)
                    com.Parameters.AddWithValue("@username", Name)
                    com.Parameters.AddWithValue("@price", Price)
                    com.Parameters.AddWithValue("@description", Description)
                    com.Parameters.AddWithValue("@stock", Stock)
                    com.ExecuteNonQuery()
                    MessageBox.Show("New item added to the Database")
                End If
            Catch
                MessageBox.Show("Make sure to fill in the correct format details, especially the price.")
            End Try
            con.Close()
        End Sub

        'UC008 Delete
        Public Sub deleteItemByIDFromModel(deleteUser As Item)
            Select Case MsgBox("Delete this Item with the ID: " + deleteUser.ID, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    'Open Connection
                    con.Open()
                    Try
                        Dim sql As String = "DELETE FROM [Item] WHERE Id = ?"
                        Dim com = New OleDbCommand(sql, con)
                        com.Parameters.AddWithValue("@Id", deleteUser.ID)
                        com.ExecuteNonQuery()
                        MessageBox.Show("Item successfully deleted from the database")
                    Catch
                        MessageBox.Show("There are orders with this item listed.")
                    End Try
                    con.Close()
            End Select
        End Sub

        'UC009 Update
        Public Sub updateItemByIDToModel(oldId As String, Id As String, Name As String, Price As String, Description As String, Stock As String)
            Dim sql As String = "UPDATE [Item] SET Id=?, itemName=?, Price=?, Description=?, Stock=? WHERE Id=?"
            Dim com = New OleDbCommand(sql, con)
            'Process Start
            If String.IsNullOrEmpty(Id) Then
                MessageBox.Show("Please click the select button below to choose the Item for the update.")
            ElseIf DataValidationGood(Id, Name, Price, Description, Stock) Then
                Select Case MsgBox("Update the Item with ID: " + oldId, MsgBoxStyle.YesNo)
                    Case MsgBoxResult.Yes
                        con.Open()
                        com.Parameters.AddWithValue("@id", Id)
                        com.Parameters.AddWithValue("@username", Name)
                        com.Parameters.AddWithValue("@price", Price)
                        com.Parameters.AddWithValue("@description", Description)
                        com.Parameters.AddWithValue("@stock", Stock)
                        com.Parameters.AddWithValue("@stock", oldId)
                        com.ExecuteNonQuery()
                        MessageBox.Show("Update sucessfully.")
                        con.Close()
                End Select
            End If
        End Sub

        '''Sub-Function
        'UI Data Validation
        Public Function DataValidationGood(Id As String, Name As String, Price As String, Description As String, Stock As String) As Boolean
            If CDbl(Price) < 0 Then
                MessageBox.Show("Please fill in a positive number for the price.")
            ElseIf CInt(Stock) < 0 Then
                MessageBox.Show("Please fill in a positive number for the stock.")
            ElseIf String.IsNullOrEmpty(Name) Then
                MessageBox.Show("Please fill in all boxes.")
            Else
                Return True
            End If
            Return False
        End Function

        Private Sub Testing(input As String)
            MessageBox.Show(input)
        End Sub
    End Class
End Namespace
