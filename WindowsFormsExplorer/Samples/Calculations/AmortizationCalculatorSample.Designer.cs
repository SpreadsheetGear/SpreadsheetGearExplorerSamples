namespace WindowsFormsExplorer.Samples.Calculations
{
    partial class AmortizationCalculatorSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmortizationCalculatorSample));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelCalc = new System.Windows.Forms.TableLayoutPanel();
            this.labelInterestRate = new System.Windows.Forms.Label();
            this.labelTotalPeriods = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.textBoxRate = new System.Windows.Forms.TextBox();
            this.textBoxPeriods = new System.Windows.Forms.TextBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.labelLoanAmount = new System.Windows.Forms.Label();
            this.labelPaymentTitle = new System.Windows.Forms.Label();
            this.labelPayment = new System.Windows.Forms.Label();
            this.labelLastPaymentTitle = new System.Windows.Forms.Label();
            this.labelTotalInterestTitle = new System.Windows.Forms.Label();
            this.labelLastPayment = new System.Windows.Forms.Label();
            this.labelTotalInterest = new System.Windows.Forms.Label();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelCalc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.AutoSize = true;
            this.tableLayoutPanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelCalc, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.workbookView, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 4;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(581, 471);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // tableLayoutPanelCalc
            // 
            this.tableLayoutPanelCalc.AutoSize = true;
            this.tableLayoutPanelCalc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelCalc.ColumnCount = 5;
            this.tableLayoutPanelCalc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelCalc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelCalc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanelCalc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelCalc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCalc.Controls.Add(this.labelInterestRate, 0, 1);
            this.tableLayoutPanelCalc.Controls.Add(this.labelTotalPeriods, 0, 2);
            this.tableLayoutPanelCalc.Controls.Add(this.textBoxAmount, 1, 0);
            this.tableLayoutPanelCalc.Controls.Add(this.textBoxRate, 1, 1);
            this.tableLayoutPanelCalc.Controls.Add(this.textBoxPeriods, 1, 2);
            this.tableLayoutPanelCalc.Controls.Add(this.buttonCalculate, 1, 4);
            this.tableLayoutPanelCalc.Controls.Add(this.labelLoanAmount, 0, 0);
            this.tableLayoutPanelCalc.Controls.Add(this.labelPaymentTitle, 3, 0);
            this.tableLayoutPanelCalc.Controls.Add(this.labelPayment, 4, 0);
            this.tableLayoutPanelCalc.Controls.Add(this.labelLastPaymentTitle, 3, 1);
            this.tableLayoutPanelCalc.Controls.Add(this.labelTotalInterestTitle, 3, 2);
            this.tableLayoutPanelCalc.Controls.Add(this.labelLastPayment, 4, 1);
            this.tableLayoutPanelCalc.Controls.Add(this.labelTotalInterest, 4, 2);
            this.tableLayoutPanelCalc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelCalc.Location = new System.Drawing.Point(4, 18);
            this.tableLayoutPanelCalc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanelCalc.Name = "tableLayoutPanelCalc";
            this.tableLayoutPanelCalc.RowCount = 5;
            this.tableLayoutPanelCalc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCalc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCalc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCalc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCalc.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelCalc.Size = new System.Drawing.Size(573, 112);
            this.tableLayoutPanelCalc.TabIndex = 1;
            // 
            // labelInterestRate
            // 
            this.labelInterestRate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelInterestRate.AutoSize = true;
            this.labelInterestRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelInterestRate.Location = new System.Drawing.Point(37, 33);
            this.labelInterestRate.Margin = new System.Windows.Forms.Padding(5);
            this.labelInterestRate.Name = "labelInterestRate";
            this.labelInterestRate.Size = new System.Drawing.Size(108, 15);
            this.labelInterestRate.TabIndex = 2;
            this.labelInterestRate.Text = "Interest Rate (rate)";
            // 
            // labelTotalPeriods
            // 
            this.labelTotalPeriods.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTotalPeriods.AutoSize = true;
            this.labelTotalPeriods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTotalPeriods.Location = new System.Drawing.Point(5, 60);
            this.labelTotalPeriods.Margin = new System.Windows.Forms.Padding(5);
            this.labelTotalPeriods.Name = "labelTotalPeriods";
            this.labelTotalPeriods.Size = new System.Drawing.Size(140, 15);
            this.labelTotalPeriods.TabIndex = 4;
            this.labelTotalPeriods.Text = "Total # of Periods (Nper)";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxAmount.Location = new System.Drawing.Point(154, 3);
            this.textBoxAmount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(111, 21);
            this.textBoxAmount.TabIndex = 1;
            this.textBoxAmount.Text = "$150,000";
            // 
            // textBoxRate
            // 
            this.textBoxRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRate.Location = new System.Drawing.Point(154, 30);
            this.textBoxRate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxRate.Name = "textBoxRate";
            this.textBoxRate.Size = new System.Drawing.Size(111, 21);
            this.textBoxRate.TabIndex = 3;
            this.textBoxRate.Text = "6.25%";
            // 
            // textBoxPeriods
            // 
            this.textBoxPeriods.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPeriods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPeriods.Location = new System.Drawing.Point(154, 57);
            this.textBoxPeriods.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxPeriods.Name = "textBoxPeriods";
            this.textBoxPeriods.Size = new System.Drawing.Size(111, 21);
            this.textBoxPeriods.TabIndex = 5;
            this.textBoxPeriods.Text = "360";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCalculate.AutoSize = true;
            this.buttonCalculate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCalculate.Location = new System.Drawing.Point(197, 84);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(68, 25);
            this.buttonCalculate.TabIndex = 6;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // labelLoanAmount
            // 
            this.labelLoanAmount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelLoanAmount.AutoSize = true;
            this.labelLoanAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLoanAmount.Location = new System.Drawing.Point(42, 6);
            this.labelLoanAmount.Margin = new System.Windows.Forms.Padding(5);
            this.labelLoanAmount.Name = "labelLoanAmount";
            this.labelLoanAmount.Size = new System.Drawing.Size(103, 15);
            this.labelLoanAmount.TabIndex = 0;
            this.labelLoanAmount.Text = "Loan Amount (pv)";
            // 
            // labelPaymentTitle
            // 
            this.labelPaymentTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPaymentTitle.AutoSize = true;
            this.labelPaymentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPaymentTitle.Location = new System.Drawing.Point(283, 6);
            this.labelPaymentTitle.Margin = new System.Windows.Forms.Padding(5);
            this.labelPaymentTitle.Name = "labelPaymentTitle";
            this.labelPaymentTitle.Size = new System.Drawing.Size(66, 15);
            this.labelPaymentTitle.TabIndex = 7;
            this.labelPaymentTitle.Text = "Payment:";
            // 
            // labelPayment
            // 
            this.labelPayment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPayment.AutoSize = true;
            this.labelPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPayment.Location = new System.Drawing.Point(390, 6);
            this.labelPayment.Margin = new System.Windows.Forms.Padding(5);
            this.labelPayment.MinimumSize = new System.Drawing.Size(140, 0);
            this.labelPayment.Name = "labelPayment";
            this.labelPayment.Size = new System.Drawing.Size(140, 15);
            this.labelPayment.TabIndex = 8;
            // 
            // labelLastPaymentTitle
            // 
            this.labelLastPaymentTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLastPaymentTitle.AutoSize = true;
            this.labelLastPaymentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLastPaymentTitle.Location = new System.Drawing.Point(283, 33);
            this.labelLastPaymentTitle.Margin = new System.Windows.Forms.Padding(5);
            this.labelLastPaymentTitle.Name = "labelLastPaymentTitle";
            this.labelLastPaymentTitle.Size = new System.Drawing.Size(97, 15);
            this.labelLastPaymentTitle.TabIndex = 9;
            this.labelLastPaymentTitle.Text = "Last Payment:";
            // 
            // labelTotalInterestTitle
            // 
            this.labelTotalInterestTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTotalInterestTitle.AutoSize = true;
            this.labelTotalInterestTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTotalInterestTitle.Location = new System.Drawing.Point(283, 60);
            this.labelTotalInterestTitle.Margin = new System.Windows.Forms.Padding(5);
            this.labelTotalInterestTitle.Name = "labelTotalInterestTitle";
            this.labelTotalInterestTitle.Size = new System.Drawing.Size(95, 15);
            this.labelTotalInterestTitle.TabIndex = 11;
            this.labelTotalInterestTitle.Text = "Total Interest:";
            // 
            // labelLastPayment
            // 
            this.labelLastPayment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLastPayment.AutoSize = true;
            this.labelLastPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLastPayment.Location = new System.Drawing.Point(390, 33);
            this.labelLastPayment.Margin = new System.Windows.Forms.Padding(5);
            this.labelLastPayment.MinimumSize = new System.Drawing.Size(140, 0);
            this.labelLastPayment.Name = "labelLastPayment";
            this.labelLastPayment.Size = new System.Drawing.Size(140, 15);
            this.labelLastPayment.TabIndex = 10;
            // 
            // labelTotalInterest
            // 
            this.labelTotalInterest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTotalInterest.AutoSize = true;
            this.labelTotalInterest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTotalInterest.Location = new System.Drawing.Point(390, 60);
            this.labelTotalInterest.Margin = new System.Windows.Forms.Padding(5);
            this.labelTotalInterest.MinimumSize = new System.Drawing.Size(140, 0);
            this.labelTotalInterest.Name = "labelTotalInterest";
            this.labelTotalInterest.Size = new System.Drawing.Size(140, 15);
            this.labelTotalInterest.TabIndex = 12;
            // 
            // workbookView
            // 
            this.workbookView.DisplayReference = "AmortizationTableForNPer";
            this.workbookView.DisplayReferenceName = "\"Amortization Schedule\"";
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(4, 154);
            this.workbookView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(573, 314);
            this.workbookView.TabIndex = 2;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.Location = new System.Drawing.Point(4, 0);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(108, 15);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Loan Calculator";
            // 
            // AmortizationCalculatorSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "AmortizationCalculatorSample";
            this.Size = new System.Drawing.Size(581, 471);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.tableLayoutPanelCalc.ResumeLayout(false);
            this.tableLayoutPanelCalc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCalc;
        private System.Windows.Forms.Label labelInterestRate;
        private System.Windows.Forms.Label labelTotalPeriods;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.TextBox textBoxRate;
        private System.Windows.Forms.TextBox textBoxPeriods;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label labelLoanAmount;
        private System.Windows.Forms.Label labelPaymentTitle;
        private System.Windows.Forms.Label labelPayment;
        private System.Windows.Forms.Label labelLastPaymentTitle;
        private System.Windows.Forms.Label labelTotalInterestTitle;
        private System.Windows.Forms.Label labelLastPayment;
        private System.Windows.Forms.Label labelTotalInterest;
    }
}
