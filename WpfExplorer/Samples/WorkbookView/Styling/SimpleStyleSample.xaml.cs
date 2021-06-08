namespace WPFExplorer.Samples.WorkbookView.Styling
{
    public partial class SimpleStyleSample : SampleUserControl
    {
        public SimpleStyleSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);

            // See SimpleStyleSample.xaml for the markup used to style the WorkbookView.
        }
    }
}
