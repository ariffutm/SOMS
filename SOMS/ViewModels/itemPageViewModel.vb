Imports SOMS.Models
Imports System.Collections.ObjectModel
Imports System.Data.OleDb

Namespace ViewModels
    Public Class itemPageViewModel
        Public Property itemList As New ObservableCollection(Of Item)
        Public Property selectedItem As New Item

        Dim con As New OleDbConnection(Database.dbProvider)
        Dim data As OleDbDataReader

        'UC013 Read
        Public Sub getAllItemListFromModel()
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
        End Sub

        'UC007 Add
        Public Sub addNewItemIntoModel(Id As String, Name As String, Price As String, Description As String, Stock As String)
            Dim sql As String = "INSERT INTO [Item] (Id, itemName, Price, Description, Stock) VALUES (?,?,?,?,?)"
            Dim com = New OleDbCommand(sql, con)
            If String.IsNullOrEmpty(Id) Then
                MessageBox.Show("Please fill in the correct ID for the item.")
            ElseIf DataValidationGood(Id, Name, Price, Description, Stock) Then
                con.Open()
                com.Parameters.AddWithValue("@id", Id)
                com.Parameters.AddWithValue("@username", Name)
                com.Parameters.AddWithValue("@price", Price)
                com.Parameters.AddWithValue("@description", Description)
                com.Parameters.AddWithValue("@stock", Stock)
                com.ExecuteNonQuery()
                MessageBox.Show("New item added to the Database")
                con.Close()
            End If
        End Sub

        'UC008 Delete
        Public Sub deleteItemByIDFromModel(deleteUser As Item)
            Select Case MsgBox("Delete this Item with the ID: " + deleteUser.ID, MsgBoxStyle.YesNo)
                Case MsgBoxResult.Yes
                    Dim sql As String = "DELETE FROM [Item] WHERE Id = ?"
                    Dim com = New OleDbCommand(sql, con)
                    'Open Connection
                    con.Open()
                    com.Parameters.AddWithValue("@Id", deleteUser.ID)
                    com.ExecuteNonQuery()
                    MessageBox.Show("Item successfully deleted from the Database")
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
    End Class
End Namespace
