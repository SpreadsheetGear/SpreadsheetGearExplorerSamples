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
    /// This UserControl is used to host and execute all samples that implement <see cref="SharedEngineSample"/>.
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
            DisposalManager.ResetWorkbookView(workbookView, false);
            SpreadsheetGearEngineSample.InitializeWorkbook();
            workbookView.ActiveWorkbook = SpreadsheetGearEngineSample.Workbook;
            button_runSample.IsEnabled = true;
        }


        private void button_runSample_Click(object sender, RoutedEventArgs e)
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
            button_runSample.IsEnabled = false;
        }


        private void button_resetSample_Click(object sender, RoutedEventArgs e)
        {
            InitializeSample();
        }
    }
}
