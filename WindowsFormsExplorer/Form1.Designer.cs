
namespace WindowsFormsExplorer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.samplesTreeView = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_launchWPFExplorer = new System.Windows.Forms.Button();
            this.sampleContainer = new WindowsFormsExplorer.SampleContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // samplesTreeView
            // 
            this.samplesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.samplesTreeView.HideSelection = false;
            this.samplesTreeView.Location = new System.Drawing.Point(0, 0);
            this.samplesTreeView.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.samplesTreeView.Name = "samplesTreeView";
            this.samplesTreeView.Size = new System.Drawing.Size(175, 529);
            this.samplesTreeView.TabIndex = 0;
            this.samplesTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.samplesTreeView_AfterSelect);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.sampleContainer);
            this.splitContainer1.Size = new System.Drawing.Size(1057, 576);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.samplesTreeView);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 576);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_launchWPFExplorer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 529);
            this.panel2.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 47);
            this.panel2.TabIndex = 1;
            // 
            // button_launchWPFExplorer
            // 
            this.button_launchWPFExplorer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_launchWPFExplorer.Location = new System.Drawing.Point(1, 11);
            this.button_launchWPFExplorer.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.button_launchWPFExplorer.Name = "button_launchWPFExplorer";
            this.button_launchWPFExplorer.Size = new System.Drawing.Size(173, 26);
            this.button_launchWPFExplorer.TabIndex = 2;
            this.button_launchWPFExplorer.Text = "Launch WPF Explorer";
            this.button_launchWPFExplorer.UseVisualStyleBackColor = true;
            this.button_launchWPFExplorer.Click += new System.EventHandler(this.button_launchWPFExplorer_Click);
            // 
            // sampleContainer
            // 
            this.sampleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleContainer.Location = new System.Drawing.Point(0, 0);
            this.sampleContainer.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.sampleContainer.Name = "sampleContainer";
            this.sampleContainer.Size = new System.Drawing.Size(878, 576);
            this.sampleContainer.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 576);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SpreadsheetGear - Windows Forms Explorer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView samplesTreeView;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private SampleContainer sampleContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_launchWPFExplorer;
    }
}

