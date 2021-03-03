using System.Windows;
using System.Windows.Input;

namespace WPFExplorer.Samples.WorkbookView
{
    public partial class LocationToRangeSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.LocationToRangeSample Sample { get; private set; }

        private void workbookView_PreviewMouseDown(object sender, MouseButtonEventArgs e)
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
            Sample = new SharedSamples.Samples.WorkboookView.LocationToRangeSample();
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
