namespace WPFExplorer.Samples.Advanced
{
    public partial class ThreadingSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Advanced.ThreadingSample Sample { get; private set; }


        private void buttonAddThread_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.AddThread(workbookView);
        }

        private void buttonRemoveThread_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Sample.RemoveThread(workbookView);
            }
            catch (System.Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "SpreadsheetGear Explorer");
            }
        }

        #region Sample Initialization Code
        public ThreadingSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.Advanced.ThreadingSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
