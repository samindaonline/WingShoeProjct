Public Class frmReportOrderHistory

    Private Sub frmReportOrderHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class