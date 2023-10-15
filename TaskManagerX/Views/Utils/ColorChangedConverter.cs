using System.Globalization;
using TaskManagerX.Models;

namespace TaskManagerX.Views.Utils
{
    public class ColorChangedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Color.Parse("Green");
            }
            else
            {
                return Color.Parse("White");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
