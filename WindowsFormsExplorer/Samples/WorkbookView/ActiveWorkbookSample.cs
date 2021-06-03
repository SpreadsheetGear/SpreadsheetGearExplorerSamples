using System;
using System.Windows.Forms;

namespace WindowsFormsExplorer.Samples.WorkbookView
{
    public partial class ActiveWorkbookSample : SampleUserControl
    {
        // Most code for this Sample is in the SamplesLibrary project and can be run from either this WindowsFormsExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SamplesLibrary.Samples.WorkboookView.ActiveWorkbookSample Sample { get; private set; }

        private void button_newWorkbook_Click(object sender, EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView, false);

            // Call into sample to load a new workbook.
            Sample.NewWorkbook(workbookView);

            // Update TextBox indicating this is a new workbook.
            UpdateLocationTextBox("New Workbook");
        }

        private void button_loadDisk_Click(object sender, EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView, false);

            // Create an OpenFileDialog.
            OpenFileDialog dialog = new OpenFileDialog();

            // If a file is selected in the dialog...
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
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

        private async void button_loadUriAsp_Click(object sender, EventArgs e)
        {
            DisposalManager.ResetWorkbookView(workbookView, false);
            progressBar.Visible = true;

            try
            {
                // Clear out location box value.
                UpdateLocationTextBox("");

                // Call into sample to load workbook from a URI that dynamically generates an Excel file.
                string uri = await Sample.LoadFromUri_RazorPage(workbookView);

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

        private async void button_loadUriXLSX_Click(object sender, EventArgs e)
        {
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
