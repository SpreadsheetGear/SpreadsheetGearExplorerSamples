namespace SamplesLibrary.Samples.Calculations
{
    public class CustomFunctionsSample : ISpreadsheetGearWindowsSample
    {
        public string PerformAddCalculation(string input1, string input2)
        {
            // Create a new empty workbook set.
            // NOTE: Use GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
            //       to use the current culture instead of the default US English culture.
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {
                // Register the custom function to the workbook set.
                workbookSet.Add(MyAdd.MyAddSingleton);

                // Add a workbook to the workbook set.
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Add();

                // Get the first sheet and it's cells.
                SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets[0];
                SpreadsheetGear.IRange cells = worksheet.Cells;

                // Assign user entered values and formula to cells.
                cells["A1"].Formula = input1;
                cells["B1"].Formula = input2;
                cells["C1"].Formula = "=MYADD(A1,B1)";

                // Return the calculated result.
                return "Result calculated from MYADD:  " + cells["C1"].Text;
            }
        }

        // A simple addition custom function.
        public class MyAdd : SpreadsheetGear.CustomFunctions.Function
        {
            // Set to the one and only instance of MyAdd.
            public static readonly MyAdd MyAddSingleton = new MyAdd();

            // Add two numbers.
            public override void Evaluate(
                SpreadsheetGear.CustomFunctions.IArguments arguments,
                SpreadsheetGear.CustomFunctions.IValue result)
            {
                // Verify that there are two arguments.
                if (arguments.Count == 2)
                    // Get the two arguments as numbers, and add them.
                    result.Number = arguments.GetNumber(0) + arguments.GetNumber(1);
                else
                    // Return ValueError.Value.
                    result.Error = SpreadsheetGear.ValueError.Value;
            }

            // Singleton class - so make the constructor private.
            private MyAdd()
                : base(
                // The name of the custom function.
                "MYADD",
                // For a given set of inputs, 
                // this function always returns the same value.
                SpreadsheetGear.CustomFunctions.Volatility.Invariant,
                // This function returns a number.
                SpreadsheetGear.CustomFunctions.ValueType.Number)
            { }
        }
    }
}
