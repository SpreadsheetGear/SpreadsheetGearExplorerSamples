
namespace WindowsFormsExplorer.Samples.WorkbookView.UIManager
{
    partial class CustomControlSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomControlSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRunSample = new System.Windows.Forms.Button();
            this.sgPanel = new System.Windows.Forms.Panel();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.formulaBar = new SpreadsheetGear.Windows.Forms.FormulaBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.sgPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.buttonRunSample, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.sgPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 538);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonRunSample
            // 
            this.buttonRunSample.AutoSize = true;
            this.buttonRunSample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRunSample.Location = new System.Drawing.Point(6, 5);
            this.buttonRunSample.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonRunSample.Name = "buttonRunSample";
            this.buttonRunSample.Size = new System.Drawing.Size(117, 35);
            this.buttonRunSample.TabIndex = 0;
            this.buttonRunSample.Text = "Run Sample";
            this.buttonRunSample.UseVisualStyleBackColor = true;
            this.buttonRunSample.Click += new System.EventHandler(this.ButtonRunSample_Click);
            // 
            // sgPanel
            // 
            this.sgPanel.Controls.Add(this.workbookView);
            this.sgPanel.Controls.Add(this.formulaBar);
            this.sgPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sgPanel.Location = new System.Drawing.Point(132, 3);
            this.sgPanel.Name = "sgPanel";
            this.sgPanel.Size = new System.Drawing.Size(494, 532);
            this.sgPanel.TabIndex = 2;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.Location = new System.Drawing.Point(0, 41);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(494, 491);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // formulaBar
            // 
            this.formulaBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.formulaBar.Location = new System.Drawing.Point(0, 0);
            this.formulaBar.Name = "formulaBar";
            this.formulaBar.Size = new System.Drawing.Size(494, 41);
            this.formulaBar.TabIndex = 0;
            this.formulaBar.TabStop = false;
            // 
            // CustomControlSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "CustomControlSample";
            this.Size = new System.Drawing.Size(629, 538);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.sgPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonRunSample;
        private System.Windows.Forms.Panel sgPanel;
        private WinFormsWorkbookView workbookView;
        private SpreadsheetGear.Windows.Forms.FormulaBar formulaBar;
    }
}
