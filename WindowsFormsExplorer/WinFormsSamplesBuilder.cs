/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using System.Linq;
using WindowsFormsExplorer.Samples.Printing;
using WindowsFormsExplorer.Samples.WorkbookView.Events;
using WindowsFormsExplorer.Samples.WorkbookView.UIManager;

namespace WindowsFormsExplorer
{
    /// <summary>
    /// Adds a handful of samples that directly depend on the Windows Forms WorkbookView implementation and so cannot use shared code like the <see cref="ISpreadsheetGearWindowsSample"/> samples.
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
                    categoryEvents.AddWinFormsSample<CalculateSample>("Calculate", "Retrieve a date/time value from a cell after calculating.", true);
                    categoryEvents.AddWinFormsSample<CellBeginEditSample>("CellBeginEdit", "Change the initial edit entry or cancel the edit.", true);
                    categoryEvents.AddWinFormsSample<CellEndEditSample>("CellEndEdit", "Custom validation of user input.", true);
                    categoryEvents.AddWinFormsSample<RangeChangedSample>("RangeChanged", "Display information about a changed range.", true);
                    categoryEvents.AddWinFormsSample<RangeSelectionChangedSample>("RangeSelectionChanged", "Display information about the current range selection.", true);
                    categoryEvents.AddWinFormsSample<ShapeSelectionChangedSample>("ShapeSelectionChanged", "Display information about the current shape selection.", true);
                    categoryEvents.AddWinFormsSample<ActiveTabChangedSample>("ActiveTabChanged", "Display information about the active tab.", true);
                    categoryEvents.AddWinFormsSample<ShapeActionSample>("ShapeAction", "Handle a built-in form control click event.", true);
                    categoryEvents.AddWinFormsSample<ShowErrorSample>("ShowError", "Change or bypass default error message handling.", true);
                }

                var categoryUIManager = categoryWbvSamples.AddCategory("UIManager", "UIManager", "Extensions to the default UI Manager framework.");
                {
                    var customControlSampleInfo = categoryUIManager.AddWinFormsSample<CustomControlSample>("Custom Control", "Replace an existing IShape with your own custom control.", true);
                    customControlSampleInfo.AddSourceCode("MyUIManager.cs");
                }
            }

            var printingSampleInfo = explorerSamples.GetCategory("Printing").AddWinFormsSample<AdvancedPrintingSample>("Advanced", "Use advanced techniques to print specific areas of a workbook.", true);
            printingSampleInfo.AddSourceCode("CustomPrintPreviewDialog.cs");

            AddWinFormsSourceCodeFiles(explorerSamples);
        }

        /// <summary>
        /// Adds *.cs source code files to any samples that involve WinForms.
        /// </summary>
        /// <param name="category"></param>
        public static void AddWinFormsSourceCodeFiles(Category category)
        {
            var targetTypeWinSample = typeof(ISpreadsheetGearWindowsSample);
            var targetTypeSampleUserControl = typeof(SampleUserControl);
            foreach (var sample in category.SampleInfos.Where(i =>
                targetTypeWinSample.IsAssignableFrom(i.SampleType) || targetTypeSampleUserControl.IsAssignableFrom(i.SampleType)))
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
        /// <param name="usesWorkbookView">Indicates whether the execution of this sample depends on the presence of a WorkbookView control. This 
        /// information can be used by the samples app UI to display different icons representing the sample.</param>
        public static SampleInfo AddWinFormsSample<T>(this Category category, string sampleName, string description, bool usesWorkbookView)
            where T : SampleUserControl
        {
            var sampleInfo = category.AddSample<T>(sampleName, description, usesWorkbookView);
            return sampleInfo;
        }
    }
}
