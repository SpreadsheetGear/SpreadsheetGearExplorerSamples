namespace SamplesLibrary.Samples.WorkboookView.Events
{
    public class ShapeSelectionChangedSample : ISpreadsheetGearWindowsSample
    {
        /// <param name="workbookView">The WorkbookView to operate on.</param>
        /// <param name="shapeRange">Represents a collection of IShape objects, in this case the new shape 
        /// selection.</param>
        public void ShapeSelectionChanged(IWorkbookView workbookView, SpreadsheetGear.Shapes.IShapeRange shapeRange)
        {
            // NOTE: GetLock() / ReleaseLock() not required because a lock is 
            // acquired before this method is invoked.

            // If at least one shape is selected...
            if (shapeRange != null)
                // display information about the first selected shape.
                workbookView.ActiveWorksheet.Cells["B1"].Formula = shapeRange[0].Name;
            else
                // display no selection.
                workbookView.ActiveWorksheet.Cells["B1"].Formula = "No Selection";
        }

        public void InitializeSample(IWorkbookView workbookView)
        {
            // Get the full path to a workbook.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\ShapeSelectionChanged.xlsx");

            // Open the workbook using the current culture.
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath,
                System.Globalization.CultureInfo.CurrentCulture);

            // Associate workbook with the WorkbookView control
            workbookView.ActiveWorkbook = workbook;
        }
    }
}
