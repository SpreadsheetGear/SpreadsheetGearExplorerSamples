namespace WPFExplorer.Samples.DataGrid
{
    public partial class SpreadsheetToDataGridFormattedSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridFormattedSample Sample { get; private set; }


        private void buttonRunSample_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Generate a DataTable from the sample.
            System.Data.DataTable dataTable = Sample.GenerateDataTable();

            // Bind a DataGrid to the DataTable.
            dataGrid.ItemsSource = new System.Data.DataView(dataTable);
        }

        public SpreadsheetToDataGridFormattedSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridFormattedSample();
        }
    }
}
