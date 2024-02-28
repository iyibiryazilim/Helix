using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.Modules.FastProductionModule.Models;
using Helix.UI.Mobile.Modules.FastProductionModule.Views;
using Helix.UI.Mobile.Modules.ProductModule.Dtos;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.ViewModels.WarehouseViewModel.WarehouseCountingViewModels;
using Helix.UI.Mobile.MVVMHelper;
using Kotlin.Properties;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.FastProductionModule.ViewModels;

[QueryProperty(name: nameof(SelectedProduct), queryId: nameof(SelectedProduct))]
public partial class FastProductionViewModel : BaseViewModel
{
    IHttpClientService _httpClientService;
    IProductionTransactionService _productionTransactionService;
    IConsumableTransactionService _consumableTransactionService;

    [ObservableProperty]
    Product selectedProduct;

    [ObservableProperty]
    Warehouse selectedWarehouse;

    public ObservableCollection<FastProductionCard> FastProductionList { get; } = new();

    public FastProductionViewModel(IHttpClientService httpClientService, IProductionTransactionService productionTransactionService, IConsumableTransactionService consumableTransactionService)
    {
        _httpClientService = httpClientService;
        _productionTransactionService = productionTransactionService;
        _consumableTransactionService = consumableTransactionService;
        Title = "Hızlı Üretim";
    }

    [RelayCommand]
    async Task GoToFastProductionSelectWarehouseListAsync()
    {
        if (IsBusy)
            return;

        try
        {
            IsBusy = true;

            await Shell.Current.GoToAsync($"{nameof(FastProductionSelectWarehouseListView)}");
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
    async Task ProductDecrementQuantityAsync()
    {

        try
        {
            IsBusy = true;

            SelectedProduct.OnHand--;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Miktar Azaltma Hatası", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task ProductIncrementQuantityAsync()
    {

        try
        {
            IsBusy = true;

            SelectedProduct.OnHand++;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Miktar Artırma Hatası", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task CardIncrementQuantityAsync(FastProductionCard item)
    {

        try
        {
            IsBusy = true;

            item.OnHand++;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Miktar Artırma Hatası", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task CardDecrementQuantityAsync(FastProductionCard item)
    {

        try
        {
            IsBusy = true;

            item.OnHand--;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Miktar Azaltma Hatası", ex.Message, "Tamam");
        }
        finally
        {
            IsBusy = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    async Task GoToBackAsync()
    {
        try
        {
            IsBusy = true;
            await Shell.Current.GoToAsync("..");
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
    async Task GoToSuccessPageViewAsync()
    {
        try
        {
            try
            {
                IsBusy = true;
                var httpClient = _httpClientService.GetOrCreateHttpClient();

                var employeeOid = await SecureStorage.GetAsync("EmployeeOid");
                foreach (var item in FastProductionList)
                {
                    var consumableTransactionDto = new ConsumableTransactionDto()
                    {
                        WarehouseNumber = item.WarehouseNumber,
                        TransactionDate = DateTime.Now,
                        IOType = 4,
                        TransactionType = 12,
                        GroupType = 3,
                        EmployeeOid = employeeOid

                    };
                    var consumableTransactionLineDto = new ConsumableTransactionLineDto()
                    {
                        IOType = 4,
                        TransactionType = 12,
                        TransactionDate = DateTime.Now,
                        ProductCode = item.ProductCode,
                        ProductReferenceId = item.ProductReferenceId,
                        Quantity = item.OnHand,
                        SubUnitsetCode = item.SubUnitsetCode,
                        SubUnitsetReferenceId = item.SubUnitsetReferenceId,
                        //UnitsetCode = item.ExitProduct.UnitsetCode,
                        //UnitsetReferenceId = item.ExitProduct.UnitsetReferenceId,
                        WarehouseNumber = item.WarehouseNumber
                    };
                    consumableTransactionDto.Lines.Add(consumableTransactionLineDto);
                    var result = await _consumableTransactionService.InsertObject(httpClient, consumableTransactionDto);

                }


                var productionTransactionDto = new ProductionTransactionDto()
                {
                    WarehouseNumber = SelectedWarehouse.Number ,
                    TransactionDate = DateTime.Now,
                    IOType = 1,
                    TransactionType = 13,
                    GroupType = 3,
                    EmployeeOid = employeeOid

                };

                var productionTransactionLineDto = new ProductionTransactionLineDto()
                {
                    IOType = 1,
                    TransactionType = 13,
                    TransactionDate = DateTime.Now,
                    ProductCode = SelectedProduct.Code,
                    ProductReferenceId = SelectedProduct.ReferenceId,
                    Quantity = SelectedProduct.OnHand,
                    SubUnitsetCode = SelectedProduct.SubUnitsetCode,
                    SubUnitsetReferenceId = SelectedProduct.SubUnitsetReferenceId,
                    UnitsetCode = SelectedProduct.UnitsetCode,
                    UnitsetReferenceId = SelectedProduct.UnitsetReferenceId,
                    WarehouseNumber = SelectedWarehouse.Number
                };
                productionTransactionDto.Lines.Add(productionTransactionLineDto);


                var ProductionResult = await _productionTransactionService.InsertObject(httpClient, productionTransactionDto);
                if (ProductionResult.IsSuccess)
                {
                    await Shell.Current.GoToAsync($"{nameof(SuccessPageView)}", new Dictionary<string, object>
                    {
                        ["GroupType"] = 5
                    });
                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
            FastProductionList.Clear();

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
