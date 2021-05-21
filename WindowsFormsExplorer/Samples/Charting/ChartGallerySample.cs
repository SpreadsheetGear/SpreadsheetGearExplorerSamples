using System.Collections.Generic;

namespace WindowsFormsExplorer.Samples.Charting
{
    public partial class ChartGallerySample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Charting.ChartGallerySample Sample { get; private set; }

        private void listBoxCategory_SelectedIndexChanged(object sender, System.EventArgs e)
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


        private void listBoxType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // Get the selected Chart Category and Chart Type.
            string selectedCategory = (string)listBoxCategory.SelectedItem;
            string selectedType = (string)listBoxType.SelectedItem;

            // Only render if both a chart category and type was selected.
            if (selectedCategory != null && selectedType != null)
            {
                // Call into sample to generate a Bitmap image of the chart.
                System.Drawing.Bitmap bitmap = Sample.RenderBitmapGDI(selectedCategory, selectedType);
                
                // Set the PictureBox source to display in the bitmap.
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