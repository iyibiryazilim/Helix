using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.SalesModule.Models;

public partial class ProcurementCustomer:ObservableObject
{
    [ObservableProperty]
    public Customer customer;
    [ObservableProperty]
    private double procurementRate;
    [ObservableProperty]
    string image;
    [ObservableProperty]
    bool isSelected;

    public ObservableCollection<ProcurementCustomerOrder> Orders { get; set; }
    public ProcurementCustomer()
    {
        Orders = new();
        
    }

}
