using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace WPFExplorer.Samples.Charting
{
    public partial class ChartGallerySample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.Charting.ChartGallerySample Sample { get; private set; }

        public ChartGallerySample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void ListBoxCategory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get the selected chart category and type.
            string selectedCategory = (string)listBoxCategory.SelectedItem;

            // Get a list of chart types available in this category.
            IEnumerable<string> chartTypes = Sample.GetChartTypes(selectedCategory);

            // Populate the ListBox with these chart types and set the initial selection to the first item.
            listBoxType.ItemsSource = chartTypes;
            listBoxType.SelectedIndex = 0;
        }

        private void ListBoxType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
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
                SpreadsheetGear.Windows.Media.Image image = new SpreadsheetGear.Windows.Media.Image(chart);

                // Generate a new BitmapSource representing the shape.
                System.Windows.Media.Imaging.BitmapSource bitmap = image.GetBitmap();

                // Set the bitmap source to display in the image control.
                imageControl.Source = bitmap;
            }
            else
                imageControl.Source = null;
        }

        #region Sample Initialization Code
        public void InitializeSample()
        {
            // Initialize the sample
            Sample = new SamplesLibrary.Samples.Charting.ChartGallerySample();
            Sample.InitializeSample();
            DisposalManager.RegisterIWorkbookSets(Sample.ChartWorkbook.WorkbookSet);

            // Initialize the Category ListBox, which will in turn trigger the Type ListBox to get
            // populated from its SelectionChanged event handler.
            IEnumerable<string> chartCategories = Sample.GetChartCategories();
            listBoxCategory.ItemsSource = chartCategories;
            listBoxCategory.SelectedIndex = 0;
        }
        #endregion
    }
}
