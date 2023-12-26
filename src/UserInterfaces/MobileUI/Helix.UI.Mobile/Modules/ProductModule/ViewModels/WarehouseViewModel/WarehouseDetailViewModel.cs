﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Views.WarehouseViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel;

[QueryProperty(nameof(Warehouse), nameof(Warehouse))]

public partial class WarehouseDetailViewModel : BaseViewModel
{

	IHttpClientService _httpClientService;
	private readonly IWarehouseService _warehouseService;
	IServiceProvider _serviceProvider;
	ICustomQueryService _customQueryService;
	IWarehouseTransactionService _warehouseTransactionService;

	public ObservableCollection<WarehouseDetailCardTypeCount> WarehouseDetailCardTypeCounts { get; } = new();
	public ObservableCollection<WarehouseTransaction> WarehouseDetailTransactions { get; } = new();


	public Command GetWarehouseDetailCommand { get; }

	[ObservableProperty]
	Warehouse warehouse;
	[ObservableProperty]
	string searchText = string.Empty;
	[ObservableProperty]
	WarehouseTransactionOrderBy orderBy = WarehouseTransactionOrderBy.DateDesc;
	[ObservableProperty]
	int currentPage = 0;
	[ObservableProperty]
	int pageSize = 20;

	public WarehouseDetailViewModel(IHttpClientService httpClientService,IWarehouseService warehouseService,IServiceProvider serviceProvider,ICustomQueryService customQueryService, IWarehouseTransactionService warehouseTransactionService)
        {
		Title = "Ambar Detayı";
            _httpClientService = httpClientService;
		_warehouseService = warehouseService;
		_serviceProvider = serviceProvider;
		_customQueryService = customQueryService;
		_warehouseTransactionService = warehouseTransactionService;
		GetWarehouseDetailCommand = new Command(async () => await LoadData());


	}

	async Task LoadData()
	{
		if (IsBusy)
			return;
		try
		{
			await Task.Delay(500);
			await Task.WhenAll(
				 GetWarehouseDetailCardTypeCount(),
				GetWarehouseTransactionAsync()

				);

		}
		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Warehouse Error: ", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	async Task GoToBackAsync()
	{
		await Shell.Current.GoToAsync("..");
	}

	[RelayCommand]
	async Task GoToWarehouseDetailBottomSheet()
	{
		if (IsBusy)
			return;

		try
		{
			IsBusy = true;
			WarehouseDetailBottomSheetViewModel model = _serviceProvider.GetService<WarehouseDetailBottomSheetViewModel>();
			model.Warehouse = Warehouse;

			WarehouseDetailBottomSheetView sheet = new WarehouseDetailBottomSheetView(model);
			
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


	async Task GetWarehouseTransactionAsync()
	{
		if (IsBusy) return;

		try
		{
			IsBusy = true;
			IsRefreshing = true;
			var httpClient = _httpClientService.GetOrCreateHttpClient();
			var result = await _warehouseTransactionService.GetWarehouseTransactions(httpClient,Warehouse.Number, SearchText, OrderBy, CurrentPage, PageSize);
			if (result.Data.Any())
			{
				WarehouseDetailTransactions.Clear();
				foreach (WarehouseTransaction item in result.Data.Take(3))
				{
					WarehouseDetailTransactions.Add(item);
				}
			}
		}

		catch (Exception ex)
		{
			Debug.WriteLine(ex);
			await Shell.Current.DisplayAlert("Warehouse Error:", $"{ex.Message}", "Tamam");
		}
		finally
		{
			IsBusy = false;
			IsRefreshing = false;
		}
	}

	async Task GetWarehouseDetailCardTypeCount()
	{
		var httpClient = _httpClientService.GetOrCreateHttpClient();
		string query = $@"SELECT DISTINCT ITEMS.CARDTYPE as [CardType] ,COUNT(STOCKREF) as [ReferenceCount] FROM LV_003_01_STINVTOT AS STINVTOT
                    LEFT JOIN LG_003_ITEMS AS ITEMS ON STINVTOT.STOCKREF = ITEMS.LOGICALREF
                    WHERE INVENNO={Warehouse.Number} AND ITEMS.CARDTYPE IS NOT NULL
                    GROUP BY ITEMS.CARDTYPE";
		var result = await _customQueryService.GetObjectsAsync(httpClient, query);
		foreach (var item in result.Data)
		{
			var obj = Mapping.Mapper.Map<WarehouseDetailCardTypeCount>(item);
			WarehouseDetailCardTypeCounts.Add(obj);
		}



	}
}
