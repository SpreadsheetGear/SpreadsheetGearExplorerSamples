﻿using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace WPFExplorer.Samples.Charting
{
    public partial class ChartGallerySample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.Charting.ChartGallerySample Sample { get; private set; }

        public ChartGallerySample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void listBoxCategory_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get the selected chart category and type.
            string selectedCategory = (string)listBoxCategory.SelectedItem;

            // Get a list of chart types available in this category.
            IEnumerable<string> chartTypes = Sample.GetChartTypes(selectedCategory);

            // Populate the ListBox with these chart types and set the initial selection to the first item.
            listBoxType.ItemsSource = chartTypes;
            listBoxType.SelectedIndex = 0;
        }

        private void listBoxType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get the selected Chart Category and Chart Type.
            string selectedCategory = (string)listBoxCategory.SelectedItem;
            string selectedType = (string)listBoxType.SelectedItem;

            // Only render if both a chart category and type was selected.
            if (selectedCategory != null && selectedType != null)
            {
                // Call into sample to generate a PNG stream image of the chart.
                using (System.IO.MemoryStream bitmapStream = Sample.RenderBitmapStreamGDI(selectedCategory, selectedType))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = bitmapStream;
                    bitmapImage.EndInit();

                    // Set the bitmap source to display in the image control.
                    imageControl.Source = bitmapImage;
                }
            }
            else
                imageControl.Source = null;
        }

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
    }
}
