namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class ActiveWorksheetSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.ActiveWorksheetSample Sample { get; private set; }

        private void ButtonRunSample_Click(object sender, System.EventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView and sets it 
            /// up with a new workbook.  Disposal of old workbooks is necessary when using SpreadsheetGear in the "Free" mode,
            /// which has a 3 workbook limit.  If you are copying and pasting this sample code to your own projects and have a
            /// Signed License that activates either the fully-licensed or 30-day evaluation mode of the software, then this
            /// workbook disposal strategy is not needed. See the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> 
            /// code file for more details.
            DisposalManager.ResetWorkbookView(workbookView);

            // Run the sample.
            Sample.SetActiveWorksheet(workbookView);
        }

        #region Sample Initialization Code
        public ActiveWorksheetSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.ActiveWorksheetSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
