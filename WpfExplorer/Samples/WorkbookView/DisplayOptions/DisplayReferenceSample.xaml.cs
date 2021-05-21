namespace WPFExplorer.Samples.WorkbookView.DisplayOptions
{
    public partial class DisplayReferenceSample : SGUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.DisplayOptions.DisplayReferenceSample Sample { get; private set; }

        private void RadioButton_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            var radioButton = (System.Windows.Controls.RadioButton)e.Source;
            Sample.UpdateDisplayReference(workbookView, radioButton.Tag.ToString());
        }

        #region Sample Initialization Code
        public DisplayReferenceSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.DisplayOptions.DisplayReferenceSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            DisposalManager.ResetWorkbookView(workbookView, false);

            Sample.InitializeSample(workbookView);
        }
        #endregion
    }
}
