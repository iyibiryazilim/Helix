using System.Globalization;

namespace Helix.UI.Mobile.Helpers.ImageConverter
{
	public class ByteArrayToImageSourceConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			byte[] bytes;

			if (value != null)
			{
				bytes = System.Convert.FromBase64String(value.ToString());
				ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(bytes));
				return imageSource;
			}
			else
			{
				string resourceName = $"{FileSystem.Current.AppDataDirectory}/Resources/Images/notfoundimage.png";
				ImageSource imageSource = ImageSource.FromFile(resourceName);
				return imageSource;
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
