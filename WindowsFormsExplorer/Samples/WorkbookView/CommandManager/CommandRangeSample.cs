namespace WindowsFormsExplorer.Samples.WorkbookView.CommandManager
{
    public partial class CommandRangeSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.CommandManager.CommandRangeSample Sample { get; private set; }

        private void ButtonExecute_Click(object sender, System.EventArgs e)
        {
            // Get the System color in Color Preview box and convert to SpreadsheetGear Color object.
            System.Drawing.Color systemColor = panelColorPreview.BackColor;

            // SpreadsheetGear uses its own SpreadsheetGear.Color, so we need to convert the System color.
            SpreadsheetGear.Color sgColor = SpreadsheetGear.Color.FromArgb(systemColor.R, systemColor.G, systemColor.B);

            // Run the sample to execute the command.
            Sample.ExecuteCommand(workbookView, sgColor);
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

        private void ButtonRedo_Click(object sender, System.EventArgs e)
        {
            // Attempt to Redo.  If it fails (probably because there is nothing to redo), display the error
            // in a MessageBox.
            if (!Sample.RedoCommand(workbookView, out string errorMessage))
            {
                System.Windows.Forms.MessageBox.Show(errorMessage, "SpreadsheetGear Explorer",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void TrackBar_ValueChanged(object sender, System.EventArgs e)
        {
            System.Drawing.Color previewColor = System.Drawing.Color.FromArgb(
                trackBarRed.Value,
                trackBarGreen.Value,
                trackBarBlue.Value
            );
            panelColorPreview.BackColor = previewColor;
        }

        #region Sample Initialization Code
        public CommandRangeSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.CommandManager.CommandRangeSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            trackBarRed.Value = panelColorPreview.BackColor.R;
            trackBarGreen.Value = panelColorPreview.BackColor.G;
            trackBarBlue.Value = panelColorPreview.BackColor.B;
        }
        #endregion
    }
}
