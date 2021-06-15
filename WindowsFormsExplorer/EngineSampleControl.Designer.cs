
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
            this.buttonResetSample = new System.Windows.Forms.Button();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.buttonRunSample = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonRunSample);
            this.panel2.Controls.Add(this.buttonResetSample);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 1132);
            this.panel2.TabIndex = 0;
            // 
            // buttonResetSample
            // 
            this.buttonResetSample.Location = new System.Drawing.Point(23, 103);
            this.buttonResetSample.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonResetSample.Name = "buttonResetSample";
            this.buttonResetSample.Size = new System.Drawing.Size(246, 54);
            this.buttonResetSample.TabIndex = 1;
            this.buttonResetSample.Text = "Reset Sample";
            this.buttonResetSample.UseVisualStyleBackColor = true;
            this.buttonResetSample.Click += new System.EventHandler(this.ButtonResetSample_Click);
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
            // buttonRunSample
            // 
            this.buttonRunSample.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRunSample.Location = new System.Drawing.Point(23, 19);
            this.buttonRunSample.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRunSample.Name = "buttonRunSample";
            this.buttonRunSample.Size = new System.Drawing.Size(246, 54);
            this.buttonRunSample.TabIndex = 0;
            this.buttonRunSample.Text = "Run Sample";
            this.buttonRunSample.UseVisualStyleBackColor = true;
            this.buttonRunSample.Click += new System.EventHandler(this.ButtonRunSample_Click);
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
        private System.Windows.Forms.Button buttonResetSample;
        private WinFormsWorkbookView workbookView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonRunSample;
    }
}
