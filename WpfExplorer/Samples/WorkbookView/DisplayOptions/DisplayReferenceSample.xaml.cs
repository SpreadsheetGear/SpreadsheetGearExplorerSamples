namespace WPFExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class DisplayReferenceSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.DisplayReferenceSample Sample { get; private set; }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            var radioButton = (System.Windows.Controls.RadioButton)e.Source;
            Sample.UpdateDisplayReference(workbookView, radioButton.Tag.ToString());
        }

        #region Sample Initialization Code
        public DisplayReferenceSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.DisplayOptions.DisplayReferenceSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);

            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
