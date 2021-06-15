using System;

namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class DesignerAndExplorerDialogsSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.DesignerAndExplorerDialogsSample Sample { get; private set; }

        private void ButtonWorkbookDesigner_Click(object sender, EventArgs e)
        {
            Sample.ShowWorkbookDesigner(workbookView);
        }

        private void ButtonWorkbookExplorer_Click(object sender, EventArgs e)
        {
            Sample.ShowWorkbookExplorer(workbookView);
        }

        private void ButtonRangeExplorer_Click(object sender, EventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView and sets it 
            /// up with a new workbook.  Disposal of old workbooks is necessary when using SpreadsheetGear in the "Free" mode,
            /// which has a 3 workbook limit.  If you are copying and pasting this sample code to your own projects and have a
            /// Signed License that activates either the fully-licensed or 30-day evaluation mode of the software, then this
            /// workbook disposal strategy is not needed. See the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> 
            /// code file for more details.
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected RangeExplorerCategoryFlags.
            // You can limit which categories are displayed in the RangeExplorer by passing in only 
            // the desired RangeExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.None;
            if (checkBoxRangeCategoriesNumberFormats.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.NumberFormat;
            if (checkBoxRangeCategoriesAlignment.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Alignment;
            if (checkBoxRangeCategoriesFont.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Font;
            if (checkBoxRangeCategoriesBorders.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Borders;
            if (checkBoxRangeCategoriesInterior.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Interior;
            if (checkBoxRangeCategoriesProtection.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Protection;
            if (checkBoxRangeCategoriesHyperlink.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Hyperlink;
            if (checkBoxRangeCategoriesValidation.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Validation;
            if (checkBoxRangeCategoriesConditionalFormats.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.FormatConditions;

            // Run the sample, passing in the selected category flags.
            Sample.ShowRangeExplorer(workbookView, categoryFlags);
        }

        private void ButtonChartExplorer_Click(object sender, EventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView and sets it 
            /// up with a new workbook.  Disposal of old workbooks is necessary when using SpreadsheetGear in the "Free" mode,
            /// which has a 3 workbook limit.  If you are copying and pasting this sample code to your own projects and have a
            /// Signed License that activates either the fully-licensed or 30-day evaluation mode of the software, then this
            /// workbook disposal strategy is not needed. See the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> 
            /// code file for more details.
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected ChartExplorerCategoryFlags.
            // You can limit which categories are displayed in the ChartExplorer by passing in only 
            // the desired ChartExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.None;
            if (checkBoxChartCategoriesChartArea.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartArea;
            if (checkBoxChartCategoriesChartData.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartData;
            if (checkBoxChartCategoriesPlotArea.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.PlotArea;
            if (checkBoxChartCategoriesLegend.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.Legend;
            if (checkBoxChartCategoriesTitle.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartTitle;
            if (checkBoxChartCategoriesAxes.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.Axes;
            if (checkBoxChartCategoriesSeries.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.SeriesCollection;
            if (checkBoxChartCategoriesPageSetup.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.PageSetup;

            Sample.ShowChartExplorer(workbookView, categoryFlags);
        }

        private void ButtonShapeExplorer_Click(object sender, EventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView and sets it 
            /// up with a new workbook.  Disposal of old workbooks is necessary when using SpreadsheetGear in the "Free" mode,
            /// which has a 3 workbook limit.  If you are copying and pasting this sample code to your own projects and have a
            /// Signed License that activates either the fully-licensed or 30-day evaluation mode of the software, then this
            /// workbook disposal strategy is not needed. See the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> 
            /// code file for more details.
            DisposalManager.ResetWorkbookView(workbookView);

            // "Or" together all of the selected ShapeExplorerCategoryFlags.
            // You can limit which categories are displayed in the ShapeExplorer by passing in only 
            // the desired ShapeExplorerCategoryFlags, or show all with the "All" flag.
            var categoryFlags = SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.None;
            if (checkBoxShapeCategoriesAlignment.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Alignment;
            if (checkBoxShapeCategoriesFont.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Font;
            if (checkBoxShapeCategoriesFill.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Fill;
            if (checkBoxShapeCategoriesLine.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Line;
            if (checkBoxShapeCategoriesProtection.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Protection;
            if (checkBoxShapeCategoriesAutoShape.Checked)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.AutoShape;
            if (checkBoxShapeCategoriesControl.Checked)
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
