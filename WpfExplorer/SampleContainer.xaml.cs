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
        public SGUserControl CurrentSample { get; private set; }

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
                await webView2.EnsureCoreWebView2Async(env);
            }
            catch { }
            
            if (webView2.CoreWebView2 == null)
            {
                var errorTextBox = new TextBox();
                errorTextBox.Text = "ERROR: Could not load WebView2 control to display sample's source code.  Ensure you " +
                    "have installed the WebView2 Runtime on this machine, which at the time of this writing was available " +
                    "from the following link:\r\n\r\n" +
                    "https://developer.microsoft.com/en-us/microsoft-edge/webview2/";
                webView2.Visibility = Visibility.Hidden;
                webView2HostGrid.Children.Add(errorTextBox);
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
                var engineSample  = sampleInfo.CreateInstance<SharedEngineSample>();
                CurrentSample = new EngineSampleControl(engineSample);
                windowsSampleLabel.Visibility = Visibility.Hidden;
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
                windowsSampleLabel.Visibility = Visibility.Visible;
            }

            grid_sampleControlContainer.Children.Clear();
            grid_sampleControlContainer.Children.Add(CurrentSample);

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
            CurrentSample?.Dispose();
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
                    Tag = sourceCode.SourceCodeHtml
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
                Tag = category.GetCategorySummary()
            };
            tabControl.Items.Add(tab);

            // Maximize tab / web view area since there is no sample to demo.
            grid.RowDefinitions[0].Height = new GridLength(0, GridUnitType.Pixel);
        }


        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabItem = tabControl.SelectedItem as TabItem;
            if (tabItem != null)
            {
                var sourceCodeHtml = (string)tabItem.Tag;
                SetWebViewContent(sourceCodeHtml);
            }
            else
                SetWebViewContent("");
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
    }
}
