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
    'Handle 'Find By Reference' Button Click event
    Private Sub ButtonFindID_Click(sender As Object, e As RoutedEventArgs) Handles ButtonFindID.Click
        If String.IsNullOrEmpty(TxtBxDetail.Text) = False Then
            viewModel.getOrderByIdFromModel(TxtBxDetail.Text)
        Else
            MessageBox.Show("Please fill in the reference in the blank.")
        End If
    End Sub
    'Handle 'Find By Date' Button Click event
    Private Sub ButtonFindDate_Click(sender As Object, e As RoutedEventArgs) Handles ButtonFindDate.Click
        If String.IsNullOrEmpty(TxtBxDetail.Text) = False Then
            viewModel.getOrderByDateFromModel(TxtBxDetail.Text)
        Else
            MessageBox.Show("Please fill in the date in the right format in the blank, such as DD/MM/YYYY or 21/12/2020.")
        End If
    End Sub
    'Handle 'Get All Order' Button Click event
    Private Sub ButtonAllOrder_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAllOrder.Click
        viewModel.getOrderListFromModel()
    End Sub
    'Testing input
    Private Sub Testing(input As String)
        MessageBox.Show(input)
    End Sub

End Class
