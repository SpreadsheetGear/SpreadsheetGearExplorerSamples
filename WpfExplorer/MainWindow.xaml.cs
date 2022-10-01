/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SamplesLibrary;

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
            //  - https://www.spreadsheetgear.com/Downloads/Licensed
            //
            // If you would like to evaluate the unlimited mode of SpreadsheetGear for 30 days, you can 
            // generate a Signed Trial License from the SpreadsheetGear Evaluation Downloads page:
            //  - https://www.spreadsheetgear.com/Downloads/Evaluation
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
            // Build the shared categories and SpreadsheetGear Engine and Windows samples.
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

        private void SamplesTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selectedItem = (sender as TreeView).SelectedItem;

            // Display summary of this category and any contained samples or sub-categories.
            if (selectedItem is Category)
            {
                categorySummaryPane.SetCategory((Category)selectedItem);
                sampleContainer.Visibility = Visibility.Collapsed;
                categorySummaryPane.Visibility = Visibility.Visible;
            }
            // Display the selected sample.
            else if (selectedItem is SampleInfo)
            {
                sampleContainer.SetSample((SampleInfo)selectedItem);
                sampleContainer.Visibility = Visibility.Visible;
                categorySummaryPane.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonCollapseCategories_Click(object sender, RoutedEventArgs e)
        {
            SetSamplesTreeViewExpansion(samplesTreeView, false);
        }

        private void ButtonExpandCategories_Click(object sender, RoutedEventArgs e)
        {
            SetSamplesTreeViewExpansion(samplesTreeView, true);
        }

        private void SetSamplesTreeViewExpansion(ItemsControl parent, bool expand)
        {
            if (parent is TreeViewItem tvi)
            {
                // Always expand but don't collapse the top-level Category
                if (expand || (!expand && tvi.Header is Category cat && !cat.Parent.IsRoot))
                {
                    tvi.IsExpanded = expand;
                }
            }

            if (parent.HasItems)
            {
                var items = parent.Items
                    .Cast<object>()
                    .Select(i => GetTreeViewItem(parent, i, expand));
                foreach (var item in items)
                {
                    SetSamplesTreeViewExpansion(item, expand);
                }
            }
        }

        private TreeViewItem GetTreeViewItem(ItemsControl parent, object item, bool expand)
        {
            if (item is TreeViewItem tvi)
                return tvi;

            var result = ContainerFromItem(parent, item);
            if (result == null && expand)
            {
                parent.UpdateLayout();
                result = ContainerFromItem(parent, item);
            }
            return result;
        }

        private TreeViewItem ContainerFromItem(ItemsControl parent, object item) => (TreeViewItem)parent.ItemContainerGenerator.ContainerFromItem(item);
    }
}
