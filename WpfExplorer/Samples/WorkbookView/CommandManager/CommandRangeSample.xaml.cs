namespace WPFExplorer.Samples.WorkbookView.CommandManager
{
    public partial class CommandRangeSample : SampleUserControl
    {
        public SamplesLibrary.Samples.WorkboookView.CommandManager.CommandRangeSample Sample { get; private set; }

        private void ButtonExecute_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Get color in Color Preview box and convert to SpreadsheetGear Color object.
            System.Windows.Media.SolidColorBrush brush =
                colorPreview.Fill as System.Windows.Media.SolidColorBrush;
            if (brush != null)
            {
                System.Windows.Media.Color previewColor = brush.Color;
                SpreadsheetGear.Color color = SpreadsheetGear.Color.FromArgb(previewColor.R, previewColor.G, previewColor.B);

                Sample.ExecuteCommand(workbookView, color);
            }            
        }

        private void ButtonUndo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Attempt to Undo.  If it fails (probably because there is nothing to undo), display the error
            // in a MessageBox.
            if (!Sample.UndoCommand(workbookView, out string errorMessage))
            {
                System.Windows.MessageBox.Show(errorMessage, "SpreadsheetGear Explorer: Error");
            }
        }

        private void ButtonRedo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // Attempt to Redo.  If it fails (probably because there is nothing to redo), display the error
            // in a MessageBox.
            if (!Sample.RedoCommand(workbookView, out string errorMessage))
            {
                System.Windows.MessageBox.Show(errorMessage, "SpreadsheetGear Explorer: Error");
            }
        }

        private void Slider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateColor();
        }

        private void UpdateColor()
        {
            if (sliderRed != null && sliderGreen != null && sliderBlue != null)
            {
                colorPreview.Fill = new System.Windows.Media.SolidColorBrush(
                    System.Windows.Media.Color.FromArgb(255,
                    System.Convert.ToByte(sliderRed.Value),
                    System.Convert.ToByte(sliderGreen.Value),
                    System.Convert.ToByte(sliderBlue.Value)));
            }
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

            workbookView.GetLock();
            try
            {
                workbookView.ActiveWorksheet.Cells["A1"].Value =
                    "Clicking on \"Execute\" will fill the currently-selected range with the color in the Color Preview box.";
            }
            finally
            {
                workbookView.ReleaseLock();
            }
            UpdateColor();
        }
        #endregion
    }
}
