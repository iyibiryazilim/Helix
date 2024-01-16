using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.Models
{
    public partial class WaitingOrderLineGroup : ObservableObject
    {
        [ObservableProperty]
        string code;

        [ObservableProperty]
        double stockQuantity;

        [ObservableProperty]
        double tempQuantity;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        ObservableCollection<WaitingOrderLine> waitingOrderLines = new();
    }
}
