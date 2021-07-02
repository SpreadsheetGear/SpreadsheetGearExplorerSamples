using System.Windows;
using System.Windows.Controls;

namespace WPFExplorer.Samples.WorkbookView.UIManager
{
    public partial class CustomControlSample : SampleUserControl
    {
        public CustomControlSample()
        {
            InitializeComponent();
            InitializeSample();

            // Create an instance of the UIManager and pass in the IWorkbookSet currently
            // attached to the WorkbookView.  UIManager's constructor will do all the 
            // plumbing to get this UIManager instance to also attach to the WorkbookView.
            new MyUIManager(workbookView.ActiveWorkbookSet);
        }

        private void RunSample()
        {
            // NOTE: Must acquire a workbook set lock.
            workbookView.GetLock();
            try
            {
                // Get the active worksheet.
                SpreadsheetGear.IWorksheet worksheet = workbookView.ActiveWorksheet;

                // Run sample just once.
                if (worksheet.Shapes.Count == 0)
                {
                    // Add a Rectangle AutoShape with a name that matches what the UIManager
                    // needs in order to replace it.
                    SpreadsheetGear.Shapes.IShape shape1 = worksheet.Shapes.AddShape(
                        SpreadsheetGear.Shapes.AutoShapeType.Rectangle, 5, 5, 100, 35);
                    shape1.Name = "MyCustomControl";

                    // Add a second Rectangle with a different name that won't match what the
                    // UIManager needs, thereby not replacing it.
                    SpreadsheetGear.Shapes.IShape shape2 = worksheet.Shapes.AddShape(
                        SpreadsheetGear.Shapes.AutoShapeType.Rectangle, 5, 50, 100, 35);
                    shape2.Name = "SomeOtherName";
                }
            }
            finally
            {
                // NOTE: Must release the workbook set lock.
                workbookView.ReleaseLock();
            }
        }

        private void ButtonRunSample_Click(object sender, RoutedEventArgs e)
        {
            RunSample();
        }

        #region Sample Initialization Code
        public void InitializeSample()
        {
            DisposalManager.RegisterWorkbookViews(workbookView);
        }
        #endregion
    }

    // UIManager replacement class.
    public class MyUIManager : SpreadsheetGear.Windows.Controls.UIManager
    {
        private Button _customControl = null;

        public MyUIManager(SpreadsheetGear.IWorkbookSet workbookSet)
            : base(workbookSet)
        { }

        // Override to substitute a custom control for any existing shape in the worksheet.  
        // This method is called when a control is displayed within the WorkbookView.
        public override FrameworkElement CreateCustomControl(SpreadsheetGear.Shapes.IShape shape)
        {
            // If the shape name matches...
            if (shape.Name == "MyCustomControl")
            {
                // Create a custom control and set various properties.
                _customControl = new Button {
                    Content = "My Custom Button"
                };

                // Add a Click event handler.
                _customControl.Click += CustomControl_Click;
                // Add an event handler so that we know when the control 
                // has been unloaded.  The control will be unloaded when
                // it is no longer in the viewable area of the WorkbookView.
                _customControl.Unloaded += CustomControl_Unloaded;

                return _customControl;
            }
            return base.CreateCustomControl(shape);
        }

        private void CustomControl_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Custom Control was Clicked!");
        }

        private void CustomControl_Unloaded(object sender, RoutedEventArgs e)
        {
            // Add any cleanup code here...
            System.Diagnostics.Debug.WriteLine("Unloaded");
            // Set the custom control reference to null.
            _customControl = null;
        }
    }
}
