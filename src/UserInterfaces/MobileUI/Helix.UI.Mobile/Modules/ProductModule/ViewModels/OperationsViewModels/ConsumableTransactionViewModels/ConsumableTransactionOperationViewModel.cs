using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;


namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels;

public partial class ConsumableTransactionOperationViewModel : BaseViewModel 
{
    public ConsumableTransactionOperationViewModel()
    {
        Title = "Sarf İşlemleri";
    }

    public ObservableCollection<ProductModel> Items { get; } = new();


    [RelayCommand]
    async Task GoToSharedProductList()
    {
        await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}", new Dictionary<string, object>
        {
            ["ViewType"] = 12
        });
    }

    [RelayCommand]
    async Task Deneme()
    {
        await Shell.Current.DisplayAlert(Title, Items.FirstOrDefault().Name, "tamam");

    }

}
