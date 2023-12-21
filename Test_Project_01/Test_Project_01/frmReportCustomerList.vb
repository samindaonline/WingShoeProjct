Public Class frmReportCustomerList

    Private Sub frmReportCustomerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'wing_shoeDataSet.tblCustomer' table. You can move, or remove it, as needed.
        Me.tblCustomerTableAdapter.Fill(Me.wing_shoeDataSet.tblCustomer)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class