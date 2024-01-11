using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.DataStores;
using Helix.UI.Mobile.Modules.SalesModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnByPurchaseDispatchTransactionViewModels
{
    public partial class ReturnByPurchaseDispatchTransactionCustomerViewModel :BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly ICustomerService _customerService;
        //Lists
        public ObservableCollection<Current> Items { get; } = new();
        public ObservableCollection<Current> Results { get; } = new();


        [ObservableProperty]
        Current selectedCustomer;

        //Commands
        public Command GetCustomersCommand { get; }
        public Command SearchCommand { get; }

        //Properties
        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        CustomerOrderBy orderBy = CustomerOrderBy.nameasc;
        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 5000;

        public ReturnByPurchaseDispatchTransactionCustomerViewModel(IHttpClientService httpClientService )
        {
            
        }


    }
}
