using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using Org.Apache.Http.Client;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels;

public partial class ProcurementBottomSheetViewModel :BaseViewModel
{
    public ObservableCollection<ProcurementCustomerOrder> Items { get; } = new();


    [ObservableProperty]
    ProcurementCustomer selectedProcurementCustomer;

    public Command LoadOrderCommand { get; }

    public ProcurementBottomSheetViewModel()
    {
        Title = "Hesaplanan Siparişler";
        LoadOrderCommand = new Command(async () => await LoadOrdersAsync());
    }


    async Task LoadOrdersAsync()
    {
        try
        {
            if (IsBusy) return;

            if (Items.Any())
                Items.Clear();

            if (SelectedProcurementCustomer.Orders.Any())
            {
               await Task.Delay(500);
                foreach (ProcurementCustomerOrder item in SelectedProcurementCustomer.Orders)
                {
                    Items.Add(item);
                }
            }
            

        }
        catch (Exception ex)
        {

            Debug.WriteLine(ex);
        }

       
    }


   











}






