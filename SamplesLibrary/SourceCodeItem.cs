/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SamplesLibrary
{
    /// <summary>
    /// Reads a source code file from the specified path and cleans / formats the code to be presented
    /// next to the running sample.
    /// </summary>
    public class SourceCodeItem
    {
        private readonly string _sampleName, _sampleDescription;

        public SourceCodeItem(string filePath, string sampleName, string sampleDescription)
        {
            var file = new System.IO.FileInfo(filePath);
            FullPath = file.FullName;
            FileName = file.Name;
            Extension = file.Extension.ToLower();
            OriginalSourceCode = System.IO.File.ReadAllText(filePath);
            if (!_extensionsMapper.TryGetValue(file.Extension, out var language))
                language = "cs";
            Language = language;

            _sampleName = sampleName;
            _sampleDescription = sampleDescription;
        }


        /// <summary>
        /// Returns <see cref="OriginalSourceCode"/> in a form that is better presentable in the 
        /// Explorers, optionally converting to HTML and modifying the tab size.
        /// </summary>
        public string GetSourceCode(SourceCodeFormat format, int tabSize = 4)
        {
            string sourceCode = OriginalSourceCode;

            // Detect and remove namespace if present
            if (Extension == ".cs")
            {
                var regex = new Regex(@"^namespace .*\n{", RegexOptions.Multiline);
                if (regex.IsMatch(sourceCode))
                {
                    sourceCode = regex.Replace(sourceCode, "");
                    sourceCode = sourceCode.Substring(0, sourceCode.LastIndexOf("}")).Trim();

                    // Trim off first indentation
                    sourceCode = Regex.Replace(sourceCode, @"( {4})(.*)", "$2");
                }
            }

            // Modfiy tab size from default of 4 if needed.
            if (tabSize != 4)
            {
                var regex = new Regex(@"(^|\G) {4}", RegexOptions.Multiline);
                sourceCode = regex.Replace(sourceCode, new string(' ', tabSize));
            }

            // Format code as HTML if needed.
            if (format == SourceCodeFormat.Html)
            {
                var htmlTemplate = System.IO.File.ReadAllText(Helpers.GetFullOutputFolderPath(@"Files\SourceCodeTemplate.html"));
                sourceCode = htmlTemplate
                    .Replace("[[TITLE]]", _sampleName)
                    .Replace("[[DESCRIPTION]]", _sampleDescription)
                    .Replace("[[BODY]]", System.Web.HttpUtility.HtmlEncode(sourceCode))
                    .Replace("[[LANGUAGE]]", Language);
            }

            return sourceCode;
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
        /// Extension of the source code file (includes period).
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Code file's original source code.  Use <see cref="GetSourceCode(bool, int)"/> to get the source code in a form that is presentable in the Explorer samples.
        /// </summary>
        public string OriginalSourceCode { get; set; }

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
        private static readonly Dictionary<string, string> _extensionsMapper = new Dictionary<string, string>() {
            { ".cs", "cs" },
            { ".xaml", "xml" }
        };
    }


    public enum SourceCodeFormat
    {
        Plaintext,
        Html
    }
}
