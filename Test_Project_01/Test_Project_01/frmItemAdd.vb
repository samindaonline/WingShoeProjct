Imports System.Data.OleDb
Public Class frmItemAdd

    Private Sub frmItemAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    'Dim dsShoe As New DataSet
    'Dim adShoe As New OleDbDataAdapter
    'Dim n As Integer
    'Public str As String()


    Private Sub frmItemAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'con.Open()
        'Dim cmShoe As New OleDbCommand
        'cmShoe.Connection = con
        'cmShoe.CommandText = "SELECT * FROM tblShoe"
        'adShoe.SelectCommand = cmShoe
        'adShoe.Fill(dsShoe, "shoe")
        'n = dsShoe.Tables("shoe").Rows.Count - 1
        'con.Close()

        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(0).Name = "Design ID"
        DataGridView1.Columns(1).Name = "Design Name"
        DataGridView1.Columns(2).Name = "Size"
        DataGridView1.Columns(3).Name = "In stock"
        DataGridView1.Columns(4).Name = "Unit Price(Rs.)"
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 230
        DataGridView1.Columns(2).Width = 60
        DataGridView1.Columns(3).Width = 70
        DataGridView1.Columns(4).Width = 116
        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Dim tbShoe As DataTable
        Dim dcPrimaryKey1(1) As DataColumn
        tbShoe = Module1.dsShoe.Tables("shoe")
        dcPrimaryKey1(0) = tbShoe.Columns("sDesignID")
        dcPrimaryKey1(1) = tbShoe.Columns("sSize")
        tbShoe.PrimaryKey = dcPrimaryKey1

        Dim strDesID, strSize As String

        strDesID = Module1.strShoeSearch
        strSize = 4
        Dim intSize As Integer = 4
        While intSize < 10
            If Not strDesID Is Nothing Or intSize <> 0 Then
                Dim drCustomer As DataRow
                drCustomer = tbShoe.Rows.Find({strDesID, intSize})
                If Not drCustomer Is Nothing Then
                    With drCustomer
                        DataGridView1.Rows.Add(.Item("sDesignID"), .Item("sName"), .Item("sSize"), .Item("sQuantity"), .Item("sUnitPrice"))
                    End With
                End If
            End If
            intSize = intSize + 1
        End While
        If DataGridView1.RowCount = 0 Then
            Me.Close()
        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        If txtQty.Text = "" Or IsNumeric(txtQty.Text) = False Then
            If txtQty.Text = "" Then
                MessageBox.Show("Please specify quantity required")
                txtQty.BackColor = Color.Pink
            ElseIf IsNumeric(txtQty.Text) = False Then
                MessageBox.Show("Please enter only digits for required quantity.")
                txtQty.BackColor = Color.Pink
            End If
        Else
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            If Val(txtQty.Text) > Val(DataGridView1.Item(3, i).Value) Then
                MessageBox.Show("Selected Item is out of stock")
            Else

                Dim cmBuild As New OleDbCommandBuilder
                cmBuild.DataAdapter = Module1.adShoe
                Dim tbEdit As DataTable
                Dim dcPrimaryKey(1) As DataColumn
                tbEdit = Module1.dsShoe.Tables("shoe")
                dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
                dcPrimaryKey(1) = tbEdit.Columns("sSize")
                tbEdit.PrimaryKey = dcPrimaryKey
                Dim drEdit As DataRow = tbEdit.Rows.Find({DataGridView1.Item(0, i).Value, DataGridView1.Item(2, i).Value})
                With drEdit
                    .Item("sQuantity") = Val(DataGridView1.Item(3, i).Value) - Val(txtQty.Text)
                End With
                Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand

                'con.Open()
                'Try
                '    adShoe.Update(dsShoe, ("shoe"))
                'Catch ex As Exception
                '    MessageBox.Show("You are trying to save data incorrectly...")
                'End Try
                'con.Close()
                Module1.str = {DataGridView1.Item(0, i).Value, DataGridView1.Item(1, i).Value, DataGridView1.Item(2, i).Value, txtQty.Text, DataGridView1.Item(4, i).Value}
                Me.Close()
            End If
        End If

    End Sub

    Private Sub txtQty_Enter(sender As Object, e As EventArgs) Handles txtQty.Enter
        txtQty.BackColor = Color.White
    End Sub

    Private Sub txtQty_KeyDown(sender As Object, e As KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtQty.Text = "" Or IsNumeric(txtQty.Text) = False Then
                If txtQty.Text = "" Then
                    MessageBox.Show("Please specify quantity required")
                    txtQty.BackColor = Color.Pink
                ElseIf IsNumeric(txtQty.Text) = False Then
                    MessageBox.Show("Please enter only digits for required quantity.")
                    txtQty.BackColor = Color.Pink
                End If
            Else
                Dim i As Integer
                i = DataGridView1.CurrentRow.Index
                If Val(txtQty.Text) > Val(DataGridView1.Item(3, i).Value) Then
                    MessageBox.Show("Selected Item is out of stock")
                Else

                    Dim cmBuild As New OleDbCommandBuilder
                    cmBuild.DataAdapter = Module1.adShoe
                    Dim tbEdit As DataTable
                    Dim dcPrimaryKey(1) As DataColumn
                    tbEdit = Module1.dsShoe.Tables("shoe")
                    dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
                    dcPrimaryKey(1) = tbEdit.Columns("sSize")
                    tbEdit.PrimaryKey = dcPrimaryKey
                    Dim drEdit As DataRow = tbEdit.Rows.Find({DataGridView1.Item(0, i).Value, DataGridView1.Item(2, i).Value})
                    With drEdit
                        .Item("sQuantity") = Val(DataGridView1.Item(3, i).Value) - Val(txtQty.Text)
                    End With
                    Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand

                    'con.Open()
                    'Try
                    '    adShoe.Update(dsShoe, ("shoe"))
                    'Catch ex As Exception
                    '    MessageBox.Show("You are trying to save data incorrectly...")
                    'End Try
                    'con.Close()
                    Module1.str = New String() {DataGridView1.Item(0, i).Value, DataGridView1.Item(1, i).Value, DataGridView1.Item(2, i).Value, txtQty.Text, DataGridView1.Item(4, i).Value}
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        If txtQty.Text = "" Then
            txtSubtotal.Text = ""
        ElseIf IsNumeric(txtQty.Text) = False Then
            MessageBox.Show("Enter numbers only")
        Else
            Dim i As Integer
            Dim subtotal As Double
            i = DataGridView1.CurrentRow.Index
            subtotal = Val(DataGridView1.Item(4, i).Value) * Val(txtQty.Text)
            txtSubtotal.Text = subtotal
        End If

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

        If DataGridView1.Rows.Count > 0 Then
            Module1.strIADesign = DataGridView1.SelectedRows(0).Cells(0).Value
            Module1.strIAName = DataGridView1.SelectedRows(0).Cells(1).Value
            Module1.strIASize = DataGridView1.SelectedRows(0).Cells(2).Value
            Module1.strIAQuantity = DataGridView1.SelectedRows(0).Cells(3).Value
            Module1.strIAUnitPrice = DataGridView1.SelectedRows(0).Cells(4).Value

            Dim frmAddQuantity As New frmAddQuantity
            frmAddQuantity.ShowDialog()

            Me.Close()
            'Try
            '    DataGridView1.Rows.Add(frmItemAdd.str)
            'Catch ex As Exception
            '    MessageBox.Show("You didn't Select Any item")
            'End Try
        Else
            MessageBox.Show("Select a row to edit")
        End If

        'Dim value As String = InputBox("Enter the quantity", "Quantity")

        'If value = "" Or IsNumeric(value) = False Then
        '    If value = "" Then
        '        MessageBox.Show("Please specify quantity required")

        '    ElseIf IsNumeric(value) = False Then
        '        MessageBox.Show("Please enter only digits for required quantity.")
        '    End If
        'Else
        '    Dim i As Integer
        '    i = DataGridView1.CurrentRow.Index
        '    If Val(value) > Val(DataGridView1.Item(3, i).Value) Then
        '        MessageBox.Show("Selected Item is out of stock")
        '    Else

        '        Dim cmBuild As New OleDbCommandBuilder
        '        cmBuild.DataAdapter = adShoe
        '        Dim tbEdit As DataTable
        '        Dim dcPrimaryKey(1) As DataColumn
        '        tbEdit = Module1.dsShoe.Tables("shoe")
        '        dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
        '        dcPrimaryKey(1) = tbEdit.Columns("sSize")
        '        tbEdit.PrimaryKey = dcPrimaryKey
        '        Dim drEdit As DataRow = tbEdit.Rows.Find({DataGridView1.Item(0, i).Value, DataGridView1.Item(2, i).Value})
        '        With drEdit
        '            .Item("sQuantity") = Val(DataGridView1.Item(3, i).Value) - Val(value)
        '        End With
        '        Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand

        '        'con.Open()
        '        'Try
        '        '    adShoe.Update(dsShoe, ("shoe"))
        '        'Catch ex As Exception
        '        '    MessageBox.Show("You are trying to save data incorrectly...")
        '        'End Try
        '        'con.Close()
        '        str = New String() {DataGridView1.Item(0, i).Value, DataGridView1.Item(1, i).Value, DataGridView1.Item(2, i).Value, value, DataGridView1.Item(4, i).Value}
        '        Me.Close()
        '    End If
        'End If
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then

            If DataGridView1.Rows.Count > 0 Then
                Module1.strIADesign = DataGridView1.SelectedRows(0).Cells(0).Value
                Module1.strIAName = DataGridView1.SelectedRows(0).Cells(1).Value
                Module1.strIASize = DataGridView1.SelectedRows(0).Cells(2).Value
                Module1.strIAQuantity = DataGridView1.SelectedRows(0).Cells(3).Value
                Module1.strIAUnitPrice = DataGridView1.SelectedRows(0).Cells(4).Value

                Dim frmAddQuantity As New frmAddQuantity
                frmAddQuantity.ShowDialog()

                Me.Close()
                'Try
                '    DataGridView1.Rows.Add(frmItemAdd.str)
                'Catch ex As Exception
                '    MessageBox.Show("You didn't Select Any item")
                'End Try
            Else
                MessageBox.Show("Select a row to edit")
            End If

            'Dim value As String = InputBox("Enter the quantity", "Quantity")

            'If value = "" Or IsNumeric(value) = False Then
            '    If value = "" Then
            '        MessageBox.Show("Please specify quantity required")

            '    ElseIf IsNumeric(value) = False Then
            '        MessageBox.Show("Please enter only digits for required quantity.")
            '    End If
            'Else
            '    Dim i As Integer
            '    i = DataGridView1.CurrentRow.Index
            '    If Val(value) > Val(DataGridView1.Item(3, i).Value) Then
            '        MessageBox.Show("Selected Item is out of stock")
            '    Else

            '        Dim cmBuild As New OleDbCommandBuilder
            '        cmBuild.DataAdapter = adShoe
            '        Dim tbEdit As DataTable
            '        Dim dcPrimaryKey(1) As DataColumn
            '        tbEdit = Module1.dsShoe.Tables("shoe")
            '        dcPrimaryKey(0) = tbEdit.Columns("sDesignID")
            '        dcPrimaryKey(1) = tbEdit.Columns("sSize")
            '        tbEdit.PrimaryKey = dcPrimaryKey
            '        Dim drEdit As DataRow = tbEdit.Rows.Find({DataGridView1.Item(0, i).Value, DataGridView1.Item(2, i).Value})
            '        With drEdit
            '            .Item("sQuantity") = Val(DataGridView1.Item(3, i).Value) - Val(value)
            '        End With
            '        Module1.adShoe.UpdateCommand = cmBuild.GetUpdateCommand

            '        'con.Open()
            '        'Try
            '        '    adShoe.Update(dsShoe, ("shoe"))
            '        'Catch ex As Exception
            '        '    MessageBox.Show("You are trying to save data incorrectly...")
            '        'End Try
            '        'con.Close()
            '        Module1.str = New String() {DataGridView1.Item(0, i).Value, DataGridView1.Item(1, i).Value, DataGridView1.Item(2, i).Value, value, DataGridView1.Item(4, i).Value}
            '        Me.Close()
            '    End If
            'End If
        End If
    End Sub
End Class