namespace WindowsFormsExplorer.Samples.Calculations
{
    public partial class SimpleLoanCalculatorSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Calculations.SimpleLoanCalculatorSample Sample { get; private set; }

        private void buttonCalculate_Click(object sender, System.EventArgs e)
        {
            SharedSamples.Samples.Calculations.SimpleLoanCalculatorResults results =
                Sample.Calculate(textBoxAmount.Text, textBoxRate.Text, textBoxPeriods.Text);

            // Copy over the original user inputs.  Note that simple-inputted values are now more nicely 
            // formatted (such as a loan amount of "1000" formatted to "$1,000").
            textBoxAmount.Text = results.LoanAmount;
            textBoxRate.Text = results.InterestRate;
            textBoxPeriods.Text = results.NumPeriods;

            // Display the calculated result.
            labelPayment.Text = results.Payment;
        }


        #region Sample Initialization Code
        public SimpleLoanCalculatorSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.Calculations.SimpleLoanCalculatorSample();
        }
        #endregion
    }
}
