using System;
using System.Globalization;
using Avalonia.Data.Converters;

public class ColumnCountConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        double width = (double)value;
        int columnWidth = 250; // adjust this value to your desired column width
        int columns = (int)Math.Floor(width / columnWidth);
        return columns;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}