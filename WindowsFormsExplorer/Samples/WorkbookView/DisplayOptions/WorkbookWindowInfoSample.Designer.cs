namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    partial class WorkbookWindowInfoSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkbookWindowInfoSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonToggleSheetTabs = new System.Windows.Forms.Button();
            this.buttonToggleScrollBars = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabRatioTrackBar = new System.Windows.Forms.TrackBar();
            this.labelTabRatio = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabRatioTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.workbookView, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(535, 322);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(204, 3);
            this.workbookView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(327, 316);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonToggleSheetTabs, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonToggleScrollBars, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 316);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // buttonToggleSheetTabs
            // 
            this.buttonToggleSheetTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToggleSheetTabs.Location = new System.Drawing.Point(3, 53);
            this.buttonToggleSheetTabs.Name = "buttonToggleSheetTabs";
            this.buttonToggleSheetTabs.Size = new System.Drawing.Size(188, 44);
            this.buttonToggleSheetTabs.TabIndex = 1;
            this.buttonToggleSheetTabs.Text = "Toggle Sheet Tabs";
            this.buttonToggleSheetTabs.UseVisualStyleBackColor = true;
            this.buttonToggleSheetTabs.Click += new System.EventHandler(this.ButtonToggleSheetTabs_Click);
            // 
            // buttonToggleScrollBars
            // 
            this.buttonToggleScrollBars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonToggleScrollBars.Location = new System.Drawing.Point(3, 3);
            this.buttonToggleScrollBars.Name = "buttonToggleScrollBars";
            this.buttonToggleScrollBars.Size = new System.Drawing.Size(188, 44);
            this.buttonToggleScrollBars.TabIndex = 0;
            this.buttonToggleScrollBars.Text = "Toggle Scroll Bars";
            this.buttonToggleScrollBars.UseVisualStyleBackColor = true;
            this.buttonToggleScrollBars.Click += new System.EventHandler(this.ButtonToggleScrollBars_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabRatioTrackBar);
            this.panel1.Controls.Add(this.labelTabRatio);
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(188, 76);
            this.panel1.TabIndex = 2;
            // 
            // tabRatioTrackBar
            // 
            this.tabRatioTrackBar.Location = new System.Drawing.Point(9, 27);
            this.tabRatioTrackBar.Maximum = 100;
            this.tabRatioTrackBar.Name = "tabRatioTrackBar";
            this.tabRatioTrackBar.Size = new System.Drawing.Size(166, 45);
            this.tabRatioTrackBar.TabIndex = 1;
            this.tabRatioTrackBar.ValueChanged += new System.EventHandler(this.TabRatioTrackBar_ValueChanged);
            // 
            // labelTabRatio
            // 
            this.labelTabRatio.AutoSize = true;
            this.labelTabRatio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTabRatio.Location = new System.Drawing.Point(9, 9);
            this.labelTabRatio.Name = "labelTabRatio";
            this.labelTabRatio.Size = new System.Drawing.Size(64, 15);
            this.labelTabRatio.TabIndex = 0;
            this.labelTabRatio.Text = "Tab Ratio: ";
            // 
            // WorkbookWindowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WorkbookWindowInfo";
            this.Size = new System.Drawing.Size(535, 322);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabRatioTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonToggleSheetTabs;
        private System.Windows.Forms.Button buttonToggleScrollBars;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTabRatio;
        private System.Windows.Forms.TrackBar tabRatioTrackBar;
    }
}