/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExplorer
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // NOTE: 
            // SpreadsheetGear products distributed on NuGet are by default in a "Free" mode which places 
            // certain limits on its usage in this mode:
            //   - 1,000 rows x 100 columns x 10 worksheets x 3 workbooks
            //
            // These samples are setup in a way that stays within these limits, and so a Signed License 
            // string (which expands on these limits) is not required.  However, if they are modified, the 
            // above limits could be hit and an exception could be thrown.  If this occurs, you can activate 
            // the unlimited mode by providing a "Signed License" string.  If you are a Licensed user of 
            // SpreadsheetGear, you can visit the SpreadsheetGear Licensed User Downloads page to generate 
            // a Signed License string from your License Number:
            //  - https://www.spreadsheetgear.com/Downloads/Licensed
            //
            // If you would like to evaluate the unlimited mode of SpreadsheetGear for 30 days, you can 
            // generate a Signed Trial License from the SpreadsheetGear Evaluation Downloads page:
            //  - https://www.spreadsheetgear.com/Downloads/Evaluation
            //
            // Once you have your Signed License, replace it with the below line of code:
            // SpreadsheetGear.Factory.SetSignedLicense("MY SIGNED LICENSE HERE");

            try
            {
                Application.Run(new Form1());
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("SpreadsheetGear:  Free use is limited", StringComparison.InvariantCultureIgnoreCase))
                {
                    MessageBox.Show("The Explorer Samples by default use a limited free mode of SpreadsheetGear products and the executing sample exceeded one of these limits.  Please open up the Program.cs file of this project for more details on how to expand these limits through the use of a Signed License.");
                }
                else
                    throw;
            }
            catch { }
        }
    }
}
