Imports System.IO
Imports SOMS.ViewModels

Public Class orderPageView
    Dim viewModel As New orderPageViewModel
    Dim itemModel As New itemPageViewModel
    Public Sub New()
        InitializeComponent()
        loadItemIntoComboboxItem()
    End Sub
    'Handle Add Button Click Event
    Private Sub ButtonAdd_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAdd.Click

    End Sub
    'Populate ComboBoxItem
    Private Sub loadItemIntoComboboxItem()
        itemModel.getItemListFromModel()
        CmbBxItem.ItemsSource = itemModel.itemList
    End Sub
    'Handle ComboBoxItem Events
    Private Sub orderItemOption(sender As Object, e As EventArgs) Handles CmbBxItem.DropDownClosed
        itemModel.selectedItem = CmbBxItem.SelectedItem
        TxtBxPrice.Text = itemModel.selectedItem.Price
    End Sub
    'Handle ComboBoxPayment Events
    Private Sub paymentOption(sender As Object, e As EventArgs) Handles CmbBxPayment.DropDownClosed
        If CmbBxPayment.Text = "Cash On Delivery" Then
            TxtBxTransaction.IsReadOnly = True
            TxtBxTransaction.Background = Brushes.LightGray
            TxtBxCourier.IsReadOnly = True
            TxtBxCourier.Background = Brushes.LightGray
        Else
            TxtBxTransaction.IsReadOnly = False
            TxtBxTransaction.Background = Brushes.White
            TxtBxCourier.IsReadOnly = False
            TxtBxCourier.Background = Brushes.White
        End If
    End Sub
    'Total Payment Calculation
    Private Sub TotalHandler(sender As Object, e As TextChangedEventArgs)
        Dim Price, Total As New Double, Quantity As New Integer
        Double.TryParse(TxtBxPrice.Text, Price)
        Int32.TryParse(TxtBxQuantity.Text, Quantity)
        Total = Price * Quantity
        TxtBxTotal.Text = Total.ToString
    End Sub
    'Testing input
    Private Sub Testing(input As String)
        MessageBox.Show(input)
    End Sub
End Class
