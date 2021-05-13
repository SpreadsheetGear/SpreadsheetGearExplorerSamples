using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

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

            if (value is SharedSamples.Category)
            {
                SharedSamples.Category category = (SharedSamples.Category)value;
                Uri uri = null;
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
            if (value is SharedSamples.SampleInfo)
            {
                SharedSamples.SampleInfo sampleInfo = (SharedSamples.SampleInfo)value;
                Uri uri = null;
                if (sampleInfo.IsSharedEngineSample)
                    uri = new Uri("/images/brackets-curly-32.png", UriKind.Relative);
                else
                    uri = new Uri("/images/window-alt-32.png", UriKind.Relative);
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
