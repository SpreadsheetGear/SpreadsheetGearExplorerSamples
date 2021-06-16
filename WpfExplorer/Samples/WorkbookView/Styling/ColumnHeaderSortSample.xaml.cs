namespace WPFExplorer.Samples.WorkbookView.Styling
{
    public partial class ColumnHeaderSortSample : SampleUserControl
    {
        private void ColumnHeader_MouseLeftButtonDown(
            object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get a reference to the custom column header elements.
            var element = sender as System.Windows.FrameworkElement;
            var sortIconsContainer = element.FindName("SortIconsContainer") as System.Windows.FrameworkElement;
            var sortIconAscending = element.FindName("SortIconAscending") as System.Windows.FrameworkElement;
            var sortIconDescending = element.FindName("SortIconDescending") as System.Windows.FrameworkElement;

            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to a range representing the portion of the worksheet which is in use.
                var sortRange = workbookView.ActiveWorksheet.UsedRange;

                // The custom column header binds the sort icon container Tag property to the column index.
                int columnIndex = (int)sortIconsContainer.Tag;

                // If the column index is valid...
                if (columnIndex >= 0 && columnIndex < sortRange.ColumnCount)
                {
                    // Assure that the sort icon container is displayed.
                    if (sortIconsContainer.Opacity == 0)
                        sortIconsContainer.Opacity = 1;

                    if (sortIconDescending.Opacity == 1)
                    {
                        // Toggle sort icon from descending to ascending.
                        sortIconAscending.Opacity = 1;
                        sortIconDescending.Opacity = 0;

                        // Sort ascending.
                        var sortKey = new SpreadsheetGear.SortKey(columnIndex,
                            SpreadsheetGear.SortOrder.Ascending,
                            SpreadsheetGear.SortDataOption.Normal);
                        sortRange.Sort(SpreadsheetGear.SortOrientation.Rows, false, sortKey);
                    }
                    else
                    {
                        // Toggle sort icon from ascending to descending.
                        sortIconAscending.Opacity = 0;
                        sortIconDescending.Opacity = 1;

                        // Sort descending.
                        var sortKey = new SpreadsheetGear.SortKey(columnIndex,
                            SpreadsheetGear.SortOrder.Descending,
                            SpreadsheetGear.SortDataOption.Normal);
                        sortRange.Sort(SpreadsheetGear.SortOrientation.Rows, false, sortKey);
                    }
                }
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        private void WorkbookView_CellBeginEdit(
            object sender, SpreadsheetGear.Windows.Controls.CellBeginEditEventArgs e)
        {
            // Cancel edit mode if the edit was triggered by double-clicking column header.
            e.Cancel =
                workbookView.RangeSelection.IsEntireColumns &&
                e.Reason == SpreadsheetGear.Windows.Controls.CellBeginEditReason.MouseEvent;
        }

        #region Sample Initialization Code
        public ColumnHeaderSortSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        public void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            workbookView.GetLock();
            try
            {
                var cells = workbookView.ActiveWorksheet.Cells;
                object[,] values = new object[44, 5] {
                    {"George", "Washington", "1789-1797","57 years, 67 days", "No political party"},
                    {"John","Adams", "1797-1801","61 years, 125 days", "Federalist"},
                    {"Thomas", "Jefferson", "1801-1809","57 years, 325 days", "Democratic-Republican"},
                    {"James", "Madison", "1809-1817", "57 years, 353 days","Democratic-Republican"},
                    {"James", "Monroe", "1817-1825","58 years, 310 days", "Democratic-Republican"},
                    {"John Quincy", "Adams", "1825-1829", "57 years, 236 days","Democratic-Republican"},
                    {"Andrew", "Jackson", "1829-1837", "61 years, 354 days","Democratic"},
                    {"Martin", "Van Buren", "1837-1841", "54 years, 89 days", "Democratic"},
                    {"William Henry", "Harrison", "1841-1841", "68 years, 23 days","Whig"},
                    {"John", "Tyler", "1841-1845", "51 years, 6 days","Whig"},
                    {"James K.", "Polk", "1845-1849", "49 years, 122 days","Democratic"},
                    {"Zachary", "Taylor", "1849-1850", "64 years, 100 days","Whig"},
                    {"Millard", "Fillmore", "1850-1853", "50 years, 183 days","Whig"},
                    {"Franklin", "Pierce", "1853-1857", "48 years, 101 days","Democratic"},
                    {"James", "Buchanan", "1857-1861", "65 years, 315 day","Democratic"},
                    {"Abraham", "Lincoln", "1861-1865", "52 years, 20 day","Republican"},
                    {"Andrew", "Johnson", "1865-1869", "56 years, 107 days","War Union"},
                    {"Ulysses S.", "Grant", "1869-1877", "46 years, 311 days","Republican"},
                    {"Rutherford B.", "Hayes", "1877-1881", "54 years, 151 days","Republican"},
                    {"James A.", "Garfield", "1881-1881", "49 years, 105 days","Republican"},
                    {"Chester Alan", "Arthur", "1881-1885", "51 years, 349 days","Republican"},
                    {"Grover", "Cleveland", "1885-1889", "55 years, 351 days","Democratic"},
                    {"Benjamin", "Harrison", "1889-1893", "55 years, 196 days","Republican"},
                    {"Grover", "Cleveland", "1893-1897", "55 years, 351 days","Democratic"},
                    {"William", "McKinley", "1897-1901", "54 years, 34 days","Republican"},
                    {"Theodore", "Roosevelt", "1901-1909", "42 years, 322 days","Republican"},
                    {"William Howard", "Taft", "1909-1913", "51 years, 170 days","Republican"},
                    {"Woodrow", "Wilson", "1913-1921", "56 years, 66 days","Democratic"},
                    {"Warren G.", "Harding", "1921-1923", "55 years, 122 days","Republican"},
                    {"Calvin", "Coolidge", "1923-1929", "51 years, 29 days","Republican"},
                    {"Herbert", "Hoover", "1929-1933", "54 years, 206 days","Republican"},
                    {"Franklin D.", "Roosevelt", "1933-1945", "51 years, 33 days","Democratic"},
                    {"Harry S.", "Truman", "1945-1953", "60 years, 339 days","Democratic"},
                    {"Dwight D.", "Eisenhower", "1953-1961", "62 years, 98 days","Republican"},
                    {"John F.", "Kennedy", "1961-1963", "43 years, 236 days","Democratic"},
                    {"Lyndon", "Johnson", "1963-1969", "55 years, 87 days","Democratic"},
                    {"Richard", "Nixon", "1969-1974", "56 years, 11 days","Republican"},
                    {"Gerald", "Ford", "1974-1977", "61 years, 26 days","Republican"},
                    {"Jimmy", "Carter", "1977-1981", "52 years, 111 days","Democratic"},
                    {"Ronald", "Reagan", "1981-1989", "69 years, 349 days","Republican"},
                    {"George", "Bush", "1989-1993", "64 years, 222 days", "Republican"},
                    {"Bill", "Clinton", "1993-2001", "46 years, 154 days","Democratic"},
                    {"George W.", "Bush", "2001-2009", "54 years, 198 days","Republican"},
                    {"Barack", "Obama", "2009-", "47 years, 169 days","Democratic"}
                };
                cells["A1:E44"].Value = values;
                cells["A1:C1"].ColumnWidth = 16;
                cells["D1:E1"].ColumnWidth = 20;
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }


    /// <summary>
    /// Converter class used to bind column header to custom text.
    /// </summary>
    public class ColumnHeaderSortConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Return custom text based on the column index.
            int columnIndex = (int)value;
            switch (columnIndex)
            {
                case 0:
                    return "First Name";
                case 1:
                    return "Last Name";
                case 2:
                    return "U.S. President";
                case 3:
                    return "Age at inauguration";
                case 4:
                    return "Political Party";
                default:
                    return "";
            }
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Not used.
            throw new System.NotImplementedException();
        }
    }
}
