using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Helpers.Queries;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.PanelViewModels
{
	public partial class PurchasePanelViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ICustomQueryService _customQueryService;

		public ObservableCollection<Supplier> Suppliers { get; } = new();
		public ObservableCollection<SupplierTransactionLine> Lines { get; } = new();

		public Command GetDataCommand { get; }

		public PurchasePanelViewModel(ICustomQueryService customQueryService, IHttpClientService httpClientService)
		{
			_customQueryService = customQueryService;
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
				//await MainThread.InvokeOnMainThreadAsync(ReloadAsync());
				await GetTopSuppliersAsync();
				await GetLastTransactionsAsync();

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}
		async Task GetTopSuppliersAsync()
		{
			try
			{
				IsBusy = true;
				Suppliers.Clear();

				var result = await _customQueryService.GetObjectsAsync(_httpClientService.GetOrCreateHttpClient(), new SupplierQuery().GetTopSuppliers());
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<Supplier>(item);
					if (obj.Image == "{}")
					{
						obj.Image = null;
					}
					Suppliers.Add(obj);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}

		}

		async Task GetLastTransactionsAsync()
		{
			try
			{
				IsBusy = true;
				Lines.Clear();
				var result = await _customQueryService.GetObjectsAsync(_httpClientService.GetOrCreateHttpClient(), new SupplierQuery().GetLastPurchaseLines());
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<SupplierTransactionLine>(item);

					Lines.Add(obj);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
			}

		}

		[RelayCommand]
		async Task GoToDetailAsync(Supplier current)
		{
			try
			{
				await Task.Delay(500);
				await Shell.Current.GoToAsync($"{nameof(SupplierDetailView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = current
				});
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
			}
		}
	}
}
