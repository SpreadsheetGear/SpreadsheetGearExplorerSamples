namespace SharedSamples.Samples.Charting
{
    public class EmbeddedPictureInChartSample : SharedEngineSample
    {
        public override void PreLoadWorkbook()
        {
            // Get the full path to a workbook with some data for the chart.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\WorkbookWithChart.xlsx");

            // Open the workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook(workbookPath);
        }

        public override void RunSample()
        {
            // Create some local variables to the active worksheet, its window info, 
            // and cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IWorksheetWindowInfo windowInfo = worksheet.WindowInfo;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Get the full path to a PNG image.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Engine\SpreadsheetGearLogoAndText.png");

            // Load picture into byte array.
            byte[] pictureBytes = System.IO.File.ReadAllBytes(workbookPath);

            // Open the file as a System.Drawing.Image so that we can get its dimensions the proportion between the 
            // height and width.
            System.IO.MemoryStream ms = new System.IO.MemoryStream(pictureBytes);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            double imageWidth = image.Width;
            double imageHeight = image.Height;
            double imageProportion = imageHeight / imageWidth;

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
