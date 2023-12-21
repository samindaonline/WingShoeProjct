Imports System.Data.OleDb
Public Class frmViewOrder
    Dim adOrder As New OleDbDataAdapter
    Dim dsOrder As New DataSet
    Dim adContain As New OleDbDataAdapter
    Dim n As Integer
    Dim chrCommand As Char
    Dim nCustomer As Integer
    Public adShoe As New OleDbDataAdapter
    Public nShoe As Integer
    Dim dsCustomer As New DataSet
    Dim dsContain As New DataSet
    Dim adCustomer As New OleDbDataAdapter
    Dim ncontain As Integer

    Dim tables As DataTableCollection
    Dim source As New BindingSource

    Private Sub frmViewOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.Open()
        Dim cmOrder As New OleDbCommand
        cmOrder.Connection = con
        cmOrder.CommandText = "SELECT * FROM tblOrder"
        adOrder.SelectCommand = cmOrder
        adOrder.Fill(dsOrder, "order")
        n = dsOrder.Tables("order").Rows.Count - 1
        con.Close()
        n = 0
        showRecords()
    End Sub
    Sub showRecords()
        Dim drOrder As DataRow
        If n >= 0 Then
            drOrder = dsOrder.Tables("order").Rows(n)
            With drOrder
                txtInvoiceNumber.Text = .Item("oID")
                txtDate.Text = .Item("oDate")
                txtAmount.Text = .Item("oAmount")
                txtTP.Text = .Item("cTP")
                radNormal.Checked = .Item("oType") = "Normal"
                radWholeSale.Checked = .Item("oType") = "Whole Sale"
            End With

            con.Open()
            Dim cmContain As New OleDbCommand
            cmContain.Connection = con
            cmContain.CommandText = "SELECT * FROM tblContain,tblOrder"
            adContain.SelectCommand = cmContain
            adContain.Fill(dsContain, "contain")
            ncontain = dsContain.Tables("contain").Rows.Count - 1
            con.Close()

            dsContain = New DataSet
            tables = dsContain.Tables
            adContain = New OleDbDataAdapter("Select sDesignID,sSize,sQuantity,TotalAmount from tblContain Where oID='" & txtInvoiceNumber.Text & "'", con)
            adContain.Fill(dsContain, "tblitems")
            Dim view As New DataView(tables(0))
            source.DataSource = view
            DataGridView1.DataSource = view

        End If
    End Sub

    'Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
    '    Me.Close()
    'End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        n = 0
        showRecords()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        If n > 0 Then
            n = n - 1
            showRecords()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If n < dsOrder.Tables("order").Rows.Count - 1 Then
            n = n + 1
            showRecords()
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        n = dsOrder.Tables("order").Rows.Count - 1
        showRecords()
    End Sub

    'Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
    '    txtInvoiceNumber.Enabled = True
    '    showRecords()
    'End Sub

    'Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
    '    txtInvoiceNumber.Enabled = False
    '    If n >= 0 Then
    '        chrCommand = "E"
    '        txtInvoiceNumber.Focus()
    '    End If
    'End Sub

    'Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
    '    If n >= 0 Then
    '        chrCommand = "D"
    '        txtInvoiceNumber.Focus()
    '    End If
    '    txtInvoiceNumber.Enabled = True
    'End Sub

    'Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    Dim orderType As String = "Normal"
    '    If radNormal.Checked = True Then
    '        orderType = "Normal"
    '    ElseIf radWholeSale.Checked = True Then
    '        orderType = "Whole Sale"
    '    End If
    '    Dim cmBuilder As New OleDbCommandBuilder
    '    cmBuilder.DataAdapter = adOrder
    '    If chrCommand = "E" Then
    '        Dim tbOrder As DataTable
    '        Dim dcPrimarykey(0) As DataColumn
    '        tbOrder = dsOrder.Tables("order")
    '        dcPrimarykey(0) = tbOrder.Columns("cNic")
    '        tbOrder.PrimaryKey = dcPrimarykey
    '        Dim drORder As DataRow = tbOrder.Rows.Find(txtInvoiceNumber.Text)
    '        With drOrder
    '            .Item("oID") = txtInvoiceNumber.Text
    '            .Item("oType") = orderType
    '            .Item("oDate") = txtDate.Text
    '            .Item("oAmount") = txtAmount.Text
    '            .Item("cTP") = txtTP.Text
    '        End With
    '        adOrder.UpdateCommand = cmBuilder.GetUpdateCommand
    '        MessageBox.Show("Data Saved Successfully", Me.Text, MessageBoxButtons.OK)

    '    ElseIf chrCommand = "D" Then
    '        dsOrder.Tables("order").Rows(n).Delete()
    '        adOrder.DeleteCommand = cmBuilder.GetDeleteCommand
    '        n = n - 1
    '        MessageBox.Show("Data Deleted Successfully", Me.Text, MessageBoxButtons.OK)
    '    End If
    '    con.Open()
    '    Try
    '        adOrder.Update(dsOrder, "order")
    '    Catch ex As Exception
    '        MessageBox.Show("You are trying to save data incorrectly...")
    '    End Try
    '    con.Close()
    '    txtInvoiceNumber.Enabled = True
    'End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim tbOrder As DataTable
        Dim dcPrimaryKey(0) As DataColumn
        tbOrder = dsOrder.Tables("order")
        dcPrimaryKey(0) = tbOrder.Columns("oID")
        tbOrder.PrimaryKey = dcPrimaryKey

        Dim strNo As String

        strNo = txtSearchBox.Text

        If Not strNo Is Nothing Then
            Dim drOrder As DataRow = tbOrder.Rows.Find(strNo)
            If Not drOrder Is Nothing Then
                With drOrder
                    txtInvoiceNumber.Text = .Item("oID")
                    txtDate.Text = .Item("oDate")
                    txtAmount.Text = .Item("oAmount")
                    txtTP.Text = .Item("cTP")
                    radNormal.Checked = .Item("oType") = "Normal"
                    radWholeSale.Checked = .Item("oType") = "Whole Sale"
                End With
            Else
                MessageBox.Show("Order Not Found...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub txtSearchBox_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBox.TextChanged

    End Sub

    Private Sub txtInvoiceNumber_TextChanged(sender As Object, e As EventArgs) Handles txtInvoiceNumber.TextChanged
        If txtInvoiceNumber.Text = "" Then
            txtInvoiceNumber.Text = ""
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtInvoiceNumber.Text, "^[A-Za-z0-9]+$") = False Then
            Dim count, rempos As Integer
            Dim a As String
            Dim sb As New System.Text.StringBuilder
            a = txtInvoiceNumber.Text

            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[A-Za-z0-9]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtInvoiceNumber.Text = a
            txtInvoiceNumber.SelectionStart = rempos - 1
            txtInvoiceNumber.SelectionLength = 0
            MessageBox.Show("Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'txtName.Text = txtName.Text.Remove(txtName.Text.Length - 1)
            'txtName.SelectionStart = txtName.Text.Length
        End If
    End Sub

    Private Sub txtAmount_TextChanged(sender As Object, e As EventArgs) Handles txtAmount.TextChanged
        If txtAmount.Text = "" Then
            txtAmount.Text = ""
            'ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtAmount.Text, "^[0-9\S]+$") = False Then
            '    MessageBox.Show("Please enter Amount", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    txtAmount.Text = txtAmount.Text.Remove(txtAmount.Text.Length - 1)
            '    txtAmount.SelectionStart = txtAmount.Text.Length
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtAmount.Text, "^[0-9\s]+$") = False Then
            Dim count, rempos As Integer
            Dim a As String
            Dim sb As New System.Text.StringBuilder
            a = txtAmount.Text

            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[0-9\s]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtAmount.Text = a
            txtAmount.SelectionStart = rempos - 1
            txtAmount.SelectionLength = 0
            MessageBox.Show("Letters and Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'txtName.Text = txtName.Text.Remove(txtName.Text.Length - 1)
            'txtName.SelectionStart = txtName.Text.Length
        End If
    End Sub

    Private Sub txtTP_TextChanged(sender As Object, e As EventArgs) Handles txtTP.TextChanged
        'StartPosition:
        '        Dim a As String
        '        a = txtTP.Text
        '        If a.Length = 10 Then
        '            con.Open()
        '            Dim cmCustomer As New OleDbCommand
        '            cmCustomer.Connection = con
        '            cmCustomer.CommandText = "SELECT * FROM tblCustomer"
        '            adCustomer.SelectCommand = cmCustomer
        '            adCustomer.Fill(dsCustomer, "customer")
        '            nCustomer = dsCustomer.Tables("customer").Rows.Count - 1
        '            con.Close()

        '            Dim tbCustomer As DataTable
        '            Dim dcPrimaryKey(0) As DataColumn
        '            tbCustomer = dsCustomer.Tables("customer")
        '            dcPrimaryKey(0) = tbCustomer.Columns("cTP")
        '            tbCustomer.PrimaryKey = dcPrimaryKey
        '            Dim strNo As String
        '            strNo = a
        '            If Not strNo Is Nothing Then
        '                Dim drCustomer As DataRow
        '                drCustomer = tbCustomer.Rows.Find(strNo)
        '                If Not drCustomer Is Nothing Then
        '                    With drCustomer
        '                        'txtCustomerName.Text = .Item("cName")
        '                        'txtCustomerAddress.Text = .Item("cAddress")
        '                    End With
        '                Else
        '                    Dim NewCus As String = MessageBox.Show("This phone number is not in the database. Do you want to add '" & txtTP.Text & "' this phone number to the customer list? ", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        '                    If NewCus = vbYes Then
        '                        Module1.strNewTP = a
        '                        Dim frmAddNewCustomer As New frmAddNewCustomer
        '                        frmAddNewCustomer.ShowDialog()
        '                        GoTo StartPosition
        '                    Else
        '                        'txtCustomerSearch.Clear()
        '                    End If
        '                End If
        '            End If

        '        ElseIf (txtTP.Text).Length > 10 Then
        '            MessageBox.Show("10 Digit Telephone Number only")
        '            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
        '            txtTP.Focus()
        '            txtTP.SelectionStart = txtTP.Text.Length
        '        ElseIf txtTP.Text = "" Then
        '            txtTP.Text = ""
        '        ElseIf IsNumeric(txtTP.Text) = False Then
        '            MessageBox.Show("Please enter valid telephone number")
        '            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
        '            txtTP.Focus()
        '            txtTP.SelectionStart = txtTP.Text.Length
        '        ElseIf (txtTP.Text).Substring(0, 1) <> "0" Then
        '            MessageBox.Show("Please enter telephone number with zero (i.e- 045 000 0000)")
        '            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
        '            txtTP.Focus()
        '            txtTP.SelectionStart = txtTP.Text.Length
        '        End If
    End Sub

  
End Class