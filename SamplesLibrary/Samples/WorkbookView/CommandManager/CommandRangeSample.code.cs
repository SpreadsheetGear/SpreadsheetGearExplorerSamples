namespace SamplesLibrary.Samples.WorkboookView.CommandManager
{
    public class CommandRangeSample : ISpreadsheetGearWindowsSample
    {
        public void ExecuteCommand(IWorkbookView workbookView, SpreadsheetGear.Color color)
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Create an instance of the command.
                MyCommandRange command = new MyCommandRange(workbookView.RangeSelection, color);

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
         * Demonstrate creating an undoable command that sets the Interior color of the currently selected
         * range in the WorkbookView control..
         */
        private class MyCommandRange : SpreadsheetGear.Commands.CommandRange
        {
            // The color we'll use to set the Interior of the range.
            SpreadsheetGear.Color _color;

            internal MyCommandRange(SpreadsheetGear.IRange range, SpreadsheetGear.Color color)
                : base(range)
            {
                _color = color;
            }

            protected override bool Execute()
            {
                bool executed = false;

                // Execute the command and return true if it executed successfully.
                Range.Interior.Color = _color;
                executed = true;

                return executed;
            }

            protected override bool Undo()
            {
                // Undo the command.
                return base.Undo();
            }

            public override string DisplayText
            {
                get
                {
                    // Text displayed in Undo menu.
                    return "MyCommandRange";
                }
            }

            protected override SpreadsheetGear.Commands.CommandRangeUndoFlags UndoFlags
            {
                get
                {
                    // Specifying just Formats flag, since we're only modifying the Interior color.
                    return SpreadsheetGear.Commands.CommandRangeUndoFlags.Formats;
                }
            }
        }
    }
}
