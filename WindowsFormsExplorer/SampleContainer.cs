/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using SamplesLibrary;
using System;
using System.Linq;
using System.Windows.Forms;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using ICSharpCode.AvalonEdit.Highlighting;
using System.Windows;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Windows.Forms.Integration;
using System.Drawing;

namespace WindowsFormsExplorer
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
                if (System.Drawing.SystemColors.WindowText.ToArgb() == Color.Black.ToArgb())
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

            pictureBox1.Image = SystemIcons.Information.ToBitmap();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        public void SetSample(SampleInfo sampleInfo)
        {
            DisposeCurrentSample();

            // SharedEngineSamples are hosted in a EngineSampleControl and provide a common user interface to load
            // and run the sample.
            SampleUserControl sampleUserControl;
            if (sampleInfo.IsSharedEngineSample)
            {
                var engineSample = sampleInfo.CreateInstance<ISpreadsheetGearEngineSample>();
                sampleUserControl = new EngineSampleControl(engineSample);
                labelSampleType.Text = "SpreadsheetGear Engine Sample";
            }
            else
            {
                // SharedWindowSamples can still be shared between WPF, WinForms, etc., as a common IWorkbookView
                // interface is used to work across UI frameworks.  A concrete XAML SampleUserControl still needs to be
                // available to work alongside the SharedWindowSample, however.
                if (sampleInfo.IsSharedWindowsSample)
                {
                    sampleUserControl = FindSampleUserControlSample(sampleInfo.SampleType);
                }
                // SampleUserControls are used for purely WPF-centric samples whose code cannot be shared (for instance,
                // samples that demonstrate XAML Control Templates which obviously don't exist in WinForms).
                else if (typeof(SampleUserControl).IsAssignableFrom(sampleInfo.SampleType))
                {
                    sampleUserControl = sampleInfo.CreateInstance<SampleUserControl>();
                }
                else
                {
                    throw new Exception("Invalid sample type provided.");
                }

                labelSampleType.Text = "SpreadsheetGear Windows Forms Sample";
            }
            sampleUserControl.Dock = DockStyle.Fill;
            panelSampleContainer.Controls.Add(sampleUserControl);

            richTextBoxNameDescription.Clear();
            string boldText = sampleInfo.Name + " - ";
            richTextBoxNameDescription.AppendText(boldText + sampleInfo.Description);
            richTextBoxNameDescription.SelectionStart = 0;
            richTextBoxNameDescription.SelectionLength = boldText.Length;
            richTextBoxNameDescription.SelectionFont = new Font(richTextBoxNameDescription.Font.Name, richTextBoxNameDescription.Font.Size, System.Drawing.FontStyle.Bold);
            richTextBoxNameDescription.ReadOnly = true;

            ResizeSplitterToShowSample();
            UpdateSourceCodeTabs(sampleInfo);
        }


        private void ResizeSplitterToShowSample()
        {
            if (splitContainer1.SplitterDistance == 0)
                splitContainer1.SplitterDistance = Height / (Height > 800 ? 3 : 2);
        }


        /// <summary>
        /// Any <see cref="ISpreadsheetGearWindowsSample"/> must also have a corresponding <see cref="SampleUserControl"/> that contains the Shared Windows Sample and both classes must have the same name.
        /// </summary>
        /// <param name="sampleType">A Type that inherits from <see cref="ISpreadsheetGearWindowsSample"/></param>
        /// <returns>The corresponding <see cref="SampleUserControl"/> for the <see cref="ISpreadsheetGearWindowsSample"/>.</returns>
        public SampleUserControl FindSampleUserControlSample(Type sampleType)
        {
            if (!typeof(ISpreadsheetGearWindowsSample).IsAssignableFrom(sampleType))
                throw new ArgumentException($"The provided type {sampleType.Name} does not inherit from {nameof(ISpreadsheetGearWindowsSample)}.", nameof(sampleType));

            var allSampleUserControls = this.GetType().Assembly
                .GetTypes()
                .Where(t => typeof(SampleUserControl).IsAssignableFrom(t));
            var userControlType = allSampleUserControls.SingleOrDefault(t => t.Name == sampleType.Name);
            if (userControlType == null)
                throw new InvalidOperationException($"Could not locate a corresponding {nameof(SampleUserControl)} class for the provided {nameof(ISpreadsheetGearWindowsSample)} ('{sampleType.Name}').");

            return (SampleUserControl)Activator.CreateInstance(userControlType);
        }


        public void DisposeCurrentSample()
        {
            if (panelSampleContainer.Controls.Count == 1)
            {
                var SampleUserControl = (SampleUserControl)panelSampleContainer.Controls[0];
                panelSampleContainer.Controls.Remove(SampleUserControl);
                SampleUserControl.Dispose();
            }
            System.Diagnostics.Debug.Assert(panelSampleContainer.Controls.Count == 0);
        }


        public void UpdateSourceCodeTabs(SampleInfo sampleInfo)
        {
            ClearTabs();

            for (int i = 0; i < sampleInfo.SourceCodes.Count; i++)
            {
                var sourceCodeItem = sampleInfo.SourceCodes[i];
                var tab = new TabPage();
                tab.Text = sourceCodeItem.FileName;
                tab.ToolTipText = sourceCodeItem.FullPath;
                tab.Controls.Add(CreateSourceCodeEditor(sourceCodeItem));
                tabControl.TabPages.Add(tab);
            }
            tabControl.SelectTab(0);
        }


        private ElementHost CreateSourceCodeEditor(SourceCodeItem sourceCodeItem)
        {
            var document = new TextDocument();
            document.Text = sourceCodeItem.GetSourceCode(SourceCodeFormat.Plaintext);
            document.FileName = sourceCodeItem.FileName;

            var editor = new TextEditor();
            editor.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            editor.FontSize = 14;
            editor.IsReadOnly = true;
            editor.Padding = new Thickness(10, 10, 0, 0);
            if (sourceCodeItem.Extension == ".cs")
                editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
            if (_syntaxHighlightingDefinitions.ContainsKey(sourceCodeItem.Extension))
                editor.SyntaxHighlighting = _syntaxHighlightingDefinitions[sourceCodeItem.Extension];
            editor.Document = document;

            ElementHost elementHost = new ElementHost();
            elementHost.Dock = DockStyle.Fill;
            elementHost.Child = editor;

            return elementHost;
        }


        private void ClearTabs()
        {
            while (tabControl.TabPages.Count > 0)
                tabControl.TabPages[0].Dispose();
        }
    }
}
