namespace WindowsFormsExplorer.Samples.WorkbookView
{
    partial class ActiveWorkbookSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveWorkbookSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_loadUriXLSX = new System.Windows.Forms.Button();
            this.button_loadUriAsp = new System.Windows.Forms.Button();
            this.button_newWorkbook = new System.Windows.Forms.Button();
            this.button_loadDisk = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.locationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(551, 323);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_loadUriXLSX);
            this.panel1.Controls.Add(this.button_loadUriAsp);
            this.panel1.Controls.Add(this.button_newWorkbook);
            this.panel1.Controls.Add(this.button_loadDisk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 317);
            this.panel1.TabIndex = 2;
            // 
            // button_loadUriXLSX
            // 
            this.button_loadUriXLSX.Location = new System.Drawing.Point(11, 125);
            this.button_loadUriXLSX.Name = "button_loadUriXLSX";
            this.button_loadUriXLSX.Size = new System.Drawing.Size(221, 23);
            this.button_loadUriXLSX.TabIndex = 3;
            this.button_loadUriXLSX.Text = "Load from URI (File on Server)";
            this.button_loadUriXLSX.UseVisualStyleBackColor = true;
            this.button_loadUriXLSX.Click += new System.EventHandler(this.button_loadUriXLSX_Click);
            // 
            // button_loadUriAsp
            // 
            this.button_loadUriAsp.Location = new System.Drawing.Point(12, 96);
            this.button_loadUriAsp.Name = "button_loadUriAsp";
            this.button_loadUriAsp.Size = new System.Drawing.Size(220, 23);
            this.button_loadUriAsp.TabIndex = 2;
            this.button_loadUriAsp.Text = "Load from URI (ASP.NET Generated)";
            this.button_loadUriAsp.UseVisualStyleBackColor = true;
            this.button_loadUriAsp.Click += new System.EventHandler(this.button_loadUriAsp_Click);
            // 
            // button_newWorkbook
            // 
            this.button_newWorkbook.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_newWorkbook.Location = new System.Drawing.Point(12, 12);
            this.button_newWorkbook.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_newWorkbook.Name = "button_newWorkbook";
            this.button_newWorkbook.Size = new System.Drawing.Size(220, 25);
            this.button_newWorkbook.TabIndex = 1;
            this.button_newWorkbook.Text = "New Workbook";
            this.button_newWorkbook.UseVisualStyleBackColor = true;
            this.button_newWorkbook.Click += new System.EventHandler(this.button_newWorkbook_Click);
            // 
            // button_loadDisk
            // 
            this.button_loadDisk.Location = new System.Drawing.Point(12, 52);
            this.button_loadDisk.Name = "button_loadDisk";
            this.button_loadDisk.Size = new System.Drawing.Size(220, 23);
            this.button_loadDisk.TabIndex = 0;
            this.button_loadDisk.Text = "Load from Disk...";
            this.button_loadDisk.UseVisualStyleBackColor = true;
            this.button_loadDisk.Click += new System.EventHandler(this.button_loadDisk_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.workbookView);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(254, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 317);
            this.panel2.TabIndex = 3;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(0, 47);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(294, 270);
            this.workbookView.TabIndex = 1;
            this.workbookView.Visible = true;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.progressBar);
            this.panel3.Controls.Add(this.locationLabel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 47);
            this.panel3.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 11);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(423, 26);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 2;
            this.progressBar.Visible = false;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(175, 17);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(0, 15);
            this.locationLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Workbook Source:";
            // 
            // ActiveWorkbookSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ActiveWorkbookSample";
            this.Size = new System.Drawing.Size(551, 323);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_newWorkbook;
        private System.Windows.Forms.Button button_loadDisk;
        private System.Windows.Forms.Button button_loadUriXLSX;
        private System.Windows.Forms.Button button_loadUriAsp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
