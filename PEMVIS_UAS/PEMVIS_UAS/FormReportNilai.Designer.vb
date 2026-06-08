<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormReportNilai
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim DgvHeaderStyle As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DgvCellStyle As DataGridViewCellStyle = New DataGridViewCellStyle()

        PanelHeader = New Panel()
        LabelTitle = New Label()
        PanelFilter = New Panel()
        LabelFilterTitle = New Label()
        LabelMatkul = New Label()
        LabelSemester = New Label()
        LabelCari = New Label()
        ComboBoxMatkul = New ComboBox()
        ComboBoxSemester = New ComboBox()
        TextBoxCari = New TextBox()
        ButtonFilter = New Button()
        ButtonRefresh = New Button()
        ButtonPrint = New Button()
        PanelGrid = New Panel()
        DataGridViewNilai = New DataGridView()
        PanelFooter = New Panel()
        LabelTotalRecord = New Label()
        ButtonClose = New Button()
        PrintDocument1 = New Printing.PrintDocument()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PrintDialog1 = New PrintDialog()

        PanelHeader.SuspendLayout()
        PanelFilter.SuspendLayout()
        PanelGrid.SuspendLayout()
        CType(DataGridViewNilai, ComponentModel.ISupportInitialize).BeginInit()
        PanelFooter.SuspendLayout()
        SuspendLayout()

        ' PanelHeader
        PanelHeader.BackColor = Color.FromArgb(102, 187, 187)
        PanelHeader.Controls.Add(LabelTitle)
        PanelHeader.Dock = DockStyle.Top
        PanelHeader.Size = New Size(1100, 80)

        LabelTitle.AutoSize = True
        LabelTitle.Font = New Font("Segoe UI", 20.25F, FontStyle.Bold)
        LabelTitle.ForeColor = Color.White
        LabelTitle.Location = New Point(25, 18)
        LabelTitle.Text = "Report Nilai Mahasiswa"

        ' PanelFilter
        PanelFilter.BackColor = Color.FromArgb(220, 240, 240)
        PanelFilter.Controls.AddRange(New Control() {LabelFilterTitle, LabelMatkul, LabelSemester,
                                                      LabelCari, ComboBoxMatkul, ComboBoxSemester,
                                                      TextBoxCari, ButtonFilter, ButtonRefresh, ButtonPrint})
        PanelFilter.Dock = DockStyle.Top
        PanelFilter.Padding = New Padding(20, 15, 20, 15)
        PanelFilter.Size = New Size(1100, 120)

        LabelFilterTitle.AutoSize = True
        LabelFilterTitle.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold)
        LabelFilterTitle.ForeColor = Color.FromArgb(74, 144, 144)
        LabelFilterTitle.Location = New Point(23, 15)
        LabelFilterTitle.Text = "Filter Laporan"

        LabelMatkul.AutoSize = True
        LabelMatkul.Font = New Font("Segoe UI", 9.0F)
        LabelMatkul.ForeColor = Color.FromArgb(74, 144, 144)
        LabelMatkul.Location = New Point(23, 50)
        LabelMatkul.Text = "Mata Kuliah:"

        ComboBoxMatkul.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxMatkul.Font = New Font("Segoe UI", 9.0F)
        ComboBoxMatkul.Location = New Point(23, 70)
        ComboBoxMatkul.Size = New Size(270, 28)
        ComboBoxMatkul.FlatStyle = FlatStyle.Flat
        ComboBoxMatkul.BackColor = Color.White

        LabelSemester.AutoSize = True
        LabelSemester.Font = New Font("Segoe UI", 9.0F)
        LabelSemester.ForeColor = Color.FromArgb(74, 144, 144)
        LabelSemester.Location = New Point(310, 50)
        LabelSemester.Text = "Semester:"

        ComboBoxSemester.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxSemester.Font = New Font("Segoe UI", 9.0F)
        ComboBoxSemester.Location = New Point(310, 70)
        ComboBoxSemester.Size = New Size(150, 28)
        ComboBoxSemester.FlatStyle = FlatStyle.Flat
        ComboBoxSemester.BackColor = Color.White

        LabelCari.AutoSize = True
        LabelCari.Font = New Font("Segoe UI", 9.0F)
        LabelCari.ForeColor = Color.FromArgb(74, 144, 144)
        LabelCari.Location = New Point(480, 50)
        LabelCari.Text = "Cari NIM / Nama:"

        TextBoxCari.Font = New Font("Segoe UI", 9.0F)
        TextBoxCari.Location = New Point(480, 70)
        TextBoxCari.Size = New Size(220, 28)
        TextBoxCari.BorderStyle = BorderStyle.FixedSingle
        TextBoxCari.ForeColor = Color.FromArgb(74, 144, 144)

        ' ButtonFilter
        ButtonFilter.Text = "Filter"
        ButtonFilter.Location = New Point(720, 65)
        ButtonFilter.Size = New Size(100, 32)
        ButtonFilter.BackColor = Color.FromArgb(102, 187, 187)
        ButtonFilter.ForeColor = Color.White
        ButtonFilter.FlatStyle = FlatStyle.Flat
        ButtonFilter.FlatAppearance.BorderSize = 0
        ButtonFilter.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)

        ' ButtonRefresh
        ButtonRefresh.Text = "Reset"
        ButtonRefresh.Location = New Point(830, 65)
        ButtonRefresh.Size = New Size(100, 32)
        ButtonRefresh.BackColor = Color.FromArgb(160, 160, 160)
        ButtonRefresh.ForeColor = Color.White
        ButtonRefresh.FlatStyle = FlatStyle.Flat
        ButtonRefresh.FlatAppearance.BorderSize = 0
        ButtonRefresh.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)

        ' ButtonPrint
        ButtonPrint.Text = "🖨 Print Preview"
        ButtonPrint.Location = New Point(940, 65)
        ButtonPrint.Size = New Size(140, 32)
        ButtonPrint.BackColor = Color.FromArgb(74, 144, 144)
        ButtonPrint.ForeColor = Color.White
        ButtonPrint.FlatStyle = FlatStyle.Flat
        ButtonPrint.FlatAppearance.BorderSize = 0
        ButtonPrint.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)

        ' PanelGrid
        PanelGrid.BackColor = Color.White
        PanelGrid.BorderStyle = BorderStyle.FixedSingle
        PanelGrid.Controls.Add(DataGridViewNilai)
        PanelGrid.Dock = DockStyle.Fill
        PanelGrid.Padding = New Padding(15, 10, 15, 10)

        ' DataGridViewNilai
        DgvHeaderStyle.BackColor = Color.FromArgb(102, 187, 187)
        DgvHeaderStyle.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        DgvHeaderStyle.ForeColor = Color.White
        DgvHeaderStyle.SelectionBackColor = Color.FromArgb(74, 144, 144)
        DgvHeaderStyle.SelectionForeColor = Color.White

        DgvCellStyle.BackColor = Color.White
        DgvCellStyle.Font = New Font("Segoe UI", 9.0F)
        DgvCellStyle.ForeColor = Color.FromArgb(74, 144, 144)
        DgvCellStyle.SelectionBackColor = Color.FromArgb(220, 240, 240)
        DgvCellStyle.SelectionForeColor = Color.FromArgb(74, 144, 144)

        DataGridViewNilai.ColumnHeadersDefaultCellStyle = DgvHeaderStyle
        DataGridViewNilai.DefaultCellStyle = DgvCellStyle
        DataGridViewNilai.BackgroundColor = Color.White
        DataGridViewNilai.BorderStyle = BorderStyle.None
        DataGridViewNilai.GridColor = Color.FromArgb(220, 240, 240)
        DataGridViewNilai.EnableHeadersVisualStyles = False
        DataGridViewNilai.Dock = DockStyle.Fill
        DataGridViewNilai.RowHeadersVisible = False
        DataGridViewNilai.TabIndex = 0

        ' PanelFooter
        PanelFooter.BackColor = Color.FromArgb(102, 187, 187)
        PanelFooter.Controls.AddRange(New Control() {LabelTotalRecord, ButtonClose})
        PanelFooter.Dock = DockStyle.Bottom
        PanelFooter.Size = New Size(1100, 55)

        LabelTotalRecord.AutoSize = True
        LabelTotalRecord.Font = New Font("Segoe UI", 9.75F)
        LabelTotalRecord.ForeColor = Color.White
        LabelTotalRecord.Location = New Point(25, 18)
        LabelTotalRecord.Text = "Total Record: 0 data"

        ButtonClose.BackColor = Color.FromArgb(74, 144, 144)
        ButtonClose.FlatAppearance.BorderSize = 0
        ButtonClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(94, 164, 164)
        ButtonClose.FlatStyle = FlatStyle.Flat
        ButtonClose.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        ButtonClose.ForeColor = Color.White
        ButtonClose.Size = New Size(110, 35)
        ButtonClose.Location = New Point(970, 10)
        ButtonClose.Text = "Tutup"
        ButtonClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.UseAntiAlias = True

        ' Form
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1100, 700)
        Controls.Add(PanelGrid)
        Controls.Add(PanelFooter)
        Controls.Add(PanelFilter)
        Controls.Add(PanelHeader)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormReportNilai"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Report Nilai"

        PanelHeader.ResumeLayout(False)
        PanelHeader.PerformLayout()
        PanelFilter.ResumeLayout(False)
        PanelFilter.PerformLayout()
        PanelGrid.ResumeLayout(False)
        CType(DataGridViewNilai, ComponentModel.ISupportInitialize).EndInit()
        PanelFooter.ResumeLayout(False)
        PanelFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PanelHeader As Panel
    Friend WithEvents LabelTitle As Label
    Friend WithEvents PanelFilter As Panel
    Friend WithEvents LabelFilterTitle As Label
    Friend WithEvents LabelMatkul As Label
    Friend WithEvents LabelSemester As Label
    Friend WithEvents LabelCari As Label
    Friend WithEvents ComboBoxMatkul As ComboBox
    Friend WithEvents ComboBoxSemester As ComboBox
    Friend WithEvents TextBoxCari As TextBox
    Friend WithEvents ButtonFilter As Button
    Friend WithEvents ButtonRefresh As Button
    Friend WithEvents ButtonPrint As Button
    Friend WithEvents PanelGrid As Panel
    Friend WithEvents DataGridViewNilai As DataGridView
    Friend WithEvents PanelFooter As Panel
    Friend WithEvents LabelTotalRecord As Label
    Friend WithEvents ButtonClose As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDialog1 As PrintDialog
End Class
