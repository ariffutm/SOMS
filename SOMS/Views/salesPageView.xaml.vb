Imports Microsoft.SqlServer
Imports SOMS.ViewModels

Public Class salesPageView
    Dim viewModel = salesPageViewModel.GetInstance

    Public Sub New()
        InitializeComponent()
        Me.DataContext = viewSales()
        summarySalesTotal()
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
    ''Sales Total UI Format
    Public Sub summarySalesTotal()
        TxtBxSum.Text = Format(viewModel.sum, "0.00")
    End Sub
    'Handle Generate Report Button Click - UC 002 Generate Report
    Private Sub ButtonReport_Click(sender As Object, e As RoutedEventArgs) Handles ButtonReport.Click
        makeReport()
    End Sub

    'Sub-fucntion
    'Display Sales Report Function
    Private Sub makeReport()
        Dim report As New salesReport
        Dim print As New PrintDialog()

        report.dateFrom.Text = TxtBxDateFrom.Text
        report.dateTo.Text = TxtBxDateTo.Text
        report.salesAmount.Text = TxtBxSum.Text
        report.DataGridSales.ItemsSource = DataGridSales.ItemsSource
        report.Show()

        'If print.ShowDialog() = True Then
        print.PrintVisual(report, "Sales Report")
        'End If
    End Sub
End Class
