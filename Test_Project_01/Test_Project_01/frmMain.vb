Imports System.Data.OleDb
Public Class frmMain
    'v3.0.230519

    Public dsShoe As New DataSet
    Public adShoe As New OleDbDataAdapter
    Public nShoe As Integer
    Dim dsCustomer As New DataSet
    Dim dsContain As New DataSet
    Dim dsOrder As New DataSet
    Dim adCustomer As New OleDbDataAdapter
    Dim adContain As New OleDbDataAdapter
    Dim adOrder As New OleDbDataAdapter
    Dim nCustomer, nContain, nOrder As Integer
    Public strInvNo, strInvNo1 As String
    Dim intPrintCount As Integer = 0

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If intPrintCount <> 1 Then
        '    con.Open()
        '    Dim cmShoe As New OleDbCommand
        '    cmShoe.Connection = con
        '    cmShoe.CommandText = "SELECT * FROM tblShoe"
        '    adShoe.SelectCommand = cmShoe
        '    adShoe.Fill(dsShoe, "shoe")
        '    nShoe = dsShoe.Tables("shoe").Rows.Count - 1
        '    con.Close()

        '    If DataGridView1.Rows.Count >= 0 Then
        '        For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '            Dim cmBuild As New OleDbCommandBuilder
        '            cmBuild.DataAdapter = adShoe
        '            Dim tbEdit As DataTable
        '            Dim dcPrimaryKey(1) As DataColumn
        '            tbEdit = dsShoe.Tables("shoe")
        '            dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
        '            dcPrimaryKey(1) = tbEdit.Columns("sSize")
        '            tbEdit.PrimaryKey = dcPrimaryKey
        '            Dim drEdit As DataRow = tbEdit.Rows.Find({CStr(DataGridView1.Rows(0).Cells(0).Value), CStr(DataGridView1.Rows(0).Cells(2).Value)})
        '            With drEdit
        '                .Item("sQuantity") = Val(.Item("sQuantity")) + Val(DataGridView1.Rows(0).Cells(3).Value)
        '            End With
        '            adShoe.UpdateCommand = cmBuild.GetUpdateCommand

        '            con.Open()
        '            Try
        '                adShoe.Update(dsShoe, ("shoe"))
        '            Catch ex As Exception
        '                MessageBox.Show("You are trying to save data incorrectly...")
        '            End Try
        '            con.Close()
        '            DataGridView1.Rows.Remove(DataGridView1.Rows(0))
        '        Next
        '    End If
        'End If

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Timer1.Interval = 100

        con.Open()
        Dim cmContain, cmOrder As New OleDbCommand
        cmContain.Connection = con
        cmOrder.Connection = con
        cmContain.CommandText = "SELECT * FROM tblContain"
        cmOrder.CommandText = "SELECT * FROM tblOrder"
        adContain.SelectCommand = cmContain
        adOrder.SelectCommand = cmOrder
        adContain.Fill(dsContain, "contain")
        adOrder.Fill(dsOrder, "order")
        nContain = dsContain.Tables("contain").Rows.Count - 1
        nOrder = dsOrder.Tables("order").Rows.Count - 1
        con.Close()

        con.Open()
        Dim cmShoe As New OleDbCommand
        cmShoe.Connection = con
        cmShoe.CommandText = "SELECT * FROM tblShoe"
        Module1.adShoe.SelectCommand = cmShoe
        Module1.adShoe.Fill(Module1.dsShoe, "shoe")
        Module1.nShoe = Module1.dsShoe.Tables("shoe").Rows.Count - 1
        con.Close()

        DataGridView1.ColumnCount = 6
        DataGridView1.Columns(0).Name = "Design ID"
        DataGridView1.Columns(1).Name = "Design Name"
        DataGridView1.Columns(2).Name = "Size"
        DataGridView1.Columns(3).Name = "Qty"
        DataGridView1.Columns(4).Name = "Unit Price(Rs.)"
        DataGridView1.Columns(5).Name = "SubTotal(Rs.)"
        DataGridView1.Columns(0).Width = 70
        DataGridView1.Columns(1).Width = 244
        DataGridView1.Columns(2).Width = 70
        DataGridView1.Columns(3).Width = 66
        DataGridView1.Columns(4).Width = 90
        DataGridView1.Columns(5).Width = 90
        invoiceNumber()

        radODNormal.Checked = True

        txtShoeSeach.Text = ""
        txtCustomerSearch.Text = ""
        txtCustomerSearch.TabIndex = "0"
        txtCustomerSearch.Focus()
        ShoeSearch()
        CustomerSearch()
    End Sub

    Sub invoiceNumber()
        Dim drOrder As DataRow
        If nOrder >= 0 Then
            drOrder = dsOrder.Tables("order").Rows(nOrder)
            strInvNo = drOrder.Item("oID")
        End If
        strInvNo1 = strInvNo.Substring(0, 3) & Format(strInvNo.Substring(3, 3) + 1, "000")
        txtInvNo.Text = strInvNo1
    End Sub

    Private Sub btnCustomerSearch_Click(sender As Object, e As EventArgs) Handles btnCustomerSearch.Click
        con.Open()
        Dim cmCustomer As New OleDbCommand
        cmCustomer.Connection = con
        cmCustomer.CommandText = "SELECT * FROM tblCustomer"
        adCustomer.SelectCommand = cmCustomer
        adCustomer.Fill(dsCustomer, "customer")
        nCustomer = dsCustomer.Tables("customer").Rows.Count - 1
        con.Close()

        If (txtCustomerSearch.Text).Length <> 10 Or (txtCustomerSearch.Text).Substring(0, 1) <> "0" Or IsNumeric(txtCustomerSearch.Text) = False Then
            If (txtCustomerSearch.Text).Length <> 10 Then
                MessageBox.Show("Please enter a 10 Digit Telephone Number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If (txtCustomerSearch.Text).Substring(0, 1) <> "0" Then
                MessageBox.Show("Please enter telephone number with zero (i.e- 045 000 0000)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            If IsNumeric(txtCustomerSearch.Text) = False Then
                MessageBox.Show("Please enter valid telephone number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            txtCustomerSearch.BackColor = Color.Pink
        Else
            Dim tbCustomer As DataTable
            Dim dcPrimaryKey(0) As DataColumn
            tbCustomer = dsCustomer.Tables("customer")
            dcPrimaryKey(0) = tbCustomer.Columns("cTP")
            tbCustomer.PrimaryKey = dcPrimaryKey
            Dim strNo As String
            strNo = txtCustomerSearch.Text
            If Not strNo Is Nothing Then
                Dim drCustomer As DataRow
                drCustomer = tbCustomer.Rows.Find(strNo)
                If Not drCustomer Is Nothing Then
                    With drCustomer
                        txtCustomerName.Text = .Item("cName")
                        txtCustomerAddress.Text = .Item("cAddress")
                    End With
                Else
                    MessageBox.Show("Customer TP number is not in the Database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub btnAddtoOrder_Click(sender As Object, e As EventArgs) Handles btnAddtoOrder.Click
        Module1.str(0) = "0"
        If System.Text.RegularExpressions.Regex.IsMatch(txtShoeSeach.Text, "^[A-Za-z0-9]+$") = False Then
            MessageBox.Show("Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Module1.strShoeSearch = txtShoeSeach.Text

            Dim frmItemAdd As New frmItemAdd
            frmItemAdd.ShowDialog()
            'MessageBox.Show(Module1.str(0))

            'Dim a As Boolean
            'If Module1.str(0) = "0" Then
            '    a = True
            'Else
            '    a = False
            'End If
            'MessageBox.Show(a)

            If Module1.str(0) = "0" Then
                MessageBox.Show("You didn't Select Any item to add to the order", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Else
                Try
                    Dim n As Integer = 0
                    If 1 <= DataGridView1.Rows.Count Then
                        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                            If Module1.str(0) = CStr(DataGridView1.Rows(i).Cells(0).Value) And Module1.str(2) = CStr(DataGridView1.Rows(i).Cells(2).Value) Then
                                DataGridView1.Rows(i).Cells(3).Value = Val(DataGridView1.Rows(i).Cells(3).Value) + Val(Module1.str(3))
                                n = n + 1
                            End If
                        Next
                        If n = 0 Then
                            DataGridView1.Rows.Add(Module1.str)
                        End If
                    Else
                        DataGridView1.Rows.Add(Module1.str)
                    End If
                Catch ex As Exception
                    MessageBox.Show("You didn't Select Any item to add to the order", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End If

            'For Each rowX As DataGridViewRow In DataGridView1.Rows
            '    rowX.Cells(5).Value = Val(rowX.Cells(3).Value) * Val(rowX.Cells(4).Value)
            'Next
            'Dim tot, tot2 As Double
            'If radODNormal.Checked = True Then
            '    For Each row As DataGridViewRow In DataGridView1.Rows
            '        If IsNumeric(row.Cells(5).Value) Then
            '            tot += Val(row.Cells(5).Value)
            '        End If
            '    Next
            '    txtTotal.Text = tot
            'ElseIf radODWholeSale.Checked = True Then
            '    For Each row As DataGridViewRow In DataGridView1.Rows
            '        If IsNumeric(row.Cells(5).Value) Then
            '            tot += Val(row.Cells(5).Value)
            '        End If
            '    Next
            '    tot2 = tot * 0.8
            '    txtTotal.Text = tot2
            'End If
        End If

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        'con.Open()
        'Dim cmShoe As New OleDbCommand
        'cmShoe.Connection = con
        'cmShoe.CommandText = "SELECT * FROM tblShoe"
        'adShoe.SelectCommand = cmShoe
        'adShoe.Fill(dsShoe, "shoe")
        'nShoe = dsShoe.Tables("shoe").Rows.Count - 1
        'con.Close()

        If DataGridView1.SelectedRows.Count > 0 Then
            Dim cmBuild As New OleDbCommandBuilder
            cmBuild.DataAdapter = Module1.adShoe
            Dim tbEdit As DataTable
            Dim dcPrimaryKey(1) As DataColumn
            tbEdit = Module1.dsShoe.Tables("shoe")
            dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
            dcPrimaryKey(1) = tbEdit.Columns("sSize")
            tbEdit.PrimaryKey = dcPrimaryKey
            Dim drEdit As DataRow = tbEdit.Rows.Find({DataGridView1.SelectedRows(0).Cells(0).Value, DataGridView1.SelectedRows(0).Cells(2).Value})
            With drEdit
                .Item("sQuantity") = .Item("sQuantity") + Val(DataGridView1.SelectedRows(0).Cells(3).Value)
            End With
            Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand

            'con.Open()
            'Try
            '    adShoe.Update(dsShoe, ("shoe"))
            'Catch ex As Exception
            '    MessageBox.Show("You are trying to save data incorrectly...")
            'End Try
            'con.Close()

            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            'For Each rowX As DataGridViewRow In DataGridView1.Rows
            '    rowX.Cells(5).Value = Val(rowX.Cells(3).Value) * Val(rowX.Cells(4).Value)
            'Next
            'Dim tot, tot2 As Double
            'If radODNormal.Checked = True Then
            '    For Each row As DataGridViewRow In DataGridView1.Rows
            '        If IsNumeric(row.Cells(5).Value) Then
            '            tot += Val(row.Cells(5).Value)
            '        End If
            '    Next
            '    txtTotal.Text = tot
            'ElseIf radODWholeSale.Checked = True Then
            '    For Each row As DataGridViewRow In DataGridView1.Rows
            '        If IsNumeric(row.Cells(5).Value) Then
            '            tot += Val(row.Cells(5).Value)
            '        End If
            '    Next
            '    tot2 = tot * 0.8
            '    txtTotal.Text = tot2
            'End If
        Else
            MessageBox.Show("Select 1 row before you hit Delete", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    'Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    '    For Each rowX As DataGridViewRow In DataGridView1.Rows
    '        rowX.Cells(5).Value = rowX.Cells(3).Value * rowX.Cells(4).Value
    '    Next
    '    Dim tot, tot2 As Double
    '    If radODNormal.Checked = True Then
    '        For Each row As DataGridViewRow In DataGridView1.Rows
    '            If IsNumeric(row.Cells(5).Value) Then
    '                tot += Val(row.Cells(5).Value)
    '            End If
    '        Next
    '        Label9.Text = tot
    '    ElseIf radODSpecial.Checked = True Then
    '        For Each row As DataGridViewRow In DataGridView1.Rows
    '            If IsNumeric(row.Cells(5).Value) Then
    '                tot += Val(row.Cells(5).Value)
    '            End If
    '        Next
    '        Label9.Text = tot
    '    ElseIf radODWholeSale.Checked = True Then
    '        For Each row As DataGridViewRow In DataGridView1.Rows
    '            If IsNumeric(row.Cells(5).Value) Then
    '                tot += Val(row.Cells(5).Value)
    '            End If
    '        Next
    '        tot2 = tot * 0.8
    '        Label9.Text = tot2
    '    End If
    'End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If txtCustomerName.Text = "" Then
            MessageBox.Show("Please Enter a Customer Detail!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCustomerSearch.Focus()
        ElseIf txtCash.Text = "" Then
            MessageBox.Show("Please Enter Cash amount", "Information Missing!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCash.Focus()
        Else
            If DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To DataGridView1.RowCount - 1
                    Dim cmBuild As New OleDbCommandBuilder
                    cmBuild.DataAdapter = adContain
                    Dim drSave As DataRow
                    drSave = dsContain.Tables("contain").NewRow
                    With drSave
                        .Item("oID") = txtInvNo.Text
                        .Item("sDesignID") = DataGridView1.Rows(i).Cells(0).Value
                        .Item("sSize") = DataGridView1.Rows(i).Cells(2).Value
                        .Item("sQuantity") = DataGridView1.Rows(i).Cells(3).Value
                        .Item("TotalAmount") = DataGridView1.Rows(i).Cells(5).Value
                    End With
                    dsContain.Tables("contain").Rows.Add(drSave)
                    adContain.InsertCommand = cmBuild.GetInsertCommand

                Next

                Dim orderType As String = "Noramal"
                If radODNormal.Checked = True Then
                    orderType = "Normal"
                ElseIf radODWholeSale.Checked = True Then
                    orderType = "Whole Sale"
                End If

                Dim cmBuild2 As New OleDbCommandBuilder
                cmBuild2.DataAdapter = adOrder

                Dim drSave2 As DataRow
                drSave2 = dsOrder.Tables("order").NewRow
                With drSave2
                    .Item("oID") = txtInvNo.Text
                    .Item("oType") = orderType
                    .Item("oDate") = Date.Today.ToString("dd'/'MM'/'yyyy")
                    .Item("oAmount") = txtTotal.Text
                    .Item("cTP") = txtCustomerSearch.Text
                End With
                dsOrder.Tables("order").Rows.Add(drSave2)
                adOrder.InsertCommand = cmBuild2.GetInsertCommand

                If txtInvNo.Text = "" Or txtCustomerSearch.Text = "" Then
                    If txtInvNo.Text = "" Then
                        MessageBox.Show("Please Enter Invoice Number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    If txtCustomerSearch.Text = "" Then
                        MessageBox.Show("Please Enter Customer", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    con.Open()
                    Try
                        adContain.Update(dsContain, ("contain"))
                        adOrder.Update(dsOrder, ("order"))
                    Catch ex As Exception
                        MessageBox.Show("You are trying to save data incorrectly.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                    con.Close()

                    con.Open()
                    Try
                        Module1.adShoe.Update(Module1.dsShoe, ("shoe"))
                    Catch ex As Exception
                        MessageBox.Show("You are trying to save data incorrectly.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                    con.Close()

                    intPrintCount = 1
                    Dim frmInvoicePrint As New frmInvoicePrint
                    frmInvoicePrint.invoice = txtInvNo.Text
                    frmInvoicePrint.cashier = Module1.user
                    frmInvoicePrint.cash = Val(txtCash.Text)
                    frmInvoicePrint.balance = Val(txtBalance.Text)
                    frmInvoicePrint.total = Val(txtTotal.Text)
                    frmInvoicePrint.customer = txtCustomerName.Text
                    frmInvoicePrint.ShowDialog()
                    Me.Close()
                End If
            Else
                MessageBox.Show("Please Enter Order items to print", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If


    End Sub

    'Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
    '    con.Open()
    '    Dim cmShoe As New OleDbCommand
    '    cmShoe.Connection = con
    '    cmShoe.CommandText = "SELECT * FROM tblShoe"
    '    adShoe.SelectCommand = cmShoe
    '    adShoe.Fill(dsShoe, "shoe")
    '    nShoe = dsShoe.Tables("shoe").Rows.Count - 1
    '    con.Close()
    '    Dim value As Double

    '    Dim cmBuild As New OleDbCommandBuilder
    '    cmBuild.DataAdapter = adShoe
    '    Dim tbEdit As DataTable
    '    Dim dcPrimaryKey(1) As DataColumn
    '    tbEdit = dsShoe.Tables("shoe")
    '    dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
    '    dcPrimaryKey(1) = tbEdit.Columns("sSize")
    '    tbEdit.PrimaryKey = dcPrimaryKey
    '    Dim drEdit As DataRow = tbEdit.Rows.Find({DataGridView1.SelectedRows(0).Cells(0).Value, DataGridView1.SelectedRows(0).Cells(2).Value})
    '    With drEdit
    '        value = Val(.Item("sQuantity"))
    '    End With
    '    '.Item("sQuantity") + Val(DataGridView1.SelectedRows(0).Cells(3).Value)
    '    'txtTest.Text = value
    '    If value >= Val(DataGridView1.SelectedRows(0).Cells(3).Value) Then
    '        txtTest.Text = "Instock"
    '    Else
    '        txtTest.Text = "Out of stock"
    '    End If

    'End Sub

    Private Sub btnAddCustomer_Click(sender As Object, e As EventArgs) Handles btnAddCustomer.Click
        frmCustomerUpdate.ShowDialog()
    End Sub

    Private Sub btnShoeInven_Click(sender As Object, e As EventArgs)
        frmViewInventory.ShowDialog()
    End Sub

    Private Sub txtShoeSeach_Enter(sender As Object, e As EventArgs) Handles txtShoeSeach.Enter
        txtShoeSeach.BackColor = Color.White
    End Sub

    Private Sub txtCustomerSearch_Enter(sender As Object, e As EventArgs) Handles txtCustomerSearch.Enter
        txtCustomerSearch.BackColor = Color.White
    End Sub

    Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged
        Dim a As String
        a = txtCash.Text

        If a = "" Then
            txtCash.Text = ""
            txtBalance.Text = ""
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(a, "^[0-9]+$") = False Then
            Dim count, rempos As Integer
            Dim sb As New System.Text.StringBuilder
            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[0-9]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtCash.Text = a
            If txtCash.Text.Length > 0 Then
                txtCash.SelectionStart = rempos - 1
                txtCash.SelectionLength = 0
            Else
                txtCash.SelectionStart = txtCash.Text.Length
            End If
            MessageBox.Show("Special Characters and numbers are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            txtBalance.Text = Val(txtCash.Text) - Val(txtTotal.Text)
        End If
        txtCash.SelectionStart = txtCash.Text.Length

    End Sub

    Private Sub txtCustomerSearch_Leave(sender As Object, e As EventArgs) Handles txtCustomerSearch.Leave
        'con.Open()
        'Dim cmCustomer As New OleDbCommand
        'cmCustomer.Connection = con
        'cmCustomer.CommandText = "SELECT * FROM tblCustomer"
        'adCustomer.SelectCommand = cmCustomer
        'adCustomer.Fill(dsCustomer, "customer")
        'nCustomer = dsCustomer.Tables("customer").Rows.Count - 1
        'con.Close()

        'If (txtCustomerSearch.Text).Length <> 10 Or (txtCustomerSearch.Text).Substring(0, 1) <> "0" Or IsNumeric(txtCustomerSearch.Text) = False Then
        '    If (txtCustomerSearch.Text).Length <> 10 Then
        '        MessageBox.Show("Please enter a 10 Digit Telephone Number")
        '    End If
        '    If (txtCustomerSearch.Text).Substring(0, 1) <> "0" Then
        '        MessageBox.Show("Please enter telephone number with zero (i.e- 045 000 0000)")
        '    End If
        '    If IsNumeric(txtCustomerSearch.Text) = False Then
        '        MessageBox.Show("Please enter valid telephone number")
        '    End If
        '    txtCustomerSearch.BackColor = Color.Pink
        'Else
        '    Dim tbCustomer As DataTable
        '    Dim dcPrimaryKey(0) As DataColumn
        '    tbCustomer = dsCustomer.Tables("customer")
        '    dcPrimaryKey(0) = tbCustomer.Columns("cTP")
        '    tbCustomer.PrimaryKey = dcPrimaryKey
        '    Dim strNo As String
        '    strNo = txtCustomerSearch.Text
        '    If Not strNo Is Nothing Then
        '        Dim drCustomer As DataRow
        '        drCustomer = tbCustomer.Rows.Find(strNo)
        '        If Not drCustomer Is Nothing Then
        '            With drCustomer
        '                txtCustomerName.Text = .Item("cName")
        '                txtCustomerAddress.Text = .Item("cAddress")
        '            End With
        '        Else
        '            MessageBox.Show("Customer TP number is not in the Database.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        'For Each rowX As DataGridViewRow In DataGridView1.Rows
        '    rowX.Cells(5).Value = Val(rowX.Cells(3).Value) * Val(rowX.Cells(4).Value)
        'Next
        'Dim tot, tot2 As Double
        'If radODNormal.Checked = True Then
        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If IsNumeric(row.Cells(5).Value) Then
        '            tot += Val(row.Cells(5).Value)
        '        End If
        '    Next
        '    txtTotal.Text = tot
        'ElseIf radODWholeSale.Checked = True Then
        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If IsNumeric(row.Cells(5).Value) Then
        '            tot += Val(row.Cells(5).Value)
        '        End If
        '    Next
        '    tot2 = tot * 0.8
        '    txtTotal.Text = tot2
        'End If
    End Sub
    
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        If DataGridView1.Rows.Count > 0 Then
            Module1.strIADesign = DataGridView1.SelectedRows(0).Cells(0).Value
            Module1.strIAName = DataGridView1.SelectedRows(0).Cells(1).Value
            Module1.strIASize = DataGridView1.SelectedRows(0).Cells(2).Value
            Module1.strIAQuantity = DataGridView1.SelectedRows(0).Cells(3).Value
            Module1.strIAUnitPrice = DataGridView1.SelectedRows(0).Cells(4).Value
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            Dim frmInvoiceEdit As New frmInvoiceEdit
            frmInvoiceEdit.ShowDialog()
            Try
                DataGridView1.Rows.Add(frmInvoiceEdit.str)
            Catch ex As Exception
                MessageBox.Show("You didn't Select Any item", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Else
            MessageBox.Show("Select a row to edit", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub btnRemoveAll_Click(sender As Object, e As EventArgs) Handles btnRemoveAll.Click
        'con.Open()
        'Dim cmShoe As New OleDbCommand
        'cmShoe.Connection = con
        'cmShoe.CommandText = "SELECT * FROM tblShoe"
        'adShoe.SelectCommand = cmShoe
        'adShoe.Fill(dsShoe, "shoe")
        'nShoe = dsShoe.Tables("shoe").Rows.Count - 1
        'con.Close()

        If DataGridView1.Rows.Count >= 0 Then
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim cmBuild As New OleDbCommandBuilder
                cmBuild.DataAdapter = Module1.adShoe
                Dim tbEdit As DataTable
                Dim dcPrimaryKey(1) As DataColumn
                tbEdit = Module1.dsShoe.Tables("shoe")
                dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
                dcPrimaryKey(1) = tbEdit.Columns("sSize")
                tbEdit.PrimaryKey = dcPrimaryKey
                Dim drEdit As DataRow = tbEdit.Rows.Find({CStr(DataGridView1.Rows(0).Cells(0).Value), CStr(DataGridView1.Rows(0).Cells(2).Value)})
                With drEdit
                    .Item("sQuantity") = Val(.Item("sQuantity")) + Val(DataGridView1.Rows(0).Cells(3).Value)
                End With
                Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand

                'con.Open()
                'Try
                '    adShoe.Update(dsShoe, ("shoe"))
                'Catch ex As Exception
                '    MessageBox.Show("You are trying to save data incorrectly...")
                'End Try
                'con.Close()
                DataGridView1.Rows.Remove(DataGridView1.Rows(0))
            Next
            'For Each rowX As DataGridViewRow In DataGridView1.Rows
            '    rowX.Cells(5).Value = Val(rowX.Cells(3).Value) * Val(rowX.Cells(4).Value)
            'Next
        End If

        'Dim tot, tot2 As Double
        'If radODNormal.Checked = True Then
        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If IsNumeric(row.Cells(5).Value) Then
        '            tot += Val(row.Cells(5).Value)
        '        End If
        '    Next
        '    txtTotal.Text = tot
        'ElseIf radODWholeSale.Checked = True Then
        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If IsNumeric(row.Cells(5).Value) Then
        '            tot += Val(row.Cells(5).Value)
        '        End If
        '    Next
        '    tot2 = tot * 0.8
        '    txtTotal.Text = tot2
        'End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If DataGridView1.Rows.Count > 0 Then
            Module1.strIADesign = DataGridView1.SelectedRows(0).Cells(0).Value
            Module1.strIAName = DataGridView1.SelectedRows(0).Cells(1).Value
            Module1.strIASize = DataGridView1.SelectedRows(0).Cells(2).Value
            Module1.strIAQuantity = DataGridView1.SelectedRows(0).Cells(3).Value
            Module1.strIAUnitPrice = DataGridView1.SelectedRows(0).Cells(4).Value
            DataGridView1.Rows.Remove(DataGridView1.SelectedRows(0))
            Dim frmInvoiceEdit As New frmInvoiceEdit
            frmInvoiceEdit.ShowDialog()
            Try
                DataGridView1.Rows.Add(frmInvoiceEdit.str)
            Catch ex As Exception
                MessageBox.Show("You didn't Select Any item", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        Else
            MessageBox.Show("Select a row to edit", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
   
    Private Sub txtCustomerSearch_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerSearch.TextChanged

StartPosition:
        Dim a As String
        a = txtCustomerSearch.Text

        If txtCustomerSearch.Text = "" Then
            txtCustomerSearch.Text = ""
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(a, "^[0-9]+$") = False Then
            Dim count, rempos As Integer
            Dim sb As New System.Text.StringBuilder
            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[0-9]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtCustomerSearch.Text = a
            If txtCustomerSearch.Text.Length > 0 Then
                txtCustomerSearch.SelectionStart = rempos - 1
                txtCustomerSearch.SelectionLength = 0
            Else
                txtCustomerSearch.SelectionStart = txtCustomerSearch.Text.Length
            End If
            MessageBox.Show("Letters and Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        If a.Length = 10 Then
            con.Open()
            Dim cmCustomer As New OleDbCommand
            cmCustomer.Connection = con
            cmCustomer.CommandText = "SELECT * FROM tblCustomer"
            adCustomer.SelectCommand = cmCustomer
            adCustomer.Fill(dsCustomer, "customer")
            nCustomer = dsCustomer.Tables("customer").Rows.Count - 1
            con.Close()

            Dim tbCustomer As DataTable
            Dim dcPrimaryKey(0) As DataColumn
            tbCustomer = dsCustomer.Tables("customer")
            dcPrimaryKey(0) = tbCustomer.Columns("cTP")
            tbCustomer.PrimaryKey = dcPrimaryKey
            Dim strNo As String
            strNo = txtCustomerSearch.Text
            If Not strNo Is Nothing Then
                Dim drCustomer As DataRow
                drCustomer = tbCustomer.Rows.Find(strNo)
                If Not drCustomer Is Nothing Then
                    With drCustomer
                        txtCustomerName.Text = .Item("cName")
                        txtCustomerAddress.Text = .Item("cAddress")
                    End With
                Else
                    Dim NewCus As String = MessageBox.Show("This phone number is not in the database. Do you want to add '" & txtCustomerSearch.Text & "' this phone number to the customer list? ", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If NewCus = vbYes Then
                        Module1.strNewTP = txtCustomerSearch.Text
                        Dim frmAddNewCustomer As New frmAddNewCustomer
                        frmAddNewCustomer.ShowDialog()
                        GoTo StartPosition
                    Else
                        txtCustomerSearch.Clear()
                    End If
                End If
            End If

        ElseIf (txtCustomerSearch.Text).Length > 10 Then
            MessageBox.Show("10 Digit Telephone Number only", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCustomerSearch.Text = txtCustomerSearch.Text.Remove(txtCustomerSearch.Text.Length - 1)
            txtCustomerSearch.Focus()
            txtCustomerSearch.SelectionStart = txtCustomerSearch.Text.Length
        ElseIf txtCustomerSearch.Text = "" Then
            txtCustomerName.Text = ""
            txtCustomerAddress.Text = ""
        ElseIf IsNumeric(txtCustomerSearch.Text) = False Then
            MessageBox.Show("Please enter valid telephone number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCustomerSearch.Text = txtCustomerSearch.Text.Remove(txtCustomerSearch.Text.Length - 1)
            txtCustomerSearch.Focus()
            txtCustomerSearch.SelectionStart = txtCustomerSearch.Text.Length
        ElseIf (txtCustomerSearch.Text).Substring(0, 1) <> "0" Then
            MessageBox.Show("Please enter telephone number with zero (i.e- 045 000 0000)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtCustomerSearch.Text = txtCustomerSearch.Text.Remove(txtCustomerSearch.Text.Length - 1)
            txtCustomerSearch.Focus()
            txtCustomerSearch.SelectionStart = txtCustomerSearch.Text.Length
        End If
    End Sub

    Sub ShoeSearch()
        Dim AutoComp As New AutoCompleteStringCollection()
        con.Open()
        Dim cmShoe As New OleDbCommand
        cmShoe.Connection = con
        cmShoe.CommandText = "SELECT * FROM tblShoe"
        adShoe.SelectCommand = cmShoe
        adShoe.Fill(dsShoe, "Shoe")
        nShoe = dsShoe.Tables("Shoe").Rows.Count - 1
        con.Close()
        For i As Integer = 0 To dsShoe.Tables(0).Rows.Count - 1
            AutoComp.Add(dsShoe.Tables(0).Rows(i)(0).ToString())
        Next
        txtShoeSeach.AutoCompleteMode = AutoCompleteMode.Suggest
        txtShoeSeach.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtShoeSeach.AutoCompleteCustomSource = AutoComp
    End Sub

    Sub CustomerSearch()
        Dim dssCustomer As New DataSet
        Dim adsCustomer As New OleDbDataAdapter
        Dim nsCustomer As Integer
        con.Open()
        Dim cmSCustomer As New OleDbCommand
        cmSCustomer.Connection = con
        cmSCustomer.CommandText = "SELECT * FROM tblCustomer"
        adsCustomer.SelectCommand = cmSCustomer
        adsCustomer.Fill(dssCustomer, "customers")
        nsCustomer = dssCustomer.Tables("customers").Rows.Count - 1
        con.Close()
        Dim AutoComp1 As New AutoCompleteStringCollection()
        For i As Integer = 0 To dssCustomer.Tables(0).Rows.Count - 1
            AutoComp1.Add(dssCustomer.Tables(0).Rows(i)(0).ToString())
        Next
        txtCustomerSearch.AutoCompleteMode = AutoCompleteMode.Suggest
        txtCustomerSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCustomerSearch.AutoCompleteCustomSource = AutoComp1
    End Sub

    Private Sub DataGridView1_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridView1.RowsAdded
        'For Each rowX As DataGridViewRow In DataGridView1.Rows
        '    rowX.Cells(5).Value = Val(rowX.Cells(3).Value) * Val(rowX.Cells(4).Value)
        'Next
        'Dim tot, tot2 As Double
        'If radODNormal.Checked = True Then
        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If IsNumeric(row.Cells(5).Value) Then
        '            tot += Val(row.Cells(5).Value)
        '        End If
        '    Next
        '    txtTotal.Text = tot
        'ElseIf radODWholeSale.Checked = True Then
        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If IsNumeric(row.Cells(5).Value) Then
        '            tot += Val(row.Cells(5).Value)
        '        End If
        '    Next
        '    tot2 = tot * 0.8
        '    txtTotal.Text = tot2
        'End If
    End Sub

    Private Sub DataGridView1_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridView1.RowsRemoved
        'For Each rowX As DataGridViewRow In DataGridView1.Rows
        '    rowX.Cells(5).Value = Val(rowX.Cells(3).Value) * Val(rowX.Cells(4).Value)
        'Next
        'Dim tot, tot2 As Double
        'If radODNormal.Checked = True Then
        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If IsNumeric(row.Cells(5).Value) Then
        '            tot += Val(row.Cells(5).Value)
        '        End If
        '    Next
        '    txtTotal.Text = tot
        'ElseIf radODWholeSale.Checked = True Then
        '    For Each row As DataGridViewRow In DataGridView1.Rows
        '        If IsNumeric(row.Cells(5).Value) Then
        '            tot += Val(row.Cells(5).Value)
        '        End If
        '    Next
        '    tot2 = tot * 0.8
        '    txtTotal.Text = tot2
        'End If
    End Sub

    Private Sub txtShoeSeach_KeyDown(sender As Object, e As KeyEventArgs) Handles txtShoeSeach.KeyDown
        If e.KeyCode = Keys.Enter Then
            Module1.str(0) = "0"
            If System.Text.RegularExpressions.Regex.IsMatch(txtShoeSeach.Text, "^[A-Za-z0-9]+$") = False Then
                MessageBox.Show("Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Module1.strShoeSearch = txtShoeSeach.Text

                Dim frmItemAdd As New frmItemAdd
                frmItemAdd.ShowDialog()

                'Dim a As Boolean
                'If Module1.str(0) = "0" Then
                '    a = True
                'Else
                '    a = False
                'End If
                'MessageBox.Show(a)

                If Module1.str(0) = "0" Then
                    MessageBox.Show("You didn't Select Any item to add to the order", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Else
                    Try
                        Dim n As Integer = 0
                        If 1 <= DataGridView1.Rows.Count Then
                            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                                If Module1.str(0) = CStr(DataGridView1.Rows(i).Cells(0).Value) And Module1.str(2) = CStr(DataGridView1.Rows(i).Cells(2).Value) Then
                                    DataGridView1.Rows(i).Cells(3).Value = Val(DataGridView1.Rows(i).Cells(3).Value) + Val(Module1.str(3))
                                    n = n + 1
                                End If
                            Next
                            If n = 0 Then
                                DataGridView1.Rows.Add(Module1.str)
                            End If
                        Else
                            DataGridView1.Rows.Add(Module1.str)
                        End If
                    Catch ex As Exception
                        MessageBox.Show("You didn't Select Any item to add to the order", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Try
                End If
                'Module1.strShoeSearch = txtShoeSeach.Text

                'Dim frmItemAdd As New frmItemAdd
                'frmItemAdd.ShowDialog()

                'Try
                '    Dim n As Integer = 0
                '    If 1 >= DataGridView1.Rows.Count Then
                '        For i As Integer = 0 To DataGridView1.Rows.Count - 1
                '            If Module1.str(0) = CStr(DataGridView1.Rows(i).Cells(0).Value) And Module1.str(2) = CStr(DataGridView1.Rows(i).Cells(2).Value) Then
                '                DataGridView1.Rows(i).Cells(3).Value = Val(DataGridView1.Rows(i).Cells(3).Value) + Val(Module1.str(3))
                '                n = n + 1
                '            End If
                '        Next
                '        If n = 0 Then
                '            DataGridView1.Rows.Add(Module1.str)
                '        End If
                '    Else
                '        DataGridView1.Rows.Add(Module1.str)
                '    End If
                'Catch ex As Exception
                '    MessageBox.Show("You didn't Select Any item to add to the order", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                'End Try

                'For Each rowX As DataGridViewRow In DataGridView1.Rows
                '    rowX.Cells(5).Value = Val(rowX.Cells(3).Value) * Val(rowX.Cells(4).Value)
                'Next
                'Dim tot, tot2 As Double
                'If radODNormal.Checked = True Then
                '    For Each row As DataGridViewRow In DataGridView1.Rows
                '        If IsNumeric(row.Cells(5).Value) Then
                '            tot += Val(row.Cells(5).Value)
                '        End If
                '    Next
                '    txtTotal.Text = tot
                'ElseIf radODWholeSale.Checked = True Then
                '    For Each row As DataGridViewRow In DataGridView1.Rows
                '        If IsNumeric(row.Cells(5).Value) Then
                '            tot += Val(row.Cells(5).Value)
                '        End If
                '    Next
                '    tot2 = tot * 0.8
                '    txtTotal.Text = tot2
                'End If
            End If
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For Each rowX As DataGridViewRow In DataGridView1.Rows
            rowX.Cells(5).Value = Val(rowX.Cells(3).Value) * Val(rowX.Cells(4).Value)
        Next
        Dim tot, tot2 As Double
        If radODNormal.Checked = True Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                If IsNumeric(row.Cells(5).Value) Then
                    tot += Val(row.Cells(5).Value)
                End If
            Next
            txtTotal.Text = tot
        ElseIf radODWholeSale.Checked = True Then
            For Each row As DataGridViewRow In DataGridView1.Rows
                If IsNumeric(row.Cells(5).Value) Then
                    tot += Val(row.Cells(5).Value)
                End If
            Next
            tot2 = tot * 0.8
            txtTotal.Text = tot2
        End If
        txtBalance.Text = Val(txtCash.Text) - Val(txtTotal.Text)

    End Sub

    Private Sub txtShoeSeach_TextChanged(sender As Object, e As EventArgs) Handles txtShoeSeach.TextChanged
        Dim a As String
        a = txtShoeSeach.Text
        If txtShoeSeach.Text = "" Then
            txtShoeSeach.Text = ""
            a = ""
            txtShoeSeach.Focus()
        ElseIf txtShoeSeach.Text = "" Then
            txtShoeSeach.Text = ""
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(a, "^[a-zA-Z0-9]+$") = False Then
            Dim count, rempos As Integer
            Dim sb As New System.Text.StringBuilder
            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[a-zA-Z0-9]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtShoeSeach.Text = a
            If txtShoeSeach.Text.Length > 0 Then
                txtShoeSeach.SelectionStart = rempos - 1
                txtShoeSeach.SelectionLength = 0
            Else
                txtShoeSeach.SelectionStart = txtShoeSeach.Text.Length
            End If
            MessageBox.Show("Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class
