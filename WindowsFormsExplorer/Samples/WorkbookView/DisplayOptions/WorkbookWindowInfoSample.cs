namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class WorkbookWindowInfoSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.WorkbookWindowInfoSample Sample { get; private set; }

        private void ButtonToggleScrollBars_Click(object sender, System.EventArgs e)
        {
            Sample.ToggleScrollBars(workbookView);
        }

        private void ButtonToggleSheetTabs_Click(object sender, System.EventArgs e)
        {
            Sample.ToggleSheetTabs(workbookView);
        }

        private void TabRatioTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            int tabRatioPercent = tabRatioTrackBar.Value;
            double tabRatio = tabRatioPercent / 100.0;
            labelTabRatio.Text = $"Tab Ratio: {tabRatioPercent}%";
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
                tabRatioTrackBar.Minimum = 0;
                tabRatioTrackBar.Maximum = 100;
                tabRatioTrackBar.SmallChange = 1;
                tabRatioTrackBar.Value = (int)(windowInfo.TabRatio * 100);
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
