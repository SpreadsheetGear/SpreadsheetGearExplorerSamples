namespace WindowsFormsExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class WorksheetWindowInfoSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.WorksheetWindowInfoSample Sample { get; private set; }

        private void buttonFreezePanes_Click(object sender, System.EventArgs e)
        {
            Sample.FreezePanes(workbookView);
        }

        private void buttonGridlines_Click(object sender, System.EventArgs e)
        {
            Sample.ToggleGridlines(workbookView);
        }

        private void buttonHeadings_Click(object sender, System.EventArgs e)
        {
            Sample.ToggleHeadings(workbookView);
        }

        private void zoomTrackBar_ValueChanged(object sender, System.EventArgs e)
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
