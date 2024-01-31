using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.SalesModule.Models;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Models
{
	public partial class PurchaseFormModel : ObservableObject
	{
		[ObservableProperty]
		string purchaseDispatch;

		[ObservableProperty]
		DateTime transactionDate = DateTime.Now;

		[ObservableProperty]
		TimeSpan transactionTime = DateTime.Now.TimeOfDay;

		[ObservableProperty]
		Customer customer;

		[ObservableProperty]
		string driver;

		[ObservableProperty]
		string speCode;

		[ObservableProperty]
		string description;
	}
}
