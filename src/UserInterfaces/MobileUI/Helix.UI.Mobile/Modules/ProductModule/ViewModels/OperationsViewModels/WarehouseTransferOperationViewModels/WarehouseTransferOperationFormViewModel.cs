using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(SelectedWarehouse), queryId: nameof(SelectedWarehouse))]
public partial class WarehouseTransferOperationFormViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;


	[ObservableProperty]
	Warehouse warehouse;

	[ObservableProperty]
	Warehouse selectedWarehouse;

	public WarehouseTransferOperationFormViewModel(IHttpClientService httpClientService)
	{
		Title = "Ambar Transfer Formu";
		_httpClientService = httpClientService;
	}


}
