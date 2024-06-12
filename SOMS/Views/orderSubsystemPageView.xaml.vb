Imports System.Collections.ObjectModel
Imports System.Windows.Interop
Imports SOMS.Models
Imports SOMS.ViewModels

Public Class orderSubsystemPageView
    Dim orderModel = orderPageViewModel.GetInstance
    Dim itemModel = itemPageViewModel.GetInstance

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
        RefreshView()
    End Sub
    'UC005 Update Order
    ''DataGridOrderItem Delete Button Column Handler - Delete order Item
    Private Sub RemoveOrderItem(sender As Object, e As RoutedEventArgs)
        Dim orderItem As orderItem = DataGridOrderItem.SelectedItem
        orderModel.deleteOrderItemFromModel(orderItem)
        Me.DataContext = orderModel
        summaryOrderTotal()
        RefreshView()
    End Sub
    ''Handle Button - Update order details
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
        RefreshView()
    End Sub

    'UI Control
    ''Handle ComboBoxItem DropDown Events
    Private Sub selectOrderItemOption(sender As Object, e As EventArgs) Handles CmbBxItem.DropDownClosed
        If String.IsNullOrWhiteSpace(CmbBxItem.Text) = False Then
            itemModel.selectedItem = CmbBxItem.SelectedItem
            TxtBxPrice.Text = itemModel.selectedItem.Price
        End If
    End Sub
    ''Handle ComboBoxItem DropDownOpened Events
    Private Sub refreshOrderItemOption(sender As Object, e As EventArgs) Handles CmbBxItem.DropDownOpened
        loadItemIntoComboboxItem()
    End Sub
    ''Handle ComboBoxPayment DropDown event
    Private Sub CmbxPayment(sender As Object, e As EventArgs) Handles CmbBxPayment.DropDownClosed
        paymentOption()
    End Sub
    ''Handle Search Order Button click event - Open OrderList
    Private Sub ButtonSearchOrder_Click(sender As Object, e As RoutedEventArgs) Handles ButtonSearchOrder.Click
        showOrderListView()
        Me.Close()
        'While form.mark
        'End While
    End Sub
    ''Handle Button - Clear Textbox
    Private Sub ButtonCancel_Click(sender As Object, e As RoutedEventArgs) Handles ButtonCancel.Click
        clearTextBox()
    End Sub
    ''Handle Button - Make Receipt
    Private Sub ButtonReceipt_Click(sender As Object, e As RoutedEventArgs) Handles ButtonReceipt.Click
        makeReceipt()
    End Sub
    ''Handle Button - Back to Dashboard
    Private Sub ButtonBack_Click(sender As Object, e As RoutedEventArgs) Handles ButtonBack.Click
        Me.Close()
    End Sub

    'Sub-function''
    ''Populate ComboBoxItem
    Private Sub loadItemIntoComboboxItem()
        'Dim itemModel As New itemPageViewModel
        itemModel.getAllItemListFromModel()
        CmbBxItem.ItemsSource = itemModel.itemList
    End Sub
    ''Total Payment Calculation Function
    Private Sub TotalHandler(sender As Object, e As TextChangedEventArgs)
        Dim Price, Total As Double, Quantity As New Integer

        Double.TryParse(TxtBxPrice.Text, Price)
        Int32.TryParse(TxtBxQuantity.Text, Quantity)

        Total = Price * Quantity
        TxtBxTotal.Text = Format(Total, "0.00")
    End Sub
    ''ComboBoxPayment Events - Control Function
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
    ''Summary Total Calculation Function 
    Public Sub summaryOrderTotal()
        Dim sum As Double = 0
        For Each row As orderItem In DataGridOrderItem.ItemsSource
            sum += Double.Parse(row.Total)
        Next
        TxtBxOrderTotal.Text = Format(sum, "0.00")
    End Sub
    ''Clear Textbox Function
    Public Sub clearTextBox()
        TxtBxCustomerName.Clear()
        TxtBxPhone.Clear()
        TxtBxEmail.Clear()
        TxtBxAddress.Clear()
        CmbBxPayment.Text = "Online Transfer"
        TxtBxId.Clear()
        TxtBxCourier.Clear()
        paymentOption()
        TxtBxDate.Text = ""
        CmbBxItem.Text = ""
        TxtBxPrice.Clear()
        TxtBxQuantity.Clear()
        TxtBxTotal.Clear()
        TxtBxOrderTotal.Clear()
        OldId.Text = ""
        orderModel.orderItemList.Clear()
    End Sub
    ''To refresh Views' display data Function
    Private Sub RefreshView()
        Dim formitem As New itemPageView
        Dim formSales As New salesPageView
    End Sub
    ''Display Order List Page Function
    Private Sub showOrderListView()
        Dim view As New orderListView
        view.Show()
    End Sub
    ''Display Receipt Data Function
    Private Sub makeReceipt()
        Dim receipt As New Receipt
        Dim Address = getAddress(TxtBxAddress.Text)
        Dim print As New PrintDialog()

        receipt.Customer.Text = TxtBxCustomerName.Text
        receipt.Phone.Text = TxtBxPhone.Text
        receipt.Address1.Text = Address(0)
        receipt.Address2.Text = Address(1)
        receipt.RefValue.Text = TxtBxId.Text
        receipt.DateValue.Text = TxtBxDate.Text
        receipt.TypeValue.Text = CmbBxPayment.Text
        receipt.TrackValue.Text = TxtBxCourier.Text
        receipt.DataGridOrderItem.ItemsSource = DataGridOrderItem.ItemsSource
        receipt.TotalValue.Text = TxtBxOrderTotal.Text
        receipt.Show()

        'If print.ShowDialog() = True Then
        print.PrintVisual(receipt, "Receipt")
        'End If
    End Sub
    ''Address Function
    Private Function getAddress(Address As String) As String()
        Dim Input As String() = Split(Address, ",", 3)
        Dim addressArray(1) As String

        For cycle As Integer = 0 To Input.Length - 1
            If cycle < (Input.Count / 2) Then
                addressArray(0) += Input(cycle)
                addressArray(0) += ", "
            Else
                addressArray(1) += Input(cycle)
            End If
        Next
        Return addressArray
    End Function
End Class
