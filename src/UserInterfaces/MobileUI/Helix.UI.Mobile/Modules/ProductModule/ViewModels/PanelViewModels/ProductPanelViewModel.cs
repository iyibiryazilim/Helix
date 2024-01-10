using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.PanelViewModels;

public partial class ProductPanelViewModel :BaseViewModel
{
	IHttpClientService _httpClientService;
	ICustomQueryService _customQueryService;

	public ObservableCollection<Product> Items { get; } = new();
	public ObservableCollection<ProductTransactionLine> Lines { get; } = new();

	public Command GetProductsCommand { get; }

	public ProductPanelViewModel(ICustomQueryService customQueryService, IHttpClientService httpClientService)
	{
		_customQueryService = customQueryService;
		_httpClientService = httpClientService;
		GetProductsCommand = new Command(async () => await LoadData());
		Title = "Malzeme Paneli";


	}

	[RelayCommand]
	public async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(300);
			await Task.WhenAll(GetTopProductsAsync(), GetLastTransactionsAsync());




		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	async Task GetTopProductsAsync()
	{
		try
		{
			IsBusy = true;
			var result = await _customQueryService.GetObjectsAsync(_httpClientService.GetOrCreateHttpClient(), new ProductQuery().GetTopProducts());
			if (Items.Count>0)
				Items.Clear();
			
			foreach (var item in result.Data)
			{
				var obj = Mapping.Mapper.Map<Product>(item);
				if (obj.Image == "{}")
				{
					obj.Image = null;
				}
				Items.Add(obj);
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
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
			var result = await _customQueryService.GetObjectsAsync(_httpClientService.GetOrCreateHttpClient(), new ProductQuery().LastTransactionList());
			if (Lines.Count > 0)
				Lines.Clear();

			foreach (var item in result.Data)
			{
				var obj = Mapping.Mapper.Map<ProductTransactionLine>(item);

				Lines.Add(obj);
			}
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}

	}

	[RelayCommand]
	public async Task GoToDetailAsync(Product product)
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			await Task.Delay(300);
			await Shell.Current.GoToAsync($"{nameof(ProductDetailView)}", new Dictionary<string, object>
			{
				[nameof(Product)] = product
			});
		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}
}
