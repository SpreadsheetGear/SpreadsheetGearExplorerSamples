namespace WindowsFormsExplorer.Samples.Reporting
{
    public partial class WorkbookConsolidationSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Reporting.WorkbookConsolidationSample Sample { get; private set; }

        private void radioButton_CheckedChanged(object sender, System.EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView, false);

            // Get the region that is selected.
            string selectedRegion = "Both";
            if (radioButtonEast.Checked)
                selectedRegion = "East";
            else if (radioButtonWest.Checked)
                selectedRegion = "West";

            // Run the sample.
            Sample.RunReport(workbookView, selectedRegion);
        }


        #region Sample Initialization Code
        public WorkbookConsolidationSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.Reporting.WorkbookConsolidationSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
