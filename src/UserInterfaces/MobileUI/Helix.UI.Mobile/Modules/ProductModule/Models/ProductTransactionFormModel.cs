using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public partial class ProductTransactionFormModel : ObservableObject
    {


        [ObservableProperty]
        DateTime transactionDate;

        [ObservableProperty]
        TimeSpan transactionTime;

        [ObservableProperty]
        Warehouse selectedWarehouse;

        [ObservableProperty]
        string documentryNo;

        [ObservableProperty]
        string speCode;

        [ObservableProperty]
        string documentryTrackingNo;

        [ObservableProperty]
        string description;



    }
}
