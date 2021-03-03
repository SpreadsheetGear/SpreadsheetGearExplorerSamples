/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SharedSamples;
using System.Windows;

namespace WPFExplorer
{
    /// <summary>
    /// This UserControl is used to host and execute all samples that implement <see cref="SharedEngineSample"/>.
    /// </summary>
    public partial class EngineSampleControl : SGUserControl
    {
        public SharedEngineSample EngineSample { get; private set; }

        public EngineSampleControl(SharedEngineSample engineSample) : this()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            EngineSample = engineSample;
            InitializeSample();
        }


        public EngineSampleControl()
        {
            InitializeComponent();
        }


        private void InitializeSample()
        {
            DisposalManager.ResetWorkbookView(workbookView, false);
            EngineSample.PreLoadWorkbook();
            workbookView.ActiveWorkbook = EngineSample.Workbook;
            button_runSample.IsEnabled = true;
        }


        private void button_runSample_Click(object sender, RoutedEventArgs e)
        {
            workbookView.GetLock();
            try
            {
                EngineSample.RunSample();
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
