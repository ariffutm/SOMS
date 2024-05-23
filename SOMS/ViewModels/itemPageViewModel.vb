Imports SOMS.Models
Imports System.Collections.ObjectModel
Imports System.Data.OleDb

Public Class itemPageViewModel
    Public Property itemList As New ObservableCollection(Of Item)
    Public Property selectedItem As New Item

    Dim con As New OleDbConnection(Database.dbProvider)
    Dim data As OleDbDataReader

    'UC013 Read
    Public Sub getItemListFromModel()
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
             .Description = data("Description")
            }
            itemList.Add(Model)
        End While
        con.Close()
    End Sub
End Class
