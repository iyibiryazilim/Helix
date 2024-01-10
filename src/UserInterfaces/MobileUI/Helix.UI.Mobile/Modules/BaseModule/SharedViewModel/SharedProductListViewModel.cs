using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.DataStores;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.PurchaseModule.ViewModels.OperationsViewModels.PurchaseDispatchViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

[QueryProperty(nameof(ViewType), nameof(ViewType))]
[QueryProperty(nameof(Warehouse), nameof(Warehouse))]

public partial class SharedProductListViewModel :BaseViewModel
{
    IHttpClientService _httpClientService;
    private readonly IProductService _productService;
    IServiceProvider _serviceProvider;
    IWarehouseTotalService _warehouseTotalService;

    public ObservableCollection<WarehouseTotal> Items { get; } = new();
    public ObservableCollection<WarehouseTotal> Results { get; } = new();

    public ObservableCollection<WarehouseTotal> SelectedProducts { get; } = new();

    public Command SearchCommand { get; }
    //Properties
    [ObservableProperty]
    string searchText = string.Empty;
    [ObservableProperty]
    WarehouseTotalOrderBy orderBy = WarehouseTotalOrderBy.nameasc;
    [ObservableProperty]
    int currentPage = 0;
    [ObservableProperty]
    int pageSize = 100000;
    [ObservableProperty]
    string groupCode = string.Empty;

    [ObservableProperty]
    public int viewType;

    [ObservableProperty]
    Warehouse warehouse;
    public Command GetProductsCommand { get; }
    public SharedProductListViewModel( IHttpClientService httpClientService, IProductService productService, IServiceProvider serviceProvider, IWarehouseTotalService warehouseTotalService)
    {

        Title = "Ürün Listesi";
        _httpClientService = httpClientService;
        _productService = productService;
        _warehouseTotalService = warehouseTotalService;
        GetProductsCommand = new Command(async () => await LoadData());
        SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
        _serviceProvider = serviceProvider;
       
    }


    [RelayCommand]
    private void ToggleSelection(WarehouseTotal item)
    {
        item.IsSelected = !item.IsSelected;
        if (item.IsSelected)
        {
            SelectedProducts.Add(item);
        }
        else
        {
            SelectedProducts.Remove(item);
        }
    }
    [RelayCommand]
    async Task SaveAsync()
    {
        switch (ViewType)
        {
            //Consumable Transaction//sarf işlemleri
            case 12:
                var consumableService = _serviceProvider.GetService<ConsumableTransactionOperationViewModel>();
                foreach (var product in SelectedProducts)
                {
                    if (consumableService.Items.ToList().Exists(x => x.Code == product.ProductCode))
                    {
                        consumableService.Items.ToList().First(x => x.Code == product.ProductCode).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ProductReferenceId,
                            Code=product.ProductCode,
                            Name=product.ProductName,
                            UnitsetCode=product.UnitsetCode,
                            SubUnitsetCode=product.SubUnitsetCode,
                            SubUnitsetReferenceId=product.SubUnitsetReferenceId,
                            UnitsetReferenceId=product.UnitsetReferenceId,
                            StockQuantity = product.OnHand,
                            Quantity=1

                        };
                        product.IsSelected = false;
                        consumableService.Items.Add(model);
                    }

                }
                break;
                //InCounting//Sayım fazlası işlemleri
            case 50:
                var inCountingService = _serviceProvider.GetService<InCountingTransactionOperationViewModel>();
                foreach (var product in SelectedProducts)
                {
                    if (inCountingService.Items.ToList().Exists(x => x.Code == product.ProductCode))
                    {
                        inCountingService.Items.ToList().First(x => x.Code == product.ProductCode).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ProductReferenceId,
                            Code = product.ProductCode,
                            Name = product.ProductName,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.OnHand,
                            Quantity = 1

                        };
                        product.IsSelected = false;
                        inCountingService.Items.Add(model);
                    }

                }
                break;
                //OutCounting//Sayım Fazlası İşlemleri
            case 51:
                var outCountingService = _serviceProvider.GetService<OutCountingTransactionOperationViewModel>();
                foreach (var product in SelectedProducts)
                {
                    if (outCountingService.Items.ToList().Exists(x => x.Code == product.ProductCode))
                    {
                        outCountingService.Items.ToList().First(x => x.Code == product.ProductCode).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ProductReferenceId,
                            Code = product.ProductCode,
                            Name = product.ProductName,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.OnHand,
                            Quantity = 1

                        };
                        product.IsSelected = false;
                        outCountingService.Items.Add(model);
                    }

                }
                break;
                //ProductionTransaction//Üretimden Giriş işlemleri
            case 13:
                var productionTransactionService = _serviceProvider.GetService<ProductionTransactionOperationViewModel>();
                foreach (var product in SelectedProducts)
                {
                    if (productionTransactionService.Items.ToList().Exists(x => x.Code == product.ProductCode))
                    {
                        productionTransactionService.Items.ToList().First(x => x.Code == product.ProductCode).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ProductReferenceId,
                            Code = product.ProductCode,
                            Name = product.ProductName,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.OnHand,
                            Quantity = 1

                        };
                        product.IsSelected = false;
                        productionTransactionService.Items.Add(model);
                    }

                }
                break;
                //WastageTransaction//Fire İşlemleri
            case 11:
                var wastageTransactionService = _serviceProvider.GetService<WastageTransactionOperationViewModel>();
                foreach (var product in SelectedProducts)
                {
                    if (wastageTransactionService.Items.ToList().Exists(x => x.Code == product.ProductCode))
                    {
                        wastageTransactionService.Items.ToList().First(x => x.Code == product.ProductCode).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ProductReferenceId,
                            Code = product.ProductCode,
                            Name = product.ProductName,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.OnHand,
                            Quantity = 1

                        };
                        product.IsSelected = false;
                        wastageTransactionService.Items.Add(model);
                    }

                }
                break;
            case 7:
                var salesDispatchService = _serviceProvider.GetService<SalesDispatchListViewModel>();
				foreach (var product in SelectedProducts)
                {
					if (salesDispatchService.Items.ToList().Exists(x => x.Code == product.ProductCode))
                    {
						salesDispatchService.Items.ToList().First(x => x.Code == product.ProductCode).StockQuantity += 1;

					}
					else
                    {
						var model = new ProductModel
                        {
							ReferenceId = product.ProductReferenceId,
                            Code = product.ProductCode,
                            Name = product.ProductName,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.OnHand,
							Quantity = 1

						};
						product.IsSelected = false;
						salesDispatchService.Items.Add(model);
					}

				}
				break;
            case 1:
                var purchaseDispatchService = _serviceProvider.GetService<PurchaseDispatchListViewModel>();
                foreach (var product in SelectedProducts)
                {
					if (purchaseDispatchService.Items.ToList().Exists(x => x.Code == product.ProductCode))
                    {
						purchaseDispatchService.Items.ToList().First(x => x.Code == product.ProductCode).StockQuantity += 1;

					}
					else
                    {
						var model = new ProductModel
                        {
							ReferenceId = product.ProductReferenceId,
                            Code = product.ProductCode,
                            Name = product.ProductName,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.OnHand,
							Quantity = 1

						};
						product.IsSelected = false;
						purchaseDispatchService.Items.Add(model);
					}
				}
                break;


            default:
                break;
        }
        await Task.Delay(200);
        await Shell.Current.GoToAsync("..");
    }


    async Task LoadData()
    {
        if (IsBusy)
            return;
        try
        {
            await Task.Delay(500);
            await MainThread.InvokeOnMainThreadAsync(GetProductsAsync);

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
    async Task GetProductsAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            var result = await _warehouseTotalService.GetWarehouseTotals(httpClient,Warehouse.Number,"1,2,3,4,10,11,12,13", SearchText, OrderBy, CurrentPage, PageSize);
            foreach (WarehouseTotal item in result.Data)
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
                    foreach (var item in Items.ToList().Where(x => x.ProductName.Contains(SearchText) || x.ProductCode.ToString().Contains(SearchText)))
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
    async Task ReloadAsync()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            var result = await _warehouseTotalService.GetWarehouseTotals(httpClient, Warehouse.Number, "1,2,3,4,10,11,12,13", SearchText, OrderBy, CurrentPage, PageSize);

            foreach (WarehouseTotal item in result.Data)
            {
                Items.Add(item);
                Results.Add(item);
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
                        foreach (var item in Items.OrderBy(x => x.ProductCode).ToList())
                        {
                            Results.Add(item);
                        }
                        break;
                    case "Kod Z-A":
                        Results.Clear();
                        foreach (var item in Items.OrderByDescending(x => x.ProductCode).ToList())
                        {
                            Results.Add(item);
                        }
                        break;
                    case "Ad A-Z":
                        Results.Clear();
                        foreach (var item in Items.OrderBy(x => x.ProductName).ToList())
                        {
                            Results.Add(item);
                        }
                        break;
                    case "Ad Z-A":
                        Results.Clear();
                        foreach (var item in Items.OrderByDescending(x => x.ProductName).ToList())
                        {
                            Results.Add(item);
                        }
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
            await Shell.Current.DisplayAlert("Supplier Error: ", $"{ex.Message}", "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }




}
