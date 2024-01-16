using Android.Views;
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
		int pageSize = 20;
		[ObservableProperty]
		string groupCode = string.Empty;
		//Query
		[ObservableProperty]
		Product product;

		[ObservableProperty]
		Product selectedProduct;
		[RelayCommand]
		public async Task LoadData()
		{
			if (IsBusy)
				return;
			try
			{
				await Task.Delay(500);
				await Task.WhenAll(ReloadAsync());			  

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
						if(SelectedProduct != null)
						{
							if (item.ReferenceId == SelectedProduct.ReferenceId)
							{
								item.IsSelected = true;
								await Task.Delay(100);
								Items.Add(item);
							}
							else
							{
								await Task.Delay(100);
								Items.Add(item);
							}
						} 
						else
						{
							await Task.Delay(100);
							Items.Add(item);
						}
				 
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
							await Shell.Current.DisplayAlert("Customer Error: ", "Yanlış Girdi", "Tamam");
							await ReloadAsync();
							break;

					}
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
		async Task ToggleSelectionAsync(Product item)
		{
			SelectedProduct = item;			 
			item.IsSelected = !item.IsSelected;
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
