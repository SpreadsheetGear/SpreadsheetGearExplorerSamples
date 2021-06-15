namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    partial class WorksheetWindowInfoSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorksheetWindowInfoSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonFreezePanes = new System.Windows.Forms.Button();
            this.buttonHeadings = new System.Windows.Forms.Button();
            this.buttonGridlines = new System.Windows.Forms.Button();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 798);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.buttonFreezePanes, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonHeadings, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.buttonGridlines, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 9);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(300, 780);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // buttonFreezePanes
            // 
            this.buttonFreezePanes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFreezePanes.AutoSize = true;
            this.buttonFreezePanes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonFreezePanes.Location = new System.Drawing.Point(8, 9);
            this.buttonFreezePanes.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.buttonFreezePanes.Name = "buttonFreezePanes";
            this.buttonFreezePanes.Size = new System.Drawing.Size(284, 47);
            this.buttonFreezePanes.TabIndex = 1;
            this.buttonFreezePanes.Text = "Freeze Panes";
            this.buttonFreezePanes.UseVisualStyleBackColor = true;
            this.buttonFreezePanes.Click += new System.EventHandler(this.ButtonFreezePanes_Click);
            // 
            // buttonHeadings
            // 
            this.buttonHeadings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHeadings.AutoSize = true;
            this.buttonHeadings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonHeadings.Location = new System.Drawing.Point(8, 139);
            this.buttonHeadings.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.buttonHeadings.Name = "buttonHeadings";
            this.buttonHeadings.Size = new System.Drawing.Size(284, 47);
            this.buttonHeadings.TabIndex = 3;
            this.buttonHeadings.Text = "Headings";
            this.buttonHeadings.UseVisualStyleBackColor = true;
            this.buttonHeadings.Click += new System.EventHandler(this.ButtonHeadings_Click);
            // 
            // buttonGridlines
            // 
            this.buttonGridlines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGridlines.AutoSize = true;
            this.buttonGridlines.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGridlines.Location = new System.Drawing.Point(8, 74);
            this.buttonGridlines.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.buttonGridlines.Name = "buttonGridlines";
            this.buttonGridlines.Size = new System.Drawing.Size(284, 47);
            this.buttonGridlines.TabIndex = 2;
            this.buttonGridlines.Text = "Gridlines";
            this.buttonGridlines.UseVisualStyleBackColor = true;
            this.buttonGridlines.Click += new System.EventHandler(this.ButtonGridlines_Click);
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(324, 9);
            this.workbookView.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(480, 780);
            this.workbookView.TabIndex = 0;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zoomTrackBar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 217);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zoom:";
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.Location = new System.Drawing.Point(27, 82);
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(242, 101);
            this.zoomTrackBar.TabIndex = 1;
            this.zoomTrackBar.ValueChanged += new System.EventHandler(this.ZoomTrackBar_ValueChanged);
            // 
            // WorksheetWindowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.Name = "WorksheetWindowInfo";
            this.Size = new System.Drawing.Size(812, 798);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.Button buttonFreezePanes;
        private System.Windows.Forms.Button buttonGridlines;
        private System.Windows.Forms.Button buttonHeadings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.Label label1;
    }
}
