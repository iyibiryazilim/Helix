using CommunityToolkit.Mvvm.ComponentModel;

namespace Helix.UI.Mobile.Modules.ProductModule.Models;

public partial class ProductDetailValues : ObservableObject
{
	[ObservableProperty]
	int inputQuantity;
	[ObservableProperty]
	int outputQuantity;
	[ObservableProperty]
	int stockQuantity;
	[ObservableProperty]
	string subUnitsetCode;

    
}
