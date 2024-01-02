using CommunityToolkit.Mvvm.ComponentModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.ProductModule.ViewModels.OperationsViewModels.ProductionTransactionOperationViewModels
{
    [QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]
    public partial class ProductionTransactionOperationFormViewModel: BaseViewModel
    {
        [ObservableProperty]
        ObservableCollection<ProductModel> productModel;
        public ProductionTransactionOperationFormViewModel()
        {
            Title = "Üretimden Giriş İşlemleri";
        }
    }
}
