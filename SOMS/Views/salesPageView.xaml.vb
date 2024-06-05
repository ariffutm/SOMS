Imports SOMS.Models
Imports SOMS.ViewModels

Public Class salesPageView
    Dim viewModel = salesPageViewModel.GetInstance

    Public Sub New()
        InitializeComponent()
        Me.DataContext = viewSales()
        TxtBxSum.Text = Format(viewModel.sum, "0.00")
    End Sub
    'UC001 - Read
    ''All sales list from Model
    Public Function viewSales() As salesPageViewModel
        viewModel.getAllSalesFromModel()
        Return viewModel
    End Function
    ''Sales List By Date
    Private Sub ButtonFind_Click(sender As Object, e As RoutedEventArgs) Handles ButtonFind.Click
        viewModel.filterDate(TxtBxDateFrom.Text, TxtBxDateTo.Text)
        summarySalesTotal()
    End Sub
    'UI Control
    ''Sales Total Calculation
    Public Sub summarySalesTotal()
        Dim sum As Double = 0
        For Each row As Sales In DataGridSales.ItemsSource
            sum += Double.Parse(row.Amount)
        Next
        TxtBxSum.Text = Format(sum, "0.00")
    End Sub
End Class
