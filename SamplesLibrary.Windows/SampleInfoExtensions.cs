/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

namespace SamplesLibrary.Windows
{
    public static class SampleInfoExtensions
    {
        public static bool IsSpreadsheetGearWindowsSample(this SampleInfo sampleInfo)
        {
            return typeof(ISpreadsheetGearWindowsSample).IsAssignableFrom(sampleInfo.SampleType);
        }
    }
}
