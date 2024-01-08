using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WarehouseTransferOperationViewModels;

public partial class WarehouseTransferOperationViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	public WarehouseTransferOperationViewModel(IHttpClientService httpClientService)
	{
		Title = "Ambar Transfer İşlemleri";
		_httpClientService = httpClientService;
	}
}
