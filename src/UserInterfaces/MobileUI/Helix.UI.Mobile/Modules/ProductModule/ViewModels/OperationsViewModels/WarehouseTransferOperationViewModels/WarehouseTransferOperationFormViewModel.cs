using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Diagnostics;

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

	[RelayCommand]
	async Task GoToSuccessPageViewAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}");
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);

		}
		finally
		{
			IsBusy = false;
		}
	}


}
