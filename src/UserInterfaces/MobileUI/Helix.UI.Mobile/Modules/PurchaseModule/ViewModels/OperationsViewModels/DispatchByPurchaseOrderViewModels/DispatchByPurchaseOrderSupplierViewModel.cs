using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.DispatchByPurchaseOrderViewModels
{
	public partial class DispatchByPurchaseOrderSupplierViewModel : BaseViewModel
	{
        IPurchaseOrderLineService _purchaseOrderLineService;
		IHttpClientService _httpClientService;

		public ObservableCollection<WaitingOrderLine> Items { get; } = new();

		public Command GetDataCommand { get; }

		public DispatchByPurchaseOrderSupplierViewModel(IPurchaseOrderLineService purchaseOrderLineService,IHttpClientService httpClientService)
        {
            Title = "Tedarikçi Seçimi";

            _purchaseOrderLineService = purchaseOrderLineService;
			_httpClientService = httpClientService;

			GetDataCommand = new Command(async () => await LoadData());

		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				var result = await _purchaseOrderLineService.GetWaitingOrders(_httpClientService.GetOrCreateHttpClient(), "", DataStores.PurchaseOrderLineOrderBy.datedesc, 0, 20);

                foreach (var item in result.Data)
                {
                    var obj = Mapping.Mapper.Map<WaitingOrderLine>(item);
					Items.Add(obj);
                }

            }
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
