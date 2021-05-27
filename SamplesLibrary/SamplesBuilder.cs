/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary.Samples.Charting;
using SamplesLibrary.Samples.Charting.Basic;
using SamplesLibrary.Samples.Charting.Stock;
using SamplesLibrary.Samples.Shapes;
using SamplesLibrary.Samples.Workbook;
using SamplesLibrary.Samples.Workbook.Worksheet;
using SamplesLibrary.Samples.Workbook.Worksheet.Range.ConditionalFormats;
using SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting;
using SamplesLibrary.Samples.Workbook.Worksheet.Range.Operations;
using SamplesLibrary.Samples.Workbook.Worksheet.Range.ValuesAndFormulas;
using SamplesLibrary.Samples.Shapes.FormControls;
using SamplesLibrary.Samples.Shapes.Lines;
using SamplesLibrary.Samples.Reporting;
using SamplesLibrary.Samples.WorkboookView;
using SamplesLibrary.Samples.WorkboookView.DisplayOptions;
using SamplesLibrary.Samples.WorkboookView.CommandManager;
using SamplesLibrary.Samples.DataGrid;
using SamplesLibrary.Samples.Calculations;
using SamplesLibrary.Samples.Advanced;
using SamplesLibrary.Samples.Printing;

namespace SamplesLibrary
{
    /// <summary>
    /// Builds up categories and SpreadsheetGear Engine / Windows Samples.
    /// </summary>
    public class SamplesBuilder
    {
        public static Category Build(bool includeWindowsSamples = true)
        {
            // Root is never actually displayed, just acts as a container for all categories / samples.
            var categoryRoot = Category.CreateRoot();

            // Main folder that contains all samples
            string introMd = System.IO.File.ReadAllText(Helpers.GetFullOutputFolderPath(@"Files\ExplorerIntro.md"));
            var explorerCategory = categoryRoot.AddCategory("SpreadsheetGear Explorer Samples", "Samples", introMd);
            explorerCategory.HideNameFromCategorySummary = true;

            if (includeWindowsSamples)
            {
                var categoryWbvSamples = explorerCategory.AddCategory("WorkbookView", "WorkbookView", "WorkbookView properties, methods, designer, explorers, display options, and events.");
                {
                    categoryWbvSamples.AddWindowsSample<ActiveWorkbookSample>("Active Workbook", "Create or open workbooks from a variety of locations (Disk, Uri, memory stream, byte array).", true);
                    categoryWbvSamples.AddWindowsSample<ActiveWorksheetSample>("Active Worksheet", "Add multiple worksheets to a workbook and display a new worksheet.", true);
                    categoryWbvSamples.AddWindowsSample<CultureInfoSample>("CultureInfo", "Specify a CultureInfo to be used for various regional formatting conventions such as date formats, list separator, decimal separator, currency symbol and more.  This sample creates a workbook with the German ('de-DE') CultureInfo, saves the workbook to disk, and re-opens it in the selected CultureInfo to demonstrate changes in locale-senstive formats.", true);
                    categoryWbvSamples.AddWindowsSample<DesignerAndExplorerDialogsSample>("Designer and Explorer Dialogs", "Show the Workbook Designer, Workbook Explorer, Range Explorer, Chart Explorer, and Shape Explorer.", true);
                    categoryWbvSamples.AddWindowsSample<LocationToRangeSample>("Location To Range", "Use the LocationToRange method from a mouse event.", true);

                    var categoryDisplayOptions = categoryWbvSamples.AddCategory("Display Options", "DisplayOptions", "Use display properties to customize the presentation of workbooks.");
                    {
                        categoryDisplayOptions.AddWindowsSample<DisplayReferenceSample>("DisplayReference", "Use the DisplayReference property to set the viewable area of a workbook.", true);
                        categoryDisplayOptions.AddWindowsSample<WorkbookWindowInfoSample>("WorkbookWindowInfo", "Show and hide scroll bars and workbook tabs.", true);
                        categoryDisplayOptions.AddWindowsSample<WorksheetWindowInfoSample>("WorksheetWindowInfo", "Freeze panes, set gridline color, show and hide headings, and zoom.", true);
                    }

                    var categoryCommandManager = categoryWbvSamples.AddCategory("CommandManager", "CommandManager", "Extensions to the default command framework.");
                    {
                        categoryCommandManager.AddWindowsSample<SimpleCommandSample>("Simple Command", "Create and execute a simple undoable command.", true);
                        categoryCommandManager.AddWindowsSample<CommandRangeSample>("Command Range", "Create and execute a CommandRange that sets a range interior color and provides built-in undoable capabilities to restore the interior color without the need for your command to keep track of its own state.", true);
                    }
                }
            }

            var categoryWorkbook = explorerCategory.AddCategory("Workbook", "Workbook", "Samples demonstrating IWorkbook API.");
            {
                categoryWorkbook.AddEngineSample<CellStylesSample>("Cell Styles", "Create custom cell Styles or modify built-in Styles.");
                categoryWorkbook.AddEngineSample<SavingAndOpeningSample>("Saving and Opening", "Save to and open from a variety of sources using a variety of file formats.  NOTE: running this sample won't make any visible changes.  Browse the 'Temp' directory under the executing directory (typically the 'bin' folder) to view the resultant files saved by this sample.");
                categoryWorkbook.AddEngineSample<SavingAndOpeningEncryptedSample>("Saving and Opening (Encrypted)", "Save to and open from a variety of sources using a variety of file formats.  NOTE: running this sample won't make any visible changes.  Browse the 'Temp' directory under the executing directory (typically the 'bin' folder) to view the resultant files saved by this sample.");
                categoryWorkbook.AddEngineSample<DocumentPropertiesSample>("Document Properties", "Demonstrates setting a variety of Built-In Document Properties as well as creating Custom Properties.", false);

                var categoryWorksheet = categoryWorkbook.AddCategory("Worksheet", "Worksheet", "Samples demonstrating IWorksheet API.");
                {
                    categoryWorksheet.AddEngineSample<WorksheetProtectionSample>("Worksheet Protection", "Demonstrates various options available when enabling and disabling worksheet protection.", false);
                    categoryWorksheet.AddEngineSample<TabColorsSample>("Tab Colors", "Modify various attributes relating to sheet tabs.", false);
                    categoryWorksheet.AddEngineSample<NamedRangeSample>("Named Ranges", "Worksheet-scoped named ranges are managed from the IWorksheet.Names[...] collection.", false);
                    categoryWorksheet.AddEngineSample<SheetVisibilitySample>("Sheet Visibility", "Sheets can be made visible to the end-user, and can be either 'hidden' or 'very hidden' as described in this sample.", false);
                    categoryWorksheet.AddEngineSample<MoveAndCopySample>("Move and Copy", "Sheets can be moved and copied with ISheet.MoveAfter(...) / MoveBefore(...) and CopyAfter(...) / CopyBefore(...).", false);
                    categoryWorksheet.AddEngineSample<DisplayOptionsSample>("Display Options", "Modify options such as freeze panes, set gridline visibility and color, show and hide headings, zoom, current range selection and more.", false);

                    var categoryRange = categoryWorksheet.AddCategory("Range", "Range", "Add a variety of formatting, comments, grouping, hyperlinks, protection, validation, values, and merge, find, replace, filter, sort, goal seek, or fill data.");
                    {
                        var categoryFormats = categoryRange.AddCategory("Formatting", "Formatting", "Samples related primarily to formatting/styling cells in some way.");
                        {
                            categoryFormats.AddEngineSample<FontSample>("Font", "Set various font options such as Font Name, Bold and Color.", renderImageRange: "A1:C3");
                            categoryFormats.AddEngineSample<RichTextSample>("Rich-Text Formatting (RTF)", "Demonstrates uniquely formatting specific sub-portions of text in a cell.", renderImageRange: "A1:C3");
                            categoryFormats.AddEngineSample<BordersSample>("Borders", "Demonstrates setting various border style options such as LineStyle, Weight and Color; as well as affecting specific border edges or all edges at once.", renderImageRange: "A1:E17");
                            categoryFormats.AddEngineSample<InteriorSample>("Interior", "Demonstrate various interior fills using solid Pre-Defined colors, Theme Colors with TintAndShade, Pattern Fills and Gradient Fills.", renderImageRange: "A1:K18");
                            categoryFormats.AddEngineSample<OrientationSample>("Orientation", "Set text orientation.");
                            categoryFormats.AddEngineSample<HyperlinksSample>("Hyperlinks", "Add hyperlinks to worksheet cells.", false);
                            categoryFormats.AddEngineSample<ValidationSample>("Validation", "Add data validation to worksheet cells.", false);
                            categoryFormats.AddEngineSample<CommentsSample>("Comments", "Add a cell comment to a worksheet cell.", false);
                            categoryFormats.AddEngineSample<NumberFormatsSample>("Number Formats", "Set number formats for worksheet cells.");
                        }

                        var categoryCFs = categoryRange.AddCategory("Conditional Formats", "ConditionalFormats", "Demonstrates a variety of ways to format cells using Conditional Formatting.");
                        {
                            categoryCFs.AddEngineSample<ColorScaleSample>("Color Scale", "Create a Color Scale Conditional Format.");
                            categoryCFs.AddEngineSample<DataBarSample>("Data Bar", "Create a Data Bar Conditional Format.");
                            categoryCFs.AddEngineSample<IconSetSample>("Icon Set", "Create an Icon Set Conditional Format.");
                            categoryCFs.AddEngineSample<Top10Sample>("Top 10", "Create a Top 10 Conditional Format.");
                            categoryCFs.AddEngineSample<AboveAverageSample>("Above Average", "Create an Above Average Conditional Format.");
                            categoryCFs.AddEngineSample<UniqueValuesSample>("Unique Values", "Create a Unique Values Conditional Format.");
                            categoryCFs.AddEngineSample<CellValueSample>("Cell Value", "Create a Cell Value Conditional Format.");
                            categoryCFs.AddEngineSample<CustomExpressionSample>("Custom Expression", "Demonstrates using a custom Expression-based Conditional Format to highlight data rows based on whether the Expression evaluates to true or false. In this case, all versions of .NET that were released in the month of November for any given year will be highlighted.");
                            categoryCFs.AddEngineSample<AlternatingRowColorsSample>("Alternating Row Colors", "Demonstrates using an Expression-based Conditional Format to create alternating row colors on a data range.");
                        }

                        var categoryValsFormulas = categoryRange.AddCategory("Values and Formulas", "ValuesAndFormulas", "Samples that involve getting or setting cell values and formulas as well as 'What-If' analysis features.");
                        {
                            categoryValsFormulas.AddEngineSample<CreateFormulaSample>("Create Formula", "Create a workbook with cell containing a formula using the =RAND() function.", renderImageRange: "A1:C3");
                            categoryValsFormulas.AddEngineSample<ValuesFromArraySample>("Values From Array", "Set cell values from a two-dimensional object array.");
                            categoryValsFormulas.AddEngineSample<ArrayFormulaSample>("Array Formula", "Creates Array Formulas on both a single cell and range of cells.");
                            categoryValsFormulas.AddEngineSample<GoalSeekSample>("Goal Seek", "Achieve a specific goal from a calculated result using a simple iterative linear search. In this sample we find the loan amount based on a desired payment by entering the desired payment, interest rate and term.");
                            categoryValsFormulas.AddEngineSample<WhatIfDataTableSample>("What-If Data Table", "Creates a What-If Data Table to calculate various loan totals based on varying interest rates and terms.", renderImageRange: "A1:I13");
                        }

                        var categoryOperations = categoryRange.AddCategory("Operations", "Operations", "Demonstrates various operations that can be performed on ranges, such as AutoFilters, Sorting, Merging and more.");
                        {
                            categoryOperations.AddEngineSample<AutoFilterSample>("Auto Filter", "Use auto filters to view subsets of data in a worksheet. Ten examples are provided, each one executing a different type of criteria on its own worksheet.", false);
                            categoryOperations.AddEngineSample<LockAndProtectCellsSample>("Lock And Protect Cells", "Lock and unlock cells and enable worksheet protection on two worksheets, protecting with and without a password.", false);
                            categoryOperations.AddEngineSample<GroupAndOutlineSample>("Group And Outline", "Group and outline ranges of cells.", false);
                            categoryOperations.AddEngineSample<SortingSample>("Sorting", "Sort a range of data.");
                            categoryOperations.AddEngineSample<MergeCellsSample>("Merge Cells", "Merge a range of cells.", renderImageRange: "A1:F6");
                            categoryOperations.AddEngineSample<FillDataSeriesSample>("Fill Data Series", "Automatically fill cells with data.");
                        }
                    }
                }
            }

            var categoryCharting = explorerCategory.AddCategory("Charting", "Charting", "Richly formatted workbooks with fast and complete calculations are the heart and soul of a spreadsheet, but the ability to make good decisions is greatly enhanced by the ability to visualize data. Enhance your users' understanding of their data by taking advantage of SpreadsheetGear's comprehensive Excel compatible charting support.", 5);
            {
                if (includeWindowsSamples)
                {
                    categoryCharting.AddWindowsSample<ChartGallerySample>("Chart Gallery", "Dynamically create a chart gallery which demonstrates common chart types and formatting features.", false);
                }
                categoryCharting.AddEngineSample<ScatterChartSample>("Scatter Chart", "Demonstrates generating a Scatter Chart where x and y data sets are plotted on a single set of axes.");
                categoryCharting.AddEngineSample<BubbleChartSample>("Bubble Chart", "Create a bubble chart representing three sets of data values.", renderImageRange: "A1:J14");
                categoryCharting.AddEngineSample<RadarChartSample>("Radar Chart", "Use a radar chart to plot each category of data on a separate value axis.");
                categoryCharting.AddEngineSample<GanttChartSample>("Gantt Chart", "Use stacked bars and various formatting to simulate a gantt chart.", renderImageRange: "A1:J14");
                categoryCharting.AddEngineSample<CombinationChartSample>("Combination Chart", "Create a combination chart by utilizing multiple chart groups and multiple axes groups.", renderImageRange: "A1:K14");
                categoryCharting.AddEngineSample<EmbeddedPictureInChartSample>("Embedded Picture In Chart", "Demonstrates how to embed a picture into a chart, in this case to act as a replacement for the Chart Title.", renderImageRange: "A1:J16");
                categoryCharting.AddEngineSample<CreateChartSheetSample>("Create Chart Sheet", "Creates a ChartSheet and populates the chart with some data.", false);
                var categoryChartingBasic = categoryCharting.AddCategory("Basic", "Basic", "Samples demonstrating constructing basic chart types.");
                {
                    categoryChartingBasic.AddEngineSample<ColumnChartSample>("Column Chart", "Demonstrates generating a basic Column Chart.", renderImageRange: "A1:L14");
                    categoryChartingBasic.AddEngineSample<LineChartSample>("Line Chart", "Demonstrates generating a basic Line Chart.", renderImageRange: "A1:L14");
                    categoryChartingBasic.AddEngineSample<PieChartSample>("Pie Chart", "Demonstrates generating a basic Pie Chart.", renderImageRange: "A1:L14");
                    categoryChartingBasic.AddEngineSample<BarChartSample>("Bar Chart", "Demonstrates generating a basic Bar Chart.", renderImageRange: "A1:L14");
                    categoryChartingBasic.AddEngineSample<AreaChartSample>("Area Chart", "Demonstrates generating a basic Area Chart.", renderImageRange: "A1:L14");
                }
                var categoryChartingStock = categoryCharting.AddCategory("Stock", "Stock", "Samples demonstrating constructing a variety of stock charts.");
                {
                    categoryChartingStock.AddEngineSample<HLCStockChartSample>("H-L-C Stock Chart", "Demonstrates generating an H-L-C Stock Chart.");
                    categoryChartingStock.AddEngineSample<OHLCStockChartSample>("O-H-L-C Stock Chart", "Demonstrates generating an O-H-L-C Stock Chart.");
                    categoryChartingStock.AddEngineSample<VHLCStockChartSample>("V-H-L-C Stock Chart", "Demonstrates generating an V-H-L-C Stock Chart.");
                    categoryChartingStock.AddEngineSample<VOHLCStockChartSample>("V-O-H-L-C Stock Chart", "Demonstrates generating an V-O-H-L-C Stock Chart.");
                }
            }

            var categoryShapes = explorerCategory.AddCategory("Shapes", "Shapes", "");
            {
                var categoryFormControls = categoryShapes.AddCategory("Form Controls", "FormControls", "");
                {
                    categoryFormControls.AddEngineSample<ButtonSample>("Button", "Add a button to a worksheet. When attached to a WorkbookView, use the WorkbookView.ShapeAction(...) event to handle clicks on a button.", false);
                    categoryFormControls.AddEngineSample<CheckBoxSample>("CheckBox", "Add a checkbox to a worksheet and link its state to a cell.", false);
                    categoryFormControls.AddEngineSample<ComboBoxSample>("ComboBox", "Add a ComboBox to a worksheet, fill it with a range of values, and link it to a cell.", false);
                    categoryFormControls.AddEngineSample<ListBoxSample>("ListBox", "Add a ListBox to a worksheet, fill it with a range of values, and link it to a cell.", false);
                    categoryFormControls.AddEngineSample<SpinnerSample>("Spinner", "Add a checkbox to a worksheet and link its state to a cell.", false);
                    categoryFormControls.AddEngineSample<ScrollBarSample>("ScrollBar", "Demonstrates adding a ScrollBar control to a worksheet, linking its value to a cell, then setting its various options such as the amount to change the value when the up/down arrows are clicked or when the main scroll area is clicked. The linked cell is also linked to a chart series whose line will change in reaction to changes in the ScrollBar value.", false);
                    categoryFormControls.AddEngineSample<GroupBoxAndOptionButtonsSample>("GroupBox And OptionButtons", "Creates a GroupBox and series of OptionButtons that are linked to a cell. Also demonstrates adding these control relative to a range of cells--adding an OptionButton within each row of the provided range and surrounding all OptionButtons within a GroupBox.", false);
                }

                var categoryLines = categoryShapes.AddCategory("Lines", "Lines", "");
                {
                    categoryLines.AddEngineSample<LineWeightSample>("Line Weight", "Adds lines with various weights.", renderImageRange: "A1:G25");
                    categoryLines.AddEngineSample<LineDashStyleSample>("LineDashStyle", "Adds lines using all of the various dash styles defined in SpreadsheetGear.Shapes.LineDashStyle.", renderImageRange: "A1:H25");
                    categoryLines.AddEngineSample<ArrowheadsSample>("Arrowheads", "Adds lines using all of the various options defined in SpreadsheetGear.Shapes.ArrowheadStyle, ArrowheadLength and ArrowheadWidth.", renderImageRange: "A1:F10");
                }

                categoryShapes.AddEngineSample<PictureSample>("Picture", "Add a picture from an image file to a worksheet.", renderImageRange: "A1:L7");
                categoryShapes.AddEngineSample<TextBoxSample>("TextBox", "Add a textbox to a worksheet and set the text and font.", renderImageRange: "A1:F12");
                categoryShapes.AddEngineSample<AutoShapesSample>("Auto Shapes", "Add autoshapes to a worksheet and set the fill and line style.", renderImageRange: "A1:G12");
            }

            if (includeWindowsSamples)
            {
                var categoryCalculations = explorerCategory.AddCategory("Calculations", "Calculations", "The true power of SpreadsheetGear is realized when using its superior Microsoft Excel compatible calculation engine. Its unmatched performance and accuracy provide a competitive advantage to data-critical .NET applications. The following samples show various ways to utilize the spreadsheet calculation engine to manipulate data in a WPF project. These examples are easily adaptable to many Microsoft .NET project types.");
                {
                    categoryCalculations.AddWindowsSample<FormulaEvaluationSample>("Formula Evaluation", "Demonstrates evaluating a single Excel compatible formula entered into a WPF app.", false);
                    categoryCalculations.AddWindowsSample<SimpleLoanCalculatorSample>("Simple Loan Calculator", "Demonstrates calculating a loan payment based on input from a WPF app. By using this design pattern, you can easily deploy complex numeric, financial and statistics calculators which call on the full power of SpreadsheetGear's Microsoft Excel compatible calculation capabilities.", false);
                    categoryCalculations.AddWindowsSample<AmortizationCalculatorSample>("Amortization Calculator", "Extends the Simple Loan Calculator with an amortization table which is displayed in a WorkbookView control. Of particular interest is the use of the defined name, AmortizationTableForNPer, which uses the OFFSET() worksheet function to return a dynamically sized range.", true);
                    categoryCalculations.AddWindowsSample<CustomFunctionsSample>("Custom Functions", "Demonstrates creating your own custom functions in .NET and adding them to a workbook set. The worksheet formulas which utilize these custom functions are compatible with Microsoft Excel worksheet formulas which utilize VBA or XLL custom functions.", false);
                }

                var categoryPerformance = explorerCategory.AddCategory("Advanced", "Advanced", "Use advanced APIs and techniques for performance and scalability.");
                {
                    categoryPerformance.AddWindowsSample<PerformanceSample>("Performance", "Demonstrates a 1,773% performance improvement which is possible by using advanced API's and features for a typical case of filling and formatting rows of data.", true);
                    categoryPerformance.AddWindowsSample<ThreadingSample>("Threading", "Load data from background threads to simulate live data feeds.", true);
                }

                var categoryPrinting = explorerCategory.AddCategory("Printing", "Printing", "Print the contents of a workbook using basic and advanced options.");
                {
                    categoryPrinting.AddWindowsSample<BasicPrintingSample>("Basic", "Easily print and print preview selections, sheets, and entire workbooks.", true);
                    categoryPrinting.AddWindowsSample<PageSetupSample>("Page Setup", "Use page setup options to customize the printing of a worksheet.", true);
                    categoryPrinting.AddWindowsSample<PageBreaksSample>("Page Breaks", "Add or remove manual page breaks to customize printed page layouts.", true);
                }
            }

            var categoryReporting = explorerCategory.AddCategory("Reporting", "Reporting", "With the wide adoption of Microsoft Excel, there is no substitute for taking advantage of spreadsheet components in your .NET projects. You can use SpreadsheetGear to deliver spreadsheet reports in a variety of ways. The following samples show some basic ways to create spreadsheet content, which can be saved to Excel files, streamed as downloadable files in a browser, displayed in a SpreadsheetGear WPF or Windows Forms WorkbookView and more.");
            {
                categoryReporting.AddEngineSample<SimpleSpreadsheetSample>("Simple Spreadsheet", "Add values and simple formatting to a workbook.");
                categoryReporting.AddEngineSample<DataTableToWorkbookSample>("DataTable to Workbook", "Copy data from a DataTable to a workbook.");
                categoryReporting.AddEngineSample<DataSetToWorkbookSample>("DataSet to Workbook", "Insert data from multiple DataTables and merge this data with formatting and formulas from a template workbook.", false);
                categoryReporting.AddEngineSample<FormulasAndFormattingSample>("Formulas and Formatting", "Add values, formulas, defined names and formatting.");
                if (includeWindowsSamples)
                {
                    categoryReporting.AddWindowsSample<WorkbookConsolidationSample>("Workbook Consolidation", "Utilize the IRange.Copy method to dynamically copy and consolidate data from multiple workbooks.", true);
                }
            }

            if (includeWindowsSamples)
            {
                var categoryDataGrid = explorerCategory.AddCategory("Data Grid", "DataGrid", "Workbooks are an excellent source of data for the built-in DataGrid, DataSet and DataTable components included into .NET, as well as the many third party charting and other controls which accept a DataSet or DataTable. SpreadsheetGear makes it easy to populate a DataSet or DataTable from a workbook or worksheet range, as demonstrated by these samples.");
                {
                    categoryDataGrid.AddWindowsSample<SpreadsheetToDataGridSample>("Spreadsheet To DataGrid", "Retrieve data from a workbook and display it in a DataGridView control.", false);
                    categoryDataGrid.AddWindowsSample<SpreadsheetToDataGridFormattedSample>("Spreadsheet To DataGrid (Formatted)", "Insert data from a DataTable into a workbook, merging the data with formatting and formulas. The results are displayed in a DataGridView control.", false);
                }
            }

            return categoryRoot;
        }
    }


    public static class CategoryExtensions
    {
        /// <summary>
        /// Just adds simple type checking through generics to ensure expected type for sample  is used.
        /// </summary>
        public static void AddEngineSample<T>(this Category category, string sampleName, string description, bool canRenderImage = true, bool canDownloadFile = true, string renderImageRange = null)
            where T : ISpreadsheetGearEngineSample
        {
            var sampleInfo = category.AddSample<T>(sampleName, description, false);
            sampleInfo.CanRenderImage = canRenderImage;
            sampleInfo.CanDownloadFile = canDownloadFile;
            sampleInfo.RenderImageRange = renderImageRange;
            sampleInfo.AddSourceCode($"{typeof(T).Name}.code.cs");
        }

        /// <summary>
        /// Just adds simple type checking through generics to ensure expected type for sample is used.
        /// </summary>
        /// <param name="usesWorkbookView">Indicates whether the execution of this sample depends on the presence of a WorkbookView control. This 
        /// information can be used by the samples app UI to display different icons representing the sample.</param>
        public static void AddWindowsSample<T>(this Category category, string sampleName, string description, bool usesWorkbookView)
            where T : ISpreadsheetGearWindowsSample
        {
            var sampleInfo = category.AddSample<T>(sampleName, description, usesWorkbookView);
            sampleInfo.AddSourceCode($"{typeof(T).Name}.code.cs");
        }
    }
}