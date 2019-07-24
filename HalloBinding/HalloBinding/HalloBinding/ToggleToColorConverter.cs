using System;
using System.Globalization;
using Xamarin.Forms;

namespace HalloBinding
{
    class ToggleToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Color.HotPink;

            return Color.Azure;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
