namespace WPFExplorer.Samples.Printing
{
    public partial class PageBreaksSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.Printing.PageBreaksSample Sample { get; private set; }

        private void buttonPrint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Run the sample.
            Sample.Print(workbookView, radioButtonRegion.IsChecked == true);
        }


        #region Sample Initialization Code
        public PageBreaksSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            Sample = new SharedSamples.Samples.Printing.PageBreaksSample();
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
