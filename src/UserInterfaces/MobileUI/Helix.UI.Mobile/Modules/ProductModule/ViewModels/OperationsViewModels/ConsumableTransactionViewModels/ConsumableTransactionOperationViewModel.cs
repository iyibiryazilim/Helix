﻿using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.BaseModule.SharedViews;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ConsumableTransactionViewModels
{
   public partial class ConsumableTransactionOperationViewModel : BaseViewModel 
    {
        public ConsumableTransactionOperationViewModel()
        {
            Title = "Sarf İşlemleri";
        }
        [RelayCommand]
        async Task GoToSharedProductList()
        {
            await Shell.Current.GoToAsync($"{nameof(SharedProductListView)}");
        }

    }
}
