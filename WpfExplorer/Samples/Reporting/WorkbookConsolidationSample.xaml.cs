using System.Windows.Controls;

namespace WPFExplorer.Samples.WorkbookView.Reporting
{
    public partial class WorkbookConsolidationSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Reporting.WorkbookConsolidationSample Sample { get; private set; }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView, false);
            string selectedRegion = (string)((RadioButton)e.Source).Tag;
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
