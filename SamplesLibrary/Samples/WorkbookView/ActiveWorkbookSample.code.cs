using System.Threading.Tasks;

namespace SamplesLibrary.Samples.WorkboookView
{
    public class ActiveWorkbookSample : ISpreadsheetGearWindowsSample
    {
        public void NewWorkbook(IWorkbookView workbookView)
        {
            // Create a new workbook.
            // NOTE: Use GetWorkbook(System.Globalization.CultureInfo.CurrentCulture)
            //       to use the current culture instead of the default US English culture.
            SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();

            // Associate the workbook with the WorkbookView control.
            workbookView.ActiveWorkbook = workbook;
        }

        public void LoadFromDisk(IWorkbookView workbookView, string filePath)
        {
            // NOTE: Use GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
            //       to use the current culture instead of the default US English culture.
            SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();

            // Open the workbook using the provided path.
            SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Open(filePath);

            // Associate the workbook with the WorkbookView control.
            workbookView.ActiveWorkbook = workbook;
        }

        public async Task<string> LoadFromUri_AspNetGenerated(IWorkbookView workbookView)
        {
            // Specify the URI that will return a workbook as the response.
            // NOTE: the below URL dynamically generates and returns a workbook in the response stream.
            // For samples on how to do this please visit:
            //     https://www.spreadsheetgear.com/Support/Samples/RazorPages/Category/Reporting
            string uri = "https://www.spreadsheetgear.com/Support/Samples/RazorPages/ExcelReportWithChart";

            await this.LoadFromURI(workbookView, uri);

            return uri;
        }

        public async Task<string> LoadFromUri_XSLX(IWorkbookView workbookView)
        {
            // Specify the URI that will return a workbook as the response.  ChartGallery.xlsx is an
            // Excel file stored on the SpreadsheetGear web server.
            string uri = "https://www.spreadsheetgear.com/Support/Samples/Files/ChartGallery.xlsx";

            await this.LoadFromURI(workbookView, uri);

            return uri;
        }

        /// <summary>
        /// Opens a System.IO.Stream from the provided URI to an Excel workbook file, which is opened
        /// by SpreadsheetGear using the IWorkbooks.OpenFromStream(...) method and displayed on the
        /// provided WorkbookView.
        /// </summary>
        public async Task LoadFromURI(IWorkbookView workbookView, string uriString)
        {
            // Create a System.Uri from the provided uriString.
            System.Uri uri = new System.Uri(uriString);

            // Create an HttpClient
            using (System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient())
            {
                // Request to contents of the provided Uri.
                System.Net.Http.HttpResponseMessage response = await httpClient.GetAsync(uri);

                // Only proceed to open workbook stream if the response was OK
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Open the requested contents as a stream.
                    using (System.IO.Stream stream = await response.Content.ReadAsStreamAsync())
                    {
                        // NOTE: Use GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
                        //       to use the current culture instead of the default US English culture.
                        SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();

                        // Open the workbook from the Stream object.
                        SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.OpenFromStream(stream);

                        // Associate the workbook with the WorkbookView control.
                        workbookView.ActiveWorkbook = workbook;
                    }
                }
                // Otherwise, display a new workbook with an error message.
                else
                {
                    SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
                    workbook.ActiveWorksheet.Cells["A1"].Value = $"Error loading workbook from URI '{uri}'";
                    workbookView.ActiveWorkbook = workbook;
                }
            }
        }
    }
}
