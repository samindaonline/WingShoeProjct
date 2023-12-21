Imports System.Data.OleDb


Public Class frmDashboard

    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        Dim frmMain As New frmMain
        frmMain.MdiParent = frmMainDashboard
        frmMain.Show()
    End Sub

    Private Sub btnViewOrderHistory_Click(sender As Object, e As EventArgs) Handles btnViewOrderHistory.Click
        Dim frmOrderHistory As New frmReportOrderHistory
        frmOrderHistory.MdiParent = frmMainDashboard
        frmOrderHistory.Show()
    End Sub

    Private Sub btnEditOrder_Click(sender As Object, e As EventArgs) Handles btnEditOrder.Click
        Dim frmViewOrder As New frmViewOrder
        frmViewOrder.MdiParent = frmMainDashboard
        frmViewOrder.Show()
    End Sub

    Private Sub btnUpCustomer_Click(sender As Object, e As EventArgs) Handles btnUpCustomer.Click
        Dim frmCustomerUpdate As New frmCustomerUpdate
        frmCustomerUpdate.MdiParent = frmMainDashboard
        frmCustomerUpdate.Show()
    End Sub

    Private Sub btnViewCus_Click(sender As Object, e As EventArgs) Handles btnViewCus.Click
        Dim frmCustomerList As New frmReportCustomerList
        frmCustomerList.MdiParent = frmMainDashboard
        frmCustomerList.Show()
    End Sub

    Private Sub btnUpInventory_Click(sender As Object, e As EventArgs) Handles btnUpInventory.Click
        Dim frmViewInventory As New frmViewInventory
        frmViewInventory.MdiParent = frmMainDashboard
        frmViewInventory.Show()
    End Sub

    Private Sub btnInventoryReport_Click(sender As Object, e As EventArgs) Handles btnInventoryReport.Click
        Dim frmInventory As New frmReportInventory
        frmInventory.MdiParent = frmMainDashboard
        frmInventory.Show()
    End Sub

    Private Sub frmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Interval = 100

        'If Module1.user = "cashier" Then
        '    btnUpInventory.Enabled = False
        '    btnUpInventory.BackColor = Color.Gray
        'ElseIf Module1.user = "storekeeper" Then
        '    btnNewOrder.Enabled = False
        '    btnUpCustomer.Enabled = False
        '    btnViewCus.Enabled = False
        '    btnViewOrderHistory.Enabled = False
        '    btnEditOrder.Enabled = False
        '    btnNewOrder.BackColor = Color.Gray
        '    btnUpCustomer.BackColor = Color.Gray
        '    btnViewCus.BackColor = Color.Gray
        '    btnViewOrderHistory.BackColor = Color.Gray
        '    btnEditOrder.BackColor = Color.Gray
        'End If
        shoeSuggest()
    End Sub



    Private Sub txtShoeSearch_Enter(sender As Object, e As EventArgs) Handles txtShoeSearch.Enter
        txtShoeSearch.Clear()
        txtShoeSearch.ForeColor = Color.Black

    End Sub

    Sub shoeSuggest()
        Dim dsShoe2 As New DataSet
        Dim adShoe2 As New OleDbDataAdapter
        Dim nShoe2 As Integer
        Dim AutoComp As New AutoCompleteStringCollection()
        con.Open()
        Dim cmShoe As New OleDbCommand
        cmShoe.Connection = con
        cmShoe.CommandText = "SELECT * FROM tblShoe"
        adShoe2.SelectCommand = cmShoe
        adShoe2.Fill(dsShoe2, "Shoe")
        nShoe2 = dsShoe2.Tables("Shoe").Rows.Count - 1
        con.Close()
        For i As Integer = 0 To dsShoe2.Tables(0).Rows.Count - 1
            AutoComp.Add(dsShoe2.Tables(0).Rows(i)(0).ToString())
        Next
        txtShoeSearch.AutoCompleteMode = AutoCompleteMode.Suggest
        txtShoeSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtShoeSearch.AutoCompleteCustomSource = AutoComp
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Module1.strShoeSearch = txtShoeSearch.Text
        Dim frmShoeSearch As New frmShoeSearch
        frmShoeSearch.ShowDialog()

    End Sub

    Private Sub btnSignOut_Click(sender As Object, e As EventArgs)
        Me.Hide()
        Dim frmlogin As New frmLogin
        frmlogin.ShowDialog()
        Me.Close()
    End Sub

    Private Sub txtShoeSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtShoeSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Module1.strShoeSearch = txtShoeSearch.Text
            Dim frmShoeSearch As New frmShoeSearch
            frmShoeSearch.ShowDialog()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Module1.user = "cashier" Then
            btnNewOrder.Enabled = True
            btnEditOrder.Enabled = True
            btnViewOrderHistory.Enabled = True
            btnUpInventory.Enabled = False
            btnInventoryReport.Enabled = True
            btnUpCustomer.Enabled = True
            btnViewCus.Enabled = True

            btnNewOrder.BackColor = Color.FromArgb(240, 55, 60)
            btnEditOrder.BackColor = Color.FromArgb(240, 55, 60)
            btnViewOrderHistory.BackColor = Color.FromArgb(240, 55, 60)
            btnUpInventory.BackColor = Color.LightGray
            btnInventoryReport.BackColor = Color.FromArgb(31, 194, 154)
            btnUpCustomer.BackColor = Color.FromArgb(45, 170, 244)
            btnViewCus.BackColor = Color.FromArgb(45, 170, 244)
        ElseIf Module1.user = "storekeeper" Then
            btnNewOrder.Enabled = False
            btnEditOrder.Enabled = False
            btnViewOrderHistory.Enabled = False
            btnUpInventory.Enabled = True
            btnInventoryReport.Enabled = True
            btnUpCustomer.Enabled = False
            btnViewCus.Enabled = False

            btnNewOrder.BackColor = Color.LightGray
            btnEditOrder.BackColor = Color.LightGray
            btnViewOrderHistory.BackColor = Color.LightGray
            btnUpInventory.BackColor = Color.FromArgb(31, 194, 154)
            btnInventoryReport.BackColor = Color.FromArgb(31, 194, 154)
            btnUpCustomer.BackColor = Color.LightGray
            btnViewCus.BackColor = Color.LightGray
        ElseIf Module1.user = "admin" Then
            btnNewOrder.Enabled = True
            btnEditOrder.Enabled = True
            btnViewOrderHistory.Enabled = True
            btnUpInventory.Enabled = True
            btnInventoryReport.Enabled = True
            btnUpCustomer.Enabled = True
            btnViewCus.Enabled = True

            btnNewOrder.BackColor = Color.FromArgb(240, 55, 60)
            btnEditOrder.BackColor = Color.FromArgb(240, 55, 60)
            btnViewOrderHistory.BackColor = Color.FromArgb(240, 55, 60)
            btnUpInventory.BackColor = Color.FromArgb(31, 194, 154)
            btnInventoryReport.BackColor = Color.FromArgb(31, 194, 154)
            btnUpCustomer.BackColor = Color.FromArgb(45, 170, 244)
            btnViewCus.BackColor = Color.FromArgb(45, 170, 244)
        Else
            btnNewOrder.Enabled = False
            btnEditOrder.Enabled = False
            btnViewOrderHistory.Enabled = False
            btnUpInventory.Enabled = False
            btnInventoryReport.Enabled = False
            btnUpCustomer.Enabled = False
            btnViewCus.Enabled = False

            btnNewOrder.BackColor = Color.LightGray
            btnEditOrder.BackColor = Color.LightGray
            btnViewOrderHistory.BackColor = Color.LightGray
            btnUpInventory.BackColor = Color.LightGray
            btnInventoryReport.BackColor = Color.LightGray
            btnUpCustomer.BackColor = Color.LightGray
            btnViewCus.BackColor = Color.LightGray
        End If
    End Sub

    Private Sub txtShoeSearch_TextChanged(sender As Object, e As EventArgs) Handles txtShoeSearch.TextChanged
        Dim a As String
        a = txtShoeSearch.Text
        If txtShoeSearch.Text = "" Then
            txtShoeSearch.Text = ""
            a = ""
            txtShoeSearch.Focus()
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtShoeSearch.Text, "^[A-Za-z0-9\s]+$") = False Then
            MessageBox.Show("Please enter Desin ID", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtShoeSearch.Text = txtShoeSearch.Text.Remove(txtShoeSearch.Text.Length - 1)
            txtShoeSearch.SelectionStart = txtShoeSearch.Text.Length
        End If

    End Sub
End Class