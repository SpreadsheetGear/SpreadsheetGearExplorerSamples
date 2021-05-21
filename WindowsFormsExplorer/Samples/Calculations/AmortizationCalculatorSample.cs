namespace WindowsFormsExplorer.Samples.Calculations
{
    public partial class AmortizationCalculatorSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Calculations.AmortizationCalculatorSample Sample { get; private set; }

        private void buttonCalculate_Click(object sender, System.EventArgs e)
        {
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
            labelPayment.Text = results.Payment;
            labelLastPayment.Text = results.LastPayment;
            labelTotalInterest.Text = results.TotalInterest;

            // Set the active workbook of the WorkbookView to the returned workbook, which will contain
            // the amortization table.
            workbookView.ActiveWorkbook = results.ResultsWorkbook;
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
