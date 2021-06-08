namespace WPFExplorer.Samples.WorkbookView.Styling
{
    public partial class ExcelThemeSample : SampleUserControl
    {
        public ExcelThemeSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);

            // See ExcelThemeSample.xaml for the markup used to style the WorkbookView.
        }
    }
}
