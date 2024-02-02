using Android.Views;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.MessageHelper;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;
using Helix.UI.Mobile.MVVMHelper;
using Kotlin.Properties;
using Microsoft.Maui.Controls;
using View = Android.Views.View;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels
{
    public partial class ProcurementOption : BaseViewModel
    {



        //[ObservableProperty]
        //bool selectCustomer = false;

        //[ObservableProperty]
        //bool selectProduct = false;

        [ObservableProperty]
        int selectOption;

        [ObservableProperty]
        bool isCustomer;

        [ObservableProperty]
        bool isProduct;

        [ObservableProperty]
        bool isOrderDate;

        [ObservableProperty]
        bool isSelected;


        public ProcurementOption()
        {
            Title = "Seçim Sayfası";

        }


        //Müşteri listesi sayfasına geçiş
        [RelayCommand]
        async Task GoToProcurementByCustomerListView()
        {
            await Shell.Current.GoToAsync($"{nameof(ProcurementCustomerListView)}");
        }

        [RelayCommand]
        async Task SelectOptionAsync(int option)
        {
            switch (option)
            {
                case 1:
                    IsCustomer = true;
                    IsProduct = false;
                    IsOrderDate = false;

                    break;
                case 2:
                    IsCustomer = false;
                    IsProduct = true;
                    IsOrderDate = false;
                    break;
                case 3:
                    IsCustomer = false;
                    IsProduct = false;
                    IsOrderDate = true;
                    break;

                default:
                    IsCustomer = false;
                    IsProduct = false;
                    IsOrderDate = false;
                    break;
            }
        }

       



        [RelayCommand]
        async Task GoToCustomerList()
        {
            try
            {
                MessageHelper messageHelper = new MessageHelper();

                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                if (IsCustomer)
                    await Shell.Current.GoToAsync($"{nameof(ProcurementCustomerListView)}");
                else if (IsProduct)
                {

                    var toastMessage = messageHelper.GetToastMessage("Yakında..");
                    await toastMessage.Show(cancellationTokenSource.Token);
                }
                else if (IsOrderDate)
                {


                    var toastMessage = messageHelper.GetToastMessage("Yakında..");
                    await toastMessage.Show(cancellationTokenSource.Token);

                }
                else
                    await Shell.Current.DisplayAlert("Error", $"Lütfen seçim yapınız", "Tamam");


            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("Error", $"{ex.Message}", "Tamam");
            }
        }



    }
}
