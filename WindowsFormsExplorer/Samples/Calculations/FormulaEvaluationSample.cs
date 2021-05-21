namespace WindowsFormsExplorer.Samples.Calculations
{
    public partial class FormulaEvaluationSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Calculations.FormulaEvaluationSample Sample { get; private set; }

        private void EvaluateFormula()
        {
            try
            {
                labelResult.Text = Sample.EvaluateFormula(textBoxFormula.Text);
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(this, exc.Message, "SpreadsheetGear Explorer",
                    System.Windows.Forms.MessageBoxButtons.OK);
            }
        }


        private void buttonEvaluate_Click(object sender, System.EventArgs e)
        {
            EvaluateFormula();
        }


        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            textBoxFormula.Text = exampleFormulasListBox.Text;
            EvaluateFormula();
        }


        #region Sample Initialization Code
        public FormulaEvaluationSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.Calculations.FormulaEvaluationSample();
        }
        #endregion
    }
}
