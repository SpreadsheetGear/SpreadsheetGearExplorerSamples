namespace WindowsFormsExplorer.Samples.Printing
{
    partial class PageBreaksSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageBreaksSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelOptions = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPrintPreview = new System.Windows.Forms.Button();
            this.groupBoxPageBreaks = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelPageBreaks = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonPageBreaksNone = new System.Windows.Forms.RadioButton();
            this.radioButtonPageBreaksUsed = new System.Windows.Forms.RadioButton();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelOptions.SuspendLayout();
            this.groupBoxPageBreaks.SuspendLayout();
            this.tableLayoutPanelPageBreaks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelOptions, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.workbookView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(473, 322);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanelOptions
            // 
            this.tableLayoutPanelOptions.AutoSize = true;
            this.tableLayoutPanelOptions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelOptions.ColumnCount = 1;
            this.tableLayoutPanelOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelOptions.Controls.Add(this.buttonPrintPreview, 0, 1);
            this.tableLayoutPanelOptions.Controls.Add(this.groupBoxPageBreaks, 0, 0);
            this.tableLayoutPanelOptions.Location = new System.Drawing.Point(4, 3);
            this.tableLayoutPanelOptions.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanelOptions.Name = "tableLayoutPanelOptions";
            this.tableLayoutPanelOptions.RowCount = 2;
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelOptions.Size = new System.Drawing.Size(125, 130);
            this.tableLayoutPanelOptions.TabIndex = 2;
            // 
            // buttonPrintPreview
            // 
            this.buttonPrintPreview.Location = new System.Drawing.Point(4, 100);
            this.buttonPrintPreview.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonPrintPreview.Name = "buttonPrintPreview";
            this.buttonPrintPreview.Size = new System.Drawing.Size(117, 27);
            this.buttonPrintPreview.TabIndex = 2;
            this.buttonPrintPreview.Text = "Print Preview...";
            this.buttonPrintPreview.UseVisualStyleBackColor = true;
            this.buttonPrintPreview.Click += new System.EventHandler(this.ButtonPrintPreview_Click);
            // 
            // groupBoxPageBreaks
            // 
            this.groupBoxPageBreaks.Controls.Add(this.tableLayoutPanelPageBreaks);
            this.groupBoxPageBreaks.Location = new System.Drawing.Point(4, 3);
            this.groupBoxPageBreaks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxPageBreaks.Name = "groupBoxPageBreaks";
            this.groupBoxPageBreaks.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBoxPageBreaks.Size = new System.Drawing.Size(117, 91);
            this.groupBoxPageBreaks.TabIndex = 0;
            this.groupBoxPageBreaks.TabStop = false;
            this.groupBoxPageBreaks.Text = "Page breaks";
            // 
            // tableLayoutPanelPageBreaks
            // 
            this.tableLayoutPanelPageBreaks.AutoSize = true;
            this.tableLayoutPanelPageBreaks.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelPageBreaks.ColumnCount = 1;
            this.tableLayoutPanelPageBreaks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelPageBreaks.Controls.Add(this.radioButtonPageBreaksNone, 0, 0);
            this.tableLayoutPanelPageBreaks.Controls.Add(this.radioButtonPageBreaksUsed, 0, 1);
            this.tableLayoutPanelPageBreaks.Location = new System.Drawing.Point(7, 22);
            this.tableLayoutPanelPageBreaks.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanelPageBreaks.Name = "tableLayoutPanelPageBreaks";
            this.tableLayoutPanelPageBreaks.RowCount = 2;
            this.tableLayoutPanelPageBreaks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPageBreaks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelPageBreaks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanelPageBreaks.Size = new System.Drawing.Size(88, 50);
            this.tableLayoutPanelPageBreaks.TabIndex = 0;
            // 
            // radioButtonPageBreaksNone
            // 
            this.radioButtonPageBreaksNone.AutoSize = true;
            this.radioButtonPageBreaksNone.Checked = true;
            this.radioButtonPageBreaksNone.Location = new System.Drawing.Point(9, 3);
            this.radioButtonPageBreaksNone.Margin = new System.Windows.Forms.Padding(9, 3, 4, 3);
            this.radioButtonPageBreaksNone.Name = "radioButtonPageBreaksNone";
            this.radioButtonPageBreaksNone.Size = new System.Drawing.Size(54, 19);
            this.radioButtonPageBreaksNone.TabIndex = 0;
            this.radioButtonPageBreaksNone.TabStop = true;
            this.radioButtonPageBreaksNone.Text = "None";
            this.radioButtonPageBreaksNone.UseVisualStyleBackColor = true;
            // 
            // radioButtonPageBreaksUsed
            // 
            this.radioButtonPageBreaksUsed.AutoSize = true;
            this.radioButtonPageBreaksUsed.Location = new System.Drawing.Point(9, 28);
            this.radioButtonPageBreaksUsed.Margin = new System.Windows.Forms.Padding(9, 3, 4, 3);
            this.radioButtonPageBreaksUsed.Name = "radioButtonPageBreaksUsed";
            this.radioButtonPageBreaksUsed.Size = new System.Drawing.Size(75, 19);
            this.radioButtonPageBreaksUsed.TabIndex = 1;
            this.radioButtonPageBreaksUsed.Text = "By region";
            this.radioButtonPageBreaksUsed.UseVisualStyleBackColor = true;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(137, 3);
            this.workbookView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(332, 316);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // PageBreaks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "PageBreaks";
            this.Size = new System.Drawing.Size(473, 322);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelOptions.ResumeLayout(false);
            this.groupBoxPageBreaks.ResumeLayout(false);
            this.groupBoxPageBreaks.PerformLayout();
            this.tableLayoutPanelPageBreaks.ResumeLayout(false);
            this.tableLayoutPanelPageBreaks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelOptions;
        private System.Windows.Forms.Button buttonPrintPreview;
        private System.Windows.Forms.GroupBox groupBoxPageBreaks;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPageBreaks;
        private System.Windows.Forms.RadioButton radioButtonPageBreaksNone;
        private System.Windows.Forms.RadioButton radioButtonPageBreaksUsed;


    }
}
