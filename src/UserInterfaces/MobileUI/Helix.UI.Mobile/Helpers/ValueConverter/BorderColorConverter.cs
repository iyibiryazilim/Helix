using System.Globalization;

namespace Helix.UI.Mobile.Helpers.ValueConverter;

public class BorderColorConverter : IValueConverter
{

	public double TempOnhand { get; set; }
	public double OnHand { get; set; }
	public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
	{
		if (TempOnhand > OnHand)
		{
			return "#2ca57c";  // Success
		}
		else if(TempOnhand < OnHand)
		{
			return "#c1322a"; // Danger
		}

		return "#00000000";  // Transparent
	}

	public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}
