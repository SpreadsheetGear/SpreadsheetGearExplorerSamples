// NOTE: a version of this sample is available to run and render on our website at:
// https://www.spreadsheetgear.com/Support/Samples/API/GroupingShapes
namespace SamplesLibrary.Engine.Samples.Shapes
{
    public class GroupingShapesSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with a set of ungrouped shapes.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\ShapesToGroup.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Get a reference to the active worksheet's shapes collection.
            SpreadsheetGear.Shapes.IShapes shapes = Workbook.ActiveWorksheet.Shapes;

            /*
             * GROUP 1
             * Group Blue Rectangles
             */
            // Get references to the 4 smaller blue rectangle shapes.
            SpreadsheetGear.Shapes.IShape rectTopLeft = shapes["Rectangle Top Left"];
            SpreadsheetGear.Shapes.IShape rectTopRight = shapes["Rectangle Top Right"];
            SpreadsheetGear.Shapes.IShape rectBottomLeft = shapes["Rectangle Bottom Left"];
            SpreadsheetGear.Shapes.IShape rectBottomRight = shapes["Rectangle Bottom Right"];

            // Create an IShape[] array and add all 4 rectangles to the array.
            var shapesArray = new SpreadsheetGear.Shapes.IShape[] { rectTopLeft, rectTopRight,
                rectBottomLeft, rectBottomRight };

            // Create an IShapeRange with the above array.
            SpreadsheetGear.Shapes.IShapeRange shapeRange = shapes.GetShapeRange(shapesArray);

            // Group the shape range, which will return an IShape that allows for further
            // modification to all shapes in the group (see operations performed on the "Final
            // Group" at the bottom of this sample).
            SpreadsheetGear.Shapes.IShape rectGroup = shapeRange.Group();

            // Rename this group for easier identification.
            rectGroup.Name = "GROUP 1 - Blue Rectangle Group";

            /*
             * GROUP 2
             * Group Red Arrows
             */
            // Similar to the blue rectangles, get a reference to the desired shapes...
            SpreadsheetGear.Shapes.IShape arrowRight = shapes["Arrow Right"];
            SpreadsheetGear.Shapes.IShape arrowDown = shapes["Arrow Down"];
            SpreadsheetGear.Shapes.IShape arrowLeft = shapes["Arrow Left"];
            SpreadsheetGear.Shapes.IShape arrowUp = shapes["Arrow Up"];
            // ...create an IShapeRange from an array of the arrow shapes...
            shapesArray = new SpreadsheetGear.Shapes.IShape[] { arrowRight, arrowDown,
                arrowLeft, arrowUp };
            shapeRange = shapes.GetShapeRange(shapesArray);
            // ...group them...
            SpreadsheetGear.Shapes.IShape arrowGroup = shapeRange.Group();
            // ...and rename the group for easier identification.
            arrowGroup.Name = "GROUP 2 - Red Arrow Group";

            /*
             * GROUP 3
             * Create a "Group of Groups" by grouping the Blue Rectangle Group and the Red Arrow 
             * Group.
             */
            shapesArray = new SpreadsheetGear.Shapes.IShape[] { rectGroup, arrowGroup };
            shapeRange = shapes.GetShapeRange(shapesArray);
            SpreadsheetGear.Shapes.IShape rectArrowGroup = shapeRange.Group();
            rectArrowGroup.Name = "GROUP 3 - Blue Rectangle Group / Red Arrow Group";

            /*
             * GROUP 4
             * Further nest groups by grouping the large gray "Rectangle Background" with 
             * the Blue Rectangle / Red Arrow Group" (so a Group within a Group within a Group).
             */
            SpreadsheetGear.Shapes.IShape rectBackground = shapes["Rectangle Background"];
            shapesArray = new SpreadsheetGear.Shapes.IShape[] { rectBackground, rectArrowGroup };
            shapeRange = shapes.GetShapeRange(shapesArray);
            SpreadsheetGear.Shapes.IShape finalGroup = shapeRange.Group();
            finalGroup.Name = "GROUP 4 - Final Group";

            /*
             * Perform various operation to the "Final Group".
             */

            // Move the "Final Group" 1 inch (72 Points) down and to the right.
            finalGroup.IncrementLeft(72);
            finalGroup.IncrementTop(72);

            // Scale up the size of the group by 150%, scaling from the middle of the group.
            finalGroup.ScaleHeight(1.5, true, SpreadsheetGear.Shapes.ScaleFrom.Middle);
            finalGroup.ScaleWidth(1.5, true, SpreadsheetGear.Shapes.ScaleFrom.Middle);
        }
    }
}
