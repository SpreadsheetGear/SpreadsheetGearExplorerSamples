namespace WPFExplorer.Samples.WorkbookView.Events
{
    public partial class ShapeSelectionChangedSample : SGUserControl
    {
        public SharedSamples.Samples.WorkboookView.Events.ShapeSelectionChangedSample Sample { get; private set; }

        private void workbookView_ShapeSelectionChanged(
            object sender, SpreadsheetGear.Windows.Controls.ShapeSelectionChangedEventArgs e)
        {
            Sample.ShapeSelectionChanged(workbookView, e.ShapeSelection);
        }


        #region Sample Initialization Code
        public ShapeSelectionChangedSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        public void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            Sample = new SharedSamples.Samples.WorkboookView.Events.ShapeSelectionChangedSample();
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
