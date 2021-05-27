/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using System;

namespace WindowsFormsExplorer
{
    /// <summary>
    /// This UserControl is used to host and execute all samples that implement <see cref="SharedEngineSample"/>.
    /// </summary>
    public partial class EngineSampleControl : SampleUserControl
    {
        public ISpreadsheetGearEngineSample EngineSample { get; private set; }

        public EngineSampleControl(ISpreadsheetGearEngineSample engineSample) : this()
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
            EngineSample.InitializeWorkbook();
            workbookView.ActiveWorkbook = EngineSample.Workbook;
            button_runSample.Enabled = true;
        }

        private void button_runSample_Click(object sender, EventArgs e)
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
            button_runSample.Enabled = false;
        }

        private void button_resetSample_Click(object sender, EventArgs e)
        {
            InitializeSample();
        }
    }
}
