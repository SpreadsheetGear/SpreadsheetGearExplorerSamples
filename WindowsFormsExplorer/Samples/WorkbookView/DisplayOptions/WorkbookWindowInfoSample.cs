namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class WorkbookWindowInfoSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.WorkbookWindowInfoSample Sample { get; private set; }

        private void button_toggleScrollBars_Click(object sender, System.EventArgs e)
        {
            Sample.ToggleScrollBars(workbookView);
        }

        private void button_toggleSheetTabs_Click(object sender, System.EventArgs e)
        {
            Sample.ToggleSheetTabs(workbookView);
        }

        private void tabRatioTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            int tabRatioPercent = tabRatioTrackBar.Value;
            double tabRatio = tabRatioPercent / 100.0;
            label_tabRatio.Text = $"Tab Ratio: {tabRatioPercent}%";
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
