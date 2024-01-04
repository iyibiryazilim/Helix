using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;

using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.InCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.OutCountingTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.WastageTransactionOperationViewModels;
using Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesDispatchViewModels;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;

[QueryProperty(nameof(ViewType), nameof(ViewType))]
public partial class SharedProductListViewModel :BaseViewModel
{
    IHttpClientService _httpClientService;
    private readonly IProductService _productService;
    IServiceProvider _serviceProvider;

    public ObservableCollection<Product> Items { get; } = new();
    public ObservableCollection<Product> SelectedProducts { get; } = new();

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

    [ObservableProperty]
    public int viewType;

    public Command GetProductsCommand { get; }
    public SharedProductListViewModel( IHttpClientService httpClientService, IProductService productService, IServiceProvider serviceProvider)
    {

        Title = "Ürün Listesi";
        _httpClientService = httpClientService;
        _productService = productService;
        GetProductsCommand = new Command(async () => await LoadData());
        SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
        _serviceProvider = serviceProvider;
    }


    [RelayCommand]
    private void ToggleSelection(Product item)
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
                    if (consumableService.Items.ToList().Exists(x => x.Code == product.Code))
                    {
                        consumableService.Items.ToList().First(x => x.Code == product.Code).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ReferenceId,
                            Code=product.Code,
                            Name=product.Name,
                            UnitsetCode=product.UnitsetCode,
                            SubUnitsetCode=product.SubUnitsetCode,
                            SubUnitsetReferenceId=product.SubUnitsetReferenceId,
                            UnitsetReferenceId=product.UnitsetReferenceId,
                            StockQuantity = product.StockQuantity,
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
                    if (inCountingService.Items.ToList().Exists(x => x.Code == product.Code))
                    {
                        inCountingService.Items.ToList().First(x => x.Code == product.Code).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ReferenceId,
                            Code = product.Code,
                            Name = product.Name,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.StockQuantity,
                           
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
                    if (outCountingService.Items.ToList().Exists(x => x.Code == product.Code))
                    {
                        outCountingService.Items.ToList().First(x => x.Code == product.Code).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ReferenceId,
                            Code = product.Code,
                            Name = product.Name,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.StockQuantity,
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
                    if (productionTransactionService.Items.ToList().Exists(x => x.Code == product.Code))
                    {
                        productionTransactionService.Items.ToList().First(x => x.Code == product.Code).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ReferenceId,
                            Code = product.Code,
                            Name = product.Name,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.StockQuantity,
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
                    if (wastageTransactionService.Items.ToList().Exists(x => x.Code == product.Code))
                    {
                        wastageTransactionService.Items.ToList().First(x => x.Code == product.Code).Quantity += 1;

                    }
                    else
                    {
                        var model = new ProductModel
                        {
                            ReferenceId = product.ReferenceId,
                            Code = product.Code,
                            Name = product.Name,
                            UnitsetCode = product.UnitsetCode,
                            SubUnitsetCode = product.SubUnitsetCode,
                            SubUnitsetReferenceId = product.SubUnitsetReferenceId,
                            UnitsetReferenceId = product.UnitsetReferenceId,
                            StockQuantity = product.StockQuantity,
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
					if (salesDispatchService.Items.ToList().Exists(x => x.Code == product.Code))
                    {
						salesDispatchService.Items.ToList().First(x => x.Code == product.Code).StockQuantity += 1;

					}
					else
                    {
						var model = new ProductModel
                        {
							ReferenceId = product.ReferenceId,
							Code = product.Code,
							Name = product.Name,
							UnitsetCode = product.UnitsetCode,
							SubUnitsetCode = product.SubUnitsetCode,
							SubUnitsetReferenceId = product.SubUnitsetReferenceId,
							UnitsetReferenceId = product.UnitsetReferenceId,
							Quantity = 1

						};
						product.IsSelected = false;
						salesDispatchService.Items.Add(model);
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
            await Task.Delay(700);
            await MainThread.InvokeOnMainThreadAsync(ReloadAsync);


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
    async Task LoadMoreAsync()
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
    async Task ReloadAsync()
    {
        if (IsBusy)
            return;


        try
        {
            IsBusy = true;
            IsRefreshing = true;
            var httpClient = _httpClientService.GetOrCreateHttpClient();

            CurrentPage = 0;
            var result = await _productService.GetObjects(httpClient, SearchText, GroupCode, OrderBy, CurrentPage, PageSize);
            if (result.Data.Any())
            {
                Items.Clear();
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
    async Task SortAsync()
    {
        
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




}
