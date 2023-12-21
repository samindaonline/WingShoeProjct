<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        Me.btnNewOrder = New System.Windows.Forms.Button()
        Me.btnViewOrderHistory = New System.Windows.Forms.Button()
        Me.btnEditOrder = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnUpCustomer = New System.Windows.Forms.Button()
        Me.btnViewCus = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnInventoryReport = New System.Windows.Forms.Button()
        Me.btnUpInventory = New System.Windows.Forms.Button()
        Me.txtShoeSearch = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNewOrder
        '
        Me.btnNewOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnNewOrder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnNewOrder.Location = New System.Drawing.Point(8, 23)
        Me.btnNewOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewOrder.Name = "btnNewOrder"
        Me.btnNewOrder.Size = New System.Drawing.Size(175, 65)
        Me.btnNewOrder.TabIndex = 0
        Me.btnNewOrder.Text = "New Order"
        Me.btnNewOrder.UseVisualStyleBackColor = False
        '
        'btnViewOrderHistory
        '
        Me.btnViewOrderHistory.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnViewOrderHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewOrderHistory.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewOrderHistory.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnViewOrderHistory.Location = New System.Drawing.Point(8, 96)
        Me.btnViewOrderHistory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewOrderHistory.Name = "btnViewOrderHistory"
        Me.btnViewOrderHistory.Size = New System.Drawing.Size(174, 28)
        Me.btnViewOrderHistory.TabIndex = 1
        Me.btnViewOrderHistory.Text = "View Order History"
        Me.btnViewOrderHistory.UseVisualStyleBackColor = False
        '
        'btnEditOrder
        '
        Me.btnEditOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(55, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnEditOrder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEditOrder.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditOrder.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnEditOrder.Location = New System.Drawing.Point(8, 131)
        Me.btnEditOrder.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEditOrder.Name = "btnEditOrder"
        Me.btnEditOrder.Size = New System.Drawing.Size(175, 28)
        Me.btnEditOrder.TabIndex = 2
        Me.btnEditOrder.Text = "Edit Orders"
        Me.btnEditOrder.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnEditOrder)
        Me.GroupBox1.Controls.Add(Me.btnNewOrder)
        Me.GroupBox1.Controls.Add(Me.btnViewOrderHistory)
        Me.GroupBox1.Location = New System.Drawing.Point(690, 13)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(192, 170)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Order"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnUpCustomer)
        Me.GroupBox2.Controls.Add(Me.btnViewCus)
        Me.GroupBox2.Location = New System.Drawing.Point(690, 370)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(192, 168)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer"
        '
        'btnUpCustomer
        '
        Me.btnUpCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnUpCustomer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpCustomer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnUpCustomer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnUpCustomer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnUpCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpCustomer.Location = New System.Drawing.Point(8, 23)
        Me.btnUpCustomer.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpCustomer.Name = "btnUpCustomer"
        Me.btnUpCustomer.Size = New System.Drawing.Size(174, 65)
        Me.btnUpCustomer.TabIndex = 3
        Me.btnUpCustomer.Text = "Update Customer List"
        Me.btnUpCustomer.UseVisualStyleBackColor = False
        '
        'btnViewCus
        '
        Me.btnViewCus.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnViewCus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnViewCus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnViewCus.Location = New System.Drawing.Point(8, 95)
        Me.btnViewCus.Margin = New System.Windows.Forms.Padding(4)
        Me.btnViewCus.Name = "btnViewCus"
        Me.btnViewCus.Size = New System.Drawing.Size(175, 65)
        Me.btnViewCus.TabIndex = 4
        Me.btnViewCus.Text = "View Customer List"
        Me.btnViewCus.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btnInventoryReport)
        Me.GroupBox3.Controls.Add(Me.btnUpInventory)
        Me.GroupBox3.Location = New System.Drawing.Point(690, 191)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox3.Size = New System.Drawing.Size(192, 171)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Shoe Store"
        '
        'btnInventoryReport
        '
        Me.btnInventoryReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.btnInventoryReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnInventoryReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnInventoryReport.Location = New System.Drawing.Point(8, 97)
        Me.btnInventoryReport.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInventoryReport.Name = "btnInventoryReport"
        Me.btnInventoryReport.Size = New System.Drawing.Size(174, 65)
        Me.btnInventoryReport.TabIndex = 6
        Me.btnInventoryReport.Text = "Store Report"
        Me.btnInventoryReport.UseVisualStyleBackColor = False
        '
        'btnUpInventory
        '
        Me.btnUpInventory.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(194, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.btnUpInventory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpInventory.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpInventory.Location = New System.Drawing.Point(8, 24)
        Me.btnUpInventory.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUpInventory.Name = "btnUpInventory"
        Me.btnUpInventory.Size = New System.Drawing.Size(174, 65)
        Me.btnUpInventory.TabIndex = 5
        Me.btnUpInventory.Text = "Update Store"
        Me.btnUpInventory.UseVisualStyleBackColor = False
        '
        'txtShoeSearch
        '
        Me.txtShoeSearch.BackColor = System.Drawing.Color.White
        Me.txtShoeSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtShoeSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShoeSearch.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.txtShoeSearch.Location = New System.Drawing.Point(109, 13)
        Me.txtShoeSearch.Name = "txtShoeSearch"
        Me.txtShoeSearch.Size = New System.Drawing.Size(149, 24)
        Me.txtShoeSearch.TabIndex = 7
        Me.txtShoeSearch.Text = "Shoe Search"
        Me.txtShoeSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Location = New System.Drawing.Point(109, 43)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(94, 27)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Test_Project_01.My.Resources.Resources.logo_no_background
        Me.PictureBox1.InitialImage = Global.Test_Project_01.My.Resources.Resources.logo_no_background
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(90, 88)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = Global.Test_Project_01.My.Resources.Resources.dashboardback2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(895, 547)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtShoeSearch)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNewOrder As System.Windows.Forms.Button
    Friend WithEvents btnViewOrderHistory As System.Windows.Forms.Button
    Friend WithEvents btnEditOrder As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnViewCus As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnUpInventory As System.Windows.Forms.Button
    Friend WithEvents btnInventoryReport As System.Windows.Forms.Button
    Friend WithEvents btnUpCustomer As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtShoeSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
