using System.Windows;
using System.Windows.Input;

namespace WPFExplorer.Samples.WorkbookView
{
    public partial class LocationToRangeSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.LocationToRangeSample Sample { get; private set; }

        private void WorkbookView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the clicked mouse coordinates relative to the WorkbookView control.
            Point position = e.GetPosition(workbookView);

            // Run the sample.
            Sample.ColorizeClickedCell(workbookView, position.X, position.Y);
        }

        #region Sample Initialization Code
        public LocationToRangeSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.LocationToRangeSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            workbookView.GetLock();
            try
            {
                workbookView.ActiveCell.Value = "Click on any cell to fill it with a color.";
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
