using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Electronic_archive_of_design_and_construction_documents.Core;

public class PathToFileNameConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string path = value as string;
        if (path == null)
            return null;
        return Path.GetFileName(path);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}