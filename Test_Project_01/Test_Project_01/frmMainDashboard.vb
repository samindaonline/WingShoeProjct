Imports System.Windows.Forms

Public Class frmMainDashboard

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub



    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub StatusStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip.ItemClicked

    End Sub

    Private Sub ToolStripStatusLabel1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MenuStrip_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub AddNewCustomerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewCustomerToolStripMenuItem.Click
        Dim frmCustomerUpdate As New frmCustomerUpdate
        frmCustomerUpdate.MdiParent = Me
        'frmCustomerUpdate.WindowState = FormWindowState.Maximized
        frmCustomerUpdate.Show()
    End Sub

    Private Sub frmMainDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each ctl As Control In Me.Controls
            Try
                Dim Mdi As System.Windows.Forms.Control = CType(ctl, MdiClient)
                Mdi.BackColor = System.Drawing.SystemColors.Control
            Catch a As Exception

            End Try
        Next
        'dbmain()
        Module1.main()

        Timer1.Start()
        Timer1.Interval = 100


        If Module1.loginStatus = "" Then
            CustomerToolStripMenuItem.Enabled = False
            OrderToolStripMenuItem.Enabled = False
            StoresToolStripMenuItem.Enabled = False
            ReportsToolStripMenuItem.Enabled = False
            LogOutToolStripMenuItem.Enabled = False
            HomeToolStripMenuItem.Enabled = False
        Else

        End If
        Dim frmlogin As New frmLogin
        frmlogin.MdiParent = Me
        frmlogin.Show()


    End Sub

    Sub dbmain()
        con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\WingShoeProjct\wing_shoe.mdb"
        'con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Database\wing_shoe.mdb"

        'Dim frmlogin As New frmLogin
        'frmlogin.ShowDialog()

       
    End Sub

    Private Sub AddNewOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddNewOrderToolStripMenuItem.Click
        Dim frmmain As New frmMain
        frmmain.MdiParent = Me
        frmmain.Show()
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        For Each afroms As Form In Me.MdiChildren
            afroms.Close()
        Next

        Dim frmDashboard As New frmDashboard
        frmDashboard.MdiParent = Me
        frmDashboard.Show()
    End Sub

    Private Sub LogInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogInToolStripMenuItem.Click
        Dim frmlogin As New frmLogin
        frmlogin.MdiParent = Me
        frmlogin.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Module1.loginStatus = "NOT" Then
            CustomerToolStripMenuItem.Enabled = False
            OrderToolStripMenuItem.Enabled = False
            StoresToolStripMenuItem.Enabled = False
            ReportsToolStripMenuItem.Enabled = False
            LogOutToolStripMenuItem.Enabled = False
            HomeToolStripMenuItem.Enabled = False
            username.Text = "Logged in as " & Module1.user
        End If

        If Module1.loginStatus = "OK" Then
            CustomerToolStripMenuItem.Enabled = True
            OrderToolStripMenuItem.Enabled = True
            StoresToolStripMenuItem.Enabled = True
            ReportsToolStripMenuItem.Enabled = True
            LogOutToolStripMenuItem.Enabled = True
            HomeToolStripMenuItem.Enabled = True
            CustomerListToolStripMenuItem.Enabled = True
            OrderHistoryToolStripMenuItem.Enabled = True
            LogInToolStripMenuItem.Enabled = False
            username.Text = "Logged in as " & Module1.user
            formsCount.Text = "| Forms Opened:" & Me.MdiChildren.Count

            If Module1.user = "cashier" Then
                StoresToolStripMenuItem.Enabled = False
            ElseIf Module1.user = "storekeeper" Then
                CustomerListToolStripMenuItem.Enabled = False
                OrderToolStripMenuItem.Enabled = False
                CustomerToolStripMenuItem.Enabled = False
                OrderHistoryToolStripMenuItem.Enabled = False
            End If

        End If

    End Sub

    Private Sub LogOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogOutToolStripMenuItem.Click
        Module1.loginStatus = "NOT"
        Module1.user = "Not Logged"

        If Module1.loginStatus = "NOT" Then
            CustomerToolStripMenuItem.Enabled = False
            OrderToolStripMenuItem.Enabled = False
            StoresToolStripMenuItem.Enabled = False
            ReportsToolStripMenuItem.Enabled = False
            LogOutToolStripMenuItem.Enabled = False
            HomeToolStripMenuItem.Enabled = False

            For Each afroms As Form In Me.MdiChildren
                afroms.Close()
            Next

            Dim frmlogin As New frmLogin
            frmlogin.MdiParent = Me
            frmlogin.Show()

        End If
    End Sub

    Private Sub UpdateStoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateStoreToolStripMenuItem.Click
        Dim frmViewInventory As New frmViewInventory
        frmViewInventory.MdiParent = Me
        frmViewInventory.Show()
    End Sub

    Private Sub EditOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditOrderToolStripMenuItem.Click
        Dim frmViewOrder As New frmViewOrder
        frmViewOrder.MdiParent = Me
        frmViewOrder.Show()
    End Sub

    Private Sub CustomerListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerListToolStripMenuItem.Click
        Dim frmReportCustomer As New frmReportCustomerList
        frmReportCustomer.MdiParent = Me
        frmReportCustomer.Show()
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        Dim frmReportInventory As New frmReportInventory
        frmReportInventory.MdiParent = Me
        frmReportInventory.Show()
    End Sub

    Private Sub OrderHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OrderHistoryToolStripMenuItem.Click
        Dim frmReportOrder As New frmReportOrderHistory
        frmReportOrder.MdiParent = Me
        frmReportOrder.Show()
    End Sub
End Class
