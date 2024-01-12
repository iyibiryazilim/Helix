using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
	public partial class TransferTransactionModel : ObservableObject
	{
		[ObservableProperty]
		Warehouse entryWarehouse;
		[ObservableProperty]
		Warehouse exitWarehouse;
		[ObservableProperty]
		ObservableCollection<TransferTransactionProduct> products;
		 
	}
}
