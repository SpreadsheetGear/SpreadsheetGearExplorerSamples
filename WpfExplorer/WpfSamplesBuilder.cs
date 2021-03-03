/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SharedSamples;
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
        ///  Adds a handful of samples that directly depend on the WPF WorkbookView implementation and so cannot use shared code like the <see cref="SharedWindowsSample"/> samples.
        /// </summary>
        public static void Build(Category rootCategory)
        {
            var explorerSamples = rootCategory.GetCategory("SpreadsheetGear Explorer Samples");
            var categoryWbvSamples = explorerSamples.GetCategory("WorkbookView");
            {
                var categoryEvents = categoryWbvSamples.AddCategory("Events", "Events", "Handle some of the available WorkbookView events.");
                {
                    categoryEvents.AddWpfSample<CalculateSample>("Calculate", "Retrieve a date/time value from a cell after calculating.");
                    categoryEvents.AddWpfSample<CellBeginEditSample>("CellBeginEdit", "Change the initial edit entry or cancel the edit.");
                    categoryEvents.AddWpfSample<CellEndEditSample>("CellEndEdit", "Custom validation of user input.");
                    categoryEvents.AddWpfSample<RangeChangedSample>("RangeChanged", "Display information about a changed range.");
                    categoryEvents.AddWpfSample<RangeSelectionChangedSample>("RangeSelectionChanged", "Display information about the current range selection.");
                    categoryEvents.AddWpfSample<ShapeSelectionChangedSample>("ShapeSelectionChanged", "Display information about the current shape selection.");
                    categoryEvents.AddWpfSample<ActiveTabChangedSample>("ActiveTabChanged", "Display information about the active tab.");
                    categoryEvents.AddWpfSample<ShapeActionSample>("ShapeAction", "Handle a built-in form control click event.");
                    categoryEvents.AddWpfSample<ShowErrorSample>("ShowError", "Change or bypass default error message handling.");
                }

                var categoryStyling = categoryWbvSamples.AddCategory("Styling", "Styling", "Use WPF Control Templates and other features to customize how the WorkbookView appears, and change the content of Row / Column Header area.");
                {
                    categoryStyling.AddWpfSample<SimpleStyleSample>("Simple Style", "Basic styling sample.");
                    categoryStyling.AddWpfSample<ExcelThemeSample>("Excel Theme", "Theme the WorkbookView with an Excel-like theme.");
                    categoryStyling.AddWpfSample<CustomHeadersSample>("Custom Headers", "Custom headers using data binding.");
                    categoryStyling.AddWpfSample<ColumnHeaderSortSample>("ColumnHeader Sort", "Sort by clicking on a custom ColumnHeader.");
                }

                var categoryUIManager = categoryWbvSamples.AddCategory("UIManager", "UIManager", "Extensions to the default UI Manager framework.");
                {
                    categoryUIManager.AddWpfSample<CustomControlSample>("Custom Control", "Replace an existing IShape with your own custom control.");
                }
            }

            explorerSamples.GetCategory("Printing").AddWpfSample<AdvancedPrintingSample>("Advanced", "Use advanced techniques to print specific areas of a workbook.");            

            AddWpfSourceCodeFiles(explorerSamples);
        }


        /// <summary>
        /// Adds *.xaml and *.xaml.cs source code files to any samples that involve WPF.
        /// </summary>
        /// <param name="category"></param>
        public static void AddWpfSourceCodeFiles(Category category)
        {
            var targetType1 = typeof(SharedWindowsSample);
            var targetType2 = typeof(SGUserControl);
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
        public static void AddWpfSample<T>(this Category category, string sampleName, string description)
            where T : SGUserControl
        {
            category.AddSample<T>(sampleName, description);
        }
    }
}
