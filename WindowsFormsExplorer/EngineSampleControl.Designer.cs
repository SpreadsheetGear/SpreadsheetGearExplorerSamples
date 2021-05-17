
namespace WindowsFormsExplorer
{
    partial class EngineSampleControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineSampleControl));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_resetSample = new System.Windows.Forms.Button();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.button_runSample = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_runSample);
            this.panel2.Controls.Add(this.button_resetSample);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 1132);
            this.panel2.TabIndex = 0;
            // 
            // button_resetSample
            // 
            this.button_resetSample.Location = new System.Drawing.Point(23, 103);
            this.button_resetSample.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_resetSample.Name = "button_resetSample";
            this.button_resetSample.Size = new System.Drawing.Size(246, 54);
            this.button_resetSample.TabIndex = 1;
            this.button_resetSample.Text = "Reset Sample";
            this.button_resetSample.UseVisualStyleBackColor = true;
            this.button_resetSample.Click += new System.EventHandler(this.button_resetSample_Click);
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(296, 0);
            this.workbookView.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(1146, 1132);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // button_runSample
            // 
            this.button_runSample.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_runSample.Location = new System.Drawing.Point(23, 19);
            this.button_runSample.Margin = new System.Windows.Forms.Padding(2);
            this.button_runSample.Name = "button_runSample";
            this.button_runSample.Size = new System.Drawing.Size(246, 54);
            this.button_runSample.TabIndex = 0;
            this.button_runSample.Text = "Run Sample";
            this.button_runSample.UseVisualStyleBackColor = true;
            this.button_runSample.Click += new System.EventHandler(this.button_runSample_Click);
            // 
            // EngineSampleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.workbookView);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EngineSampleControl";
            this.Size = new System.Drawing.Size(1442, 1132);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_resetSample;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_runSample;
    }
}
