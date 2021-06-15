namespace WindowsFormsExplorer.Samples.Calculations
{
    partial class CustomFunctionsSample
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelFeatures2 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelValues = new System.Windows.Forms.TableLayoutPanel();
            this.labelEnterValues = new System.Windows.Forms.Label();
            this.tableLayoutPanelEvaluate = new System.Windows.Forms.TableLayoutPanel();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.labelTitleFeatures = new System.Windows.Forms.Label();
            this.labelFeatures1 = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelValues.SuspendLayout();
            this.tableLayoutPanelEvaluate.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(225, 6);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 28);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(421, 6);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 28);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.labelFeatures2, 0, 8);
            this.tableLayoutPanelMain.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelValues, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelEvaluate, 0, 4);
            this.tableLayoutPanelMain.Controls.Add(this.labelTitleFeatures, 0, 6);
            this.tableLayoutPanelMain.Controls.Add(this.labelFeatures1, 0, 7);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 10);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 10;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(686, 336);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // labelFeatures2
            // 
            this.labelFeatures2.AutoSize = true;
            this.labelFeatures2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFeatures2.Location = new System.Drawing.Point(4, 278);
            this.labelFeatures2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelFeatures2.Name = "labelFeatures2";
            this.labelFeatures2.Size = new System.Drawing.Size(678, 22);
            this.labelFeatures2.TabIndex = 14;
            this.labelFeatures2.Text = "       •  This function extends the SpreadsheetGear.CustomFunctions.Function clas" +
    "s.";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(5, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(441, 37);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Custom Function Calculator";
            // 
            // tableLayoutPanelValues
            // 
            this.tableLayoutPanelValues.AutoSize = true;
            this.tableLayoutPanelValues.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelValues.ColumnCount = 4;
            this.tableLayoutPanelValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanelValues.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelValues.Controls.Add(this.textBox2, 3, 0);
            this.tableLayoutPanelValues.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanelValues.Controls.Add(this.labelEnterValues, 0, 0);
            this.tableLayoutPanelValues.Location = new System.Drawing.Point(4, 73);
            this.tableLayoutPanelValues.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanelValues.Name = "tableLayoutPanelValues";
            this.tableLayoutPanelValues.RowCount = 1;
            this.tableLayoutPanelValues.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelValues.Size = new System.Drawing.Size(600, 40);
            this.tableLayoutPanelValues.TabIndex = 4;
            // 
            // labelEnterValues
            // 
            this.labelEnterValues.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelEnterValues.AutoSize = true;
            this.labelEnterValues.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEnterValues.Location = new System.Drawing.Point(5, 9);
            this.labelEnterValues.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelEnterValues.Name = "labelEnterValues";
            this.labelEnterValues.Size = new System.Drawing.Size(210, 22);
            this.labelEnterValues.TabIndex = 1;
            this.labelEnterValues.Text = "Enter values for MYADD:";
            // 
            // tableLayoutPanelEvaluate
            // 
            this.tableLayoutPanelEvaluate.AutoSize = true;
            this.tableLayoutPanelEvaluate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelEvaluate.ColumnCount = 3;
            this.tableLayoutPanelEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanelEvaluate.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelEvaluate.Controls.Add(this.labelResult, 2, 0);
            this.tableLayoutPanelEvaluate.Controls.Add(this.buttonCalculate, 0, 0);
            this.tableLayoutPanelEvaluate.Location = new System.Drawing.Point(4, 139);
            this.tableLayoutPanelEvaluate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanelEvaluate.Name = "tableLayoutPanelEvaluate";
            this.tableLayoutPanelEvaluate.RowCount = 1;
            this.tableLayoutPanelEvaluate.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelEvaluate.Size = new System.Drawing.Size(324, 44);
            this.tableLayoutPanelEvaluate.TabIndex = 11;
            // 
            // labelResult
            // 
            this.labelResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelResult.Location = new System.Drawing.Point(118, 11);
            this.labelResult.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.labelResult.MinimumSize = new System.Drawing.Size(200, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(200, 22);
            this.labelResult.TabIndex = 9;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.AutoSize = true;
            this.buttonCalculate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCalculate.Location = new System.Drawing.Point(0, 6);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(0, 6, 5, 6);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(95, 32);
            this.buttonCalculate.TabIndex = 5;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.ButtonCalculate_Click);
            // 
            // labelTitleFeatures
            // 
            this.labelTitleFeatures.AutoSize = true;
            this.labelTitleFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitleFeatures.Location = new System.Drawing.Point(5, 219);
            this.labelTitleFeatures.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTitleFeatures.Name = "labelTitleFeatures";
            this.labelTitleFeatures.Size = new System.Drawing.Size(220, 22);
            this.labelTitleFeatures.TabIndex = 12;
            this.labelTitleFeatures.Text = "Notice These Features:";
            // 
            // labelFeatures1
            // 
            this.labelFeatures1.AutoSize = true;
            this.labelFeatures1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelFeatures1.Location = new System.Drawing.Point(4, 246);
            this.labelFeatures1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelFeatures1.Name = "labelFeatures1";
            this.labelFeatures1.Size = new System.Drawing.Size(534, 22);
            this.labelFeatures1.TabIndex = 13;
            this.labelFeatures1.Text = "       •  Demonstrates the use of a custom function named MYADD.";
            // 
            // CustomFunctionsSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CustomFunctionsSample";
            this.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.Size = new System.Drawing.Size(691, 352);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelValues.ResumeLayout(false);
            this.tableLayoutPanelValues.PerformLayout();
            this.tableLayoutPanelEvaluate.ResumeLayout(false);
            this.tableLayoutPanelEvaluate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelValues;
        private System.Windows.Forms.Label labelEnterValues;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelEvaluate;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label labelTitleFeatures;
        private System.Windows.Forms.Label labelFeatures2;
        private System.Windows.Forms.Label labelFeatures1;
    }
}
