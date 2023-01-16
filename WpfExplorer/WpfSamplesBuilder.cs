/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using SamplesLibrary.Windows;
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
        public static Category Build()
        {
            // Build the shared categories and SpreadsheetGear Engine and Windows samples.
            var rootCategory = WindowsSamplesBuilder.Build();

            // Intermix in the WPF-specific samples.
            var explorerSamples = rootCategory.GetCategory("SpreadsheetGear Explorer Samples");
            var categoryWbvSamples = explorerSamples.GetCategory("WorkbookView");
            {
                var categoryEvents = categoryWbvSamples.AddCategory("Events", "Events", "Handle some of the available WorkbookView events.", 30);
                {
                    categoryEvents.AddWpfSample<CalculateSample>("Calculate", "Retrieve a date/time value from a cell after calculating.", 10, true);
                    categoryEvents.AddWpfSample<CellBeginEditSample>("CellBeginEdit", "Change the initial edit entry or cancel the edit.", 20, true);
                    categoryEvents.AddWpfSample<CellEndEditSample>("CellEndEdit", "Custom validation of user input.", 30, true);
                    categoryEvents.AddWpfSample<RangeChangedSample>("RangeChanged", "Display information about a changed range.", 40, true);
                    categoryEvents.AddWpfSample<RangeSelectionChangedSample>("RangeSelectionChanged", "Display information about the current range selection.", 50, true);
                    categoryEvents.AddWpfSample<ShapeSelectionChangedSample>("ShapeSelectionChanged", "Display information about the current shape selection.", 60, true);
                    categoryEvents.AddWpfSample<ActiveTabChangedSample>("ActiveTabChanged", "Display information about the active tab.", 70, true);
                    categoryEvents.AddWpfSample<ShapeActionSample>("ShapeAction", "Handle a built-in form control click event.", 80, true);
                    categoryEvents.AddWpfSample<ShowErrorSample>("ShowError", "Change or bypass default error message handling.", 90, true);
                }

                var categoryStyling = categoryWbvSamples.AddCategory("Styling", "Styling", "Use WPF Control Templates and other features to customize how the WorkbookView appears, and change the content of Row / Column Header area.", 40);
                {
                    categoryStyling.AddWpfSample<SimpleStyleSample>("Simple Style", "Basic styling sample.", 10, true);
                    categoryStyling.AddWpfSample<ExcelThemeSample>("Excel Theme", "Theme the WorkbookView with an Excel-like theme.", 20, true);
                    categoryStyling.AddWpfSample<CustomHeadersSample>("Custom Headers", "Custom headers using data binding.", 30, true);
                    categoryStyling.AddWpfSample<ColumnHeaderSortSample>("ColumnHeader Sort", "Sort by clicking on a custom ColumnHeader.", 40, true);
                }

                var categoryUIManager = categoryWbvSamples.AddCategory("UIManager", "UIManager", "Extensions to the default UI Manager framework.", 50);
                {
                    categoryUIManager.AddWpfSample<CustomControlSample>("Custom Control", "Replace an existing IShape with your own custom control.", 10, true);
                }
            }

            explorerSamples.GetCategory("Printing").AddWpfSample<AdvancedPrintingSample>("Advanced", "Use advanced techniques to print specific areas of a workbook.", 40, true);

            AddWpfSourceCodeFiles(explorerSamples);

            return rootCategory;
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
        public static void AddWpfSample<T>(this Category category, string sampleName, string description, int sortIndex, bool usesWorkbookView)
            where T : SampleUserControl
        {
            category.AddSample<T>(sampleName, description, sortIndex, usesWorkbookView);
        }
    }
}
