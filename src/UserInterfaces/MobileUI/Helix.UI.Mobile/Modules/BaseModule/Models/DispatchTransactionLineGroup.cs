using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.Models
{
	public partial class DispatchTransactionLineGroup : ObservableObject
	{
		[ObservableProperty]
		string image;
		[ObservableProperty]
		string code;
		[ObservableProperty]
		string subUnitsetCode;
		[ObservableProperty]
		double stockQuantity;
		[ObservableProperty]
		double? lineQuantity = 0;
		[ObservableProperty]
		string name;
		[ObservableProperty]
		bool isEnabled;
		[ObservableProperty]
		bool isSelected;
		[ObservableProperty]
		ObservableCollection<DispatchTransactionLine> lines = new();
	}
}
