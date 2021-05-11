/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using Microsoft.Web.WebView2.Core;
using SharedSamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPFExplorer
{
    /// <summary>
    /// Hosts all samples, displaying the sample itself on a top pane and the sample's various source code files on the bottom.
    /// In the case where a Category is selected, a summary of that Category and any of its containing sub-categories and samples
    ///  is displayed.
    /// </summary>
    public partial class SampleContainer : UserControl
    {
        private SGUserControl _currentSampleUserControl;
        private WebView2State _webView2State = WebView2State.NotInitialized;
        private RenderedContent _pendingRenderedContent;

        public SampleContainer()
        {
            InitializeComponent();
        }


        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Initializing WebView2 when the WebView2 Runtime is not installed on the local machine may throw an exception.  See
            // below TextBox note for more details on downloading and installing the Runtime.
            try
            {
                // Have observed web control running by default in a folder that lacks proper permissions.  Explicitly setup a user
                // data folder in the right place so as to avoid this problem.
                var userDataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                    "SpreadsheetGearWindowsFormsExplorerSamples");
                var env = await CoreWebView2Environment.CreateAsync(null, userDataFolder);

                _webView2State = WebView2State.Initializing;
                //throw new Exception();    // Uncomment to simulate failure to locate WebView2 control
                await webView2.EnsureCoreWebView2Async(env);
                _webView2State = WebView2State.Initialized;
            }
            catch { }
            
            if (webView2.CoreWebView2 == null)
            {
                _webView2State = WebView2State.NotAvailable;
            }
           
            if (_pendingRenderedContent != null)
                SetWebViewContent(_pendingRenderedContent);
        }


        public void SetSample(SampleInfo sampleInfo)
        {
            DisposeCurrentSample();

            // SharedEngineSamples are hosted in a EngineSampleControl and provide a common user interface to load
            // and run the sample.
            if (sampleInfo.IsSharedEngineSample)
            {
                var engineSample  = sampleInfo.CreateInstance<SharedEngineSample>();
                _currentSampleUserControl = new EngineSampleControl(engineSample);
                sampleTypeTextBlock.Text = "SpreadsheetGear Engine Sample";
            }
            else 
            {
                // SharedWindowSamples can still be shared between WPF, WinForms, etc., as a common IWorkbookView
                // interface is used to work across UI frameworks.  A concrete XAML SGUserControl still needs to be
                // available to work alongside the SharedWindowSample, however.
                if (sampleInfo.IsSharedWindowsSample)
                {
                    _currentSampleUserControl = FindSGUserControlSample(sampleInfo.SampleType);
                }
                // SGUserControls are used for purely WPF-centric samples whose code cannot be shared (for instance,
                // samples that demonstrate XAML Control Templates which obviously don't exist in WinForms).
                else if (typeof(SGUserControl).IsAssignableFrom(sampleInfo.SampleType))
                {
                    _currentSampleUserControl = sampleInfo.CreateInstance<SGUserControl>();
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
            grid_sampleControlContainer.Children.Add(_currentSampleUserControl);

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
            _currentSampleUserControl?.Dispose();
        }


        public void UpdateSourceCodeTabs(SampleInfo sampleInfo)
        {
            ClearTabs();
            for (int i = 0; i < sampleInfo.SourceCodes.Count; i++)
            {
                var sourceCode = sampleInfo.SourceCodes[i];
                var tab = new TabItem() {
                    Header = sourceCode.FileName,
                    ToolTip = sourceCode.FullPath,
                    IsSelected = i == 0,
                    Tag = new RenderedContent() { 
                        HtmlContent = sourceCode.GetSourceCode(SourceCodeFormat.Html),
                        PlaintextContent = sourceCode.GetSourceCode(SourceCodeFormat.Plaintext)
                    }
                };
                tabControl.Items.Add(tab);
            }
        }


        public void SetSummaryTab(Category category)
        {
            ClearTabs();
            var tab = new TabItem()
            {
                Header = "Description",
                ToolTip = "",
                IsSelected = true,
                Tag = new RenderedContent() { 
                    HtmlContent = category.GetCategorySummaryHtml(),
                    PlaintextContent = category.GetCategorySummaryPlaintext()
                }
            };
            tabControl.Items.Add(tab);

            // Maximize tab / web view area since there is no sample to demo.
            grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
        }


        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabItem = tabControl.SelectedItem as TabItem;
            if (tabItem != null)
                SetWebViewContent((RenderedContent)tabItem.Tag);
            else
                ClearWebViewContent();
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


        private void SetWebViewContent(RenderedContent content)
        {
            // WebView2 is available and initialized
            if (_webView2State == WebView2State.Initialized)
            {
                webView2.Visibility = Visibility.Visible;
                webView2FallbackContainer.Visibility = Visibility.Collapsed;
                webView2.NavigateToString(content.HtmlContent);
                _pendingRenderedContent = null;
            }
            // WebView2 must be initialized asynchronously, which is done in the async void Load event.  Calls to set
            // the TabItems's contents could get called while WebView2 is awaiting syncing, in such case this task
            // should be attempted later on, after initialization of the WebView2 has completed.
            else if (_webView2State == WebView2State.Initializing || _webView2State == WebView2State.NotInitialized)
            {
                _pendingRenderedContent = content;
            }
            // WebView2 is not available, likely Runtime not installed.  Fallback to simple plaintext TextBox and add note
            // prompting user to download WebView2 Runtime.
            else if (_webView2State == WebView2State.NotAvailable)
            {
                webView2.Visibility = Visibility.Collapsed;
                webView2FallbackContainer.Visibility = Visibility.Visible;
                webView2FallbackTextBox.Text = content.PlaintextContent;
            }
        }


        private void ClearWebViewContent()
        {
            SetWebViewContent(new RenderedContent("", ""));
        }


        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            var processStartInfo = new System.Diagnostics.ProcessStartInfo(e.Uri.ToString());
            processStartInfo.UseShellExecute = true;
            System.Diagnostics.Process.Start(processStartInfo);
        }
    }


    /// <summary>
    /// Provides HTML and Plaintext-based contents to display for the selected Sample source code file tab / Category node.
    /// </summary>
    public class RenderedContent
    {
        public RenderedContent(string html, string plaintext)
        {
            HtmlContent = html;
            PlaintextContent = plaintext;
        }

        public RenderedContent() { }

        public string HtmlContent { get; set; }

        public string PlaintextContent { get; set; }
    }


    public enum WebView2State
    {
        NotInitialized,
        Initializing,
        Initialized,
        NotAvailable
    }
}
