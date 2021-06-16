namespace WPFExplorer.Samples.Advanced
{
    public partial class ThreadingSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.Advanced.ThreadingSample Sample { get; private set; }

        private void ButtonAddThread_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.AddThread(workbookView);
        }

        private void ButtonRemoveThread_Click(object sender, System.Windows.RoutedEventArgs e)
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
