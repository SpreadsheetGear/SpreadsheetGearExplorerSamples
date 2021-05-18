/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SharedSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Xml;
using System.IO;
using System.Windows.Media;
using System.Reflection;

namespace WPFExplorer
{
    /// <summary>
    /// Hosts all samples, displaying the sample itself on a top pane and the sample's various source code files on the bottom.
    /// </summary>
    public partial class SampleContainer : UserControl
    {
        private Dictionary<string, IHighlightingDefinition> _syntaxHighlightingDefinitions;

        public SampleContainer()
        {
            InitializeComponent();

            // Preload any syntax highlighting definitions to be supplied to the AvalonEdit control, taking into account
            // other definition files for high-contrast (black or white) modes.
            _syntaxHighlightingDefinitions = new Dictionary<string, IHighlightingDefinition>();
            var customHighlightItems = new Dictionary<string, string>() {
                { ".cs",    "Syntax-Highlight-Def-CSharp" },
                { ".xaml",  "Syntax-Highlight-Def-XML" }
            };
            string highContrastMode = "";
            if (SystemParameters.HighContrast)
            {
                // High Contrast White
                if (Color.AreClose(SystemColors.WindowTextBrush.Color, Colors.Black))
                    highContrastMode = "-HCW";
                // High Contrast Black
                else
                    highContrastMode = "-HCB";
            }
            
            var baseDir = System.AppDomain.CurrentDomain.BaseDirectory;
            foreach (var item in customHighlightItems)
            {
                using (var stream = new StreamReader($@"{baseDir}Files\{item.Value}{highContrastMode}.xshd"))
                using (var reader = new XmlTextReader(stream))
                {
                    _syntaxHighlightingDefinitions.Add(item.Key, HighlightingLoader.Load(reader, HighlightingManager.Instance));
                }
            }
        }


        public void SetSample(SampleInfo sampleInfo)
        {
            DisposeCurrentSample();

            // SharedEngineSamples are hosted in a EngineSampleControl and provide a common user interface to load
            // and run the sample.
            SGUserControl sampleUserControl;
            if (sampleInfo.IsSharedEngineSample)
            {
                var engineSample  = sampleInfo.CreateInstance<SharedEngineSample>();
                sampleUserControl = new EngineSampleControl(engineSample);
                sampleTypeTextBlock.Text = "SpreadsheetGear Engine Sample";
            }
            else 
            {
                // SharedWindowSamples can still be shared between WPF, WinForms, etc., as a common IWorkbookView
                // interface is used to work across UI frameworks.  A concrete XAML SGUserControl still needs to be
                // available to work alongside the SharedWindowSample, however.
                if (sampleInfo.IsSharedWindowsSample)
                {
                    sampleUserControl = FindSGUserControlSample(sampleInfo.SampleType);
                }
                // SGUserControls are used for purely WPF-centric samples whose code cannot be shared (for instance,
                // samples that demonstrate XAML Control Templates which obviously don't exist in WinForms).
                else if (typeof(SGUserControl).IsAssignableFrom(sampleInfo.SampleType))
                {
                    sampleUserControl = sampleInfo.CreateInstance<SGUserControl>();
                }
                else
                {
                    throw new Exception("Invalid sample type provided.");
                }
                sampleTypeTextBlock.Text = "SpreadsheetGear Windows WPF Sample";
            }
            sampleNameRun.Text = sampleInfo.Name;
            sampleDescriptionRun.Text = sampleInfo.Description;

            grid_sampleControlContainer.Children.Clear();
            grid_sampleControlContainer.Children.Add(sampleUserControl);

            ResizeSplitterToShowSample();
            UpdateSourceCodeTabs(sampleInfo);
        }


        private void ResizeSplitterToShowSample()
        {
            var rowSample = grid.RowDefinitions[0];
            var rowSourceCode = grid.RowDefinitions[2];
            if (rowSample.Height.Value == 0)
            {
                rowSample.Height = new GridLength(2, GridUnitType.Star);
                rowSourceCode.Height = new GridLength(3, GridUnitType.Star);
            }
        }


        /// <summary>
        /// Any <see cref="SharedWindowsSample"/> must also have a corresponding <see cref="SGUserControl"/> that contains the Shared Windows Sample and both classes must have the same name.
        /// </summary>
        /// <param name="sampleType">A Type that inherits from <see cref="SharedWindowsSample"/></param>
        /// <returns>The corresponding <see cref="SGUserControl"/> for the <see cref="SharedWindowsSample"/>.</returns>
        public SGUserControl FindSGUserControlSample(Type sampleType)
        {
            if (!typeof(SharedWindowsSample).IsAssignableFrom(sampleType))
                throw new ArgumentException($"The provided type {sampleType.Name} does not inherit from {nameof(SharedWindowsSample)}.", nameof(sampleType));

            var allSGUserControls = this.GetType().Assembly
                .GetTypes()
                .Where(t => typeof(SGUserControl).IsAssignableFrom(t));
            var userControlType = allSGUserControls.SingleOrDefault(t => t.Name == sampleType.Name);
            if (userControlType == null)
                throw new InvalidOperationException($"Could not locate a corresponding {nameof(SGUserControl)} class for the provided {nameof(SharedWindowsSample)} ('{sampleType.Name}').");

            return (SGUserControl)Activator.CreateInstance(userControlType);
        }


        public void DisposeCurrentSample()
        {
            if (grid_sampleControlContainer.Children.Count == 1)
                ((SGUserControl)grid_sampleControlContainer.Children[0]).Dispose();
            grid_sampleControlContainer.Children.Clear();
            System.Diagnostics.Debug.Assert(grid_sampleControlContainer.Children.Count == 0);
        }


        public void UpdateSourceCodeTabs(SampleInfo sampleInfo)
        {
            ClearTabs();
            for (int i = 0; i < sampleInfo.SourceCodes.Count; i++)
            {
                var sourceCodeItem = sampleInfo.SourceCodes[i];
                var tab = new TabItem() {
                    Header = new TextBlock() { 
                        Text = sourceCodeItem.FileName,
                        ToolTip = sourceCodeItem.FullPath
                    },
                    IsSelected = i == 0
                };
                var editor = CreateSourceCodeEditor(sourceCodeItem);
                tab.Content = editor;
                tabControl.Items.Add(tab);
            }
        }


        private TextEditor CreateSourceCodeEditor(SourceCodeItem sourceCodeItem)
        {
            var document = new TextDocument();
            document.Text = sourceCodeItem.GetSourceCode(SourceCodeFormat.Plaintext);
            document.FileName = sourceCodeItem.FileName;

            var editor = new TextEditor();
            editor.FontFamily = new FontFamily("Consolas");
            editor.FontSize = 14;
            editor.IsReadOnly = true;
            editor.Padding = new Thickness(10, 10, 0, 0);
            if (sourceCodeItem.Extension == ".cs")
                editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
            else if (sourceCodeItem.Extension == ".xaml")
                editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("XML");
            if (_syntaxHighlightingDefinitions.ContainsKey(sourceCodeItem.Extension))
                editor.SyntaxHighlighting = _syntaxHighlightingDefinitions[sourceCodeItem.Extension];
            editor.Document = document;

            return editor;
        }


        private void ClearTabs()
        {
            while (tabControl.Items.Count > 0)
            {
                var tabItem = tabControl.Items[0] as TabItem;
                tabItem.Template = null;    // Avoid annoying xaml binding warning at runtime.
                tabControl.Items.Remove(tabItem);
            }
        }
    }
}
