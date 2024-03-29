﻿namespace WPFExplorer.Samples.Printing
{
    public partial class PageBreaksSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Windows.Samples.Printing.PageBreaksSample Sample { get; private set; }

        private void ButtonPrint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Run the sample.
            Sample.Print(workbookView, radioButtonRegion.IsChecked == true);
        }

        #region Sample Initialization Code
        public PageBreaksSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);
            Sample = new SamplesLibrary.Windows.Samples.Printing.PageBreaksSample();
            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
