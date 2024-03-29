﻿using Android.Views.Accessibility;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.FastProductionModule.Views;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;

public partial class FastProductionAllProductsListViewModel : BaseViewModel
{
	IHttpClientService _httpClientService;
	IServiceProvider _serviceProvider;
	IProductService _productService;

	public Command<string> SearchCommand { get; }
	public Command GetItemsCommand { get; }

	public FastProductionAllProductsListViewModel(IHttpClientService httpClientService, IProductService productService, IServiceProvider serviceProvider)
	{
		Title = "Ürün Listesi";
		_httpClientService = httpClientService;
		_serviceProvider = serviceProvider;
		_productService = productService;

		GetItemsCommand = new Command(async () => await LoadData());
		SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
	}

	#region List
	public ObservableCollection<Product> Items { get; } = new();

	[ObservableProperty]
	public Product selectedProduct;
	#endregion

	#region Properties
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	ProductOrderBy orderBy = ProductOrderBy.nameasc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;
	#endregion


	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await MainThread.InvokeOnMainThreadAsync(ReloadAsync);
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
	async Task GetProductsListAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;
			IsRefreshing = false;

			var httpClient = _httpClientService.GetOrCreateHttpClient();
			var result = await _productService.GetObjects(httpClient, SearchText, "", OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				Items.Clear();

				foreach (var item in result.Data)
				{
					Items.Add(item);
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
			var result = await _productService.GetObjects(httpClient, SearchText, "", OrderBy, CurrentPage, PageSize);
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
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");

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

			var result = await _productService.GetObjects(httpClient, SearchText, "", OrderBy, CurrentPage, PageSize);
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
			await Shell.Current.DisplayAlert("Error: ", $"{ex.Message}", "Tamam");
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
                        OrderBy = ProductOrderBy.nameasc;
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

	[RelayCommand]
	private void ToggleSelection(Product item)
	{
		if (item == SelectedProduct)
		{
			SelectedProduct.IsSelected = false;
			SelectedProduct = null;
		}
		else
		{
			if (SelectedProduct != null)
			{
				SelectedProduct.IsSelected = false;
			}

			SelectedProduct = item;
			SelectedProduct.IsSelected = true;
		}
	}

	[RelayCommand]
	public async Task GoToNextAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			var fastProductionViewModel = _serviceProvider.GetService<FastProductionViewModel>();
			if(fastProductionViewModel.FastProductionList.Count > 0)
			{
				fastProductionViewModel.FastProductionList.Clear();
			}

			if(SelectedProduct != null)
			{
				SelectedProduct.OnHand = 1;
				await Shell.Current.GoToAsync($"{nameof(FastProductionView)}", new Dictionary<string, object>
				{
					[nameof(SelectedProduct)] = SelectedProduct
				});
			}
			else
			{
				await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için seçim yapmanız gerekmektedir", "Tamam");
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
	async Task GoToBackAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			//await Shell.Current.GoToAsync("..");
			Application.Current.MainPage = new AppShell();
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
