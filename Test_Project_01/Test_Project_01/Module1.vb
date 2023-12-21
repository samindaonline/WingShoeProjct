Imports System.Data.OleDb
Module Module1
    Public strShoeSearch, strNewTP As String
    Public loginStatus As String = "NOT"
    Public strIADesign, strIASize, strIAName, strIAQuantity, strIAUnitPrice As String
    Public con As New OleDbConnection
    Public user As String = "No One"
    Public str() As String = {"0", "0", "0", "0", "0"}

    Public dsShoe As New DataSet
    Public adShoe As New OleDbDataAdapter
    Public nShoe As Integer

    Sub main()
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\WingShoeProjct\wing_shoe.mdb"
        'con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Database\wing_shoe.mdb"

        'Dim frmlogin As New frmLogin
        'frmlogin.ShowDialog()

        'Dim frmdashboard As New frmDashboard
        'frmdashboard.ShowDialog()

        'Dim frmMainDashboard As New frmMainDashboard
        'frmMainDashboard.ShowDialog()

        'Dim frmMain As New frmMain
        'frmMain.ShowDialog()

        'Dim frmItemAdd As New frmItemAdd
        'frmItemAdd.ShowDialog()
    End Sub
    
End Module
