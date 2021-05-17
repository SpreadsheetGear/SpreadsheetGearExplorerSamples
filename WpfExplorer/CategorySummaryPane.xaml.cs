using MdXaml;
using SharedSamples;
using System;
using System.Linq;
using System.Collections.Generic;
/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections;

namespace WPFExplorer
{
    /// <summary>
    /// Interaction logic for CategorySummary.xaml
    /// </summary>
    public partial class CategorySummaryPane : UserControl
    {
        public CategorySummaryPane()
        {
            InitializeComponent();

            // Used to launch browser when a hyperlink is clicked.
            CommandBindings.Add(new CommandBinding(
                NavigationCommands.GoToPage,
                (sender, e) => {
                    var proc = new Process();
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.FileName = (string)e.Parameter;
                    proc.Start();
                }));
        }


        public void SetCategory(Category category)
        {
            var markdown = category.GetCategorySummaryMarkdown("📁", "▶️");
            markdownScrollViewer.Markdown = markdown;
            var doc = markdownScrollViewer.Document;
            doc.PagePadding = new Thickness(10);
        }
    }
}
