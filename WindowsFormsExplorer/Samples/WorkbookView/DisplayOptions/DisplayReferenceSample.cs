namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class DisplayReferenceSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.DisplayReferenceSample Sample { get; private set; }

        private void radioButton_CheckedChanged(object sender, System.EventArgs e)
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
