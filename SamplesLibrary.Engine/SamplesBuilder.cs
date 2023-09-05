/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary.Engine.Samples.Charting;
using SamplesLibrary.Engine.Samples.Charting.Basic;
using SamplesLibrary.Engine.Samples.Charting.Stock;
using SamplesLibrary.Engine.Samples.Shapes;
using SamplesLibrary.Engine.Samples.Workbook;
using SamplesLibrary.Engine.Samples.Workbook.Worksheet;
using SamplesLibrary.Engine.Samples.Workbook.Worksheet.Range.ConditionalFormats;
using SamplesLibrary.Engine.Samples.Workbook.Worksheet.Range.Formatting;
using SamplesLibrary.Engine.Samples.Workbook.Worksheet.Range.Operations;
using SamplesLibrary.Engine.Samples.Workbook.Worksheet.Range.ValuesAndFormulas;
using SamplesLibrary.Engine.Samples.Shapes.FormControls;
using SamplesLibrary.Engine.Samples.Shapes.Lines;
using SamplesLibrary.Engine.Samples.Reporting;

namespace SamplesLibrary.Engine
{
    /// <summary>
    /// Builds up categories and SpreadsheetGear Engine Samples.
    /// </summary>
    public class SamplesBuilder
    {
        public static Category Build()
        {
            // Root is never actually displayed, just acts as a container for all categories / samples.
            var categoryRoot = Category.CreateRoot();

            // Main folder that contains all samples
            string introMd = System.IO.File.ReadAllText(Helpers.GetFullOutputFolderPath(@"Files\ExplorerIntro.md"));
            var explorerCategory = categoryRoot.AddCategory("SpreadsheetGear Explorer Samples", "Samples", introMd, 0);
            explorerCategory.HideNameFromCategorySummary = true;

            var categoryWorkbook = explorerCategory.AddCategory("Workbook", "Workbook", "Samples demonstrating IWorkbook API.", 20);
            {
                categoryWorkbook.AddEngineSample<CellStylesSample>("Cell Styles", "Create custom cell Styles or modify built-in Styles.", 10);
                categoryWorkbook.AddEngineSample<SavingAndOpeningSample>("Saving and Opening", "Save to and open from a variety of sources using a variety of file formats.  NOTE: running this sample won't make any visible changes.  Browse the 'Temp' directory under the executing directory (typically the 'bin' folder) to view the resultant files saved by this sample.", 20, false);
                categoryWorkbook.AddEngineSample<SavingAndOpeningEncryptedSample>("Saving and Opening (Encrypted)", "Save to and open from a variety of sources using a variety of file formats.  NOTE: running this sample won't make any visible changes.  Browse the 'Temp' directory under the executing directory (typically the 'bin' folder) to view the resultant files saved by this sample.", 30, false);
                categoryWorkbook.AddEngineSample<DocumentPropertiesSample>("Document Properties", "Demonstrates setting a variety of Built-In Document Properties as well as creating Custom Properties.", 40, false);

                var categoryWorksheet = categoryWorkbook.AddCategory("Worksheet", "Worksheet", "Samples demonstrating IWorksheet API.", 10);
                {
                    categoryWorksheet.AddEngineSample<WorksheetProtectionSample>("Worksheet Protection", "Demonstrates various options available when enabling and disabling worksheet protection.", 10, false);
                    categoryWorksheet.AddEngineSample<TabColorsSample>("Tab Colors", "Modify various attributes relating to sheet tabs.", 20, false);
                    categoryWorksheet.AddEngineSample<NamedRangeSample>("Named Ranges", "Worksheet-scoped named ranges are managed from the IWorksheet.Names[...] collection.", 30, false);
                    categoryWorksheet.AddEngineSample<SheetVisibilitySample>("Sheet Visibility", "Sheets can be made visible to the end-user, and can be either 'hidden' or 'very hidden' as described in this sample.", 40, false);
                    categoryWorksheet.AddEngineSample<MoveAndCopySample>("Move and Copy", "Sheets can be moved and copied with ISheet.MoveAfter(...) / MoveBefore(...) and CopyAfter(...) / CopyBefore(...).", 50, false);
                    categoryWorksheet.AddEngineSample<DisplayOptionsSample>("Display Options", "Modify options such as freeze panes, set gridline visibility and color, show and hide headings, zoom, current range selection and more.", 60, false);

                    var categoryRange = categoryWorksheet.AddCategory("Range", "Range", "Add a variety of formatting, comments, grouping, hyperlinks, protection, validation, values, and merge, find, replace, filter, sort, goal seek, or fill data.", 10);
                    {
                        var categoryFormats = categoryRange.AddCategory("Formatting", "Formatting", "Samples related primarily to formatting/styling cells in some way.", 10);
                        {
                            categoryFormats.AddEngineSample<FontSample>("Font", "Set various font options such as Font Name, Bold and Color.", 10, renderImageRange: "A1:C3");
                            categoryFormats.AddEngineSample<RichTextSample>("Rich-Text Formatting (RTF)", "Demonstrates uniquely formatting specific sub-portions of text in a cell.", 20, renderImageRange: "A1:C3");
                            categoryFormats.AddEngineSample<BordersSample>("Borders", "Demonstrates setting various border style options such as LineStyle, Weight and Color; as well as affecting specific border edges or all edges at once.", 30, renderImageRange: "A1:E17");
                            categoryFormats.AddEngineSample<InteriorSample>("Interior", "Demonstrate various interior fills using solid Pre-Defined colors, Theme Colors with TintAndShade, Pattern Fills and Gradient Fills.", 40, renderImageRange: "A1:K18");
                            categoryFormats.AddEngineSample<OrientationSample>("Orientation", "Set text orientation.", 50);
                            categoryFormats.AddEngineSample<HyperlinksSample>("Hyperlinks", "Add hyperlinks to worksheet cells.", 60, false);
                            categoryFormats.AddEngineSample<ValidationSample>("Validation", "Add data validation to worksheet cells.", 70, false);
                            categoryFormats.AddEngineSample<CommentsSample>("Comments", "Add a cell comment to a worksheet cell.", 80, false);
                            categoryFormats.AddEngineSample<NumberFormatsSample>("Number Formats", "Set number formats for worksheet cells.", 90);
                        }

                        var categoryCFs = categoryRange.AddCategory("Conditional Formats", "ConditionalFormats", "Demonstrates a variety of ways to format cells using Conditional Formatting.", 20);
                        {
                            categoryCFs.AddEngineSample<ColorScaleSample>("Color Scale", "Create a Color Scale Conditional Format.", 10);
                            categoryCFs.AddEngineSample<DataBarSample>("Data Bar", "Create a Data Bar Conditional Format.", 20);
                            categoryCFs.AddEngineSample<IconSetSample>("Icon Set", "Create an Icon Set Conditional Format.", 30);
                            categoryCFs.AddEngineSample<Top10Sample>("Top 10", "Create a Top 10 Conditional Format.", 40);
                            categoryCFs.AddEngineSample<AboveAverageSample>("Above Average", "Create an Above Average Conditional Format.", 50);
                            categoryCFs.AddEngineSample<UniqueValuesSample>("Unique Values", "Create a Unique Values Conditional Format.", 60);
                            categoryCFs.AddEngineSample<CellValueSample>("Cell Value", "Create a Cell Value Conditional Format.", 70);
                            categoryCFs.AddEngineSample<CustomExpressionSample>("Custom Expression", "Demonstrates using a custom Expression-based Conditional Format to highlight data rows based on whether the Expression evaluates to true or false. In this case, all versions of .NET that were released in the month of November for any given year will be highlighted.", 80);
                            categoryCFs.AddEngineSample<AlternatingRowColorsSample>("Alternating Row Colors", "Demonstrates using an Expression-based Conditional Format to create alternating row colors on a data range.", 90);
                        }

                        var categoryValsFormulas = categoryRange.AddCategory("Values and Formulas", "ValuesAndFormulas", "Samples that involve getting or setting cell values and formulas as well as 'What-If' analysis features.", 30);
                        {
                            categoryValsFormulas.AddEngineSample<CreateFormulaSample>("Create Formula", "Create a workbook with cell containing a formula using the =RAND() function.", 10, renderImageRange: "A1:C3");
                            categoryValsFormulas.AddEngineSample<ValuesFromArraySample>("Values From Array", "Set cell values from a two-dimensional object array.", 20);
                            categoryValsFormulas.AddEngineSample<ArrayFormulaSample>("Array Formula", "Creates Array Formulas on both a single cell and range of cells.", 30);
                            categoryValsFormulas.AddEngineSample<GoalSeekSample>("Goal Seek", "Achieve a specific goal from a calculated result using a simple iterative linear search. In this sample we find the loan amount based on a desired payment by entering the desired payment, interest rate and term.", 40);
                            categoryValsFormulas.AddEngineSample<WhatIfDataTableSample>("What-If Data Table", "Creates a What-If Data Table to calculate various loan totals based on varying interest rates and terms.", 50, renderImageRange: "A1:I13");
                        }

                        var categoryOperations = categoryRange.AddCategory("Operations", "Operations", "Demonstrates various operations that can be performed on ranges, such as AutoFilters, Sorting, Merging and more.", 40);
                        {
                            categoryOperations.AddEngineSample<AutoFilterSample>("Auto Filter", "Use auto filters to view subsets of data in a worksheet. Ten examples are provided, each one executing a different type of criteria on its own worksheet.", 10, false);
                            categoryOperations.AddEngineSample<LockAndProtectCellsSample>("Lock And Protect Cells", "Lock and unlock cells and enable worksheet protection on two worksheets, protecting with and without a password.", 20, false);
                            categoryOperations.AddEngineSample<GroupAndOutlineSample>("Group And Outline", "Group and outline ranges of cells.", 30, false);
                            categoryOperations.AddEngineSample<SortingSample>("Sorting", "Sort a range of data.", 40);
                            categoryOperations.AddEngineSample<MergeCellsSample>("Merge Cells", "Merge a range of cells.", 50, renderImageRange: "A1:F6");
                            categoryOperations.AddEngineSample<FillDataSeriesSample>("Fill Data Series", "Automatically fill cells with data.", 60);
                        }
                    }
                }
            }

            var categoryCharting = explorerCategory.AddCategory("Charting", "Charting", "Richly formatted workbooks with fast and complete calculations are the heart and soul of a spreadsheet, but the ability to make good decisions is greatly enhanced by the ability to visualize data. Enhance your users' understanding of their data by taking advantage of SpreadsheetGear's comprehensive Excel compatible charting support.", 30);
            {
                categoryCharting.AddEngineSample<ScatterChartSample>("Scatter Chart", "Demonstrates generating a Scatter Chart where x and y data sets are plotted on a single set of axes.", 20);
                categoryCharting.AddEngineSample<BubbleChartSample>("Bubble Chart", "Create a bubble chart representing three sets of data values.", 30, renderImageRange: "A1:J14");
                categoryCharting.AddEngineSample<RadarChartSample>("Radar Chart", "Use a radar chart to plot each category of data on a separate value axis.", 40);
                categoryCharting.AddEngineSample<GanttChartSample>("Gantt Chart", "Use stacked bars and various formatting to simulate a gantt chart.", 50, renderImageRange: "A1:J14");
                categoryCharting.AddEngineSample<CombinationChartSample>("Combination Chart", "Create a combination chart by utilizing multiple chart groups and multiple axes groups.", 60, renderImageRange: "A1:K14");
                categoryCharting.AddEngineSample<EmbeddedPictureInChartSample>("Embedded Picture In Chart", "Demonstrates how to embed a picture into a chart, in this case to act as a replacement for the Chart Title.", 70, renderImageRange: "A1:J16");
                categoryCharting.AddEngineSample<CreateChartSheetSample>("Create Chart Sheet", "Creates a ChartSheet and populates the chart with some data.", 80, false);
                var categoryChartingBasic = categoryCharting.AddCategory("Basic", "Basic", "Samples demonstrating constructing basic chart types.", 10);
                {
                    categoryChartingBasic.AddEngineSample<ColumnChartSample>("Column Chart", "Demonstrates generating a basic Column Chart.", 10, renderImageRange: "A1:L14");
                    categoryChartingBasic.AddEngineSample<LineChartSample>("Line Chart", "Demonstrates generating a basic Line Chart.", 20, renderImageRange: "A1:L14");
                    categoryChartingBasic.AddEngineSample<PieChartSample>("Pie Chart", "Demonstrates generating a basic Pie Chart.", 30, renderImageRange: "A1:L14");
                    categoryChartingBasic.AddEngineSample<BarChartSample>("Bar Chart", "Demonstrates generating a basic Bar Chart.", 40, renderImageRange: "A1:L14");
                    categoryChartingBasic.AddEngineSample<AreaChartSample>("Area Chart", "Demonstrates generating a basic Area Chart.", 50, renderImageRange: "A1:L14");
                }
                var categoryChartingStock = categoryCharting.AddCategory("Stock", "Stock", "Samples demonstrating constructing a variety of stock charts.", 20);
                {
                    categoryChartingStock.AddEngineSample<HLCStockChartSample>("H-L-C Stock Chart", "Demonstrates generating an H-L-C Stock Chart.", 10);
                    categoryChartingStock.AddEngineSample<OHLCStockChartSample>("O-H-L-C Stock Chart", "Demonstrates generating an O-H-L-C Stock Chart.", 20);
                    categoryChartingStock.AddEngineSample<VHLCStockChartSample>("V-H-L-C Stock Chart", "Demonstrates generating an V-H-L-C Stock Chart.", 30);
                    categoryChartingStock.AddEngineSample<VOHLCStockChartSample>("V-O-H-L-C Stock Chart", "Demonstrates generating an V-O-H-L-C Stock Chart.", 40);
                }
            }

            var categoryShapes = explorerCategory.AddCategory("Shapes", "Shapes", "", 40);
            {
                var categoryFormControls = categoryShapes.AddCategory("Form Controls", "FormControls", "", 10);
                {
                    categoryFormControls.AddEngineSample<ButtonSample>("Button", "Add a button to a worksheet. When attached to a WorkbookView, use the WorkbookView.ShapeAction(...) event to handle clicks on a button.", 10, false);
                    categoryFormControls.AddEngineSample<CheckBoxSample>("CheckBox", "Add a checkbox to a worksheet and link its state to a cell.", 20, false);
                    categoryFormControls.AddEngineSample<ComboBoxSample>("ComboBox", "Add a ComboBox to a worksheet, fill it with a range of values, and link it to a cell.", 30, false);
                    categoryFormControls.AddEngineSample<ListBoxSample>("ListBox", "Add a ListBox to a worksheet, fill it with a range of values, and link it to a cell.", 40, false);
                    categoryFormControls.AddEngineSample<SpinnerSample>("Spinner", "Add a checkbox to a worksheet and link its state to a cell.", 50, false);
                    categoryFormControls.AddEngineSample<ScrollBarSample>("ScrollBar", "Demonstrates adding a ScrollBar control to a worksheet, linking its value to a cell, then setting its various options such as the amount to change the value when the up/down arrows are clicked or when the main scroll area is clicked. The linked cell is also linked to a chart series whose line will change in reaction to changes in the ScrollBar value.", 60, false);
                    categoryFormControls.AddEngineSample<GroupBoxAndOptionButtonsSample>("GroupBox And OptionButtons", "Creates a GroupBox and series of OptionButtons that are linked to a cell. Also demonstrates adding these control relative to a range of cells--adding an OptionButton within each row of the provided range and surrounding all OptionButtons within a GroupBox.", 70, false);
                }

                var categoryLines = categoryShapes.AddCategory("Lines", "Lines", "", 20);
                {
                    categoryLines.AddEngineSample<LineWeightSample>("Line Weight", "Adds lines with various weights.", 10, renderImageRange: "A1:G25");
                    categoryLines.AddEngineSample<LineDashStyleSample>("LineDashStyle", "Adds lines using all of the various dash styles defined in SpreadsheetGear.Shapes.LineDashStyle.", 20, renderImageRange: "A1:H25");
                    categoryLines.AddEngineSample<ArrowheadsSample>("Arrowheads", "Adds lines using all of the various options defined in SpreadsheetGear.Shapes.ArrowheadStyle, ArrowheadLength and ArrowheadWidth.", 30, renderImageRange: "A1:F10");
                }

                categoryShapes.AddEngineSample<PictureSample>("Picture", "Add a picture from an image file to a worksheet.", 10, renderImageRange: "A1:L7");
                categoryShapes.AddEngineSample<CroppedPictureSample>("Cropped Picture", "Adds a picture consisting of the SpreadsheetGear logo on the left and text \"SpreadsheetGear\" on the right, then crops the \"SpreadsheetGear\" text out of the picture, leaving just the logo.", 20, renderImageRange: "A1:K13");
                categoryShapes.AddEngineSample<TextBoxSample>("TextBox", "Add a textbox to a worksheet and set the text and font.", 30, renderImageRange: "A1:F12");
                categoryShapes.AddEngineSample<AutoShapesSample>("Auto Shapes", "Add autoshapes to a worksheet and set the fill and line style.", 40, renderImageRange: "A1:G12");
            }

            var categoryReporting = explorerCategory.AddCategory("Reporting", "Reporting", "With the wide adoption of Microsoft Excel, there is no substitute for taking advantage of spreadsheet components in your .NET projects. You can use SpreadsheetGear to deliver spreadsheet reports in a variety of ways. The following samples show some basic ways to create spreadsheet content, which can be saved to Excel files, streamed as downloadable files in a browser, displayed in a SpreadsheetGear WPF or Windows Forms WorkbookView and more.", 80);
            {
                categoryReporting.AddEngineSample<SimpleSpreadsheetSample>("Simple Spreadsheet", "Add values and simple formatting to a workbook.", 10);
                categoryReporting.AddEngineSample<DataTableToWorkbookSample>("DataTable to Workbook", "Copy data from a DataTable to a workbook.", 20);
                categoryReporting.AddEngineSample<DataSetToWorkbookSample>("DataSet to Workbook", "Insert data from multiple DataTables and merge this data with formatting and formulas from a template workbook.", 30, false);
                categoryReporting.AddEngineSample<FormulasAndFormattingSample>("Formulas and Formatting", "Add values, formulas, defined names and formatting.", 40);
            }

            return categoryRoot;
        }
    }


    public static class CategoryExtensions
    {
        /// <summary>
        /// Just adds simple type checking through generics to ensure expected type for sample  is used.
        /// </summary>
        public static void AddEngineSample<T>(this Category category, string sampleName, string description, int sortIndex, bool canRenderImage = true, bool canDownloadFile = true, string renderImageRange = null)
            where T : ISpreadsheetGearEngineSample
        {
            var sampleInfo = category.AddSample<T>(sampleName, description, sortIndex, false);
            sampleInfo.CanRenderImage = canRenderImage;
            sampleInfo.CanDownloadFile = canDownloadFile;
            sampleInfo.RenderImageRange = renderImageRange;
            sampleInfo.AddSourceCode($"{typeof(T).Name}.code.cs");
        }
    }
}