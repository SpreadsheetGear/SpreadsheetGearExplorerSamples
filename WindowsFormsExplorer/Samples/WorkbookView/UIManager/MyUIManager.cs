using System;
using System.Windows.Forms;

namespace WindowsFormsExplorer.Samples.WorkbookView.UIManager
{
    // UIManager replacement class.
    public class MyUIManager : SpreadsheetGear.Windows.Forms.UIManager
    {
        private Button _customControl = null;

        public MyUIManager(SpreadsheetGear.IWorkbookSet workbookSet)
            : base(workbookSet)
        { }

        // Override to substitute a custom control for any existing shape in the worksheet.  
        // This method is called when a control is displayed within the WorkbookView.
        public override System.Windows.Forms.Control CreateCustomControl(SpreadsheetGear.Shapes.IShape shape)
        {
            // If the shape name matches...
            if (shape.Name == "MyCustomControl")
            {
                // Create a custom control and set various properties.
                _customControl = new Button {
                    Text = "My Custom Button"
                };

                // Add a Click event handler.
                _customControl.Click += new EventHandler(CustomControl_Click);

                // Add an event handler so that we know when the control 
                // has been disposed.  The control will be disposed when
                // it is no longer in the viewable area of the WorkbookView.
                _customControl.Disposed += new EventHandler(CustomControl_Disposed);

                return _customControl;
            }
            return base.CreateCustomControl(shape);
        }

        private void CustomControl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Custom Control was Clicked!");
        }

        private void CustomControl_Disposed(object sender, EventArgs e)
        {
            // Add any cleanup code here...

            // Set the custom control reference to null.
            _customControl = null;
        }
    }
}
