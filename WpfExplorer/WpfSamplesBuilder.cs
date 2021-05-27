/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using WPFExplorer.Samples.Printing;
using WPFExplorer.Samples.WorkbookView.Events;
using WPFExplorer.Samples.WorkbookView.UIManager;
using WPFExplorer.Samples.WorkbookView.Styling;
using System.Linq;

namespace WPFExplorer
{
    public class WpfSamplesBuilder
    {
        /// <summary>
        ///  Adds a handful of samples that directly depend on the WPF WorkbookView implementation and so cannot use shared code like the <see cref="ISpreadsheetGearWindowsSample"/> samples.
        /// </summary>
        public static void Build(Category rootCategory)
        {
            var explorerSamples = rootCategory.GetCategory("SpreadsheetGear Explorer Samples");
            var categoryWbvSamples = explorerSamples.GetCategory("WorkbookView");
            {
                var categoryEvents = categoryWbvSamples.AddCategory("Events", "Events", "Handle some of the available WorkbookView events.");
                {
                    categoryEvents.AddWpfSample<CalculateSample>("Calculate", "Retrieve a date/time value from a cell after calculating.", true);
                    categoryEvents.AddWpfSample<CellBeginEditSample>("CellBeginEdit", "Change the initial edit entry or cancel the edit.", true);
                    categoryEvents.AddWpfSample<CellEndEditSample>("CellEndEdit", "Custom validation of user input.", true);
                    categoryEvents.AddWpfSample<RangeChangedSample>("RangeChanged", "Display information about a changed range.", true);
                    categoryEvents.AddWpfSample<RangeSelectionChangedSample>("RangeSelectionChanged", "Display information about the current range selection.", true);
                    categoryEvents.AddWpfSample<ShapeSelectionChangedSample>("ShapeSelectionChanged", "Display information about the current shape selection.", true);
                    categoryEvents.AddWpfSample<ActiveTabChangedSample>("ActiveTabChanged", "Display information about the active tab.", true);
                    categoryEvents.AddWpfSample<ShapeActionSample>("ShapeAction", "Handle a built-in form control click event.", true);
                    categoryEvents.AddWpfSample<ShowErrorSample>("ShowError", "Change or bypass default error message handling.", true);
                }

                var categoryStyling = categoryWbvSamples.AddCategory("Styling", "Styling", "Use WPF Control Templates and other features to customize how the WorkbookView appears, and change the content of Row / Column Header area.");
                {
                    categoryStyling.AddWpfSample<SimpleStyleSample>("Simple Style", "Basic styling sample.", true);
                    categoryStyling.AddWpfSample<ExcelThemeSample>("Excel Theme", "Theme the WorkbookView with an Excel-like theme.", true);
                    categoryStyling.AddWpfSample<CustomHeadersSample>("Custom Headers", "Custom headers using data binding.", true);
                    categoryStyling.AddWpfSample<ColumnHeaderSortSample>("ColumnHeader Sort", "Sort by clicking on a custom ColumnHeader.", true);
                }

                var categoryUIManager = categoryWbvSamples.AddCategory("UIManager", "UIManager", "Extensions to the default UI Manager framework.");
                {
                    categoryUIManager.AddWpfSample<CustomControlSample>("Custom Control", "Replace an existing IShape with your own custom control.", true);
                }
            }

            explorerSamples.GetCategory("Printing").AddWpfSample<AdvancedPrintingSample>("Advanced", "Use advanced techniques to print specific areas of a workbook.", true);

            AddWpfSourceCodeFiles(explorerSamples);
        }


        /// <summary>
        /// Adds *.xaml and *.xaml.cs source code files to any samples that involve WPF.
        /// </summary>
        /// <param name="category"></param>
        public static void AddWpfSourceCodeFiles(Category category)
        {
            var targetType1 = typeof(ISpreadsheetGearWindowsSample);
            var targetType2 = typeof(SampleUserControl);
            foreach (var sample in category.SampleInfos.Where(i => targetType1.IsAssignableFrom(i.SampleType) ||
                targetType2.IsAssignableFrom(i.SampleType)))
            {
                sample.AddSourceCode($"{sample.SampleType.Name}.xaml.cs");
                sample.AddSourceCode($"{sample.SampleType.Name}.xaml");
            }
            foreach (var subCategory in category.ChildCategories)
            {
                AddWpfSourceCodeFiles(subCategory);
            }
        }
    }


    public static class CategoryExtensions
    {
        /// <summary>
        /// Just adds simple type checking through generics to ensure expected type for sample is used.
        /// </summary>
        public static void AddWpfSample<T>(this Category category, string sampleName, string description, bool usesWorkbookView)
            where T : SampleUserControl
        {
            category.AddSample<T>(sampleName, description, usesWorkbookView);
        }
    }
}
