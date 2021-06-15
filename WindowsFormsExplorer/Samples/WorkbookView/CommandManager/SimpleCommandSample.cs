namespace WindowsFormsExplorer.Samples.WorkbookView.CommandManager
{
    public partial class SimpleCommandSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.CommandManager.SimpleCommandSample Sample { get; private set; }

        private void ButtonExecute_Click(object sender, System.EventArgs e)
        {
            // Run the sample to execute the command.
            Sample.ExecuteCommand(workbookView);
        }

        private void ButtonUndo_Click(object sender, System.EventArgs e)
        {
            // Attempt to Undo.  If it fails (probably because there is nothing to undo), display the error
            // in a MessageBox.
            if (!Sample.UndoCommand(workbookView, out string errorMessage))
            {
                System.Windows.Forms.MessageBox.Show(errorMessage, "SpreadsheetGear Explorer",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        #region Sample Initialization Code
        public SimpleCommandSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.CommandManager.SimpleCommandSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
