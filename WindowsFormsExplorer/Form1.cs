﻿/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            InitializeTreeviewImages();
            PopulateSampleTree();
        }

        private ImageList _samplesImageList;
        // index values below are image position in _samplesImageList
        private const int EngineImageIndex = 2; // brackets_curly_32
        private const int WindowsImageIndex = 3; // window_alt_32

        private void InitializeTreeviewImages()
        {
            _samplesImageList = new ImageList();
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.FolderOpened_32));
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.FolderClosed_32));
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.brackets_curly_32));
            _samplesImageList.Images.Add(new Bitmap(WindowsFormsExplorer.Properties.Resources.window_alt_32));
            _samplesImageList.ImageSize = new Size(32, 32); // increase size from 16x16 deafault
            samplesTreeView.ImageList = _samplesImageList;
            samplesTreeView.AfterCollapse += SamplesTreeView_AfterCollapse;
            samplesTreeView.AfterExpand += SamplesTreeView_AfterExpand;
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
            var categoryNode = new TreeNode(currentCategory.Name, 0, 0);
            categoryNode.Tag = currentCategory;
            if (currentNode != null)
                currentNode.Nodes.Add(categoryNode);
            else
                samplesTreeView.Nodes.Add(categoryNode);
            foreach (var sampleInfo in currentCategory.SampleInfos)
            {
                int imageIndex = sampleInfo.IsSharedEngineSample ? EngineImageIndex : WindowsImageIndex;
                int selectedImageIndex = imageIndex;
                var sampleNode = new TreeNode(sampleInfo.Name, imageIndex, selectedImageIndex);
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
