using System.Collections.Generic;

namespace SamplesLibrary.Samples.Charting
{
    public class ChartGallerySample : ISpreadsheetGearWindowsSample
    {
        public SpreadsheetGear.IWorkbook ChartWorkbook { get; set; }

        public void InitializeSample()
        {
            // Get the full path to a workbook containing all the charts that will be used by the Chart Gallery.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\ChartGallery.xlsx");

            // Open the workbook.
            ChartWorkbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }


        public System.Drawing.Bitmap RenderBitmapGDI(string category, string type)
        {
            // Get the worksheet based on the selected category name.
            SpreadsheetGear.IWorksheet worksheet = ChartWorkbook.Worksheets[category];

            // Get the shape based on the selected type.
            SpreadsheetGear.Shapes.IShape shape = worksheet.Shapes[type];

            // Create the SpreadsheetGear Image class.
            SpreadsheetGear.Drawing.Image image = new SpreadsheetGear.Drawing.Image(shape);

            // Generate a new Bitmap representing the shape and return.
            System.Drawing.Bitmap bitmap = image.GetBitmap();
            return bitmap;
        }


        public System.IO.MemoryStream RenderBitmapStreamGDI(string category, string type)
        {
            // Generate a new Bitmap representing the shape.
            using (System.Drawing.Bitmap bitmap = RenderBitmapGDI(category, type))
            {
                // Save Bitmap to PNG stream and return;
                var stream = new System.IO.MemoryStream();
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Seek(0, System.IO.SeekOrigin.Begin);
                return stream;
            }
        }


        public IEnumerable<string> GetChartCategories()
        {
            // Dynamically build the category list using worksheet names.
            foreach (SpreadsheetGear.IWorksheet worksheet in ChartWorkbook.Worksheets)
                yield return worksheet.Name;
        }


        public IEnumerable<string> GetChartTypes(string category)
        {
            // If we have a valid category...
            if (!string.IsNullOrEmpty(category))
            {
                // Get the worksheet based on the selected category name.
                SpreadsheetGear.IWorksheet worksheet = ChartWorkbook.Worksheets[category];

                // Dynamically build the type list using shape names.
                foreach (SpreadsheetGear.Shapes.IShape shape in worksheet.Shapes)
                    yield return shape.Name;
            }
        }
    }
}
