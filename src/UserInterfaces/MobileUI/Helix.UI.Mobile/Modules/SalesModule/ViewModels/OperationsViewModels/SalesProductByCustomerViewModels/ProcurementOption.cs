using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.SalesProductByCustomerViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels.SalesProductByCustomerViewModels
{
   public partial class ProcurementOption
    {
        //Ürün Toplama
        [RelayCommand]
        async Task GoToProcurementByCustomerView()
        {
            await Shell.Current.GoToAsync($"{nameof(ProcurementByCustomerView)}");
        }
    }
}
