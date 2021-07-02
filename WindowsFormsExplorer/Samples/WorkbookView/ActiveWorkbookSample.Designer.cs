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
            this.buttonLoadUriXLSX = new System.Windows.Forms.Button();
            this.buttonLoadUriAsp = new System.Windows.Forms.Button();
            this.buttonNewWorkbook = new System.Windows.Forms.Button();
            this.buttonLoadDisk = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 429F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(787, 538);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonLoadUriXLSX);
            this.panel1.Controls.Add(this.buttonLoadUriAsp);
            this.panel1.Controls.Add(this.buttonNewWorkbook);
            this.panel1.Controls.Add(this.buttonLoadDisk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 528);
            this.panel1.TabIndex = 2;
            // 
            // buttonLoadUriXLSX
            // 
            this.buttonLoadUriXLSX.Location = new System.Drawing.Point(16, 208);
            this.buttonLoadUriXLSX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoadUriXLSX.Name = "buttonLoadUriXLSX";
            this.buttonLoadUriXLSX.Size = new System.Drawing.Size(316, 38);
            this.buttonLoadUriXLSX.TabIndex = 3;
            this.buttonLoadUriXLSX.Text = "Load from URI (File on Server)";
            this.buttonLoadUriXLSX.UseVisualStyleBackColor = true;
            this.buttonLoadUriXLSX.Click += new System.EventHandler(this.ButtonLoadUriXLSX_Click);
            // 
            // buttonLoadUriAsp
            // 
            this.buttonLoadUriAsp.Location = new System.Drawing.Point(17, 160);
            this.buttonLoadUriAsp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoadUriAsp.Name = "buttonLoadUriAsp";
            this.buttonLoadUriAsp.Size = new System.Drawing.Size(314, 38);
            this.buttonLoadUriAsp.TabIndex = 2;
            this.buttonLoadUriAsp.Text = "Load from URI (ASP.NET Generated)";
            this.buttonLoadUriAsp.UseVisualStyleBackColor = true;
            this.buttonLoadUriAsp.Click += new System.EventHandler(this.ButtonLoadUriAsp_Click);
            // 
            // buttonNewWorkbook
            // 
            this.buttonNewWorkbook.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNewWorkbook.Location = new System.Drawing.Point(17, 20);
            this.buttonNewWorkbook.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.buttonNewWorkbook.Name = "buttonNewWorkbook";
            this.buttonNewWorkbook.Size = new System.Drawing.Size(314, 42);
            this.buttonNewWorkbook.TabIndex = 1;
            this.buttonNewWorkbook.Text = "New Workbook";
            this.buttonNewWorkbook.UseVisualStyleBackColor = true;
            this.buttonNewWorkbook.Click += new System.EventHandler(this.ButtonNewWorkbook_Click);
            // 
            // buttonLoadDisk
            // 
            this.buttonLoadDisk.Location = new System.Drawing.Point(17, 87);
            this.buttonLoadDisk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonLoadDisk.Name = "buttonLoadDisk";
            this.buttonLoadDisk.Size = new System.Drawing.Size(314, 38);
            this.buttonLoadDisk.TabIndex = 0;
            this.buttonLoadDisk.Text = "Load from Disk...";
            this.buttonLoadDisk.UseVisualStyleBackColor = true;
            this.buttonLoadDisk.Click += new System.EventHandler(this.ButtonLoadDisk_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.workbookView);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(362, 5);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 528);
            this.panel2.TabIndex = 3;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(0, 78);
            this.workbookView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(421, 450);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.progressBar);
            this.panel3.Controls.Add(this.locationLabel);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(421, 78);
            this.panel3.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(17, 18);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(604, 43);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 2;
            this.progressBar.Visible = false;
            // 
            // locationLabel
            // 
            this.locationLabel.AutoSize = true;
            this.locationLabel.Location = new System.Drawing.Point(250, 28);
            this.locationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(740, 25);
            this.locationLabel.TabIndex = 1;
            this.locationLabel.Text = "Select one of the buttons to create or open a workbook and load it into the Workb" +
    "ookView.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Workbook Source:";
            // 
            // ActiveWorkbookSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "ActiveWorkbookSample";
            this.Size = new System.Drawing.Size(787, 538);
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
        private System.Windows.Forms.Button buttonNewWorkbook;
        private System.Windows.Forms.Button buttonLoadDisk;
        private System.Windows.Forms.Button buttonLoadUriXLSX;
        private System.Windows.Forms.Button buttonLoadUriAsp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
