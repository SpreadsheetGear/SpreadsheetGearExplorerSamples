namespace WindowsFormsExplorer.Samples.DataGrid
{
    public partial class SpreadsheetToDataGridSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridSample Sample { get; private set; }

        private void ButtonRunSample_Click(object sender, System.EventArgs e)
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
