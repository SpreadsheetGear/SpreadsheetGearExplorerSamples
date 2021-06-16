namespace WPFExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class WorksheetWindowInfoSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.WorksheetWindowInfoSample Sample { get; private set; }

        private void ButtonFreezePanes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.FreezePanes(workbookView);
        }

        private void ButtonToggleGridlines_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.ToggleGridlines(workbookView);
        }

        private void ButtonToggleHeadings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.ToggleHeadings(workbookView);
        }

        private void SliderZoom_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            int zoom = System.Convert.ToInt32(e.NewValue);
            labelZoom.Content = zoom + "%";
            Sample.Zoom(workbookView, zoom);
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
                var cell = workbookView.ActiveWorksheet.Cells["B3"];
                var windowInfo = workbookView.ActiveWorksheetWindowInfo;
                cell.Value = "SpreadsheetGear";
                cell.Interior.Color = SpreadsheetGear.Color.FromArgb(255, 30, 43, 74);
                cell.Font.Bold = true;
                cell.Font.Size = 18.0;
                cell.GetCharacters(0, 11).Font.Color =
                    SpreadsheetGear.Color.FromArgb(255, 255, 255, 255);
                cell.GetCharacters(11, 4).Font.Color =
                    SpreadsheetGear.Color.FromArgb(255, 233, 14, 14);
                cell.Columns.AutoFit();
                sliderZoom.Value = windowInfo.Zoom;
                sliderZoom.Minimum = 10;
                sliderZoom.Maximum = 400;
                sliderZoom.SmallChange = 1;
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
