namespace WindowsFormsExplorer.Samples.WorkbookView
{
    partial class DesignerAndExplorerDialogsSample
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesignerAndExplorerDialogsSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonWorkbookExplorer = new System.Windows.Forms.Button();
            this.buttonRangeExplorer = new System.Windows.Forms.Button();
            this.buttonWorkbookDesigner = new System.Windows.Forms.Button();
            this.buttonChartExplorer = new System.Windows.Forms.Button();
            this.buttonShapeExplorer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_shapeCategories_protection = new System.Windows.Forms.CheckBox();
            this.checkBox_shapeCategories_autoShape = new System.Windows.Forms.CheckBox();
            this.checkBox_shapeCategories_control = new System.Windows.Forms.CheckBox();
            this.checkBox_shapeCategories_line = new System.Windows.Forms.CheckBox();
            this.checkBox_shapeCategories_fill = new System.Windows.Forms.CheckBox();
            this.checkBox_shapeCategories_font = new System.Windows.Forms.CheckBox();
            this.checkBox_shapeCategories_alignment = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_chartCategories_chartData = new System.Windows.Forms.CheckBox();
            this.checkBox_chartCategories_axes = new System.Windows.Forms.CheckBox();
            this.checkBox_chartCategories_series = new System.Windows.Forms.CheckBox();
            this.checkBox_chartCategories_pageSetup = new System.Windows.Forms.CheckBox();
            this.checkBox_chartCategories_title = new System.Windows.Forms.CheckBox();
            this.checkBox_chartCategories_legend = new System.Windows.Forms.CheckBox();
            this.checkBox_chartCategories_plotArea = new System.Windows.Forms.CheckBox();
            this.checkBox_chartCategories_chartArea = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_rangeCategories_conditionalFormats = new System.Windows.Forms.CheckBox();
            this.checkBox_rangeCategories_validation = new System.Windows.Forms.CheckBox();
            this.checkBox_rangeCategories_interior = new System.Windows.Forms.CheckBox();
            this.checkBox_rangeCategories_protection = new System.Windows.Forms.CheckBox();
            this.checkBox_rangeCategories_hyperlink = new System.Windows.Forms.CheckBox();
            this.checkBox_rangeCategories_borders = new System.Windows.Forms.CheckBox();
            this.checkBox_rangeCategories_font = new System.Windows.Forms.CheckBox();
            this.checkBox_rangeCategories_alignment = new System.Windows.Forms.CheckBox();
            this.checkBox_rangeCategories_numberFormats = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.workbookView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 839);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(240, 3);
            this.workbookView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(481, 833);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(230, 833);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.buttonWorkbookExplorer, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonRangeExplorer, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonWorkbookDesigner, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonChartExplorer, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonShapeExplorer, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(230, 830);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // buttonWorkbookExplorer
            // 
            this.buttonWorkbookExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWorkbookExplorer.AutoSize = true;
            this.buttonWorkbookExplorer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonWorkbookExplorer.Location = new System.Drawing.Point(4, 34);
            this.buttonWorkbookExplorer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonWorkbookExplorer.Name = "buttonWorkbookExplorer";
            this.buttonWorkbookExplorer.Size = new System.Drawing.Size(222, 25);
            this.buttonWorkbookExplorer.TabIndex = 1;
            this.buttonWorkbookExplorer.Text = "Workbook Explorer";
            this.buttonWorkbookExplorer.UseVisualStyleBackColor = true;
            this.buttonWorkbookExplorer.Click += new System.EventHandler(this.buttonWorkbookExplorer_Click);
            // 
            // buttonRangeExplorer
            // 
            this.buttonRangeExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRangeExplorer.AutoSize = true;
            this.buttonRangeExplorer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRangeExplorer.Location = new System.Drawing.Point(4, 65);
            this.buttonRangeExplorer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRangeExplorer.Name = "buttonRangeExplorer";
            this.buttonRangeExplorer.Size = new System.Drawing.Size(222, 25);
            this.buttonRangeExplorer.TabIndex = 2;
            this.buttonRangeExplorer.Text = "Range Explorer";
            this.buttonRangeExplorer.UseVisualStyleBackColor = true;
            this.buttonRangeExplorer.Click += new System.EventHandler(this.buttonRangeExplorer_Click);
            // 
            // buttonWorkbookDesigner
            // 
            this.buttonWorkbookDesigner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWorkbookDesigner.AutoSize = true;
            this.buttonWorkbookDesigner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonWorkbookDesigner.Location = new System.Drawing.Point(4, 3);
            this.buttonWorkbookDesigner.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonWorkbookDesigner.Name = "buttonWorkbookDesigner";
            this.buttonWorkbookDesigner.Size = new System.Drawing.Size(222, 25);
            this.buttonWorkbookDesigner.TabIndex = 0;
            this.buttonWorkbookDesigner.Text = "Workbook Designer";
            this.buttonWorkbookDesigner.UseVisualStyleBackColor = true;
            this.buttonWorkbookDesigner.Click += new System.EventHandler(this.buttonWorkbookDesigner_Click);
            // 
            // buttonChartExplorer
            // 
            this.buttonChartExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChartExplorer.AutoSize = true;
            this.buttonChartExplorer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChartExplorer.Location = new System.Drawing.Point(4, 354);
            this.buttonChartExplorer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonChartExplorer.Name = "buttonChartExplorer";
            this.buttonChartExplorer.Size = new System.Drawing.Size(222, 25);
            this.buttonChartExplorer.TabIndex = 3;
            this.buttonChartExplorer.Text = "Chart Explorer";
            this.buttonChartExplorer.UseVisualStyleBackColor = true;
            this.buttonChartExplorer.Click += new System.EventHandler(this.buttonChartExplorer_Click);
            // 
            // buttonShapeExplorer
            // 
            this.buttonShapeExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShapeExplorer.AutoSize = true;
            this.buttonShapeExplorer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonShapeExplorer.Location = new System.Drawing.Point(4, 624);
            this.buttonShapeExplorer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonShapeExplorer.Name = "buttonShapeExplorer";
            this.buttonShapeExplorer.Size = new System.Drawing.Size(222, 25);
            this.buttonShapeExplorer.TabIndex = 4;
            this.buttonShapeExplorer.Text = "Shape Explorer";
            this.buttonShapeExplorer.UseVisualStyleBackColor = true;
            this.buttonShapeExplorer.Click += new System.EventHandler(this.buttonShapeExplorer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_shapeCategories_protection);
            this.groupBox1.Controls.Add(this.checkBox_shapeCategories_autoShape);
            this.groupBox1.Controls.Add(this.checkBox_shapeCategories_control);
            this.groupBox1.Controls.Add(this.checkBox_shapeCategories_line);
            this.groupBox1.Controls.Add(this.checkBox_shapeCategories_fill);
            this.groupBox1.Controls.Add(this.checkBox_shapeCategories_font);
            this.groupBox1.Controls.Add(this.checkBox_shapeCategories_alignment);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(3, 655);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 206);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shape Explorer Flags";
            // 
            // checkBox_shapeCategories_protection
            // 
            this.checkBox_shapeCategories_protection.AutoSize = true;
            this.checkBox_shapeCategories_protection.Checked = true;
            this.checkBox_shapeCategories_protection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_shapeCategories_protection.Location = new System.Drawing.Point(23, 122);
            this.checkBox_shapeCategories_protection.Name = "checkBox_shapeCategories_protection";
            this.checkBox_shapeCategories_protection.Size = new System.Drawing.Size(85, 19);
            this.checkBox_shapeCategories_protection.TabIndex = 6;
            this.checkBox_shapeCategories_protection.Text = "Protection";
            this.checkBox_shapeCategories_protection.UseVisualStyleBackColor = true;
            // 
            // checkBox_shapeCategories_autoShape
            // 
            this.checkBox_shapeCategories_autoShape.AutoSize = true;
            this.checkBox_shapeCategories_autoShape.Checked = true;
            this.checkBox_shapeCategories_autoShape.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_shapeCategories_autoShape.Location = new System.Drawing.Point(23, 147);
            this.checkBox_shapeCategories_autoShape.Name = "checkBox_shapeCategories_autoShape";
            this.checkBox_shapeCategories_autoShape.Size = new System.Drawing.Size(87, 19);
            this.checkBox_shapeCategories_autoShape.TabIndex = 5;
            this.checkBox_shapeCategories_autoShape.Text = "AutoShape";
            this.checkBox_shapeCategories_autoShape.UseVisualStyleBackColor = true;
            // 
            // checkBox_shapeCategories_control
            // 
            this.checkBox_shapeCategories_control.AutoSize = true;
            this.checkBox_shapeCategories_control.Checked = true;
            this.checkBox_shapeCategories_control.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_shapeCategories_control.Location = new System.Drawing.Point(23, 172);
            this.checkBox_shapeCategories_control.Name = "checkBox_shapeCategories_control";
            this.checkBox_shapeCategories_control.Size = new System.Drawing.Size(67, 19);
            this.checkBox_shapeCategories_control.TabIndex = 4;
            this.checkBox_shapeCategories_control.Text = "Control";
            this.checkBox_shapeCategories_control.UseVisualStyleBackColor = true;
            // 
            // checkBox_shapeCategories_line
            // 
            this.checkBox_shapeCategories_line.AutoSize = true;
            this.checkBox_shapeCategories_line.Checked = true;
            this.checkBox_shapeCategories_line.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_shapeCategories_line.Location = new System.Drawing.Point(23, 97);
            this.checkBox_shapeCategories_line.Name = "checkBox_shapeCategories_line";
            this.checkBox_shapeCategories_line.Size = new System.Drawing.Size(49, 19);
            this.checkBox_shapeCategories_line.TabIndex = 3;
            this.checkBox_shapeCategories_line.Text = "Line";
            this.checkBox_shapeCategories_line.UseVisualStyleBackColor = true;
            // 
            // checkBox_shapeCategories_fill
            // 
            this.checkBox_shapeCategories_fill.AutoSize = true;
            this.checkBox_shapeCategories_fill.Checked = true;
            this.checkBox_shapeCategories_fill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_shapeCategories_fill.Location = new System.Drawing.Point(23, 72);
            this.checkBox_shapeCategories_fill.Name = "checkBox_shapeCategories_fill";
            this.checkBox_shapeCategories_fill.Size = new System.Drawing.Size(41, 19);
            this.checkBox_shapeCategories_fill.TabIndex = 2;
            this.checkBox_shapeCategories_fill.Text = "Fill";
            this.checkBox_shapeCategories_fill.UseVisualStyleBackColor = true;
            // 
            // checkBox_shapeCategories_font
            // 
            this.checkBox_shapeCategories_font.AutoSize = true;
            this.checkBox_shapeCategories_font.Checked = true;
            this.checkBox_shapeCategories_font.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_shapeCategories_font.Location = new System.Drawing.Point(23, 47);
            this.checkBox_shapeCategories_font.Name = "checkBox_shapeCategories_font";
            this.checkBox_shapeCategories_font.Size = new System.Drawing.Size(51, 19);
            this.checkBox_shapeCategories_font.TabIndex = 1;
            this.checkBox_shapeCategories_font.Text = "Font";
            this.checkBox_shapeCategories_font.UseVisualStyleBackColor = true;
            // 
            // checkBox_shapeCategories_alignment
            // 
            this.checkBox_shapeCategories_alignment.AutoSize = true;
            this.checkBox_shapeCategories_alignment.Checked = true;
            this.checkBox_shapeCategories_alignment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_shapeCategories_alignment.Location = new System.Drawing.Point(23, 22);
            this.checkBox_shapeCategories_alignment.Name = "checkBox_shapeCategories_alignment";
            this.checkBox_shapeCategories_alignment.Size = new System.Drawing.Size(84, 19);
            this.checkBox_shapeCategories_alignment.TabIndex = 0;
            this.checkBox_shapeCategories_alignment.Text = "Alignment";
            this.checkBox_shapeCategories_alignment.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_chartCategories_chartData);
            this.groupBox2.Controls.Add(this.checkBox_chartCategories_axes);
            this.groupBox2.Controls.Add(this.checkBox_chartCategories_series);
            this.groupBox2.Controls.Add(this.checkBox_chartCategories_pageSetup);
            this.groupBox2.Controls.Add(this.checkBox_chartCategories_title);
            this.groupBox2.Controls.Add(this.checkBox_chartCategories_legend);
            this.groupBox2.Controls.Add(this.checkBox_chartCategories_plotArea);
            this.groupBox2.Controls.Add(this.checkBox_chartCategories_chartArea);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(3, 385);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 233);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chart Explorer Flags";
            // 
            // checkBox_chartCategories_chartData
            // 
            this.checkBox_chartCategories_chartData.AutoSize = true;
            this.checkBox_chartCategories_chartData.Checked = true;
            this.checkBox_chartCategories_chartData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chartCategories_chartData.Location = new System.Drawing.Point(22, 47);
            this.checkBox_chartCategories_chartData.Name = "checkBox_chartCategories_chartData";
            this.checkBox_chartCategories_chartData.Size = new System.Drawing.Size(85, 19);
            this.checkBox_chartCategories_chartData.TabIndex = 7;
            this.checkBox_chartCategories_chartData.Text = "Chart Data";
            this.checkBox_chartCategories_chartData.UseVisualStyleBackColor = true;
            // 
            // checkBox_chartCategories_axes
            // 
            this.checkBox_chartCategories_axes.AutoSize = true;
            this.checkBox_chartCategories_axes.Checked = true;
            this.checkBox_chartCategories_axes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chartCategories_axes.Location = new System.Drawing.Point(22, 147);
            this.checkBox_chartCategories_axes.Name = "checkBox_chartCategories_axes";
            this.checkBox_chartCategories_axes.Size = new System.Drawing.Size(53, 19);
            this.checkBox_chartCategories_axes.TabIndex = 6;
            this.checkBox_chartCategories_axes.Text = "Axes";
            this.checkBox_chartCategories_axes.UseVisualStyleBackColor = true;
            // 
            // checkBox_chartCategories_series
            // 
            this.checkBox_chartCategories_series.AutoSize = true;
            this.checkBox_chartCategories_series.Checked = true;
            this.checkBox_chartCategories_series.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chartCategories_series.Location = new System.Drawing.Point(22, 172);
            this.checkBox_chartCategories_series.Name = "checkBox_chartCategories_series";
            this.checkBox_chartCategories_series.Size = new System.Drawing.Size(60, 19);
            this.checkBox_chartCategories_series.TabIndex = 5;
            this.checkBox_chartCategories_series.Text = "Series";
            this.checkBox_chartCategories_series.UseVisualStyleBackColor = true;
            // 
            // checkBox_chartCategories_pageSetup
            // 
            this.checkBox_chartCategories_pageSetup.AutoSize = true;
            this.checkBox_chartCategories_pageSetup.Checked = true;
            this.checkBox_chartCategories_pageSetup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chartCategories_pageSetup.Location = new System.Drawing.Point(22, 197);
            this.checkBox_chartCategories_pageSetup.Name = "checkBox_chartCategories_pageSetup";
            this.checkBox_chartCategories_pageSetup.Size = new System.Drawing.Size(89, 19);
            this.checkBox_chartCategories_pageSetup.TabIndex = 4;
            this.checkBox_chartCategories_pageSetup.Text = "Page Setup";
            this.checkBox_chartCategories_pageSetup.UseVisualStyleBackColor = true;
            // 
            // checkBox_chartCategories_title
            // 
            this.checkBox_chartCategories_title.AutoSize = true;
            this.checkBox_chartCategories_title.Checked = true;
            this.checkBox_chartCategories_title.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chartCategories_title.Location = new System.Drawing.Point(22, 122);
            this.checkBox_chartCategories_title.Name = "checkBox_chartCategories_title";
            this.checkBox_chartCategories_title.Size = new System.Drawing.Size(51, 19);
            this.checkBox_chartCategories_title.TabIndex = 3;
            this.checkBox_chartCategories_title.Text = "Title";
            this.checkBox_chartCategories_title.UseVisualStyleBackColor = true;
            // 
            // checkBox_chartCategories_legend
            // 
            this.checkBox_chartCategories_legend.AutoSize = true;
            this.checkBox_chartCategories_legend.Checked = true;
            this.checkBox_chartCategories_legend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chartCategories_legend.Location = new System.Drawing.Point(22, 97);
            this.checkBox_chartCategories_legend.Name = "checkBox_chartCategories_legend";
            this.checkBox_chartCategories_legend.Size = new System.Drawing.Size(67, 19);
            this.checkBox_chartCategories_legend.TabIndex = 2;
            this.checkBox_chartCategories_legend.Text = "Legend";
            this.checkBox_chartCategories_legend.UseVisualStyleBackColor = true;
            // 
            // checkBox_chartCategories_plotArea
            // 
            this.checkBox_chartCategories_plotArea.AutoSize = true;
            this.checkBox_chartCategories_plotArea.Checked = true;
            this.checkBox_chartCategories_plotArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chartCategories_plotArea.Location = new System.Drawing.Point(22, 72);
            this.checkBox_chartCategories_plotArea.Name = "checkBox_chartCategories_plotArea";
            this.checkBox_chartCategories_plotArea.Size = new System.Drawing.Size(77, 19);
            this.checkBox_chartCategories_plotArea.TabIndex = 1;
            this.checkBox_chartCategories_plotArea.Text = "Plot Area";
            this.checkBox_chartCategories_plotArea.UseVisualStyleBackColor = true;
            // 
            // checkBox_chartCategories_chartArea
            // 
            this.checkBox_chartCategories_chartArea.AutoSize = true;
            this.checkBox_chartCategories_chartArea.Checked = true;
            this.checkBox_chartCategories_chartArea.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_chartCategories_chartArea.Location = new System.Drawing.Point(23, 22);
            this.checkBox_chartCategories_chartArea.Name = "checkBox_chartCategories_chartArea";
            this.checkBox_chartCategories_chartArea.Size = new System.Drawing.Size(85, 19);
            this.checkBox_chartCategories_chartArea.TabIndex = 0;
            this.checkBox_chartCategories_chartArea.Text = "Chart Area";
            this.checkBox_chartCategories_chartArea.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_conditionalFormats);
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_validation);
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_interior);
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_protection);
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_hyperlink);
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_borders);
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_font);
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_alignment);
            this.groupBox3.Controls.Add(this.checkBox_rangeCategories_numberFormats);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(3, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 252);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Range Explorer Flags";
            // 
            // checkBox_rangeCategories_conditionalFormats
            // 
            this.checkBox_rangeCategories_conditionalFormats.AutoSize = true;
            this.checkBox_rangeCategories_conditionalFormats.Checked = true;
            this.checkBox_rangeCategories_conditionalFormats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_conditionalFormats.Location = new System.Drawing.Point(23, 222);
            this.checkBox_rangeCategories_conditionalFormats.Name = "checkBox_rangeCategories_conditionalFormats";
            this.checkBox_rangeCategories_conditionalFormats.Size = new System.Drawing.Size(136, 19);
            this.checkBox_rangeCategories_conditionalFormats.TabIndex = 8;
            this.checkBox_rangeCategories_conditionalFormats.Text = "Conditional Formats";
            this.checkBox_rangeCategories_conditionalFormats.UseVisualStyleBackColor = true;
            // 
            // checkBox_rangeCategories_validation
            // 
            this.checkBox_rangeCategories_validation.AutoSize = true;
            this.checkBox_rangeCategories_validation.Checked = true;
            this.checkBox_rangeCategories_validation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_validation.Location = new System.Drawing.Point(23, 197);
            this.checkBox_rangeCategories_validation.Name = "checkBox_rangeCategories_validation";
            this.checkBox_rangeCategories_validation.Size = new System.Drawing.Size(80, 19);
            this.checkBox_rangeCategories_validation.TabIndex = 7;
            this.checkBox_rangeCategories_validation.Text = "Validation";
            this.checkBox_rangeCategories_validation.UseVisualStyleBackColor = true;
            // 
            // checkBox_rangeCategories_interior
            // 
            this.checkBox_rangeCategories_interior.AutoSize = true;
            this.checkBox_rangeCategories_interior.Checked = true;
            this.checkBox_rangeCategories_interior.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_interior.Location = new System.Drawing.Point(23, 122);
            this.checkBox_rangeCategories_interior.Name = "checkBox_rangeCategories_interior";
            this.checkBox_rangeCategories_interior.Size = new System.Drawing.Size(69, 19);
            this.checkBox_rangeCategories_interior.TabIndex = 6;
            this.checkBox_rangeCategories_interior.Text = "Interior";
            this.checkBox_rangeCategories_interior.UseVisualStyleBackColor = true;
            // 
            // checkBox_rangeCategories_protection
            // 
            this.checkBox_rangeCategories_protection.AutoSize = true;
            this.checkBox_rangeCategories_protection.Checked = true;
            this.checkBox_rangeCategories_protection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_protection.Location = new System.Drawing.Point(23, 147);
            this.checkBox_rangeCategories_protection.Name = "checkBox_rangeCategories_protection";
            this.checkBox_rangeCategories_protection.Size = new System.Drawing.Size(85, 19);
            this.checkBox_rangeCategories_protection.TabIndex = 5;
            this.checkBox_rangeCategories_protection.Text = "Protection";
            this.checkBox_rangeCategories_protection.UseVisualStyleBackColor = true;
            // 
            // checkBox_rangeCategories_hyperlink
            // 
            this.checkBox_rangeCategories_hyperlink.AutoSize = true;
            this.checkBox_rangeCategories_hyperlink.Checked = true;
            this.checkBox_rangeCategories_hyperlink.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_hyperlink.Location = new System.Drawing.Point(23, 172);
            this.checkBox_rangeCategories_hyperlink.Name = "checkBox_rangeCategories_hyperlink";
            this.checkBox_rangeCategories_hyperlink.Size = new System.Drawing.Size(80, 19);
            this.checkBox_rangeCategories_hyperlink.TabIndex = 4;
            this.checkBox_rangeCategories_hyperlink.Text = "Hyperlink";
            this.checkBox_rangeCategories_hyperlink.UseVisualStyleBackColor = true;
            // 
            // checkBox_rangeCategories_borders
            // 
            this.checkBox_rangeCategories_borders.AutoSize = true;
            this.checkBox_rangeCategories_borders.Checked = true;
            this.checkBox_rangeCategories_borders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_borders.Location = new System.Drawing.Point(23, 97);
            this.checkBox_rangeCategories_borders.Name = "checkBox_rangeCategories_borders";
            this.checkBox_rangeCategories_borders.Size = new System.Drawing.Size(70, 19);
            this.checkBox_rangeCategories_borders.TabIndex = 3;
            this.checkBox_rangeCategories_borders.Text = "Borders";
            this.checkBox_rangeCategories_borders.UseVisualStyleBackColor = true;
            // 
            // checkBox_rangeCategories_font
            // 
            this.checkBox_rangeCategories_font.AutoSize = true;
            this.checkBox_rangeCategories_font.Checked = true;
            this.checkBox_rangeCategories_font.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_font.Location = new System.Drawing.Point(23, 72);
            this.checkBox_rangeCategories_font.Name = "checkBox_rangeCategories_font";
            this.checkBox_rangeCategories_font.Size = new System.Drawing.Size(51, 19);
            this.checkBox_rangeCategories_font.TabIndex = 2;
            this.checkBox_rangeCategories_font.Text = "Font";
            this.checkBox_rangeCategories_font.UseVisualStyleBackColor = true;
            // 
            // checkBox_rangeCategories_alignment
            // 
            this.checkBox_rangeCategories_alignment.AutoSize = true;
            this.checkBox_rangeCategories_alignment.Checked = true;
            this.checkBox_rangeCategories_alignment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_alignment.Location = new System.Drawing.Point(23, 47);
            this.checkBox_rangeCategories_alignment.Name = "checkBox_rangeCategories_alignment";
            this.checkBox_rangeCategories_alignment.Size = new System.Drawing.Size(84, 19);
            this.checkBox_rangeCategories_alignment.TabIndex = 1;
            this.checkBox_rangeCategories_alignment.Text = "Alignment";
            this.checkBox_rangeCategories_alignment.UseVisualStyleBackColor = true;
            // 
            // checkBox_rangeCategories_numberFormats
            // 
            this.checkBox_rangeCategories_numberFormats.AutoSize = true;
            this.checkBox_rangeCategories_numberFormats.Checked = true;
            this.checkBox_rangeCategories_numberFormats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_rangeCategories_numberFormats.Location = new System.Drawing.Point(23, 22);
            this.checkBox_rangeCategories_numberFormats.Name = "checkBox_rangeCategories_numberFormats";
            this.checkBox_rangeCategories_numberFormats.Size = new System.Drawing.Size(120, 19);
            this.checkBox_rangeCategories_numberFormats.TabIndex = 0;
            this.checkBox_rangeCategories_numberFormats.Text = "Number Formats";
            this.checkBox_rangeCategories_numberFormats.UseVisualStyleBackColor = true;
            // 
            // DesignerAndExplorerDialogsSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DesignerAndExplorerDialogsSample";
            this.Size = new System.Drawing.Size(725, 839);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonWorkbookExplorer;
        private System.Windows.Forms.Button buttonRangeExplorer;
        private System.Windows.Forms.Button buttonWorkbookDesigner;
        private System.Windows.Forms.Button buttonChartExplorer;
        private System.Windows.Forms.Button buttonShapeExplorer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox_shapeCategories_protection;
        private System.Windows.Forms.CheckBox checkBox_shapeCategories_autoShape;
        private System.Windows.Forms.CheckBox checkBox_shapeCategories_control;
        private System.Windows.Forms.CheckBox checkBox_shapeCategories_line;
        private System.Windows.Forms.CheckBox checkBox_shapeCategories_fill;
        private System.Windows.Forms.CheckBox checkBox_shapeCategories_font;
        private System.Windows.Forms.CheckBox checkBox_shapeCategories_alignment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox_chartCategories_axes;
        private System.Windows.Forms.CheckBox checkBox_chartCategories_series;
        private System.Windows.Forms.CheckBox checkBox_chartCategories_pageSetup;
        private System.Windows.Forms.CheckBox checkBox_chartCategories_title;
        private System.Windows.Forms.CheckBox checkBox_chartCategories_legend;
        private System.Windows.Forms.CheckBox checkBox_chartCategories_plotArea;
        private System.Windows.Forms.CheckBox checkBox_chartCategories_chartArea;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_conditionalFormats;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_validation;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_interior;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_protection;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_hyperlink;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_borders;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_font;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_alignment;
        private System.Windows.Forms.CheckBox checkBox_rangeCategories_numberFormats;
        private System.Windows.Forms.CheckBox checkBox_chartCategories_chartData;
    }
}
