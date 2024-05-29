Imports SOMS.Models
Imports SOMS.ViewModels

Public Class itemPageView
    Dim viewModel As New itemPageViewModel

    Public Sub New()
        InitializeComponent()
        Me.DataContext = seeAllItemList()
    End Sub
    'Read item list from Model
    Private Function seeAllItemList() As itemPageViewModel
        Dim viewModel As New itemPageViewModel
        viewModel.getAllItemListFromModel()
        Return viewModel
    End Function

    'UC013 Add
    Private Sub sendAddedItemDetail(sender As Object, e As RoutedEventArgs) Handles ButtonAdd.Click
        viewModel.addNewItemIntoModel(TxtBxId.Text, TxtBxName.Text, TxtBxPrice.Text, TxtBxDescription.Text, TxtBxStock.Text)
        Me.DataContext = seeAllItemList()
    End Sub

    'UC013 Delete
    Private Sub RemoveItem(sender As Object, e As RoutedEventArgs)
        Dim item As Item = DataGridItem.SelectedItem
        viewModel.deleteItemByIDFromModel(item)
        Me.DataContext = seeAllItemList()
    End Sub

    'UC013 Select itemId First, then Update
    Private Sub SelectItem(sender As Object, e As RoutedEventArgs)
        Dim item As Item = DataGridItem.SelectedItem
        OldId.Text = item.ID
        TxtBxId.Text = item.ID
        TxtBxName.Text = item.Name
        TxtBxPrice.Text = item.Price
        TxtBxDescription.Text = item.Description
        TxtBxStock.Text = item.Stock
    End Sub
    Private Sub sendItemUpdatedByID(sender As Object, e As RoutedEventArgs) Handles ButtonUpdate.Click
        viewModel.updateItemByIDToModel(OldId.Text, TxtBxId.Text, TxtBxName.Text, TxtBxPrice.Text, TxtBxDescription.Text, TxtBxStock.Text)
        Me.DataContext = seeAllItemList()
    End Sub


    'Testing
    Private Sub Testing(input As String)
        MessageBox.Show(input)
    End Sub
End Class
