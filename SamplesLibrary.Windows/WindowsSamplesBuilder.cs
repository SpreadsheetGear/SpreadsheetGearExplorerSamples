/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary.Engine;
using SamplesLibrary.Windows.Samples.Advanced;
using SamplesLibrary.Windows.Samples.Calculations;
using SamplesLibrary.Windows.Samples.Charting;
using SamplesLibrary.Windows.Samples.DataGrid;
using SamplesLibrary.Windows.Samples.Printing;
using SamplesLibrary.Windows.Samples.Reporting;
using SamplesLibrary.Windows.Samples.WorkboookView.CommandManager;
using SamplesLibrary.Windows.Samples.WorkboookView.DisplayOptions;
using SamplesLibrary.Windows.Samples.WorkboookView;

namespace SamplesLibrary.Windows
{
    public class WindowsSamplesBuilder
    {
        public static Category Build()
        {
            var categoryRoot = SamplesBuilder.Build();
            var explorerCategory = categoryRoot.ChildCategories.Single();

            var categoryWbvSamples = explorerCategory.AddCategory("WorkbookView", "WorkbookView", "WorkbookView properties, methods, designer, explorers, display options, and events.", 10);
            {
                categoryWbvSamples.AddWindowsSample<ActiveWorkbookSample>("Active Workbook", "Create or open workbooks from a variety of locations (Disk, Uri, memory stream, byte array).", 10, true);
                categoryWbvSamples.AddWindowsSample<ActiveWorksheetSample>("Active Worksheet", "Add multiple worksheets to a workbook and display a new worksheet.", 20, true);
                categoryWbvSamples.AddWindowsSample<CultureInfoSample>("CultureInfo", "Specify a CultureInfo to be used for various regional formatting conventions such as date formats, list separator, decimal separator, currency symbol and more.  This sample creates a workbook with the German ('de-DE') CultureInfo, saves the workbook to disk, and re-opens it in the selected CultureInfo to demonstrate changes in locale-senstive formats.", 30, true);
                categoryWbvSamples.AddWindowsSample<DesignerAndExplorerDialogsSample>("Designer and Explorer Dialogs", "Show the Workbook Designer, Workbook Explorer, Range Explorer, Chart Explorer, and Shape Explorer.", 40, true);
                categoryWbvSamples.AddWindowsSample<LocationToRangeSample>("Location To Range", "Use the LocationToRange method from a mouse event.", 50, true);

                var categoryDisplayOptions = categoryWbvSamples.AddCategory("Display Options", "DisplayOptions", "Use display properties to customize the presentation of workbooks.", 10);
                {
                    categoryDisplayOptions.AddWindowsSample<DisplayReferenceSample>("DisplayReference", "Use the DisplayReference property to set the viewable area of a workbook.", 10, true);
                    categoryDisplayOptions.AddWindowsSample<WorkbookWindowInfoSample>("WorkbookWindowInfo", "Show and hide scroll bars and workbook tabs.", 20, true);
                    categoryDisplayOptions.AddWindowsSample<WorksheetWindowInfoSample>("WorksheetWindowInfo", "Freeze panes, set gridline color, show and hide headings, and zoom.", 30, true);
                }

                var categoryCommandManager = categoryWbvSamples.AddCategory("CommandManager", "CommandManager", "Extensions to the default command framework.", 20);
                {
                    categoryCommandManager.AddWindowsSample<SimpleCommandSample>("Simple Command", "Create and execute a simple undoable command.", 10, true);
                    categoryCommandManager.AddWindowsSample<CommandRangeSample>("Command Range", "Create and execute a CommandRange that sets a range interior color and provides built-in undoable capabilities to restore the interior color without the need for your command to keep track of its own state.", 20, true);
                }
            }

            var categoryCharting = explorerCategory.GetCategory("Charting");
            {
                categoryCharting.AddWindowsSample<ChartGallerySample>("Chart Gallery", "Dynamically create a chart gallery which demonstrates common chart types and formatting features.", 10, false);
            }

            var categoryCalculations = explorerCategory.AddCategory("Calculations", "Calculations", "The true power of SpreadsheetGear is realized when using its superior Microsoft Excel compatible calculation engine. Its unmatched performance and accuracy provide a competitive advantage to data-critical .NET applications. The following samples show various ways to utilize the spreadsheet calculation engine to manipulate data in a WPF project. These examples are easily adaptable to many Microsoft .NET project types.", 50);
            {
                categoryCalculations.AddWindowsSample<FormulaEvaluationSample>("Formula Evaluation", "Demonstrates evaluating a single Excel compatible formula entered into a WPF app.", 10, false);
                categoryCalculations.AddWindowsSample<SimpleLoanCalculatorSample>("Simple Loan Calculator", "Demonstrates calculating a loan payment based on input from a WPF app. By using this design pattern, you can easily deploy complex numeric, financial and statistics calculators which call on the full power of SpreadsheetGear's Microsoft Excel compatible calculation capabilities.", 20, false);
                categoryCalculations.AddWindowsSample<AmortizationCalculatorSample>("Amortization Calculator", "Extends the Simple Loan Calculator with an amortization table which is displayed in a WorkbookView control. Of particular interest is the use of the defined name, AmortizationTableForNPer, which uses the OFFSET() worksheet function to return a dynamically sized range.", 30, true);
                categoryCalculations.AddWindowsSample<CustomFunctionsSample>("Custom Functions", "Demonstrates creating your own custom functions in .NET and adding them to a workbook set. The worksheet formulas which utilize these custom functions are compatible with Microsoft Excel worksheet formulas which utilize VBA or XLL custom functions.", 40, false);
            }

            var categoryPerformance = explorerCategory.AddCategory("Advanced", "Advanced", "Use advanced APIs and techniques for performance and scalability.", 60);
            {
                categoryPerformance.AddWindowsSample<PerformanceSample>("Performance", "Demonstrates a 1,773% performance improvement which is possible by using advanced API's and features for a typical case of filling and formatting rows of data.", 10, true);
                categoryPerformance.AddWindowsSample<ThreadingSample>("Threading", "Load data from background threads to simulate live data feeds.", 20, true);
            }

            var categoryPrinting = explorerCategory.AddCategory("Printing", "Printing", "Print the contents of a workbook using basic and advanced options.", 70);
            {
                categoryPrinting.AddWindowsSample<BasicPrintingSample>("Basic", "Easily print and print preview selections, sheets, and entire workbooks.", 10, true);
                categoryPrinting.AddWindowsSample<PageSetupSample>("Page Setup", "Use page setup options to customize the printing of a worksheet.", 20, true);
                categoryPrinting.AddWindowsSample<PageBreaksSample>("Page Breaks", "Add or remove manual page breaks to customize printed page layouts.", 30, true);
            }

            var categoryReporting = explorerCategory.GetCategory("Reporting");
            {
                categoryReporting.AddWindowsSample<WorkbookConsolidationSample>("Workbook Consolidation", "Utilize the IRange.Copy method to dynamically copy and consolidate data from multiple workbooks.", 50, true);
            }

            var categoryDataGrid = explorerCategory.AddCategory("Data Grid", "DataGrid", "Workbooks are an excellent source of data for the built-in DataGrid, DataSet and DataTable components included into .NET, as well as the many third party charting and other controls which accept a DataSet or DataTable. SpreadsheetGear makes it easy to populate a DataSet or DataTable from a workbook or worksheet range, as demonstrated by these samples.", 90);
            {
                categoryDataGrid.AddWindowsSample<SpreadsheetToDataGridSample>("Spreadsheet To DataGrid", "Retrieve data from a workbook and display it in a DataGridView control.", 10, false);
                categoryDataGrid.AddWindowsSample<SpreadsheetToDataGridFormattedSample>("Spreadsheet To DataGrid (Formatted)", "Insert data from a DataTable into a workbook, merging the data with formatting and formulas. The results are displayed in a DataGridView control.", 20, false);
            }

            return categoryRoot;
        }
    }

    public static class CategoryExtensions
    {
        /// <summary>
        /// Just adds simple type checking through generics to ensure expected type for sample is used.
        /// </summary>
        /// <param name="usesWorkbookView">Indicates whether the execution of this sample depends on the presence of a WorkbookView control. This 
        /// information can be used by the samples app UI to display different icons representing the sample.</param>
        public static void AddWindowsSample<T>(this Category category, string sampleName, string description, int sortIndex, bool usesWorkbookView)
            where T : ISpreadsheetGearWindowsSample
        {
            var sampleInfo = category.AddSample<T>(sampleName, description, sortIndex, usesWorkbookView);
            sampleInfo.AddSourceCode($"{typeof(T).Name}.code.cs");
        }
    }
}
