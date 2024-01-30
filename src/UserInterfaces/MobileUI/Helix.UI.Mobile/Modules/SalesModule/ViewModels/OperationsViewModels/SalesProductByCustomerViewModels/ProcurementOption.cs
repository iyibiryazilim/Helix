using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using Kotlin.Properties;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels
{
    public partial class ProcurementOption :BaseViewModel
    {

       

        [ObservableProperty]
        bool selectCustomer = false;

        [ObservableProperty]
        bool selectProduct = false;

        public ProcurementOption()
        {
            Title = "Seçim Sayfası";
            
        }


        //Ürün Toplama
        [RelayCommand]
        async Task GoToProcurementByCustomerListView()
        {
            await Shell.Current.GoToAsync($"{nameof(ProcurementCustomerListView)}");
        }

        [RelayCommand]
        async Task SelectCustomerAsync()
        {
            SelectCustomer= true;
            SelectProduct = false;
        }

        [RelayCommand]
        async Task SelectProductAsync()
        {
            SelectCustomer = false;
            SelectProduct = true;
        }


    }
}
