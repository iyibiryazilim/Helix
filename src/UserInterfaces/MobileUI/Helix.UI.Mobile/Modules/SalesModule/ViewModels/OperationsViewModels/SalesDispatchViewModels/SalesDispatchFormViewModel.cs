using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;

[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]
public partial class SalesDispatchFormViewModel : BaseViewModel
{
	IHttpClientService _httpClient;

	[ObservableProperty]
	ObservableCollection<ProductModel> productModel;

	public SalesDispatchFormViewModel(IHttpClientService httpClient, IWarehouseService warehouseService)
	{
		Title = "Sevk Formu";
		_httpClient = httpClient;
	}


}
