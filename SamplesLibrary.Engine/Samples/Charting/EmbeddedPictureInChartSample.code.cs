// NOTE: a version of this sample is available to run and render on our website at:
// https://www.spreadsheetgear.com/Support/Samples/API/ChartingEmbeddedPicture
namespace SamplesLibrary.Engine.Samples.Charting
{
    public class EmbeddedPictureInChartSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Get the full path to a workbook with some data for the chart.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\WorkbookWithChart.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public void RunSample()
        {
            // Create a local variable to the active worksheet.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;

            // Get the full path to a PNG image.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\SpreadsheetGearLogoAndText.png");

            // Load picture into byte array.
            byte[] pictureBytes = System.IO.File.ReadAllBytes(workbookPath);

            // Open the image so that we can get its dimensions and determine the proportion
            // between the height and width.
            double imageProportion;
            // NOTE: we are using a 3rd party imaging library (SkiaSharp) here to open a PNG
            // and get its measurements.  If you are on Windows, you could instead use the
            // System.Drawing.Image class to get this information.  We do not do so here
            // so that these Engine samples can be used in non-Windows environments such as
            // Linux and MacOS.
            using (var image = SkiaSharp.SKImage.FromEncodedData(pictureBytes))
            {
                double imageWidth = image.Width;
                double imageHeight = image.Height;
                imageProportion = imageHeight / imageWidth;
            }

            // Get the Chart IShape and IChart objects.
            SpreadsheetGear.Shapes.IShape chartShape = worksheet.Shapes["Chart 1"];
            SpreadsheetGear.Charts.IChart chart = chartShape.Chart;

            // Calculate size and position of picture so that it fills 75% of the  chart's
            // total width, and is centered at the top of the chart.
            double width = chartShape.Width * 0.75;
            double height = width * imageProportion;
            double left = (chartShape.Width - width) / 2;
            double top = 5;

            // Embed the picture from the pictureBytes (would also accept path to the file).
            chart.Shapes.AddPicture(pictureBytes, left, top, width, height);
        }
    }
}
