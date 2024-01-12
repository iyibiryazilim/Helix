using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
	public partial class TransferTransactionProduct : ObservableObject
	{
		[ObservableProperty]
		Product entryProduct;
		[ObservableProperty]
		Product exitProduct;
	}
}
