namespace WindowsFormsExplorer.Samples.Calculations
{
    public partial class CustomFunctionsSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.Calculations.CustomFunctionsSample Sample { get; private set; }

        private void Calculate()
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
