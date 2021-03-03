/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFExplorer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception.Message.Contains("SpreadsheetGear:  Free use is limited", StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show("The Explorer Samples by default use a limited free mode of SpreadsheetGear products and the executing sample exceeded one of these limits.  Please open up the MainWindow.xaml.cs file of this project for more details on how to expand these limits through the use of a Signed License.");
                Current.Shutdown();
            }
        }
    }
}
