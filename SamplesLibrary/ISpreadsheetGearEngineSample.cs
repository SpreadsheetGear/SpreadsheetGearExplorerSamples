/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

namespace SamplesLibrary
{
    /// <summary>
    /// Base interface for all samples that demonstrate features of the SpreadsheetGear Engine for .NET product.
    /// See <see cref="ISpreadsheetGearWindowsSample"/> for samples that might also demonstrate features involving UI,
    /// such as the WorkbookView or FormulaBar controls.
    /// </summary>
    public interface ISpreadsheetGearEngineSample : ISample
    {
        /// <summary>
        /// The results of the sample are stored in this property, which can be attached to a WorkbookView
        /// to display the end-user, saved out to disk, etc.
        /// </summary>
        public SpreadsheetGear.IWorkbook Workbook { get; set; }

        /// <summary>
        /// Provides an opportunity to setup <see cref="Workbook"/> with the desired workbook before the
        /// <see cref="RunSample"/> method is called.
        /// </summary>
        public void InitializeWorkbook() { }

        /// <summary>
        /// Call this to execute the sample.  Results should be stored in the <see cref="Workbook"/> property.
        /// </summary>
        public void RunSample() { }
    }
}
