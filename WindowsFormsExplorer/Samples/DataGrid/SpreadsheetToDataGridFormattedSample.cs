namespace WindowsFormsExplorer.Samples.DataGrid
{
    public partial class SpreadsheetToDataGridFormattedSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridFormattedSample Sample { get; private set; }

        private void buttonRunSample_Click(object sender, System.EventArgs e)
        {
            try
            {
                // Generate a DataTable from the sample.
                System.Data.DataTable dataTable = Sample.GenerateDataTable();

                // Bind a DataGrid to the DataTable.
                dataGridView.DataSource = dataTable;
            }
            catch (System.Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message, "SpreadsheetGear Explorer", 
                    System.Windows.Forms.MessageBoxButtons.OK);
            }
        }


        #region Sample Initialization Code
        public SpreadsheetToDataGridFormattedSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridFormattedSample();
        }
        #endregion
    }
}
