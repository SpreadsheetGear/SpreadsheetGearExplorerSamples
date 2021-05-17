using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Xml;
using System.IO;
using SharedSamples;
using MdXaml;
using System.Windows.Input;
using System.Diagnostics;

namespace WindowsFormsExplorer
{
    public partial class CategorySummaryPane : UserControl
    {
        private ElementHost _elementHost;
        private MarkdownScrollViewer _markdownScrollViewer;

        public CategorySummaryPane()
        {
            InitializeComponent();

            _elementHost = new ElementHost();
            _elementHost.Dock = DockStyle.Fill;
            this.Controls.Add(_elementHost);

            _markdownScrollViewer = new MarkdownScrollViewer();

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
            //doc.FontFamily = new System.Windows.Media.FontFamily("Calibri");
            //doc.FontSize = 18;
        }
    }
}
