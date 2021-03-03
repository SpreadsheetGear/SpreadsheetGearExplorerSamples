using System.Collections.Generic;

namespace WPFExplorer.Samples.WorkbookView
{
    public partial class CultureInfoSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.CultureInfoSample Sample { get; private set; }

        private void button_runSample_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView_deDE, false);
            DisposalManager.ResetWorkbookView(workbookView_selectedCulture, false);
            Sample.RunSample(workbookView_deDE, workbookView_selectedCulture, (string)listBox_cultures.SelectedItem);
        }


        #region Sample Initialization Code
        public CultureInfoSample()
        {
            InitializeComponent();
            InitializeSample();
        }
        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.WorkboookView.CultureInfoSample();
            DisposalManager.RegisterWorkbookViews(workbookView_deDE, workbookView_selectedCulture);

            // Get all cultures and populate ListBox with them
            List<string> cultures = Sample.GetAllCultures();
            listBox_cultures.ItemsSource = cultures;
            listBox_cultures.SelectedIndex = 0;
        }
        #endregion
    }
}
