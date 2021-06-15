namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    partial class DisplayReferenceSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayReferenceSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonWorksheet = new System.Windows.Forms.RadioButton();
            this.radioButtonRange = new System.Windows.Forms.RadioButton();
            this.radioButtonDefinedName = new System.Windows.Forms.RadioButton();
            this.radioButtonMultipleRanges = new System.Windows.Forms.RadioButton();
            this.radioButtonWorkbook = new System.Windows.Forms.RadioButton();
            this.radioButtonUsedRange = new System.Windows.Forms.RadioButton();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.workbookView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(462, 322);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.radioButtonWorksheet, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonRange, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonDefinedName, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonMultipleRanges, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonWorkbook, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonUsedRange, 0, 5);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 3);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(118, 316);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // radioButtonWorksheet
            // 
            this.radioButtonWorksheet.AutoSize = true;
            this.radioButtonWorksheet.Location = new System.Drawing.Point(4, 28);
            this.radioButtonWorksheet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonWorksheet.Name = "radioButtonWorksheet";
            this.radioButtonWorksheet.Size = new System.Drawing.Size(81, 19);
            this.radioButtonWorksheet.TabIndex = 1;
            this.radioButtonWorksheet.TabStop = true;
            this.radioButtonWorksheet.Text = "Worksheet";
            this.radioButtonWorksheet.UseVisualStyleBackColor = true;
            this.radioButtonWorksheet.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonRange
            // 
            this.radioButtonRange.AutoSize = true;
            this.radioButtonRange.Location = new System.Drawing.Point(4, 53);
            this.radioButtonRange.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonRange.Name = "radioButtonRange";
            this.radioButtonRange.Size = new System.Drawing.Size(58, 19);
            this.radioButtonRange.TabIndex = 2;
            this.radioButtonRange.TabStop = true;
            this.radioButtonRange.Text = "Range";
            this.radioButtonRange.UseVisualStyleBackColor = true;
            this.radioButtonRange.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonDefinedName
            // 
            this.radioButtonDefinedName.AutoSize = true;
            this.radioButtonDefinedName.Location = new System.Drawing.Point(4, 78);
            this.radioButtonDefinedName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonDefinedName.Name = "radioButtonDefinedName";
            this.radioButtonDefinedName.Size = new System.Drawing.Size(101, 19);
            this.radioButtonDefinedName.TabIndex = 3;
            this.radioButtonDefinedName.TabStop = true;
            this.radioButtonDefinedName.Text = "Defined Name";
            this.radioButtonDefinedName.UseVisualStyleBackColor = true;
            this.radioButtonDefinedName.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonMultipleRanges
            // 
            this.radioButtonMultipleRanges.AutoSize = true;
            this.radioButtonMultipleRanges.Location = new System.Drawing.Point(4, 103);
            this.radioButtonMultipleRanges.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonMultipleRanges.Name = "radioButtonMultipleRanges";
            this.radioButtonMultipleRanges.Size = new System.Drawing.Size(110, 19);
            this.radioButtonMultipleRanges.TabIndex = 4;
            this.radioButtonMultipleRanges.TabStop = true;
            this.radioButtonMultipleRanges.Text = "Multiple Ranges";
            this.radioButtonMultipleRanges.UseVisualStyleBackColor = true;
            this.radioButtonMultipleRanges.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonWorkbook
            // 
            this.radioButtonWorkbook.AutoSize = true;
            this.radioButtonWorkbook.Checked = true;
            this.radioButtonWorkbook.Location = new System.Drawing.Point(4, 3);
            this.radioButtonWorkbook.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonWorkbook.Name = "radioButtonWorkbook";
            this.radioButtonWorkbook.Size = new System.Drawing.Size(80, 19);
            this.radioButtonWorkbook.TabIndex = 0;
            this.radioButtonWorkbook.TabStop = true;
            this.radioButtonWorkbook.Text = "Workbook";
            this.radioButtonWorkbook.UseVisualStyleBackColor = true;
            this.radioButtonWorkbook.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // radioButtonUsedRange
            // 
            this.radioButtonUsedRange.AutoSize = true;
            this.radioButtonUsedRange.Location = new System.Drawing.Point(4, 128);
            this.radioButtonUsedRange.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioButtonUsedRange.Name = "radioButtonUsedRange";
            this.radioButtonUsedRange.Size = new System.Drawing.Size(92, 19);
            this.radioButtonUsedRange.TabIndex = 5;
            this.radioButtonUsedRange.TabStop = true;
            this.radioButtonUsedRange.Text = "Used Ranges";
            this.radioButtonUsedRange.UseVisualStyleBackColor = true;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(130, 3);
            this.workbookView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(328, 316);
            this.workbookView.TabIndex = 0;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // DisplayReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DisplayReference";
            this.Size = new System.Drawing.Size(462, 322);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButtonWorksheet;
        private System.Windows.Forms.RadioButton radioButtonRange;
        private System.Windows.Forms.RadioButton radioButtonDefinedName;
        private System.Windows.Forms.RadioButton radioButtonMultipleRanges;
        private System.Windows.Forms.RadioButton radioButtonWorkbook;
        private System.Windows.Forms.RadioButton radioButtonUsedRange;


    }
}
