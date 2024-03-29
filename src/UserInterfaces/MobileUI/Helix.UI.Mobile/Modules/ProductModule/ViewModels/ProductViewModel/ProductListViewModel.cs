﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

public partial class ProductListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	private readonly IProductService _productService;
	//private readonly IEndProductService _endProductService;

	public ObservableCollection<Product> Items { get; } = new();
	public ObservableCollection<ProductGroup> Groups { get; } = new();

	public Command SearchCommand { get; }

	//Properties
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	ProductOrderBy orderBy = ProductOrderBy.nameasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;
	[ObservableProperty]
	string groupCode = string.Empty;



	public Command GetProductsCommand { get; }

	public ProductListViewModel(IHttpClientService httpClientService, IProductService productService)
	{
		Title = "Malzemeler";
		_httpClientService = httpClientService;
		_productService = productService;
		GetProductsCommand = new Command(async () => await LoadData());
		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
	}


	[RelayCommand]
	public async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);

			await Task.WhenAll(ReloadAsync(), GetGroupsAsync());




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
	[RelayCommand]
	public async Task PerformSearchAsync(string text)
	{
		if (IsBusy)
			return;
		try
		{

			if (!string.IsNullOrEmpty(text))
			{
				if (text.Length >= 3)
				{
					SearchText = text;
					await ReloadAsync();
				}
			}
			else
			{
				SearchText = string.Empty;
				await ReloadAsync();
			}
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

	[RelayCommand]
	public async Task LoadMoreAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			CurrentPage++;
			var result = await _productService.GetObjects(httpClient, SearchText, GroupCode, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				foreach (Product item in result.Data)
				{
					await Task.Delay(100);
					Items.Add(item);
				}
			}
			else
			{
				CurrentPage--;
			}

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");

		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}
	[RelayCommand]
	public async Task ReloadAsync()
	{
		if (IsBusy)
			return;


		try
		{
			IsBusy = true;
			IsRefreshing = true;
			IsRefreshing = false;

			var httpClient = _httpClientService.GetOrCreateHttpClient();

			CurrentPage = 0;
			Items.Clear();

			var result = await _productService.GetObjects(httpClient, SearchText, GroupCode, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				foreach (Product item in result.Data)
				{
					await Task.Delay(100);
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

	[RelayCommand]
	public async Task SortAsync()
	{
		if (IsBusy) return;
		try
		{
			string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Kod A-Z", "Kod Z-A", "Ad A-Z", "Ad Z-A");
			if (!string.IsNullOrEmpty(response))
			{
				CurrentPage = 0;
				await Task.Delay(100);
				switch (response)
				{
					case "Kod A-Z":
						OrderBy = ProductOrderBy.codeasc;
						await ReloadAsync();
						break;
					case "Kod Z-A":
						OrderBy = ProductOrderBy.codedesc;
						await ReloadAsync();
						break;
					case "Ad A-Z":
						OrderBy = ProductOrderBy.nameasc;
						await ReloadAsync();
						break;
					case "Ad Z-A":
						OrderBy = ProductOrderBy.namedesc;
						await ReloadAsync();
						break;
					default:
						
						await ReloadAsync();
						break;

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
			IsRefreshing = false;
		}
	}

	public async Task GetGroupsAsync()
	{

		try
		{
			IsBusy = true;
			//IsRefreshing = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();

			CurrentPage = 0;
			var result = await _productService.GetGroupCode(httpClient);
			if (result.IsSuccess)
			{
				if (result.Data.Any())
				{
					Groups.Clear();
					await Task.Delay(200);
					Groups.Add(new ProductGroup
					{
						GroupCode = "Tümü",
						GroupDefinition = "Tümü",
						IsSelected = true
					});

					foreach (ProductGroup item in result.Data)
					{
						await Task.Delay(100);
						Groups.Add(item);
					}
				}
			}
			else
			{
				Debug.WriteLine(result.Message);
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
			IsRefreshing = false;
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

	[RelayCommand]
	public async Task SelectGroupAsync(ProductGroup productGroup)
	{
		if (IsBusy)
			return;
		if (productGroup != null)
		{
			try
			{

				productGroup.IsSelected = !productGroup.IsSelected;

				if (productGroup.GroupDefinition == "Tümü")
				{
					GroupCode = string.Empty;

				}

				else
					GroupCode = productGroup.GroupCode;

				foreach (var item in Groups.Where(x => x.IsSelected == true && x.GroupCode != productGroup.GroupCode))
				{
					item.IsSelected = false;
				}

				//GroupCode = productGroup.GroupCode;
				await ReloadAsync();


			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Product Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;
			}
		}
		else
		{
			Debug.WriteLine("veri yok");
		}
	}
}
