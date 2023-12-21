Imports System.Data.OleDb
Public Class frmTest
    Public strTest1, strTest2 As String
    Dim dsShoe As New DataSet
    Dim adShoe As New OleDbDataAdapter
    Dim nShoe As Integer

   

    Private Sub btnShoeSearch_Click(sender As Object, e As EventArgs) Handles btnShoeSearch.Click
        Dim tbShoe As DataTable
        Dim dcPrimaryKey1(1) As DataColumn
        tbShoe = dsShoe.Tables("shoe")
        dcPrimaryKey1(0) = tbShoe.Columns("sDesignID")
        dcPrimaryKey1(1) = tbShoe.Columns("sSize")
        tbShoe.PrimaryKey = dcPrimaryKey1

        Dim strDesID, strSize As String
        strDesID = txtShoeSeach.Text
        strSize = txtSearchSize.Text
        'Dim frmTest As New frmTest
        'frmTest.ShowDialog()
        'strDesID = frmTest.strTest1
        'strSize = frmTest.strTest2

        If Not strDesID Is Nothing Or Not strSize Is Nothing Then
            Dim drCustomer As DataRow
            drCustomer = tbShoe.Rows.Find({strDesID, strSize})
            If Not drCustomer Is Nothing Then
                With drCustomer
                    txtShoeDesignID.Text = .Item("sDesignID")
                    txtShoesName.Text = .Item("sName")
                    txtShoesQuantity.Text = .Item("sQuantity")
                    txtShoesSize.Text = .Item("sSize")
                    txtShoesUnitPrice.Text = .Item("sUnitPrice")
                End With
            Else
                MessageBox.Show("Not Found...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub frmTest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim cmShoe As New OleDbCommand
        Dim cmCustomer As New OleDbCommand
        cmShoe.Connection = con
        cmCustomer.Connection = con
        cmShoe.CommandText = "SELECT * FROM tblShoe"
        cmCustomer.CommandText = "SELECT * FROM tblCustomer"
        adShoe.SelectCommand = cmShoe
        adShoe.Fill(dsShoe, "shoe")
        nShoe = dsShoe.Tables("shoe").Rows.Count - 1
        con.Close()
        frmMain.DataGridView1.ColumnCount = 6
    End Sub

    Private Sub btnAddtoOrder_Click(sender As Object, e As EventArgs) Handles btnAddtoOrder.Click

        'str = New String() {txtShoeDesignID.Text, txtShoesName.Text, txtShoesSize.Text, txtSDQty.Text, txtShoesUnitPrice.Text, txtSDSubtotal.Text}
        frmMain.DataGridView1.Rows.Add(txtShoeDesignID.Text, txtShoesName.Text, txtShoesSize.Text, txtSDQty.Text, txtShoesUnitPrice.Text, txtSDSubtotal.Text)
    End Sub
End Class