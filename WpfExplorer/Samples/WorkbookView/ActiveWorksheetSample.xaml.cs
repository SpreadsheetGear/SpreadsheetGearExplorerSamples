namespace WPFExplorer.Samples.WorkbookView
{
    public partial class ActiveWorksheetSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.ActiveWorksheetSample Sample { get; private set; }

        private void buttonRunSample_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView, true);

            // Run the sample.
            Sample.SetActiveWorksheet(workbookView);
        }


        #region Sample Initialization Code
        public ActiveWorksheetSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.WorkboookView.ActiveWorksheetSample();
            // DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
