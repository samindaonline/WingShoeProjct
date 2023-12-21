<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportInventory
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportInventory))
        Me.tblShoeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.wing_shoeDataSet = New Test_Project_01.wing_shoeDataSet()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.tblShoeTableAdapter = New Test_Project_01.wing_shoeDataSetTableAdapters.tblShoeTableAdapter()
        CType(Me.tblShoeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.wing_shoeDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tblShoeBindingSource
        '
        Me.tblShoeBindingSource.DataMember = "tblShoe"
        Me.tblShoeBindingSource.DataSource = Me.wing_shoeDataSet
        '
        'wing_shoeDataSet
        '
        Me.wing_shoeDataSet.DataSetName = "wing_shoeDataSet"
        Me.wing_shoeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "dsInventory"
        ReportDataSource1.Value = Me.tblShoeBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Test_Project_01.rptInventory.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(692, 358)
        Me.ReportViewer1.TabIndex = 0
        '
        'tblShoeTableAdapter
        '
        Me.tblShoeTableAdapter.ClearBeforeFill = True
        '
        'frmReportInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 358)
        Me.Controls.Add(Me.ReportViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportInventory"
        Me.Text = "Inventory Report"
        CType(Me.tblShoeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.wing_shoeDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents tblShoeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents wing_shoeDataSet As Test_Project_01.wing_shoeDataSet
    Friend WithEvents tblShoeTableAdapter As Test_Project_01.wing_shoeDataSetTableAdapters.tblShoeTableAdapter
End Class
