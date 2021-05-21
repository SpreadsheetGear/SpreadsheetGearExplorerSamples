namespace SamplesLibrary.Samples.Workbook.Worksheet.Range.Formatting
{
    public class ValidationSample : ISpreadsheetGearEngineSample
    {
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        public void InitializeWorkbook()
        {
            // Create a new workbook.
            Workbook = SpreadsheetGear.Factory.GetWorkbook();
        }

        public void RunSample()
        {
            // Create some local variables to the active worksheet and its cells.
            SpreadsheetGear.IWorksheet worksheet = Workbook.ActiveWorksheet;
            SpreadsheetGear.IRange cells = worksheet.Cells;

            // Whole Number Validation
            {
                // Create a label for this validation
                cells["A1"].Value = "Whole Number";

                // Get a reference to the cell's validation.
                SpreadsheetGear.IValidation validation = cells["A2"].Validation;

                // Add data validation which will force the user to
                // enter a whole number greater than zero.
                validation.Add(
                    SpreadsheetGear.ValidationType.WholeNumber,
                    SpreadsheetGear.ValidationAlertStyle.Stop,
                    SpreadsheetGear.ValidationOperator.Greater, "0", null);

                // Set the error message to display if validation fails.
                validation.ErrorMessage = "You must enter a whole number greater than zero!";

                // Set the input message to display when the cell is active.
                validation.InputMessage = "Enter a whole number greater than zero.";
            }

            // Between
            {
                // Create a label for this validation
                cells["B1"].Value = "Between";

                // Get a reference to the cell's validation.
                SpreadsheetGear.IValidation validation = cells["B2"].Validation;

                // Delete any existing validation.
                validation.Delete();

                // Add data validation which will force the user to
                // enter a decimal number between 100 and 500.
                validation.Add(
                    SpreadsheetGear.ValidationType.Decimal,
                    SpreadsheetGear.ValidationAlertStyle.Stop,
                    SpreadsheetGear.ValidationOperator.Between, "100", "500");

                // Set the error message to display if validation fails.
                validation.ErrorMessage = "You must enter a number between 100 and 500!";

                // Set the input message to display when the cell is active.
                validation.InputMessage = "Enter a number between 100 and 500.";
            }

            // List of Values
            {
                // Create a label for this validation
                cells["C1"].Value = "List of Values";

                // Add data validation which will provide a drop-down 
                // list of values to choose from.  Users will be warned 
                // if they try to enter a value that is not in the list.
                cells["C2"].Validation.Add(
                    SpreadsheetGear.ValidationType.List,
                    SpreadsheetGear.ValidationAlertStyle.Warning,
                    SpreadsheetGear.ValidationOperator.Default, "Red,Green,Blue", null);
            }

            // Linked List
            {
                // Create a label for this validation
                cells["D1"].Value = "Linked List";

                // Load sample data.
                cells["D4:D6"].Value = new string[,] { { "Cold" }, { "Warm" }, { "Hot" } };

                // Add data validation which will provide a drop-down 
                // list of values to choose from.  This list is generated
                // from the sample cell data.  Users will be informed 
                // if they try to enter a value that is not in the list.
                cells["D2"].Validation.Add(
                    SpreadsheetGear.ValidationType.List,
                    SpreadsheetGear.ValidationAlertStyle.Information,
                    SpreadsheetGear.ValidationOperator.Default, "=D4:D6", null);
            }

            // Custom Validation
            {
                // Create a label for this validation
                cells["E1"].Value = "Custom";

                // Load sample data.
                cells["E4"].Value = 100;

                // Get a reference to the cell's validation.
                SpreadsheetGear.IValidation validation = cells["E2"].Validation;

                // Delete any existing validation.
                validation.Delete();

                // Add data validation which will force the user to enter a
                // number which is validated against the specified formula.
                validation.Add(
                    SpreadsheetGear.ValidationType.Custom,
                    SpreadsheetGear.ValidationAlertStyle.Stop,
                    SpreadsheetGear.ValidationOperator.Default,
                    "=IF(E2>($E$4*2),TRUE,FALSE)", null);

                // Set the error message to display if validation fails.
                validation.ErrorMessage = "You must enter a number greater than (E4 x 2)";

                // Set the input message to display when the cell is active.
                validation.InputMessage = "Enter a number greater than (E4 x 2).";
            }

            // Apply a bit of formatting to clean up the sample.
            worksheet.Cells["A2:E2"].Borders.LineStyle = SpreadsheetGear.LineStyle.Continuous;
            worksheet.UsedRange.ColumnWidth = 14;
        }
    }
}
