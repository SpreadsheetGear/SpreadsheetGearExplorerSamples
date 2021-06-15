namespace WindowsFormsExplorer.Samples.DataGrid
{
    public partial class SpreadsheetToDataGridFormattedSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridFormattedSample Sample { get; private set; }

        private void ButtonRunSample_Click(object sender, System.EventArgs e)
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
