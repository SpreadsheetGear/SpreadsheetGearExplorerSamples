namespace WindowsFormsExplorer.Samples.WorkbookView.CommandManager
{
    public partial class CommandRangeSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.CommandManager.CommandRangeSample Sample { get; private set; }

        private void button_execute_Click(object sender, System.EventArgs e)
        {
            // Get the System color in Color Preview box and convert to SpreadsheetGear Color object.
            System.Drawing.Color systemColor = panel_colorPreview.BackColor;

            // SpreadsheetGear uses its own SpreadsheetGear.Color, so we need to convert the System color.
            SpreadsheetGear.Color sgColor = SpreadsheetGear.Color.FromArgb(systemColor.R, systemColor.G, systemColor.B);

            // Run the sample to execute the command.
            Sample.ExecuteCommand(workbookView, sgColor);
        }


        private void button_undo_Click(object sender, System.EventArgs e)
        {
            // Attempt to Undo.  If it fails (probably because there is nothing to undo), display the error
            // in a MessageBox.
            if (!Sample.UndoCommand(workbookView, out string errorMessage))
            {
                System.Windows.Forms.MessageBox.Show(errorMessage, "SpreadsheetGear Explorer", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        private void trackBar_ValueChanged(object sender, System.EventArgs e)
        {
            System.Drawing.Color previewColor = System.Drawing.Color.FromArgb(
                trackBar_red.Value,
                trackBar_green.Value,
                trackBar_blue.Value
            );
            panel_colorPreview.BackColor = previewColor;
        }


        #region Sample Initialization Code
        public CommandRangeSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SharedSamples.Samples.WorkboookView.CommandManager.CommandRangeSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
            trackBar_red.Value = panel_colorPreview.BackColor.R;
            trackBar_green.Value = panel_colorPreview.BackColor.G;
            trackBar_blue.Value = panel_colorPreview.BackColor.B;
        }
        #endregion
    }
}
