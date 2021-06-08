﻿namespace WPFExplorer.Samples.DataGrid
{
    public partial class SpreadsheetToDataGridFormattedSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
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

        #region Sample Initialization Code
        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.DataGrid.SpreadsheetToDataGridFormattedSample();
        }
        #endregion
    }
}
