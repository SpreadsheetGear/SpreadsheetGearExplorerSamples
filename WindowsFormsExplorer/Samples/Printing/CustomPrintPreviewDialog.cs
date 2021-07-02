using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace WindowsFormsExplorer.Samples.Printing
{
    /// <summary>
    /// Provides a custom print preview form.
    /// </summary>
    public partial class CustomPrintPreviewDialog : Form
    {
        private int _pageCount;

        public CustomPrintPreviewDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets a value indicating the document to preview.
        /// </summary>
        public PrintDocument Document
        {
            get
            {
                return PrintPreviewControl.Document;
            }
            set
            {
                if (PrintPreviewControl.Document != value)
                {
                    PrintPreviewControl.Document = value;
                    value.BeginPrint += new PrintEventHandler(PrintDocument_BeginPrint);
                    value.EndPrint += new PrintEventHandler(PrintDocument_EndPrint);
                    value.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating the System.Windows.Forms.PrintPreviewControl 
        /// contained in this form.
        /// </summary>
        public PrintPreviewControl PrintPreviewControl
        {
            get
            {
                return printPreviewControl;
            }
        }

        /// <summary>
        /// Overridden to allow for specialized processing of key events.
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    // If the Escape key is used then close the dialog and
                    // return true to avoid further processing of the key.
                    this.Close();
                    return true;
            }
            // Call the base class implementation.
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// Gets a value indicating whether there is a previous page to view.
        /// </summary>
        private bool HasPreviousPage
        {
            get
            {
                return PrintPreviewControl.StartPage > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether there is a next page to view.
        /// </summary>
        private bool HasNextPage
        {
            get
            {
                return _pageCount > (PrintPreviewControl.StartPage + 1);
            }
        }

        /// <summary>
        /// Enables and disables previous and next page buttons.
        /// </summary>
        private void CheckPageStatus()
        {
            toolStripButtonPreviousPage.Enabled = HasPreviousPage;
            toolStripButtonNextPage.Enabled = HasNextPage;
        }

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            // Initialize the page count.
            _pageCount = 0;
        }

        private void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            // Call routine to enable or disable previous and next page buttons.
            CheckPageStatus();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Increment the page count.
            _pageCount++;
        }

        private void PrintPreviewControl_StartPageChanged(object sender, EventArgs e)
        {
            // Call routine to enable or disable previous and next page buttons.
            CheckPageStatus();
        }

        private void ToolStripButtonPrint_Click(object sender, EventArgs e)
        {
            // Create a print dialog.
            System.Windows.Forms.PrintDialog dialog = new System.Windows.Forms.PrintDialog {
                // Set the print dialogs print document.
                Document = Document
            };

            // Show the print dialog and check the return status...
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                // Print the document.
                Document.Print();
            }
        }

        private void ToolStripButtonZoom_Click(object sender, EventArgs e)
        {
            if (toolStripButtonZoom.Checked)
            {
                // Zoom to 100%
                PrintPreviewControl.AutoZoom = false;
                PrintPreviewControl.Zoom = 1.0;
            }
            else
            {
                // Zoom is automatically determined.
                PrintPreviewControl.AutoZoom = true;
            }
        }

        private void ToolStripButtonPreviousPage_Click(object sender, EventArgs e)
        {
            // Decrement the start page if possible.
            if (HasPreviousPage)
                PrintPreviewControl.StartPage -= 1;
        }

        private void ToolStripButtonNextPage_Click(object sender, EventArgs e)
        {
            // Increment the start page if possible.
            if (HasNextPage)
                PrintPreviewControl.StartPage += 1;
        }

        private void ToolStripButtonClose_Click(object sender, EventArgs e)
        {
            // Close the print preview dialog.
            this.Close();
        }
    }
}