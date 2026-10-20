using System;

using Microsoft.UI.Xaml.Data;

namespace Noted.Converters;

public partial class TitleToDisplayTitleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value is string title && string.IsNullOrEmpty(title)
            ? "Untitled"
            : value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
