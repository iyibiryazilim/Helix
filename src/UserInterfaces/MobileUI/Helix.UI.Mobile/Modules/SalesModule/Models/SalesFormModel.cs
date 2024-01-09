using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.Models
{
    public partial class SalesFormModel : ObservableObject
    {
        [ObservableProperty]
        string salesDispatch;

        [ObservableProperty]
        TimeSpan transactionDate;

        [ObservableProperty]
        TimeSpan transactionTime;

        [ObservableProperty]
        Current current;

        [ObservableProperty]
        Warehouse warehouse;

        [ObservableProperty]
        string carrier;

        [ObservableProperty]
        string driver;

        [ObservableProperty]
        string speCode;

        [ObservableProperty]
        Warehouse selectedWarehouse;

        [ObservableProperty]
        Customer selectedCustomer;

        [ObservableProperty]
        string description;
    }
}
