using System.Windows;
using System.Windows.Controls;

namespace WPFExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class WorkbookWindowInfoSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.WorkbookWindowInfoSample Sample { get; private set; }

        private void ButtonToggleScrollBars_Click(object sender, RoutedEventArgs e)
        {
            Sample.ToggleScrollBars(workbookView);
        }

        private void ButtonToggleSheetTabs_Click(object sender, RoutedEventArgs e)
        {
            Sample.ToggleSheetTabs(workbookView);
        }

        private void SliderTabRatio_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
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
            Sample = new SamplesLibrary.Samples.WorkboookView.DisplayOptions.WorkbookWindowInfoSample();
            DisposalManager.RegisterWorkbookViews(workbookView);

            workbookView.GetLock();
            try
            {
                var windowInfo = workbookView.ActiveWorkbookWindowInfo;
                sliderTabRatio.Minimum = 0;
                sliderTabRatio.Maximum = 1;
                sliderTabRatio.SmallChange = 0.01;
                sliderTabRatio.Value = windowInfo.TabRatio;
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
