namespace SamplesLibrary.Samples.WorkboookView
{
    public class DesignerAndExplorerDialogsSample : ISpreadsheetGearWindowsSample
    {
        public  void ShowWorkbookDesigner(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the active workbook set.
                SpreadsheetGear.IWorkbookSet workbookSet = workbookView.ActiveWorkbookSet;

                // Create the Workbook Designer for the active workbook set.
                SpreadsheetGear.Windows.Forms.WorkbookDesigner designer =
                    new SpreadsheetGear.Windows.Forms.WorkbookDesigner(workbookSet);

                // Display the Workbook Designer to the user.  GetOwnerWindow() retrieves the parent
                // window of the WorkbookView control, which allows the dialog to stay on top even
                // when a user clicks back onto the WorkbookView / parent window.
                designer.Show(workbookView.GetOwnerWindow());
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void ShowWorkbookExplorer(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the active workbook set.
                SpreadsheetGear.IWorkbookSet workbookSet = workbookView.ActiveWorkbookSet;

                // Create the Workbook Explorer for the active workbook set.
                SpreadsheetGear.Windows.Forms.WorkbookExplorer explorer =
                    new SpreadsheetGear.Windows.Forms.WorkbookExplorer(workbookSet);

                // Display the Workbook Explorer to the user.  GetOwnerWindow() retrieves the parent
                // window of the WorkbookView control, which allows the dialog to stay on top even
                // when a user clicks back onto the WorkbookView / parent window.
                explorer.Show(workbookView.GetOwnerWindow());
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void ShowRangeExplorer(IWorkbookView workbookView, 
            SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags categoryFlags)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Select a range of cells.
                workbookView.ActiveWorksheet.Cells["B2:D3"].Select();

                // Get the active workbook set.
                SpreadsheetGear.IWorkbookSet workbookSet = workbookView.ActiveWorkbookSet;

                // Create the Range Explorer which operates on the current range selection. You can 
                // limit which categories are displayed in the RangeExplorer by passing in only the 
                // desired RangeExplorerCategoryFlags, or show all with the "All" flag.
                SpreadsheetGear.Windows.Forms.RangeExplorer explorer =
                    new SpreadsheetGear.Windows.Forms.RangeExplorer(workbookSet, categoryFlags);

                // Display the Range Explorer to the user.  GetOwnerWindow() retrieves the parent
                // window of the WorkbookView control, which allows the dialog to stay on top even
                // when a user clicks back onto the WorkbookView / parent window.
                explorer.Show(workbookView.GetOwnerWindow());
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void ShowChartExplorer(IWorkbookView workbookView, 
            SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags categoryFlags)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the worksheet's shapes collection.
                SpreadsheetGear.IWorksheet worksheet = workbookView.ActiveWorksheet;
                SpreadsheetGear.Shapes.IShapes shapes = worksheet.Shapes;

                // Delete any existing shapes.
                while (shapes.Count != 0)
                    shapes[0].Delete();

                // Load some sample data.
                SpreadsheetGear.IRange dataRange = worksheet.Cells["A101:C105"];
                dataRange.Formula = "=INT(RAND() * 10 + 5)";

                // Add a chart.
                SpreadsheetGear.Shapes.IShape shape = shapes.AddChart(10, 10, 320, 150);
                SpreadsheetGear.Charts.IChart chart = shape.Chart;

                // Set the chart's source data range, plotting series in columns.
                chart.SetSourceData(dataRange, SpreadsheetGear.Charts.RowCol.Columns);

                // Set the chart type.
                chart.ChartType = SpreadsheetGear.Charts.ChartType.ColumnClustered;

                // Select the chart shape.
                shape.Select(true);

                // Get the active workbook set.
                SpreadsheetGear.IWorkbookSet workbookSet = workbookView.ActiveWorkbookSet;

                // Create the Chart Explorer which operates on the current chart selection.  You can 
                // limit which categories are displayed in the ChartExplorer by passing in only the 
                // desired ChartExplorerCategoryFlags, or show all with the "All" flag.
                SpreadsheetGear.Windows.Forms.ChartExplorer explorer =
                    new SpreadsheetGear.Windows.Forms.ChartExplorer(workbookSet, categoryFlags);

                // Display the Chart Explorer to the user.  GetOwnerWindow() retrieves the parent
                // window of the WorkbookView control, which allows the dialog to stay on top even
                // when a user clicks back onto the WorkbookView / parent window.
                explorer.Show(workbookView.GetOwnerWindow());
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public void ShowShapeExplorer(IWorkbookView workbookView, 
            SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags categoryFlags)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get a reference to the worksheet's shapes collection.
                SpreadsheetGear.Shapes.IShapes shapes = workbookView.ActiveWorksheet.Shapes;

                // Delete any existing shapes.
                while (shapes.Count != 0)
                    shapes[0].Delete();

                // Add a trapezoid.
                SpreadsheetGear.Shapes.IShape shape = shapes.AddShape(
                    SpreadsheetGear.Shapes.AutoShapeType.Trapezoid, 24, 24, 96, 96);

                // Select the trapezoid.
                shape.Select(true);

                // Add a Button
                shapes.AddFormControl(SpreadsheetGear.Shapes.FormControlType.ButtonControl, 150, 24, 100, 24);

                // Add a TextBox
                shapes.AddTextBox(300, 24, 150, 75);

                // Get the active workbook set.
                SpreadsheetGear.IWorkbookSet workbookSet = workbookView.ActiveWorkbookSet;

                // Create the Shape Explorer which operates on the current shape selection. You can limit 
                // which categories are displayed in the ShapeExplorer by passing in only the desired 
                // ShapeExplorerCategoryFlags, or show all with the "All" flag.
                SpreadsheetGear.Windows.Forms.ShapeExplorer explorer =
                    new SpreadsheetGear.Windows.Forms.ShapeExplorer(workbookSet, categoryFlags);

                // Display the Shape Explorer to the user.  GetOwnerWindow() retrieves the parent
                // window of the WorkbookView control, which allows the dialog to stay on top even
                // when a user clicks back onto the WorkbookView / parent window.
                explorer.Show(workbookView.GetOwnerWindow());
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }
    }
}
