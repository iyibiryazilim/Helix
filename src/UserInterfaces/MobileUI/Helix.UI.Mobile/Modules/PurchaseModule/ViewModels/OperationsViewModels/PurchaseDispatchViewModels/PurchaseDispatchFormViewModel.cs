using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;

[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]
public partial class PurchaseDispatchFormViewModel : BaseViewModel
{
	[ObservableProperty]
	ObservableCollection<ProductModel> productModel;

	public PurchaseDispatchFormViewModel()
	{
		Title = "Mal Kabul Formu";
	}
}
