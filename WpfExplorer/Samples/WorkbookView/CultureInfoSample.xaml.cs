using System.Collections.Generic;

namespace WPFExplorer.Samples.WorkbookView
{
    public partial class CultureInfoSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WPFExplorer samples app as
        // well as the WindowsFormsExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.CultureInfoSample Sample { get; private set; }

        private void button_runSample_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookViews.  Disposal of 
            /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
            /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
            /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
            /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
            DisposalManager.ResetWorkbookView(workbookView_deDE, false);
            DisposalManager.ResetWorkbookView(workbookView_selectedCulture, false);

            // Run the sample.
            Sample.RunSample(workbookView_deDE, workbookView_selectedCulture, (string)listBox_cultures.SelectedItem);
            label_selectedCulture.Content = $"Selected Culture ({listBox_cultures.SelectedItem})";
        }


        #region Sample Initialization Code
        public CultureInfoSample()
        {
            InitializeComponent();
            InitializeSample();
        }
        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.CultureInfoSample();
            DisposalManager.RegisterWorkbookViews(workbookView_deDE, workbookView_selectedCulture);

            // Get all cultures and populate ListBox with them
            List<string> cultures = Sample.GetAllCultures();
            listBox_cultures.ItemsSource = cultures;
            listBox_cultures.SelectedIndex = 0;
        }
        #endregion
    }
}
