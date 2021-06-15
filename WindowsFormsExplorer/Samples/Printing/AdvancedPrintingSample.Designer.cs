namespace WindowsFormsExplorer.Samples.Printing
{
    partial class AdvancedPrintingSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedPrintingSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.tableLayoutPanelOptions = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPrintPreview = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.groupBoxPrintWhat = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelPrintWhat = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxRange = new System.Windows.Forms.CheckBox();
            this.checkBoxChart = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelOptions.SuspendLayout();
            this.groupBoxPrintWhat.SuspendLayout();
            this.tableLayoutPanelPrintWhat.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelOptions, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(498, 322);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(162, 3);
            this.workbookView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(332, 316);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // tableLayoutPanelOptions
            // 
            this.tableLayoutPanelOptions.AutoSize = true;
            this.tableLayoutPanelOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelOptions.ColumnCount = 1;
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOptions.Controls.Add(this.buttonPrintPreview, 0, 2);
            this.tableLayoutPanelOptions.Controls.Add(this.buttonPrint, 0, 1);
            this.tableLayoutPanelOptions.Controls.Add(this.groupBoxPrintWhat, 0, 0);
            this.tableLayoutPanelOptions.Location = new System.Drawing.Point(4, 3);
            this.tableLayoutPanelOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanelOptions.Name = "tableLayoutPanelOptions";
            this.tableLayoutPanelOptions.RowCount = 3;
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelOptions.Size = new System.Drawing.Size(150, 162);
            this.tableLayoutPanelOptions.TabIndex = 0;
            // 
            // buttonPrintPreview
            // 
            this.buttonPrintPreview.Location = new System.Drawing.Point(4, 132);
            this.buttonPrintPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPrintPreview.Name = "buttonPrintPreview";
            this.buttonPrintPreview.Size = new System.Drawing.Size(142, 27);
            this.buttonPrintPreview.TabIndex = 2;
            this.buttonPrintPreview.Text = "Custom Print Preview...";
            this.buttonPrintPreview.UseVisualStyleBackColor = true;
            this.buttonPrintPreview.Click += new System.EventHandler(this.ButtonPrintPreview_Click);
            // 
            // buttonPrint
            // 
            this.buttonPrint.Location = new System.Drawing.Point(4, 99);
            this.buttonPrint.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(142, 27);
            this.buttonPrint.TabIndex = 1;
            this.buttonPrint.Text = "Print...";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // groupBoxPrintWhat
            // 
            this.groupBoxPrintWhat.Controls.Add(this.tableLayoutPanelPrintWhat);
            this.groupBoxPrintWhat.Location = new System.Drawing.Point(4, 3);
            this.groupBoxPrintWhat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxPrintWhat.Name = "groupBoxPrintWhat";
            this.groupBoxPrintWhat.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxPrintWhat.Size = new System.Drawing.Size(142, 90);
            this.groupBoxPrintWhat.TabIndex = 0;
            this.groupBoxPrintWhat.TabStop = false;
            this.groupBoxPrintWhat.Text = "Print what";
            // 
            // tableLayoutPanelPrintWhat
            // 
            this.tableLayoutPanelPrintWhat.AutoSize = true;
            this.tableLayoutPanelPrintWhat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelPrintWhat.ColumnCount = 1;
            this.tableLayoutPanelPrintWhat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelPrintWhat.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelPrintWhat.Controls.Add(this.checkBoxRange, 0, 0);
            this.tableLayoutPanelPrintWhat.Controls.Add(this.checkBoxChart, 0, 1);
            this.tableLayoutPanelPrintWhat.Location = new System.Drawing.Point(7, 22);
            this.tableLayoutPanelPrintWhat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanelPrintWhat.Name = "tableLayoutPanelPrintWhat";
            this.tableLayoutPanelPrintWhat.RowCount = 2;
            this.tableLayoutPanelPrintWhat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPrintWhat.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPrintWhat.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelPrintWhat.Size = new System.Drawing.Size(67, 50);
            this.tableLayoutPanelPrintWhat.TabIndex = 0;
            // 
            // checkBoxRange
            // 
            this.checkBoxRange.AutoSize = true;
            this.checkBoxRange.Checked = true;
            this.checkBoxRange.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRange.Location = new System.Drawing.Point(4, 3);
            this.checkBoxRange.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxRange.Name = "checkBoxRange";
            this.checkBoxRange.Size = new System.Drawing.Size(59, 19);
            this.checkBoxRange.TabIndex = 3;
            this.checkBoxRange.Text = "Range";
            this.checkBoxRange.UseVisualStyleBackColor = true;
            // 
            // checkBoxChart
            // 
            this.checkBoxChart.AutoSize = true;
            this.checkBoxChart.Checked = true;
            this.checkBoxChart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxChart.Location = new System.Drawing.Point(4, 28);
            this.checkBoxChart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBoxChart.Name = "checkBoxChart";
            this.checkBoxChart.Size = new System.Drawing.Size(55, 19);
            this.checkBoxChart.TabIndex = 4;
            this.checkBoxChart.Text = "Chart";
            this.checkBoxChart.UseVisualStyleBackColor = true;
            // 
            // AdvancedPrintingSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AdvancedPrintingSample";
            this.Size = new System.Drawing.Size(498, 322);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelOptions.ResumeLayout(false);
            this.groupBoxPrintWhat.ResumeLayout(false);
            this.groupBoxPrintWhat.PerformLayout();
            this.tableLayoutPanelPrintWhat.ResumeLayout(false);
            this.tableLayoutPanelPrintWhat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOptions;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.GroupBox groupBoxPrintWhat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPrintWhat;
        private System.Windows.Forms.Button buttonPrintPreview;
        private System.Windows.Forms.CheckBox checkBoxRange;
        private System.Windows.Forms.CheckBox checkBoxChart;


    }
}
