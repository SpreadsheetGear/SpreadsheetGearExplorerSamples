// NOTE: a version of this sample is available to run and render on our website at:
// https://www.spreadsheetgear.com/Support/Samples/API/ShapesCroppedPicture
namespace SamplesLibrary.Engine.Samples.Shapes
{
    public class CroppedPictureSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create local variable to the active worksheet.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;

            // This picture consists of the SpreadsheetGear logo and the text "SpreadsheetGear" to 
            // the right of the logo.
            string imagePath = Helpers.GetFullOutputFolderPath(@"Files\Engine\SG-Logo-Text.png");

            // Add the picture to the worksheet, specifying the size (in this case 7" x 1" which is
            // the original dimensions of the picture).  Note all units are measured in Points, where
            // 1 inch == 72 Points.
            SpreadsheetGear.Shapes.IShape shape = worksheet.Shapes.AddPicture(imagePath, 10, 10,
                7 * 72, 1 * 72);

            // Select the picture.
            shape.Select(true);

            // Get the IPictureFormat object from the IShape, which has various picture-related APIs, 
            // including cropping APIs.
            SpreadsheetGear.Shapes.IPictureFormat picture = shape.PictureFormat;

            // We pre-measured the width of just the logo which has a width of 1.35 inches starting 
            // from the left edge.  The full picture is 7 inches long, so we should crop from the 
            // right edge of the picture a distance of 7" - 1.35".  Again, this API is measured in 
            // Points, so we also multiply by 72.
            picture.CropRight = (7.0 - 1.35) * 72;

            // Additional Notes on Cropping:
            //   - IPictureFormat also has the properties CropLeft, CropTop and CropBottom.
            //   - Specify crop measurements based on the dimensions of the *original picture size*
            //     and not the dimensions that you specified for the shape (IShape.Width / Height).
            //   - Negative crop values can be used to extend the shape's boundary beyond the picture.

            // Add a second uncropped copy of this picture below the cropped picture for comparison
            // purposes.
            worksheet.Shapes.AddPicture(imagePath, 10, 100);
        }
    }
}
