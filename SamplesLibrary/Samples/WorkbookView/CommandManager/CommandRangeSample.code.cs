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

        public bool RedoCommand(IWorkbookView workbookView, out string errorMessage)
        {
            errorMessage = null;

            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Redo the last undone command.
                workbookView.ActiveCommandManager.Redo();

                // Return true to indicate redo was successful.
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
            private readonly SpreadsheetGear.Color color;

            internal MyCommandRange(SpreadsheetGear.IRange range, SpreadsheetGear.Color color)
                : base(range)
            {
                this.color = color;
            }

            protected override bool Execute()
            {
                // Execute the command.
                Range.Interior.Color = color;

                // Returning true indicates this Command should be added to the Undo stack, which is typically
                // the desired outcome for a successfully-executed command.  Returning false would keep this
                // Command from being added to the Undo stack.  The Undo stack is preserved as-is / not cleared
                // in the case of returning false.
                return true;
            }

            protected override bool Undo()
            {
                // Call base to undo the Command, which will revert the range back using whatever CommandRangeUndoFlags
                // were specified for this Command (CommandRangeUndoFlags.Formats in this case).
                bool retVal = base.Undo();

                // The return value indicates whether this undone Command should be added to the Redo stack, which
                // would be the desired outcome in most cases.  Returning false will clear the Redo stack.
                return retVal;
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
