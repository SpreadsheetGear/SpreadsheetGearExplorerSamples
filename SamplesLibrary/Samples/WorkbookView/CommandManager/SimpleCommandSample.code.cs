namespace SamplesLibrary.Samples.WorkboookView.CommandManager
{
    public class SimpleCommandSample : ISpreadsheetGearWindowsSample
    {
        public void ExecuteCommand(IWorkbookView workbookView)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Create an instance of the simple command.
                CommandSimple command = new CommandSimple(workbookView);

                // Execute the command.
                workbookView.ActiveCommandManager.Execute(command);
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        public bool UndoCommand(IWorkbookView workbookView, out string errorMessage)
        {
            errorMessage = null;

            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Undo the last undoable command.
                workbookView.ActiveCommandManager.Undo();

                // Return true to indicate undo was successful.
                return true;
            }
            catch (System.Exception exc)
            {
                // Provide an error message when something goes wrong.
                errorMessage = exc.Message;
                return false;
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        /*
         * Demonstrate creating a simple undoable command which
         * toggles the display of gridlines.
         */
        private class CommandSimple : SpreadsheetGear.Commands.Command
        {
            private readonly IWorkbookView _workbookView;
            private bool _saveDisplayGridlines;

            public CommandSimple(IWorkbookView workbookView)
                : base(workbookView.ActiveWorkbook)
            {
                _workbookView = workbookView;
            }

            public override string DisplayText
            {
                get
                {
                    // Text displayed in Undo menu.
                    return "Toggle Display Gridlines";
                }
            }

            public override SpreadsheetGear.Commands.CommandUndoSupport UndoSupport
            {
                get
                {
                    // Undo is fully supported.
                    return SpreadsheetGear.Commands.CommandUndoSupport.Full;
                }
            }

            protected override bool Execute()
            {
                // Execute the command - we won't save state since we're
                // just toggling a boolean value.
                SpreadsheetGear.IWorksheetWindowInfo windowInfo = _workbookView.ActiveWorksheetWindowInfo;
                _saveDisplayGridlines = windowInfo.DisplayGridlines;
                windowInfo.DisplayGridlines = !_saveDisplayGridlines;
                return true;
            }

            protected override bool Undo()
            {
                // Undo the command.
                SpreadsheetGear.IWorksheetWindowInfo windowInfo = _workbookView.ActiveWorksheetWindowInfo;
                windowInfo.DisplayGridlines = _saveDisplayGridlines;
                return true;
            }
        }
    }
}
