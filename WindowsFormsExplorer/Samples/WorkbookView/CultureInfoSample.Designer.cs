namespace WindowsFormsExplorer.Samples.WorkbookView
{
    partial class CultureInfoSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CultureInfoSample));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox_cultures = new System.Windows.Forms.ListBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_runSample = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.workbookView_deDE = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.formulaBar1 = new SpreadsheetGear.Windows.Forms.FormulaBar();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.workbookView_selectedCulture = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.formulaBar2 = new SpreadsheetGear.Windows.Forms.FormulaBar();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox_cultures);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1725, 1342);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 0;
            // 
            // listBox_cultures
            // 
            this.listBox_cultures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_cultures.FormattingEnabled = true;
            this.listBox_cultures.ItemHeight = 37;
            this.listBox_cultures.Location = new System.Drawing.Point(0, 109);
            this.listBox_cultures.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listBox_cultures.Name = "listBox_cultures";
            this.listBox_cultures.Size = new System.Drawing.Size(332, 1233);
            this.listBox_cultures.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_runSample);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(332, 109);
            this.panel3.TabIndex = 2;
            // 
            // button_runSample
            // 
            this.button_runSample.Location = new System.Drawing.Point(34, 17);
            this.button_runSample.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_runSample.Name = "button_runSample";
            this.button_runSample.Size = new System.Drawing.Size(264, 81);
            this.button_runSample.TabIndex = 0;
            this.button_runSample.Text = "Run Sample";
            this.button_runSample.UseVisualStyleBackColor = true;
            this.button_runSample.Click += new System.EventHandler(this.button_runSample_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Size = new System.Drawing.Size(1389, 1342);
            this.splitContainer2.SplitterDistance = 649;
            this.splitContainer2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.workbookView_deDE);
            this.panel1.Controls.Add(this.formulaBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(649, 1305);
            this.panel1.TabIndex = 0;
            // 
            // workbookView_deDE
            // 
            this.workbookView_deDE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView_deDE.FormulaBar = this.formulaBar1;
            this.workbookView_deDE.Location = new System.Drawing.Point(0, 59);
            this.workbookView_deDE.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workbookView_deDE.Name = "workbookView_deDE";
            this.workbookView_deDE.Size = new System.Drawing.Size(649, 1246);
            this.workbookView_deDE.TabIndex = 1;
            //this.workbookView_deDE.WorkbookSetState = resources.GetString("workbookView_deDE.WorkbookSetState");
            // 
            // formulaBar1
            // 
            this.formulaBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.formulaBar1.Location = new System.Drawing.Point(0, 0);
            this.formulaBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.formulaBar1.Name = "formulaBar1";
            this.formulaBar1.Size = new System.Drawing.Size(649, 59);
            this.formulaBar1.TabIndex = 0;
            this.formulaBar1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "German Culture (de-DE)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.workbookView_selectedCulture);
            this.panel2.Controls.Add(this.formulaBar2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 1305);
            this.panel2.TabIndex = 3;
            // 
            // workbookView_selectedCulture
            // 
            this.workbookView_selectedCulture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView_selectedCulture.FormulaBar = this.formulaBar2;
            this.workbookView_selectedCulture.Location = new System.Drawing.Point(0, 59);
            this.workbookView_selectedCulture.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workbookView_selectedCulture.Name = "workbookView_selectedCulture";
            this.workbookView_selectedCulture.Size = new System.Drawing.Size(736, 1246);
            this.workbookView_selectedCulture.TabIndex = 1;
            // 
            // formulaBar2
            // 
            this.formulaBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.formulaBar2.Location = new System.Drawing.Point(0, 0);
            this.formulaBar2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.formulaBar2.Name = "formulaBar2";
            this.formulaBar2.Size = new System.Drawing.Size(736, 59);
            this.formulaBar2.TabIndex = 0;
            this.formulaBar2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 37);
            this.label2.TabIndex = 2;
            this.label2.Text = "Selected Culture";
            // 
            // CultureInfoSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CultureInfoSample";
            this.Size = new System.Drawing.Size(1725, 1342);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_runSample;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel1;
        private WinFormsWorkbookView workbookView_deDE;
        private SpreadsheetGear.Windows.Forms.FormulaBar formulaBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private WinFormsWorkbookView workbookView_selectedCulture;
        private SpreadsheetGear.Windows.Forms.FormulaBar formulaBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_cultures;
        private System.Windows.Forms.Panel panel3;
    }
}
