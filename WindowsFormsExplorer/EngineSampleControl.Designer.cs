
namespace WindowsFormsExplorer
{
    partial class EngineSampleControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineSampleControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_runSample = new System.Windows.Forms.Button();
            this.button_resetSample = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 42);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(673, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_runSample);
            this.panel2.Controls.Add(this.button_resetSample);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 36);
            this.panel2.TabIndex = 0;
            // 
            // button_runSample
            // 
            this.button_runSample.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_runSample.Location = new System.Drawing.Point(9, 7);
            this.button_runSample.Margin = new System.Windows.Forms.Padding(1);
            this.button_runSample.Name = "button_runSample";
            this.button_runSample.Size = new System.Drawing.Size(115, 22);
            this.button_runSample.TabIndex = 0;
            this.button_runSample.Text = "Run Sample";
            this.button_runSample.UseVisualStyleBackColor = true;
            this.button_runSample.Click += new System.EventHandler(this.button_runSample_Click);
            // 
            // button_resetSample
            // 
            this.button_resetSample.Location = new System.Drawing.Point(140, 7);
            this.button_resetSample.Margin = new System.Windows.Forms.Padding(1);
            this.button_resetSample.Name = "button_resetSample";
            this.button_resetSample.Size = new System.Drawing.Size(115, 22);
            this.button_resetSample.TabIndex = 1;
            this.button_resetSample.Text = "Reset Sample";
            this.button_resetSample.UseVisualStyleBackColor = true;
            this.button_resetSample.Click += new System.EventHandler(this.button_resetSample_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(277, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(393, 36);
            this.panel3.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(142, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 15, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 15, 0);
            this.label1.Size = new System.Drawing.Size(251, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "SpreadsheetGear Engine for .NET Sample";
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(0, 42);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(673, 417);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // EngineSampleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.workbookView);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "EngineSampleControl";
            this.Size = new System.Drawing.Size(673, 459);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_resetSample;
        private System.Windows.Forms.Button button_runSample;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
