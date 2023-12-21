Imports System.Data.OleDb
Public Class frmCustomerUpdate
    Dim adCustomer As New OleDbDataAdapter
    Dim dsCustomer As New DataSet
    Dim n As Integer
    Dim chrDBCommand As Char
    Dim strSearch As String = "0"
    Dim strAvailable As String = "NO"
    Dim intAddbtn As Integer = 0

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmCustomerUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loadDb()
        n = 0
        showRecords()

    End Sub
    Sub showRecords()
        Dim drOrder As DataRow
        If n >= 0 Then
            drOrder = dsCustomer.Tables("Customer").Rows(n)
            With drOrder
                txtAddress.Text = .Item("cAddress")
                txtName.Text = .Item("cName")
                txtTP.Text = .Item("cTP")
                radMale.Checked = .Item("cGender") = "Male"
                radFemale.Checked = .Item("cGender") = "Female"
            End With
        End If
    End Sub

    Sub loadDb()
        con.Open()
        Dim cmCustomer As New OleDbCommand
        cmCustomer.Connection = con
        cmCustomer.CommandText = "SELECT * FROM tblCustomer"
        adCustomer.SelectCommand = cmCustomer
        adCustomer.Fill(dsCustomer, "Customer")
        n = dsCustomer.Tables("Customer").Rows.Count - 1
        con.Close()
    End Sub

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
        If n < dsCustomer.Tables("Customer").Rows.Count - 1 Then
            n = n + 1
            showRecords()
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        n = dsCustomer.Tables("Customer").Rows.Count - 1
        showRecords()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtTP.Enabled = True
        intAddbtn = 0
        showRecords()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        txtTP.Enabled = True
        chrDBCommand = "A"
        intAddbtn = 1
        clearControls()
    End Sub
    Sub clearControls()
        txtAddress.Clear()
        txtName.Clear()
        txtTP.Clear()
        radMale.Checked = True
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        txtTP.Enabled = False
        If n >= 0 Then
            chrDBCommand = "E"
            txtName.Focus()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        txtTP.Enabled = True
        If n >= 0 Then
            txtName.Focus()
        End If

        Dim n1 As String = MessageBox.Show("Do you want to delete '" & txtName.Text & "' from customer list?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If n1 = vbYes Then
            'If strSearch = "1" Then
            Dim rowToDelete As DataRow = dsCustomer.Tables("Customer").Select("cTP = '" & txtTP.Text & "'")(0)
            rowToDelete.Delete()
            'Else
            'dsCustomer.Tables("Customer").Rows(n).Delete()
            'End If

            con.Open()
            adCustomer.Update(dsCustomer, "Customer")
            con.Close()

            loadDb()
            n = 0
            showRecords()
            MessageBox.Show("Record deleted successfully.",Me.Text,MessageBoxButtons.OK,MessageBoxIcon.Information)
        Else
            MessageBox.Show("Record not deleted.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        '    If strSearch = "1" Then
        '        n = n - 1
        '        con.Open()
        '        Dim cmDelete As New OleDbCommand("Delete from tblCustomer where cTP=@cTP", con)
        '        cmDelete.Parameters.AddWithValue("@cTP", txtSearchBox.Text)
        '        cmDelete.ExecuteNonQuery()
        '        con.Close()

        '        strSearch = "0"

        '        Dim rowToDelete As DataRow = dsCustomer.Tables("Customer").Select("cTP = '" & txtSearchBox.Text & "'")(0)
        '        rowToDelete.Delete()


        '        loadDb()

        '        n = 0
        '        showRecords()
        '        MessageBox.Show("Record deleted successfully.")
        '    Else
        '        Dim cmBuilder As New OleDbCommandBuilder
        '        cmBuilder.DataAdapter = adCustomer
        '        dsCustomer.Tables("Customer").Rows(n).Delete()
        '        adCustomer.DeleteCommand = cmBuilder.GetDeleteCommand
        '        n = n - 1
        '        con.Open()
        '        Try
        '            adCustomer.Update(dsCustomer, "Customer")
        '        Catch ex As Exception
        '            MessageBox.Show("You are trying to save data incorrectly...")
        '        End Try
        '        con.Close()
        '        n = 0
        '        showRecords()
        '        MessageBox.Show("Record deleted successfully1.")
        '    End If
        'Else
        '    MessageBox.Show("Record Not Deleted")
        'End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        txtTP.Enabled = True
        If txtTP.Text = "" Or txtName.Text = "" Then
            If txtName.Text = "" Then
                MessageBox.Show("Please enter customer's name.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtName.BackColor = Color.Pink

            ElseIf txtTP.Text = "" Then
                MessageBox.Show("Please enter customer's telephone number.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtTP.BackColor = Color.Pink
            End If
        Else
            Dim cGender As String = "M"
            If radFemale.Checked = True Then
                cGender = "Female"
            ElseIf radMale.Checked = True Then
                cGender = "Male"
            End If
            Dim cmBuilder As New OleDbCommandBuilder
            cmBuilder.DataAdapter = adCustomer
            If chrDBCommand = "A" Then
                If (txtTP.Text).Length <> 10 Or (txtTP.Text).Substring(0, 1) <> "0" Or IsNumeric(txtTP.Text) = False Then
                    txtTP.BackColor = Color.Pink
                    If (txtTP.Text).Length <> 10 Then
                        MessageBox.Show("Please Enter a 10-digit phone number.")
                    ElseIf (txtTP.Text).Substring(0, 1) <> "0" Then
                        MessageBox.Show("Please Enter a phone number starting with 0.")
                    ElseIf IsNumeric(txtTP.Text) = False Then
                        MessageBox.Show("A non-numeric symbol was entered. Please enter numbers only.")
                    End If
                Else
                    If txtTP.Text = "" Then
                        MessageBox.Show("Please enter data before saving...")
                    ElseIf txtTP.Text.Length = 10 Then
                        Dim tbCustomer As DataTable
                        Dim dcPrimaryKey(0) As DataColumn
                        tbCustomer = dsCustomer.Tables("Customer")
                        dcPrimaryKey(0) = tbCustomer.Columns("cTP")
                        tbCustomer.PrimaryKey = dcPrimaryKey
                        Dim strNo As String

                        strNo = txtTP.Text
                        If Not strNo Is Nothing Then
                            Dim drCustomer As DataRow = tbCustomer.Rows.Find(strNo)
                            If Not drCustomer Is Nothing Then
                                strAvailable = "YES"
                                MessageBox.Show("This Number is already in the Database! Please Enter another Number.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                txtTP.BackColor = Color.Pink
                                txtTP.Clear()
                            Else
                                strAvailable = "NO"
                                Dim drCus As DataRow
                                drCus = dsCustomer.Tables("Customer").NewRow
                                With drCus
                                    .Item("cTP") = txtTP.Text
                                    .Item("cName") = txtName.Text
                                    .Item("cAddress") = txtAddress.Text
                                    .Item("cGender") = cGender
                                End With
                                dsCustomer.Tables("customer").Rows.Add(drCus)
                                adCustomer.InsertCommand = cmBuilder.GetInsertCommand
                                n = n + 1
                                MessageBox.Show("Data Saved Successfully", Me.Text, MessageBoxButtons.OK)
                            End If
                        End If
                    End If
                End If
            ElseIf chrDBCommand = "E" Then
                Dim tbCus As DataTable
                Dim dcPrimarykey(0) As DataColumn
                tbCus = dsCustomer.Tables("Customer")
                dcPrimarykey(0) = tbCus.Columns("cTP")
                tbCus.PrimaryKey = dcPrimarykey
                Dim drOrder As DataRow = tbCus.Rows.Find(txtTP.Text)
                With drOrder
                    .Item("cTP") = txtTP.Text
                    .Item("cName") = txtName.Text
                    .Item("cAddress") = txtAddress.Text
                    .Item("cGender") = cGender
                End With
                adCustomer.UpdateCommand = cmBuilder.GetUpdateCommand
                MessageBox.Show("Data Saved Successfully", Me.Text, MessageBoxButtons.OK)
            End If
            con.Open()
            Try
                adCustomer.Update(dsCustomer, "Customer")
            Catch ex As Exception
                MessageBox.Show("You are trying to save data incorrectly...")
            End Try
            con.Close()
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If (txtSearchBox.Text).Length <> 10 Or (txtSearchBox.Text).Substring(0, 1) <> "0" Or IsNumeric(txtSearchBox.Text) = False Then
            txtSearchBox.BackColor = Color.Pink
            If (txtSearchBox.Text).Length <> 10 Then
                MessageBox.Show("Please Enter a 10-digit phone number.")
            ElseIf (txtSearchBox.Text).Substring(0, 1) <> "0" Then
                MessageBox.Show("Please Enter a phone number starting with 0.")
            ElseIf IsNumeric(txtSearchBox.Text) = False Then
                MessageBox.Show("A non-numeric symbol was entered. Please enter numbers only.")
            End If
        Else
            Dim tbCustomer As DataTable
            Dim dcPrimaryKey(0) As DataColumn
            tbCustomer = dsCustomer.Tables("Customer")
            dcPrimaryKey(0) = tbCustomer.Columns("cTP")
            tbCustomer.PrimaryKey = dcPrimaryKey

            Dim strNo As String

            strNo = txtSearchBox.Text

            If Not strNo Is Nothing Then
                Dim drCustomer As DataRow = tbCustomer.Rows.Find(strNo)
                If Not drCustomer Is Nothing Then
                    With drCustomer
                        txtAddress.Text = .Item("cAddress")
                        txtName.Text = .Item("cName")
                        txtTP.Text = .Item("cTP")
                        radMale.Checked = .Item("cGender") = "Male"
                        radFemale.Checked = .Item("cGender") = "Female"
                    End With
                    strSearch = "1"
                Else
                    MessageBox.Show("Customer Not Found...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub txtTP_Enter(sender As Object, e As EventArgs) Handles txtTP.Enter
        txtTP.BackColor = Color.White
    End Sub

    Private Sub txtSearchBox_Enter(sender As Object, e As EventArgs) Handles txtSearchBox.Enter
        txtSearchBox.BackColor = Color.White
      
    End Sub

    Private Sub txtSearchBox_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (txtSearchBox.Text).Length <> 10 Or (txtSearchBox.Text).Substring(0, 1) <> "0" Or IsNumeric(txtSearchBox.Text) = False Then
                txtSearchBox.BackColor = Color.Pink
                If (txtSearchBox.Text).Length <> 10 Then
                    MessageBox.Show("Please Enter a 10-digit phone number.")
                ElseIf (txtSearchBox.Text).Substring(0, 1) <> "0" Then
                    MessageBox.Show("Please Enter a phone number starting with 0.")
                ElseIf IsNumeric(txtSearchBox.Text) = False Then
                    MessageBox.Show("A non-numeric symbol was entered. Please enter numbers only.")
                End If
            Else
                Dim tbCustomer As DataTable
                Dim dcPrimaryKey(0) As DataColumn
                tbCustomer = dsCustomer.Tables("Customer")
                dcPrimaryKey(0) = tbCustomer.Columns("cTP")
                tbCustomer.PrimaryKey = dcPrimaryKey

                Dim strNo As String

                strNo = txtSearchBox.Text

                If Not strNo Is Nothing Then
                    Dim drCustomer As DataRow = tbCustomer.Rows.Find(strNo)
                    If Not drCustomer Is Nothing Then
                        With drCustomer
                            txtAddress.Text = .Item("cAddress")
                            txtName.Text = .Item("cName")
                            txtTP.Text = .Item("cTP")
                            radMale.Checked = .Item("cGender") = "Male"
                            radFemale.Checked = .Item("cGender") = "Female"
                        End With
                        strSearch = "1"
                    Else
                        MessageBox.Show("Customer Not Found...", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub txtSearchBox_TextChanged(sender As Object, e As EventArgs) Handles txtSearchBox.TextChanged
        Dim a As String
        a = txtSearchBox.Text
        If txtSearchBox.Text = "" Then
            txtSearchBox.Text = ""
            a = ""
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
            txtSearchBox.Text = a
            If txtSearchBox.Text.Length > 0 Then
                txtSearchBox.SelectionStart = rempos - 1
                txtSearchBox.SelectionLength = 0
            Else
                txtSearchBox.SelectionStart = txtSearchBox.Text.Length
            End If
            MessageBox.Show("Letters & Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If
            'ElseIf IsNumeric(txtSearchBox.Text) = False Then
            '    MessageBox.Show("Please enter valid telephone number")
            '    txtSearchBox.Text = txtSearchBox.Text.Remove(txtSearchBox.Text.Length - 1)
            '    txtSearchBox.Focus()
            '    txtSearchBox.SelectionStart = txtSearchBox.Text.Length
        ElseIf (txtSearchBox.Text).Substring(0, 1) <> "0" Then
            MessageBox.Show("Please enter telephone number with zero (i.e- 045 000 0000)")
            txtSearchBox.Text = txtSearchBox.Text.Remove(txtSearchBox.Text.Length - 1)
            txtSearchBox.Focus()
            txtSearchBox.SelectionStart = txtSearchBox.Text.Length
            'ElseIf (txtSearchBox.Text).Length > 10 Then
            '    MessageBox.Show("10 Digit Telephone Number only")
            '    txtSearchBox.Text = txtSearchBox.Text.Remove(txtSearchBox.Text.Length - 1)
            '    txtSearchBox.Focus()
            '    txtSearchBox.SelectionStart = txtSearchBox.Text.Length
        End If
    End Sub

    Private Sub txtName_Enter(sender As Object, e As EventArgs) Handles txtName.Enter
        txtName.BackColor = Color.White
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim a As String
        a = txtName.Text
        If txtName.Text = "" Then
            txtName.Text = ""
            a = ""
            txtName.Focus()
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(a, "^[a-zA-Z0-9\s]+$") = False Then
            Dim count, rempos As Integer
            Dim sb As New System.Text.StringBuilder
            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[a-zA-Z0-9\s]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtName.Text = a
            If txtName.Text.Length > 0 Then
                txtName.SelectionStart = rempos - 1
                txtName.SelectionLength = 0
            Else
                txtName.SelectionStart = txtName.Text.Length
            End If
            MessageBox.Show("Numbers & Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub txtTP_TextChanged(sender As Object, e As EventArgs) Handles txtTP.TextChanged
        'If intAddbtn = 1 Then
        '    If txtTP.Text.Length = 10 Then
        '        Dim tbCustomer As DataTable
        '        Dim dcPrimaryKey(0) As DataColumn
        '        tbCustomer = dsCustomer.Tables("Customer")
        '        dcPrimaryKey(0) = tbCustomer.Columns("cTP")
        '        tbCustomer.PrimaryKey = dcPrimaryKey
        '        Dim strNo As String

        '        strNo = txtTP.Text
        '        If Not strNo Is Nothing Then
        '            Dim drCustomer As DataRow = tbCustomer.Rows.Find(strNo)
        '            If Not drCustomer Is Nothing Then
        '                strAvailable = "YES"
        '                MessageBox.Show("This Number is already in the Database! Please Enter another Number.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '                txtTP.Clear()
        '            Else
        '                strAvailable = "NO"
        '            End If
        '        End If
        '    End If
        'End If

        '*******************************

        Dim a As String
        a = txtTP.Text
        If (txtTP.Text).Length > 10 Then
            MessageBox.Show("10 Digit Telephone Number only")
            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
            txtTP.Focus()
            txtTP.SelectionStart = txtTP.Text.Length
        ElseIf txtTP.Text = "" Then
            txtTP.Text = ""
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
            txtTP.Text = a
            If txtTP.Text.Length > 0 Then
                txtTP.SelectionStart = rempos - 1
                txtTP.SelectionLength = 0
            Else
                txtTP.SelectionStart = txtTP.Text.Length
            End If
            MessageBox.Show("Letters & Special Characters are not allowed1.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf (txtTP.Text).Substring(0, 1) <> "0" Then
            MessageBox.Show("Please enter telephone number with zero (i.e- 045 000 0000)")
            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
            txtTP.Focus()
            txtTP.SelectionStart = txtTP.Text.Length
        End If
    End Sub
End Class