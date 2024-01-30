using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.SalesModule.Models
{
    public partial class SalesFormModel : ObservableObject
    {
        [ObservableProperty]
        string salesDispatch;

        [ObservableProperty]
        DateTime transactionDate = DateTime.Now;

        [ObservableProperty]
        TimeSpan transactionTime=DateTime.Now.TimeOfDay;

        [ObservableProperty]
        string speCode;

        [ObservableProperty]
        Warehouse selectedWarehouse;

        [ObservableProperty]
        Customer selectedCustomer;

        [ObservableProperty]
        string description;

        [ObservableProperty]
        Driver selectedDriver;

        [ObservableProperty]
        Carrier selectedCarrier;

        [ObservableProperty]
        SpeCodeModel selectedSpeCode;


    }
}
