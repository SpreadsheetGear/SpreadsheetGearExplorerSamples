namespace WPFExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class WorksheetWindowInfoSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.DisplayOptions.WorksheetWindowInfoSample Sample { get; private set; }

        private void buttonFreezePanes_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.FreezePanes(workbookView);
        }

        private void buttonToggleGridlines_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.ToggleGridlines(workbookView);
        }

        private void buttonToggleHeadings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.ToggleHeadings(workbookView);
        }

        private void sliderZoom_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
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
            Sample = new SharedSamples.Samples.WorkboookView.DisplayOptions.WorksheetWindowInfoSample();
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
