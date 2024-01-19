using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Helpers.HttpClientHelper;
using Helix.UI.Mobile.Modules.BaseModule.Services;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Services;
using Helix.UI.Mobile.MVVMHelper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels
{
    [QueryProperty(name: nameof(Product), queryId: nameof(Product))]

    public partial class ProcurementSelectWarehouse :BaseViewModel
    {
        IHttpClientService _httpClientService;
        private readonly IWarehouseService _warehouseService;
        ICustomQueryService _customQueryService;
        //Lists
        public ObservableCollection<Warehouse> Items { get; } = new();
        public ObservableCollection<Warehouse> Results { get; } = new();


        //Commands
        public Command GetWarehousesCommand { get; }
        public Command SearchCommand { get; }

        //Properties
        [ObservableProperty]
        string searchText = string.Empty;
        [ObservableProperty]
        WarehouseOrderBy orderBy = WarehouseOrderBy.numberasc;
        [ObservableProperty]
        int currentPage = 0;
        [ObservableProperty]
        int pageSize = 1000;

        [ObservableProperty]
        Warehouse selectedWarehouse;

        [ObservableProperty]
        Product product;


    }
}
