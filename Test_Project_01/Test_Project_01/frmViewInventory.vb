Imports System.Data.OleDb
Public Class frmViewInventory
    Dim adShoe As New OleDbDataAdapter
    Dim dsShoe As New DataSet
    Dim n As Integer
    Dim chrDBCommand As Char

    Private Sub frmViewInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loaddb()
        n = 0
        showRecords()
    End Sub
    Sub showRecords()
        Dim drShoe As DataRow
        If n >= 0 Then
            drShoe = dsShoe.Tables("shoe").Rows(n)
            With drShoe
                txtDesignID.Text = .Item("sDesignID")
                txtManDate.Text = .Item("sManDate")
                txtQuantity.Text = .Item("sQuantity")
                txtSize.Text = .Item("sSize")
                txtUnitPrice.Text = .Item("sUnitPrice")
                txtName.Text = .Item("sName")
            End With
        End If
    End Sub

    Sub loaddb()
        con.Open()
        Dim cmShoe As New OleDbCommand
        cmShoe.Connection = con
        cmShoe.CommandText = "SELECT * FROM tblShoe"
        adShoe.SelectCommand = cmShoe
        adShoe.Fill(dsShoe, "shoe")
        n = dsShoe.Tables("shoe").Rows.Count - 1
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
        If n < dsShoe.Tables("shoe").Rows.Count - 1 Then
            n = n + 1
            showRecords()
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        n = dsShoe.Tables("shoe").Rows.Count - 1
        showRecords()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        txtDesignID.Enabled = True
        txtSize.Enabled = True
        showRecords()
    End Sub

    Sub clearControls()
        txtDesignID.Clear()
        txtManDate.Clear()
        txtQuantity.Clear()
        txtSize.Clear()
        txtName.Clear()
        txtUnitPrice.Clear()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        txtDesignID.Enabled = True
        txtSize.Enabled = True
        chrDBCommand = "A"
        clearControls()
        txtManDate.Text = String.Format("{0:yyyy/MM/dd}", DateTime.Now)
        txtDesignID.Focus()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        txtDesignID.Enabled = False
        txtSize.Enabled = False

        If n >= 0 Then
            chrDBCommand = "E"
            txtQuantity.Focus()
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim n1 As String = MessageBox.Show("Do you want to delete '" & txtDesignID.Text & "' and size '" & txtSize.Text & "' from shoe inventory?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If n1 = vbYes Then

            Dim deleteCommand As New OleDbCommand("DELETE FROM tblShoe WHERE sDesignID = @sDesignID AND sSize = @sSize", con)
            deleteCommand.Parameters.AddWithValue("@sDesignID", txtDesignID.Text)
            deleteCommand.Parameters.AddWithValue("@sSize", txtSize.Text)

            adShoe.DeleteCommand = deleteCommand

            Dim rowToDelete As DataRow = dsShoe.Tables("shoe").Select("sDesignID = '" & txtDesignID.Text & "' AND sSize = '" & txtSize.Text & "'").FirstOrDefault()
            If rowToDelete IsNot Nothing Then
                rowToDelete.Delete()

                con.Open()
                adShoe.Update(dsShoe, "shoe")
                con.Close()

                loaddb()
                n = 0
                showRecords()
                MessageBox.Show("Record deleted successfully.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Record not found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("Record not deleted.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        'Dim n1 As String = MessageBox.Show("Do you want to delete '" & txtDesignID.Text & "' and size '" & txtSize.Text & "' from shoe inventory?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If n1 = vbYes Then
        '    Dim cmBuilder As New OleDbCommandBuilder
        '    cmBuilder.DataAdapter = adShoe
        '    dsShoe.Tables("shoe").Rows(n).Delete()
        '    adShoe.DeleteCommand = cmBuilder.GetDeleteCommand
        '    n = n - 1
        '    con.Open()
        '    Try
        '        adShoe.Update(dsShoe, "shoe")
        '    Catch ex As Exception
        '        MessageBox.Show("You are trying to save data incorrectly...")
        '    End Try
        '    con.Close()
        '    n = 0
        '    showRecords()
        '    MessageBox.Show("Record deleted successfully.")
        'Else
        '    MessageBox.Show("Record is Not Deleted")
        'End If
        txtDesignID.Enabled = True
        txtSize.Enabled = True
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtDesignID.Text = "" Or txtSize.Text = "" Then
            If txtDesignID.Text = "" Then
                txtDesignID.BackColor = Color.Pink
                MessageBox.Show("You must Enter DesignID to save data.", "Data Missing!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtDesignID.BackColor = Color.White
                txtDesignID.Focus()

            ElseIf txtSize.Text = "" Then
                txtSize.BackColor = Color.Pink
                MessageBox.Show("You must Enter Size to save data.", "Data Missing!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSize.BackColor = Color.White
                txtSize.Focus()
            End If
        Else
            Dim cmBuilder As New OleDbCommandBuilder
            cmBuilder.DataAdapter = adShoe
            If chrDBCommand = "A" Then
                If txtName.Text = "" Then
                    txtName.BackColor = Color.Pink
                    MessageBox.Show("You must Enter Name to save data.", "Data Missing!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtName.BackColor = Color.White
                    txtName.Focus()
                ElseIf txtQuantity.Text = "" Then
                    txtQuantity.BackColor = Color.Pink
                    MessageBox.Show("You must Enter Quantity to save data.", "Data Missing!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtQuantity.BackColor = Color.White
                    txtQuantity.Focus()
                ElseIf txtUnitPrice.Text = "" Then
                    txtUnitPrice.BackColor = Color.Pink
                    MessageBox.Show("You must Enter Unit Price to save data.", "Data Missing!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtUnitPrice.BackColor = Color.White
                    txtUnitPrice.Focus()
                ElseIf txtManDate.Text = "" Then
                    txtManDate.BackColor = Color.Pink
                    MessageBox.Show("You must Enter Manufacture Date to save data.", "Data Missing!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    txtManDate.BackColor = Color.White
                    txtManDate.Focus()
                Else
                    Dim tbShoe As DataTable
                    Dim dcPrimaryKey(1) As DataColumn
                    tbShoe = dsShoe.Tables("shoe")
                    dcPrimaryKey(0) = tbShoe.Columns("sDesignID")
                    dcPrimaryKey(1) = tbShoe.Columns("sSize")
                    tbShoe.PrimaryKey = dcPrimaryKey

                    Dim drwShoe As DataRow = tbShoe.Rows.Find({txtDesignID.Text, txtSize.Text})
                    If Not drwShoe Is Nothing Then
                        With drwShoe
                            MessageBox.Show("The Design and the sieze that you entered is already in the database!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtDesignID.BackColor = Color.Pink
                            txtSize.BackColor = Color.Pink
                            txtDesignID.Clear()
                            txtSize.Clear()
                        End With
                    Else
                        Dim drShoe As DataRow
                        drShoe = dsShoe.Tables("shoe").NewRow
                        With drShoe
                            .Item("sDesignID") = txtDesignID.Text
                            .Item("sManDate") = txtManDate.Text
                            .Item("sQuantity") = txtQuantity.Text
                            .Item("sSize") = txtSize.Text
                            .Item("sUnitPrice") = txtUnitPrice.Text
                            .Item("sName") = txtName.Text

                        End With
                        dsShoe.Tables("shoe").Rows.Add(drShoe)
                        adShoe.InsertCommand = cmBuilder.GetInsertCommand
                        n = n + 1
                        MessageBox.Show("Data Saved Successfully", Me.Text, MessageBoxButtons.OK)
                    End If
                End If

            ElseIf chrDBCommand = "E" Then
                Dim tbShoe As DataTable
                Dim dcPrimarykey(1) As DataColumn
                tbShoe = dsShoe.Tables("shoe")
                dcPrimarykey(0) = tbShoe.Columns("sDesignID")
                dcPrimarykey(1) = tbShoe.Columns("sSize")
                tbShoe.PrimaryKey = dcPrimarykey
                Dim drShoe As DataRow = tbShoe.Rows.Find({txtDesignID.Text, txtSize.Text})
                With drShoe
                    .Item("sDesignID") = txtDesignID.Text
                    .Item("sManDate") = txtManDate.Text
                    .Item("sQuantity") = txtQuantity.Text
                    .Item("sSize") = txtSize.Text
                    .Item("sUnitPrice") = txtUnitPrice.Text
                    .Item("sName") = txtName.Text
                End With
                adShoe.UpdateCommand = cmBuilder.GetUpdateCommand
                MessageBox.Show("Data Saved Successfully", Me.Text, MessageBoxButtons.OK)
            End If
            con.Open()
            Try
                adShoe.Update(dsShoe, "shoe")
            Catch ex As Exception
                MessageBox.Show("You are trying to save data incorrectly...")
            End Try
            con.Close()
        End If
        txtDesignID.Enabled = True
        txtSize.Enabled = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Sub txtSearchSize_TextChanged(sender As Object, e As EventArgs) Handles txtSearchSize.TextChanged
        If IsNumeric(txtSearchSize.Text) = False Then
            MessageBox.Show("Please enter numbers only", Me.Text, MessageBoxButtons.OK)
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim tbShoe As DataTable
        Dim dcPrimaryKey(1) As DataColumn
        tbShoe = dsShoe.Tables("shoe")
        dcPrimaryKey(0) = tbShoe.Columns("sDesignID")
        dcPrimaryKey(1) = tbShoe.Columns("sSize")
        tbShoe.PrimaryKey = dcPrimaryKey

        Dim drShoe As DataRow = tbShoe.Rows.Find({txtSeachDesID.Text, txtSearchSize.Text})
        If Not drShoe Is Nothing Then
            With drShoe
                txtDesignID.Text = .Item("sDesignID")
                txtName.Text = .Item("sName")
                txtManDate.Text = .Item("sManDate")
                txtQuantity.Text = .Item("sQuantity")
                txtSize.Text = .Item("sSize")
                txtUnitPrice.Text = .Item("sUnitPrice")
            End With
        Else
            MessageBox.Show("Selected Shoe Not Found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Private Sub txtUnitPrice_TextChanged(sender As Object, e As EventArgs) Handles txtUnitPrice.TextChanged
        If txtUnitPrice.Text = "" Then
            txtUnitPrice.Text = ""
            'ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtUnitPrice.Text, "^[0-9\S]+$") = False Then
            '    MessageBox.Show("Please enter Amount", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    txtUnitPrice.Text = txtUnitPrice.Text.Remove(txtUnitPrice.Text.Length - 1)
            '    txtUnitPrice.SelectionStart = txtUnitPrice.Text.Length
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtUnitPrice.Text, "^[0-9\s]+$") = False Then
            Dim count, rempos As Integer
            Dim a As String
            Dim sb As New System.Text.StringBuilder
            a = txtUnitPrice.Text

            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[0-9\s]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtUnitPrice.Text = a
            If txtUnitPrice.Text.Length > 0 Then
                txtUnitPrice.SelectionStart = rempos - 1
                txtUnitPrice.SelectionLength = 0
            Else
                txtUnitPrice.SelectionStart = txtUnitPrice.Text.Length
            End If
            MessageBox.Show("Letters and Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'txtName.Text = txtName.Text.Remove(txtName.Text.Length - 1)
            'txtName.SelectionStart = txtName.Text.Length
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        If txtQuantity.Text = "" Then

        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "^[0-9\S]+$") = False Then
            MessageBox.Show("Please enter quantity as numbers", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtQuantity.Text = txtQuantity.Text.Remove(txtQuantity.Text.Length - 1)
            txtQuantity.SelectionStart = txtQuantity.Text.Length
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "^[0-9\s]+$") = False Then
            Dim count, rempos As Integer
            Dim a As String
            Dim sb As New System.Text.StringBuilder
            a = txtQuantity.Text

            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[0-9\s]+$") = True Then
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
            MessageBox.Show("Letters and Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub txtDesignID_Enter(sender As Object, e As EventArgs) Handles txtDesignID.Enter
        txtDesignID.BackColor = Color.White
    End Sub

    Private Sub txtDesignID_TextChanged(sender As Object, e As EventArgs) Handles txtDesignID.TextChanged
        If txtDesignID.Text = "" Then
            txtDesignID.Text = ""
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtDesignID.Text, "^[A-Za-z0-9]+$") = False Then
            MessageBox.Show("No Special Character Allowed in this field.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtDesignID.Text = txtDesignID.Text.Remove(txtDesignID.Text.Length - 1)
            txtDesignID.SelectionStart = txtDesignID.Text.Length
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtDesignID.Text, "^[A-Za-z0-9]+$") = False Then
            Dim count, rempos As Integer
            Dim a As String
            Dim sb As New System.Text.StringBuilder
            a = txtDesignID.Text

            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[A-Za-z0-9]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtDesignID.Text = a
            If txtDesignID.Text.Length > 0 Then
                txtDesignID.SelectionStart = rempos - 1
                txtDesignID.SelectionLength = 0
            Else
                txtDesignID.SelectionStart = txtDesignID.Text.Length
            End If
            MessageBox.Show("Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'txtName.Text = txtName.Text.Remove(txtName.Text.Length - 1)
            'txtName.SelectionStart = txtName.Text.Length
        End If

    End Sub

    Private Sub txtSize_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles txtSize.ContextMenuStripChanged

    End Sub

    Private Sub txtSize_Enter(sender As Object, e As EventArgs) Handles txtSize.Enter
        txtSize.BackColor = Color.White
    End Sub

    Private Sub txtSize_TextChanged(sender As Object, e As EventArgs) Handles txtSize.TextChanged
        If txtSize.Text = "" Then
            txtSize.Text = ""
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtSize.Text, "^[0-9]+$") = False Then
            Dim count, rempos As Integer
            Dim a As String
            Dim sb As New System.Text.StringBuilder
            a = txtName.Text

            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[0-9]+$") = True Then
                    sb.Append(c)
                Else
                    rempos = count
                End If
            Next
            a = sb.ToString
            txtSize.Text = a
            If txtSize.Text.Length > 0 Then
                txtSize.SelectionStart = rempos - 1
                txtSize.SelectionLength = 0
            Else
                txtSize.SelectionStart = txtSize.Text.Length
            End If
            MessageBox.Show("Letters and Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'txtName.Text = txtName.Text.Remove(txtName.Text.Length - 1)
            'txtName.SelectionStart = txtName.Text.Length
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        If txtName.Text = "" Then
            txtName.Text = ""
        ElseIf System.Text.RegularExpressions.Regex.IsMatch(txtName.Text, "^[A-Za-z0-9\s]+$") = False Then
            Dim count, rempos As Integer
            Dim a As String
            Dim sb As New System.Text.StringBuilder
            a = txtName.Text

            For Each c As Char In a
                count = count + 1
                If System.Text.RegularExpressions.Regex.IsMatch(c, "^[A-Za-z0-9\s]+$") = True Then
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
            MessageBox.Show("Numbers and Special Characters are not allowed.", "Invalid input!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'txtName.Text = txtName.Text.Remove(txtName.Text.Length - 1)
            'txtName.SelectionStart = txtName.Text.Length
        End If
    End Sub

    Private Sub txtManDate_TextChanged(sender As Object, e As EventArgs) Handles txtManDate.TextChanged

    End Sub

    
    Private Sub txtSeachDesID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSeachDesID.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtSearchSize.Text = "" Then
                txtSearchSize.Focus()
            Else
                Dim tbShoe As DataTable
                Dim dcPrimaryKey(1) As DataColumn
                tbShoe = dsShoe.Tables("shoe")
                dcPrimaryKey(0) = tbShoe.Columns("sDesignID")
                dcPrimaryKey(1) = tbShoe.Columns("sSize")
                tbShoe.PrimaryKey = dcPrimaryKey

                Dim drShoe As DataRow = tbShoe.Rows.Find({txtSeachDesID.Text, txtSearchSize.Text})
                If Not drShoe Is Nothing Then
                    With drShoe
                        txtDesignID.Text = .Item("sDesignID")
                        txtName.Text = .Item("sName")
                        txtManDate.Text = .Item("sManDate")
                        txtQuantity.Text = .Item("sQuantity")
                        txtSize.Text = .Item("sSize")
                        txtUnitPrice.Text = .Item("sUnitPrice")
                    End With
                Else
                    MessageBox.Show("Selected Shoe Not Found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub txtSearchSize_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchSize.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtSeachDesID.Text = "" Then
                txtSeachDesID.Focus()
            Else
                Dim tbShoe As DataTable
                Dim dcPrimaryKey(1) As DataColumn
                tbShoe = dsShoe.Tables("shoe")
                dcPrimaryKey(0) = tbShoe.Columns("sDesignID")
                dcPrimaryKey(1) = tbShoe.Columns("sSize")
                tbShoe.PrimaryKey = dcPrimaryKey

                Dim drShoe As DataRow = tbShoe.Rows.Find({txtSeachDesID.Text, txtSearchSize.Text})
                If Not drShoe Is Nothing Then
                    With drShoe
                        txtDesignID.Text = .Item("sDesignID")
                        txtName.Text = .Item("sName")
                        txtManDate.Text = .Item("sManDate")
                        txtQuantity.Text = .Item("sQuantity")
                        txtSize.Text = .Item("sSize")
                        txtUnitPrice.Text = .Item("sUnitPrice")
                    End With
                Else
                    MessageBox.Show("Selected Shoe Not Found.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub
End Class