namespace WindowsFormsExplorer.Samples.Calculations
{
    public partial class CustomFunctionsSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Calculations.CustomFunctionsSample Sample { get; private set; }

        private void buttonCalculate_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Run the sample, passing in the 2 inputs provided by the user.
                string result = Sample.PerformAddCalculation(textBox1.Text, textBox2.Text);

                // Display the results in a label.
                labelResult.Text = result;
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(this, exc.Message, "SpreadsheetGear Explorer",
                    System.Windows.Forms.MessageBoxButtons.OK);
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
            Sample = new SamplesLibrary.Samples.Calculations.CustomFunctionsSample();
        }
        #endregion
    }
}
