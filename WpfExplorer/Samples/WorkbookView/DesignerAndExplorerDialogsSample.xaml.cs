using System.Windows;

namespace WPFExplorer.Samples.WorkbookView
{
    public partial class DesignerAndExplorerDialogsSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.DesignerAndExplorerDialogsSample Sample { get; private set; }

        private void button_workbookDesigner_Click(object sender, RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);
            Sample.ShowWorkbookDesigner(workbookView);
        }

        private void button_workbookExplorer_Click(object sender, RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);
            Sample.ShowWorkbookExplorer(workbookView);
        }

        private void button_rangeExplorer_Click(object sender, RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected RangeExplorerCategoryFlags.
            // You can limit which categories are displayed in the RangeExplorer by passing in only 
            // the desired RangeExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.None;
            if (checkBox_rangeCategories_numberFormat.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.NumberFormat;
            if (checkBox_rangeCategories_alignment.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Alignment;
            if (checkBox_rangeCategories_font.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Font;
            if (checkBox_rangeCategories_borders.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Borders;
            if (checkBox_rangeCategories_interior.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Interior;
            if (checkBox_rangeCategories_protection.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Protection;
            if (checkBox_rangeCategories_hyperlink.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Hyperlink;
            if (checkBox_rangeCategories_validation.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Validation;
            if (checkBox_rangeCategories_conditionalFormats.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.FormatConditions;

            // Run the sample.
            Sample.ShowRangeExplorer(workbookView, categoryFlags);
        }

        private void button_chartExplorer_Click(object sender, RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected ChartExplorerCategoryFlags.
            // You can limit which categories are displayed in the ChartExplorer by passing in only 
            // the desired ChartExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.None;
            if (checkBox_chartCategories_chartArea.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartArea;
            if (checkBox_chartCategories_plotArea.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.PlotArea;
            if (checkBox_chartCategories_legend.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.Legend;
            if (checkBox_chartCategories_title.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartTitle;
            if (checkBox_chartCategories_axes.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.Axes;
            if (checkBox_chartCategories_series.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.SeriesCollection;
            if (checkBox_chartCategories_pageSetup.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.PageSetup;

            Sample.ShowChartExplorer(workbookView, categoryFlags);
        }

        private void button_shapeExplorer_Click(object sender, RoutedEventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected ShapeExplorerCategoryFlags.
            // You can limit which categories are displayed in the ShapeExplorer by passing in only 
            // the desired ShapeExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.None;
            if (checkBox_shapeCategories_alignment.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Alignment;
            if (checkBox_shapeCategories_font.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Font;
            if (checkBox_shapeCategories_fill.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Fill;
            if (checkBox_shapeCategories_line.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Line;
            if (checkBox_shapeCategories_protection.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Protection;
            if (checkBox_shapeCategories_autoShape.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.AutoShape;
            if (checkBox_shapeCategories_control.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Control;

            Sample.ShowShapeExplorer(workbookView, categoryFlags);
        }


        #region Sample Initialization Code
        public DesignerAndExplorerDialogsSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.DesignerAndExplorerDialogsSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
