namespace WPFExplorer.Samples.Advanced
{
    public partial class PerformanceSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Advanced.PerformanceSample Sample { get; private set; }

        private void buttonRunSample_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView, false);

            // Run the sample.
            Sample.RunSample(workbookView.ActiveWorkbookSet);
        }

        #region Sample Initialization Code
        public PerformanceSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            buttonRunSample.Click += buttonRunSample_Click;
            Sample = new SharedSamples.Samples.Advanced.PerformanceSample();
            // DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
