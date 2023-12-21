Imports System.Data.OleDb
Public Class frmShoeSearch
    Dim dsShoe As New DataSet
    Dim adShoe As New OleDbDataAdapter
    Dim n As Integer
    Private Sub frmShoeSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.Open()
        Dim cmShoe As New OleDbCommand
        cmShoe.Connection = con
        cmShoe.CommandText = "SELECT * FROM tblShoe"
        adShoe.SelectCommand = cmShoe
        adShoe.Fill(dsShoe, "shoe")
        n = dsShoe.Tables("shoe").Rows.Count - 1
        con.Close()

        DGShoeSearch.ColumnCount = 5
        DGShoeSearch.Columns(0).Name = "Design ID"
        DGShoeSearch.Columns(1).Name = "Design Name"
        DGShoeSearch.Columns(2).Name = "Size"
        DGShoeSearch.Columns(3).Name = "In stock"
        DGShoeSearch.Columns(4).Name = "Unit Price(Rs.)"
        DGShoeSearch.Columns(0).Width = 100
        DGShoeSearch.Columns(1).Width = 230
        DGShoeSearch.Columns(2).Width = 60
        DGShoeSearch.Columns(3).Width = 70
        DGShoeSearch.Columns(4).Width = 116

        Dim tbShoe As DataTable
        Dim dcPrimaryKey1(1) As DataColumn
        tbShoe = dsShoe.Tables("shoe")
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
                        DGShoeSearch.Rows.Add(.Item("sDesignID"), .Item("sName"), .Item("sSize"), .Item("sQuantity"), .Item("sUnitPrice"))
                    End With
                End If
            End If
            intSize = intSize + 1
        End While

    End Sub
End Class