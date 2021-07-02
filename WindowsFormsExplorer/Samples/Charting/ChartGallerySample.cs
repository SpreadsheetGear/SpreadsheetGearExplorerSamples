using System.Collections.Generic;

namespace WindowsFormsExplorer.Samples.Charting
{
    public partial class ChartGallerySample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.Charting.ChartGallerySample Sample { get; private set; }

        private void ListBoxCategory_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get the selected chart category and type.
            string selectedCategory = (string)listBoxCategory.SelectedItem;

            // Get a list of chart types available in this category.
            IEnumerable<string> chartTypes = Sample.GetChartTypes(selectedCategory);

            // Clear and re-populate the ListBox with the selected category and set the initial selection to the 
            // first item.
            listBoxType.Items.Clear();
            foreach (string chartType in chartTypes)
                listBoxType.Items.Add(chartType);
            listBoxType.SelectedIndex = 0;
        }

        private void ListBoxType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get the selected Chart Category and Chart Type.
            string selectedCategory = (string)listBoxCategory.SelectedItem;
            string selectedType = (string)listBoxType.SelectedItem;

            // Only render if both a chart category and type was selected.
            if (selectedCategory != null && selectedType != null)
            {
                // Get the worksheet based on the selected category name.
                SpreadsheetGear.IWorksheet worksheet = Sample.ChartWorkbook.Worksheets[selectedCategory];

                // Get the chart based on the selected type.
                SpreadsheetGear.Charts.IChart chart = worksheet.Shapes[selectedType].Chart;

                // Create the SpreadsheetGear Image class.
                SpreadsheetGear.Drawing.Image image = new SpreadsheetGear.Drawing.Image(chart) {
                    // Set the DPI of the image to match the current display device.
                    Dpi = this.DeviceDpi
                };

                // Generate a new Bitmap representing the shape.
                System.Drawing.Bitmap bitmap = image.GetBitmap();
                
                // Set the PictureBox source to display the bitmap.
                pictureBox.Image = bitmap;
            }
            else
                pictureBox.Image = null;
        }

        #region Sample Initialization Code
        public ChartGallerySample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            // Initialize the sample
            Sample = new SamplesLibrary.Samples.Charting.ChartGallerySample();
            Sample.InitializeSample();
            DisposalManager.RegisterIWorkbookSets(Sample.ChartWorkbook.WorkbookSet);

            // Initialize the Category ListBox, which will in turn trigger the Type ListBox to get
            // populated from its SelectionChanged event handler.
            IEnumerable<string> chartCategories = Sample.GetChartCategories();
            foreach (string chartCategory in chartCategories)
                listBoxCategory.Items.Add(chartCategory);
            listBoxCategory.SelectedIndex = 0;
        }
        #endregion
    }
}