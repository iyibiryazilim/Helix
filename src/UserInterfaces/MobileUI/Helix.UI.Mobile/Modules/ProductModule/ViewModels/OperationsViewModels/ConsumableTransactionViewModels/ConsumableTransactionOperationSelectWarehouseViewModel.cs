using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews.ConsumableTransactionViews;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;
using static Helix.UI.Mobile.Modules.ProductModule.DataStores.WarehouseDataStore;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels
{
    public partial class ConsumableTransactionOperationSelectWarehouseViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly IWarehouseService _warehouseService;
        //Lists
        public ObservableCollection<Warehouse> Items { get; } = new();

        //Commands
        public Command GetWarehousesCommand { get; }
        public Command SearchCommand { get; }

        //Properties
        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        WarehouseOrderBy orderBy = WarehouseOrderBy.nameasc;
        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 20;
        public ConsumableTransactionOperationSelectWarehouseViewModel(IHttpClientService httpClientService, IWarehouseService warehouseService)
        {
            _httpClientService = httpClientService;
            _warehouseService = warehouseService;
            GetWarehousesCommand = new Command(async () => await LoadData());
            SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

        }

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
                await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
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
                var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
                if (result.Data.Any())
                {
                    foreach (Warehouse item in result.Data)
                    {
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
                await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");

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
                var result = await _warehouseService.GetObjects(httpClient, SearchText, OrderBy, CurrentPage, PageSize);
                if (result.Data.Any())
                {
                    Items.Clear();
                    foreach (Warehouse item in result.Data)
                    {
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
            if (IsBusy) return;
            try
            {
                string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Numara A-Z", "Numara Z-A", "Ad A-Z", "Ad Z-A");
                if (!string.IsNullOrEmpty(response))
                {
                    CurrentPage = 0;
                    await Task.Delay(100);
                    switch (response)
                    {
                        case "Numara A-Z":
                            OrderBy = WarehouseOrderBy.numberasc;
                            await ReloadAsync();
                            break;
                        case "Numara Z-A":
                            OrderBy = WarehouseOrderBy.numberdesc;
                            await ReloadAsync();
                            break;
                        case "Ad A-Z":
                            OrderBy = WarehouseOrderBy.nameasc;
                            await ReloadAsync();
                            break;
                        case "Ad Z-A":
                            OrderBy = WarehouseOrderBy.namedesc;
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
                await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task GoToDetailAsync(Warehouse warehouse)
        {
            try
            {
                await Task.Delay(500);
                await Shell.Current.GoToAsync($"{nameof(ConsumableTransactionOperationView)}", new Dictionary<string, object>
                {
                    [nameof(Warehouse)] = warehouse
                });
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Customer Error: ", $"{ex.Message}", "Tamam");
            }
        }


    }
}
