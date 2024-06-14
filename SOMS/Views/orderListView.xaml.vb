Imports SOMS.Models
Imports SOMS.ViewModels
Imports System.Windows.Forms

Public Class orderListView
    Public viewModel = orderPageViewModel.GetInstance
    Public Shared selectedOrder As New Order

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        viewModel.getOrderListFromModel()
        Me.DataContext = viewModel
    End Sub
    'UC005 Update Order
    ''Select to Update
    Public Sub SelectOrder(sender As Object, e As RoutedEventArgs)
        selectedOrder = DataGridOrder.SelectedItem
        Dim orderForm As New orderSubsystemPageView
        ''Order Details
        orderForm.OldId.Text = selectedOrder.Id
        orderForm.TxtBxCustomerName.Text = selectedOrder.Customer
        orderForm.TxtBxPhone.Text = selectedOrder.Phone
        orderForm.TxtBxEmail.Text = selectedOrder.Email
        orderForm.TxtBxAddress.Text = selectedOrder.Address
        orderForm.CmbBxPayment.Text = selectedOrder.Method
        orderForm.TxtBxId.Text = selectedOrder.Id
        orderForm.TxtBxCourier.Text = selectedOrder.Courier
        orderForm.CmbBxStatus.Text = selectedOrder.Status
        orderForm.TxtBxDate.Text = selectedOrder.IssuedOn
        ''Order Item List
        viewModel.getOrderItemListByOrderIdFromModel(selectedOrder.Id)
        orderForm.DataGridOrderItem.ItemsSource = viewModel.orderItemList
        orderForm.summaryOrderTotal()
        orderForm.Show()
        Me.Close()
        'mark = 1
    End Sub
    ''Remove order
    Private Sub RemoveOrder(sender As Object, e As RoutedEventArgs)
        Dim selectedOrder As Order = DataGridOrder.SelectedItem
        viewModel.deleteOrderFromModel(selectedOrder)
        viewModel.getOrderListFromModel
    End Sub
    ''UC006 Notify Customer With Email
    Private Sub clickNotifyCustomerOrderButton(sender As Object, e As RoutedEventArgs)
        Dim selectedOrder As Order = DataGridOrder.SelectedItem
        If String.IsNullOrEmpty(selectedOrder.Email) = False Then
            viewModel.requestOrderDetailsForNotifyByID(selectedOrder)
        Else
            MessageBox.Show("The customer emptied out the email details.")
        End If
    End Sub
    'Testing input
    Private Sub Testing(input As String)
        MessageBox.Show(input)
    End Sub
End Class
