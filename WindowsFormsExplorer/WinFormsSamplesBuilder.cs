/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SharedSamples;
using System.Linq;
using WindowsFormsExplorer.Samples.Printing;
using WindowsFormsExplorer.Samples.WorkbookView.Events;
using WindowsFormsExplorer.Samples.WorkbookView.UIManager;

namespace WindowsFormsExplorer
{
    /// <summary>
    /// Adds a handful of samples that directly depend on the Windows Forms WorkbookView implementation and so cannot use shared code like the <see cref="SharedWindowsSample"/> samples.
    /// </summary>
    public class WinFormsSamplesBuilder
    {
        public static void Build(Category rootCategory)
        {
            var explorerSamples = rootCategory.GetCategory("SpreadsheetGear Explorer Samples");
            var categoryWbvSamples = explorerSamples.GetCategory("WorkbookView");
            {
                var categoryEvents = categoryWbvSamples.AddCategory("Events", "Events", "Handle some of the available WorkbookView events.");
                {
                    categoryEvents.AddWinFormsSample<CalculateSample>("Calculate", "Retrieve a date/time value from a cell after calculating.");
                    categoryEvents.AddWinFormsSample<CellBeginEditSample>("CellBeginEdit", "Change the initial edit entry or cancel the edit.");
                    categoryEvents.AddWinFormsSample<CellEndEditSample>("CellEndEdit", "Custom validation of user input.");
                    categoryEvents.AddWinFormsSample<RangeChangedSample>("RangeChanged", "Display information about a changed range.");
                    categoryEvents.AddWinFormsSample<RangeSelectionChangedSample>("RangeSelectionChanged", "Display information about the current range selection.");
                    categoryEvents.AddWinFormsSample<ShapeSelectionChangedSample>("ShapeSelectionChanged", "Display information about the current shape selection.");
                    categoryEvents.AddWinFormsSample<ActiveTabChangedSample>("ActiveTabChanged", "Display information about the active tab.");
                    categoryEvents.AddWinFormsSample<ShapeActionSample>("ShapeAction", "Handle a built-in form control click event.");
                    categoryEvents.AddWinFormsSample<ShowErrorSample>("ShowError", "Change or bypass default error message handling.");
                }

                var categoryUIManager = categoryWbvSamples.AddCategory("UIManager", "UIManager", "Extensions to the default UI Manager framework.");
                {
                    var customControlSampleInfo = categoryUIManager.AddWinFormsSample<CustomControlSample>("Custom Control", "Replace an existing IShape with your own custom control.");
                    customControlSampleInfo.AddSourceCode("MyUIManager.cs");
                }
            }

            var printingSampleInfo = explorerSamples.GetCategory("Printing").AddWinFormsSample<AdvancedPrintingSample>("Advanced", "Use advanced techniques to print specific areas of a workbook.");
            printingSampleInfo.AddSourceCode("CustomPrintPreviewDialog.cs");

            AddWinFormsSourceCodeFiles(explorerSamples);
        }

        /// <summary>
        /// Adds *.cs source code files to any samples that involve WinForms.
        /// </summary>
        /// <param name="category"></param>
        public static void AddWinFormsSourceCodeFiles(Category category)
        {
            var targetTypeSharedWinSample = typeof(SharedWindowsSample);
            var targetTypeSGUserControl = typeof(SGUserControl);
            foreach (var sample in category.SampleInfos.Where(i =>
                targetTypeSharedWinSample.IsAssignableFrom(i.SampleType) || targetTypeSGUserControl.IsAssignableFrom(i.SampleType)))
            {
                sample.AddSourceCode($"{sample.SampleType.Name}.cs");
            }
            foreach (var subCategory in category.ChildCategories)
            {
                AddWinFormsSourceCodeFiles(subCategory);
            }
        }
    }


    public static class CategoryExtensions
    {
        /// <summary>
        /// Just adds simple type checking through generics to ensure expected type for sample is used.
        /// </summary>
        public static SampleInfo AddWinFormsSample<T>(this Category category, string sampleName, string description)
            where T : SGUserControl
        {
            var sampleInfo = category.AddSample<T>(sampleName, description);
            return sampleInfo;
        }
    }
}
