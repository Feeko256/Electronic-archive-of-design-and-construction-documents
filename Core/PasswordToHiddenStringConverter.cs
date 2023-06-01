using System;
using System.Globalization;
using System.Windows.Data;

namespace Electronic_archive_of_design_and_construction_documents.Core;

public class PasswordToHiddenStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value != null)
        {
            string password = (string)value;
            return new string('*', password.Length);
        }
        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}