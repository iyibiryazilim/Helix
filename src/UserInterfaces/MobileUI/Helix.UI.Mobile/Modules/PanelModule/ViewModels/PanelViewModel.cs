using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.PanelModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.PanelModule.ViewModels;
public partial class PanelViewModel : BaseViewModel
{
	IHttpClientService _httpClient;
	ICustomQueryService _customQueryService;

	public Command GetDataCommand { get; }
	public ObservableCollection<Product> Products { get; } = new();
	public PanelViewModel(IHttpClientService httpClient, ICustomQueryService customQueryService)
	{
		Title = "Ana Panel";
		_httpClient = httpClient;
		_customQueryService = customQueryService;

		GetDataCommand = new Command(async () => await LoadData());
	}

	[RelayCommand]
	public async Task LoadData()
	{
		if (IsBusy)
			return;

		try
		{
			await Task.Delay(300);
			await Task.WhenAll(GetTodayTransactionedProductAsync());
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

	async Task GetTodayTransactionedProductAsync()
	{
		try
		{
			IsBusy = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _customQueryService.GetObjectsAsync(httpClient, new PanelQuery().GetTodayInputOutput());
			
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
}
