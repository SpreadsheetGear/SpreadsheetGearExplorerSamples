
namespace WindowsFormsExplorer.Samples.WorkbookView.CommandManager
{
    partial class CommandRangeSample
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandRangeSample));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar_blue = new System.Windows.Forms.TrackBar();
            this.trackBar_green = new System.Windows.Forms.TrackBar();
            this.trackBar_red = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_colorPreview = new System.Windows.Forms.Panel();
            this.button_undo = new System.Windows.Forms.Button();
            this.button_execute = new System.Windows.Forms.Button();
            this.button_redo = new System.Windows.Forms.Button();
            this.workbookView = new WindowsFormsExplorer.WinFormsWorkbookView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_red)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.workbookView, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(787, 581);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_redo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.trackBar_blue);
            this.panel1.Controls.Add(this.trackBar_green);
            this.panel1.Controls.Add(this.trackBar_red);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel_colorPreview);
            this.panel1.Controls.Add(this.button_undo);
            this.panel1.Controls.Add(this.button_execute);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 577);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(14, 445);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Blue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 355);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Green";
            // 
            // trackBar_blue
            // 
            this.trackBar_blue.Location = new System.Drawing.Point(14, 468);
            this.trackBar_blue.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.trackBar_blue.Maximum = 255;
            this.trackBar_blue.Name = "trackBar_blue";
            this.trackBar_blue.Size = new System.Drawing.Size(170, 69);
            this.trackBar_blue.TabIndex = 9;
            this.trackBar_blue.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // trackBar_green
            // 
            this.trackBar_green.Location = new System.Drawing.Point(14, 378);
            this.trackBar_green.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.trackBar_green.Maximum = 255;
            this.trackBar_green.Name = "trackBar_green";
            this.trackBar_green.Size = new System.Drawing.Size(170, 69);
            this.trackBar_green.TabIndex = 8;
            this.trackBar_green.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // trackBar_red
            // 
            this.trackBar_red.Location = new System.Drawing.Point(14, 292);
            this.trackBar_red.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.trackBar_red.Maximum = 255;
            this.trackBar_red.Name = "trackBar_red";
            this.trackBar_red.Size = new System.Drawing.Size(170, 69);
            this.trackBar_red.TabIndex = 7;
            this.trackBar_red.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 270);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Red";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Color Preview";
            // 
            // panel_colorPreview
            // 
            this.panel_colorPreview.BackColor = System.Drawing.Color.Red;
            this.panel_colorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_colorPreview.Location = new System.Drawing.Point(16, 193);
            this.panel_colorPreview.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel_colorPreview.Name = "panel_colorPreview";
            this.panel_colorPreview.Size = new System.Drawing.Size(171, 60);
            this.panel_colorPreview.TabIndex = 2;
            // 
            // button_undo
            // 
            this.button_undo.Location = new System.Drawing.Point(14, 62);
            this.button_undo.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.button_undo.Name = "button_undo";
            this.button_undo.Size = new System.Drawing.Size(170, 35);
            this.button_undo.TabIndex = 1;
            this.button_undo.Text = "Undo";
            this.button_undo.UseVisualStyleBackColor = true;
            this.button_undo.Click += new System.EventHandler(this.button_undo_Click);
            // 
            // button_execute
            // 
            this.button_execute.Location = new System.Drawing.Point(14, 15);
            this.button_execute.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.button_execute.Name = "button_execute";
            this.button_execute.Size = new System.Drawing.Size(170, 35);
            this.button_execute.TabIndex = 0;
            this.button_execute.Text = "Execute";
            this.button_execute.UseVisualStyleBackColor = true;
            this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
            // 
            // button_redo
            // 
            this.button_redo.Location = new System.Drawing.Point(14, 110);
            this.button_redo.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.button_redo.Name = "button_redo";
            this.button_redo.Size = new System.Drawing.Size(170, 35);
            this.button_redo.TabIndex = 10;
            this.button_redo.Text = "Redo";
            this.button_redo.UseVisualStyleBackColor = true;
            this.button_redo.Click += new System.EventHandler(this.button_redo_Click);
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.FormulaBar = null;
            this.workbookView.Location = new System.Drawing.Point(141, 2);
            this.workbookView.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(409, 300);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // CommandRangeSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "CommandRangeSample";
            this.Size = new System.Drawing.Size(787, 581);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_red)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_colorPreview;
        private System.Windows.Forms.Button button_undo;
        private System.Windows.Forms.Button button_execute;
        private System.Windows.Forms.TrackBar trackBar_blue;
        private System.Windows.Forms.TrackBar trackBar_green;
        private System.Windows.Forms.TrackBar trackBar_red;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_redo;
        private WinFormsWorkbookView workbookView;
    }
}
