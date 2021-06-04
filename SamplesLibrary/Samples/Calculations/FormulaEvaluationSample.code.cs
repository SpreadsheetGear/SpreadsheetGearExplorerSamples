namespace SamplesLibrary.Samples.Calculations
{
    public class FormulaEvaluationSample : ISpreadsheetGearWindowsSample
    {
        public string EvaluateFormula(string formula)
        {
            // Create a new empty workbook set.
            // NOTE: Use GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
            //       to use the current culture instead of the default US English culture.
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {
                // Create a new workbook and get referene to the first worksheet.
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Add();
                SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];

                // Evaluate the input formula.
                object result = worksheet.EvaluateValue(formula);

                // Display the result to the user.
                string displayValue;
                if (result == null)
                    displayValue = "Invalid Formula!";
                else if (result is SpreadsheetGear.ValueError)
                {
                    SpreadsheetGear.ValueError valueError = (SpreadsheetGear.ValueError)result;
                    displayValue = "Value Error: #" + valueError.ToString().ToUpper() + "!";
                }
                else
                    displayValue = result.ToString();

                // Return information about the evaluated result.
                return "Result calculated from ISheet.EvaluateValue(...) = " + displayValue;
            }
        }
    }
}
