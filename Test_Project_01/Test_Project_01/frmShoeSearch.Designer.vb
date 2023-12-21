<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShoeSearch
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
        Me.DGShoeSearch = New System.Windows.Forms.DataGridView()
        CType(Me.DGShoeSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGShoeSearch
        '
        Me.DGShoeSearch.AllowUserToAddRows = False
        Me.DGShoeSearch.AllowUserToDeleteRows = False
        Me.DGShoeSearch.AllowUserToResizeColumns = False
        Me.DGShoeSearch.AllowUserToResizeRows = False
        Me.DGShoeSearch.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DGShoeSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGShoeSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DGShoeSearch.GridColor = System.Drawing.SystemColors.Control
        Me.DGShoeSearch.Location = New System.Drawing.Point(13, 14)
        Me.DGShoeSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DGShoeSearch.Name = "DGShoeSearch"
        Me.DGShoeSearch.RowHeadersVisible = False
        Me.DGShoeSearch.Size = New System.Drawing.Size(571, 266)
        Me.DGShoeSearch.TabIndex = 0
        '
        'frmShoeSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 294)
        Me.Controls.Add(Me.DGShoeSearch)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmShoeSearch"
        Me.Text = "Shoe Search"
        CType(Me.DGShoeSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DGShoeSearch As System.Windows.Forms.DataGridView
End Class
