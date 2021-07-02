/*
* Copyright © SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear® is a registered trademark of SpreadsheetGear LLC.
*/

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using SamplesLibrary;

/// <summary>
/// This file contains all the IValueConverter classes used by WPFExplorer
/// </summary>
namespace WPFExplorer
{
    class CategoryImageConverter : IValueConverter
    {
        public static CategoryImageConverter Instance = new CategoryImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SamplesLibrary.Category)
            {
                Category category = (Category)value;
                Uri uri;
                if (category.IsExpanded)
                    uri = new Uri("/images/FolderOpened-32.png", UriKind.Relative);
                else
                    uri = new Uri("/images/FolderClosed-32.png", UriKind.Relative);
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }


    class SampleInfoImageConverter : IValueConverter
    {
        public static SampleInfoImageConverter Instance = new SampleInfoImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is SampleInfo)
            {
                SampleInfo sampleInfo = (SampleInfo)value;
                Uri uri;
                if (sampleInfo.IsSpreadsheetGearEngineSample)
                    uri = new Uri("/SpreadsheetGearLogo.ico", UriKind.Relative);
                else
                {
                    if (sampleInfo.UsesWorkbookView)
                        uri = new Uri("/images/WorkbookView-32.png", UriKind.Relative);
                    else
                        uri = new Uri("/images/UserControl-32.png", UriKind.Relative);
                }
                BitmapImage source = new BitmapImage(uri);
                return source;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

}
