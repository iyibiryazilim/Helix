using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Helpers.MappingHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ReturnModule.Views.Sales.ReturnBySalesDispatchTransactionViews;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Sales.ReturnBySalesDispatchTransactionViewModels
{
	[QueryProperty(nameof(Current), nameof(Current))]
    [QueryProperty(nameof(Warehouse), nameof(Warehouse))]

    public partial class ReturnBySalesDispatchTransactionFicheListViewModel : BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly ICustomerTransactionService _customerTransactionService;

        public ObservableCollection<DispatchTransaction> Items { get; } = new();
        public ObservableCollection<DispatchTransaction> Results { get; } = new();
        public ObservableCollection<DispatchTransaction> SelectedTransactions { get; } = new();


        public Command GetOrdersCommand { get; }
        public Command SearchCommand { get; }
        public Command SelectAllCommand { get; }


        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        CustomerTransactionOrderBy orderBy = CustomerTransactionOrderBy.datedesc;
        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 20000;

        [ObservableProperty]
        Customer current;

        [ObservableProperty]
        Warehouse warehouse;


        public ReturnBySalesDispatchTransactionFicheListViewModel(IHttpClientService httpClientService, ICustomerTransactionService customerTransactionService)
        {
            _httpClientService = httpClientService;
            _customerTransactionService = customerTransactionService;
            GetOrdersCommand = new Command(async () => await LoadData());
            SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));
            SelectAllCommand = new Command<bool>(async (isSelected) => await SelectAllAsync(isSelected));
            Title = "Satış İrsaliyeleri";
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(500);
                await MainThread.InvokeOnMainThreadAsync(GetSalesDispatchesAsync);

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
        async Task GetSalesDispatchesAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;
                IsRefreshing = false;

                var httpClient = _httpClientService.GetOrCreateHttpClient();

                var result = await _customerTransactionService.GetTransactionByTransactionTypeAndWarehouseAsync(httpClient, SearchText, OrderBy, Current.ReferenceId,Warehouse.Number,"7,8", CurrentPage, PageSize);
                Items.Clear();
                Results.Clear();
                foreach (var item in result.Data)
                {
                    var obj = Mapping.Mapper.Map<DispatchTransaction>(item);
                    Items.Add(obj);
                    Results.Add(obj);
                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Sales Dispatch Error: ", $"{ex.Message}", "Tamam");
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
                        foreach (var item in Items.ToList().Where(x => x.Code.Contains(SearchText) || x.CurrentName.Contains(SearchText) || x.CurrentCode.Contains(SearchText)))
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

                CurrentPage = 0;
                var result = await _customerTransactionService.GetTransactionByTransactionTypeAndWarehouseAsync(httpClient, SearchText, OrderBy, Current.ReferenceId,Warehouse.Number,"7,8", CurrentPage, PageSize);

                if (result.Data.Any())
                {
                    Items.Clear();
                    Results.Clear();
                    foreach (var item in result.Data)
                    {
                        var obj = Mapping.Mapper.Map<DispatchTransaction>(item);
                        Items.Add(obj);
                        Results.Add(obj);
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
        async Task SortAsync()
        {
            if (IsBusy) return;
            try
            {
                string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Tarih Büyükten Küçüğe", "Tarih Küçükten Büyüğe");
                if (!string.IsNullOrEmpty(response))
                {
                    CurrentPage = 0;
                    await Task.Delay(100);
                    switch (response)
                    {
                        case "Tarih Büyükten Küçüğe":
                            Results.Clear();
                            foreach (var item in Items.OrderByDescending(x => x.TransactionDate).ToList())
                            {
                                Results.Add(item);
                            }
                            break;
                        case "Tarih Küçükten Büyüğe":
                            Results.Clear();
                            foreach (var item in Items.OrderBy(x => x.TransactionDate).ToList())
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
                await Shell.Current.DisplayAlert(" Error: ", $"{ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async Task SelectAsync(DispatchTransaction model)
        {
            await Task.Run(() =>
            {
                DispatchTransaction selectedItem = Results.FirstOrDefault(x => x.ReferenceId == model.ReferenceId);
                if (selectedItem != null)
                {
                    if (selectedItem.IsSelected)
                    {
                        selectedItem.IsSelected = false;
                        SelectedTransactions.Remove(selectedItem);

                    }
                    else
                    {
                        selectedItem.IsSelected = true;

                        SelectedTransactions.Add(selectedItem);
                    }
                }

            });
        }

        [RelayCommand]
        async Task GoToSalesDispatchLineListAsync()
        {
            if (SelectedTransactions.Count > 0)
            {
                await Shell.Current.GoToAsync($"{nameof(ReturnBySalesDispatchTransactionLineListView)}", new Dictionary<string, object>
                {
                    [nameof(SelectedTransactions)] = SelectedTransactions,
                    [nameof(Warehouse)] = Warehouse,
					[nameof(Current)] = Current

				});
            }
            else
            {
                await Shell.Current.DisplayAlert("Hata", "Bir sonraki sayfaya gitmek için seçim yapmanız gerekmektedir", "Tamam");
            }

        }


        public async Task SelectAllAsync(bool isSelected)
        {
            if (isSelected)
            {
                foreach (var item in Results)
                {
                    item.IsSelected = true;
                    SelectedTransactions.Add(item);
                }
            }
            else
            {
                foreach (var item in Results)
                {
                    item.IsSelected = false;
                    SelectedTransactions.Remove(item);
                }
            }
        }
    }
}
