using System;
using System.Windows.Forms;

namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class ActiveWorkbookSample : SampleUserControl
    {
        // Most of the relevant SpreadsheetGear code for this sample is in this member's class, located within the
        // SamplesLibrary project.  It is shared sample code that can be run from this WindowsFormsExplorer samples 
        // app as well as the WPFExplorer samples app.
        public SamplesLibrary.Samples.WorkboookView.ActiveWorkbookSample Sample { get; private set; }

        private void ButtonNewWorkbook_Click(object sender, EventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView.  Disposal of 
            /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
            /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
            /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
            /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
            DisposalManager.ResetWorkbookView(workbookView, false);

            // Call into sample to load a new workbook.
            Sample.NewWorkbook(workbookView);

            // Update TextBox indicating this is a new workbook.
            UpdateLocationTextBox("New Workbook");
        }

        private void ButtonLoadDisk_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog.
            OpenFileDialog dialog = new OpenFileDialog();

            // If a file is selected in the dialog...
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView.  Disposal of 
                    /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
                    /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
                    /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
                    /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
                    DisposalManager.ResetWorkbookView(workbookView, false);

                    // Call into sample to load workbook from file specified in dialog.
                    Sample.LoadFromDisk(workbookView, dialog.FileName);

                    // Update TextBox indicating opened file's path.
                    UpdateLocationTextBox(dialog.FileName);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "SpreadsheetGear Explorer", MessageBoxButtons.OK);
                }
            }
        }

        private async void ButtonLoadUriAsp_Click(object sender, EventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView.  Disposal of 
            /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
            /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
            /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
            /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
            DisposalManager.ResetWorkbookView(workbookView, false);
            progressBar.Visible = true;

            try
            {
                // Clear out location box value.
                UpdateLocationTextBox("");

                // Call into sample to load workbook from a URI that dynamically generates an Excel file.
                string uri = await Sample.LoadFromUri_AspNetGenerated(workbookView);

                // Update TextBox indicating it the URI it was loaded from.
                UpdateLocationTextBox(uri);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "SpreadsheetGear Explorer", MessageBoxButtons.OK);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        private async void ButtonLoadUriXLSX_Click(object sender, EventArgs e)
        {
            /// Disposes of the IWorkbookSet (and IWorkbook objects contained within it) used by the WorkbookView.  Disposal of 
            /// old workbooks is necessary when using SpreadsheetGear in the "Free" mode, which has a 3 workbook limit.  If you 
            /// are copying and pasting this sample code to your own projects and have a Signed License that activates either the 
            /// fully-licensed or 30-day evaluation mode of the software, then this workbook disposal strategy is not needed. See 
            /// the comments in the <see cref="SamplesLibrary.SGDisposalManager"/> code file for more details.
            DisposalManager.ResetWorkbookView(workbookView, false);
            progressBar.Visible = true;

            try
            {
                // Clear out location box value.
                UpdateLocationTextBox("");

                // Call into sample to load workbook from a URI that points to an Excel file.
                string uri = await Sample.LoadFromUri_XSLX(workbookView);

                // Update TextBox indicating it the URI it was loaded from.
                UpdateLocationTextBox(uri);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "SpreadsheetGear Explorer", MessageBoxButtons.OK);
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        private void UpdateLocationTextBox(string location)
        {
            locationLabel.Text = location;
        }

        #region Sample Initialization Code
        public ActiveWorkbookSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            Sample = new SamplesLibrary.Samples.WorkboookView.ActiveWorkbookSample();
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }
}
