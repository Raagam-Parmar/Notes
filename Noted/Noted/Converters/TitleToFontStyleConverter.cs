using System;

using Microsoft.UI.Xaml.Data;

using Windows.UI.Text;

namespace Noted.Converters;

public partial class TitleToFontStyleConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        return value is string title && string.IsNullOrEmpty(title)
            ? FontStyle.Italic
            : FontStyle.Normal;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
