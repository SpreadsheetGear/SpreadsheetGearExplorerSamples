// NOTE: a web-based version of this sample is available to run and execute on our website at:
// https://www.spreadsheetgear.com/Support/Samples/RazorPages/AmortizationCalculator
namespace WindowsFormsExplorer.Samples.Calculations
{
    public partial class AmortizationCalculatorSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Windows.Samples.Calculations.AmortizationCalculatorSample Sample { get; private set; }

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
            SamplesLibrary.Windows.Samples.Calculations.AmortizationCalculatorResults results = Sample.Calculate(loanAmount, interestRate, numPeriods);

            // Copy over the original user inputs.  Note that simple-inputted values are now more nicely 
            // formatted (such as a loan amount of "1000" formatted to "$1,000").
            textBoxAmount.Text = results.LoanAmount;
            textBoxRate.Text = results.InterestRate;
            textBoxPeriods.Text = results.NumPeriods;

            // Display the calculated results.
            labelPayment.Text = results.Payment;
            labelLastPayment.Text = results.LastPayment;
            labelTotalInterest.Text = results.TotalInterest;

            // Set the active workbook of the WorkbookView to the returned workbook, which will contain
            // the amortization table.
            workbookView.ActiveWorkbook = results.ResultsWorkbook;
        }

        private void ButtonCalculate_Click(object sender, System.EventArgs e)
        {
            Calculate();
        }

        private void TextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
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
            Sample = new SamplesLibrary.Windows.Samples.Calculations.AmortizationCalculatorSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
