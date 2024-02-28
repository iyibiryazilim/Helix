using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.LoginModule.Models;
using Helix.UI.Mobile.Modules.PanelModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.PanelModule.Models;
using Helix.UI.Mobile.Modules.PanelModule.Services;
using Helix.UI.Mobile.Modules.PanelModule.Views;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PanelModule.ViewModels;
public partial class PanelViewModel : BaseViewModel
{
	IHttpClientService _httpClient;
	ICustomQueryService _customQueryService;
	IEmployeeService _employeeService;


	public Command GetDataCommand { get; }
	public ObservableCollection<Product> Products { get; } = new();
	public ObservableCollection<Employee> Employees { get; } = new();


	public MainPanelModel mainPanelModel { get; set; } 

	[ObservableProperty]
	Employee user = new Employee();
	public Command GetUserInformationCommand { get; }

	public PanelViewModel(IHttpClientService httpClient, ICustomQueryService customQueryService, IEmployeeService employeeService)
	{
		Title = "Ana Panel";
		_httpClient = httpClient;
		_customQueryService = customQueryService;

		GetDataCommand = new Command(async () => await LoadData());
		mainPanelModel = new MainPanelModel();
		GetUserInformationCommand = new Command(async () => await GetUserInformationAsync());
		_employeeService = employeeService;
	}

	[RelayCommand]
	public async Task LoadData()
	{
		if (IsBusy)
			return;

		try
		{
			await Task.Delay(300);
			await Task.WhenAll(GetTodayInputCountValuesAsync(),
					  GetTodayOutputCountValueAsync(),
					  GetWaitingSalesOrderCountValueAsync(),
					  GetWaitingPurchaseOrderCountValueAsync(),
					  GetTodayTransactionedProductAsync(),
					  GetEmployeeStatisticsAsync());
			//await MainThread.InvokeOnMainThreadAsync(GetTodayTransactionedProductAsync);
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
    
    async Task GetUserInformationAsync()
    {

        try
        {
            IsBusy = true;
			var httpClient = _httpClient.GetOrCreateHttpClient();

			var result =await  _employeeService.GetObject(httpClient, new Guid(await SecureStorage.GetAsync("EmployeeOid")),"?&expand=Image");
			if(result.IsSuccess)
			{
				User = result.Data;
			} 

        }
        catch (Exception)
        {

            throw;
        }
    }



    async Task GetTodayTransactionedProductAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _customQueryService.GetObjectsAsync(httpClient, new PanelQuery().GetTodayTransactionedProducts());
			
			if(Products.Count > 0)
			{
				Products.Clear();
			}

			if(result.Data.Any())
			{
				foreach(var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<Product>(item);
					if(obj.Image == "{}")
					{
						obj.Image = null;
					}
					Products.Add(obj);
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

	async Task GetTodayInputCountValuesAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _customQueryService.GetObjectsAsync(httpClient, new PanelQuery().GetTodayInputCountValues());

			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<MainPanelModel>(item);
					mainPanelModel.InputCount = obj.InputCount;
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

	async Task GetTodayOutputCountValueAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _customQueryService.GetObjectsAsync(httpClient, new PanelQuery().GetTodayOutputCountValues());

			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<MainPanelModel>(item);
					mainPanelModel.OutputCount= obj.OutputCount;
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
	async Task GetWaitingSalesOrderCountValueAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _customQueryService.GetObjectsAsync(httpClient, new PanelQuery().GetWaitingSalesOrderCountValues());

			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<MainPanelModel>(item);
					mainPanelModel.WaitingSalesOrderCount = obj.WaitingSalesOrderCount;
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

	async Task GetWaitingPurchaseOrderCountValueAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _customQueryService.GetObjectsAsync(httpClient, new PanelQuery().GetWaitingPurchaseOrderCountValues());

			if (result.Data.Any())
			{
				foreach (var item in result.Data)
				{
					var obj = Mapping.Mapper.Map<MainPanelModel>(item);
					mainPanelModel.WaitingPurchaseOrderCount = obj.WaitingPurchaseOrderCount;
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

	async Task GetEmployeeStatisticsAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _employeeService.GetObjects(httpClient, "?&expand=Image");

			if (result.IsSuccess)
			{
				if (Employees.Count > 0)
				{
					Employees.Clear();
				}
				foreach (var item in result.Data)
				{
					Employees.Add(item);
				}
			}
			else
			{
				await Shell.Current.DisplayAlert("Error: ", $"{result.Message}", "Tamam");

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
    async Task GoToProfilelViewAsync()
    {
		await Shell.Current.GoToAsync($"{nameof(ProfilePageView)}");
    }

}
