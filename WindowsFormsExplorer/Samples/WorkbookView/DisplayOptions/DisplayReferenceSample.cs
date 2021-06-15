namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class DisplayReferenceSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.DisplayReferenceSample Sample { get; private set; }

        private void RadioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            // Get the selected display reference.
            string selectedItem = ((System.Windows.Forms.RadioButton)sender).Text;

            // Run the sample.
            Sample.UpdateDisplayReference(workbookView, selectedItem);
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
