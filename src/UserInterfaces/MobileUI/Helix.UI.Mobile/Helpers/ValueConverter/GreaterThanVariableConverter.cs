namespace Helix.UI.Mobile.Helpers.ValueConverter
{
    public class GreaterThanVeriableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double lineQuantity)
            {
                return lineQuantity > Cutoff;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public int Cutoff { get; set; }
    }
}
