namespace SamplesLibrary.Samples.Shapes
{
    public class AutoShapesSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;

            // Get a reference to the worksheet's shapes collection.
            SpreadsheetGear.Shapes.IShapes shapes = worksheet.Shapes;

            // Add a variety of auto shapes.
            for (int iRow = 0; iRow < 12; iRow += 3)
            {
                for (int iCol = 0; iCol < 7; iCol++)
                {
                    // Calculate the left, top, width and height of the shape by 
                    // converting row and column coordinates to points.  Use fractional 
                    // values to get coordinates in between row and column boundaries.
                    double left = windowInfo.ColumnToPoints(iCol + 0.1);
                    double top = windowInfo.RowToPoints(iRow + 0.2);
                    double right = windowInfo.ColumnToPoints(iCol + 0.9);
                    double bottom = windowInfo.RowToPoints(iRow + 2.8);
                    double width = right - left;
                    double height = bottom - top;

                    // Get the next sample auto shape type.
                    SpreadsheetGear.Shapes.AutoShapeType autoShapeType =
                        GetAutoShapeType(shapes.Count);

                    // Add the shape using the calculated bounds.
                    SpreadsheetGear.Shapes.IShape shape =
                        shapes.AddShape(autoShapeType, left, top, width, height);

                    // Set fill color with increased transparency for each shape.
                    SpreadsheetGear.Shapes.IFillFormat fillFormat = shape.Fill;
                    fillFormat.ForeColor.RGB = SpreadsheetGear.Colors.DarkSlateBlue;
                    fillFormat.Transparency = (shapes.Count - 1.0) * 0.03;

                    // Set line color.
                    SpreadsheetGear.Shapes.ILineFormat lineFormat = shape.Line;
                    lineFormat.ForeColor.RGB = SpreadsheetGear.Colors.Maroon;

                    // Set line to dash line style.
                    lineFormat.DashStyle = SpreadsheetGear.Shapes.LineDashStyle.Dash;
                }
            }


            
        }

        /*
             * SpreadsheetGear supports many of Excel's auto shape types
             * in the SpreadsheetGear.Shapes.IShapes API (more than 100 types).
             * 
             * The WorkbookView control currently supports and renders a subset of
             * these auto shape types including the ones listed below and used in
             * this sample.  See the Shape Explorer's AutoShape category for a
             * complete list of auto shapes supported in the WorkbookView control.
             */
        private SpreadsheetGear.Shapes.AutoShapeType GetAutoShapeType(int index)
        {
            switch (index)
            {
                case 0:
                default:
                    return SpreadsheetGear.Shapes.AutoShapeType.Rectangle;
                case 1:
                    return SpreadsheetGear.Shapes.AutoShapeType.Parallelogram;
                case 2:
                    return SpreadsheetGear.Shapes.AutoShapeType.Trapezoid;
                case 3:
                    return SpreadsheetGear.Shapes.AutoShapeType.Diamond;
                case 4:
                    return SpreadsheetGear.Shapes.AutoShapeType.Oval;
                case 5:
                    return SpreadsheetGear.Shapes.AutoShapeType.Cross;
                case 6:
                    return SpreadsheetGear.Shapes.AutoShapeType.IsoscelesTriangle;
                case 7:
                    return SpreadsheetGear.Shapes.AutoShapeType.RightTriangle;
                case 8:
                    return SpreadsheetGear.Shapes.AutoShapeType.Octagon;
                case 9:
                    return SpreadsheetGear.Shapes.AutoShapeType.Hexagon;
                case 10:
                    return SpreadsheetGear.Shapes.AutoShapeType.RegularPentagon;
                case 11:
                    return SpreadsheetGear.Shapes.AutoShapeType.FlowchartManualInput;
                case 12:
                    return SpreadsheetGear.Shapes.AutoShapeType.FlowchartOffpageConnector;
                case 13:
                    return SpreadsheetGear.Shapes.AutoShapeType.FlowchartMerge;
                case 14:
                    return SpreadsheetGear.Shapes.AutoShapeType.FlowchartCollate;
                case 15:
                    return SpreadsheetGear.Shapes.AutoShapeType.FlowchartSort;
                case 16:
                    return SpreadsheetGear.Shapes.AutoShapeType.RightArrow;
                case 17:
                    return SpreadsheetGear.Shapes.AutoShapeType.LeftArrow;
                case 18:
                    return SpreadsheetGear.Shapes.AutoShapeType.UpArrow;
                case 19:
                    return SpreadsheetGear.Shapes.AutoShapeType.DownArrow;
                case 20:
                    return SpreadsheetGear.Shapes.AutoShapeType.LeftRightArrow;
                case 21:
                    return SpreadsheetGear.Shapes.AutoShapeType.UpDownArrow;
                case 22:
                    return SpreadsheetGear.Shapes.AutoShapeType.RightArrowCallout;
                case 23:
                    return SpreadsheetGear.Shapes.AutoShapeType.LeftArrowCallout;
                case 24:
                    return SpreadsheetGear.Shapes.AutoShapeType.UpArrowCallout;
                case 25:
                    return SpreadsheetGear.Shapes.AutoShapeType.DownArrowCallout;
                case 26:
                    return SpreadsheetGear.Shapes.AutoShapeType.LeftRightArrowCallout;
                case 27:
                    return SpreadsheetGear.Shapes.AutoShapeType.UpDownArrowCallout;
            }
        }
    }
}
