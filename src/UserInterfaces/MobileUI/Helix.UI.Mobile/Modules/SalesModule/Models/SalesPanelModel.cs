using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.Models
{
    public partial class SalesPanelModel:ObservableObject
    {
        [ObservableProperty]
        double? salesCount;

        [ObservableProperty]
        double? salesPurchaseCount;

    }
}
