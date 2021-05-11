/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using SharedSamples;

namespace WPFExplorer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // NOTE: 
            // SpreadsheetGear products distributed on NuGet are by default in a "Free" mode which places 
            // certain limits on its usage in this mode:
            //   - 1,000 rows x 100 columns x 10 worksheets x 3 workbooks
            //
            // These samples are setup in a way that stays within these limits, and so a Signed License 
            // string (which expands on these limits) is not required.  However, if they are modified, the 
            // above limits could be hit and an exception could be thrown.  If this occurs, you can activate 
            // the unlimited mode by providing a "Signed License" string.  If you are a Licensed user of 
            // SpreadsheetGear, you can visit the SpreadsheetGear Licensed User Downloads page to generate 
            // a Signed License string from your License Number:
            //  - https://www.spreadsheetgear.com/downloads/downloadlicensed.aspx
            //
            // If you would like to evaluate the unlimited mode of SpreadsheetGear for 30 days, you can 
            // generate a Signed Trial License from the SpreadsheetGear Evaluation Downloads page:
            //  - https://www.spreadsheetgear.com/downloads/register.aspx
            //
            // Once you have your Signed License, replace it with the below line of code:
            // SpreadsheetGear.Factory.SetSignedLicense("MY SIGNED LICENSE HERE");

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateSampleTree();
        }


        private void PopulateSampleTree()
        {
            // Build the shared categories and shared (Engine and Windows) samples.
            var categoryRoot = SamplesBuilder.Build();

            // Intermix in the WPF-specific samples.
            WpfSamplesBuilder.Build(categoryRoot);

            // Associate samples with the TreeView.
            samplesTreeView.ItemsSource = categoryRoot.ChildCategories;

            // Select first item
            var item = samplesTreeView.ItemContainerGenerator.ContainerFromIndex(0);
            var treeViewItem = item as TreeViewItem;
            if (treeViewItem != null)
                treeViewItem.IsSelected = true;
        }


        private void samplesTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = (sender as TreeView).SelectedItem;

            // Display summary of this category and any contained samples or sub-categories.
            if (selectedItem is Category)
            {
                sampleContainer.SetSummaryTab((Category)selectedItem);
            }
            // Display the selected sample.
            else if (selectedItem is SampleInfo)
            {
                sampleContainer.SetSample((SampleInfo)selectedItem);
            }
        }
    }
}
