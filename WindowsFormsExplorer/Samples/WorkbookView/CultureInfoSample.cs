using System;
using System.Collections.Generic;

namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class CultureInfoSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.CultureInfoSample Sample { get; private set; }

        private void button_runSample_Click(object sender, EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView_deDE, false);
            DisposalManager.ResetWorkbookView(workbookView_selectedCulture, false);

            Sample.RunSample(workbookView_deDE, workbookView_selectedCulture, (string)listBox_cultures.SelectedItem);
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
            listBox_cultures.DataSource = cultures;
            listBox_cultures.SelectedIndex = 0;

            splitContainer2.SplitterDistance = splitContainer2.Parent.Width / 2;
        }
        #endregion
    }
}
