﻿using System;
using System.Collections.Generic;

namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class CultureInfoSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Windows.Samples.WorkbookView.CultureInfoSample Sample { get; private set; }

        private void ButtonRunSample_Click(object sender, EventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookViews.  Disposal of 
            /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
            /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
            /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
            /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
            DisposalManager.ResetWorkbookView(workbookViewDeDE, false);
            DisposalManager.ResetWorkbookView(workbookViewSelectedCulture, false);

            Sample.RunSample(workbookViewDeDE, workbookViewSelectedCulture, (string)listBoxCultures.SelectedItem);

            labelSelectedCulture.Text = $"Selected Culture ({listBoxCultures.SelectedItem})";
        }

        #region Sample Initialization Code
        public CultureInfoSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Windows.Samples.WorkbookView.CultureInfoSample();
            DisposalManager.RegisterWorkbookViews(workbookViewDeDE, workbookViewSelectedCulture);

            // Get all cultures and populate ListBox with them
            List<string> cultures = Sample.GetAllCultures();
            listBoxCultures.DataSource = cultures;
            listBoxCultures.SelectedIndex = 0;

            splitContainer2.SplitterDistance = splitContainer2.Parent.Width / 2;
        }
        #endregion
    }
}
