Imports System.Data.OleDb
Public Class frmAddQuantity

    Private Sub frmAddQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub frmAddQuantity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDesignID.Text = Module1.strIADesign
        txtName.Text = Module1.strIAName
        txtSize.Text = Module1.strIASize
        txtStock.Text = Module1.strIAQuantity
        txtUnitPrice.Text = Module1.strIAUnitPrice
        'txtDesignID.Enabled = False
        'txtName.Enabled = False
        'txtSize.Enabled = False
        'txtStock.Enabled = False
        'txtUnitPrice.Enabled = False
        'txtSubTotal.Enabled = False
        txtQuantity.Focus()
    End Sub

    Private Sub txtQuantity_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQuantity.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(txtQuantity.Text) > Val(txtStock.Text) Then
                MessageBox.Show("Selected Item is out of stock", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim cmBuild As New OleDbCommandBuilder
                cmBuild.DataAdapter = adShoe
                Dim tbEdit As DataTable
                Dim dcPrimaryKey(1) As DataColumn
                tbEdit = Module1.dsShoe.Tables("shoe")
                dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
                dcPrimaryKey(1) = tbEdit.Columns("sSize")
                tbEdit.PrimaryKey = dcPrimaryKey
                Dim drEdit As DataRow = tbEdit.Rows.Find({txtDesignID.Text, txtSize.Text})
                With drEdit
                    .Item("sQuantity") = Val(txtStock.Text) - Val(txtQuantity.Text)
                End With
                Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand

                Module1.str = {txtDesignID.Text, txtName.Text, txtSize.Text, txtQuantity.Text, txtUnitPrice.Text}
                Me.Close()
            End If
        End If

    End Sub


    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        If IsNumeric(txtQuantity.Text) = True Then
            Dim total As Double
            total = Val(txtQuantity.Text) * Val(txtUnitPrice.Text)
            txtSubTotal.Text = total
        Else
            Dim a As String
            a = txtQuantity.Text
            If txtQuantity.Text = "" Then
                txtQuantity.Text = ""
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
                txtQuantity.Text = a
                If txtQuantity.Text.Length > 0 Then
                    txtQuantity.SelectionStart = rempos - 1
                    txtQuantity.SelectionLength = 0
                Else
                    txtQuantity.SelectionStart = txtQuantity.Text.Length
                End If
                MessageBox.Show("Numbers & Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        If Val(txtQuantity.Text) > Val(txtStock.Text) Then
            MessageBox.Show("Selected Item is out of stock", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub


    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If Val(txtQuantity.Text) > Val(txtStock.Text) Then
            MessageBox.Show("Selected Item is out of stock", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            Dim cmBuild As New OleDbCommandBuilder
            cmBuild.DataAdapter = adShoe
            Dim tbEdit As DataTable
            Dim dcPrimaryKey(1) As DataColumn
            tbEdit = Module1.dsShoe.Tables("shoe")
            dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
            dcPrimaryKey(1) = tbEdit.Columns("sSize")
            tbEdit.PrimaryKey = dcPrimaryKey
            Dim drEdit As DataRow = tbEdit.Rows.Find({txtDesignID.Text, txtSize.Text})
            With drEdit
                .Item("sQuantity") = Val(txtStock.Text) - Val(txtQuantity.Text)
            End With
            Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand

            Module1.str = {txtDesignID.Text, txtName.Text, txtSize.Text, txtQuantity.Text, txtUnitPrice.Text}
            Me.Close()
        End If
    End Sub
End Class