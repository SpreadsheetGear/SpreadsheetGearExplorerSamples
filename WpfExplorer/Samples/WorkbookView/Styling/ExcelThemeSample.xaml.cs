namespace WPFExplorer.Samples.WorkbookView.Styling
{
    public partial class ExcelThemeSample : SampleUserControl
    {
        public ExcelThemeSample()
        {
            InitializeComponent();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
    }
}
