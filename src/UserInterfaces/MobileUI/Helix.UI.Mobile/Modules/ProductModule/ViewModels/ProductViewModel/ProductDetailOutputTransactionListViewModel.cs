using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

[QueryProperty(name: nameof(Product), queryId: nameof(Product))]
public partial class ProductDetailOutputTransactionListViewModel : BaseViewModel
{
	[ObservableProperty]
	Product product;
	public ProductDetailOutputTransactionListViewModel()
	{
		Title = "Çıkış Hareketleri";
	}
}
