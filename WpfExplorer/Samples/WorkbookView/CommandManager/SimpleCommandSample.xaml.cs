﻿namespace WPFExplorer.Samples.WorkbookView.CommandManager
{
    public partial class SimpleCommandSample : SGUserControl
    {
        public SharedSamples.Samples.WorkboookView.CommandManager.SimpleCommandSample Sample { get; private set; }

        private void buttonExecute_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Sample.ExecuteCommand(workbookView);
        }

        private void buttonUndo_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Sample.UndoCommand(workbookView, out string errorMessage))
            {
                System.Windows.MessageBox.Show(errorMessage, "SpreadsheetGear Explorer: Error");
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
            // DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
