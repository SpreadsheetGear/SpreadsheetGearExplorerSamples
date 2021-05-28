namespace WPFExplorer.Samples.WorkbookView
{
    public partial class ActiveWorkbookSample : SGUserControl
    {
        // Most code for this Sample is in the SharedSamples project and can be run from either this WpfExplorer
        // project sample or a similar sample in the WindowsFormsExplorer project.
        public SharedSamples.Samples.WorkboookView.ActiveWorkbookSample Sample { get; private set; }

        private void buttonNewWorkbook_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // DisposalManager.ResetWorkbookView(workbookView, false);

            // Call into sample to load a new workbook.
            Sample.NewWorkbook(workbookView);

            // Update TextBox indicating this is a new workbook.
            UpdateLocationTextBox("New Workbook");
        }

        private void buttonLoadDisk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // DisposalManager.ResetWorkbookView(workbookView, false);

            // Create an OpenFileDialog.
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

            // If a file is selected in the dialog...
            if (dialog.ShowDialog() == true)
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
                    System.Windows.MessageBox.Show(ex.Message, "SpreadsheetGear Explorer", System.Windows.MessageBoxButton.OK);
                }
            }
        }

        private async void buttonLoadUriASP_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // DisposalManager.ResetWorkbookView(workbookView, false);
            UriDownloadProgressIndicator.Visibility = System.Windows.Visibility.Visible;

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
                System.Windows.MessageBox.Show(ex.Message, "SpreadsheetGear Explorer", System.Windows.MessageBoxButton.OK);
            }
            finally
            {
                UriDownloadProgressIndicator.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private async void buttonLoadUriXSLX_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // DisposalManager.ResetWorkbookView(workbookView, false);
            UriDownloadProgressIndicator.Visibility = System.Windows.Visibility.Visible;

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
                System.Windows.MessageBox.Show(ex.Message, "SpreadsheetGear Explorer", System.Windows.MessageBoxButton.OK);
            }
            finally
            {
                UriDownloadProgressIndicator.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void UpdateLocationTextBox(string location)
        {
            locationLabel.Content = location;
        }


        #region Sample Initialization Code
        public ActiveWorkbookSample()
        {
            InitializeComponent();
            InitializeSample();
        }

        private void InitializeSample()
        {
            buttonNewWorkbook.Click += buttonNewWorkbook_Click;
            buttonLoadDisk.Click += buttonLoadDisk_Click;
            buttonLoadUriASP.Click += buttonLoadUriASP_Click;
            buttonLoadUriXSLX.Click += buttonLoadUriXSLX_Click;
            Sample = new SharedSamples.Samples.WorkboookView.ActiveWorkbookSample();
            // DisposalManager.RegisterWorkbookViews(workbookView);
        }

        #endregion
    }
}
