<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewOrderHistory
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.wing_shoeDataSet = New Test_Project_01.wing_shoeDataSet()
        Me.tblOrderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tblOrderTableAdapter = New Test_Project_01.wing_shoeDataSetTableAdapters.tblOrderTableAdapter()
        CType(Me.wing_shoeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblOrderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "OrderHistory"
        ReportDataSource1.Value = Me.tblOrderBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Test_Project_01.ReportViewOrderHistory.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(734, 431)
        Me.ReportViewer1.TabIndex = 0
        '
        'wing_shoeDataSet
        '
        Me.wing_shoeDataSet.DataSetName = "wing_shoeDataSet"
        Me.wing_shoeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'tblOrderBindingSource
        '
        Me.tblOrderBindingSource.DataMember = "tblOrder"
        Me.tblOrderBindingSource.DataSource = Me.wing_shoeDataSet
        '
        'tblOrderTableAdapter
        '
        Me.tblOrderTableAdapter.ClearBeforeFill = True
        '
        'frmViewOrderHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 431)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmViewOrderHistory"
        Me.Text = "frmViewOrderHistory"
        CType(Me.wing_shoeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblOrderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblOrderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents wing_shoeDataSet As Test_Project_01.wing_shoeDataSet
    Friend WithEvents tblOrderTableAdapter As Test_Project_01.wing_shoeDataSetTableAdapters.tblOrderTableAdapter
End Class
