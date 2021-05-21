using System;

namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class DesignerAndExplorerDialogsSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.DesignerAndExplorerDialogsSample Sample { get; private set; }

        private void buttonWorkbookDesigner_Click(object sender, EventArgs e)
        {
            Sample.ShowWorkbookDesigner(workbookView);
        }

        private void buttonWorkbookExplorer_Click(object sender, EventArgs e)
        {
            Sample.ShowWorkbookExplorer(workbookView);
        }

        private void buttonRangeExplorer_Click(object sender, EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected RangeExplorerCategoryFlags.
            // You can limit which categories are displayed in the RangeExplorer by passing in only 
            // the desired RangeExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.None;
            if (checkBox_rangeCategories_numberFormats.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.NumberFormat;
            if (checkBox_rangeCategories_alignment.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Alignment;
            if (checkBox_rangeCategories_font.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Font;
            if (checkBox_rangeCategories_borders.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Borders;
            if (checkBox_rangeCategories_interior.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Interior;
            if (checkBox_rangeCategories_protection.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Protection;
            if (checkBox_rangeCategories_hyperlink.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Hyperlink;
            if (checkBox_rangeCategories_validation.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Validation;
            if (checkBox_rangeCategories_conditionalFormats.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.FormatConditions;

            // Run the sample, passing in the selected category flags.
            Sample.ShowRangeExplorer(workbookView, categoryFlags);
        }

        private void buttonChartExplorer_Click(object sender, EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected ChartExplorerCategoryFlags.
            // You can limit which categories are displayed in the ChartExplorer by passing in only 
            // the desired ChartExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.None;
            if (checkBox_chartCategories_chartArea.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartArea;
            if (checkBox_chartCategories_plotArea.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.PlotArea;
            if (checkBox_chartCategories_legend.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.Legend;
            if (checkBox_chartCategories_title.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartTitle;
            if (checkBox_chartCategories_axes.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.Axes;
            if (checkBox_chartCategories_series.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.SeriesCollection;
            if (checkBox_chartCategories_pageSetup.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.PageSetup;

            Sample.ShowChartExplorer(workbookView, categoryFlags);
        }

        private void buttonShapeExplorer_Click(object sender, EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected ShapeExplorerCategoryFlags.
            // You can limit which categories are displayed in the ShapeExplorer by passing in only 
            // the desired ShapeExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.None;
            if (checkBox_shapeCategories_alignment.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Alignment;
            if (checkBox_shapeCategories_font.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Font;
            if (checkBox_shapeCategories_fill.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Fill;
            if (checkBox_shapeCategories_line.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Line;
            if (checkBox_shapeCategories_protection.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Protection;
            if (checkBox_shapeCategories_autoShape.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.AutoShape;
            if (checkBox_shapeCategories_control.Checked)
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
            workbookView.GetLock();
            try
            {
                workbookView.ActiveCell.Value = "Click on any cell to fill it with a color.";
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }
        #endregion
    }
}
