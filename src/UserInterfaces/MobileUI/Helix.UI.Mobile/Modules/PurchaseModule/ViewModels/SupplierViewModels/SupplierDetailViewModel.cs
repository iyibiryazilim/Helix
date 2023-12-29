using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.BaseModule.ViewModels;
using Helix.UI.Mobile.Modules.BaseModule.Views;
using Helix.UI.Mobile.Modules.PurchaseModule.DataStores;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Services;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.SupplierViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	public partial class SupplierDetailViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ISupplierTransactionLineService _SupplierTransactionLineService;
		ICustomQueryService _services;
		IServiceProvider _serviceProvider;

		[ObservableProperty]
		Supplier current;
		public ObservableCollection<CurrentTransactionLine> Items { get; } = new();
		//[ObservableProperty]
		//LineChart chart = new();
		public Command GetLoadDataCommand { get; }

		//Properties
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		SupplierTransactionLineOrderBy orderBy = SupplierTransactionLineOrderBy.datedesc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20;

		public SupplierDetailViewModel(IHttpClientService httpClientService, ICustomQueryService services, ISupplierTransactionLineService SupplierTransactionLineService, IServiceProvider serviceProvider)
		{
			Title = "Tedarikçi Detayı";
			_httpClientService = httpClientService;
			_SupplierTransactionLineService = SupplierTransactionLineService;
			_services = services;

			GetLoadDataCommand = new Command(async () => await LoadData());
			_serviceProvider = serviceProvider;
		}

		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetLastTransactionsAsync);

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

		public async Task GetLastTransactionsAsync()
		{

			try
			{
				IsBusy = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				CurrentPage = 0;
				var result = await _SupplierTransactionLineService.GetTransactionLineByCurrentIdAsync(httpClient, SearchText, OrderBy, Current.ReferenceId, CurrentPage, PageSize);
				if (result.Data.Any())
				{
					Items.Clear();
					foreach (var item in result.Data.Take(3))
					{
						await Task.Delay(20);
						Items.Add(item);
					}
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
				IsRefreshing = false;
			}
		}


		[RelayCommand]
		async Task GoToBackAsync()
		{
			await Shell.Current.GoToAsync("..");
		}

		[RelayCommand]
		async Task OpenShowMoreBottomSheetAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;

				CurrentShowMoreBottomSheetViewModel viewModel = _serviceProvider.GetService<CurrentShowMoreBottomSheetViewModel>();
				viewModel.Current = Current;
				CurrentShowMoreBottomSheetView sheet = new CurrentShowMoreBottomSheetView(viewModel);
				await sheet.ShowAsync();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}

		[RelayCommand]
		async Task OpenFastOperationBottomSheetAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;

				SupplierFastOperationBottomSheetViewModel viewModel = _serviceProvider.GetService<SupplierFastOperationBottomSheetViewModel>();
				viewModel.Current = Current;

				SupplierFastOperationBottomSheetView sheet = new SupplierFastOperationBottomSheetView(viewModel);
				await sheet.ShowAsync();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
			}
			finally
			{
				IsBusy = false;
			}
		}
	}
}
