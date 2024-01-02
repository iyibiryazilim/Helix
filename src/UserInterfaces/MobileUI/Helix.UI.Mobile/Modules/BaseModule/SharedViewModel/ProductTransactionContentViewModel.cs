using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViewModel
{
    public partial class ProductTransactionContentViewModel : BaseViewModel
    {
        
        public ProductTransactionContentViewModel()
        {
            
        }
        [RelayCommand]
        async Task GoToSharedProductList()
        {
            await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}");
        }
        [RelayCommand]
        async Task GoToOperationForm()
        {
            await Shell.Current.GoToAsync($"{nameof(ProductTransactionOperationFormContentView)}");
        }


    }
}
