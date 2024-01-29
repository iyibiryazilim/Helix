using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.BaseModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Models;

public partial class ProcurementCustomerOrder :ObservableObject
{
    [ObservableProperty]
    private SalesOrderLine salesOrderLine;

    [ObservableProperty]
    public double procurementQuantity;

    [ObservableProperty]
    private double procurementRate;
  

  

   
}
