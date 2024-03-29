﻿/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using SamplesLibrary.Engine;
using MdXaml;
using System.Windows.Input;
using System.Diagnostics;

namespace WindowsFormsExplorer
{
    public partial class CategorySummaryPane : UserControl
    {
        private readonly ElementHost _elementHost;
        private readonly MarkdownScrollViewer _markdownScrollViewer;

        public CategorySummaryPane()
        {
            InitializeComponent();

            _elementHost = new ElementHost() {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(_elementHost);

            _markdownScrollViewer = new MarkdownScrollViewer();

            // Load style more accommodating to high-contrast modes.
            var styleUri = new Uri($"/SamplesLibrary.Windows;component/Files/Markdown.Style.xaml", UriKind.Relative);
            var resourceDict = (ResourceDictionary)System.Windows.Application.LoadComponent(styleUri);
            var standardStyle = (Style)resourceDict["DocumentStyleStandard"];
            _markdownScrollViewer.MarkdownStyle = standardStyle;

            // Used to launch browser when a hyperlink is clicked.
            _markdownScrollViewer.CommandBindings.Add(new CommandBinding(
                NavigationCommands.GoToPage,
                (sender, e) => {
                    var proc = new Process();
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.FileName = (string)e.Parameter;
                    proc.Start();
                }));

            _elementHost.Child = _markdownScrollViewer;
        }


        public void SetCategory(Category category)
        {
            var markdown = category.GetCategorySummaryMarkdown("📁", "▶️");
            _markdownScrollViewer.Markdown = markdown;
            var doc = _markdownScrollViewer.Document;
            doc.PagePadding = new Thickness(10);
        }
    }
}
