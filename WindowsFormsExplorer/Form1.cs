/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SamplesLibrary;

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
            InitializeTreeviewImages();
            PopulateSampleTree();
        }

        private ImageList _samplesImageList;
        // Index values are image positions in _samplesImageList
        private int _imageIndexEngine = 2;
        private int _imageIndexWindows = 3;
        private int _imageIndexWorkbookView = 4;

        private void InitializeTreeviewImages()
        {
            // TreeView image size vs rendered size doesn't work consistently on low vs high DPI screens.  Use a smaller
            // image list size and actual image size based on DPI of the primary screen to improve rendering.
            var g = CreateGraphics();
            var treeViewImageSize = 32;
            if (g.DpiX <= 96)
            {
                _imageIndexEngine = 5;
                _imageIndexWindows = 6;
                _imageIndexWorkbookView = 7;
                treeViewImageSize = 16;
            }

            _samplesImageList = new ImageList() {
                ColorDepth = ColorDepth.Depth24Bit
            };
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.FolderOpened_32));            // 0
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.FolderClosed_32));            // 1
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.SpreadsheetGearLogo_32));     // 2
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.UserControl_32));             // 3
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.WorkbookView_32));            // 4
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.SpreadsheetGearLogo_16));     // 5
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.UserControl_16));             // 6
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.WorkbookView_16));            // 7

            _samplesImageList.ImageSize = new Size(treeViewImageSize, treeViewImageSize);
            samplesTreeView.ImageList = _samplesImageList;
            samplesTreeView.AfterCollapse += SamplesTreeView_AfterCollapse;
            samplesTreeView.AfterExpand += SamplesTreeView_AfterExpand;
        }

        private void PopulateSampleTree()
        {
            // Build the shared categories and SpreadsheetGear Engine and Windows samples.
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
            var categoryNode = new TreeNode(currentCategory.Name, 0, 0) {
                Tag = currentCategory
            };
            if (currentNode != null)
                currentNode.Nodes.Add(categoryNode);
            else
                samplesTreeView.Nodes.Add(categoryNode);
            foreach (var sampleInfo in currentCategory.SampleInfos)
            {
                int imageIndex;
                if (sampleInfo.IsSpreadsheetGearEngineSample)
                    imageIndex = _imageIndexEngine;
                else
                {
                    if (sampleInfo.UsesWorkbookView)
                        imageIndex = _imageIndexWorkbookView;
                    else
                        imageIndex = _imageIndexWindows;
                }
                int selectedImageIndex = imageIndex;
                var sampleNode = new TreeNode(sampleInfo.Name, imageIndex, selectedImageIndex) {
                    Tag = sampleInfo
                };
                categoryNode.Nodes.Add(sampleNode);
            }
            foreach (var childCategory in currentCategory.ChildCategories)
            {
                BuildTreeView(categoryNode, childCategory);
            }
        }

        private void SamplesTreeView_AfterSelect(object sender, TreeViewEventArgs e)
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

        private void ButtonExpand_Click(object sender, System.EventArgs e)
        {
            samplesTreeView.ExpandAll();
        }

        private void ButtonCollapse_Click(object sender, System.EventArgs e)
        {
            samplesTreeView.CollapseAll();
            samplesTreeView.Nodes[0].Expand();
        }

        private void SamplesTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 0;
            e.Node.SelectedImageIndex = 0;
        }

        private void SamplesTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            e.Node.ImageIndex = 1;
            e.Node.SelectedImageIndex = 1;
        }

    }
}
