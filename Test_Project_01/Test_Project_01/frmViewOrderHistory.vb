Public Class frmViewOrderHistory

    Private Sub frmViewOrderHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'wing_shoeDataSet.tblOrder' table. You can move, or remove it, as needed.
        Me.tblOrderTableAdapter.Fill(Me.wing_shoeDataSet.tblOrder)

        Me.ReportViewer1.RefreshReport()
    End Sub
End Class