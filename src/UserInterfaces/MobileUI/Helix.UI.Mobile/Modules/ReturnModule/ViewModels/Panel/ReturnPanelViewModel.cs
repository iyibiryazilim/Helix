using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.PurchaseModule.Views.SupplierViews;
using Helix.UI.Mobile.Modules.ReturnModule.Helpers.Queries;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.CustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Panel;

public partial class ReturnPanelViewModel : BaseViewModel
{
	IHttpClientService _httpClient;
	ICustomQueryService _customQueryService;

	public Command GetDataCommand { get; }

	public ObservableCollection<Customer> LastReturningCustomerList { get; } = new();
	public ObservableCollection<Product> LastReturnProductList { get; } = new();
	public ObservableCollection<CustomerTransactionLine> ReturnTransactionList { get; } = new();

	public ReturnPanelViewModel(IHttpClientService httpClient, ICustomQueryService customQueryService)
	{
		Title = "İade Paneli";
		_httpClient = httpClient;
		_customQueryService = customQueryService;

		GetDataCommand = new Command(async () => await LoadData());
	}

	[RelayCommand]
	async Task LoadData()
	{
		if (IsBusy)
		{
			return;
		}
		try
		{
			IsBusy = true;
			await Task.Delay(300);
			await Task.WhenAll(GetReturnTransactionListAsync(), GetLastReturningCustomerListAsync(), GetLastReturnProductListAsync());
			//await GetLastReturningCustomerListAsync();
			//await GetLastReturnProductListAsync();
			//await GetReturnTransactionListAsync();
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

	async Task GetLastReturningCustomerListAsync()
	{
		try
		{
			IsBusy = true;

			var result = await _customQueryService.GetObjectsAsync(_httpClient.GetOrCreateHttpClient(), new ReturnPanelQuery().LastReturnCustomerQuery());
			if (result.Data.Any())
			{
				LastReturningCustomerList.Clear();
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<Customer>(item);
					if (obj.Image == "{}")
					{
						obj.Image = null;
					}
					LastReturningCustomerList.Add(obj);
				}
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

	async Task GetLastReturnProductListAsync()
	{
		try
		{
			IsBusy = true;

			var result = await _customQueryService.GetObjectsAsync(_httpClient.GetOrCreateHttpClient(), new ReturnPanelQuery().LastReturnProductQuery());
			if (result.Data.Any())
			{
				LastReturnProductList.Clear();
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<Product>(item);
					if (obj.Image == "{}")
					{
						obj.Image = null;
					}
					LastReturnProductList.Add(obj);
				}
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

	async Task GetReturnTransactionListAsync()
	{
		try
		{
			IsBusy = true;

			var result = await _customQueryService.GetObjectsAsync(_httpClient.GetOrCreateHttpClient(), new ReturnPanelQuery().TopReturnTransactionListQuery());
			if (result.Data.Any())
			{
				ReturnTransactionList.Clear();
				foreach (var item in result.Data)
				{
					await Task.Delay(50);
					var obj = Mapping.Mapper.Map<CustomerTransactionLine>(item);
					ReturnTransactionList.Add(obj);
				}
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
	async Task GoToProductDetailViewAsync(Product product)
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Shell.Current.GoToAsync($"{nameof(ProductDetailView)}", new Dictionary<string, object>
			{
				[nameof(Product)] = product				
			});
		}
		catch(Exception ex)
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
	async Task GoToCustomerOrSupplierDetailViewAsync(Current current)
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			// 12 ile başlıyorsa customer, 32 ile başlıyorsa supplier 
			if(current.Code.StartsWith("12"))
			{
				await Shell.Current.GoToAsync($"{nameof(CustomerDetailView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = current
				});
			}
			else if(current.Code.StartsWith("32"))
			{
				await Shell.Current.GoToAsync($"{nameof(SupplierDetailView)}", new Dictionary<string, object>
				{
					[nameof(Current)] = current
				});
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

}
