using Helix.UI.Mobile.Modules.BaseModule.SharedViewModel;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class SalesDispatchFormContentView : ContentView
{ 
	public static readonly BindableProperty WarehouseListProperty = BindableProperty.Create(nameof(WarehouseList),typeof(ObservableCollection<Warehouse>),typeof(SalesDispatchFormContentView));

	public ObservableCollection<Warehouse> WarehouseList
    {
        get => GetValue(WarehouseListProperty) as ObservableCollection<Warehouse>;
        set => SetValue(WarehouseListProperty, value);
    }

    public SalesDispatchFormContentView()
	{
		InitializeComponent();
		
	}
}