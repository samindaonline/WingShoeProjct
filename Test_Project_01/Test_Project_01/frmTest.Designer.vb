<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTest
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnSDSubTotal = New System.Windows.Forms.Button()
        Me.txtSDSubtotal = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSDQty = New System.Windows.Forms.TextBox()
        Me.btnAddtoOrder = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtShoeDesignID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtShoesSize = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtShoesName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtShoesUnitPrice = New System.Windows.Forms.TextBox()
        Me.lblShoesSize = New System.Windows.Forms.Label()
        Me.txtShoesQuantity = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtSearchSize = New System.Windows.Forms.TextBox()
        Me.btnShoeSearch = New System.Windows.Forms.Button()
        Me.txtShoeSeach = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnSDSubTotal)
        Me.GroupBox3.Controls.Add(Me.txtSDSubtotal)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtSDQty)
        Me.GroupBox3.Controls.Add(Me.btnAddtoOrder)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 336)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(234, 157)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Add to Order"
        '
        'btnSDSubTotal
        '
        Me.btnSDSubTotal.Location = New System.Drawing.Point(117, 77)
        Me.btnSDSubTotal.Name = "btnSDSubTotal"
        Me.btnSDSubTotal.Size = New System.Drawing.Size(100, 23)
        Me.btnSDSubTotal.TabIndex = 6
        Me.btnSDSubTotal.Text = "Total"
        Me.btnSDSubTotal.UseVisualStyleBackColor = True
        '
        'txtSDSubtotal
        '
        Me.txtSDSubtotal.Location = New System.Drawing.Point(117, 51)
        Me.txtSDSubtotal.Name = "txtSDSubtotal"
        Me.txtSDSubtotal.Size = New System.Drawing.Size(100, 20)
        Me.txtSDSubtotal.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(19, 54)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Subtotal"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Shoe Qty."
        '
        'txtSDQty
        '
        Me.txtSDQty.Location = New System.Drawing.Point(117, 25)
        Me.txtSDQty.Name = "txtSDQty"
        Me.txtSDQty.Size = New System.Drawing.Size(100, 20)
        Me.txtSDQty.TabIndex = 0
        '
        'btnAddtoOrder
        '
        Me.btnAddtoOrder.Location = New System.Drawing.Point(11, 106)
        Me.btnAddtoOrder.Name = "btnAddtoOrder"
        Me.btnAddtoOrder.Size = New System.Drawing.Size(206, 23)
        Me.btnAddtoOrder.TabIndex = 3
        Me.btnAddtoOrder.Text = "Add to Order"
        Me.btnAddtoOrder.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtShoeDesignID)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtShoesSize)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtShoesName)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtShoesUnitPrice)
        Me.GroupBox2.Controls.Add(Me.lblShoesSize)
        Me.GroupBox2.Controls.Add(Me.txtShoesQuantity)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 173)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(234, 157)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search Result"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "sDesignID"
        '
        'txtShoeDesignID
        '
        Me.txtShoeDesignID.Location = New System.Drawing.Point(117, 14)
        Me.txtShoeDesignID.Name = "txtShoeDesignID"
        Me.txtShoeDesignID.Size = New System.Drawing.Size(100, 20)
        Me.txtShoeDesignID.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "sQuantity"
        '
        'txtShoesSize
        '
        Me.txtShoesSize.Location = New System.Drawing.Point(117, 40)
        Me.txtShoesSize.Name = "txtShoesSize"
        Me.txtShoesSize.Size = New System.Drawing.Size(100, 20)
        Me.txtShoesSize.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "sUnitPrice"
        '
        'txtShoesName
        '
        Me.txtShoesName.Location = New System.Drawing.Point(117, 66)
        Me.txtShoesName.Name = "txtShoesName"
        Me.txtShoesName.Size = New System.Drawing.Size(100, 20)
        Me.txtShoesName.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "sName"
        '
        'txtShoesUnitPrice
        '
        Me.txtShoesUnitPrice.Location = New System.Drawing.Point(117, 92)
        Me.txtShoesUnitPrice.Name = "txtShoesUnitPrice"
        Me.txtShoesUnitPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtShoesUnitPrice.TabIndex = 0
        '
        'lblShoesSize
        '
        Me.lblShoesSize.AutoSize = True
        Me.lblShoesSize.Location = New System.Drawing.Point(19, 43)
        Me.lblShoesSize.Name = "lblShoesSize"
        Me.lblShoesSize.Size = New System.Drawing.Size(32, 13)
        Me.lblShoesSize.TabIndex = 4
        Me.lblShoesSize.Text = "sSize"
        '
        'txtShoesQuantity
        '
        Me.txtShoesQuantity.Location = New System.Drawing.Point(117, 118)
        Me.txtShoesQuantity.Name = "txtShoesQuantity"
        Me.txtShoesQuantity.Size = New System.Drawing.Size(100, 20)
        Me.txtShoesQuantity.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSearchSize)
        Me.GroupBox1.Controls.Add(Me.btnShoeSearch)
        Me.GroupBox1.Controls.Add(Me.txtShoeSeach)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 157)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search Item"
        '
        'txtSearchSize
        '
        Me.txtSearchSize.Location = New System.Drawing.Point(13, 87)
        Me.txtSearchSize.Name = "txtSearchSize"
        Me.txtSearchSize.Size = New System.Drawing.Size(100, 20)
        Me.txtSearchSize.TabIndex = 5
        '
        'btnShoeSearch
        '
        Me.btnShoeSearch.Location = New System.Drawing.Point(11, 113)
        Me.btnShoeSearch.Name = "btnShoeSearch"
        Me.btnShoeSearch.Size = New System.Drawing.Size(206, 23)
        Me.btnShoeSearch.TabIndex = 1
        Me.btnShoeSearch.Text = "Search"
        Me.btnShoeSearch.UseVisualStyleBackColor = True
        '
        'txtShoeSeach
        '
        Me.txtShoeSeach.Location = New System.Drawing.Point(13, 41)
        Me.txtShoeSeach.Name = "txtShoeSeach"
        Me.txtShoeSeach.Size = New System.Drawing.Size(204, 20)
        Me.txtShoeSeach.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Enter Shoe Design ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Enter Shoe Size"
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(258, 505)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmTest"
        Me.Text = "frmTest"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSDSubTotal As System.Windows.Forms.Button
    Friend WithEvents txtSDSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSDQty As System.Windows.Forms.TextBox
    Friend WithEvents btnAddtoOrder As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShoeDesignID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtShoesSize As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtShoesName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtShoesUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents lblShoesSize As System.Windows.Forms.Label
    Friend WithEvents txtShoesQuantity As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearchSize As System.Windows.Forms.TextBox
    Friend WithEvents btnShoeSearch As System.Windows.Forms.Button
    Friend WithEvents txtShoeSeach As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
