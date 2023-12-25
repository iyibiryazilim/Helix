using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Views.OperationsViews;
using Helix.UI.Mobile.Modules.SalesModule.Views.OperationsViews.DispatchBySalesOrderView;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.SalesModule.ViewModels.OperationsViewModels
{
	public partial class SalesOperationViewModel : BaseViewModel
	{
        public SalesOperationViewModel()
        {
            Title = "Sevkiyat İşlemleri";
        }
        [RelayCommand]
        async Task GoToDispatchBySalesOrderCustomerView()
        {
            await Shell.Current.GoToAsync($"{nameof(DispatchBySalesOrderCustomerView)}");
        }
    }
}
