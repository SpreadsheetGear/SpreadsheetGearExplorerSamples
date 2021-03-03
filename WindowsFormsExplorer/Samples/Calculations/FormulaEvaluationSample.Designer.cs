namespace WindowsFormsExplorer.Samples.Calculations
{
    partial class FormulaEvaluationSample
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxFormula = new System.Windows.Forms.TextBox();
            this.labelEnterFormula = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelEvaluate = new System.Windows.Forms.TableLayoutPanel();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonEvaluate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exampleFormulasListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelEvaluate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.textBoxFormula, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.labelEnterFormula, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelEvaluate, 0, 5);
            this.tableLayoutPanelMain.Controls.Add(this.panel1, 0, 6);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 7;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(429, 313);
            this.tableLayoutPanelMain.TabIndex = 2;
            // 
            // textBoxFormula
            // 
            this.textBoxFormula.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxFormula.Location = new System.Drawing.Point(4, 53);
            this.textBoxFormula.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFormula.Name = "textBoxFormula";
            this.textBoxFormula.Size = new System.Drawing.Size(421, 21);
            this.textBoxFormula.TabIndex = 4;
            this.textBoxFormula.Text = "TEXT(STDEV(1, 2, 3, 4), \"0.00\")";
            // 
            // labelEnterFormula
            // 
            this.labelEnterFormula.AutoSize = true;
            this.labelEnterFormula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEnterFormula.Location = new System.Drawing.Point(4, 34);
            this.labelEnterFormula.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEnterFormula.Name = "labelEnterFormula";
            this.labelEnterFormula.Size = new System.Drawing.Size(243, 15);
            this.labelEnterFormula.TabIndex = 3;
            this.labelEnterFormula.Text = "Enter Excel compatible formula to evaluate:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(4, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(172, 15);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "Evaluate Formula Sample";
            // 
            // tableLayoutPanelEvaluate
            // 
            this.tableLayoutPanelEvaluate.AutoSize = true;
            this.tableLayoutPanelEvaluate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelEvaluate.ColumnCount = 3;
            this.tableLayoutPanelEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanelEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEvaluate.Controls.Add(this.labelResult, 2, 0);
            this.tableLayoutPanelEvaluate.Controls.Add(this.buttonEvaluate, 0, 0);
            this.tableLayoutPanelEvaluate.Location = new System.Drawing.Point(3, 90);
            this.tableLayoutPanelEvaluate.Name = "tableLayoutPanelEvaluate";
            this.tableLayoutPanelEvaluate.RowCount = 1;
            this.tableLayoutPanelEvaluate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelEvaluate.Size = new System.Drawing.Size(225, 33);
            this.tableLayoutPanelEvaluate.TabIndex = 10;
            // 
            // labelResult
            // 
            this.labelResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelResult.Location = new System.Drawing.Point(81, 9);
            this.labelResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelResult.MinimumSize = new System.Drawing.Size(140, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(140, 15);
            this.labelResult.TabIndex = 9;
            // 
            // buttonEvaluate
            // 
            this.buttonEvaluate.AutoSize = true;
            this.buttonEvaluate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEvaluate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonEvaluate.Location = new System.Drawing.Point(0, 4);
            this.buttonEvaluate.Margin = new System.Windows.Forms.Padding(0, 4, 4, 4);
            this.buttonEvaluate.Name = "buttonEvaluate";
            this.buttonEvaluate.Size = new System.Drawing.Size(64, 25);
            this.buttonEvaluate.TabIndex = 5;
            this.buttonEvaluate.Text = "Evaluate";
            this.buttonEvaluate.UseVisualStyleBackColor = false;
            this.buttonEvaluate.Click += new System.EventHandler(this.buttonEvaluate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.exampleFormulasListBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 181);
            this.panel1.TabIndex = 11;
            // 
            // listBox1
            // 
            this.exampleFormulasListBox.FormattingEnabled = true;
            this.exampleFormulasListBox.ItemHeight = 15;
            this.exampleFormulasListBox.Items.AddRange(new object[] {
            "SUM(1,2,3)",
            "IF(HOUR(NOW())&lt;12, \"Good Morning!\", \"Good Afternoon\")",
            "ROUND(RAND()*100, 0)",
            "VLOOKUP(2, {1,\"a\";2,\"b\";3,\"c\";4,\"d\";5,\"e\"}, 2)",
            "PMT(3.99%/12, 60, 25000)",
            "TEXT(PMT(3.99%/12, 60, 25000), \"$#,##0.00_);($#,##0.00)\")"});
            this.exampleFormulasListBox.Location = new System.Drawing.Point(12, 34);
            this.exampleFormulasListBox.Name = "listBox1";
            this.exampleFormulasListBox.Size = new System.Drawing.Size(391, 124);
            this.exampleFormulasListBox.TabIndex = 1;
            this.exampleFormulasListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Example Formulas:";
            // 
            // FormulaEvaluationSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormulaEvaluationSample";
            this.Size = new System.Drawing.Size(433, 317);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelEvaluate.ResumeLayout(false);
            this.tableLayoutPanelEvaluate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelEnterFormula;
        private System.Windows.Forms.TextBox textBoxFormula;
        private System.Windows.Forms.Button buttonEvaluate;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEvaluate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox exampleFormulasListBox;
    }
}
