using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.ProductModule.Models
{
    public partial class ProductTransactionFormModel : ObservableObject
    {


        [ObservableProperty]
        DateTime transactionDate = DateTime.Now;

        [ObservableProperty]
        TimeSpan transactionTime=DateTime.Now.TimeOfDay;

        [ObservableProperty]
        string documentryNo = string.Empty;

        [ObservableProperty]
        string speCode = string.Empty;

        [ObservableProperty]
        string documentryTrackingNo = string.Empty; 

        [ObservableProperty]
        string description = string.Empty;



    }
}
