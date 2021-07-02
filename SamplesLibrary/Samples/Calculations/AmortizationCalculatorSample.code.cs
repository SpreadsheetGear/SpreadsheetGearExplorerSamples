using System;
using System.Collections.Generic;
using System.Text;

namespace SamplesLibrary.Samples.Calculations
{
    /// <summary>
    /// Simple class to transport the results of the sample.
    /// </summary>
    public class AmortizationCalculatorResults
    {
        public string LoanAmount { get; set; }
        public string InterestRate { get; set; }
        public string NumPeriods { get; set; }
        public string Payment { get; set; }
        public string LastPayment { get; set; }
        public string TotalInterest { get; set; }
        public SpreadsheetGear.IWorkbook ResultsWorkbook { get; set; }
    }


    public class AmortizationCalculatorSample : ISpreadsheetGearWindowsSample
    {
        public AmortizationCalculatorResults Calculate(string loanAmount, string interestRate, string numPeriods)
        {
            // Create a new empty workbook set.
            // NOTE: Use GetWorkbookSet(System.Globalization.CultureInfo.CurrentCulture)
            //       to use the current culture instead of the default US English culture.
            SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();

            // Get the full path to a workbook with with loan formulas and amortization table.
            string workbookPath = Helpers.GetFullOutputFolderPath(@"Files\Windows\CalculationsLoanAmortizationTable.xls");

            // Open the workbook.
            SpreadsheetGear.IWorkbook workbook = workbookSet.Workbooks.Open(workbookPath);

            // Get ranges from defined names.
            SpreadsheetGear.IRange pv = workbook.Names["PV"].RefersToRange;
            SpreadsheetGear.IRange rate = workbook.Names["Rate"].RefersToRange;
            SpreadsheetGear.IRange nper = workbook.Names["NPer"].RefersToRange;

            // Copy the text box values to the worksheet.
            pv.Formula = loanAmount;
            rate.Formula = interestRate;
            nper.Formula = numPeriods;

            // Setup a AmortizationCalculatorResults object to return the results.
            AmortizationCalculatorResults results = new AmortizationCalculatorResults {
                // Copy the formatted worksheet values to the text boxes.
                LoanAmount = pv.Text,
                InterestRate = rate.Text,
                NumPeriods = nper.Text,

                // Get additional info from Defined Names that refer to cells holding calculated values.
                // This workbook is setup with Automatic calculation mode, so just the act of getting IRange.Text 
                // will trigger a calculation and return an updated value.
                Payment = workbook.Names["Payment"].RefersToRange.Text,
                LastPayment = workbook.Names["LastPayment"].RefersToRange.Text,
                TotalInterest = workbook.Names["TotalInterest"].RefersToRange.Text,

                // Return the workbook to display the amortization table in a WorkbookView control.
                ResultsWorkbook = workbook
            };

            // Return the results.
            return results;
        }
    }
}
