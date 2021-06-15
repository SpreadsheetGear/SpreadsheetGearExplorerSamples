namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class WorksheetWindowInfoSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.WorksheetWindowInfoSample Sample { get; private set; }

        private void ButtonFreezePanes_Click(object sender, System.EventArgs e)
        {
            Sample.FreezePanes(workbookView);
        }

        private void ButtonGridlines_Click(object sender, System.EventArgs e)
        {
            Sample.ToggleGridlines(workbookView);
        }

        private void ButtonHeadings_Click(object sender, System.EventArgs e)
        {
            Sample.ToggleHeadings(workbookView);
        }

        private void ZoomTrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            Sample.Zoom(workbookView, zoomTrackBar.Value);
        }

        #region Sample Initialization Code
        public WorksheetWindowInfoSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.DisplayOptions.WorksheetWindowInfoSample();
            DisposalManager.RegisterWorkbookViews(workbookView);

            workbookView.GetLock();
            try
            {
                SpreadsheetGear.IRange cell = workbookView.ActiveWorksheet.Cells["B3"];
                SpreadsheetGear.IWorksheetWindowInfo windowInfo = workbookView.ActiveWorksheetWindowInfo;
                cell.Value = "SpreadsheetGear";
                cell.Interior.Color = SpreadsheetGear.Color.FromArgb(255, 30, 43, 74);
                cell.Font.Bold = true;
                cell.Font.Size = 18.0;
                cell.GetCharacters(0, 11).Font.Color =
                    SpreadsheetGear.Color.FromArgb(255, 255, 255, 255);
                cell.GetCharacters(11, 4).Font.Color =
                    SpreadsheetGear.Color.FromArgb(255, 233, 14, 14);
                cell.Columns.AutoFit();
                zoomTrackBar.Minimum = 10;
                zoomTrackBar.Maximum = 400;
                zoomTrackBar.SmallChange = 15;
                zoomTrackBar.Value = windowInfo.Zoom;
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
