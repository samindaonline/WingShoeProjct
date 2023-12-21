Imports System.Data.OleDb
Public Class frmInvoiceEdit
    'Dim adShoe As New OleDbDataAdapter
    'Dim nShoe As Integer
    'Dim dsShoe As New DataSet
    Public str As String()

    Private Sub frmInvoiceEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If txtQty.Text = Module1.strIAQuantity Then
            str = New String() {txtDesignID.Text, txtName.Text, Module1.strIASize, Module1.strIAQuantity, Module1.strIAUnitPrice}
        End If

    End Sub
    Private Sub frmInvoiceEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'con.Open()
        'Dim cmShoe As New OleDbCommand
        'cmShoe.Connection = con
        'cmShoe.CommandText = "SELECT * FROM tblShoe"
        'adShoe.SelectCommand = cmShoe
        'adShoe.Fill(dsShoe, "shoe")
        'nShoe = dsShoe.Tables("shoe").Rows.Count - 1
        'con.Close()

        txtDesignID.Text = Module1.strIADesign
        txtName.Text = Module1.strIAName
        txtSize.Text = Module1.strIASize
        txtQty.Text = Module1.strIAQuantity
        txtUnitPrice.Text = Module1.strIAUnitPrice
    End Sub

    Private Sub txtUnitPrice_TextChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.TextChanged
        Dim total As Double

        total = Val(txtQty.Text) * Val(txtUnitPrice.Text)
        txtSubtotal.Text = total
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        Dim a As String
        a = txtQty.Text
        If IsNumeric(txtQty.Text) = True Then
            Dim total As Double
            total = Val(txtQty.Text) * Val(txtUnitPrice.Text)
            txtSubtotal.Text = total

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
            txtQty.Text = a
            If txtQty.Text.Length > 0 Then
                txtQty.SelectionStart = rempos - 1
                txtQty.SelectionLength = 0
            Else
                txtQty.SelectionStart = txtQty.Text.Length
            End If
            MessageBox.Show("Numbers & Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If



    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim stock, value As Integer

        If Val(txtQty.Text) >= Module1.strIAQuantity Then
            Dim cmBuild As New OleDbCommandBuilder
            cmBuild.DataAdapter = Module1.adShoe
            Dim tbEdit As DataTable
            Dim dcPrimaryKey(1) As DataColumn
            tbEdit = Module1.dsShoe.Tables("shoe")
            dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
            dcPrimaryKey(1) = tbEdit.Columns("sSize")
            tbEdit.PrimaryKey = dcPrimaryKey
            Dim drEdit As DataRow = tbEdit.Rows.Find({txtDesignID.Text, txtSize.Text})
            With drEdit
                stock = .Item("sQuantity")
            End With
            If txtQty.Text > stock Then
                MessageBox.Show("Out of stock")
            Else
                value = Val(txtQty.Text) - Module1.strIAQuantity
                With drEdit
                    .Item("sQuantity") = .Item("sQuantity") - value
                End With
                Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand
                'con.Open()
                'Try
                '    adShoe.Update(dsShoe, ("shoe"))
                'Catch ex As Exception
                '    MessageBox.Show("You are trying to save data incorrectly...")
                'End Try
                'con.Close()

                str = New String() {txtDesignID.Text, txtName.Text, txtSize.Text, txtQty.Text, txtUnitPrice.Text, txtSubtotal.Text}
                Me.Close()
            End If


        ElseIf Val(txtQty.Text) < Module1.strIAQuantity Then

            Dim cmBuild As New OleDbCommandBuilder
            cmBuild.DataAdapter = Module1.adShoe
            Dim tbEdit As DataTable
            Dim dcPrimaryKey(1) As DataColumn
            tbEdit = Module1.dsShoe.Tables("shoe")
            dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
            dcPrimaryKey(1) = tbEdit.Columns("sSize")
            tbEdit.PrimaryKey = dcPrimaryKey
            Dim drEdit As DataRow = tbEdit.Rows.Find({txtDesignID.Text, txtSize.Text})
            With drEdit
                stock = .Item("sQuantity")
            End With
            value = Module1.strIAQuantity - Val(txtQty.Text)
            With drEdit
                .Item("sQuantity") = .Item("sQuantity") + value
            End With
            Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand
            'con.Open()
            'Try
            '    adShoe.Update(dsShoe, ("shoe"))
            'Catch ex As Exception
            '    MessageBox.Show("You are trying to save data incorrectly...")
            'End Try
            'con.Close()
            str = New String() {txtDesignID.Text, txtName.Text, txtSize.Text, txtQty.Text, txtUnitPrice.Text, txtSubtotal.Text}
            Me.Close()
        End If
    End Sub

End Class