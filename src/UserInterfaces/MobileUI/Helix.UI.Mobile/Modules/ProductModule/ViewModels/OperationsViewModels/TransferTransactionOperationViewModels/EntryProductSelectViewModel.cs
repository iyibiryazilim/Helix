﻿using Android.Views;
using AndroidX.Navigation.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;


namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.TransferTransactionOperationViewModels
{
	[QueryProperty(nameof(Product), nameof(Product))]
	public partial class EntryProductSelectViewModel : BaseViewModel
	{
		IHttpClientService _httpClientService;
		IProductService _productService;
		IServiceProvider _serviceProvider;

		public EntryProductSelectViewModel(IHttpClientService httpClientService, IProductService productService, IServiceProvider serviceProvider)
		{
			Title = "Giriş Ürün Listesi";
			_httpClientService = httpClientService;
			_productService = productService;
			_serviceProvider = serviceProvider;
			GetProductsCommand = new Command(async () => await LoadData());
			SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
		}
		public ObservableCollection<Product> Items { get; } = new();
		public ObservableCollection<Product> Results { get; } = new();

		//Commands
		public Command GetProductsCommand { get; }
		public Command SearchCommand { get; }
		//Properties
		[ObservableProperty]
		string searchText = string.Empty;
		[ObservableProperty]
		ProductOrderBy orderBy = ProductOrderBy.nameasc;
		[ObservableProperty]
		int currentPage = 0;
		[ObservableProperty]
		int pageSize = 100000;
		[ObservableProperty]
		string groupCode = string.Empty;
		//Query
		[ObservableProperty]
		Product product;
		async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await MainThread.InvokeOnMainThreadAsync(GetItemsAsync);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				await Shell.Current.DisplayAlert("Waiting Sales Order Error: ", $"{ex.Message}", "Tamam");
			}
			finally
			{
				IsBusy = false;
				IsRefreshing = false;

			}
		}
		[RelayCommand]
		async Task GetItemsAsync()
		{
			if (IsBusy)
				return;
			try
			{
				IsBusy = true;
				IsRefreshing = true;
				var httpClient = _httpClientService.GetOrCreateHttpClient();

				var result = await _productService.GetObjects(httpClient, SearchText, "", OrderBy, CurrentPage, PageSize);
				foreach (var item in result.Data)
				{
					Items.Add(item);
					Results.Add(item);
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
						Results.Clear();
						foreach (var item in Items.ToList().Where(x => x.Name.Contains(SearchText) || x.Code.ToString().Contains(SearchText)))
						{
							Results.Add(item);
						}
					}
				}
				else
				{
					SearchText = string.Empty;
					Results.Clear();
					foreach (var item in Items)
					{
						Results.Add(item);
					}
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
		async Task ToggleSelectionAsync(Product item)
		{
			// Deselect all items
			foreach (var product in Items)
			{
				product.IsSelected = false;
			}

			// Toggle the selection of the provided item
			item.IsSelected = !item.IsSelected;
		}
		[RelayCommand]
		async Task SortAsync()
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
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.Code).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Kod Z-A":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.Code).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Ad A-Z":
							Results.Clear();
							foreach (var item in Items.OrderBy(x => x.Name).ToList())
							{
								Results.Add(item);
							}
							break;
						case "Ad Z-A":
							Results.Clear();
							foreach (var item in Items.OrderByDescending(x => x.Name).ToList())
							{
								Results.Add(item);
							}
							break;
						default:
							Results.Clear();
							foreach (var item in Items)
							{
								Results.Add(item);
							}
							break;

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
		public async Task SaveAsync()
		{
			try
			{
				var productViewModel = _serviceProvider.GetService<ChangeProductViewModel>();

				if (productViewModel == null)
				{
					LogOrThrowException("ProductViewModel is null");
					return;
				}

				var productToUpdate = productViewModel.TransferTransactionModel.Products
					.FirstOrDefault(x => x.ExitProduct?.ReferenceId == Product.ReferenceId);

				if (productToUpdate == null)
				{
					LogOrThrowException("No matching product found");
					return;
				}

				var selectedEntryProduct = Items.FirstOrDefault(x => x.IsSelected);

				if (selectedEntryProduct == null)
				{
					LogOrThrowException("No selected entry product found");
					return;
				}

				productToUpdate.EntryProduct = selectedEntryProduct;
				productToUpdate.EntryProductIsNull = false;

				// Call a method to handle the navigation logic
				await NavigateBackAsync();
			}
			catch (Exception ex)
			{
				LogOrThrowException(ex.Message);
				throw;
			}
		}

		private async Task NavigateBackAsync()
		{
			// Additional logic related to navigation if needed
			await Shell.Current.GoToAsync("..");
		}
		private async void LogOrThrowException(string message)
		{
			Debug.WriteLine(message);
			await Shell.Current.DisplayAlert("Error: ", $"{message}", "Tamam");
		}
	}
}
