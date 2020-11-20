using System;
using System.Globalization;
using Xamarin.Forms;

namespace EZMedChatMobile.Converters
{
    public class BooleanToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var iconColor = Color.Gray;

            if (!(value is Boolean))
            {
                return value;
            }

            if ((Boolean)value)
            {
                iconColor = Color.Green;
            }

            return iconColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
