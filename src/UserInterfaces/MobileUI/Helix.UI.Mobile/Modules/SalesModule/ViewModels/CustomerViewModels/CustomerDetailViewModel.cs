using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.BaseModule.ViewModels;
using Helix.UI.Mobile.Modules.BaseModule.Views;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.CustomerViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
	public partial class CustomerDetailViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		ICustomerTransactionLineService _customerTransactionLineService;
		ICustomQueryService _customQueryservice;
		IServiceProvider _serviceProvider;

		[ObservableProperty]
		Customer current;
		public ObservableCollection<CurrentTransactionLine> Items { get; } = new();
        public ObservableCollection<Product> TopProducts { get; } = new();

        //[ObservableProperty]
        //LineChart chart = new();
        public Command GetLoadDataCommand { get; }

		//Properties
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		CustomerTransactionLineOrderBy orderBy = CustomerTransactionLineOrderBy.datedesc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 20;

		[ObservableProperty]
		string subTitle;

        public CustomerDetailViewModel(IHttpClientService httpClientService, ICustomQueryService customQueryService, ICustomerTransactionLineService customerTransactionLineService, IServiceProvider serviceProvider)
		{
			Title = "Müşteri Detayı";
			SubTitle = "En Çok Satış Yapılan Ürünler";
			_httpClientService = httpClientService;
			_customerTransactionLineService = customerTransactionLineService;
			_customQueryservice = customQueryService;

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
				await Task.WhenAll(GetLastTransactionsAsync(), GetTopSalesProductsAsync());
 
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
					foreach (var item in result.Data.Take(5))
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

        public async Task GetTopSalesProductsAsync()
        {

            try
            {
                IsBusy = true;
                var httpClient = _httpClientService.GetOrCreateHttpClient();

                CurrentPage = 0;
				var query = new CustomerQuery().GetTopSalesProducts(Current.ReferenceId);
                var result = await _customQueryservice.GetObjectsAsync(httpClient,query);
                if (result.Data.Any())
                {
                    TopProducts.Clear();
                    foreach (var item in result.Data)
                    {
                        var obj = Mapping.Mapper.Map<Product>(item);
						if (obj.Image=="{}")
						{
							obj.Image = null;
						}
                        TopProducts.Add(obj);
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

				CustomerFastOperationBottomSheetViewModel viewModel = _serviceProvider.GetService<CustomerFastOperationBottomSheetViewModel>();
				viewModel.Current = Current;

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

        [RelayCommand]
        async Task GoToDetailAsync(Product product)
        {
            try
            {
                await Task.Delay(500);
                await Shell.Current.GoToAsync($"{nameof(ProductDetailView)}", new Dictionary<string, object>
                {
                    [nameof(Product)] = product
                });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");
            }
        }
    }
}
