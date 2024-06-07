Public Class Receipt
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub
    Private Sub ButtonReceipt_Click(sender As Object, e As RoutedEventArgs) Handles ButtonReceipt.Click
        Dim window As New Receipt()
        window.Show()
        Dim pd As New PrintDialog()
        pd.PrintVisual(window, "MyForm")
    End Sub
End Class
