namespace WPFExplorer.Samples.Calculations
{
    public partial class CustomFunctionsSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Calculations.CustomFunctionsSample Sample { get; private set; }

        private void buttonCalculate_Click(object sender, System.Windows.RoutedEventArgs e)
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

        #region Sample Initialization Code
        public CustomFunctionsSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.Calculations.CustomFunctionsSample();
        }
        #endregion
    }
}
