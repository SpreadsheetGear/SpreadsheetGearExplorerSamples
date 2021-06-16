namespace WPFExplorer.Samples.WorkbookView.Styling
{
    /// <summary>
    /// Converter class used to replace default column header content.
    /// </summary>
    public class ColumnHeaderTextConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Return custom text based on the column index.
            int columnIndex = (int)value;
            switch (columnIndex)
            {
                case 1:
                    return "Q1";
                case 2:
                    return "Q2";
                case 3:
                    return "Q3";
                case 4:
                    return "Q4";
                case 5:
                    return "Curr Year";
                case 6:
                    return "Last Year";
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


    /// <summary>
    /// Custom control used to replace default row header content.
    /// </summary>
    public class CustomRowHeaderContent : System.Windows.Controls.ContentControl
    {
        public CustomRowHeaderContent()
        {
            DefaultStyleKey = typeof(CustomRowHeaderContent);
        }

        // RowIndex dependency property (for use from XAML).
        public static readonly System.Windows.DependencyProperty RowIndexProperty =
            System.Windows.DependencyProperty.Register("RowIndex",
            typeof(int),
            typeof(CustomRowHeaderContent),
            new System.Windows.PropertyMetadata(OnRowIndexPropertyChanged));

        // WorkbookView dependency property (for use from XAML).
        public static readonly System.Windows.DependencyProperty WorkbookViewProperty =
            System.Windows.DependencyProperty.Register("WorkbookView",
            typeof(SpreadsheetGear.Windows.Controls.WorkbookView),
            typeof(CustomRowHeaderContent),
            new System.Windows.PropertyMetadata(OnWorkbookViewPropertyChanged));

        // RowIndex property.
        public int RowIndex
        {
            get { return (int)GetValue(RowIndexProperty); }
            set { SetValue(RowIndexProperty, value); }
        }

        // WorkbookView property.
        public SpreadsheetGear.Windows.Controls.WorkbookView WorkbookView
        {
            get { return GetValue(WorkbookViewProperty) as SpreadsheetGear.Windows.Controls.WorkbookView; }
            set { SetValue(WorkbookViewProperty, value); }
        }

        // RowIndex property changed handler.
        private static void OnRowIndexPropertyChanged(
            System.Windows.DependencyObject d, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var rowHeaderContent = d as CustomRowHeaderContent;
            if (rowHeaderContent != null)
            {
                // Update the data state.
                rowHeaderContent.CheckDataState();
            }
        }

        // WorkbookView property changed handler.
        private static void OnWorkbookViewPropertyChanged(
            System.Windows.DependencyObject d, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var rowHeaderContent = d as CustomRowHeaderContent;
            if (rowHeaderContent != null)
            {
                var oldView = e.OldValue as SpreadsheetGear.Windows.Controls.WorkbookView;
                var newView = e.NewValue as SpreadsheetGear.Windows.Controls.WorkbookView;

                // If the workbook view has changed...
                if (oldView != newView)
                {
                    // Set up a Calculate event handler to update the data state.
                    if (newView != null)
                    {
                        newView.Calculate +=
                            new SpreadsheetGear.Windows.Controls.CalculateEventHandler(rowHeaderContent.WorkbookView_Calculate);
                    }

                    // Remove any previous Calculate event handler.
                    if (oldView != null)
                    {
                        newView.Calculate -=
                            new SpreadsheetGear.Windows.Controls.CalculateEventHandler(rowHeaderContent.WorkbookView_Calculate);
                    }
                }

                // Update the data state.
                rowHeaderContent.CheckDataState();
            }
        }

        // WorkbookView Calculate event handler.
        private void WorkbookView_Calculate(object sender,
            SpreadsheetGear.Windows.Controls.CalculateEventArgs e)
        {
            // Update the data state.
            CheckDataState();
        }

        private void CheckDataState()
        {
            // Ignore if we don't yet have a workbook view reference.
            if (WorkbookView == null)
                return;

            // NOTE: Must acquire a workbook set lock.
            WorkbookView.GetLock();
            try
            {
                // Get a reference to the advanced IValues interface for the worksheet.
                var values = WorkbookView.ActiveWorksheet as SpreadsheetGear.Advanced.Cells.IValues;

                // DataState defaults to none.
                string dataState = "None";

                // Get various values from the worksheet.
                var rowIndex = RowIndex;
                var store = values[rowIndex, 0];
                var curSales = values[rowIndex, 5];
                var lastSales = values[rowIndex, 6];

                // If we have valid sales entries...
                if (store != null && curSales != null && lastSales != null)
                {
                    // Determine if sales were positive or negative...
                    if (curSales.Number >= lastSales.Number)
                        dataState = "Positive";
                    else
                        dataState = "Negative";
                }

                // Transition the data state.
                System.Windows.VisualStateManager.GoToState(this, dataState, true);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                WorkbookView.ReleaseLock();
            }
        }
    }

    public partial class CustomHeadersSample : SampleUserControl
    {
        #region Sample Initialization Code
        public CustomHeadersSample()
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
                cells["A1"].Value = "Store 1";
                cells["G1"].Value = 150000;
                cells["A2"].Value = "Store 2";
                cells["G2"].Value = 120000;
                cells["A3"].Value = "Store 3";
                cells["G3"].Value = 175000;
                cells["A4"].Value = "Store 4";
                cells["G4"].Value = 190000;
                cells["A5"].Value = "Store 5";
                cells["G5"].Value = 90000;
                cells["A1:G1"].ColumnWidth = 10;
                cells["B1:G6"].NumberFormat = string.Format("$#{0}##0", workbookView.ActiveWorkbookSet.Culture.NumberFormat.NumberGroupSeparator);
                object[,] values = new object[5, 4] {
                    { 20000, 40000, 40000, 30000 },
                    { 40000, 50000, 40000, 60000 },
                    { 40000, 50000, 40000, 80000 },
                    { 30000, 40000, 40000, 60000 },
                    { 20000, 20000, 40000, 50000 }
                };
                cells["B1:E5"].Value = values;
                cells["F1"].Formula = "=sum(B1:E1)";
                cells["F1:F5"].FillDown();
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
