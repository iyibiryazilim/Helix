using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderLineViews;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderLineViewModels
{

    [QueryProperty(nameof(SelectedOrderLines), nameof(SelectedOrderLines))]
    public partial class DispatchBySalesOrderLineSelectedLineListViewModel : BaseViewModel
    {
        public DispatchBySalesOrderLineSelectedLineListViewModel()
        {
            Title = "Sipariş Satırı Düzenleme";
            GetOrderLinesCommand = new Command(async () => await LoadData());
            SearchCommand = new Command<string>(async (searchText) => await PerformSearchAsync(searchText));

        }

        [ObservableProperty]
        ObservableCollection<WaitingOrderLine> selectedOrderLines;
        public Command SearchCommand { get; }

        [ObservableProperty]
        string searchText = string.Empty;
        public ObservableCollection<WaitingOrderLine> Results { get; set; } = new();
        public Command GetOrderLinesCommand { get; }



        async Task LoadData()
        {
            if (IsBusy)
                return;
            try
            {
                await Task.Delay(500);
                await MainThread.InvokeOnMainThreadAsync(GetSalesOrderLinesAsync);

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
        async Task GetSalesOrderLinesAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                IsRefreshing = true;
                Results.Clear();
                foreach (var item in SelectedOrderLines)
                {
                    Results.Add(item);
                }


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
                        foreach (var item in SelectedOrderLines.ToList().Where(x => x.OrderCode.Contains(SearchText) || x.ProductCode.Contains(SearchText) || x.ProductName.Contains(SearchText)))
                        {
                            Results.Add(item);
                        }
                    }
                }
                else
                {
                    SearchText = string.Empty;
                    Results.Clear();
                    foreach (var item in SelectedOrderLines)
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
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        async Task SortAsync()
        {
            if (IsBusy) return;
            try
            {
                string response = await Shell.Current.DisplayActionSheet("Sırala", "Vazgeç", null, "Termin Tarihi Büyükten Küçüğe", "Termin Tarihi Küçükten Büyüğe", "Bekleyen Miktar Büyükten Küçüğe", "Bekleyen Miktar Küçükten Büyüğe");
                if (!string.IsNullOrEmpty(response))
                {
                    await Task.Delay(100);
                    switch (response)
                    {
                        case "Termin Tarihi Büyükten Küçüğe":
                            Results.Clear();
                            foreach (var item in SelectedOrderLines.OrderByDescending(x => x.DueDate).ToList())
                            {
                                Results.Add(item);
                            }
                            break;
                        case "Termin Tarihi Küçükten Büyüğe":
                            Results.Clear();
                            foreach (var item in SelectedOrderLines.OrderBy(x => x.DueDate).ToList())
                            {
                                Results.Add(item);
                            }
                            break;
                        case "Bekleyen Miktar Büyükten Küçüğe":
                            Results.Clear();
                            foreach (var item in SelectedOrderLines.OrderByDescending(x => x.TempQuantity).ToList())
                            {
                                Results.Add(item);
                            }
                            break;
                        case "Bekleyen Miktar Küçükten Büyüğe":
                            Results.Clear();
                            foreach (var item in SelectedOrderLines.OrderBy(x => x.TempQuantity).ToList())
                            {
                                Results.Add(item);
                            }
                            break;
                        default:
                            await GetSalesOrderLinesAsync();
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
        async Task RemoveItemAsync(WaitingOrderLine item)
        {

            if (IsBusy)
                return;

            try
            {

                IsBusy = true;
                IsRefreshing = true;

                bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.OrderCode} sipariş numaralı {item.ProductName} isimli ürün çıkartılacaktır.Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");
                if (answer)
                    Results.Remove(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error : ", $"Bir Hata Oluştu:{ex.Message}", "Kapat");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }

        }

        [RelayCommand]
        async Task AddQuantity(WaitingOrderLine item)
        {


            if (item.WaitingQuantity < item.Quantity)
            {
                await Shell.Current.DisplayAlert("Uyarı", "Eklemek istediğiniz miktar bekleyen miktardan fazla", "Tamam");
            }
            else
            {
                item.TempQuantity++;

            }


        }

        [RelayCommand]
        async Task DeleteQuantity(WaitingOrderLine item)
        {
            if (item.TempQuantity != 1)
                item.TempQuantity--;


        }

        [RelayCommand]
        async Task GoToSalesOrderSummary()
        {
            await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderLineSummaryView)}", new Dictionary<string, object>
            {
                ["SelectedOrderLines"] = Results
            });
        }
    }
}
