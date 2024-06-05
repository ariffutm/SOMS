Imports SOMS.Models
Imports SOMS.ViewModels
Public Class itemPageView
    Dim viewModel = itemPageViewModel.GetInstance

    Public Sub New()
        InitializeComponent()
        Me.DataContext = seeAllItemList()
    End Sub
    'Read item list from Model
    Public Function seeAllItemList() As itemPageViewModel
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
        If String.IsNullOrWhiteSpace(OldId.Text) Then
            MessageBox.Show("Please select the item in the list to update.")
        Else
            viewModel.updateItemByIDToModel(OldId.Text, TxtBxId.Text, TxtBxName.Text, TxtBxPrice.Text, TxtBxDescription.Text, TxtBxStock.Text)
            OldId.Text = ""
            Me.DataContext = seeAllItemList()
        End If
    End Sub

    'Testing
    Private Sub Testing(input As String)
        MessageBox.Show(input)
    End Sub

    'Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
    '    Dim form As New orderSubsystemPageView
    '    form.TabControl.SelectedIndex = 1
    'End Sub
End Class
