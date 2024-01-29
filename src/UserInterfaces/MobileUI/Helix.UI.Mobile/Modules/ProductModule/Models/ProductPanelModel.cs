using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public partial class ProductPanelModel :ObservableObject
    {
        [ObservableProperty]
        double? inputCount;

        [ObservableProperty]
        double? outputCount;



    }
}
