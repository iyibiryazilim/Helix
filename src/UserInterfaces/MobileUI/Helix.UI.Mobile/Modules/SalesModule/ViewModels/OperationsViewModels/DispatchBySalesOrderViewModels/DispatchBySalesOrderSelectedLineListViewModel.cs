using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.DispatchBySalesOrderViewModels
{
    [QueryProperty(nameof(SelectedOrderLines), nameof(SelectedOrderLines))]
    public partial class DispatchBySalesOrderSelectedLineListViewModel : BaseViewModel
    {
        public DispatchBySalesOrderSelectedLineListViewModel()
        {
            Title = "Sipariş Satırı Düzenleme";
        }

        [ObservableProperty]
        ObservableCollection<WaitingOrderLine> selectedOrderLines;

        [RelayCommand]
        async Task RemoveItemAsync(WaitingOrderLine item)
        {

            if (IsBusy)
                return;

            try
            {

                IsBusy = true;
                IsRefreshing = true;

                bool answer = await Application.Current.MainPage.DisplayAlert("Uyarı", $"{item.ProductName} ürün çıkartılacaktır.Devam etmek istiyor musunuz ?", "Çıkart", "Vazgeç");
                if (answer)
                    SelectedOrderLines.Remove(item);
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

            item.TempQuantity++;

            if (item.WaitingQuantity< item.Quantity)
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
    }
}
