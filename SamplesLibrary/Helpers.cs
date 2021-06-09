/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SamplesLibrary
{
    public static class Helpers
    {
        /// <summary>
        /// Creates an absolute path to the provided <paramref name="pathFromOutputFolder"/> relative to the "Output" ("bin") directory for the currently-executing application.  The current working directory (<see cref="System.Environment.CurrentDirectory"/>) cannot be used because it points to the project root folder for ASP.NET apps.  Many supporting files for the samples are located in the Output/bin directory, so this method can be used to assist in getting a path to these supporting files.
        /// </summary>
        /// <param name="pathFromOutputFolder">Path relative to the Output/bin directory</param>
        public static string GetFullOutputFolderPath(string pathFromOutputFolder = "")
        {
            string pathToOutputFolder = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            return Path.Combine(pathToOutputFolder, pathFromOutputFolder);
        }
    }
}
