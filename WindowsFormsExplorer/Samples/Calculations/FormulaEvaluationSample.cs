namespace WindowsFormsExplorer.Samples.Calculations
{
    public partial class FormulaEvaluationSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
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

        private void ButtonEvaluate_Click(object sender, System.EventArgs e)
        {
            EvaluateFormula();
        }

        private void TextBoxFormula_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
                EvaluateFormula();
        }

        private void ListBox1_SelectedIndexChanged(object sender, System.EventArgs e)
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
