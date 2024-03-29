﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Helpers.QueryHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel.BottomSheetViewModels;
using Helix.UI.Mobile.Modules.ProductModule.Views.ProductViews.BottomSheetViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.ProductTransactionLineDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.ProductViewModel;

[QueryProperty(name: nameof(Product), queryId: nameof(Product))]
public partial class ProductDetailViewModel : BaseViewModel
{
	IServiceProvider _serviceProvider;
	IHttpClientService _httpClient;
	ICustomQueryService _customQueryService;
	IProductTransactionLineService _productTransactionLineService;

	// Properties
	[ObservableProperty]
	ProductDetailValues productDetailValues = new();
	[ObservableProperty]
	Product product;
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;
	[ObservableProperty]
	ProductTransactionLineOrderBy orderBy = ProductTransactionLineOrderBy.datedesc;

	public ObservableCollection<ProductTransactionLine> ProductTransactionLines { get; } = new();

	public Command GetProductTransactionLineCommand { get; }

	public ProductDetailViewModel(IServiceProvider serviceProvider, IHttpClientService httpClient, IProductTransactionLineService productTransactionLineService, ICustomQueryService customQueryService)
	{
		Title = "Ürün Detayı";
		_serviceProvider = serviceProvider;
		_httpClient = httpClient;
		_customQueryService = customQueryService;
		_productTransactionLineService = productTransactionLineService;
		GetProductTransactionLineCommand = new Command(async () => await LoadData());
	}

	public async Task GetProductTransactionLineAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;
			IsRefreshing = true;

			var httpClient = _httpClient.GetOrCreateHttpClient();
			var result = await _productTransactionLineService.GetTransactionLinesByProductId(httpClient, Product.ReferenceId, SearchText, OrderBy, CurrentPage, PageSize);

			if (result.Data.Any())
			{
				ProductTransactionLines.Clear();
				foreach (var item in result.Data.Take(3))
				{
					ProductTransactionLines.Add(item);
				}
			}
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

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(1000);
			await Task.WhenAll(
				 GetProductDetailValues(),
				 GetProductTransactionLineAsync()
			);
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

	async Task GetProductDetailValues()
	{
		try
		{
			var httpClient = _httpClient.GetOrCreateHttpClient();
			var query = new ProductQuery().DetailValues(Product.ReferenceId);
			var result = await _customQueryService.GetObjectAsync(httpClient, query);
			var obj = Mapping.Mapper.Map<ProductDetailValues>(result.Data);

			ProductDetailValues.InputQuantity = obj.InputQuantity;
			ProductDetailValues.OutputQuantity = obj.OutputQuantity;
			ProductDetailValues.StockQuantity = obj.StockQuantity;
			ProductDetailValues.SubUnitsetCode = obj.SubUnitsetCode;
		}
		catch(Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Error :", ex.Message, "Tamam");
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

			ProductFastOperationBottomSheetViewModel viewModel = _serviceProvider.GetService<ProductFastOperationBottomSheetViewModel>();

			ProductFastOperationBottomSheetView sheet = new ProductFastOperationBottomSheetView(viewModel);
			viewModel.Product = Product;
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
	async Task OpenProductTransactionBottomSheetAsync()
	{
		if (IsBusy)
			return;
		try
		{
			IsBusy = true;

			ProductTransactionBottomSheetViewModel viewModel = _serviceProvider.GetService<ProductTransactionBottomSheetViewModel>();

			ProductTransactionBottomSheetView sheet = new ProductTransactionBottomSheetView(viewModel);
			viewModel.Product = Product;
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
