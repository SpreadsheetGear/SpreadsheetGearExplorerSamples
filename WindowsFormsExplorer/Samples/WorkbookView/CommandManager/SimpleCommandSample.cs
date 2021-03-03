namespace WindowsFormsExplorer.Samples.WorkbookView.CommandManager
{
    public partial class SimpleCommandSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.CommandManager.SimpleCommandSample Sample { get; private set; }

        private void buttonExecute_Click(object sender, System.EventArgs e)
        {
            // Run the sample to execute the command.
            Sample.ExecuteCommand(workbookView);
        }

        private void buttonUndo_Click(object sender, System.EventArgs e)
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
            Sample = new SharedSamples.Samples.WorkboookView.CommandManager.SimpleCommandSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
