using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews.BottomSheetViews;
using Helix.UI.Mobile.MVVMHelper;
using Org.Apache.Http.Client;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.ProductTransactionLineDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

[QueryProperty(name: nameof(Product), queryId: nameof(Product))]
public partial class ProductDetailViewModel : BaseViewModel
{
	IServiceProvider _serviceProvider;
	IHttpClientService _httpClient;
	IProductTransactionLineService _productTransactionLineService;

	// Properties
	[ObservableProperty]
	Product product;
	[ObservableProperty]
	string searchText= string.Empty;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;
	[ObservableProperty]
	ProductTransactionLineOrderBy orderBy = ProductTransactionLineOrderBy.datedesc;

	public ObservableCollection<ProductTransactionLine> ProductTransactionLines { get; } = new();

	public Command GetProductTransactionLineCommand { get; }

	public ProductDetailViewModel(IServiceProvider serviceProvider, IHttpClientService httpClient, IProductTransactionLineService productTransactionLineService)
	{
		Title = "Ürün Detayı";
		_serviceProvider = serviceProvider;
		_httpClient = httpClient;
		_productTransactionLineService = productTransactionLineService;
		GetProductTransactionLineCommand = new Command(async () => await GetProductTransactionLineAsync());
	}

	public async Task GetProductTransactionLineAsync()
	{
		if(IsBusy)
			return;
		try
		{
			IsBusy = true;
			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _productTransactionLineService.GetTransactionLinesByProductId(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);

			if (result.Data.Any())
			{
				foreach(var item in result.Data.Take(5))
				{
					await Task.Delay(50);
					ProductTransactionLines.Add(item);
				}
			}
			else
			{
				CurrentPage--;
			}

		}
		catch(Exception ex)
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
		if(IsBusy)
			return;
		try
		{
			IsBusy = true;

			ProductFastOperationBottomSheetViewModel viewModel = _serviceProvider.GetService<ProductFastOperationBottomSheetViewModel>();

			ProductFastOperationBottomSheetView sheet = new ProductFastOperationBottomSheetView(viewModel);
			await sheet.ShowAsync();
		}
		catch(Exception ex)
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
	async Task OpenProductTransactionBottomSheetAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			ProductTransactionBottomSheetViewModel viewModel = _serviceProvider.GetService<ProductTransactionBottomSheetViewModel>();

			ProductTransactionBottomSheetView sheet = new ProductTransactionBottomSheetView(viewModel);
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
