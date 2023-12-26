using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Models;

public partial class Warehouse :ObservableObject
{
    [ObservableProperty]
    int referenceId;
    [ObservableProperty]
    string name;
    [ObservableProperty]
    short number;
    [ObservableProperty]
    int divisionreferenceId;
    [ObservableProperty]
    short? divisionNumber;
    [ObservableProperty]
    string divisionCountry;
    [ObservableProperty]
    string divisionCity;
    [ObservableProperty]
    string city;
    [ObservableProperty]
    string country;
    [ObservableProperty]
    string county;
	[ObservableProperty]
	DateTime? lastTransactionDate;

}
