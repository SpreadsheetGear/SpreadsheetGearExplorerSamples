using System.Windows;
using System.Windows.Controls;

namespace WPFExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class WorkbookWindowInfoSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.DisplayOptions.WorkbookWindowInfoSample Sample { get; private set; }

        private void button_toggleScrollBars_Click(object sender, RoutedEventArgs e)
        {
            Sample.ToggleScrollBars(workbookView);
        }

        private void button_toggleSheetTabs_Click(object sender, RoutedEventArgs e)
        {
            Sample.ToggleSheetTabs(workbookView);
        }

        private void slider_tabRatio_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            double tabRatio = e.NewValue;
            tabRatioLabel.Content = $"{tabRatio:0.00}";
            Sample.SetTabRatio(workbookView, tabRatio);
        }

        #region Sample Initialization Code
        public WorkbookWindowInfoSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.WorkboookView.DisplayOptions.WorkbookWindowInfoSample();
            // DisposalManager.RegisterWorkbookViews(workbookView);

            workbookView.GetLock();
            try
            {
                var windowInfo = workbookView.ActiveWorkbookWindowInfo;
                slider_tabRatio.Minimum = 0;
                slider_tabRatio.Maximum = 1;
                slider_tabRatio.SmallChange = 0.01;
                slider_tabRatio.Value = windowInfo.TabRatio;
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
