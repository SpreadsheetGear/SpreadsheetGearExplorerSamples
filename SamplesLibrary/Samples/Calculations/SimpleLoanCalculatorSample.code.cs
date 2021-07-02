namespace SamplesLibrary.Samples.Calculations
{
    /// <summary>
    /// Simple class to transport the results of the sample.
    /// </summary>
    public class SimpleLoanCalculatorResults
    {
        public string LoanAmount { get; set; }
        public string InterestRate { get; set; }
        public string NumPeriods { get; set; }
        public string Payment { get; set; }
    }


    public class SimpleLoanCalculatorSample : ISpreadsheetGearWindowsSample
    {
        public SimpleLoanCalculatorResults Calculate(string loanAmount, string interestRate, string numPeriods)
        {
            // Create a new empty workbook set.
            // NOTE: Use GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
            //       to use the current culture instead of the default US English culture.
            using (SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet())
            {
                // Get the full path to a workbook with with loan formulas.
                string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\CalculationsSimpleLoanCalc.xls");

                // Open the workbook.
                SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Open(workbookPath);

                // Get ranges from defined names.
                SpreadsheetGear.IRange pv = workbook.Names["pv"].RefersToRange;
                SpreadsheetGear.IRange rate = workbook.Names["rate"].RefersToRange;
                SpreadsheetGear.IRange nper = workbook.Names["nper"].RefersToRange;

                // Copy the text box values to the worksheet.
                pv.Formula = loanAmount;
                rate.Formula = interestRate;
                nper.Formula = numPeriods;

                // Setup a SimpleLoanCalculatorResults object to return the results.
                SimpleLoanCalculatorResults results = new SimpleLoanCalculatorResults {
                    // Copy the formatted worksheet values to the corresponding result properties.
                    LoanAmount = pv.Text,
                    InterestRate = rate.Text,
                    NumPeriods = nper.Text,

                    // Get payment amount from the Defined Name that refers to the cell holding the payment formula.
                    // This workbook is setup with Automatic calculation mode, so just the act of getting IRange.Text 
                    // will trigger a calculation and return an updated value.
                    Payment = workbook.Names["payment"].RefersToRange.Text
                };

                // Return the results.
                return results;
            }
        }
    }
}
