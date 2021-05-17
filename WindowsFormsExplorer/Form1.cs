/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System.Windows.Forms;
using SharedSamples;

namespace WindowsFormsExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, System.EventArgs e)
        {
            PopulateSampleTree();
        }


        private void PopulateSampleTree()
        {
            // Build the shared categories and shared (Engine and Windows) samples.
            var categoryRoot = SamplesBuilder.Build();

            // Add in the WinForms-specific samples.
            WinFormsSamplesBuilder.Build(categoryRoot);

            // Build up TreeView items and select the first item.
            foreach (var category in categoryRoot.ChildCategories)
                BuildTreeView(null, category);
            samplesTreeView.ExpandAll();
            samplesTreeView.SelectedNode = samplesTreeView.Nodes[0];
            samplesTreeView.Focus();
        }


        private void BuildTreeView(TreeNode currentNode, Category currentCategory)
        {
            var categoryNode = new TreeNode(currentCategory.Name);
            categoryNode.Tag = currentCategory;
            if (currentNode != null)
                currentNode.Nodes.Add(categoryNode);
            else
                samplesTreeView.Nodes.Add(categoryNode);
            foreach (var sampleInfo in currentCategory.SampleInfos)
            {
                var sampleNode = new TreeNode(sampleInfo.Name);
                sampleNode.Tag = sampleInfo;
                categoryNode.Nodes.Add(sampleNode);
            }
            foreach (var childCategory in currentCategory.ChildCategories)
            {
                BuildTreeView(categoryNode, childCategory);
            }
        }


        private void samplesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var selectedNode = samplesTreeView.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Tag is Category)
                {
                    categorySummaryPane.SetCategory((Category)selectedNode.Tag);
                    categorySummaryPane.Visible = true;
                    sampleContainer.Visible = false;
                    sampleContainer.DisposeCurrentSample();

                }
                else if (selectedNode.Tag is SampleInfo)
                {
                    var sampleInfo = (SampleInfo)selectedNode.Tag;
                    sampleContainer.SetSample(sampleInfo);
                    categorySummaryPane.Visible = false;
                    sampleContainer.Visible = true;
                }
            }
        }


        private void button_expand_Click(object sender, System.EventArgs e)
        {
            samplesTreeView.ExpandAll();
        }


        private void button_collapse_Click(object sender, System.EventArgs e)
        {
            samplesTreeView.CollapseAll();
            samplesTreeView.Nodes[0].Expand();
        }
    }
}
