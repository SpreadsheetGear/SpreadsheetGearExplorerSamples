using System.Diagnostics;
using System;
using System.Collections.Generic;

// NOTE: a version of this sample is available to run on our website at:
// https://www.spreadsheetgear.com/Support/Samples/API/DateTimesAndExcelSerialNumericDates
namespace SamplesLibrary.Engine.Samples.Workbook
{
    public class DateTimeSample : ISpreadsheetGearEngineSample
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

            // SAMPLE 1 - Input DateTime
            {
                // Cell values can be set to a System.DateTime object, but internally
                // the date/time will be stored as a serial numeric (double) value.
                DateTime dateTime = new DateTime(2000, 3, 31, 18, 0, 0);
                cells["A1"].Value = dateTime;

                // Retrieve the serial date/time double value.
                double serialDateTime = (double)cells["A1"].Value;

                // The integer portion of the double value represents the number of days
                // since January 1, 1900, in this case 36,616 days.
                double days = Math.Truncate(serialDateTime);
                Debug.Assert(days == 36616);

                // The decimal portion of the double value represents the fractional time
                // into a 24 hour day.  In this case 18:00 (6:00 PM) is 75% into a day.
                double timeOfDay = serialDateTime - days;
                Debug.Assert(timeOfDay == 0.75);

                // The IWorkbook.NumberToDateTime(...) method can convert a serial numeric
                // date to a System.DateTime object.
                DateTime dateTime2 = Workbook.NumberToDateTime(serialDateTime);
                Debug.Assert(dateTime2 == dateTime);

                // Conversely, the IWorkbook.DateTimeToNumber(...) can be used to convert
                // a DateTime object to a serial numeric date value.
                double serialDateTime2 = Workbook.DateTimeToNumber(dateTime2);
                Debug.Assert(serialDateTime2 == serialDateTime);
            }

            // SAMPLE 2 - Input String
            {
                // This workbook is setup using an "en-US" CultureInfo, so we'll use this
                // format for the date/time string.
                string dateTimeStr = "4/30/2001 6:00:00 AM";
                cells["A4"].Value = dateTimeStr;

                // Retrieve the serial date/time double value.
                double serialDateTime = (double)cells["A4"].Value;

                // Similar to the above "SAMPLE 1", assert the expected serial date was used.
                double days = Math.Truncate(serialDateTime);
                double timeOfDay = serialDateTime - days;
                Debug.Assert(days == 37011);
                Debug.Assert(timeOfDay == 0.25);
            }

            // SAMPLE 3 - Set various Number Formats.
            { 
                // Set a range to the same DateTime.
                cells["A7:A14"].Value = new DateTime(2024, 2, 1, 17, 30, 25);
                // Define a list of Number Formats.
                List<string> numberFormats = new List<string>() {
                    "0.00",
                    "m/d/yyyy h:mm AM/PM",
                    "m/d/yyyy h:mm",
                    "m/d/yyyy",
                    "yyyy-mm-dd",
                    "yyyy-mm-ddThh:MM:ss",
                    "hh:mm:SS",
                    "h:mm:SS AM/PM"
                };
                // Iterate over and apply these Number Formats to the date/time value.
                for (int i = 0; i < numberFormats.Count; i++)
                {
                    // Set Number Format
                    cells["A7"].Offset(i, 0).NumberFormat = numberFormats[i];

                    // Show the Number Format in the cell to the right of the date/time value.
                    cells["A7"].Offset(i, 1).Value = "'" + numberFormats[i];
                }
            }

            // Setup some explanatory details about this sample and auto-fit cell contents.
            cells["B1"].Value = "<-- Inputted as a DateTime.";
            cells["B2"].Value = "<-- Underlying serial numeric double value of A1";
            cells["A2"].Formula = "=A1";
            cells["B4"].Value = "<-- Inputted as a string.";
            cells["B5"].Value = "<-- Underlying serial numeric double value of A4";
            cells["A5"].Formula = "=A4";
            worksheet.UsedRange.Columns.AutoFit();
        }
    }
}