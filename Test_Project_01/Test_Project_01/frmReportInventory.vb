Public Class frmReportInventory

    Private Sub frmReportInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'wing_shoeDataSet.tblShoe' table. You can move, or remove it, as needed.
        Me.tblShoeTableAdapter.Fill(Me.wing_shoeDataSet.tblShoe)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class