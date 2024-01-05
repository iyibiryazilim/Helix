using CommunityToolkit.Mvvm.Input;
using Helix.UI.Mobile.Modules.ProductModule.Models;
using Helix.UI.Mobile.Modules.PurchaseModule.Models;
using Helix.UI.Mobile.Modules.SalesModule.Models;
using System.Collections.ObjectModel;

namespace Helix.UI.Mobile.Modules.BaseModule.SharedViews;

public partial class PurchaseDispatchOperationFormContentView : ContentView
{
    //WarehouseList
    public static readonly BindableProperty WarehouseListProperty = BindableProperty.Create(nameof(WarehouseList), typeof(ObservableCollection<Warehouse>), typeof(SalesDispatchFormContentView));

    //CustomerList
    public static readonly BindableProperty SupplierListProperty = BindableProperty.Create(nameof(SupplierList), typeof(ObservableCollection<Supplier>), typeof(SalesDispatchFormContentView));


    //command 
    //WarehouseCommand
    public static readonly BindableProperty GetWarehouseCommandProperty = BindableProperty.Create(nameof(GetWarehouseCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionOperationFormContentView), null);

    //customerCommand
    public static readonly BindableProperty GetSupplierCommandProperty = BindableProperty.Create(nameof(GetSupplierCommand), typeof(AsyncRelayCommand), typeof(ProductTransactionOperationFormContentView), null);


    //get warehouse
    public AsyncRelayCommand GetWarehouseCommand
    {
        get => GetValue(GetWarehouseCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetWarehouseCommandProperty, value);
    }
    //warehouseList
    public ObservableCollection<Warehouse> WarehouseList
    {
        get => GetValue(WarehouseListProperty) as ObservableCollection<Warehouse>;
        set => SetValue(WarehouseListProperty, value);
    }

    //CustomerList
    public ObservableCollection<Supplier> SupplierList
    {
        get => GetValue(SupplierListProperty) as ObservableCollection<Supplier>;
        set => SetValue(SupplierListProperty, value);
    }
    //get customer
    public AsyncRelayCommand GetSupplierCommand
    {
        get => GetValue(GetSupplierCommandProperty) as AsyncRelayCommand;
        set => SetValue(GetSupplierCommandProperty, value);
    }
    public PurchaseDispatchOperationFormContentView()
	{
		InitializeComponent();
	}
}