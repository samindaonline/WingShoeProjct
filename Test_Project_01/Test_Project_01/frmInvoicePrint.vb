Imports Microsoft.Reporting.WinForms

Public Class frmInvoicePrint
    Public invoice As String
    Public cashier As String
    Public total As Double
    Public balance As Double
    Public cash As Double
    Public time As String
    Public customer As String

    Private Sub frmInvoicePrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'wing_shoeDataSet.tblContain' table. You can move, or remove it, as needed.
        Me.tblContainTableAdapter.Fill(Me.wing_shoeDataSet.tblContain)
        'TODO: This line of code loads data into the 'wing_shoeDataSet.tblOrder' table. You can move, or remove it, as needed.
        Me.tblOrderTableAdapter.Fill(Me.wing_shoeDataSet.tblOrder)
        'TODO: This line of code loads data into the 'wing_shoeDataSet.tblCustomer' table. You can move, or remove it, as needed.
        Me.tblCustomerTableAdapter.Fill(Me.wing_shoeDataSet.tblCustomer)
        'TODO: This line of code loads data into the 'wing_shoeDataSet.tblShoe' table. You can move, or remove it, as needed.
        Me.tblShoeTableAdapter.Fill(Me.wing_shoeDataSet.tblShoe)
        'TODO: This line of code loads data into the 'wing_shoeDataSet.qryBill' table. You can move, or remove it, as needed.
        Me.qryBillTableAdapter.Fill(Me.wing_shoeDataSet.qryBill)

        Dim parameters As IList(Of ReportParameter) = New List(Of ReportParameter)
        parameters.Add(New ReportParameter("InvoiceNumber", invoice))
        parameters.Add(New ReportParameter("Cashier", cashier))
        parameters.Add(New ReportParameter("Total", total))
        parameters.Add(New ReportParameter("Cash", cash))
        parameters.Add(New ReportParameter("Balance", balance))
        parameters.Add(New ReportParameter("Customer", customer))
        ReportViewer1.LocalReport.SetParameters(parameters)


        Me.ReportViewer1.RefreshReport()
    End Sub
End Class