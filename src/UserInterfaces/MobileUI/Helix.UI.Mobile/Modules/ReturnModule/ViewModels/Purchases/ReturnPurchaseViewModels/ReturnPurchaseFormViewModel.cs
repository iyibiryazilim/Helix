using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.MVVMHelper;

namespace Helix.UI.Mobile.Modules.ReturnModule.ViewModels.Purchases.ReturnPurchaseViewModels;

[QueryProperty(name: nameof(Warehouse), queryId: nameof(Warehouse))]
[QueryProperty(name: nameof(ProductModel), queryId: nameof(ProductModel))]

public partial class ReturnPurchaseFormViewModel :BaseViewModel
{
}
