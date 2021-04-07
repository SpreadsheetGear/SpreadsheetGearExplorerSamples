/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using Microsoft.Web.WebView2.Core;
using SharedSamples;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsExplorer
{
    /// <summary>
    /// Hosts all samples, displaying the sample itself on a top pane and the sample's various source code files on the bottom.
    /// In the case where a Category is selected, a summary of that Category and any of its containing sub-categories and samples
    ///  is displayed.
    /// </summary>
    public partial class SampleContainer : UserControl
    {
        public SGUserControl CurrentSample { get; private set; }

        public SampleContainer()
        {
            InitializeComponent();
        }

        private async void SampleContainer_Load(object sender, EventArgs e)
        {
            // Have observed web control running by default in a folder that lacks proper permissions.  Explicitly setup a user
            // data folder in the right place so as to avoid this problem.
            var userDataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "SpreadsheetGearWindowsFormsExplorerSamples");
            var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder);
            await webView2.EnsureCoreWebView2Async(env);
            
            if (webView2.CoreWebView2 == null)
            {
                var errorTextBox = new TextBox();
                errorTextBox.Text = "ERROR: Could not load WebView2 control to display sample's source code.  Ensure you " +
                    "have installed the WebView2 Runtime on this machine, which at the time of this writing was available " +
                    "from the following link:\r\n\r\n" +
                    "https://developer.microsoft.com/en-us/microsoft-edge/webview2/";
                errorTextBox.Multiline = true;
                errorTextBox.Dock = DockStyle.Fill; var webView2Parent = webView2.Parent;
                webView2Parent.Controls.Clear(); webView2Parent.Controls.Add(errorTextBox);
            }
            else if (!string.IsNullOrEmpty(_pendingHtml))
                SetWebViewContent(_pendingHtml);
        }


        public void SetSample(SampleInfo sampleInfo)
        {
            DisposeCurrentSample();

            // SharedEngineSamples are hosted in a EngineSampleControl and provide a common user interface to load
            // and run the sample.
            if (typeof(SharedEngineSample).IsAssignableFrom(sampleInfo.SampleType))
            {
                var engineSample = sampleInfo.CreateInstance<SharedEngineSample>();
                CurrentSample = new EngineSampleControl(engineSample);
                windowsSampleLabelPanel.Visible = false;
            }
            else
            {
                // SharedWindowSamples can still be shared between WPF, WinForms, etc., as a common IWorkbookView
                // interface is used to work across UI frameworks.  A concrete XAML SGUserControl still needs to be
                // available to work alongside the SharedWindowSample, however.
                if (typeof(SharedWindowsSample).IsAssignableFrom(sampleInfo.SampleType))
                {
                    CurrentSample = FindSGUserControlSample(sampleInfo.SampleType);
                }
                // SGUserControls are used for purely WPF-centric samples whose code cannot be shared (for instance,
                // samples that demonstrate XAML Control Templates which obviously don't exist in WinForms).
                else if (typeof(SGUserControl).IsAssignableFrom(sampleInfo.SampleType))
                {
                    CurrentSample = sampleInfo.CreateInstance<SGUserControl>();
                }
                else
                {
                    throw new Exception("Invalid sample type provided.");
                }
                windowsSampleLabelPanel.Visible = true;
            }
            CurrentSample.Dock = DockStyle.Fill;
            
            panelSampleContainer.Controls.Clear();
            panelSampleContainer.Controls.Add(CurrentSample);

            ResizeSplitterToShowSample();
            UpdateSourceCodeTabs(sampleInfo);
        }


        private void ResizeSplitterToShowSample()
        {
            if (splitContainer1.SplitterDistance == 0)
                splitContainer1.SplitterDistance = Height / (Height > 800 ? 3 : 2);
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
            CurrentSample?.Dispose();
        }


        public void UpdateSourceCodeTabs(SampleInfo sampleInfo)
        {
            RemoveTabs();

            for (int i = 0; i < sampleInfo.SourceCodes.Count; i++)
            {
                var sourceCode = sampleInfo.SourceCodes[i];
                if (i == 0)
                    SetWebViewContent(sourceCode.SourceCodeHtml);
                var tab = new TabPage();
                tab.Text = sourceCode.FileName;
                tab.ToolTipText = sourceCode.FullPath;
                tab.Tag = sourceCode.SourceCodeHtml;
                tabControl.TabPages.Add(tab);
            }
            tabControl.SelectTab(0);
        }


        public void SetSummaryTab(Category category)
        {
            DisposeCurrentSample();
            RemoveTabs();

            var html = category.GetCategorySummary();
            SetWebViewContent(html);

            var tab = new TabPage("Description");
            tab.Tag = html;
            tabControl.TabPages.Add(tab);
            tabControl.SelectTab(0);

            // Maximize tab / web view area since there is no sample to demo.
            splitContainer1.SplitterDistance = 0;
        }


        private void RemoveTabs()
        {
            tabControl.Selected -= tabControl_Selected;
            while (tabControl.TabPages.Count > 0)
                tabControl.TabPages[0].Dispose();
            tabControl.Selected += tabControl_Selected;
            SetWebViewContent("");
        }


        private string _pendingHtml = null;
        private void SetWebViewContent(string html)
        {
            // WebView2 either isn't available or has not yet been initialized.
            if (webView2.CoreWebView2 != null)
            {
                webView2.NavigateToString(html);
                _pendingHtml = null;
            }
            // WebView2 must be initialized asynchronously, which is done in the Load event.  Calls to set
            // the controls HTML contents could get called before initialization so we should store off any
            // HTML that can be checked on to render should initialization complete later on.
            else
                _pendingHtml = html;
        }


        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            var tabPage = tabControl.SelectedTab;
            if (tabPage != null)
            {
                var sourceCodeHtml = (string)tabPage.Tag;
                SetWebViewContent(sourceCodeHtml);
            }
            else
                SetWebViewContent("");
        }
    }
}
