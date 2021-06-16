namespace WPFExplorer.Samples.Calculations
{
    public partial class AmortizationCalculatorSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.Calculations.AmortizationCalculatorSample Sample { get; private set; }

        private void Calculate()
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView.  Disposal of 
            /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
            /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
            /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
            /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
            DisposalManager.ResetWorkbookView(workbookView, false);

            // Get values from user.
            string loanAmount = textBoxAmount.Text;
            string interestRate = textBoxRate.Text;
            string numPeriods = textBoxPeriods.Text;

            // Run sample and get results back.
            SamplesLibrary.Samples.Calculations.AmortizationCalculatorResults results = Sample.Calculate(loanAmount, interestRate, numPeriods);

            // Copy over the original user inputs.  Note that simple-inputted values are now more nicely 
            // formatted (such as a loan amount of "1000" formatted to "$1,000").
            textBoxAmount.Text = results.LoanAmount;
            textBoxRate.Text = results.InterestRate;
            textBoxPeriods.Text = results.NumPeriods;

            // Display the calculated results.
            labelPayment.Content = results.Payment;
            labelLastPayment.Content = results.LastPayment;
            labelTotalInterest.Content = results.TotalInterest;

            // Set the active workbook of the WorkbookView to the returned workbook, which will contain
            // the amortization table.
            workbookView.ActiveWorkbook = results.ResultsWorkbook;
        }

        private void ButtonCalculate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Calculate();
        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                Calculate();
        }

        #region Sample Initialization Code
        public AmortizationCalculatorSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.Calculations.AmortizationCalculatorSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
