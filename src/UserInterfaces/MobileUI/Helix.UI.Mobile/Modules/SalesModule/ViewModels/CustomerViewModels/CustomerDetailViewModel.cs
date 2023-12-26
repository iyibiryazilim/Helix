using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using Microcharts;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	public partial class CustomerDetailViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ICustomerTransactionLineService _customerTransactionLineService;
		ICustomQueryService _services;
		IServiceProvider _serviceProvider;

		[ObservableProperty]
		Customer current;
		public ObservableCollection<CurrentTransactionLine> Items { get; } = new();
		[ObservableProperty]
		LineChart chart = new();
		public Command GetLoadDataCommand { get; }

		//Properties
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		CustomerTransactionLineOrderBy orderBy = CustomerTransactionLineOrderBy.dateasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20;

		public CustomerDetailViewModel(IHttpClientService httpClientService, ICustomQueryService services, ICustomerTransactionLineService customerTransactionLineService, IServiceProvider serviceProvider)
		{
			Title = "Müşteri Detayı";
			_httpClientService = httpClientService;
			_customerTransactionLineService = customerTransactionLineService;
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
				await LoadChartDataAsync();

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
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
				var result = await _customerTransactionLineService.GetTransactionLineByCurrentIdAsync(httpClient, SearchText, OrderBy, Current.ReferenceId, CurrentPage, PageSize);
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
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}

		public async Task LoadChartDataAsync()
		{
			try
			{
				IsBusy = true;
				ChartEntry[] entries = new[]
	   {
			new ChartEntry(212)
			{
				Label = "Windows",
				ValueLabel = "112",
				Color = SKColor.Parse("#2c3e50")
			},
			new ChartEntry(248)
			{
				Label = "Android",
				ValueLabel = "648",
				Color = SKColor.Parse("#77d065")
			},
			new ChartEntry(128)
			{
				Label = "iOS",
				ValueLabel = "428",
				Color = SKColor.Parse("#b455b6")
			},
			new ChartEntry(514)
			{
				Label = ".NET MAUI",
				ValueLabel = "214",
				Color = SKColor.Parse("#3498db")
			}
		};
				Chart.Entries = entries;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
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

				CustomerShowMoreBottomSheetViewModel viewModel = _serviceProvider.GetService<CustomerShowMoreBottomSheetViewModel>();

				CustomerShowMoreBottomSheetView sheet = new CustomerShowMoreBottomSheetView(viewModel);
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

				CustomerFastOperationBottomSheetViewModel viewModel = _serviceProvider.GetService<CustomerFastOperationBottomSheetViewModel>();

				CustomerFastOperationBottomSheetView sheet = new CustomerFastOperationBottomSheetView(viewModel);
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
