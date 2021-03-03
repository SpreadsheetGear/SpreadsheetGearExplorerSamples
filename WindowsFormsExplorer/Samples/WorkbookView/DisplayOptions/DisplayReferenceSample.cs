namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class DisplayReferenceSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.DisplayOptions.DisplayReferenceSample Sample { get; private set; }

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
            Sample = new SharedSamples.Samples.WorkboookView.DisplayOptions.DisplayReferenceSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);

            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
