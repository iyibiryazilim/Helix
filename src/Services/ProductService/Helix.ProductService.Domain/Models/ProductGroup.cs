using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Helix.ProductService.Domain.Models
{
	public class ProductGroup : INotifyPropertyChanged
	{
		string? groupDefinition;
		public string? GroupDefinition
		{
			get => groupDefinition;
			set
			{
				groupDefinition = value;
				NotifyPropertyChanged();
			}
		}


		string? groupCode;
		public string? GroupCode
		{
			get => groupCode;
			set
			{
				groupCode = value;
				NotifyPropertyChanged();
			}
		}

		public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler? PropertyChanged;

	}
}
