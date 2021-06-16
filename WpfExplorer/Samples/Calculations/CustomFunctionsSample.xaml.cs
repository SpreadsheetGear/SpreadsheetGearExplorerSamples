namespace WPFExplorer.Samples.Calculations
{
    public partial class CustomFunctionsSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.Calculations.CustomFunctionsSample Sample { get; private set; }

        private void Calculate()
        {
            try
            {
                // Run the sample, passing in the 2 inputs provided by the user.
                string result = Sample.PerformAddCalculation(textBox1.Text, textBox2.Text);

                // Display the results in a label.
                labelResult.Content = result;
            }
            catch (System.Exception exc)
            {
                System.Windows.MessageBox.Show(exc.Message,
                    "SpreadsheetGear", System.Windows.MessageBoxButton.OK);
            }
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
        public CustomFunctionsSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.Calculations.CustomFunctionsSample();
        }
        #endregion
    }
}
