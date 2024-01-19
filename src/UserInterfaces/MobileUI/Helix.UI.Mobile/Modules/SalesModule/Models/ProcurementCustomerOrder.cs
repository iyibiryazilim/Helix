using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.SalesModule.Models;

public partial class ProcurementCustomerOrder :ObservableObject
{
    [ObservableProperty]
    private SalesOrderLine salesOrderLine;

    [ObservableProperty]
    private double procurementQuantity;

    [ObservableProperty]
    private double procurementRate;
}
