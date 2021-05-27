namespace WindowsFormsExplorer.Samples.DataGrid
{
    public partial class SpreadsheetToDataGridSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridSample Sample { get; private set; }

        private void buttonRunSample_Click(object sender, System.EventArgs e)
        {
            // Generate a DataTable from the sample.
            System.Data.DataTable dataTable = Sample.GenerateDataTable();

            // Bind a DataGridView to the DataTable.
            dataGridView.DataSource = dataTable;
        }


        #region Sample Initialization Code
        public SpreadsheetToDataGridSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridSample();
        }
        #endregion
    }
}
