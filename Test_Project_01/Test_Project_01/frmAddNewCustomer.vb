Imports System.Data.OleDb
Public Class frmAddNewCustomer
    Dim adCustomer As New OleDbDataAdapter
    Dim dsCustomer As New DataSet
    Dim n As Integer
    Dim chrDBCommand As Char
    Private Sub frmAddNewCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtTP.Text = Module1.strNewTP
        radMale.Checked = True
        con.Open()
        Dim cmCustomer As New OleDbCommand
        cmCustomer.Connection = con
        cmCustomer.CommandText = "SELECT * FROM tblCustomer"
        adCustomer.SelectCommand = cmCustomer
        adCustomer.Fill(dsCustomer, "Customer")
        n = dsCustomer.Tables("Customer").Rows.Count - 1
        con.Close()
        n = 0
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtTP.Text = "" Or txtName.Text = "" Then
            If txtName.Text = "" Then
                MessageBox.Show("Please enter customer's name.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtName.BackColor = Color.Pink
            End If
            If txtTP.Text = "" Then
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

            If (txtTP.Text).Length <> 10 Or (txtTP.Text).Substring(0, 1) <> "0" Or IsNumeric(txtTP.Text) = False Then
                txtTP.BackColor = Color.Pink
                If (txtTP.Text).Length <> 10 Then
                    MessageBox.Show("Please Enter a 10-digit phone number.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf (txtTP.Text).Substring(0, 1) <> "0" Then
                    MessageBox.Show("Please Enter a phone number starting with 0.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf IsNumeric(txtTP.Text) = False Then
                    MessageBox.Show("A non-numeric symbol was entered. Please enter numbers only.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                If txtTP.Text = "" Then
                    MessageBox.Show("Please enter data before saving.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim drCus As DataRow
                    drCus = dsCustomer.Tables("customer").NewRow
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

            con.Open()
            Try
                adCustomer.Update(dsCustomer, "customer")
            Catch ex As Exception
                MessageBox.Show("You are trying to save data incorrectly.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
            con.Close()
            Me.Close()
        End If
    End Sub

    Private Sub txtTP_TextChanged(sender As Object, e As EventArgs) Handles txtTP.TextChanged
        Dim a As String
        a = txtTP.Text
        If a = "" Then
            a = ""
            txtTP.Text = a
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
            txtTP.Text = a
            If txtTP.Text.Length > 0 Then
                txtTP.SelectionStart = rempos - 1
                txtTP.SelectionLength = 0
            Else
                txtTP.SelectionStart = txtTP.Text.Length
            End If
            MessageBox.Show("Letters & Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ElseIf (a).Length > 10 Then
            MessageBox.Show("10 Digit Telephone Number only", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
            txtTP.Focus()
            txtTP.SelectionStart = txtTP.Text.Length
        ElseIf IsNumeric(a) = False Then
            MessageBox.Show("Please enter valid telephone number", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
            txtTP.Focus()
            txtTP.SelectionStart = txtTP.Text.Length
        ElseIf (txtTP.Text).Substring(0, 1) <> "0" Then
            MessageBox.Show("Please enter telephone number with zero (i.e- 045 000 0000)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
            txtTP.Focus()
            txtTP.SelectionStart = txtTP.Text.Length
        ElseIf a.Length > 10 Then
            MessageBox.Show("Telephone Number contains only 10 Numbers! (i.e- 045 000 0000)", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtTP.Text = txtTP.Text.Remove(txtTP.Text.Length - 1)
            txtTP.Focus()
            txtTP.SelectionStart = txtTP.Text.Length
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Dim a As String
        a = txtName.Text
        If txtName.Text = "" Then
            txtName.Text = ""
            a = ""
            txtName.Focus()
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

End Class