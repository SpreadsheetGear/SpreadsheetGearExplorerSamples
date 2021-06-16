namespace WPFExplorer.Samples.Calculations
{
    public partial class FormulaEvaluationSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.Calculations.FormulaEvaluationSample Sample { get; private set; }

        private void EvaluateFormula()
        {
            try
            {
                labelResult.Content = Sample.EvaluateFormula(textBoxFormula.Text);
            }
            catch (System.Exception exc)
            {
                System.Windows.MessageBox.Show(exc.Message,
                    "SpreadsheetGear", System.Windows.MessageBoxButton.OK);
            }
        }

        private void ButtonEvaluate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            EvaluateFormula();
        }

        private void TextBoxFormula_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Return)
            {
                EvaluateFormula();
            }
        }

        private void ListBoxFormulas_SelectionChanged(
            object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var item = listBoxFormulas.SelectedItem as System.Windows.Controls.ListBoxItem;
            textBoxFormula.Text = item.Content.ToString();
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
