namespace WPFExplorer.Samples.Calculations
{
    public partial class SimpleLoanCalculatorSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.Calculations.SimpleLoanCalculatorSample Sample { get; private set; }

        private void Calculate()
        {
            SamplesLibrary.Samples.Calculations.SimpleLoanCalculatorResults results =
                Sample.Calculate(textBoxAmount.Text, textBoxRate.Text, textBoxPeriods.Text);

            // Copy over the original user inputs.  Note that simple-inputted values are now more nicely 
            // formatted (such as a loan amount of "1000" formatted to "$1,000").
            textBoxAmount.Text = results.LoanAmount;
            textBoxRate.Text = results.InterestRate;
            textBoxPeriods.Text = results.NumPeriods;

            // Display the calculated result.
            labelPayment.Content = results.Payment;
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
        public SimpleLoanCalculatorSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.Calculations.SimpleLoanCalculatorSample();
        }
        #endregion
    }
}
