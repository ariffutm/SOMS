Imports SOMS.Models
Imports SOMS.ViewModels

Public Class orderSubsystemPageView
    Dim orderModel = orderPageViewModel.GetInstance
    Dim itemModel As New itemPageViewModel

    Public Sub New()
        InitializeComponent()
        loadItemIntoComboboxItem()
        Me.DataContext = orderModel
    End Sub
    'UC003 Add Order - Handle Add Button Click Event
    Private Sub sendAddedOrderDetail(sender As Object, e As RoutedEventArgs) Handles ButtonAdd.Click
        orderModel.addNewOrderIntoModel(TxtBxCustomerName.Text, TxtBxPhone.Text, TxtBxEmail.Text,
                                    TxtBxAddress.Text, CmbBxPayment.Text, TxtBxId.Text,
                                    TxtBxCourier.Text, CmbBxStatus.Text, TxtBxDate.Text,
                                    itemModel.selectedItem, TxtBxPrice.Text, TxtBxQuantity.Text)
        summaryOrderTotal()
    End Sub
    'UC005 Update Order
    '''DataGridOrderItem Delete Button Column Handler - Delete order Item
    Private Sub RemoveOrderItem(sender As Object, e As RoutedEventArgs)
        Dim orderItem As orderItem = DataGridOrderItem.SelectedItem
        orderModel.deleteOrderItemFromModel(orderItem)
        Me.DataContext = orderModel
        summaryOrderTotal()
    End Sub
    '''Update Order Details Button Handler - Update order details
    Private Sub sendOrderUpdateDetailsByID(sender As Object, e As RoutedEventArgs) Handles ButtonUpdate.Click
        If String.IsNullOrWhiteSpace(OldId.Text) Then
            MessageBox.Show("Please click the 'Search Order' button to begin the order update process.")
        Else
            orderModel.updateOrderByIDIntoModel(TxtBxCustomerName.Text, TxtBxPhone.Text, TxtBxEmail.Text,
                                                TxtBxAddress.Text, CmbBxPayment.Text, TxtBxId.Text,
                                                TxtBxCourier.Text, CmbBxStatus.Text, TxtBxDate.Text,
                                                OldId.Text)
            OldId.Text = ""
        End If
    End Sub
    'UI Control
    '''Handle ComboBoxItem DropDown Events
    Private Sub selectOrderItemOption(sender As Object, e As EventArgs) Handles CmbBxItem.DropDownClosed
        If String.IsNullOrWhiteSpace(CmbBxItem.Text) = False Then
            itemModel.selectedItem = CmbBxItem.SelectedItem
            TxtBxPrice.Text = itemModel.selectedItem.Price
        End If
    End Sub
    '''Handle ComboBoxItem DropDownOpened Events
    Private Sub refreshOrderItemOption(sender As Object, e As EventArgs) Handles CmbBxItem.DropDownOpened
        loadItemIntoComboboxItem()
    End Sub
    '''Handle ComboBoxPayment DropDown event
    Private Sub CmbxPayment(sender As Object, e As EventArgs) Handles CmbBxPayment.DropDownClosed
        paymentOption()
    End Sub
    ''Sub-function''
    ''<<<<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>>>>>
    'Populate ComboBoxItem
    Private Sub loadItemIntoComboboxItem()
        Dim itemModel As New itemPageViewModel
        itemModel.getAllItemListFromModel()
        CmbBxItem.ItemsSource = itemModel.itemList
    End Sub
    ''Total Payment Calculation
    Private Sub TotalHandler(sender As Object, e As TextChangedEventArgs)
        Dim Price, Total As Double, Quantity As New Integer

        Double.TryParse(TxtBxPrice.Text, Price)
        Int32.TryParse(TxtBxQuantity.Text, Quantity)

        Total = Price * Quantity
        TxtBxTotal.Text = Format(Total, "0.00")
    End Sub
    ''ComboBoxPayment Events - Control
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
    ''Search Order Button Handler - Open OrderList
    Private Sub ButtonSearchOrder_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSearchOrder.Click
        Dim form As New orderListView
        form.Show()
        Me.Close()
        'While form.mark
        'End While
    End Sub
    ''Summary Total Calculation 
    Public Sub summaryOrderTotal()
        Dim sum As Double = 0
        For Each row As orderItem In DataGridOrderItem.ItemsSource
            sum += Double.Parse(row.Total)
        Next
        TxtBxOrderTotal.Text = Format(sum, "0.00")
    End Sub
End Class
