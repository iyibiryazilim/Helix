//using Helix.UI.Mobile.Modules.BaseModule.Models;
using Helix.UI.Mobile.Modules.ProductModule.Models;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class ProductListContentView : ContentView
{
	public static readonly BindableProperty ProductProperty = BindableProperty.Create(nameof(Product), typeof(Product), typeof(ContentView), null);

    public Product Product
    {
        get => (Product)GetValue(ProductListContentView.ProductProperty);
        set => SetValue(ProductListContentView.ProductProperty, value);
    }
    public ProductListContentView()
	{
		InitializeComponent();
	}
}