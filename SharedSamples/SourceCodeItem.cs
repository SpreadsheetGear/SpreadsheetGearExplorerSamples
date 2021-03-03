/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SharedSamples
{
    /// <summary>
    /// Reads a source code file from the specified path and sets up an HTML string that can be
    /// passed into a web control to display next to the running sample.
    /// </summary>
    public class SourceCodeItem
    {
        public SourceCodeItem(string filePath, string sampleName, string sampleDescription)
        {
            var file = new System.IO.FileInfo(filePath);
            FullPath = file.FullName;
            FileName = file.Name;
            SourceCode = System.IO.File.ReadAllText(filePath);
            if (!_extensionsMapper.TryGetValue(file.Extension, out var language))
                language = "cs";
            Language = language;

            var htmlTemplate = System.IO.File.ReadAllText(Helpers.GetFullOutputFolderPath(@"Files\SourceCodeTemplate.html"));
            SourceCodeHtml = htmlTemplate
                .Replace("[[TITLE]]", sampleName)
                .Replace("[[DESCRIPTION]]", sampleDescription)
                .Replace("[[BODY]]", System.Web.HttpUtility.HtmlEncode(SourceCode))
                .Replace("[[LANGUAGE]]", Language);
        }


        /// <summary>
        /// Returns <see cref="SourceCode"/> but using the specified amount of spaces per tab (default is 4).
        /// </summary>
        public string GetSourceCode(int tabSize = 4)
        {
            if (tabSize == 4)
                return SourceCode;
            else
            {
                var regex = new Regex(@"(^|\G) {4}", RegexOptions.Multiline);
                var newSourceCode = regex.Replace(SourceCode, new string(' ', tabSize));
                return newSourceCode;
            }
        }


        /// <summary>
        /// Full path to source code file, including the file name.
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Just the file name and extension of the source code file.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Original source code.
        /// </summary>
        public string SourceCode { get; set; }

        /// <summary>
        /// HTML-formatted source code
        /// </summary>
        public string SourceCodeHtml { get; set; }

        /// <summary>
        /// Returns the language class used by Prism.js syntax highlighter, excluding the "language-" 
        /// prefix (cs, xml, etc).
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Formatted HTML uses the Prism.js syntax highligher library to format the sample code in a
        /// viwer-friendly way.  This dictionary maps known file extensions to the CSS classes for the
        /// given language.
        /// </summary>
        private static Dictionary<string, string> _extensionsMapper = new Dictionary<string, string>() {
            { ".cs", "cs" },
            { ".xaml", "xml" }
        };
    }
}
