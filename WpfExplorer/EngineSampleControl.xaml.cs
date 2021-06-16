/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using System.Windows;

namespace WPFExplorer
{
    /// <summary>
    /// This UserControl is used to host and execute all samples that implement <see cref="ISpreadsheetGearEngineSample"/>.
    /// </summary>
    public partial class EngineSampleControl : SampleUserControl
    {
        public ISpreadsheetGearEngineSample SpreadsheetGearEngineSample { get; private set; }

        public EngineSampleControl(ISpreadsheetGearEngineSample engineSample) : this()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            SpreadsheetGearEngineSample = engineSample;
            InitializeSample();
        }

        public EngineSampleControl()
        {
            InitializeComponent();
        }

        private void InitializeSample()
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView.  Disposal of 
            /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
            /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
            /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
            /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
            DisposalManager.ResetWorkbookView(workbookView, false);

            SpreadsheetGearEngineSample.InitializeWorkbook();
            workbookView.ActiveWorkbook = SpreadsheetGearEngineSample.Workbook;
            buttonRunSample.IsEnabled = true;
        }

        private void ButtonRunSample_Click(object sender, RoutedEventArgs e)
        {
            workbookView.GetLock();
            try
            {
                SpreadsheetGearEngineSample.RunSample();
            }
            finally
            {
                workbookView.ReleaseLock();
            }
            buttonRunSample.IsEnabled = false;
        }

        private void ButtonResetSample_Click(object sender, RoutedEventArgs e)
        {
            InitializeSample();
        }
    }
}
