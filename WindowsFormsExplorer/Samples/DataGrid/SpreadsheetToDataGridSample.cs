namespace WindowsFormsExplorer.Samples.DataGrid
{
    public partial class SpreadsheetToDataGridSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.DataGrid.SpreadsheetToDataGridSample Sample { get; private set; }

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
            Sample = new SharedSamples.Samples.DataGrid.SpreadsheetToDataGridSample();
        }
        #endregion
    }
}
