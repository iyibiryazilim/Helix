using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.PurchaseModule.Models
{
    public partial class PurchasePanelModel :ObservableObject
    {
        [ObservableProperty]
        double? purchaseDispatchCount;

        [ObservableProperty]
        double? salesReturnCount;

    }
}
