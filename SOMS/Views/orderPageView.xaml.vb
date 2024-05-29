Imports SOMS.ViewModels

Public Class orderPageView
    Dim orderModel As New orderPageViewModel
    Dim itemModel As New itemPageViewModel
    Public Sub New()
        InitializeComponent()
        loadItemIntoComboboxItem()
    End Sub
    'UC003 - Handle Add Button Click Event
    Private Sub sendAddedOrderDetail(sender As Object, e As RoutedEventArgs) Handles ButtonAdd.Click
        orderModel.addNewOrderIntoModel(TxtBxCustomerName.Text, TxtBxPhone.Text, TxtBxEmail.Text,
                                        TxtBxAddress.Text, CmbBxPayment.Text, TxtBxId.Text,
                                        TxtBxCourier.Text, CmbBxStatus.Text, TxtBxDate.Text,
                                        itemModel.selectedItem, TxtBxPrice.Text, TxtBxQuantity.Text)
    End Sub
    'Handle ComboBoxItem DropDown Events
    Private Sub orderItemOption(sender As Object, e As EventArgs) Handles CmbBxItem.DropDownClosed
        If String.IsNullOrWhiteSpace(CmbBxItem.Text) = False Then
            itemModel.selectedItem = CmbBxItem.SelectedItem
            TxtBxPrice.Text = itemModel.selectedItem.Price
        End If
    End Sub
    'Handle ComboBoxPayment DropDown event
    Private Sub CmbxPayment(sender As Object, e As EventArgs) Handles CmbBxPayment.DropDownClosed
        paymentOption()
    End Sub


    ''UI Control''
    ''<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>
    'Populate ComboBoxItem
    Private Sub loadItemIntoComboboxItem()
        itemModel.getItemListFromModel()
        CmbBxItem.ItemsSource = itemModel.itemList
    End Sub
    'Total Payment Calculation
    Private Sub TotalHandler(sender As Object, e As TextChangedEventArgs)
        Dim Price, Total As Double, Quantity As New Integer
        Double.TryParse(TxtBxPrice.Text, Price)
        Int32.TryParse(TxtBxQuantity.Text, Quantity)
        Total = Price * Quantity
        TxtBxTotal.Text = Format(Total, "0.00")
    End Sub
    'ComboBoxPayment Events - Control
    Private Sub paymentOption()
        If CmbBxPayment.Text = "Cash On Delivery" Then
            TxtBxCourier.IsReadOnly = True
            TxtBxCourier.Background = Brushes.LightGray
            TxtBxCourier.Text = ""
        Else
            TxtBxCourier.IsReadOnly = False
            TxtBxCourier.Background = Brushes.White
        End If
    End Sub

End Class
