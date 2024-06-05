Imports SOMS.Models
Imports SOMS.ViewModels

Public Class salesPageView
    Dim viewModel = salesPageViewModel.GetInstance

    Public Sub New()
        InitializeComponent()
        Me.DataContext = viewSales()
    End Sub
    'UC001 - Read sales list from Model
    Public Function viewSales() As salesPageViewModel
        viewModel.getAllSalesFromModel()
        summarySalesTotal()
        Return viewModel
    End Function

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
