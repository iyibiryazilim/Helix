using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public partial class WarehouseModel : ObservableObject
    {
        [ObservableProperty]
        int warehousereferenceId;

        [ObservableProperty]
        string warehouseName;

        [ObservableProperty]
        short? warehouseNumber;

        [ObservableProperty]
        DateTime? lastTransactionDate;

        [ObservableProperty]
        bool isSelected = false;
    }
}
