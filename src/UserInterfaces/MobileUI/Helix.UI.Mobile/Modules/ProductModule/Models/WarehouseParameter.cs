using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public partial class WarehouseParameter :ObservableObject
    {
        [ObservableProperty]
        short warehouseNumber;

        [ObservableProperty]
        string warehouseName;

        [ObservableProperty]
        double? minLevel;

        [ObservableProperty]
        double? maxLevel;

        [ObservableProperty]
        double? safeLevel;

        [ObservableProperty]
        double? stockQuantity;

        
    }
}
