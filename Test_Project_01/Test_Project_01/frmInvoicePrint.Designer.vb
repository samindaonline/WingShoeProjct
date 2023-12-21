<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoicePrint
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoicePrint))
        Me.tblContainBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.wing_shoeDataSet = New Test_Project_01.wing_shoeDataSet()
        Me.tblOrderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tblCustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.tblShoeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.qryBillBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tblContainTableAdapter = New Test_Project_01.wing_shoeDataSetTableAdapters.tblContainTableAdapter()
        Me.tblOrderTableAdapter = New Test_Project_01.wing_shoeDataSetTableAdapters.tblOrderTableAdapter()
        Me.tblCustomerTableAdapter = New Test_Project_01.wing_shoeDataSetTableAdapters.tblCustomerTableAdapter()
        Me.tblShoeTableAdapter = New Test_Project_01.wing_shoeDataSetTableAdapters.tblShoeTableAdapter()
        Me.qryBillTableAdapter = New Test_Project_01.wing_shoeDataSetTableAdapters.qryBillTableAdapter()
        CType(Me.tblContainBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wing_shoeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblOrderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblCustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblShoeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.qryBillBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblContainBindingSource
        '
        Me.tblContainBindingSource.DataMember = "tblContain"
        Me.tblContainBindingSource.DataSource = Me.wing_shoeDataSet
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
        'tblCustomerBindingSource
        '
        Me.tblCustomerBindingSource.DataMember = "tblCustomer"
        Me.tblCustomerBindingSource.DataSource = Me.wing_shoeDataSet
        '
        'tblShoeBindingSource
        '
        Me.tblShoeBindingSource.DataMember = "tblShoe"
        Me.tblShoeBindingSource.DataSource = Me.wing_shoeDataSet
        '
        'qryBillBindingSource
        '
        Me.qryBillBindingSource.DataMember = "qryBill"
        Me.qryBillBindingSource.DataSource = Me.wing_shoeDataSet
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsBillContain"
        ReportDataSource1.Value = Me.tblContainBindingSource
        ReportDataSource2.Name = "dsBillOrder"
        ReportDataSource2.Value = Me.tblOrderBindingSource
        ReportDataSource3.Name = "dsBillCustomer"
        ReportDataSource3.Value = Me.tblCustomerBindingSource
        ReportDataSource4.Name = "dsBillShoe"
        ReportDataSource4.Value = Me.tblShoeBindingSource
        ReportDataSource5.Name = "dsBillInvoice"
        ReportDataSource5.Value = Me.qryBillBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Test_Project_01.rptReceipt.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(377, 512)
        Me.ReportViewer1.TabIndex = 0
        '
        'tblContainTableAdapter
        '
        Me.tblContainTableAdapter.ClearBeforeFill = True
        '
        'tblOrderTableAdapter
        '
        Me.tblOrderTableAdapter.ClearBeforeFill = True
        '
        'tblCustomerTableAdapter
        '
        Me.tblCustomerTableAdapter.ClearBeforeFill = True
        '
        'tblShoeTableAdapter
        '
        Me.tblShoeTableAdapter.ClearBeforeFill = True
        '
        'qryBillTableAdapter
        '
        Me.qryBillTableAdapter.ClearBeforeFill = True
        '
        'frmInvoicePrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 512)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInvoicePrint"
        Me.Text = "Print View"
        CType(Me.tblContainBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wing_shoeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblOrderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblCustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblShoeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.qryBillBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblContainBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents wing_shoeDataSet As Test_Project_01.wing_shoeDataSet
    Friend WithEvents tblOrderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tblCustomerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tblShoeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents qryBillBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents tblContainTableAdapter As Test_Project_01.wing_shoeDataSetTableAdapters.tblContainTableAdapter
    Friend WithEvents tblOrderTableAdapter As Test_Project_01.wing_shoeDataSetTableAdapters.tblOrderTableAdapter
    Friend WithEvents tblCustomerTableAdapter As Test_Project_01.wing_shoeDataSetTableAdapters.tblCustomerTableAdapter
    Friend WithEvents tblShoeTableAdapter As Test_Project_01.wing_shoeDataSetTableAdapters.tblShoeTableAdapter
    Friend WithEvents qryBillTableAdapter As Test_Project_01.wing_shoeDataSetTableAdapters.qryBillTableAdapter
End Class
