/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

            // Load style more accommodating to high-contrast modes.
            var styleUri = new Uri($"/{nameof(SamplesLibrary)};component/Files/Markdown.Style.xaml", UriKind.RelativeOrAbsolute);
            var resourceDict = (ResourceDictionary)Application.LoadComponent(styleUri);
            var standardStyle = (Style)resourceDict["DocumentStyleStandard"];
            markdownScrollViewer.MarkdownStyle = standardStyle;
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
