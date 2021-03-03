
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.workbookView = new WinFormsWorkbookView();
            this.buttonRunSample = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.buttonRunSample, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(149, 323);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(92, 3);
            this.workbookView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(53, 317);
            this.workbookView.TabIndex = 1;
            // 
            // buttonRunSample
            // 
            this.buttonRunSample.AutoSize = true;
            this.buttonRunSample.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonRunSample.Location = new System.Drawing.Point(4, 3);
            this.buttonRunSample.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonRunSample.Name = "buttonRunSample";
            this.buttonRunSample.Size = new System.Drawing.Size(80, 25);
            this.buttonRunSample.TabIndex = 0;
            this.buttonRunSample.Text = "Run Sample";
            this.buttonRunSample.UseVisualStyleBackColor = true;
            this.buttonRunSample.Click += new System.EventHandler(this.buttonRunSample_Click);
            // 
            // CustomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CustomControl";
            this.Size = new System.Drawing.Size(149, 323);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonRunSample;
        private WinFormsWorkbookView workbookView;
    }
}
