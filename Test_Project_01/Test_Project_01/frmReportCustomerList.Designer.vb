<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCustomerList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportCustomerList))
        Me.tblCustomerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.wing_shoeDataSet = New Test_Project_01.wing_shoeDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tblCustomerTableAdapter = New Test_Project_01.wing_shoeDataSetTableAdapters.tblCustomerTableAdapter()
        CType(Me.tblCustomerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wing_shoeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblCustomerBindingSource
        '
        Me.tblCustomerBindingSource.DataMember = "tblCustomer"
        Me.tblCustomerBindingSource.DataSource = Me.wing_shoeDataSet
        '
        'wing_shoeDataSet
        '
        Me.wing_shoeDataSet.DataSetName = "wing_shoeDataSet"
        Me.wing_shoeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsCustomerList"
        ReportDataSource1.Value = Me.tblCustomerBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Test_Project_01.rptCustomerList.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(587, 345)
        Me.ReportViewer1.TabIndex = 0
        '
        'tblCustomerTableAdapter
        '
        Me.tblCustomerTableAdapter.ClearBeforeFill = True
        '
        'frmReportCustomerList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(587, 345)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportCustomerList"
        Me.Text = "Customer List"
        CType(Me.tblCustomerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wing_shoeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblCustomerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents wing_shoeDataSet As Test_Project_01.wing_shoeDataSet
    Friend WithEvents tblCustomerTableAdapter As Test_Project_01.wing_shoeDataSetTableAdapters.tblCustomerTableAdapter
End Class
