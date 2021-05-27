/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;

namespace SamplesLibrary
{
    /// <summary>
    /// Represents a sample whose functionality requires a UI.  The specific UI is open-ended--the implementing sample could 
    /// use WPF or Windows Forms or some other UI framework.  The sample may or may not necessarily use WorkbookView or 
    /// FormulaBar controls and instead just depend on controls or features within the given UI framework itself (buttons, text
    /// boxes, etc.).  See <see cref="ISpreadsheetGearEngineSample"/> for samples that only involve the use of the SpreadsheetGear 
    /// Engine for .NET product, which don't involve UI to run the sample.
    /// </summary>
    public interface ISpreadsheetGearWindowsSample : ISample { }
}
