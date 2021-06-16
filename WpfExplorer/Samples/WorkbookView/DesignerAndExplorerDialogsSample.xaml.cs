using System.Windows;

namespace WPFExplorer.Samples.WorkbookView
{
    public partial class DesignerAndExplorerDialogsSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.DesignerAndExplorerDialogsSample Sample { get; private set; }

        private void ButtonWorkbookDesigner_Click(object sender, RoutedEventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView and sets it 
            /// up with a new workbook.  Disposal of old workbooks is necessary when using SpreadsheetGear in the "Free" mode,
            /// which has a 3 workbook limit.  If you are copying and pasting this sample code to your own projects and have a
            /// Signed License that activates either the fully-licensed or 30-day evaluation mode of the software, then this
            /// workbook disposal strategy is not needed. See the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> 
            /// code file for more details.
            DisposalManager.ResetWorkbookView(workbookView);

            Sample.ShowWorkbookDesigner(workbookView);
        }

        private void ButtonWorkbookExplorer_Click(object sender, RoutedEventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView and sets it 
            /// up with a new workbook.  Disposal of old workbooks is necessary when using SpreadsheetGear in the "Free" mode,
            /// which has a 3 workbook limit.  If you are copying and pasting this sample code to your own projects and have a
            /// Signed License that activates either the fully-licensed or 30-day evaluation mode of the software, then this
            /// workbook disposal strategy is not needed. See the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> 
            /// code file for more details.
            DisposalManager.ResetWorkbookView(workbookView);

            Sample.ShowWorkbookExplorer(workbookView);
        }

        private void ButtonRangeExplorer_Click(object sender, RoutedEventArgs e)
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
            if (checkBoxRangeCategoriesNumberFormat.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.NumberFormat;
            if (checkBoxRangeCategoriesAlignment.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Alignment;
            if (checkBoxRangeCategoriesFont.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Font;
            if (checkBoxRangeCategoriesBorders.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Borders;
            if (checkBoxRangeCategoriesInterior.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Interior;
            if (checkBoxRangeCategoriesProtection.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Protection;
            if (checkBoxRangeCategoriesHyperlink.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Hyperlink;
            if (checkBoxRangeCategoriesValidation.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.Validation;
            if (checkBoxRangeCategoriesConditionalFormats.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.RangeExplorerCategoryFlags.FormatConditions;

            // Run the sample.
            Sample.ShowRangeExplorer(workbookView, categoryFlags);
        }

        private void ButtonChartExplorer_Click(object sender, RoutedEventArgs e)
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
            if (checkBoxChartCategoriesChartArea.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartArea;
            if (checkBoxChartCategoriesChartData.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartData;
            if (checkBoxChartCategoriesPlotArea.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.PlotArea;
            if (checkBoxChartCategoriesLegend.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.Legend;
            if (checkBoxChartCategoriesTitle.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.ChartTitle;
            if (checkBoxChartCategoriesAxes.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.Axes;
            if (checkBoxChartCategoriesSeries.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.SeriesCollection;
            if (checkBoxChartCategoriesPageSetup.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ChartExplorerCategoryFlags.PageSetup;

            Sample.ShowChartExplorer(workbookView, categoryFlags);
        }

        private void ButtonShapeExplorer_Click(object sender, RoutedEventArgs e)
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
            if (checkBoxShapeCategoriesAlignment.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Alignment;
            if (checkBoxShapeCategoriesFont.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Font;
            if (checkBoxShapeCategoriesFill.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Fill;
            if (checkBoxShapeCategoriesLine.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Line;
            if (checkBoxShapeCategoriesProtection.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.Protection;
            if (checkBoxShapeCategoriesAutoShape.IsChecked == true)
                categoryFlags |= SpreadsheetGear.Windows.Forms.ShapeExplorerCategoryFlags.AutoShape;
            if (checkBoxShapeCategoriesControl.IsChecked == true)
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
